// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmRemoveProgress
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmRemoveProgress : Form
  {
    private IContainer components;

    public frmRemoveProgress()
    {
      this.Load += new EventHandler(this.RemoveProgress_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.ListBox1 = new ListBox();
      this.Button1 = new Button();
      this.SuspendLayout();
      this.ListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ListBox1.FormattingEnabled = true;
      this.ListBox1.Location = new Point(12, 12);
      this.ListBox1.Name = "ListBox1";
      this.ListBox1.Size = new Size(703, 134);
      this.ListBox1.TabIndex = 0;
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(640, 152);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(727, 185);
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.ListBox1);
      this.Name = "RemoveProgress";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Progress";
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("ListBox1")]
    internal virtual ListBox ListBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get => this._Button1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void RemoveProgress_Load(object sender, EventArgs e)
    {
      CenterForms.CenterForm((Form) this, (Form) MyProject.Forms.frmLibrary);
    }
  }
}
