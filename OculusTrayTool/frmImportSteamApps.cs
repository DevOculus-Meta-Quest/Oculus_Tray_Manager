using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmImportSteamApps : Form
{
	private delegate T Func<T>();

	private delegate void Func();

	[CompilerGenerated]
	internal sealed class _Closure_0024__189_002D0
	{
		public List<SteamNode> _0024VB_0024Local_steamList;

		public frmProcessing _0024VB_0024Local_frmProcessing;

		public BackgroundWorker _0024VB_0024Local_backgroundWorker;

		public frmImportSteamApps _0024VB_0024Me;

		public DownloadProgressChangedEventHandler _0024I1;

		public _Closure_0024__189_002D0(_Closure_0024__189_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_steamList = arg0._0024VB_0024Local_steamList;
				_0024VB_0024Local_frmProcessing = arg0._0024VB_0024Local_frmProcessing;
				_0024VB_0024Local_backgroundWorker = arg0._0024VB_0024Local_backgroundWorker;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(object sender, DoWorkEventArgs e)
		{
			foreach (SteamNode _0024VB_0024Local_steam in _0024VB_0024Local_steamList)
			{
				if (_0024VB_0024Me.TryRemoveApp(_0024VB_0024Local_frmProcessing, _0024VB_0024Local_steam))
				{
					Log.WriteToLog("Importing '" + _0024VB_0024Local_steam.Name + "'");
					Globals.oculus.TryCreateManifest(_0024VB_0024Local_steam, SteamLaunchType.App);
					Globals.oculus.TryDownloadAppHeader(_0024VB_0024Local_steam, [SpecialName] (object _sender, DownloadProgressChangedEventArgs _e) =>
					{
						object[] array = (object[])_e.UserState;
						Uri uri = (Uri)array[0];
						object objectValue = RuntimeHelpers.GetObjectValue(array[1]);
						object objectValue2 = RuntimeHelpers.GetObjectValue(array[2]);
						_0024VB_0024Local_frmProcessing.UpdateProgressBar(_e.ProgressPercentage, $"Downloading '{RuntimeHelpers.GetObjectValue(objectValue2)}'...");
					});
				}
			}
			Globals.oculus.TryRestartOculusService();
		}

		[SpecialName]
		internal void _Lambda_0024__1(object _sender, DownloadProgressChangedEventArgs _e)
		{
			object[] array = (object[])_e.UserState;
			Uri uri = (Uri)array[0];
			object objectValue = RuntimeHelpers.GetObjectValue(array[1]);
			object objectValue2 = RuntimeHelpers.GetObjectValue(array[2]);
			_0024VB_0024Local_frmProcessing.UpdateProgressBar(_e.ProgressPercentage, $"Downloading '{RuntimeHelpers.GetObjectValue(objectValue2)}'...");
		}

		[SpecialName]
		internal void _Lambda_0024__2(object sender, RunWorkerCompletedEventArgs e)
		{
			_0024VB_0024Local_backgroundWorker.Dispose();
			_0024VB_0024Local_frmProcessing.Close();
			_0024VB_0024Me.UpdateAppListView();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__191_002D0
	{
		public List<SteamNode> _0024VB_0024Local_steamList;

		public frmProcessing _0024VB_0024Local_frmProcessing;

		public object _0024VB_0024Local_syncObject;

		public BackgroundWorker _0024VB_0024Local_backgroundWorker;

		public frmImportSteamApps _0024VB_0024Me;

		public EventHandler<FileDownloadProgressChangedEventArgs> _0024I1;

		public EventHandler<EventArgs> _0024I2;

		public _Closure_0024__191_002D0(_Closure_0024__191_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_steamList = arg0._0024VB_0024Local_steamList;
				_0024VB_0024Local_frmProcessing = arg0._0024VB_0024Local_frmProcessing;
				_0024VB_0024Local_syncObject = arg0._0024VB_0024Local_syncObject;
				_0024VB_0024Local_backgroundWorker = arg0._0024VB_0024Local_backgroundWorker;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(object sender, DoWorkEventArgs e)
		{
			string path = Path.Combine(Application.StartupPath, "Assets");
			List<DownloadFileNode> list = new List<DownloadFileNode>();
			foreach (SteamNode _0024VB_0024Local_steam in _0024VB_0024Local_steamList)
			{
				string tempPath = Path.GetTempPath();
				string text = Path.Combine(tempPath, $"{_0024VB_0024Local_steam.AppId}.json");
				if (!Globals.steam.TryDownloadAppDetails(_0024VB_0024Local_steam.AppId, text))
				{
					continue;
				}
				string appDetailsText = File.ReadAllText(text);
				if (!_0024VB_0024Local_steam.TryParseAppDetails(appDetailsText))
				{
					continue;
				}
				foreach (SteamScreenshotNode screenshot in _0024VB_0024Local_steam.ScreenshotList)
				{
					Uri uri = new Uri(screenshot.FullPath);
					string destinationFolder = Path.Combine(path, _0024VB_0024Local_steam.AppId.ToString());
					DownloadFileNode item = new DownloadFileNode(screenshot.FullPath, destinationFolder);
					if (MyProject.Forms.FrmMain.debug)
					{
						Log.WriteToLog(screenshot.FullPath.ToString() + " added to download list");
					}
					list.Add(item);
				}
			}
			FileDownloader fileDownloader = new FileDownloader(list);
			fileDownloader.FileDownloadProgressChanged += [SpecialName] (object _sender, FileDownloadProgressChangedEventArgs _e) =>
			{
				_0024VB_0024Local_frmProcessing.UpdateProgressBar(_e.TotalProgressPercentage, "Downloading Assets...");
			};
			fileDownloader.AllFilesDownloadCompleted += [SpecialName] (object _sender, EventArgs _e) =>
			{
				object obj2 = _0024VB_0024Local_syncObject;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
				bool lockTaken2 = false;
				try
				{
					Monitor.Enter(obj2, ref lockTaken2);
					Monitor.Pulse(RuntimeHelpers.GetObjectValue(_0024VB_0024Local_syncObject));
				}
				finally
				{
					if (lockTaken2)
					{
						Monitor.Exit(obj2);
					}
				}
			};
			object obj = _0024VB_0024Local_syncObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				fileDownloader.Start();
				Monitor.Wait(RuntimeHelpers.GetObjectValue(_0024VB_0024Local_syncObject));
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1(object _sender, FileDownloadProgressChangedEventArgs _e)
		{
			_0024VB_0024Local_frmProcessing.UpdateProgressBar(_e.TotalProgressPercentage, "Downloading Assets...");
		}

		[SpecialName]
		internal void _Lambda_0024__2(object _sender, EventArgs _e)
		{
			object obj = _0024VB_0024Local_syncObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				Monitor.Pulse(RuntimeHelpers.GetObjectValue(_0024VB_0024Local_syncObject));
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3(object sender, RunWorkerCompletedEventArgs e)
		{
			_0024VB_0024Local_backgroundWorker.Dispose();
			_0024VB_0024Local_frmProcessing.Close();
			_0024VB_0024Me.UpdateAppListView();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__195_002D0
	{
		public Control _0024VB_0024Local_control;

		public SteamNode _0024VB_0024Local_steamNode;

		public _Closure_0024__195_002D0(_Closure_0024__195_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_control = arg0._0024VB_0024Local_control;
				_0024VB_0024Local_steamNode = arg0._0024VB_0024Local_steamNode;
			}
		}

		[SpecialName]
		internal DialogResult _Lambda_0024__0()
		{
			return MessageBox.Show(_0024VB_0024Local_control, $"'{_0024VB_0024Local_steamNode.Name}' Is In Your Library.\r\nDo You Want To Delete It?", "Delete App?", MessageBoxButtons.YesNo);
		}
	}

	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lvwAppList")]
	private ListView _lvwAppList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbImportApps")]
	private ToolStripButton _tsbImportApps;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbDownloadAssets")]
	private ToolStripButton _tsbDownloadAssets;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsmiOpenFileLocation")]
	private ToolStripMenuItem _tsmiOpenFileLocation;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsmiLaunchApp")]
	private ToolStripMenuItem _tsmiLaunchApp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbRemoveApps")]
	private ToolStripButton _tsbRemoveApps;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbRefresh")]
	private ToolStripButton _tsbRefresh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbSelectAll")]
	private ToolStripButton _tsbSelectAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbClear")]
	private ToolStripButton _tsbClear;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbStartService")]
	private ToolStripButton _tsbStartService;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbStopService")]
	private ToolStripButton _tsbStopService;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tscbVrManifest")]
	private ToolStripCheckBox _tscbVrManifest;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbSearch")]
	private ToolStripButton _tsbSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsbRestartService")]
	private ToolStripButton _tsbRestartService;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pictureBox1")]
	private PictureBox _pictureBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsslHeadsoftLogo")]
	private ToolStripStatusLabel _tsslHeadsoftLogo;

	private ListViewColumnSorter m_lvwColumnSorter;

	internal virtual ListView lvwAppList
	{
		[CompilerGenerated]
		get
		{
			return _lvwAppList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ColumnClickEventHandler value2 = lvwAppList_ColumnClick;
			ListView listView = _lvwAppList;
			if (listView != null)
			{
				listView.ColumnClick -= value2;
			}
			_lvwAppList = value;
			listView = _lvwAppList;
			if (listView != null)
			{
				listView.ColumnClick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("colAppId")]
	internal virtual ColumnHeader colAppId
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colName")]
	internal virtual ColumnHeader colName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colType")]
	internal virtual ColumnHeader colType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colGenre")]
	internal virtual ColumnHeader colGenre
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colPublisher")]
	internal virtual ColumnHeader colPublisher
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colDeveloper")]
	internal virtual ColumnHeader colDeveloper
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colExecutable")]
	internal virtual ColumnHeader colExecutable
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colArguments")]
	internal virtual ColumnHeader colArguments
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colOSList")]
	internal virtual ColumnHeader colOSList
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colReleaseDate")]
	internal virtual ColumnHeader colReleaseDate
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colDescription")]
	internal virtual ColumnHeader colDescription
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("tsApps")]
	internal virtual ToolStrip tsApps
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ssApps")]
	internal virtual StatusStrip ssApps
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tsbImportApps
	{
		[CompilerGenerated]
		get
		{
			return _tsbImportApps;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbImportApps_Click;
			ToolStripButton toolStripButton = _tsbImportApps;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbImportApps = value;
			toolStripButton = _tsbImportApps;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tsbDownloadAssets
	{
		[CompilerGenerated]
		get
		{
			return _tsbDownloadAssets;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbDownloadAssets_Click;
			ToolStripButton toolStripButton = _tsbDownloadAssets;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbDownloadAssets = value;
			toolStripButton = _tsbDownloadAssets;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("colLibraryFolder")]
	internal virtual ColumnHeader colLibraryFolder
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("colInstallDir")]
	internal virtual ColumnHeader colInstallDir
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("cmsApps")]
	internal virtual ContextMenuStrip cmsApps
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem tsmiOpenFileLocation
	{
		[CompilerGenerated]
		get
		{
			return _tsmiOpenFileLocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsmiOpenFileLocation_Click;
			ToolStripMenuItem toolStripMenuItem = _tsmiOpenFileLocation;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_tsmiOpenFileLocation = value;
			toolStripMenuItem = _tsmiOpenFileLocation;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem tsmiLaunchApp
	{
		[CompilerGenerated]
		get
		{
			return _tsmiLaunchApp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsmiLaunchApp_Click;
			ToolStripMenuItem toolStripMenuItem = _tsmiLaunchApp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_tsmiLaunchApp = value;
			toolStripMenuItem = _tsmiLaunchApp;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tsbRemoveApps
	{
		[CompilerGenerated]
		get
		{
			return _tsbRemoveApps;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbRemoveApps_Click;
			ToolStripButton toolStripButton = _tsbRemoveApps;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbRemoveApps = value;
			toolStripButton = _tsbRemoveApps;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("colInstalled")]
	internal virtual ColumnHeader colInstalled
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("imApps")]
	internal virtual ImageList imApps
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tsbRefresh
	{
		[CompilerGenerated]
		get
		{
			return _tsbRefresh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbRefresh_Click;
			ToolStripButton toolStripButton = _tsbRefresh;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbRefresh = value;
			toolStripButton = _tsbRefresh;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("toolStripSeparator3")]
	internal virtual ToolStripSeparator toolStripSeparator3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tsbSelectAll
	{
		[CompilerGenerated]
		get
		{
			return _tsbSelectAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbSelectAll_Click;
			ToolStripButton toolStripButton = _tsbSelectAll;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbSelectAll = value;
			toolStripButton = _tsbSelectAll;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tsbClear
	{
		[CompilerGenerated]
		get
		{
			return _tsbClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbClear_Click;
			ToolStripButton toolStripButton = _tsbClear;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbClear = value;
			toolStripButton = _tsbClear;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("toolStripSeparator1")]
	internal virtual ToolStripSeparator toolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("toolStripSeparator2")]
	internal virtual ToolStripSeparator toolStripSeparator2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tsbStartService
	{
		[CompilerGenerated]
		get
		{
			return _tsbStartService;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbStartService_Click;
			ToolStripButton toolStripButton = _tsbStartService;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbStartService = value;
			toolStripButton = _tsbStartService;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tsbStopService
	{
		[CompilerGenerated]
		get
		{
			return _tsbStopService;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbStopService_Click;
			ToolStripButton toolStripButton = _tsbStopService;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbStopService = value;
			toolStripButton = _tsbStopService;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("toolStripSeparator4")]
	internal virtual ToolStripSeparator toolStripSeparator4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripCheckBox tscbVrManifest
	{
		[CompilerGenerated]
		get
		{
			return _tscbVrManifest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler obj = tscbVrManifest_CheckedChanged;
			ToolStripCheckBox toolStripCheckBox = _tscbVrManifest;
			if (toolStripCheckBox != null)
			{
				toolStripCheckBox.CheckedChanged -= obj;
			}
			_tscbVrManifest = value;
			toolStripCheckBox = _tscbVrManifest;
			if (toolStripCheckBox != null)
			{
				toolStripCheckBox.CheckedChanged += obj;
			}
		}
	}

	[field: AccessedThroughProperty("tstbSearch")]
	internal virtual ToolStripSpringTextBox tstbSearch
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tsbSearch
	{
		[CompilerGenerated]
		get
		{
			return _tsbSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbSearch_Click;
			ToolStripButton toolStripButton = _tsbSearch;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbSearch = value;
			toolStripButton = _tsbSearch;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tsbRestartService
	{
		[CompilerGenerated]
		get
		{
			return _tsbRestartService;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsbRestartService_Click;
			ToolStripButton toolStripButton = _tsbRestartService;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			_tsbRestartService = value;
			toolStripButton = _tsbRestartService;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("tslSearch")]
	internal virtual ToolStripLabel tslSearch
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("toolStripSeparator5")]
	internal virtual ToolStripSeparator toolStripSeparator5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("panel1")]
	internal virtual Panel panel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual PictureBox pictureBox1
	{
		[CompilerGenerated]
		get
		{
			return _pictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pictureBox1_Click;
			PictureBox pictureBox = _pictureBox1;
			if (pictureBox != null)
			{
				pictureBox.Click -= value2;
			}
			_pictureBox1 = value;
			pictureBox = _pictureBox1;
			if (pictureBox != null)
			{
				pictureBox.Click += value2;
			}
		}
	}

	internal virtual ToolStripStatusLabel tsslHeadsoftLogo
	{
		[CompilerGenerated]
		get
		{
			return _tsslHeadsoftLogo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tsslHeadsoftLogo_Click;
			ToolStripStatusLabel toolStripStatusLabel = _tsslHeadsoftLogo;
			if (toolStripStatusLabel != null)
			{
				toolStripStatusLabel.Click -= value2;
			}
			_tsslHeadsoftLogo = value;
			toolStripStatusLabel = _tsslHeadsoftLogo;
			if (toolStripStatusLabel != null)
			{
				toolStripStatusLabel.Click += value2;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmImportSteamApps));
		this.lvwAppList = new System.Windows.Forms.ListView();
		this.colInstalled = new System.Windows.Forms.ColumnHeader();
		this.colAppId = new System.Windows.Forms.ColumnHeader();
		this.colName = new System.Windows.Forms.ColumnHeader();
		this.colType = new System.Windows.Forms.ColumnHeader();
		this.colGenre = new System.Windows.Forms.ColumnHeader();
		this.colPublisher = new System.Windows.Forms.ColumnHeader();
		this.colDeveloper = new System.Windows.Forms.ColumnHeader();
		this.colExecutable = new System.Windows.Forms.ColumnHeader();
		this.colArguments = new System.Windows.Forms.ColumnHeader();
		this.colOSList = new System.Windows.Forms.ColumnHeader();
		this.colReleaseDate = new System.Windows.Forms.ColumnHeader();
		this.colDescription = new System.Windows.Forms.ColumnHeader();
		this.colLibraryFolder = new System.Windows.Forms.ColumnHeader();
		this.colInstallDir = new System.Windows.Forms.ColumnHeader();
		this.cmsApps = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiLaunchApp = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
		this.imApps = new System.Windows.Forms.ImageList(this.components);
		this.tsApps = new System.Windows.Forms.ToolStrip();
		this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
		this.tsbImportApps = new System.Windows.Forms.ToolStripButton();
		this.tsbRemoveApps = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.tsbSelectAll = new System.Windows.Forms.ToolStripButton();
		this.tsbClear = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.tsbDownloadAssets = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.tsbStartService = new System.Windows.Forms.ToolStripButton();
		this.tsbStopService = new System.Windows.Forms.ToolStripButton();
		this.tsbRestartService = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.tscbVrManifest = new OculusTrayTool.ToolStripCheckBox();
		this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this.tslSearch = new System.Windows.Forms.ToolStripLabel();
		this.tstbSearch = new OculusTrayTool.ToolStripSpringTextBox();
		this.tsbSearch = new System.Windows.Forms.ToolStripButton();
		this.ssApps = new System.Windows.Forms.StatusStrip();
		this.tsslHeadsoftLogo = new System.Windows.Forms.ToolStripStatusLabel();
		this.panel1 = new System.Windows.Forms.Panel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.cmsApps.SuspendLayout();
		this.tsApps.SuspendLayout();
		this.ssApps.SuspendLayout();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.lvwAppList.CheckBoxes = true;
		this.lvwAppList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[14]
		{
			this.colInstalled, this.colAppId, this.colName, this.colType, this.colGenre, this.colPublisher, this.colDeveloper, this.colExecutable, this.colArguments, this.colOSList,
			this.colReleaseDate, this.colDescription, this.colLibraryFolder, this.colInstallDir
		});
		this.lvwAppList.ContextMenuStrip = this.cmsApps;
		this.lvwAppList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lvwAppList.FullRowSelect = true;
		this.lvwAppList.GridLines = true;
		this.lvwAppList.HideSelection = false;
		this.lvwAppList.Location = new System.Drawing.Point(0, 39);
		this.lvwAppList.MultiSelect = false;
		this.lvwAppList.Name = "lvwAppList";
		this.lvwAppList.Size = new System.Drawing.Size(636, 283);
		this.lvwAppList.SmallImageList = this.imApps;
		this.lvwAppList.TabIndex = 3;
		this.lvwAppList.UseCompatibleStateImageBehavior = false;
		this.lvwAppList.View = System.Windows.Forms.View.Details;
		this.colInstalled.Text = "Installed";
		this.colAppId.Text = "AppId";
		this.colName.Text = "Name";
		this.colType.Text = "Type";
		this.colGenre.Text = "Genre";
		this.colPublisher.Text = "Publisher";
		this.colDeveloper.Text = "Developer";
		this.colExecutable.Text = "Executable";
		this.colArguments.Text = "Arguments";
		this.colOSList.Text = "OSList";
		this.colReleaseDate.Text = "ReleaseDate";
		this.colDescription.Text = "Description";
		this.colLibraryFolder.Text = "LibraryFolder";
		this.colInstallDir.Text = "InstallDir";
		this.cmsApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.tsmiLaunchApp, this.tsmiOpenFileLocation });
		this.cmsApps.Name = "cmsApps";
		this.cmsApps.Size = new System.Drawing.Size(174, 48);
		this.tsmiLaunchApp.Name = "tsmiLaunchApp";
		this.tsmiLaunchApp.Size = new System.Drawing.Size(173, 22);
		this.tsmiLaunchApp.Text = "Launch App";
		this.tsmiOpenFileLocation.Name = "tsmiOpenFileLocation";
		this.tsmiOpenFileLocation.Size = new System.Drawing.Size(173, 22);
		this.tsmiOpenFileLocation.Text = "Open File Location";
		this.imApps.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imApps.ImageStream");
		this.imApps.TransparentColor = System.Drawing.Color.Transparent;
		this.imApps.Images.SetKeyName(0, "installed.png");
		this.imApps.Images.SetKeyName(1, "not_installed.png");
		this.tsApps.ImageScalingSize = new System.Drawing.Size(32, 32);
		this.tsApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
		{
			this.tsbRefresh, this.tsbImportApps, this.tsbRemoveApps, this.toolStripSeparator3, this.tsbSelectAll, this.tsbClear, this.toolStripSeparator1, this.tsbDownloadAssets, this.toolStripSeparator2, this.tsbStartService,
			this.tsbStopService, this.tsbRestartService, this.toolStripSeparator4, this.tscbVrManifest, this.toolStripSeparator5, this.tslSearch, this.tstbSearch, this.tsbSearch
		});
		this.tsApps.Location = new System.Drawing.Point(0, 0);
		this.tsApps.Name = "tsApps";
		this.tsApps.Size = new System.Drawing.Size(636, 39);
		this.tsApps.TabIndex = 4;
		this.tsApps.Text = "toolStrip1";
		this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbRefresh.Image = (System.Drawing.Image)resources.GetObject("tsbRefresh.Image");
		this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbRefresh.Name = "tsbRefresh";
		this.tsbRefresh.Size = new System.Drawing.Size(36, 36);
		this.tsbRefresh.Text = "Refresh App List";
		this.tsbImportApps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbImportApps.Image = (System.Drawing.Image)resources.GetObject("tsbImportApps.Image");
		this.tsbImportApps.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbImportApps.Name = "tsbImportApps";
		this.tsbImportApps.Size = new System.Drawing.Size(36, 36);
		this.tsbImportApps.Text = "Import Selected Apps";
		this.tsbRemoveApps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbRemoveApps.Image = (System.Drawing.Image)resources.GetObject("tsbRemoveApps.Image");
		this.tsbRemoveApps.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbRemoveApps.Name = "tsbRemoveApps";
		this.tsbRemoveApps.Size = new System.Drawing.Size(36, 36);
		this.tsbRemoveApps.Text = "Remove Selected Apps";
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
		this.tsbSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbSelectAll.Image = (System.Drawing.Image)resources.GetObject("tsbSelectAll.Image");
		this.tsbSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbSelectAll.Name = "tsbSelectAll";
		this.tsbSelectAll.Size = new System.Drawing.Size(36, 36);
		this.tsbSelectAll.Text = "Select All Apps";
		this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbClear.Image = (System.Drawing.Image)resources.GetObject("tsbClear.Image");
		this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbClear.Name = "tsbClear";
		this.tsbClear.Size = new System.Drawing.Size(36, 36);
		this.tsbClear.Text = "Clear All Selections";
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
		this.tsbDownloadAssets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbDownloadAssets.Image = (System.Drawing.Image)resources.GetObject("tsbDownloadAssets.Image");
		this.tsbDownloadAssets.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbDownloadAssets.Name = "tsbDownloadAssets";
		this.tsbDownloadAssets.Size = new System.Drawing.Size(36, 36);
		this.tsbDownloadAssets.Text = "Download Selected Assets";
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
		this.tsbStartService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbStartService.Image = (System.Drawing.Image)resources.GetObject("tsbStartService.Image");
		this.tsbStartService.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbStartService.Name = "tsbStartService";
		this.tsbStartService.Size = new System.Drawing.Size(36, 36);
		this.tsbStartService.Text = "Start Oculus Service";
		this.tsbStopService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbStopService.Image = (System.Drawing.Image)resources.GetObject("tsbStopService.Image");
		this.tsbStopService.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbStopService.Name = "tsbStopService";
		this.tsbStopService.Size = new System.Drawing.Size(36, 36);
		this.tsbStopService.Text = "Stop Oculus Service";
		this.tsbRestartService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbRestartService.Image = (System.Drawing.Image)resources.GetObject("tsbRestartService.Image");
		this.tsbRestartService.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbRestartService.Name = "tsbRestartService";
		this.tsbRestartService.Size = new System.Drawing.Size(36, 36);
		this.tsbRestartService.Text = "Restart Oculus Service";
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
		this.tscbVrManifest.BackColor = System.Drawing.Color.Transparent;
		this.tscbVrManifest.Checked = false;
		this.tscbVrManifest.Name = "tscbVrManifest";
		this.tscbVrManifest.Size = new System.Drawing.Size(86, 36);
		this.tscbVrManifest.Text = "Vr Manifest";
		this.toolStripSeparator5.Name = "toolStripSeparator5";
		this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
		this.tslSearch.Name = "tslSearch";
		this.tslSearch.Size = new System.Drawing.Size(45, 36);
		this.tslSearch.Text = "Search:";
		this.tstbSearch.Name = "tstbSearch";
		this.tstbSearch.Size = new System.Drawing.Size(92, 39);
		this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbSearch.Image = (System.Drawing.Image)resources.GetObject("tsbSearch.Image");
		this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tsbSearch.Name = "tsbSearch";
		this.tsbSearch.Size = new System.Drawing.Size(36, 36);
		this.tsbSearch.Text = "Search";
		this.ssApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.tsslHeadsoftLogo });
		this.ssApps.Location = new System.Drawing.Point(0, 412);
		this.ssApps.Name = "ssApps";
		this.ssApps.Size = new System.Drawing.Size(636, 22);
		this.ssApps.TabIndex = 5;
		this.ssApps.Text = "statusStrip1";
		this.tsslHeadsoftLogo.AutoSize = false;
		this.tsslHeadsoftLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsslHeadsoftLogo.Image = (System.Drawing.Image)resources.GetObject("tsslHeadsoftLogo.Image");
		this.tsslHeadsoftLogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.tsslHeadsoftLogo.IsLink = true;
		this.tsslHeadsoftLogo.Name = "tsslHeadsoftLogo";
		this.tsslHeadsoftLogo.Size = new System.Drawing.Size(148, 17);
		this.panel1.Controls.Add(this.pictureBox1);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 322);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(636, 90);
		this.panel1.TabIndex = 6;
		this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(66, 0);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(500, 90);
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(636, 434);
		base.Controls.Add(this.lvwAppList);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.ssApps);
		base.Controls.Add(this.tsApps);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimumSize = new System.Drawing.Size(652, 473);
		base.Name = "frmImportSteamApps";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Import Steam Apps";
		this.cmsApps.ResumeLayout(false);
		this.tsApps.ResumeLayout(false);
		this.tsApps.PerformLayout();
		this.ssApps.ResumeLayout(false);
		this.ssApps.PerformLayout();
		this.panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public frmImportSteamApps()
	{
		base.Load += frmImportSteamApps_Load;
		base.Resize += frmImportSteamApps_Resize;
		base.FormClosing += frmImportSteamApps_FormClosing;
		components = null;
		m_lvwColumnSorter = null;
		InitializeComponent();
	}

	private void frmImportSteamApps_Load(object sender, EventArgs e)
	{
		tscbVrManifest.Checked = true;
		if (MySettingsProperty.Settings.SteamWindowLocation != default(Point))
		{
			base.Location = MySettingsProperty.Settings.SteamWindowLocation;
		}
		else
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Setting Steam GUI location to Center Screen");
			}
			CenterToScreen();
			MySettingsProperty.Settings.SteamWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
		}
		if ((base.Location.X < 0) | (base.Location.Y < 0))
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Steam GUI location has negative number, adjusting");
			}
			CenterToScreen();
			MySettingsProperty.Settings.SteamWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
		}
		if (MySettingsProperty.Settings.SteamWindowSize != default(Size))
		{
			base.Size = MySettingsProperty.Settings.SteamWindowSize;
		}
	}

	private void UpdateAppListView()
	{
		try
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Updating list of Steam games");
			}
			if (!Globals.oculus.TryRefresh() || !Globals.steam.TryRefresh())
			{
				return;
			}
			List<SteamNode> appInfoList = null;
			if (tscbVrManifest.Checked)
			{
				if (!Globals.steam.TryGetVRManifest(ref appInfoList) || !Globals.steam.TryGetAppInfo(appInfoList, windowsOnly: true, vrOnly: true))
				{
					return;
				}
			}
			else
			{
				Dictionary<ulong, SteamNode> appInfoDictionary = null;
				if (!Globals.steam.TryGetAppInfo(windowsOnly: true, vrOnly: true, ref appInfoDictionary, ref appInfoList))
				{
					return;
				}
			}
			m_lvwColumnSorter = new ListViewColumnSorter();
			m_lvwColumnSorter.SortColumn = 2;
			m_lvwColumnSorter.Order = SortOrder.Ascending;
			lvwAppList.Items.Clear();
			lvwAppList.ListViewItemSorter = m_lvwColumnSorter;
			List<ListViewItem> list = new List<ListViewItem>();
			foreach (SteamNode item in appInfoList)
			{
				bool flag = Globals.oculus.IsAppInstalled(item);
				if (string.IsNullOrEmpty(tstbSearch.Text) || item.Name.IndexOf(tstbSearch.Text, StringComparison.CurrentCultureIgnoreCase) != -1)
				{
					ListViewItem listViewItem = new ListViewItem(new string[14]
					{
						"",
						item.AppId.ToString(),
						item.Name,
						item.Type,
						item.Genre,
						item.Publisher,
						item.Developer,
						item.Executable,
						item.Parameters,
						item.OSList,
						item.ReleaseDateString,
						item.Description,
						item.LibraryFolder,
						item.InstallDir
					});
					listViewItem.ImageIndex = ((!flag) ? 1 : 0);
					listViewItem.Tag = item;
					list.Add(listViewItem);
				}
			}
			lvwAppList.Items.AddRange(list.ToArray());
			foreach (ColumnHeader column in lvwAppList.Columns)
			{
				if (Operators.CompareString(column.Text, "Description", TextCompare: false) != 0)
				{
					column.Width = -2;
				}
			}
			lvwAppList.Sort();
			if (Globals.dbg)
			{
				Log.WriteToLog("Update complete");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void lvwAppList_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		if (e.Column == m_lvwColumnSorter.SortColumn)
		{
			m_lvwColumnSorter.Order = ((m_lvwColumnSorter.Order != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
		}
		else
		{
			m_lvwColumnSorter.SortColumn = e.Column;
			m_lvwColumnSorter.Order = SortOrder.Ascending;
		}
		lvwAppList.Sort();
	}

	private void tsbRefresh_Click(object sender, EventArgs e)
	{
		UpdateAppListView();
	}

	private void tsbImportApps_Click(object sender, EventArgs e)
	{
		ImportSelectedApps();
	}

	private void tsbRemoveApps_Click(object sender, EventArgs e)
	{
		RemoveSelectedApps();
	}

	private void tsbSelectAll_Click(object sender, EventArgs e)
	{
		foreach (ListViewItem item in lvwAppList.Items)
		{
			item.Checked = true;
		}
	}

	private void tsbClear_Click(object sender, EventArgs e)
	{
		foreach (ListViewItem item in lvwAppList.Items)
		{
			item.Checked = false;
		}
	}

	private void tsbDownloadAssets_Click(object sender, EventArgs e)
	{
		DownloadSelectedAssets();
	}

	private void tsbStartService_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		Globals.oculus.TryStartOculusService();
		Cursor = Cursors.Default;
	}

	private void tsbStopService_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		Globals.oculus.TryStopOculusService();
		Cursor = Cursors.Default;
	}

	private void tsbRestartService_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		Globals.oculus.TryRestartOculusService();
		Cursor = Cursors.Default;
	}

	private void tscbVrManifest_CheckedChanged(object sender, EventArgs e)
	{
		UpdateAppListView();
	}

	private void tsbSearch_Click(object sender, EventArgs e)
	{
		UpdateAppListView();
	}

	private void ImportSelectedApps()
	{
		try
		{
			_Closure_0024__189_002D0 arg = default(_Closure_0024__189_002D0);
			_Closure_0024__189_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__189_002D0(arg);
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			if (MyProject.Forms.FrmMain.debug)
			{
				Log.WriteToLog("Importing selected apps");
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_steamList = null;
			if (!TryGetSelectedSteamList(ref CS_0024_003C_003E8__locals0._0024VB_0024Local_steamList))
			{
				return;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing = new frmProcessing();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker = new BackgroundWorker();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.WorkerReportsProgress = false;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.DoWork += [SpecialName] (object sender, DoWorkEventArgs e) =>
			{
				foreach (SteamNode _0024VB_0024Local_steam in CS_0024_003C_003E8__locals0._0024VB_0024Local_steamList)
				{
					if (CS_0024_003C_003E8__locals0._0024VB_0024Me.TryRemoveApp(CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing, _0024VB_0024Local_steam))
					{
						Log.WriteToLog("Importing '" + _0024VB_0024Local_steam.Name + "'");
						Globals.oculus.TryCreateManifest(_0024VB_0024Local_steam, SteamLaunchType.App);
						Globals.oculus.TryDownloadAppHeader(_0024VB_0024Local_steam, [SpecialName] (object _sender, DownloadProgressChangedEventArgs _e) =>
						{
							object[] array = (object[])_e.UserState;
							Uri uri = (Uri)array[0];
							object objectValue = RuntimeHelpers.GetObjectValue(array[1]);
							object objectValue2 = RuntimeHelpers.GetObjectValue(array[2]);
							CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing.UpdateProgressBar(_e.ProgressPercentage, $"Downloading '{RuntimeHelpers.GetObjectValue(objectValue2)}'...");
						});
					}
				}
				Globals.oculus.TryRestartOculusService();
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.RunWorkerCompleted += [SpecialName] (object sender, RunWorkerCompletedEventArgs e) =>
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.Dispose();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing.Close();
				CS_0024_003C_003E8__locals0._0024VB_0024Me.UpdateAppListView();
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.RunWorkerAsync();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing.ShowDialog(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ImportSelectedApps: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void RemoveSelectedApps()
	{
		try
		{
			List<SteamNode> steamList = null;
			if (!TryGetSelectedSteamList(ref steamList))
			{
				return;
			}
			foreach (SteamNode item in steamList)
			{
				TryRemoveApp(this, item);
				Log.WriteToLog("'" + item.Name + "' has been removed");
			}
			UpdateAppListView();
			Globals.oculus.TryRestartOculusService();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("RemoveSelectedApps: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void DownloadSelectedAssets()
	{
		try
		{
			_Closure_0024__191_002D0 arg = default(_Closure_0024__191_002D0);
			_Closure_0024__191_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__191_002D0(arg);
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_steamList = null;
			if (!TryGetSelectedSteamList(ref CS_0024_003C_003E8__locals0._0024VB_0024Local_steamList))
			{
				return;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_syncObject = RuntimeHelpers.GetObjectValue(new object());
			CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing = new frmProcessing();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker = new BackgroundWorker();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.WorkerReportsProgress = false;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.DoWork += [SpecialName] (object sender, DoWorkEventArgs e) =>
			{
				string path = Path.Combine(Application.StartupPath, "Assets");
				List<DownloadFileNode> list = new List<DownloadFileNode>();
				foreach (SteamNode _0024VB_0024Local_steam in CS_0024_003C_003E8__locals0._0024VB_0024Local_steamList)
				{
					string tempPath = Path.GetTempPath();
					string text = Path.Combine(tempPath, $"{_0024VB_0024Local_steam.AppId}.json");
					if (Globals.steam.TryDownloadAppDetails(_0024VB_0024Local_steam.AppId, text))
					{
						string appDetailsText = File.ReadAllText(text);
						if (_0024VB_0024Local_steam.TryParseAppDetails(appDetailsText))
						{
							foreach (SteamScreenshotNode screenshot in _0024VB_0024Local_steam.ScreenshotList)
							{
								Uri uri = new Uri(screenshot.FullPath);
								string destinationFolder = Path.Combine(path, _0024VB_0024Local_steam.AppId.ToString());
								DownloadFileNode item = new DownloadFileNode(screenshot.FullPath, destinationFolder);
								if (MyProject.Forms.FrmMain.debug)
								{
									Log.WriteToLog(screenshot.FullPath.ToString() + " added to download list");
								}
								list.Add(item);
							}
						}
					}
				}
				FileDownloader fileDownloader = new FileDownloader(list);
				fileDownloader.FileDownloadProgressChanged += [SpecialName] (object _sender, FileDownloadProgressChangedEventArgs _e) =>
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing.UpdateProgressBar(_e.TotalProgressPercentage, "Downloading Assets...");
				};
				fileDownloader.AllFilesDownloadCompleted += [SpecialName] (object _sender, EventArgs _e) =>
				{
					object _0024VB_0024Local_syncObject2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_syncObject;
					ObjectFlowControl.CheckForSyncLockOnValueType(_0024VB_0024Local_syncObject2);
					bool lockTaken2 = false;
					try
					{
						Monitor.Enter(_0024VB_0024Local_syncObject2, ref lockTaken2);
						Monitor.Pulse(RuntimeHelpers.GetObjectValue(CS_0024_003C_003E8__locals0._0024VB_0024Local_syncObject));
					}
					finally
					{
						if (lockTaken2)
						{
							Monitor.Exit(_0024VB_0024Local_syncObject2);
						}
					}
				};
				object _0024VB_0024Local_syncObject = CS_0024_003C_003E8__locals0._0024VB_0024Local_syncObject;
				ObjectFlowControl.CheckForSyncLockOnValueType(_0024VB_0024Local_syncObject);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(_0024VB_0024Local_syncObject, ref lockTaken);
					fileDownloader.Start();
					Monitor.Wait(RuntimeHelpers.GetObjectValue(CS_0024_003C_003E8__locals0._0024VB_0024Local_syncObject));
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(_0024VB_0024Local_syncObject);
					}
				}
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.RunWorkerCompleted += [SpecialName] (object sender, RunWorkerCompletedEventArgs e) =>
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.Dispose();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing.Close();
				CS_0024_003C_003E8__locals0._0024VB_0024Me.UpdateAppListView();
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_backgroundWorker.RunWorkerAsync();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_frmProcessing.ShowDialog(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("DownloadSelectedAssets: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private bool TryGetSelectedSteamList(ref List<SteamNode> steamList)
	{
		bool result;
		try
		{
			steamList = null;
			if (lvwAppList.CheckedItems.Count <= 0)
			{
				result = false;
			}
			else
			{
				steamList = new List<SteamNode>();
				foreach (ListViewItem checkedItem in lvwAppList.CheckedItems)
				{
					SteamNode item = (SteamNode)checkedItem.Tag;
					steamList.Add(item);
				}
				result = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetSelectedSteamList: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void tsmiLaunchApp_Click(object sender, EventArgs e)
	{
		try
		{
			if (lvwAppList.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = lvwAppList.SelectedItems[0];
				SteamNode steamNode = (SteamNode)listViewItem.Tag;
				Globals.steam.TryLaunchApp(steamNode.AppId, steamNode.Parameters);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Could not launch app: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void tsmiOpenFileLocation_Click(object sender, EventArgs e)
	{
		if (lvwAppList.SelectedItems.Count > 0)
		{
			ListViewItem listViewItem = lvwAppList.SelectedItems[0];
			SteamNode steamNode = (SteamNode)listViewItem.Tag;
			string fullPath = steamNode.FullPath;
			if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
			{
				Process.Start("explorer.exe", $"/select,\"{fullPath}\"");
			}
		}
	}

	private bool TryRemoveApp(Control control, SteamNode steamNode)
	{
		_Closure_0024__195_002D0 arg = default(_Closure_0024__195_002D0);
		_Closure_0024__195_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__195_002D0(arg);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_control = control;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_steamNode = steamNode;
		bool result = default(bool);
		try
		{
			List<string> manifestFileList = null;
			List<string> assetDirectoryList = null;
			if (Globals.oculus.TryGetManifestFileNameAndAssetFolderList(CS_0024_003C_003E8__locals0._0024VB_0024Local_steamNode, ref manifestFileList, ref assetDirectoryList))
			{
				if (Conversions.ToInteger(CS_0024_003C_003E8__locals0._0024VB_0024Local_control.Invoke((Func<DialogResult>)([SpecialName] () => MessageBox.Show(CS_0024_003C_003E8__locals0._0024VB_0024Local_control, $"'{CS_0024_003C_003E8__locals0._0024VB_0024Local_steamNode.Name}' Is In Your Library.\r\nDo You Want To Delete It?", "Delete App?", MessageBoxButtons.YesNo)))) != 6)
				{
					result = false;
					return result;
				}
				foreach (string item in manifestFileList)
				{
					if (File.Exists(item))
					{
						File.Delete(item);
						if (Globals.dbg)
						{
							Log.WriteToLog(item + " deleted");
						}
					}
				}
				foreach (string item2 in assetDirectoryList)
				{
					if (Directory.Exists(item2))
					{
						Directory.Delete(item2, recursive: true);
						if (Globals.dbg)
						{
							Log.WriteToLog(item2 + " deleted");
						}
					}
				}
			}
			result = true;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryRemoveApp: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void frmImportSteamApps_Resize(object sender, EventArgs e)
	{
		pictureBox1.Location = new Point(checked((int)Math.Round((double)base.ClientSize.Width / 2.0 - (double)pictureBox1.Width / 2.0)), 0);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Process.Start("http://headsoft.com.au/redirect.php?url=https://www.mechatech.co.uk/");
	}

	private void tsslHeadsoftLogo_Click(object sender, EventArgs e)
	{
		Process.Start("http://headsoft.com.au/");
	}

	private void frmImportSteamApps_FormClosing(object sender, FormClosingEventArgs e)
	{
		MySettingsProperty.Settings.SteamWindowLocation = base.Location;
		MySettingsProperty.Settings.SteamWindowSize = base.Size;
		MySettingsProperty.Settings.Save();
	}
}
