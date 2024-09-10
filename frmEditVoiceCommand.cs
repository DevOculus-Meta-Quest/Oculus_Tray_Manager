// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmEditVoiceCommand
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
  public class frmEditVoiceCommand : Form
  {
    private IContainer components;

    public frmEditVoiceCommand() => this.InitializeComponent();

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
      this.TextBoxPhrase = new TextBox();
      this.Label2 = new Label();
      this.LabelAction = new Label();
      this.ComboEnabled = new ComboBox();
      this.Label3 = new Label();
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(15, 30);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(40, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Action:";
      this.TextBoxPhrase.Location = new Point(64, 53);
      this.TextBoxPhrase.Name = "TextBoxPhrase";
      this.TextBoxPhrase.Size = new Size(249, 20);
      this.TextBoxPhrase.TabIndex = 3;
      this.Label2.AutoSize = true;
      this.Label2.Location = new Point(15, 56);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(43, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Phrase:";
      this.LabelAction.AutoSize = true;
      this.LabelAction.ForeColor = Color.Black;
      this.LabelAction.Location = new Point(61, 30);
      this.LabelAction.Name = "LabelAction";
      this.LabelAction.Size = new Size(37, 13);
      this.LabelAction.TabIndex = 4;
      this.LabelAction.Text = "Action";
      this.ComboEnabled.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboEnabled.FormattingEnabled = true;
      this.ComboEnabled.Items.AddRange(new object[2]
      {
        (object) "True",
        (object) "False"
      });
      this.ComboEnabled.Location = new Point(64, 79);
      this.ComboEnabled.Name = "ComboEnabled";
      this.ComboEnabled.Size = new Size(121, 21);
      this.ComboEnabled.TabIndex = 5;
      this.Label3.AutoSize = true;
      this.Label3.Location = new Point(15, 82);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(49, 13);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Enabled:";
      this.GroupBox1.Controls.Add((Control) this.TextBoxPhrase);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.ComboEnabled);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.LabelAction);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(334, 132);
      this.GroupBox1.TabIndex = 7;
      this.GroupBox1.TabStop = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(271, 150);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 8;
      this.Button1.Text = "Save";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Location = new Point(12, 150);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 9;
      this.Button2.Text = "Cancel";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(356, 179);
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.ForeColor = Color.DodgerBlue;
      this.Name = nameof (frmEditVoiceCommand);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Edit Voice Command";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TextBoxPhrase")]
    internal virtual TextBox TextBoxPhrase { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("LabelAction")]
    internal virtual Label LabelAction { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboEnabled")]
    internal virtual ComboBox ComboEnabled { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label3")]
    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    private void Button2_Click(object sender, EventArgs e) => this.Close();

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.TextBoxPhrase.Text.EndsWith(";"))
        this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.TrimEnd(';');
      this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.Replace(";;", ";");
      if (Operators.CompareString(this.LabelAction.Text, "Enable Voice Control", false) == 0)
        MySettingsProperty.Settings.StartVoice = this.TextBoxPhrase.Text;
      if (Operators.CompareString(this.LabelAction.Text, "Disable Voice Control", false) == 0)
        MySettingsProperty.Settings.StopVoice = this.TextBoxPhrase.Text;
      if (Operators.CompareString(this.LabelAction.Text, "Set Pixel Density", false) == 0)
      {
        MySettingsProperty.Settings.SetPD = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.SetPDEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Disable ASW", false) == 0)
      {
        MySettingsProperty.Settings.DisableASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.DisableASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Enable ASW", false) == 0)
      {
        MySettingsProperty.Settings.EnableASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.EnableASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "45 fps, ASW On", false) == 0)
      {
        MySettingsProperty.Settings.LockASWOn = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.LockASWOnEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show ASW Status", false) == 0)
      {
        MySettingsProperty.Settings.ShowASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Pixel Density", false) == 0)
      {
        MySettingsProperty.Settings.ShowPD = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowPDEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Performance", false) == 0)
      {
        MySettingsProperty.Settings.ShowPerf = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowPerfEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Latency Timing", false) == 0)
      {
        MySettingsProperty.Settings.ShowLatency = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowLatencyEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Application Render Timing", false) == 0)
      {
        MySettingsProperty.Settings.ShowApplicationRender = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowApplicationRenderEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Compositor Render Timing", false) == 0)
      {
        MySettingsProperty.Settings.ShowCompositorRender = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowCompositorRenderEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Version Info", false) == 0)
      {
        MySettingsProperty.Settings.ShowVersion = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowVersionEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Close Overlay", false) == 0)
      {
        MySettingsProperty.Settings.Close = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.CloseEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Launch SteamVR", false) == 0)
      {
        MySettingsProperty.Settings.LaunchSteam = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.LaunchSteamEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      MySettingsProperty.Settings.Save();
      MyProject.Forms.FrmMain.LoadVoiceSettings();
      MyProject.Forms.frmVoiceSettings.VoicechangeMade = true;
      this.Close();
    }
  }
}
