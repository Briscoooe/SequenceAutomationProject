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
            if (password1Tb.Text == password2Tb.Text)
            {
                if (connectionManager.validateEmail(emailTb.Text) == 1)
                {
                    if (!connectionManager.validateUsername(usernameTb.Text))
                    {
                        List<string> userInfo = new List<string>();
                        userInfo.Add(firstnameTb.Text);
                        userInfo.Add(surnameTb.Text);
                        userInfo.Add(emailTb.Text);
                        userInfo.Add(usernameTb.Text);
                        userInfo.Add(password1Tb.Text);

                        if (connectionManager.register(userInfo))
                        {
                            BigMessageBox.Show("Account created! You may now log in");
                            if (RegisterEvent != null)
                                RegisterEvent(this, new EventArgs());
                            firstnameTb.Text = "";
                            surnameTb.Text = "";
                            emailTb.Text = "";
                            usernameTb.Text = "";
                            password1Tb.Text = "";
                            password2Tb.Text = "";
                        }

                        else
                            BigMessageBox.Show("Something went wrong");
                    }

                    else
                        BigMessageBox.Show("This username is already in use");
                }

                else if (connectionManager.validateEmail(emailTb.Text) == 0)
                    BigMessageBox.Show("This email adress is already in use");

                else if (connectionManager.validateEmail(emailTb.Text) ==2)
                    BigMessageBox.Show("This is not a valid email address");
            }
            else
                BigMessageBox.Show("Passwords do not match");
            
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
