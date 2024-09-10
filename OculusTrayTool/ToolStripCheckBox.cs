using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OculusTrayTool
{
	// Token: 0x02000011 RID: 17
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
	public class ToolStripCheckBox : MyCustomToolStripControlHost
	{
		// Token: 0x06000177 RID: 375 RVA: 0x00006E8F File Offset: 0x0000508F
		public ToolStripCheckBox()
			: base(new CheckBox())
		{
			this.BackColor = Color.Transparent;
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00006EAC File Offset: 0x000050AC
		public CheckBox CheckBoxControl
		{
			get
			{
				return base.Control as CheckBox;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00006ECC File Offset: 0x000050CC
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00006EE9 File Offset: 0x000050E9
		public bool Checked
		{
			get
			{
				return this.CheckBoxControl.Checked;
			}
			set
			{
				this.CheckBoxControl.Checked = value;
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006EFC File Offset: 0x000050FC
		protected override void OnSubscribeControlEvents(Control c)
		{
			base.OnSubscribeControlEvents(c);
			CheckBox checkBox = (CheckBox)c;
			checkBox.CheckedChanged += this.OnCheckedChanged;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006F2C File Offset: 0x0000512C
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			base.OnUnsubscribeControlEvents(c);
			CheckBox checkBox = (CheckBox)c;
			checkBox.CheckedChanged -= this.OnCheckedChanged;
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600017D RID: 381 RVA: 0x00006F5C File Offset: 0x0000515C
		// (remove) Token: 0x0600017E RID: 382 RVA: 0x00006F94 File Offset: 0x00005194
		public event EventHandler CheckedChanged;

		// Token: 0x0600017F RID: 383 RVA: 0x00006FCC File Offset: 0x000051CC
		private void OnCheckedChanged(object sender, EventArgs e)
		{
			EventHandler checkedChangedEvent = this.CheckedChangedEvent;
			if (checkedChangedEvent != null)
			{
				checkedChangedEvent(this, e);
			}
		}
	}
}
