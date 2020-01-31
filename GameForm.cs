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
            if(Keys.J == e.KeyCode)
            {
                Random Rnd = new Random();
                Cursor.Position = new Point(Rnd.Next(1013, 1065), Rnd.Next(215,268));
            }
            if (Keys.H == e.KeyCode)
            {
                StartBot();
            }

        }

        
        private void StartBot()
        {
            Random Rnd = new Random();
            //Takes lobsters from bank
            Cursor.Position = new Point(Rnd.Next(1013, 1065), Rnd.Next(215,268));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            
            //Walks to top floor staircase
            Cursor.Position = new Point(Rnd.Next(1570,1580), Rnd.Next(301,310));
            DoMouseClick();
            //wait 10-11s while character walks to stairs 
            System.Threading.Thread.Sleep(Rnd.Next(10000,11000));

            //Clicks Topstair
            Cursor.Position = new Point(Rnd.Next(608,661), Rnd.Next(408,441));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            //Moves Cursor to middlestair
            Cursor.Position = new Point(Rnd.Next(605,658), Rnd.Next(332,384));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            //Moves cursor to "down" dialogue box
            Cursor.Position = new Point(Rnd.Next(463,820), Rnd.Next(904,930));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            //Moves cursor to cooking range
            Cursor.Position = new Point(Rnd.Next(888,903),Rnd.Next(476,534));
            HumanReaction();
            DoMouseClick();
            //Wait for character to walk to range
            System.Threading.Thread.Sleep(Rnd.Next(10000,11000));

            //Clicks cook lobster
            Cursor.Position = new Point(Rnd.Next(521,758), Rnd.Next(837,980));
            HumanReaction();
            DoMouseClick();
            //wait for lobster to cook
            System.Threading.Thread.Sleep(Rnd.Next(30000,31000));

            //Walks back to staircase
            Cursor.Position = new Point(Rnd.Next(1514,1517), Rnd.Next(261,264));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            //Moves Cursor to bottomstair
            Cursor.Position = new Point(Rnd.Next(605,658), Rnd.Next(332,384));
            DoMouseClick();
            HumanReaction();
            HumanReaction();
            //Moves Cursor to middlestair
            Cursor.Position = new Point(Rnd.Next(605,658), Rnd.Next(332,384));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            //Moves cursor to "up" dialogue box
            Cursor.Position = new Point(Rnd.Next(480, 790), Rnd.Next(837, 871));
            HumanReaction();
            DoMouseClick();
            HumanReaction();
            //Walk to bank
            Cursor.Position = new Point(Rnd.Next(716,719), Rnd.Next(295,301));
            DoMouseClick();
            System.Threading.Thread.Sleep(Rnd.Next(10000,11000));

            //Banks Lobsters
            Cursor.Position = new Point(Rnd.Next(1389,1459), Rnd.Next(476,534));
            HumanReaction();
            DoMouseClick();
            HumanReaction();

            //Restart Bot
            StartBot();
            
        }
        //Program waits for human reaction time 
        private void HumanReaction()
        {
            Random r = new Random();
            int Reaction = r.Next(2000, 3000);
            System.Threading.Thread.Sleep(Reaction);
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
