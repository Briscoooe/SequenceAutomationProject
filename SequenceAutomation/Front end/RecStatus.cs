using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MessageBox.Show("Test");
        }
    }
}
