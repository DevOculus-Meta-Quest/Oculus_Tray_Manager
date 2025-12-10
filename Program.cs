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
            bool createdNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, "Local\\OculusTrayTool_SingleInstance", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("Oculus Tray Tool is already running!", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
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
}
