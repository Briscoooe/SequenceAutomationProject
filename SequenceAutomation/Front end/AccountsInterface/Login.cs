using System;
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
            Cursor.Current = Cursors.WaitCursor;
            ConnectionManager connectionManager = new ConnectionManager();
            if (usernameTb.Text != "" && passwordTb.Text != "")
            {
                if (connectionManager.loginUser(usernameTb.Text, passwordTb.Text))
                {
                    BigMessageBox.Show("Logged in successfully");
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
            Cursor.Current = Cursors.Arrow;

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
