using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[DesignerGenerated]
public class ToolStripSpringTextBox : CueToolStripTextBox
{
	private IContainer components;

	public ToolStripSpringTextBox()
	{
		components = null;
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		components = new Container();
	}

	public override Size GetPreferredSize(Size constrainingSize)
	{
		if (base.IsOnOverflow || base.Owner.Orientation == Orientation.Vertical)
		{
			return DefaultSize;
		}
		int num = base.Owner.DisplayRectangle.Width;
		checked
		{
			if (base.Owner.OverflowButton.Visible)
			{
				num = num - base.Owner.OverflowButton.Width - base.Owner.OverflowButton.Margin.Horizontal;
			}
			int num2 = 0;
			foreach (ToolStripItem item in base.Owner.Items)
			{
				if (!item.IsOnOverflow)
				{
					if (item is ToolStripSpringTextBox)
					{
						num2++;
						num -= item.Margin.Horizontal;
					}
					else
					{
						num = num - item.Width - item.Margin.Horizontal;
					}
				}
			}
			if (num2 > 1)
			{
				num = (int)Math.Round((double)num / (double)num2);
			}
			if (num < DefaultSize.Width)
			{
				num = DefaultSize.Width;
			}
			Size preferredSize = base.GetPreferredSize(constrainingSize);
			preferredSize.Width = num - 8;
			return preferredSize;
		}
	}
}
