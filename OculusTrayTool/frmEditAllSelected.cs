using System;
using System.Collections;
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
	// Token: 0x0200001F RID: 31
	[DesignerGenerated]
	public partial class frmEditAllSelected : Form
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000E09D File Offset: 0x0000C29D
		public frmEditAllSelected()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000284 RID: 644 RVA: 0x000101C7 File Offset: 0x0000E3C7
		// (set) Token: 0x06000285 RID: 645 RVA: 0x000101D1 File Offset: 0x0000E3D1
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000286 RID: 646 RVA: 0x000101DA File Offset: 0x0000E3DA
		// (set) Token: 0x06000287 RID: 647 RVA: 0x000101E4 File Offset: 0x0000E3E4
		internal virtual PictureBox PictureBox10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000288 RID: 648 RVA: 0x000101ED File Offset: 0x0000E3ED
		// (set) Token: 0x06000289 RID: 649 RVA: 0x000101F7 File Offset: 0x0000E3F7
		internal virtual ComboBox ComboAGPS
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00010200 File Offset: 0x0000E400
		// (set) Token: 0x0600028B RID: 651 RVA: 0x0001020A File Offset: 0x0000E40A
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00010213 File Offset: 0x0000E413
		// (set) Token: 0x0600028D RID: 653 RVA: 0x0001021D File Offset: 0x0000E41D
		internal virtual PictureBox PictureBox9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600028E RID: 654 RVA: 0x00010226 File Offset: 0x0000E426
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00010230 File Offset: 0x0000E430
		internal virtual ComboBox ComboMirror
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00010239 File Offset: 0x0000E439
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00010243 File Offset: 0x0000E443
		internal virtual Label Label9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0001024C File Offset: 0x0000E44C
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00010256 File Offset: 0x0000E456
		internal virtual NumericUpDown NumericUpDown2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000294 RID: 660 RVA: 0x0001025F File Offset: 0x0000E45F
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00010269 File Offset: 0x0000E469
		internal virtual PictureBox PictureBox7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00010272 File Offset: 0x0000E472
		// (set) Token: 0x06000297 RID: 663 RVA: 0x0001027C File Offset: 0x0000E47C
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00010285 File Offset: 0x0000E485
		// (set) Token: 0x06000299 RID: 665 RVA: 0x0001028F File Offset: 0x0000E48F
		internal virtual NumericUpDown NumericUpDown1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00010298 File Offset: 0x0000E498
		// (set) Token: 0x0600029B RID: 667 RVA: 0x000102A2 File Offset: 0x0000E4A2
		internal virtual PictureBox PictureBox6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600029C RID: 668 RVA: 0x000102AB File Offset: 0x0000E4AB
		// (set) Token: 0x0600029D RID: 669 RVA: 0x000102B5 File Offset: 0x0000E4B5
		internal virtual Label Label6
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600029E RID: 670 RVA: 0x000102BE File Offset: 0x0000E4BE
		// (set) Token: 0x0600029F RID: 671 RVA: 0x000102C8 File Offset: 0x0000E4C8
		internal virtual PictureBox PictureBox5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x000102D1 File Offset: 0x0000E4D1
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x000102DB File Offset: 0x0000E4DB
		internal virtual PictureBox PictureBox4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x000102E4 File Offset: 0x0000E4E4
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x000102EE File Offset: 0x0000E4EE
		internal virtual PictureBox PictureBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x000102F7 File Offset: 0x0000E4F7
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00010301 File Offset: 0x0000E501
		internal virtual PictureBox PictureBox2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0001030A File Offset: 0x0000E50A
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00010314 File Offset: 0x0000E514
		internal virtual ComboBox ComboMethod
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x0001031D File Offset: 0x0000E51D
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00010327 File Offset: 0x0000E527
		internal virtual ComboBox ComboASW
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00010330 File Offset: 0x0000E530
		// (set) Token: 0x060002AB RID: 683 RVA: 0x0001033A File Offset: 0x0000E53A
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00010343 File Offset: 0x0000E543
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0001034D File Offset: 0x0000E54D
		internal virtual ComboBox ComboCPU
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00010356 File Offset: 0x0000E556
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00010360 File Offset: 0x0000E560
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00010369 File Offset: 0x0000E569
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00010374 File Offset: 0x0000E574
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

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x000103B7 File Offset: 0x0000E5B7
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x000103C1 File Offset: 0x0000E5C1
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000103CA File Offset: 0x0000E5CA
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x000103D4 File Offset: 0x0000E5D4
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000103DD File Offset: 0x0000E5DD
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x000103E8 File Offset: 0x0000E5E8
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

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x0001042B File Offset: 0x0000E62B
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00010438 File Offset: 0x0000E638
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

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0001047B File Offset: 0x0000E67B
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00010485 File Offset: 0x0000E685
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0001048E File Offset: 0x0000E68E
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00010498 File Offset: 0x0000E698
		internal virtual TextBox TextBoxComment
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060002BE RID: 702 RVA: 0x000104A1 File Offset: 0x0000E6A1
		// (set) Token: 0x060002BF RID: 703 RVA: 0x000104AB File Offset: 0x0000E6AB
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x000104B4 File Offset: 0x0000E6B4
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x000104BE File Offset: 0x0000E6BE
		internal virtual PictureBox PictureBox11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x000104C7 File Offset: 0x0000E6C7
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x000104D1 File Offset: 0x0000E6D1
		internal virtual NumericUpDown NumericUpDown3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x000104DA File Offset: 0x0000E6DA
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x000104E4 File Offset: 0x0000E6E4
		internal virtual NumericUpDown NumericUpDown4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x000104ED File Offset: 0x0000E6ED
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x000104F7 File Offset: 0x0000E6F7
		internal virtual Label Label14
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00010500 File Offset: 0x0000E700
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0001050A File Offset: 0x0000E70A
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00010513 File Offset: 0x0000E713
		// (set) Token: 0x060002CB RID: 715 RVA: 0x0001051D File Offset: 0x0000E71D
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00010526 File Offset: 0x0000E726
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00010530 File Offset: 0x0000E730
		internal virtual Label Label33
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00010539 File Offset: 0x0000E739
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00010543 File Offset: 0x0000E743
		internal virtual ComboBox ComboBox8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x0001054C File Offset: 0x0000E74C
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x00010556 File Offset: 0x0000E756
		internal virtual ComboBox ComboBox9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x0001055F File Offset: 0x0000E75F
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00010569 File Offset: 0x0000E769
		internal virtual Label Label37
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00010572 File Offset: 0x0000E772
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x0001057C File Offset: 0x0000E77C
		internal virtual ComboBox ComboBoxEnabled
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00010585 File Offset: 0x0000E785
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x0001058F File Offset: 0x0000E78F
		internal virtual Label Label15
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00010598 File Offset: 0x0000E798
		private void Button1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				try
				{
					foreach (object obj in MyProject.Forms.frmProfiles.ListView1.CheckedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						string[] array = Strings.Split(Conversions.ToString(listViewItem.Tag), ",", -1, CompareMethod.Binary);
						string text = array[0];
						string text2 = array[1];
						string text3 = array[2];
						string text4 = array[4];
						string text5 = array[3];
						string text6 = array[5];
						string text7 = array[6];
						string text8 = array[7];
						string text9 = array[8];
						bool flag = Operators.CompareString(text9, "Default", false) == 0;
						if (flag)
						{
							text9 = "0";
						}
						bool flag2 = Operators.CompareString(text9, "Minimized", false) == 0;
						if (flag2)
						{
							text9 = "1";
						}
						bool flag3 = Operators.CompareString(text9, "Forced", false) == 0;
						if (flag3)
						{
							text9 = "2";
						}
						string text10 = array[9];
						bool flag4 = Operators.CompareString(text10, "On", false) == 0;
						if (flag4)
						{
							text10 = Conversions.ToString(1);
						}
						bool flag5 = Operators.CompareString(text10, "Off", false) == 0;
						if (flag5)
						{
							text10 = Conversions.ToString(0);
						}
						string text11 = array[10];
						string text12 = array[11];
						string text13 = array[12];
						string text14 = array[13];
						string text15 = array[14];
						bool flag6 = Operators.CompareString(this.ComboSS.Text, "", false) != 0;
						if (flag6)
						{
							text2 = this.ComboSS.Text;
						}
						bool flag7 = Operators.CompareString(this.ComboASW.Text, "", false) != 0;
						if (flag7)
						{
							text3 = this.ComboASW.Text;
						}
						bool flag8 = Operators.CompareString(this.NumericUpDown1.Text, "", false) != 0;
						if (flag8)
						{
							text7 = this.NumericUpDown1.Value.ToString();
						}
						bool flag9 = Operators.CompareString(this.ComboCPU.Text, "", false) != 0;
						if (flag9)
						{
							text4 = this.ComboCPU.Text;
						}
						bool flag10 = Operators.CompareString(this.NumericUpDown2.Text, "", false) != 0;
						if (flag10)
						{
							text8 = this.NumericUpDown2.Value.ToString();
						}
						bool flag11 = Operators.CompareString(this.ComboMethod.Text, "", false) != 0;
						if (flag11)
						{
							text5 = this.ComboMethod.Text;
						}
						bool flag12 = Operators.CompareString(this.ComboMirror.Text, "", false) != 0;
						if (flag12)
						{
							text9 = this.ComboMirror.SelectedIndex.ToString();
						}
						bool flag13 = Operators.CompareString(this.ComboAGPS.Text, "", false) != 0;
						if (flag13)
						{
							text10 = this.ComboAGPS.SelectedIndex.ToString();
						}
						bool flag14 = Operators.CompareString(this.TextBoxComment.Text, "", false) != 0;
						if (flag14)
						{
							text11 = this.TextBoxComment.Text;
						}
						OTTDB.AddProfile(text, text3, text2, text4, Path.GetFileName(text6), text6, text5, text7, text8, text9, text10, text11, this.NumericUpDown3.Value.ToString() + " " + this.NumericUpDown4.Value.ToString(), this.ComboBox8.Text, this.ComboBox9.Text, this.ComboBoxEnabled.Text);
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
				OTTDB.GetProfiles();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Update all selected profiles: " + ex.Message);
			}
			this.Cursor = Cursors.Default;
			base.Close();
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0001099C File Offset: 0x0000EB9C
		private void ComboSS_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsNumber(e.KeyChar) & (e.KeyChar != '.') & (Convert.ToInt32(e.KeyChar) != 8);
			if (flag)
			{
				object obj;
				bool flag2 = e.KeyChar == Conversions.ToChar(obj);
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
	}
}
