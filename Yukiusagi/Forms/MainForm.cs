using CoreTweet;
using StoneTank.Yukiusagi.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace StoneTank.Yukiusagi
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Accounts of Twitter
        /// </summary>
        private List<TwitterAccount> TwitterAccounts = new List<TwitterAccount>();

        /// <summary>
        /// アップロードしようとしているファイル名
        /// </summary>
        private List<string> UploadingFileNames = new List<string>();

        /// <summary>
        /// アップロード用一時ファイル名
        /// </summary>
        private string UploadingTempFileName;

        /// <summary>
        /// リプライ先ステータス
        /// </summary>
        private Status ReplyTo;

        #region Private メソッド

        /// <summary>
        /// 通知を表示します。
        /// </summary>
        private void Notify(int timeout, string title, string text, ToolTipIcon icon)
        {
            if (Settings.Default.NotificationEnabled)
            {
                notifyIcon.ShowBalloonTip(timeout, title, text, icon);
            }
        }
        
        /// <summary>
        /// ツイートの字数を計算して表示します。
        /// </summary>
        private void ShowTweetLength()
        {
            // メディアありの場合は短縮URLの字数を加算する
            int length = tweetTextBox.Text.Replace("\r\n", "\n").Length +
                ((UploadingFileNames.Count > 0) ? TwitterAccounts.FirstOrDefault().AccountData.ShortUrlLengthHttps : 0); // Umm... which account should i use?

            // URLは短縮URLの字数で計算する
            foreach (Match match in Define.UrlRegex.Matches(tweetTextBox.Text))
            {
                length -= match.Length;
                length += TwitterAccounts.FirstOrDefault().AccountData.ShortUrlLengthHttps; // which account should i use?
            }

            tweetLengthLabel.Text = length.ToString();
        }

        #endregion

        #region 通知関係

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            this.BringToFront();
            this.Activate();
        }

        #endregion

        #region MainForm

        public MainForm()
        {
            InitializeComponent();

            dockPanel.Theme = new VS2015LightTheme();

            this.Location = Settings.Default.WindowLocation;
            this.Size = Settings.Default.WindowSize;
            this.WindowState = Settings.Default.WindowState;

            splitContainer.SplitterDistance = Settings.Default.SplitterDistance;

            tweetTextBox.Font = Settings.Default.Font;

            // レイアウト情報
            if (!string.IsNullOrEmpty(Settings.Default.WindowLayout))
            {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(Settings.Default.WindowLayout)))
                {
                    dockPanel.LoadFromXml(stream, new DeserializeDockContent(new Func<string, IDockContent>(s =>
                    {
                        // 文字列から該当する Form を見つけて返す
                        if (s.EndsWith(nameof(TimelineForm)))
                        {
                            return new TimelineForm();
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    })));
                }
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                SplashForm splash = new SplashForm();
                splash.Show(this);

                try
                {
                    if (Settings.Default.TwitterAccounts.Count == 0)
                    {
                        // 新規認証

                        using (AuthorizeDialog dialog = new AuthorizeDialog())
                        {
                            if (dialog.ShowDialog(this) == DialogResult.OK)
                            {
                                TwitterAccount account = new TwitterAccount();
                                await account.AuthorizeAsync(dialog.ConsumerKey, dialog.ConsumerSecret, this);

                                TwitterAccounts.Add(account);
                            }
                            else
                            {
                                throw new OperationCanceledException();
                            }
                        }
                    }
                    else
                    {
                        TwitterAccounts = Settings.Default.TwitterAccounts;
                        await Task.WhenAll(TwitterAccounts.Select(async account => await account.CreateAsync()));
                    }
                }
                catch (OperationCanceledException)
                {
                    Application.Exit();
                }
                catch (HttpRequestException httpRequestException)
                {
                    MessageBox.Show("ネットワークエラーのためアプリケーションの初期化に失敗しました。ネットワーク接続を確認してください。\r\n" + httpRequestException.Message,
                        "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("予期しないエラーのためアプリケーションの初期化に失敗しました。\r\n" + ex.Message,
                        "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    Application.Exit();
                }
                finally
                {
                    splash.Close();
                }
            }
            else
            {
                MessageBox.Show("ネットワーク接続がオフラインのようです。ネットワーク接続を確認してください。", "ゆきうさぎ",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;

            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                // 設定の保存
                Settings.Default.WindowState = this.WindowState;

                if (this.WindowState == FormWindowState.Normal)
                {
                    Settings.Default.WindowLocation = this.Location;
                    Settings.Default.WindowSize = this.Size;
                }
                else
                {
                    Settings.Default.WindowLocation = this.RestoreBounds.Location;
                    Settings.Default.WindowSize = this.RestoreBounds.Size;
                }

                Settings.Default.SplitterDistance = splitContainer.SplitterDistance;
                
                // レイアウト情報を同じファイルにつっこむ
                using (MemoryStream stream = new MemoryStream())
                {
                    dockPanel.SaveAsXml(stream, Encoding.UTF8);
                    Settings.Default.WindowLayout = Encoding.UTF8.GetString(stream.ToArray());
                }

                Settings.Default.Save();
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }

        #endregion

        #region ツイート入力欄まわり

        private void SendButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TweetTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowTweetLength();
        }

        private void TweetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyData == Settings.Default.PostShortcutKey)
            {
                sendButton.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                tweetTextBox.SelectAll();
            }
        }

        private void ReplyInfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(this, "リプライを取り消しますか?", "ゆきうさぎ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ReplyTo = null;
                replyInfoLinkLabel.Text = "";
                replyInfoLinkLabel.Visible = false;
                tweetTextBox.Focus();
                tweetTextBox.Select(tweetTextBox.Text.Length, 0);
            }
        }

        private void PhotoCheckBox_Click(object sender, EventArgs e)
        {
            if (UploadingFileNames.Count > 0)
            {
                if (MessageBox.Show(this, "メディアの添付を取り消しますか?", "ゆきうさぎ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UploadingFileNames.Clear();
                    photoCheckBox.Checked = false;
                    ShowTweetLength();
                    tweetTextBox.Focus();
                }
            }
            else
            {
                // 画像添付
                openFileDialog.Filter = "アップロード対応形式|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (openFileDialog.FileNames.Length > 4)
                    {
                        MessageBox.Show(this, "5つ以上のファイルが選択されました。1つのツイートに添付できる画像ファイルは4つまでです。ファイルを選択しなおしてください。", "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        UploadingFileNames.Clear();
                        UploadingFileNames.AddRange(openFileDialog.FileNames);

                        statusLabel.Text = $"{UploadingFileNames.Count}個のアイテムが選択されました";

                        photoCheckBox.Checked = true;
                        ShowTweetLength();
                        tweetTextBox.Focus();
                    }
                }
            }
        }

        private void FromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                UploadingFileNames.Clear();

                UploadingTempFileName = Path.GetTempFileName();

                using (Image image = Clipboard.GetImage())
                {
                    using (FileStream stream = new FileStream(UploadingTempFileName, FileMode.Create, FileAccess.Write))
                    {
                        image.Save(stream, ImageFormat.Png);
                    }

                    UploadingFileNames.Add(UploadingTempFileName);

                    statusLabel.Text = $"{UploadingFileNames.Count}個のアイテムが選択されました";

                    photoCheckBox.Checked = true;
                    ShowTweetLength();
                    tweetTextBox.Focus();
                }
            }
        }

        #endregion

        #region メニュー
        
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TweetPanelToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer.Panel1Collapsed = !tweetPanelToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.Font;

            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.Font = fontDialog.Font;
                tweetTextBox.Font = fontDialog.Font;
            }
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutDialog dialog = new AboutDialog())
            {
                dialog.ShowDialog(this);
            }
        }

        #endregion
    }
}
