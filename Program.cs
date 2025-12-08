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
            try
            {
                Application.Run(new FrmMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error at startup: " + ex.ToString(), "Oculus Tray Tool Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
