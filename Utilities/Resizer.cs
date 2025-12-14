


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool
{
  public class Resizer
  {
    private Dictionary<string, Resizer.ControlInfo> ctrlDict;

    public Resizer() => this.ctrlDict = new Dictionary<string, Resizer.ControlInfo>();

    public void FindAllControls(Control thisCtrl)
    {
        foreach (Control control in thisCtrl.Controls)
        {
          try
          {
            if (control.Parent != null)
            {
            if ((control is Label || control is ComboBox || control is Button || control is CheckBox || control is ListBox || control is RichTextBox || control is DotNetBarTabcontrol) && control.Name != "Label8" && control.Name != "Button2" && control.Name != "LabelPropertiesFilename" && control.Name != "LabelProperties" && control.Name != "LabelProperties2" && control.Name != "ComboPowerPlanStart" && control.Name != "ComboPowerPlanExit")
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
            Debug.Print(ex.Message);
          }
          if (control.Controls.Count > 0)
            this.FindAllControls(control);
        }
      }

    public void ResizeAllControls(Control thisCtrl, float Ratio)
    {
      float emSize = Ratio;
      if (emSize < 8.0f) emSize = 8.0f; // Safeguard against invisible text
        foreach (Control control in thisCtrl.Controls)
        {
          try
          {
            if (control.Parent != null)
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
              }
            }
          }
          catch (Exception ex)
          {
          }
          if (control.Controls.Count > 0)
            this.ResizeAllControls(control, Ratio);
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

