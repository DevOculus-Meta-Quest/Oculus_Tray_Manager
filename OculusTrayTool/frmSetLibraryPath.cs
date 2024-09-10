using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x0200004A RID: 74
	[DesignerGenerated]
	public partial class frmSetLibraryPath : Form
	{
		// Token: 0x06000594 RID: 1428 RVA: 0x0002D7DC File Offset: 0x0002B9DC
		public frmSetLibraryPath()
		{
			this.InitializeComponent();
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0002DAEE File Offset: 0x0002BCEE
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x0002DAF8 File Offset: 0x0002BCF8
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0002DB01 File Offset: 0x0002BD01
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x0002DB0B File Offset: 0x0002BD0B
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0002DB14 File Offset: 0x0002BD14
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x0002DB20 File Offset: 0x0002BD20
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

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0002DB63 File Offset: 0x0002BD63
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x0002DB6D File Offset: 0x0002BD6D
		internal virtual FolderBrowserDialog FolderBrowserDialog1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0002DB78 File Offset: 0x0002BD78
		private void Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.FolderBrowserDialog1.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				bool flag2 = Directory.Exists(this.FolderBrowserDialog1.SelectedPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
				if (flag2)
				{
					bool flag3 = File.Exists(this.FolderBrowserDialog1.SelectedPath.TrimEnd(new char[] { '\\' }) + "\\Manifests\\oculus-home.json");
					if (flag3)
					{
						Interaction.MsgBox("While this path contains a 'Manifests' folder, it is not the correct one. See if there's a subfolder called 'Software' to the folder you selected. If so please select that folder.", MsgBoxStyle.Exclamation, "Invalid Path");
					}
					else
					{
						MySettingsProperty.Settings.LibraryPath = this.FolderBrowserDialog1.SelectedPath.TrimEnd(new char[] { '\\' });
						MySettingsProperty.Settings.Save();
						base.Close();
					}
				}
				else
				{
					Interaction.MsgBox("Invalid Path: Folder does not contain 'Manifests'", MsgBoxStyle.Exclamation, "Invalid Path");
				}
			}
		}
	}
}
