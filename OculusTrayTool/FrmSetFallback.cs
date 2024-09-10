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

namespace OculusTrayTool;

[DesignerGenerated]
public class FrmSetFallback : Form
{
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
	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	public Dictionary<string, string> ComboAudioFallbackSource;

	public Dictionary<string, string> ComboMicFallbackSource;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboMicFallback")]
	internal virtual ComboBox ComboMicFallback
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboAudioFallback")]
	internal virtual ComboBox ComboAudioFallback
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
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

	internal virtual ComboBox ComboBox2
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboBox2_SelectedIndexChanged;
			ComboBox comboBox = _ComboBox2;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			_ComboBox2 = value;
			comboBox = _ComboBox2;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
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

	[field: AccessedThroughProperty("ComboCommFallback")]
	internal virtual ComboBox ComboCommFallback
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

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3
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

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboCommMicFallback")]
	internal virtual ComboBox ComboCommMicFallback
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

	[field: AccessedThroughProperty("ComboBox3")]
	internal virtual ComboBox ComboBox3
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

	[field: AccessedThroughProperty("ComboBox4")]
	internal virtual ComboBox ComboBox4
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

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual GroupBox GroupBox4
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

	[field: AccessedThroughProperty("ComboBox5")]
	internal virtual ComboBox ComboBox5
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

	public FrmSetFallback()
	{
		base.Load += SetFallback_Load;
		ComboAudioFallbackSource = new Dictionary<string, string>();
		ComboMicFallbackSource = new Dictionary<string, string>();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.FrmSetFallback));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ComboBox3 = new System.Windows.Forms.ComboBox();
		this.Label8 = new System.Windows.Forms.Label();
		this.ComboBox4 = new System.Windows.Forms.ComboBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.Label10 = new System.Windows.Forms.Label();
		this.ComboBox5 = new System.Windows.Forms.ComboBox();
		this.ComboBox6 = new System.Windows.Forms.ComboBox();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.ComboCommMicFallback = new System.Windows.Forms.ComboBox();
		this.Label7 = new System.Windows.Forms.Label();
		this.ComboCommFallback = new System.Windows.Forms.ComboBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.ComboMicFallback = new System.Windows.Forms.ComboBox();
		this.ComboAudioFallback = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Controls.Add(this.ComboBox3);
		this.GroupBox1.Controls.Add(this.Label8);
		this.GroupBox1.Controls.Add(this.ComboBox4);
		this.GroupBox1.Controls.Add(this.Label9);
		this.GroupBox1.Controls.Add(this.GroupBox4);
		this.GroupBox1.Controls.Add(this.GroupBox5);
		this.GroupBox1.Controls.Add(this.Label10);
		this.GroupBox1.Controls.Add(this.ComboBox5);
		this.GroupBox1.Controls.Add(this.ComboBox6);
		this.GroupBox1.Controls.Add(this.Label11);
		this.GroupBox1.Controls.Add(this.Label12);
		this.GroupBox1.Controls.Add(this.ComboCommMicFallback);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.ComboCommFallback);
		this.GroupBox1.Controls.Add(this.Label6);
		this.GroupBox1.Controls.Add(this.GroupBox3);
		this.GroupBox1.Controls.Add(this.GroupBox2);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.ComboBox1);
		this.GroupBox1.Controls.Add(this.ComboBox2);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.ComboMicFallback);
		this.GroupBox1.Controls.Add(this.ComboAudioFallback);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(409, 418);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Set when Audio/Mic devices should switch";
		this.ComboBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox3.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox3.FormattingEnabled = true;
		this.ComboBox3.Location = new System.Drawing.Point(157, 224);
		this.ComboBox3.Name = "ComboBox3";
		this.ComboBox3.Size = new System.Drawing.Size(239, 23);
		this.ComboBox3.TabIndex = 29;
		this.Label8.AutoSize = true;
		this.Label8.Location = new System.Drawing.Point(23, 227);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(117, 15);
		this.Label8.TabIndex = 28;
		this.Label8.Text = "Mic Communication";
		this.ComboBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox4.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox4.FormattingEnabled = true;
		this.ComboBox4.Location = new System.Drawing.Point(157, 195);
		this.ComboBox4.Name = "ComboBox4";
		this.ComboBox4.Size = new System.Drawing.Size(239, 23);
		this.ComboBox4.TabIndex = 27;
		this.Label9.AutoSize = true;
		this.Label9.Location = new System.Drawing.Point(23, 198);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(128, 15);
		this.Label9.TabIndex = 26;
		this.Label9.Text = "Audio Communication";
		this.GroupBox4.Location = new System.Drawing.Point(6, 111);
		this.GroupBox4.Name = "GroupBox4";
		this.GroupBox4.Size = new System.Drawing.Size(26, 10);
		this.GroupBox4.TabIndex = 25;
		this.GroupBox4.TabStop = false;
		this.GroupBox5.Location = new System.Drawing.Point(253, 113);
		this.GroupBox5.Name = "GroupBox5";
		this.GroupBox5.Size = new System.Drawing.Size(145, 10);
		this.GroupBox5.TabIndex = 24;
		this.GroupBox5.TabStop = false;
		this.Label10.AutoSize = true;
		this.Label10.Location = new System.Drawing.Point(38, 109);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(209, 15);
		this.Label10.TabIndex = 23;
		this.Label10.Text = "On Start/Load switch to these devices";
		this.ComboBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox5.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox5.FormattingEnabled = true;
		this.ComboBox5.Location = new System.Drawing.Point(157, 166);
		this.ComboBox5.Name = "ComboBox5";
		this.ComboBox5.Size = new System.Drawing.Size(239, 23);
		this.ComboBox5.TabIndex = 22;
		this.ComboBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox6.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox6.FormattingEnabled = true;
		this.ComboBox6.Location = new System.Drawing.Point(157, 137);
		this.ComboBox6.Name = "ComboBox6";
		this.ComboBox6.Size = new System.Drawing.Size(240, 23);
		this.ComboBox6.TabIndex = 21;
		this.Label11.AutoSize = true;
		this.Label11.Location = new System.Drawing.Point(23, 169);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(73, 15);
		this.Label11.TabIndex = 20;
		this.Label11.Text = "Microphone";
		this.Label12.AutoSize = true;
		this.Label12.Location = new System.Drawing.Point(26, 142);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(38, 15);
		this.Label12.TabIndex = 19;
		this.Label12.Text = "Audio";
		this.ComboCommMicFallback.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboCommMicFallback.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboCommMicFallback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboCommMicFallback.FormattingEnabled = true;
		this.ComboCommMicFallback.Items.AddRange(new object[1] { " " });
		this.ComboCommMicFallback.Location = new System.Drawing.Point(157, 375);
		this.ComboCommMicFallback.Name = "ComboCommMicFallback";
		this.ComboCommMicFallback.Size = new System.Drawing.Size(239, 23);
		this.ComboCommMicFallback.TabIndex = 18;
		this.Label7.AutoSize = true;
		this.Label7.Location = new System.Drawing.Point(23, 378);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(117, 15);
		this.Label7.TabIndex = 17;
		this.Label7.Text = "Mic Communication";
		this.ComboCommFallback.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboCommFallback.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboCommFallback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboCommFallback.FormattingEnabled = true;
		this.ComboCommFallback.Location = new System.Drawing.Point(157, 346);
		this.ComboCommFallback.Name = "ComboCommFallback";
		this.ComboCommFallback.Size = new System.Drawing.Size(239, 23);
		this.ComboCommFallback.TabIndex = 16;
		this.Label6.AutoSize = true;
		this.Label6.Location = new System.Drawing.Point(23, 349);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(128, 15);
		this.Label6.TabIndex = 15;
		this.Label6.Text = "Audio Communication";
		this.GroupBox3.Location = new System.Drawing.Point(6, 262);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(26, 10);
		this.GroupBox3.TabIndex = 14;
		this.GroupBox3.TabStop = false;
		this.GroupBox2.Location = new System.Drawing.Point(217, 264);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(181, 10);
		this.GroupBox2.TabIndex = 13;
		this.GroupBox2.TabStop = false;
		this.Label5.AutoSize = true;
		this.Label5.Location = new System.Drawing.Point(38, 260);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(173, 15);
		this.Label5.TabIndex = 12;
		this.Label5.Text = "On Exit switch to these devices";
		this.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox1.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox1.FormattingEnabled = true;
		this.ComboBox1.Items.AddRange(new object[5] { "When Oculus Home starts/exits", "When Oculus Tray Tool starts/exits", "When a Profile loads/exits", "Never", "When SteamVR starts/exits" });
		this.ComboBox1.Location = new System.Drawing.Point(143, 34);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(253, 23);
		this.ComboBox1.TabIndex = 8;
		this.ComboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboBox2.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboBox2.FormattingEnabled = true;
		this.ComboBox2.Items.AddRange(new object[5] { "When Oculus Home starts/exits", "When Oculus Tray Tool starts/exits", "When a Profile loads/exits", "Never", "When SteamVR starts/exits" });
		this.ComboBox2.Location = new System.Drawing.Point(143, 63);
		this.ComboBox2.Name = "ComboBox2";
		this.ComboBox2.Size = new System.Drawing.Size(253, 23);
		this.ComboBox2.TabIndex = 9;
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(23, 63);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(112, 15);
		this.Label4.TabIndex = 7;
		this.Label4.Text = "Switch Microphone";
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(23, 34);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(77, 15);
		this.Label3.TabIndex = 6;
		this.Label3.Text = "Switch Audio";
		this.ComboMicFallback.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboMicFallback.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboMicFallback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMicFallback.FormattingEnabled = true;
		this.ComboMicFallback.Location = new System.Drawing.Point(157, 317);
		this.ComboMicFallback.Name = "ComboMicFallback";
		this.ComboMicFallback.Size = new System.Drawing.Size(239, 23);
		this.ComboMicFallback.TabIndex = 3;
		this.ComboAudioFallback.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboAudioFallback.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboAudioFallback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboAudioFallback.FormattingEnabled = true;
		this.ComboAudioFallback.Location = new System.Drawing.Point(157, 288);
		this.ComboAudioFallback.Name = "ComboAudioFallback";
		this.ComboAudioFallback.Size = new System.Drawing.Size(240, 23);
		this.ComboAudioFallback.TabIndex = 2;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(23, 320);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(73, 15);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Microphone";
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(26, 293);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(38, 15);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Audio";
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(366, 436);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(55, 25);
		this.Button1.TabIndex = 1;
		this.Button1.Text = "OK";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(12, 436);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(55, 25);
		this.Button2.TabIndex = 2;
		this.Button2.Text = "Reset";
		this.Button2.UseVisualStyleBackColor = true;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button3.Location = new System.Drawing.Point(306, 436);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(55, 25);
		this.Button3.TabIndex = 3;
		this.Button3.Text = "Cancel";
		this.Button3.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(433, 471);
		base.Controls.Add(this.Button3);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(449, 510);
		base.Name = "FrmSetFallback";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Audio Swicher";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (ComboBox6.SelectedItem != null)
			{
				if (Operators.CompareString(ComboBox6.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetAudioOnStart = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
					MySettingsProperty.Settings.SetAudioOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart.ToString() + "' as current default audio device (on startup)");
				}
				else
				{
					string key = ((KeyValuePair<string, string>)ComboBox6.SelectedItem).Key;
					string value = ((KeyValuePair<string, string>)ComboBox6.SelectedItem).Value;
					MySettingsProperty.Settings.SetAudioOnStart = value;
					MySettingsProperty.Settings.SetAudioOnStartGuid = key;
				}
			}
			if (ComboAudioFallback.SelectedItem != null)
			{
				if (Operators.CompareString(ComboAudioFallback.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DefaultAudio = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
					MySettingsProperty.Settings.SystemDefaultAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultAudio + "' as current default audio device (on exit)");
				}
				else
				{
					string key2 = ((KeyValuePair<string, string>)ComboAudioFallback.SelectedItem).Key;
					string value2 = ((KeyValuePair<string, string>)ComboAudioFallback.SelectedItem).Value;
					MySettingsProperty.Settings.DefaultAudio = value2;
					MySettingsProperty.Settings.SystemDefaultAudioGuid = key2;
				}
			}
			if (ComboBox5.SelectedItem != null)
			{
				if (Operators.CompareString(ComboBox5.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetMicOnStart = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
					MySettingsProperty.Settings.SetMicOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetMicOnStart + "' as current default mic device (on startup)");
				}
				else
				{
					string key3 = ((KeyValuePair<string, string>)ComboBox5.SelectedItem).Key;
					string value3 = ((KeyValuePair<string, string>)ComboBox5.SelectedItem).Value;
					MySettingsProperty.Settings.SetMicOnStart = value3;
					MySettingsProperty.Settings.SetMicOnStartGuid = key3;
				}
			}
			if (ComboMicFallback.SelectedItem != null)
			{
				if (Operators.CompareString(ComboMicFallback.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DefaultMic = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
					MySettingsProperty.Settings.SystemDefaultMicGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultMic + "' as current default mic device (on exit)");
				}
				else
				{
					string key4 = ((KeyValuePair<string, string>)ComboMicFallback.SelectedItem).Key;
					string value4 = ((KeyValuePair<string, string>)ComboMicFallback.SelectedItem).Value;
					MySettingsProperty.Settings.DefaultMic = value4;
					MySettingsProperty.Settings.SystemDefaultMicGuid = key4;
				}
			}
			if (ComboBox4.SelectedItem != null)
			{
				if (Operators.CompareString(ComboBox4.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetAudioCommOnStart = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
					MySettingsProperty.Settings.SetAudioCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioCommOnStart + "' as current default audio comm device (on startup)");
				}
				else
				{
					string key5 = ((KeyValuePair<string, string>)ComboBox4.SelectedItem).Key;
					string value5 = ((KeyValuePair<string, string>)ComboBox4.SelectedItem).Value;
					MySettingsProperty.Settings.SetAudioCommOnStart = value5;
					MySettingsProperty.Settings.SetAudioCommOnStartGuid = key5;
				}
			}
			if (ComboCommFallback.SelectedItem != null)
			{
				if (Operators.CompareString(ComboCommFallback.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DefaultCommAudio = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
					MySettingsProperty.Settings.SystemDefaultCommAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultCommAudio + "' as current default audio comm device (on exit)");
				}
				else
				{
					string key6 = ((KeyValuePair<string, string>)ComboCommFallback.SelectedItem).Key;
					string value6 = ((KeyValuePair<string, string>)ComboCommFallback.SelectedItem).Value;
					MySettingsProperty.Settings.DefaultCommAudio = value6;
					MySettingsProperty.Settings.SystemDefaultCommAudioGuid = key6;
				}
			}
			if (ComboBox3.SelectedItem != null)
			{
				if (Operators.CompareString(ComboBox3.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetMicCommOnStart = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
					MySettingsProperty.Settings.SetMicCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart + "' as current mic comm device (on startup)");
				}
				else
				{
					string key7 = ((KeyValuePair<string, string>)ComboBox3.SelectedItem).Key;
					string value7 = ((KeyValuePair<string, string>)ComboBox3.SelectedItem).Value;
					MySettingsProperty.Settings.SetMicCommOnStart = value7;
					MySettingsProperty.Settings.SetMicCommOnStartGuid = key7;
				}
			}
			if (ComboCommMicFallback.SelectedItem != null)
			{
				if (Operators.CompareString(ComboCommFallback.Text, "Use current default", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DefaultComm = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
					MySettingsProperty.Settings.SystemDefaultCommGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
					Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultComm + "' as current mic comm device (on exit)");
				}
				else
				{
					string key8 = ((KeyValuePair<string, string>)ComboCommMicFallback.SelectedItem).Key;
					string value8 = ((KeyValuePair<string, string>)ComboCommMicFallback.SelectedItem).Value;
					MySettingsProperty.Settings.DefaultComm = value8;
					MySettingsProperty.Settings.SystemDefaultCommGuid = key8;
				}
			}
			MySettingsProperty.Settings.Save();
			if ((Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, null, TextCompare: false) != 0) & (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, null, TextCompare: false) != 0))
			{
				MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = true;
			}
			else
			{
				MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = false;
				MyProject.Forms.FrmMain.ToolStripMenuItem3.ToolTipText = "No fallback devices has been selected in the AudioSwitcher configuration";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Error setting Audio fallback device: " + ex2.Message);
			Interaction.MsgBox("Error setting Audio fallback device: " + ex2.Message, MsgBoxStyle.Critical, "Error");
			ProjectData.ClearProjectError();
		}
		Close();
	}

	private void SetFallback_Load(object sender, EventArgs e)
	{
		GetConfig.IsReading = true;
		ComboBox1.SelectedIndex = MySettingsProperty.Settings.SetRiftAudioDefault;
		ComboBox2.SelectedIndex = MySettingsProperty.Settings.SetRiftMicDefault;
		ComboAudioFallback.Text = MySettingsProperty.Settings.DefaultAudio;
		ComboMicFallback.Text = MySettingsProperty.Settings.DefaultMic;
		ComboCommFallback.Text = MySettingsProperty.Settings.DefaultCommAudio;
		ComboCommMicFallback.Text = MySettingsProperty.Settings.DefaultComm;
		ComboBox3.Text = MySettingsProperty.Settings.SetMicCommOnStart;
		ComboBox4.Text = MySettingsProperty.Settings.SetAudioCommOnStart;
		ComboBox5.Text = MySettingsProperty.Settings.SetMicOnStart;
		ComboBox6.Text = MySettingsProperty.Settings.SetAudioOnStart;
		GetConfig.IsReading = false;
		MyProject.Forms.FrmMain.Cursor = Cursors.Default;
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		Log.WriteToLog("Resetting AudioSwitcher settings..");
		GetConfig.IsReading = true;
		Cursor = Cursors.WaitCursor;
		ComboAudioFallback.Text = "";
		ComboMicFallback.Text = "";
		ComboCommFallback.Text = Conversions.ToString(ComboBox1.SelectedIndex == 0);
		ComboBox2.SelectedIndex = 0;
		GetConfig.IsReading = false;
		MySettingsProperty.Settings.DefaultAudio = null;
		MySettingsProperty.Settings.DefaultMic = null;
		MySettingsProperty.Settings.DefaultComm = null;
		MySettingsProperty.Settings.DefaultCommAudio = null;
		MySettingsProperty.Settings.SystemDefaultAudioGuid = null;
		MySettingsProperty.Settings.SystemDefaultMicGuid = null;
		MySettingsProperty.Settings.SystemDefaultCommGuid = null;
		MySettingsProperty.Settings.RiftMicGuid = null;
		MySettingsProperty.Settings.RiftAudioGuid = null;
		MySettingsProperty.Settings.SetMicCommOnStart = null;
		MySettingsProperty.Settings.SetAudioCommOnStart = null;
		MySettingsProperty.Settings.SetMicOnStart = null;
		MySettingsProperty.Settings.SetAudioOnStart = null;
		MySettingsProperty.Settings.SetMicCommOnStartGuid = null;
		MySettingsProperty.Settings.SetAudioCommOnStartGuid = null;
		MySettingsProperty.Settings.SetMicOnStartGuid = null;
		MySettingsProperty.Settings.SetAudioOnStartGuid = null;
		MySettingsProperty.Settings.SetRiftMicDefault = 0;
		MySettingsProperty.Settings.SetRiftAudioDefault = 0;
		MySettingsProperty.Settings.Save();
		GetDevices.GetAllAudioDevices();
		GetDevices.GetAllMicDevices();
		Cursor = Cursors.Default;
	}

	private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.SetRiftAudioDefault = ComboBox1.SelectedIndex;
			MySettingsProperty.Settings.Save();
		}
	}

	private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!GetConfig.IsReading)
		{
			MySettingsProperty.Settings.SetRiftMicDefault = ComboBox2.SelectedIndex;
			MySettingsProperty.Settings.Save();
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		Close();
	}
}
