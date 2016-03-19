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
    public partial class Login : UserControl
    {
        public event EventHandler LoginEvent;
        public event EventHandler GoBackEvent;

        public Login()
        {
            InitializeComponent();
        }

        private void login(object sender, EventArgs e)
        {
            ConnectionManager connectionManager= new ConnectionManager();
            if (usernameTb.Text != "" && passwordTb.Text != "")
            {
                if (connectionManager.loginUser(usernameTb.Text, passwordTb.Text))
                {
                    BigMessageBox.Show("Logged in successfully");
                    Properties.Settings.Default.currentUser = usernameTb.Text;
                    if (LoginEvent != null)
                        LoginEvent(this, new EventArgs());
                }

                else
                {
                    BigMessageBox.Show("Username/email or password is incorrect");
                }
            }
            else
            {
                BigMessageBox.Show("You must fill in both fields");
            }
        }

        private void goBackEvent(object sender, EventArgs e)
        {
            if (GoBackEvent != null)
                GoBackEvent(this, e);
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
