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
	// Token: 0x02000050 RID: 80
	[DesignerGenerated]
	public partial class frmLoading : Form
	{
		// Token: 0x060007C2 RID: 1986 RVA: 0x00046DAE File Offset: 0x00044FAE
		public frmLoading()
		{
			base.Load += this.Loading_Load;
			base.FormClosing += this.frmLoading_FormClosing;
			this.InitializeComponent();
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x000470F7 File Offset: 0x000452F7
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x00047104 File Offset: 0x00045304
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

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x00047147 File Offset: 0x00045347
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x00047154 File Offset: 0x00045354
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

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x00047197 File Offset: 0x00045397
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x000471A1 File Offset: 0x000453A1
		internal virtual PictureBox PictureBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x000471AC File Offset: 0x000453AC
		private void Loading_Load(object sender, EventArgs e)
		{
			base.Location = checked(new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height));
			Win32.AnimateWindow(base.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_NEGATIVE | Win32.AnimateWindowFlags.AW_SLIDE);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00008AF8 File Offset: 0x00006CF8
		private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00047210 File Offset: 0x00045410
		private void Label1_Click(object sender, EventArgs e)
		{
			bool loadingDone = MyProject.Forms.FrmMain.loadingDone;
			if (loadingDone)
			{
				MyProject.Forms.FrmMain.ShowForm();
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x00047244 File Offset: 0x00045444
		private void Label2_Click(object sender, EventArgs e)
		{
			bool loadingDone = MyProject.Forms.FrmMain.loadingDone;
			if (loadingDone)
			{
				MyProject.Forms.FrmMain.ShowForm();
			}
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00047278 File Offset: 0x00045478
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			bool loadingDone = MyProject.Forms.FrmMain.loadingDone;
			if (loadingDone)
			{
				MyProject.Forms.FrmMain.ShowForm();
			}
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x000472AB File Offset: 0x000454AB
		public void CloseStartupToast()
		{
			Win32.AnimateWindow(base.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_POSITIVE | Win32.AnimateWindowFlags.AW_HIDE | Win32.AnimateWindowFlags.AW_SLIDE);
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x000472C4 File Offset: 0x000454C4
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle = createParams.ExStyle | 134217728 | 8;
				return createParams;
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x000472F4 File Offset: 0x000454F4
		protected override void WndProc(ref Message msg)
		{
			int msg2 = msg.Msg;
			if (msg2 != 33)
			{
				base.WndProc(ref msg);
			}
			else
			{
				msg.Result = (IntPtr)3;
			}
		}
	}
}
