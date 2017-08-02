namespace StoneTank.Yukiusagi
{
    partial class AuthorizeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizeDialog));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.consumerKeyTextBox = new System.Windows.Forms.TextBox();
            this.consumerSecretTextBox = new System.Windows.Forms.TextBox();
            this.consumerKeyLabel = new System.Windows.Forms.Label();
            this.consumerSecretLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(278, 166);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(84, 24);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(368, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(84, 24);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "キャンセル(&C)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(389, 45);
            this.label.TabIndex = 0;
            this.label.Text = "Twitter API の Consumer Key と Consumer Secret を入力してください。\r\nまだ Consumer Key と Consum" +
    "er Secret を取得していない場合、\r\nそれらを取得してから続行してください。";
            // 
            // consumerKeyTextBox
            // 
            this.consumerKeyTextBox.Location = new System.Drawing.Point(153, 70);
            this.consumerKeyTextBox.Name = "consumerKeyTextBox";
            this.consumerKeyTextBox.Size = new System.Drawing.Size(299, 23);
            this.consumerKeyTextBox.TabIndex = 2;
            // 
            // consumerSecretTextBox
            // 
            this.consumerSecretTextBox.Location = new System.Drawing.Point(153, 99);
            this.consumerSecretTextBox.Name = "consumerSecretTextBox";
            this.consumerSecretTextBox.Size = new System.Drawing.Size(299, 23);
            this.consumerSecretTextBox.TabIndex = 4;
            // 
            // consumerKeyLabel
            // 
            this.consumerKeyLabel.AutoSize = true;
            this.consumerKeyLabel.Location = new System.Drawing.Point(12, 73);
            this.consumerKeyLabel.Name = "consumerKeyLabel";
            this.consumerKeyLabel.Size = new System.Drawing.Size(119, 15);
            this.consumerKeyLabel.TabIndex = 1;
            this.consumerKeyLabel.Text = "Consumer Key (&K):";
            // 
            // consumerSecretLabel
            // 
            this.consumerSecretLabel.AutoSize = true;
            this.consumerSecretLabel.Location = new System.Drawing.Point(12, 102);
            this.consumerSecretLabel.Name = "consumerSecretLabel";
            this.consumerSecretLabel.Size = new System.Drawing.Size(135, 15);
            this.consumerSecretLabel.TabIndex = 3;
            this.consumerSecretLabel.Text = "Consumer Secret (&C):";
            // 
            // AuthorizeDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 202);
            this.Controls.Add(this.consumerSecretLabel);
            this.Controls.Add(this.consumerKeyLabel);
            this.Controls.Add(this.consumerSecretTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.consumerKeyTextBox);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorizeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ゆきうさぎ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox consumerKeyTextBox;
        private System.Windows.Forms.TextBox consumerSecretTextBox;
        private System.Windows.Forms.Label consumerKeyLabel;
        private System.Windows.Forms.Label consumerSecretLabel;
    }
}