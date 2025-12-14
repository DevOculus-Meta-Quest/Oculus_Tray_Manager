
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool
{
  public class TextProgressBar : ProgressBar
  {
    public TextProgressBar()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle clientRectangle = this.ClientRectangle;
      Graphics graphics = e.Graphics;
      ProgressBarRenderer.DrawHorizontalBar(graphics, clientRectangle);
      clientRectangle.Inflate(-3, -3);
      if (this.Value > 0)
      {
        Rectangle bounds = new Rectangle(clientRectangle.X, clientRectangle.Y, checked ((int) Math.Round(unchecked ((double) this.Value / (double) this.Maximum * (double) clientRectangle.Width))), clientRectangle.Height);
        ProgressBarRenderer.DrawHorizontalChunks(graphics, bounds);
      }
      using (Font font = new Font(FontFamily.GenericSansSerif, 10f))
      {
        SizeF sizeF = graphics.MeasureString(this.Message, font);
        Point point = new Point(checked ((int) Math.Round(unchecked ((double) this.Width / 2.0 - (double) sizeF.Width / 2.0))), checked ((int) Math.Round(unchecked ((double) this.Height / 2.0 - (double) sizeF.Height / 2.0))));
        graphics.DrawString(this.Message, font, Brushes.Black, (PointF) point);
      }
    }

    public string Message { get; set; }
  }
}
