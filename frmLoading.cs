// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmLoading
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
  public class frmLoading : Form
  {
    private IContainer components;

    public frmLoading()
    {
      this.Load += new EventHandler(this.Loading_Load);
      this.FormClosing += new FormClosingEventHandler(this.frmLoading_FormClosing);
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
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.PictureBox2 = new PictureBox();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.White;
      this.Label1.Location = new Point(53, 13);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(111, 17);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Oculus Tray Tool";
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.DarkGray;
      this.Label2.Location = new Point(53, 30);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(166, 17);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Starting up, please wait...";
      this.PictureBox2.Image = (Image) OculusTrayTool.My.Resources.Resources.App_Blue_32;
      this.PictureBox2.Location = new Point(15, 18);
      this.PictureBox2.Name = "PictureBox2";
      this.PictureBox2.Size = new Size(32, 29);
      this.PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox2.TabIndex = 4;
      this.PictureBox2.TabStop = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(259, 63);
      this.ControlBox = false;
      this.Controls.Add((Control) this.PictureBox2);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.Label1);
      this.ForeColor = Color.DodgerBlue;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (frmLoading);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Loading";
      ((ISupportInitialize) this.PictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
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

    [field: AccessedThroughProperty("PictureBox2")]
    internal virtual PictureBox PictureBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void Loading_Load(object sender, EventArgs e)
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      int x = checked (workingArea.Width - this.Width);
      workingArea = Screen.PrimaryScreen.WorkingArea;
      int y = checked (workingArea.Height - this.Height);
      this.Location = new Point(x, y);
      Win32.AnimateWindow(this.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_NEGATIVE | Win32.AnimateWindowFlags.AW_SLIDE);
    }

    private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void Label1_Click(object sender, EventArgs e)
    {
      if (!MyProject.Forms.FrmMain.loadingDone)
        return;
      MyProject.Forms.FrmMain.ShowForm();
    }

    private void Label2_Click(object sender, EventArgs e)
    {
      if (!MyProject.Forms.FrmMain.loadingDone)
        return;
      MyProject.Forms.FrmMain.ShowForm();
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      if (!MyProject.Forms.FrmMain.loadingDone)
        return;
      MyProject.Forms.FrmMain.ShowForm();
    }

    public void CloseStartupToast()
    {
      Win32.AnimateWindow(this.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_POSITIVE | Win32.AnimateWindowFlags.AW_HIDE | Win32.AnimateWindowFlags.AW_SLIDE);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle = createParams.ExStyle | 134217728 | 8;
        return createParams;
      }
    }

    protected override void WndProc(ref Message msg)
    {
      if (msg.Msg == 33)
        msg.Result = (IntPtr) 3;
      else
        base.WndProc(ref msg);
    }
  }
}
