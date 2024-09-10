using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[StandardModule]
internal sealed class LVsort
{
	public class ListViewItemComparer : IComparer
	{
		private int col;

		private SortOrder order;

		public ListViewItemComparer()
		{
			col = 0;
			order = SortOrder.Ascending;
		}

		public ListViewItemComparer(int column, SortOrder order)
		{
			col = column;
			this.order = order;
		}

		public int Compare(object x, object y)
		{
			int num = -1;
			num = string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
			if (order == SortOrder.Descending)
			{
				num = checked(num * -1);
			}
			return num;
		}

		int IComparer.Compare(object x, object y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Compare
			return this.Compare(x, y);
		}
	}
}
