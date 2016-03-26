using System;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class BigMessageBox : Form
    {
        static BigMessageBox newMessageBox;

        public BigMessageBox()
        {
            InitializeComponent();
        }

        public static void Show(string txtMessage)
        {
            newMessageBox = new BigMessageBox();
            newMessageBox.messageBody.Text = txtMessage;
            newMessageBox.ShowDialog();
        }

        private void Close(object sender, EventArgs e)
        {
            newMessageBox.Dispose();
        }
    }
}