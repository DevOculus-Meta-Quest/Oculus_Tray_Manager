// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmHomeTrayToast
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
  public class frmHomeTrayToast : Form
  {
    private IContainer components;

    public frmHomeTrayToast()
    {
      this.Load += new EventHandler(this.HomeTrayToast_Load);
      this.Click += new EventHandler(this.HomeTrayToast_Click);
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
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.PictureBox1 = new PictureBox();
      this.Timer1 = new Timer(this.components);
      this.Timer2 = new Timer(this.components);
      this.ToolTip1 = new ToolTip(this.components);
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.DarkGray;
      this.Label2.Location = new Point(53, 30);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(173, 17);
      this.Label2.TabIndex = 8;
      this.Label2.Text = "Home is minimized to tray";
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.White;
      this.Label1.Location = new Point(53, 13);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(111, 17);
      this.Label1.TabIndex = 7;
      this.Label1.Text = "Oculus Tray Tool";
      this.PictureBox1.Image = (Image) OculusTrayTool.My.Resources.Resources.App_Blue_32;
      this.PictureBox1.Location = new Point(15, 18);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(32, 29);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 6;
      this.PictureBox1.TabStop = false;
      this.Timer1.Interval = 50;
      this.Timer2.Interval = 2500;
      this.ToolTip1.AutomaticDelay = 50;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(259, 63);
      this.ControlBox = false;
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (frmHomeTrayToast);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "HomeTrayToast";
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual Label Label2
    {
      get => this._Label2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Label2_Click);
        Label label2_1 = this._Label2;
        if (label2_1 != null)
          label2_1.Click -= eventHandler;
        this._Label2 = value;
        Label label2_2 = this._Label2;
        if (label2_2 == null)
          return;
        label2_2.Click += eventHandler;
      }
    }

    internal virtual Label Label1
    {
      get => this._Label1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Label1_Click);
        Label label1_1 = this._Label1;
        if (label1_1 != null)
          label1_1.Click -= eventHandler;
        this._Label1 = value;
        Label label1_2 = this._Label1;
        if (label1_2 == null)
          return;
        label1_2.Click += eventHandler;
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

    internal virtual Timer Timer1
    {
      get => this._Timer1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
        Timer timer1_1 = this._Timer1;
        if (timer1_1 != null)
          timer1_1.Tick -= eventHandler;
        this._Timer1 = value;
        Timer timer1_2 = this._Timer1;
        if (timer1_2 == null)
          return;
        timer1_2.Tick += eventHandler;
      }
    }

    internal virtual Timer Timer2
    {
      get => this._Timer2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer2_Tick);
        Timer timer2_1 = this._Timer2;
        if (timer2_1 != null)
          timer2_1.Tick -= eventHandler;
        this._Timer2 = value;
        Timer timer2_2 = this._Timer2;
        if (timer2_2 == null)
          return;
        timer2_2.Tick += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolTip1")]
    internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      this.Opacity -= 0.06;
      if (this.Opacity != 0.0)
        return;
      this.Close();
      this.Dispose();
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {
      this.Timer2.Stop();
      this.Timer1.Start();
    }

    private void PictureBox1_Click(object sender, EventArgs e) => this.CloseMe();

    private void Label1_Click(object sender, EventArgs e) => this.CloseMe();

    private void Label2_Click(object sender, EventArgs e) => this.CloseMe();

    private void HomeTrayToast_Load(object sender, EventArgs e)
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      int x = checked (workingArea.Width - this.Width);
      workingArea = Screen.PrimaryScreen.WorkingArea;
      int y = checked (workingArea.Height - this.Height);
      this.Location = new Point(x, y);
      this.Timer2.Start();
      Application.DoEvents();
    }

    private void HomeTrayToast_Click(object sender, EventArgs e) => this.CloseMe();

    private void CloseMe()
    {
      MySettingsProperty.Settings.ShowHomeToast = false;
      MySettingsProperty.Settings.Save();
      Log.WriteToLog("The notification toast that Oculus Home is minimized to the System Tray has been disabled.");
      Log.WriteToLog("To re-enable, set the property 'ShowHomeToast' to 'True' in the user.config file.");
      FrmMain.fmain.AddToListboxAndScroll("The notification toast that Oculus Home is minimized to the System Tray has been disabled.");
      FrmMain.fmain.AddToListboxAndScroll("To re-enable, set the property 'ShowHomeToast' to 'True' in the user.config file.");
      this.Close();
      this.Dispose();
    }
  }
}
