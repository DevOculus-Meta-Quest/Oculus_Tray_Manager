// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.LVsort
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class LVsort
  {
    public class ListViewItemComparer : IComparer
    {
      private int col;
      private SortOrder order;

      public ListViewItemComparer()
      {
        this.col = 0;
        this.order = SortOrder.Ascending;
      }

      public ListViewItemComparer(int column, SortOrder order)
      {
        this.col = column;
        this.order = order;
      }

      public int Compare(object x, object y)
      {
        int num = string.Compare(((ListViewItem) x).SubItems[this.col].Text, ((ListViewItem) y).SubItems[this.col].Text);
        if (this.order == SortOrder.Descending)
          checked { num *= -1; }
        return num;
      }
    }
  }
}
