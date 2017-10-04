using System;
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

namespace DesktopClient
{
    public partial class MainForm : Form
    {
        enum Status
        {
            Default = 0,
            Anonymous = 1,
            Logined = 2
        }

        #region Vars

        const string userAddedSuccess = "User added";
        const string userAddedFail = "No such user";
        const string userAddedYourSelf = "Can't add yourself";
        const string userAddedFriendExists = "User already exists";

        #region User info

        string userLogin;
        string userPassword;
        string userToken;

        Status userStatus = Status.Default;
        List<string> userFriends = new List<string>();

        #endregion

        #region Colors

        Color activeSideBarButtonColor = Color.FromArgb(20, 23, 28);
        Color transparentColor = Color.Transparent;

        Color FriendPanelHoveredColor = Color.FromArgb(255, 38, 51, 62);
        Color FriendPanelNotHoveredColor = Color.Transparent;

        Color ScrollColor = Color.FromArgb(255, 22, 25, 30);


        Color userAddedSuccessColor = Color.FromArgb(255, 6, 96, 11);
        Color userAddedFailColor = Color.FromArgb(255, 122, 17, 17);

        Color profilePanelButtonPressColor = Color.FromArgb(255, 152, 204, 253);

        Color myMessagesTextPanelColor = Color.FromArgb(255, 49, 74, 94);

        #endregion

        Point windowPosition;
        int menuNormalWidth = 170;
        int menuToggleSpeed = 50;

        int userAddFriendNotifDelay = 1500;

        #region Scrolls

        CustomScrollBar friendScroll;

        CustomScrollBar chatScroll;

        #endregion

        Dictionary<PictureBox, Panel> activeSideBar = new Dictionary<PictureBox, Panel>();

        Dictionary<Status, string> statuses = new Dictionary<Status, string>
        {
            { Status.Anonymous, "Anonymous"},
        };

        int messagePanelMaxWidth = 250;

        int chatPanelCurrentWidth;

        #endregion

        



        public MainForm()
        {
            InitializeComponent();
            friendScroll = new CustomScrollBar(FriendsListPanel, FriendsScroll, 3);

            StartUserSettings();
            ControlsSettings();

            chatScroll = new CustomScrollBar(ChatMessagesPanel, ChatScroll, 10);
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            ChatPanel.Resize += (object obj, EventArgs args) =>
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
                }

            };


            chatPanelCurrentWidth = ChatPanel.Width;
        }

        private void ControlsSettings()
        {
            ProfilePanel.Width = 0;
            ProfilePanel.Visible = false;

            FriendsPanel.Width = 0;
            FriendsPanel.Visible = false;

            // profile panel
            ProfilepanelAvatarPic.Left = (menuNormalWidth - ProfilepanelAvatarPic.Width) / 2;

        }



        #region Custom scroll
        
        // friend scroll
        private void FriendsListAddNewPanel(string name)
        {
            friendScroll.AddNewItem(CreateFriendPanel(name));
        }

        private void FriendsListClear()
        {
            friendScroll.Clear();
        }

        // custom class for enabling doubleclick event (wtf?!?)
        class MyButt : Button
        {
            public MyButt()
            {
                SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            }
        }

        private Panel CreateFriendPanel(string name)
        {
            var p = new Panel();
            var but = new MyButt();
            var picBox = new PictureBox();

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
                ChatFriendName.Text = but.Text;
                ChatPanel.Visible = true;
            };

            return p;
        }
        

        // chat scroll
        private void ChatMessageAddNewPanel(string text)
        {
            chatScroll.AddNewItem(CreateChatMessagesPanel(text));
        }

        private Panel CreateChatMessagesPanel(string text)
        {
            
            var p = new Panel();
            var rich = new RichTextBox();

            p.SuspendLayout();
            rich.SuspendLayout();

            p.Controls.Add(rich);

            rich.BackColor = myMessagesTextPanelColor;
            rich.BorderStyle = BorderStyle.None;
            rich.Font = new Font("Microsoft YaHei UI Light", 13F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            rich.ForeColor = Color.Black;
            rich.CausesValidation = false;
            rich.Cursor = Cursors.Arrow;
            rich.ScrollBars = RichTextBoxScrollBars.None;
            rich.ShortcutsEnabled = false;
            rich.WordWrap = true;
            rich.TabStop = false;
            rich.Margin = new Padding(0,0,0,0);
            rich.Text = text;
            rich.Left = 10;
            rich.Top = 4;

            using (Graphics g = CreateGraphics())
            {
                rich.Height = (int)g.MeasureString(rich.Text, rich.Font, messagePanelMaxWidth).Height;
                rich.Width = (int)g.MeasureString(rich.Text, rich.Font, messagePanelMaxWidth).Width;
            }

            // panel
            p.BackColor = Color.Transparent;
            p.Size = new Size(rich.Width + 20, rich.Height + 8);
            p.Margin = new Padding(0,0,0,0);
            p.Paint += new PaintEventHandler(ChatMessagesPanel_Paint);

            rich.ResumeLayout();
            p.ResumeLayout();

            return p;
        }

        private void ChatMessagesPanel_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            panel.SuspendLayout();

            using (Graphics v = e.Graphics)
            {
                using (var pen = new Pen(myMessagesTextPanelColor))
                {
                    DrawRoundRect(v, pen, panel.ClientRectangle.Left, panel.ClientRectangle.Top, panel.ClientRectangle.Width - 1, panel.ClientRectangle.Height - 1, 10);
                }
            }

            panel.ResumeLayout();
            base.OnPaint(e);
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


        #region Exit button
        private void ExitButton_Click(object sender, EventArgs e)
        {
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
            ProfilePanel.Refresh();
        }

        private void ProfilePanelStatusLogined()
        {
            ProfilePanel.Controls.Find("ProfilePanelLogInButton", false).FirstOrDefault()?.Dispose();
            ProfilePanel.Controls.Find("ProfilePanelSignUpButton", false).FirstOrDefault()?.Dispose();
            Generate_LogOutButton();
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
        }

        private async void AddFriendName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if(AddFriendName.Text.Length > 0)
                {
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
                    else if (await AddFriend(friendName))
                    {
                        AddFriendStatusTimer.Start();
                        Generate_AddFriendStatus(userAddedSuccessColor, userAddedSuccess);

                        FriendsListAddNewPanel(friendName);
                    }
                    else
                    {
                        AddFriendStatusTimer.Start();
                        Generate_AddFriendStatus(userAddedFailColor, userAddedFail);
                    }
                }
                FriendsScroll.Invalidate();
            }
        }

        private void AddFriendStatusTimer_Tick(object sender, EventArgs e)
        {
            FriendsListPanel.Controls.Find("AddFriendStatusPanel", false).FirstOrDefault()?.Dispose();
            FriendsScroll.Invalidate();
            AddFriendStatusTimer.Stop();
        }

        #endregion

        #region Generate Controls

        // profile panel

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
                UpdateUser(statuses[Status.Anonymous], "");
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


        // friends panel

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

        #endregion

        #region User methods

        private async void UserLogined(string login, string password)
        {
            if(userStatus != Status.Logined)
            {
                ProfilePanelStatusLogined();
                FriendsPanelStatusLogined();

                userStatus = Status.Logined;
            }

            UpdateUser(login, password);
            SaveUserInfo();

            await GetFriends(userLogin, userPassword);

            foreach (var f in userFriends)
            {
                FriendsListAddNewPanel(f);
            }
        }

        private void UserNotLogined()
        {
            if(userStatus != Status.Anonymous)
            {
                ProfilePanelStatusUnlogin();
                FriendsPanelStatusUnlogin();

                userStatus = Status.Anonymous;
            }
            UpdateUser(statuses[Status.Anonymous], "");
            SaveUserInfo();
        }

        private void UpdateUser(string name, string pass)
        {
            userLogin = name;
            userPassword = pass;
            ProfilepanelLoginLabel.Text = name;
            ProfilepanelLoginLabel.Left = (menuNormalWidth - ProfilepanelLoginLabel.Width) / 2;
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
            if(userLogin != statuses[Status.Anonymous])
            {
                await LogInUser(userLogin, userPassword);
            }
            else
            {
                UserNotLogined();
            }
        }

        #endregion

        #region Connect with service

        public async Task<bool> LogInUser(string login, string password)
        {
            string result;
            var url = Properties.Settings.Default.loginUrl;

            using (WebClient webClient = new WebClient())
            {
                var uri = new Uri(url);
                AddAuthorizationHeader(webClient, login, password);
                try
                {
                    result = await webClient.DownloadStringTaskAsync(uri);
                }
                catch(WebException)
                {
                    result = null;
                }
            }
            if (!String.IsNullOrEmpty(result))
            {
                userToken = JsonConvert.DeserializeObject<TokenService.Token>(result).Key;
                UserLogined(login, password);
                return true;
            }
            UserNotLogined();
            return false;
        }

        public async Task<bool> RegisterUser(string login, string password)
        {
            string result;
            var loginUrl = Properties.Settings.Default.signupUrl;

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var uss = new TokenService.User() { Login = login, Password = password };
                result = await webClient.UploadStringTaskAsync(loginUrl, "POST", JsonConvert.SerializeObject(uss));
            }
            if (!String.IsNullOrEmpty(result))
            {
                userToken = JsonConvert.DeserializeObject<TokenService.Token>(result).Key;
                UserLogined(login, password);
                return true;
            }
            return false;
        }

        private async Task<bool> AddFriend(string name)
        {
            bool result;
            string url = Properties.Settings.Default.addFriendUrl + name;

            using (WebClient webClient = new WebClient())
            {
                AddAuthorizationHeader(webClient, userLogin, userPassword);

                try
                {
                    var str = await webClient.DownloadStringTaskAsync(url);
                    result = Boolean.Parse(str);
                }
                catch (WebException)
                {
                    return false;
                }
            }
            if(result)
                userFriends.Add(name);

            return result;
        }

        private async Task GetFriends(string login, string password)
        {
            var url = Properties.Settings.Default.getFriendsUrl;

            using (var webClient = new WebClient())
            {
                AddAuthorizationHeader(webClient, login, password);

                try
                {
                    var answer = await webClient.DownloadStringTaskAsync(url);
                    userFriends = JsonConvert.DeserializeObject<List<string>>(answer);
                    userFriends.Sort();
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




        #endregion


        #region ChatBox

        private void ChatSendMessageButton_Click(object sender, EventArgs e)
        {
            var text = ChatInputMessageText.Text.Trim(' ', '\n');
            if (!String.IsNullOrEmpty(text))
            {
                ChatMessageAddNewPanel(text);
            }

            ChatInputMessageText.Text = "";
        }



        #endregion

        private void ChatCloseButton_Click(object sender, EventArgs e)
        {
            ChatPanel.Visible = false;
        }
    }
}
