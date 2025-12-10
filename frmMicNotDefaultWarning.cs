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