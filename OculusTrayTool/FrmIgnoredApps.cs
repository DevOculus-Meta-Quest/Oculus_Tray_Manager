using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000023 RID: 35
	[DesignerGenerated]
	public partial class FrmIgnoredApps : Form
	{
		// Token: 0x06000342 RID: 834 RVA: 0x00013CA0 File Offset: 0x00011EA0
		public FrmIgnoredApps()
		{
			base.Load += this.FrmIgnoredApps_Load;
			this.InitializeComponent();
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00014176 File Offset: 0x00012376
		// (set) Token: 0x06000346 RID: 838 RVA: 0x00014180 File Offset: 0x00012380
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00014189 File Offset: 0x00012389
		// (set) Token: 0x06000348 RID: 840 RVA: 0x00014193 File Offset: 0x00012393
		internal virtual ListView ListView1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0001419C File Offset: 0x0001239C
		// (set) Token: 0x0600034A RID: 842 RVA: 0x000141A6 File Offset: 0x000123A6
		internal virtual ColumnHeader ColumnHeader1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600034B RID: 843 RVA: 0x000141AF File Offset: 0x000123AF
		// (set) Token: 0x0600034C RID: 844 RVA: 0x000141B9 File Offset: 0x000123B9
		internal virtual ColumnHeader ColumnHeader2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600034D RID: 845 RVA: 0x000141C2 File Offset: 0x000123C2
		// (set) Token: 0x0600034E RID: 846 RVA: 0x000141CC File Offset: 0x000123CC
		internal virtual ColumnHeader ColumnHeader3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600034F RID: 847 RVA: 0x000141D5 File Offset: 0x000123D5
		// (set) Token: 0x06000350 RID: 848 RVA: 0x000141E0 File Offset: 0x000123E0
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

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00014223 File Offset: 0x00012423
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00014230 File Offset: 0x00012430
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

		// Token: 0x06000353 RID: 851 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00014274 File Offset: 0x00012474
		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (object obj in this.ListView1.CheckedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					OTTDB.RemoveIgnoredApp(Conversions.ToString(listViewItem.Tag));
					OTTDB.AddIncludedApp(Conversions.ToString(listViewItem.Tag));
					Log.WriteToLog("'" + listViewItem.Text + "' is not being ignored anymore");
					MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + listViewItem.Text + "' is not being ignored anymore");
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
			this.Cursor = Cursors.WaitCursor;
			this.GetIgnoredApps();
			MyProject.Forms.FrmMain.ignoredApps = (List<string>)OTTDB.GetIgnoredApps();
			MyProject.Forms.FrmMain.includedApps = (List<string>)OTTDB.GetIncludedApps();
			MyProject.Forms.frmLibrary.PopulateList();
			this.Cursor = Cursors.Default;
			base.Close();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000143A0 File Offset: 0x000125A0
		private void FrmIgnoredApps_Load(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			frmLibrary.SetDoubleBuffering(this.ListView1, true);
			this.GetIgnoredApps();
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000143D0 File Offset: 0x000125D0
		private void GetIgnoredApps()
		{
			this.ListView1.Items.Clear();
			List<string> list = (List<string>)OTTDB.GetIgnoredApps();
			try
			{
				foreach (string text in list)
				{
					bool flag = File.Exists(text);
					if (flag)
					{
						string text2 = File.ReadAllText(text);
						JObject jobject = JObject.Parse(text2);
						string text3 = jobject.SelectToken("canonicalName").ToString();
						string text4 = "";
						string text5 = "";
						string text6 = "";
						List<JToken> list2 = ((IEnumerable<JToken>)jobject.Children()).ToList<JToken>();
						try
						{
							foreach (JToken jtoken in list2)
							{
								JProperty jproperty = (JProperty)jtoken;
								jproperty.CreateReader();
								string name = jproperty.Name;
								if (Operators.CompareString(name, "displayName", false) != 0)
								{
									if (Operators.CompareString(name, "launchFile", false) != 0)
									{
										if (Operators.CompareString(name, "launchParameters", false) == 0)
										{
											text6 = jproperty.Value.ToString();
										}
									}
									else
									{
										string fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
										text5 = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
										bool flag2 = text4.ToLower().EndsWith(".exe") | (Operators.CompareString(text4.ToLower(), "unknown app", false) == 0);
										if (flag2)
										{
											text4 = Path.GetFileNameWithoutExtension(fileName);
										}
									}
								}
								else
								{
									text4 = jproperty.Value.ToString();
								}
							}
						}
						finally
						{
							List<JToken>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						ListViewItem listViewItem = new ListViewItem(text4);
						listViewItem.SubItems.Add(text6);
						listViewItem.SubItems.Add(text5);
						listViewItem.Tag = text;
						this.ListView1.Items.Add(listViewItem);
					}
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}
	}
}
