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
    public partial class FirstTimePlay : UserControl
    {
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
            if (NoTutorialEvent != null)
                NoTutorialEvent(this, e);
        }
    }
}
