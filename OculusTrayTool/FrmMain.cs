using System;
using System.Collections;
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

namespace OculusTrayTool
{
	// Token: 0x0200004F RID: 79
	[DesignerGenerated]
	public partial class FrmMain : Form
	{
		// Token: 0x170001FE RID: 510
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0002F284 File Offset: 0x0002D484
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x0002F290 File Offset: 0x0002D490
		private virtual ManagementEventWatcher Watcher
		{
			[CompilerGenerated]
			get
			{
				return this._Watcher;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventArrivedEventHandler eventArrivedEventHandler = new EventArrivedEventHandler(this.Watcher_EventArrived);
				ManagementEventWatcher managementEventWatcher = this._Watcher;
				if (managementEventWatcher != null)
				{
					managementEventWatcher.EventArrived -= eventArrivedEventHandler;
				}
				this._Watcher = value;
				managementEventWatcher = this._Watcher;
				if (managementEventWatcher != null)
				{
					managementEventWatcher.EventArrived += eventArrivedEventHandler;
				}
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x0002F2D3 File Offset: 0x0002D4D3
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x0002F2E0 File Offset: 0x0002D4E0
		public virtual ManagementEventWatcher MinimizeHomeWatcher
		{
			[CompilerGenerated]
			get
			{
				return this._MinimizeHomeWatcher;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventArrivedEventHandler eventArrivedEventHandler = new EventArrivedEventHandler(this.MinimizeHomeWatcher_EventArrived);
				ManagementEventWatcher managementEventWatcher = this._MinimizeHomeWatcher;
				if (managementEventWatcher != null)
				{
					managementEventWatcher.EventArrived -= eventArrivedEventHandler;
				}
				this._MinimizeHomeWatcher = value;
				managementEventWatcher = this._MinimizeHomeWatcher;
				if (managementEventWatcher != null)
				{
					managementEventWatcher.EventArrived += eventArrivedEventHandler;
				}
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0002F323 File Offset: 0x0002D523
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0002F330 File Offset: 0x0002D530
		public virtual KeyboardHook kbHook
		{
			[CompilerGenerated]
			get
			{
				return this._kbHook;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyboardHook.KeyDownEventHandler keyDownEventHandler = new KeyboardHook.KeyDownEventHandler(this.kbHook_KeyDown);
				KeyboardHook.KeyUpEventHandler keyUpEventHandler = new KeyboardHook.KeyUpEventHandler(this.kbHook_KeyUp);
				if (this._kbHook != null)
				{
					KeyboardHook.KeyDown -= keyDownEventHandler;
					KeyboardHook.KeyUp -= keyUpEventHandler;
				}
				this._kbHook = value;
				if (this._kbHook != null)
				{
					KeyboardHook.KeyDown += keyDownEventHandler;
					KeyboardHook.KeyUp += keyUpEventHandler;
				}
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0002F388 File Offset: 0x0002D588
		public FrmMain()
		{
			base.Load += this.Form1_Load;
			base.FormClosing += this.frmMain_FormClosing;
			base.Resize += this.Form1_Resize;
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
			this.customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
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
			this.colRemovedTabs = new Collection();
			this.steamvr = "";
			this.Hometimer = new global::System.Windows.Forms.Timer();
			this.pTimer = new global::System.Timers.Timer();
			this.ManualStart = false;
			this.restartInDBG = false;
			this.ignoredApps = new List<string>();
			this.includedApps = new List<string>();
			this.voiceProfileNames = new List<string>();
			this.ovrDown = false;
			this.Update_URL = "https://www.dropbox.com/s/63qb2oswo2o3ugt/version.txt?dl=1";
			this.UpdateTest_URL = "https://www.dropbox.com/s/v11ce9oww5yhkg4/version_test_2.txt?dl=1";
			this.voiceSettingsLoaded = false;
			this._Home2Timer = new global::System.Timers.Timer(100.0);
			this.restartHome = false;
			this.mirrorTimer = new global::System.Timers.Timer();
			this.StartingUp = false;
			this.AswToggle = new List<string>();
			this.cpuTimer = new global::System.Timers.Timer();
			this.aswTimer = new global::System.Timers.Timer();
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

		// Token: 0x060005E2 RID: 1506 RVA: 0x0002F654 File Offset: 0x0002D854
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				this.StartingUp = true;
				FrmMain.fmain = this;
				FrmMain.lockObject = RuntimeHelpers.GetObjectValue(new object());
				this.rs.FindAllControls(this);
				string[] commandLineArgs = Environment.GetCommandLineArgs();
				foreach (string text in commandLineArgs)
				{
					bool flag = Operators.CompareString(text, "-r", false) == 0;
					if (flag)
					{
						MySettingsProperty.Settings.Reset();
						MySettingsProperty.Settings.Save();
						this.Shutdown();
					}
					bool flag2 = Operators.CompareString(text, "-d", false) == 0;
					if (flag2)
					{
						Globals.dbg = true;
					}
					else
					{
						Globals.dbg = false;
					}
					bool flag3 = Operators.CompareString(text, "-u", false) == 0;
					if (flag3)
					{
						MySettingsProperty.Settings.UpgradeRequired = true;
					}
				}
				bool flag4 = !Globals.dbg;
				if (flag4)
				{
					bool runDebug = MySettingsProperty.Settings.RunDebug;
					if (runDebug)
					{
						MySettingsProperty.Settings.RunDebug = false;
						MySettingsProperty.Settings.Save();
						Globals.dbg = true;
					}
				}
				bool dbg = Globals.dbg;
				if (dbg)
				{
					string text2 = DateTime.Now.ToString().Replace("/", "").Replace("\\", "")
						.Replace("-", "")
						.Replace(" ", "_")
						.Replace(":", "");
					FileSystem.Rename(Application.StartupPath + "\\ott.log", "ott_" + text2 + ".log");
					Log.WriteToLog(":: Debug is ON ::");
				}
				Log.WriteToLog("Starting up...");
				Log.WriteToLog("Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
				VoiceCommands.Initialize();
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Checking Administrator privileges");
				}
				WindowsIdentity current = WindowsIdentity.GetCurrent();
				WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
				this.isElevated = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
				bool flag5 = !this.isElevated;
				if (flag5)
				{
					Interaction.MsgBox("You must run Oculus Tray Tool as Administrator.\r\nThe application will now exit.", MsgBoxStyle.Critical, "Oculus Tray Tool");
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
				bool flag6 = !File.Exists(Application.StartupPath + "\\Microsoft.Speech.dll");
				if (flag6)
				{
					Log.WriteToLog("Missing dependency: Microsoft.Speech.dll, cannot continue");
					Interaction.MsgBox("Missing dependency: Microsoft.Speech.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
					base.Dispose();
				}
				else
				{
					bool flag7 = !File.Exists(Application.StartupPath + "\\CoreAudio.dll");
					if (flag7)
					{
						Log.WriteToLog("Missing dependency: CoreAudio.dll, cannot continue");
						Interaction.MsgBox("Missing dependency: CoreAudio.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
						base.Dispose();
					}
					else
					{
						bool flag8 = !File.Exists(Application.StartupPath + "\\Microsoft.Win32.TaskScheduler.dll");
						if (flag8)
						{
							Log.WriteToLog("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue");
							Interaction.MsgBox("Missing dependency: Microsoft.Win32.TaskScheduler.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
							base.Dispose();
						}
						else
						{
							bool flag9 = !File.Exists(Application.StartupPath + "\\Newtonsoft.Json.dll");
							if (flag9)
							{
								Log.WriteToLog("Missing dependency: Newtonsoft.Json.dll, cannot continue");
								Interaction.MsgBox("Missing dependency: Newtonsoft.Json.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
								base.Dispose();
							}
							else
							{
								bool flag10 = !File.Exists(Application.StartupPath + "\\SQLite.Interop.dll");
								if (flag10)
								{
									Log.WriteToLog("Missing dependency: SQLite.Interop.dll, cannot continue");
									Interaction.MsgBox("Missing dependency: SQLite.Interop.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
									base.Dispose();
								}
								else
								{
									bool flag11 = !File.Exists(Application.StartupPath + "\\System.Data.SQLite.dll");
									if (flag11)
									{
										Log.WriteToLog("Missing dependency: System.Data.SQLite.dll, cannot continue");
										Interaction.MsgBox("Missing dependency: System.Data.SQLite.dll, cannot continue", MsgBoxStyle.Critical, "Oculus Tray Tool");
										base.Dispose();
									}
									else
									{
										bool dbg3 = Globals.dbg;
										if (dbg3)
										{
											Log.WriteToLog("Show Loading toast");
										}
										MyProject.Forms.frmLoading.Show();
										bool upgradeRequired = MySettingsProperty.Settings.UpgradeRequired;
										if (upgradeRequired)
										{
											Log.WriteToLog("Migrating user settings to new version");
											MySettingsProperty.Settings.Upgrade();
											MySettingsProperty.Settings.UpgradeRequired = false;
											MySettingsProperty.Settings.StartWithWindows = false;
											MySettingsProperty.Settings.Save();
										}
										OTTDB.CheckDB();
										this.TrackBar1.Value = checked((int)Math.Round((double)MySettingsProperty.Settings.FontSize));
										this.Label14.Text = "Font Size: " + Conversions.ToString(this.TrackBar1.Value);
										this.rs.ResizeAllControls(this, (float)this.TrackBar1.Value);
										MyProject.Forms.frmProfiles.ListView1.Font = new Font(MyProject.Forms.frmProfiles.ListView1.Font.Name, MySettingsProperty.Settings.FontSize, FontStyle.Regular);
										MyProject.Forms.frmProfiles.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
										this.UpdateTab = this.DotNetBarTabcontrol1.TabPages[6];
										this.colRemovedTabs.Add(this.TabPage6, this.TabPage6.Name, null, null);
										this.DotNetBarTabcontrol1.TabPages.Remove(this.TabPage6);
										bool dbg4 = Globals.dbg;
										if (dbg4)
										{
											Log.WriteToLog("Checking .NET version");
										}
										GetDotNetVersion.GetVersion();
										bool flag12 = MySettingsProperty.Settings.WindowLocation != default(Point);
										if (flag12)
										{
											bool dbg5 = Globals.dbg;
											if (dbg5)
											{
												Log.WriteToLog("Setting GUI location to " + MySettingsProperty.Settings.WindowLocation.ToString());
											}
											base.Location = MySettingsProperty.Settings.WindowLocation;
										}
										else
										{
											Log.WriteToLog("Setting GUI location to Center Screen");
											base.CenterToScreen();
											MySettingsProperty.Settings.WindowLocation = base.Location;
											MySettingsProperty.Settings.Save();
										}
										bool flag13 = (base.Location.X < 0) | (base.Location.Y < 0);
										if (flag13)
										{
											Log.WriteToLog("GUI location has negative number, adjusting");
											base.CenterToScreen();
											MySettingsProperty.Settings.WindowLocation = base.Location;
											MySettingsProperty.Settings.Save();
										}
										bool flag14 = MySettingsProperty.Settings.GuiSize != default(Size);
										if (flag14)
										{
											base.Size = MySettingsProperty.Settings.GuiSize;
										}
										Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
										this.scaleX = graphics.DpiX / 96f;
										this.scaleY = graphics.DpiY / 96f;
										this.Text = this.Text + " " + Application.ProductVersion.Substring(0, 8);
										MyProject.Forms.frmAbout.Label4.Text = Application.ProductVersion.Substring(0, 8);
										this.customCulture.NumberFormat.NumberDecimalSeparator = ".";
										bool dbg6 = Globals.dbg;
										if (dbg6)
										{
											Log.WriteToLog("Setting culture to " + this.customCulture.ToString());
										}
										Thread.CurrentThread.CurrentCulture = this.customCulture;
										this.Is64Bit = Environment.Is64BitOperatingSystem;
										bool dbg7 = Globals.dbg;
										if (dbg7)
										{
											Log.WriteToLog("is64Bit=" + Conversions.ToString(this.Is64Bit));
										}
										bool flag15 = !this.isElevated;
										if (flag15)
										{
											this.AddToListboxAndScroll("** Not running as Administrator **");
											Log.WriteToLog("Not running as Administrator!");
											this.hasError = true;
										}
										string text3 = this.ToolTip.GetToolTip(this.CheckSpoofCPU);
										bool flag16 = Operators.CompareString(text3, null, false) != 0;
										if (flag16)
										{
											bool flag17 = text3.Length > 75;
											if (flag17)
											{
												this.ToolTip.SetToolTip(this.CheckSpoofCPU, this.SplitToolTip(text3));
											}
										}
										text3 = this.ToolTip.GetToolTip(this.Label13);
										bool flag18 = Operators.CompareString(text3, null, false) != 0;
										if (flag18)
										{
											bool flag19 = text3.Length > 75;
											if (flag19)
											{
												this.ToolTip.SetToolTip(this.Label13, this.SplitToolTip(text3));
											}
										}
										text3 = this.ToolTip.GetToolTip(this.Label18);
										bool flag20 = Operators.CompareString(text3, null, false) != 0;
										if (flag20)
										{
											bool flag21 = text3.Length > 75;
											if (flag21)
											{
												this.ToolTip.SetToolTip(this.Label18, this.SplitToolTip(text3));
											}
										}
										text3 = this.ToolTip.GetToolTip(this.CheckLocalDebug);
										bool flag22 = Operators.CompareString(text3, null, false) != 0;
										if (flag22)
										{
											bool flag23 = text3.Length > 75;
											if (flag23)
											{
												this.ToolTip.SetToolTip(this.CheckLocalDebug, this.SplitToolTip(text3));
											}
										}
										text3 = this.ToolTip.GetToolTip(this.CheckStartWatcher);
										bool flag24 = Operators.CompareString(text3, null, false) != 0;
										if (flag24)
										{
											bool flag25 = text3.Length > 75;
											if (flag25)
											{
												this.ToolTip.SetToolTip(this.CheckStartWatcher, this.SplitToolTip(text3));
											}
										}
										bool flag26 = File.Exists(Application.StartupPath + "\\data.sqlite");
										if (flag26)
										{
											File.Delete(Application.StartupPath + "\\data.sqlite");
											bool dbg8 = Globals.dbg;
											if (dbg8)
											{
												Log.WriteToLog("Database copy deleted");
											}
										}
										bool dbg9 = Globals.dbg;
										if (dbg9)
										{
											Log.WriteToLog("Looking for Oculus database");
										}
										bool flag27 = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite");
										if (flag27)
										{
											bool dbg10 = Globals.dbg;
											if (dbg10)
											{
												Log.WriteToLog("Database found, making a copy");
											}
											try
											{
												File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
											}
											catch (Exception ex)
											{
												Log.WriteToLog("Failed to create database copy: " + ex.Message);
												Interaction.MsgBox("Failed to create database copy: " + ex.Message, MsgBoxStyle.Critical, "Error copying database");
												this.AddToListboxAndScroll("Failed to create database copy: " + ex.Message);
												this.hasError = true;
												return;
											}
										}
										OculusTrayTool.OculusPath.GetOculusPath();
										GetConfig.IsReading = true;
										OTTDB.OpenOttDB();
										PowerPlans.GetPowerPlans();
										GetConfig.GetConfig();
										bool flag28 = (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) == 0) | string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString());
										if (flag28)
										{
											MySettingsProperty.Settings.LibraryPath = "";
											MySettingsProperty.Settings.Save();
											Log.WriteToLog("Oculus Library paths not set, retrieving them from the registry");
											this.OculusSoftwarePaths = (List<string>)OculusTrayTool.OculusPath.GetOculusSoftwarePaths();
											Log.WriteToLog("Found " + this.OculusSoftwarePaths.Count.ToString() + " library paths");
											bool flag29 = this.OculusSoftwarePaths.Count > 0;
											if (flag29)
											{
												try
												{
													foreach (string text4 in this.OculusSoftwarePaths)
													{
														Log.WriteToLog("Oculus Library path: " + text4.TrimEnd(new char[] { '\\' }));
														MySettings settings;
														(settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + text4 + ",";
														MySettingsProperty.Settings.Save();
													}
												}
												finally
												{
													List<string>.Enumerator enumerator;
													((IDisposable)enumerator).Dispose();
												}
												MySettingsProperty.Settings.LibraryPath = MySettingsProperty.Settings.LibraryPath.TrimEnd(new char[] { ',' });
												MySettingsProperty.Settings.Save();
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
										this.NextASW.AddRange(new string[] { "Auto", "Off", "45", "45f", "18", "30", "Adaptive" });
										OTTDB.GetProfiles();
										this.ignoredApps = (List<string>)OTTDB.GetIgnoredApps();
										this.includedApps = (List<string>)OTTDB.GetIncludedApps();
										bool flag30 = this.ignoredApps.Count > 0;
										if (flag30)
										{
											Log.WriteToLog(Conversions.ToString(this.ignoredApps.Count) + " apps are being ignored");
										}
										bool useLocalDebugTool = MySettingsProperty.Settings.UseLocalDebugTool;
										if (useLocalDebugTool)
										{
											bool flag31 = File.Exists(Application.StartupPath + "\\OculusDebugToolCLI.exe");
											if (flag31)
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
										else
										{
											bool flag32 = File.Exists(this.OculusPath + "Support\\oculus-diagnostics\\OculusDebugToolCLI.exe");
											if (flag32)
											{
												RunCommand.debug_tool_path = this.OculusPath + "Support\\oculus-diagnostics\\OculusDebugToolCLI.exe";
												Log.WriteToLog("Using " + RunCommand.debug_tool_path);
											}
											else
											{
												RunCommand.debug_tool_path = Application.StartupPath + "\\OculusDebugToolCLI.exe";
												Log.WriteToLog("Using " + RunCommand.debug_tool_path);
											}
										}
										RunCommand.CloseDebugTool();
										bool dbg11 = Globals.dbg;
										if (dbg11)
										{
											Log.WriteToLog("Reading setting ASW");
										}
										bool flag33 = MySettingsProperty.Settings.ASW == 0;
										if (flag33)
										{
											FrmMain.fmain.ComboBox1.Text = "Auto";
										}
										bool flag34 = MySettingsProperty.Settings.ASW == 1;
										if (flag34)
										{
											FrmMain.fmain.ComboBox1.Text = "Off";
										}
										bool flag35 = MySettingsProperty.Settings.ASW == 2;
										if (flag35)
										{
											FrmMain.fmain.ComboBox1.Text = "45 Hz";
										}
										bool flag36 = MySettingsProperty.Settings.ASW == 3;
										if (flag36)
										{
											FrmMain.fmain.ComboBox1.Text = "30 Hz";
										}
										bool flag37 = MySettingsProperty.Settings.ASW == 4;
										if (flag37)
										{
											FrmMain.fmain.ComboBox1.Text = "18 Hz";
										}
										bool flag38 = MySettingsProperty.Settings.ASW == 5;
										if (flag38)
										{
											FrmMain.fmain.ComboBox1.Text = "45 Hz forced";
										}
										bool flag39 = MySettingsProperty.Settings.ASW == 6;
										if (flag39)
										{
											FrmMain.fmain.ComboBox1.Text = "Adaptive";
										}
										FrmMain.fmain.ComboVisualHUD.Text = "None";
										this.CheckStartWithWindows();
										PowerPlans.CheckPowerState(false);
										bool flag40 = !this.spoofid;
										if (flag40)
										{
											bool flag41 = MySettingsProperty.Settings.StartOVR & !this.OVRIsRunning;
											if (flag41)
											{
												bool oculusServiceFound = this.OculusServiceFound;
												if (oculusServiceFound)
												{
													this.StartOVR();
												}
											}
										}
										bool dbg12 = Globals.dbg;
										if (dbg12)
										{
											Log.WriteToLog("Reading setting SpoofCPU");
										}
										FrmMain.fmain.spoofid = MySettingsProperty.Settings.SpoofCPU;
										bool spoofCPU = MySettingsProperty.Settings.SpoofCPU;
										if (spoofCPU)
										{
											FrmMain.fmain.CheckSpoofCPU.Checked = true;
											MySettingsProperty.Settings.OldCPUID = "";
											FrmMain.fmain.GetCPUid();
										}
										else
										{
											FrmMain.fmain.CheckSpoofCPU.Checked = false;
										}
										bool flag42 = !MySettingsProperty.Settings.StartOVR & !MySettingsProperty.Settings.SpoofCPU;
										if (flag42)
										{
											this.CheckOculusService();
										}
										string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
										string text5 = Path.Combine(folderPath, "OTT");
										Directory.CreateDirectory(text5);
										Globals.steam = new Steam(text5);
										Globals.oculus = new Oculus(text5, Globals.steam);
										this.GetSteamPath();
										this.GetSteamVR();
										bool flag43 = Operators.CompareString(this.SteamPath, "", false) != 0;
										if (flag43)
										{
											this.vrManifestFileName = Path.Combine(this.SteamPath, "config\\steamapps.vrmanifest");
											bool flag44 = !File.Exists(this.vrManifestFileName);
											if (flag44)
											{
												Log.WriteToLog("Could not locate Steam VR manifest");
											}
											else
											{
												Log.WriteToLog("Found Steam VR manifest: " + this.vrManifestFileName);
												GetGames.GetSteamGames();
											}
										}
										bool oculusServiceFound2 = this.OculusServiceFound;
										if (oculusServiceFound2)
										{
											bool flag45 = Directory.Exists(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
											if (flag45)
											{
												GetGames.GetThirdPartyApps(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
											}
											bool flag46 = Directory.Exists(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
											if (flag46)
											{
												GetGames.GetFiles(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
											}
											bool flag47 = Directory.Exists(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Software\\Manifests");
											if (flag47)
											{
												GetGames.GetFiles(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Software\\Manifests");
											}
											bool flag48 = (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString());
											if (flag48)
											{
												foreach (string text6 in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
												{
													bool flag49 = Directory.Exists(text6.TrimEnd(new char[] { '\\' }) + "\\Manifests");
													if (flag49)
													{
														GetGames.GetFiles(text6.TrimEnd(new char[] { '\\' }) + "\\Manifests");
													}
													bool flag50 = Directory.Exists(text6.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
													if (flag50)
													{
														GetGames.GetThirdPartyApps(text6.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
													}
												}
											}
										}
										bool flag51 = OTTDB.numTimer > 0;
										if (flag51)
										{
											bool dbg13 = Globals.dbg;
											if (dbg13)
											{
												Log.WriteToLog("Creating EventHandler for Timer AppWatcher");
											}
											this.pTimer.Elapsed += this.OnTimerProfile;
											this.pTimer.Interval = 400.0;
											this.pTimer.Enabled = false;
											this.pTimer.AutoReset = true;
										}
										bool ovrisRunning = this.OVRIsRunning;
										if (ovrisRunning)
										{
											this.ComboVisualHUD.SelectedIndex = 0;
										}
										bool flag52 = this.OculusServiceFound & !MySettingsProperty.Settings.StartAppwatcherOnStart;
										if (flag52)
										{
											Log.WriteToLog("Oculus Home/SteamVR required, waiting for either to start");
											this.OculusHomeWatcher.Start();
										}
										bool flag53 = this.OculusServiceFound & MySettingsProperty.Settings.StartAppwatcherOnStart;
										if (flag53)
										{
											bool flag54 = OTTDB.numWMI > 0;
											if (flag54)
											{
												this.CreateWatcher();
											}
											bool flag55 = OTTDB.numTimer > 0;
											if (flag55)
											{
												Log.WriteToLog("Start Appwatcher On Start is True, starting Timer AppWatcher");
												this.pTimer.Start();
											}
										}
										bool ovrisRunning2 = this.OVRIsRunning;
										if (ovrisRunning2)
										{
											bool @checked = this.CheckLaunchHomeTool.Checked;
											if (@checked)
											{
												bool flag56 = File.Exists(this.OculusPath + "Support\\oculus-client\\OculusClient.exe");
												if (flag56)
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
										}
										bool automaticUpdateCheck = MySettingsProperty.Settings.AutomaticUpdateCheck;
										if (automaticUpdateCheck)
										{
											this.UpdateTimer.Start();
										}
										else
										{
											Log.WriteToLog("Automatic update checking is disabled");
											this.AddToListboxAndScroll("Automatic update checking is disabled");
										}
										bool dbg14 = Globals.dbg;
										if (dbg14)
										{
											this.PrintSettings(false);
										}
										bool startMinimized = MySettingsProperty.Settings.StartMinimized;
										if (startMinimized)
										{
											base.WindowState = FormWindowState.Minimized;
										}
										bool setRiftDefault = GetConfig.SetRiftDefault;
										if (setRiftDefault)
										{
											bool flag57 = MySettingsProperty.Settings.SetRiftAudioDefault == 1;
											if (flag57)
											{
												bool flag58 = MySettingsProperty.Settings.SetAudioOnStartGuid != null;
												if (flag58)
												{
													AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
												}
												bool flag59 = MySettingsProperty.Settings.SetAudioCommOnStartGuid != null;
												if (flag59)
												{
													AudioSwitcher.SetDefaultAudioCommDeviceOnStart();
												}
											}
											bool flag60 = MySettingsProperty.Settings.SetRiftMicDefault == 1;
											if (flag60)
											{
												bool flag61 = MySettingsProperty.Settings.SetMicOnStartGuid != null;
												if (flag61)
												{
													AudioSwitcher.SetDefaultMicDeviceOnStart();
												}
												bool flag62 = MySettingsProperty.Settings.SetMicCommOnStartGuid != null;
												if (flag62)
												{
													AudioSwitcher.SetDefaultMicCommDeviceOnStart();
												}
											}
										}
										else
										{
											bool useVoiceCommands = GetConfig.useVoiceCommands;
											if (useVoiceCommands)
											{
												this.EnableDisableVoice(true);
											}
										}
										bool flag63 = (MySettingsProperty.Settings.HomelessEnabled == 1) & MySettingsProperty.Settings.HomelessAutoPatch;
										if (flag63)
										{
											Log.WriteToLog("Oculus Homeless is installed, generating hash of 'Home2-Win64-Shipping.exe'");
											string text7 = Conversions.ToString(this.GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe"));
											string text8 = Conversions.ToString(this.GenerateSHA256Hash(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"));
											bool flag64 = Operators.CompareString(text8, text7, false) != 0;
											if (flag64)
											{
												Log.WriteToLog("'Home2-Win64-Shipping.exe' has been updated. Automatically re-applying Oculus Homeless");
												this.InstallHomeless();
											}
											else
											{
												Log.WriteToLog("'Home2-Win64-Shipping.exe' has not changed, Oculus Homeless is still enabled");
											}
										}
										try
										{
											bool flag65 = GetDevices.AudioDevCount > 0;
											if (flag65)
											{
												MMDeviceEnumerator mmdeviceEnumerator = new MMDeviceEnumerator();
												MMDevice defaultAudioEndpoint = mmdeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole);
												bool flag66 = defaultAudioEndpoint.FriendlyName.ToLower().Contains("rift");
												if (flag66)
												{
													this.ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
													bool flag67 = (Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, null, false) != 0) & (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, null, false) != 0);
													if (flag67)
													{
														this.ToolStripMenuItem3.Enabled = true;
													}
													else
													{
														this.ToolStripMenuItem3.Enabled = false;
														this.ToolStripMenuItem3.ToolTipText = "No fallback devices has been selected in the AudioSwitcher configuration";
													}
												}
												else
												{
													this.ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
												}
											}
											else
											{
												Log.WriteToLog("Could not get default audio endpoint, no enabled devices found!");
												this.AddToListboxAndScroll("WARNING: Could not get default audio endpoint, no enabled devices found!");
												this.hasWarning = true;
											}
										}
										catch (Exception ex2)
										{
											Log.WriteToLog("* Could not get default audio endpoint!");
											this.AddToListboxAndScroll("* Could not get default audio endpoint, no enabled devices found!");
											this.hasWarning = true;
										}
										bool restartServiceAfterSleep = MySettingsProperty.Settings.RestartServiceAfterSleep;
										if (restartServiceAfterSleep)
										{
											bool dbg15 = Globals.dbg;
											if (dbg15)
											{
												Log.WriteToLog("Adding eventhandler for PowerModeChanged");
											}
											SystemEvents.PowerModeChanged += this.PowerModeChanged;
										}
										bool sendHomeToTrayOnStart = MySettingsProperty.Settings.SendHomeToTrayOnStart;
										if (sendHomeToTrayOnStart)
										{
											this.StartMinimizeHomeWatcher();
										}
										OTTDB.GetLinkPresetNames();
										this.GetOculusLinkValues();
										this.CheckWarnings();
										this.AddToListboxAndScroll(Conversions.ToString(this.AllAppsList.Count) + " apps are being monitored");
										this.AddToListboxAndScroll(Conversions.ToString(this.ignoredApps.Count) + " apps are being ignored");
										this.AddToListboxAndScroll(Conversions.ToString(GetConfig.numprofiles) + " apps have profiles");
										Log.WriteToLog("Getting list of supported desktop resolutions");
										MyProject.Forms.frmProfiles.ComboResolution.Items.AddRange(Resolution.GetSupportedResolutions());
										GetConfig.IsReading = false;
										this.loadingDone = true;
										bool dbg16 = Globals.dbg;
										if (dbg16)
										{
											Log.WriteToLog("LoadingDone=" + this.loadingDone.ToString());
										}
										this.Cursor = Cursors.Default;
										bool dbg17 = Globals.dbg;
										if (dbg17)
										{
											Log.WriteToLog("Checking errors and warnings");
										}
										bool flag68 = this.hasError;
										if (flag68)
										{
											bool dbg18 = Globals.dbg;
											if (dbg18)
											{
												Log.WriteToLog("hasError=" + this.hasError.ToString());
											}
											MyProject.Forms.frmLoading.Label2.Text = "Not Ready (Error)";
											MyProject.Forms.frmLoading.Label2.Refresh();
											this.NotificationTimer.Interval = 1500;
											this.NotificationTimer.Start();
											Log.WriteToLog("Startup Complete");
										}
										else
										{
											bool flag69 = this.hasWarning;
											if (flag69)
											{
												bool dbg19 = Globals.dbg;
												if (dbg19)
												{
													Log.WriteToLog("hasWarning=" + this.hasWarning.ToString());
												}
												MyProject.Forms.frmLoading.Label2.Text = "Ready (Warnings)";
												MyProject.Forms.frmLoading.Label2.Refresh();
												this.NotificationTimer.Interval = 1500;
												this.NotificationTimer.Start();
												Log.WriteToLog("Startup Complete");
											}
											else
											{
												bool flag70 = !this.hasError & !this.hasWarning;
												if (flag70)
												{
													bool dbg20 = Globals.dbg;
													if (dbg20)
													{
														Log.WriteToLog("No warnings or errors");
													}
													MyProject.Forms.frmLoading.Label2.Text = "Ready";
													MyProject.Forms.frmLoading.Label2.Refresh();
													this.NotificationTimer.Interval = 1000;
													this.NotificationTimer.Start();
													Log.WriteToLog("Startup Complete");
												}
											}
										}
										this.NotifyIcon1.Visible = true;
										this.StartingUp = false;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex3)
			{
				this.AddToListboxAndScroll("Exception on Startup: " + ex3.Message);
				StackTrace stackTrace = new StackTrace(ex3, true);
				Log.WriteToLog(ex3.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00031288 File Offset: 0x0002F488
		private void StartMinimizeHomeWatcher()
		{
			try
			{
				this.MinimizeHomeWatcher.Stop();
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Starting Watcher for 'Minimize Home on Start'");
				}
				string text = "SELECT TargetInstance FROM __InstanceCreationEvent WITHIN  1.0 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name like 'OculusClient.exe'";
				string text2 = "\\\\.\\root\\CIMV2";
				this.MinimizeHomeWatcher = new ManagementEventWatcher(text2, text);
				this.MinimizeHomeWatcher.Start();
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Watcher for 'Minimize Home on Start' started");
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("StartMinimizeHomeWatcher(): " + ex.Message);
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0003132C File Offset: 0x0002F52C
		private void MinimizeHomeWatcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			this.MinimizeHomeWatcher_EventArrived_Delegate(0);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00031338 File Offset: 0x0002F538
		private void MinimizeHomeWatcher_EventArrived_Delegate(int tries)
		{
			checked
			{
				try
				{
					this.MinimizeHomeWatcher.Stop();
					bool flag = !HomeToTray.HomeIsMinimized;
					if (flag)
					{
						bool flag2 = tries >= 3;
						if (flag2)
						{
							Log.WriteToLog(Conversions.ToString(tries) + " attempts for sending Home to tray, giving up");
							tries = 0;
						}
						else
						{
							bool dbg = Globals.dbg;
							if (dbg)
							{
								Log.WriteToLog("'Minimize Home on Start' event arrived");
							}
							Process[] processesByName = Process.GetProcessesByName("OculusClient");
							bool flag3 = processesByName.Count<Process>() >= 3;
							if (flag3)
							{
								Log.WriteToLog("Oculus Home seems to have started up fully. Sleeping " + MySettingsProperty.Settings.SleepAfterHomeStart + "ms before attempting to minimize to tray");
								Thread.Sleep(Conversions.ToInteger(MySettingsProperty.Settings.SleepAfterHomeStart));
								HomeToTray.SendHomeToTrayOnStart();
								bool homeIsMinimized = HomeToTray.HomeIsMinimized;
								if (homeIsMinimized)
								{
									this.EnableShowHomeMenu();
									bool flag4 = MySettingsProperty.Settings.ShowHomeToast & !HomeToTray.ToastShown;
									if (flag4)
									{
										HomeToTray.ToastShown = true;
										Thread thread = new Thread((FrmMain._Closure$__.$I95-0 == null) ? (FrmMain._Closure$__.$I95-0 = delegate
										{
											MyProject.Forms.frmHomeTrayToast.ShowDialog();
										}) : FrmMain._Closure$__.$I95-0);
										thread.Start();
									}
									this.MinimizeHomeWatcher.Start();
								}
							}
							else
							{
								Log.WriteToLog("Oculus Home Not fully running, sleeping 500ms And retrying");
								Thread.Sleep(500);
								tries++;
								this.MinimizeHomeWatcher_EventArrived_Delegate(tries);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("MinimizeHomeWatcher_EventArrived() :  " + ex.Message);
				}
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000314E0 File Offset: 0x0002F6E0
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			MySettingsProperty.Settings.WindowLocation = base.Location;
			MySettingsProperty.Settings.GuiSize = base.Size;
			MySettingsProperty.Settings.Save();
			bool flag = e.CloseReason == CloseReason.WindowsShutDown;
			if (flag)
			{
				Log.WriteToLog("Windows shutdown detected, performing quick cleanup");
				bool flag2 = OTTDB.ott_cnn.State == ConnectionState.Open;
				if (flag2)
				{
					OTTDB.ott_cnn.Close();
				}
				bool flag3 = Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", false) != 0;
				if (flag3)
				{
					bool flag4 = MySettingsProperty.Settings.ApplyPowerPlan == 0;
					if (flag4)
					{
						PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanExit);
						PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
					}
				}
				bool setRiftDefault = GetConfig.SetRiftDefault;
				if (setRiftDefault)
				{
					bool flag5 = MySettingsProperty.Settings.SetRiftAudioDefault == 1;
					if (flag5)
					{
						AudioSwitcher.SetFallbackAudioDevice();
						AudioSwitcher.SetFallbackCommAudioDevice();
					}
					bool flag6 = MySettingsProperty.Settings.SetRiftMicDefault == 1;
					if (flag6)
					{
						AudioSwitcher.SetFallbackMicDevice();
						AudioSwitcher.SetFallbackCommMicDevice();
					}
				}
				Log.WriteToLog("bye bye");
				base.Dispose();
			}
			bool flag7 = e.CloseReason == CloseReason.UserClosing;
			if (flag7)
			{
				bool flag8 = !MySettingsProperty.Settings.CloseOnX;
				if (flag8)
				{
					e.Cancel = true;
					bool showStillRunning = MySettingsProperty.Settings.ShowStillRunning;
					if (showStillRunning)
					{
						MyProject.Forms.frmStillRunningToast.Show();
					}
					base.WindowState = FormWindowState.Minimized;
				}
				else
				{
					bool flag9 = Interaction.MsgBox("Oculus Tray Tool needs to be running to work its magic!\r\n\r\nAre you sure you want to exit?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm Exit") == MsgBoxResult.No;
					if (flag9)
					{
						e.Cancel = true;
					}
					else
					{
						this.Shutdown();
					}
				}
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00031688 File Offset: 0x0002F888
		public void Shutdown()
		{
			try
			{
				base.Hide();
				Log.WriteToLog("Closing down...");
				MyProject.Forms.frmProfiles.Close();
				MyProject.Forms.frmLibrary.Close();
				try
				{
					bool flag = CheckUpdate.frmToast != null;
					if (flag)
					{
						CheckUpdate.frmToast.BeginInvoke((FrmMain._Closure$__.$I97-0 == null) ? (FrmMain._Closure$__.$I97-0 = delegate
						{
							CheckUpdate.frmToast.Close();
						}) : FrmMain._Closure$__.$I97-0);
					}
				}
				catch (Exception ex)
				{
				}
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Removing eventhandler for PowerModeChanged");
				}
				SystemEvents.PowerModeChanged -= this.PowerModeChanged;
				Log.WriteToLog("StopOVR is " + MySettingsProperty.Settings.StopOVR.ToString());
				bool stopOVR = MySettingsProperty.Settings.StopOVR;
				if (stopOVR)
				{
					Log.WriteToLog("Calling on service to stop");
					this.StopOVR();
				}
				else
				{
					bool closeHomeOnExit = MySettingsProperty.Settings.CloseHomeOnExit;
					if (closeHomeOnExit)
					{
						this.CloseClient();
					}
				}
				bool flag2 = Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", false) != 0;
				if (flag2)
				{
					bool flag3 = MySettingsProperty.Settings.ApplyPowerPlan == 0;
					if (flag3)
					{
						PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanExit);
						PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
					}
				}
				bool setRiftDefault = GetConfig.SetRiftDefault;
				if (setRiftDefault)
				{
					bool flag4 = MySettingsProperty.Settings.SetRiftAudioDefault == 1;
					if (flag4)
					{
						AudioSwitcher.SetFallbackAudioDevice();
						AudioSwitcher.SetFallbackCommAudioDevice();
					}
					bool flag5 = MySettingsProperty.Settings.SetRiftMicDefault == 1;
					if (flag5)
					{
						AudioSwitcher.SetFallbackMicDevice();
						AudioSwitcher.SetFallbackCommMicDevice();
					}
				}
				this.Watcher.Stop();
				this.OculusHomeWatcher.Stop();
				this.MinimizeHomeWatcher.Stop();
				this.pTimer.Stop();
				this.HometoTrayTimer.Stop();
				this.NotificationTimer.Stop();
				this.UpdateTimer.Stop();
				this._Home2Timer.Stop();
				this.mirrorTimer.Stop();
				bool homeIsRunning = this.HomeIsRunning;
				if (homeIsRunning)
				{
					HomeToTray.ShowHomeNormal();
				}
				MyProject.Forms.frmHotKeys.Close();
				bool flag6 = this.spoofid;
				if (flag6)
				{
					this.RestoreCPUID();
				}
				RunCommand.CloseDebugTool();
				bool flag7 = OTTDB.ott_cnn.State == ConnectionState.Open;
				if (flag7)
				{
					OTTDB.ott_cnn.Close();
				}
				bool flag8 = MyProject.Forms.frmLibrary.Steamcnn.State == ConnectionState.Open;
				if (flag8)
				{
					MyProject.Forms.frmLibrary.Steamcnn.Close();
				}
				bool flag9 = File.Exists(Application.StartupPath + "\\ppdp.txt");
				if (flag9)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Deleting temporary file ppdp.txt");
					}
					File.Delete(Application.StartupPath + "\\ppdp.txt");
				}
				bool flag10 = File.Exists(Application.StartupPath + "\\perf.txt");
				if (flag10)
				{
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog("Deleting temporary file perf.txt");
					}
					File.Delete(Application.StartupPath + "\\perf.txt");
				}
				bool flag11 = File.Exists(Application.StartupPath + "\\asw.txt");
				if (flag11)
				{
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog("Deleting temporary file asw.txt");
					}
					File.Delete(Application.StartupPath + "\\asw.txt");
				}
				bool flag12 = File.Exists(Application.StartupPath + "\\fov.txt");
				if (flag12)
				{
					bool dbg5 = Globals.dbg;
					if (dbg5)
					{
						Log.WriteToLog("Deleting temporary file fov.txt");
					}
					File.Delete(Application.StartupPath + "\\fov.txt");
				}
				bool flag13 = File.Exists(Application.StartupPath + "\\usb.txt");
				if (flag13)
				{
					bool dbg6 = Globals.dbg;
					if (dbg6)
					{
						Log.WriteToLog("Deleting temporary file usb.txt");
					}
					File.Delete(Application.StartupPath + "\\usb.txt");
				}
				bool flag14 = File.Exists(Application.StartupPath + "\\data.sqlite");
				if (flag14)
				{
					try
					{
						File.Delete(Application.StartupPath + "\\data.sqlite");
						bool dbg7 = Globals.dbg;
						if (dbg7)
						{
							Log.WriteToLog("Database copy deleted");
						}
					}
					catch (Exception ex2)
					{
					}
				}
				bool resChanged = Resolution.ResChanged;
				if (resChanged)
				{
					this.AddToListboxAndScroll("Resetting Desktop resolution");
					Log.WriteToLog("Resetting Desktop resolution");
					Resolution.RestoreDisplaySettings();
				}
				this.NotifyIcon1.Visible = false;
				this.NotifyIcon1.Dispose();
				this.NotifyIcon3.Visible = false;
				this.NotifyIcon3.Dispose();
				Log.WriteToLog("bye bye");
				bool flag15 = this.restartInDBG;
				if (flag15)
				{
					Log.WriteToLog("Restarting application...");
					this.NotifyIcon1.Visible = false;
					this.NotifyIcon1.Dispose();
					Application.Restart();
				}
				else
				{
					Environment.Exit(0);
				}
			}
			catch (Exception ex3)
			{
				Log.WriteToLog(ex3.Message);
				this.NotifyIcon1.Visible = false;
				this.NotifyIcon1.Dispose();
				Environment.Exit(0);
			}
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00031C34 File Offset: 0x0002FE34
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void CloseClient()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering CloseClient");
			}
			try
			{
				bool setRiftDefault = GetConfig.SetRiftDefault;
				if (setRiftDefault)
				{
					bool flag = MySettingsProperty.Settings.SetRiftAudioDefault == 0;
					if (flag)
					{
						AudioSwitcher.SetFallbackAudioDevice();
						AudioSwitcher.SetFallbackCommAudioDevice();
					}
					bool flag2 = MySettingsProperty.Settings.SetRiftMicDefault == 0;
					if (flag2)
					{
						AudioSwitcher.SetFallbackMicDevice();
						AudioSwitcher.SetFallbackCommMicDevice();
					}
				}
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				bool flag3 = processesByName.Length > 0;
				if (flag3)
				{
					Log.WriteToLog("Closing Oculus Home");
					foreach (Process process in processesByName)
					{
						process.Kill();
						process.WaitForExit();
					}
				}
				Process[] processesByName2 = Process.GetProcessesByName("oculus-platform-runtime");
				bool flag4 = processesByName2.Length > 0;
				if (flag4)
				{
					processesByName2[0].Kill();
				}
				this.HomeIsRunning = false;
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting CloseClient");
				}
			}
			catch (Exception ex)
			{
				ProjectData.EndApp();
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00031D68 File Offset: 0x0002FF68
		private void GetSteamPath()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetSteamPath");
			}
			try
			{
				bool flag = MyProject.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam") != null;
				if (flag)
				{
					this.SteamPath = MyProject.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam", false).GetValue("SteamPath").ToString()
						.Replace("/", "\\");
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Steam Path: " + this.SteamPath);
					}
				}
				else
				{
					this.SteamPath = "";
					this.AddToListboxAndScroll("Steam path not found");
					Log.WriteToLog("Steam path not found");
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Exiting GetSteamPath");
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Exception: Could not get Steam installation path: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("GetSteamPath: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00031EB0 File Offset: 0x000300B0
		public void GetSteamVR()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetSteamVR");
			}
			try
			{
				bool flag = Operators.CompareString(this.SteamPath, "", false) != 0;
				if (flag)
				{
					string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\openvr\\openvrpaths.vrpath";
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Looking for " + text);
					}
					bool flag2 = File.Exists(text);
					if (flag2)
					{
						bool dbg3 = Globals.dbg;
						if (dbg3)
						{
							Log.WriteToLog(text + " found, getting SteamVR path");
						}
						string text2 = File.ReadAllText(text);
						JObject jobject = JObject.Parse(text2);
						string text3 = jobject.SelectToken("runtime").ToString().Replace("[", "")
							.Replace("]", "")
							.Replace("\\\\", "\\")
							.Replace("\"", "")
							.Trim();
						bool flag3 = text3.Contains(",");
						if (flag3)
						{
							string[] array = Strings.Split(text3, ",", -1, CompareMethod.Binary);
							this.steamvr = array[0].Trim();
						}
						else
						{
							this.steamvr = text3.Trim();
						}
						bool flag4 = !this.steamvr.EndsWith("\\");
						if (flag4)
						{
							ref string ptr = ref this.steamvr;
							this.steamvr = ptr + "\\";
						}
						MyProject.Forms.frmLibrary.AddSteamVRToolStripMenuItem.Enabled = true;
						bool dbg4 = Globals.dbg;
						if (dbg4)
						{
							Log.WriteToLog("SteamVR path: " + this.steamvr);
						}
					}
					else
					{
						MyProject.Forms.frmLibrary.AddSteamVRToolStripMenuItem.Enabled = false;
						Log.WriteToLog(text + " was not found, could not get SteamVR path");
						this.AddToListboxAndScroll("Could not get SteamVR path");
					}
				}
				bool dbg5 = Globals.dbg;
				if (dbg5)
				{
					Log.WriteToLog("Exiting GetSteamVR");
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Exception: Could not get SteamVR path: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("GetSteamVR: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0003211C File Offset: 0x0003031C
		public void PrintSettings(bool migrate)
		{
			Log.WriteToLog("## Current Settings ##");
			List<string> list = new List<string>();
			try
			{
				foreach (object obj in MySettingsProperty.Settings.PropertyValues)
				{
					SettingsPropertyValue settingsPropertyValue = (SettingsPropertyValue)obj;
					list.Add(settingsPropertyValue.Name + " = " + settingsPropertyValue.PropertyValue.ToString());
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			list.Sort();
			try
			{
				foreach (string text in list)
				{
					bool flag = !migrate;
					if (flag)
					{
						Log.WriteToLog(text.Replace("{", "[").Replace("}", "]"));
					}
					else
					{
						Log.WriteToMigrateLog(text);
					}
				}
			}
			finally
			{
				List<string>.Enumerator enumerator2;
				((IDisposable)enumerator2).Dispose();
			}
			Log.WriteToLog("## End Settings ##");
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0003223C File Offset: 0x0003043C
		public void Recheck()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering Recheck");
			}
			this.hasWarning = false;
			this.ListBox1.Items.Clear();
			PowerPlans.CheckPowerState(false);
			this.CheckWarnings();
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Exiting Recheck");
			}
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00032298 File Offset: 0x00030498
		public void CheckWarnings()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering CheckWarnings");
			}
			bool flag = this.hasError;
			checked
			{
				if (flag)
				{
					this.DotNetBarTabcontrol1.TabPages[4].Text = "Log (Error)";
					this.ListBox1.TopIndex = this.ListBox1.Items.Count - 1;
					this.ListBox1.Refresh();
				}
				else
				{
					bool flag2 = this.hasWarning;
					if (flag2)
					{
						this.DotNetBarTabcontrol1.TabPages[4].Text = "Log (Warning)";
						this.ListBox1.TopIndex = this.ListBox1.Items.Count - 1;
						this.ListBox1.Refresh();
					}
					else
					{
						bool flag3 = !this.hasError & !this.hasWarning;
						if (!flag3)
						{
							bool dbg2 = Globals.dbg;
							if (dbg2)
							{
								Log.WriteToLog("Exiting CheckWarnings");
							}
						}
					}
				}
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00032394 File Offset: 0x00030594
		public void LoadVoiceSettings()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering LoadVoiceSettings");
			}
			bool flag = Operators.CompareString(MySettingsProperty.Settings.StartVoice, "", false) == 0;
			if (flag)
			{
				MySettingsProperty.Settings.StartVoice = "computer, start listening;speech on";
				MySettingsProperty.Settings.StartVoiceEnabled = true;
			}
			bool flag2 = Operators.CompareString(MySettingsProperty.Settings.StopVoice, "", false) == 0;
			if (flag2)
			{
				MySettingsProperty.Settings.StopVoice = "computer, stop listening;speech off";
				MySettingsProperty.Settings.StopVoiceEnabled = true;
			}
			bool flag3 = Operators.CompareString(MySettingsProperty.Settings.EnableASW, "", false) == 0;
			if (flag3)
			{
				MySettingsProperty.Settings.EnableASW = "enable spacewarp";
				MySettingsProperty.Settings.EnableASWEnabled = true;
			}
			bool flag4 = Operators.CompareString(MySettingsProperty.Settings.DisableASW, "", false) == 0;
			if (flag4)
			{
				MySettingsProperty.Settings.DisableASW = "disable spacewarp";
				MySettingsProperty.Settings.DisableASWEnabled = true;
			}
			bool flag5 = Operators.CompareString(MySettingsProperty.Settings.ShowPD, "", false) == 0;
			if (flag5)
			{
				MySettingsProperty.Settings.ShowPD = "show pixel density; show super sampling";
				MySettingsProperty.Settings.ShowPDEnabled = true;
			}
			bool flag6 = Operators.CompareString(MySettingsProperty.Settings.ShowPerf, "", false) == 0;
			if (flag6)
			{
				MySettingsProperty.Settings.ShowPerf = "show performance";
				MySettingsProperty.Settings.ShowPerfEnabled = true;
			}
			bool flag7 = Operators.CompareString(MySettingsProperty.Settings.Close, "", false) == 0;
			if (flag7)
			{
				MySettingsProperty.Settings.Close = "close overlay";
				MySettingsProperty.Settings.CloseEnabled = true;
			}
			bool flag8 = Operators.CompareString(MySettingsProperty.Settings.SetPD, "", false) == 0;
			if (flag8)
			{
				MySettingsProperty.Settings.SetPD = "set pixel density;set super sampling";
				MySettingsProperty.Settings.SetPDEnabled = true;
			}
			bool flag9 = Operators.CompareString(MySettingsProperty.Settings.ShowASW, "", false) == 0;
			if (flag9)
			{
				MySettingsProperty.Settings.ShowASW = "show spacewarp";
				MySettingsProperty.Settings.ShowASWEnabled = true;
			}
			bool flag10 = Operators.CompareString(MySettingsProperty.Settings.LockASWOn, "", false) == 0;
			if (flag10)
			{
				MySettingsProperty.Settings.LockASWOn = "lock framerate";
				MySettingsProperty.Settings.LockASWOnEnabled = true;
			}
			bool flag11 = Operators.CompareString(MySettingsProperty.Settings.ShowLatency, "", false) == 0;
			if (flag11)
			{
				MySettingsProperty.Settings.ShowLatency = "show latency timing";
				MySettingsProperty.Settings.ShowLatencyEnabled = true;
			}
			bool flag12 = Operators.CompareString(MySettingsProperty.Settings.ShowApplicationRender, "", false) == 0;
			if (flag12)
			{
				MySettingsProperty.Settings.ShowApplicationRender = "show application timing";
				MySettingsProperty.Settings.ShowApplicationRenderEnabled = true;
			}
			bool flag13 = Operators.CompareString(MySettingsProperty.Settings.ShowCompositorRender, "", false) == 0;
			if (flag13)
			{
				MySettingsProperty.Settings.ShowCompositorRender = "show compositor timing";
				MySettingsProperty.Settings.ShowCompositorRenderEnabled = true;
			}
			bool flag14 = Operators.CompareString(MySettingsProperty.Settings.ShowVersion, "", false) == 0;
			if (flag14)
			{
				MySettingsProperty.Settings.ShowVersion = "show version";
				MySettingsProperty.Settings.ShowVersionEnabled = true;
			}
			bool flag15 = Operators.CompareString(MySettingsProperty.Settings.LaunchSteam, "", false) == 0;
			if (flag15)
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
			this.voiceSettingsLoaded = true;
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Exiting LoadVoiceSettings");
			}
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00032CB0 File Offset: 0x00030EB0
		private bool IsInRange(double x, double a, double b)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering IsInRange");
			}
			return (x >= a) & (x <= b);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00032CF4 File Offset: 0x00030EF4
		private void CheckStartWithWindows()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering CheckStartWithWindows");
			}
			try
			{
				bool startWithWindows = MySettingsProperty.Settings.StartWithWindows;
				if (startWithWindows)
				{
					this.CheckStartWindows.Checked = true;
				}
				else
				{
					this.CheckStartWindows.Checked = false;
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting CheckStartWithWindows");
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Start with Windows: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("CheckStartWithWindows: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00032DC0 File Offset: 0x00030FC0
		private void CheckStartWindows_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool flag2 = this.isElevated;
					if (flag2)
					{
						bool @checked = this.CheckStartWindows.Checked;
						if (@checked)
						{
							MyProject.Forms.frmStartupType.ShowDialog();
						}
						else
						{
							CreateTask.GetAndDeleteTask("Oculus Tray Tool");
							bool flag3 = Operators.ConditionalCompareObjectNotEqual(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue(Application.ProductName), null, false);
							if (flag3)
							{
								MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue(Application.ProductName);
							}
							MySettingsProperty.Settings.StartWithWindows = false;
							MySettingsProperty.Settings.Save();
							Log.WriteToLog("Disabled 'Start with Windows'");
						}
					}
					else
					{
						GetConfig.IsReading = true;
						this.CheckStartWindows.Checked = false;
						GetConfig.IsReading = false;
						Interaction.MsgBox("You must run the application as Administrator to change this option.", MsgBoxStyle.Critical, "Oculus Tray Tool");
					}
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Start with Windows: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00032F2C File Offset: 0x0003112C
		public void CheckOculusService()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering CheckOculusService");
			}
			try
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				ServiceController serviceController = new ServiceController("OVRService");
				bool flag = serviceController.Status == ServiceControllerStatus.Stopped;
				if (flag)
				{
					this.ovrDown = true;
					this.LabelServiceStatus.ForeColor = Color.Red;
					this.LabelServiceStatus.Text = "Down";
					this.ButtonStartOVR.Enabled = true;
					this.ButtonStopOVR.Enabled = false;
					this.ButtonRestartOVR.Enabled = false;
					this.ToolStripStartOVR.Enabled = true;
					this.ToolStripStopOVR.Enabled = false;
					this.ToolStripRestartOVR.Enabled = false;
					Log.WriteToLog("OVR Service is DOWN");
					this.AddToListboxAndScroll("OVR Service is down, some options disabled");
					this.OVRIsRunning = false;
					this.ComboVisualHUD.Text = "None";
					this.ComboVisualHUD.Enabled = false;
					this.ComboBox1.Enabled = false;
					this.HotKeysCheckBox.Enabled = false;
					GetConfig.UseHotKeys = false;
					this.kbHook = null;
					bool flag2 = !this.CheckStartService.Checked & !this.spoofid;
					if (flag2)
					{
						this.hasWarning = true;
						Log.WriteToLog("Warning: OVR Service is DOWN, not managed by Oculus Tray Tool");
					}
				}
				bool flag3 = serviceController.Status == ServiceControllerStatus.Running;
				if (flag3)
				{
					Log.WriteToLog("OVR Service is UP");
					this.AddToListboxAndScroll("OVR Service is UP");
					this.LabelServiceStatus.ForeColor = Color.Green;
					this.LabelServiceStatus.Text = "Up";
					this.ButtonStartOVR.Enabled = false;
					this.ButtonStopOVR.Enabled = true;
					this.ButtonRestartOVR.Enabled = true;
					this.ToolStripStartOVR.Enabled = false;
					this.ToolStripStopOVR.Enabled = true;
					this.ToolStripRestartOVR.Enabled = true;
					bool flag4 = (Operators.CompareString(GetConfig.ppdpstartup, "", false) != 0) & (Operators.CompareString(GetConfig.ppdpstartup, "0", false) != 0);
					if (flag4)
					{
						Thread thread = new Thread((FrmMain._Closure$__.$I108-0 == null) ? (FrmMain._Closure$__.$I108-0 = delegate
						{
							RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
						}) : FrmMain._Closure$__.$I108-0);
						thread.Start();
					}
					this.ComboOVRPrio.Text = MySettingsProperty.Settings.OVRSrvPrio;
					bool flag5 = Operators.CompareString(MySettingsProperty.Settings.OVRSrvPrio, "Normal", false) != 0;
					if (flag5)
					{
						this.ChangeCPUPrioOVR(MySettingsProperty.Settings.OVRSrvPrio);
					}
					bool flag6 = MySettingsProperty.Settings.ASW == 0;
					if (flag6)
					{
						Thread thread2 = new Thread((FrmMain._Closure$__.$I108-1 == null) ? (FrmMain._Closure$__.$I108-1 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Auto");
						}) : FrmMain._Closure$__.$I108-1);
						thread2.Start();
						this.AddToListboxAndScroll("ASW set to Auto");
						this.ComboBox1.Text = "Auto";
					}
					bool flag7 = MySettingsProperty.Settings.ASW == 1;
					if (flag7)
					{
						Thread thread3 = new Thread((FrmMain._Closure$__.$I108-2 == null) ? (FrmMain._Closure$__.$I108-2 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Off");
						}) : FrmMain._Closure$__.$I108-2);
						thread3.Start();
						this.AddToListboxAndScroll("ASW set to Off");
						this.ComboBox1.Text = "Off";
					}
					bool flag8 = MySettingsProperty.Settings.ASW == 2;
					if (flag8)
					{
						Thread thread4 = new Thread((FrmMain._Closure$__.$I108-3 == null) ? (FrmMain._Closure$__.$I108-3 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock45");
						}) : FrmMain._Closure$__.$I108-3);
						thread4.Start();
						this.AddToListboxAndScroll("Framerate @ 45 Hz");
						this.ComboBox1.Text = "45 Hz";
					}
					bool flag9 = MySettingsProperty.Settings.ASW == 3;
					if (flag9)
					{
						Thread thread5 = new Thread((FrmMain._Closure$__.$I108-4 == null) ? (FrmMain._Closure$__.$I108-4 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock30");
						}) : FrmMain._Closure$__.$I108-4);
						thread5.Start();
						this.AddToListboxAndScroll("Framerate @ 30 Hz");
						this.ComboBox1.Text = "30 Hz";
					}
					bool flag10 = MySettingsProperty.Settings.ASW == 4;
					if (flag10)
					{
						Thread thread6 = new Thread((FrmMain._Closure$__.$I108-5 == null) ? (FrmMain._Closure$__.$I108-5 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock18");
						}) : FrmMain._Closure$__.$I108-5);
						thread6.Start();
						this.AddToListboxAndScroll("Framerate @ 18 Hz");
						this.ComboBox1.Text = "18 Hz";
					}
					bool flag11 = MySettingsProperty.Settings.ASW == 5;
					if (flag11)
					{
						Thread thread7 = new Thread((FrmMain._Closure$__.$I108-6 == null) ? (FrmMain._Closure$__.$I108-6 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Sim45");
						}) : FrmMain._Closure$__.$I108-6);
						thread7.Start();
						this.AddToListboxAndScroll("Framerate forced to 45 Hz");
						this.ComboBox1.Text = "45 Hz forced";
					}
					bool flag12 = MySettingsProperty.Settings.ASW == 6;
					if (flag12)
					{
						Thread thread8 = new Thread((FrmMain._Closure$__.$I108-7 == null) ? (FrmMain._Closure$__.$I108-7 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
						}) : FrmMain._Closure$__.$I108-7);
						thread8.Start();
						this.AddToListboxAndScroll("Framerate set to Adaptive");
						this.ComboBox1.Text = "Adaptive";
					}
					bool flag13 = (Conversions.ToDouble(MySettingsProperty.Settings.FOVh) != 0.0) & (Conversions.ToDouble(MySettingsProperty.Settings.FOVh) != 1.0) & (Conversions.ToDouble(MySettingsProperty.Settings.FOVv) != 0.0) & (Conversions.ToDouble(MySettingsProperty.Settings.FOVv) != 1.0);
					if (flag13)
					{
						Thread thread9 = new Thread((FrmMain._Closure$__.$I108-8 == null) ? (FrmMain._Closure$__.$I108-8 = delegate
						{
							RunCommand.Run_debug_tool_fov("service set-client-fov-tan-angle-multiplier " + MySettingsProperty.Settings.FOVh + " " + MySettingsProperty.Settings.FOVv);
						}) : FrmMain._Closure$__.$I108-8);
						thread9.Start();
						this.AddToListboxAndScroll("FOV set to " + MySettingsProperty.Settings.FOVh + "; " + MySettingsProperty.Settings.FOVv);
					}
					bool adaptiveGPUScaling = MySettingsProperty.Settings.AdaptiveGPUScaling;
					if (adaptiveGPUScaling)
					{
						Thread thread10 = new Thread((FrmMain._Closure$__.$I108-9 == null) ? (FrmMain._Closure$__.$I108-9 = delegate
						{
							RunCommand.Run_debug_tool_agps("true");
						}) : FrmMain._Closure$__.$I108-9);
						thread10.Start();
						this.AddToListboxAndScroll("Adaptive GPU Scaling Enabled");
					}
					bool flag14 = !MySettingsProperty.Settings.AdaptiveGPUScaling;
					if (flag14)
					{
						Thread thread11 = new Thread((FrmMain._Closure$__.$I108-10 == null) ? (FrmMain._Closure$__.$I108-10 = delegate
						{
							RunCommand.Run_debug_tool_agps("false");
						}) : FrmMain._Closure$__.$I108-10);
						thread11.Start();
						this.AddToListboxAndScroll("Adaptive GPU Scaling Disabled");
					}
					Thread thread12 = new Thread((FrmMain._Closure$__.$I108-11 == null) ? (FrmMain._Closure$__.$I108-11 = delegate
					{
						RunCommand.Run_debug_tool_force_mipmap(MySettingsProperty.Settings.ForceMipmap);
					}) : FrmMain._Closure$__.$I108-11);
					thread12.Start();
					Thread thread13 = new Thread((FrmMain._Closure$__.$I108-12 == null) ? (FrmMain._Closure$__.$I108-12 = delegate
					{
						RunCommand.Run_debug_tool_offset_mipmap(MySettingsProperty.Settings.OffsetMipmap);
					}) : FrmMain._Closure$__.$I108-12);
					thread13.Start();
					this.ComboVisualHUD.SelectedIndex = 0;
					this.OVRIsRunning = true;
					this.ComboVisualHUD.Enabled = true;
					this.ComboBox1.Enabled = true;
					this.HotKeysCheckBox.Enabled = true;
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting CheckOculusService");
				}
				Control.CheckForIllegalCrossThreadCalls = true;
			}
			catch (Exception ex)
			{
				this.LabelServiceStatus.ForeColor = Color.Red;
				this.LabelServiceStatus.Text = "N/A";
				this.ButtonStartOVR.Enabled = false;
				this.ButtonStopOVR.Enabled = false;
				this.ButtonRestartOVR.Enabled = false;
				this.ComboVisualHUD.Enabled = false;
				this.ComboBox1.Enabled = false;
				this.HotKeysCheckBox.Enabled = false;
				GetConfig.UseHotKeys = false;
				this.kbHook = null;
				this.OVRIsRunning = false;
				this.BtnLibrary.Enabled = false;
				this.OculusServiceFound = false;
				Log.WriteToLog("Could not get the Oculus Service");
				this.AddToListboxAndScroll("Could not get the Oculus Service");
				this.hasError = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				Control.CheckForIllegalCrossThreadCalls = true;
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x000337D8 File Offset: 0x000319D8
		public void StartOVR()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering StartOVR");
			}
			try
			{
				Application.DoEvents();
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Service Where Name=\"OVRService\"");
				try
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						string text = managementObject.GetPropertyValue("StartMode").ToString().Replace("\"", "");
						bool flag = Operators.CompareString(text, "Disabled", false) == 0;
						if (flag)
						{
							this.AddToListboxAndScroll("* Oculus Service Is set to Disabled, cannot continue");
							this.hasError = true;
							return;
						}
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator;
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				this.AddToListboxAndScroll("Starting OVR Service...");
				Log.WriteToLog("Starting OVR Service...");
				ServiceController serviceController = new ServiceController("OVRService");
				bool flag2 = serviceController.Status == ServiceControllerStatus.Stopped;
				if (flag2)
				{
					this.Cursor = Cursors.WaitCursor;
					serviceController.Start();
					serviceController.WaitForStatus(ServiceControllerStatus.Running);
					Log.WriteToLog("Sleeping for " + Conversions.ToString(MySettingsProperty.Settings.SleepAfterServiceStart) + "ms after service start");
					Thread.Sleep(MySettingsProperty.Settings.SleepAfterServiceStart);
					this.CheckOculusService();
					bool @checked = this.CheckLaunchHome.Checked;
					if (@checked)
					{
						bool flag3 = File.Exists(this.OculusPath + "Support\\oculus-client\\OculusClient.exe");
						if (flag3)
						{
							Log.WriteToLog("Sleeping 5s before starting Home");
							this.Hometimer.Interval = 5000;
							this.Hometimer.Tick += this.HomeTimerTick;
							this.Hometimer.Start();
						}
						else
						{
							Log.WriteToLog("Could Not locate OculusClient in " + this.OculusPath);
							this.AddToListboxAndScroll("Could Not locate OculusClient in " + this.OculusPath);
							this.hasWarning = true;
						}
					}
					this.Cursor = Cursors.Default;
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting StartOVR");
				}
			}
			catch (Exception ex)
			{
				this.LabelServiceStatus.ForeColor = Color.Red;
				this.LabelServiceStatus.Text = "N/A";
				this.ButtonStartOVR.Enabled = false;
				this.AddToListboxAndScroll("* Start OVR:  " + ex.Message);
				this.hasError = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00033AAC File Offset: 0x00031CAC
		private void HomeTimerTick(object sender, EventArgs e)
		{
			this.Hometimer.Stop();
			RunCommand.StartHome();
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00033AC4 File Offset: 0x00031CC4
		public void CloseHome()
		{
			Process[] processesByName = Process.GetProcessesByName("oculus-platform-runtime");
			bool flag = processesByName.Length > 0;
			if (flag)
			{
				Log.WriteToLog("Closing Oculus Home");
				processesByName[0].Kill();
			}
			Process[] processesByName2 = Process.GetProcessesByName("OVRServiceLauncher");
			bool flag2 = processesByName2.Length > 0;
			if (flag2)
			{
				Log.WriteToLog("Closing OVRServiceLauncher");
				processesByName2[0].Kill();
			}
			Process[] processesByName3 = Process.GetProcessesByName("OVRServer_x64");
			bool flag3 = processesByName3.Length > 0;
			if (flag3)
			{
				Log.WriteToLog("Closing OVRServer_x64");
				processesByName3[0].Kill();
			}
			Process[] processesByName4 = Process.GetProcessesByName("OVRRedir");
			bool flag4 = processesByName4.Length > 0;
			if (flag4)
			{
				Log.WriteToLog("Closing OVRRedir");
				processesByName4[0].Kill();
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00033B88 File Offset: 0x00031D88
		public void StopOVR()
		{
			Cursor.Current = Cursors.WaitCursor;
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering StopOVR");
			}
			bool homeIsRunning = this.HomeIsRunning;
			if (homeIsRunning)
			{
				this.CloseHome();
			}
			this.AddToListboxAndScroll("Stopping OVR Service...");
			Log.WriteToLog("Stopping OVR Service...");
			ServiceController serviceController = new ServiceController("OVRService");
			bool flag = serviceController.Status == ServiceControllerStatus.Running;
			if (flag)
			{
				serviceController.Stop();
				serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
			}
			this.CheckOculusService();
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Exiting StopOVR");
			}
			Cursor.Current = Cursors.Default;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00033C30 File Offset: 0x00031E30
		public void DisableFrescoPower()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering DisableFrescoPower");
			}
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\wmi", "SELECT * FROM MSPower_DeviceEnable");
				try
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						string text = NewLateBinding.LateGet(managementObject["InstanceName"], null, "TrimEnd", new object[] { "0" }, null, null, null).ToString().TrimEnd(new char[] { '_' })
							.ToUpper();
						bool flag = text.Contains("ROOT_HUB_FL30");
						if (flag)
						{
							bool flag2 = Operators.ConditionalCompareObjectEqual(managementObject.GetPropertyValue("Enable"), true, false);
							if (flag2)
							{
								managementObject.SetPropertyValue("Enable", false);
								managementObject.Put();
								Log.WriteToLog("Disabled Fresco Logic Power Management");
								this.AddToListboxAndScroll("Disabled Fresco Logic Power Management");
							}
						}
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator;
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting DisableFrescoPower");
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Disable Fresco Power Management: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("DisableFrescoPower: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00033DE8 File Offset: 0x00031FE8
		private void Form1_Resize(object sender, EventArgs e)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering Resize");
			}
			bool flag = base.WindowState == FormWindowState.Minimized;
			if (flag)
			{
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("WindowState=Minimized");
				}
				base.ShowInTaskbar = false;
				bool hideAltTab = GetConfig.hideAltTab;
				if (hideAltTab)
				{
					base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				}
			}
			bool flag2 = base.WindowState == FormWindowState.Normal;
			if (flag2)
			{
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("WindowState=Normal");
				}
				base.ShowInTaskbar = true;
				bool hideAltTab2 = GetConfig.hideAltTab;
				if (hideAltTab2)
				{
					base.FormBorderStyle = FormBorderStyle.FixedSingle;
				}
			}
			bool dbg4 = Globals.dbg;
			if (dbg4)
			{
				Log.WriteToLog("Exiting Resize");
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00033EA0 File Offset: 0x000320A0
		public void ShowForm()
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					base.ShowInTaskbar = true;
					bool hideAltTab = GetConfig.hideAltTab;
					if (hideAltTab)
					{
						base.FormBorderStyle = FormBorderStyle.FixedSingle;
					}
					base.WindowState = FormWindowState.Normal;
					bool flag2 = (base.Location.X < 0) | (base.Location.Y < 0);
					if (flag2)
					{
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog("GUI location has negative number, adjusting");
						}
						base.CenterToScreen();
						MySettingsProperty.Settings.WindowLocation = base.Location;
						MySettingsProperty.Settings.Save();
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ShowForm: " + ex.Message);
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00033F80 File Offset: 0x00032180
		private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			bool flag = base.WindowState == FormWindowState.Minimized;
			if (flag)
			{
				this.ShowForm();
			}
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00033FA4 File Offset: 0x000321A4
		private void ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			bool hideAltTab = GetConfig.hideAltTab;
			if (hideAltTab)
			{
				base.FormBorderStyle = FormBorderStyle.FixedSingle;
			}
			base.ShowInTaskbar = true;
			base.WindowState = FormWindowState.Normal;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00033FD4 File Offset: 0x000321D4
		private void CheckStartMin_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckStartMin.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00034088 File Offset: 0x00032288
		private void ButtonStartOVR_Click(object sender, EventArgs e)
		{
			this.StartOVR();
			bool @checked = this.CheckLaunchHome.Checked;
			if (@checked)
			{
				ServiceController serviceController = new ServiceController("OVRService");
				bool flag = serviceController.Status == ServiceControllerStatus.Running;
				if (flag)
				{
					RunCommand.StartHome();
				}
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000340D0 File Offset: 0x000322D0
		public void AppWork(object sender, DoWorkEventArgs e)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering AppWork");
			}
			try
			{
				Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(this.runningApp));
				bool flag = processesByName.Length > 0;
				if (flag)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Waiting for " + Path.GetFileNameWithoutExtension(this.runningApp) + " to exit");
					}
					processesByName[0].WaitForExit();
					Log.WriteToLog(this.runningapp_displayname + ": App has exited");
					this.AddToListboxAndScroll(this.runningapp_displayname + ": App has exited");
					this.pid = 0;
					this.ManualStart = false;
					this.runningApp = null;
					this.runningapp_displayname = "";
					this.Watcher.Start();
					bool flag2 = !this.NoProfileFound;
					if (flag2)
					{
						Thread thread = new Thread((FrmMain._Closure$__.$I120-0 == null) ? (FrmMain._Closure$__.$I120-0 = delegate
						{
							RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
						}) : FrmMain._Closure$__.$I120-0);
						thread.Start();
						bool enabled = this.mirrorTimer.Enabled;
						if (enabled)
						{
							this.mirrorTimer.Stop();
							bool dbg3 = Globals.dbg;
							if (dbg3)
							{
								Log.WriteToLog("Mirror Timer stopped");
							}
						}
						bool flag3 = MySettingsProperty.Settings.ASW == 0;
						if (flag3)
						{
							Thread thread2 = new Thread((FrmMain._Closure$__.$I120-1 == null) ? (FrmMain._Closure$__.$I120-1 = delegate
							{
								RunCommand.Run_debug_tool_asw("server:asw.Auto");
							}) : FrmMain._Closure$__.$I120-1);
							thread2.Start();
							this.AddToListboxAndScroll("ASW set to Auto");
						}
						bool flag4 = MySettingsProperty.Settings.ASW == 1;
						if (flag4)
						{
							Thread thread3 = new Thread((FrmMain._Closure$__.$I120-2 == null) ? (FrmMain._Closure$__.$I120-2 = delegate
							{
								RunCommand.Run_debug_tool_asw("server:asw.Off");
							}) : FrmMain._Closure$__.$I120-2);
							thread3.Start();
							this.AddToListboxAndScroll("ASW set to Off");
						}
						bool flag5 = MySettingsProperty.Settings.ASW == 2;
						if (flag5)
						{
							Thread thread4 = new Thread((FrmMain._Closure$__.$I120-3 == null) ? (FrmMain._Closure$__.$I120-3 = delegate
							{
								RunCommand.Run_debug_tool_asw("server:asw.Clock45");
							}) : FrmMain._Closure$__.$I120-3);
							thread4.Start();
							this.AddToListboxAndScroll("Framerate Locked @ 45 fps");
						}
						Thread thread5 = new Thread((FrmMain._Closure$__.$I120-4 == null) ? (FrmMain._Closure$__.$I120-4 = delegate
						{
							RunCommand.Run_debug_tool_force_mipmap(MySettingsProperty.Settings.ForceMipmap.ToString().ToLower());
						}) : FrmMain._Closure$__.$I120-4);
						thread5.Start();
						Thread thread6 = new Thread((FrmMain._Closure$__.$I120-5 == null) ? (FrmMain._Closure$__.$I120-5 = delegate
						{
							RunCommand.Run_debug_tool_offset_mipmap(MySettingsProperty.Settings.OffsetMipmap.ToString());
						}) : FrmMain._Closure$__.$I120-5);
						thread6.Start();
						Thread thread7 = new Thread((FrmMain._Closure$__.$I120-6 == null) ? (FrmMain._Closure$__.$I120-6 = delegate
						{
							RunCommand.Run_debug_tool_fov("service set-client-fov-tan-angle-multiplier " + MySettingsProperty.Settings.FOVh + " " + MySettingsProperty.Settings.FOVv);
						}) : FrmMain._Closure$__.$I120-6);
						thread7.Start();
						bool setRiftDefault = GetConfig.SetRiftDefault;
						if (setRiftDefault)
						{
							bool flag6 = MySettingsProperty.Settings.SetRiftAudioDefault == 2;
							if (flag6)
							{
								Thread thread8 = new Thread((FrmMain._Closure$__.$I120-7 == null) ? (FrmMain._Closure$__.$I120-7 = delegate
								{
									AudioSwitcher.SetFallbackAudioDevice();
									AudioSwitcher.SetFallbackCommAudioDevice();
								}) : FrmMain._Closure$__.$I120-7);
								thread8.Start();
							}
							bool flag7 = MySettingsProperty.Settings.SetRiftMicDefault == 2;
							if (flag7)
							{
								Thread thread9 = new Thread((FrmMain._Closure$__.$I120-8 == null) ? (FrmMain._Closure$__.$I120-8 = delegate
								{
									AudioSwitcher.SetFallbackMicDevice();
									AudioSwitcher.SetFallbackCommMicDevice();
								}) : FrmMain._Closure$__.$I120-8);
								thread9.Start();
							}
						}
						bool resChanged = Resolution.ResChanged;
						if (resChanged)
						{
							this.AddToListboxAndScroll("Resetting Desktop resolution");
							Log.WriteToLog("Resetting Desktop resolution");
							Resolution.RestoreDisplaySettings();
						}
						bool flag8 = OTTDB.numWMI > 0;
						if (flag8)
						{
							this.CreateWatcher();
						}
						bool flag9 = OTTDB.numTimer > 0;
						if (flag9)
						{
							Log.WriteToLog("Starting Timer AppWatcher");
							this.pTimer.Start();
						}
					}
					else
					{
						this.NoProfileFound = false;
					}
				}
				else
				{
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog("AppWork: " + Path.GetFileNameWithoutExtension(this.runningApp) + " was not fund");
					}
				}
				this.AppWatchWorker.DoWork -= this.AppWork;
				bool dbg5 = Globals.dbg;
				if (dbg5)
				{
					Log.WriteToLog("Exiting AppWork");
				}
			}
			catch (Exception ex)
			{
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("AppWork: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00034578 File Offset: 0x00032778
		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Shutdown();
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00034582 File Offset: 0x00032782
		private void ButtonStopOVR_Click(object sender, EventArgs e)
		{
			this.StopOVR();
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0003458C File Offset: 0x0003278C
		private void ButtonRestartOVR_Click(object sender, EventArgs e)
		{
			this.StopOVR();
			this.Cursor = Cursors.WaitCursor;
			this.LabelServiceStatus.Refresh();
			this.AddToListboxAndScroll("Waiting 4s until start of the OVR service to ensure proper tracking");
			Thread.Sleep(4000);
			this.StartOVR();
			this.LabelServiceStatus.Refresh();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x000345F0 File Offset: 0x000327F0
		private void CheckStartService_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckStartService.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x000346A4 File Offset: 0x000328A4
		private void CheckStopService_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckStopService.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00034758 File Offset: 0x00032958
		private void CheckLaunchHome_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckLaunchHome.Checked;
					if (@checked)
					{
						MySettingsProperty.Settings.StartHomeOnServiceStart = true;
						this.CheckLaunchHomeTool.Checked = false;
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00034818 File Offset: 0x00032A18
		private void CheckLaunchHomeTool_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckLaunchHomeTool.Checked;
					if (@checked)
					{
						MySettingsProperty.Settings.StartHomeOnToolStart = true;
						this.CheckLaunchHome.Checked = false;
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x000348D8 File Offset: 0x00032AD8
		private void CheckCloseHome_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckCloseHome.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0003498C File Offset: 0x00032B8C
		private void CheckBoxAltTab_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckBoxAltTab.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00034A4C File Offset: 0x00032C4C
		private void CheckRiftAudio_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckRiftAudio.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.SetRiftAsDefault = true;
					GetConfig.SetRiftDefault = true;
					MySettingsProperty.Settings.Save();
					bool flag2 = (Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, "", false) == 0) | (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, "", false) == 0);
					if (flag2)
					{
						this.Cursor = Cursors.WaitCursor;
						MyProject.Forms.FrmSetFallback.ShowDialog();
						this.Cursor = Cursors.Default;
					}
				}
				else
				{
					MySettingsProperty.Settings.SetRiftAsDefault = false;
					GetConfig.SetRiftDefault = false;
					MySettingsProperty.Settings.Save();
				}
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00034B18 File Offset: 0x00032D18
		private void StartWatcherNoHome()
		{
			try
			{
				bool setRiftDefault = GetConfig.SetRiftDefault;
				if (setRiftDefault)
				{
					bool flag = MySettingsProperty.Settings.SetRiftAudioDefault == 0;
					if (flag)
					{
						Thread thread = new Thread((FrmMain._Closure$__.$I131-0 == null) ? (FrmMain._Closure$__.$I131-0 = delegate
						{
							AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
						}) : FrmMain._Closure$__.$I131-0);
						thread.Start();
					}
					bool flag2 = MySettingsProperty.Settings.SetRiftMicDefault == 0;
					if (flag2)
					{
						Thread thread2 = new Thread((FrmMain._Closure$__.$I131-1 == null) ? (FrmMain._Closure$__.$I131-1 = delegate
						{
							AudioSwitcher.SetDefaultMicDeviceOnStart();
						}) : FrmMain._Closure$__.$I131-1);
						thread2.Start();
					}
				}
				bool flag3 = OTTDB.numWMI > 0;
				if (flag3)
				{
					this.CreateWatcher();
				}
				else
				{
					Log.WriteToLog("No WMI profiles found");
				}
				bool flag4 = OTTDB.numTimer > 0;
				if (flag4)
				{
					Log.WriteToLog("Starting Timer AppWatcher");
					this.pTimer.Start();
				}
				else
				{
					Log.WriteToLog("No Timer profiles found");
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("StartWatcherNoHome: " + ex.Message);
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00034C54 File Offset: 0x00032E54
		public void CreateWatcher()
		{
			try
			{
				this.Watcher.Stop();
				Log.WriteToLog("Starting WMI AppWatcher");
				string text = "SELECT TargetInstance  FROM __InstanceCreationEvent WITHIN  1.0  WHERE TargetInstance ISA 'Win32_Process'    AND TargetInstance.Name like '%'";
				string text2 = "\\\\.\\root\\CIMV2";
				this.Watcher = new ManagementEventWatcher(text2, text);
				this.Watcher.Start();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("CreateWatcher: " + ex.Message);
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00034CD8 File Offset: 0x00032ED8
		private void StopWatcherNoHome()
		{
			try
			{
				Log.WriteToLog("Stopping AppWatcher");
				this.Watcher.Stop();
				this.pTimer.Stop();
				bool isListening = VoiceCommands.isListening;
				if (isListening)
				{
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("Stopping voice command listener");
					}
					VoiceCommands.StopListening();
				}
				bool grammarsBuilt = VoiceCommands.grammarsBuilt;
				if (grammarsBuilt)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Disabling voice commands");
					}
					VoiceCommands.DisableVoice();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("StopWatcherNoHome: " + ex.Message);
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00034D90 File Offset: 0x00032F90
		private void OculusHomeWatcher_Tick(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			bool flag = processesByName.Length > 0;
			if (flag)
			{
				try
				{
					this.OculusHomeWatcher.Stop();
					this.HomeIsRunning = true;
					Log.WriteToLog("Oculus Home is running");
					this.AddToListboxAndScroll("Oculus Home is running");
					bool flag2 = MySettingsProperty.Settings.ApplyPowerPlan == 1;
					if (flag2)
					{
						PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
						PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
					}
					bool sendHomeToTray = MySettingsProperty.Settings.SendHomeToTray;
					if (sendHomeToTray)
					{
						this.HometoTrayTimer.Enabled = true;
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog("HometoTrayTimer started");
						}
					}
					else
					{
						this.HometoTrayTimer.Enabled = false;
					}
					bool setRiftDefault = GetConfig.SetRiftDefault;
					if (setRiftDefault)
					{
						bool flag3 = MySettingsProperty.Settings.SetRiftAudioDefault == 0;
						if (flag3)
						{
							bool flag4 = MySettingsProperty.Settings.SetAudioOnStartGuid != null;
							if (flag4)
							{
								AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
							}
							bool flag5 = MySettingsProperty.Settings.SetAudioCommOnStartGuid != null;
							if (flag5)
							{
								AudioSwitcher.SetDefaultAudioCommDeviceOnStart();
							}
						}
						bool flag6 = MySettingsProperty.Settings.SetRiftMicDefault == 0;
						if (flag6)
						{
							bool flag7 = MySettingsProperty.Settings.SetMicOnStartGuid != null;
							if (flag7)
							{
								AudioSwitcher.SetDefaultMicDeviceOnStart();
							}
							bool flag8 = MySettingsProperty.Settings.SetMicCommOnStartGuid != null;
							if (flag8)
							{
								AudioSwitcher.SetDefaultMicCommDeviceOnStart();
							}
						}
					}
					bool flag9 = MySettingsProperty.Settings.ASW == 0;
					if (flag9)
					{
						Thread thread = new Thread((FrmMain._Closure$__.$I134-0 == null) ? (FrmMain._Closure$__.$I134-0 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Auto");
						}) : FrmMain._Closure$__.$I134-0);
						thread.Start();
						this.AddToListboxAndScroll("ASW set to Auto");
						this.ComboBox1.Text = "Auto";
					}
					bool flag10 = MySettingsProperty.Settings.ASW == 1;
					if (flag10)
					{
						Thread thread2 = new Thread((FrmMain._Closure$__.$I134-1 == null) ? (FrmMain._Closure$__.$I134-1 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Off");
						}) : FrmMain._Closure$__.$I134-1);
						thread2.Start();
						this.AddToListboxAndScroll("ASW set to Off");
						this.ComboBox1.Text = "Off";
					}
					bool flag11 = MySettingsProperty.Settings.ASW == 2;
					if (flag11)
					{
						Thread thread3 = new Thread((FrmMain._Closure$__.$I134-2 == null) ? (FrmMain._Closure$__.$I134-2 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock45");
						}) : FrmMain._Closure$__.$I134-2);
						thread3.Start();
						this.AddToListboxAndScroll("Framerate @ 45 Hz");
						this.ComboBox1.Text = "45 Hz";
					}
					bool flag12 = MySettingsProperty.Settings.ASW == 3;
					if (flag12)
					{
						Thread thread4 = new Thread((FrmMain._Closure$__.$I134-3 == null) ? (FrmMain._Closure$__.$I134-3 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock30");
						}) : FrmMain._Closure$__.$I134-3);
						thread4.Start();
						this.AddToListboxAndScroll("Framerate @ 30 Hz");
						this.ComboBox1.Text = "30 Hz";
					}
					bool flag13 = MySettingsProperty.Settings.ASW == 4;
					if (flag13)
					{
						Thread thread5 = new Thread((FrmMain._Closure$__.$I134-4 == null) ? (FrmMain._Closure$__.$I134-4 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock18");
						}) : FrmMain._Closure$__.$I134-4);
						thread5.Start();
						this.AddToListboxAndScroll("Framerate @ 18 Hz");
						this.ComboBox1.Text = "18 Hz";
					}
					bool flag14 = MySettingsProperty.Settings.ASW == 5;
					if (flag14)
					{
						Thread thread6 = new Thread((FrmMain._Closure$__.$I134-5 == null) ? (FrmMain._Closure$__.$I134-5 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Sim45");
						}) : FrmMain._Closure$__.$I134-5);
						thread6.Start();
						this.AddToListboxAndScroll("Framerate forced to 45 Hz");
						this.ComboBox1.Text = "45 Hz forced";
					}
					bool flag15 = MySettingsProperty.Settings.ASW == 6;
					if (flag15)
					{
						Thread thread7 = new Thread((FrmMain._Closure$__.$I134-6 == null) ? (FrmMain._Closure$__.$I134-6 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
						}) : FrmMain._Closure$__.$I134-6);
						thread7.Start();
						this.AddToListboxAndScroll("Framerate set to Adaptive");
						this.ComboBox1.Text = "Adaptive";
					}
					bool flag16 = OTTDB.numWMI > 0;
					if (flag16)
					{
						this.CreateWatcher();
					}
					bool flag17 = OTTDB.numTimer > 0;
					if (flag17)
					{
						Log.WriteToLog("Starting Timer AppWatcher");
						this.pTimer.Start();
					}
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Adding backgroundworker for monitoring Oculus Home/SteamVR");
					}
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += this.HomeWork;
					backgroundWorker.RunWorkerAsync();
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog("Backgroundworker started");
					}
					bool mirrorHome = MySettingsProperty.Settings.MirrorHome;
					if (mirrorHome)
					{
						this._Home2Timer.Elapsed += this._Home2TimerElapsed;
						this._Home2Timer.Start();
					}
					bool useVoiceCommands = MySettingsProperty.Settings.UseVoiceCommands;
					if (useVoiceCommands)
					{
						this.EnableDisableVoice(true);
					}
					bool useHotKeys = MySettingsProperty.Settings.UseHotKeys;
					if (useHotKeys)
					{
						this.kbHook = new KeyboardHook();
					}
					else
					{
						this.kbHook = null;
					}
				}
				catch (Exception ex)
				{
					this.AddToListboxAndScroll(ex.Message);
					StackTrace stackTrace = new StackTrace(ex, true);
					Log.WriteToLog("OculusHomeWatcher_Tick: " + ex.ToString() + stackTrace.ToString());
				}
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0003532C File Offset: 0x0003352C
		private void _Home2TimerElapsed(object sender, ElapsedEventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
			bool flag = processesByName.Length > 0;
			if (flag)
			{
				this._Home2Timer.Stop();
				Log.WriteToLog("Starting Oculus Mirror ");
				Process.Start(this.OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
				MinMaxApp.MaximizeApp("OculusMirror");
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Adding backgroundworker for Oculus Mirror");
				}
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += this.Home2Work;
				backgroundWorker.RunWorkerAsync();
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Backgroundworker started");
				}
			}
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000353D8 File Offset: 0x000335D8
		private void OnTimerProfile(object source, ElapsedEventArgs e)
		{
			bool manualStart = this.ManualStart;
			checked
			{
				if (!manualStart)
				{
					try
					{
						foreach (KeyValuePair<string, string> keyValuePair in this.profileTimerList)
						{
							Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(keyValuePair.Key));
							bool flag = processesByName.Length > 0;
							if (flag)
							{
								try
								{
									FrmMain._Closure$__136-0 CS$<>8__locals1 = new FrmMain._Closure$__136-0(CS$<>8__locals1);
									this.pTimer.Stop();
									this.runningApp = keyValuePair.Key;
									this.CurrentSS = keyValuePair.Value;
									this.pid = processesByName[0].Id;
									this.runningapp_displayname = OTTDB.GetDisplayName(this.runningApp);
									Log.WriteToLog(string.Concat(new string[]
									{
										"Game launch detected using Timer:  ",
										this.runningapp_displayname,
										" with PID ",
										Conversions.ToString(this.pid),
										" (",
										this.appName,
										")"
									}));
									this.AddToListboxAndScroll(this.runningapp_displayname + ": Applying profile");
									Thread thread = new Thread(delegate
									{
										RunCommand.Run_debug_tool(this.CurrentSS);
									});
									thread.Start();
									CS$<>8__locals1.$VB$Local_fov = "";
									bool flag2 = this.profileFOV.TryGetValue(this.runningApp.ToLower(), out CS$<>8__locals1.$VB$Local_fov);
									if (flag2)
									{
										Thread thread2 = new Thread(delegate
										{
											RunCommand.Run_debug_tool_fov(CS$<>8__locals1.$VB$Local_fov);
										});
										thread2.Start();
									}
									CS$<>8__locals1.$VB$Local_forcemipmap = "";
									bool flag3 = this.profileForceMipMap.TryGetValue(this.runningApp.ToLower(), out CS$<>8__locals1.$VB$Local_forcemipmap);
									if (flag3)
									{
										Thread thread3 = new Thread(delegate
										{
											RunCommand.Run_debug_tool_force_mipmap(CS$<>8__locals1.$VB$Local_forcemipmap.ToLower());
										});
										thread3.Start();
									}
									CS$<>8__locals1.$VB$Local_offsetmipmap = "";
									bool flag4 = this.profileOffsetMipMap.TryGetValue(this.runningApp.ToLower(), out CS$<>8__locals1.$VB$Local_offsetmipmap);
									if (flag4)
									{
										Thread thread4 = new Thread(delegate
										{
											RunCommand.Run_debug_tool_offset_mipmap(CS$<>8__locals1.$VB$Local_offsetmipmap);
										});
										thread4.Start();
									}
									string text = "";
									bool flag5 = this.profileAGPS.TryGetValue(this.runningApp.ToLower(), out text);
									if (flag5)
									{
										bool flag6 = Operators.CompareString(text, "0", false) == 0;
										if (flag6)
										{
											Thread thread5 = new Thread((FrmMain._Closure$__.$I136-4 == null) ? (FrmMain._Closure$__.$I136-4 = delegate
											{
												RunCommand.Run_debug_tool_agps("false");
											}) : FrmMain._Closure$__.$I136-4);
											thread5.Start();
										}
										else
										{
											Thread thread6 = new Thread((FrmMain._Closure$__.$I136-5 == null) ? (FrmMain._Closure$__.$I136-5 = delegate
											{
												RunCommand.Run_debug_tool_agps("true");
											}) : FrmMain._Closure$__.$I136-5);
											thread6.Start();
										}
									}
									bool homeIsMirrored = this.HomeIsMirrored;
									if (homeIsMirrored)
									{
										Process[] processesByName2 = Process.GetProcessesByName("OculusMirror");
										bool flag7 = processesByName2.Length > 0;
										if (flag7)
										{
											processesByName2[0].Kill();
											this.HomeIsMirrored = false;
										}
									}
									bool flag8 = !GetConfig.SetRiftDefault | (MySettingsProperty.Settings.SetRiftAudioDefault != 2);
									if (flag8)
									{
										bool voiceConfirmProfile = MySettingsProperty.Settings.VoiceConfirmProfile;
										if (voiceConfirmProfile)
										{
											Thread thread7 = new Thread((FrmMain._Closure$__.$I136-6 == null) ? (FrmMain._Closure$__.$I136-6 = delegate
											{
												MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
											}) : FrmMain._Closure$__.$I136-6);
											thread7.Start();
										}
									}
									bool setRiftDefault = GetConfig.SetRiftDefault;
									if (setRiftDefault)
									{
										bool flag9 = MySettingsProperty.Settings.SetRiftAudioDefault == 2;
										if (flag9)
										{
											bool voiceConfirmProfile2 = MySettingsProperty.Settings.VoiceConfirmProfile;
											if (voiceConfirmProfile2)
											{
												Thread thread8 = new Thread((FrmMain._Closure$__.$I136-7 == null) ? (FrmMain._Closure$__.$I136-7 = delegate
												{
													AudioSwitcher.SetDefaultAudioDeviceOnStart(true);
												}) : FrmMain._Closure$__.$I136-7);
												thread8.Start();
											}
											else
											{
												Thread thread9 = new Thread((FrmMain._Closure$__.$I136-8 == null) ? (FrmMain._Closure$__.$I136-8 = delegate
												{
													AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
												}) : FrmMain._Closure$__.$I136-8);
												thread9.Start();
											}
										}
										bool flag10 = MySettingsProperty.Settings.SetRiftMicDefault == 2;
										if (flag10)
										{
											Thread thread10 = new Thread((FrmMain._Closure$__.$I136-9 == null) ? (FrmMain._Closure$__.$I136-9 = delegate
											{
												AudioSwitcher.SetDefaultMicDeviceOnStart();
											}) : FrmMain._Closure$__.$I136-9);
											thread10.Start();
										}
									}
									string text2 = "";
									bool flag11 = this.profileCpuDelay.TryGetValue(this.runningApp.ToLower(), out text2);
									if (flag11)
									{
										this.cpuTimer.AutoReset = false;
										this.cpuTimer.Interval = (double)(Conversions.ToInteger(text2) * 1000);
										this.cpuTimer.Elapsed += this.ApplyCpuPrioTick;
										this.cpuTimer.Start();
										Log.WriteToLog(string.Concat(new string[] { "Timer: ", this.runningapp_displayname, ": Applying CPU Priority in ", text2, " seconds" }));
									}
									string text3 = "";
									bool flag12 = this.profileAswDelay.TryGetValue(this.runningApp.ToLower(), out text3);
									if (flag12)
									{
										this.aswTimer.AutoReset = false;
										this.aswTimer.Interval = (double)(Conversions.ToInteger(text3) * 1000);
										this.aswTimer.Elapsed += this.ApplyAswTick;
										this.aswTimer.Start();
										Log.WriteToLog(string.Concat(new string[] { "Timer: ", this.runningapp_displayname, ": Applying ASW setting in ", text3, " seconds" }));
										this.AddToListboxAndScroll(this.runningapp_displayname + ": Applying ASW setting in " + text3 + " seconds");
									}
									string text4 = "";
									bool flag13 = this.profileMirror.TryGetValue(this.runningApp.ToLower(), out text4);
									if (flag13)
									{
										bool flag14 = Operators.CompareString(text4, "1", false) == 0;
										if (flag14)
										{
											MinMaxApp.MinimizeCount = 0;
											this.mirrorTimer.AutoReset = true;
											this.mirrorTimer.Interval = 5000.0;
											this.mirrorTimer.Elapsed += this.ApplyMirrorTick;
											this.mirrorTimer.Start();
										}
										bool flag15 = Operators.CompareString(text4, "2", false) == 0;
										if (flag15)
										{
											Log.WriteToLog("Starting Oculus Mirror");
											Process.Start(this.OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
										}
									}
									bool flag16 = Operators.ConditionalCompareObjectNotEqual(this.GetCurrentResolution(), MySettingsProperty.Settings.DesktopResolution, false);
									if (flag16)
									{
										FrmMain._Closure$__136-1 CS$<>8__locals2 = new FrmMain._Closure$__136-1(CS$<>8__locals2);
										this.AddToListboxAndScroll("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
										Log.WriteToLog("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
										string[] array = Strings.Split(MySettingsProperty.Settings.DesktopResolution, "x", -1, CompareMethod.Binary);
										CS$<>8__locals2.$VB$Local_yRes = (short)Conversions.ToInteger(array[0].Trim());
										CS$<>8__locals2.$VB$Local_xRes = (short)Conversions.ToInteger(array[1].Trim());
										Thread thread11 = new Thread(delegate
										{
											Resolution.ChangeDisplaySettings((int)CS$<>8__locals2.$VB$Local_yRes, (int)CS$<>8__locals2.$VB$Local_xRes);
										});
										thread11.Start();
									}
									bool dbg = Globals.dbg;
									if (dbg)
									{
										Log.WriteToLog("Starting AppWatchWorker in 2 seconds");
									}
									Thread.Sleep(2000);
									this.AppWatchWorker.DoWork += this.AppWork;
									this.AppWatchWorker.RunWorkerAsync();
									bool dbg2 = Globals.dbg;
									if (dbg2)
									{
										Log.WriteToLog("Worker started");
									}
									break;
								}
								catch (Exception ex)
								{
									this.AddToListboxAndScroll(ex.Message);
									StackTrace stackTrace = new StackTrace(ex, true);
									Log.WriteToLog(ex.ToString() + stackTrace.ToString());
								}
							}
						}
					}
					finally
					{
						Dictionary<string, string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
			}
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00035C18 File Offset: 0x00033E18
		private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			checked
			{
				try
				{
					bool manualStart = this.ManualStart;
					if (!manualStart)
					{
						try
						{
							ManagementBaseObject managementBaseObject = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
							this.runningApp = managementBaseObject.Properties["ExecutablePath"].Value.ToString();
							this.appName = managementBaseObject.Properties["ExecutablePath"].Value.ToString().ToLower();
							bool flag = this.AllAppsList.ContainsKey(this.runningApp);
							if (flag)
							{
								this.pid = Conversions.ToInteger(managementBaseObject.Properties["processId"].Value.ToString().ToLower());
								bool dbg = Globals.dbg;
								if (dbg)
								{
									Log.WriteToLog("Process " + this.runningApp + " was found in list, storing PID");
								}
							}
						}
						catch (Exception ex)
						{
							return;
						}
						bool flag2 = Operators.CompareString(Path.GetFileNameWithoutExtension(this.runningApp), "OculusDash", false) == 0;
						if (flag2)
						{
							bool flag3 = Operators.CompareString(MySettingsProperty.Settings.OVRSrvPrio, "Normal", false) != 0;
							if (flag3)
							{
								Thread thread = new Thread(delegate
								{
									this.ChangeCPUPrioDash(MySettingsProperty.Settings.OVRSrvPrio);
								});
								thread.Start();
							}
						}
						string text = "";
						bool flag4 = this.profileList.TryGetValue(this.appName, out text);
						if (flag4)
						{
							this.Watcher.Stop();
							this.pTimer.Stop();
							this.CurrentSS = text;
							this.runningAppExe = Path.GetFileName(this.runningApp);
							this.runningapp_displayname = OTTDB.GetDisplayName(this.runningApp);
							Log.WriteToLog(string.Concat(new string[]
							{
								"Game launch detected using WMI: ",
								this.runningapp_displayname,
								" with PID ",
								Conversions.ToString(this.pid),
								" (",
								this.appName,
								")"
							}));
							bool dbg2 = Globals.dbg;
							if (dbg2)
							{
								Log.WriteToLog(this.runningApp + ": Super Sampling @ " + this.CurrentSS);
							}
							this.AddToListboxAndScroll(this.runningapp_displayname + ": Applying profile");
							Thread thread2 = new Thread(delegate
							{
								RunCommand.Run_debug_tool(this.CurrentSS);
							});
							thread2.Start();
							string fov = "";
							bool flag5 = this.profileFOV.TryGetValue(this.runningApp.ToLower(), out fov);
							if (flag5)
							{
								Thread thread3 = new Thread(delegate
								{
									RunCommand.Run_debug_tool_fov(fov);
								});
								thread3.Start();
							}
							string forcemipmap = "";
							bool flag6 = this.profileForceMipMap.TryGetValue(this.runningApp.ToLower(), out forcemipmap);
							if (flag6)
							{
								Thread thread4 = new Thread(delegate
								{
									RunCommand.Run_debug_tool_force_mipmap(forcemipmap.ToLower());
								});
								thread4.Start();
							}
							string offsetmipmap = "";
							bool flag7 = this.profileOffsetMipMap.TryGetValue(this.runningApp.ToLower(), out offsetmipmap);
							if (flag7)
							{
								Thread thread5 = new Thread(delegate
								{
									RunCommand.Run_debug_tool_offset_mipmap(offsetmipmap);
								});
								thread5.Start();
							}
							string text2 = "";
							bool flag8 = this.profileAGPS.TryGetValue(this.runningApp.ToLower(), out text2);
							if (flag8)
							{
								bool flag9 = Operators.CompareString(text2, "0", false) == 0;
								if (flag9)
								{
									Thread thread6 = new Thread((FrmMain._Closure$__.$I137-5 == null) ? (FrmMain._Closure$__.$I137-5 = delegate
									{
										RunCommand.Run_debug_tool_agps("false");
									}) : FrmMain._Closure$__.$I137-5);
									thread6.Start();
								}
								else
								{
									Thread thread7 = new Thread((FrmMain._Closure$__.$I137-6 == null) ? (FrmMain._Closure$__.$I137-6 = delegate
									{
										RunCommand.Run_debug_tool_agps("true");
									}) : FrmMain._Closure$__.$I137-6);
									thread7.Start();
								}
							}
							bool homeIsMirrored = this.HomeIsMirrored;
							if (homeIsMirrored)
							{
								Process[] processesByName = Process.GetProcessesByName("OculusMirror");
								bool flag10 = processesByName.Length > 0;
								if (flag10)
								{
									processesByName[0].Kill();
									this.HomeIsMirrored = false;
								}
							}
							bool flag11 = !GetConfig.SetRiftDefault | (MySettingsProperty.Settings.SetRiftAudioDefault != 2);
							if (flag11)
							{
								bool voiceConfirmProfile = MySettingsProperty.Settings.VoiceConfirmProfile;
								if (voiceConfirmProfile)
								{
									Thread thread8 = new Thread((FrmMain._Closure$__.$I137-7 == null) ? (FrmMain._Closure$__.$I137-7 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
									}) : FrmMain._Closure$__.$I137-7);
									thread8.Start();
								}
							}
							bool setRiftDefault = GetConfig.SetRiftDefault;
							if (setRiftDefault)
							{
								bool flag12 = MySettingsProperty.Settings.SetRiftAudioDefault == 2;
								if (flag12)
								{
									bool voiceConfirmProfile2 = MySettingsProperty.Settings.VoiceConfirmProfile;
									if (voiceConfirmProfile2)
									{
										Thread thread9 = new Thread((FrmMain._Closure$__.$I137-8 == null) ? (FrmMain._Closure$__.$I137-8 = delegate
										{
											AudioSwitcher.SetDefaultAudioDeviceOnStart(true);
										}) : FrmMain._Closure$__.$I137-8);
										thread9.Start();
									}
									else
									{
										Thread thread10 = new Thread((FrmMain._Closure$__.$I137-9 == null) ? (FrmMain._Closure$__.$I137-9 = delegate
										{
											AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
										}) : FrmMain._Closure$__.$I137-9);
										thread10.Start();
									}
								}
								bool flag13 = MySettingsProperty.Settings.SetRiftMicDefault == 2;
								if (flag13)
								{
									Thread thread11 = new Thread((FrmMain._Closure$__.$I137-10 == null) ? (FrmMain._Closure$__.$I137-10 = delegate
									{
										AudioSwitcher.SetDefaultMicDeviceOnStart();
									}) : FrmMain._Closure$__.$I137-10);
									thread11.Start();
								}
							}
							string text3 = "";
							bool flag14 = this.profileCpuDelay.TryGetValue(this.runningApp.ToLower(), out text3);
							if (flag14)
							{
								this.cpuTimer.AutoReset = false;
								this.cpuTimer.Interval = (double)(Conversions.ToInteger(text3) * 1000);
								this.cpuTimer.Elapsed += this.ApplyCpuPrioTick;
								this.cpuTimer.Start();
								Log.WriteToLog(this.runningapp_displayname + ": Applying CPU Priority in " + text3 + " seconds");
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Applying CPU Priority in " + text3 + " seconds");
							}
							string text4 = "";
							bool flag15 = this.profileAswDelay.TryGetValue(this.runningApp.ToLower(), out text4);
							if (flag15)
							{
								this.aswTimer.AutoReset = false;
								this.aswTimer.Interval = (double)(Conversions.ToInteger(text4) * 1000);
								this.aswTimer.Elapsed += this.ApplyAswTick;
								this.aswTimer.Start();
								Log.WriteToLog(this.runningapp_displayname + ": Applying ASW setting in " + text4 + " seconds");
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Applying ASW setting in " + text4 + " seconds");
							}
							string text5 = "";
							bool flag16 = this.profileMirror.TryGetValue(this.runningApp.ToLower(), out text5);
							if (flag16)
							{
								bool flag17 = Operators.CompareString(text5, "1", false) == 0;
								if (flag17)
								{
									MinMaxApp.MinimizeCount = 0;
									this.mirrorTimer.AutoReset = true;
									this.mirrorTimer.Interval = 5000.0;
									this.mirrorTimer.Elapsed += this.ApplyMirrorTick;
									this.mirrorTimer.Start();
								}
								bool flag18 = Operators.CompareString(text5, "2", false) == 0;
								if (flag18)
								{
									Log.WriteToLog("Starting Oculus Mirror");
									Process.Start(this.OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
								}
							}
							bool flag19 = Operators.ConditionalCompareObjectNotEqual(this.GetCurrentResolution(), MySettingsProperty.Settings.DesktopResolution, false);
							if (flag19)
							{
								this.AddToListboxAndScroll("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
								Log.WriteToLog("Setting Desktop resolution to " + MySettingsProperty.Settings.DesktopResolution);
								string[] array = Strings.Split(MySettingsProperty.Settings.DesktopResolution, "x", -1, CompareMethod.Binary);
								short yRes = (short)Conversions.ToInteger(array[0].Trim());
								short xRes = (short)Conversions.ToInteger(array[1].Trim());
								Thread thread12 = new Thread(delegate
								{
									Resolution.ChangeDisplaySettings((int)yRes, (int)xRes);
								});
								thread12.Start();
							}
							bool dbg3 = Globals.dbg;
							if (dbg3)
							{
								Log.WriteToLog("Starting AppWatchWorker in 2 seconds");
							}
							Thread.Sleep(2000);
							this.AppWatchWorker.DoWork += this.AppWork;
							this.AppWatchWorker.RunWorkerAsync();
							bool dbg4 = Globals.dbg;
							if (dbg4)
							{
								Log.WriteToLog("Worker started");
							}
						}
						else
						{
							this.runningApp = "";
						}
					}
				}
				catch (Exception ex2)
				{
					Log.WriteToLog("Watcher_EventArrived: " + ex2.ToString());
					bool flag20 = OTTDB.numWMI > 0;
					if (flag20)
					{
						this.CreateWatcher();
					}
				}
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00036568 File Offset: 0x00034768
		public void ApplyMirrorTick(object sender, ElapsedEventArgs e)
		{
			bool flag = MinMaxApp.MinimizeCount > 0;
			if (flag)
			{
				this.mirrorTimer.Enabled = false;
			}
			else
			{
				MinMaxApp.SetMirrorRetry = 0;
				MinMaxApp.MinimizeApp(Path.GetFileNameWithoutExtension(this.runningApp));
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x000365AC File Offset: 0x000347AC
		public void ApplyCpuPrioTick(object sender, ElapsedEventArgs e)
		{
			try
			{
				this.cpuTimer.Enabled = false;
				bool flag = Operators.CompareString(this.runningApp, "", false) == 0;
				if (flag)
				{
					this.cpuTimer.Enabled = false;
					this.cpuTimer.Elapsed -= this.ApplyCpuPrioTick;
				}
				else
				{
					string text = "";
					bool flag2 = this.profilePriorityList.TryGetValue(this.runningApp.ToLower(), out text);
					if (flag2)
					{
						Process[] processesByName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(this.runningApp));
						foreach (Process process in processesByName)
						{
							if (Operators.CompareString(text, "Normal", false) != 0)
							{
								if (Operators.CompareString(text, "Above Normal", false) != 0)
								{
									if (Operators.CompareString(text, "High", false) == 0)
									{
										process.PriorityClass = ProcessPriorityClass.High;
										bool flag3 = process.PriorityClass == ProcessPriorityClass.High;
										if (flag3)
										{
											this.AddToListboxAndScroll(this.runningapp_displayname + ": CPU Priority set to 'High'");
											Log.WriteToLog(this.runningapp_displayname + ": CPU Priority set to 'High'");
											break;
										}
									}
								}
								else
								{
									process.PriorityClass = ProcessPriorityClass.AboveNormal;
									bool flag4 = process.PriorityClass == ProcessPriorityClass.AboveNormal;
									if (flag4)
									{
										this.AddToListboxAndScroll(this.runningapp_displayname + ": CPU Priority set to 'Above Normal'");
										Log.WriteToLog(this.runningapp_displayname + ": CPU Priority set to 'Above Normal'");
										break;
									}
								}
							}
							else
							{
								process.PriorityClass = ProcessPriorityClass.Normal;
								bool flag5 = process.PriorityClass == ProcessPriorityClass.Normal;
								if (flag5)
								{
									this.AddToListboxAndScroll(this.runningapp_displayname + ": CPU Priority set to 'Normal'");
									Log.WriteToLog(this.runningapp_displayname + ": CPU Priority set to 'Normal'");
									break;
								}
							}
						}
					}
					this.cpuTimer.Enabled = false;
					this.cpuTimer.Elapsed -= this.ApplyCpuPrioTick;
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll(ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("ApplyCpuPrioTick: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00036828 File Offset: 0x00034A28
		public void ApplyAswTick(object sender, ElapsedEventArgs e)
		{
			try
			{
				bool flag = Operators.CompareString(this.runningApp, "", false) == 0;
				if (flag)
				{
					this.aswTimer.Enabled = false;
					this.aswTimer.Elapsed -= this.ApplyAswTick;
				}
				else
				{
					string text = "";
					bool flag2 = this.profileASWList.TryGetValue(this.runningApp.ToLower(), out text);
					if (flag2)
					{
						bool flag3 = Operators.CompareString(text, "Inherit", false) != 0;
						if (flag3)
						{
							bool flag4 = Operators.CompareString(text, "Auto", false) == 0;
							if (flag4)
							{
								Thread thread = new Thread((FrmMain._Closure$__.$I140-0 == null) ? (FrmMain._Closure$__.$I140-0 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Auto");
								}) : FrmMain._Closure$__.$I140-0);
								thread.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": ASW set to Auto");
								Log.WriteToLog(this.runningapp_displayname + ": ASW set to Auto");
							}
							bool flag5 = Operators.CompareString(text, "Off", false) == 0;
							if (flag5)
							{
								Thread thread2 = new Thread((FrmMain._Closure$__.$I140-1 == null) ? (FrmMain._Closure$__.$I140-1 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Off");
								}) : FrmMain._Closure$__.$I140-1);
								thread2.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": ASW set to Off");
								Log.WriteToLog(this.runningapp_displayname + ": ASW set to Off");
							}
							bool flag6 = (Operators.CompareString(text, "45 Hz", false) == 0) | (Operators.CompareString(text, "45 fps", false) == 0);
							if (flag6)
							{
								Thread thread3 = new Thread((FrmMain._Closure$__.$I140-2 == null) ? (FrmMain._Closure$__.$I140-2 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock45");
								}) : FrmMain._Closure$__.$I140-2);
								thread3.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Framerate @ 45 Hz");
								Log.WriteToLog(this.runningapp_displayname + ": Framerate @ 45 Hz");
							}
							bool flag7 = Operators.CompareString(text, "30 Hz", false) == 0;
							if (flag7)
							{
								Thread thread4 = new Thread((FrmMain._Closure$__.$I140-3 == null) ? (FrmMain._Closure$__.$I140-3 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock30");
								}) : FrmMain._Closure$__.$I140-3);
								thread4.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Framerate @ 30 Hz");
								Log.WriteToLog(this.runningapp_displayname + ": Framerate @ 30 Hz");
							}
							bool flag8 = Operators.CompareString(text, "18 Hz", false) == 0;
							if (flag8)
							{
								Thread thread5 = new Thread((FrmMain._Closure$__.$I140-4 == null) ? (FrmMain._Closure$__.$I140-4 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock18");
								}) : FrmMain._Closure$__.$I140-4);
								thread5.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Framerate @ 18 Hz");
								Log.WriteToLog(this.runningapp_displayname + ": Framerate @ 18 Hz");
							}
							bool flag9 = Operators.CompareString(text, "45 Hz forced", false) == 0;
							if (flag9)
							{
								Thread thread6 = new Thread((FrmMain._Closure$__.$I140-5 == null) ? (FrmMain._Closure$__.$I140-5 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Sim45");
								}) : FrmMain._Closure$__.$I140-5);
								thread6.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Framerate @ 45 Hz forced");
								Log.WriteToLog(this.runningapp_displayname + ": Framerate forced to 45 Hz");
							}
							bool flag10 = Operators.CompareString(text, "Adaptive", false) == 0;
							if (flag10)
							{
								Thread thread7 = new Thread((FrmMain._Closure$__.$I140-6 == null) ? (FrmMain._Closure$__.$I140-6 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
								}) : FrmMain._Closure$__.$I140-6);
								thread7.Start();
								this.AddToListboxAndScroll(this.runningapp_displayname + ": Framerate set to Adaptive");
								Log.WriteToLog(this.runningapp_displayname + ": Framerate set to Adaptive");
							}
						}
					}
					this.aswTimer.Enabled = false;
					this.aswTimer.Elapsed -= this.ApplyAswTick;
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll(ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("ApplyAswTick: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00036C94 File Offset: 0x00034E94
		private void Home2Work(object sender, DoWorkEventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
			bool flag = processesByName.Length > 0;
			if (flag)
			{
				processesByName[0].WaitForExit();
				Log.WriteToLog("Stopping Oculus Home mirror");
				this.AddToListboxAndScroll("Stopping Oculus Home mirror");
				Process[] processesByName2 = Process.GetProcessesByName("OculusMirror");
				bool flag2 = processesByName2.Length > 0;
				if (flag2)
				{
					processesByName2[0].Kill();
					this.HomeIsMirrored = false;
					this._Home2Timer.Start();
				}
			}
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00036D0C File Offset: 0x00034F0C
		private void HomeWork(object sender, DoWorkEventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			bool flag = processesByName.Length > 0;
			if (flag)
			{
				processesByName[0].WaitForExit();
				Log.WriteToLog("Oculus Home closed");
				this.AddToListboxAndScroll("Oculus Home closed");
				HomeToTray.ToastShown = false;
				this.DisableShowHomeMenu();
				bool flag2 = MySettingsProperty.Settings.SendHomeToTray | MySettingsProperty.Settings.SendHomeToTrayOnStart;
				if (flag2)
				{
					this.StartMinimizeHomeWatcher();
				}
				bool setRiftDefault = GetConfig.SetRiftDefault;
				if (setRiftDefault)
				{
					bool flag3 = MySettingsProperty.Settings.SetRiftAudioDefault == 0;
					if (flag3)
					{
						Thread thread = new Thread((FrmMain._Closure$__.$I142-0 == null) ? (FrmMain._Closure$__.$I142-0 = delegate
						{
							AudioSwitcher.SetFallbackAudioDevice();
							AudioSwitcher.SetFallbackCommAudioDevice();
						}) : FrmMain._Closure$__.$I142-0);
						thread.Start();
					}
					bool flag4 = MySettingsProperty.Settings.SetRiftMicDefault == 0;
					if (flag4)
					{
						Thread thread2 = new Thread((FrmMain._Closure$__.$I142-1 == null) ? (FrmMain._Closure$__.$I142-1 = delegate
						{
							AudioSwitcher.SetFallbackMicDevice();
							AudioSwitcher.SetFallbackCommMicDevice();
						}) : FrmMain._Closure$__.$I142-1);
						thread2.Start();
					}
				}
				bool flag5 = MySettingsProperty.Settings.ApplyPowerPlan == 1;
				if (flag5)
				{
					PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanExit);
					PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
				}
				this.Watcher.Stop();
				this.pTimer.Stop();
				this.HometoTrayTimer.Enabled = false;
				this.HomeIsRunning = false;
				bool joyAquired = GetControllers.joyAquired;
				if (joyAquired)
				{
					GetControllers.joy.Unacquire();
					GetControllers.joyAquired = false;
				}
				bool stopOVRHome = MySettingsProperty.Settings.StopOVRHome;
				if (stopOVRHome)
				{
					Thread.Sleep(1000);
					this.StopOVR();
				}
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Starting Oculus Home watcher");
				}
				base.BeginInvoke(new FrmMain.TimerStart(this.HomeStartFunction));
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Oculus Home watcher started");
				}
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00036F00 File Offset: 0x00035100
		private void HomeStartFunction()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering HomeStartFunction");
			}
			this.OculusHomeWatcher.Start();
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Exiting HomeStartFunction");
			}
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00036F44 File Offset: 0x00035144
		private void ToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			bool flag = Operators.CompareString(this.ToolStripMenuItem3.Text, "Set Rift as default Audio/Mic", false) == 0;
			if (flag)
			{
				bool flag2 = Operators.CompareString(MySettingsProperty.Settings.RiftAudioGuid, null, false) != 0;
				if (flag2)
				{
					RiftDefault.SetRiftDefaultAudioDevice();
				}
				bool flag3 = Operators.CompareString(MySettingsProperty.Settings.RiftMicGuid, null, false) != 0;
				if (flag3)
				{
					RiftDefault.SetRiftDefaultMicDevice();
				}
				bool flag4 = GetDevices.GetDefaultAudioDeviceName().ToString().ToLower()
					.Contains("rift");
				if (flag4)
				{
					this.ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
				}
				this.Cursor = Cursors.Default;
			}
			else
			{
				bool flag5 = Operators.CompareString(this.ToolStripMenuItem3.Text, "Set Fallback as default Audio/Mic", false) == 0;
				if (flag5)
				{
					bool flag6 = Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, null, false) != 0;
					if (flag6)
					{
						AudioSwitcher.SetFallbackAudioDevice();
					}
					else
					{
						Log.WriteToLog("Could not set fallback audio device, no device selected");
						FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio device, no device selected");
					}
					bool flag7 = Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, null, false) != 0;
					if (flag7)
					{
						AudioSwitcher.SetFallbackMicDevice();
					}
					else
					{
						Log.WriteToLog("Could not set fallback microphone device, no device selected");
						FrmMain.fmain.AddToListboxAndScroll("Could not set fallback microphone device, no device selected");
					}
					bool flag8 = Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommGuid, null, false) != 0;
					if (flag8)
					{
						AudioSwitcher.SetFallbackCommMicDevice();
					}
					else
					{
						Log.WriteToLog("Could not set fallback mic communications device, no device selected");
						FrmMain.fmain.AddToListboxAndScroll("Could not set fallback mic communications device, no device selected");
					}
					bool flag9 = Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommAudioGuid, null, false) != 0;
					if (flag9)
					{
						AudioSwitcher.SetFallbackCommAudioDevice();
					}
					else
					{
						Log.WriteToLog("Could not set fallback audio communications device, no device selected");
						FrmMain.fmain.AddToListboxAndScroll("Could not set fallback mic communications device, no device selected");
					}
					bool flag10 = !GetDevices.GetDefaultAudioDeviceName().ToString().ToLower()
						.Contains("rift");
					if (flag10)
					{
						this.ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
					}
				}
				bool flag11 = (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, null, false) == 0) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, null, false) == 0);
				if (flag11)
				{
					Interaction.MsgBox("Could not set fallback audio and microphone devices, no devices selected", MsgBoxStyle.Exclamation, "Warning");
				}
				else
				{
					bool flag12 = Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, null, false) == 0;
					if (flag12)
					{
						Interaction.MsgBox("Could not set fallback audio device, no device selected", MsgBoxStyle.Exclamation, "Warning");
					}
					bool flag13 = Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, null, false) == 0;
					if (flag13)
					{
						Interaction.MsgBox("Could not set fallback microphone device, no device selected", MsgBoxStyle.Exclamation, "Warning");
					}
				}
				this.Cursor = Cursors.Default;
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00037208 File Offset: 0x00035408
		private void CheckSpoofCPU_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool flag2 = this.isElevated;
					if (flag2)
					{
						bool @checked = this.CheckSpoofCPU.Checked;
						if (@checked)
						{
							this.CheckSpoofCPU.Refresh();
							MySettingsProperty.Settings.SpoofCPU = true;
							this.spoofid = true;
							MySettingsProperty.Settings.OldCPUID = "";
							Interaction.MsgBox("The CPU ID will be changed next time (and every time) you start Oculus Tray Tool. Remember to start Oculus Tray Tool before starting Oculus Home.", MsgBoxStyle.Information, "Oculus Tray Tool");
						}
						else
						{
							MySettingsProperty.Settings.SpoofCPU = false;
							this.spoofid = false;
							this.RestoreCPUID();
						}
						MySettingsProperty.Settings.Save();
					}
					else
					{
						GetConfig.IsReading = true;
						this.CheckSpoofCPU.Checked = false;
						GetConfig.IsReading = false;
						Interaction.MsgBox("You must run the application as Administrator to change this option.", MsgBoxStyle.Critical, "Oculus Tray Tool");
					}
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00037340 File Offset: 0x00035540
		public void GetCPUid()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetCPUid");
			}
			try
			{
				RegistryKey registryKey = MyProject.Computer.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
				this.cpuid = Conversions.ToString(registryKey.GetValue("ProcessorNameString"));
				Log.WriteToLog("Current CPU ID: " + this.cpuid);
				bool flag = (Operators.CompareString(this.cpuid, "Intel(R) Core(TM) i7-4770K CPU @ 3.90GHz", false) == 0) | (Operators.CompareString(this.cpuid, "AMD Ryzen 7 1700X Eight-Core Processor", false) == 0);
				if (flag)
				{
					this.AddToListboxAndScroll("Spoofing CPU ID not needed, already set or equal");
					Log.WriteToLog("Spoofing CPU ID not needed, already set or equal");
					bool flag2 = !GetConfig.IsReading;
					if (flag2)
					{
						Interaction.MsgBox("Spoofing CPU ID not needed, already set or equal", MsgBoxStyle.Information, "Spoof CPU");
					}
				}
				else
				{
					bool flag3 = Operators.CompareString(MySettingsProperty.Settings.OldCPUID, "", false) == 0;
					if (flag3)
					{
						MySettingsProperty.Settings.OldCPUID = this.cpuid;
						MySettingsProperty.Settings.Save();
						Log.WriteToLog("Saved Current CPU ID");
					}
					bool flag4 = this.cpuid.StartsWith("AMD");
					if (flag4)
					{
						this.ChangeCPUID("AMD Ryzen 7 1700X Eight-Core Processor");
					}
					else
					{
						this.ChangeCPUID("Intel(R) Core(TM) i7-4770K CPU @ 3.90GHz");
					}
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting GetCPUid");
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Could not retrieve CPU ID: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00037514 File Offset: 0x00035714
		private void ChangeCPUID(string model)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering ChangeCPUID");
			}
			try
			{
				bool flag = Operators.CompareString(MySettingsProperty.Settings.OldCPUID, "", false) != 0;
				if (flag)
				{
					RegistryKey registryKey = MyProject.Computer.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", true);
					registryKey.SetValue("ProcessorNameString", model);
					Log.WriteToLog("New CPU ID: " + model);
					this.AddToListboxAndScroll("New CPU ID: " + model);
					this.StopOVR();
					this.StartOVR();
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting ChangeCPUID");
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("* Could not change CPU ID: " + ex.Message);
				this.AddToListboxAndScroll("* Could not change CPU ID: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00037640 File Offset: 0x00035840
		private void RestoreCPUID()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering RestoreCPUID");
			}
			try
			{
				bool flag = Operators.CompareString(MySettingsProperty.Settings.OldCPUID, "", false) != 0;
				if (flag)
				{
					RegistryKey registryKey = MyProject.Computer.Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", true);
					registryKey.SetValue("ProcessorNameString", MySettingsProperty.Settings.OldCPUID);
					Log.WriteToLog("CPU ID restored to: " + MySettingsProperty.Settings.OldCPUID);
					this.AddToListboxAndScroll("CPU ID restored to: " + MySettingsProperty.Settings.OldCPUID);
					MySettingsProperty.Settings.OldCPUID = "";
				}
				else
				{
					this.AddToListboxAndScroll("No old ID to restore");
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting RestoreCPUID");
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Could not restore CPU ID: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00037780 File Offset: 0x00035980
		internal string SplitToolTip(string strOrig)
		{
			string text = " ";
			string text2 = "\r\n";
			string[] array = strOrig.Split(new char[] { Conversions.ToChar(text) });
			string text4;
			string text5;
			foreach (string text3 in array)
			{
				text4 = text4 + text3 + text;
				bool flag = Strings.Len(text4) > 70;
				if (flag)
				{
					text5 = text5 + text4 + text2;
					text4 = "";
				}
			}
			bool flag2 = Strings.Len(text4) < 8;
			if (flag2)
			{
				text5 = text5.Substring(0, checked(text5.Length - 2));
			}
			return text5 + text4;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00037838 File Offset: 0x00035A38
		private void ToolStripStartOVR_Click(object sender, EventArgs e)
		{
			this.StartOVR();
			bool @checked = this.CheckLaunchHome.Checked;
			if (@checked)
			{
				ServiceController serviceController = new ServiceController("OVRService");
				bool flag = serviceController.Status == ServiceControllerStatus.Running;
				if (flag)
				{
					RunCommand.StartHome();
				}
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00034582 File Offset: 0x00032782
		private void ToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			this.StopOVR();
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0003787E File Offset: 0x00035A7E
		private void ToolStripMenuItem6_Click(object sender, EventArgs e)
		{
			this.StopOVR();
			this.StartOVR();
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0003788F File Offset: 0x00035A8F
		private void ToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			PowerPlans.CheckPowerState(true);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00037899 File Offset: 0x00035A99
		private void NotificationTimer_Tick(object sender, EventArgs e)
		{
			this.NotificationTimer.Stop();
			MyProject.Forms.frmLoading.CloseStartupToast();
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x000378B8 File Offset: 0x00035AB8
		private void CheckMinimizeOnX_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					GetConfig.IsReading = true;
					bool @checked = this.CheckMinimizeOnX.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00037984 File Offset: 0x00035B84
		private void BtnLibrary_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			MyProject.Forms.frmLibrary.Location = MySettingsProperty.Settings.LibraryWindowLocation;
			MyProject.Forms.frmLibrary.Size = MySettingsProperty.Settings.LibraryWindowSize;
			MyProject.Forms.frmLibrary.Show();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000379F0 File Offset: 0x00035BF0
		private void BtnProfiles_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmProfiles.Location = MySettingsProperty.Settings.ProfilesWindowLocation;
			MyProject.Forms.frmProfiles.Size = MySettingsProperty.Settings.ProfilesWindowSize;
			MyProject.Forms.frmProfiles.Show();
			MyProject.Forms.frmProfiles.ListView1.Sorting = SortOrder.Ascending;
			MyProject.Forms.frmProfiles.ListView1.Focus();
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00037A6D File Offset: 0x00035C6D
		private void BtnVoice_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmVoiceSettings.Size = MySettingsProperty.Settings.VoiceDialogSize;
			MyProject.Forms.frmVoiceSettings.ShowDialog();
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00037A9C File Offset: 0x00035C9C
		private void TrackBar1_Scroll(object sender, EventArgs e)
		{
			this.Label14.Text = "Font Size: " + Conversions.ToString(this.TrackBar1.Value);
			this.rs.ResizeAllControls(this, (float)this.TrackBar1.Value);
			MySettingsProperty.Settings.FontSize = (float)this.TrackBar1.Value;
			MySettingsProperty.Settings.Save();
			MyProject.Forms.frmProfiles.ListView1.Font = new Font(MyProject.Forms.frmProfiles.ListView1.Font.Name, MySettingsProperty.Settings.FontSize, FontStyle.Regular);
			MyProject.Forms.frmProfiles.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00037B5F File Offset: 0x00035D5F
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmDonate.ShowDialog();
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00037B74 File Offset: 0x00035D74
		private void ComboSSstart_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.PPDPStartup = this.ComboSSstart.Text;
				MySettingsProperty.Settings.Save();
				GetConfig.ppdpstartup = this.ComboSSstart.Text;
				Thread thread = new Thread((FrmMain._Closure$__.$I163-0 == null) ? (FrmMain._Closure$__.$I163-0 = delegate
				{
					RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
				}) : FrmMain._Closure$__.$I163-0);
				thread.Start();
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00037BF4 File Offset: 0x00035DF4
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool flag2 = Operators.CompareString(this.ComboBox1.Text, "Auto", false) == 0;
				if (flag2)
				{
					MySettingsProperty.Settings.ASW = 0;
					Thread thread = new Thread((FrmMain._Closure$__.$I164-0 == null) ? (FrmMain._Closure$__.$I164-0 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Auto");
					}) : FrmMain._Closure$__.$I164-0);
					thread.Start();
					this.AddToListboxAndScroll("ASW set to Auto");
				}
				bool flag3 = Operators.CompareString(this.ComboBox1.Text, "Off", false) == 0;
				if (flag3)
				{
					MySettingsProperty.Settings.ASW = 1;
					Thread thread2 = new Thread((FrmMain._Closure$__.$I164-1 == null) ? (FrmMain._Closure$__.$I164-1 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Off");
					}) : FrmMain._Closure$__.$I164-1);
					thread2.Start();
					this.AddToListboxAndScroll("ASW set to Off");
				}
				bool flag4 = Operators.CompareString(this.ComboBox1.Text, "45 Hz", false) == 0;
				if (flag4)
				{
					MySettingsProperty.Settings.ASW = 2;
					Thread thread3 = new Thread((FrmMain._Closure$__.$I164-2 == null) ? (FrmMain._Closure$__.$I164-2 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock45");
					}) : FrmMain._Closure$__.$I164-2);
					thread3.Start();
					this.AddToListboxAndScroll("Framerate @ 45 Hz");
				}
				bool flag5 = Operators.CompareString(this.ComboBox1.Text, "30 Hz", false) == 0;
				if (flag5)
				{
					MySettingsProperty.Settings.ASW = 3;
					Thread thread4 = new Thread((FrmMain._Closure$__.$I164-3 == null) ? (FrmMain._Closure$__.$I164-3 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock30");
					}) : FrmMain._Closure$__.$I164-3);
					thread4.Start();
					this.AddToListboxAndScroll("Framerate @ 30 Hz");
				}
				bool flag6 = Operators.CompareString(this.ComboBox1.Text, "18 Hz", false) == 0;
				if (flag6)
				{
					MySettingsProperty.Settings.ASW = 4;
					Thread thread5 = new Thread((FrmMain._Closure$__.$I164-4 == null) ? (FrmMain._Closure$__.$I164-4 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Clock18");
					}) : FrmMain._Closure$__.$I164-4);
					thread5.Start();
					this.AddToListboxAndScroll("Framerate @ 18 Hz");
				}
				bool flag7 = Operators.CompareString(this.ComboBox1.Text, "45 Hz forced", false) == 0;
				if (flag7)
				{
					MySettingsProperty.Settings.ASW = 5;
					Thread thread6 = new Thread((FrmMain._Closure$__.$I164-5 == null) ? (FrmMain._Closure$__.$I164-5 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Sim45");
					}) : FrmMain._Closure$__.$I164-5);
					thread6.Start();
					this.AddToListboxAndScroll("Framerate forced to 45 Hz");
				}
				bool flag8 = Operators.CompareString(this.ComboBox1.Text, "Adaptive", false) == 0;
				if (flag8)
				{
					MySettingsProperty.Settings.ASW = 6;
					Thread thread7 = new Thread((FrmMain._Closure$__.$I164-6 == null) ? (FrmMain._Closure$__.$I164-6 = delegate
					{
						RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
					}) : FrmMain._Closure$__.$I164-6);
					thread7.Start();
					this.AddToListboxAndScroll("Framerate set to Adaptive");
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00037F0C File Offset: 0x0003610C
		private void ComboVoice_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool flag2 = Operators.CompareString(this.ComboVoice.Text, "Enabled", false) == 0;
				if (flag2)
				{
					MySettingsProperty.Settings.UseVoiceCommands = true;
					MySettingsProperty.Settings.Save();
					this.EnableDisableVoice(true);
				}
				else
				{
					MySettingsProperty.Settings.UseVoiceCommands = false;
					MySettingsProperty.Settings.Save();
					this.EnableDisableVoice(false);
				}
			}
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00037F88 File Offset: 0x00036188
		public void EnableDisableVoice(bool enable)
		{
			if (enable)
			{
				this.ComboVoice.Text = "Enabled";
				this.AddToListboxAndScroll("Enabling Voice commands");
				Log.WriteToLog("Enabling Voice commands");
				GetConfig.useVoiceCommands = true;
				this.BtnVoice.Enabled = true;
				VoiceCommands.StartStopBuilder();
				bool homeIsRunning = this.HomeIsRunning;
				if (homeIsRunning)
				{
					bool flag = MySettingsProperty.Settings.JoystickActivationKeyContinous | MySettingsProperty.Settings.JoystickActivationKeyPush;
					if (flag)
					{
						bool flag2 = Operators.CompareString(MySettingsProperty.Settings.JoystickVoiceActivationButton, "", false) != 0;
						if (flag2)
						{
							Thread thread = new Thread((FrmMain._Closure$__.$I166-0 == null) ? (FrmMain._Closure$__.$I166-0 = delegate
							{
								GetControllers.CaptureButtonPushToTalk();
							}) : FrmMain._Closure$__.$I166-0);
							thread.Start();
						}
					}
					CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.Name);
					VoiceCommands.sRecognize = new SpeechRecognitionEngine(cultureInfo);
					VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
					VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
					VoiceCommands.buildGrammars();
					this.AddToListboxAndScroll("Ready to accept voice commands");
				}
			}
			else
			{
				this.ComboVoice.Text = "Disabled";
				Log.WriteToLog("Disabling Voice commands..");
				this.AddToListboxAndScroll("Disabling Voice commands..");
				GetConfig.useVoiceCommands = false;
				this.BtnVoice.Enabled = false;
				bool isListening = VoiceCommands.isListening;
				if (isListening)
				{
					VoiceCommands.StopListening();
				}
				bool grammarsBuilt = VoiceCommands.grammarsBuilt;
				if (grammarsBuilt)
				{
					VoiceCommands.DisableVoice();
				}
				bool joyAquired = GetControllers.joyAquired;
				if (joyAquired)
				{
					GetControllers.joy.Unacquire();
					GetControllers.joyAquired = false;
				}
				Log.WriteToLog("Voice commands Disabled");
				this.AddToListboxAndScroll("Voice commands Disabled");
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0003814C File Offset: 0x0003634C
		private void HotKeysCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.HotKeysCheckBox.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.UseHotKeys = true;
					GetConfig.UseHotKeys = true;
					this.BtnConfigureHotKeys.Enabled = true;
					this.kbHook = new KeyboardHook();
				}
				else
				{
					MySettingsProperty.Settings.UseHotKeys = false;
					GetConfig.UseHotKeys = false;
					this.BtnConfigureHotKeys.Enabled = false;
					this.kbHook = null;
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x000381DC File Offset: 0x000363DC
		private void ComboPowerPlan_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					MySettingsProperty.Settings.PowerPlanStart = this.ComboPowerPlanStart.Text;
					MySettingsProperty.Settings.Save();
					bool flag2 = Operators.CompareString(this.ComboPowerPlanStart.Text, "Not Used", false) != 0;
					if (flag2)
					{
						bool flag3 = MySettingsProperty.Settings.ApplyPowerPlan == 0;
						if (flag3)
						{
							PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
							PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
						}
						this.PowerPlanTimer.Start();
					}
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x000382D8 File Offset: 0x000364D8
		private void ComboUSBsusp_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool flag2 = this.ComboUSBsusp.SelectedIndex == 0;
					if (flag2)
					{
						Log.WriteToLog("Disabling USB Selective Suspend");
						PowerPlans.GetSetUsbSuspend(PowerPlans.filter, true);
						MySettingsProperty.Settings.USBSuspend = 0;
					}
					else
					{
						Log.WriteToLog("Enabling USB Selective Suspend");
						PowerPlans.GetSetUsbSuspend(PowerPlans.filter, true);
						MySettingsProperty.Settings.USBSuspend = 1;
					}
					MySettingsProperty.Settings.Save();
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x000383BC File Offset: 0x000365BC
		public void ChangeCPUPrioOVR(string prio)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("OVRServer_x64");
				foreach (Process process in processesByName)
				{
					if (Operators.CompareString(prio, "Normal", false) != 0)
					{
						if (Operators.CompareString(prio, "Above normal", false) != 0)
						{
							if (Operators.CompareString(prio, "High", false) != 0)
							{
								if (Operators.CompareString(prio, "Realtime", false) == 0)
								{
									process.PriorityClass = ProcessPriorityClass.RealTime;
									bool flag = process.PriorityClass == ProcessPriorityClass.RealTime;
									if (flag)
									{
										Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
										this.AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
									}
								}
							}
							else
							{
								process.PriorityClass = ProcessPriorityClass.High;
								bool flag2 = process.PriorityClass == ProcessPriorityClass.High;
								if (flag2)
								{
									Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
									this.AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
								}
							}
						}
						else
						{
							process.PriorityClass = ProcessPriorityClass.AboveNormal;
							bool flag3 = process.PriorityClass == ProcessPriorityClass.AboveNormal;
							if (flag3)
							{
								Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
								this.AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
							}
						}
					}
					else
					{
						process.PriorityClass = ProcessPriorityClass.Normal;
						bool flag4 = process.PriorityClass == ProcessPriorityClass.Normal;
						if (flag4)
						{
							Log.WriteToLog("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
							this.AddToListboxAndScroll("CPU Priority of 'OVRServer_x64' set to '" + prio + "'");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ChangeCPUPrioOVR(): " + ex.Message);
			}
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x000385D0 File Offset: 0x000367D0
		public void ChangeCPUPrioDash(string prio)
		{
			try
			{
				Log.WriteToLog("Sleeping 5s before changing CPU Priority of OculusDash to " + prio);
				Thread.Sleep(5000);
				Process[] processesByName = Process.GetProcessesByName("OculusDash");
				foreach (Process process in processesByName)
				{
					if (Operators.CompareString(prio, "Normal", false) != 0)
					{
						if (Operators.CompareString(prio, "Above normal", false) != 0)
						{
							if (Operators.CompareString(prio, "High", false) != 0)
							{
								if (Operators.CompareString(prio, "Realtime", false) == 0)
								{
									process.PriorityClass = ProcessPriorityClass.RealTime;
									bool flag = process.PriorityClass == ProcessPriorityClass.RealTime;
									if (flag)
									{
										Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
										this.AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
									}
								}
							}
							else
							{
								process.PriorityClass = ProcessPriorityClass.High;
								bool flag2 = process.PriorityClass == ProcessPriorityClass.High;
								if (flag2)
								{
									Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
									this.AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
								}
							}
						}
						else
						{
							process.PriorityClass = ProcessPriorityClass.AboveNormal;
							bool flag3 = process.PriorityClass == ProcessPriorityClass.AboveNormal;
							if (flag3)
							{
								Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
								this.AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
							}
						}
					}
					else
					{
						process.PriorityClass = ProcessPriorityClass.Normal;
						bool flag4 = process.PriorityClass == ProcessPriorityClass.Normal;
						if (flag4)
						{
							Log.WriteToLog("CPU Priority of 'OculusDash' set to '" + prio + "'");
							this.AddToListboxAndScroll("CPU Priority of 'OculusDash' set to '" + prio + "'");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ChangeCPUPrioDash(): " + ex.Message);
			}
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00038800 File Offset: 0x00036A00
		private void HometoTrayTimer_Tick(object sender, EventArgs e)
		{
			HomeToTray.SendHomeToTrayOnMinimize();
			bool homeIsMinimized = HomeToTray.HomeIsMinimized;
			if (homeIsMinimized)
			{
				this.EnableShowHomeMenu();
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00038828 File Offset: 0x00036A28
		private void CheckSendHomeToTray_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckSendHomeToTray.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.SendHomeToTray = true;
					bool homeIsRunning = this.HomeIsRunning;
					if (homeIsRunning)
					{
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog("Home is running, HomeToTray enabled, Timer started");
						}
						this.HometoTrayTimer.Enabled = true;
						MySettingsProperty.Settings.Save();
					}
				}
				else
				{
					try
					{
						HomeToTray.ShowHomeNormal();
						this.DisableShowHomeMenu();
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Restore Home: " + ex.Message);
					}
					MySettingsProperty.Settings.SendHomeToTray = false;
					this.HometoTrayTimer.Enabled = false;
					MySettingsProperty.Settings.ShowHomeToast = true;
					MySettingsProperty.Settings.Save();
				}
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00038918 File Offset: 0x00036B18
		private void CheckSendHomeToTrayOnStart_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckSendHomeToTrayOnStart.Checked;
				if (@checked)
				{
					this.StartMinimizeHomeWatcher();
					MySettingsProperty.Settings.SendHomeToTrayOnStart = true;
					MySettingsProperty.Settings.Save();
					bool homeIsRunning = this.HomeIsRunning;
					if (homeIsRunning)
					{
						HomeToTray.SendHomeToTrayOnStart();
						bool flag2 = MySettingsProperty.Settings.ShowHomeToast & !HomeToTray.ToastShown;
						if (flag2)
						{
							HomeToTray.ToastShown = true;
							Thread thread = new Thread((FrmMain._Closure$__.$I174-0 == null) ? (FrmMain._Closure$__.$I174-0 = delegate
							{
								MyProject.Forms.frmHomeTrayToast.ShowDialog();
							}) : FrmMain._Closure$__.$I174-0);
							thread.Start();
						}
					}
				}
				else
				{
					MySettingsProperty.Settings.SendHomeToTrayOnStart = false;
					MySettingsProperty.Settings.ShowHomeToast = true;
					MySettingsProperty.Settings.Save();
					this.MinimizeHomeWatcher.Stop();
				}
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00038A00 File Offset: 0x00036C00
		private void CheckLocalDebug_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckLocalDebug.Checked;
				if (@checked)
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

		// Token: 0x06000634 RID: 1588 RVA: 0x00038A60 File Offset: 0x00036C60
		private void CheckStartWatcher_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckStartWatcher.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.StartAppwatcherOnStart = true;
					MySettingsProperty.Settings.Save();
					bool oculusServiceFound = this.OculusServiceFound;
					if (oculusServiceFound)
					{
						Log.WriteToLog("Starting AppWatcher");
						this.AddToListboxAndScroll("Starting AppWatcher");
						this.StartWatcherNoHome();
					}
				}
				else
				{
					MySettingsProperty.Settings.StartAppwatcherOnStart = false;
					MySettingsProperty.Settings.Save();
				}
			}
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00038AE8 File Offset: 0x00036CE8
		private void BtnRemoveAllProfiles_Click(object sender, EventArgs e)
		{
			bool flag = Interaction.MsgBox("Really remove all Profiles?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm remove") == MsgBoxResult.Yes;
			if (flag)
			{
				OTTDB.RemoveAllProfiles();
				this.Watcher.Stop();
				bool enabled = this.pTimer.Enabled;
				if (enabled)
				{
					this.pTimer.Stop();
				}
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
				bool flag2 = Directory.Exists(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
				if (flag2)
				{
					GetGames.GetThirdPartyApps(this.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
				}
				bool flag3 = Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0;
				if (flag3)
				{
					foreach (string text in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
					{
						bool flag4 = Directory.Exists(text.TrimEnd(new char[] { '\\' }) + "\\Manifests");
						if (flag4)
						{
							GetGames.GetFiles(text.TrimEnd(new char[] { '\\' }) + "\\Manifests");
						}
						bool flag5 = Directory.Exists(text.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
						if (flag5)
						{
							GetGames.GetThirdPartyApps(text.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
						}
					}
				}
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00038CA0 File Offset: 0x00036EA0
		private void Button1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			Log.WriteToLog("Checking Internet connection..");
			CheckConnection.CheckForInternetConnection();
			bool haveiConnection = CheckConnection.HaveiConnection;
			if (haveiConnection)
			{
				Log.WriteToLog("Internet connection looks good");
				CheckUpdate.CheckForUpdate(true);
			}
			else
			{
				Log.WriteToLog("Internet connection not available, gave up");
				this.AddToListboxAndScroll("No internet connection, cannot check for updates");
			}
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00038D10 File Offset: 0x00036F10
		private void Button5_Click(object sender, EventArgs e)
		{
			bool flag = Interaction.MsgBox("Restart in Debug mode?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm restart") == MsgBoxResult.Yes;
			if (flag)
			{
				MySettingsProperty.Settings.RunDebug = true;
				MySettingsProperty.Settings.Save();
				this.restartInDBG = true;
				this.Shutdown();
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00038D60 File Offset: 0x00036F60
		private void CheckSensorPower_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckSensorPower.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00038E14 File Offset: 0x00037014
		private void Button4_Click(object sender, EventArgs e)
		{
			bool flag = Interaction.MsgBox("Reset all Oculus Tray Tool settings to default and restart application?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm reset") == MsgBoxResult.Yes;
			if (flag)
			{
				MySettingsProperty.Settings.Reset();
				MySettingsProperty.Settings.Save();
				this.restartInDBG = true;
				this.Shutdown();
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00038E60 File Offset: 0x00037060
		private void ComboPowerPlanExit_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					MySettingsProperty.Settings.PowerPlanExit = this.ComboPowerPlanExit.Text;
					MySettingsProperty.Settings.Save();
				}
			}
			catch (Exception ex)
			{
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00038F00 File Offset: 0x00037100
		private void BtnConfigureAudio_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			MyProject.Forms.FrmSetFallback.ShowDialog(this);
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00038F20 File Offset: 0x00037120
		private void ComboApplyPlan_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.ApplyPowerPlan = this.ComboApplyPlan.SelectedIndex;
				MySettingsProperty.Settings.Save();
				bool flag2 = this.ComboApplyPlan.SelectedIndex == 0;
				if (flag2)
				{
					PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
					PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
				}
			}
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00038F8D File Offset: 0x0003718D
		private void Button8_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.LabelDownloadStatus.Text = "Downloading..";
			this.LabelDownloadStatus.Refresh();
			CheckUpdate.DownloadUpdate(CheckUpdate.link, true, "");
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00038FCC File Offset: 0x000371CC
		private void Button9_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.Cursor = Cursors.WaitCursor;
				this.LabelDownloadStatus.Text = "Downloading..";
				this.LabelDownloadStatus.Refresh();
				CheckUpdate.DownloadUpdate(CheckUpdate.link, false, folderBrowserDialog.SelectedPath);
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0003902C File Offset: 0x0003722C
		public void AddToListboxAndScroll(string text)
		{
			bool invokeRequired = base.InvokeRequired;
			checked
			{
				if (invokeRequired)
				{
					FrmMain.AddToListboxAndScrollDelegate addToListboxAndScrollDelegate = new FrmMain.AddToListboxAndScrollDelegate(this.AddToListboxAndScroll);
					base.Invoke(addToListboxAndScrollDelegate, new object[] { text });
				}
				else
				{
					this.ListBox1.Items.Add(DateAndTime.TimeOfDay.ToString("HH:mm:ss ") + text);
					this.ListBox1.TopIndex = this.ListBox1.Items.Count - 1;
					ref int ptr = ref this.numLogMessages;
					this.numLogMessages = ptr + 1;
					this.DotNetBarTabcontrol1.TabPages[4].Text = "Log Window (" + Conversions.ToString(this.numLogMessages) + ")";
				}
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x000390F0 File Offset: 0x000372F0
		public void UpdateTabPage()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new FrmMain.UpdateTabDelegate(this.UpdateTabPage));
			}
			else
			{
				this.DotNetBarTabcontrol1.Controls.Add((Control)this.colRemovedTabs["TabPage6"]);
				this.DotNetBarTabcontrol1.TabPages[7].ImageIndex = 6;
				this.colRemovedTabs.Remove("TabPage6");
				bool flag = base.WindowState == FormWindowState.Minimized;
				if (flag)
				{
					this.DotNetBarTabcontrol1.SelectedIndex = 7;
				}
			}
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0003918C File Offset: 0x0003738C
		public void ShowUpdateToast()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new FrmMain.ShowUpdateToastDelegate(this.ShowUpdateToast));
			}
			else
			{
				MyProject.Forms.frmUpdateToast.Show();
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x000391CC File Offset: 0x000373CC
		public void EnableShowHomeMenu()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new FrmMain.EnableShowHomeMenuDelegate(this.EnableShowHomeMenu));
			}
			else
			{
				this.ToolStripMenuShowHome.Enabled = true;
			}
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0003920C File Offset: 0x0003740C
		public void DisableShowHomeMenu()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new FrmMain.DisableShowHomeMenuDelegate(this.DisableShowHomeMenu));
			}
			else
			{
				this.ToolStripMenuShowHome.Enabled = false;
				this.NotifyIcon3.Visible = false;
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00039258 File Offset: 0x00037458
		public void SetTitleIsListening()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new FrmMain.SetTitleIsListeningDelegate(this.SetTitleIsListening));
			}
			else
			{
				this.Text = "Oculus Tray Tool " + Application.ProductVersion.Substring(0, 8) + " - Listening to Voice Commands";
			}
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x000392AC File Offset: 0x000374AC
		public void RemoveTitleIsListening()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new FrmMain.RemoveTitleIsListeningDelegate(this.RemoveTitleIsListening));
			}
			else
			{
				this.Text = "Oculus Tray Tool " + Application.ProductVersion.Substring(0, 8);
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000392FC File Offset: 0x000374FC
		public void SetToolTipText(string text, Control crtl)
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				FrmMain.SetToolTipDelegate setToolTipDelegate = new FrmMain.SetToolTipDelegate(this.SetToolTipText);
				base.Invoke(setToolTipDelegate, new object[] { text, crtl });
			}
			else
			{
				this.ToolTip.SetToolTip(crtl, text);
			}
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0003934A File Offset: 0x0003754A
		private void PictureBox2_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmAbout.StartPosition = FormStartPosition.CenterParent;
			MyProject.Forms.frmAbout.ShowDialog(this);
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00039370 File Offset: 0x00037570
		private void CheckBoxCheckForUpdates_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBoxCheckForUpdates.Checked;
				if (@checked)
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

		// Token: 0x06000649 RID: 1609 RVA: 0x000393C4 File Offset: 0x000375C4
		private void FlashBackground(Control control, Color c)
		{
			Color backColor = control.BackColor;
			control.BackColor = c;
			control.Update();
			Thread.Sleep(200);
			control.BackColor = backColor;
			control.Update();
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00039408 File Offset: 0x00037608
		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				MySettingsProperty.Settings.FOVh = Conversions.ToString(this.NumericFOVh.Value);
				MySettingsProperty.Settings.FOVv = Conversions.ToString(this.NumericFOVv.Value);
				MySettingsProperty.Settings.Save();
				Thread thread = new Thread((FrmMain._Closure$__.$I206-0 == null) ? (FrmMain._Closure$__.$I206-0 = delegate
				{
					RunCommand.Run_debug_tool_fov(MySettingsProperty.Settings.FOVh.ToString() + " " + MySettingsProperty.Settings.FOVv.ToString());
				}) : FrmMain._Closure$__.$I206-0);
				thread.Start();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x000394AC File Offset: 0x000376AC
		private void BtnHomless_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmHomeless.ShowDialog(this);
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x000394C0 File Offset: 0x000376C0
		private void ComboHomless_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool flag2 = this.ComboHomless.SelectedIndex == 1;
				if (flag2)
				{
					bool flag3 = MessageBox.Show(this, "NOTE: Please make sure you have not already replaced the original 'Home2-Win64-Shipping.exe' binary. If you have done so please consult the User Guide for more info before proceeding. Proceed with installation?", "Oculus Homeless", MessageBoxButtons.YesNo) == DialogResult.Yes;
					if (flag3)
					{
						this.Cursor = Cursors.WaitCursor;
						bool flag4 = false;
						bool homeIsRunning = this.HomeIsRunning;
						if (homeIsRunning)
						{
							flag4 = true;
							bool flag5 = MessageBox.Show(this, "The Oculus service needs to be stopped. Proceed with installation?", "Oculus Homeless", MessageBoxButtons.YesNo) == DialogResult.Yes;
							if (!flag5)
							{
								this.Cursor = Cursors.Default;
								this.ComboHomless.Text = "Disabled";
								return;
							}
							this.StopOVR();
							Thread.Sleep(1000);
						}
						this.InstallHomeless();
						bool flag6 = flag4;
						if (flag6)
						{
							this.StartOVR();
						}
						this.BtnHomless.Enabled = true;
						this.Cursor = Cursors.Default;
					}
				}
				else
				{
					this.Cursor = Cursors.WaitCursor;
					bool flag7 = false;
					bool homeIsRunning2 = this.HomeIsRunning;
					if (homeIsRunning2)
					{
						flag7 = true;
						bool flag8 = MessageBox.Show(this, "The Oculus service needs to be stopped. Proceed with uninstallation?", "Oculus Homeless", MessageBoxButtons.YesNo) == DialogResult.Yes;
						if (!flag8)
						{
							this.Cursor = Cursors.Default;
							this.ComboHomless.Text = "Enabled";
							return;
						}
						this.StopOVR();
						Thread.Sleep(1000);
					}
					this.UninstallHomeless();
					bool flag9 = flag7;
					if (flag9)
					{
						this.StartOVR();
					}
					this.BtnHomless.Enabled = false;
					this.Cursor = Cursors.Default;
				}
			}
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0003965C File Offset: 0x0003785C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void InstallHomeless()
		{
			Log.WriteToLog("Installing Oculus Homeless");
			Log.WriteToLog("Generating SHA256 hash of Oculus Homeless binary: " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe");
			try
			{
				string text = Conversions.ToString(this.GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe"));
				MySettingsProperty.Settings.HomelessHash = text;
				MySettingsProperty.Settings.Save();
			}
			catch (Exception ex)
			{
				this.ComboHomless.Text = "Disabled";
				Interaction.MsgBox("Could not generate hash of " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe\r\n\r\n" + ex.Message, MsgBoxStyle.Exclamation, null);
				Log.WriteToLog("Could not generate hash of " + Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe: " + ex.Message);
				return;
			}
			Log.WriteToLog("Generating SHA256 hash of original binary: " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
			try
			{
				string text2 = Conversions.ToString(this.GenerateSHA256Hash(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"));
				MySettingsProperty.Settings.HomeHash = text2;
				MySettingsProperty.Settings.Save();
			}
			catch (Exception ex2)
			{
				this.ComboHomless.Text = "Disabled";
				Interaction.MsgBox("Could not generate hash of " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex2.Message, MsgBoxStyle.Exclamation, null);
				Log.WriteToLog("Could not generate hash of " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex2.Message);
				return;
			}
			Log.WriteToLog("Backing up original Home2-Win64-Shipping.exe from " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64");
			bool flag = !Directory.Exists(Application.StartupPath + "\\Homeless\\Backup");
			if (flag)
			{
				Directory.CreateDirectory(Application.StartupPath + "\\Homeless\\Backup");
			}
			try
			{
				File.Copy(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe", Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe", true);
			}
			catch (Exception ex3)
			{
				this.ComboHomless.Text = "Disabled";
				Interaction.MsgBox("Could not create backup copy of " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex3.Message, MsgBoxStyle.Exclamation, null);
				Log.WriteToLog("Could not create backup copy of " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex3.Message);
				return;
			}
			bool flag2 = File.Exists(Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe");
			if (flag2)
			{
				Log.WriteToLog("Backup successful, renaming original file");
				try
				{
					bool flag3 = File.Exists(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG");
					if (flag3)
					{
						File.Delete(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG");
					}
					FileSystem.Rename(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe", this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG");
				}
				catch (Exception ex4)
				{
					this.ComboHomless.Text = "Disabled";
					Interaction.MsgBox("Could not rename " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n" + ex4.Message, MsgBoxStyle.Exclamation, null);
					Log.WriteToLog("Could not rename " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: " + ex4.Message);
					return;
				}
				Log.WriteToLog("Copying new file");
				try
				{
					File.Copy(Application.StartupPath + "\\Homeless\\Home2-Win64-Shipping.exe", this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				}
				catch (Exception ex5)
				{
					this.ComboHomless.Text = "Disabled";
					Interaction.MsgBox(string.Concat(new string[]
					{
						"Could not copy ",
						Application.StartupPath,
						"\\Homeless\\Home2-Win64-Shipping.exe to ",
						this.OculusPath,
						"Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe\r\n\r\n",
						ex5.Message
					}), MsgBoxStyle.Exclamation, null);
					Log.WriteToLog(string.Concat(new string[]
					{
						"Could not copy ",
						Application.StartupPath,
						"\\Homeless\\Home2-Win64-Shipping.exe to ",
						this.OculusPath,
						"Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe: ",
						ex5.Message
					}));
					return;
				}
				try
				{
					bool flag4 = !Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
					if (flag4)
					{
						Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
						Log.WriteToLog("Created " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
						string[] files = Directory.GetFiles(Application.StartupPath + "\\Homeless\\Music", "*.mp3");
						foreach (string text3 in files)
						{
							File.Copy(text3, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + Path.GetFileName(text3));
							Log.WriteToLog(string.Concat(new string[]
							{
								"Copied ",
								text3,
								" to ",
								Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
								"\\OculusTrayTool\\Music"
							}));
						}
						string[] files2 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
						MyProject.Forms.frmHomeless.ComboMusic.DropDownStyle = ComboBoxStyle.DropDown;
						foreach (string text4 in files2)
						{
							MyProject.Forms.frmHomeless.ComboMusic.Items.Add(Path.GetFileName(text4));
						}
						MyProject.Forms.frmHomeless.ComboMusic.DropDownStyle = ComboBoxStyle.DropDownList;
					}
				}
				catch (Exception ex6)
				{
					this.ComboHomless.Text = "Disabled";
					Interaction.MsgBox("Could not copy music to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\\r\n\r\n" + ex6.Message, MsgBoxStyle.Exclamation, null);
					Log.WriteToLog("Could not copy music to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\: " + ex6.Message);
					return;
				}
				Log.WriteToLog("Installation complete");
				MySettingsProperty.Settings.HomelessEnabled = this.ComboHomless.SelectedIndex;
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00039D50 File Offset: 0x00037F50
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void UninstallHomeless()
		{
			Log.WriteToLog("Uninstalling Oculus Homeless");
			try
			{
				bool flag = File.Exists(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG");
				if (flag)
				{
					string text = Conversions.ToString(this.GenerateSHA256Hash(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG"));
					bool flag2 = Operators.CompareString(text, MySettingsProperty.Settings.HomeHash, false) == 0;
					if (!flag2)
					{
						this.ComboHomless.Text = "Enabled";
						Log.WriteToLog("Hash values do not match!");
						Interaction.MsgBox("Stored hash value of " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG does not match actual value, aborting. Recommend manual rename.", MsgBoxStyle.OkOnly, null);
						return;
					}
					Log.WriteToLog(string.Concat(new string[] { "Hash values match, renaming ", this.OculusPath, "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG to ", this.OculusPath, "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe" }));
					bool flag3 = File.Exists(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
					if (flag3)
					{
						File.Delete(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
					}
					FileSystem.Rename(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG", this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				}
				else
				{
					Log.WriteToLog(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG was not found, using seconday backup");
					string text2 = Conversions.ToString(this.GenerateSHA256Hash(Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe"));
					bool flag4 = Operators.CompareString(text2, MySettingsProperty.Settings.HomeHash, false) == 0;
					if (!flag4)
					{
						this.ComboHomless.Text = "Enabled";
						Log.WriteToLog("Hash values do not match!");
						Interaction.MsgBox("Stored hash value of " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG does not match actual value, aborting. Recommend manual rename.", MsgBoxStyle.OkOnly, null);
						return;
					}
					Log.WriteToLog(string.Concat(new string[]
					{
						"Hash values match, copying ",
						Application.StartupPath,
						"\\Homeless\\Backup\\Home2-Win64-Shipping.exe to ",
						this.OculusPath,
						"Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe"
					}));
					bool flag5 = File.Exists(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
					if (flag5)
					{
						File.Delete(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
					}
					File.Copy(Application.StartupPath + "\\Homeless\\Backup\\Home2-Win64-Shipping.exe", this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				}
				try
				{
					bool flag6 = File.Exists(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
					if (flag6)
					{
						File.Delete(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
					}
					bool flag7 = File.Exists(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
					if (flag7)
					{
						File.Delete(this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
					}
				}
				catch (Exception ex)
				{
					this.ComboHomless.Text = "Enabled";
					Log.WriteToLog("UninstallHomeless: " + ex.Message);
				}
				Log.WriteToLog("Uninstall complete");
				MySettingsProperty.Settings.HomelessEnabled = this.ComboHomless.SelectedIndex;
				MySettingsProperty.Settings.Save();
			}
			catch (Exception ex2)
			{
				this.ComboHomless.Text = "Enabled";
				Interaction.MsgBox("Could not rename " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG\r\n\r\n" + ex2.Message, MsgBoxStyle.Exclamation, null);
				Log.WriteToLog("Could not rename " + this.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe_ORG: " + ex2.Message);
			}
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0003A12C File Offset: 0x0003832C
		private object GenerateSHA256Hash(string filename)
		{
			object obj;
			using (FileStream fileStream = File.OpenRead(filename))
			{
				SHA256Managed sha256Managed = new SHA256Managed();
				byte[] array = sha256Managed.ComputeHash(fileStream);
				obj = BitConverter.ToString(array).Replace("-", string.Empty).ToLower();
			}
			return obj;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0003A18C File Offset: 0x0003838C
		private void UpdateTimer_Tick(object sender, EventArgs e)
		{
			this.UpdateTimer.Stop();
			Log.WriteToLog("Checking Internet connection..");
			CheckConnection.CheckForInternetConnection();
			bool haveiConnection = CheckConnection.HaveiConnection;
			if (haveiConnection)
			{
				Log.WriteToLog("Internet connection looks good");
				Thread thread = new Thread((FrmMain._Closure$__.$I212-0 == null) ? (FrmMain._Closure$__.$I212-0 = delegate
				{
					CheckUpdate.CheckForUpdate(false);
				}) : FrmMain._Closure$__.$I212-0);
				thread.Start();
			}
			else
			{
				Log.WriteToLog("Internet connection not available");
				this.AddToListboxAndScroll("No internet connection, cannot check for updates");
			}
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0003A218 File Offset: 0x00038418
		private void ToolStripMenuShowHome_Click(object sender, EventArgs e)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Calling ShowHomeNormal");
			}
			try
			{
				HomeToTray.ShowHomeNormal();
				this.DisableShowHomeMenu();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Restore Home: " + ex.Message);
			}
			bool sendHomeToTray = MySettingsProperty.Settings.SendHomeToTray;
			if (sendHomeToTray)
			{
				this.HometoTrayTimer.Enabled = true;
			}
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0003A2A0 File Offset: 0x000384A0
		private void ComboMirrorHome_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool flag2 = this.ComboMirrorHome.SelectedIndex == 0;
				if (flag2)
				{
					MySettingsProperty.Settings.MirrorHome = true;
					bool homeIsRunning = this.HomeIsRunning;
					if (homeIsRunning)
					{
						Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
						bool flag3 = processesByName.Length > 0;
						if (flag3)
						{
							Log.WriteToLog("Starting Oculus Mirror");
							try
							{
								Process.Start(this.OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe");
								this.HomeIsMirrored = true;
							}
							catch (Exception ex)
							{
								Log.WriteToLog("Could not launch " + this.OculusPath + "Support\\oculus-diagnostics\\OculusMirror.exe: " + ex.Message);
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
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0003A3A0 File Offset: 0x000385A0
		private void ComboVisualHUD_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool flag2 = this.ComboVisualHUD.SelectedIndex == 0;
				if (flag2)
				{
					this.AddToListboxAndScroll("Resetting Visual HUD to None");
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("Resetting Visual HUD to None");
					}
					Thread thread = new Thread((FrmMain._Closure$__.$I215-0 == null) ? (FrmMain._Closure$__.$I215-0 = delegate
					{
						RunCommand.Run_debug_tool_info("perfhud reset\r\nlayerhud reset");
					}) : FrmMain._Closure$__.$I215-0);
					thread.Start();
				}
				bool flag3 = this.ComboVisualHUD.SelectedIndex == 1;
				if (flag3)
				{
					this.AddToListboxAndScroll("Enabling Layer Overlay");
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Enabling Layer Overlay");
					}
					Thread thread2 = new Thread((FrmMain._Closure$__.$I215-1 == null) ? (FrmMain._Closure$__.$I215-1 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 1\r\nperfhud set-mode 0");
					}) : FrmMain._Closure$__.$I215-1);
					thread2.Start();
				}
				bool flag4 = this.ComboVisualHUD.SelectedIndex == 2;
				if (flag4)
				{
					this.AddToListboxAndScroll("Enabling Performance Overlay");
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog("Enabling Performance Overlay");
					}
					Thread thread3 = new Thread((FrmMain._Closure$__.$I215-2 == null) ? (FrmMain._Closure$__.$I215-2 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 1");
					}) : FrmMain._Closure$__.$I215-2);
					thread3.Start();
				}
				bool flag5 = this.ComboVisualHUD.SelectedIndex == 3;
				if (flag5)
				{
					this.AddToListboxAndScroll("Enabling ASW Overlay");
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog("Enabling ASW Overlay");
					}
					Thread thread4 = new Thread((FrmMain._Closure$__.$I215-3 == null) ? (FrmMain._Closure$__.$I215-3 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 6");
					}) : FrmMain._Closure$__.$I215-3);
					thread4.Start();
				}
				bool flag6 = this.ComboVisualHUD.SelectedIndex == 4;
				if (flag6)
				{
					this.AddToListboxAndScroll("Enabling Latency Timing Overlay");
					bool dbg5 = Globals.dbg;
					if (dbg5)
					{
						Log.WriteToLog("Enabling Latency Timing Overlay");
					}
					Thread thread5 = new Thread((FrmMain._Closure$__.$I215-4 == null) ? (FrmMain._Closure$__.$I215-4 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 2");
					}) : FrmMain._Closure$__.$I215-4);
					thread5.Start();
				}
				bool flag7 = this.ComboVisualHUD.SelectedIndex == 5;
				if (flag7)
				{
					this.AddToListboxAndScroll("Enabling Application Render Timing Overlay");
					bool dbg6 = Globals.dbg;
					if (dbg6)
					{
						Log.WriteToLog("Enabling Application Render Timing Overlay");
					}
					Thread thread6 = new Thread((FrmMain._Closure$__.$I215-5 == null) ? (FrmMain._Closure$__.$I215-5 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 3");
					}) : FrmMain._Closure$__.$I215-5);
					thread6.Start();
				}
				bool flag8 = this.ComboVisualHUD.SelectedIndex == 6;
				if (flag8)
				{
					this.AddToListboxAndScroll("Enabling Compositor Render Timing Overlay");
					bool dbg7 = Globals.dbg;
					if (dbg7)
					{
						Log.WriteToLog("Enabling Compositor Render Timing Overlay");
					}
					Thread thread7 = new Thread((FrmMain._Closure$__.$I215-6 == null) ? (FrmMain._Closure$__.$I215-6 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 4");
					}) : FrmMain._Closure$__.$I215-6);
					thread7.Start();
				}
				bool flag9 = this.ComboVisualHUD.SelectedIndex == 7;
				if (flag9)
				{
					this.AddToListboxAndScroll("Enabling Version Info Overlay");
					bool dbg8 = Globals.dbg;
					if (dbg8)
					{
						Log.WriteToLog("Enabling Version Info Overlay");
					}
					Thread thread8 = new Thread((FrmMain._Closure$__.$I215-7 == null) ? (FrmMain._Closure$__.$I215-7 = delegate
					{
						RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 5");
					}) : FrmMain._Closure$__.$I215-7);
					thread8.Start();
				}
			}
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0003A714 File Offset: 0x00038914
		private void PowerModeChanged(object sender, PowerModeChangedEventArgs args)
		{
			bool flag = (double)args.Mode == Conversions.ToDouble("1");
			if (flag)
			{
				Log.WriteToLog("Computer is waking up");
				this.AddToListboxAndScroll("Computer is waking up");
				Thread.Sleep(3000);
				this.StopOVR();
				Thread.Sleep(4000);
				this.StartOVR();
			}
			bool flag2 = (double)args.Mode == Conversions.ToDouble("2");
			if (flag2)
			{
				Log.WriteToLog("Computer is in an unknown power state");
				this.AddToListboxAndScroll("Computer is in an unknown power state");
			}
			bool flag3 = (double)args.Mode == Conversions.ToDouble("3");
			if (flag3)
			{
				Log.WriteToLog("Computer is going to sleep");
				this.AddToListboxAndScroll("Computer is going to sleep");
			}
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0003A7D8 File Offset: 0x000389D8
		private void CheckRestartSleep_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckRestartSleep.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.RestartServiceAfterSleep = true;
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("Adding eventhandler for PowerModeChanged");
					}
					SystemEvents.PowerModeChanged += this.PowerModeChanged;
				}
				else
				{
					MySettingsProperty.Settings.RestartServiceAfterSleep = false;
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Removing eventhandler for PowerModeChanged");
					}
					SystemEvents.PowerModeChanged -= this.PowerModeChanged;
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0003A87A File Offset: 0x00038A7A
		private void BtnSteamImport_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmImportSteamApps.ShowDialog(this);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0003A890 File Offset: 0x00038A90
		private void NotifyIcon3_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				HomeToTray.ShowHomeNormal();
				this.DisableShowHomeMenu();
				bool sendHomeToTray = MySettingsProperty.Settings.SendHomeToTray;
				if (sendHomeToTray)
				{
					this.HometoTrayTimer.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Restore Home: " + ex.Message);
			}
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0003A904 File Offset: 0x00038B04
		private void BtnConfigureHotKeys_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmHotKeys.ShowDialog();
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0003A917 File Offset: 0x00038B17
		private void ClearLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ListBox1.Items.Clear();
			this.numLogMessages = 0;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0003A932 File Offset: 0x00038B32
		private void OpenLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(Application.StartupPath + "\\ott.log");
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0003A94C File Offset: 0x00038B4C
		private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.DotNetBarTabcontrol1.SelectedIndex == 4;
			if (flag)
			{
				this.numLogMessages = 0;
				this.DotNetBarTabcontrol1.SelectedTab.Text = "Log Window";
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0003A98C File Offset: 0x00038B8C
		private void kbHook_KeyDown(Keys Key)
		{
			bool homeIsRunning = this.HomeIsRunning;
			checked
			{
				if (homeIsRunning)
				{
					string text = "";
					this.FuncToKeyDictionary.TryGetValue(Key.ToString().ToUpper(), out text);
					bool flag = Operators.CompareString(text, "", false) != 0;
					if (flag)
					{
						bool flag2 = Operators.CompareString(text, "ASW Auto", false) == 0;
						if (flag2)
						{
							this.AddToListboxAndScroll("Setting ASW to Auto");
							RunCommand.Run_debug_tool_asw("server:asw.Auto");
							bool hotKeyVoiceConfirmation = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
							if (hotKeyVoiceConfirmation)
							{
								Thread thread = new Thread((FrmMain._Closure$__.$I224-0 == null) ? (FrmMain._Closure$__.$I224-0 = delegate
								{
									MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
								}) : FrmMain._Closure$__.$I224-0);
								thread.Start();
							}
						}
						bool flag3 = Operators.CompareString(text, "ASW Off", false) == 0;
						if (flag3)
						{
							this.AddToListboxAndScroll("Setting ASW to Off");
							RunCommand.Run_debug_tool_asw("server:asw.Off");
							bool hotKeyVoiceConfirmation2 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
							if (hotKeyVoiceConfirmation2)
							{
								Thread thread2 = new Thread((FrmMain._Closure$__.$I224-1 == null) ? (FrmMain._Closure$__.$I224-1 = delegate
								{
									MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
								}) : FrmMain._Closure$__.$I224-1);
								thread2.Start();
							}
						}
						bool flag4 = Operators.CompareString(text, "ASW 45", false) == 0;
						if (flag4)
						{
							this.AddToListboxAndScroll("Setting ASW to Clock45");
							RunCommand.Run_debug_tool_asw("server:asw.Clock45");
							bool hotKeyVoiceConfirmation3 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
							if (hotKeyVoiceConfirmation3)
							{
								Thread thread3 = new Thread((FrmMain._Closure$__.$I224-2 == null) ? (FrmMain._Closure$__.$I224-2 = delegate
								{
									MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelocked.wav");
								}) : FrmMain._Closure$__.$I224-2);
								thread3.Start();
							}
						}
						bool flag5 = Operators.CompareString(text, "Close HUD", false) == 0;
						if (flag5)
						{
							RunCommand.Run_debug_tool_info("perfhud reset\r\nlayerhud reset");
						}
						bool flag6 = Operators.CompareString(text, "HUD ASW Mode", false) == 0;
						if (flag6)
						{
							RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 6");
						}
						bool flag7 = Operators.CompareString(text, "HUD Performance", false) == 0;
						if (flag7)
						{
							RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 1");
						}
						bool flag8 = Operators.CompareString(text, "HUD Pixel Density", false) == 0;
						if (flag8)
						{
							RunCommand.Run_debug_tool_info("layerhud set-mode 1\r\nperfhud set-mode 0");
						}
						bool flag9 = Operators.CompareString(text, "HUD Latency", false) == 0;
						if (flag9)
						{
							RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 2");
						}
						bool flag10 = Operators.CompareString(text, "HUD Application Render", false) == 0;
						if (flag10)
						{
							RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 3");
						}
						bool flag11 = Operators.CompareString(text, "HUD Compositor Render", false) == 0;
						if (flag11)
						{
							RunCommand.Run_debug_tool_info("layerhud set-mode 0\r\nperfhud set-mode 4");
						}
						bool flag12 = Operators.CompareString(text, "Exit running VR app", false) == 0;
						if (flag12)
						{
							try
							{
								bool flag13 = (Operators.CompareString(this.runningAppExe, "cmd.exe", false) != 0) & (Operators.CompareString(this.runningapp_displayname, "", false) != 0) & (this.pid != 0);
								if (flag13)
								{
									bool flag14 = this.AllAppsList.ContainsValue(this.runningapp_displayname);
									if (flag14)
									{
										KillRunningApp.GetParentProcess(this.pid);
										this.pid = 0;
									}
								}
							}
							catch (Exception ex)
							{
								Log.WriteToLog(string.Concat(new string[]
								{
									"Termination request for ",
									this.runningapp_displayname,
									"(",
									this.runningAppExe,
									") with PID ",
									Conversions.ToString(this.pid),
									" failed: ",
									ex.Message
								}));
								this.AddToListboxAndScroll(string.Concat(new string[]
								{
									"Termination request for ",
									this.runningapp_displayname,
									" with PID ",
									Conversions.ToString(this.pid),
									" failed: ",
									ex.Message
								}));
								this.pid = 0;
							}
						}
						bool flag15 = Operators.CompareString(text, "Next HUD", false) == 0;
						if (flag15)
						{
							bool flag16 = this.ComboVisualHUD.SelectedIndex == this.ComboVisualHUD.Items.Count - 1;
							if (flag16)
							{
								this.ComboVisualHUD.SelectedIndex = 0;
							}
							else
							{
								this.ComboVisualHUD.SelectedIndex = this.ComboVisualHUD.SelectedIndex + 1;
							}
						}
						bool flag17 = Operators.CompareString(text, "Previous HUD", false) == 0;
						if (flag17)
						{
							bool flag18 = this.ComboVisualHUD.SelectedIndex == 0;
							if (flag18)
							{
								this.ComboVisualHUD.SelectedIndex = this.ComboVisualHUD.Items.Count - 1;
							}
							else
							{
								this.ComboVisualHUD.SelectedIndex = this.ComboVisualHUD.SelectedIndex - 1;
							}
						}
						bool flag19 = Operators.CompareString(text, "Next ASW Mode", false) == 0;
						if (flag19)
						{
							bool flag20 = this.CurrentASW != this.NextASW.Count - 1;
							if (flag20)
							{
								ref int ptr = ref this.CurrentASW;
								this.CurrentASW = ptr + 1;
							}
							else
							{
								this.CurrentASW = 0;
							}
							string text2 = this.NextASW[this.CurrentASW];
							bool flag21 = Operators.CompareString(text2, "45", false) == 0;
							if (flag21)
							{
								this.AddToListboxAndScroll("Setting ASW to Clock45");
								Thread thread4 = new Thread((FrmMain._Closure$__.$I224-3 == null) ? (FrmMain._Closure$__.$I224-3 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock45");
								}) : FrmMain._Closure$__.$I224-3);
								thread4.Start();
								bool hotKeyVoiceConfirmation4 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation4)
								{
									Thread thread5 = new Thread((FrmMain._Closure$__.$I224-4 == null) ? (FrmMain._Closure$__.$I224-4 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat45fps.wav");
									}) : FrmMain._Closure$__.$I224-4);
									thread5.Start();
								}
							}
							bool flag22 = Operators.CompareString(text2, "Off", false) == 0;
							if (flag22)
							{
								this.AddToListboxAndScroll("Setting ASW to Off");
								Thread thread6 = new Thread((FrmMain._Closure$__.$I224-5 == null) ? (FrmMain._Closure$__.$I224-5 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Off");
								}) : FrmMain._Closure$__.$I224-5);
								thread6.Start();
								bool hotKeyVoiceConfirmation5 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation5)
								{
									Thread thread7 = new Thread((FrmMain._Closure$__.$I224-6 == null) ? (FrmMain._Closure$__.$I224-6 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
									}) : FrmMain._Closure$__.$I224-6);
									thread7.Start();
								}
							}
							bool flag23 = Operators.CompareString(text2, "Auto", false) == 0;
							if (flag23)
							{
								this.AddToListboxAndScroll("Setting ASW to Auto");
								Thread thread8 = new Thread((FrmMain._Closure$__.$I224-7 == null) ? (FrmMain._Closure$__.$I224-7 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Auto");
								}) : FrmMain._Closure$__.$I224-7);
								thread8.Start();
								bool hotKeyVoiceConfirmation6 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation6)
								{
									Thread thread9 = new Thread((FrmMain._Closure$__.$I224-8 == null) ? (FrmMain._Closure$__.$I224-8 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
									}) : FrmMain._Closure$__.$I224-8);
									thread9.Start();
								}
							}
							bool flag24 = Operators.CompareString(text2, "30", false) == 0;
							if (flag24)
							{
								this.AddToListboxAndScroll("Setting ASW to 30Hz");
								Thread thread10 = new Thread((FrmMain._Closure$__.$I224-9 == null) ? (FrmMain._Closure$__.$I224-9 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock30");
								}) : FrmMain._Closure$__.$I224-9);
								thread10.Start();
								bool hotKeyVoiceConfirmation7 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation7)
								{
									Thread thread11 = new Thread((FrmMain._Closure$__.$I224-10 == null) ? (FrmMain._Closure$__.$I224-10 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat30fps.wav");
									}) : FrmMain._Closure$__.$I224-10);
									thread11.Start();
								}
							}
							bool flag25 = Operators.CompareString(text2, "18", false) == 0;
							if (flag25)
							{
								this.AddToListboxAndScroll("Setting ASW to 18Hz");
								Thread thread12 = new Thread((FrmMain._Closure$__.$I224-11 == null) ? (FrmMain._Closure$__.$I224-11 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock18");
								}) : FrmMain._Closure$__.$I224-11);
								thread12.Start();
								bool hotKeyVoiceConfirmation8 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation8)
								{
									Thread thread13 = new Thread((FrmMain._Closure$__.$I224-12 == null) ? (FrmMain._Closure$__.$I224-12 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat18fps.wav");
									}) : FrmMain._Closure$__.$I224-12);
									thread13.Start();
								}
							}
							bool flag26 = Operators.CompareString(text2, "45f", false) == 0;
							if (flag26)
							{
								this.AddToListboxAndScroll("Setting ASW to 45Hz (Forced)");
								Thread thread14 = new Thread((FrmMain._Closure$__.$I224-13 == null) ? (FrmMain._Closure$__.$I224-13 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Sim45");
								}) : FrmMain._Closure$__.$I224-13);
								thread14.Start();
								bool hotKeyVoiceConfirmation9 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation9)
								{
									Thread thread15 = new Thread((FrmMain._Closure$__.$I224-14 == null) ? (FrmMain._Closure$__.$I224-14 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\framerateforcedto45fps.wav");
									}) : FrmMain._Closure$__.$I224-14);
									thread15.Start();
								}
							}
							bool flag27 = Operators.CompareString(text2, "Adaptive", false) == 0;
							if (flag27)
							{
								this.AddToListboxAndScroll("Setting ASW to Adaptive");
								Thread thread16 = new Thread((FrmMain._Closure$__.$I224-15 == null) ? (FrmMain._Closure$__.$I224-15 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
								}) : FrmMain._Closure$__.$I224-15);
								thread16.Start();
								bool hotKeyVoiceConfirmation10 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation10)
								{
									Thread thread17 = new Thread((FrmMain._Closure$__.$I224-16 == null) ? (FrmMain._Closure$__.$I224-16 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\adaptiveframerateenabled.wav");
									}) : FrmMain._Closure$__.$I224-16);
									thread17.Start();
								}
							}
						}
						bool flag28 = Operators.CompareString(text, "Previous ASW Mode", false) == 0;
						if (flag28)
						{
							bool flag29 = this.CurrentASW != 0;
							if (flag29)
							{
								ref int ptr = ref this.CurrentASW;
								this.CurrentASW = ptr - 1;
							}
							else
							{
								this.CurrentASW = this.NextASW.Count - 1;
							}
							string text3 = this.NextASW[this.CurrentASW];
							bool flag30 = Operators.CompareString(text3, "45", false) == 0;
							if (flag30)
							{
								this.AddToListboxAndScroll("Setting ASW to 45hz");
								RunCommand.Run_debug_tool_asw("server:asw.Clock45");
								bool hotKeyVoiceConfirmation11 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation11)
								{
									Thread thread18 = new Thread((FrmMain._Closure$__.$I224-17 == null) ? (FrmMain._Closure$__.$I224-17 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat45fps.wav");
									}) : FrmMain._Closure$__.$I224-17);
									thread18.Start();
								}
							}
							bool flag31 = Operators.CompareString(text3, "Off", false) == 0;
							if (flag31)
							{
								this.AddToListboxAndScroll("Setting ASW to Off");
								RunCommand.Run_debug_tool_asw("server:asw.Off");
								bool hotKeyVoiceConfirmation12 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation12)
								{
									Thread thread19 = new Thread((FrmMain._Closure$__.$I224-18 == null) ? (FrmMain._Closure$__.$I224-18 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
									}) : FrmMain._Closure$__.$I224-18);
									thread19.Start();
								}
							}
							bool flag32 = Operators.CompareString(text3, "Auto", false) == 0;
							if (flag32)
							{
								this.AddToListboxAndScroll("Setting ASW to Auto");
								RunCommand.Run_debug_tool_asw("server:asw.Auto");
								bool hotKeyVoiceConfirmation13 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation13)
								{
									Thread thread20 = new Thread((FrmMain._Closure$__.$I224-19 == null) ? (FrmMain._Closure$__.$I224-19 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
									}) : FrmMain._Closure$__.$I224-19);
									thread20.Start();
								}
							}
							bool flag33 = Operators.CompareString(text3, "30", false) == 0;
							if (flag33)
							{
								this.AddToListboxAndScroll("Setting ASW to 30Hz");
								Thread thread21 = new Thread((FrmMain._Closure$__.$I224-20 == null) ? (FrmMain._Closure$__.$I224-20 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock30");
								}) : FrmMain._Closure$__.$I224-20);
								thread21.Start();
								bool hotKeyVoiceConfirmation14 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation14)
								{
									Thread thread22 = new Thread((FrmMain._Closure$__.$I224-21 == null) ? (FrmMain._Closure$__.$I224-21 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat30fps.wav");
									}) : FrmMain._Closure$__.$I224-21);
									thread22.Start();
								}
							}
							bool flag34 = Operators.CompareString(text3, "18", false) == 0;
							if (flag34)
							{
								this.AddToListboxAndScroll("Setting ASW to 18Hz");
								Thread thread23 = new Thread((FrmMain._Closure$__.$I224-22 == null) ? (FrmMain._Closure$__.$I224-22 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Clock18");
								}) : FrmMain._Closure$__.$I224-22);
								thread23.Start();
								bool hotKeyVoiceConfirmation15 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation15)
								{
									Thread thread24 = new Thread((FrmMain._Closure$__.$I224-23 == null) ? (FrmMain._Closure$__.$I224-23 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelockedat18fps.wav");
									}) : FrmMain._Closure$__.$I224-23);
									thread24.Start();
								}
							}
							bool flag35 = Operators.CompareString(text3, "45f", false) == 0;
							if (flag35)
							{
								this.AddToListboxAndScroll("Setting ASW to 45Hz (forced)");
								Thread thread25 = new Thread((FrmMain._Closure$__.$I224-24 == null) ? (FrmMain._Closure$__.$I224-24 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Sim45");
								}) : FrmMain._Closure$__.$I224-24);
								thread25.Start();
								bool hotKeyVoiceConfirmation16 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation16)
								{
									Thread thread26 = new Thread((FrmMain._Closure$__.$I224-25 == null) ? (FrmMain._Closure$__.$I224-25 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\framerateforcedto45fps.wav");
									}) : FrmMain._Closure$__.$I224-25);
									thread26.Start();
								}
							}
							bool flag36 = Operators.CompareString(text3, "Adaptive", false) == 0;
							if (flag36)
							{
								this.AddToListboxAndScroll("Setting ASW to Adaptive");
								Thread thread27 = new Thread((FrmMain._Closure$__.$I224-26 == null) ? (FrmMain._Closure$__.$I224-26 = delegate
								{
									RunCommand.Run_debug_tool_asw("server:asw.Adaptive");
								}) : FrmMain._Closure$__.$I224-26);
								thread27.Start();
								bool hotKeyVoiceConfirmation17 = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
								if (hotKeyVoiceConfirmation17)
								{
									Thread thread28 = new Thread((FrmMain._Closure$__.$I224-27 == null) ? (FrmMain._Closure$__.$I224-27 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\adaptiveframerateenabled.wav");
									}) : FrmMain._Closure$__.$I224-27);
									thread28.Start();
								}
							}
						}
					}
					bool flag37 = Operators.CompareString(Key.ToString().ToUpper(), MySettingsProperty.Settings.KeyboardVoiceActivationKey, false) == 0;
					if (flag37)
					{
						bool voiceActivationKeyContinous = MySettingsProperty.Settings.VoiceActivationKeyContinous;
						if (voiceActivationKeyContinous)
						{
							bool flag38 = !VoiceCommands.isListening;
							if (flag38)
							{
								VoiceCommands.isListening = true;
								this.SetTitleIsListening();
								bool flag39 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
								if (flag39)
								{
									Thread thread29 = new Thread((FrmMain._Closure$__.$I224-28 == null) ? (FrmMain._Closure$__.$I224-28 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
									}) : FrmMain._Closure$__.$I224-28);
									thread29.Start();
								}
								CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.Name);
								VoiceCommands.sRecognize = new SpeechRecognitionEngine(cultureInfo);
								VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
								VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
								VoiceCommands.buildGrammars();
							}
							else
							{
								bool flag40 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
								if (flag40)
								{
									Thread thread30 = new Thread((FrmMain._Closure$__.$I224-29 == null) ? (FrmMain._Closure$__.$I224-29 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
									}) : FrmMain._Closure$__.$I224-29);
									thread30.Start();
								}
								VoiceCommands.StopListening();
								this.RemoveTitleIsListening();
							}
						}
						bool voiceActivationKeyPush = MySettingsProperty.Settings.VoiceActivationKeyPush;
						if (voiceActivationKeyPush)
						{
							bool flag41 = !VoiceCommands.isListening;
							if (flag41)
							{
								bool flag42 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
								if (flag42)
								{
									Thread thread31 = new Thread((FrmMain._Closure$__.$I224-30 == null) ? (FrmMain._Closure$__.$I224-30 = delegate
									{
										MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
									}) : FrmMain._Closure$__.$I224-30);
									thread31.Start();
								}
								CultureInfo cultureInfo2 = new CultureInfo(CultureInfo.CurrentUICulture.Name);
								VoiceCommands.sRecognize = new SpeechRecognitionEngine(cultureInfo2);
								VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
								VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
								VoiceCommands.buildGrammars();
								VoiceCommands.isListening = true;
								this.SetTitleIsListening();
							}
						}
					}
				}
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0003B948 File Offset: 0x00039B48
		private void kbHook_KeyUp(Keys Key)
		{
			bool homeIsRunning = this.HomeIsRunning;
			if (homeIsRunning)
			{
				bool flag = Operators.CompareString(Key.ToString().ToUpper(), MySettingsProperty.Settings.KeyboardVoiceActivationKey, false) == 0;
				if (flag)
				{
					bool voiceActivationKeyPush = MySettingsProperty.Settings.VoiceActivationKeyPush;
					if (voiceActivationKeyPush)
					{
						bool flag2 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
						if (flag2)
						{
							Thread thread = new Thread((FrmMain._Closure$__.$I225-0 == null) ? (FrmMain._Closure$__.$I225-0 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav", AudioPlayMode.Background);
							}) : FrmMain._Closure$__.$I225-0);
							thread.Start();
						}
						VoiceCommands.StopListening();
						this.RemoveTitleIsListening();
					}
				}
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0003B9F4 File Offset: 0x00039BF4
		private void PowerPlanTimer_Tick(object sender, EventArgs e)
		{
			this.PowerPlanTimer.Stop();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			try
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					bool flag = Conversions.ToBoolean(managementObject.GetPropertyValue("IsActive"));
					if (flag)
					{
						bool flag2 = Operators.CompareString(managementObject["ElementName"].ToString(), MySettingsProperty.Settings.PowerPlanCurrent, false) != 0;
						if (flag2)
						{
							Log.WriteToLog("Detected power plan change by outside source, adjusting");
							this.AddToListboxAndScroll("Detected power plan change by outside source, adjusting");
							PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanCurrent);
							PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
						}
						break;
					}
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator;
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.PowerPlanTimer.Start();
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0003BAF0 File Offset: 0x00039CF0
		private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.isCopy;
			if (!flag)
			{
				this.ComboBox2.Text = OTTDB.GetLinkPresetValueByName(this.ComboBox4.Text, "Curve");
				this.ComboBox3.Text = OTTDB.GetLinkPresetValueByName(this.ComboBox4.Text, "Encoding");
				this.ComboBox6.Text = OTTDB.GetLinkPresetValueByName(this.ComboBox4.Text, "Bitrate");
				this.ComboBox7.Text = OTTDB.GetLinkPresetValueByName(this.ComboBox4.Text, "Sharpening");
				this.ComboBox10.SelectedIndex = Conversions.ToInteger(OTTDB.GetLinkPresetValueByName(this.ComboBox4.Text, "DBR"));
				this.ComboBox2.Enabled = true;
				this.ComboBox3.Enabled = true;
				this.Button3.Enabled = true;
			}
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0003BBDE File Offset: 0x00039DDE
		private void Button10_Click(object sender, EventArgs e)
		{
			this.SaveOculusLinkValues(true);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0003BBEC File Offset: 0x00039DEC
		private void SaveOculusLinkValues(bool restart)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				bool flag = Operators.CompareString(this.ComboBox4.Text, "Disabled", false) == 0;
				if (flag)
				{
					MyProject.Computer.Registry.CurrentUser.DeleteSubKey("Software\\Oculus\\RemoteHeadset", false);
					Log.WriteToLog("Disabled Quest Link options");
					if (restart)
					{
						this.StopOVR();
						this.StartOVR();
					}
					else
					{
						this.Cursor = Cursors.Default;
					}
				}
				else
				{
					bool flag2 = MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", false) == null;
					if (flag2)
					{
						MyProject.Computer.Registry.CurrentUser.CreateSubKey("Software\\Oculus\\RemoteHeadset", true);
					}
					RegistryKey registryKey = MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", true);
					switch (this.ComboBox2.SelectedIndex)
					{
					case 0:
					{
						bool flag3 = registryKey.GetValue("DistortionCurve", null) != null;
						if (flag3)
						{
							registryKey.DeleteValue("DistortionCurve", false);
						}
						Log.WriteToLog("Quest Link option set: DistortionCurve = " + this.ComboBox2.Items[0].ToString());
						break;
					}
					case 1:
						registryKey.SetValue("DistortionCurve", "1", RegistryValueKind.DWord);
						Log.WriteToLog("Quest Link option set: DistortionCurve = " + this.ComboBox2.Items[1].ToString());
						break;
					case 2:
						registryKey.SetValue("DistortionCurve", "0", RegistryValueKind.DWord);
						Log.WriteToLog("Quest Link option set: DistortionCurve = " + this.ComboBox2.Items[2].ToString());
						break;
					}
					registryKey.SetValue("EncodeWidth", this.ComboBox3.Text, RegistryValueKind.DWord);
					Log.WriteToLog("Quest Link option set: EncodeWidth = " + this.ComboBox3.Text);
					bool flag4 = Operators.CompareString(this.ComboBox6.Text, "", false) != 0;
					if (flag4)
					{
						registryKey.SetValue("BitrateMbps", this.ComboBox6.Text, RegistryValueKind.DWord);
						Log.WriteToLog("Quest Link option set: BitrateMbps = " + this.ComboBox6.Text);
					}
					bool flag5 = Operators.CompareString(this.ComboBox7.Text, "", false) != 0;
					if (flag5)
					{
						bool flag6 = Operators.CompareString(this.ComboBox7.Text, "Disabled", false) == 0;
						if (flag6)
						{
							registryKey.SetValue("LinkSharpeningEnabled", "1", RegistryValueKind.DWord);
							Log.WriteToLog("Quest Link option set: LinkSharpeningEnabled = " + this.ComboBox7.Text);
						}
						bool flag7 = Operators.CompareString(this.ComboBox7.Text, "Enabled", false) == 0;
						if (flag7)
						{
							registryKey.SetValue("LinkSharpeningEnabled", "2", RegistryValueKind.DWord);
							Log.WriteToLog("Quest Link option set: LinkSharpeningEnabled = " + this.ComboBox7.Text);
						}
						bool flag8 = Operators.CompareString(this.ComboBox7.Text, "Auto", false) == 0;
						if (flag8)
						{
							bool flag9 = registryKey.GetValue("LinkSharpeningEnabled", null) != null;
							if (flag9)
							{
								registryKey.DeleteValue("LinkSharpeningEnabled");
								Log.WriteToLog("Quest Link option set: LinkSharpeningEnabled = " + this.ComboBox7.Text);
							}
						}
					}
					switch (this.ComboBox10.SelectedIndex)
					{
					case 0:
					{
						bool flag10 = registryKey.GetValue("DBR", null) != null;
						if (flag10)
						{
							registryKey.DeleteValue("DBR", false);
						}
						Log.WriteToLog("Quest Link option set: Encode Dynamic Bitrate = " + this.ComboBox10.Items[0].ToString());
						break;
					}
					case 1:
						registryKey.SetValue("DBR", "1", RegistryValueKind.DWord);
						Log.WriteToLog("Quest Link option set: Encode Dynamic Bitrate = " + this.ComboBox10.Items[1].ToString());
						break;
					case 2:
						registryKey.SetValue("DBR", "0", RegistryValueKind.DWord);
						Log.WriteToLog("Quest Link option set: Encode Dynamic Bitrate = " + this.ComboBox10.Items[2].ToString());
						break;
					}
					bool flag11 = Operators.CompareString(this.ComboBox11.Text, "0", false) == 0;
					if (flag11)
					{
						bool flag12 = registryKey.GetValue("DBRMax", null) != null;
						if (flag12)
						{
							registryKey.DeleteValue("DBRMax", false);
						}
						Log.WriteToLog("Quest Link option set: Disabled Dynamic Bitrate Max");
					}
					else
					{
						registryKey.SetValue("DBRMax", this.ComboBox11.Text, RegistryValueKind.DWord);
						Log.WriteToLog("Quest Link option set: Dynamic Bitrate Max = " + this.ComboBox11.Text);
					}
					bool flag13 = (Operators.CompareString(this.ComboBox4.Text, "GTX 970+", false) == 0) | (Operators.CompareString(this.ComboBox4.Text, "GTX 1070+", false) == 0) | (Operators.CompareString(this.ComboBox4.Text, "RTX 2070+", false) == 0) | (Operators.CompareString(this.ComboBox4.Text, "GTX 1080Ti/RTX 2080+", false) == 0);
					if (flag13)
					{
						this.isCopy = true;
						MyProject.Forms.frmLinkPresets.ShowDialog();
					}
					OTTDB.AddLinkPreset(this.ComboBox4.Text, this.ComboBox2.Text, this.ComboBox3.Text, this.ComboBox6.Text, this.ComboBox7.Text, this.ComboBox10.SelectedIndex.ToString());
					if (restart)
					{
						this.StopOVR();
						this.StartOVR();
					}
					else
					{
						this.Cursor = Cursors.Default;
					}
				}
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				Log.WriteToLog("Could not set registry values for Quest Link: " + ex.Message);
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error setting registry values");
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0003C230 File Offset: 0x0003A430
		public void GetOculusLinkValues()
		{
			try
			{
				bool flag = MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", false) != null;
				if (flag)
				{
					RegistryKey registryKey = MyProject.Computer.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", false);
					bool flag2 = registryKey.GetValue("DistortionCurve", null) != null;
					if (flag2)
					{
						bool flag3 = Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DistortionCurve", null), "0", false);
						if (flag3)
						{
							this.ComboBox2.Text = "Low";
						}
						else
						{
							bool flag4 = Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DistortionCurve", null), "1", false);
							if (flag4)
							{
								this.ComboBox2.Text = "High";
							}
						}
					}
					else
					{
						this.ComboBox2.Text = "Default";
					}
					bool flag5 = registryKey.GetValue("EncodeWidth", null) != null;
					if (flag5)
					{
						this.ComboBox3.Text = Conversions.ToString(registryKey.GetValue("EncodeWidth", null));
					}
					bool flag6 = registryKey.GetValue("BitrateMbps", null) != null;
					if (flag6)
					{
						this.ComboBox6.Text = Conversions.ToString(registryKey.GetValue("BitrateMbps", null));
					}
					bool flag7 = registryKey.GetValue("LinkSharpeningEnabled", null) != null;
					if (flag7)
					{
						bool flag8 = Operators.ConditionalCompareObjectEqual(registryKey.GetValue("LinkSharpeningEnabled", null), "1", false);
						if (flag8)
						{
							this.ComboBox7.Text = "Disabled";
						}
						else
						{
							bool flag9 = Operators.ConditionalCompareObjectEqual(registryKey.GetValue("LinkSharpeningEnabled", null), "2", false);
							if (flag9)
							{
								this.ComboBox7.Text = "Enabled";
							}
						}
					}
					else
					{
						this.ComboBox7.Text = "Auto";
					}
					bool flag10 = registryKey.GetValue("DBR", null) != null;
					if (flag10)
					{
						bool flag11 = Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DBR", null), "1", false);
						if (flag11)
						{
							this.ComboBox10.Text = "Enabled";
						}
						else
						{
							bool flag12 = Operators.ConditionalCompareObjectEqual(registryKey.GetValue("DBR", null), "0", false);
							if (flag12)
							{
								this.ComboBox10.Text = "Disabled";
							}
						}
					}
					else
					{
						this.ComboBox10.Text = "Default";
					}
					bool flag13 = registryKey.GetValue("DBRMax", null) != null;
					if (flag13)
					{
						this.ComboBox11.Text = Conversions.ToString(registryKey.GetValue("DBRMax", null));
					}
					else
					{
						this.ComboBox11.Text = "0";
					}
					string linkPresetValueByValues = OTTDB.GetLinkPresetValueByValues(this.ComboBox2.Text, this.ComboBox3.Text, this.ComboBox6.Text, this.ComboBox7.Text, this.ComboBox10.SelectedIndex.ToString());
					bool flag14 = Operators.CompareString(linkPresetValueByValues, "", false) != 0;
					if (flag14)
					{
						this.ComboBox4.Text = linkPresetValueByValues;
						Log.WriteToLog("Oculus Link Preset: " + linkPresetValueByValues);
					}
					else
					{
						Log.WriteToLog("No matching Presets found");
						this.AddToListboxAndScroll("No matching Presets found");
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Could not read Link values from registry: " + ex.Message);
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0003C5BC File Offset: 0x0003A7BC
		private void ComboBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !Versioned.IsNumeric(e.KeyChar) & (e.KeyChar != '\b');
			if (flag)
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0003C5F8 File Offset: 0x0003A7F8
		private void Button12_Click(object sender, EventArgs e)
		{
			this.SaveOculusLinkValues(false);
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0003C604 File Offset: 0x0003A804
		private void Button11_Click(object sender, EventArgs e)
		{
			object obj = true;
			MyProject.Forms.frmLinkPresets.TextBox1.Text = "";
			MyProject.Forms.frmLinkPresets.ShowDialog();
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0003C644 File Offset: 0x0003A844
		private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.ComboBox5.SelectedIndex == 0;
			if (flag)
			{
				MySettingsProperty.Settings.AdaptiveGPUScaling = true;
				MySettingsProperty.Settings.Save();
				bool ovrisRunning = this.OVRIsRunning;
				if (ovrisRunning)
				{
					RunCommand.Run_debug_tool_agps("true");
					this.AddToListboxAndScroll("Adaptive GPU Scaling Enabled");
				}
			}
			else
			{
				MySettingsProperty.Settings.AdaptiveGPUScaling = false;
				MySettingsProperty.Settings.Save();
				bool ovrisRunning2 = this.OVRIsRunning;
				if (ovrisRunning2)
				{
					RunCommand.Run_debug_tool_agps("false");
					this.AddToListboxAndScroll("Adaptive GPU Scaling Disabled");
				}
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0003C6E0 File Offset: 0x0003A8E0
		public object GetCurrentResolution()
		{
			checked
			{
				short num = (short)Screen.PrimaryScreen.Bounds.Width;
				short num2 = (short)Screen.PrimaryScreen.Bounds.Height;
				return num.ToString().Trim() + " x " + num2.ToString().Trim();
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0003C740 File Offset: 0x0003A940
		private void ComboOVRPrio_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool isReading = GetConfig.IsReading;
			if (!isReading)
			{
				bool flag = Operators.CompareString(this.ComboOVRPrio.SelectedItem.ToString(), "", false) != 0;
				if (flag)
				{
					this.ChangeCPUPrioOVR(this.ComboOVRPrio.SelectedItem.ToString());
					MySettingsProperty.Settings.OVRSrvPrio = this.ComboOVRPrio.SelectedItem.ToString();
				}
			}
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0003C7AF File Offset: 0x0003A9AF
		private void Button3_Click(object sender, EventArgs e)
		{
			OTTDB.RemoveLinkPresetByName(this.ComboBox4.Text);
			this.ComboBox4.Items.Clear();
			OTTDB.GetLinkPresetNames();
			this.GetOculusLinkValues();
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0003C7E4 File Offset: 0x0003A9E4
		private void Button6_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string text = "Not Installed";
			string text2 = "Not Installed";
			string text3 = "Not Installed";
			bool flag = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, ""), 0, false);
			if (flag)
			{
				text = "Installed";
			}
			bool flag2 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, ""), 0, false);
			if (flag2)
			{
				text2 = "Installed";
			}
			bool flag3 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, ""), 0, false);
			if (flag3)
			{
				text3 = "Installed";
			}
			this.Cursor = Cursors.Default;
			bool flag4 = Interaction.MsgBox(string.Concat(new string[] { "This will install several pre-requisits, if not already installed, as well as close Oculus Home if it's running. Continue?\r\n\r\nChocolatey \t", text, "\r\nNode.js \t\t", text3, "\r\nasar \t\t", text2 }), MsgBoxStyle.YesNo | MsgBoxStyle.Question, null) == MsgBoxResult.Yes;
			if (flag4)
			{
				this.DotNetBarTabcontrol1.SelectedTab = this.DotNetBarTabcontrol1.TabPages[4];
				this.ListBox1.Refresh();
				AirLink.EnableAirLink();
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0003C908 File Offset: 0x0003AB08
		private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.ForceMipmap = this.ComboBox8.Text;
				MySettingsProperty.Settings.Save();
				Thread thread = new Thread((FrmMain._Closure$__.$I239-0 == null) ? (FrmMain._Closure$__.$I239-0 = delegate
				{
					RunCommand.Run_debug_tool_force_mipmap(MySettingsProperty.Settings.ForceMipmap.ToString().ToLower());
				}) : FrmMain._Closure$__.$I239-0);
				thread.Start();
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0003C978 File Offset: 0x0003AB78
		private void ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.OffsetMipmap = this.ComboBox9.Text;
				MySettingsProperty.Settings.Save();
				Thread thread = new Thread((FrmMain._Closure$__.$I240-0 == null) ? (FrmMain._Closure$__.$I240-0 = delegate
				{
					RunCommand.Run_debug_tool_offset_mipmap(MySettingsProperty.Settings.OffsetMipmap.ToString());
				}) : FrmMain._Closure$__.$I240-0);
				thread.Start();
			}
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0003C9E8 File Offset: 0x0003ABE8
		private void ComboSSstart_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsNumber(e.KeyChar) & (e.KeyChar != '.') & (Convert.ToInt32(e.KeyChar) != 8);
			if (flag)
			{
				bool flag2 = e.KeyChar == Conversions.ToChar(this.DSep);
				if (flag2)
				{
					e.Handled = true;
				}
				else
				{
					bool flag3 = e.KeyChar == '\r';
					if (flag3)
					{
						bool flag4 = !GetConfig.IsReading;
						if (flag4)
						{
							MySettingsProperty.Settings.PPDPStartup = this.ComboSSstart.Text;
							MySettingsProperty.Settings.Save();
							GetConfig.ppdpstartup = this.ComboSSstart.Text;
							Thread thread = new Thread((FrmMain._Closure$__.$I241-0 == null) ? (FrmMain._Closure$__.$I241-0 = delegate
							{
								RunCommand.Run_debug_tool(GetConfig.ppdpstartup);
							}) : FrmMain._Closure$__.$I241-0);
							thread.Start();
						}
					}
					else
					{
						e.Handled = true;
					}
				}
			}
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0003CAE0 File Offset: 0x0003ACE0
		private void CheckStopServiceHome_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				bool flag = !GetConfig.IsReading;
				if (flag)
				{
					bool @checked = this.CheckStopServiceHome.Checked;
					if (@checked)
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
				this.AddToListboxAndScroll("* Exception: " + ex.Message);
				this.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x00044E73 File Offset: 0x00043073
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x00044E7D File Offset: 0x0004307D
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x00044E86 File Offset: 0x00043086
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x00044E90 File Offset: 0x00043090
		internal virtual CheckBox CheckStartMin
		{
			[CompilerGenerated]
			get
			{
				return this._CheckStartMin;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckStartMin_CheckedChanged);
				CheckBox checkBox = this._CheckStartMin;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckStartMin = value;
				checkBox = this._CheckStartMin;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00044ED3 File Offset: 0x000430D3
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x00044EE0 File Offset: 0x000430E0
		internal virtual CheckBox CheckStartWindows
		{
			[CompilerGenerated]
			get
			{
				return this._CheckStartWindows;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckStartWindows_CheckedChanged);
				CheckBox checkBox = this._CheckStartWindows;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckStartWindows = value;
				checkBox = this._CheckStartWindows;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00044F23 File Offset: 0x00043123
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x00044F30 File Offset: 0x00043130
		internal virtual NotifyIcon NotifyIcon1
		{
			[CompilerGenerated]
			get
			{
				return this._NotifyIcon1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.NotifyIcon1_DoubleClick);
				NotifyIcon notifyIcon = this._NotifyIcon1;
				if (notifyIcon != null)
				{
					notifyIcon.DoubleClick -= eventHandler;
				}
				this._NotifyIcon1 = value;
				notifyIcon = this._NotifyIcon1;
				if (notifyIcon != null)
				{
					notifyIcon.DoubleClick += eventHandler;
				}
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00044F73 File Offset: 0x00043173
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x00044F80 File Offset: 0x00043180
		internal virtual Button ButtonStartOVR
		{
			[CompilerGenerated]
			get
			{
				return this._ButtonStartOVR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ButtonStartOVR_Click);
				Button button = this._ButtonStartOVR;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._ButtonStartOVR = value;
				button = this._ButtonStartOVR;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x00044FC3 File Offset: 0x000431C3
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x00044FCD File Offset: 0x000431CD
		internal virtual Label LabelServiceStatus
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00044FD6 File Offset: 0x000431D6
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x00044FE0 File Offset: 0x000431E0
		internal virtual ContextMenuStrip ContextMenuStrip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x00044FE9 File Offset: 0x000431E9
		// (set) Token: 0x06000680 RID: 1664 RVA: 0x00044FF4 File Offset: 0x000431F4
		internal virtual ToolStripMenuItem ToolStripMenuItem1
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem1_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem1;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem1 = value;
				toolStripMenuItem = this._ToolStripMenuItem1;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00045037 File Offset: 0x00043237
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x00045044 File Offset: 0x00043244
		internal virtual ToolStripMenuItem ToolStripMenuItem2
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem2_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem2;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem2 = value;
				toolStripMenuItem = this._ToolStripMenuItem2;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00045087 File Offset: 0x00043287
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x00045091 File Offset: 0x00043291
		internal virtual ListBox ListBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x0004509A File Offset: 0x0004329A
		// (set) Token: 0x06000686 RID: 1670 RVA: 0x000450A4 File Offset: 0x000432A4
		internal virtual ToolTip ToolTip
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x000450AD File Offset: 0x000432AD
		// (set) Token: 0x06000688 RID: 1672 RVA: 0x000450B8 File Offset: 0x000432B8
		internal virtual Button ButtonStopOVR
		{
			[CompilerGenerated]
			get
			{
				return this._ButtonStopOVR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ButtonStopOVR_Click);
				Button button = this._ButtonStopOVR;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._ButtonStopOVR = value;
				button = this._ButtonStopOVR;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x000450FB File Offset: 0x000432FB
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x00045108 File Offset: 0x00043308
		internal virtual CheckBox CheckStartService
		{
			[CompilerGenerated]
			get
			{
				return this._CheckStartService;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckStartService_CheckedChanged);
				CheckBox checkBox = this._CheckStartService;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckStartService = value;
				checkBox = this._CheckStartService;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0004514B File Offset: 0x0004334B
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x00045158 File Offset: 0x00043358
		internal virtual CheckBox CheckLaunchHome
		{
			[CompilerGenerated]
			get
			{
				return this._CheckLaunchHome;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckLaunchHome_CheckedChanged);
				CheckBox checkBox = this._CheckLaunchHome;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckLaunchHome = value;
				checkBox = this._CheckLaunchHome;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0004519B File Offset: 0x0004339B
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x000451A8 File Offset: 0x000433A8
		internal virtual CheckBox CheckStopService
		{
			[CompilerGenerated]
			get
			{
				return this._CheckStopService;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckStopService_CheckedChanged);
				CheckBox checkBox = this._CheckStopService;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckStopService = value;
				checkBox = this._CheckStopService;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x000451EB File Offset: 0x000433EB
		// (set) Token: 0x06000690 RID: 1680 RVA: 0x000451F5 File Offset: 0x000433F5
		internal virtual GroupBox GroupBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x000451FE File Offset: 0x000433FE
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x00045208 File Offset: 0x00043408
		internal virtual Button ButtonRestartOVR
		{
			[CompilerGenerated]
			get
			{
				return this._ButtonRestartOVR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ButtonRestartOVR_Click);
				Button button = this._ButtonRestartOVR;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._ButtonRestartOVR = value;
				button = this._ButtonRestartOVR;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0004524B File Offset: 0x0004344B
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x00045255 File Offset: 0x00043455
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0004525E File Offset: 0x0004345E
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x00045268 File Offset: 0x00043468
		internal virtual CheckBox CheckLaunchHomeTool
		{
			[CompilerGenerated]
			get
			{
				return this._CheckLaunchHomeTool;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckLaunchHomeTool_CheckedChanged);
				CheckBox checkBox = this._CheckLaunchHomeTool;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckLaunchHomeTool = value;
				checkBox = this._CheckLaunchHomeTool;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x000452AB File Offset: 0x000434AB
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x000452B8 File Offset: 0x000434B8
		internal virtual CheckBox CheckCloseHome
		{
			[CompilerGenerated]
			get
			{
				return this._CheckCloseHome;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckCloseHome_CheckedChanged);
				CheckBox checkBox = this._CheckCloseHome;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckCloseHome = value;
				checkBox = this._CheckCloseHome;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x000452FB File Offset: 0x000434FB
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x00045308 File Offset: 0x00043508
		internal virtual CheckBox CheckBoxAltTab
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBoxAltTab;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBoxAltTab_CheckedChanged);
				CheckBox checkBox = this._CheckBoxAltTab;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckBoxAltTab = value;
				checkBox = this._CheckBoxAltTab;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0004534B File Offset: 0x0004354B
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x00045358 File Offset: 0x00043558
		internal virtual CheckBox CheckRiftAudio
		{
			[CompilerGenerated]
			get
			{
				return this._CheckRiftAudio;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckRiftAudio_CheckedChanged);
				CheckBox checkBox = this._CheckRiftAudio;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckRiftAudio = value;
				checkBox = this._CheckRiftAudio;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0004539B File Offset: 0x0004359B
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x000453A8 File Offset: 0x000435A8
		internal virtual global::System.Windows.Forms.Timer OculusHomeWatcher
		{
			[CompilerGenerated]
			get
			{
				return this._OculusHomeWatcher;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.OculusHomeWatcher_Tick);
				global::System.Windows.Forms.Timer timer = this._OculusHomeWatcher;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._OculusHomeWatcher = value;
				timer = this._OculusHomeWatcher;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x000453EB File Offset: 0x000435EB
		// (set) Token: 0x060006A0 RID: 1696 RVA: 0x000453F8 File Offset: 0x000435F8
		internal virtual ToolStripMenuItem ToolStripMenuItem3
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem3_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem3;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem3 = value;
				toolStripMenuItem = this._ToolStripMenuItem3;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x0004543B File Offset: 0x0004363B
		// (set) Token: 0x060006A2 RID: 1698 RVA: 0x00045445 File Offset: 0x00043645
		internal virtual ToolStripSeparator ToolStripSeparator1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x0004544E File Offset: 0x0004364E
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x00045458 File Offset: 0x00043658
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00045461 File Offset: 0x00043661
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x0004546C File Offset: 0x0004366C
		internal virtual CheckBox CheckSpoofCPU
		{
			[CompilerGenerated]
			get
			{
				return this._CheckSpoofCPU;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckSpoofCPU_CheckedChanged);
				CheckBox checkBox = this._CheckSpoofCPU;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckSpoofCPU = value;
				checkBox = this._CheckSpoofCPU;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x000454AF File Offset: 0x000436AF
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x000454BC File Offset: 0x000436BC
		internal virtual ToolStripMenuItem ToolStripStartOVR
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripStartOVR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripStartOVR_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripStartOVR;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripStartOVR = value;
				toolStripMenuItem = this._ToolStripStartOVR;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x000454FF File Offset: 0x000436FF
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0004550C File Offset: 0x0004370C
		internal virtual ToolStripMenuItem ToolStripStopOVR
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripStopOVR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem5_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripStopOVR;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripStopOVR = value;
				toolStripMenuItem = this._ToolStripStopOVR;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x0004554F File Offset: 0x0004374F
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x0004555C File Offset: 0x0004375C
		internal virtual ToolStripMenuItem ToolStripRestartOVR
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripRestartOVR;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem6_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripRestartOVR;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripRestartOVR = value;
				toolStripMenuItem = this._ToolStripRestartOVR;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x0004559F File Offset: 0x0004379F
		// (set) Token: 0x060006AE RID: 1710 RVA: 0x000455A9 File Offset: 0x000437A9
		internal virtual ToolStripSeparator ToolStripSeparator2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x000455B2 File Offset: 0x000437B2
		// (set) Token: 0x060006B0 RID: 1712 RVA: 0x000455BC File Offset: 0x000437BC
		internal virtual GroupBox GroupBox6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x000455C5 File Offset: 0x000437C5
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x000455CF File Offset: 0x000437CF
		internal virtual ContextMenuStrip ContextMenuStrip2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x000455D8 File Offset: 0x000437D8
		// (set) Token: 0x060006B4 RID: 1716 RVA: 0x000455E4 File Offset: 0x000437E4
		internal virtual ToolStripMenuItem ToolStripMenuItem4
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem4_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem4;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem4 = value;
				toolStripMenuItem = this._ToolStripMenuItem4;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00045627 File Offset: 0x00043827
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x00045634 File Offset: 0x00043834
		internal virtual global::System.Windows.Forms.Timer NotificationTimer
		{
			[CompilerGenerated]
			get
			{
				return this._NotificationTimer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.NotificationTimer_Tick);
				global::System.Windows.Forms.Timer timer = this._NotificationTimer;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._NotificationTimer = value;
				timer = this._NotificationTimer;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00045677 File Offset: 0x00043877
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x00045684 File Offset: 0x00043884
		internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1
		{
			[CompilerGenerated]
			get
			{
				return this._DotNetBarTabcontrol1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.DotNetBarTabcontrol1_SelectedIndexChanged);
				DotNetBarTabcontrol dotNetBarTabcontrol = this._DotNetBarTabcontrol1;
				if (dotNetBarTabcontrol != null)
				{
					dotNetBarTabcontrol.SelectedIndexChanged -= eventHandler;
				}
				this._DotNetBarTabcontrol1 = value;
				dotNetBarTabcontrol = this._DotNetBarTabcontrol1;
				if (dotNetBarTabcontrol != null)
				{
					dotNetBarTabcontrol.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x000456C7 File Offset: 0x000438C7
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x000456D1 File Offset: 0x000438D1
		internal virtual TabPage TabPage1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x000456DA File Offset: 0x000438DA
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000456E4 File Offset: 0x000438E4
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x000456ED File Offset: 0x000438ED
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x000456F8 File Offset: 0x000438F8
		internal virtual Button BtnVoice
		{
			[CompilerGenerated]
			get
			{
				return this._BtnVoice;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnVoice_Click);
				Button button = this._BtnVoice;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnVoice = value;
				button = this._BtnVoice;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0004573B File Offset: 0x0004393B
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x00045745 File Offset: 0x00043945
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x0004574E File Offset: 0x0004394E
		// (set) Token: 0x060006C2 RID: 1730 RVA: 0x00045758 File Offset: 0x00043958
		internal virtual ComboBox ComboSSstart
		{
			[CompilerGenerated]
			get
			{
				return this._ComboSSstart;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboSSstart_SelectedIndexChanged);
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.ComboSSstart_KeyPress);
				ComboBox comboBox = this._ComboSSstart;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
					comboBox.KeyPress -= keyPressEventHandler;
				}
				this._ComboSSstart = value;
				comboBox = this._ComboSSstart;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
					comboBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x000457B6 File Offset: 0x000439B6
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x000457C0 File Offset: 0x000439C0
		internal virtual Button BtnProfiles
		{
			[CompilerGenerated]
			get
			{
				return this._BtnProfiles;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnProfiles_Click);
				Button button = this._BtnProfiles;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnProfiles = value;
				button = this._BtnProfiles;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00045803 File Offset: 0x00043A03
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x0004580D File Offset: 0x00043A0D
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x00045816 File Offset: 0x00043A16
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x00045820 File Offset: 0x00043A20
		internal virtual ComboBox ComboVoice
		{
			[CompilerGenerated]
			get
			{
				return this._ComboVoice;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboVoice_SelectedIndexChanged);
				ComboBox comboBox = this._ComboVoice;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboVoice = value;
				comboBox = this._ComboVoice;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00045863 File Offset: 0x00043A63
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x0004586D File Offset: 0x00043A6D
		internal virtual TabPage TabPage2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00045876 File Offset: 0x00043A76
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x00045880 File Offset: 0x00043A80
		internal virtual CheckBox HotKeysCheckBox
		{
			[CompilerGenerated]
			get
			{
				return this._HotKeysCheckBox;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.HotKeysCheckBox_CheckedChanged);
				CheckBox checkBox = this._HotKeysCheckBox;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._HotKeysCheckBox = value;
				checkBox = this._HotKeysCheckBox;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x000458C3 File Offset: 0x00043AC3
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x000458CD File Offset: 0x00043ACD
		internal virtual TabPage TabPage3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x000458D6 File Offset: 0x00043AD6
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x000458E0 File Offset: 0x00043AE0
		internal virtual GroupBox GroupBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x000458E9 File Offset: 0x00043AE9
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x000458F4 File Offset: 0x00043AF4
		internal virtual ComboBox ComboUSBsusp
		{
			[CompilerGenerated]
			get
			{
				return this._ComboUSBsusp;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboUSBsusp_SelectedIndexChanged);
				ComboBox comboBox = this._ComboUSBsusp;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboUSBsusp = value;
				comboBox = this._ComboUSBsusp;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x00045937 File Offset: 0x00043B37
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x00045941 File Offset: 0x00043B41
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0004594A File Offset: 0x00043B4A
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x00045954 File Offset: 0x00043B54
		internal virtual ComboBox ComboPowerPlanStart
		{
			[CompilerGenerated]
			get
			{
				return this._ComboPowerPlanStart;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboPowerPlan_SelectedIndexChanged);
				ComboBox comboBox = this._ComboPowerPlanStart;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboPowerPlanStart = value;
				comboBox = this._ComboPowerPlanStart;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00045997 File Offset: 0x00043B97
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x000459A1 File Offset: 0x00043BA1
		internal virtual TabPage TabPage4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x000459AA File Offset: 0x00043BAA
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x000459B4 File Offset: 0x00043BB4
		internal virtual TabPage TabPage5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x000459BD File Offset: 0x00043BBD
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x000459C7 File Offset: 0x00043BC7
		internal virtual TabPage TabPage6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x000459D0 File Offset: 0x00043BD0
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x000459DC File Offset: 0x00043BDC
		internal virtual CheckBox CheckMinimizeOnX
		{
			[CompilerGenerated]
			get
			{
				return this._CheckMinimizeOnX;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckMinimizeOnX_CheckedChanged);
				CheckBox checkBox = this._CheckMinimizeOnX;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckMinimizeOnX = value;
				checkBox = this._CheckMinimizeOnX;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00045A1F File Offset: 0x00043C1F
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00045A2C File Offset: 0x00043C2C
		internal virtual PictureBox PictureBox1
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
				PictureBox pictureBox = this._PictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox1 = value;
				pictureBox = this._PictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00045A6F File Offset: 0x00043C6F
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x00045A79 File Offset: 0x00043C79
		internal virtual GroupBox GroupBox9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x00045A82 File Offset: 0x00043C82
		// (set) Token: 0x060006E4 RID: 1764 RVA: 0x00045A8C File Offset: 0x00043C8C
		internal virtual GroupBox GroupBox14
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00045A95 File Offset: 0x00043C95
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x00045A9F File Offset: 0x00043C9F
		internal virtual DBLayoutPanel DbLayoutPanel2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00045AA8 File Offset: 0x00043CA8
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x00045AB2 File Offset: 0x00043CB2
		internal virtual DBLayoutPanel DbLayoutPanel4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x00045ABB File Offset: 0x00043CBB
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x00045AC5 File Offset: 0x00043CC5
		internal virtual DBLayoutPanel DbLayoutPanel5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x00045ACE File Offset: 0x00043CCE
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x00045AD8 File Offset: 0x00043CD8
		internal virtual TrackBar TrackBar1
		{
			[CompilerGenerated]
			get
			{
				return this._TrackBar1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.TrackBar1_Scroll);
				TrackBar trackBar = this._TrackBar1;
				if (trackBar != null)
				{
					trackBar.Scroll -= eventHandler;
				}
				this._TrackBar1 = value;
				trackBar = this._TrackBar1;
				if (trackBar != null)
				{
					trackBar.Scroll += eventHandler;
				}
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x00045B1B File Offset: 0x00043D1B
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x00045B25 File Offset: 0x00043D25
		internal virtual Label Label14
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x00045B2E File Offset: 0x00043D2E
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x00045B38 File Offset: 0x00043D38
		internal virtual DBLayoutPanel DbLayoutPanel6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x00045B41 File Offset: 0x00043D41
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x00045B4B File Offset: 0x00043D4B
		internal virtual DBLayoutPanel DbLayoutPanel7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00045B54 File Offset: 0x00043D54
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x00045B5E File Offset: 0x00043D5E
		internal virtual DBLayoutPanel DbLayoutPanel8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00045B67 File Offset: 0x00043D67
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x00045B71 File Offset: 0x00043D71
		internal virtual GroupBox GroupBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00045B7A File Offset: 0x00043D7A
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x00045B84 File Offset: 0x00043D84
		internal virtual ImageList ImageList1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00045B8D File Offset: 0x00043D8D
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x00045B98 File Offset: 0x00043D98
		internal virtual global::System.Windows.Forms.Timer HometoTrayTimer
		{
			[CompilerGenerated]
			get
			{
				return this._HometoTrayTimer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.HometoTrayTimer_Tick);
				global::System.Windows.Forms.Timer timer = this._HometoTrayTimer;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._HometoTrayTimer = value;
				timer = this._HometoTrayTimer;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00045BDB File Offset: 0x00043DDB
		// (set) Token: 0x060006FC RID: 1788 RVA: 0x00045BE8 File Offset: 0x00043DE8
		internal virtual CheckBox CheckSendHomeToTray
		{
			[CompilerGenerated]
			get
			{
				return this._CheckSendHomeToTray;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckSendHomeToTray_CheckedChanged);
				CheckBox checkBox = this._CheckSendHomeToTray;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckSendHomeToTray = value;
				checkBox = this._CheckSendHomeToTray;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00045C2B File Offset: 0x00043E2B
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x00045C38 File Offset: 0x00043E38
		internal virtual CheckBox CheckSendHomeToTrayOnStart
		{
			[CompilerGenerated]
			get
			{
				return this._CheckSendHomeToTrayOnStart;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckSendHomeToTrayOnStart_CheckedChanged);
				CheckBox checkBox = this._CheckSendHomeToTrayOnStart;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckSendHomeToTrayOnStart = value;
				checkBox = this._CheckSendHomeToTrayOnStart;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00045C7B File Offset: 0x00043E7B
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x00045C85 File Offset: 0x00043E85
		internal virtual TabPage TabPage7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00045C8E File Offset: 0x00043E8E
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x00045C98 File Offset: 0x00043E98
		internal virtual GroupBox GroupBox7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00045CA1 File Offset: 0x00043EA1
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x00045CAB File Offset: 0x00043EAB
		internal virtual DBLayoutPanel DbLayoutPanel1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00045CB4 File Offset: 0x00043EB4
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x00045CC0 File Offset: 0x00043EC0
		internal virtual Button Button4
		{
			[CompilerGenerated]
			get
			{
				return this._Button4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button4_Click);
				Button button = this._Button4;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button4 = value;
				button = this._Button4;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00045D03 File Offset: 0x00043F03
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00045D10 File Offset: 0x00043F10
		internal virtual CheckBox CheckLocalDebug
		{
			[CompilerGenerated]
			get
			{
				return this._CheckLocalDebug;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckLocalDebug_CheckedChanged);
				CheckBox checkBox = this._CheckLocalDebug;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckLocalDebug = value;
				checkBox = this._CheckLocalDebug;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00045D53 File Offset: 0x00043F53
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00045D60 File Offset: 0x00043F60
		internal virtual CheckBox CheckStartWatcher
		{
			[CompilerGenerated]
			get
			{
				return this._CheckStartWatcher;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckStartWatcher_CheckedChanged);
				CheckBox checkBox = this._CheckStartWatcher;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckStartWatcher = value;
				checkBox = this._CheckStartWatcher;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00045DA3 File Offset: 0x00043FA3
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00045DB0 File Offset: 0x00043FB0
		internal virtual Button Button1
		{
			[CompilerGenerated]
			get
			{
				return this._Button1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button1_Click);
				Button button = this._Button1;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button1 = value;
				button = this._Button1;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00045DF3 File Offset: 0x00043FF3
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00045E00 File Offset: 0x00044000
		internal virtual Button Button5
		{
			[CompilerGenerated]
			get
			{
				return this._Button5;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button5_Click);
				Button button = this._Button5;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button5 = value;
				button = this._Button5;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00045E43 File Offset: 0x00044043
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00045E50 File Offset: 0x00044050
		internal virtual CheckBox CheckSensorPower
		{
			[CompilerGenerated]
			get
			{
				return this._CheckSensorPower;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckSensorPower_CheckedChanged);
				CheckBox checkBox = this._CheckSensorPower;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckSensorPower = value;
				checkBox = this._CheckSensorPower;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00045E93 File Offset: 0x00044093
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00045EA0 File Offset: 0x000440A0
		internal virtual ComboBox ComboPowerPlanExit
		{
			[CompilerGenerated]
			get
			{
				return this._ComboPowerPlanExit;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboPowerPlanExit_SelectedIndexChanged);
				ComboBox comboBox = this._ComboPowerPlanExit;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboPowerPlanExit = value;
				comboBox = this._ComboPowerPlanExit;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00045EE3 File Offset: 0x000440E3
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00045EED File Offset: 0x000440ED
		internal virtual Label Label22
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00045EF6 File Offset: 0x000440F6
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00045F00 File Offset: 0x00044100
		internal virtual Button BtnConfigureAudio
		{
			[CompilerGenerated]
			get
			{
				return this._BtnConfigureAudio;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnConfigureAudio_Click);
				Button button = this._BtnConfigureAudio;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnConfigureAudio = value;
				button = this._BtnConfigureAudio;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00045F43 File Offset: 0x00044143
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00045F50 File Offset: 0x00044150
		internal virtual ComboBox ComboApplyPlan
		{
			[CompilerGenerated]
			get
			{
				return this._ComboApplyPlan;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboApplyPlan_SelectedIndexChanged);
				ComboBox comboBox = this._ComboApplyPlan;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboApplyPlan = value;
				comboBox = this._ComboApplyPlan;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00045F93 File Offset: 0x00044193
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00045F9D File Offset: 0x0004419D
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00045FA6 File Offset: 0x000441A6
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00045FB0 File Offset: 0x000441B0
		internal virtual Label Label23
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00045FB9 File Offset: 0x000441B9
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00045FC3 File Offset: 0x000441C3
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00045FCC File Offset: 0x000441CC
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00045FD6 File Offset: 0x000441D6
		internal virtual Label LabelVer
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00045FDF File Offset: 0x000441DF
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00045FE9 File Offset: 0x000441E9
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00045FF2 File Offset: 0x000441F2
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00045FFC File Offset: 0x000441FC
		internal virtual Button Button9
		{
			[CompilerGenerated]
			get
			{
				return this._Button9;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button9_Click);
				Button button = this._Button9;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button9 = value;
				button = this._Button9;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x0004603F File Offset: 0x0004423F
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x0004604C File Offset: 0x0004424C
		internal virtual Button Button8
		{
			[CompilerGenerated]
			get
			{
				return this._Button8;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button8_Click);
				Button button = this._Button8;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button8 = value;
				button = this._Button8;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x0004608F File Offset: 0x0004428F
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x00046099 File Offset: 0x00044299
		internal virtual Label LabelDownloadStatus
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x000460A2 File Offset: 0x000442A2
		// (set) Token: 0x0600072A RID: 1834 RVA: 0x000460AC File Offset: 0x000442AC
		internal virtual PictureBox PictureBox2
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox2_Click);
				PictureBox pictureBox = this._PictureBox2;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox2 = value;
				pictureBox = this._PictureBox2;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x000460EF File Offset: 0x000442EF
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x000460FC File Offset: 0x000442FC
		internal virtual CheckBox CheckBoxCheckForUpdates
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBoxCheckForUpdates;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBoxCheckForUpdates_CheckedChanged);
				CheckBox checkBox = this._CheckBoxCheckForUpdates;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckBoxCheckForUpdates = value;
				checkBox = this._CheckBoxCheckForUpdates;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x0004613F File Offset: 0x0004433F
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x00046149 File Offset: 0x00044349
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00046152 File Offset: 0x00044352
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x0004615C File Offset: 0x0004435C
		internal virtual Label Label15
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00046165 File Offset: 0x00044365
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x0004616F File Offset: 0x0004436F
		internal virtual NumericUpDown NumericFOVh
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x00046178 File Offset: 0x00044378
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x00046184 File Offset: 0x00044384
		internal virtual Button Button2
		{
			[CompilerGenerated]
			get
			{
				return this._Button2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button2_Click);
				Button button = this._Button2;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button2 = value;
				button = this._Button2;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x000461C7 File Offset: 0x000443C7
		// (set) Token: 0x06000736 RID: 1846 RVA: 0x000461D1 File Offset: 0x000443D1
		internal virtual Label Label16
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x000461DA File Offset: 0x000443DA
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x000461E4 File Offset: 0x000443E4
		internal virtual ComboBox ComboHomless
		{
			[CompilerGenerated]
			get
			{
				return this._ComboHomless;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboHomless_SelectedIndexChanged);
				ComboBox comboBox = this._ComboHomless;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboHomless = value;
				comboBox = this._ComboHomless;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x00046227 File Offset: 0x00044427
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x00046234 File Offset: 0x00044434
		internal virtual Button BtnHomless
		{
			[CompilerGenerated]
			get
			{
				return this._BtnHomless;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnHomless_Click);
				Button button = this._BtnHomless;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnHomless = value;
				button = this._BtnHomless;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x00046277 File Offset: 0x00044477
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x00046284 File Offset: 0x00044484
		internal virtual global::System.Windows.Forms.Timer UpdateTimer
		{
			[CompilerGenerated]
			get
			{
				return this._UpdateTimer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.UpdateTimer_Tick);
				global::System.Windows.Forms.Timer timer = this._UpdateTimer;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._UpdateTimer = value;
				timer = this._UpdateTimer;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x000462C7 File Offset: 0x000444C7
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x000462D4 File Offset: 0x000444D4
		internal virtual ToolStripMenuItem ToolStripMenuShowHome
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuShowHome;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuShowHome_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuShowHome;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuShowHome = value;
				toolStripMenuItem = this._ToolStripMenuShowHome;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x00046317 File Offset: 0x00044517
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x00046321 File Offset: 0x00044521
		internal virtual Label Label9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0004632A File Offset: 0x0004452A
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x00046334 File Offset: 0x00044534
		internal virtual ComboBox ComboVisualHUD
		{
			[CompilerGenerated]
			get
			{
				return this._ComboVisualHUD;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboVisualHUD_SelectedIndexChanged);
				ComboBox comboBox = this._ComboVisualHUD;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboVisualHUD = value;
				comboBox = this._ComboVisualHUD;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00046377 File Offset: 0x00044577
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x00046381 File Offset: 0x00044581
		internal virtual Label Label17
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x0004638A File Offset: 0x0004458A
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x00046394 File Offset: 0x00044594
		internal virtual ComboBox ComboMirrorHome
		{
			[CompilerGenerated]
			get
			{
				return this._ComboMirrorHome;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboMirrorHome_SelectedIndexChanged);
				ComboBox comboBox = this._ComboMirrorHome;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboMirrorHome = value;
				comboBox = this._ComboMirrorHome;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x000463D7 File Offset: 0x000445D7
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x000463E4 File Offset: 0x000445E4
		internal virtual CheckBox CheckRestartSleep
		{
			[CompilerGenerated]
			get
			{
				return this._CheckRestartSleep;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckRestartSleep_CheckedChanged);
				CheckBox checkBox = this._CheckRestartSleep;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckRestartSleep = value;
				checkBox = this._CheckRestartSleep;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x00046427 File Offset: 0x00044627
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x00046434 File Offset: 0x00044634
		internal virtual Button BtnSteamImport
		{
			[CompilerGenerated]
			get
			{
				return this._BtnSteamImport;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnSteamImport_Click);
				Button button = this._BtnSteamImport;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnSteamImport = value;
				button = this._BtnSteamImport;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x00046477 File Offset: 0x00044677
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x00046484 File Offset: 0x00044684
		internal virtual NotifyIcon NotifyIcon3
		{
			[CompilerGenerated]
			get
			{
				return this._NotifyIcon3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.NotifyIcon3_MouseDown);
				NotifyIcon notifyIcon = this._NotifyIcon3;
				if (notifyIcon != null)
				{
					notifyIcon.MouseDown -= mouseEventHandler;
				}
				this._NotifyIcon3 = value;
				notifyIcon = this._NotifyIcon3;
				if (notifyIcon != null)
				{
					notifyIcon.MouseDown += mouseEventHandler;
				}
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x000464C7 File Offset: 0x000446C7
		// (set) Token: 0x0600074E RID: 1870 RVA: 0x000464D4 File Offset: 0x000446D4
		internal virtual Button BtnConfigureHotKeys
		{
			[CompilerGenerated]
			get
			{
				return this._BtnConfigureHotKeys;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnConfigureHotKeys_Click);
				Button button = this._BtnConfigureHotKeys;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnConfigureHotKeys = value;
				button = this._BtnConfigureHotKeys;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x00046517 File Offset: 0x00044717
		// (set) Token: 0x06000750 RID: 1872 RVA: 0x00046524 File Offset: 0x00044724
		internal virtual ToolStripMenuItem ClearLogToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._ClearLogToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ClearLogToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._ClearLogToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ClearLogToolStripMenuItem = value;
				toolStripMenuItem = this._ClearLogToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00046567 File Offset: 0x00044767
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x00046574 File Offset: 0x00044774
		internal virtual ToolStripMenuItem OpenLogToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._OpenLogToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.OpenLogToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._OpenLogToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._OpenLogToolStripMenuItem = value;
				toolStripMenuItem = this._OpenLogToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x000465B7 File Offset: 0x000447B7
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x000465C1 File Offset: 0x000447C1
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x000465CA File Offset: 0x000447CA
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x000465D4 File Offset: 0x000447D4
		internal virtual Label Label18
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x000465DD File Offset: 0x000447DD
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x000465E7 File Offset: 0x000447E7
		internal virtual Label Label24
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x000465F0 File Offset: 0x000447F0
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x000465FA File Offset: 0x000447FA
		internal virtual Label Label25
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x00046603 File Offset: 0x00044803
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x0004660D File Offset: 0x0004480D
		internal virtual Label Label26
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x00046616 File Offset: 0x00044816
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x00046620 File Offset: 0x00044820
		internal virtual Label Label27
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00046629 File Offset: 0x00044829
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x00046633 File Offset: 0x00044833
		internal virtual Label Label28
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0004663C File Offset: 0x0004483C
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x00046646 File Offset: 0x00044846
		internal virtual Label Label29
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0004664F File Offset: 0x0004484F
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x0004665C File Offset: 0x0004485C
		internal virtual Button BtnLibrary
		{
			[CompilerGenerated]
			get
			{
				return this._BtnLibrary;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnLibrary_Click);
				Button button = this._BtnLibrary;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnLibrary = value;
				button = this._BtnLibrary;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x0004669F File Offset: 0x0004489F
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x000466AC File Offset: 0x000448AC
		internal virtual global::System.Windows.Forms.Timer PowerPlanTimer
		{
			[CompilerGenerated]
			get
			{
				return this._PowerPlanTimer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PowerPlanTimer_Tick);
				global::System.Windows.Forms.Timer timer = this._PowerPlanTimer;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._PowerPlanTimer = value;
				timer = this._PowerPlanTimer;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x000466EF File Offset: 0x000448EF
		// (set) Token: 0x06000768 RID: 1896 RVA: 0x000466F9 File Offset: 0x000448F9
		internal virtual TabPage TabPage8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x00046702 File Offset: 0x00044902
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x0004670C File Offset: 0x0004490C
		internal virtual GroupBox GroupBox5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x00046715 File Offset: 0x00044915
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x0004671F File Offset: 0x0004491F
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x00046728 File Offset: 0x00044928
		// (set) Token: 0x0600076E RID: 1902 RVA: 0x00046734 File Offset: 0x00044934
		internal virtual ComboBox ComboBox3
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.ComboBox3_KeyPress);
				ComboBox comboBox = this._ComboBox3;
				if (comboBox != null)
				{
					comboBox.KeyPress -= keyPressEventHandler;
				}
				this._ComboBox3 = value;
				comboBox = this._ComboBox3;
				if (comboBox != null)
				{
					comboBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x00046777 File Offset: 0x00044977
		// (set) Token: 0x06000770 RID: 1904 RVA: 0x00046781 File Offset: 0x00044981
		internal virtual ComboBox ComboBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x0004678A File Offset: 0x0004498A
		// (set) Token: 0x06000772 RID: 1906 RVA: 0x00046794 File Offset: 0x00044994
		internal virtual Label Label31
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x0004679D File Offset: 0x0004499D
		// (set) Token: 0x06000774 RID: 1908 RVA: 0x000467A7 File Offset: 0x000449A7
		internal virtual Label Label30
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x000467B0 File Offset: 0x000449B0
		// (set) Token: 0x06000776 RID: 1910 RVA: 0x000467BC File Offset: 0x000449BC
		internal virtual ComboBox ComboBox4
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox4_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox4;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox4 = value;
				comboBox = this._ComboBox4;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x000467FF File Offset: 0x000449FF
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x00046809 File Offset: 0x00044A09
		internal virtual Label Label32
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00046812 File Offset: 0x00044A12
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x0004681C File Offset: 0x00044A1C
		internal virtual Button Button10
		{
			[CompilerGenerated]
			get
			{
				return this._Button10;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button10_Click);
				Button button = this._Button10;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button10 = value;
				button = this._Button10;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x0004685F File Offset: 0x00044A5F
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x0004686C File Offset: 0x00044A6C
		internal virtual Button Button11
		{
			[CompilerGenerated]
			get
			{
				return this._Button11;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button11_Click);
				Button button = this._Button11;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button11 = value;
				button = this._Button11;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x000468AF File Offset: 0x00044AAF
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x000468B9 File Offset: 0x00044AB9
		internal virtual DBLayoutPanel DbLayoutPanel3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x000468C2 File Offset: 0x00044AC2
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x000468CC File Offset: 0x00044ACC
		internal virtual Button Button12
		{
			[CompilerGenerated]
			get
			{
				return this._Button12;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button12_Click);
				Button button = this._Button12;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button12 = value;
				button = this._Button12;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0004690F File Offset: 0x00044B0F
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x0004691C File Offset: 0x00044B1C
		internal virtual Button BtnRemoveAllProfiles
		{
			[CompilerGenerated]
			get
			{
				return this._BtnRemoveAllProfiles;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnRemoveAllProfiles_Click);
				EventHandler eventHandler2 = new EventHandler(this.Button1_Click);
				Button button = this._BtnRemoveAllProfiles;
				if (button != null)
				{
					button.Click -= eventHandler;
					button.Click -= eventHandler2;
				}
				this._BtnRemoveAllProfiles = value;
				button = this._BtnRemoveAllProfiles;
				if (button != null)
				{
					button.Click += eventHandler;
					button.Click += eventHandler2;
				}
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x0004697A File Offset: 0x00044B7A
		// (set) Token: 0x06000784 RID: 1924 RVA: 0x00046984 File Offset: 0x00044B84
		internal virtual ComboBox ComboBox1
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox1;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox1 = value;
				comboBox = this._ComboBox1;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x000469C7 File Offset: 0x00044BC7
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x000469D1 File Offset: 0x00044BD1
		internal virtual Label Label35
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x000469DA File Offset: 0x00044BDA
		// (set) Token: 0x06000788 RID: 1928 RVA: 0x000469E4 File Offset: 0x00044BE4
		internal virtual ComboBox ComboBox5
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox5;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox5_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox5;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox5 = value;
				comboBox = this._ComboBox5;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x00046A27 File Offset: 0x00044C27
		// (set) Token: 0x0600078A RID: 1930 RVA: 0x00046A31 File Offset: 0x00044C31
		internal virtual SplitContainer SplitContainer1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x00046A3A File Offset: 0x00044C3A
		// (set) Token: 0x0600078C RID: 1932 RVA: 0x00046A44 File Offset: 0x00044C44
		internal virtual NumericUpDown NumericFOVv
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x00046A4D File Offset: 0x00044C4D
		// (set) Token: 0x0600078E RID: 1934 RVA: 0x00046A57 File Offset: 0x00044C57
		internal virtual Label Label36
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x00046A60 File Offset: 0x00044C60
		// (set) Token: 0x06000790 RID: 1936 RVA: 0x00046A6A File Offset: 0x00044C6A
		internal virtual ComboBox ComboBox6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x00046A73 File Offset: 0x00044C73
		// (set) Token: 0x06000792 RID: 1938 RVA: 0x00046A7D File Offset: 0x00044C7D
		internal virtual Label Label19
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x00046A86 File Offset: 0x00044C86
		// (set) Token: 0x06000794 RID: 1940 RVA: 0x00046A90 File Offset: 0x00044C90
		internal virtual ComboBox ComboOVRPrio
		{
			[CompilerGenerated]
			get
			{
				return this._ComboOVRPrio;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboOVRPrio_SelectedIndexChanged);
				ComboBox comboBox = this._ComboOVRPrio;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboOVRPrio = value;
				comboBox = this._ComboOVRPrio;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x00046AD3 File Offset: 0x00044CD3
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x00046AE0 File Offset: 0x00044CE0
		internal virtual Button Button3
		{
			[CompilerGenerated]
			get
			{
				return this._Button3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button3_Click);
				Button button = this._Button3;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button3 = value;
				button = this._Button3;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x00046B23 File Offset: 0x00044D23
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x00046B2D File Offset: 0x00044D2D
		internal virtual Label Label20
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00046B36 File Offset: 0x00044D36
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x00046B40 File Offset: 0x00044D40
		internal virtual ComboBox ComboBox7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x00046B49 File Offset: 0x00044D49
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x00046B53 File Offset: 0x00044D53
		internal virtual Label Label21
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00046B5C File Offset: 0x00044D5C
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x00046B68 File Offset: 0x00044D68
		internal virtual Button Button6
		{
			[CompilerGenerated]
			get
			{
				return this._Button6;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button6_Click);
				Button button = this._Button6;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button6 = value;
				button = this._Button6;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00046BAB File Offset: 0x00044DAB
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x00046BB5 File Offset: 0x00044DB5
		internal virtual PictureBox PictureBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00046BBE File Offset: 0x00044DBE
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x00046BC8 File Offset: 0x00044DC8
		internal virtual Label Label34
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x00046BD1 File Offset: 0x00044DD1
		// (set) Token: 0x060007A4 RID: 1956 RVA: 0x00046BDB File Offset: 0x00044DDB
		internal virtual Label Label33
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x00046BE4 File Offset: 0x00044DE4
		// (set) Token: 0x060007A6 RID: 1958 RVA: 0x00046BF0 File Offset: 0x00044DF0
		internal virtual ComboBox ComboBox8
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox8;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox8_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox8;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox8 = value;
				comboBox = this._ComboBox8;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x00046C33 File Offset: 0x00044E33
		// (set) Token: 0x060007A8 RID: 1960 RVA: 0x00046C3D File Offset: 0x00044E3D
		internal virtual Label Label37
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x00046C46 File Offset: 0x00044E46
		// (set) Token: 0x060007AA RID: 1962 RVA: 0x00046C50 File Offset: 0x00044E50
		internal virtual ComboBox ComboBox9
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox9;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox9_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox9;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox9 = value;
				comboBox = this._ComboBox9;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x00046C93 File Offset: 0x00044E93
		// (set) Token: 0x060007AC RID: 1964 RVA: 0x00046C9D File Offset: 0x00044E9D
		internal virtual Label Label38
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x00046CA6 File Offset: 0x00044EA6
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x00046CB0 File Offset: 0x00044EB0
		internal virtual ComboBox ComboBox10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x00046CB9 File Offset: 0x00044EB9
		// (set) Token: 0x060007B0 RID: 1968 RVA: 0x00046CC3 File Offset: 0x00044EC3
		internal virtual ComboBox ComboBox11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x00046CCC File Offset: 0x00044ECC
		// (set) Token: 0x060007B2 RID: 1970 RVA: 0x00046CD6 File Offset: 0x00044ED6
		internal virtual Label Label39
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00046CDF File Offset: 0x00044EDF
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x00046CE9 File Offset: 0x00044EE9
		internal virtual PictureBox PictureBox6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x00046CF2 File Offset: 0x00044EF2
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x00046CFC File Offset: 0x00044EFC
		internal virtual PictureBox PictureBox5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x00046D05 File Offset: 0x00044F05
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x00046D0F File Offset: 0x00044F0F
		internal virtual PictureBox PictureBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x00046D18 File Offset: 0x00044F18
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x00046D22 File Offset: 0x00044F22
		internal virtual PictureBox PictureBox7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x00046D2B File Offset: 0x00044F2B
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x00046D35 File Offset: 0x00044F35
		internal virtual PictureBox PictureBox8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x00046D3E File Offset: 0x00044F3E
		// (set) Token: 0x060007BE RID: 1982 RVA: 0x00046D48 File Offset: 0x00044F48
		internal virtual CheckBox CheckStopServiceHome
		{
			[CompilerGenerated]
			get
			{
				return this._CheckStopServiceHome;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckStopServiceHome_CheckedChanged);
				CheckBox checkBox = this._CheckStopServiceHome;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckStopServiceHome = value;
				checkBox = this._CheckStopServiceHome;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x04000256 RID: 598
		public static object lockObject;

		// Token: 0x04000257 RID: 599
		private Resizer rs;

		// Token: 0x04000258 RID: 600
		public bool Is64Bit;

		// Token: 0x04000259 RID: 601
		public Dictionary<string, string> profileList;

		// Token: 0x0400025A RID: 602
		public Dictionary<string, string> profileTimerList;

		// Token: 0x0400025B RID: 603
		public Dictionary<string, string> profileASWList;

		// Token: 0x0400025C RID: 604
		public Dictionary<string, string> profilePriorityList;

		// Token: 0x0400025D RID: 605
		public string aswProfileMode;

		// Token: 0x0400025E RID: 606
		public List<string> profileNames;

		// Token: 0x0400025F RID: 607
		public Dictionary<string, string> profileDisplayNames;

		// Token: 0x04000260 RID: 608
		public Dictionary<string, string> profileAswDelay;

		// Token: 0x04000261 RID: 609
		public Dictionary<string, string> profileCpuDelay;

		// Token: 0x04000262 RID: 610
		public Dictionary<string, string> profilePaths;

		// Token: 0x04000263 RID: 611
		public Dictionary<string, string> profileMirror;

		// Token: 0x04000264 RID: 612
		public Dictionary<string, string> profileAGPS;

		// Token: 0x04000265 RID: 613
		public Dictionary<string, string> profileFOV;

		// Token: 0x04000266 RID: 614
		public Dictionary<string, string> profileForceMipMap;

		// Token: 0x04000267 RID: 615
		public Dictionary<string, string> profileOffsetMipMap;

		// Token: 0x04000268 RID: 616
		public string runningApp;

		// Token: 0x04000269 RID: 617
		public bool hasError;

		// Token: 0x0400026A RID: 618
		public bool hasWarning;

		// Token: 0x0400026B RID: 619
		private string ssValue;

		// Token: 0x0400026C RID: 620
		private bool OculusServiceFound;

		// Token: 0x0400026D RID: 621
		public CultureInfo customCulture;

		// Token: 0x0400026E RID: 622
		public Dictionary<string, string> power_plans;

		// Token: 0x0400026F RID: 623
		public bool debug;

		// Token: 0x04000270 RID: 624
		public bool RiftAudioCanceled;

		// Token: 0x04000271 RID: 625
		public object scaleX;

		// Token: 0x04000272 RID: 626
		public object scaleY;

		// Token: 0x04000273 RID: 627
		public string OculusPath;

		// Token: 0x04000274 RID: 628
		public bool HomeIsRunning;

		// Token: 0x04000275 RID: 629
		private bool OVRIsRunning;

		// Token: 0x04000276 RID: 630
		public bool spoofid;

		// Token: 0x04000277 RID: 631
		private string cpuid;

		// Token: 0x04000278 RID: 632
		public string CurrentSS;

		// Token: 0x04000279 RID: 633
		public bool isElevated;

		// Token: 0x0400027A RID: 634
		public bool loadingDone;

		// Token: 0x0400027B RID: 635
		public string SteamPath;

		// Token: 0x0400027C RID: 636
		public List<string> OculusSoftwarePaths;

		// Token: 0x0400027F RID: 639
		public TabPage UpdateTab;

		// Token: 0x04000280 RID: 640
		public Collection colRemovedTabs;

		// Token: 0x04000281 RID: 641
		public string steamvr;

		// Token: 0x04000282 RID: 642
		public string OculusAppVersion;

		// Token: 0x04000283 RID: 643
		private string appName;

		// Token: 0x04000284 RID: 644
		public string runningapp_displayname;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.Timer Hometimer;

		// Token: 0x04000286 RID: 646
		public global::System.Timers.Timer pTimer;

		// Token: 0x04000287 RID: 647
		public bool ManualStart;

		// Token: 0x04000288 RID: 648
		private bool restartInDBG;

		// Token: 0x04000289 RID: 649
		public List<string> ignoredApps;

		// Token: 0x0400028A RID: 650
		public List<string> includedApps;

		// Token: 0x0400028B RID: 651
		public List<string> voiceProfileNames;

		// Token: 0x0400028C RID: 652
		public static FrmMain fmain;

		// Token: 0x0400028D RID: 653
		private bool ovrDown;

		// Token: 0x0400028E RID: 654
		public string Update_URL;

		// Token: 0x0400028F RID: 655
		public string UpdateTest_URL;

		// Token: 0x04000290 RID: 656
		public bool voiceSettingsLoaded;

		// Token: 0x04000291 RID: 657
		private global::System.Timers.Timer _Home2Timer;

		// Token: 0x04000292 RID: 658
		private bool restartHome;

		// Token: 0x04000293 RID: 659
		public string vrManifestFileName;

		// Token: 0x04000294 RID: 660
		public global::System.Timers.Timer mirrorTimer;

		// Token: 0x04000295 RID: 661
		public bool StartingUp;

		// Token: 0x04000296 RID: 662
		private List<string> AswToggle;

		// Token: 0x04000297 RID: 663
		private global::System.Timers.Timer cpuTimer;

		// Token: 0x04000298 RID: 664
		private global::System.Timers.Timer aswTimer;

		// Token: 0x04000299 RID: 665
		private BackgroundWorker AppWatchWorker;

		// Token: 0x0400029A RID: 666
		public Dictionary<string, string> AllAppsList;

		// Token: 0x0400029B RID: 667
		private bool NoProfileFound;

		// Token: 0x0400029C RID: 668
		private int numLogMessages;

		// Token: 0x0400029D RID: 669
		public string runningAppExe;

		// Token: 0x0400029E RID: 670
		public int pid;

		// Token: 0x040002A0 RID: 672
		public bool HomeIsMirrored;

		// Token: 0x040002A1 RID: 673
		public Dictionary<string, string> FuncToKeyDictionary;

		// Token: 0x040002A2 RID: 674
		private List<string> NextASW;

		// Token: 0x040002A3 RID: 675
		private int CurrentASW;

		// Token: 0x040002A4 RID: 676
		private List<string> NextHUD;

		// Token: 0x040002A5 RID: 677
		private int CurrentHUD;

		// Token: 0x040002A6 RID: 678
		public bool isCopy;

		// Token: 0x040002A7 RID: 679
		private string DSep;

		// Token: 0x02000086 RID: 134
		// (Invoke) Token: 0x06000A57 RID: 2647
		private delegate void TimerStart();

		// Token: 0x02000087 RID: 135
		// (Invoke) Token: 0x06000A5B RID: 2651
		private delegate void AppTimerStart();

		// Token: 0x02000088 RID: 136
		// (Invoke) Token: 0x06000A5F RID: 2655
		public delegate void AddToListboxAndScrollDelegate(string text);

		// Token: 0x02000089 RID: 137
		// (Invoke) Token: 0x06000A63 RID: 2659
		public delegate void UpdateTabDelegate();

		// Token: 0x0200008A RID: 138
		// (Invoke) Token: 0x06000A67 RID: 2663
		public delegate void ShowUpdateToastDelegate();

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x06000A6B RID: 2667
		public delegate void EnableShowHomeMenuDelegate();

		// Token: 0x0200008C RID: 140
		// (Invoke) Token: 0x06000A6F RID: 2671
		public delegate void DisableShowHomeMenuDelegate();

		// Token: 0x0200008D RID: 141
		// (Invoke) Token: 0x06000A73 RID: 2675
		public delegate void SetTitleIsListeningDelegate();

		// Token: 0x0200008E RID: 142
		// (Invoke) Token: 0x06000A77 RID: 2679
		public delegate void RemoveTitleIsListeningDelegate();

		// Token: 0x0200008F RID: 143
		// (Invoke) Token: 0x06000A7B RID: 2683
		public delegate void SetToolTipDelegate(string text, Control crtl);
	}
}
