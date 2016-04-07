using System;
using System.Drawing;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public class SearchBox : TextBox
    {
        private static Font SearchTextFont;

        public SearchBox()
        {
            Initialize();
        }

        private void Initialize()
        {
            SearchTextFont = new Font("Segoe UI", 16, FontStyle.Italic);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x00f)
            {
                base.WndProc(ref m);
                Graphics graphic = CreateGraphics();
                OnPaint(new PaintEventArgs(graphic, ClientRectangle));
                graphic.Dispose();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Graphics graphic = CreateGraphics();
            OnPaint(new PaintEventArgs(graphic, ClientRectangle));
            graphic.Dispose();
            base.OnTextChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.Text.Equals(""))
            {
                SetStyle(ControlStyles.UserPaint, true);
                e.Graphics.DrawString("Search for a recording", SearchTextFont, Brushes.Gray, 0, 0);
            }
            else
            {
                SetStyle(ControlStyles.UserPaint, false);
            }
        }
    }
}