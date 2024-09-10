using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool
{
	// Token: 0x0200001C RID: 28
	[DesignerGenerated]
	public partial class frmDonate : Form
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0000C70C File Offset: 0x0000A90C
		public frmDonate()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000D1DA File Offset: 0x0000B3DA
		// (set) Token: 0x06000254 RID: 596 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0000D1ED File Offset: 0x0000B3ED
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0000D1F7 File Offset: 0x0000B3F7
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0000D200 File Offset: 0x0000B400
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0000D20C File Offset: 0x0000B40C
		internal virtual PictureBox PictureBox4
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox4_Click);
				PictureBox pictureBox = this._PictureBox4;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox4 = value;
				pictureBox = this._PictureBox4;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000D24F File Offset: 0x0000B44F
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0000D25C File Offset: 0x0000B45C
		internal virtual PictureBox PictureBox3
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox3_Click);
				PictureBox pictureBox = this._PictureBox3;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox3 = value;
				pictureBox = this._PictureBox3;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000D29F File Offset: 0x0000B49F
		// (set) Token: 0x0600025C RID: 604 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		internal virtual PictureBox PictureBox2
		{
			[CompilerGenerated]
			get
			{
				return this._PictureBox2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.PictureBox2_Click);
				PictureBox pictureBox = this._PictureBox2;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._PictureBox2 = value;
				pictureBox = this._PictureBox2;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000D2EF File Offset: 0x0000B4EF
		// (set) Token: 0x0600025E RID: 606 RVA: 0x0000D2FC File Offset: 0x0000B4FC
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

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000D33F File Offset: 0x0000B53F
		// (set) Token: 0x06000260 RID: 608 RVA: 0x0000D349 File Offset: 0x0000B549
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000D352 File Offset: 0x0000B552
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000D35C File Offset: 0x0000B55C
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000D365 File Offset: 0x0000B565
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0000D36F File Offset: 0x0000B56F
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0000D378 File Offset: 0x0000B578
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0000D382 File Offset: 0x0000B582
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000D38B File Offset: 0x0000B58B
		// (set) Token: 0x06000268 RID: 616 RVA: 0x0000D395 File Offset: 0x0000B595
		internal virtual GroupBox GroupBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000D39E File Offset: 0x0000B59E
		// (set) Token: 0x0600026A RID: 618 RVA: 0x0000D3A8 File Offset: 0x0000B5A8
		internal virtual GroupBox GroupBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000D3B1 File Offset: 0x0000B5B1
		// (set) Token: 0x0600026C RID: 620 RVA: 0x0000D3BB File Offset: 0x0000B5BB
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600026D RID: 621 RVA: 0x0000D3C4 File Offset: 0x0000B5C4
		// (set) Token: 0x0600026E RID: 622 RVA: 0x0000D3D0 File Offset: 0x0000B5D0
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

		// Token: 0x0600026F RID: 623 RVA: 0x0000D413 File Offset: 0x0000B613
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=V2Q88RWKVSAH6");
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000D421 File Offset: 0x0000B621
		private void PictureBox2_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XV6QUB2VGL298");
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000D42F File Offset: 0x0000B62F
		private void PictureBox3_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7A8ME9WUMG9SA");
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000D43D File Offset: 0x0000B63D
		private void PictureBox4_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=R5D56LX9T8MTY");
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000D44B File Offset: 0x0000B64B
		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://apollyonvr.com");
		}
	}
}
