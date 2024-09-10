using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000051 RID: 81
	[StandardModule]
	internal sealed class LVsort
	{
		// Token: 0x02000095 RID: 149
		public class ListViewItemComparer : IComparer
		{
			// Token: 0x06000AF7 RID: 2807 RVA: 0x0005AFD6 File Offset: 0x000591D6
			public ListViewItemComparer()
			{
				this.col = 0;
				this.order = SortOrder.Ascending;
			}

			// Token: 0x06000AF8 RID: 2808 RVA: 0x0005AFEE File Offset: 0x000591EE
			public ListViewItemComparer(int column, SortOrder order)
			{
				this.col = column;
				this.order = order;
			}

			// Token: 0x06000AF9 RID: 2809 RVA: 0x0005B008 File Offset: 0x00059208
			public int Compare(object x, object y)
			{
				int num = string.Compare(((ListViewItem)x).SubItems[this.col].Text, ((ListViewItem)y).SubItems[this.col].Text);
				bool flag = this.order == SortOrder.Descending;
				checked
				{
					if (flag)
					{
						num *= -1;
					}
					return num;
				}
			}

			// Token: 0x04000522 RID: 1314
			private int col;

			// Token: 0x04000523 RID: 1315
			private SortOrder order;
		}
	}
}
