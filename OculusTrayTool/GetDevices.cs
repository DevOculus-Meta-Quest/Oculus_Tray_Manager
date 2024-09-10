using System;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000029 RID: 41
	[StandardModule]
	internal sealed class GetDevices
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00018D7C File Offset: 0x00016F7C
		public static void GetAllAudioDevices()
		{
			checked
			{
				try
				{
					Log.WriteToLog("Getting list of available audio devices");
					GetDevices.AudioDevices = GetDevices.devenum.EnumerateAudioEndPoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE);
					GetDevices.AudioDevCount = GetDevices.AudioDevices.Count;
					MyProject.Forms.FrmSetFallback.ComboAudioFallback.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Clear();
					MyProject.Forms.FrmSetFallback.ComboAudioFallback.Items.Clear();
					MyProject.Forms.FrmSetFallback.ComboCommFallback.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboCommFallback.Items.Clear();
					MyProject.Forms.FrmSetFallback.ComboBox4.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboBox4.Items.Clear();
					MyProject.Forms.FrmSetFallback.ComboBox6.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboBox6.Items.Clear();
					bool flag = GetDevices.AudioDevices.Count > 0;
					if (flag)
					{
						int num = GetDevices.AudioDevices.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							bool flag2 = GetDevices.AudioDevices[i].Properties[GetDevices.AudioDevices[i].Properties.Count - 3].Value.ToString().ToLower().Contains("rift");
							if (flag2)
							{
								MySettingsProperty.Settings.RiftAudioGuid = GetDevices.AudioDevices[i].ID.ToString();
								MySettingsProperty.Settings.Save();
								Log.WriteToLog("Rift Audio ID: " + GetDevices.AudioDevices[i].ID.ToString().Replace("{", "[").Replace("}", "]"));
							}
							MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Add(GetDevices.AudioDevices[i].ID.ToString(), GetDevices.AudioDevices[i].Properties[GetDevices.AudioDevices[i].Properties.Count - 3].Value.ToString());
						}
						bool flag3 = GetDevices.AudioDevices.Count > 1;
						if (flag3)
						{
							MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Add("1", "Use current default");
							MyProject.Forms.FrmSetFallback.ComboAudioFallback.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, null);
							MyProject.Forms.FrmSetFallback.ComboAudioFallback.DisplayMember = "Value";
							MyProject.Forms.FrmSetFallback.ComboAudioFallback.ValueMember = "Key";
							MyProject.Forms.FrmSetFallback.ComboCommFallback.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, null);
							MyProject.Forms.FrmSetFallback.ComboCommFallback.DisplayMember = "Value";
							MyProject.Forms.FrmSetFallback.ComboCommFallback.ValueMember = "Key";
							MyProject.Forms.FrmSetFallback.ComboBox4.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, null);
							MyProject.Forms.FrmSetFallback.ComboBox4.DisplayMember = "Value";
							MyProject.Forms.FrmSetFallback.ComboBox4.ValueMember = "Key";
							MyProject.Forms.FrmSetFallback.ComboBox6.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource, null);
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
						Log.WriteToLog("Found " + Conversions.ToString(GetDevices.AudioDevices.Count - 1) + " non-Rift output devices");
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
					Log.WriteToLog("GetAllAudioDevices: " + ex.Message);
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000192D8 File Offset: 0x000174D8
		public static void GetAllMicDevices()
		{
			checked
			{
				try
				{
					Log.WriteToLog("Getting list of available microphone devices");
					GetDevices.MicDevices = GetDevices.devenum.EnumerateAudioEndPoints(EDataFlow.eCapture, DEVICE_STATE.DEVICE_STATE_ACTIVE);
					GetDevices.MicdevCount = GetDevices.MicDevices.Count;
					MyProject.Forms.FrmSetFallback.ComboMicFallback.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Clear();
					MyProject.Forms.FrmSetFallback.ComboMicFallback.Items.Clear();
					MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboCommMicFallback.Items.Clear();
					MyProject.Forms.FrmSetFallback.ComboBox3.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboBox3.Items.Clear();
					MyProject.Forms.FrmSetFallback.ComboBox5.DataSource = null;
					MyProject.Forms.FrmSetFallback.ComboBox5.Items.Clear();
					bool flag = GetDevices.MicDevices.Count > 0;
					if (flag)
					{
						int num = GetDevices.MicDevices.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							bool flag2 = GetDevices.MicDevices[i].Properties[GetDevices.MicDevices[i].Properties.Count - 3].Value.ToString().ToLower().Contains("rift");
							if (flag2)
							{
								MySettingsProperty.Settings.RiftMicGuid = GetDevices.MicDevices[i].ID.ToString();
								MySettingsProperty.Settings.Save();
								Log.WriteToLog("Rift Microphone ID: " + GetDevices.MicDevices[i].ID.ToString().Replace("{", "[").Replace("}", "]"));
							}
							MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Add(GetDevices.MicDevices[i].ID.ToString(), GetDevices.MicDevices[i].Properties[GetDevices.MicDevices[i].Properties.Count - 3].Value.ToString());
						}
						Log.WriteToLog("Found " + Conversions.ToString(GetDevices.MicDevices.Count - 1) + " non-Rift input devices");
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
					bool flag3 = GetDevices.MicDevices.Count > 1;
					if (flag3)
					{
						MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Add("1", "Use current default");
						MyProject.Forms.FrmSetFallback.ComboMicFallback.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, null);
						MyProject.Forms.FrmSetFallback.ComboMicFallback.DisplayMember = "Value";
						MyProject.Forms.FrmSetFallback.ComboMicFallback.ValueMember = "Key";
						MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, null);
						MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DisplayMember = "Value";
						MyProject.Forms.FrmSetFallback.ComboCommMicFallback.ValueMember = "Key";
						MyProject.Forms.FrmSetFallback.ComboBox3.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, null);
						MyProject.Forms.FrmSetFallback.ComboBox3.DisplayMember = "Value";
						MyProject.Forms.FrmSetFallback.ComboBox3.ValueMember = "Key";
						MyProject.Forms.FrmSetFallback.ComboBox5.DataSource = new BindingSource(MyProject.Forms.FrmSetFallback.ComboMicFallbackSource, null);
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
					bool flag4 = Operators.CompareString(ex.HResult.ToString(), "-2147023728", false) == 0;
					if (flag4)
					{
						Log.WriteToLog("No microphone devices found!");
						FrmMain.fmain.AddToListboxAndScroll("No microphone devices found!");
						MyProject.Forms.FrmMain.hasWarning = true;
						MySettingsProperty.Settings.DefaultMic = "";
						MySettingsProperty.Settings.SystemDefaultMicGuid = "";
						MySettingsProperty.Settings.Save();
					}
					else
					{
						Log.WriteToLog(string.Concat(new string[]
						{
							"GetAllMicDevices: ",
							ex.Message,
							" (",
							ex.HResult.ToString(),
							")"
						}));
					}
				}
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000198F4 File Offset: 0x00017AF4
		public static object GetDefaultMicDevice()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
				obj = defaultAudioEndpoint.ID.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultMicDevice: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0001995C File Offset: 0x00017B5C
		public static object GetDefaultMicDeviceName()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
				obj = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultMicDeviceName: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x000199DC File Offset: 0x00017BDC
		public static object GetDefaultAudioDevice()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
				obj = defaultAudioEndpoint.ID.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultAudioDevice: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00019A44 File Offset: 0x00017C44
		public static object GetDefaultAudioDeviceName()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
				obj = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultAudioDeviceName: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00019AC4 File Offset: 0x00017CC4
		public static object GetDefaultAudioCommDevice()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications);
				obj = defaultAudioEndpoint.ID.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultAudioCommDevice: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00019B2C File Offset: 0x00017D2C
		public static object GetDefaultAudioCommDeviceName()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications);
				obj = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultAudioCommDeviceName: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00019BAC File Offset: 0x00017DAC
		public static object GetDefaultMicCommDevice()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications);
				obj = defaultAudioEndpoint.ID.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultMiCommDevice: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00019C14 File Offset: 0x00017E14
		public static object GetDefaultMicCommDeviceName()
		{
			object obj;
			try
			{
				MMDevice defaultAudioEndpoint = GetDevices.devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications);
				obj = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetDefaultMiCommDeviceName: " + ex.Message);
				obj = "";
			}
			return obj;
		}

		// Token: 0x04000156 RID: 342
		private static MMDeviceEnumerator devenum = new MMDeviceEnumerator();

		// Token: 0x04000157 RID: 343
		private static MMDeviceCollection AudioDevices;

		// Token: 0x04000158 RID: 344
		private static MMDeviceCollection MicDevices;

		// Token: 0x04000159 RID: 345
		public static int AudioDevCount = 0;

		// Token: 0x0400015A RID: 346
		public static int MicdevCount = 0;
	}
}
