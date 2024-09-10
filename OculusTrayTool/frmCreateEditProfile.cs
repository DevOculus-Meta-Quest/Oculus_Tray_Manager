using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x0200001A RID: 26
	[DesignerGenerated]
	public partial class frmCreateEditProfile : Form
	{
		// Token: 0x060001E0 RID: 480 RVA: 0x000091E5 File Offset: 0x000073E5
		public frmCreateEditProfile()
		{
			base.Load += this.CreateEditProfile_Load;
			this.CreateCancel = false;
			this.isEdit = false;
			this.DSep = ".";
			this.InitializeComponent();
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000B9C1 File Offset: 0x00009BC1
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x0000B9CB File Offset: 0x00009BCB
		internal virtual ComboBox ComboCPU
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000B9D4 File Offset: 0x00009BD4
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x0000B9DE File Offset: 0x00009BDE
		internal virtual TextBox TextDisplayName
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x0000B9E7 File Offset: 0x00009BE7
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x0000B9F1 File Offset: 0x00009BF1
		internal virtual ComboBox ComboASW
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000B9FA File Offset: 0x00009BFA
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000BA04 File Offset: 0x00009C04
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001EB RID: 491 RVA: 0x0000BA0D File Offset: 0x00009C0D
		// (set) Token: 0x060001EC RID: 492 RVA: 0x0000BA17 File Offset: 0x00009C17
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000BA20 File Offset: 0x00009C20
		// (set) Token: 0x060001EE RID: 494 RVA: 0x0000BA2A File Offset: 0x00009C2A
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000BA33 File Offset: 0x00009C33
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0000BA3D File Offset: 0x00009C3D
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000BA46 File Offset: 0x00009C46
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x0000BA50 File Offset: 0x00009C50
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x0000BA59 File Offset: 0x00009C59
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x0000BA63 File Offset: 0x00009C63
		internal virtual ComboBox ComboMethod
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0000BA6C File Offset: 0x00009C6C
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x0000BA76 File Offset: 0x00009C76
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000BA7F File Offset: 0x00009C7F
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x0000BA89 File Offset: 0x00009C89
		internal virtual PictureBox PictureBox5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x0000BA92 File Offset: 0x00009C92
		// (set) Token: 0x060001FA RID: 506 RVA: 0x0000BA9C File Offset: 0x00009C9C
		internal virtual PictureBox PictureBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000BAA5 File Offset: 0x00009CA5
		// (set) Token: 0x060001FC RID: 508 RVA: 0x0000BAAF File Offset: 0x00009CAF
		internal virtual PictureBox PictureBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000BAB8 File Offset: 0x00009CB8
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000BAC2 File Offset: 0x00009CC2
		internal virtual PictureBox PictureBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0000BACB File Offset: 0x00009CCB
		// (set) Token: 0x06000200 RID: 512 RVA: 0x0000BAD5 File Offset: 0x00009CD5
		internal virtual PictureBox PictureBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000201 RID: 513 RVA: 0x0000BADE File Offset: 0x00009CDE
		// (set) Token: 0x06000202 RID: 514 RVA: 0x0000BAE8 File Offset: 0x00009CE8
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000203 RID: 515 RVA: 0x0000BAF1 File Offset: 0x00009CF1
		// (set) Token: 0x06000204 RID: 516 RVA: 0x0000BAFC File Offset: 0x00009CFC
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

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000BB3F File Offset: 0x00009D3F
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000BB4C File Offset: 0x00009D4C
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000BB8F File Offset: 0x00009D8F
		// (set) Token: 0x06000208 RID: 520 RVA: 0x0000BB99 File Offset: 0x00009D99
		internal virtual NumericUpDown NumericUpDown1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000BBA2 File Offset: 0x00009DA2
		// (set) Token: 0x0600020A RID: 522 RVA: 0x0000BBAC File Offset: 0x00009DAC
		internal virtual PictureBox PictureBox6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000BBB5 File Offset: 0x00009DB5
		// (set) Token: 0x0600020C RID: 524 RVA: 0x0000BBBF File Offset: 0x00009DBF
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000BBC8 File Offset: 0x00009DC8
		// (set) Token: 0x0600020E RID: 526 RVA: 0x0000BBD2 File Offset: 0x00009DD2
		internal virtual NumericUpDown NumericUpDown2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000BBDB File Offset: 0x00009DDB
		// (set) Token: 0x06000210 RID: 528 RVA: 0x0000BBE5 File Offset: 0x00009DE5
		internal virtual PictureBox PictureBox7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000BBEE File Offset: 0x00009DEE
		// (set) Token: 0x06000212 RID: 530 RVA: 0x0000BBF8 File Offset: 0x00009DF8
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000BC01 File Offset: 0x00009E01
		// (set) Token: 0x06000214 RID: 532 RVA: 0x0000BC0B File Offset: 0x00009E0B
		internal virtual PictureBox PictureBox8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000BC14 File Offset: 0x00009E14
		// (set) Token: 0x06000216 RID: 534 RVA: 0x0000BC1E File Offset: 0x00009E1E
		internal virtual TextBox TextBoxPath
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0000BC27 File Offset: 0x00009E27
		// (set) Token: 0x06000218 RID: 536 RVA: 0x0000BC31 File Offset: 0x00009E31
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000219 RID: 537 RVA: 0x0000BC3A File Offset: 0x00009E3A
		// (set) Token: 0x0600021A RID: 538 RVA: 0x0000BC44 File Offset: 0x00009E44
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

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000BC87 File Offset: 0x00009E87
		// (set) Token: 0x0600021C RID: 540 RVA: 0x0000BC94 File Offset: 0x00009E94
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

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		// (set) Token: 0x0600021E RID: 542 RVA: 0x0000BCFC File Offset: 0x00009EFC
		internal virtual ComboBox ComboMirror
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0000BD05 File Offset: 0x00009F05
		// (set) Token: 0x06000220 RID: 544 RVA: 0x0000BD0F File Offset: 0x00009F0F
		internal virtual Label Label9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000221 RID: 545 RVA: 0x0000BD18 File Offset: 0x00009F18
		// (set) Token: 0x06000222 RID: 546 RVA: 0x0000BD22 File Offset: 0x00009F22
		internal virtual PictureBox PictureBox9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000BD2B File Offset: 0x00009F2B
		// (set) Token: 0x06000224 RID: 548 RVA: 0x0000BD35 File Offset: 0x00009F35
		internal virtual PictureBox PictureBox10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000BD3E File Offset: 0x00009F3E
		// (set) Token: 0x06000226 RID: 550 RVA: 0x0000BD48 File Offset: 0x00009F48
		internal virtual ComboBox ComboAGPS
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000BD51 File Offset: 0x00009F51
		// (set) Token: 0x06000228 RID: 552 RVA: 0x0000BD5B File Offset: 0x00009F5B
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000229 RID: 553 RVA: 0x0000BD64 File Offset: 0x00009F64
		// (set) Token: 0x0600022A RID: 554 RVA: 0x0000BD70 File Offset: 0x00009F70
		internal virtual ComboBox ComboSS
		{
			[CompilerGenerated]
			get
			{
				return this._ComboSS;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.ComboSS_KeyPress);
				ComboBox comboBox = this._ComboSS;
				if (comboBox != null)
				{
					comboBox.KeyPress -= keyPressEventHandler;
				}
				this._ComboSS = value;
				comboBox = this._ComboSS;
				if (comboBox != null)
				{
					comboBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600022B RID: 555 RVA: 0x0000BDB3 File Offset: 0x00009FB3
		// (set) Token: 0x0600022C RID: 556 RVA: 0x0000BDBD File Offset: 0x00009FBD
		internal virtual TextBox TextBoxComment
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600022D RID: 557 RVA: 0x0000BDC6 File Offset: 0x00009FC6
		// (set) Token: 0x0600022E RID: 558 RVA: 0x0000BDD0 File Offset: 0x00009FD0
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0000BDD9 File Offset: 0x00009FD9
		// (set) Token: 0x06000230 RID: 560 RVA: 0x0000BDE3 File Offset: 0x00009FE3
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000231 RID: 561 RVA: 0x0000BDEC File Offset: 0x00009FEC
		// (set) Token: 0x06000232 RID: 562 RVA: 0x0000BDF6 File Offset: 0x00009FF6
		internal virtual Label Label14
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0000BDFF File Offset: 0x00009FFF
		// (set) Token: 0x06000234 RID: 564 RVA: 0x0000BE09 File Offset: 0x0000A009
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000235 RID: 565 RVA: 0x0000BE12 File Offset: 0x0000A012
		// (set) Token: 0x06000236 RID: 566 RVA: 0x0000BE1C File Offset: 0x0000A01C
		internal virtual NumericUpDown NumericUpDown3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000237 RID: 567 RVA: 0x0000BE25 File Offset: 0x0000A025
		// (set) Token: 0x06000238 RID: 568 RVA: 0x0000BE2F File Offset: 0x0000A02F
		internal virtual NumericUpDown NumericUpDown4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0000BE38 File Offset: 0x0000A038
		// (set) Token: 0x0600023A RID: 570 RVA: 0x0000BE42 File Offset: 0x0000A042
		internal virtual PictureBox PictureBox11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000BE4B File Offset: 0x0000A04B
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000BE55 File Offset: 0x0000A055
		internal virtual Label Label33
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000BE5E File Offset: 0x0000A05E
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0000BE68 File Offset: 0x0000A068
		internal virtual ComboBox ComboBox8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0000BE71 File Offset: 0x0000A071
		// (set) Token: 0x06000240 RID: 576 RVA: 0x0000BE7B File Offset: 0x0000A07B
		internal virtual ComboBox ComboBox9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000BE84 File Offset: 0x0000A084
		// (set) Token: 0x06000242 RID: 578 RVA: 0x0000BE8E File Offset: 0x0000A08E
		internal virtual Label Label37
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0000BE97 File Offset: 0x0000A097
		// (set) Token: 0x06000244 RID: 580 RVA: 0x0000BEA1 File Offset: 0x0000A0A1
		internal virtual ComboBox ComboBoxEnabled
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000BEAA File Offset: 0x0000A0AA
		// (set) Token: 0x06000246 RID: 582 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		internal virtual Label Label15
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000BEC0 File Offset: 0x0000A0C0
		private void Button1_Click(object sender, EventArgs e)
		{
			bool flag = Operators.CompareString(this.TextDisplayName.Text, null, false) == 0;
			checked
			{
				if (!flag)
				{
					MyProject.Forms.frmProfiles.TopMost = true;
					bool flag2 = Operators.CompareString(this.TextDisplayName.Text, "- All Games & Apps -", false) != 0;
					if (flag2)
					{
						this.pLaunchfile = Path.GetFileName(this.TextBoxPath.Text);
						this.pPath = this.TextBoxPath.Text;
						OTTDB.AddProfile(this.TextDisplayName.Text, this.ComboASW.Text, this.ComboSS.Text, this.ComboCPU.Text, this.pLaunchfile, this.pPath, this.ComboMethod.Text, this.NumericUpDown1.Value.ToString(), this.NumericUpDown2.Value.ToString(), this.ComboMirror.SelectedIndex.ToString(), this.ComboAGPS.SelectedIndex.ToString(), this.TextBoxComment.Text, this.NumericUpDown3.Value.ToString() + " " + this.NumericUpDown4.Value.ToString(), this.ComboBox8.Text, this.ComboBox9.Text, this.ComboBoxEnabled.Text);
					}
					else
					{
						this.Cursor = Cursors.WaitCursor;
						int num = this.ComboBox1.Items.Count - 1;
						for (int i = 1; i <= num; i++)
						{
							frmCreateEditProfile.GameItem gameItem = (frmCreateEditProfile.GameItem)this.ComboBox1.Items[i];
							this.TextBoxPath.Text = gameItem.info;
							this.TextDisplayName.Text = gameItem.Name;
							this.pLaunchfile = Path.GetFileName(this.TextBoxPath.Text);
							this.pPath = this.TextBoxPath.Text;
							OTTDB.AddProfile(this.TextDisplayName.Text, this.ComboASW.Text, this.ComboSS.Text, this.ComboCPU.Text, this.pLaunchfile, this.pPath, this.ComboMethod.Text, this.NumericUpDown1.Value.ToString(), this.NumericUpDown2.Value.ToString(), this.ComboMirror.SelectedIndex.ToString(), this.ComboAGPS.SelectedIndex.ToString(), this.TextBoxComment.Text, this.NumericUpDown3.Value.ToString() + " " + this.NumericUpDown4.Value.ToString(), this.ComboBox8.Text, this.ComboBox9.Text, this.ComboBoxEnabled.Text);
						}
						this.Cursor = Cursors.Default;
					}
					OTTDB.GetProfiles();
					bool flag3 = MyProject.Forms.FrmMain.HomeIsRunning | MySettingsProperty.Settings.StartAppwatcherOnStart;
					if (flag3)
					{
						bool flag4 = OTTDB.numWMI > 0;
						if (flag4)
						{
							MyProject.Forms.FrmMain.CreateWatcher();
						}
						bool flag5 = OTTDB.numTimer > 0;
						if (flag5)
						{
							MyProject.Forms.FrmMain.pTimer.Start();
						}
					}
					this.ComboBox1.Items.Remove(RuntimeHelpers.GetObjectValue(this.ComboBox1.SelectedItem));
					this.ComboBox1.Text = "- Select Game -";
					this.ComboSS.SelectedIndex = 0;
					this.ComboASW.SelectedIndex = 0;
					this.ComboCPU.SelectedIndex = 0;
					this.ComboMethod.SelectedIndex = 0;
					this.NumericUpDown1.Value = 5m;
					this.NumericUpDown2.Value = 5m;
					this.TextBoxPath.Text = "";
					this.TextDisplayName.Text = "";
					this.ComboMirror.SelectedIndex = 0;
					this.ComboAGPS.SelectedIndex = 1;
					this.NumericUpDown3.Value = 0m;
					this.NumericUpDown4.Value = 0m;
					this.ComboBoxEnabled.Text = "Yes";
					base.Close();
				}
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000C348 File Offset: 0x0000A548
		private void Button2_Click(object sender, EventArgs e)
		{
			this.CreateCancel = true;
			this.ComboBox1.Text = "- Select Game -";
			this.ComboSS.SelectedIndex = 0;
			this.ComboASW.SelectedIndex = 0;
			this.ComboCPU.SelectedIndex = 0;
			this.ComboMethod.SelectedIndex = 0;
			this.NumericUpDown1.Value = 5m;
			this.NumericUpDown2.Value = 5m;
			this.TextBoxPath.Text = "";
			this.TextDisplayName.Text = "";
			this.ComboAGPS.SelectedIndex = 1;
			this.NumericUpDown3.Value = 0m;
			this.NumericUpDown4.Value = 0m;
			this.ComboBoxEnabled.Text = "Yes";
			base.Close();
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000C434 File Offset: 0x0000A634
		private void Button3_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Browse...";
			bool flag = Operators.CompareString(this.TextBoxPath.Text, "", false) != 0;
			if (flag)
			{
				bool flag2 = Directory.Exists(Path.GetDirectoryName(this.TextBoxPath.Text));
				if (flag2)
				{
					openFileDialog.InitialDirectory = Path.GetDirectoryName(this.TextBoxPath.Text);
				}
			}
			else
			{
				openFileDialog.InitialDirectory = MyProject.Forms.FrmMain.OculusPath;
			}
			openFileDialog.Filter = "Executable files (*.exe)|*.exe";
			bool flag3 = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag3)
			{
				this.TextDisplayName.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
				this.TextDisplayName.Visible = true;
				this.ComboBox1.Visible = false;
				this.TextBoxPath.Text = openFileDialog.FileName;
				this.Button1.Enabled = true;
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000C52C File Offset: 0x0000A72C
		private void CreateEditProfile_Load(object sender, EventArgs e)
		{
			this.ToolTip1.SetToolTip(this.PictureBox2, "Sets the level of Super Sampling, or Pixel Density, to apply to the app when it is started.\r\nThis value acts as a multiplier, it is not the definitive value the app will get.\r\nThat depends on what the native Pixeld Density the app runs att.\r\nUse the Pixel Density Visual HUD to check what you actually get, and adjust this value to get the desired result.");
			this.ToolTip1.SetToolTip(this.PictureBox3, "Sets the mode for Asynchronous Space Warp (ASW).\r\nThis should usualy be set to Auto unless you experience issues.");
			this.ToolTip1.SetToolTip(this.PictureBox4, "Makes Windows give this app a bit higher priority over other system resources.\r\n Can improve performance.");
			this.ToolTip1.SetToolTip(this.PictureBox5, "Determines how OTT should detect this app. WMI is default and has less impact on CPU performace\r\nbut is less accurate in detecting games starts. Might not work for every game.\r\nThe Timer method consumes more CPU bit is a lot more accurate.\r\nUse Timer for the apps that do not work with WMI.");
			this.ToolTip1.SetToolTip(this.PictureBox8, "The path to the executable that OTT should monitor. This is usally correct and should in most\r\ncases not be touched. But in some cases it might be neccessary to modify this\r\nso OTT detects the right process.");
			this.ToolTip1.SetToolTip(this.PictureBox11, "Setting this to a value lower than 1, for example 0.8, will cause a lower FOV in the headset which\r\nwill increase the FPS due to less pixels being drawn.\r\nUsing a value higher than 1 will only affect the Mirror view on your desktop.");
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000C5C4 File Offset: 0x0000A7C4
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = Operators.CompareString(this.ComboBox1.SelectedItem.ToString(), "- All Games & Apps -", false) != 0;
			if (flag)
			{
				frmCreateEditProfile.GameItem gameItem = (frmCreateEditProfile.GameItem)this.ComboBox1.SelectedItem;
				this.TextBoxPath.Text = gameItem.info;
				this.TextDisplayName.Text = gameItem.Name;
			}
			else
			{
				this.TextDisplayName.Text = "- All Games & Apps -";
			}
			this.Button1.Enabled = true;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000C64C File Offset: 0x0000A84C
		private void ComboBox1_TextChanged(object sender, EventArgs e)
		{
			this.TextDisplayName.Text = this.ComboBox1.Text;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000C668 File Offset: 0x0000A868
		private void ComboSS_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsNumber(e.KeyChar) & (e.KeyChar != '.') & (Convert.ToInt32(e.KeyChar) != 8);
			if (flag)
			{
				bool flag2 = e.KeyChar == Conversions.ToChar(this.DSep);
				if (flag2)
				{
					e.Handled = true;
				}
				else
				{
					e.Handled = true;
				}
			}
		}

		// Token: 0x04000099 RID: 153
		public string pLaunchfile;

		// Token: 0x0400009A RID: 154
		public string pPath;

		// Token: 0x0400009B RID: 155
		public bool CreateCancel;

		// Token: 0x0400009C RID: 156
		public bool isEdit;

		// Token: 0x0400009D RID: 157
		private string DSep;

		// Token: 0x02000067 RID: 103
		public class GameItem
		{
			// Token: 0x06000A05 RID: 2565 RVA: 0x0005A0B8 File Offset: 0x000582B8
			public GameItem(string name, string info)
			{
				this.mInfo = info;
				this.mName = name;
			}

			// Token: 0x17000362 RID: 866
			// (get) Token: 0x06000A06 RID: 2566 RVA: 0x0005A0D0 File Offset: 0x000582D0
			// (set) Token: 0x06000A07 RID: 2567 RVA: 0x0005A0E8 File Offset: 0x000582E8
			public string info
			{
				get
				{
					return this.mInfo;
				}
				set
				{
					this.mInfo = value;
				}
			}

			// Token: 0x17000363 RID: 867
			// (get) Token: 0x06000A08 RID: 2568 RVA: 0x0005A0F4 File Offset: 0x000582F4
			// (set) Token: 0x06000A09 RID: 2569 RVA: 0x0005A10C File Offset: 0x0005830C
			public string Name
			{
				get
				{
					return this.mName;
				}
				set
				{
					this.mName = value;
				}
			}

			// Token: 0x04000444 RID: 1092
			private string mInfo;

			// Token: 0x04000445 RID: 1093
			private string mName;
		}
	}
}
