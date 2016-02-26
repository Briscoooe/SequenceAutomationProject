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
    public partial class TutorialSelectRec : UserControl
    {
        public event EventHandler goBackEvent;
        public event EventHandler goNextEvent;

        public TutorialSelectRec()
        {
            InitializeComponent();
        }

        private void goNext(object sender, EventArgs e)
        {
            if (goNextEvent != null)
                goNextEvent(this, e);
        }

        private void goBack(object sender, EventArgs e)
        {
            if (goBackEvent != null)
                goBackEvent(this, e);
        }
    }
}
