using System;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    public partial class OptionsDialog : Form
    {
        public int StatusesCount { get; set; }

        public bool MediaPossiblySensitive { get; set; }

        public bool NotificationEnabled { get; set; }

        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            statusesCountNumericUpDown.Value = (decimal)StatusesCount;
            mediaPossiblySensitiveCheckBox.Checked = MediaPossiblySensitive;
            notificationEnabledCheckBox.Checked = NotificationEnabled;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StatusesCount = (int)statusesCountNumericUpDown.Value;
            MediaPossiblySensitive = mediaPossiblySensitiveCheckBox.Checked;
            NotificationEnabled = notificationEnabledCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
