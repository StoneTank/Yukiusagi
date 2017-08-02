namespace StoneTank.Yukiusagi
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tweetPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tweetTextBox = new System.Windows.Forms.TextBox();
            this.replyInfoLinkLabel = new System.Windows.Forms.LinkLabel();
            this.accountSelectPanel = new System.Windows.Forms.Panel();
            this.accountsButton = new System.Windows.Forms.Button();
            this.tweetButtonsPanel = new System.Windows.Forms.Panel();
            this.photoCheckBox = new System.Windows.Forms.CheckBox();
            this.mediaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tweetLengthLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.accountsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.accountSelectPanel.SuspendLayout();
            this.tweetButtonsPanel.SuspendLayout();
            this.mediaContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.fileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // streamToolStripMenuItem
            // 
            this.streamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStreamToolStripMenuItem,
            this.stopStreamToolStripMenuItem});
            this.streamToolStripMenuItem.Name = "streamToolStripMenuItem";
            this.streamToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.streamToolStripMenuItem.Text = "User Stream(&S)";
            // 
            // startStreamToolStripMenuItem
            // 
            this.startStreamToolStripMenuItem.Name = "startStreamToolStripMenuItem";
            this.startStreamToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.startStreamToolStripMenuItem.Text = "接続(&C)";
            // 
            // stopStreamToolStripMenuItem
            // 
            this.stopStreamToolStripMenuItem.Name = "stopStreamToolStripMenuItem";
            this.stopStreamToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.stopStreamToolStripMenuItem.Text = "切断(&D)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.quitToolStripMenuItem.Text = "アプリケーションの終了(&X)";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tweetPanelToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.viewToolStripMenuItem.Text = "表示(&V)";
            // 
            // tweetPanelToolStripMenuItem
            // 
            this.tweetPanelToolStripMenuItem.Checked = true;
            this.tweetPanelToolStripMenuItem.CheckOnClick = true;
            this.tweetPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tweetPanelToolStripMenuItem.Name = "tweetPanelToolStripMenuItem";
            this.tweetPanelToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.tweetPanelToolStripMenuItem.Text = "ツイートパネル(&P)";
            this.tweetPanelToolStripMenuItem.CheckedChanged += new System.EventHandler(this.TweetPanelToolStripMenuItem_CheckedChanged);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.statusBarToolStripMenuItem.Text = "ステータスバー(&S)";
            this.statusBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.StatusBarToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.toolsToolStripMenuItem.Text = "ツール(&T)";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.fontToolStripMenuItem.Text = "ツイート入力欄のフォント(&F)...";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.optionsToolStripMenuItem.Text = "オプション(&O)...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.helpToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.aboutToolStripMenuItem.Text = "バージョン情報(&A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(45, 17);
            this.statusLabel.Text = "Status";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tweetTextBox);
            this.splitContainer.Panel1.Controls.Add(this.replyInfoLinkLabel);
            this.splitContainer.Panel1.Controls.Add(this.accountSelectPanel);
            this.splitContainer.Panel1.Controls.Add(this.tweetButtonsPanel);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.splitContainer.Panel1MinSize = 72;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dockPanel);
            this.splitContainer.Size = new System.Drawing.Size(784, 516);
            this.splitContainer.SplitterDistance = 72;
            this.splitContainer.TabIndex = 1;
            // 
            // tweetTextBox
            // 
            this.tweetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tweetTextBox.Location = new System.Drawing.Point(45, 21);
            this.tweetTextBox.Multiline = true;
            this.tweetTextBox.Name = "tweetTextBox";
            this.tweetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tweetTextBox.Size = new System.Drawing.Size(669, 51);
            this.tweetTextBox.TabIndex = 2;
            this.tweetTextBox.TextChanged += new System.EventHandler(this.TweetTextBox_TextChanged);
            this.tweetTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TweetTextBox_KeyDown);
            // 
            // replyInfoLinkLabel
            // 
            this.replyInfoLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HighlightText;
            this.replyInfoLinkLabel.AutoEllipsis = true;
            this.replyInfoLinkLabel.BackColor = System.Drawing.SystemColors.Highlight;
            this.replyInfoLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.replyInfoLinkLabel.LinkColor = System.Drawing.SystemColors.HighlightText;
            this.replyInfoLinkLabel.Location = new System.Drawing.Point(45, 3);
            this.replyInfoLinkLabel.Name = "replyInfoLinkLabel";
            this.replyInfoLinkLabel.Size = new System.Drawing.Size(669, 18);
            this.replyInfoLinkLabel.TabIndex = 1;
            this.replyInfoLinkLabel.TabStop = true;
            this.replyInfoLinkLabel.Text = "Reply to @screen_name: \"Text\"";
            this.replyInfoLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.replyInfoLinkLabel, "クリックして取り消します。");
            this.replyInfoLinkLabel.UseMnemonic = false;
            this.replyInfoLinkLabel.Visible = false;
            this.replyInfoLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HighlightText;
            this.replyInfoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ReplyInfoLinkLabel_LinkClicked);
            // 
            // accountSelectPanel
            // 
            this.accountSelectPanel.Controls.Add(this.accountsButton);
            this.accountSelectPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.accountSelectPanel.Location = new System.Drawing.Point(3, 3);
            this.accountSelectPanel.Margin = new System.Windows.Forms.Padding(0);
            this.accountSelectPanel.Name = "accountSelectPanel";
            this.accountSelectPanel.Size = new System.Drawing.Size(42, 69);
            this.accountSelectPanel.TabIndex = 0;
            // 
            // accountsButton
            // 
            this.accountsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountsButton.Location = new System.Drawing.Point(0, 0);
            this.accountsButton.Name = "accountsButton";
            this.accountsButton.Size = new System.Drawing.Size(42, 69);
            this.accountsButton.TabIndex = 1;
            this.accountsButton.UseVisualStyleBackColor = true;
            // 
            // tweetButtonsPanel
            // 
            this.tweetButtonsPanel.Controls.Add(this.photoCheckBox);
            this.tweetButtonsPanel.Controls.Add(this.tweetLengthLabel);
            this.tweetButtonsPanel.Controls.Add(this.sendButton);
            this.tweetButtonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.tweetButtonsPanel.Location = new System.Drawing.Point(714, 3);
            this.tweetButtonsPanel.Name = "tweetButtonsPanel";
            this.tweetButtonsPanel.Size = new System.Drawing.Size(70, 69);
            this.tweetButtonsPanel.TabIndex = 3;
            // 
            // photoCheckBox
            // 
            this.photoCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.photoCheckBox.AutoCheck = false;
            this.photoCheckBox.ContextMenuStrip = this.mediaContextMenuStrip;
            this.photoCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.photoCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("photoCheckBox.Image")));
            this.photoCheckBox.Location = new System.Drawing.Point(0, 18);
            this.photoCheckBox.Name = "photoCheckBox";
            this.photoCheckBox.Size = new System.Drawing.Size(70, 24);
            this.photoCheckBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.photoCheckBox, "クリックしてメディアの添付と添付の解除を行います。右クリックするとオプションを表示します。");
            this.photoCheckBox.UseVisualStyleBackColor = true;
            this.photoCheckBox.Click += new System.EventHandler(this.PhotoCheckBox_Click);
            // 
            // mediaContextMenuStrip
            // 
            this.mediaContextMenuStrip.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mediaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromClipboardToolStripMenuItem});
            this.mediaContextMenuStrip.Name = "tabsContextMenuStrip";
            this.mediaContextMenuStrip.Size = new System.Drawing.Size(230, 26);
            // 
            // fromClipboardToolStripMenuItem
            // 
            this.fromClipboardToolStripMenuItem.Name = "fromClipboardToolStripMenuItem";
            this.fromClipboardToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.fromClipboardToolStripMenuItem.Text = "クリップボードの画像を添付(&L)...";
            this.fromClipboardToolStripMenuItem.Click += new System.EventHandler(this.FromClipboardToolStripMenuItem_Click);
            // 
            // tweetLengthLabel
            // 
            this.tweetLengthLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tweetLengthLabel.Location = new System.Drawing.Point(0, 0);
            this.tweetLengthLabel.Name = "tweetLengthLabel";
            this.tweetLengthLabel.Size = new System.Drawing.Size(70, 18);
            this.tweetLengthLabel.TabIndex = 1;
            this.tweetLengthLabel.Text = "140";
            this.tweetLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tweetLengthLabel.UseMnemonic = false;
            // 
            // sendButton
            // 
            this.sendButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sendButton.Location = new System.Drawing.Point(0, 45);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(70, 24);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "&Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.ShowDocumentIcon = true;
            this.dockPanel.Size = new System.Drawing.Size(784, 440);
            this.dockPanel.TabIndex = 0;
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ShowEffects = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ゆきうさぎ";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // accountsContextMenuStrip
            // 
            this.accountsContextMenuStrip.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.accountsContextMenuStrip.Name = "tabsContextMenuStrip";
            this.accountsContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 50);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.accountSelectPanel.ResumeLayout(false);
            this.tweetButtonsPanel.ResumeLayout(false);
            this.mediaContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox tweetTextBox;
        private System.Windows.Forms.Panel tweetButtonsPanel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.CheckBox photoCheckBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel replyInfoLinkLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label tweetLengthLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tweetPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip mediaContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fromClipboardToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.Panel accountSelectPanel;
        private System.Windows.Forms.Button accountsButton;
        private System.Windows.Forms.ContextMenuStrip accountsContextMenuStrip;
    }
}