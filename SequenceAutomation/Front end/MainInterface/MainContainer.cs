using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class ApplicationContainer : Form
    {
        // Declaring the keyboard shortcut
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

            // Initialise the event handler for the property changed event
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);

            // Initialising the event handlers to their appropriate methods
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

        // This method saved the application settings when they have changed
        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        #region Event handlers

        /*
         * Summary: Each of these methods is an event handler for a button. All navigation between
         * screens in the main application window is controlled by these methods
         * Each of them set the size of the window according to the screen to be displayed and center the screen
         * Some of the methods pass information like JSON strings and other recording information between them
         */
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
            ClientSize = new Size(1000, 697);
            tutorialPlayRec.BringToFront();
            CenterToScreen();
        }

        private void gotoSelectRec(object sender, EventArgs e)
        {
            tutorialSelectRec.prepareList();
            ClientSize = new Size(1294, 690);
            tutorialSelectRec.BringToFront();
            CenterToScreen();
            Cursor.Current = Cursors.Arrow;
        }


        private void returnToLogin(object sender, EventArgs e)
        {
            loginUserControl.BringToFront();
            ClientSize = new Size(990, 530);
            CenterToScreen();
        }

        private void gotoPlay(object sender, EventArgs e)
        {
            playRecUserControl.prepareList();
            playRecUserControl.BringToFront();
            ClientSize = new Size(1270, 680);
            CenterToScreen();
            Cursor.Current = Cursors.Arrow;
        }

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
            ClientSize = new Size(1294, 690);
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
        #endregion

    }
}
