using CoreTweet;
using StoneTank.Yukiusagi.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    public partial class TimelineForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region Properties

        /// <summary>
        /// JavaScript といっしょにがんばる
        /// </summary>
        public JsFront JsFront { get; set; }

        /// <summary>
        /// タイムラインのプロパティ
        /// </summary>
        public TimelineProperty TimelineProperty { get; set; }

        /// <summary>
        /// DockContent を区別するための文字列
        /// </summary>
        public string PersistString { get; set; }

        #endregion

        /// <summary>
        /// Overrides GetPersistString()
        /// </summary>
        protected override string GetPersistString()
        {
            return PersistString;
        }

        /// <summary>
        /// TimelineForm を初期化します
        /// </summary>
        public TimelineForm()
        {
            InitializeComponent();

            // PersistString が空の場合は決める

            if (string.IsNullOrEmpty(PersistString))
            {
                // DockContent を区別するための文字列 ("0:TimelineForm" の形式)
                PersistString = $"{Settings.Default.TabId}:{nameof(TimelineForm)}";

                if (Settings.Default.TabId == ulong.MaxValue)
                {
                    Settings.Default.TabId = 0; // やむを得ない
                }
                else
                {
                    Settings.Default.TabId++;
                }
            }
            else
            {
                if (Settings.Default.TimelineProperties.ContainsKey(PersistString))
                {
                    TimelineProperty = Settings.Default.TimelineProperties[PersistString];

                    this.Text = this.TabText = TimelineProperty.Text;
                }
                else
                {
                    throw new TimelineSetupException();
                }
            }

            JsFront = new JsFront(TimelineProperty);
        }

        /// <summary>
        /// ステータスを追加して表示します
        /// </summary>
        /// <param name="status">追加するステータス</param>
        public async void NewStatus(Status status)
        {
            JsFront.Statuses.Add(status);

            // JavaScript に投げる JSON
            string json = await Task.Run(() => Newtonsoft.Json.JsonConvert.SerializeObject(status));

            if (!webBrowser.IsBusy)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["AddStatusFunctionName"], new object[] { json });
            }
        }

        /// <summary>
        /// 複数のステータスを追加して表示します
        /// </summary>
        /// <param name="statuses">追加するステータス</param>
        public async void NewStatusRange(List<Status> statuses)
        {
            JsFront.Statuses.AddRange(statuses);

            // JavaScript に投げる JSON
            string json = await Task.Run(() => Newtonsoft.Json.JsonConvert.SerializeObject(statuses));

            if (!webBrowser.IsBusy)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["AddStatusRangeFunctionName"], new object[] { json });
            }
        }

        /// <summary>
        /// 指定されたIDのステータスを削除します
        /// </summary>
        /// <param name="id">削除するステータスID</param>
        public void RemoveStatus(long id)
        {
            if (JsFront.Statuses.Exists(s => s.Id == id))
            {
                JsFront.Statuses.RemoveAll(s => s.Id == id);
            }

            if (!webBrowser.IsBusy)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["RemoveStatusFunctionName"], new object[] { id });
            }
        }

        private void TimelineForm_Load(object sender, EventArgs e)
        {
            webBrowser.ObjectForScripting = JsFront;

            // タイムライン HTML の URI 生成
            var baseUri = new Uri($"file:///{Application.StartupPath.Replace(Path.DirectorySeparatorChar, '/')}/");
            var uri = new Uri(baseUri, ConfigurationManager.AppSettings["TimelineHtmlUri"]);

            if (File.Exists(uri.ToString()))
            {
                webBrowser.Navigate(uri);
            }
            else
            {
                MessageBox.Show(this.ParentForm, "指定されたタイムライン HTML ファイルが存在しません。", "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// タイムラインの初期化を失敗してす、しまったのですが！！
    /// </summary>
    public class TimelineSetupException : Exception
    {
        public TimelineSetupException() { }
        public TimelineSetupException(string message) : base(message) { }
        public TimelineSetupException(string message, Exception innerException) : base(message, innerException) { }
    }
}
