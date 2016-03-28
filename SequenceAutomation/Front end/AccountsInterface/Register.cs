using System;
using System.Collections.Generic;
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
            Cursor.Current = Cursors.WaitCursor;

            if (firstnameTb.Text != "" || surnameTb.Text != "" || usernameTb.Text != "" ||
                password1Tb.Text != "" || password2Tb.Text != "")
            {
                if(ConnectionManager.testConnection())
                {
                    List<string> userInfo = new List<string>();
                    userInfo.Add(firstnameTb.Text);
                    userInfo.Add(surnameTb.Text);
                    userInfo.Add(emailTb.Text);
                    userInfo.Add(usernameTb.Text);
                    userInfo.Add(password1Tb.Text);
                    userInfo.Add(password2Tb.Text);

                    string result = ConnectionManager.register(userInfo);

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
                            usernameTb.Text = "";
                            break;
                        case "EMAIL_EXISTS":
                            BigMessageBox.Show("There is already an account registered to this email address");
                            emailTb.Text = "";
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

                else
                {
                    BigMessageBox.Show("Could not connect to server");
                }
            }
            else
            {
                BigMessageBox.Show("Please fill in all fields");
            }

            Cursor.Current = Cursors.Arrow;

        }

        private void goBack(object sender, EventArgs e)
        {
            if (GoBackEvent != null)
                GoBackEvent(this, new EventArgs());
        }

        private void goBackBtn_MouseLeave(object sender, EventArgs e)
        {
            goBackBtn.BackgroundImage = Properties.Resources.backbutton;
        }

        private void goBackBtn_MouseEnter(object sender, EventArgs e)
        {
            goBackBtn.BackgroundImage = Properties.Resources.backbutton_hover;
        }

        private void passwordKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar)
               && e.KeyChar != '_' && e.KeyChar != '*' && e.KeyChar != '!')
            {
                e.Handled = true;
                return;
            }
            e.Handled = false;
            return;
        }

        private void showPasswordInfo(object sender, EventArgs e)
        {
            BigMessageBox.Show("Passwords may be up to 16 characters and may only contain letters, numbers, '*', '_' or '!'");

        }
    }
}
