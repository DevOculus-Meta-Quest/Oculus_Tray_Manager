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
public class frmEditVoiceCommand : Form
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

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBoxPhrase")]
	internal virtual TextBox TextBoxPhrase
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

	[field: AccessedThroughProperty("LabelAction")]
	internal virtual Label LabelAction
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboEnabled")]
	internal virtual ComboBox ComboEnabled
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

	public frmEditVoiceCommand()
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
		this.Label1 = new System.Windows.Forms.Label();
		this.TextBoxPhrase = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.LabelAction = new System.Windows.Forms.Label();
		this.ComboEnabled = new System.Windows.Forms.ComboBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(15, 30);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(40, 13);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Action:";
		this.TextBoxPhrase.Location = new System.Drawing.Point(64, 53);
		this.TextBoxPhrase.Name = "TextBoxPhrase";
		this.TextBoxPhrase.Size = new System.Drawing.Size(249, 20);
		this.TextBoxPhrase.TabIndex = 3;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(15, 56);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(43, 13);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Phrase:";
		this.LabelAction.AutoSize = true;
		this.LabelAction.ForeColor = System.Drawing.Color.Black;
		this.LabelAction.Location = new System.Drawing.Point(61, 30);
		this.LabelAction.Name = "LabelAction";
		this.LabelAction.Size = new System.Drawing.Size(37, 13);
		this.LabelAction.TabIndex = 4;
		this.LabelAction.Text = "Action";
		this.ComboEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboEnabled.FormattingEnabled = true;
		this.ComboEnabled.Items.AddRange(new object[2] { "True", "False" });
		this.ComboEnabled.Location = new System.Drawing.Point(64, 79);
		this.ComboEnabled.Name = "ComboEnabled";
		this.ComboEnabled.Size = new System.Drawing.Size(121, 21);
		this.ComboEnabled.TabIndex = 5;
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(15, 82);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(49, 13);
		this.Label3.TabIndex = 6;
		this.Label3.Text = "Enabled:";
		this.GroupBox1.Controls.Add(this.TextBoxPhrase);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.ComboEnabled);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.LabelAction);
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(334, 132);
		this.GroupBox1.TabIndex = 7;
		this.GroupBox1.TabStop = false;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Location = new System.Drawing.Point(271, 150);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 23);
		this.Button1.TabIndex = 8;
		this.Button1.Text = "Save";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Location = new System.Drawing.Point(12, 150);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(75, 23);
		this.Button2.TabIndex = 9;
		this.Button2.Text = "Cancel";
		this.Button2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(356, 179);
		base.ControlBox = false;
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		this.ForeColor = System.Drawing.Color.DodgerBlue;
		base.Name = "frmEditVoiceCommand";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Edit Voice Command";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		if (TextBoxPhrase.Text.EndsWith(";"))
		{
			TextBoxPhrase.Text = TextBoxPhrase.Text.TrimEnd(';');
		}
		TextBoxPhrase.Text = TextBoxPhrase.Text.Replace(";;", ";");
		if (Operators.CompareString(LabelAction.Text, "Enable Voice Control", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.StartVoice = TextBoxPhrase.Text;
		}
		if (Operators.CompareString(LabelAction.Text, "Disable Voice Control", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.StopVoice = TextBoxPhrase.Text;
		}
		if (Operators.CompareString(LabelAction.Text, "Set Pixel Density", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.SetPD = TextBoxPhrase.Text;
			MySettingsProperty.Settings.SetPDEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Disable ASW", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.DisableASW = TextBoxPhrase.Text;
			MySettingsProperty.Settings.DisableASWEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Enable ASW", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.EnableASW = TextBoxPhrase.Text;
			MySettingsProperty.Settings.EnableASWEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "45 fps, ASW On", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.LockASWOn = TextBoxPhrase.Text;
			MySettingsProperty.Settings.LockASWOnEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show ASW Status", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowASW = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowASWEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show Pixel Density", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowPD = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowPDEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show Performance", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowPerf = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowPerfEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show Latency Timing", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowLatency = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowLatencyEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show Application Render Timing", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowApplicationRender = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowApplicationRenderEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show Compositor Render Timing", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowCompositorRender = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowCompositorRenderEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Show Version Info", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.ShowVersion = TextBoxPhrase.Text;
			MySettingsProperty.Settings.ShowVersionEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Close Overlay", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.Close = TextBoxPhrase.Text;
			MySettingsProperty.Settings.CloseEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		if (Operators.CompareString(LabelAction.Text, "Launch SteamVR", TextCompare: false) == 0)
		{
			MySettingsProperty.Settings.LaunchSteam = TextBoxPhrase.Text;
			MySettingsProperty.Settings.LaunchSteamEnabled = Conversions.ToBoolean(ComboEnabled.Text);
		}
		MySettingsProperty.Settings.Save();
		MyProject.Forms.FrmMain.LoadVoiceSettings();
		MyProject.Forms.frmVoiceSettings.VoicechangeMade = true;
		Close();
	}
}
