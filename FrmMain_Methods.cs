using System.Windows.Forms;
using System;
using System.Drawing;
using Microsoft.Win32;

namespace OculusTrayTool
{
    public partial class FrmMain
    {

        public void LoadVoiceSettings()
        {
            if (Globals.dbg) Log.WriteToLog("LoadVoiceSettings called");
        }

        public string GetCurrentResolution()
        {
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


        public void PrintSettings(bool full)
        {
             Log.WriteToLog("PrintSettings stub called. Full: " + full);
        }

        public void OnTimerProfile(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

        public void InstallHomeless()
        {
        }

        public void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
        }

         public void GetOculusLinkValues()
        {
        }
    }
}
