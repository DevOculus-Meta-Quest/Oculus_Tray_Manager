using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x0200000D RID: 13
	[DesignerGenerated]
	public class CueToolStripTextBox : ToolStripTextBox
	{
		// Token: 0x06000159 RID: 345 RVA: 0x000068B0 File Offset: 0x00004AB0
		// Note: this type is marked as 'beforefieldinit'.
		static CueToolStripTextBox()
		{
			checked
			{
				CueToolStripTextBox.EM_SETCUEBANNER = (uint)(unchecked((ulong)CueToolStripTextBox.ECM_FIRST) + 1UL);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000068CB File Offset: 0x00004ACB
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000068DC File Offset: 0x00004ADC
		public CueToolStripTextBox()
		{
			this.components = null;
			this.m_cueText = string.Empty;
			this.m_showCueTextWithFocus = false;
			bool flag = base.Control != null;
			if (flag)
			{
				base.Control.HandleCreated += this.OnControlHandleCreated;
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006934 File Offset: 0x00004B34
		public CueToolStripTextBox(string name)
			: base(name)
		{
			this.components = null;
			this.m_cueText = string.Empty;
			this.m_showCueTextWithFocus = false;
			bool flag = base.Control != null;
			if (flag)
			{
				base.Control.HandleCreated += this.OnControlHandleCreated;
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000698C File Offset: 0x00004B8C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				bool flag = base.Control != null;
				if (flag)
				{
					base.Control.HandleCreated -= this.OnControlHandleCreated;
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000069D0 File Offset: 0x00004BD0
		public void OnControlHandleCreated(object sender, EventArgs e)
		{
			this.UpdateCue();
		}

		// Token: 0x0600015F RID: 351
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, string lParam);

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000160 RID: 352 RVA: 0x000069DC File Offset: 0x00004BDC
		// (set) Token: 0x06000161 RID: 353 RVA: 0x000069F4 File Offset: 0x00004BF4
		[Description("The text value to be displayed as a cue to the user.")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string CueText
		{
			get
			{
				return this.m_cueText;
			}
			set
			{
				bool flag = value == null;
				if (flag)
				{
					value = string.Empty;
				}
				bool flag2 = !this.m_cueText.Equals(value, StringComparison.CurrentCulture);
				if (flag2)
				{
					this.m_cueText = value;
					this.UpdateCue();
					this.OnCueTextChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000162 RID: 354 RVA: 0x00006A44 File Offset: 0x00004C44
		// (remove) Token: 0x06000163 RID: 355 RVA: 0x00006A7C File Offset: 0x00004C7C
		public event EventHandler CueTextChanged;

		// Token: 0x06000164 RID: 356 RVA: 0x00006AB4 File Offset: 0x00004CB4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCueTextChanged(EventArgs e)
		{
			EventHandler cueTextChangedEvent = this.CueTextChangedEvent;
			if (cueTextChangedEvent != null)
			{
				cueTextChangedEvent(this, e);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006AD8 File Offset: 0x00004CD8
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00006AF0 File Offset: 0x00004CF0
		[Description("Indicates whether the CueText will be displayed even when the control has focus.")]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Localizable(true)]
		public bool ShowCueTextWithFocus
		{
			get
			{
				return this.m_showCueTextWithFocus;
			}
			set
			{
				bool flag = this.m_showCueTextWithFocus != value;
				if (flag)
				{
					this.m_showCueTextWithFocus = value;
					this.UpdateCue();
					this.OnShowCueTextWithFocusChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000167 RID: 359 RVA: 0x00006B2C File Offset: 0x00004D2C
		// (remove) Token: 0x06000168 RID: 360 RVA: 0x00006B64 File Offset: 0x00004D64
		public event EventHandler ShowCueTextWithFocusChanged;

		// Token: 0x06000169 RID: 361 RVA: 0x00006B9C File Offset: 0x00004D9C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnShowCueTextWithFocusChanged(EventArgs e)
		{
			EventHandler showCueTextWithFocusChangedEvent = this.ShowCueTextWithFocusChangedEvent;
			if (showCueTextWithFocusChangedEvent != null)
			{
				showCueTextWithFocusChangedEvent(this, e);
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00006BC0 File Offset: 0x00004DC0
		private void UpdateCue()
		{
			bool flag = base.Control != null && base.Control.IsHandleCreated;
			if (flag)
			{
				CueToolStripTextBox.SendMessage(new HandleRef(base.Control, base.Control.Handle), CueToolStripTextBox.EM_SETCUEBANNER, this.m_showCueTextWithFocus ? new IntPtr(1) : IntPtr.Zero, this.m_cueText);
			}
		}

		// Token: 0x04000014 RID: 20
		private IContainer components;

		// Token: 0x04000015 RID: 21
		private static uint ECM_FIRST = 5376U;

		// Token: 0x04000016 RID: 22
		private static uint EM_SETCUEBANNER;

		// Token: 0x04000017 RID: 23
		private string m_cueText;

		// Token: 0x04000019 RID: 25
		private bool m_showCueTextWithFocus;
	}
}
