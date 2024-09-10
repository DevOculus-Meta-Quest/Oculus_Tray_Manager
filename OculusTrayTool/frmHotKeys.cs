using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000022 RID: 34
	[DesignerGenerated]
	public partial class frmHotKeys : Form
	{
		// Token: 0x06000315 RID: 789 RVA: 0x000128F8 File Offset: 0x00010AF8
		public frmHotKeys()
		{
			base.KeyDown += this.frmHotKeys_KeyDown;
			this.KeyList = new List<string>();
			this.FunctionList = new List<string>();
			this.HotKeyList = new Dictionary<int, string>();
			this.isCapture = false;
			this.InitializeComponent();
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000318 RID: 792 RVA: 0x000133BF File Offset: 0x000115BF
		// (set) Token: 0x06000319 RID: 793 RVA: 0x000133CC File Offset: 0x000115CC
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
				MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.ListView1_MouseDown);
				ListView listView = this._ListView1;
				if (listView != null)
				{
					listView.MouseMove -= mouseEventHandler;
					listView.MouseDown -= mouseEventHandler2;
				}
				this._ListView1 = value;
				listView = this._ListView1;
				if (listView != null)
				{
					listView.MouseMove += mouseEventHandler;
					listView.MouseDown += mouseEventHandler2;
				}
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0001342A File Offset: 0x0001162A
		// (set) Token: 0x0600031B RID: 795 RVA: 0x00013434 File Offset: 0x00011634
		internal virtual ColumnHeader ColumnHeader1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0001343D File Offset: 0x0001163D
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00013447 File Offset: 0x00011647
		internal virtual ColumnHeader ColumnHeader3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00013450 File Offset: 0x00011650
		// (set) Token: 0x0600031F RID: 799 RVA: 0x0001345A File Offset: 0x0001165A
		internal virtual GroupBox GroupBox3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00013463 File Offset: 0x00011663
		// (set) Token: 0x06000321 RID: 801 RVA: 0x0001346D File Offset: 0x0001166D
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00013476 File Offset: 0x00011676
		// (set) Token: 0x06000323 RID: 803 RVA: 0x00013480 File Offset: 0x00011680
		internal virtual ComboBox ComboFunction
		{
			[CompilerGenerated]
			get
			{
				return this._ComboFunction;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.ComboFunction_KeyPress);
				ComboBox comboBox = this._ComboFunction;
				if (comboBox != null)
				{
					comboBox.KeyPress -= keyPressEventHandler;
				}
				this._ComboFunction = value;
				comboBox = this._ComboFunction;
				if (comboBox != null)
				{
					comboBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000324 RID: 804 RVA: 0x000134C3 File Offset: 0x000116C3
		// (set) Token: 0x06000325 RID: 805 RVA: 0x000134D0 File Offset: 0x000116D0
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

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000326 RID: 806 RVA: 0x00013513 File Offset: 0x00011713
		// (set) Token: 0x06000327 RID: 807 RVA: 0x00013520 File Offset: 0x00011720
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
				ContextMenuStrip contextMenuStrip = this._ContextMenuStrip1;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Opening -= cancelEventHandler;
				}
				this._ContextMenuStrip1 = value;
				contextMenuStrip = this._ContextMenuStrip1;
				if (contextMenuStrip != null)
				{
					contextMenuStrip.Opening += cancelEventHandler;
				}
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000328 RID: 808 RVA: 0x00013563 File Offset: 0x00011763
		// (set) Token: 0x06000329 RID: 809 RVA: 0x00013570 File Offset: 0x00011770
		internal virtual ToolStripMenuItem DeleteHotKeyToolStripMenuItem
		{
			[CompilerGenerated]
			get
			{
				return this._DeleteHotKeyToolStripMenuItem;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.DeleteHotKeyToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._DeleteHotKeyToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._DeleteHotKeyToolStripMenuItem = value;
				toolStripMenuItem = this._DeleteHotKeyToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600032A RID: 810 RVA: 0x000135B3 File Offset: 0x000117B3
		// (set) Token: 0x0600032B RID: 811 RVA: 0x000135C0 File Offset: 0x000117C0
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

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00013603 File Offset: 0x00011803
		// (set) Token: 0x0600032D RID: 813 RVA: 0x0001360D File Offset: 0x0001180D
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00013616 File Offset: 0x00011816
		// (set) Token: 0x0600032F RID: 815 RVA: 0x00013620 File Offset: 0x00011820
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

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00013663 File Offset: 0x00011863
		// (set) Token: 0x06000331 RID: 817 RVA: 0x00013670 File Offset: 0x00011870
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

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000332 RID: 818 RVA: 0x000136B3 File Offset: 0x000118B3
		// (set) Token: 0x06000333 RID: 819 RVA: 0x000136BD File Offset: 0x000118BD
		internal virtual ToolTip ToolTip1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000334 RID: 820 RVA: 0x000136C6 File Offset: 0x000118C6
		// (set) Token: 0x06000335 RID: 821 RVA: 0x000136D0 File Offset: 0x000118D0
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

		// Token: 0x06000336 RID: 822 RVA: 0x00013714 File Offset: 0x00011914
		private void Button1_Click(object sender, EventArgs e)
		{
			string text = "";
			checked
			{
				int num = this.ListView1.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					text = string.Concat(new string[]
					{
						text,
						this.ListView1.Items[i].Text,
						",",
						this.ListView1.Items[i].SubItems[1].Text,
						";"
					});
				}
				text = text.TrimEnd(new char[] { ';' });
				MySettingsProperty.Settings.HotKeyCombos = text;
				MySettingsProperty.Settings.Save();
				GetConfig.GetHotKeys();
				base.Close();
			}
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000137DA File Offset: 0x000119DA
		private void DeleteHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DeleteHotKey();
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000137E4 File Offset: 0x000119E4
		private void DeleteHotKey()
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			checked
			{
				if (flag)
				{
					this.ListView1.Items.RemoveAt(this.ListView1.SelectedIndices[0]);
					this.KeyList.Clear();
					this.FunctionList.Clear();
					string text = "";
					int num = this.ListView1.Items.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						this.KeyList.Add(this.ListView1.Items[i].SubItems[1].Text);
						this.FunctionList.Add(this.ListView1.Items[i].Text);
						text = string.Concat(new string[]
						{
							text,
							this.ListView1.Items[i].Text,
							",",
							this.ListView1.Items[i].SubItems[1].Text,
							";"
						});
					}
					text = text.TrimEnd(new char[] { ';' });
					MySettingsProperty.Settings.HotKeyCombos = text;
					MySettingsProperty.Settings.Save();
				}
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00013948 File Offset: 0x00011B48
		private void ListView1_MouseMove(object sender, MouseEventArgs e)
		{
			ListViewItem itemAt = this.ListView1.GetItemAt(e.X, e.Y);
			try
			{
				foreach (object obj in this.ListView1.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					bool flag = itemAt != null;
					if (flag)
					{
						itemAt.Selected = true;
					}
					else
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
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000139E0 File Offset: 0x00011BE0
		private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				this.ContextMenuStrip1.Enabled = true;
			}
			else
			{
				this.ContextMenuStrip1.Enabled = false;
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00013A24 File Offset: 0x00011C24
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.CheckBox1.Checked;
			if (@checked)
			{
				MySettingsProperty.Settings.HotKeyVoiceConfirmation = true;
			}
			else
			{
				MySettingsProperty.Settings.HotKeyVoiceConfirmation = false;
			}
			MySettingsProperty.Settings.Save();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00013A6C File Offset: 0x00011C6C
		private void Button2_Click(object sender, EventArgs e)
		{
			bool flag = Operators.CompareString(this.ComboFunction.Text, "", false) != 0;
			if (flag)
			{
				bool flag2 = !this.FunctionList.Contains(this.ComboFunction.Text);
				if (flag2)
				{
					bool flag3 = !this.KeyList.Contains(this.Label1.Text);
					if (flag3)
					{
						this.KeyList.Add(this.Label1.Text);
						this.FunctionList.Add(this.ComboFunction.Text);
						ListViewItem listViewItem = new ListViewItem();
						listViewItem = this.ListView1.Items.Add(this.ComboFunction.Text);
						listViewItem.SubItems.Add(this.Label1.Text);
					}
					else
					{
						Interaction.MsgBox("The selected key is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, "Error");
					}
				}
				else
				{
					Interaction.MsgBox("The selected function is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, "Error");
				}
				this.isCapture = false;
				this.Label1.Text = "";
				this.ComboFunction.Text = "";
				this.Button3.Enabled = true;
			}
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00013BA4 File Offset: 0x00011DA4
		private void frmHotKeys_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = this.isCapture;
			if (flag)
			{
				this.Label1.Text = e.KeyCode.ToString().ToUpper();
				this.Button3.Enabled = true;
				this.Button2.Enabled = true;
				this.isCapture = false;
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00013C04 File Offset: 0x00011E04
		private void ComboFunction_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00013C0F File Offset: 0x00011E0F
		private void Button3_Click(object sender, EventArgs e)
		{
			this.isCapture = true;
			this.Button3.Enabled = false;
			this.Button2.Enabled = false;
			this.Label1.Text = "Press any key to bind";
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00013C44 File Offset: 0x00011E44
		private void Button4_Click(object sender, EventArgs e)
		{
			this.DeleteHotKey();
			this.Button4.Enabled = false;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00013C5C File Offset: 0x00011E5C
		private void ListView1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = this.ListView1.SelectedItems.Count > 0;
			if (flag)
			{
				this.Button4.Enabled = true;
			}
			else
			{
				this.Button4.Enabled = false;
			}
		}

		// Token: 0x04000102 RID: 258
		public List<string> KeyList;

		// Token: 0x04000103 RID: 259
		public List<string> FunctionList;

		// Token: 0x04000104 RID: 260
		public Dictionary<int, string> HotKeyList;

		// Token: 0x04000105 RID: 261
		private bool isCapture;
	}
}
