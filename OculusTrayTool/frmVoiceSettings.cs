using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmVoiceSettings : Form
{
	private delegate void UpdateLabelDelegate(string text);

	private delegate void UpdateListeningButtonDelegate(int index);

	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TrackBar1")]
	private TrackBar _TrackBar1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ListView1")]
	private ListView _ListView1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox2")]
	private CheckBox _CheckBox2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox4")]
	private CheckBox _CheckBox4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox3")]
	private CheckBox _CheckBox3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboDevice")]
	private ComboBox _ComboDevice;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ButtonListen")]
	private Button _ButtonListen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox5")]
	private CheckBox _CheckBox5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox6")]
	private CheckBox _CheckBox6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox7")]
	private CheckBox _CheckBox7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	public bool VoicechangeMade;

	private int iRow;

	private int iCol;

	private string setting;

	private bool isEditing;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolTip1")]
	internal virtual ToolTip ToolTip1
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

	[field: AccessedThroughProperty("LabelConfidencePercent")]
	internal virtual Label LabelConfidencePercent
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
			MouseEventHandler value3 = TrackBar1_MouseUp;
			TrackBar trackBar = _TrackBar1;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
				trackBar.MouseUp -= value3;
			}
			_TrackBar1 = value;
			trackBar = _TrackBar1;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
				trackBar.MouseUp += value3;
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
			MouseEventHandler value2 = ListView1_MouseClick;
			ListView listView = _ListView1;
			if (listView != null)
			{
				listView.MouseClick -= value2;
			}
			_ListView1 = value;
			listView = _ListView1;
			if (listView != null)
			{
				listView.MouseClick += value2;
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

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ListView2")]
	internal virtual ListView ListView2
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

	[field: AccessedThroughProperty("ColumnHeader5")]
	internal virtual ColumnHeader ColumnHeader5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelExplain")]
	internal virtual Label LabelExplain
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckBox1
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox1_CheckedChanged;
			EventHandler value3 = CheckBox1_MouseHover;
			CheckBox checkBox = _CheckBox1;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
				checkBox.MouseHover -= value3;
			}
			_CheckBox1 = value;
			checkBox = _CheckBox1;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
				checkBox.MouseHover += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CheckBox2
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox2_CheckedChanged;
			EventHandler value3 = CheckBox2_MouseHover;
			CheckBox checkBox = _CheckBox2;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
				checkBox.MouseHover -= value3;
			}
			_CheckBox2 = value;
			checkBox = _CheckBox2;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
				checkBox.MouseHover += value3;
			}
		}
	}

	internal virtual CheckBox CheckBox4
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox4_CheckedChanged;
			EventHandler value3 = CheckBox4_MouseHover;
			CheckBox checkBox = _CheckBox4;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
				checkBox.MouseHover -= value3;
			}
			_CheckBox4 = value;
			checkBox = _CheckBox4;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
				checkBox.MouseHover += value3;
			}
		}
	}

	internal virtual CheckBox CheckBox3
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox3_CheckedChanged;
			EventHandler value3 = CheckBox3_MouseHover;
			CheckBox checkBox = _CheckBox3;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
				checkBox.MouseHover -= value3;
			}
			_CheckBox3 = value;
			checkBox = _CheckBox3;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
				checkBox.MouseHover += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboDevice
	{
		[CompilerGenerated]
		get
		{
			return _ComboDevice;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboDevice_SelectedIndexChanged;
			KeyPressEventHandler value3 = ComboDevice_KeyPress;
			ComboBox comboDevice = _ComboDevice;
			if (comboDevice != null)
			{
				comboDevice.SelectedIndexChanged -= value2;
				comboDevice.KeyPress -= value3;
			}
			_ComboDevice = value;
			comboDevice = _ComboDevice;
			if (comboDevice != null)
			{
				comboDevice.SelectedIndexChanged += value2;
				comboDevice.KeyPress += value3;
			}
		}
	}

	internal virtual Button ButtonListen
	{
		[CompilerGenerated]
		get
		{
			return _ButtonListen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ButtonListen_Click;
			Button buttonListen = _ButtonListen;
			if (buttonListen != null)
			{
				buttonListen.Click -= value2;
			}
			_ButtonListen = value;
			buttonListen = _ButtonListen;
			if (buttonListen != null)
			{
				buttonListen.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ImageList1")]
	internal virtual ImageList ImageList1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabelKey")]
	internal virtual Label LabelKey
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

	internal virtual CheckBox CheckBox5
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox5_CheckedChanged;
			EventHandler value3 = CheckBox5_MouseHover;
			CheckBox checkBox = _CheckBox5;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
				checkBox.MouseHover -= value3;
			}
			_CheckBox5 = value;
			checkBox = _CheckBox5;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
				checkBox.MouseHover += value3;
			}
		}
	}

	internal virtual CheckBox CheckBox6
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox6_CheckedChanged;
			EventHandler value3 = CheckBox6_MouseHover;
			CheckBox checkBox = _CheckBox6;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
				checkBox.MouseHover -= value3;
			}
			_CheckBox6 = value;
			checkBox = _CheckBox6;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
				checkBox.MouseHover += value3;
			}
		}
	}

	internal virtual CheckBox CheckBox7
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox7_CheckedChanged;
			CheckBox checkBox = _CheckBox7;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_CheckBox7 = value;
			checkBox = _CheckBox7;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
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
			EventHandler value3 = ComboBox1_TextChanged;
			ComboBox comboBox = _ComboBox1;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
				comboBox.TextChanged -= value3;
			}
			_ComboBox1 = value;
			comboBox = _ComboBox1;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
				comboBox.TextChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
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

	public frmVoiceSettings()
	{
		base.FormClosing += voiceSettings_FormClosing;
		base.Load += voiceSettings_Load;
		base.KeyDown += frmVoiceSettings_KeyDown;
		VoicechangeMade = false;
		isEditing = false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmVoiceSettings));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.Button3 = new System.Windows.Forms.Button();
		this.LabelConfidencePercent = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.TrackBar1 = new System.Windows.Forms.TrackBar();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.DotNetBarTabcontrol1 = new OculusTrayTool.DotNetBarTabcontrol();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.CheckBox7 = new System.Windows.Forms.CheckBox();
		this.CheckBox5 = new System.Windows.Forms.CheckBox();
		this.CheckBox6 = new System.Windows.Forms.CheckBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.LabelExplain = new System.Windows.Forms.Label();
		this.LabelKey = new System.Windows.Forms.Label();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.ButtonListen = new System.Windows.Forms.Button();
		this.CheckBox2 = new System.Windows.Forms.CheckBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.CheckBox3 = new System.Windows.Forms.CheckBox();
		this.ComboDevice = new System.Windows.Forms.ComboBox();
		this.CheckBox4 = new System.Windows.Forms.CheckBox();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.ListView1 = new System.Windows.Forms.ListView();
		this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.Button4 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.ListView2 = new System.Windows.Forms.ListView();
		this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.TrackBar1).BeginInit();
		this.DotNetBarTabcontrol1.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.TabPage2.SuspendLayout();
		base.SuspendLayout();
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(601, 47);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label2.Location = new System.Drawing.Point(5, 10);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(585, 35);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Click on the Voice Command you want to edit and add/remove phrases to control that function. Commands are separated with a semicolon ( ; ).\r\n";
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(538, 474);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 25);
		this.Button1.TabIndex = 5;
		this.Button1.Text = "OK";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button3.Location = new System.Drawing.Point(12, 474);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(83, 25);
		this.Button3.TabIndex = 10;
		this.Button3.Text = "Set Defaults";
		this.Button3.UseVisualStyleBackColor = true;
		this.LabelConfidencePercent.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.LabelConfidencePercent.AutoSize = true;
		this.LabelConfidencePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelConfidencePercent.ForeColor = System.Drawing.Color.DodgerBlue;
		this.LabelConfidencePercent.Location = new System.Drawing.Point(308, 479);
		this.LabelConfidencePercent.Name = "LabelConfidencePercent";
		this.LabelConfidencePercent.Size = new System.Drawing.Size(0, 15);
		this.LabelConfidencePercent.TabIndex = 40;
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label1.Location = new System.Drawing.Point(126, 479);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(72, 15);
		this.Label1.TabIndex = 39;
		this.Label1.Text = "Confidence:";
		this.TrackBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.TrackBar1.AutoSize = false;
		this.TrackBar1.Location = new System.Drawing.Point(201, 479);
		this.TrackBar1.Maximum = 100;
		this.TrackBar1.Minimum = 1;
		this.TrackBar1.Name = "TrackBar1";
		this.TrackBar1.Size = new System.Drawing.Size(107, 20);
		this.TrackBar1.TabIndex = 38;
		this.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
		this.TrackBar1.Value = 1;
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "Very-Basic-Listen-icon.png");
		this.ImageList1.Images.SetKeyName(1, "Very-Basic-Not-Listen-icon.png");
		this.DotNetBarTabcontrol1.Alignment = System.Windows.Forms.TabAlignment.Left;
		this.DotNetBarTabcontrol1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage3);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage1);
		this.DotNetBarTabcontrol1.Controls.Add(this.TabPage2);
		this.DotNetBarTabcontrol1.ItemSize = new System.Drawing.Size(43, 80);
		this.DotNetBarTabcontrol1.Location = new System.Drawing.Point(12, 65);
		this.DotNetBarTabcontrol1.Multiline = true;
		this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
		this.DotNetBarTabcontrol1.SelectedIndex = 0;
		this.DotNetBarTabcontrol1.Size = new System.Drawing.Size(601, 403);
		this.DotNetBarTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		this.DotNetBarTabcontrol1.TabIndex = 41;
		this.ToolTip1.SetToolTip(this.DotNetBarTabcontrol1, "Click to add command");
		this.TabPage3.BackColor = System.Drawing.Color.White;
		this.TabPage3.Controls.Add(this.GroupBox2);
		this.TabPage3.Location = new System.Drawing.Point(84, 4);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage3.Size = new System.Drawing.Size(513, 395);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "Activation";
		this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox2.Controls.Add(this.CheckBox7);
		this.GroupBox2.Controls.Add(this.CheckBox5);
		this.GroupBox2.Controls.Add(this.CheckBox6);
		this.GroupBox2.Controls.Add(this.Label3);
		this.GroupBox2.Controls.Add(this.LabelExplain);
		this.GroupBox2.Controls.Add(this.LabelKey);
		this.GroupBox2.Controls.Add(this.CheckBox1);
		this.GroupBox2.Controls.Add(this.ButtonListen);
		this.GroupBox2.Controls.Add(this.CheckBox2);
		this.GroupBox2.Controls.Add(this.Label4);
		this.GroupBox2.Controls.Add(this.CheckBox3);
		this.GroupBox2.Controls.Add(this.ComboDevice);
		this.GroupBox2.Controls.Add(this.CheckBox4);
		this.GroupBox2.Location = new System.Drawing.Point(6, 0);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(501, 389);
		this.GroupBox2.TabIndex = 10;
		this.GroupBox2.TabStop = false;
		this.CheckBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.CheckBox7.AutoSize = true;
		this.CheckBox7.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox7.Location = new System.Drawing.Point(355, 366);
		this.CheckBox7.Name = "CheckBox7";
		this.CheckBox7.Size = new System.Drawing.Size(138, 17);
		this.CheckBox7.TabIndex = 12;
		this.CheckBox7.Text = "Disable audio feedback";
		this.CheckBox7.UseVisualStyleBackColor = true;
		this.CheckBox5.AutoSize = true;
		this.CheckBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox5.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox5.Location = new System.Drawing.Point(20, 162);
		this.CheckBox5.Name = "CheckBox5";
		this.CheckBox5.Size = new System.Drawing.Size(178, 19);
		this.CheckBox5.TabIndex = 10;
		this.CheckBox5.Text = "Joystick activated, continous";
		this.CheckBox5.UseVisualStyleBackColor = true;
		this.CheckBox6.AutoSize = true;
		this.CheckBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox6.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox6.Location = new System.Drawing.Point(20, 187);
		this.CheckBox6.Name = "CheckBox6";
		this.CheckBox6.Size = new System.Drawing.Size(198, 19);
		this.CheckBox6.TabIndex = 11;
		this.CheckBox6.Text = "Joystick activated, Push-To-Talk";
		this.CheckBox6.UseVisualStyleBackColor = true;
		this.Label3.AutoSize = true;
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label3.Location = new System.Drawing.Point(6, 30);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(446, 15);
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Select how voice commands should be enabled. You can select multiple options.";
		this.LabelExplain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.LabelExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelExplain.ForeColor = System.Drawing.Color.DodgerBlue;
		this.LabelExplain.Location = new System.Drawing.Point(256, 70);
		this.LabelExplain.Name = "LabelExplain";
		this.LabelExplain.Size = new System.Drawing.Size(239, 178);
		this.LabelExplain.TabIndex = 2;
		this.LabelKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelKey.ForeColor = System.Drawing.Color.DodgerBlue;
		this.LabelKey.Location = new System.Drawing.Point(19, 324);
		this.LabelKey.Name = "LabelKey";
		this.LabelKey.Size = new System.Drawing.Size(205, 25);
		this.LabelKey.TabIndex = 9;
		this.LabelKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.CheckBox1.AutoSize = true;
		this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox1.Location = new System.Drawing.Point(20, 70);
		this.CheckBox1.Name = "CheckBox1";
		this.CheckBox1.Size = new System.Drawing.Size(166, 19);
		this.CheckBox1.TabIndex = 1;
		this.CheckBox1.Text = "Voice activated, continous";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.ButtonListen.Enabled = false;
		this.ButtonListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.ButtonListen.Image = OculusTrayTool.My.Resources.Resources.Very_Basic_Not_Listen_icon;
		this.ButtonListen.Location = new System.Drawing.Point(242, 313);
		this.ButtonListen.Name = "ButtonListen";
		this.ButtonListen.Size = new System.Drawing.Size(56, 53);
		this.ButtonListen.TabIndex = 8;
		this.ToolTip1.SetToolTip(this.ButtonListen, "Click to capture button or key");
		this.ButtonListen.UseVisualStyleBackColor = true;
		this.CheckBox2.AutoSize = true;
		this.CheckBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox2.Location = new System.Drawing.Point(20, 93);
		this.CheckBox2.Name = "CheckBox2";
		this.CheckBox2.Size = new System.Drawing.Size(162, 19);
		this.CheckBox2.TabIndex = 3;
		this.CheckBox2.Text = "Voice activated, repeated";
		this.CheckBox2.UseVisualStyleBackColor = true;
		this.Label4.AutoSize = true;
		this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label4.Location = new System.Drawing.Point(16, 247);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(208, 15);
		this.Label4.TabIndex = 7;
		this.Label4.Text = "Select device for button/key activation";
		this.CheckBox3.AutoSize = true;
		this.CheckBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox3.Location = new System.Drawing.Point(20, 116);
		this.CheckBox3.Name = "CheckBox3";
		this.CheckBox3.Size = new System.Drawing.Size(188, 19);
		this.CheckBox3.TabIndex = 4;
		this.CheckBox3.Text = "Keyboard activated, continous";
		this.CheckBox3.UseVisualStyleBackColor = true;
		this.ComboDevice.Enabled = false;
		this.ComboDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboDevice.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ComboDevice.FormattingEnabled = true;
		this.ComboDevice.Location = new System.Drawing.Point(19, 265);
		this.ComboDevice.Name = "ComboDevice";
		this.ComboDevice.Size = new System.Drawing.Size(205, 23);
		this.ComboDevice.TabIndex = 6;
		this.CheckBox4.AutoSize = true;
		this.CheckBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox4.Location = new System.Drawing.Point(20, 139);
		this.CheckBox4.Name = "CheckBox4";
		this.CheckBox4.Size = new System.Drawing.Size(208, 19);
		this.CheckBox4.TabIndex = 5;
		this.CheckBox4.Text = "Keyboard activated, Push-To-Talk";
		this.CheckBox4.UseVisualStyleBackColor = true;
		this.TabPage1.BackColor = System.Drawing.Color.White;
		this.TabPage1.Controls.Add(this.ListView1);
		this.TabPage1.Location = new System.Drawing.Point(84, 4);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(513, 395);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "System";
		this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader3 });
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ListView1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		this.ListView1.Location = new System.Drawing.Point(3, 3);
		this.ListView1.Name = "ListView1";
		this.ListView1.Size = new System.Drawing.Size(507, 389);
		this.ListView1.TabIndex = 1;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ColumnHeader1.Text = "Action";
		this.ColumnHeader1.Width = 134;
		this.ColumnHeader2.Text = "Voice Command";
		this.ColumnHeader2.Width = 187;
		this.ColumnHeader3.Text = "Enabled";
		this.TabPage2.BackColor = System.Drawing.Color.White;
		this.TabPage2.Controls.Add(this.Button4);
		this.TabPage2.Controls.Add(this.Button2);
		this.TabPage2.Controls.Add(this.ComboBox1);
		this.TabPage2.Controls.Add(this.Label5);
		this.TabPage2.Controls.Add(this.ListView2);
		this.TabPage2.Location = new System.Drawing.Point(84, 4);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage2.Size = new System.Drawing.Size(513, 395);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "User";
		this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button4.Location = new System.Drawing.Point(299, 7);
		this.Button4.Name = "Button4";
		this.Button4.Size = new System.Drawing.Size(75, 23);
		this.Button4.TabIndex = 4;
		this.Button4.Text = "Add Profile";
		this.Button4.UseVisualStyleBackColor = true;
		this.Button2.Enabled = false;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(218, 7);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(75, 23);
		this.Button2.TabIndex = 3;
		this.Button2.Text = "Edit Profile";
		this.Button2.UseVisualStyleBackColor = true;
		this.ComboBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ComboBox1.FormattingEnabled = true;
		this.ComboBox1.Location = new System.Drawing.Point(48, 9);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(164, 21);
		this.ComboBox1.TabIndex = 2;
		this.Label5.AutoSize = true;
		this.Label5.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label5.Location = new System.Drawing.Point(6, 12);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(36, 13);
		this.Label5.TabIndex = 1;
		this.Label5.Text = "Profile";
		this.ListView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.ColumnHeader4, this.ColumnHeader5 });
		this.ListView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ListView2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ListView2.FullRowSelect = true;
		this.ListView2.GridLines = true;
		this.ListView2.Location = new System.Drawing.Point(3, 38);
		this.ListView2.Name = "ListView2";
		this.ListView2.Size = new System.Drawing.Size(507, 354);
		this.ListView2.TabIndex = 0;
		this.ListView2.UseCompatibleStateImageBehavior = false;
		this.ListView2.View = System.Windows.Forms.View.Details;
		this.ColumnHeader4.Text = "Spoken Command";
		this.ColumnHeader4.Width = 264;
		this.ColumnHeader5.Text = "Actions";
		this.ColumnHeader5.Width = 227;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(625, 508);
		base.Controls.Add(this.DotNetBarTabcontrol1);
		base.Controls.Add(this.LabelConfidencePercent);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.TrackBar1);
		base.Controls.Add(this.Button3);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmVoiceSettings";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Configure Voice Commands";
		this.GroupBox1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.TrackBar1).EndInit();
		this.DotNetBarTabcontrol1.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.TabPage1.ResumeLayout(false);
		this.TabPage2.ResumeLayout(false);
		this.TabPage2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		if (VoicechangeMade)
		{
			VoicechangeMade = false;
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Restarting voice recognition");
			VoiceCommands.StopListening();
			VoiceCommands.DisableVoice();
			VoiceCommands.StartStopBuilder();
		}
		Close();
	}

	private void voiceSettings_FormClosing(object sender, FormClosingEventArgs e)
	{
		MySettingsProperty.Settings.VoiceDialogSize = base.Size;
		MySettings.Default.VoiceWindowLocation = base.Location;
		MySettingsProperty.Settings.Save();
		MySettings.Default.Save();
	}

	private void voiceSettings_Load(object sender, EventArgs e)
	{
		if (DotNetBarTabcontrol1.TabPages.Count > 2)
		{
			DotNetBarTabcontrol1.TabPages.Remove(DotNetBarTabcontrol1.TabPages[2]);
		}
		if (MySettings.Default.VoiceWindowLocation != default(Point))
		{
			base.Location = MySettings.Default.VoiceWindowLocation;
		}
		else
		{
			base.StartPosition = FormStartPosition.CenterParent;
		}
		if (!GetControllers.ControllersFound)
		{
			GetControllers.GetAllControllers();
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.StartVoice = "computer, start listening;speech on";
		MySettingsProperty.Settings.StartVoiceEnabled = true;
		MySettingsProperty.Settings.StopVoice = "computer, stop listening;speech off";
		MySettingsProperty.Settings.StopVoiceEnabled = true;
		MySettingsProperty.Settings.EnableASW = "enable spacewarp";
		MySettingsProperty.Settings.EnableASWEnabled = true;
		MySettingsProperty.Settings.DisableASW = "disable spacewarp";
		MySettingsProperty.Settings.DisableASWEnabled = true;
		MySettingsProperty.Settings.ShowPD = "show pixel density; show super sampling";
		MySettingsProperty.Settings.ShowPDEnabled = true;
		MySettingsProperty.Settings.ShowPerf = "show performance";
		MySettingsProperty.Settings.ShowPerfEnabled = true;
		MySettingsProperty.Settings.Close = "close overlay";
		MySettingsProperty.Settings.CloseEnabled = true;
		MySettingsProperty.Settings.SetPD = "set pixel density;set super sampling";
		MySettingsProperty.Settings.SetPDEnabled = true;
		MySettingsProperty.Settings.ShowASW = "show spacewarp";
		MySettingsProperty.Settings.ShowASWEnabled = true;
		MySettingsProperty.Settings.LockASWOn = "lock framerate";
		MySettingsProperty.Settings.LockASWOnEnabled = true;
		MySettingsProperty.Settings.ShowLatency = "show latency timing";
		MySettingsProperty.Settings.ShowLatencyEnabled = true;
		MySettingsProperty.Settings.ShowApplicationRender = "show application timing";
		MySettingsProperty.Settings.ShowApplicationRenderEnabled = true;
		MySettingsProperty.Settings.ShowCompositorRender = "show compositor timing";
		MySettingsProperty.Settings.ShowCompositorRenderEnabled = true;
		MySettingsProperty.Settings.ShowVersion = "show version";
		MySettingsProperty.Settings.ShowVersionEnabled = true;
		MySettingsProperty.Settings.LaunchSteam = "start steam;launch steam";
		MySettingsProperty.Settings.LaunchSteamEnabled = true;
		MySettingsProperty.Settings.Save();
		MyProject.Forms.FrmMain.LoadVoiceSettings();
		VoicechangeMade = true;
	}

	private void TrackBar1_Scroll(object sender, EventArgs e)
	{
		LabelConfidencePercent.Text = Conversions.ToString(TrackBar1.Value) + "%";
		LabelConfidencePercent.Refresh();
		VoicechangeMade = true;
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (CheckBox1.Checked)
			{
				CheckBox2.Checked = false;
				LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the prhase set for 'Disable Voice Control' is spoken.";
				MySettingsProperty.Settings.VoiceActivationVoiceContinous = true;
			}
			else
			{
				MySettingsProperty.Settings.VoiceActivationVoiceContinous = false;
			}
			MySettingsProperty.Settings.Save();
		}
	}

	private void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (CheckBox2.Checked)
			{
				CheckBox1.Checked = false;
				LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the prhase set for 'Enable Voice Control' must once again be spoken to activate commands.";
				MySettingsProperty.Settings.VoiceActivationVoiceRepeated = true;
			}
			else
			{
				MySettingsProperty.Settings.VoiceActivationVoiceRepeated = false;
			}
			MySettingsProperty.Settings.Save();
		}
	}

	private void CheckBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckBox3.Checked)
		{
			ComboDevice.Enabled = true;
			CheckBox4.Checked = false;
			LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again";
			MySettingsProperty.Settings.VoiceActivationKeyContinous = true;
		}
		else
		{
			MySettingsProperty.Settings.VoiceActivationKeyContinous = false;
			if (!CheckBox3.Checked & !CheckBox4.Checked & !CheckBox5.Checked & !CheckBox5.Checked & !CheckBox6.Checked)
			{
				ComboDevice.Enabled = false;
				ButtonListen.Enabled = false;
			}
		}
		MySettingsProperty.Settings.Save();
		AddItemsToDeviceList();
	}

	private void CheckBox4_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckBox4.Checked)
		{
			ComboDevice.Enabled = true;
			CheckBox3.Checked = false;
			LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
			MySettingsProperty.Settings.VoiceActivationKeyPush = true;
		}
		else
		{
			MySettingsProperty.Settings.VoiceActivationKeyPush = false;
			if (!CheckBox3.Checked & !CheckBox4.Checked & !CheckBox5.Checked & !CheckBox5.Checked & !CheckBox6.Checked)
			{
				ComboDevice.Enabled = false;
				ButtonListen.Enabled = false;
			}
		}
		MySettingsProperty.Settings.Save();
		AddItemsToDeviceList();
	}

	private void ButtonListen_Click(object sender, EventArgs e)
	{
		ButtonListen.Image = ImageList1.Images[0];
		ButtonListen.Refresh();
		if ((Operators.CompareString(ComboDevice.SelectedItem.ToString(), "Keyboard", TextCompare: false) != 0) & (Operators.CompareString(ComboDevice.SelectedItem.ToString(), "", TextCompare: false) != 0))
		{
			UpdateButtonLabel("Push button");
			GetControllers.CaptureSelectedButton();
		}
		if ((Operators.CompareString(ComboDevice.SelectedItem.ToString(), "Keyboard", TextCompare: false) == 0) & (Operators.CompareString(ComboDevice.SelectedItem.ToString(), "", TextCompare: false) != 0))
		{
			LabelKey.Text = "Press key";
		}
	}

	private void ComboDevice_SelectedIndexChanged(object sender, EventArgs e)
	{
		GetControllers.selectedDevice = ComboDevice.SelectedItem.ToString();
		if (Operators.CompareString(ComboDevice.SelectedItem.ToString(), "Keyboard", TextCompare: false) != 0)
		{
			GetControllers.SelectController();
			if (Operators.CompareString(MySettingsProperty.Settings.JoystickDeviceName, ComboDevice.SelectedItem.ToString(), TextCompare: false) == 0)
			{
				LabelKey.Text = MySettingsProperty.Settings.JoystickVoiceActivationButton.Replace("Buttons", "");
			}
		}
		else
		{
			LabelKey.Text = MySettingsProperty.Settings.KeyboardVoiceActivationKey;
		}
		ButtonListen.Enabled = true;
	}

	private void TrackBar1_MouseUp(object sender, MouseEventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.Confidence = TrackBar1.Value;
			MySettingsProperty.Settings.Save();
		}
	}

	public static void UpdateButtonLabel(string text)
	{
		if (MyProject.Forms.frmVoiceSettings.InvokeRequired)
		{
			UpdateLabelDelegate method = UpdateButtonLabel;
			MyProject.Forms.frmVoiceSettings.Invoke(method, text);
		}
		else
		{
			MyProject.Forms.frmVoiceSettings.LabelKey.Text = text;
			MyProject.Forms.frmVoiceSettings.LabelKey.Refresh();
		}
	}

	public static void UpdateListeningButton(int index)
	{
		if (MyProject.Forms.frmVoiceSettings.InvokeRequired)
		{
			UpdateListeningButtonDelegate method = UpdateListeningButton;
			MyProject.Forms.frmVoiceSettings.Invoke(method, index);
		}
		else
		{
			MyProject.Forms.frmVoiceSettings.ButtonListen.Image = MyProject.Forms.frmVoiceSettings.ImageList1.Images[index];
			MyProject.Forms.frmVoiceSettings.ButtonListen.Refresh();
		}
	}

	private void CheckBox5_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckBox5.Checked)
		{
			ComboDevice.Enabled = true;
			CheckBox6.Checked = false;
			LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again";
			MySettingsProperty.Settings.JoystickActivationKeyContinous = true;
		}
		else
		{
			MySettingsProperty.Settings.JoystickActivationKeyContinous = false;
			if (!CheckBox3.Checked & !CheckBox4.Checked & !CheckBox5.Checked & !CheckBox5.Checked & !CheckBox6.Checked)
			{
				ComboDevice.Enabled = false;
				ButtonListen.Enabled = false;
			}
		}
		MySettingsProperty.Settings.Save();
		AddItemsToDeviceList();
	}

	private void CheckBox6_CheckedChanged(object sender, EventArgs e)
	{
		if (GetConfig.IsReading)
		{
			return;
		}
		if (CheckBox6.Checked)
		{
			ComboDevice.Enabled = true;
			CheckBox5.Checked = false;
			LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
			MySettingsProperty.Settings.JoystickActivationKeyPush = true;
		}
		else
		{
			MySettingsProperty.Settings.JoystickActivationKeyPush = false;
			if (!CheckBox3.Checked & !CheckBox4.Checked & !CheckBox5.Checked & !CheckBox5.Checked & !CheckBox6.Checked)
			{
				ComboDevice.Enabled = false;
				ButtonListen.Enabled = false;
			}
		}
		MySettingsProperty.Settings.Save();
		AddItemsToDeviceList();
	}

	private void frmVoiceSettings_KeyDown(object sender, KeyEventArgs e)
	{
		if (Operators.CompareString(LabelKey.Text, "Press key", TextCompare: false) == 0)
		{
			UpdateButtonLabel(e.KeyCode.ToString().ToUpper());
			ButtonListen.Image = ImageList1.Images[1];
			ButtonListen.Refresh();
			MySettingsProperty.Settings.KeyboardVoiceActivationKey = e.KeyCode.ToString().ToUpper();
			MySettingsProperty.Settings.Save();
			Log.WriteToLog("Registered '" + e.KeyCode.ToString().ToUpper() + "' as key for activating voice commands");
		}
	}

	private void CheckBox1_MouseHover(object sender, EventArgs e)
	{
		LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the phrase set for 'Disable Voice Control' is spoken.";
		LabelExplain.Refresh();
	}

	private void CheckBox2_MouseHover(object sender, EventArgs e)
	{
		LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the phrase set for 'Enable Voice Control' must once again be spoken.";
		LabelExplain.Refresh();
	}

	private void CheckBox3_MouseHover(object sender, EventArgs e)
	{
		LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again.";
		LabelExplain.Refresh();
	}

	private void CheckBox4_MouseHover(object sender, EventArgs e)
	{
		LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
		LabelExplain.Refresh();
	}

	private void CheckBox5_MouseHover(object sender, EventArgs e)
	{
		LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again.";
		LabelExplain.Refresh();
	}

	private void CheckBox6_MouseHover(object sender, EventArgs e)
	{
		LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
		LabelExplain.Refresh();
	}

	public void AddItemsToDeviceList()
	{
		ComboDevice.Text = "";
		ComboDevice.Items.Clear();
		LabelKey.Text = "";
		if (CheckBox3.Checked | CheckBox4.Checked)
		{
			ComboDevice.Items.Add("Keyboard");
		}
		if (!(CheckBox5.Checked | CheckBox6.Checked))
		{
			return;
		}
		foreach (KeyValuePair<string, Guid> joystick in GetControllers.joysticks)
		{
			ComboDevice.Items.Add(joystick.Key);
		}
	}

	private void ComboDevice_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = true;
	}

	private void ListView1_MouseClick(object sender, MouseEventArgs e)
	{
		ListViewHitTestInfo listViewHitTestInfo = ListView1.HitTest(e.X, e.Y);
		if (listViewHitTestInfo.Item != null)
		{
			MyProject.Forms.frmEditVoiceCommand.LabelAction.Text = listViewHitTestInfo.Item.Text;
			MyProject.Forms.frmEditVoiceCommand.TextBoxPhrase.Text = listViewHitTestInfo.Item.SubItems[1].Text + ";";
			if (Operators.CompareString(listViewHitTestInfo.Item.SubItems[2].Text, "True", TextCompare: false) == 0)
			{
				MyProject.Forms.frmEditVoiceCommand.ComboEnabled.SelectedIndex = 0;
			}
			else
			{
				MyProject.Forms.frmEditVoiceCommand.ComboEnabled.SelectedIndex = 1;
			}
			MyProject.Forms.frmEditVoiceCommand.ShowDialog();
		}
	}

	private void CheckBox7_CheckedChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			if (CheckBox7.Checked)
			{
				MySettingsProperty.Settings.DisableVoiceControlAudioFeedback = true;
			}
			else
			{
				MySettingsProperty.Settings.DisableVoiceControlAudioFeedback = false;
			}
			MySettingsProperty.Settings.Save();
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmAddCustomVoice.ShowDialog();
	}

	private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Operators.ConditionalCompareObjectNotEqual(ComboBox1.SelectedItem, null, TextCompare: false))
		{
			Button2.Enabled = true;
			List<string> list = new List<string>();
			list = (List<string>)OTTDB.GetVoiceProfileCommands(ComboBox1.SelectedItem.ToString());
			{
				foreach (string item in list)
				{
					string[] array = Strings.Split(item, "|");
					ListViewItem listViewItem = new ListViewItem();
					listViewItem = ListView2.Items.Add(array[0]);
					string[] array2 = Strings.Split(array[1], ",");
					string[] array3 = array2;
					foreach (string expression in array3)
					{
						string[] array4 = Strings.Split(expression, ":");
						if (Operators.CompareString(array4[0], "wait", TextCompare: false) != 0)
						{
							listViewItem.SubItems.Add(array4[0] + " '" + array4[1] + "'");
						}
					}
				}
				return;
			}
		}
		Button2.Enabled = false;
	}

	private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmAddVoiceProfile.ShowDialog();
	}

	private void ComboBox1_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(ComboBox1.Text, null, TextCompare: false) == 0)
		{
			Button2.Enabled = false;
		}
	}
}
