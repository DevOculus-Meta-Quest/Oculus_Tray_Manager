// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmMicNotDefaultWarning
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
  public partial class frmMicNotDefaultWarning : Form
  {
    

    public frmMicNotDefaultWarning()
    {
      this.Load += new EventHandler(this.frmMicNotDefaultWarning_Load);
      this.InitializeComponent();
    }

    



    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ShowMicNotDefaultWarning = !this.CheckBox1.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void frmMicNotDefaultWarning_Load(object sender, EventArgs e) => this.BringToFront();
  }
}