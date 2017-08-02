using System;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    public partial class AuthorizeDialog : Form
    {

        public string ConsumerKey { get { return consumerKey; } }
        public string ConsumerSecret { get { return consumerSecret; } }

        private string consumerKey;
        private string consumerSecret;

        public AuthorizeDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (consumerKeyTextBox.Text.Trim() == "上上下下左右左右BA")
            {
                Properties.Settings.Default.Save();
                MessageBox.Show(this, "Saved settings.", "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                consumerKeyTextBox.SelectAll();
            }
            else if (consumerKeyTextBox.Text.Trim() == "")
            {
                MessageBox.Show(this, "Consumer Key を入力してください。", "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (consumerSecretLabel.Text.Trim() == "")
            {
                MessageBox.Show(this, "Consumer Secret を入力してください。", "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                consumerKey = consumerKeyTextBox.Text.Trim();
                consumerSecret = consumerSecretTextBox.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
