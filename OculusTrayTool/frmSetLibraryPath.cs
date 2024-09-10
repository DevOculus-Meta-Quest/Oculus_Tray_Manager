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
public class frmSetLibraryPath : Form
{
	private IContainer components;

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

	[field: AccessedThroughProperty("FolderBrowserDialog1")]
	internal virtual FolderBrowserDialog FolderBrowserDialog1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmSetLibraryPath()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmSetLibraryPath));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(394, 97);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.Label1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label1.Location = new System.Drawing.Point(6, 17);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(382, 77);
		this.Label1.TabIndex = 0;
		this.Label1.Text = resources.GetString("Label1.Text");
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(150, 124);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(127, 29);
		this.Button1.TabIndex = 1;
		this.Button1.Text = "Browse...";
		this.Button1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(418, 165);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SetLibraryPath";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Set Library Path";
		this.GroupBox1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		if (FolderBrowserDialog1.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		if (Directory.Exists(FolderBrowserDialog1.SelectedPath.TrimEnd('\\') + "\\Manifests"))
		{
			if (File.Exists(FolderBrowserDialog1.SelectedPath.TrimEnd('\\') + "\\Manifests\\oculus-home.json"))
			{
				Interaction.MsgBox("While this path contains a 'Manifests' folder, it is not the correct one. See if there's a subfolder called 'Software' to the folder you selected. If so please select that folder.", MsgBoxStyle.Exclamation, "Invalid Path");
				return;
			}
			MySettingsProperty.Settings.LibraryPath = FolderBrowserDialog1.SelectedPath.TrimEnd('\\');
			MySettingsProperty.Settings.Save();
			Close();
		}
		else
		{
			Interaction.MsgBox("Invalid Path: Folder does not contain 'Manifests'", MsgBoxStyle.Exclamation, "Invalid Path");
		}
	}
}
