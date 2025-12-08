using System.Windows.Forms;
using System;

namespace OculusTrayTool
{
    public partial class FrmMain
    {
        // Ensuring ListBox1 exists if not already defined
        // public System.Windows.Forms.ListBox ListBox1; // Commented out to avoid conflict if it exists privately



        public void LoadVoiceSettings()
        {
            // Stub implementation
            if (Globals.dbg) Log.WriteToLog("LoadVoiceSettings called");
        }

        public string GetCurrentResolution()
        {
            // Stub implementation
            return "1920x1080"; 
        }

        public void ShowForm()
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }
    }
}
