// Decompiled with JetBrains decompiler

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmStartupType : Form
  {
    

    public frmStartupType() => this.InitializeComponent();

    

    

    

    


    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.RadioButton1.Checked)
      {
        if (MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue(Application.ProductName) == null)
        {
          try
          {
            MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue(Application.ProductName, (object) (Application.StartupPath + "\\OculusTrayTool.exe"));
            MySettingsProperty.Settings.StartWithWindows = true;
            MySettingsProperty.Settings.Save();
            Log.WriteToLog("Enabled 'Start with Windows', startup type' Regular'");
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Log.WriteToLog("Could not enable 'Start with Windows', startup type' Regular': " + ex.Message);
            ProjectData.ClearProjectError();
          }
        }
      }
      if (this.RadioButton2.Checked)
        CreateTask.CreateScheduledTask(true);
      this.Close();
    }
  }
}