using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class ApplicationContainer : Form
    {
        public ApplicationContainer()
        {
            InitializeComponent();
            loginUserControl.CreateButtonEvent += gotoCreate;
            loginUserControl.PlayButtonEvent += gotoPlay;
            createRecUserControl.BackButtonEvent += returnToHome;
            playRecUserControl.BackButtonEvent += returnToHome;
        }

        private void returnToHome(object sender, EventArgs e)
        {
            loginUserControl.BringToFront();
        }

        public void gotoPlay(object sender, EventArgs e)
        {
            playRecUserControl.BringToFront();
        }

        protected void gotoCreate(object sender, EventArgs e)
        {
            createRecUserControl.BringToFront();
        }
    }
}
