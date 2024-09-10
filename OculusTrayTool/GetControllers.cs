using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using SharpDX.DirectInput;

namespace OculusTrayTool
{
	// Token: 0x02000028 RID: 40
	[StandardModule]
	internal sealed class GetControllers
	{
		// Token: 0x060003E0 RID: 992 RVA: 0x00018650 File Offset: 0x00016850
		public static void GetAllControllers()
		{
			GetControllers.joysticks.Clear();
			DirectInput directInput = new DirectInput();
			try
			{
				foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices))
				{
					GetControllers.joystickGuid = deviceInstance.InstanceGuid;
					DirectInput directInput2 = directInput;
					object obj = GetControllers.joystickGuid;
					GetControllers.joy = new Joystick(directInput2, (obj != null) ? ((Guid)obj) : default(Guid));
					bool flag = !GetControllers.joysticks.ContainsKey(GetControllers.joy.Properties.ProductName);
					if (flag)
					{
						Dictionary<string, Guid> dictionary = GetControllers.joysticks;
						string productName = GetControllers.joy.Properties.ProductName;
						object obj2 = GetControllers.joystickGuid;
						dictionary.Add(productName, (obj2 != null) ? ((Guid)obj2) : default(Guid));
						GetControllers.ControllersFound = true;
					}
				}
			}
			finally
			{
				IEnumerator<DeviceInstance> enumerator;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00018748 File Offset: 0x00016948
		public static void SelectController()
		{
			GetControllers.joystickGuid = Guid.Empty;
			Dictionary<string, Guid> dictionary = GetControllers.joysticks;
			string text = GetControllers.selectedDevice;
			object obj = GetControllers.joystickGuid;
			Guid guid = ((obj != null) ? ((Guid)obj) : default(Guid));
			bool flag = dictionary.TryGetValue(text, out guid);
			GetControllers.joystickGuid = guid;
			bool flag2 = !flag;
			if (flag2)
			{
				Interaction.MsgBox("Could not get GUID", MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000187B4 File Offset: 0x000169B4
		public static void CaptureSelectedButton()
		{
			try
			{
				DirectInput directInput = new DirectInput();
				DirectInput directInput2 = directInput;
				object obj = GetControllers.joystickGuid;
				GetControllers.joy = new Joystick(directInput2, (obj != null) ? ((Guid)obj) : default(Guid));
				GetControllers.joy.Properties.BufferSize = 128;
				GetControllers.joy.Acquire();
				GetControllers.joyAquired = true;
				for (;;)
				{
					Application.DoEvents();
					GetControllers.joy.Poll();
					JoystickUpdate[] bufferedData = GetControllers.joy.GetBufferedData();
					foreach (JoystickUpdate joystickUpdate in bufferedData)
					{
						bool flag = joystickUpdate.ToString().Contains("Buttons") & joystickUpdate.ToString().Contains("128");
						if (flag)
						{
							goto Block_3;
						}
					}
					Thread.Sleep(100);
				}
				Block_3:
				JoystickUpdate joystickUpdate;
				string text = joystickUpdate.Offset.ToString();
				frmVoiceSettings.UpdateButtonLabel(text.ToString().Replace("Buttons", ""));
				frmVoiceSettings.UpdateListeningButton(1);
				MySettingsProperty.Settings.JoystickVoiceActivationButton = text;
				MySettingsProperty.Settings.JoystickDeviceName = GetControllers.selectedDevice;
				MySettingsProperty.Settings.Save();
				GetControllers.joy.Unacquire();
				GetControllers.joyAquired = false;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("CaptureSelectedButton(): " + ex.Message);
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00018968 File Offset: 0x00016B68
		public static void CaptureButtonPushToTalk()
		{
			try
			{
				GetControllers.joystickGuid = Guid.Empty;
				Dictionary<string, Guid> dictionary = GetControllers.joysticks;
				string joystickDeviceName = MySettingsProperty.Settings.JoystickDeviceName;
				object obj = GetControllers.joystickGuid;
				Guid guid = ((obj != null) ? ((Guid)obj) : default(Guid));
				bool flag = dictionary.TryGetValue(joystickDeviceName, out guid);
				GetControllers.joystickGuid = guid;
				bool flag2 = flag;
				if (flag2)
				{
					Log.WriteToLog(string.Concat(new string[]
					{
						"Listening to ",
						MySettingsProperty.Settings.JoystickDeviceName,
						" (",
						GetControllers.joystickGuid.ToString(),
						") for button activated voice commands"
					}));
					DirectInput directInput = new DirectInput();
					DirectInput directInput2 = directInput;
					object obj2 = GetControllers.joystickGuid;
					Guid guid2;
					if (obj2 == null)
					{
						guid = default(Guid);
						guid2 = guid;
					}
					else
					{
						guid2 = (Guid)obj2;
					}
					GetControllers.joy = new Joystick(directInput2, guid2);
					GetControllers.joy.Properties.BufferSize = 128;
					GetControllers.joy.Acquire();
					GetControllers.joyAquired = true;
					for (;;)
					{
						GetControllers.joy.Poll();
						JoystickUpdate[] bufferedData = GetControllers.joy.GetBufferedData();
						foreach (JoystickUpdate joystickUpdate in bufferedData)
						{
							bool flag3 = Operators.CompareString(joystickUpdate.Offset.ToString(), MySettingsProperty.Settings.JoystickVoiceActivationButton, false) == 0;
							if (flag3)
							{
								bool joystickActivationKeyContinous = MySettingsProperty.Settings.JoystickActivationKeyContinous;
								if (joystickActivationKeyContinous)
								{
									bool flag4 = !VoiceCommands.isListening;
									if (flag4)
									{
										bool flag5 = Operators.CompareString(joystickUpdate.Value.ToString(), "128", false) == 0;
										if (flag5)
										{
											bool flag6 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
											if (flag6)
											{
												Thread thread = new Thread((GetControllers._Closure$__.$I10-0 == null) ? (GetControllers._Closure$__.$I10-0 = delegate
												{
													MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
												}) : GetControllers._Closure$__.$I10-0);
												thread.Start();
											}
											VoiceCommands.isListening = true;
											FrmMain.fmain.SetTitleIsListening();
											break;
										}
									}
									else
									{
										bool flag7 = Operators.CompareString(joystickUpdate.Value.ToString(), "128", false) == 0;
										if (flag7)
										{
											VoiceCommands.isListening = false;
											bool flag8 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
											if (flag8)
											{
												Thread thread2 = new Thread((GetControllers._Closure$__.$I10-1 == null) ? (GetControllers._Closure$__.$I10-1 = delegate
												{
													MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
												}) : GetControllers._Closure$__.$I10-1);
												thread2.Start();
											}
											FrmMain.fmain.RemoveTitleIsListening();
										}
									}
								}
								bool joystickActivationKeyPush = MySettingsProperty.Settings.JoystickActivationKeyPush;
								if (joystickActivationKeyPush)
								{
									bool flag9 = Operators.CompareString(joystickUpdate.Value.ToString(), "128", false) == 0;
									if (flag9)
									{
										VoiceCommands.isListening = true;
										bool flag10 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
										if (flag10)
										{
											Thread thread3 = new Thread((GetControllers._Closure$__.$I10-2 == null) ? (GetControllers._Closure$__.$I10-2 = delegate
											{
												MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
											}) : GetControllers._Closure$__.$I10-2);
											thread3.Start();
										}
										FrmMain.fmain.SetTitleIsListening();
									}
									bool flag11 = Operators.CompareString(joystickUpdate.Value.ToString(), "0", false) == 0;
									if (flag11)
									{
										VoiceCommands.isListening = false;
										bool flag12 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
										if (flag12)
										{
											Thread thread4 = new Thread((GetControllers._Closure$__.$I10-3 == null) ? (GetControllers._Closure$__.$I10-3 = delegate
											{
												MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
											}) : GetControllers._Closure$__.$I10-3);
											thread4.Start();
										}
										FrmMain.fmain.RemoveTitleIsListening();
									}
								}
							}
						}
						Thread.Sleep(100);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x04000150 RID: 336
		public static Dictionary<string, Guid> joysticks = new Dictionary<string, Guid>();

		// Token: 0x04000151 RID: 337
		private static object joystickGuid = Guid.Empty;

		// Token: 0x04000152 RID: 338
		public static bool ControllersFound = false;

		// Token: 0x04000153 RID: 339
		public static string selectedDevice;

		// Token: 0x04000154 RID: 340
		public static Joystick joy;

		// Token: 0x04000155 RID: 341
		public static bool joyAquired = false;
	}
}
