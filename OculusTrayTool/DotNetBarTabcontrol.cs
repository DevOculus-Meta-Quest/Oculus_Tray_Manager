using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

internal class DotNetBarTabcontrol : TabControl
{
	public DotNetBarTabcontrol()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
		DoubleBuffered = true;
		base.SizeMode = TabSizeMode.Fixed;
		base.ItemSize = new Size(43, 135);
	}

	protected override void CreateHandle()
	{
		base.CreateHandle();
		base.Alignment = TabAlignment.Left;
	}

	public Pen ToPen(Color color)
	{
		return new Pen(color);
	}

	public Brush ToBrush(Color color)
	{
		return new SolidBrush(color);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Bitmap bitmap = new Bitmap(base.Width, base.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		try
		{
			base.SelectedTab.BackColor = Color.White;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		graphics.Clear(Color.White);
		checked
		{
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)), new Rectangle(0, 0, base.ItemSize.Height + 4, base.Height));
			graphics.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(base.ItemSize.Height + 3, 0), new Point(base.ItemSize.Height + 3, 999));
			int num = base.TabCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (i == base.SelectedIndex)
				{
					Rectangle rectangle = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
					ColorBlend colorBlend = new ColorBlend();
					colorBlend.Colors = new Color[3]
					{
						Color.FromArgb(232, 232, 240),
						Color.FromArgb(232, 232, 240),
						Color.FromArgb(232, 232, 240)
					};
					colorBlend.Positions = new float[3] { 0f, 0.5f, 1f };
					LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.Black, Color.Black, 90f);
					linearGradientBrush.InterpolationColors = colorBlend;
					graphics.FillRectangle(linearGradientBrush, rectangle);
					graphics.DrawRectangle(new Pen(Color.FromArgb(170, 187, 204)), rectangle);
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					Point[] points = new Point[3]
					{
						new Point(base.ItemSize.Height - 3, GetTabRect(i).Location.Y + 20),
						new Point(base.ItemSize.Height + 4, GetTabRect(i).Location.Y + 14),
						new Point(base.ItemSize.Height + 4, GetTabRect(i).Location.Y + 27)
					};
					graphics.FillPolygon(Brushes.White, points);
					graphics.DrawPolygon(new Pen(Color.FromArgb(170, 187, 204)), points);
					if (base.ImageList != null)
					{
						try
						{
							if (base.ImageList.Images[base.TabPages[i].ImageIndex] != null)
							{
								graphics.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle.Location.X + 8, rectangle.Location.Y + 14));
								graphics.DrawString("      " + base.TabPages[i].Text, Font, Brushes.DimGray, rectangle, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
							else
							{
								graphics.DrawString(base.TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.DimGray, rectangle, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							graphics.DrawString(base.TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.DimGray, rectangle, new StringFormat
							{
								LineAlignment = StringAlignment.Center,
								Alignment = StringAlignment.Center
							});
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						graphics.DrawString(base.TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.DimGray, rectangle, new StringFormat
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Center
						});
					}
					graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 250)), new Point(rectangle.Location.X - 1, rectangle.Location.Y - 1), new Point(rectangle.Location.X, rectangle.Location.Y));
					graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 250)), new Point(rectangle.Location.X - 1, rectangle.Bottom - 1), new Point(rectangle.Location.X, rectangle.Bottom));
					continue;
				}
				Rectangle rectangle2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height + 1));
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)), rectangle2);
				graphics.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(rectangle2.Right, rectangle2.Top), new Point(rectangle2.Right, rectangle2.Bottom));
				if (base.ImageList != null)
				{
					try
					{
						if (base.ImageList.Images[base.TabPages[i].ImageIndex] != null)
						{
							graphics.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 14));
							graphics.DrawString("      " + base.TabPages[i].Text, Font, Brushes.DimGray, rectangle2, new StringFormat
							{
								LineAlignment = StringAlignment.Center,
								Alignment = StringAlignment.Center
							});
						}
						else
						{
							graphics.DrawString(base.TabPages[i].Text, Font, Brushes.DimGray, rectangle2, new StringFormat
							{
								LineAlignment = StringAlignment.Center,
								Alignment = StringAlignment.Center
							});
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						graphics.DrawString(base.TabPages[i].Text, Font, Brushes.DimGray, rectangle2, new StringFormat
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Center
						});
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					graphics.DrawString(base.TabPages[i].Text, Font, Brushes.DimGray, rectangle2, new StringFormat
					{
						LineAlignment = StringAlignment.Center,
						Alignment = StringAlignment.Center
					});
				}
			}
			NewLateBinding.LateCall(e.Graphics, null, "DrawImage", new object[3]
			{
				bitmap.Clone(),
				0,
				0
			}, null, null, null, IgnoreReturn: true);
			graphics.Dispose();
			bitmap.Dispose();
		}
	}
}
