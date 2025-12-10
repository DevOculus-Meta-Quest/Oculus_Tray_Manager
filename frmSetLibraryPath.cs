// Decompiled with JetBrains decompiler

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