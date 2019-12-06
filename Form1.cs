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
    
    public partial class Form1 : Form
    {
        private const string Runescape = "C:\\Users\\Nathaniel\\AppData\\Local\\RuneLite\\RuneLite.exe";
        private const string Calculator = "calc.exe";
        private const string JagEx = "C:\\Users\\Nathaniel\\jagexcache\\jagexlauncher\\bin\\JagexLauncher.exe";

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        
        public Form1()
        {
            InitializeComponent();
            var process = new Process
            {
                StartInfo = { FileName = Calculator, Arguments = "oldschool" }
            };
            process.Start();
            Thread.Sleep(500);
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
