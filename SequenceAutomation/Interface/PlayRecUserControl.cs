using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class PlayRecUserControl : UserControl
    {
        public event EventHandler BackButtonEvent;

        public PlayRecUserControl()
        {
            InitializeComponent();
        }

        public void goBack(object sender, EventArgs e)
        {
            if (BackButtonEvent != null)
                BackButtonEvent(this, e);
        }
    }
}
