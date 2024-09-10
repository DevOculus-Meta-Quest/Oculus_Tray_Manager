using System;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

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
		checked
		{
			try
			{
				Log.WriteToLog("Getting list of available audio devices");
				AudioDevices = devenum.EnumerateAudioEndPoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE);
				AudioDevCount = AudioDevices.Count;
				MyProject.Forms.FrmSetFallback.ComboAudioFallback.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Clear();
				MyProject.Forms.FrmSetFallback.ComboAudioFallback.Items.Clear();
				MyProject.Forms.FrmSetFallback.ComboCommFallback.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboCommFallback.Items.Clear();
				MyProject.Forms.FrmSetFallback.ComboBox4.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboBox4.Items.Clear();
				MyProject.Forms.FrmSetFallback.ComboBox6.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboBox6.Items.Clear();
				if (AudioDevices.Count > 0)
				{
					int num = AudioDevices.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (AudioDevices[i].Properties[AudioDevices[i].Properties.Count - 3].Value.ToString().ToLower().Contains("rift"))
						{
							MySettingsProperty.Settings.RiftAudioGuid = AudioDevices[i].ID.ToString();
							MySettingsProperty.Settings.Save();
							Log.WriteToLog("Rift Audio ID: " + AudioDevices[i].ID.ToString().Replace("{", "[").Replace("}", "]"));
						}
						MyProject.Forms.FrmSetFallback.ComboAudioFallbackSource.Add(AudioDevices[i].ID.ToString(), AudioDevices[i].Properties[AudioDevices[i].Properties.Count - 3].Value.ToString());
					}
					if (AudioDevices.Count > 1)
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
					Log.WriteToLog("Found " + Conversions.ToString(AudioDevices.Count - 1) + " non-Rift output devices");
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
				Exception ex2 = ex;
				Log.WriteToLog("GetAllAudioDevices: " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void GetAllMicDevices()
	{
		checked
		{
			try
			{
				Log.WriteToLog("Getting list of available microphone devices");
				MicDevices = devenum.EnumerateAudioEndPoints(EDataFlow.eCapture, DEVICE_STATE.DEVICE_STATE_ACTIVE);
				MicdevCount = MicDevices.Count;
				MyProject.Forms.FrmSetFallback.ComboMicFallback.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Clear();
				MyProject.Forms.FrmSetFallback.ComboMicFallback.Items.Clear();
				MyProject.Forms.FrmSetFallback.ComboCommMicFallback.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboCommMicFallback.Items.Clear();
				MyProject.Forms.FrmSetFallback.ComboBox3.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboBox3.Items.Clear();
				MyProject.Forms.FrmSetFallback.ComboBox5.DataSource = null;
				MyProject.Forms.FrmSetFallback.ComboBox5.Items.Clear();
				if (MicDevices.Count > 0)
				{
					int num = MicDevices.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (MicDevices[i].Properties[MicDevices[i].Properties.Count - 3].Value.ToString().ToLower().Contains("rift"))
						{
							MySettingsProperty.Settings.RiftMicGuid = MicDevices[i].ID.ToString();
							MySettingsProperty.Settings.Save();
							Log.WriteToLog("Rift Microphone ID: " + MicDevices[i].ID.ToString().Replace("{", "[").Replace("}", "]"));
						}
						MyProject.Forms.FrmSetFallback.ComboMicFallbackSource.Add(MicDevices[i].ID.ToString(), MicDevices[i].Properties[MicDevices[i].Properties.Count - 3].Value.ToString());
					}
					Log.WriteToLog("Found " + Conversions.ToString(MicDevices.Count - 1) + " non-Rift input devices");
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
				if (MicDevices.Count > 1)
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
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Operators.CompareString(ex2.HResult.ToString(), "-2147023728", TextCompare: false) == 0)
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
					Log.WriteToLog("GetAllMicDevices: " + ex2.Message + " (" + ex2.HResult + ")");
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public static object GetDefaultMicDevice()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
			result = defaultAudioEndpoint.ID.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultMicDevice: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultMicDeviceName()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
			result = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultMicDeviceName: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultAudioDevice()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
			result = defaultAudioEndpoint.ID.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultAudioDevice: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultAudioDeviceName()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
			result = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultAudioDeviceName: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultAudioCommDevice()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications);
			result = defaultAudioEndpoint.ID.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultAudioCommDevice: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultAudioCommDeviceName()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications);
			result = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultAudioCommDeviceName: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultMicCommDevice()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications);
			result = defaultAudioEndpoint.ID.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultMiCommDevice: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetDefaultMicCommDeviceName()
	{
		object result;
		try
		{
			MMDevice defaultAudioEndpoint = devenum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications);
			result = defaultAudioEndpoint.Properties[checked(defaultAudioEndpoint.Properties.Count - 3)].Value.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetDefaultMiCommDeviceName: " + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
