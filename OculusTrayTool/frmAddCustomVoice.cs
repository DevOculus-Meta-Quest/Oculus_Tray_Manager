using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000018 RID: 24
	[DesignerGenerated]
	public partial class frmAddCustomVoice : Form
	{
		// Token: 0x060001AD RID: 429 RVA: 0x00008154 File Offset: 0x00006354
		public frmAddCustomVoice()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00008952 File Offset: 0x00006B52
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x0000895C File Offset: 0x00006B5C
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00008965 File Offset: 0x00006B65
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x0000896F File Offset: 0x00006B6F
		internal virtual TextBox TextBoxSpokenCommand
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00008978 File Offset: 0x00006B78
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00008982 File Offset: 0x00006B82
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000898B File Offset: 0x00006B8B
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00008995 File Offset: 0x00006B95
		internal virtual TextBox TextBoxButtonCombo
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000899E File Offset: 0x00006B9E
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x000089A8 File Offset: 0x00006BA8
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

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000089EB File Offset: 0x00006BEB
		// (set) Token: 0x060001BB RID: 443 RVA: 0x000089F5 File Offset: 0x00006BF5
		internal virtual OpenFileDialog OpenFileDialog1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000089FE File Offset: 0x00006BFE
		// (set) Token: 0x060001BD RID: 445 RVA: 0x00008A08 File Offset: 0x00006C08
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00008A11 File Offset: 0x00006C11
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00008A1C File Offset: 0x00006C1C
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

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00008A5F File Offset: 0x00006C5F
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x00008A69 File Offset: 0x00006C69
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00008A72 File Offset: 0x00006C72
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00008A7C File Offset: 0x00006C7C
		internal virtual TextBox TextBoxSeconds
		{
			[CompilerGenerated]
			get
			{
				return this._TextBoxSeconds;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.TextBoxSeconds_KeyPress);
				TextBox textBox = this._TextBoxSeconds;
				if (textBox != null)
				{
					textBox.KeyPress -= keyPressEventHandler;
				}
				this._TextBoxSeconds = value;
				textBox = this._TextBoxSeconds;
				if (textBox != null)
				{
					textBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00008ABF File Offset: 0x00006CBF
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x00008AC9 File Offset: 0x00006CC9
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00008AD2 File Offset: 0x00006CD2
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00008ADC File Offset: 0x00006CDC
		internal virtual RadioButton RadioButton2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00008AE5 File Offset: 0x00006CE5
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00008AEF File Offset: 0x00006CEF
		internal virtual RadioButton RadioButton1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00008AF8 File Offset: 0x00006CF8
		private void Button2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00008B08 File Offset: 0x00006D08
		private void TextBoxSeconds_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = (Strings.Asc(e.KeyChar) != 8) & (Strings.Asc(e.KeyChar) != 127) & (Strings.Asc(e.KeyChar) != 44);
			if (flag)
			{
				bool flag2 = (Strings.Asc(e.KeyChar) < 48) | (Strings.Asc(e.KeyChar) > 57);
				if (flag2)
				{
					e.Handled = true;
				}
			}
		}

		// Token: 0x0400005B RID: 91
		public int id;

		// Token: 0x0400005C RID: 92
		public string VoiceProfileName;

		// Token: 0x0400005D RID: 93
		public string VoiceProfileGameProfile;
	}
}
