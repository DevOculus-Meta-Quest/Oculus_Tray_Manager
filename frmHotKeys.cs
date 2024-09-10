// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmHotKeys
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections;
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
  public class frmHotKeys : Form
  {
    private IContainer components;
    public List<string> KeyList;
    public List<string> FunctionList;
    public Dictionary<int, string> HotKeyList;
    private bool isCapture;

    public frmHotKeys()
    {
      this.KeyDown += new KeyEventHandler(this.frmHotKeys_KeyDown);
      this.KeyList = new List<string>();
      this.FunctionList = new List<string>();
      this.HotKeyList = new Dictionary<int, string>();
      this.isCapture = false;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmHotKeys));
      this.ListView1 = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.DeleteHotKeyToolStripMenuItem = new ToolStripMenuItem();
      this.GroupBox3 = new GroupBox();
      this.Label1 = new Label();
      this.Button3 = new Button();
      this.Button2 = new Button();
      this.GroupBox1 = new GroupBox();
      this.ComboFunction = new ComboBox();
      this.Button1 = new Button();
      this.CheckBox1 = new CheckBox();
      this.ToolTip1 = new ToolTip(this.components);
      this.Button4 = new Button();
      this.ContextMenuStrip1.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ListView1.Columns.AddRange(new ColumnHeader[2]
      {
        this.ColumnHeader1,
        this.ColumnHeader3
      });
      this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
      this.ListView1.FullRowSelect = true;
      this.ListView1.GridLines = true;
      this.ListView1.HideSelection = false;
      this.ListView1.Location = new Point(13, 154);
      this.ListView1.MultiSelect = false;
      this.ListView1.Name = "ListView1";
      this.ListView1.Size = new Size(294, 166);
      this.ListView1.Sorting = SortOrder.Ascending;
      this.ListView1.TabIndex = 12;
      this.ListView1.UseCompatibleStateImageBehavior = false;
      this.ListView1.View = View.Details;
      this.ColumnHeader1.Text = "Function";
      this.ColumnHeader1.Width = 121;
      this.ColumnHeader3.Text = "Key";
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.DeleteHotKeyToolStripMenuItem
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(150, 26);
      this.DeleteHotKeyToolStripMenuItem.Name = "DeleteHotKeyToolStripMenuItem";
      this.DeleteHotKeyToolStripMenuItem.Size = new Size(149, 22);
      this.DeleteHotKeyToolStripMenuItem.Text = "Delete HotKey";
      this.GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.Label1);
      this.GroupBox3.Controls.Add((Control) this.Button3);
      this.GroupBox3.ForeColor = Color.DodgerBlue;
      this.GroupBox3.Location = new Point(12, 70);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(294, 49);
      this.GroupBox3.TabIndex = 11;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Press 'Capture' then a key to bind";
      this.Label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label1.Location = new Point(6, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(221, 18);
      this.Label1.TabIndex = 14;
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.Button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.ForeColor = Color.DodgerBlue;
      this.Button3.Location = new Point(233, 19);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(55, 23);
      this.Button3.TabIndex = 16;
      this.Button3.Text = "Capture";
      this.Button3.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Button2.Enabled = false;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(268, 125);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(38, 23);
      this.Button2.TabIndex = 15;
      this.Button2.Text = "Add";
      this.ToolTip1.SetToolTip((Control) this.Button2, "Add selected Function and Key binding");
      this.Button2.UseVisualStyleBackColor = true;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.ComboFunction);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(294, 52);
      this.GroupBox1.TabIndex = 9;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Select Function for the hotkey";
      this.ComboFunction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboFunction.FormattingEnabled = true;
      this.ComboFunction.Items.AddRange(new object[15]
      {
        (object) "ASW 45",
        (object) "ASW Auto",
        (object) "ASW Off",
        (object) "Close HUD",
        (object) "Exit running VR app",
        (object) "HUD Application Render",
        (object) "HUD ASW Mode",
        (object) "HUD Compositor Render",
        (object) "HUD Latency",
        (object) "HUD Performance",
        (object) "HUD Pixel Density",
        (object) "Next ASW Mode",
        (object) "Next HUD",
        (object) "Previous ASW Mode",
        (object) "Previous HUD"
      });
      this.ComboFunction.Location = new Point(6, 19);
      this.ComboFunction.Name = "ComboFunction";
      this.ComboFunction.Size = new Size(276, 21);
      this.ComboFunction.Sorted = true;
      this.ComboFunction.TabIndex = 0;
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Popup;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(261, 326);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(45, 23);
      this.Button1.TabIndex = 8;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.CheckBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.ForeColor = Color.DodgerBlue;
      this.CheckBox1.Location = new Point(11, 330);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size(187, 17);
      this.CheckBox1.TabIndex = 13;
      this.CheckBox1.Text = "Voice Confirmation for ASW Mode";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.Button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Button4.Enabled = false;
      this.Button4.FlatStyle = FlatStyle.Flat;
      this.Button4.ForeColor = Color.DodgerBlue;
      this.Button4.Location = new Point(12, 125);
      this.Button4.Name = "Button4";
      this.Button4.Size = new Size(48, 23);
      this.Button4.TabIndex = 16;
      this.Button4.Text = "Delete";
      this.ToolTip1.SetToolTip((Control) this.Button4, "Add selected Function and Key binding");
      this.Button4.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(319, 361);
      this.Controls.Add((Control) this.Button4);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.CheckBox1);
      this.Controls.Add((Control) this.ListView1);
      this.Controls.Add((Control) this.GroupBox3);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.Button1);
      this.ForeColor = Color.DodgerBlue;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(335, 400);
      this.Name = nameof (frmHotKeys);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Configure Hot Keys";
      this.ContextMenuStrip1.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual ListView ListView1
    {
      get => this._ListView1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.ListView1_MouseMove);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.ListView1_MouseDown);
        ListView listView1_1 = this._ListView1;
        if (listView1_1 != null)
        {
          listView1_1.MouseMove -= mouseEventHandler1;
          listView1_1.MouseDown -= mouseEventHandler2;
        }
        this._ListView1 = value;
        ListView listView1_2 = this._ListView1;
        if (listView1_2 == null)
          return;
        listView1_2.MouseMove += mouseEventHandler1;
        listView1_2.MouseDown += mouseEventHandler2;
      }
    }

    [field: AccessedThroughProperty("ColumnHeader1")]
    internal virtual ColumnHeader ColumnHeader1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader3")]
    internal virtual ColumnHeader ColumnHeader3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox3")]
    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox ComboFunction
    {
      get => this._ComboFunction;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.ComboFunction_KeyPress);
        ComboBox comboFunction1 = this._ComboFunction;
        if (comboFunction1 != null)
          comboFunction1.KeyPress -= pressEventHandler;
        this._ComboFunction = value;
        ComboBox comboFunction2 = this._ComboFunction;
        if (comboFunction2 == null)
          return;
        comboFunction2.KeyPress += pressEventHandler;
      }
    }

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

    internal virtual ContextMenuStrip ContextMenuStrip1
    {
      get => this._ContextMenuStrip1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.ContextMenuStrip1_Opening);
        ContextMenuStrip contextMenuStrip1_1 = this._ContextMenuStrip1;
        if (contextMenuStrip1_1 != null)
          contextMenuStrip1_1.Opening -= cancelEventHandler;
        this._ContextMenuStrip1 = value;
        ContextMenuStrip contextMenuStrip1_2 = this._ContextMenuStrip1;
        if (contextMenuStrip1_2 == null)
          return;
        contextMenuStrip1_2.Opening += cancelEventHandler;
      }
    }

    internal virtual ToolStripMenuItem DeleteHotKeyToolStripMenuItem
    {
      get => this._DeleteHotKeyToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.DeleteHotKeyToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._DeleteHotKeyToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._DeleteHotKeyToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._DeleteHotKeyToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual CheckBox CheckBox1
    {
      get => this._CheckBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBox1_CheckedChanged);
        CheckBox checkBox1_1 = this._CheckBox1;
        if (checkBox1_1 != null)
          checkBox1_1.CheckedChanged -= eventHandler;
        this._CheckBox1 = value;
        CheckBox checkBox1_2 = this._CheckBox1;
        if (checkBox1_2 == null)
          return;
        checkBox1_2.CheckedChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [field: AccessedThroughProperty("ToolTip1")]
    internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    private void Button1_Click(object sender, EventArgs e)
    {
      string str = "";
      int num = checked (this.ListView1.Items.Count - 1);
      int index = 0;
      while (index <= num)
      {
        str = str + this.ListView1.Items[index].Text + "," + this.ListView1.Items[index].SubItems[1].Text + ";";
        checked { ++index; }
      }
      MySettingsProperty.Settings.HotKeyCombos = str.TrimEnd(';');
      MySettingsProperty.Settings.Save();
      GetConfig.GetHotKeys();
      this.Close();
    }

    private void DeleteHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.DeleteHotKey();
    }

    private void DeleteHotKey()
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      this.ListView1.Items.RemoveAt(this.ListView1.SelectedIndices[0]);
      this.KeyList.Clear();
      this.FunctionList.Clear();
      string str = "";
      int num = checked (this.ListView1.Items.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this.KeyList.Add(this.ListView1.Items[index].SubItems[1].Text);
        this.FunctionList.Add(this.ListView1.Items[index].Text);
        str = str + this.ListView1.Items[index].Text + "," + this.ListView1.Items[index].SubItems[1].Text + ";";
        checked { ++index; }
      }
      MySettingsProperty.Settings.HotKeyCombos = str.TrimEnd(';');
      MySettingsProperty.Settings.Save();
    }

    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
      ListViewItem itemAt = this.ListView1.GetItemAt(e.X, e.Y);
      try
      {
        foreach (ListViewItem listViewItem in this.ListView1.Items)
        {
          if (itemAt != null)
            itemAt.Selected = true;
          else
            listViewItem.Selected = false;
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count > 0)
        this.ContextMenuStrip1.Enabled = true;
      else
        this.ContextMenuStrip1.Enabled = false;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.HotKeyVoiceConfirmation = this.CheckBox1.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (Operators.CompareString(this.ComboFunction.Text, "", false) == 0)
        return;
      if (!this.FunctionList.Contains(this.ComboFunction.Text))
      {
        if (!this.KeyList.Contains(this.Label1.Text))
        {
          this.KeyList.Add(this.Label1.Text);
          this.FunctionList.Add(this.ComboFunction.Text);
          ListViewItem listViewItem = new ListViewItem();
          this.ListView1.Items.Add(this.ComboFunction.Text).SubItems.Add(this.Label1.Text);
        }
        else
        {
          int num1 = (int) Interaction.MsgBox((object) "The selected key is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, (object) "Error");
        }
      }
      else
      {
        int num2 = (int) Interaction.MsgBox((object) "The selected function is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, (object) "Error");
      }
      this.isCapture = false;
      this.Label1.Text = "";
      this.ComboFunction.Text = "";
      this.Button3.Enabled = true;
    }

    private void frmHotKeys_KeyDown(object sender, KeyEventArgs e)
    {
      if (!this.isCapture)
        return;
      this.Label1.Text = e.KeyCode.ToString().ToUpper();
      this.Button3.Enabled = true;
      this.Button2.Enabled = true;
      this.isCapture = false;
    }

    private void ComboFunction_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void Button3_Click(object sender, EventArgs e)
    {
      this.isCapture = true;
      this.Button3.Enabled = false;
      this.Button2.Enabled = false;
      this.Label1.Text = "Press any key to bind";
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      this.DeleteHotKey();
      this.Button4.Enabled = false;
    }

    private void ListView1_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count > 0)
        this.Button4.Enabled = true;
      else
        this.Button4.Enabled = false;
    }
  }
}
