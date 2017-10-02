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
            Anonymous = 0,
        }
        Dictionary<Status, string> statuses = new Dictionary<Status, string>
        {
            { Status.Anonymous, "Anonymous"},
        };

        string login;
        string password;
        string token;

        Point windowPosition;
        int menuNormalWidth = 160;
        int menuToggleSpeed = 50;

        Color activeSideBarButtonColor = Color.FromArgb(20, 23, 28);
        Color transparentColor = Color.Transparent;

        Color FriendPanelHovered = Color.FromArgb(255, 38, 51, 62);
        Color FriendPanelNotHovered = Color.Transparent;

        Color ScrollColor = Color.FromArgb(255, 22, 25, 30);
        CustomScrollBar custScroll;

        Dictionary<PictureBox, Panel> activeSideBar = new Dictionary<PictureBox, Panel>();

        public MainForm()
        {
            InitializeComponent();
            StartUserSettings();
            ControlsSettings();

            custScroll = new CustomScrollBar(FriendsListPanel, Scroll, 3);
            for (int i = 0; i < 15; i++)
            {
                AddNewFriend(i.ToString());
            }
        }

        private void ControlsSettings()
        {
            ProfilePanel.Width = 0;
            ProfilePanel.Visible = false;

            FriendsPanel.Width = 0;
            FriendsPanel.Visible = false;
        }



        #region Custom scroll
        
        private void AddNewFriend(string name)
        {
            custScroll.AddNewItem(CreatePanel(name));
        }

        private Panel CreatePanel(string name)
        {
            var p = new Panel();
            var but = new Button();
            var picBox = new PictureBox();

            // custom panel
            p.Name = $"{name}_friendPanel";
            p.Controls.Add(picBox);
            p.Controls.Add(but);
            p.Size = new Size(160, 50);
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
            but.Size = new Size(104, 50);
            but.Text = name;
            but.UseVisualStyleBackColor = true;
            but.MouseLeave += (object sender, EventArgs e) => { but.Parent.BackColor = FriendPanelNotHovered; };
            but.MouseHover += (object sender, EventArgs e) => { but.Parent.BackColor = FriendPanelHovered; };

            return p;
        }

        private void Scroll_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            var pen = new Pen(ScrollColor);
            DrawRoundRect(v, pen, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 3);
            base.OnPaint(e);
        }

        private void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
                g.FillPath(new SolidBrush(p.Color), gp);
                g.DrawPath(p, gp);
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
            Timer.Tick += (object s, EventArgs el) =>
            {
                p.Width -= menuToggleSpeed;
                if (p.Width <= 0)
                {
                    Timer.Stop();
                    Timer = new Timer();
                    p.Width = 0;
                    p.Visible = false;
                    Refresh();
                }
            };
            Timer.Start();
        }

        private void Open(Panel p)
        {
            Timer.Tick += (object s, EventArgs el) =>
            {
                p.Width += menuToggleSpeed;
                if (p.Width >= menuNormalWidth)
                {
                    Timer.Stop();
                    Timer = new Timer();
                    p.Width = menuNormalWidth;
                    Refresh();
                }
            };

            p.Visible = true;
            Timer.Start();
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
        }

        private void FriendsPanelStatusLogined()
        {
            FriendsPanel.Controls.Find("LogInToSeeFriendsLabel", false).FirstOrDefault()?.Dispose();
            FriendsListPanel.Visible = true;
            AddFriendPanel.Visible = true;
        }


        #endregion

        #region Generate Controls

        // profile panel

        private void Generate_LogOutButton()
        {
            var but = new Button();
            but.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(204)))), ((int)(((byte)(253)))));
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Font = new Font("Microsoft YaHei UI Light", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point(30, 200);
            but.Name = "ProfilePanelLogOutButton";
            but.Size = new Size(100, 40);
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
            but.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(204)))), ((int)(((byte)(253)))));
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Font = new Font("Microsoft YaHei UI Light", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point(30, 269);
            but.Name = "ProfilePanelSignUpButton";
            but.Size = new Size(100, 40);
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
            but.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(204)))), ((int)(((byte)(253)))));
            but.FlatStyle = FlatStyle.Flat;
            but.TabStop = false;
            but.Font = new Font("Microsoft YaHei UI Light", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            but.Location = new Point(30, 200);
            but.Name = "ProfilePanelLogInButton";
            but.Size = new Size(100, 40);
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
            l.AutoSize = true;
            l.Font = new Font("Microsoft YaHei Light", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            l.Location = new Point(3, 147);
            l.Size = new Size(156, 50);
            l.TabIndex = 1;
            l.Name = "LogInToSeeFriendsLabel";
            l.Text = "        LogIn\r\nto see friends list";

            FriendsPanel.Controls.Add(l);
        }
        
        #endregion

        #region User methods

        private void UserLogined()
        {
            ProfilePanelStatusLogined();
            FriendsPanelStatusLogined();
        }

        private void UserNotLogined()
        {
            ProfilePanelStatusUnlogin();
            FriendsPanelStatusUnlogin();
        }

        private void UpdateUser(string name, string pass)
        {
            login = name;
            password = pass;
            ProfilepanelLoginLabel.Text = name;
            ProfilepanelLoginLabel.Left = (menuNormalWidth - ProfilepanelLoginLabel.Width) / 2;
        }

        private string EncodeBase64(string name, string password)
        {
            var textBytes = Encoding.UTF8.GetBytes($"{name}:{password}");
            return Convert.ToBase64String(textBytes);
        }

        private void SaveUserInfo()
        {
            Properties.Settings.Default.Login = login;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();
        }

        private void LoadUserInfo()
        {
            login = Properties.Settings.Default.Login;
            password = Properties.Settings.Default.Password;
        }

        private async void StartUserSettings()
        {
            LoadUserInfo();
            if(login != statuses[Status.Anonymous])
            {
                if(!await AuthenticateUser(login, password))
                {
                    UpdateUser(statuses[Status.Anonymous], "");
                }
            }
            else
            {
                UserNotLogined();
            }
        }

        #endregion

        #region Connect with service

        public async Task<bool> AuthenticateUser(string login, string password)
        {
            string result;
            var loginUrl = Properties.Settings.Default.loginUrl;

            using (WebClient webClient = new WebClient())
            {
                var uri = new Uri(loginUrl);
                var enc = EncodeBase64(login, password);
                webClient.Headers.Add(HttpRequestHeader.Authorization, $"Basic {enc}");
                result = await webClient.DownloadStringTaskAsync(uri);
            }

            if (!String.IsNullOrEmpty(result))
            {
                token = JsonConvert.DeserializeObject<TokenService.Token>(result).Key;
                UpdateUser(login, password);
                SaveUserInfo();
                UserLogined();
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
                token = JsonConvert.DeserializeObject<TokenService.Token>(result).Key;
                UpdateUser(login, password);
                SaveUserInfo();
                UserLogined();
                return true;
            }
            UserNotLogined();
            return false;
        }


        #endregion

    }
}
