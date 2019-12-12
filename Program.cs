using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1TESTING
{
    static class Program
    {
        private const string Runelite = "C:\\Users\\Nathaniel\\AppData\\Local\\RuneLite\\RuneLite.exe";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm(Runelite));
        }
    }
}
