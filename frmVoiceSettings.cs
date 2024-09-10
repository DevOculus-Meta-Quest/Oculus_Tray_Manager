// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmVoiceSettings
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
  public class frmVoiceSettings : Form
  {
    private IContainer components;
    public bool VoicechangeMade;
    private int iRow;
    private int iCol;
    private string setting;
    private bool isEditing;

    public frmVoiceSettings()
    {
      this.FormClosing += new FormClosingEventHandler(this.voiceSettings_FormClosing);
      this.Load += new EventHandler(this.voiceSettings_Load);
      this.KeyDown += new KeyEventHandler(this.frmVoiceSettings_KeyDown);
      this.VoicechangeMade = false;
      this.isEditing = false;
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
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmVoiceSettings));
      this.GroupBox1 = new GroupBox();
      this.Label2 = new Label();
      this.Button1 = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.Button3 = new Button();
      this.LabelConfidencePercent = new Label();
      this.Label1 = new Label();
      this.TrackBar1 = new TrackBar();
      this.ImageList1 = new ImageList(this.components);
      this.DotNetBarTabcontrol1 = new DotNetBarTabcontrol();
      this.TabPage3 = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.CheckBox7 = new CheckBox();
      this.CheckBox5 = new CheckBox();
      this.CheckBox6 = new CheckBox();
      this.Label3 = new Label();
      this.LabelExplain = new Label();
      this.LabelKey = new Label();
      this.CheckBox1 = new CheckBox();
      this.ButtonListen = new Button();
      this.CheckBox2 = new CheckBox();
      this.Label4 = new Label();
      this.CheckBox3 = new CheckBox();
      this.ComboDevice = new ComboBox();
      this.CheckBox4 = new CheckBox();
      this.TabPage1 = new TabPage();
      this.ListView1 = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.TabPage2 = new TabPage();
      this.Button4 = new Button();
      this.Button2 = new Button();
      this.ComboBox1 = new ComboBox();
      this.Label5 = new Label();
      this.ListView2 = new ListView();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.GroupBox1.SuspendLayout();
      this.TrackBar1.BeginInit();
      this.DotNetBarTabcontrol1.SuspendLayout();
      this.TabPage3.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.TabPage1.SuspendLayout();
      this.TabPage2.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(601, 47);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.DodgerBlue;
      this.Label2.Location = new Point(5, 10);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(585, 35);
      this.Label2.TabIndex = 0;
      this.Label2.Text = "Click on the Voice Command you want to edit and add/remove phrases to control that function. Commands are separated with a semicolon ( ; ).\r\n";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(538, 474);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 25);
      this.Button1.TabIndex = 5;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button3.ForeColor = Color.DodgerBlue;
      this.Button3.Location = new Point(12, 474);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(83, 25);
      this.Button3.TabIndex = 10;
      this.Button3.Text = "Set Defaults";
      this.Button3.UseVisualStyleBackColor = true;
      this.LabelConfidencePercent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.LabelConfidencePercent.AutoSize = true;
      this.LabelConfidencePercent.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LabelConfidencePercent.ForeColor = Color.DodgerBlue;
      this.LabelConfidencePercent.Location = new Point(308, 479);
      this.LabelConfidencePercent.Name = "LabelConfidencePercent";
      this.LabelConfidencePercent.Size = new Size(0, 15);
      this.LabelConfidencePercent.TabIndex = 40;
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(126, 479);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 15);
      this.Label1.TabIndex = 39;
      this.Label1.Text = "Confidence:";
      this.TrackBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.TrackBar1.AutoSize = false;
      this.TrackBar1.Location = new Point(201, 479);
      this.TrackBar1.Maximum = 100;
      this.TrackBar1.Minimum = 1;
      this.TrackBar1.Name = "TrackBar1";
      this.TrackBar1.Size = new Size(107, 20);
      this.TrackBar1.TabIndex = 38;
      this.TrackBar1.TickStyle = TickStyle.None;
      this.TrackBar1.Value = 1;
      this.ImageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("ImageList1.ImageStream");
      this.ImageList1.TransparentColor = Color.Transparent;
      this.ImageList1.Images.SetKeyName(0, "Very-Basic-Listen-icon.png");
      this.ImageList1.Images.SetKeyName(1, "Very-Basic-Not-Listen-icon.png");
      this.DotNetBarTabcontrol1.Alignment = TabAlignment.Left;
      this.DotNetBarTabcontrol1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage3);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage1);
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage2);
      this.DotNetBarTabcontrol1.ItemSize = new Size(43, 80);
      this.DotNetBarTabcontrol1.Location = new Point(12, 65);
      this.DotNetBarTabcontrol1.Multiline = true;
      this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
      this.DotNetBarTabcontrol1.SelectedIndex = 0;
      this.DotNetBarTabcontrol1.Size = new Size(601, 403);
      this.DotNetBarTabcontrol1.SizeMode = TabSizeMode.Fixed;
      this.DotNetBarTabcontrol1.TabIndex = 41;
      this.ToolTip1.SetToolTip((Control) this.DotNetBarTabcontrol1, "Click to add command");
      this.TabPage3.BackColor = Color.White;
      this.TabPage3.Controls.Add((Control) this.GroupBox2);
      this.TabPage3.Location = new Point(84, 4);
      this.TabPage3.Name = "TabPage3";
      this.TabPage3.Padding = new Padding(3);
      this.TabPage3.Size = new Size(513, 395);
      this.TabPage3.TabIndex = 2;
      this.TabPage3.Text = "Activation";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.CheckBox7);
      this.GroupBox2.Controls.Add((Control) this.CheckBox5);
      this.GroupBox2.Controls.Add((Control) this.CheckBox6);
      this.GroupBox2.Controls.Add((Control) this.Label3);
      this.GroupBox2.Controls.Add((Control) this.LabelExplain);
      this.GroupBox2.Controls.Add((Control) this.LabelKey);
      this.GroupBox2.Controls.Add((Control) this.CheckBox1);
      this.GroupBox2.Controls.Add((Control) this.ButtonListen);
      this.GroupBox2.Controls.Add((Control) this.CheckBox2);
      this.GroupBox2.Controls.Add((Control) this.Label4);
      this.GroupBox2.Controls.Add((Control) this.CheckBox3);
      this.GroupBox2.Controls.Add((Control) this.ComboDevice);
      this.GroupBox2.Controls.Add((Control) this.CheckBox4);
      this.GroupBox2.Location = new Point(6, 0);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(501, 389);
      this.GroupBox2.TabIndex = 10;
      this.GroupBox2.TabStop = false;
      this.CheckBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.CheckBox7.AutoSize = true;
      this.CheckBox7.ForeColor = Color.DodgerBlue;
      this.CheckBox7.Location = new Point(355, 366);
      this.CheckBox7.Name = "CheckBox7";
      this.CheckBox7.Size = new Size(138, 17);
      this.CheckBox7.TabIndex = 12;
      this.CheckBox7.Text = "Disable audio feedback";
      this.CheckBox7.UseVisualStyleBackColor = true;
      this.CheckBox5.AutoSize = true;
      this.CheckBox5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox5.ForeColor = Color.DodgerBlue;
      this.CheckBox5.Location = new Point(20, 162);
      this.CheckBox5.Name = "CheckBox5";
      this.CheckBox5.Size = new Size(178, 19);
      this.CheckBox5.TabIndex = 10;
      this.CheckBox5.Text = "Joystick activated, continous";
      this.CheckBox5.UseVisualStyleBackColor = true;
      this.CheckBox6.AutoSize = true;
      this.CheckBox6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox6.ForeColor = Color.DodgerBlue;
      this.CheckBox6.Location = new Point(20, 187);
      this.CheckBox6.Name = "CheckBox6";
      this.CheckBox6.Size = new Size(198, 19);
      this.CheckBox6.TabIndex = 11;
      this.CheckBox6.Text = "Joystick activated, Push-To-Talk";
      this.CheckBox6.UseVisualStyleBackColor = true;
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.ForeColor = Color.DodgerBlue;
      this.Label3.Location = new Point(6, 30);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(446, 15);
      this.Label3.TabIndex = 0;
      this.Label3.Text = "Select how voice commands should be enabled. You can select multiple options.";
      this.LabelExplain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.LabelExplain.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LabelExplain.ForeColor = Color.DodgerBlue;
      this.LabelExplain.Location = new Point(256, 70);
      this.LabelExplain.Name = "LabelExplain";
      this.LabelExplain.Size = new Size(239, 178);
      this.LabelExplain.TabIndex = 2;
      this.LabelKey.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelKey.ForeColor = Color.DodgerBlue;
      this.LabelKey.Location = new Point(19, 324);
      this.LabelKey.Name = "LabelKey";
      this.LabelKey.Size = new Size(205, 25);
      this.LabelKey.TabIndex = 9;
      this.LabelKey.TextAlign = ContentAlignment.MiddleCenter;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox1.ForeColor = Color.DodgerBlue;
      this.CheckBox1.Location = new Point(20, 70);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size(166, 19);
      this.CheckBox1.TabIndex = 1;
      this.CheckBox1.Text = "Voice activated, continous";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.ButtonListen.Enabled = false;
      this.ButtonListen.FlatStyle = FlatStyle.Flat;
      this.ButtonListen.Image = (Image) OculusTrayTool.My.Resources.Resources.Very_Basic_Not_Listen_icon;
      this.ButtonListen.Location = new Point(242, 313);
      this.ButtonListen.Name = "ButtonListen";
      this.ButtonListen.Size = new Size(56, 53);
      this.ButtonListen.TabIndex = 8;
      this.ToolTip1.SetToolTip((Control) this.ButtonListen, "Click to capture button or key");
      this.ButtonListen.UseVisualStyleBackColor = true;
      this.CheckBox2.AutoSize = true;
      this.CheckBox2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox2.ForeColor = Color.DodgerBlue;
      this.CheckBox2.Location = new Point(20, 93);
      this.CheckBox2.Name = "CheckBox2";
      this.CheckBox2.Size = new Size(162, 19);
      this.CheckBox2.TabIndex = 3;
      this.CheckBox2.Text = "Voice activated, repeated";
      this.CheckBox2.UseVisualStyleBackColor = true;
      this.Label4.AutoSize = true;
      this.Label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.ForeColor = Color.DodgerBlue;
      this.Label4.Location = new Point(16, 247);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(208, 15);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Select device for button/key activation";
      this.CheckBox3.AutoSize = true;
      this.CheckBox3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox3.ForeColor = Color.DodgerBlue;
      this.CheckBox3.Location = new Point(20, 116);
      this.CheckBox3.Name = "CheckBox3";
      this.CheckBox3.Size = new Size(188, 19);
      this.CheckBox3.TabIndex = 4;
      this.CheckBox3.Text = "Keyboard activated, continous";
      this.CheckBox3.UseVisualStyleBackColor = true;
      this.ComboDevice.Enabled = false;
      this.ComboDevice.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboDevice.ForeColor = Color.DodgerBlue;
      this.ComboDevice.FormattingEnabled = true;
      this.ComboDevice.Location = new Point(19, 265);
      this.ComboDevice.Name = "ComboDevice";
      this.ComboDevice.Size = new Size(205, 23);
      this.ComboDevice.TabIndex = 6;
      this.CheckBox4.AutoSize = true;
      this.CheckBox4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox4.ForeColor = Color.DodgerBlue;
      this.CheckBox4.Location = new Point(20, 139);
      this.CheckBox4.Name = "CheckBox4";
      this.CheckBox4.Size = new Size(208, 19);
      this.CheckBox4.TabIndex = 5;
      this.CheckBox4.Text = "Keyboard activated, Push-To-Talk";
      this.CheckBox4.UseVisualStyleBackColor = true;
      this.TabPage1.BackColor = Color.White;
      this.TabPage1.Controls.Add((Control) this.ListView1);
      this.TabPage1.Location = new Point(84, 4);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Padding = new Padding(3);
      this.TabPage1.Size = new Size(513, 395);
      this.TabPage1.TabIndex = 0;
      this.TabPage1.Text = "System";
      this.ListView1.Columns.AddRange(new ColumnHeader[3]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3
      });
      this.ListView1.Dock = DockStyle.Fill;
      this.ListView1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListView1.ForeColor = Color.DodgerBlue;
      this.ListView1.FullRowSelect = true;
      this.ListView1.GridLines = true;
      this.ListView1.Location = new Point(3, 3);
      this.ListView1.Name = "ListView1";
      this.ListView1.Size = new Size(507, 389);
      this.ListView1.TabIndex = 1;
      this.ListView1.UseCompatibleStateImageBehavior = false;
      this.ListView1.View = View.Details;
      this.ColumnHeader1.Text = "Action";
      this.ColumnHeader1.Width = 134;
      this.ColumnHeader2.Text = "Voice Command";
      this.ColumnHeader2.Width = 187;
      this.ColumnHeader3.Text = "Enabled";
      this.TabPage2.BackColor = Color.White;
      this.TabPage2.Controls.Add((Control) this.Button4);
      this.TabPage2.Controls.Add((Control) this.Button2);
      this.TabPage2.Controls.Add((Control) this.ComboBox1);
      this.TabPage2.Controls.Add((Control) this.Label5);
      this.TabPage2.Controls.Add((Control) this.ListView2);
      this.TabPage2.Location = new Point(84, 4);
      this.TabPage2.Name = "TabPage2";
      this.TabPage2.Padding = new Padding(3);
      this.TabPage2.Size = new Size(513, 395);
      this.TabPage2.TabIndex = 1;
      this.TabPage2.Text = "User";
      this.Button4.FlatStyle = FlatStyle.Flat;
      this.Button4.ForeColor = Color.DodgerBlue;
      this.Button4.Location = new Point(299, 7);
      this.Button4.Name = "Button4";
      this.Button4.Size = new Size(75, 23);
      this.Button4.TabIndex = 4;
      this.Button4.Text = "Add Profile";
      this.Button4.UseVisualStyleBackColor = true;
      this.Button2.Enabled = false;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(218, 7);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 3;
      this.Button2.Text = "Edit Profile";
      this.Button2.UseVisualStyleBackColor = true;
      this.ComboBox1.ForeColor = Color.DodgerBlue;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Location = new Point(48, 9);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(164, 21);
      this.ComboBox1.TabIndex = 2;
      this.Label5.AutoSize = true;
      this.Label5.ForeColor = Color.DodgerBlue;
      this.Label5.Location = new Point(6, 12);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(36, 13);
      this.Label5.TabIndex = 1;
      this.Label5.Text = "Profile";
      this.ListView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ListView2.Columns.AddRange(new ColumnHeader[2]
      {
        this.ColumnHeader4,
        this.ColumnHeader5
      });
      this.ListView2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListView2.ForeColor = Color.DodgerBlue;
      this.ListView2.FullRowSelect = true;
      this.ListView2.GridLines = true;
      this.ListView2.Location = new Point(3, 38);
      this.ListView2.Name = "ListView2";
      this.ListView2.Size = new Size(507, 354);
      this.ListView2.TabIndex = 0;
      this.ListView2.UseCompatibleStateImageBehavior = false;
      this.ListView2.View = View.Details;
      this.ColumnHeader4.Text = "Spoken Command";
      this.ColumnHeader4.Width = 264;
      this.ColumnHeader5.Text = "Actions";
      this.ColumnHeader5.Width = 227;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = Color.White;
      this.ClientSize = new Size(625, 508);
      this.Controls.Add((Control) this.DotNetBarTabcontrol1);
      this.Controls.Add((Control) this.LabelConfidencePercent);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.TrackBar1);
      this.Controls.Add((Control) this.Button3);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmVoiceSettings);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Configure Voice Commands";
      this.GroupBox1.ResumeLayout(false);
      this.TrackBar1.EndInit();
      this.DotNetBarTabcontrol1.ResumeLayout(false);
      this.TabPage3.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.TabPage1.ResumeLayout(false);
      this.TabPage2.ResumeLayout(false);
      this.TabPage2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

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

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ToolTip1")]
    internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [field: AccessedThroughProperty("LabelConfidencePercent")]
    internal virtual Label LabelConfidencePercent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TrackBar TrackBar1
    {
      get => this._TrackBar1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TrackBar1_Scroll);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.TrackBar1_MouseUp);
        TrackBar trackBar1_1 = this._TrackBar1;
        if (trackBar1_1 != null)
        {
          trackBar1_1.Scroll -= eventHandler;
          trackBar1_1.MouseUp -= mouseEventHandler;
        }
        this._TrackBar1 = value;
        TrackBar trackBar1_2 = this._TrackBar1;
        if (trackBar1_2 == null)
          return;
        trackBar1_2.Scroll += eventHandler;
        trackBar1_2.MouseUp += mouseEventHandler;
      }
    }

    [field: AccessedThroughProperty("DotNetBarTabcontrol1")]
    internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TabPage1")]
    internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ListView ListView1
    {
      get => this._ListView1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.ListView1_MouseClick);
        ListView listView1_1 = this._ListView1;
        if (listView1_1 != null)
          listView1_1.MouseClick -= mouseEventHandler;
        this._ListView1 = value;
        ListView listView1_2 = this._ListView1;
        if (listView1_2 == null)
          return;
        listView1_2.MouseClick += mouseEventHandler;
      }
    }

    [field: AccessedThroughProperty("ColumnHeader1")]
    internal virtual ColumnHeader ColumnHeader1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader2")]
    internal virtual ColumnHeader ColumnHeader2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader3")]
    internal virtual ColumnHeader ColumnHeader3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TabPage2")]
    internal virtual TabPage TabPage2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ListView2")]
    internal virtual ListView ListView2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader4")]
    internal virtual ColumnHeader ColumnHeader4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader5")]
    internal virtual ColumnHeader ColumnHeader5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TabPage3")]
    internal virtual TabPage TabPage3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("LabelExplain")]
    internal virtual Label LabelExplain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox CheckBox1
    {
      get => this._CheckBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CheckBox1_CheckedChanged);
        EventHandler eventHandler2 = new EventHandler(this.CheckBox1_MouseHover);
        CheckBox checkBox1_1 = this._CheckBox1;
        if (checkBox1_1 != null)
        {
          checkBox1_1.CheckedChanged -= eventHandler1;
          checkBox1_1.MouseHover -= eventHandler2;
        }
        this._CheckBox1 = value;
        CheckBox checkBox1_2 = this._CheckBox1;
        if (checkBox1_2 == null)
          return;
        checkBox1_2.CheckedChanged += eventHandler1;
        checkBox1_2.MouseHover += eventHandler2;
      }
    }

    [field: AccessedThroughProperty("Label3")]
    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox CheckBox2
    {
      get => this._CheckBox2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CheckBox2_CheckedChanged);
        EventHandler eventHandler2 = new EventHandler(this.CheckBox2_MouseHover);
        CheckBox checkBox2_1 = this._CheckBox2;
        if (checkBox2_1 != null)
        {
          checkBox2_1.CheckedChanged -= eventHandler1;
          checkBox2_1.MouseHover -= eventHandler2;
        }
        this._CheckBox2 = value;
        CheckBox checkBox2_2 = this._CheckBox2;
        if (checkBox2_2 == null)
          return;
        checkBox2_2.CheckedChanged += eventHandler1;
        checkBox2_2.MouseHover += eventHandler2;
      }
    }

    internal virtual CheckBox CheckBox4
    {
      get => this._CheckBox4;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CheckBox4_CheckedChanged);
        EventHandler eventHandler2 = new EventHandler(this.CheckBox4_MouseHover);
        CheckBox checkBox4_1 = this._CheckBox4;
        if (checkBox4_1 != null)
        {
          checkBox4_1.CheckedChanged -= eventHandler1;
          checkBox4_1.MouseHover -= eventHandler2;
        }
        this._CheckBox4 = value;
        CheckBox checkBox4_2 = this._CheckBox4;
        if (checkBox4_2 == null)
          return;
        checkBox4_2.CheckedChanged += eventHandler1;
        checkBox4_2.MouseHover += eventHandler2;
      }
    }

    internal virtual CheckBox CheckBox3
    {
      get => this._CheckBox3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CheckBox3_CheckedChanged);
        EventHandler eventHandler2 = new EventHandler(this.CheckBox3_MouseHover);
        CheckBox checkBox3_1 = this._CheckBox3;
        if (checkBox3_1 != null)
        {
          checkBox3_1.CheckedChanged -= eventHandler1;
          checkBox3_1.MouseHover -= eventHandler2;
        }
        this._CheckBox3 = value;
        CheckBox checkBox3_2 = this._CheckBox3;
        if (checkBox3_2 == null)
          return;
        checkBox3_2.CheckedChanged += eventHandler1;
        checkBox3_2.MouseHover += eventHandler2;
      }
    }

    [field: AccessedThroughProperty("Label4")]
    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox ComboDevice
    {
      get => this._ComboDevice;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboDevice_SelectedIndexChanged);
        KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.ComboDevice_KeyPress);
        ComboBox comboDevice1 = this._ComboDevice;
        if (comboDevice1 != null)
        {
          comboDevice1.SelectedIndexChanged -= eventHandler;
          comboDevice1.KeyPress -= pressEventHandler;
        }
        this._ComboDevice = value;
        ComboBox comboDevice2 = this._ComboDevice;
        if (comboDevice2 == null)
          return;
        comboDevice2.SelectedIndexChanged += eventHandler;
        comboDevice2.KeyPress += pressEventHandler;
      }
    }

    internal virtual Button ButtonListen
    {
      get => this._ButtonListen;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonListen_Click);
        Button buttonListen1 = this._ButtonListen;
        if (buttonListen1 != null)
          buttonListen1.Click -= eventHandler;
        this._ButtonListen = value;
        Button buttonListen2 = this._ButtonListen;
        if (buttonListen2 == null)
          return;
        buttonListen2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ImageList1")]
    internal virtual ImageList ImageList1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("LabelKey")]
    internal virtual Label LabelKey { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox2")]
    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox CheckBox5
    {
      get => this._CheckBox5;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CheckBox5_CheckedChanged);
        EventHandler eventHandler2 = new EventHandler(this.CheckBox5_MouseHover);
        CheckBox checkBox5_1 = this._CheckBox5;
        if (checkBox5_1 != null)
        {
          checkBox5_1.CheckedChanged -= eventHandler1;
          checkBox5_1.MouseHover -= eventHandler2;
        }
        this._CheckBox5 = value;
        CheckBox checkBox5_2 = this._CheckBox5;
        if (checkBox5_2 == null)
          return;
        checkBox5_2.CheckedChanged += eventHandler1;
        checkBox5_2.MouseHover += eventHandler2;
      }
    }

    internal virtual CheckBox CheckBox6
    {
      get => this._CheckBox6;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CheckBox6_CheckedChanged);
        EventHandler eventHandler2 = new EventHandler(this.CheckBox6_MouseHover);
        CheckBox checkBox6_1 = this._CheckBox6;
        if (checkBox6_1 != null)
        {
          checkBox6_1.CheckedChanged -= eventHandler1;
          checkBox6_1.MouseHover -= eventHandler2;
        }
        this._CheckBox6 = value;
        CheckBox checkBox6_2 = this._CheckBox6;
        if (checkBox6_2 == null)
          return;
        checkBox6_2.CheckedChanged += eventHandler1;
        checkBox6_2.MouseHover += eventHandler2;
      }
    }

    internal virtual CheckBox CheckBox7
    {
      get => this._CheckBox7;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBox7_CheckedChanged);
        CheckBox checkBox7_1 = this._CheckBox7;
        if (checkBox7_1 != null)
          checkBox7_1.CheckedChanged -= eventHandler;
        this._CheckBox7 = value;
        CheckBox checkBox7_2 = this._CheckBox7;
        if (checkBox7_2 == null)
          return;
        checkBox7_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ComboBox ComboBox1
    {
      get => this._ComboBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.ComboBox1_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.ComboBox1_TextChanged);
        ComboBox comboBox1_1 = this._ComboBox1;
        if (comboBox1_1 != null)
        {
          comboBox1_1.SelectedIndexChanged -= eventHandler1;
          comboBox1_1.TextChanged -= eventHandler2;
        }
        this._ComboBox1 = value;
        ComboBox comboBox1_2 = this._ComboBox1;
        if (comboBox1_2 == null)
          return;
        comboBox1_2.SelectedIndexChanged += eventHandler1;
        comboBox1_2.TextChanged += eventHandler2;
      }
    }

    [field: AccessedThroughProperty("Label5")]
    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button4
    {
      get => this._Button4;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button4_Click);
        Button button4_1 = this._Button4;
        if (button4_1 != null)
          button4_1.Click -= eventHandler;
        this._Button4 = value;
        Button button4_2 = this._Button4;
        if (button4_2 == null)
          return;
        button4_2.Click += eventHandler;
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

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.VoicechangeMade)
      {
        this.VoicechangeMade = false;
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Restarting voice recognition");
        VoiceCommands.StopListening();
        VoiceCommands.DisableVoice();
        VoiceCommands.StartStopBuilder();
      }
      this.Close();
    }

    private void voiceSettings_FormClosing(object sender, FormClosingEventArgs e)
    {
      MySettingsProperty.Settings.VoiceDialogSize = this.Size;
      MySettings.Default.VoiceWindowLocation = this.Location;
      MySettingsProperty.Settings.Save();
      MySettings.Default.Save();
    }

    private void voiceSettings_Load(object sender, EventArgs e)
    {
      if (this.DotNetBarTabcontrol1.TabPages.Count > 2)
        this.DotNetBarTabcontrol1.TabPages.Remove(this.DotNetBarTabcontrol1.TabPages[2]);
      if (MySettings.Default.VoiceWindowLocation != new Point())
        this.Location = MySettings.Default.VoiceWindowLocation;
      else
        this.StartPosition = FormStartPosition.CenterParent;
      if (GetControllers.ControllersFound)
        return;
      GetControllers.GetAllControllers();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.StartVoice = "computer, start listening;speech on";
      MySettingsProperty.Settings.StartVoiceEnabled = true;
      MySettingsProperty.Settings.StopVoice = "computer, stop listening;speech off";
      MySettingsProperty.Settings.StopVoiceEnabled = true;
      MySettingsProperty.Settings.EnableASW = "enable spacewarp";
      MySettingsProperty.Settings.EnableASWEnabled = true;
      MySettingsProperty.Settings.DisableASW = "disable spacewarp";
      MySettingsProperty.Settings.DisableASWEnabled = true;
      MySettingsProperty.Settings.ShowPD = "show pixel density; show super sampling";
      MySettingsProperty.Settings.ShowPDEnabled = true;
      MySettingsProperty.Settings.ShowPerf = "show performance";
      MySettingsProperty.Settings.ShowPerfEnabled = true;
      MySettingsProperty.Settings.Close = "close overlay";
      MySettingsProperty.Settings.CloseEnabled = true;
      MySettingsProperty.Settings.SetPD = "set pixel density;set super sampling";
      MySettingsProperty.Settings.SetPDEnabled = true;
      MySettingsProperty.Settings.ShowASW = "show spacewarp";
      MySettingsProperty.Settings.ShowASWEnabled = true;
      MySettingsProperty.Settings.LockASWOn = "lock framerate";
      MySettingsProperty.Settings.LockASWOnEnabled = true;
      MySettingsProperty.Settings.ShowLatency = "show latency timing";
      MySettingsProperty.Settings.ShowLatencyEnabled = true;
      MySettingsProperty.Settings.ShowApplicationRender = "show application timing";
      MySettingsProperty.Settings.ShowApplicationRenderEnabled = true;
      MySettingsProperty.Settings.ShowCompositorRender = "show compositor timing";
      MySettingsProperty.Settings.ShowCompositorRenderEnabled = true;
      MySettingsProperty.Settings.ShowVersion = "show version";
      MySettingsProperty.Settings.ShowVersionEnabled = true;
      MySettingsProperty.Settings.LaunchSteam = "start steam;launch steam";
      MySettingsProperty.Settings.LaunchSteamEnabled = true;
      MySettingsProperty.Settings.Save();
      MyProject.Forms.FrmMain.LoadVoiceSettings();
      this.VoicechangeMade = true;
    }

    private void TrackBar1_Scroll(object sender, EventArgs e)
    {
      this.LabelConfidencePercent.Text = Conversions.ToString(this.TrackBar1.Value) + "%";
      this.LabelConfidencePercent.Refresh();
      this.VoicechangeMade = true;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox1.Checked)
      {
        this.CheckBox2.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the prhase set for 'Disable Voice Control' is spoken.";
        MySettingsProperty.Settings.VoiceActivationVoiceContinous = true;
      }
      else
        MySettingsProperty.Settings.VoiceActivationVoiceContinous = false;
      MySettingsProperty.Settings.Save();
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox2.Checked)
      {
        this.CheckBox1.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the prhase set for 'Enable Voice Control' must once again be spoken to activate commands.";
        MySettingsProperty.Settings.VoiceActivationVoiceRepeated = true;
      }
      else
        MySettingsProperty.Settings.VoiceActivationVoiceRepeated = false;
      MySettingsProperty.Settings.Save();
    }

    private void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox3.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox4.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again";
        MySettingsProperty.Settings.VoiceActivationKeyContinous = true;
      }
      else
      {
        MySettingsProperty.Settings.VoiceActivationKeyContinous = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox4.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox3.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
        MySettingsProperty.Settings.VoiceActivationKeyPush = true;
      }
      else
      {
        MySettingsProperty.Settings.VoiceActivationKeyPush = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void ButtonListen_Click(object sender, EventArgs e)
    {
      this.ButtonListen.Image = this.ImageList1.Images[0];
      this.ButtonListen.Refresh();
      if (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) != 0 & Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "", false) != 0)
      {
        frmVoiceSettings.UpdateButtonLabel("Push button");
        GetControllers.CaptureSelectedButton();
      }
      if (!(Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) == 0 & Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "", false) != 0))
        return;
      this.LabelKey.Text = "Press key";
    }

    private void ComboDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
      GetControllers.selectedDevice = this.ComboDevice.SelectedItem.ToString();
      if (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) != 0)
      {
        GetControllers.SelectController();
        if (Operators.CompareString(MySettingsProperty.Settings.JoystickDeviceName, this.ComboDevice.SelectedItem.ToString(), false) == 0)
          this.LabelKey.Text = MySettingsProperty.Settings.JoystickVoiceActivationButton.Replace("Buttons", "");
      }
      else
        this.LabelKey.Text = MySettingsProperty.Settings.KeyboardVoiceActivationKey;
      this.ButtonListen.Enabled = true;
    }

    private void TrackBar1_MouseUp(object sender, MouseEventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.Confidence = this.TrackBar1.Value;
      MySettingsProperty.Settings.Save();
    }

    public static void UpdateButtonLabel(string text)
    {
      if (MyProject.Forms.frmVoiceSettings.InvokeRequired)
      {
        MyProject.Forms.frmVoiceSettings.Invoke((Delegate) new frmVoiceSettings.UpdateLabelDelegate(frmVoiceSettings.UpdateButtonLabel), (object) text);
      }
      else
      {
        MyProject.Forms.frmVoiceSettings.LabelKey.Text = text;
        MyProject.Forms.frmVoiceSettings.LabelKey.Refresh();
      }
    }

    public static void UpdateListeningButton(int index)
    {
      if (MyProject.Forms.frmVoiceSettings.InvokeRequired)
      {
        MyProject.Forms.frmVoiceSettings.Invoke((Delegate) new frmVoiceSettings.UpdateListeningButtonDelegate(frmVoiceSettings.UpdateListeningButton), (object) index);
      }
      else
      {
        MyProject.Forms.frmVoiceSettings.ButtonListen.Image = MyProject.Forms.frmVoiceSettings.ImageList1.Images[index];
        MyProject.Forms.frmVoiceSettings.ButtonListen.Refresh();
      }
    }

    private void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox5.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox6.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again";
        MySettingsProperty.Settings.JoystickActivationKeyContinous = true;
      }
      else
      {
        MySettingsProperty.Settings.JoystickActivationKeyContinous = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox6.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox5.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
        MySettingsProperty.Settings.JoystickActivationKeyPush = true;
      }
      else
      {
        MySettingsProperty.Settings.JoystickActivationKeyPush = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void frmVoiceSettings_KeyDown(object sender, KeyEventArgs e)
    {
      if (Operators.CompareString(this.LabelKey.Text, "Press key", false) != 0)
        return;
      frmVoiceSettings.UpdateButtonLabel(e.KeyCode.ToString().ToUpper());
      this.ButtonListen.Image = this.ImageList1.Images[1];
      this.ButtonListen.Refresh();
      MySettingsProperty.Settings.KeyboardVoiceActivationKey = e.KeyCode.ToString().ToUpper();
      MySettingsProperty.Settings.Save();
      Log.WriteToLog("Registered '" + e.KeyCode.ToString().ToUpper() + "' as key for activating voice commands");
    }

    private void CheckBox1_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the phrase set for 'Disable Voice Control' is spoken.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox2_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the phrase set for 'Enable Voice Control' must once again be spoken.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox3_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox4_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox5_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox6_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
      this.LabelExplain.Refresh();
    }

    public void AddItemsToDeviceList()
    {
      this.ComboDevice.Text = "";
      this.ComboDevice.Items.Clear();
      this.LabelKey.Text = "";
      if (this.CheckBox3.Checked | this.CheckBox4.Checked)
        this.ComboDevice.Items.Add((object) "Keyboard");
      if (!(this.CheckBox5.Checked | this.CheckBox6.Checked))
        return;
      try
      {
        foreach (KeyValuePair<string, Guid> joystick in GetControllers.joysticks)
          this.ComboDevice.Items.Add((object) joystick.Key);
      }
      finally
      {
        Dictionary<string, Guid>.Enumerator enumerator;
        enumerator.Dispose();
      }
    }

    private void ComboDevice_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void ListView1_MouseClick(object sender, MouseEventArgs e)
    {
      ListViewHitTestInfo listViewHitTestInfo = this.ListView1.HitTest(e.X, e.Y);
      if (listViewHitTestInfo.Item == null)
        return;
      MyProject.Forms.frmEditVoiceCommand.LabelAction.Text = listViewHitTestInfo.Item.Text;
      MyProject.Forms.frmEditVoiceCommand.TextBoxPhrase.Text = listViewHitTestInfo.Item.SubItems[1].Text + ";";
      MyProject.Forms.frmEditVoiceCommand.ComboEnabled.SelectedIndex = Operators.CompareString(listViewHitTestInfo.Item.SubItems[2].Text, "True", false) != 0 ? 1 : 0;
      int num = (int) MyProject.Forms.frmEditVoiceCommand.ShowDialog();
    }

    private void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.DisableVoiceControlAudioFeedback = this.CheckBox7.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmAddCustomVoice.ShowDialog();
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Operators.ConditionalCompareObjectNotEqual(this.ComboBox1.SelectedItem, (object) null, false))
      {
        this.Button2.Enabled = true;
        List<string> stringList = new List<string>();
        List<string> voiceProfileCommands = (List<string>) OTTDB.GetVoiceProfileCommands(this.ComboBox1.SelectedItem.ToString());
        try
        {
          foreach (string Expression in voiceProfileCommands)
          {
            string[] strArray1 = Strings.Split(Expression, "|");
            ListViewItem listViewItem1 = new ListViewItem();
            ListViewItem listViewItem2 = this.ListView2.Items.Add(strArray1[0]);
            string[] strArray2 = Strings.Split(strArray1[1], ",");
            int index = 0;
            while (index < strArray2.Length)
            {
              string[] strArray3 = Strings.Split(strArray2[index], ":");
              if (Operators.CompareString(strArray3[0], "wait", false) != 0)
                listViewItem2.SubItems.Add(strArray3[0] + " '" + strArray3[1] + "'");
              checked { ++index; }
            }
          }
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      else
        this.Button2.Enabled = false;
    }

    private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmAddVoiceProfile.ShowDialog();
    }

    private void ComboBox1_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(this.ComboBox1.Text, (string) null, false) != 0)
        return;
      this.Button2.Enabled = false;
    }

    private delegate void UpdateLabelDelegate(string text);

    private delegate void UpdateListeningButtonDelegate(int index);
  }
}
