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
	// Token: 0x02000041 RID: 65
	[DesignerGenerated]
	public partial class frmRemoveProgress : Form
	{
		// Token: 0x06000577 RID: 1399 RVA: 0x0002CBDC File Offset: 0x0002ADDC
		public frmRemoveProgress()
		{
			base.Load += this.RemoveProgress_Load;
			this.InitializeComponent();
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0002CE1E File Offset: 0x0002B01E
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0002CE28 File Offset: 0x0002B028
		internal virtual ListBox ListBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0002CE31 File Offset: 0x0002B031
		// (set) Token: 0x0600057D RID: 1405 RVA: 0x0002CE3C File Offset: 0x0002B03C
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

		// Token: 0x0600057E RID: 1406 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0002CE7F File Offset: 0x0002B07F
		private void RemoveProgress_Load(object sender, EventArgs e)
		{
			CenterForms.CenterForm(this, MyProject.Forms.frmLibrary);
		}
	}
}
