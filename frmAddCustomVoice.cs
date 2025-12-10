// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmAddCustomVoice
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
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
  public partial class frmAddCustomVoice : Form
  {
    
    public int id;
    public string VoiceProfileName;
    public string VoiceProfileGameProfile;

    public frmAddCustomVoice() => this.InitializeComponent();

    

    

    

    




    

    




    




    

    

    

    private void Button2_Click(object sender, EventArgs e)
    {
    }

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void TextBoxSeconds_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!((int)e.KeyChar != 8 & (int)e.KeyChar != (int) sbyte.MaxValue & (int)e.KeyChar != 44) || !((int)e.KeyChar < 48 | (int)e.KeyChar > 57))
        return;
      e.Handled = true;
    }
  }
}