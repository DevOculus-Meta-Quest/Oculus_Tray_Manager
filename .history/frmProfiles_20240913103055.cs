// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmProfiles
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using OculusTrayTool.MyNameSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmProfiles : Form
  {
    private IContainer components;
    private Resizer rs;
    private int sortColumn;
    private string ProfileToFind;
    public int selectedItem;
    public Dictionary<string, string> GameList;
    private CheckBox cck;

    public frmProfiles()
    {
      this.FormClosing += new FormClosingEventHandler(this.scan_FormClosing);
      this.Load += new EventHandler(this.scan_Load);
      this.rs = new Resizer();
      this.sortColumn = -1;
      this.GameList = new Dictionary<string, string>();
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmProfiles));
      this.ListView1 = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem1 = new ToolStripMenuItem();
      this.ToolStripMenuItem2 = new ToolStripMenuItem();
      this.ToolStripSeparator1 = new ToolStripSeparator();
      this.LaunchAppToolStripMenuItem = new ToolStripMenuItem();
      this.LaunchAppWithOptionsToolStripMenuItem = new ToolStripMenuItem();
      this.ToolStripSeparator2 = new ToolStripSeparator();
      this.ToolStripMenuItem3 = new ToolStripMenuItem();
      this.ToolStripMenuItem4 = new ToolStripMenuItem();
      this.ToolStripMenuItem6 = new ToolStripMenuItem();
      this.ToolStripSeparator3 = new ToolStripSeparator();
      this.ToolStripMenuItem5 = new ToolStripMenuItem();
      this.RemoveAllSelectedProfilesToolStripMenuItem = new ToolStripMenuItem();
      this.Button2 = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.GroupBox2 = new GroupBox();
      this.Label2 = new Label();
      this.CheckVoiceConfirm = new CheckBox();
      this.Button1 = new Button();
      this.Label1 = new Label();
      this.ComboResolution = new ComboBox();
      this.Button3 = new Button();
      this.DbLayoutPanel1 = new DBLayoutPanel(this.components);
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.Label5 = new Label();
      this.Label16 = new Label();
      this.Label17 = new Label();
      this.Label18 = new Label();
      this.Label19 = new Label();
      this.Label20 = new Label();
      this.Label22 = new Label();
      this.Label23 = new Label();
      this.Label24 = new Label();
      this.Label25 = new Label();
      this.Label26 = new Label();
      this.Label27 = new Label();
      this.Label28 = new Label();
      this.Label30 = new Label();
      this.Label29 = new Label();
      this.Label15 = new Label();
      this.Label14 = new Label();
      this.Label13 = new Label();
      this.Label12 = new Label();
      this.Label11 = new Label();
      this.Label10 = new Label();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.Label7 = new Label();
      this.Label6 = new Label();
      this.Label31 = new Label();
      this.Label32 = new Label();
      this.TextBox1 = new TextBox();
      this.ContextMenuStrip1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.DbLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.ListView1.CheckBoxes = true;
      this.ListView1.Columns.AddRange(new ColumnHeader[5]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader5
      });
      this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
      this.ListView1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListView1.ForeColor = Color.DodgerBlue;
      this.ListView1.FullRowSelect = true;
      this.ListView1.GridLines = true;
      this.ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.ListView1.HideSelection = false;
      this.ListView1.Location = new Point(13, 128);
      this.ListView1.MultiSelect = false;
      this.ListView1.Name = "ListView1";
      this.ListView1.OwnerDraw = true;
      this.ListView1.Size = new Size(507, 379);
      this.ListView1.TabIndex = 1;
      this.ListView1.UseCompatibleStateImageBehavior = false;
      this.ListView1.View = View.Details;
      this.ColumnHeader1.Text = "   Game Name";
      this.ColumnHeader1.Width = 116;
      this.ColumnHeader2.Text = "Super Sampling";
      this.ColumnHeader2.Width = 164;
      this.ColumnHeader3.Text = "ASW Mode";
      this.ColumnHeader3.Width = 110;
      this.ColumnHeader4.Text = "CPU Priority";
      this.ColumnHeader4.Width = 113;
      this.ColumnHeader5.Text = "Enabled";
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.ToolStripMenuItem1,
        (ToolStripItem) this.ToolStripMenuItem2,
        (ToolStripItem) this.ToolStripSeparator1,
        (ToolStripItem) this.LaunchAppToolStripMenuItem,
        (ToolStripItem) this.LaunchAppWithOptionsToolStripMenuItem,
        (ToolStripItem) this.ToolStripSeparator2,
        (ToolStripItem) this.ToolStripMenuItem3,
        (ToolStripItem) this.ToolStripMenuItem4,
        (ToolStripItem) this.ToolStripMenuItem6,
        (ToolStripItem) this.ToolStripSeparator3,
        (ToolStripItem) this.ToolStripMenuItem5,
        (ToolStripItem) this.RemoveAllSelectedProfilesToolStripMenuItem
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(242, 220);
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new Size(241, 22);
      this.ToolStripMenuItem1.Text = "Hide App in Profiles";
      this.ToolStripMenuItem1.Visible = false;
      this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      this.ToolStripMenuItem2.Size = new Size(241, 22);
      this.ToolStripMenuItem2.Text = "Hide App in Profiles and Library";
      this.ToolStripMenuItem2.Visible = false;
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new Size(238, 6);
      this.LaunchAppToolStripMenuItem.Image = (Image) OculusTrayTool.My.Resources.Resources.Service_Start;
      this.LaunchAppToolStripMenuItem.Name = "LaunchAppToolStripMenuItem";
      this.LaunchAppToolStripMenuItem.Size = new Size(241, 22);
      this.LaunchAppToolStripMenuItem.Text = "Launch App";
      this.LaunchAppWithOptionsToolStripMenuItem.Name = "LaunchAppWithOptionsToolStripMenuItem";
      this.LaunchAppWithOptionsToolStripMenuItem.Size = new Size(241, 22);
      this.LaunchAppWithOptionsToolStripMenuItem.Text = "Launch App with options..";
      this.ToolStripSeparator2.Name = "ToolStripSeparator2";
      this.ToolStripSeparator2.Size = new Size(238, 6);
      this.ToolStripMenuItem3.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new Size(241, 22);
      this.ToolStripMenuItem3.Text = "Create New Profile...";
      this.ToolStripMenuItem4.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
      this.ToolStripMenuItem4.Size = new Size(241, 22);
      this.ToolStripMenuItem4.Text = "Edit highlighted profile...";
      this.ToolStripMenuItem6.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
      this.ToolStripMenuItem6.Size = new Size(241, 22);
      this.ToolStripMenuItem6.Text = "Edit all selected...";
      this.ToolStripSeparator3.Name = "ToolStripSeparator3";
      this.ToolStripSeparator3.Size = new Size(238, 6);
      this.ToolStripMenuItem5.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Delete;
      this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
      this.ToolStripMenuItem5.Size = new Size(241, 22);
      this.ToolStripMenuItem5.Text = "Remove highlighted Profile";
      this.RemoveAllSelectedProfilesToolStripMenuItem.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Delete;
      this.RemoveAllSelectedProfilesToolStripMenuItem.Name = "RemoveAllSelectedProfilesToolStripMenuItem";
      this.RemoveAllSelectedProfilesToolStripMenuItem.Size = new Size(241, 22);
      this.RemoveAllSelectedProfilesToolStripMenuItem.Text = "Remove all selected Profiles";
      this.RemoveAllSelectedProfilesToolStripMenuItem.Visible = false;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(856, 542);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(62, 25);
      this.Button2.TabIndex = 3;
      this.Button2.Text = "Close";
      this.Button2.UseVisualStyleBackColor = true;
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.Label2);
      this.GroupBox2.ForeColor = Color.DodgerBlue;
      this.GroupBox2.Location = new Point(12, 12);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(905, 79);
      this.GroupBox2.TabIndex = 10;
      this.GroupBox2.TabStop = false;
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new Point(12, 13);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(887, 60);
      this.Label2.TabIndex = 0;
      this.Label2.Text = "Double-click to edit, right-click for options.\r\n\r\nTip: You can select multiple profiles and use \"Edit all selected\" to change settings for all of them at once.\r\n";
      this.CheckVoiceConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.CheckVoiceConfirm.AutoSize = true;
      this.CheckVoiceConfirm.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckVoiceConfirm.ForeColor = Color.DodgerBlue;
      this.CheckVoiceConfirm.Location = new Point(12, 513);
      this.CheckVoiceConfirm.Name = "CheckVoiceConfirm";
      this.CheckVoiceConfirm.Size = new Size(254, 19);
      this.CheckVoiceConfirm.TabIndex = 15;
      this.CheckVoiceConfirm.Text = "Audio confirmation when profile is applied";
      this.CheckVoiceConfirm.UseVisualStyleBackColor = true;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 97);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(92, 25);
      this.Button1.TabIndex = 25;
      this.Button1.Text = "Create profile";
      this.Button1.UseVisualStyleBackColor = true;
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(10, 542);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(112, 15);
      this.Label1.TabIndex = 26;
      this.Label1.Text = "Desktop resolution:";
      this.ComboResolution.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.ComboResolution.FormattingEnabled = true;
      this.ComboResolution.Location = new Point(125, 541);
      this.ComboResolution.Name = "ComboResolution";
      this.ComboResolution.Size = new Size(104, 21);
      this.ComboResolution.TabIndex = 27;
      this.Button3.Enabled = false;
      this.Button3.FlatStyle = FlatStyle.Flat;
      this.Button3.ForeColor = Color.DodgerBlue;
      this.Button3.Location = new Point(110, 97);
      this.Button3.Name = "Button3";
      this.Button3.Size = new Size(71, 25);
      this.Button3.TabIndex = 29;
      this.Button3.Text = "Edit profile";
      this.Button3.UseVisualStyleBackColor = true;
      this.DbLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.DbLayoutPanel1.ColumnCount = 2;
      this.DbLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.14583f));
      this.DbLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.85417f));
      this.DbLayoutPanel1.Controls.Add((Control) this.Label3, 0, 0);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label4, 0, 1);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label5, 0, 2);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label16, 1, 0);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label17, 1, 1);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label18, 1, 2);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label19, 1, 3);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label20, 1, 4);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label22, 1, 6);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label23, 1, 7);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label24, 1, 8);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label25, 1, 9);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label26, 1, 10);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label27, 1, 11);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label28, 1, 12);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label30, 1, 13);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label29, 0, 14);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label15, 0, 13);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label14, 0, 12);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label13, 0, 11);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label12, 0, 10);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label11, 0, 9);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label10, 0, 8);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label9, 0, 7);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label8, 0, 6);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label7, 0, 5);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label6, 0, 4);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label31, 1, 14);
      this.DbLayoutPanel1.Controls.Add((Control) this.Label32, 0, 3);
      this.DbLayoutPanel1.Controls.Add((Control) this.TextBox1, 1, 5);
      this.DbLayoutPanel1.ForeColor = Color.DodgerBlue;
      this.DbLayoutPanel1.Location = new Point(526, 128);
      this.DbLayoutPanel1.Name = "DbLayoutPanel1";
      this.DbLayoutPanel1.RowCount = 15;
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.845564f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.297919f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.681271f));
      this.DbLayoutPanel1.Size = new Size(391, 379);
      this.DbLayoutPanel1.TabIndex = 0;
      this.Label3.AutoSize = true;
      this.Label3.Dock = DockStyle.Fill;
      this.Label3.Location = new Point(4, 1);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(153, 24);
      this.Label3.TabIndex = 0;
      this.Label3.Text = "Game name";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.Label4.AutoSize = true;
      this.Label4.Dock = DockStyle.Fill;
      this.Label4.Location = new Point(4, 26);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(153, 24);
      this.Label4.TabIndex = 1;
      this.Label4.Text = "Super Sampling";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label5.AutoSize = true;
      this.Label5.Dock = DockStyle.Fill;
      this.Label5.Location = new Point(4, 51);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(153, 24);
      this.Label5.TabIndex = 2;
      this.Label5.Text = "ASW Mode";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.Label16.AutoSize = true;
      this.Label16.Dock = DockStyle.Fill;
      this.Label16.Location = new Point(164, 1);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(223, 24);
      this.Label16.TabIndex = 13;
      this.Label16.Text = "Label16";
      this.Label16.TextAlign = ContentAlignment.MiddleLeft;
      this.Label16.Visible = false;
      this.Label17.AutoSize = true;
      this.Label17.Dock = DockStyle.Fill;
      this.Label17.Location = new Point(164, 26);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(223, 24);
      this.Label17.TabIndex = 14;
      this.Label17.Text = "Label17";
      this.Label17.TextAlign = ContentAlignment.MiddleLeft;
      this.Label17.Visible = false;
      this.Label18.AutoSize = true;
      this.Label18.Dock = DockStyle.Fill;
      this.Label18.Location = new Point(164, 51);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(223, 24);
      this.Label18.TabIndex = 15;
      this.Label18.Text = "Label18";
      this.Label18.TextAlign = ContentAlignment.MiddleLeft;
      this.Label18.Visible = false;
      this.Label19.AutoSize = true;
      this.Label19.Dock = DockStyle.Fill;
      this.Label19.Location = new Point(164, 76);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(223, 24);
      this.Label19.TabIndex = 16;
      this.Label19.Text = "Label19";
      this.Label19.TextAlign = ContentAlignment.MiddleLeft;
      this.Label19.Visible = false;
      this.Label20.AutoSize = true;
      this.Label20.Dock = DockStyle.Fill;
      this.Label20.Location = new Point(164, 101);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(223, 24);
      this.Label20.TabIndex = 17;
      this.Label20.Text = "Label20";
      this.Label20.TextAlign = ContentAlignment.MiddleLeft;
      this.Label20.Visible = false;
      this.Label22.AutoSize = true;
      this.Label22.Dock = DockStyle.Fill;
      this.Label22.Location = new Point(164, 151);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(223, 24);
      this.Label22.TabIndex = 19;
      this.Label22.Text = "Label22";
      this.Label22.TextAlign = ContentAlignment.MiddleLeft;
      this.Label22.Visible = false;
      this.Label23.AutoSize = true;
      this.Label23.Dock = DockStyle.Fill;
      this.Label23.Location = new Point(164, 176);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(223, 24);
      this.Label23.TabIndex = 20;
      this.Label23.Text = "Label23";
      this.Label23.TextAlign = ContentAlignment.MiddleLeft;
      this.Label23.Visible = false;
      this.Label24.AutoSize = true;
      this.Label24.Dock = DockStyle.Fill;
      this.Label24.Location = new Point(164, 201);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(223, 24);
      this.Label24.TabIndex = 21;
      this.Label24.Text = "Label24";
      this.Label24.TextAlign = ContentAlignment.MiddleLeft;
      this.Label24.Visible = false;
      this.Label25.AutoSize = true;
      this.Label25.Dock = DockStyle.Fill;
      this.Label25.Location = new Point(164, 226);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(223, 24);
      this.Label25.TabIndex = 22;
      this.Label25.Text = "Label25";
      this.Label25.TextAlign = ContentAlignment.MiddleLeft;
      this.Label25.Visible = false;
      this.Label26.AutoSize = true;
      this.Label26.Dock = DockStyle.Fill;
      this.Label26.Location = new Point(164, 251);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(223, 24);
      this.Label26.TabIndex = 23;
      this.Label26.Text = "Label26";
      this.Label26.TextAlign = ContentAlignment.MiddleLeft;
      this.Label26.Visible = false;
      this.Label27.AutoSize = true;
      this.Label27.Dock = DockStyle.Fill;
      this.Label27.Location = new Point(164, 276);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(223, 24);
      this.Label27.TabIndex = 24;
      this.Label27.Text = "Label27";
      this.Label27.TextAlign = ContentAlignment.MiddleLeft;
      this.Label27.Visible = false;
      this.Label28.AutoSize = true;
      this.Label28.Dock = DockStyle.Fill;
      this.Label28.Location = new Point(164, 301);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(223, 22);
      this.Label28.TabIndex = 25;
      this.Label28.Text = "Label28";
      this.Label28.TextAlign = ContentAlignment.MiddleLeft;
      this.Label28.Visible = false;
      this.Label30.AutoSize = true;
      this.Label30.Dock = DockStyle.Fill;
      this.Label30.Location = new Point(164, 324);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(223, 24);
      this.Label30.TabIndex = 27;
      this.Label30.Text = "Label30";
      this.Label30.TextAlign = ContentAlignment.MiddleLeft;
      this.Label30.Visible = false;
      this.Label29.AutoSize = true;
      this.Label29.Dock = DockStyle.Fill;
      this.Label29.Location = new Point(4, 349);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(153, 29);
      this.Label29.TabIndex = 26;
      this.Label29.Text = "Enabled";
      this.Label29.TextAlign = ContentAlignment.MiddleLeft;
      this.Label15.AutoSize = true;
      this.Label15.Dock = DockStyle.Fill;
      this.Label15.Location = new Point(4, 324);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(153, 24);
      this.Label15.TabIndex = 12;
      this.Label15.Text = "Offset MipMap Bias";
      this.Label15.TextAlign = ContentAlignment.MiddleLeft;
      this.Label14.AutoSize = true;
      this.Label14.Dock = DockStyle.Fill;
      this.Label14.Location = new Point(4, 301);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(153, 22);
      this.Label14.TabIndex = 11;
      this.Label14.Text = "Force MipMap Generation";
      this.Label14.TextAlign = ContentAlignment.MiddleLeft;
      this.Label13.AutoSize = true;
      this.Label13.Dock = DockStyle.Fill;
      this.Label13.Location = new Point(4, 276);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(153, 24);
      this.Label13.TabIndex = 10;
      this.Label13.Text = "FoV";
      this.Label13.TextAlign = ContentAlignment.MiddleLeft;
      this.Label12.AutoSize = true;
      this.Label12.Dock = DockStyle.Fill;
      this.Label12.Location = new Point(4, 251);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(153, 24);
      this.Label12.TabIndex = 9;
      this.Label12.Text = "Comment";
      this.Label12.TextAlign = ContentAlignment.MiddleLeft;
      this.Label11.AutoSize = true;
      this.Label11.Dock = DockStyle.Fill;
      this.Label11.Location = new Point(4, 226);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(153, 24);
      this.Label11.TabIndex = 8;
      this.Label11.Text = "Adaptive GPU";
      this.Label11.TextAlign = ContentAlignment.MiddleLeft;
      this.Label10.AutoSize = true;
      this.Label10.Dock = DockStyle.Fill;
      this.Label10.Location = new Point(4, 201);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(153, 24);
      this.Label10.TabIndex = 7;
      this.Label10.Text = "Mirror";
      this.Label10.TextAlign = ContentAlignment.MiddleLeft;
      this.Label9.AutoSize = true;
      this.Label9.Dock = DockStyle.Fill;
      this.Label9.Location = new Point(4, 176);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(153, 24);
      this.Label9.TabIndex = 6;
      this.Label9.Text = "CPU Delay";
      this.Label9.TextAlign = ContentAlignment.MiddleLeft;
      this.Label8.AutoSize = true;
      this.Label8.Dock = DockStyle.Fill;
      this.Label8.Location = new Point(4, 151);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(153, 24);
      this.Label8.TabIndex = 5;
      this.Label8.Text = "ASW Delay";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      this.Label7.AutoSize = true;
      this.Label7.Dock = DockStyle.Fill;
      this.Label7.Location = new Point(4, 126);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(153, 24);
      this.Label7.TabIndex = 4;
      this.Label7.Text = "Path";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      this.Label6.AutoSize = true;
      this.Label6.Dock = DockStyle.Fill;
      this.Label6.Location = new Point(4, 101);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(153, 24);
      this.Label6.TabIndex = 3;
      this.Label6.Text = "CPU Priority";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.Label31.AutoSize = true;
      this.Label31.Dock = DockStyle.Fill;
      this.Label31.Location = new Point(164, 349);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(223, 29);
      this.Label31.TabIndex = 28;
      this.Label31.Text = "Label31";
      this.Label31.TextAlign = ContentAlignment.MiddleLeft;
      this.Label31.Visible = false;
      this.Label32.AutoSize = true;
      this.Label32.Dock = DockStyle.Fill;
      this.Label32.Location = new Point(4, 76);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(153, 24);
      this.Label32.TabIndex = 29;
      this.Label32.Text = "Detection Method";
      this.Label32.TextAlign = ContentAlignment.MiddleLeft;
      this.TextBox1.BorderStyle = BorderStyle.None;
      this.TextBox1.Dock = DockStyle.Fill;
      this.TextBox1.ForeColor = Color.DodgerBlue;
      this.TextBox1.Location = new Point(164, 129);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(223, 13);
      this.TextBox1.TabIndex = 30;
      this.TextBox1.Visible = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = Color.White;
      this.ClientSize = new Size(930, 574);
      this.Controls.Add((Control) this.DbLayoutPanel1);
      this.Controls.Add((Control) this.Button3);
      this.Controls.Add((Control) this.ComboResolution);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.CheckVoiceConfirm);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.ListView1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MinimumSize = new Size(946, 613);
      this.Name = nameof (frmProfiles);
      this.ShowIcon = false;
      this.SizeGripStyle = SizeGripStyle.Show;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Profiles";
      this.ContextMenuStrip1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.DbLayoutPanel1.ResumeLayout(false);
      this.DbLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual ListView ListView1
    {
      get => this._ListView1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.ListView1_DoubleClick);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.ListView1_MouseMove);
        DrawListViewColumnHeaderEventHandler headerEventHandler = new DrawListViewColumnHeaderEventHandler(this.ListView1_DrawColumnHeader);
        DrawListViewItemEventHandler itemEventHandler1 = new DrawListViewItemEventHandler(this.ListView1_DrawItem);
        DrawListViewSubItemEventHandler itemEventHandler2 = new DrawListViewSubItemEventHandler(this.ListView1_DrawSubItem);
        EventHandler eventHandler2 = new EventHandler(this.ListView1_MouseHover);
        EventHandler eventHandler3 = new EventHandler(this.ListView1_Click);
        ListView listView1_1 = this._ListView1;
        if (listView1_1 != null)
        {
          listView1_1.DoubleClick -= eventHandler1;
          listView1_1.MouseMove -= mouseEventHandler;
          listView1_1.DrawColumnHeader -= headerEventHandler;
          listView1_1.DrawItem -= itemEventHandler1;
          listView1_1.DrawSubItem -= itemEventHandler2;
          listView1_1.MouseHover -= eventHandler2;
          listView1_1.Click -= eventHandler3;
        }
        this._ListView1 = value;
        ListView listView1_2 = this._ListView1;
        if (listView1_2 == null)
          return;
        listView1_2.DoubleClick += eventHandler1;
        listView1_2.MouseMove += mouseEventHandler;
        listView1_2.DrawColumnHeader += headerEventHandler;
        listView1_2.DrawItem += itemEventHandler1;
        listView1_2.DrawSubItem += itemEventHandler2;
        listView1_2.MouseHover += eventHandler2;
        listView1_2.Click += eventHandler3;
      }
    }

    [field: AccessedThroughProperty("ColumnHeader1")]
    internal virtual ColumnHeader ColumnHeader1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader2")]
    internal virtual ColumnHeader ColumnHeader2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader3")]
    internal virtual ColumnHeader ColumnHeader3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button2
    {
      get => this._Button2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        Button button2_1 = this._Button2;
        if (button2_1 != null)
          button2_1.Click -= eventHandler;
        this._Button2 = value;
        Button button2_2 = this._Button2;
        if (button2_2 == null)
          return;
        button2_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolTip1")]
    internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader4")]
    internal virtual ColumnHeader ColumnHeader4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox2")]
    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox CheckVoiceConfirm
    {
      get => this._CheckVoiceConfirm;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckVoiceConfirm_CheckedChanged);
        CheckBox checkVoiceConfirm1 = this._CheckVoiceConfirm;
        if (checkVoiceConfirm1 != null)
          checkVoiceConfirm1.CheckedChanged -= eventHandler;
        this._CheckVoiceConfirm = value;
        CheckBox checkVoiceConfirm2 = this._CheckVoiceConfirm;
        if (checkVoiceConfirm2 == null)
          return;
        checkVoiceConfirm2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ContextMenuStrip ContextMenuStrip1
    {
      get => this._ContextMenuStrip1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.ContextMenuStrip1_Opening);
        EventHandler eventHandler = new EventHandler(this.ContextMenuStrip1_MouseLeave);
        ContextMenuStrip contextMenuStrip1_1 = this._ContextMenuStrip1;
        if (contextMenuStrip1_1 != null)
        {
          contextMenuStrip1_1.Opening -= cancelEventHandler;
          contextMenuStrip1_1.MouseLeave -= eventHandler;
        }
        this._ContextMenuStrip1 = value;
        ContextMenuStrip contextMenuStrip1_2 = this._ContextMenuStrip1;
        if (contextMenuStrip1_2 == null)
          return;
        contextMenuStrip1_2.Opening += cancelEventHandler;
        contextMenuStrip1_2.MouseLeave += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolStripMenuItem1")]
    internal virtual ToolStripMenuItem ToolStripMenuItem1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ToolStripMenuItem2")]
    internal virtual ToolStripMenuItem ToolStripMenuItem2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem ToolStripMenuItem3
    {
      get => this._ToolStripMenuItem3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem3_Click);
        ToolStripMenuItem toolStripMenuItem3_1 = this._ToolStripMenuItem3;
        if (toolStripMenuItem3_1 != null)
          toolStripMenuItem3_1.Click -= eventHandler;
        this._ToolStripMenuItem3 = value;
        ToolStripMenuItem toolStripMenuItem3_2 = this._ToolStripMenuItem3;
        if (toolStripMenuItem3_2 == null)
          return;
        toolStripMenuItem3_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem4
    {
      get => this._ToolStripMenuItem4;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem4_Click);
        ToolStripMenuItem toolStripMenuItem4_1 = this._ToolStripMenuItem4;
        if (toolStripMenuItem4_1 != null)
          toolStripMenuItem4_1.Click -= eventHandler;
        this._ToolStripMenuItem4 = value;
        ToolStripMenuItem toolStripMenuItem4_2 = this._ToolStripMenuItem4;
        if (toolStripMenuItem4_2 == null)
          return;
        toolStripMenuItem4_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem5
    {
      get => this._ToolStripMenuItem5;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem5_Click);
        ToolStripMenuItem toolStripMenuItem5_1 = this._ToolStripMenuItem5;
        if (toolStripMenuItem5_1 != null)
          toolStripMenuItem5_1.Click -= eventHandler;
        this._ToolStripMenuItem5 = value;
        ToolStripMenuItem toolStripMenuItem5_2 = this._ToolStripMenuItem5;
        if (toolStripMenuItem5_2 == null)
          return;
        toolStripMenuItem5_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolStripSeparator1")]
    internal virtual ToolStripSeparator ToolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ToolStripSeparator2")]
    internal virtual ToolStripSeparator ToolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem LaunchAppToolStripMenuItem
    {
      get => this._LaunchAppToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.LaunchAppToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._LaunchAppToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._LaunchAppToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._LaunchAppToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem LaunchAppWithOptionsToolStripMenuItem
    {
      get => this._LaunchAppWithOptionsToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.LaunchAppWithOptionsToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._LaunchAppWithOptionsToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._LaunchAppWithOptionsToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._LaunchAppWithOptionsToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual Button Button1
    {
      get => this._Button1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem6
    {
      get => this._ToolStripMenuItem6;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem6_Click);
        ToolStripMenuItem toolStripMenuItem6_1 = this._ToolStripMenuItem6;
        if (toolStripMenuItem6_1 != null)
          toolStripMenuItem6_1.Click -= eventHandler;
        this._ToolStripMenuItem6 = value;
        ToolStripMenuItem toolStripMenuItem6_2 = this._ToolStripMenuItem6;
        if (toolStripMenuItem6_2 == null)
          return;
        toolStripMenuItem6_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolStripSeparator3")]
    internal virtual ToolStripSeparator ToolStripSeparator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("RemoveAllSelectedProfilesToolStripMenuItem")]
    internal virtual ToolStripMenuItem RemoveAllSelectedProfilesToolStripMenuItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox ComboResolution
    {
      get => this._ComboResolution;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboResolution_SelectedIndexChanged);
        ComboBox comboResolution1 = this._ComboResolution;
        if (comboResolution1 != null)
          comboResolution1.SelectedIndexChanged -= eventHandler;
        this._ComboResolution = value;
        ComboBox comboResolution2 = this._ComboResolution;
        if (comboResolution2 == null)
          return;
        comboResolution2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label11")]
    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label10")]
    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label9")]
    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label8")]
    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label7")]
    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label6")]
    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label5")]
    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label4")]
    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label3")]
    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label13")]
    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label12")]
    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label15")]
    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label14")]
    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("DbLayoutPanel1")]
    internal virtual DBLayoutPanel DbLayoutPanel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label29")]
    internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label16")]
    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label17")]
    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label18")]
    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label19")]
    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label20")]
    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label22")]
    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label23")]
    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label24")]
    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label25")]
    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label26")]
    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label27")]
    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label28")]
    internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label30")]
    internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button3
    {
      get => this._Button3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button3_Click);
        Button button3_1 = this._Button3;
        if (button3_1 != null)
          button3_1.Click -= eventHandler;
        this._Button3 = value;
        Button button3_2 = this._Button3;
        if (button3_2 == null)
          return;
        button3_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Label31")]
    internal virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label32")]
    internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TextBox1")]
    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ColumnHeader5")]
    internal virtual ColumnHeader ColumnHeader5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void scan_FormClosing(object sender, FormClosingEventArgs e)
    {
      MySettingsProperty.Settings.ScanDialogSize = this.Size;
      MySettingsProperty.Settings.ScanWindowLocation = this.Location;
      MySettingsProperty.Settings.Save();
      if (e.CloseReason != CloseReason.UserClosing)
        return;
      this.Hide();
      e.Cancel = true;
    }

    private void scan_Load(object sender, EventArgs e)
    {
      frmProfiles.SetDoubleBuffered((Control) this.ListView1);
      this.Size = MySettingsProperty.Settings.ScanDialogSize;
      this.rs.FindAllControls((Control) this);
      this.rs.ResizeAllControls((Control) this, (float) MyProject.Forms.FrmMain.TrackBar1.Value);
      Point point;
      if (MySettingsProperty.Settings.ScanWindowLocation != new Point())
      {
        if (Globals.dbg)
        {
          point = MySettingsProperty.Settings.ScanWindowLocation;
          Log.WriteToLog("Setting Profiles GUI location to " + point.ToString());
        }
        this.Location = MySettingsProperty.Settings.ScanWindowLocation;
      }
      else
      {
        this.CenterToScreen();
        MySettingsProperty.Settings.ScanWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      point = this.Location;
      int num1 = point.X < 0 ? 1 : 0;
      point = this.Location;
      int num2 = point.Y < 0 ? 1 : 0;
      if ((num1 | num2) != 0)
      {
        if (Globals.dbg)
          Log.WriteToLog("Profiles GUI location has negative number, adjusting");
        this.CenterToScreen();
        MySettingsProperty.Settings.ScanWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      this.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      this.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      this.Show();
      this.ComboResolution.Focus();
    }

    private bool FindItem(
      ListView.ListViewItemCollection ItemList,
      int ColumnIndex,
      string SearchString)
    {
      try
      {
        foreach (ListViewItem listViewItem in ItemList)
        {
          if (Operators.CompareString(listViewItem.SubItems[ColumnIndex].Text, SearchString, false) == 0)
            return true;
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return false;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.ProfilesWindowLocation = this.Location;
      MySettingsProperty.Settings.ProfilesWindowSize = this.Size;
      MySettingsProperty.Settings.Save();
      this.Hide();
    }

    public static void SetDoubleBuffered(Control control)
    {
      typeof (Control).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) control, new object[1]
      {
        (object) true
      });
    }

    private void DeleteProfile()
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      try
      {
        foreach (ListViewItem selectedItem in this.ListView1.SelectedItems)
        {
          if (Interaction.MsgBox((object) ("Remove profile for '" + selectedItem.Text.Replace(" *", "") + "'?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Confirm") == MsgBoxResult.Yes)
          {
            OTTDB.RemoveProfile(this.TextBox1.Text);
            this.ListView1.Items.Clear();
            OTTDB.GetProfiles();
            if (OTTDB.numWMI > 0)
              MyProject.Forms.FrmMain.CreateWatcher();
            if (OTTDB.numTimer > 0)
              MyProject.Forms.FrmMain.pTimer.Start();
          }
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
        GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
      if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0)
      {
        string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
        int index = 0;
        while (index < strArray.Length)
        {
          string str = strArray[index];
          if (Directory.Exists(str.TrimEnd('\\') + "\\Manifests"))
            GetGames.GetFiles(str.TrimEnd('\\') + "\\Manifests");
          if (Directory.Exists(str.TrimEnd('\\') + "\\CoreData\\Manifests"))
            GetGames.GetThirdPartyApps(str.TrimEnd('\\') + "\\CoreData\\Manifests");
          checked { ++index; }
        }
      }
    }

    private void CheckVoiceConfirm_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.VoiceConfirmProfile = this.CheckVoiceConfirm.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count > 0 | this.ListView1.CheckedItems.Count <= 1)
      {
        this.ToolStripMenuItem1.Enabled = true;
        this.ToolStripMenuItem2.Enabled = true;
        this.ToolStripMenuItem3.Enabled = false;
        this.ToolStripMenuItem4.Enabled = true;
        this.ToolStripMenuItem5.Enabled = true;
        this.ToolStripMenuItem6.Enabled = false;
        this.LaunchAppToolStripMenuItem.Enabled = true;
        this.LaunchAppWithOptionsToolStripMenuItem.Enabled = true;
        this.RemoveAllSelectedProfilesToolStripMenuItem.Enabled = false;
      }
      else
      {
        this.ToolStripMenuItem1.Enabled = false;
        this.ToolStripMenuItem2.Enabled = false;
        this.ToolStripMenuItem3.Enabled = true;
        this.ToolStripMenuItem4.Enabled = false;
        this.ToolStripMenuItem5.Enabled = false;
        this.LaunchAppToolStripMenuItem.Enabled = false;
        this.LaunchAppWithOptionsToolStripMenuItem.Enabled = false;
        this.RemoveAllSelectedProfilesToolStripMenuItem.Enabled = false;
      }
      if (this.ListView1.CheckedItems.Count <= 1)
        return;
      this.ToolStripMenuItem1.Enabled = false;
      this.ToolStripMenuItem2.Enabled = false;
      this.ToolStripMenuItem3.Enabled = false;
      this.ToolStripMenuItem4.Enabled = false;
      this.ToolStripMenuItem5.Enabled = false;
      this.ToolStripMenuItem6.Enabled = true;
      this.LaunchAppToolStripMenuItem.Enabled = false;
      this.LaunchAppWithOptionsToolStripMenuItem.Enabled = false;
      this.RemoveAllSelectedProfilesToolStripMenuItem.Enabled = true;
    }

    private void ListView1_DoubleClick(object sender, EventArgs e)
    {
      this.selectedItem = this.ListView1.SelectedItems[0].Index;
      try
      {
        foreach (ListViewItem checkedItem in this.ListView1.CheckedItems)
          checkedItem.Checked = false;
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ShowEdit();
    }

    private void ToolStripMenuItem3_Click(object sender, EventArgs e) => this.ShowCreate();

    private void ShowEdit()
    {
      try
      {
        string[] strArray1 = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
        MyProject.Forms.frmCreateEditProfile.TextDisplayName.Text = strArray1[0];
        MyProject.Forms.frmCreateEditProfile.ComboSS.Text = strArray1[1];
        MyProject.Forms.frmCreateEditProfile.ComboASW.Text = strArray1[2];
        MyProject.Forms.frmCreateEditProfile.ComboCPU.Text = strArray1[4];
        MyProject.Forms.frmCreateEditProfile.ComboMethod.Text = strArray1[3];
        MyProject.Forms.frmCreateEditProfile.pLaunchfile = Path.GetFileName(strArray1[5]);
        MyProject.Forms.frmCreateEditProfile.pPath = strArray1[5];
        MyProject.Forms.frmCreateEditProfile.TextBoxPath.Text = strArray1[5];
        if (!File.Exists(strArray1[5]))
        {
          MyProject.Forms.frmCreateEditProfile.TextBoxPath.BackColor = Color.LightCoral;
          this.ToolTip1.SetToolTip((Control) MyProject.Forms.frmCreateEditProfile.TextBoxPath, "Path not found!");
        }
        else
        {
          MyProject.Forms.frmCreateEditProfile.TextBoxPath.BackColor = Color.White;
          this.ToolTip1.SetToolTip((Control) MyProject.Forms.frmCreateEditProfile.TextBoxPath, "");
        }
        MyProject.Forms.frmCreateEditProfile.NumericUpDown1.Value = new Decimal(Conversions.ToInteger(strArray1[6]));
        MyProject.Forms.frmCreateEditProfile.NumericUpDown2.Value = new Decimal(Conversions.ToInteger(strArray1[7]));
        MyProject.Forms.frmCreateEditProfile.ComboMirror.Text = strArray1[8];
        MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = strArray1[9];
        MyProject.Forms.frmCreateEditProfile.TextBoxComment.Text = strArray1[10];
        string[] strArray2 = Strings.Split(strArray1[11]);
        MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = new Decimal(Conversions.ToDouble(strArray2[0]));
        MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = new Decimal(Conversions.ToDouble(strArray2[1]));
        MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = strArray1[12];
        MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = strArray1[13];
        MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = strArray1[14];
        MyProject.Forms.frmCreateEditProfile.TextDisplayName.Visible = true;
        MyProject.Forms.frmCreateEditProfile.ComboBox1.Visible = false;
        MyProject.Forms.frmCreateEditProfile.TopMost = true;
        MyProject.Forms.frmCreateEditProfile.isEdit = true;
        MyProject.Forms.frmCreateEditProfile.Button1.Enabled = true;
        int num = (int) MyProject.Forms.frmCreateEditProfile.ShowDialog();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ShowEdit: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void ShowCreate()
    {
      try
      {
        MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
        MyProject.Forms.frmCreateEditProfile.TextDisplayName.Visible = false;
        MyProject.Forms.frmCreateEditProfile.ComboBox1.Visible = true;
        MyProject.Forms.frmCreateEditProfile.ComboBox1.DisplayMember = "Name";
        MyProject.Forms.frmCreateEditProfile.ComboBox1.ValueMember = "Info";
        MyProject.Forms.frmCreateEditProfile.ComboSS.Text = MyProject.Forms.FrmMain.ComboSSstart.Text;
        MyProject.Forms.frmCreateEditProfile.ComboASW.Text = MyProject.Forms.FrmMain.ComboBox1.Text;
        MyProject.Forms.frmCreateEditProfile.ComboCPU.SelectedIndex = 0;
        MyProject.Forms.frmCreateEditProfile.ComboMethod.SelectedIndex = 0;
        MyProject.Forms.frmCreateEditProfile.NumericUpDown1.Value = 5M;
        MyProject.Forms.frmCreateEditProfile.NumericUpDown2.Value = 5M;
        MyProject.Forms.frmCreateEditProfile.ComboMirror.SelectedIndex = 0;
        MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = MyProject.Forms.FrmMain.ComboBox5.Text;
        MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = MyProject.Forms.FrmMain.NumericFOVh.Value;
        MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = MyProject.Forms.FrmMain.NumericFOVv.Value;
        MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = MyProject.Forms.FrmMain.ComboBox8.Text;
        MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = MyProject.Forms.FrmMain.ComboBox9.Text;
        MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = "Yes";
        try
        {
          foreach (KeyValuePair<string, string> game in this.GameList)
            MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add((object) new frmCreateEditProfile.GameItem(game.Key, game.Value));
        }
        finally
        {
          Dictionary<string, string>.Enumerator enumerator;
          enumerator.Dispose();
        }
        if (MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Count > 0)
          MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add((object) "- All Games & Apps -");
        int num = (int) MyProject.Forms.frmCreateEditProfile.ShowDialog();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ShowCreate: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void ToolStripMenuItem4_Click(object sender, EventArgs e)
    {
      this.selectedItem = this.ListView1.SelectedItems[0].Index;
      this.ShowEdit();
    }

    private void ToolStripMenuItem5_Click(object sender, EventArgs e) => this.DeleteProfile();

    private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
    {
      this.ContextMenuStrip1.Close();
      this.ListView1.Focus();
    }

    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.ListView1.CheckedItems.Count != 0)
        return;
      ListViewItem itemAt = this.ListView1.GetItemAt(e.X, e.Y);
      try
      {
        foreach (ListViewItem listViewItem in this.ListView1.Items)
        {
          if (listViewItem != itemAt)
            listViewItem.Selected = false;
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (itemAt != null)
        itemAt.Selected = true;
    }

    private void LaunchAppToolStripMenuItem_Click(object sender, EventArgs e) => this.LaunchApp();

    private void LaunchApp()
    {
      try
      {
        string str1 = "";
        string str2 = "";
        string str3 = "";
        if (GetGames.manifesDictionary.TryGetValue(this.ListView1.SelectedItems[0].Text, out str1))
        {
          if (File.Exists(str1))
          {
            List<string> stringList = new List<string>();
            List<string> appInfo = this.GetAppInfo(str1, "");
            int num1 = checked (appInfo.Count - 1);
            int num2 = 0;
            while (num2 <= num1)
            {
              str2 = appInfo[0];
              str3 = appInfo[1];
              checked { ++num2; }
            }
            if (Operators.CompareString(str2, "", false) != 0 & File.Exists(str2))
            {
              MyProject.Forms.FrmMain.ManualStart = true;
              if (!MyProject.Forms.FrmMain.HomeIsRunning)
                RunCommand.StartHome();
              Thread.Sleep(3000);
              if (MyProject.Forms.frmLibrary.ManualStartProfiles.ContainsKey(str2.ToLower()))
              {
                Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(str2));
                this.ApplyProfile(str2.TrimStart().TrimEnd());
              }
              else
              {
                Log.WriteToLog("No profile found for '" + str2 + "'");
                FrmMain.fmain.AddToListboxAndScroll("No profile found for '" + str2 + "'");
              }
              if (Operators.CompareString(str3, "", false) != 0)
                Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text + " (" + str2.TrimStart().TrimEnd() + str3.TrimStart().TrimEnd() + ")");
              else
                Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text + " (" + str2.TrimStart().TrimEnd() + ")");
              Process.Start(str2, str3);
            }
          }
        }
        else
        {
          string text = this.TextBox1.Text;
          if (File.Exists(text))
          {
            MyProject.Forms.FrmMain.ManualStart = true;
            if (!MyProject.Forms.FrmMain.HomeIsRunning)
              RunCommand.StartHome();
            Thread.Sleep(3000);
            Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
            this.ApplyProfile(text.TrimStart().TrimEnd());
            Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
            Log.WriteToLog(" -> " + text.TrimStart().TrimEnd());
            Process.Start(text, str3);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("LaunchApp(): " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Could not launch app: " + exception.Message));
        ProjectData.ClearProjectError();
      }
      if (Globals.dbg)
        Log.WriteToLog("Adding backgroundworker AppWatchWorker");
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(MyProject.Forms.FrmMain.AppWork);
      backgroundWorker.RunWorkerAsync();
      if (!Globals.dbg)
        return;
      Log.WriteToLog("Worker started");
    }

    private void ApplyProfile(string appName)
    {
      string ss = "";
      if (MyProject.Forms.frmLibrary.ManualStartProfiles.TryGetValue(appName.ToLower(), out ss))
      {
        new Thread((ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool(ss))).Start();
        string Left = "";
        if (MyProject.Forms.FrmMain.profileAGPS.TryGetValue(appName.ToLower(), out Left))
        {
          if (Operators.CompareString(Left, "0", false) == 0)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (frmProfiles._Closure\u0024__.\u0024I264\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = frmProfiles._Closure\u0024__.\u0024I264\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmProfiles._Closure\u0024__.\u0024I264\u002D1 = start = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_agps("false"));
            }
            new Thread(start).Start();
          }
          else
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (frmProfiles._Closure\u0024__.\u0024I264\u002D2 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = frmProfiles._Closure\u0024__.\u0024I264\u002D2;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmProfiles._Closure\u0024__.\u0024I264\u002D2 = start = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_agps("true"));
            }
            new Thread(start).Start();
          }
        }
        if (MySettingsProperty.Settings.VoiceConfirmProfile)
        {
          ThreadStart start;
          // ISSUE: reference to a compiler-generated field
          if (frmProfiles._Closure\u0024__.\u0024I264\u002D3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            start = frmProfiles._Closure\u0024__.\u0024I264\u002D3;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            frmProfiles._Closure\u0024__.\u0024I264\u002D3 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav"));
          }
          new Thread(start).Start();
        }
        MyProject.Forms.FrmMain.runningApp = appName;
        string displayName = OTTDB.GetDisplayName(appName);
        MyProject.Forms.FrmMain.runningapp_displayname = OTTDB.GetDisplayName(appName);
        Log.WriteToLog("Manual game launch detected: " + displayName + " (" + appName + ")");
        Log.WriteToLog(displayName + ": Super Sampling @ " + ss);
        if (Globals.dbg)
          Log.WriteToLog(MyProject.Forms.FrmMain.runningApp + ": Super Sampling @ " + ss);
        FrmMain.fmain.AddToListboxAndScroll(displayName + ": Super Sampling @ " + ss);
        string str1 = "";
        if (MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str1))
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = (double) checked (Conversions.ToInteger(str1) * 1000);
          timer.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyAswTick);
          timer.Start();
          Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str1 + " seconds");
          FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str1 + " seconds");
        }
        string str2 = "";
        if (!MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str2))
          return;
        System.Timers.Timer timer1 = new System.Timers.Timer();
        timer1.AutoReset = false;
        timer1.Interval = (double) checked (Conversions.ToInteger(str2) * 1000);
        timer1.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyCpuPrioTick);
        timer1.Start();
        Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + str2 + " seconds");
        FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + str2 + " seconds");
      }
      else
        Log.WriteToLog("No profile found for '" + appName + "'");
    }

    private List<string> GetAppInfo(string jFile, string customParms)
    {
      List<string> appInfo = new List<string>();
      JObject jobject = (JObject) JToken.Parse(File.ReadAllText(jFile));
      string str1 = (string) jobject.SelectToken("canonicalName");
      string str2 = ((string) jobject.SelectToken("launchFile")).Replace("\\\\", "\\").Replace("/", "\\");
      string str3 = Operators.CompareString(customParms, "", false) != 0 ? customParms : (string) jobject.SelectToken("launchParameters");
      string str4 = str2.Replace("\\\\", "\\").Replace("/", "\\");
      string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
      int index = 0;
      while (index < strArray.Length)
      {
        string str5 = strArray[index];
        if (File.Exists(str5 + "\\Software\\" + str1 + "\\" + str2))
        {
          str4 = str5 + "\\Software\\" + str1 + "\\" + str2;
          break;
        }
        checked { ++index; }
      }
      appInfo.Add(str4);
      appInfo.Add(str3);
      return appInfo;
    }

    private void LaunchAppWithOptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      if (GetGames.manifesDictionary.TryGetValue(this.ListView1.SelectedItems[0].Text, out str1))
      {
        if (File.Exists(str1))
        {
          List<string> stringList = new List<string>();
          List<string> appInfo = this.GetAppInfo(str1, "");
          int num1 = checked (appInfo.Count - 1);
          int num2 = 0;
          while (num2 <= num1)
          {
            str2 = appInfo[0];
            str3 = appInfo[1];
            checked { ++num2; }
          }
          MyProject.Forms.frmLaunchOptions.TextBox1.Text = str3;
          int num3 = (int) MyProject.Forms.frmLaunchOptions.ShowDialog();
          if (MyProject.Forms.frmLaunchOptions.optionsCanceled)
            return;
          if (Operators.CompareString(MyProject.Forms.frmLaunchOptions.TextBox1.Text, "", false) != 0)
            str3 = str3 + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text;
          if (Operators.CompareString(str2, "", false) != 0 & File.Exists(str2))
          {
            MyProject.Forms.FrmMain.ManualStart = true;
            if (!MyProject.Forms.FrmMain.HomeIsRunning)
              RunCommand.StartHome();
            Thread.Sleep(3000);
            if (MyProject.Forms.frmLibrary.ManualStartProfiles.ContainsKey(str2.ToLower()))
            {
              Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(str2));
              FrmMain.fmain.AddToListboxAndScroll("Applying profile for " + OTTDB.GetDisplayName(str2));
              this.ApplyProfile(str2.TrimStart().TrimEnd());
            }
            else
            {
              Log.WriteToLog("No profile found for '" + str2 + "'");
              FrmMain.fmain.AddToListboxAndScroll("No profile found for '" + str2 + "'");
            }
            FrmMain.fmain.AddToListboxAndScroll("Launching " + this.ListView1.SelectedItems[0].Text + " with params '" + str3.TrimStart().TrimEnd() + "'");
            if (Operators.CompareString(str3, "", false) != 0)
              Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text + " (" + str2.TrimStart().TrimEnd() + str3.TrimStart().TrimEnd() + ")");
            else
              Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text + " (" + str2.TrimStart().TrimEnd() + ")");
            Process.Start(str2, str3);
          }
        }
      }
      else
      {
        string text = this.TextBox1.Text;
        if (File.Exists(text))
        {
          MyProject.Forms.FrmMain.ManualStart = true;
          if (!MyProject.Forms.FrmMain.HomeIsRunning)
            RunCommand.StartHome();
          Thread.Sleep(3000);
          Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(text));
          this.ApplyProfile(text.TrimStart().TrimEnd());
          Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
          Log.WriteToLog(" -> " + text.TrimStart().TrimEnd());
          Process.Start(text, str3);
        }
      }
      if (Globals.dbg)
        Log.WriteToLog("Adding backgroundworker AppWatchWorker");
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(MyProject.Forms.FrmMain.AppWork);
      backgroundWorker.RunWorkerAsync();
      if (!Globals.dbg)
        return;
      Log.WriteToLog("Worker started");
    }

    private void Button1_Click(object sender, EventArgs e) => this.ShowCreate();

    private void ToolStripMenuItem6_Click(object sender, EventArgs e)
    {
      MyProject.Forms.frmEditAllSelected.NumericUpDown1.Text = "";
      MyProject.Forms.frmEditAllSelected.NumericUpDown2.Text = "";
      MyProject.Forms.frmEditAllSelected.ComboSS.Text = "";
      MyProject.Forms.frmEditAllSelected.ComboASW.Text = "";
      MyProject.Forms.frmEditAllSelected.ComboCPU.Text = "";
      MyProject.Forms.frmEditAllSelected.ComboMethod.Text = "";
      MyProject.Forms.frmEditAllSelected.ComboMirror.Text = "";
      MyProject.Forms.frmEditAllSelected.ComboAGPS.Text = "";
      MyProject.Forms.frmEditAllSelected.TextBoxComment.Text = "";
      int num = (int) MyProject.Forms.frmEditAllSelected.ShowDialog();
    }

    private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
      if (e.ColumnIndex == 0)
      {
        CheckBox checkBox = new CheckBox();
        checkBox.Text = "";
        checkBox.Visible = true;
        this.cck = checkBox;
        e.DrawBackground();
        this.cck.BackColor = Color.Transparent;
        this.cck.UseVisualStyleBackColor = true;
        CheckBox cck1 = this.cck;
        int x = e.Bounds.X;
        int y = e.Bounds.Y;
        CheckBox cck2 = this.cck;
        Rectangle bounds = e.Bounds;
        int width1 = bounds.Width;
        bounds = e.Bounds;
        int height1 = bounds.Height;
        Size proposedSize1 = new Size(width1, height1);
        int width2 = cck2.GetPreferredSize(proposedSize1).Width;
        CheckBox cck3 = this.cck;
        bounds = e.Bounds;
        int width3 = bounds.Width;
        bounds = e.Bounds;
        int height2 = bounds.Height;
        Size proposedSize2 = new Size(width3, height2);
        int width4 = cck3.GetPreferredSize(proposedSize2).Width;
        cck1.SetBounds(x, y, width2, width4);
        CheckBox cck4 = this.cck;
        CheckBox cck5 = this.cck;
        bounds = e.Bounds;
        int width5 = checked (bounds.Width - 1);
        bounds = e.Bounds;
        int height3 = bounds.Height;
        Size proposedSize3 = new Size(width5, height3);
        int width6 = checked (cck5.GetPreferredSize(proposedSize3).Width + 1);
        bounds = e.Bounds;
        int height4 = bounds.Height;
        Size size = new Size(width6, height4);
        cck4.Size = size;
        this.cck.Location = new Point(4, 2);
        this.ListView1.Controls.Add((Control) this.cck);
        this.cck.Show();
        this.cck.BringToFront();
        e.DrawText(TextFormatFlags.VerticalCenter);
        this.cck.CheckedChanged += new EventHandler(this.theCheckboxInHeader_CheckChanged);
      }
      else
        e.DrawDefault = true;
    }

    private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
      e.DrawDefault = true;
    }

    private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
      e.DrawDefault = true;
    }

    private void theCheckboxInHeader_CheckChanged(object sender, EventArgs e)
    {
      if (this.ListView1.Items.Count > 0)
      {
        if (this.cck.Checked)
        {
          try
          {
            foreach (ListViewItem listViewItem in this.ListView1.Items)
              listViewItem.Checked = true;
          }
          finally
          {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        else if (!this.cck.Checked)
        {
          try
          {
            foreach (ListViewItem listViewItem in this.ListView1.Items)
              listViewItem.Checked = false;
          }
          finally
          {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
      }
    }

    private void ComboResolution_SelectedIndexChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.DesktopResolution = Conversions.ToString(this.ComboResolution.SelectedItem);
      MySettingsProperty.Settings.Save();
    }

    private void ListView1_MouseHover(object sender, EventArgs e) => this.ListView1.Refresh();

    private void ListView1_Click(object sender, EventArgs e)
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      string[] strArray1 = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      this.Label16.Text = strArray1[0];
      this.Label17.Text = strArray1[1];
      this.Label18.Text = strArray1[2];
      this.Label19.Text = strArray1[3];
      this.Label20.Text = strArray1[4];
      this.TextBox1.Text = strArray1[5];
      this.Label22.Text = strArray1[6] + " seconds";
      this.Label23.Text = strArray1[7] + " seconds";
      this.Label24.Text = strArray1[8];
      this.Label25.Text = strArray1[9];
      this.Label26.Text = strArray1[10];
      string[] strArray2 = Strings.Split(strArray1[11]);
      this.Label27.Text = "Horizontal: " + strArray2[0] + " Vertical: " + strArray2[1];
      this.Label28.Text = strArray1[12];
      this.Label30.Text = strArray1[13];
      this.Label31.Text = strArray1[14];
      this.Label16.Visible = true;
      this.Label17.Visible = true;
      this.Label18.Visible = true;
      this.Label19.Visible = true;
      this.Label20.Visible = true;
      this.TextBox1.Visible = true;
      this.Label22.Visible = true;
      this.Label23.Visible = true;
      this.Label24.Visible = true;
      this.Label25.Visible = true;
      this.Label26.Visible = true;
      this.Label27.Visible = true;
      this.Label28.Visible = true;
      this.Label30.Visible = true;
      this.Label31.Visible = true;
      this.Button3.Enabled = true;
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      if (this.ListView1.CheckedItems.Count == 1)
        this.ShowEdit();
      else if (this.ListView1.SelectedItems.Count == 1 & this.ListView1.CheckedItems.Count < 2)
        this.ShowEdit();
      else if (this.ListView1.CheckedItems.Count > 1)
      {
        MyProject.Forms.frmEditAllSelected.NumericUpDown1.Text = "";
        MyProject.Forms.frmEditAllSelected.NumericUpDown2.Text = "";
        MyProject.Forms.frmEditAllSelected.ComboSS.Text = "";
        MyProject.Forms.frmEditAllSelected.ComboASW.Text = "";
        MyProject.Forms.frmEditAllSelected.ComboCPU.Text = "";
        MyProject.Forms.frmEditAllSelected.ComboMethod.Text = "";
        MyProject.Forms.frmEditAllSelected.ComboMirror.Text = "";
        MyProject.Forms.frmEditAllSelected.ComboAGPS.Text = "";
        MyProject.Forms.frmEditAllSelected.TextBoxComment.Text = "";
        int num = (int) MyProject.Forms.frmEditAllSelected.ShowDialog();
      }
    }
  }
}
