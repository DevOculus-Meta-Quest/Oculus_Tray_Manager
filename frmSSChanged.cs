// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmSSChanged
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
  public class frmSSChanged : Form
  {
    private IContainer components;

    public frmSSChanged() => this.InitializeComponent();

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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSSChanged));
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.GroupBox1 = new GroupBox();
      this.CheckBox1 = new CheckBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(6, 16);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(250, 36);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Restart any running VR application to apply the new Super Sampling value to it.";
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(214, 64);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(45, 25);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(3, 3);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(260, 55);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox1.ForeColor = Color.DodgerBlue;
      this.CheckBox1.Location = new Point(12, 68);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size(175, 19);
      this.CheckBox1.TabIndex = 3;
      this.CheckBox1.Text = "Got it, don't show this again";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(267, 95);
      this.Controls.Add((Control) this.CheckBox1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.Button1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ssChanged";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Restart Reminder";
      this.GroupBox1.ResumeLayout(false);
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

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckBox1.Checked)
        MySettingsProperty.Settings.ShowConfirmRestart = false;
      else
        MySettingsProperty.Settings.ShowConfirmRestart = true;
    }
  }
}
