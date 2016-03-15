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
    public partial class AccountContainer : Form
    {
        public AccountContainer()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CenterToScreen();

            options.GoBackEvent += close;
            options.LoginEvent += gotoLogin;
            options.RegisterEvent += gotoRegister;

            register1.GoBackEvent += gotoOptions;
            register1.RegisterEvent += gotoOptions;

            login1.GoBackEvent += gotoOptions;
            login1.LoginEvent += close;
        }

        private void gotoOptions(object sender, EventArgs e)
        {
            options.BringToFront();
            ClientSize = new Size(860, 458);
            CenterToScreen();
        }

        private void gotoRegister(object sender, EventArgs e)
        {
            register1.BringToFront();
            ClientSize = new Size(628, 723);
            CenterToScreen();
        }

        private void gotoLogin(object sender, EventArgs e)
        {
            login1.BringToFront();
            ClientSize = new Size(515, 415);
            CenterToScreen();
        }

        private void close(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
