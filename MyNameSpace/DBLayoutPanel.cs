// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.MyNameSpace.DBLayoutPanel
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

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
