
using System;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool
{
  public class ScrollListener : NativeWindow
  {
    private const int WM_MOUSEACTIVATE = 33;
    private const int WM_MOUSEMOVE = 512;
    private Control ctrl;

    public event ScrollListener.MyScrollEventHandler MyScroll;

    public ScrollListener(Control ctrl) => this.AssignHandle(ctrl.Handle);

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 276 | m.Msg == 277)
      {
        ScrollListener.MyScrollEventHandler scrollEvent = this.MyScroll;
        if (scrollEvent != null)
          scrollEvent((object) this.ctrl, new EventArgs());
      }
      base.WndProc(ref m);
    }

    ~ScrollListener()
    {
      this.ReleaseHandle();
    }

    public delegate void MyScrollEventHandler(object sender, EventArgs e);
  }
}
