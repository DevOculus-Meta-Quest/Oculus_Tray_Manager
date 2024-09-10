using System;
using System.Drawing;
using System.Windows.Forms;

namespace OculusTrayTool
{
	// Token: 0x02000010 RID: 16
	public class TextProgressBar : ProgressBar
	{
		// Token: 0x06000173 RID: 371 RVA: 0x00006D30 File Offset: 0x00004F30
		public TextProgressBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006D48 File Offset: 0x00004F48
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			Graphics graphics = e.Graphics;
			ProgressBarRenderer.DrawHorizontalBar(graphics, clientRectangle);
			clientRectangle.Inflate(-3, -3);
			bool flag = base.Value > 0;
			checked
			{
				if (flag)
				{
					Rectangle rectangle = new Rectangle(clientRectangle.X, clientRectangle.Y, (int)Math.Round((double)(unchecked((float)base.Value / (float)base.Maximum * (float)clientRectangle.Width))), clientRectangle.Height);
					ProgressBarRenderer.DrawHorizontalChunks(graphics, rectangle);
				}
				using (Font font = new Font(FontFamily.GenericSansSerif, 10f))
				{
					SizeF sizeF = graphics.MeasureString(this.Message, font);
					Point point = new Point((int)Math.Round(unchecked((double)base.Width / 2.0 - (double)(sizeF.Width / 2f))), (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)(sizeF.Height / 2f))));
					graphics.DrawString(this.Message, font, Brushes.Black, point);
				}
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00006E7C File Offset: 0x0000507C
		// (set) Token: 0x06000176 RID: 374 RVA: 0x00006E86 File Offset: 0x00005086
		public string Message { get; set; }
	}
}
