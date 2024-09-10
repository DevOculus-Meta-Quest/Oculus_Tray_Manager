using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000012 RID: 18
	[DesignerGenerated]
	public class ToolStripSpringTextBox : CueToolStripTextBox
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00006FED File Offset: 0x000051ED
		public ToolStripSpringTextBox()
		{
			this.components = null;
			this.InitializeComponent();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00007004 File Offset: 0x00005204
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000703B File Offset: 0x0000523B
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000704C File Offset: 0x0000524C
		public override Size GetPreferredSize(Size constrainingSize)
		{
			bool flag = base.IsOnOverflow || base.Owner.Orientation == Orientation.Vertical;
			checked
			{
				Size size;
				if (flag)
				{
					size = this.DefaultSize;
				}
				else
				{
					int num = base.Owner.DisplayRectangle.Width;
					bool visible = base.Owner.OverflowButton.Visible;
					if (visible)
					{
						num = num - base.Owner.OverflowButton.Width - base.Owner.OverflowButton.Margin.Horizontal;
					}
					int num2 = 0;
					try
					{
						foreach (object obj in base.Owner.Items)
						{
							ToolStripItem toolStripItem = (ToolStripItem)obj;
							bool isOnOverflow = toolStripItem.IsOnOverflow;
							if (!isOnOverflow)
							{
								bool flag2 = toolStripItem is ToolStripSpringTextBox;
								if (flag2)
								{
									num2++;
									num -= toolStripItem.Margin.Horizontal;
								}
								else
								{
									num = num - toolStripItem.Width - toolStripItem.Margin.Horizontal;
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					bool flag3 = num2 > 1;
					if (flag3)
					{
						num = (int)Math.Round((double)num / (double)num2);
					}
					bool flag4 = num < this.DefaultSize.Width;
					if (flag4)
					{
						num = this.DefaultSize.Width;
					}
					Size preferredSize = base.GetPreferredSize(constrainingSize);
					preferredSize.Width = num - 8;
					size = preferredSize;
				}
				return size;
			}
		}

		// Token: 0x04000020 RID: 32
		private IContainer components;
	}
}
