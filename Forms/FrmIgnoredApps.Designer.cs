using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MetaQuestTrayTool.Forms
{
    partial class FrmIgnoredApps
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (FrmIgnoredApps));
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
      this.GroupBox1.Controls.Add(this.ListView1);
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
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.Name = "FrmIgnoredApps";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Ignored Apps";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Button2.Click += new EventHandler(this.Button2_Click);
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
        internal GroupBox GroupBox1;
        internal ListView ListView1;
        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader2;
        internal ColumnHeader ColumnHeader3;
    
    }
}
