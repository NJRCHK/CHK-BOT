using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
namespace CHK
{
    public partial class GameForm : Form
    {
        Random Rnd = new Random();
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
                DoMouseClick(0,1);
            }
            if(Keys.J == e.KeyCode)
            {
                Random Rnd = new Random();
                Cursor.Position = new Point(Rnd.Next(1013, 1065), Rnd.Next(215,268));
            }
            if (Keys.H == e.KeyCode)
            {
                whlie(true)
                {
                    Thread t = new Thread(StartBot);
                    t.IsBackground = true;
                    t.Start();
                }
            }

        }

        
        private void StartBot()
        {
            

            
            
            //Takes lobsters from bank
            Cursor.Position = new Point(Rnd.Next(1013, 1065), Rnd.Next(215,268));
            DoMouseClick(500,1000);

            //Walks to gate
            Cursor.Position = new Point(Rnd.Next(1430, 1432), Rnd.Next(131,134));
            DoMouseClick(15000,16000);

            //Click gate or stand still
            Cursor.Position = new Point(Rnd.Next(613, 642), Rnd.Next(414,415));
            DoMouseClick(3000,4000);
            
            //Click door
            Cursor.Position = new Point(Rnd.Next(579, 677), Rnd.Next(564,565));
            //DoMouseClick(2000,3000);
            
            //Walk inside
            Cursor.Position = new Point(Rnd.Next(630, 652), Rnd.Next(444,450));
            DoMouseClick(3000,4000);

            //Click Range
            Cursor.Position = new Point(Rnd.Next(529, 551), Rnd.Next(360,375));
            DoMouseClick(1000,2000);
        
            //Clicks cook lobster
            Cursor.Position = new Point(Rnd.Next(521,758), Rnd.Next(837,980));
            DoMouseClick(80000,81000);
            //wait for lobster to cook

            //walk back to bank
            Cursor.Position = new Point(Rnd.Next(1706,1711), Rnd.Next(245,248));
            DoMouseClick(10000,11000);

            //click bank
            Cursor.Position = new Point(Rnd.Next(831,862), Rnd.Next(407,436));
            DoMouseClick(2000,3000);
            
            //Banks Lobsters
            Cursor.Position = new Point(Rnd.Next(1389,1459), Rnd.Next(476,534));
            DoMouseClick(1000,2000);

            
  
            }  
        

        public void DoMouseClick(int MinWait, int MaxWait)
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            Thread.Sleep(Rnd.Next(MinWait,MaxWait));
        }

  
    }
}
