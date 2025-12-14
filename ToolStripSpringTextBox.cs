using System.Windows.Forms.Layout;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


#nullable disable
namespace OculusTrayTool
{
  public partial class ToolStripSpringTextBox : CueToolStripTextBox
  {
    

    public ToolStripSpringTextBox() : base("ToolStripSpringTextBox")
    {
      this.components = (IContainer) null;
      this.InitializeComponent();
    }

    

    
  
        public override Size GetPreferredSize(Size constrainingSize)
        {
            if (this.IsOnOverflow || this.Owner.Orientation == Orientation.Vertical)
                return this.DefaultSize;
                
            int width = this.Owner.DisplayRectangle.Width;
            if (this.Owner.OverflowButton.Visible)
            {
                width = width - this.Owner.OverflowButton.Width - this.Owner.OverflowButton.Margin.Horizontal;
            }
            
            int springCount = 0;
            foreach (ToolStripItem item in this.Owner.Items)
            {
                if (item.IsOnOverflow) continue;
                if (item is ToolStripSpringTextBox)
                {
                    springCount++;
                    width -= item.Margin.Horizontal;
                }
                else
                {
                    width = width - item.Width - item.Margin.Horizontal;
                }
            }
            
            if (springCount > 1)
                width /= springCount;
                
            if (width < this.DefaultSize.Width)
                width = this.DefaultSize.Width;
                
            return new Size(width, this.DefaultSize.Height);
        }
    
}
}