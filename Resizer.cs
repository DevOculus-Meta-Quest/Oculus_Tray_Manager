// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Resizer
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  public class Resizer
  {
    private Dictionary<string, Resizer.ControlInfo> ctrlDict;

    public Resizer() => this.ctrlDict = new Dictionary<string, Resizer.ControlInfo>();

    public void FindAllControls(Control thisCtrl)
    {
      try
      {
        foreach (Control control in thisCtrl.Controls)
        {
          try
          {
            if (!Information.IsNothing((object) control.Parent))
            {
              if (control is Label | control is ComboBox | control is Button | control is CheckBox | control is ListBox | control is RichTextBox | control is DotNetBarTabcontrol && Operators.CompareString(control.Name, "Label8", false) != 0 & Operators.CompareString(control.Name, "Button2", false) != 0 & Operators.CompareString(control.Name, "LabelPropertiesFilename", false) != 0 & Operators.CompareString(control.Name, "LabelProperties", false) != 0 & Operators.CompareString(control.Name, "LabelProperties2", false) != 0)
              {
                Resizer.ControlInfo controlInfo = new Resizer.ControlInfo();
                controlInfo.name = control.Name;
                controlInfo.parentName = control.Parent.Name;
                controlInfo.originalFontSize = control.Font.Size;
                controlInfo.originalHeight = control.Height;
                controlInfo.originalWidth = control.Width;
                this.ctrlDict.Add(controlInfo.name, controlInfo);
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Debug.Print(ex.Message);
            ProjectData.ClearProjectError();
          }
          if (control.Controls.Count > 0)
            this.FindAllControls(control);
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void ResizeAllControls(Control thisCtrl, float Ratio)
    {
      float emSize = Ratio;
      try
      {
        foreach (Control control in thisCtrl.Controls)
        {
          try
          {
            if (!Information.IsNothing((object) control.Parent))
            {
              Resizer.ControlInfo controlInfo = new Resizer.ControlInfo();
              try
              {
                if (this.ctrlDict.TryGetValue(control.Name, out controlInfo))
                {
                  Font font = control.Font;
                  control.Font = new Font(font.FontFamily, emSize, font.Style);
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
          if (control.Controls.Count > 0)
            this.ResizeAllControls(control, Ratio);
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private struct ControlInfo
    {
      public string name;
      public string parentName;
      public int originalHeight;
      public int originalWidth;
      public float originalFontSize;
    }
  }
}
