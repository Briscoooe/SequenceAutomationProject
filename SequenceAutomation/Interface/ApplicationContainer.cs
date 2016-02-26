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
        /*
         * Method: ApplicationContainer()
         * Summary: Class constructor
         */
        public ApplicationContainer()
        {
            InitializeComponent();

            // Initialising the events to their appropriate methods
            loginUserControl.CreateButtonEvent += gotoCreate;
            loginUserControl.PlayButtonEvent += gotoPlay;
            createRecUserControl.BackButtonEvent += returnToLogin;
            playRecUserControl.BackButtonEvent += returnToLogin;
        }

        /* 
         * Method: returnToLogin()
         * Summary: Brings up the login menu by bringing it to the front of the view
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void returnToLogin(object sender, EventArgs e)
        {
            loginUserControl.BringToFront();
            ClientSize = new Size(990, 530);
        }

        /* 
         * Method: gotoPlay() 
         * Summary: Brings up the play recording menu by bringing it to the front of the view
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        public void gotoPlay(object sender, EventArgs e)
        {
            playRecUserControl.BringToFront();
            ClientSize = new Size(1406, 663);

        }

        /* 
        * Method: gotoCreate()
        * Summary: Brings up the create recording menu by bringing it to the front of the view
        * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
        */
        protected void gotoCreate(object sender, EventArgs e)
        {
            createRecUserControl.BringToFront();
        }
    }
}
