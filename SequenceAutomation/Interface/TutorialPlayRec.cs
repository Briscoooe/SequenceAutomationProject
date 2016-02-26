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
    public partial class TutorialPlayRec : UserControl
    {
        public event EventHandler goBackEvent;
        public event EventHandler gotoPlayEvent;

        public TutorialPlayRec()
        {
            InitializeComponent();
        }

        private void gotoPlay(object sender, EventArgs e)
        {
            if (gotoPlayEvent != null)
                gotoPlayEvent(this, e);
        }

        private void goBack(object sender, EventArgs e)
        {
            if (goBackEvent != null)
                goBackEvent(this, e);
        }
    }
}
