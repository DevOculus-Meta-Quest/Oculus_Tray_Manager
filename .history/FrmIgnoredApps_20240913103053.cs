// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.FrmIgnoredApps
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class FrmIgnoredApps : Form
  {
    private IContainer components;

    public FrmIgnoredApps()
    {
      this.Load += new EventHandler(this.FrmIgnoredApps_Load);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmIgnoredApps));
      this.GroupBox1 = new GroupBox();
      this.ListView1 = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.ListView1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(839, 377);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Ignored Apps - Select to include";
      this.ListView1.CheckBoxes = true;
      this.ListView1.Columns.AddRange(new ColumnHeader[3]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3
      });
      this.ListView1.Dock = DockStyle.Fill;
      this.ListView1.ForeColor = Color.DodgerBlue;
      this.ListView1.FullRowSelect = true;
      this.ListView1.GridLines = true;
      this.ListView1.Location = new Point(3, 16);
      this.ListView1.Name = "ListView1";
      this.ListView1.Size = new Size(833, 358);
      this.ListView1.Sorting = SortOrder.Ascending;
      this.ListView1.TabIndex = 0;
      this.ListView1.UseCompatibleStateImageBehavior = false;
      this.ListView1.View = View.Details;
      this.ColumnHeader1.Text = "Name";
      this.ColumnHeader1.Width = 158;
      this.ColumnHeader2.Text = "Launch Parameters";
      this.ColumnHeader2.Width = 254;
      this.ColumnHeader3.Text = "Path";
      this.ColumnHeader3.Width = 414;
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(773, 395);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(15, 395);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(107, 23);
      this.Button2.TabIndex = 2;
      this.Button2.Text = "Include Selected";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(863, 430);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FrmIgnoredApps);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Ignored Apps";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ListView1")]
    internal virtual ListView ListView1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader1")]
    internal virtual ColumnHeader ColumnHeader1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader2")]
    internal virtual ColumnHeader ColumnHeader2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader3")]
    internal virtual ColumnHeader ColumnHeader3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
      try
      {
        foreach (ListViewItem checkedItem in this.ListView1.CheckedItems)
        {
          OTTDB.RemoveIgnoredApp(Conversions.ToString(checkedItem.Tag));
          OTTDB.AddIncludedApp(Conversions.ToString(checkedItem.Tag));
          Log.WriteToLog("'" + checkedItem.Text + "' is not being ignored anymore");
          MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + checkedItem.Text + "' is not being ignored anymore");
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.Cursor = Cursors.WaitCursor;
      this.GetIgnoredApps();
      MyProject.Forms.FrmMain.ignoredApps = (List<string>) OTTDB.GetIgnoredApps();
      MyProject.Forms.FrmMain.includedApps = (List<string>) OTTDB.GetIncludedApps();
      MyProject.Forms.frmLibrary.PopulateList();
      this.Cursor = Cursors.Default;
      this.Close();
    }

    private void FrmIgnoredApps_Load(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      frmLibrary.SetDoubleBuffering((Control) this.ListView1, true);
      this.GetIgnoredApps();
      this.Cursor = Cursors.Default;
    }

    private void GetIgnoredApps()
    {
      this.ListView1.Items.Clear();
      List<string> ignoredApps = (List<string>) OTTDB.GetIgnoredApps();
      try
      {
        foreach (string path in ignoredApps)
        {
          if (File.Exists(path))
          {
            JObject jobject = JObject.Parse(File.ReadAllText(path));
            jobject.SelectToken("canonicalName").ToString();
            string text = "";
            string str1 = "";
            string str2 = "";
            List<JToken> list = jobject.Children().ToList<JToken>();
            try
            {
              foreach (JProperty jproperty in list)
              {
                jproperty.CreateReader();
                string name = jproperty.Name;
                if (Operators.CompareString(name, "displayName", false) != 0)
                {
                  if (Operators.CompareString(name, "launchFile", false) != 0)
                  {
                    if (Operators.CompareString(name, "launchParameters", false) == 0)
                      str2 = jproperty.Value.ToString();
                  }
                  else
                  {
                    string fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
                    str1 = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
                    if (text.ToLower().EndsWith(".exe") | Operators.CompareString(text.ToLower(), "unknown app", false) == 0)
                      text = Path.GetFileNameWithoutExtension(fileName);
                  }
                }
                else
                  text = jproperty.Value.ToString();
              }
            }
            finally
            {
              List<JToken>.Enumerator enumerator;
              enumerator.Dispose();
            }
            this.ListView1.Items.Add(new ListViewItem(text)
            {
              SubItems = {
                str2,
                str1
              },
              Tag = (object) path
            });
          }
        }
      }
      finally
      {
        List<string>.Enumerator enumerator;
        enumerator.Dispose();
      }
    }
  }
}
