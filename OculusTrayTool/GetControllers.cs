using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using SharpDX.DirectInput;

namespace OculusTrayTool;

[StandardModule]
internal sealed class GetControllers
{
	public static Dictionary<string, Guid> joysticks = new Dictionary<string, Guid>();

	private static object joystickGuid = Guid.Empty;

	public static bool ControllersFound = false;

	public static string selectedDevice;

	public static Joystick joy;

	public static bool joyAquired = false;

	public static void GetAllControllers()
	{
		joysticks.Clear();
		DirectInput directInput = new DirectInput();
		foreach (DeviceInstance device in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices))
		{
			joystickGuid = device.InstanceGuid;
			object obj = joystickGuid;
			joy = new Joystick(directInput, (obj != null) ? ((Guid)obj) : default(Guid));
			if (!joysticks.ContainsKey(joy.Properties.ProductName))
			{
				Dictionary<string, Guid> dictionary = joysticks;
				string productName = joy.Properties.ProductName;
				object obj2 = joystickGuid;
				dictionary.Add(productName, (obj2 != null) ? ((Guid)obj2) : default(Guid));
				ControllersFound = true;
			}
		}
	}

	public static void SelectController()
	{
		joystickGuid = Guid.Empty;
		Dictionary<string, Guid> dictionary = joysticks;
		string key = selectedDevice;
		object obj = joystickGuid;
		Guid value = ((obj != null) ? ((Guid)obj) : default(Guid));
		bool flag = dictionary.TryGetValue(key, out value);
		joystickGuid = value;
		if (!flag)
		{
			Interaction.MsgBox("Could not get GUID");
		}
	}

	public static void CaptureSelectedButton()
	{
		try
		{
			string text = "";
			DirectInput directInput = new DirectInput();
			object obj = joystickGuid;
			joy = new Joystick(directInput, (obj != null) ? ((Guid)obj) : default(Guid));
			joy.Properties.BufferSize = 128;
			joy.Acquire();
			joyAquired = true;
			while (true)
			{
				Application.DoEvents();
				joy.Poll();
				JoystickUpdate[] bufferedData = joy.GetBufferedData();
				JoystickUpdate[] array = bufferedData;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					JoystickUpdate joystickUpdate = array[i];
					if (joystickUpdate.ToString().Contains("Buttons") & joystickUpdate.ToString().Contains("128"))
					{
						text = joystickUpdate.Offset.ToString();
						frmVoiceSettings.UpdateButtonLabel(text.ToString().Replace("Buttons", ""));
						frmVoiceSettings.UpdateListeningButton(1);
						MySettingsProperty.Settings.JoystickVoiceActivationButton = text;
						MySettingsProperty.Settings.JoystickDeviceName = selectedDevice;
						MySettingsProperty.Settings.Save();
						joy.Unacquire();
						joyAquired = false;
						return;
					}
				}
				Thread.Sleep(100);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("CaptureSelectedButton(): " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void CaptureButtonPushToTalk()
	{
		try
		{
			joystickGuid = Guid.Empty;
			Dictionary<string, Guid> dictionary = joysticks;
			string joystickDeviceName = MySettingsProperty.Settings.JoystickDeviceName;
			object obj = joystickGuid;
			Guid value = ((obj != null) ? ((Guid)obj) : default(Guid));
			bool flag = dictionary.TryGetValue(joystickDeviceName, out value);
			joystickGuid = value;
			if (!flag)
			{
				return;
			}
			Log.WriteToLog("Listening to " + MySettingsProperty.Settings.JoystickDeviceName + " (" + joystickGuid.ToString() + ") for button activated voice commands");
			DirectInput directInput = new DirectInput();
			object obj2 = joystickGuid;
			joy = new Joystick(directInput, (obj2 != null) ? ((Guid)obj2) : default(Guid));
			joy.Properties.BufferSize = 128;
			joy.Acquire();
			joyAquired = true;
			while (true)
			{
				joy.Poll();
				JoystickUpdate[] bufferedData = joy.GetBufferedData();
				JoystickUpdate[] array = bufferedData;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					JoystickUpdate joystickUpdate = array[i];
					if (Operators.CompareString(joystickUpdate.Offset.ToString(), MySettingsProperty.Settings.JoystickVoiceActivationButton, TextCompare: false) != 0)
					{
						continue;
					}
					if (MySettingsProperty.Settings.JoystickActivationKeyContinous)
					{
						if (!VoiceCommands.isListening)
						{
							if (Operators.CompareString(joystickUpdate.Value.ToString(), "128", TextCompare: false) == 0)
							{
								if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
								{
									Thread thread = new Thread([SpecialName] () =>
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
									});
									thread.Start();
								}
								VoiceCommands.isListening = true;
								FrmMain.fmain.SetTitleIsListening();
								break;
							}
						}
						else if (Operators.CompareString(joystickUpdate.Value.ToString(), "128", TextCompare: false) == 0)
						{
							VoiceCommands.isListening = false;
							if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
							{
								Thread thread2 = new Thread([SpecialName] () =>
								{
									MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
								});
								thread2.Start();
							}
							FrmMain.fmain.RemoveTitleIsListening();
						}
					}
					if (!MySettingsProperty.Settings.JoystickActivationKeyPush)
					{
						continue;
					}
					if (Operators.CompareString(joystickUpdate.Value.ToString(), "128", TextCompare: false) == 0)
					{
						VoiceCommands.isListening = true;
						if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
						{
							Thread thread3 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
							});
							thread3.Start();
						}
						FrmMain.fmain.SetTitleIsListening();
					}
					if (Operators.CompareString(joystickUpdate.Value.ToString(), "0", TextCompare: false) != 0)
					{
						continue;
					}
					VoiceCommands.isListening = false;
					if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
					{
						Thread thread4 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
						});
						thread4.Start();
					}
					FrmMain.fmain.RemoveTitleIsListening();
				}
				Thread.Sleep(100);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
