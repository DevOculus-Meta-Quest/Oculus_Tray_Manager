using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmAddCustomVoice
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmAddCustomVoice));
      this.Label2 = new Label();
      this.TextBoxSpokenCommand = new TextBox();
      this.Label4 = new Label();
      this.TextBoxButtonCombo = new TextBox();
      this.Button2 = new Button();
      this.OpenFileDialog1 = new OpenFileDialog();
      this.GroupBox1 = new GroupBox();
      this.Label3 = new Label();
      this.TextBoxSeconds = new TextBox();
      this.Label1 = new Label();
      this.RadioButton2 = new RadioButton();
      this.RadioButton1 = new RadioButton();
      this.Button1 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label2.AutoSize = true;
      this.Label2.Location = new Point(14, 91);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(63, 13);
      this.Label2.TabIndex = 0;
      this.Label2.Text = "When i say:";
      this.TextBoxSpokenCommand.Location = new Point(128, 88);
      this.TextBoxSpokenCommand.Name = "TextBoxSpokenCommand";
      this.TextBoxSpokenCommand.Size = new Size(226, 20);
      this.TextBoxSpokenCommand.TabIndex = 1;
      this.Label4.AutoSize = true;
      this.Label4.Location = new Point(14, 126);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(108, 13);
      this.Label4.TabIndex = 14;
      this.Label4.Text = "Press Button/Combo:";
      this.TextBoxButtonCombo.Enabled = false;
      this.TextBoxButtonCombo.Location = new Point(128, 123);
      this.TextBoxButtonCombo.Name = "TextBoxButtonCombo";
      this.TextBoxButtonCombo.Size = new Size(226, 20);
      this.TextBoxButtonCombo.TabIndex = 15;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Location = new Point(330, 260);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(56, 23);
      this.Button2.TabIndex = 16;
      this.Button2.Text = "Save";
      this.Button2.UseVisualStyleBackColor = true;
      this.OpenFileDialog1.Filter = "Scripts|*.cmd;*.bat|Executables|*.exe";
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.TextBoxSeconds);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Controls.Add(this.RadioButton2);
      this.GroupBox1.Controls.Add(this.RadioButton1);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.TextBoxButtonCombo);
      this.GroupBox1.Controls.Add(this.TextBoxSpokenCommand);
      this.GroupBox1.Controls.Add(this.Label4);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(373, 242);
      this.GroupBox1.TabIndex = 18;
      this.GroupBox1.TabStop = false;
      this.Label3.AutoSize = true;
      this.Label3.Location = new Point(281, 176);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(47, 13);
      this.Label3.TabIndex = 24;
      this.Label3.Text = "seconds";
      this.TextBoxSeconds.Location = new Point(198, 174);
      this.TextBoxSeconds.Name = "TextBoxSeconds";
      this.TextBoxSeconds.Size = new Size(76, 20);
      this.TextBoxSeconds.TabIndex = 23;
      this.TextBoxSeconds.Text = "00,300";
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(145, 177);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(47, 13);
      this.Label1.TabIndex = 22;
      this.Label1.Text = "Hold for ";
      this.RadioButton2.AutoSize = true;
      this.RadioButton2.Location = new Point(128, 200);
      this.RadioButton2.Name = "RadioButton2";
      this.RadioButton2.Size = new Size(83, 17);
      this.RadioButton2.TabIndex = 21;
      this.RadioButton2.TabStop = true;
      this.RadioButton2.Text = "Press Key(s)";
      this.RadioButton2.UseVisualStyleBackColor = true;
      this.RadioButton1.AutoSize = true;
      this.RadioButton1.Location = new Point(128, 154);
      this.RadioButton1.Name = "RadioButton1";
      this.RadioButton1.Size = new Size(146, 17);
      this.RadioButton1.TabIndex = 20;
      this.RadioButton1.TabStop = true;
      this.RadioButton1.Text = "Press and Release Key(s)";
      this.RadioButton1.UseVisualStyleBackColor = true;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(12, 260);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(56, 23);
      this.Button1.TabIndex = 19;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(398, 295);
      this.ControlBox = false;
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.GroupBox1);
      this.ForeColor = Color.DodgerBlue;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.Name = "frmAddCustomVoice";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Command";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    
      this.Button2.Click += new EventHandler(this.Button2_Click);
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.TextBoxSeconds.KeyPress += new KeyPressEventHandler(this.TextBoxSeconds_KeyPress);
    }

        #endregion

    internal Button Button2;
    internal Button Button1;
    internal TextBox TextBoxSeconds;
        internal Label Label2;
        internal TextBox TextBoxSpokenCommand;
        internal Label Label4;
        internal TextBox TextBoxButtonCombo;
        internal OpenFileDialog OpenFileDialog1;
        internal GroupBox GroupBox1;
        internal Label Label3;
        internal Label Label1;
        internal RadioButton RadioButton2;
        internal RadioButton RadioButton1;
    
    }
}