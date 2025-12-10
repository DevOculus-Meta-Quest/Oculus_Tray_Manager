using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmProperties
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmProperties));
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
      this.GroupBox1.Controls.Add(this.LabelProperties);
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
      this.LabelProperties.Text = resources.GetString("LabelProperties.Text");
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
      this.Controls.Add(this.TextBox1);
      this.Controls.Add(this.LabelProperties2);
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.CheckBox1);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Controls.Add(this.RichTextBox1);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
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

        #endregion

    internal Button Button1;
    internal Button Button2;
        internal RichTextBox RichTextBox1;
        internal GroupBox GroupBox1;
        internal Label LabelProperties;
        internal CheckBox CheckBox1;
        internal Label LabelProperties2;
        internal TextBox TextBox1;
    
    }
}