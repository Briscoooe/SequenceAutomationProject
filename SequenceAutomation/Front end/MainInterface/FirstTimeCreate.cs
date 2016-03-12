using System;
using System.Windows.Forms;

namespace SequenceAutomation.Interface
{
    public partial class FirstTimeCreate : UserControl
    {
        /* 
         * TODO
         * Commmenting
         */
        public event EventHandler YesTutorialEvent;
        public event EventHandler NoTutorialEvent;

        public FirstTimeCreate()
        {
            InitializeComponent();
        }

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
