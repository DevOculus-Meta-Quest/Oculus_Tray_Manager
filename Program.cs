using System;
using System.Windows.Forms;

namespace OculusTrayTool
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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
