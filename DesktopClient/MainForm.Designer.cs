namespace Client
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
            this.ProfilePanelSignUpButton = new System.Windows.Forms.Button();
            this.ProfilePanelLogInButton = new System.Windows.Forms.Button();
            this.ProfilepanelAvatarPic = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.FormHeader = new System.Windows.Forms.Panel();
            this.HeaderExitButton = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.FriendsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.welcomePicture = new System.Windows.Forms.PictureBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.sideBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarProfile)).BeginInit();
            this.ProfilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilepanelAvatarPic)).BeginInit();
            this.FormHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderExitButton)).BeginInit();
            this.FriendsPanel.SuspendLayout();
            this.welcomePanel.SuspendLayout();
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
            this.sideBarMenu.Size = new System.Drawing.Size(40, 400);
            this.sideBarMenu.TabIndex = 0;
            // 
            // sideBarSettings
            // 
            this.sideBarSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sideBarSettings.Image = global::Client.Properties.Resources.sideBarMenuSettings;
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
            this.sideBarFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sideBarFriends.Image = global::Client.Properties.Resources.sideBarMenuFriends;
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
            this.sideBarProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sideBarProfile.Image = global::Client.Properties.Resources.sideBarMenuProfile;
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
            this.ProfilePanel.Controls.Add(this.ProfilePanelSignUpButton);
            this.ProfilePanel.Controls.Add(this.ProfilePanelLogInButton);
            this.ProfilePanel.Controls.Add(this.ProfilepanelAvatarPic);
            this.ProfilePanel.Controls.Add(this.splitter1);
            this.ProfilePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProfilePanel.Location = new System.Drawing.Point(40, 0);
            this.ProfilePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProfilePanel.Name = "ProfilePanel";
            this.ProfilePanel.Size = new System.Drawing.Size(161, 400);
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
            // ProfilePanelSignUpButton
            // 
            this.ProfilePanelSignUpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(204)))), ((int)(((byte)(253)))));
            this.ProfilePanelSignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfilePanelSignUpButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProfilePanelSignUpButton.Location = new System.Drawing.Point(30, 269);
            this.ProfilePanelSignUpButton.Name = "ProfilePanelSignUpButton";
            this.ProfilePanelSignUpButton.Size = new System.Drawing.Size(100, 40);
            this.ProfilePanelSignUpButton.TabIndex = 2;
            this.ProfilePanelSignUpButton.Text = "SignUp";
            this.ProfilePanelSignUpButton.UseVisualStyleBackColor = true;
            this.ProfilePanelSignUpButton.Click += new System.EventHandler(this.ProfilePanelSignUpButton_Click);
            // 
            // ProfilePanelLogInButton
            // 
            this.ProfilePanelLogInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(204)))), ((int)(((byte)(253)))));
            this.ProfilePanelLogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfilePanelLogInButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProfilePanelLogInButton.Location = new System.Drawing.Point(30, 200);
            this.ProfilePanelLogInButton.Name = "ProfilePanelLogInButton";
            this.ProfilePanelLogInButton.Size = new System.Drawing.Size(100, 40);
            this.ProfilePanelLogInButton.TabIndex = 2;
            this.ProfilePanelLogInButton.Text = "LogIn";
            this.ProfilePanelLogInButton.UseVisualStyleBackColor = true;
            this.ProfilePanelLogInButton.Click += new System.EventHandler(this.ProfilePanelLogInButton_Click);
            // 
            // ProfilepanelAvatarPic
            // 
            this.ProfilepanelAvatarPic.Image = global::Client.Properties.Resources.anonym;
            this.ProfilepanelAvatarPic.Location = new System.Drawing.Point(40, 50);
            this.ProfilepanelAvatarPic.Name = "ProfilepanelAvatarPic";
            this.ProfilepanelAvatarPic.Size = new System.Drawing.Size(80, 80);
            this.ProfilepanelAvatarPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilepanelAvatarPic.TabIndex = 1;
            this.ProfilepanelAvatarPic.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(61)))));
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.splitter1.Name = "splitter1";
            this.splitter1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitter1.Size = new System.Drawing.Size(2, 400);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // FormHeader
            // 
            this.FormHeader.Controls.Add(this.HeaderExitButton);
            this.FormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormHeader.Location = new System.Drawing.Point(203, 0);
            this.FormHeader.Margin = new System.Windows.Forms.Padding(0);
            this.FormHeader.Name = "FormHeader";
            this.FormHeader.Size = new System.Drawing.Size(397, 50);
            this.FormHeader.TabIndex = 2;
            this.FormHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseDown);
            this.FormHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseMove);
            // 
            // HeaderExitButton
            // 
            this.HeaderExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HeaderExitButton.Image = global::Client.Properties.Resources.ExitButton;
            this.HeaderExitButton.Location = new System.Drawing.Point(355, 10);
            this.HeaderExitButton.Name = "HeaderExitButton";
            this.HeaderExitButton.Size = new System.Drawing.Size(30, 30);
            this.HeaderExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HeaderExitButton.TabIndex = 0;
            this.HeaderExitButton.TabStop = false;
            this.HeaderExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.HeaderExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            this.HeaderExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // Timer
            // 
            this.Timer.Interval = 50;
            // 
            // FriendsPanel
            // 
            this.FriendsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.FriendsPanel.Controls.Add(this.label2);
            this.FriendsPanel.Controls.Add(this.splitter2);
            this.FriendsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FriendsPanel.Location = new System.Drawing.Point(201, 0);
            this.FriendsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FriendsPanel.Name = "FriendsPanel";
            this.FriendsPanel.Size = new System.Drawing.Size(2, 400);
            this.FriendsPanel.TabIndex = 4;
            this.FriendsPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "        LogIn\r\nto see friends list";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(61)))));
            this.splitter2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Margin = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.splitter2.Name = "splitter2";
            this.splitter2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitter2.Size = new System.Drawing.Size(2, 400);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // welcomePanel
            // 
            this.welcomePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.welcomePanel.Controls.Add(this.welcomePicture);
            this.welcomePanel.Controls.Add(this.welcomeLabel);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(203, 50);
            this.welcomePanel.Margin = new System.Windows.Forms.Padding(0);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(397, 350);
            this.welcomePanel.TabIndex = 3;
            // 
            // welcomePicture
            // 
            this.welcomePicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcomePicture.Image = global::Client.Properties.Resources.Logo;
            this.welcomePicture.Location = new System.Drawing.Point(134, 90);
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
            this.welcomeLabel.Location = new System.Drawing.Point(22, 193);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(347, 40);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to MoonChat";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.welcomePanel);
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
            this.sideBarMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sideBarSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideBarProfile)).EndInit();
            this.ProfilePanel.ResumeLayout(false);
            this.ProfilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilepanelAvatarPic)).EndInit();
            this.FormHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderExitButton)).EndInit();
            this.FriendsPanel.ResumeLayout(false);
            this.FriendsPanel.PerformLayout();
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideBarMenu;
        private System.Windows.Forms.Panel ProfilePanel;
        private System.Windows.Forms.Panel FormHeader;
        private System.Windows.Forms.PictureBox HeaderExitButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox sideBarSettings;
        private System.Windows.Forms.PictureBox sideBarFriends;
        private System.Windows.Forms.PictureBox sideBarProfile;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button ProfilePanelLogInButton;
        private System.Windows.Forms.PictureBox ProfilepanelAvatarPic;
        private System.Windows.Forms.Button ProfilePanelSignUpButton;
        private System.Windows.Forms.Label ProfilepanelLoginLabel;
        private System.Windows.Forms.Panel FriendsPanel;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.PictureBox welcomePicture;
        private System.Windows.Forms.Label welcomeLabel;
    }
}

