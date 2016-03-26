using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace SequenceAutomation
{
    public partial class ApplicationContainer : Form
    {
        /* 
         * TODO
         * Commmenting
         */

        public KeyboardShortcut shortcut;

        /*
         * Method: ApplicationContainer()
         * Summary: Class constructor
         */
        public ApplicationContainer()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CenterToScreen();

            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);

            // Initialising the events to their appropriate methods
            loginUserControl.CreateButtonEvent += gotoCreateTutorialSelect;
            loginUserControl.PlayButtonEvent += gotoPlayTutorialSelect;

            createRecUserControl.BackButtonEvent += returnToLogin;
            createRecUserControl.ShowTutorialEvent += gotoStartRec;

            playRecUserControl.BackButtonEvent += returnToLogin;
            playRecUserControl.TutorialEvent += gotoPlayTutorial;
            playRecUserControl.gotoLoginEvent += returnToLogin;

            firstTimePlay.YesTutorialEvent += gotoPlayTutorial;
            firstTimePlay.NoTutorialEvent += gotoPlay;

            tutorialSelectRec.goBackEvent += returnToLogin;
            tutorialSelectRec.goNextEvent += new EventHandler<TextEventArgs>(gotoPlayRec);
            tutorialSelectRec.gotoLoginEvent += returnToLogin;

            tutorialPlayRec.goBackEvent += new EventHandler<TextEventArgs>(gotoSelectRec);
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

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void gotoUploadRec(object sender, TextEventArgs e)
        {
            if (e.json != "")
                tutorialUploadRec.recJson = e.json;
            ClientSize = new Size(1065, 719);
            tutorialUploadRec.checkLogin();
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
            if (e.json != "")
                tutorialTestRec.mergedJson = e.json;

            ClientSize = new Size(961, 505);
            tutorialTestRec.BringToFront();
            CenterToScreen();
        }

        private void gotoPlayRec(object sender, TextEventArgs e)
        {
            if (e.json != "")
            {
                RecordingManager recording = new RecordingManager(e.json);
                tutorialPlayRec.recJson = e.json;
                tutorialPlayRec.currentRecTitle.Text = recording.Title;
                tutorialPlayRec.recTitle = e.name;
            }
            ClientSize = new Size(1325, 522);
            tutorialPlayRec.BringToFront();
            CenterToScreen();
        }

        private void gotoSelectRec(object sender, EventArgs e)
        {
            tutorialSelectRec.prepareList();
            ClientSize = new Size(1168, 690);
            tutorialSelectRec.BringToFront();
            CenterToScreen();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;
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
        private void gotoPlay(object sender, EventArgs e)
        {
            playRecUserControl.prepareList();
            playRecUserControl.BringToFront();
            ClientSize = new Size(1270, 680);
            CenterToScreen();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;
        }

        /* 
        * Method: gotoCreate()
        * Summary: Brings up the create recording menu by bringing it to the front of the view
        * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
        */
        private void gotoCreate(object sender, EventArgs e)
        {
            createRecUserControl.BringToFront();
            createRecUserControl.checkLogin();
            ClientSize = new Size(1208, 612);
            CenterToScreen();
        }

        private void gotoPlayTutorial(object sender, EventArgs e)
        {
            tutorialSelectRec.prepareList();
            ClientSize = new Size(1168, 690);
            tutorialSelectRec.BringToFront();
            CenterToScreen();
        }


        private void gotoPlayTutorialSelect(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.playRemember)
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
            if (Properties.Settings.Default.createRemember)
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
