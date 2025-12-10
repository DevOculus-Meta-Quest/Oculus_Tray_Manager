// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmRemoveProgress
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
  public partial class frmRemoveProgress : Form
  {
    

    public frmRemoveProgress()
    {
      this.Load += this.RemoveProgress_Load;
      this.InitializeComponent();
    }

    


    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void RemoveProgress_Load(object sender, EventArgs e)
    {
      CenterForms.CenterForm((Form) this, (Form) MyProject.Forms.frmLibrary);
    }
  }
}