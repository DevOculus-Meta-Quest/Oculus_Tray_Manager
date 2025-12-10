using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class FrmSetFallback
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (FrmSetFallback));
      this.GroupBox1 = new GroupBox();
      this.ComboBox3 = new ComboBox();
      this.Label8 = new Label();
      this.ComboBox4 = new ComboBox();
      this.Label9 = new Label();
      this.GroupBox4 = new GroupBox();
      this.GroupBox5 = new GroupBox();
      this.Label10 = new Label();
      this.ComboBox5 = new ComboBox();
      this.ComboBox6 = new ComboBox();
      this.Label11 = new Label();
      this.Label12 = new Label();
      this.ComboCommMicFallback = new ComboBox();
      this.Label7 = new Label();
      this.ComboCommFallback = new ComboBox();
      this.Label6 = new Label();
      this.GroupBox3 = new GroupBox();
      this.GroupBox2 = new GroupBox();
      this.Label5 = new Label();
      this.ComboBox1 = new ComboBox();
      this.ComboBox2 = new ComboBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.ComboMicFallback = new ComboBox();
      this.ComboAudioFallback = new ComboBox();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.Button3 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add(this.ComboBox3);
      this.GroupBox1.Controls.Add(this.Label8);
      this.GroupBox1.Controls.Add(this.ComboBox4);
      this.GroupBox1.Controls.Add(this.Label9);
      this.GroupBox1.Controls.Add(this.GroupBox4);
      this.GroupBox1.Controls.Add(this.GroupBox5);
      this.GroupBox1.Controls.Add(this.Label10);
      this.GroupBox1.Controls.Add(this.ComboBox5);
      this.GroupBox1.Controls.Add(this.ComboBox6);
      this.GroupBox1.Controls.Add(this.Label11);
      this.GroupBox1.Controls.Add(this.Label12);
      this.GroupBox1.Controls.Add(this.ComboCommMicFallback);
      this.GroupBox1.Controls.Add(this.Label7);
      this.GroupBox1.Controls.Add(this.ComboCommFallback);
      this.GroupBox1.Controls.Add(this.Label6);
      this.GroupBox1.Controls.Add(this.GroupBox3);
      this.GroupBox1.Controls.Add(this.GroupBox2);
      this.GroupBox1.Controls.Add(this.Label5);
      this.GroupBox1.Controls.Add(this.ComboBox1);
      this.GroupBox1.Controls.Add(this.ComboBox2);
      this.GroupBox1.Controls.Add(this.Label4);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.ComboMicFallback);
      this.GroupBox1.Controls.Add(this.ComboAudioFallback);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(409, 418);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Set when Audio/Mic devices should switch";
      this.ComboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox3.BackColor = Color.AliceBlue;
      this.ComboBox3.FlatStyle = FlatStyle.Popup;
      this.ComboBox3.FormattingEnabled = true;
      this.ComboBox3.Location = new Point(157, 224);
      this.ComboBox3.Name = "ComboBox3";
      this.ComboBox3.Size = new Size(239, 23);
      this.ComboBox3.TabIndex = 29;
      this.Label8.AutoSize = true;
      this.Label8.Location = new Point(23, 227);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(117, 15);
      this.Label8.TabIndex = 28;
      this.Label8.Text = "Mic Communication";
      this.ComboBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox4.BackColor = Color.AliceBlue;
      this.ComboBox4.FlatStyle = FlatStyle.Popup;
      this.ComboBox4.FormattingEnabled = true;
      this.ComboBox4.Location = new Point(157, 195);
      this.ComboBox4.Name = "ComboBox4";
      this.ComboBox4.Size = new Size(239, 23);
      this.ComboBox4.TabIndex = 27;
      this.Label9.AutoSize = true;
      this.Label9.Location = new Point(23, 198);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(128, 15);
      this.Label9.TabIndex = 26;
      this.Label9.Text = "Audio Communication";
      this.GroupBox4.Location = new Point(6, 111);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(26, 10);
      this.GroupBox4.TabIndex = 25;
      this.GroupBox4.TabStop = false;
      this.GroupBox5.Location = new Point(253, 113);
      this.GroupBox5.Name = "GroupBox5";
      this.GroupBox5.Size = new Size(145, 10);
      this.GroupBox5.TabIndex = 24;
      this.GroupBox5.TabStop = false;
      this.Label10.AutoSize = true;
      this.Label10.Location = new Point(38, 109);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(209, 15);
      this.Label10.TabIndex = 23;
      this.Label10.Text = "On Start/Load switch to these devices";
      this.ComboBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox5.BackColor = Color.AliceBlue;
      this.ComboBox5.FlatStyle = FlatStyle.Popup;
      this.ComboBox5.FormattingEnabled = true;
      this.ComboBox5.Location = new Point(157, 166);
      this.ComboBox5.Name = "ComboBox5";
      this.ComboBox5.Size = new Size(239, 23);
      this.ComboBox5.TabIndex = 22;
      this.ComboBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox6.BackColor = Color.AliceBlue;
      this.ComboBox6.FlatStyle = FlatStyle.Popup;
      this.ComboBox6.FormattingEnabled = true;
      this.ComboBox6.Location = new Point(157, 137);
      this.ComboBox6.Name = "ComboBox6";
      this.ComboBox6.Size = new Size(240, 23);
      this.ComboBox6.TabIndex = 21;
      this.Label11.AutoSize = true;
      this.Label11.Location = new Point(23, 169);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(73, 15);
      this.Label11.TabIndex = 20;
      this.Label11.Text = "Microphone";
      this.Label12.AutoSize = true;
      this.Label12.Location = new Point(26, 142);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(38, 15);
      this.Label12.TabIndex = 19;
      this.Label12.Text = "Audio";
      this.ComboCommMicFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboCommMicFallback.BackColor = Color.AliceBlue;
      this.ComboCommMicFallback.FlatStyle = FlatStyle.Popup;
      this.ComboCommMicFallback.FormattingEnabled = true;
      this.ComboCommMicFallback.Items.AddRange(new object[1]
      {
        (object) " "
      });
      this.ComboCommMicFallback.Location = new Point(157, 375);
      this.ComboCommMicFallback.Name = "ComboCommMicFallback";
      this.ComboCommMicFallback.Size = new Size(239, 23);
      this.ComboCommMicFallback.TabIndex = 18;
      this.Label7.AutoSize = true;
      this.Label7.Location = new Point(23, 378);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(117, 15);
      this.Label7.TabIndex = 17;
      this.Label7.Text = "Mic Communication";
      this.ComboCommFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboCommFallback.BackColor = Color.AliceBlue;
      this.ComboCommFallback.FlatStyle = FlatStyle.Popup;
      this.ComboCommFallback.FormattingEnabled = true;
      this.ComboCommFallback.Location = new Point(157, 346);
      this.ComboCommFallback.Name = "ComboCommFallback";
      this.ComboCommFallback.Size = new Size(239, 23);
      this.ComboCommFallback.TabIndex = 16;
      this.Label6.AutoSize = true;
      this.Label6.Location = new Point(23, 349);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(128, 15);
      this.Label6.TabIndex = 15;
      this.Label6.Text = "Audio Communication";
      this.GroupBox3.Location = new Point(6, 262);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(26, 10);
      this.GroupBox3.TabIndex = 14;
      this.GroupBox3.TabStop = false;
      this.GroupBox2.Location = new Point(217, 264);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(181, 10);
      this.GroupBox2.TabIndex = 13;
      this.GroupBox2.TabStop = false;
      this.Label5.AutoSize = true;
      this.Label5.Location = new Point(38, 260);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(173, 15);
      this.Label5.TabIndex = 12;
      this.Label5.Text = "On Exit switch to these devices";
      this.ComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox1.BackColor = Color.AliceBlue;
      this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox1.FlatStyle = FlatStyle.Popup;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Items.AddRange(new object[5]
      {
        (object) "When Oculus Home starts/exits",
        (object) "When Oculus Tray Tool starts/exits",
        (object) "When a Profile loads/exits",
        (object) "Never",
        (object) "When SteamVR starts/exits"
      });
      this.ComboBox1.Location = new Point(143, 34);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(253, 23);
      this.ComboBox1.TabIndex = 8;
      this.ComboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox2.BackColor = Color.AliceBlue;
      this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox2.FlatStyle = FlatStyle.Popup;
      this.ComboBox2.FormattingEnabled = true;
      this.ComboBox2.Items.AddRange(new object[5]
      {
        (object) "When Oculus Home starts/exits",
        (object) "When Oculus Tray Tool starts/exits",
        (object) "When a Profile loads/exits",
        (object) "Never",
        (object) "When SteamVR starts/exits"
      });
      this.ComboBox2.Location = new Point(143, 63);
      this.ComboBox2.Name = "ComboBox2";
      this.ComboBox2.Size = new Size(253, 23);
      this.ComboBox2.TabIndex = 9;
      this.Label4.AutoSize = true;
      this.Label4.Location = new Point(23, 63);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(112, 15);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Switch Microphone";
      this.Label3.AutoSize = true;
      this.Label3.Location = new Point(23, 34);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(77, 15);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Switch Audio";
      this.ComboMicFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboMicFallback.BackColor = Color.AliceBlue;
      this.ComboMicFallback.FlatStyle = FlatStyle.Popup;
      this.ComboMicFallback.FormattingEnabled = true;
      this.ComboMicFallback.Location = new Point(157, 317);
      this.ComboMicFallback.Name = "ComboMicFallback";
      this.ComboMicFallback.Size = new Size(239, 23);
      this.ComboMicFallback.TabIndex = 3;
      this.ComboAudioFallback.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.ComboAudioFallback.BackColor = Color.AliceBlue;
      this.ComboAudioFallback.FlatStyle = FlatStyle.Popup;
      this.ComboAudioFallback.FormattingEnabled = true;
      this.ComboAudioFallback.Location = new Point(157, 288);
      this.ComboAudioFallback.Name = "ComboAudioFallback";
      this.ComboAudioFallback.Size = new Size(240, 23);
      this.ComboAudioFallback.TabIndex = 2;
      this.Label2.AutoSize = true;
      this.Label2.Location = new Point(23, 320);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(73, 15);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Microphone";
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(26, 293);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(38, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Audio";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(366, 436);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(55, 25);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(12, 436);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(55, 25);
      this.Button2.TabIndex = 2;
      this.Button2.Text = "Reset";
      this.Button2.UseVisualStyleBackColor = true;
      this.Button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button3.ForeColor = Color.DodgerBlue;
      this.Button3.Location = new Point(306, 436);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(55, 25);
      this.Button3.TabIndex = 3;
      this.Button3.Text = "Cancel";
      this.Button3.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = Color.White;
      this.ClientSize = new Size(433, 471);
      this.Controls.Add(this.Button3);
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(449, 510);
      this.Name = "FrmSetFallback";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Audio Swicher";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
      
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Button2.Click += new EventHandler(this.Button2_Click);
      this.Button3.Click += new EventHandler(this.Button3_Click);
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
    internal ComboBox ComboBox2;
    internal ComboBox ComboBox1;
    internal Button Button3;
        internal GroupBox GroupBox1;
        internal ComboBox ComboBox3;
        internal Label Label8;
        internal ComboBox ComboBox4;
        internal Label Label9;
        internal GroupBox GroupBox4;
        internal GroupBox GroupBox5;
        internal Label Label10;
        internal ComboBox ComboBox5;
        internal ComboBox ComboBox6;
        internal Label Label11;
        internal Label Label12;
        internal ComboBox ComboCommMicFallback;
        internal Label Label7;
        internal ComboBox ComboCommFallback;
        internal Label Label6;
        internal GroupBox GroupBox3;
        internal GroupBox GroupBox2;
        internal Label Label5;
        internal Label Label4;
        internal Label Label3;
        internal ComboBox ComboMicFallback;
        internal ComboBox ComboAudioFallback;
        internal Label Label2;
        internal Label Label1;
    
    }
}