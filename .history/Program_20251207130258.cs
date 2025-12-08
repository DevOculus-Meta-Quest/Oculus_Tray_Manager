using System;
using System.Windows.Forms;

namespace OculusTrayTool
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
            // We need to resolve how to access the main form. 
            // For now, let's instantiate it directly, assuming FrmMain exists.
            // We might need to setup the 'My.Forms' singleton replacement here if we want to keep that pattern.
            Application.Run(new FrmMain()); 
        }
    }
}
