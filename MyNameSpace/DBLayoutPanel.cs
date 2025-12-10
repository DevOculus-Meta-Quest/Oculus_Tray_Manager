// Decompiled with JetBrains decompiler

using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool.MyNameSpace
{
  public class DBLayoutPanel : TableLayoutPanel
  {
    public DBLayoutPanel()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    public DBLayoutPanel(IContainer container)
    {
      container.Add((IComponent) this);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }
  }
}
