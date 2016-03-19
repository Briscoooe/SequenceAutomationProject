using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class Register : UserControl
    {
        public event EventHandler RegisterEvent;
        public event EventHandler GoBackEvent;

        public Register()
        {
            InitializeComponent();
        }

        private void register(object sender, EventArgs e)
        {
            ConnectionManager connectionManager = new ConnectionManager();
            List<string> userInfo = new List<string>();
            userInfo.Add(firstnameTb.Text);
            userInfo.Add(surnameTb.Text);
            userInfo.Add(emailTb.Text);
            userInfo.Add(usernameTb.Text);
            userInfo.Add(password1Tb.Text);
            userInfo.Add(password2Tb.Text);

            string result = connectionManager.register(userInfo);

            switch (result)
            {
                case "REGISTER_SUCCESSFUL":
                    BigMessageBox.Show("Account created! You may now log in");
                    if (RegisterEvent != null)
                        RegisterEvent(this, new EventArgs());
                    firstnameTb.Text = "";
                    surnameTb.Text = "";
                    emailTb.Text = "";
                    usernameTb.Text = "";
                    password1Tb.Text = "";
                    password2Tb.Text = "";
                    break;
                case "CONNECTION_ERROR":
                    BigMessageBox.Show("There was a problem connecting to the server");
                    break;
                case "USERNAME_EXISTS":
                    BigMessageBox.Show("This username is already taken");
                    break;
                case "EMAIL_EXISTS":
                    BigMessageBox.Show("There is already an account registered to this email address");
                    break;
                case "EMAIL_INVALID":
                    BigMessageBox.Show("The email address you entered was not valid");
                    break;
                case "PASSWORD_NO_MATCH":
                    BigMessageBox.Show("The passwords you entered did not match");
                    break;
                case "ERROR":
                    BigMessageBox.Show("There was a problem with the registration. Please try again");
                    break;
                default:
                    break;
            }

        }

        private void goBack(object sender, EventArgs e)
        {
            if (GoBackEvent != null)
                GoBackEvent(this, new EventArgs());
        }

        private void passwordKeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            // Check for a naughty character in the KeyDown event.
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^+^\-^\/^\*^\(^\)]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }*/
        }

        private void goBackBtn_MouseLeave(object sender, EventArgs e)
        {
            goBackBtn.BackgroundImage = Properties.Resources.backbutton;
        }

        private void goBackBtn_MouseEnter(object sender, EventArgs e)
        {
            goBackBtn.BackgroundImage = Properties.Resources.backbutton_hover;
        }
    }
}
