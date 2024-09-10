using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmStillRunningToast : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer2")]
	private Timer _Timer2;

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Label2_Click;
			Label label = _Label2;
			if (label != null)
			{
				label.Click -= value2;
			}
			_Label2 = value;
			label = _Label2;
			if (label != null)
			{
				label.Click += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Label1_Click;
			Label label = _Label1;
			if (label != null)
			{
				label.Click -= value2;
			}
			_Label1 = value;
			label = _Label1;
			if (label != null)
			{
				label.Click += value2;
			}
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PictureBox1_Click;
			PictureBox pictureBox = _PictureBox1;
			if (pictureBox != null)
			{
				pictureBox.Click -= value2;
			}
			_PictureBox1 = value;
			pictureBox = _PictureBox1;
			if (pictureBox != null)
			{
				pictureBox.Click += value2;
			}
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Timer1_Tick;
			Timer timer = _Timer1;
			if (timer != null)
			{
				timer.Tick -= value2;
			}
			_Timer1 = value;
			timer = _Timer1;
			if (timer != null)
			{
				timer.Tick += value2;
			}
		}
	}

	internal virtual Timer Timer2
	{
		[CompilerGenerated]
		get
		{
			return _Timer2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Timer2_Tick;
			Timer timer = _Timer2;
			if (timer != null)
			{
				timer.Tick -= value2;
			}
			_Timer2 = value;
			timer = _Timer2;
			if (timer != null)
			{
				timer.Tick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolTip1")]
	internal virtual ToolTip ToolTip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmStillRunningToast()
	{
		base.Click += StillRunningToast_Click;
		base.Load += StillRunningToast_Load;
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
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.Timer1 = new System.Windows.Forms.Timer(this.components);
		this.Timer2 = new System.Windows.Forms.Timer(this.components);
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		base.SuspendLayout();
		this.Label2.AutoSize = true;
		this.Label2.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.ForeColor = System.Drawing.Color.DarkGray;
		this.Label2.Location = new System.Drawing.Point(53, 30);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(120, 17);
		this.Label2.TabIndex = 5;
		this.Label2.Text = "I'm still running...";
		this.ToolTip1.SetToolTip(this.Label2, "Click to permanently suppress this message");
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.White;
		this.Label1.Location = new System.Drawing.Point(53, 13);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(111, 17);
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Oculus Tray Tool";
		this.ToolTip1.SetToolTip(this.Label1, "Click to permanently suppress this message");
		this.PictureBox1.Image = OculusTrayTool.My.Resources.Resources.App_Blue_32;
		this.PictureBox1.Location = new System.Drawing.Point(15, 18);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 29);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox1.TabIndex = 3;
		this.PictureBox1.TabStop = false;
		this.ToolTip1.SetToolTip(this.PictureBox1, "Click to permanently suppress this message\"");
		this.Timer1.Interval = 50;
		this.Timer2.Interval = 2500;
		this.ToolTip1.AutomaticDelay = 50;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.Black;
		base.ClientSize = new System.Drawing.Size(259, 63);
		base.Controls.Add(this.Label2);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.PictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "StillRunningToast";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "StillRunningToast";
		this.ToolTip1.SetToolTip(this, "Click to permanently suppress this message");
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void StillRunningToast_Click(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.ShowStillRunning = false;
		MySettingsProperty.Settings.Save();
		Close();
		Dispose();
	}

	private void StillRunningToast_Load(object sender, EventArgs e)
	{
		base.Location = checked(new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height));
		Timer2.Start();
		Application.DoEvents();
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		base.Opacity -= 0.06;
		if (base.Opacity == 0.0)
		{
			Close();
			Dispose();
		}
	}

	private void Timer2_Tick(object sender, EventArgs e)
	{
		Timer2.Stop();
		Timer1.Start();
	}

	private void PictureBox1_Click(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.ShowStillRunning = false;
		MySettingsProperty.Settings.Save();
	}

	private void Label1_Click(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.ShowStillRunning = false;
		MySettingsProperty.Settings.Save();
	}

	private void Label2_Click(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.ShowStillRunning = false;
		MySettingsProperty.Settings.Save();
	}
}
