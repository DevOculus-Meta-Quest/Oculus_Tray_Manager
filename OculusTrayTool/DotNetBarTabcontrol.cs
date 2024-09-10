using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x0200001D RID: 29
	internal class DotNetBarTabcontrol : TabControl
	{
		// Token: 0x06000274 RID: 628 RVA: 0x0000D459 File Offset: 0x0000B659
		public DotNetBarTabcontrol()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			this.DoubleBuffered = true;
			base.SizeMode = TabSizeMode.Fixed;
			base.ItemSize = new Size(43, 135);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000D493 File Offset: 0x0000B693
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Alignment = TabAlignment.Left;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000D4A8 File Offset: 0x0000B6A8
		public Pen ToPen(Color color)
		{
			return new Pen(color);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000D4C0 File Offset: 0x0000B6C0
		public Brush ToBrush(Color color)
		{
			return new SolidBrush(color);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000D4D8 File Offset: 0x0000B6D8
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			try
			{
				base.SelectedTab.BackColor = Color.White;
			}
			catch (Exception ex)
			{
			}
			graphics.Clear(Color.White);
			checked
			{
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)), new Rectangle(0, 0, base.ItemSize.Height + 4, base.Height));
				graphics.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(base.ItemSize.Height + 3, 0), new Point(base.ItemSize.Height + 3, 999));
				int num = base.TabCount - 1;
				for (int i = 0; i <= num; i++)
				{
					bool flag = i == base.SelectedIndex;
					if (flag)
					{
						Rectangle rectangle = new Rectangle(new Point(base.GetTabRect(i).Location.X - 2, base.GetTabRect(i).Location.Y - 2), new Size(base.GetTabRect(i).Width + 3, base.GetTabRect(i).Height - 1));
						ColorBlend colorBlend = new ColorBlend();
						colorBlend.Colors = new Color[]
						{
							Color.FromArgb(232, 232, 240),
							Color.FromArgb(232, 232, 240),
							Color.FromArgb(232, 232, 240)
						};
						colorBlend.Positions = new float[] { 0f, 0.5f, 1f };
						graphics.FillRectangle(new LinearGradientBrush(rectangle, Color.Black, Color.Black, 90f)
						{
							InterpolationColors = colorBlend
						}, rectangle);
						graphics.DrawRectangle(new Pen(Color.FromArgb(170, 187, 204)), rectangle);
						graphics.SmoothingMode = SmoothingMode.HighQuality;
						Point[] array = new Point[]
						{
							new Point(base.ItemSize.Height - 3, base.GetTabRect(i).Location.Y + 20),
							new Point(base.ItemSize.Height + 4, base.GetTabRect(i).Location.Y + 14),
							new Point(base.ItemSize.Height + 4, base.GetTabRect(i).Location.Y + 27)
						};
						graphics.FillPolygon(Brushes.White, array);
						graphics.DrawPolygon(new Pen(Color.FromArgb(170, 187, 204)), array);
						bool flag2 = base.ImageList != null;
						if (flag2)
						{
							try
							{
								bool flag3 = base.ImageList.Images[base.TabPages[i].ImageIndex] != null;
								if (flag3)
								{
									graphics.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle.Location.X + 8, rectangle.Location.Y + 14));
									graphics.DrawString("      " + base.TabPages[i].Text, this.Font, Brushes.DimGray, rectangle, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
								else
								{
									graphics.DrawString(base.TabPages[i].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.DimGray, rectangle, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
							}
							catch (Exception ex2)
							{
								graphics.DrawString(base.TabPages[i].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.DimGray, rectangle, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
						}
						else
						{
							graphics.DrawString(base.TabPages[i].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.DimGray, rectangle, new StringFormat
							{
								LineAlignment = StringAlignment.Center,
								Alignment = StringAlignment.Center
							});
						}
						graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 250)), new Point(rectangle.Location.X - 1, rectangle.Location.Y - 1), new Point(rectangle.Location.X, rectangle.Location.Y));
						graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 250)), new Point(rectangle.Location.X - 1, rectangle.Bottom - 1), new Point(rectangle.Location.X, rectangle.Bottom));
					}
					else
					{
						Rectangle rectangle2 = new Rectangle(new Point(base.GetTabRect(i).Location.X - 2, base.GetTabRect(i).Location.Y - 2), new Size(base.GetTabRect(i).Width + 3, base.GetTabRect(i).Height + 1));
						graphics.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)), rectangle2);
						graphics.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(rectangle2.Right, rectangle2.Top), new Point(rectangle2.Right, rectangle2.Bottom));
						bool flag4 = base.ImageList != null;
						if (flag4)
						{
							try
							{
								bool flag5 = base.ImageList.Images[base.TabPages[i].ImageIndex] != null;
								if (flag5)
								{
									graphics.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 14));
									graphics.DrawString("      " + base.TabPages[i].Text, this.Font, Brushes.DimGray, rectangle2, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
								else
								{
									graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.DimGray, rectangle2, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
							}
							catch (Exception ex3)
							{
								graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.DimGray, rectangle2, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
						}
						else
						{
							graphics.DrawString(base.TabPages[i].Text, this.Font, Brushes.DimGray, rectangle2, new StringFormat
							{
								LineAlignment = StringAlignment.Center,
								Alignment = StringAlignment.Center
							});
						}
					}
				}
				NewLateBinding.LateCall(e.Graphics, null, "DrawImage", new object[]
				{
					bitmap.Clone(),
					0,
					0
				}, null, null, null, true);
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
	}
}
