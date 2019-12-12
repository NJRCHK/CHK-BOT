using System;
using System.Windows.Forms;

namespace CHK
{
    static class Program
    {
        private const string NateRunelightPath = "C:\\Users\\Nathaniel\\AppData\\Local\\RuneLite\\RuneLite.exe";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string programPath = Microsoft.VisualBasic.Interaction.InputBox("Enter Runelight Path:", "CHK-BOT");
            try
            {
                Application.Run(new GameForm(programPath));
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    Application.Run(new GameForm(NateRunelightPath));
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Microsoft.VisualBasic.Interaction.MsgBox("Error: Runelight not found at: " + programPath);
                }
            }
        }
    }
}
