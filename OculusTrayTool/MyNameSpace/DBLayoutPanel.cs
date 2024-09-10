using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OculusTrayTool.MyNameSpace
{
	// Token: 0x0200001B RID: 27
	public class DBLayoutPanel : TableLayoutPanel
	{
		// Token: 0x0600024E RID: 590 RVA: 0x0000C6D6 File Offset: 0x0000A8D6
		public DBLayoutPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000C6ED File Offset: 0x0000A8ED
		public DBLayoutPanel(IContainer container)
		{
			container.Add(this);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
