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

namespace Client
{
    public partial class MainForm : Form
    {
        string login;
        string password;
        string token;

        Point windowPosition;
        int menuNormalWidth = 160;
        int menuToggleSpeed = 50;

        Color activeSideBarButtonColor = Color.FromArgb(20, 23, 28);
        Color transparentColor = Color.Transparent;

        

        Dictionary<PictureBox, Panel> activeSideBar = new Dictionary<PictureBox, Panel>();

        public MainForm()
        {
            InitializeComponent();
            StartUserSettings();
        }

        

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

        private void ProfilePanelLogInButton_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            regForm.ActivateLogInTab();
            regForm.Location = this.Location;
            regForm.MainForm = this;
            regForm.Show();
            ToggleSideBarMenuButton(sideBarProfile, ProfilePanel);
        }

        private void ProfilePanelSignUpButton_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            regForm.ActivateSignUpTab();
            regForm.Location = this.Location;
            regForm.MainForm = this;
            regForm.Show();
            ToggleSideBarMenuButton(sideBarProfile, ProfilePanel);
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




        #endregion

        #region User methods

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
            if(login != "Anonymous")
            {
                if(!await AuthenticateUser(login, password))
                {
                    UpdateUser("Anonymous", "");
                }
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
                return true;
            }
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
                return true;
            }
            return false;
        }

        #endregion
    }
}
