using System;
using System.Windows.Forms;

namespace SequenceAutomation.Interface
{
    public partial class FirstTimeCreate : UserControl
    {
        // The event handlers for the buttons
        public event EventHandler YesTutorialEvent;
        public event EventHandler NoTutorialEvent;

        public FirstTimeCreate()
        {
            InitializeComponent();
        }

        // These methods are event handlers for the navigation buttons
        private void gotoTutorial(object sender, EventArgs e)
        {
            if (YesTutorialEvent != null)
                YesTutorialEvent(this, new EventArgs());
        }


        private void gotoCreate(object sender, EventArgs e)
        {
            if (NoTutorialEvent != null)
                NoTutorialEvent(this, e);
        }

        /*
         * Method: checkChanged()
         * Summary: 
         */
        private void checkChanged(object sender, EventArgs e)
        {
            if (rememberChoiceBtn.Checked)
            {
                Properties.Settings.Default.createRemember = true;
            }

            else
            {
                Properties.Settings.Default.createRemember = false;
            }
        }
    }
}
