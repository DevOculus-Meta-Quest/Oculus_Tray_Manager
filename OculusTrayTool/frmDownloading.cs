using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmDownloading : Form
{
	public delegate void UpdateLabel_delegate(string text);

	private IContainer components;

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmDownloading()
	{
		base.Load += frmDownloading_Load;
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
		base.SuspendLayout();
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label1.Location = new System.Drawing.Point(4, 15);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(252, 13);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Updating Database:  0%";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(258, 41);
		base.ControlBox = false;
		base.Controls.Add(this.Label1);
		this.ForeColor = System.Drawing.Color.DodgerBlue;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "frmDownloading";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.ResumeLayout(false);
	}

	public void UpdateLabel(string text)
	{
		if (Label1.InvokeRequired)
		{
			UpdateLabel_delegate method = UpdateLabel;
			Label1.BeginInvoke(method, text);
		}
		else
		{
			Label1.Text = text;
			Label1.Update();
		}
	}

	private void frmDownloading_Load(object sender, EventArgs e)
	{
		CenterForm(this, MyProject.Forms.frmLibrary);
	}

	public static void CenterForm(Form frm, Form parent = null)
	{
		Rectangle rectangle = parent?.RectangleToScreen(parent.ClientRectangle) ?? Screen.FromPoint(frm.Location).WorkingArea;
		checked
		{
			int num = rectangle.Left + unchecked(checked(rectangle.Width - frm.Width) / 2);
			int num2 = rectangle.Top + unchecked(checked(rectangle.Height - frm.Height) / 2);
			frm.Location = new Point(num, num2);
		}
	}
}
