using System;
using System.Drawing;
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
            CenterToScreen();

            // Initialising the events to their appropriate methods
            loginUserControl.CreateButtonEvent += gotoCreate;
            loginUserControl.PlayButtonEvent += gotoTutorialSelect;

            createRecUserControl.BackButtonEvent += returnToLogin;

            playRecUserControl.BackButtonEvent += returnToLogin;
            playRecUserControl.TutorialEvent += gotoTutorial;

            firstTimePlay.YesTutorialEvent += gotoTutorial;
            firstTimePlay.NoTutorialEvent += gotoPlay;

            tutorialSelectRec.goBackEvent += returnToLogin;
            tutorialSelectRec.goNextEvent += gotoSelectSpeed;
            tutorialSelectRec.gotoLoginEvent += returnToLogin;

            tutorialSelectSpeed.goBackEvent += gotoSelectRec;
            tutorialSelectSpeed.goNextEvent += gotoPlayRec;
            tutorialSelectSpeed.gotoLoginEvent += returnToLogin;

            tutorialPlayRec.goBackEvent += gotoSelectSpeed;
            tutorialPlayRec.gotoPlayEvent += gotoPlay;
            tutorialPlayRec.gotoLoginEvent += returnToLogin;
        }

        private void gotoPlayRec(object sender, EventArgs e)
        {
            ClientSize = new Size(847, 468);
            tutorialPlayRec.BringToFront();
            CenterToScreen();
        }

        private void gotoSelectRec(object sender, EventArgs e)
        {
            ClientSize = new Size(990, 530);
            tutorialSelectRec.BringToFront();
            CenterToScreen();
        }

        private void gotoSelectSpeed(object sender, EventArgs e)
        {
            ClientSize = new Size(955, 444);
            tutorialSelectSpeed.BringToFront();
            CenterToScreen();
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
            CenterToScreen();
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
            CenterToScreen();
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
            CenterToScreen();
        }

        private void gotoTutorial(object sender, EventArgs e)
        {
            ClientSize = new Size(990, 530);
            tutorialSelectRec.BringToFront();
            CenterToScreen();
        }


        private void gotoTutorialSelect(object sender, EventArgs e)
        {
            firstTimePlay.BringToFront();
            CenterToScreen();
        }

    }
}
