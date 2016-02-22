using System;
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
            loginUserControl.Show();
            playRecUserControl.Hide();
            createRecUserControl.Hide();
        }

        public void gotoPlay(object sender, EventArgs e)
        {
            playRecUserControl.Show();
            loginUserControl.Hide();
        }

        protected void gotoCreate(object sender, EventArgs e)
        {
            createRecUserControl.Show();
            loginUserControl.Hide();
        }
    }
}
