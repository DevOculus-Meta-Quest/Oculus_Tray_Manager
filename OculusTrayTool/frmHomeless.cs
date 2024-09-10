using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmHomeless : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboMusic")]
	private ComboBox _ComboMusic;

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
	[AccessedThroughProperty("BtnColor")]
	private Button _BtnColor;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnBrowseMusic")]
	private Button _BtnBrowseMusic;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboMusic
	{
		[CompilerGenerated]
		get
		{
			return _ComboMusic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComboMusic_SelectedIndexChanged;
			ComboBox comboMusic = _ComboMusic;
			if (comboMusic != null)
			{
				comboMusic.SelectedIndexChanged -= value2;
			}
			_ComboMusic = value;
			comboMusic = _ComboMusic;
			if (comboMusic != null)
			{
				comboMusic.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("NumericVolume")]
	internal virtual NumericUpDown NumericVolume
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

	[field: AccessedThroughProperty("ColorDialog1")]
	internal virtual ColorDialog ColorDialog1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button BtnColor
	{
		[CompilerGenerated]
		get
		{
			return _BtnColor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button3_Click;
			Button btnColor = _BtnColor;
			if (btnColor != null)
			{
				btnColor.Click -= value2;
			}
			_BtnColor = value;
			btnColor = _BtnColor;
			if (btnColor != null)
			{
				btnColor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual TextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button BtnBrowseMusic
	{
		[CompilerGenerated]
		get
		{
			return _BtnBrowseMusic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BtnBrowseMusic_Click;
			Button btnBrowseMusic = _BtnBrowseMusic;
			if (btnBrowseMusic != null)
			{
				btnBrowseMusic.Click -= value2;
			}
			_BtnBrowseMusic = value;
			btnBrowseMusic = _BtnBrowseMusic;
			if (btnBrowseMusic != null)
			{
				btnBrowseMusic.Click += value2;
			}
		}
	}

	internal virtual CheckBox CheckBox1
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox1_CheckedChanged;
			CheckBox checkBox = _CheckBox1;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_CheckBox1 = value;
			checkBox = _CheckBox1;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	public frmHomeless()
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
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.BtnBrowseMusic = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.BtnColor = new System.Windows.Forms.Button();
		this.ComboMusic = new System.Windows.Forms.ComboBox();
		this.NumericVolume = new System.Windows.Forms.NumericUpDown();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericVolume).BeginInit();
		base.SuspendLayout();
		this.GroupBox1.Controls.Add(this.CheckBox1);
		this.GroupBox1.Controls.Add(this.BtnBrowseMusic);
		this.GroupBox1.Controls.Add(this.TextBox1);
		this.GroupBox1.Controls.Add(this.BtnColor);
		this.GroupBox1.Controls.Add(this.ComboMusic);
		this.GroupBox1.Controls.Add(this.NumericVolume);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(348, 133);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.BtnBrowseMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnBrowseMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.BtnBrowseMusic.Location = new System.Drawing.Point(258, 44);
		this.BtnBrowseMusic.Name = "BtnBrowseMusic";
		this.BtnBrowseMusic.Size = new System.Drawing.Size(71, 23);
		this.BtnBrowseMusic.TabIndex = 8;
		this.BtnBrowseMusic.Text = "Add More";
		this.BtnBrowseMusic.UseVisualStyleBackColor = true;
		this.TextBox1.Location = new System.Drawing.Point(131, 17);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		this.TextBox1.Size = new System.Drawing.Size(121, 20);
		this.TextBox1.TabIndex = 7;
		this.BtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.BtnColor.Location = new System.Drawing.Point(258, 15);
		this.BtnColor.Name = "BtnColor";
		this.BtnColor.Size = new System.Drawing.Size(71, 23);
		this.BtnColor.TabIndex = 6;
		this.BtnColor.Text = "Pick color";
		this.BtnColor.UseVisualStyleBackColor = true;
		this.ComboMusic.BackColor = System.Drawing.Color.AliceBlue;
		this.ComboMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboMusic.DropDownWidth = 200;
		this.ComboMusic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.ComboMusic.FormattingEnabled = true;
		this.ComboMusic.Items.AddRange(new object[1] { "None" });
		this.ComboMusic.Location = new System.Drawing.Point(131, 46);
		this.ComboMusic.Name = "ComboMusic";
		this.ComboMusic.Size = new System.Drawing.Size(121, 21);
		this.ComboMusic.Sorted = true;
		this.ComboMusic.TabIndex = 4;
		this.NumericVolume.Location = new System.Drawing.Point(132, 79);
		this.NumericVolume.Name = "NumericVolume";
		this.NumericVolume.Size = new System.Drawing.Size(120, 20);
		this.NumericVolume.TabIndex = 3;
		this.Label3.AutoSize = true;
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label3.Location = new System.Drawing.Point(16, 81);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(103, 15);
		this.Label3.TabIndex = 2;
		this.Label3.Text = "Music volume %: ";
		this.Label2.AutoSize = true;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.Location = new System.Drawing.Point(15, 49);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(112, 15);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Background music:";
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.Location = new System.Drawing.Point(16, 20);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(109, 15);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Background color: ";
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(12, 151);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(55, 25);
		this.Button1.TabIndex = 1;
		this.Button1.Text = "Cancel";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(305, 151);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(55, 25);
		this.Button2.TabIndex = 2;
		this.Button2.Text = "OK";
		this.Button2.UseVisualStyleBackColor = true;
		this.ColorDialog1.FullOpen = true;
		this.CheckBox1.AutoSize = true;
		this.CheckBox1.Location = new System.Drawing.Point(16, 105);
		this.CheckBox1.Name = "CheckBox1";
		this.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.CheckBox1.Size = new System.Drawing.Size(130, 17);
		this.CheckBox1.TabIndex = 9;
		this.CheckBox1.Text = "   :Automatically patch";
		this.CheckBox1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(368, 183);
		base.ControlBox = false;
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "frmHomeless";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Configure Oculus Homeless";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericVolume).EndInit();
		base.ResumeLayout(false);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		if (ColorDialog1.ShowDialog(this) == DialogResult.OK)
		{
			TextBox1.BackColor = ColorDialog1.Color;
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		try
		{
			Cursor = Cursors.WaitCursor;
			Color backColor = TextBox1.BackColor;
			float num = (float)Math.Round((double)(int)backColor.R / 255.0, 2);
			float num2 = (float)Math.Round((double)(int)backColor.G / 255.0, 2);
			float num3 = (float)Math.Round((double)(int)backColor.B / 255.0, 2);
			string text = num.ToString().Replace(",", ".") + " " + num2.ToString().Replace(",", ".") + " " + num3.ToString().Replace(",", ".");
			StreamWriter streamWriter = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
			streamWriter.WriteLine(text);
			streamWriter.Close();
			Log.WriteToLog("Homeless background color set to " + text);
			if (Operators.CompareString(ComboMusic.Text, "None", TextCompare: false) != 0)
			{
				if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + ComboMusic.Text))
				{
					StreamWriter streamWriter2 = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
					streamWriter2.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString().Replace("\\", "\\\\") + "\\\\OculusTrayTool\\\\Music\\\\" + ComboMusic.Text + "," + Conversions.ToString(decimal.Multiply(NumericVolume.Value, 10m)));
					streamWriter2.Close();
					Log.WriteToLog("Homeless background music set to " + ComboMusic.Text);
					Log.WriteToLog("Homeless background volume set to " + Conversions.ToString(NumericVolume.Value) + "%");
				}
			}
			else if (File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt"))
			{
				File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
				Log.WriteToLog("Homeless background music disabled");
			}
			MySettingsProperty.Settings.HomlessColor = text;
			MySettingsProperty.Settings.HomelessVolume = Convert.ToInt32(decimal.Multiply(NumericVolume.Value, 10m));
			MySettingsProperty.Settings.Save();
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			if (processesByName.Length > 0)
			{
				Process[] processesByName2 = Process.GetProcessesByName("Home2-Win64-Shipping");
				if (processesByName2.Length > 0)
				{
					Log.WriteToLog("Killing Home2-Win64-Shipping.exe");
					Process[] array = processesByName2;
					foreach (Process process in array)
					{
						process.Kill();
						process.WaitForExit();
					}
				}
				Thread.Sleep(1000);
				Process[] processesByName3 = Process.GetProcessesByName("Home2-Win64-Shipping");
				if (processesByName3.Length == 0)
				{
					Log.WriteToLog("Restarting Home2-Win64-Shipping.exe");
					Process.Start(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
				}
			}
			Cursor = Cursors.Default;
			Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Could save settings: " + ex2.Message);
			Interaction.MsgBox("Could save settings: " + ex2.Message, MsgBoxStyle.Critical, "Error saving settings");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnBrowseMusic_Click(object sender, EventArgs e)
	{
		try
		{
			if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
				Log.WriteToLog("Created " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			openFileDialog.Filter = "MP3 Music (*.mp3)|*.mp3";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string text = ComboMusic.Text;
			string[] fileNames = openFileDialog.FileNames;
			foreach (string text2 in fileNames)
			{
				File.Copy(text2, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + Path.GetFileName(text2).Replace(" ", ""));
				Log.WriteToLog("Copied " + text2 + " to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
			}
			if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
			{
				ComboMusic.Items.Clear();
				string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
				string[] array = files;
				foreach (string path in array)
				{
					ComboMusic.Items.Add(Path.GetFileName(path));
				}
			}
			ComboMusic.Items.Add("None");
			ComboMusic.Text = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Could not add music file: " + ex2.Message);
			Interaction.MsgBox("Could not add music file: " + ex2.Message, MsgBoxStyle.Critical, "Error adding music");
			ProjectData.ClearProjectError();
		}
	}

	private void ComboMusic_SelectedIndexChanged(object sender, EventArgs e)
	{
		MySettingsProperty.Settings.HomelessMusic = ComboMusic.Text;
		MySettingsProperty.Settings.Save();
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			MySettingsProperty.Settings.HomelessAutoPatch = true;
		}
		else
		{
			MySettingsProperty.Settings.HomelessAutoPatch = false;
		}
		MySettingsProperty.Settings.Save();
	}
}
