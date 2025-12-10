// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmStillRunningToast
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

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
  public partial class frmStillRunningToast : Form
  {
    

    public frmStillRunningToast()
    {
      this.Click += this.StillRunningToast_Click;
      this.Load += this.StillRunningToast_Load;
      this.InitializeComponent();
    }

    

    private void StillRunningToast_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ShowStillRunning = false;
      MySettingsProperty.Settings.Save();
      this.Close();
      this.Dispose();
    }

    private void StillRunningToast_Load(object sender, EventArgs e)
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      int x = checked (workingArea.Width - this.Width);
      workingArea = Screen.PrimaryScreen.WorkingArea;
      int y = checked (workingArea.Height - this.Height);
      this.Location = new Point(x, y);
      this.Timer2.Start();
      Application.DoEvents();
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      this.Opacity -= 0.06;
      if (this.Opacity != 0.0)
        return;
      this.Close();
      this.Dispose();
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {
      this.Timer2.Stop();
      this.Timer1.Start();
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ShowStillRunning = false;
      MySettingsProperty.Settings.Save();
    }

    private void Label1_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ShowStillRunning = false;
      MySettingsProperty.Settings.Save();
    }

    private void Label2_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ShowStillRunning = false;
      MySettingsProperty.Settings.Save();
    }
  }
}