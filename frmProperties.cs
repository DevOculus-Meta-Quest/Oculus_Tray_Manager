// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmProperties
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
  public class frmProperties : Form
  {
    private IContainer components;
    public string fname;

    public frmProperties()
    {
      this.Load += new EventHandler(this.Properties_Load);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmProperties));
      this.RichTextBox1 = new RichTextBox();
      this.GroupBox1 = new GroupBox();
      this.LabelProperties = new Label();
      this.Button1 = new Button();
      this.CheckBox1 = new CheckBox();
      this.Button2 = new Button();
      this.LabelProperties2 = new Label();
      this.TextBox1 = new TextBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.RichTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.RichTextBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.RichTextBox1.Location = new Point(12, 124);
      this.RichTextBox1.Name = "RichTextBox1";
      this.RichTextBox1.Size = new Size(660, 360);
      this.RichTextBox1.TabIndex = 0;
      this.RichTextBox1.Text = "";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.LabelProperties);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(660, 87);
      this.GroupBox1.TabIndex = 1;
      this.GroupBox1.TabStop = false;
      this.LabelProperties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.LabelProperties.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LabelProperties.Location = new Point(6, 12);
      this.LabelProperties.Name = "LabelProperties";
      this.LabelProperties.Size = new Size(647, 72);
      this.LabelProperties.TabIndex = 0;
      this.LabelProperties.Text = componentResourceManager.GetString("LabelProperties.Text");
      this.LabelProperties.TextAlign = ContentAlignment.MiddleCenter;
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(597, 493);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 25);
      this.Button1.TabIndex = 2;
      this.Button1.Text = "Verify file";
      this.Button1.UseVisualStyleBackColor = true;
      this.CheckBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Checked = true;
      this.CheckBox1.CheckState = CheckState.Checked;
      this.CheckBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox1.ForeColor = Color.DodgerBlue;
      this.CheckBox1.Location = new Point(452, 497);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size(143, 19);
      this.CheckBox1.TabIndex = 3;
      this.CheckBox1.Text = "Backup before saving";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(12, 493);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 25);
      this.Button2.TabIndex = 4;
      this.Button2.Text = "Close";
      this.Button2.UseVisualStyleBackColor = true;
      this.LabelProperties2.AutoSize = true;
      this.LabelProperties2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LabelProperties2.ForeColor = Color.DodgerBlue;
      this.LabelProperties2.Location = new Point(12, 103);
      this.LabelProperties2.Name = "LabelProperties2";
      this.LabelProperties2.Size = new Size(65, 15);
      this.LabelProperties2.TabIndex = 5;
      this.LabelProperties2.Text = "Filename: ";
      this.TextBox1.BorderStyle = BorderStyle.None;
      this.TextBox1.Location = new Point(76, 105);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(626, 13);
      this.TextBox1.TabIndex = 7;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(684, 525);
      this.Controls.Add((Control) this.TextBox1);
      this.Controls.Add((Control) this.LabelProperties2);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.CheckBox1);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.RichTextBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(700, 564);
      this.Name = "Properties";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "App Properties";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [field: AccessedThroughProperty("RichTextBox1")]
    internal virtual RichTextBox RichTextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("LabelProperties")]
    internal virtual Label LabelProperties { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [field: AccessedThroughProperty("CheckBox1")]
    internal virtual CheckBox CheckBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [field: AccessedThroughProperty("LabelProperties2")]
    internal virtual Label LabelProperties2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TextBox1")]
    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void Button2_Click(object sender, EventArgs e) => this.Close();

    private void FormatText(string searchstring, FontStyle style)
    {
      for (int start = this.RichTextBox1.Find(searchstring, 0, RichTextBoxFinds.MatchCase); start != -1; start = this.RichTextBox1.Find(searchstring, checked (start + searchstring.Length), RichTextBoxFinds.MatchCase))
      {
        this.RichTextBox1.Select(start, searchstring.Length);
        this.RichTextBox1.SelectionFont = new Font(this.RichTextBox1.Font, style);
        this.RichTextBox1.SelectionColor = Color.DodgerBlue;
      }
      this.RichTextBox1.Select(0, 0);
    }

    private void Properties_Load(object sender, EventArgs e)
    {
      this.FormatText("displayName", FontStyle.Bold);
      this.FormatText("launchFile", FontStyle.Bold);
      this.FormatText("launchParameters", FontStyle.Bold);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.CheckBox1.Checked)
      {
        string str = ".BKP_" + DateTime.Now.ToString("yyyyMMddHHmmss");
        FileSystem.FileCopy(this.fname, this.fname + str);
        Log.WriteToLog("Backup made: " + this.fname + " -> " + this.fname + str);
      }
      if (!frmProperties.IsValidJson(this.RichTextBox1.Text) || Interaction.MsgBox((object) "JSON formatting looks OK, do you want to save this file?", MsgBoxStyle.YesNo | MsgBoxStyle.Question) != MsgBoxResult.Yes)
        return;
      StreamWriter streamWriter = new StreamWriter(this.fname);
      streamWriter.Write(this.RichTextBox1.Text);
      streamWriter.Close();
      Log.WriteToLog(this.fname + " was edited");
    }

    private static bool IsValidJson(string strInput)
    {
      strInput = strInput.Trim();
      bool flag;
      if (strInput.StartsWith("{") && strInput.EndsWith("}") || strInput.StartsWith("[") && strInput.EndsWith("]"))
      {
        try
        {
          JToken.Parse(strInput);
          flag = true;
        }
        catch (JsonReaderException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Exclamation, (object) "JSON validation failed");
          flag = false;
          ProjectData.ClearProjectError();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) Interaction.MsgBox((object) ex.ToString(), MsgBoxStyle.Exclamation, (object) "JSON validation failed");
          flag = false;
          ProjectData.ClearProjectError();
        }
      }
      else
        flag = false;
      return flag;
    }
  }
}
