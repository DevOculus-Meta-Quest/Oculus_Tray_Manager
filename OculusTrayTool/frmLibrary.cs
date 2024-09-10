using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool
{
	// Token: 0x0200002F RID: 47
	[DesignerGenerated]
	public partial class frmLibrary : Form
	{
		// Token: 0x0600041C RID: 1052 RVA: 0x0001C288 File Offset: 0x0001A488
		public frmLibrary()
		{
			base.FormClosing += this.Library_FormClosing;
			base.Load += this.Library_Load;
			base.ResizeBegin += this.Library_ResizeBegin;
			this.imageListLarge = new ImageList();
			this.ImgListOverlay = new ImageList
			{
				ImageSize = new Size(64, 64)
			};
			this.steam_assets = Application.StartupPath + "\\SteamVRAssets";
			this.backupPath = Application.StartupPath + "\\backup";
			this.changeMade = false;
			this.steamExes = new List<string>();
			this.rs = new Resizer();
			this.isReading = false;
			this.scrapeDone = false;
			this.libraryLoaded = false;
			this.ManualStartProfiles = new Dictionary<string, string>();
			this.removeOK = false;
			this.Client = new WebClient();
			this.Steamcnn = new SQLiteConnection();
			this.Iconscnn = new SQLiteConnection();
			this.offset = 0;
			this.isSearch = false;
			this.lvShrunk = false;
			this.ShrinkSize = 0;
			this.NoIconSet = false;
			this.BrowseForIcons = false;
			this.cnn = new SQLiteConnection();
			this.IconGameList = new List<string>();
			this.DisplayNameList = new List<string>();
			this.InitializeComponent();
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0001D6C4 File Offset: 0x0001B8C4
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x0001D6D0 File Offset: 0x0001B8D0
		internal virtual ListView ListView1
		{
			[CompilerGenerated]
			get
			{
				return this._ListView1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.ListView1_MouseMove);
				ListView listView = this._ListView1;
				if (listView != null)
				{
					listView.MouseMove -= mouseEventHandler;
				}
				this._ListView1 = value;
				listView = this._ListView1;
				if (listView != null)
				{
					listView.MouseMove += mouseEventHandler;
				}
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0001D713 File Offset: 0x0001B913
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x0001D71D File Offset: 0x0001B91D
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0001D726 File Offset: 0x0001B926
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x0001D730 File Offset: 0x0001B930
		internal virtual ContextMenuStrip ContextMenuStrip1
		{
			[CompilerGenerated]
			get
			{
				return this._ContextMenuStrip1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				CancelEventHandler cancelEventHandler = new CancelEventHandler(this.ContextMenuStrip1_Opening);
				EventHandler eventHandler = new EventHandler(this.ContextMenuStrip1_MouseLeave);
				ContextMenuStrip contextMenuStrip = this._ContextMenuStrip1;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Opening -= cancelEventHandler;
					contextMenuStrip.MouseLeave -= eventHandler;
				}
				this._ContextMenuStrip1 = value;
				contextMenuStrip = this._ContextMenuStrip1;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Opening += cancelEventHandler;
					contextMenuStrip.MouseLeave += eventHandler;
				}
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0001D78E File Offset: 0x0001B98E
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x0001D798 File Offset: 0x0001B998
		internal virtual ToolStripMenuItem ToolStripMenuItem3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001D7A1 File Offset: 0x0001B9A1
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0001D7AC File Offset: 0x0001B9AC
		internal virtual ToolStripMenuItem ToolStripMenuItem2
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem2_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem2;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem2 = value;
				toolStripMenuItem = this._ToolStripMenuItem2;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0001D7EF File Offset: 0x0001B9EF
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0001D7FC File Offset: 0x0001B9FC
		internal virtual ToolStripMenuItem ToolStripMenuItem4
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem4_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem4;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem4 = value;
				toolStripMenuItem = this._ToolStripMenuItem4;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0001D83F File Offset: 0x0001BA3F
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x0001D84C File Offset: 0x0001BA4C
		internal virtual ToolStripMenuItem ToolStripMenuItem7
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem7;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem7_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem7;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem7 = value;
				toolStripMenuItem = this._ToolStripMenuItem7;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0001D88F File Offset: 0x0001BA8F
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x0001D89C File Offset: 0x0001BA9C
		internal virtual ToolStripMenuItem ToolStripMenuItem8
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem8;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem8_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem8;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem8 = value;
				toolStripMenuItem = this._ToolStripMenuItem8;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0001D8DF File Offset: 0x0001BADF
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x0001D8EC File Offset: 0x0001BAEC
		internal virtual PictureBox PicturePlay
		{
			[CompilerGenerated]
			get
			{
				return this._PicturePlay;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.PicturePlay_MouseUp);
				PictureBox pictureBox = this._PicturePlay;
				if (pictureBox != null)
				{
					pictureBox.MouseUp -= mouseEventHandler;
				}
				this._PicturePlay = value;
				pictureBox = this._PicturePlay;
				if (pictureBox != null)
				{
					pictureBox.MouseUp += mouseEventHandler;
				}
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0001D92F File Offset: 0x0001BB2F
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0001D93C File Offset: 0x0001BB3C
		internal virtual ContextMenuStrip ContextMenuStrip2
		{
			[CompilerGenerated]
			get
			{
				return this._ContextMenuStrip2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				CancelEventHandler cancelEventHandler = new CancelEventHandler(this.ContextMenuStrip2_Opening);
				ContextMenuStrip contextMenuStrip = this._ContextMenuStrip2;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Opening -= cancelEventHandler;
				}
				this._ContextMenuStrip2 = value;
				contextMenuStrip = this._ContextMenuStrip2;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Opening += cancelEventHandler;
				}
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0001D97F File Offset: 0x0001BB7F
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0001D989 File Offset: 0x0001BB89
		internal virtual ToolStripMenuItem ReEnableAppToolStripMenuItem
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0001D992 File Offset: 0x0001BB92
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0001D99C File Offset: 0x0001BB9C
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0001D9A5 File Offset: 0x0001BBA5
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0001D9B0 File Offset: 0x0001BBB0
		internal virtual TextBox TextBox1
		{
			[CompilerGenerated]
			get
			{
				return this._TextBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyEventHandler keyEventHandler = new KeyEventHandler(this.TextBox1_KeyDown);
				TextBox textBox = this._TextBox1;
				if (textBox != null)
				{
					textBox.KeyDown -= keyEventHandler;
				}
				this._TextBox1 = value;
				textBox = this._TextBox1;
				if (textBox != null)
				{
					textBox.KeyDown += keyEventHandler;
				}
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0001D9F3 File Offset: 0x0001BBF3
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0001DA00 File Offset: 0x0001BC00
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

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0001DA43 File Offset: 0x0001BC43
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x0001DA4D File Offset: 0x0001BC4D
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x0001DA56 File Offset: 0x0001BC56
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0001DA60 File Offset: 0x0001BC60
		internal virtual ToolStripMenuItem ToolStripMenuItem1
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem1_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem1;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem1 = value;
				toolStripMenuItem = this._ToolStripMenuItem1;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0001DAA3 File Offset: 0x0001BCA3
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0001DAB0 File Offset: 0x0001BCB0
		internal virtual ToolStripMenuItem ToolStripMenuItem9
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem9;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem9_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem9;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem9 = value;
				toolStripMenuItem = this._ToolStripMenuItem9;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0001DAF3 File Offset: 0x0001BCF3
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x0001DAFD File Offset: 0x0001BCFD
		internal virtual ToolStripSeparator ToolStripSeparator1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0001DB06 File Offset: 0x0001BD06
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x0001DB10 File Offset: 0x0001BD10
		internal virtual ToolStripSeparator ToolStripSeparator2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0001DB19 File Offset: 0x0001BD19
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0001DB23 File Offset: 0x0001BD23
		internal virtual GroupBox GroupBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0001DB2C File Offset: 0x0001BD2C
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x0001DB38 File Offset: 0x0001BD38
		internal virtual ToolStripMenuItem ShowAppInLibraryAndProfilesToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._ShowAppInLibraryAndProfilesToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ShowAppInLibraryAndProfilesToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._ShowAppInLibraryAndProfilesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ShowAppInLibraryAndProfilesToolStripMenuItem = value;
				toolStripMenuItem = this._ShowAppInLibraryAndProfilesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0001DB7B File Offset: 0x0001BD7B
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x0001DB85 File Offset: 0x0001BD85
		internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0001DB8E File Offset: 0x0001BD8E
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0001DB98 File Offset: 0x0001BD98
		internal virtual TabPage TabPage1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0001DBA1 File Offset: 0x0001BDA1
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x0001DBAB File Offset: 0x0001BDAB
		internal virtual MenuStrip MenuStrip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0001DBB4 File Offset: 0x0001BDB4
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0001DBBE File Offset: 0x0001BDBE
		internal virtual ToolStripMenuItem OptionsToolStripMenuItem
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0001DBC7 File Offset: 0x0001BDC7
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0001DBD4 File Offset: 0x0001BDD4
		internal virtual ToolStripMenuItem AddSteamVRToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._AddSteamVRToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AddSteamVRToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._AddSteamVRToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._AddSteamVRToolStripMenuItem = value;
				toolStripMenuItem = this._AddSteamVRToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0001DC17 File Offset: 0x0001BE17
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0001DC24 File Offset: 0x0001BE24
		internal virtual ToolStripMenuItem ShowToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._ShowToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ShowToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._ShowToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ShowToolStripMenuItem = value;
				toolStripMenuItem = this._ShowToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0001DC67 File Offset: 0x0001BE67
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x0001DC71 File Offset: 0x0001BE71
		internal virtual ToolStripMenuItem ShowRemoved3rdPartyAppsToolStripMenuItem
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0001DC7A File Offset: 0x0001BE7A
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x0001DC84 File Offset: 0x0001BE84
		internal virtual ToolStripMenuItem SortingToolStripMenuItem
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0001DC8D File Offset: 0x0001BE8D
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0001DC98 File Offset: 0x0001BE98
		internal virtual ToolStripMenuItem AscendingToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._AscendingToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AscendingToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._AscendingToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._AscendingToolStripMenuItem = value;
				toolStripMenuItem = this._AscendingToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0001DCDB File Offset: 0x0001BEDB
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x0001DCE8 File Offset: 0x0001BEE8
		internal virtual ToolStripMenuItem DescendingToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._DescendingToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.DescendingToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._DescendingToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._DescendingToolStripMenuItem = value;
				toolStripMenuItem = this._DescendingToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0001DD2B File Offset: 0x0001BF2B
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x0001DD38 File Offset: 0x0001BF38
		internal virtual ToolStripMenuItem RefreshLibraryToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._RefreshLibraryToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RefreshLibraryToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._RefreshLibraryToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._RefreshLibraryToolStripMenuItem = value;
				toolStripMenuItem = this._RefreshLibraryToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0001DD7B File Offset: 0x0001BF7B
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x0001DD88 File Offset: 0x0001BF88
		internal virtual ToolStripMenuItem ShowIgnoredAppsToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._ShowIgnoredAppsToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ShowIgnoredAppsToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._ShowIgnoredAppsToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ShowIgnoredAppsToolStripMenuItem = value;
				toolStripMenuItem = this._ShowIgnoredAppsToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0001DDCB File Offset: 0x0001BFCB
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x0001DDD8 File Offset: 0x0001BFD8
		internal virtual ToolStripMenuItem ToolStripMenuItem5
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem5;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem5_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem5;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem5 = value;
				toolStripMenuItem = this._ToolStripMenuItem5;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x0001DE1B File Offset: 0x0001C01B
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x0001DE28 File Offset: 0x0001C028
		internal virtual ToolStripMenuItem ToolStripMenuItem6
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem6;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem6_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem6;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem6 = value;
				toolStripMenuItem = this._ToolStripMenuItem6;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0001DE6B File Offset: 0x0001C06B
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0001DE75 File Offset: 0x0001C075
		internal virtual ToolStripSeparator ToolStripSeparator3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x0001DE7E File Offset: 0x0001C07E
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x0001DE88 File Offset: 0x0001C088
		internal virtual ToolStripMenuItem RemoveProfileToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._RemoveProfileToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RemoveProfileToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._RemoveProfileToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._RemoveProfileToolStripMenuItem = value;
				toolStripMenuItem = this._RemoveProfileToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0001DECB File Offset: 0x0001C0CB
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x0001DED5 File Offset: 0x0001C0D5
		private virtual WebClient Client
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0001DEE0 File Offset: 0x0001C0E0
		private static string ByteArrayToString(byte[] ba)
		{
			string text = BitConverter.ToString(ba);
			return text.Replace("-", "");
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0001DF0C File Offset: 0x0001C10C
		private static byte[] GetBytes(SQLiteDataReader reader)
		{
			byte[] array = new byte[2048];
			long num = 0L;
			checked
			{
				byte[] array2;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					long num2;
					while (frmLibrary.InlineAssignHelper<long>(ref num2, reader.GetBytes(0, num, array, 0, array.Length)) > 0L)
					{
						memoryStream.Write(array, 0, (int)num2);
						num += num2;
					}
					array2 = memoryStream.ToArray();
				}
				return array2;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001DF8C File Offset: 0x0001C18C
		private static T InlineAssignHelper<T>(ref T target, T value)
		{
			target = value;
			return value;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0001DFA8 File Offset: 0x0001C1A8
		public static void SetDoubleBuffering(Control control, bool value)
		{
			PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(control, value, null);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0001DFDC File Offset: 0x0001C1DC
		private void GetOculusLibrary(string p)
		{
			frmLibrary.SetDoubleBuffering(this.ListView1, true);
			this.PicturePlay.Visible = false;
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetOculusLibrary");
			}
			bool flag = File.Exists(Application.StartupPath + "\\data.sqlite");
			checked
			{
				if (flag)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Opening database copy");
					}
					try
					{
						bool flag2 = this.cnn.State == ConnectionState.Closed;
						if (flag2)
						{
							this.cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
							this.cnn.Open();
						}
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Failed to open database copy: " + ex.Message);
						Interaction.MsgBox("Failed to open database copy: " + ex.Message, MsgBoxStyle.Critical, "Error opening database");
						FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex.Message);
						MyProject.Forms.FrmMain.hasError = true;
						return;
					}
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog("Parsing Manifests in " + p);
					}
					SQLiteCommand sqliteCommand = new SQLiteCommand(this.cnn);
					this.ListView1.BeginUpdate();
					string[] files = Directory.GetFiles(p, "*.mini");
					int i = 0;
					while (i < files.Length)
					{
						string text = files[i];
						string text2 = File.ReadAllText(text);
						JObject jobject = JObject.Parse(text2);
						string text3 = p.Replace("\\Manifests", "") + "\\Software";
						string text4 = jobject.SelectToken("canonicalName").ToString();
						string text5 = jobject.SelectToken("appId").ToString();
						string text6 = string.Concat(new string[]
						{
							text3,
							"\\",
							text4,
							"\\",
							jobject.SelectToken("launchFile").ToString().Replace("/", "\\")
						});
						string text7 = MySettingsProperty.Settings.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Software\\StoreAssets\\" + text4 + "_assets";
						string text8 = text7 + "\\small_landscape_image.jpg";
						bool flag3 = !File.Exists(text8);
						if (flag3)
						{
							Log.WriteToLog("Could not find game icon '" + text8 + "', looking in the other library paths");
							foreach (string text9 in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
							{
								text7 = text9.TrimEnd(new char[] { '\\' }) + "\\Software\\StoreAssets\\" + text4 + "_assets";
								text8 = text7 + "\\small_landscape_image.jpg";
								bool flag4 = File.Exists(text8);
								if (flag4)
								{
									Log.WriteToLog("Found game icon at '" + text8 + "'");
									break;
								}
							}
						}
						bool flag5 = Operators.CompareString(text5, "", false) != 0;
						if (flag5)
						{
							StringBuilder stringBuilder = new StringBuilder();
							try
							{
								sqliteCommand.CommandText = "Select value from Objects WHERE hashkey='" + text5 + "' AND typename='Application'";
								using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
								{
									bool hasRows = sqliteDataReader.HasRows;
									if (!hasRows)
									{
										goto IL_0681;
									}
									while (sqliteDataReader.Read())
									{
										byte[] bytes = frmLibrary.GetBytes(sqliteDataReader);
										stringBuilder.Append(Encoding.Default.GetString(bytes));
									}
								}
							}
							catch (Exception ex2)
							{
								Log.WriteToLog("Failed to read database entry for appId '" + text5 + "': " + ex2.Message);
								FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text5 + "': " + ex2.Message);
								MyProject.Forms.FrmMain.hasError = true;
								return;
							}
							string text10 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
							string text11 = "display:name::";
							bool flag6 = Conversions.ToInteger(MyProject.Forms.FrmMain.OculusAppVersion) >= 118;
							string text12;
							if (flag6)
							{
								text12 = ":display:short:description";
							}
							else
							{
								text12 = ":grouping";
							}
							int num = text10.IndexOf(text11);
							int num2 = text10.IndexOf(text12);
							bool flag7 = num > -1 && num2 > -1;
							if (flag7)
							{
								string text13 = Strings.Mid(text10, num + text11.Length + 1, num2 - num - text11.Length).Replace(":", " ").TrimEnd(new char[] { ':' })
									.TrimEnd(new char[] { ' ' });
								text13 = text13.Remove(text13.Length - 1);
								ListViewItem listViewItem = this.ListView1.FindItemWithText(text13);
								bool flag8 = listViewItem != null;
								if (!flag8)
								{
									bool flag9 = File.Exists(text8);
									if (flag9)
									{
										using (Image image = Image.FromFile(text8))
										{
											this.imageListLarge.Images.Add(text6, image);
										}
									}
									else
									{
										this.imageListLarge.Images.Add(text6, Resources.removed_app);
									}
									ListViewItem listViewItem2 = new ListViewItem(text13, text6);
									listViewItem2.Tag = string.Concat(new string[]
									{
										Path.GetFileName(text6),
										",",
										text7,
										",",
										text.Replace(".mini", ""),
										",",
										text6
									});
									bool flag10 = this.ManualStartProfiles.ContainsKey(text6) | this.ManualStartProfiles.ContainsKey(text6.ToLower());
									if (flag10)
									{
										listViewItem2.ForeColor = Color.Green;
									}
									else
									{
										bool flag11 = this.DisplayNameList.Contains(text13.ToLower());
										if (flag11)
										{
											listViewItem2.ForeColor = Color.Blue;
										}
										else
										{
											listViewItem2.ForeColor = Color.Red;
										}
									}
									this.ListView1.Items.Add(listViewItem2);
									bool flag12 = !this.IconGameList.Contains(text13);
									if (flag12)
									{
										this.IconGameList.Add(text13);
									}
								}
							}
						}
						IL_0681:
						i++;
						continue;
						goto IL_0681;
					}
					this.ListView1.Sorting = SortOrder.Ascending;
					this.ListView1.Sort();
					this.ListView1.EndUpdate();
					sqliteCommand.Dispose();
					this.cnn.Close();
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog("Connection closed");
					}
					bool dbg5 = Globals.dbg;
					if (dbg5)
					{
						Log.WriteToLog("Exiting GetOculusLibrary");
					}
				}
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0001E71C File Offset: 0x0001C91C
		private void GetThirdPartyApps(string p)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_0002:
				int num = 1;
				bool dbg = Globals.dbg;
				if (!dbg)
				{
					goto IL_001C;
				}
				IL_000F:
				num = 2;
				Log.WriteToLog("Entering GetThirdPartyApps");
				IL_001C:
				num = 3;
				List<string> list = new List<string>();
				IL_0024:
				num = 4;
				this.PicturePlay.Visible = false;
				IL_0033:
				num = 5;
				this.ListView1.BeginUpdate();
				IL_0041:
				num = 6;
				bool flag = Operators.CompareString(MyProject.Forms.FrmMain.SteamPath, "", false) != 0;
				if (!flag)
				{
					goto IL_01B9;
				}
				IL_0069:
				num = 7;
				string text = Path.Combine(MyProject.Forms.FrmMain.SteamPath, "config\\steamapps.vrmanifest");
				IL_0086:
				num = 8;
				bool flag2 = !File.Exists(text);
				if (!flag2)
				{
					IL_00AD:
					num = 11;
					Log.WriteToLog("Found Steam VR manifest: " + text);
					IL_00C2:
					num = 12;
					string text2 = File.ReadAllText(text);
					IL_00CE:
					num = 13;
					JObject jobject = JObject.Parse(text2);
					IL_00DA:
					num = 14;
					JToken jtoken = jobject.SelectToken("applications");
					IL_00EB:
					num = 15;
					IEnumerator<JToken> enumerator = ((IEnumerable<JToken>)jtoken).GetEnumerator();
					while (enumerator.MoveNext())
					{
						JToken jtoken2 = enumerator.Current;
						IL_0105:
						num = 16;
						IL_010B:
						num = 17;
						string text3 = jtoken2["app_key"].ToString();
						IL_0121:
						num = 18;
						string text4 = jtoken2["strings"]["en_us"]["name"].ToString();
						IL_014B:
						num = 19;
						bool flag3 = !list.Contains(text4);
						if (flag3)
						{
							IL_015F:
							num = 20;
							list.Add(text4);
							IL_016B:
							num = 21;
							bool dbg2 = Globals.dbg;
							if (dbg2)
							{
								IL_0179:
								num = 22;
								Log.WriteToLog("GetThirdPartyLibraryApps: Steam game '" + text4 + "' added to list");
							}
							IL_0193:;
						}
						IL_0195:
						num = 24;
					}
					IL_01A8:
					num = 25;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
					IL_01B7:
					goto IL_01B8;
				}
				IL_0098:
				num = 9;
				Log.WriteToLog("Could not locate Steam VR manifest");
				IL_00A6:
				IL_01B8:
				IL_01B9:
				IL_01BA:
				num = 28;
				foreach (string text5 in Directory.GetFiles(p, "*.json"))
				{
					IL_01D9:
					ProjectData.ClearProjectError();
					num2 = -2;
					IL_01E2:
					num = 30;
					bool flag4 = text5.Contains("_assets.json");
					if (flag4)
					{
						IL_01F7:;
					}
					else
					{
						IL_01FC:
						num = 32;
						bool dbg3 = Globals.dbg;
						if (dbg3)
						{
							IL_020A:
							num = 33;
							Log.WriteToLog("Opening " + text5);
						}
						IL_021F:
						num = 34;
						string text6 = File.ReadAllText(text5);
						IL_022B:
						num = 35;
						JObject jobject2 = JObject.Parse(text6);
						IL_0237:
						num = 36;
						bool flag5 = (bool)jobject2.SelectToken("thirdParty");
						IL_024D:
						num = 37;
						string text7 = jobject2.SelectToken("canonicalName").ToString();
						IL_0263:
						num = 38;
						List<JToken> list2 = ((IEnumerable<JToken>)jobject2.Children()).ToList<JToken>();
						IL_027E:
						num = 39;
						List<JToken>.Enumerator enumerator2 = list2.GetEnumerator();
						string text8;
						string fileName;
						string text9;
						while (enumerator2.MoveNext())
						{
							JToken jtoken3 = enumerator2.Current;
							JProperty jproperty = (JProperty)jtoken3;
							IL_029D:
							num = 40;
							jproperty.CreateReader();
							IL_02A9:
							num = 41;
							string name = jproperty.Name;
							if (Operators.CompareString(name, "displayName", false) != 0)
							{
								if (Operators.CompareString(name, "launchFile", false) == 0)
								{
									IL_02EA:
									num = 45;
									text8 = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
									IL_0319:
									num = 46;
									fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
									IL_034D:
									break;
								}
							}
							else
							{
								IL_02D6:
								num = 43;
								text9 = jproperty.Value.ToString();
								IL_02E7:;
							}
							IL_0351:
							IL_0352:
							num = 49;
						}
						IL_0365:
						num = 50;
						((IDisposable)enumerator2).Dispose();
						IL_0376:
						num = 51;
						bool flag6 = !flag5;
						if (flag6)
						{
							IL_0384:
							num = 52;
							bool dbg4 = Globals.dbg;
							if (dbg4)
							{
								IL_0392:
								num = 53;
								Log.WriteToLog("'" + text9 + "' is not thirdParty, ignoring for now");
							}
							IL_03AC:;
						}
						else
						{
							IL_03B2:
							IL_03B3:
							num = 56;
							bool flag7 = list.Contains(text9);
							if (flag7)
							{
								IL_03C4:
								num = 57;
								bool dbg5 = Globals.dbg;
								if (dbg5)
								{
									IL_03D2:
									num = 58;
									Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + text9 + "' to Library view");
								}
								IL_03EC:
								num = 59;
								this.AddThirdPartyGameToLibrary(p, list, text7, text9, fileName, text8);
								IL_0400:;
							}
							else
							{
								IL_0407:
								num = 61;
								Log.WriteToLog("'" + text9 + "' not found in Steam game list, getting info from the Oculus Database");
								IL_0421:
								num = 62;
								StringBuilder stringBuilder = new StringBuilder();
								IL_042B:
								num = 63;
								bool flag8 = this.cnn.State == ConnectionState.Closed;
								if (flag8)
								{
									IL_0442:
									num = 64;
									this.cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
									IL_0464:
									num = 65;
									this.cnn.Open();
									IL_0473:;
								}
								IL_0475:
								num = 67;
								SQLiteCommand sqliteCommand = new SQLiteCommand(this.cnn);
								IL_0485:
								num = 68;
								sqliteCommand.CommandText = "select value from Objects WHERE hashkey='" + text7 + "_LocalAppState' AND typename='LocalApplicationState'";
								IL_04A2:
								num = 69;
								using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
								{
									while (sqliteDataReader.Read())
									{
										byte[] bytes = frmLibrary.GetBytes(sqliteDataReader);
										stringBuilder.Append(Encoding.Default.GetString(bytes));
									}
								}
								IL_04EB:
								num = 70;
								bool flag9 = stringBuilder.ToString().Contains("FLAT");
								if (flag9)
								{
									IL_0505:
									num = 71;
									bool dbg6 = Globals.dbg;
									if (dbg6)
									{
										IL_0513:
										num = 72;
										Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
									}
									IL_0521:;
								}
								else
								{
									IL_0527:
									IL_0528:
									num = 75;
									bool flag10 = Operators.CompareString(stringBuilder.ToString(), "", false) != 0;
									if (flag10)
									{
										IL_0546:
										num = 76;
										bool dbg7 = Globals.dbg;
										if (dbg7)
										{
											IL_0554:
											num = 77;
											Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + text9 + "' to Library view");
										}
										IL_056E:
										num = 78;
										this.AddThirdPartyGameToLibrary(p, list, text7, text9, fileName, text8);
										IL_0582:;
									}
									IL_0584:
									num = 80;
									bool flag11 = Operators.CompareString(stringBuilder.ToString(), "", false) == 0;
									if (flag11)
									{
										IL_05A5:
										num = 81;
										bool dbg8 = Globals.dbg;
										if (dbg8)
										{
											IL_05B3:
											num = 82;
											Log.WriteToLog("GetThirdPartyLibraryApps:  -> Not found, looking for secondary entry: " + text7 + ": UserAppPlayTime");
										}
										IL_05CD:
										num = 83;
										sqliteCommand.CommandText = "select value from Objects WHERE hashkey LIKE \"%" + text7 + "%\" AND typename='UserAppPlayTime'";
										IL_05EA:
										num = 84;
										using (SQLiteDataReader sqliteDataReader2 = sqliteCommand.ExecuteReader())
										{
											bool hasRows = sqliteDataReader2.HasRows;
											if (hasRows)
											{
												bool dbg9 = Globals.dbg;
												if (dbg9)
												{
													Log.WriteToLog("GetThirdPartyLibraryApps:  -> Found entry for " + text7 + ": UserAppPlayTime");
												}
												bool dbg10 = Globals.dbg;
												if (dbg10)
												{
													Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + text9 + "' to Library view");
												}
												this.AddThirdPartyGameToLibrary(p, list, text7, text9, fileName, text8);
											}
											else
											{
												bool flag12 = !MyProject.Forms.FrmMain.includedApps.Contains(text5);
												if (flag12)
												{
													bool dbg11 = Globals.dbg;
													if (dbg11)
													{
														Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
													}
													goto IL_06F0;
												}
												this.AddThirdPartyGameToLibrary(p, list, text7, text9, fileName, text8);
											}
										}
										IL_06B7:;
									}
									IL_06B9:
									num = 86;
									sqliteCommand.Dispose();
									IL_06C4:
									num = 87;
									this.cnn.Close();
									IL_06D3:
									num = 88;
									bool dbg12 = Globals.dbg;
									if (dbg12)
									{
										IL_06E1:
										num = 89;
										Log.WriteToLog("Connection closed");
									}
									IL_06EF:;
								}
							}
						}
					}
					IL_06F0:
					num = 91;
				}
				IL_070A:
				num = 92;
				this.ListView1.EndUpdate();
				IL_0719:
				num = 93;
				bool flag13 = this.cnn.State == ConnectionState.Open;
				if (!flag13)
				{
					goto IL_075C;
				}
				IL_0730:
				num = 94;
				this.cnn.Close();
				IL_073F:
				num = 95;
				bool dbg13 = Globals.dbg;
				if (!dbg13)
				{
					goto IL_075B;
				}
				IL_074D:
				num = 96;
				Log.WriteToLog("Connection closed");
				IL_075B:
				IL_075C:
				IL_075D:
				num = 98;
				bool dbg14 = Globals.dbg;
				if (!dbg14)
				{
					goto IL_0779;
				}
				IL_076B:
				num = 99;
				Log.WriteToLog("Exiting GetThirdPartyApps");
				IL_0779:
				goto IL_0963;
				IL_034F:
				goto IL_0351;
				IL_03B1:
				goto IL_03B2;
				IL_0526:
				goto IL_0527;
				IL_077E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_091C:
				goto IL_0958;
				IL_091E:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
				IL_0936:;
			}
			catch when (endfilter((obj is Exception) & (num2 != 0) & (num4 == 0)))
			{
				Exception ex = (Exception)obj2;
				goto IL_091E;
			}
			IL_0958:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_0963:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0001F0E4 File Offset: 0x0001D2E4
		private void AddThirdPartyGameToLibrary(string p, List<string> steamGameList, string canonName, string DisplayName, string LaunchFile, string fullpath)
		{
			try
			{
				bool flag = this.IconGameList.Contains(DisplayName);
				if (flag)
				{
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("AddThirdPartyGameToLibrary: '" + DisplayName + "' has already been added to the library, skipping");
					}
				}
				else
				{
					bool flag2 = false;
					string text = p + "\\" + canonName + ".json";
					string text2 = MySettingsProperty.Settings.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Software\\StoreAssets\\" + canonName + "_assets";
					string text3 = text2 + "\\small_landscape_image.jpg";
					bool flag3 = File.Exists(text3);
					if (flag3)
					{
						flag2 = true;
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + text3);
						}
					}
					else
					{
						foreach (string text4 in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
						{
							text2 = text4.TrimEnd(new char[] { '\\' }) + "\\Software\\StoreAssets\\" + canonName + "_assets";
							text3 = text2 + "\\small_landscape_image.jpg";
							bool flag4 = File.Exists(text3);
							if (flag4)
							{
								flag2 = true;
								bool dbg3 = Globals.dbg;
								if (dbg3)
								{
									Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + text3);
								}
								break;
							}
						}
					}
					bool flag5 = !flag2;
					if (flag5)
					{
						Log.WriteToLog("Could not locate local icon for '" + DisplayName + "'");
						text3 = "Default Unknown";
					}
					bool flag6 = DisplayName.ToLower().EndsWith(".exe") | (Operators.CompareString(DisplayName.ToLower(), "unknown app", false) == 0);
					if (flag6)
					{
						DisplayName = Path.GetFileNameWithoutExtension(LaunchFile);
					}
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog("    App is thirdParty");
						Log.WriteToLog("    DisplayName: '" + DisplayName + "'");
						Log.WriteToLog("    LaunchFile: '" + LaunchFile + "'");
						Log.WriteToLog("    FullPath: '" + fullpath + "'");
						Log.WriteToLog("    assetsPath: '" + text2 + "'");
						Log.WriteToLog("    iconFile: '" + text3 + "'");
					}
					string text5 = string.Concat(new string[]
					{
						Path.GetFileName(LaunchFile),
						",",
						text2,
						",",
						text,
						",3rdParty,",
						LaunchFile
					});
					bool flag7 = !OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Library") & !OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both");
					if (flag7)
					{
						bool dbg5 = Globals.dbg;
						if (dbg5)
						{
							Log.WriteToLog("    Hidden: False");
						}
						bool flag8 = File.Exists(text3);
						if (flag8)
						{
							using (Image image = Image.FromFile(text3))
							{
								bool dbg6 = Globals.dbg;
								if (dbg6)
								{
									Log.WriteToLog(string.Concat(new string[] { "AddThirdPartyGameToLibrary: Adding '", DisplayName, "' (", LaunchFile, ") to library with '", text3, "'" }));
								}
								this.imageListLarge.Images.Add(LaunchFile, image);
							}
						}
						else
						{
							bool dbg7 = Globals.dbg;
							if (dbg7)
							{
								Log.WriteToLog(string.Concat(new string[] { "AddThirdPartyGameToLibrary: Adding '", DisplayName, "' (", LaunchFile, ") to library with [???] icon" }));
							}
							this.imageListLarge.Images.Add(LaunchFile, Resources.removed_app);
						}
						ListViewItem listViewItem = new ListViewItem(DisplayName, LaunchFile);
						listViewItem.Tag = text5;
						bool flag9 = this.ManualStartProfiles.ContainsKey(fullpath) | this.ManualStartProfiles.ContainsKey(fullpath.ToLower());
						if (flag9)
						{
							listViewItem.ForeColor = Color.Green;
						}
						else
						{
							bool flag10 = this.DisplayNameList.Contains(DisplayName.ToLower());
							if (flag10)
							{
								listViewItem.ForeColor = Color.Blue;
							}
							else
							{
								listViewItem.ForeColor = Color.Red;
							}
						}
						this.ListView1.Items.Add(listViewItem);
						bool flag11 = !this.IconGameList.Contains(DisplayName);
						if (flag11)
						{
							this.IconGameList.Add(DisplayName);
						}
					}
					else
					{
						bool dbg8 = Globals.dbg;
						if (dbg8)
						{
							Log.WriteToLog("    Hidden: True");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("AddThirdPartyGameToLibrary: " + ex.Message);
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0001F5CC File Offset: 0x0001D7CC
		private void Library_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = this.changeMade;
			if (flag)
			{
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				bool flag2 = processesByName.Length > 0;
				if (flag2)
				{
					Interaction.MsgBox("You may need to restart oculus Home to see the new icons in VR.", MsgBoxStyle.Information, "Oculus Tray Tool");
				}
			}
			MySettingsProperty.Settings.LibraryWindowLocation = base.Location;
			MySettingsProperty.Settings.LibraryWindowSize = base.Size;
			MySettingsProperty.Settings.Save();
			bool flag3 = e.CloseReason == CloseReason.UserClosing;
			if (flag3)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001F65A File Offset: 0x0001D85A
		private void Library_Load(object sender, EventArgs e)
		{
			this.LoadLibrary();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001F664 File Offset: 0x0001D864
		public void LoadLibrary()
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			Log.WriteToLog("Opening Library");
			this.changeMade = false;
			bool flag = MySettingsProperty.Settings.LibraryWindowLocation != default(Point);
			if (flag)
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Setting Library GUI location to " + MySettingsProperty.Settings.LibraryWindowLocation.ToString());
				}
				base.Location = MySettingsProperty.Settings.LibraryWindowLocation;
			}
			else
			{
				base.CenterToScreen();
				MySettingsProperty.Settings.LibraryWindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			bool flag2 = (base.Location.X < 0) | (base.Location.Y < 0);
			if (flag2)
			{
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Library GUI location has negative number, adjusting");
				}
				base.CenterToScreen();
				MySettingsProperty.Settings.LibraryWindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			base.Size = MySettingsProperty.Settings.LibraryWindowSize;
			this.rs.FindAllControls(this);
			this.rs.ResizeAllControls(this, (float)MyProject.Forms.FrmMain.TrackBar1.Value);
			this.imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
			this.ImgListOverlay.ColorDepth = ColorDepth.Depth32Bit;
			Image play = Resources.play2;
			this.ImgListOverlay.Images.Add(play);
			this.PicturePlay.Visible = false;
			frmLibrary.icons.Images.Clear();
			frmLibrary.icons.ColorDepth = ColorDepth.Depth32Bit;
			frmLibrary.icons.ImageSize = new Size(250, 90);
			bool flag3 = !this.libraryLoaded;
			if (flag3)
			{
				Log.WriteToLog("Library not loaded");
				this.PopulateList();
			}
			else
			{
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Library already loaded, proceeding");
				}
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001F868 File Offset: 0x0001DA68
		private object GenerateSHA256Hash(string filename)
		{
			object obj;
			using (FileStream fileStream = File.OpenRead(filename))
			{
				SHA256Managed sha256Managed = new SHA256Managed();
				byte[] array = sha256Managed.ComputeHash(fileStream);
				obj = BitConverter.ToString(array).Replace("-", string.Empty).ToLower();
			}
			return obj;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001F8C8 File Offset: 0x0001DAC8
		public void PopulateList()
		{
			this.Cursor = Cursors.WaitCursor;
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Loading Library view");
			}
			this.PicturePlay.Visible = false;
			this.ListView1.Items.Clear();
			this.imageListLarge.Images.Clear();
			this.imageListLarge.ImageSize = new Size(250, 90);
			this.ListView1.LargeImageList = this.imageListLarge;
			this.ListView1.View = View.LargeIcon;
			this.ContextMenuStrip1.Visible = true;
			this.ContextMenuStrip1.Close();
			bool flag = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
			if (flag)
			{
				this.GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
			}
			bool flag2 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Software\\Manifests");
			if (flag2)
			{
				this.GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Software\\Manifests");
			}
			bool flag3 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
			if (flag3)
			{
				this.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
			}
			bool flag4 = Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0;
			if (flag4)
			{
				foreach (string text in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
				{
					bool flag5 = Directory.Exists(text.TrimEnd(new char[] { '\\' }) + "\\Manifests");
					if (flag5)
					{
						this.GetOculusLibrary(text.TrimEnd(new char[] { '\\' }) + "\\Manifests");
					}
					bool flag6 = Directory.Exists(text.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
					if (flag6)
					{
						this.GetThirdPartyApps(text.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
					}
				}
			}
			MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
			MyProject.Forms.frmProfiles.GameList.Clear();
			bool flag7 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
			if (flag7)
			{
				GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Manifests");
			}
			bool flag8 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Software\\Manifests");
			if (flag8)
			{
				GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\Software\\Manifests");
			}
			bool flag9 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
			if (flag9)
			{
				GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
			}
			bool flag10 = Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0;
			if (flag10)
			{
				foreach (string text2 in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
				{
					bool flag11 = Directory.Exists(text2.TrimEnd(new char[] { '\\' }) + "\\Manifests");
					if (flag11)
					{
						GetGames.GetFiles(text2.TrimEnd(new char[] { '\\' }) + "\\Manifests");
					}
					bool flag12 = Directory.Exists(text2.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
					if (flag12)
					{
						GetGames.GetThirdPartyApps(text2.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
					}
				}
			}
			this.libraryLoaded = true;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001FDF0 File Offset: 0x0001DFF0
		private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count == 0;
			if (!flag)
			{
				bool flag2 = (this.ListView1.SelectedItems.Count > 0) & this.PicturePlay.Visible;
				if (flag2)
				{
					bool flag3 = this.ListView1.SelectedItems[0].ForeColor == Color.Red;
					if (flag3)
					{
						this.ToolStripMenuItem1.Visible = true;
						this.ToolStripMenuItem9.Visible = false;
						this.RemoveProfileToolStripMenuItem.Visible = false;
					}
					bool flag4 = this.ListView1.SelectedItems[0].ForeColor == Color.Green;
					if (flag4)
					{
						this.ToolStripMenuItem1.Visible = false;
						this.ToolStripMenuItem9.Visible = true;
						this.RemoveProfileToolStripMenuItem.Visible = true;
					}
					bool flag5 = Conversions.ToBoolean(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, null, "contains", new object[] { "3rdParty" }, null, null, null));
					if (flag5)
					{
						this.ToolStripMenuItem2.Visible = true;
						this.ToolStripMenuItem4.Visible = true;
						this.ToolStripMenuItem5.Visible = true;
						this.ToolStripMenuItem7.Visible = true;
						this.ToolStripMenuItem8.Visible = true;
					}
					else
					{
						bool flag6 = Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, null, "contains", new object[] { "hidden" }, null, null, null)));
						if (flag6)
						{
							this.ToolStripMenuItem2.Visible = true;
							this.ToolStripMenuItem4.Visible = false;
							this.ToolStripMenuItem5.Visible = false;
							this.ToolStripMenuItem7.Visible = true;
							this.ToolStripMenuItem8.Visible = true;
						}
					}
					bool @checked = this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked;
					if (@checked)
					{
						this.ToolStripMenuItem2.Visible = false;
						this.ToolStripMenuItem4.Visible = false;
						this.ToolStripMenuItem5.Visible = false;
						this.ToolStripMenuItem7.Visible = false;
						this.ToolStripMenuItem8.Visible = false;
					}
				}
				else
				{
					this.ToolStripMenuItem1.Visible = false;
					this.ToolStripMenuItem2.Visible = false;
					this.ToolStripMenuItem4.Visible = false;
					this.ToolStripMenuItem5.Visible = false;
					this.ToolStripMenuItem7.Visible = false;
					this.ToolStripMenuItem8.Visible = false;
				}
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00020090 File Offset: 0x0001E290
		private void CreateManifest(string canonicalName, string displayName, string files, string launchFile, string path)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			using (JsonWriter jsonWriter = new JsonTextWriter(stringWriter))
			{
				jsonWriter.Formatting = Formatting.Indented;
				jsonWriter.WriteStartObject();
				jsonWriter.WritePropertyName("canonicalName");
				jsonWriter.WriteValue(canonicalName);
				jsonWriter.WritePropertyName("displayName");
				jsonWriter.WriteValue(displayName);
				jsonWriter.WritePropertyName("files");
				jsonWriter.WriteStartObject();
				jsonWriter.WritePropertyName(files);
				jsonWriter.WriteValue("");
				jsonWriter.WriteEndObject();
				jsonWriter.WritePropertyName("firewallExceptionsRequired");
				jsonWriter.WriteValue(false);
				jsonWriter.WritePropertyName("isCore");
				jsonWriter.WriteValue(false);
				jsonWriter.WritePropertyName("launchFile");
				jsonWriter.WriteValue(launchFile);
				jsonWriter.WritePropertyName("launchParameters");
				jsonWriter.WriteValue("");
				jsonWriter.WritePropertyName("manifestVersion");
				jsonWriter.WriteValue(0);
				jsonWriter.WritePropertyName("packageType");
				jsonWriter.WriteValue("APP");
				jsonWriter.WritePropertyName("thirdParty");
				jsonWriter.WriteValue(true);
				jsonWriter.WritePropertyName("version");
				jsonWriter.WriteValue("1");
				jsonWriter.WritePropertyName("versionCode");
				jsonWriter.WriteValue(1);
				jsonWriter.WriteEndObject();
			}
			StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
			streamWriter.Write(stringWriter);
			streamWriter.Close();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00020234 File Offset: 0x0001E434
		private void CreateAssetManifest(string canonicalName, string color, Dictionary<string, string> files, string parameters, string path)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			using (JsonWriter jsonWriter = new JsonTextWriter(stringWriter))
			{
				jsonWriter.Formatting = Formatting.Indented;
				jsonWriter.WriteStartObject();
				jsonWriter.WritePropertyName("dominantColor");
				jsonWriter.WriteValue(color);
				jsonWriter.WritePropertyName("files");
				jsonWriter.WriteStartObject();
				try
				{
					foreach (KeyValuePair<string, string> keyValuePair in files)
					{
						jsonWriter.WritePropertyName(keyValuePair.Key);
						jsonWriter.WriteValue(keyValuePair.Value);
					}
				}
				finally
				{
					Dictionary<string, string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				jsonWriter.WriteEndObject();
				jsonWriter.WritePropertyName("packageType");
				jsonWriter.WriteValue("ASSET_BUNDLE");
				jsonWriter.WritePropertyName("isCore");
				jsonWriter.WriteValue(false);
				jsonWriter.WritePropertyName("appId");
				jsonWriter.WriteNull();
				jsonWriter.WritePropertyName("canonicalName");
				jsonWriter.WriteValue(canonicalName);
				jsonWriter.WritePropertyName("launchFile");
				jsonWriter.WriteNull();
				jsonWriter.WritePropertyName("launchParameters");
				bool flag = Operators.CompareString(parameters, "", false) == 0;
				if (flag)
				{
					jsonWriter.WriteNull();
				}
				else
				{
					jsonWriter.WriteValue(parameters);
				}
				jsonWriter.WritePropertyName("launchFile2D");
				jsonWriter.WriteNull();
				jsonWriter.WritePropertyName("launchParameters2D");
				jsonWriter.WriteNull();
				jsonWriter.WritePropertyName("version");
				jsonWriter.WriteValue("1");
				jsonWriter.WritePropertyName("versionCode");
				jsonWriter.WriteValue(1);
				jsonWriter.WritePropertyName("redistributables");
				jsonWriter.WriteNull();
				jsonWriter.WritePropertyName("firewallExceptionsRequired");
				jsonWriter.WriteValue(false);
				jsonWriter.WritePropertyName("thirdParty");
				jsonWriter.WriteValue(true);
				jsonWriter.WritePropertyName("manifestVersion");
				jsonWriter.WriteValue(0);
				jsonWriter.WriteEndObject();
			}
			StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
			streamWriter.Write(stringWriter);
			streamWriter.Close();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00020490 File Offset: 0x0001E690
		private void ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
			bool flag = File.Exists(array[2]);
			if (flag)
			{
				string text = File.ReadAllText(array[2]);
				string text2 = JToken.Parse(text).ToString(Formatting.Indented, new JsonConverter[0]);
				MyProject.Forms.frmProperties.RichTextBox1.Text = text2;
				MyProject.Forms.frmProperties.TextBox1.Text = array[2];
				MyProject.Forms.frmProperties.fname = array[2];
				this.rs.FindAllControls(MyProject.Forms.frmProperties);
				this.rs.ResizeAllControls(MyProject.Forms.frmProperties, (float)MyProject.Forms.FrmMain.TrackBar1.Value);
				bool flag2 = Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, null, "contains", new object[] { "3rdParty" }, null, null, null)));
				if (flag2)
				{
					MyProject.Forms.frmProperties.Button1.Enabled = false;
				}
				else
				{
					MyProject.Forms.frmProperties.Button1.Enabled = true;
				}
				MyProject.Forms.frmProperties.ShowDialog();
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x000205F8 File Offset: 0x0001E7F8
		private void ToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
			OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, array[0], "Library");
			this.PopulateList();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0002065C File Offset: 0x0001E85C
		private void ToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
			OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, array[0], "Both");
			this.PopulateList();
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000206BD File Offset: 0x0001E8BD
		private void ToolStripMenuItem7_Click(object sender, EventArgs e)
		{
			this.LaunchApp();
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000206C8 File Offset: 0x0001E8C8
		private void LaunchApp()
		{
			checked
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
					bool flag = File.Exists(array[2]);
					if (flag)
					{
						string text = "";
						string text2 = "";
						List<string> list = new List<string>();
						list = this.GetAppInfo(array[2], "");
						int num = list.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							text = list[0];
							text2 = list[1];
						}
						bool flag2 = (Operators.CompareString(text, "", false) != 0) & File.Exists(text);
						if (flag2)
						{
							MyProject.Forms.FrmMain.ManualStart = true;
							bool flag3 = !MyProject.Forms.FrmMain.HomeIsRunning;
							if (flag3)
							{
								RunCommand.StartHome();
								Thread.Sleep(3000);
							}
							bool flag4 = this.ManualStartProfiles.ContainsKey(text.ToLower());
							if (flag4)
							{
								Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
								this.ApplyProfile(text.TrimStart(new char[0]).TrimEnd(new char[0]));
							}
							else
							{
								Log.WriteToLog("No profile found for '" + text + "'");
							}
							Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
							bool flag5 = Operators.CompareString(text2, "", false) != 0;
							if (flag5)
							{
								Log.WriteToLog(" -> " + text.TrimStart(new char[0]).TrimEnd(new char[0]) + " " + text2.TrimStart(new char[0]).TrimEnd(new char[0]));
							}
							else
							{
								Log.WriteToLog(" -> " + text.TrimStart(new char[0]).TrimEnd(new char[0]));
							}
							this.Cursor = Cursors.Default;
							Process.Start(text, text2);
							bool dbg = Globals.dbg;
							if (dbg)
							{
								Log.WriteToLog("Adding Worker AppWatchWorker");
							}
							BackgroundWorker backgroundWorker = new BackgroundWorker();
							backgroundWorker.DoWork += MyProject.Forms.FrmMain.AppWork;
							backgroundWorker.RunWorkerAsync();
							bool dbg2 = Globals.dbg;
							if (dbg2)
							{
								Log.WriteToLog("Worker started");
							}
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("LaunchApp(): " + ex.Message);
				}
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0002098C File Offset: 0x0001EB8C
		private void ApplyProfile(string appName)
		{
			string ss = "";
			checked
			{
				try
				{
					bool flag = this.ManualStartProfiles.TryGetValue(appName.ToLower(), out ss);
					if (flag)
					{
						Thread thread = new Thread(delegate
						{
							RunCommand.Run_debug_tool(ss);
						});
						thread.Start();
						string text = "";
						bool flag2 = MyProject.Forms.FrmMain.profileAGPS.TryGetValue(MyProject.Forms.FrmMain.runningApp.ToLower(), out text);
						if (flag2)
						{
							bool flag3 = Operators.CompareString(text, "0", false) == 0;
							if (flag3)
							{
								Thread thread2 = new Thread((frmLibrary._Closure$__.$I209-1 == null) ? (frmLibrary._Closure$__.$I209-1 = delegate
								{
									RunCommand.Run_debug_tool_agps("false");
								}) : frmLibrary._Closure$__.$I209-1);
								thread2.Start();
							}
							else
							{
								Thread thread3 = new Thread((frmLibrary._Closure$__.$I209-2 == null) ? (frmLibrary._Closure$__.$I209-2 = delegate
								{
									RunCommand.Run_debug_tool_agps("true");
								}) : frmLibrary._Closure$__.$I209-2);
								thread3.Start();
							}
						}
						bool voiceConfirmProfile = MySettingsProperty.Settings.VoiceConfirmProfile;
						if (voiceConfirmProfile)
						{
							Thread thread4 = new Thread((frmLibrary._Closure$__.$I209-3 == null) ? (frmLibrary._Closure$__.$I209-3 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
							}) : frmLibrary._Closure$__.$I209-3);
							thread4.Start();
						}
						bool setRiftDefault = GetConfig.SetRiftDefault;
						if (setRiftDefault)
						{
							bool flag4 = MySettingsProperty.Settings.SetRiftAudioDefault == 2;
							if (flag4)
							{
								Thread thread5 = new Thread((frmLibrary._Closure$__.$I209-4 == null) ? (frmLibrary._Closure$__.$I209-4 = delegate
								{
									AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
								}) : frmLibrary._Closure$__.$I209-4);
								thread5.Start();
							}
							bool flag5 = MySettingsProperty.Settings.SetRiftMicDefault == 2;
							if (flag5)
							{
								Thread thread6 = new Thread((frmLibrary._Closure$__.$I209-5 == null) ? (frmLibrary._Closure$__.$I209-5 = delegate
								{
									AudioSwitcher.SetDefaultMicDeviceOnStart();
								}) : frmLibrary._Closure$__.$I209-5);
								thread6.Start();
							}
						}
						MyProject.Forms.FrmMain.runningApp = appName;
						string displayName = OTTDB.GetDisplayName(appName);
						MyProject.Forms.FrmMain.runningapp_displayname = OTTDB.GetDisplayName(appName);
						Log.WriteToLog(string.Concat(new string[] { "Manual game launch detected: ", displayName, " (", appName, ")" }));
						Log.WriteToLog(displayName + ": Super Sampling @ " + ss);
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog(MyProject.Forms.FrmMain.runningApp + ": Super Sampling @ " + ss);
						}
						FrmMain.fmain.AddToListboxAndScroll("Game launch detected: " + displayName);
						string text2 = "";
						bool flag6 = MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text2);
						if (flag6)
						{
							global::System.Timers.Timer timer = new global::System.Timers.Timer();
							timer.AutoReset = false;
							timer.Interval = (double)(Conversions.ToInteger(text2) * 1000);
							timer.Elapsed += MyProject.Forms.FrmMain.ApplyCpuPrioTick;
							timer.Start();
							Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + text2 + " seconds");
							FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + text2 + " seconds");
						}
						string text3 = "";
						bool flag7 = MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text3);
						if (flag7)
						{
							global::System.Timers.Timer timer2 = new global::System.Timers.Timer();
							timer2.AutoReset = false;
							timer2.Interval = (double)(Conversions.ToInteger(text3) * 1000);
							timer2.Elapsed += MyProject.Forms.FrmMain.ApplyAswTick;
							timer2.Start();
							Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + text3 + " seconds");
							FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + text3 + " seconds");
						}
						string text4 = "";
						bool flag8 = MyProject.Forms.FrmMain.profileMirror.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text4);
						if (flag8)
						{
							bool flag9 = Operators.CompareString(text4, "1", false) == 0;
							if (flag9)
							{
								global::System.Timers.Timer timer3 = new global::System.Timers.Timer();
								timer3.AutoReset = false;
								timer3.Interval = 2000.0;
								timer3.Elapsed += FrmMain.fmain.ApplyMirrorTick;
								timer3.Start();
							}
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("ApplyProfile(): " + ex.Message);
				}
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00020EBC File Offset: 0x0001F0BC
		private List<string> GetAppInfo(string jFile, string customParms)
		{
			List<string> list2;
			try
			{
				List<string> list = new List<string>();
				string text = "";
				string text2 = File.ReadAllText(jFile);
				JObject jobject = (JObject)JToken.Parse(text2);
				string text3 = (string)jobject.SelectToken("canonicalName");
				string text4 = ((string)jobject.SelectToken("launchFile")).Replace("/", "\\").Replace("\\\\", "\\");
				bool flag = Operators.CompareString(customParms, "", false) == 0;
				string text5;
				if (flag)
				{
					text5 = (string)jobject.SelectToken("launchParameters");
				}
				else
				{
					text5 = customParms;
				}
				bool flag2 = this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty");
				if (flag2)
				{
					text = text4.Replace("/", "\\").Replace("\\\\", "\\");
				}
				bool flag3 = !this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty");
				if (flag3)
				{
					string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary);
					foreach (string text6 in array)
					{
						bool flag4 = File.Exists(string.Concat(new string[] { text6, "\\Software\\", text3, "\\", text4 }));
						if (flag4)
						{
							text = string.Concat(new string[] { text6, "\\Software\\", text3, "\\", text4 });
							break;
						}
					}
				}
				list.Add(text);
				list.Add(text5);
				list2 = list;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetAppInfo(): " + ex.Message);
			}
			return list2;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x000210E0 File Offset: 0x0001F2E0
		private void ListView1_MouseMove(object sender, MouseEventArgs e)
		{
			checked
			{
				try
				{
					bool @checked = this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked;
					if (!@checked)
					{
						bool checked2 = this.ShowToolStripMenuItem.Checked;
						if (!checked2)
						{
							bool flag = this.ListView1.Items.Count == 0;
							if (!flag)
							{
								ListViewItem itemAt = this.ListView1.GetItemAt(e.X, e.Y);
								try
								{
									foreach (object obj in this.ListView1.Items)
									{
										ListViewItem listViewItem = (ListViewItem)obj;
										bool flag2 = listViewItem != itemAt;
										if (flag2)
										{
											listViewItem.Selected = false;
										}
									}
								}
								finally
								{
									IEnumerator enumerator;
									if (enumerator is IDisposable)
									{
										(enumerator as IDisposable).Dispose();
									}
								}
								bool flag3 = itemAt != null;
								if (flag3)
								{
									itemAt.Selected = true;
									itemAt.EnsureVisible();
									ListViewHitTestInfo listViewHitTestInfo = this.ListView1.HitTest(e.X, e.Y);
									this.PicturePlay.Left = this.ListView1.Left + listViewHitTestInfo.Item.Bounds.Left + 21;
									this.PicturePlay.Top = this.ListView1.Top + listViewHitTestInfo.Item.Bounds.Top + 2;
									string[] array = Strings.Split(Conversions.ToString(itemAt.Tag), ",", -1, CompareMethod.Binary);
									this.PicturePlay.Image = this.CreateOverlay(this.imageListLarge.Images[array[array.Count<string>() - 1]]);
									this.PicturePlay.Visible = true;
									this.PicturePlay.Select();
								}
								else
								{
									this.PicturePlay.Visible = false;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000212FC File Offset: 0x0001F4FC
		private Image CreateOverlay(Image im)
		{
			int width = this.ImgListOverlay.Images[0].Width;
			int height = this.ImgListOverlay.Images[0].Height;
			Bitmap bitmap = new Bitmap(width, height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(this.ImgListOverlay.Images[0], 0, 0, width, height);
			}
			bitmap.MakeTransparent(Color.Red);
			int width2 = im.Width;
			int height2 = im.Height;
			Bitmap bitmap2 = new Bitmap(width2, height2);
			checked
			{
				int num = (width2 - width) / 2;
				int num2 = (height2 - height) / 2;
				using (Graphics graphics2 = Graphics.FromImage(bitmap2))
				{
					graphics2.DrawImage(im, 0, 0, width2, height2);
					graphics2.DrawImage(bitmap, num, num2, width, height);
				}
				this.PicturePlay.Image = bitmap2;
				bitmap.Dispose();
				return bitmap2;
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0002141C File Offset: 0x0001F61C
		private void ToolStripMenuItem8_Click(object sender, EventArgs e)
		{
			string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
			bool flag = File.Exists(array[2]);
			checked
			{
				if (flag)
				{
					string text = "";
					string text2 = "";
					List<string> list = new List<string>();
					list = this.GetAppInfo(array[2], "");
					int num = list.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text = list[0];
						text2 = list[1];
					}
					MyProject.Forms.frmLaunchOptions.TextBox1.Text = text2;
					MyProject.Forms.frmLaunchOptions.ShowDialog();
					bool optionsCanceled = MyProject.Forms.frmLaunchOptions.optionsCanceled;
					if (!optionsCanceled)
					{
						bool flag2 = (Operators.CompareString(text, "", false) != 0) & File.Exists(text);
						if (flag2)
						{
							MyProject.Forms.FrmMain.ManualStart = true;
							Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
							Log.WriteToLog(" -> " + text.TrimStart(new char[0]).TrimEnd(new char[0]) + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text.TrimStart(new char[0]).TrimEnd(new char[0]));
							this.ApplyProfile(text.TrimStart(new char[0]).TrimEnd(new char[0]));
							Process.Start(text, MyProject.Forms.frmLaunchOptions.TextBox1.Text);
							MyProject.Forms.frmLaunchOptions.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000215EC File Offset: 0x0001F7EC
		private void PicturePlay_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				bool flag2 = e.Button == MouseButtons.Left;
				if (flag2)
				{
					this.LaunchApp();
				}
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00021630 File Offset: 0x0001F830
		private void ContextMenuStrip2_Opening(object sender, CancelEventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count == 0;
			if (!flag)
			{
				bool flag2 = this.ListView1.SelectedItems.Count > 0;
				if (flag2)
				{
					bool flag3 = Conversions.ToBoolean(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, null, "contains", new object[] { "hidden" }, null, null, null));
					if (flag3)
					{
						this.ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = true;
					}
					else
					{
						this.ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = false;
					}
				}
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000216CB File Offset: 0x0001F8CB
		private void Button2_Click(object sender, EventArgs e)
		{
			this.SearchForApp();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x000216D8 File Offset: 0x0001F8D8
		private void TextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Return;
			if (flag)
			{
				this.SearchForApp();
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00021700 File Offset: 0x0001F900
		private void SearchForApp()
		{
			bool flag = this.DotNetBarTabcontrol1.SelectedIndex == 0;
			if (flag)
			{
				ListViewItem listViewItem = this.ListView1.FindItemWithText(this.TextBox1.Text);
				bool flag2 = listViewItem != null;
				if (flag2)
				{
					listViewItem.Selected = true;
					this.ListView1.Focus();
					this.ListView1.SelectedItems[0].EnsureVisible();
				}
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00021770 File Offset: 0x0001F970
		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
			frmCreateEditProfile frmCreateEditProfile = new frmCreateEditProfile();
			bool flag = this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty");
			string text2;
			if (flag)
			{
				string text = File.ReadAllText(array[2]);
				JObject jobject = JObject.Parse(text);
				text2 = jobject.SelectToken("launchFile").ToString();
			}
			else
			{
				text2 = array[3];
			}
			frmCreateEditProfile.TextDisplayName.Text = this.ListView1.SelectedItems[0].Text;
			frmCreateEditProfile.ComboSS.Text = "0";
			frmCreateEditProfile.ComboASW.Text = "Auto";
			frmCreateEditProfile.ComboCPU.Text = "Normal";
			frmCreateEditProfile.ComboMethod.Text = "WMI";
			frmCreateEditProfile.pLaunchfile = array[0].Replace("\\\\", "\\").Replace("/", "\\");
			frmCreateEditProfile.pPath = text2.Replace("\\\\", "\\").Replace("/", "\\");
			frmCreateEditProfile.TextBoxPath.Text = text2.Replace("\\\\", "\\").Replace("/", "\\");
			frmCreateEditProfile.NumericUpDown1.Value = 5m;
			frmCreateEditProfile.NumericUpDown2.Value = 5m;
			frmCreateEditProfile.ComboMirror.SelectedIndex = 0;
			frmCreateEditProfile.ComboAGPS.SelectedIndex = 1;
			frmCreateEditProfile.Button1.Enabled = true;
			frmCreateEditProfile.ShowDialog(this);
			bool flag2 = !frmCreateEditProfile.CreateCancel;
			if (flag2)
			{
				this.PicturePlay.Visible = false;
				this.PopulateList();
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00021960 File Offset: 0x0001FB60
		private void ToolStripMenuItem9_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.ListView1.SelectedItems.Count == 0;
				if (!flag)
				{
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("Editing Profile: '" + this.ListView1.SelectedItems[0].Text + "'");
					}
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(" Tag: ", this.ListView1.SelectedItems[0].Tag)));
					}
					string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog(" Reading " + array[2].Replace("\\\\", "\\").Replace("/", "\\"));
					}
					string text = File.ReadAllText(array[2].Replace("\\\\", "\\").Replace("/", "\\"));
					JObject jobject = JObject.Parse(text);
					string text2 = jobject.SelectToken("launchFile").ToString();
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog(" Json Launchfile: " + text2);
					}
					string text3 = array[3];
					bool flag2 = Operators.CompareString(text3, "3rdParty", false) == 0;
					if (flag2)
					{
						text3 = text2.Replace("\\\\", "\\").Replace("/", "\\");
					}
					bool dbg5 = Globals.dbg;
					if (dbg5)
					{
						Log.WriteToLog(" Path: " + text3);
					}
					bool flag3 = MyProject.Forms.FrmMain.profilePaths.TryGetValue(text3, out text2);
					if (flag3)
					{
						text2 = text3;
					}
					text2 = text2.Replace("\\\\", "\\").Replace("/", "\\");
					bool dbg6 = Globals.dbg;
					if (dbg6)
					{
						Log.WriteToLog(" Launchfile: " + text2);
					}
					frmCreateEditProfile frmCreateEditProfile = new frmCreateEditProfile();
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					bool flag4 = this.ManualStartProfiles.TryGetValue(text2.ToLower(), out text6);
					if (flag4)
					{
						frmCreateEditProfile.ComboSS.Text = text6;
					}
					bool flag5 = MyProject.Forms.FrmMain.profileASWList.TryGetValue(text2, out text5);
					if (flag5)
					{
						frmCreateEditProfile.ComboASW.Text = text5;
					}
					bool flag6 = MyProject.Forms.FrmMain.profileDisplayNames.TryGetValue(text2, out text4);
					if (flag6)
					{
						frmCreateEditProfile.TextDisplayName.Text = text4;
					}
					bool flag7 = MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(text2, out text8);
					if (flag7)
					{
						frmCreateEditProfile.ComboCPU.Text = text8;
					}
					bool flag8 = MyProject.Forms.FrmMain.profileTimerList.TryGetValue(text2, out text7);
					if (flag8)
					{
						frmCreateEditProfile.ComboMethod.Text = "Timer";
					}
					else
					{
						frmCreateEditProfile.ComboMethod.Text = "WMI";
					}
					Dictionary<string, string> profileAswDelay = MyProject.Forms.FrmMain.profileAswDelay;
					string text9 = text2;
					string text10 = Conversions.ToString(num);
					bool flag9 = profileAswDelay.TryGetValue(text9, out text10);
					num = Conversions.ToInteger(text10);
					bool flag10 = flag9;
					if (flag10)
					{
						frmCreateEditProfile.NumericUpDown1.Value = new decimal(num);
					}
					Dictionary<string, string> profileCpuDelay = MyProject.Forms.FrmMain.profileCpuDelay;
					string text11 = text2;
					text10 = Conversions.ToString(num2);
					bool flag11 = profileCpuDelay.TryGetValue(text11, out text10);
					num2 = Conversions.ToInteger(text10);
					bool flag12 = flag11;
					if (flag12)
					{
						frmCreateEditProfile.NumericUpDown2.Value = new decimal(num2);
					}
					Dictionary<string, string> profileMirror = MyProject.Forms.FrmMain.profileMirror;
					string text12 = text2.ToLower();
					text10 = Conversions.ToString(num3);
					bool flag13 = profileMirror.TryGetValue(text12, out text10);
					if (flag13)
					{
						frmCreateEditProfile.ComboMirror.SelectedIndex = num3;
					}
					Dictionary<string, string> profileAGPS = MyProject.Forms.FrmMain.profileAGPS;
					string text13 = text2.ToLower();
					text10 = Conversions.ToString(num4);
					bool flag14 = profileAGPS.TryGetValue(text13, out text10);
					if (flag14)
					{
						frmCreateEditProfile.ComboAGPS.SelectedIndex = num4;
					}
					frmCreateEditProfile.pLaunchfile = Path.GetFileName(text2);
					frmCreateEditProfile.pPath = text2;
					frmCreateEditProfile.TextBoxPath.Text = text2;
					frmCreateEditProfile.Button1.Enabled = true;
					frmCreateEditProfile.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Could not edit profile: " + ex.Message);
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00021E24 File Offset: 0x00020024
		private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
		{
			this.ContextMenuStrip1.Close();
			this.ListView1.Focus();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00021E3F File Offset: 0x0002003F
		private void Library_ResizeBegin(object sender, EventArgs e)
		{
			this.PicturePlay.Visible = false;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00021E4F File Offset: 0x0002004F
		private void ShowAppInLibraryAndProfilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OTTDB.UnHideApp(this.ListView1.SelectedItems[0].Text);
			this.ShowToolStripMenuItem.Checked = false;
			this.PopulateList();
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00021E84 File Offset: 0x00020084
		public void ImagelistAddItem(string name, Image img)
		{
			try
			{
				frmLibrary.icons.Images.Add(name, img);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00021EC8 File Offset: 0x000200C8
		private int GetCount(SQLiteConnection sqConnection, string Table)
		{
			SQLiteCommand sqliteCommand = new SQLiteCommand("SELECT COUNT(*) From " + Table, sqConnection);
			return (int)Convert.ToInt16(RuntimeHelpers.GetObjectValue(sqliteCommand.ExecuteScalar()));
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00021F00 File Offset: 0x00020100
		public void ClearListview(ListView lv)
		{
			bool invokeRequired = lv.InvokeRequired;
			if (invokeRequired)
			{
				frmLibrary.ClearListview_delegate clearListview_delegate = new frmLibrary.ClearListview_delegate(this.ClearListview);
				lv.BeginInvoke(clearListview_delegate, new object[] { lv });
			}
			else
			{
				lv.Items.Clear();
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00021F50 File Offset: 0x00020150
		private void AddSteamVRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = Operators.CompareString(MyProject.Forms.FrmMain.steamvr, "", false) == 0;
			if (flag)
			{
				Interaction.MsgBox("Could not locate Steam VR path", MsgBoxStyle.Critical, "Error");
			}
			else
			{
				string text = MyProject.Forms.FrmMain.steamvr.Replace(" ", "").Replace("\\", "_").Replace(":", "") + "bin_win32_assets";
				string text2 = MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Software\\StoreAssets\\" + text;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				bool flag2 = !Directory.Exists(text2);
				if (flag2)
				{
					Log.WriteToLog("Creating " + text2);
					Directory.CreateDirectory(text2);
				}
				try
				{
					foreach (string text3 in Directory.GetFiles(this.steam_assets))
					{
						bool flag3 = (Operators.CompareString(Path.GetExtension(text3), ".bat", false) != 0) & (Operators.CompareString(Path.GetExtension(text3), ".exe", false) != 0);
						if (flag3)
						{
							Log.WriteToLog("Copying " + Path.GetFileName(text3) + " -> " + text2);
							File.Copy(text3, text2 + "\\" + Path.GetFileName(text3), true);
							Log.WriteToLog("Generating hash for " + Path.GetFileName(text3));
							string text4 = Conversions.ToString(this.GenerateSHA256Hash(text3));
							dictionary.Add(Path.GetFileName(text3), text4);
						}
						bool flag4 = Operators.CompareString(Path.GetExtension(text3), ".bat", false) == 0;
						if (flag4)
						{
							File.Copy(text3, MyProject.Forms.FrmMain.steamvr + Path.GetFileName(text3), true);
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("Exception occurred when copying files: " + ex.Message);
					Interaction.MsgBox("Exception occurred when copying files: " + ex.Message, MsgBoxStyle.OkOnly, null);
					return;
				}
				this.CreateManifest(text.Replace("_assets", ""), "SteamVR", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
				this.CreateAssetManifest(text, "#060404", dictionary, "", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
				this.PopulateList();
				bool flag5 = Interaction.MsgBox("You need to restart the Oculus Service for SteamVR to be visible in Oculus Home. Restart it now?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, "Restart Required") == MsgBoxResult.Yes;
				if (flag5)
				{
					MyProject.Forms.FrmMain.StopOVR();
					MyProject.Forms.FrmMain.StartOVR();
				}
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00022278 File Offset: 0x00020478
		private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool @checked = this.ShowToolStripMenuItem.Checked;
			if (@checked)
			{
				this.PicturePlay.Visible = false;
				this.isReading = true;
				this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked = false;
				this.isReading = false;
				this.ListView1.Items.Clear();
				this.imageListLarge.Images.Clear();
				this.imageListLarge.ImageSize = new Size(250, 90);
				this.ListView1.LargeImageList = this.imageListLarge;
				this.ListView1.View = View.LargeIcon;
				try
				{
					foreach (object obj in ((IEnumerable)OTTDB.GetHiddenApps()))
					{
						string text = Conversions.ToString(obj);
						this.imageListLarge.Images.Add(text, Resources.removed_app);
						ListViewItem listViewItem = new ListViewItem(text, text);
						listViewItem.Tag = text + ",hidden";
						this.ListView1.Items.Add(listViewItem);
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			else
			{
				this.RefreshLibrary();
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000223BC File Offset: 0x000205BC
		private void AscendingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool @checked = this.AscendingToolStripMenuItem.Checked;
			if (@checked)
			{
				this.DescendingToolStripMenuItem.Checked = false;
				bool flag = this.DotNetBarTabcontrol1.SelectedIndex == 0;
				if (flag)
				{
					this.ListView1.Sorting = SortOrder.Ascending;
				}
				else
				{
					this.ListView1.Sorting = SortOrder.None;
				}
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0002241C File Offset: 0x0002061C
		private void DescendingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool @checked = this.DescendingToolStripMenuItem.Checked;
			if (@checked)
			{
				this.AscendingToolStripMenuItem.Checked = false;
				bool flag = this.DotNetBarTabcontrol1.SelectedIndex == 0;
				if (flag)
				{
					this.ListView1.Sorting = SortOrder.Descending;
				}
				else
				{
					this.ListView1.Sorting = SortOrder.None;
				}
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00022479 File Offset: 0x00020679
		private void RefreshLibraryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.RefreshLibrary();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00022484 File Offset: 0x00020684
		private void RefreshLibrary()
		{
			Log.WriteToLog("Refreshing Library");
			try
			{
				bool flag = this.cnn.State == ConnectionState.Open;
				if (flag)
				{
					this.cnn.Close();
				}
				bool flag2 = File.Exists(Application.StartupPath + "\\data.sqlite");
				if (flag2)
				{
					File.Delete(Application.StartupPath + "\\data.sqlite");
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("Database copy deleted");
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Failed to delete database copy: " + ex.Message);
				Interaction.MsgBox("Failed to delete database copy: " + ex.Message, MsgBoxStyle.OkOnly, null);
				FrmMain.fmain.AddToListboxAndScroll("Failed to delete database copy: " + ex.Message);
				MyProject.Forms.FrmMain.hasError = true;
				return;
			}
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Looking for Oculus database");
			}
			bool flag3 = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite");
			if (flag3)
			{
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Database found, making a copy");
				}
				try
				{
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
				}
				catch (Exception ex2)
				{
					Log.WriteToLog("Failed to create database copy: " + ex2.Message);
					Interaction.MsgBox("Failed to create database copy: " + ex2.Message, MsgBoxStyle.Critical, "Error copying database");
					FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + ex2.Message);
					MyProject.Forms.FrmMain.hasError = true;
					return;
				}
			}
			this.IconGameList.Clear();
			this.libraryLoaded = false;
			this.LoadLibrary();
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00022690 File Offset: 0x00020890
		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData.ToString());
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00022690 File Offset: 0x00020890
		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData.ToString());
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x000226A9 File Offset: 0x000208A9
		private void ShowIgnoredAppsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyProject.Forms.FrmIgnoredApps.ShowDialog(this);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x000226C0 File Offset: 0x000208C0
		private void ToolStripMenuItem6_Click(object sender, EventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
				string text = array[2];
				string text2 = this.ListView1.SelectedItems[0].Text;
				OTTDB.AddIgnoreApp(text);
				OTTDB.RemoveIncludedApp(text);
				MyProject.Forms.FrmMain.ignoredApps = (List<string>)OTTDB.GetIgnoredApps();
				MyProject.Forms.FrmMain.includedApps = (List<string>)OTTDB.GetIncludedApps();
				MyProject.Forms.FrmMain.ignoredApps.Add(text);
				this.PopulateList();
				Log.WriteToLog("'" + text2 + "' is now being ignored");
				MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + text2 + "' is now being ignored");
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x000227C0 File Offset: 0x000209C0
		private void RemoveProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DeleteProfile();
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x000227CC File Offset: 0x000209CC
		private void DeleteProfile()
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				ListViewItem listViewItem = this.ListView1.SelectedItems[0];
				string[] array = Strings.Split(Conversions.ToString(listViewItem.Tag), ",", -1, CompareMethod.Binary);
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog(" Reading " + array[2].Replace("\\\\", "\\").Replace("/", "\\"));
				}
				string text = File.ReadAllText(array[2].Replace("\\\\", "\\").Replace("/", "\\"));
				JObject jobject = JObject.Parse(text);
				string text2 = jobject.SelectToken("launchFile").ToString();
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog(" Json Launchfile: " + text2);
				}
				string text3 = array[3];
				bool flag2 = Operators.CompareString(text3, "3rdParty", false) == 0;
				if (flag2)
				{
					text3 = text2.Replace("\\\\", "\\").Replace("/", "\\");
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog(" Path: " + text3);
				}
				bool flag3 = MyProject.Forms.FrmMain.profilePaths.TryGetValue(text3, out text2);
				if (flag3)
				{
					text2 = text3;
				}
				text2 = text2.Replace("\\\\", "\\").Replace("/", "\\");
				bool flag4 = Interaction.MsgBox("Remove profile for '" + listViewItem.Text + "'?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm") == MsgBoxResult.Yes;
				if (flag4)
				{
					OTTDB.RemoveProfile(text2);
					OTTDB.GetProfiles();
					bool flag5 = OTTDB.numWMI > 0;
					if (flag5)
					{
						MyProject.Forms.FrmMain.CreateWatcher();
					}
					bool flag6 = OTTDB.numTimer > 0;
					if (flag6)
					{
						MyProject.Forms.FrmMain.pTimer.Start();
					}
				}
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
				this.PopulateList();
			}
		}

		// Token: 0x04000195 RID: 405
		private ImageList imageListLarge;

		// Token: 0x04000196 RID: 406
		public static ImageList icons = new ImageList();

		// Token: 0x04000197 RID: 407
		private ImageList ImgListOverlay;

		// Token: 0x04000198 RID: 408
		private string steam_assets;

		// Token: 0x04000199 RID: 409
		private string backupPath;

		// Token: 0x0400019A RID: 410
		private bool changeMade;

		// Token: 0x0400019B RID: 411
		private List<string> steamExes;

		// Token: 0x0400019C RID: 412
		private Resizer rs;

		// Token: 0x0400019D RID: 413
		private bool isReading;

		// Token: 0x0400019E RID: 414
		private bool scrapeDone;

		// Token: 0x0400019F RID: 415
		private bool libraryLoaded;

		// Token: 0x040001A0 RID: 416
		public Dictionary<string, string> ManualStartProfiles;

		// Token: 0x040001A1 RID: 417
		private bool removeOK;

		// Token: 0x040001A2 RID: 418
		public int LocalDBVersion;

		// Token: 0x040001A3 RID: 419
		public int IconsLocalDBVersion;

		// Token: 0x040001A5 RID: 421
		private Thread GetIcons;

		// Token: 0x040001A6 RID: 422
		public SQLiteConnection Steamcnn;

		// Token: 0x040001A7 RID: 423
		public SQLiteConnection Iconscnn;

		// Token: 0x040001A8 RID: 424
		private int offset;

		// Token: 0x040001A9 RID: 425
		private bool isOpen;

		// Token: 0x040001AA RID: 426
		private bool IconsisOpen;

		// Token: 0x040001AB RID: 427
		private int dbCount;

		// Token: 0x040001AC RID: 428
		private bool isSearch;

		// Token: 0x040001AD RID: 429
		private bool lvShrunk;

		// Token: 0x040001AE RID: 430
		private string selectedLink;

		// Token: 0x040001AF RID: 431
		private int ShrinkSize;

		// Token: 0x040001B0 RID: 432
		private ListView lvToShrink;

		// Token: 0x040001B1 RID: 433
		private bool NoIconSet;

		// Token: 0x040001B2 RID: 434
		private bool BrowseForIcons;

		// Token: 0x040001B3 RID: 435
		private SQLiteConnection cnn;

		// Token: 0x040001B4 RID: 436
		private List<string> IconGameList;

		// Token: 0x040001B5 RID: 437
		public List<string> DisplayNameList;

		// Token: 0x02000075 RID: 117
		// (Invoke) Token: 0x06000A30 RID: 2608
		public delegate void ImagelistAddItem_delegate(string name, Image img);

		// Token: 0x02000076 RID: 118
		// (Invoke) Token: 0x06000A34 RID: 2612
		public delegate void ListViewAddItemSteam_delegate(string name, string tag);

		// Token: 0x02000077 RID: 119
		// (Invoke) Token: 0x06000A38 RID: 2616
		public delegate void ClearListview_delegate(ListView lv);
	}
}
