using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.My.Resources;

namespace OculusTrayTool
{
	// Token: 0x02000060 RID: 96
	[DesignerGenerated]
	public partial class frmVoiceSettings : Form
	{
		// Token: 0x0600093B RID: 2363 RVA: 0x00056334 File Offset: 0x00054534
		public frmVoiceSettings()
		{
			base.FormClosing += this.voiceSettings_FormClosing;
			base.Load += this.voiceSettings_Load;
			base.KeyDown += this.frmVoiceSettings_KeyDown;
			this.VoicechangeMade = false;
			this.isEditing = false;
			this.InitializeComponent();
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x00057DBF File Offset: 0x00055FBF
		// (set) Token: 0x0600093F RID: 2367 RVA: 0x00057DC9 File Offset: 0x00055FC9
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00057DD2 File Offset: 0x00055FD2
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x00057DDC File Offset: 0x00055FDC
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

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x00057E1F File Offset: 0x0005601F
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00057E29 File Offset: 0x00056029
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00057E32 File Offset: 0x00056032
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00057E3C File Offset: 0x0005603C
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x00057E45 File Offset: 0x00056045
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x00057E50 File Offset: 0x00056050
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

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x00057E93 File Offset: 0x00056093
		// (set) Token: 0x06000949 RID: 2377 RVA: 0x00057E9D File Offset: 0x0005609D
		internal virtual Label LabelConfidencePercent
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x00057EA6 File Offset: 0x000560A6
		// (set) Token: 0x0600094B RID: 2379 RVA: 0x00057EB0 File Offset: 0x000560B0
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x00057EB9 File Offset: 0x000560B9
		// (set) Token: 0x0600094D RID: 2381 RVA: 0x00057EC4 File Offset: 0x000560C4
		internal virtual TrackBar TrackBar1
		{
			[CompilerGenerated]
			get
			{
				return this._TrackBar1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.TrackBar1_Scroll);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.TrackBar1_MouseUp);
				TrackBar trackBar = this._TrackBar1;
				if (trackBar != null)
				{
					trackBar.Scroll -= eventHandler;
					trackBar.MouseUp -= mouseEventHandler;
				}
				this._TrackBar1 = value;
				trackBar = this._TrackBar1;
				if (trackBar != null)
				{
					trackBar.Scroll += eventHandler;
					trackBar.MouseUp += mouseEventHandler;
				}
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x00057F22 File Offset: 0x00056122
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x00057F2C File Offset: 0x0005612C
		internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x00057F35 File Offset: 0x00056135
		// (set) Token: 0x06000951 RID: 2385 RVA: 0x00057F3F File Offset: 0x0005613F
		internal virtual TabPage TabPage1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00057F48 File Offset: 0x00056148
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x00057F54 File Offset: 0x00056154
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
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.ListView1_MouseClick);
				ListView listView = this._ListView1;
				if (listView != null)
				{
					listView.MouseClick -= mouseEventHandler;
				}
				this._ListView1 = value;
				listView = this._ListView1;
				if (listView != null)
				{
					listView.MouseClick += mouseEventHandler;
				}
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x00057F97 File Offset: 0x00056197
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00057FA1 File Offset: 0x000561A1
		internal virtual ColumnHeader ColumnHeader1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x00057FAA File Offset: 0x000561AA
		// (set) Token: 0x06000957 RID: 2391 RVA: 0x00057FB4 File Offset: 0x000561B4
		internal virtual ColumnHeader ColumnHeader2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x00057FBD File Offset: 0x000561BD
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x00057FC7 File Offset: 0x000561C7
		internal virtual ColumnHeader ColumnHeader3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x00057FD0 File Offset: 0x000561D0
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x00057FDA File Offset: 0x000561DA
		internal virtual TabPage TabPage2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x00057FE3 File Offset: 0x000561E3
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x00057FED File Offset: 0x000561ED
		internal virtual ListView ListView2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x00057FF6 File Offset: 0x000561F6
		// (set) Token: 0x0600095F RID: 2399 RVA: 0x00058000 File Offset: 0x00056200
		internal virtual ColumnHeader ColumnHeader4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00058009 File Offset: 0x00056209
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x00058013 File Offset: 0x00056213
		internal virtual ColumnHeader ColumnHeader5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x0005801C File Offset: 0x0005621C
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x00058026 File Offset: 0x00056226
		internal virtual TabPage TabPage3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0005802F File Offset: 0x0005622F
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x00058039 File Offset: 0x00056239
		internal virtual Label LabelExplain
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00058042 File Offset: 0x00056242
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x0005804C File Offset: 0x0005624C
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
				EventHandler eventHandler2 = new EventHandler(this.CheckBox1_MouseHover);
				CheckBox checkBox = this._CheckBox1;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
					checkBox.MouseHover -= eventHandler2;
				}
				this._CheckBox1 = value;
				checkBox = this._CheckBox1;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
					checkBox.MouseHover += eventHandler2;
				}
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x000580AA File Offset: 0x000562AA
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x000580B4 File Offset: 0x000562B4
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x000580BD File Offset: 0x000562BD
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x000580C8 File Offset: 0x000562C8
		internal virtual CheckBox CheckBox2
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox2_CheckedChanged);
				EventHandler eventHandler2 = new EventHandler(this.CheckBox2_MouseHover);
				CheckBox checkBox = this._CheckBox2;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
					checkBox.MouseHover -= eventHandler2;
				}
				this._CheckBox2 = value;
				checkBox = this._CheckBox2;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
					checkBox.MouseHover += eventHandler2;
				}
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x00058126 File Offset: 0x00056326
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x00058130 File Offset: 0x00056330
		internal virtual CheckBox CheckBox4
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox4_CheckedChanged);
				EventHandler eventHandler2 = new EventHandler(this.CheckBox4_MouseHover);
				CheckBox checkBox = this._CheckBox4;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
					checkBox.MouseHover -= eventHandler2;
				}
				this._CheckBox4 = value;
				checkBox = this._CheckBox4;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
					checkBox.MouseHover += eventHandler2;
				}
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0005818E File Offset: 0x0005638E
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x00058198 File Offset: 0x00056398
		internal virtual CheckBox CheckBox3
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox3;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox3_CheckedChanged);
				EventHandler eventHandler2 = new EventHandler(this.CheckBox3_MouseHover);
				CheckBox checkBox = this._CheckBox3;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
					checkBox.MouseHover -= eventHandler2;
				}
				this._CheckBox3 = value;
				checkBox = this._CheckBox3;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
					checkBox.MouseHover += eventHandler2;
				}
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x000581F6 File Offset: 0x000563F6
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x00058200 File Offset: 0x00056400
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x00058209 File Offset: 0x00056409
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x00058214 File Offset: 0x00056414
		internal virtual ComboBox ComboDevice
		{
			[CompilerGenerated]
			get
			{
				return this._ComboDevice;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboDevice_SelectedIndexChanged);
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.ComboDevice_KeyPress);
				ComboBox comboBox = this._ComboDevice;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
					comboBox.KeyPress -= keyPressEventHandler;
				}
				this._ComboDevice = value;
				comboBox = this._ComboDevice;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
					comboBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00058272 File Offset: 0x00056472
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x0005827C File Offset: 0x0005647C
		internal virtual Button ButtonListen
		{
			[CompilerGenerated]
			get
			{
				return this._ButtonListen;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ButtonListen_Click);
				Button button = this._ButtonListen;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._ButtonListen = value;
				button = this._ButtonListen;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x000582BF File Offset: 0x000564BF
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x000582C9 File Offset: 0x000564C9
		internal virtual ImageList ImageList1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x000582D2 File Offset: 0x000564D2
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x000582DC File Offset: 0x000564DC
		internal virtual Label LabelKey
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x000582E5 File Offset: 0x000564E5
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x000582EF File Offset: 0x000564EF
		internal virtual GroupBox GroupBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x000582F8 File Offset: 0x000564F8
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00058304 File Offset: 0x00056504
		internal virtual CheckBox CheckBox5
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox5;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox5_CheckedChanged);
				EventHandler eventHandler2 = new EventHandler(this.CheckBox5_MouseHover);
				CheckBox checkBox = this._CheckBox5;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
					checkBox.MouseHover -= eventHandler2;
				}
				this._CheckBox5 = value;
				checkBox = this._CheckBox5;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
					checkBox.MouseHover += eventHandler2;
				}
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00058362 File Offset: 0x00056562
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x0005836C File Offset: 0x0005656C
		internal virtual CheckBox CheckBox6
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox6;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox6_CheckedChanged);
				EventHandler eventHandler2 = new EventHandler(this.CheckBox6_MouseHover);
				CheckBox checkBox = this._CheckBox6;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
					checkBox.MouseHover -= eventHandler2;
				}
				this._CheckBox6 = value;
				checkBox = this._CheckBox6;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
					checkBox.MouseHover += eventHandler2;
				}
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x000583CA File Offset: 0x000565CA
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x000583D4 File Offset: 0x000565D4
		internal virtual CheckBox CheckBox7
		{
			[CompilerGenerated]
			get
			{
				return this._CheckBox7;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CheckBox7_CheckedChanged);
				CheckBox checkBox = this._CheckBox7;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._CheckBox7 = value;
				checkBox = this._CheckBox7;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00058417 File Offset: 0x00056617
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00058424 File Offset: 0x00056624
		internal virtual ComboBox ComboBox1
		{
			[CompilerGenerated]
			get
			{
				return this._ComboBox1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
				EventHandler eventHandler2 = new EventHandler(this.ComboBox1_TextChanged);
				ComboBox comboBox = this._ComboBox1;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
					comboBox.TextChanged -= eventHandler2;
				}
				this._ComboBox1 = value;
				comboBox = this._ComboBox1;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
					comboBox.TextChanged += eventHandler2;
				}
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x00058482 File Offset: 0x00056682
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x0005848C File Offset: 0x0005668C
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00058495 File Offset: 0x00056695
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x000584A0 File Offset: 0x000566A0
		internal virtual Button Button4
		{
			[CompilerGenerated]
			get
			{
				return this._Button4;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button4_Click);
				Button button = this._Button4;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button4 = value;
				button = this._Button4;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x000584E3 File Offset: 0x000566E3
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x000584F0 File Offset: 0x000566F0
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

		// Token: 0x0600098A RID: 2442 RVA: 0x00058534 File Offset: 0x00056734
		private void Button1_Click(object sender, EventArgs e)
		{
			bool voicechangeMade = this.VoicechangeMade;
			if (voicechangeMade)
			{
				this.VoicechangeMade = false;
				MyProject.Forms.FrmMain.AddToListboxAndScroll("Restarting voice recognition");
				VoiceCommands.StopListening();
				VoiceCommands.DisableVoice();
				VoiceCommands.StartStopBuilder();
			}
			base.Close();
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00058583 File Offset: 0x00056783
		private void voiceSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			MySettingsProperty.Settings.VoiceDialogSize = base.Size;
			MySettings.Default.VoiceWindowLocation = base.Location;
			MySettingsProperty.Settings.Save();
			MySettings.Default.Save();
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x000585C0 File Offset: 0x000567C0
		private void voiceSettings_Load(object sender, EventArgs e)
		{
			bool flag = this.DotNetBarTabcontrol1.TabPages.Count > 2;
			if (flag)
			{
				this.DotNetBarTabcontrol1.TabPages.Remove(this.DotNetBarTabcontrol1.TabPages[2]);
			}
			bool flag2 = MySettings.Default.VoiceWindowLocation != default(Point);
			if (flag2)
			{
				base.Location = MySettings.Default.VoiceWindowLocation;
			}
			else
			{
				base.StartPosition = FormStartPosition.CenterParent;
			}
			bool flag3 = !GetControllers.ControllersFound;
			if (flag3)
			{
				GetControllers.GetAllControllers();
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00058658 File Offset: 0x00056858
		private void Button3_Click(object sender, EventArgs e)
		{
			MySettingsProperty.Settings.StartVoice = "computer, start listening;speech on";
			MySettingsProperty.Settings.StartVoiceEnabled = true;
			MySettingsProperty.Settings.StopVoice = "computer, stop listening;speech off";
			MySettingsProperty.Settings.StopVoiceEnabled = true;
			MySettingsProperty.Settings.EnableASW = "enable spacewarp";
			MySettingsProperty.Settings.EnableASWEnabled = true;
			MySettingsProperty.Settings.DisableASW = "disable spacewarp";
			MySettingsProperty.Settings.DisableASWEnabled = true;
			MySettingsProperty.Settings.ShowPD = "show pixel density; show super sampling";
			MySettingsProperty.Settings.ShowPDEnabled = true;
			MySettingsProperty.Settings.ShowPerf = "show performance";
			MySettingsProperty.Settings.ShowPerfEnabled = true;
			MySettingsProperty.Settings.Close = "close overlay";
			MySettingsProperty.Settings.CloseEnabled = true;
			MySettingsProperty.Settings.SetPD = "set pixel density;set super sampling";
			MySettingsProperty.Settings.SetPDEnabled = true;
			MySettingsProperty.Settings.ShowASW = "show spacewarp";
			MySettingsProperty.Settings.ShowASWEnabled = true;
			MySettingsProperty.Settings.LockASWOn = "lock framerate";
			MySettingsProperty.Settings.LockASWOnEnabled = true;
			MySettingsProperty.Settings.ShowLatency = "show latency timing";
			MySettingsProperty.Settings.ShowLatencyEnabled = true;
			MySettingsProperty.Settings.ShowApplicationRender = "show application timing";
			MySettingsProperty.Settings.ShowApplicationRenderEnabled = true;
			MySettingsProperty.Settings.ShowCompositorRender = "show compositor timing";
			MySettingsProperty.Settings.ShowCompositorRenderEnabled = true;
			MySettingsProperty.Settings.ShowVersion = "show version";
			MySettingsProperty.Settings.ShowVersionEnabled = true;
			MySettingsProperty.Settings.LaunchSteam = "start steam;launch steam";
			MySettingsProperty.Settings.LaunchSteamEnabled = true;
			MySettingsProperty.Settings.Save();
			MyProject.Forms.FrmMain.LoadVoiceSettings();
			this.VoicechangeMade = true;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0005882C File Offset: 0x00056A2C
		private void TrackBar1_Scroll(object sender, EventArgs e)
		{
			this.LabelConfidencePercent.Text = Conversions.ToString(this.TrackBar1.Value) + "%";
			this.LabelConfidencePercent.Refresh();
			this.VoicechangeMade = true;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00058868 File Offset: 0x00056A68
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox1.Checked;
				if (@checked)
				{
					this.CheckBox2.Checked = false;
					this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the prhase set for 'Disable Voice Control' is spoken.";
					MySettingsProperty.Settings.VoiceActivationVoiceContinous = true;
				}
				else
				{
					MySettingsProperty.Settings.VoiceActivationVoiceContinous = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000588DC File Offset: 0x00056ADC
		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox2.Checked;
				if (@checked)
				{
					this.CheckBox1.Checked = false;
					this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the prhase set for 'Enable Voice Control' must once again be spoken to activate commands.";
					MySettingsProperty.Settings.VoiceActivationVoiceRepeated = true;
				}
				else
				{
					MySettingsProperty.Settings.VoiceActivationVoiceRepeated = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00058950 File Offset: 0x00056B50
		private void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox3.Checked;
				if (@checked)
				{
					this.ComboDevice.Enabled = true;
					this.CheckBox4.Checked = false;
					this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again";
					MySettingsProperty.Settings.VoiceActivationKeyContinous = true;
				}
				else
				{
					MySettingsProperty.Settings.VoiceActivationKeyContinous = false;
					bool flag2 = !this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked;
					if (flag2)
					{
						this.ComboDevice.Enabled = false;
						this.ButtonListen.Enabled = false;
					}
				}
				MySettingsProperty.Settings.Save();
				this.AddItemsToDeviceList();
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00058A44 File Offset: 0x00056C44
		private void CheckBox4_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox4.Checked;
				if (@checked)
				{
					this.ComboDevice.Enabled = true;
					this.CheckBox3.Checked = false;
					this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
					MySettingsProperty.Settings.VoiceActivationKeyPush = true;
				}
				else
				{
					MySettingsProperty.Settings.VoiceActivationKeyPush = false;
					bool flag2 = !this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked;
					if (flag2)
					{
						this.ComboDevice.Enabled = false;
						this.ButtonListen.Enabled = false;
					}
				}
				MySettingsProperty.Settings.Save();
				this.AddItemsToDeviceList();
			}
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00058B38 File Offset: 0x00056D38
		private void ButtonListen_Click(object sender, EventArgs e)
		{
			this.ButtonListen.Image = this.ImageList1.Images[0];
			this.ButtonListen.Refresh();
			bool flag = (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) != 0) & (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "", false) != 0);
			if (flag)
			{
				frmVoiceSettings.UpdateButtonLabel("Push button");
				GetControllers.CaptureSelectedButton();
			}
			bool flag2 = (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) == 0) & (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "", false) != 0);
			if (flag2)
			{
				this.LabelKey.Text = "Press key";
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00058C18 File Offset: 0x00056E18
		private void ComboDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetControllers.selectedDevice = this.ComboDevice.SelectedItem.ToString();
			bool flag = Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) != 0;
			if (flag)
			{
				GetControllers.SelectController();
				bool flag2 = Operators.CompareString(MySettingsProperty.Settings.JoystickDeviceName, this.ComboDevice.SelectedItem.ToString(), false) == 0;
				if (flag2)
				{
					this.LabelKey.Text = MySettingsProperty.Settings.JoystickVoiceActivationButton.Replace("Buttons", "");
				}
			}
			else
			{
				this.LabelKey.Text = MySettingsProperty.Settings.KeyboardVoiceActivationKey;
			}
			this.ButtonListen.Enabled = true;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00058CDC File Offset: 0x00056EDC
		private void TrackBar1_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				MySettingsProperty.Settings.Confidence = this.TrackBar1.Value;
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00058D1C File Offset: 0x00056F1C
		public static void UpdateButtonLabel(string text)
		{
			bool invokeRequired = MyProject.Forms.frmVoiceSettings.InvokeRequired;
			if (invokeRequired)
			{
				frmVoiceSettings.UpdateLabelDelegate updateLabelDelegate = new frmVoiceSettings.UpdateLabelDelegate(frmVoiceSettings.UpdateButtonLabel);
				MyProject.Forms.frmVoiceSettings.Invoke(updateLabelDelegate, new object[] { text });
			}
			else
			{
				MyProject.Forms.frmVoiceSettings.LabelKey.Text = text;
				MyProject.Forms.frmVoiceSettings.LabelKey.Refresh();
			}
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00058D98 File Offset: 0x00056F98
		public static void UpdateListeningButton(int index)
		{
			bool invokeRequired = MyProject.Forms.frmVoiceSettings.InvokeRequired;
			if (invokeRequired)
			{
				frmVoiceSettings.UpdateListeningButtonDelegate updateListeningButtonDelegate = new frmVoiceSettings.UpdateListeningButtonDelegate(frmVoiceSettings.UpdateListeningButton);
				MyProject.Forms.frmVoiceSettings.Invoke(updateListeningButtonDelegate, new object[] { index });
			}
			else
			{
				MyProject.Forms.frmVoiceSettings.ButtonListen.Image = MyProject.Forms.frmVoiceSettings.ImageList1.Images[index];
				MyProject.Forms.frmVoiceSettings.ButtonListen.Refresh();
			}
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00058E30 File Offset: 0x00057030
		private void CheckBox5_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox5.Checked;
				if (@checked)
				{
					this.ComboDevice.Enabled = true;
					this.CheckBox6.Checked = false;
					this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again";
					MySettingsProperty.Settings.JoystickActivationKeyContinous = true;
				}
				else
				{
					MySettingsProperty.Settings.JoystickActivationKeyContinous = false;
					bool flag2 = !this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked;
					if (flag2)
					{
						this.ComboDevice.Enabled = false;
						this.ButtonListen.Enabled = false;
					}
				}
				MySettingsProperty.Settings.Save();
				this.AddItemsToDeviceList();
			}
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00058F24 File Offset: 0x00057124
		private void CheckBox6_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox6.Checked;
				if (@checked)
				{
					this.ComboDevice.Enabled = true;
					this.CheckBox5.Checked = false;
					this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
					MySettingsProperty.Settings.JoystickActivationKeyPush = true;
				}
				else
				{
					MySettingsProperty.Settings.JoystickActivationKeyPush = false;
					bool flag2 = !this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked;
					if (flag2)
					{
						this.ComboDevice.Enabled = false;
						this.ButtonListen.Enabled = false;
					}
				}
				MySettingsProperty.Settings.Save();
				this.AddItemsToDeviceList();
			}
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00059018 File Offset: 0x00057218
		private void frmVoiceSettings_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = Operators.CompareString(this.LabelKey.Text, "Press key", false) == 0;
			if (flag)
			{
				frmVoiceSettings.UpdateButtonLabel(e.KeyCode.ToString().ToUpper());
				this.ButtonListen.Image = this.ImageList1.Images[1];
				this.ButtonListen.Refresh();
				MySettingsProperty.Settings.KeyboardVoiceActivationKey = e.KeyCode.ToString().ToUpper();
				MySettingsProperty.Settings.Save();
				Log.WriteToLog("Registered '" + e.KeyCode.ToString().ToUpper() + "' as key for activating voice commands");
			}
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x000590ED File Offset: 0x000572ED
		private void CheckBox1_MouseHover(object sender, EventArgs e)
		{
			this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the phrase set for 'Disable Voice Control' is spoken.";
			this.LabelExplain.Refresh();
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0005910D File Offset: 0x0005730D
		private void CheckBox2_MouseHover(object sender, EventArgs e)
		{
			this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the phrase set for 'Enable Voice Control' must once again be spoken.";
			this.LabelExplain.Refresh();
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0005912D File Offset: 0x0005732D
		private void CheckBox3_MouseHover(object sender, EventArgs e)
		{
			this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again.";
			this.LabelExplain.Refresh();
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0005914D File Offset: 0x0005734D
		private void CheckBox4_MouseHover(object sender, EventArgs e)
		{
			this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
			this.LabelExplain.Refresh();
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0005916D File Offset: 0x0005736D
		private void CheckBox5_MouseHover(object sender, EventArgs e)
		{
			this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again.";
			this.LabelExplain.Refresh();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0005918D File Offset: 0x0005738D
		private void CheckBox6_MouseHover(object sender, EventArgs e)
		{
			this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
			this.LabelExplain.Refresh();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000591B0 File Offset: 0x000573B0
		public void AddItemsToDeviceList()
		{
			this.ComboDevice.Text = "";
			this.ComboDevice.Items.Clear();
			this.LabelKey.Text = "";
			bool flag = this.CheckBox3.Checked | this.CheckBox4.Checked;
			if (flag)
			{
				this.ComboDevice.Items.Add("Keyboard");
			}
			bool flag2 = this.CheckBox5.Checked | this.CheckBox6.Checked;
			if (flag2)
			{
				try
				{
					foreach (KeyValuePair<string, Guid> keyValuePair in GetControllers.joysticks)
					{
						this.ComboDevice.Items.Add(keyValuePair.Key);
					}
				}
				finally
				{
					Dictionary<string, Guid>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00013C04 File Offset: 0x00011E04
		private void ComboDevice_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x000592A0 File Offset: 0x000574A0
		private void ListView1_MouseClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo listViewHitTestInfo = this.ListView1.HitTest(e.X, e.Y);
			bool flag = listViewHitTestInfo.Item != null;
			if (flag)
			{
				MyProject.Forms.frmEditVoiceCommand.LabelAction.Text = listViewHitTestInfo.Item.Text;
				MyProject.Forms.frmEditVoiceCommand.TextBoxPhrase.Text = listViewHitTestInfo.Item.SubItems[1].Text + ";";
				bool flag2 = Operators.CompareString(listViewHitTestInfo.Item.SubItems[2].Text, "True", false) == 0;
				if (flag2)
				{
					MyProject.Forms.frmEditVoiceCommand.ComboEnabled.SelectedIndex = 0;
				}
				else
				{
					MyProject.Forms.frmEditVoiceCommand.ComboEnabled.SelectedIndex = 1;
				}
				MyProject.Forms.frmEditVoiceCommand.ShowDialog();
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00059398 File Offset: 0x00057598
		private void CheckBox7_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !GetConfig.IsReading;
			if (flag)
			{
				bool @checked = this.CheckBox7.Checked;
				if (@checked)
				{
					MySettingsProperty.Settings.DisableVoiceControlAudioFeedback = true;
				}
				else
				{
					MySettingsProperty.Settings.DisableVoiceControlAudioFeedback = false;
				}
				MySettingsProperty.Settings.Save();
			}
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x000593EB File Offset: 0x000575EB
		private void Button2_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmAddCustomVoice.ShowDialog();
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00059400 File Offset: 0x00057600
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = Operators.ConditionalCompareObjectNotEqual(this.ComboBox1.SelectedItem, null, false);
			if (flag)
			{
				this.Button2.Enabled = true;
				List<string> list = new List<string>();
				list = (List<string>)OTTDB.GetVoiceProfileCommands(this.ComboBox1.SelectedItem.ToString());
				try
				{
					foreach (string text in list)
					{
						string[] array = Strings.Split(text, "|", -1, CompareMethod.Binary);
						ListViewItem listViewItem = new ListViewItem();
						listViewItem = this.ListView2.Items.Add(array[0]);
						string[] array2 = Strings.Split(array[1], ",", -1, CompareMethod.Binary);
						foreach (string text2 in array2)
						{
							string[] array4 = Strings.Split(text2, ":", -1, CompareMethod.Binary);
							bool flag2 = Operators.CompareString(array4[0], "wait", false) != 0;
							if (flag2)
							{
								listViewItem.SubItems.Add(array4[0] + " '" + array4[1] + "'");
							}
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			else
			{
				this.Button2.Enabled = false;
			}
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x00008AF8 File Offset: 0x00006CF8
		private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00059560 File Offset: 0x00057760
		private void Button4_Click(object sender, EventArgs e)
		{
			MyProject.Forms.frmAddVoiceProfile.ShowDialog();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00059574 File Offset: 0x00057774
		private void ComboBox1_TextChanged(object sender, EventArgs e)
		{
			bool flag = Operators.CompareString(this.ComboBox1.Text, null, false) == 0;
			if (flag)
			{
				this.Button2.Enabled = false;
			}
		}

		// Token: 0x04000413 RID: 1043
		public bool VoicechangeMade;

		// Token: 0x04000414 RID: 1044
		private int iRow;

		// Token: 0x04000415 RID: 1045
		private int iCol;

		// Token: 0x04000416 RID: 1046
		private string setting;

		// Token: 0x04000417 RID: 1047
		private bool isEditing;

		// Token: 0x0200009E RID: 158
		// (Invoke) Token: 0x06000B19 RID: 2841
		private delegate void UpdateLabelDelegate(string text);

		// Token: 0x0200009F RID: 159
		// (Invoke) Token: 0x06000B1D RID: 2845
		private delegate void UpdateListeningButtonDelegate(int index);
	}
}
