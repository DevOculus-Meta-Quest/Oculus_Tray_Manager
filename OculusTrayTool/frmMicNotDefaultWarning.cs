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
	// Token: 0x02000025 RID: 37
	[DesignerGenerated]
	public partial class frmMicNotDefaultWarning : Form
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x00016B7A File Offset: 0x00014D7A
		public frmMicNotDefaultWarning()
		{
			base.Load += this.frmMicNotDefaultWarning_Load;
			this.InitializeComponent();
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060003CA RID: 970 RVA: 0x00016E5C File Offset: 0x0001505C
		// (set) Token: 0x060003CB RID: 971 RVA: 0x00016E66 File Offset: 0x00015066
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060003CC RID: 972 RVA: 0x00016E6F File Offset: 0x0001506F
		// (set) Token: 0x060003CD RID: 973 RVA: 0x00016E7C File Offset: 0x0001507C
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

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00016EBF File Offset: 0x000150BF
		// (set) Token: 0x060003CF RID: 975 RVA: 0x00016ECC File Offset: 0x000150CC
		internal virtual CheckBox CheckBox1
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox1_CheckedChanged);
				CheckBox checkBox = this._CheckBox1;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckBox1 = value;
				checkBox = this._CheckBox1;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00016F10 File Offset: 0x00015110
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.CheckBox1.Checked;
			if (@checked)
			{
				MySettingsProperty.Settings.ShowMicNotDefaultWarning = false;
			}
			else
			{
				MySettingsProperty.Settings.ShowMicNotDefaultWarning = true;
			}
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00016F55 File Offset: 0x00015155
		private void frmMicNotDefaultWarning_Load(object sender, EventArgs e)
		{
			base.BringToFront();
		}
	}
}
