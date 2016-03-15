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

            DatabaseManager dbManager = new DatabaseManager();
            if (dbManager.register(firstnameTb.Text, surnameTb.Text, emailTb.Text, usernameTb.Text, password1Tb.Text))
            {
                BigMessageBox.Show("Account created! You may now log in");
                if (RegisterEvent != null)
                    RegisterEvent(this, new EventArgs());
            }

            else
            {
                BigMessageBox.Show("Username or password is incorrect");
            }
            
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
    }
}
