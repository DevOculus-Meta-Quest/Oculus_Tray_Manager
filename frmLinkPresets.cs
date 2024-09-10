// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmLinkPresets
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
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
  public class frmLinkPresets : Form
  {
    private IContainer components;

    public frmLinkPresets() => this.InitializeComponent();

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
      this.Label1 = new Label();
      this.TextBox1 = new TextBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1 = new GroupBox();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(12, 28);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(47, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Name: ";
      this.TextBox1.Location = new Point(65, 25);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(228, 21);
      this.TextBox1.TabIndex = 1;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 83);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 2;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(218, 83);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 3;
      this.Button2.Text = "OK";
      this.Button2.UseVisualStyleBackColor = true;
      this.GroupBox1.Location = new Point(5, 67);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(299, 10);
      this.GroupBox1.TabIndex = 4;
      this.GroupBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(310, 118);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.TextBox1);
      this.Controls.Add((Control) this.Label1);
      this.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = nameof (frmLinkPresets);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Preset";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TextBox1")]
    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button Button2
    {
      get => this._Button2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        Button button2_1 = this._Button2;
        if (button2_1 != null)
          button2_1.Click -= eventHandler;
        this._Button2 = value;
        Button button2_2 = this._Button2;
        if (button2_2 == null)
          return;
        button2_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (FrmMain.fmain.ComboBox4.FindString(this.TextBox1.Text) >= 0)
      {
        int num = (int) Interaction.MsgBox((object) "A Preset with this name already exists", MsgBoxStyle.Critical, (object) "Preset exists");
        this.TextBox1.Text = "";
      }
      else
      {
        FrmMain.fmain.ComboBox4.Items.Add((object) this.TextBox1.Text);
        FrmMain.fmain.ComboBox4.SelectedIndex = checked (FrmMain.fmain.ComboBox4.Items.Count - 1);
        MyProject.Forms.FrmMain.isCopy = false;
      }
      this.Close();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.isCopy = false;
      this.Close();
    }
  }
}
