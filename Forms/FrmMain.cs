
using CoreAudio;
using System.Speech.Recognition;

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
using Microsoft.Win32;


namespace OculusTrayTool.Forms
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
    

    private ManagementEventWatcher _Watcher;
    private ManagementEventWatcher _MinimizeHomeWatcher;
    private KeyboardHook _kbHook;
    private CheckBox _CheckStopServiceHome;
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
    private ComboBox _ComboBox1, _ComboBox2, _ComboBox3, _ComboBox4, _ComboBox5, _ComboBox6, _ComboBox7, _ComboBox8, _ComboBox9, _ComboBox10, _ComboBox11, _ComboMirrorHome, _ComboVisualHUD, _ComboOVRPrio, _ComboHomless, _ComboVoice, _ComboUSBsusp/*, _ComboPowerPlanStart, _ComboPowerPlanExit, _ComboApplyPlan*/;
    private Label _Label5, _Label6, _Label7, _Label8, _Label9, _Label13, _Label15, _Label16, _Label17, _Label18, _Label19, _Label29, _Label33, _Label35, _Label36, _Label37, _Label38, _Label39, _Label10, _Label31, _Label30, _Label32, _Label2, _Label22, _Label3, _Label23, _Label4, _LabelVer, _Label12, _LabelDownloadStatus, _Label14, _Label1, _Label11, _Label20, _Label21, _Label34, _Label24, _Label25, _Label26, _Label27, _Label28;
    private PictureBox _PictureBox1, _PictureBox2, _PictureBox3, _PictureBox5, _PictureBox6, _PictureBox4, _PictureBox7, _PictureBox8;
    private ToolStripMenuItem _OpenLogToolStripMenuItem, _ClearLogToolStripMenuItem, _ToolStripMenuItem1, _ToolStripMenuItem2, _ToolStripMenuItem3, _ToolStripMenuItem4, _ToolStripMenuShowHome, _ToolStripStartOVR, _ToolStripStopOVR, _ToolStripRestartOVR;
    private ContextMenuStrip _ContextMenuStrip1, _ContextMenuStrip2;
    private ToolStripSeparator _ToolStripSeparator1, _ToolStripSeparator2;

    public virtual ManagementEventWatcher Watcher
    {
      get { return this._Watcher; }
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
    






    public virtual KeyboardHook kbHook
    {
      get { return this._kbHook; }
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
      fmain = this;
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
          if (String.Equals(Left, "-r", StringComparison.OrdinalIgnoreCase))
          {
            OculusTrayTool.My.MySettings.Default.Reset();
            OculusTrayTool.My.MySettings.Default.Save();
            this.Shutdown();
          }
          Globals.dbg = String.Equals(Left, "-d", StringComparison.OrdinalIgnoreCase);
          if (String.Equals(Left, "-u", StringComparison.OrdinalIgnoreCase))
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
          if (File.Exists(Application.StartupPath + "\\ott.log"))
            File.Move(Application.StartupPath + "\\ott.log", "ott_" + DateTime.Now.ToString().Replace("/", "").Replace("\\", "").Replace("-", "").Replace(" ", "_").Replace(":", "") + ".log");
          Log.WriteToLog(":: Debug is ON ::");
        }
        Log.WriteToLog("Starting up...");
        // Direct UI test
        this.AddToListboxAndScroll("--- TEST LOG ENTRY TO UI ---");
        
        Log.WriteToLog("Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        VoiceCommands.Initialize();
        if (Globals.dbg)
          Log.WriteToLog("Checking Administrator privileges");
        Log.WriteToLog("Form1_Load: fmain is " + (fmain == null ? "null" : "set") + ", matching this: " + (fmain == this));
        this.Shown += new EventHandler(this.Form1_Shown); // Ensure refresh happens after UI is visible
        this.isElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        if (!this.isElevated)
        {
          int num = (int) MessageBox.Show("You must run Oculus Tray Tool as Administrator.\r\nThe application will now exit.", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
          int num = (int) MessageBox.Show("Missing dependency: CoreAudio.dll, cannot continue", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Dispose();
        }
        else if (!File.Exists(Application.StartupPath + "\\Microsoft.Win32.TaskScheduler.dll"))
        {
          Log.WriteToLog("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue");
          int num = (int) MessageBox.Show("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Dispose();
        }
        else if (!File.Exists(Application.StartupPath + "\\Newtonsoft.Json.dll"))
        {
          Log.WriteToLog("Missing dependency: Newtonsoft.Json.dll, cannot continue");
          int num = (int) MessageBox.Show("Missing dependency: Newtonsoft.Json.dll, cannot continue", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Dispose();
        }

        else if (!File.Exists(Application.StartupPath + "\\System.Data.SQLite.dll"))
        {
          Log.WriteToLog("Missing dependency: System.Data.SQLite.dll, cannot continue");
          int num = (int) MessageBox.Show("Missing dependency: System.Data.SQLite.dll, cannot continue", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
              //ProjectData.SetProjectError(ex);
              Exception exception = ex;
              Log.WriteToLog("Failed to create database copy: " + exception.Message);
              int num3 = (int) MessageBox.Show("Failed to create database copy: " + exception.Message, "Error copying database", MessageBoxButtons.OK, MessageBoxIcon.Error);
              this.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
              this.hasError = true;
              //ProjectData.ClearProjectError();
              return;
            }
          }
          OculusTrayTool.OculusPath.GetOculusPath();
          GetConfig.IsReading = true;
          
          
          OTTDB.OpenOttDB();
          PowerPlans.GetPowerPlans();
          this.LoadPowerPlansDirectly();
           
          
          GetConfig.Load();
          bool isLibPathEmpty = (string.Compare(OculusTrayTool.My.MySettings.Default.LibraryPath, "", StringComparison.Ordinal) == 0 | string.IsNullOrWhiteSpace(OculusTrayTool.My.MySettings.Default.LibraryPath.ToString()));
          bool noSoftwarePaths = (this.OculusSoftwarePaths.Count == 0);

          if (isLibPathEmpty && noSoftwarePaths)
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
                  MySettings settings;
                  (settings = OculusTrayTool.My.MySettings.Default).LibraryPath = settings.LibraryPath + oculusSoftwarePath + ",";
                  OculusTrayTool.My.MySettings.Default.Save();
                }
              }
              catch (Exception ex)
              {
                   Log.WriteToLog("Error processing Oculus Library Paths: " + ex.Message);
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
              Log.WriteToLog("WARNING TRIGGERED: No library paths found in registry");
              this.hasWarning = true;
            }
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
          this.SteamPath = this.GetSteamPath();
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
              string[] strArray = OculusTrayTool.My.MySettings.Default.LibraryPath.Split(',');
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
            Log.WriteToLog("WARNING TRIGGERED: Could not get default audio endpoint");
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
              Thread.Sleep(Convert.ToInt32(OculusTrayTool.My.MySettings.Default.SleepAfterHomeStart));
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
        if (!String.Equals(OculusTrayTool.My.MySettings.Default.PowerPlanExit, "Not Used", StringComparison.OrdinalIgnoreCase) && OculusTrayTool.My.MySettings.Default.ApplyPowerPlan == 0)
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
        else if (MessageBox.Show("Oculus Tray Tool needs to be running to work its magic!\r\n\r\nAre you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
      }
      catch (Exception ex)
      {
          Log.WriteToLog("Error in Shutdown: " + ex.Message);
      }
    }

    private void ComboSSstart_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar == (int) Convert.ToChar(this.DSep))
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
        //ProjectData.SetProjectError(ex);
        Exception e1 = ex;
        this.AddToListboxAndScroll("* Exception: " + e1.Message);
        Log.WriteToLog("WARNING TRIGGERED: CheckStopServiceHome exception");
        this.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e1, true);
        Log.WriteToLog(e1.ToString() + stackTrace.ToString());
        //ProjectData.ClearProjectError();
      }
    }

    public virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }














    


    private delegate void TimerStart();

    private delegate void AppTimerStart();

    public void AddToListboxAndScroll(string text)
    {
       // Use replacement control if available, otherwise fallback to designer control (for safety)
       ListBox targetList = _logListBox != null ? _logListBox : this.ListBox1;
       
       if (targetList == null) return; // Should not happen

       if (targetList.InvokeRequired)
       {
           this.Invoke((Delegate) new FrmMain.AddToListboxAndScrollDelegate(this.AddToListboxAndScroll), (object) text);
       }
       else
       {
           // Explicit visibility force for new control too
           if (!targetList.Visible) targetList.Visible = true;
           
           targetList.Items.Add((object) text);
           targetList.TopIndex = checked (targetList.Items.Count - 1);
           
           // Refresh to be sure
           targetList.Refresh();
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
    }



    private void kbHook_KeyDown(Keys Key)
    {
    }

    private void kbHook_KeyUp(Keys Key)
    {
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
    }

    private string GetSteamPath() { return ""; }
    private string GetSteamVR() { return ""; }

    private void CheckWarnings() { }
    private void CheckOculusService() { }
    internal void StartOVR()
    {
        try
        {
            ServiceController sc = new ServiceController("OVRService");
            if (sc.Status != ServiceControllerStatus.Running)
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                Log.WriteToLog("OVRService Started");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error starting Oculus Service: " + ex.Message);
            Log.WriteToLog("Error starting Oculus Service: " + ex.ToString());
        }
    }

    internal void StopOVR()
    {
        try
        {
            ServiceController sc = new ServiceController("OVRService");
            if (sc.Status != ServiceControllerStatus.Stopped)
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                Log.WriteToLog("OVRService Stopped");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error stopping Oculus Service: " + ex.Message);
            Log.WriteToLog("Error stopping Oculus Service: " + ex.ToString());
        }
    }
    internal void ApplyAswTick(object sender, ElapsedEventArgs e) { Log.WriteToLog("ApplyAswTick stub called"); }
    internal void ApplyCpuPrioTick(object sender, ElapsedEventArgs e) { Log.WriteToLog("ApplyCpuPrioTick stub called"); }
    internal void AppWork(object sender, DoWorkEventArgs e) { Log.WriteToLog("AppWork stub called"); }
    private void EnableDisableVoice(bool enable) { }
    private void EnableShowHomeMenu() { }
    private void DisableShowHomeMenu() { }
    
    private void CheckStartWindows_CheckedChanged(object sender, EventArgs e) { }
    private void NotifyIcon1_DoubleClick(object sender, EventArgs e) { }
    private void ButtonStartOVR_Click(object sender, EventArgs e)
    {
        StartOVR();
    }
    private void ToolStripMenuItem1_Click(object sender, EventArgs e) { }
    private void ToolStripMenuItem2_Click(object sender, EventArgs e) { }
    private void ButtonStopOVR_Click(object sender, EventArgs e)
    {
        StopOVR();
    }
    private void CheckStartService_CheckedChanged(object sender, EventArgs e) { }
    private void CheckLaunchHome_CheckedChanged(object sender, EventArgs e) { }
    private void CheckStopService_CheckedChanged(object sender, EventArgs e) { }
    private void ButtonRestartOVR_Click(object sender, EventArgs e)
    {
        StopOVR();
        Thread.Sleep(1000);
        StartOVR();
    }
    private void CheckLaunchHomeTool_CheckedChanged(object sender, EventArgs e) { }
    private void CheckCloseHome_CheckedChanged(object sender, EventArgs e) { }
    private void CheckBoxAltTab_CheckedChanged(object sender, EventArgs e) { }
    private void CheckRiftAudio_CheckedChanged(object sender, EventArgs e) { }
    private void OculusHomeWatcher_Tick(object sender, EventArgs e) { }
    private void ToolStripMenuItem3_Click(object sender, EventArgs e) { }
    private void CheckSpoofCPU_CheckedChanged(object sender, EventArgs e) { }
    private void ToolStripStartOVR_Click(object sender, EventArgs e)
    {
        StartOVR();
    }
    private void ToolStripMenuItem5_Click(object sender, EventArgs e)
    {
        StopOVR();
    }
    private void ToolStripMenuItem6_Click(object sender, EventArgs e)
    {
        StopOVR();
        Thread.Sleep(1000);
        StartOVR();
    }
    private void ToolStripMenuItem4_Click(object sender, EventArgs e) { }
    private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnVoice_Click(object sender, EventArgs e)
    {
        new frmVoiceSettings().ShowDialog();
    }
    private void ComboSSstart_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnProfiles_Click(object sender, EventArgs e)
    {
        MyProject.Forms.frmProfiles.ShowDialog();
    }
    private void ComboVoice_SelectedIndexChanged(object sender, EventArgs e) { }
    private void HotKeysCheckBox_CheckedChanged(object sender, EventArgs e) { }
    private void ComboUSBsusp_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ComboPowerPlan_SelectedIndexChanged(object sender, EventArgs e) 
    { 

    }
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
    private void BtnConfigureAudio_Click(object sender, EventArgs e)
    {
        MyProject.Forms.FrmSetFallback.ShowDialog();
    }
    private void ComboApplyPlan_SelectedIndexChanged(object sender, EventArgs e) { }
    private void Button9_Click(object sender, EventArgs e) { }
    private void Button8_Click(object sender, EventArgs e) { }
    private void PictureBox2_Click(object sender, EventArgs e) { }
    private void CheckBoxCheckForUpdates_CheckedChanged(object sender, EventArgs e) { }
    private void Button2_Click(object sender, EventArgs e) { }
    private void ComboHomless_SelectedIndexChanged(object sender, EventArgs e) { }
    private void BtnHomless_Click(object sender, EventArgs e)
    {
        new frmHomeless().ShowDialog();
    }
    private void UpdateTimer_Tick(object sender, EventArgs e) { }
    private void ToolStripMenuShowHome_Click(object sender, EventArgs e) { }
    private void ComboVisualHUD_SelectedIndexChanged(object sender, EventArgs e) { }
    private void ComboMirrorHome_SelectedIndexChanged(object sender, EventArgs e) { }
    private void CheckRestartSleep_CheckedChanged(object sender, EventArgs e) { }
    private void BtnSteamImport_Click(object sender, EventArgs e)
    {
        new frmImportSteamApps().ShowDialog();
    }
    private void NotifyIcon3_MouseDown(object sender, MouseEventArgs e) { }
    private void BtnConfigureHotKeys_Click(object sender, EventArgs e)
    {
        new frmHotKeys().ShowDialog();
    }
    private void ClearLogToolStripMenuItem_Click(object sender, EventArgs e) 
    {
        Log.ClearLog();
        if (_logListBox != null) _logListBox.Items.Clear();
        else this.ListBox1.Items.Clear();
    }
    private void OpenLogToolStripMenuItem_Click(object sender, EventArgs e) { }
    private void BtnLibrary_Click(object sender, EventArgs e)
    {
        try {
            MyProject.Forms.frmLibrary.ShowDialog();
        } catch (Exception ex) {
            MessageBox.Show("Error opening Game Library: " + ex.ToString());
        }
    }
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
        if (this._NotifyIcon1 != null)
            this._NotifyIcon1.Visible = false;
        
        // Ensure the loading/status form is closed
        if (MyProject.Forms.frmLoading != null)
             MyProject.Forms.frmLoading.Close();
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
            {
                 MyProject.Forms.frmUpdateToast.ShowDialog();
            }
        } catch (Exception ex) {
            Log.WriteToLog("ShowUpdateToast error: " + ex.Message);
        }
    }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Globals.dbg)
                Log.WriteToLog("Form1_Shown: Refreshing Power Plan Comboboxes");
             // Removed redundant call as it is called in Form1_Load
        }

    private bool _controlsReplaced = false;

    private void ReplaceCorruptedControls()
    {
        if (_controlsReplaced) return;
        
        try
        {

            
            // Find the parent container (DbLayoutPanel5)
            Control[] foundControls = this.Controls.Find("DbLayoutPanel5", true);
            if (foundControls.Length == 0)
            {
                Log.WriteToLog("ReplaceCorruptedControls: ERROR - DbLayoutPanel5 not found!");
                return;
            }
            TableLayoutPanel parentPanel = (TableLayoutPanel)foundControls[0];

            // Helper to remove ALL controls at specific cell
            void RemoveControlAt(int col, int row)
            {
                // Iterate backwards safely
                for (int i = parentPanel.Controls.Count - 1; i >= 0; i--)
                {
                    Control ctrl = parentPanel.Controls[i];
                    TableLayoutPanelCellPosition pos = parentPanel.GetPositionFromControl(ctrl);
                    if (pos.Column == col && pos.Row == row)
                    {

                        parentPanel.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }
            }

            // 1. Clear and Recreate ComboPowerPlanStart (Cell 1, 0)
            RemoveControlAt(1, 0); // Clear the cell first!

            this.ComboPowerPlanStart = new ComboBox();
            this.ComboPowerPlanStart.Name = "ComboPowerPlanStart";
            this.ComboPowerPlanStart.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboPowerPlanStart.BackColor = System.Drawing.Color.White;
            this.ComboPowerPlanStart.ForeColor = System.Drawing.Color.Black;
            this.ComboPowerPlanStart.FlatStyle = FlatStyle.Standard; 
            this.ComboPowerPlanStart.FormattingEnabled = true;
            this.ComboPowerPlanStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular);
            this.ComboPowerPlanStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.ComboPowerPlanStart.Height = 21;
            this.ComboPowerPlanStart.SelectedIndexChanged += new EventHandler(this.ComboPowerPlan_SelectedIndexChanged);
            
            parentPanel.Controls.Add(this.ComboPowerPlanStart, 1, 0); // Add directly to cell
            




            // 2. Clear and Recreate ComboPowerPlanExit (Cell 1, 1)
            RemoveControlAt(1, 1); 

            this.ComboPowerPlanExit = new ComboBox();
            this.ComboPowerPlanExit.Name = "ComboPowerPlanExit";
            this.ComboPowerPlanExit.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboPowerPlanExit.BackColor = System.Drawing.Color.White;
            this.ComboPowerPlanExit.ForeColor = System.Drawing.Color.Black;
            this.ComboPowerPlanExit.FlatStyle = FlatStyle.Standard;
            this.ComboPowerPlanExit.FormattingEnabled = true;
            this.ComboPowerPlanExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular);
            this.ComboPowerPlanExit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.ComboPowerPlanExit.Height = 21;
            this.ComboPowerPlanExit.SelectedIndexChanged += new EventHandler(this.ComboPowerPlan_SelectedIndexChanged);

            parentPanel.Controls.Add(this.ComboPowerPlanExit, 1, 1);


            // 3. Clear and Recreate ComboApplyPlan (Cell 1, 2)
            RemoveControlAt(1, 2);

            this.ComboApplyPlan = new ComboBox();
            this.ComboApplyPlan.Name = "ComboApplyPlan";
            this.ComboApplyPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboApplyPlan.BackColor = System.Drawing.Color.White;
            this.ComboApplyPlan.ForeColor = System.Drawing.Color.Black;
            this.ComboApplyPlan.FlatStyle = FlatStyle.Standard;
            this.ComboApplyPlan.FormattingEnabled = true;
            this.ComboApplyPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular);
            this.ComboApplyPlan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.ComboApplyPlan.Height = 21;
            // Populate Items
            this.ComboApplyPlan.Items.AddRange(new object[] { "OTT Start/Exit", "Oculus Home Start/Exit" });
            this.ComboApplyPlan.SelectedIndex = 0; // Default: OTT Start/Exit
            this.ComboApplyPlan.SelectedIndexChanged += new EventHandler(this.ComboApplyPlan_SelectedIndexChanged);

            parentPanel.Controls.Add(this.ComboApplyPlan, 1, 2);


            // 4. Clear and Recreate ComboUSBsusp (Cell 1, 3)
            RemoveControlAt(1, 3);

            this.ComboUSBsusp = new ComboBox();
            this.ComboUSBsusp.Name = "ComboUSBsusp";
            this.ComboUSBsusp.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboUSBsusp.BackColor = System.Drawing.Color.White;
            this.ComboUSBsusp.ForeColor = System.Drawing.Color.Black;
            this.ComboUSBsusp.FlatStyle = FlatStyle.Standard;
            this.ComboUSBsusp.FormattingEnabled = true;
            this.ComboUSBsusp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular);
            this.ComboUSBsusp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.ComboUSBsusp.Height = 21;
            this.ComboUSBsusp.Items.AddRange(new object[] { "Disabled", "Enabled" });
            this.ComboUSBsusp.SelectedIndex = 0; // Default: Disabled
            this.ComboUSBsusp.SelectedIndexChanged += new EventHandler(this.ComboUSBsusp_SelectedIndexChanged); // Presumed handler
            
            parentPanel.Controls.Add(this.ComboUSBsusp, 1, 3);


            // --- LOG WINDOW REPLACEMENT ---
            ReplaceLogControl();


            // --- GAME SETTINGS REPLACEMENT ---
            ReplaceGameSettingsControls();
            
            // --- QUEST LINK REPLACEMENT ---
            ReplaceQuestLinkControls();


            _controlsReplaced = true;
            
            // --- FIX RESET BUTTON ---
            // Wire up "Reset all to default" (Button4) to our new logic
            try 
            {
                if (this.Button4 != null)
                {
                    // Remove existing handler(s) to prevent crash
                    this.Button4.Click -= this.Button4_Click;
                    // Attach new handler
                    this.Button4.Click += (s, e) => ResetDefaults();

                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog("ReplaceCorruptedControls: Warning - Could not wire Reset button: " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Log.WriteToLog("ReplaceCorruptedControls FATAL ERROR: " + ex.ToString());
        }
    }

    private void ResetDefaults()
    {
        try
        {
            Log.WriteToLog("ResetDefaults: Resetting all settings to defaults...");

            // Helper to set ComboBox value
            void SetCombo(Control container, string name, string val)
            {
                Control[] found = container.Controls.Find(name, true);
                if (found.Length > 0 && found[0] is ComboBox box)
                {
                    int idx = box.FindStringExact(val);
                    if (idx != -1) box.SelectedIndex = idx;
                    else box.Text = val;
                }
            }

            // 1. Game Settings
            Control[] gsPanels = this.Controls.Find("DbLayoutPanel5", true); // "Settings" panel
            if (gsPanels.Length > 0)
            {
                 // Defaults based on "Default" or "0"
                 SetCombo(gsPanels[0], "ComboSSstart", "0.0"); // Super Sampling
                 SetCombo(gsPanels[0], "ComboBox1", "Auto"); // ASW
                 SetCombo(gsPanels[0], "ComboBox2", "Default"); // Adaptive GPU
                 SetCombo(gsPanels[0], "ComboVoice", "Disabled");
                 SetCombo(gsPanels[0], "ComboHomless", "Disabled");
                 SetCombo(gsPanels[0], "ComboMirrorHome", "Disabled");
                 SetCombo(gsPanels[0], "ComboVisualHUD", "None");
                 SetCombo(gsPanels[0], "ComboOVRPrio", "Normal");
                 SetCombo(gsPanels[0], "ComboBox8", "False"); // Force MipMap
                 SetCombo(gsPanels[0], "ComboBox9", "0"); // Offset MipMap
            }

            // 2. Quest Link
            // We need to find the Quest Link panel again. 
            // Reuse the label finding logic or cache the panel? 
            // Caching is risky if controls are recreated. Let's find by unique label again.
            Label FindLabel(Control parent, string text)
            {
                foreach (Control c in parent.Controls)
                {
                    if (c is Label lbl && lbl.Text.Contains(text)) return lbl;
                    if (c.HasChildren) { var f = FindLabel(c, text); if (f!=null) return f; }
                }
                return null;
            }
            Label qLabel = FindLabel(this, "Distortion Curvature");
            if (qLabel != null && qLabel.Parent != null)
            {
                 Control qPanel = qLabel.Parent;
                 SetCombo(qPanel, "ComboLinkDistortion", "Default");
                 SetCombo(qPanel, "ComboLinkResolution", "0");
                 SetCombo(qPanel, "ComboLinkBitrate", "0");
                 SetCombo(qPanel, "ComboLinkDynamicBitrate", "Default");
                 SetCombo(qPanel, "ComboLinkDynamicBitrateMax", "0");
                 SetCombo(qPanel, "ComboLinkSharpening", "Auto");
            }
            
            MessageBox.Show("All settings have been reset to default.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            Log.WriteToLog("ResetDefaults Error: " + ex.Message);
            MessageBox.Show("Error resetting defaults: " + ex.Message);
        }
    }

    private void ReplaceGameSettingsControls()
    {
        try
        {
            // Robust Discovery: Find the panel by looking for the unique Label "Default Super Sampling"
            TableLayoutPanel settingsPanel = null;

            // Local helper to recursively find the label
            Label FindLabelByText(Control parent, string text)
            {
                foreach (Control c in parent.Controls)
                {
                    if (c is Label lbl && lbl.Text.Contains(text)) return lbl;
                    if (c.HasChildren)
                    {
                        Label found = FindLabelByText(c, text);
                        if (found != null) return found;
                    }
                }
                return null;
            }

            Label targetLabel = FindLabelByText(this, "Default Super Sampling");
            if (targetLabel != null && targetLabel.Parent is TableLayoutPanel)
            {
                settingsPanel = (TableLayoutPanel)targetLabel.Parent;
            }

            if (settingsPanel == null)
            {
                Log.WriteToLog("ReplaceGameSettingsControls: ERROR - Could not find 'Default Super Sampling' label or its parent panel!");
                // Fallback attempt: DbLayoutPanel1?
                 Control[] found = this.Controls.Find("DbLayoutPanel1", true);
                 if (found.Length > 0) settingsPanel = (TableLayoutPanel)found[0];
            }

            if (settingsPanel == null) {
                 Log.WriteToLog("ReplaceGameSettingsControls: FATAL - Settings Panel NOT FOUND.");
                 return;
            }
           


            // Helper to find row by label text
            int GetRowForLabel(string labelText)
            {
                foreach (Control c in settingsPanel.Controls)
                {
                    if (c is Label lbl && lbl.Text != null && lbl.Text.IndexOf(labelText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var pos = settingsPanel.GetPositionFromControl(c);
                        // Log.WriteToLog("ReplaceGameSettingsControls: Mapped '" + labelText + "' to Row " + pos.Row);
                        return pos.Row;
                    }
                }
                Log.WriteToLog("ReplaceGameSettingsControls: WARNING - Could not find label containing '" + labelText + "'");
                return -1;
            }

            // Helpers
            void ReplaceCombo(string labelText, string name, string[] items, string defaultVal)
            {
                int row = GetRowForLabel(labelText);
                if (row == -1) return; // Skip if label not found

                // Remove existing at (1, row)
                 for (int i = settingsPanel.Controls.Count - 1; i >= 0; i--)
                {
                    Control ctrl = settingsPanel.Controls[i];
                    TableLayoutPanelCellPosition pos = settingsPanel.GetPositionFromControl(ctrl);
                    if (pos.Column == 1 && pos.Row == row)
                    {
                        settingsPanel.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }

                ComboBox box = new ComboBox();
                box.Name = name;
                box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.BackColor = Color.White;
                box.ForeColor = Color.Black;
                box.FlatStyle = FlatStyle.Standard;
                box.Font = new Font("Microsoft Sans Serif", 8.25f);
                box.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                box.Height = 21;
                
                if (items != null) box.Items.AddRange(items);
                if (defaultVal != null) 
                {
                    int idx = box.FindStringExact(defaultVal);
                    if (idx != -1) box.SelectedIndex = idx;
                    else box.Text = defaultVal;
                }
                
                settingsPanel.Controls.Add(box, 1, row);
            }
            
            // 1. Super Sampling
             string[] ssItems = new string[] { "0.0", "1.0", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "2.0", "2.5" };
             ReplaceCombo("Super Sampling", "ComboSSstart", ssItems, "0.0");
             
             // 2. ASW Mode
             string[] aswItems = new string[] { "Auto", "Off", "45 Hz", "30 Hz", "18 Hz", "45 Hz forced", "Adaptive" };
             ReplaceCombo("ASW Mode", "ComboBox1", aswItems, "Auto");

             // 3. Adaptive GPU Scaling
             ReplaceCombo("Adaptive GPU", "ComboBox2", new string[] { "Default", "On", "Off" }, "On"); 
             
             // 4. Voice Commands
             ReplaceCombo("Voice Commands", "ComboVoice", new string[] { "Disabled", "English", "German", "French", "Spanish", "Italian" }, "Disabled");
             
             // 5. Oculus Homeless
             ReplaceCombo("Homeless", "ComboHomless", new string[] { "Disabled", "Enabled" }, "Disabled");
             
             // 6. Mirror Oculus Home
             ReplaceCombo("Mirror", "ComboMirrorHome", new string[] { "Disabled", "Enabled" }, "Disabled");

             // 7. Visual HUD
             ReplaceCombo("Visual HUD", "ComboVisualHUD", new string[] { "None", "Performance", "Stereo Debug", "Layer", "Compositor" }, "None");

             // 8. OVR Server Priority
             ReplaceCombo("Priority", "ComboOVRPrio", new string[] { "Normal", "High", "Realtime" }, "Normal"); 
             
             // 9. Force MipMap
             ReplaceCombo("Force MipMap", "ComboBox8", new string[] { "False", "True" }, "False");

             // 10. Offset MipMap
             ReplaceCombo("Offset MipMap", "ComboBox9", new string[] { "0", "1", "2", "-1", "-2" }, "0");


        }
        catch (Exception ex)
        {
            Log.WriteToLog("ReplaceGameSettingsControls Error: " + ex.Message);
        }
    }

    private void ReplaceQuestLinkControls()
    {
        try
        {
            TableLayoutPanel settingsPanel = null;

            // Local helper to recursively find the label
            Label FindLabelByText(Control parent, string text)
            {
                foreach (Control c in parent.Controls)
                {
                    if (c is Label lbl && lbl.Text.Contains(text)) return lbl;
                    if (c.HasChildren)
                    {
                        Label found = FindLabelByText(c, text);
                        if (found != null) return found;
                    }
                }
                return null;
            }

            // "Distortion Curvature" is unique to Quest Link tab
            Label targetLabel = FindLabelByText(this, "Distortion Curvature");
            if (targetLabel != null && targetLabel.Parent is TableLayoutPanel)
            {
                settingsPanel = (TableLayoutPanel)targetLabel.Parent;
            }

            if (settingsPanel == null)
            {
                Log.WriteToLog("ReplaceQuestLinkControls: ERROR - Could not find Quest Link panel!");
                return;
            }
           


            int GetRowForLabel(string labelText)
            {
                foreach (Control c in settingsPanel.Controls)
                {
                    if (c is Label lbl && lbl.Text != null && lbl.Text.IndexOf(labelText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var pos = settingsPanel.GetPositionFromControl(c);
                        // Log.WriteToLog("ReplaceQuestLinkControls: Mapped '" + labelText + "' to Row " + pos.Row);
                        return pos.Row;
                    }
                }
                Log.WriteToLog("ReplaceQuestLinkControls: WARNING - Could not find label containing '" + labelText + "'");
                return -1;
            }

            void ReplaceCombo(string labelText, string name, string[] items, string defaultVal)
            {
                int row = GetRowForLabel(labelText);
                if (row == -1) return; // Skip if label not found

                // Remove existing control at (Column 1, Row)
                for (int i = settingsPanel.Controls.Count - 1; i >= 0; i--)
                {
                    Control ctrl = settingsPanel.Controls[i];
                    TableLayoutPanelCellPosition pos = settingsPanel.GetPositionFromControl(ctrl);
                    if (pos.Column == 1 && pos.Row == row)
                    {
                        settingsPanel.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }

                ComboBox box = new ComboBox();
                box.Name = name;
                box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.BackColor = Color.White;
                box.ForeColor = Color.Black;
                box.FlatStyle = FlatStyle.Standard;
                box.Font = new Font("Microsoft Sans Serif", 8.25f);
                box.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                box.Margin = new Padding(3, 0, 3, 0); // Tweak margin to match if needed
                box.Height = 21;
                
                if (items != null) box.Items.AddRange(items);
                if (defaultVal != null) 
                {
                    int idx = box.FindStringExact(defaultVal);
                    if (idx != -1) box.SelectedIndex = idx;
                    else box.Text = defaultVal;
                }
                
                settingsPanel.Controls.Add(box, 1, row);
            }
            
            // 1. Distortion Curvature: Default, Low, High
            ReplaceCombo("Distortion Curvature", "ComboLinkDistortion", new string[] { "Default", "Low", "High" }, "Default");

            // 2. Encode Resolution
            ReplaceCombo("Encode Resolution", "ComboLinkResolution", new string[] { "0", "1832", "2048", "2352", "2784", "3648", "3664" }, "0"); 

            // 3. Encode Bitrate
            ReplaceCombo("Encode Bitrate", "ComboLinkBitrate", new string[] { "0", "100", "150", "200", "250", "300", "350", "400", "500" }, "0");

            // 4. Encode Dynamic Bitrate
            ReplaceCombo("Encode Dynamic Bitrate", "ComboLinkDynamicBitrate", new string[] { "Default", "Enabled", "Disabled" }, "Default");

            // 5. Dynamic Bitrate Max
            ReplaceCombo("Dynamic Bitrate Max", "ComboLinkDynamicBitrateMax", new string[] { "0", "100", "150", "200" }, "0");

            // 6. Sharpening
            ReplaceCombo("Sharpening", "ComboLinkSharpening", new string[] { "Auto", "Normal", "Quality" }, "Auto");


        }
        catch (Exception ex)
        {
            Log.WriteToLog("ReplaceQuestLinkControls Error: " + ex.Message);
        }
    }

    private ListBox _logListBox; // Replacement for corrupted ListBox1

    private void ReplaceLogControl()
    {
        try 
        {
            // Find GroupBox3 (Log Container)
            Control[] found = this.Controls.Find("GroupBox3", true);
            if (found.Length == 0) 
            {
                Log.WriteToLog("ReplaceLogControl: ERROR - GroupBox3 not found!");
                return;
            }
            GroupBox container = (GroupBox)found[0];
            
            // Clear existing corrupted controls
            container.Controls.Clear();
            
            // Create fresh ListBox
            _logListBox = new ListBox();
            _logListBox.Name = "ListBox1_Replacement";
            _logListBox.Dock = DockStyle.Fill;
            _logListBox.BorderStyle = BorderStyle.None;
            _logListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            _logListBox.ForeColor = System.Drawing.Color.DodgerBlue;
            _logListBox.BackColor = System.Drawing.Color.White;
            _logListBox.FormattingEnabled = true;
            _logListBox.HorizontalScrollbar = true;
            _logListBox.ItemHeight = 15;
            
            // Create "Clear Log" Button
            Button btnClear = new Button();
            btnClear.Name = "BtnClearLog";
            btnClear.Text = "Clear Log";
            btnClear.Dock = DockStyle.Bottom;
            btnClear.Height = 30;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.BackColor = System.Drawing.Color.WhiteSmoke;
            btnClear.ForeColor = System.Drawing.Color.Black;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += (sender, e) => {
                try {
                    // Clear UI
                    if (_logListBox != null) _logListBox.Items.Clear();
                    // Clear File
                    Log.ClearLog();
                    // Feedback
                    _logListBox?.Items.Add("Log Cleared.");
                } catch {}
            };

            // Add Control (Order matters for Docking: Add Bottom first, then Fill)
            container.Controls.Add(_logListBox); // Fill
            container.Controls.Add(btnClear);    // Bottom (added last = processed first in dock layout?? No, standard Forms docking: Last added is closest to edge usually, or z-order matters. Let's try adding button first, then listbox)
            // Correction: In WinForms, the LAST control added to collection is at the START of the Z-order.
            // Dock=Fill takes remaining space. Dock=Bottom takes bottom slice.
            // If I add ListBox (Fill) first, it might take everything.
            // Safest: Add Button (Dock=Bottom), THEN ListBox (Dock=Fill) with BringToFront().
            
            // Let's redo addition order:
            container.Controls.Clear();
            container.Controls.Add(_logListBox); 
            container.Controls.Add(btnClear);
            
            // Set Docking Correctly
            btnClear.Dock = DockStyle.Bottom;
            _logListBox.Dock = DockStyle.Fill;
            
            // Z-Order: To make sure ListBox doesn't cover Button, we usually want Button to claim its space first.
            // Actually, in auto-layout, Docking priority is determined by Z-Index.
            // The control with index 0 (top of Z-order) gets priority.
            // So we want Button to be index 0? Or index 1?
            // Usually: Add Button. Dock Bottom. Add ListBox. Dock Fill. Bring ListBox Front? 
            
            // Let's just use standard add order and explicit BringToFront/SendToBack if needed.
            // If I add Button first, it is at 0. then ListBox at 0 (Button becomes 1).
            // Let's try:
            // 1. Add ListBox (Fill)
            // 2. Add Button (Bottom)
            // 3. Button.BringToFront() -> Button is 0. Button claims Bottom. ListBox claims remaining Fill.
            
            btnClear.BringToFront();


        }
        catch (Exception ex)
        {
            Log.WriteToLog("ReplaceLogControl ERROR: " + ex.Message);
        }
    }

    private void LoadPowerPlansDirectly()
    {
        try
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.LoadPowerPlansDirectly));
                return;
            }

            // Ensure we are working with fresh, non-corrupted controls
            ReplaceCorruptedControls();



            // Clear existing items
            this.ComboPowerPlanStart.Items.Clear();
            this.ComboPowerPlanExit.Items.Clear();

            // Add items from the PowerPlans.PlanNames list that was populated by PowerPlans.GetPowerPlans()
            if (PowerPlans.PlanNames != null && PowerPlans.PlanNames.Count > 0)
            {
                foreach (string planName in PowerPlans.PlanNames)
                {
                    this.ComboPowerPlanStart.Items.Add(planName);
                    this.ComboPowerPlanExit.Items.Add(planName);

                }
            }
            else
            {
                Log.WriteToLog("LoadPowerPlansDirectly: PowerPlans.PlanNames is empty or null, falling back to " + ((char)34) + "Not Used" + ((char)34) + ".");
                
                // Fallback to "Not Used" if no plans found
                this.ComboPowerPlanStart.Items.Add("Not Used");
                this.ComboPowerPlanExit.Items.Add("Not Used");
            }

            
            // Log.WriteToLog("LoadPowerPlansDirectly: Populated " + this.ComboPowerPlanStart.Items.Count + " items in ComboPowerPlanStart and " + this.ComboPowerPlanExit.Items.Count + " items in ComboPowerPlanExit.");
            
            // Set default selections
            if (this.ComboPowerPlanStart.Items.Count > 0)
                this.ComboPowerPlanStart.SelectedIndex = 0;

            if (this.ComboPowerPlanExit.Items.Count > 0)
                this.ComboPowerPlanExit.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.WriteToLog("LoadPowerPlansDirectly Error: " + ex.Message);
        }
    }
}
}
