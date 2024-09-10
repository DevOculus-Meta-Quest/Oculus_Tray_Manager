namespace OculusTrayTool
{
	// Token: 0x02000019 RID: 25
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmAddVoiceProfile : global::System.Windows.Forms.Form
	{
		// Token: 0x060001CE RID: 462 RVA: 0x00008B90 File Offset: 0x00006D90
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

		// Token: 0x060001CF RID: 463 RVA: 0x00008BE0 File Offset: 0x00006DE0
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.ComboBox1 = new global::System.Windows.Forms.ComboBox();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Label1.Location = new global::System.Drawing.Point(10, 22);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(70, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Profile Name:";
			this.TextBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.TextBox1.Location = new global::System.Drawing.Point(131, 19);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new global::System.Drawing.Size(217, 20);
			this.TextBox1.TabIndex = 1;
			this.Label2.AutoSize = true;
			this.Label2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Label2.Location = new global::System.Drawing.Point(10, 55);
			this.Label2.Name = "Label2";
			this.Label2.Size = new global::System.Drawing.Size(119, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Load with Game Profile:";
			this.ComboBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Location = new global::System.Drawing.Point(131, 52);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new global::System.Drawing.Size(217, 21);
			this.ComboBox1.TabIndex = 3;
			this.GroupBox1.Controls.Add(this.ComboBox1);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(363, 94);
			this.GroupBox1.TabIndex = 4;
			this.GroupBox1.TabStop = false;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(12, 112);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 5;
			this.Button1.Text = "Cancel";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(300, 112);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 6;
			this.Button2.Text = "Save";
			this.Button2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(387, 146);
			base.ControlBox = false;
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			base.Name = "frmAddVoiceProfile";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Profile";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400005E RID: 94
		private global::System.ComponentModel.IContainer components;
	}
}
