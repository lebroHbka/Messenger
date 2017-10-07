namespace DesktopClient
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
            this.sideBarMenu = new System.Windows.Forms.Panel();
            this.sideBarSettings = new System.Windows.Forms.PictureBox();
            this.sideBarFriends = new System.Windows.Forms.PictureBox();
            this.sideBarProfile = new System.Windows.Forms.PictureBox();
            this.ProfilePanel = new System.Windows.Forms.Panel();
            this.ProfilepanelLoginLabel = new System.Windows.Forms.Label();
            this.ProfilepanelAvatarPic = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.FormHeader = new System.Windows.Forms.Panel();
            this.ServerOfflinePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ChatFriendOfflinePanel = new System.Windows.Forms.Panel();
            this.ChatFriendOfflineLabel = new System.Windows.Forms.Label();
            this.HeaderExitButton = new System.Windows.Forms.PictureBox();
            this.SideBarCloseTimer = new System.Windows.Forms.Timer(this.components);
            this.FriendsPanel = new System.Windows.Forms.Panel();
            this.FriendsListPanel = new System.Windows.Forms.Panel();
            this.FriendsScroll = new System.Windows.Forms.Panel();
            this.AddFriendPanel = new System.Windows.Forms.Panel();
            this.AddFriendName = new System.Windows.Forms.RichTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.WelcomePanel = new System.Windows.Forms.Panel();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.ChatExitPanel = new System.Windows.Forms.Panel();
            this.ChatInputMessageText = new System.Windows.Forms.RichTextBox();
            this.ChatDecoratePanel2 = new System.Windows.Forms.Panel();
            this.ChatDecoratePanel1 = new System.Windows.Forms.Panel();
            this.ChatSendMessageButton = new System.Windows.Forms.Button();
            this.ChatFriendName = new System.Windows.Forms.Label();
            this.ChatFriendPic = new System.Windows.Forms.PictureBox();
            this.ChatMessagesPanel = new System.Windows.Forms.Panel();
            this.ChatScroll = new System.Windows.Forms.Panel();
            this.welcomePicture = new System.Windows.Forms.PictureBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.AddFriendStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.FriendOfflineTimer = new System.Windows.Forms.Timer(this.components);
            this.ServerOfflineNotificationTimer = new System.Windows.Forms.Timer(this.components);
            this.sideBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarProfile)).BeginInit();
            this.ProfilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilepanelAvatarPic)).BeginInit();
            this.FormHeader.SuspendLayout();
            this.ServerOfflinePanel.SuspendLayout();
            this.ChatFriendOfflinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderExitButton)).BeginInit();
            this.FriendsPanel.SuspendLayout();
            this.FriendsListPanel.SuspendLayout();
            this.AddFriendPanel.SuspendLayout();
            this.WelcomePanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatFriendPic)).BeginInit();
            this.ChatMessagesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // sideBarMenu
            // 
            this.sideBarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.sideBarMenu.Controls.Add(this.sideBarSettings);
            this.sideBarMenu.Controls.Add(this.sideBarFriends);
            this.sideBarMenu.Controls.Add(this.sideBarProfile);
            this.sideBarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarMenu.Location = new System.Drawing.Point(0, 0);
            this.sideBarMenu.Margin = new System.Windows.Forms.Padding(0);
            this.sideBarMenu.Name = "sideBarMenu";
            this.sideBarMenu.Size = new System.Drawing.Size(40, 450);
            this.sideBarMenu.TabIndex = 0;
            // 
            // sideBarSettings
            // 
            this.sideBarSettings.Image = global::DesktopClient.Properties.Resources.sideBarMenuSettings;
            this.sideBarSettings.Location = new System.Drawing.Point(2, 170);
            this.sideBarSettings.Name = "sideBarSettings";
            this.sideBarSettings.Size = new System.Drawing.Size(36, 36);
            this.sideBarSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sideBarSettings.TabIndex = 0;
            this.sideBarSettings.TabStop = false;
            this.sideBarSettings.MouseLeave += new System.EventHandler(this.SideBarSettings_MouseLeave);
            this.sideBarSettings.MouseHover += new System.EventHandler(this.SideBarSettings_MouseHover);
            // 
            // sideBarFriends
            // 
            this.sideBarFriends.Image = global::DesktopClient.Properties.Resources.sideBarMenuFriends;
            this.sideBarFriends.Location = new System.Drawing.Point(2, 110);
            this.sideBarFriends.Name = "sideBarFriends";
            this.sideBarFriends.Size = new System.Drawing.Size(36, 36);
            this.sideBarFriends.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sideBarFriends.TabIndex = 0;
            this.sideBarFriends.TabStop = false;
            this.sideBarFriends.Click += new System.EventHandler(this.SideBarFriends_Click);
            this.sideBarFriends.MouseLeave += new System.EventHandler(this.SideBarFriends_MouseLeave);
            this.sideBarFriends.MouseHover += new System.EventHandler(this.SideBarFriends_MouseHover);
            // 
            // sideBarProfile
            // 
            this.sideBarProfile.Image = global::DesktopClient.Properties.Resources.sideBarMenuProfile;
            this.sideBarProfile.Location = new System.Drawing.Point(2, 50);
            this.sideBarProfile.Name = "sideBarProfile";
            this.sideBarProfile.Size = new System.Drawing.Size(36, 36);
            this.sideBarProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sideBarProfile.TabIndex = 0;
            this.sideBarProfile.TabStop = false;
            this.sideBarProfile.Click += new System.EventHandler(this.SideBarProfile_Click);
            this.sideBarProfile.MouseLeave += new System.EventHandler(this.SideBarProfile_MouseLeave);
            this.sideBarProfile.MouseHover += new System.EventHandler(this.SideBarProfile_MouseHover);
            // 
            // ProfilePanel
            // 
            this.ProfilePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.ProfilePanel.Controls.Add(this.ProfilepanelLoginLabel);
            this.ProfilePanel.Controls.Add(this.ProfilepanelAvatarPic);
            this.ProfilePanel.Controls.Add(this.splitter1);
            this.ProfilePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProfilePanel.Location = new System.Drawing.Point(40, 0);
            this.ProfilePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProfilePanel.Name = "ProfilePanel";
            this.ProfilePanel.Size = new System.Drawing.Size(0, 450);
            this.ProfilePanel.TabIndex = 1;
            this.ProfilePanel.Visible = false;
            // 
            // ProfilepanelLoginLabel
            // 
            this.ProfilepanelLoginLabel.AutoSize = true;
            this.ProfilepanelLoginLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProfilepanelLoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(98)))), ((int)(((byte)(114)))));
            this.ProfilepanelLoginLabel.Location = new System.Drawing.Point(19, 13);
            this.ProfilepanelLoginLabel.Name = "ProfilepanelLoginLabel";
            this.ProfilepanelLoginLabel.Size = new System.Drawing.Size(122, 27);
            this.ProfilepanelLoginLabel.TabIndex = 3;
            this.ProfilepanelLoginLabel.Text = "Anonymous";
            this.ProfilepanelLoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfilepanelAvatarPic
            // 
            this.ProfilepanelAvatarPic.Image = global::DesktopClient.Properties.Resources.anonym;
            this.ProfilepanelAvatarPic.Location = new System.Drawing.Point(37, 50);
            this.ProfilepanelAvatarPic.Name = "ProfilepanelAvatarPic";
            this.ProfilepanelAvatarPic.Size = new System.Drawing.Size(80, 80);
            this.ProfilepanelAvatarPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilepanelAvatarPic.TabIndex = 1;
            this.ProfilepanelAvatarPic.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(61)))));
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.splitter1.Name = "splitter1";
            this.splitter1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitter1.Size = new System.Drawing.Size(2, 450);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // FormHeader
            // 
            this.FormHeader.Controls.Add(this.ServerOfflinePanel);
            this.FormHeader.Controls.Add(this.ChatFriendOfflinePanel);
            this.FormHeader.Controls.Add(this.HeaderExitButton);
            this.FormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormHeader.Location = new System.Drawing.Point(40, 0);
            this.FormHeader.Margin = new System.Windows.Forms.Padding(0);
            this.FormHeader.Name = "FormHeader";
            this.FormHeader.Size = new System.Drawing.Size(660, 40);
            this.FormHeader.TabIndex = 2;
            this.FormHeader.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseClick);
            this.FormHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseDown);
            this.FormHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseMove);
            // 
            // ServerOfflinePanel
            // 
            this.ServerOfflinePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerOfflinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.ServerOfflinePanel.Controls.Add(this.label1);
            this.ServerOfflinePanel.Location = new System.Drawing.Point(265, 0);
            this.ServerOfflinePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ServerOfflinePanel.Name = "ServerOfflinePanel";
            this.ServerOfflinePanel.Size = new System.Drawing.Size(130, 40);
            this.ServerOfflinePanel.TabIndex = 13;
            this.ServerOfflinePanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server is offline";
            // 
            // ChatFriendOfflinePanel
            // 
            this.ChatFriendOfflinePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatFriendOfflinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.ChatFriendOfflinePanel.Controls.Add(this.ChatFriendOfflineLabel);
            this.ChatFriendOfflinePanel.Location = new System.Drawing.Point(265, 0);
            this.ChatFriendOfflinePanel.Name = "ChatFriendOfflinePanel";
            this.ChatFriendOfflinePanel.Size = new System.Drawing.Size(130, 40);
            this.ChatFriendOfflinePanel.TabIndex = 11;
            this.ChatFriendOfflinePanel.Visible = false;
            // 
            // ChatFriendOfflineLabel
            // 
            this.ChatFriendOfflineLabel.AutoSize = true;
            this.ChatFriendOfflineLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatFriendOfflineLabel.Location = new System.Drawing.Point(22, 10);
            this.ChatFriendOfflineLabel.Name = "ChatFriendOfflineLabel";
            this.ChatFriendOfflineLabel.Size = new System.Drawing.Size(86, 20);
            this.ChatFriendOfflineLabel.TabIndex = 0;
            this.ChatFriendOfflineLabel.Text = "User offline";
            // 
            // HeaderExitButton
            // 
            this.HeaderExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderExitButton.Image = global::DesktopClient.Properties.Resources.ExitButton;
            this.HeaderExitButton.Location = new System.Drawing.Point(619, 5);
            this.HeaderExitButton.Name = "HeaderExitButton";
            this.HeaderExitButton.Size = new System.Drawing.Size(30, 30);
            this.HeaderExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HeaderExitButton.TabIndex = 0;
            this.HeaderExitButton.TabStop = false;
            this.HeaderExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.HeaderExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            this.HeaderExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // SideBarCloseTimer
            // 
            this.SideBarCloseTimer.Interval = 50;
            // 
            // FriendsPanel
            // 
            this.FriendsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.FriendsPanel.Controls.Add(this.FriendsListPanel);
            this.FriendsPanel.Controls.Add(this.AddFriendPanel);
            this.FriendsPanel.Controls.Add(this.splitter2);
            this.FriendsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FriendsPanel.Location = new System.Drawing.Point(40, 0);
            this.FriendsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FriendsPanel.Name = "FriendsPanel";
            this.FriendsPanel.Size = new System.Drawing.Size(0, 450);
            this.FriendsPanel.TabIndex = 4;
            this.FriendsPanel.Visible = false;
            // 
            // FriendsListPanel
            // 
            this.FriendsListPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.FriendsListPanel.Controls.Add(this.FriendsScroll);
            this.FriendsListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FriendsListPanel.Location = new System.Drawing.Point(2, 27);
            this.FriendsListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FriendsListPanel.Name = "FriendsListPanel";
            this.FriendsListPanel.Size = new System.Drawing.Size(0, 423);
            this.FriendsListPanel.TabIndex = 1;
            this.FriendsListPanel.Click += new System.EventHandler(this.FriendsListPanel_Click);
            // 
            // FriendsScroll
            // 
            this.FriendsScroll.BackColor = System.Drawing.Color.Transparent;
            this.FriendsScroll.Location = new System.Drawing.Point(160, 0);
            this.FriendsScroll.Margin = new System.Windows.Forms.Padding(0);
            this.FriendsScroll.Name = "FriendsScroll";
            this.FriendsScroll.Size = new System.Drawing.Size(8, 100);
            this.FriendsScroll.TabIndex = 0;
            this.FriendsScroll.Paint += new System.Windows.Forms.PaintEventHandler(this.Scroll_Paint);
            // 
            // AddFriendPanel
            // 
            this.AddFriendPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.AddFriendPanel.Controls.Add(this.AddFriendName);
            this.AddFriendPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddFriendPanel.Location = new System.Drawing.Point(2, 0);
            this.AddFriendPanel.Name = "AddFriendPanel";
            this.AddFriendPanel.Size = new System.Drawing.Size(0, 27);
            this.AddFriendPanel.TabIndex = 2;
            // 
            // AddFriendName
            // 
            this.AddFriendName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddFriendName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.AddFriendName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddFriendName.DetectUrls = false;
            this.AddFriendName.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFriendName.ForeColor = System.Drawing.Color.White;
            this.AddFriendName.Location = new System.Drawing.Point(-81, 0);
            this.AddFriendName.Margin = new System.Windows.Forms.Padding(0);
            this.AddFriendName.MaxLength = 10;
            this.AddFriendName.Multiline = false;
            this.AddFriendName.Name = "AddFriendName";
            this.AddFriendName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.AddFriendName.Size = new System.Drawing.Size(151, 27);
            this.AddFriendName.TabIndex = 1;
            this.AddFriendName.Text = "";
            this.AddFriendName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddFriendName_KeyDown);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(61)))));
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Margin = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.splitter2.Name = "splitter2";
            this.splitter2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitter2.Size = new System.Drawing.Size(2, 450);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // WelcomePanel
            // 
            this.WelcomePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WelcomePanel.Controls.Add(this.ChatPanel);
            this.WelcomePanel.Controls.Add(this.welcomePicture);
            this.WelcomePanel.Controls.Add(this.welcomeLabel);
            this.WelcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WelcomePanel.Location = new System.Drawing.Point(40, 40);
            this.WelcomePanel.Margin = new System.Windows.Forms.Padding(0);
            this.WelcomePanel.Name = "WelcomePanel";
            this.WelcomePanel.Size = new System.Drawing.Size(660, 410);
            this.WelcomePanel.TabIndex = 3;
            this.WelcomePanel.Click += new System.EventHandler(this.WelcomePanel_Click);
            // 
            // ChatPanel
            // 
            this.ChatPanel.Controls.Add(this.ChatExitPanel);
            this.ChatPanel.Controls.Add(this.ChatInputMessageText);
            this.ChatPanel.Controls.Add(this.ChatDecoratePanel2);
            this.ChatPanel.Controls.Add(this.ChatDecoratePanel1);
            this.ChatPanel.Controls.Add(this.ChatSendMessageButton);
            this.ChatPanel.Controls.Add(this.ChatFriendName);
            this.ChatPanel.Controls.Add(this.ChatFriendPic);
            this.ChatPanel.Controls.Add(this.ChatMessagesPanel);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatPanel.Location = new System.Drawing.Point(0, 0);
            this.ChatPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(660, 410);
            this.ChatPanel.TabIndex = 2;
            this.ChatPanel.Visible = false;
            // 
            // ChatExitPanel
            // 
            this.ChatExitPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChatExitPanel.Location = new System.Drawing.Point(206, 4);
            this.ChatExitPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ChatExitPanel.Name = "ChatExitPanel";
            this.ChatExitPanel.Size = new System.Drawing.Size(15, 15);
            this.ChatExitPanel.TabIndex = 10;
            this.ChatExitPanel.Click += new System.EventHandler(this.ChatExitPanel_Click);
            this.ChatExitPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatExitPanel_Paint);
            // 
            // ChatInputMessageText
            // 
            this.ChatInputMessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(56)))), ((int)(((byte)(68)))));
            this.ChatInputMessageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatInputMessageText.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatInputMessageText.Location = new System.Drawing.Point(32, 322);
            this.ChatInputMessageText.Margin = new System.Windows.Forms.Padding(0);
            this.ChatInputMessageText.Name = "ChatInputMessageText";
            this.ChatInputMessageText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ChatInputMessageText.Size = new System.Drawing.Size(515, 75);
            this.ChatInputMessageText.TabIndex = 5;
            this.ChatInputMessageText.TabStop = false;
            this.ChatInputMessageText.Text = "";
            // 
            // ChatDecoratePanel2
            // 
            this.ChatDecoratePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(56)))), ((int)(((byte)(68)))));
            this.ChatDecoratePanel2.Location = new System.Drawing.Point(21, 322);
            this.ChatDecoratePanel2.Margin = new System.Windows.Forms.Padding(0);
            this.ChatDecoratePanel2.Name = "ChatDecoratePanel2";
            this.ChatDecoratePanel2.Size = new System.Drawing.Size(11, 75);
            this.ChatDecoratePanel2.TabIndex = 8;
            // 
            // ChatDecoratePanel1
            // 
            this.ChatDecoratePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(74)))), ((int)(((byte)(94)))));
            this.ChatDecoratePanel1.Location = new System.Drawing.Point(21, 4);
            this.ChatDecoratePanel1.Name = "ChatDecoratePanel1";
            this.ChatDecoratePanel1.Size = new System.Drawing.Size(8, 50);
            this.ChatDecoratePanel1.TabIndex = 7;
            // 
            // ChatSendMessageButton
            // 
            this.ChatSendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChatSendMessageButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatSendMessageButton.Location = new System.Drawing.Point(565, 339);
            this.ChatSendMessageButton.Name = "ChatSendMessageButton";
            this.ChatSendMessageButton.Size = new System.Drawing.Size(75, 41);
            this.ChatSendMessageButton.TabIndex = 6;
            this.ChatSendMessageButton.Text = "Send";
            this.ChatSendMessageButton.UseVisualStyleBackColor = true;
            this.ChatSendMessageButton.Click += new System.EventHandler(this.ChatSendMessageButton_Click);
            // 
            // ChatFriendName
            // 
            this.ChatFriendName.AutoSize = true;
            this.ChatFriendName.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatFriendName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(98)))), ((int)(((byte)(114)))));
            this.ChatFriendName.Location = new System.Drawing.Point(81, 16);
            this.ChatFriendName.Name = "ChatFriendName";
            this.ChatFriendName.Size = new System.Drawing.Size(122, 27);
            this.ChatFriendName.TabIndex = 4;
            this.ChatFriendName.Text = "Anonymous";
            this.ChatFriendName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChatFriendPic
            // 
            this.ChatFriendPic.Image = global::DesktopClient.Properties.Resources.anonym;
            this.ChatFriendPic.Location = new System.Drawing.Point(35, 9);
            this.ChatFriendPic.Name = "ChatFriendPic";
            this.ChatFriendPic.Size = new System.Drawing.Size(40, 40);
            this.ChatFriendPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChatFriendPic.TabIndex = 1;
            this.ChatFriendPic.TabStop = false;
            // 
            // ChatMessagesPanel
            // 
            this.ChatMessagesPanel.Controls.Add(this.ChatScroll);
            this.ChatMessagesPanel.Location = new System.Drawing.Point(22, 67);
            this.ChatMessagesPanel.Name = "ChatMessagesPanel";
            this.ChatMessagesPanel.Size = new System.Drawing.Size(618, 238);
            this.ChatMessagesPanel.TabIndex = 0;
            // 
            // ChatScroll
            // 
            this.ChatScroll.Location = new System.Drawing.Point(610, 0);
            this.ChatScroll.Margin = new System.Windows.Forms.Padding(0);
            this.ChatScroll.Name = "ChatScroll";
            this.ChatScroll.Size = new System.Drawing.Size(8, 109);
            this.ChatScroll.TabIndex = 0;
            this.ChatScroll.Paint += new System.Windows.Forms.PaintEventHandler(this.Scroll_Paint);
            // 
            // welcomePicture
            // 
            this.welcomePicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcomePicture.Image = global::DesktopClient.Properties.Resources.Logo;
            this.welcomePicture.Location = new System.Drawing.Point(268, 119);
            this.welcomePicture.Name = "welcomePicture";
            this.welcomePicture.Size = new System.Drawing.Size(100, 100);
            this.welcomePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.welcomePicture.TabIndex = 1;
            this.welcomePicture.TabStop = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel.Location = new System.Drawing.Point(156, 222);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(347, 40);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to MoonChat";
            // 
            // AddFriendStatusTimer
            // 
            this.AddFriendStatusTimer.Tick += new System.EventHandler(this.AddFriendStatusTimer_Tick);
            // 
            // FriendOfflineTimer
            // 
            this.FriendOfflineTimer.Tick += new System.EventHandler(this.FriendOfflineTimer_Tick);
            // 
            // ServerOfflineNotificationTimer
            // 
            this.ServerOfflineNotificationTimer.Tick += new System.EventHandler(this.ServerOfflineNotificationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.WelcomePanel);
            this.Controls.Add(this.FormHeader);
            this.Controls.Add(this.FriendsPanel);
            this.Controls.Add(this.ProfilePanel);
            this.Controls.Add(this.sideBarMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoonChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sideBarMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sideBarSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarProfile)).EndInit();
            this.ProfilePanel.ResumeLayout(false);
            this.ProfilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilepanelAvatarPic)).EndInit();
            this.FormHeader.ResumeLayout(false);
            this.ServerOfflinePanel.ResumeLayout(false);
            this.ServerOfflinePanel.PerformLayout();
            this.ChatFriendOfflinePanel.ResumeLayout(false);
            this.ChatFriendOfflinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderExitButton)).EndInit();
            this.FriendsPanel.ResumeLayout(false);
            this.FriendsListPanel.ResumeLayout(false);
            this.AddFriendPanel.ResumeLayout(false);
            this.WelcomePanel.ResumeLayout(false);
            this.WelcomePanel.PerformLayout();
            this.ChatPanel.ResumeLayout(false);
            this.ChatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatFriendPic)).EndInit();
            this.ChatMessagesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.welcomePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideBarMenu;
        private System.Windows.Forms.Panel ProfilePanel;
        private System.Windows.Forms.Panel FormHeader;
        private System.Windows.Forms.PictureBox HeaderExitButton;
        private System.Windows.Forms.Timer SideBarCloseTimer;
        private System.Windows.Forms.PictureBox sideBarSettings;
        private System.Windows.Forms.PictureBox sideBarFriends;
        private System.Windows.Forms.PictureBox sideBarProfile;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox ProfilepanelAvatarPic;
        private System.Windows.Forms.Label ProfilepanelLoginLabel;
        private System.Windows.Forms.Panel FriendsPanel;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel WelcomePanel;
        private System.Windows.Forms.PictureBox welcomePicture;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel FriendsListPanel;
        private System.Windows.Forms.Panel FriendsScroll;
        private System.Windows.Forms.RichTextBox AddFriendName;
        private System.Windows.Forms.Panel AddFriendPanel;
        private System.Windows.Forms.Timer AddFriendStatusTimer;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Label ChatFriendName;
        private System.Windows.Forms.PictureBox ChatFriendPic;
        private System.Windows.Forms.Panel ChatMessagesPanel;
        private System.Windows.Forms.Button ChatSendMessageButton;
        private System.Windows.Forms.RichTextBox ChatInputMessageText;
        private System.Windows.Forms.Panel ChatScroll;
        private System.Windows.Forms.Panel ChatDecoratePanel1;
        private System.Windows.Forms.Panel ChatDecoratePanel2;
        private System.Windows.Forms.Panel ChatExitPanel;
        private System.Windows.Forms.Panel ChatFriendOfflinePanel;
        private System.Windows.Forms.Label ChatFriendOfflineLabel;
        private System.Windows.Forms.Timer FriendOfflineTimer;
        private System.Windows.Forms.Panel ServerOfflinePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer ServerOfflineNotificationTimer;
    }
}

