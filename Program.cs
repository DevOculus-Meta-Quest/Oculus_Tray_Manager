using System;
using System.Windows.Forms;
using MetaQuestTrayTool.Forms;

namespace MetaQuestTrayTool
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool createdNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, "Local\\MetaQuestTrayTool_SingleInstance", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("Meta Quest Tray Tool is already running!", "Meta Quest Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    Application.Run(new FrmMain());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Critical error at startup: " + ex.ToString(), "Meta Quest Tray Tool Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
