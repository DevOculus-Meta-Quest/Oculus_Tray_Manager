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

namespace OculusTrayTool
{
	// Token: 0x02000021 RID: 33
	[DesignerGenerated]
	public partial class frmHomeless : Form
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0001166C File Offset: 0x0000F86C
		public frmHomeless()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00011F98 File Offset: 0x00010198
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x00011FA2 File Offset: 0x000101A2
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00011FAB File Offset: 0x000101AB
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x00011FB8 File Offset: 0x000101B8
		internal virtual ComboBox ComboMusic
		{
			[CompilerGenerated]
			get
			{
				return this._ComboMusic;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboMusic_SelectedIndexChanged);
				ComboBox comboBox = this._ComboMusic;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboMusic = value;
				comboBox = this._ComboMusic;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00011FFB File Offset: 0x000101FB
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00012005 File Offset: 0x00010205
		internal virtual NumericUpDown NumericVolume
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0001200E File Offset: 0x0001020E
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00012018 File Offset: 0x00010218
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00012021 File Offset: 0x00010221
		// (set) Token: 0x060002FE RID: 766 RVA: 0x0001202B File Offset: 0x0001022B
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00012034 File Offset: 0x00010234
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0001203E File Offset: 0x0001023E
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00012047 File Offset: 0x00010247
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00012054 File Offset: 0x00010254
		internal virtual Button Button1
		{
			[CompilerGenerated]
			get
			{
				return this._Button1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button1_Click);
				Button button = this._Button1;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button1 = value;
				button = this._Button1;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00012097 File Offset: 0x00010297
		// (set) Token: 0x06000304 RID: 772 RVA: 0x000120A4 File Offset: 0x000102A4
		internal virtual Button Button2
		{
			[CompilerGenerated]
			get
			{
				return this._Button2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button2_Click);
				Button button = this._Button2;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button2 = value;
				button = this._Button2;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000305 RID: 773 RVA: 0x000120E7 File Offset: 0x000102E7
		// (set) Token: 0x06000306 RID: 774 RVA: 0x000120F1 File Offset: 0x000102F1
		internal virtual ColorDialog ColorDialog1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000307 RID: 775 RVA: 0x000120FA File Offset: 0x000102FA
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00012104 File Offset: 0x00010304
		internal virtual Button BtnColor
		{
			[CompilerGenerated]
			get
			{
				return this._BtnColor;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button3_Click);
				Button button = this._BtnColor;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnColor = value;
				button = this._BtnColor;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00012147 File Offset: 0x00010347
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00012151 File Offset: 0x00010351
		internal virtual TextBox TextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0001215A File Offset: 0x0001035A
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00012164 File Offset: 0x00010364
		internal virtual Button BtnBrowseMusic
		{
			[CompilerGenerated]
			get
			{
				return this._BtnBrowseMusic;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BtnBrowseMusic_Click);
				Button button = this._BtnBrowseMusic;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._BtnBrowseMusic = value;
				button = this._BtnBrowseMusic;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600030D RID: 781 RVA: 0x000121A7 File Offset: 0x000103A7
		// (set) Token: 0x0600030E RID: 782 RVA: 0x000121B4 File Offset: 0x000103B4
		internal virtual CheckBox CheckBox1
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox1_CheckedChanged);
				CheckBox checkBox = this._CheckBox1;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckBox1 = value;
				checkBox = this._CheckBox1;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000121F8 File Offset: 0x000103F8
		private void Button3_Click(object sender, EventArgs e)
		{
			bool flag = this.ColorDialog1.ShowDialog(this) == DialogResult.OK;
			if (flag)
			{
				this.TextBox1.BackColor = this.ColorDialog1.Color;
			}
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00012234 File Offset: 0x00010434
		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				Color backColor = this.TextBox1.BackColor;
				float num = (float)Math.Round((double)backColor.R / 255.0, 2);
				float num2 = (float)Math.Round((double)backColor.G / 255.0, 2);
				float num3 = (float)Math.Round((double)backColor.B / 255.0, 2);
				string text = string.Concat(new string[]
				{
					num.ToString().Replace(",", "."),
					" ",
					num2.ToString().Replace(",", "."),
					" ",
					num3.ToString().Replace(",", ".")
				});
				StreamWriter streamWriter = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
				streamWriter.WriteLine(text);
				streamWriter.Close();
				Log.WriteToLog("Homeless background color set to " + text);
				bool flag = Operators.CompareString(this.ComboMusic.Text, "None", false) != 0;
				if (flag)
				{
					bool flag2 = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + this.ComboMusic.Text);
					if (flag2)
					{
						StreamWriter streamWriter2 = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
						streamWriter2.WriteLine(string.Concat(new string[]
						{
							Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString().Replace("\\", "\\\\"),
							"\\\\OculusTrayTool\\\\Music\\\\",
							this.ComboMusic.Text,
							",",
							Conversions.ToString(decimal.Multiply(this.NumericVolume.Value, 10m))
						}));
						streamWriter2.Close();
						Log.WriteToLog("Homeless background music set to " + this.ComboMusic.Text);
						Log.WriteToLog("Homeless background volume set to " + Conversions.ToString(this.NumericVolume.Value) + "%");
					}
				}
				else
				{
					bool flag3 = File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
					if (flag3)
					{
						File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
						Log.WriteToLog("Homeless background music disabled");
					}
				}
				MySettingsProperty.Settings.HomlessColor = text;
				MySettingsProperty.Settings.HomelessVolume = Convert.ToInt32(decimal.Multiply(this.NumericVolume.Value, 10m));
				MySettingsProperty.Settings.Save();
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				bool flag4 = processesByName.Length > 0;
				if (flag4)
				{
					Process[] processesByName2 = Process.GetProcessesByName("Home2-Win64-Shipping");
					bool flag5 = processesByName2.Length > 0;
					if (flag5)
					{
						Log.WriteToLog("Killing Home2-Win64-Shipping.exe");
						foreach (Process process in processesByName2)
						{
							process.Kill();
							process.WaitForExit();
						}
					}
					Thread.Sleep(1000);
					Process[] processesByName3 = Process.GetProcessesByName("Home2-Win64-Shipping");
					bool flag6 = processesByName3.Length == 0;
					if (flag6)
					{
						Log.WriteToLog("Restarting Home2-Win64-Shipping.exe");
						Process.Start(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
					}
				}
				this.Cursor = Cursors.Default;
				base.Close();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Could save settings: " + ex.Message);
				Interaction.MsgBox("Could save settings: " + ex.Message, MsgBoxStyle.Critical, "Error saving settings");
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00012650 File Offset: 0x00010850
		private void BtnBrowseMusic_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = !Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
				if (flag)
				{
					Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
					Log.WriteToLog("Created " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
				}
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = true;
				openFileDialog.Filter = "MP3 Music (*.mp3)|*.mp3";
				bool flag2 = openFileDialog.ShowDialog() == DialogResult.OK;
				if (flag2)
				{
					string text = this.ComboMusic.Text;
					foreach (string text2 in openFileDialog.FileNames)
					{
						File.Copy(text2, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + Path.GetFileName(text2).Replace(" ", ""));
						Log.WriteToLog(string.Concat(new string[]
						{
							"Copied ",
							text2,
							" to ",
							Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
							"\\OculusTrayTool\\Music"
						}));
					}
					bool flag3 = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
					if (flag3)
					{
						this.ComboMusic.Items.Clear();
						string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
						foreach (string text3 in files)
						{
							this.ComboMusic.Items.Add(Path.GetFileName(text3));
						}
					}
					this.ComboMusic.Items.Add("None");
					this.ComboMusic.Text = text;
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Could not add music file: " + ex.Message);
				Interaction.MsgBox("Could not add music file: " + ex.Message, MsgBoxStyle.Critical, "Error adding music");
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0001288C File Offset: 0x00010A8C
		private void ComboMusic_SelectedIndexChanged(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.HomelessMusic = this.ComboMusic.Text;
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000128B0 File Offset: 0x00010AB0
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.CheckBox1.Checked;
			if (@checked)
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
}
