// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmStartupType
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
  public class frmStartupType : Form
  {
    private IContainer components;

    public frmStartupType() => this.InitializeComponent();

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
      this.RadioButton1 = new RadioButton();
      this.RadioButton2 = new RadioButton();
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(395, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Select the method for launching Oculus Tray Tool when Windows starts.";
      this.RadioButton1.AutoSize = true;
      this.RadioButton1.Location = new Point(46, 58);
      this.RadioButton1.Name = "RadioButton1";
      this.RadioButton1.Size = new Size(283, 19);
      this.RadioButton1.TabIndex = 0;
      this.RadioButton1.TabStop = true;
      this.RadioButton1.Text = "Regular startup (UAC should prompt if enabled)";
      this.RadioButton1.UseVisualStyleBackColor = true;
      this.RadioButton2.AutoSize = true;
      this.RadioButton2.Location = new Point(46, 83);
      this.RadioButton2.Name = "RadioButton2";
      this.RadioButton2.Size = new Size(339, 19);
      this.RadioButton2.TabIndex = 1;
      this.RadioButton2.TabStop = true;
      this.RadioButton2.Text = "Scheduled Task (UAC should not prompt, even if enabled)";
      this.RadioButton2.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.RadioButton2);
      this.GroupBox1.Controls.Add((Control) this.RadioButton1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(414, 123);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(351, 141);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 3;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(440, 172);
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = "StartupType";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Select Startup Method";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("RadioButton1")]
    internal virtual RadioButton RadioButton1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("RadioButton2")]
    internal virtual RadioButton RadioButton2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.RadioButton1.Checked)
      {
        if (MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue(Application.ProductName) == null)
        {
          try
          {
            MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue(Application.ProductName, (object) (Application.StartupPath + "\\OculusTrayTool.exe"));
            MySettingsProperty.Settings.StartWithWindows = true;
            MySettingsProperty.Settings.Save();
            Log.WriteToLog("Enabled 'Start with Windows', startup type' Regular'");
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Log.WriteToLog("Could not enable 'Start with Windows', startup type' Regular': " + ex.Message);
            ProjectData.ClearProjectError();
          }
        }
      }
      if (this.RadioButton2.Checked)
        CreateTask.CreateScheduledTask(true);
      this.Close();
    }
  }
}
