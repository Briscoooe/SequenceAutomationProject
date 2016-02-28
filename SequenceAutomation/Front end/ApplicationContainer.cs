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
            loginUserControl.CreateButtonEvent += gotoCreateTutorialSelect;
            loginUserControl.PlayButtonEvent += gotoPlayTutorialSelect;

            createRecUserControl.BackButtonEvent += returnToLogin;
            createRecUserControl.ShowTutorialEvent += gotoStartRec;

            playRecUserControl.BackButtonEvent += returnToLogin;
            playRecUserControl.TutorialEvent += gotoPlayTutorial;

            firstTimePlay.YesTutorialEvent += gotoPlayTutorial;
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

            firstTimeCreate.YesTutorialEvent += gotoStartRec;
            firstTimeCreate.NoTutorialEvent += gotoCreate;

            tutorialStartRec.goBackEvent += returnToLogin;
            tutorialStartRec.goNextEvent += new EventHandler<TextEventArgs>(gotoTestRec);
            tutorialStartRec.gotoLoginEvent += returnToLogin;

            tutorialTestRec.goBackEvent += gotoStartRec;
            tutorialTestRec.goNextEvent += new EventHandler<TextEventArgs>(gotoUploadRec);
            tutorialTestRec.gotoLoginEvent += returnToLogin;

            tutorialUploadRec.goBackEvent += new EventHandler<TextEventArgs>(gotoTestRec);
            tutorialUploadRec.goNextEvent += gotoCreate;
            tutorialUploadRec.gotoLoginEvent += returnToLogin;


        }

        private void gotoUploadRec(object sender, TextEventArgs e)
        {
            if (e.json != "")
                tutorialUploadRec.mergedJson = e.json;
            ClientSize = new Size(1065, 719);
            tutorialUploadRec.BringToFront();
            CenterToScreen();
        }

        private void gotoStartRec(object sender, EventArgs e)
        {
            tutorialStartRec.reset();
            ClientSize = new Size(961, 505);
            tutorialStartRec.BringToFront();
            CenterToScreen();
        }

        private void gotoTestRec(object sender, TextEventArgs e)
        {
            if(e.json != "")
                tutorialTestRec.mergedJson = e.json;

            ClientSize = new Size(961, 505);
            tutorialTestRec.BringToFront();
            CenterToScreen();
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
            ClientSize = new Size(1208, 612);
            CenterToScreen();
        }

        private void gotoPlayTutorial(object sender, EventArgs e)
        {
            ClientSize = new Size(990, 530);
            tutorialSelectRec.BringToFront();
            CenterToScreen();
        }


        private void gotoPlayTutorialSelect(object sender, EventArgs e)
        {
            if (firstTimePlay.rememberSelection)
            {
                gotoPlay(sender, e);
            }

            else
            {
                firstTimePlay.BringToFront();
                CenterToScreen();
            }
        }

        private void gotoCreateTutorialSelect(object sender, EventArgs e)
        {
            if (firstTimeCreate.rememberSelection)
            {
                gotoCreate(sender, e);
            }

            else
            {
                firstTimeCreate.BringToFront();
                CenterToScreen();
            }
        }

    }
}
