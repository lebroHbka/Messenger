﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Windows.Threading;
using Microsoft.AspNet.SignalR.Client;
using System.Media;

namespace DesktopClient
{
    public partial class MainForm : Form
    {
        #region Enums

        enum UserStatus
        {
            Default = 0,
            Anonymous = 1,
            Logined = 2
        }

        public enum ConnectStatus
        {
            Ok = 1,
            Fail = 2,
            ServiceNotAvailable = 3
        }

        #endregion

        #region Support classes

        // custom class for enabling doubleclick event
        class ButtonWithDoubleClick : Button
        {
            public ButtonWithDoubleClick()
            {
                SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            }
        }

        class ChatMessagePanel : Panel
        {
            public void ShiftX(int shift)
            {
                this.Left += shift;
            }
        }

        #endregion

        #region Vars

        #region Consts

        const string userAddedSuccess = "User added";
        const string userAddedFail = "No such user";
        const string userAddedYourSelf = "Can't add yourself";
        const string userAddedFriendExists = "User already exists";

        const int userAddFriendNotifDelay = 1500;
        const int friendOfflineNotifDelay = 1000;
        const int serverOfflineNotidDelay = 1000;

        const int menuNormalWidth = 170;
        const int menuToggleSpeed = 50;

        const int messagePanelMaxWidth = 250;

        #endregion

        #region User info

        string userLogin;
        string userPassword;
        string userToken;

        UserStatus userStatus = UserStatus.Default;
        List<string> userFriends = new List<string>();
        List<MessageFormat> userNewMessages = new List<MessageFormat>();

        HashSet<string> userFriendsTheirMsgNotReaded;

        SoundPlayer addFriendSound;

        #endregion

        #region Colors

        Color activeSideBarButtonColor = Color.FromArgb(20, 23, 28);
        Color transparentColor = Color.Transparent;

        Color FriendPanelHoveredColor = Color.FromArgb(255, 38, 51, 62);
        Color FriendPanelNotHoveredColor = Color.Transparent;

        Color ScrollColor = Color.FromArgb(255, 22, 25, 30);


        Color userAddedSuccessColor = Color.FromArgb(255, 9, 79, 13);
        Color userAddedFailColor = Color.FromArgb(255, 79, 9, 9);


        Color profilePanelButtonPressColor = Color.FromArgb(255, 152, 204, 253);

        Color chatOutcomingMessagesBackColor = Color.FromArgb(255, 49, 74, 94);
        Color chatIncomingMessagesBackColor = Color.FromArgb(255, 25, 49, 68);

        Color chatExitPanelColor = Color.FromArgb(25, 32, 38);

        Color newMessageNotificationColor = Color.FromArgb(255, 244, 197, 66);

        #endregion

        #region Scrolls

        CustomScrollBar friendScroll;

        CustomScrollBar chatScroll;

        #endregion

        #region Hub

        HubConnection hub;
        IHubProxy hubProxy;

        #endregion 

        Point windowPosition;

        Dictionary<PictureBox, Panel> activeSideBar = new Dictionary<PictureBox, Panel>();

        Dictionary<UserStatus, string> statuses = new Dictionary<UserStatus, string>
        {
            { UserStatus.Anonymous, "Anonymous"},
        };


        int chatPanelCurrentWidth;

        event Action<int> moveIncomingMessages;

        #endregion

        
        public MainForm()
        {
            InitializeComponent();
            
            
            ControlsSettings();
            StartUserSettings();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            ChatPanel.Resize += ChatResize;

            chatPanelCurrentWidth = ChatPanel.Width;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromHub();
            SaveUserMessages();
            SaveFriendsWithNotReadedMsg();
        }

        private void ControlsSettings()
        {
            ProfilePanel.Width = 0;
            ProfilePanel.Visible = false;

            FriendsPanel.Width = 0;
            FriendsPanel.Visible = false;

            // profile panel
            ProfilepanelAvatarPic.Left = (menuNormalWidth - ProfilepanelAvatarPic.Width) / 2;

            // scrolls
            friendScroll = new CustomScrollBar(FriendsListPanel, FriendsScroll, 3);
            chatScroll = new CustomScrollBar(ChatMessagesPanel, ChatScroll, 10);

            addFriendSound = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + @"Resources\addFriendSound.wav");
            
            LoadFriendsWithNotReadedMsg();
        }


        #region Exit button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DisconnectFromHub();
            Application.Exit();
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            HeaderExitButton.ImageLocation = @"Resources\ExitButtonHovered.png";
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            HeaderExitButton.ImageLocation = @"Resources\ExitButton.png";
        }

        #endregion

        #region Form header

        private void FormHeader_MouseDown(object sender, MouseEventArgs e)
        {
            windowPosition = e.Location;
        }

        private void FormHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - windowPosition.X;
                this.Top += e.Y - windowPosition.Y;
            }
        }

        private void FormHeader_MouseClick(object sender, MouseEventArgs e)
        {
            FormHeader.Focus();
        }

        #endregion

        #region WelcomePanel

        private void WelcomePanel_Click(object sender, EventArgs e)
        {
            WelcomePanel.Focus();
        }

        #endregion

        #region Side bar methods

        private void Close(Panel p)
        {
            SideBarCloseTimer.Tick += (object s, EventArgs el) =>
            {
                p.Width -= menuToggleSpeed;
                if (p.Width <= 0)
                {
                    SideBarCloseTimer.Stop();
                    SideBarCloseTimer = new Timer();
                    p.Width = 0;
                    p.Visible = false;
                    Refresh();
                }
            };
            SideBarCloseTimer.Start();
        }

        private void Open(Panel p)
        {
            SideBarCloseTimer.Tick += (object s, EventArgs el) =>
            {
                p.Width += menuToggleSpeed;
                if (p.Width >= menuNormalWidth)
                {
                    SideBarCloseTimer.Stop();
                    SideBarCloseTimer = new Timer();
                    p.Width = menuNormalWidth;
                    Refresh();
                }
            };

            p.Visible = true;
            SideBarCloseTimer.Start();
        }

        private void ToggleSideBarMenuButton(PictureBox button, Panel p)
        {
            if (p.Visible)
            {
                Close(p);
                button.BackColor = transparentColor;
                activeSideBar.Clear();
            }
            else
            {
                if (activeSideBar.Count > 0)
                {
                    // close opened panel
                    var actSideBar = activeSideBar.First();
                    actSideBar.Key.BackColor = transparentColor;
                    actSideBar.Value.Width = 0;
                    actSideBar.Value.Visible = false;

                    activeSideBar.Clear();

                    // fast open new panel
                    p.Visible = true;
                    p.Width = menuNormalWidth;
                }
                else
                {
                    // slow open new panel
                    Open(p);
                }

                button.BackColor = activeSideBarButtonColor;
                activeSideBar[button] = p;
            }
        }

        private void SideBarSettings_MouseHover(object sender, EventArgs e)
        {
            sideBarSettings.BackColor = Color.FromArgb(20, 23, 28);
        }

        private void SideBarSettings_MouseLeave(object sender, EventArgs e)
        {
            sideBarSettings.BackColor = Color.FromArgb(30, 34, 41);
        }

        #endregion

        #region Side bar profile

        private void SideBarProfile_MouseHover(object sender, EventArgs e)
        {
            sideBarProfile.BackColor = activeSideBarButtonColor;
        }

        private void SideBarProfile_MouseLeave(object sender, EventArgs e)
        {
            if(!ProfilePanel.Visible)
                sideBarProfile.BackColor = transparentColor;
        }

        private void SideBarProfile_Click(object sender, EventArgs e)
        {
            ToggleSideBarMenuButton(sideBarProfile, ProfilePanel);
            
        }
        
        private void ProfilePanelStatusUnlogin()
        {
            ProfilePanel.Controls.Find("ProfilePanelLogOutButton", false).FirstOrDefault()?.Dispose();
            Generate_LogInButton();
            Generate_SignUpButton();

            ProfilepanelLoginLabel.Text = statuses[UserStatus.Anonymous];
            ProfilepanelLoginLabel.Left = (menuNormalWidth - ProfilepanelLoginLabel.Width) / 2;

            ProfilePanel.Refresh();
        }

        private void ProfilePanelStatusLogined()
        {
            ProfilePanel.Controls.Find("ProfilePanelLogInButton", false).FirstOrDefault()?.Dispose();
            ProfilePanel.Controls.Find("ProfilePanelSignUpButton", false).FirstOrDefault()?.Dispose();
            Generate_LogOutButton();

            ProfilepanelLoginLabel.Text = userLogin;
            ProfilepanelLoginLabel.Left = (menuNormalWidth - ProfilepanelLoginLabel.Width) / 2;

            ProfilePanel.Refresh();
        }

        #endregion

        #region Side bar friends

        private void SideBarFriends_MouseHover(object sender, EventArgs e)
        {
            sideBarFriends.BackColor = activeSideBarButtonColor;
        }

        private void SideBarFriends_MouseLeave(object sender, EventArgs e)
        {
            if (!FriendsPanel.Visible)
                sideBarFriends.BackColor = transparentColor;
        }

        private void SideBarFriends_Click(object sender, EventArgs e)
        {
            ToggleSideBarMenuButton(sideBarFriends, FriendsPanel);
        }

        private void FriendsPanelStatusUnlogin()
        {
            FriendsListPanel.Visible = false;
            AddFriendPanel.Visible = false;
            Generate_LoginToSeeFriendsLabel();
            FriendsListClear();
            AddFriendName.Text = "";
        }

        private void FriendsPanelStatusLogined()
        {
            FriendsPanel.Controls.Find("LogInToSeeFriendsLabel", false).FirstOrDefault()?.Dispose();
            FriendsListPanel.Visible = true;
            AddFriendPanel.Visible = true;
            FriendsListAddFriendsPanel();
        }

        private async void AddFriendName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if(AddFriendName.Text.Length > 0)
                {
                    //stop previos timer if some active
                    AddFriendStatusTimer_Tick(sender, e);
                    AddFriendStatusTimer.Interval = userAddFriendNotifDelay;

                    var friendName = AddFriendName.Text;
                    if (friendName == userLogin)
                    {
                        AddFriendStatusTimer.Start();
                        Generate_AddFriendStatus(userAddedFailColor, userAddedYourSelf);
                    }
                    else if (userFriends.Contains(friendName))
                    {
                        AddFriendStatusTimer.Start();
                        Generate_AddFriendStatus(userAddedFailColor, userAddedFriendExists);
                    }
                    else 
                    {
                        var status = await AddFriend(friendName);
                        if(status == ConnectStatus.Ok)
                        {
                            FriendsListClear();

                            AddFriendStatusTimer.Start();
                            Generate_AddFriendStatus(userAddedSuccessColor, userAddedSuccess);

                            FriendsListAddFriendsPanel();
                        }
                        else if (status == ConnectStatus.ServiceNotAvailable)
                        {
                            ServiceOfflineNotification();
                        }
                        else
                        {
                            AddFriendStatusTimer.Start();
                            Generate_AddFriendStatus(userAddedFailColor, userAddedFail);
                        }
                    }
                }
                FriendsScroll.Invalidate();
                AddFriendName.Text = "";
            }
        }

        private void AddFriendStatusTimer_Tick(object sender, EventArgs e)
        {
            FriendsListPanel.Controls.Find("AddFriendStatusPanel", false).FirstOrDefault()?.Dispose();
            FriendsScroll.Invalidate();
            AddFriendStatusTimer.Stop();
        }

        private void FriendsListPanel_Click(object sender, EventArgs e)
        {
            FriendsListPanel.Focus();
        }

        #endregion

        #region Generate Controls


        #region Profile 
        private void Generate_LogOutButton()
        {
            var but = new Button();
            but.FlatAppearance.MouseDownBackColor = profilePanelButtonPressColor;
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Size = new Size(100, 40);
            but.Font = new Font("Microsoft YaHei UI Light", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point((menuNormalWidth - but.Width) / 2, 200);
            but.Name = "ProfilePanelLogOutButton";
            but.TabIndex = 2;
            but.Text = "LogOut";
            but.UseVisualStyleBackColor = true;
            but.Click += (object sender, EventArgs e) =>
            {
                UpdateUserInfo(statuses[UserStatus.Anonymous], "");
                SaveUserInfo();
                UserNotLogined();
            };

            ProfilePanel.Controls.Add(but);
        }

        private void Generate_SignUpButton()
        {
            var but = new Button();
            but.FlatAppearance.MouseDownBackColor = profilePanelButtonPressColor;
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Size = new Size(100, 40);
            but.Font = new Font("Microsoft YaHei UI Light", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point((menuNormalWidth - but.Width) / 2, 269);
            but.Name = "ProfilePanelSignUpButton";
            but.TabIndex = 2;
            but.Text = "SignUp";
            but.UseVisualStyleBackColor = true;
            but.Click += (object sender, EventArgs e) => 
            {
                var regForm = new RegistrationForm();
                regForm.ActivateSignUpTab();
                regForm.Location = this.Location;
                regForm.MainForm = this;
                regForm.Show();
                ToggleSideBarMenuButton(sideBarProfile, ProfilePanel);
            };

            ProfilePanel.Controls.Add(but);
        }

        private void Generate_LogInButton()
        {
            var but = new Button();
            but.FlatAppearance.MouseDownBackColor = profilePanelButtonPressColor;
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Size = new Size(100, 40);
            but.Font = new Font("Microsoft YaHei UI Light", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point((menuNormalWidth - but.Width) / 2, 200);
            but.Name = "ProfilePanelLogInButton";
            but.TabIndex = 2;
            but.Text = "LogIn";
            but.UseVisualStyleBackColor = true;
            but.Click += (object sender, EventArgs e) => 
            {
                var regForm = new RegistrationForm();
                regForm.ActivateLogInTab();
                regForm.Location = this.Location;
                regForm.MainForm = this;
                regForm.Show();
                ToggleSideBarMenuButton(sideBarProfile, ProfilePanel);
            };

            ProfilePanel.Controls.Add(but);
        }
        #endregion

        #region Friends
        private void Generate_LoginToSeeFriendsLabel()
        {
            var l = new Label();
            l.Font = new Font("Microsoft YaHei Light", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            l.Size = new Size(156, 50);
            l.Location = new Point((menuNormalWidth - l.Width) / 2, 147);
            l.Name = "LogInToSeeFriendsLabel";
            l.Text = "        LogIn\r\nto see friends list";

            FriendsPanel.Controls.Add(l);
        }
        
        private void Generate_AddFriendStatus(Color color, string text)
        {
            var p = new Panel();
            var l = new Label();

            p.Controls.Add(l);
            FriendsListPanel.Controls.Add(p);
            p.BringToFront();

            p.BackColor = color;
            p.Location = new Point(0, 0);
            p.Margin = new Padding(0);
            p.Name = "AddFriendStatusPanel";
            p.Size = new Size(menuNormalWidth, 32);

            l.AutoSize = true;
            l.Font = new Font("Microsoft YaHei Light", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            l.Name = "AddFriendStatusLabel";
            l.Size = new Size(112, 25);
            l.Text = text;
            l.Location = new Point((p.Width - l.Width) / 2, 3);
        }

        private Panel Generate_FriendPanel(string name)
        {
            var p = new Panel();
            var but = new ButtonWithDoubleClick();
            var picBox = new PictureBox();
            var statPanel = new Panel();

            p.SuspendLayout();
            but.SuspendLayout();
            picBox.SuspendLayout();
            statPanel.SuspendLayout();

            // custom panel
            p.Name = $"{name}_friendPanel";
            p.Controls.Add(picBox);
            p.Controls.Add(but);
            p.Size = new Size(menuNormalWidth, 50);
            p.TabStop = false;

            // custom pic
            picBox.Image = Properties.Resources.anonym;
            picBox.Location = new Point(3, 0);
            picBox.Size = new Size(50, 50);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // custom button
            but.Controls.Add(statPanel);
            but.Name = $"{name}_friendButtonn";
            but.FlatAppearance.BorderSize = 0;
            but.FlatAppearance.MouseDownBackColor = Color.Transparent;
            but.FlatAppearance.MouseOverBackColor = Color.Transparent;
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point(56, 0);
            but.Margin = new Padding(0);
            but.Size = new Size(114, 50);
            but.Text = name;
            but.UseVisualStyleBackColor = true;
            but.MouseLeave += (object sender, EventArgs e) => { but.Parent.BackColor = FriendPanelNotHoveredColor; };
            but.MouseHover += (object sender, EventArgs e) => { but.Parent.BackColor = FriendPanelHoveredColor; };
            but.DoubleClick += (object sender, EventArgs e) =>
            {
                ChatOpen(but.Text);
            };

            // new message status panel
            statPanel.Name = $"{name}_newMessageStatus";
            statPanel.Width = 5;
            statPanel.Dock = DockStyle.Right;
            statPanel.Margin = new Padding(0,0,0,0);
            statPanel.BackColor = newMessageNotificationColor;
            statPanel.Visible = false;

            statPanel.ResumeLayout();
            picBox.ResumeLayout();
            but.ResumeLayout();
            p.ResumeLayout();

            return p;
        }
        #endregion

        #region Chat

        private ChatMessagePanel Generate_ChatMessageTemplate(string text, Color color)
        {
            var p = new ChatMessagePanel();
            var rich = new RichTextBox();

            p.SuspendLayout();
            rich.SuspendLayout();

            p.Controls.Add(rich);

            rich.BorderStyle = BorderStyle.None;
            rich.Font = new Font("Microsoft YaHei UI Light", 13F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            rich.ForeColor = Color.Black;
            rich.BackColor = color;
            rich.Text = text;
            rich.CausesValidation = false;
            rich.Cursor = Cursors.Arrow;
            rich.ScrollBars = RichTextBoxScrollBars.None;
            rich.ShortcutsEnabled = false;
            rich.WordWrap = true;
            rich.TabStop = false;
            rich.Margin = new Padding(0, 0, 0, 0);
            
            rich.Left = 10;
            rich.Top = 4;
            rich.Enter += (object sender, EventArgs e) =>
            {
                rich.Parent.Focus();
            };

            using (Graphics g = CreateGraphics())
            {
                rich.Height = (int)g.MeasureString(rich.Text, rich.Font, messagePanelMaxWidth).Height;
                rich.Width = (int)g.MeasureString(rich.Text, rich.Font, messagePanelMaxWidth).Width;
            }

            // panel
            p.BackColor = Color.Transparent;
            p.Size = new Size(rich.Width + 20, rich.Height + 8);
            p.Margin = new Padding(0, 0, 0, 0);

            rich.ResumeLayout();
            p.ResumeLayout();

            return p;
        }

        private Panel Generate_ChatOutcomingMessagesPanel(string text)
        {
            var panel = Generate_ChatMessageTemplate(text, chatOutcomingMessagesBackColor);
            panel.Paint += ChatOutcomingMessagesPanel_Paint;

            return panel;
        }

        private Panel Generate_ChatIncomingMessagesPanel(string text)
        {
            var panel = Generate_ChatMessageTemplate(text, chatIncomingMessagesBackColor);
            panel.Paint += ChatIncomingMessagesPanel_Paint;
            moveIncomingMessages += panel.ShiftX;

            return panel;
        }

        private void ChatOutcomingMessagesPanel_Paint(object sender, PaintEventArgs e)
        {

            var panel = sender as Panel;
            
            using (Graphics v = e.Graphics)
            {
                using (var pen = new Pen(chatOutcomingMessagesBackColor))
                {
                    DrawRoundRect(v, pen, panel.ClientRectangle.Left, panel.ClientRectangle.Top, panel.ClientRectangle.Width - 1, panel.ClientRectangle.Height - 1, 10);
                }
            }

            base.OnPaint(e);
        }

        private void ChatIncomingMessagesPanel_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            panel.SuspendLayout();

            using (Graphics v = e.Graphics)
            {
                using (var pen = new Pen(chatIncomingMessagesBackColor))
                {
                    DrawRoundRect(v, pen, panel.ClientRectangle.Left, panel.ClientRectangle.Top, panel.ClientRectangle.Width - 1, panel.ClientRectangle.Height - 1, 10);
                }
            }

            panel.ResumeLayout();
            base.OnPaint(e);
        }


        #endregion


        #endregion

        #region User methods

        private async void UserLogined(string login, string password)
        {
            ChatSendMessageButton.Enabled = false;

            UpdateUserInfo(login, password);
            SaveUserInfo();
            Messages.CreateUserTable(userLogin);

            ProfilePanelStatusLogined();

            await GetFriends(userLogin, userPassword);
            FriendsPanelStatusLogined();

            userStatus = UserStatus.Logined;
            await ConnectToHub();
            ChatSendMessageButton.Enabled = true;
        }

        private void UserNotLogined()
        {
            UpdateUserInfo(statuses[UserStatus.Anonymous], "");
            SaveUserInfo();

            ProfilePanelStatusUnlogin();
            FriendsPanelStatusUnlogin();

            ChatPanel.Visible = false;

            userStatus = UserStatus.Anonymous;
            DisconnectFromHub();
        }

        private void UpdateUserInfo(string name, string pass)
        {
            userLogin = name;
            userPassword = pass;
        }

        private void SaveUserInfo()
        {
            Properties.Settings.Default.Login = userLogin;
            Properties.Settings.Default.Password = userPassword;
            Properties.Settings.Default.Save();
        }

        private void LoadUserInfo()
        {
            userLogin = Properties.Settings.Default.Login;
            userPassword = Properties.Settings.Default.Password;
        }

        private async void StartUserSettings()
        {
            LoadUserInfo();
            if(userLogin != statuses[UserStatus.Anonymous])
            {
                if(await LogInUser(userLogin, userPassword) == ConnectStatus.ServiceNotAvailable)
                {
                    ServiceOfflineNotification();
                    UserNotLogined();
                }
            }
            else
            {
                UserNotLogined();
            }
        }

        #endregion

        #region Connect with service

        public async Task<ConnectStatus> LogInUser(string login, string password)
        {
            string result;
            var url = Properties.Settings.Default.userServiceUrl + Properties.Settings.Default.loginPath;

            using (WebClient webClient = new WebClient())
            {
                var uri = new Uri(url);
                AddAuthorizationHeader(webClient, login, password);
                try
                {
                    result = await webClient.DownloadStringTaskAsync(uri);
                }
                catch(WebException e)
                {
                    UserNotLogined();
                    if ((e.Status == WebExceptionStatus.ProtocolError) && (e.Response != null))
                    {
                        if(((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.Unauthorized)
                        {
                            return ConnectStatus.Fail;
                        }
                    }
                    return ConnectStatus.ServiceNotAvailable;
                }
            }
            userToken = JsonConvert.DeserializeObject<TokenService.Token>(result).Key;
            UserLogined(login, password);
            return ConnectStatus.Ok;
        }

        public async Task<ConnectStatus> RegisterUser(string login, string password)
        {
            string result;
            var loginUrl = Properties.Settings.Default.userServiceUrl + Properties.Settings.Default.signuPath;

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                try
                {
                    var uss = new TokenService.User() { Login = login, Password = password };
                    result = await webClient.UploadStringTaskAsync(loginUrl, "POST", JsonConvert.SerializeObject(uss));
                }
                catch (WebException)
                {
                    return ConnectStatus.ServiceNotAvailable;
                }
            }
            if (!String.IsNullOrEmpty(result))
            {
                userToken = JsonConvert.DeserializeObject<TokenService.Token>(result).Key;
                UserLogined(login, password);
                return ConnectStatus.Ok;
            }
            return ConnectStatus.Fail;
        }

        private async Task<ConnectStatus> AddFriend(string name)
        {
            bool result;
            string url = Properties.Settings.Default.userServiceUrl + Properties.Settings.Default.addFriendPath;

            using (WebClient webClient = new WebClient())
            {
                AddAuthorizationHeader(webClient, userLogin, userPassword);

                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                try
                {
                    var str = await webClient.UploadStringTaskAsync(url, "POST", JsonConvert.SerializeObject(name));
                    result = Boolean.Parse(str);
                }
                catch (WebException)
                {
                    return ConnectStatus.ServiceNotAvailable;
                }
            }
            if(result)
                userFriends.Add(name);

            return ConnectStatus.Ok;
        }

        private async Task GetFriends(string login, string password)
        {
            var url = Properties.Settings.Default.userServiceUrl + Properties.Settings.Default.getFriendsPath;

            using (var webClient = new WebClient())
            {
                AddAuthorizationHeader(webClient, login, password);

                try
                {
                    var answer = await webClient.DownloadStringTaskAsync(url);
                    userFriends = JsonConvert.DeserializeObject<List<string>>(answer);
                }
                catch (WebException)
                {
                    Debug.WriteLine("Can't get friends");
                }
            }
        }

        private void AddAuthorizationHeader(WebClient client, string login, string password)
        {
            var textBytes = Encoding.UTF8.GetBytes($"{login}:{password}");
            client.Headers.Add(HttpRequestHeader.Authorization, $"Basic {Convert.ToBase64String(textBytes)}");
        }


        #region Offline service

        private void ServiceOfflineNotification()
        {
            ServerOfflineNotificationTimer.Stop();
            ServerOfflinePanel.Visible = true;
            ServerOfflineNotificationTimer.Interval = serverOfflineNotidDelay;
            ServerOfflineNotificationTimer.Start();
        }

        private void ServerOfflineNotificationTimer_Tick(object sender, EventArgs e)
        {
            ServerOfflinePanel.Visible = false;
            ServerOfflineNotificationTimer.Stop();
        }

        #endregion


        #endregion

        #region ChatBox

        private void ChatOpen(string friendName)
        {
            ChatFriendName.Text = friendName;
            ChatFixExitPanelPosition();
            ChatPanel.Visible = true;
            ChatMessageClear();
            RestoreMessages(friendName);

            // close friend panel
            ToggleSideBarMenuButton(sideBarFriends, FriendsPanel);

            RemoveMessageNotification(friendName);
        }

        private void ChatSendMessageButton_Click(object sender, EventArgs e)
        {
            var text = ChatInputMessageText.Text.Trim(' ', '\n');
            if (!String.IsNullOrEmpty(text))
            {
                SendMessage(text, ChatFriendName.Text);
            }

            ChatInputMessageText.Text = "";
        }

        private void ChatExitPanel_Paint(object sender, PaintEventArgs e)
        {
            
            using (var gp = e.Graphics)
            {
                var width = e.ClipRectangle.Width;
                var height = e.ClipRectangle.Height;

                var br = new SolidBrush(chatExitPanelColor);
                var p1 = new Point(0, 0);
                var p2 = new Point(width, 0);
                var p3 = new Point(height, width);
                gp.FillPolygon(br, new Point[] { p1, p2, p3 });
            }
        }

        private void ChatResize(object obj, EventArgs args)
        {
            if (chatPanelCurrentWidth != ChatPanel.Width)
            {
                ChatInputMessageText.SuspendLayout();
                ChatSendMessageButton.SuspendLayout();
                ChatMessagesPanel.SuspendLayout();
                ChatScroll.SuspendLayout();

                var d = ChatPanel.Width - chatPanelCurrentWidth;

                ChatInputMessageText.Width += d;
                ChatSendMessageButton.Left += d;
                ChatMessagesPanel.Width += d;
                ChatScroll.Left += d;

                chatPanelCurrentWidth = ChatPanel.Width;
                moveIncomingMessages?.Invoke(d);
            }
        }

        private void ChatExitPanel_Click(object sender, EventArgs e)
        {
            ChatPanel.Visible = false;
        }

        private void ChatFixExitPanelPosition()
        {
            ChatExitPanel.Left = ChatFriendName.Left + ChatFriendName.Width;
        }

        private void RestoreMessages(string friendName)
        {
            foreach (var msg in Messages.GetMessages(userLogin, friendName))
            {
                if(msg.IsReceived == 0)
                    ChatOutcomingMessageAddPanel(msg.Message);
                else
                    ChatIncomingMessageAddPanel(msg.Message);
            }
            foreach (var msg in userNewMessages)
            {
                if (msg.Friend == friendName)
                {
                    if (msg.IsReceived == 0)
                        ChatOutcomingMessageAddPanel(msg.Message);
                    else
                        ChatIncomingMessageAddPanel(msg.Message);
                }
            }
        }

        private void FriendOfflineTimer_Tick(object sender, EventArgs e)
        {
            ChatFriendOfflinePanel.Visible = false;
            FriendOfflineTimer.Stop();
        }

        private void AddNewMessage(MessageFormat newMsg)
        {
            userNewMessages.Add(newMsg);
        }

        private void SaveUserMessages()
        {
            Messages.SaveMessages(userLogin, userNewMessages);
        }
        
        #endregion

        #region Scroll boxes

        // friend scroll
        private void FriendsListAddFriendsPanel()
        {
            userFriends.Sort();
            foreach (var f in userFriends)
            {
                friendScroll.AddNewItem(Generate_FriendPanel(f));
                if (userFriendsTheirMsgNotReaded.Contains(f))
                    AddNewMessageNotification(f);
            }
            friendScroll.MoveStart();
        }

        private void FriendsListClear()
        {
            friendScroll.Clear();
        }
        

        // chat scroll
        private void ChatOutcomingMessageAddPanel(string text)
        {
            var panel = Generate_ChatOutcomingMessagesPanel(text);
            chatScroll.AddNewItem(panel);
        }

        private void ChatIncomingMessageAddPanel(string text)
        {
            var panel = Generate_ChatIncomingMessagesPanel(text);
            chatScroll.AddNewItem(panel, ChatMessagesPanel.Width - panel.Width - 20);
        }

        private void ChatMessageClear()
        {
            chatScroll.Clear();
            moveIncomingMessages = null;
        }


        // scroll paint
        private void Scroll_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics v = e.Graphics)
            {
                using (var pen = new Pen(ScrollColor))
                {
                    DrawRoundRect(v, pen, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 3);
                }
            }
            base.OnPaint(e);
        }

        // make rounded
        private void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
                gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
                gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
                gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
                gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
                gp.CloseFigure();

                using (var br = new SolidBrush(p.Color))
                {
                    g.FillPath(br, gp);
                    g.DrawPath(p, gp);
                }
            }
        }

        #endregion

        #region Hub methods

        private async Task ConnectToHub()
        {
            var queryString = $"Token={userToken}";
            hub = new HubConnection(Properties.Settings.Default.signalrHubUrl, queryString);
            
            hubProxy = hub.CreateHubProxy(Properties.Settings.Default.signalrHubName);

            hubProxy.On("GetMessage", (string text, string fromFriend) => { GetMessage(text, fromFriend); });

            await hub.Start();
        }

        private void DisconnectFromHub()
        {
            hub?.Stop();
        }

        private void GetMessage(string text, string fromFriend)
        {
            BeginInvoke(new Action(()=> 
            {
                if (userFriends.Contains(fromFriend))
                {
                    // add new msg notification
                    if((ChatPanel.Visible != true) || (ChatFriendName.Text != fromFriend))
                    {
                        AddNewMessageNotification(fromFriend);
                    }
                    else
                    {
                        ChatIncomingMessageAddPanel(text);
                    }
                    var msg = new MessageFormat { Friend = fromFriend, Message = text,
                                                  Data = DateTime.Now.Ticks, IsReceived = 1 };
                    AddNewMessage(msg);
                }
            }));
        }

        private async void SendMessage(string text, string friendName)
        {
            if(await hubProxy.Invoke<bool>("SendMessage", text, friendName))
            {
                ChatOutcomingMessageAddPanel(text);
                var msg = new MessageFormat { Friend = friendName, Message = text,
                                              Data = DateTime.Now.Ticks, IsReceived = 0  };
                AddNewMessage(msg);
            }
            else
            {
                FriendOfflineTimer.Stop();
                FriendOfflineTimer.Interval = friendOfflineNotifDelay;
                ChatFriendOfflinePanel.Visible = true;
                FriendOfflineTimer.Start();
            }
        }

        #endregion

        #region Message Notifications

        private void AddNewMessageNotification(string friendName)
        {
            var p = FriendsListPanel.Controls.Find($"{friendName}_friendPanel", false).FirstOrDefault();
            var b = p.Controls.Find($"{friendName}_friendButtonn", false).FirstOrDefault();
            b.Controls.Find($"{friendName}_newMessageStatus", false).FirstOrDefault().Visible = true;
            userFriendsTheirMsgNotReaded.Add(friendName);
            addFriendSound.Play();
        }

        private void RemoveMessageNotification(string friendName)
        {
            var p = FriendsListPanel.Controls.Find($"{friendName}_friendPanel", false).FirstOrDefault();
            var b = p.Controls.Find($"{friendName}_friendButtonn", false).FirstOrDefault();
            b.Controls.Find($"{friendName}_newMessageStatus", false).FirstOrDefault().Visible = false;
            userFriendsTheirMsgNotReaded.Remove(friendName);
        }

        private void SaveFriendsWithNotReadedMsg()
        {
            var col = new System.Collections.Specialized.StringCollection();
            col.AddRange(userFriendsTheirMsgNotReaded.ToArray());

            Properties.Settings.Default.friendsWithNotReadedMsg = col;
            Properties.Settings.Default.Save();
        }

        private void LoadFriendsWithNotReadedMsg()
        {
            var col = Properties.Settings.Default.friendsWithNotReadedMsg;
            if (col == null)
                userFriendsTheirMsgNotReaded = new HashSet<string>();
            else
                userFriendsTheirMsgNotReaded = new HashSet<string>(col.Cast<string>().ToList());
        }

        #endregion

    }
}
