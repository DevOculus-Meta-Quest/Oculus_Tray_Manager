using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmAbout : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LinkLabel2")]
	private LinkLabel _LinkLabel2;

	private Resizer rs;

	internal virtual LinkLabel LinkLabel1
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = LinkLabel1_LinkClicked;
			LinkLabel linkLabel = _LinkLabel1;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel1 = value;
			linkLabel = _LinkLabel1;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
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

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
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

	internal virtual LinkLabel LinkLabel2
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = LinkLabel2_LinkClicked;
			LinkLabel linkLabel = _LinkLabel2;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_LinkLabel2 = value;
			linkLabel = _LinkLabel2;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmAbout()
	{
		base.Load += readme_Load;
		rs = new Resizer();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmAbout));
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.LinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.LinkLabel1.Location = new System.Drawing.Point(209, 128);
		this.LinkLabel1.Name = "LinkLabel1";
		this.LinkLabel1.Size = new System.Drawing.Size(102, 15);
		this.LinkLabel1.TabIndex = 0;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Open User Guide";
		this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.PictureBox1.Image = OculusTrayTool.My.Resources.Resources.paypal;
		this.PictureBox1.Location = new System.Drawing.Point(13, 123);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(88, 27);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox1.TabIndex = 2;
		this.PictureBox1.TabStop = false;
		this.GroupBox1.Controls.Add(this.LinkLabel2);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.Label6);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(13, 4);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(305, 113);
		this.GroupBox1.TabIndex = 3;
		this.GroupBox1.TabStop = false;
		this.LinkLabel2.AutoSize = true;
		this.LinkLabel2.Location = new System.Drawing.Point(108, 87);
		this.LinkLabel2.Name = "LinkLabel2";
		this.LinkLabel2.Size = new System.Drawing.Size(114, 13);
		this.LinkLabel2.TabIndex = 7;
		this.LinkLabel2.TabStop = true;
		this.LinkLabel2.Text = "https://apollyonvr.com";
		this.Label7.Location = new System.Drawing.Point(7, 87);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(55, 13);
		this.Label7.TabIndex = 6;
		this.Label7.Text = "Website: ";
		this.Label6.ForeColor = System.Drawing.Color.Crimson;
		this.Label6.Location = new System.Drawing.Point(103, 65);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(143, 15);
		this.Label6.TabIndex = 5;
		this.Label6.Text = " ApollyonVR@gmail.com";
		this.Label5.ForeColor = System.Drawing.Color.Crimson;
		this.Label5.Location = new System.Drawing.Point(103, 42);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(100, 15);
		this.Label5.TabIndex = 4;
		this.Label5.Text = " ApollyonVR";
		this.Label4.ForeColor = System.Drawing.Color.Crimson;
		this.Label4.Location = new System.Drawing.Point(105, 20);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(100, 15);
		this.Label4.TabIndex = 3;
		this.Label4.Text = "Label4";
		this.Label3.Location = new System.Drawing.Point(7, 65);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(39, 13);
		this.Label3.TabIndex = 2;
		this.Label3.Text = "Email: ";
		this.Label2.Location = new System.Drawing.Point(7, 42);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(69, 13);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Created by: ";
		this.Label1.Location = new System.Drawing.Point(7, 20);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(100, 13);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Oculus Tray Tool";
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(330, 158);
		base.Controls.Add(this.GroupBox1);
		base.Controls.Add(this.LinkLabel1);
		base.Controls.Add(this.PictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAbout";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "About";
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[DllImport("user32.dll")]
	private static extern bool HideCaret(IntPtr hWnd);

	private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = true;
	}

	private void readme_Load(object sender, EventArgs e)
	{
		PictureBox1.Focus();
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		if (File.Exists(Application.StartupPath + "\\User Guide.pdf"))
		{
			Process.Start(Application.StartupPath + "\\User Guide.pdf");
		}
	}

	private void PictureBox1_Click(object sender, EventArgs e)
	{
		MyProject.Forms.frmDonate.ShowDialog();
		Close();
	}

	private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://apollyonvr.com");
	}
}
