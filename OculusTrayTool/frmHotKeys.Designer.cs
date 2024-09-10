namespace OculusTrayTool
{
	// Token: 0x02000022 RID: 34
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmHotKeys : global::System.Windows.Forms.Form
	{
		// Token: 0x06000316 RID: 790 RVA: 0x00012950 File Offset: 0x00010B50
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

		// Token: 0x06000317 RID: 791 RVA: 0x000129A0 File Offset: 0x00010BA0
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmHotKeys));
			this.ListView1 = new global::System.Windows.Forms.ListView();
			this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.ContextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.DeleteHotKeyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.GroupBox3 = new global::System.Windows.Forms.GroupBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Button3 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.ComboFunction = new global::System.Windows.Forms.ComboBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			this.ToolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.Button4 = new global::System.Windows.Forms.Button();
			this.ContextMenuStrip1.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.ListView1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.ListView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader3 });
			this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
			this.ListView1.FullRowSelect = true;
			this.ListView1.GridLines = true;
			this.ListView1.HideSelection = false;
			this.ListView1.Location = new global::System.Drawing.Point(13, 154);
			this.ListView1.MultiSelect = false;
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new global::System.Drawing.Size(294, 166);
			this.ListView1.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.ListView1.TabIndex = 12;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader1.Text = "Function";
			this.ColumnHeader1.Width = 121;
			this.ColumnHeader3.Text = "Key";
			this.ContextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.DeleteHotKeyToolStripMenuItem });
			this.ContextMenuStrip1.Name = "ContextMenuStrip1";
			this.ContextMenuStrip1.Size = new global::System.Drawing.Size(150, 26);
			this.DeleteHotKeyToolStripMenuItem.Name = "DeleteHotKeyToolStripMenuItem";
			this.DeleteHotKeyToolStripMenuItem.Size = new global::System.Drawing.Size(149, 22);
			this.DeleteHotKeyToolStripMenuItem.Text = "Delete HotKey";
			this.GroupBox3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox3.Controls.Add(this.Label1);
			this.GroupBox3.Controls.Add(this.Button3);
			this.GroupBox3.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox3.Location = new global::System.Drawing.Point(12, 70);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new global::System.Drawing.Size(294, 49);
			this.GroupBox3.TabIndex = 11;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Press 'Capture' then a key to bind";
			this.Label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.Label1.Location = new global::System.Drawing.Point(6, 24);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(221, 18);
			this.Label1.TabIndex = 14;
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.Button3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button3.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button3.Location = new global::System.Drawing.Point(233, 19);
			this.Button3.Name = "Button3";
			this.Button3.Size = new global::System.Drawing.Size(55, 23);
			this.Button3.TabIndex = 16;
			this.Button3.Text = "Capture";
			this.Button3.UseVisualStyleBackColor = true;
			this.Button2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button2.Enabled = false;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(268, 125);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(38, 23);
			this.Button2.TabIndex = 15;
			this.Button2.Text = "Add";
			this.ToolTip1.SetToolTip(this.Button2, "Add selected Function and Key binding");
			this.Button2.UseVisualStyleBackColor = true;
			this.GroupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox1.Controls.Add(this.ComboFunction);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(294, 52);
			this.GroupBox1.TabIndex = 9;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Select Function for the hotkey";
			this.ComboFunction.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.ComboFunction.FormattingEnabled = true;
			this.ComboFunction.Items.AddRange(new object[]
			{
				"ASW 45", "ASW Auto", "ASW Off", "Close HUD", "Exit running VR app", "HUD Application Render", "HUD ASW Mode", "HUD Compositor Render", "HUD Latency", "HUD Performance",
				"HUD Pixel Density", "Next ASW Mode", "Next HUD", "Previous ASW Mode", "Previous HUD"
			});
			this.ComboFunction.Location = new global::System.Drawing.Point(6, 19);
			this.ComboFunction.Name = "ComboFunction";
			this.ComboFunction.Size = new global::System.Drawing.Size(276, 21);
			this.ComboFunction.Sorted = true;
			this.ComboFunction.TabIndex = 0;
			this.Button1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(261, 326);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(45, 23);
			this.Button1.TabIndex = 8;
			this.Button1.Text = "OK";
			this.Button1.UseVisualStyleBackColor = true;
			this.CheckBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.CheckBox1.Location = new global::System.Drawing.Point(11, 330);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new global::System.Drawing.Size(187, 17);
			this.CheckBox1.TabIndex = 13;
			this.CheckBox1.Text = "Voice Confirmation for ASW Mode";
			this.CheckBox1.UseVisualStyleBackColor = true;
			this.Button4.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button4.Enabled = false;
			this.Button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button4.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button4.Location = new global::System.Drawing.Point(12, 125);
			this.Button4.Name = "Button4";
			this.Button4.Size = new global::System.Drawing.Size(48, 23);
			this.Button4.TabIndex = 16;
			this.Button4.Text = "Delete";
			this.ToolTip1.SetToolTip(this.Button4, "Add selected Function and Key binding");
			this.Button4.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(319, 361);
			base.Controls.Add(this.Button4);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.CheckBox1);
			base.Controls.Add(this.ListView1);
			base.Controls.Add(this.GroupBox3);
			base.Controls.Add(this.GroupBox1);
			base.Controls.Add(this.Button1);
			this.ForeColor = global::System.Drawing.Color.DodgerBlue;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(335, 400);
			base.Name = "frmHotKeys";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configure Hot Keys";
			this.ContextMenuStrip1.ResumeLayout(false);
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000F2 RID: 242
		private global::System.ComponentModel.IContainer components;
	}
}
