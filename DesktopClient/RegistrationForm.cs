using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class RegistrationForm : Form
    {
        enum AuthenticationStatus
        {
            Ok,
            Fail
        }

        #region Colors

        Color bgColor = Color.FromArgb(32, 43, 52);

        Color okButtonBackColor = Color.FromArgb(10, 104, 79);
        Color okButtonBackColorHover = Color.FromArgb(21, 135, 104);
        Color okButtonForeColor = Color.White;

        Color failButtonBackColor = Color.FromArgb(56, 63, 73);
        Color failButtonForeColor = Color.FromArgb(48, 53, 61);

        Color AuthenticationStatus_fail = Color.FromArgb(249, 12, 0);
        Color AuthenticationStatus_ok = Color.FromArgb(17, 214, 53);

        #endregion

        public MainForm MainForm { get; set; }

        AuthenticationStatus authStatus;

        Point windowPosition;

        int authentNotificDelay = 1300;
        bool isLogInButtEnabled = true;
        bool isRegistrButtEnabled = true;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        #region Exit button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.ImageLocation = @"Resources\ExitButtonHovered.png";
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.ImageLocation = @"Resources\ExitButton.png";
        }

        #endregion

        #region Validation

        private bool ValidateLogin(string login)
        {
            if (login.Length > 2)
                return true;
            return false;
        }

        private bool ValidatePassword(string pass)
        {
            if (pass.Length >= 5)
                return true;
            return false;
        }

        private bool ValidateEmail(string mail)
        {
            if (mail.Contains("@"))
                return true;
            return false;
        }
        #endregion

        #region Login/SignUp buttom

        private void ActivateButton(Button btn)
        {
            btn.BackColor = okButtonBackColor;
            btn.FlatAppearance.MouseOverBackColor = okButtonBackColorHover;
            btn.FlatAppearance.MouseDownBackColor = okButtonBackColorHover;
            btn.ForeColor = okButtonForeColor;
            btn.Enabled = true;
        }

        private void DeactivateButton(Button btn)
        {
            btn.BackColor = failButtonBackColor;
            btn.FlatAppearance.MouseOverBackColor = failButtonBackColor;
            btn.FlatAppearance.MouseDownBackColor = failButtonBackColor;
            btn.ForeColor = failButtonForeColor;
            btn.Enabled = false;
        }

        #endregion

        #region Activate tabs
        private void ClearFields()
        {
            UserLoginField.Text = "";
            UserPassField.Text = "";
        }

        public void ActivateLogInTab()
        {
            ClearFields();
            LogInTab.Enabled = false;
            SignUpTab.Enabled = true;

            LogInButton.Visible = true;
            RegistrationButton.Visible = false;


            ActiveTabStatus.Location = new Point(LogInTab.Location.X,
                                                            ActiveTabStatus.Location.Y);
        }

        public void ActivateSignUpTab()
        {
            ClearFields();
            LogInTab.Enabled = true;
            SignUpTab.Enabled = false;

            LogInButton.Visible = false;
            RegistrationButton.Visible = true;

            ActiveTabStatus.Location = new Point(SignUpTab.Location.X,
            ActiveTabStatus.Location.Y);
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


        private void AuthenticationNotification(AuthenticationStatus status, int delayTime, bool closeAfter)
        {
            // method make main panel transparent so helper panel(AuthenticationStatusPanel)
            // with correct border color can represent status of authentication,
            // after delayTime main panel again make previos color.
            // all this for prevent flickering while render border
            
            authStatus = status;
            StatusPanel.Refresh();
            MainPanel.BackColor = Color.Transparent;
            StatusPanel.Visible = true;

            Timer.Interval = delayTime;
            Timer.Tick += (object obj, EventArgs args) =>
            {
                StatusPanel.Visible = false;
                MainPanel.BackColor = bgColor;
                Timer.Stop();
                Timer = new Timer();
                if (closeAfter)
                {
                    // close form
                    this.Dispose();
                }
                isLogInButtEnabled = true;
                isRegistrButtEnabled = true;
            };
            Timer.Start();
        }

        private void UserInputData_TextChanged(object sender, EventArgs e)
        {
            if (!LogInTab.Enabled)
            {
                if (ValidateLogin(UserLoginField.Text) && ValidatePassword(UserPassField.Text))
                    ActivateButton(LogInButton);
                else
                    DeactivateButton(LogInButton);
            }
            else
            {
                if (ValidateLogin(UserLoginField.Text) && ValidatePassword(UserPassField.Text))
                    ActivateButton(RegistrationButton);
                else
                    DeactivateButton(RegistrationButton);
            }
        }
        
        #region Signin panel

        private async void LogInButton_Click(object sender, EventArgs e)
        {
            if (isLogInButtEnabled)
            {
                isLogInButtEnabled = false;
                string login = UserLoginField.Text;
                string password = UserPassField.Text;

                if (await MainForm.LogInUser(login, password))
                {
                    AuthenticationNotification(AuthenticationStatus.Ok, authentNotificDelay, true);
                }
                else
                {
                    AuthenticationNotification(AuthenticationStatus.Fail, authentNotificDelay, false);
                }
            }
        }

        private void AuthenticationLogInTab_Click(object sender, EventArgs e)
        {
            ActivateLogInTab();
        }

        #endregion

        #region SignUp panel

        private async void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (isRegistrButtEnabled)
            {
                isRegistrButtEnabled = false;
                string login = UserLoginField.Text;
                string password = UserPassField.Text;

                if (await MainForm.RegisterUser(login, password))
                {
                    AuthenticationNotification(AuthenticationStatus.Ok, authentNotificDelay, true);
                }
                else
                {
                    AuthenticationNotification(AuthenticationStatus.Fail, authentNotificDelay, false);
                }
            }
        }

        private void AuthenticationSignUpTab_Click(object sender, EventArgs e)
        {
            ActivateSignUpTab();
        }

        #endregion

        private void AuthenticationStatusPanel_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor;

            if(authStatus == AuthenticationStatus.Ok)
            {
                borderColor = AuthenticationStatus_ok;
            }
            else
            {
                borderColor = AuthenticationStatus_fail;
            }
            ControlPaint.DrawBorder(e.Graphics, StatusPanel.ClientRectangle,
                                    borderColor, 3, ButtonBorderStyle.Solid,
                                    borderColor, 3, ButtonBorderStyle.Solid,
                                    borderColor, 3, ButtonBorderStyle.Solid,
                                    borderColor, 3, ButtonBorderStyle.Solid);
        }
    }
}
