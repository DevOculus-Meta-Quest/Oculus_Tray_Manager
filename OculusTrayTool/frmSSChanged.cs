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
	// Token: 0x02000059 RID: 89
	[DesignerGenerated]
	public partial class frmSSChanged : Form
	{
		// Token: 0x060008E6 RID: 2278 RVA: 0x00051D75 File Offset: 0x0004FF75
		public frmSSChanged()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x00052165 File Offset: 0x00050365
		// (set) Token: 0x060008EA RID: 2282 RVA: 0x0005216F File Offset: 0x0005036F
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x00052178 File Offset: 0x00050378
		// (set) Token: 0x060008EC RID: 2284 RVA: 0x00052184 File Offset: 0x00050384
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

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x000521C7 File Offset: 0x000503C7
		// (set) Token: 0x060008EE RID: 2286 RVA: 0x000521D1 File Offset: 0x000503D1
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x000521DA File Offset: 0x000503DA
		// (set) Token: 0x060008F0 RID: 2288 RVA: 0x000521E4 File Offset: 0x000503E4
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

		// Token: 0x060008F1 RID: 2289 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00052228 File Offset: 0x00050428
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.CheckBox1.Checked;
			if (@checked)
			{
				MySettingsProperty.Settings.ShowConfirmRestart = false;
			}
			else
			{
				MySettingsProperty.Settings.ShowConfirmRestart = true;
			}
		}
	}
}
