using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool.My
{
	// Token: 0x02000006 RID: 6
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x06000026 RID: 38 RVA: 0x000026A4 File Offset: 0x000008A4
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		private static void AutoSaveSettings(object sender, EventArgs e)
		{
			bool saveMySettingsOnExit = MyProject.Application.SaveMySettingsOnExit;
			if (saveMySettingsOnExit)
			{
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000026D0 File Offset: 0x000008D0
		public static MySettings Default
		{
			get
			{
				bool flag = !MySettings.addedHandler;
				if (flag)
				{
					object obj = MySettings.addedHandlerLockObject;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					lock (obj)
					{
						bool flag3 = !MySettings.addedHandler;
						if (flag3)
						{
							MyProject.Application.Shutdown += MySettings.AutoSaveSettings;
							MySettings.addedHandler = true;
						}
					}
				}
				return MySettings.defaultInstance;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000275C File Offset: 0x0000095C
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000278D File Offset: 0x0000098D
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point WindowLocation
		{
			get
			{
				object obj = this["WindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["WindowLocation"] = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000027A4 File Offset: 0x000009A4
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000027C6 File Offset: 0x000009C6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("computer, start listening;speech on")]
		public string StartVoice
		{
			get
			{
				return Conversions.ToString(this["StartVoice"]);
			}
			set
			{
				this["StartVoice"] = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000027D8 File Offset: 0x000009D8
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000027FA File Offset: 0x000009FA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("computer, stop listening;speech off")]
		public string StopVoice
		{
			get
			{
				return Conversions.ToString(this["StopVoice"]);
			}
			set
			{
				this["StopVoice"] = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000280C File Offset: 0x00000A0C
		// (set) Token: 0x0600002F RID: 47 RVA: 0x0000282E File Offset: 0x00000A2E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("enable spacewarp")]
		public string EnableASW
		{
			get
			{
				return Conversions.ToString(this["EnableASW"]);
			}
			set
			{
				this["EnableASW"] = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002840 File Offset: 0x00000A40
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002862 File Offset: 0x00000A62
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("disable spacewarp")]
		public string DisableASW
		{
			get
			{
				return Conversions.ToString(this["DisableASW"]);
			}
			set
			{
				this["DisableASW"] = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002874 File Offset: 0x00000A74
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002896 File Offset: 0x00000A96
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show pixel density; show super sampling")]
		public string ShowPD
		{
			get
			{
				return Conversions.ToString(this["ShowPD"]);
			}
			set
			{
				this["ShowPD"] = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000028A8 File Offset: 0x00000AA8
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000028CA File Offset: 0x00000ACA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show performance")]
		public string ShowPerf
		{
			get
			{
				return Conversions.ToString(this["ShowPerf"]);
			}
			set
			{
				this["ShowPerf"] = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000028DC File Offset: 0x00000ADC
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000028FE File Offset: 0x00000AFE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("close overlay")]
		public string Close
		{
			get
			{
				return Conversions.ToString(this["Close"]);
			}
			set
			{
				this["Close"] = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002910 File Offset: 0x00000B10
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002932 File Offset: 0x00000B32
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("set pixel density;set super sampling")]
		public string SetPD
		{
			get
			{
				return Conversions.ToString(this["SetPD"]);
			}
			set
			{
				this["SetPD"] = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002944 File Offset: 0x00000B44
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002966 File Offset: 0x00000B66
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show spacewarp")]
		public string ShowASW
		{
			get
			{
				return Conversions.ToString(this["ShowASW"]);
			}
			set
			{
				this["ShowASW"] = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002978 File Offset: 0x00000B78
		// (set) Token: 0x0600003D RID: 61 RVA: 0x000029A9 File Offset: 0x00000BA9
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("663, 492")]
		public Size ScanDialogSize
		{
			get
			{
				object obj = this["ScanDialogSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["ScanDialogSize"] = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000029C0 File Offset: 0x00000BC0
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000029F1 File Offset: 0x00000BF1
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("613, 580")]
		public Size VoiceDialogSize
		{
			get
			{
				object obj = this["VoiceDialogSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["VoiceDialogSize"] = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002A08 File Offset: 0x00000C08
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002A2A File Offset: 0x00000C2A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string OldCPUID
		{
			get
			{
				return Conversions.ToString(this["OldCPUID"]);
			}
			set
			{
				this["OldCPUID"] = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002A3C File Offset: 0x00000C3C
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002A6D File Offset: 0x00000C6D
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point ScanWindowLocation
		{
			get
			{
				object obj = this["ScanWindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["ScanWindowLocation"] = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002A84 File Offset: 0x00000C84
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002AB5 File Offset: 0x00000CB5
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point ProfilesWindowLocation
		{
			get
			{
				object obj = this["ProfilesWindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["ProfilesWindowLocation"] = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002ACC File Offset: 0x00000CCC
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002AFD File Offset: 0x00000CFD
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point VoiceWindowLocation
		{
			get
			{
				object obj = this["VoiceWindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["VoiceWindowLocation"] = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002B14 File Offset: 0x00000D14
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002B45 File Offset: 0x00000D45
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point ReadmeWindowLocation
		{
			get
			{
				object obj = this["ReadmeWindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["ReadmeWindowLocation"] = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002B5C File Offset: 0x00000D5C
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002B7E File Offset: 0x00000D7E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("lock framerate")]
		public string LockASWOn
		{
			get
			{
				return Conversions.ToString(this["LockASWOn"]);
			}
			set
			{
				this["LockASWOn"] = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002B90 File Offset: 0x00000D90
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002BC1 File Offset: 0x00000DC1
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("507, 379")]
		public Size WindowSize
		{
			get
			{
				object obj = this["WindowSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["WindowSize"] = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002BD8 File Offset: 0x00000DD8
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002C09 File Offset: 0x00000E09
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0, 0")]
		public Point LogIconLocation
		{
			get
			{
				object obj = this["LogIconLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["LogIconLocation"] = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002C20 File Offset: 0x00000E20
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002C42 File Offset: 0x00000E42
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show latency timing")]
		public string ShowLatency
		{
			get
			{
				return Conversions.ToString(this["ShowLatency"]);
			}
			set
			{
				this["ShowLatency"] = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002C54 File Offset: 0x00000E54
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002C76 File Offset: 0x00000E76
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show application timing")]
		public string ShowApplicationRender
		{
			get
			{
				return Conversions.ToString(this["ShowApplicationRender"]);
			}
			set
			{
				this["ShowApplicationRender"] = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002C88 File Offset: 0x00000E88
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002CAA File Offset: 0x00000EAA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show compositor timing")]
		public string ShowCompositorRender
		{
			get
			{
				return Conversions.ToString(this["ShowCompositorRender"]);
			}
			set
			{
				this["ShowCompositorRender"] = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002CBC File Offset: 0x00000EBC
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002CDE File Offset: 0x00000EDE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("show version")]
		public string ShowVersion
		{
			get
			{
				return Conversions.ToString(this["ShowVersion"]);
			}
			set
			{
				this["ShowVersion"] = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002CF0 File Offset: 0x00000EF0
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002D21 File Offset: 0x00000F21
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("946, 584")]
		public Size ProfilesWindowSize
		{
			get
			{
				object obj = this["ProfilesWindowSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["ProfilesWindowSize"] = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002D38 File Offset: 0x00000F38
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002D5A File Offset: 0x00000F5A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowConfirmRestart
		{
			get
			{
				return Conversions.ToBoolean(this["ShowConfirmRestart"]);
			}
			set
			{
				this["ShowConfirmRestart"] = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002D70 File Offset: 0x00000F70
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002D92 File Offset: 0x00000F92
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("start steam;launch steam")]
		public string LaunchSteam
		{
			get
			{
				return Conversions.ToString(this["LaunchSteam"]);
			}
			set
			{
				this["LaunchSteam"] = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002DA4 File Offset: 0x00000FA4
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002DC6 File Offset: 0x00000FC6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string AssetsPath
		{
			get
			{
				return Conversions.ToString(this["AssetsPath"]);
			}
			set
			{
				this["AssetsPath"] = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002DD8 File Offset: 0x00000FD8
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002DFA File Offset: 0x00000FFA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool StartVoiceEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["StartVoiceEnabled"]);
			}
			set
			{
				this["StartVoiceEnabled"] = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002E10 File Offset: 0x00001010
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002E32 File Offset: 0x00001032
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool StopVoiceEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["StopVoiceEnabled"]);
			}
			set
			{
				this["StopVoiceEnabled"] = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002E48 File Offset: 0x00001048
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002E6A File Offset: 0x0000106A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool EnableASWEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["EnableASWEnabled"]);
			}
			set
			{
				this["EnableASWEnabled"] = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002E80 File Offset: 0x00001080
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002EA2 File Offset: 0x000010A2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool DisableASWEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["DisableASWEnabled"]);
			}
			set
			{
				this["DisableASWEnabled"] = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002EB8 File Offset: 0x000010B8
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002EDA File Offset: 0x000010DA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowPDEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowPDEnabled"]);
			}
			set
			{
				this["ShowPDEnabled"] = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002EF0 File Offset: 0x000010F0
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002F12 File Offset: 0x00001112
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowPerfEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowPerfEnabled"]);
			}
			set
			{
				this["ShowPerfEnabled"] = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002F28 File Offset: 0x00001128
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002F4A File Offset: 0x0000114A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool CloseEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["CloseEnabled"]);
			}
			set
			{
				this["CloseEnabled"] = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002F60 File Offset: 0x00001160
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00002F82 File Offset: 0x00001182
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool SetPDEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["SetPDEnabled"]);
			}
			set
			{
				this["SetPDEnabled"] = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002F98 File Offset: 0x00001198
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00002FBA File Offset: 0x000011BA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowASWEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowASWEnabled"]);
			}
			set
			{
				this["ShowASWEnabled"] = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002FD0 File Offset: 0x000011D0
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002FF2 File Offset: 0x000011F2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowLatencyEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowLatencyEnabled"]);
			}
			set
			{
				this["ShowLatencyEnabled"] = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003008 File Offset: 0x00001208
		// (set) Token: 0x06000075 RID: 117 RVA: 0x0000302A File Offset: 0x0000122A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowApplicationRenderEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowApplicationRenderEnabled"]);
			}
			set
			{
				this["ShowApplicationRenderEnabled"] = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003040 File Offset: 0x00001240
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003062 File Offset: 0x00001262
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowCompositorRenderEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowCompositorRenderEnabled"]);
			}
			set
			{
				this["ShowCompositorRenderEnabled"] = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003078 File Offset: 0x00001278
		// (set) Token: 0x06000079 RID: 121 RVA: 0x0000309A File Offset: 0x0000129A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowVersionEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["ShowVersionEnabled"]);
			}
			set
			{
				this["ShowVersionEnabled"] = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000030B0 File Offset: 0x000012B0
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000030D2 File Offset: 0x000012D2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool LaunchSteamEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["LaunchSteamEnabled"]);
			}
			set
			{
				this["LaunchSteamEnabled"] = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000030E8 File Offset: 0x000012E8
		// (set) Token: 0x0600007D RID: 125 RVA: 0x0000310A File Offset: 0x0000130A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool LockASWOnEnabled
		{
			get
			{
				return Conversions.ToBoolean(this["LockASWOnEnabled"]);
			}
			set
			{
				this["LockASWOnEnabled"] = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003120 File Offset: 0x00001320
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003142 File Offset: 0x00001342
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("9")]
		public float FontSize
		{
			get
			{
				return Conversions.ToSingle(this["FontSize"]);
			}
			set
			{
				this["FontSize"] = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003158 File Offset: 0x00001358
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003189 File Offset: 0x00001389
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("507, 411")]
		public Size GuiSize
		{
			get
			{
				object obj = this["GuiSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["GuiSize"] = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000031A0 File Offset: 0x000013A0
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000031C2 File Offset: 0x000013C2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartWithWindows
		{
			get
			{
				return Conversions.ToBoolean(this["StartWithWindows"]);
			}
			set
			{
				this["StartWithWindows"] = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000031D8 File Offset: 0x000013D8
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000031FA File Offset: 0x000013FA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool RunDebug
		{
			get
			{
				return Conversions.ToBoolean(this["RunDebug"]);
			}
			set
			{
				this["RunDebug"] = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00003210 File Offset: 0x00001410
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00003232 File Offset: 0x00001432
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool VoiceConfirmProfile
		{
			get
			{
				return Conversions.ToBoolean(this["VoiceConfirmProfile"]);
			}
			set
			{
				this["VoiceConfirmProfile"] = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003248 File Offset: 0x00001448
		// (set) Token: 0x06000089 RID: 137 RVA: 0x0000326A File Offset: 0x0000146A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowStillRunning
		{
			get
			{
				return Conversions.ToBoolean(this["ShowStillRunning"]);
			}
			set
			{
				this["ShowStillRunning"] = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00003280 File Offset: 0x00001480
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000032A2 File Offset: 0x000014A2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool SendHomeToTray
		{
			get
			{
				return Conversions.ToBoolean(this["SendHomeToTray"]);
			}
			set
			{
				this["SendHomeToTray"] = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000032B8 File Offset: 0x000014B8
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000032DA File Offset: 0x000014DA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool SendHomeToTrayOnStart
		{
			get
			{
				return Conversions.ToBoolean(this["SendHomeToTrayOnStart"]);
			}
			set
			{
				this["SendHomeToTrayOnStart"] = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000032F0 File Offset: 0x000014F0
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00003312 File Offset: 0x00001512
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowHomeToast
		{
			get
			{
				return Conversions.ToBoolean(this["ShowHomeToast"]);
			}
			set
			{
				this["ShowHomeToast"] = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003328 File Offset: 0x00001528
		// (set) Token: 0x06000091 RID: 145 RVA: 0x0000334A File Offset: 0x0000154A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartMinimized
		{
			get
			{
				return Conversions.ToBoolean(this["StartMinimized"]);
			}
			set
			{
				this["StartMinimized"] = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00003360 File Offset: 0x00001560
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00003382 File Offset: 0x00001582
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int StartHomeDelay
		{
			get
			{
				return Conversions.ToInteger(this["StartHomeDelay"]);
			}
			set
			{
				this["StartHomeDelay"] = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00003398 File Offset: 0x00001598
		// (set) Token: 0x06000095 RID: 149 RVA: 0x000033BA File Offset: 0x000015BA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool UseVoiceCommands
		{
			get
			{
				return Conversions.ToBoolean(this["UseVoiceCommands"]);
			}
			set
			{
				this["UseVoiceCommands"] = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000033D0 File Offset: 0x000015D0
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000033F2 File Offset: 0x000015F2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool DisableFrescoPower
		{
			get
			{
				return Conversions.ToBoolean(this["DisableFrescoPower"]);
			}
			set
			{
				this["DisableFrescoPower"] = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003408 File Offset: 0x00001608
		// (set) Token: 0x06000099 RID: 153 RVA: 0x0000342A File Offset: 0x0000162A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LibraryPath
		{
			get
			{
				return Conversions.ToString(this["LibraryPath"]);
			}
			set
			{
				this["LibraryPath"] = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000343C File Offset: 0x0000163C
		// (set) Token: 0x0600009B RID: 155 RVA: 0x0000345E File Offset: 0x0000165E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public string PPDPStartup
		{
			get
			{
				return Conversions.ToString(this["PPDPStartup"]);
			}
			set
			{
				this["PPDPStartup"] = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003470 File Offset: 0x00001670
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003492 File Offset: 0x00001692
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Not Used")]
		public string PowerPlanStart
		{
			get
			{
				return Conversions.ToString(this["PowerPlanStart"]);
			}
			set
			{
				this["PowerPlanStart"] = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000034A4 File Offset: 0x000016A4
		// (set) Token: 0x0600009F RID: 159 RVA: 0x000034C6 File Offset: 0x000016C6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool SpoofCPU
		{
			get
			{
				return Conversions.ToBoolean(this["SpoofCPU"]);
			}
			set
			{
				this["SpoofCPU"] = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x000034DC File Offset: 0x000016DC
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x000034FE File Offset: 0x000016FE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StopOVR
		{
			get
			{
				return Conversions.ToBoolean(this["StopOVR"]);
			}
			set
			{
				this["StopOVR"] = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00003514 File Offset: 0x00001714
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003536 File Offset: 0x00001736
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartHomeOnServiceStart
		{
			get
			{
				return Conversions.ToBoolean(this["StartHomeOnServiceStart"]);
			}
			set
			{
				this["StartHomeOnServiceStart"] = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000354C File Offset: 0x0000174C
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x0000356E File Offset: 0x0000176E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string OculusPath
		{
			get
			{
				return Conversions.ToString(this["OculusPath"]);
			}
			set
			{
				this["OculusPath"] = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00003580 File Offset: 0x00001780
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000035A2 File Offset: 0x000017A2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartOVR
		{
			get
			{
				return Conversions.ToBoolean(this["StartOVR"]);
			}
			set
			{
				this["StartOVR"] = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000035B8 File Offset: 0x000017B8
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000035DA File Offset: 0x000017DA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool OVRServerPriority
		{
			get
			{
				return Conversions.ToBoolean(this["OVRServerPriority"]);
			}
			set
			{
				this["OVRServerPriority"] = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000035F0 File Offset: 0x000017F0
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00003612 File Offset: 0x00001812
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartHomeOnToolStart
		{
			get
			{
				return Conversions.ToBoolean(this["StartHomeOnToolStart"]);
			}
			set
			{
				this["StartHomeOnToolStart"] = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003628 File Offset: 0x00001828
		// (set) Token: 0x060000AD RID: 173 RVA: 0x0000364A File Offset: 0x0000184A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool CloseHomeOnExit
		{
			get
			{
				return Conversions.ToBoolean(this["CloseHomeOnExit"]);
			}
			set
			{
				this["CloseHomeOnExit"] = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003660 File Offset: 0x00001860
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00003682 File Offset: 0x00001882
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool HideAltTab
		{
			get
			{
				return Conversions.ToBoolean(this["HideAltTab"]);
			}
			set
			{
				this["HideAltTab"] = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003698 File Offset: 0x00001898
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000036BA File Offset: 0x000018BA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DefaultAudio
		{
			get
			{
				return Conversions.ToString(this["DefaultAudio"]);
			}
			set
			{
				this["DefaultAudio"] = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000036CC File Offset: 0x000018CC
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000036EE File Offset: 0x000018EE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DefaultMic
		{
			get
			{
				return Conversions.ToString(this["DefaultMic"]);
			}
			set
			{
				this["DefaultMic"] = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00003700 File Offset: 0x00001900
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00003722 File Offset: 0x00001922
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool SetRiftAsDefault
		{
			get
			{
				return Conversions.ToBoolean(this["SetRiftAsDefault"]);
			}
			set
			{
				this["SetRiftAsDefault"] = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00003738 File Offset: 0x00001938
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x0000375A File Offset: 0x0000195A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int SetRiftAudioDefault
		{
			get
			{
				return Conversions.ToInteger(this["SetRiftAudioDefault"]);
			}
			set
			{
				this["SetRiftAudioDefault"] = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00003770 File Offset: 0x00001970
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00003792 File Offset: 0x00001992
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int SetRiftMicDefault
		{
			get
			{
				return Conversions.ToInteger(this["SetRiftMicDefault"]);
			}
			set
			{
				this["SetRiftMicDefault"] = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000037A8 File Offset: 0x000019A8
		// (set) Token: 0x060000BB RID: 187 RVA: 0x000037CA File Offset: 0x000019CA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool UseLocalDebugTool
		{
			get
			{
				return Conversions.ToBoolean(this["UseLocalDebugTool"]);
			}
			set
			{
				this["UseLocalDebugTool"] = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000037E0 File Offset: 0x000019E0
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00003802 File Offset: 0x00001A02
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool UseHotKeys
		{
			get
			{
				return Conversions.ToBoolean(this["UseHotKeys"]);
			}
			set
			{
				this["UseHotKeys"] = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003818 File Offset: 0x00001A18
		// (set) Token: 0x060000BF RID: 191 RVA: 0x0000383A File Offset: 0x00001A3A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int ASW
		{
			get
			{
				return Conversions.ToInteger(this["ASW"]);
			}
			set
			{
				this["ASW"] = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003850 File Offset: 0x00001A50
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00003872 File Offset: 0x00001A72
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool CloseOnX
		{
			get
			{
				return Conversions.ToBoolean(this["CloseOnX"]);
			}
			set
			{
				this["CloseOnX"] = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003888 File Offset: 0x00001A88
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x000038AA File Offset: 0x00001AAA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool NoHome
		{
			get
			{
				return Conversions.ToBoolean(this["NoHome"]);
			}
			set
			{
				this["NoHome"] = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000038C0 File Offset: 0x00001AC0
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x000038E2 File Offset: 0x00001AE2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool DisableSensorPower
		{
			get
			{
				return Conversions.ToBoolean(this["DisableSensorPower"]);
			}
			set
			{
				this["DisableSensorPower"] = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x000038F8 File Offset: 0x00001AF8
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000391A File Offset: 0x00001B1A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Not Used")]
		public string PowerPlanExit
		{
			get
			{
				return Conversions.ToString(this["PowerPlanExit"]);
			}
			set
			{
				this["PowerPlanExit"] = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000392C File Offset: 0x00001B2C
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x0000395D File Offset: 0x00001B5D
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point LibraryWindowLocation
		{
			get
			{
				object obj = this["LibraryWindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["LibraryWindowLocation"] = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00003974 File Offset: 0x00001B74
		// (set) Token: 0x060000CB RID: 203 RVA: 0x000039A5 File Offset: 0x00001BA5
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1040, 623")]
		public Size LibraryWindowSize
		{
			get
			{
				object obj = this["LibraryWindowSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["LibraryWindowSize"] = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000039BC File Offset: 0x00001BBC
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000039DE File Offset: 0x00001BDE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int ApplyPowerPlan
		{
			get
			{
				return Conversions.ToInteger(this["ApplyPowerPlan"]);
			}
			set
			{
				this["ApplyPowerPlan"] = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060000CE RID: 206 RVA: 0x000039F4 File Offset: 0x00001BF4
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00003A16 File Offset: 0x00001C16
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool UpgradeRequired
		{
			get
			{
				return Conversions.ToBoolean(this["UpgradeRequired"]);
			}
			set
			{
				this["UpgradeRequired"] = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00003A2C File Offset: 0x00001C2C
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00003A4E File Offset: 0x00001C4E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string RiftAudioGuid
		{
			get
			{
				return Conversions.ToString(this["RiftAudioGuid"]);
			}
			set
			{
				this["RiftAudioGuid"] = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00003A60 File Offset: 0x00001C60
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x00003A82 File Offset: 0x00001C82
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string RiftMicGuid
		{
			get
			{
				return Conversions.ToString(this["RiftMicGuid"]);
			}
			set
			{
				this["RiftMicGuid"] = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00003A94 File Offset: 0x00001C94
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00003AB6 File Offset: 0x00001CB6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SystemDefaultMicGuid
		{
			get
			{
				return Conversions.ToString(this["SystemDefaultMicGuid"]);
			}
			set
			{
				this["SystemDefaultMicGuid"] = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00003AC8 File Offset: 0x00001CC8
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00003AEA File Offset: 0x00001CEA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SystemDefaultAudioGuid
		{
			get
			{
				return Conversions.ToString(this["SystemDefaultAudioGuid"]);
			}
			set
			{
				this["SystemDefaultAudioGuid"] = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00003AFC File Offset: 0x00001CFC
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00003B1E File Offset: 0x00001D1E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool DisableCallback
		{
			get
			{
				return Conversions.ToBoolean(this["DisableCallback"]);
			}
			set
			{
				this["DisableCallback"] = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00003B34 File Offset: 0x00001D34
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00003B56 File Offset: 0x00001D56
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowMicNotDefaultWarning
		{
			get
			{
				return Conversions.ToBoolean(this["ShowMicNotDefaultWarning"]);
			}
			set
			{
				this["ShowMicNotDefaultWarning"] = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00003B6C File Offset: 0x00001D6C
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00003B8E File Offset: 0x00001D8E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("60")]
		public int Confidence
		{
			get
			{
				return Conversions.ToInteger(this["Confidence"]);
			}
			set
			{
				this["Confidence"] = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00003BA4 File Offset: 0x00001DA4
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00003BC6 File Offset: 0x00001DC6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartAppwatcherOnStart
		{
			get
			{
				return Conversions.ToBoolean(this["StartAppwatcherOnStart"]);
			}
			set
			{
				this["StartAppwatcherOnStart"] = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00003BDC File Offset: 0x00001DDC
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00003BFE File Offset: 0x00001DFE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool DBCheck
		{
			get
			{
				return Conversions.ToBoolean(this["DBCheck"]);
			}
			set
			{
				this["DBCheck"] = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00003C14 File Offset: 0x00001E14
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00003C36 File Offset: 0x00001E36
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public int DbgToolMethod
		{
			get
			{
				return Conversions.ToInteger(this["DbgToolMethod"]);
			}
			set
			{
				this["DbgToolMethod"] = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00003C4C File Offset: 0x00001E4C
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00003C7D File Offset: 0x00001E7D
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("10, 10")]
		public Point SteamWindowLocation
		{
			get
			{
				object obj = this["SteamWindowLocation"];
				return (obj != null) ? ((Point)obj) : default(Point);
			}
			set
			{
				this["SteamWindowLocation"] = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00003C94 File Offset: 0x00001E94
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00003CC5 File Offset: 0x00001EC5
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("652, 473")]
		public Size SteamWindowSize
		{
			get
			{
				object obj = this["SteamWindowSize"];
				return (obj != null) ? ((Size)obj) : default(Size);
			}
			set
			{
				this["SteamWindowSize"] = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00003CDC File Offset: 0x00001EDC
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00003CFE File Offset: 0x00001EFE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool AutomaticUpdateCheck
		{
			get
			{
				return Conversions.ToBoolean(this["AutomaticUpdateCheck"]);
			}
			set
			{
				this["AutomaticUpdateCheck"] = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00003D14 File Offset: 0x00001F14
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00003D36 File Offset: 0x00001F36
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public string FOVh
		{
			get
			{
				return Conversions.ToString(this["FOVh"]);
			}
			set
			{
				this["FOVh"] = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00003D48 File Offset: 0x00001F48
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00003D6A File Offset: 0x00001F6A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int HomelessEnabled
		{
			get
			{
				return Conversions.ToInteger(this["HomelessEnabled"]);
			}
			set
			{
				this["HomelessEnabled"] = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00003D80 File Offset: 0x00001F80
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00003DA2 File Offset: 0x00001FA2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0 0 0 ")]
		public string HomlessColor
		{
			get
			{
				return Conversions.ToString(this["HomlessColor"]);
			}
			set
			{
				this["HomlessColor"] = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00003DB4 File Offset: 0x00001FB4
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00003DD6 File Offset: 0x00001FD6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("None")]
		public string HomelessMusic
		{
			get
			{
				return Conversions.ToString(this["HomelessMusic"]);
			}
			set
			{
				this["HomelessMusic"] = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00003DE8 File Offset: 0x00001FE8
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00003E0A File Offset: 0x0000200A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("500")]
		public int HomelessVolume
		{
			get
			{
				return Conversions.ToInteger(this["HomelessVolume"]);
			}
			set
			{
				this["HomelessVolume"] = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003E20 File Offset: 0x00002020
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00003E42 File Offset: 0x00002042
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string HomelessHash
		{
			get
			{
				return Conversions.ToString(this["HomelessHash"]);
			}
			set
			{
				this["HomelessHash"] = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00003E54 File Offset: 0x00002054
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00003E76 File Offset: 0x00002076
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string HomeHash
		{
			get
			{
				return Conversions.ToString(this["HomeHash"]);
			}
			set
			{
				this["HomeHash"] = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00003E88 File Offset: 0x00002088
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00003EAA File Offset: 0x000020AA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool HomelessAutoPatch
		{
			get
			{
				return Conversions.ToBoolean(this["HomelessAutoPatch"]);
			}
			set
			{
				this["HomelessAutoPatch"] = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00003EC0 File Offset: 0x000020C0
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00003EE2 File Offset: 0x000020E2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool MirrorHome
		{
			get
			{
				return Conversions.ToBoolean(this["MirrorHome"]);
			}
			set
			{
				this["MirrorHome"] = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00003EF8 File Offset: 0x000020F8
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00003F1A File Offset: 0x0000211A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public int USBSuspend
		{
			get
			{
				return Conversions.ToInteger(this["USBSuspend"]);
			}
			set
			{
				this["USBSuspend"] = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00003F30 File Offset: 0x00002130
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00003F52 File Offset: 0x00002152
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool RestartServiceAfterSleep
		{
			get
			{
				return Conversions.ToBoolean(this["RestartServiceAfterSleep"]);
			}
			set
			{
				this["RestartServiceAfterSleep"] = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00003F68 File Offset: 0x00002168
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00003F8A File Offset: 0x0000218A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Next HUD,None,LEFT;Previous HUD,None,RIGHT;Next ASW Mode,None,UP;Previous ASW Mode,None,DOWN")]
		public string HotKeyCombos
		{
			get
			{
				return Conversions.ToString(this["HotKeyCombos"]);
			}
			set
			{
				this["HotKeyCombos"] = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00003F9C File Offset: 0x0000219C
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00003FBE File Offset: 0x000021BE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool HotKeyVoiceConfirmation
		{
			get
			{
				return Conversions.ToBoolean(this["HotKeyVoiceConfirmation"]);
			}
			set
			{
				this["HotKeyVoiceConfirmation"] = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00003FD4 File Offset: 0x000021D4
		// (set) Token: 0x06000105 RID: 261 RVA: 0x00003FF6 File Offset: 0x000021F6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool VoiceActivationVoiceContinous
		{
			get
			{
				return Conversions.ToBoolean(this["VoiceActivationVoiceContinous"]);
			}
			set
			{
				this["VoiceActivationVoiceContinous"] = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000106 RID: 262 RVA: 0x0000400C File Offset: 0x0000220C
		// (set) Token: 0x06000107 RID: 263 RVA: 0x0000402E File Offset: 0x0000222E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool VoiceActivationVoiceRepeated
		{
			get
			{
				return Conversions.ToBoolean(this["VoiceActivationVoiceRepeated"]);
			}
			set
			{
				this["VoiceActivationVoiceRepeated"] = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004044 File Offset: 0x00002244
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00004066 File Offset: 0x00002266
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool VoiceActivationKeyContinous
		{
			get
			{
				return Conversions.ToBoolean(this["VoiceActivationKeyContinous"]);
			}
			set
			{
				this["VoiceActivationKeyContinous"] = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000407C File Offset: 0x0000227C
		// (set) Token: 0x0600010B RID: 267 RVA: 0x0000409E File Offset: 0x0000229E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool VoiceActivationKeyPush
		{
			get
			{
				return Conversions.ToBoolean(this["VoiceActivationKeyPush"]);
			}
			set
			{
				this["VoiceActivationKeyPush"] = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600010C RID: 268 RVA: 0x000040B4 File Offset: 0x000022B4
		// (set) Token: 0x0600010D RID: 269 RVA: 0x000040D6 File Offset: 0x000022D6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public string SetFallbackMicDefaultCommDev
		{
			get
			{
				return Conversions.ToString(this["SetFallbackMicDefaultCommDev"]);
			}
			set
			{
				this["SetFallbackMicDefaultCommDev"] = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600010E RID: 270 RVA: 0x000040E8 File Offset: 0x000022E8
		// (set) Token: 0x0600010F RID: 271 RVA: 0x0000410A File Offset: 0x0000230A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string KeyboardVoiceActivationKey
		{
			get
			{
				return Conversions.ToString(this["KeyboardVoiceActivationKey"]);
			}
			set
			{
				this["KeyboardVoiceActivationKey"] = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000110 RID: 272 RVA: 0x0000411C File Offset: 0x0000231C
		// (set) Token: 0x06000111 RID: 273 RVA: 0x0000413E File Offset: 0x0000233E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string JoystickVoiceActivationButton
		{
			get
			{
				return Conversions.ToString(this["JoystickVoiceActivationButton"]);
			}
			set
			{
				this["JoystickVoiceActivationButton"] = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00004150 File Offset: 0x00002350
		// (set) Token: 0x06000113 RID: 275 RVA: 0x00004172 File Offset: 0x00002372
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string JoystickDeviceName
		{
			get
			{
				return Conversions.ToString(this["JoystickDeviceName"]);
			}
			set
			{
				this["JoystickDeviceName"] = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00004184 File Offset: 0x00002384
		// (set) Token: 0x06000115 RID: 277 RVA: 0x000041A6 File Offset: 0x000023A6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool JoystickActivationKeyContinous
		{
			get
			{
				return Conversions.ToBoolean(this["JoystickActivationKeyContinous"]);
			}
			set
			{
				this["JoystickActivationKeyContinous"] = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000116 RID: 278 RVA: 0x000041BC File Offset: 0x000023BC
		// (set) Token: 0x06000117 RID: 279 RVA: 0x000041DE File Offset: 0x000023DE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool JoystickActivationKeyPush
		{
			get
			{
				return Conversions.ToBoolean(this["JoystickActivationKeyPush"]);
			}
			set
			{
				this["JoystickActivationKeyPush"] = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000041F4 File Offset: 0x000023F4
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00004216 File Offset: 0x00002416
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool DisableVoiceControlAudioFeedback
		{
			get
			{
				return Conversions.ToBoolean(this["DisableVoiceControlAudioFeedback"]);
			}
			set
			{
				this["DisableVoiceControlAudioFeedback"] = value;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600011A RID: 282 RVA: 0x0000422C File Offset: 0x0000242C
		// (set) Token: 0x0600011B RID: 283 RVA: 0x0000424E File Offset: 0x0000244E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DefaultComm
		{
			get
			{
				return Conversions.ToString(this["DefaultComm"]);
			}
			set
			{
				this["DefaultComm"] = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00004260 File Offset: 0x00002460
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00004282 File Offset: 0x00002482
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SystemDefaultCommGuid
		{
			get
			{
				return Conversions.ToString(this["SystemDefaultCommGuid"]);
			}
			set
			{
				this["SystemDefaultCommGuid"] = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00004294 File Offset: 0x00002494
		// (set) Token: 0x0600011F RID: 287 RVA: 0x000042B6 File Offset: 0x000024B6
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SystemDefaultCommAudioGuid
		{
			get
			{
				return Conversions.ToString(this["SystemDefaultCommAudioGuid"]);
			}
			set
			{
				this["SystemDefaultCommAudioGuid"] = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000042C8 File Offset: 0x000024C8
		// (set) Token: 0x06000121 RID: 289 RVA: 0x000042EA File Offset: 0x000024EA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DefaultCommAudio
		{
			get
			{
				return Conversions.ToString(this["DefaultCommAudio"]);
			}
			set
			{
				this["DefaultCommAudio"] = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000042FC File Offset: 0x000024FC
		// (set) Token: 0x06000123 RID: 291 RVA: 0x0000431E File Offset: 0x0000251E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string PowerPlanCurrent
		{
			get
			{
				return Conversions.ToString(this["PowerPlanCurrent"]);
			}
			set
			{
				this["PowerPlanCurrent"] = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004330 File Offset: 0x00002530
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00004352 File Offset: 0x00002552
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetAudioOnStart
		{
			get
			{
				return Conversions.ToString(this["SetAudioOnStart"]);
			}
			set
			{
				this["SetAudioOnStart"] = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00004364 File Offset: 0x00002564
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00004386 File Offset: 0x00002586
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetMicOnStart
		{
			get
			{
				return Conversions.ToString(this["SetMicOnStart"]);
			}
			set
			{
				this["SetMicOnStart"] = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00004398 File Offset: 0x00002598
		// (set) Token: 0x06000129 RID: 297 RVA: 0x000043BA File Offset: 0x000025BA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetAudioCommOnStart
		{
			get
			{
				return Conversions.ToString(this["SetAudioCommOnStart"]);
			}
			set
			{
				this["SetAudioCommOnStart"] = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600012A RID: 298 RVA: 0x000043CC File Offset: 0x000025CC
		// (set) Token: 0x0600012B RID: 299 RVA: 0x000043EE File Offset: 0x000025EE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetMicCommOnStart
		{
			get
			{
				return Conversions.ToString(this["SetMicCommOnStart"]);
			}
			set
			{
				this["SetMicCommOnStart"] = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00004400 File Offset: 0x00002600
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00004422 File Offset: 0x00002622
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetAudioOnStartGuid
		{
			get
			{
				return Conversions.ToString(this["SetAudioOnStartGuid"]);
			}
			set
			{
				this["SetAudioOnStartGuid"] = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00004434 File Offset: 0x00002634
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00004456 File Offset: 0x00002656
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetMicOnStartGuid
		{
			get
			{
				return Conversions.ToString(this["SetMicOnStartGuid"]);
			}
			set
			{
				this["SetMicOnStartGuid"] = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00004468 File Offset: 0x00002668
		// (set) Token: 0x06000131 RID: 305 RVA: 0x0000448A File Offset: 0x0000268A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetAudioCommOnStartGuid
		{
			get
			{
				return Conversions.ToString(this["SetAudioCommOnStartGuid"]);
			}
			set
			{
				this["SetAudioCommOnStartGuid"] = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000132 RID: 306 RVA: 0x0000449C File Offset: 0x0000269C
		// (set) Token: 0x06000133 RID: 307 RVA: 0x000044BE File Offset: 0x000026BE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SetMicCommOnStartGuid
		{
			get
			{
				return Conversions.ToString(this["SetMicCommOnStartGuid"]);
			}
			set
			{
				this["SetMicCommOnStartGuid"] = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000134 RID: 308 RVA: 0x000044D0 File Offset: 0x000026D0
		// (set) Token: 0x06000135 RID: 309 RVA: 0x000044F2 File Offset: 0x000026F2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public string FOVv
		{
			get
			{
				return Conversions.ToString(this["FOVv"]);
			}
			set
			{
				this["FOVv"] = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00004504 File Offset: 0x00002704
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00004526 File Offset: 0x00002726
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool AdaptiveGPUScaling
		{
			get
			{
				return Conversions.ToBoolean(this["AdaptiveGPUScaling"]);
			}
			set
			{
				this["AdaptiveGPUScaling"] = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000138 RID: 312 RVA: 0x0000453C File Offset: 0x0000273C
		// (set) Token: 0x06000139 RID: 313 RVA: 0x0000455E File Offset: 0x0000275E
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("2000")]
		public int SleepAfterServiceStart
		{
			get
			{
				return Conversions.ToInteger(this["SleepAfterServiceStart"]);
			}
			set
			{
				this["SleepAfterServiceStart"] = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00004574 File Offset: 0x00002774
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00004596 File Offset: 0x00002796
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("2000")]
		public string SleepAfterHomeStart
		{
			get
			{
				return Conversions.ToString(this["SleepAfterHomeStart"]);
			}
			set
			{
				this["SleepAfterHomeStart"] = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600013C RID: 316 RVA: 0x000045A8 File Offset: 0x000027A8
		// (set) Token: 0x0600013D RID: 317 RVA: 0x000045CA File Offset: 0x000027CA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DesktopResolution
		{
			get
			{
				return Conversions.ToString(this["DesktopResolution"]);
			}
			set
			{
				this["DesktopResolution"] = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600013E RID: 318 RVA: 0x000045DC File Offset: 0x000027DC
		// (set) Token: 0x0600013F RID: 319 RVA: 0x000045FE File Offset: 0x000027FE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Normal")]
		public string OVRSrvPrio
		{
			get
			{
				return Conversions.ToString(this["OVRSrvPrio"]);
			}
			set
			{
				this["OVRSrvPrio"] = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00004610 File Offset: 0x00002810
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00004632 File Offset: 0x00002832
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public string ForceMipmap
		{
			get
			{
				return Conversions.ToString(this["ForceMipmap"]);
			}
			set
			{
				this["ForceMipmap"] = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00004644 File Offset: 0x00002844
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00004666 File Offset: 0x00002866
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public string OffsetMipmap
		{
			get
			{
				return Conversions.ToString(this["OffsetMipmap"]);
			}
			set
			{
				this["OffsetMipmap"] = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00004678 File Offset: 0x00002878
		// (set) Token: 0x06000145 RID: 325 RVA: 0x0000469A File Offset: 0x0000289A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StopOVRHome
		{
			get
			{
				return Conversions.ToBoolean(this["StopOVRHome"]);
			}
			set
			{
				this["StopOVRHome"] = value;
			}
		}

		// Token: 0x04000008 RID: 8
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());

		// Token: 0x04000009 RID: 9
		private static bool addedHandler;

		// Token: 0x0400000A RID: 10
		private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());
	}
}
