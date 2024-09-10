using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;
using OculusTrayTool.MyNameSpace;

namespace OculusTrayTool
{
	// Token: 0x02000057 RID: 87
	[DesignerGenerated]
	public partial class frmProfiles : Form
	{
		// Token: 0x06000809 RID: 2057 RVA: 0x0004A6D0 File Offset: 0x000488D0
		public frmProfiles()
		{
			base.FormClosing += this.scan_FormClosing;
			base.Load += this.scan_Load;
			this.rs = new Resizer();
			this.sortColumn = -1;
			this.GameList = new Dictionary<string, string>();
			this.InitializeComponent();
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0004CC80 File Offset: 0x0004AE80
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x0004CC8C File Offset: 0x0004AE8C
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
				EventHandler eventHandler = new EventHandler(this.ListView1_DoubleClick);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.ListView1_MouseMove);
				DrawListViewColumnHeaderEventHandler drawListViewColumnHeaderEventHandler = new DrawListViewColumnHeaderEventHandler(this.ListView1_DrawColumnHeader);
				DrawListViewItemEventHandler drawListViewItemEventHandler = new DrawListViewItemEventHandler(this.ListView1_DrawItem);
				DrawListViewSubItemEventHandler drawListViewSubItemEventHandler = new DrawListViewSubItemEventHandler(this.ListView1_DrawSubItem);
				EventHandler eventHandler2 = new EventHandler(this.ListView1_MouseHover);
				EventHandler eventHandler3 = new EventHandler(this.ListView1_Click);
				ListView listView = this._ListView1;
				if (listView != null)
				{
					listView.DoubleClick -= eventHandler;
					listView.MouseMove -= mouseEventHandler;
					listView.DrawColumnHeader -= drawListViewColumnHeaderEventHandler;
					listView.DrawItem -= drawListViewItemEventHandler;
					listView.DrawSubItem -= drawListViewSubItemEventHandler;
					listView.MouseHover -= eventHandler2;
					listView.Click -= eventHandler3;
				}
				this._ListView1 = value;
				listView = this._ListView1;
				if (listView != null)
				{
					listView.DoubleClick += eventHandler;
					listView.MouseMove += mouseEventHandler;
					listView.DrawColumnHeader += drawListViewColumnHeaderEventHandler;
					listView.DrawItem += drawListViewItemEventHandler;
					listView.DrawSubItem += drawListViewSubItemEventHandler;
					listView.MouseHover += eventHandler2;
					listView.Click += eventHandler3;
				}
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0004CD8C File Offset: 0x0004AF8C
		// (set) Token: 0x0600080F RID: 2063 RVA: 0x0004CD96 File Offset: 0x0004AF96
		internal virtual ColumnHeader ColumnHeader1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0004CD9F File Offset: 0x0004AF9F
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x0004CDA9 File Offset: 0x0004AFA9
		internal virtual ColumnHeader ColumnHeader2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0004CDB2 File Offset: 0x0004AFB2
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x0004CDBC File Offset: 0x0004AFBC
		internal virtual ColumnHeader ColumnHeader3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0004CDC5 File Offset: 0x0004AFC5
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x0004CDD0 File Offset: 0x0004AFD0
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

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x0004CE13 File Offset: 0x0004B013
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x0004CE1D File Offset: 0x0004B01D
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0004CE26 File Offset: 0x0004B026
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x0004CE30 File Offset: 0x0004B030
		internal virtual ColumnHeader ColumnHeader4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0004CE39 File Offset: 0x0004B039
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0004CE43 File Offset: 0x0004B043
		internal virtual GroupBox GroupBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0004CE4C File Offset: 0x0004B04C
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x0004CE56 File Offset: 0x0004B056
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0004CE5F File Offset: 0x0004B05F
		// (set) Token: 0x0600081F RID: 2079 RVA: 0x0004CE6C File Offset: 0x0004B06C
		internal virtual CheckBox CheckVoiceConfirm
		{
			[CompilerGenerated]
			get
			{
				return this._CheckVoiceConfirm;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckVoiceConfirm_CheckedChanged);
				CheckBox checkBox = this._CheckVoiceConfirm;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckVoiceConfirm = value;
				checkBox = this._CheckVoiceConfirm;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0004CEAF File Offset: 0x0004B0AF
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x0004CEBC File Offset: 0x0004B0BC
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

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0004CF1A File Offset: 0x0004B11A
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x0004CF24 File Offset: 0x0004B124
		internal virtual ToolStripMenuItem ToolStripMenuItem1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0004CF2D File Offset: 0x0004B12D
		// (set) Token: 0x06000825 RID: 2085 RVA: 0x0004CF37 File Offset: 0x0004B137
		internal virtual ToolStripMenuItem ToolStripMenuItem2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x0004CF40 File Offset: 0x0004B140
		// (set) Token: 0x06000827 RID: 2087 RVA: 0x0004CF4C File Offset: 0x0004B14C
		internal virtual ToolStripMenuItem ToolStripMenuItem3
		{
			[CompilerGenerated]
			get
			{
				return this._ToolStripMenuItem3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem3_Click);
				ToolStripMenuItem toolStripMenuItem = this._ToolStripMenuItem3;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._ToolStripMenuItem3 = value;
				toolStripMenuItem = this._ToolStripMenuItem3;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0004CF8F File Offset: 0x0004B18F
		// (set) Token: 0x06000829 RID: 2089 RVA: 0x0004CF9C File Offset: 0x0004B19C
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

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0004CFDF File Offset: 0x0004B1DF
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x0004CFEC File Offset: 0x0004B1EC
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

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x0004D02F File Offset: 0x0004B22F
		// (set) Token: 0x0600082D RID: 2093 RVA: 0x0004D039 File Offset: 0x0004B239
		internal virtual ToolStripSeparator ToolStripSeparator1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0004D042 File Offset: 0x0004B242
		// (set) Token: 0x0600082F RID: 2095 RVA: 0x0004D04C File Offset: 0x0004B24C
		internal virtual ToolStripSeparator ToolStripSeparator2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x0004D055 File Offset: 0x0004B255
		// (set) Token: 0x06000831 RID: 2097 RVA: 0x0004D060 File Offset: 0x0004B260
		internal virtual ToolStripMenuItem LaunchAppToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._LaunchAppToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.LaunchAppToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._LaunchAppToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._LaunchAppToolStripMenuItem = value;
				toolStripMenuItem = this._LaunchAppToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x0004D0A3 File Offset: 0x0004B2A3
		// (set) Token: 0x06000833 RID: 2099 RVA: 0x0004D0B0 File Offset: 0x0004B2B0
		internal virtual ToolStripMenuItem LaunchAppWithOptionsToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._LaunchAppWithOptionsToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.LaunchAppWithOptionsToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._LaunchAppWithOptionsToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._LaunchAppWithOptionsToolStripMenuItem = value;
				toolStripMenuItem = this._LaunchAppWithOptionsToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0004D0F3 File Offset: 0x0004B2F3
		// (set) Token: 0x06000835 RID: 2101 RVA: 0x0004D100 File Offset: 0x0004B300
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

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x0004D143 File Offset: 0x0004B343
		// (set) Token: 0x06000837 RID: 2103 RVA: 0x0004D150 File Offset: 0x0004B350
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

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0004D193 File Offset: 0x0004B393
		// (set) Token: 0x06000839 RID: 2105 RVA: 0x0004D19D File Offset: 0x0004B39D
		internal virtual ToolStripSeparator ToolStripSeparator3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0004D1A6 File Offset: 0x0004B3A6
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x0004D1B0 File Offset: 0x0004B3B0
		internal virtual ToolStripMenuItem RemoveAllSelectedProfilesToolStripMenuItem
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0004D1B9 File Offset: 0x0004B3B9
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x0004D1C3 File Offset: 0x0004B3C3
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0004D1CC File Offset: 0x0004B3CC
		// (set) Token: 0x0600083F RID: 2111 RVA: 0x0004D1D8 File Offset: 0x0004B3D8
		internal virtual ComboBox ComboResolution
		{
			[CompilerGenerated]
			get
			{
				return this._ComboResolution;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboResolution_SelectedIndexChanged);
				ComboBox comboBox = this._ComboResolution;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._ComboResolution = value;
				comboBox = this._ComboResolution;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0004D21B File Offset: 0x0004B41B
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x0004D225 File Offset: 0x0004B425
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0004D22E File Offset: 0x0004B42E
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x0004D238 File Offset: 0x0004B438
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0004D241 File Offset: 0x0004B441
		// (set) Token: 0x06000845 RID: 2117 RVA: 0x0004D24B File Offset: 0x0004B44B
		internal virtual Label Label9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0004D254 File Offset: 0x0004B454
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x0004D25E File Offset: 0x0004B45E
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0004D267 File Offset: 0x0004B467
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x0004D271 File Offset: 0x0004B471
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0004D27A File Offset: 0x0004B47A
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x0004D284 File Offset: 0x0004B484
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x0004D28D File Offset: 0x0004B48D
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x0004D297 File Offset: 0x0004B497
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0004D2A0 File Offset: 0x0004B4A0
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x0004D2AA File Offset: 0x0004B4AA
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0004D2B3 File Offset: 0x0004B4B3
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x0004D2BD File Offset: 0x0004B4BD
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0004D2C6 File Offset: 0x0004B4C6
		// (set) Token: 0x06000853 RID: 2131 RVA: 0x0004D2D0 File Offset: 0x0004B4D0
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0004D2D9 File Offset: 0x0004B4D9
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x0004D2E3 File Offset: 0x0004B4E3
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0004D2EC File Offset: 0x0004B4EC
		// (set) Token: 0x06000857 RID: 2135 RVA: 0x0004D2F6 File Offset: 0x0004B4F6
		internal virtual Label Label15
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x0004D2FF File Offset: 0x0004B4FF
		// (set) Token: 0x06000859 RID: 2137 RVA: 0x0004D309 File Offset: 0x0004B509
		internal virtual Label Label14
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x0004D312 File Offset: 0x0004B512
		// (set) Token: 0x0600085B RID: 2139 RVA: 0x0004D31C File Offset: 0x0004B51C
		internal virtual DBLayoutPanel DbLayoutPanel1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x0004D325 File Offset: 0x0004B525
		// (set) Token: 0x0600085D RID: 2141 RVA: 0x0004D32F File Offset: 0x0004B52F
		internal virtual Label Label29
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0004D338 File Offset: 0x0004B538
		// (set) Token: 0x0600085F RID: 2143 RVA: 0x0004D342 File Offset: 0x0004B542
		internal virtual Label Label16
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x0004D34B File Offset: 0x0004B54B
		// (set) Token: 0x06000861 RID: 2145 RVA: 0x0004D355 File Offset: 0x0004B555
		internal virtual Label Label17
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0004D35E File Offset: 0x0004B55E
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x0004D368 File Offset: 0x0004B568
		internal virtual Label Label18
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0004D371 File Offset: 0x0004B571
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x0004D37B File Offset: 0x0004B57B
		internal virtual Label Label19
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0004D384 File Offset: 0x0004B584
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0004D38E File Offset: 0x0004B58E
		internal virtual Label Label20
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0004D397 File Offset: 0x0004B597
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x0004D3A1 File Offset: 0x0004B5A1
		internal virtual Label Label22
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0004D3AA File Offset: 0x0004B5AA
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0004D3B4 File Offset: 0x0004B5B4
		internal virtual Label Label23
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0004D3BD File Offset: 0x0004B5BD
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x0004D3C7 File Offset: 0x0004B5C7
		internal virtual Label Label24
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0004D3D0 File Offset: 0x0004B5D0
		// (set) Token: 0x0600086F RID: 2159 RVA: 0x0004D3DA File Offset: 0x0004B5DA
		internal virtual Label Label25
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x0004D3E3 File Offset: 0x0004B5E3
		// (set) Token: 0x06000871 RID: 2161 RVA: 0x0004D3ED File Offset: 0x0004B5ED
		internal virtual Label Label26
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0004D3F6 File Offset: 0x0004B5F6
		// (set) Token: 0x06000873 RID: 2163 RVA: 0x0004D400 File Offset: 0x0004B600
		internal virtual Label Label27
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0004D409 File Offset: 0x0004B609
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x0004D413 File Offset: 0x0004B613
		internal virtual Label Label28
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0004D41C File Offset: 0x0004B61C
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x0004D426 File Offset: 0x0004B626
		internal virtual Label Label30
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0004D42F File Offset: 0x0004B62F
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x0004D43C File Offset: 0x0004B63C
		internal virtual Button Button3
		{
			[CompilerGenerated]
			get
			{
				return this._Button3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button3_Click);
				Button button = this._Button3;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button3 = value;
				button = this._Button3;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0004D47F File Offset: 0x0004B67F
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x0004D489 File Offset: 0x0004B689
		internal virtual Label Label31
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0004D492 File Offset: 0x0004B692
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x0004D49C File Offset: 0x0004B69C
		internal virtual Label Label32
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x0004D4A5 File Offset: 0x0004B6A5
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x0004D4AF File Offset: 0x0004B6AF
		internal virtual TextBox TextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0004D4B8 File Offset: 0x0004B6B8
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x0004D4C2 File Offset: 0x0004B6C2
		internal virtual ColumnHeader ColumnHeader5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0004D4CC File Offset: 0x0004B6CC
		private void scan_FormClosing(object sender, FormClosingEventArgs e)
		{
			MySettingsProperty.Settings.ScanDialogSize = base.Size;
			MySettingsProperty.Settings.ScanWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
			bool flag = e.CloseReason == CloseReason.UserClosing;
			if (flag)
			{
				base.Hide();
				e.Cancel = true;
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0004D528 File Offset: 0x0004B728
		private void scan_Load(object sender, EventArgs e)
		{
			frmProfiles.SetDoubleBuffered(this.ListView1);
			base.Size = MySettingsProperty.Settings.ScanDialogSize;
			this.rs.FindAllControls(this);
			this.rs.ResizeAllControls(this, (float)MyProject.Forms.FrmMain.TrackBar1.Value);
			bool flag = MySettingsProperty.Settings.ScanWindowLocation != default(Point);
			if (flag)
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Setting Profiles GUI location to " + MySettingsProperty.Settings.ScanWindowLocation.ToString());
				}
				base.Location = MySettingsProperty.Settings.ScanWindowLocation;
			}
			else
			{
				base.CenterToScreen();
				MySettingsProperty.Settings.ScanWindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			bool flag2 = (base.Location.X < 0) | (base.Location.Y < 0);
			if (flag2)
			{
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Profiles GUI location has negative number, adjusting");
				}
				base.CenterToScreen();
				MySettingsProperty.Settings.ScanWindowLocation = base.Location;
				MySettingsProperty.Settings.Save();
			}
			this.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			this.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			base.Show();
			this.ComboResolution.Focus();
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0004D698 File Offset: 0x0004B898
		private bool FindItem(ListView.ListViewItemCollection ItemList, int ColumnIndex, string SearchString)
		{
			try
			{
				foreach (object obj in ItemList)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					bool flag = Operators.CompareString(listViewItem.SubItems[ColumnIndex].Text, SearchString, false) == 0;
					if (flag)
					{
						return true;
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
			return false;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0004D718 File Offset: 0x0004B918
		private void Button2_Click(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.ProfilesWindowLocation = base.Location;
			MySettingsProperty.Settings.ProfilesWindowSize = base.Size;
			MySettingsProperty.Settings.Save();
			base.Hide();
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0004D750 File Offset: 0x0004B950
		public static void SetDoubleBuffered(Control control)
		{
			typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, control, new object[] { true });
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0004D78C File Offset: 0x0004B98C
		private void DeleteProfile()
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				try
				{
					foreach (object obj in this.ListView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						bool flag2 = Interaction.MsgBox("Remove profile for '" + listViewItem.Text.Replace(" *", "") + "'?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Confirm") == MsgBoxResult.Yes;
						if (flag2)
						{
							OTTDB.RemoveProfile(this.TextBox1.Text);
							this.ListView1.Items.Clear();
							OTTDB.GetProfiles();
							bool flag3 = OTTDB.numWMI > 0;
							if (flag3)
							{
								MyProject.Forms.FrmMain.CreateWatcher();
							}
							bool flag4 = OTTDB.numTimer > 0;
							if (flag4)
							{
								MyProject.Forms.FrmMain.pTimer.Start();
							}
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
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
				bool flag5 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
				if (flag5)
				{
					GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
				}
				bool flag6 = Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0;
				if (flag6)
				{
					foreach (string text in Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary))
					{
						bool flag7 = Directory.Exists(text.TrimEnd(new char[] { '\\' }) + "\\Manifests");
						if (flag7)
						{
							GetGames.GetFiles(text.TrimEnd(new char[] { '\\' }) + "\\Manifests");
						}
						bool flag8 = Directory.Exists(text.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
						if (flag8)
						{
							GetGames.GetThirdPartyApps(text.TrimEnd(new char[] { '\\' }) + "\\CoreData\\Manifests");
						}
					}
				}
			}
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x0004DA28 File Offset: 0x0004BC28
		private void CheckVoiceConfirm_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckVoiceConfirm.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.VoiceConfirmProfile = true;
				}
				else
				{
					MySettingsProperty.Settings.VoiceConfirmProfile = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0004DA7C File Offset: 0x0004BC7C
		private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			bool flag = (this.ListView1.SelectedItems.Count > 0) | (this.ListView1.CheckedItems.Count <= 1);
			if (flag)
			{
				this.ToolStripMenuItem1.Enabled = true;
				this.ToolStripMenuItem2.Enabled = true;
				this.ToolStripMenuItem3.Enabled = false;
				this.ToolStripMenuItem4.Enabled = true;
				this.ToolStripMenuItem5.Enabled = true;
				this.ToolStripMenuItem6.Enabled = false;
				this.LaunchAppToolStripMenuItem.Enabled = true;
				this.LaunchAppWithOptionsToolStripMenuItem.Enabled = true;
				this.RemoveAllSelectedProfilesToolStripMenuItem.Enabled = false;
			}
			else
			{
				this.ToolStripMenuItem1.Enabled = false;
				this.ToolStripMenuItem2.Enabled = false;
				this.ToolStripMenuItem3.Enabled = true;
				this.ToolStripMenuItem4.Enabled = false;
				this.ToolStripMenuItem5.Enabled = false;
				this.LaunchAppToolStripMenuItem.Enabled = false;
				this.LaunchAppWithOptionsToolStripMenuItem.Enabled = false;
				this.RemoveAllSelectedProfilesToolStripMenuItem.Enabled = false;
			}
			bool flag2 = this.ListView1.CheckedItems.Count > 1;
			if (flag2)
			{
				this.ToolStripMenuItem1.Enabled = false;
				this.ToolStripMenuItem2.Enabled = false;
				this.ToolStripMenuItem3.Enabled = false;
				this.ToolStripMenuItem4.Enabled = false;
				this.ToolStripMenuItem5.Enabled = false;
				this.ToolStripMenuItem6.Enabled = true;
				this.LaunchAppToolStripMenuItem.Enabled = false;
				this.LaunchAppWithOptionsToolStripMenuItem.Enabled = false;
				this.RemoveAllSelectedProfilesToolStripMenuItem.Enabled = true;
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0004DC28 File Offset: 0x0004BE28
		private void ListView1_DoubleClick(object sender, EventArgs e)
		{
			this.selectedItem = this.ListView1.SelectedItems[0].Index;
			try
			{
				foreach (object obj in this.ListView1.CheckedItems)
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
			this.ShowEdit();
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0004DCB4 File Offset: 0x0004BEB4
		private void ToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			this.ShowCreate();
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0004DCC0 File Offset: 0x0004BEC0
		private void ShowEdit()
		{
			try
			{
				string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
				MyProject.Forms.frmCreateEditProfile.TextDisplayName.Text = array[0];
				MyProject.Forms.frmCreateEditProfile.ComboSS.Text = array[1];
				MyProject.Forms.frmCreateEditProfile.ComboASW.Text = array[2];
				MyProject.Forms.frmCreateEditProfile.ComboCPU.Text = array[4];
				MyProject.Forms.frmCreateEditProfile.ComboMethod.Text = array[3];
				MyProject.Forms.frmCreateEditProfile.pLaunchfile = Path.GetFileName(array[5]);
				MyProject.Forms.frmCreateEditProfile.pPath = array[5];
				MyProject.Forms.frmCreateEditProfile.TextBoxPath.Text = array[5];
				bool flag = !File.Exists(array[5]);
				if (flag)
				{
					MyProject.Forms.frmCreateEditProfile.TextBoxPath.BackColor = Color.LightCoral;
					this.ToolTip1.SetToolTip(MyProject.Forms.frmCreateEditProfile.TextBoxPath, "Path not found!");
				}
				else
				{
					MyProject.Forms.frmCreateEditProfile.TextBoxPath.BackColor = Color.White;
					this.ToolTip1.SetToolTip(MyProject.Forms.frmCreateEditProfile.TextBoxPath, "");
				}
				MyProject.Forms.frmCreateEditProfile.NumericUpDown1.Value = new decimal(Conversions.ToInteger(array[6]));
				MyProject.Forms.frmCreateEditProfile.NumericUpDown2.Value = new decimal(Conversions.ToInteger(array[7]));
				MyProject.Forms.frmCreateEditProfile.ComboMirror.Text = array[8];
				MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = array[9];
				MyProject.Forms.frmCreateEditProfile.TextBoxComment.Text = array[10];
				string[] array2 = Strings.Split(array[11], " ", -1, CompareMethod.Binary);
				MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = new decimal(Conversions.ToDouble(array2[0]));
				MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = new decimal(Conversions.ToDouble(array2[1]));
				MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = array[12];
				MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = array[13];
				MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = array[14];
				MyProject.Forms.frmCreateEditProfile.TextDisplayName.Visible = true;
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Visible = false;
				MyProject.Forms.frmCreateEditProfile.TopMost = true;
				MyProject.Forms.frmCreateEditProfile.isEdit = true;
				MyProject.Forms.frmCreateEditProfile.Button1.Enabled = true;
				MyProject.Forms.frmCreateEditProfile.ShowDialog();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ShowEdit: " + ex.Message);
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0004E020 File Offset: 0x0004C220
		private void ShowCreate()
		{
			try
			{
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
				MyProject.Forms.frmCreateEditProfile.TextDisplayName.Visible = false;
				MyProject.Forms.frmCreateEditProfile.ComboBox1.Visible = true;
				MyProject.Forms.frmCreateEditProfile.ComboBox1.DisplayMember = "Name";
				MyProject.Forms.frmCreateEditProfile.ComboBox1.ValueMember = "Info";
				MyProject.Forms.frmCreateEditProfile.ComboSS.Text = MyProject.Forms.FrmMain.ComboSSstart.Text;
				MyProject.Forms.frmCreateEditProfile.ComboASW.Text = MyProject.Forms.FrmMain.ComboBox1.Text;
				MyProject.Forms.frmCreateEditProfile.ComboCPU.SelectedIndex = 0;
				MyProject.Forms.frmCreateEditProfile.ComboMethod.SelectedIndex = 0;
				MyProject.Forms.frmCreateEditProfile.NumericUpDown1.Value = 5m;
				MyProject.Forms.frmCreateEditProfile.NumericUpDown2.Value = 5m;
				MyProject.Forms.frmCreateEditProfile.ComboMirror.SelectedIndex = 0;
				MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = MyProject.Forms.FrmMain.ComboBox5.Text;
				MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = MyProject.Forms.FrmMain.NumericFOVh.Value;
				MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = MyProject.Forms.FrmMain.NumericFOVv.Value;
				MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = MyProject.Forms.FrmMain.ComboBox8.Text;
				MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = MyProject.Forms.FrmMain.ComboBox9.Text;
				MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = "Yes";
				try
				{
					foreach (KeyValuePair<string, string> keyValuePair in this.GameList)
					{
						MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add(new frmCreateEditProfile.GameItem(keyValuePair.Key, keyValuePair.Value));
					}
				}
				finally
				{
					Dictionary<string, string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				bool flag = MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Count > 0;
				if (flag)
				{
					MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add("- All Games & Apps -");
				}
				MyProject.Forms.frmCreateEditProfile.ShowDialog();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ShowCreate: " + ex.Message);
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0004E36C File Offset: 0x0004C56C
		private void ToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			this.selectedItem = this.ListView1.SelectedItems[0].Index;
			this.ShowEdit();
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0004E392 File Offset: 0x0004C592
		private void ToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			this.DeleteProfile();
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0004E39C File Offset: 0x0004C59C
		private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
		{
			this.ContextMenuStrip1.Close();
			this.ListView1.Focus();
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0004E3B8 File Offset: 0x0004C5B8
		private void ListView1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = this.ListView1.CheckedItems.Count != 0;
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
				}
			}
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0004E478 File Offset: 0x0004C678
		private void LaunchAppToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LaunchApp();
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0004E484 File Offset: 0x0004C684
		private void LaunchApp()
		{
			checked
			{
				try
				{
					string text = "";
					string text2 = "";
					string text3 = "";
					bool flag = GetGames.manifesDictionary.TryGetValue(this.ListView1.SelectedItems[0].Text, out text);
					if (flag)
					{
						bool flag2 = File.Exists(text);
						if (flag2)
						{
							List<string> list = new List<string>();
							list = this.GetAppInfo(text, "");
							int num = list.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								text2 = list[0];
								text3 = list[1];
							}
							bool flag3 = (Operators.CompareString(text2, "", false) != 0) & File.Exists(text2);
							if (flag3)
							{
								MyProject.Forms.FrmMain.ManualStart = true;
								bool flag4 = !MyProject.Forms.FrmMain.HomeIsRunning;
								if (flag4)
								{
									RunCommand.StartHome();
								}
								Thread.Sleep(3000);
								bool flag5 = MyProject.Forms.frmLibrary.ManualStartProfiles.ContainsKey(text2.ToLower());
								if (flag5)
								{
									Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text2));
									this.ApplyProfile(text2.TrimStart(new char[0]).TrimEnd(new char[0]));
								}
								else
								{
									Log.WriteToLog("No profile found for '" + text2 + "'");
									FrmMain.fmain.AddToListboxAndScroll("No profile found for '" + text2 + "'");
								}
								bool flag6 = Operators.CompareString(text3, "", false) != 0;
								if (flag6)
								{
									Log.WriteToLog(string.Concat(new string[]
									{
										"Launching ",
										this.ListView1.SelectedItems[0].Text,
										" (",
										text2.TrimStart(new char[0]).TrimEnd(new char[0]),
										text3.TrimStart(new char[0]).TrimEnd(new char[0]),
										")"
									}));
								}
								else
								{
									Log.WriteToLog(string.Concat(new string[]
									{
										"Launching ",
										this.ListView1.SelectedItems[0].Text,
										" (",
										text2.TrimStart(new char[0]).TrimEnd(new char[0]),
										")"
									}));
								}
								Process.Start(text2, text3);
							}
						}
					}
					else
					{
						text2 = this.TextBox1.Text;
						bool flag7 = File.Exists(text2);
						if (flag7)
						{
							MyProject.Forms.FrmMain.ManualStart = true;
							bool flag8 = !MyProject.Forms.FrmMain.HomeIsRunning;
							if (flag8)
							{
								RunCommand.StartHome();
							}
							Thread.Sleep(3000);
							Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text2));
							this.ApplyProfile(text2.TrimStart(new char[0]).TrimEnd(new char[0]));
							Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
							Log.WriteToLog(" -> " + text2.TrimStart(new char[0]).TrimEnd(new char[0]));
							Process.Start(text2, text3);
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("LaunchApp(): " + ex.Message);
					Interaction.MsgBox("Could not launch app: " + ex.Message, MsgBoxStyle.OkOnly, null);
				}
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Adding backgroundworker AppWatchWorker");
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

		// Token: 0x06000894 RID: 2196 RVA: 0x0004E898 File Offset: 0x0004CA98
		private void ApplyProfile(string appName)
		{
			string ss = "";
			bool flag = MyProject.Forms.frmLibrary.ManualStartProfiles.TryGetValue(appName.ToLower(), out ss);
			checked
			{
				if (flag)
				{
					Thread thread = new Thread(delegate
					{
						RunCommand.Run_debug_tool(ss);
					});
					thread.Start();
					string text = "";
					bool flag2 = MyProject.Forms.FrmMain.profileAGPS.TryGetValue(appName.ToLower(), out text);
					if (flag2)
					{
						bool flag3 = Operators.CompareString(text, "0", false) == 0;
						if (flag3)
						{
							Thread thread2 = new Thread((frmProfiles._Closure$__.$I264-1 == null) ? (frmProfiles._Closure$__.$I264-1 = delegate
							{
								RunCommand.Run_debug_tool_agps("false");
							}) : frmProfiles._Closure$__.$I264-1);
							thread2.Start();
						}
						else
						{
							Thread thread3 = new Thread((frmProfiles._Closure$__.$I264-2 == null) ? (frmProfiles._Closure$__.$I264-2 = delegate
							{
								RunCommand.Run_debug_tool_agps("true");
							}) : frmProfiles._Closure$__.$I264-2);
							thread3.Start();
						}
					}
					bool voiceConfirmProfile = MySettingsProperty.Settings.VoiceConfirmProfile;
					if (voiceConfirmProfile)
					{
						Thread thread4 = new Thread((frmProfiles._Closure$__.$I264-3 == null) ? (frmProfiles._Closure$__.$I264-3 = delegate
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
						}) : frmProfiles._Closure$__.$I264-3);
						thread4.Start();
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
					FrmMain.fmain.AddToListboxAndScroll(displayName + ": Super Sampling @ " + ss);
					string text2 = "";
					bool flag4 = MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text2);
					if (flag4)
					{
						global::System.Timers.Timer timer = new global::System.Timers.Timer();
						timer.AutoReset = false;
						timer.Interval = (double)(Conversions.ToInteger(text2) * 1000);
						timer.Elapsed += MyProject.Forms.FrmMain.ApplyAswTick;
						timer.Start();
						Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + text2 + " seconds");
						FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + text2 + " seconds");
					}
					string text3 = "";
					bool flag5 = MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text3);
					if (flag5)
					{
						global::System.Timers.Timer timer2 = new global::System.Timers.Timer();
						timer2.AutoReset = false;
						timer2.Interval = (double)(Conversions.ToInteger(text3) * 1000);
						timer2.Elapsed += MyProject.Forms.FrmMain.ApplyCpuPrioTick;
						timer2.Start();
						Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + text3 + " seconds");
						FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + text3 + " seconds");
					}
				}
				else
				{
					Log.WriteToLog("No profile found for '" + appName + "'");
				}
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0004EC6C File Offset: 0x0004CE6C
		private List<string> GetAppInfo(string jFile, string customParms)
		{
			List<string> list = new List<string>();
			string text = File.ReadAllText(jFile);
			JObject jobject = (JObject)JToken.Parse(text);
			string text2 = (string)jobject.SelectToken("canonicalName");
			string text3 = ((string)jobject.SelectToken("launchFile")).Replace("\\\\", "\\").Replace("/", "\\");
			bool flag = Operators.CompareString(customParms, "", false) == 0;
			string text4;
			if (flag)
			{
				text4 = (string)jobject.SelectToken("launchParameters");
			}
			else
			{
				text4 = customParms;
			}
			string text5 = text3.Replace("\\\\", "\\").Replace("/", "\\");
			string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary);
			foreach (string text6 in array)
			{
				bool flag2 = File.Exists(string.Concat(new string[] { text6, "\\Software\\", text2, "\\", text3 }));
				if (flag2)
				{
					text5 = string.Concat(new string[] { text6, "\\Software\\", text2, "\\", text3 });
					break;
				}
			}
			list.Add(text5);
			list.Add(text4);
			return list;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0004EDEC File Offset: 0x0004CFEC
		private void LaunchAppWithOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			bool flag = GetGames.manifesDictionary.TryGetValue(this.ListView1.SelectedItems[0].Text, out text);
			checked
			{
				if (flag)
				{
					bool flag2 = File.Exists(text);
					if (flag2)
					{
						List<string> list = new List<string>();
						list = this.GetAppInfo(text, "");
						int num = list.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							text2 = list[0];
							text3 = list[1];
						}
						MyProject.Forms.frmLaunchOptions.TextBox1.Text = text3;
						MyProject.Forms.frmLaunchOptions.ShowDialog();
						bool optionsCanceled = MyProject.Forms.frmLaunchOptions.optionsCanceled;
						if (optionsCanceled)
						{
							return;
						}
						bool flag3 = Operators.CompareString(MyProject.Forms.frmLaunchOptions.TextBox1.Text, "", false) != 0;
						if (flag3)
						{
							text3 = text3 + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text;
						}
						bool flag4 = (Operators.CompareString(text2, "", false) != 0) & File.Exists(text2);
						if (flag4)
						{
							MyProject.Forms.FrmMain.ManualStart = true;
							bool flag5 = !MyProject.Forms.FrmMain.HomeIsRunning;
							if (flag5)
							{
								RunCommand.StartHome();
							}
							Thread.Sleep(3000);
							bool flag6 = MyProject.Forms.frmLibrary.ManualStartProfiles.ContainsKey(text2.ToLower());
							if (flag6)
							{
								Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text2));
								FrmMain.fmain.AddToListboxAndScroll("Applying profile for " + OTTDB.GetDisplayName(text2));
								this.ApplyProfile(text2.TrimStart(new char[0]).TrimEnd(new char[0]));
							}
							else
							{
								Log.WriteToLog("No profile found for '" + text2 + "'");
								FrmMain.fmain.AddToListboxAndScroll("No profile found for '" + text2 + "'");
							}
							FrmMain.fmain.AddToListboxAndScroll(string.Concat(new string[]
							{
								"Launching ",
								this.ListView1.SelectedItems[0].Text,
								" with params '",
								text3.TrimStart(new char[0]).TrimEnd(new char[0]),
								"'"
							}));
							bool flag7 = Operators.CompareString(text3, "", false) != 0;
							if (flag7)
							{
								Log.WriteToLog(string.Concat(new string[]
								{
									"Launching ",
									this.ListView1.SelectedItems[0].Text,
									" (",
									text2.TrimStart(new char[0]).TrimEnd(new char[0]),
									text3.TrimStart(new char[0]).TrimEnd(new char[0]),
									")"
								}));
							}
							else
							{
								Log.WriteToLog(string.Concat(new string[]
								{
									"Launching ",
									this.ListView1.SelectedItems[0].Text,
									" (",
									text2.TrimStart(new char[0]).TrimEnd(new char[0]),
									")"
								}));
							}
							Process.Start(text2, text3);
						}
					}
				}
				else
				{
					text2 = this.TextBox1.Text;
					bool flag8 = File.Exists(text2);
					if (flag8)
					{
						MyProject.Forms.FrmMain.ManualStart = true;
						bool flag9 = !MyProject.Forms.FrmMain.HomeIsRunning;
						if (flag9)
						{
							RunCommand.StartHome();
						}
						Thread.Sleep(3000);
						Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text2));
						this.ApplyProfile(text2.TrimStart(new char[0]).TrimEnd(new char[0]));
						Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
						Log.WriteToLog(" -> " + text2.TrimStart(new char[0]).TrimEnd(new char[0]));
						Process.Start(text2, text3);
					}
				}
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Adding backgroundworker AppWatchWorker");
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

		// Token: 0x06000897 RID: 2199 RVA: 0x0004DCB4 File Offset: 0x0004BEB4
		private void Button1_Click(object sender, EventArgs e)
		{
			this.ShowCreate();
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0004F2A8 File Offset: 0x0004D4A8
		private void ToolStripMenuItem6_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmEditAllSelected.NumericUpDown1.Text = "";
			MyProject.Forms.frmEditAllSelected.NumericUpDown2.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboSS.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboASW.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboCPU.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboMethod.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboMirror.Text = "";
			MyProject.Forms.frmEditAllSelected.ComboAGPS.Text = "";
			MyProject.Forms.frmEditAllSelected.TextBoxComment.Text = "";
			MyProject.Forms.frmEditAllSelected.ShowDialog();
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0004F3B0 File Offset: 0x0004D5B0
		private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			bool flag = e.ColumnIndex == 0;
			if (flag)
			{
				this.cck = new CheckBox
				{
					Text = "",
					Visible = true
				};
				e.DrawBackground();
				this.cck.BackColor = Color.Transparent;
				this.cck.UseVisualStyleBackColor = true;
				this.cck.SetBounds(e.Bounds.X, e.Bounds.Y, this.cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, this.cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);
				this.cck.Size = new Size(checked(this.cck.GetPreferredSize(new Size(e.Bounds.Width - 1, e.Bounds.Height)).Width + 1), e.Bounds.Height);
				this.cck.Location = new Point(4, 2);
				this.ListView1.Controls.Add(this.cck);
				this.cck.Show();
				this.cck.BringToFront();
				e.DrawText(TextFormatFlags.VerticalCenter);
				this.cck.CheckedChanged += this.theCheckboxInHeader_CheckChanged;
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0004F568 File Offset: 0x0004D768
		private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0004F573 File Offset: 0x0004D773
		private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0004F580 File Offset: 0x0004D780
		private void theCheckboxInHeader_CheckChanged(object sender, EventArgs e)
		{
			bool flag = this.ListView1.Items.Count > 0;
			if (flag)
			{
				bool @checked = this.cck.Checked;
				if (@checked)
				{
					try
					{
						foreach (object obj in this.ListView1.Items)
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
				else
				{
					bool flag2 = !this.cck.Checked;
					if (flag2)
					{
						try
						{
							foreach (object obj2 in this.ListView1.Items)
							{
								ListViewItem listViewItem2 = (ListViewItem)obj2;
								listViewItem2.Checked = false;
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
					}
				}
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0004F68C File Offset: 0x0004D88C
		private void ComboResolution_SelectedIndexChanged(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.DesktopResolution = Conversions.ToString(this.ComboResolution.SelectedItem);
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0004F6B5 File Offset: 0x0004D8B5
		private void ListView1_MouseHover(object sender, EventArgs e)
		{
			this.ListView1.Refresh();
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0004F6C4 File Offset: 0x0004D8C4
		private void ListView1_Click(object sender, EventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				string[] array = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",", -1, CompareMethod.Binary);
				this.Label16.Text = array[0];
				this.Label17.Text = array[1];
				this.Label18.Text = array[2];
				this.Label19.Text = array[3];
				this.Label20.Text = array[4];
				this.TextBox1.Text = array[5];
				this.Label22.Text = array[6] + " seconds";
				this.Label23.Text = array[7] + " seconds";
				this.Label24.Text = array[8];
				this.Label25.Text = array[9];
				this.Label26.Text = array[10];
				string[] array2 = Strings.Split(array[11], " ", -1, CompareMethod.Binary);
				this.Label27.Text = "Horizontal: " + array2[0] + " Vertical: " + array2[1];
				this.Label28.Text = array[12];
				this.Label30.Text = array[13];
				this.Label31.Text = array[14];
				this.Label16.Visible = true;
				this.Label17.Visible = true;
				this.Label18.Visible = true;
				this.Label19.Visible = true;
				this.Label20.Visible = true;
				this.TextBox1.Visible = true;
				this.Label22.Visible = true;
				this.Label23.Visible = true;
				this.Label24.Visible = true;
				this.Label25.Visible = true;
				this.Label26.Visible = true;
				this.Label27.Visible = true;
				this.Label28.Visible = true;
				this.Label30.Visible = true;
				this.Label31.Visible = true;
				this.Button3.Enabled = true;
			}
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0004F904 File Offset: 0x0004DB04
		private void Button3_Click(object sender, EventArgs e)
		{
			bool flag = this.ListView1.CheckedItems.Count == 1;
			if (flag)
			{
				this.ShowEdit();
			}
			else
			{
				bool flag2 = (this.ListView1.SelectedItems.Count == 1) & (this.ListView1.CheckedItems.Count < 2);
				if (flag2)
				{
					this.ShowEdit();
				}
				else
				{
					bool flag3 = this.ListView1.CheckedItems.Count > 1;
					if (flag3)
					{
						MyProject.Forms.frmEditAllSelected.NumericUpDown1.Text = "";
						MyProject.Forms.frmEditAllSelected.NumericUpDown2.Text = "";
						MyProject.Forms.frmEditAllSelected.ComboSS.Text = "";
						MyProject.Forms.frmEditAllSelected.ComboASW.Text = "";
						MyProject.Forms.frmEditAllSelected.ComboCPU.Text = "";
						MyProject.Forms.frmEditAllSelected.ComboMethod.Text = "";
						MyProject.Forms.frmEditAllSelected.ComboMirror.Text = "";
						MyProject.Forms.frmEditAllSelected.ComboAGPS.Text = "";
						MyProject.Forms.frmEditAllSelected.TextBoxComment.Text = "";
						MyProject.Forms.frmEditAllSelected.ShowDialog();
					}
				}
			}
		}

		// Token: 0x040003A5 RID: 933
		private Resizer rs;

		// Token: 0x040003A6 RID: 934
		private int sortColumn;

		// Token: 0x040003A7 RID: 935
		private string ProfileToFind;

		// Token: 0x040003A8 RID: 936
		public int selectedItem;

		// Token: 0x040003A9 RID: 937
		public Dictionary<string, string> GameList;

		// Token: 0x040003AA RID: 938
		private CheckBox cck;
	}
}
