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
public class frmLoading : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label _Label2;

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

	[field: AccessedThroughProperty("PictureBox2")]
	internal virtual PictureBox PictureBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ExStyle = createParams.ExStyle | 0x8000000 | 8;
			return createParams;
		}
	}

	public frmLoading()
	{
		base.Load += Loading_Load;
		base.FormClosing += frmLoading_FormClosing;
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
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
		base.SuspendLayout();
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.White;
		this.Label1.Location = new System.Drawing.Point(53, 13);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(111, 17);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Oculus Tray Tool";
		this.Label2.AutoSize = true;
		this.Label2.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.ForeColor = System.Drawing.Color.DarkGray;
		this.Label2.Location = new System.Drawing.Point(53, 30);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(166, 17);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Starting up, please wait...";
		this.PictureBox2.Image = OculusTrayTool.My.Resources.Resources.App_Blue_32;
		this.PictureBox2.Location = new System.Drawing.Point(15, 18);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(32, 29);
		this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox2.TabIndex = 4;
		this.PictureBox2.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.AutoSize = true;
		this.BackColor = System.Drawing.Color.Black;
		base.ClientSize = new System.Drawing.Size(259, 63);
		base.ControlBox = false;
		base.Controls.Add(this.PictureBox2);
		base.Controls.Add(this.Label2);
		base.Controls.Add(this.Label1);
		this.ForeColor = System.Drawing.Color.DodgerBlue;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmLoading";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Loading";
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Loading_Load(object sender, EventArgs e)
	{
		base.Location = checked(new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height));
		Win32.AnimateWindow(base.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_NEGATIVE | Win32.AnimateWindowFlags.AW_SLIDE);
	}

	private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void Label1_Click(object sender, EventArgs e)
	{
		if (MyProject.Forms.FrmMain.loadingDone)
		{
			MyProject.Forms.FrmMain.ShowForm();
		}
	}

	private void Label2_Click(object sender, EventArgs e)
	{
		if (MyProject.Forms.FrmMain.loadingDone)
		{
			MyProject.Forms.FrmMain.ShowForm();
		}
	}

	private void PictureBox1_Click(object sender, EventArgs e)
	{
		if (MyProject.Forms.FrmMain.loadingDone)
		{
			MyProject.Forms.FrmMain.ShowForm();
		}
	}

	public void CloseStartupToast()
	{
		Win32.AnimateWindow(base.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_POSITIVE | Win32.AnimateWindowFlags.AW_HIDE | Win32.AnimateWindowFlags.AW_SLIDE);
	}

	protected override void WndProc(ref Message msg)
	{
		int msg2 = msg.Msg;
		if (msg2 == 33)
		{
			bool flag = true;
			msg.Result = (IntPtr)3;
		}
		else
		{
			base.WndProc(ref msg);
		}
	}
}
