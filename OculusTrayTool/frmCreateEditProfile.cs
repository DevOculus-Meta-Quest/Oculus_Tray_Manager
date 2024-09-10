using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmCreateEditProfile : Form
{
	public class GameItem
	{
		private string mInfo;

		private string mName;

		public string info
		{
			get
			{
				return mInfo;
			}
			set
			{
				mInfo = value;
			}
		}

		public string Name
		{
			get
			{
				return mName;
			}
			set
			{
				mName = value;
			}
		}

		public GameItem(string name, string info)
		{
			mInfo = info;
			mName = name;
		}
	}

	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboSS")]
	private ComboBox _ComboSS;

	public string pLaunchfile;

	public string pPath;

	public bool CreateCancel;

	public bool isEdit;

	private string DSep;

	[field: AccessedThroughProperty("ComboCPU")]
	internal virtual ComboBox ComboCPU
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextDisplayName")]
	internal virtual TextBox TextDisplayName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboASW")]
	internal virtual ComboBox ComboASW
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
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

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
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

	[field: AccessedThroughProperty("ComboMethod")]
	internal virtual ComboBox ComboMethod
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

	[field: AccessedThroughProperty("PictureBox3")]
	internal virtual PictureBox PictureBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox2")]
	internal virtual PictureBox PictureBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1
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

	[field: AccessedThroughProperty("NumericUpDown1")]
	internal virtual NumericUpDown NumericUpDown1
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

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("NumericUpDown2")]
	internal virtual NumericUpDown NumericUpDown2
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

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7
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

	[field: AccessedThroughProperty("TextBoxPath")]
	internal virtual TextBox TextBoxPath
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

	[field: AccessedThroughProperty("ComboMirror")]
	internal virtual ComboBox ComboMirror
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

	[field: AccessedThroughProperty("PictureBox9")]
	internal virtual PictureBox PictureBox9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox10")]
	internal virtual PictureBox PictureBox10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboAGPS")]
	internal virtual ComboBox ComboAGPS
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

	internal virtual ComboBox ComboSS
	{
		[CompilerGenerated]
		get
		{
			return _ComboSS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = ComboSS_KeyPress;
			ComboBox comboSS = _ComboSS;
			if (comboSS != null)
			{
				comboSS.KeyPress -= value2;
			}
			_ComboSS = value;
			comboSS = _ComboSS;
			if (comboSS != null)
			{
				comboSS.KeyPress += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextBoxComment")]
	internal virtual TextBox TextBoxComment
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label11")]
	internal virtual Label Label11
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

	[field: AccessedThroughProperty("Label14")]
	internal virtual Label Label14
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

	[field: AccessedThroughProperty("NumericUpDown3")]
	internal virtual NumericUpDown NumericUpDown3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("NumericUpDown4")]
	internal virtual NumericUpDown NumericUpDown4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox11")]
	internal virtual PictureBox PictureBox11
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

	[field: AccessedThroughProperty("ComboBox8")]
	internal virtual ComboBox ComboBox8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboBox9")]
	internal virtual ComboBox ComboBox9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label37")]
	internal virtual Label Label37
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboBoxEnabled")]
	internal virtual ComboBox ComboBoxEnabled
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

	public frmCreateEditProfile()
	{
		base.Load += CreateEditProfile_Load;
		CreateCancel = false;
		isEdit = false;
		DSep = ".";
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmCreateEditProfile));
		this.ComboCPU = new System.Windows.Forms.ComboBox();
		this.TextDisplayName = new System.Windows.Forms.TextBox();
		this.ComboASW = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.ComboMethod = new System.Windows.Forms.ComboBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ComboBoxEnabled = new System.Windows.Forms.ComboBox();
		this.Label15 = new System.Windows.Forms.Label();
		this.Label33 = new System.Windows.Forms.Label();
		this.ComboBox8 = new System.Windows.Forms.ComboBox();
		this.ComboBox9 = new System.Windows.Forms.ComboBox();
		this.Label37 = new System.Windows.Forms.Label();
		this.PictureBox11 = new System.Windows.Forms.PictureBox();
		this.NumericUpDown3 = new System.Windows.Forms.NumericUpDown();
		this.NumericUpDown4 = new System.Windows.Forms.NumericUpDown();
		this.Label14 = new System.Windows.Forms.Label();
		this.Label13 = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.TextBoxComment = new System.Windows.Forms.TextBox();
		this.Label11 = new System.Windows.Forms.Label();
		this.ComboSS = new System.Windows.Forms.ComboBox();
		this.PictureBox10 = new System.Windows.Forms.PictureBox();
		this.ComboAGPS = new System.Windows.Forms.ComboBox();
		this.Label10 = new System.Windows.Forms.Label();
		this.PictureBox9 = new System.Windows.Forms.PictureBox();
		this.ComboMirror = new System.Windows.Forms.ComboBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.Button3 = new System.Windows.Forms.Button();
		this.PictureBox8 = new System.Windows.Forms.PictureBox();
		this.TextBoxPath = new System.Windows.Forms.TextBox();
		this.Label8 = new System.Windows.Forms.Label();
		this.NumericUpDown2 = new System.Windows.Forms.NumericUpDown();
		this.PictureBox7 = new System.Windows.Forms.PictureBox();
		this.Label7 = new System.Windows.Forms.Label();
		this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.PictureBox6 = new System.Windows.Forms.PictureBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.PictureBox5 = new System.Windows.Forms.PictureBox();
		this.PictureBox4 = new System.Windows.Forms.PictureBox();
		this.PictureBox3 = new System.Windows.Forms.PictureBox();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		base.SuspendLayout();
		this.ComboCPU.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboCPU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboCPU.FormattingEnabled = true;
		this.ComboCPU.Items.AddRange(new object[4] { "Default", "Normal", "Above Normal", "High" });
		this.ComboCPU.Location = new System.Drawing.Point(103, 149);
		this.ComboCPU.Name = "ComboCPU";
		this.ComboCPU.Size = new System.Drawing.Size(208, 23);
		this.ComboCPU.TabIndex = 18;
		this.TextDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextDisplayName.Location = new System.Drawing.Point(104, 18);
		this.TextDisplayName.Name = "TextDisplayName";
		this.TextDisplayName.Size = new System.Drawing.Size(208, 21);
		this.TextDisplayName.TabIndex = 17;
		this.ComboASW.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboASW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboASW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboASW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboASW.FormattingEnabled = true;
		this.ComboASW.Items.AddRange(new object[7] { "Auto", "Off", "45 Hz", "30 Hz", "18 Hz", "45 Hz forced", "Adaptive" });
		this.ComboASW.Location = new System.Drawing.Point(103, 89);
		this.ComboASW.Name = "ComboASW";
		this.ComboASW.Size = new System.Drawing.Size(208, 23);
		this.ComboASW.TabIndex = 16;
		this.Label1.AutoSize = true;
		this.Label1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label1.Location = new System.Drawing.Point(14, 24);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(62, 13);
		this.Label1.TabIndex = 19;
		this.Label1.Text = "Game/App:";
		this.Label2.AutoSize = true;
		this.Label2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label2.Location = new System.Drawing.Point(14, 57);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(84, 13);
		this.Label2.TabIndex = 20;
		this.Label2.Text = "Super Sampling:";
		this.Label3.AutoSize = true;
		this.Label3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label3.Location = new System.Drawing.Point(14, 94);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(65, 13);
		this.Label3.TabIndex = 21;
		this.Label3.Text = "ASW Mode:";
		this.Label4.AutoSize = true;
		this.Label4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label4.Location = new System.Drawing.Point(14, 154);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(66, 13);
		this.Label4.TabIndex = 22;
		this.Label4.Text = "CPU Priority:";
		this.Label5.AutoSize = true;
		this.Label5.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label5.Location = new System.Drawing.Point(14, 216);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(56, 13);
		this.Label5.TabIndex = 24;
		this.Label5.Text = "Detection:";
		this.ComboMethod.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboMethod.FormattingEnabled = true;
		this.ComboMethod.Items.AddRange(new object[2] { "WMI", "Timer" });
		this.ComboMethod.Location = new System.Drawing.Point(103, 211);
		this.ComboMethod.Name = "ComboMethod";
		this.ComboMethod.Size = new System.Drawing.Size(208, 23);
		this.ComboMethod.TabIndex = 25;
		this.GroupBox1.Controls.Add(this.ComboBoxEnabled);
		this.GroupBox1.Controls.Add(this.Label15);
		this.GroupBox1.Controls.Add(this.Label33);
		this.GroupBox1.Controls.Add(this.ComboBox8);
		this.GroupBox1.Controls.Add(this.ComboBox9);
		this.GroupBox1.Controls.Add(this.Label37);
		this.GroupBox1.Controls.Add(this.PictureBox11);
		this.GroupBox1.Controls.Add(this.NumericUpDown3);
		this.GroupBox1.Controls.Add(this.NumericUpDown4);
		this.GroupBox1.Controls.Add(this.Label14);
		this.GroupBox1.Controls.Add(this.Label13);
		this.GroupBox1.Controls.Add(this.Label12);
		this.GroupBox1.Controls.Add(this.TextBoxComment);
		this.GroupBox1.Controls.Add(this.Label11);
		this.GroupBox1.Controls.Add(this.ComboSS);
		this.GroupBox1.Controls.Add(this.PictureBox10);
		this.GroupBox1.Controls.Add(this.ComboAGPS);
		this.GroupBox1.Controls.Add(this.Label10);
		this.GroupBox1.Controls.Add(this.PictureBox9);
		this.GroupBox1.Controls.Add(this.ComboMirror);
		this.GroupBox1.Controls.Add(this.Label9);
		this.GroupBox1.Controls.Add(this.ComboBox1);
		this.GroupBox1.Controls.Add(this.Button3);
		this.GroupBox1.Controls.Add(this.PictureBox8);
		this.GroupBox1.Controls.Add(this.TextBoxPath);
		this.GroupBox1.Controls.Add(this.Label8);
		this.GroupBox1.Controls.Add(this.NumericUpDown2);
		this.GroupBox1.Controls.Add(this.PictureBox7);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.NumericUpDown1);
		this.GroupBox1.Controls.Add(this.PictureBox6);
		this.GroupBox1.Controls.Add(this.Label6);
		this.GroupBox1.Controls.Add(this.PictureBox5);
		this.GroupBox1.Controls.Add(this.PictureBox4);
		this.GroupBox1.Controls.Add(this.PictureBox3);
		this.GroupBox1.Controls.Add(this.PictureBox2);
		this.GroupBox1.Controls.Add(this.PictureBox1);
		this.GroupBox1.Controls.Add(this.TextDisplayName);
		this.GroupBox1.Controls.Add(this.ComboMethod);
		this.GroupBox1.Controls.Add(this.ComboASW);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.ComboCPU);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Location = new System.Drawing.Point(12, 2);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(754, 292);
		this.GroupBox1.TabIndex = 26;
		this.GroupBox1.TabStop = false;
		this.ComboBoxEnabled.FormattingEnabled = true;
		this.ComboBoxEnabled.Items.AddRange(new object[2] { "Yes", "No" });
		this.ComboBoxEnabled.Location = new System.Drawing.Point(550, 246);
		this.ComboBoxEnabled.Name = "ComboBoxEnabled";
		this.ComboBoxEnabled.Size = new System.Drawing.Size(162, 21);
		this.ComboBoxEnabled.TabIndex = 66;
		this.Label15.AutoSize = true;
		this.Label15.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label15.Location = new System.Drawing.Point(415, 249);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(49, 13);
		this.Label15.TabIndex = 65;
		this.Label15.Text = "Enabled:";
		this.Label33.AutoSize = true;
		this.Label33.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label33.Location = new System.Drawing.Point(415, 140);
		this.Label33.Name = "Label33";
		this.Label33.Size = new System.Drawing.Size(130, 13);
		this.Label33.TabIndex = 61;
		this.Label33.Text = "Force MipMap Generation";
		this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboBox8.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox8.FormattingEnabled = true;
		this.ComboBox8.Items.AddRange(new object[2] { "True", "False" });
		this.ComboBox8.Location = new System.Drawing.Point(551, 135);
		this.ComboBox8.Name = "ComboBox8";
		this.ComboBox8.Size = new System.Drawing.Size(162, 24);
		this.ComboBox8.TabIndex = 62;
		this.ComboBox9.BackColor = System.Drawing.Color.AliceBlue;
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
		this.ComboBox9.Location = new System.Drawing.Point(551, 173);
		this.ComboBox9.Name = "ComboBox9";
		this.ComboBox9.Size = new System.Drawing.Size(162, 24);
		this.ComboBox9.TabIndex = 64;
		this.Label37.AutoSize = true;
		this.Label37.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label37.Location = new System.Drawing.Point(415, 178);
		this.Label37.Name = "Label37";
		this.Label37.Size = new System.Drawing.Size(99, 13);
		this.Label37.TabIndex = 63;
		this.Label37.Text = "Offset MipMap Bias";
		this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.PictureBox11.Image = (System.Drawing.Image)resources.GetObject("PictureBox11.Image");
		this.PictureBox11.Location = new System.Drawing.Point(729, 99);
		this.PictureBox11.Name = "PictureBox11";
		this.PictureBox11.Size = new System.Drawing.Size(19, 20);
		this.PictureBox11.TabIndex = 60;
		this.PictureBox11.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox11, resources.GetString("PictureBox11.ToolTip"));
		this.NumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumericUpDown3.DecimalPlaces = 2;
		this.NumericUpDown3.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		this.NumericUpDown3.Location = new System.Drawing.Point(562, 97);
		this.NumericUpDown3.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.NumericUpDown3.Name = "NumericUpDown3";
		this.NumericUpDown3.Size = new System.Drawing.Size(45, 20);
		this.NumericUpDown3.TabIndex = 59;
		this.NumericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumericUpDown4.DecimalPlaces = 2;
		this.NumericUpDown4.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		this.NumericUpDown4.Location = new System.Drawing.Point(669, 97);
		this.NumericUpDown4.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.NumericUpDown4.Name = "NumericUpDown4";
		this.NumericUpDown4.Size = new System.Drawing.Size(45, 20);
		this.NumericUpDown4.TabIndex = 56;
		this.Label14.AutoSize = true;
		this.Label14.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label14.Location = new System.Drawing.Point(621, 99);
		this.Label14.Name = "Label14";
		this.Label14.Size = new System.Drawing.Size(42, 13);
		this.Label14.TabIndex = 55;
		this.Label14.Text = "Vertical";
		this.Label13.AutoSize = true;
		this.Label13.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label13.Location = new System.Drawing.Point(502, 99);
		this.Label13.Name = "Label13";
		this.Label13.Size = new System.Drawing.Size(54, 13);
		this.Label13.TabIndex = 54;
		this.Label13.Text = "Horizontal";
		this.Label12.AutoSize = true;
		this.Label12.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label12.Location = new System.Drawing.Point(415, 99);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(73, 13);
		this.Label12.TabIndex = 53;
		this.Label12.Text = "FoV Multiplier:";
		this.TextBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBoxComment.Location = new System.Drawing.Point(550, 211);
		this.TextBoxComment.Name = "TextBoxComment";
		this.TextBoxComment.Size = new System.Drawing.Size(162, 21);
		this.TextBoxComment.TabIndex = 51;
		this.Label11.AutoSize = true;
		this.Label11.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label11.Location = new System.Drawing.Point(415, 216);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(54, 13);
		this.Label11.TabIndex = 52;
		this.Label11.Text = "Comment:";
		this.ComboSS.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboSS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboSS.FormattingEnabled = true;
		this.ComboSS.Items.AddRange(new object[38]
		{
			"0", "0.7", "0.75", "0.8", "0.85", "0.9", "0.95", "1.0", "1.05", "1.1",
			"1.15", "1.2", "1.25", "1.3", "1.35", "1.4", "1.45", "1.5", "1.55", "1.6",
			"1.65", "1.7", "1.75", "1.8", "1.85", "1.9", "1.95", "2.0", "2.05", "2.1",
			"2.15", "2.2", "2.25", "2.3", "2.35", "2.4", "2.45", "2.5"
		});
		this.ComboSS.Location = new System.Drawing.Point(103, 52);
		this.ComboSS.Name = "ComboSS";
		this.ComboSS.Size = new System.Drawing.Size(208, 23);
		this.ComboSS.Sorted = true;
		this.ComboSS.TabIndex = 29;
		this.ComboSS.TabStop = false;
		this.PictureBox10.Image = (System.Drawing.Image)resources.GetObject("PictureBox10.Image");
		this.PictureBox10.Location = new System.Drawing.Point(729, 55);
		this.PictureBox10.Name = "PictureBox10";
		this.PictureBox10.Size = new System.Drawing.Size(19, 20);
		this.PictureBox10.TabIndex = 46;
		this.PictureBox10.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox10, "Enables or Disables Adaptive GPU Scaling. Setting this to Off might improve the experience in some games.");
		this.ComboAGPS.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboAGPS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboAGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboAGPS.FormattingEnabled = true;
		this.ComboAGPS.Items.AddRange(new object[2] { "Off", "On" });
		this.ComboAGPS.Location = new System.Drawing.Point(505, 51);
		this.ComboAGPS.Name = "ComboAGPS";
		this.ComboAGPS.Size = new System.Drawing.Size(208, 23);
		this.ComboAGPS.TabIndex = 45;
		this.Label10.AutoSize = true;
		this.Label10.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label10.Location = new System.Drawing.Point(415, 56);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(71, 13);
		this.Label10.TabIndex = 44;
		this.Label10.Text = "GPU Scaling:";
		this.PictureBox9.Image = (System.Drawing.Image)resources.GetObject("PictureBox9.Image");
		this.PictureBox9.Location = new System.Drawing.Point(729, 17);
		this.PictureBox9.Name = "PictureBox9";
		this.PictureBox9.Size = new System.Drawing.Size(19, 20);
		this.PictureBox9.TabIndex = 43;
		this.PictureBox9.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox9, "Sets the window state of the app when it is launched.");
		this.ComboMirror.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboMirror.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboMirror.FormattingEnabled = true;
		this.ComboMirror.Items.AddRange(new object[3] { "Default", "Minimized", "Forced" });
		this.ComboMirror.Location = new System.Drawing.Point(505, 16);
		this.ComboMirror.Name = "ComboMirror";
		this.ComboMirror.Size = new System.Drawing.Size(208, 23);
		this.ComboMirror.TabIndex = 42;
		this.Label9.AutoSize = true;
		this.Label9.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label9.Location = new System.Drawing.Point(416, 21);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(73, 13);
		this.Label9.TabIndex = 41;
		this.Label9.Text = "Screen Mirror:";
		this.ComboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox1.FormattingEnabled = true;
		this.ComboBox1.Location = new System.Drawing.Point(104, 17);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(208, 23);
		this.ComboBox1.Sorted = true;
		this.ComboBox1.TabIndex = 29;
		this.ComboBox1.Text = "- Select Game -";
		this.ComboBox1.Visible = false;
		this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button3.Location = new System.Drawing.Point(318, 19);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(26, 21);
		this.Button3.TabIndex = 29;
		this.Button3.Text = "..";
		this.ToolTip1.SetToolTip(this.Button3, "Manually browse for a game if it is not found in the list, or change profile .exe, e.g. the process that Oculus TrayTool will monitor.");
		this.Button3.UseVisualStyleBackColor = true;
		this.PictureBox8.Image = (System.Drawing.Image)resources.GetObject("PictureBox8.Image");
		this.PictureBox8.Location = new System.Drawing.Point(349, 249);
		this.PictureBox8.Name = "PictureBox8";
		this.PictureBox8.Size = new System.Drawing.Size(19, 20);
		this.PictureBox8.TabIndex = 40;
		this.PictureBox8.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox8, "The path to the executable that OTT should monitor.");
		this.TextBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBoxPath.Location = new System.Drawing.Point(104, 249);
		this.TextBoxPath.Name = "TextBoxPath";
		this.TextBoxPath.Size = new System.Drawing.Size(208, 21);
		this.TextBoxPath.TabIndex = 38;
		this.Label8.AutoSize = true;
		this.Label8.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label8.Location = new System.Drawing.Point(14, 254);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(56, 13);
		this.Label8.TabIndex = 39;
		this.Label8.Text = "EXE Path:";
		this.NumericUpDown2.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.NumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.NumericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.NumericUpDown2.Location = new System.Drawing.Point(103, 178);
		this.NumericUpDown2.Name = "NumericUpDown2";
		this.NumericUpDown2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.NumericUpDown2.Size = new System.Drawing.Size(208, 18);
		this.NumericUpDown2.TabIndex = 35;
		this.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.NumericUpDown2.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
		this.PictureBox7.Image = (System.Drawing.Image)resources.GetObject("PictureBox7.Image");
		this.PictureBox7.Location = new System.Drawing.Point(349, 176);
		this.PictureBox7.Name = "PictureBox7";
		this.PictureBox7.Size = new System.Drawing.Size(19, 20);
		this.PictureBox7.TabIndex = 37;
		this.PictureBox7.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox7, "Sets the delay before applying CPU Priority. Some games and apps require a bit more time to start up to successfully change PCU Priority.");
		this.Label7.AutoSize = true;
		this.Label7.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label7.Location = new System.Drawing.Point(25, 180);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(56, 13);
		this.Label7.TabIndex = 36;
		this.Label7.Text = "Set Delay:";
		this.NumericUpDown1.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.NumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.NumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.NumericUpDown1.Location = new System.Drawing.Point(103, 118);
		this.NumericUpDown1.Name = "NumericUpDown1";
		this.NumericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.NumericUpDown1.Size = new System.Drawing.Size(208, 18);
		this.NumericUpDown1.TabIndex = 29;
		this.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.NumericUpDown1.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
		this.PictureBox6.Image = (System.Drawing.Image)resources.GetObject("PictureBox6.Image");
		this.PictureBox6.Location = new System.Drawing.Point(349, 116);
		this.PictureBox6.Name = "PictureBox6";
		this.PictureBox6.Size = new System.Drawing.Size(19, 20);
		this.PictureBox6.TabIndex = 34;
		this.PictureBox6.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox6, "Sets the delay before applying ASW. Some games and apps require a bit more time to start up to successfully change ASW.");
		this.Label6.AutoSize = true;
		this.Label6.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label6.Location = new System.Drawing.Point(20, 119);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(56, 13);
		this.Label6.TabIndex = 33;
		this.Label6.Text = "Set Delay:";
		this.PictureBox5.Image = (System.Drawing.Image)resources.GetObject("PictureBox5.Image");
		this.PictureBox5.Location = new System.Drawing.Point(349, 214);
		this.PictureBox5.Name = "PictureBox5";
		this.PictureBox5.Size = new System.Drawing.Size(19, 20);
		this.PictureBox5.TabIndex = 31;
		this.PictureBox5.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox5, resources.GetString("PictureBox5.ToolTip"));
		this.PictureBox4.Image = (System.Drawing.Image)resources.GetObject("PictureBox4.Image");
		this.PictureBox4.Location = new System.Drawing.Point(349, 147);
		this.PictureBox4.Name = "PictureBox4";
		this.PictureBox4.Size = new System.Drawing.Size(19, 20);
		this.PictureBox4.TabIndex = 30;
		this.PictureBox4.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox4, "Makes Windows give this app a bit higher priority over other system resources. Can improve performance.");
		this.PictureBox3.Image = (System.Drawing.Image)resources.GetObject("PictureBox3.Image");
		this.PictureBox3.Location = new System.Drawing.Point(349, 87);
		this.PictureBox3.Name = "PictureBox3";
		this.PictureBox3.Size = new System.Drawing.Size(19, 20);
		this.PictureBox3.TabIndex = 29;
		this.PictureBox3.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox3, "Sets the mode for Asynchronous Space Warp (ASW). This should usualy be set to Auto unless you experience issues.");
		this.PictureBox2.Image = (System.Drawing.Image)resources.GetObject("PictureBox2.Image");
		this.PictureBox2.Location = new System.Drawing.Point(349, 55);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(19, 20);
		this.PictureBox2.TabIndex = 28;
		this.PictureBox2.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox2, resources.GetString("PictureBox2.ToolTip"));
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(349, 20);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(19, 20);
		this.PictureBox1.TabIndex = 27;
		this.PictureBox1.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox1, resources.GetString("PictureBox1.ToolTip"));
		this.ToolTip1.AutoPopDelay = 15000;
		this.ToolTip1.InitialDelay = 200;
		this.ToolTip1.ReshowDelay = 100;
		this.Button1.Enabled = false;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(714, 300);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(52, 23);
		this.Button1.TabIndex = 27;
		this.Button1.Text = "OK";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(12, 300);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(52, 23);
		this.Button2.TabIndex = 28;
		this.Button2.Text = "Cancel";
		this.Button2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(774, 329);
		base.ControlBox = false;
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "frmCreateEditProfile";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Create/Edit Profile";
		base.TopMost = true;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		base.ResumeLayout(false);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(TextDisplayName.Text, null, TextCompare: false) == 0)
		{
			return;
		}
		MyProject.Forms.frmProfiles.TopMost = true;
		checked
		{
			if (Operators.CompareString(TextDisplayName.Text, "- All Games & Apps -", TextCompare: false) != 0)
			{
				pLaunchfile = Path.GetFileName(TextBoxPath.Text);
				pPath = TextBoxPath.Text;
				OTTDB.AddProfile(TextDisplayName.Text, ComboASW.Text, ComboSS.Text, ComboCPU.Text, pLaunchfile, pPath, ComboMethod.Text, NumericUpDown1.Value.ToString(), NumericUpDown2.Value.ToString(), ComboMirror.SelectedIndex.ToString(), ComboAGPS.SelectedIndex.ToString(), TextBoxComment.Text, NumericUpDown3.Value + " " + NumericUpDown4.Value, ComboBox8.Text, ComboBox9.Text, ComboBoxEnabled.Text);
			}
			else
			{
				Cursor = Cursors.WaitCursor;
				int num = ComboBox1.Items.Count - 1;
				for (int i = 1; i <= num; i++)
				{
					GameItem gameItem = (GameItem)ComboBox1.Items[i];
					TextBoxPath.Text = gameItem.info;
					TextDisplayName.Text = gameItem.Name;
					pLaunchfile = Path.GetFileName(TextBoxPath.Text);
					pPath = TextBoxPath.Text;
					OTTDB.AddProfile(TextDisplayName.Text, ComboASW.Text, ComboSS.Text, ComboCPU.Text, pLaunchfile, pPath, ComboMethod.Text, NumericUpDown1.Value.ToString(), NumericUpDown2.Value.ToString(), ComboMirror.SelectedIndex.ToString(), ComboAGPS.SelectedIndex.ToString(), TextBoxComment.Text, NumericUpDown3.Value + " " + NumericUpDown4.Value, ComboBox8.Text, ComboBox9.Text, ComboBoxEnabled.Text);
				}
				Cursor = Cursors.Default;
			}
			OTTDB.GetProfiles();
			if (MyProject.Forms.FrmMain.HomeIsRunning | MySettingsProperty.Settings.StartAppwatcherOnStart)
			{
				if (OTTDB.numWMI > 0)
				{
					MyProject.Forms.FrmMain.CreateWatcher();
				}
				if (OTTDB.numTimer > 0)
				{
					MyProject.Forms.FrmMain.pTimer.Start();
				}
			}
			ComboBox1.Items.Remove(RuntimeHelpers.GetObjectValue(ComboBox1.SelectedItem));
			ComboBox1.Text = "- Select Game -";
			ComboSS.SelectedIndex = 0;
			ComboASW.SelectedIndex = 0;
			ComboCPU.SelectedIndex = 0;
			ComboMethod.SelectedIndex = 0;
			NumericUpDown1.Value = 5m;
			NumericUpDown2.Value = 5m;
			TextBoxPath.Text = "";
			TextDisplayName.Text = "";
			ComboMirror.SelectedIndex = 0;
			ComboAGPS.SelectedIndex = 1;
			NumericUpDown3.Value = 0m;
			NumericUpDown4.Value = 0m;
			ComboBoxEnabled.Text = "Yes";
			Close();
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		CreateCancel = true;
		ComboBox1.Text = "- Select Game -";
		ComboSS.SelectedIndex = 0;
		ComboASW.SelectedIndex = 0;
		ComboCPU.SelectedIndex = 0;
		ComboMethod.SelectedIndex = 0;
		NumericUpDown1.Value = 5m;
		NumericUpDown2.Value = 5m;
		TextBoxPath.Text = "";
		TextDisplayName.Text = "";
		ComboAGPS.SelectedIndex = 1;
		NumericUpDown3.Value = 0m;
		NumericUpDown4.Value = 0m;
		ComboBoxEnabled.Text = "Yes";
		Close();
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "Browse...";
		if (Operators.CompareString(TextBoxPath.Text, "", TextCompare: false) != 0)
		{
			if (Directory.Exists(Path.GetDirectoryName(TextBoxPath.Text)))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(TextBoxPath.Text);
			}
		}
		else
		{
			openFileDialog.InitialDirectory = MyProject.Forms.FrmMain.OculusPath;
		}
		openFileDialog.Filter = "Executable files (*.exe)|*.exe";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			TextDisplayName.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
			TextDisplayName.Visible = true;
			ComboBox1.Visible = false;
			TextBoxPath.Text = openFileDialog.FileName;
			Button1.Enabled = true;
		}
	}

	private void CreateEditProfile_Load(object sender, EventArgs e)
	{
		ToolTip1.SetToolTip(PictureBox2, "Sets the level of Super Sampling, or Pixel Density, to apply to the app when it is started.\r\nThis value acts as a multiplier, it is not the definitive value the app will get.\r\nThat depends on what the native Pixeld Density the app runs att.\r\nUse the Pixel Density Visual HUD to check what you actually get, and adjust this value to get the desired result.");
		ToolTip1.SetToolTip(PictureBox3, "Sets the mode for Asynchronous Space Warp (ASW).\r\nThis should usualy be set to Auto unless you experience issues.");
		ToolTip1.SetToolTip(PictureBox4, "Makes Windows give this app a bit higher priority over other system resources.\r\n Can improve performance.");
		ToolTip1.SetToolTip(PictureBox5, "Determines how OTT should detect this app. WMI is default and has less impact on CPU performace\r\nbut is less accurate in detecting games starts. Might not work for every game.\r\nThe Timer method consumes more CPU bit is a lot more accurate.\r\nUse Timer for the apps that do not work with WMI.");
		ToolTip1.SetToolTip(PictureBox8, "The path to the executable that OTT should monitor. This is usally correct and should in most\r\ncases not be touched. But in some cases it might be neccessary to modify this\r\nso OTT detects the right process.");
		ToolTip1.SetToolTip(PictureBox11, "Setting this to a value lower than 1, for example 0.8, will cause a lower FOV in the headset which\r\nwill increase the FPS due to less pixels being drawn.\r\nUsing a value higher than 1 will only affect the Mirror view on your desktop.");
	}

	private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(ComboBox1.SelectedItem.ToString(), "- All Games & Apps -", TextCompare: false) != 0)
		{
			GameItem gameItem = (GameItem)ComboBox1.SelectedItem;
			TextBoxPath.Text = gameItem.info;
			TextDisplayName.Text = gameItem.Name;
		}
		else
		{
			TextDisplayName.Text = "- All Games & Apps -";
		}
		Button1.Enabled = true;
	}

	private void ComboBox1_TextChanged(object sender, EventArgs e)
	{
		TextDisplayName.Text = ComboBox1.Text;
	}

	private void ComboSS_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '.') & (Convert.ToInt32(e.KeyChar) != 8))
		{
			if (e.KeyChar == Conversions.ToChar(DSep))
			{
				e.Handled = true;
			}
			else
			{
				e.Handled = true;
			}
		}
	}
}
