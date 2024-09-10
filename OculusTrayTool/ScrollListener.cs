using System;
using System.Windows.Forms;

namespace OculusTrayTool;

public class ScrollListener : NativeWindow
{
	public delegate void MyScrollEventHandler(object sender, EventArgs e);

	private const int WM_MOUSEACTIVATE = 33;

	private const int WM_MOUSEMOVE = 512;

	private Control ctrl;

	public event MyScrollEventHandler MyScroll;

	public ScrollListener(Control ctrl)
	{
		AssignHandle(ctrl.Handle);
	}

	protected override void WndProc(ref Message m)
	{
		if ((m.Msg == 276) | (m.Msg == 277))
		{
			MyScroll?.Invoke(ctrl, new EventArgs());
		}
		base.WndProc(ref m);
	}

	~ScrollListener()
	{
		ReleaseHandle();
		base.Finalize();
	}
}
