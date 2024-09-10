using System;
using System.Windows.Forms;

namespace OculusTrayTool
{
	// Token: 0x02000049 RID: 73
	public class ScrollListener : NativeWindow
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600058F RID: 1423 RVA: 0x0002D6F4 File Offset: 0x0002B8F4
		// (remove) Token: 0x06000590 RID: 1424 RVA: 0x0002D72C File Offset: 0x0002B92C
		public event ScrollListener.MyScrollEventHandler MyScroll;

		// Token: 0x06000591 RID: 1425 RVA: 0x0002D761 File Offset: 0x0002B961
		public ScrollListener(Control ctrl)
		{
			base.AssignHandle(ctrl.Handle);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0002D778 File Offset: 0x0002B978
		protected override void WndProc(ref Message m)
		{
			bool flag = (m.Msg == 276) | (m.Msg == 277);
			if (flag)
			{
				ScrollListener.MyScrollEventHandler myScrollEvent = this.MyScrollEvent;
				if (myScrollEvent != null)
				{
					myScrollEvent(this.ctrl, new EventArgs());
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0002D7CB File Offset: 0x0002B9CB
		protected override void Finalize()
		{
			this.ReleaseHandle();
			base.Finalize();
		}

		// Token: 0x0400023B RID: 571
		private const int WM_MOUSEACTIVATE = 33;

		// Token: 0x0400023C RID: 572
		private const int WM_MOUSEMOVE = 512;

		// Token: 0x0400023D RID: 573
		private Control ctrl;

		// Token: 0x02000085 RID: 133
		// (Invoke) Token: 0x06000A53 RID: 2643
		public delegate void MyScrollEventHandler(object sender, EventArgs e);
	}
}
