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
	// Token: 0x0200004B RID: 75
	[DesignerGenerated]
	public partial class frmStartupType : Form
	{
		// Token: 0x060005A0 RID: 1440 RVA: 0x0002DC62 File Offset: 0x0002BE62
		public frmStartupType()
		{
			this.InitializeComponent();
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0002E099 File Offset: 0x0002C299
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0002E0A3 File Offset: 0x0002C2A3
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0002E0AC File Offset: 0x0002C2AC
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0002E0B6 File Offset: 0x0002C2B6
		internal virtual RadioButton RadioButton1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0002E0BF File Offset: 0x0002C2BF
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0002E0C9 File Offset: 0x0002C2C9
		internal virtual RadioButton RadioButton2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0002E0D2 File Offset: 0x0002C2D2
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x0002E0DC File Offset: 0x0002C2DC
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0002E0E5 File Offset: 0x0002C2E5
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x0002E0F0 File Offset: 0x0002C2F0
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

		// Token: 0x060005AD RID: 1453 RVA: 0x0002E134 File Offset: 0x0002C334
		private void Button1_Click(object sender, EventArgs e)
		{
			bool @checked = this.RadioButton1.Checked;
			if (@checked)
			{
				bool flag = MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue(Application.ProductName) == null;
				if (flag)
				{
					try
					{
						MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue(Application.ProductName, Application.StartupPath + "\\OculusTrayTool.exe");
						MySettingsProperty.Settings.StartWithWindows = true;
						MySettingsProperty.Settings.Save();
						Log.WriteToLog("Enabled 'Start with Windows', startup type' Regular'");
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Could not enable 'Start with Windows', startup type' Regular': " + ex.Message);
					}
				}
			}
			bool checked2 = this.RadioButton2.Checked;
			if (checked2)
			{
				CreateTask.CreateScheduledTask(true);
			}
			base.Close();
		}
	}
}
