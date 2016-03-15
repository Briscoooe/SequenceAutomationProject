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
            if (RegisterEvent != null)
                RegisterEvent(this, new EventArgs());
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
