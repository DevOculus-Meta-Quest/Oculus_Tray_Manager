// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmMicNotDefaultWarning
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
  public class frmMicNotDefaultWarning : Form
  {
    private IContainer components;

    public frmMicNotDefaultWarning()
    {
      this.Load += new EventHandler(this.frmMicNotDefaultWarning_Load);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMicNotDefaultWarning));
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.CheckBox1 = new CheckBox();
      this.SuspendLayout();
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new Point(12, 9);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(380, 71);
      this.Label1.TabIndex = 0;
      this.Label1.Text = componentResourceManager.GetString("Label1.Text");
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(334, 83);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(58, 23);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Location = new Point(15, 87);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size((int) sbyte.MaxValue, 17);
      this.CheckBox1.TabIndex = 2;
      this.CheckBox1.Text = "Don't show this again";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(404, 118);
      this.ControlBox = false;
      this.Controls.Add((Control) this.CheckBox1);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.Label1);
      this.ForeColor = Color.DodgerBlue;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = nameof (frmMicNotDefaultWarning);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Oculus Tray Tool";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual CheckBox CheckBox1
    {
      get => this._CheckBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBox1_CheckedChanged);
        CheckBox checkBox1_1 = this._CheckBox1;
        if (checkBox1_1 != null)
          checkBox1_1.CheckedChanged -= eventHandler;
        this._CheckBox1 = value;
        CheckBox checkBox1_2 = this._CheckBox1;
        if (checkBox1_2 == null)
          return;
        checkBox1_2.CheckedChanged += eventHandler;
      }
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ShowMicNotDefaultWarning = !this.CheckBox1.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void frmMicNotDefaultWarning_Load(object sender, EventArgs e) => this.BringToFront();
  }
}
