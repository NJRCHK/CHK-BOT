using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace CHK
{
    public partial class GameForm : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        
        public GameForm(string runelightPath)
        {
            InitializeComponent();
            var process = new Process
            {
                StartInfo = { FileName = runelightPath }
            };
            process.Start();
            Thread.Sleep(27000);
            SetParent(process.MainWindowHandle, Handle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.K)
            {
                Application.Exit();
            }
        }
    }
}
