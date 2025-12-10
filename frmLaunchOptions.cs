// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmLaunchOptions
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
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
  public partial class frmLaunchOptions : Form
  {
    


    public bool optionsCanceled;

    public frmLaunchOptions()
    {
      this.Load += this.LaunchOptions_Load;
      this.optionsCanceled = false;
      this.InitializeComponent();
    }

    



    

    

    private void Button2_Click(object sender, EventArgs e)
    {
      this.optionsCanceled = true;
      this.Close();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.optionsCanceled = false;
      this.Hide();
    }

    private void LaunchOptions_Load(object sender, EventArgs e)
    {
      this.TopMost = true;
      this.Focus();
    }
  }
}