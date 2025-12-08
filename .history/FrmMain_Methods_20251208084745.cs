using System.Windows.Forms;
using System;
using System.Drawing; // For Font usage in PrintSettings stub?

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

        // Added to resolve missing method errors
        public void AddToListboxAndScroll(string msg)
        {
             // Stub: Log it since we can't reliably touch the UI control if name is unknown
             Log.WriteToLog("[UI Log]: " + msg);
             // If ListBox1 is the standard name:
             // if (this.ListBox1 != null) { this.ListBox1.Items.Add(msg); this.ListBox1.TopIndex = this.ListBox1.Items.Count - 1; }
        }

        public void PrintSettings(bool full)
        {
             Log.WriteToLog("PrintSettings stub called. Full: " + full);
        }
    }
}
