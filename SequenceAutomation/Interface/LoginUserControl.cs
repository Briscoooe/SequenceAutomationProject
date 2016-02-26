using System;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler CreateButtonEvent;
        public event EventHandler PlayButtonEvent;

        public LoginUserControl()
        {
            InitializeComponent();
        }

        private void gotoCreate(object sender, EventArgs e)
        {
            if (CreateButtonEvent != null)
                CreateButtonEvent(this, new EventArgs());
        }

        
        private void gotoPlay(object sender, EventArgs e)
        {
            if (PlayButtonEvent != null)
                PlayButtonEvent(this, e);
        }
    }
}
