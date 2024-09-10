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
	// Token: 0x02000019 RID: 25
	[DesignerGenerated]
	public partial class frmAddVoiceProfile : Form
	{
		// Token: 0x060001CD RID: 461 RVA: 0x00008B82 File Offset: 0x00006D82
		public frmAddVoiceProfile()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x0000908C File Offset: 0x0000728C
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x00009096 File Offset: 0x00007296
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000909F File Offset: 0x0000729F
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x000090A9 File Offset: 0x000072A9
		internal virtual TextBox TextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x000090B2 File Offset: 0x000072B2
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x000090BC File Offset: 0x000072BC
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x000090C5 File Offset: 0x000072C5
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x000090CF File Offset: 0x000072CF
		internal virtual ComboBox ComboBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x000090D8 File Offset: 0x000072D8
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x000090E2 File Offset: 0x000072E2
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001DA RID: 474 RVA: 0x000090EB File Offset: 0x000072EB
		// (set) Token: 0x060001DB RID: 475 RVA: 0x000090F8 File Offset: 0x000072F8
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

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000913B File Offset: 0x0000733B
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00009148 File Offset: 0x00007348
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

		// Token: 0x060001DE RID: 478 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000918C File Offset: 0x0000738C
		private void Button2_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmAddCustomVoice.VoiceProfileName = this.TextBox1.Text;
			MyProject.Forms.frmAddCustomVoice.VoiceProfileGameProfile = this.ComboBox1.Text;
			MyProject.Forms.frmAddCustomVoice.ShowDialog();
			base.Close();
		}
	}
}
