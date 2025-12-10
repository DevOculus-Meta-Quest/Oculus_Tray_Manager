using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmHotKeys
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmHotKeys));
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
      this.GroupBox3.Controls.Add(this.Label1);
      this.GroupBox3.Controls.Add(this.Button3);
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
      this.ToolTip1.SetToolTip(this.Button2, "Add selected Function and Key binding");
      this.Button2.UseVisualStyleBackColor = true;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add(this.ComboFunction);
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
      this.ToolTip1.SetToolTip(this.Button4, "Add selected Function and Key binding");
      this.Button4.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(319, 361);
      this.Controls.Add(this.Button4);
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.CheckBox1);
      this.Controls.Add(this.ListView1);
      this.Controls.Add(this.GroupBox3);
      this.Controls.Add(this.GroupBox1);
      this.Controls.Add(this.Button1);
      this.ForeColor = Color.DodgerBlue;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(335, 400);
      this.Name = "frmHotKeys";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Configure Hot Keys";
      this.ContextMenuStrip1.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    
      this.ListView1.MouseMove += new MouseEventHandler(this.ListView1_MouseMove);
      this.ListView1.MouseDown += new MouseEventHandler(this.ListView1_MouseDown);
      this.ComboFunction.KeyPress += new KeyPressEventHandler(this.ComboFunction_KeyPress);
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.ContextMenuStrip1.Opening += new CancelEventHandler(this.ContextMenuStrip1_Opening);
      this.DeleteHotKeyToolStripMenuItem.Click += new EventHandler(this.DeleteHotKeyToolStripMenuItem_Click);
      this.CheckBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
      this.Button2.Click += new EventHandler(this.Button2_Click);
      this.Button3.Click += new EventHandler(this.Button3_Click);
      this.Button4.Click += new EventHandler(this.Button4_Click);
    }

        #endregion

    internal ListView ListView1;
    internal ComboBox ComboFunction;
    internal Button Button1;
    internal ContextMenuStrip ContextMenuStrip1;
    internal ToolStripMenuItem DeleteHotKeyToolStripMenuItem;
    internal CheckBox CheckBox1;
    internal Button Button2;
    internal Button Button3;
    internal Button Button4;
        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader3;
        internal GroupBox GroupBox3;
        internal Label Label1;
        internal GroupBox GroupBox1;
        internal ToolTip ToolTip1;
    
    }
}