namespace OculusTrayTool
{
	// Token: 0x02000021 RID: 33
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmHomeless : global::System.Windows.Forms.Form
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x0001167C File Offset: 0x0000F87C
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

		// Token: 0x060002F4 RID: 756 RVA: 0x000116CC File Offset: 0x0000F8CC
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.BtnBrowseMusic = new global::System.Windows.Forms.Button();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.BtnColor = new global::System.Windows.Forms.Button();
			this.ComboMusic = new global::System.Windows.Forms.ComboBox();
			this.NumericVolume = new global::System.Windows.Forms.NumericUpDown();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.ColorDialog1 = new global::System.Windows.Forms.ColorDialog();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			this.GroupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.NumericVolume).BeginInit();
			base.SuspendLayout();
			this.GroupBox1.Controls.Add(this.CheckBox1);
			this.GroupBox1.Controls.Add(this.BtnBrowseMusic);
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Controls.Add(this.BtnColor);
			this.GroupBox1.Controls.Add(this.ComboMusic);
			this.GroupBox1.Controls.Add(this.NumericVolume);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(348, 133);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.BtnBrowseMusic.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.BtnBrowseMusic.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.BtnBrowseMusic.Location = new global::System.Drawing.Point(258, 44);
			this.BtnBrowseMusic.Name = "BtnBrowseMusic";
			this.BtnBrowseMusic.Size = new global::System.Drawing.Size(71, 23);
			this.BtnBrowseMusic.TabIndex = 8;
			this.BtnBrowseMusic.Text = "Add More";
			this.BtnBrowseMusic.UseVisualStyleBackColor = true;
			this.TextBox1.Location = new global::System.Drawing.Point(131, 17);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.Size = new global::System.Drawing.Size(121, 20);
			this.TextBox1.TabIndex = 7;
			this.BtnColor.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.BtnColor.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.BtnColor.Location = new global::System.Drawing.Point(258, 15);
			this.BtnColor.Name = "BtnColor";
			this.BtnColor.Size = new global::System.Drawing.Size(71, 23);
			this.BtnColor.TabIndex = 6;
			this.BtnColor.Text = "Pick color";
			this.BtnColor.UseVisualStyleBackColor = true;
			this.ComboMusic.BackColor = global::System.Drawing.Color.AliceBlue;
			this.ComboMusic.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboMusic.DropDownWidth = 200;
			this.ComboMusic.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.ComboMusic.FormattingEnabled = true;
			this.ComboMusic.Items.AddRange(new object[] { "None" });
			this.ComboMusic.Location = new global::System.Drawing.Point(131, 46);
			this.ComboMusic.Name = "ComboMusic";
			this.ComboMusic.Size = new global::System.Drawing.Size(121, 21);
			this.ComboMusic.Sorted = true;
			this.ComboMusic.TabIndex = 4;
			this.NumericVolume.Location = new global::System.Drawing.Point(132, 79);
			this.NumericVolume.Name = "NumericVolume";
			this.NumericVolume.Size = new global::System.Drawing.Size(120, 20);
			this.NumericVolume.TabIndex = 3;
			this.Label3.AutoSize = true;
			this.Label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label3.Location = new global::System.Drawing.Point(16, 81);
			this.Label3.Name = "Label3";
			this.Label3.Size = new global::System.Drawing.Size(103, 15);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Music volume %: ";
			this.Label2.AutoSize = true;
			this.Label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label2.Location = new global::System.Drawing.Point(15, 49);
			this.Label2.Name = "Label2";
			this.Label2.Size = new global::System.Drawing.Size(112, 15);
			this.Label2.TabIndex = 1;
			this.Label2.Text = "Background music:";
			this.Label1.AutoSize = true;
			this.Label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.Location = new global::System.Drawing.Point(16, 20);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(109, 15);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Background color: ";
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(12, 151);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(55, 25);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Cancel";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(305, 151);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(55, 25);
			this.Button2.TabIndex = 2;
			this.Button2.Text = "OK";
			this.Button2.UseVisualStyleBackColor = true;
			this.ColorDialog1.FullOpen = true;
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new global::System.Drawing.Point(16, 105);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
			this.CheckBox1.Size = new global::System.Drawing.Size(130, 17);
			this.CheckBox1.TabIndex = 9;
			this.CheckBox1.Text = "   :Automatically patch";
			this.CheckBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(368, 183);
			base.ControlBox = false;
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "frmHomeless";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configure Oculus Homeless";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.NumericVolume).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000E4 RID: 228
		private global::System.ComponentModel.IContainer components;
	}
}
