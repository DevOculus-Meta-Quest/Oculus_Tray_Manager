using System;
using System.Drawing;
using System.Windows.Forms;

namespace OculusTrayTool;

public class TextProgressBar : ProgressBar
{
	public string Message { get; set; }

	public TextProgressBar()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Rectangle clientRectangle = base.ClientRectangle;
		Graphics graphics = e.Graphics;
		ProgressBarRenderer.DrawHorizontalBar(graphics, clientRectangle);
		clientRectangle.Inflate(-3, -3);
		checked
		{
			if (base.Value > 0)
			{
				Rectangle bounds = new Rectangle(clientRectangle.X, clientRectangle.Y, (int)Math.Round((float)base.Value / (float)base.Maximum * (float)clientRectangle.Width), clientRectangle.Height);
				ProgressBarRenderer.DrawHorizontalChunks(graphics, bounds);
			}
			using Font font = new Font(FontFamily.GenericSansSerif, 10f);
			SizeF sizeF = graphics.MeasureString(Message, font);
			Point point = new Point((int)Math.Round((double)base.Width / 2.0 - (double)(sizeF.Width / 2f)), (int)Math.Round((double)base.Height / 2.0 - (double)(sizeF.Height / 2f)));
			graphics.DrawString(Message, font, Brushes.Black, point);
		}
	}
}
