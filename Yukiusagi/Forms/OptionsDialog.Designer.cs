namespace StoneTank.Yukiusagi
{
    partial class OptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusesCountLabel2 = new System.Windows.Forms.Label();
            this.statusesCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mediaPossiblySensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.otherSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationEnabledCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusesCountNumericUpDown)).BeginInit();
            this.otherSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(278, 166);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(84, 24);
            this.okButton.TabIndex = 0;
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
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "キャンセル(&C)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // statusesCountLabel2
            // 
            this.statusesCountLabel2.AutoSize = true;
            this.statusesCountLabel2.Location = new System.Drawing.Point(6, 24);
            this.statusesCountLabel2.Name = "statusesCountLabel2";
            this.statusesCountLabel2.Size = new System.Drawing.Size(161, 15);
            this.statusesCountLabel2.TabIndex = 0;
            this.statusesCountLabel2.Text = "REST API 取得ツイート数(&T):";
            // 
            // statusesCountNumericUpDown
            // 
            this.statusesCountNumericUpDown.Location = new System.Drawing.Point(173, 22);
            this.statusesCountNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.statusesCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.statusesCountNumericUpDown.Name = "statusesCountNumericUpDown";
            this.statusesCountNumericUpDown.Size = new System.Drawing.Size(64, 23);
            this.statusesCountNumericUpDown.TabIndex = 1;
            this.statusesCountNumericUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // mediaPossiblySensitiveCheckBox
            // 
            this.mediaPossiblySensitiveCheckBox.AutoSize = true;
            this.mediaPossiblySensitiveCheckBox.Location = new System.Drawing.Point(9, 51);
            this.mediaPossiblySensitiveCheckBox.Name = "mediaPossiblySensitiveCheckBox";
            this.mediaPossiblySensitiveCheckBox.Size = new System.Drawing.Size(260, 19);
            this.mediaPossiblySensitiveCheckBox.TabIndex = 2;
            this.mediaPossiblySensitiveCheckBox.Text = "アップロードするメディアは不適切な内容を含む(&S)";
            this.mediaPossiblySensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // otherSettingsGroupBox
            // 
            this.otherSettingsGroupBox.Controls.Add(this.notificationEnabledCheckBox);
            this.otherSettingsGroupBox.Controls.Add(this.statusesCountNumericUpDown);
            this.otherSettingsGroupBox.Controls.Add(this.statusesCountLabel2);
            this.otherSettingsGroupBox.Controls.Add(this.mediaPossiblySensitiveCheckBox);
            this.otherSettingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.otherSettingsGroupBox.Name = "otherSettingsGroupBox";
            this.otherSettingsGroupBox.Size = new System.Drawing.Size(440, 103);
            this.otherSettingsGroupBox.TabIndex = 2;
            this.otherSettingsGroupBox.TabStop = false;
            this.otherSettingsGroupBox.Text = "設定";
            // 
            // notificationEnabledCheckBox
            // 
            this.notificationEnabledCheckBox.AutoSize = true;
            this.notificationEnabledCheckBox.Checked = true;
            this.notificationEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notificationEnabledCheckBox.Location = new System.Drawing.Point(9, 76);
            this.notificationEnabledCheckBox.Name = "notificationEnabledCheckBox";
            this.notificationEnabledCheckBox.Size = new System.Drawing.Size(130, 19);
            this.notificationEnabledCheckBox.TabIndex = 3;
            this.notificationEnabledCheckBox.Text = "通知を有効にする(&N)";
            this.notificationEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 202);
            this.Controls.Add(this.otherSettingsGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "オプション";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusesCountNumericUpDown)).EndInit();
            this.otherSettingsGroupBox.ResumeLayout(false);
            this.otherSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusesCountLabel2;
        private System.Windows.Forms.NumericUpDown statusesCountNumericUpDown;
        private System.Windows.Forms.CheckBox mediaPossiblySensitiveCheckBox;
        private System.Windows.Forms.GroupBox otherSettingsGroupBox;
        private System.Windows.Forms.CheckBox notificationEnabledCheckBox;
    }
}