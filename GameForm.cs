using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace CHK
{
    public partial class GameForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private const int WindowDockingDelay = 15000;

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);

        public GameForm(string runelightPath)
        {
            InitializeComponent();
            //Set window to fullscreen
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //TopMost = true;
            //Open RuneLite inside of form
            var process = new Process
            {
                StartInfo = { FileName = runelightPath }
            };
            process.Start();
            Thread.Sleep(WindowDockingDelay);
            SetParent(process.MainWindowHandle, Handle);
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                Application.Exit();
            if(Keys.K == e.KeyCode)
            {
                DoMouseClick();
            }

        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
    }
}
