using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000024 RID: 36
	[DesignerGenerated]
	public partial class frmImportSteamApps : Form
	{
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000359 RID: 857 RVA: 0x000156A2 File Offset: 0x000138A2
		// (set) Token: 0x0600035A RID: 858 RVA: 0x000156AC File Offset: 0x000138AC
		internal virtual ListView lvwAppList
		{
			[CompilerGenerated]
			get
			{
				return this._lvwAppList;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ColumnClickEventHandler columnClickEventHandler = new ColumnClickEventHandler(this.lvwAppList_ColumnClick);
				ListView listView = this._lvwAppList;
				if (listView != null)
				{
					listView.ColumnClick -= columnClickEventHandler;
				}
				this._lvwAppList = value;
				listView = this._lvwAppList;
				if (listView != null)
				{
					listView.ColumnClick += columnClickEventHandler;
				}
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600035B RID: 859 RVA: 0x000156EF File Offset: 0x000138EF
		// (set) Token: 0x0600035C RID: 860 RVA: 0x000156F9 File Offset: 0x000138F9
		internal virtual ColumnHeader colAppId
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00015702 File Offset: 0x00013902
		// (set) Token: 0x0600035E RID: 862 RVA: 0x0001570C File Offset: 0x0001390C
		internal virtual ColumnHeader colName
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00015715 File Offset: 0x00013915
		// (set) Token: 0x06000360 RID: 864 RVA: 0x0001571F File Offset: 0x0001391F
		internal virtual ColumnHeader colType
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00015728 File Offset: 0x00013928
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00015732 File Offset: 0x00013932
		internal virtual ColumnHeader colGenre
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0001573B File Offset: 0x0001393B
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00015745 File Offset: 0x00013945
		internal virtual ColumnHeader colPublisher
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0001574E File Offset: 0x0001394E
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00015758 File Offset: 0x00013958
		internal virtual ColumnHeader colDeveloper
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00015761 File Offset: 0x00013961
		// (set) Token: 0x06000368 RID: 872 RVA: 0x0001576B File Offset: 0x0001396B
		internal virtual ColumnHeader colExecutable
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00015774 File Offset: 0x00013974
		// (set) Token: 0x0600036A RID: 874 RVA: 0x0001577E File Offset: 0x0001397E
		internal virtual ColumnHeader colArguments
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00015787 File Offset: 0x00013987
		// (set) Token: 0x0600036C RID: 876 RVA: 0x00015791 File Offset: 0x00013991
		internal virtual ColumnHeader colOSList
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0001579A File Offset: 0x0001399A
		// (set) Token: 0x0600036E RID: 878 RVA: 0x000157A4 File Offset: 0x000139A4
		internal virtual ColumnHeader colReleaseDate
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600036F RID: 879 RVA: 0x000157AD File Offset: 0x000139AD
		// (set) Token: 0x06000370 RID: 880 RVA: 0x000157B7 File Offset: 0x000139B7
		internal virtual ColumnHeader colDescription
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000371 RID: 881 RVA: 0x000157C0 File Offset: 0x000139C0
		// (set) Token: 0x06000372 RID: 882 RVA: 0x000157CA File Offset: 0x000139CA
		internal virtual ToolStrip tsApps
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000373 RID: 883 RVA: 0x000157D3 File Offset: 0x000139D3
		// (set) Token: 0x06000374 RID: 884 RVA: 0x000157DD File Offset: 0x000139DD
		internal virtual StatusStrip ssApps
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000375 RID: 885 RVA: 0x000157E6 File Offset: 0x000139E6
		// (set) Token: 0x06000376 RID: 886 RVA: 0x000157F0 File Offset: 0x000139F0
		internal virtual ToolStripButton tsbImportApps
		{
			[CompilerGenerated]
			get
			{
				return this._tsbImportApps;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbImportApps_Click);
				ToolStripButton toolStripButton = this._tsbImportApps;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbImportApps = value;
				toolStripButton = this._tsbImportApps;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00015833 File Offset: 0x00013A33
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00015840 File Offset: 0x00013A40
		internal virtual ToolStripButton tsbDownloadAssets
		{
			[CompilerGenerated]
			get
			{
				return this._tsbDownloadAssets;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbDownloadAssets_Click);
				ToolStripButton toolStripButton = this._tsbDownloadAssets;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbDownloadAssets = value;
				toolStripButton = this._tsbDownloadAssets;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00015883 File Offset: 0x00013A83
		// (set) Token: 0x0600037A RID: 890 RVA: 0x0001588D File Offset: 0x00013A8D
		internal virtual ColumnHeader colLibraryFolder
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00015896 File Offset: 0x00013A96
		// (set) Token: 0x0600037C RID: 892 RVA: 0x000158A0 File Offset: 0x00013AA0
		internal virtual ColumnHeader colInstallDir
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600037D RID: 893 RVA: 0x000158A9 File Offset: 0x00013AA9
		// (set) Token: 0x0600037E RID: 894 RVA: 0x000158B3 File Offset: 0x00013AB3
		internal virtual ContextMenuStrip cmsApps
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600037F RID: 895 RVA: 0x000158BC File Offset: 0x00013ABC
		// (set) Token: 0x06000380 RID: 896 RVA: 0x000158C8 File Offset: 0x00013AC8
		internal virtual ToolStripMenuItem tsmiOpenFileLocation
		{
			[CompilerGenerated]
			get
			{
				return this._tsmiOpenFileLocation;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsmiOpenFileLocation_Click);
				ToolStripMenuItem toolStripMenuItem = this._tsmiOpenFileLocation;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._tsmiOpenFileLocation = value;
				toolStripMenuItem = this._tsmiOpenFileLocation;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0001590B File Offset: 0x00013B0B
		// (set) Token: 0x06000382 RID: 898 RVA: 0x00015918 File Offset: 0x00013B18
		internal virtual ToolStripMenuItem tsmiLaunchApp
		{
			[CompilerGenerated]
			get
			{
				return this._tsmiLaunchApp;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsmiLaunchApp_Click);
				ToolStripMenuItem toolStripMenuItem = this._tsmiLaunchApp;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._tsmiLaunchApp = value;
				toolStripMenuItem = this._tsmiLaunchApp;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0001595B File Offset: 0x00013B5B
		// (set) Token: 0x06000384 RID: 900 RVA: 0x00015968 File Offset: 0x00013B68
		internal virtual ToolStripButton tsbRemoveApps
		{
			[CompilerGenerated]
			get
			{
				return this._tsbRemoveApps;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbRemoveApps_Click);
				ToolStripButton toolStripButton = this._tsbRemoveApps;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbRemoveApps = value;
				toolStripButton = this._tsbRemoveApps;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000385 RID: 901 RVA: 0x000159AB File Offset: 0x00013BAB
		// (set) Token: 0x06000386 RID: 902 RVA: 0x000159B5 File Offset: 0x00013BB5
		internal virtual ColumnHeader colInstalled
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000387 RID: 903 RVA: 0x000159BE File Offset: 0x00013BBE
		// (set) Token: 0x06000388 RID: 904 RVA: 0x000159C8 File Offset: 0x00013BC8
		internal virtual ImageList imApps
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000389 RID: 905 RVA: 0x000159D1 File Offset: 0x00013BD1
		// (set) Token: 0x0600038A RID: 906 RVA: 0x000159DC File Offset: 0x00013BDC
		internal virtual ToolStripButton tsbRefresh
		{
			[CompilerGenerated]
			get
			{
				return this._tsbRefresh;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbRefresh_Click);
				ToolStripButton toolStripButton = this._tsbRefresh;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbRefresh = value;
				toolStripButton = this._tsbRefresh;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00015A1F File Offset: 0x00013C1F
		// (set) Token: 0x0600038C RID: 908 RVA: 0x00015A29 File Offset: 0x00013C29
		internal virtual ToolStripSeparator toolStripSeparator3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00015A32 File Offset: 0x00013C32
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00015A3C File Offset: 0x00013C3C
		internal virtual ToolStripButton tsbSelectAll
		{
			[CompilerGenerated]
			get
			{
				return this._tsbSelectAll;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbSelectAll_Click);
				ToolStripButton toolStripButton = this._tsbSelectAll;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbSelectAll = value;
				toolStripButton = this._tsbSelectAll;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00015A7F File Offset: 0x00013C7F
		// (set) Token: 0x06000390 RID: 912 RVA: 0x00015A8C File Offset: 0x00013C8C
		internal virtual ToolStripButton tsbClear
		{
			[CompilerGenerated]
			get
			{
				return this._tsbClear;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbClear_Click);
				ToolStripButton toolStripButton = this._tsbClear;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbClear = value;
				toolStripButton = this._tsbClear;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00015ACF File Offset: 0x00013CCF
		// (set) Token: 0x06000392 RID: 914 RVA: 0x00015AD9 File Offset: 0x00013CD9
		internal virtual ToolStripSeparator toolStripSeparator1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00015AE2 File Offset: 0x00013CE2
		// (set) Token: 0x06000394 RID: 916 RVA: 0x00015AEC File Offset: 0x00013CEC
		internal virtual ToolStripSeparator toolStripSeparator2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00015AF5 File Offset: 0x00013CF5
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00015B00 File Offset: 0x00013D00
		internal virtual ToolStripButton tsbStartService
		{
			[CompilerGenerated]
			get
			{
				return this._tsbStartService;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbStartService_Click);
				ToolStripButton toolStripButton = this._tsbStartService;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbStartService = value;
				toolStripButton = this._tsbStartService;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00015B43 File Offset: 0x00013D43
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00015B50 File Offset: 0x00013D50
		internal virtual ToolStripButton tsbStopService
		{
			[CompilerGenerated]
			get
			{
				return this._tsbStopService;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbStopService_Click);
				ToolStripButton toolStripButton = this._tsbStopService;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbStopService = value;
				toolStripButton = this._tsbStopService;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00015B93 File Offset: 0x00013D93
		// (set) Token: 0x0600039A RID: 922 RVA: 0x00015B9D File Offset: 0x00013D9D
		internal virtual ToolStripSeparator toolStripSeparator4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00015BA6 File Offset: 0x00013DA6
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00015BB0 File Offset: 0x00013DB0
		internal virtual ToolStripCheckBox tscbVrManifest
		{
			[CompilerGenerated]
			get
			{
				return this._tscbVrManifest;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tscbVrManifest_CheckedChanged);
				ToolStripCheckBox toolStripCheckBox = this._tscbVrManifest;
				if (toolStripCheckBox != null)
				{
					toolStripCheckBox.CheckedChanged -= eventHandler;
				}
				this._tscbVrManifest = value;
				toolStripCheckBox = this._tscbVrManifest;
				if (toolStripCheckBox != null)
				{
					toolStripCheckBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00015BF3 File Offset: 0x00013DF3
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00015BFD File Offset: 0x00013DFD
		internal virtual ToolStripSpringTextBox tstbSearch
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00015C06 File Offset: 0x00013E06
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00015C10 File Offset: 0x00013E10
		internal virtual ToolStripButton tsbSearch
		{
			[CompilerGenerated]
			get
			{
				return this._tsbSearch;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbSearch_Click);
				ToolStripButton toolStripButton = this._tsbSearch;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbSearch = value;
				toolStripButton = this._tsbSearch;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00015C53 File Offset: 0x00013E53
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00015C60 File Offset: 0x00013E60
		internal virtual ToolStripButton tsbRestartService
		{
			[CompilerGenerated]
			get
			{
				return this._tsbRestartService;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsbRestartService_Click);
				ToolStripButton toolStripButton = this._tsbRestartService;
				if (toolStripButton != null)
				{
					toolStripButton.Click -= eventHandler;
				}
				this._tsbRestartService = value;
				toolStripButton = this._tsbRestartService;
				if (toolStripButton != null)
				{
					toolStripButton.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00015CA3 File Offset: 0x00013EA3
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00015CAD File Offset: 0x00013EAD
		internal virtual ToolStripLabel tslSearch
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00015CB6 File Offset: 0x00013EB6
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00015CC0 File Offset: 0x00013EC0
		internal virtual ToolStripSeparator toolStripSeparator5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00015CC9 File Offset: 0x00013EC9
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00015CD3 File Offset: 0x00013ED3
		internal virtual Panel panel1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00015CDC File Offset: 0x00013EDC
		// (set) Token: 0x060003AA RID: 938 RVA: 0x00015CE8 File Offset: 0x00013EE8
		internal virtual PictureBox pictureBox1
		{
			[CompilerGenerated]
			get
			{
				return this._pictureBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.pictureBox1_Click);
				PictureBox pictureBox = this._pictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._pictureBox1 = value;
				pictureBox = this._pictureBox1;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00015D2B File Offset: 0x00013F2B
		// (set) Token: 0x060003AC RID: 940 RVA: 0x00015D38 File Offset: 0x00013F38
		internal virtual ToolStripStatusLabel tsslHeadsoftLogo
		{
			[CompilerGenerated]
			get
			{
				return this._tsslHeadsoftLogo;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tsslHeadsoftLogo_Click);
				ToolStripStatusLabel toolStripStatusLabel = this._tsslHeadsoftLogo;
				if (toolStripStatusLabel != null)
				{
					toolStripStatusLabel.Click -= eventHandler;
				}
				this._tsslHeadsoftLogo = value;
				toolStripStatusLabel = this._tsslHeadsoftLogo;
				if (toolStripStatusLabel != null)
				{
					toolStripStatusLabel.Click += eventHandler;
				}
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00015D7C File Offset: 0x00013F7C
		public frmImportSteamApps()
		{
			base.Load += this.frmImportSteamApps_Load;
			base.Resize += this.frmImportSteamApps_Resize;
			base.FormClosing += this.frmImportSteamApps_FormClosing;
			this.components = null;
			this.m_lvwColumnSorter = null;
			this.InitializeComponent();
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00015DE0 File Offset: 0x00013FE0
		private void frmImportSteamApps_Load(object sender, EventArgs e)
		{
			this.tscbVrManifest.Checked = true;
			bool flag = MySettingsProperty.Settings.SteamWindowLocation != default(Point);
			if (flag)
			{
				base.Location = MySettingsProperty.Settings.SteamWindowLocation;
			}
			else
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Setting Steam GUI location to Center Screen");
				}
				base.CenterToScreen();
				MySettingsProperty.Settings.SteamWindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			bool flag2 = (base.Location.X < 0) | (base.Location.Y < 0);
			if (flag2)
			{
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Steam GUI location has negative number, adjusting");
				}
				base.CenterToScreen();
				MySettingsProperty.Settings.SteamWindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			bool flag3 = MySettingsProperty.Settings.SteamWindowSize != default(Size);
			if (flag3)
			{
				base.Size = MySettingsProperty.Settings.SteamWindowSize;
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00015EF8 File Offset: 0x000140F8
		private void UpdateAppListView()
		{
			try
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Updating list of Steam games");
				}
				bool flag = !Globals.oculus.TryRefresh();
				if (!flag)
				{
					bool flag2 = !Globals.steam.TryRefresh();
					if (!flag2)
					{
						List<SteamNode> list = null;
						bool @checked = this.tscbVrManifest.Checked;
						if (@checked)
						{
							bool flag3 = !Globals.steam.TryGetVRManifest(ref list);
							if (flag3)
							{
								return;
							}
							bool flag4 = !Globals.steam.TryGetAppInfo(list, true, true);
							if (flag4)
							{
								return;
							}
						}
						else
						{
							Dictionary<ulong, SteamNode> dictionary = null;
							bool flag5 = !Globals.steam.TryGetAppInfo(true, true, ref dictionary, ref list);
							if (flag5)
							{
								return;
							}
						}
						this.m_lvwColumnSorter = new ListViewColumnSorter();
						this.m_lvwColumnSorter.SortColumn = 2;
						this.m_lvwColumnSorter.Order = SortOrder.Ascending;
						this.lvwAppList.Items.Clear();
						this.lvwAppList.ListViewItemSorter = this.m_lvwColumnSorter;
						List<ListViewItem> list2 = new List<ListViewItem>();
						try
						{
							foreach (SteamNode steamNode in list)
							{
								bool flag6 = Globals.oculus.IsAppInstalled(steamNode);
								bool flag7 = !string.IsNullOrEmpty(this.tstbSearch.Text) && steamNode.Name.IndexOf(this.tstbSearch.Text, StringComparison.CurrentCultureIgnoreCase) == -1;
								if (!flag7)
								{
									list2.Add(new ListViewItem(new string[]
									{
										"",
										steamNode.AppId.ToString(),
										steamNode.Name,
										steamNode.Type,
										steamNode.Genre,
										steamNode.Publisher,
										steamNode.Developer,
										steamNode.Executable,
										steamNode.Parameters,
										steamNode.OSList,
										steamNode.ReleaseDateString,
										steamNode.Description,
										steamNode.LibraryFolder,
										steamNode.InstallDir
									})
									{
										ImageIndex = (flag6 ? 0 : 1),
										Tag = steamNode
									});
								}
							}
						}
						finally
						{
							List<SteamNode>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						this.lvwAppList.Items.AddRange(list2.ToArray());
						try
						{
							foreach (object obj in this.lvwAppList.Columns)
							{
								ColumnHeader columnHeader = (ColumnHeader)obj;
								bool flag8 = Operators.CompareString(columnHeader.Text, "Description", false) == 0;
								if (!flag8)
								{
									columnHeader.Width = -2;
								}
							}
						}
						finally
						{
							IEnumerator enumerator2;
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						this.lvwAppList.Sort();
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("Update complete");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog(ex.Message);
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0001626C File Offset: 0x0001446C
		private void lvwAppList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			bool flag = e.Column == this.m_lvwColumnSorter.SortColumn;
			if (flag)
			{
				this.m_lvwColumnSorter.Order = ((this.m_lvwColumnSorter.Order == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending);
			}
			else
			{
				this.m_lvwColumnSorter.SortColumn = e.Column;
				this.m_lvwColumnSorter.Order = SortOrder.Ascending;
			}
			this.lvwAppList.Sort();
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x000162DF File Offset: 0x000144DF
		private void tsbRefresh_Click(object sender, EventArgs e)
		{
			this.UpdateAppListView();
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000162E9 File Offset: 0x000144E9
		private void tsbImportApps_Click(object sender, EventArgs e)
		{
			this.ImportSelectedApps();
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x000162F3 File Offset: 0x000144F3
		private void tsbRemoveApps_Click(object sender, EventArgs e)
		{
			this.RemoveSelectedApps();
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00016300 File Offset: 0x00014500
		private void tsbSelectAll_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (object obj in this.lvwAppList.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					listViewItem.Checked = true;
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

		// Token: 0x060003B5 RID: 949 RVA: 0x00016368 File Offset: 0x00014568
		private void tsbClear_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (object obj in this.lvwAppList.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					listViewItem.Checked = false;
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

		// Token: 0x060003B6 RID: 950 RVA: 0x000163D0 File Offset: 0x000145D0
		private void tsbDownloadAssets_Click(object sender, EventArgs e)
		{
			this.DownloadSelectedAssets();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000163DA File Offset: 0x000145DA
		private void tsbStartService_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			Globals.oculus.TryStartOculusService();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00016400 File Offset: 0x00014600
		private void tsbStopService_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			Globals.oculus.TryStopOculusService();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00016426 File Offset: 0x00014626
		private void tsbRestartService_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			Globals.oculus.TryRestartOculusService();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000162DF File Offset: 0x000144DF
		private void tscbVrManifest_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateAppListView();
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000162DF File Offset: 0x000144DF
		private void tsbSearch_Click(object sender, EventArgs e)
		{
			this.UpdateAppListView();
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0001644C File Offset: 0x0001464C
		private void ImportSelectedApps()
		{
			try
			{
				frmImportSteamApps._Closure$__189-0 CS$<>8__locals1 = new frmImportSteamApps._Closure$__189-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Me = this;
				bool debug = MyProject.Forms.FrmMain.debug;
				if (debug)
				{
					Log.WriteToLog("Importing selected apps");
				}
				CS$<>8__locals1.$VB$Local_steamList = null;
				bool flag = !this.TryGetSelectedSteamList(ref CS$<>8__locals1.$VB$Local_steamList);
				if (!flag)
				{
					CS$<>8__locals1.$VB$Local_frmProcessing = new frmProcessing();
					CS$<>8__locals1.$VB$Local_backgroundWorker = new BackgroundWorker();
					CS$<>8__locals1.$VB$Local_backgroundWorker.WorkerReportsProgress = false;
					CS$<>8__locals1.$VB$Local_backgroundWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
					{
						try
						{
							foreach (SteamNode steamNode in CS$<>8__locals1.$VB$Local_steamList)
							{
								bool flag2 = !CS$<>8__locals1.$VB$Me.TryRemoveApp(CS$<>8__locals1.$VB$Local_frmProcessing, steamNode);
								if (!flag2)
								{
									Log.WriteToLog("Importing '" + steamNode.Name + "'");
									Globals.oculus.TryCreateManifest(steamNode, SteamLaunchType.App);
									Globals.oculus.TryDownloadAppHeader(steamNode, (CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = delegate(object _sender, DownloadProgressChangedEventArgs _e)
									{
										object[] array = (object[])_e.UserState;
										Uri uri = (Uri)array[0];
										object objectValue = RuntimeHelpers.GetObjectValue(array[1]);
										object objectValue2 = RuntimeHelpers.GetObjectValue(array[2]);
										CS$<>8__locals1.$VB$Local_frmProcessing.UpdateProgressBar(_e.ProgressPercentage, string.Format("Downloading '{0}'...", RuntimeHelpers.GetObjectValue(objectValue2)));
									}) : CS$<>8__locals1.$I1);
								}
							}
						}
						finally
						{
							List<SteamNode>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						Globals.oculus.TryRestartOculusService();
					};
					CS$<>8__locals1.$VB$Local_backgroundWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
					{
						CS$<>8__locals1.$VB$Local_backgroundWorker.Dispose();
						CS$<>8__locals1.$VB$Local_frmProcessing.Close();
						CS$<>8__locals1.$VB$Me.UpdateAppListView();
					};
					CS$<>8__locals1.$VB$Local_backgroundWorker.RunWorkerAsync();
					CS$<>8__locals1.$VB$Local_frmProcessing.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ImportSelectedApps: " + ex.Message);
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001654C File Offset: 0x0001474C
		private void RemoveSelectedApps()
		{
			try
			{
				List<SteamNode> list = null;
				bool flag = !this.TryGetSelectedSteamList(ref list);
				if (!flag)
				{
					try
					{
						foreach (SteamNode steamNode in list)
						{
							this.TryRemoveApp(this, steamNode);
							Log.WriteToLog("'" + steamNode.Name + "' has been removed");
						}
					}
					finally
					{
						List<SteamNode>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					this.UpdateAppListView();
					Globals.oculus.TryRestartOculusService();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("RemoveSelectedApps: " + ex.Message);
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00016620 File Offset: 0x00014820
		private void DownloadSelectedAssets()
		{
			try
			{
				frmImportSteamApps._Closure$__191-0 CS$<>8__locals1 = new frmImportSteamApps._Closure$__191-0(CS$<>8__locals1);
				CS$<>8__locals1.$VB$Me = this;
				CS$<>8__locals1.$VB$Local_steamList = null;
				bool flag = !this.TryGetSelectedSteamList(ref CS$<>8__locals1.$VB$Local_steamList);
				if (!flag)
				{
					CS$<>8__locals1.$VB$Local_syncObject = RuntimeHelpers.GetObjectValue(new object());
					CS$<>8__locals1.$VB$Local_frmProcessing = new frmProcessing();
					CS$<>8__locals1.$VB$Local_backgroundWorker = new BackgroundWorker();
					CS$<>8__locals1.$VB$Local_backgroundWorker.WorkerReportsProgress = false;
					CS$<>8__locals1.$VB$Local_backgroundWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
					{
						string text = Path.Combine(Application.StartupPath, "Assets");
						List<DownloadFileNode> list = new List<DownloadFileNode>();
						try
						{
							foreach (SteamNode steamNode in CS$<>8__locals1.$VB$Local_steamList)
							{
								string tempPath = Path.GetTempPath();
								string text2 = Path.Combine(tempPath, string.Format("{0}.json", steamNode.AppId));
								bool flag2 = !Globals.steam.TryDownloadAppDetails(steamNode.AppId, text2);
								if (!flag2)
								{
									string text3 = File.ReadAllText(text2);
									bool flag3 = !steamNode.TryParseAppDetails(text3);
									if (!flag3)
									{
										try
										{
											foreach (SteamScreenshotNode steamScreenshotNode in steamNode.ScreenshotList)
											{
												Uri uri = new Uri(steamScreenshotNode.FullPath);
												string text4 = Path.Combine(text, steamNode.AppId.ToString());
												DownloadFileNode downloadFileNode = new DownloadFileNode(steamScreenshotNode.FullPath, text4);
												bool debug = MyProject.Forms.FrmMain.debug;
												if (debug)
												{
													Log.WriteToLog(steamScreenshotNode.FullPath.ToString() + " added to download list");
												}
												list.Add(downloadFileNode);
											}
										}
										finally
										{
											List<SteamScreenshotNode>.Enumerator enumerator2;
											((IDisposable)enumerator2).Dispose();
										}
									}
								}
							}
						}
						finally
						{
							List<SteamNode>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						FileDownloader fileDownloader = new FileDownloader(list);
						fileDownloader.FileDownloadProgressChanged += ((CS$<>8__locals1.$I1 == null) ? (CS$<>8__locals1.$I1 = delegate(object _sender, FileDownloadProgressChangedEventArgs _e)
						{
							CS$<>8__locals1.$VB$Local_frmProcessing.UpdateProgressBar(_e.TotalProgressPercentage, "Downloading Assets...");
						}) : CS$<>8__locals1.$I1);
						fileDownloader.AllFilesDownloadCompleted += ((CS$<>8__locals1.$I2 == null) ? (CS$<>8__locals1.$I2 = delegate(object _sender, EventArgs _e)
						{
							object $VB$Local_syncObject2 = CS$<>8__locals1.$VB$Local_syncObject;
							ObjectFlowControl.CheckForSyncLockOnValueType($VB$Local_syncObject2);
							lock ($VB$Local_syncObject2)
							{
								Monitor.Pulse(RuntimeHelpers.GetObjectValue(CS$<>8__locals1.$VB$Local_syncObject));
							}
						}) : CS$<>8__locals1.$I2);
						object $VB$Local_syncObject = CS$<>8__locals1.$VB$Local_syncObject;
						ObjectFlowControl.CheckForSyncLockOnValueType($VB$Local_syncObject);
						lock ($VB$Local_syncObject)
						{
							fileDownloader.Start();
							Monitor.Wait(RuntimeHelpers.GetObjectValue(CS$<>8__locals1.$VB$Local_syncObject));
						}
					};
					CS$<>8__locals1.$VB$Local_backgroundWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
					{
						CS$<>8__locals1.$VB$Local_backgroundWorker.Dispose();
						CS$<>8__locals1.$VB$Local_frmProcessing.Close();
						CS$<>8__locals1.$VB$Me.UpdateAppListView();
					};
					CS$<>8__locals1.$VB$Local_backgroundWorker.RunWorkerAsync();
					CS$<>8__locals1.$VB$Local_frmProcessing.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("DownloadSelectedAssets: " + ex.Message);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00016714 File Offset: 0x00014914
		private bool TryGetSelectedSteamList(ref List<SteamNode> steamList)
		{
			bool flag2;
			try
			{
				steamList = null;
				bool flag = this.lvwAppList.CheckedItems.Count <= 0;
				if (flag)
				{
					flag2 = false;
				}
				else
				{
					steamList = new List<SteamNode>();
					try
					{
						foreach (object obj in this.lvwAppList.CheckedItems)
						{
							ListViewItem listViewItem = (ListViewItem)obj;
							SteamNode steamNode = (SteamNode)listViewItem.Tag;
							steamList.Add(steamNode);
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
					flag2 = true;
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetSelectedSteamList: " + ex.Message);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000167F4 File Offset: 0x000149F4
		private void tsmiLaunchApp_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.lvwAppList.SelectedItems.Count <= 0;
				if (!flag)
				{
					ListViewItem listViewItem = this.lvwAppList.SelectedItems[0];
					SteamNode steamNode = (SteamNode)listViewItem.Tag;
					Globals.steam.TryLaunchApp(steamNode.AppId, steamNode.Parameters);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Could not launch app: " + ex.Message);
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00016890 File Offset: 0x00014A90
		private void tsmiOpenFileLocation_Click(object sender, EventArgs e)
		{
			bool flag = this.lvwAppList.SelectedItems.Count <= 0;
			if (!flag)
			{
				ListViewItem listViewItem = this.lvwAppList.SelectedItems[0];
				SteamNode steamNode = (SteamNode)listViewItem.Tag;
				string fullPath = steamNode.FullPath;
				bool flag2 = string.IsNullOrEmpty(fullPath);
				if (!flag2)
				{
					bool flag3 = !File.Exists(fullPath);
					if (!flag3)
					{
						Process.Start("explorer.exe", string.Format("/select,\"{0}\"", fullPath));
					}
				}
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00016918 File Offset: 0x00014B18
		private bool TryRemoveApp(Control control, SteamNode steamNode)
		{
			frmImportSteamApps._Closure$__195-0 CS$<>8__locals1 = new frmImportSteamApps._Closure$__195-0(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_control = control;
			CS$<>8__locals1.$VB$Local_steamNode = steamNode;
			bool flag5;
			try
			{
				List<string> list = null;
				List<string> list2 = null;
				bool flag = Globals.oculus.TryGetManifestFileNameAndAssetFolderList(CS$<>8__locals1.$VB$Local_steamNode, ref list, ref list2);
				if (flag)
				{
					bool flag2 = Conversions.ToInteger(CS$<>8__locals1.$VB$Local_control.Invoke(new frmImportSteamApps.Func<DialogResult>(() => MessageBox.Show(CS$<>8__locals1.$VB$Local_control, string.Format("'{0}' Is In Your Library.\r\nDo You Want To Delete It?", CS$<>8__locals1.$VB$Local_steamNode.Name), "Delete App?", MessageBoxButtons.YesNo)))) != 6;
					if (flag2)
					{
						return false;
					}
					try
					{
						foreach (string text in list)
						{
							bool flag3 = File.Exists(text);
							if (flag3)
							{
								File.Delete(text);
								bool dbg = Globals.dbg;
								if (dbg)
								{
									Log.WriteToLog(text + " deleted");
								}
							}
						}
					}
					finally
					{
						List<string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					try
					{
						foreach (string text2 in list2)
						{
							bool flag4 = Directory.Exists(text2);
							if (flag4)
							{
								Directory.Delete(text2, true);
								bool dbg2 = Globals.dbg;
								if (dbg2)
								{
									Log.WriteToLog(text2 + " deleted");
								}
							}
						}
					}
					finally
					{
						List<string>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
				flag5 = true;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryRemoveApp: " + ex.Message);
			}
			return flag5;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00016AD8 File Offset: 0x00014CD8
		private void frmImportSteamApps_Resize(object sender, EventArgs e)
		{
			checked
			{
				this.pictureBox1.Location = new Point((int)Math.Round(unchecked((double)base.ClientSize.Width / 2.0 - (double)this.pictureBox1.Width / 2.0)), 0);
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00016B2E File Offset: 0x00014D2E
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("http://headsoft.com.au/redirect.php?url=https://www.mechatech.co.uk/");
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00016B3C File Offset: 0x00014D3C
		private void tsslHeadsoftLogo_Click(object sender, EventArgs e)
		{
			Process.Start("http://headsoft.com.au/");
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00016B4A File Offset: 0x00014D4A
		private void frmImportSteamApps_FormClosing(object sender, FormClosingEventArgs e)
		{
			MySettingsProperty.Settings.SteamWindowLocation = base.Location;
			MySettingsProperty.Settings.SteamWindowSize = base.Size;
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x04000139 RID: 313
		private ListViewColumnSorter m_lvwColumnSorter;

		// Token: 0x02000069 RID: 105
		// (Invoke) Token: 0x06000A11 RID: 2577
		private delegate T Func<T>();

		// Token: 0x0200006A RID: 106
		// (Invoke) Token: 0x06000A15 RID: 2581
		private delegate void Func();
	}
}
