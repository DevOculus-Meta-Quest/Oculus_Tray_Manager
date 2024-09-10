// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.GetDevices
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class GetDevices
  {
    private static MMDeviceEnumerator devenum = new MMDeviceEnumerator();
    private static MMDeviceCollection AudioDevices;
    private static MMDeviceCollection MicDevices;
    public static int AudioDevCount = 0;
    public static int MicdevCount = 0;

    public static void GetAllAudioDevices()
    {
      try
      {
        Log.WriteToLog("Getting list of available audio devices");
        GetDevices.AudioDevices = GetDevices.devenum.EnumerateAudioEndPoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE);
        GetDevices.AudioDevCount = GetDevices.AudioDevices.Count;
        MyProject.Forms.FrmSetFallback.ComboAudioFallback.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Clear();
        MyProject.Forms.FrmSetFallback.ComboAudioFallback.Items.Clear();
        MyProject.Forms.FrmSetFallback.ComboCommFallback.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboCommFallback.Items.Clear();
        MyProject.Forms.FrmSetFallback.ComboBox4.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboBox4.Items.Clear();
        MyProject.Forms.FrmSetFallback.ComboBox6.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboBox6.Items.Clear();
        if (GetDevices.AudioDevices.Count > 0)
        {
          int num = checked (GetDevices.AudioDevices.Count - 1);
          int index = 0;
          while (index <= num)
          {
            if (GetDevices.AudioDevices[index].Properties[checked (GetDevices.AudioDevices[index].Properties.Count - 3)].Value.ToString().ToLower().Contains("rift"))
            {
              MySettingsProperty.Settings.RiftAudioGuid = GetDevices.AudioDevices[index].ID.ToString();
              MySettingsProperty.Settings.Save();
              Log.WriteToLog("Rift Audio ID: " + GetDevices.AudioDevices[index].ID.ToString().Replace("{", "[").Replace("}", "]"));
            }
            MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Add(GetDevices.AudioDevices[index].ID.ToString(), GetDevices.AudioDevices[index].Properties[checked (GetDevices.AudioDevices[index].Properties.Count - 3)].Value.ToString());
            checked { ++index; }
          }
          if (GetDevices.AudioDevices.Count > 1)
          {
            MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Add("1", "Use current default");
            MyProject.Forms.FrmSetFallback.ComboAudioFallback.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, (string) null);
            MyProject.Forms.FrmSetFallback.ComboAudioFallback.DisplayMember = "Value";
            MyProject.Forms.FrmSetFallback.ComboAudioFallback.ValueMember = "Key";
            MyProject.Forms.FrmSetFallback.ComboCommFallback.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, (string) null);
            MyProject.Forms.FrmSetFallback.ComboCommFallback.DisplayMember = "Value";
            MyProject.Forms.FrmSetFallback.ComboCommFallback.ValueMember = "Key";
            MyProject.Forms.FrmSetFallback.ComboBox4.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, (string) null);
            MyProject.Forms.FrmSetFallback.ComboBox4.DisplayMember = "Value";
            MyProject.Forms.FrmSetFallback.ComboBox4.ValueMember = "Key";
            MyProject.Forms.FrmSetFallback.ComboBox6.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, (string) null);
            MyProject.Forms.FrmSetFallback.ComboBox6.DisplayMember = "Value";
            MyProject.Forms.FrmSetFallback.ComboBox6.ValueMember = "Key";
          }
          else
          {
            MySettingsProperty.Settings.DefaultAudio = "";
            MySettingsProperty.Settings.SystemDefaultAudioGuid = "";
            MySettingsProperty.Settings.SystemDefaultCommAudioGuid = "";
            MySettingsProperty.Settings.Save();
          }
          Log.WriteToLog("Found " + Conversions.ToString(checked (GetDevices.AudioDevices.Count - 1)) + " non-Rift output devices");
        }
        else
        {
          Log.WriteToLog("No enabled audio devices found");
          FrmMain.fmain.AddToListboxAndScroll("No enabled audio devices found");
          MyProject.Forms.FrmMain.hasWarning = true;
          GetConfig.useVoiceCommands = false;
          MyProject.Forms.FrmMain.ComboVoice.SelectedIndex = 0;
          MyProject.Forms.FrmMain.ComboVoice.Enabled = false;
          MyProject.Forms.FrmMain.BtnVoice.Enabled = false;
          MySettingsProperty.Settings.DefaultAudio = "";
          MySettingsProperty.Settings.SystemDefaultAudioGuid = "";
          MySettingsProperty.Settings.Save();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetAllAudioDevices: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void GetAllMicDevices()
    {
      try
      {
        Log.WriteToLog("Getting list of available microphone devices");
        GetDevices.MicDevices = GetDevices.devenum.EnumerateAudioEndPoints(EDataFlow.eCapture, DEVICE_STATE.DEVICE_STATE_ACTIVE);
        GetDevices.MicdevCount = GetDevices.MicDevices.Count;
        MyProject.Forms.FrmSetFallback.ComboMicFallback.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Clear();
        MyProject.Forms.FrmSetFallback.ComboMicFallback.Items.Clear();
        MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboCommMicFallback.Items.Clear();
        MyProject.Forms.FrmSetFallback.ComboBox3.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboBox3.Items.Clear();
        MyProject.Forms.FrmSetFallback.ComboBox5.DataSource = (object) null;
        MyProject.Forms.FrmSetFallback.ComboBox5.Items.Clear();
        if (GetDevices.MicDevices.Count > 0)
        {
          int num = checked (GetDevices.MicDevices.Count - 1);
          int index = 0;
          while (index <= num)
          {
            if (GetDevices.MicDevices[index].Properties[checked (GetDevices.MicDevices[index].Properties.Count - 3)].Value.ToString().ToLower().Contains("rift"))
            {
              MySettingsProperty.Settings.RiftMicGuid = GetDevices.MicDevices[index].ID.ToString();
              MySettingsProperty.Settings.Save();
              Log.WriteToLog("Rift Microphone ID: " + GetDevices.MicDevices[index].ID.ToString().Replace("{", "[").Replace("}", "]"));
            }
            MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Add(GetDevices.MicDevices[index].ID.ToString(), GetDevices.MicDevices[index].Properties[checked (GetDevices.MicDevices[index].Properties.Count - 3)].Value.ToString());
            checked { ++index; }
          }
          Log.WriteToLog("Found " + Conversions.ToString(checked (GetDevices.MicDevices.Count - 1)) + " non-Rift input devices");
        }
        else
        {
          Log.WriteToLog("No enabled microphone devices found");
          FrmMain.fmain.AddToListboxAndScroll("No enabled microphone devices found");
          MyProject.Forms.FrmMain.hasWarning = true;
          GetConfig.useVoiceCommands = false;
          MyProject.Forms.FrmMain.ComboVoice.SelectedIndex = 0;
          MyProject.Forms.FrmMain.ComboVoice.Enabled = false;
          MyProject.Forms.FrmMain.BtnVoice.Enabled = false;
          MySettingsProperty.Settings.DefaultMic = "";
          MySettingsProperty.Settings.SystemDefaultMicGuid = "";
          MySettingsProperty.Settings.SystemDefaultCommGuid = "";
          MySettingsProperty.Settings.Save();
        }
        if (GetDevices.MicDevices.Count > 1)
        {
          MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Add("1", "Use current default");
          MyProject.Forms.FrmSetFallback.ComboMicFallback.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, (string) null);
          MyProject.Forms.FrmSetFallback.ComboMicFallback.DisplayMember = "Value";
          MyProject.Forms.FrmSetFallback.ComboMicFallback.ValueMember = "Key";
          MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, (string) null);
          MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DisplayMember = "Value";
          MyProject.Forms.FrmSetFallback.ComboCommMicFallback.ValueMember = "Key";
          MyProject.Forms.FrmSetFallback.ComboBox3.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, (string) null);
          MyProject.Forms.FrmSetFallback.ComboBox3.DisplayMember = "Value";
          MyProject.Forms.FrmSetFallback.ComboBox3.ValueMember = "Key";
          MyProject.Forms.FrmSetFallback.ComboBox5.DataSource = (object) new BindingSource((object) MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, (string) null);
          MyProject.Forms.FrmSetFallback.ComboBox5.DisplayMember = "Value";
          MyProject.Forms.FrmSetFallback.ComboBox5.ValueMember = "Key";
        }
        else
        {
          MySettingsProperty.Settings.DefaultMic = "";
          MySettingsProperty.Settings.SystemDefaultMicGuid = "";
          MySettingsProperty.Settings.SystemDefaultCommGuid = "";
          MySettingsProperty.Settings.Save();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        if (Operators.CompareString(exception.HResult.ToString(), "-2147023728", false) == 0)
        {
          Log.WriteToLog("No microphone devices found!");
          FrmMain.fmain.AddToListboxAndScroll("No microphone devices found!");
          MyProject.Forms.FrmMain.hasWarning = true;
          MySettingsProperty.Settings.DefaultMic = "";
          MySettingsProperty.Settings.SystemDefaultMicGuid = "";
          MySettingsProperty.Settings.Save();
        }
        else
          Log.WriteToLog("GetAllMicDevices: " + exception.Message + " (" + exception.HResult.ToString() + ")");
        ProjectData.ClearProjectError();
      }
    }

    public static object GetDefaultMicDevice()
    {
      object defaultMicDevice;
      try
      {
        defaultMicDevice = (object) GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia).ID.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultMicDevice: " + ex.Message);
        defaultMicDevice = (object) "";
        ProjectData.ClearProjectError();
      }
      return defaultMicDevice;
    }

    public static object GetDefaultMicDeviceName()
    {
      object defaultMicDeviceName;
      try
      {
        MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
        defaultMicDeviceName = (object) defaultAudioEndpoint.Properties[checked (defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultMicDeviceName: " + ex.Message);
        defaultMicDeviceName = (object) "";
        ProjectData.ClearProjectError();
      }
      return defaultMicDeviceName;
    }

    public static object GetDefaultAudioDevice()
    {
      object defaultAudioDevice;
      try
      {
        defaultAudioDevice = (object) GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia).ID.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultAudioDevice: " + ex.Message);
        defaultAudioDevice = (object) "";
        ProjectData.ClearProjectError();
      }
      return defaultAudioDevice;
    }

    public static object GetDefaultAudioDeviceName()
    {
      object defaultAudioDeviceName;
      try
      {
        MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
        defaultAudioDeviceName = (object) defaultAudioEndpoint.Properties[checked (defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultAudioDeviceName: " + ex.Message);
        defaultAudioDeviceName = (object) "";
        ProjectData.ClearProjectError();
      }
      return defaultAudioDeviceName;
    }

    public static object GetDefaultAudioCommDevice()
    {
      object defaultAudioCommDevice;
      try
      {
        defaultAudioCommDevice = (object) GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications).ID.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultAudioCommDevice: " + ex.Message);
        defaultAudioCommDevice = (object) "";
        ProjectData.ClearProjectError();
      }
      return defaultAudioCommDevice;
    }

    public static object GetDefaultAudioCommDeviceName()
    {
      object audioCommDeviceName;
      try
      {
        MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications);
        audioCommDeviceName = (object) defaultAudioEndpoint.Properties[checked (defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultAudioCommDeviceName: " + ex.Message);
        audioCommDeviceName = (object) "";
        ProjectData.ClearProjectError();
      }
      return audioCommDeviceName;
    }

    public static object GetDefaultMicCommDevice()
    {
      object defaultMicCommDevice;
      try
      {
        defaultMicCommDevice = (object) GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications).ID.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultMiCommDevice: " + ex.Message);
        defaultMicCommDevice = (object) "";
        ProjectData.ClearProjectError();
      }
      return defaultMicCommDevice;
    }

    public static object GetDefaultMicCommDeviceName()
    {
      object micCommDeviceName;
      try
      {
        MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications);
        micCommDeviceName = (object) defaultAudioEndpoint.Properties[checked (defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetDefaultMiCommDeviceName: " + ex.Message);
        micCommDeviceName = (object) "";
        ProjectData.ClearProjectError();
      }
      return micCommDeviceName;
    }
  }
}
