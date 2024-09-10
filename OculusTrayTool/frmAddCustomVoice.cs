using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmAddCustomVoice : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TextBoxSeconds")]
	private TextBox _TextBoxSeconds;

	public int id;

	public string VoiceProfileName;

	public string VoiceProfileGameProfile;

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBoxSpokenCommand")]
	internal virtual TextBox TextBoxSpokenCommand
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

	[field: AccessedThroughProperty("TextBoxButtonCombo")]
	internal virtual TextBox TextBoxButtonCombo
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

	[field: AccessedThroughProperty("OpenFileDialog1")]
	internal virtual OpenFileDialog OpenFileDialog1
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

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox TextBoxSeconds
	{
		[CompilerGenerated]
		get
		{
			return _TextBoxSeconds;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = TextBoxSeconds_KeyPress;
			TextBox textBoxSeconds = _TextBoxSeconds;
			if (textBoxSeconds != null)
			{
				textBoxSeconds.KeyPress -= value2;
			}
			_TextBoxSeconds = value;
			textBoxSeconds = _TextBoxSeconds;
			if (textBoxSeconds != null)
			{
				textBoxSeconds.KeyPress += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("RadioButton2")]
	internal virtual RadioButton RadioButton2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("RadioButton1")]
	internal virtual RadioButton RadioButton1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmAddCustomVoice()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmAddCustomVoice));
		this.Label2 = new System.Windows.Forms.Label();
		this.TextBoxSpokenCommand = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.TextBoxButtonCombo = new System.Windows.Forms.TextBox();
		this.Button2 = new System.Windows.Forms.Button();
		this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.TextBoxSeconds = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.Button1 = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(14, 91);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(63, 13);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "When i say:";
		this.TextBoxSpokenCommand.Location = new System.Drawing.Point(128, 88);
		this.TextBoxSpokenCommand.Name = "TextBoxSpokenCommand";
		this.TextBoxSpokenCommand.Size = new System.Drawing.Size(226, 20);
		this.TextBoxSpokenCommand.TabIndex = 1;
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(14, 126);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(108, 13);
		this.Label4.TabIndex = 14;
		this.Label4.Text = "Press Button/Combo:";
		this.TextBoxButtonCombo.Enabled = false;
		this.TextBoxButtonCombo.Location = new System.Drawing.Point(128, 123);
		this.TextBoxButtonCombo.Name = "TextBoxButtonCombo";
		this.TextBoxButtonCombo.Size = new System.Drawing.Size(226, 20);
		this.TextBoxButtonCombo.TabIndex = 15;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Location = new System.Drawing.Point(330, 260);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(56, 23);
		this.Button2.TabIndex = 16;
		this.Button2.Text = "Save";
		this.Button2.UseVisualStyleBackColor = true;
		this.OpenFileDialog1.Filter = "Scripts|*.cmd;*.bat|Executables|*.exe";
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.TextBoxSeconds);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.RadioButton2);
		this.GroupBox1.Controls.Add(this.RadioButton1);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.TextBoxButtonCombo);
		this.GroupBox1.Controls.Add(this.TextBoxSpokenCommand);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(373, 242);
		this.GroupBox1.TabIndex = 18;
		this.GroupBox1.TabStop = false;
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(281, 176);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(47, 13);
		this.Label3.TabIndex = 24;
		this.Label3.Text = "seconds";
		this.TextBoxSeconds.Location = new System.Drawing.Point(198, 174);
		this.TextBoxSeconds.Name = "TextBoxSeconds";
		this.TextBoxSeconds.Size = new System.Drawing.Size(76, 20);
		this.TextBoxSeconds.TabIndex = 23;
		this.TextBoxSeconds.Text = "00,300";
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(145, 177);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(47, 13);
		this.Label1.TabIndex = 22;
		this.Label1.Text = "Hold for ";
		this.RadioButton2.AutoSize = true;
		this.RadioButton2.Location = new System.Drawing.Point(128, 200);
		this.RadioButton2.Name = "RadioButton2";
		this.RadioButton2.Size = new System.Drawing.Size(83, 17);
		this.RadioButton2.TabIndex = 21;
		this.RadioButton2.TabStop = true;
		this.RadioButton2.Text = "Press Key(s)";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Location = new System.Drawing.Point(128, 154);
		this.RadioButton1.Name = "RadioButton1";
		this.RadioButton1.Size = new System.Drawing.Size(146, 17);
		this.RadioButton1.TabIndex = 20;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Press and Release Key(s)";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Location = new System.Drawing.Point(12, 260);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(56, 23);
		this.Button1.TabIndex = 19;
		this.Button1.Text = "Cancel";
		this.Button1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(398, 295);
		base.ControlBox = false;
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.GroupBox1);
		this.ForeColor = System.Drawing.Color.DodgerBlue;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmAddCustomVoice";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add Command";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	private void Button2_Click(object sender, EventArgs e)
	{
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void TextBoxSeconds_KeyPress(object sender, KeyPressEventArgs e)
	{
		int num = 0;
		if (((Strings.Asc(e.KeyChar) != 8) & (Strings.Asc(e.KeyChar) != 127) & (Strings.Asc(e.KeyChar) != 44)) && ((Strings.Asc(e.KeyChar) < 48) | (Strings.Asc(e.KeyChar) > 57)))
		{
			e.Handled = true;
		}
	}
}
