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


namespace WindowsFormsApp1TESTING
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        private void button2_Click_1(object sender, EventArgs e)
        {
            //To be changed
            Process p = Process.Start("C:\\Users\\Nathaniel\\AppData\\Local\\RuneLite\\RuneLite.exe");
            Thread.Sleep(500);
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.Handle);
        }
        public Form1()
        {
            InitializeComponent();
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
