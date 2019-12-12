using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace WindowsFormsApp1TESTING
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
            SetParent(process.MainWindowHandle, this.Handle);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.K)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
