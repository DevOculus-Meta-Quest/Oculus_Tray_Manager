// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmLinkPresets
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
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
  public partial class frmLinkPresets : Form
  {
    

    public frmLinkPresets() => this.InitializeComponent();

    

    



    

    private void Button2_Click(object sender, EventArgs e)
    {
      if (FrmMain.fmain.ComboBox4.FindString(this.TextBox1.Text) >= 0)
      {
        int num = (int) Interaction.MsgBox((object) "A Preset with this name already exists", MsgBoxStyle.Critical, (object) "Preset exists");
        this.TextBox1.Text = "";
      }
      else
      {
        FrmMain.fmain.ComboBox4.Items.Add((object) this.TextBox1.Text);
        FrmMain.fmain.ComboBox4.SelectedIndex = checked (FrmMain.fmain.ComboBox4.Items.Count - 1);
        MyProject.Forms.FrmMain.isCopy = false;
      }
      this.Close();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.isCopy = false;
      this.Close();
    }
  }
}