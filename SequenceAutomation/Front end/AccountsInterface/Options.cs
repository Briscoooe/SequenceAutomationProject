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
    public partial class Options : UserControl
    {
        public event EventHandler LoginEvent;
        public event EventHandler RegisterEvent;
        public event EventHandler GoBackEvent;

        public Options()
        {
            InitializeComponent();
        }

        private void gotoLogin(object sender, EventArgs e)
        {
            if (LoginEvent != null)
                LoginEvent(this, new EventArgs());
        }


        private void gotoRegister(object sender, EventArgs e)
        {
            if (RegisterEvent != null)
                RegisterEvent(this, e);
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
