using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmEditAllSelected : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboSS")]
	private ComboBox _ComboSS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
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

	[field: AccessedThroughProperty("PictureBox9")]
	internal virtual PictureBox PictureBox9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	[field: AccessedThroughProperty("ComboMethod")]
	internal virtual ComboBox ComboMethod
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboCPU")]
	internal virtual ComboBox ComboCPU
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

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	[field: AccessedThroughProperty("PictureBox11")]
	internal virtual PictureBox PictureBox11
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

	[field: AccessedThroughProperty("Label12")]
	internal virtual Label Label12
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

	public frmEditAllSelected()
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmEditAllSelected));
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
		this.PictureBox10 = new System.Windows.Forms.PictureBox();
		this.ComboAGPS = new System.Windows.Forms.ComboBox();
		this.Label10 = new System.Windows.Forms.Label();
		this.PictureBox9 = new System.Windows.Forms.PictureBox();
		this.ComboMirror = new System.Windows.Forms.ComboBox();
		this.Label9 = new System.Windows.Forms.Label();
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
		this.ComboMethod = new System.Windows.Forms.ComboBox();
		this.ComboASW = new System.Windows.Forms.ComboBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.ComboCPU = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.ComboSS = new System.Windows.Forms.ComboBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button1 = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
		base.SuspendLayout();
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
		this.GroupBox1.Controls.Add(this.PictureBox10);
		this.GroupBox1.Controls.Add(this.ComboAGPS);
		this.GroupBox1.Controls.Add(this.Label10);
		this.GroupBox1.Controls.Add(this.PictureBox9);
		this.GroupBox1.Controls.Add(this.ComboMirror);
		this.GroupBox1.Controls.Add(this.Label9);
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
		this.GroupBox1.Controls.Add(this.ComboMethod);
		this.GroupBox1.Controls.Add(this.ComboASW);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.ComboCPU);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.ComboSS);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Location = new System.Drawing.Point(15, 36);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(738, 238);
		this.GroupBox1.TabIndex = 27;
		this.GroupBox1.TabStop = false;
		this.ComboBoxEnabled.FormattingEnabled = true;
		this.ComboBoxEnabled.Items.AddRange(new object[2] { "Yes", "No" });
		this.ComboBoxEnabled.Location = new System.Drawing.Point(517, 202);
		this.ComboBoxEnabled.Name = "ComboBoxEnabled";
		this.ComboBoxEnabled.Size = new System.Drawing.Size(172, 21);
		this.ComboBoxEnabled.TabIndex = 73;
		this.Label15.AutoSize = true;
		this.Label15.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label15.Location = new System.Drawing.Point(382, 205);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(49, 13);
		this.Label15.TabIndex = 72;
		this.Label15.Text = "Enabled:";
		this.Label33.AutoSize = true;
		this.Label33.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label33.Location = new System.Drawing.Point(382, 99);
		this.Label33.Name = "Label33";
		this.Label33.Size = new System.Drawing.Size(129, 13);
		this.Label33.TabIndex = 68;
		this.Label33.Text = "Force MipMap On Layers:";
		this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ComboBox8.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox8.FormattingEnabled = true;
		this.ComboBox8.Items.AddRange(new object[2] { "True", "False" });
		this.ComboBox8.Location = new System.Drawing.Point(517, 94);
		this.ComboBox8.Name = "ComboBox8";
		this.ComboBox8.Size = new System.Drawing.Size(173, 24);
		this.ComboBox8.TabIndex = 69;
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
		this.ComboBox9.Location = new System.Drawing.Point(517, 127);
		this.ComboBox9.Name = "ComboBox9";
		this.ComboBox9.Size = new System.Drawing.Size(173, 24);
		this.ComboBox9.TabIndex = 71;
		this.Label37.AutoSize = true;
		this.Label37.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label37.Location = new System.Drawing.Point(381, 132);
		this.Label37.Name = "Label37";
		this.Label37.Size = new System.Drawing.Size(130, 13);
		this.Label37.TabIndex = 70;
		this.Label37.Text = "Offset MipMap On Layers:";
		this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.PictureBox11.Image = (System.Drawing.Image)resources.GetObject("PictureBox11.Image");
		this.PictureBox11.Location = new System.Drawing.Point(702, 60);
		this.PictureBox11.Name = "PictureBox11";
		this.PictureBox11.Size = new System.Drawing.Size(19, 20);
		this.PictureBox11.TabIndex = 67;
		this.PictureBox11.TabStop = false;
		this.NumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumericUpDown3.DecimalPlaces = 2;
		this.NumericUpDown3.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		this.NumericUpDown3.Location = new System.Drawing.Point(528, 60);
		this.NumericUpDown3.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.NumericUpDown3.Name = "NumericUpDown3";
		this.NumericUpDown3.Size = new System.Drawing.Size(45, 20);
		this.NumericUpDown3.TabIndex = 66;
		this.NumericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumericUpDown4.DecimalPlaces = 2;
		this.NumericUpDown4.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		this.NumericUpDown4.Location = new System.Drawing.Point(645, 60);
		this.NumericUpDown4.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.NumericUpDown4.Name = "NumericUpDown4";
		this.NumericUpDown4.Size = new System.Drawing.Size(45, 20);
		this.NumericUpDown4.TabIndex = 65;
		this.Label14.AutoSize = true;
		this.Label14.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label14.Location = new System.Drawing.Point(597, 62);
		this.Label14.Name = "Label14";
		this.Label14.Size = new System.Drawing.Size(42, 13);
		this.Label14.TabIndex = 64;
		this.Label14.Text = "Vertical";
		this.Label13.AutoSize = true;
		this.Label13.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label13.Location = new System.Drawing.Point(469, 62);
		this.Label13.Name = "Label13";
		this.Label13.Size = new System.Drawing.Size(54, 13);
		this.Label13.TabIndex = 63;
		this.Label13.Text = "Horizontal";
		this.Label12.AutoSize = true;
		this.Label12.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label12.Location = new System.Drawing.Point(382, 62);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(73, 13);
		this.Label12.TabIndex = 62;
		this.Label12.Text = "FoV Multiplier:";
		this.TextBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBoxComment.Location = new System.Drawing.Point(517, 166);
		this.TextBoxComment.Name = "TextBoxComment";
		this.TextBoxComment.Size = new System.Drawing.Size(172, 21);
		this.TextBoxComment.TabIndex = 54;
		this.Label11.AutoSize = true;
		this.Label11.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label11.Location = new System.Drawing.Point(381, 171);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(54, 13);
		this.Label11.TabIndex = 55;
		this.Label11.Text = "Comment:";
		this.PictureBox10.Image = (System.Drawing.Image)resources.GetObject("PictureBox10.Image");
		this.PictureBox10.Location = new System.Drawing.Point(702, 22);
		this.PictureBox10.Name = "PictureBox10";
		this.PictureBox10.Size = new System.Drawing.Size(19, 20);
		this.PictureBox10.TabIndex = 46;
		this.PictureBox10.TabStop = false;
		this.ComboAGPS.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboAGPS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboAGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboAGPS.FormattingEnabled = true;
		this.ComboAGPS.Items.AddRange(new object[2] { "Off", "On" });
		this.ComboAGPS.Location = new System.Drawing.Point(472, 19);
		this.ComboAGPS.Name = "ComboAGPS";
		this.ComboAGPS.Size = new System.Drawing.Size(218, 23);
		this.ComboAGPS.TabIndex = 45;
		this.Label10.AutoSize = true;
		this.Label10.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label10.Location = new System.Drawing.Point(382, 24);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(71, 13);
		this.Label10.TabIndex = 44;
		this.Label10.Text = "GPU Scaling:";
		this.PictureBox9.Image = (System.Drawing.Image)resources.GetObject("PictureBox9.Image");
		this.PictureBox9.Location = new System.Drawing.Point(334, 208);
		this.PictureBox9.Name = "PictureBox9";
		this.PictureBox9.Size = new System.Drawing.Size(19, 20);
		this.PictureBox9.TabIndex = 43;
		this.PictureBox9.TabStop = false;
		this.ComboMirror.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboMirror.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboMirror.FormattingEnabled = true;
		this.ComboMirror.Items.AddRange(new object[3] { "Default", "Minimized", "Forced" });
		this.ComboMirror.Location = new System.Drawing.Point(104, 205);
		this.ComboMirror.Name = "ComboMirror";
		this.ComboMirror.Size = new System.Drawing.Size(218, 23);
		this.ComboMirror.TabIndex = 42;
		this.Label9.AutoSize = true;
		this.Label9.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label9.Location = new System.Drawing.Point(14, 210);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(73, 13);
		this.Label9.TabIndex = 41;
		this.Label9.Text = "Screen Mirror:";
		this.NumericUpDown2.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.NumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.NumericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.NumericUpDown2.Location = new System.Drawing.Point(104, 140);
		this.NumericUpDown2.Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		this.NumericUpDown2.Name = "NumericUpDown2";
		this.NumericUpDown2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.NumericUpDown2.Size = new System.Drawing.Size(219, 18);
		this.NumericUpDown2.TabIndex = 35;
		this.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.NumericUpDown2.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
		this.PictureBox7.Image = (System.Drawing.Image)resources.GetObject("PictureBox7.Image");
		this.PictureBox7.Location = new System.Drawing.Point(334, 138);
		this.PictureBox7.Name = "PictureBox7";
		this.PictureBox7.Size = new System.Drawing.Size(19, 20);
		this.PictureBox7.TabIndex = 37;
		this.PictureBox7.TabStop = false;
		this.Label7.AutoSize = true;
		this.Label7.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label7.Location = new System.Drawing.Point(24, 141);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(56, 13);
		this.Label7.TabIndex = 36;
		this.Label7.Text = "Set Delay:";
		this.NumericUpDown1.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.NumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.NumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.NumericUpDown1.Location = new System.Drawing.Point(104, 77);
		this.NumericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		this.NumericUpDown1.Name = "NumericUpDown1";
		this.NumericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.NumericUpDown1.Size = new System.Drawing.Size(219, 18);
		this.NumericUpDown1.TabIndex = 29;
		this.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.NumericUpDown1.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
		this.PictureBox6.Image = (System.Drawing.Image)resources.GetObject("PictureBox6.Image");
		this.PictureBox6.Location = new System.Drawing.Point(334, 78);
		this.PictureBox6.Name = "PictureBox6";
		this.PictureBox6.Size = new System.Drawing.Size(19, 20);
		this.PictureBox6.TabIndex = 34;
		this.PictureBox6.TabStop = false;
		this.Label6.AutoSize = true;
		this.Label6.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label6.Location = new System.Drawing.Point(24, 78);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(56, 13);
		this.Label6.TabIndex = 33;
		this.Label6.Text = "Set Delay:";
		this.PictureBox5.Image = (System.Drawing.Image)resources.GetObject("PictureBox5.Image");
		this.PictureBox5.Location = new System.Drawing.Point(334, 176);
		this.PictureBox5.Name = "PictureBox5";
		this.PictureBox5.Size = new System.Drawing.Size(19, 20);
		this.PictureBox5.TabIndex = 31;
		this.PictureBox5.TabStop = false;
		this.PictureBox4.Image = (System.Drawing.Image)resources.GetObject("PictureBox4.Image");
		this.PictureBox4.Location = new System.Drawing.Point(334, 111);
		this.PictureBox4.Name = "PictureBox4";
		this.PictureBox4.Size = new System.Drawing.Size(19, 20);
		this.PictureBox4.TabIndex = 30;
		this.PictureBox4.TabStop = false;
		this.PictureBox3.Image = (System.Drawing.Image)resources.GetObject("PictureBox3.Image");
		this.PictureBox3.Location = new System.Drawing.Point(334, 51);
		this.PictureBox3.Name = "PictureBox3";
		this.PictureBox3.Size = new System.Drawing.Size(19, 20);
		this.PictureBox3.TabIndex = 29;
		this.PictureBox3.TabStop = false;
		this.PictureBox2.Image = (System.Drawing.Image)resources.GetObject("PictureBox2.Image");
		this.PictureBox2.Location = new System.Drawing.Point(334, 19);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(19, 20);
		this.PictureBox2.TabIndex = 28;
		this.PictureBox2.TabStop = false;
		this.ComboMethod.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboMethod.FormattingEnabled = true;
		this.ComboMethod.Items.AddRange(new object[2] { "WMI", "Timer" });
		this.ComboMethod.Location = new System.Drawing.Point(104, 171);
		this.ComboMethod.Name = "ComboMethod";
		this.ComboMethod.Size = new System.Drawing.Size(218, 23);
		this.ComboMethod.TabIndex = 25;
		this.ComboASW.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboASW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboASW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboASW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboASW.FormattingEnabled = true;
		this.ComboASW.Items.AddRange(new object[7] { "Auto", "Off", "45 Hz", "30 Hz", "18 Hz", "45 Hz forced", "Adaptive" });
		this.ComboASW.Location = new System.Drawing.Point(104, 48);
		this.ComboASW.Name = "ComboASW";
		this.ComboASW.Size = new System.Drawing.Size(218, 23);
		this.ComboASW.TabIndex = 16;
		this.Label5.AutoSize = true;
		this.Label5.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label5.Location = new System.Drawing.Point(15, 181);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(56, 13);
		this.Label5.TabIndex = 24;
		this.Label5.Text = "Detection:";
		this.ComboCPU.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboCPU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboCPU.FormattingEnabled = true;
		this.ComboCPU.Items.AddRange(new object[4] { "Default", "Normal", "Above Normal", "High" });
		this.ComboCPU.Location = new System.Drawing.Point(104, 111);
		this.ComboCPU.Name = "ComboCPU";
		this.ComboCPU.Size = new System.Drawing.Size(218, 23);
		this.ComboCPU.TabIndex = 18;
		this.Label4.AutoSize = true;
		this.Label4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label4.Location = new System.Drawing.Point(14, 116);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(66, 13);
		this.Label4.TabIndex = 22;
		this.Label4.Text = "CPU Priority:";
		this.ComboSS.BackColor = System.Drawing.SystemColors.InactiveBorder;
		this.ComboSS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboSS.FormattingEnabled = true;
		this.ComboSS.Items.AddRange(new object[20]
		{
			"0.7", "0.8", "0.9", "0", "1.0", "1.1", "1.2", "1.3", "1.4", "1.5",
			"1.6", "1.7", "1.8", "1.9", "2.0", "2.1", "2.2", "2.3", "2.4", "2.5"
		});
		this.ComboSS.Location = new System.Drawing.Point(104, 19);
		this.ComboSS.Name = "ComboSS";
		this.ComboSS.Size = new System.Drawing.Size(218, 23);
		this.ComboSS.TabIndex = 15;
		this.Label3.AutoSize = true;
		this.Label3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label3.Location = new System.Drawing.Point(15, 53);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(65, 13);
		this.Label3.TabIndex = 21;
		this.Label3.Text = "ASW Mode:";
		this.Label2.AutoSize = true;
		this.Label2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label2.Location = new System.Drawing.Point(14, 25);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(84, 13);
		this.Label2.TabIndex = 20;
		this.Label2.Text = "Super Sampling:";
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(15, 280);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(52, 23);
		this.Button2.TabIndex = 30;
		this.Button2.Text = "Cancel";
		this.Button2.UseVisualStyleBackColor = true;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(698, 280);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(55, 23);
		this.Button1.TabIndex = 29;
		this.Button1.Text = "Update";
		this.Button1.UseVisualStyleBackColor = true;
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label1.Location = new System.Drawing.Point(12, 9);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(295, 15);
		this.Label1.TabIndex = 31;
		this.Label1.Text = "Leave any value that you do not want to update blank.";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(765, 312);
		base.ControlBox = false;
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "frmEditAllSelected";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Edit All Selected";
		base.TopMost = true;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		try
		{
			foreach (ListViewItem checkedItem in MyProject.Forms.frmProfiles.ListView1.CheckedItems)
			{
				string[] array = Strings.Split(Conversions.ToString(checkedItem.Tag), ",");
				string displayname = array[0];
				string ppdp = array[1];
				string asw = array[2];
				string priority = array[4];
				string method = array[3];
				string path = array[5];
				string aswdelay = array[6];
				string cpudelay = array[7];
				string text = array[8];
				if (Operators.CompareString(text, "Default", TextCompare: false) == 0)
				{
					text = "0";
				}
				if (Operators.CompareString(text, "Minimized", TextCompare: false) == 0)
				{
					text = "1";
				}
				if (Operators.CompareString(text, "Forced", TextCompare: false) == 0)
				{
					text = "2";
				}
				string text2 = array[9];
				if (Operators.CompareString(text2, "On", TextCompare: false) == 0)
				{
					text2 = Conversions.ToString(1);
				}
				if (Operators.CompareString(text2, "Off", TextCompare: false) == 0)
				{
					text2 = Conversions.ToString(0);
				}
				string comment = array[10];
				string text3 = array[11];
				string text4 = array[12];
				string text5 = array[13];
				string text6 = array[14];
				if (Operators.CompareString(ComboSS.Text, "", TextCompare: false) != 0)
				{
					ppdp = ComboSS.Text;
				}
				if (Operators.CompareString(ComboASW.Text, "", TextCompare: false) != 0)
				{
					asw = ComboASW.Text;
				}
				if (Operators.CompareString(NumericUpDown1.Text, "", TextCompare: false) != 0)
				{
					aswdelay = NumericUpDown1.Value.ToString();
				}
				if (Operators.CompareString(ComboCPU.Text, "", TextCompare: false) != 0)
				{
					priority = ComboCPU.Text;
				}
				if (Operators.CompareString(NumericUpDown2.Text, "", TextCompare: false) != 0)
				{
					cpudelay = NumericUpDown2.Value.ToString();
				}
				if (Operators.CompareString(ComboMethod.Text, "", TextCompare: false) != 0)
				{
					method = ComboMethod.Text;
				}
				if (Operators.CompareString(ComboMirror.Text, "", TextCompare: false) != 0)
				{
					text = ComboMirror.SelectedIndex.ToString();
				}
				if (Operators.CompareString(ComboAGPS.Text, "", TextCompare: false) != 0)
				{
					text2 = ComboAGPS.SelectedIndex.ToString();
				}
				if (Operators.CompareString(TextBoxComment.Text, "", TextCompare: false) != 0)
				{
					comment = TextBoxComment.Text;
				}
				OTTDB.AddProfile(displayname, asw, ppdp, priority, Path.GetFileName(path), path, method, aswdelay, cpudelay, text, text2, comment, NumericUpDown3.Value + " " + NumericUpDown4.Value, ComboBox8.Text, ComboBox9.Text, ComboBoxEnabled.Text);
			}
			OTTDB.GetProfiles();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Update all selected profiles: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		Cursor = Cursors.Default;
		Close();
	}

	private void ComboSS_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '.') & (Convert.ToInt32(e.KeyChar) != 8))
		{
			object value = default(object);
			if (e.KeyChar == Conversions.ToChar(value))
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
