using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.MyNameSpace;

namespace OculusTrayTool;

[DesignerGenerated]
public class FrmMain : Form
{
	private delegate void TimerStart();

	private delegate void AppTimerStart();

	public delegate void AddToListboxAndScrollDelegate(string text);

	public delegate void UpdateTabDelegate();

	public delegate void ShowUpdateToastDelegate();

	public delegate void EnableShowHomeMenuDelegate();

	public delegate void DisableShowHomeMenuDelegate();

	public delegate void SetTitleIsListeningDelegate();

	public delegate void RemoveTitleIsListeningDelegate();

	public delegate void SetToolTipDelegate(string text, Control crtl);

	[CompilerGenerated]
	internal sealed class _Closure_0024__136_002D0
	{
		public string _0024VB_0024Local_fov;

		public string _0024VB_0024Local_forcemipmap;

		public string _0024VB_0024Local_offsetmipmap;

		public _Closure_0024__136_002D0(_Closure_0024__136_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_fov = arg0._0024VB_0024Local_fov;
				_0024VB_0024Local_forcemipmap = arg0._0024VB_0024Local_forcemipmap;
				_0024VB_0024Local_offsetmipmap = arg0._0024VB_0024Local_offsetmipmap;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			RunCommand.Run_debug_tool_fov(_0024VB_0024Local_fov);
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			RunCommand.Run_debug_tool_force_mipmap(_0024VB_0024Local_forcemipmap.ToLower());
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			RunCommand.Run_debug_tool_offset_mipmap(_0024VB_0024Local_offsetmipmap);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__136_002D1
	{
		public short _0024VB_0024Local_yRes;

		public short _0024VB_0024Local_xRes;

		public _Closure_0024__136_002D1(_Closure_0024__136_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_yRes = arg0._0024VB_0024Local_yRes;
				_0024VB_0024Local_xRes = arg0._0024VB_0024Local_xRes;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__10()
		{
			Resolution.ChangeDisplaySettings(_0024VB_0024Local_yRes, _0024VB_0024Local_xRes);
		}
	}

	public static object lockObject;

	private Resizer rs;

	public bool Is64Bit;

	public Dictionary<string, string> profileList;

	public Dictionary<string, string> profileTimerList;

	public Dictionary<string, string> profileASWList;

	public Dictionary<string, string> profilePriorityList;

	public string aswProfileMode;

	public List<string> profileNames;

	public Dictionary<string, string> profileDisplayNames;

	public Dictionary<string, string> profileAswDelay;

	public Dictionary<string, string> profileCpuDelay;

	public Dictionary<string, string> profilePaths;

	public Dictionary<string, string> profileMirror;

	public Dictionary<string, string> profileAGPS;

	public Dictionary<string, string> profileFOV;

	public Dictionary<string, string> profileForceMipMap;

	public Dictionary<string, string> profileOffsetMipMap;

	public string runningApp;

	public bool hasError;

	public bool hasWarning;

	private string ssValue;

	private bool OculusServiceFound;

	public CultureInfo customCulture;

	public Dictionary<string, string> power_plans;

	public bool debug;

	public bool RiftAudioCanceled;

	public object scaleX;

	public object scaleY;

	public string OculusPath;

	public bool HomeIsRunning;

	private bool OVRIsRunning;

	public bool spoofid;

	private string cpuid;

	public string CurrentSS;

	public bool isElevated;

	public bool loadingDone;

	public string SteamPath;

	public List<string> OculusSoftwarePaths;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Watcher")]
	private ManagementEventWatcher _Watcher;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MinimizeHomeWatcher")]
	private ManagementEventWatcher _MinimizeHomeWatcher;

	public TabPage UpdateTab;

	public Collection colRemovedTabs;

	public string steamvr;

	public string OculusAppVersion;

	private string appName;

	public string runningapp_displayname;

	private System.Windows.Forms.Timer Hometimer;

	public System.Timers.Timer pTimer;

	public bool ManualStart;

	private bool restartInDBG;

	public List<string> ignoredApps;

	public List<string> includedApps;

	public List<string> voiceProfileNames;

	public static FrmMain fmain;

	private bool ovrDown;

	public string Update_URL;

	public string UpdateTest_URL;

	public bool voiceSettingsLoaded;

	private System.Timers.Timer _Home2Timer;

	private bool restartHome;

	public string vrManifestFileName;

	public System.Timers.Timer mirrorTimer;

	public bool StartingUp;

	private List<string> AswToggle;

	private System.Timers.Timer cpuTimer;

	private System.Timers.Timer aswTimer;

	private BackgroundWorker AppWatchWorker;

	public Dictionary<string, string> AllAppsList;

	private bool NoProfileFound;

	private int numLogMessages;

	public string runningAppExe;

	public int pid;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("kbHook")]
	private KeyboardHook _kbHook;

	public bool HomeIsMirrored;

	public Dictionary<string, string> FuncToKeyDictionary;

	private List<string> NextASW;

	private int CurrentASW;

	private List<string> NextHUD;

	private int CurrentHUD;

	public bool isCopy;

	private string DSep;

	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckStartMin")]
	private CheckBox _CheckStartMin;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckStartWindows")]
	private CheckBox _CheckStartWindows;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("NotifyIcon1")]
	private NotifyIcon _NotifyIcon1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ButtonStartOVR")]
	private Button _ButtonStartOVR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem1")]
	private ToolStripMenuItem _ToolStripMenuItem1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem2")]
	private ToolStripMenuItem _ToolStripMenuItem2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ButtonStopOVR")]
	private Button _ButtonStopOVR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckStartService")]
	private CheckBox _CheckStartService;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckLaunchHome")]
	private CheckBox _CheckLaunchHome;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckStopService")]
	private CheckBox _CheckStopService;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ButtonRestartOVR")]
	private Button _ButtonRestartOVR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckLaunchHomeTool")]
	private CheckBox _CheckLaunchHomeTool;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckCloseHome")]
	private CheckBox _CheckCloseHome;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBoxAltTab")]
	private CheckBox _CheckBoxAltTab;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckRiftAudio")]
	private CheckBox _CheckRiftAudio;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("OculusHomeWatcher")]
	private System.Windows.Forms.Timer _OculusHomeWatcher;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem3")]
	private ToolStripMenuItem _ToolStripMenuItem3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckSpoofCPU")]
	private CheckBox _CheckSpoofCPU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripStartOVR")]
	private ToolStripMenuItem _ToolStripStartOVR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripStopOVR")]
	private ToolStripMenuItem _ToolStripStopOVR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripRestartOVR")]
	private ToolStripMenuItem _ToolStripRestartOVR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem4")]
	private ToolStripMenuItem _ToolStripMenuItem4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("NotificationTimer")]
	private System.Windows.Forms.Timer _NotificationTimer;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DotNetBarTabcontrol1")]
	private DotNetBarTabcontrol _DotNetBarTabcontrol1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnVoice")]
	private Button _BtnVoice;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboSSstart")]
	private ComboBox _ComboSSstart;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnProfiles")]
	private Button _BtnProfiles;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboVoice")]
	private ComboBox _ComboVoice;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("HotKeysCheckBox")]
	private CheckBox _HotKeysCheckBox;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboUSBsusp")]
	private ComboBox _ComboUSBsusp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboPowerPlanStart")]
	private ComboBox _ComboPowerPlanStart;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckMinimizeOnX")]
	private CheckBox _CheckMinimizeOnX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TrackBar1")]
	private TrackBar _TrackBar1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("HometoTrayTimer")]
	private System.Windows.Forms.Timer _HometoTrayTimer;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckSendHomeToTray")]
	private CheckBox _CheckSendHomeToTray;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckSendHomeToTrayOnStart")]
	private CheckBox _CheckSendHomeToTrayOnStart;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckLocalDebug")]
	private CheckBox _CheckLocalDebug;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckStartWatcher")]
	private CheckBox _CheckStartWatcher;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button5")]
	private Button _Button5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckSensorPower")]
	private CheckBox _CheckSensorPower;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboPowerPlanExit")]
	private ComboBox _ComboPowerPlanExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnConfigureAudio")]
	private Button _BtnConfigureAudio;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboApplyPlan")]
	private ComboBox _ComboApplyPlan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button9")]
	private Button _Button9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button8")]
	private Button _Button8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox2")]
	private PictureBox _PictureBox2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBoxCheckForUpdates")]
	private CheckBox _CheckBoxCheckForUpdates;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboHomless")]
	private ComboBox _ComboHomless;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnHomless")]
	private Button _BtnHomless;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UpdateTimer")]
	private System.Windows.Forms.Timer _UpdateTimer;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuShowHome")]
	private ToolStripMenuItem _ToolStripMenuShowHome;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboVisualHUD")]
	private ComboBox _ComboVisualHUD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboMirrorHome")]
	private ComboBox _ComboMirrorHome;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckRestartSleep")]
	private CheckBox _CheckRestartSleep;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSteamImport")]
	private Button _BtnSteamImport;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("NotifyIcon3")]
	private NotifyIcon _NotifyIcon3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnConfigureHotKeys")]
	private Button _BtnConfigureHotKeys;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ClearLogToolStripMenuItem")]
	private ToolStripMenuItem _ClearLogToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("OpenLogToolStripMenuItem")]
	private ToolStripMenuItem _OpenLogToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLibrary")]
	private Button _BtnLibrary;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PowerPlanTimer")]
	private System.Windows.Forms.Timer _PowerPlanTimer;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox3")]
	private ComboBox _ComboBox3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox4")]
	private ComboBox _ComboBox4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button10")]
	private Button _Button10;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button11")]
	private Button _Button11;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button12")]
	private Button _Button12;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnRemoveAllProfiles")]
	private Button _BtnRemoveAllProfiles;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox5")]
	private ComboBox _ComboBox5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboOVRPrio")]
	private ComboBox _ComboOVRPrio;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button6")]
	private Button _Button6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox8")]
	private ComboBox _ComboBox8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox9")]
	private ComboBox _ComboBox9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckStopServiceHome")]
	private CheckBox _CheckStopServiceHome;

	private virtual ManagementEventWatcher Watcher
	{
		[CompilerGenerated]
		get
		{
			return _Watcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventArrivedEventHandler value2 = Watcher_EventArrived;
			ManagementEventWatcher watcher = _Watcher;
			if (watcher != null)
			{
				watcher.EventArrived -= value2;
			}
			_Watcher = value;
			watcher = _Watcher;
			if (watcher != null)
			{
				watcher.EventArrived += value2;
			}
		}
	}

	public virtual ManagementEventWatcher MinimizeHomeWatcher
	{
		[CompilerGenerated]
		get
		{
			return _MinimizeHomeWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventArrivedEventHandler value2 = MinimizeHomeWatcher_EventArrived;
			ManagementEventWatcher minimizeHomeWatcher = _MinimizeHomeWatcher;
			if (minimizeHomeWatcher != null)
			{
				minimizeHomeWatcher.EventArrived -= value2;
			}
			_MinimizeHomeWatcher = value;
			minimizeHomeWatcher = _MinimizeHomeWatcher;
			if (minimizeHomeWatcher != null)
			{
				minimizeHomeWatcher.EventArrived += value2;
			}
		}
	}

	public virtual KeyboardHook kbHook
	{
		[CompilerGenerated]
		get
		{
			return _kbHook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyboardHook.KeyDownEventHandler obj = kbHook_KeyDown;
			KeyboardHook.KeyUpEventHandler obj2 = kbHook_KeyUp;
			if (_kbHook != null)
			{
				KeyboardHook.KeyDown -= obj;
				KeyboardHook.KeyUp -= obj2;
			}
			_kbHook = value;
			if (_kbHook != null)
			{
				KeyboardHook.KeyDown += obj;
				KeyboardHook.KeyUp += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckStartMin
	{
		[CompilerGenerated]
		get
		{
			return _CheckStartMin;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckStartMin_CheckedChanged;
			CheckBox checkStartMin = _CheckStartMin;
			if (checkStartMin != null)
			{
				checkStartMin.CheckedChanged -= value2;
			}
			_CheckStartMin = value;
			checkStartMin = _CheckStartMin;
			if (checkStartMin != null)
			{
				checkStartMin.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckStartWindows
	{
		[CompilerGenerated]
		get
		{
			return _CheckStartWindows;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckStartWindows_CheckedChanged;
			CheckBox checkStartWindows = _CheckStartWindows;
			if (checkStartWindows != null)
			{
				checkStartWindows.CheckedChanged -= value2;
			}
			_CheckStartWindows = value;
			checkStartWindows = _CheckStartWindows;
			if (checkStartWindows != null)
			{
				checkStartWindows.CheckedChanged += value2;
			}
		}
	}

	internal virtual NotifyIcon NotifyIcon1
	{
		[CompilerGenerated]
		get
		{
			return _NotifyIcon1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NotifyIcon1_DoubleClick;
			NotifyIcon notifyIcon = _NotifyIcon1;
			if (notifyIcon != null)
			{
				notifyIcon.DoubleClick -= value2;
			}
			_NotifyIcon1 = value;
			notifyIcon = _NotifyIcon1;
			if (notifyIcon != null)
			{
				notifyIcon.DoubleClick += value2;
			}
		}
	}

	internal virtual Button ButtonStartOVR
	{
		[CompilerGenerated]
		get
		{
			return _ButtonStartOVR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ButtonStartOVR_Click;
			Button buttonStartOVR = _ButtonStartOVR;
			if (buttonStartOVR != null)
			{
				buttonStartOVR.Click -= value2;
			}
			_ButtonStartOVR = value;
			buttonStartOVR = _ButtonStartOVR;
			if (buttonStartOVR != null)
			{
				buttonStartOVR.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelServiceStatus")]
	internal virtual Label LabelServiceStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ContextMenuStrip1")]
	internal virtual ContextMenuStrip ContextMenuStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem1_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem1 = value;
			toolStripMenuItem = _ToolStripMenuItem1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem2
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem2_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem2 = value;
			toolStripMenuItem = _ToolStripMenuItem2;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ListBox1")]
	internal virtual ListBox ListBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolTip")]
	internal virtual ToolTip ToolTip
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button ButtonStopOVR
	{
		[CompilerGenerated]
		get
		{
			return _ButtonStopOVR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ButtonStopOVR_Click;
			Button buttonStopOVR = _ButtonStopOVR;
			if (buttonStopOVR != null)
			{
				buttonStopOVR.Click -= value2;
			}
			_ButtonStopOVR = value;
			buttonStopOVR = _ButtonStopOVR;
			if (buttonStopOVR != null)
			{
				buttonStopOVR.Click += value2;
			}
		}
	}

	internal virtual CheckBox CheckStartService
	{
		[CompilerGenerated]
		get
		{
			return _CheckStartService;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckStartService_CheckedChanged;
			CheckBox checkStartService = _CheckStartService;
			if (checkStartService != null)
			{
				checkStartService.CheckedChanged -= value2;
			}
			_CheckStartService = value;
			checkStartService = _CheckStartService;
			if (checkStartService != null)
			{
				checkStartService.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckLaunchHome
	{
		[CompilerGenerated]
		get
		{
			return _CheckLaunchHome;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckLaunchHome_CheckedChanged;
			CheckBox checkLaunchHome = _CheckLaunchHome;
			if (checkLaunchHome != null)
			{
				checkLaunchHome.CheckedChanged -= value2;
			}
			_CheckLaunchHome = value;
			checkLaunchHome = _CheckLaunchHome;
			if (checkLaunchHome != null)
			{
				checkLaunchHome.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckStopService
	{
		[CompilerGenerated]
		get
		{
			return _CheckStopService;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckStopService_CheckedChanged;
			CheckBox checkStopService = _CheckStopService;
			if (checkStopService != null)
			{
				checkStopService.CheckedChanged -= value2;
			}
			_CheckStopService = value;
			checkStopService = _CheckStopService;
			if (checkStopService != null)
			{
				checkStopService.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual GroupBox GroupBox4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button ButtonRestartOVR
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRestartOVR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ButtonRestartOVR_Click;
			Button buttonRestartOVR = _ButtonRestartOVR;
			if (buttonRestartOVR != null)
			{
				buttonRestartOVR.Click -= value2;
			}
			_ButtonRestartOVR = value;
			buttonRestartOVR = _ButtonRestartOVR;
			if (buttonRestartOVR != null)
			{
				buttonRestartOVR.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label11")]
	internal virtual Label Label11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckLaunchHomeTool
	{
		[CompilerGenerated]
		get
		{
			return _CheckLaunchHomeTool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckLaunchHomeTool_CheckedChanged;
			CheckBox checkLaunchHomeTool = _CheckLaunchHomeTool;
			if (checkLaunchHomeTool != null)
			{
				checkLaunchHomeTool.CheckedChanged -= value2;
			}
			_CheckLaunchHomeTool = value;
			checkLaunchHomeTool = _CheckLaunchHomeTool;
			if (checkLaunchHomeTool != null)
			{
				checkLaunchHomeTool.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckCloseHome
	{
		[CompilerGenerated]
		get
		{
			return _CheckCloseHome;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckCloseHome_CheckedChanged;
			CheckBox checkCloseHome = _CheckCloseHome;
			if (checkCloseHome != null)
			{
				checkCloseHome.CheckedChanged -= value2;
			}
			_CheckCloseHome = value;
			checkCloseHome = _CheckCloseHome;
			if (checkCloseHome != null)
			{
				checkCloseHome.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckBoxAltTab
	{
		[CompilerGenerated]
		get
		{
			return _CheckBoxAltTab;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBoxAltTab_CheckedChanged;
			CheckBox checkBoxAltTab = _CheckBoxAltTab;
			if (checkBoxAltTab != null)
			{
				checkBoxAltTab.CheckedChanged -= value2;
			}
			_CheckBoxAltTab = value;
			checkBoxAltTab = _CheckBoxAltTab;
			if (checkBoxAltTab != null)
			{
				checkBoxAltTab.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckRiftAudio
	{
		[CompilerGenerated]
		get
		{
			return _CheckRiftAudio;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckRiftAudio_CheckedChanged;
			CheckBox checkRiftAudio = _CheckRiftAudio;
			if (checkRiftAudio != null)
			{
				checkRiftAudio.CheckedChanged -= value2;
			}
			_CheckRiftAudio = value;
			checkRiftAudio = _CheckRiftAudio;
			if (checkRiftAudio != null)
			{
				checkRiftAudio.CheckedChanged += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.Timer OculusHomeWatcher
	{
		[CompilerGenerated]
		get
		{
			return _OculusHomeWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OculusHomeWatcher_Tick;
			System.Windows.Forms.Timer oculusHomeWatcher = _OculusHomeWatcher;
			if (oculusHomeWatcher != null)
			{
				oculusHomeWatcher.Tick -= value2;
			}
			_OculusHomeWatcher = value;
			oculusHomeWatcher = _OculusHomeWatcher;
			if (oculusHomeWatcher != null)
			{
				oculusHomeWatcher.Tick += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem3
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem3_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem3;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem3 = value;
			toolStripMenuItem = _ToolStripMenuItem3;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual Label Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckSpoofCPU
	{
		[CompilerGenerated]
		get
		{
			return _CheckSpoofCPU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckSpoofCPU_CheckedChanged;
			CheckBox checkSpoofCPU = _CheckSpoofCPU;
			if (checkSpoofCPU != null)
			{
				checkSpoofCPU.CheckedChanged -= value2;
			}
			_CheckSpoofCPU = value;
			checkSpoofCPU = _CheckSpoofCPU;
			if (checkSpoofCPU != null)
			{
				checkSpoofCPU.CheckedChanged += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripStartOVR
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripStartOVR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripStartOVR_Click;
			ToolStripMenuItem toolStripStartOVR = _ToolStripStartOVR;
			if (toolStripStartOVR != null)
			{
				toolStripStartOVR.Click -= value2;
			}
			_ToolStripStartOVR = value;
			toolStripStartOVR = _ToolStripStartOVR;
			if (toolStripStartOVR != null)
			{
				toolStripStartOVR.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripStopOVR
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripStopOVR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem5_Click;
			ToolStripMenuItem toolStripStopOVR = _ToolStripStopOVR;
			if (toolStripStopOVR != null)
			{
				toolStripStopOVR.Click -= value2;
			}
			_ToolStripStopOVR = value;
			toolStripStopOVR = _ToolStripStopOVR;
			if (toolStripStopOVR != null)
			{
				toolStripStopOVR.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripRestartOVR
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripRestartOVR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem6_Click;
			ToolStripMenuItem toolStripRestartOVR = _ToolStripRestartOVR;
			if (toolStripRestartOVR != null)
			{
				toolStripRestartOVR.Click -= value2;
			}
			_ToolStripRestartOVR = value;
			toolStripRestartOVR = _ToolStripRestartOVR;
			if (toolStripRestartOVR != null)
			{
				toolStripRestartOVR.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox6")]
	internal virtual GroupBox GroupBox6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ContextMenuStrip2")]
	internal virtual ContextMenuStrip ContextMenuStrip2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem4
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem4_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem4;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem4 = value;
			toolStripMenuItem = _ToolStripMenuItem4;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.Timer NotificationTimer
	{
		[CompilerGenerated]
		get
		{
			return _NotificationTimer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NotificationTimer_Tick;
			System.Windows.Forms.Timer notificationTimer = _NotificationTimer;
			if (notificationTimer != null)
			{
				notificationTimer.Tick -= value2;
			}
			_NotificationTimer = value;
			notificationTimer = _NotificationTimer;
			if (notificationTimer != null)
			{
				notificationTimer.Tick += value2;
			}
		}
	}

	internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1
	{
		[CompilerGenerated]
		get
		{
			return _DotNetBarTabcontrol1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DotNetBarTabcontrol1_SelectedIndexChanged;
			DotNetBarTabcontrol dotNetBarTabcontrol = _DotNetBarTabcontrol1;
			if (dotNetBarTabcontrol != null)
			{
				dotNetBarTabcontrol.SelectedIndexChanged -= value2;
			}
			_DotNetBarTabcontrol1 = value;
			dotNetBarTabcontrol = _DotNetBarTabcontrol1;
			if (dotNetBarTabcontrol != null)
			{
				dotNetBarTabcontrol.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button BtnVoice
	{
		[CompilerGenerated]
		get
		{
			return _BtnVoice;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnVoice_Click;
			Button btnVoice = _BtnVoice;
			if (btnVoice != null)
			{
				btnVoice.Click -= value2;
			}
			_BtnVoice = value;
			btnVoice = _BtnVoice;
			if (btnVoice != null)
			{
				btnVoice.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboSSstart
	{
		[CompilerGenerated]
		get
		{
			return _ComboSSstart;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboSSstart_SelectedIndexChanged;
			KeyPressEventHandler value3 = ComboSSstart_KeyPress;
			ComboBox comboSSstart = _ComboSSstart;
			if (comboSSstart != null)
			{
				comboSSstart.SelectedIndexChanged -= value2;
				comboSSstart.KeyPress -= value3;
			}
			_ComboSSstart = value;
			comboSSstart = _ComboSSstart;
			if (comboSSstart != null)
			{
				comboSSstart.SelectedIndexChanged += value2;
				comboSSstart.KeyPress += value3;
			}
		}
	}

	internal virtual Button BtnProfiles
	{
		[CompilerGenerated]
		get
		{
			return _BtnProfiles;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnProfiles_Click;
			Button btnProfiles = _BtnProfiles;
			if (btnProfiles != null)
			{
				btnProfiles.Click -= value2;
			}
			_BtnProfiles = value;
			btnProfiles = _BtnProfiles;
			if (btnProfiles != null)
			{
				btnProfiles.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboVoice
	{
		[CompilerGenerated]
		get
		{
			return _ComboVoice;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboVoice_SelectedIndexChanged;
			ComboBox comboVoice = _ComboVoice;
			if (comboVoice != null)
			{
				comboVoice.SelectedIndexChanged -= value2;
			}
			_ComboVoice = value;
			comboVoice = _ComboVoice;
			if (comboVoice != null)
			{
				comboVoice.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox HotKeysCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _HotKeysCheckBox;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HotKeysCheckBox_CheckedChanged;
			CheckBox hotKeysCheckBox = _HotKeysCheckBox;
			if (hotKeysCheckBox != null)
			{
				hotKeysCheckBox.CheckedChanged -= value2;
			}
			_HotKeysCheckBox = value;
			hotKeysCheckBox = _HotKeysCheckBox;
			if (hotKeysCheckBox != null)
			{
				hotKeysCheckBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual GroupBox GroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboUSBsusp
	{
		[CompilerGenerated]
		get
		{
			return _ComboUSBsusp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboUSBsusp_SelectedIndexChanged;
			ComboBox comboUSBsusp = _ComboUSBsusp;
			if (comboUSBsusp != null)
			{
				comboUSBsusp.SelectedIndexChanged -= value2;
			}
			_ComboUSBsusp = value;
			comboUSBsusp = _ComboUSBsusp;
			if (comboUSBsusp != null)
			{
				comboUSBsusp.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboPowerPlanStart
	{
		[CompilerGenerated]
		get
		{
			return _ComboPowerPlanStart;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboPowerPlan_SelectedIndexChanged;
			ComboBox comboPowerPlanStart = _ComboPowerPlanStart;
			if (comboPowerPlanStart != null)
			{
				comboPowerPlanStart.SelectedIndexChanged -= value2;
			}
			_ComboPowerPlanStart = value;
			comboPowerPlanStart = _ComboPowerPlanStart;
			if (comboPowerPlanStart != null)
			{
				comboPowerPlanStart.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage6")]
	internal virtual TabPage TabPage6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckMinimizeOnX
	{
		[CompilerGenerated]
		get
		{
			return _CheckMinimizeOnX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckMinimizeOnX_CheckedChanged;
			CheckBox checkMinimizeOnX = _CheckMinimizeOnX;
			if (checkMinimizeOnX != null)
			{
				checkMinimizeOnX.CheckedChanged -= value2;
			}
			_CheckMinimizeOnX = value;
			checkMinimizeOnX = _CheckMinimizeOnX;
			if (checkMinimizeOnX != null)
			{
				checkMinimizeOnX.CheckedChanged += value2;
			}
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PictureBox1_Click;
			PictureBox pictureBox = _PictureBox1;
			if (pictureBox != null)
			{
				pictureBox.Click -= value2;
			}
			_PictureBox1 = value;
			pictureBox = _PictureBox1;
			if (pictureBox != null)
			{
				pictureBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox9")]
	internal virtual GroupBox GroupBox9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox14")]
	internal virtual GroupBox GroupBox14
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel2")]
	internal virtual DBLayoutPanel DbLayoutPanel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel4")]
	internal virtual DBLayoutPanel DbLayoutPanel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel5")]
	internal virtual DBLayoutPanel DbLayoutPanel5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TrackBar TrackBar1
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TrackBar1_Scroll;
			TrackBar trackBar = _TrackBar1;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			_TrackBar1 = value;
			trackBar = _TrackBar1;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label14")]
	internal virtual Label Label14
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel6")]
	internal virtual DBLayoutPanel DbLayoutPanel6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel7")]
	internal virtual DBLayoutPanel DbLayoutPanel7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel8")]
	internal virtual DBLayoutPanel DbLayoutPanel8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImageList1")]
	internal virtual ImageList ImageList1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.Timer HometoTrayTimer
	{
		[CompilerGenerated]
		get
		{
			return _HometoTrayTimer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HometoTrayTimer_Tick;
			System.Windows.Forms.Timer hometoTrayTimer = _HometoTrayTimer;
			if (hometoTrayTimer != null)
			{
				hometoTrayTimer.Tick -= value2;
			}
			_HometoTrayTimer = value;
			hometoTrayTimer = _HometoTrayTimer;
			if (hometoTrayTimer != null)
			{
				hometoTrayTimer.Tick += value2;
			}
		}
	}

	internal virtual CheckBox CheckSendHomeToTray
	{
		[CompilerGenerated]
		get
		{
			return _CheckSendHomeToTray;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckSendHomeToTray_CheckedChanged;
			CheckBox checkSendHomeToTray = _CheckSendHomeToTray;
			if (checkSendHomeToTray != null)
			{
				checkSendHomeToTray.CheckedChanged -= value2;
			}
			_CheckSendHomeToTray = value;
			checkSendHomeToTray = _CheckSendHomeToTray;
			if (checkSendHomeToTray != null)
			{
				checkSendHomeToTray.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckSendHomeToTrayOnStart
	{
		[CompilerGenerated]
		get
		{
			return _CheckSendHomeToTrayOnStart;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckSendHomeToTrayOnStart_CheckedChanged;
			CheckBox checkSendHomeToTrayOnStart = _CheckSendHomeToTrayOnStart;
			if (checkSendHomeToTrayOnStart != null)
			{
				checkSendHomeToTrayOnStart.CheckedChanged -= value2;
			}
			_CheckSendHomeToTrayOnStart = value;
			checkSendHomeToTrayOnStart = _CheckSendHomeToTrayOnStart;
			if (checkSendHomeToTrayOnStart != null)
			{
				checkSendHomeToTrayOnStart.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage7")]
	internal virtual TabPage TabPage7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox7")]
	internal virtual GroupBox GroupBox7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DbLayoutPanel1")]
	internal virtual DBLayoutPanel DbLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button4_Click;
			Button button = _Button4;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button4 = value;
			button = _Button4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CheckLocalDebug
	{
		[CompilerGenerated]
		get
		{
			return _CheckLocalDebug;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckLocalDebug_CheckedChanged;
			CheckBox checkLocalDebug = _CheckLocalDebug;
			if (checkLocalDebug != null)
			{
				checkLocalDebug.CheckedChanged -= value2;
			}
			_CheckLocalDebug = value;
			checkLocalDebug = _CheckLocalDebug;
			if (checkLocalDebug != null)
			{
				checkLocalDebug.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckStartWatcher
	{
		[CompilerGenerated]
		get
		{
			return _CheckStartWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckStartWatcher_CheckedChanged;
			CheckBox checkStartWatcher = _CheckStartWatcher;
			if (checkStartWatcher != null)
			{
				checkStartWatcher.CheckedChanged -= value2;
			}
			_CheckStartWatcher = value;
			checkStartWatcher = _CheckStartWatcher;
			if (checkStartWatcher != null)
			{
				checkStartWatcher.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button1_Click;
			Button button = _Button1;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button1 = value;
			button = _Button1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button5
	{
		[CompilerGenerated]
		get
		{
			return _Button5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button5_Click;
			Button button = _Button5;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button5 = value;
			button = _Button5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CheckSensorPower
	{
		[CompilerGenerated]
		get
		{
			return _CheckSensorPower;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckSensorPower_CheckedChanged;
			CheckBox checkSensorPower = _CheckSensorPower;
			if (checkSensorPower != null)
			{
				checkSensorPower.CheckedChanged -= value2;
			}
			_CheckSensorPower = value;
			checkSensorPower = _CheckSensorPower;
			if (checkSensorPower != null)
			{
				checkSensorPower.CheckedChanged += value2;
			}
		}
	}

	internal virtual ComboBox ComboPowerPlanExit
	{
		[CompilerGenerated]
		get
		{
			return _ComboPowerPlanExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboPowerPlanExit_SelectedIndexChanged;
			ComboBox comboPowerPlanExit = _ComboPowerPlanExit;
			if (comboPowerPlanExit != null)
			{
				comboPowerPlanExit.SelectedIndexChanged -= value2;
			}
			_ComboPowerPlanExit = value;
			comboPowerPlanExit = _ComboPowerPlanExit;
			if (comboPowerPlanExit != null)
			{
				comboPowerPlanExit.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label22")]
	internal virtual Label Label22
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button BtnConfigureAudio
	{
		[CompilerGenerated]
		get
		{
			return _BtnConfigureAudio;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnConfigureAudio_Click;
			Button btnConfigureAudio = _BtnConfigureAudio;
			if (btnConfigureAudio != null)
			{
				btnConfigureAudio.Click -= value2;
			}
			_BtnConfigureAudio = value;
			btnConfigureAudio = _BtnConfigureAudio;
			if (btnConfigureAudio != null)
			{
				btnConfigureAudio.Click += value2;
			}
		}
	}

	internal virtual ComboBox ComboApplyPlan
	{
		[CompilerGenerated]
		get
		{
			return _ComboApplyPlan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboApplyPlan_SelectedIndexChanged;
			ComboBox comboApplyPlan = _ComboApplyPlan;
			if (comboApplyPlan != null)
			{
				comboApplyPlan.SelectedIndexChanged -= value2;
			}
			_ComboApplyPlan = value;
			comboApplyPlan = _ComboApplyPlan;
			if (comboApplyPlan != null)
			{
				comboApplyPlan.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label23")]
	internal virtual Label Label23
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelVer")]
	internal virtual Label LabelVer
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label12")]
	internal virtual Label Label12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button9
	{
		[CompilerGenerated]
		get
		{
			return _Button9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button9_Click;
			Button button = _Button9;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button9 = value;
			button = _Button9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button8
	{
		[CompilerGenerated]
		get
		{
			return _Button8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button8_Click;
			Button button = _Button8;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button8 = value;
			button = _Button8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelDownloadStatus")]
	internal virtual Label LabelDownloadStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual PictureBox PictureBox2
	{
		[CompilerGenerated]
		get
		{
			return _PictureBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PictureBox2_Click;
			PictureBox pictureBox = _PictureBox2;
			if (pictureBox != null)
			{
				pictureBox.Click -= value2;
			}
			_PictureBox2 = value;
			pictureBox = _PictureBox2;
			if (pictureBox != null)
			{
				pictureBox.Click += value2;
			}
		}
	}

	internal virtual CheckBox CheckBoxCheckForUpdates
	{
		[CompilerGenerated]
		get
		{
			return _CheckBoxCheckForUpdates;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBoxCheckForUpdates_CheckedChanged;
			CheckBox checkBoxCheckForUpdates = _CheckBoxCheckForUpdates;
			if (checkBoxCheckForUpdates != null)
			{
				checkBoxCheckForUpdates.CheckedChanged -= value2;
			}
			_CheckBoxCheckForUpdates = value;
			checkBoxCheckForUpdates = _CheckBoxCheckForUpdates;
			if (checkBoxCheckForUpdates != null)
			{
				checkBoxCheckForUpdates.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label15")]
	internal virtual Label Label15
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("NumericFOVh")]
	internal virtual NumericUpDown NumericFOVh
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button2_Click;
			Button button = _Button2;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button2 = value;
			button = _Button2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label16")]
	internal virtual Label Label16
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboHomless
	{
		[CompilerGenerated]
		get
		{
			return _ComboHomless;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboHomless_SelectedIndexChanged;
			ComboBox comboHomless = _ComboHomless;
			if (comboHomless != null)
			{
				comboHomless.SelectedIndexChanged -= value2;
			}
			_ComboHomless = value;
			comboHomless = _ComboHomless;
			if (comboHomless != null)
			{
				comboHomless.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Button BtnHomless
	{
		[CompilerGenerated]
		get
		{
			return _BtnHomless;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnHomless_Click;
			Button btnHomless = _BtnHomless;
			if (btnHomless != null)
			{
				btnHomless.Click -= value2;
			}
			_BtnHomless = value;
			btnHomless = _BtnHomless;
			if (btnHomless != null)
			{
				btnHomless.Click += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.Timer UpdateTimer
	{
		[CompilerGenerated]
		get
		{
			return _UpdateTimer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateTimer_Tick;
			System.Windows.Forms.Timer updateTimer = _UpdateTimer;
			if (updateTimer != null)
			{
				updateTimer.Tick -= value2;
			}
			_UpdateTimer = value;
			updateTimer = _UpdateTimer;
			if (updateTimer != null)
			{
				updateTimer.Tick += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuShowHome
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuShowHome;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuShowHome_Click;
			ToolStripMenuItem toolStripMenuShowHome = _ToolStripMenuShowHome;
			if (toolStripMenuShowHome != null)
			{
				toolStripMenuShowHome.Click -= value2;
			}
			_ToolStripMenuShowHome = value;
			toolStripMenuShowHome = _ToolStripMenuShowHome;
			if (toolStripMenuShowHome != null)
			{
				toolStripMenuShowHome.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal virtual Label Label9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboVisualHUD
	{
		[CompilerGenerated]
		get
		{
			return _ComboVisualHUD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboVisualHUD_SelectedIndexChanged;
			ComboBox comboVisualHUD = _ComboVisualHUD;
			if (comboVisualHUD != null)
			{
				comboVisualHUD.SelectedIndexChanged -= value2;
			}
			_ComboVisualHUD = value;
			comboVisualHUD = _ComboVisualHUD;
			if (comboVisualHUD != null)
			{
				comboVisualHUD.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label17")]
	internal virtual Label Label17
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboMirrorHome
	{
		[CompilerGenerated]
		get
		{
			return _ComboMirrorHome;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboMirrorHome_SelectedIndexChanged;
			ComboBox comboMirrorHome = _ComboMirrorHome;
			if (comboMirrorHome != null)
			{
				comboMirrorHome.SelectedIndexChanged -= value2;
			}
			_ComboMirrorHome = value;
			comboMirrorHome = _ComboMirrorHome;
			if (comboMirrorHome != null)
			{
				comboMirrorHome.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckRestartSleep
	{
		[CompilerGenerated]
		get
		{
			return _CheckRestartSleep;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckRestartSleep_CheckedChanged;
			CheckBox checkRestartSleep = _CheckRestartSleep;
			if (checkRestartSleep != null)
			{
				checkRestartSleep.CheckedChanged -= value2;
			}
			_CheckRestartSleep = value;
			checkRestartSleep = _CheckRestartSleep;
			if (checkRestartSleep != null)
			{
				checkRestartSleep.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button BtnSteamImport
	{
		[CompilerGenerated]
		get
		{
			return _BtnSteamImport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnSteamImport_Click;
			Button btnSteamImport = _BtnSteamImport;
			if (btnSteamImport != null)
			{
				btnSteamImport.Click -= value2;
			}
			_BtnSteamImport = value;
			btnSteamImport = _BtnSteamImport;
			if (btnSteamImport != null)
			{
				btnSteamImport.Click += value2;
			}
		}
	}

	internal virtual NotifyIcon NotifyIcon3
	{
		[CompilerGenerated]
		get
		{
			return _NotifyIcon3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = NotifyIcon3_MouseDown;
			NotifyIcon notifyIcon = _NotifyIcon3;
			if (notifyIcon != null)
			{
				notifyIcon.MouseDown -= value2;
			}
			_NotifyIcon3 = value;
			notifyIcon = _NotifyIcon3;
			if (notifyIcon != null)
			{
				notifyIcon.MouseDown += value2;
			}
		}
	}

	internal virtual Button BtnConfigureHotKeys
	{
		[CompilerGenerated]
		get
		{
			return _BtnConfigureHotKeys;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnConfigureHotKeys_Click;
			Button btnConfigureHotKeys = _BtnConfigureHotKeys;
			if (btnConfigureHotKeys != null)
			{
				btnConfigureHotKeys.Click -= value2;
			}
			_BtnConfigureHotKeys = value;
			btnConfigureHotKeys = _BtnConfigureHotKeys;
			if (btnConfigureHotKeys != null)
			{
				btnConfigureHotKeys.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ClearLogToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ClearLogToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ClearLogToolStripMenuItem_Click;
			ToolStripMenuItem clearLogToolStripMenuItem = _ClearLogToolStripMenuItem;
			if (clearLogToolStripMenuItem != null)
			{
				clearLogToolStripMenuItem.Click -= value2;
			}
			_ClearLogToolStripMenuItem = value;
			clearLogToolStripMenuItem = _ClearLogToolStripMenuItem;
			if (clearLogToolStripMenuItem != null)
			{
				clearLogToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem OpenLogToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _OpenLogToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OpenLogToolStripMenuItem_Click;
			ToolStripMenuItem openLogToolStripMenuItem = _OpenLogToolStripMenuItem;
			if (openLogToolStripMenuItem != null)
			{
				openLogToolStripMenuItem.Click -= value2;
			}
			_OpenLogToolStripMenuItem = value;
			openLogToolStripMenuItem = _OpenLogToolStripMenuItem;
			if (openLogToolStripMenuItem != null)
			{
				openLogToolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label13")]
	internal virtual Label Label13
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label18")]
	internal virtual Label Label18
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label24")]
	internal virtual Label Label24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label25")]
	internal virtual Label Label25
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label26")]
	internal virtual Label Label26
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label27")]
	internal virtual Label Label27
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label28")]
	internal virtual Label Label28
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label29")]
	internal virtual Label Label29
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button BtnLibrary
	{
		[CompilerGenerated]
		get
		{
			return _BtnLibrary;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnLibrary_Click;
			Button btnLibrary = _BtnLibrary;
			if (btnLibrary != null)
			{
				btnLibrary.Click -= value2;
			}
			_BtnLibrary = value;
			btnLibrary = _BtnLibrary;
			if (btnLibrary != null)
			{
				btnLibrary.Click += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.Timer PowerPlanTimer
	{
		[CompilerGenerated]
		get
		{
			return _PowerPlanTimer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PowerPlanTimer_Tick;
			System.Windows.Forms.Timer powerPlanTimer = _PowerPlanTimer;
			if (powerPlanTimer != null)
			{
				powerPlanTimer.Tick -= value2;
			}
			_PowerPlanTimer = value;
			powerPlanTimer = _PowerPlanTimer;
			if (powerPlanTimer != null)
			{
				powerPlanTimer.Tick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage8")]
	internal virtual TabPage TabPage8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox5")]
	internal virtual GroupBox GroupBox5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label10")]
	internal virtual Label Label10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboBox3
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = ComboBox3_KeyPress;
			ComboBox comboBox = _ComboBox3;
			if (comboBox != null)
			{
				comboBox.KeyPress -= value2;
			}
			_ComboBox3 = value;
			comboBox = _ComboBox3;
			if (comboBox != null)
			{
				comboBox.KeyPress += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ComboBox2")]
	internal virtual ComboBox ComboBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label31")]
	internal virtual Label Label31
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label30")]
	internal virtual Label Label30
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboBox4
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboBox4_SelectedIndexChanged;
			ComboBox comboBox = _ComboBox4;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox4 = value;
			comboBox = _ComboBox4;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label32")]
	internal virtual Label Label32
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button10
	{
		[CompilerGenerated]
		get
		{
			return _Button10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button10_Click;
			Button button = _Button10;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button10 = value;
			button = _Button10;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button11
	{
		[CompilerGenerated]
		get
		{
			return _Button11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button11_Click;
			Button button = _Button11;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button11 = value;
			button = _Button11;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DbLayoutPanel3")]
	internal virtual DBLayoutPanel DbLayoutPanel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button12
	{
		[CompilerGenerated]
		get
		{
			return _Button12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button12_Click;
			Button button = _Button12;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button12 = value;
			button = _Button12;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtnRemoveAllProfiles
	{
		[CompilerGenerated]
		get
		{
			return _BtnRemoveAllProfiles;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnRemoveAllProfiles_Click;
			EventHandler value3 = Button1_Click;
			Button btnRemoveAllProfiles = _BtnRemoveAllProfiles;
			if (btnRemoveAllProfiles != null)
			{
				btnRemoveAllProfiles.Click -= value2;
				btnRemoveAllProfiles.Click -= value3;
			}
			_BtnRemoveAllProfiles = value;
			btnRemoveAllProfiles = _BtnRemoveAllProfiles;
			if (btnRemoveAllProfiles != null)
			{
				btnRemoveAllProfiles.Click += value2;
				btnRemoveAllProfiles.Click += value3;
			}
		}
	}

	internal virtual ComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboBox1_SelectedIndexChanged;
			ComboBox comboBox = _ComboBox1;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox1 = value;
			comboBox = _ComboBox1;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label35")]
	internal virtual Label Label35
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboBox5
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboBox5_SelectedIndexChanged;
			ComboBox comboBox = _ComboBox5;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox5 = value;
			comboBox = _ComboBox5;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("NumericFOVv")]
	internal virtual NumericUpDown NumericFOVv
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label36")]
	internal virtual Label Label36
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboBox6")]
	internal virtual ComboBox ComboBox6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label19")]
	internal virtual Label Label19
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboOVRPrio
	{
		[CompilerGenerated]
		get
		{
			return _ComboOVRPrio;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboOVRPrio_SelectedIndexChanged;
			ComboBox comboOVRPrio = _ComboOVRPrio;
			if (comboOVRPrio != null)
			{
				comboOVRPrio.SelectedIndexChanged -= value2;
			}
			_ComboOVRPrio = value;
			comboOVRPrio = _ComboOVRPrio;
			if (comboOVRPrio != null)
			{
				comboOVRPrio.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Button Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button3_Click;
			Button button = _Button3;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button3 = value;
			button = _Button3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label20")]
	internal virtual Label Label20
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboBox7")]
	internal virtual ComboBox ComboBox7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label21")]
	internal virtual Label Label21
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button6
	{
		[CompilerGenerated]
		get
		{
			return _Button6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button6_Click;
			Button button = _Button6;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button6 = value;
			button = _Button6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("PictureBox3")]
	internal virtual PictureBox PictureBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label34")]
	internal virtual Label Label34
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label33")]
	internal virtual Label Label33
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboBox8
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboBox8_SelectedIndexChanged;
			ComboBox comboBox = _ComboBox8;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox8 = value;
			comboBox = _ComboBox8;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label37")]
	internal virtual Label Label37
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboBox9
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboBox9_SelectedIndexChanged;
			ComboBox comboBox = _ComboBox9;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox9 = value;
			comboBox = _ComboBox9;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label38")]
	internal virtual Label Label38
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboBox10")]
	internal virtual ComboBox ComboBox10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboBox11")]
	internal virtual ComboBox ComboBox11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label39")]
	internal virtual Label Label39
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox6")]
	internal virtual PictureBox PictureBox6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox5")]
	internal virtual PictureBox PictureBox5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox4")]
	internal virtual PictureBox PictureBox4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox7")]
	internal virtual PictureBox PictureBox7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox8")]
	internal virtual PictureBox PictureBox8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckStopServiceHome
	{
		[CompilerGenerated]
		get
		{
			return _CheckStopServiceHome;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckStopServiceHome_CheckedChanged;
			CheckBox checkStopServiceHome = _CheckStopServiceHome;
			if (checkStopServiceHome != null)
			{
				checkStopServiceHome.CheckedChanged -= value2;
			}
			_CheckStopServiceHome = value;
			checkStopServiceHome = _CheckStopServiceHome;
			if (checkStopServiceHome != null)
			{
				checkStopServiceHome.CheckedChanged += value2;
			}
		}
	}

	public FrmMain()
	{
		base.Load += Form1_Load;
		base.FormClosing += frmMain_FormClosing;
		base.Resize += Form1_Resize;
		rs = new Resizer();
		Is64Bit = false;
		profileList = new Dictionary<string, string>();
		profileTimerList = new Dictionary<string, string>();
		profileASWList = new Dictionary<string, string>();
		profilePriorityList = new Dictionary<string, string>();
		profileNames = new List<string>();
		profileDisplayNames = new Dictionary<string, string>();
		profileAswDelay = new Dictionary<string, string>();
		profileCpuDelay = new Dictionary<string, string>();
		profilePaths = new Dictionary<string, string>();
		profileMirror = new Dictionary<string, string>();
		profileAGPS = new Dictionary<string, string>();
		profileFOV = new Dictionary<string, string>();
		profileForceMipMap = new Dictionary<string, string>();
		profileOffsetMipMap = new Dictionary<string, string>();
		runningApp = "";
		hasError = false;
		hasWarning = false;
		OculusServiceFound = true;
		customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
		power_plans = new Dictionary<string, string>();
		debug = false;
		RiftAudioCanceled = false;
		HomeIsRunning = false;
		OVRIsRunning = false;
		spoofid = false;
		loadingDone = false;
		OculusSoftwarePaths = new List<string>();
		Watcher = new ManagementEventWatcher();
		MinimizeHomeWatcher = new ManagementEventWatcher();
		colRemovedTabs = new Collection();
		steamvr = "";
		Hometimer = new System.Windows.Forms.Timer();
		pTimer = new System.Timers.Timer();
		ManualStart = false;
		restartInDBG = false;
		ignoredApps = new List<string>();
		includedApps = new List<string>();
		voiceProfileNames = new List<string>();
		ovrDown = false;
		Update_URL = "https://www.dropbox.com/s/63qb2oswo2o3ugt/version.txt?dl=1";
		UpdateTest_URL = "https://www.dropbox.com/s/v11ce9oww5yhkg4/version_test_2.txt?dl=1";
		voiceSettingsLoaded = false;
		_Home2Timer = new System.Timers.Timer(100.0);
		restartHome = false;
		mirrorTimer = new System.Timers.Timer();
		StartingUp = false;
		AswToggle = new List<string>();
		cpuTimer = new System.Timers.Timer();
		aswTimer = new System.Timers.Timer();
		AppWatchWorker = new BackgroundWorker();
		AllAppsList = new Dictionary<string, string>();
		NoProfileFound = false;
		numLogMessages = 0;
		HomeIsMirrored = false;
		FuncToKeyDictionary = new Dictionary<string, string>();
		NextASW = new List<string>();
		CurrentASW = 0;
		NextHUD = new List<string>();
		CurrentHUD = 0;
		DSep = ".";
		Application.EnableVisualStyles();
		InitializeComponent();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Form1_Load(object sender, EventArgs e)
	{
		try
		{
			StartingUp = true;
			fmain = this;
			lockObject = RuntimeHelpers.GetObjectValue(new object());
			rs.FindAllControls(this);
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			string[] array = commandLineArgs;
			foreach (string left in array)
			{
				if (Operators.CompareString(left, "-r", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.Reset();
					MySettingsProperty.Settings.Save();
					Shutdown();
				}
				if (Operators.CompareString(left, "-d", TextCompare: false) == 0)
				{
					Globals.dbg = true;
				}
				else
				{
					Globals.dbg = false;
				}
				if (Operators.CompareString(left, "-u", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UpgradeRequired = true;
				}
			}
			if (!Globals.dbg && MySettingsProperty.Settings.RunDebug)
			{
				MySettingsProperty.Settings.RunDebug = false;
				MySettingsProperty.Settings.Save();
				Globals.dbg = true;
			}
			if (Globals.dbg)
			{
				string text = DateTime.Now.ToString().Replace("/", "").Replace("\\", "")
					.Replace("-", "")
					.Replace(" ", "_")
					.Replace(":", "");
				FileSystem.Rename(Application.StartupPath + "\\ott.log", "ott_" + text + ".log");
				Log.WriteToLog(":: Debug is ON ::");
			}
			Log.WriteToLog("Starting up...");
			Log.WriteToLog("Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
			VoiceCommands.Initialize();
			if (Globals.dbg)
			{
				Log.WriteToLog("Checking Administrator privileges");
			}
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
			isElevated = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			if (!isElevated)
			{
				Interaction.MsgBox("You must run Oculus Tray Tool as Administrator.\r\nThe application will now exit.", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Shutdown();
			}
			DotNetBarTabcontrol1.TabPages[0].ImageIndex = 0;
			DotNetBarTabcontrol1.TabPages[1].ImageIndex = 1;
			DotNetBarTabcontrol1.TabPages[2].ImageIndex = 2;
			DotNetBarTabcontrol1.TabPages[3].ImageIndex = 3;
			DotNetBarTabcontrol1.TabPages[4].ImageIndex = 4;
			DotNetBarTabcontrol1.TabPages[5].ImageIndex = 5;
			DotNetBarTabcontrol1.TabPages[6].ImageIndex = 7;
			DotNetBarTabcontrol1.TabPages[7].ImageIndex = 6;
			if (!File.Exists(Application.StartupPath + "\\Microsoft.Speech.dll"))
			{
				Log.WriteToLog("Missing dependency: Microsoft.Speech.dll, cannot continue");
				Interaction.MsgBox("Missing dependency: Microsoft.Speech.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Dispose();
				return;
			}
			if (!File.Exists(Application.StartupPath + "\\CoreAudio.dll"))
			{
				Log.WriteToLog("Missing dependency: CoreAudio.dll, cannot continue");
				Interaction.MsgBox("Missing dependency: CoreAudio.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Dispose();
				return;
			}
			if (!File.Exists(Application.StartupPath + "\\Microsoft.Win32.TaskScheduler.dll"))
			{
				Log.WriteToLog("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue");
				Interaction.MsgBox("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Dispose();
				return;
			}
			if (!File.Exists(Application.StartupPath + "\\Newtonsoft.Json.dll"))
			{
				Log.WriteToLog("Missing dependency: Newtonsoft.Json.dll, cannot continue");
				Interaction.MsgBox("Missing dependency: Newtonsoft.Json.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Dispose();
				return;
			}
			if (!File.Exists(Application.StartupPath + "\\SQLite.Interop.dll"))
			{
				Log.WriteToLog("Missing dependency: SQLite.Interop.dll, cannot continue");
				Interaction.MsgBox("Missing dependency: SQLite.Interop.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Dispose();
				return;
			}
			if (!File.Exists(Application.StartupPath + "\\System.Data.SQLite.dll"))
			{
				Log.WriteToLog("Missing dependency: System.Data.SQLite.dll, cannot continue");
				Interaction.MsgBox("Missing dependency: System.Data.SQLite.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
				Dispose();
				return;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Show Loading toast");
			}
			MyProject.Forms.frmLoading.Show();
			if (MySettingsProperty.Settings.UpgradeRequired)
			{
				Log.WriteToLog("Migrating user settings to new version");
				MySettingsProperty.Settings.Upgrade();
				MySettingsProperty.Settings.UpgradeRequired = false;
				MySettingsProperty.Settings.StartWithWindows = false;
				MySettingsProperty.Settings.Save();
			}
			OTTDB.CheckDB();
			TrackBar1.Value = checked((int)Math.Round(MySettingsProperty.Settings.FontSize));
			Label14.Text = "Font Size: " + Conversions.ToString(TrackBar1.Value);
			rs.ResizeAllControls(this, TrackBar1.Value);
			MyProject.Forms.frmProfiles.ListView1.Font = new Font(MyProject.Forms.frmProfiles.ListView1.Font.Name, MySettingsProperty.Settings.FontSize, FontStyle.Regular);
			MyProject.Forms.frmProfiles.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			UpdateTab = DotNetBarTabcontrol1.TabPages[6];
			colRemovedTabs.Add(TabPage6, TabPage6.Name);
			DotNetBarTabcontrol1.TabPages.Remove(TabPage6);
			if (Globals.dbg)
			{
				Log.WriteToLog("Checking .NET version");
			}
			GetDotNetVersion.GetVersion();
			if (MySettingsProperty.Settings.WindowLocation != default(Point))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Setting GUI location to " + MySettingsProperty.Settings.WindowLocation.ToString());
				}
				base.Location = MySettingsProperty.Settings.WindowLocation;
			}
			else
			{
				Log.WriteToLog("Setting GUI location to Center Screen");
				CenterToScreen();
				MySettingsProperty.Settings.WindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			if ((base.Location.X < 0) | (base.Location.Y < 0))
			{
				Log.WriteToLog("GUI location has negative number, adjusting");
				CenterToScreen();
				MySettingsProperty.Settings.WindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			if (MySettingsProperty.Settings.GuiSize != default(Size))
			{
				base.Size = MySettingsProperty.Settings.GuiSize;
			}
			Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
			scaleX = graphics.DpiX / 96f;
			scaleY = graphics.DpiY / 96f;
			Text = Text + " " + Application.ProductVersion.Substring(0, 8);
			MyProject.Forms.frmAbout.Label4.Text = Application.ProductVersion.Substring(0, 8);
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			if (Globals.dbg)
			{
				Log.WriteToLog("Setting culture to " + customCulture.ToString());
			}
			Thread.CurrentThread.CurrentCulture = customCulture;
			Is64Bit = Environment.Is64BitOperatingSystem;
			if (Globals.dbg)
			{
				Log.WriteToLog("is64Bit=" + Conversions.ToString(Is64Bit));
			}
			if (!isElevated)
			{
				AddToListboxAndScroll("** Not running as Administrator **");
				Log.WriteToLog("Not running as Administrator!");
				hasError = true;
			}
			string toolTip = ToolTip.GetToolTip(CheckSpoofCPU);
			if (Operators.CompareString(toolTip, null, TextCompare: false) != 0 && toolTip.Length > 75)
			{
				ToolTip.SetToolTip(CheckSpoofCPU, SplitToolTip(toolTip));
			}
			toolTip = ToolTip.GetToolTip(Label13);
			if (Operators.CompareString(toolTip, null, TextCompare: false) != 0 && toolTip.Length > 75)
			{
				ToolTip.SetToolTip(Label13, SplitToolTip(toolTip));
			}
			toolTip = ToolTip.GetToolTip(Label18);
			if (Operators.CompareString(toolTip, null, TextCompare: false) != 0 && toolTip.Length > 75)
			{
				ToolTip.SetToolTip(Label18, SplitToolTip(toolTip));
			}
			toolTip = ToolTip.GetToolTip(CheckLocalDebug);
			if (Operators.CompareString(toolTip, null, TextCompare: false) != 0 && toolTip.Length > 75)
			{
				ToolTip.SetToolTip(CheckLocalDebug, SplitToolTip(toolTip));
			}
			toolTip = ToolTip.GetToolTip(CheckStartWatcher);
			if (Operators.CompareString(toolTip, null, TextCompare: false) != 0 && toolTip.Length > 75)
			{
				ToolTip.SetToolTip(CheckStartWatcher, SplitToolTip(toolTip));
			}
			if (File.Exists(Application.StartupPath + "\\data.sqlite"))
			{
				File.Delete(Application.StartupPath + "\\data.sqlite");
				if (Globals.dbg)
				{
					Log.WriteToLog("Database copy deleted");
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Looking for Oculus database");
			}
			if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Database found, making a copy");
				}
				try
				{
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", overwrite: true);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteToLog("Failed to create database copy: " + ex2.Message);
					Interaction.MsgBox("Failed to create database copy: " + ex2.Message, MsgBoxStyle.Critical, "Error copying database");
					AddToListboxAndScroll("Failed to create database copy: " + ex2.Message);
					hasError = true;
					ProjectData.ClearProjectError();
					return;
				}
			}
			OculusTrayTool.OculusPath.GetOculusPath();
			GetConfig.IsReading = true;
			OTTDB.OpenOttDB();
			PowerPlans.GetPowerPlans();
			GetConfig.GetConfig();
			if ((Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) == 0) | string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString()))
			{
				MySettingsProperty.Settings.LibraryPath = "";
				MySettingsProperty.Settings.Save();
				Log.WriteToLog("Oculus Library paths not set, retrieving them from the registry");
				OculusSoftwarePaths = (List<string>)OculusTrayTool.OculusPath.GetOculusSoftwarePaths();
				Log.WriteToLog("Found " + OculusSoftwarePaths.Count + " library paths");
				if (OculusSoftwarePaths.Count > 0)
				{
					foreach (string oculusSoftwarePath in OculusSoftwarePaths)
					{
						Log.WriteToLog("Oculus Library path: " + oculusSoftwarePath.TrimEnd('\\'));
						MySettings settings;
						(settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + oculusSoftwarePath + ",";
						MySettingsProperty.Settings.Save();
					}
					MySettingsProperty.Settings.LibraryPath = MySettingsProperty.Settings.LibraryPath.TrimEnd(',');
					MySettingsProperty.Settings.Save();
				}
				else
				{
					Log.WriteToLog("No library paths returned from registry! You may need to add them manually.");
					Log.WriteToLog("Using " + OculusPath + " as default library path");
					AddToListboxAndScroll("No library paths returned from registry! You may need to add them manually.");
					AddToListboxAndScroll("Using " + OculusPath + " as default library path");
					hasWarning = true;
				}
			}
			NextASW.AddRange(new string[7] { "Auto", "Off", "45", "45f", "18", "30", "Adaptive" });
			OTTDB.GetProfiles();
			ignoredApps = (List<string>)OTTDB.GetIgnoredApps();
			includedApps = (List<string>)OTTDB.GetIncludedApps();
			if (ignoredApps.Count > 0)
			{
				Log.WriteToLog(Conversions.ToString(ignoredApps.Count) + " apps are being ignored");
			}
			if (MySettingsProperty.Settings.UseLocalDebugTool)
			{
				if (File.Exists(Application.StartupPath + "\\OculusDebugToolCLI.exe"))
				{
					RunCommand.debug_tool_path = Application.StartupPath + "\\OculusDebugToolCLI.exe";
					Log.WriteToLog("'UseLocalDebugTool' is 'True', using " + RunCommand.debug_tool_path);
					CheckLocalDebug.Checked = true;
				}
				else
				{
					Log.WriteToLog("'UseLocalDebugTool' is 'True' but " + Application.StartupPath + "\\OculusDebugToolCLI.exe was not found!");
					AddToListboxAndScroll("'UseLocalDebugTool' is 'True' but " + Application.StartupPath + "\\OculusDebugToolCLI.exe was not found!");
					ListBox1.Refresh();
					hasError = true;
				}
			}
			else if (File.Exists(OculusPath + "Support\\oculus-diagnostics\\OculusDebugToolCLI.exe"))
			{
				RunCommand.debug_tool_path = OculusPath + "Support\\oculus-diagnostics\\OculusDebugToolCLI.exe";
				Log.WriteToLog("Using " + RunCommand.debug_tool_path);
			}
			else
			{
				RunCommand.debug_tool_path = Application.StartupPath + "\\OculusDebugToolCLI.exe";
				Log.WriteToLog("Using " + RunCommand.debug_tool_path);
			}
			RunCommand.CloseDebugTool();
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting ASW");
			}
			if (MySettingsProperty.Settings.ASW == 0)
			{
				fmain.ComboBox1.Text = "Auto";
			}
			if (MySettingsProperty.Settings.ASW == 1)
			{
				fmain.ComboBox1.Text = "Off";
			}
			if (MySettingsProperty.Settings.ASW == 2)
			{
				fmain.ComboBox1.Text = "45 Hz";
			}
			if (MySettingsProperty.Settings.ASW == 3)
			{
				fmain.ComboBox1.Text = "30 Hz";
			}
			if (MySettingsProperty.Settings.ASW == 4)
			{
				fmain.ComboBox1.Text = "18 Hz";
			}
			if (MySettingsProperty.Settings.ASW == 5)
			{
				fmain.ComboBox1.Text = "45 Hz forced";
			}
			if (MySettingsProperty.Settings.ASW == 6)
			{
				fmain.ComboBox1.Text = "Adaptive";
			}
			fmain.ComboVisualHUD.Text = "None";
			CheckStartWithWindows();
			PowerPlans.CheckPowerState(change: false);
			if (!spoofid && (MySettingsProperty.Settings.StartOVR & !OVRIsRunning) && OculusServiceFound)
			{
				StartOVR();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting SpoofCPU");
			}
			fmain.spoofid = MySettingsProperty.Settings.SpoofCPU;
			if (MySettingsProperty.Settings.SpoofCPU)
			{
				fmain.CheckSpoofCPU.Checked = true;
				MySettingsProperty.Settings.OldCPUID = "";
				fmain.GetCPUid();
			}
			else
			{
				fmain.CheckSpoofCPU.Checked = false;
			}
			if (!MySettingsProperty.Settings.StartOVR & !MySettingsProperty.Settings.SpoofCPU)
			{
				CheckOculusService();
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string text2 = Path.Combine(folderPath, "OTT");
			Directory.CreateDirectory(text2);
			Globals.steam = new Steam(text2);
			Globals.oculus = new Oculus(text2, Globals.steam);
			GetSteamPath();
			GetSteamVR();
			if (Operators.CompareString(SteamPath, "", TextCompare: false) != 0)
			{
				vrManifestFileName = Path.Combine(SteamPath, "config\\steamapps.vrmanifest");
				if (!File.Exists(vrManifestFileName))
				{
					Log.WriteToLog("Could not locate Steam VR manifest");
				}
				else
				{
					Log.WriteToLog("Found Steam VR manifest: " + vrManifestFileName);
					GetGames.GetSteamGames();
				}
			}
			if (OculusServiceFound)
			{
				if (Directory.Exists(OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
				{
					GetGames.GetThirdPartyApps(OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
				}
				if (Directory.Exists(OculusPath.TrimEnd('\\') + "\\Manifests"))
				{
					GetGames.GetFiles(OculusPath.TrimEnd('\\') + "\\Manifests");
				}
				if (Directory.Exists(OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
				{
					GetGames.GetFiles(OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
				}
				if ((Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString()))
				{
					string[] array2 = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
					foreach (string text3 in array2)
					{
						if (Directory.Exists(text3.TrimEnd('\\') + "\\Manifests"))
						{
							GetGames.GetFiles(text3.TrimEnd('\\') + "\\Manifests");
						}
						if (Directory.Exists(text3.TrimEnd('\\') + "\\CoreData\\Manifests"))
						{
							GetGames.GetThirdPartyApps(text3.TrimEnd('\\') + "\\CoreData\\Manifests");
						}
					}
				}
			}
			if (OTTDB.numTimer > 0)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Creating EventHandler for Timer AppWatcher");
				}
				pTimer.Elapsed += OnTimerProfile;
				pTimer.Interval = 400.0;
				pTimer.Enabled = false;
				pTimer.AutoReset = true;
			}
			if (OVRIsRunning)
			{
				ComboVisualHUD.SelectedIndex = 0;
			}
			if (OculusServiceFound & !MySettingsProperty.Settings.StartAppwatcherOnStart)
			{
				Log.WriteToLog("Oculus Home/SteamVR required, waiting for either to start");
				OculusHomeWatcher.Start();
			}
			if (OculusServiceFound & MySettingsProperty.Settings.StartAppwatcherOnStart)
			{
				if (OTTDB.numWMI > 0)
				{
					CreateWatcher();
				}
				if (OTTDB.numTimer > 0)
				{
					Log.WriteToLog("Start Appwatcher On Start is True, starting Timer AppWatcher");
					pTimer.Start();
				}
			}
			if (OVRIsRunning && CheckLaunchHomeTool.Checked)
			{
				if (File.Exists(OculusPath + "Support\\oculus-client\\OculusClient.exe"))
				{
					RunCommand.StartHome();
				}
				else
				{
					Log.WriteToLog("Could not locate OculusClient in " + OculusPath);
					AddToListboxAndScroll("Could not locate OculusClient in " + OculusPath);
					hasWarning = true;
				}
			}
			if (MySettingsProperty.Settings.AutomaticUpdateCheck)
			{
				UpdateTimer.Start();
			}
			else
			{
				Log.WriteToLog("Automatic update checking is disabled");
				AddToListboxAndScroll("Automatic update checking is disabled");
			}
			if (Globals.dbg)
			{
				PrintSettings(migrate: false);
			}
			if (MySettingsProperty.Settings.StartMinimized)
			{
				base.WindowState = FormWindowState.Minimized;
			}
			if (GetConfig.SetRiftDefault)
			{
				if (MySettingsProperty.Settings.SetRiftAudioDefault == 1)
				{
					if (MySettingsProperty.Settings.SetAudioOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: false);
					}
					if (MySettingsProperty.Settings.SetAudioCommOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultAudioCommDeviceOnStart();
					}
				}
				if (MySettingsProperty.Settings.SetRiftMicDefault == 1)
				{
					if (MySettingsProperty.Settings.SetMicOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultMicDeviceOnStart();
					}
					if (MySettingsProperty.Settings.SetMicCommOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultMicCommDeviceOnStart();
					}
				}
			}
			else if (GetConfig.useVoiceCommands)
			{
				EnableDisableVoice(enable: true);
			}
			if ((MySettingsProperty.Settings.HomelessEnabled == 1) & MySettingsProperty.Settings.HomelessAutoPatch)
			{
				Log.WriteToLog("Oculus Homeless is installed, generating hash of 'Home2-Win64-Shipping.exe'");
				string right = Conversions.ToString(GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe"));
				string left2 = Conversions.ToString(GenerateSHA256Hash(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"));
				if (Operators.CompareString(left2, right, TextCompare: false) != 0)
				{
					Log.WriteToLog("'Home2-Win64-Shipping.exe' has been updated. Automatically re-applying Oculus Homeless");
					InstallHomeless();
				}
				else
				{
					Log.WriteToLog("'Home2-Win64-Shipping.exe' has not changed, Oculus Homeless is still enabled");
				}
			}
			try
			{
				if (GetDevices.AudioDevCount > 0)
				{
					MMDeviceEnumerator mMDeviceEnumerator = new MMDeviceEnumerator();
					MMDevice defaultAudioEndpoint = mMDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole);
					if (defaultAudioEndpoint.FriendlyName.ToLower().Contains("rift"))
					{
						ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
						if ((Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, null, TextCompare: false) != 0) & (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, null, TextCompare: false) != 0))
						{
							ToolStripMenuItem3.Enabled = true;
						}
						else
						{
							ToolStripMenuItem3.Enabled = false;
							ToolStripMenuItem3.ToolTipText = "No fallback devices has been selected in the AudioSwitcher configuration";
						}
					}
					else
					{
						ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
					}
				}
				else
				{
					Log.WriteToLog("Could not get default audio endpoint, no enabled devices found!");
					AddToListboxAndScroll("WARNING: Could not get default audio endpoint, no enabled devices found!");
					hasWarning = true;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("* Could not get default audio endpoint!");
				AddToListboxAndScroll("* Could not get default audio endpoint, no enabled devices found!");
				hasWarning = true;
				ProjectData.ClearProjectError();
			}
			if (MySettingsProperty.Settings.RestartServiceAfterSleep)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Adding eventhandler for PowerModeChanged");
				}
				SystemEvents.PowerModeChanged += PowerModeChanged;
			}
			if (MySettingsProperty.Settings.SendHomeToTrayOnStart)
			{
				StartMinimizeHomeWatcher();
			}
			OTTDB.GetLinkPresetNames();
			GetOculusLinkValues();
			CheckWarnings();
			AddToListboxAndScroll(Conversions.ToString(AllAppsList.Count) + " apps are being monitored");
			AddToListboxAndScroll(Conversions.ToString(ignoredApps.Count) + " apps are being ignored");
			AddToListboxAndScroll(Conversions.ToString(GetConfig.numprofiles) + " apps have profiles");
			Log.WriteToLog("Getting list of supported desktop resolutions");
			MyProject.Forms.frmProfiles.ComboResolution.Items.AddRange(Resolution.GetSupportedResolutions());
			GetConfig.IsReading = false;
			loadingDone = true;
			if (Globals.dbg)
			{
				Log.WriteToLog("LoadingDone=" + loadingDone);
			}
			Cursor = Cursors.Default;
			if (Globals.dbg)
			{
				Log.WriteToLog("Checking errors and warnings");
			}
			if (hasError)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("hasError=" + hasError);
				}
				MyProject.Forms.frmLoading.Label2.Text = "Not Ready (Error)";
				MyProject.Forms.frmLoading.Label2.Refresh();
				NotificationTimer.Interval = 1500;
				NotificationTimer.Start();
				Log.WriteToLog("Startup Complete");
			}
			else if (hasWarning)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("hasWarning=" + hasWarning);
				}
				MyProject.Forms.frmLoading.Label2.Text = "Ready (Warnings)";
				MyProject.Forms.frmLoading.Label2.Refresh();
				NotificationTimer.Interval = 1500;
				NotificationTimer.Start();
				Log.WriteToLog("Startup Complete");
			}
			else if (!hasError & !hasWarning)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("No warnings or errors");
				}
				MyProject.Forms.frmLoading.Label2.Text = "Ready";
				MyProject.Forms.frmLoading.Label2.Refresh();
				NotificationTimer.Interval = 1000;
				NotificationTimer.Start();
				Log.WriteToLog("Startup Complete");
			}
			NotifyIcon1.Visible = true;
			StartingUp = false;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			AddToListboxAndScroll("Exception on Startup: " + ex6.Message);
			StackTrace stackTrace = new StackTrace(ex6, fNeedFileInfo: true);
			Log.WriteToLog(ex6.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void StartMinimizeHomeWatcher()
	{
		try
		{
			MinimizeHomeWatcher.Stop();
			if (Globals.dbg)
			{
				Log.WriteToLog("Starting Watcher for 'Minimize Home on Start'");
			}
			string query = "SELECT TargetInstance FROM __InstanceCreationEvent WITHIN  1.0 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name like 'OculusClient.exe'";
			string scope = "\\\\.\\root\\CIMV2";
			MinimizeHomeWatcher = new ManagementEventWatcher(scope, query);
			MinimizeHomeWatcher.Start();
			if (Globals.dbg)
			{
				Log.WriteToLog("Watcher for 'Minimize Home on Start' started");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("StartMinimizeHomeWatcher(): " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void MinimizeHomeWatcher_EventArrived(object sender, EventArrivedEventArgs e)
	{
		MinimizeHomeWatcher_EventArrived_Delegate(0);
	}

	private void MinimizeHomeWatcher_EventArrived_Delegate(int tries)
	{
		try
		{
			MinimizeHomeWatcher.Stop();
			if (HomeToTray.HomeIsMinimized)
			{
				return;
			}
			if (tries >= 3)
			{
				Log.WriteToLog(Conversions.ToString(tries) + " attempts for sending Home to tray, giving up");
				tries = 0;
				return;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("'Minimize Home on Start' event arrived");
			}
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			if (processesByName.Count() >= 3)
			{
				Log.WriteToLog("Oculus Home seems to have started up fully. Sleeping " + MySettingsProperty.Settings.SleepAfterHomeStart + "ms before attempting to minimize to tray");
				Thread.Sleep(Conversions.ToInteger(MySettingsProperty.Settings.SleepAfterHomeStart));
				HomeToTray.SendHomeToTrayOnStart();
				if (!HomeToTray.HomeIsMinimized)
				{
					return;
				}
				EnableShowHomeMenu();
				if (MySettingsProperty.Settings.ShowHomeToast & !HomeToTray.ToastShown)
				{
					HomeToTray.ToastShown = true;
					Thread thread = new Thread([SpecialName] () =>
					{
						MyProject.Forms.frmHomeTrayToast.ShowDialog();
					});
					thread.Start();
				}
				MinimizeHomeWatcher.Start();
			}
			else
			{
				Log.WriteToLog("Oculus Home Not fully running, sleeping 500ms And retrying");
				Thread.Sleep(500);
				tries = checked(tries + 1);
				MinimizeHomeWatcher_EventArrived_Delegate(tries);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("MinimizeHomeWatcher_EventArrived() :  " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		MySettingsProperty.Settings.WindowLocation = base.Location;
		MySettingsProperty.Settings.GuiSize = base.Size;
		MySettingsProperty.Settings.Save();
		if (e.CloseReason == CloseReason.WindowsShutDown)
		{
			Log.WriteToLog("Windows shutdown detected, performing quick cleanup");
			if (OTTDB.ott_cnn.State == ConnectionState.Open)
			{
				OTTDB.ott_cnn.Close();
			}
			if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", TextCompare: false) != 0 && MySettingsProperty.Settings.ApplyPowerPlan == 0)
			{
				PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanExit);
				PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
			}
			if (GetConfig.SetRiftDefault)
			{
				if (MySettingsProperty.Settings.SetRiftAudioDefault == 1)
				{
					AudioSwitcher.SetFallbackAudioDevice();
					AudioSwitcher.SetFallbackCommAudioDevice();
				}
				if (MySettingsProperty.Settings.SetRiftMicDefault == 1)
				{
					AudioSwitcher.SetFallbackMicDevice();
					AudioSwitcher.SetFallbackCommMicDevice();
				}
			}
			Log.WriteToLog("bye bye");
			Dispose();
		}
		if (e.CloseReason != CloseReason.UserClosing)
		{
			return;
		}
		if (!MySettingsProperty.Settings.CloseOnX)
		{
			e.Cancel = true;
			if (MySettingsProperty.Settings.ShowStillRunning)
			{
				MyProject.Forms.frmStillRunningToast.Show();
			}
			base.WindowState = FormWindowState.Minimized;
		}
		else if (Interaction.MsgBox("Oculus Tray Tool needs to be running to work its magic!\r\n\r\nAre you sure you want to exit?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm Exit") == MsgBoxResult.No)
		{
			e.Cancel = true;
		}
		else
		{
			Shutdown();
		}
	}

	public void Shutdown()
	{
		try
		{
			Hide();
			Log.WriteToLog("Closing down...");
			MyProject.Forms.frmProfiles.Close();
			MyProject.Forms.frmLibrary.Close();
			try
			{
				if (CheckUpdate.frmToast != null)
				{
					CheckUpdate.frmToast.BeginInvoke((Action)([SpecialName] () =>
					{
						CheckUpdate.frmToast.Close();
					}));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Removing eventhandler for PowerModeChanged");
			}
			SystemEvents.PowerModeChanged -= PowerModeChanged;
			Log.WriteToLog("StopOVR is " + MySettingsProperty.Settings.StopOVR);
			if (MySettingsProperty.Settings.StopOVR)
			{
				Log.WriteToLog("Calling on service to stop");
				StopOVR();
			}
			else if (MySettingsProperty.Settings.CloseHomeOnExit)
			{
				CloseClient();
			}
			if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", TextCompare: false) != 0 && MySettingsProperty.Settings.ApplyPowerPlan == 0)
			{
				PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanExit);
				PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
			}
			if (GetConfig.SetRiftDefault)
			{
				if (MySettingsProperty.Settings.SetRiftAudioDefault == 1)
				{
					AudioSwitcher.SetFallbackAudioDevice();
					AudioSwitcher.SetFallbackCommAudioDevice();
				}
				if (MySettingsProperty.Settings.SetRiftMicDefault == 1)
				{
					AudioSwitcher.SetFallbackMicDevice();
					AudioSwitcher.SetFallbackCommMicDevice();
				}
			}
			Watcher.Stop();
			OculusHomeWatcher.Stop();
			MinimizeHomeWatcher.Stop();
			pTimer.Stop();
			HometoTrayTimer.Stop();
			NotificationTimer.Stop();
			UpdateTimer.Stop();
			_Home2Timer.Stop();
			mirrorTimer.Stop();
			if (HomeIsRunning)
			{
				HomeToTray.ShowHomeNormal();
			}
			MyProject.Forms.frmHotKeys.Close();
			if (spoofid)
			{
				RestoreCPUID();
			}
			RunCommand.CloseDebugTool();
			if (OTTDB.ott_cnn.State == ConnectionState.Open)
			{
				OTTDB.ott_cnn.Close();
			}
			if (MyProject.Forms.frmLibrary.Steamcnn.State == ConnectionState.Open)
			{
				MyProject.Forms.frmLibrary.Steamcnn.Close();
			}
			if (File.Exists(Application.StartupPath + "\\ppdp.txt"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Deleting temporary file ppdp.txt");
				}
				File.Delete(Application.StartupPath + "\\ppdp.txt");
			}
			if (File.Exists(Application.StartupPath + "\\perf.txt"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Deleting temporary file perf.txt");
				}
				File.Delete(Application.StartupPath + "\\perf.txt");
			}
			if (File.Exists(Application.StartupPath + "\\asw.txt"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Deleting temporary file asw.txt");
				}
				File.Delete(Application.StartupPath + "\\asw.txt");
			}
			if (File.Exists(Application.StartupPath + "\\fov.txt"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Deleting temporary file fov.txt");
				}
				File.Delete(Application.StartupPath + "\\fov.txt");
			}
			if (File.Exists(Application.StartupPath + "\\usb.txt"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Deleting temporary file usb.txt");
				}
				File.Delete(Application.StartupPath + "\\usb.txt");
			}
			if (File.Exists(Application.StartupPath + "\\data.sqlite"))
			{
				try
				{
					File.Delete(Application.StartupPath + "\\data.sqlite");
					if (Globals.dbg)
					{
						Log.WriteToLog("Database copy deleted");
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ProjectData.ClearProjectError();
				}
			}
			if (Resolution.ResChanged)
			{
				AddToListboxAndScroll("Resetting Desktop resolution");
				Log.WriteToLog("Resetting Desktop resolution");
				Resolution.RestoreDisplaySettings();
			}
			NotifyIcon1.Visible = false;
			NotifyIcon1.Dispose();
			NotifyIcon3.Visible = false;
			NotifyIcon3.Dispose();
			Log.WriteToLog("bye bye");
			if (restartInDBG)
			{
				Log.WriteToLog("Restarting application...");
				NotifyIcon1.Visible = false;
				NotifyIcon1.Dispose();
				Application.Restart();
			}
			else
			{
				Environment.Exit(0);
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			Log.WriteToLog(ex6.Message);
			NotifyIcon1.Visible = false;
			NotifyIcon1.Dispose();
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public void CloseClient()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CloseClient");
		}
		try
		{
			if (GetConfig.SetRiftDefault)
			{
				if (MySettingsProperty.Settings.SetRiftAudioDefault == 0)
				{
					AudioSwitcher.SetFallbackAudioDevice();
					AudioSwitcher.SetFallbackCommAudioDevice();
				}
				if (MySettingsProperty.Settings.SetRiftMicDefault == 0)
				{
					AudioSwitcher.SetFallbackMicDevice();
					AudioSwitcher.SetFallbackCommMicDevice();
				}
			}
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			if (processesByName.Length > 0)
			{
				Log.WriteToLog("Closing Oculus Home");
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					process.Kill();
					process.WaitForExit();
				}
			}
			Process[] processesByName2 = Process.GetProcessesByName("oculus-platform-runtime");
			if (processesByName2.Length > 0)
			{
				processesByName2[0].Kill();
			}
			HomeIsRunning = false;
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting CloseClient");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.EndApp();
			ProjectData.ClearProjectError();
		}
	}

	private void GetSteamPath()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetSteamPath");
		}
		try
		{
			if (MyProject.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam") != null)
			{
				SteamPath = MyProject.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam", writable: false).GetValue("SteamPath").ToString()
					.Replace("/", "\\");
				if (Globals.dbg)
				{
					Log.WriteToLog("Steam Path: " + SteamPath);
				}
			}
			else
			{
				SteamPath = "";
				AddToListboxAndScroll("Steam path not found");
				Log.WriteToLog("Steam path not found");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetSteamPath");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: Could not get Steam installation path: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("GetSteamPath: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void GetSteamVR()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetSteamVR");
		}
		try
		{
			if (Operators.CompareString(SteamPath, "", TextCompare: false) != 0)
			{
				string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\openvr\\openvrpaths.vrpath";
				if (Globals.dbg)
				{
					Log.WriteToLog("Looking for " + text);
				}
				if (File.Exists(text))
				{
					if (Globals.dbg)
					{
						Log.WriteToLog(text + " found, getting SteamVR path");
					}
					string json = File.ReadAllText(text);
					JObject jObject = JObject.Parse(json);
					string text2 = jObject.SelectToken("runtime").ToString().Replace("[", "")
						.Replace("]", "")
						.Replace("\\\\", "\\")
						.Replace("\"", "")
						.Trim();
					if (text2.Contains(","))
					{
						string[] array = Strings.Split(text2, ",");
						steamvr = array[0].Trim();
					}
					else
					{
						steamvr = text2.Trim();
					}
					if (!steamvr.EndsWith("\\"))
					{
						steamvr += "\\";
					}
					MyProject.Forms.frmLibrary.AddSteamVRToolStripMenuItem.Enabled = true;
					if (Globals.dbg)
					{
						Log.WriteToLog("SteamVR path: " + steamvr);
					}
				}
				else
				{
					MyProject.Forms.frmLibrary.AddSteamVRToolStripMenuItem.Enabled = false;
					Log.WriteToLog(text + " was not found, could not get SteamVR path");
					AddToListboxAndScroll("Could not get SteamVR path");
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetSteamVR");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: Could not get SteamVR path: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("GetSteamVR: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void PrintSettings(bool migrate)
	{
		Log.WriteToLog("## Current Settings ##");
		List<string> list = new List<string>();
		foreach (SettingsPropertyValue propertyValue in MySettingsProperty.Settings.PropertyValues)
		{
			list.Add(propertyValue.Name + " = " + propertyValue.PropertyValue.ToString());
		}
		list.Sort();
		foreach (string item in list)
		{
			if (!migrate)
			{
				Log.WriteToLog(item.Replace("{", "[").Replace("}", "]"));
			}
			else
			{
				Log.WriteToMigrateLog(item);
			}
		}
		Log.WriteToLog("## End Settings ##");
	}

	public void Recheck()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering Recheck");
		}
		hasWarning = false;
		ListBox1.Items.Clear();
		PowerPlans.CheckPowerState(change: false);
		CheckWarnings();
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting Recheck");
		}
	}

	public void CheckWarnings()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CheckWarnings");
		}
		checked
		{
			if (hasError)
			{
				DotNetBarTabcontrol1.TabPages[4].Text = "Log (Error)";
				ListBox1.TopIndex = ListBox1.Items.Count - 1;
				ListBox1.Refresh();
			}
			else if (hasWarning)
			{
				DotNetBarTabcontrol1.TabPages[4].Text = "Log (Warning)";
				ListBox1.TopIndex = ListBox1.Items.Count - 1;
				ListBox1.Refresh();
			}
			else if (!(!hasError & !hasWarning) && Globals.dbg)
			{
				Log.WriteToLog("Exiting CheckWarnings");
			}
		}
	}

	public void LoadVoiceSettings()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering LoadVoiceSettings");
		}
		if (Operators.CompareString(MySettingsProperty.Settings.StartVoice, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.StartVoice = "computer, start listening;speech on";
			MySettingsProperty.Settings.StartVoiceEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.StopVoice, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.StopVoice = "computer, stop listening;speech off";
			MySettingsProperty.Settings.StopVoiceEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.EnableASW, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.EnableASW = "enable spacewarp";
			MySettingsProperty.Settings.EnableASWEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.DisableASW, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.DisableASW = "disable spacewarp";
			MySettingsProperty.Settings.DisableASWEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowPD, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowPD = "show pixel density; show super sampling";
			MySettingsProperty.Settings.ShowPDEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowPerf, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowPerf = "show performance";
			MySettingsProperty.Settings.ShowPerfEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.Close, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.Close = "close overlay";
			MySettingsProperty.Settings.CloseEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.SetPD, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.SetPD = "set pixel density;set super sampling";
			MySettingsProperty.Settings.SetPDEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowASW, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowASW = "show spacewarp";
			MySettingsProperty.Settings.ShowASWEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.LockASWOn, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.LockASWOn = "lock framerate";
			MySettingsProperty.Settings.LockASWOnEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowLatency, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowLatency = "show latency timing";
			MySettingsProperty.Settings.ShowLatencyEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowApplicationRender, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowApplicationRender = "show application timing";
			MySettingsProperty.Settings.ShowApplicationRenderEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowCompositorRender, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowCompositorRender = "show compositor timing";
			MySettingsProperty.Settings.ShowCompositorRenderEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.ShowVersion, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowVersion = "show version";
			MySettingsProperty.Settings.ShowVersionEnabled = true;
		}
		if (Operators.CompareString(MySettingsProperty.Settings.LaunchSteam, "", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.LaunchSteam = "start steam;launch steam";
			MySettingsProperty.Settings.LaunchSteamEnabled = true;
		}
		MySettingsProperty.Settings.Save();
		MyProject.Forms.frmVoiceSettings.ListView1.Items.Clear();
		ListViewItem listViewItem = new ListViewItem();
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Enable Voice Control");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.StartVoice);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.StartVoiceEnabled));
		listViewItem.UseItemStyleForSubItems = false;
		listViewItem.SubItems[2].ForeColor = Color.Gray;
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Disable Voice Control");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.StopVoice);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.StopVoiceEnabled));
		listViewItem.UseItemStyleForSubItems = false;
		listViewItem.SubItems[2].ForeColor = Color.Gray;
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Set Pixel Density");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.SetPD);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.SetPDEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Disable ASW");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.DisableASW);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.DisableASWEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Enable ASW");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.EnableASW);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.EnableASWEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("45 fps, ASW On");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.LockASWOn);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.LockASWOnEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show ASW Status");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowASW);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowASWEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show Pixel Density");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowPD);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowPDEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show Performance");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowPerf);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowPerfEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show Latency Timing");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowLatency);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowLatencyEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show Application Render Timing");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowApplicationRender);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowApplicationRenderEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show Compositor Render Timing");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowCompositorRender);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowCompositorRenderEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Show Version Info");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.ShowVersion);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.ShowVersionEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Close Overlay");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.Close);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.CloseEnabled));
		listViewItem = MyProject.Forms.frmVoiceSettings.ListView1.Items.Add("Launch SteamVR");
		listViewItem.SubItems.Add(MySettingsProperty.Settings.LaunchSteam);
		listViewItem.SubItems.Add(Conversions.ToString(MySettingsProperty.Settings.LaunchSteamEnabled));
		MyProject.Forms.frmVoiceSettings.ListView1.Columns[0].Width = -1;
		MyProject.Forms.frmVoiceSettings.ListView1.Columns[1].Width = -1;
		voiceSettingsLoaded = true;
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting LoadVoiceSettings");
		}
	}

	private bool IsInRange(double x, double a, double b)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering IsInRange");
		}
		if (x >= a && x <= b)
		{
			return true;
		}
		return false;
	}

	private void CheckStartWithWindows()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CheckStartWithWindows");
		}
		try
		{
			if (MySettingsProperty.Settings.StartWithWindows)
			{
				CheckStartWindows.Checked = true;
			}
			else
			{
				CheckStartWindows.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting CheckStartWithWindows");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Start with Windows: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("CheckStartWithWindows: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckStartWindows_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (GetConfig.IsReading)
			{
				return;
			}
			if (isElevated)
			{
				if (CheckStartWindows.Checked)
				{
					MyProject.Forms.frmStartupType.ShowDialog();
					return;
				}
				CreateTask.GetAndDeleteTask("Oculus Tray Tool");
				if (Operators.ConditionalCompareObjectNotEqual(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true).GetValue(Application.ProductName), null, TextCompare: false))
				{
					MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true).DeleteValue(Application.ProductName);
				}
				MySettingsProperty.Settings.StartWithWindows = false;
				MySettingsProperty.Settings.Save();
				Log.WriteToLog("Disabled 'Start with Windows'");
			}
			else
			{
				GetConfig.IsReading = true;
				CheckStartWindows.Checked = false;
				GetConfig.IsReading = false;
				Interaction.MsgBox("You must run the application as Administrator to change this option.", MsgBoxStyle.Critical, "Oculus Tray Tool");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Start with Windows: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void CheckOculusService()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CheckOculusService");
		}
		try
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			ServiceController serviceController = new ServiceController("OVRService");
			if (serviceController.Status == ServiceControllerStatus.Stopped)
			{
				ovrDown = true;
				LabelServiceStatus.ForeColor = Color.Red;
				LabelServiceStatus.Text = "Down";
				ButtonStartOVR.Enabled = true;
				ButtonStopOVR.Enabled = false;
				ButtonRestartOVR.Enabled = false;
				ToolStripStartOVR.Enabled = true;
				ToolStripStopOVR.Enabled = false;
				ToolStripRestartOVR.Enabled = false;
				Log.WriteToLog("OVR Service is DOWN");
				AddToListboxAndScroll("OVR Service is down, some options disabled");
				OVRIsRunning = false;
				ComboVisualHUD.Text = "None";
				ComboVisualHUD.Enabled = false;
				ComboBox1.Enabled = false;
				HotKeysCheckBox.Enabled = false;
				GetConfig.UseHotKeys = false;
				kbHook = null;
				if (!CheckStartService.Checked & !spoofid)
				{
					hasWarning = true;
					Log.WriteToLog("Warning: OVR Service is DOWN, not managed by Oculus Tray Tool");
				}
			}
			if (serviceController.Status == ServiceControllerStatus.Running)
			{
				Log.WriteToLog("OVR Service is UP");
				AddToListboxAndScroll("OVR Service is UP");
				LabelServiceStatus.ForeColor = Color.Green;
				LabelServiceStatus.Text = "Up";
				ButtonStartOVR.Enabled = false;
				ButtonStopOVR.Enabled = true;
				ButtonRestartOVR.Enabled = true;
				ToolStripStartOVR.Enabled = false;
				ToolStripStopOVR.Enabled = true;
				ToolStripRestartOVR.Enabled = true;
				if ((Operators.CompareString(GetConfig.ppdpstartup, "", TextCompare: false) != 0) & (Operators.CompareString(GetConfig.ppdpstartup, "0", TextCompare: false) != 0))
				{
					Thread thread = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
					});
					thread.Start();
				}
				ComboOVRPrio.Text = MySettingsProperty.Settings.OVRSrvPrio;
				if (Operators.CompareString(MySettingsProperty.Settings.OVRSrvPrio, "Normal", TextCompare: false) != 0)
				{
					ChangeCPUPrioOVR(MySettingsProperty.Settings.OVRSrvPrio);
				}
				if (MySettingsProperty.Settings.ASW == 0)
				{
					Thread thread2 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Auto");
					});
					thread2.Start();
					AddToListboxAndScroll("ASW set to Auto");
					ComboBox1.Text = "Auto";
				}
				if (MySettingsProperty.Settings.ASW == 1)
				{
					Thread thread3 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Off");
					});
					thread3.Start();
					AddToListboxAndScroll("ASW set to Off");
					ComboBox1.Text = "Off";
				}
				if (MySettingsProperty.Settings.ASW == 2)
				{
					Thread thread4 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock45");
					});
					thread4.Start();
					AddToListboxAndScroll("Framerate @ 45 Hz");
					ComboBox1.Text = "45 Hz";
				}
				if (MySettingsProperty.Settings.ASW == 3)
				{
					Thread thread5 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock30");
					});
					thread5.Start();
					AddToListboxAndScroll("Framerate @ 30 Hz");
					ComboBox1.Text = "30 Hz";
				}
				if (MySettingsProperty.Settings.ASW == 4)
				{
					Thread thread6 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock18");
					});
					thread6.Start();
					AddToListboxAndScroll("Framerate @ 18 Hz");
					ComboBox1.Text = "18 Hz";
				}
				if (MySettingsProperty.Settings.ASW == 5)
				{
					Thread thread7 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Sim45");
					});
					thread7.Start();
					AddToListboxAndScroll("Framerate forced to 45 Hz");
					ComboBox1.Text = "45 Hz forced";
				}
				if (MySettingsProperty.Settings.ASW == 6)
				{
					Thread thread8 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
					});
					thread8.Start();
					AddToListboxAndScroll("Framerate set to Adaptive");
					ComboBox1.Text = "Adaptive";
				}
				if ((Conversions.ToDouble(MySettingsProperty.Settings.FOVh) != 0.0) & (Conversions.ToDouble(MySettingsProperty.Settings.FOVh) != 1.0) & (Conversions.ToDouble(MySettingsProperty.Settings.FOVv) != 0.0) & (Conversions.ToDouble(MySettingsProperty.Settings.FOVv) != 1.0))
				{
					Thread thread9 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_fov("service set-client-fov-tan-angle-multiplier " + MySettingsProperty.Settings.FOVh + " " + MySettingsProperty.Settings.FOVv);
					});
					thread9.Start();
					AddToListboxAndScroll("FOV set to " + MySettingsProperty.Settings.FOVh + "; " + MySettingsProperty.Settings.FOVv);
				}
				if (MySettingsProperty.Settings.AdaptiveGPUScaling)
				{
					Thread thread10 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_agps("true");
					});
					thread10.Start();
					AddToListboxAndScroll("Adaptive GPU Scaling Enabled");
				}
				if (!MySettingsProperty.Settings.AdaptiveGPUScaling)
				{
					Thread thread11 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_agps("false");
					});
					thread11.Start();
					AddToListboxAndScroll("Adaptive GPU Scaling Disabled");
				}
				Thread thread12 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_force_mipmap(MySettingsProperty.Settings.ForceMipmap);
				});
				thread12.Start();
				Thread thread13 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_offset_mipmap(MySettingsProperty.Settings.OffsetMipmap);
				});
				thread13.Start();
				ComboVisualHUD.SelectedIndex = 0;
				OVRIsRunning = true;
				ComboVisualHUD.Enabled = true;
				ComboBox1.Enabled = true;
				HotKeysCheckBox.Enabled = true;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting CheckOculusService");
			}
			Control.CheckForIllegalCrossThreadCalls = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			LabelServiceStatus.ForeColor = Color.Red;
			LabelServiceStatus.Text = "N/A";
			ButtonStartOVR.Enabled = false;
			ButtonStopOVR.Enabled = false;
			ButtonRestartOVR.Enabled = false;
			ComboVisualHUD.Enabled = false;
			ComboBox1.Enabled = false;
			HotKeysCheckBox.Enabled = false;
			GetConfig.UseHotKeys = false;
			kbHook = null;
			OVRIsRunning = false;
			BtnLibrary.Enabled = false;
			OculusServiceFound = false;
			Log.WriteToLog("Could not get the Oculus Service");
			AddToListboxAndScroll("Could not get the Oculus Service");
			hasError = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			Control.CheckForIllegalCrossThreadCalls = true;
			ProjectData.ClearProjectError();
		}
	}

	public void StartOVR()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering StartOVR");
		}
		try
		{
			Application.DoEvents();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Service Where Name=\"OVRService\"");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string left = item.GetPropertyValue("StartMode").ToString().Replace("\"", "");
				if (Operators.CompareString(left, "Disabled", TextCompare: false) == 0)
				{
					AddToListboxAndScroll("* Oculus Service Is set to Disabled, cannot continue");
					hasError = true;
					return;
				}
			}
			AddToListboxAndScroll("Starting OVR Service...");
			Log.WriteToLog("Starting OVR Service...");
			ServiceController serviceController = new ServiceController("OVRService");
			if (serviceController.Status == ServiceControllerStatus.Stopped)
			{
				Cursor = Cursors.WaitCursor;
				serviceController.Start();
				serviceController.WaitForStatus(ServiceControllerStatus.Running);
				Log.WriteToLog("Sleeping for " + Conversions.ToString(MySettingsProperty.Settings.SleepAfterServiceStart) + "ms after service start");
				Thread.Sleep(MySettingsProperty.Settings.SleepAfterServiceStart);
				CheckOculusService();
				if (CheckLaunchHome.Checked)
				{
					if (File.Exists(OculusPath + "Support\\oculus-client\\OculusClient.exe"))
					{
						Log.WriteToLog("Sleeping 5s before starting Home");
						Hometimer.Interval = 5000;
						Hometimer.Tick += HomeTimerTick;
						Hometimer.Start();
					}
					else
					{
						Log.WriteToLog("Could Not locate OculusClient in " + OculusPath);
						AddToListboxAndScroll("Could Not locate OculusClient in " + OculusPath);
						hasWarning = true;
					}
				}
				Cursor = Cursors.Default;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting StartOVR");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			LabelServiceStatus.ForeColor = Color.Red;
			LabelServiceStatus.Text = "N/A";
			ButtonStartOVR.Enabled = false;
			AddToListboxAndScroll("* Start OVR:  " + ex2.Message);
			hasError = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void HomeTimerTick(object sender, EventArgs e)
	{
		Hometimer.Stop();
		RunCommand.StartHome();
	}

	public void CloseHome()
	{
		Process[] processesByName = Process.GetProcessesByName("oculus-platform-runtime");
		if (processesByName.Length > 0)
		{
			Log.WriteToLog("Closing Oculus Home");
			processesByName[0].Kill();
		}
		Process[] processesByName2 = Process.GetProcessesByName("OVRServiceLauncher");
		if (processesByName2.Length > 0)
		{
			Log.WriteToLog("Closing OVRServiceLauncher");
			processesByName2[0].Kill();
		}
		Process[] processesByName3 = Process.GetProcessesByName("OVRServer_x64");
		if (processesByName3.Length > 0)
		{
			Log.WriteToLog("Closing OVRServer_x64");
			processesByName3[0].Kill();
		}
		Process[] processesByName4 = Process.GetProcessesByName("OVRRedir");
		if (processesByName4.Length > 0)
		{
			Log.WriteToLog("Closing OVRRedir");
			processesByName4[0].Kill();
		}
	}

	public void StopOVR()
	{
		Cursor.Current = Cursors.WaitCursor;
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering StopOVR");
		}
		if (HomeIsRunning)
		{
			CloseHome();
		}
		AddToListboxAndScroll("Stopping OVR Service...");
		Log.WriteToLog("Stopping OVR Service...");
		ServiceController serviceController = new ServiceController("OVRService");
		if (serviceController.Status == ServiceControllerStatus.Running)
		{
			serviceController.Stop();
			serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
		}
		CheckOculusService();
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting StopOVR");
		}
		Cursor.Current = Cursors.Default;
	}

	public void DisableFrescoPower()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering DisableFrescoPower");
		}
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\wmi", "SELECT * FROM MSPower_DeviceEnable");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = NewLateBinding.LateGet(item["InstanceName"], null, "TrimEnd", new object[1] { "0" }, null, null, null).ToString().TrimEnd('_')
					.ToUpper();
				if (text.Contains("ROOT_HUB_FL30") && Operators.ConditionalCompareObjectEqual(item.GetPropertyValue("Enable"), true, TextCompare: false))
				{
					item.SetPropertyValue("Enable", false);
					item.Put();
					Log.WriteToLog("Disabled Fresco Logic Power Management");
					AddToListboxAndScroll("Disabled Fresco Logic Power Management");
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting DisableFrescoPower");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Disable Fresco Power Management: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("DisableFrescoPower: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void Form1_Resize(object sender, EventArgs e)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering Resize");
		}
		if (base.WindowState == FormWindowState.Minimized)
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("WindowState=Minimized");
			}
			base.ShowInTaskbar = false;
			if (GetConfig.hideAltTab)
			{
				base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			}
		}
		if (base.WindowState == FormWindowState.Normal)
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("WindowState=Normal");
			}
			base.ShowInTaskbar = true;
			if (GetConfig.hideAltTab)
			{
				base.FormBorderStyle = FormBorderStyle.FixedSingle;
			}
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting Resize");
		}
	}

	public void ShowForm()
	{
		try
		{
			if (GetConfig.IsReading)
			{
				return;
			}
			base.ShowInTaskbar = true;
			if (GetConfig.hideAltTab)
			{
				base.FormBorderStyle = FormBorderStyle.FixedSingle;
			}
			base.WindowState = FormWindowState.Normal;
			if ((base.Location.X < 0) | (base.Location.Y < 0))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("GUI location has negative number, adjusting");
				}
				CenterToScreen();
				MySettingsProperty.Settings.WindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ShowForm: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Minimized)
		{
			ShowForm();
		}
	}

	private void ToolStripMenuItem2_Click(object sender, EventArgs e)
	{
		if (GetConfig.hideAltTab)
		{
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
		}
		base.ShowInTaskbar = true;
		base.WindowState = FormWindowState.Normal;
	}

	private void CheckStartMin_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckStartMin.Checked)
				{
					MySettingsProperty.Settings.StartMinimized = true;
				}
				else
				{
					MySettingsProperty.Settings.StartMinimized = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void ButtonStartOVR_Click(object sender, EventArgs e)
	{
		StartOVR();
		if (CheckLaunchHome.Checked)
		{
			ServiceController serviceController = new ServiceController("OVRService");
			if (serviceController.Status == ServiceControllerStatus.Running)
			{
				RunCommand.StartHome();
			}
		}
	}

	public void AppWork(object sender, DoWorkEventArgs e)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering AppWork");
		}
		try
		{
			Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(runningApp));
			if (processesByName.Length > 0)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Waiting for " + Path.GetFileNameWithoutExtension(runningApp) + " to exit");
				}
				processesByName[0].WaitForExit();
				Log.WriteToLog(runningapp_displayname + ": App has exited");
				AddToListboxAndScroll(runningapp_displayname + ": App has exited");
				pid = 0;
				ManualStart = false;
				runningApp = null;
				runningapp_displayname = "";
				Watcher.Start();
				if (!NoProfileFound)
				{
					Thread thread = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
					});
					thread.Start();
					if (mirrorTimer.Enabled)
					{
						mirrorTimer.Stop();
						if (Globals.dbg)
						{
							Log.WriteToLog("Mirror Timer stopped");
						}
					}
					if (MySettingsProperty.Settings.ASW == 0)
					{
						Thread thread2 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Auto");
						});
						thread2.Start();
						AddToListboxAndScroll("ASW set to Auto");
					}
					if (MySettingsProperty.Settings.ASW == 1)
					{
						Thread thread3 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Off");
						});
						thread3.Start();
						AddToListboxAndScroll("ASW set to Off");
					}
					if (MySettingsProperty.Settings.ASW == 2)
					{
						Thread thread4 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock45");
						});
						thread4.Start();
						AddToListboxAndScroll("Framerate Locked @ 45 fps");
					}
					Thread thread5 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_force_mipmap(MySettingsProperty.Settings.ForceMipmap.ToString().ToLower());
					});
					thread5.Start();
					Thread thread6 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_offset_mipmap(MySettingsProperty.Settings.OffsetMipmap.ToString());
					});
					thread6.Start();
					Thread thread7 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_fov("service set-client-fov-tan-angle-multiplier " + MySettingsProperty.Settings.FOVh + " " + MySettingsProperty.Settings.FOVv);
					});
					thread7.Start();
					if (GetConfig.SetRiftDefault)
					{
						if (MySettingsProperty.Settings.SetRiftAudioDefault == 2)
						{
							Thread thread8 = new Thread([SpecialName] () =>
							{
								AudioSwitcher.SetFallbackAudioDevice();
								AudioSwitcher.SetFallbackCommAudioDevice();
							});
							thread8.Start();
						}
						if (MySettingsProperty.Settings.SetRiftMicDefault == 2)
						{
							Thread thread9 = new Thread([SpecialName] () =>
							{
								AudioSwitcher.SetFallbackMicDevice();
								AudioSwitcher.SetFallbackCommMicDevice();
							});
							thread9.Start();
						}
					}
					if (Resolution.ResChanged)
					{
						AddToListboxAndScroll("Resetting Desktop resolution");
						Log.WriteToLog("Resetting Desktop resolution");
						Resolution.RestoreDisplaySettings();
					}
					if (OTTDB.numWMI > 0)
					{
						CreateWatcher();
					}
					if (OTTDB.numTimer > 0)
					{
						Log.WriteToLog("Starting Timer AppWatcher");
						pTimer.Start();
					}
				}
				else
				{
					NoProfileFound = false;
				}
			}
			else if (Globals.dbg)
			{
				Log.WriteToLog("AppWork: " + Path.GetFileNameWithoutExtension(runningApp) + " was not fund");
			}
			AppWatchWorker.DoWork -= AppWork;
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting AppWork");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("AppWork: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void ToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Shutdown();
	}

	private void ButtonStopOVR_Click(object sender, EventArgs e)
	{
		StopOVR();
	}

	private void ButtonRestartOVR_Click(object sender, EventArgs e)
	{
		StopOVR();
		Cursor = Cursors.WaitCursor;
		LabelServiceStatus.Refresh();
		AddToListboxAndScroll("Waiting 4s until start of the OVR service to ensure proper tracking");
		Thread.Sleep(4000);
		StartOVR();
		LabelServiceStatus.Refresh();
		Cursor = Cursors.Default;
	}

	private void CheckStartService_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckStartService.Checked)
				{
					MySettingsProperty.Settings.StartOVR = true;
				}
				else
				{
					MySettingsProperty.Settings.StartOVR = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckStopService_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckStopService.Checked)
				{
					MySettingsProperty.Settings.StopOVR = true;
				}
				else
				{
					MySettingsProperty.Settings.StopOVR = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckLaunchHome_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckLaunchHome.Checked)
				{
					MySettingsProperty.Settings.StartHomeOnServiceStart = true;
					CheckLaunchHomeTool.Checked = false;
				}
				else
				{
					MySettingsProperty.Settings.StartHomeOnServiceStart = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckLaunchHomeTool_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckLaunchHomeTool.Checked)
				{
					MySettingsProperty.Settings.StartHomeOnToolStart = true;
					CheckLaunchHome.Checked = false;
				}
				else
				{
					MySettingsProperty.Settings.StartHomeOnToolStart = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckCloseHome_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckCloseHome.Checked)
				{
					MySettingsProperty.Settings.CloseHomeOnExit = true;
				}
				else
				{
					MySettingsProperty.Settings.CloseHomeOnExit = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckBoxAltTab_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckBoxAltTab.Checked)
				{
					MySettingsProperty.Settings.HideAltTab = true;
					GetConfig.hideAltTab = true;
				}
				else
				{
					MySettingsProperty.Settings.HideAltTab = false;
					GetConfig.hideAltTab = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void CheckRiftAudio_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckRiftAudio.Checked)
		{
			MySettingsProperty.Settings.SetRiftAsDefault = true;
			GetConfig.SetRiftDefault = true;
			MySettingsProperty.Settings.Save();
			if ((Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, "", TextCompare: false) == 0) | (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, "", TextCompare: false) == 0))
			{
				Cursor = Cursors.WaitCursor;
				MyProject.Forms.FrmSetFallback.ShowDialog();
				Cursor = Cursors.Default;
			}
		}
		else
		{
			MySettingsProperty.Settings.SetRiftAsDefault = false;
			GetConfig.SetRiftDefault = false;
			MySettingsProperty.Settings.Save();
		}
	}

	private void StartWatcherNoHome()
	{
		try
		{
			if (GetConfig.SetRiftDefault)
			{
				if (MySettingsProperty.Settings.SetRiftAudioDefault == 0)
				{
					Thread thread = new Thread([SpecialName] () =>
					{
						AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: false);
					});
					thread.Start();
				}
				if (MySettingsProperty.Settings.SetRiftMicDefault == 0)
				{
					Thread thread2 = new Thread([SpecialName] () =>
					{
						AudioSwitcher.SetDefaultMicDeviceOnStart();
					});
					thread2.Start();
				}
			}
			if (OTTDB.numWMI > 0)
			{
				CreateWatcher();
			}
			else
			{
				Log.WriteToLog("No WMI profiles found");
			}
			if (OTTDB.numTimer > 0)
			{
				Log.WriteToLog("Starting Timer AppWatcher");
				pTimer.Start();
			}
			else
			{
				Log.WriteToLog("No Timer profiles found");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("StartWatcherNoHome: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void CreateWatcher()
	{
		try
		{
			Watcher.Stop();
			Log.WriteToLog("Starting WMI AppWatcher");
			string query = "SELECT TargetInstance  FROM __InstanceCreationEvent WITHIN  1.0  WHERE TargetInstance ISA 'Win32_Process'    AND TargetInstance.Name like '%'";
			string scope = "\\\\.\\root\\CIMV2";
			Watcher = new ManagementEventWatcher(scope, query);
			Watcher.Start();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("CreateWatcher: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void StopWatcherNoHome()
	{
		try
		{
			Log.WriteToLog("Stopping AppWatcher");
			Watcher.Stop();
			pTimer.Stop();
			if (VoiceCommands.isListening)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Stopping voice command listener");
				}
				VoiceCommands.StopListening();
			}
			if (VoiceCommands.grammarsBuilt)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Disabling voice commands");
				}
				VoiceCommands.DisableVoice();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("StopWatcherNoHome: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void OculusHomeWatcher_Tick(object sender, EventArgs e)
	{
		Process[] processesByName = Process.GetProcessesByName("OculusClient");
		if (processesByName.Length <= 0)
		{
			return;
		}
		try
		{
			OculusHomeWatcher.Stop();
			HomeIsRunning = true;
			Log.WriteToLog("Oculus Home is running");
			AddToListboxAndScroll("Oculus Home is running");
			if (MySettingsProperty.Settings.ApplyPowerPlan == 1)
			{
				PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
				PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
			}
			if (MySettingsProperty.Settings.SendHomeToTray)
			{
				HometoTrayTimer.Enabled = true;
				if (Globals.dbg)
				{
					Log.WriteToLog("HometoTrayTimer started");
				}
			}
			else
			{
				HometoTrayTimer.Enabled = false;
			}
			if (GetConfig.SetRiftDefault)
			{
				if (MySettingsProperty.Settings.SetRiftAudioDefault == 0)
				{
					if (MySettingsProperty.Settings.SetAudioOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: false);
					}
					if (MySettingsProperty.Settings.SetAudioCommOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultAudioCommDeviceOnStart();
					}
				}
				if (MySettingsProperty.Settings.SetRiftMicDefault == 0)
				{
					if (MySettingsProperty.Settings.SetMicOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultMicDeviceOnStart();
					}
					if (MySettingsProperty.Settings.SetMicCommOnStartGuid != null)
					{
						AudioSwitcher.SetDefaultMicCommDeviceOnStart();
					}
				}
			}
			if (MySettingsProperty.Settings.ASW == 0)
			{
				Thread thread = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Auto");
				});
				thread.Start();
				AddToListboxAndScroll("ASW set to Auto");
				ComboBox1.Text = "Auto";
			}
			if (MySettingsProperty.Settings.ASW == 1)
			{
				Thread thread2 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Off");
				});
				thread2.Start();
				AddToListboxAndScroll("ASW set to Off");
				ComboBox1.Text = "Off";
			}
			if (MySettingsProperty.Settings.ASW == 2)
			{
				Thread thread3 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Clock45");
				});
				thread3.Start();
				AddToListboxAndScroll("Framerate @ 45 Hz");
				ComboBox1.Text = "45 Hz";
			}
			if (MySettingsProperty.Settings.ASW == 3)
			{
				Thread thread4 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Clock30");
				});
				thread4.Start();
				AddToListboxAndScroll("Framerate @ 30 Hz");
				ComboBox1.Text = "30 Hz";
			}
			if (MySettingsProperty.Settings.ASW == 4)
			{
				Thread thread5 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Clock18");
				});
				thread5.Start();
				AddToListboxAndScroll("Framerate @ 18 Hz");
				ComboBox1.Text = "18 Hz";
			}
			if (MySettingsProperty.Settings.ASW == 5)
			{
				Thread thread6 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Sim45");
				});
				thread6.Start();
				AddToListboxAndScroll("Framerate forced to 45 Hz");
				ComboBox1.Text = "45 Hz forced";
			}
			if (MySettingsProperty.Settings.ASW == 6)
			{
				Thread thread7 = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
				});
				thread7.Start();
				AddToListboxAndScroll("Framerate set to Adaptive");
				ComboBox1.Text = "Adaptive";
			}
			if (OTTDB.numWMI > 0)
			{
				CreateWatcher();
			}
			if (OTTDB.numTimer > 0)
			{
				Log.WriteToLog("Starting Timer AppWatcher");
				pTimer.Start();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Adding backgroundworker for monitoring Oculus Home/SteamVR");
			}
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += HomeWork;
			backgroundWorker.RunWorkerAsync();
			if (Globals.dbg)
			{
				Log.WriteToLog("Backgroundworker started");
			}
			if (MySettingsProperty.Settings.MirrorHome)
			{
				_Home2Timer.Elapsed += _Home2TimerElapsed;
				_Home2Timer.Start();
			}
			if (MySettingsProperty.Settings.UseVoiceCommands)
			{
				EnableDisableVoice(enable: true);
			}
			if (MySettingsProperty.Settings.UseHotKeys)
			{
				kbHook = new KeyboardHook();
			}
			else
			{
				kbHook = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll(ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("OculusHomeWatcher_Tick: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void _Home2TimerElapsed(object sender, ElapsedEventArgs e)
	{
		Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
		if (processesByName.Length > 0)
		{
			_Home2Timer.Stop();
			Log.WriteToLog("Starting Oculus Mirror ");
			Process.Start(OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
			MinMaxApp.MaximizeApp("OculusMirror");
			if (Globals.dbg)
			{
				Log.WriteToLog("Adding backgroundworker for Oculus Mirror");
			}
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += Home2Work;
			backgroundWorker.RunWorkerAsync();
			if (Globals.dbg)
			{
				Log.WriteToLog("Backgroundworker started");
			}
		}
	}

	private void OnTimerProfile(object source, ElapsedEventArgs e)
	{
		if (ManualStart)
		{
			return;
		}
		checked
		{
			_Closure_0024__136_002D0 closure_0024__136_002D = default(_Closure_0024__136_002D0);
			_Closure_0024__136_002D1 closure_0024__136_002D2 = default(_Closure_0024__136_002D1);
			foreach (KeyValuePair<string, string> profileTimer in profileTimerList)
			{
				Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(profileTimer.Key));
				if (processesByName.Length <= 0)
				{
					continue;
				}
				try
				{
					closure_0024__136_002D = new _Closure_0024__136_002D0(closure_0024__136_002D);
					pTimer.Stop();
					string text = "";
					runningApp = profileTimer.Key;
					CurrentSS = profileTimer.Value;
					pid = processesByName[0].Id;
					runningapp_displayname = OTTDB.GetDisplayName(runningApp);
					Log.WriteToLog("Game launch detected using Timer:  " + runningapp_displayname + " with PID " + Conversions.ToString(pid) + " (" + appName + ")");
					AddToListboxAndScroll(runningapp_displayname + ": Applying profile");
					Thread thread = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool(CurrentSS);
					});
					thread.Start();
					closure_0024__136_002D._0024VB_0024Local_fov = "";
					if (profileFOV.TryGetValue(runningApp.ToLower(), out closure_0024__136_002D._0024VB_0024Local_fov))
					{
						Thread thread2 = new Thread(closure_0024__136_002D._Lambda_0024__1);
						thread2.Start();
					}
					closure_0024__136_002D._0024VB_0024Local_forcemipmap = "";
					if (profileForceMipMap.TryGetValue(runningApp.ToLower(), out closure_0024__136_002D._0024VB_0024Local_forcemipmap))
					{
						Thread thread3 = new Thread(closure_0024__136_002D._Lambda_0024__2);
						thread3.Start();
					}
					closure_0024__136_002D._0024VB_0024Local_offsetmipmap = "";
					if (profileOffsetMipMap.TryGetValue(runningApp.ToLower(), out closure_0024__136_002D._0024VB_0024Local_offsetmipmap))
					{
						Thread thread4 = new Thread(closure_0024__136_002D._Lambda_0024__3);
						thread4.Start();
					}
					string value = "";
					if (profileAGPS.TryGetValue(runningApp.ToLower(), out value))
					{
						if (Operators.CompareString(value, "0", TextCompare: false) == 0)
						{
							Thread thread5 = new Thread([SpecialName] () =>
							{
								RunCommand.Run_debug_tool_agps("false");
							});
							thread5.Start();
						}
						else
						{
							Thread thread6 = new Thread([SpecialName] () =>
							{
								RunCommand.Run_debug_tool_agps("true");
							});
							thread6.Start();
						}
					}
					if (HomeIsMirrored)
					{
						Process[] processesByName2 = Process.GetProcessesByName("OculusMirror");
						if (processesByName2.Length > 0)
						{
							processesByName2[0].Kill();
							HomeIsMirrored = false;
						}
					}
					if ((!GetConfig.SetRiftDefault | (MySettingsProperty.Settings.SetRiftAudioDefault != 2)) && MySettingsProperty.Settings.VoiceConfirmProfile)
					{
						Thread thread7 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
						});
						thread7.Start();
					}
					if (GetConfig.SetRiftDefault)
					{
						if (MySettingsProperty.Settings.SetRiftAudioDefault == 2)
						{
							if (MySettingsProperty.Settings.VoiceConfirmProfile)
							{
								Thread thread8 = new Thread([SpecialName] () =>
								{
									AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: true);
								});
								thread8.Start();
							}
							else
							{
								Thread thread9 = new Thread([SpecialName] () =>
								{
									AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: false);
								});
								thread9.Start();
							}
						}
						if (MySettingsProperty.Settings.SetRiftMicDefault == 2)
						{
							Thread thread10 = new Thread([SpecialName] () =>
							{
								AudioSwitcher.SetDefaultMicDeviceOnStart();
							});
							thread10.Start();
						}
					}
					string value2 = "";
					if (profileCpuDelay.TryGetValue(runningApp.ToLower(), out value2))
					{
						cpuTimer.AutoReset = false;
						cpuTimer.Interval = Conversions.ToInteger(value2) * 1000;
						cpuTimer.Elapsed += ApplyCpuPrioTick;
						cpuTimer.Start();
						Log.WriteToLog("Timer: " + runningapp_displayname + ": Applying CPU Priority in " + value2 + " seconds");
					}
					string value3 = "";
					if (profileAswDelay.TryGetValue(runningApp.ToLower(), out value3))
					{
						aswTimer.AutoReset = false;
						aswTimer.Interval = Conversions.ToInteger(value3) * 1000;
						aswTimer.Elapsed += ApplyAswTick;
						aswTimer.Start();
						Log.WriteToLog("Timer: " + runningapp_displayname + ": Applying ASW setting in " + value3 + " seconds");
						AddToListboxAndScroll(runningapp_displayname + ": Applying ASW setting in " + value3 + " seconds");
					}
					string value4 = "";
					if (profileMirror.TryGetValue(runningApp.ToLower(), out value4))
					{
						if (Operators.CompareString(value4, "1", TextCompare: false) == 0)
						{
							MinMaxApp.MinimizeCount = 0;
							mirrorTimer.AutoReset = true;
							mirrorTimer.Interval = 5000.0;
							mirrorTimer.Elapsed += ApplyMirrorTick;
							mirrorTimer.Start();
						}
						if (Operators.CompareString(value4, "2", TextCompare: false) == 0)
						{
							Log.WriteToLog("Starting Oculus Mirror");
							Process.Start(OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
						}
					}
					if (Operators.ConditionalCompareObjectNotEqual(GetCurrentResolution(), MySettingsProperty.Settings.DesktopResolution, TextCompare: false))
					{
						closure_0024__136_002D2 = new _Closure_0024__136_002D1(closure_0024__136_002D2);
						AddToListboxAndScroll("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
						Log.WriteToLog("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
						string[] array = Strings.Split(MySettingsProperty.Settings.DesktopResolution, "x");
						closure_0024__136_002D2._0024VB_0024Local_yRes = (short)Conversions.ToInteger(array[0].Trim());
						closure_0024__136_002D2._0024VB_0024Local_xRes = (short)Conversions.ToInteger(array[1].Trim());
						Thread thread11 = new Thread(closure_0024__136_002D2._Lambda_0024__10);
						thread11.Start();
					}
					if (Globals.dbg)
					{
						Log.WriteToLog("Starting AppWatchWorker in 2 seconds");
					}
					Thread.Sleep(2000);
					AppWatchWorker.DoWork += AppWork;
					AppWatchWorker.RunWorkerAsync();
					if (Globals.dbg)
					{
						Log.WriteToLog("Worker started");
					}
					break;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					AddToListboxAndScroll(ex2.Message);
					StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
					Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
	{
		checked
		{
			try
			{
				if (ManualStart)
				{
					return;
				}
				try
				{
					ManagementBaseObject managementBaseObject = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
					runningApp = managementBaseObject.Properties["ExecutablePath"].Value.ToString();
					appName = managementBaseObject.Properties["ExecutablePath"].Value.ToString().ToLower();
					if (AllAppsList.ContainsKey(runningApp))
					{
						pid = Conversions.ToInteger(managementBaseObject.Properties["processId"].Value.ToString().ToLower());
						if (Globals.dbg)
						{
							Log.WriteToLog("Process " + runningApp + " was found in list, storing PID");
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
					return;
				}
				if (Operators.CompareString(Path.GetFileNameWithoutExtension(runningApp), "OculusDash", TextCompare: false) == 0 && Operators.CompareString(MySettingsProperty.Settings.OVRSrvPrio, "Normal", TextCompare: false) != 0)
				{
					Thread thread = new Thread([SpecialName] () =>
					{
						ChangeCPUPrioDash(MySettingsProperty.Settings.OVRSrvPrio);
					});
					thread.Start();
				}
				string value = "";
				if (profileList.TryGetValue(appName, out value))
				{
					Watcher.Stop();
					pTimer.Stop();
					CurrentSS = value;
					runningAppExe = Path.GetFileName(runningApp);
					runningapp_displayname = OTTDB.GetDisplayName(runningApp);
					Log.WriteToLog("Game launch detected using WMI: " + runningapp_displayname + " with PID " + Conversions.ToString(pid) + " (" + appName + ")");
					if (Globals.dbg)
					{
						Log.WriteToLog(runningApp + ": Super Sampling @ " + CurrentSS);
					}
					AddToListboxAndScroll(runningapp_displayname + ": Applying profile");
					Thread thread2 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool(CurrentSS);
					});
					thread2.Start();
					string value2 = "";
					if (profileFOV.TryGetValue(runningApp.ToLower(), out value2))
					{
						Thread thread3 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_fov(value2);
						});
						thread3.Start();
					}
					string value3 = "";
					if (profileForceMipMap.TryGetValue(runningApp.ToLower(), out value3))
					{
						Thread thread4 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_force_mipmap(value3.ToLower());
						});
						thread4.Start();
					}
					string value4 = "";
					if (profileOffsetMipMap.TryGetValue(runningApp.ToLower(), out value4))
					{
						Thread thread5 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_offset_mipmap(value4);
						});
						thread5.Start();
					}
					string value5 = "";
					if (profileAGPS.TryGetValue(runningApp.ToLower(), out value5))
					{
						if (Operators.CompareString(value5, "0", TextCompare: false) == 0)
						{
							Thread thread6 = new Thread([SpecialName] () =>
							{
								RunCommand.Run_debug_tool_agps("false");
							});
							thread6.Start();
						}
						else
						{
							Thread thread7 = new Thread([SpecialName] () =>
							{
								RunCommand.Run_debug_tool_agps("true");
							});
							thread7.Start();
						}
					}
					if (HomeIsMirrored)
					{
						Process[] processesByName = Process.GetProcessesByName("OculusMirror");
						if (processesByName.Length > 0)
						{
							processesByName[0].Kill();
							HomeIsMirrored = false;
						}
					}
					if ((!GetConfig.SetRiftDefault | (MySettingsProperty.Settings.SetRiftAudioDefault != 2)) && MySettingsProperty.Settings.VoiceConfirmProfile)
					{
						Thread thread8 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
						});
						thread8.Start();
					}
					if (GetConfig.SetRiftDefault)
					{
						if (MySettingsProperty.Settings.SetRiftAudioDefault == 2)
						{
							if (MySettingsProperty.Settings.VoiceConfirmProfile)
							{
								Thread thread9 = new Thread([SpecialName] () =>
								{
									AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: true);
								});
								thread9.Start();
							}
							else
							{
								Thread thread10 = new Thread([SpecialName] () =>
								{
									AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: false);
								});
								thread10.Start();
							}
						}
						if (MySettingsProperty.Settings.SetRiftMicDefault == 2)
						{
							Thread thread11 = new Thread([SpecialName] () =>
							{
								AudioSwitcher.SetDefaultMicDeviceOnStart();
							});
							thread11.Start();
						}
					}
					string value6 = "";
					if (profileCpuDelay.TryGetValue(runningApp.ToLower(), out value6))
					{
						cpuTimer.AutoReset = false;
						cpuTimer.Interval = Conversions.ToInteger(value6) * 1000;
						cpuTimer.Elapsed += ApplyCpuPrioTick;
						cpuTimer.Start();
						Log.WriteToLog(runningapp_displayname + ": Applying CPU Priority in " + value6 + " seconds");
						AddToListboxAndScroll(runningapp_displayname + ": Applying CPU Priority in " + value6 + " seconds");
					}
					string value7 = "";
					if (profileAswDelay.TryGetValue(runningApp.ToLower(), out value7))
					{
						aswTimer.AutoReset = false;
						aswTimer.Interval = Conversions.ToInteger(value7) * 1000;
						aswTimer.Elapsed += ApplyAswTick;
						aswTimer.Start();
						Log.WriteToLog(runningapp_displayname + ": Applying ASW setting in " + value7 + " seconds");
						AddToListboxAndScroll(runningapp_displayname + ": Applying ASW setting in " + value7 + " seconds");
					}
					string value8 = "";
					if (profileMirror.TryGetValue(runningApp.ToLower(), out value8))
					{
						if (Operators.CompareString(value8, "1", TextCompare: false) == 0)
						{
							MinMaxApp.MinimizeCount = 0;
							mirrorTimer.AutoReset = true;
							mirrorTimer.Interval = 5000.0;
							mirrorTimer.Elapsed += ApplyMirrorTick;
							mirrorTimer.Start();
						}
						if (Operators.CompareString(value8, "2", TextCompare: false) == 0)
						{
							Log.WriteToLog("Starting Oculus Mirror");
							Process.Start(OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
						}
					}
					if (Operators.ConditionalCompareObjectNotEqual(GetCurrentResolution(), MySettingsProperty.Settings.DesktopResolution, TextCompare: false))
					{
						AddToListboxAndScroll("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
						Log.WriteToLog("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
						string[] array = Strings.Split(MySettingsProperty.Settings.DesktopResolution, "x");
						short num = (short)Conversions.ToInteger(array[0].Trim());
						short num2 = (short)Conversions.ToInteger(array[1].Trim());
						Thread thread12 = new Thread([SpecialName] () =>
						{
							Resolution.ChangeDisplaySettings(num, num2);
						});
						thread12.Start();
					}
					if (Globals.dbg)
					{
						Log.WriteToLog("Starting AppWatchWorker in 2 seconds");
					}
					Thread.Sleep(2000);
					AppWatchWorker.DoWork += AppWork;
					AppWatchWorker.RunWorkerAsync();
					if (Globals.dbg)
					{
						Log.WriteToLog("Worker started");
					}
				}
				else
				{
					runningApp = "";
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("Watcher_EventArrived: " + ex4.ToString());
				if (OTTDB.numWMI > 0)
				{
					CreateWatcher();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ApplyMirrorTick(object sender, ElapsedEventArgs e)
	{
		if (MinMaxApp.MinimizeCount > 0)
		{
			mirrorTimer.Enabled = false;
			return;
		}
		MinMaxApp.SetMirrorRetry = 0;
		MinMaxApp.MinimizeApp(Path.GetFileNameWithoutExtension(runningApp));
	}

	public void ApplyCpuPrioTick(object sender, ElapsedEventArgs e)
	{
		try
		{
			cpuTimer.Enabled = false;
			if (Operators.CompareString(runningApp, "", TextCompare: false) == 0)
			{
				cpuTimer.Enabled = false;
				cpuTimer.Elapsed -= ApplyCpuPrioTick;
				return;
			}
			string value = "";
			if (profilePriorityList.TryGetValue(runningApp.ToLower(), out value))
			{
				Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(runningApp));
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					switch (value)
					{
					case "Normal":
						process.PriorityClass = ProcessPriorityClass.Normal;
						if (process.PriorityClass == ProcessPriorityClass.Normal)
						{
							AddToListboxAndScroll(runningapp_displayname + ": CPU Priority set to 'Normal'");
							Log.WriteToLog(runningapp_displayname + ": CPU Priority set to 'Normal'");
							break;
						}
						continue;
					case "Above Normal":
						process.PriorityClass = ProcessPriorityClass.AboveNormal;
						if (process.PriorityClass == ProcessPriorityClass.AboveNormal)
						{
							AddToListboxAndScroll(runningapp_displayname + ": CPU Priority set to 'Above Normal'");
							Log.WriteToLog(runningapp_displayname + ": CPU Priority set to 'Above Normal'");
							break;
						}
						continue;
					case "High":
						process.PriorityClass = ProcessPriorityClass.High;
						if (process.PriorityClass == ProcessPriorityClass.High)
						{
							AddToListboxAndScroll(runningapp_displayname + ": CPU Priority set to 'High'");
							Log.WriteToLog(runningapp_displayname + ": CPU Priority set to 'High'");
							break;
						}
						continue;
					default:
						continue;
					}
					break;
				}
			}
			cpuTimer.Enabled = false;
			cpuTimer.Elapsed -= ApplyCpuPrioTick;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll(ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("ApplyCpuPrioTick: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyAswTick(object sender, ElapsedEventArgs e)
	{
		try
		{
			if (Operators.CompareString(runningApp, "", TextCompare: false) == 0)
			{
				aswTimer.Enabled = false;
				aswTimer.Elapsed -= ApplyAswTick;
				return;
			}
			string value = "";
			if (profileASWList.TryGetValue(runningApp.ToLower(), out value) && Operators.CompareString(value, "Inherit", TextCompare: false) != 0)
			{
				if (Operators.CompareString(value, "Auto", TextCompare: false) == 0)
				{
					Thread thread = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Auto");
					});
					thread.Start();
					AddToListboxAndScroll(runningapp_displayname + ": ASW set to Auto");
					Log.WriteToLog(runningapp_displayname + ": ASW set to Auto");
				}
				if (Operators.CompareString(value, "Off", TextCompare: false) == 0)
				{
					Thread thread2 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Off");
					});
					thread2.Start();
					AddToListboxAndScroll(runningapp_displayname + ": ASW set to Off");
					Log.WriteToLog(runningapp_displayname + ": ASW set to Off");
				}
				if ((Operators.CompareString(value, "45 Hz", TextCompare: false) == 0) | (Operators.CompareString(value, "45 fps", TextCompare: false) == 0))
				{
					Thread thread3 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock45");
					});
					thread3.Start();
					AddToListboxAndScroll(runningapp_displayname + ": Framerate @ 45 Hz");
					Log.WriteToLog(runningapp_displayname + ": Framerate @ 45 Hz");
				}
				if (Operators.CompareString(value, "30 Hz", TextCompare: false) == 0)
				{
					Thread thread4 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock30");
					});
					thread4.Start();
					AddToListboxAndScroll(runningapp_displayname + ": Framerate @ 30 Hz");
					Log.WriteToLog(runningapp_displayname + ": Framerate @ 30 Hz");
				}
				if (Operators.CompareString(value, "18 Hz", TextCompare: false) == 0)
				{
					Thread thread5 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock18");
					});
					thread5.Start();
					AddToListboxAndScroll(runningapp_displayname + ": Framerate @ 18 Hz");
					Log.WriteToLog(runningapp_displayname + ": Framerate @ 18 Hz");
				}
				if (Operators.CompareString(value, "45 Hz forced", TextCompare: false) == 0)
				{
					Thread thread6 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Sim45");
					});
					thread6.Start();
					AddToListboxAndScroll(runningapp_displayname + ": Framerate @ 45 Hz forced");
					Log.WriteToLog(runningapp_displayname + ": Framerate forced to 45 Hz");
				}
				if (Operators.CompareString(value, "Adaptive", TextCompare: false) == 0)
				{
					Thread thread7 = new Thread([SpecialName] () =>
					{
						RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
					});
					thread7.Start();
					AddToListboxAndScroll(runningapp_displayname + ": Framerate set to Adaptive");
					Log.WriteToLog(runningapp_displayname + ": Framerate set to Adaptive");
				}
			}
			aswTimer.Enabled = false;
			aswTimer.Elapsed -= ApplyAswTick;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll(ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("ApplyAswTick: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void Home2Work(object sender, DoWorkEventArgs e)
	{
		Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
		if (processesByName.Length > 0)
		{
			processesByName[0].WaitForExit();
			Log.WriteToLog("Stopping Oculus Home mirror");
			AddToListboxAndScroll("Stopping Oculus Home mirror");
			Process[] processesByName2 = Process.GetProcessesByName("OculusMirror");
			if (processesByName2.Length > 0)
			{
				processesByName2[0].Kill();
				HomeIsMirrored = false;
				_Home2Timer.Start();
			}
		}
	}

	private void HomeWork(object sender, DoWorkEventArgs e)
	{
		Process[] processesByName = Process.GetProcessesByName("OculusClient");
		if (processesByName.Length <= 0)
		{
			return;
		}
		processesByName[0].WaitForExit();
		Log.WriteToLog("Oculus Home closed");
		AddToListboxAndScroll("Oculus Home closed");
		HomeToTray.ToastShown = false;
		DisableShowHomeMenu();
		if (MySettingsProperty.Settings.SendHomeToTray | MySettingsProperty.Settings.SendHomeToTrayOnStart)
		{
			StartMinimizeHomeWatcher();
		}
		if (GetConfig.SetRiftDefault)
		{
			if (MySettingsProperty.Settings.SetRiftAudioDefault == 0)
			{
				Thread thread = new Thread([SpecialName] () =>
				{
					AudioSwitcher.SetFallbackAudioDevice();
					AudioSwitcher.SetFallbackCommAudioDevice();
				});
				thread.Start();
			}
			if (MySettingsProperty.Settings.SetRiftMicDefault == 0)
			{
				Thread thread2 = new Thread([SpecialName] () =>
				{
					AudioSwitcher.SetFallbackMicDevice();
					AudioSwitcher.SetFallbackCommMicDevice();
				});
				thread2.Start();
			}
		}
		if (MySettingsProperty.Settings.ApplyPowerPlan == 1)
		{
			PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanExit);
			PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
		}
		Watcher.Stop();
		pTimer.Stop();
		HometoTrayTimer.Enabled = false;
		HomeIsRunning = false;
		if (GetControllers.joyAquired)
		{
			GetControllers.joy.Unacquire();
			GetControllers.joyAquired = false;
		}
		if (MySettingsProperty.Settings.StopOVRHome)
		{
			Thread.Sleep(1000);
			StopOVR();
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("Starting Oculus Home watcher");
		}
		BeginInvoke(new TimerStart(HomeStartFunction));
		if (Globals.dbg)
		{
			Log.WriteToLog("Oculus Home watcher started");
		}
	}

	private void HomeStartFunction()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering HomeStartFunction");
		}
		OculusHomeWatcher.Start();
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting HomeStartFunction");
		}
	}

	private void ToolStripMenuItem3_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		if (Operators.CompareString(ToolStripMenuItem3.Text, "Set Rift as default Audio/Mic", TextCompare: false) == 0)
		{
			if (Operators.CompareString(MySettingsProperty.Settings.RiftAudioGuid, null, TextCompare: false) != 0)
			{
				RiftDefault.SetRiftDefaultAudioDevice();
			}
			if (Operators.CompareString(MySettingsProperty.Settings.RiftMicGuid, null, TextCompare: false) != 0)
			{
				RiftDefault.SetRiftDefaultMicDevice();
			}
			if (GetDevices.GetDefaultAudioDeviceName().ToString().ToLower()
				.Contains("rift"))
			{
				ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
			}
			Cursor = Cursors.Default;
			return;
		}
		if (Operators.CompareString(ToolStripMenuItem3.Text, "Set Fallback as default Audio/Mic", TextCompare: false) == 0)
		{
			if (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, null, TextCompare: false) != 0)
			{
				AudioSwitcher.SetFallbackAudioDevice();
			}
			else
			{
				Log.WriteToLog("Could not set fallback audio device, no device selected");
				fmain.AddToListboxAndScroll("Could not set fallback audio device, no device selected");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, null, TextCompare: false) != 0)
			{
				AudioSwitcher.SetFallbackMicDevice();
			}
			else
			{
				Log.WriteToLog("Could not set fallback microphone device, no device selected");
				fmain.AddToListboxAndScroll("Could not set fallback microphone device, no device selected");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommGuid, null, TextCompare: false) != 0)
			{
				AudioSwitcher.SetFallbackCommMicDevice();
			}
			else
			{
				Log.WriteToLog("Could not set fallback mic communications device, no device selected");
				fmain.AddToListboxAndScroll("Could not set fallback mic communications device, no device selected");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommAudioGuid, null, TextCompare: false) != 0)
			{
				AudioSwitcher.SetFallbackCommAudioDevice();
			}
			else
			{
				Log.WriteToLog("Could not set fallback audio communications device, no device selected");
				fmain.AddToListboxAndScroll("Could not set fallback mic communications device, no device selected");
			}
			if (!GetDevices.GetDefaultAudioDeviceName().ToString().ToLower()
				.Contains("rift"))
			{
				ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
			}
		}
		if ((Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, null, TextCompare: false) == 0) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, null, TextCompare: false) == 0))
		{
			Interaction.MsgBox("Could not set fallback audio and microphone devices, no devices selected", MsgBoxStyle.Exclamation, "Warning");
		}
		else
		{
			if (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, null, TextCompare: false) == 0)
			{
				Interaction.MsgBox("Could not set fallback audio device, no device selected", MsgBoxStyle.Exclamation, "Warning");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, null, TextCompare: false) == 0)
			{
				Interaction.MsgBox("Could not set fallback microphone device, no device selected", MsgBoxStyle.Exclamation, "Warning");
			}
		}
		Cursor = Cursors.Default;
	}

	private void CheckSpoofCPU_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (GetConfig.IsReading)
			{
				return;
			}
			if (isElevated)
			{
				if (CheckSpoofCPU.Checked)
				{
					CheckSpoofCPU.Refresh();
					MySettingsProperty.Settings.SpoofCPU = true;
					spoofid = true;
					MySettingsProperty.Settings.OldCPUID = "";
					Interaction.MsgBox("The CPU ID will be changed next time (and every time) you start Oculus Tray Tool. Remember to start Oculus Tray Tool before starting Oculus Home.", MsgBoxStyle.Information, "Oculus Tray Tool");
				}
				else
				{
					MySettingsProperty.Settings.SpoofCPU = false;
					spoofid = false;
					RestoreCPUID();
				}
				MySettingsProperty.Settings.Save();
			}
			else
			{
				GetConfig.IsReading = true;
				CheckSpoofCPU.Checked = false;
				GetConfig.IsReading = false;
				Interaction.MsgBox("You must run the application as Administrator to change this option.", MsgBoxStyle.Critical, "Oculus Tray Tool");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void GetCPUid()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetCPUid");
		}
		try
		{
			RegistryKey registryKey = MyProject.Computer.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
			cpuid = Conversions.ToString(registryKey.GetValue("ProcessorNameString"));
			Log.WriteToLog("Current CPU ID: " + cpuid);
			if ((Operators.CompareString(cpuid, "Intel(R) Core(TM) i7-4770K CPU @ 3.90GHz", TextCompare: false) == 0) | (Operators.CompareString(cpuid, "AMD Ryzen 7 1700X Eight-Core Processor", TextCompare: false) == 0))
			{
				AddToListboxAndScroll("Spoofing CPU ID not needed, already set or equal");
				Log.WriteToLog("Spoofing CPU ID not needed, already set or equal");
				if (!GetConfig.IsReading)
				{
					Interaction.MsgBox("Spoofing CPU ID not needed, already set or equal", MsgBoxStyle.Information, "Spoof CPU");
				}
			}
			else
			{
				if (Operators.CompareString(MySettingsProperty.Settings.OldCPUID, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.OldCPUID = cpuid;
					MySettingsProperty.Settings.Save();
					Log.WriteToLog("Saved Current CPU ID");
				}
				if (cpuid.StartsWith("AMD"))
				{
					ChangeCPUID("AMD Ryzen 7 1700X Eight-Core Processor");
				}
				else
				{
					ChangeCPUID("Intel(R) Core(TM) i7-4770K CPU @ 3.90GHz");
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetCPUid");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Could not retrieve CPU ID: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void ChangeCPUID(string model)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering ChangeCPUID");
		}
		try
		{
			if (Operators.CompareString(MySettingsProperty.Settings.OldCPUID, "", TextCompare: false) != 0)
			{
				RegistryKey registryKey = MyProject.Computer.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", writable: true);
				registryKey.SetValue("ProcessorNameString", model);
				Log.WriteToLog("New CPU ID: " + model);
				AddToListboxAndScroll("New CPU ID: " + model);
				StopOVR();
				StartOVR();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting ChangeCPUID");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("* Could not change CPU ID: " + ex2.Message);
			AddToListboxAndScroll("* Could not change CPU ID: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void RestoreCPUID()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering RestoreCPUID");
		}
		try
		{
			if (Operators.CompareString(MySettingsProperty.Settings.OldCPUID, "", TextCompare: false) != 0)
			{
				RegistryKey registryKey = MyProject.Computer.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", writable: true);
				registryKey.SetValue("ProcessorNameString", MySettingsProperty.Settings.OldCPUID);
				Log.WriteToLog("CPU ID restored to: " + MySettingsProperty.Settings.OldCPUID);
				AddToListboxAndScroll("CPU ID restored to: " + MySettingsProperty.Settings.OldCPUID);
				MySettingsProperty.Settings.OldCPUID = "";
			}
			else
			{
				AddToListboxAndScroll("No old ID to restore");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting RestoreCPUID");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Could not restore CPU ID: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	internal string SplitToolTip(string strOrig)
	{
		string text = " ";
		string text2 = "\r\n";
		string[] array = strOrig.Split(Conversions.ToChar(text));
		string[] array2 = array;
		string text4 = default(string);
		string text5 = default(string);
		foreach (string text3 in array2)
		{
			text4 = text4 + text3 + text;
			if (Strings.Len(text4) > 70)
			{
				text5 = text5 + text4 + text2;
				text4 = "";
			}
		}
		if (Strings.Len(text4) < 8)
		{
			text5 = text5.Substring(0, checked(text5.Length - 2));
		}
		return text5 + text4;
	}

	private void ToolStripStartOVR_Click(object sender, EventArgs e)
	{
		StartOVR();
		if (CheckLaunchHome.Checked)
		{
			ServiceController serviceController = new ServiceController("OVRService");
			if (serviceController.Status == ServiceControllerStatus.Running)
			{
				RunCommand.StartHome();
			}
		}
	}

	private void ToolStripMenuItem5_Click(object sender, EventArgs e)
	{
		StopOVR();
	}

	private void ToolStripMenuItem6_Click(object sender, EventArgs e)
	{
		StopOVR();
		StartOVR();
	}

	private void ToolStripMenuItem4_Click(object sender, EventArgs e)
	{
		PowerPlans.CheckPowerState(change: true);
	}

	private void NotificationTimer_Tick(object sender, EventArgs e)
	{
		NotificationTimer.Stop();
		MyProject.Forms.frmLoading.CloseStartupToast();
	}

	private void CheckMinimizeOnX_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				GetConfig.IsReading = true;
				if (CheckMinimizeOnX.Checked)
				{
					MySettingsProperty.Settings.CloseOnX = false;
					MySettingsProperty.Settings.ShowStillRunning = true;
				}
				else
				{
					MySettingsProperty.Settings.CloseOnX = true;
				}
				MySettingsProperty.Settings.Save();
				GetConfig.IsReading = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void BtnLibrary_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		MyProject.Forms.frmLibrary.Location = MySettingsProperty.Settings.LibraryWindowLocation;
		MyProject.Forms.frmLibrary.Size = MySettingsProperty.Settings.LibraryWindowSize;
		MyProject.Forms.frmLibrary.Show();
		Cursor = Cursors.Default;
	}

	private void BtnProfiles_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmProfiles.Location = MySettingsProperty.Settings.ProfilesWindowLocation;
		MyProject.Forms.frmProfiles.Size = MySettingsProperty.Settings.ProfilesWindowSize;
		MyProject.Forms.frmProfiles.Show();
		MyProject.Forms.frmProfiles.ListView1.Sorting = SortOrder.Ascending;
		MyProject.Forms.frmProfiles.ListView1.Focus();
	}

	private void BtnVoice_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmVoiceSettings.Size = MySettingsProperty.Settings.VoiceDialogSize;
		MyProject.Forms.frmVoiceSettings.ShowDialog();
	}

	private void TrackBar1_Scroll(object sender, EventArgs e)
	{
		Label14.Text = "Font Size: " + Conversions.ToString(TrackBar1.Value);
		rs.ResizeAllControls(this, TrackBar1.Value);
		MySettingsProperty.Settings.FontSize = TrackBar1.Value;
		MySettingsProperty.Settings.Save();
		MyProject.Forms.frmProfiles.ListView1.Font = new Font(MyProject.Forms.frmProfiles.ListView1.Font.Name, MySettingsProperty.Settings.FontSize, FontStyle.Regular);
		MyProject.Forms.frmProfiles.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
	}

	private void PictureBox1_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmDonate.ShowDialog();
	}

	private void ComboSSstart_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.PPDPStartup = ComboSSstart.Text;
			MySettingsProperty.Settings.Save();
			GetConfig.ppdpstartup = ComboSSstart.Text;
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
			});
			thread.Start();
		}
	}

	private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (Operators.CompareString(ComboBox1.Text, "Auto", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 0;
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Auto");
			});
			thread.Start();
			AddToListboxAndScroll("ASW set to Auto");
		}
		if (Operators.CompareString(ComboBox1.Text, "Off", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 1;
			Thread thread2 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Off");
			});
			thread2.Start();
			AddToListboxAndScroll("ASW set to Off");
		}
		if (Operators.CompareString(ComboBox1.Text, "45 Hz", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 2;
			Thread thread3 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Clock45");
			});
			thread3.Start();
			AddToListboxAndScroll("Framerate @ 45 Hz");
		}
		if (Operators.CompareString(ComboBox1.Text, "30 Hz", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 3;
			Thread thread4 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Clock30");
			});
			thread4.Start();
			AddToListboxAndScroll("Framerate @ 30 Hz");
		}
		if (Operators.CompareString(ComboBox1.Text, "18 Hz", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 4;
			Thread thread5 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Clock18");
			});
			thread5.Start();
			AddToListboxAndScroll("Framerate @ 18 Hz");
		}
		if (Operators.CompareString(ComboBox1.Text, "45 Hz forced", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 5;
			Thread thread6 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Sim45");
			});
			thread6.Start();
			AddToListboxAndScroll("Framerate forced to 45 Hz");
		}
		if (Operators.CompareString(ComboBox1.Text, "Adaptive", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ASW = 6;
			Thread thread7 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
			});
			thread7.Start();
			AddToListboxAndScroll("Framerate set to Adaptive");
		}
		MySettingsProperty.Settings.Save();
	}

	private void ComboVoice_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (Operators.CompareString(ComboVoice.Text, "Enabled", TextCompare: false) == 0)
			{
				MySettingsProperty.Settings.UseVoiceCommands = true;
				MySettingsProperty.Settings.Save();
				EnableDisableVoice(enable: true);
			}
			else
			{
				MySettingsProperty.Settings.UseVoiceCommands = false;
				MySettingsProperty.Settings.Save();
				EnableDisableVoice(enable: false);
			}
		}
	}

	public void EnableDisableVoice(bool enable)
	{
		if (enable)
		{
			ComboVoice.Text = "Enabled";
			AddToListboxAndScroll("Enabling Voice commands");
			Log.WriteToLog("Enabling Voice commands");
			GetConfig.useVoiceCommands = true;
			BtnVoice.Enabled = true;
			VoiceCommands.StartStopBuilder();
			if (!HomeIsRunning)
			{
				return;
			}
			if ((MySettingsProperty.Settings.JoystickActivationKeyContinous | MySettingsProperty.Settings.JoystickActivationKeyPush) && Operators.CompareString(MySettingsProperty.Settings.JoystickVoiceActivationButton, "", TextCompare: false) != 0)
			{
				Thread thread = new Thread([SpecialName] () =>
				{
					GetControllers.CaptureButtonPushToTalk();
				});
				thread.Start();
			}
			CultureInfo culture = new CultureInfo(CultureInfo.CurrentUICulture.Name);
			VoiceCommands.sRecognize = new SpeechRecognitionEngine(culture);
			VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
			VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
			VoiceCommands.buildGrammars();
			AddToListboxAndScroll("Ready to accept voice commands");
		}
		else
		{
			ComboVoice.Text = "Disabled";
			Log.WriteToLog("Disabling Voice commands..");
			AddToListboxAndScroll("Disabling Voice commands..");
			GetConfig.useVoiceCommands = false;
			BtnVoice.Enabled = false;
			if (VoiceCommands.isListening)
			{
				VoiceCommands.StopListening();
			}
			if (VoiceCommands.grammarsBuilt)
			{
				VoiceCommands.DisableVoice();
			}
			if (GetControllers.joyAquired)
			{
				GetControllers.joy.Unacquire();
				GetControllers.joyAquired = false;
			}
			Log.WriteToLog("Voice commands Disabled");
			AddToListboxAndScroll("Voice commands Disabled");
		}
	}

	private void HotKeysCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (HotKeysCheckBox.Checked)
			{
				MySettingsProperty.Settings.UseHotKeys = true;
				GetConfig.UseHotKeys = true;
				BtnConfigureHotKeys.Enabled = true;
				kbHook = new KeyboardHook();
			}
			else
			{
				MySettingsProperty.Settings.UseHotKeys = false;
				GetConfig.UseHotKeys = false;
				BtnConfigureHotKeys.Enabled = false;
				kbHook = null;
			}
			MySettingsProperty.Settings.Save();
		}
	}

	private void ComboPowerPlan_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (GetConfig.IsReading)
			{
				return;
			}
			MySettingsProperty.Settings.PowerPlanStart = ComboPowerPlanStart.Text;
			MySettingsProperty.Settings.Save();
			if (Operators.CompareString(ComboPowerPlanStart.Text, "Not Used", TextCompare: false) != 0)
			{
				if (MySettingsProperty.Settings.ApplyPowerPlan == 0)
				{
					PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
					PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
				}
				PowerPlanTimer.Start();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void ComboUSBsusp_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (ComboUSBsusp.SelectedIndex == 0)
				{
					Log.WriteToLog("Disabling USB Selective Suspend");
					PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: true);
					MySettingsProperty.Settings.USBSuspend = 0;
				}
				else
				{
					Log.WriteToLog("Enabling USB Selective Suspend");
					PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: true);
					MySettingsProperty.Settings.USBSuspend = 1;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void ChangeCPUPrioOVR(string prio)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OVRServer_x64");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				switch (prio)
				{
				case "Normal":
					process.PriorityClass = ProcessPriorityClass.Normal;
					if (process.PriorityClass == ProcessPriorityClass.Normal)
					{
						Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
					}
					break;
				case "Above normal":
					process.PriorityClass = ProcessPriorityClass.AboveNormal;
					if (process.PriorityClass == ProcessPriorityClass.AboveNormal)
					{
						Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
					}
					break;
				case "High":
					process.PriorityClass = ProcessPriorityClass.High;
					if (process.PriorityClass == ProcessPriorityClass.High)
					{
						Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
					}
					break;
				case "Realtime":
					process.PriorityClass = ProcessPriorityClass.RealTime;
					if (process.PriorityClass == ProcessPriorityClass.RealTime)
					{
						Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ChangeCPUPrioOVR(): " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void ChangeCPUPrioDash(string prio)
	{
		try
		{
			Log.WriteToLog("Sleeping 5s before changing CPU Priority of OculusDash to " + prio);
			Thread.Sleep(5000);
			Process[] processesByName = Process.GetProcessesByName("OculusDash");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				switch (prio)
				{
				case "Normal":
					process.PriorityClass = ProcessPriorityClass.Normal;
					if (process.PriorityClass == ProcessPriorityClass.Normal)
					{
						Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
					}
					break;
				case "Above normal":
					process.PriorityClass = ProcessPriorityClass.AboveNormal;
					if (process.PriorityClass == ProcessPriorityClass.AboveNormal)
					{
						Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
					}
					break;
				case "High":
					process.PriorityClass = ProcessPriorityClass.High;
					if (process.PriorityClass == ProcessPriorityClass.High)
					{
						Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
					}
					break;
				case "Realtime":
					process.PriorityClass = ProcessPriorityClass.RealTime;
					if (process.PriorityClass == ProcessPriorityClass.RealTime)
					{
						Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
						AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ChangeCPUPrioDash(): " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void HometoTrayTimer_Tick(object sender, EventArgs e)
	{
		HomeToTray.SendHomeToTrayOnMinimize();
		if (HomeToTray.HomeIsMinimized)
		{
			EnableShowHomeMenu();
		}
	}

	private void CheckSendHomeToTray_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckSendHomeToTray.Checked)
		{
			MySettingsProperty.Settings.SendHomeToTray = true;
			if (HomeIsRunning)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Home is running, HomeToTray enabled, Timer started");
				}
				HometoTrayTimer.Enabled = true;
				MySettingsProperty.Settings.Save();
			}
			return;
		}
		try
		{
			HomeToTray.ShowHomeNormal();
			DisableShowHomeMenu();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Restore Home: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		MySettingsProperty.Settings.SendHomeToTray = false;
		HometoTrayTimer.Enabled = false;
		MySettingsProperty.Settings.ShowHomeToast = true;
		MySettingsProperty.Settings.Save();
	}

	private void CheckSendHomeToTrayOnStart_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckSendHomeToTrayOnStart.Checked)
		{
			StartMinimizeHomeWatcher();
			MySettingsProperty.Settings.SendHomeToTrayOnStart = true;
			MySettingsProperty.Settings.Save();
			if (!HomeIsRunning)
			{
				return;
			}
			HomeToTray.SendHomeToTrayOnStart();
			if (MySettingsProperty.Settings.ShowHomeToast & !HomeToTray.ToastShown)
			{
				HomeToTray.ToastShown = true;
				Thread thread = new Thread([SpecialName] () =>
				{
					MyProject.Forms.frmHomeTrayToast.ShowDialog();
				});
				thread.Start();
			}
		}
		else
		{
			MySettingsProperty.Settings.SendHomeToTrayOnStart = false;
			MySettingsProperty.Settings.ShowHomeToast = true;
			MySettingsProperty.Settings.Save();
			MinimizeHomeWatcher.Stop();
		}
	}

	private void CheckLocalDebug_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (CheckLocalDebug.Checked)
			{
				MySettingsProperty.Settings.UseLocalDebugTool = true;
				MySettingsProperty.Settings.Save();
			}
			else
			{
				MySettingsProperty.Settings.UseLocalDebugTool = false;
				MySettingsProperty.Settings.Save();
			}
		}
	}

	private void CheckStartWatcher_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckStartWatcher.Checked)
		{
			MySettingsProperty.Settings.StartAppwatcherOnStart = true;
			MySettingsProperty.Settings.Save();
			if (OculusServiceFound)
			{
				Log.WriteToLog("Starting AppWatcher");
				AddToListboxAndScroll("Starting AppWatcher");
				StartWatcherNoHome();
			}
		}
		else
		{
			MySettingsProperty.Settings.StartAppwatcherOnStart = false;
			MySettingsProperty.Settings.Save();
		}
	}

	private void BtnRemoveAllProfiles_Click(object sender, EventArgs e)
	{
		if (Interaction.MsgBox("Really remove all Profiles?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm remove") != MsgBoxResult.Yes)
		{
			return;
		}
		OTTDB.RemoveAllProfiles();
		Watcher.Stop();
		if (pTimer.Enabled)
		{
			pTimer.Stop();
		}
		MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
		if (Directory.Exists(OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
		{
			GetGames.GetThirdPartyApps(OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
		}
		if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) == 0)
		{
			return;
		}
		string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
		foreach (string text in array)
		{
			if (Directory.Exists(text.TrimEnd('\\') + "\\Manifests"))
			{
				GetGames.GetFiles(text.TrimEnd('\\') + "\\Manifests");
			}
			if (Directory.Exists(text.TrimEnd('\\') + "\\CoreData\\Manifests"))
			{
				GetGames.GetThirdPartyApps(text.TrimEnd('\\') + "\\CoreData\\Manifests");
			}
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		Log.WriteToLog("Checking Internet connection..");
		CheckConnection.CheckForInternetConnection();
		if (CheckConnection.HaveiConnection)
		{
			Log.WriteToLog("Internet connection looks good");
			CheckUpdate.CheckForUpdate(manual: true);
		}
		else
		{
			Log.WriteToLog("Internet connection not available, gave up");
			AddToListboxAndScroll("No internet connection, cannot check for updates");
		}
		Cursor = Cursors.Default;
	}

	private void Button5_Click(object sender, EventArgs e)
	{
		if (Interaction.MsgBox("Restart in Debug mode?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm restart") == MsgBoxResult.Yes)
		{
			MySettingsProperty.Settings.RunDebug = true;
			MySettingsProperty.Settings.Save();
			restartInDBG = true;
			Shutdown();
		}
	}

	private void CheckSensorPower_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckSensorPower.Checked)
				{
					MySettingsProperty.Settings.DisableSensorPower = true;
				}
				else
				{
					MySettingsProperty.Settings.DisableSensorPower = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		if (Interaction.MsgBox("Reset all Oculus Tray Tool settings to default and restart application?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm reset") == MsgBoxResult.Yes)
		{
			MySettingsProperty.Settings.Reset();
			MySettingsProperty.Settings.Save();
			restartInDBG = true;
			Shutdown();
		}
	}

	private void ComboPowerPlanExit_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				MySettingsProperty.Settings.PowerPlanExit = ComboPowerPlanExit.Text;
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private void BtnConfigureAudio_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		MyProject.Forms.FrmSetFallback.ShowDialog(this);
	}

	private void ComboApplyPlan_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.ApplyPowerPlan = ComboApplyPlan.SelectedIndex;
			MySettingsProperty.Settings.Save();
			if (ComboApplyPlan.SelectedIndex == 0)
			{
				PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
				PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
			}
		}
	}

	private void Button8_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		LabelDownloadStatus.Text = "Downloading..";
		LabelDownloadStatus.Refresh();
		CheckUpdate.DownloadUpdate(CheckUpdate.link, install: true, "");
	}

	private void Button9_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			Cursor = Cursors.WaitCursor;
			LabelDownloadStatus.Text = "Downloading..";
			LabelDownloadStatus.Refresh();
			CheckUpdate.DownloadUpdate(CheckUpdate.link, install: false, folderBrowserDialog.SelectedPath);
		}
	}

	public void AddToListboxAndScroll(string text)
	{
		checked
		{
			if (base.InvokeRequired)
			{
				AddToListboxAndScrollDelegate method = AddToListboxAndScroll;
				Invoke(method, text);
			}
			else
			{
				ListBox1.Items.Add(DateAndTime.TimeOfDay.ToString("HH:mm:ss ") + text);
				ListBox1.TopIndex = ListBox1.Items.Count - 1;
				numLogMessages++;
				DotNetBarTabcontrol1.TabPages[4].Text = "Log Window (" + Conversions.ToString(numLogMessages) + ")";
			}
		}
	}

	public void UpdateTabPage()
	{
		if (base.InvokeRequired)
		{
			Invoke(new UpdateTabDelegate(UpdateTabPage));
			return;
		}
		DotNetBarTabcontrol1.Controls.Add((Control)colRemovedTabs["TabPage6"]);
		DotNetBarTabcontrol1.TabPages[7].ImageIndex = 6;
		colRemovedTabs.Remove("TabPage6");
		if (base.WindowState == FormWindowState.Minimized)
		{
			DotNetBarTabcontrol1.SelectedIndex = 7;
		}
	}

	public void ShowUpdateToast()
	{
		if (base.InvokeRequired)
		{
			Invoke(new ShowUpdateToastDelegate(ShowUpdateToast));
		}
		else
		{
			MyProject.Forms.frmUpdateToast.Show();
		}
	}

	public void EnableShowHomeMenu()
	{
		if (base.InvokeRequired)
		{
			Invoke(new EnableShowHomeMenuDelegate(EnableShowHomeMenu));
		}
		else
		{
			ToolStripMenuShowHome.Enabled = true;
		}
	}

	public void DisableShowHomeMenu()
	{
		if (base.InvokeRequired)
		{
			Invoke(new DisableShowHomeMenuDelegate(DisableShowHomeMenu));
			return;
		}
		ToolStripMenuShowHome.Enabled = false;
		NotifyIcon3.Visible = false;
	}

	public void SetTitleIsListening()
	{
		if (base.InvokeRequired)
		{
			Invoke(new SetTitleIsListeningDelegate(SetTitleIsListening));
		}
		else
		{
			Text = "Oculus Tray Tool " + Application.ProductVersion.Substring(0, 8) + " - Listening to Voice Commands";
		}
	}

	public void RemoveTitleIsListening()
	{
		if (base.InvokeRequired)
		{
			Invoke(new RemoveTitleIsListeningDelegate(RemoveTitleIsListening));
		}
		else
		{
			Text = "Oculus Tray Tool " + Application.ProductVersion.Substring(0, 8);
		}
	}

	public void SetToolTipText(string text, Control crtl)
	{
		if (base.InvokeRequired)
		{
			SetToolTipDelegate method = SetToolTipText;
			Invoke(method, text, crtl);
		}
		else
		{
			ToolTip.SetToolTip(crtl, text);
		}
	}

	private void PictureBox2_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmAbout.StartPosition = FormStartPosition.CenterParent;
		MyProject.Forms.frmAbout.ShowDialog(this);
	}

	private void CheckBoxCheckForUpdates_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (CheckBoxCheckForUpdates.Checked)
			{
				MySettingsProperty.Settings.AutomaticUpdateCheck = true;
			}
			else
			{
				MySettingsProperty.Settings.AutomaticUpdateCheck = false;
			}
			MySettingsProperty.Settings.Save();
		}
	}

	private void FlashBackground(Control control, Color c)
	{
		Color backColor = control.BackColor;
		Control control2 = control;
		control2.BackColor = c;
		control2.Update();
		Thread.Sleep(200);
		control2.BackColor = backColor;
		control2.Update();
		control2 = null;
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		try
		{
			MySettingsProperty.Settings.FOVh = Conversions.ToString(NumericFOVh.Value);
			MySettingsProperty.Settings.FOVv = Conversions.ToString(NumericFOVv.Value);
			MySettingsProperty.Settings.Save();
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_fov(MySettingsProperty.Settings.FOVh.ToString() + " " + MySettingsProperty.Settings.FOVv.ToString());
			});
			thread.Start();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void BtnHomless_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmHomeless.ShowDialog(this);
	}

	private void ComboHomless_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (ComboHomless.SelectedIndex == 1)
		{
			if (MessageBox.Show(this, "NOTE: Please make sure you have not already replaced the original 'Home2-Win64-Shipping.exe' binary. If you have done so please consult the User Guide for more info before proceeding. Proceed with installation?", "Oculus Homeless", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			Cursor = Cursors.WaitCursor;
			bool flag = false;
			if (HomeIsRunning)
			{
				flag = true;
				if (MessageBox.Show(this, "The Oculus service needs to be stopped. Proceed with installation?", "Oculus Homeless", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					Cursor = Cursors.Default;
					ComboHomless.Text = "Disabled";
					return;
				}
				StopOVR();
				Thread.Sleep(1000);
			}
			InstallHomeless();
			if (flag)
			{
				StartOVR();
			}
			BtnHomless.Enabled = true;
			Cursor = Cursors.Default;
			return;
		}
		Cursor = Cursors.WaitCursor;
		bool flag2 = false;
		if (HomeIsRunning)
		{
			flag2 = true;
			if (MessageBox.Show(this, "The Oculus service needs to be stopped. Proceed with uninstallation?", "Oculus Homeless", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				Cursor = Cursors.Default;
				ComboHomless.Text = "Enabled";
				return;
			}
			StopOVR();
			Thread.Sleep(1000);
		}
		UninstallHomeless();
		if (flag2)
		{
			StartOVR();
		}
		BtnHomless.Enabled = false;
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void InstallHomeless()
	{
		Log.WriteToLog("Installing Oculus Homeless");
		Log.WriteToLog("Generating SHA256 hash of Oculus Homeless binary: " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe");
		try
		{
			string homelessHash = Conversions.ToString(GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe"));
			MySettingsProperty.Settings.HomelessHash = homelessHash;
			MySettingsProperty.Settings.Save();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ComboHomless.Text = "Disabled";
			Interaction.MsgBox("Could not generate hash of " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe\r\n\r\n" + ex2.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not generate hash of " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe: " + ex2.Message);
			ProjectData.ClearProjectError();
			return;
		}
		Log.WriteToLog("Generating SHA256 hash of original binary: " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
		try
		{
			string homeHash = Conversions.ToString(GenerateSHA256Hash(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"));
			MySettingsProperty.Settings.HomeHash = homeHash;
			MySettingsProperty.Settings.Save();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ComboHomless.Text = "Disabled";
			Interaction.MsgBox("Could not generate hash of " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex4.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not generate hash of " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex4.Message);
			ProjectData.ClearProjectError();
			return;
		}
		Log.WriteToLog("Backing up original Home2-Win64-Shipping.exe from " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64");
		if (!Directory.Exists(Application.StartupPath + "\\Homeless\\Backup"))
		{
			Directory.CreateDirectory(Application.StartupPath + "\\Homeless\\Backup");
		}
		try
		{
			File.Copy(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe", Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe", overwrite: true);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ComboHomless.Text = "Disabled";
			Interaction.MsgBox("Could not create backup copy of " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex6.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not create backup copy of " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex6.Message);
			ProjectData.ClearProjectError();
			return;
		}
		if (!File.Exists(Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe"))
		{
			return;
		}
		Log.WriteToLog("Backup successful, renaming original file");
		try
		{
			if (File.Exists(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG"))
			{
				File.Delete(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG");
			}
			FileSystem.Rename(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe", OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG");
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ComboHomless.Text = "Disabled";
			Interaction.MsgBox("Could not rename " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex8.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not rename " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex8.Message);
			ProjectData.ClearProjectError();
			return;
		}
		Log.WriteToLog("Copying new file");
		try
		{
			File.Copy(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe", OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ComboHomless.Text = "Disabled";
			Interaction.MsgBox("Could not copy " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe to " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex10.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not copy " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe to " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex10.Message);
			ProjectData.ClearProjectError();
			return;
		}
		try
		{
			if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
				Log.WriteToLog("Created " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
				string[] files = Directory.GetFiles(Application.StartupPath + "\\Homeless\\Music", "*.mp3");
				string[] array = files;
				foreach (string text in array)
				{
					File.Copy(text, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + Path.GetFileName(text));
					Log.WriteToLog("Copied " + text + " to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
				}
				string[] files2 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
				MyProject.Forms.frmHomeless.ComboMusic.DropDownStyle = ComboBoxStyle.DropDown;
				string[] array2 = files2;
				foreach (string path in array2)
				{
					MyProject.Forms.frmHomeless.ComboMusic.Items.Add(Path.GetFileName(path));
				}
				MyProject.Forms.frmHomeless.ComboMusic.DropDownStyle = ComboBoxStyle.DropDownList;
			}
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception ex12 = ex11;
			ComboHomless.Text = "Disabled";
			Interaction.MsgBox("Could not copy music to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\\r\n\r\n" + ex12.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not copy music to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\: " + ex12.Message);
			ProjectData.ClearProjectError();
			return;
		}
		Log.WriteToLog("Installation complete");
		MySettingsProperty.Settings.HomelessEnabled = ComboHomless.SelectedIndex;
		MySettingsProperty.Settings.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void UninstallHomeless()
	{
		Log.WriteToLog("Uninstalling Oculus Homeless");
		try
		{
			if (File.Exists(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG"))
			{
				string left = Conversions.ToString(GenerateSHA256Hash(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG"));
				if (Operators.CompareString(left, MySettingsProperty.Settings.HomeHash, TextCompare: false) != 0)
				{
					ComboHomless.Text = "Enabled";
					Log.WriteToLog("Hash values do not match!");
					Interaction.MsgBox("Stored hash value of " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG does not match actual value, aborting. Recommend manual rename.");
					return;
				}
				Log.WriteToLog("Hash values match, renaming " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG to " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				if (File.Exists(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"))
				{
					File.Delete(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				}
				FileSystem.Rename(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG", OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
			}
			else
			{
				Log.WriteToLog(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG was not found, using seconday backup");
				string left2 = Conversions.ToString(GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe"));
				if (Operators.CompareString(left2, MySettingsProperty.Settings.HomeHash, TextCompare: false) != 0)
				{
					ComboHomless.Text = "Enabled";
					Log.WriteToLog("Hash values do not match!");
					Interaction.MsgBox("Stored hash value of " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG does not match actual value, aborting. Recommend manual rename.");
					return;
				}
				Log.WriteToLog("Hash values match, copying " + Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe to " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				if (File.Exists(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"))
				{
					File.Delete(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				}
				File.Copy(Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe", OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
			}
			try
			{
				if (File.Exists(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt"))
				{
					File.Delete(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
				}
				if (File.Exists(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt"))
				{
					File.Delete(OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ComboHomless.Text = "Enabled";
				Log.WriteToLog("UninstallHomeless: " + ex2.Message);
				ProjectData.ClearProjectError();
			}
			Log.WriteToLog("Uninstall complete");
			MySettingsProperty.Settings.HomelessEnabled = ComboHomless.SelectedIndex;
			MySettingsProperty.Settings.Save();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ComboHomless.Text = "Enabled";
			Interaction.MsgBox("Could not rename " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG\r\n\r\n" + ex4.Message, MsgBoxStyle.Exclamation);
			Log.WriteToLog("Could not rename " + OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	private object GenerateSHA256Hash(string filename)
	{
		using FileStream inputStream = File.OpenRead(filename);
		SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] array = sHA256Managed.ComputeHash(inputStream);
		return BitConverter.ToString(array).Replace("-", string.Empty).ToLower();
	}

	private void UpdateTimer_Tick(object sender, EventArgs e)
	{
		UpdateTimer.Stop();
		Log.WriteToLog("Checking Internet connection..");
		CheckConnection.CheckForInternetConnection();
		if (CheckConnection.HaveiConnection)
		{
			Log.WriteToLog("Internet connection looks good");
			Thread thread = new Thread([SpecialName] () =>
			{
				CheckUpdate.CheckForUpdate(manual: false);
			});
			thread.Start();
		}
		else
		{
			Log.WriteToLog("Internet connection not available");
			AddToListboxAndScroll("No internet connection, cannot check for updates");
		}
	}

	private void ToolStripMenuShowHome_Click(object sender, EventArgs e)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Calling ShowHomeNormal");
		}
		try
		{
			HomeToTray.ShowHomeNormal();
			DisableShowHomeMenu();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Restore Home: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		if (MySettingsProperty.Settings.SendHomeToTray)
		{
			HometoTrayTimer.Enabled = true;
		}
	}

	private void ComboMirrorHome_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (ComboMirrorHome.SelectedIndex == 0)
		{
			MySettingsProperty.Settings.MirrorHome = true;
			if (HomeIsRunning)
			{
				Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
				if (processesByName.Length > 0)
				{
					Log.WriteToLog("Starting Oculus Mirror");
					try
					{
						Process.Start(OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
						HomeIsMirrored = true;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Log.WriteToLog("Could not launch " + OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe: " + ex2.Message);
						ProjectData.ClearProjectError();
					}
					MinMaxApp.MaximizeApp("OculusMirror");
				}
			}
		}
		else
		{
			MySettingsProperty.Settings.MirrorHome = false;
		}
		MySettingsProperty.Settings.Save();
	}

	private void ComboVisualHUD_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (ComboVisualHUD.SelectedIndex == 0)
		{
			AddToListboxAndScroll("Resetting Visual HUD to None");
			if (Globals.dbg)
			{
				Log.WriteToLog("Resetting Visual HUD to None");
			}
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("perfhud reset\r\nlayerhud reset");
			});
			thread.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 1)
		{
			AddToListboxAndScroll("Enabling Layer Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling Layer Overlay");
			}
			Thread thread2 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 1\r\nperfhud set-mode 0");
			});
			thread2.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 2)
		{
			AddToListboxAndScroll("Enabling Performance Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling Performance Overlay");
			}
			Thread thread3 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 1");
			});
			thread3.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 3)
		{
			AddToListboxAndScroll("Enabling ASW Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling ASW Overlay");
			}
			Thread thread4 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 6");
			});
			thread4.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 4)
		{
			AddToListboxAndScroll("Enabling Latency Timing Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling Latency Timing Overlay");
			}
			Thread thread5 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 2");
			});
			thread5.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 5)
		{
			AddToListboxAndScroll("Enabling Application Render Timing Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling Application Render Timing Overlay");
			}
			Thread thread6 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 3");
			});
			thread6.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 6)
		{
			AddToListboxAndScroll("Enabling Compositor Render Timing Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling Compositor Render Timing Overlay");
			}
			Thread thread7 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 4");
			});
			thread7.Start();
		}
		if (ComboVisualHUD.SelectedIndex == 7)
		{
			AddToListboxAndScroll("Enabling Version Info Overlay");
			if (Globals.dbg)
			{
				Log.WriteToLog("Enabling Version Info Overlay");
			}
			Thread thread8 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 5");
			});
			thread8.Start();
		}
	}

	private void PowerModeChanged(object sender, PowerModeChangedEventArgs args)
	{
		if ((double)args.Mode == Conversions.ToDouble("1"))
		{
			Log.WriteToLog("Computer is waking up");
			AddToListboxAndScroll("Computer is waking up");
			Thread.Sleep(3000);
			StopOVR();
			Thread.Sleep(4000);
			StartOVR();
		}
		if ((double)args.Mode == Conversions.ToDouble("2"))
		{
			Log.WriteToLog("Computer is in an unknown power state");
			AddToListboxAndScroll("Computer is in an unknown power state");
		}
		if ((double)args.Mode == Conversions.ToDouble("3"))
		{
			Log.WriteToLog("Computer is going to sleep");
			AddToListboxAndScroll("Computer is going to sleep");
		}
	}

	private void CheckRestartSleep_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckRestartSleep.Checked)
		{
			MySettingsProperty.Settings.RestartServiceAfterSleep = true;
			if (Globals.dbg)
			{
				Log.WriteToLog("Adding eventhandler for PowerModeChanged");
			}
			SystemEvents.PowerModeChanged += PowerModeChanged;
		}
		else
		{
			MySettingsProperty.Settings.RestartServiceAfterSleep = false;
			if (Globals.dbg)
			{
				Log.WriteToLog("Removing eventhandler for PowerModeChanged");
			}
			SystemEvents.PowerModeChanged -= PowerModeChanged;
		}
		MySettingsProperty.Settings.Save();
	}

	private void BtnSteamImport_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmImportSteamApps.ShowDialog(this);
	}

	private void NotifyIcon3_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			HomeToTray.ShowHomeNormal();
			DisableShowHomeMenu();
			if (MySettingsProperty.Settings.SendHomeToTray)
			{
				HometoTrayTimer.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Restore Home: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnConfigureHotKeys_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmHotKeys.ShowDialog();
	}

	private void ClearLogToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ListBox1.Items.Clear();
		numLogMessages = 0;
	}

	private void OpenLogToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Process.Start(Application.StartupPath + "\\ott.log");
	}

	private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DotNetBarTabcontrol1.SelectedIndex == 4)
		{
			numLogMessages = 0;
			DotNetBarTabcontrol1.SelectedTab.Text = "Log Window";
		}
	}

	private void kbHook_KeyDown(Keys Key)
	{
		if (!HomeIsRunning)
		{
			return;
		}
		string value = "";
		FuncToKeyDictionary.TryGetValue(Key.ToString().ToUpper(), out value);
		checked
		{
			if (Operators.CompareString(value, "", TextCompare: false) != 0)
			{
				if (Operators.CompareString(value, "ASW Auto", TextCompare: false) == 0)
				{
					AddToListboxAndScroll("Setting ASW to Auto");
					RunCommand.Run_debug_tool_asw("server:asw.Auto");
					if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
					{
						Thread thread = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
						});
						thread.Start();
					}
				}
				if (Operators.CompareString(value, "ASW Off", TextCompare: false) == 0)
				{
					AddToListboxAndScroll("Setting ASW to Off");
					RunCommand.Run_debug_tool_asw("server:asw.Off");
					if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
					{
						Thread thread2 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
						});
						thread2.Start();
					}
				}
				if (Operators.CompareString(value, "ASW 45", TextCompare: false) == 0)
				{
					AddToListboxAndScroll("Setting ASW to Clock45");
					RunCommand.Run_debug_tool_asw("server:asw.Clock45");
					if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
					{
						Thread thread3 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelocked.wav");
						});
						thread3.Start();
					}
				}
				if (Operators.CompareString(value, "Close HUD", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("perfhud reset\r\nlayerhud reset");
				}
				if (Operators.CompareString(value, "HUD ASW Mode", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 6");
				}
				if (Operators.CompareString(value, "HUD Performance", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 1");
				}
				if (Operators.CompareString(value, "HUD Pixel Density", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("layerhud set-mode 1\r\nperfhud set-mode 0");
				}
				if (Operators.CompareString(value, "HUD Latency", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 2");
				}
				if (Operators.CompareString(value, "HUD Application Render", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 3");
				}
				if (Operators.CompareString(value, "HUD Compositor Render", TextCompare: false) == 0)
				{
					RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 4");
				}
				if (Operators.CompareString(value, "Exit running VR app", TextCompare: false) == 0)
				{
					try
					{
						if (((Operators.CompareString(runningAppExe, "cmd.exe", TextCompare: false) != 0) & (Operators.CompareString(runningapp_displayname, "", TextCompare: false) != 0) & (pid != 0)) && AllAppsList.ContainsValue(runningapp_displayname))
						{
							KillRunningApp.GetParentProcess(pid);
							pid = 0;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Log.WriteToLog("Termination request for " + runningapp_displayname + "(" + runningAppExe + ") with PID " + Conversions.ToString(pid) + " failed: " + ex2.Message);
						AddToListboxAndScroll("Termination request for " + runningapp_displayname + " with PID " + Conversions.ToString(pid) + " failed: " + ex2.Message);
						pid = 0;
						ProjectData.ClearProjectError();
					}
				}
				if (Operators.CompareString(value, "Next HUD", TextCompare: false) == 0)
				{
					if (ComboVisualHUD.SelectedIndex == ComboVisualHUD.Items.Count - 1)
					{
						ComboVisualHUD.SelectedIndex = 0;
					}
					else
					{
						ComboVisualHUD.SelectedIndex += 1;
					}
				}
				if (Operators.CompareString(value, "Previous HUD", TextCompare: false) == 0)
				{
					if (ComboVisualHUD.SelectedIndex == 0)
					{
						ComboVisualHUD.SelectedIndex = ComboVisualHUD.Items.Count - 1;
					}
					else
					{
						ComboVisualHUD.SelectedIndex -= 1;
					}
				}
				if (Operators.CompareString(value, "Next ASW Mode", TextCompare: false) == 0)
				{
					if (CurrentASW != NextASW.Count - 1)
					{
						CurrentASW++;
					}
					else
					{
						CurrentASW = 0;
					}
					string left = NextASW[CurrentASW];
					if (Operators.CompareString(left, "45", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Clock45");
						Thread thread4 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock45");
						});
						thread4.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread5 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat45fps.wav");
							});
							thread5.Start();
						}
					}
					if (Operators.CompareString(left, "Off", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Off");
						Thread thread6 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Off");
						});
						thread6.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread7 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
							});
							thread7.Start();
						}
					}
					if (Operators.CompareString(left, "Auto", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Auto");
						Thread thread8 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Auto");
						});
						thread8.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread9 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
							});
							thread9.Start();
						}
					}
					if (Operators.CompareString(left, "30", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 30Hz");
						Thread thread10 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock30");
						});
						thread10.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread11 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat30fps.wav");
							});
							thread11.Start();
						}
					}
					if (Operators.CompareString(left, "18", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 18Hz");
						Thread thread12 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock18");
						});
						thread12.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread13 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat18fps.wav");
							});
							thread13.Start();
						}
					}
					if (Operators.CompareString(left, "45f", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 45Hz (Forced)");
						Thread thread14 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Sim45");
						});
						thread14.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread15 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\framerateforcedto45fps.wav");
							});
							thread15.Start();
						}
					}
					if (Operators.CompareString(left, "Adaptive", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Adaptive");
						Thread thread16 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
						});
						thread16.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread17 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\adaptiveframerateenabled.wav");
							});
							thread17.Start();
						}
					}
				}
				if (Operators.CompareString(value, "Previous ASW Mode", TextCompare: false) == 0)
				{
					if (CurrentASW != 0)
					{
						CurrentASW--;
					}
					else
					{
						CurrentASW = NextASW.Count - 1;
					}
					string left2 = NextASW[CurrentASW];
					if (Operators.CompareString(left2, "45", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 45hz");
						RunCommand.Run_debug_tool_asw("server:asw.Clock45");
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread18 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat45fps.wav");
							});
							thread18.Start();
						}
					}
					if (Operators.CompareString(left2, "Off", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Off");
						RunCommand.Run_debug_tool_asw("server:asw.Off");
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread19 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
							});
							thread19.Start();
						}
					}
					if (Operators.CompareString(left2, "Auto", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Auto");
						RunCommand.Run_debug_tool_asw("server:asw.Auto");
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread20 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
							});
							thread20.Start();
						}
					}
					if (Operators.CompareString(left2, "30", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 30Hz");
						Thread thread21 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock30");
						});
						thread21.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread22 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat30fps.wav");
							});
							thread22.Start();
						}
					}
					if (Operators.CompareString(left2, "18", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 18Hz");
						Thread thread23 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock18");
						});
						thread23.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread24 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat18fps.wav");
							});
							thread24.Start();
						}
					}
					if (Operators.CompareString(left2, "45f", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to 45Hz (forced)");
						Thread thread25 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Sim45");
						});
						thread25.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread26 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\framerateforcedto45fps.wav");
							});
							thread26.Start();
						}
					}
					if (Operators.CompareString(left2, "Adaptive", TextCompare: false) == 0)
					{
						AddToListboxAndScroll("Setting ASW to Adaptive");
						Thread thread27 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
						});
						thread27.Start();
						if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
						{
							Thread thread28 = new Thread([SpecialName] () =>
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\adaptiveframerateenabled.wav");
							});
							thread28.Start();
						}
					}
				}
			}
			if (Operators.CompareString(Key.ToString().ToUpper(), MySettingsProperty.Settings.KeyboardVoiceActivationKey, TextCompare: false) != 0)
			{
				return;
			}
			if (MySettingsProperty.Settings.VoiceActivationKeyContinous)
			{
				if (!VoiceCommands.isListening)
				{
					VoiceCommands.isListening = true;
					SetTitleIsListening();
					if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
					{
						Thread thread29 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
						});
						thread29.Start();
					}
					CultureInfo culture = new CultureInfo(CultureInfo.CurrentUICulture.Name);
					VoiceCommands.sRecognize = new SpeechRecognitionEngine(culture);
					VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
					VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
					VoiceCommands.buildGrammars();
				}
				else
				{
					if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
					{
						Thread thread30 = new Thread([SpecialName] () =>
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
						});
						thread30.Start();
					}
					VoiceCommands.StopListening();
					RemoveTitleIsListening();
				}
			}
			if (!MySettingsProperty.Settings.VoiceActivationKeyPush || VoiceCommands.isListening)
			{
				return;
			}
			if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
			{
				Thread thread31 = new Thread([SpecialName] () =>
				{
					MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
				});
				thread31.Start();
			}
			CultureInfo culture2 = new CultureInfo(CultureInfo.CurrentUICulture.Name);
			VoiceCommands.sRecognize = new SpeechRecognitionEngine(culture2);
			VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
			VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
			VoiceCommands.buildGrammars();
			VoiceCommands.isListening = true;
			SetTitleIsListening();
		}
	}

	private void kbHook_KeyUp(Keys Key)
	{
		if (!HomeIsRunning || Operators.CompareString(Key.ToString().ToUpper(), MySettingsProperty.Settings.KeyboardVoiceActivationKey, TextCompare: false) != 0 || !MySettingsProperty.Settings.VoiceActivationKeyPush)
		{
			return;
		}
		if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
		{
			Thread thread = new Thread([SpecialName] () =>
			{
				MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
			});
			thread.Start();
		}
		VoiceCommands.StopListening();
		RemoveTitleIsListening();
	}

	private void PowerPlanTimer_Tick(object sender, EventArgs e)
	{
		PowerPlanTimer.Stop();
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
		ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
		foreach (ManagementObject item in managementObjectCollection)
		{
			if (Conversions.ToBoolean(item.GetPropertyValue("IsActive")))
			{
				if (Operators.CompareString(item["ElementName"].ToString(), MySettingsProperty.Settings.PowerPlanCurrent, TextCompare: false) != 0)
				{
					Log.WriteToLog("Detected power plan change by outside source, adjusting");
					AddToListboxAndScroll("Detected power plan change by outside source, adjusting");
					PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanCurrent);
					PowerPlans.GetSetUsbSuspend(PowerPlans.filter, change: false);
				}
				break;
			}
		}
		PowerPlanTimer.Start();
	}

	private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!isCopy)
		{
			ComboBox2.Text = OTTDB.GetLinkPresetValueByName(ComboBox4.Text, "Curve");
			ComboBox3.Text = OTTDB.GetLinkPresetValueByName(ComboBox4.Text, "Encoding");
			ComboBox6.Text = OTTDB.GetLinkPresetValueByName(ComboBox4.Text, "Bitrate");
			ComboBox7.Text = OTTDB.GetLinkPresetValueByName(ComboBox4.Text, "Sharpening");
			ComboBox10.SelectedIndex = Conversions.ToInteger(OTTDB.GetLinkPresetValueByName(ComboBox4.Text, "DBR"));
			ComboBox2.Enabled = true;
			ComboBox3.Enabled = true;
			Button3.Enabled = true;
		}
	}

	private void Button10_Click(object sender, EventArgs e)
	{
		SaveOculusLinkValues(restart: true);
	}

	private void SaveOculusLinkValues(bool restart)
	{
		try
		{
			Cursor = Cursors.WaitCursor;
			if (Operators.CompareString(ComboBox4.Text, "Disabled", TextCompare: false) == 0)
			{
				MyProject.Computer.Registry.CurrentUser.DeleteSubKey("Software\\Oculus\\RemoteHeadset", throwOnMissingSubKey: false);
				Log.WriteToLog("Disabled Quest Link options");
				if (restart)
				{
					StopOVR();
					StartOVR();
				}
				else
				{
					Cursor = Cursors.Default;
				}
				return;
			}
			if (MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", writable: false) == null)
			{
				MyProject.Computer.Registry.CurrentUser.CreateSubKey("Software\\Oculus\\RemoteHeadset", writable: true);
			}
			RegistryKey registryKey = MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", writable: true);
			switch (ComboBox2.SelectedIndex)
			{
			case 0:
				if (registryKey.GetValue("DistortionCurve", null) != null)
				{
					registryKey.DeleteValue("DistortionCurve", throwOnMissingValue: false);
				}
				Log.WriteToLog("Quest Link option set: DistortionCurve = " + ComboBox2.Items[0].ToString());
				break;
			case 1:
				registryKey.SetValue("DistortionCurve", "1", RegistryValueKind.DWord);
				Log.WriteToLog("Quest Link option set: DistortionCurve = " + ComboBox2.Items[1].ToString());
				break;
			case 2:
				registryKey.SetValue("DistortionCurve", "0", RegistryValueKind.DWord);
				Log.WriteToLog("Quest Link option set: DistortionCurve = " + ComboBox2.Items[2].ToString());
				break;
			}
			registryKey.SetValue("EncodeWidth", ComboBox3.Text, RegistryValueKind.DWord);
			Log.WriteToLog("Quest Link option set: EncodeWidth = " + ComboBox3.Text);
			if (Operators.CompareString(ComboBox6.Text, "", TextCompare: false) != 0)
			{
				registryKey.SetValue("BitrateMbps", ComboBox6.Text, RegistryValueKind.DWord);
				Log.WriteToLog("Quest Link option set: BitrateMbps = " + ComboBox6.Text);
			}
			if (Operators.CompareString(ComboBox7.Text, "", TextCompare: false) != 0)
			{
				if (Operators.CompareString(ComboBox7.Text, "Disabled", TextCompare: false) == 0)
				{
					registryKey.SetValue("LinkSharpeningEnabled", "1", RegistryValueKind.DWord);
					Log.WriteToLog("Quest Link option set: LinkSharpeningEnabled = " + ComboBox7.Text);
				}
				if (Operators.CompareString(ComboBox7.Text, "Enabled", TextCompare: false) == 0)
				{
					registryKey.SetValue("LinkSharpeningEnabled", "2", RegistryValueKind.DWord);
					Log.WriteToLog("Quest Link option set: LinkSharpeningEnabled = " + ComboBox7.Text);
				}
				if (Operators.CompareString(ComboBox7.Text, "Auto", TextCompare: false) == 0 && registryKey.GetValue("LinkSharpeningEnabled", null) != null)
				{
					registryKey.DeleteValue("LinkSharpeningEnabled");
					Log.WriteToLog("Quest Link option set: LinkSharpeningEnabled = " + ComboBox7.Text);
				}
			}
			switch (ComboBox10.SelectedIndex)
			{
			case 0:
				if (registryKey.GetValue("DBR", null) != null)
				{
					registryKey.DeleteValue("DBR", throwOnMissingValue: false);
				}
				Log.WriteToLog("Quest Link option set: Encode Dynamic Bitrate = " + ComboBox10.Items[0].ToString());
				break;
			case 1:
				registryKey.SetValue("DBR", "1", RegistryValueKind.DWord);
				Log.WriteToLog("Quest Link option set: Encode Dynamic Bitrate = " + ComboBox10.Items[1].ToString());
				break;
			case 2:
				registryKey.SetValue("DBR", "0", RegistryValueKind.DWord);
				Log.WriteToLog("Quest Link option set: Encode Dynamic Bitrate = " + ComboBox10.Items[2].ToString());
				break;
			}
			if (Operators.CompareString(ComboBox11.Text, "0", TextCompare: false) == 0)
			{
				if (registryKey.GetValue("DBRMax", null) != null)
				{
					registryKey.DeleteValue("DBRMax", throwOnMissingValue: false);
				}
				Log.WriteToLog("Quest Link option set: Disabled Dynamic Bitrate Max");
			}
			else
			{
				registryKey.SetValue("DBRMax", ComboBox11.Text, RegistryValueKind.DWord);
				Log.WriteToLog("Quest Link option set: Dynamic Bitrate Max = " + ComboBox11.Text);
			}
			if ((Operators.CompareString(ComboBox4.Text, "GTX 970+", TextCompare: false) == 0) | (Operators.CompareString(ComboBox4.Text, "GTX 1070+", TextCompare: false) == 0) | (Operators.CompareString(ComboBox4.Text, "RTX 2070+", TextCompare: false) == 0) | (Operators.CompareString(ComboBox4.Text, "GTX 1080Ti/RTX 2080+", TextCompare: false) == 0))
			{
				isCopy = true;
				MyProject.Forms.frmLinkPresets.ShowDialog();
			}
			OTTDB.AddLinkPreset(ComboBox4.Text, ComboBox2.Text, ComboBox3.Text, ComboBox6.Text, ComboBox7.Text, ComboBox10.SelectedIndex.ToString());
			if (restart)
			{
				StopOVR();
				StartOVR();
			}
			else
			{
				Cursor = Cursors.Default;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Cursor = Cursors.Default;
			Log.WriteToLog("Could not set registry values for Quest Link: " + ex2.Message);
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Error setting registry values");
			ProjectData.ClearProjectError();
		}
	}

	public void GetOculusLinkValues()
	{
		try
		{
			if (MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", writable: false) == null)
			{
				return;
			}
			RegistryKey registryKey = MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", writable: false);
			if (registryKey.GetValue("DistortionCurve", null) != null)
			{
				if (Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DistortionCurve", null), "0", TextCompare: false))
				{
					ComboBox2.Text = "Low";
				}
				else if (Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DistortionCurve", null), "1", TextCompare: false))
				{
					ComboBox2.Text = "High";
				}
			}
			else
			{
				ComboBox2.Text = "Default";
			}
			if (registryKey.GetValue("EncodeWidth", null) != null)
			{
				ComboBox3.Text = Conversions.ToString(registryKey.GetValue("EncodeWidth", null));
			}
			if (registryKey.GetValue("BitrateMbps", null) != null)
			{
				ComboBox6.Text = Conversions.ToString(registryKey.GetValue("BitrateMbps", null));
			}
			if (registryKey.GetValue("LinkSharpeningEnabled", null) != null)
			{
				if (Operators.ConditionalCompareObjectEqual(registryKey.GetValue("LinkSharpeningEnabled", null), "1", TextCompare: false))
				{
					ComboBox7.Text = "Disabled";
				}
				else if (Operators.ConditionalCompareObjectEqual(registryKey.GetValue("LinkSharpeningEnabled", null), "2", TextCompare: false))
				{
					ComboBox7.Text = "Enabled";
				}
			}
			else
			{
				ComboBox7.Text = "Auto";
			}
			if (registryKey.GetValue("DBR", null) != null)
			{
				if (Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DBR", null), "1", TextCompare: false))
				{
					ComboBox10.Text = "Enabled";
				}
				else if (Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DBR", null), "0", TextCompare: false))
				{
					ComboBox10.Text = "Disabled";
				}
			}
			else
			{
				ComboBox10.Text = "Default";
			}
			if (registryKey.GetValue("DBRMax", null) != null)
			{
				ComboBox11.Text = Conversions.ToString(registryKey.GetValue("DBRMax", null));
			}
			else
			{
				ComboBox11.Text = "0";
			}
			string text = "";
			text = OTTDB.GetLinkPresetValueByValues(ComboBox2.Text, ComboBox3.Text, ComboBox6.Text, ComboBox7.Text, ComboBox10.SelectedIndex.ToString());
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				ComboBox4.Text = text;
				Log.WriteToLog("Oculus Link Preset: " + text);
			}
			else
			{
				Log.WriteToLog("No matching Presets found");
				AddToListboxAndScroll("No matching Presets found");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Could not read Link values from registry: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void ComboBox3_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!Versioned.IsNumeric(e.KeyChar) & (e.KeyChar != '\b'))
		{
			e.Handled = true;
		}
	}

	private void Button12_Click(object sender, EventArgs e)
	{
		SaveOculusLinkValues(restart: false);
	}

	private void Button11_Click(object sender, EventArgs e)
	{
		object obj = true;
		MyProject.Forms.frmLinkPresets.TextBox1.Text = "";
		MyProject.Forms.frmLinkPresets.ShowDialog();
	}

	private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ComboBox5.SelectedIndex == 0)
		{
			MySettingsProperty.Settings.AdaptiveGPUScaling = true;
			MySettingsProperty.Settings.Save();
			if (OVRIsRunning)
			{
				RunCommand.Run_debug_tool_agps("true");
				AddToListboxAndScroll("Adaptive GPU Scaling Enabled");
			}
		}
		else
		{
			MySettingsProperty.Settings.AdaptiveGPUScaling = false;
			MySettingsProperty.Settings.Save();
			if (OVRIsRunning)
			{
				RunCommand.Run_debug_tool_agps("false");
				AddToListboxAndScroll("Adaptive GPU Scaling Disabled");
			}
		}
	}

	public object GetCurrentResolution()
	{
		checked
		{
			short num = (short)Screen.PrimaryScreen.Bounds.Width;
			short num2 = (short)Screen.PrimaryScreen.Bounds.Height;
			return num.ToString().Trim() + " x " + num2.ToString().Trim();
		}
	}

	private void ComboOVRPrio_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading && Operators.CompareString(ComboOVRPrio.SelectedItem.ToString(), "", TextCompare: false) != 0)
		{
			ChangeCPUPrioOVR(ComboOVRPrio.SelectedItem.ToString());
			MySettingsProperty.Settings.OVRSrvPrio = ComboOVRPrio.SelectedItem.ToString();
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		OTTDB.RemoveLinkPresetByName(ComboBox4.Text);
		ComboBox4.Items.Clear();
		OTTDB.GetLinkPresetNames();
		GetOculusLinkValues();
	}

	private void Button6_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		string text = "Not Installed";
		string text2 = "Not Installed";
		string text3 = "Not Installed";
		if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, ""), 0, TextCompare: false))
		{
			text = "Installed";
		}
		if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, ""), 0, TextCompare: false))
		{
			text2 = "Installed";
		}
		if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, ""), 0, TextCompare: false))
		{
			text3 = "Installed";
		}
		Cursor = Cursors.Default;
		if (Interaction.MsgBox("This will install several pre-requisits, if not already installed, as well as close Oculus Home if it's running. Continue?\r\n\r\nChocolatey \t" + text + "\r\nNode.js \t\t" + text3 + "\r\nasar \t\t" + text2, MsgBoxStyle.YesNo | MsgBoxStyle.Question) == MsgBoxResult.Yes)
		{
			DotNetBarTabcontrol1.SelectedTab = DotNetBarTabcontrol1.TabPages[4];
			ListBox1.Refresh();
			AirLink.EnableAirLink();
		}
	}

	private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.ForceMipmap = ComboBox8.Text;
			MySettingsProperty.Settings.Save();
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_force_mipmap(MySettingsProperty.Settings.ForceMipmap.ToString().ToLower());
			});
			thread.Start();
		}
	}

	private void ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.OffsetMipmap = ComboBox9.Text;
			MySettingsProperty.Settings.Save();
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_offset_mipmap(MySettingsProperty.Settings.OffsetMipmap.ToString());
			});
			thread.Start();
		}
	}

	private void ComboSSstart_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!(!char.IsNumber(e.KeyChar) & (e.KeyChar != '.') & (Convert.ToInt32(e.KeyChar) != 8)))
		{
			return;
		}
		if (e.KeyChar == Conversions.ToChar(DSep))
		{
			e.Handled = true;
		}
		else if (e.KeyChar == '\r')
		{
			if (!GetConfig.IsReading)
			{
				MySettingsProperty.Settings.PPDPStartup = ComboSSstart.Text;
				MySettingsProperty.Settings.Save();
				GetConfig.ppdpstartup = ComboSSstart.Text;
				Thread thread = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
				});
				thread.Start();
			}
		}
		else
		{
			e.Handled = true;
		}
	}

	private void CheckStopServiceHome_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (!GetConfig.IsReading)
			{
				if (CheckStopServiceHome.Checked)
				{
					MySettingsProperty.Settings.StopOVRHome = true;
				}
				else
				{
					MySettingsProperty.Settings.StopOVRHome = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			AddToListboxAndScroll("* Exception: " + ex2.Message);
			hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.FrmMain));
		this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.ToolStripStartOVR = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripStopOVR = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripRestartOVR = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuShowHome = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.ClearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.OpenLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.ComboSSstart = new System.Windows.Forms.ComboBox();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.ComboHomless = new System.Windows.Forms.ComboBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.ComboVoice = new System.Windows.Forms.ComboBox();
		this.BtnVoice = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.PictureBox8 = new System.Windows.Forms.PictureBox();
		this.CheckRiftAudio = new System.Windows.Forms.CheckBox();
		this.CheckSpoofCPU = new System.Windows.Forms.CheckBox();
		this.ButtonRestartOVR = new System.Windows.Forms.Button();
		this.ButtonStartOVR = new System.Windows.Forms.Button();
		this.ButtonStopOVR = new System.Windows.Forms.Button();
		this.Label29 = new System.Windows.Forms.Label();
		this.CheckLocalDebug = new System.Windows.Forms.CheckBox();
		this.CheckStartWatcher = new System.Windows.Forms.CheckBox();
		this.Label13 = new System.Windows.Forms.Label();
		this.Label18 = new System.Windows.Forms.Label();
		this.Button4 = new System.Windows.Forms.Button();
		this.BtnRemoveAllProfiles = new System.Windows.Forms.Button();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button5 = new System.Windows.Forms.Button();
		this.PictureBox7 = new System.Windows.Forms.PictureBox();
		this.PictureBox6 = new System.Windows.Forms.PictureBox();
		this.PictureBox5 = new System.Windows.Forms.PictureBox();
		this.PictureBox4 = new System.Windows.Forms.PictureBox();
		this.PictureBox3 = new System.Windows.Forms.PictureBox();
		this.Button11 = new System.Windows.Forms.Button();
		this.OculusHomeWatcher = new System.Windows.Forms.Timer(this.components);
		this.Label8 = new System.Windows.Forms.Label();
		this.NotificationTimer = new System.Windows.Forms.Timer(this.components);
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.HometoTrayTimer = new System.Windows.Forms.Timer(this.components);
		this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
		this.NotifyIcon3 = new System.Windows.Forms.NotifyIcon(this.components);
		this.PowerPlanTimer = new System.Windows.Forms.Timer(this.components);
		this.DotNetBarTabcontrol1 = new OculusTrayTool.DotNetBarTabcontrol();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.GroupBox14 = new System.Windows.Forms.GroupBox();
		this.DbLayoutPanel2 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.Label19 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.BtnProfiles = new System.Windows.Forms.Button();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.ComboMirrorHome = new System.Windows.Forms.ComboBox();
		this.Label16 = new System.Windows.Forms.Label();
		this.BtnHomless = new System.Windows.Forms.Button();
		this.Label15 = new System.Windows.Forms.Label();
		this.Label35 = new System.Windows.Forms.Label();
		this.ComboVisualHUD = new System.Windows.Forms.ComboBox();
		this.ComboBox5 = new System.Windows.Forms.ComboBox();
		this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
		this.NumericFOVh = new System.Windows.Forms.NumericUpDown();
		this.NumericFOVv = new System.Windows.Forms.NumericUpDown();
		this.ComboOVRPrio = new System.Windows.Forms.ComboBox();
		this.Label33 = new System.Windows.Forms.Label();
		this.ComboBox8 = new System.Windows.Forms.ComboBox();
		this.ComboBox9 = new System.Windows.Forms.ComboBox();
		this.Label37 = new System.Windows.Forms.Label();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.DbLayoutPanel4 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.CheckStartWindows = new System.Windows.Forms.CheckBox();
		this.CheckStartMin = new System.Windows.Forms.CheckBox();
		this.CheckMinimizeOnX = new System.Windows.Forms.CheckBox();
		this.CheckBoxAltTab = new System.Windows.Forms.CheckBox();
		this.HotKeysCheckBox = new System.Windows.Forms.CheckBox();
		this.BtnConfigureAudio = new System.Windows.Forms.Button();
		this.Label14 = new System.Windows.Forms.Label();
		this.CheckBoxCheckForUpdates = new System.Windows.Forms.CheckBox();
		this.BtnConfigureHotKeys = new System.Windows.Forms.Button();
		this.TrackBar1 = new System.Windows.Forms.TrackBar();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.DbLayoutPanel5 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.ComboApplyPlan = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.ComboPowerPlanExit = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.ComboPowerPlanStart = new System.Windows.Forms.ComboBox();
		this.Label22 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label23 = new System.Windows.Forms.Label();
		this.CheckSensorPower = new System.Windows.Forms.CheckBox();
		this.ComboUSBsusp = new System.Windows.Forms.ComboBox();
		this.TabPage4 = new System.Windows.Forms.TabPage();
		this.DbLayoutPanel7 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.GroupBox6 = new System.Windows.Forms.GroupBox();
		this.DbLayoutPanel8 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.CheckStartService = new System.Windows.Forms.CheckBox();
		this.CheckStopService = new System.Windows.Forms.CheckBox();
		this.CheckSendHomeToTrayOnStart = new System.Windows.Forms.CheckBox();
		this.CheckSendHomeToTray = new System.Windows.Forms.CheckBox();
		this.CheckCloseHome = new System.Windows.Forms.CheckBox();
		this.CheckLaunchHomeTool = new System.Windows.Forms.CheckBox();
		this.CheckLaunchHome = new System.Windows.Forms.CheckBox();
		this.CheckRestartSleep = new System.Windows.Forms.CheckBox();
		this.CheckStopServiceHome = new System.Windows.Forms.CheckBox();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.DbLayoutPanel6 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.LabelServiceStatus = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.TabPage5 = new System.Windows.Forms.TabPage();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.ListBox1 = new System.Windows.Forms.ListBox();
		this.TabPage7 = new System.Windows.Forms.TabPage();
		this.GroupBox7 = new System.Windows.Forms.GroupBox();
		this.DbLayoutPanel1 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.BtnLibrary = new System.Windows.Forms.Button();
		this.BtnSteamImport = new System.Windows.Forms.Button();
		this.Label24 = new System.Windows.Forms.Label();
		this.Label25 = new System.Windows.Forms.Label();
		this.Label26 = new System.Windows.Forms.Label();
		this.Label27 = new System.Windows.Forms.Label();
		this.Label28 = new System.Windows.Forms.Label();
		this.TabPage8 = new System.Windows.Forms.TabPage();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button12 = new System.Windows.Forms.Button();
		this.DbLayoutPanel3 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.ComboBox11 = new System.Windows.Forms.ComboBox();
		this.ComboBox6 = new System.Windows.Forms.ComboBox();
		this.Label32 = new System.Windows.Forms.Label();
		this.Label30 = new System.Windows.Forms.Label();
		this.Label31 = new System.Windows.Forms.Label();
		this.ComboBox4 = new System.Windows.Forms.ComboBox();
		this.ComboBox3 = new System.Windows.Forms.ComboBox();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.Label36 = new System.Windows.Forms.Label();
		this.Label38 = new System.Windows.Forms.Label();
		this.ComboBox10 = new System.Windows.Forms.ComboBox();
		this.Label21 = new System.Windows.Forms.Label();
		this.Button6 = new System.Windows.Forms.Button();
		this.Label20 = new System.Windows.Forms.Label();
		this.ComboBox7 = new System.Windows.Forms.ComboBox();
		this.Label39 = new System.Windows.Forms.Label();
		this.Button10 = new System.Windows.Forms.Button();
		this.Label10 = new System.Windows.Forms.Label();
		this.TabPage6 = new System.Windows.Forms.TabPage();
		this.GroupBox9 = new System.Windows.Forms.GroupBox();
		this.LabelDownloadStatus = new System.Windows.Forms.Label();
		this.LabelVer = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.Button9 = new System.Windows.Forms.Button();
		this.Button8 = new System.Windows.Forms.Button();
		this.ContextMenuStrip1.SuspendLayout();
		this.ContextMenuStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox3).BeginInit();
		this.DotNetBarTabcontrol1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.GroupBox14.SuspendLayout();
		this.DbLayoutPanel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
		this.SplitContainer1.Panel1.SuspendLayout();
		this.SplitContainer1.Panel2.SuspendLayout();
		this.SplitContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericFOVh).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericFOVv).BeginInit();
		this.TabPage2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.DbLayoutPanel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.TrackBar1).BeginInit();
		this.TabPage3.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.DbLayoutPanel5.SuspendLayout();
		this.TabPage4.SuspendLayout();
		this.DbLayoutPanel7.SuspendLayout();
		this.GroupBox6.SuspendLayout();
		this.DbLayoutPanel8.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.DbLayoutPanel6.SuspendLayout();
		this.TabPage5.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.TabPage7.SuspendLayout();
		this.GroupBox7.SuspendLayout();
		this.DbLayoutPanel1.SuspendLayout();
		this.TabPage8.SuspendLayout();
		this.GroupBox5.SuspendLayout();
		this.DbLayoutPanel3.SuspendLayout();
		this.TabPage6.SuspendLayout();
		this.GroupBox9.SuspendLayout();
		base.SuspendLayout();
		this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
		this.NotifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("NotifyIcon1.Icon");
		this.NotifyIcon1.Text = "Oculus Tray Tool";
		this.ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.ToolStripStartOVR, this.ToolStripStopOVR, this.ToolStripRestartOVR, this.ToolStripSeparator2, this.ToolStripMenuItem3, this.ToolStripSeparator1, this.ToolStripMenuItem2, this.ToolStripMenuShowHome, this.ToolStripMenuItem1 });
		this.ContextMenuStrip1.Name = "ContextMenuStrip1";
		this.ContextMenuStrip1.Size = new System.Drawing.Size(230, 198);
		this.ToolStripStartOVR.Image = (System.Drawing.Image)resources.GetObject("ToolStripStartOVR.Image");
		this.ToolStripStartOVR.Name = "ToolStripStartOVR";
		this.ToolStripStartOVR.Size = new System.Drawing.Size(229, 26);
		this.ToolStripStartOVR.Text = "Start Oculus Service";
		this.ToolStripStopOVR.Image = (System.Drawing.Image)resources.GetObject("ToolStripStopOVR.Image");
		this.ToolStripStopOVR.Name = "ToolStripStopOVR";
		this.ToolStripStopOVR.Size = new System.Drawing.Size(229, 26);
		this.ToolStripStopOVR.Text = "Stop Oculus Service";
		this.ToolStripRestartOVR.Image = (System.Drawing.Image)resources.GetObject("ToolStripRestartOVR.Image");
		this.ToolStripRestartOVR.Name = "ToolStripRestartOVR";
		this.ToolStripRestartOVR.Size = new System.Drawing.Size(229, 26);
		this.ToolStripRestartOVR.Text = "Restart Oculus Service";
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new System.Drawing.Size(226, 6);
		this.ToolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem3.Image");
		this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		this.ToolStripMenuItem3.Size = new System.Drawing.Size(229, 26);
		this.ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new System.Drawing.Size(226, 6);
		this.ToolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem2.Image");
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		this.ToolStripMenuItem2.Size = new System.Drawing.Size(229, 26);
		this.ToolStripMenuItem2.Text = "Show Application";
		this.ToolStripMenuShowHome.Enabled = false;
		this.ToolStripMenuShowHome.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuShowHome.Image");
		this.ToolStripMenuShowHome.Name = "ToolStripMenuShowHome";
		this.ToolStripMenuShowHome.Size = new System.Drawing.Size(229, 26);
		this.ToolStripMenuShowHome.Text = "Show Oculus Home";
		this.ToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem1.Image");
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new System.Drawing.Size(229, 26);
		this.ToolStripMenuItem1.Text = "Exit";
		this.ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.ToolStripMenuItem4, this.ClearLogToolStripMenuItem, this.OpenLogToolStripMenuItem });
		this.ContextMenuStrip2.Name = "ContextMenuStrip2";
		this.ContextMenuStrip2.Size = new System.Drawing.Size(227, 82);
		this.ToolStripMenuItem4.Enabled = false;
		this.ToolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem4.Image");
		this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		this.ToolStripMenuItem4.Size = new System.Drawing.Size(226, 26);
		this.ToolStripMenuItem4.Text = "Disable Power Management";
		this.ToolStripMenuItem4.Visible = false;
		this.ClearLogToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("ClearLogToolStripMenuItem.Image");
		this.ClearLogToolStripMenuItem.Name = "ClearLogToolStripMenuItem";
		this.ClearLogToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
		this.ClearLogToolStripMenuItem.Text = "Clear Log";
		this.OpenLogToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("OpenLogToolStripMenuItem.Image");
		this.OpenLogToolStripMenuItem.Name = "OpenLogToolStripMenuItem";
		this.OpenLogToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
		this.OpenLogToolStripMenuItem.Text = "Open Log";
		this.ToolTip.AutoPopDelay = 10000;
		this.ToolTip.InitialDelay = 100;
		this.ToolTip.ReshowDelay = 100;
		this.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(30, 401);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(99, 31);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox1.TabIndex = 9;
		this.PictureBox1.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox1, "Donate to the project");
		this.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox2.Image = (System.Drawing.Image)resources.GetObject("PictureBox2.Image");
		this.PictureBox2.Location = new System.Drawing.Point(5, 408);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(19, 20);
		this.PictureBox2.TabIndex = 32;
		this.PictureBox2.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox2, "About");
		this.ComboSSstart.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboSSstart.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboSSstart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboSSstart.FormattingEnabled = true;
		this.ComboSSstart.Items.AddRange(new object[38]
		{
			"0", "0.7", "0.75", "0.8", "0.85", "0.9", "0.95", "1.0", "1.05", "1.1",
			"1.15", "1.2", "1.25", "1.3", "1.35", "1.4", "1.45", "1.5", "1.55", "1.6",
			"1.65", "1.7", "1.75", "1.8", "1.85", "1.9", "1.95", "2.0", "2.05", "2.1",
			"2.15", "2.2", "2.25", "2.3", "2.35", "2.4", "2.45", "2.5"
		});
		this.ComboSSstart.Location = new System.Drawing.Point(167, 39);
		this.ComboSSstart.Name = "ComboSSstart";
		this.ComboSSstart.Size = new System.Drawing.Size(116, 23);
		this.ComboSSstart.Sorted = true;
		this.ComboSSstart.TabIndex = 11;
		this.ComboSSstart.TabStop = false;
		this.ToolTip.SetToolTip(this.ComboSSstart, "This is the Super Sampling modifier set on startup. All VR apps that do not have a profile will inherit this setting");
		this.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox1.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox1.FormattingEnabled = true;
		this.ComboBox1.Items.AddRange(new object[7] { "18 Hz", "30 Hz", "45 Hz", "45 Hz forced", "Adaptive", "Auto", "Off" });
		this.ComboBox1.Location = new System.Drawing.Point(167, 72);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(116, 23);
		this.ComboBox1.Sorted = true;
		this.ComboBox1.TabIndex = 25;
		this.ComboBox1.TabStop = false;
		this.ToolTip.SetToolTip(this.ComboBox1, "This is the ASW mode set on startup. All VR apps that do not have a profile will inherit this setting");
		this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label1.Location = new System.Drawing.Point(4, 34);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(156, 32);
		this.Label1.TabIndex = 21;
		this.Label1.Text = "Default Super Sampling";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolTip.SetToolTip(this.Label1, "This is the Super Sampling modifier set on startup. All VR apps that do not have a profile will inherit this setting");
		this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label6.Location = new System.Drawing.Point(4, 67);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(156, 32);
		this.Label6.TabIndex = 26;
		this.Label6.Text = "Default ASW Mode";
		this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolTip.SetToolTip(this.Label6, "This is the ASW mode set on startup. All VR apps that do not have a profile will inherit this setting");
		this.ComboHomless.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboHomless.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboHomless.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboHomless.FormattingEnabled = true;
		this.ComboHomless.Items.AddRange(new object[2] { "Disabled", "Enabled" });
		this.ComboHomless.Location = new System.Drawing.Point(167, 202);
		this.ComboHomless.Name = "ComboHomless";
		this.ComboHomless.Size = new System.Drawing.Size(116, 23);
		this.ComboHomless.TabIndex = 37;
		this.ToolTip.SetToolTip(this.ComboHomless, "Enable or Disable Oculus Homeless");
		this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label5.Location = new System.Drawing.Point(4, 166);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(156, 32);
		this.Label5.TabIndex = 12;
		this.Label5.Text = "Voice Commands";
		this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolTip.SetToolTip(this.Label5, "Enable voice commands");
		this.ComboVoice.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboVoice.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboVoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboVoice.FormattingEnabled = true;
		this.ComboVoice.Items.AddRange(new object[2] { "Disabled", "Enabled" });
		this.ComboVoice.Location = new System.Drawing.Point(167, 171);
		this.ComboVoice.Name = "ComboVoice";
		this.ComboVoice.Size = new System.Drawing.Size(116, 23);
		this.ComboVoice.TabIndex = 13;
		this.ComboVoice.TabStop = false;
		this.ToolTip.SetToolTip(this.ComboVoice, "Enable Voice commands");
		this.BtnVoice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.BtnVoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnVoice.Location = new System.Drawing.Point(290, 169);
		this.BtnVoice.Name = "BtnVoice";
		this.BtnVoice.Size = new System.Drawing.Size(59, 26);
		this.BtnVoice.TabIndex = 24;
		this.BtnVoice.TabStop = false;
		this.BtnVoice.Text = "Edit";
		this.ToolTip.SetToolTip(this.BtnVoice, "Configure Voice Commands");
		this.BtnVoice.UseVisualStyleBackColor = true;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Location = new System.Drawing.Point(290, 136);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(59, 26);
		this.Button2.TabIndex = 34;
		this.Button2.TabStop = false;
		this.Button2.Text = "Save";
		this.ToolTip.SetToolTip(this.Button2, "Sets the FOV on your regular 2D display. Useful when streaming gameplay.\r\nDoes not affect FOV in the Rift itself.");
		this.Button2.UseVisualStyleBackColor = true;
		this.PictureBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.PictureBox8.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox8.Image = (System.Drawing.Image)resources.GetObject("PictureBox8.Image");
		this.PictureBox8.Location = new System.Drawing.Point(310, 7);
		this.PictureBox8.Name = "PictureBox8";
		this.PictureBox8.Size = new System.Drawing.Size(19, 20);
		this.PictureBox8.TabIndex = 53;
		this.PictureBox8.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox8, "Create a Profile with custom settings for each of your games.");
		this.CheckRiftAudio.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckRiftAudio.Location = new System.Drawing.Point(4, 90);
		this.CheckRiftAudio.Name = "CheckRiftAudio";
		this.CheckRiftAudio.Size = new System.Drawing.Size(153, 36);
		this.CheckRiftAudio.TabIndex = 7;
		this.CheckRiftAudio.TabStop = false;
		this.CheckRiftAudio.Text = "Use Audio Switcher";
		this.ToolTip.SetToolTip(this.CheckRiftAudio, "Check to have the Rift set as default device for Audio and/or Mic when Oculus Home starts");
		this.CheckRiftAudio.UseVisualStyleBackColor = true;
		this.CheckSpoofCPU.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckSpoofCPU.Location = new System.Drawing.Point(4, 214);
		this.CheckSpoofCPU.Name = "CheckSpoofCPU";
		this.CheckSpoofCPU.Size = new System.Drawing.Size(322, 23);
		this.CheckSpoofCPU.TabIndex = 27;
		this.CheckSpoofCPU.TabStop = false;
		this.CheckSpoofCPU.Text = "Spoof CPU ID on tool start";
		this.ToolTip.SetToolTip(this.CheckSpoofCPU, "Check to spoof the CPU ID. Makes Oculus nag screen regarding minimum specs go away. Takes affect immediately when checked and forces a restart of the OVR service.");
		this.CheckSpoofCPU.UseVisualStyleBackColor = true;
		this.ButtonRestartOVR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ButtonRestartOVR.FlatAppearance.BorderSize = 0;
		this.ButtonRestartOVR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.ButtonRestartOVR.Image = (System.Drawing.Image)resources.GetObject("ButtonRestartOVR.Image");
		this.ButtonRestartOVR.Location = new System.Drawing.Point(292, 3);
		this.ButtonRestartOVR.Name = "ButtonRestartOVR";
		this.ButtonRestartOVR.Size = new System.Drawing.Size(52, 55);
		this.ButtonRestartOVR.TabIndex = 16;
		this.ButtonRestartOVR.TabStop = false;
		this.ToolTip.SetToolTip(this.ButtonRestartOVR, "Restart the Oculus service if it is running");
		this.ButtonRestartOVR.UseVisualStyleBackColor = true;
		this.ButtonStartOVR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ButtonStartOVR.FlatAppearance.BorderSize = 0;
		this.ButtonStartOVR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.ButtonStartOVR.Image = (System.Drawing.Image)resources.GetObject("ButtonStartOVR.Image");
		this.ButtonStartOVR.Location = new System.Drawing.Point(183, 3);
		this.ButtonStartOVR.Name = "ButtonStartOVR";
		this.ButtonStartOVR.Size = new System.Drawing.Size(50, 55);
		this.ButtonStartOVR.TabIndex = 14;
		this.ButtonStartOVR.TabStop = false;
		this.ToolTip.SetToolTip(this.ButtonStartOVR, "Start the Oculus service if it is down");
		this.ButtonStartOVR.UseVisualStyleBackColor = true;
		this.ButtonStopOVR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ButtonStopOVR.FlatAppearance.BorderSize = 0;
		this.ButtonStopOVR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.ButtonStopOVR.Image = (System.Drawing.Image)resources.GetObject("ButtonStopOVR.Image");
		this.ButtonStopOVR.Location = new System.Drawing.Point(239, 3);
		this.ButtonStopOVR.Name = "ButtonStopOVR";
		this.ButtonStopOVR.Size = new System.Drawing.Size(47, 55);
		this.ButtonStopOVR.TabIndex = 15;
		this.ButtonStopOVR.TabStop = false;
		this.ToolTip.SetToolTip(this.ButtonStopOVR, "Stop the Oculus service if it is running");
		this.ButtonStopOVR.UseVisualStyleBackColor = true;
		this.Label29.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label29.Location = new System.Drawing.Point(4, 345);
		this.Label29.Name = "Label29";
		this.Label29.Size = new System.Drawing.Size(155, 50);
		this.Label29.TabIndex = 38;
		this.Label29.Text = "Game Library";
		this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolTip.SetToolTip(this.Label29, "Enable voice commands");
		this.CheckLocalDebug.AutoSize = true;
		this.CheckLocalDebug.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckLocalDebug.Location = new System.Drawing.Point(166, 4);
		this.CheckLocalDebug.Name = "CheckLocalDebug";
		this.CheckLocalDebug.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.CheckLocalDebug.Size = new System.Drawing.Size(156, 41);
		this.CheckLocalDebug.TabIndex = 0;
		this.CheckLocalDebug.Text = "Use OTT Local";
		this.ToolTip.SetToolTip(this.CheckLocalDebug, "Use the Oculus Debug Tool shipped with OTT. Don't check this box unless you know what you are doing as it could potantially break functionality.");
		this.CheckLocalDebug.UseVisualStyleBackColor = true;
		this.CheckStartWatcher.AutoSize = true;
		this.CheckStartWatcher.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckStartWatcher.Location = new System.Drawing.Point(166, 52);
		this.CheckStartWatcher.Name = "CheckStartWatcher";
		this.CheckStartWatcher.Size = new System.Drawing.Size(156, 41);
		this.CheckStartWatcher.TabIndex = 4;
		this.CheckStartWatcher.Text = "Start on OTT Start";
		this.ToolTip.SetToolTip(this.CheckStartWatcher, resources.GetString("CheckStartWatcher.ToolTip"));
		this.CheckStartWatcher.UseVisualStyleBackColor = true;
		this.Label13.AutoSize = true;
		this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label13.Location = new System.Drawing.Point(4, 1);
		this.Label13.Name = "Label13";
		this.Label13.Size = new System.Drawing.Size(155, 47);
		this.Label13.TabIndex = 31;
		this.Label13.Text = "Oculus Debug Tool";
		this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolTip.SetToolTip(this.Label13, "Use the Oculus Debug Tool shipped with OTT. Don't check this box unless you know what you are doing as it could potantially break functionality.");
		this.Label18.AutoSize = true;
		this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label18.Location = new System.Drawing.Point(4, 49);
		this.Label18.Name = "Label18";
		this.Label18.Size = new System.Drawing.Size(155, 47);
		this.Label18.TabIndex = 32;
		this.Label18.Text = " AppWatcher";
		this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolTip.SetToolTip(this.Label18, resources.GetString("Label18.ToolTip"));
		this.Button4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button4.Location = new System.Drawing.Point(166, 100);
		this.Button4.Name = "Button4";
		this.Button4.Size = new System.Drawing.Size(156, 41);
		this.Button4.TabIndex = 3;
		this.Button4.Text = "Reset all to default";
		this.ToolTip.SetToolTip(this.Button4, "Reset all settings to Default");
		this.Button4.UseVisualStyleBackColor = true;
		this.BtnRemoveAllProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
		this.BtnRemoveAllProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnRemoveAllProfiles.Location = new System.Drawing.Point(166, 148);
		this.BtnRemoveAllProfiles.Name = "BtnRemoveAllProfiles";
		this.BtnRemoveAllProfiles.Size = new System.Drawing.Size(156, 41);
		this.BtnRemoveAllProfiles.TabIndex = 5;
		this.BtnRemoveAllProfiles.Text = "Remove all";
		this.ToolTip.SetToolTip(this.BtnRemoveAllProfiles, "Remove all Profiles");
		this.BtnRemoveAllProfiles.UseVisualStyleBackColor = true;
		this.Button1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Location = new System.Drawing.Point(166, 196);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(156, 41);
		this.Button1.TabIndex = 6;
		this.Button1.Text = "Check for updates";
		this.ToolTip.SetToolTip(this.Button1, "Manually check if there's any updates available");
		this.Button1.UseVisualStyleBackColor = true;
		this.Button5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button5.Location = new System.Drawing.Point(166, 244);
		this.Button5.Name = "Button5";
		this.Button5.Size = new System.Drawing.Size(156, 44);
		this.Button5.TabIndex = 7;
		this.Button5.Text = "Restart in Debug mode";
		this.ToolTip.SetToolTip(this.Button5, "Restart in Debug mode for additional logging");
		this.Button5.UseVisualStyleBackColor = true;
		this.PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox7.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox7.Image = (System.Drawing.Image)resources.GetObject("PictureBox7.Image");
		this.PictureBox7.Location = new System.Drawing.Point(314, 133);
		this.PictureBox7.Name = "PictureBox7";
		this.PictureBox7.Size = new System.Drawing.Size(19, 20);
		this.PictureBox7.TabIndex = 37;
		this.PictureBox7.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox7, "Override distortion curvature. Higher curvature gives higher pixel density in center.");
		this.PictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox6.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox6.Image = (System.Drawing.Image)resources.GetObject("PictureBox6.Image");
		this.PictureBox6.Location = new System.Drawing.Point(314, 199);
		this.PictureBox6.Name = "PictureBox6";
		this.PictureBox6.Size = new System.Drawing.Size(19, 20);
		this.PictureBox6.TabIndex = 36;
		this.PictureBox6.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox6, "Override encoding bitrate");
		this.PictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox5.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox5.Image = (System.Drawing.Image)resources.GetObject("PictureBox5.Image");
		this.PictureBox5.Location = new System.Drawing.Point(314, 265);
		this.PictureBox5.Name = "PictureBox5";
		this.PictureBox5.Size = new System.Drawing.Size(19, 20);
		this.PictureBox5.TabIndex = 35;
		this.PictureBox5.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox5, "Override maximum dynamic bitrate");
		this.PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox4.Image = (System.Drawing.Image)resources.GetObject("PictureBox4.Image");
		this.PictureBox4.Location = new System.Drawing.Point(314, 232);
		this.PictureBox4.Name = "PictureBox4";
		this.PictureBox4.Size = new System.Drawing.Size(19, 20);
		this.PictureBox4.TabIndex = 34;
		this.PictureBox4.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox4, "Automatically adjust bitrate");
		this.PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox3.Image = (System.Drawing.Image)resources.GetObject("PictureBox3.Image");
		this.PictureBox3.Location = new System.Drawing.Point(314, 336);
		this.PictureBox3.Name = "PictureBox3";
		this.PictureBox3.Size = new System.Drawing.Size(19, 20);
		this.PictureBox3.TabIndex = 33;
		this.PictureBox3.TabStop = false;
		this.ToolTip.SetToolTip(this.PictureBox3, "Uses Paolod29's code to patch AirLink and make it permanently enabled.\r\nYou need to run this again if the Oculus App is updated.\r\nCheck out https://github.com/pd29/oculus-airlink-enabler \r\nfor more.");
		this.Button11.Enabled = false;
		this.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button11.Location = new System.Drawing.Point(314, 98);
		this.Button11.Name = "Button11";
		this.Button11.Size = new System.Drawing.Size(22, 22);
		this.Button11.TabIndex = 11;
		this.Button11.Text = "+";
		this.ToolTip.SetToolTip(this.Button11, "Create Custom Preset");
		this.Button11.UseVisualStyleBackColor = true;
		this.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Label8.AutoSize = true;
		this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label8.ForeColor = System.Drawing.Color.DarkRed;
		this.Label8.Location = new System.Drawing.Point(432, 0);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(68, 12);
		this.Label8.TabIndex = 7;
		this.Label8.Text = "By ApollyonVR";
		this.NotificationTimer.Interval = 1500;
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "Icon_GameSettings.png");
		this.ImageList1.Images.SetKeyName(1, "Icon_TrayTool.png");
		this.ImageList1.Images.SetKeyName(2, "Icon_PowerOptions.png");
		this.ImageList1.Images.SetKeyName(3, "Icon_Service&Startup.png");
		this.ImageList1.Images.SetKeyName(4, "Icon_Log.png");
		this.ImageList1.Images.SetKeyName(5, "icon-advanced.png");
		this.ImageList1.Images.SetKeyName(6, "up-32.png");
		this.ImageList1.Images.SetKeyName(7, "icon_QuestLink.png");
		this.UpdateTimer.Interval = 5000;
		this.NotifyIcon3.Icon = (System.Drawing.Icon)resources.GetObject("NotifyIcon3.Icon");
		this.NotifyIcon3.Text = "Oculus Home";
		this.PowerPlanTimer.Interval = 2000;
		this.DotNetBarTabcontrol1.Alignment = System.Windows.Forms.TabAlignment.Left;
		this.DotNetBarTabcontrol1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage1);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage2);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage3);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage4);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage5);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage7);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage8);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage6);
		this.DotNetBarTabcontrol1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.DotNetBarTabcontrol1.ImageList = this.ImageList1;
		this.DotNetBarTabcontrol1.ItemSize = new System.Drawing.Size(43, 135);
		this.DotNetBarTabcontrol1.Location = new System.Drawing.Point(0, 0);
		this.DotNetBarTabcontrol1.Multiline = true;
		this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
		this.DotNetBarTabcontrol1.Padding = new System.Drawing.Point(6, 8);
		this.DotNetBarTabcontrol1.SelectedIndex = 0;
		this.DotNetBarTabcontrol1.Size = new System.Drawing.Size(508, 433);
		this.DotNetBarTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		this.DotNetBarTabcontrol1.TabIndex = 29;
		this.TabPage1.BackColor = System.Drawing.Color.White;
		this.TabPage1.Controls.Add(this.GroupBox14);
		this.TabPage1.Location = new System.Drawing.Point(139, 4);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(365, 425);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Game Settings";
		this.GroupBox14.Controls.Add(this.DbLayoutPanel2);
		this.GroupBox14.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox14.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox14.Location = new System.Drawing.Point(3, 3);
		this.GroupBox14.Name = "GroupBox14";
		this.GroupBox14.Size = new System.Drawing.Size(359, 419);
		this.GroupBox14.TabIndex = 0;
		this.GroupBox14.TabStop = false;
		this.DbLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel2.ColumnCount = 3;
		this.DbLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.5356f));
		this.DbLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.12687f));
		this.DbLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.33753f));
		this.DbLayoutPanel2.Controls.Add(this.Label19, 0, 9);
		this.DbLayoutPanel2.Controls.Add(this.Label7, 0, 0);
		this.DbLayoutPanel2.Controls.Add(this.BtnProfiles, 1, 0);
		this.DbLayoutPanel2.Controls.Add(this.ComboSSstart, 1, 1);
		this.DbLayoutPanel2.Controls.Add(this.ComboBox1, 1, 2);
		this.DbLayoutPanel2.Controls.Add(this.Label1, 0, 1);
		this.DbLayoutPanel2.Controls.Add(this.Label6, 0, 2);
		this.DbLayoutPanel2.Controls.Add(this.Label9, 0, 8);
		this.DbLayoutPanel2.Controls.Add(this.Label17, 0, 7);
		this.DbLayoutPanel2.Controls.Add(this.ComboMirrorHome, 1, 7);
		this.DbLayoutPanel2.Controls.Add(this.Label16, 0, 6);
		this.DbLayoutPanel2.Controls.Add(this.ComboHomless, 1, 6);
		this.DbLayoutPanel2.Controls.Add(this.BtnHomless, 2, 6);
		this.DbLayoutPanel2.Controls.Add(this.Label5, 0, 5);
		this.DbLayoutPanel2.Controls.Add(this.ComboVoice, 1, 5);
		this.DbLayoutPanel2.Controls.Add(this.BtnVoice, 2, 5);
		this.DbLayoutPanel2.Controls.Add(this.Label15, 0, 4);
		this.DbLayoutPanel2.Controls.Add(this.Button2, 2, 4);
		this.DbLayoutPanel2.Controls.Add(this.Label35, 0, 3);
		this.DbLayoutPanel2.Controls.Add(this.ComboVisualHUD, 1, 8);
		this.DbLayoutPanel2.Controls.Add(this.ComboBox5, 1, 3);
		this.DbLayoutPanel2.Controls.Add(this.SplitContainer1, 1, 4);
		this.DbLayoutPanel2.Controls.Add(this.ComboOVRPrio, 1, 9);
		this.DbLayoutPanel2.Controls.Add(this.Label33, 0, 10);
		this.DbLayoutPanel2.Controls.Add(this.ComboBox8, 1, 10);
		this.DbLayoutPanel2.Controls.Add(this.ComboBox9, 1, 11);
		this.DbLayoutPanel2.Controls.Add(this.Label37, 0, 11);
		this.DbLayoutPanel2.Controls.Add(this.PictureBox8, 2, 0);
		this.DbLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DbLayoutPanel2.Location = new System.Drawing.Point(3, 17);
		this.DbLayoutPanel2.Name = "DbLayoutPanel2";
		this.DbLayoutPanel2.RowCount = 12;
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332f));
		this.DbLayoutPanel2.Size = new System.Drawing.Size(353, 399);
		this.DbLayoutPanel2.TabIndex = 1;
		this.Label19.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label19.Location = new System.Drawing.Point(4, 298);
		this.Label19.Name = "Label19";
		this.Label19.Size = new System.Drawing.Size(156, 32);
		this.Label19.TabIndex = 47;
		this.Label19.Text = "OVR Server Priority";
		this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label7.Location = new System.Drawing.Point(4, 1);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(156, 32);
		this.Label7.TabIndex = 16;
		this.Label7.Text = "Profiles";
		this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.BtnProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.BtnProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.BtnProfiles.Location = new System.Drawing.Point(167, 4);
		this.BtnProfiles.Name = "BtnProfiles";
		this.BtnProfiles.Size = new System.Drawing.Size(116, 26);
		this.BtnProfiles.TabIndex = 10;
		this.BtnProfiles.TabStop = false;
		this.BtnProfiles.Text = "View && Edit";
		this.BtnProfiles.UseVisualStyleBackColor = true;
		this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label9.Location = new System.Drawing.Point(4, 265);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(156, 32);
		this.Label9.TabIndex = 39;
		this.Label9.Text = "Visual HUD";
		this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label17.AutoSize = true;
		this.Label17.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label17.Location = new System.Drawing.Point(4, 232);
		this.Label17.Name = "Label17";
		this.Label17.Size = new System.Drawing.Size(156, 32);
		this.Label17.TabIndex = 41;
		this.Label17.Text = "Mirror Oculus Home";
		this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboMirrorHome.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboMirrorHome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboMirrorHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMirrorHome.FormattingEnabled = true;
		this.ComboMirrorHome.Items.AddRange(new object[2] { "Enabled", "Disabled" });
		this.ComboMirrorHome.Location = new System.Drawing.Point(167, 235);
		this.ComboMirrorHome.Name = "ComboMirrorHome";
		this.ComboMirrorHome.Size = new System.Drawing.Size(116, 23);
		this.ComboMirrorHome.TabIndex = 42;
		this.Label16.AutoSize = true;
		this.Label16.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label16.Location = new System.Drawing.Point(4, 199);
		this.Label16.Name = "Label16";
		this.Label16.Size = new System.Drawing.Size(156, 32);
		this.Label16.TabIndex = 36;
		this.Label16.Text = "Oculus Homeless";
		this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.BtnHomless.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.BtnHomless.Enabled = false;
		this.BtnHomless.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnHomless.Location = new System.Drawing.Point(290, 202);
		this.BtnHomless.Name = "BtnHomless";
		this.BtnHomless.Size = new System.Drawing.Size(59, 26);
		this.BtnHomless.TabIndex = 38;
		this.BtnHomless.Text = "Edit";
		this.BtnHomless.UseVisualStyleBackColor = true;
		this.Label15.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label15.Location = new System.Drawing.Point(4, 133);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(156, 32);
		this.Label15.TabIndex = 32;
		this.Label15.Text = "FoV Multiplier";
		this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label35.AutoSize = true;
		this.Label35.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label35.Location = new System.Drawing.Point(4, 100);
		this.Label35.Name = "Label35";
		this.Label35.Size = new System.Drawing.Size(156, 32);
		this.Label35.TabIndex = 44;
		this.Label35.Text = "Adaptive GPU Scaling";
		this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboVisualHUD.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboVisualHUD.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboVisualHUD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboVisualHUD.DropDownWidth = 180;
		this.ComboVisualHUD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboVisualHUD.FormattingEnabled = true;
		this.ComboVisualHUD.Items.AddRange(new object[8] { "None", "Pixel Density", "Performance", "ASW Status", "Latency Timing", "Application Render Timing", "Compositor Render Timing", "Version Info" });
		this.ComboVisualHUD.Location = new System.Drawing.Point(167, 270);
		this.ComboVisualHUD.Name = "ComboVisualHUD";
		this.ComboVisualHUD.Size = new System.Drawing.Size(116, 23);
		this.ComboVisualHUD.TabIndex = 40;
		this.ComboBox5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox5.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox5.FormattingEnabled = true;
		this.ComboBox5.Items.AddRange(new object[2] { "On", "Off" });
		this.ComboBox5.Location = new System.Drawing.Point(167, 105);
		this.ComboBox5.Name = "ComboBox5";
		this.ComboBox5.Size = new System.Drawing.Size(116, 23);
		this.ComboBox5.TabIndex = 45;
		this.ComboBox5.TabStop = false;
		this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.SplitContainer1.Location = new System.Drawing.Point(167, 136);
		this.SplitContainer1.Name = "SplitContainer1";
		this.SplitContainer1.Panel1.Controls.Add(this.NumericFOVh);
		this.SplitContainer1.Panel2.Controls.Add(this.NumericFOVv);
		this.SplitContainer1.Size = new System.Drawing.Size(116, 26);
		this.SplitContainer1.SplitterDistance = 53;
		this.SplitContainer1.TabIndex = 46;
		this.NumericFOVh.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.NumericFOVh.DecimalPlaces = 2;
		this.NumericFOVh.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		this.NumericFOVh.Location = new System.Drawing.Point(1, 3);
		this.NumericFOVh.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.NumericFOVh.Name = "NumericFOVh";
		this.NumericFOVh.Size = new System.Drawing.Size(52, 21);
		this.NumericFOVh.TabIndex = 33;
		this.NumericFOVv.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.NumericFOVv.DecimalPlaces = 2;
		this.NumericFOVv.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		this.NumericFOVv.Location = new System.Drawing.Point(2, 3);
		this.NumericFOVv.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.NumericFOVv.Name = "NumericFOVv";
		this.NumericFOVv.Size = new System.Drawing.Size(54, 21);
		this.NumericFOVv.TabIndex = 34;
		this.ComboOVRPrio.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboOVRPrio.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboOVRPrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboOVRPrio.DropDownWidth = 180;
		this.ComboOVRPrio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboOVRPrio.FormattingEnabled = true;
		this.ComboOVRPrio.Items.AddRange(new object[4] { "Normal", "Above normal", "High", "Realtime" });
		this.ComboOVRPrio.Location = new System.Drawing.Point(167, 303);
		this.ComboOVRPrio.Name = "ComboOVRPrio";
		this.ComboOVRPrio.Size = new System.Drawing.Size(116, 23);
		this.ComboOVRPrio.TabIndex = 48;
		this.Label33.AutoSize = true;
		this.Label33.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label33.Location = new System.Drawing.Point(4, 331);
		this.Label33.Name = "Label33";
		this.Label33.Size = new System.Drawing.Size(156, 32);
		this.Label33.TabIndex = 49;
		this.Label33.Text = "Force MipMap On Layers";
		this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboBox8.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox8.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox8.FormattingEnabled = true;
		this.ComboBox8.Items.AddRange(new object[2] { "True", "False" });
		this.ComboBox8.Location = new System.Drawing.Point(167, 334);
		this.ComboBox8.Name = "ComboBox8";
		this.ComboBox8.Size = new System.Drawing.Size(116, 24);
		this.ComboBox8.TabIndex = 50;
		this.ComboBox9.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox9.FormattingEnabled = true;
		this.ComboBox9.Items.AddRange(new object[21]
		{
			"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
			"10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
			"20"
		});
		this.ComboBox9.Location = new System.Drawing.Point(167, 367);
		this.ComboBox9.Name = "ComboBox9";
		this.ComboBox9.Size = new System.Drawing.Size(116, 24);
		this.ComboBox9.TabIndex = 52;
		this.Label37.AutoSize = true;
		this.Label37.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label37.Location = new System.Drawing.Point(4, 364);
		this.Label37.Name = "Label37";
		this.Label37.Size = new System.Drawing.Size(156, 34);
		this.Label37.TabIndex = 51;
		this.Label37.Text = "Offset MipMap On Layers";
		this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.TabPage2.BackColor = System.Drawing.Color.White;
		this.TabPage2.Controls.Add(this.GroupBox1);
		this.TabPage2.Location = new System.Drawing.Point(139, 4);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage2.Size = new System.Drawing.Size(365, 425);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "Tray Tool";
		this.GroupBox1.Controls.Add(this.DbLayoutPanel4);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.GroupBox1.Location = new System.Drawing.Point(3, 3);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(359, 419);
		this.GroupBox1.TabIndex = 11;
		this.GroupBox1.TabStop = false;
		this.DbLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel4.ColumnCount = 2;
		this.DbLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.DbLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191f));
		this.DbLayoutPanel4.Controls.Add(this.CheckStartWindows, 0, 0);
		this.DbLayoutPanel4.Controls.Add(this.CheckStartMin, 0, 1);
		this.DbLayoutPanel4.Controls.Add(this.CheckMinimizeOnX, 0, 4);
		this.DbLayoutPanel4.Controls.Add(this.CheckRiftAudio, 0, 2);
		this.DbLayoutPanel4.Controls.Add(this.CheckBoxAltTab, 0, 3);
		this.DbLayoutPanel4.Controls.Add(this.HotKeysCheckBox, 0, 5);
		this.DbLayoutPanel4.Controls.Add(this.BtnConfigureAudio, 1, 2);
		this.DbLayoutPanel4.Controls.Add(this.Label14, 0, 7);
		this.DbLayoutPanel4.Controls.Add(this.CheckBoxCheckForUpdates, 0, 6);
		this.DbLayoutPanel4.Controls.Add(this.BtnConfigureHotKeys, 1, 5);
		this.DbLayoutPanel4.Controls.Add(this.TrackBar1, 0, 8);
		this.DbLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DbLayoutPanel4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.DbLayoutPanel4.Location = new System.Drawing.Point(3, 17);
		this.DbLayoutPanel4.Name = "DbLayoutPanel4";
		this.DbLayoutPanel4.RowCount = 9;
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.27596f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.08902f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.902077f));
		this.DbLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.91395f));
		this.DbLayoutPanel4.Size = new System.Drawing.Size(353, 399);
		this.DbLayoutPanel4.TabIndex = 12;
		this.CheckStartWindows.AutoSize = true;
		this.CheckStartWindows.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckStartWindows.Location = new System.Drawing.Point(4, 4);
		this.CheckStartWindows.Name = "CheckStartWindows";
		this.CheckStartWindows.Size = new System.Drawing.Size(153, 36);
		this.CheckStartWindows.TabIndex = 4;
		this.CheckStartWindows.TabStop = false;
		this.CheckStartWindows.Text = "Start with Windows";
		this.CheckStartWindows.UseVisualStyleBackColor = true;
		this.CheckStartMin.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckStartMin.Location = new System.Drawing.Point(4, 47);
		this.CheckStartMin.Name = "CheckStartMin";
		this.CheckStartMin.Size = new System.Drawing.Size(153, 36);
		this.CheckStartMin.TabIndex = 5;
		this.CheckStartMin.TabStop = false;
		this.CheckStartMin.Text = "Start minimized";
		this.CheckStartMin.UseVisualStyleBackColor = true;
		this.CheckMinimizeOnX.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckMinimizeOnX.Location = new System.Drawing.Point(4, 176);
		this.CheckMinimizeOnX.Name = "CheckMinimizeOnX";
		this.CheckMinimizeOnX.Size = new System.Drawing.Size(153, 36);
		this.CheckMinimizeOnX.TabIndex = 9;
		this.CheckMinimizeOnX.Text = "Minimize Tool on X";
		this.CheckMinimizeOnX.UseVisualStyleBackColor = true;
		this.CheckBoxAltTab.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckBoxAltTab.Location = new System.Drawing.Point(4, 133);
		this.CheckBoxAltTab.Name = "CheckBoxAltTab";
		this.CheckBoxAltTab.Size = new System.Drawing.Size(153, 36);
		this.CheckBoxAltTab.TabIndex = 6;
		this.CheckBoxAltTab.TabStop = false;
		this.CheckBoxAltTab.Text = "Hide from Alt+Tab";
		this.CheckBoxAltTab.UseVisualStyleBackColor = true;
		this.HotKeysCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
		this.HotKeysCheckBox.Location = new System.Drawing.Point(4, 219);
		this.HotKeysCheckBox.Name = "HotKeysCheckBox";
		this.HotKeysCheckBox.Size = new System.Drawing.Size(153, 36);
		this.HotKeysCheckBox.TabIndex = 27;
		this.HotKeysCheckBox.Text = "Enable HotKeys";
		this.HotKeysCheckBox.UseVisualStyleBackColor = true;
		this.BtnConfigureAudio.Dock = System.Windows.Forms.DockStyle.Fill;
		this.BtnConfigureAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnConfigureAudio.Location = new System.Drawing.Point(164, 90);
		this.BtnConfigureAudio.Name = "BtnConfigureAudio";
		this.BtnConfigureAudio.Size = new System.Drawing.Size(185, 36);
		this.BtnConfigureAudio.TabIndex = 29;
		this.BtnConfigureAudio.Text = "Configure";
		this.BtnConfigureAudio.UseVisualStyleBackColor = true;
		this.Label14.AutoSize = true;
		this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.Label14.Location = new System.Drawing.Point(4, 298);
		this.Label14.Name = "Label14";
		this.Label14.Size = new System.Drawing.Size(153, 33);
		this.Label14.TabIndex = 28;
		this.Label14.Text = "Font Size: ";
		this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.CheckBoxCheckForUpdates.AutoSize = true;
		this.CheckBoxCheckForUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckBoxCheckForUpdates.Location = new System.Drawing.Point(4, 262);
		this.CheckBoxCheckForUpdates.Name = "CheckBoxCheckForUpdates";
		this.CheckBoxCheckForUpdates.Size = new System.Drawing.Size(153, 32);
		this.CheckBoxCheckForUpdates.TabIndex = 30;
		this.CheckBoxCheckForUpdates.Text = "Check for updates on startup";
		this.CheckBoxCheckForUpdates.UseVisualStyleBackColor = true;
		this.BtnConfigureHotKeys.Dock = System.Windows.Forms.DockStyle.Fill;
		this.BtnConfigureHotKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnConfigureHotKeys.Location = new System.Drawing.Point(164, 219);
		this.BtnConfigureHotKeys.Name = "BtnConfigureHotKeys";
		this.BtnConfigureHotKeys.Size = new System.Drawing.Size(185, 36);
		this.BtnConfigureHotKeys.TabIndex = 31;
		this.BtnConfigureHotKeys.Text = "Configure";
		this.BtnConfigureHotKeys.UseVisualStyleBackColor = true;
		this.TrackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TrackBar1.Location = new System.Drawing.Point(4, 335);
		this.TrackBar1.Maximum = 12;
		this.TrackBar1.Minimum = 8;
		this.TrackBar1.Name = "TrackBar1";
		this.TrackBar1.Size = new System.Drawing.Size(153, 60);
		this.TrackBar1.TabIndex = 26;
		this.TrackBar1.Value = 8;
		this.TabPage3.BackColor = System.Drawing.Color.White;
		this.TabPage3.Controls.Add(this.GroupBox2);
		this.TabPage3.Location = new System.Drawing.Point(139, 4);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage3.Size = new System.Drawing.Size(365, 425);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "Power Options";
		this.GroupBox2.Controls.Add(this.DbLayoutPanel5);
		this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox2.Location = new System.Drawing.Point(3, 3);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(359, 419);
		this.GroupBox2.TabIndex = 3;
		this.GroupBox2.TabStop = false;
		this.DbLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel5.ColumnCount = 2;
		this.DbLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.13433f));
		this.DbLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.86567f));
		this.DbLayoutPanel5.Controls.Add(this.ComboApplyPlan, 1, 2);
		this.DbLayoutPanel5.Controls.Add(this.Label4, 0, 3);
		this.DbLayoutPanel5.Controls.Add(this.ComboPowerPlanExit, 1, 1);
		this.DbLayoutPanel5.Controls.Add(this.Label2, 0, 0);
		this.DbLayoutPanel5.Controls.Add(this.ComboPowerPlanStart, 1, 0);
		this.DbLayoutPanel5.Controls.Add(this.Label22, 0, 1);
		this.DbLayoutPanel5.Controls.Add(this.Label3, 0, 2);
		this.DbLayoutPanel5.Controls.Add(this.Label23, 0, 4);
		this.DbLayoutPanel5.Controls.Add(this.CheckSensorPower, 1, 4);
		this.DbLayoutPanel5.Controls.Add(this.ComboUSBsusp, 1, 3);
		this.DbLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DbLayoutPanel5.Location = new System.Drawing.Point(3, 17);
		this.DbLayoutPanel5.Name = "DbLayoutPanel5";
		this.DbLayoutPanel5.RowCount = 5;
		this.DbLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.DbLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.DbLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.DbLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.DbLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667f));
		this.DbLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.DbLayoutPanel5.Size = new System.Drawing.Size(353, 399);
		this.DbLayoutPanel5.TabIndex = 4;
		this.ComboApplyPlan.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboApplyPlan.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboApplyPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboApplyPlan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboApplyPlan.FormattingEnabled = true;
		this.ComboApplyPlan.Items.AddRange(new object[2] { "OTT Start/Exit", "Oculus Home Start/Exit" });
		this.ComboApplyPlan.Location = new System.Drawing.Point(190, 187);
		this.ComboApplyPlan.Name = "ComboApplyPlan";
		this.ComboApplyPlan.Size = new System.Drawing.Size(159, 23);
		this.ComboApplyPlan.TabIndex = 20;
		this.ComboApplyPlan.TabStop = false;
		this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label4.Location = new System.Drawing.Point(4, 238);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(179, 78);
		this.Label4.TabIndex = 18;
		this.Label4.Text = "USB Selective Suspend";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboPowerPlanExit.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboPowerPlanExit.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboPowerPlanExit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboPowerPlanExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboPowerPlanExit.FormattingEnabled = true;
		this.ComboPowerPlanExit.Location = new System.Drawing.Point(190, 108);
		this.ComboPowerPlanExit.Name = "ComboPowerPlanExit";
		this.ComboPowerPlanExit.Size = new System.Drawing.Size(159, 23);
		this.ComboPowerPlanExit.TabIndex = 12;
		this.ComboPowerPlanExit.TabStop = false;
		this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label2.Location = new System.Drawing.Point(4, 1);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(179, 78);
		this.Label2.TabIndex = 6;
		this.Label2.Text = "Set Power Plan on Start";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboPowerPlanStart.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboPowerPlanStart.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboPowerPlanStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboPowerPlanStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboPowerPlanStart.FormattingEnabled = true;
		this.ComboPowerPlanStart.Location = new System.Drawing.Point(190, 28);
		this.ComboPowerPlanStart.Name = "ComboPowerPlanStart";
		this.ComboPowerPlanStart.Size = new System.Drawing.Size(159, 23);
		this.ComboPowerPlanStart.TabIndex = 6;
		this.ComboPowerPlanStart.TabStop = false;
		this.Label22.AutoSize = true;
		this.Label22.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label22.Location = new System.Drawing.Point(4, 80);
		this.Label22.Name = "Label22";
		this.Label22.Size = new System.Drawing.Size(179, 78);
		this.Label22.TabIndex = 14;
		this.Label22.Text = "Set Power Plan on Exit";
		this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label3.AutoSize = true;
		this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label3.Location = new System.Drawing.Point(4, 159);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(179, 78);
		this.Label3.TabIndex = 19;
		this.Label3.Text = "Apply Power Plan on";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label23.AutoSize = true;
		this.Label23.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label23.Location = new System.Drawing.Point(4, 317);
		this.Label23.Name = "Label23";
		this.Label23.Size = new System.Drawing.Size(179, 81);
		this.Label23.TabIndex = 15;
		this.Label23.Text = "Rift Power Management";
		this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.CheckSensorPower.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckSensorPower.Location = new System.Drawing.Point(190, 320);
		this.CheckSensorPower.Name = "CheckSensorPower";
		this.CheckSensorPower.Size = new System.Drawing.Size(159, 75);
		this.CheckSensorPower.TabIndex = 10;
		this.CheckSensorPower.TabStop = false;
		this.CheckSensorPower.Text = "Disable on start";
		this.CheckSensorPower.UseVisualStyleBackColor = true;
		this.ComboUSBsusp.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboUSBsusp.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboUSBsusp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboUSBsusp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboUSBsusp.FormattingEnabled = true;
		this.ComboUSBsusp.Items.AddRange(new object[2] { "Disabled", "Enabled" });
		this.ComboUSBsusp.Location = new System.Drawing.Point(190, 266);
		this.ComboUSBsusp.Name = "ComboUSBsusp";
		this.ComboUSBsusp.Size = new System.Drawing.Size(159, 23);
		this.ComboUSBsusp.TabIndex = 7;
		this.ComboUSBsusp.TabStop = false;
		this.TabPage4.BackColor = System.Drawing.Color.White;
		this.TabPage4.Controls.Add(this.DbLayoutPanel7);
		this.TabPage4.Location = new System.Drawing.Point(139, 4);
		this.TabPage4.Name = "TabPage4";
		this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage4.Size = new System.Drawing.Size(365, 425);
		this.TabPage4.TabIndex = 3;
		this.TabPage4.Text = "Service & Startup";
		this.DbLayoutPanel7.ColumnCount = 1;
		this.DbLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.DbLayoutPanel7.Controls.Add(this.GroupBox6, 0, 1);
		this.DbLayoutPanel7.Controls.Add(this.GroupBox4, 0, 0);
		this.DbLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DbLayoutPanel7.Location = new System.Drawing.Point(3, 3);
		this.DbLayoutPanel7.Name = "DbLayoutPanel7";
		this.DbLayoutPanel7.RowCount = 2;
		this.DbLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.97701f));
		this.DbLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.02299f));
		this.DbLayoutPanel7.Size = new System.Drawing.Size(359, 419);
		this.DbLayoutPanel7.TabIndex = 25;
		this.GroupBox6.Controls.Add(this.DbLayoutPanel8);
		this.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox6.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox6.Location = new System.Drawing.Point(3, 90);
		this.GroupBox6.Name = "GroupBox6";
		this.GroupBox6.Size = new System.Drawing.Size(353, 326);
		this.GroupBox6.TabIndex = 24;
		this.GroupBox6.TabStop = false;
		this.DbLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.DbLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel8.ColumnCount = 1;
		this.DbLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.DbLayoutPanel8.Controls.Add(this.CheckStartService, 0, 0);
		this.DbLayoutPanel8.Controls.Add(this.CheckStopService, 0, 1);
		this.DbLayoutPanel8.Controls.Add(this.CheckSendHomeToTrayOnStart, 0, 9);
		this.DbLayoutPanel8.Controls.Add(this.CheckSendHomeToTray, 0, 8);
		this.DbLayoutPanel8.Controls.Add(this.CheckSpoofCPU, 0, 7);
		this.DbLayoutPanel8.Controls.Add(this.CheckCloseHome, 0, 6);
		this.DbLayoutPanel8.Controls.Add(this.CheckLaunchHomeTool, 0, 5);
		this.DbLayoutPanel8.Controls.Add(this.CheckLaunchHome, 0, 4);
		this.DbLayoutPanel8.Controls.Add(this.CheckRestartSleep, 0, 3);
		this.DbLayoutPanel8.Controls.Add(this.CheckStopServiceHome, 0, 2);
		this.DbLayoutPanel8.Location = new System.Drawing.Point(3, 17);
		this.DbLayoutPanel8.Name = "DbLayoutPanel8";
		this.DbLayoutPanel8.RowCount = 10;
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111f));
		this.DbLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.DbLayoutPanel8.Size = new System.Drawing.Size(330, 300);
		this.DbLayoutPanel8.TabIndex = 12;
		this.CheckStartService.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckStartService.Location = new System.Drawing.Point(4, 4);
		this.CheckStartService.Name = "CheckStartService";
		this.CheckStartService.Size = new System.Drawing.Size(322, 23);
		this.CheckStartService.TabIndex = 17;
		this.CheckStartService.TabStop = false;
		this.CheckStartService.Text = "Start Oculus service when tool starts";
		this.CheckStartService.UseVisualStyleBackColor = true;
		this.CheckStopService.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckStopService.Location = new System.Drawing.Point(4, 34);
		this.CheckStopService.Name = "CheckStopService";
		this.CheckStopService.Size = new System.Drawing.Size(322, 23);
		this.CheckStopService.TabIndex = 18;
		this.CheckStopService.TabStop = false;
		this.CheckStopService.Text = "Stop Oculus service when tool exits";
		this.CheckStopService.UseVisualStyleBackColor = true;
		this.CheckSendHomeToTrayOnStart.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckSendHomeToTrayOnStart.Location = new System.Drawing.Point(4, 274);
		this.CheckSendHomeToTrayOnStart.Name = "CheckSendHomeToTrayOnStart";
		this.CheckSendHomeToTrayOnStart.Size = new System.Drawing.Size(322, 22);
		this.CheckSendHomeToTrayOnStart.TabIndex = 30;
		this.CheckSendHomeToTrayOnStart.TabStop = false;
		this.CheckSendHomeToTrayOnStart.Text = "Send Oculus Home to tray when it starts";
		this.CheckSendHomeToTrayOnStart.UseVisualStyleBackColor = true;
		this.CheckSendHomeToTray.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckSendHomeToTray.Location = new System.Drawing.Point(4, 244);
		this.CheckSendHomeToTray.Name = "CheckSendHomeToTray";
		this.CheckSendHomeToTray.Size = new System.Drawing.Size(322, 23);
		this.CheckSendHomeToTray.TabIndex = 29;
		this.CheckSendHomeToTray.TabStop = false;
		this.CheckSendHomeToTray.Text = "Send Oculus Home to tray when it's minimized";
		this.CheckSendHomeToTray.UseVisualStyleBackColor = true;
		this.CheckCloseHome.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckCloseHome.Location = new System.Drawing.Point(4, 184);
		this.CheckCloseHome.Name = "CheckCloseHome";
		this.CheckCloseHome.Size = new System.Drawing.Size(322, 23);
		this.CheckCloseHome.TabIndex = 21;
		this.CheckCloseHome.TabStop = false;
		this.CheckCloseHome.Text = "Close Oculus Home on tool exit";
		this.CheckCloseHome.UseVisualStyleBackColor = true;
		this.CheckLaunchHomeTool.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckLaunchHomeTool.Location = new System.Drawing.Point(4, 154);
		this.CheckLaunchHomeTool.Name = "CheckLaunchHomeTool";
		this.CheckLaunchHomeTool.Size = new System.Drawing.Size(322, 23);
		this.CheckLaunchHomeTool.TabIndex = 20;
		this.CheckLaunchHomeTool.TabStop = false;
		this.CheckLaunchHomeTool.Text = "Launch Oculus Home on tool start";
		this.CheckLaunchHomeTool.UseVisualStyleBackColor = true;
		this.CheckLaunchHome.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckLaunchHome.Location = new System.Drawing.Point(4, 124);
		this.CheckLaunchHome.Name = "CheckLaunchHome";
		this.CheckLaunchHome.Size = new System.Drawing.Size(322, 23);
		this.CheckLaunchHome.TabIndex = 19;
		this.CheckLaunchHome.TabStop = false;
		this.CheckLaunchHome.Text = "Launch Oculus Home on service start";
		this.CheckLaunchHome.UseVisualStyleBackColor = true;
		this.CheckRestartSleep.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckRestartSleep.Location = new System.Drawing.Point(4, 94);
		this.CheckRestartSleep.Name = "CheckRestartSleep";
		this.CheckRestartSleep.Size = new System.Drawing.Size(322, 23);
		this.CheckRestartSleep.TabIndex = 31;
		this.CheckRestartSleep.Text = "Restart Oculus service when computer wakes up";
		this.CheckRestartSleep.UseVisualStyleBackColor = true;
		this.CheckStopServiceHome.AutoSize = true;
		this.CheckStopServiceHome.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CheckStopServiceHome.Location = new System.Drawing.Point(4, 64);
		this.CheckStopServiceHome.Name = "CheckStopServiceHome";
		this.CheckStopServiceHome.Size = new System.Drawing.Size(322, 23);
		this.CheckStopServiceHome.TabIndex = 32;
		this.CheckStopServiceHome.Text = "Stop Oculus service when Oculus Home is closed";
		this.CheckStopServiceHome.UseVisualStyleBackColor = true;
		this.GroupBox4.Controls.Add(this.DbLayoutPanel6);
		this.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox4.Location = new System.Drawing.Point(3, 3);
		this.GroupBox4.Name = "GroupBox4";
		this.GroupBox4.Size = new System.Drawing.Size(353, 81);
		this.GroupBox4.TabIndex = 11;
		this.GroupBox4.TabStop = false;
		this.DbLayoutPanel6.ColumnCount = 5;
		this.DbLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.89933f));
		this.DbLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.11409f));
		this.DbLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.10738f));
		this.DbLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.43624f));
		this.DbLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.10738f));
		this.DbLayoutPanel6.Controls.Add(this.ButtonRestartOVR, 4, 0);
		this.DbLayoutPanel6.Controls.Add(this.LabelServiceStatus, 1, 0);
		this.DbLayoutPanel6.Controls.Add(this.ButtonStartOVR, 2, 0);
		this.DbLayoutPanel6.Controls.Add(this.Label11, 0, 0);
		this.DbLayoutPanel6.Controls.Add(this.ButtonStopOVR, 3, 0);
		this.DbLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DbLayoutPanel6.Location = new System.Drawing.Point(3, 17);
		this.DbLayoutPanel6.Name = "DbLayoutPanel6";
		this.DbLayoutPanel6.RowCount = 1;
		this.DbLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.DbLayoutPanel6.Size = new System.Drawing.Size(347, 61);
		this.DbLayoutPanel6.TabIndex = 31;
		this.LabelServiceStatus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.LabelServiceStatus.AutoSize = true;
		this.LabelServiceStatus.Location = new System.Drawing.Point(124, 23);
		this.LabelServiceStatus.Name = "LabelServiceStatus";
		this.LabelServiceStatus.Size = new System.Drawing.Size(53, 15);
		this.LabelServiceStatus.TabIndex = 14;
		this.LabelServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label11.Location = new System.Drawing.Point(3, 0);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(115, 61);
		this.Label11.TabIndex = 25;
		this.Label11.Text = "Oculus Service: ";
		this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.TabPage5.BackColor = System.Drawing.Color.White;
		this.TabPage5.Controls.Add(this.GroupBox3);
		this.TabPage5.Location = new System.Drawing.Point(139, 4);
		this.TabPage5.Name = "TabPage5";
		this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage5.Size = new System.Drawing.Size(365, 425);
		this.TabPage5.TabIndex = 4;
		this.TabPage5.Text = "Log Window";
		this.GroupBox3.Controls.Add(this.ListBox1);
		this.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox3.Location = new System.Drawing.Point(3, 3);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(359, 419);
		this.GroupBox3.TabIndex = 9;
		this.GroupBox3.TabStop = false;
		this.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.ListBox1.ContextMenuStrip = this.ContextMenuStrip2;
		this.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ListBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ListBox1.FormattingEnabled = true;
		this.ListBox1.HorizontalScrollbar = true;
		this.ListBox1.ItemHeight = 15;
		this.ListBox1.Location = new System.Drawing.Point(3, 17);
		this.ListBox1.Name = "ListBox1";
		this.ListBox1.Size = new System.Drawing.Size(353, 399);
		this.ListBox1.TabIndex = 8;
		this.TabPage7.BackColor = System.Drawing.Color.White;
		this.TabPage7.Controls.Add(this.GroupBox7);
		this.TabPage7.Location = new System.Drawing.Point(139, 4);
		this.TabPage7.Name = "TabPage7";
		this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage7.Size = new System.Drawing.Size(365, 425);
		this.TabPage7.TabIndex = 6;
		this.TabPage7.Text = "Advanced";
		this.GroupBox7.Controls.Add(this.DbLayoutPanel1);
		this.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox7.Location = new System.Drawing.Point(3, 3);
		this.GroupBox7.Name = "GroupBox7";
		this.GroupBox7.Size = new System.Drawing.Size(359, 419);
		this.GroupBox7.TabIndex = 10;
		this.GroupBox7.TabStop = false;
		this.DbLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.DbLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel1.ColumnCount = 2;
		this.DbLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.DbLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.DbLayoutPanel1.Controls.Add(this.BtnLibrary, 1, 7);
		this.DbLayoutPanel1.Controls.Add(this.Label29, 0, 7);
		this.DbLayoutPanel1.Controls.Add(this.CheckLocalDebug, 1, 0);
		this.DbLayoutPanel1.Controls.Add(this.CheckStartWatcher, 1, 1);
		this.DbLayoutPanel1.Controls.Add(this.Label13, 0, 0);
		this.DbLayoutPanel1.Controls.Add(this.Label18, 0, 1);
		this.DbLayoutPanel1.Controls.Add(this.Button4, 1, 2);
		this.DbLayoutPanel1.Controls.Add(this.BtnRemoveAllProfiles, 1, 3);
		this.DbLayoutPanel1.Controls.Add(this.Button1, 1, 4);
		this.DbLayoutPanel1.Controls.Add(this.Button5, 1, 5);
		this.DbLayoutPanel1.Controls.Add(this.BtnSteamImport, 1, 6);
		this.DbLayoutPanel1.Controls.Add(this.Label24, 0, 2);
		this.DbLayoutPanel1.Controls.Add(this.Label25, 0, 3);
		this.DbLayoutPanel1.Controls.Add(this.Label26, 0, 4);
		this.DbLayoutPanel1.Controls.Add(this.Label27, 0, 5);
		this.DbLayoutPanel1.Controls.Add(this.Label28, 0, 6);
		this.DbLayoutPanel1.Location = new System.Drawing.Point(6, 17);
		this.DbLayoutPanel1.Name = "DbLayoutPanel1";
		this.DbLayoutPanel1.RowCount = 8;
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.27053f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.27053f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.27053f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.27053f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.27053f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.1401f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.52657f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.98067f));
		this.DbLayoutPanel1.Size = new System.Drawing.Size(326, 396);
		this.DbLayoutPanel1.TabIndex = 0;
		this.BtnLibrary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.BtnLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnLibrary.Location = new System.Drawing.Point(166, 348);
		this.BtnLibrary.Name = "BtnLibrary";
		this.BtnLibrary.Size = new System.Drawing.Size(156, 44);
		this.BtnLibrary.TabIndex = 29;
		this.BtnLibrary.TabStop = false;
		this.BtnLibrary.Text = "View && Edit";
		this.BtnLibrary.UseVisualStyleBackColor = true;
		this.BtnSteamImport.Dock = System.Windows.Forms.DockStyle.Fill;
		this.BtnSteamImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnSteamImport.Location = new System.Drawing.Point(166, 295);
		this.BtnSteamImport.Name = "BtnSteamImport";
		this.BtnSteamImport.Size = new System.Drawing.Size(156, 46);
		this.BtnSteamImport.TabIndex = 30;
		this.BtnSteamImport.TabStop = false;
		this.BtnSteamImport.Text = "View && Import";
		this.BtnSteamImport.UseVisualStyleBackColor = true;
		this.Label24.AutoSize = true;
		this.Label24.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label24.Location = new System.Drawing.Point(4, 97);
		this.Label24.Name = "Label24";
		this.Label24.Size = new System.Drawing.Size(155, 47);
		this.Label24.TabIndex = 33;
		this.Label24.Text = "Settings";
		this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label25.AutoSize = true;
		this.Label25.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label25.Location = new System.Drawing.Point(4, 145);
		this.Label25.Name = "Label25";
		this.Label25.Size = new System.Drawing.Size(155, 47);
		this.Label25.TabIndex = 34;
		this.Label25.Text = "Profiles";
		this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label26.AutoSize = true;
		this.Label26.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label26.Location = new System.Drawing.Point(4, 193);
		this.Label26.Name = "Label26";
		this.Label26.Size = new System.Drawing.Size(155, 47);
		this.Label26.TabIndex = 35;
		this.Label26.Text = "Updates";
		this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label27.AutoSize = true;
		this.Label27.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label27.Location = new System.Drawing.Point(4, 241);
		this.Label27.Name = "Label27";
		this.Label27.Size = new System.Drawing.Size(155, 50);
		this.Label27.TabIndex = 36;
		this.Label27.Text = "Debug";
		this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label28.AutoSize = true;
		this.Label28.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label28.Location = new System.Drawing.Point(4, 292);
		this.Label28.Name = "Label28";
		this.Label28.Size = new System.Drawing.Size(155, 52);
		this.Label28.TabIndex = 37;
		this.Label28.Text = "Steam Library";
		this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.TabPage8.BackColor = System.Drawing.Color.White;
		this.TabPage8.Controls.Add(this.GroupBox5);
		this.TabPage8.Location = new System.Drawing.Point(139, 4);
		this.TabPage8.Name = "TabPage8";
		this.TabPage8.Size = new System.Drawing.Size(365, 425);
		this.TabPage8.TabIndex = 7;
		this.TabPage8.Text = "Quest Link";
		this.GroupBox5.Controls.Add(this.PictureBox7);
		this.GroupBox5.Controls.Add(this.PictureBox6);
		this.GroupBox5.Controls.Add(this.PictureBox5);
		this.GroupBox5.Controls.Add(this.PictureBox4);
		this.GroupBox5.Controls.Add(this.PictureBox3);
		this.GroupBox5.Controls.Add(this.Button3);
		this.GroupBox5.Controls.Add(this.Button12);
		this.GroupBox5.Controls.Add(this.DbLayoutPanel3);
		this.GroupBox5.Controls.Add(this.Button11);
		this.GroupBox5.Controls.Add(this.Button10);
		this.GroupBox5.Controls.Add(this.Label10);
		this.GroupBox5.Location = new System.Drawing.Point(3, 3);
		this.GroupBox5.Name = "GroupBox5";
		this.GroupBox5.Size = new System.Drawing.Size(342, 414);
		this.GroupBox5.TabIndex = 10;
		this.GroupBox5.TabStop = false;
		this.Button3.Enabled = false;
		this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button3.Location = new System.Drawing.Point(9, 383);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(56, 25);
		this.Button3.TabIndex = 14;
		this.Button3.Text = "Delete";
		this.Button3.UseVisualStyleBackColor = true;
		this.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button12.Location = new System.Drawing.Point(280, 383);
		this.Button12.Name = "Button12";
		this.Button12.Size = new System.Drawing.Size(56, 25);
		this.Button12.TabIndex = 13;
		this.Button12.Text = "Save";
		this.Button12.UseVisualStyleBackColor = true;
		this.DbLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel3.ColumnCount = 2;
		this.DbLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333f));
		this.DbLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667f));
		this.DbLayoutPanel3.Controls.Add(this.ComboBox11, 1, 5);
		this.DbLayoutPanel3.Controls.Add(this.ComboBox6, 1, 3);
		this.DbLayoutPanel3.Controls.Add(this.Label32, 0, 0);
		this.DbLayoutPanel3.Controls.Add(this.Label30, 0, 1);
		this.DbLayoutPanel3.Controls.Add(this.Label31, 0, 2);
		this.DbLayoutPanel3.Controls.Add(this.ComboBox4, 1, 0);
		this.DbLayoutPanel3.Controls.Add(this.ComboBox3, 1, 2);
		this.DbLayoutPanel3.Controls.Add(this.ComboBox2, 1, 1);
		this.DbLayoutPanel3.Controls.Add(this.Label36, 0, 3);
		this.DbLayoutPanel3.Controls.Add(this.Label38, 0, 4);
		this.DbLayoutPanel3.Controls.Add(this.ComboBox10, 1, 4);
		this.DbLayoutPanel3.Controls.Add(this.Label21, 0, 7);
		this.DbLayoutPanel3.Controls.Add(this.Button6, 1, 7);
		this.DbLayoutPanel3.Controls.Add(this.Label20, 0, 6);
		this.DbLayoutPanel3.Controls.Add(this.ComboBox7, 1, 6);
		this.DbLayoutPanel3.Controls.Add(this.Label39, 0, 5);
		this.DbLayoutPanel3.Location = new System.Drawing.Point(12, 92);
		this.DbLayoutPanel3.Name = "DbLayoutPanel3";
		this.DbLayoutPanel3.RowCount = 8;
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5f));
		this.DbLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.DbLayoutPanel3.Size = new System.Drawing.Size(296, 268);
		this.DbLayoutPanel3.TabIndex = 12;
		this.ComboBox11.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox11.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox11.FormattingEnabled = true;
		this.ComboBox11.Items.AddRange(new object[18]
		{
			"0", "150", "200", "250", "300", "350", "400", "450", "500", "550",
			"600", "650", "700", "750", "800", "850", "900", "960"
		});
		this.ComboBox11.Location = new System.Drawing.Point(175, 169);
		this.ComboBox11.MaxLength = 4;
		this.ComboBox11.Name = "ComboBox11";
		this.ComboBox11.Size = new System.Drawing.Size(117, 24);
		this.ComboBox11.TabIndex = 18;
		this.ComboBox6.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox6.FormattingEnabled = true;
		this.ComboBox6.Items.AddRange(new object[18]
		{
			"0", "150", "200", "250", "300", "350", "400", "450", "500", "550",
			"600", "650", "700", "750", "800", "850", "900", "960"
		});
		this.ComboBox6.Location = new System.Drawing.Point(175, 103);
		this.ComboBox6.MaxLength = 4;
		this.ComboBox6.Name = "ComboBox6";
		this.ComboBox6.Size = new System.Drawing.Size(117, 24);
		this.ComboBox6.TabIndex = 10;
		this.Label32.AutoSize = true;
		this.Label32.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label32.Location = new System.Drawing.Point(4, 1);
		this.Label32.Name = "Label32";
		this.Label32.Size = new System.Drawing.Size(164, 32);
		this.Label32.TabIndex = 5;
		this.Label32.Text = "Presets";
		this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label30.AutoSize = true;
		this.Label30.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label30.Location = new System.Drawing.Point(4, 34);
		this.Label30.Name = "Label30";
		this.Label30.Size = new System.Drawing.Size(164, 32);
		this.Label30.TabIndex = 1;
		this.Label30.Text = "Distortion Curvature:";
		this.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label31.AutoSize = true;
		this.Label31.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label31.Location = new System.Drawing.Point(4, 67);
		this.Label31.Name = "Label31";
		this.Label31.Size = new System.Drawing.Size(164, 32);
		this.Label31.TabIndex = 2;
		this.Label31.Text = "Encode Resolution";
		this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboBox4.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox4.Enabled = false;
		this.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox4.FormattingEnabled = true;
		this.ComboBox4.Items.AddRange(new object[1] { "Disabled" });
		this.ComboBox4.Location = new System.Drawing.Point(175, 4);
		this.ComboBox4.Name = "ComboBox4";
		this.ComboBox4.Size = new System.Drawing.Size(117, 24);
		this.ComboBox4.TabIndex = 6;
		this.ComboBox3.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox3.FormattingEnabled = true;
		this.ComboBox3.Items.AddRange(new object[6] { "2016", "2352", "2912", "3648", "3960", "4040" });
		this.ComboBox3.Location = new System.Drawing.Point(175, 70);
		this.ComboBox3.MaxLength = 4;
		this.ComboBox3.Name = "ComboBox3";
		this.ComboBox3.Size = new System.Drawing.Size(117, 24);
		this.ComboBox3.TabIndex = 4;
		this.ComboBox2.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox2.FormattingEnabled = true;
		this.ComboBox2.Items.AddRange(new object[3] { "Default", "High", "Low" });
		this.ComboBox2.Location = new System.Drawing.Point(175, 37);
		this.ComboBox2.Name = "ComboBox2";
		this.ComboBox2.Size = new System.Drawing.Size(117, 24);
		this.ComboBox2.TabIndex = 3;
		this.Label36.AutoSize = true;
		this.Label36.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label36.Location = new System.Drawing.Point(4, 100);
		this.Label36.Name = "Label36";
		this.Label36.Size = new System.Drawing.Size(164, 32);
		this.Label36.TabIndex = 9;
		this.Label36.Text = "Encode Bitrate";
		this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label38.AutoSize = true;
		this.Label38.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label38.Location = new System.Drawing.Point(4, 133);
		this.Label38.Name = "Label38";
		this.Label38.Size = new System.Drawing.Size(164, 32);
		this.Label38.TabIndex = 15;
		this.Label38.Text = "Encode Dynamic Bitrate";
		this.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboBox10.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox10.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox10.FormattingEnabled = true;
		this.ComboBox10.Items.AddRange(new object[3] { "Default", "Enabled", "Disabled" });
		this.ComboBox10.Location = new System.Drawing.Point(175, 136);
		this.ComboBox10.Name = "ComboBox10";
		this.ComboBox10.Size = new System.Drawing.Size(117, 24);
		this.ComboBox10.TabIndex = 16;
		this.Label21.AutoSize = true;
		this.Label21.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label21.Location = new System.Drawing.Point(4, 232);
		this.Label21.Name = "Label21";
		this.Label21.Size = new System.Drawing.Size(164, 35);
		this.Label21.TabIndex = 13;
		this.Label21.Text = "Permanent AirLink";
		this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Button6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button6.Location = new System.Drawing.Point(175, 235);
		this.Button6.Name = "Button6";
		this.Button6.Size = new System.Drawing.Size(117, 29);
		this.Button6.TabIndex = 14;
		this.Button6.Text = "Enable";
		this.Button6.UseVisualStyleBackColor = true;
		this.Label20.AutoSize = true;
		this.Label20.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label20.Location = new System.Drawing.Point(4, 199);
		this.Label20.Name = "Label20";
		this.Label20.Size = new System.Drawing.Size(164, 32);
		this.Label20.TabIndex = 11;
		this.Label20.Text = "Sharpening";
		this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboBox7.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox7.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox7.FormattingEnabled = true;
		this.ComboBox7.Items.AddRange(new object[3] { "Auto", "Disabled", "Enabled" });
		this.ComboBox7.Location = new System.Drawing.Point(175, 202);
		this.ComboBox7.Name = "ComboBox7";
		this.ComboBox7.Size = new System.Drawing.Size(117, 24);
		this.ComboBox7.TabIndex = 12;
		this.Label39.AutoSize = true;
		this.Label39.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label39.Location = new System.Drawing.Point(4, 166);
		this.Label39.Name = "Label39";
		this.Label39.Size = new System.Drawing.Size(164, 32);
		this.Label39.TabIndex = 17;
		this.Label39.Text = "Dynamic Bitrate Max";
		this.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button10.Location = new System.Drawing.Point(123, 383);
		this.Button10.Name = "Button10";
		this.Button10.Size = new System.Drawing.Size(146, 25);
		this.Button10.TabIndex = 10;
		this.Button10.Text = "Save && Restart Service";
		this.Button10.UseVisualStyleBackColor = true;
		this.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label10.Location = new System.Drawing.Point(9, 17);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(324, 72);
		this.Label10.TabIndex = 0;
		this.Label10.Text = "These settings are for the Oculus Quest/Quest 2 when using Link. You can change the Preset values to experiment. Higher settings require more GPU power and may cause a significant performance drop.";
		this.TabPage6.BackColor = System.Drawing.Color.White;
		this.TabPage6.Controls.Add(this.GroupBox9);
		this.TabPage6.Location = new System.Drawing.Point(139, 4);
		this.TabPage6.Name = "TabPage6";
		this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage6.Size = new System.Drawing.Size(365, 425);
		this.TabPage6.TabIndex = 5;
		this.TabPage6.Text = "Update Found!";
		this.GroupBox9.Controls.Add(this.LabelDownloadStatus);
		this.GroupBox9.Controls.Add(this.LabelVer);
		this.GroupBox9.Controls.Add(this.Label12);
		this.GroupBox9.Controls.Add(this.Button9);
		this.GroupBox9.Controls.Add(this.Button8);
		this.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox9.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox9.Location = new System.Drawing.Point(3, 3);
		this.GroupBox9.Name = "GroupBox9";
		this.GroupBox9.Size = new System.Drawing.Size(359, 419);
		this.GroupBox9.TabIndex = 7;
		this.GroupBox9.TabStop = false;
		this.LabelDownloadStatus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.LabelDownloadStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelDownloadStatus.Location = new System.Drawing.Point(6, 244);
		this.LabelDownloadStatus.Name = "LabelDownloadStatus";
		this.LabelDownloadStatus.Size = new System.Drawing.Size(347, 16);
		this.LabelDownloadStatus.TabIndex = 5;
		this.LabelDownloadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.LabelVer.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.LabelVer.Location = new System.Drawing.Point(6, 140);
		this.LabelVer.Name = "LabelVer";
		this.LabelVer.Size = new System.Drawing.Size(321, 19);
		this.LabelVer.TabIndex = 4;
		this.LabelVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label12.Location = new System.Drawing.Point(6, 110);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(347, 16);
		this.Label12.TabIndex = 3;
		this.Label12.Text = "Looks like we have an update for you!";
		this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button9.Location = new System.Drawing.Point(177, 152);
		this.Button9.Name = "Button9";
		this.Button9.Size = new System.Drawing.Size(146, 31);
		this.Button9.TabIndex = 1;
		this.Button9.Text = "Download Only";
		this.Button9.UseVisualStyleBackColor = true;
		this.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button8.Location = new System.Drawing.Point(15, 152);
		this.Button8.Name = "Button8";
		this.Button8.Size = new System.Drawing.Size(146, 31);
		this.Button8.TabIndex = 0;
		this.Button8.Text = "Download and Install";
		this.Button8.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(508, 433);
		base.Controls.Add(this.PictureBox2);
		base.Controls.Add(this.PictureBox1);
		base.Controls.Add(this.Label8);
		base.Controls.Add(this.DotNetBarTabcontrol1);
		this.DoubleBuffered = true;
		this.ForeColor = System.Drawing.Color.DodgerBlue;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		this.MinimumSize = new System.Drawing.Size(524, 472);
		base.Name = "FrmMain";
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Oculus Tray Tool";
		this.ContextMenuStrip1.ResumeLayout(false);
		this.ContextMenuStrip2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox3).EndInit();
		this.DotNetBarTabcontrol1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.GroupBox14.ResumeLayout(false);
		this.DbLayoutPanel2.ResumeLayout(false);
		this.DbLayoutPanel2.PerformLayout();
		this.SplitContainer1.Panel1.ResumeLayout(false);
		this.SplitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
		this.SplitContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.NumericFOVh).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericFOVv).EndInit();
		this.TabPage2.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.DbLayoutPanel4.ResumeLayout(false);
		this.DbLayoutPanel4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.TrackBar1).EndInit();
		this.TabPage3.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.DbLayoutPanel5.ResumeLayout(false);
		this.DbLayoutPanel5.PerformLayout();
		this.TabPage4.ResumeLayout(false);
		this.DbLayoutPanel7.ResumeLayout(false);
		this.GroupBox6.ResumeLayout(false);
		this.DbLayoutPanel8.ResumeLayout(false);
		this.DbLayoutPanel8.PerformLayout();
		this.GroupBox4.ResumeLayout(false);
		this.DbLayoutPanel6.ResumeLayout(false);
		this.DbLayoutPanel6.PerformLayout();
		this.TabPage5.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.TabPage7.ResumeLayout(false);
		this.GroupBox7.ResumeLayout(false);
		this.DbLayoutPanel1.ResumeLayout(false);
		this.DbLayoutPanel1.PerformLayout();
		this.TabPage8.ResumeLayout(false);
		this.GroupBox5.ResumeLayout(false);
		this.DbLayoutPanel3.ResumeLayout(false);
		this.DbLayoutPanel3.PerformLayout();
		this.TabPage6.ResumeLayout(false);
		this.GroupBox9.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
