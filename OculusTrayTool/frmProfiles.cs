using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;
using OculusTrayTool.MyNameSpace;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmProfiles : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ListView1")]
	private ListView _ListView1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckVoiceConfirm")]
	private CheckBox _CheckVoiceConfirm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ContextMenuStrip1")]
	private ContextMenuStrip _ContextMenuStrip1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem3")]
	private ToolStripMenuItem _ToolStripMenuItem3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem4")]
	private ToolStripMenuItem _ToolStripMenuItem4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem5")]
	private ToolStripMenuItem _ToolStripMenuItem5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LaunchAppToolStripMenuItem")]
	private ToolStripMenuItem _LaunchAppToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LaunchAppWithOptionsToolStripMenuItem")]
	private ToolStripMenuItem _LaunchAppWithOptionsToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem6")]
	private ToolStripMenuItem _ToolStripMenuItem6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboResolution")]
	private ComboBox _ComboResolution;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	private Resizer rs;

	private int sortColumn;

	private string ProfileToFind;

	public int selectedItem;

	public Dictionary<string, string> GameList;

	private CheckBox cck;

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
			EventHandler value2 = ListView1_DoubleClick;
			MouseEventHandler value3 = ListView1_MouseMove;
			DrawListViewColumnHeaderEventHandler value4 = ListView1_DrawColumnHeader;
			DrawListViewItemEventHandler value5 = ListView1_DrawItem;
			DrawListViewSubItemEventHandler value6 = ListView1_DrawSubItem;
			EventHandler value7 = ListView1_MouseHover;
			EventHandler value8 = ListView1_Click;
			ListView listView = _ListView1;
			if (listView != null)
			{
				listView.DoubleClick -= value2;
				listView.MouseMove -= value3;
				listView.DrawColumnHeader -= value4;
				listView.DrawItem -= value5;
				listView.DrawSubItem -= value6;
				listView.MouseHover -= value7;
				listView.Click -= value8;
			}
			_ListView1 = value;
			listView = _ListView1;
			if (listView != null)
			{
				listView.DoubleClick += value2;
				listView.MouseMove += value3;
				listView.DrawColumnHeader += value4;
				listView.DrawItem += value5;
				listView.DrawSubItem += value6;
				listView.MouseHover += value7;
				listView.Click += value8;
			}
		}
	}

	[field: AccessedThroughProperty("ColumnHeader1")]
	internal virtual ColumnHeader ColumnHeader1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader2")]
	internal virtual ColumnHeader ColumnHeader2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader3")]
	internal virtual ColumnHeader ColumnHeader3
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

	[field: AccessedThroughProperty("ToolTip1")]
	internal virtual ToolTip ToolTip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader4")]
	internal virtual ColumnHeader ColumnHeader4
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckVoiceConfirm
	{
		[CompilerGenerated]
		get
		{
			return _CheckVoiceConfirm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckVoiceConfirm_CheckedChanged;
			CheckBox checkVoiceConfirm = _CheckVoiceConfirm;
			if (checkVoiceConfirm != null)
			{
				checkVoiceConfirm.CheckedChanged -= value2;
			}
			_CheckVoiceConfirm = value;
			checkVoiceConfirm = _CheckVoiceConfirm;
			if (checkVoiceConfirm != null)
			{
				checkVoiceConfirm.CheckedChanged += value2;
			}
		}
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

	[field: AccessedThroughProperty("ToolStripMenuItem1")]
	internal virtual ToolStripMenuItem ToolStripMenuItem1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripMenuItem2")]
	internal virtual ToolStripMenuItem ToolStripMenuItem2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	internal virtual ToolStripMenuItem LaunchAppToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _LaunchAppToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LaunchAppToolStripMenuItem_Click;
			ToolStripMenuItem launchAppToolStripMenuItem = _LaunchAppToolStripMenuItem;
			if (launchAppToolStripMenuItem != null)
			{
				launchAppToolStripMenuItem.Click -= value2;
			}
			_LaunchAppToolStripMenuItem = value;
			launchAppToolStripMenuItem = _LaunchAppToolStripMenuItem;
			if (launchAppToolStripMenuItem != null)
			{
				launchAppToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem LaunchAppWithOptionsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _LaunchAppWithOptionsToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LaunchAppWithOptionsToolStripMenuItem_Click;
			ToolStripMenuItem launchAppWithOptionsToolStripMenuItem = _LaunchAppWithOptionsToolStripMenuItem;
			if (launchAppWithOptionsToolStripMenuItem != null)
			{
				launchAppWithOptionsToolStripMenuItem.Click -= value2;
			}
			_LaunchAppWithOptionsToolStripMenuItem = value;
			launchAppWithOptionsToolStripMenuItem = _LaunchAppWithOptionsToolStripMenuItem;
			if (launchAppWithOptionsToolStripMenuItem != null)
			{
				launchAppWithOptionsToolStripMenuItem.Click += value2;
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

	[field: AccessedThroughProperty("RemoveAllSelectedProfilesToolStripMenuItem")]
	internal virtual ToolStripMenuItem RemoveAllSelectedProfilesToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboResolution
	{
		[CompilerGenerated]
		get
		{
			return _ComboResolution;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboResolution_SelectedIndexChanged;
			ComboBox comboResolution = _ComboResolution;
			if (comboResolution != null)
			{
				comboResolution.SelectedIndexChanged -= value2;
			}
			_ComboResolution = value;
			comboResolution = _ComboResolution;
			if (comboResolution != null)
			{
				comboResolution.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label11")]
	internal virtual Label Label11
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

	[field: AccessedThroughProperty("Label9")]
	internal virtual Label Label9
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

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
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

	[field: AccessedThroughProperty("Label13")]
	internal virtual Label Label13
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

	[field: AccessedThroughProperty("Label15")]
	internal virtual Label Label15
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label14")]
	internal virtual Label Label14
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

	[field: AccessedThroughProperty("Label29")]
	internal virtual Label Label29
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label16")]
	internal virtual Label Label16
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label17")]
	internal virtual Label Label17
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

	[field: AccessedThroughProperty("Label19")]
	internal virtual Label Label19
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label20")]
	internal virtual Label Label20
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label22")]
	internal virtual Label Label22
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

	[field: AccessedThroughProperty("Label30")]
	internal virtual Label Label30
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	[field: AccessedThroughProperty("Label31")]
	internal virtual Label Label31
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label32")]
	internal virtual Label Label32
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual TextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader5")]
	internal virtual ColumnHeader ColumnHeader5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmProfiles()
	{
		base.FormClosing += scan_FormClosing;
		base.Load += scan_Load;
		rs = new Resizer();
		sortColumn = -1;
		GameList = new Dictionary<string, string>();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmProfiles));
		this.ListView1 = new System.Windows.Forms.ListView();
		this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.LaunchAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.LaunchAppWithOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.RemoveAllSelectedProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.Button2 = new System.Windows.Forms.Button();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.CheckVoiceConfirm = new System.Windows.Forms.CheckBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.ComboResolution = new System.Windows.Forms.ComboBox();
		this.Button3 = new System.Windows.Forms.Button();
		this.DbLayoutPanel1 = new OculusTrayTool.MyNameSpace.DBLayoutPanel(this.components);
		this.Label3 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label16 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.Label18 = new System.Windows.Forms.Label();
		this.Label19 = new System.Windows.Forms.Label();
		this.Label20 = new System.Windows.Forms.Label();
		this.Label22 = new System.Windows.Forms.Label();
		this.Label23 = new System.Windows.Forms.Label();
		this.Label24 = new System.Windows.Forms.Label();
		this.Label25 = new System.Windows.Forms.Label();
		this.Label26 = new System.Windows.Forms.Label();
		this.Label27 = new System.Windows.Forms.Label();
		this.Label28 = new System.Windows.Forms.Label();
		this.Label30 = new System.Windows.Forms.Label();
		this.Label29 = new System.Windows.Forms.Label();
		this.Label15 = new System.Windows.Forms.Label();
		this.Label14 = new System.Windows.Forms.Label();
		this.Label13 = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label10 = new System.Windows.Forms.Label();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label31 = new System.Windows.Forms.Label();
		this.Label32 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.ContextMenuStrip1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.DbLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.ListView1.CheckBoxes = true;
		this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[5] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader3, this.ColumnHeader4, this.ColumnHeader5 });
		this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
		this.ListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ListView1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		this.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.ListView1.HideSelection = false;
		this.ListView1.Location = new System.Drawing.Point(13, 128);
		this.ListView1.MultiSelect = false;
		this.ListView1.Name = "ListView1";
		this.ListView1.OwnerDraw = true;
		this.ListView1.Size = new System.Drawing.Size(507, 379);
		this.ListView1.TabIndex = 1;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ColumnHeader1.Text = "   Game Name";
		this.ColumnHeader1.Width = 116;
		this.ColumnHeader2.Text = "Super Sampling";
		this.ColumnHeader2.Width = 164;
		this.ColumnHeader3.Text = "ASW Mode";
		this.ColumnHeader3.Width = 110;
		this.ColumnHeader4.Text = "CPU Priority";
		this.ColumnHeader4.Width = 113;
		this.ColumnHeader5.Text = "Enabled";
		this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
		{
			this.ToolStripMenuItem1, this.ToolStripMenuItem2, this.ToolStripSeparator1, this.LaunchAppToolStripMenuItem, this.LaunchAppWithOptionsToolStripMenuItem, this.ToolStripSeparator2, this.ToolStripMenuItem3, this.ToolStripMenuItem4, this.ToolStripMenuItem6, this.ToolStripSeparator3,
			this.ToolStripMenuItem5, this.RemoveAllSelectedProfilesToolStripMenuItem
		});
		this.ContextMenuStrip1.Name = "ContextMenuStrip1";
		this.ContextMenuStrip1.Size = new System.Drawing.Size(242, 220);
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem1.Text = "Hide App in Profiles";
		this.ToolStripMenuItem1.Visible = false;
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		this.ToolStripMenuItem2.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem2.Text = "Hide App in Profiles and Library";
		this.ToolStripMenuItem2.Visible = false;
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new System.Drawing.Size(238, 6);
		this.LaunchAppToolStripMenuItem.Image = OculusTrayTool.My.Resources.Resources.Service_Start;
		this.LaunchAppToolStripMenuItem.Name = "LaunchAppToolStripMenuItem";
		this.LaunchAppToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
		this.LaunchAppToolStripMenuItem.Text = "Launch App";
		this.LaunchAppWithOptionsToolStripMenuItem.Name = "LaunchAppWithOptionsToolStripMenuItem";
		this.LaunchAppWithOptionsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
		this.LaunchAppWithOptionsToolStripMenuItem.Text = "Launch App with options..";
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new System.Drawing.Size(238, 6);
		this.ToolStripMenuItem3.Image = OculusTrayTool.My.Resources.Resources.Icon_Edit;
		this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		this.ToolStripMenuItem3.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem3.Text = "Create New Profile...";
		this.ToolStripMenuItem4.Image = OculusTrayTool.My.Resources.Resources.Icon_Edit;
		this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		this.ToolStripMenuItem4.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem4.Text = "Edit highlighted profile...";
		this.ToolStripMenuItem6.Image = OculusTrayTool.My.Resources.Resources.Icon_Edit;
		this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
		this.ToolStripMenuItem6.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem6.Text = "Edit all selected...";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new System.Drawing.Size(238, 6);
		this.ToolStripMenuItem5.Image = OculusTrayTool.My.Resources.Resources.Icon_Delete;
		this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
		this.ToolStripMenuItem5.Size = new System.Drawing.Size(241, 22);
		this.ToolStripMenuItem5.Text = "Remove highlighted Profile";
		this.RemoveAllSelectedProfilesToolStripMenuItem.Image = OculusTrayTool.My.Resources.Resources.Icon_Delete;
		this.RemoveAllSelectedProfilesToolStripMenuItem.Name = "RemoveAllSelectedProfilesToolStripMenuItem";
		this.RemoveAllSelectedProfilesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
		this.RemoveAllSelectedProfilesToolStripMenuItem.Text = "Remove all selected Profiles";
		this.RemoveAllSelectedProfilesToolStripMenuItem.Visible = false;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(856, 542);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(62, 25);
		this.Button2.TabIndex = 3;
		this.Button2.Text = "Close";
		this.Button2.UseVisualStyleBackColor = true;
		this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox2.Controls.Add(this.Label2);
		this.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox2.Location = new System.Drawing.Point(12, 12);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(905, 79);
		this.GroupBox2.TabIndex = 10;
		this.GroupBox2.TabStop = false;
		this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.Location = new System.Drawing.Point(12, 13);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(887, 60);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Double-click to edit, right-click for options.\r\n\r\nTip: You can select multiple profiles and use \"Edit all selected\" to change settings for all of them at once.\r\n";
		this.CheckVoiceConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.CheckVoiceConfirm.AutoSize = true;
		this.CheckVoiceConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckVoiceConfirm.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckVoiceConfirm.Location = new System.Drawing.Point(12, 513);
		this.CheckVoiceConfirm.Name = "CheckVoiceConfirm";
		this.CheckVoiceConfirm.Size = new System.Drawing.Size(254, 19);
		this.CheckVoiceConfirm.TabIndex = 15;
		this.CheckVoiceConfirm.Text = "Audio confirmation when profile is applied";
		this.CheckVoiceConfirm.UseVisualStyleBackColor = true;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(12, 97);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(92, 25);
		this.Button1.TabIndex = 25;
		this.Button1.Text = "Create profile";
		this.Button1.UseVisualStyleBackColor = true;
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label1.Location = new System.Drawing.Point(10, 542);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(112, 15);
		this.Label1.TabIndex = 26;
		this.Label1.Text = "Desktop resolution:";
		this.ComboResolution.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.ComboResolution.FormattingEnabled = true;
		this.ComboResolution.Location = new System.Drawing.Point(125, 541);
		this.ComboResolution.Name = "ComboResolution";
		this.ComboResolution.Size = new System.Drawing.Size(104, 21);
		this.ComboResolution.TabIndex = 27;
		this.Button3.Enabled = false;
		this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button3.Location = new System.Drawing.Point(110, 97);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(71, 25);
		this.Button3.TabIndex = 29;
		this.Button3.Text = "Edit profile";
		this.Button3.UseVisualStyleBackColor = true;
		this.DbLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.DbLayoutPanel1.ColumnCount = 2;
		this.DbLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.14583f));
		this.DbLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.85417f));
		this.DbLayoutPanel1.Controls.Add(this.Label3, 0, 0);
		this.DbLayoutPanel1.Controls.Add(this.Label4, 0, 1);
		this.DbLayoutPanel1.Controls.Add(this.Label5, 0, 2);
		this.DbLayoutPanel1.Controls.Add(this.Label16, 1, 0);
		this.DbLayoutPanel1.Controls.Add(this.Label17, 1, 1);
		this.DbLayoutPanel1.Controls.Add(this.Label18, 1, 2);
		this.DbLayoutPanel1.Controls.Add(this.Label19, 1, 3);
		this.DbLayoutPanel1.Controls.Add(this.Label20, 1, 4);
		this.DbLayoutPanel1.Controls.Add(this.Label22, 1, 6);
		this.DbLayoutPanel1.Controls.Add(this.Label23, 1, 7);
		this.DbLayoutPanel1.Controls.Add(this.Label24, 1, 8);
		this.DbLayoutPanel1.Controls.Add(this.Label25, 1, 9);
		this.DbLayoutPanel1.Controls.Add(this.Label26, 1, 10);
		this.DbLayoutPanel1.Controls.Add(this.Label27, 1, 11);
		this.DbLayoutPanel1.Controls.Add(this.Label28, 1, 12);
		this.DbLayoutPanel1.Controls.Add(this.Label30, 1, 13);
		this.DbLayoutPanel1.Controls.Add(this.Label29, 0, 14);
		this.DbLayoutPanel1.Controls.Add(this.Label15, 0, 13);
		this.DbLayoutPanel1.Controls.Add(this.Label14, 0, 12);
		this.DbLayoutPanel1.Controls.Add(this.Label13, 0, 11);
		this.DbLayoutPanel1.Controls.Add(this.Label12, 0, 10);
		this.DbLayoutPanel1.Controls.Add(this.Label11, 0, 9);
		this.DbLayoutPanel1.Controls.Add(this.Label10, 0, 8);
		this.DbLayoutPanel1.Controls.Add(this.Label9, 0, 7);
		this.DbLayoutPanel1.Controls.Add(this.Label8, 0, 6);
		this.DbLayoutPanel1.Controls.Add(this.Label7, 0, 5);
		this.DbLayoutPanel1.Controls.Add(this.Label6, 0, 4);
		this.DbLayoutPanel1.Controls.Add(this.Label31, 1, 14);
		this.DbLayoutPanel1.Controls.Add(this.Label32, 0, 3);
		this.DbLayoutPanel1.Controls.Add(this.TextBox1, 1, 5);
		this.DbLayoutPanel1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.DbLayoutPanel1.Location = new System.Drawing.Point(526, 128);
		this.DbLayoutPanel1.Name = "DbLayoutPanel1";
		this.DbLayoutPanel1.RowCount = 15;
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.845564f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.297919f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.681271f));
		this.DbLayoutPanel1.Size = new System.Drawing.Size(391, 379);
		this.DbLayoutPanel1.TabIndex = 0;
		this.Label3.AutoSize = true;
		this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label3.Location = new System.Drawing.Point(4, 1);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(153, 24);
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Game name";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label4.AutoSize = true;
		this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label4.Location = new System.Drawing.Point(4, 26);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(153, 24);
		this.Label4.TabIndex = 1;
		this.Label4.Text = "Super Sampling";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label5.AutoSize = true;
		this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label5.Location = new System.Drawing.Point(4, 51);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(153, 24);
		this.Label5.TabIndex = 2;
		this.Label5.Text = "ASW Mode";
		this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label16.AutoSize = true;
		this.Label16.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label16.Location = new System.Drawing.Point(164, 1);
		this.Label16.Name = "Label16";
		this.Label16.Size = new System.Drawing.Size(223, 24);
		this.Label16.TabIndex = 13;
		this.Label16.Text = "Label16";
		this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label16.Visible = false;
		this.Label17.AutoSize = true;
		this.Label17.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label17.Location = new System.Drawing.Point(164, 26);
		this.Label17.Name = "Label17";
		this.Label17.Size = new System.Drawing.Size(223, 24);
		this.Label17.TabIndex = 14;
		this.Label17.Text = "Label17";
		this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label17.Visible = false;
		this.Label18.AutoSize = true;
		this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label18.Location = new System.Drawing.Point(164, 51);
		this.Label18.Name = "Label18";
		this.Label18.Size = new System.Drawing.Size(223, 24);
		this.Label18.TabIndex = 15;
		this.Label18.Text = "Label18";
		this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label18.Visible = false;
		this.Label19.AutoSize = true;
		this.Label19.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label19.Location = new System.Drawing.Point(164, 76);
		this.Label19.Name = "Label19";
		this.Label19.Size = new System.Drawing.Size(223, 24);
		this.Label19.TabIndex = 16;
		this.Label19.Text = "Label19";
		this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label19.Visible = false;
		this.Label20.AutoSize = true;
		this.Label20.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label20.Location = new System.Drawing.Point(164, 101);
		this.Label20.Name = "Label20";
		this.Label20.Size = new System.Drawing.Size(223, 24);
		this.Label20.TabIndex = 17;
		this.Label20.Text = "Label20";
		this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label20.Visible = false;
		this.Label22.AutoSize = true;
		this.Label22.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label22.Location = new System.Drawing.Point(164, 151);
		this.Label22.Name = "Label22";
		this.Label22.Size = new System.Drawing.Size(223, 24);
		this.Label22.TabIndex = 19;
		this.Label22.Text = "Label22";
		this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label22.Visible = false;
		this.Label23.AutoSize = true;
		this.Label23.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label23.Location = new System.Drawing.Point(164, 176);
		this.Label23.Name = "Label23";
		this.Label23.Size = new System.Drawing.Size(223, 24);
		this.Label23.TabIndex = 20;
		this.Label23.Text = "Label23";
		this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label23.Visible = false;
		this.Label24.AutoSize = true;
		this.Label24.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label24.Location = new System.Drawing.Point(164, 201);
		this.Label24.Name = "Label24";
		this.Label24.Size = new System.Drawing.Size(223, 24);
		this.Label24.TabIndex = 21;
		this.Label24.Text = "Label24";
		this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label24.Visible = false;
		this.Label25.AutoSize = true;
		this.Label25.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label25.Location = new System.Drawing.Point(164, 226);
		this.Label25.Name = "Label25";
		this.Label25.Size = new System.Drawing.Size(223, 24);
		this.Label25.TabIndex = 22;
		this.Label25.Text = "Label25";
		this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label25.Visible = false;
		this.Label26.AutoSize = true;
		this.Label26.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label26.Location = new System.Drawing.Point(164, 251);
		this.Label26.Name = "Label26";
		this.Label26.Size = new System.Drawing.Size(223, 24);
		this.Label26.TabIndex = 23;
		this.Label26.Text = "Label26";
		this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label26.Visible = false;
		this.Label27.AutoSize = true;
		this.Label27.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label27.Location = new System.Drawing.Point(164, 276);
		this.Label27.Name = "Label27";
		this.Label27.Size = new System.Drawing.Size(223, 24);
		this.Label27.TabIndex = 24;
		this.Label27.Text = "Label27";
		this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label27.Visible = false;
		this.Label28.AutoSize = true;
		this.Label28.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label28.Location = new System.Drawing.Point(164, 301);
		this.Label28.Name = "Label28";
		this.Label28.Size = new System.Drawing.Size(223, 22);
		this.Label28.TabIndex = 25;
		this.Label28.Text = "Label28";
		this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label28.Visible = false;
		this.Label30.AutoSize = true;
		this.Label30.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label30.Location = new System.Drawing.Point(164, 324);
		this.Label30.Name = "Label30";
		this.Label30.Size = new System.Drawing.Size(223, 24);
		this.Label30.TabIndex = 27;
		this.Label30.Text = "Label30";
		this.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label30.Visible = false;
		this.Label29.AutoSize = true;
		this.Label29.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label29.Location = new System.Drawing.Point(4, 349);
		this.Label29.Name = "Label29";
		this.Label29.Size = new System.Drawing.Size(153, 29);
		this.Label29.TabIndex = 26;
		this.Label29.Text = "Enabled";
		this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label15.AutoSize = true;
		this.Label15.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label15.Location = new System.Drawing.Point(4, 324);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(153, 24);
		this.Label15.TabIndex = 12;
		this.Label15.Text = "Offset MipMap Bias";
		this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label14.AutoSize = true;
		this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label14.Location = new System.Drawing.Point(4, 301);
		this.Label14.Name = "Label14";
		this.Label14.Size = new System.Drawing.Size(153, 22);
		this.Label14.TabIndex = 11;
		this.Label14.Text = "Force MipMap Generation";
		this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label13.AutoSize = true;
		this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label13.Location = new System.Drawing.Point(4, 276);
		this.Label13.Name = "Label13";
		this.Label13.Size = new System.Drawing.Size(153, 24);
		this.Label13.TabIndex = 10;
		this.Label13.Text = "FoV";
		this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label12.AutoSize = true;
		this.Label12.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label12.Location = new System.Drawing.Point(4, 251);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(153, 24);
		this.Label12.TabIndex = 9;
		this.Label12.Text = "Comment";
		this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label11.AutoSize = true;
		this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label11.Location = new System.Drawing.Point(4, 226);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(153, 24);
		this.Label11.TabIndex = 8;
		this.Label11.Text = "Adaptive GPU";
		this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label10.AutoSize = true;
		this.Label10.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label10.Location = new System.Drawing.Point(4, 201);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(153, 24);
		this.Label10.TabIndex = 7;
		this.Label10.Text = "Mirror";
		this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label9.AutoSize = true;
		this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label9.Location = new System.Drawing.Point(4, 176);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(153, 24);
		this.Label9.TabIndex = 6;
		this.Label9.Text = "CPU Delay";
		this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label8.AutoSize = true;
		this.Label8.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label8.Location = new System.Drawing.Point(4, 151);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(153, 24);
		this.Label8.TabIndex = 5;
		this.Label8.Text = "ASW Delay";
		this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label7.AutoSize = true;
		this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label7.Location = new System.Drawing.Point(4, 126);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(153, 24);
		this.Label7.TabIndex = 4;
		this.Label7.Text = "Path";
		this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label6.AutoSize = true;
		this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label6.Location = new System.Drawing.Point(4, 101);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(153, 24);
		this.Label6.TabIndex = 3;
		this.Label6.Text = "CPU Priority";
		this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label31.AutoSize = true;
		this.Label31.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label31.Location = new System.Drawing.Point(164, 349);
		this.Label31.Name = "Label31";
		this.Label31.Size = new System.Drawing.Size(223, 29);
		this.Label31.TabIndex = 28;
		this.Label31.Text = "Label31";
		this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label31.Visible = false;
		this.Label32.AutoSize = true;
		this.Label32.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label32.Location = new System.Drawing.Point(4, 76);
		this.Label32.Name = "Label32";
		this.Label32.Size = new System.Drawing.Size(153, 24);
		this.Label32.TabIndex = 29;
		this.Label32.Text = "Detection Method";
		this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.TextBox1.Location = new System.Drawing.Point(164, 129);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(223, 13);
		this.TextBox1.TabIndex = 30;
		this.TextBox1.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(930, 574);
		base.Controls.Add(this.DbLayoutPanel1);
		base.Controls.Add(this.Button3);
		base.Controls.Add(this.ComboResolution);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.CheckVoiceConfirm);
		base.Controls.Add(this.GroupBox2);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.ListView1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size(946, 613);
		base.Name = "frmProfiles";
		base.ShowIcon = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Profiles";
		this.ContextMenuStrip1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.DbLayoutPanel1.ResumeLayout(false);
		this.DbLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void scan_FormClosing(object sender, FormClosingEventArgs e)
	{
		MySettingsProperty.Settings.ScanDialogSize = base.Size;
		MySettingsProperty.Settings.ScanWindowLocation = base.Location;
		MySettingsProperty.Settings.Save();
		if (e.CloseReason == CloseReason.UserClosing)
		{
			Hide();
			e.Cancel = true;
		}
	}

	private void scan_Load(object sender, EventArgs e)
	{
		SetDoubleBuffered(ListView1);
		base.Size = MySettingsProperty.Settings.ScanDialogSize;
		rs.FindAllControls(this);
		rs.ResizeAllControls(this, MyProject.Forms.FrmMain.TrackBar1.Value);
		if (MySettingsProperty.Settings.ScanWindowLocation != default(Point))
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Setting Profiles GUI location to " + MySettingsProperty.Settings.ScanWindowLocation.ToString());
			}
			base.Location = MySettingsProperty.Settings.ScanWindowLocation;
		}
		else
		{
			CenterToScreen();
			MySettingsProperty.Settings.ScanWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
		}
		if ((base.Location.X < 0) | (base.Location.Y < 0))
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Profiles GUI location has negative number, adjusting");
			}
			CenterToScreen();
			MySettingsProperty.Settings.ScanWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
		}
		ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		Show();
		ComboResolution.Focus();
	}

	private bool FindItem(ListView.ListViewItemCollection ItemList, int ColumnIndex, string SearchString)
	{
		foreach (ListViewItem Item in ItemList)
		{
			if (Operators.CompareString(Item.SubItems[ColumnIndex].Text, SearchString, TextCompare: false) == 0)
			{
				return true;
			}
		}
		return false;
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.ProfilesWindowLocation = base.Location;
		MySettingsProperty.Settings.ProfilesWindowSize = base.Size;
		MySettingsProperty.Settings.Save();
		Hide();
	}

	public static void SetDoubleBuffered(Control control)
	{
		typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, control, new object[1] { true });
	}

	private void DeleteProfile()
	{
		if (ListView1.SelectedItems.Count <= 0)
		{
			return;
		}
		foreach (ListViewItem selectedItem in ListView1.SelectedItems)
		{
			if (Interaction.MsgBox("Remove profile for '" + selectedItem.Text.Replace(" *", "") + "'?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm") == MsgBoxResult.Yes)
			{
				OTTDB.RemoveProfile(TextBox1.Text);
				ListView1.Items.Clear();
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
		}
		MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
		if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
		{
			GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
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

	private void CheckVoiceConfirm_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (CheckVoiceConfirm.Checked)
			{
				MySettingsProperty.Settings.VoiceConfirmProfile = true;
			}
			else
			{
				MySettingsProperty.Settings.VoiceConfirmProfile = false;
			}
			MySettingsProperty.Settings.Save();
		}
	}

	private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
	{
		if ((ListView1.SelectedItems.Count > 0) | (ListView1.CheckedItems.Count <= 1))
		{
			ToolStripMenuItem1.Enabled = true;
			ToolStripMenuItem2.Enabled = true;
			ToolStripMenuItem3.Enabled = false;
			ToolStripMenuItem4.Enabled = true;
			ToolStripMenuItem5.Enabled = true;
			ToolStripMenuItem6.Enabled = false;
			LaunchAppToolStripMenuItem.Enabled = true;
			LaunchAppWithOptionsToolStripMenuItem.Enabled = true;
			RemoveAllSelectedProfilesToolStripMenuItem.Enabled = false;
		}
		else
		{
			ToolStripMenuItem1.Enabled = false;
			ToolStripMenuItem2.Enabled = false;
			ToolStripMenuItem3.Enabled = true;
			ToolStripMenuItem4.Enabled = false;
			ToolStripMenuItem5.Enabled = false;
			LaunchAppToolStripMenuItem.Enabled = false;
			LaunchAppWithOptionsToolStripMenuItem.Enabled = false;
			RemoveAllSelectedProfilesToolStripMenuItem.Enabled = false;
		}
		if (ListView1.CheckedItems.Count > 1)
		{
			ToolStripMenuItem1.Enabled = false;
			ToolStripMenuItem2.Enabled = false;
			ToolStripMenuItem3.Enabled = false;
			ToolStripMenuItem4.Enabled = false;
			ToolStripMenuItem5.Enabled = false;
			ToolStripMenuItem6.Enabled = true;
			LaunchAppToolStripMenuItem.Enabled = false;
			LaunchAppWithOptionsToolStripMenuItem.Enabled = false;
			RemoveAllSelectedProfilesToolStripMenuItem.Enabled = true;
		}
	}

	private void ListView1_DoubleClick(object sender, EventArgs e)
	{
		selectedItem = ListView1.SelectedItems[0].Index;
		foreach (ListViewItem checkedItem in ListView1.CheckedItems)
		{
			checkedItem.Checked = false;
		}
		ShowEdit();
	}

	private void ToolStripMenuItem3_Click(object sender, EventArgs e)
	{
		ShowCreate();
	}

	private void ShowEdit()
	{
		try
		{
			string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
			MyProject.Forms.frmCreateEditProfile.TextDisplayName.Text = array[0];
			MyProject.Forms.frmCreateEditProfile.ComboSS.Text = array[1];
			MyProject.Forms.frmCreateEditProfile.ComboASW.Text = array[2];
			MyProject.Forms.frmCreateEditProfile.ComboCPU.Text = array[4];
			MyProject.Forms.frmCreateEditProfile.ComboMethod.Text = array[3];
			MyProject.Forms.frmCreateEditProfile.pLaunchfile = Path.GetFileName(array[5]);
			MyProject.Forms.frmCreateEditProfile.pPath = array[5];
			MyProject.Forms.frmCreateEditProfile.TextBoxPath.Text = array[5];
			if (!File.Exists(array[5]))
			{
				MyProject.Forms.frmCreateEditProfile.TextBoxPath.BackColor = Color.LightCoral;
				ToolTip1.SetToolTip(MyProject.Forms.frmCreateEditProfile.TextBoxPath, "Path not found!");
			}
			else
			{
				MyProject.Forms.frmCreateEditProfile.TextBoxPath.BackColor = Color.White;
				ToolTip1.SetToolTip(MyProject.Forms.frmCreateEditProfile.TextBoxPath, "");
			}
			MyProject.Forms.frmCreateEditProfile.NumericUpDown1.Value = new decimal(Conversions.ToInteger(array[6]));
			MyProject.Forms.frmCreateEditProfile.NumericUpDown2.Value = new decimal(Conversions.ToInteger(array[7]));
			MyProject.Forms.frmCreateEditProfile.ComboMirror.Text = array[8];
			MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = array[9];
			MyProject.Forms.frmCreateEditProfile.TextBoxComment.Text = array[10];
			string[] array2 = Strings.Split(array[11]);
			MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = new decimal(Conversions.ToDouble(array2[0]));
			MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = new decimal(Conversions.ToDouble(array2[1]));
			MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = array[12];
			MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = array[13];
			MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = array[14];
			MyProject.Forms.frmCreateEditProfile.TextDisplayName.Visible = true;
			MyProject.Forms.frmCreateEditProfile.ComboBox1.Visible = false;
			MyProject.Forms.frmCreateEditProfile.TopMost = true;
			MyProject.Forms.frmCreateEditProfile.isEdit = true;
			MyProject.Forms.frmCreateEditProfile.Button1.Enabled = true;
			MyProject.Forms.frmCreateEditProfile.ShowDialog();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ShowEdit: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void ShowCreate()
	{
		try
		{
			MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
			MyProject.Forms.frmCreateEditProfile.TextDisplayName.Visible = false;
			MyProject.Forms.frmCreateEditProfile.ComboBox1.Visible = true;
			MyProject.Forms.frmCreateEditProfile.ComboBox1.DisplayMember = "Name";
			MyProject.Forms.frmCreateEditProfile.ComboBox1.ValueMember = "Info";
			MyProject.Forms.frmCreateEditProfile.ComboSS.Text = MyProject.Forms.FrmMain.ComboSSstart.Text;
			MyProject.Forms.frmCreateEditProfile.ComboASW.Text = MyProject.Forms.FrmMain.ComboBox1.Text;
			MyProject.Forms.frmCreateEditProfile.ComboCPU.SelectedIndex = 0;
			MyProject.Forms.frmCreateEditProfile.ComboMethod.SelectedIndex = 0;
			MyProject.Forms.frmCreateEditProfile.NumericUpDown1.Value = 5m;
			MyProject.Forms.frmCreateEditProfile.NumericUpDown2.Value = 5m;
			MyProject.Forms.frmCreateEditProfile.ComboMirror.SelectedIndex = 0;
			MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = MyProject.Forms.FrmMain.ComboBox5.Text;
			MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = MyProject.Forms.FrmMain.NumericFOVh.Value;
			MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = MyProject.Forms.FrmMain.NumericFOVv.Value;
			MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = MyProject.Forms.FrmMain.ComboBox8.Text;
			MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = MyProject.Forms.FrmMain.ComboBox9.Text;
			MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = "Yes";
			foreach (KeyValuePair<string, string> game in GameList)
			{
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add(new frmCreateEditProfile.GameItem(game.Key, game.Value));
			}
			if (MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Count > 0)
			{
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add("- All Games & Apps -");
			}
			MyProject.Forms.frmCreateEditProfile.ShowDialog();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ShowCreate: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void ToolStripMenuItem4_Click(object sender, EventArgs e)
	{
		selectedItem = ListView1.SelectedItems[0].Index;
		ShowEdit();
	}

	private void ToolStripMenuItem5_Click(object sender, EventArgs e)
	{
		DeleteProfile();
	}

	private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
	{
		ContextMenuStrip1.Close();
		ListView1.Focus();
	}

	private void ListView1_MouseMove(object sender, MouseEventArgs e)
	{
		if (ListView1.CheckedItems.Count != 0)
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
		}
	}

	private void LaunchAppToolStripMenuItem_Click(object sender, EventArgs e)
	{
		LaunchApp();
	}

	private void LaunchApp()
	{
		checked
		{
			try
			{
				string value = "";
				string text = "";
				string text2 = "";
				if (GetGames.manifesDictionary.TryGetValue(ListView1.SelectedItems[0].Text, out value))
				{
					if (File.Exists(value))
					{
						List<string> list = new List<string>();
						list = GetAppInfo(value, "");
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
							}
							Thread.Sleep(3000);
							if (MyProject.Forms.frmLibrary.ManualStartProfiles.ContainsKey(text.ToLower()))
							{
								Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
								ApplyProfile(text.TrimStart().TrimEnd());
							}
							else
							{
								Log.WriteToLog("No profile found for '" + text + "'");
								FrmMain.fmain.AddToListboxAndScroll("No profile found for '" + text + "'");
							}
							if (Operators.CompareString(text2, "", TextCompare: false) != 0)
							{
								Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text + " (" + text.TrimStart().TrimEnd() + text2.TrimStart().TrimEnd() + ")");
							}
							else
							{
								Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text + " (" + text.TrimStart().TrimEnd() + ")");
							}
							Process.Start(text, text2);
						}
					}
				}
				else
				{
					text = TextBox1.Text;
					if (File.Exists(text))
					{
						MyProject.Forms.FrmMain.ManualStart = true;
						if (!MyProject.Forms.FrmMain.HomeIsRunning)
						{
							RunCommand.StartHome();
						}
						Thread.Sleep(3000);
						Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
						ApplyProfile(text.TrimStart().TrimEnd());
						Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text);
						Log.WriteToLog(" -> " + text.TrimStart().TrimEnd());
						Process.Start(text, text2);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("LaunchApp(): " + ex2.Message);
				Interaction.MsgBox("Could not launch app: " + ex2.Message);
				ProjectData.ClearProjectError();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Adding backgroundworker AppWatchWorker");
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

	private void ApplyProfile(string appName)
	{
		string value = "";
		checked
		{
			if (MyProject.Forms.frmLibrary.ManualStartProfiles.TryGetValue(appName.ToLower(), out value))
			{
				Thread thread = new Thread([SpecialName] () =>
				{
					RunCommand.Run_debug_tool(value);
				});
				thread.Start();
				string value2 = "";
				if (MyProject.Forms.FrmMain.profileAGPS.TryGetValue(appName.ToLower(), out value2))
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
				MyProject.Forms.FrmMain.runningApp = appName;
				string displayName = OTTDB.GetDisplayName(appName);
				MyProject.Forms.FrmMain.runningapp_displayname = OTTDB.GetDisplayName(appName);
				Log.WriteToLog("Manual game launch detected: " + displayName + " (" + appName + ")");
				Log.WriteToLog(displayName + ": Super Sampling @ " + value);
				if (Globals.dbg)
				{
					Log.WriteToLog(MyProject.Forms.FrmMain.runningApp + ": Super Sampling @ " + value);
				}
				FrmMain.fmain.AddToListboxAndScroll(displayName + ": Super Sampling @ " + value);
				string value3 = "";
				if (MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value3))
				{
					System.Timers.Timer timer = new System.Timers.Timer();
					timer.AutoReset = false;
					timer.Interval = Conversions.ToInteger(value3) * 1000;
					timer.Elapsed += MyProject.Forms.FrmMain.ApplyAswTick;
					timer.Start();
					Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + value3 + " seconds");
					FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + value3 + " seconds");
				}
				string value4 = "";
				if (MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value4))
				{
					System.Timers.Timer timer2 = new System.Timers.Timer();
					timer2.AutoReset = false;
					timer2.Interval = Conversions.ToInteger(value4) * 1000;
					timer2.Elapsed += MyProject.Forms.FrmMain.ApplyCpuPrioTick;
					timer2.Start();
					Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + value4 + " seconds");
					FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + value4 + " seconds");
				}
			}
			else
			{
				Log.WriteToLog("No profile found for '" + appName + "'");
			}
		}
	}

	private List<string> GetAppInfo(string jFile, string customParms)
	{
		List<string> list = new List<string>();
		string text = "";
		string text2 = "";
		string json = File.ReadAllText(jFile);
		JObject jObject = (JObject)JToken.Parse(json);
		string text3 = (string)jObject.SelectToken("canonicalName");
		string text4 = ((string)jObject.SelectToken("launchFile")).Replace("\\\\", "\\").Replace("/", "\\");
		text2 = ((Operators.CompareString(customParms, "", TextCompare: false) != 0) ? customParms : ((string)jObject.SelectToken("launchParameters")));
		text = text4.Replace("\\\\", "\\").Replace("/", "\\");
		string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
		string[] array2 = array;
		foreach (string text5 in array2)
		{
			if (File.Exists(text5 + "\\Software\\" + text3 + "\\" + text4))
			{
				text = text5 + "\\Software\\" + text3 + "\\" + text4;
				break;
			}
		}
		list.Add(text);
		list.Add(text2);
		return list;
	}

	private void LaunchAppWithOptionsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		string value = "";
		string text = "";
		string text2 = "";
		checked
		{
			if (GetGames.manifesDictionary.TryGetValue(ListView1.SelectedItems[0].Text, out value))
			{
				if (File.Exists(value))
				{
					List<string> list = new List<string>();
					list = GetAppInfo(value, "");
					int num = list.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text = list[0];
						text2 = list[1];
					}
					MyProject.Forms.frmLaunchOptions.TextBox1.Text = text2;
					MyProject.Forms.frmLaunchOptions.ShowDialog();
					if (MyProject.Forms.frmLaunchOptions.optionsCanceled)
					{
						return;
					}
					if (Operators.CompareString(MyProject.Forms.frmLaunchOptions.TextBox1.Text, "", TextCompare: false) != 0)
					{
						text2 = text2 + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text;
					}
					if ((Operators.CompareString(text, "", TextCompare: false) != 0) & File.Exists(text))
					{
						MyProject.Forms.FrmMain.ManualStart = true;
						if (!MyProject.Forms.FrmMain.HomeIsRunning)
						{
							RunCommand.StartHome();
						}
						Thread.Sleep(3000);
						if (MyProject.Forms.frmLibrary.ManualStartProfiles.ContainsKey(text.ToLower()))
						{
							Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
							FrmMain.fmain.AddToListboxAndScroll("Applying profile for " + OTTDB.GetDisplayName(text));
							ApplyProfile(text.TrimStart().TrimEnd());
						}
						else
						{
							Log.WriteToLog("No profile found for '" + text + "'");
							FrmMain.fmain.AddToListboxAndScroll("No profile found for '" + text + "'");
						}
						FrmMain.fmain.AddToListboxAndScroll("Launching " + ListView1.SelectedItems[0].Text + " with params '" + text2.TrimStart().TrimEnd() + "'");
						if (Operators.CompareString(text2, "", TextCompare: false) != 0)
						{
							Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text + " (" + text.TrimStart().TrimEnd() + text2.TrimStart().TrimEnd() + ")");
						}
						else
						{
							Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text + " (" + text.TrimStart().TrimEnd() + ")");
						}
						Process.Start(text, text2);
					}
				}
			}
			else
			{
				text = TextBox1.Text;
				if (File.Exists(text))
				{
					MyProject.Forms.FrmMain.ManualStart = true;
					if (!MyProject.Forms.FrmMain.HomeIsRunning)
					{
						RunCommand.StartHome();
					}
					Thread.Sleep(3000);
					Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
					ApplyProfile(text.TrimStart().TrimEnd());
					Log.WriteToLog("Launching " + ListView1.SelectedItems[0].Text);
					Log.WriteToLog(" -> " + text.TrimStart().TrimEnd());
					Process.Start(text, text2);
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Adding backgroundworker AppWatchWorker");
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

	private void Button1_Click(object sender, EventArgs e)
	{
		ShowCreate();
	}

	private void ToolStripMenuItem6_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmEditAllSelected.NumericUpDown1.Text = "";
		MyProject.Forms.frmEditAllSelected.NumericUpDown2.Text = "";
		MyProject.Forms.frmEditAllSelected.ComboSS.Text = "";
		MyProject.Forms.frmEditAllSelected.ComboASW.Text = "";
		MyProject.Forms.frmEditAllSelected.ComboCPU.Text = "";
		MyProject.Forms.frmEditAllSelected.ComboMethod.Text = "";
		MyProject.Forms.frmEditAllSelected.ComboMirror.Text = "";
		MyProject.Forms.frmEditAllSelected.ComboAGPS.Text = "";
		MyProject.Forms.frmEditAllSelected.TextBoxComment.Text = "";
		MyProject.Forms.frmEditAllSelected.ShowDialog();
	}

	private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
	{
		if (e.ColumnIndex == 0)
		{
			cck = new CheckBox
			{
				Text = "",
				Visible = true
			};
			e.DrawBackground();
			cck.BackColor = Color.Transparent;
			cck.UseVisualStyleBackColor = true;
			cck.SetBounds(e.Bounds.X, e.Bounds.Y, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);
			cck.Size = new Size(checked(cck.GetPreferredSize(new Size(e.Bounds.Width - 1, e.Bounds.Height)).Width + 1), e.Bounds.Height);
			cck.Location = new Point(4, 2);
			ListView1.Controls.Add(cck);
			cck.Show();
			cck.BringToFront();
			e.DrawText(TextFormatFlags.VerticalCenter);
			cck.CheckedChanged += theCheckboxInHeader_CheckChanged;
		}
		else
		{
			e.DrawDefault = true;
		}
	}

	private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
	{
		e.DrawDefault = true;
	}

	private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
	{
		e.DrawDefault = true;
	}

	private void theCheckboxInHeader_CheckChanged(object sender, EventArgs e)
	{
		if (ListView1.Items.Count <= 0)
		{
			return;
		}
		if (cck.Checked)
		{
			foreach (ListViewItem item in ListView1.Items)
			{
				item.Checked = true;
			}
			return;
		}
		if (cck.Checked)
		{
			return;
		}
		foreach (ListViewItem item2 in ListView1.Items)
		{
			item2.Checked = false;
		}
	}

	private void ComboResolution_SelectedIndexChanged(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.DesktopResolution = Conversions.ToString(ComboResolution.SelectedItem);
		MySettingsProperty.Settings.Save();
	}

	private void ListView1_MouseHover(object sender, EventArgs e)
	{
		ListView1.Refresh();
	}

	private void ListView1_Click(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			string[] array = Strings.Split(Conversions.ToString(ListView1.SelectedItems[0].Tag), ",");
			Label16.Text = array[0];
			Label17.Text = array[1];
			Label18.Text = array[2];
			Label19.Text = array[3];
			Label20.Text = array[4];
			TextBox1.Text = array[5];
			Label22.Text = array[6] + " seconds";
			Label23.Text = array[7] + " seconds";
			Label24.Text = array[8];
			Label25.Text = array[9];
			Label26.Text = array[10];
			string[] array2 = Strings.Split(array[11]);
			Label27.Text = "Horizontal: " + array2[0] + " Vertical: " + array2[1];
			Label28.Text = array[12];
			Label30.Text = array[13];
			Label31.Text = array[14];
			Label16.Visible = true;
			Label17.Visible = true;
			Label18.Visible = true;
			Label19.Visible = true;
			Label20.Visible = true;
			TextBox1.Visible = true;
			Label22.Visible = true;
			Label23.Visible = true;
			Label24.Visible = true;
			Label25.Visible = true;
			Label26.Visible = true;
			Label27.Visible = true;
			Label28.Visible = true;
			Label30.Visible = true;
			Label31.Visible = true;
			Button3.Enabled = true;
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		if (ListView1.CheckedItems.Count == 1)
		{
			ShowEdit();
		}
		else if ((ListView1.SelectedItems.Count == 1) & (ListView1.CheckedItems.Count < 2))
		{
			ShowEdit();
		}
		else if (ListView1.CheckedItems.Count > 1)
		{
			MyProject.Forms.frmEditAllSelected.NumericUpDown1.Text = "";
			MyProject.Forms.frmEditAllSelected.NumericUpDown2.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboSS.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboASW.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboCPU.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboMethod.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboMirror.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboAGPS.Text = "";
			MyProject.Forms.frmEditAllSelected.TextBoxComment.Text = "";
			MyProject.Forms.frmEditAllSelected.ShowDialog();
		}
	}
}
