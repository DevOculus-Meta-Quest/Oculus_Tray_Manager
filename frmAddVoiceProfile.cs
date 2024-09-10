// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmAddVoiceProfile
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
  public class frmAddVoiceProfile : Form
  {
    private IContainer components;

    public frmAddVoiceProfile() => this.InitializeComponent();

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
      this.Label2 = new Label();
      this.ComboBox1 = new ComboBox();
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(10, 22);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(70, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Profile Name:";
      this.TextBox1.ForeColor = Color.DodgerBlue;
      this.TextBox1.Location = new Point(131, 19);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(217, 20);
      this.TextBox1.TabIndex = 1;
      this.Label2.AutoSize = true;
      this.Label2.ForeColor = Color.DodgerBlue;
      this.Label2.Location = new Point(10, 55);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(119, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Load with Game Profile:";
      this.ComboBox1.ForeColor = Color.DodgerBlue;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Location = new Point(131, 52);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(217, 21);
      this.ComboBox1.TabIndex = 3;
      this.GroupBox1.Controls.Add((Control) this.ComboBox1);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.TextBox1);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(363, 94);
      this.GroupBox1.TabIndex = 4;
      this.GroupBox1.TabStop = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 112);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 5;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(300, 112);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 6;
      this.Button2.Text = "Save";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(387, 146);
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (frmAddVoiceProfile);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Profile";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TextBox1")]
    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox1")]
    internal virtual ComboBox ComboBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void Button2_Click(object sender, EventArgs e)
    {
      MyProject.Forms.frmAddCustomVoice.VoiceProfileName = this.TextBox1.Text;
      MyProject.Forms.frmAddCustomVoice.VoiceProfileGameProfile = this.ComboBox1.Text;
      int num = (int) MyProject.Forms.frmAddCustomVoice.ShowDialog();
      this.Close();
    }
  }
}
