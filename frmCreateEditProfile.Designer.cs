using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmCreateEditProfile
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
      this.components = (IContainer) new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmCreateEditProfile));
      this.ComboCPU = new ComboBox();
      this.TextDisplayName = new TextBox();
      this.ComboASW = new ComboBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.Label5 = new Label();
      this.ComboMethod = new ComboBox();
      this.GroupBox1 = new GroupBox();
      this.ComboBoxEnabled = new ComboBox();
      this.Label15 = new Label();
      this.Label33 = new Label();
      this.ComboBox8 = new ComboBox();
      this.ComboBox9 = new ComboBox();
      this.Label37 = new Label();
      this.PictureBox11 = new PictureBox();
      this.NumericUpDown3 = new NumericUpDown();
      this.NumericUpDown4 = new NumericUpDown();
      this.Label14 = new Label();
      this.Label13 = new Label();
      this.Label12 = new Label();
      this.TextBoxComment = new TextBox();
      this.Label11 = new Label();
      this.ComboSS = new ComboBox();
      this.PictureBox10 = new PictureBox();
      this.ComboAGPS = new ComboBox();
      this.Label10 = new Label();
      this.PictureBox9 = new PictureBox();
      this.ComboMirror = new ComboBox();
      this.Label9 = new Label();
      this.ComboBox1 = new ComboBox();
      this.Button3 = new Button();
      this.PictureBox8 = new PictureBox();
      this.TextBoxPath = new TextBox();
      this.Label8 = new Label();
      this.NumericUpDown2 = new NumericUpDown();
      this.PictureBox7 = new PictureBox();
      this.Label7 = new Label();
      this.NumericUpDown1 = new NumericUpDown();
      this.PictureBox6 = new PictureBox();
      this.Label6 = new Label();
      this.PictureBox5 = new PictureBox();
      this.PictureBox4 = new PictureBox();
      this.PictureBox3 = new PictureBox();
      this.PictureBox2 = new PictureBox();
      this.PictureBox1 = new PictureBox();
      this.ToolTip1 = new ToolTip(this.components);
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      ((ISupportInitialize) this.PictureBox11).BeginInit();
      this.NumericUpDown3.BeginInit();
      this.NumericUpDown4.BeginInit();
      ((ISupportInitialize) this.PictureBox10).BeginInit();
      ((ISupportInitialize) this.PictureBox9).BeginInit();
      ((ISupportInitialize) this.PictureBox8).BeginInit();
      this.NumericUpDown2.BeginInit();
      ((ISupportInitialize) this.PictureBox7).BeginInit();
      this.NumericUpDown1.BeginInit();
      ((ISupportInitialize) this.PictureBox6).BeginInit();
      ((ISupportInitialize) this.PictureBox5).BeginInit();
      ((ISupportInitialize) this.PictureBox4).BeginInit();
      ((ISupportInitialize) this.PictureBox3).BeginInit();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.ComboCPU.BackColor = SystemColors.InactiveBorder;
      this.ComboCPU.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboCPU.FlatStyle = FlatStyle.Popup;
      this.ComboCPU.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboCPU.FormattingEnabled = true;
      this.ComboCPU.Items.AddRange(new object[4]
      {
        (object) "Default",
        (object) "Normal",
        (object) "Above Normal",
        (object) "High"
      });
      this.ComboCPU.Location = new Point(103, 149);
      this.ComboCPU.Name = "ComboCPU";
      this.ComboCPU.Size = new Size(208, 23);
      this.ComboCPU.TabIndex = 18;
      this.TextDisplayName.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TextDisplayName.Location = new Point(104, 18);
      this.TextDisplayName.Name = "TextDisplayName";
      this.TextDisplayName.Size = new Size(208, 21);
      this.TextDisplayName.TabIndex = 17;
      this.ComboASW.BackColor = SystemColors.InactiveBorder;
      this.ComboASW.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboASW.FlatStyle = FlatStyle.Popup;
      this.ComboASW.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboASW.FormattingEnabled = true;
      this.ComboASW.Items.AddRange(new object[7]
      {
        (object) "Auto",
        (object) "Off",
        (object) "45 Hz",
        (object) "30 Hz",
        (object) "18 Hz",
        (object) "45 Hz forced",
        (object) "Adaptive"
      });
      this.ComboASW.Location = new Point(103, 89);
      this.ComboASW.Name = "ComboASW";
      this.ComboASW.Size = new Size(208, 23);
      this.ComboASW.TabIndex = 16;
      this.Label1.AutoSize = true;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(14, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(62, 13);
      this.Label1.TabIndex = 19;
      this.Label1.Text = "Game/App:";
      this.Label2.AutoSize = true;
      this.Label2.ForeColor = Color.DodgerBlue;
      this.Label2.Location = new Point(14, 57);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(84, 13);
      this.Label2.TabIndex = 20;
      this.Label2.Text = "Super Sampling:";
      this.Label3.AutoSize = true;
      this.Label3.ForeColor = Color.DodgerBlue;
      this.Label3.Location = new Point(14, 94);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(65, 13);
      this.Label3.TabIndex = 21;
      this.Label3.Text = "ASW Mode:";
      this.Label4.AutoSize = true;
      this.Label4.ForeColor = Color.DodgerBlue;
      this.Label4.Location = new Point(14, 154);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(66, 13);
      this.Label4.TabIndex = 22;
      this.Label4.Text = "CPU Priority:";
      this.Label5.AutoSize = true;
      this.Label5.ForeColor = Color.DodgerBlue;
      this.Label5.Location = new Point(14, 216);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(56, 13);
      this.Label5.TabIndex = 24;
      this.Label5.Text = "Detection:";
      this.ComboMethod.BackColor = SystemColors.InactiveBorder;
      this.ComboMethod.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboMethod.FlatStyle = FlatStyle.Popup;
      this.ComboMethod.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboMethod.FormattingEnabled = true;
      this.ComboMethod.Items.AddRange(new object[2]
      {
        (object) "WMI",
        (object) "Timer"
      });
      this.ComboMethod.Location = new Point(103, 211);
      this.ComboMethod.Name = "ComboMethod";
      this.ComboMethod.Size = new Size(208, 23);
      this.ComboMethod.TabIndex = 25;
      this.GroupBox1.Controls.Add(this.ComboBoxEnabled);
      this.GroupBox1.Controls.Add(this.Label15);
      this.GroupBox1.Controls.Add(this.Label33);
      this.GroupBox1.Controls.Add(this.ComboBox8);
      this.GroupBox1.Controls.Add(this.ComboBox9);
      this.GroupBox1.Controls.Add(this.Label37);
      this.GroupBox1.Controls.Add(this.PictureBox11);
      this.GroupBox1.Controls.Add(this.NumericUpDown3);
      this.GroupBox1.Controls.Add(this.NumericUpDown4);
      this.GroupBox1.Controls.Add(this.Label14);
      this.GroupBox1.Controls.Add(this.Label13);
      this.GroupBox1.Controls.Add(this.Label12);
      this.GroupBox1.Controls.Add(this.TextBoxComment);
      this.GroupBox1.Controls.Add(this.Label11);
      this.GroupBox1.Controls.Add(this.ComboSS);
      this.GroupBox1.Controls.Add(this.PictureBox10);
      this.GroupBox1.Controls.Add(this.ComboAGPS);
      this.GroupBox1.Controls.Add(this.Label10);
      this.GroupBox1.Controls.Add(this.PictureBox9);
      this.GroupBox1.Controls.Add(this.ComboMirror);
      this.GroupBox1.Controls.Add(this.Label9);
      this.GroupBox1.Controls.Add(this.ComboBox1);
      this.GroupBox1.Controls.Add(this.Button3);
      this.GroupBox1.Controls.Add(this.PictureBox8);
      this.GroupBox1.Controls.Add(this.TextBoxPath);
      this.GroupBox1.Controls.Add(this.Label8);
      this.GroupBox1.Controls.Add(this.NumericUpDown2);
      this.GroupBox1.Controls.Add(this.PictureBox7);
      this.GroupBox1.Controls.Add(this.Label7);
      this.GroupBox1.Controls.Add(this.NumericUpDown1);
      this.GroupBox1.Controls.Add(this.PictureBox6);
      this.GroupBox1.Controls.Add(this.Label6);
      this.GroupBox1.Controls.Add(this.PictureBox5);
      this.GroupBox1.Controls.Add(this.PictureBox4);
      this.GroupBox1.Controls.Add(this.PictureBox3);
      this.GroupBox1.Controls.Add(this.PictureBox2);
      this.GroupBox1.Controls.Add(this.PictureBox1);
      this.GroupBox1.Controls.Add(this.TextDisplayName);
      this.GroupBox1.Controls.Add(this.ComboMethod);
      this.GroupBox1.Controls.Add(this.ComboASW);
      this.GroupBox1.Controls.Add(this.Label5);
      this.GroupBox1.Controls.Add(this.ComboCPU);
      this.GroupBox1.Controls.Add(this.Label4);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Location = new Point(12, 2);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(754, 292);
      this.GroupBox1.TabIndex = 26;
      this.GroupBox1.TabStop = false;
      this.ComboBoxEnabled.FormattingEnabled = true;
      this.ComboBoxEnabled.Items.AddRange(new object[2]
      {
        (object) "Yes",
        (object) "No"
      });
      this.ComboBoxEnabled.Location = new Point(550, 246);
      this.ComboBoxEnabled.Name = "ComboBoxEnabled";
      this.ComboBoxEnabled.Size = new Size(162, 21);
      this.ComboBoxEnabled.TabIndex = 66;
      this.Label15.AutoSize = true;
      this.Label15.ForeColor = Color.DodgerBlue;
      this.Label15.Location = new Point(415, 249);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(49, 13);
      this.Label15.TabIndex = 65;
      this.Label15.Text = "Enabled:";
      this.Label33.AutoSize = true;
      this.Label33.ForeColor = Color.DodgerBlue;
      this.Label33.Location = new Point(415, 140);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(130, 13);
      this.Label33.TabIndex = 61;
      this.Label33.Text = "Force MipMap Generation";
      this.Label33.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox8.BackColor = Color.AliceBlue;
      this.ComboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox8.FlatStyle = FlatStyle.Popup;
      this.ComboBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox8.FormattingEnabled = true;
      this.ComboBox8.Items.AddRange(new object[2]
      {
        (object) "True",
        (object) "False"
      });
      this.ComboBox8.Location = new Point(551, 135);
      this.ComboBox8.Name = "ComboBox8";
      this.ComboBox8.Size = new Size(162, 24);
      this.ComboBox8.TabIndex = 62;
      this.ComboBox9.BackColor = Color.AliceBlue;
      this.ComboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox9.FlatStyle = FlatStyle.Popup;
      this.ComboBox9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox9.FormattingEnabled = true;
      this.ComboBox9.Items.AddRange(new object[21]
      {
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20"
      });
      this.ComboBox9.Location = new Point(551, 173);
      this.ComboBox9.Name = "ComboBox9";
      this.ComboBox9.Size = new Size(162, 24);
      this.ComboBox9.TabIndex = 64;
      this.Label37.AutoSize = true;
      this.Label37.ForeColor = Color.DodgerBlue;
      this.Label37.Location = new Point(415, 178);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(99, 13);
      this.Label37.TabIndex = 63;
      this.Label37.Text = "Offset MipMap Bias";
      this.Label37.TextAlign = ContentAlignment.MiddleLeft;
      this.PictureBox11.Image = (System.Drawing.Image)resources.GetObject("PictureBox11.Image");
      this.PictureBox11.Location = new Point(729, 99);
      this.PictureBox11.Name = "PictureBox11";
      this.PictureBox11.Size = new Size(19, 20);
      this.PictureBox11.TabIndex = 60;
      this.PictureBox11.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox11, resources.GetString("PictureBox11.ToolTip"));
      this.NumericUpDown3.BorderStyle = BorderStyle.FixedSingle;
      this.NumericUpDown3.DecimalPlaces = 2;
      this.NumericUpDown3.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        131072
      });
      this.NumericUpDown3.Location = new Point(562, 97);
      this.NumericUpDown3.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.NumericUpDown3.Name = "NumericUpDown3";
      this.NumericUpDown3.Size = new Size(45, 20);
      this.NumericUpDown3.TabIndex = 59;
      this.NumericUpDown4.BorderStyle = BorderStyle.FixedSingle;
      this.NumericUpDown4.DecimalPlaces = 2;
      this.NumericUpDown4.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        131072
      });
      this.NumericUpDown4.Location = new Point(669, 97);
      this.NumericUpDown4.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.NumericUpDown4.Name = "NumericUpDown4";
      this.NumericUpDown4.Size = new Size(45, 20);
      this.NumericUpDown4.TabIndex = 56;
      this.Label14.AutoSize = true;
      this.Label14.ForeColor = Color.DodgerBlue;
      this.Label14.Location = new Point(621, 99);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(42, 13);
      this.Label14.TabIndex = 55;
      this.Label14.Text = "Vertical";
      this.Label13.AutoSize = true;
      this.Label13.ForeColor = Color.DodgerBlue;
      this.Label13.Location = new Point(502, 99);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(54, 13);
      this.Label13.TabIndex = 54;
      this.Label13.Text = "Horizontal";
      this.Label12.AutoSize = true;
      this.Label12.ForeColor = Color.DodgerBlue;
      this.Label12.Location = new Point(415, 99);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(73, 13);
      this.Label12.TabIndex = 53;
      this.Label12.Text = "FoV Multiplier:";
      this.TextBoxComment.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TextBoxComment.Location = new Point(550, 211);
      this.TextBoxComment.Name = "TextBoxComment";
      this.TextBoxComment.Size = new Size(162, 21);
      this.TextBoxComment.TabIndex = 51;
      this.Label11.AutoSize = true;
      this.Label11.ForeColor = Color.DodgerBlue;
      this.Label11.Location = new Point(415, 216);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(54, 13);
      this.Label11.TabIndex = 52;
      this.Label11.Text = "Comment:";
      this.ComboSS.BackColor = SystemColors.InactiveBorder;
      this.ComboSS.FlatStyle = FlatStyle.Popup;
      this.ComboSS.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboSS.FormattingEnabled = true;
      this.ComboSS.Items.AddRange(new object[38]
      {
        (object) "0",
        (object) "0.7",
        (object) "0.75",
        (object) "0.8",
        (object) "0.85",
        (object) "0.9",
        (object) "0.95",
        (object) "1.0",
        (object) "1.05",
        (object) "1.1",
        (object) "1.15",
        (object) "1.2",
        (object) "1.25",
        (object) "1.3",
        (object) "1.35",
        (object) "1.4",
        (object) "1.45",
        (object) "1.5",
        (object) "1.55",
        (object) "1.6",
        (object) "1.65",
        (object) "1.7",
        (object) "1.75",
        (object) "1.8",
        (object) "1.85",
        (object) "1.9",
        (object) "1.95",
        (object) "2.0",
        (object) "2.05",
        (object) "2.1",
        (object) "2.15",
        (object) "2.2",
        (object) "2.25",
        (object) "2.3",
        (object) "2.35",
        (object) "2.4",
        (object) "2.45",
        (object) "2.5"
      });
      this.ComboSS.Location = new Point(103, 52);
      this.ComboSS.Name = "ComboSS";
      this.ComboSS.Size = new Size(208, 23);
      this.ComboSS.Sorted = true;
      this.ComboSS.TabIndex = 29;
      this.ComboSS.TabStop = false;
      this.PictureBox10.Image = (System.Drawing.Image)resources.GetObject("PictureBox10.Image");
      this.PictureBox10.Location = new Point(729, 55);
      this.PictureBox10.Name = "PictureBox10";
      this.PictureBox10.Size = new Size(19, 20);
      this.PictureBox10.TabIndex = 46;
      this.PictureBox10.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox10, "Enables or Disables Adaptive GPU Scaling. Setting this to Off might improve the experience in some games.");
      this.ComboAGPS.BackColor = SystemColors.InactiveBorder;
      this.ComboAGPS.FlatStyle = FlatStyle.Popup;
      this.ComboAGPS.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboAGPS.FormattingEnabled = true;
      this.ComboAGPS.Items.AddRange(new object[2]
      {
        (object) "Off",
        (object) "On"
      });
      this.ComboAGPS.Location = new Point(505, 51);
      this.ComboAGPS.Name = "ComboAGPS";
      this.ComboAGPS.Size = new Size(208, 23);
      this.ComboAGPS.TabIndex = 45;
      this.Label10.AutoSize = true;
      this.Label10.ForeColor = Color.DodgerBlue;
      this.Label10.Location = new Point(415, 56);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(71, 13);
      this.Label10.TabIndex = 44;
      this.Label10.Text = "GPU Scaling:";
      this.PictureBox9.Image = (System.Drawing.Image)resources.GetObject("PictureBox9.Image");
      this.PictureBox9.Location = new Point(729, 17);
      this.PictureBox9.Name = "PictureBox9";
      this.PictureBox9.Size = new Size(19, 20);
      this.PictureBox9.TabIndex = 43;
      this.PictureBox9.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox9, "Sets the window state of the app when it is launched.");
      this.ComboMirror.BackColor = SystemColors.InactiveBorder;
      this.ComboMirror.FlatStyle = FlatStyle.Popup;
      this.ComboMirror.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboMirror.FormattingEnabled = true;
      this.ComboMirror.Items.AddRange(new object[3]
      {
        (object) "Default",
        (object) "Minimized",
        (object) "Forced"
      });
      this.ComboMirror.Location = new Point(505, 16);
      this.ComboMirror.Name = "ComboMirror";
      this.ComboMirror.Size = new Size(208, 23);
      this.ComboMirror.TabIndex = 42;
      this.Label9.AutoSize = true;
      this.Label9.ForeColor = Color.DodgerBlue;
      this.Label9.Location = new Point(416, 21);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(73, 13);
      this.Label9.TabIndex = 41;
      this.Label9.Text = "Screen Mirror:";
      this.ComboBox1.BackColor = SystemColors.InactiveBorder;
      this.ComboBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Location = new Point(104, 17);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(208, 23);
      this.ComboBox1.Sorted = true;
      this.ComboBox1.TabIndex = 29;
      this.ComboBox1.Text = "- Select Game -";
      this.ComboBox1.Visible = false;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.Location = new Point(318, 19);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(26, 21);
      this.Button3.TabIndex = 29;
      this.Button3.Text = "..";
      this.ToolTip1.SetToolTip(this.Button3, "Manually browse for a game if it is not found in the list, or change profile .exe, e.g. the process that Oculus TrayTool will monitor.");
      this.Button3.UseVisualStyleBackColor = true;
      this.PictureBox8.Image = (System.Drawing.Image)resources.GetObject("PictureBox8.Image");
      this.PictureBox8.Location = new Point(349, 249);
      this.PictureBox8.Name = "PictureBox8";
      this.PictureBox8.Size = new Size(19, 20);
      this.PictureBox8.TabIndex = 40;
      this.PictureBox8.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox8, "The path to the executable that OTT should monitor.");
      this.TextBoxPath.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TextBoxPath.Location = new Point(104, 249);
      this.TextBoxPath.Name = "TextBoxPath";
      this.TextBoxPath.Size = new Size(208, 21);
      this.TextBoxPath.TabIndex = 38;
      this.Label8.AutoSize = true;
      this.Label8.ForeColor = Color.DodgerBlue;
      this.Label8.Location = new Point(14, 254);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(56, 13);
      this.Label8.TabIndex = 39;
      this.Label8.Text = "EXE Path:";
      this.NumericUpDown2.BackColor = SystemColors.InactiveBorder;
      this.NumericUpDown2.BorderStyle = BorderStyle.None;
      this.NumericUpDown2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.NumericUpDown2.Location = new Point(103, 178);
      this.NumericUpDown2.Name = "NumericUpDown2";
      this.NumericUpDown2.RightToLeft = RightToLeft.Yes;
      this.NumericUpDown2.Size = new Size(208, 18);
      this.NumericUpDown2.TabIndex = 35;
      this.NumericUpDown2.TextAlign = HorizontalAlignment.Right;
      this.NumericUpDown2.UpDownAlign = LeftRightAlignment.Left;
      this.PictureBox7.Image = (System.Drawing.Image)resources.GetObject("PictureBox7.Image");
      this.PictureBox7.Location = new Point(349, 176);
      this.PictureBox7.Name = "PictureBox7";
      this.PictureBox7.Size = new Size(19, 20);
      this.PictureBox7.TabIndex = 37;
      this.PictureBox7.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox7, "Sets the delay before applying CPU Priority. Some games and apps require a bit more time to start up to successfully change PCU Priority.");
      this.Label7.AutoSize = true;
      this.Label7.ForeColor = Color.DodgerBlue;
      this.Label7.Location = new Point(25, 180);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(56, 13);
      this.Label7.TabIndex = 36;
      this.Label7.Text = "Set Delay:";
      this.NumericUpDown1.BackColor = SystemColors.InactiveBorder;
      this.NumericUpDown1.BorderStyle = BorderStyle.None;
      this.NumericUpDown1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.NumericUpDown1.Location = new Point(103, 118);
      this.NumericUpDown1.Name = "NumericUpDown1";
      this.NumericUpDown1.RightToLeft = RightToLeft.Yes;
      this.NumericUpDown1.Size = new Size(208, 18);
      this.NumericUpDown1.TabIndex = 29;
      this.NumericUpDown1.TextAlign = HorizontalAlignment.Right;
      this.NumericUpDown1.UpDownAlign = LeftRightAlignment.Left;
      this.PictureBox6.Image = (System.Drawing.Image)resources.GetObject("PictureBox6.Image");
      this.PictureBox6.Location = new Point(349, 116);
      this.PictureBox6.Name = "PictureBox6";
      this.PictureBox6.Size = new Size(19, 20);
      this.PictureBox6.TabIndex = 34;
      this.PictureBox6.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox6, "Sets the delay before applying ASW. Some games and apps require a bit more time to start up to successfully change ASW.");
      this.Label6.AutoSize = true;
      this.Label6.ForeColor = Color.DodgerBlue;
      this.Label6.Location = new Point(20, 119);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(56, 13);
      this.Label6.TabIndex = 33;
      this.Label6.Text = "Set Delay:";
      this.PictureBox5.Image = (System.Drawing.Image)resources.GetObject("PictureBox5.Image");
      this.PictureBox5.Location = new Point(349, 214);
      this.PictureBox5.Name = "PictureBox5";
      this.PictureBox5.Size = new Size(19, 20);
      this.PictureBox5.TabIndex = 44;
      this.PictureBox5.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox5, "Comment must be unique and is only used to differentiate between different profiles for the same game.");
      this.ClientSize = new Size(726, 311);
      this.Controls.Add((Control) this.NumericUpDown4);
      this.Controls.Add((Control) this.Label14);
      this.Controls.Add((Control) this.Label13);
      this.Controls.Add((Control) this.Label12);
      this.Controls.Add((Control) this.Label11);
      this.Controls.Add((Control) this.TextBoxComment);
      this.Controls.Add((Control) this.NumericUpDown3);
      this.Controls.Add((Control) this.ComboBox9);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.PictureBox11);
      this.Controls.Add((Control) this.ComboBox8);
      this.Controls.Add((Control) this.ComboBoxEnabled);
      this.Controls.Add((Control) this.PictureBox9);
      this.Controls.Add((Control) this.Button3);
      this.Controls.Add((Control) this.PictureBox5);
      this.Controls.Add((Control) this.ComboBox1);
      this.Controls.Add((Control) this.ComboMirror);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.PictureBox8);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.TextBoxPath);
      this.Controls.Add((Control) this.PictureBox7);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.NumericUpDown2);
      this.Controls.Add((Control) this.PictureBox6);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.NumericUpDown1);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.TextDisplayName);
      this.Controls.Add((Control) this.PictureBox4);
      this.Controls.Add((Control) this.PictureBox3);
      this.Controls.Add((Control) this.PictureBox2);
      this.Controls.Add((Control) this.PictureBox1);
      this.Controls.Add((Control) this.ComboAGPS);
      this.Controls.Add((Control) this.ComboMethod);
      this.Controls.Add((Control) this.ComboCPU);
      this.Controls.Add((Control) this.ComboASW);
      this.Controls.Add((Control) this.ComboSS);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.Label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmCreateEditProfile);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Create/Edit Profile";
      ((ISupportInitialize) this.NumericUpDown1).EndInit();
      ((ISupportInitialize) this.NumericUpDown2).EndInit();
      ((ISupportInitialize) this.PictureBox1).EndInit();
      ((ISupportInitialize) this.PictureBox2).EndInit();
      ((ISupportInitialize) this.PictureBox3).EndInit();
      ((ISupportInitialize) this.PictureBox4).EndInit();
      ((ISupportInitialize) this.PictureBox5).EndInit();
      ((ISupportInitialize) this.PictureBox6).EndInit();
      ((ISupportInitialize) this.NumericUpDown3).EndInit();
      ((ISupportInitialize) this.NumericUpDown4).EndInit();
      ((ISupportInitialize) this.PictureBox8).EndInit();
      ((ISupportInitialize) this.PictureBox9).EndInit();
      ((ISupportInitialize) this.PictureBox11).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
      this.Button1.Click += new System.EventHandler(this.Button1_Click);
      this.Button2.Click += new System.EventHandler(this.Button2_Click);
      this.Button3.Click += new System.EventHandler(this.Button3_Click);
      this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
      this.ComboBox1.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
      this.ComboSS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboSS_KeyPress);
      this.PictureBox5.Size = new Size(19, 20);
      this.PictureBox5.TabIndex = 31;
      this.PictureBox5.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox5, resources.GetString("PictureBox5.ToolTip"));
      this.PictureBox4.Image = (System.Drawing.Image)resources.GetObject("PictureBox4.Image");
      this.PictureBox4.Location = new Point(349, 147);
      this.PictureBox4.Name = "PictureBox4";
      this.PictureBox4.Size = new Size(19, 20);
      this.PictureBox4.TabIndex = 30;
      this.PictureBox4.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox4, "Makes Windows give this app a bit higher priority over other system resources. Can improve performance.");
      this.PictureBox3.Image = (System.Drawing.Image)resources.GetObject("PictureBox3.Image");
      this.PictureBox3.Location = new Point(349, 87);
      this.PictureBox3.Name = "PictureBox3";
      this.PictureBox3.Size = new Size(19, 20);
      this.PictureBox3.TabIndex = 29;
      this.PictureBox3.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox3, "Sets the mode for Asynchronous Space Warp (ASW). This should usualy be set to Auto unless you experience issues.");
      this.PictureBox2.Image = (System.Drawing.Image)resources.GetObject("PictureBox2.Image");
      this.PictureBox2.Location = new Point(349, 55);
      this.PictureBox2.Name = "PictureBox2";
      this.PictureBox2.Size = new Size(19, 20);
      this.PictureBox2.TabIndex = 28;
      this.PictureBox2.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox2, resources.GetString("PictureBox2.ToolTip"));
      this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
      this.PictureBox1.Location = new Point(349, 20);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(19, 20);
      this.PictureBox1.TabIndex = 27;
      this.PictureBox1.TabStop = false;
      this.ToolTip1.SetToolTip(this.PictureBox1, resources.GetString("PictureBox1.ToolTip"));
      this.ToolTip1.AutoPopDelay = 15000;
      this.ToolTip1.InitialDelay = 200;
      this.ToolTip1.ReshowDelay = 100;
      this.Button1.Enabled = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(714, 300);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(52, 23);
      this.Button1.TabIndex = 27;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(12, 300);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(52, 23);
      this.Button2.TabIndex = 28;
      this.Button2.Text = "Cancel";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(774, 329);
      this.ControlBox = false;
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = "frmCreateEditProfile";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Create/Edit Profile";
      this.TopMost = true;
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      ((ISupportInitialize) this.PictureBox11).EndInit();
      this.NumericUpDown3.EndInit();
      this.NumericUpDown4.EndInit();
      ((ISupportInitialize) this.PictureBox10).EndInit();
      ((ISupportInitialize) this.PictureBox9).EndInit();
      ((ISupportInitialize) this.PictureBox8).EndInit();
      this.NumericUpDown2.EndInit();
      ((ISupportInitialize) this.PictureBox7).EndInit();
      this.NumericUpDown1.EndInit();
      ((ISupportInitialize) this.PictureBox6).EndInit();
      ((ISupportInitialize) this.PictureBox5).EndInit();
      ((ISupportInitialize) this.PictureBox4).EndInit();
      ((ISupportInitialize) this.PictureBox3).EndInit();
      ((ISupportInitialize) this.PictureBox2).EndInit();
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
    
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
    internal Button Button3;
    internal ComboBox ComboBox1;
    internal ComboBox ComboSS;
        internal ComboBox ComboCPU;
        internal TextBox TextDisplayName;
        internal ComboBox ComboASW;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal ComboBox ComboMethod;
        internal GroupBox GroupBox1;
        internal ComboBox ComboBoxEnabled;
        internal Label Label15;
        internal Label Label33;
        internal ComboBox ComboBox8;
        internal ComboBox ComboBox9;
        internal Label Label37;
        internal PictureBox PictureBox11;
        internal NumericUpDown NumericUpDown3;
        internal NumericUpDown NumericUpDown4;
        internal Label Label14;
        internal Label Label13;
        internal Label Label12;
        internal TextBox TextBoxComment;
        internal Label Label11;
        internal PictureBox PictureBox10;
        internal ComboBox ComboAGPS;
        internal Label Label10;
        internal PictureBox PictureBox9;
        internal ComboBox ComboMirror;
        internal Label Label9;
        internal PictureBox PictureBox8;
        internal TextBox TextBoxPath;
        internal Label Label8;
        internal NumericUpDown NumericUpDown2;
        internal PictureBox PictureBox7;
        internal Label Label7;
        internal NumericUpDown NumericUpDown1;
        internal PictureBox PictureBox6;
        internal Label Label6;
        internal PictureBox PictureBox5;
        internal PictureBox PictureBox4;
        internal PictureBox PictureBox3;
        internal PictureBox PictureBox2;
        internal PictureBox PictureBox1;
        internal ToolTip ToolTip1;
    
    }
}