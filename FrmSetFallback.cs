// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.FrmSetFallback
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class FrmSetFallback : Form
  {
    private IContainer components;
    public Dictionary<string, string> ComboAudioFallbackSource;
    public Dictionary<string, string> ComboMicFallbackSource;

    public FrmSetFallback()
    {
      this.Load += new EventHandler(this.SetFallback_Load);
      this.ComboAudioFallbackSource = new Dictionary<string, string>();
      this.ComboMicFallbackSource = new Dictionary<string, string>();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmSetFallback));
      this.GroupBox1 = new GroupBox();
      this.ComboBox3 = new ComboBox();
      this.Label8 = new Label();
      this.ComboBox4 = new ComboBox();
      this.Label9 = new Label();
      this.GroupBox4 = new GroupBox();
      this.GroupBox5 = new GroupBox();
      this.Label10 = new Label();
      this.ComboBox5 = new ComboBox();
      this.ComboBox6 = new ComboBox();
      this.Label11 = new Label();
      this.Label12 = new Label();
      this.ComboCommMicFallback = new ComboBox();
      this.Label7 = new Label();
      this.ComboCommFallback = new ComboBox();
      this.Label6 = new Label();
      this.GroupBox3 = new GroupBox();
      this.GroupBox2 = new GroupBox();
      this.Label5 = new Label();
      this.ComboBox1 = new ComboBox();
      this.ComboBox2 = new ComboBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.ComboMicFallback = new ComboBox();
      this.ComboAudioFallback = new ComboBox();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.Button3 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.ComboBox3);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Controls.Add((Control) this.ComboBox4);
      this.GroupBox1.Controls.Add((Control) this.Label9);
      this.GroupBox1.Controls.Add((Control) this.GroupBox4);
      this.GroupBox1.Controls.Add((Control) this.GroupBox5);
      this.GroupBox1.Controls.Add((Control) this.Label10);
      this.GroupBox1.Controls.Add((Control) this.ComboBox5);
      this.GroupBox1.Controls.Add((Control) this.ComboBox6);
      this.GroupBox1.Controls.Add((Control) this.Label11);
      this.GroupBox1.Controls.Add((Control) this.Label12);
      this.GroupBox1.Controls.Add((Control) this.ComboCommMicFallback);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.ComboCommFallback);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.GroupBox3);
      this.GroupBox1.Controls.Add((Control) this.GroupBox2);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.ComboBox1);
      this.GroupBox1.Controls.Add((Control) this.ComboBox2);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.ComboMicFallback);
      this.GroupBox1.Controls.Add((Control) this.ComboAudioFallback);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(409, 418);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Set when Audio/Mic devices should switch";
      this.ComboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox3.BackColor = Color.AliceBlue;
      this.ComboBox3.FlatStyle = FlatStyle.Popup;
      this.ComboBox3.FormattingEnabled = true;
      this.ComboBox3.Location = new Point(157, 224);
      this.ComboBox3.Name = "ComboBox3";
      this.ComboBox3.Size = new Size(239, 23);
      this.ComboBox3.TabIndex = 29;
      this.Label8.AutoSize = true;
      this.Label8.Location = new Point(23, 227);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(117, 15);
      this.Label8.TabIndex = 28;
      this.Label8.Text = "Mic Communication";
      this.ComboBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox4.BackColor = Color.AliceBlue;
      this.ComboBox4.FlatStyle = FlatStyle.Popup;
      this.ComboBox4.FormattingEnabled = true;
      this.ComboBox4.Location = new Point(157, 195);
      this.ComboBox4.Name = "ComboBox4";
      this.ComboBox4.Size = new Size(239, 23);
      this.ComboBox4.TabIndex = 27;
      this.Label9.AutoSize = true;
      this.Label9.Location = new Point(23, 198);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(128, 15);
      this.Label9.TabIndex = 26;
      this.Label9.Text = "Audio Communication";
      this.GroupBox4.Location = new Point(6, 111);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(26, 10);
      this.GroupBox4.TabIndex = 25;
      this.GroupBox4.TabStop = false;
      this.GroupBox5.Location = new Point(253, 113);
      this.GroupBox5.Name = "GroupBox5";
      this.GroupBox5.Size = new Size(145, 10);
      this.GroupBox5.TabIndex = 24;
      this.GroupBox5.TabStop = false;
      this.Label10.AutoSize = true;
      this.Label10.Location = new Point(38, 109);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(209, 15);
      this.Label10.TabIndex = 23;
      this.Label10.Text = "On Start/Load switch to these devices";
      this.ComboBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox5.BackColor = Color.AliceBlue;
      this.ComboBox5.FlatStyle = FlatStyle.Popup;
      this.ComboBox5.FormattingEnabled = true;
      this.ComboBox5.Location = new Point(157, 166);
      this.ComboBox5.Name = "ComboBox5";
      this.ComboBox5.Size = new Size(239, 23);
      this.ComboBox5.TabIndex = 22;
      this.ComboBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox6.BackColor = Color.AliceBlue;
      this.ComboBox6.FlatStyle = FlatStyle.Popup;
      this.ComboBox6.FormattingEnabled = true;
      this.ComboBox6.Location = new Point(157, 137);
      this.ComboBox6.Name = "ComboBox6";
      this.ComboBox6.Size = new Size(240, 23);
      this.ComboBox6.TabIndex = 21;
      this.Label11.AutoSize = true;
      this.Label11.Location = new Point(23, 169);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(73, 15);
      this.Label11.TabIndex = 20;
      this.Label11.Text = "Microphone";
      this.Label12.AutoSize = true;
      this.Label12.Location = new Point(26, 142);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(38, 15);
      this.Label12.TabIndex = 19;
      this.Label12.Text = "Audio";
      this.ComboCommMicFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboCommMicFallback.BackColor = Color.AliceBlue;
      this.ComboCommMicFallback.FlatStyle = FlatStyle.Popup;
      this.ComboCommMicFallback.FormattingEnabled = true;
      this.ComboCommMicFallback.Items.AddRange(new object[1]
      {
        (object) " "
      });
      this.ComboCommMicFallback.Location = new Point(157, 375);
      this.ComboCommMicFallback.Name = "ComboCommMicFallback";
      this.ComboCommMicFallback.Size = new Size(239, 23);
      this.ComboCommMicFallback.TabIndex = 18;
      this.Label7.AutoSize = true;
      this.Label7.Location = new Point(23, 378);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(117, 15);
      this.Label7.TabIndex = 17;
      this.Label7.Text = "Mic Communication";
      this.ComboCommFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboCommFallback.BackColor = Color.AliceBlue;
      this.ComboCommFallback.FlatStyle = FlatStyle.Popup;
      this.ComboCommFallback.FormattingEnabled = true;
      this.ComboCommFallback.Location = new Point(157, 346);
      this.ComboCommFallback.Name = "ComboCommFallback";
      this.ComboCommFallback.Size = new Size(239, 23);
      this.ComboCommFallback.TabIndex = 16;
      this.Label6.AutoSize = true;
      this.Label6.Location = new Point(23, 349);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(128, 15);
      this.Label6.TabIndex = 15;
      this.Label6.Text = "Audio Communication";
      this.GroupBox3.Location = new Point(6, 262);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(26, 10);
      this.GroupBox3.TabIndex = 14;
      this.GroupBox3.TabStop = false;
      this.GroupBox2.Location = new Point(217, 264);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(181, 10);
      this.GroupBox2.TabIndex = 13;
      this.GroupBox2.TabStop = false;
      this.Label5.AutoSize = true;
      this.Label5.Location = new Point(38, 260);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(173, 15);
      this.Label5.TabIndex = 12;
      this.Label5.Text = "On Exit switch to these devices";
      this.ComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox1.BackColor = Color.AliceBlue;
      this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox1.FlatStyle = FlatStyle.Popup;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Items.AddRange(new object[5]
      {
        (object) "When Oculus Home starts/exits",
        (object) "When Oculus Tray Tool starts/exits",
        (object) "When a Profile loads/exits",
        (object) "Never",
        (object) "When SteamVR starts/exits"
      });
      this.ComboBox1.Location = new Point(143, 34);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(253, 23);
      this.ComboBox1.TabIndex = 8;
      this.ComboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox2.BackColor = Color.AliceBlue;
      this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox2.FlatStyle = FlatStyle.Popup;
      this.ComboBox2.FormattingEnabled = true;
      this.ComboBox2.Items.AddRange(new object[5]
      {
        (object) "When Oculus Home starts/exits",
        (object) "When Oculus Tray Tool starts/exits",
        (object) "When a Profile loads/exits",
        (object) "Never",
        (object) "When SteamVR starts/exits"
      });
      this.ComboBox2.Location = new Point(143, 63);
      this.ComboBox2.Name = "ComboBox2";
      this.ComboBox2.Size = new Size(253, 23);
      this.ComboBox2.TabIndex = 9;
      this.Label4.AutoSize = true;
      this.Label4.Location = new Point(23, 63);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(112, 15);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Switch Microphone";
      this.Label3.AutoSize = true;
      this.Label3.Location = new Point(23, 34);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(77, 15);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Switch Audio";
      this.ComboMicFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboMicFallback.BackColor = Color.AliceBlue;
      this.ComboMicFallback.FlatStyle = FlatStyle.Popup;
      this.ComboMicFallback.FormattingEnabled = true;
      this.ComboMicFallback.Location = new Point(157, 317);
      this.ComboMicFallback.Name = "ComboMicFallback";
      this.ComboMicFallback.Size = new Size(239, 23);
      this.ComboMicFallback.TabIndex = 3;
      this.ComboAudioFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboAudioFallback.BackColor = Color.AliceBlue;
      this.ComboAudioFallback.FlatStyle = FlatStyle.Popup;
      this.ComboAudioFallback.FormattingEnabled = true;
      this.ComboAudioFallback.Location = new Point(157, 288);
      this.ComboAudioFallback.Name = "ComboAudioFallback";
      this.ComboAudioFallback.Size = new Size(240, 23);
      this.ComboAudioFallback.TabIndex = 2;
      this.Label2.AutoSize = true;
      this.Label2.Location = new Point(23, 320);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(73, 15);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Microphone";
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(26, 293);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(38, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Audio";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(366, 436);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(55, 25);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(12, 436);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(55, 25);
      this.Button2.TabIndex = 2;
      this.Button2.Text = "Reset";
      this.Button2.UseVisualStyleBackColor = true;
      this.Button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button3.ForeColor = Color.DodgerBlue;
      this.Button3.Location = new Point(306, 436);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(55, 25);
      this.Button3.TabIndex = 3;
      this.Button3.Text = "Cancel";
      this.Button3.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = Color.White;
      this.ClientSize = new Size(433, 471);
      this.Controls.Add((Control) this.Button3);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(449, 510);
      this.Name = nameof (FrmSetFallback);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Audio Swicher";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboMicFallback")]
    internal virtual ComboBox ComboMicFallback { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboAudioFallback")]
    internal virtual ComboBox ComboAudioFallback { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox ComboBox2
    {
      get => this._ComboBox2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox2_SelectedIndexChanged);
        ComboBox comboBox2_1 = this._ComboBox2;
        if (comboBox2_1 != null)
          comboBox2_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox2 = value;
        ComboBox comboBox2_2 = this._ComboBox2;
        if (comboBox2_2 == null)
          return;
        comboBox2_2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox ComboBox1
    {
      get => this._ComboBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
        ComboBox comboBox1_1 = this._ComboBox1;
        if (comboBox1_1 != null)
          comboBox1_1.SelectedIndexChanged -= eventHandler;
        this._ComboBox1 = value;
        ComboBox comboBox1_2 = this._ComboBox1;
        if (comboBox1_2 == null)
          return;
        comboBox1_2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label4")]
    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label3")]
    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button3
    {
      get => this._Button3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button3_Click);
        Button button3_1 = this._Button3;
        if (button3_1 != null)
          button3_1.Click -= eventHandler;
        this._Button3 = value;
        Button button3_2 = this._Button3;
        if (button3_2 == null)
          return;
        button3_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ComboCommFallback")]
    internal virtual ComboBox ComboCommFallback { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label6")]
    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox3")]
    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox2")]
    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label5")]
    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboCommMicFallback")]
    internal virtual ComboBox ComboCommMicFallback { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label7")]
    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox3")]
    internal virtual ComboBox ComboBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label8")]
    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox4")]
    internal virtual ComboBox ComboBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label9")]
    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox4")]
    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox5")]
    internal virtual GroupBox GroupBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label10")]
    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox5")]
    internal virtual ComboBox ComboBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ComboBox6")]
    internal virtual ComboBox ComboBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label11")]
    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label12")]
    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void Button1_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.ComboBox6.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboBox6.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.SetAudioOnStart = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
            MySettingsProperty.Settings.SetAudioOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart.ToString() + "' as current default audio device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox6.SelectedItem).Key;
            MySettingsProperty.Settings.SetAudioOnStart = ((KeyValuePair<string, string>) this.ComboBox6.SelectedItem).Value;
            MySettingsProperty.Settings.SetAudioOnStartGuid = key;
          }
        }
        if (this.ComboAudioFallback.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboAudioFallback.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.DefaultAudio = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
            MySettingsProperty.Settings.SystemDefaultAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultAudio + "' as current default audio device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboAudioFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultAudio = ((KeyValuePair<string, string>) this.ComboAudioFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultAudioGuid = key;
          }
        }
        if (this.ComboBox5.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboBox5.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.SetMicOnStart = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
            MySettingsProperty.Settings.SetMicOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetMicOnStart + "' as current default mic device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox5.SelectedItem).Key;
            MySettingsProperty.Settings.SetMicOnStart = ((KeyValuePair<string, string>) this.ComboBox5.SelectedItem).Value;
            MySettingsProperty.Settings.SetMicOnStartGuid = key;
          }
        }
        if (this.ComboMicFallback.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboMicFallback.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.DefaultMic = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
            MySettingsProperty.Settings.SystemDefaultMicGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultMic + "' as current default mic device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboMicFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultMic = ((KeyValuePair<string, string>) this.ComboMicFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultMicGuid = key;
          }
        }
        if (this.ComboBox4.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboBox4.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.SetAudioCommOnStart = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
            MySettingsProperty.Settings.SetAudioCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioCommOnStart + "' as current default audio comm device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox4.SelectedItem).Key;
            MySettingsProperty.Settings.SetAudioCommOnStart = ((KeyValuePair<string, string>) this.ComboBox4.SelectedItem).Value;
            MySettingsProperty.Settings.SetAudioCommOnStartGuid = key;
          }
        }
        if (this.ComboCommFallback.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboCommFallback.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.DefaultCommAudio = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
            MySettingsProperty.Settings.SystemDefaultCommAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultCommAudio + "' as current default audio comm device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboCommFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultCommAudio = ((KeyValuePair<string, string>) this.ComboCommFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultCommAudioGuid = key;
          }
        }
        if (this.ComboBox3.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboBox3.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.SetMicCommOnStart = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
            MySettingsProperty.Settings.SetMicCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.SetAudioOnStart + "' as current mic comm device (on startup)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboBox3.SelectedItem).Key;
            MySettingsProperty.Settings.SetMicCommOnStart = ((KeyValuePair<string, string>) this.ComboBox3.SelectedItem).Value;
            MySettingsProperty.Settings.SetMicCommOnStartGuid = key;
          }
        }
        if (this.ComboCommMicFallback.SelectedItem != null)
        {
          if (Operators.CompareString(this.ComboCommFallback.Text, "Use current default", false) == 0)
          {
            MySettingsProperty.Settings.DefaultComm = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
            MySettingsProperty.Settings.SystemDefaultCommGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
            Log.WriteToLog("Stored '" + MySettingsProperty.Settings.DefaultComm + "' as current mic comm device (on exit)");
          }
          else
          {
            string key = ((KeyValuePair<string, string>) this.ComboCommMicFallback.SelectedItem).Key;
            MySettingsProperty.Settings.DefaultComm = ((KeyValuePair<string, string>) this.ComboCommMicFallback.SelectedItem).Value;
            MySettingsProperty.Settings.SystemDefaultCommGuid = key;
          }
        }
        MySettingsProperty.Settings.Save();
        if (Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, (string) null, false) != 0 & Operators.CompareString(MySettingsProperty.Settings.DefaultMic, (string) null, false) != 0)
        {
          MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = true;
        }
        else
        {
          MyProject.Forms.FrmMain.ToolStripMenuItem3.Enabled = false;
          MyProject.Forms.FrmMain.ToolStripMenuItem3.ToolTipText = "No fallback devices has been selected in the AudioSwitcher configuration";
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Error setting Audio fallback device: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Error setting Audio fallback device: " + exception.Message), MsgBoxStyle.Critical, (object) "Error");
        ProjectData.ClearProjectError();
      }
      this.Close();
    }

    private void SetFallback_Load(object sender, EventArgs e)
    {
      GetConfig.IsReading = true;
      this.ComboBox1.SelectedIndex = MySettingsProperty.Settings.SetRiftAudioDefault;
      this.ComboBox2.SelectedIndex = MySettingsProperty.Settings.SetRiftMicDefault;
      this.ComboAudioFallback.Text = MySettingsProperty.Settings.DefaultAudio;
      this.ComboMicFallback.Text = MySettingsProperty.Settings.DefaultMic;
      this.ComboCommFallback.Text = MySettingsProperty.Settings.DefaultCommAudio;
      this.ComboCommMicFallback.Text = MySettingsProperty.Settings.DefaultComm;
      this.ComboBox3.Text = MySettingsProperty.Settings.SetMicCommOnStart;
      this.ComboBox4.Text = MySettingsProperty.Settings.SetAudioCommOnStart;
      this.ComboBox5.Text = MySettingsProperty.Settings.SetMicOnStart;
      this.ComboBox6.Text = MySettingsProperty.Settings.SetAudioOnStart;
      GetConfig.IsReading = false;
      MyProject.Forms.FrmMain.Cursor = Cursors.Default;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      Log.WriteToLog("Resetting AudioSwitcher settings..");
      GetConfig.IsReading = true;
      this.Cursor = Cursors.WaitCursor;
      this.ComboAudioFallback.Text = "";
      this.ComboMicFallback.Text = "";
      this.ComboCommFallback.Text = Conversions.ToString(this.ComboBox1.SelectedIndex == 0);
      this.ComboBox2.SelectedIndex = 0;
      GetConfig.IsReading = false;
      MySettingsProperty.Settings.DefaultAudio = (string) null;
      MySettingsProperty.Settings.DefaultMic = (string) null;
      MySettingsProperty.Settings.DefaultComm = (string) null;
      MySettingsProperty.Settings.DefaultCommAudio = (string) null;
      MySettingsProperty.Settings.SystemDefaultAudioGuid = (string) null;
      MySettingsProperty.Settings.SystemDefaultMicGuid = (string) null;
      MySettingsProperty.Settings.SystemDefaultCommGuid = (string) null;
      MySettingsProperty.Settings.RiftMicGuid = (string) null;
      MySettingsProperty.Settings.RiftAudioGuid = (string) null;
      MySettingsProperty.Settings.SetMicCommOnStart = (string) null;
      MySettingsProperty.Settings.SetAudioCommOnStart = (string) null;
      MySettingsProperty.Settings.SetMicOnStart = (string) null;
      MySettingsProperty.Settings.SetAudioOnStart = (string) null;
      MySettingsProperty.Settings.SetMicCommOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetAudioCommOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetMicOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetAudioOnStartGuid = (string) null;
      MySettingsProperty.Settings.SetRiftMicDefault = 0;
      MySettingsProperty.Settings.SetRiftAudioDefault = 0;
      MySettingsProperty.Settings.Save();
      GetDevices.GetAllAudioDevices();
      GetDevices.GetAllMicDevices();
      this.Cursor = Cursors.Default;
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.SetRiftAudioDefault = this.ComboBox1.SelectedIndex;
      MySettingsProperty.Settings.Save();
    }

    private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.SetRiftMicDefault = this.ComboBox2.SelectedIndex;
      MySettingsProperty.Settings.Save();
    }

    private void Button3_Click(object sender, EventArgs e) => this.Close();
  }
}
