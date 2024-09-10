using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000030 RID: 48
	[DesignerGenerated]
	public partial class frmLaunchOptions : Form
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x000229FD File Offset: 0x00020BFD
		public frmLaunchOptions()
		{
			base.Load += this.LaunchOptions_Load;
			this.optionsCanceled = false;
			this.InitializeComponent();
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00022E33 File Offset: 0x00021033
		// (set) Token: 0x060004A1 RID: 1185 RVA: 0x00022E3D File Offset: 0x0002103D
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00022E46 File Offset: 0x00021046
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x00022E50 File Offset: 0x00021050
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

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00022E93 File Offset: 0x00021093
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00022EA0 File Offset: 0x000210A0
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

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00022EE3 File Offset: 0x000210E3
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x00022EED File Offset: 0x000210ED
		internal virtual TextBox TextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00022EF6 File Offset: 0x000210F6
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00022F00 File Offset: 0x00021100
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00022F09 File Offset: 0x00021109
		private void Button2_Click(object sender, EventArgs e)
		{
			this.optionsCanceled = true;
			base.Close();
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00022F1A File Offset: 0x0002111A
		private void Button1_Click(object sender, EventArgs e)
		{
			this.optionsCanceled = false;
			base.Hide();
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00022F2B File Offset: 0x0002112B
		private void LaunchOptions_Load(object sender, EventArgs e)
		{
			base.TopMost = true;
			base.Focus();
		}

		// Token: 0x040001BC RID: 444
		public bool optionsCanceled;
	}
}
