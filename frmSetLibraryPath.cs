// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmSetLibraryPath
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
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmSetLibraryPath : Form
  {
    

    public frmSetLibraryPath() => this.InitializeComponent();

    

    


    

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.FolderBrowserDialog1.ShowDialog() != DialogResult.OK)
        return;
      if (Directory.Exists(this.FolderBrowserDialog1.SelectedPath.TrimEnd('\\') + "\\Manifests"))
      {
        if (File.Exists(this.FolderBrowserDialog1.SelectedPath.TrimEnd('\\') + "\\Manifests\\oculus-home.json"))
        {
          int num1 = (int) Interaction.MsgBox((object) "While this path contains a 'Manifests' folder, it is not the correct one. See if there's a subfolder called 'Software' to the folder you selected. If so please select that folder.", MsgBoxStyle.Exclamation, (object) "Invalid Path");
        }
        else
        {
          MySettingsProperty.Settings.LibraryPath = this.FolderBrowserDialog1.SelectedPath.TrimEnd('\\');
          MySettingsProperty.Settings.Save();
          this.Close();
        }
      }
      else
      {
        int num2 = (int) Interaction.MsgBox((object) "Invalid Path: Folder does not contain 'Manifests'", MsgBoxStyle.Exclamation, (object) "Invalid Path");
      }
    }
  }
}