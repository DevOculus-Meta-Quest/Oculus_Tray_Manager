// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.DotNetBarTabcontrol
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  internal class DotNetBarTabcontrol : TabControl
  {
    public DotNetBarTabcontrol()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      this.DoubleBuffered = true;
      this.SizeMode = TabSizeMode.Fixed;
      this.ItemSize = new Size(43, 135);
    }

    protected override void CreateHandle()
    {
      base.CreateHandle();
      this.Alignment = TabAlignment.Left;
    }

    public Pen ToPen(Color color) => new Pen(color);

    public Brush ToBrush(Color color) => (Brush) new SolidBrush(color);

    protected override void OnPaint(PaintEventArgs e)
    {
      Bitmap bitmap = new Bitmap(this.Width, this.Height);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap);
      try
      {
        this.SelectedTab.BackColor = Color.White;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      graphics1.Clear(Color.White);
      graphics1.FillRectangle((Brush) new SolidBrush(Color.FromArgb(246, 248, 252)), new Rectangle(0, 0, checked (this.ItemSize.Height + 4), this.Height));
      graphics1.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(checked (this.ItemSize.Height + 3), 0), new Point(checked (this.ItemSize.Height + 3), 999));
      int num = checked (this.TabCount - 1);
      int index = 0;
      while (index <= num)
      {
        Point location1;
        if (index == this.SelectedIndex)
        {
          Rectangle rectangle;
          ref Rectangle local = ref rectangle;
          location1 = this.GetTabRect(index).Location;
          int x1 = checked (location1.X - 2);
          location1 = this.GetTabRect(index).Location;
          int y1 = checked (location1.Y - 2);
          Point location2 = new Point(x1, y1);
          Size size = new Size(checked (this.GetTabRect(index).Width + 3), checked (this.GetTabRect(index).Height - 1));
          local = new Rectangle(location2, size);
          graphics1.FillRectangle((Brush) new LinearGradientBrush(rectangle, Color.Black, Color.Black, 90f)
          {
            InterpolationColors = new ColorBlend()
            {
              Colors = new Color[3]
              {
                Color.FromArgb(232, 232, 240),
                Color.FromArgb(232, 232, 240),
                Color.FromArgb(232, 232, 240)
              },
              Positions = new float[3]{ 0.0f, 0.5f, 1f }
            }
          }, rectangle);
          graphics1.DrawRectangle(new Pen(Color.FromArgb(170, 187, 204)), rectangle);
          graphics1.SmoothingMode = SmoothingMode.HighQuality;
          Point[] pointArray = new Point[3];
          int x2 = checked (this.ItemSize.Height - 3);
          location1 = this.GetTabRect(index).Location;
          int y2 = checked (location1.Y + 20);
          pointArray[0] = new Point(x2, y2);
          int x3 = checked (this.ItemSize.Height + 4);
          location1 = this.GetTabRect(index).Location;
          int y3 = checked (location1.Y + 14);
          pointArray[1] = new Point(x3, y3);
          int x4 = checked (this.ItemSize.Height + 4);
          location1 = this.GetTabRect(index).Location;
          int y4 = checked (location1.Y + 27);
          pointArray[2] = new Point(x4, y4);
          Point[] points = pointArray;
          graphics1.FillPolygon(Brushes.White, points);
          graphics1.DrawPolygon(new Pen(Color.FromArgb(170, 187, 204)), points);
          if (this.ImageList != null)
          {
            try
            {
              if (this.ImageList.Images[this.TabPages[index].ImageIndex] != null)
              {
                Graphics graphics2 = graphics1;
                Image image = this.ImageList.Images[this.TabPages[index].ImageIndex];
                location1 = rectangle.Location;
                int x5 = checked (location1.X + 8);
                location1 = rectangle.Location;
                int y5 = checked (location1.Y + 14);
                Point point = new Point(x5, y5);
                graphics2.DrawImage(image, point);
                graphics1.DrawString("      " + this.TabPages[index].Text, this.Font, Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
                {
                  LineAlignment = StringAlignment.Center,
                  Alignment = StringAlignment.Center
                });
              }
              else
                graphics1.DrawString(this.TabPages[index].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
                {
                  LineAlignment = StringAlignment.Center,
                  Alignment = StringAlignment.Center
                });
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              graphics1.DrawString(this.TabPages[index].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
              {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
              });
              ProjectData.ClearProjectError();
            }
          }
          else
            graphics1.DrawString(this.TabPages[index].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
            {
              LineAlignment = StringAlignment.Center,
              Alignment = StringAlignment.Center
            });
          Graphics graphics3 = graphics1;
          Pen pen1 = new Pen(Color.FromArgb(200, 200, 250));
          location1 = rectangle.Location;
          int x6 = checked (location1.X - 1);
          location1 = rectangle.Location;
          int y6 = checked (location1.Y - 1);
          Point pt1_1 = new Point(x6, y6);
          location1 = rectangle.Location;
          int x7 = location1.X;
          location1 = rectangle.Location;
          int y7 = location1.Y;
          Point pt2_1 = new Point(x7, y7);
          graphics3.DrawLine(pen1, pt1_1, pt2_1);
          Graphics graphics4 = graphics1;
          Pen pen2 = new Pen(Color.FromArgb(200, 200, 250));
          location1 = rectangle.Location;
          Point pt1_2 = new Point(checked (location1.X - 1), checked (rectangle.Bottom - 1));
          location1 = rectangle.Location;
          Point pt2_2 = new Point(location1.X, rectangle.Bottom);
          graphics4.DrawLine(pen2, pt1_2, pt2_2);
        }
        else
        {
          Rectangle rectangle;
          ref Rectangle local = ref rectangle;
          Rectangle tabRect = this.GetTabRect(index);
          location1 = tabRect.Location;
          int x8 = checked (location1.X - 2);
          tabRect = this.GetTabRect(index);
          location1 = tabRect.Location;
          int y8 = checked (location1.Y - 2);
          Point location3 = new Point(x8, y8);
          tabRect = this.GetTabRect(index);
          int width = checked (tabRect.Width + 3);
          tabRect = this.GetTabRect(index);
          int height = checked (tabRect.Height + 1);
          Size size = new Size(width, height);
          local = new Rectangle(location3, size);
          graphics1.FillRectangle((Brush) new SolidBrush(Color.FromArgb(246, 248, 252)), rectangle);
          graphics1.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(rectangle.Right, rectangle.Top), new Point(rectangle.Right, rectangle.Bottom));
          if (this.ImageList != null)
          {
            try
            {
              if (this.ImageList.Images[this.TabPages[index].ImageIndex] != null)
              {
                Graphics graphics5 = graphics1;
                Image image = this.ImageList.Images[this.TabPages[index].ImageIndex];
                location1 = rectangle.Location;
                int x9 = checked (location1.X + 8);
                location1 = rectangle.Location;
                int y9 = checked (location1.Y + 14);
                Point point = new Point(x9, y9);
                graphics5.DrawImage(image, point);
                graphics1.DrawString("      " + this.TabPages[index].Text, this.Font, Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
                {
                  LineAlignment = StringAlignment.Center,
                  Alignment = StringAlignment.Center
                });
              }
              else
                graphics1.DrawString(this.TabPages[index].Text, this.Font, Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
                {
                  LineAlignment = StringAlignment.Center,
                  Alignment = StringAlignment.Center
                });
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              graphics1.DrawString(this.TabPages[index].Text, this.Font, Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
              {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
              });
              ProjectData.ClearProjectError();
            }
          }
          else
            graphics1.DrawString(this.TabPages[index].Text, this.Font, Brushes.DimGray, (RectangleF) rectangle, new StringFormat()
            {
              LineAlignment = StringAlignment.Center,
              Alignment = StringAlignment.Center
            });
        }
        checked { ++index; }
      }
      NewLateBinding.LateCall((object) e.Graphics, (Type) null, "DrawImage", new object[3]
      {
        bitmap.Clone(),
        (object) 0,
        (object) 0
      }, (string[]) null, (Type[]) null, (bool[]) null, true);
      graphics1.Dispose();
      bitmap.Dispose();
    }
  }
}
