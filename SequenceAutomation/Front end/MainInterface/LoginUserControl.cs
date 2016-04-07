using System;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class LoginUserControl : UserControl
    {
        // The event handlers for the buttons
        public event EventHandler CreateButtonEvent;
        public event EventHandler PlayButtonEvent;

        public LoginUserControl()
        {
            InitializeComponent();
        }

        // These methods are event handlers for the navigation buttons
        private void gotoCreate(object sender, EventArgs e)
        {
            if (CreateButtonEvent != null)
                CreateButtonEvent(this, new EventArgs());
        }

        private void gotoPlay(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (PlayButtonEvent != null)
                PlayButtonEvent(this, e);
        }
    }
}
