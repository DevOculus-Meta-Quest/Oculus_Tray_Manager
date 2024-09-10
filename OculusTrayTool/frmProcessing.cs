using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmProcessing : Form
{
	public delegate void UpdateProgressBarDelegate(int percent, string message);

	private IContainer components;

	private TextProgressBar progressBar1;

	protected override bool ShowWithoutActivation => true;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ExStyle = createParams.ExStyle | 0x8000000 | 8;
			return createParams;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.progressBar1 = new OculusTrayTool.TextProgressBar();
		base.SuspendLayout();
		this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBar1.Location = new System.Drawing.Point(0, 0);
		this.progressBar1.Message = null;
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(300, 52);
		this.progressBar1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(300, 52);
		base.ControlBox = false;
		base.Controls.Add(this.progressBar1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmProcessing";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Processing";
		base.TopMost = true;
		base.ResumeLayout(false);
	}

	public frmProcessing()
	{
		components = null;
		InitializeComponent();
	}

	private void frmProcessing_Load(object sender, EventArgs e)
	{
	}

	public void UpdateProgressBar(int percent, string message)
	{
		if (progressBar1.InvokeRequired)
		{
			UpdateProgressBarDelegate method = UpdateProgressBar;
			Invoke(method, percent, message);
		}
		else
		{
			progressBar1.Message = message;
			progressBar1.Value = MathTools.Clamp(percent, 0, 100);
		}
	}

	protected override void WndProc(ref Message msg)
	{
		int msg2 = msg.Msg;
		if (msg2 == 33)
		{
			msg.Result = (IntPtr)3;
		}
		else
		{
			base.WndProc(ref msg);
		}
	}
}
