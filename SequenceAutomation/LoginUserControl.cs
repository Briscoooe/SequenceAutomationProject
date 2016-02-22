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
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        public void gotoPlay(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void gotoCreate(object sender, EventArgs e)
        {
            Hide();
            CreateRecUserControl rec = new CreateRecUserControl();
            rec.Show();
        }
    }
}
