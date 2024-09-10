using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000020 RID: 32
	[DesignerGenerated]
	public partial class frmEditVoiceCommand : Form
	{
		// Token: 0x060002DB RID: 731 RVA: 0x00010A05 File Offset: 0x0000EC05
		public frmEditVoiceCommand()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0001100E File Offset: 0x0000F20E
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00011018 File Offset: 0x0000F218
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00011021 File Offset: 0x0000F221
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0001102B File Offset: 0x0000F22B
		internal virtual TextBox TextBoxPhrase
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00011034 File Offset: 0x0000F234
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x0001103E File Offset: 0x0000F23E
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00011047 File Offset: 0x0000F247
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00011051 File Offset: 0x0000F251
		internal virtual Label LabelAction
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x0001105A File Offset: 0x0000F25A
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00011064 File Offset: 0x0000F264
		internal virtual ComboBox ComboEnabled
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x0001106D File Offset: 0x0000F26D
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x00011077 File Offset: 0x0000F277
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00011080 File Offset: 0x0000F280
		// (set) Token: 0x060002EB RID: 747 RVA: 0x0001108A File Offset: 0x0000F28A
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00011093 File Offset: 0x0000F293
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000110A0 File Offset: 0x0000F2A0
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

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060002EE RID: 750 RVA: 0x000110E3 File Offset: 0x0000F2E3
		// (set) Token: 0x060002EF RID: 751 RVA: 0x000110F0 File Offset: 0x0000F2F0
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

		// Token: 0x060002F0 RID: 752 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00011134 File Offset: 0x0000F334
		private void Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.TextBoxPhrase.Text.EndsWith(";");
			if (flag)
			{
				this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.TrimEnd(new char[] { ';' });
			}
			this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.Replace(";;", ";");
			bool flag2 = Operators.CompareString(this.LabelAction.Text, "Enable Voice Control", false) == 0;
			if (flag2)
			{
				MySettingsProperty.Settings.StartVoice = this.TextBoxPhrase.Text;
			}
			bool flag3 = Operators.CompareString(this.LabelAction.Text, "Disable Voice Control", false) == 0;
			if (flag3)
			{
				MySettingsProperty.Settings.StopVoice = this.TextBoxPhrase.Text;
			}
			bool flag4 = Operators.CompareString(this.LabelAction.Text, "Set Pixel Density", false) == 0;
			if (flag4)
			{
				MySettingsProperty.Settings.SetPD = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.SetPDEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag5 = Operators.CompareString(this.LabelAction.Text, "Disable ASW", false) == 0;
			if (flag5)
			{
				MySettingsProperty.Settings.DisableASW = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.DisableASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag6 = Operators.CompareString(this.LabelAction.Text, "Enable ASW", false) == 0;
			if (flag6)
			{
				MySettingsProperty.Settings.EnableASW = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.EnableASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag7 = Operators.CompareString(this.LabelAction.Text, "45 fps, ASW On", false) == 0;
			if (flag7)
			{
				MySettingsProperty.Settings.LockASWOn = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.LockASWOnEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag8 = Operators.CompareString(this.LabelAction.Text, "Show ASW Status", false) == 0;
			if (flag8)
			{
				MySettingsProperty.Settings.ShowASW = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag9 = Operators.CompareString(this.LabelAction.Text, "Show Pixel Density", false) == 0;
			if (flag9)
			{
				MySettingsProperty.Settings.ShowPD = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowPDEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag10 = Operators.CompareString(this.LabelAction.Text, "Show Performance", false) == 0;
			if (flag10)
			{
				MySettingsProperty.Settings.ShowPerf = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowPerfEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag11 = Operators.CompareString(this.LabelAction.Text, "Show Latency Timing", false) == 0;
			if (flag11)
			{
				MySettingsProperty.Settings.ShowLatency = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowLatencyEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag12 = Operators.CompareString(this.LabelAction.Text, "Show Application Render Timing", false) == 0;
			if (flag12)
			{
				MySettingsProperty.Settings.ShowApplicationRender = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowApplicationRenderEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag13 = Operators.CompareString(this.LabelAction.Text, "Show Compositor Render Timing", false) == 0;
			if (flag13)
			{
				MySettingsProperty.Settings.ShowCompositorRender = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowCompositorRenderEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag14 = Operators.CompareString(this.LabelAction.Text, "Show Version Info", false) == 0;
			if (flag14)
			{
				MySettingsProperty.Settings.ShowVersion = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.ShowVersionEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag15 = Operators.CompareString(this.LabelAction.Text, "Close Overlay", false) == 0;
			if (flag15)
			{
				MySettingsProperty.Settings.Close = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.CloseEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			bool flag16 = Operators.CompareString(this.LabelAction.Text, "Launch SteamVR", false) == 0;
			if (flag16)
			{
				MySettingsProperty.Settings.LaunchSteam = this.TextBoxPhrase.Text;
				MySettingsProperty.Settings.LaunchSteamEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
			}
			MySettingsProperty.Settings.Save();
			MyProject.Forms.FrmMain.LoadVoiceSettings();
			MyProject.Forms.frmVoiceSettings.VoicechangeMade = true;
			base.Close();
		}
	}
}
