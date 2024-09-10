using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool
{
	// Token: 0x02000040 RID: 64
	[DesignerGenerated]
	public partial class frmProperties : Form
	{
		// Token: 0x0600055F RID: 1375 RVA: 0x0002C138 File Offset: 0x0002A338
		public frmProperties()
		{
			base.Load += this.Properties_Load;
			this.InitializeComponent();
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0002C84C File Offset: 0x0002AA4C
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0002C856 File Offset: 0x0002AA56
		internal virtual RichTextBox RichTextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0002C85F File Offset: 0x0002AA5F
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0002C869 File Offset: 0x0002AA69
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0002C872 File Offset: 0x0002AA72
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x0002C87C File Offset: 0x0002AA7C
		internal virtual Label LabelProperties
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0002C885 File Offset: 0x0002AA85
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0002C890 File Offset: 0x0002AA90
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

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0002C8D3 File Offset: 0x0002AAD3
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x0002C8DD File Offset: 0x0002AADD
		internal virtual CheckBox CheckBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0002C8E6 File Offset: 0x0002AAE6
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0002C8F0 File Offset: 0x0002AAF0
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

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0002C933 File Offset: 0x0002AB33
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x0002C93D File Offset: 0x0002AB3D
		internal virtual Label LabelProperties2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0002C946 File Offset: 0x0002AB46
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x0002C950 File Offset: 0x0002AB50
		internal virtual TextBox TextBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00008AFB File Offset: 0x00006CFB
		private void Button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0002C95C File Offset: 0x0002AB5C
		private void FormatText(string searchstring, FontStyle style)
		{
			for (int num = this.RichTextBox1.Find(searchstring, 0, RichTextBoxFinds.MatchCase); num != -1; num = this.RichTextBox1.Find(searchstring, checked(num + searchstring.Length), RichTextBoxFinds.MatchCase))
			{
				this.RichTextBox1.Select(num, searchstring.Length);
				this.RichTextBox1.SelectionFont = new Font(this.RichTextBox1.Font, style);
				this.RichTextBox1.SelectionColor = Color.DodgerBlue;
			}
			this.RichTextBox1.Select(0, 0);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0002C9EC File Offset: 0x0002ABEC
		private void Properties_Load(object sender, EventArgs e)
		{
			this.FormatText("displayName", FontStyle.Bold);
			this.FormatText("launchFile", FontStyle.Bold);
			this.FormatText("launchParameters", FontStyle.Bold);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0002CA18 File Offset: 0x0002AC18
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void Button1_Click(object sender, EventArgs e)
		{
			bool @checked = this.CheckBox1.Checked;
			if (@checked)
			{
				string text = ".BKP_" + DateTime.Now.ToString("yyyyMMddHHmmss");
				FileSystem.FileCopy(this.fname, this.fname + text);
				Log.WriteToLog(string.Concat(new string[] { "Backup made: ", this.fname, " -> ", this.fname, text }));
			}
			bool flag = frmProperties.IsValidJson(this.RichTextBox1.Text);
			if (flag)
			{
				bool flag2 = Interaction.MsgBox("JSON formatting looks OK, do you want to save this file?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, null) == MsgBoxResult.Yes;
				if (flag2)
				{
					StreamWriter streamWriter = new StreamWriter(this.fname);
					streamWriter.Write(this.RichTextBox1.Text);
					streamWriter.Close();
					Log.WriteToLog(this.fname + " was edited");
				}
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0002CB10 File Offset: 0x0002AD10
		private static bool IsValidJson(string strInput)
		{
			strInput = strInput.Trim();
			bool flag = (strInput.StartsWith("{") && strInput.EndsWith("}")) || (strInput.StartsWith("[") && strInput.EndsWith("]"));
			if (flag)
			{
				try
				{
					JToken jtoken = JToken.Parse(strInput);
					return true;
				}
				catch (JsonReaderException ex)
				{
					Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, "JSON validation failed");
					return false;
				}
				catch (Exception ex2)
				{
					Interaction.MsgBox(ex2.ToString(), MsgBoxStyle.Exclamation, "JSON validation failed");
					return false;
				}
			}
			return false;
		}

		// Token: 0x0400020E RID: 526
		public string fname;
	}
}
