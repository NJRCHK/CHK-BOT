using System;
using System.Windows.Forms;

namespace CHK
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string ProgramPath = Microsoft.VisualBasic.Interaction.InputBox("Enter Runelight Path:", "CHK-BOT");
            try
            {
                Application.Run(new GameForm(ProgramPath));
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Error: RuneLite not found at: " + ProgramPath);
            }
        }
    }
}
