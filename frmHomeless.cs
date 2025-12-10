// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmHomeless
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
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmHomeless : Form
  {
    

    public frmHomeless() => this.InitializeComponent();

    


    

    

    

    



    


    



    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void Button3_Click(object sender, EventArgs e)
    {
      if (this.ColorDialog1.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.TextBox1.BackColor = this.ColorDialog1.Color;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        Color backColor = this.TextBox1.BackColor;
        float num1 = (float) Math.Round((double) backColor.R / (double) byte.MaxValue, 2);
        float num2 = (float) Math.Round((double) backColor.G / (double) byte.MaxValue, 2);
        float num3 = (float) Math.Round((double) backColor.B / (double) byte.MaxValue, 2);
        string str = num1.ToString().Replace(",", ".") + " " + num2.ToString().Replace(",", ".") + " " + num3.ToString().Replace(",", ".");
        StreamWriter streamWriter1 = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
        streamWriter1.WriteLine(str);
        streamWriter1.Close();
        Log.WriteToLog("Homeless background color set to " + str);
        if (Operators.CompareString(this.ComboMusic.Text, "None", false) != 0)
        {
          if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + this.ComboMusic.Text))
          {
            StreamWriter streamWriter2 = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
            streamWriter2.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString().Replace("\\", "\\\\") + "\\\\OculusTrayTool\\\\Music\\\\" + this.ComboMusic.Text + "," + Conversions.ToString(Decimal.Multiply(this.NumericVolume.Value, 10M)));
            streamWriter2.Close();
            Log.WriteToLog("Homeless background music set to " + this.ComboMusic.Text);
            Log.WriteToLog("Homeless background volume set to " + Conversions.ToString(this.NumericVolume.Value) + "%");
          }
        }
        else if (File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt"))
        {
          File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
          Log.WriteToLog("Homeless background music disabled");
        }
        MySettingsProperty.Settings.HomlessColor = str;
        MySettingsProperty.Settings.HomelessVolume = Convert.ToInt32(Decimal.Multiply(this.NumericVolume.Value, 10M));
        MySettingsProperty.Settings.Save();
        if (Process.GetProcessesByName("OculusClient").Length > 0)
        {
          Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
          if (processesByName.Length > 0)
          {
            Log.WriteToLog("Killing Home2-Win64-Shipping.exe");
            Process[] processArray = processesByName;
            int index = 0;
            while (index < processArray.Length)
            {
              Process process = processArray[index];
              process.Kill();
              process.WaitForExit();
              checked { ++index; }
            }
          }
          Thread.Sleep(1000);
          if (Process.GetProcessesByName("Home2-Win64-Shipping").Length == 0)
          {
            Log.WriteToLog("Restarting Home2-Win64-Shipping.exe");
            Process.Start(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
          }
        }
        this.Cursor = Cursors.Default;
        this.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Could save settings: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Could save settings: " + exception.Message), MsgBoxStyle.Critical, (object) "Error saving settings");
        ProjectData.ClearProjectError();
      }
    }

    private void BtnBrowseMusic_Click(object sender, EventArgs e)
    {
      try
      {
        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
        {
          Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
          Log.WriteToLog("Created " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = true;
        openFileDialog.Filter = "MP3 Music (*.mp3)|*.mp3";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        string text = this.ComboMusic.Text;
        string[] fileNames = openFileDialog.FileNames;
        int index1 = 0;
        while (index1 < fileNames.Length)
        {
          string str = fileNames[index1];
          File.Copy(str, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + Path.GetFileName(str).Replace(" ", ""));
          Log.WriteToLog("Copied " + str + " to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
          checked { ++index1; }
        }
        if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
        {
          this.ComboMusic.Items.Clear();
          string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
          int index2 = 0;
          while (index2 < files.Length)
          {
            this.ComboMusic.Items.Add((object) Path.GetFileName(files[index2]));
            checked { ++index2; }
          }
        }
        this.ComboMusic.Items.Add((object) "None");
        this.ComboMusic.Text = text;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Could not add music file: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Could not add music file: " + exception.Message), MsgBoxStyle.Critical, (object) "Error adding music");
        ProjectData.ClearProjectError();
      }
    }

    private void ComboMusic_SelectedIndexChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.HomelessMusic = this.ComboMusic.Text;
      MySettingsProperty.Settings.Save();
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.HomelessAutoPatch = this.CheckBox1.Checked;
      MySettingsProperty.Settings.Save();
    }
  }
}