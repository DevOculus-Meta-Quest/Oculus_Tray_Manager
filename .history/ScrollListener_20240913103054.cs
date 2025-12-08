// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.ScrollListener
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
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
        // ISSUE: reference to a compiler-generated field
        ScrollListener.MyScrollEventHandler scrollEvent = this.MyScrollEvent;
        if (scrollEvent != null)
          scrollEvent((object) this.ctrl, new EventArgs());
      }
      base.WndProc(ref m);
    }

    ~ScrollListener()
    {
      this.ReleaseHandle();
      // ISSUE: explicit finalizer call
      base.Finalize();
    }

    public delegate void MyScrollEventHandler(object sender, EventArgs e);
  }
}
