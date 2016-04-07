using System;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class FirstTimePlay : UserControl
    {
        // The event handlers for the buttons
        public event EventHandler YesTutorialEvent;
        public event EventHandler NoTutorialEvent;

        public FirstTimePlay()
        {
            InitializeComponent();
        }

        // These methods are event handlers for the navigation buttons
        private void gotoTutorial(object sender, EventArgs e)
        {
            if (YesTutorialEvent != null)
                YesTutorialEvent(this, new EventArgs());
        }


        private void gotoPlay(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (NoTutorialEvent != null)
                NoTutorialEvent(this, e);
        }

        /*
         * Method: checkChanged()
         * Summary: Checks to see if the user has selected the "Don't show this again" check box
         */
        private void checkChanged(object sender, EventArgs e)
        {
            if(rememberChoiceBtn.Checked)
            {
                Properties.Settings.Default.playRemember = true;
            }

            else
            {
                Properties.Settings.Default.playRemember = false;
            }
        }
    }
}
