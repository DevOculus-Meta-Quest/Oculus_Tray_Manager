// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.CueToolStripTextBox
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class CueToolStripTextBox : ToolStripTextBox
  {
    private IContainer components;
    private static uint ECM_FIRST = 5376;
    private static uint EM_SETCUEBANNER = checked ((uint) ((long) CueToolStripTextBox.ECM_FIRST + 1L));
    private string m_cueText;
    private bool m_showCueTextWithFocus;

    private void InitializeComponent() => this.components = (IContainer) new System.ComponentModel.Container();

    public CueToolStripTextBox()
    {
      this.components = (IContainer) null;
      this.m_cueText = string.Empty;
      this.m_showCueTextWithFocus = false;
      if (this.Control == null)
        return;
      this.Control.HandleCreated += new EventHandler(this.OnControlHandleCreated);
    }

    public CueToolStripTextBox(string name)
      : base(name)
    {
      this.components = (IContainer) null;
      this.m_cueText = string.Empty;
      this.m_showCueTextWithFocus = false;
      if (this.Control == null)
        return;
      this.Control.HandleCreated += new EventHandler(this.OnControlHandleCreated);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.Control != null)
        this.Control.HandleCreated -= new EventHandler(this.OnControlHandleCreated);
      base.Dispose(disposing);
    }

    public void OnControlHandleCreated(object sender, EventArgs e) => this.UpdateCue();

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(
      HandleRef hWnd,
      uint Msg,
      IntPtr wParam,
      string lParam);

    [Description("The text value to be displayed as a cue to the user.")]
    [Category("Appearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string CueText
    {
      get => this.m_cueText;
      set
      {
        if (value == null)
          value = string.Empty;
        if (this.m_cueText.Equals(value, StringComparison.CurrentCulture))
          return;
        this.m_cueText = value;
        this.UpdateCue();
        this.OnCueTextChanged(EventArgs.Empty);
      }
    }

    public event EventHandler CueTextChanged;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnCueTextChanged(EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      EventHandler textChangedEvent = this.CueTextChangedEvent;
      if (textChangedEvent == null)
        return;
      textChangedEvent((object) this, e);
    }

    [Description("Indicates whether the CueText will be displayed even when the control has focus.")]
    [Category("Appearance")]
    [DefaultValue(false)]
    [Localizable(true)]
    public bool ShowCueTextWithFocus
    {
      get => this.m_showCueTextWithFocus;
      set
      {
        if (this.m_showCueTextWithFocus == value)
          return;
        this.m_showCueTextWithFocus = value;
        this.UpdateCue();
        this.OnShowCueTextWithFocusChanged(EventArgs.Empty);
      }
    }

    public event EventHandler ShowCueTextWithFocusChanged;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnShowCueTextWithFocusChanged(EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      EventHandler focusChangedEvent = this.ShowCueTextWithFocusChangedEvent;
      if (focusChangedEvent == null)
        return;
      focusChangedEvent((object) this, e);
    }

    private void UpdateCue()
    {
      if (this.Control == null || !this.Control.IsHandleCreated)
        return;
      CueToolStripTextBox.SendMessage(new HandleRef((object) this.Control, this.Control.Handle), CueToolStripTextBox.EM_SETCUEBANNER, this.m_showCueTextWithFocus ? new IntPtr(1) : IntPtr.Zero, this.m_cueText);
    }
  }
}
