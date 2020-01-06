﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace CHK
{
    public partial class GameForm : Form
    {
        private const int WindowDockingDelay = 27000;

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
            Thread.Sleep(WindowDockingDelay);
            SetParent(process.MainWindowHandle, Handle);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                Application.Exit();
        }
    }
}
