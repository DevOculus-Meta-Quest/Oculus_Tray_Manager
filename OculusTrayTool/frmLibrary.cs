using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmLibrary : Form
{
	public delegate void ImagelistAddItem_delegate(string name, Image img);

	public delegate void ListViewAddItemSteam_delegate(string name, string tag);

	public delegate void ClearListview_delegate(ListView lv);

	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ListView1")]
	private ListView _ListView1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ContextMenuStrip1")]
	private ContextMenuStrip _ContextMenuStrip1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem2")]
	private ToolStripMenuItem _ToolStripMenuItem2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem4")]
	private ToolStripMenuItem _ToolStripMenuItem4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem7")]
	private ToolStripMenuItem _ToolStripMenuItem7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem8")]
	private ToolStripMenuItem _ToolStripMenuItem8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicturePlay")]
	private PictureBox _PicturePlay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ContextMenuStrip2")]
	private ContextMenuStrip _ContextMenuStrip2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem1")]
	private ToolStripMenuItem _ToolStripMenuItem1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem9")]
	private ToolStripMenuItem _ToolStripMenuItem9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShowAppInLibraryAndProfilesToolStripMenuItem")]
	private ToolStripMenuItem _ShowAppInLibraryAndProfilesToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("AddSteamVRToolStripMenuItem")]
	private ToolStripMenuItem _AddSteamVRToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShowToolStripMenuItem")]
	private ToolStripMenuItem _ShowToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("AscendingToolStripMenuItem")]
	private ToolStripMenuItem _AscendingToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DescendingToolStripMenuItem")]
	private ToolStripMenuItem _DescendingToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RefreshLibraryToolStripMenuItem")]
	private ToolStripMenuItem _RefreshLibraryToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShowIgnoredAppsToolStripMenuItem")]
	private ToolStripMenuItem _ShowIgnoredAppsToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem5")]
	private ToolStripMenuItem _ToolStripMenuItem5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem6")]
	private ToolStripMenuItem _ToolStripMenuItem6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RemoveProfileToolStripMenuItem")]
	private ToolStripMenuItem _RemoveProfileToolStripMenuItem;

	private ImageList imageListLarge;

	public static ImageList icons = new ImageList();

	private ImageList ImgListOverlay;

	private string steam_assets;

	private string backupPath;

	private bool changeMade;

	private List<string> steamExes;

	private Resizer rs;

	private bool isReading;

	private bool scrapeDone;

	private bool libraryLoaded;

	public Dictionary<string, string> ManualStartProfiles;

	private bool removeOK;

	public int LocalDBVersion;

	public int IconsLocalDBVersion;

	private Thread GetIcons;

	public SQLiteConnection Steamcnn;

	public SQLiteConnection Iconscnn;

	private int offset;

	private bool isOpen;

	private bool IconsisOpen;

	private int dbCount;

	private bool isSearch;

	private bool lvShrunk;

	private string selectedLink;

	private int ShrinkSize;

	private ListView lvToShrink;

	private bool NoIconSet;

	private bool BrowseForIcons;

	private SQLiteConnection cnn;

	private List<string> IconGameList;

	public List<string> DisplayNameList;

	internal virtual ListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return _ListView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = ListView1_MouseMove;
			ListView listView = _ListView1;
			if (listView != null)
			{
				listView.MouseMove -= value2;
			}
			_ListView1 = value;
			listView = _ListView1;
			if (listView != null)
			{
				listView.MouseMove += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolTip1")]
	internal virtual ToolTip ToolTip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ContextMenuStrip ContextMenuStrip1
	{
		[CompilerGenerated]
		get
		{
			return _ContextMenuStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CancelEventHandler value2 = ContextMenuStrip1_Opening;
			EventHandler value3 = ContextMenuStrip1_MouseLeave;
			ContextMenuStrip contextMenuStrip = _ContextMenuStrip1;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= value2;
				contextMenuStrip.MouseLeave -= value3;
			}
			_ContextMenuStrip1 = value;
			contextMenuStrip = _ContextMenuStrip1;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += value2;
				contextMenuStrip.MouseLeave += value3;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripMenuItem3")]
	internal virtual ToolStripMenuItem ToolStripMenuItem3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	internal virtual ToolStripMenuItem ToolStripMenuItem7
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem7_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem7;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem7 = value;
			toolStripMenuItem = _ToolStripMenuItem7;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem8
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem8_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem8;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem8 = value;
			toolStripMenuItem = _ToolStripMenuItem8;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual PictureBox PicturePlay
	{
		[CompilerGenerated]
		get
		{
			return _PicturePlay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = PicturePlay_MouseUp;
			PictureBox picturePlay = _PicturePlay;
			if (picturePlay != null)
			{
				picturePlay.MouseUp -= value2;
			}
			_PicturePlay = value;
			picturePlay = _PicturePlay;
			if (picturePlay != null)
			{
				picturePlay.MouseUp += value2;
			}
		}
	}

	internal virtual ContextMenuStrip ContextMenuStrip2
	{
		[CompilerGenerated]
		get
		{
			return _ContextMenuStrip2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CancelEventHandler value2 = ContextMenuStrip2_Opening;
			ContextMenuStrip contextMenuStrip = _ContextMenuStrip2;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= value2;
			}
			_ContextMenuStrip2 = value;
			contextMenuStrip = _ContextMenuStrip2;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ReEnableAppToolStripMenuItem")]
	internal virtual ToolStripMenuItem ReEnableAppToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _TextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = TextBox1_KeyDown;
			TextBox textBox = _TextBox1;
			if (textBox != null)
			{
				textBox.KeyDown -= value2;
			}
			_TextBox1 = value;
			textBox = _TextBox1;
			if (textBox != null)
			{
				textBox.KeyDown += value2;
			}
		}
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

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6
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

	internal virtual ToolStripMenuItem ToolStripMenuItem9
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem9_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem9;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem9 = value;
			toolStripMenuItem = _ToolStripMenuItem9;
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

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal virtual ToolStripSeparator ToolStripSeparator2
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

	internal virtual ToolStripMenuItem ShowAppInLibraryAndProfilesToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ShowAppInLibraryAndProfilesToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ShowAppInLibraryAndProfilesToolStripMenuItem_Click;
			ToolStripMenuItem showAppInLibraryAndProfilesToolStripMenuItem = _ShowAppInLibraryAndProfilesToolStripMenuItem;
			if (showAppInLibraryAndProfilesToolStripMenuItem != null)
			{
				showAppInLibraryAndProfilesToolStripMenuItem.Click -= value2;
			}
			_ShowAppInLibraryAndProfilesToolStripMenuItem = value;
			showAppInLibraryAndProfilesToolStripMenuItem = _ShowAppInLibraryAndProfilesToolStripMenuItem;
			if (showAppInLibraryAndProfilesToolStripMenuItem != null)
			{
				showAppInLibraryAndProfilesToolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DotNetBarTabcontrol1")]
	internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("MenuStrip1")]
	internal virtual MenuStrip MenuStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OptionsToolStripMenuItem")]
	internal virtual ToolStripMenuItem OptionsToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem AddSteamVRToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AddSteamVRToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddSteamVRToolStripMenuItem_Click;
			ToolStripMenuItem addSteamVRToolStripMenuItem = _AddSteamVRToolStripMenuItem;
			if (addSteamVRToolStripMenuItem != null)
			{
				addSteamVRToolStripMenuItem.Click -= value2;
			}
			_AddSteamVRToolStripMenuItem = value;
			addSteamVRToolStripMenuItem = _AddSteamVRToolStripMenuItem;
			if (addSteamVRToolStripMenuItem != null)
			{
				addSteamVRToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ShowToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ShowToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ShowToolStripMenuItem_Click;
			ToolStripMenuItem showToolStripMenuItem = _ShowToolStripMenuItem;
			if (showToolStripMenuItem != null)
			{
				showToolStripMenuItem.Click -= value2;
			}
			_ShowToolStripMenuItem = value;
			showToolStripMenuItem = _ShowToolStripMenuItem;
			if (showToolStripMenuItem != null)
			{
				showToolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ShowRemoved3rdPartyAppsToolStripMenuItem")]
	internal virtual ToolStripMenuItem ShowRemoved3rdPartyAppsToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SortingToolStripMenuItem")]
	internal virtual ToolStripMenuItem SortingToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem AscendingToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AscendingToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AscendingToolStripMenuItem_Click;
			ToolStripMenuItem ascendingToolStripMenuItem = _AscendingToolStripMenuItem;
			if (ascendingToolStripMenuItem != null)
			{
				ascendingToolStripMenuItem.Click -= value2;
			}
			_AscendingToolStripMenuItem = value;
			ascendingToolStripMenuItem = _AscendingToolStripMenuItem;
			if (ascendingToolStripMenuItem != null)
			{
				ascendingToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem DescendingToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _DescendingToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DescendingToolStripMenuItem_Click;
			ToolStripMenuItem descendingToolStripMenuItem = _DescendingToolStripMenuItem;
			if (descendingToolStripMenuItem != null)
			{
				descendingToolStripMenuItem.Click -= value2;
			}
			_DescendingToolStripMenuItem = value;
			descendingToolStripMenuItem = _DescendingToolStripMenuItem;
			if (descendingToolStripMenuItem != null)
			{
				descendingToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem RefreshLibraryToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _RefreshLibraryToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RefreshLibraryToolStripMenuItem_Click;
			ToolStripMenuItem refreshLibraryToolStripMenuItem = _RefreshLibraryToolStripMenuItem;
			if (refreshLibraryToolStripMenuItem != null)
			{
				refreshLibraryToolStripMenuItem.Click -= value2;
			}
			_RefreshLibraryToolStripMenuItem = value;
			refreshLibraryToolStripMenuItem = _RefreshLibraryToolStripMenuItem;
			if (refreshLibraryToolStripMenuItem != null)
			{
				refreshLibraryToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ShowIgnoredAppsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ShowIgnoredAppsToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ShowIgnoredAppsToolStripMenuItem_Click;
			ToolStripMenuItem showIgnoredAppsToolStripMenuItem = _ShowIgnoredAppsToolStripMenuItem;
			if (showIgnoredAppsToolStripMenuItem != null)
			{
				showIgnoredAppsToolStripMenuItem.Click -= value2;
			}
			_ShowIgnoredAppsToolStripMenuItem = value;
			showIgnoredAppsToolStripMenuItem = _ShowIgnoredAppsToolStripMenuItem;
			if (showIgnoredAppsToolStripMenuItem != null)
			{
				showIgnoredAppsToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem5
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem5_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem5 = value;
			toolStripMenuItem = _ToolStripMenuItem5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem6
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripMenuItem6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ToolStripMenuItem6_Click;
			ToolStripMenuItem toolStripMenuItem = _ToolStripMenuItem6;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ToolStripMenuItem6 = value;
			toolStripMenuItem = _ToolStripMenuItem6;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator3")]
	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem RemoveProfileToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _RemoveProfileToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveProfileToolStripMenuItem_Click;
			ToolStripMenuItem removeProfileToolStripMenuItem = _RemoveProfileToolStripMenuItem;
			if (removeProfileToolStripMenuItem != null)
			{
				removeProfileToolStripMenuItem.Click -= value2;
			}
			_RemoveProfileToolStripMenuItem = value;
			removeProfileToolStripMenuItem = _RemoveProfileToolStripMenuItem;
			if (removeProfileToolStripMenuItem != null)
			{
				removeProfileToolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Client")]
	private virtual WebClient Client
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmLibrary()
	{
		base.FormClosing += Library_FormClosing;
		base.Load += Library_Load;
		base.ResizeBegin += Library_ResizeBegin;
		imageListLarge = new ImageList();
		ImgListOverlay = new ImageList
		{
			ImageSize = new Size(64, 64)
		};
		steam_assets = Application.StartupPath + "\\SteamVRAssets";
		backupPath = Application.StartupPath + "\\backup";
		changeMade = false;
		steamExes = new List<string>();
		rs = new Resizer();
		isReading = false;
		scrapeDone = false;
		libraryLoaded = false;
		ManualStartProfiles = new Dictionary<string, string>();
		removeOK = false;
		Client = new WebClient();
		Steamcnn = new SQLiteConnection();
		Iconscnn = new SQLiteConnection();
		offset = 0;
		isSearch = false;
		lvShrunk = false;
		ShrinkSize = 0;
		NoIconSet = false;
		BrowseForIcons = false;
		cnn = new SQLiteConnection();
		IconGameList = new List<string>();
		DisplayNameList = new List<string>();
		InitializeComponent();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmLibrary));
		this.ContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.ReEnableAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ShowAppInLibraryAndProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		this.RemoveProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Button2 = new System.Windows.Forms.Button();
		this.Label6 = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
		this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.AddSteamVRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ShowRemoved3rdPartyAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ShowIgnoredAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RefreshLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.AscendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.DescendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.DotNetBarTabcontrol1 = new OculusTrayTool.DotNetBarTabcontrol();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.PicturePlay = new System.Windows.Forms.PictureBox();
		this.ListView1 = new System.Windows.Forms.ListView();
		this.ContextMenuStrip2.SuspendLayout();
		this.ContextMenuStrip1.SuspendLayout();
		this.MenuStrip1.SuspendLayout();
		this.DotNetBarTabcontrol1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PicturePlay).BeginInit();
		base.SuspendLayout();
		this.ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ReEnableAppToolStripMenuItem, this.ShowAppInLibraryAndProfilesToolStripMenuItem });
		this.ContextMenuStrip2.Name = "ContextMenuStrip2";
		this.ContextMenuStrip2.Size = new System.Drawing.Size(246, 48);
		this.ReEnableAppToolStripMenuItem.Enabled = false;
		this.ReEnableAppToolStripMenuItem.Name = "ReEnableAppToolStripMenuItem";
		this.ReEnableAppToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
		this.ReEnableAppToolStripMenuItem.Text = "Re-Enable App";
		this.ReEnableAppToolStripMenuItem.Visible = false;
		this.ShowAppInLibraryAndProfilesToolStripMenuItem.Name = "ShowAppInLibraryAndProfilesToolStripMenuItem";
		this.ShowAppInLibraryAndProfilesToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
		this.ShowAppInLibraryAndProfilesToolStripMenuItem.Text = "Show App in Library and Profiles";
		this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[13]
		{
			this.ToolStripMenuItem3, this.ToolStripMenuItem2, this.ToolStripSeparator2, this.ToolStripMenuItem4, this.ToolStripMenuItem5, this.ToolStripMenuItem6, this.ToolStripSeparator3, this.ToolStripMenuItem7, this.ToolStripMenuItem8, this.ToolStripSeparator1,
			this.ToolStripMenuItem1, this.ToolStripMenuItem9, this.RemoveProfileToolStripMenuItem
		});
		this.ContextMenuStrip1.Name = "ContextMenuStrip1";
		this.ContextMenuStrip1.Size = new System.Drawing.Size(242, 242);
		this.ToolStripMenuItem3.Image = OculusTrayTool.My.Resources.Resources.refresh_16;
		this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		this.ToolStripMenuItem3.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem3.Text = "Replace Icons";
		this.ToolStripMenuItem3.Visible = false;
		this.ToolStripMenuItem2.Image = OculusTrayTool.My.Resources.Resources.Icon_View;
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		this.ToolStripMenuItem2.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem2.Text = "Show Properties";
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new System.Drawing.Size(238, 6);
		this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		this.ToolStripMenuItem4.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem4.Text = "Hide App in Library";
		this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
		this.ToolStripMenuItem5.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem5.Text = "Hide App in Library and Profiles";
		this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
		this.ToolStripMenuItem6.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem6.Text = "Ignore App";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new System.Drawing.Size(238, 6);
		this.ToolStripMenuItem7.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem7.Image");
		this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
		this.ToolStripMenuItem7.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem7.Text = "Launch App";
		this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
		this.ToolStripMenuItem8.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem8.Text = "Launch App with options..";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new System.Drawing.Size(238, 6);
		this.ToolStripMenuItem1.Image = OculusTrayTool.My.Resources.Resources.Icon_Edit;
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem1.Text = "Create Profile...";
		this.ToolStripMenuItem9.Image = OculusTrayTool.My.Resources.Resources.Icon_Edit;
		this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
		this.ToolStripMenuItem9.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem9.Text = "Edit Profile...";
		this.RemoveProfileToolStripMenuItem.Image = OculusTrayTool.My.Resources.Resources.Icon_Delete;
		this.RemoveProfileToolStripMenuItem.Name = "RemoveProfileToolStripMenuItem";
		this.RemoveProfileToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
		this.RemoveProfileToolStripMenuItem.Text = "Remove Profile";
		this.ToolTip1.AutoPopDelay = 10000;
		this.ToolTip1.InitialDelay = 200;
		this.ToolTip1.ReshowDelay = 100;
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Location = new System.Drawing.Point(12, 30);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(1000, 5);
		this.GroupBox1.TabIndex = 14;
		this.GroupBox1.TabStop = false;
		this.TextBox1.Location = new System.Drawing.Point(68, 44);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(149, 20);
		this.TextBox1.TabIndex = 20;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(223, 43);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(48, 22);
		this.Button2.TabIndex = 21;
		this.Button2.Text = "Go";
		this.Button2.UseVisualStyleBackColor = true;
		this.Label6.AutoSize = true;
		this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label6.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label6.Location = new System.Drawing.Point(13, 47);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(49, 15);
		this.Label6.TabIndex = 22;
		this.Label6.Text = "Search:";
		this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox2.Location = new System.Drawing.Point(12, 71);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(1000, 5);
		this.GroupBox2.TabIndex = 15;
		this.GroupBox2.TabStop = false;
		this.MenuStrip1.AutoSize = false;
		this.MenuStrip1.BackColor = System.Drawing.Color.Transparent;
		this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.OptionsToolStripMenuItem, this.SortingToolStripMenuItem });
		this.MenuStrip1.Location = new System.Drawing.Point(9, 3);
		this.MenuStrip1.Name = "MenuStrip1";
		this.MenuStrip1.Size = new System.Drawing.Size(152, 25);
		this.MenuStrip1.TabIndex = 33;
		this.MenuStrip1.Text = "MenuStrip1";
		this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.AddSteamVRToolStripMenuItem, this.ShowToolStripMenuItem, this.ShowRemoved3rdPartyAppsToolStripMenuItem, this.ShowIgnoredAppsToolStripMenuItem, this.RefreshLibraryToolStripMenuItem });
		this.OptionsToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
		this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
		this.OptionsToolStripMenuItem.Text = "Options";
		this.AddSteamVRToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.AddSteamVRToolStripMenuItem.Enabled = false;
		this.AddSteamVRToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.AddSteamVRToolStripMenuItem.Name = "AddSteamVRToolStripMenuItem";
		this.AddSteamVRToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
		this.AddSteamVRToolStripMenuItem.Text = "Add SteamVR";
		this.ShowToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.ShowToolStripMenuItem.CheckOnClick = true;
		this.ShowToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
		this.ShowToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
		this.ShowToolStripMenuItem.Text = "Show Hidden 3rd Party Apps";
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.CheckOnClick = true;
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.Enabled = false;
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.Name = "ShowRemoved3rdPartyAppsToolStripMenuItem";
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.Text = "Show Removed 3rd Party Apps";
		this.ShowRemoved3rdPartyAppsToolStripMenuItem.Visible = false;
		this.ShowIgnoredAppsToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.ShowIgnoredAppsToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ShowIgnoredAppsToolStripMenuItem.Name = "ShowIgnoredAppsToolStripMenuItem";
		this.ShowIgnoredAppsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
		this.ShowIgnoredAppsToolStripMenuItem.Text = "Show Ignored Apps";
		this.RefreshLibraryToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.RefreshLibraryToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.RefreshLibraryToolStripMenuItem.Name = "RefreshLibraryToolStripMenuItem";
		this.RefreshLibraryToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
		this.RefreshLibraryToolStripMenuItem.Text = "Refresh Library";
		this.SortingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.AscendingToolStripMenuItem, this.DescendingToolStripMenuItem });
		this.SortingToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.SortingToolStripMenuItem.Name = "SortingToolStripMenuItem";
		this.SortingToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
		this.SortingToolStripMenuItem.Text = "Sorting";
		this.AscendingToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.AscendingToolStripMenuItem.CheckOnClick = true;
		this.AscendingToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.AscendingToolStripMenuItem.Name = "AscendingToolStripMenuItem";
		this.AscendingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
		this.AscendingToolStripMenuItem.Text = "Ascending";
		this.DescendingToolStripMenuItem.BackColor = System.Drawing.Color.White;
		this.DescendingToolStripMenuItem.CheckOnClick = true;
		this.DescendingToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue;
		this.DescendingToolStripMenuItem.Name = "DescendingToolStripMenuItem";
		this.DescendingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
		this.DescendingToolStripMenuItem.Text = "Descending";
		this.DotNetBarTabcontrol1.Alignment = System.Windows.Forms.TabAlignment.Left;
		this.DotNetBarTabcontrol1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage1);
		this.DotNetBarTabcontrol1.ItemSize = new System.Drawing.Size(43, 85);
		this.DotNetBarTabcontrol1.Location = new System.Drawing.Point(12, 82);
		this.DotNetBarTabcontrol1.Multiline = true;
		this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
		this.DotNetBarTabcontrol1.SelectedIndex = 0;
		this.DotNetBarTabcontrol1.Size = new System.Drawing.Size(1011, 488);
		this.DotNetBarTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		this.DotNetBarTabcontrol1.TabIndex = 24;
		this.TabPage1.BackColor = System.Drawing.Color.White;
		this.TabPage1.Controls.Add(this.PicturePlay);
		this.TabPage1.Controls.Add(this.ListView1);
		this.TabPage1.Location = new System.Drawing.Point(89, 4);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(918, 480);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Library";
		this.PicturePlay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.PicturePlay.BackColor = System.Drawing.Color.Transparent;
		this.PicturePlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PicturePlay.ContextMenuStrip = this.ContextMenuStrip1;
		this.PicturePlay.Location = new System.Drawing.Point(683, 0);
		this.PicturePlay.Name = "PicturePlay";
		this.PicturePlay.Size = new System.Drawing.Size(250, 90);
		this.PicturePlay.TabIndex = 1;
		this.PicturePlay.TabStop = false;
		this.PicturePlay.Visible = false;
		this.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.ListView1.ContextMenuStrip = this.ContextMenuStrip2;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ListView1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ListView1.HideSelection = false;
		this.ListView1.Location = new System.Drawing.Point(3, 3);
		this.ListView1.MultiSelect = false;
		this.ListView1.Name = "ListView1";
		this.ListView1.Size = new System.Drawing.Size(912, 474);
		this.ListView1.TabIndex = 3;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1024, 584);
		base.Controls.Add(this.MenuStrip1);
		base.Controls.Add(this.DotNetBarTabcontrol1);
		base.Controls.Add(this.GroupBox2);
		base.Controls.Add(this.Label6);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.TextBox1);
		base.Controls.Add(this.GroupBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.MenuStrip1;
		this.MinimumSize = new System.Drawing.Size(1040, 623);
		base.Name = "frmLibrary";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Game Library";
		this.ContextMenuStrip2.ResumeLayout(false);
		this.ContextMenuStrip1.ResumeLayout(false);
		this.MenuStrip1.ResumeLayout(false);
		this.MenuStrip1.PerformLayout();
		this.DotNetBarTabcontrol1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.PicturePlay).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", "");
	}

	private static byte[] GetBytes(SQLiteDataReader reader)
	{
		byte[] array = new byte[2048];
		long num = 0L;
		checked
		{
			using MemoryStream memoryStream = new MemoryStream();
			long target = default(long);
			for (; InlineAssignHelper(ref target, reader.GetBytes(0, num, array, 0, array.Length)) > 0; num += target)
			{
				memoryStream.Write(array, 0, (int)target);
			}
			return memoryStream.ToArray();
		}
	}

	private static T InlineAssignHelper<T>(ref T target, T value)
	{
		target = value;
		return value;
	}

	public static void SetDoubleBuffering(Control control, bool value)
	{
		PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		property.SetValue(control, value, null);
	}

	private void GetOculusLibrary(string p)
	{
		SetDoubleBuffering(ListView1, value: true);
		PicturePlay.Visible = false;
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetOculusLibrary");
		}
		if (!File.Exists(Application.StartupPath + "\\data.sqlite"))
		{
			return;
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("Opening database copy");
		}
		try
		{
			if (cnn.State == ConnectionState.Closed)
			{
				cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
				cnn.Open();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Failed to open database copy: " + ex2.Message);
			Interaction.MsgBox("Failed to open database copy: " + ex2.Message, MsgBoxStyle.Critical, "Error opening database");
			FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex2.Message);
			MyProject.Forms.FrmMain.hasError = true;
			ProjectData.ClearProjectError();
			return;
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("Parsing Manifests in " + p);
		}
		SQLiteCommand sQLiteCommand = new SQLiteCommand(cnn);
		ListView1.BeginUpdate();
		string[] files = Directory.GetFiles(p, "*.mini");
		checked
		{
			foreach (string text in files)
			{
				string json = File.ReadAllText(text);
				JObject jObject = JObject.Parse(json);
				string text2 = p.Replace("\\Manifests", "") + "\\Software";
				string text3 = jObject.SelectToken("canonicalName").ToString();
				string text4 = jObject.SelectToken("appId").ToString();
				string text5 = text2 + "\\" + text3 + "\\" + jObject.SelectToken("launchFile").ToString().Replace("/", "\\");
				string text6 = MySettingsProperty.Settings.OculusPath.TrimEnd('\\') + "\\CoreData\\Software\\StoreAssets\\" + text3 + "_assets";
				string text7 = text6 + "\\small_landscape_image.jpg";
				if (!File.Exists(text7))
				{
					Log.WriteToLog("Could not find game icon '" + text7 + "', looking in the other library paths");
					string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
					foreach (string text8 in array)
					{
						text6 = text8.TrimEnd('\\') + "\\Software\\StoreAssets\\" + text3 + "_assets";
						text7 = text6 + "\\small_landscape_image.jpg";
						if (File.Exists(text7))
						{
							Log.WriteToLog("Found game icon at '" + text7 + "'");
							break;
						}
					}
				}
				if (Operators.CompareString(text4, "", TextCompare: false) == 0)
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder();
				try
				{
					sQLiteCommand.CommandText = "Select value from Objects WHERE hashkey='" + text4 + "' AND typename='Application'";
					using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
					if (sQLiteDataReader.HasRows)
					{
						while (sQLiteDataReader.Read())
						{
							byte[] bytes = GetBytes(sQLiteDataReader);
							stringBuilder.Append(Encoding.Default.GetString(bytes));
						}
						goto IL_03fb;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Log.WriteToLog("Failed to read database entry for appId '" + text4 + "': " + ex4.Message);
					FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text4 + "': " + ex4.Message);
					MyProject.Forms.FrmMain.hasError = true;
					ProjectData.ClearProjectError();
					return;
				}
				continue;
				IL_03fb:
				string text9 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
				string text10 = "display:name::";
				string value = ((Conversions.ToInteger(MyProject.Forms.FrmMain.OculusAppVersion) < 118) ? ":grouping" : ":display:short:description");
				int num = text9.IndexOf(text10);
				int num2 = text9.IndexOf(value);
				if (num <= -1 || num2 <= -1)
				{
					continue;
				}
				string text11 = Strings.Mid(text9, num + text10.Length + 1, num2 - num - text10.Length).Replace(":", " ").TrimEnd(':')
					.TrimEnd(' ');
				text11 = text11.Remove(text11.Length - 1);
				ListViewItem listViewItem = ListView1.FindItemWithText(text11);
				if (listViewItem != null)
				{
					continue;
				}
				if (File.Exists(text7))
				{
					using Image image = Image.FromFile(text7);
					imageListLarge.Images.Add(text5, image);
				}
				else
				{
					imageListLarge.Images.Add(text5, Resources.removed_app);
				}
				ListViewItem listViewItem2 = new ListViewItem(text11, text5);
				listViewItem2.Tag = Path.GetFileName(text5) + "," + text6 + "," + text.Replace(".mini", "") + "," + text5;
				if (ManualStartProfiles.ContainsKey(text5) | ManualStartProfiles.ContainsKey(text5.ToLower()))
				{
					listViewItem2.ForeColor = Color.Green;
				}
				else if (DisplayNameList.Contains(text11.ToLower()))
				{
					listViewItem2.ForeColor = Color.Blue;
				}
				else
				{
					listViewItem2.ForeColor = Color.Red;
				}
				ListView1.Items.Add(listViewItem2);
				if (!IconGameList.Contains(text11))
				{
					IconGameList.Add(text11);
				}
			}
			ListView1.Sorting = SortOrder.Ascending;
			ListView1.Sort();
			ListView1.EndUpdate();
			sQLiteCommand.Dispose();
			cnn.Close();
			if (Globals.dbg)
			{
				Log.WriteToLog("Connection closed");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetOculusLibrary");
			}
		}
	}

	private void GetThirdPartyApps(string p)
	{
		int try0001_dispatch = -1;
		int num = default(int);
		int num2 = default(int);
		int num3 = default(int);
		SQLiteCommand sQLiteCommand = default(SQLiteCommand);
		string text = default(string);
		string text2 = default(string);
		List<string> list = default(List<string>);
		string fileName = default(string);
		string fullpath = default(string);
		string text3 = default(string);
		string text4 = default(string);
		string json = default(string);
		JObject jObject = default(JObject);
		JToken jToken = default(JToken);
		IEnumerator<JToken> enumerator = default(IEnumerator<JToken>);
		JToken current = default(JToken);
		string text6 = default(string);
		string[] files = default(string[]);
		int num6 = default(int);
		string json2 = default(string);
		JObject jObject2 = default(JObject);
		bool flag = default(bool);
		List<JToken> list2 = default(List<JToken>);
		List<JToken>.Enumerator enumerator2 = default(List<JToken>.Enumerator);
		JProperty jProperty = default(JProperty);
		StringBuilder stringBuilder = default(StringBuilder);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				int num5;
				string text5;
				string name;
				switch (try0001_dispatch)
				{
				default:
					num = 1;
					if (Globals.dbg)
					{
						goto IL_000f;
					}
					goto IL_001c;
				case 2334:
					{
						num2 = num;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num2 + 1;
						num2 = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000f;
						case 3:
							goto IL_001c;
						case 4:
							goto IL_0024;
						case 5:
							goto IL_0033;
						case 6:
							goto IL_0041;
						case 7:
							goto IL_0069;
						case 8:
							goto IL_0086;
						case 9:
							goto IL_0098;
						case 11:
							goto IL_00ad;
						case 12:
							goto IL_00c2;
						case 13:
							goto IL_00ce;
						case 14:
							goto IL_00da;
						case 15:
							goto IL_00eb;
						case 16:
							goto IL_0105;
						case 17:
							goto IL_010b;
						case 18:
							goto IL_0121;
						case 19:
							goto IL_014b;
						case 20:
							goto IL_015f;
						case 21:
							goto IL_016b;
						case 22:
							goto IL_0179;
						case 23:
						case 24:
							goto IL_0195;
						case 25:
							goto IL_01a8;
						case 10:
						case 26:
						case 27:
						case 28:
							goto IL_01ba;
						case 29:
							goto IL_01d9;
						case 30:
							goto IL_01e2;
						case 32:
							goto IL_01fc;
						case 33:
							goto IL_020a;
						case 34:
							goto IL_021f;
						case 35:
							goto IL_022b;
						case 36:
							goto IL_0237;
						case 37:
							goto IL_024d;
						case 38:
							goto IL_0263;
						case 39:
							goto IL_027e;
						case 40:
							goto IL_029d;
						case 41:
							goto IL_02a9;
						case 43:
							goto IL_02d6;
						case 45:
							goto IL_02ea;
						case 46:
							goto IL_0319;
						case 42:
						case 44:
						case 48:
						case 49:
							goto IL_0352;
						case 47:
						case 50:
							goto IL_0365;
						case 51:
							goto IL_0376;
						case 52:
							goto IL_0384;
						case 53:
							goto IL_0392;
						case 55:
						case 56:
							goto IL_03b3;
						case 57:
							goto IL_03c4;
						case 58:
							goto IL_03d2;
						case 59:
							goto IL_03ec;
						case 61:
							goto IL_0407;
						case 62:
							goto IL_0421;
						case 63:
							goto IL_042b;
						case 64:
							goto IL_0442;
						case 65:
							goto IL_0464;
						case 66:
						case 67:
							goto IL_0475;
						case 68:
							goto IL_0485;
						case 69:
							goto IL_04a2;
						case 70:
							goto IL_04eb;
						case 71:
							goto IL_0505;
						case 72:
							goto IL_0513;
						case 74:
						case 75:
							goto IL_0528;
						case 76:
							goto IL_0546;
						case 77:
							goto IL_0554;
						case 78:
							goto IL_056e;
						case 79:
						case 80:
							goto IL_0584;
						case 81:
							goto IL_05a5;
						case 82:
							goto IL_05b3;
						case 83:
							goto IL_05cd;
						case 84:
							goto IL_05ea;
						case 85:
						case 86:
							goto IL_06b9;
						case 87:
							goto IL_06c4;
						case 88:
							goto IL_06d3;
						case 89:
							goto IL_06e1;
						case 31:
						case 54:
						case 60:
						case 73:
						case 90:
						case 91:
							goto IL_06f0;
						case 92:
							goto IL_070a;
						case 93:
							goto IL_0719;
						case 94:
							goto IL_0730;
						case 95:
							goto IL_073f;
						case 96:
							goto IL_074d;
						case 97:
						case 98:
							goto IL_075d;
						case 99:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 100:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_05ea:
					num = 84;
					using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
					{
						if (sQLiteDataReader.HasRows)
						{
							if (Globals.dbg)
							{
								Log.WriteToLog("GetThirdPartyLibraryApps:  -> Found entry for " + text + ": UserAppPlayTime");
							}
							if (Globals.dbg)
							{
								Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + text2 + "' to Library view");
							}
							AddThirdPartyGameToLibrary(p, list, text, text2, fileName, fullpath);
						}
						else
						{
							if (!MyProject.Forms.FrmMain.includedApps.Contains(text3))
							{
								if (Globals.dbg)
								{
									Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
								}
								goto IL_06f0;
							}
							AddThirdPartyGameToLibrary(p, list, text, text2, fileName, fullpath);
						}
					}
					goto IL_06b9;
					IL_06b9:
					num = 86;
					sQLiteCommand.Dispose();
					goto IL_06c4;
					IL_05cd:
					num = 83;
					sQLiteCommand.CommandText = "select value from Objects WHERE hashkey LIKE \"%" + text + "%\" AND typename='UserAppPlayTime'";
					goto IL_05ea;
					IL_06c4:
					num = 87;
					cnn.Close();
					goto IL_06d3;
					IL_000f:
					num = 2;
					Log.WriteToLog("Entering GetThirdPartyApps");
					goto IL_001c;
					IL_001c:
					num = 3;
					list = new List<string>();
					goto IL_0024;
					IL_0024:
					num = 4;
					PicturePlay.Visible = false;
					goto IL_0033;
					IL_0033:
					num = 5;
					ListView1.BeginUpdate();
					goto IL_0041;
					IL_0041:
					num = 6;
					if (Operators.CompareString(MyProject.Forms.FrmMain.SteamPath, "", TextCompare: false) != 0)
					{
						goto IL_0069;
					}
					goto IL_01ba;
					IL_0069:
					num = 7;
					text4 = Path.Combine(MyProject.Forms.FrmMain.SteamPath, "config\\steamapps.vrmanifest");
					goto IL_0086;
					IL_0086:
					num = 8;
					if (!File.Exists(text4))
					{
						goto IL_0098;
					}
					goto IL_00ad;
					IL_0098:
					num = 9;
					Log.WriteToLog("Could not locate Steam VR manifest");
					goto IL_01ba;
					IL_00ad:
					num = 11;
					Log.WriteToLog("Found Steam VR manifest: " + text4);
					goto IL_00c2;
					IL_00c2:
					num = 12;
					json = File.ReadAllText(text4);
					goto IL_00ce;
					IL_00ce:
					num = 13;
					jObject = JObject.Parse(json);
					goto IL_00da;
					IL_00da:
					num = 14;
					jToken = jObject.SelectToken("applications");
					goto IL_00eb;
					IL_00eb:
					num = 15;
					enumerator = ((IEnumerable<JToken>)jToken).GetEnumerator();
					goto IL_0198;
					IL_0198:
					if (enumerator.MoveNext())
					{
						current = enumerator.Current;
						goto IL_0105;
					}
					goto IL_01a8;
					IL_01a8:
					num = 25;
					enumerator?.Dispose();
					goto IL_01ba;
					IL_06e1:
					num = 89;
					Log.WriteToLog("Connection closed");
					goto IL_06f0;
					IL_06d3:
					num = 88;
					if (Globals.dbg)
					{
						goto IL_06e1;
					}
					goto IL_06f0;
					IL_0105:
					num = 16;
					num5 = 0;
					goto IL_010b;
					IL_010b:
					num = 17;
					text5 = current["app_key"].ToString();
					goto IL_0121;
					IL_0121:
					num = 18;
					text6 = current["strings"]["en_us"]["name"].ToString();
					goto IL_014b;
					IL_014b:
					num = 19;
					if (!list.Contains(text6))
					{
						goto IL_015f;
					}
					goto IL_0195;
					IL_015f:
					num = 20;
					list.Add(text6);
					goto IL_016b;
					IL_016b:
					num = 21;
					if (Globals.dbg)
					{
						goto IL_0179;
					}
					goto IL_0195;
					IL_0179:
					num = 22;
					Log.WriteToLog("GetThirdPartyLibraryApps: Steam game '" + text6 + "' added to list");
					goto IL_0195;
					IL_0195:
					num = 24;
					goto IL_0198;
					IL_01ba:
					num = 28;
					files = Directory.GetFiles(p, "*.json");
					num6 = 0;
					goto IL_06f9;
					IL_06f9:
					if (num6 < files.Length)
					{
						text3 = files[num6];
						goto IL_01d9;
					}
					goto IL_070a;
					IL_070a:
					num = 92;
					ListView1.EndUpdate();
					goto IL_0719;
					IL_0719:
					num = 93;
					if (cnn.State == ConnectionState.Open)
					{
						goto IL_0730;
					}
					goto IL_075d;
					IL_0730:
					num = 94;
					cnn.Close();
					goto IL_073f;
					IL_073f:
					num = 95;
					if (Globals.dbg)
					{
						goto IL_074d;
					}
					goto IL_075d;
					IL_074d:
					num = 96;
					Log.WriteToLog("Connection closed");
					goto IL_075d;
					IL_075d:
					num = 98;
					if (!Globals.dbg)
					{
						goto end_IL_0001_3;
					}
					break;
					IL_06f0:
					num = 91;
					num6 = checked(num6 + 1);
					goto IL_06f9;
					IL_01d9:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_01e2;
					IL_01e2:
					num = 30;
					if (!text3.Contains("_assets.json"))
					{
						goto IL_01fc;
					}
					goto IL_06f0;
					IL_01fc:
					num = 32;
					if (Globals.dbg)
					{
						goto IL_020a;
					}
					goto IL_021f;
					IL_020a:
					num = 33;
					Log.WriteToLog("Opening " + text3);
					goto IL_021f;
					IL_021f:
					num = 34;
					json2 = File.ReadAllText(text3);
					goto IL_022b;
					IL_022b:
					num = 35;
					jObject2 = JObject.Parse(json2);
					goto IL_0237;
					IL_0237:
					num = 36;
					flag = (bool)jObject2.SelectToken("thirdParty");
					goto IL_024d;
					IL_024d:
					num = 37;
					text = jObject2.SelectToken("canonicalName").ToString();
					goto IL_0263;
					IL_0263:
					num = 38;
					list2 = jObject2.Children().ToList();
					goto IL_027e;
					IL_027e:
					num = 39;
					enumerator2 = list2.GetEnumerator();
					goto IL_0355;
					IL_0355:
					if (enumerator2.MoveNext())
					{
						jProperty = (JProperty)enumerator2.Current;
						goto IL_029d;
					}
					goto IL_0365;
					IL_02d6:
					num = 43;
					text2 = jProperty.Value.ToString();
					goto IL_0352;
					IL_029d:
					num = 40;
					jProperty.CreateReader();
					goto IL_02a9;
					IL_02a9:
					num = 41;
					name = jProperty.Name;
					if (Operators.CompareString(name, "displayName", TextCompare: false) == 0)
					{
						goto IL_02d6;
					}
					if (Operators.CompareString(name, "launchFile", TextCompare: false) == 0)
					{
						goto IL_02ea;
					}
					goto IL_0352;
					IL_0352:
					num = 49;
					goto IL_0355;
					IL_02ea:
					num = 45;
					fullpath = jProperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
					goto IL_0319;
					IL_0319:
					num = 46;
					fileName = Path.GetFileName(jProperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
					goto IL_0365;
					IL_0365:
					num = 50;
					((IDisposable)enumerator2).Dispose();
					goto IL_0376;
					IL_0376:
					num = 51;
					if (!flag)
					{
						goto IL_0384;
					}
					goto IL_03b3;
					IL_0384:
					num = 52;
					if (Globals.dbg)
					{
						goto IL_0392;
					}
					goto IL_06f0;
					IL_0392:
					num = 53;
					Log.WriteToLog("'" + text2 + "' is not thirdParty, ignoring for now");
					goto IL_06f0;
					IL_03b3:
					num = 56;
					if (list.Contains(text2))
					{
						goto IL_03c4;
					}
					goto IL_0407;
					IL_03c4:
					num = 57;
					if (Globals.dbg)
					{
						goto IL_03d2;
					}
					goto IL_03ec;
					IL_03d2:
					num = 58;
					Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + text2 + "' to Library view");
					goto IL_03ec;
					IL_03ec:
					num = 59;
					AddThirdPartyGameToLibrary(p, list, text, text2, fileName, fullpath);
					goto IL_06f0;
					IL_0407:
					num = 61;
					Log.WriteToLog("'" + text2 + "' not found in Steam game list, getting info from the Oculus Database");
					goto IL_0421;
					IL_0421:
					num = 62;
					stringBuilder = new StringBuilder();
					goto IL_042b;
					IL_042b:
					num = 63;
					if (cnn.State == ConnectionState.Closed)
					{
						goto IL_0442;
					}
					goto IL_0475;
					IL_0442:
					num = 64;
					cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
					goto IL_0464;
					IL_0464:
					num = 65;
					cnn.Open();
					goto IL_0475;
					IL_0475:
					num = 67;
					sQLiteCommand = new SQLiteCommand(cnn);
					goto IL_0485;
					IL_0485:
					num = 68;
					sQLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + text + "_LocalAppState' AND typename='LocalApplicationState'";
					goto IL_04a2;
					IL_04a2:
					num = 69;
					using (SQLiteDataReader sQLiteDataReader2 = sQLiteCommand.ExecuteReader())
					{
						while (sQLiteDataReader2.Read())
						{
							byte[] bytes = GetBytes(sQLiteDataReader2);
							stringBuilder.Append(Encoding.Default.GetString(bytes));
						}
					}
					goto IL_04eb;
					IL_04eb:
					num = 70;
					if (stringBuilder.ToString().Contains("FLAT"))
					{
						goto IL_0505;
					}
					goto IL_0528;
					IL_0505:
					num = 71;
					if (Globals.dbg)
					{
						goto IL_0513;
					}
					goto IL_06f0;
					IL_0513:
					num = 72;
					Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
					goto IL_06f0;
					IL_0528:
					num = 75;
					if (Operators.CompareString(stringBuilder.ToString(), "", TextCompare: false) != 0)
					{
						goto IL_0546;
					}
					goto IL_0584;
					IL_0546:
					num = 76;
					if (Globals.dbg)
					{
						goto IL_0554;
					}
					goto IL_056e;
					IL_0554:
					num = 77;
					Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + text2 + "' to Library view");
					goto IL_056e;
					IL_056e:
					num = 78;
					AddThirdPartyGameToLibrary(p, list, text, text2, fileName, fullpath);
					goto IL_0584;
					IL_0584:
					num = 80;
					if (Operators.CompareString(stringBuilder.ToString(), "", TextCompare: false) == 0)
					{
						goto IL_05a5;
					}
					goto IL_06b9;
					IL_05a5:
					num = 81;
					if (Globals.dbg)
					{
						goto IL_05b3;
					}
					goto IL_05cd;
					IL_05b3:
					num = 82;
					Log.WriteToLog("GetThirdPartyLibraryApps:  -> Not found, looking for secondary entry: " + text + ": UserAppPlayTime");
					goto IL_05cd;
					end_IL_0001_2:
					break;
				}
				num = 99;
				Log.WriteToLog("Exiting GetThirdPartyApps");
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 2334;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num2 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void AddThirdPartyGameToLibrary(string p, List<string> steamGameList, string canonName, string DisplayName, string LaunchFile, string fullpath)
	{
		try
		{
			if (IconGameList.Contains(DisplayName))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("AddThirdPartyGameToLibrary: '" + DisplayName + "' has already been added to the library, skipping");
				}
				return;
			}
			bool flag = false;
			string text = p + "\\" + canonName + ".json";
			string text2 = MySettingsProperty.Settings.OculusPath.TrimEnd('\\') + "\\CoreData\\Software\\StoreAssets\\" + canonName + "_assets";
			string text3 = text2 + "\\small_landscape_image.jpg";
			if (File.Exists(text3))
			{
				flag = true;
				if (Globals.dbg)
				{
					Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + text3);
				}
			}
			else
			{
				string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
				foreach (string text4 in array)
				{
					text2 = text4.TrimEnd('\\') + "\\Software\\StoreAssets\\" + canonName + "_assets";
					text3 = text2 + "\\small_landscape_image.jpg";
					if (File.Exists(text3))
					{
						flag = true;
						if (Globals.dbg)
						{
							Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + text3);
						}
						break;
					}
				}
			}
			if (!flag)
			{
				Log.WriteToLog("Could not locate local icon for '" + DisplayName + "'");
				text3 = "Default Unknown";
			}
			if (DisplayName.ToLower().EndsWith(".exe") | (Operators.CompareString(DisplayName.ToLower(), "unknown app", TextCompare: false) == 0))
			{
				DisplayName = Path.GetFileNameWithoutExtension(LaunchFile);
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("    App is thirdParty");
				Log.WriteToLog("    DisplayName: '" + DisplayName + "'");
				Log.WriteToLog("    LaunchFile: '" + LaunchFile + "'");
				Log.WriteToLog("    FullPath: '" + fullpath + "'");
				Log.WriteToLog("    assetsPath: '" + text2 + "'");
				Log.WriteToLog("    iconFile: '" + text3 + "'");
			}
			string tag = Path.GetFileName(LaunchFile) + "," + text2 + "," + text + ",3rdParty," + LaunchFile;
			if (!OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Library") & !OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both"))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("    Hidden: False");
				}
				if (File.Exists(text3))
				{
					using Image image = Image.FromFile(text3);
					if (Globals.dbg)
					{
						Log.WriteToLog("AddThirdPartyGameToLibrary: Adding '" + DisplayName + "' (" + LaunchFile + ") to library with '" + text3 + "'");
					}
					imageListLarge.Images.Add(LaunchFile, image);
				}
				else
				{
					if (Globals.dbg)
					{
						Log.WriteToLog("AddThirdPartyGameToLibrary: Adding '" + DisplayName + "' (" + LaunchFile + ") to library with [???] icon");
					}
					imageListLarge.Images.Add(LaunchFile, Resources.removed_app);
				}
				ListViewItem listViewItem = new ListViewItem(DisplayName, LaunchFile);
				listViewItem.Tag = tag;
				if (ManualStartProfiles.ContainsKey(fullpath) | ManualStartProfiles.ContainsKey(fullpath.ToLower()))
				{
					listViewItem.ForeColor = Color.Green;
				}
				else if (DisplayNameList.Contains(DisplayName.ToLower()))
				{
					listViewItem.ForeColor = Color.Blue;
				}
				else
				{
					listViewItem.ForeColor = Color.Red;
				}
				ListView1.Items.Add(listViewItem);
				if (!IconGameList.Contains(DisplayName))
				{
					IconGameList.Add(DisplayName);
				}
			}
			else if (Globals.dbg)
			{
				Log.WriteToLog("    Hidden: True");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("AddThirdPartyGameToLibrary: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void Library_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (changeMade)
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			if (processesByName.Length > 0)
			{
				Interaction.MsgBox("You may need to restart oculus Home to see the new icons in VR.", MsgBoxStyle.Information, "Oculus Tray Tool");
			}
		}
		MySettingsProperty.Settings.LibraryWindowLocation = base.Location;
		MySettingsProperty.Settings.LibraryWindowSize = base.Size;
		MySettingsProperty.Settings.Save();
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
	}

	private void Library_Load(object sender, EventArgs e)
	{
		LoadLibrary();
	}

	public void LoadLibrary()
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		Log.WriteToLog("Opening Library");
		changeMade = false;
		if (MySettingsProperty.Settings.LibraryWindowLocation != default(Point))
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Setting Library GUI location to " + MySettingsProperty.Settings.LibraryWindowLocation.ToString());
			}
			base.Location = MySettingsProperty.Settings.LibraryWindowLocation;
		}
		else
		{
			CenterToScreen();
			MySettingsProperty.Settings.LibraryWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
		}
		if ((base.Location.X < 0) | (base.Location.Y < 0))
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Library GUI location has negative number, adjusting");
			}
			CenterToScreen();
			MySettingsProperty.Settings.LibraryWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
		}
		base.Size = MySettingsProperty.Settings.LibraryWindowSize;
		rs.FindAllControls(this);
		rs.ResizeAllControls(this, MyProject.Forms.FrmMain.TrackBar1.Value);
		imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
		ImgListOverlay.ColorDepth = ColorDepth.Depth32Bit;
		Image play = Resources.play2;
		ImgListOverlay.Images.Add(play);
		PicturePlay.Visible = false;
		icons.Images.Clear();
		icons.ColorDepth = ColorDepth.Depth32Bit;
		icons.ImageSize = new Size(250, 90);
		if (!libraryLoaded)
		{
			Log.WriteToLog("Library not loaded");
			PopulateList();
		}
		else if (Globals.dbg)
		{
			Log.WriteToLog("Library already loaded, proceeding");
		}
	}

	private object GenerateSHA256Hash(string filename)
	{
		using FileStream inputStream = File.OpenRead(filename);
		SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] array = sHA256Managed.ComputeHash(inputStream);
		return BitConverter.ToString(array).Replace("-", string.Empty).ToLower();
	}

	public void PopulateList()
	{
		Cursor = Cursors.WaitCursor;
		if (Globals.dbg)
		{
			Log.WriteToLog("Loading Library view");
		}
		PicturePlay.Visible = false;
		ListView1.Items.Clear();
		imageListLarge.Images.Clear();
		imageListLarge.ImageSize = new Size(250, 90);
		ListView1.LargeImageList = imageListLarge;
		ListView1.View = View.LargeIcon;
		ContextMenuStrip1.Visible = true;
		ContextMenuStrip1.Close();
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
		{
			GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
		}
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
		{
			GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
		}
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
		{
			GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
		}
		if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0)
		{
			string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
			foreach (string text in array)
			{
				if (Directory.Exists(text.TrimEnd('\\') + "\\Manifests"))
				{
					GetOculusLibrary(text.TrimEnd('\\') + "\\Manifests");
				}
				if (Directory.Exists(text.TrimEnd('\\') + "\\CoreData\\Manifests"))
				{
					GetThirdPartyApps(text.TrimEnd('\\') + "\\CoreData\\Manifests");
				}
			}
		}
		MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
		MyProject.Forms.frmProfiles.GameList.Clear();
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
		{
			GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
		}
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
		{
			GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
		}
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
		{
			GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
		}
		if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0)
		{
			string[] array2 = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
			foreach (string text2 in array2)
			{
				if (Directory.Exists(text2.TrimEnd('\\') + "\\Manifests"))
				{
					GetGames.GetFiles(text2.TrimEnd('\\') + "\\Manifests");
				}
				if (Directory.Exists(text2.TrimEnd('\\') + "\\CoreData\\Manifests"))
				{
					GetGames.GetThirdPartyApps(text2.TrimEnd('\\') + "\\CoreData\\Manifests");
				}
			}
		}
		libraryLoaded = true;
		Cursor = Cursors.Default;
	}

	private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
	{
		if (ListView1.SelectedItems.Count == 0)
		{
			return;
		}
		if ((ListView1.SelectedItems.Count > 0) & PicturePlay.Visible)
		{
			if (ListView1.SelectedItems[0].ForeColor == Color.Red)
			{
				ToolStripMenuItem1.Visible = true;
				ToolStripMenuItem9.Visible = false;
				RemoveProfileToolStripMenuItem.Visible = false;
			}
			if (ListView1.SelectedItems[0].ForeColor == Color.Green)
			{
				ToolStripMenuItem1.Visible = false;
				ToolStripMenuItem9.Visible = true;
				RemoveProfileToolStripMenuItem.Visible = true;
			}
			if (Conversions.ToBoolean(NewLateBinding.LateGet(ListView1.SelectedItems[0].Tag, null, "contains", new object[1] { "3rdParty" }, null, null, null)))
			{
				ToolStripMenuItem2.Visible = true;
				ToolStripMenuItem4.Visible = true;
				ToolStripMenuItem5.Visible = true;
				ToolStripMenuItem7.Visible = true;
				ToolStripMenuItem8.Visible = true;
			}
			else if (Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(ListView1.SelectedItems[0].Tag, null, "contains", new object[1] { "hidden" }, null, null, null))))
			{
				ToolStripMenuItem2.Visible = true;
				ToolStripMenuItem4.Visible = false;
				ToolStripMenuItem5.Visible = false;
				ToolStripMenuItem7.Visible = true;
				ToolStripMenuItem8.Visible = true;
			}
			if (ShowRemoved3rdPartyAppsToolStripMenuItem.Checked)
			{
				ToolStripMenuItem2.Visible = false;
				ToolStripMenuItem4.Visible = false;
				ToolStripMenuItem5.Visible = false;
				ToolStripMenuItem7.Visible = false;
				ToolStripMenuItem8.Visible = false;
			}
		}
		else
		{
			ToolStripMenuItem1.Visible = false;
			ToolStripMenuItem2.Visible = false;
			ToolStripMenuItem4.Visible = false;
			ToolStripMenuItem5.Visible = false;
			ToolStripMenuItem7.Visible = false;
			ToolStripMenuItem8.Visible = false;
		}
	}

	private void CreateManifest(string canonicalName, string displayName, string files, string launchFile, string path)
	{
		StringBuilder sb = new StringBuilder();
		StringWriter stringWriter = new StringWriter(sb);
		using (JsonWriter jsonWriter = new JsonTextWriter(stringWriter))
		{
			jsonWriter.Formatting = Formatting.Indented;
			jsonWriter.WriteStartObject();
			jsonWriter.WritePropertyName("canonicalName");
			jsonWriter.WriteValue(canonicalName);
			jsonWriter.WritePropertyName("displayName");
			jsonWriter.WriteValue(displayName);
			jsonWriter.WritePropertyName("files");
			jsonWriter.WriteStartObject();
			jsonWriter.WritePropertyName(files);
			jsonWriter.WriteValue("");
			jsonWriter.WriteEndObject();
			jsonWriter.WritePropertyName("firewallExceptionsRequired");
			jsonWriter.WriteValue(value: false);
			jsonWriter.WritePropertyName("isCore");
			jsonWriter.WriteValue(value: false);
			jsonWriter.WritePropertyName("launchFile");
			jsonWriter.WriteValue(launchFile);
			jsonWriter.WritePropertyName("launchParameters");
			jsonWriter.WriteValue("");
			jsonWriter.WritePropertyName("manifestVersion");
			jsonWriter.WriteValue(0);
			jsonWriter.WritePropertyName("packageType");
			jsonWriter.WriteValue("APP");
			jsonWriter.WritePropertyName("thirdParty");
			jsonWriter.WriteValue(value: true);
			jsonWriter.WritePropertyName("version");
			jsonWriter.WriteValue("1");
			jsonWriter.WritePropertyName("versionCode");
			jsonWriter.WriteValue(1);
			jsonWriter.WriteEndObject();
		}
		StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
		streamWriter.Write(stringWriter);
		streamWriter.Close();
	}

	private void CreateAssetManifest(string canonicalName, string color, Dictionary<string, string> files, string parameters, string path)
	{
		StringBuilder sb = new StringBuilder();
		StringWriter stringWriter = new StringWriter(sb);
		using (JsonWriter jsonWriter = new JsonTextWriter(stringWriter))
		{
			jsonWriter.Formatting = Formatting.Indented;
			jsonWriter.WriteStartObject();
			jsonWriter.WritePropertyName("dominantColor");
			jsonWriter.WriteValue(color);
			jsonWriter.WritePropertyName("files");
			jsonWriter.WriteStartObject();
			foreach (KeyValuePair<string, string> file in files)
			{
				jsonWriter.WritePropertyName(file.Key);
				jsonWriter.WriteValue(file.Value);
			}
			jsonWriter.WriteEndObject();
			jsonWriter.WritePropertyName("packageType");
			jsonWriter.WriteValue("ASSET_BUNDLE");
			jsonWriter.WritePropertyName("isCore");
			jsonWriter.WriteValue(value: false);
			jsonWriter.WritePropertyName("appId");
			jsonWriter.WriteNull();
			jsonWriter.WritePropertyName("canonicalName");
			jsonWriter.WriteValue(canonicalName);
			jsonWriter.WritePropertyName("launchFile");
			jsonWriter.WriteNull();
			jsonWriter.WritePropertyName("launchParameters");
			if (Operators.CompareString(parameters, "", TextCompare: false) == 0)
			{
				jsonWriter.WriteNull();
			}
			else
			{
				jsonWriter.WriteValue(parameters);
			}
			jsonWriter.WritePropertyName("launchFile2D");
			jsonWriter.WriteNull();
			jsonWriter.WritePropertyName("launchParameters2D");
			jsonWriter.WriteNull();
			jsonWriter.WritePropertyName("version");
			jsonWriter.WriteValue("1");
			jsonWriter.WritePropertyName("versionCode");
			jsonWriter.WriteValue(1);
			jsonWriter.WritePropertyName("redistributables");
			jsonWriter.WriteNull();
			jsonWriter.WritePropertyName("firewallExceptionsRequired");
			jsonWriter.WriteValue(value: false);
			jsonWriter.WritePropertyName("thirdParty");
			jsonWriter.WriteValue(value: true);
			jsonWriter.WritePropertyName("manifestVersion");
			jsonWriter.WriteValue(0);
			jsonWriter.WriteEndObject();
		}
		StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
		streamWriter.Write(stringWriter);
		streamWriter.Close();
	}

	private void ToolStripMenuItem2_Click(object sender, EventArgs e)
	{
		string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
		if (File.Exists(array[2]))
		{
			string json = File.ReadAllText(array[2]);
			string text = JToken.Parse(json).ToString(Formatting.Indented);
			MyProject.Forms.frmProperties.RichTextBox1.Text = text;
			MyProject.Forms.frmProperties.TextBox1.Text = array[2];
			MyProject.Forms.frmProperties.fname = array[2];
			rs.FindAllControls(MyProject.Forms.frmProperties);
			rs.ResizeAllControls(MyProject.Forms.frmProperties, MyProject.Forms.FrmMain.TrackBar1.Value);
			if (Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(ListView1.SelectedItems[0].Tag, null, "contains", new object[1] { "3rdParty" }, null, null, null))))
			{
				MyProject.Forms.frmProperties.Button1.Enabled = false;
			}
			else
			{
				MyProject.Forms.frmProperties.Button1.Enabled = true;
			}
			MyProject.Forms.frmProperties.ShowDialog();
		}
	}

	private void ToolStripMenuItem4_Click(object sender, EventArgs e)
	{
		string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
		OTTDB.HideApp(ListView1.SelectedItems[0].Text, array[0], "Library");
		PopulateList();
	}

	private void ToolStripMenuItem5_Click(object sender, EventArgs e)
	{
		string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
		OTTDB.HideApp(ListView1.SelectedItems[0].Text, array[0], "Both");
		PopulateList();
	}

	private void ToolStripMenuItem7_Click(object sender, EventArgs e)
	{
		LaunchApp();
	}

	private void LaunchApp()
	{
		checked
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
				if (!File.Exists(array[2]))
				{
					return;
				}
				string text = "";
				string text2 = "";
				List<string> list = new List<string>();
				list = GetAppInfo(array[2], "");
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					text = list[0];
					text2 = list[1];
				}
				if ((Operators.CompareString(text, "", TextCompare: false) != 0) & File.Exists(text))
				{
					MyProject.Forms.FrmMain.ManualStart = true;
					if (!MyProject.Forms.FrmMain.HomeIsRunning)
					{
						RunCommand.StartHome();
						Thread.Sleep(3000);
					}
					if (ManualStartProfiles.ContainsKey(text.ToLower()))
					{
						Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
						ApplyProfile(text.TrimStart().TrimEnd());
					}
					else
					{
						Log.WriteToLog("No profile found for '" + text + "'");
					}
					Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text);
					if (Operators.CompareString(text2, "", TextCompare: false) != 0)
					{
						Log.WriteToLog(" -> " + text.TrimStart().TrimEnd() + " " + text2.TrimStart().TrimEnd());
					}
					else
					{
						Log.WriteToLog(" -> " + text.TrimStart().TrimEnd());
					}
					Cursor = Cursors.Default;
					Process.Start(text, text2);
					if (Globals.dbg)
					{
						Log.WriteToLog("Adding Worker AppWatchWorker");
					}
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += MyProject.Forms.FrmMain.AppWork;
					backgroundWorker.RunWorkerAsync();
					if (Globals.dbg)
					{
						Log.WriteToLog("Worker started");
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("LaunchApp(): " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ApplyProfile(string appName)
	{
		string value = "";
		checked
		{
			try
			{
				if (!ManualStartProfiles.TryGetValue(appName.ToLower(), out value))
				{
					return;
				}
				Thread thread = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool(value);
				});
				thread.Start();
				string value2 = "";
				if (MyProject.Forms.FrmMain.profileAGPS.TryGetValue(MyProject.Forms.FrmMain.runningApp.ToLower(), out value2))
				{
					if (Operators.CompareString(value2, "0", TextCompare: false) == 0)
					{
						Thread thread2 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_agps("false");
						});
						thread2.Start();
					}
					else
					{
						Thread thread3 = new Thread([SpecialName] () =>
						{
							RunCommand.Run_debug_tool_agps("true");
						});
						thread3.Start();
					}
				}
				if (MySettingsProperty.Settings.VoiceConfirmProfile)
				{
					Thread thread4 = new Thread([SpecialName] () =>
					{
						MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
					});
					thread4.Start();
				}
				if (GetConfig.SetRiftDefault)
				{
					if (MySettingsProperty.Settings.SetRiftAudioDefault == 2)
					{
						Thread thread5 = new Thread([SpecialName] () =>
						{
							AudioSwitcher.SetDefaultAudioDeviceOnStart(PlayLaunchDetected: false);
						});
						thread5.Start();
					}
					if (MySettingsProperty.Settings.SetRiftMicDefault == 2)
					{
						Thread thread6 = new Thread([SpecialName] () =>
						{
							AudioSwitcher.SetDefaultMicDeviceOnStart();
						});
						thread6.Start();
					}
				}
				MyProject.Forms.FrmMain.runningApp = appName;
				string displayName = OTTDB.GetDisplayName(appName);
				MyProject.Forms.FrmMain.runningapp_displayname = OTTDB.GetDisplayName(appName);
				Log.WriteToLog("Manual game launch detected: " + displayName + " (" + appName + ")");
				Log.WriteToLog(displayName + ": Super Sampling @ " + value);
				if (Globals.dbg)
				{
					Log.WriteToLog(MyProject.Forms.FrmMain.runningApp + ": Super Sampling @ " + value);
				}
				FrmMain.fmain.AddToListboxAndScroll("Game launch detected: " + displayName);
				string value3 = "";
				if (MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value3))
				{
					System.Timers.Timer timer = new System.Timers.Timer();
					timer.AutoReset = false;
					timer.Interval = Conversions.ToInteger(value3) * 1000;
					timer.Elapsed += MyProject.Forms.FrmMain.ApplyCpuPrioTick;
					timer.Start();
					Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + value3 + " seconds");
					FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + value3 + " seconds");
				}
				string value4 = "";
				if (MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value4))
				{
					System.Timers.Timer timer2 = new System.Timers.Timer();
					timer2.AutoReset = false;
					timer2.Interval = Conversions.ToInteger(value4) * 1000;
					timer2.Elapsed += MyProject.Forms.FrmMain.ApplyAswTick;
					timer2.Start();
					Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + value4 + " seconds");
					FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + value4 + " seconds");
				}
				string value5 = "";
				if (MyProject.Forms.FrmMain.profileMirror.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value5) && Operators.CompareString(value5, "1", TextCompare: false) == 0)
				{
					System.Timers.Timer timer3 = new System.Timers.Timer();
					timer3.AutoReset = false;
					timer3.Interval = 2000.0;
					timer3.Elapsed += FrmMain.fmain.ApplyMirrorTick;
					timer3.Start();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("ApplyProfile(): " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	private List<string> GetAppInfo(string jFile, string customParms)
	{
		List<string> result = default(List<string>);
		try
		{
			List<string> list = new List<string>();
			string item = "";
			string text = "";
			string json = File.ReadAllText(jFile);
			JObject jObject = (JObject)JToken.Parse(json);
			string text2 = (string)jObject.SelectToken("canonicalName");
			string text3 = ((string)jObject.SelectToken("launchFile")).Replace("/", "\\").Replace("\\\\", "\\");
			text = ((Operators.CompareString(customParms, "", TextCompare: false) != 0) ? customParms : ((string)jObject.SelectToken("launchParameters")));
			if (ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
			{
				item = text3.Replace("/", "\\").Replace("\\\\", "\\");
			}
			if (!ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
			{
				string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
				string[] array2 = array;
				foreach (string text4 in array2)
				{
					if (File.Exists(text4 + "\\Software\\" + text2 + "\\" + text3))
					{
						item = text4 + "\\Software\\" + text2 + "\\" + text3;
						break;
					}
				}
			}
			list.Add(item);
			list.Add(text);
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetAppInfo(): " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void ListView1_MouseMove(object sender, MouseEventArgs e)
	{
		checked
		{
			try
			{
				if (ShowRemoved3rdPartyAppsToolStripMenuItem.Checked || ShowToolStripMenuItem.Checked || ListView1.Items.Count == 0)
				{
					return;
				}
				ListViewItem itemAt = ListView1.GetItemAt(e.X, e.Y);
				foreach (ListViewItem item in ListView1.Items)
				{
					if (item != itemAt)
					{
						item.Selected = false;
					}
				}
				if (itemAt != null)
				{
					itemAt.Selected = true;
					itemAt.EnsureVisible();
					ListViewHitTestInfo listViewHitTestInfo = ListView1.HitTest(e.X, e.Y);
					PicturePlay.Left = ListView1.Left + listViewHitTestInfo.Item.Bounds.Left + 21;
					PicturePlay.Top = ListView1.Top + listViewHitTestInfo.Item.Bounds.Top + 2;
					string[] array = Strings.Split(Conversions.ToString(itemAt.Tag), ",");
					PicturePlay.Image = CreateOverlay(imageListLarge.Images[array[array.Count() - 1]]);
					PicturePlay.Visible = true;
					PicturePlay.Select();
				}
				else
				{
					PicturePlay.Visible = false;
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

	private Image CreateOverlay(Image im)
	{
		int num = ImgListOverlay.Images[0].Width;
		int num2 = ImgListOverlay.Images[0].Height;
		Bitmap bitmap = new Bitmap(num, num2);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.DrawImage(ImgListOverlay.Images[0], 0, 0, num, num2);
		}
		bitmap.MakeTransparent(Color.Red);
		int num3 = im.Width;
		int num4 = im.Height;
		Bitmap bitmap2 = new Bitmap(num3, num4);
		int num5 = checked(num3 - num) / 2;
		int num6 = checked(num4 - num2) / 2;
		using (Graphics graphics2 = Graphics.FromImage(bitmap2))
		{
			graphics2.DrawImage(im, 0, 0, num3, num4);
			graphics2.DrawImage(bitmap, num5, num6, num, num2);
		}
		PicturePlay.Image = bitmap2;
		bitmap.Dispose();
		return bitmap2;
	}

	private void ToolStripMenuItem8_Click(object sender, EventArgs e)
	{
		string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
		checked
		{
			if (File.Exists(array[2]))
			{
				string text = "";
				string text2 = "";
				List<string> list = new List<string>();
				list = GetAppInfo(array[2], "");
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					text = list[0];
					text2 = list[1];
				}
				MyProject.Forms.frmLaunchOptions.TextBox1.Text = text2;
				MyProject.Forms.frmLaunchOptions.ShowDialog();
				if (!MyProject.Forms.frmLaunchOptions.optionsCanceled && ((Operators.CompareString(text, "", TextCompare: false) != 0) & File.Exists(text)))
				{
					MyProject.Forms.FrmMain.ManualStart = true;
					Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text);
					Log.WriteToLog(" -> " + text.TrimStart().TrimEnd() + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text.TrimStart().TrimEnd());
					ApplyProfile(text.TrimStart().TrimEnd());
					Process.Start(text, MyProject.Forms.frmLaunchOptions.TextBox1.Text);
					MyProject.Forms.frmLaunchOptions.Close();
				}
			}
		}
	}

	private void PicturePlay_MouseUp(object sender, MouseEventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0 && e.Button == MouseButtons.Left)
		{
			LaunchApp();
		}
	}

	private void ContextMenuStrip2_Opening(object sender, CancelEventArgs e)
	{
		if (ListView1.SelectedItems.Count != 0 && ListView1.SelectedItems.Count > 0)
		{
			if (Conversions.ToBoolean(NewLateBinding.LateGet(ListView1.SelectedItems[0].Tag, null, "contains", new object[1] { "hidden" }, null, null, null)))
			{
				ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = true;
			}
			else
			{
				ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = false;
			}
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		SearchForApp();
	}

	private void TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			SearchForApp();
		}
	}

	private void SearchForApp()
	{
		if (DotNetBarTabcontrol1.SelectedIndex == 0)
		{
			ListViewItem listViewItem = ListView1.FindItemWithText(TextBox1.Text);
			if (listViewItem != null)
			{
				listViewItem.Selected = true;
				ListView1.Focus();
				ListView1.SelectedItems[0].EnsureVisible();
			}
		}
	}

	private void ToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
		string text = "";
		frmCreateEditProfile frmCreateEditProfile2 = new frmCreateEditProfile();
		if (ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
		{
			string json = File.ReadAllText(array[2]);
			JObject jObject = JObject.Parse(json);
			text = jObject.SelectToken("launchFile").ToString();
		}
		else
		{
			text = array[3];
		}
		frmCreateEditProfile2.TextDisplayName.Text = ListView1.SelectedItems[0].Text;
		frmCreateEditProfile2.ComboSS.Text = "0";
		frmCreateEditProfile2.ComboASW.Text = "Auto";
		frmCreateEditProfile2.ComboCPU.Text = "Normal";
		frmCreateEditProfile2.ComboMethod.Text = "WMI";
		frmCreateEditProfile2.pLaunchfile = array[0].Replace("\\\\", "\\").Replace("/", "\\");
		frmCreateEditProfile2.pPath = text.Replace("\\\\", "\\").Replace("/", "\\");
		frmCreateEditProfile2.TextBoxPath.Text = text.Replace("\\\\", "\\").Replace("/", "\\");
		frmCreateEditProfile2.NumericUpDown1.Value = 5m;
		frmCreateEditProfile2.NumericUpDown2.Value = 5m;
		frmCreateEditProfile2.ComboMirror.SelectedIndex = 0;
		frmCreateEditProfile2.ComboAGPS.SelectedIndex = 1;
		frmCreateEditProfile2.Button1.Enabled = true;
		frmCreateEditProfile2.ShowDialog(this);
		if (!frmCreateEditProfile2.CreateCancel)
		{
			PicturePlay.Visible = false;
			PopulateList();
		}
	}

	private void ToolStripMenuItem9_Click(object sender, EventArgs e)
	{
		try
		{
			if (ListView1.SelectedItems.Count != 0)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Editing Profile: '" + ListView1.SelectedItems[0].Text + "'");
				}
				if (Globals.dbg)
				{
					Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(" Tag: ", ListView1.SelectedItems[0].Tag)));
				}
				string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
				if (Globals.dbg)
				{
					Log.WriteToLog(" Reading " + array[2].Replace("\\\\", "\\").Replace("/", "\\"));
				}
				string json = File.ReadAllText(array[2].Replace("\\\\", "\\").Replace("/", "\\"));
				JObject jObject = JObject.Parse(json);
				string value = jObject.SelectToken("launchFile").ToString();
				if (Globals.dbg)
				{
					Log.WriteToLog(" Json Launchfile: " + value);
				}
				string text = array[3];
				if (Operators.CompareString(text, "3rdParty", TextCompare: false) == 0)
				{
					text = value.Replace("\\\\", "\\").Replace("/", "\\");
				}
				if (Globals.dbg)
				{
					Log.WriteToLog(" Path: " + text);
				}
				if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(text, out value))
				{
					value = text;
				}
				value = value.Replace("\\\\", "\\").Replace("/", "\\");
				if (Globals.dbg)
				{
					Log.WriteToLog(" Launchfile: " + value);
				}
				frmCreateEditProfile frmCreateEditProfile2 = new frmCreateEditProfile();
				string value2 = "";
				string value3 = "";
				string value4 = "";
				string value5 = "";
				string value6 = "";
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				if (ManualStartProfiles.TryGetValue(value.ToLower(), out value4))
				{
					frmCreateEditProfile2.ComboSS.Text = value4;
				}
				if (MyProject.Forms.FrmMain.profileASWList.TryGetValue(value, out value3))
				{
					frmCreateEditProfile2.ComboASW.Text = value3;
				}
				if (MyProject.Forms.FrmMain.profileDisplayNames.TryGetValue(value, out value2))
				{
					frmCreateEditProfile2.TextDisplayName.Text = value2;
				}
				if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(value, out value6))
				{
					frmCreateEditProfile2.ComboCPU.Text = value6;
				}
				if (MyProject.Forms.FrmMain.profileTimerList.TryGetValue(value, out value5))
				{
					frmCreateEditProfile2.ComboMethod.Text = "Timer";
				}
				else
				{
					frmCreateEditProfile2.ComboMethod.Text = "WMI";
				}
				Dictionary<string, string> profileAswDelay = MyProject.Forms.FrmMain.profileAswDelay;
				string key = value;
				string value7 = Conversions.ToString(num);
				bool num5 = profileAswDelay.TryGetValue(key, out value7);
				num = Conversions.ToInteger(value7);
				if (num5)
				{
					frmCreateEditProfile2.NumericUpDown1.Value = new decimal(num);
				}
				Dictionary<string, string> profileCpuDelay = MyProject.Forms.FrmMain.profileCpuDelay;
				string key2 = value;
				value7 = Conversions.ToString(num2);
				bool num6 = profileCpuDelay.TryGetValue(key2, out value7);
				num2 = Conversions.ToInteger(value7);
				if (num6)
				{
					frmCreateEditProfile2.NumericUpDown2.Value = new decimal(num2);
				}
				Dictionary<string, string> profileMirror = MyProject.Forms.FrmMain.profileMirror;
				string key3 = value.ToLower();
				value7 = Conversions.ToString(num3);
				if (profileMirror.TryGetValue(key3, out value7))
				{
					frmCreateEditProfile2.ComboMirror.SelectedIndex = num3;
				}
				Dictionary<string, string> profileAGPS = MyProject.Forms.FrmMain.profileAGPS;
				string key4 = value.ToLower();
				value7 = Conversions.ToString(num4);
				if (profileAGPS.TryGetValue(key4, out value7))
				{
					frmCreateEditProfile2.ComboAGPS.SelectedIndex = num4;
				}
				frmCreateEditProfile2.pLaunchfile = Path.GetFileName(value);
				frmCreateEditProfile2.pPath = value;
				frmCreateEditProfile2.TextBoxPath.Text = value;
				frmCreateEditProfile2.Button1.Enabled = true;
				frmCreateEditProfile2.ShowDialog(this);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Could not edit profile: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
	{
		ContextMenuStrip1.Close();
		ListView1.Focus();
	}

	private void Library_ResizeBegin(object sender, EventArgs e)
	{
		PicturePlay.Visible = false;
	}

	private void ShowAppInLibraryAndProfilesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		OTTDB.UnHideApp(ListView1.SelectedItems[0].Text);
		ShowToolStripMenuItem.Checked = false;
		PopulateList();
	}

	public void ImagelistAddItem(string name, Image img)
	{
		try
		{
			icons.Images.Add(name, img);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private int GetCount(SQLiteConnection sqConnection, string Table)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand("SELECT COUNT(*) From " + Table, sqConnection);
		return Convert.ToInt16(RuntimeHelpers.GetObjectValue(sQLiteCommand.ExecuteScalar()));
	}

	public void ClearListview(ListView lv)
	{
		if (lv.InvokeRequired)
		{
			ClearListview_delegate method = ClearListview;
			lv.BeginInvoke(method, lv);
		}
		else
		{
			ListView listView = lv;
			listView.Items.Clear();
			listView = null;
		}
	}

	private void AddSteamVRToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(MyProject.Forms.FrmMain.steamvr, "", TextCompare: false) == 0)
		{
			Interaction.MsgBox("Could not locate Steam VR path", MsgBoxStyle.Critical, "Error");
			return;
		}
		string text = MyProject.Forms.FrmMain.steamvr.Replace(" ", "").Replace("\\", "_").Replace(":", "") + "bin_win32_assets";
		string text2 = MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Software\\StoreAssets\\" + text;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (!Directory.Exists(text2))
		{
			Log.WriteToLog("Creating " + text2);
			Directory.CreateDirectory(text2);
		}
		try
		{
			string[] files = Directory.GetFiles(steam_assets);
			foreach (string text3 in files)
			{
				if ((Operators.CompareString(Path.GetExtension(text3), ".bat", TextCompare: false) != 0) & (Operators.CompareString(Path.GetExtension(text3), ".exe", TextCompare: false) != 0))
				{
					Log.WriteToLog("Copying " + Path.GetFileName(text3) + " -> " + text2);
					File.Copy(text3, text2 + "\\" + Path.GetFileName(text3), overwrite: true);
					Log.WriteToLog("Generating hash for " + Path.GetFileName(text3));
					string value = Conversions.ToString(GenerateSHA256Hash(text3));
					dictionary.Add(Path.GetFileName(text3), value);
				}
				if (Operators.CompareString(Path.GetExtension(text3), ".bat", TextCompare: false) == 0)
				{
					File.Copy(text3, MyProject.Forms.FrmMain.steamvr + Path.GetFileName(text3), overwrite: true);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Exception occurred when copying files: " + ex2.Message);
			Interaction.MsgBox("Exception occurred when copying files: " + ex2.Message);
			ProjectData.ClearProjectError();
			return;
		}
		CreateManifest(text.Replace("_assets", ""), "SteamVR", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
		CreateAssetManifest(text, "#060404", dictionary, "", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
		PopulateList();
		if (Interaction.MsgBox("You need to restart the Oculus Service for SteamVR to be visible in Oculus Home. Restart it now?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, "Restart Required") == MsgBoxResult.Yes)
		{
			MyProject.Forms.FrmMain.StopOVR();
			MyProject.Forms.FrmMain.StartOVR();
		}
	}

	private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (ShowToolStripMenuItem.Checked)
		{
			PicturePlay.Visible = false;
			isReading = true;
			ShowRemoved3rdPartyAppsToolStripMenuItem.Checked = false;
			isReading = false;
			ListView1.Items.Clear();
			imageListLarge.Images.Clear();
			imageListLarge.ImageSize = new Size(250, 90);
			ListView1.LargeImageList = imageListLarge;
			ListView1.View = View.LargeIcon;
			{
				foreach (object item in (IEnumerable)OTTDB.GetHiddenApps())
				{
					string text = Conversions.ToString(item);
					imageListLarge.Images.Add(text, Resources.removed_app);
					ListViewItem listViewItem = new ListViewItem(text, text);
					listViewItem.Tag = text + ",hidden";
					ListView1.Items.Add(listViewItem);
				}
				return;
			}
		}
		RefreshLibrary();
	}

	private void AscendingToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (AscendingToolStripMenuItem.Checked)
		{
			DescendingToolStripMenuItem.Checked = false;
			if (DotNetBarTabcontrol1.SelectedIndex == 0)
			{
				ListView1.Sorting = SortOrder.Ascending;
			}
			else
			{
				ListView1.Sorting = SortOrder.None;
			}
		}
	}

	private void DescendingToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (DescendingToolStripMenuItem.Checked)
		{
			AscendingToolStripMenuItem.Checked = false;
			if (DotNetBarTabcontrol1.SelectedIndex == 0)
			{
				ListView1.Sorting = SortOrder.Descending;
			}
			else
			{
				ListView1.Sorting = SortOrder.None;
			}
		}
	}

	private void RefreshLibraryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		RefreshLibrary();
	}

	private void RefreshLibrary()
	{
		Log.WriteToLog("Refreshing Library");
		try
		{
			if (cnn.State == ConnectionState.Open)
			{
				cnn.Close();
			}
			if (File.Exists(Application.StartupPath + "\\data.sqlite"))
			{
				File.Delete(Application.StartupPath + "\\data.sqlite");
				if (Globals.dbg)
				{
					Log.WriteToLog("Database copy deleted");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Failed to delete database copy: " + ex2.Message);
			Interaction.MsgBox("Failed to delete database copy: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll("Failed to delete database copy: " + ex2.Message);
			MyProject.Forms.FrmMain.hasError = true;
			ProjectData.ClearProjectError();
			return;
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
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("Failed to create database copy: " + ex4.Message);
				Interaction.MsgBox("Failed to create database copy: " + ex4.Message, MsgBoxStyle.Critical, "Error copying database");
				FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + ex4.Message);
				MyProject.Forms.FrmMain.hasError = true;
				ProjectData.ClearProjectError();
				return;
			}
		}
		IconGameList.Clear();
		libraryLoaded = false;
		LoadLibrary();
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(e.Link.LinkData.ToString());
	}

	private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(e.Link.LinkData.ToString());
	}

	private void ShowIgnoredAppsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MyProject.Forms.FrmIgnoredApps.ShowDialog(this);
	}

	private void ToolStripMenuItem6_Click(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
			string text = array[2];
			string text2 = ListView1.SelectedItems[0].Text;
			OTTDB.AddIgnoreApp(text);
			OTTDB.RemoveIncludedApp(text);
			MyProject.Forms.FrmMain.ignoredApps = (List<string>)OTTDB.GetIgnoredApps();
			MyProject.Forms.FrmMain.includedApps = (List<string>)OTTDB.GetIncludedApps();
			MyProject.Forms.FrmMain.ignoredApps.Add(text);
			PopulateList();
			Log.WriteToLog("'" + text2 + "' is now being ignored");
			MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + text2 + "' is now being ignored");
		}
	}

	private void RemoveProfileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DeleteProfile();
	}

	private void DeleteProfile()
	{
		if (ListView1.SelectedItems.Count <= 0)
		{
			return;
		}
		ListViewItem listViewItem = ListView1.SelectedItems[0];
		string[] array = Strings.Split(Conversions.ToString(listViewItem.Tag), ",");
		if (Globals.dbg)
		{
			Log.WriteToLog(" Reading " + array[2].Replace("\\\\", "\\").Replace("/", "\\"));
		}
		string json = File.ReadAllText(array[2].Replace("\\\\", "\\").Replace("/", "\\"));
		JObject jObject = JObject.Parse(json);
		string value = jObject.SelectToken("launchFile").ToString();
		if (Globals.dbg)
		{
			Log.WriteToLog(" Json Launchfile: " + value);
		}
		string text = array[3];
		if (Operators.CompareString(text, "3rdParty", TextCompare: false) == 0)
		{
			text = value.Replace("\\\\", "\\").Replace("/", "\\");
		}
		if (Globals.dbg)
		{
			Log.WriteToLog(" Path: " + text);
		}
		if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(text, out value))
		{
			value = text;
		}
		value = value.Replace("\\\\", "\\").Replace("/", "\\");
		if (Interaction.MsgBox("Remove profile for '" + listViewItem.Text + "'?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm") == MsgBoxResult.Yes)
		{
			OTTDB.RemoveProfile(value);
			OTTDB.GetProfiles();
			if (OTTDB.numWMI > 0)
			{
				MyProject.Forms.FrmMain.CreateWatcher();
			}
			if (OTTDB.numTimer > 0)
			{
				MyProject.Forms.FrmMain.pTimer.Start();
			}
		}
		MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
		PopulateList();
	}
}
