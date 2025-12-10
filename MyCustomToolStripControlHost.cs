// Decompiled with JetBrains decompiler

using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  public class MyCustomToolStripControlHost : ToolStripControlHost
  {
    public MyCustomToolStripControlHost()
      : base(new Control())
    {
    }

    public MyCustomToolStripControlHost(Control c)
      : base(c)
    {
    }
  }
}
