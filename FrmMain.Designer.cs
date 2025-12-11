
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using OculusTrayTool.MyNameSpace;

namespace OculusTrayTool
{
    partial class FrmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (FrmMain));
      this.NotifyIcon1 = new NotifyIcon(this.components);
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.ToolStripStartOVR = new ToolStripMenuItem();
      this.ToolStripStopOVR = new ToolStripMenuItem();
      this.ToolStripRestartOVR = new ToolStripMenuItem();
      this.ToolStripSeparator2 = new ToolStripSeparator();
      this.ToolStripMenuItem3 = new ToolStripMenuItem();
      this.ToolStripSeparator1 = new ToolStripSeparator();
      this.ToolStripMenuItem2 = new ToolStripMenuItem();
      this.ToolStripMenuShowHome = new ToolStripMenuItem();
      this.ToolStripMenuItem1 = new ToolStripMenuItem();
      this.ContextMenuStrip2 = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem4 = new ToolStripMenuItem();
      this.ClearLogToolStripMenuItem = new ToolStripMenuItem();
      this.OpenLogToolStripMenuItem = new ToolStripMenuItem();
      this.ToolTip = new ToolTip(this.components);
      this.PictureBox1 = new PictureBox();
      this.PictureBox2 = new PictureBox();
      this.ComboSSstart = new ComboBox();
      this.ComboBox1 = new ComboBox();
      this.Label1 = new Label();
      this.Label6 = new Label();
      this.ComboHomless = new ComboBox();
      this.Label5 = new Label();
      this.ComboVoice = new ComboBox();
      this.BtnVoice = new Button();
      this.Button2 = new Button();
      this.PictureBox8 = new PictureBox();
      this.CheckRiftAudio = new CheckBox();
      this.CheckSpoofCPU = new CheckBox();
      this.ButtonRestartOVR = new Button();
      this.ButtonStartOVR = new Button();
      this.ButtonStopOVR = new Button();
      this.Label29 = new Label();
      this.CheckLocalDebug = new CheckBox();
      this.CheckStartWatcher = new CheckBox();
      this.Label13 = new Label();
      this.Label18 = new Label();
      this.Button4 = new Button();
      this.BtnRemoveAllProfiles = new Button();
      this.Button1 = new Button();
      this.Button5 = new Button();
      this.PictureBox7 = new PictureBox();
      this.PictureBox6 = new PictureBox();
      this.PictureBox5 = new PictureBox();
      this.PictureBox4 = new PictureBox();
      this.PictureBox3 = new PictureBox();
      this.Button11 = new Button();
      this.OculusHomeWatcher = new System.Windows.Forms.Timer(this.components);
      this.Label8 = new Label();
      this.NotificationTimer = new System.Windows.Forms.Timer(this.components);
      this.MinimizeHomeWatcher = new System.Management.ManagementEventWatcher();
      this.ImageList1 = new ImageList(this.components);
      this.HometoTrayTimer = new System.Windows.Forms.Timer(this.components);
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.NotifyIcon3 = new NotifyIcon(this.components);
      this.PowerPlanTimer = new System.Windows.Forms.Timer(this.components);
      this.DotNetBarTabcontrol1 = new DotNetBarTabcontrol();
      this.TabPage1 = new TabPage();
      this.GroupBox14 = new GroupBox();
      this.DbLayoutPanel2 = new DBLayoutPanel(this.components);
      this.Label19 = new Label();
      this.Label7 = new Label();
      this.BtnProfiles = new Button();
      this.Label9 = new Label();
      this.Label17 = new Label();
      this.ComboMirrorHome = new ComboBox();
      this.Label16 = new Label();
      this.BtnHomless = new Button();
      this.Label15 = new Label();
      this.Label35 = new Label();
      this.ComboVisualHUD = new ComboBox();
      this.ComboBox5 = new ComboBox();
      this.SplitContainer1 = new SplitContainer();
      this.NumericFOVh = new NumericUpDown();
      this.NumericFOVv = new NumericUpDown();
      this.ComboOVRPrio = new ComboBox();
      this.Label33 = new Label();
      this.ComboBox8 = new ComboBox();
      this.ComboBox9 = new ComboBox();
      this.Label37 = new Label();
      this.TabPage2 = new TabPage();
      this.GroupBox1 = new GroupBox();
      this.DbLayoutPanel4 = new DBLayoutPanel(this.components);
      this.CheckStartWithWindows = new CheckBox();
      this.CheckStartMin = new CheckBox();
      this.CheckMinimizeOnX = new CheckBox();
      this.CheckBoxAltTab = new CheckBox();
      this.HotKeysCheckBox = new CheckBox();
      this.BtnConfigureAudio = new Button();
      this.Label14 = new Label();
      this.CheckBoxCheckForUpdates = new CheckBox();
      this.BtnConfigureHotKeys = new Button();
      this.TrackBar1 = new TrackBar();
      this.TabPage3 = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.DbLayoutPanel5 = new DBLayoutPanel(this.components);
      this.ComboApplyPlan = new ComboBox();
      this.Label4 = new Label();
      this.ComboPowerPlanExit = new ComboBox();
      this.Label2 = new Label();
      this.ComboPowerPlanStart = new ComboBox();
      this.Label22 = new Label();
      this.Label3 = new Label();
      this.Label23 = new Label();
      this.CheckSensorPower = new CheckBox();
      this.ComboUSBsusp = new ComboBox();
      this.TabPage4 = new TabPage();
      this.DbLayoutPanel7 = new DBLayoutPanel(this.components);
      this.GroupBox6 = new GroupBox();
      this.DbLayoutPanel8 = new DBLayoutPanel(this.components);
      this.CheckStartService = new CheckBox();
      this.CheckStopService = new CheckBox();
      this.CheckSendHomeToTrayOnStart = new CheckBox();
      this.CheckSendHomeToTray = new CheckBox();
      this.CheckCloseHome = new CheckBox();
      this.CheckLaunchHomeTool = new CheckBox();
      this.CheckLaunchHome = new CheckBox();
      this.CheckRestartSleep = new CheckBox();
      this.CheckStopServiceHome = new CheckBox();
      this.GroupBox4 = new GroupBox();
      this.DbLayoutPanel6 = new DBLayoutPanel(this.components);
      this.LabelServiceStatus = new Label();
      this.Label11 = new Label();
      this.TabPage5 = new TabPage();
      this.GroupBox3 = new GroupBox();
      this.ListBox1 = new ListBox();
      this.TabPage7 = new TabPage();
      this.GroupBox7 = new GroupBox();
      this.DbLayoutPanel1 = new DBLayoutPanel(this.components);
      this.BtnLibrary = new Button();
      this.BtnSteamImport = new Button();
      this.Label24 = new Label();
      this.Label25 = new Label();
      this.Label26 = new Label();
      this.Label27 = new Label();
      this.Label28 = new Label();
      this.TabPage8 = new TabPage();
      this.GroupBox5 = new GroupBox();
      this.Button3 = new Button();
      this.Button12 = new Button();
      this.DbLayoutPanel3 = new DBLayoutPanel(this.components);
      this.ComboBox11 = new ComboBox();
      this.ComboBox6 = new ComboBox();
      this.Label32 = new Label();
      this.Label30 = new Label();
      this.Label31 = new Label();
      this.ComboBox4 = new ComboBox();
      this.ComboBox3 = new ComboBox();
      this.ComboBox2 = new ComboBox();
      this.Label36 = new Label();
      this.Label38 = new Label();
      this.ComboBox10 = new ComboBox();
      this.Label21 = new Label();
      this.Button6 = new Button();
      this.Label20 = new Label();
      this.ComboBox7 = new ComboBox();
      this.Label39 = new Label();
      this.Button10 = new Button();
      this.Label10 = new Label();
      this.TabPage6 = new TabPage();
      this.GroupBox9 = new GroupBox();
      this.LabelDownloadStatus = new Label();
      this.LabelVer = new Label();
      this.Label12 = new Label();
      this.Button9 = new Button();
      this.Button8 = new Button();
      this.ContextMenuStrip1.SuspendLayout();
      this.ContextMenuStrip2.SuspendLayout();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      ((ISupportInitialize) this.PictureBox8).BeginInit();
      ((ISupportInitialize) this.PictureBox7).BeginInit();
      ((ISupportInitialize) this.PictureBox6).BeginInit();
      ((ISupportInitialize) this.PictureBox5).BeginInit();
      ((ISupportInitialize) this.PictureBox4).BeginInit();
      ((ISupportInitialize) this.PictureBox3).BeginInit();
      this.DotNetBarTabcontrol1.SuspendLayout();
      this.TabPage1.SuspendLayout();
      this.GroupBox14.SuspendLayout();
      this.DbLayoutPanel2.SuspendLayout();
      this.SplitContainer1.BeginInit();
      this.SplitContainer1.Panel1.SuspendLayout();
      this.SplitContainer1.Panel2.SuspendLayout();
      this.SplitContainer1.SuspendLayout();
      this.NumericFOVh.BeginInit();
      this.NumericFOVv.BeginInit();
      this.TabPage2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.DbLayoutPanel4.SuspendLayout();
      this.TrackBar1.BeginInit();
      this.TabPage3.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.DbLayoutPanel5.SuspendLayout();
      this.TabPage4.SuspendLayout();
      this.DbLayoutPanel7.SuspendLayout();
      this.GroupBox6.SuspendLayout();
      this.DbLayoutPanel8.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.DbLayoutPanel6.SuspendLayout();
      this.TabPage5.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.TabPage7.SuspendLayout();
      this.GroupBox7.SuspendLayout();
      this.DbLayoutPanel1.SuspendLayout();
      this.TabPage8.SuspendLayout();
      this.GroupBox5.SuspendLayout();
      this.DbLayoutPanel3.SuspendLayout();
      this.TabPage6.SuspendLayout();
      this.GroupBox9.SuspendLayout();
      this.SuspendLayout();
      this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
      this.NotifyIcon1.Icon = (Icon) resources.GetObject("NotifyIcon1.Icon");
      this.NotifyIcon1.Text = "Oculus Tray Tool";
      this.ContextMenuStrip1.ImageScalingSize = new Size(20, 20);
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.ToolStripStartOVR,
        (ToolStripItem) this.ToolStripStopOVR,
        (ToolStripItem) this.ToolStripRestartOVR,
        (ToolStripItem) this.ToolStripSeparator2,
        (ToolStripItem) this.ToolStripMenuItem3,
        (ToolStripItem) this.ToolStripSeparator1,
        (ToolStripItem) this.ToolStripMenuItem2,
        (ToolStripItem) this.ToolStripMenuShowHome,
        (ToolStripItem) this.ToolStripMenuItem1
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(230, 198);
      this.ToolStripStartOVR.Image = (System.Drawing.Image)resources.GetObject("ToolStripStartOVR.Image");
      this.ToolStripStartOVR.Name = "ToolStripStartOVR";
      this.ToolStripStartOVR.Size = new Size(229, 26);
      this.ToolStripStartOVR.Text = "Start Oculus Service";
      this.ToolStripStopOVR.Image = (System.Drawing.Image)resources.GetObject("ToolStripStopOVR.Image");
      this.ToolStripStopOVR.Name = "ToolStripStopOVR";
      this.ToolStripStopOVR.Size = new Size(229, 26);
      this.ToolStripStopOVR.Text = "Stop Oculus Service";
      this.ToolStripRestartOVR.Image = (System.Drawing.Image)resources.GetObject("ToolStripRestartOVR.Image");
      this.ToolStripRestartOVR.Name = "ToolStripRestartOVR";
      this.ToolStripRestartOVR.Size = new Size(229, 26);
      this.ToolStripRestartOVR.Text = "Restart Oculus Service";
      this.ToolStripSeparator2.Name = "ToolStripSeparator2";
      this.ToolStripSeparator2.Size = new Size(226, 6);
      this.ToolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem3.Image");
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new Size(229, 26);
      this.ToolStripMenuItem3.Text = "Set Rift as default Audio/Mic";
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new Size(226, 6);
      this.ToolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem2.Image");
      this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      this.ToolStripMenuItem2.Size = new Size(229, 26);
      this.ToolStripMenuItem2.Text = "Show Application";
      this.ToolStripMenuShowHome.Enabled = false;
      this.ToolStripMenuShowHome.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuShowHome.Image");
      this.ToolStripMenuShowHome.Name = "ToolStripMenuShowHome";
      this.ToolStripMenuShowHome.Size = new Size(229, 26);
      this.ToolStripMenuShowHome.Text = "Show Oculus Home";
      this.ToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem1.Image");
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new Size(229, 26);
      this.ToolStripMenuItem1.Text = "Exit";
      this.ContextMenuStrip2.ImageScalingSize = new Size(20, 20);
      this.ContextMenuStrip2.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.ToolStripMenuItem4,
        (ToolStripItem) this.ClearLogToolStripMenuItem,
        (ToolStripItem) this.OpenLogToolStripMenuItem
      });
      this.ContextMenuStrip2.Name = "ContextMenuStrip2";
      this.ContextMenuStrip2.Size = new Size(227, 82);
      this.ToolStripMenuItem4.Enabled = false;
      this.ToolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem4.Image");
      this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
      this.ToolStripMenuItem4.Size = new Size(226, 26);
      this.ToolStripMenuItem4.Text = "Disable Power Management";
      this.ToolStripMenuItem4.Visible = false;
      this.ClearLogToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("ClearLogToolStripMenuItem.Image");
      this.ClearLogToolStripMenuItem.Name = "ClearLogToolStripMenuItem";
      this.ClearLogToolStripMenuItem.Size = new Size(226, 26);
      this.ClearLogToolStripMenuItem.Text = "Clear Log";
      this.OpenLogToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("OpenLogToolStripMenuItem.Image");
      this.OpenLogToolStripMenuItem.Name = "OpenLogToolStripMenuItem";
      this.OpenLogToolStripMenuItem.Size = new Size(226, 26);
      this.OpenLogToolStripMenuItem.Text = "Open Log";
      this.ToolTip.AutoPopDelay = 10000;
      this.ToolTip.InitialDelay = 100;
      this.ToolTip.ReshowDelay = 100;
      this.PictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox1.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox1.Cursor = Cursors.Hand;
      this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
      this.PictureBox1.Location = new Point(30, 401);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(99, 31);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 9;
      this.PictureBox1.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox1, "Donate to the project");
      this.PictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox2.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox2.Image = (System.Drawing.Image)resources.GetObject("PictureBox2.Image");
      this.PictureBox2.Location = new Point(5, 408);
      this.PictureBox2.Name = "PictureBox2";
      this.PictureBox2.Size = new Size(19, 20);
      this.PictureBox2.TabIndex = 32;
      this.PictureBox2.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox2, "About");
      this.ComboSSstart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboSSstart.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboSSstart.FlatStyle = FlatStyle.Popup;
      this.ComboSSstart.FormattingEnabled = true;
      this.ComboSSstart.Items.AddRange(new object[38]
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
      this.ComboSSstart.Location = new Point(167, 39);
      this.ComboSSstart.Name = "ComboSSstart";
      this.ComboSSstart.Size = new Size(116, 23);
      this.ComboSSstart.Sorted = true;
      this.ComboSSstart.TabIndex = 11;
      this.ComboSSstart.TabStop = false;
      this.ToolTip.SetToolTip(this.ComboSSstart, "This is the Super Sampling modifier set on startup. All VR apps that do not have a profile will inherit this setting");
      this.ComboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox1.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox1.FlatStyle = FlatStyle.Popup;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Items.AddRange(new object[7]
      {
        (object) "18 Hz",
        (object) "30 Hz",
        (object) "45 Hz",
        (object) "45 Hz forced",
        (object) "Adaptive",
        (object) "Auto",
        (object) "Off"
      });
      this.ComboBox1.Location = new Point(167, 72);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(116, 23);
      this.ComboBox1.Sorted = true;
      this.ComboBox1.TabIndex = 25;
      this.ComboBox1.TabStop = false;
      this.ToolTip.SetToolTip(this.ComboBox1, "This is the ASW mode set on startup. All VR apps that do not have a profile will inherit this setting");
      this.Label1.Dock = DockStyle.Fill;
      this.Label1.Location = new Point(4, 34);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(156, 32);
      this.Label1.TabIndex = 21;
      this.Label1.Text = "Default Super Sampling";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip(this.Label1, "This is the Super Sampling modifier set on startup. All VR apps that do not have a profile will inherit this setting");
      this.Label6.Dock = DockStyle.Fill;
      this.Label6.Location = new Point(4, 67);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(156, 32);
      this.Label6.TabIndex = 26;
      this.Label6.Text = "Default ASW Mode";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip(this.Label6, "This is the ASW mode set on startup. All VR apps that do not have a profile will inherit this setting");
      this.ComboHomless.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboHomless.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboHomless.FlatStyle = FlatStyle.Popup;
      this.ComboHomless.FormattingEnabled = true;
      this.ComboHomless.Items.AddRange(new object[2]
      {
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboHomless.Location = new Point(167, 202);
      this.ComboHomless.Name = "ComboHomless";
      this.ComboHomless.Size = new Size(116, 23);
      this.ComboHomless.TabIndex = 37;
      this.ToolTip.SetToolTip(this.ComboHomless, "Enable or Disable Oculus Homeless");
      this.Label5.Dock = DockStyle.Fill;
      this.Label5.Location = new Point(4, 166);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(156, 32);
      this.Label5.TabIndex = 12;
      this.Label5.Text = "Voice Commands";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip(this.Label5, "Enable voice commands");
      this.ComboVoice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboVoice.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboVoice.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboVoice.FlatStyle = FlatStyle.Popup;
      this.ComboVoice.FormattingEnabled = true;
      this.ComboVoice.Items.AddRange(new object[2]
      {
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboVoice.Location = new Point(167, 171);
      this.ComboVoice.Name = "ComboVoice";
      this.ComboVoice.Size = new Size(116, 23);
      this.ComboVoice.TabIndex = 13;
      this.ComboVoice.TabStop = false;
      this.ToolTip.SetToolTip(this.ComboVoice, "Enable Voice commands");
      this.BtnVoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnVoice.FlatStyle = FlatStyle.Flat;
      this.BtnVoice.Location = new Point(290, 169);
      this.BtnVoice.Name = "BtnVoice";
      this.BtnVoice.Size = new Size(59, 26);
      this.BtnVoice.TabIndex = 24;
      this.BtnVoice.TabStop = false;
      this.BtnVoice.Text = "Edit";
      this.ToolTip.SetToolTip(this.BtnVoice, "Configure Voice Commands");
      this.BtnVoice.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Location = new Point(290, 136);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(59, 26);
      this.Button2.TabIndex = 34;
      this.Button2.TabStop = false;
      this.Button2.Text = "Save";
      this.ToolTip.SetToolTip(this.Button2, "Sets the FOV on your regular 2D display. Useful when streaming gameplay.\r\nDoes not affect FOV in the Rift itself.");
      this.Button2.UseVisualStyleBackColor = true;
      this.PictureBox8.Anchor = AnchorStyles.None;
      this.PictureBox8.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox8.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox8.Image = (System.Drawing.Image)resources.GetObject("PictureBox8.Image");
      this.PictureBox8.Location = new Point(310, 7);
      this.PictureBox8.Name = "PictureBox8";
      this.PictureBox8.Size = new Size(19, 20);
      this.PictureBox8.TabIndex = 53;
      this.PictureBox8.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox8, "Create a Profile with custom settings for each of your games.");
      this.CheckRiftAudio.Dock = DockStyle.Fill;
      this.CheckRiftAudio.Location = new Point(4, 90);
      this.CheckRiftAudio.Name = "CheckRiftAudio";
      this.CheckRiftAudio.Size = new Size(153, 36);
      this.CheckRiftAudio.TabIndex = 7;
      this.CheckRiftAudio.TabStop = false;
      this.CheckRiftAudio.Text = "Use Audio Switcher";
      this.ToolTip.SetToolTip(this.CheckRiftAudio, "Check to have the Rift set as default device for Audio and/or Mic when Oculus Home starts");
      this.CheckRiftAudio.UseVisualStyleBackColor = true;
      this.CheckSpoofCPU.Dock = DockStyle.Fill;
      this.CheckSpoofCPU.Location = new Point(4, 214);
      this.CheckSpoofCPU.Name = "CheckSpoofCPU";
      this.CheckSpoofCPU.Size = new Size(322, 23);
      this.CheckSpoofCPU.TabIndex = 27;
      this.CheckSpoofCPU.TabStop = false;
      this.CheckSpoofCPU.Text = "Spoof CPU ID on tool start";
      this.ToolTip.SetToolTip(this.CheckSpoofCPU, "Check to spoof the CPU ID. Makes Oculus nag screen regarding minimum specs go away. Takes affect immediately when checked and forces a restart of the OVR service.");
      this.CheckSpoofCPU.UseVisualStyleBackColor = true;
      this.ButtonRestartOVR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ButtonRestartOVR.FlatAppearance.BorderSize = 0;
      this.ButtonRestartOVR.FlatStyle = FlatStyle.Flat;
      this.ButtonRestartOVR.Image = (System.Drawing.Image)resources.GetObject("ButtonRestartOVR.Image");
      this.ButtonRestartOVR.Location = new Point(292, 3);
      this.ButtonRestartOVR.Name = "ButtonRestartOVR";
      this.ButtonRestartOVR.Size = new Size(52, 55);
      this.ButtonRestartOVR.TabIndex = 16;
      this.ButtonRestartOVR.TabStop = false;
      this.ToolTip.SetToolTip(this.ButtonRestartOVR, "Restart the Oculus service if it is running");
      this.ButtonRestartOVR.UseVisualStyleBackColor = true;
      this.ButtonStartOVR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ButtonStartOVR.FlatAppearance.BorderSize = 0;
      this.ButtonStartOVR.FlatStyle = FlatStyle.Flat;
      this.ButtonStartOVR.Image = (System.Drawing.Image)resources.GetObject("ButtonStartOVR.Image");
      this.ButtonStartOVR.Location = new Point(183, 3);
      this.ButtonStartOVR.Name = "ButtonStartOVR";
      this.ButtonStartOVR.Size = new Size(50, 55);
      this.ButtonStartOVR.TabIndex = 14;
      this.ButtonStartOVR.TabStop = false;
      this.ToolTip.SetToolTip(this.ButtonStartOVR, "Start the Oculus service if it is down");
      this.ButtonStartOVR.UseVisualStyleBackColor = true;
      this.ButtonStopOVR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ButtonStopOVR.FlatAppearance.BorderSize = 0;
      this.ButtonStopOVR.FlatStyle = FlatStyle.Flat;
      this.ButtonStopOVR.Image = (System.Drawing.Image)resources.GetObject("ButtonStopOVR.Image");
      this.ButtonStopOVR.Location = new Point(239, 3);
      this.ButtonStopOVR.Name = "ButtonStopOVR";
      this.ButtonStopOVR.Size = new Size(47, 55);
      this.ButtonStopOVR.TabIndex = 15;
      this.ButtonStopOVR.TabStop = false;
      this.ToolTip.SetToolTip(this.ButtonStopOVR, "Stop the Oculus service if it is running");
      this.ButtonStopOVR.UseVisualStyleBackColor = true;
      this.Label29.Dock = DockStyle.Fill;
      this.Label29.Location = new Point(4, 345);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(155, 50);
      this.Label29.TabIndex = 38;
      this.Label29.Text = "Game Library";
      this.Label29.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip(this.Label29, "Enable voice commands");
      this.CheckLocalDebug.AutoSize = true;
      this.CheckLocalDebug.Dock = DockStyle.Fill;
      this.CheckLocalDebug.Location = new Point(166, 4);
      this.CheckLocalDebug.Name = "CheckLocalDebug";
      this.CheckLocalDebug.RightToLeft = RightToLeft.No;
      this.CheckLocalDebug.Size = new Size(156, 41);
      this.CheckLocalDebug.TabIndex = 0;
      this.CheckLocalDebug.Text = "Use OTT Local";
      this.ToolTip.SetToolTip(this.CheckLocalDebug, "Use the Oculus Debug Tool shipped with OTT. Don't check this box unless you know what you are doing as it could potantially break functionality.");
      this.CheckLocalDebug.UseVisualStyleBackColor = true;
      this.CheckStartWatcher.AutoSize = true;
      this.CheckStartWatcher.Dock = DockStyle.Fill;
      this.CheckStartWatcher.Location = new Point(166, 52);
      this.CheckStartWatcher.Name = "CheckStartWatcher";
      this.CheckStartWatcher.Size = new Size(156, 41);
      this.CheckStartWatcher.TabIndex = 4;
      this.CheckStartWatcher.Text = "Start on OTT Start";
      this.ToolTip.SetToolTip(this.CheckStartWatcher, resources.GetString("CheckStartWatcher.ToolTip"));
      this.CheckStartWatcher.UseVisualStyleBackColor = true;
      this.Label13.AutoSize = true;
      this.Label13.Dock = DockStyle.Fill;
      this.Label13.Location = new Point(4, 1);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(155, 47);
      this.Label13.TabIndex = 31;
      this.Label13.Text = "Oculus Debug Tool";
      this.Label13.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip(this.Label13, "Use the Oculus Debug Tool shipped with OTT. Don't check this box unless you know what you are doing as it could potantially break functionality.");
      this.Label18.AutoSize = true;
      this.Label18.Dock = DockStyle.Fill;
      this.Label18.Location = new Point(4, 49);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(155, 47);
      this.Label18.TabIndex = 32;
      this.Label18.Text = " AppWatcher";
      this.Label18.TextAlign = ContentAlignment.MiddleLeft;
      this.ToolTip.SetToolTip(this.Label18, resources.GetString("Label18.ToolTip"));
      this.Button4.Dock = DockStyle.Fill;
      this.Button4.FlatStyle = FlatStyle.Flat;
      this.Button4.Location = new Point(166, 100);
      this.Button4.Name = "Button4";
      this.Button4.Size = new Size(156, 41);
      this.Button4.TabIndex = 3;
      this.Button4.Text = "Reset all to default";
      this.ToolTip.SetToolTip(this.Button4, "Reset all settings to Default");
      this.Button4.UseVisualStyleBackColor = true;
      this.BtnRemoveAllProfiles.Dock = DockStyle.Fill;
      this.BtnRemoveAllProfiles.FlatStyle = FlatStyle.Flat;
      this.BtnRemoveAllProfiles.Location = new Point(166, 148);
      this.BtnRemoveAllProfiles.Name = "BtnRemoveAllProfiles";
      this.BtnRemoveAllProfiles.Size = new Size(156, 41);
      this.BtnRemoveAllProfiles.TabIndex = 5;
      this.BtnRemoveAllProfiles.Text = "Remove all";
      this.ToolTip.SetToolTip(this.BtnRemoveAllProfiles, "Remove all Profiles");
      this.BtnRemoveAllProfiles.UseVisualStyleBackColor = true;
      this.Button1.Dock = DockStyle.Fill;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(166, 196);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(156, 41);
      this.Button1.TabIndex = 6;
      this.Button1.Text = "Check for updates";
      this.ToolTip.SetToolTip(this.Button1, "Manually check if there's any updates available");
      this.Button1.UseVisualStyleBackColor = true;
      this.Button5.Dock = DockStyle.Fill;
      this.Button5.FlatStyle = FlatStyle.Flat;
      this.Button5.Location = new Point(166, 244);
      this.Button5.Name = "Button5";
      this.Button5.Size = new Size(156, 44);
      this.Button5.TabIndex = 7;
      this.Button5.Text = "Restart in Debug mode";
      this.ToolTip.SetToolTip(this.Button5, "Restart in Debug mode for additional logging");
      this.Button5.UseVisualStyleBackColor = true;
      this.PictureBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox7.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox7.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox7.Image = (System.Drawing.Image)resources.GetObject("PictureBox7.Image");
      this.PictureBox7.Location = new Point(314, 133);
      this.PictureBox7.Name = "PictureBox7";
      this.PictureBox7.Size = new Size(19, 20);
      this.PictureBox7.TabIndex = 37;
      this.PictureBox7.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox7, "Override distortion curvature. Higher curvature gives higher pixel density in center.");
      this.PictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox6.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox6.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox6.Image = (System.Drawing.Image)resources.GetObject("PictureBox6.Image");
      this.PictureBox6.Location = new Point(314, 199);
      this.PictureBox6.Name = "PictureBox6";
      this.PictureBox6.Size = new Size(19, 20);
      this.PictureBox6.TabIndex = 36;
      this.PictureBox6.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox6, "Override encoding bitrate");
      this.PictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox5.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox5.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox5.Image = (System.Drawing.Image)resources.GetObject("PictureBox5.Image");
      this.PictureBox5.Location = new Point(314, 265);
      this.PictureBox5.Name = "PictureBox5";
      this.PictureBox5.Size = new Size(19, 20);
      this.PictureBox5.TabIndex = 35;
      this.PictureBox5.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox5, "Override maximum dynamic bitrate");
      this.PictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox4.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox4.Image = (System.Drawing.Image)resources.GetObject("PictureBox4.Image");
      this.PictureBox4.Location = new Point(314, 232);
      this.PictureBox4.Name = "PictureBox4";
      this.PictureBox4.Size = new Size(19, 20);
      this.PictureBox4.TabIndex = 34;
      this.PictureBox4.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox4, "Automatically adjust bitrate");
      this.PictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
      this.PictureBox3.BackgroundImageLayout = ImageLayout.None;
      this.PictureBox3.Image = (System.Drawing.Image)resources.GetObject("PictureBox3.Image");
      this.PictureBox3.Location = new Point(314, 336);
      this.PictureBox3.Name = "PictureBox3";
      this.PictureBox3.Size = new Size(19, 20);
      this.PictureBox3.TabIndex = 33;
      this.PictureBox3.TabStop = false;
      this.ToolTip.SetToolTip(this.PictureBox3, "Uses Paolod29's code to patch AirLink and make it permanently enabled.\r\nYou need to run this again if the Oculus App is updated.\r\nCheck out https://github.com/pd29/oculus-airlink-enabler \r\nfor more.");
      this.Button11.Enabled = false;
      this.Button11.FlatStyle = FlatStyle.Flat;
      this.Button11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button11.Location = new Point(314, 98);
      this.Button11.Name = "Button11";
      this.Button11.Size = new Size(22, 22);
      this.Button11.TabIndex = 11;
      this.Button11.Text = "+";
      this.ToolTip.SetToolTip(this.Button11, "Create Custom Preset");
      this.Button11.UseVisualStyleBackColor = true;
      this.Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label8.AutoSize = true;
      this.Label8.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label8.ForeColor = System.Drawing.Color.DarkRed;
      this.Label8.Location = new Point(432, 0);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(68, 12);
      this.Label8.TabIndex = 7;
      this.Label8.Text = "By ApollyonVR";
      this.NotificationTimer.Interval = 1500;
      this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
      this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.ImageList1.Images.SetKeyName(0, "Icon_GameSettings.png");
      this.ImageList1.Images.SetKeyName(1, "Icon_TrayTool.png");
      this.ImageList1.Images.SetKeyName(2, "Icon_PowerOptions.png");
      this.ImageList1.Images.SetKeyName(3, "Icon_Service&Startup.png");
      this.ImageList1.Images.SetKeyName(4, "Icon_Log.png");
      this.ImageList1.Images.SetKeyName(5, "icon-advanced.png");
      this.ImageList1.Images.SetKeyName(6, "up-32.png");
      this.ImageList1.Images.SetKeyName(7, "icon_QuestLink.png");
      this.UpdateTimer.Interval = 5000;
      this.NotifyIcon3.Icon = (Icon) resources.GetObject("NotifyIcon3.Icon");
      this.NotifyIcon3.Text = "Oculus Home";
      this.PowerPlanTimer.Interval = 2000;
      this.DotNetBarTabcontrol1.Alignment = TabAlignment.Left;
      this.DotNetBarTabcontrol1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage1);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage2);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage3);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage4);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage5);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage7);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage8);
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage6);
      this.DotNetBarTabcontrol1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.DotNetBarTabcontrol1.ImageList = this.ImageList1;
      this.DotNetBarTabcontrol1.ItemSize = new Size(43, 135);
      this.DotNetBarTabcontrol1.Location = new Point(0, 0);
      this.DotNetBarTabcontrol1.Multiline = true;
      this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
      this.DotNetBarTabcontrol1.Padding = new Point(6, 8);
      this.DotNetBarTabcontrol1.SelectedIndex = 0;
      this.DotNetBarTabcontrol1.Size = new Size(508, 433);
      this.DotNetBarTabcontrol1.SizeMode = TabSizeMode.Fixed;
      this.DotNetBarTabcontrol1.TabIndex = 29;
      this.TabPage1.BackColor = System.Drawing.Color.White;
      this.TabPage1.Controls.Add(this.GroupBox14);
      this.TabPage1.Location = new Point(139, 4);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Padding = new Padding(3);
      this.TabPage1.Size = new Size(365, 425);
      this.TabPage1.TabIndex = 0;
      this.TabPage1.Text = "Game Settings";
      this.GroupBox14.Controls.Add(this.DbLayoutPanel2);
      this.GroupBox14.Dock = DockStyle.Fill;
      this.GroupBox14.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox14.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox14.Location = new Point(3, 3);
      this.GroupBox14.Name = "GroupBox14";
      this.GroupBox14.Size = new Size(359, 419);
      this.GroupBox14.TabIndex = 0;
      this.GroupBox14.TabStop = false;
      this.DbLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel2.ColumnCount = 3;
      this.DbLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.5356f));
      this.DbLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.12687f));
      this.DbLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.33753f));
      this.DbLayoutPanel2.Controls.Add(this.Label19, 0, 9);
      this.DbLayoutPanel2.Controls.Add(this.Label7, 0, 0);
      this.DbLayoutPanel2.Controls.Add(this.BtnProfiles, 1, 0);
      this.DbLayoutPanel2.Controls.Add(this.ComboSSstart, 1, 1);
      this.DbLayoutPanel2.Controls.Add(this.ComboBox1, 1, 2);
      this.DbLayoutPanel2.Controls.Add(this.Label1, 0, 1);
      this.DbLayoutPanel2.Controls.Add(this.Label6, 0, 2);
      this.DbLayoutPanel2.Controls.Add(this.Label9, 0, 8);
      this.DbLayoutPanel2.Controls.Add(this.Label17, 0, 7);
      this.DbLayoutPanel2.Controls.Add(this.ComboMirrorHome, 1, 7);
      this.DbLayoutPanel2.Controls.Add(this.Label16, 0, 6);
      this.DbLayoutPanel2.Controls.Add(this.ComboHomless, 1, 6);
      this.DbLayoutPanel2.Controls.Add(this.BtnHomless, 2, 6);
      this.DbLayoutPanel2.Controls.Add(this.Label5, 0, 5);
      this.DbLayoutPanel2.Controls.Add(this.ComboVoice, 1, 5);
      this.DbLayoutPanel2.Controls.Add(this.BtnVoice, 2, 5);
      this.DbLayoutPanel2.Controls.Add(this.Label15, 0, 4);
      this.DbLayoutPanel2.Controls.Add(this.Button2, 2, 4);
      this.DbLayoutPanel2.Controls.Add(this.Label35, 0, 3);
      this.DbLayoutPanel2.Controls.Add(this.ComboVisualHUD, 1, 8);
      this.DbLayoutPanel2.Controls.Add(this.ComboBox5, 1, 3);
      this.DbLayoutPanel2.Controls.Add(this.SplitContainer1, 1, 4);
      this.DbLayoutPanel2.Controls.Add(this.ComboOVRPrio, 1, 9);
      this.DbLayoutPanel2.Controls.Add(this.Label33, 0, 10);
      this.DbLayoutPanel2.Controls.Add(this.ComboBox8, 1, 10);
      this.DbLayoutPanel2.Controls.Add(this.ComboBox9, 1, 11);
      this.DbLayoutPanel2.Controls.Add(this.Label37, 0, 11);
      this.DbLayoutPanel2.Controls.Add(this.PictureBox8, 2, 0);
      this.DbLayoutPanel2.Dock = DockStyle.Fill;
      this.DbLayoutPanel2.Location = new Point(3, 17);
      this.DbLayoutPanel2.Name = "DbLayoutPanel2";
      this.DbLayoutPanel2.RowCount = 12;
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332f));
      this.DbLayoutPanel2.Size = new Size(353, 399);
      this.DbLayoutPanel2.TabIndex = 1;
      this.Label19.Dock = DockStyle.Fill;
      this.Label19.Location = new Point(4, 298);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(156, 32);
      this.Label19.TabIndex = 47;
      this.Label19.Text = "OVR Server Priority";
      this.Label19.TextAlign = ContentAlignment.MiddleLeft;
      this.Label7.Dock = DockStyle.Fill;
      this.Label7.Location = new Point(4, 1);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(156, 32);
      this.Label7.TabIndex = 16;
      this.Label7.Text = "Profiles";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      this.BtnProfiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnProfiles.FlatStyle = FlatStyle.Flat;
      this.BtnProfiles.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnProfiles.Location = new Point(167, 4);
      this.BtnProfiles.Name = "BtnProfiles";
      this.BtnProfiles.Size = new Size(116, 26);
      this.BtnProfiles.TabIndex = 10;
      this.BtnProfiles.TabStop = false;
      this.BtnProfiles.Text = "View && Edit";
      this.BtnProfiles.UseVisualStyleBackColor = true;
      this.Label9.Dock = DockStyle.Fill;
      this.Label9.Location = new Point(4, 265);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(156, 32);
      this.Label9.TabIndex = 39;
      this.Label9.Text = "Visual HUD";
      this.Label9.TextAlign = ContentAlignment.MiddleLeft;
      this.Label17.AutoSize = true;
      this.Label17.Dock = DockStyle.Fill;
      this.Label17.Location = new Point(4, 232);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(156, 32);
      this.Label17.TabIndex = 41;
      this.Label17.Text = "Mirror Oculus Home";
      this.Label17.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboMirrorHome.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboMirrorHome.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboMirrorHome.FlatStyle = FlatStyle.Popup;
      this.ComboMirrorHome.FormattingEnabled = true;
      this.ComboMirrorHome.Items.AddRange(new object[2]
      {
        (object) "Enabled",
        (object) "Disabled"
      });
      this.ComboMirrorHome.Location = new Point(167, 235);
      this.ComboMirrorHome.Name = "ComboMirrorHome";
      this.ComboMirrorHome.Size = new Size(116, 23);
      this.ComboMirrorHome.TabIndex = 42;
      this.Label16.AutoSize = true;
      this.Label16.Dock = DockStyle.Fill;
      this.Label16.Location = new Point(4, 199);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(156, 32);
      this.Label16.TabIndex = 36;
      this.Label16.Text = "Oculus Homeless";
      this.Label16.TextAlign = ContentAlignment.MiddleLeft;
      this.BtnHomless.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnHomless.Enabled = false;
      this.BtnHomless.FlatStyle = FlatStyle.Flat;
      this.BtnHomless.Location = new Point(290, 202);
      this.BtnHomless.Name = "BtnHomless";
      this.BtnHomless.Size = new Size(59, 26);
      this.BtnHomless.TabIndex = 38;
      this.BtnHomless.Text = "Edit";
      this.BtnHomless.UseVisualStyleBackColor = true;
      this.Label15.Dock = DockStyle.Fill;
      this.Label15.Location = new Point(4, 133);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(156, 32);
      this.Label15.TabIndex = 32;
      this.Label15.Text = "FoV Multiplier";
      this.Label15.TextAlign = ContentAlignment.MiddleLeft;
      this.Label35.AutoSize = true;
      this.Label35.Dock = DockStyle.Fill;
      this.Label35.Location = new Point(4, 100);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(156, 32);
      this.Label35.TabIndex = 44;
      this.Label35.Text = "Adaptive GPU Scaling";
      this.Label35.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboVisualHUD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboVisualHUD.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboVisualHUD.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboVisualHUD.DropDownWidth = 180;
      this.ComboVisualHUD.FlatStyle = FlatStyle.Popup;
      this.ComboVisualHUD.FormattingEnabled = true;
      this.ComboVisualHUD.Items.AddRange(new object[8]
      {
        (object) "None",
        (object) "Pixel Density",
        (object) "Performance",
        (object) "ASW Status",
        (object) "Latency Timing",
        (object) "Application Render Timing",
        (object) "Compositor Render Timing",
        (object) "Version Info"
      });
      this.ComboVisualHUD.Location = new Point(167, 270);
      this.ComboVisualHUD.Name = "ComboVisualHUD";
      this.ComboVisualHUD.Size = new Size(116, 23);
      this.ComboVisualHUD.TabIndex = 40;
      this.ComboBox5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboBox5.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox5.FlatStyle = FlatStyle.Popup;
      this.ComboBox5.FormattingEnabled = true;
      this.ComboBox5.Items.AddRange(new object[2]
      {
        (object) "On",
        (object) "Off"
      });
      this.ComboBox5.Location = new Point(167, 105);
      this.ComboBox5.Name = "ComboBox5";
      this.ComboBox5.Size = new Size(116, 23);
      this.ComboBox5.TabIndex = 45;
      this.ComboBox5.TabStop = false;
      this.SplitContainer1.Dock = DockStyle.Fill;
      this.SplitContainer1.Location = new Point(167, 136);
      this.SplitContainer1.Name = "SplitContainer1";
      this.SplitContainer1.Panel1.Controls.Add(this.NumericFOVh);
      this.SplitContainer1.Panel2.Controls.Add(this.NumericFOVv);
      this.SplitContainer1.Size = new Size(116, 26);
      this.SplitContainer1.SplitterDistance = 53;
      this.SplitContainer1.TabIndex = 46;
      this.NumericFOVh.Anchor = AnchorStyles.None;
      this.NumericFOVh.DecimalPlaces = 2;
      this.NumericFOVh.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        131072
      });
      this.NumericFOVh.Location = new Point(1, 3);
      this.NumericFOVh.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.NumericFOVh.Name = "NumericFOVh";
      this.NumericFOVh.Size = new Size(52, 21);
      this.NumericFOVh.TabIndex = 33;
      this.NumericFOVv.Anchor = AnchorStyles.None;
      this.NumericFOVv.DecimalPlaces = 2;
      this.NumericFOVv.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        131072
      });
      this.NumericFOVv.Location = new Point(2, 3);
      this.NumericFOVv.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.NumericFOVv.Name = "NumericFOVv";
      this.NumericFOVv.Size = new Size(54, 21);
      this.NumericFOVv.TabIndex = 34;
      this.ComboOVRPrio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboOVRPrio.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboOVRPrio.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboOVRPrio.DropDownWidth = 180;
      this.ComboOVRPrio.FlatStyle = FlatStyle.Popup;
      this.ComboOVRPrio.FormattingEnabled = true;
      this.ComboOVRPrio.Items.AddRange(new object[4]
      {
        (object) "Normal",
        (object) "Above normal",
        (object) "High",
        (object) "Realtime"
      });
      this.ComboOVRPrio.Location = new Point(167, 303);
      this.ComboOVRPrio.Name = "ComboOVRPrio";
      this.ComboOVRPrio.Size = new Size(116, 23);
      this.ComboOVRPrio.TabIndex = 48;
      this.Label33.AutoSize = true;
      this.Label33.Dock = DockStyle.Fill;
      this.Label33.Location = new Point(4, 331);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(156, 32);
      this.Label33.TabIndex = 49;
      this.Label33.Text = "Force MipMap On Layers";
      this.Label33.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox8.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox8.Dock = DockStyle.Fill;
      this.ComboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox8.FlatStyle = FlatStyle.Popup;
      this.ComboBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox8.FormattingEnabled = true;
      this.ComboBox8.Items.AddRange(new object[2]
      {
        (object) "True",
        (object) "False"
      });
      this.ComboBox8.Location = new Point(167, 334);
      this.ComboBox8.Name = "ComboBox8";
      this.ComboBox8.Size = new Size(116, 24);
      this.ComboBox8.TabIndex = 50;
      this.ComboBox9.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox9.Dock = DockStyle.Fill;
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
      this.ComboBox9.Location = new Point(167, 367);
      this.ComboBox9.Name = "ComboBox9";
      this.ComboBox9.Size = new Size(116, 24);
      this.ComboBox9.TabIndex = 52;
      this.Label37.AutoSize = true;
      this.Label37.Dock = DockStyle.Fill;
      this.Label37.Location = new Point(4, 364);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(156, 34);
      this.Label37.TabIndex = 51;
      this.Label37.Text = "Offset MipMap On Layers";
      this.Label37.TextAlign = ContentAlignment.MiddleLeft;
      this.TabPage2.BackColor = System.Drawing.Color.White;
      this.TabPage2.Controls.Add(this.GroupBox1);
      this.TabPage2.Location = new Point(139, 4);
      this.TabPage2.Name = "TabPage2";
      this.TabPage2.Padding = new Padding(3);
      this.TabPage2.Size = new Size(365, 425);
      this.TabPage2.TabIndex = 1;
      this.TabPage2.Text = "Tray Tool";
      this.GroupBox1.Controls.Add(this.DbLayoutPanel4);
      this.GroupBox1.Dock = DockStyle.Fill;
      this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox1.ForeColor = SystemColors.ControlText;
      this.GroupBox1.Location = new Point(3, 3);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(359, 419);
      this.GroupBox1.TabIndex = 11;
      this.GroupBox1.TabStop = false;
      this.DbLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel4.ColumnCount = 2;
      this.DbLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191f));
      this.DbLayoutPanel4.Controls.Add(this.CheckStartWithWindows, 0, 0);
      this.DbLayoutPanel4.Controls.Add(this.CheckStartMin, 0, 1);
      this.DbLayoutPanel4.Controls.Add(this.CheckMinimizeOnX, 0, 4);
      this.DbLayoutPanel4.Controls.Add(this.CheckRiftAudio, 0, 2);
      this.DbLayoutPanel4.Controls.Add(this.CheckBoxAltTab, 0, 3);
      this.DbLayoutPanel4.Controls.Add(this.HotKeysCheckBox, 0, 5);
      this.DbLayoutPanel4.Controls.Add(this.BtnConfigureAudio, 1, 2);
      this.DbLayoutPanel4.Controls.Add(this.Label14, 0, 7);
      this.DbLayoutPanel4.Controls.Add(this.CheckBoxCheckForUpdates, 0, 6);
      this.DbLayoutPanel4.Controls.Add(this.BtnConfigureHotKeys, 1, 5);
      this.DbLayoutPanel4.Controls.Add(this.TrackBar1, 0, 8);
      this.DbLayoutPanel4.Dock = DockStyle.Fill;
      this.DbLayoutPanel4.ForeColor = System.Drawing.Color.DodgerBlue;
      this.DbLayoutPanel4.Location = new Point(3, 17);
      this.DbLayoutPanel4.Name = "DbLayoutPanel4";
      this.DbLayoutPanel4.RowCount = 9;
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.27596f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10.09F));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 8.902077f));
      this.DbLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.91395f));
      this.DbLayoutPanel4.Size = new Size(353, 399);
      this.DbLayoutPanel4.TabIndex = 12;
      this.CheckStartWithWindows.AutoSize = true;
      this.CheckStartWithWindows.Dock = DockStyle.Fill;
      this.CheckStartWithWindows.Location = new Point(4, 4);
      this.CheckStartWithWindows.Name = "CheckStartWindows";
      this.CheckStartWithWindows.Size = new Size(153, 36);
      this.CheckStartWithWindows.TabIndex = 4;
      this.CheckStartWithWindows.TabStop = false;
      this.CheckStartWithWindows.Text = "Start with Windows";
      this.CheckStartWithWindows.UseVisualStyleBackColor = true;
      this.CheckStartMin.Dock = DockStyle.Fill;
      this.CheckStartMin.Location = new Point(4, 47);
      this.CheckStartMin.Name = "CheckStartMin";
      this.CheckStartMin.Size = new Size(153, 36);
      this.CheckStartMin.TabIndex = 5;
      this.CheckStartMin.TabStop = false;
      this.CheckStartMin.Text = "Start minimized";
      this.CheckStartMin.UseVisualStyleBackColor = true;
      this.CheckMinimizeOnX.Dock = DockStyle.Fill;
      this.CheckMinimizeOnX.Location = new Point(4, 176);
      this.CheckMinimizeOnX.Name = "CheckMinimizeOnX";
      this.CheckMinimizeOnX.Size = new Size(153, 36);
      this.CheckMinimizeOnX.TabIndex = 9;
      this.CheckMinimizeOnX.Text = "Minimize Tool on X";
      this.CheckMinimizeOnX.UseVisualStyleBackColor = true;
      this.CheckBoxAltTab.Dock = DockStyle.Fill;
      this.CheckBoxAltTab.Location = new Point(4, 133);
      this.CheckBoxAltTab.Name = "CheckBoxAltTab";
      this.CheckBoxAltTab.Size = new Size(153, 36);
      this.CheckBoxAltTab.TabIndex = 6;
      this.CheckBoxAltTab.TabStop = false;
      this.CheckBoxAltTab.Text = "Hide from Alt+Tab";
      this.CheckBoxAltTab.UseVisualStyleBackColor = true;
      this.HotKeysCheckBox.Dock = DockStyle.Fill;
      this.HotKeysCheckBox.Location = new Point(4, 219);
      this.HotKeysCheckBox.Name = "HotKeysCheckBox";
      this.HotKeysCheckBox.Size = new Size(153, 36);
      this.HotKeysCheckBox.TabIndex = 27;
      this.HotKeysCheckBox.Text = "Enable HotKeys";
      this.HotKeysCheckBox.UseVisualStyleBackColor = true;
      this.BtnConfigureAudio.Dock = DockStyle.Fill;
      this.BtnConfigureAudio.FlatStyle = FlatStyle.Flat;
      this.BtnConfigureAudio.Location = new Point(164, 90);
      this.BtnConfigureAudio.Name = "BtnConfigureAudio";
      this.BtnConfigureAudio.Size = new Size(185, 36);
      this.BtnConfigureAudio.TabIndex = 29;
      this.BtnConfigureAudio.Text = "Configure";
      this.BtnConfigureAudio.UseVisualStyleBackColor = true;

      this.Label14.AutoSize = true;
      this.Label14.Dock = DockStyle.Fill;
      this.Label14.ImageAlign = ContentAlignment.MiddleRight;
      this.Label14.Location = new Point(4, 298);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(153, 33);
      this.Label14.TabIndex = 28;
      this.Label14.Text = "Font Size: ";
      this.Label14.TextAlign = ContentAlignment.MiddleLeft;
      this.CheckBoxCheckForUpdates.AutoSize = true;
      this.CheckBoxCheckForUpdates.Dock = DockStyle.Fill;
      this.CheckBoxCheckForUpdates.Location = new Point(4, 262);
      this.CheckBoxCheckForUpdates.Name = "CheckBoxCheckForUpdates";
      this.CheckBoxCheckForUpdates.Size = new Size(153, 32);
      this.CheckBoxCheckForUpdates.TabIndex = 30;
      this.CheckBoxCheckForUpdates.Text = "Check for updates on startup";
      this.CheckBoxCheckForUpdates.UseVisualStyleBackColor = true;
      this.BtnConfigureHotKeys.Dock = DockStyle.Fill;
      this.BtnConfigureHotKeys.FlatStyle = FlatStyle.Flat;
      this.BtnConfigureHotKeys.Location = new Point(164, 219);
      this.BtnConfigureHotKeys.Name = "BtnConfigureHotKeys";
      this.BtnConfigureHotKeys.Size = new Size(185, 36);
      this.BtnConfigureHotKeys.TabIndex = 31;
      this.BtnConfigureHotKeys.Text = "Configure";
      this.BtnConfigureHotKeys.UseVisualStyleBackColor = true;

      this.TrackBar1.Dock = DockStyle.Fill;
      this.TrackBar1.Location = new Point(4, 335);
      this.TrackBar1.Maximum = 12;
      this.TrackBar1.Minimum = 8;
      this.TrackBar1.Name = "TrackBar1";
      this.TrackBar1.Size = new Size(153, 60);
      this.TrackBar1.TabIndex = 26;
      this.TrackBar1.Value = 8;
      this.TabPage3.BackColor = System.Drawing.Color.White;
      this.TabPage3.Controls.Add(this.GroupBox2);
      this.TabPage3.Location = new Point(139, 4);
      this.TabPage3.Name = "TabPage3";
      this.TabPage3.Padding = new Padding(3);
      this.TabPage3.Size = new Size(365, 425);
      this.TabPage3.TabIndex = 2;
      this.TabPage3.Text = "Power Options";
      this.GroupBox2.Controls.Add(this.DbLayoutPanel5);
      this.GroupBox2.Dock = DockStyle.Fill;
      this.GroupBox2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox2.Location = new Point(3, 3);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(359, 419);
      this.GroupBox2.TabIndex = 3;
      this.GroupBox2.TabStop = false;
      this.DbLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel5.ColumnCount = 2;
      this.DbLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.13433f));
      this.DbLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.86567f));
      this.DbLayoutPanel5.Controls.Add(this.ComboApplyPlan, 1, 2);
      this.DbLayoutPanel5.Controls.Add(this.Label4, 0, 3);
      this.DbLayoutPanel5.Controls.Add(this.ComboPowerPlanExit, 1, 1);
      this.DbLayoutPanel5.Controls.Add(this.Label2, 0, 0);
      this.DbLayoutPanel5.Controls.Add(this.ComboPowerPlanStart, 1, 0);
      this.DbLayoutPanel5.Controls.Add(this.Label22, 0, 1);
      this.DbLayoutPanel5.Controls.Add(this.Label3, 0, 2);
      this.DbLayoutPanel5.Controls.Add(this.Label23, 0, 4);
      this.DbLayoutPanel5.Controls.Add(this.CheckSensorPower, 1, 4);
      this.DbLayoutPanel5.Controls.Add(this.ComboUSBsusp, 1, 3);
      this.DbLayoutPanel5.Dock = DockStyle.Fill;
      this.DbLayoutPanel5.Location = new Point(3, 17);
      this.DbLayoutPanel5.Name = "DbLayoutPanel5";
      this.DbLayoutPanel5.RowCount = 5;
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667f));
      this.DbLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.DbLayoutPanel5.Size = new Size(353, 399);
      this.DbLayoutPanel5.TabIndex = 4;
      this.ComboApplyPlan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboApplyPlan.BackColor = System.Drawing.Color.White;
      this.ComboApplyPlan.ForeColor = System.Drawing.Color.Black;
      this.ComboApplyPlan.DrawMode = DrawMode.Normal;
      this.ComboApplyPlan.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboApplyPlan.FlatStyle = FlatStyle.Standard;
      this.ComboApplyPlan.FormattingEnabled = true;
      this.ComboApplyPlan.Items.AddRange(new object[2]
      {
        (object) "OTT Start/Exit",
        (object) "Oculus Home Start/Exit"
      });
      this.ComboApplyPlan.Location = new Point(190, 187);
      this.ComboApplyPlan.Name = "ComboApplyPlan";
      this.ComboApplyPlan.Size = new Size(159, 23);
      this.ComboApplyPlan.TabIndex = 20;
      this.ComboApplyPlan.TabStop = false;
      this.Label4.Dock = DockStyle.Fill;
      this.Label4.Location = new Point(4, 238);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(179, 78);
      this.Label4.TabIndex = 18;
      this.Label4.Text = "USB Selective Suspend";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboPowerPlanExit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboPowerPlanExit.BackColor = System.Drawing.Color.White;
      this.ComboPowerPlanExit.ForeColor = System.Drawing.Color.Black;
      this.ComboPowerPlanExit.DrawMode = DrawMode.Normal;
      this.ComboPowerPlanExit.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboPowerPlanExit.FlatStyle = FlatStyle.Standard;
      this.ComboPowerPlanExit.FormattingEnabled = true;
      this.ComboPowerPlanExit.Location = new Point(190, 108);
      this.ComboPowerPlanExit.Name = "ComboPowerPlanExit";
      this.ComboPowerPlanExit.Size = new Size(159, 23);
      this.ComboPowerPlanExit.TabIndex = 12;
      this.ComboPowerPlanExit.TabStop = false;
      this.Label2.Dock = DockStyle.Fill;
      this.Label2.Location = new Point(4, 1);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(179, 78);
      this.Label2.TabIndex = 6;
      this.Label2.Text = "Set Power Plan on Start";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboPowerPlanStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboPowerPlanStart.BackColor = System.Drawing.Color.White;
      this.ComboPowerPlanStart.ForeColor = System.Drawing.Color.Black;
      this.ComboPowerPlanStart.DrawMode = DrawMode.Normal;
      this.ComboPowerPlanStart.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboPowerPlanStart.FlatStyle = FlatStyle.Standard;
      this.ComboPowerPlanStart.FormattingEnabled = true;
      this.ComboPowerPlanStart.Location = new Point(190, 28);
      this.ComboPowerPlanStart.Name = "ComboPowerPlanStart";
      this.ComboPowerPlanStart.Size = new Size(159, 23);
      this.ComboPowerPlanStart.TabIndex = 6;
      this.ComboPowerPlanStart.TabStop = false;
      this.Label22.AutoSize = true;
      this.Label22.Dock = DockStyle.Fill;
      this.Label22.Location = new Point(4, 80);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(179, 78);
      this.Label22.TabIndex = 14;
      this.Label22.Text = "Set Power Plan on Exit";
      this.Label22.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.AutoSize = true;
      this.Label3.Dock = DockStyle.Fill;
      this.Label3.Location = new Point(4, 159);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(179, 78);
      this.Label3.TabIndex = 19;
      this.Label3.Text = "Apply Power Plan on";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.Label23.AutoSize = true;
      this.Label23.Dock = DockStyle.Fill;
      this.Label23.Location = new Point(4, 317);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(179, 81);
      this.Label23.TabIndex = 15;
      this.Label23.Text = "Rift Power Management";
      this.Label23.TextAlign = ContentAlignment.MiddleLeft;
      this.CheckSensorPower.Dock = DockStyle.Fill;
      this.CheckSensorPower.Location = new Point(190, 320);
      this.CheckSensorPower.Name = "CheckSensorPower";
      this.CheckSensorPower.Size = new Size(159, 75);
      this.CheckSensorPower.TabIndex = 10;
      this.CheckSensorPower.TabStop = false;
      this.CheckSensorPower.Text = "Disable on start";
      this.CheckSensorPower.UseVisualStyleBackColor = true;
      this.ComboUSBsusp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.ComboUSBsusp.BackColor = System.Drawing.Color.White;
      this.ComboUSBsusp.ForeColor = System.Drawing.Color.Black;
      this.ComboUSBsusp.DrawMode = DrawMode.Normal;
      this.ComboUSBsusp.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboUSBsusp.FlatStyle = FlatStyle.Standard;
      this.ComboUSBsusp.FormattingEnabled = true;
      this.ComboUSBsusp.Items.AddRange(new object[2]
      {
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboUSBsusp.Location = new Point(190, 266);
      this.ComboUSBsusp.Name = "ComboUSBsusp";
      this.ComboUSBsusp.Size = new Size(159, 23);
      this.ComboUSBsusp.TabIndex = 7;
      this.ComboUSBsusp.TabStop = false;
      this.TabPage4.BackColor = System.Drawing.Color.White;
      this.TabPage4.Controls.Add(this.DbLayoutPanel7);
      this.TabPage4.Location = new Point(139, 4);
      this.TabPage4.Name = "TabPage4";
      this.TabPage4.Padding = new Padding(3);
      this.TabPage4.Size = new Size(365, 425);
      this.TabPage4.TabIndex = 3;
      this.TabPage4.Text = "Service & Startup";
      this.DbLayoutPanel7.ColumnCount = 1;
      this.DbLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel7.Controls.Add(this.GroupBox6, 0, 1);
      this.DbLayoutPanel7.Controls.Add(this.GroupBox4, 0, 0);
      this.DbLayoutPanel7.Dock = DockStyle.Fill;
      this.DbLayoutPanel7.Location = new Point(3, 3);
      this.DbLayoutPanel7.Name = "DbLayoutPanel7";
      this.DbLayoutPanel7.RowCount = 2;
      this.DbLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20.97701f));
      this.DbLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 79.02299f));
      this.DbLayoutPanel7.Size = new Size(359, 419);
      this.DbLayoutPanel7.TabIndex = 25;
      this.GroupBox6.Controls.Add(this.DbLayoutPanel8);
      this.GroupBox6.Dock = DockStyle.Fill;
      this.GroupBox6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox6.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox6.Location = new Point(3, 90);
      this.GroupBox6.Name = "GroupBox6";
      this.GroupBox6.Size = new Size(353, 326);
      this.GroupBox6.TabIndex = 24;
      this.GroupBox6.TabStop = false;
      this.DbLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.DbLayoutPanel8.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel8.ColumnCount = 1;
      this.DbLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel8.Controls.Add(this.CheckStartService, 0, 0);
      this.DbLayoutPanel8.Controls.Add(this.CheckStopService, 0, 1);
      this.DbLayoutPanel8.Controls.Add(this.CheckSendHomeToTrayOnStart, 0, 9);
      this.DbLayoutPanel8.Controls.Add(this.CheckSendHomeToTray, 0, 8);
      this.DbLayoutPanel8.Controls.Add(this.CheckSpoofCPU, 0, 7);
      this.DbLayoutPanel8.Controls.Add(this.CheckCloseHome, 0, 6);
      this.DbLayoutPanel8.Controls.Add(this.CheckLaunchHomeTool, 0, 5);
      this.DbLayoutPanel8.Controls.Add(this.CheckLaunchHome, 0, 4);
      this.DbLayoutPanel8.Controls.Add(this.CheckRestartSleep, 0, 3);
      this.DbLayoutPanel8.Controls.Add(this.CheckStopServiceHome, 0, 2);
      this.DbLayoutPanel8.Location = new Point(3, 17);
      this.DbLayoutPanel8.Name = "DbLayoutPanel8";
      this.DbLayoutPanel8.RowCount = 10;
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111f));
      this.DbLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.DbLayoutPanel8.Size = new Size(330, 300);
      this.DbLayoutPanel8.TabIndex = 12;
      this.CheckStartService.Dock = DockStyle.Fill;
      this.CheckStartService.Location = new Point(4, 4);
      this.CheckStartService.Name = "CheckStartService";
      this.CheckStartService.Size = new Size(322, 23);
      this.CheckStartService.TabIndex = 17;
      this.CheckStartService.TabStop = false;
      this.CheckStartService.Text = "Start Oculus service when tool starts";
      this.CheckStartService.UseVisualStyleBackColor = true;
      this.CheckStopService.Dock = DockStyle.Fill;
      this.CheckStopService.Location = new Point(4, 34);
      this.CheckStopService.Name = "CheckStopService";
      this.CheckStopService.Size = new Size(322, 23);
      this.CheckStopService.TabIndex = 18;
      this.CheckStopService.TabStop = false;
      this.CheckStopService.Text = "Stop Oculus service when tool exits";
      this.CheckStopService.UseVisualStyleBackColor = true;
      this.CheckSendHomeToTrayOnStart.Dock = DockStyle.Fill;
      this.CheckSendHomeToTrayOnStart.Location = new Point(4, 274);
      this.CheckSendHomeToTrayOnStart.Name = "CheckSendHomeToTrayOnStart";
      this.CheckSendHomeToTrayOnStart.Size = new Size(322, 22);
      this.CheckSendHomeToTrayOnStart.TabIndex = 30;
      this.CheckSendHomeToTrayOnStart.TabStop = false;
      this.CheckSendHomeToTrayOnStart.Text = "Send Oculus Home to tray when it starts";
      this.CheckSendHomeToTrayOnStart.UseVisualStyleBackColor = true;
      this.CheckSendHomeToTray.Dock = DockStyle.Fill;
      this.CheckSendHomeToTray.Location = new Point(4, 244);
      this.CheckSendHomeToTray.Name = "CheckSendHomeToTray";
      this.CheckSendHomeToTray.Size = new Size(322, 23);
      this.CheckSendHomeToTray.TabIndex = 29;
      this.CheckSendHomeToTray.TabStop = false;
      this.CheckSendHomeToTray.Text = "Send Oculus Home to tray when it's minimized";
      this.CheckSendHomeToTray.UseVisualStyleBackColor = true;
      this.CheckCloseHome.Dock = DockStyle.Fill;
      this.CheckCloseHome.Location = new Point(4, 184);
      this.CheckCloseHome.Name = "CheckCloseHome";
      this.CheckCloseHome.Size = new Size(322, 23);
      this.CheckCloseHome.TabIndex = 21;
      this.CheckCloseHome.TabStop = false;
      this.CheckCloseHome.Text = "Close Oculus Home on tool exit";
      this.CheckCloseHome.UseVisualStyleBackColor = true;
      this.CheckLaunchHomeTool.Dock = DockStyle.Fill;
      this.CheckLaunchHomeTool.Location = new Point(4, 154);
      this.CheckLaunchHomeTool.Name = "CheckLaunchHomeTool";
      this.CheckLaunchHomeTool.Size = new Size(322, 23);
      this.CheckLaunchHomeTool.TabIndex = 20;
      this.CheckLaunchHomeTool.TabStop = false;
      this.CheckLaunchHomeTool.Text = "Launch Oculus Home on tool start";
      this.CheckLaunchHomeTool.UseVisualStyleBackColor = true;
      this.CheckLaunchHome.Dock = DockStyle.Fill;
      this.CheckLaunchHome.Location = new Point(4, 124);
      this.CheckLaunchHome.Name = "CheckLaunchHome";
      this.CheckLaunchHome.Size = new Size(322, 23);
      this.CheckLaunchHome.TabIndex = 19;
      this.CheckLaunchHome.TabStop = false;
      this.CheckLaunchHome.Text = "Launch Oculus Home on service start";
      this.CheckLaunchHome.UseVisualStyleBackColor = true;
      this.CheckRestartSleep.Dock = DockStyle.Fill;
      this.CheckRestartSleep.Location = new Point(4, 94);
      this.CheckRestartSleep.Name = "CheckRestartSleep";
      this.CheckRestartSleep.Size = new Size(322, 23);
      this.CheckRestartSleep.TabIndex = 31;
      this.CheckRestartSleep.Text = "Restart Oculus service when computer wakes up";
      this.CheckRestartSleep.UseVisualStyleBackColor = true;
      this.CheckStopServiceHome.AutoSize = true;
      this.CheckStopServiceHome.Dock = DockStyle.Fill;
      this.CheckStopServiceHome.Location = new Point(4, 64);
      this.CheckStopServiceHome.Name = "CheckStopServiceHome";
      this.CheckStopServiceHome.Size = new Size(322, 23);
      this.CheckStopServiceHome.TabIndex = 32;
      this.CheckStopServiceHome.Text = "Stop Oculus service when Oculus Home is closed";
      this.CheckStopServiceHome.UseVisualStyleBackColor = true;
      this.GroupBox4.Controls.Add(this.DbLayoutPanel6);
      this.GroupBox4.Dock = DockStyle.Fill;
      this.GroupBox4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox4.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox4.Location = new Point(3, 3);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(353, 81);
      this.GroupBox4.TabIndex = 11;
      this.GroupBox4.TabStop = false;
      this.DbLayoutPanel6.ColumnCount = 5;
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.89933f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.11409f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.10738f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.43624f));
      this.DbLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.10738f));
      this.DbLayoutPanel6.Controls.Add(this.ButtonRestartOVR, 4, 0);
      this.DbLayoutPanel6.Controls.Add(this.LabelServiceStatus, 1, 0);
      this.DbLayoutPanel6.Controls.Add(this.ButtonStartOVR, 2, 0);
      this.DbLayoutPanel6.Controls.Add(this.Label11, 0, 0);
      this.DbLayoutPanel6.Controls.Add(this.ButtonStopOVR, 3, 0);
      this.DbLayoutPanel6.Dock = DockStyle.Fill;
      this.DbLayoutPanel6.Location = new Point(3, 17);
      this.DbLayoutPanel6.Name = "DbLayoutPanel6";
      this.DbLayoutPanel6.RowCount = 1;
      this.DbLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.DbLayoutPanel6.Size = new Size(347, 61);
      this.DbLayoutPanel6.TabIndex = 31;
      this.LabelServiceStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.LabelServiceStatus.AutoSize = true;
      this.LabelServiceStatus.Location = new Point(124, 23);
      this.LabelServiceStatus.Name = "LabelServiceStatus";
      this.LabelServiceStatus.Size = new Size(53, 15);
      this.LabelServiceStatus.TabIndex = 14;
      this.LabelServiceStatus.TextAlign = ContentAlignment.MiddleLeft;
      this.Label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Label11.Location = new Point(3, 0);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(115, 61);
      this.Label11.TabIndex = 25;
      this.Label11.Text = "Oculus Service: ";
      this.Label11.TextAlign = ContentAlignment.MiddleLeft;
      this.TabPage5.BackColor = System.Drawing.Color.White;
      this.TabPage5.Controls.Add(this.GroupBox3);
      this.TabPage5.Location = new Point(139, 4);
      this.TabPage5.Name = "TabPage5";
      this.TabPage5.Padding = new Padding(3);
      this.TabPage5.Size = new Size(365, 425);
      this.TabPage5.TabIndex = 4;
      this.TabPage5.Text = "Log Window";
      this.GroupBox3.Controls.Add(this.ListBox1);
      this.GroupBox3.Dock = DockStyle.Fill;
      this.GroupBox3.Location = new Point(3, 3);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(359, 419);
      this.GroupBox3.TabIndex = 9;
      this.GroupBox3.TabStop = false;
      this.ListBox1.BorderStyle = BorderStyle.None;
      this.ListBox1.ContextMenuStrip = this.ContextMenuStrip2;
      this.ListBox1.Dock = DockStyle.Fill;
      this.ListBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListBox1.ForeColor = System.Drawing.Color.DodgerBlue;
      this.ListBox1.FormattingEnabled = true;
      this.ListBox1.HorizontalScrollbar = true;
      this.ListBox1.ItemHeight = 15;
      this.ListBox1.Location = new Point(3, 17);
      this.ListBox1.Name = "ListBox1";
      this.ListBox1.Size = new Size(353, 399);
      this.ListBox1.TabIndex = 8;
      this.TabPage7.BackColor = System.Drawing.Color.White;
      this.TabPage7.Controls.Add(this.GroupBox7);
      this.TabPage7.Location = new Point(139, 4);
      this.TabPage7.Name = "TabPage7";
      this.TabPage7.Padding = new Padding(3);
      this.TabPage7.Size = new Size(365, 425);
      this.TabPage7.TabIndex = 6;
      this.TabPage7.Text = "Advanced";
      this.GroupBox7.Controls.Add(this.DbLayoutPanel1);
      this.GroupBox7.Dock = DockStyle.Fill;
      this.GroupBox7.Location = new Point(3, 3);
      this.GroupBox7.Name = "GroupBox7";
      this.GroupBox7.Size = new Size(359, 419);
      this.GroupBox7.TabIndex = 10;
      this.GroupBox7.TabStop = false;
      this.DbLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.DbLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel1.ColumnCount = 2;
      this.DbLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.DbLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.DbLayoutPanel1.Controls.Add(this.BtnLibrary, 1, 7);
      this.DbLayoutPanel1.Controls.Add(this.Label29, 0, 7);
      this.DbLayoutPanel1.Controls.Add(this.CheckLocalDebug, 1, 0);
      this.DbLayoutPanel1.Controls.Add(this.CheckStartWatcher, 1, 1);
      this.DbLayoutPanel1.Controls.Add(this.Label13, 0, 0);
      this.DbLayoutPanel1.Controls.Add(this.Label18, 0, 1);
      this.DbLayoutPanel1.Controls.Add(this.Button4, 1, 2);
      this.DbLayoutPanel1.Controls.Add(this.BtnRemoveAllProfiles, 1, 3);
      this.DbLayoutPanel1.Controls.Add(this.Button1, 1, 4);
      this.DbLayoutPanel1.Controls.Add(this.Button5, 1, 5);
      this.DbLayoutPanel1.Controls.Add(this.BtnSteamImport, 1, 6);
      this.DbLayoutPanel1.Controls.Add(this.Label24, 0, 2);
      this.DbLayoutPanel1.Controls.Add(this.Label25, 0, 3);
      this.DbLayoutPanel1.Controls.Add(this.Label26, 0, 4);
      this.DbLayoutPanel1.Controls.Add(this.Label27, 0, 5);
      this.DbLayoutPanel1.Controls.Add(this.Label28, 0, 6);
      this.DbLayoutPanel1.Location = new Point(6, 17);
      this.DbLayoutPanel1.Name = "DbLayoutPanel1";
      this.DbLayoutPanel1.RowCount = 8;
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.27053f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.1401f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.52657f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.98067f));
      this.DbLayoutPanel1.Size = new Size(326, 396);
      this.DbLayoutPanel1.TabIndex = 0;
      this.BtnLibrary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BtnLibrary.FlatStyle = FlatStyle.Flat;
      this.BtnLibrary.Location = new Point(166, 348);
      this.BtnLibrary.Name = "BtnLibrary";
      this.BtnLibrary.Size = new Size(156, 44);
      this.BtnLibrary.TabIndex = 29;
      this.BtnLibrary.TabStop = false;
      this.BtnLibrary.Text = "View && Edit";
      this.BtnLibrary.UseVisualStyleBackColor = true;
      this.BtnSteamImport.Dock = DockStyle.Fill;
      this.BtnSteamImport.FlatStyle = FlatStyle.Flat;
      this.BtnSteamImport.Location = new Point(166, 295);
      this.BtnSteamImport.Name = "BtnSteamImport";
      this.BtnSteamImport.Size = new Size(156, 46);
      this.BtnSteamImport.TabIndex = 30;
      this.BtnSteamImport.TabStop = false;
      this.BtnSteamImport.Text = "View && Import";
      this.BtnSteamImport.UseVisualStyleBackColor = true;
      this.Label24.AutoSize = true;
      this.Label24.Dock = DockStyle.Fill;
      this.Label24.Location = new Point(4, 97);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(155, 47);
      this.Label24.TabIndex = 33;
      this.Label24.Text = "Settings";
      this.Label24.TextAlign = ContentAlignment.MiddleLeft;
      this.Label25.AutoSize = true;
      this.Label25.Dock = DockStyle.Fill;
      this.Label25.Location = new Point(4, 145);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(155, 47);
      this.Label25.TabIndex = 34;
      this.Label25.Text = "Profiles";
      this.Label25.TextAlign = ContentAlignment.MiddleLeft;
      this.Label26.AutoSize = true;
      this.Label26.Dock = DockStyle.Fill;
      this.Label26.Location = new Point(4, 193);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(155, 47);
      this.Label26.TabIndex = 35;
      this.Label26.Text = "Updates";
      this.Label26.TextAlign = ContentAlignment.MiddleLeft;
      this.Label27.AutoSize = true;
      this.Label27.Dock = DockStyle.Fill;
      this.Label27.Location = new Point(4, 241);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(155, 50);
      this.Label27.TabIndex = 36;
      this.Label27.Text = "Debug";
      this.Label27.TextAlign = ContentAlignment.MiddleLeft;
      this.Label28.AutoSize = true;
      this.Label28.Dock = DockStyle.Fill;
      this.Label28.Location = new Point(4, 292);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(155, 52);
      this.Label28.TabIndex = 37;
      this.Label28.Text = "Steam Library";
      this.Label28.TextAlign = ContentAlignment.MiddleLeft;
      this.TabPage8.BackColor = System.Drawing.Color.White;
      this.TabPage8.Controls.Add(this.GroupBox5);
      this.TabPage8.Location = new Point(139, 4);
      this.TabPage8.Name = "TabPage8";
      this.TabPage8.Size = new Size(365, 425);
      this.TabPage8.TabIndex = 7;
      this.TabPage8.Text = "Quest Link";
      this.GroupBox5.Controls.Add(this.PictureBox7);
      this.GroupBox5.Controls.Add(this.PictureBox6);
      this.GroupBox5.Controls.Add(this.PictureBox5);
      this.GroupBox5.Controls.Add(this.PictureBox4);
      this.GroupBox5.Controls.Add(this.PictureBox3);
      this.GroupBox5.Controls.Add(this.Button3);
      this.GroupBox5.Controls.Add(this.Button12);
      this.GroupBox5.Controls.Add(this.DbLayoutPanel3);
      this.GroupBox5.Controls.Add(this.Button11);
      this.GroupBox5.Controls.Add(this.Button10);
      this.GroupBox5.Controls.Add(this.Label10);
      this.GroupBox5.Location = new Point(3, 3);
      this.GroupBox5.Name = "GroupBox5";
      this.GroupBox5.Size = new Size(342, 414);
      this.GroupBox5.TabIndex = 10;
      this.GroupBox5.TabStop = false;
      this.Button3.Enabled = false;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.Location = new Point(9, 383);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(56, 25);
      this.Button3.TabIndex = 14;
      this.Button3.Text = "Delete";
      this.Button3.UseVisualStyleBackColor = true;
      this.Button12.FlatStyle = FlatStyle.Flat;
      this.Button12.Location = new Point(280, 383);
      this.Button12.Name = "Button12";
      this.Button12.Size = new Size(56, 25);
      this.Button12.TabIndex = 13;
      this.Button12.Text = "Save";
      this.Button12.UseVisualStyleBackColor = true;
      this.DbLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel3.ColumnCount = 2;
      this.DbLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.33333f));
      this.DbLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.66667f));
      this.DbLayoutPanel3.Controls.Add(this.ComboBox11, 1, 5);
      this.DbLayoutPanel3.Controls.Add(this.ComboBox6, 1, 3);
      this.DbLayoutPanel3.Controls.Add(this.Label32, 0, 0);
      this.DbLayoutPanel3.Controls.Add(this.Label30, 0, 1);
      this.DbLayoutPanel3.Controls.Add(this.Label31, 0, 2);
      this.DbLayoutPanel3.Controls.Add(this.ComboBox4, 1, 0);
      this.DbLayoutPanel3.Controls.Add(this.ComboBox3, 1, 2);
      this.DbLayoutPanel3.Controls.Add(this.ComboBox2, 1, 1);
      this.DbLayoutPanel3.Controls.Add(this.Label36, 0, 3);
      this.DbLayoutPanel3.Controls.Add(this.Label38, 0, 4);
      this.DbLayoutPanel3.Controls.Add(this.ComboBox10, 1, 4);
      this.DbLayoutPanel3.Controls.Add(this.Label21, 0, 7);
      this.DbLayoutPanel3.Controls.Add(this.Button6, 1, 7);
      this.DbLayoutPanel3.Controls.Add(this.Label20, 0, 6);
      this.DbLayoutPanel3.Controls.Add(this.ComboBox7, 1, 6);
      this.DbLayoutPanel3.Controls.Add(this.Label39, 0, 5);
      this.DbLayoutPanel3.Location = new Point(12, 92);
      this.DbLayoutPanel3.Name = "DbLayoutPanel3";
      this.DbLayoutPanel3.RowCount = 8;
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
      this.DbLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.DbLayoutPanel3.Size = new Size(296, 268);
      this.DbLayoutPanel3.TabIndex = 12;
      this.ComboBox11.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox11.Dock = DockStyle.Fill;
      this.ComboBox11.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox11.FlatStyle = FlatStyle.Popup;
      this.ComboBox11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox11.FormattingEnabled = true;
      this.ComboBox11.Items.AddRange(new object[18]
      {
        (object) "0",
        (object) "150",
        (object) "200",
        (object) "250",
        (object) "300",
        (object) "350",
        (object) "400",
        (object) "450",
        (object) "500",
        (object) "550",
        (object) "600",
        (object) "650",
        (object) "700",
        (object) "750",
        (object) "800",
        (object) "850",
        (object) "900",
        (object) "960"
      });
      this.ComboBox11.Location = new Point(175, 169);
      this.ComboBox11.MaxLength = 4;
      this.ComboBox11.Name = "ComboBox11";
      this.ComboBox11.Size = new Size(117, 24);
      this.ComboBox11.TabIndex = 18;
      this.ComboBox6.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox6.Dock = DockStyle.Fill;
      this.ComboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox6.FlatStyle = FlatStyle.Popup;
      this.ComboBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox6.FormattingEnabled = true;
      this.ComboBox6.Items.AddRange(new object[18]
      {
        (object) "0",
        (object) "150",
        (object) "200",
        (object) "250",
        (object) "300",
        (object) "350",
        (object) "400",
        (object) "450",
        (object) "500",
        (object) "550",
        (object) "600",
        (object) "650",
        (object) "700",
        (object) "750",
        (object) "800",
        (object) "850",
        (object) "900",
        (object) "960"
      });
      this.ComboBox6.Location = new Point(175, 103);
      this.ComboBox6.MaxLength = 4;
      this.ComboBox6.Name = "ComboBox6";
      this.ComboBox6.Size = new Size(117, 24);
      this.ComboBox6.TabIndex = 10;
      this.Label32.AutoSize = true;
      this.Label32.Dock = DockStyle.Fill;
      this.Label32.Location = new Point(4, 1);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(164, 32);
      this.Label32.TabIndex = 5;
      this.Label32.Text = "Presets";
      this.Label32.TextAlign = ContentAlignment.MiddleLeft;
      this.Label30.AutoSize = true;
      this.Label30.Dock = DockStyle.Fill;
      this.Label30.Location = new Point(4, 34);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(164, 32);
      this.Label30.TabIndex = 1;
      this.Label30.Text = "Distortion Curvature:";
      this.Label30.TextAlign = ContentAlignment.MiddleLeft;
      this.Label31.AutoSize = true;
      this.Label31.Dock = DockStyle.Fill;
      this.Label31.Location = new Point(4, 67);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(164, 32);
      this.Label31.TabIndex = 2;
      this.Label31.Text = "Encode Resolution";
      this.Label31.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox4.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox4.Dock = DockStyle.Fill;
      this.ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox4.Enabled = false;
      this.ComboBox4.FlatStyle = FlatStyle.Popup;
      this.ComboBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox4.FormattingEnabled = true;
      this.ComboBox4.Items.AddRange(new object[1]
      {
        (object) "Disabled"
      });
      this.ComboBox4.Location = new Point(175, 4);
      this.ComboBox4.Name = "ComboBox4";
      this.ComboBox4.Size = new Size(117, 24);
      this.ComboBox4.TabIndex = 6;
      this.ComboBox3.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox3.Dock = DockStyle.Fill;
      this.ComboBox3.FlatStyle = FlatStyle.Popup;
      this.ComboBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox3.FormattingEnabled = true;
      this.ComboBox3.Items.AddRange(new object[6]
      {
        (object) "2016",
        (object) "2352",
        (object) "2912",
        (object) "3648",
        (object) "3960",
        (object) "4040"
      });
      this.ComboBox3.Location = new Point(175, 70);
      this.ComboBox3.MaxLength = 4;
      this.ComboBox3.Name = "ComboBox3";
      this.ComboBox3.Size = new Size(117, 24);
      this.ComboBox3.TabIndex = 4;
      this.ComboBox2.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox2.Dock = DockStyle.Fill;
      this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox2.FlatStyle = FlatStyle.Popup;
      this.ComboBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox2.FormattingEnabled = true;
      this.ComboBox2.Items.AddRange(new object[3]
      {
        (object) "Default",
        (object) "High",
        (object) "Low"
      });
      this.ComboBox2.Location = new Point(175, 37);
      this.ComboBox2.Name = "ComboBox2";
      this.ComboBox2.Size = new Size(117, 24);
      this.ComboBox2.TabIndex = 3;
      this.Label36.AutoSize = true;
      this.Label36.Dock = DockStyle.Fill;
      this.Label36.Location = new Point(4, 100);
      this.Label36.Name = "Label36";
      this.Label36.Size = new Size(164, 32);
      this.Label36.TabIndex = 9;
      this.Label36.Text = "Encode Bitrate";
      this.Label36.TextAlign = ContentAlignment.MiddleLeft;
      this.Label38.AutoSize = true;
      this.Label38.Dock = DockStyle.Fill;
      this.Label38.Location = new Point(4, 133);
      this.Label38.Name = "Label38";
      this.Label38.Size = new Size(164, 32);
      this.Label38.TabIndex = 15;
      this.Label38.Text = "Encode Dynamic Bitrate";
      this.Label38.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox10.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox10.Dock = DockStyle.Fill;
      this.ComboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox10.FlatStyle = FlatStyle.Popup;
      this.ComboBox10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox10.FormattingEnabled = true;
      this.ComboBox10.Items.AddRange(new object[3]
      {
        (object) "Default",
        (object) "Enabled",
        (object) "Disabled"
      });
      this.ComboBox10.Location = new Point(175, 136);
      this.ComboBox10.Name = "ComboBox10";
      this.ComboBox10.Size = new Size(117, 24);
      this.ComboBox10.TabIndex = 16;
      this.Label21.AutoSize = true;
      this.Label21.Dock = DockStyle.Fill;
      this.Label21.Location = new Point(4, 232);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(164, 35);
      this.Label21.TabIndex = 13;
      this.Label21.Text = "Permanent AirLink";
      this.Label21.TextAlign = ContentAlignment.MiddleLeft;
      this.Button6.Dock = DockStyle.Fill;
      this.Button6.FlatStyle = FlatStyle.Flat;
      this.Button6.Location = new Point(175, 235);
      this.Button6.Name = "Button6";
      this.Button6.Size = new Size(117, 29);
      this.Button6.TabIndex = 14;
      this.Button6.Text = "Enable";
      this.Button6.UseVisualStyleBackColor = true;
      this.Label20.AutoSize = true;
      this.Label20.Dock = DockStyle.Fill;
      this.Label20.Location = new Point(4, 199);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(164, 32);
      this.Label20.TabIndex = 11;
      this.Label20.Text = "Sharpening";
      this.Label20.TextAlign = ContentAlignment.MiddleLeft;
      this.ComboBox7.BackColor = System.Drawing.Color.AliceBlue;
      this.ComboBox7.Dock = DockStyle.Fill;
      this.ComboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboBox7.FlatStyle = FlatStyle.Popup;
      this.ComboBox7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ComboBox7.FormattingEnabled = true;
      this.ComboBox7.Items.AddRange(new object[3]
      {
        (object) "Auto",
        (object) "Disabled",
        (object) "Enabled"
      });
      this.ComboBox7.Location = new Point(175, 202);
      this.ComboBox7.Name = "ComboBox7";
      this.ComboBox7.Size = new Size(117, 24);
      this.ComboBox7.TabIndex = 12;
      this.Label39.AutoSize = true;
      this.Label39.Dock = DockStyle.Fill;
      this.Label39.Location = new Point(4, 166);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(164, 32);
      this.Label39.TabIndex = 17;
      this.Label39.Text = "Dynamic Bitrate Max";
      this.Label39.TextAlign = ContentAlignment.MiddleLeft;
      this.Button10.FlatStyle = FlatStyle.Flat;
      this.Button10.Location = new Point(123, 383);
      this.Button10.Name = "Button10";
      this.Button10.Size = new Size(146, 25);
      this.Button10.TabIndex = 10;
      this.Button10.Text = "Save && Restart Service";
      this.Button10.UseVisualStyleBackColor = true;
      this.Label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label10.Location = new Point(9, 17);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(324, 72);
      this.Label10.TabIndex = 0;
      this.Label10.Text = "These settings are for the Oculus Quest/Quest 2 when using Link. You can change the Preset values to experiment. Higher settings require more GPU power and may cause a significant performance drop.";
      this.TabPage6.BackColor = System.Drawing.Color.White;
      this.TabPage6.Controls.Add(this.GroupBox9);
      this.TabPage6.Location = new Point(139, 4);
      this.TabPage6.Name = "TabPage6";
      this.TabPage6.Padding = new Padding(3);
      this.TabPage6.Size = new Size(365, 425);
      this.TabPage6.TabIndex = 5;
      this.TabPage6.Text = "Update Found!";
      this.GroupBox9.Controls.Add(this.LabelDownloadStatus);
      this.GroupBox9.Controls.Add(this.LabelVer);
      this.GroupBox9.Controls.Add(this.Label12);
      this.GroupBox9.Controls.Add(this.Button9);
      this.GroupBox9.Controls.Add(this.Button8);
      this.GroupBox9.Dock = DockStyle.Fill;
      this.GroupBox9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox9.ForeColor = System.Drawing.Color.DodgerBlue;
      this.GroupBox9.Location = new Point(3, 3);
      this.GroupBox9.Name = "GroupBox9";
      this.GroupBox9.Size = new Size(359, 419);
      this.GroupBox9.TabIndex = 7;
      this.GroupBox9.TabStop = false;
      this.LabelDownloadStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.LabelDownloadStatus.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LabelDownloadStatus.Location = new Point(6, 244);
      this.LabelDownloadStatus.Name = "LabelDownloadStatus";
      this.LabelDownloadStatus.Size = new Size(347, 16);
      this.LabelDownloadStatus.TabIndex = 5;
      this.LabelDownloadStatus.TextAlign = ContentAlignment.MiddleCenter;
      this.LabelVer.Anchor = AnchorStyles.Left;
      this.LabelVer.Location = new Point(6, 140);
      this.LabelVer.Name = "LabelVer";
      this.LabelVer.Size = new Size(321, 19);
      this.LabelVer.TabIndex = 4;
      this.LabelVer.TextAlign = ContentAlignment.MiddleCenter;
      this.Label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.Label12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label12.Location = new Point(6, 110);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(347, 16);
      this.Label12.TabIndex = 3;
      this.Label12.Text = "Looks like we have an update for you!";
      this.Label12.TextAlign = ContentAlignment.MiddleCenter;
      this.Button9.FlatStyle = FlatStyle.Flat;
      this.Button9.Location = new Point(177, 152);
      this.Button9.Name = "Button9";
      this.Button9.Size = new Size(146, 31);
      this.Button9.TabIndex = 1;
      this.Button9.Text = "Download Only";
      this.Button9.UseVisualStyleBackColor = true;
      this.Button8.FlatStyle = FlatStyle.Flat;
      this.Button8.Location = new Point(15, 152);
      this.Button8.Name = "Button8";
      this.Button8.Size = new Size(146, 31);
      this.Button8.TabIndex = 0;
      this.Button8.Text = "Download and Install";
      this.Button8.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new Size(508, 433);
      this.Controls.Add(this.PictureBox2);
      this.Controls.Add(this.PictureBox1);
      this.Controls.Add(this.Label8);
      this.Controls.Add(this.DotNetBarTabcontrol1);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.Color.DodgerBlue;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimumSize = new Size(524, 472);
      this.Name = "FrmMain";
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Oculus Tray Tool";
      this.ContextMenuStrip1.ResumeLayout(false);
      this.ContextMenuStrip2.ResumeLayout(false);
      ((ISupportInitialize) this.PictureBox1).EndInit();
      ((ISupportInitialize) this.PictureBox2).EndInit();
      ((ISupportInitialize) this.PictureBox8).EndInit();
      ((ISupportInitialize) this.PictureBox7).EndInit();
      ((ISupportInitialize) this.PictureBox6).EndInit();
      ((ISupportInitialize) this.PictureBox5).EndInit();
      ((ISupportInitialize) this.PictureBox4).EndInit();
      ((ISupportInitialize) this.PictureBox3).EndInit();
      this.DotNetBarTabcontrol1.ResumeLayout(false);
      this.TabPage1.ResumeLayout(false);
      this.GroupBox14.ResumeLayout(false);
      this.DbLayoutPanel2.ResumeLayout(false);
      this.DbLayoutPanel2.PerformLayout();
      this.SplitContainer1.Panel1.ResumeLayout(false);
      this.SplitContainer1.Panel2.ResumeLayout(false);
      this.SplitContainer1.EndInit();
      this.SplitContainer1.ResumeLayout(false);
      this.NumericFOVh.EndInit();
      this.NumericFOVv.EndInit();
      this.TabPage2.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.DbLayoutPanel4.ResumeLayout(false);
      this.DbLayoutPanel4.PerformLayout();
      this.TrackBar1.EndInit();
      this.TabPage3.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.DbLayoutPanel5.ResumeLayout(false);
      this.DbLayoutPanel5.PerformLayout();
      this.TabPage4.ResumeLayout(false);
      this.DbLayoutPanel7.ResumeLayout(false);
      this.GroupBox6.ResumeLayout(false);
      this.DbLayoutPanel8.ResumeLayout(false);
      this.DbLayoutPanel8.PerformLayout();
      this.GroupBox4.ResumeLayout(false);
      this.DbLayoutPanel6.ResumeLayout(false);
      this.DbLayoutPanel6.PerformLayout();
      this.TabPage5.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.TabPage7.ResumeLayout(false);
      this.GroupBox7.ResumeLayout(false);
      this.DbLayoutPanel1.ResumeLayout(false);
      this.DbLayoutPanel1.PerformLayout();
      this.TabPage8.ResumeLayout(false);
      this.GroupBox5.ResumeLayout(false);
      this.DbLayoutPanel3.ResumeLayout(false);
      this.DbLayoutPanel3.PerformLayout();
      this.TabPage6.ResumeLayout(false);
      this.GroupBox9.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    
      this.NotificationTimer.Tick += new EventHandler(this.NotificationTimer_Tick);
    

      this.MinimizeHomeWatcher.EventArrived += new EventArrivedEventHandler(this.MinimizeHomeWatcher_EventArrived);
      this.CheckStartMin.CheckedChanged += new EventHandler(this.CheckStartMin_CheckedChanged);
      this.NotifyIcon1.DoubleClick += new EventHandler(this.NotifyIcon1_DoubleClick);
      this.ButtonStartOVR.Click += new EventHandler(this.ButtonStartOVR_Click);
      this.ToolStripMenuItem1.Click += new EventHandler(this.ToolStripMenuItem1_Click);
      this.ToolStripMenuItem2.Click += new EventHandler(this.ToolStripMenuItem2_Click);
      this.ButtonStopOVR.Click += new EventHandler(this.ButtonStopOVR_Click);
      this.CheckStartService.CheckedChanged += new EventHandler(this.CheckStartService_CheckedChanged);
      this.CheckLaunchHome.CheckedChanged += new EventHandler(this.CheckLaunchHome_CheckedChanged);
      this.CheckStopService.CheckedChanged += new EventHandler(this.CheckStopService_CheckedChanged);
      this.ButtonRestartOVR.Click += new EventHandler(this.ButtonRestartOVR_Click);
      this.CheckLaunchHomeTool.CheckedChanged += new EventHandler(this.CheckLaunchHomeTool_CheckedChanged);
      this.CheckCloseHome.CheckedChanged += new EventHandler(this.CheckCloseHome_CheckedChanged);
      this.CheckBoxAltTab.CheckedChanged += new EventHandler(this.CheckBoxAltTab_CheckedChanged);
      this.CheckRiftAudio.CheckedChanged += new EventHandler(this.CheckRiftAudio_CheckedChanged);
      this.OculusHomeWatcher.Tick += new EventHandler(this.OculusHomeWatcher_Tick);
      this.ToolStripMenuItem3.Click += new EventHandler(this.ToolStripMenuItem3_Click);
      this.CheckSpoofCPU.CheckedChanged += new EventHandler(this.CheckSpoofCPU_CheckedChanged);
      this.ToolStripStartOVR.Click += new EventHandler(this.ToolStripStartOVR_Click);
      this.ToolStripStopOVR.Click += new EventHandler(this.ToolStripMenuItem5_Click);
      this.ToolStripRestartOVR.Click += new EventHandler(this.ToolStripMenuItem6_Click);
      this.ToolStripMenuItem4.Click += new EventHandler(this.ToolStripMenuItem4_Click);
      this.BtnVoice.Click += new EventHandler(this.BtnVoice_Click);
      this.ComboSSstart.SelectedIndexChanged += new EventHandler(this.ComboSSstart_SelectedIndexChanged);
      this.BtnProfiles.Click += new EventHandler(this.BtnProfiles_Click);
      this.ComboVoice.SelectedIndexChanged += new EventHandler(this.ComboVoice_SelectedIndexChanged);
      this.HotKeysCheckBox.CheckedChanged += new EventHandler(this.HotKeysCheckBox_CheckedChanged);
      this.ComboUSBsusp.SelectedIndexChanged += new EventHandler(this.ComboUSBsusp_SelectedIndexChanged);
      this.ComboPowerPlanStart.SelectedIndexChanged += new EventHandler(this.ComboPowerPlan_SelectedIndexChanged);
      this.CheckMinimizeOnX.CheckedChanged += new EventHandler(this.CheckMinimizeOnX_CheckedChanged);
      this.PictureBox1.Click += new EventHandler(this.PictureBox1_Click);
      this.TrackBar1.Scroll += new EventHandler(this.TrackBar1_Scroll);
      this.HometoTrayTimer.Tick += new EventHandler(this.HometoTrayTimer_Tick);
      this.CheckSendHomeToTray.CheckedChanged += new EventHandler(this.CheckSendHomeToTray_CheckedChanged);
      this.CheckSendHomeToTrayOnStart.CheckedChanged += new EventHandler(this.CheckSendHomeToTrayOnStart_CheckedChanged);
      this.Button4.Click += new EventHandler(this.Button4_Click);
      this.CheckLocalDebug.CheckedChanged += new EventHandler(this.CheckLocalDebug_CheckedChanged);
      this.CheckStartWatcher.CheckedChanged += new EventHandler(this.CheckStartWatcher_CheckedChanged);
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Button5.Click += new EventHandler(this.Button5_Click);
      this.CheckSensorPower.CheckedChanged += new EventHandler(this.CheckSensorPower_CheckedChanged);
      this.ComboPowerPlanExit.SelectedIndexChanged += new EventHandler(this.ComboPowerPlanExit_SelectedIndexChanged);
      this.BtnConfigureAudio.Click += new EventHandler(this.BtnConfigureAudio_Click);
      this.ComboApplyPlan.SelectedIndexChanged += new EventHandler(this.ComboApplyPlan_SelectedIndexChanged);
      this.Button9.Click += new EventHandler(this.Button9_Click);
      this.Button8.Click += new EventHandler(this.Button8_Click);
      this.PictureBox2.Click += new EventHandler(this.PictureBox2_Click);
      this.CheckBoxCheckForUpdates.CheckedChanged += new EventHandler(this.CheckBoxCheckForUpdates_CheckedChanged);
      this.Button2.Click += new EventHandler(this.Button2_Click);
      this.ComboHomless.SelectedIndexChanged += new EventHandler(this.ComboHomless_SelectedIndexChanged);
      this.BtnHomless.Click += new EventHandler(this.BtnHomless_Click);
      this.UpdateTimer.Tick += new EventHandler(this.UpdateTimer_Tick);
      this.ToolStripMenuShowHome.Click += new EventHandler(this.ToolStripMenuShowHome_Click);
      this.ComboVisualHUD.SelectedIndexChanged += new EventHandler(this.ComboVisualHUD_SelectedIndexChanged);
      this.ComboMirrorHome.SelectedIndexChanged += new EventHandler(this.ComboMirrorHome_SelectedIndexChanged);
      this.CheckRestartSleep.CheckedChanged += new EventHandler(this.CheckRestartSleep_CheckedChanged);
      this.BtnSteamImport.Click += new EventHandler(this.BtnSteamImport_Click);
      this.NotifyIcon3.MouseDown += new MouseEventHandler(this.NotifyIcon3_MouseDown);
      this.BtnConfigureHotKeys.Click += new EventHandler(this.BtnConfigureHotKeys_Click);

      this.ClearLogToolStripMenuItem.Click += new EventHandler(this.ClearLogToolStripMenuItem_Click);
      this.OpenLogToolStripMenuItem.Click += new EventHandler(this.OpenLogToolStripMenuItem_Click);
      this.BtnLibrary.Click += new EventHandler(this.BtnLibrary_Click);
      this.PowerPlanTimer.Tick += new EventHandler(this.PowerPlanTimer_Tick);
      this.ComboBox3.KeyPress += new KeyPressEventHandler(this.ComboBox3_KeyPress);
      this.ComboBox4.SelectedIndexChanged += new EventHandler(this.ComboBox4_SelectedIndexChanged);
      this.Button10.Click += new EventHandler(this.Button10_Click);
      this.Button11.Click += new EventHandler(this.Button11_Click);
      this.Button12.Click += new EventHandler(this.Button12_Click);
      this.BtnRemoveAllProfiles.Click += new EventHandler(this.BtnRemoveAllProfiles_Click);
      this.ComboBox1.SelectedIndexChanged += new EventHandler(this.ComboBox1_SelectedIndexChanged);
      this.ComboBox5.SelectedIndexChanged += new EventHandler(this.ComboBox5_SelectedIndexChanged);
      this.ComboOVRPrio.SelectedIndexChanged += new EventHandler(this.ComboOVRPrio_SelectedIndexChanged);
      this.Button3.Click += new EventHandler(this.Button3_Click);
      this.Button6.Click += new EventHandler(this.Button6_Click);
      this.ComboBox8.SelectedIndexChanged += new EventHandler(this.ComboBox8_SelectedIndexChanged);
      this.ComboBox9.SelectedIndexChanged += new EventHandler(this.ComboBox9_SelectedIndexChanged);
      this.CheckStopServiceHome.CheckedChanged += new EventHandler(this.CheckStopServiceHome_CheckedChanged);
      this.CheckStartWithWindows.CheckedChanged += new System.EventHandler(this.CheckStartWindows_CheckedChanged);
      this.DotNetBarTabcontrol1.SelectedIndexChanged += new EventHandler(this.DotNetBarTabcontrol1_SelectedIndexChanged);
}

        #endregion

    internal CheckBox CheckStartWithWindows;
    internal System.Windows.Forms.Timer NotificationTimer;
    public System.Management.ManagementEventWatcher MinimizeHomeWatcher;
    public NotifyIcon NotifyIcon1;
    public ContextMenuStrip ContextMenuStrip1;
    public ToolStripMenuItem ToolStripStartOVR;
    public ToolStripMenuItem ToolStripStopOVR;
    public ToolStripMenuItem ToolStripRestartOVR;
    public ToolStripSeparator ToolStripSeparator2;
    public ToolStripMenuItem ToolStripMenuItem3;
    public ToolStripSeparator ToolStripSeparator1;
    public ToolStripMenuItem ToolStripMenuItem2;
    public ToolStripMenuItem ToolStripMenuShowHome;
    public ToolStripMenuItem ToolStripMenuItem1;
    public ContextMenuStrip ContextMenuStrip2;
    public ToolStripMenuItem ToolStripMenuItem4;
    public ToolStripMenuItem ClearLogToolStripMenuItem;
    public ToolStripMenuItem OpenLogToolStripMenuItem;
    public ToolTip ToolTip;
    public PictureBox PictureBox1;
    public PictureBox PictureBox2;
    public ComboBox ComboSSstart;
    public ComboBox ComboBox1;
    public Label Label1;
    public Label Label6;
    public ComboBox ComboHomless;
    public Label Label5;
    public ComboBox ComboVoice;
    public Button BtnVoice;
    public Button Button2;
    public PictureBox PictureBox8;
    public CheckBox CheckRiftAudio;
    public CheckBox CheckSpoofCPU;
    public Button ButtonRestartOVR;
    public Button ButtonStartOVR;
    public Button ButtonStopOVR;
    public Label Label29;
    public CheckBox CheckLocalDebug;
    public CheckBox CheckStartWatcher;
    public Label Label13;
    public Label Label18;
    public Button Button4;
    public Button BtnRemoveAllProfiles;
    public Button Button1;
    public Button Button5;
    public PictureBox PictureBox7;
    public PictureBox PictureBox6;
    public PictureBox PictureBox5;
    public PictureBox PictureBox4;
    public PictureBox PictureBox3;
    public Button Button11;
    public System.Windows.Forms.Timer OculusHomeWatcher;
    public Label Label8;
    public ImageList ImageList1;
    public System.Windows.Forms.Timer HometoTrayTimer;
    public System.Windows.Forms.Timer UpdateTimer;
    public NotifyIcon NotifyIcon3;
    public System.Windows.Forms.Timer PowerPlanTimer;
    public DotNetBarTabcontrol DotNetBarTabcontrol1;
    public TabPage TabPage1;
    public GroupBox GroupBox14;
    public DBLayoutPanel DbLayoutPanel2;
    public Label Label19;
    public Label Label7;
    public Button BtnProfiles;
    public Label Label9;
    public Label Label17;
    public ComboBox ComboMirrorHome;
    public Label Label16;
    public Button BtnHomless;
    public Label Label15;
    public Label Label35;
    public ComboBox ComboVisualHUD;
    public ComboBox ComboBox5;
    public SplitContainer SplitContainer1;
    public NumericUpDown NumericFOVh;
    public NumericUpDown NumericFOVv;
    public ComboBox ComboOVRPrio;
    public Label Label33;
    public ComboBox ComboBox8;
    public ComboBox ComboBox9;
    public Label Label37;
    public TabPage TabPage2;
    public GroupBox GroupBox1;
    public DBLayoutPanel DbLayoutPanel4;
    public CheckBox CheckStartWindows;
    public CheckBox CheckStartMin;
    public CheckBox CheckMinimizeOnX;
    public CheckBox CheckBoxAltTab;
    public CheckBox HotKeysCheckBox;
    public Button BtnConfigureAudio;
    public Label Label14;
    public CheckBox CheckBoxCheckForUpdates;
    public Button BtnConfigureHotKeys;
    public TrackBar TrackBar1;
    public TabPage TabPage3;
    public GroupBox GroupBox2;
    public DBLayoutPanel DbLayoutPanel5;
    public ComboBox ComboApplyPlan;
    public Label Label4;
    public ComboBox ComboPowerPlanExit;
    public Label Label2;
    public ComboBox ComboPowerPlanStart;
    public Label Label22;
    public Label Label3;
    public Label Label23;
    public CheckBox CheckSensorPower;
    public ComboBox ComboUSBsusp;
    public TabPage TabPage4;
    public DBLayoutPanel DbLayoutPanel7;
    public GroupBox GroupBox6;
    public DBLayoutPanel DbLayoutPanel8;
    public CheckBox CheckStartService;
    public CheckBox CheckStopService;
    public CheckBox CheckSendHomeToTrayOnStart;
    public CheckBox CheckSendHomeToTray;
    public CheckBox CheckCloseHome;
    public CheckBox CheckLaunchHomeTool;
    public CheckBox CheckLaunchHome;
    public CheckBox CheckRestartSleep;
    public CheckBox CheckStopServiceHome;
    public GroupBox GroupBox4;
    public DBLayoutPanel DbLayoutPanel6;
    public Label LabelServiceStatus;
    public Label Label11;
    public TabPage TabPage5;
    public GroupBox GroupBox3;
    public ListBox ListBox1;
    public TabPage TabPage7;
    public GroupBox GroupBox7;
    public DBLayoutPanel DbLayoutPanel1;
    public Button BtnLibrary;
    public Button BtnSteamImport;
    public Label Label24;
    public Label Label25;
    public Label Label26;
    public Label Label27;
    public Label Label28;
    public TabPage TabPage8;
    public GroupBox GroupBox5;
    public Button Button3;
    public Button Button12;
    public DBLayoutPanel DbLayoutPanel3;
    public ComboBox ComboBox11;
    public ComboBox ComboBox6;
    public Label Label32;
    public Label Label30;
    public Label Label31;
    public ComboBox ComboBox4;
    public ComboBox ComboBox3;
    public ComboBox ComboBox2;
    public Label Label36;
    public Label Label38;
    public ComboBox ComboBox10;
    public Label Label21;
    public Button Button6;
    public Label Label20;
    public ComboBox ComboBox7;
    public Label Label39;
    public Button Button10;
    public Label Label10;
    public TabPage TabPage6;
    public GroupBox GroupBox9;
    public Label LabelDownloadStatus;
    public Label LabelVer;
    public Label Label12;
    public Button Button9;
    public Button Button8;
    }
}