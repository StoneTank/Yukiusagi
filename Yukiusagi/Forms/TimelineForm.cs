using CoreTweet;
using CoreTweet.Core;
using StoneTank.Yukiusagi.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
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
        public TimelineForm(TimelineProperty property)
        {
            InitializeComponent();

            // PersistString を決める
            TimelineProperty = property;

            // DockContent を区別するための文字列 ("0:TimelineForm" の形式)
            PersistString = $"{Settings.Default.TabId}:{nameof(TimelineForm)}";
            TimelineProperty.FormPersistString = PersistString;

            if (Settings.Default.TabId == ulong.MaxValue)
            {
                Settings.Default.TabId = 0; // やむを得ない
            }
            else
            {
                Settings.Default.TabId++;
            }

            JsFront = new JsFront(TimelineProperty);
        }

        /// <summary>
        /// TimelineForm を初期化します
        /// </summary>
        public TimelineForm(string persistString)
        {
            InitializeComponent();

            PersistString = persistString;

            if (Settings.Default.TimelineProperties.Exists((p => p.FormPersistString == PersistString)))
            {
                TimelineProperty = Settings.Default.TimelineProperties.Find((p => p.FormPersistString == PersistString));

                this.Text = this.TabText = TimelineProperty.Text;
            }
            else
            {
                throw new TimelineSetupException();
            }

            JsFront = new JsFront(TimelineProperty);
        }

        /// <summary>
        /// StatusResponse を使用して新しいステータスを現在のタイムラインに追加します。
        /// </summary>
        /// <param name="response">追加するステータスの StatusResponse。</param>
        public void NewStatus(StatusResponse response)
        {
            JsFront.Statuses.Add(response);

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["AddStatusFunctionName"] as string, new object[] { response.Json });
            }
        }

        /// <summary>
        /// ListResponse&lt;Status&gt; を使用して新しいステータスを現在のタイムラインに追加します。
        /// </summary>
        /// <param name="response">追加するステータスの ListedResponse。</param>
        public void NewStatusRange(ListedResponse<Status> response)
        {
            JsFront.Statuses.AddRange(response.OrderBy(s => s.Id));

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["AddStatusRangeFunctionName"] as string, new object[] { response.Json });
            }
        }

        /// <summary>
        /// IEnumerable&lt;Status&gt; およびそれらを表す JSON を使用して新しいステータスを現在のタイムラインに追加します。
        /// </summary>
        /// <param name="statuses">追加するステータスの IEnumerable。</param>
        /// <param name="json">追加する複数のステータスの JSON。</param>
        public void NewStatusRange(IEnumerable<Status> statuses, string json)
        {
            JsFront.Statuses.AddRange(statuses.OrderBy(s => s.Id));

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["AddStatusRangeFunctionName"] as string, new object[] { json });
            }
        }

        /// <summary>
        /// 複数の ListedResponse&lt;Status&gt; を使用して新しいステータスを現在のタイムラインに追加します。
        /// </summary>
        /// <param name="responses">追加するステータスの ListedResponse。</param>
        public void NewStatusRangeFromMultipleLists(ListedResponse<Status>[] responses)
        {
            List<Status> statuses = new List<Status>();
            StringBuilder json = new StringBuilder();

            json.Append("[");

            for (int i = 0; i < responses.Length; i++)
            {
                statuses.AddRange(responses[i]);
                json.Append(responses[i].Json);

                if (i < responses.Length - 1)
                {
                    json.Append(",");
                }
            }

            json.Append("]");

            JsFront.Statuses.AddRange(statuses.OrderBy(s => s.Id));

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["AddStatusRangeFromMultipleListsFunctionName"] as string, new object[] { json });
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

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                webBrowser.Document.InvokeScript(ConfigurationManager.AppSettings["RemoveStatusFunctionName"] as string, new object[] { id.ToString() });
            }
        }

        private void TimelineForm_Load(object sender, EventArgs e)
        {
            webBrowser.ObjectForScripting = JsFront;

            // タイムライン HTML の URI 生成
            var baseUri = new Uri($"file:///{Application.StartupPath.Replace(Path.DirectorySeparatorChar, '/')}/");
            var uri = new Uri(baseUri, ConfigurationManager.AppSettings["TimelineHtmlUri"]);

            if (File.Exists(uri.LocalPath))
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
