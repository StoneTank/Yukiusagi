using StoneTank.Yukiusagi.Properties;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    public partial class TimelineForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        /// <summary>
        /// JavaScript といっしょにがんばる
        /// </summary>
        public JsFront JsFront { get; set; } = new JsFront();

        // DockContent を区別するための文字列
        private string persistString;

        protected override string GetPersistString()
        {
            return persistString;
        }

        public TimelineForm()
        {
            InitializeComponent();

            // DockContent を区別するための文字列
            // "0:TimelineForm" の形式
            persistString = $"{Settings.Default.TabId}:{nameof(TimelineForm)}";

            if (Settings.Default.TabId == ulong.MaxValue)
            {
                Settings.Default.TabId = 0; // やむを得ない
            }
            else
            {
                Settings.Default.TabId++;
            }
        }

        private void TimelineForm_Load(object sender, EventArgs e)
        {
            webBrowser.ObjectForScripting = JsFront;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TimelineHtmlUri"]))
            {
                var baseUri = new Uri($"file:///{Application.StartupPath.Replace(Path.DirectorySeparatorChar, '/')}");

                webBrowser.Navigate(new Uri(baseUri, ConfigurationManager.AppSettings["TimelineHtmlUri"]));
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
