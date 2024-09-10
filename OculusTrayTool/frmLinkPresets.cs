using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000036 RID: 54
	[DesignerGenerated]
	public partial class frmLinkPresets : Form
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x000236BC File Offset: 0x000218BC
		public frmLinkPresets()
		{
			this.InitializeComponent();
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00023A80 File Offset: 0x00021C80
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x00023A8A File Offset: 0x00021C8A
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x00023A93 File Offset: 0x00021C93
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x00023A9D File Offset: 0x00021C9D
		internal virtual TextBox TextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x00023AA6 File Offset: 0x00021CA6
		// (set) Token: 0x060004DE RID: 1246 RVA: 0x00023AB0 File Offset: 0x00021CB0
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

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x00023AF3 File Offset: 0x00021CF3
		// (set) Token: 0x060004E0 RID: 1248 RVA: 0x00023B00 File Offset: 0x00021D00
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

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x00023B43 File Offset: 0x00021D43
		// (set) Token: 0x060004E2 RID: 1250 RVA: 0x00023B4D File Offset: 0x00021D4D
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00023B58 File Offset: 0x00021D58
		private void Button2_Click(object sender, EventArgs e)
		{
			int num = FrmMain.fmain.ComboBox4.FindString(this.TextBox1.Text);
			bool flag = num >= 0;
			if (flag)
			{
				Interaction.MsgBox("A Preset with this name already exists", MsgBoxStyle.Critical, "Preset exists");
				this.TextBox1.Text = "";
			}
			else
			{
				FrmMain.fmain.ComboBox4.Items.Add(this.TextBox1.Text);
				FrmMain.fmain.ComboBox4.SelectedIndex = checked(FrmMain.fmain.ComboBox4.Items.Count - 1);
				MyProject.Forms.FrmMain.isCopy = false;
			}
			base.Close();
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00023C11 File Offset: 0x00021E11
		private void Button1_Click(object sender, EventArgs e)
		{
			MyProject.Forms.FrmMain.isCopy = false;
			base.Close();
		}
	}
}
