// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmAbout
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmAbout : Form
  {
    
    private Resizer rs;

    public frmAbout()
    {
      this.Load += this.readme_Load;
      this.rs = new Resizer();
      this.InitializeComponent();
    }

    

    

    

    

    

    

    


    

    [DllImport("user32.dll")]
    private static extern bool HideCaret(IntPtr hWnd);

    private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void readme_Load(object sender, EventArgs e) => this.PictureBox1.Focus();

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Application.StartupPath + "\\User Guide.pdf"))
        return;
      Process.Start(Application.StartupPath + "\\User Guide.pdf");
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmDonate.ShowDialog();
      this.Close();
    }

    private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("https://apollyonvr.com");
    }
  }
}