// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.ToolStripSpringTextBox
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class ToolStripSpringTextBox : CueToolStripTextBox
  {
    private IContainer components;

    public ToolStripSpringTextBox()
    {
      this.components = (IContainer) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent() => this.components = (IContainer) new System.ComponentModel.Container();

    public override Size GetPreferredSize(Size constrainingSize)
    {
      if (this.IsOnOverflow || this.Owner.Orientation == Orientation.Vertical)
        return this.DefaultSize;
      int num1 = this.Owner.DisplayRectangle.Width;
      Padding margin;
      if (this.Owner.OverflowButton.Visible)
      {
        int num2 = checked (num1 - this.Owner.OverflowButton.Width);
        margin = this.Owner.OverflowButton.Margin;
        int horizontal = margin.Horizontal;
        num1 = checked (num2 - horizontal);
      }
      int num3 = 0;
      try
      {
        foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.Owner.Items)
        {
          if (!toolStripItem.IsOnOverflow)
          {
            if (toolStripItem is ToolStripSpringTextBox)
            {
              checked { ++num3; }
              int num4 = num1;
              margin = toolStripItem.Margin;
              int horizontal = margin.Horizontal;
              num1 = checked (num4 - horizontal);
            }
            else
            {
              int num5 = checked (num1 - toolStripItem.Width);
              margin = toolStripItem.Margin;
              int horizontal = margin.Horizontal;
              num1 = checked (num5 - horizontal);
            }
          }
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (num3 > 1)
        num1 = checked ((int) Math.Round(unchecked ((double) num1 / (double) num3)));
      int num6 = num1;
      Size defaultSize = this.DefaultSize;
      int width = defaultSize.Width;
      if (num6 < width)
      {
        defaultSize = this.DefaultSize;
        num1 = defaultSize.Width;
      }
      return base.GetPreferredSize(constrainingSize) with
      {
        Width = checked (num1 - 8)
      };
    }
  }
}
