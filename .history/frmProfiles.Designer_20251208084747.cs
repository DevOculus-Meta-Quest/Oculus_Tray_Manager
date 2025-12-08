namespace OculusTrayTool
{
    partial class frmProfiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.Button2 = new System.Windows.Forms.Button();
            // Defined based on usage in frmProfiles.cs
            this.Label16 = new System.Windows.Forms.Label();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrackBar1 = new System.Windows.Forms.TrackBar();
            this.ComboResolution = new System.Windows.Forms.ComboBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            
            // SuspendLayout for performance
            this.SuspendLayout();

            // 
            // ListView1
            // 
            this.ListView1.Location = new System.Drawing.Point(12, 12);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(200, 100);
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;

            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(12, 120);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Button2";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);

            // 
            // frmProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.ListView1);
            this.Name = "frmProfiles";
            this.Text = "Profiles";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView ListView1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.TrackBar TrackBar1;
        internal System.Windows.Forms.ComboBox ComboResolution;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
    }
}
