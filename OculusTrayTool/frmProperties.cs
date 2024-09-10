using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmProperties : Form
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

	public string fname;

	[field: AccessedThroughProperty("RichTextBox1")]
	internal virtual RichTextBox RichTextBox1
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

	[field: AccessedThroughProperty("LabelProperties")]
	internal virtual Label LabelProperties
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

	[field: AccessedThroughProperty("CheckBox1")]
	internal virtual CheckBox CheckBox1
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

	[field: AccessedThroughProperty("LabelProperties2")]
	internal virtual Label LabelProperties2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual TextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmProperties()
	{
		base.Load += Properties_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmProperties));
		this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.LabelProperties = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.Button2 = new System.Windows.Forms.Button();
		this.LabelProperties2 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.RichTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.RichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.RichTextBox1.Location = new System.Drawing.Point(12, 124);
		this.RichTextBox1.Name = "RichTextBox1";
		this.RichTextBox1.Size = new System.Drawing.Size(660, 360);
		this.RichTextBox1.TabIndex = 0;
		this.RichTextBox1.Text = "";
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Controls.Add(this.LabelProperties);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(660, 87);
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.LabelProperties.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.LabelProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelProperties.Location = new System.Drawing.Point(6, 12);
		this.LabelProperties.Name = "LabelProperties";
		this.LabelProperties.Size = new System.Drawing.Size(647, 72);
		this.LabelProperties.TabIndex = 0;
		this.LabelProperties.Text = resources.GetString("LabelProperties.Text");
		this.LabelProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(597, 493);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 25);
		this.Button1.TabIndex = 2;
		this.Button1.Text = "Verify file";
		this.Button1.UseVisualStyleBackColor = true;
		this.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.CheckBox1.AutoSize = true;
		this.CheckBox1.Checked = true;
		this.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
		this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.CheckBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox1.Location = new System.Drawing.Point(452, 497);
		this.CheckBox1.Name = "CheckBox1";
		this.CheckBox1.Size = new System.Drawing.Size(143, 19);
		this.CheckBox1.TabIndex = 3;
		this.CheckBox1.Text = "Backup before saving";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(12, 493);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(75, 25);
		this.Button2.TabIndex = 4;
		this.Button2.Text = "Close";
		this.Button2.UseVisualStyleBackColor = true;
		this.LabelProperties2.AutoSize = true;
		this.LabelProperties2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelProperties2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.LabelProperties2.Location = new System.Drawing.Point(12, 103);
		this.LabelProperties2.Name = "LabelProperties2";
		this.LabelProperties2.Size = new System.Drawing.Size(65, 15);
		this.LabelProperties2.TabIndex = 5;
		this.LabelProperties2.Text = "Filename: ";
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Location = new System.Drawing.Point(76, 105);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(626, 13);
		this.TextBox1.TabIndex = 7;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(684, 525);
		base.Controls.Add(this.TextBox1);
		base.Controls.Add(this.LabelProperties2);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.CheckBox1);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.Controls.Add(this.RichTextBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(700, 564);
		base.Name = "Properties";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "App Properties";
		this.GroupBox1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void FormatText(string searchstring, FontStyle style)
	{
		for (int num = RichTextBox1.Find(searchstring, 0, RichTextBoxFinds.MatchCase); num != -1; num = RichTextBox1.Find(searchstring, checked(num + searchstring.Length), RichTextBoxFinds.MatchCase))
		{
			RichTextBox1.Select(num, searchstring.Length);
			RichTextBox1.SelectionFont = new Font(RichTextBox1.Font, style);
			RichTextBox1.SelectionColor = Color.DodgerBlue;
		}
		RichTextBox1.Select(0, 0);
	}

	private void Properties_Load(object sender, EventArgs e)
	{
		FormatText("displayName", FontStyle.Bold);
		FormatText("launchFile", FontStyle.Bold);
		FormatText("launchParameters", FontStyle.Bold);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Button1_Click(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			string text = ".BKP_" + DateTime.Now.ToString("yyyyMMddHHmmss");
			FileSystem.FileCopy(fname, fname + text);
			Log.WriteToLog("Backup made: " + fname + " -> " + fname + text);
		}
		if (IsValidJson(RichTextBox1.Text) && Interaction.MsgBox("JSON formatting looks OK, do you want to save this file?", MsgBoxStyle.YesNo | MsgBoxStyle.Question) == MsgBoxResult.Yes)
		{
			StreamWriter streamWriter = new StreamWriter(fname);
			streamWriter.Write(RichTextBox1.Text);
			streamWriter.Close();
			Log.WriteToLog(fname + " was edited");
		}
	}

	private static bool IsValidJson(string strInput)
	{
		strInput = strInput.Trim();
		bool result;
		if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || (strInput.StartsWith("[") && strInput.EndsWith("]")))
		{
			try
			{
				JToken jToken = JToken.Parse(strInput);
				result = true;
			}
			catch (JsonReaderException ex)
			{
				ProjectData.SetProjectError(ex);
				JsonReaderException ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Exclamation, "JSON validation failed");
				result = false;
				ProjectData.ClearProjectError();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Interaction.MsgBox(ex4.ToString(), MsgBoxStyle.Exclamation, "JSON validation failed");
				result = false;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}
}
