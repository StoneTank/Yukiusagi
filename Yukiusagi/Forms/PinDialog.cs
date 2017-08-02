using System;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    public partial class PinDialog : Form
    {
        /// <summary>
        /// 入力されたPINコードを取得します
        /// </summary>
        public string Pin { get { return pin; } }

        private string pin;

        public PinDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (pinTextBox.Text.Trim() == "")
            {
                MessageBox.Show(this, "PIN を入力してください。", "ゆきうさぎ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pinTextBox.Focus();
            }
            else
            {
                pin = pinTextBox.Text.Trim();
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
