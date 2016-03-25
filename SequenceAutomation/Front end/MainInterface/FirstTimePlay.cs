using System;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class FirstTimePlay : UserControl
    {
        /* 
         * TODO
         * Commmenting
         */
        public event EventHandler YesTutorialEvent;
        public event EventHandler NoTutorialEvent;

        public FirstTimePlay()
        {
            InitializeComponent();
        }

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
