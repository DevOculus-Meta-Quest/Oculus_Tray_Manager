using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000058 RID: 88
	[DesignerGenerated]
	public partial class FrmSetFallback : Form
	{
		// Token: 0x060008A1 RID: 2209 RVA: 0x0004FA84 File Offset: 0x0004DC84
		public FrmSetFallback()
		{
			base.Load += this.SetFallback_Load;
			this.ComboAudioFallbackSource = new Dictionary<string, string>();
			this.ComboMicFallbackSource = new Dictionary<string, string>();
			this.InitializeComponent();
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x00050F4F File Offset: 0x0004F14F
		// (set) Token: 0x060008A5 RID: 2213 RVA: 0x00050F59 File Offset: 0x0004F159
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x00050F62 File Offset: 0x0004F162
		// (set) Token: 0x060008A7 RID: 2215 RVA: 0x00050F6C File Offset: 0x0004F16C
		internal virtual ComboBox ComboMicFallback
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x00050F75 File Offset: 0x0004F175
		// (set) Token: 0x060008A9 RID: 2217 RVA: 0x00050F7F File Offset: 0x0004F17F
		internal virtual ComboBox ComboAudioFallback
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00050F88 File Offset: 0x0004F188
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x00050F92 File Offset: 0x0004F192
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x00050F9B File Offset: 0x0004F19B
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x00050FA5 File Offset: 0x0004F1A5
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00050FAE File Offset: 0x0004F1AE
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x00050FB8 File Offset: 0x0004F1B8
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

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00050FFB File Offset: 0x0004F1FB
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x00051008 File Offset: 0x0004F208
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

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0005104B File Offset: 0x0004F24B
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x00051058 File Offset: 0x0004F258
		internal virtual ComboBox ComboBox2
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox2_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox2;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox2 = value;
				comboBox = this._ComboBox2;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x0005109B File Offset: 0x0004F29B
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x000510A8 File Offset: 0x0004F2A8
		internal virtual ComboBox ComboBox1
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
				ComboBox comboBox = this._ComboBox1;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboBox1 = value;
				comboBox = this._ComboBox1;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x000510EB File Offset: 0x0004F2EB
		// (set) Token: 0x060008B7 RID: 2231 RVA: 0x000510F5 File Offset: 0x0004F2F5
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x000510FE File Offset: 0x0004F2FE
		// (set) Token: 0x060008B9 RID: 2233 RVA: 0x00051108 File Offset: 0x0004F308
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x00051111 File Offset: 0x0004F311
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x0005111C File Offset: 0x0004F31C
		internal virtual Button Button3
		{
			[CompilerGenerated]
			get
			{
				return this._Button3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button3_Click);
				Button button = this._Button3;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button3 = value;
				button = this._Button3;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x0005115F File Offset: 0x0004F35F
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x00051169 File Offset: 0x0004F369
		internal virtual ComboBox ComboCommFallback
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x00051172 File Offset: 0x0004F372
		// (set) Token: 0x060008BF RID: 2239 RVA: 0x0005117C File Offset: 0x0004F37C
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00051185 File Offset: 0x0004F385
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0005118F File Offset: 0x0004F38F
		internal virtual GroupBox GroupBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x00051198 File Offset: 0x0004F398
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x000511A2 File Offset: 0x0004F3A2
		internal virtual GroupBox GroupBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x000511AB File Offset: 0x0004F3AB
		// (set) Token: 0x060008C5 RID: 2245 RVA: 0x000511B5 File Offset: 0x0004F3B5
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x000511BE File Offset: 0x0004F3BE
		// (set) Token: 0x060008C7 RID: 2247 RVA: 0x000511C8 File Offset: 0x0004F3C8
		internal virtual ComboBox ComboCommMicFallback
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x000511D1 File Offset: 0x0004F3D1
		// (set) Token: 0x060008C9 RID: 2249 RVA: 0x000511DB File Offset: 0x0004F3DB
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x000511E4 File Offset: 0x0004F3E4
		// (set) Token: 0x060008CB RID: 2251 RVA: 0x000511EE File Offset: 0x0004F3EE
		internal virtual ComboBox ComboBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x000511F7 File Offset: 0x0004F3F7
		// (set) Token: 0x060008CD RID: 2253 RVA: 0x00051201 File Offset: 0x0004F401
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x0005120A File Offset: 0x0004F40A
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x00051214 File Offset: 0x0004F414
		internal virtual ComboBox ComboBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x0005121D File Offset: 0x0004F41D
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x00051227 File Offset: 0x0004F427
		internal virtual Label Label9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x00051230 File Offset: 0x0004F430
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0005123A File Offset: 0x0004F43A
		internal virtual GroupBox GroupBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x00051243 File Offset: 0x0004F443
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x0005124D File Offset: 0x0004F44D
		internal virtual GroupBox GroupBox5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x00051256 File Offset: 0x0004F456
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x00051260 File Offset: 0x0004F460
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x00051269 File Offset: 0x0004F469
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x00051273 File Offset: 0x0004F473
		internal virtual ComboBox ComboBox5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x0005127C File Offset: 0x0004F47C
		// (set) Token: 0x060008DB RID: 2267 RVA: 0x00051286 File Offset: 0x0004F486
		internal virtual ComboBox ComboBox6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x0005128F File Offset: 0x0004F48F
		// (set) Token: 0x060008DD RID: 2269 RVA: 0x00051299 File Offset: 0x0004F499
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x000512A2 File Offset: 0x0004F4A2
		// (set) Token: 0x060008DF RID: 2271 RVA: 0x000512AC File Offset: 0x0004F4AC
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x000512B8 File Offset: 0x0004F4B8
		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.ComboBox6.SelectedItem != null;
				if (flag)
				{
					bool flag2 = Operators.CompareString(this.ComboBox6.Text, "Use current default", false) == 0;
					if (flag2)
					{
						MySettingsProperty.Settings.SetAudioOnStart = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
						MySettingsProperty.Settings.SetAudioOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart.ToString() + "' as current default audio device (on startup)");
					}
					else
					{
						string key = ((KeyValuePair<string, string>)this.ComboBox6.SelectedItem).Key;
						string value = ((KeyValuePair<string, string>)this.ComboBox6.SelectedItem).Value;
						MySettingsProperty.Settings.SetAudioOnStart = value;
						MySettingsProperty.Settings.SetAudioOnStartGuid = key;
					}
				}
				bool flag3 = this.ComboAudioFallback.SelectedItem != null;
				if (flag3)
				{
					bool flag4 = Operators.CompareString(this.ComboAudioFallback.Text, "Use current default", false) == 0;
					if (flag4)
					{
						MySettingsProperty.Settings.DefaultAudio = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
						MySettingsProperty.Settings.SystemDefaultAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultAudio + "' as current default audio device (on exit)");
					}
					else
					{
						string key2 = ((KeyValuePair<string, string>)this.ComboAudioFallback.SelectedItem).Key;
						string value2 = ((KeyValuePair<string, string>)this.ComboAudioFallback.SelectedItem).Value;
						MySettingsProperty.Settings.DefaultAudio = value2;
						MySettingsProperty.Settings.SystemDefaultAudioGuid = key2;
					}
				}
				bool flag5 = this.ComboBox5.SelectedItem != null;
				if (flag5)
				{
					bool flag6 = Operators.CompareString(this.ComboBox5.Text, "Use current default", false) == 0;
					if (flag6)
					{
						MySettingsProperty.Settings.SetMicOnStart = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
						MySettingsProperty.Settings.SetMicOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetMicOnStart + "' as current default mic device (on startup)");
					}
					else
					{
						string key3 = ((KeyValuePair<string, string>)this.ComboBox5.SelectedItem).Key;
						string value3 = ((KeyValuePair<string, string>)this.ComboBox5.SelectedItem).Value;
						MySettingsProperty.Settings.SetMicOnStart = value3;
						MySettingsProperty.Settings.SetMicOnStartGuid = key3;
					}
				}
				bool flag7 = this.ComboMicFallback.SelectedItem != null;
				if (flag7)
				{
					bool flag8 = Operators.CompareString(this.ComboMicFallback.Text, "Use current default", false) == 0;
					if (flag8)
					{
						MySettingsProperty.Settings.DefaultMic = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
						MySettingsProperty.Settings.SystemDefaultMicGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultMic + "' as current default mic device (on exit)");
					}
					else
					{
						string key4 = ((KeyValuePair<string, string>)this.ComboMicFallback.SelectedItem).Key;
						string value4 = ((KeyValuePair<string, string>)this.ComboMicFallback.SelectedItem).Value;
						MySettingsProperty.Settings.DefaultMic = value4;
						MySettingsProperty.Settings.SystemDefaultMicGuid = key4;
					}
				}
				bool flag9 = this.ComboBox4.SelectedItem != null;
				if (flag9)
				{
					bool flag10 = Operators.CompareString(this.ComboBox4.Text, "Use current default", false) == 0;
					if (flag10)
					{
						MySettingsProperty.Settings.SetAudioCommOnStart = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
						MySettingsProperty.Settings.SetAudioCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioCommOnStart + "' as current default audio comm device (on startup)");
					}
					else
					{
						string key5 = ((KeyValuePair<string, string>)this.ComboBox4.SelectedItem).Key;
						string value5 = ((KeyValuePair<string, string>)this.ComboBox4.SelectedItem).Value;
						MySettingsProperty.Settings.SetAudioCommOnStart = value5;
						MySettingsProperty.Settings.SetAudioCommOnStartGuid = key5;
					}
				}
				bool flag11 = this.ComboCommFallback.SelectedItem != null;
				if (flag11)
				{
					bool flag12 = Operators.CompareString(this.ComboCommFallback.Text, "Use current default", false) == 0;
					if (flag12)
					{
						MySettingsProperty.Settings.DefaultCommAudio = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
						MySettingsProperty.Settings.SystemDefaultCommAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultCommAudio + "' as current default audio comm device (on exit)");
					}
					else
					{
						string key6 = ((KeyValuePair<string, string>)this.ComboCommFallback.SelectedItem).Key;
						string value6 = ((KeyValuePair<string, string>)this.ComboCommFallback.SelectedItem).Value;
						MySettingsProperty.Settings.DefaultCommAudio = value6;
						MySettingsProperty.Settings.SystemDefaultCommAudioGuid = key6;
					}
				}
				bool flag13 = this.ComboBox3.SelectedItem != null;
				if (flag13)
				{
					bool flag14 = Operators.CompareString(this.ComboBox3.Text, "Use current default", false) == 0;
					if (flag14)
					{
						MySettingsProperty.Settings.SetMicCommOnStart = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
						MySettingsProperty.Settings.SetMicCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart + "' as current mic comm device (on startup)");
					}
					else
					{
						string key7 = ((KeyValuePair<string, string>)this.ComboBox3.SelectedItem).Key;
						string value7 = ((KeyValuePair<string, string>)this.ComboBox3.SelectedItem).Value;
						MySettingsProperty.Settings.SetMicCommOnStart = value7;
						MySettingsProperty.Settings.SetMicCommOnStartGuid = key7;
					}
				}
				bool flag15 = this.ComboCommMicFallback.SelectedItem != null;
				if (flag15)
				{
					bool flag16 = Operators.CompareString(this.ComboCommFallback.Text, "Use current default", false) == 0;
					if (flag16)
					{
						MySettingsProperty.Settings.DefaultComm = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
						MySettingsProperty.Settings.SystemDefaultCommGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
						Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultComm + "' as current mic comm device (on exit)");
					}
					else
					{
						string key8 = ((KeyValuePair<string, string>)this.ComboCommMicFallback.SelectedItem).Key;
						string value8 = ((KeyValuePair<string, string>)this.ComboCommMicFallback.SelectedItem).Value;
						MySettingsProperty.Settings.DefaultComm = value8;
						MySettingsProperty.Settings.SystemDefaultCommGuid = key8;
					}
				}
				MySettingsProperty.Settings.Save();
				bool flag17 = (Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, null, false) != 0) & (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, null, false) != 0);
				if (flag17)
				{
					MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = true;
				}
				else
				{
					MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = false;
					MyProject.Forms.FrmMain.ToolStripMenuItem3.ToolTipText = "No fallback devices has been selected in the AudioSwitcher configuration";
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Error setting Audio fallback device: " + ex.Message);
				Interaction.MsgBox("Error setting Audio fallback device: " + ex.Message, MsgBoxStyle.Critical, "Error");
			}
			base.Close();
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00051A64 File Offset: 0x0004FC64
		private void SetFallback_Load(object sender, EventArgs e)
		{
			GetConfig.IsReading = true;
			this.ComboBox1.SelectedIndex = MySettingsProperty.Settings.SetRiftAudioDefault;
			this.ComboBox2.SelectedIndex = MySettingsProperty.Settings.SetRiftMicDefault;
			this.ComboAudioFallback.Text = MySettingsProperty.Settings.DefaultAudio;
			this.ComboMicFallback.Text = MySettingsProperty.Settings.DefaultMic;
			this.ComboCommFallback.Text = MySettingsProperty.Settings.DefaultCommAudio;
			this.ComboCommMicFallback.Text = MySettingsProperty.Settings.DefaultComm;
			this.ComboBox3.Text = MySettingsProperty.Settings.SetMicCommOnStart;
			this.ComboBox4.Text = MySettingsProperty.Settings.SetAudioCommOnStart;
			this.ComboBox5.Text = MySettingsProperty.Settings.SetMicOnStart;
			this.ComboBox6.Text = MySettingsProperty.Settings.SetAudioOnStart;
			GetConfig.IsReading = false;
			MyProject.Forms.FrmMain.Cursor = Cursors.Default;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00051B70 File Offset: 0x0004FD70
		private void Button2_Click(object sender, EventArgs e)
		{
			Log.WriteToLog("Resetting AudioSwitcher settings..");
			GetConfig.IsReading = true;
			this.Cursor = Cursors.WaitCursor;
			this.ComboAudioFallback.Text = "";
			this.ComboMicFallback.Text = "";
			this.ComboCommFallback.Text = Conversions.ToString(this.ComboBox1.SelectedIndex == 0);
			this.ComboBox2.SelectedIndex = 0;
			GetConfig.IsReading = false;
			MySettingsProperty.Settings.DefaultAudio = null;
			MySettingsProperty.Settings.DefaultMic = null;
			MySettingsProperty.Settings.DefaultComm = null;
			MySettingsProperty.Settings.DefaultCommAudio = null;
			MySettingsProperty.Settings.SystemDefaultAudioGuid = null;
			MySettingsProperty.Settings.SystemDefaultMicGuid = null;
			MySettingsProperty.Settings.SystemDefaultCommGuid = null;
			MySettingsProperty.Settings.RiftMicGuid = null;
			MySettingsProperty.Settings.RiftAudioGuid = null;
			MySettingsProperty.Settings.SetMicCommOnStart = null;
			MySettingsProperty.Settings.SetAudioCommOnStart = null;
			MySettingsProperty.Settings.SetMicOnStart = null;
			MySettingsProperty.Settings.SetAudioOnStart = null;
			MySettingsProperty.Settings.SetMicCommOnStartGuid = null;
			MySettingsProperty.Settings.SetAudioCommOnStartGuid = null;
			MySettingsProperty.Settings.SetMicOnStartGuid = null;
			MySettingsProperty.Settings.SetAudioOnStartGuid = null;
			MySettingsProperty.Settings.SetRiftMicDefault = 0;
			MySettingsProperty.Settings.SetRiftAudioDefault = 0;
			MySettingsProperty.Settings.Save();
			GetDevices.GetAllAudioDevices();
			GetDevices.GetAllMicDevices();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00051CF8 File Offset: 0x0004FEF8
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.SetRiftAudioDefault = this.ComboBox1.SelectedIndex;
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00051D38 File Offset: 0x0004FF38
		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.SetRiftMicDefault = this.ComboBox2.SelectedIndex;
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button3_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040003CA RID: 970
		public Dictionary<string, string> ComboAudioFallbackSource;

		// Token: 0x040003CB RID: 971
		public Dictionary<string, string> ComboMicFallbackSource;
	}
}
