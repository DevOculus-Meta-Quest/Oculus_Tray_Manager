using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool
{
	// Token: 0x0200004D RID: 77
	[DesignerGenerated]
	public partial class frmUpdateToast : Form
	{
		// Token: 0x060005C4 RID: 1476 RVA: 0x0002E8C7 File Offset: 0x0002CAC7
		public frmUpdateToast()
		{
			base.Load += this.UpdateToast_Load;
			base.Click += this.UpdateToast_Click;
			this.InitializeComponent();
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0002EC66 File Offset: 0x0002CE66
		// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0002EC70 File Offset: 0x0002CE70
		internal virtual Label Label1
		{
			[CompilerGenerated]
			get
			{
				return this._Label1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Label1_Click);
				Label label = this._Label1;
				if (label != null)
				{
					label.Click -= eventHandler;
				}
				this._Label1 = value;
				label = this._Label1;
				if (label != null)
				{
					label.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0002ECB3 File Offset: 0x0002CEB3
		// (set) Token: 0x060005CA RID: 1482 RVA: 0x0002ECC0 File Offset: 0x0002CEC0
		internal virtual Label Label2
		{
			[CompilerGenerated]
			get
			{
				return this._Label2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Label2_Click);
				Label label = this._Label2;
				if (label != null)
				{
					label.Click -= eventHandler;
				}
				this._Label2 = value;
				label = this._Label2;
				if (label != null)
				{
					label.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0002ED03 File Offset: 0x0002CF03
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x0002ED10 File Offset: 0x0002CF10
		internal virtual Timer Timer1
		{
			[CompilerGenerated]
			get
			{
				return this._Timer1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
				Timer timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._Timer1 = value;
				timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0002ED53 File Offset: 0x0002CF53
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0002ED60 File Offset: 0x0002CF60
		internal virtual Timer Timer2
		{
			[CompilerGenerated]
			get
			{
				return this._Timer2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Timer2_Tick);
				Timer timer = this._Timer2;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._Timer2 = value;
				timer = this._Timer2;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0002EDA3 File Offset: 0x0002CFA3
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0002EDAD File Offset: 0x0002CFAD
		internal virtual PictureBox PictureBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0002EDB8 File Offset: 0x0002CFB8
		private void UpdateToast_Load(object sender, EventArgs e)
		{
			base.Location = checked(new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height));
			this.Timer1.Enabled = true;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0002EE11 File Offset: 0x0002D011
		private void Timer1_Tick(object sender, EventArgs e)
		{
			this.Timer1.Enabled = false;
			this.Timer2.Enabled = true;
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0002EE30 File Offset: 0x0002D030
		private void Timer2_Tick(object sender, EventArgs e)
		{
			base.Opacity -= 0.06;
			bool flag = base.Opacity == 0.0;
			if (flag)
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Timer expired");
				}
			}
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0002EE80 File Offset: 0x0002D080
		private void UpdateToast_Click(object sender, EventArgs e)
		{
			MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
			MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
			base.Close();
			base.Dispose();
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0002EE80 File Offset: 0x0002D080
		private void Label1_Click(object sender, EventArgs e)
		{
			MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
			MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
			base.Close();
			base.Dispose();
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0002EE80 File Offset: 0x0002D080
		private void Label2_Click(object sender, EventArgs e)
		{
			MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
			MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
			base.Close();
			base.Dispose();
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0002EE80 File Offset: 0x0002D080
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
			MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
			base.Close();
			base.Dispose();
		}
	}
}
