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

            tutorialSelectSpeed.goBackEvent += gotoSelectRec;
            tutorialSelectSpeed.goNextEvent += gotoPlayRec;

            tutorialPlayRec.goBackEvent += gotoSelectSpeed;
            tutorialPlayRec.gotoPlayEvent += gotoPlay;
        }

        private void gotoPlayRec(object sender, EventArgs e)
        {
            CenterToScreen();
            ClientSize = new Size(809, 385);
            tutorialPlayRec.BringToFront();
        }

        private void gotoSelectRec(object sender, EventArgs e)
        {
            CenterToScreen();
            ClientSize = new Size(990, 530);
            tutorialSelectRec.BringToFront();
        }

        private void gotoSelectSpeed(object sender, EventArgs e)
        {
            CenterToScreen();
            ClientSize = new Size(865, 444);
            tutorialSelectSpeed.BringToFront();
        }

        /* 
         * Method: returnToLogin()
         * Summary: Brings up the login menu by bringing it to the front of the view
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void returnToLogin(object sender, EventArgs e)
        {
            CenterToScreen();
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
            CenterToScreen();
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
            CenterToScreen();
            createRecUserControl.BringToFront();
        }

        private void gotoTutorial(object sender, EventArgs e)
        {
            ClientSize = new Size(990, 530);
            CenterToScreen();
            tutorialSelectRec.BringToFront();
        }


        private void gotoTutorialSelect(object sender, EventArgs e)
        {
            CenterToScreen();
            firstTimePlay.BringToFront();
        }

    }
}
