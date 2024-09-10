// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.GetControllers
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class GetControllers
  {
    public static Dictionary<string, Guid> joysticks = new Dictionary<string, Guid>();
    private static object joystickGuid = (object) Guid.Empty;
    public static bool ControllersFound = false;
    public static string selectedDevice;
    public static Joystick joy;
    public static bool joyAquired = false;

    public static void GetAllControllers()
    {
      GetControllers.joysticks.Clear();
      SharpDX.DirectInput.DirectInput directInput1 = new SharpDX.DirectInput.DirectInput();
      try
      {
        foreach (DeviceInstance device in (IEnumerable<DeviceInstance>) directInput1.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices))
        {
          GetControllers.joystickGuid = (object) device.InstanceGuid;
          SharpDX.DirectInput.DirectInput directInput2 = directInput1;
          object joystickGuid1 = GetControllers.joystickGuid;
          Guid deviceGuid = joystickGuid1 != null ? (Guid) joystickGuid1 : new Guid();
          GetControllers.joy = new Joystick(directInput2, deviceGuid);
          if (!GetControllers.joysticks.ContainsKey(GetControllers.joy.Properties.ProductName))
          {
            Dictionary<string, Guid> joysticks = GetControllers.joysticks;
            string productName = GetControllers.joy.Properties.ProductName;
            object joystickGuid2 = GetControllers.joystickGuid;
            Guid guid = joystickGuid2 != null ? (Guid) joystickGuid2 : new Guid();
            joysticks.Add(productName, guid);
            GetControllers.ControllersFound = true;
          }
        }
      }
      finally
      {
        IEnumerator<DeviceInstance> enumerator;
        enumerator?.Dispose();
      }
    }

    public static void SelectController()
    {
      GetControllers.joystickGuid = (object) Guid.Empty;
      Dictionary<string, Guid> joysticks = GetControllers.joysticks;
      string selectedDevice = GetControllers.selectedDevice;
      object joystickGuid = GetControllers.joystickGuid;
      Guid guid = joystickGuid != null ? (Guid) joystickGuid : new Guid();
      ref Guid local = ref guid;
      bool flag = joysticks.TryGetValue(selectedDevice, out local);
      GetControllers.joystickGuid = (object) guid;
      if (flag)
        return;
      int num = (int) Interaction.MsgBox((object) "Could not get GUID");
    }

    public static void CaptureSelectedButton()
    {
      try
      {
        SharpDX.DirectInput.DirectInput directInput = new SharpDX.DirectInput.DirectInput();
        object joystickGuid = GetControllers.joystickGuid;
        Guid deviceGuid = joystickGuid != null ? (Guid) joystickGuid : new Guid();
        GetControllers.joy = new Joystick(directInput, deviceGuid);
        GetControllers.joy.Properties.BufferSize = 128;
        GetControllers.joy.Acquire();
        GetControllers.joyAquired = true;
        while (true)
        {
          Application.DoEvents();
          GetControllers.joy.Poll();
          JoystickUpdate[] bufferedData = GetControllers.joy.GetBufferedData();
          int index = 0;
          while (index < bufferedData.Length)
          {
            JoystickUpdate joystickUpdate = bufferedData[index];
            if (joystickUpdate.ToString().Contains("Buttons") & joystickUpdate.ToString().Contains("128"))
            {
              string str = joystickUpdate.Offset.ToString();
              frmVoiceSettings.UpdateButtonLabel(str.ToString().Replace("Buttons", ""));
              frmVoiceSettings.UpdateListeningButton(1);
              MySettingsProperty.Settings.JoystickVoiceActivationButton = str;
              MySettingsProperty.Settings.JoystickDeviceName = GetControllers.selectedDevice;
              MySettingsProperty.Settings.Save();
              GetControllers.joy.Unacquire();
              GetControllers.joyAquired = false;
              return;
            }
            checked { ++index; }
          }
          Thread.Sleep(100);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("CaptureSelectedButton(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void CaptureButtonPushToTalk()
    {
      try
      {
        GetControllers.joystickGuid = (object) Guid.Empty;
        Dictionary<string, Guid> joysticks = GetControllers.joysticks;
        string joystickDeviceName = MySettingsProperty.Settings.JoystickDeviceName;
        object joystickGuid1 = GetControllers.joystickGuid;
        Guid guid = joystickGuid1 != null ? (Guid) joystickGuid1 : new Guid();
        ref Guid local = ref guid;
        bool flag = joysticks.TryGetValue(joystickDeviceName, out local);
        GetControllers.joystickGuid = (object) guid;
        if (!flag)
          return;
        Log.WriteToLog("Listening to " + MySettingsProperty.Settings.JoystickDeviceName + " (" + GetControllers.joystickGuid.ToString() + ") for button activated voice commands");
        SharpDX.DirectInput.DirectInput directInput = new SharpDX.DirectInput.DirectInput();
        object joystickGuid2 = GetControllers.joystickGuid;
        Guid deviceGuid;
        if (joystickGuid2 == null)
        {
          guid = new Guid();
          deviceGuid = guid;
        }
        else
          deviceGuid = (Guid) joystickGuid2;
        GetControllers.joy = new Joystick(directInput, deviceGuid);
        GetControllers.joy.Properties.BufferSize = 128;
        GetControllers.joy.Acquire();
        GetControllers.joyAquired = true;
        while (true)
        {
          GetControllers.joy.Poll();
          JoystickUpdate[] bufferedData = GetControllers.joy.GetBufferedData();
          int index = 0;
          while (index < bufferedData.Length)
          {
            JoystickUpdate joystickUpdate = bufferedData[index];
            if (Operators.CompareString(joystickUpdate.Offset.ToString(), MySettingsProperty.Settings.JoystickVoiceActivationButton, false) == 0)
            {
              int num;
              if (MySettingsProperty.Settings.JoystickActivationKeyContinous)
              {
                if (!VoiceCommands.isListening)
                {
                  num = joystickUpdate.Value;
                  if (Operators.CompareString(num.ToString(), "128", false) == 0)
                  {
                    if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
                    {
                      ThreadStart start;
                      // ISSUE: reference to a compiler-generated field
                      if (GetControllers._Closure\u0024__.\u0024I10\u002D0 != null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        start = GetControllers._Closure\u0024__.\u0024I10\u002D0;
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        GetControllers._Closure\u0024__.\u0024I10\u002D0 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background));
                      }
                      new Thread(start).Start();
                    }
                    VoiceCommands.isListening = true;
                    FrmMain.fmain.SetTitleIsListening();
                    break;
                  }
                }
                else
                {
                  num = joystickUpdate.Value;
                  if (Operators.CompareString(num.ToString(), "128", false) == 0)
                  {
                    VoiceCommands.isListening = false;
                    if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
                    {
                      ThreadStart start;
                      // ISSUE: reference to a compiler-generated field
                      if (GetControllers._Closure\u0024__.\u0024I10\u002D1 != null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        start = GetControllers._Closure\u0024__.\u0024I10\u002D1;
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        GetControllers._Closure\u0024__.\u0024I10\u002D1 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background));
                      }
                      new Thread(start).Start();
                    }
                    FrmMain.fmain.RemoveTitleIsListening();
                  }
                }
              }
              if (MySettingsProperty.Settings.JoystickActivationKeyPush)
              {
                num = joystickUpdate.Value;
                if (Operators.CompareString(num.ToString(), "128", false) == 0)
                {
                  VoiceCommands.isListening = true;
                  if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
                  {
                    ThreadStart start;
                    // ISSUE: reference to a compiler-generated field
                    if (GetControllers._Closure\u0024__.\u0024I10\u002D2 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      start = GetControllers._Closure\u0024__.\u0024I10\u002D2;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      GetControllers._Closure\u0024__.\u0024I10\u002D2 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background));
                    }
                    new Thread(start).Start();
                  }
                  FrmMain.fmain.SetTitleIsListening();
                }
                num = joystickUpdate.Value;
                if (Operators.CompareString(num.ToString(), "0", false) == 0)
                {
                  VoiceCommands.isListening = false;
                  if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
                  {
                    ThreadStart start;
                    // ISSUE: reference to a compiler-generated field
                    if (GetControllers._Closure\u0024__.\u0024I10\u002D3 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      start = GetControllers._Closure\u0024__.\u0024I10\u002D3;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      GetControllers._Closure\u0024__.\u0024I10\u002D3 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background));
                    }
                    new Thread(start).Start();
                  }
                  FrmMain.fmain.RemoveTitleIsListening();
                }
              }
            }
            checked { ++index; }
          }
          Thread.Sleep(100);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }
  }
}
