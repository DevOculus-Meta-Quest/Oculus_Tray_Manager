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
	// Token: 0x0200001E RID: 30
	[DesignerGenerated]
	public partial class frmDownloading : Form
	{
		// Token: 0x06000279 RID: 633 RVA: 0x0000DE0C File Offset: 0x0000C00C
		public frmDownloading()
		{
			base.Load += this.frmDownloading_Load;
			this.InitializeComponent();
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600027C RID: 636 RVA: 0x0000DF9B File Offset: 0x0000C19B
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000DFA5 File Offset: 0x0000C1A5
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000DFB0 File Offset: 0x0000C1B0
		public void UpdateLabel(string text)
		{
			bool invokeRequired = this.Label1.InvokeRequired;
			if (invokeRequired)
			{
				frmDownloading.UpdateLabel_delegate updateLabel_delegate = new frmDownloading.UpdateLabel_delegate(this.UpdateLabel);
				this.Label1.BeginInvoke(updateLabel_delegate, new object[] { text });
			}
			else
			{
				this.Label1.Text = text;
				this.Label1.Update();
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000E00F File Offset: 0x0000C20F
		private void frmDownloading_Load(object sender, EventArgs e)
		{
			frmDownloading.CenterForm(this, MyProject.Forms.frmLibrary);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000E024 File Offset: 0x0000C224
		public static void CenterForm(Form frm, Form parent = null)
		{
			bool flag = parent != null;
			Rectangle rectangle;
			if (flag)
			{
				rectangle = parent.RectangleToScreen(parent.ClientRectangle);
			}
			else
			{
				rectangle = Screen.FromPoint(frm.Location).WorkingArea;
			}
			checked
			{
				int num = rectangle.Left + (rectangle.Width - frm.Width) / 2;
				int num2 = rectangle.Top + (rectangle.Height - frm.Height) / 2;
				frm.Location = new Point(num, num2);
			}
		}

		// Token: 0x02000068 RID: 104
		// (Invoke) Token: 0x06000A0D RID: 2573
		public delegate void UpdateLabel_delegate(string text);
	}
}
