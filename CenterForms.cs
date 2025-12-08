// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.CenterForms
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class CenterForms
  {
    public static void CenterForm(Form frm, Form parent = null)
    {
      Rectangle rectangle = parent == null ? Screen.FromPoint(frm.Location).WorkingArea : parent.RectangleToScreen(parent.ClientRectangle);
      int x = checked (rectangle.Left + unchecked (checked (rectangle.Width - frm.Width) / 2));
      int y = checked (rectangle.Top + unchecked (checked (rectangle.Height - frm.Height) / 2));
      frm.Location = new Point(x, y);
    }
  }
}
