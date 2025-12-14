

using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool.Forms
{

  public partial class FrmSetFallback : Form
  {
    
    public Dictionary<string, string> ComboAudioFallbackSource;
    public Dictionary<string, string> ComboMicFallbackSource;

    public FrmSetFallback()
    {
      this.Load += this.SetFallback_Load;
      this.ComboAudioFallbackSource = new Dictionary<string, string>();
      this.ComboMicFallbackSource = new Dictionary<string, string>();
      this.InitializeComponent();
    }

    

    

    

    

    





    

    


    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    private void Button1_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.ComboBox6.SelectedItem != null)
        {
          if (String.Equals(this.ComboBox6.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.SetAudioOnStart = Convert.ToString(GetDevices.GetDefaultAudioDeviceName());
            MySettingsProperty.Settings.SetAudioOnStartGuid = Convert.ToString(GetDevices.GetDefaultAudioDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart.ToString() + "' as current default audio device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox6.SelectedItem).Key;
            MySettingsProperty.Settings.SetAudioOnStart = ((KeyValuePair<string, string>) this.ComboBox6.SelectedItem).Value;
            MySettingsProperty.Settings.SetAudioOnStartGuid = key;
          }
        }
        if (this.ComboAudioFallback.SelectedItem != null)
        {
          if (String.Equals(this.ComboAudioFallback.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.DefaultAudio = Convert.ToString(GetDevices.GetDefaultAudioDeviceName());
            MySettingsProperty.Settings.SystemDefaultAudioGuid = Convert.ToString(GetDevices.GetDefaultAudioDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultAudio + "' as current default audio device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboAudioFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultAudio = ((KeyValuePair<string, string>) this.ComboAudioFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultAudioGuid = key;
          }
        }
        if (this.ComboBox5.SelectedItem != null)
        {
          if (String.Equals(this.ComboBox5.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.SetMicOnStart = Convert.ToString(GetDevices.GetDefaultMicDeviceName());
            MySettingsProperty.Settings.SetMicOnStartGuid = Convert.ToString(GetDevices.GetDefaultMicDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetMicOnStart + "' as current default mic device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox5.SelectedItem).Key;
            MySettingsProperty.Settings.SetMicOnStart = ((KeyValuePair<string, string>) this.ComboBox5.SelectedItem).Value;
            MySettingsProperty.Settings.SetMicOnStartGuid = key;
          }
        }
        if (this.ComboMicFallback.SelectedItem != null)
        {
          if (String.Equals(this.ComboMicFallback.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.DefaultMic = Convert.ToString(GetDevices.GetDefaultMicDeviceName());
            MySettingsProperty.Settings.SystemDefaultMicGuid = Convert.ToString(GetDevices.GetDefaultMicDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultMic + "' as current default mic device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboMicFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultMic = ((KeyValuePair<string, string>) this.ComboMicFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultMicGuid = key;
          }
        }
        if (this.ComboBox4.SelectedItem != null)
        {
          if (String.Equals(this.ComboBox4.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.SetAudioCommOnStart = Convert.ToString(GetDevices.GetDefaultAudioCommDeviceName());
            MySettingsProperty.Settings.SetAudioCommOnStartGuid = Convert.ToString(GetDevices.GetDefaultAudioCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioCommOnStart + "' as current default audio comm device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox4.SelectedItem).Key;
            MySettingsProperty.Settings.SetAudioCommOnStart = ((KeyValuePair<string, string>) this.ComboBox4.SelectedItem).Value;
            MySettingsProperty.Settings.SetAudioCommOnStartGuid = key;
          }
        }
        if (this.ComboCommFallback.SelectedItem != null)
        {
          if (String.Equals(this.ComboCommFallback.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.DefaultCommAudio = Convert.ToString(GetDevices.GetDefaultAudioCommDeviceName());
            MySettingsProperty.Settings.SystemDefaultCommAudioGuid = Convert.ToString(GetDevices.GetDefaultAudioCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultCommAudio + "' as current default audio comm device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboCommFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultCommAudio = ((KeyValuePair<string, string>) this.ComboCommFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultCommAudioGuid = key;
          }
        }
        if (this.ComboBox3.SelectedItem != null)
        {
          if (String.Equals(this.ComboBox3.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.SetMicCommOnStart = Convert.ToString(GetDevices.GetDefaultMicCommDeviceName());
            MySettingsProperty.Settings.SetMicCommOnStartGuid = Convert.ToString(GetDevices.GetDefaultMicCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart + "' as current mic comm device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox3.SelectedItem).Key;
            MySettingsProperty.Settings.SetMicCommOnStart = ((KeyValuePair<string, string>) this.ComboBox3.SelectedItem).Value;
            MySettingsProperty.Settings.SetMicCommOnStartGuid = key;
          }
        }
        if (this.ComboCommMicFallback.SelectedItem != null)
        {
          if (String.Equals(this.ComboCommFallback.Text, "Use current default", StringComparison.OrdinalIgnoreCase))
          {
            MySettingsProperty.Settings.DefaultComm = Convert.ToString(GetDevices.GetDefaultMicCommDeviceName());
            MySettingsProperty.Settings.SystemDefaultCommGuid = Convert.ToString(GetDevices.GetDefaultMicCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultComm + "' as current mic comm device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboCommMicFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultComm = ((KeyValuePair<string, string>) this.ComboCommMicFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultCommGuid = key;
          }
        }
        MySettingsProperty.Settings.Save();
        if (!String.Equals(MySettingsProperty.Settings.DefaultAudio, null, StringComparison.OrdinalIgnoreCase) & !String.Equals(MySettingsProperty.Settings.DefaultMic, null, StringComparison.OrdinalIgnoreCase))
        {
          MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = true;
        }
        else
        {
          MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = false;
          MyProject.Forms.FrmMain.ToolStripMenuItem3.ToolTipText = "No fallback devices has been selected in the AudioSwitcher configuration";
        }
      }
      catch (Exception ex)
      {
        //ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Error setting Audio fallback device: " + exception.Message);
        int num = (int) MessageBox.Show("Error setting Audio fallback device: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //ProjectData.ClearProjectError();
      }
      this.Close();
    }

    private void SetFallback_Load(object sender, EventArgs e)
    {
      GetDevices.GetAllAudioDevices();
      GetDevices.GetAllMicDevices();
      GetConfig.IsReading = true;
      this.ComboBox1.SelectedIndex = MySettingsProperty.Settings.SetRiftAudioDefault;
      this.ComboBox2.SelectedIndex = MySettingsProperty.Settings.SetRiftMicDefault;
      this.ComboAudioFallback.Text = MySettingsProperty.Settings.DefaultAudio;
      this.ComboMicFallback.Text = MySettingsProperty.Settings.DefaultMic;
      this.ComboCommFallback.Text = MySettingsProperty.Settings.DefaultCommAudio;
      this.ComboCommMicFallback.Text = MySettingsProperty.Settings.DefaultComm;
      this.ComboBox3.Text = MySettingsProperty.Settings.SetMicCommOnStart;
      this.ComboBox4.Text = MySettingsProperty.Settings.SetAudioCommOnStart;
      this.ComboBox5.Text = MySettingsProperty.Settings.SetMicOnStart;
      this.ComboBox6.Text = MySettingsProperty.Settings.SetAudioOnStart;
      GetConfig.IsReading = false;
      MyProject.Forms.FrmMain.Cursor = Cursors.Default;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      Log.WriteToLog("Resetting AudioSwitcher settings..");
      GetConfig.IsReading = true;
      this.Cursor = Cursors.WaitCursor;
      this.ComboAudioFallback.Text = "";
      this.ComboMicFallback.Text = "";
      this.ComboCommFallback.Text = Convert.ToString(this.ComboBox1.SelectedIndex == 0);
      this.ComboBox2.SelectedIndex = 0;
      GetConfig.IsReading = false;
      MySettingsProperty.Settings.DefaultAudio = (string) null;
      MySettingsProperty.Settings.DefaultMic = (string) null;
      MySettingsProperty.Settings.DefaultComm = (string) null;
      MySettingsProperty.Settings.DefaultCommAudio = (string) null;
      MySettingsProperty.Settings.SystemDefaultAudioGuid = (string) null;
      MySettingsProperty.Settings.SystemDefaultMicGuid = (string) null;
      MySettingsProperty.Settings.SystemDefaultCommGuid = (string) null;
      MySettingsProperty.Settings.RiftMicGuid = (string) null;
      MySettingsProperty.Settings.RiftAudioGuid = (string) null;
      MySettingsProperty.Settings.SetMicCommOnStart = (string) null;
      MySettingsProperty.Settings.SetAudioCommOnStart = (string) null;
      MySettingsProperty.Settings.SetMicOnStart = (string) null;
      MySettingsProperty.Settings.SetAudioOnStart = (string) null;
      MySettingsProperty.Settings.SetMicCommOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetAudioCommOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetMicOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetAudioOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetRiftMicDefault = 0;
      MySettingsProperty.Settings.SetRiftAudioDefault = 0;
      MySettingsProperty.Settings.Save();
      GetDevices.GetAllAudioDevices();
      GetDevices.GetAllMicDevices();
      this.Cursor = Cursors.Default;
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.SetRiftAudioDefault = this.ComboBox1.SelectedIndex;
      MySettingsProperty.Settings.Save();
    }

    private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.SetRiftMicDefault = this.ComboBox2.SelectedIndex;
      MySettingsProperty.Settings.Save();
    }

    private void Button3_Click(object sender, EventArgs e) => this.Close();
  }
}
