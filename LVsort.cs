// Decompiled with JetBrains decompiler

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
