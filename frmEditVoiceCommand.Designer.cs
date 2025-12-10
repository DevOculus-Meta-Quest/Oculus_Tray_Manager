using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmEditVoiceCommand
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
      this.Label1 = new Label();
      this.TextBoxPhrase = new TextBox();
      this.Label2 = new Label();
      this.LabelAction = new Label();
      this.ComboEnabled = new ComboBox();
      this.Label3 = new Label();
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(15, 30);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(40, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Action:";
      this.TextBoxPhrase.Location = new Point(64, 53);
      this.TextBoxPhrase.Name = "TextBoxPhrase";
      this.TextBoxPhrase.Size = new Size(249, 20);
      this.TextBoxPhrase.TabIndex = 3;
      this.Label2.AutoSize = true;
      this.Label2.Location = new Point(15, 56);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(43, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Phrase:";
      this.LabelAction.AutoSize = true;
      this.LabelAction.ForeColor = Color.Black;
      this.LabelAction.Location = new Point(61, 30);
      this.LabelAction.Name = "LabelAction";
      this.LabelAction.Size = new Size(37, 13);
      this.LabelAction.TabIndex = 4;
      this.LabelAction.Text = "Action";
      this.ComboEnabled.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboEnabled.FormattingEnabled = true;
      this.ComboEnabled.Items.AddRange(new object[2]
      {
        (object) "True",
        (object) "False"
      });
      this.ComboEnabled.Location = new Point(64, 79);
      this.ComboEnabled.Name = "ComboEnabled";
      this.ComboEnabled.Size = new Size(121, 21);
      this.ComboEnabled.TabIndex = 5;
      this.Label3.AutoSize = true;
      this.Label3.Location = new Point(15, 82);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(49, 13);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Enabled:";
      this.GroupBox1.Controls.Add(this.TextBoxPhrase);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Controls.Add(this.ComboEnabled);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.LabelAction);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(334, 132);
      this.GroupBox1.TabIndex = 7;
      this.GroupBox1.TabStop = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(271, 150);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 8;
      this.Button1.Text = "Save";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Location = new Point(12, 150);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 9;
      this.Button2.Text = "Cancel";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(356, 179);
      this.ControlBox = false;
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.ForeColor = Color.DodgerBlue;
      this.Name = "frmEditVoiceCommand";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Edit Voice Command";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Button2.Click += new EventHandler(this.Button2_Click);
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
        internal Label Label1;
        internal TextBox TextBoxPhrase;
        internal Label Label2;
        internal Label LabelAction;
        internal ComboBox ComboEnabled;
        internal Label Label3;
        internal GroupBox GroupBox1;
    
    }
}