// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmSetLibraryPath
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
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmSetLibraryPath : Form
  {
    private IContainer components;

    public frmSetLibraryPath() => this.InitializeComponent();

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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSetLibraryPath));
      this.GroupBox1 = new GroupBox();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.FolderBrowserDialog1 = new FolderBrowserDialog();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(394, 97);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(382, 77);
      this.Label1.TabIndex = 0;
      this.Label1.Text = componentResourceManager.GetString("Label1.Text");
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(150, 124);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size((int) sbyte.MaxValue, 29);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Browse...";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(418, 165);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SetLibraryPath";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Set Library Path";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [field: AccessedThroughProperty("FolderBrowserDialog1")]
    internal virtual FolderBrowserDialog FolderBrowserDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.FolderBrowserDialog1.ShowDialog() != DialogResult.OK)
        return;
      if (Directory.Exists(this.FolderBrowserDialog1.SelectedPath.TrimEnd('\\') + "\\Manifests"))
      {
        if (File.Exists(this.FolderBrowserDialog1.SelectedPath.TrimEnd('\\') + "\\Manifests\\oculus-home.json"))
        {
          int num1 = (int) Interaction.MsgBox((object) "While this path contains a 'Manifests' folder, it is not the correct one. See if there's a subfolder called 'Software' to the folder you selected. If so please select that folder.", MsgBoxStyle.Exclamation, (object) "Invalid Path");
        }
        else
        {
          MySettingsProperty.Settings.LibraryPath = this.FolderBrowserDialog1.SelectedPath.TrimEnd('\\');
          MySettingsProperty.Settings.Save();
          this.Close();
        }
      }
      else
      {
        int num2 = (int) Interaction.MsgBox((object) "Invalid Path: Folder does not contain 'Manifests'", MsgBoxStyle.Exclamation, (object) "Invalid Path");
      }
    }
  }
}
