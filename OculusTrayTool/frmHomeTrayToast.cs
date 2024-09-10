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
	// Token: 0x0200002E RID: 46
	[DesignerGenerated]
	public partial class frmHomeTrayToast : Form
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x0001BC02 File Offset: 0x00019E02
		public frmHomeTrayToast()
		{
			base.Load += this.HomeTrayToast_Load;
			base.Click += this.HomeTrayToast_Click;
			this.InitializeComponent();
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0001BF9D File Offset: 0x0001A19D
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x0001BFA8 File Offset: 0x0001A1A8
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

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0001BFEB File Offset: 0x0001A1EB
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x0001BFF8 File Offset: 0x0001A1F8
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

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0001C03B File Offset: 0x0001A23B
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x0001C048 File Offset: 0x0001A248
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

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0001C08B File Offset: 0x0001A28B
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x0001C098 File Offset: 0x0001A298
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

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x0001C0DB File Offset: 0x0001A2DB
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x0001C0E8 File Offset: 0x0001A2E8
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

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0001C12B File Offset: 0x0001A32B
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0001C135 File Offset: 0x0001A335
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001C140 File Offset: 0x0001A340
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

		// Token: 0x06000414 RID: 1044 RVA: 0x0001C18A File Offset: 0x0001A38A
		private void Timer2_Tick(object sender, EventArgs e)
		{
			this.Timer2.Stop();
			this.Timer1.Start();
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001C1A5 File Offset: 0x0001A3A5
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			this.CloseMe();
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001C1A5 File Offset: 0x0001A3A5
		private void Label1_Click(object sender, EventArgs e)
		{
			this.CloseMe();
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0001C1A5 File Offset: 0x0001A3A5
		private void Label2_Click(object sender, EventArgs e)
		{
			this.CloseMe();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0001C1B0 File Offset: 0x0001A3B0
		private void HomeTrayToast_Load(object sender, EventArgs e)
		{
			base.Location = checked(new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height));
			this.Timer2.Start();
			Application.DoEvents();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0001C1A5 File Offset: 0x0001A3A5
		private void HomeTrayToast_Click(object sender, EventArgs e)
		{
			this.CloseMe();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001C210 File Offset: 0x0001A410
		private void CloseMe()
		{
			MySettingsProperty.Settings.ShowHomeToast = false;
			MySettingsProperty.Settings.Save();
			Log.WriteToLog("The notification toast that Oculus Home is minimized to the System Tray has been disabled.");
			Log.WriteToLog("To re-enable, set the property 'ShowHomeToast' to 'True' in the user.config file.");
			FrmMain.fmain.AddToListboxAndScroll("The notification toast that Oculus Home is minimized to the System Tray has been disabled.");
			FrmMain.fmain.AddToListboxAndScroll("To re-enable, set the property 'ShowHomeToast' to 'True' in the user.config file.");
			base.Close();
			base.Dispose();
		}
	}
}
