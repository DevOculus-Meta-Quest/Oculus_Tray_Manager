// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.FrmMain
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using System.Speech.Recognition;
using static OculusTrayTool.Interaction;
using System.Timers;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.MyNameSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Runtime.CompilerServices;
using System.Management;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Drawing;
using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.Win32;


#nullable disable
namespace OculusTrayTool
{
  public partial class FrmMain : Form
  {
    public static FrmMain fmain; // Restoration
    private System.Windows.Forms.Timer _OculusHomeWatcher; // Restoration
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
    private string vrManifestFileName;
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
    public bool StartingUp; // Added missing field
    public string SteamPath;
    public List<string> OculusSoftwarePaths;
    public TabPage UpdateTab;
    public Dictionary<string, TabPage> colRemovedTabs = new Dictionary<string, TabPage>();
    public string steamvr;
    public string OculusAppVersion;
    private string appName;
    public string runningapp_displayname;
    private System.Windows.Forms.Timer Hometimer;
    public System.Timers.Timer pTimer;
    public bool ManualStart;
    private bool restartInDBG;
    public List<string> ignoredApps;
    public List<string> includedApps; // Added missing field
    public List<string> voiceProfileNames;
    public bool ovrDown;
    public string Update_URL;
    public string UpdateTest_URL;
    public bool voiceSettingsLoaded;
    public System.Timers.Timer _Home2Timer;
    public bool restartHome;
    public System.Timers.Timer mirrorTimer;
    public List<string> AswToggle;
    public System.Windows.Forms.Timer _NotificationTimer;
    private System.Timers.Timer cpuTimer;
    private System.Timers.Timer aswTimer;
    private BackgroundWorker AppWatchWorker;
    public Dictionary<string, string> AllAppsList;
    private bool NoProfileFound;
    private int numLogMessages;
    public string runningAppExe;
    public int pid;
    public bool HomeIsMirrored;
    public Dictionary<string, string> FuncToKeyDictionary;
    private List<string> NextASW;
    private int CurrentASW;
    private List<string> NextHUD;
    private int CurrentHUD;
    public bool isCopy;
    private string DSep;
    private IContainer components;

    private ManagementEventWatcher _Watcher;
    private ManagementEventWatcher _MinimizeHomeWatcher;
    private KeyboardHook _kbHook;
    private CheckBox _CheckStopServiceHome;
    // Backing fields for properties with event logic
    private CheckBox _CheckLocalDebug;
    private ComboBox _ComboSSstart;
    private Button _Button1, _Button2, _Button4, _Button5, _Button11, _BtnProfiles, _BtnHomless, _BtnRemoveAllProfiles, _BtnVoice, _ButtonRestartOVR, _ButtonStartOVR, _ButtonStopOVR, _Button10, _Button12, _Button3, _Button6, _Button9, _Button8, _BtnSteamImport, _BtnConfigureHotKeys, _BtnConfigureAudio, _BtnLibrary;
    private CheckBox _CheckRiftAudio, _CheckSpoofCPU, _CheckStartWatcher, _CheckMinimizeOnX, _CheckStartWindows, _CheckStartMin, _CheckBoxAltTab, _HotKeysCheckBox, _CheckSensorPower, _CheckLaunchHomeTool, _CheckCloseHome, _CheckSendHomeToTray, _CheckSendHomeToTrayOnStart, _CheckBoxCheckForUpdates, _CheckRestartSleep;
    private CheckBox _CheckStartService, _CheckLaunchHome, _CheckStopService;
    private NotifyIcon _NotifyIcon1;
    private NotifyIcon _NotifyIcon3;
    private DotNetBarTabcontrol _DotNetBarTabcontrol1;
    private TrackBar _TrackBar1;
    private System.Windows.Forms.Timer _HometoTrayTimer;
    private System.Windows.Forms.Timer _PowerPlanTimer;
    private System.Windows.Forms.Timer _UpdateTimer;
    private ComboBox _ComboBox1, _ComboBox2, _ComboBox3, _ComboBox4, _ComboBox5, _ComboBox6, _ComboBox7, _ComboBox8, _ComboBox9, _ComboBox10, _ComboBox11, _ComboMirrorHome, _ComboVisualHUD, _ComboOVRPrio, _ComboHomless, _ComboVoice, _ComboUSBsusp, _ComboPowerPlanStart, _ComboPowerPlanExit, _ComboApplyPlan;
    private Label _Label5, _Label6, _Label7, _Label8, _Label9, _Label13, _Label15, _Label16, _Label17, _Label18, _Label19, _Label29, _Label33, _Label35, _Label36, _Label37, _Label38, _Label39, _Label10, _Label31, _Label30, _Label32, _Label2, _Label22, _Label3, _Label23, _Label4, _LabelVer, _Label12, _LabelDownloadStatus, _Label14, _Label1, _Label11, _Label20, _Label21, _Label34, _Label24, _Label25, _Label26, _Label27, _Label28;
    private PictureBox _PictureBox1, _PictureBox2, _PictureBox3, _PictureBox5, _PictureBox6, _PictureBox4, _PictureBox7, _PictureBox8;
    private ToolStripMenuItem _OpenLogToolStripMenuItem, _ClearLogToolStripMenuItem, _ToolStripMenuItem1, _ToolStripMenuItem2, _ToolStripMenuItem3, _ToolStripMenuItem4, _ToolStripMenuShowHome, _ToolStripStartOVR, _ToolStripStopOVR, _ToolStripRestartOVR;
    private ContextMenuStrip _ContextMenuStrip1, _ContextMenuStrip2;
    private ToolStripSeparator _ToolStripSeparator1, _ToolStripSeparator2;

    public virtual ManagementEventWatcher Watcher
    {
      get => this._Watcher;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventArrivedEventHandler arrivedEventHandler = new EventArrivedEventHandler(this.Watcher_EventArrived);
        ManagementEventWatcher watcher1 = this._Watcher;
        if (watcher1 != null)
          watcher1.EventArrived -= arrivedEventHandler;
        this._Watcher = value;
        ManagementEventWatcher watcher2 = this._Watcher;
        if (watcher2 == null)
          return;
        watcher2.EventArrived += arrivedEventHandler;
      }
    }
    
    internal virtual CheckBox CheckStartWithWindows
    {
        get => this._CheckStartWindows;
        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            this._CheckStartWindows = value;
            // Add event handler logic if needed, or simple assignment
            if (_CheckStartWindows != null) {
               _CheckStartWindows.CheckedChanged += CheckStartWindows_CheckedChanged;
            }
        }
    }

    internal virtual System.Windows.Forms.Timer NotificationTimer
    {
      get => this._NotificationTimer;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.NotificationTimer_Tick);
        System.Windows.Forms.Timer notificationTimer1 = this._NotificationTimer;
        if (notificationTimer1 != null)
          notificationTimer1.Tick -= eventHandler;
        this._NotificationTimer = value;
        System.Windows.Forms.Timer notificationTimer2 = this._NotificationTimer;
        if (notificationTimer2 == null)
          return;
        notificationTimer2.Tick += eventHandler;
      }
    }

    public virtual ManagementEventWatcher MinimizeHomeWatcher
    {
      get => this._MinimizeHomeWatcher;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventArrivedEventHandler arrivedEventHandler = new EventArrivedEventHandler(this.MinimizeHomeWatcher_EventArrived);
        ManagementEventWatcher minimizeHomeWatcher1 = this._MinimizeHomeWatcher;
        if (minimizeHomeWatcher1 != null)
          minimizeHomeWatcher1.EventArrived -= arrivedEventHandler;
        this._MinimizeHomeWatcher = value;
        ManagementEventWatcher minimizeHomeWatcher2 = this._MinimizeHomeWatcher;
        if (minimizeHomeWatcher2 == null)
          return;
        minimizeHomeWatcher2.EventArrived += arrivedEventHandler;
      }
    }

    public virtual KeyboardHook kbHook
    {
      get => this._kbHook;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyboardHook.KeyDownEventHandler downEventHandler = new KeyboardHook.KeyDownEventHandler(this.kbHook_KeyDown);
        KeyboardHook.KeyUpEventHandler keyUpEventHandler = new KeyboardHook.KeyUpEventHandler(this.kbHook_KeyUp);
        if (this._kbHook != null)
        {
          KeyboardHook.KeyDown -= downEventHandler;
          KeyboardHook.KeyUp -= keyUpEventHandler;
        }
        this._kbHook = value;
        if (this._kbHook == null)
          return;
        KeyboardHook.KeyDown += downEventHandler;
        KeyboardHook.KeyUp += keyUpEventHandler;
      }
    }

    public FrmMain()
    {
      InitializeComponent();
      this.Load += new EventHandler(this.Form1_Load);
      this.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
      this.Resize += new EventHandler(this.Form1_Resize);
      this.rs = new Resizer();
      this.Is64Bit = false;
      this.profileList = new Dictionary<string, string>();
      this.profileTimerList = new Dictionary<string, string>();
      this.profileASWList = new Dictionary<string, string>();
      this.profilePriorityList = new Dictionary<string, string>();
      this.profileNames = new List<string>();
      this.profileDisplayNames = new Dictionary<string, string>();
      this.profileAswDelay = new Dictionary<string, string>();
      this.profileCpuDelay = new Dictionary<string, string>();
      this.profilePaths = new Dictionary<string, string>();
      this.profileMirror = new Dictionary<string, string>();
      this.profileAGPS = new Dictionary<string, string>();
      this.profileFOV = new Dictionary<string, string>();
      this.profileForceMipMap = new Dictionary<string, string>();
      this.profileOffsetMipMap = new Dictionary<string, string>();
      this.runningApp = "";
      this.hasError = false;
      this.hasWarning = false;
      this.OculusServiceFound = true;
      this.customCulture = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
      this.power_plans = new Dictionary<string, string>();
      this.debug = false;
      this.RiftAudioCanceled = false;
      this.HomeIsRunning = false;
      this.OVRIsRunning = false;
      this.spoofid = false;
      this.loadingDone = false;
      this.OculusSoftwarePaths = new List<string>();
      this.Watcher = new ManagementEventWatcher();
      this.MinimizeHomeWatcher = new ManagementEventWatcher();
      this.colRemovedTabs = new Dictionary<string, TabPage>();
      this.steamvr = "";
      this.Hometimer = new System.Windows.Forms.Timer();
      this.pTimer = new System.Timers.Timer();
      this.ManualStart = false;
      this.restartInDBG = false;
      this.ignoredApps = new List<string>();
      this.includedApps = new List<string>();
      this.voiceProfileNames = new List<string>();
      this.ovrDown = false;
      this.Update_URL = "https://www.dropbox.com/s/63qb2oswo2o3ugt/version.txt?dl=1";
      this.UpdateTest_URL = "https://www.dropbox.com/s/v11ce9oww5yhkg4/version_test_2.txt?dl=1";
      this.voiceSettingsLoaded = false;
      this._Home2Timer = new System.Timers.Timer(100.0);
      this.restartHome = false;
      this.mirrorTimer = new System.Timers.Timer();
      this.StartingUp = false;
      this.AswToggle = new List<string>();
      this.cpuTimer = new System.Timers.Timer();
      this.aswTimer = new System.Timers.Timer();
      this.AppWatchWorker = new BackgroundWorker();
      this.AllAppsList = new Dictionary<string, string>();
      this.NoProfileFound = false;
      this.numLogMessages = 0;
      this.HomeIsMirrored = false;
      this.FuncToKeyDictionary = new Dictionary<string, string>();
      this.NextASW = new List<string>();
      this.CurrentASW = 0;
      this.NextHUD = new List<string>();
      this.CurrentHUD = 0;
      this.DSep = ".";
      Application.EnableVisualStyles();
      this.InitializeComponent();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        this.StartingUp = true;
        FrmMain.fmain = this;
        FrmMain.lockObject = RuntimeHelpers.GetObjectValue(new object());
        this.rs.FindAllControls((Control) this);
        string[] commandLineArgs = Environment.GetCommandLineArgs();
        int index1 = 0;
        while (index1 < commandLineArgs.Length)
        {
          string Left = commandLineArgs[index1];
          if (Operators.CompareString(Left, "-r", false) == 0)
          {
            OculusTrayTool.My.MySettings.Default.Reset();
            OculusTrayTool.My.MySettings.Default.Save();
            this.Shutdown();
          }
          Globals.dbg = Operators.CompareString(Left, "-d", false) == 0;
          if (Operators.CompareString(Left, "-u", false) == 0)
            OculusTrayTool.My.MySettings.Default.UpgradeRequired = true;
          checked { ++index1; }
        }
        if (!Globals.dbg && OculusTrayTool.My.MySettings.Default.RunDebug)
        {
          OculusTrayTool.My.MySettings.Default.RunDebug = false;
          OculusTrayTool.My.MySettings.Default.Save();
          Globals.dbg = true;
        }
        if (Globals.dbg)
        {
          FileSystem.Rename(Application.StartupPath + "\\ott.log", "ott_" + DateTime.Now.ToString().Replace("/", "").Replace("\\", "").Replace("-", "").Replace(" ", "_").Replace(":", "") + ".log");
          Log.WriteToLog(":: Debug is ON ::");
        }
        Log.WriteToLog("Starting up...");
        Log.WriteToLog("Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        VoiceCommands.Initialize();
        if (Globals.dbg)
          Log.WriteToLog("Checking Administrator privileges");
        this.isElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        if (!this.isElevated)
        {
          int num = (int) Interaction.MsgBox((object) "You must run Oculus Tray Tool as Administrator.\r\nThe application will now exit.", MsgBoxStyle.Critical, (object) "Oculus Tray Tool");
          this.Shutdown();
        }
        this.DotNetBarTabcontrol1.TabPages[0].ImageIndex = 0;
        this.DotNetBarTabcontrol1.TabPages[1].ImageIndex = 1;
        this.DotNetBarTabcontrol1.TabPages[2].ImageIndex = 2;
        this.DotNetBarTabcontrol1.TabPages[3].ImageIndex = 3;
        this.DotNetBarTabcontrol1.TabPages[4].ImageIndex = 4;
        this.DotNetBarTabcontrol1.TabPages[5].ImageIndex = 5;
        this.DotNetBarTabcontrol1.TabPages[6].ImageIndex = 7;
        this.DotNetBarTabcontrol1.TabPages[7].ImageIndex = 6;

        if (!File.Exists(Application.StartupPath + "\\CoreAudio.dll"))
        {
          Log.WriteToLog("Missing dependency: CoreAudio.dll, cannot continue");
          int num = (int) Interaction.MsgBox((object) "Missing dependency: CoreAudio.dll, cannot continue", MsgBoxStyle.Critical, (object) "Oculus Tray Tool");
          this.Dispose();
        }
        else if (!File.Exists(Application.StartupPath + "\\Microsoft.Win32.TaskScheduler.dll"))
        {
          Log.WriteToLog("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue");
          int num = (int) Interaction.MsgBox((object) "Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue", MsgBoxStyle.Critical, (object) "Oculus Tray Tool");
          this.Dispose();
        }
        else if (!File.Exists(Application.StartupPath + "\\Newtonsoft.Json.dll"))
        {
          Log.WriteToLog("Missing dependency: Newtonsoft.Json.dll, cannot continue");
          int num = (int) Interaction.MsgBox((object) "Missing dependency: Newtonsoft.Json.dll, cannot continue", MsgBoxStyle.Critical, (object) "Oculus Tray Tool");
          this.Dispose();
        }
        else if (!File.Exists(Application.StartupPath + "\\SQLite.Interop.dll"))
        {
          Log.WriteToLog("Missing dependency: SQLite.Interop.dll, cannot continue");
          int num = (int) Interaction.MsgBox((object) "Missing dependency: SQLite.Interop.dll, cannot continue", MsgBoxStyle.Critical, (object) "Oculus Tray Tool");
          this.Dispose();
        }
        else if (!File.Exists(Application.StartupPath + "\\System.Data.SQLite.dll"))
        {
          Log.WriteToLog("Missing dependency: System.Data.SQLite.dll, cannot continue");
          int num = (int) Interaction.MsgBox((object) "Missing dependency: System.Data.SQLite.dll, cannot continue", MsgBoxStyle.Critical, (object) "Oculus Tray Tool");
          this.Dispose();
        }
        else
        {
          if (Globals.dbg)
            Log.WriteToLog("Show Loading toast");
          MyProject.Forms.frmLoading.Show();
          if (OculusTrayTool.My.MySettings.Default.UpgradeRequired)
          {
            Log.WriteToLog("Migrating user settings to new version");
            OculusTrayTool.My.MySettings.Default.Upgrade();
            OculusTrayTool.My.MySettings.Default.UpgradeRequired = false;
            OculusTrayTool.My.MySettings.Default.StartWithWindows = false;
            OculusTrayTool.My.MySettings.Default.Save();
          }
          OTTDB.CheckDB();
          this.TrackBar1.Value = checked ((int) Math.Round((double) OculusTrayTool.My.MySettings.Default.FontSize));
          this.Label14.Text = "Font Size: " + this.TrackBar1.Value.ToString();
          this.rs.ResizeAllControls((Control) this, (float) this.TrackBar1.Value);
          MyProject.Forms.frmProfiles.ListView1.Font = new Font(MyProject.Forms.frmProfiles.ListView1.Font.Name, OculusTrayTool.My.MySettings.Default.FontSize, FontStyle.Regular);
          MyProject.Forms.frmProfiles.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
          this.UpdateTab = this.DotNetBarTabcontrol1.TabPages[6];
          this.colRemovedTabs.Add(this.TabPage6.Name, (TabPage)this.TabPage6);
          this.DotNetBarTabcontrol1.TabPages.Remove(this.TabPage6);
          if (Globals.dbg)
            Log.WriteToLog("Checking .NET version");
          GetDotNetVersion.GetVersion();
          Point point;
          if (OculusTrayTool.My.MySettings.Default.WindowLocation != new Point())
          {
            if (Globals.dbg)
            {
              point = OculusTrayTool.My.MySettings.Default.WindowLocation;
              Log.WriteToLog("Setting GUI location to " + point.ToString());
            }
            this.Location = OculusTrayTool.My.MySettings.Default.WindowLocation;
          }
          else
          {
            Log.WriteToLog("Setting GUI location to Center Screen");
            this.CenterToScreen();
            OculusTrayTool.My.MySettings.Default.WindowLocation = this.Location;
            OculusTrayTool.My.MySettings.Default.Save();
          }
          point = this.Location;
          int num1 = point.X < 0 ? 1 : 0;
          point = this.Location;
          int num2 = point.Y < 0 ? 1 : 0;
          if ((num1 | num2) != 0)
          {
            Log.WriteToLog("GUI location has negative number, adjusting");
            this.CenterToScreen();
            OculusTrayTool.My.MySettings.Default.WindowLocation = this.Location;
            OculusTrayTool.My.MySettings.Default.Save();
          }
          if (OculusTrayTool.My.MySettings.Default.GuiSize != new Size())
            this.Size = OculusTrayTool.My.MySettings.Default.GuiSize;
          Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
          this.scaleX = (object) (float) ((double) graphics.DpiX / 96.0);
          this.scaleY = (object) (float) ((double) graphics.DpiY / 96.0);
          this.Text = this.Text + " " + Application.ProductVersion.Substring(0, 8);
          MyProject.Forms.frmAbout.Label4.Text = Application.ProductVersion.Substring(0, 8);
          this.customCulture.NumberFormat.NumberDecimalSeparator = ".";
          if (Globals.dbg)
            Log.WriteToLog("Setting culture to " + this.customCulture.ToString());
          Thread.CurrentThread.CurrentCulture = this.customCulture;
          this.Is64Bit = Environment.Is64BitOperatingSystem;
          if (Globals.dbg)
            Log.WriteToLog("is64Bit=" + this.Is64Bit.ToString());
          if (!this.isElevated)
          {
            this.AddToListboxAndScroll("** Not running as Administrator **");
            Log.WriteToLog("Not running as Administrator!");
            this.hasError = true;
          }
          string toolTip1 = this.ToolTip.GetToolTip((Control) this.CheckSpoofCPU);
          if (string.Compare(toolTip1, (string) null, StringComparison.Ordinal) != 0 && toolTip1.Length > 75)
            this.ToolTip.SetToolTip((Control) this.CheckSpoofCPU, this.SplitToolTip(toolTip1));
          string toolTip2 = this.ToolTip.GetToolTip((Control) this.Label13);
          if (string.Compare(toolTip2, (string) null, StringComparison.Ordinal) != 0 && toolTip2.Length > 75)
            this.ToolTip.SetToolTip((Control) this.Label13, this.SplitToolTip(toolTip2));
          string toolTip3 = this.ToolTip.GetToolTip((Control) this.Label18);
          if (string.Compare(toolTip3, (string) null, StringComparison.Ordinal) != 0 && toolTip3.Length > 75)
            this.ToolTip.SetToolTip((Control) this.Label18, this.SplitToolTip(toolTip3));
          string toolTip4 = this.ToolTip.GetToolTip((Control) this.CheckLocalDebug);
          if (string.Compare(toolTip4, (string) null, StringComparison.Ordinal) != 0 && toolTip4.Length > 75)
            this.ToolTip.SetToolTip((Control) this.CheckLocalDebug, this.SplitToolTip(toolTip4));
          string toolTip5 = this.ToolTip.GetToolTip((Control) this.CheckStartWatcher);
          if (string.Compare(toolTip5, (string) null, StringComparison.Ordinal) != 0 && toolTip5.Length > 75)
            this.ToolTip.SetToolTip((Control) this.CheckStartWatcher, this.SplitToolTip(toolTip5));
          if (File.Exists(Application.StartupPath + "\\data.sqlite"))
          {
            File.Delete(Application.StartupPath + "\\data.sqlite");
            if (Globals.dbg)
              Log.WriteToLog("Database copy deleted");
          }
          if (Globals.dbg)
            Log.WriteToLog("Looking for Oculus database");
          if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite"))
          {
            if (Globals.dbg)
              Log.WriteToLog("Database found, making a copy");
            try
            {
              File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Exception exception = ex;
              Log.WriteToLog("Failed to create database copy: " + exception.Message);
              int num3 = (int) Interaction.MsgBox((object) ("Failed to create database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error copying database");
              this.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
              this.hasError = true;
              ProjectData.ClearProjectError();
              return;
            }
          }
          OculusTrayTool.OculusPath.GetOculusPath();
          GetConfig.IsReading = true;
          OTTDB.OpenOttDB();
          PowerPlans.GetPowerPlans();
          GetConfig.Load();
          if (string.Compare(OculusTrayTool.My.MySettings.Default.LibraryPath, "", StringComparison.Ordinal) == 0 | string.IsNullOrWhiteSpace(OculusTrayTool.My.MySettings.Default.LibraryPath.ToString()))
          {
            OculusTrayTool.My.MySettings.Default.LibraryPath = "";
            OculusTrayTool.My.MySettings.Default.Save();
            Log.WriteToLog("Oculus Library paths not set, retrieving them from the registry");
            this.OculusSoftwarePaths = (List<string>) OculusTrayTool.OculusPath.GetOculusSoftwarePaths();
            Log.WriteToLog("Found " + this.OculusSoftwarePaths.Count.ToString() + " library paths");
            if (this.OculusSoftwarePaths.Count > 0)
            {
              try
              {
                foreach (string oculusSoftwarePath in this.OculusSoftwarePaths)
                {
                  Log.WriteToLog("Oculus Library path: " + oculusSoftwarePath.TrimEnd('\\'));
                  // ISSUE: variable of a compiler-generated type
                  MySettings settings;
                  (settings = OculusTrayTool.My.MySettings.Default).LibraryPath = settings.LibraryPath + oculusSoftwarePath + ",";
                  OculusTrayTool.My.MySettings.Default.Save();
                }
              }
              catch (Exception ex)
              {
                   Log.WriteToLog("Error processing Oculus Library Paths: " + ex.Message);
              }
              }
              OculusTrayTool.My.MySettings.Default.LibraryPath = OculusTrayTool.My.MySettings.Default.LibraryPath.TrimEnd(',');
              OculusTrayTool.My.MySettings.Default.Save();
            }
            else
            {
              Log.WriteToLog("No library paths returned from registry! You may need to add them manually.");
              Log.WriteToLog("Using " + this.OculusPath + " as default library path");
              this.AddToListboxAndScroll("No library paths returned from registry! You may need to add them manually.");
              this.AddToListboxAndScroll("Using " + this.OculusPath + " as default library path");
              this.hasWarning = true;
            }
          }
          this.NextASW.AddRange((IEnumerable<string>) new string[7]
          {
            "Auto",
            "Off",
            "45",
            "45f",
            "18",
            "30",
            "Adaptive"
          });
          OTTDB.GetProfiles();
          this.ignoredApps = (List<string>) OTTDB.GetIgnoredApps();
          this.includedApps = (List<string>) OTTDB.GetIncludedApps();
          if (this.ignoredApps.Count > 0)
            Log.WriteToLog(this.ignoredApps.Count.ToString() + " apps are being ignored");
          if (OculusTrayTool.My.MySettings.Default.UseLocalDebugTool)
          {
            if (File.Exists(Application.StartupPath + "\\OculusDebugToolCLI.exe"))
            {
              RunCommand.debug_tool_path = Application.StartupPath + "\\OculusDebugToolCLI.exe";
              Log.WriteToLog("'UseLocalDebugTool' is 'True', using " + RunCommand.debug_tool_path);
              this.CheckLocalDebug.Checked = true;
            }
            else
            {
              Log.WriteToLog("'UseLocalDebugTool' is 'True' but " + Application.StartupPath + "\\OculusDebugToolCLI.exe was not found!");
              this.AddToListboxAndScroll("'UseLocalDebugTool' is 'True' but " + Application.StartupPath + "\\OculusDebugToolCLI.exe was not found!");
              this.ListBox1.Refresh();
              this.hasError = true;
            }
          }
          else if (File.Exists(this.OculusPath + "Support\\oculus-diagnostics\\OculusDebugToolCLI.exe"))
          {
            RunCommand.debug_tool_path = this.OculusPath + "Support\\oculus-diagnostics\\OculusDebugToolCLI.exe";
            Log.WriteToLog("Using " + RunCommand.debug_tool_path);
          }
          else
          {
            RunCommand.debug_tool_path = Application.StartupPath + "\\OculusDebugToolCLI.exe";
            Log.WriteToLog("Using " + RunCommand.debug_tool_path);
          }
          RunCommand.CloseDebugTool();
          if (Globals.dbg)
            Log.WriteToLog("Reading setting ASW");
          if (OculusTrayTool.My.MySettings.Default.ASW == 0)
            FrmMain.fmain.ComboBox1.Text = "Auto";
          if (OculusTrayTool.My.MySettings.Default.ASW == 1)
            FrmMain.fmain.ComboBox1.Text = "Off";
          if (OculusTrayTool.My.MySettings.Default.ASW == 2)
            FrmMain.fmain.ComboBox1.Text = "45 Hz";
          if (OculusTrayTool.My.MySettings.Default.ASW == 3)
            FrmMain.fmain.ComboBox1.Text = "30 Hz";
          if (OculusTrayTool.My.MySettings.Default.ASW == 4)
            FrmMain.fmain.ComboBox1.Text = "18 Hz";
          if (OculusTrayTool.My.MySettings.Default.ASW == 5)
            FrmMain.fmain.ComboBox1.Text = "45 Hz forced";
          if (OculusTrayTool.My.MySettings.Default.ASW == 6)
            FrmMain.fmain.ComboBox1.Text = "Adaptive";
          FrmMain.fmain.ComboVisualHUD.Text = "None";
          this.CheckStartWithWindowsLogic();
          PowerPlans.CheckPowerState(false);
          if (!this.spoofid && OculusTrayTool.My.MySettings.Default.StartOVR & !this.OVRIsRunning && this.OculusServiceFound)
            this.StartOVR();
          if (Globals.dbg)
            Log.WriteToLog("Reading setting SpoofCPU");
          FrmMain.fmain.spoofid = OculusTrayTool.My.MySettings.Default.SpoofCPU;
          if (OculusTrayTool.My.MySettings.Default.SpoofCPU)
          {
            FrmMain.fmain.CheckSpoofCPU.Checked = true;
            OculusTrayTool.My.MySettings.Default.OldCPUID = "";
            FrmMain.fmain.GetCPUid();
          }
          else
            FrmMain.fmain.CheckSpoofCPU.Checked = false;
          if (!OculusTrayTool.My.MySettings.Default.StartOVR & !OculusTrayTool.My.MySettings.Default.SpoofCPU)
            this.CheckOculusService();
          string str1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OTT");
          Directory.CreateDirectory(str1);
          Globals.steam = new Steam(str1);
          Globals.oculus = new Oculus(str1, Globals.steam);
          this.GetSteamPath();
          this.GetSteamVR();
          if (string.Compare(this.SteamPath, "", StringComparison.Ordinal) != 0)
          {
            this.vrManifestFileName = Path.Combine(this.SteamPath, "config\\steamapps.vrmanifest");
            if (!File.Exists(this.vrManifestFileName))
            {
              Log.WriteToLog("Could not locate Steam VR manifest");
            }
            else
            {
              Log.WriteToLog("Found Steam VR manifest: " + this.vrManifestFileName);
              GetGames.GetSteamGames();
            }
          }
          if (this.OculusServiceFound)
          {
            if (Directory.Exists(this.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
              GetGames.GetThirdPartyApps(this.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
            if (Directory.Exists(this.OculusPath.TrimEnd('\\') + "\\Manifests"))
              GetGames.GetFiles(this.OculusPath.TrimEnd('\\') + "\\Manifests");
            if (Directory.Exists(this.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
              GetGames.GetFiles(this.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
            if (string.Compare(OculusTrayTool.My.MySettings.Default.LibraryPath, "", StringComparison.Ordinal) != 0 & !string.IsNullOrWhiteSpace(OculusTrayTool.My.MySettings.Default.LibraryPath.ToString()))
            {
              string[] strArray = Strings.Split(OculusTrayTool.My.MySettings.Default.LibraryPath, ",");
              int index2 = 0;
              while (index2 < strArray.Length)
              {
                string str2 = strArray[index2];
                if (Directory.Exists(str2.TrimEnd('\\') + "\\Manifests"))
                  GetGames.GetFiles(str2.TrimEnd('\\') + "\\Manifests");
                if (Directory.Exists(str2.TrimEnd('\\') + "\\CoreData\\Manifests"))
                  GetGames.GetThirdPartyApps(str2.TrimEnd('\\') + "\\CoreData\\Manifests");
                checked { ++index2; }
              }
            }
          }
          if (OTTDB.numTimer > 0)
          {
            if (Globals.dbg)
              Log.WriteToLog("Creating EventHandler for Timer AppWatcher");
            this.pTimer.Elapsed += new ElapsedEventHandler(this.OnTimerProfile);
            this.pTimer.Interval = 400.0;
            this.pTimer.Enabled = false;
            this.pTimer.AutoReset = true;
          }
          if (this.OVRIsRunning)
            this.ComboVisualHUD.SelectedIndex = 0;
          if (this.OculusServiceFound & !OculusTrayTool.My.MySettings.Default.StartAppwatcherOnStart)
          {
            Log.WriteToLog("Oculus Home/SteamVR required, waiting for either to start");
            this.OculusHomeWatcher.Start();
          }
          if (this.OculusServiceFound & OculusTrayTool.My.MySettings.Default.StartAppwatcherOnStart)
          {
            if (OTTDB.numWMI > 0)
              this.CreateWatcher();
            if (OTTDB.numTimer > 0)
            {
              Log.WriteToLog("Start Appwatcher On Start is True, starting Timer AppWatcher");
              this.pTimer.Start();
            }
          }
          if (this.OVRIsRunning && this.CheckLaunchHomeTool.Checked)
          {
            if (File.Exists(this.OculusPath + "Support\\oculus-client\\OculusClient.exe"))
            {
              RunCommand.StartHome();
            }
            else
            {
              Log.WriteToLog("Could not locate OculusClient in " + this.OculusPath);
              this.AddToListboxAndScroll("Could not locate OculusClient in " + this.OculusPath);
              this.hasWarning = true;
            }
          }
          if (OculusTrayTool.My.MySettings.Default.AutomaticUpdateCheck)
          {
            this.UpdateTimer.Start();
          }
          else
          {
            Log.WriteToLog("Automatic update checking is disabled");
            this.AddToListboxAndScroll("Automatic update checking is disabled");
          }
          if (Globals.dbg)
            this.PrintSettings(false);
          if (OculusTrayTool.My.MySettings.Default.StartMinimized)
            this.WindowState = FormWindowState.Minimized;
          try
          {
          if (GetConfig.SetRiftDefault)
          {
            if (OculusTrayTool.My.MySettings.Default.SetRiftAudioDefault == 1)
            {
              if (OculusTrayTool.My.MySettings.Default.SetAudioOnStartGuid != null)
                AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
              if (OculusTrayTool.My.MySettings.Default.SetAudioCommOnStartGuid != null)
                AudioSwitcher.SetDefaultAudioCommDeviceOnStart();
            }
            if (OculusTrayTool.My.MySettings.Default.SetRiftMicDefault == 1)
            {
              if (OculusTrayTool.My.MySettings.Default.SetMicOnStartGuid != null)
                AudioSwitcher.SetDefaultMicDeviceOnStart();
              if (OculusTrayTool.My.MySettings.Default.SetMicCommOnStartGuid != null)
                AudioSwitcher.SetDefaultMicCommDeviceOnStart();
            }
          }
          else if (GetConfig.useVoiceCommands)
            this.EnableDisableVoice(true);
          if (OculusTrayTool.My.MySettings.Default.HomelessEnabled == 1 & OculusTrayTool.My.MySettings.Default.HomelessAutoPatch)
          {
            Log.WriteToLog("Oculus Homeless is installed, generating hash of 'Home2-Win64-Shipping.exe'");
            string Right = this.GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe").ToString();
            if (string.Compare(this.GenerateSHA256Hash(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe").ToString(), Right, StringComparison.Ordinal) != 0)
            {
              Log.WriteToLog("'Home2-Win64-Shipping.exe' has been updated. Automatically re-applying Oculus Homeless");
              this.InstallHomeless();
            }
          }
          else
             this.ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Log.WriteToLog("* Could not get default audio endpoint!");
            this.AddToListboxAndScroll("* Could not get default audio endpoint, no enabled devices found!");
            this.hasWarning = true;
            ProjectData.ClearProjectError();
          }
          if (OculusTrayTool.My.MySettings.Default.RestartServiceAfterSleep)
          {
            if (Globals.dbg)
              Log.WriteToLog("Adding eventhandler for PowerModeChanged");
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(this.PowerModeChanged);
          }
          if (OculusTrayTool.My.MySettings.Default.SendHomeToTrayOnStart)
            this.StartMinimizeHomeWatcher();
          OTTDB.GetLinkPresetNames();
          this.GetOculusLinkValues();
          this.CheckWarnings();
          this.AddToListboxAndScroll(this.AllAppsList.Count.ToString() + " apps are being monitored");
          this.AddToListboxAndScroll(this.ignoredApps.Count.ToString() + " apps are being ignored");
          this.AddToListboxAndScroll(GetConfig.numprofiles.ToString() + " apps have profiles");
          Log.WriteToLog("Getting list of supported desktop resolutions");
          MyProject.Forms.frmProfiles.ComboResolution.Items.AddRange((object[]) Resolution.GetSupportedResolutions());
          GetConfig.IsReading = false;
          this.loadingDone = true;
          if (Globals.dbg)
            Log.WriteToLog("LoadingDone=" + this.loadingDone.ToString());
          this.Cursor = Cursors.Default;
          if (Globals.dbg)
            Log.WriteToLog("Checking errors and warnings");
          if (this.hasError)
          {
            if (Globals.dbg)
              Log.WriteToLog("hasError=" + this.hasError.ToString());
            MyProject.Forms.frmLoading.Label2.Text = "Not Ready (Error)";
            MyProject.Forms.frmLoading.Label2.Refresh();
            this.NotificationTimer.Interval = 1500;
            this.NotificationTimer.Start();
            Log.WriteToLog("Startup Complete");
          }
          else if (this.hasWarning)
          {
            if (Globals.dbg)
              Log.WriteToLog("hasWarning=" + this.hasWarning.ToString());
            MyProject.Forms.frmLoading.Label2.Text = "Ready (Warnings)";
            MyProject.Forms.frmLoading.Label2.Refresh();
            this.NotificationTimer.Interval = 1500;
            this.NotificationTimer.Start();
            Log.WriteToLog("Startup Complete");
          }
          else if (!this.hasError & !this.hasWarning)
          {
            if (Globals.dbg)
              Log.WriteToLog("No warnings or errors");
            MyProject.Forms.frmLoading.Label2.Text = "Ready";
            MyProject.Forms.frmLoading.Label2.Refresh();
            this.NotificationTimer.Interval = 1000;
            this.NotificationTimer.Start();
            Log.WriteToLog("Startup Complete");
          }
          this.NotifyIcon1.Visible = true;
          this.StartingUp = false;
        }

      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e1 = ex;
        this.AddToListboxAndScroll("Exception on Startup: " + e1.Message);
        StackTrace stackTrace = new StackTrace(e1, true);
        Log.WriteToLog(e1.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public void CreateWatcher()
    {
      if (this.Watcher != null)
        return;
      this.Watcher = new ManagementEventWatcher();
    }

    private void StartMinimizeHomeWatcher()
    {
      try
      {
        this.MinimizeHomeWatcher.Stop();
        if (Globals.dbg)
          Log.WriteToLog("Starting Watcher for 'Minimize Home on Start'");
        this.MinimizeHomeWatcher = new ManagementEventWatcher("\\\\.\\root\\CIMV2", "SELECT TargetInstance FROM __InstanceCreationEvent WITHIN  1.0 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name like 'OculusClient.exe'");
        this.MinimizeHomeWatcher.Start();
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Watcher for 'Minimize Home on Start' started");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("StartMinimizeHomeWatcher(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void MinimizeHomeWatcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
      this.MinimizeHomeWatcher_EventArrived_Delegate(0);
    }

    private void MinimizeHomeWatcher_EventArrived_Delegate(int tries)
    {
      try
      {
        this.MinimizeHomeWatcher.Stop();
        if (!HomeToTray.HomeIsMinimized)
        {
          if (tries >= 3)
          {
            Log.WriteToLog(tries.ToString() + " attempts for sending Home to tray, giving up");
            tries = 0;
          }
          else
          {
            if (Globals.dbg)
              Log.WriteToLog("'Minimize Home on Start' event arrived");
            if (((IEnumerable<Process>) Process.GetProcessesByName("OculusClient")).Count<Process>() >= 3)
            {
              Log.WriteToLog("Oculus Home seems to have started up fully. Sleeping " + OculusTrayTool.My.MySettings.Default.SleepAfterHomeStart + "ms before attempting to minimize to tray");
              Thread.Sleep(Conversions.ToInteger(OculusTrayTool.My.MySettings.Default.SleepAfterHomeStart));
              HomeToTray.SendHomeToTrayOnStart();
              if (HomeToTray.HomeIsMinimized)
              {
                this.EnableShowHomeMenu();
                if (OculusTrayTool.My.MySettings.Default.ShowHomeToast & !HomeToTray.ToastShown)
                {
                  HomeToTray.ToastShown = true;
                  new Thread(() => MyProject.Forms.frmHomeTrayToast.ShowDialog()).Start();
                }
                this.MinimizeHomeWatcher.Start();
              }
            }
           }
         }
       } catch (Exception ex) {
          Log.WriteToLog("Error in MinimizeHomeWatcher_EventArrived_Delegate: " + ex.Message);
       }
     }

     private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
     {
       OculusTrayTool.My.MySettings.Default.GuiSize = this.Size;
      OculusTrayTool.My.MySettings.Default.Save();
      if (e.CloseReason == CloseReason.WindowsShutDown)
      {
        Log.WriteToLog("Windows shutdown detected, performing quick cleanup");
        if (OTTDB.ott_cnn.State == ConnectionState.Open)
          OTTDB.ott_cnn.Close();
        if (Operators.CompareString(OculusTrayTool.My.MySettings.Default.PowerPlanExit, "Not Used", false) != 0 && OculusTrayTool.My.MySettings.Default.ApplyPowerPlan == 0)
        {
          PowerPlans.SetActivePowerPlan(OculusTrayTool.My.MySettings.Default.PowerPlanExit);
          PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
        }
        if (GetConfig.SetRiftDefault)
        {
          if (OculusTrayTool.My.MySettings.Default.SetRiftAudioDefault == 1)
          {
            AudioSwitcher.SetFallbackAudioDevice();
            AudioSwitcher.SetFallbackCommAudioDevice();
          }
          if (OculusTrayTool.My.MySettings.Default.SetRiftMicDefault == 1)
          {
            AudioSwitcher.SetFallbackMicDevice();
            AudioSwitcher.SetFallbackCommMicDevice();
          }
        }
        Log.WriteToLog("bye bye");
        this.Dispose();
      }
      if (e.CloseReason == CloseReason.UserClosing)
      {
        if (!OculusTrayTool.My.MySettings.Default.CloseOnX)
        {
          e.Cancel = true;
          if (OculusTrayTool.My.MySettings.Default.ShowStillRunning)
            MyProject.Forms.frmStillRunningToast.Show();
          this.WindowState = FormWindowState.Minimized;
        }
        else if (Interaction.MsgBox((object) "Oculus Tray Tool needs to be running to work its magic!\r\n\r\nAre you sure you want to exit?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Confirm Exit") == MsgBoxResult.No)
          e.Cancel = true;
        else
          this.Shutdown();
      }
    }

    public void Shutdown()
    {
      try
      {
        this.Hide();
        // return; // Removed unreachable return or kept it? Logic implies hide then done.
      }
      catch (Exception ex)
      {
          Log.WriteToLog("Error in Shutdown: " + ex.Message);
      }
    }

    private void ComboSSstart_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar == (int) Conversions.ToChar(this.DSep))
        e.Handled = true;
      else if (e.KeyChar == '\r')
      {
        if (!GetConfig.IsReading)
        {
          OculusTrayTool.My.MySettings.Default.PPDPStartup = this.ComboSSstart.Text;
          OculusTrayTool.My.MySettings.Default.Save();
          GetConfig.ppdpstartup = this.ComboSSstart.Text;
          new Thread(() => RunCommand.Run_debug_tool(GetConfig.ppdpstartup)).Start();
        }
      }
      else
        e.Handled = true;
    }

    private void CheckStopServiceHome_CheckedChanged(object sender, EventArgs e)
    {
      try
      {
        if (GetConfig.IsReading)
          return;
        OculusTrayTool.My.MySettings.Default.StopOVRHome = this.CheckStopServiceHome.Checked;
        OculusTrayTool.My.MySettings.Default.Save();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e1 = ex;
        this.AddToListboxAndScroll("* Exception: " + e1.Message);
        this.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e1, true);
        Log.WriteToLog(e1.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmMain));
      this.NotifyIcon1 = new NotifyIcon(this.components);
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.ToolStripStartOVR = new ToolStripMenuItem();
      this.ToolStripStopOVR = new ToolStripMenuItem();
      this.ToolStripRestartOVR = new ToolStripMenuItem();
      this.ToolStripSeparator2 = new ToolStripSeparator();
      this.ToolStripMenuItem3 = new ToolStripMenuItem();
      this.ToolStripSeparator1 = new ToolStripSeparator();
      this.ToolStripMenuItem2 = new ToolStripMenuItem();
      this.ToolStripMenuShowHome = new ToolStripMenuItem();
      this.ToolStripMenuItem1 = new ToolStripMenuItem();
      this.ContextMenuStrip2 = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem4 = new ToolStripMenuItem();
      this.ClearLogToolStripMenuItem = new ToolStripMenuItem();
      this.OpenLogToolStripMenuItem = new ToolStripMenuItem();
      this.ToolTip = new ToolTip(this.components);
      this.PictureBox1 = new PictureBox();
      this.PictureBox2 = new PictureBox();
      this.ComboSSstart = new ComboBox();
      this.ComboBox1 = new ComboBox();
      this.Label1 = new Label();
      this.Label6 = new Label();
      this.ComboHomless = new ComboBox();
      this.Label5 = new Label();
      this.ComboVoice = new ComboBox();
      this.BtnVoice = new Button();
      this.Button2 = new Button();
      this.PictureBox8 = new PictureBox();
      this.CheckRiftAudio = new CheckBox();
      this.CheckSpoofCPU = new CheckBox();
      this.ButtonRestartOVR = new Button();
      this.ButtonStartOVR = new Button();
      this.ButtonStopOVR = new Button();
      this.Label29 = new Label();
      this.CheckLocalDebug = new CheckBox();
      this.CheckStartWatcher = new CheckBox();
      this.Label13 = new Label();
      this.Label18 = new Label();
      this.Button4 = new Button();
      this.BtnRemoveAllProfiles = new Button();
      this.Button1 = new Button();
      this.Button5 = new Button();
      this.PictureBox7 = new PictureBox();
      this.PictureBox6 = new PictureBox();
      this.PictureBox5 = new PictureBox();
      this.PictureBox4 = new PictureBox();
      this.PictureBox3 = new PictureBox();
      this.Button11 = new Button();
      this.OculusHomeWatcher = new System.Windows.Forms.Timer(this.components);
      this.Label8 = new Label();
      this.NotificationTimer = new System.Windows.Forms.Timer(this.components);
      this.ImageList1 = new ImageList(this.components);
      this.HometoTrayTimer = new System.Windows.Forms.Timer(this.components);
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.NotifyIcon3 = new NotifyIcon(this.components);
      this.PowerPlanTimer = new System.Windows.Forms.Timer(this.components);
      this.DotNetBarTabcontrol1 = new DotNetBarTabcontrol();
      this.TabPage1 = new TabPage();
      this.GroupBox14 = new GroupBox();
      this.DbLayoutPanel2 = new DBLayoutPanel(this.components);
      this.Label19 = new Label();
      this.Label7 = new Label();
      this.BtnProfiles = new Button();
      this.Label9 = new Label();
      this.Label17 = new Label();
      this.ComboMirrorHome = new ComboBox();
      this.Label16 = new Label();
      this.BtnHomless = new Button();
      this.Label15 = new Label();
      this.Label35 = new Label();
      this.ComboVisualHUD = new ComboBox();
      this.ComboBox5 = new ComboBox();
      this.SplitContainer1 = new SplitContainer();
      this.NumericFOVh = new NumericUpDown();
      this.NumericFOVv = new NumericUpDown();
      this.ComboOVRPrio = new ComboBox();
      this.Label33 = new Label();
      this.ComboBox8 = new ComboBox();
      this.ComboBox9 = new ComboBox();
      this.Label37 = new Label();
      this.TabPage2 = new TabPage();
      this.GroupBox1 = new GroupBox();
      this.DbLayoutPanel4 = new DBLayoutPanel(this.components);
      this.CheckStartWindows = new CheckBox();
      this.CheckStartMin = new CheckBox();
      this.CheckMinimizeOnX = new CheckBox();
      this.CheckBoxAltTab = new CheckBox();
      this.HotKeysCheckBox = new CheckBox();
      this.BtnConfigureAudio = new Button();
      this.Label14 = new Label();
      this.CheckBoxCheckForUpdates = new CheckBox();
      this.BtnConfigureHotKeys = new Button();
      this.TrackBar1 = new TrackBar();
      this.TabPage3 = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.DbLayoutPanel5 = new DBLayoutPanel(this.components);
      this.ComboApplyPlan = new ComboBox();
      this.Label4 = new Label();
      this.ComboPowerPlanExit = new ComboBox();
      this.Label2 = new Label();
      this.ComboPowerPlanStart = new ComboBox();
      this.Label22 = new Label();
      this.Label3 = new Label();
      this.Label23 = new Label();
      this.CheckSensorPower = new CheckBox();
      this.ComboUSBsusp = new ComboBox();
      this.TabPage4 = new TabPage();
      this.DbLayoutPanel7 = new DBLayoutPanel(this.components);
      this.GroupBox6 = new GroupBox();
      this.DbLayoutPanel8 = new DBLayoutPanel(this.components);
      this.CheckStartService = new CheckBox();
      this.CheckStopService = new CheckBox();
      this.CheckSendHomeToTrayOnStart = new CheckBox();
      this.CheckSendHomeToTray = new CheckBox();
      this.CheckCloseHome = new CheckBox();
      this.CheckLaunchHomeTool = new CheckBox();
      this.CheckLaunchHome = new CheckBox();
      this.CheckRestartSleep = new CheckBox();
      this.CheckStopServiceHome = new CheckBox();
      this.GroupBox4 = new GroupBox();
      this.DbLayoutPanel6 = new DBLayoutPanel(this.components);
      this.LabelServiceStatus = new Label();
      this.Label11 = new Label();
      this.TabPage5 = new TabPage();
      this.GroupBox3 = new GroupBox();
      this.ListBox1 = new ListBox();
      this.TabPage7 = new TabPage();
      this.GroupBox7 = new GroupBox();
      this.DbLayoutPanel1 = new DBLayoutPanel(this.components);
      this.BtnLibrary = new Button();
      this.BtnSteamImport = new Button();
      this.Label24 = new Label();
      this.Label25 = new Label();
      this.Label26 = new Label();
      this.Label27 = new Label();
      this.Label28 = new Label();
      this.TabPage8 = new TabPage();
      this.GroupBox5 = new GroupBox();
      this.Button3 = new Button();
      this.Button12 = new Button();
      this.DbLayoutPanel3 = new DBLayoutPanel(this.components);
      this.ComboBox11 = new ComboBox();
      this.ComboBox6 = new ComboBox();
      this.Label32 = new Label();
      this.Label30 = new Label();
      this.Label31 = new Label();
      this.ComboBox4 = new ComboBox();
      this.ComboBox3 = new ComboBox();
      this.ComboBox2 = new ComboBox();
      this.Label36 = new Label();
      this.Label38 = new Label();
      this.ComboBox10 = new ComboBox();
      this.Label21 = new Label();
      this.Button6 = new Button();
      this.Label20 = new Label();
      this.ComboBox7 = new ComboBox();
      this.Label39 = new Label();
      this.Button10 = new Button();
      this.Label10 = new Label();
      this.TabPage6 = new TabPage();
      this.GroupBox9 = new GroupBox();
      this.LabelDownloadStatus = new Label();
      this.LabelVer = new Label();
      this.Label12 = new Label();
      this.Button9 = new Button();
      this.Button8 = new Button();
      this.ContextMenuStrip1.SuspendLayout();
      this.ContextMenuStrip2.SuspendLayout();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      ((ISupportInitialize) this.PictureBox8).BeginInit();
      ((ISupportInitialize) this.PictureBox7).BeginInit();
      ((ISupportInitialize) this.PictureBox6).BeginInit();
      ((ISupportInitialize) this.PictureBox5).BeginInit();
      ((ISupportInitialize) this.PictureBox4).BeginInit();
      ((ISupportInitialize) this.PictureBox3).BeginInit();
      this.DotNetBarTabcontrol1.SuspendLayout();
      this.TabPage1.SuspendLayout();
      this.GroupBox14.SuspendLayout();
      this.DbLayoutPanel2.SuspendLayout();
      this.SplitContainer1.BeginInit();
      this.SplitContainer1.Panel1.SuspendLayout();
      this.SplitContainer1.Panel2.SuspendLayout();
      this.SplitContainer1.SuspendLayout();
      this.NumericFOVh.BeginInit();
      this.NumericFOVv.BeginInit();
      this.TabPage2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.DbLayoutPanel4.SuspendLayout();
      this.TrackBar1.BeginInit();
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
      this.SuspendLayout();
      this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
      this.NotifyIcon1.Icon = (Icon) componentResourceManager.GetObject("NotifyIcon1.Icon");
      this.NotifyIcon1.Text = "Oculus Tray Tool";
      this.ContextMenuStrip1.ImageScalingSize = new Size(20, 20);
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.ToolStripStartOVR,
        (ToolStripItem) this.ToolStripStopOVR,
        (ToolStripItem) this.ToolStripRestartOVR,
        (ToolStripItem) this.ToolStripSeparator2,
        (ToolStripItem) this.ToolStripMenuItem3,
        (ToolStripItem) this.ToolStripSeparator1,
        (ToolStripItem) this.ToolStripMenuItem2,
        (ToolStripItem) this.ToolStripMenuShowHome,
        (ToolStripItem) this.ToolStripMenuItem1
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(230, 198);
      this.ToolStripStartOVR.Image = (Image) componentResourceManager.GetObject("ToolStripStartOVR.Image");
      this.ToolStripStartOVR.Name = "ToolStripStartOVR";
      this.ToolStripStartOVR.Size = new Size(229, 26);
      this.ToolStripStartOVR.Text = "Start Oculus Service";
      this.ToolStripStopOVR.Image = (Image) componentResourceManager.GetObject("ToolStripStopOVR.Image");
      this.ToolStripStopOVR.Name = "ToolStripStopOVR";
      this.ToolStripStopOVR.Size = new Size(229, 26);
      this.ToolStripStopOVR.Text = "Stop Oculus Service";
      this.ToolStripRestartOVR.Image = (Image) componentResourceManager.GetObject("ToolStripRestartOVR.Image");
      this.ToolStripRestartOVR.Name = "ToolStripRestartOVR";
      this.ToolStripRestartOVR.Size = new Size(229, 26);
      this.ToolStripRestartOVR.Text = "Restart Oculus Service";
      this.ToolStripSeparator2.Name = "ToolStripSeparator2";
      this.ToolStripSeparator2.Size = new Size(226, 6);
      this.ToolStripMenuItem3.Image = (Image) componentResourceManager.GetObject("ToolStripMenuItem3.Image");
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new Size(229, 26);
      this.ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new Size(226, 6);
      this.ToolStripMenuItem2.Image = (Image) componentResourceManager.GetObject("ToolStripMenuItem2.Image");
      this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      this.ToolStripMenuItem2.Size = new Size(229, 26);
      this.ToolStripMenuItem2.Text = "Show Application";
      this.ToolStripMenuShowHome.Enabled = false;
      this.ToolStripMenuShowHome.Image = (Image) componentResourceManager.GetObject("ToolStripMenuShowHome.Image");
      this.ToolStripMenuShowHome.Name = "ToolStripMenuShowHome";
      this.ToolStripMenuShowHome.Size = new Size(229, 26);
      this.ToolStripMenuShowHome.Text = "Show Oculus Home";
      this.ToolStripMenuItem1.Image = (Image) componentResourceManager.GetObject("ToolStripMenuItem1.Image");
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new Size(229, 26);
      this.ToolStripMenuItem1.Text = "Exit";
      this.ContextMenuStrip2.ImageScalingSize = new Size(20, 20);
      this.ContextMenuStrip2.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.ToolStripMenuItem4,
        (ToolStripItem) this.ClearLogToolStripMenuItem,
        (ToolStripItem) this.OpenLogToolStripMenuItem
      });
      this.ContextMenuStrip2.Name = "ContextMenuStrip2";
      this.ContextMenuStrip2.Size = new Size(227, 82);
      this.ToolStripMenuItem4.Enabled = false;
      this.ToolStripMenuItem4.Image = (Image) componentResourceManager.GetObject("ToolStripMenuItem4.Image");
      this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
      this.ToolStripMenuItem4.Size = new Size(226, 26);
      this.ToolStripMenuItem4.Text = "Disable Power Management";
      this.ToolStripMenuItem4.Visible = false;
      this.ClearLogToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("ClearLogToolStripMenuItem.Image");
      this.ClearLogToolStripMenuItem.Name = "ClearLogToolStripMenuItem";
      this.ClearLogToolStripMenuItem.Size = new Size(226, 26);
      this.ClearLogToolStripMenuItem.Text = "Clear Log";
      this.OpenLogToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("OpenLogToolStripMenuItem.Image");
      this.OpenLogToolStripMenuItem.Name = "OpenLogToolStripMenuItem";
      this.OpenLogToolStripMenuItem.Size = new Size(226, 26);
      this.OpenLogToolStripMenuItem.Text = "Open Log";
      this.ToolTip.AutoPopDelay = 10000;
      this.ToolTip.InitialDelay = 100;
      this.ToolTip.ReshowDelay = 100;
      this.PictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox1.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox1.Cursor = Cursors.Hand;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      this.PictureBox1.Location = new Point(30, 401);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(99, 31);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 9;
      this.PictureBox1.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox1, "Donate to the project");
      this.PictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox2.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox2.Image = (Image) componentResourceManager.GetObject("PictureBox2.Image");
      this.PictureBox2.Location = new Point(5, 408);
      this.PictureBox2.Name = "PictureBox2";
      this.PictureBox2.Size = new Size(19, 20);
      this.PictureBox2.TabIndex = 32;
      this.PictureBox2.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox2, "About");
      this.ComboSSstart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboSSstart.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboSSstart.FlatStyle = FlatStyle.Popup;
      this.ComboSSstart.FormattingEnabled = true;
      this.ComboSSstart.Items.AddRange(new object[38]
      {
        (object) "0",
        (object) "0.7",
        (object) "0.75",
        (object) "0.8",
        (object) "0.85",
        (object) "0.9",
        (object) "0.95",
        (object) "1.0",
        (object) "1.05",
        (object) "1.1",
        (object) "1.15",
        (object) "1.2",
        (object) "1.25",
        (object) "1.3",
        (object) "1.35",
        (object) "1.4",
        (object) "1.45",
        (object) "1.5",
        (object) "1.55",
        (object) "1.6",
        (object) "1.65",
        (object) "1.7",
        (object) "1.75",
        (object) "1.8",
        (object) "1.85",
        (object) "1.9",
        (object) "1.95",
        (object) "2.0",
        (object) "2.05",
        (object) "2.1",
        (object) "2.15",
        (object) "2.2",
        (object) "2.25",
        (object) "2.3",
        (object) "2.35",
        (object) "2.4",
        (object) "2.45",
        (object) "2.5"
      });
      this.ComboSSstart.Location = new Point(167, 39);
      this.ComboSSstart.Name = "ComboSSstart";
      this.ComboSSstart.Size = new Size(116, 23);
      this.ComboSSstart.Sorted = true;
      this.ComboSSstart.TabIndex = 11;
      this.ComboSSstart.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.ComboSSstart, "This is the Super Sampling modifier set on startup. All VR apps that do not have a profile will inherit this setting");
      this.ComboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox1.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox1.FlatStyle = FlatStyle.Popup;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Items.AddRange(new object[7]
      {
        (object) "18 Hz",
        (object) "30 Hz",
        (object) "45 Hz",
        (object) "45 Hz forced",
        (object) "Adaptive",
        (object) "Auto",
        (object) "Off"
      });
      this.ComboBox1.Location = new Point(167, 72);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(116, 23);
      this.ComboBox1.Sorted = true;
      this.ComboBox1.TabIndex = 25;
      this.ComboBox1.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.ComboBox1, "This is the ASW mode set on startup. All VR apps that do not have a profile will inherit this setting");
      this.Label1.Dock = DockStyle.Fill;
      this.Label1.Location = new Point(4, 34);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(156, 32);
      this.Label1.TabIndex = 21;
      this.Label1.Text = "Default Super Sampling";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip((Control) this.Label1, "This is the Super Sampling modifier set on startup. All VR apps that do not have a profile will inherit this setting");
      this.Label6.Dock = DockStyle.Fill;
      this.Label6.Location = new Point(4, 67);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(156, 32);
      this.Label6.TabIndex = 26;
      this.Label6.Text = "Default ASW Mode";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip((Control) this.Label6, "This is the ASW mode set on startup. All VR apps that do not have a profile will inherit this setting");
      this.ComboHomless.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboHomless.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboHomless.FlatStyle = FlatStyle.Popup;
      this.ComboHomless.FormattingEnabled = true;
      this.ComboHomless.Items.AddRange(new object[2]
      {
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboHomless.Location = new Point(167, 202);
      this.ComboHomless.Name = "ComboHomless";
      this.ComboHomless.Size = new Size(116, 23);
      this.ComboHomless.TabIndex = 37;
      this.ToolTip.SetToolTip((Control) this.ComboHomless, "Enable or Disable Oculus Homeless");
      this.Label5.Dock = DockStyle.Fill;
      this.Label5.Location = new Point(4, 166);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(156, 32);
      this.Label5.TabIndex = 12;
      this.Label5.Text = "Voice Commands";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip((Control) this.Label5, "Enable voice commands");
      this.ComboVoice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboVoice.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboVoice.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboVoice.FlatStyle = FlatStyle.Popup;
      this.ComboVoice.FormattingEnabled = true;
      this.ComboVoice.Items.AddRange(new object[2]
      {
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboVoice.Location = new Point(167, 171);
      this.ComboVoice.Name = "ComboVoice";
      this.ComboVoice.Size = new Size(116, 23);
      this.ComboVoice.TabIndex = 13;
      this.ComboVoice.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.ComboVoice, "Enable Voice commands");
      this.BtnVoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnVoice.FlatStyle = FlatStyle.Flat;
      this.BtnVoice.Location = new Point(290, 169);
      this.BtnVoice.Name = "BtnVoice";
      this.BtnVoice.Size = new Size(59, 26);
      this.BtnVoice.TabIndex = 24;
      this.BtnVoice.TabStop = false;
      this.BtnVoice.Text = "Edit";
      this.ToolTip.SetToolTip((Control) this.BtnVoice, "Configure Voice Commands");
      this.BtnVoice.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Location = new Point(290, 136);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(59, 26);
      this.Button2.TabIndex = 34;
      this.Button2.TabStop = false;
      this.Button2.Text = "Save";
      this.ToolTip.SetToolTip((Control) this.Button2, "Sets the FOV on your regular 2D display. Useful when streaming gameplay.\r\nDoes not affect FOV in the Rift itself.");
      this.Button2.UseVisualStyleBackColor = true;
      this.PictureBox8.Anchor = AnchorStyles.None;
      this.PictureBox8.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox8.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox8.Image = (Image) componentResourceManager.GetObject("PictureBox8.Image");
      this.PictureBox8.Location = new Point(310, 7);
      this.PictureBox8.Name = "PictureBox8";
      this.PictureBox8.Size = new Size(19, 20);
      this.PictureBox8.TabIndex = 53;
      this.PictureBox8.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox8, "Create a Profile with custom settings for each of your games.");
      this.CheckRiftAudio.Dock = DockStyle.Fill;
      this.CheckRiftAudio.Location = new Point(4, 90);
      this.CheckRiftAudio.Name = "CheckRiftAudio";
      this.CheckRiftAudio.Size = new Size(153, 36);
      this.CheckRiftAudio.TabIndex = 7;
      this.CheckRiftAudio.TabStop = false;
      this.CheckRiftAudio.Text = "Use Audio Switcher";
      this.ToolTip.SetToolTip((Control) this.CheckRiftAudio, "Check to have the Rift set as default device for Audio and/or Mic when Oculus Home starts");
      this.CheckRiftAudio.UseVisualStyleBackColor = true;
      this.CheckSpoofCPU.Dock = DockStyle.Fill;
      this.CheckSpoofCPU.Location = new Point(4, 214);
      this.CheckSpoofCPU.Name = "CheckSpoofCPU";
      this.CheckSpoofCPU.Size = new Size(322, 23);
      this.CheckSpoofCPU.TabIndex = 27;
      this.CheckSpoofCPU.TabStop = false;
      this.CheckSpoofCPU.Text = "Spoof CPU ID on tool start";
      this.ToolTip.SetToolTip((Control) this.CheckSpoofCPU, "Check to spoof the CPU ID. Makes Oculus nag screen regarding minimum specs go away. Takes affect immediately when checked and forces a restart of the OVR service.");
      this.CheckSpoofCPU.UseVisualStyleBackColor = true;
      this.ButtonRestartOVR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ButtonRestartOVR.FlatAppearance.BorderSize = 0;
      this.ButtonRestartOVR.FlatStyle = FlatStyle.Flat;
      this.ButtonRestartOVR.Image = (Image) componentResourceManager.GetObject("ButtonRestartOVR.Image");
      this.ButtonRestartOVR.Location = new Point(292, 3);
      this.ButtonRestartOVR.Name = "ButtonRestartOVR";
      this.ButtonRestartOVR.Size = new Size(52, 55);
      this.ButtonRestartOVR.TabIndex = 16;
      this.ButtonRestartOVR.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.ButtonRestartOVR, "Restart the Oculus service if it is running");
      this.ButtonRestartOVR.UseVisualStyleBackColor = true;
      this.ButtonStartOVR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ButtonStartOVR.FlatAppearance.BorderSize = 0;
      this.ButtonStartOVR.FlatStyle = FlatStyle.Flat;
      this.ButtonStartOVR.Image = (Image) componentResourceManager.GetObject("ButtonStartOVR.Image");
      this.ButtonStartOVR.Location = new Point(183, 3);
      this.ButtonStartOVR.Name = "ButtonStartOVR";
      this.ButtonStartOVR.Size = new Size(50, 55);
      this.ButtonStartOVR.TabIndex = 14;
      this.ButtonStartOVR.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.ButtonStartOVR, "Start the Oculus service if it is down");
      this.ButtonStartOVR.UseVisualStyleBackColor = true;
      this.ButtonStopOVR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ButtonStopOVR.FlatAppearance.BorderSize = 0;
      this.ButtonStopOVR.FlatStyle = FlatStyle.Flat;
      this.ButtonStopOVR.Image = (Image) componentResourceManager.GetObject("ButtonStopOVR.Image");
      this.ButtonStopOVR.Location = new Point(239, 3);
      this.ButtonStopOVR.Name = "ButtonStopOVR";
      this.ButtonStopOVR.Size = new Size(47, 55);
      this.ButtonStopOVR.TabIndex = 15;
      this.ButtonStopOVR.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.ButtonStopOVR, "Stop the Oculus service if it is running");
      this.ButtonStopOVR.UseVisualStyleBackColor = true;
      this.Label29.Dock = DockStyle.Fill;
      this.Label29.Location = new Point(4, 345);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(155, 50);
      this.Label29.TabIndex = 38;
      this.Label29.Text = "Game Library";
      this.Label29.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip((Control) this.Label29, "Enable voice commands");
      this.CheckLocalDebug.AutoSize = true;
      this.CheckLocalDebug.Dock = DockStyle.Fill;
      this.CheckLocalDebug.Location = new Point(166, 4);
      this.CheckLocalDebug.Name = "CheckLocalDebug";
      this.CheckLocalDebug.RightToLeft = RightToLeft.No;
      this.CheckLocalDebug.Size = new Size(156, 41);
      this.CheckLocalDebug.TabIndex = 0;
      this.CheckLocalDebug.Text = "Use OTT Local";
      this.ToolTip.SetToolTip((Control) this.CheckLocalDebug, "Use the Oculus Debug Tool shipped with OTT. Don't check this box unless you know what you are doing as it could potantially break functionality.");
      this.CheckLocalDebug.UseVisualStyleBackColor = true;
      this.CheckStartWatcher.AutoSize = true;
      this.CheckStartWatcher.Dock = DockStyle.Fill;
      this.CheckStartWatcher.Location = new Point(166, 52);
      this.CheckStartWatcher.Name = "CheckStartWatcher";
      this.CheckStartWatcher.Size = new Size(156, 41);
      this.CheckStartWatcher.TabIndex = 4;
      this.CheckStartWatcher.Text = "Start on OTT Start";
      this.ToolTip.SetToolTip((Control) this.CheckStartWatcher, componentResourceManager.GetString("CheckStartWatcher.ToolTip"));
      this.CheckStartWatcher.UseVisualStyleBackColor = true;
      this.Label13.AutoSize = true;
      this.Label13.Dock = DockStyle.Fill;
      this.Label13.Location = new Point(4, 1);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(155, 47);
      this.Label13.TabIndex = 31;
      this.Label13.Text = "Oculus Debug Tool";
      this.Label13.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip((Control) this.Label13, "Use the Oculus Debug Tool shipped with OTT. Don't check this box unless you know what you are doing as it could potantially break functionality.");
      this.Label18.AutoSize = true;
      this.Label18.Dock = DockStyle.Fill;
      this.Label18.Location = new Point(4, 49);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(155, 47);
      this.Label18.TabIndex = 32;
      this.Label18.Text = " AppWatcher";
      this.Label18.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip((Control) this.Label18, componentResourceManager.GetString("Label18.ToolTip"));
      this.Button4.Dock = DockStyle.Fill;
      this.Button4.FlatStyle = FlatStyle.Flat;
      this.Button4.Location = new Point(166, 100);
      this.Button4.Name = "Button4";
      this.Button4.Size = new Size(156, 41);
      this.Button4.TabIndex = 3;
      this.Button4.Text = "Reset all to default";
      this.ToolTip.SetToolTip((Control) this.Button4, "Reset all settings to Default");
      this.Button4.UseVisualStyleBackColor = true;
      this.BtnRemoveAllProfiles.Dock = DockStyle.Fill;
      this.BtnRemoveAllProfiles.FlatStyle = FlatStyle.Flat;
      this.BtnRemoveAllProfiles.Location = new Point(166, 148);
      this.BtnRemoveAllProfiles.Name = "BtnRemoveAllProfiles";
      this.BtnRemoveAllProfiles.Size = new Size(156, 41);
      this.BtnRemoveAllProfiles.TabIndex = 5;
      this.BtnRemoveAllProfiles.Text = "Remove all";
      this.ToolTip.SetToolTip((Control) this.BtnRemoveAllProfiles, "Remove all Profiles");
      this.BtnRemoveAllProfiles.UseVisualStyleBackColor = true;
      this.Button1.Dock = DockStyle.Fill;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(166, 196);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(156, 41);
      this.Button1.TabIndex = 6;
      this.Button1.Text = "Check for updates";
      this.ToolTip.SetToolTip((Control) this.Button1, "Manually check if there's any updates available");
      this.Button1.UseVisualStyleBackColor = true;
      this.Button5.Dock = DockStyle.Fill;
      this.Button5.FlatStyle = FlatStyle.Flat;
      this.Button5.Location = new Point(166, 244);
      this.Button5.Name = "Button5";
      this.Button5.Size = new Size(156, 44);
      this.Button5.TabIndex = 7;
      this.Button5.Text = "Restart in Debug mode";
      this.ToolTip.SetToolTip((Control) this.Button5, "Restart in Debug mode for additional logging");
      this.Button5.UseVisualStyleBackColor = true;
      this.PictureBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox7.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox7.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox7.Image = (Image) componentResourceManager.GetObject("PictureBox7.Image");
      this.PictureBox7.Location = new Point(314, 133);
      this.PictureBox7.Name = "PictureBox7";
      this.PictureBox7.Size = new Size(19, 20);
      this.PictureBox7.TabIndex = 37;
      this.PictureBox7.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox7, "Override distortion curvature. Higher curvature gives higher pixel density in center.");
      this.PictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox6.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox6.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox6.Image = (Image) componentResourceManager.GetObject("PictureBox6.Image");
      this.PictureBox6.Location = new Point(314, 199);
      this.PictureBox6.Name = "PictureBox6";
      this.PictureBox6.Size = new Size(19, 20);
      this.PictureBox6.TabIndex = 36;
      this.PictureBox6.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox6, "Override encoding bitrate");
      this.PictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox5.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox5.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox5.Image = (Image) componentResourceManager.GetObject("PictureBox5.Image");
      this.PictureBox5.Location = new Point(314, 265);
      this.PictureBox5.Name = "PictureBox5";
      this.PictureBox5.Size = new Size(19, 20);
      this.PictureBox5.TabIndex = 35;
      this.PictureBox5.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox5, "Override maximum dynamic bitrate");
      this.PictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox4.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox4.Image = (Image) componentResourceManager.GetObject("PictureBox4.Image");
      this.PictureBox4.Location = new Point(314, 232);
      this.PictureBox4.Name = "PictureBox4";
      this.PictureBox4.Size = new Size(19, 20);
      this.PictureBox4.TabIndex = 34;
      this.PictureBox4.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox4, "Automatically adjust bitrate");
      this.PictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox3.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox3.Image = (Image) componentResourceManager.GetObject("PictureBox3.Image");
      this.PictureBox3.Location = new Point(314, 336);
      this.PictureBox3.Name = "PictureBox3";
      this.PictureBox3.Size = new Size(19, 20);
      this.PictureBox3.TabIndex = 33;
      this.PictureBox3.TabStop = false;
      this.ToolTip.SetToolTip((Control) this.PictureBox3, "Uses Paolod29's code to patch AirLink and make it permanently enabled.\r\nYou need to run this again if the Oculus App is updated.\r\nCheck out https://github.com/pd29/oculus-airlink-enabler \r\nfor more.");
      this.Button11.Enabled = false;
      this.Button11.FlatStyle = FlatStyle.Flat;
      this.Button11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button11.Location = new Point(314, 98);
      this.Button11.Name = "Button11";
      this.Button11.Size = new Size(22, 22);
      this.Button11.TabIndex = 11;
      this.Button11.Text = "+";
      this.ToolTip.SetToolTip((Control) this.Button11, "Create Custom Preset");
      this.Button11.UseVisualStyleBackColor = true;
      this.Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label8.AutoSize = true;
      this.Label8.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label8.ForeColor = System.Drawing.Color.DarkRed;
      this.Label8.Location = new Point(432, 0);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(68, 12);
      this.Label8.TabIndex = 7;
      this.Label8.Text = "By ApollyonVR";
      this.NotificationTimer.Interval = 1500;
      this.ImageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("ImageList1.ImageStream");
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
      this.NotifyIcon3.Icon = (Icon) componentResourceManager.GetObject("NotifyIcon3.Icon");
      this.NotifyIcon3.Text = "Oculus Home";
      this.PowerPlanTimer.Interval = 2000;
      this.DotNetBarTabcontrol1.Alignment = TabAlignment.Left;
      this.DotNetBarTabcontrol1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage1);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage2);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage3);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage4);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage5);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage7);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage8);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage6);
      this.DotNetBarTabcontrol1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.DotNetBarTabcontrol1.ImageList = this.ImageList1;
      this.DotNetBarTabcontrol1.ItemSize = new Size(43, 135);
      this.DotNetBarTabcontrol1.Location = new Point(0, 0);
      this.DotNetBarTabcontrol1.Multiline = true;
      this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
      this.DotNetBarTabcontrol1.Padding = new Point(6, 8);
      this.DotNetBarTabcontrol1.SelectedIndex = 0;
      this.DotNetBarTabcontrol1.Size = new Size(508, 433);
      this.DotNetBarTabcontrol1.SizeMode = TabSizeMode.Fixed;
      this.DotNetBarTabcontrol1.TabIndex = 29;
      this.TabPage1.BackColor = System.Drawing.Color.White;
      this.TabPage1.Controls.Add((Control) this.GroupBox14);
      this.TabPage1.Location = new Point(139, 4);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Padding = new Padding(3);
      this.TabPage1.Size = new Size(365, 425);
      this.TabPage1.TabIndex = 0;
      this.TabPage1.Text = "Game Settings";
      this.GroupBox14.Controls.Add((Control) this.DbLayoutPanel2);
      this.GroupBox14.Dock = DockStyle.Fill;
      this.GroupBox14.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox14.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox14.Location = new Point(3, 3);
      this.GroupBox14.Name = "GroupBox14";
      this.GroupBox14.Size = new Size(359, 419);
      this.GroupBox14.TabIndex = 0;
      this.GroupBox14.TabStop = false;
      this.DbLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel2.ColumnCount = 3;
      this.DbLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.5356f));
      this.DbLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.12687f));
      this.DbLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.33753f));
      this.DbLayoutPanel2.Controls.Add((Control) this.Label19, 0, 9);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label7, 0, 0);
      this.DbLayoutPanel2.Controls.Add((Control) this.BtnProfiles, 1, 0);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboSSstart, 1, 1);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboBox1, 1, 2);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label1, 0, 1);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label6, 0, 2);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label9, 0, 8);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label17, 0, 7);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboMirrorHome, 1, 7);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label16, 0, 6);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboHomless, 1, 6);
      this.DbLayoutPanel2.Controls.Add((Control) this.BtnHomless, 2, 6);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label5, 0, 5);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboVoice, 1, 5);
      this.DbLayoutPanel2.Controls.Add((Control) this.BtnVoice, 2, 5);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label15, 0, 4);
      this.DbLayoutPanel2.Controls.Add((Control) this.Button2, 2, 4);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label35, 0, 3);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboVisualHUD, 1, 8);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboBox5, 1, 3);
      this.DbLayoutPanel2.Controls.Add((Control) this.SplitContainer1, 1, 4);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboOVRPrio, 1, 9);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label33, 0, 10);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboBox8, 1, 10);
      this.DbLayoutPanel2.Controls.Add((Control) this.ComboBox9, 1, 11);
      this.DbLayoutPanel2.Controls.Add((Control) this.Label37, 0, 11);
      this.DbLayoutPanel2.Controls.Add((Control) this.PictureBox8, 2, 0);
      this.DbLayoutPanel2.Dock = DockStyle.Fill;
      this.DbLayoutPanel2.Location = new Point(3, 17);
      this.DbLayoutPanel2.Name = "DbLayoutPanel2";
      this.DbLayoutPanel2.RowCount = 12;
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.Size = new Size(353, 399);
      this.DbLayoutPanel2.TabIndex = 1;
      this.Label19.Dock = DockStyle.Fill;
      this.Label19.Location = new Point(4, 298);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(156, 32);
      this.Label19.TabIndex = 47;
      this.Label19.Text = "OVR Server Priority";
      this.Label19.TextAlign = ContentAlignment.MiddleLeft;
      this.Label7.Dock = DockStyle.Fill;
      this.Label7.Location = new Point(4, 1);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(156, 32);
      this.Label7.TabIndex = 16;
      this.Label7.Text = "Profiles";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      this.BtnProfiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnProfiles.FlatStyle = FlatStyle.Flat;
      this.BtnProfiles.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnProfiles.Location = new Point(167, 4);
      this.BtnProfiles.Name = "BtnProfiles";
      this.BtnProfiles.Size = new Size(116, 26);
      this.BtnProfiles.TabIndex = 10;
      this.BtnProfiles.TabStop = false;
      this.BtnProfiles.Text = "View && Edit";
      this.BtnProfiles.UseVisualStyleBackColor = true;
      this.Label9.Dock = DockStyle.Fill;
      this.Label9.Location = new Point(4, 265);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(156, 32);
      this.Label9.TabIndex = 39;
      this.Label9.Text = "Visual HUD";
      this.Label9.TextAlign = ContentAlignment.MiddleLeft;
      this.Label17.AutoSize = true;
      this.Label17.Dock = DockStyle.Fill;
      this.Label17.Location = new Point(4, 232);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(156, 32);
      this.Label17.TabIndex = 41;
      this.Label17.Text = "Mirror Oculus Home";
      this.Label17.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboMirrorHome.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboMirrorHome.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboMirrorHome.FlatStyle = FlatStyle.Popup;
      this.ComboMirrorHome.FormattingEnabled = true;
      this.ComboMirrorHome.Items.AddRange(new object[2]
      {
        (object) "Enabled",
        (object) "Disabled"
      });
      this.ComboMirrorHome.Location = new Point(167, 235);
      this.ComboMirrorHome.Name = "ComboMirrorHome";
      this.ComboMirrorHome.Size = new Size(116, 23);
      this.ComboMirrorHome.TabIndex = 42;
      this.Label16.AutoSize = true;
      this.Label16.Dock = DockStyle.Fill;
      this.Label16.Location = new Point(4, 199);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(156, 32);
      this.Label16.TabIndex = 36;
      this.Label16.Text = "Oculus Homeless";
      this.Label16.TextAlign = ContentAlignment.MiddleLeft;
      this.BtnHomless.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnHomless.Enabled = false;
      this.BtnHomless.FlatStyle = FlatStyle.Flat;
      this.BtnHomless.Location = new Point(290, 202);
      this.BtnHomless.Name = "BtnHomless";
      this.BtnHomless.Size = new Size(59, 26);
      this.BtnHomless.TabIndex = 38;
      this.BtnHomless.Text = "Edit";
      this.BtnHomless.UseVisualStyleBackColor = true;
      this.Label15.Dock = DockStyle.Fill;
      this.Label15.Location = new Point(4, 133);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(156, 32);
      this.Label15.TabIndex = 32;
      this.Label15.Text = "FoV Multiplier";
      this.Label15.TextAlign = ContentAlignment.MiddleLeft;
      this.Label35.AutoSize = true;
      this.Label35.Dock = DockStyle.Fill;
      this.Label35.Location = new Point(4, 100);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(156, 32);
      this.Label35.TabIndex = 44;
      this.Label35.Text = "Adaptive GPU Scaling";
      this.Label35.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboVisualHUD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboVisualHUD.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboVisualHUD.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboVisualHUD.DropDownWidth = 180;
      this.ComboVisualHUD.FlatStyle = FlatStyle.Popup;
      this.ComboVisualHUD.FormattingEnabled = true;
      this.ComboVisualHUD.Items.AddRange(new object[8]
      {
        (object) "None",
        (object) "Pixel Density",
        (object) "Performance",
        (object) "ASW Status",
        (object) "Latency Timing",
        (object) "Application Render Timing",
        (object) "Compositor Render Timing",
        (object) "Version Info"
      });
      this.ComboVisualHUD.Location = new Point(167, 270);
      this.ComboVisualHUD.Name = "ComboVisualHUD";
      this.ComboVisualHUD.Size = new Size(116, 23);
      this.ComboVisualHUD.TabIndex = 40;
      this.ComboBox5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox5.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox5.FlatStyle = FlatStyle.Popup;
      this.ComboBox5.FormattingEnabled = true;
      this.ComboBox5.Items.AddRange(new object[2]
      {
        (object) "On",
        (object) "Off"
      });
      this.ComboBox5.Location = new Point(167, 105);
      this.ComboBox5.Name = "ComboBox5";
      this.ComboBox5.Size = new Size(116, 23);
      this.ComboBox5.TabIndex = 45;
      this.ComboBox5.TabStop = false;
      this.SplitContainer1.Dock = DockStyle.Fill;
      this.SplitContainer1.Location = new Point(167, 136);
      this.SplitContainer1.Name = "SplitContainer1";
      this.SplitContainer1.Panel1.Controls.Add((Control) this.NumericFOVh);
      this.SplitContainer1.Panel2.Controls.Add((Control) this.NumericFOVv);
      this.SplitContainer1.Size = new Size(116, 26);
      this.SplitContainer1.SplitterDistance = 53;
      this.SplitContainer1.TabIndex = 46;
      this.NumericFOVh.Anchor = AnchorStyles.None;
      this.NumericFOVh.DecimalPlaces = 2;
      this.NumericFOVh.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        131072
      });
      this.NumericFOVh.Location = new Point(1, 3);
      this.NumericFOVh.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.NumericFOVh.Name = "NumericFOVh";
      this.NumericFOVh.Size = new Size(52, 21);
      this.NumericFOVh.TabIndex = 33;
      this.NumericFOVv.Anchor = AnchorStyles.None;
      this.NumericFOVv.DecimalPlaces = 2;
      this.NumericFOVv.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        131072
      });
      this.NumericFOVv.Location = new Point(2, 3);
      this.NumericFOVv.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.NumericFOVv.Name = "NumericFOVv";
      this.NumericFOVv.Size = new Size(54, 21);
      this.NumericFOVv.TabIndex = 34;
      this.ComboOVRPrio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboOVRPrio.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboOVRPrio.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboOVRPrio.DropDownWidth = 180;
      this.ComboOVRPrio.FlatStyle = FlatStyle.Popup;
      this.ComboOVRPrio.FormattingEnabled = true;
      this.ComboOVRPrio.Items.AddRange(new object[4]
      {
        (object) "Normal",
        (object) "Above normal",
        (object) "High",
        (object) "Realtime"
      });
      this.ComboOVRPrio.Location = new Point(167, 303);
      this.ComboOVRPrio.Name = "ComboOVRPrio";
      this.ComboOVRPrio.Size = new Size(116, 23);
      this.ComboOVRPrio.TabIndex = 48;
      this.Label33.AutoSize = true;
      this.Label33.Dock = DockStyle.Fill;
      this.Label33.Location = new Point(4, 331);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(156, 32);
      this.Label33.TabIndex = 49;
      this.Label33.Text = "Force MipMap On Layers";
      this.Label33.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox8.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox8.Dock = DockStyle.Fill;
      this.ComboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox8.FlatStyle = FlatStyle.Popup;
      this.ComboBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox8.FormattingEnabled = true;
      this.ComboBox8.Items.AddRange(new object[2]
      {
        (object) "True",
        (object) "False"
      });
      this.ComboBox8.Location = new Point(167, 334);
      this.ComboBox8.Name = "ComboBox8";
      this.ComboBox8.Size = new Size(116, 24);
      this.ComboBox8.TabIndex = 50;
      this.ComboBox9.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox9.Dock = DockStyle.Fill;
      this.ComboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox9.FlatStyle = FlatStyle.Popup;
      this.ComboBox9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox9.FormattingEnabled = true;
      this.ComboBox9.Items.AddRange(new object[21]
      {
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20"
      });
      this.ComboBox9.Location = new Point(167, 367);
      this.ComboBox9.Name = "ComboBox9";
      this.ComboBox9.Size = new Size(116, 24);
      this.ComboBox9.TabIndex = 52;
      this.Label37.AutoSize = true;
      this.Label37.Dock = DockStyle.Fill;
      this.Label37.Location = new Point(4, 364);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(156, 34);
      this.Label37.TabIndex = 51;
      this.Label37.Text = "Offset MipMap On Layers";
      this.Label37.TextAlign = ContentAlignment.MiddleLeft;
      this.TabPage2.BackColor = System.Drawing.Color.White;
      this.TabPage2.Controls.Add((Control) this.GroupBox1);
      this.TabPage2.Location = new Point(139, 4);
      this.TabPage2.Name = "TabPage2";
      this.TabPage2.Padding = new Padding(3);
      this.TabPage2.Size = new Size(365, 425);
      this.TabPage2.TabIndex = 1;
      this.TabPage2.Text = "Tray Tool";
      this.GroupBox1.Controls.Add((Control) this.DbLayoutPanel4);
      this.GroupBox1.Dock = DockStyle.Fill;
      this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox1.ForeColor = SystemColors.ControlText;
      this.GroupBox1.Location = new Point(3, 3);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(359, 419);
      this.GroupBox1.TabIndex = 11;
      this.GroupBox1.TabStop = false;
      this.DbLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel4.ColumnCount = 2;
      this.DbLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191f));
      this.DbLayoutPanel4.Controls.Add((Control) this.CheckStartWindows, 0, 0);
      this.DbLayoutPanel4.Controls.Add((Control) this.CheckStartMin, 0, 1);
      this.DbLayoutPanel4.Controls.Add((Control) this.CheckMinimizeOnX, 0, 4);
      this.DbLayoutPanel4.Controls.Add((Control) this.CheckRiftAudio, 0, 2);
      this.DbLayoutPanel4.Controls.Add((Control) this.CheckBoxAltTab, 0, 3);
      this.DbLayoutPanel4.Controls.Add((Control) this.HotKeysCheckBox, 0, 5);
      this.DbLayoutPanel4.Controls.Add((Control) this.BtnConfigureAudio, 1, 2);
      this.DbLayoutPanel4.Controls.Add((Control) this.Label14, 0, 7);
      this.DbLayoutPanel4.Controls.Add((Control) this.CheckBoxCheckForUpdates, 0, 6);
      this.DbLayoutPanel4.Controls.Add((Control) this.BtnConfigureHotKeys, 1, 5);
      this.DbLayoutPanel4.Controls.Add((Control) this.TrackBar1, 0, 8);
      this.DbLayoutPanel4.Dock = DockStyle.Fill;
      this.DbLayoutPanel4.ForeColor = System.Drawing.Color.DodgerBlue;
      this.DbLayoutPanel4.Location = new Point(3, 17);
      this.DbLayoutPanel4.Name = "DbLayoutPanel4";
      this.DbLayoutPanel4.RowCount = 9;
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.27596f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 2977f * (float) Math.PI / 927f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 8.902077f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.91395f));
      this.DbLayoutPanel4.Size = new Size(353, 399);
      this.DbLayoutPanel4.TabIndex = 12;
      this.CheckStartWindows.AutoSize = true;
      this.CheckStartWindows.Dock = DockStyle.Fill;
      this.CheckStartWindows.Location = new Point(4, 4);
      this.CheckStartWindows.Name = "CheckStartWindows";
      this.CheckStartWindows.Size = new Size(153, 36);
      this.CheckStartWindows.TabIndex = 4;
      this.CheckStartWindows.TabStop = false;
      this.CheckStartWindows.Text = "Start with Windows";
      this.CheckStartWindows.UseVisualStyleBackColor = true;
      this.CheckStartMin.Dock = DockStyle.Fill;
      this.CheckStartMin.Location = new Point(4, 47);
      this.CheckStartMin.Name = "CheckStartMin";
      this.CheckStartMin.Size = new Size(153, 36);
      this.CheckStartMin.TabIndex = 5;
      this.CheckStartMin.TabStop = false;
      this.CheckStartMin.Text = "Start minimized";
      this.CheckStartMin.UseVisualStyleBackColor = true;
      this.CheckMinimizeOnX.Dock = DockStyle.Fill;
      this.CheckMinimizeOnX.Location = new Point(4, 176);
      this.CheckMinimizeOnX.Name = "CheckMinimizeOnX";
      this.CheckMinimizeOnX.Size = new Size(153, 36);
      this.CheckMinimizeOnX.TabIndex = 9;
      this.CheckMinimizeOnX.Text = "Minimize Tool on X";
      this.CheckMinimizeOnX.UseVisualStyleBackColor = true;
      this.CheckBoxAltTab.Dock = DockStyle.Fill;
      this.CheckBoxAltTab.Location = new Point(4, 133);
      this.CheckBoxAltTab.Name = "CheckBoxAltTab";
      this.CheckBoxAltTab.Size = new Size(153, 36);
      this.CheckBoxAltTab.TabIndex = 6;
      this.CheckBoxAltTab.TabStop = false;
      this.CheckBoxAltTab.Text = "Hide from Alt+Tab";
      this.CheckBoxAltTab.UseVisualStyleBackColor = true;
      this.HotKeysCheckBox.Dock = DockStyle.Fill;
      this.HotKeysCheckBox.Location = new Point(4, 219);
      this.HotKeysCheckBox.Name = "HotKeysCheckBox";
      this.HotKeysCheckBox.Size = new Size(153, 36);
      this.HotKeysCheckBox.TabIndex = 27;
      this.HotKeysCheckBox.Text = "Enable HotKeys";
      this.HotKeysCheckBox.UseVisualStyleBackColor = true;
      this.BtnConfigureAudio.Dock = DockStyle.Fill;
      this.BtnConfigureAudio.FlatStyle = FlatStyle.Flat;
      this.BtnConfigureAudio.Location = new Point(164, 90);
      this.BtnConfigureAudio.Name = "BtnConfigureAudio";
      this.BtnConfigureAudio.Size = new Size(185, 36);
      this.BtnConfigureAudio.TabIndex = 29;
      this.BtnConfigureAudio.Text = "Configure";
      this.BtnConfigureAudio.UseVisualStyleBackColor = true;
      this.Label14.AutoSize = true;
      this.Label14.Dock = DockStyle.Fill;
      this.Label14.ImageAlign = ContentAlignment.MiddleRight;
      this.Label14.Location = new Point(4, 298);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(153, 33);
      this.Label14.TabIndex = 28;
      this.Label14.Text = "Font Size: ";
      this.Label14.TextAlign = ContentAlignment.MiddleLeft;
      this.CheckBoxCheckForUpdates.AutoSize = true;
      this.CheckBoxCheckForUpdates.Dock = DockStyle.Fill;
      this.CheckBoxCheckForUpdates.Location = new Point(4, 262);
      this.CheckBoxCheckForUpdates.Name = "CheckBoxCheckForUpdates";
      this.CheckBoxCheckForUpdates.Size = new Size(153, 32);
      this.CheckBoxCheckForUpdates.TabIndex = 30;
      this.CheckBoxCheckForUpdates.Text = "Check for updates on startup";
      this.CheckBoxCheckForUpdates.UseVisualStyleBackColor = true;
      this.BtnConfigureHotKeys.Dock = DockStyle.Fill;
      this.BtnConfigureHotKeys.FlatStyle = FlatStyle.Flat;
      this.BtnConfigureHotKeys.Location = new Point(164, 219);
      this.BtnConfigureHotKeys.Name = "BtnConfigureHotKeys";
      this.BtnConfigureHotKeys.Size = new Size(185, 36);
      this.BtnConfigureHotKeys.TabIndex = 31;
      this.BtnConfigureHotKeys.Text = "Configure";
      this.BtnConfigureHotKeys.UseVisualStyleBackColor = true;
      this.TrackBar1.Dock = DockStyle.Fill;
      this.TrackBar1.Location = new Point(4, 335);
      this.TrackBar1.Maximum = 12;
      this.TrackBar1.Minimum = 8;
      this.TrackBar1.Name = "TrackBar1";
      this.TrackBar1.Size = new Size(153, 60);
      this.TrackBar1.TabIndex = 26;
      this.TrackBar1.Value = 8;
      this.TabPage3.BackColor = System.Drawing.Color.White;
      this.TabPage3.Controls.Add((Control) this.GroupBox2);
      this.TabPage3.Location = new Point(139, 4);
      this.TabPage3.Name = "TabPage3";
      this.TabPage3.Padding = new Padding(3);
      this.TabPage3.Size = new Size(365, 425);
      this.TabPage3.TabIndex = 2;
      this.TabPage3.Text = "Power Options";
      this.GroupBox2.Controls.Add((Control) this.DbLayoutPanel5);
      this.GroupBox2.Dock = DockStyle.Fill;
      this.GroupBox2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox2.Location = new Point(3, 3);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(359, 419);
      this.GroupBox2.TabIndex = 3;
      this.GroupBox2.TabStop = false;
      this.DbLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel5.ColumnCount = 2;
      this.DbLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.13433f));
      this.DbLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.86567f));
      this.DbLayoutPanel5.Controls.Add((Control) this.ComboApplyPlan, 1, 2);
      this.DbLayoutPanel5.Controls.Add((Control) this.Label4, 0, 3);
      this.DbLayoutPanel5.Controls.Add((Control) this.ComboPowerPlanExit, 1, 1);
      this.DbLayoutPanel5.Controls.Add((Control) this.Label2, 0, 0);
      this.DbLayoutPanel5.Controls.Add((Control) this.ComboPowerPlanStart, 1, 0);
      this.DbLayoutPanel5.Controls.Add((Control) this.Label22, 0, 1);
      this.DbLayoutPanel5.Controls.Add((Control) this.Label3, 0, 2);
      this.DbLayoutPanel5.Controls.Add((Control) this.Label23, 0, 4);
      this.DbLayoutPanel5.Controls.Add((Control) this.CheckSensorPower, 1, 4);
      this.DbLayoutPanel5.Controls.Add((Control) this.ComboUSBsusp, 1, 3);
      this.DbLayoutPanel5.Dock = DockStyle.Fill;
      this.DbLayoutPanel5.Location = new Point(3, 17);
      this.DbLayoutPanel5.Name = "DbLayoutPanel5";
      this.DbLayoutPanel5.RowCount = 5;
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.DbLayoutPanel5.Size = new Size(353, 399);
      this.DbLayoutPanel5.TabIndex = 4;
      this.ComboApplyPlan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboApplyPlan.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboApplyPlan.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboApplyPlan.FlatStyle = FlatStyle.Popup;
      this.ComboApplyPlan.FormattingEnabled = true;
      this.ComboApplyPlan.Items.AddRange(new object[2]
      {
        (object) "OTT Start/Exit",
        (object) "Oculus Home Start/Exit"
      });
      this.ComboApplyPlan.Location = new Point(190, 187);
      this.ComboApplyPlan.Name = "ComboApplyPlan";
      this.ComboApplyPlan.Size = new Size(159, 23);
      this.ComboApplyPlan.TabIndex = 20;
      this.ComboApplyPlan.TabStop = false;
      this.Label4.Dock = DockStyle.Fill;
      this.Label4.Location = new Point(4, 238);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(179, 78);
      this.Label4.TabIndex = 18;
      this.Label4.Text = "USB Selective Suspend";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboPowerPlanExit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboPowerPlanExit.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboPowerPlanExit.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboPowerPlanExit.FlatStyle = FlatStyle.Popup;
      this.ComboPowerPlanExit.FormattingEnabled = true;
      this.ComboPowerPlanExit.Location = new Point(190, 108);
      this.ComboPowerPlanExit.Name = "ComboPowerPlanExit";
      this.ComboPowerPlanExit.Size = new Size(159, 23);
      this.ComboPowerPlanExit.TabIndex = 12;
      this.ComboPowerPlanExit.TabStop = false;
      this.Label2.Dock = DockStyle.Fill;
      this.Label2.Location = new Point(4, 1);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(179, 78);
      this.Label2.TabIndex = 6;
      this.Label2.Text = "Set Power Plan on Start";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboPowerPlanStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboPowerPlanStart.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboPowerPlanStart.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboPowerPlanStart.FlatStyle = FlatStyle.Popup;
      this.ComboPowerPlanStart.FormattingEnabled = true;
      this.ComboPowerPlanStart.Location = new Point(190, 28);
      this.ComboPowerPlanStart.Name = "ComboPowerPlanStart";
      this.ComboPowerPlanStart.Size = new Size(159, 23);
      this.ComboPowerPlanStart.TabIndex = 6;
      this.ComboPowerPlanStart.TabStop = false;
      this.Label22.AutoSize = true;
      this.Label22.Dock = DockStyle.Fill;
      this.Label22.Location = new Point(4, 80);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(179, 78);
      this.Label22.TabIndex = 14;
      this.Label22.Text = "Set Power Plan on Exit";
      this.Label22.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.AutoSize = true;
      this.Label3.Dock = DockStyle.Fill;
      this.Label3.Location = new Point(4, 159);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(179, 78);
      this.Label3.TabIndex = 19;
      this.Label3.Text = "Apply Power Plan on";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.Label23.AutoSize = true;
      this.Label23.Dock = DockStyle.Fill;
      this.Label23.Location = new Point(4, 317);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(179, 81);
      this.Label23.TabIndex = 15;
      this.Label23.Text = "Rift Power Management";
      this.Label23.TextAlign = ContentAlignment.MiddleLeft;
      this.CheckSensorPower.Dock = DockStyle.Fill;
      this.CheckSensorPower.Location = new Point(190, 320);
      this.CheckSensorPower.Name = "CheckSensorPower";
      this.CheckSensorPower.Size = new Size(159, 75);
      this.CheckSensorPower.TabIndex = 10;
      this.CheckSensorPower.TabStop = false;
      this.CheckSensorPower.Text = "Disable on start";
      this.CheckSensorPower.UseVisualStyleBackColor = true;
      this.ComboUSBsusp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboUSBsusp.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboUSBsusp.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboUSBsusp.FlatStyle = FlatStyle.Popup;
      this.ComboUSBsusp.FormattingEnabled = true;
      this.ComboUSBsusp.Items.AddRange(new object[2]
      {
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboUSBsusp.Location = new Point(190, 266);
      this.ComboUSBsusp.Name = "ComboUSBsusp";
      this.ComboUSBsusp.Size = new Size(159, 23);
      this.ComboUSBsusp.TabIndex = 7;
      this.ComboUSBsusp.TabStop = false;
      this.TabPage4.BackColor = System.Drawing.Color.White;
      this.TabPage4.Controls.Add((Control) this.DbLayoutPanel7);
      this.TabPage4.Location = new Point(139, 4);
      this.TabPage4.Name = "TabPage4";
      this.TabPage4.Padding = new Padding(3);
      this.TabPage4.Size = new Size(365, 425);
      this.TabPage4.TabIndex = 3;
      this.TabPage4.Text = "Service & Startup";
      this.DbLayoutPanel7.ColumnCount = 1;
      this.DbLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel7.Controls.Add((Control) this.GroupBox6, 0, 1);
      this.DbLayoutPanel7.Controls.Add((Control) this.GroupBox4, 0, 0);
      this.DbLayoutPanel7.Dock = DockStyle.Fill;
      this.DbLayoutPanel7.Location = new Point(3, 3);
      this.DbLayoutPanel7.Name = "DbLayoutPanel7";
      this.DbLayoutPanel7.RowCount = 2;
      this.DbLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20.97701f));
      this.DbLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 79.02299f));
      this.DbLayoutPanel7.Size = new Size(359, 419);
      this.DbLayoutPanel7.TabIndex = 25;
      this.GroupBox6.Controls.Add((Control) this.DbLayoutPanel8);
      this.GroupBox6.Dock = DockStyle.Fill;
      this.GroupBox6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox6.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox6.Location = new Point(3, 90);
      this.GroupBox6.Name = "GroupBox6";
      this.GroupBox6.Size = new Size(353, 326);
      this.GroupBox6.TabIndex = 24;
      this.GroupBox6.TabStop = false;
      this.DbLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.DbLayoutPanel8.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel8.ColumnCount = 1;
      this.DbLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckStartService, 0, 0);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckStopService, 0, 1);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckSendHomeToTrayOnStart, 0, 9);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckSendHomeToTray, 0, 8);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckSpoofCPU, 0, 7);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckCloseHome, 0, 6);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckLaunchHomeTool, 0, 5);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckLaunchHome, 0, 4);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckRestartSleep, 0, 3);
      this.DbLayoutPanel8.Controls.Add((Control) this.CheckStopServiceHome, 0, 2);
      this.DbLayoutPanel8.Location = new Point(3, 17);
      this.DbLayoutPanel8.Name = "DbLayoutPanel8";
      this.DbLayoutPanel8.RowCount = 10;
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.DbLayoutPanel8.Size = new Size(330, 300);
      this.DbLayoutPanel8.TabIndex = 12;
      this.CheckStartService.Dock = DockStyle.Fill;
      this.CheckStartService.Location = new Point(4, 4);
      this.CheckStartService.Name = "CheckStartService";
      this.CheckStartService.Size = new Size(322, 23);
      this.CheckStartService.TabIndex = 17;
      this.CheckStartService.TabStop = false;
      this.CheckStartService.Text = "Start Oculus service when tool starts";
      this.CheckStartService.UseVisualStyleBackColor = true;
      this.CheckStopService.Dock = DockStyle.Fill;
      this.CheckStopService.Location = new Point(4, 34);
      this.CheckStopService.Name = "CheckStopService";
      this.CheckStopService.Size = new Size(322, 23);
      this.CheckStopService.TabIndex = 18;
      this.CheckStopService.TabStop = false;
      this.CheckStopService.Text = "Stop Oculus service when tool exits";
      this.CheckStopService.UseVisualStyleBackColor = true;
      this.CheckSendHomeToTrayOnStart.Dock = DockStyle.Fill;
      this.CheckSendHomeToTrayOnStart.Location = new Point(4, 274);
      this.CheckSendHomeToTrayOnStart.Name = "CheckSendHomeToTrayOnStart";
      this.CheckSendHomeToTrayOnStart.Size = new Size(322, 22);
      this.CheckSendHomeToTrayOnStart.TabIndex = 30;
      this.CheckSendHomeToTrayOnStart.TabStop = false;
      this.CheckSendHomeToTrayOnStart.Text = "Send Oculus Home to tray when it starts";
      this.CheckSendHomeToTrayOnStart.UseVisualStyleBackColor = true;
      this.CheckSendHomeToTray.Dock = DockStyle.Fill;
      this.CheckSendHomeToTray.Location = new Point(4, 244);
      this.CheckSendHomeToTray.Name = "CheckSendHomeToTray";
      this.CheckSendHomeToTray.Size = new Size(322, 23);
      this.CheckSendHomeToTray.TabIndex = 29;
      this.CheckSendHomeToTray.TabStop = false;
      this.CheckSendHomeToTray.Text = "Send Oculus Home to tray when it's minimized";
      this.CheckSendHomeToTray.UseVisualStyleBackColor = true;
      this.CheckCloseHome.Dock = DockStyle.Fill;
      this.CheckCloseHome.Location = new Point(4, 184);
      this.CheckCloseHome.Name = "CheckCloseHome";
      this.CheckCloseHome.Size = new Size(322, 23);
      this.CheckCloseHome.TabIndex = 21;
      this.CheckCloseHome.TabStop = false;
      this.CheckCloseHome.Text = "Close Oculus Home on tool exit";
      this.CheckCloseHome.UseVisualStyleBackColor = true;
      this.CheckLaunchHomeTool.Dock = DockStyle.Fill;
      this.CheckLaunchHomeTool.Location = new Point(4, 154);
      this.CheckLaunchHomeTool.Name = "CheckLaunchHomeTool";
      this.CheckLaunchHomeTool.Size = new Size(322, 23);
      this.CheckLaunchHomeTool.TabIndex = 20;
      this.CheckLaunchHomeTool.TabStop = false;
      this.CheckLaunchHomeTool.Text = "Launch Oculus Home on tool start";
      this.CheckLaunchHomeTool.UseVisualStyleBackColor = true;
      this.CheckLaunchHome.Dock = DockStyle.Fill;
      this.CheckLaunchHome.Location = new Point(4, 124);
      this.CheckLaunchHome.Name = "CheckLaunchHome";
      this.CheckLaunchHome.Size = new Size(322, 23);
      this.CheckLaunchHome.TabIndex = 19;
      this.CheckLaunchHome.TabStop = false;
      this.CheckLaunchHome.Text = "Launch Oculus Home on service start";
      this.CheckLaunchHome.UseVisualStyleBackColor = true;
      this.CheckRestartSleep.Dock = DockStyle.Fill;
      this.CheckRestartSleep.Location = new Point(4, 94);
      this.CheckRestartSleep.Name = "CheckRestartSleep";
      this.CheckRestartSleep.Size = new Size(322, 23);
      this.CheckRestartSleep.TabIndex = 31;
      this.CheckRestartSleep.Text = "Restart Oculus service when computer wakes up";
      this.CheckRestartSleep.UseVisualStyleBackColor = true;
      this.CheckStopServiceHome.AutoSize = true;
      this.CheckStopServiceHome.Dock = DockStyle.Fill;
      this.CheckStopServiceHome.Location = new Point(4, 64);
      this.CheckStopServiceHome.Name = "CheckStopServiceHome";
      this.CheckStopServiceHome.Size = new Size(322, 23);
      this.CheckStopServiceHome.TabIndex = 32;
      this.CheckStopServiceHome.Text = "Stop Oculus service when Oculus Home is closed";
      this.CheckStopServiceHome.UseVisualStyleBackColor = true;
      this.GroupBox4.Controls.Add((Control) this.DbLayoutPanel6);
      this.GroupBox4.Dock = DockStyle.Fill;
      this.GroupBox4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox4.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox4.Location = new Point(3, 3);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(353, 81);
      this.GroupBox4.TabIndex = 11;
      this.GroupBox4.TabStop = false;
      this.DbLayoutPanel6.ColumnCount = 5;
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.89933f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.11409f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.10738f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.43624f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.10738f));
      this.DbLayoutPanel6.Controls.Add((Control) this.ButtonRestartOVR, 4, 0);
      this.DbLayoutPanel6.Controls.Add((Control) this.LabelServiceStatus, 1, 0);
      this.DbLayoutPanel6.Controls.Add((Control) this.ButtonStartOVR, 2, 0);
      this.DbLayoutPanel6.Controls.Add((Control) this.Label11, 0, 0);
      this.DbLayoutPanel6.Controls.Add((Control) this.ButtonStopOVR, 3, 0);
      this.DbLayoutPanel6.Dock = DockStyle.Fill;
      this.DbLayoutPanel6.Location = new Point(3, 17);
      this.DbLayoutPanel6.Name = "DbLayoutPanel6";
      this.DbLayoutPanel6.RowCount = 1;
      this.DbLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel6.Size = new Size(347, 61);
      this.DbLayoutPanel6.TabIndex = 31;
      this.LabelServiceStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.LabelServiceStatus.AutoSize = true;
      this.LabelServiceStatus.Location = new Point(124, 23);
      this.LabelServiceStatus.Name = "LabelServiceStatus";
      this.LabelServiceStatus.Size = new Size(53, 15);
      this.LabelServiceStatus.TabIndex = 14;
      this.LabelServiceStatus.TextAlign = ContentAlignment.MiddleLeft;
      this.Label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Label11.Location = new Point(3, 0);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(115, 61);
      this.Label11.TabIndex = 25;
      this.Label11.Text = "Oculus Service: ";
      this.Label11.TextAlign = ContentAlignment.MiddleLeft;
      this.TabPage5.BackColor = System.Drawing.Color.White;
      this.TabPage5.Controls.Add((Control) this.GroupBox3);
      this.TabPage5.Location = new Point(139, 4);
      this.TabPage5.Name = "TabPage5";
      this.TabPage5.Padding = new Padding(3);
      this.TabPage5.Size = new Size(365, 425);
      this.TabPage5.TabIndex = 4;
      this.TabPage5.Text = "Log Window";
      this.GroupBox3.Controls.Add((Control) this.ListBox1);
      this.GroupBox3.Dock = DockStyle.Fill;
      this.GroupBox3.Location = new Point(3, 3);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(359, 419);
      this.GroupBox3.TabIndex = 9;
      this.GroupBox3.TabStop = false;
      this.ListBox1.BorderStyle = BorderStyle.None;
      this.ListBox1.ContextMenuStrip = this.ContextMenuStrip2;
      this.ListBox1.Dock = DockStyle.Fill;
      this.ListBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListBox1.ForeColor = System.Drawing.Color.DodgerBlue;
      this.ListBox1.FormattingEnabled = true;
      this.ListBox1.HorizontalScrollbar = true;
      this.ListBox1.ItemHeight = 15;
      this.ListBox1.Location = new Point(3, 17);
      this.ListBox1.Name = "ListBox1";
      this.ListBox1.Size = new Size(353, 399);
      this.ListBox1.TabIndex = 8;
      this.TabPage7.BackColor = System.Drawing.Color.White;
      this.TabPage7.Controls.Add((Control) this.GroupBox7);
      this.TabPage7.Location = new Point(139, 4);
      this.TabPage7.Name = "TabPage7";
      this.TabPage7.Padding = new Padding(3);
      this.TabPage7.Size = new Size(365, 425);
      this.TabPage7.TabIndex = 6;
      this.TabPage7.Text = "Advanced";
      this.GroupBox7.Controls.Add((Control) this.DbLayoutPanel1);
      this.GroupBox7.Dock = DockStyle.Fill;
      this.GroupBox7.Location = new Point(3, 3);
      this.GroupBox7.Name = "GroupBox7";
      this.GroupBox7.Size = new Size(359, 419);
      this.GroupBox7.TabIndex = 10;
      this.GroupBox7.TabStop = false;
      this.DbLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.DbLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel1.ColumnCount = 2;
      this.DbLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.DbLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.DbLayoutPanel1.Controls.Add((Control) this.BtnLibrary, 1, 7);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label29, 0, 7);
      this.DbLayoutPanel1.Controls.Add((Control) this.CheckLocalDebug, 1, 0);
      this.DbLayoutPanel1.Controls.Add((Control) this.CheckStartWatcher, 1, 1);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label13, 0, 0);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label18, 0, 1);
      this.DbLayoutPanel1.Controls.Add((Control) this.Button4, 1, 2);
      this.DbLayoutPanel1.Controls.Add((Control) this.BtnRemoveAllProfiles, 1, 3);
      this.DbLayoutPanel1.Controls.Add((Control) this.Button1, 1, 4);
      this.DbLayoutPanel1.Controls.Add((Control) this.Button5, 1, 5);
      this.DbLayoutPanel1.Controls.Add((Control) this.BtnSteamImport, 1, 6);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label24, 0, 2);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label25, 0, 3);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label26, 0, 4);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label27, 0, 5);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label28, 0, 6);
      this.DbLayoutPanel1.Location = new Point(6, 17);
      this.DbLayoutPanel1.Name = "DbLayoutPanel1";
      this.DbLayoutPanel1.RowCount = 8;
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.1401f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.52657f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.98067f));
      this.DbLayoutPanel1.Size = new Size(326, 396);
      this.DbLayoutPanel1.TabIndex = 0;
      this.BtnLibrary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnLibrary.FlatStyle = FlatStyle.Flat;
      this.BtnLibrary.Location = new Point(166, 348);
      this.BtnLibrary.Name = "BtnLibrary";
      this.BtnLibrary.Size = new Size(156, 44);
      this.BtnLibrary.TabIndex = 29;
      this.BtnLibrary.TabStop = false;
      this.BtnLibrary.Text = "View && Edit";
      this.BtnLibrary.UseVisualStyleBackColor = true;
      this.BtnSteamImport.Dock = DockStyle.Fill;
      this.BtnSteamImport.FlatStyle = FlatStyle.Flat;
      this.BtnSteamImport.Location = new Point(166, 295);
      this.BtnSteamImport.Name = "BtnSteamImport";
      this.BtnSteamImport.Size = new Size(156, 46);
      this.BtnSteamImport.TabIndex = 30;
      this.BtnSteamImport.TabStop = false;
      this.BtnSteamImport.Text = "View && Import";
      this.BtnSteamImport.UseVisualStyleBackColor = true;
      this.Label24.AutoSize = true;
      this.Label24.Dock = DockStyle.Fill;
      this.Label24.Location = new Point(4, 97);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(155, 47);
      this.Label24.TabIndex = 33;
      this.Label24.Text = "Settings";
      this.Label24.TextAlign = ContentAlignment.MiddleLeft;
      this.Label25.AutoSize = true;
      this.Label25.Dock = DockStyle.Fill;
      this.Label25.Location = new Point(4, 145);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(155, 47);
      this.Label25.TabIndex = 34;
      this.Label25.Text = "Profiles";
      this.Label25.TextAlign = ContentAlignment.MiddleLeft;
      this.Label26.AutoSize = true;
      this.Label26.Dock = DockStyle.Fill;
      this.Label26.Location = new Point(4, 193);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(155, 47);
      this.Label26.TabIndex = 35;
      this.Label26.Text = "Updates";
      this.Label26.TextAlign = ContentAlignment.MiddleLeft;
      this.Label27.AutoSize = true;
      this.Label27.Dock = DockStyle.Fill;
      this.Label27.Location = new Point(4, 241);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(155, 50);
      this.Label27.TabIndex = 36;
      this.Label27.Text = "Debug";
      this.Label27.TextAlign = ContentAlignment.MiddleLeft;
      this.Label28.AutoSize = true;
      this.Label28.Dock = DockStyle.Fill;
      this.Label28.Location = new Point(4, 292);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(155, 52);
      this.Label28.TabIndex = 37;
      this.Label28.Text = "Steam Library";
      this.Label28.TextAlign = ContentAlignment.MiddleLeft;
      this.TabPage8.BackColor = System.Drawing.Color.White;
      this.TabPage8.Controls.Add((Control) this.GroupBox5);
      this.TabPage8.Location = new Point(139, 4);
      this.TabPage8.Name = "TabPage8";
      this.TabPage8.Size = new Size(365, 425);
      this.TabPage8.TabIndex = 7;
      this.TabPage8.Text = "Quest Link";
      this.GroupBox5.Controls.Add((Control) this.PictureBox7);
      this.GroupBox5.Controls.Add((Control) this.PictureBox6);
      this.GroupBox5.Controls.Add((Control) this.PictureBox5);
      this.GroupBox5.Controls.Add((Control) this.PictureBox4);
      this.GroupBox5.Controls.Add((Control) this.PictureBox3);
      this.GroupBox5.Controls.Add((Control) this.Button3);
      this.GroupBox5.Controls.Add((Control) this.Button12);
      this.GroupBox5.Controls.Add((Control) this.DbLayoutPanel3);
      this.GroupBox5.Controls.Add((Control) this.Button11);
      this.GroupBox5.Controls.Add((Control) this.Button10);
      this.GroupBox5.Controls.Add((Control) this.Label10);
      this.GroupBox5.Location = new Point(3, 3);
      this.GroupBox5.Name = "GroupBox5";
      this.GroupBox5.Size = new Size(342, 414);
      this.GroupBox5.TabIndex = 10;
      this.GroupBox5.TabStop = false;
      this.Button3.Enabled = false;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.Location = new Point(9, 383);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(56, 25);
      this.Button3.TabIndex = 14;
      this.Button3.Text = "Delete";
      this.Button3.UseVisualStyleBackColor = true;
      this.Button12.FlatStyle = FlatStyle.Flat;
      this.Button12.Location = new Point(280, 383);
      this.Button12.Name = "Button12";
      this.Button12.Size = new Size(56, 25);
      this.Button12.TabIndex = 13;
      this.Button12.Text = "Save";
      this.Button12.UseVisualStyleBackColor = true;
      this.DbLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel3.ColumnCount = 2;
      this.DbLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.33333f));
      this.DbLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.66667f));
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox11, 1, 5);
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox6, 1, 3);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label32, 0, 0);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label30, 0, 1);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label31, 0, 2);
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox4, 1, 0);
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox3, 1, 2);
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox2, 1, 1);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label36, 0, 3);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label38, 0, 4);
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox10, 1, 4);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label21, 0, 7);
      this.DbLayoutPanel3.Controls.Add((Control) this.Button6, 1, 7);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label20, 0, 6);
      this.DbLayoutPanel3.Controls.Add((Control) this.ComboBox7, 1, 6);
      this.DbLayoutPanel3.Controls.Add((Control) this.Label39, 0, 5);
      this.DbLayoutPanel3.Location = new Point(12, 92);
      this.DbLayoutPanel3.Name = "DbLayoutPanel3";
      this.DbLayoutPanel3.RowCount = 8;
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.DbLayoutPanel3.Size = new Size(296, 268);
      this.DbLayoutPanel3.TabIndex = 12;
      this.ComboBox11.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox11.Dock = DockStyle.Fill;
      this.ComboBox11.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox11.FlatStyle = FlatStyle.Popup;
      this.ComboBox11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox11.FormattingEnabled = true;
      this.ComboBox11.Items.AddRange(new object[18]
      {
        (object) "0",
        (object) "150",
        (object) "200",
        (object) "250",
        (object) "300",
        (object) "350",
        (object) "400",
        (object) "450",
        (object) "500",
        (object) "550",
        (object) "600",
        (object) "650",
        (object) "700",
        (object) "750",
        (object) "800",
        (object) "850",
        (object) "900",
        (object) "960"
      });
      this.ComboBox11.Location = new Point(175, 169);
      this.ComboBox11.MaxLength = 4;
      this.ComboBox11.Name = "ComboBox11";
      this.ComboBox11.Size = new Size(117, 24);
      this.ComboBox11.TabIndex = 18;
      this.ComboBox6.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox6.Dock = DockStyle.Fill;
      this.ComboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox6.FlatStyle = FlatStyle.Popup;
      this.ComboBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox6.FormattingEnabled = true;
      this.ComboBox6.Items.AddRange(new object[18]
      {
        (object) "0",
        (object) "150",
        (object) "200",
        (object) "250",
        (object) "300",
        (object) "350",
        (object) "400",
        (object) "450",
        (object) "500",
        (object) "550",
        (object) "600",
        (object) "650",
        (object) "700",
        (object) "750",
        (object) "800",
        (object) "850",
        (object) "900",
        (object) "960"
      });
      this.ComboBox6.Location = new Point(175, 103);
      this.ComboBox6.MaxLength = 4;
      this.ComboBox6.Name = "ComboBox6";
      this.ComboBox6.Size = new Size(117, 24);
      this.ComboBox6.TabIndex = 10;
      this.Label32.AutoSize = true;
      this.Label32.Dock = DockStyle.Fill;
      this.Label32.Location = new Point(4, 1);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(164, 32);
      this.Label32.TabIndex = 5;
      this.Label32.Text = "Presets";
      this.Label32.TextAlign = ContentAlignment.MiddleLeft;
      this.Label30.AutoSize = true;
      this.Label30.Dock = DockStyle.Fill;
      this.Label30.Location = new Point(4, 34);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(164, 32);
      this.Label30.TabIndex = 1;
      this.Label30.Text = "Distortion Curvature:";
      this.Label30.TextAlign = ContentAlignment.MiddleLeft;
      this.Label31.AutoSize = true;
      this.Label31.Dock = DockStyle.Fill;
      this.Label31.Location = new Point(4, 67);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(164, 32);
      this.Label31.TabIndex = 2;
      this.Label31.Text = "Encode Resolution";
      this.Label31.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox4.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox4.Dock = DockStyle.Fill;
      this.ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox4.Enabled = false;
      this.ComboBox4.FlatStyle = FlatStyle.Popup;
      this.ComboBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox4.FormattingEnabled = true;
      this.ComboBox4.Items.AddRange(new object[1]
      {
        (object) "Disabled"
      });
      this.ComboBox4.Location = new Point(175, 4);
      this.ComboBox4.Name = "ComboBox4";
      this.ComboBox4.Size = new Size(117, 24);
      this.ComboBox4.TabIndex = 6;
      this.ComboBox3.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox3.Dock = DockStyle.Fill;
      this.ComboBox3.FlatStyle = FlatStyle.Popup;
      this.ComboBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox3.FormattingEnabled = true;
      this.ComboBox3.Items.AddRange(new object[6]
      {
        (object) "2016",
        (object) "2352",
        (object) "2912",
        (object) "3648",
        (object) "3960",
        (object) "4040"
      });
      this.ComboBox3.Location = new Point(175, 70);
      this.ComboBox3.MaxLength = 4;
      this.ComboBox3.Name = "ComboBox3";
      this.ComboBox3.Size = new Size(117, 24);
      this.ComboBox3.TabIndex = 4;
      this.ComboBox2.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox2.Dock = DockStyle.Fill;
      this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox2.FlatStyle = FlatStyle.Popup;
      this.ComboBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox2.FormattingEnabled = true;
      this.ComboBox2.Items.AddRange(new object[3]
      {
        (object) "Default",
        (object) "High",
        (object) "Low"
      });
      this.ComboBox2.Location = new Point(175, 37);
      this.ComboBox2.Name = "ComboBox2";
      this.ComboBox2.Size = new Size(117, 24);
      this.ComboBox2.TabIndex = 3;
      this.Label36.AutoSize = true;
      this.Label36.Dock = DockStyle.Fill;
      this.Label36.Location = new Point(4, 100);
      this.Label36.Name = "Label36";
      this.Label36.Size = new Size(164, 32);
      this.Label36.TabIndex = 9;
      this.Label36.Text = "Encode Bitrate";
      this.Label36.TextAlign = ContentAlignment.MiddleLeft;
      this.Label38.AutoSize = true;
      this.Label38.Dock = DockStyle.Fill;
      this.Label38.Location = new Point(4, 133);
      this.Label38.Name = "Label38";
      this.Label38.Size = new Size(164, 32);
      this.Label38.TabIndex = 15;
      this.Label38.Text = "Encode Dynamic Bitrate";
      this.Label38.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox10.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox10.Dock = DockStyle.Fill;
      this.ComboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox10.FlatStyle = FlatStyle.Popup;
      this.ComboBox10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox10.FormattingEnabled = true;
      this.ComboBox10.Items.AddRange(new object[3]
      {
        (object) "Default",
        (object) "Enabled",
        (object) "Disabled"
      });
      this.ComboBox10.Location = new Point(175, 136);
      this.ComboBox10.Name = "ComboBox10";
      this.ComboBox10.Size = new Size(117, 24);
      this.ComboBox10.TabIndex = 16;
      this.Label21.AutoSize = true;
      this.Label21.Dock = DockStyle.Fill;
      this.Label21.Location = new Point(4, 232);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(164, 35);
      this.Label21.TabIndex = 13;
      this.Label21.Text = "Permanent AirLink";
      this.Label21.TextAlign = ContentAlignment.MiddleLeft;
      this.Button6.Dock = DockStyle.Fill;
      this.Button6.FlatStyle = FlatStyle.Flat;
      this.Button6.Location = new Point(175, 235);
      this.Button6.Name = "Button6";
      this.Button6.Size = new Size(117, 29);
      this.Button6.TabIndex = 14;
      this.Button6.Text = "Enable";
      this.Button6.UseVisualStyleBackColor = true;
      this.Label20.AutoSize = true;
      this.Label20.Dock = DockStyle.Fill;
      this.Label20.Location = new Point(4, 199);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(164, 32);
      this.Label20.TabIndex = 11;
      this.Label20.Text = "Sharpening";
      this.Label20.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox7.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox7.Dock = DockStyle.Fill;
      this.ComboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox7.FlatStyle = FlatStyle.Popup;
      this.ComboBox7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox7.FormattingEnabled = true;
      this.ComboBox7.Items.AddRange(new object[3]
      {
        (object) "Auto",
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboBox7.Location = new Point(175, 202);
      this.ComboBox7.Name = "ComboBox7";
      this.ComboBox7.Size = new Size(117, 24);
      this.ComboBox7.TabIndex = 12;
      this.Label39.AutoSize = true;
      this.Label39.Dock = DockStyle.Fill;
      this.Label39.Location = new Point(4, 166);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(164, 32);
      this.Label39.TabIndex = 17;
      this.Label39.Text = "Dynamic Bitrate Max";
      this.Label39.TextAlign = ContentAlignment.MiddleLeft;
      this.Button10.FlatStyle = FlatStyle.Flat;
      this.Button10.Location = new Point(123, 383);
      this.Button10.Name = "Button10";
      this.Button10.Size = new Size(146, 25);
      this.Button10.TabIndex = 10;
      this.Button10.Text = "Save && Restart Service";
      this.Button10.UseVisualStyleBackColor = true;
      this.Label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label10.Location = new Point(9, 17);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(324, 72);
      this.Label10.TabIndex = 0;
      this.Label10.Text = "These settings are for the Oculus Quest/Quest 2 when using Link. You can change the Preset values to experiment. Higher settings require more GPU power and may cause a significant performance drop.";
      this.TabPage6.BackColor = System.Drawing.Color.White;
      this.TabPage6.Controls.Add((Control) this.GroupBox9);
      this.TabPage6.Location = new Point(139, 4);
      this.TabPage6.Name = "TabPage6";
      this.TabPage6.Padding = new Padding(3);
      this.TabPage6.Size = new Size(365, 425);
      this.TabPage6.TabIndex = 5;
      this.TabPage6.Text = "Update Found!";
      this.GroupBox9.Controls.Add((Control) this.LabelDownloadStatus);
      this.GroupBox9.Controls.Add((Control) this.LabelVer);
      this.GroupBox9.Controls.Add((Control) this.Label12);
      this.GroupBox9.Controls.Add((Control) this.Button9);
      this.GroupBox9.Controls.Add((Control) this.Button8);
      this.GroupBox9.Dock = DockStyle.Fill;
      this.GroupBox9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox9.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox9.Location = new Point(3, 3);
      this.GroupBox9.Name = "GroupBox9";
      this.GroupBox9.Size = new Size(359, 419);
      this.GroupBox9.TabIndex = 7;
      this.GroupBox9.TabStop = false;
      this.LabelDownloadStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.LabelDownloadStatus.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LabelDownloadStatus.Location = new Point(6, 244);
      this.LabelDownloadStatus.Name = "LabelDownloadStatus";
      this.LabelDownloadStatus.Size = new Size(347, 16);
      this.LabelDownloadStatus.TabIndex = 5;
      this.LabelDownloadStatus.TextAlign = ContentAlignment.MiddleCenter;
      this.LabelVer.Anchor = AnchorStyles.Left;
      this.LabelVer.Location = new Point(6, 140);
      this.LabelVer.Name = "LabelVer";
      this.LabelVer.Size = new Size(321, 19);
      this.LabelVer.TabIndex = 4;
      this.LabelVer.TextAlign = ContentAlignment.MiddleCenter;
      this.Label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.Label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label12.Location = new Point(6, 110);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(347, 16);
      this.Label12.TabIndex = 3;
      this.Label12.Text = "Looks like we have an update for you!";
      this.Label12.TextAlign = ContentAlignment.MiddleCenter;
      this.Button9.FlatStyle = FlatStyle.Flat;
      this.Button9.Location = new Point(177, 152);
      this.Button9.Name = "Button9";
      this.Button9.Size = new Size(146, 31);
      this.Button9.TabIndex = 1;
      this.Button9.Text = "Download Only";
      this.Button9.UseVisualStyleBackColor = true;
      this.Button8.FlatStyle = FlatStyle.Flat;
      this.Button8.Location = new Point(15, 152);
      this.Button8.Name = "Button8";
      this.Button8.Size = new Size(146, 31);
      this.Button8.TabIndex = 0;
      this.Button8.Text = "Download and Install";
      this.Button8.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new Size(508, 433);
      this.Controls.Add((Control) this.PictureBox2);
      this.Controls.Add((Control) this.PictureBox1);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.DotNetBarTabcontrol1);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.Color.DodgerBlue;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimumSize = new Size(524, 472);
      this.Name = nameof (FrmMain);
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Oculus Tray Tool";
      this.ContextMenuStrip1.ResumeLayout(false);
      this.ContextMenuStrip2.ResumeLayout(false);
      ((ISupportInitialize) this.PictureBox1).EndInit();
      ((ISupportInitialize) this.PictureBox2).EndInit();
      ((ISupportInitialize) this.PictureBox8).EndInit();
      ((ISupportInitialize) this.PictureBox7).EndInit();
      ((ISupportInitialize) this.PictureBox6).EndInit();
      ((ISupportInitialize) this.PictureBox5).EndInit();
      ((ISupportInitialize) this.PictureBox4).EndInit();
      ((ISupportInitialize) this.PictureBox3).EndInit();
      this.DotNetBarTabcontrol1.ResumeLayout(false);
      this.TabPage1.ResumeLayout(false);
      this.GroupBox14.ResumeLayout(false);
      this.DbLayoutPanel2.ResumeLayout(false);
      this.DbLayoutPanel2.PerformLayout();
      this.SplitContainer1.Panel1.ResumeLayout(false);
      this.SplitContainer1.Panel2.ResumeLayout(false);
      this.SplitContainer1.EndInit();
      this.SplitContainer1.ResumeLayout(false);
      this.NumericFOVh.EndInit();
      this.NumericFOVv.EndInit();
      this.TabPage2.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.DbLayoutPanel4.ResumeLayout(false);
      this.DbLayoutPanel4.PerformLayout();
      this.TrackBar1.EndInit();
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
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [field: AccessedThroughProperty("GroupBox1")]
    public virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual CheckBox CheckStartMin
    {
      get => this._CheckStartMin;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckStartMin_CheckedChanged);
        CheckBox checkStartMin1 = this._CheckStartMin;
        if (checkStartMin1 != null)
          checkStartMin1.CheckedChanged -= eventHandler;
        this._CheckStartMin = value;
        CheckBox checkStartMin2 = this._CheckStartMin;
        if (checkStartMin2 == null)
          return;
        checkStartMin2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckStartWindows
    {
      get => this._CheckStartWindows;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckStartWindows_CheckedChanged);
        CheckBox checkStartWindows1 = this._CheckStartWindows;
        if (checkStartWindows1 != null)
          checkStartWindows1.CheckedChanged -= eventHandler;
        this._CheckStartWindows = value;
        CheckBox checkStartWindows2 = this._CheckStartWindows;
        if (checkStartWindows2 == null)
          return;
        checkStartWindows2.CheckedChanged += eventHandler;
      }
    }

    public virtual NotifyIcon NotifyIcon1
    {
      get => this._NotifyIcon1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.NotifyIcon1_DoubleClick);
        NotifyIcon notifyIcon1_1 = this._NotifyIcon1;
        if (notifyIcon1_1 != null)
          notifyIcon1_1.DoubleClick -= eventHandler;
        this._NotifyIcon1 = value;
        NotifyIcon notifyIcon1_2 = this._NotifyIcon1;
        if (notifyIcon1_2 == null)
          return;
        notifyIcon1_2.DoubleClick += eventHandler;
      }
    }

    public virtual Button ButtonStartOVR
    {
      get => this._ButtonStartOVR;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonStartOVR_Click);
        Button buttonStartOvr1 = this._ButtonStartOVR;
        if (buttonStartOvr1 != null)
          buttonStartOvr1.Click -= eventHandler;
        this._ButtonStartOVR = value;
        Button buttonStartOvr2 = this._ButtonStartOVR;
        if (buttonStartOvr2 == null)
          return;
        buttonStartOvr2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("LabelServiceStatus")]
    public virtual Label LabelServiceStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ContextMenuStrip1")]
    public virtual ContextMenuStrip ContextMenuStrip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ToolStripMenuItem ToolStripMenuItem1
    {
      get => this._ToolStripMenuItem1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem1_Click);
        ToolStripMenuItem toolStripMenuItem1_1 = this._ToolStripMenuItem1;
        if (toolStripMenuItem1_1 != null)
          toolStripMenuItem1_1.Click -= eventHandler;
        this._ToolStripMenuItem1 = value;
        ToolStripMenuItem toolStripMenuItem1_2 = this._ToolStripMenuItem1;
        if (toolStripMenuItem1_2 == null)
          return;
        toolStripMenuItem1_2.Click += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ToolStripMenuItem2
    {
      get => this._ToolStripMenuItem2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem2_Click);
        ToolStripMenuItem toolStripMenuItem2_1 = this._ToolStripMenuItem2;
        if (toolStripMenuItem2_1 != null)
          toolStripMenuItem2_1.Click -= eventHandler;
        this._ToolStripMenuItem2 = value;
        ToolStripMenuItem toolStripMenuItem2_2 = this._ToolStripMenuItem2;
        if (toolStripMenuItem2_2 == null)
          return;
        toolStripMenuItem2_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ListBox1")]
    public virtual ListBox ListBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ToolTip")]
    public virtual ToolTip ToolTip { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button ButtonStopOVR
    {
      get => this._ButtonStopOVR;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonStopOVR_Click);
        Button buttonStopOvr1 = this._ButtonStopOVR;
        if (buttonStopOvr1 != null)
          buttonStopOvr1.Click -= eventHandler;
        this._ButtonStopOVR = value;
        Button buttonStopOvr2 = this._ButtonStopOVR;
        if (buttonStopOvr2 == null)
          return;
        buttonStopOvr2.Click += eventHandler;
      }
    }

    public virtual CheckBox CheckStartService
    {
      get => this._CheckStartService;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckStartService_CheckedChanged);
        CheckBox checkStartService1 = this._CheckStartService;
        if (checkStartService1 != null)
          checkStartService1.CheckedChanged -= eventHandler;
        this._CheckStartService = value;
        CheckBox checkStartService2 = this._CheckStartService;
        if (checkStartService2 == null)
          return;
        checkStartService2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckLaunchHome
    {
      get => this._CheckLaunchHome;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckLaunchHome_CheckedChanged);
        CheckBox checkLaunchHome1 = this._CheckLaunchHome;
        if (checkLaunchHome1 != null)
          checkLaunchHome1.CheckedChanged -= eventHandler;
        this._CheckLaunchHome = value;
        CheckBox checkLaunchHome2 = this._CheckLaunchHome;
        if (checkLaunchHome2 == null)
          return;
        checkLaunchHome2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckStopService
    {
      get => this._CheckStopService;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckStopService_CheckedChanged);
        CheckBox checkStopService1 = this._CheckStopService;
        if (checkStopService1 != null)
          checkStopService1.CheckedChanged -= eventHandler;
        this._CheckStopService = value;
        CheckBox checkStopService2 = this._CheckStopService;
        if (checkStopService2 == null)
          return;
        checkStopService2.CheckedChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("GroupBox4")]
    public virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button ButtonRestartOVR
    {
      get => this._ButtonRestartOVR;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonRestartOVR_Click);
        Button buttonRestartOvr1 = this._ButtonRestartOVR;
        if (buttonRestartOvr1 != null)
          buttonRestartOvr1.Click -= eventHandler;
        this._ButtonRestartOVR = value;
        Button buttonRestartOvr2 = this._ButtonRestartOVR;
        if (buttonRestartOvr2 == null)
          return;
        buttonRestartOvr2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label11")]
    public virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual CheckBox CheckLaunchHomeTool
    {
      get => this._CheckLaunchHomeTool;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckLaunchHomeTool_CheckedChanged);
        CheckBox checkLaunchHomeTool1 = this._CheckLaunchHomeTool;
        if (checkLaunchHomeTool1 != null)
          checkLaunchHomeTool1.CheckedChanged -= eventHandler;
        this._CheckLaunchHomeTool = value;
        CheckBox checkLaunchHomeTool2 = this._CheckLaunchHomeTool;
        if (checkLaunchHomeTool2 == null)
          return;
        checkLaunchHomeTool2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckCloseHome
    {
      get => this._CheckCloseHome;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckCloseHome_CheckedChanged);
        CheckBox checkCloseHome1 = this._CheckCloseHome;
        if (checkCloseHome1 != null)
          checkCloseHome1.CheckedChanged -= eventHandler;
        this._CheckCloseHome = value;
        CheckBox checkCloseHome2 = this._CheckCloseHome;
        if (checkCloseHome2 == null)
          return;
        checkCloseHome2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckBoxAltTab
    {
      get => this._CheckBoxAltTab;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBoxAltTab_CheckedChanged);
        CheckBox checkBoxAltTab1 = this._CheckBoxAltTab;
        if (checkBoxAltTab1 != null)
          checkBoxAltTab1.CheckedChanged -= eventHandler;
        this._CheckBoxAltTab = value;
        CheckBox checkBoxAltTab2 = this._CheckBoxAltTab;
        if (checkBoxAltTab2 == null)
          return;
        checkBoxAltTab2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckRiftAudio
    {
      get => this._CheckRiftAudio;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckRiftAudio_CheckedChanged);
        CheckBox checkRiftAudio1 = this._CheckRiftAudio;
        if (checkRiftAudio1 != null)
          checkRiftAudio1.CheckedChanged -= eventHandler;
        this._CheckRiftAudio = value;
        CheckBox checkRiftAudio2 = this._CheckRiftAudio;
        if (checkRiftAudio2 == null)
          return;
        checkRiftAudio2.CheckedChanged += eventHandler;
      }
    }

    public virtual System.Windows.Forms.Timer OculusHomeWatcher
    {
      get => this._OculusHomeWatcher;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OculusHomeWatcher_Tick);
        System.Windows.Forms.Timer oculusHomeWatcher1 = this._OculusHomeWatcher;
        if (oculusHomeWatcher1 != null)
          oculusHomeWatcher1.Tick -= eventHandler;
        this._OculusHomeWatcher = value;
        System.Windows.Forms.Timer oculusHomeWatcher2 = this._OculusHomeWatcher;
        if (oculusHomeWatcher2 == null)
          return;
        oculusHomeWatcher2.Tick += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ToolStripMenuItem3
    {
      get => this._ToolStripMenuItem3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem3_Click);
        ToolStripMenuItem toolStripMenuItem3_1 = this._ToolStripMenuItem3;
        if (toolStripMenuItem3_1 != null)
          toolStripMenuItem3_1.Click -= eventHandler;
        this._ToolStripMenuItem3 = value;
        ToolStripMenuItem toolStripMenuItem3_2 = this._ToolStripMenuItem3;
        if (toolStripMenuItem3_2 == null)
          return;
        toolStripMenuItem3_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolStripSeparator1")]
    public virtual ToolStripSeparator ToolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label8")]
    public virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual CheckBox CheckSpoofCPU
    {
      get => this._CheckSpoofCPU;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckSpoofCPU_CheckedChanged);
        CheckBox checkSpoofCpu1 = this._CheckSpoofCPU;
        if (checkSpoofCpu1 != null)
          checkSpoofCpu1.CheckedChanged -= eventHandler;
        this._CheckSpoofCPU = value;
        CheckBox checkSpoofCpu2 = this._CheckSpoofCPU;
        if (checkSpoofCpu2 == null)
          return;
        checkSpoofCpu2.CheckedChanged += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ToolStripStartOVR
    {
      get => this._ToolStripStartOVR;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripStartOVR_Click);
        ToolStripMenuItem toolStripStartOvr1 = this._ToolStripStartOVR;
        if (toolStripStartOvr1 != null)
          toolStripStartOvr1.Click -= eventHandler;
        this._ToolStripStartOVR = value;
        ToolStripMenuItem toolStripStartOvr2 = this._ToolStripStartOVR;
        if (toolStripStartOvr2 == null)
          return;
        toolStripStartOvr2.Click += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ToolStripStopOVR
    {
      get => this._ToolStripStopOVR;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem5_Click);
        ToolStripMenuItem toolStripStopOvr1 = this._ToolStripStopOVR;
        if (toolStripStopOvr1 != null)
          toolStripStopOvr1.Click -= eventHandler;
        this._ToolStripStopOVR = value;
        ToolStripMenuItem toolStripStopOvr2 = this._ToolStripStopOVR;
        if (toolStripStopOvr2 == null)
          return;
        toolStripStopOvr2.Click += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ToolStripRestartOVR
    {
      get => this._ToolStripRestartOVR;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem6_Click);
        ToolStripMenuItem toolStripRestartOvr1 = this._ToolStripRestartOVR;
        if (toolStripRestartOvr1 != null)
          toolStripRestartOvr1.Click -= eventHandler;
        this._ToolStripRestartOVR = value;
        ToolStripMenuItem toolStripRestartOvr2 = this._ToolStripRestartOVR;
        if (toolStripRestartOvr2 == null)
          return;
        toolStripRestartOvr2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolStripSeparator2")]
    public virtual ToolStripSeparator ToolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox6")]
    public virtual GroupBox GroupBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ContextMenuStrip2")]
    public virtual ContextMenuStrip ContextMenuStrip2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ToolStripMenuItem ToolStripMenuItem4
    {
      get => this._ToolStripMenuItem4;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem4_Click);
        ToolStripMenuItem toolStripMenuItem4_1 = this._ToolStripMenuItem4;
        if (toolStripMenuItem4_1 != null)
          toolStripMenuItem4_1.Click -= eventHandler;
        this._ToolStripMenuItem4 = value;
        ToolStripMenuItem toolStripMenuItem4_2 = this._ToolStripMenuItem4;
        if (toolStripMenuItem4_2 == null)
          return;
        toolStripMenuItem4_2.Click += eventHandler;
      }
    }



    public virtual DotNetBarTabcontrol DotNetBarTabcontrol1
    {
      get => (DotNetBarTabcontrol)this._DotNetBarTabcontrol1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.DotNetBarTabcontrol1_SelectedIndexChanged);
        DotNetBarTabcontrol netBarTabcontrol1_1 = this._DotNetBarTabcontrol1;
        if (netBarTabcontrol1_1 != null)
          netBarTabcontrol1_1.SelectedIndexChanged -= eventHandler;
        this._DotNetBarTabcontrol1 = value;
        DotNetBarTabcontrol netBarTabcontrol1_2 = this._DotNetBarTabcontrol1;
        if (netBarTabcontrol1_2 == null)
          return;
        netBarTabcontrol1_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TabPage1")]
    public virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label6")]
    public virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button BtnVoice
    {
      get => this._BtnVoice;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnVoice_Click);
        Button btnVoice1 = this._BtnVoice;
        if (btnVoice1 != null)
          btnVoice1.Click -= eventHandler;
        this._BtnVoice = value;
        Button btnVoice2 = this._BtnVoice;
        if (btnVoice2 == null)
          return;
        btnVoice2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label1")]
    public virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboSSstart
    {
      get => this._ComboSSstart;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboSSstart_SelectedIndexChanged);
        KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.ComboSSstart_KeyPress);
        ComboBox comboSsstart1 = this._ComboSSstart;
        if (comboSsstart1 != null)
        {
          comboSsstart1.SelectedIndexChanged -= eventHandler;
          comboSsstart1.KeyPress -= pressEventHandler;
        }
        this._ComboSSstart = value;
        ComboBox comboSsstart2 = this._ComboSSstart;
        if (comboSsstart2 == null)
          return;
        comboSsstart2.SelectedIndexChanged += eventHandler;
        comboSsstart2.KeyPress += pressEventHandler;
      }
    }

    public virtual Button BtnProfiles
    {
      get => this._BtnProfiles;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnProfiles_Click);
        Button btnProfiles1 = this._BtnProfiles;
        if (btnProfiles1 != null)
          btnProfiles1.Click -= eventHandler;
        this._BtnProfiles = value;
        Button btnProfiles2 = this._BtnProfiles;
        if (btnProfiles2 == null)
          return;
        btnProfiles2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label7")]
    public virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboVoice
    {
      get => this._ComboVoice;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboVoice_SelectedIndexChanged);
        ComboBox comboVoice1 = this._ComboVoice;
        if (comboVoice1 != null)
          comboVoice1.SelectedIndexChanged -= eventHandler;
        this._ComboVoice = value;
        ComboBox comboVoice2 = this._ComboVoice;
        if (comboVoice2 == null)
          return;
        comboVoice2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TabPage2")]
    public virtual TabPage TabPage2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual CheckBox HotKeysCheckBox
    {
      get => this._HotKeysCheckBox;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HotKeysCheckBox_CheckedChanged);
        CheckBox hotKeysCheckBox1 = this._HotKeysCheckBox;
        if (hotKeysCheckBox1 != null)
          hotKeysCheckBox1.CheckedChanged -= eventHandler;
        this._HotKeysCheckBox = value;
        CheckBox hotKeysCheckBox2 = this._HotKeysCheckBox;
        if (hotKeysCheckBox2 == null)
          return;
        hotKeysCheckBox2.CheckedChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TabPage3")]
    public virtual TabPage TabPage3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox2")]
    public virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboUSBsusp
    {
      get => this._ComboUSBsusp;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboUSBsusp_SelectedIndexChanged);
        ComboBox comboUsBsusp1 = this._ComboUSBsusp;
        if (comboUsBsusp1 != null)
          comboUsBsusp1.SelectedIndexChanged -= eventHandler;
        this._ComboUSBsusp = value;
        ComboBox comboUsBsusp2 = this._ComboUSBsusp;
        if (comboUsBsusp2 == null)
          return;
        comboUsBsusp2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label2")]
    public virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboPowerPlanStart
    {
      get => this._ComboPowerPlanStart;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboPowerPlan_SelectedIndexChanged);
        ComboBox comboPowerPlanStart1 = this._ComboPowerPlanStart;
        if (comboPowerPlanStart1 != null)
          comboPowerPlanStart1.SelectedIndexChanged -= eventHandler;
        this._ComboPowerPlanStart = value;
        ComboBox comboPowerPlanStart2 = this._ComboPowerPlanStart;
        if (comboPowerPlanStart2 == null)
          return;
        comboPowerPlanStart2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TabPage4")]
    public virtual TabPage TabPage4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TabPage5")]
    public virtual TabPage TabPage5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TabPage6")]
    public virtual TabPage TabPage6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual CheckBox CheckMinimizeOnX
    {
      get => this._CheckMinimizeOnX;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckMinimizeOnX_CheckedChanged);
        CheckBox checkMinimizeOnX1 = this._CheckMinimizeOnX;
        if (checkMinimizeOnX1 != null)
          checkMinimizeOnX1.CheckedChanged -= eventHandler;
        this._CheckMinimizeOnX = value;
        CheckBox checkMinimizeOnX2 = this._CheckMinimizeOnX;
        if (checkMinimizeOnX2 == null)
          return;
        checkMinimizeOnX2.CheckedChanged += eventHandler;
      }
    }

    public virtual PictureBox PictureBox1
    {
      get => this._PictureBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
        PictureBox pictureBox1_1 = this._PictureBox1;
        if (pictureBox1_1 != null)
          pictureBox1_1.Click -= eventHandler;
        this._PictureBox1 = value;
        PictureBox pictureBox1_2 = this._PictureBox1;
        if (pictureBox1_2 == null)
          return;
        pictureBox1_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("GroupBox9")]
    public virtual GroupBox GroupBox9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox14")]
    public virtual GroupBox GroupBox14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel2")]
    public virtual DBLayoutPanel DbLayoutPanel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel4")]
    public virtual DBLayoutPanel DbLayoutPanel4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel5")]
    public virtual DBLayoutPanel DbLayoutPanel5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual TrackBar TrackBar1
    {
      get => this._TrackBar1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TrackBar1_Scroll);
        TrackBar trackBar1_1 = this._TrackBar1;
        if (trackBar1_1 != null)
          trackBar1_1.Scroll -= eventHandler;
        this._TrackBar1 = value;
        TrackBar trackBar1_2 = this._TrackBar1;
        if (trackBar1_2 == null)
          return;
        trackBar1_2.Scroll += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label14")]
    public virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel6")]
    public virtual DBLayoutPanel DbLayoutPanel6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel7")]
    public virtual DBLayoutPanel DbLayoutPanel7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel8")]
    public virtual DBLayoutPanel DbLayoutPanel8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox3")]
    public virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ImageList1")]
    public virtual ImageList ImageList1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual System.Windows.Forms.Timer HometoTrayTimer
    {
      get => this._HometoTrayTimer;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HometoTrayTimer_Tick);
        System.Windows.Forms.Timer hometoTrayTimer1 = this._HometoTrayTimer;
        if (hometoTrayTimer1 != null)
          hometoTrayTimer1.Tick -= eventHandler;
        this._HometoTrayTimer = value;
        System.Windows.Forms.Timer hometoTrayTimer2 = this._HometoTrayTimer;
        if (hometoTrayTimer2 == null)
          return;
        hometoTrayTimer2.Tick += eventHandler;
      }
    }

    public virtual CheckBox CheckSendHomeToTray
    {
      get => this._CheckSendHomeToTray;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckSendHomeToTray_CheckedChanged);
        CheckBox checkSendHomeToTray1 = this._CheckSendHomeToTray;
        if (checkSendHomeToTray1 != null)
          checkSendHomeToTray1.CheckedChanged -= eventHandler;
        this._CheckSendHomeToTray = value;
        CheckBox checkSendHomeToTray2 = this._CheckSendHomeToTray;
        if (checkSendHomeToTray2 == null)
          return;
        checkSendHomeToTray2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckSendHomeToTrayOnStart
    {
      get => this._CheckSendHomeToTrayOnStart;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckSendHomeToTrayOnStart_CheckedChanged);
        CheckBox homeToTrayOnStart1 = this._CheckSendHomeToTrayOnStart;
        if (homeToTrayOnStart1 != null)
          homeToTrayOnStart1.CheckedChanged -= eventHandler;
        this._CheckSendHomeToTrayOnStart = value;
        CheckBox homeToTrayOnStart2 = this._CheckSendHomeToTrayOnStart;
        if (homeToTrayOnStart2 == null)
          return;
        homeToTrayOnStart2.CheckedChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TabPage7")]
    public virtual TabPage TabPage7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox7")]
    public virtual GroupBox GroupBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel1")]
    public virtual DBLayoutPanel DbLayoutPanel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button Button4
    {
      get => this._Button4;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button4_Click);
        Button button4_1 = this._Button4;
        if (button4_1 != null)
          button4_1.Click -= eventHandler;
        this._Button4 = value;
        Button button4_2 = this._Button4;
        if (button4_2 == null)
          return;
        button4_2.Click += eventHandler;
      }
    }

    public virtual CheckBox CheckLocalDebug
    {
      get => this._CheckLocalDebug;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckLocalDebug_CheckedChanged);
        CheckBox checkLocalDebug1 = this._CheckLocalDebug;
        if (checkLocalDebug1 != null)
          checkLocalDebug1.CheckedChanged -= eventHandler;
        this._CheckLocalDebug = value;
        CheckBox checkLocalDebug2 = this._CheckLocalDebug;
        if (checkLocalDebug2 == null)
          return;
        checkLocalDebug2.CheckedChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckStartWatcher
    {
      get => this._CheckStartWatcher;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckStartWatcher_CheckedChanged);
        CheckBox checkStartWatcher1 = this._CheckStartWatcher;
        if (checkStartWatcher1 != null)
          checkStartWatcher1.CheckedChanged -= eventHandler;
        this._CheckStartWatcher = value;
        CheckBox checkStartWatcher2 = this._CheckStartWatcher;
        if (checkStartWatcher2 == null)
          return;
        checkStartWatcher2.CheckedChanged += eventHandler;
      }
    }

    public virtual Button Button1
    {
      get => this._Button1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    public virtual Button Button5
    {
      get => this._Button5;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button5_Click);
        Button button5_1 = this._Button5;
        if (button5_1 != null)
          button5_1.Click -= eventHandler;
        this._Button5 = value;
        Button button5_2 = this._Button5;
        if (button5_2 == null)
          return;
        button5_2.Click += eventHandler;
      }
    }

    public virtual CheckBox CheckSensorPower
    {
      get => this._CheckSensorPower;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckSensorPower_CheckedChanged);
        CheckBox checkSensorPower1 = this._CheckSensorPower;
        if (checkSensorPower1 != null)
          checkSensorPower1.CheckedChanged -= eventHandler;
        this._CheckSensorPower = value;
        CheckBox checkSensorPower2 = this._CheckSensorPower;
        if (checkSensorPower2 == null)
          return;
        checkSensorPower2.CheckedChanged += eventHandler;
      }
    }

    public virtual ComboBox ComboPowerPlanExit
    {
      get => this._ComboPowerPlanExit;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboPowerPlanExit_SelectedIndexChanged);
        ComboBox comboPowerPlanExit1 = this._ComboPowerPlanExit;
        if (comboPowerPlanExit1 != null)
          comboPowerPlanExit1.SelectedIndexChanged -= eventHandler;
        this._ComboPowerPlanExit = value;
        ComboBox comboPowerPlanExit2 = this._ComboPowerPlanExit;
        if (comboPowerPlanExit2 == null)
          return;
        comboPowerPlanExit2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label22")]
    public virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button BtnConfigureAudio
    {
      get => this._BtnConfigureAudio;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnConfigureAudio_Click);
        Button btnConfigureAudio1 = this._BtnConfigureAudio;
        if (btnConfigureAudio1 != null)
          btnConfigureAudio1.Click -= eventHandler;
        this._BtnConfigureAudio = value;
        Button btnConfigureAudio2 = this._BtnConfigureAudio;
        if (btnConfigureAudio2 == null)
          return;
        btnConfigureAudio2.Click += eventHandler;
      }
    }

    public virtual ComboBox ComboApplyPlan
    {
      get => this._ComboApplyPlan;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboApplyPlan_SelectedIndexChanged);
        ComboBox comboApplyPlan1 = this._ComboApplyPlan;
        if (comboApplyPlan1 != null)
          comboApplyPlan1.SelectedIndexChanged -= eventHandler;
        this._ComboApplyPlan = value;
        ComboBox comboApplyPlan2 = this._ComboApplyPlan;
        if (comboApplyPlan2 == null)
          return;
        comboApplyPlan2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label4")]
    public virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label23")]
    public virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label3")]
    public virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("LabelVer")]
    public virtual Label LabelVer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label12")]
    public virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button Button9
    {
      get => this._Button9;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button9_Click);
        Button button9_1 = this._Button9;
        if (button9_1 != null)
          button9_1.Click -= eventHandler;
        this._Button9 = value;
        Button button9_2 = this._Button9;
        if (button9_2 == null)
          return;
        button9_2.Click += eventHandler;
      }
    }

    public virtual Button Button8
    {
      get => this._Button8;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button8_Click);
        Button button8_1 = this._Button8;
        if (button8_1 != null)
          button8_1.Click -= eventHandler;
        this._Button8 = value;
        Button button8_2 = this._Button8;
        if (button8_2 == null)
          return;
        button8_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("LabelDownloadStatus")]
    public virtual Label LabelDownloadStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual PictureBox PictureBox2
    {
      get => this._PictureBox2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox2_Click);
        PictureBox pictureBox2_1 = this._PictureBox2;
        if (pictureBox2_1 != null)
          pictureBox2_1.Click -= eventHandler;
        this._PictureBox2 = value;
        PictureBox pictureBox2_2 = this._PictureBox2;
        if (pictureBox2_2 == null)
          return;
        pictureBox2_2.Click += eventHandler;
      }
    }

    public virtual CheckBox CheckBoxCheckForUpdates
    {
      get => this._CheckBoxCheckForUpdates;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBoxCheckForUpdates_CheckedChanged);
        CheckBox boxCheckForUpdates1 = this._CheckBoxCheckForUpdates;
        if (boxCheckForUpdates1 != null)
          boxCheckForUpdates1.CheckedChanged -= eventHandler;
        this._CheckBoxCheckForUpdates = value;
        CheckBox boxCheckForUpdates2 = this._CheckBoxCheckForUpdates;
        if (boxCheckForUpdates2 == null)
          return;
        boxCheckForUpdates2.CheckedChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label5")]
    public virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label15")]
    public virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("NumericFOVh")]
    public virtual NumericUpDown NumericFOVh { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button Button2
    {
      get => this._Button2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        Button button2_1 = this._Button2;
        if (button2_1 != null)
          button2_1.Click -= eventHandler;
        this._Button2 = value;
        Button button2_2 = this._Button2;
        if (button2_2 == null)
          return;
        button2_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label16")]
    public virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboHomless
    {
      get => this._ComboHomless;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboHomless_SelectedIndexChanged);
        ComboBox comboHomless1 = this._ComboHomless;
        if (comboHomless1 != null)
          comboHomless1.SelectedIndexChanged -= eventHandler;
        this._ComboHomless = value;
        ComboBox comboHomless2 = this._ComboHomless;
        if (comboHomless2 == null)
          return;
        comboHomless2.SelectedIndexChanged += eventHandler;
      }
    }

    public virtual Button BtnHomless
    {
      get => this._BtnHomless;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnHomless_Click);
        Button btnHomless1 = this._BtnHomless;
        if (btnHomless1 != null)
          btnHomless1.Click -= eventHandler;
        this._BtnHomless = value;
        Button btnHomless2 = this._BtnHomless;
        if (btnHomless2 == null)
          return;
        btnHomless2.Click += eventHandler;
      }
    }

    public virtual System.Windows.Forms.Timer UpdateTimer
    {
      get => this._UpdateTimer;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.UpdateTimer_Tick);
        System.Windows.Forms.Timer updateTimer1 = this._UpdateTimer;
        if (updateTimer1 != null)
          updateTimer1.Tick -= eventHandler;
        this._UpdateTimer = value;
        System.Windows.Forms.Timer updateTimer2 = this._UpdateTimer;
        if (updateTimer2 == null)
          return;
        updateTimer2.Tick += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ToolStripMenuShowHome
    {
      get => this._ToolStripMenuShowHome;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuShowHome_Click);
        ToolStripMenuItem stripMenuShowHome1 = this._ToolStripMenuShowHome;
        if (stripMenuShowHome1 != null)
          stripMenuShowHome1.Click -= eventHandler;
        this._ToolStripMenuShowHome = value;
        ToolStripMenuItem stripMenuShowHome2 = this._ToolStripMenuShowHome;
        if (stripMenuShowHome2 == null)
          return;
        stripMenuShowHome2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label9")]
    public virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboVisualHUD
    {
      get => this._ComboVisualHUD;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboVisualHUD_SelectedIndexChanged);
        ComboBox comboVisualHud1 = this._ComboVisualHUD;
        if (comboVisualHud1 != null)
          comboVisualHud1.SelectedIndexChanged -= eventHandler;
        this._ComboVisualHUD = value;
        ComboBox comboVisualHud2 = this._ComboVisualHUD;
        if (comboVisualHud2 == null)
          return;
        comboVisualHud2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label17")]
    public virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboMirrorHome
    {
      get => this._ComboMirrorHome;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboMirrorHome_SelectedIndexChanged);
        ComboBox comboMirrorHome1 = this._ComboMirrorHome;
        if (comboMirrorHome1 != null)
          comboMirrorHome1.SelectedIndexChanged -= eventHandler;
        this._ComboMirrorHome = value;
        ComboBox comboMirrorHome2 = this._ComboMirrorHome;
        if (comboMirrorHome2 == null)
          return;
        comboMirrorHome2.SelectedIndexChanged += eventHandler;
      }
    }

    public virtual CheckBox CheckRestartSleep
    {
      get => this._CheckRestartSleep;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckRestartSleep_CheckedChanged);
        CheckBox checkRestartSleep1 = this._CheckRestartSleep;
        if (checkRestartSleep1 != null)
          checkRestartSleep1.CheckedChanged -= eventHandler;
        this._CheckRestartSleep = value;
        CheckBox checkRestartSleep2 = this._CheckRestartSleep;
        if (checkRestartSleep2 == null)
          return;
        checkRestartSleep2.CheckedChanged += eventHandler;
      }
    }

    public virtual Button BtnSteamImport
    {
      get => this._BtnSteamImport;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnSteamImport_Click);
        Button btnSteamImport1 = this._BtnSteamImport;
        if (btnSteamImport1 != null)
          btnSteamImport1.Click -= eventHandler;
        this._BtnSteamImport = value;
        Button btnSteamImport2 = this._BtnSteamImport;
        if (btnSteamImport2 == null)
          return;
        btnSteamImport2.Click += eventHandler;
      }
    }

    public virtual NotifyIcon NotifyIcon3
    {
      get => this._NotifyIcon3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.NotifyIcon3_MouseDown);
        NotifyIcon notifyIcon3_1 = this._NotifyIcon3;
        if (notifyIcon3_1 != null)
          notifyIcon3_1.MouseDown -= mouseEventHandler;
        this._NotifyIcon3 = value;
        NotifyIcon notifyIcon3_2 = this._NotifyIcon3;
        if (notifyIcon3_2 == null)
          return;
        notifyIcon3_2.MouseDown += mouseEventHandler;
      }
    }

    public virtual Button BtnConfigureHotKeys
    {
      get => this._BtnConfigureHotKeys;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnConfigureHotKeys_Click);
        Button configureHotKeys1 = this._BtnConfigureHotKeys;
        if (configureHotKeys1 != null)
          configureHotKeys1.Click -= eventHandler;
        this._BtnConfigureHotKeys = value;
        Button configureHotKeys2 = this._BtnConfigureHotKeys;
        if (configureHotKeys2 == null)
          return;
        configureHotKeys2.Click += eventHandler;
      }
    }

    public virtual ToolStripMenuItem ClearLogToolStripMenuItem
    {
      get => this._ClearLogToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ClearLogToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ClearLogToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ClearLogToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ClearLogToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    public virtual ToolStripMenuItem OpenLogToolStripMenuItem
    {
      get => this._OpenLogToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OpenLogToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._OpenLogToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._OpenLogToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._OpenLogToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label13")]
    public virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label18")]
    public virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label24")]
    public virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label25")]
    public virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label26")]
    public virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label27")]
    public virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label28")]
    public virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label29")]
    public virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button BtnLibrary
    {
      get => this._BtnLibrary;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnLibrary_Click);
        Button btnLibrary1 = this._BtnLibrary;
        if (btnLibrary1 != null)
          btnLibrary1.Click -= eventHandler;
        this._BtnLibrary = value;
        Button btnLibrary2 = this._BtnLibrary;
        if (btnLibrary2 == null)
          return;
        btnLibrary2.Click += eventHandler;
      }
    }

    public virtual System.Windows.Forms.Timer PowerPlanTimer
    {
      get => this._PowerPlanTimer;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PowerPlanTimer_Tick);
        System.Windows.Forms.Timer powerPlanTimer1 = this._PowerPlanTimer;
        if (powerPlanTimer1 != null)
          powerPlanTimer1.Tick -= eventHandler;
        this._PowerPlanTimer = value;
        System.Windows.Forms.Timer powerPlanTimer2 = this._PowerPlanTimer;
        if (powerPlanTimer2 == null)
          return;
        powerPlanTimer2.Tick += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TabPage8")]
    public virtual TabPage TabPage8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox5")]
    public virtual GroupBox GroupBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label10")]
    public virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboBox3
    {
      get => this._ComboBox3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.ComboBox3_KeyPress);
        ComboBox comboBox3_1 = this._ComboBox3;
        if (comboBox3_1 != null)
          comboBox3_1.KeyPress -= pressEventHandler;
        this._ComboBox3 = value;
        ComboBox comboBox3_2 = this._ComboBox3;
        if (comboBox3_2 == null)
          return;
        comboBox3_2.KeyPress += pressEventHandler;
      }
    }

    [field: AccessedThroughProperty("ComboBox2")]
    public virtual ComboBox ComboBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label31")]
    public virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label30")]
    public virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboBox4
    {
      get => this._ComboBox4;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox4_SelectedIndexChanged);
        ComboBox comboBox4_1 = this._ComboBox4;
        if (comboBox4_1 != null)
          comboBox4_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox4 = value;
        ComboBox comboBox4_2 = this._ComboBox4;
        if (comboBox4_2 == null)
          return;
        comboBox4_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label32")]
    public virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button Button10
    {
      get => this._Button10;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button10_Click);
        Button button10_1 = this._Button10;
        if (button10_1 != null)
          button10_1.Click -= eventHandler;
        this._Button10 = value;
        Button button10_2 = this._Button10;
        if (button10_2 == null)
          return;
        button10_2.Click += eventHandler;
      }
    }

    public virtual Button Button11
    {
      get => this._Button11;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button11_Click);
        Button button11_1 = this._Button11;
        if (button11_1 != null)
          button11_1.Click -= eventHandler;
        this._Button11 = value;
        Button button11_2 = this._Button11;
        if (button11_2 == null)
          return;
        button11_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("DbLayoutPanel3")]
    public virtual DBLayoutPanel DbLayoutPanel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button Button12
    {
      get => this._Button12;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button12_Click);
        Button button12_1 = this._Button12;
        if (button12_1 != null)
          button12_1.Click -= eventHandler;
        this._Button12 = value;
        Button button12_2 = this._Button12;
        if (button12_2 == null)
          return;
        button12_2.Click += eventHandler;
      }
    }

    public virtual Button BtnRemoveAllProfiles
    {
      get => this._BtnRemoveAllProfiles;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.BtnRemoveAllProfiles_Click);
        EventHandler eventHandler2 = new EventHandler(this.Button1_Click);
        Button removeAllProfiles1 = this._BtnRemoveAllProfiles;
        if (removeAllProfiles1 != null)
        {
          removeAllProfiles1.Click -= eventHandler1;
          removeAllProfiles1.Click -= eventHandler2;
        }
        this._BtnRemoveAllProfiles = value;
        Button removeAllProfiles2 = this._BtnRemoveAllProfiles;
        if (removeAllProfiles2 == null)
          return;
        removeAllProfiles2.Click += eventHandler1;
        removeAllProfiles2.Click += eventHandler2;
      }
    }

    public virtual ComboBox ComboBox1
    {
      get => this._ComboBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
        ComboBox comboBox1_1 = this._ComboBox1;
        if (comboBox1_1 != null)
          comboBox1_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox1 = value;
        ComboBox comboBox1_2 = this._ComboBox1;
        if (comboBox1_2 == null)
          return;
        comboBox1_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label35")]
    public virtual Label Label35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboBox5
    {
      get => this._ComboBox5;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox5_SelectedIndexChanged);
        ComboBox comboBox5_1 = this._ComboBox5;
        if (comboBox5_1 != null)
          comboBox5_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox5 = value;
        ComboBox comboBox5_2 = this._ComboBox5;
        if (comboBox5_2 == null)
          return;
        comboBox5_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("SplitContainer1")]
    public virtual SplitContainer SplitContainer1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("NumericFOVv")]
    public virtual NumericUpDown NumericFOVv { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label36")]
    public virtual Label Label36 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox6")]
    public virtual ComboBox ComboBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label19")]
    public virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboOVRPrio
    {
      get => this._ComboOVRPrio;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboOVRPrio_SelectedIndexChanged);
        ComboBox comboOvrPrio1 = this._ComboOVRPrio;
        if (comboOvrPrio1 != null)
          comboOvrPrio1.SelectedIndexChanged -= eventHandler;
        this._ComboOVRPrio = value;
        ComboBox comboOvrPrio2 = this._ComboOVRPrio;
        if (comboOvrPrio2 == null)
          return;
        comboOvrPrio2.SelectedIndexChanged += eventHandler;
      }
    }

    public virtual Button Button3
    {
      get => this._Button3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button3_Click);
        Button button3_1 = this._Button3;
        if (button3_1 != null)
          button3_1.Click -= eventHandler;
        this._Button3 = value;
        Button button3_2 = this._Button3;
        if (button3_2 == null)
          return;
        button3_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label20")]
    public virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox7")]
    public virtual ComboBox ComboBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label21")]
    public virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual Button Button6
    {
      get => this._Button6;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button6_Click);
        Button button6_1 = this._Button6;
        if (button6_1 != null)
          button6_1.Click -= eventHandler;
        this._Button6 = value;
        Button button6_2 = this._Button6;
        if (button6_2 == null)
          return;
        button6_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("PictureBox3")]
    public virtual PictureBox PictureBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label34")]
    public virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label33")]
    public virtual Label Label33 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboBox8
    {
      get => this._ComboBox8;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox8_SelectedIndexChanged);
        ComboBox comboBox8_1 = this._ComboBox8;
        if (comboBox8_1 != null)
          comboBox8_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox8 = value;
        ComboBox comboBox8_2 = this._ComboBox8;
        if (comboBox8_2 == null)
          return;
        comboBox8_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label37")]
    public virtual Label Label37 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual ComboBox ComboBox9
    {
      get => this._ComboBox9;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox9_SelectedIndexChanged);
        ComboBox comboBox9_1 = this._ComboBox9;
        if (comboBox9_1 != null)
          comboBox9_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox9 = value;
        ComboBox comboBox9_2 = this._ComboBox9;
        if (comboBox9_2 == null)
          return;
        comboBox9_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label38")]
    public virtual Label Label38 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox10")]
    public virtual ComboBox ComboBox10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox11")]
    public virtual ComboBox ComboBox11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label39")]
    public virtual Label Label39 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PictureBox6")]
    public virtual PictureBox PictureBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PictureBox5")]
    public virtual PictureBox PictureBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PictureBox4")]
    public virtual PictureBox PictureBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PictureBox7")]
    public virtual PictureBox PictureBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PictureBox8")]
    public virtual PictureBox PictureBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public virtual CheckBox CheckStopServiceHome
    {
      get => this._CheckStopServiceHome;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckStopServiceHome_CheckedChanged);
        CheckBox checkStopServiceHome1 = this._CheckStopServiceHome;
        if (checkStopServiceHome1 != null)
          checkStopServiceHome1.CheckedChanged -= eventHandler;
        this._CheckStopServiceHome = value;
        CheckBox checkStopServiceHome2 = this._CheckStopServiceHome;
        if (checkStopServiceHome2 == null)
          return;
        checkStopServiceHome2.CheckedChanged += eventHandler;
      }
    }
    


    private delegate void TimerStart();

    private delegate void AppTimerStart();

    public void AddToListboxAndScroll(string text)
    {
      if (this.ListBox1.InvokeRequired)
      {
        this.Invoke((Delegate) new FrmMain.AddToListboxAndScrollDelegate(this.AddToListboxAndScroll), (object) text);
      }
      else
      {
        this.ListBox1.Items.Add((object) text);
        this.ListBox1.TopIndex = checked (this.ListBox1.Items.Count - 1);
      }
    }

    public delegate void AddToListboxAndScrollDelegate(string text);

    public delegate void UpdateTabDelegate();

    public delegate void ShowUpdateToastDelegate();

    public delegate void EnableShowHomeMenuDelegate();

    public delegate void DisableShowHomeMenuDelegate();

    public delegate void SetTitleIsListeningDelegate();

    public delegate void RemoveTitleIsListeningDelegate();

    public delegate void SetToolTipDelegate(string text, Control crtl);
    private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        // TODO: Implement Watcher_EventArrived logic
    }



    private void kbHook_KeyDown(Keys Key)
    {
        // TODO: Implement kbHook_KeyDown logic
    }

    private void kbHook_KeyUp(Keys Key)
    {
        // TODO: Implement kbHook_KeyUp logic
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        // TODO: Implement Form1_Resize logic
    }

    private string GetSteamPath() { return ""; }
    private string GetSteamVR() { return ""; }

    private void CheckWarnings() { }
    private void CheckOculusService() { }
    internal void StartOVR() { Log.WriteToLog("StartOVR stub called"); }
    internal void StopOVR() { Log.WriteToLog("StopOVR stub called"); }
    internal void ApplyAswTick(object sender, ElapsedEventArgs e) { Log.WriteToLog("ApplyAswTick stub called"); }
    internal void ApplyCpuPrioTick(object sender, ElapsedEventArgs e) { Log.WriteToLog("ApplyCpuPrioTick stub called"); }
    internal void AppWork(object sender, DoWorkEventArgs e) { Log.WriteToLog("AppWork stub called"); }
    private void EnableDisableVoice(bool enable) { }
    private void EnableShowHomeMenu() { }
    private void DisableShowHomeMenu() { }
    
    // Event Handlers
    private void CheckStartWindows_CheckedChanged(object sender, EventArgs e) { }
    private void NotifyIcon1_DoubleClick(object sender, EventArgs e) { }
    private void ButtonStartOVR_Click(object sender, EventArgs e) { }
    private void ToolStripMenuItem1_Click(object sender, EventArgs e) { }
    private void ToolStripMenuItem2_Click(object sender, EventArgs e) { }
    private void ButtonStopOVR_Click(object sender, EventArgs e) { }
    private void CheckStartService_CheckedChanged(object sender, EventArgs e) { }
    private void CheckLaunchHome_CheckedChanged(object sender, EventArgs e) { }
    private void CheckStopService_CheckedChanged(object sender, EventArgs e) { }
    private void ButtonRestartOVR_Click(object sender, EventArgs e) { }
    private void CheckLaunchHomeTool_CheckedChanged(object sender, EventArgs e) { }
    private void CheckCloseHome_CheckedChanged(object sender, EventArgs e) { }
    private void CheckBoxAltTab_CheckedChanged(object sender, EventArgs e) { }
    private void CheckRiftAudio_CheckedChanged(object sender, EventArgs e) { }
    private void OculusHomeWatcher_Tick(object sender, EventArgs e) { }
    private void ToolStripMenuItem3_Click(object sender, EventArgs e) { }
    private void CheckSpoofCPU_CheckedChanged(object sender, EventArgs e) { }
    private void ToolStripStartOVR_Click(object sender, EventArgs e) { }
    private void ToolStripMenuItem5_Click(object sender, EventArgs e) { }
    private void ToolStripMenuItem6_Click(object sender, EventArgs e) { }
    private void ToolStripMenuItem4_Click(object sender, EventArgs e) { }
    private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnVoice_Click(object sender, EventArgs e) { }
    private void ComboSSstart_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnProfiles_Click(object sender, EventArgs e) { }
    private void ComboVoice_SelectedIndexChanged(object sender, EventArgs e) { }
    private void HotKeysCheckBox_CheckedChanged(object sender, EventArgs e) { }
    private void ComboUSBsusp_SelectedIndexChanged(object sender, EventArgs e) { }
    private void ComboPowerPlan_SelectedIndexChanged(object sender, EventArgs e) { }
    private void CheckMinimizeOnX_CheckedChanged(object sender, EventArgs e) { }
    private void PictureBox1_Click(object sender, EventArgs e) { }
    private void TrackBar1_Scroll(object sender, EventArgs e) { }
    private void HometoTrayTimer_Tick(object sender, EventArgs e) { }
    private void CheckSendHomeToTray_CheckedChanged(object sender, EventArgs e) { }
    private void CheckSendHomeToTrayOnStart_CheckedChanged(object sender, EventArgs e) { }
    private void Button4_Click(object sender, EventArgs e) { }
    private void CheckLocalDebug_CheckedChanged(object sender, EventArgs e) { }
    private void CheckStartWatcher_CheckedChanged(object sender, EventArgs e) { }
    private void Button1_Click(object sender, EventArgs e) { }
    private void Button5_Click(object sender, EventArgs e) { }
    private void CheckSensorPower_CheckedChanged(object sender, EventArgs e) { }
    private void ComboPowerPlanExit_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnConfigureAudio_Click(object sender, EventArgs e) { }
    private void ComboApplyPlan_SelectedIndexChanged(object sender, EventArgs e) { }
    private void Button9_Click(object sender, EventArgs e) { }
    private void Button8_Click(object sender, EventArgs e) { }
    private void PictureBox2_Click(object sender, EventArgs e) { }
    private void CheckBoxCheckForUpdates_CheckedChanged(object sender, EventArgs e) { }
    private void Button2_Click(object sender, EventArgs e) { }
    private void ComboHomless_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnHomless_Click(object sender, EventArgs e) { }
    private void UpdateTimer_Tick(object sender, EventArgs e) { }
    private void ToolStripMenuShowHome_Click(object sender, EventArgs e) { }
    private void ComboVisualHUD_SelectedIndexChanged(object sender, EventArgs e) { }
    private void ComboMirrorHome_SelectedIndexChanged(object sender, EventArgs e) { }
    private void CheckRestartSleep_CheckedChanged(object sender, EventArgs e) { }
    private void BtnSteamImport_Click(object sender, EventArgs e) { }
    private void NotifyIcon3_MouseDown(object sender, MouseEventArgs e) { }
    private void BtnConfigureHotKeys_Click(object sender, EventArgs e) { }
    private void ClearLogToolStripMenuItem_Click(object sender, EventArgs e) { }
    private void OpenLogToolStripMenuItem_Click(object sender, EventArgs e) { }
    private void BtnLibrary_Click(object sender, EventArgs e) { }
    private void PowerPlanTimer_Tick(object sender, EventArgs e) { }
    private void ComboBox3_KeyPress(object sender, KeyPressEventArgs e) { }
    private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
    private void Button10_Click(object sender, EventArgs e) { }
    private void Button11_Click(object sender, EventArgs e) { }
    private void Button12_Click(object sender, EventArgs e) { }
    private void BtnRemoveAllProfiles_Click(object sender, EventArgs e) { }
    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e) { }
    private void ComboOVRPrio_SelectedIndexChanged(object sender, EventArgs e) { }
    private void Button3_Click(object sender, EventArgs e) { }
    private void Button6_Click(object sender, EventArgs e) { }
    private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e) { }
    private void ComboBox9_SelectedIndexChanged(object sender, EventArgs e) { }
    private void CheckStartMin_CheckedChanged(object sender, EventArgs e) { }
    private string GetCPUid() { return ""; }

    private string SplitToolTip(string tip)
    {
        // TODO: Implement SplitToolTip logic
        return tip;
    }
    private string GenerateSHA256Hash(string filename)
    {
        try
        {
            if (!File.Exists(filename)) return string.Empty;
            using (FileStream stream = File.OpenRead(filename))
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Log.WriteToLog("Error generating hash: " + ex.Message);
            return string.Empty;
        }
    }

    private void NotificationTimer_Tick(object sender, EventArgs e)
    {
        this.NotificationTimer.Stop();
        this._NotifyIcon1.Visible = false;
        // Logic to hide toast/notification?
    }


    private ToolTip ToolTip1;

    public void SetToolTipText(Control control, string text)
    {
      if (this.ToolTip1 == null)
      {
         this.ToolTip1 = new ToolTip(this.components);
      }
      this.ToolTip1.SetToolTip(control, text);
    }

    // Added methods to resolve compilation errors
    private void CheckStartWithWindowsLogic()
    {
         try {
            string keyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key == null) return;
                object val = key.GetValue("OculusTrayTool");
                if (val != null)
                {
                    if (this.CheckStartWithWindows != null)
                        this.CheckStartWithWindows.Checked = true;
                }
                else
                {
                    if (this.CheckStartWithWindows != null)
                        this.CheckStartWithWindows.Checked = false;
                }
            }
         } catch (Exception ex) {
            Log.WriteToLog("Error checking start with windows: " + ex.Message);
         }
    }

    public void UpdateTabPage()
    {
        Log.WriteToLog("UpdateTabPage stub called");
    }

    public void ApplyMirrorTick(object sender, EventArgs e)
    {
        Log.WriteToLog("ApplyMirrorTick stub called");
    }

    public void ShowUpdateToast()
    {
        Log.WriteToLog("ShowUpdateToast stub called");
        try {
            // if (OculusTrayTool.My.MySettings.Default.ShowUpdateToast)
            {
                 MyProject.Forms.frmUpdateToast.ShowDialog();
            }
        } catch (Exception ex) {
            Log.WriteToLog("ShowUpdateToast error: " + ex.Message);
        }
    }
}
}
