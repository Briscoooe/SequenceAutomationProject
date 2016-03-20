using System;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class RecStatus : Form
    {
        public RecStatus()
        {
            InitializeComponent();
        }

        private void showMessage(object sender, EventArgs e)
        {
            BigMessageBox.Show("Test");
        }
    }
}
