using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000026 RID: 38
	[DesignerGenerated]
	public partial class frmProcessing : Form
	{
		// Token: 0x060003D5 RID: 981 RVA: 0x000170AE File Offset: 0x000152AE
		public frmProcessing()
		{
			this.components = null;
			this.InitializeComponent();
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00008AF8 File Offset: 0x00006CF8
		private void frmProcessing_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000170C8 File Offset: 0x000152C8
		public void UpdateProgressBar(int percent, string message)
		{
			bool invokeRequired = this.progressBar1.InvokeRequired;
			if (invokeRequired)
			{
				frmProcessing.UpdateProgressBarDelegate updateProgressBarDelegate = new frmProcessing.UpdateProgressBarDelegate(this.UpdateProgressBar);
				base.Invoke(updateProgressBarDelegate, new object[] { percent, message });
			}
			else
			{
				this.progressBar1.Message = message;
				this.progressBar1.Value = MathTools.Clamp<int>(percent, 0, 100);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00017134 File Offset: 0x00015334
		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00017148 File Offset: 0x00015348
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle = createParams.ExStyle | 134217728 | 8;
				return createParams;
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00017178 File Offset: 0x00015378
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

		// Token: 0x0200006E RID: 110
		// (Invoke) Token: 0x06000A24 RID: 2596
		public delegate void UpdateProgressBarDelegate(int percent, string message);
	}
}
