// Decompiled with JetBrains decompiler

using System.Collections;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  public class ListViewColumnSorter : IComparer
  {
    private int ColumnToSort;
    private SortOrder OrderOfSort;
    private CaseInsensitiveComparer ObjectCompare;

    public ListViewColumnSorter()
    {
      this.ColumnToSort = 0;
      this.OrderOfSort = SortOrder.None;
      this.ObjectCompare = new CaseInsensitiveComparer();
    }

    public int Compare(object x, object y)
    {
      int num = this.ObjectCompare.Compare((object) ((ListViewItem) x).SubItems[this.ColumnToSort].Text, (object) ((ListViewItem) y).SubItems[this.ColumnToSort].Text);
      if (this.OrderOfSort == SortOrder.Ascending)
        return num;
      return this.OrderOfSort == SortOrder.Descending ? checked (-num) : 0;
    }

    public int SortColumn
    {
      get => this.ColumnToSort;
      set => this.ColumnToSort = value;
    }

    public SortOrder Order
    {
      get => this.OrderOfSort;
      set => this.OrderOfSort = value;
    }
  }
}
