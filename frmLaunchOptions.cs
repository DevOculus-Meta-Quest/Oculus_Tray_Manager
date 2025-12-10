// Decompiled with JetBrains decompiler

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