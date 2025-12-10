// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmSSChanged
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
  public partial class frmSSChanged : Form
  {
    

    public frmSSChanged() => this.InitializeComponent();

    


    


    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckBox1.Checked)
        MySettingsProperty.Settings.ShowConfirmRestart = false;
      else
        MySettingsProperty.Settings.ShowConfirmRestart = true;
    }
  }
}