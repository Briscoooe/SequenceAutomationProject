using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
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

        public static void Show(string txtMessage, string txtTitle)
        {
            newMessageBox = new BigMessageBox();
            newMessageBox.messageTitle.Text = txtTitle;
            newMessageBox.messageBody.Text = txtMessage;
            newMessageBox.ShowDialog();
        }

        private void Close(object sender, EventArgs e)
        {
            newMessageBox.Dispose();
        }

    }
}