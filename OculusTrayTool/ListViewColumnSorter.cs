using System;
using System.Collections;
using System.Windows.Forms;

namespace OculusTrayTool
{
	// Token: 0x0200000E RID: 14
	public class ListViewColumnSorter : IComparer
	{
		// Token: 0x0600016B RID: 363 RVA: 0x00006C26 File Offset: 0x00004E26
		public ListViewColumnSorter()
		{
			this.ColumnToSort = 0;
			this.OrderOfSort = SortOrder.None;
			this.ObjectCompare = new CaseInsensitiveComparer();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006C4C File Offset: 0x00004E4C
		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			int num = this.ObjectCompare.Compare(listViewItem.SubItems[this.ColumnToSort].Text, listViewItem2.SubItems[this.ColumnToSort].Text);
			bool flag = this.OrderOfSort == SortOrder.Ascending;
			int num2;
			if (flag)
			{
				num2 = num;
			}
			else
			{
				bool flag2 = this.OrderOfSort == SortOrder.Descending;
				if (flag2)
				{
					num2 = checked(0 - num);
				}
				else
				{
					num2 = 0;
				}
			}
			return num2;
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00006CD0 File Offset: 0x00004ED0
		// (set) Token: 0x0600016E RID: 366 RVA: 0x00006CE8 File Offset: 0x00004EE8
		public int SortColumn
		{
			get
			{
				return this.ColumnToSort;
			}
			set
			{
				this.ColumnToSort = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00006CF4 File Offset: 0x00004EF4
		// (set) Token: 0x06000170 RID: 368 RVA: 0x00006D0C File Offset: 0x00004F0C
		public SortOrder Order
		{
			get
			{
				return this.OrderOfSort;
			}
			set
			{
				this.OrderOfSort = value;
			}
		}

		// Token: 0x0400001B RID: 27
		private int ColumnToSort;

		// Token: 0x0400001C RID: 28
		private SortOrder OrderOfSort;

		// Token: 0x0400001D RID: 29
		private CaseInsensitiveComparer ObjectCompare;
	}
}
