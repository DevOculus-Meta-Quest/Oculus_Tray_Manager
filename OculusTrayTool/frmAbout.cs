using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool
{
	// Token: 0x02000053 RID: 83
	[DesignerGenerated]
	public partial class frmAbout : Form
	{
		// Token: 0x060007D9 RID: 2009 RVA: 0x000481E0 File Offset: 0x000463E0
		public frmAbout()
		{
			base.Load += this.readme_Load;
			this.rs = new Resizer();
			this.InitializeComponent();
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x0004897E File Offset: 0x00046B7E
		// (set) Token: 0x060007DD RID: 2013 RVA: 0x00048988 File Offset: 0x00046B88
		internal virtual LinkLabel LinkLabel1
		{
			[CompilerGenerated]
			get
			{
				return this._LinkLabel1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler linkLabelLinkClickedEventHandler = new LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
				LinkLabel linkLabel = this._LinkLabel1;
				if (linkLabel != null)
				{
					linkLabel.LinkClicked -= linkLabelLinkClickedEventHandler;
				}
				this._LinkLabel1 = value;
				linkLabel = this._LinkLabel1;
				if (linkLabel != null)
				{
					linkLabel.LinkClicked += linkLabelLinkClickedEventHandler;
				}
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x000489CB File Offset: 0x00046BCB
		// (set) Token: 0x060007DF RID: 2015 RVA: 0x000489D8 File Offset: 0x00046BD8
		internal virtual PictureBox PictureBox1
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
				PictureBox pictureBox = this._PictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox1 = value;
				pictureBox = this._PictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x00048A1B File Offset: 0x00046C1B
		// (set) Token: 0x060007E1 RID: 2017 RVA: 0x00048A25 File Offset: 0x00046C25
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x00048A2E File Offset: 0x00046C2E
		// (set) Token: 0x060007E3 RID: 2019 RVA: 0x00048A38 File Offset: 0x00046C38
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x00048A41 File Offset: 0x00046C41
		// (set) Token: 0x060007E5 RID: 2021 RVA: 0x00048A4B File Offset: 0x00046C4B
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x00048A54 File Offset: 0x00046C54
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x00048A5E File Offset: 0x00046C5E
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00048A67 File Offset: 0x00046C67
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x00048A71 File Offset: 0x00046C71
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x00048A7A File Offset: 0x00046C7A
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x00048A84 File Offset: 0x00046C84
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x00048A8D File Offset: 0x00046C8D
		// (set) Token: 0x060007ED RID: 2029 RVA: 0x00048A97 File Offset: 0x00046C97
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x00048AA0 File Offset: 0x00046CA0
		// (set) Token: 0x060007EF RID: 2031 RVA: 0x00048AAC File Offset: 0x00046CAC
		internal virtual LinkLabel LinkLabel2
		{
			[CompilerGenerated]
			get
			{
				return this._LinkLabel2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler linkLabelLinkClickedEventHandler = new LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
				LinkLabel linkLabel = this._LinkLabel2;
				if (linkLabel != null)
				{
					linkLabel.LinkClicked -= linkLabelLinkClickedEventHandler;
				}
				this._LinkLabel2 = value;
				linkLabel = this._LinkLabel2;
				if (linkLabel != null)
				{
					linkLabel.LinkClicked += linkLabelLinkClickedEventHandler;
				}
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x00048AEF File Offset: 0x00046CEF
		// (set) Token: 0x060007F1 RID: 2033 RVA: 0x00048AF9 File Offset: 0x00046CF9
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060007F2 RID: 2034
		[DllImport("user32.dll")]
		private static extern bool HideCaret(IntPtr hWnd);

		// Token: 0x060007F3 RID: 2035 RVA: 0x00013C04 File Offset: 0x00011E04
		private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00048B02 File Offset: 0x00046D02
		private void readme_Load(object sender, EventArgs e)
		{
			this.PictureBox1.Focus();
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00048B14 File Offset: 0x00046D14
		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bool flag = File.Exists(Application.StartupPath + "\\User Guide.pdf");
			if (flag)
			{
				Process.Start(Application.StartupPath + "\\User Guide.pdf");
			}
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00048B51 File Offset: 0x00046D51
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmDonate.ShowDialog();
			base.Close();
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00048B6B File Offset: 0x00046D6B
		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://apollyonvr.com");
		}

		// Token: 0x04000364 RID: 868
		private Resizer rs;
	}
}
