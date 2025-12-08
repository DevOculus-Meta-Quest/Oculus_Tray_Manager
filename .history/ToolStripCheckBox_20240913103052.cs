// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.ToolStripCheckBox
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#nullable disable
namespace OculusTrayTool
{
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
  public class ToolStripCheckBox : MyCustomToolStripControlHost
  {
    public ToolStripCheckBox()
      : base((Control) new CheckBox())
    {
      this.BackColor = Color.Transparent;
    }

    public CheckBox CheckBoxControl => this.Control as CheckBox;

    public bool Checked
    {
      get => this.CheckBoxControl.Checked;
      set => this.CheckBoxControl.Checked = value;
    }

    protected override void OnSubscribeControlEvents(Control c)
    {
      base.OnSubscribeControlEvents(c);
      ((CheckBox) c).CheckedChanged += new EventHandler(this.OnCheckedChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control c)
    {
      base.OnUnsubscribeControlEvents(c);
      ((CheckBox) c).CheckedChanged -= new EventHandler(this.OnCheckedChanged);
    }

    public event EventHandler CheckedChanged;

    private void OnCheckedChanged(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      EventHandler checkedChangedEvent = this.CheckedChangedEvent;
      if (checkedChangedEvent == null)
        return;
      checkedChangedEvent((object) this, e);
    }
  }
}
