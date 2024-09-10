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
	// Token: 0x0200004C RID: 76
	[DesignerGenerated]
	public partial class frmStillRunningToast : Form
	{
		// Token: 0x060005AE RID: 1454 RVA: 0x0002E234 File Offset: 0x0002C434
		public frmStillRunningToast()
		{
			base.Click += this.StillRunningToast_Click;
			base.Load += this.StillRunningToast_Load;
			this.InitializeComponent();
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x0002E61D File Offset: 0x0002C81D
		// (set) Token: 0x060005B2 RID: 1458 RVA: 0x0002E628 File Offset: 0x0002C828
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

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0002E66B File Offset: 0x0002C86B
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0002E678 File Offset: 0x0002C878
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

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0002E6BB File Offset: 0x0002C8BB
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x0002E6C8 File Offset: 0x0002C8C8
		internal virtual PictureBox PictureBox1
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
				PictureBox pictureBox = this._PictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox1 = value;
				pictureBox = this._PictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0002E70B File Offset: 0x0002C90B
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x0002E718 File Offset: 0x0002C918
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

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0002E75B File Offset: 0x0002C95B
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x0002E768 File Offset: 0x0002C968
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

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0002E7AB File Offset: 0x0002C9AB
		// (set) Token: 0x060005BC RID: 1468 RVA: 0x0002E7B5 File Offset: 0x0002C9B5
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0002E7BE File Offset: 0x0002C9BE
		private void StillRunningToast_Click(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.ShowStillRunning = false;
			MySettingsProperty.Settings.Save();
			base.Close();
			base.Dispose();
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0002E7E8 File Offset: 0x0002C9E8
		private void StillRunningToast_Load(object sender, EventArgs e)
		{
			base.Location = checked(new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height));
			this.Timer2.Start();
			Application.DoEvents();
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0002E848 File Offset: 0x0002CA48
		private void Timer1_Tick(object sender, EventArgs e)
		{
			base.Opacity -= 0.06;
			bool flag = base.Opacity == 0.0;
			if (flag)
			{
				base.Close();
				base.Dispose();
			}
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0002E892 File Offset: 0x0002CA92
		private void Timer2_Tick(object sender, EventArgs e)
		{
			this.Timer2.Stop();
			this.Timer1.Start();
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0002E8AD File Offset: 0x0002CAAD
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.ShowStillRunning = false;
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0002E8AD File Offset: 0x0002CAAD
		private void Label1_Click(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.ShowStillRunning = false;
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0002E8AD File Offset: 0x0002CAAD
		private void Label2_Click(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.ShowStillRunning = false;
			MySettingsProperty.Settings.Save();
		}
	}
}
