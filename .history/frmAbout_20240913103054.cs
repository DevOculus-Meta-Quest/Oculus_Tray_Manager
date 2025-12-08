// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmAbout
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmAbout : Form
  {
    private IContainer components;
    private Resizer rs;

    public frmAbout()
    {
      this.Load += new EventHandler(this.readme_Load);
      this.rs = new Resizer();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAbout));
      this.LinkLabel1 = new LinkLabel();
      this.PictureBox1 = new PictureBox();
      this.GroupBox1 = new GroupBox();
      this.LinkLabel2 = new LinkLabel();
      this.Label7 = new Label();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.LinkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.LinkLabel1.AutoSize = true;
      this.LinkLabel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LinkLabel1.Location = new Point(209, 128);
      this.LinkLabel1.Name = "LinkLabel1";
      this.LinkLabel1.Size = new Size(102, 15);
      this.LinkLabel1.TabIndex = 0;
      this.LinkLabel1.TabStop = true;
      this.LinkLabel1.Text = "Open User Guide";
      this.PictureBox1.Cursor = Cursors.Hand;
      this.PictureBox1.Image = (Image) OculusTrayTool.My.Resources.Resources.paypal;
      this.PictureBox1.Location = new Point(13, 123);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(88, 27);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 2;
      this.PictureBox1.TabStop = false;
      this.GroupBox1.Controls.Add((Control) this.LinkLabel2);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(13, 4);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(305, 113);
      this.GroupBox1.TabIndex = 3;
      this.GroupBox1.TabStop = false;
      this.LinkLabel2.AutoSize = true;
      this.LinkLabel2.Location = new Point(108, 87);
      this.LinkLabel2.Name = "LinkLabel2";
      this.LinkLabel2.Size = new Size(114, 13);
      this.LinkLabel2.TabIndex = 7;
      this.LinkLabel2.TabStop = true;
      this.LinkLabel2.Text = "https://apollyonvr.com";
      this.Label7.Location = new Point(7, 87);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(55, 13);
      this.Label7.TabIndex = 6;
      this.Label7.Text = "Website: ";
      this.Label6.ForeColor = Color.Crimson;
      this.Label6.Location = new Point(103, 65);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(143, 15);
      this.Label6.TabIndex = 5;
      this.Label6.Text = " ApollyonVR@gmail.com";
      this.Label5.ForeColor = Color.Crimson;
      this.Label5.Location = new Point(103, 42);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(100, 15);
      this.Label5.TabIndex = 4;
      this.Label5.Text = " ApollyonVR";
      this.Label4.ForeColor = Color.Crimson;
      this.Label4.Location = new Point(105, 20);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(100, 15);
      this.Label4.TabIndex = 3;
      this.Label4.Text = "Label4";
      this.Label3.Location = new Point(7, 65);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(39, 13);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Email: ";
      this.Label2.Location = new Point(7, 42);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(69, 13);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Created by: ";
      this.Label1.Location = new Point(7, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Oculus Tray Tool";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.White;
      this.ClientSize = new Size(330, 158);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.LinkLabel1);
      this.Controls.Add((Control) this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmAbout);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "About";
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual LinkLabel LinkLabel1
    {
      get => this._LinkLabel1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
        LinkLabel linkLabel1_1 = this._LinkLabel1;
        if (linkLabel1_1 != null)
          linkLabel1_1.LinkClicked -= clickedEventHandler;
        this._LinkLabel1 = value;
        LinkLabel linkLabel1_2 = this._LinkLabel1;
        if (linkLabel1_2 == null)
          return;
        linkLabel1_2.LinkClicked += clickedEventHandler;
      }
    }

    internal virtual PictureBox PictureBox1
    {
      get => this._PictureBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
        PictureBox pictureBox1_1 = this._PictureBox1;
        if (pictureBox1_1 != null)
          pictureBox1_1.Click -= eventHandler;
        this._PictureBox1 = value;
        PictureBox pictureBox1_2 = this._PictureBox1;
        if (pictureBox1_2 == null)
          return;
        pictureBox1_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label5")]
    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label4")]
    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label3")]
    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label6")]
    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual LinkLabel LinkLabel2
    {
      get => this._LinkLabel2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
        LinkLabel linkLabel2_1 = this._LinkLabel2;
        if (linkLabel2_1 != null)
          linkLabel2_1.LinkClicked -= clickedEventHandler;
        this._LinkLabel2 = value;
        LinkLabel linkLabel2_2 = this._LinkLabel2;
        if (linkLabel2_2 == null)
          return;
        linkLabel2_2.LinkClicked += clickedEventHandler;
      }
    }

    [field: AccessedThroughProperty("Label7")]
    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DllImport("user32.dll")]
    private static extern bool HideCaret(IntPtr hWnd);

    private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void readme_Load(object sender, EventArgs e) => this.PictureBox1.Focus();

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (!File.Exists(Application.StartupPath + "\\User Guide.pdf"))
        return;
      Process.Start(Application.StartupPath + "\\User Guide.pdf");
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmDonate.ShowDialog();
      this.Close();
    }

    private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("https://apollyonvr.com");
    }
  }
}
