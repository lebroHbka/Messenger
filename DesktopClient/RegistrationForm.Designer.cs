namespace DesktopClient
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LogInButton = new System.Windows.Forms.Button();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.HelpPanel2 = new System.Windows.Forms.Panel();
            this.PasswordPic = new System.Windows.Forms.PictureBox();
            this.HelpPanel1 = new System.Windows.Forms.Panel();
            this.LogginPic = new System.Windows.Forms.PictureBox();
            this.UserPassField = new System.Windows.Forms.RichTextBox();
            this.UserLoginField = new System.Windows.Forms.RichTextBox();
            this.ActiveTabStatus = new System.Windows.Forms.Panel();
            this.SignUpTab = new System.Windows.Forms.Button();
            this.LogInTab = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.FormHeader = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.LoginPanel.SuspendLayout();
            this.HelpPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPic)).BeginInit();
            this.HelpPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogginPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            this.FormHeader.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.LogInButton);
            this.LoginPanel.Controls.Add(this.RegistrationButton);
            this.LoginPanel.Controls.Add(this.HelpPanel2);
            this.LoginPanel.Controls.Add(this.HelpPanel1);
            this.LoginPanel.Controls.Add(this.UserPassField);
            this.LoginPanel.Controls.Add(this.UserLoginField);
            this.LoginPanel.Location = new System.Drawing.Point(100, 137);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(400, 230);
            this.LoginPanel.TabIndex = 4;
            // 
            // LogInButton
            // 
            this.LogInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.LogInButton.Enabled = false;
            this.LogInButton.FlatAppearance.BorderSize = 0;
            this.LogInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.LogInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.LogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 16F, System.Drawing.FontStyle.Bold);
            this.LogInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(61)))));
            this.LogInButton.Location = new System.Drawing.Point(90, 140);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(220, 40);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.TabStop = false;
            this.LogInButton.Text = "LogIn";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.AuthenticationLogInButton_Click);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.RegistrationButton.Enabled = false;
            this.RegistrationButton.FlatAppearance.BorderSize = 0;
            this.RegistrationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.RegistrationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(73)))));
            this.RegistrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegistrationButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 16F, System.Drawing.FontStyle.Bold);
            this.RegistrationButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(61)))));
            this.RegistrationButton.Location = new System.Drawing.Point(90, 140);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(220, 40);
            this.RegistrationButton.TabIndex = 3;
            this.RegistrationButton.Text = "Register";
            this.RegistrationButton.UseVisualStyleBackColor = false;
            this.RegistrationButton.Visible = false;
            this.RegistrationButton.Click += new System.EventHandler(this.SignInRegistrationButton_Click);
            // 
            // HelpPanel2
            // 
            this.HelpPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HelpPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.HelpPanel2.Controls.Add(this.PasswordPic);
            this.HelpPanel2.Location = new System.Drawing.Point(90, 70);
            this.HelpPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.HelpPanel2.Name = "HelpPanel2";
            this.HelpPanel2.Size = new System.Drawing.Size(40, 30);
            this.HelpPanel2.TabIndex = 2;
            // 
            // PasswordPic
            // 
            this.PasswordPic.Image = ((System.Drawing.Image)(resources.GetObject("PasswordPic.Image")));
            this.PasswordPic.Location = new System.Drawing.Point(4, 6);
            this.PasswordPic.Name = "PasswordPic";
            this.PasswordPic.Size = new System.Drawing.Size(20, 20);
            this.PasswordPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasswordPic.TabIndex = 3;
            this.PasswordPic.TabStop = false;
            // 
            // HelpPanel1
            // 
            this.HelpPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HelpPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.HelpPanel1.Controls.Add(this.LogginPic);
            this.HelpPanel1.Location = new System.Drawing.Point(90, 20);
            this.HelpPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.HelpPanel1.Name = "HelpPanel1";
            this.HelpPanel1.Size = new System.Drawing.Size(40, 30);
            this.HelpPanel1.TabIndex = 2;
            // 
            // LogginPic
            // 
            this.LogginPic.Image = ((System.Drawing.Image)(resources.GetObject("LogginPic.Image")));
            this.LogginPic.Location = new System.Drawing.Point(4, 6);
            this.LogginPic.Name = "LogginPic";
            this.LogginPic.Size = new System.Drawing.Size(20, 20);
            this.LogginPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogginPic.TabIndex = 3;
            this.LogginPic.TabStop = false;
            // 
            // UserPassField
            // 
            this.UserPassField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UserPassField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.UserPassField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserPassField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserPassField.DetectUrls = false;
            this.UserPassField.Font = new System.Drawing.Font("Microsoft YaHei Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPassField.ForeColor = System.Drawing.Color.White;
            this.UserPassField.Location = new System.Drawing.Point(130, 70);
            this.UserPassField.Margin = new System.Windows.Forms.Padding(0);
            this.UserPassField.MaxLength = 10;
            this.UserPassField.Multiline = false;
            this.UserPassField.Name = "UserPassField";
            this.UserPassField.Size = new System.Drawing.Size(180, 30);
            this.UserPassField.TabIndex = 1;
            this.UserPassField.Text = "";
            this.UserPassField.TextChanged += new System.EventHandler(this.UserInputData_TextChanged);
            // 
            // UserLoginField
            // 
            this.UserLoginField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UserLoginField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.UserLoginField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserLoginField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserLoginField.DetectUrls = false;
            this.UserLoginField.Font = new System.Drawing.Font("Microsoft YaHei Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLoginField.ForeColor = System.Drawing.Color.White;
            this.UserLoginField.Location = new System.Drawing.Point(130, 20);
            this.UserLoginField.Margin = new System.Windows.Forms.Padding(0);
            this.UserLoginField.MaxLength = 10;
            this.UserLoginField.Multiline = false;
            this.UserLoginField.Name = "UserLoginField";
            this.UserLoginField.Size = new System.Drawing.Size(180, 30);
            this.UserLoginField.TabIndex = 0;
            this.UserLoginField.Text = "";
            this.UserLoginField.TextChanged += new System.EventHandler(this.UserInputData_TextChanged);
            // 
            // ActiveTabStatus
            // 
            this.ActiveTabStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(204)))), ((int)(((byte)(253)))));
            this.ActiveTabStatus.Location = new System.Drawing.Point(125, 116);
            this.ActiveTabStatus.Name = "ActiveTabStatus";
            this.ActiveTabStatus.Size = new System.Drawing.Size(134, 5);
            this.ActiveTabStatus.TabIndex = 3;
            // 
            // SignUpTab
            // 
            this.SignUpTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.SignUpTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SignUpTab.CausesValidation = false;
            this.SignUpTab.FlatAppearance.BorderSize = 0;
            this.SignUpTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(67)))), ((int)(((byte)(84)))));
            this.SignUpTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SignUpTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUpTab.Font = new System.Drawing.Font("Microsoft YaHei Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignUpTab.ForeColor = System.Drawing.Color.Black;
            this.SignUpTab.Location = new System.Drawing.Point(345, 75);
            this.SignUpTab.Margin = new System.Windows.Forms.Padding(0);
            this.SignUpTab.Name = "SignUpTab";
            this.SignUpTab.Size = new System.Drawing.Size(134, 41);
            this.SignUpTab.TabIndex = 0;
            this.SignUpTab.TabStop = false;
            this.SignUpTab.Text = "SignUp";
            this.SignUpTab.UseVisualStyleBackColor = false;
            this.SignUpTab.Click += new System.EventHandler(this.AuthenticationSignUpTab_Click);
            // 
            // LogInTab
            // 
            this.LogInTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.LogInTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogInTab.CausesValidation = false;
            this.LogInTab.Enabled = false;
            this.LogInTab.FlatAppearance.BorderSize = 0;
            this.LogInTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(67)))), ((int)(((byte)(84)))));
            this.LogInTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LogInTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInTab.Font = new System.Drawing.Font("Microsoft YaHei Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogInTab.ForeColor = System.Drawing.Color.Black;
            this.LogInTab.Location = new System.Drawing.Point(125, 75);
            this.LogInTab.Margin = new System.Windows.Forms.Padding(0);
            this.LogInTab.Name = "LogInTab";
            this.LogInTab.Size = new System.Drawing.Size(134, 41);
            this.LogInTab.TabIndex = 0;
            this.LogInTab.TabStop = false;
            this.LogInTab.Text = "LogIn";
            this.LogInTab.UseMnemonic = false;
            this.LogInTab.UseVisualStyleBackColor = false;
            this.LogInTab.Click += new System.EventHandler(this.AuthenticationLogInTab_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(558, 10);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(30, 30);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitButton.TabIndex = 5;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            this.ExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // FormHeader
            // 
            this.FormHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FormHeader.BackColor = System.Drawing.Color.Transparent;
            this.FormHeader.Controls.Add(this.ExitButton);
            this.FormHeader.Location = new System.Drawing.Point(0, 0);
            this.FormHeader.Margin = new System.Windows.Forms.Padding(0);
            this.FormHeader.Name = "FormHeader";
            this.FormHeader.Size = new System.Drawing.Size(600, 50);
            this.FormHeader.TabIndex = 6;
            this.FormHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseDown);
            this.FormHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormHeader_MouseMove);
            // 
            // MainPanel
            // 
            this.MainPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.MainPanel.CausesValidation = false;
            this.MainPanel.Controls.Add(this.ActiveTabStatus);
            this.MainPanel.Controls.Add(this.LoginPanel);
            this.MainPanel.Controls.Add(this.SignUpTab);
            this.MainPanel.Controls.Add(this.LogInTab);
            this.MainPanel.Controls.Add(this.FormHeader);
            this.MainPanel.ForeColor = System.Drawing.Color.Black;
            this.MainPanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(600, 400);
            this.MainPanel.TabIndex = 3;
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.Transparent;
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusPanel.Location = new System.Drawing.Point(0, 0);
            this.StatusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(600, 400);
            this.StatusPanel.TabIndex = 40;
            this.StatusPanel.Visible = false;
            this.StatusPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AuthenticationStatusPanel_Paint);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.StatusPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(900, 500);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RegistrationForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AuthenticationStatusPanel_Paint);
            this.LoginPanel.ResumeLayout(false);
            this.HelpPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPic)).EndInit();
            this.HelpPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogginPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            this.FormHeader.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Panel HelpPanel2;
        private System.Windows.Forms.PictureBox PasswordPic;
        private System.Windows.Forms.Panel HelpPanel1;
        private System.Windows.Forms.PictureBox LogginPic;
        private System.Windows.Forms.RichTextBox UserPassField;
        private System.Windows.Forms.RichTextBox UserLoginField;
        private System.Windows.Forms.Panel ActiveTabStatus;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Button SignUpTab;
        private System.Windows.Forms.Button LogInTab;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.Panel FormHeader;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel StatusPanel;
    }
}