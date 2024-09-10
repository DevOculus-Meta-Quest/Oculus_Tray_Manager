namespace OculusTrayTool
{
	// Token: 0x02000036 RID: 54
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmLinkPresets : global::System.Windows.Forms.Form
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x000236CC File Offset: 0x000218CC
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

		// Token: 0x060004D8 RID: 1240 RVA: 0x0002371C File Offset: 0x0002191C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Label1.Location = new global::System.Drawing.Point(12, 28);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(47, 15);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Name: ";
			this.TextBox1.Location = new global::System.Drawing.Point(65, 25);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new global::System.Drawing.Size(228, 21);
			this.TextBox1.TabIndex = 1;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(12, 83);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Cancel";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(218, 83);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 3;
			this.Button2.Text = "OK";
			this.Button2.UseVisualStyleBackColor = true;
			this.GroupBox1.Location = new global::System.Drawing.Point(5, 67);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(299, 10);
			this.GroupBox1.TabIndex = 4;
			this.GroupBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(310, 118);
			base.ControlBox = false;
			base.Controls.Add(this.GroupBox1);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.Label1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmLinkPresets";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Preset";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001CF RID: 463
		private global::System.ComponentModel.IContainer components;
	}
}
