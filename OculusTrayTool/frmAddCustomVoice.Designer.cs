namespace OculusTrayTool
{
	// Token: 0x02000018 RID: 24
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmAddCustomVoice : global::System.Windows.Forms.Form
	{
		// Token: 0x060001AE RID: 430 RVA: 0x00008164 File Offset: 0x00006364
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				bool flag = disposing && this.components != null;
				if (flag)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000081B4 File Offset: 0x000063B4
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmAddCustomVoice));
			this.Label2 = new global::System.Windows.Forms.Label();
			this.TextBoxSpokenCommand = new global::System.Windows.Forms.TextBox();
			this.Label4 = new global::System.Windows.Forms.Label();
			this.TextBoxButtonCombo = new global::System.Windows.Forms.TextBox();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.OpenFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.TextBoxSeconds = new global::System.Windows.Forms.TextBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.RadioButton2 = new global::System.Windows.Forms.RadioButton();
			this.RadioButton1 = new global::System.Windows.Forms.RadioButton();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.Label2.AutoSize = true;
			this.Label2.Location = new global::System.Drawing.Point(14, 91);
			this.Label2.Name = "Label2";
			this.Label2.Size = new global::System.Drawing.Size(63, 13);
			this.Label2.TabIndex = 0;
			this.Label2.Text = "When i say:";
			this.TextBoxSpokenCommand.Location = new global::System.Drawing.Point(128, 88);
			this.TextBoxSpokenCommand.Name = "TextBoxSpokenCommand";
			this.TextBoxSpokenCommand.Size = new global::System.Drawing.Size(226, 20);
			this.TextBoxSpokenCommand.TabIndex = 1;
			this.Label4.AutoSize = true;
			this.Label4.Location = new global::System.Drawing.Point(14, 126);
			this.Label4.Name = "Label4";
			this.Label4.Size = new global::System.Drawing.Size(108, 13);
			this.Label4.TabIndex = 14;
			this.Label4.Text = "Press Button/Combo:";
			this.TextBoxButtonCombo.Enabled = false;
			this.TextBoxButtonCombo.Location = new global::System.Drawing.Point(128, 123);
			this.TextBoxButtonCombo.Name = "TextBoxButtonCombo";
			this.TextBoxButtonCombo.Size = new global::System.Drawing.Size(226, 20);
			this.TextBoxButtonCombo.TabIndex = 15;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.Location = new global::System.Drawing.Point(330, 260);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(56, 23);
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
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(373, 242);
			this.GroupBox1.TabIndex = 18;
			this.GroupBox1.TabStop = false;
			this.Label3.AutoSize = true;
			this.Label3.Location = new global::System.Drawing.Point(281, 176);
			this.Label3.Name = "Label3";
			this.Label3.Size = new global::System.Drawing.Size(47, 13);
			this.Label3.TabIndex = 24;
			this.Label3.Text = "seconds";
			this.TextBoxSeconds.Location = new global::System.Drawing.Point(198, 174);
			this.TextBoxSeconds.Name = "TextBoxSeconds";
			this.TextBoxSeconds.Size = new global::System.Drawing.Size(76, 20);
			this.TextBoxSeconds.TabIndex = 23;
			this.TextBoxSeconds.Text = "00,300";
			this.Label1.AutoSize = true;
			this.Label1.Location = new global::System.Drawing.Point(145, 177);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(47, 13);
			this.Label1.TabIndex = 22;
			this.Label1.Text = "Hold for ";
			this.RadioButton2.AutoSize = true;
			this.RadioButton2.Location = new global::System.Drawing.Point(128, 200);
			this.RadioButton2.Name = "RadioButton2";
			this.RadioButton2.Size = new global::System.Drawing.Size(83, 17);
			this.RadioButton2.TabIndex = 21;
			this.RadioButton2.TabStop = true;
			this.RadioButton2.Text = "Press Key(s)";
			this.RadioButton2.UseVisualStyleBackColor = true;
			this.RadioButton1.AutoSize = true;
			this.RadioButton1.Location = new global::System.Drawing.Point(128, 154);
			this.RadioButton1.Name = "RadioButton1";
			this.RadioButton1.Size = new global::System.Drawing.Size(146, 17);
			this.RadioButton1.TabIndex = 20;
			this.RadioButton1.TabStop = true;
			this.RadioButton1.Text = "Press and Release Key(s)";
			this.RadioButton1.UseVisualStyleBackColor = true;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.Location = new global::System.Drawing.Point(12, 260);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(56, 23);
			this.Button1.TabIndex = 19;
			this.Button1.Text = "Cancel";
			this.Button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(398, 295);
			base.ControlBox = false;
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.GroupBox1);
			this.ForeColor = global::System.Drawing.Color.DodgerBlue;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmAddCustomVoice";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Command";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400004D RID: 77
		private global::System.ComponentModel.IContainer components;
	}
}
