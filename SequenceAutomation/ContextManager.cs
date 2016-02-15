using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAutomation
{
    public class ContextManager
    {
        //public long time;
        //public string openWindowsStr = "open windows";
        //public Dictionary<IntPtr, string> openWindows;
        //public Dictionary<long, Dictionary<IntPtr, string>> openWindows;
        public ContextManager() { }

        public void getContext()
        {
            
        }

        /// References http://www.tcx.be/blog/2006/list-open-windows/
        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
        public Dictionary<IntPtr, string> GetOpenWindows()
        {
            IntPtr shellWindow = GetShellWindow();
            Dictionary <IntPtr, string> windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();

                return true;

            }, 0);

            return windows;
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();
    }
 
}
