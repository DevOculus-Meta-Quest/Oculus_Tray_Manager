// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmLibrary
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmLibrary : Form
  {
    private IContainer components;
    private ImageList imageListLarge;
    public static ImageList icons = new ImageList();
    private ImageList ImgListOverlay;
    private string steam_assets;
    private string backupPath;
    private bool changeMade;
    private List<string> steamExes;
    private Resizer rs;
    private bool isReading;
    private bool scrapeDone;
    private bool libraryLoaded;
    public Dictionary<string, string> ManualStartProfiles;
    private bool removeOK;
    public int LocalDBVersion;
    public int IconsLocalDBVersion;
    private Thread GetIcons;
    public SQLiteConnection Steamcnn;
    public SQLiteConnection Iconscnn;
    private int offset;
    private bool isOpen;
    private bool IconsisOpen;
    private int dbCount;
    private bool isSearch;
    private bool lvShrunk;
    private string selectedLink;
    private int ShrinkSize;
    private ListView lvToShrink;
    private bool NoIconSet;
    private bool BrowseForIcons;
    private SQLiteConnection cnn;
    private List<string> IconGameList;
    public List<string> DisplayNameList;

    public frmLibrary()
    {
      this.FormClosing += new FormClosingEventHandler(this.Library_FormClosing);
      this.Load += new EventHandler(this.Library_Load);
      this.ResizeBegin += new EventHandler(this.Library_ResizeBegin);
      this.imageListLarge = new ImageList();
      this.ImgListOverlay = new ImageList()
      {
        ImageSize = new Size(64, 64)
      };
      this.steam_assets = Application.StartupPath + "\\SteamVRAssets";
      this.backupPath = Application.StartupPath + "\\backup";
      this.changeMade = false;
      this.steamExes = new List<string>();
      this.rs = new Resizer();
      this.isReading = false;
      this.scrapeDone = false;
      this.libraryLoaded = false;
      this.ManualStartProfiles = new Dictionary<string, string>();
      this.removeOK = false;
      this.Client = new WebClient();
      this.Steamcnn = new SQLiteConnection();
      this.Iconscnn = new SQLiteConnection();
      this.offset = 0;
      this.isSearch = false;
      this.lvShrunk = false;
      this.ShrinkSize = 0;
      this.NoIconSet = false;
      this.BrowseForIcons = false;
      this.cnn = new SQLiteConnection();
      this.IconGameList = new List<string>();
      this.DisplayNameList = new List<string>();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLibrary));
      this.ContextMenuStrip2 = new ContextMenuStrip(this.components);
      this.ReEnableAppToolStripMenuItem = new ToolStripMenuItem();
      this.ShowAppInLibraryAndProfilesToolStripMenuItem = new ToolStripMenuItem();
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem3 = new ToolStripMenuItem();
      this.ToolStripMenuItem2 = new ToolStripMenuItem();
      this.ToolStripSeparator2 = new ToolStripSeparator();
      this.ToolStripMenuItem4 = new ToolStripMenuItem();
      this.ToolStripMenuItem5 = new ToolStripMenuItem();
      this.ToolStripMenuItem6 = new ToolStripMenuItem();
      this.ToolStripSeparator3 = new ToolStripSeparator();
      this.ToolStripMenuItem7 = new ToolStripMenuItem();
      this.ToolStripMenuItem8 = new ToolStripMenuItem();
      this.ToolStripSeparator1 = new ToolStripSeparator();
      this.ToolStripMenuItem1 = new ToolStripMenuItem();
      this.ToolStripMenuItem9 = new ToolStripMenuItem();
      this.RemoveProfileToolStripMenuItem = new ToolStripMenuItem();
      this.ToolTip1 = new ToolTip(this.components);
      this.GroupBox1 = new GroupBox();
      this.TextBox1 = new TextBox();
      this.Button2 = new Button();
      this.Label6 = new Label();
      this.GroupBox2 = new GroupBox();
      this.MenuStrip1 = new MenuStrip();
      this.OptionsToolStripMenuItem = new ToolStripMenuItem();
      this.AddSteamVRToolStripMenuItem = new ToolStripMenuItem();
      this.ShowToolStripMenuItem = new ToolStripMenuItem();
      this.ShowRemoved3rdPartyAppsToolStripMenuItem = new ToolStripMenuItem();
      this.ShowIgnoredAppsToolStripMenuItem = new ToolStripMenuItem();
      this.RefreshLibraryToolStripMenuItem = new ToolStripMenuItem();
      this.SortingToolStripMenuItem = new ToolStripMenuItem();
      this.AscendingToolStripMenuItem = new ToolStripMenuItem();
      this.DescendingToolStripMenuItem = new ToolStripMenuItem();
      this.DotNetBarTabcontrol1 = new DotNetBarTabcontrol();
      this.TabPage1 = new TabPage();
      this.PicturePlay = new PictureBox();
      this.ListView1 = new ListView();
      this.ContextMenuStrip2.SuspendLayout();
      this.ContextMenuStrip1.SuspendLayout();
      this.MenuStrip1.SuspendLayout();
      this.DotNetBarTabcontrol1.SuspendLayout();
      this.TabPage1.SuspendLayout();
      ((ISupportInitialize) this.PicturePlay).BeginInit();
      this.SuspendLayout();
      this.ContextMenuStrip2.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.ReEnableAppToolStripMenuItem,
        (ToolStripItem) this.ShowAppInLibraryAndProfilesToolStripMenuItem
      });
      this.ContextMenuStrip2.Name = "ContextMenuStrip2";
      this.ContextMenuStrip2.Size = new Size(246, 48);
      this.ReEnableAppToolStripMenuItem.Enabled = false;
      this.ReEnableAppToolStripMenuItem.Name = "ReEnableAppToolStripMenuItem";
      this.ReEnableAppToolStripMenuItem.Size = new Size(245, 22);
      this.ReEnableAppToolStripMenuItem.Text = "Re-Enable App";
      this.ReEnableAppToolStripMenuItem.Visible = false;
      this.ShowAppInLibraryAndProfilesToolStripMenuItem.Name = "ShowAppInLibraryAndProfilesToolStripMenuItem";
      this.ShowAppInLibraryAndProfilesToolStripMenuItem.Size = new Size(245, 22);
      this.ShowAppInLibraryAndProfilesToolStripMenuItem.Text = "Show App in Library and Profiles";
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[13]
      {
        (ToolStripItem) this.ToolStripMenuItem3,
        (ToolStripItem) this.ToolStripMenuItem2,
        (ToolStripItem) this.ToolStripSeparator2,
        (ToolStripItem) this.ToolStripMenuItem4,
        (ToolStripItem) this.ToolStripMenuItem5,
        (ToolStripItem) this.ToolStripMenuItem6,
        (ToolStripItem) this.ToolStripSeparator3,
        (ToolStripItem) this.ToolStripMenuItem7,
        (ToolStripItem) this.ToolStripMenuItem8,
        (ToolStripItem) this.ToolStripSeparator1,
        (ToolStripItem) this.ToolStripMenuItem1,
        (ToolStripItem) this.ToolStripMenuItem9,
        (ToolStripItem) this.RemoveProfileToolStripMenuItem
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(242, 242);
      this.ToolStripMenuItem3.Image = (Image) OculusTrayTool.My.Resources.Resources.refresh_16;
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new Size(241, 22);
      this.ToolStripMenuItem3.Text = "Replace Icons";
      this.ToolStripMenuItem3.Visible = false;
      this.ToolStripMenuItem2.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_View;
      this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      this.ToolStripMenuItem2.Size = new Size(241, 22);
      this.ToolStripMenuItem2.Text = "Show Properties";
      this.ToolStripSeparator2.Name = "ToolStripSeparator2";
      this.ToolStripSeparator2.Size = new Size(238, 6);
      this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
      this.ToolStripMenuItem4.Size = new Size(241, 22);
      this.ToolStripMenuItem4.Text = "Hide App in Library";
      this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
      this.ToolStripMenuItem5.Size = new Size(241, 22);
      this.ToolStripMenuItem5.Text = "Hide App in Library and Profiles";
      this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
      this.ToolStripMenuItem6.Size = new Size(241, 22);
      this.ToolStripMenuItem6.Text = "Ignore App";
      this.ToolStripSeparator3.Name = "ToolStripSeparator3";
      this.ToolStripSeparator3.Size = new Size(238, 6);
      this.ToolStripMenuItem7.Image = (Image) componentResourceManager.GetObject("ToolStripMenuItem7.Image");
      this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
      this.ToolStripMenuItem7.Size = new Size(241, 22);
      this.ToolStripMenuItem7.Text = "Launch App";
      this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
      this.ToolStripMenuItem8.Size = new Size(241, 22);
      this.ToolStripMenuItem8.Text = "Launch App with options..";
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new Size(238, 6);
      this.ToolStripMenuItem1.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new Size(241, 22);
      this.ToolStripMenuItem1.Text = "Create Profile...";
      this.ToolStripMenuItem9.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
      this.ToolStripMenuItem9.Size = new Size(241, 22);
      this.ToolStripMenuItem9.Text = "Edit Profile...";
      this.RemoveProfileToolStripMenuItem.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Delete;
      this.RemoveProfileToolStripMenuItem.Name = "RemoveProfileToolStripMenuItem";
      this.RemoveProfileToolStripMenuItem.Size = new Size(241, 22);
      this.RemoveProfileToolStripMenuItem.Text = "Remove Profile";
      this.ToolTip1.AutoPopDelay = 10000;
      this.ToolTip1.InitialDelay = 200;
      this.ToolTip1.ReshowDelay = 100;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Location = new Point(12, 30);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(1000, 5);
      this.GroupBox1.TabIndex = 14;
      this.GroupBox1.TabStop = false;
      this.TextBox1.Location = new Point(68, 44);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(149, 20);
      this.TextBox1.TabIndex = 20;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(223, 43);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(48, 22);
      this.Button2.TabIndex = 21;
      this.Button2.Text = "Go";
      this.Button2.UseVisualStyleBackColor = true;
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label6.ForeColor = Color.DodgerBlue;
      this.Label6.Location = new Point(13, 47);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(49, 15);
      this.Label6.TabIndex = 22;
      this.Label6.Text = "Search:";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Location = new Point(12, 71);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1000, 5);
      this.GroupBox2.TabIndex = 15;
      this.GroupBox2.TabStop = false;
      this.MenuStrip1.AutoSize = false;
      this.MenuStrip1.BackColor = Color.Transparent;
      this.MenuStrip1.Dock = DockStyle.None;
      this.MenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.OptionsToolStripMenuItem,
        (ToolStripItem) this.SortingToolStripMenuItem
      });
      this.MenuStrip1.Location = new Point(9, 3);
      this.MenuStrip1.Name = "MenuStrip1";
      this.MenuStrip1.Size = new Size(152, 25);
      this.MenuStrip1.TabIndex = 33;
      this.MenuStrip1.Text = "MenuStrip1";
      this.OptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.AddSteamVRToolStripMenuItem,
        (ToolStripItem) this.ShowToolStripMenuItem,
        (ToolStripItem) this.ShowRemoved3rdPartyAppsToolStripMenuItem,
        (ToolStripItem) this.ShowIgnoredAppsToolStripMenuItem,
        (ToolStripItem) this.RefreshLibraryToolStripMenuItem
      });
      this.OptionsToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
      this.OptionsToolStripMenuItem.Size = new Size(61, 21);
      this.OptionsToolStripMenuItem.Text = "Options";
      this.AddSteamVRToolStripMenuItem.BackColor = Color.White;
      this.AddSteamVRToolStripMenuItem.Enabled = false;
      this.AddSteamVRToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.AddSteamVRToolStripMenuItem.Name = "AddSteamVRToolStripMenuItem";
      this.AddSteamVRToolStripMenuItem.Size = new Size(236, 22);
      this.AddSteamVRToolStripMenuItem.Text = "Add SteamVR";
      this.ShowToolStripMenuItem.BackColor = Color.White;
      this.ShowToolStripMenuItem.CheckOnClick = true;
      this.ShowToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
      this.ShowToolStripMenuItem.Size = new Size(236, 22);
      this.ShowToolStripMenuItem.Text = "Show Hidden 3rd Party Apps";
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.BackColor = Color.White;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.CheckOnClick = true;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Enabled = false;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Name = "ShowRemoved3rdPartyAppsToolStripMenuItem";
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Size = new Size(236, 22);
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Text = "Show Removed 3rd Party Apps";
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Visible = false;
      this.ShowIgnoredAppsToolStripMenuItem.BackColor = Color.White;
      this.ShowIgnoredAppsToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.ShowIgnoredAppsToolStripMenuItem.Name = "ShowIgnoredAppsToolStripMenuItem";
      this.ShowIgnoredAppsToolStripMenuItem.Size = new Size(236, 22);
      this.ShowIgnoredAppsToolStripMenuItem.Text = "Show Ignored Apps";
      this.RefreshLibraryToolStripMenuItem.BackColor = Color.White;
      this.RefreshLibraryToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.RefreshLibraryToolStripMenuItem.Name = "RefreshLibraryToolStripMenuItem";
      this.RefreshLibraryToolStripMenuItem.Size = new Size(236, 22);
      this.RefreshLibraryToolStripMenuItem.Text = "Refresh Library";
      this.SortingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.AscendingToolStripMenuItem,
        (ToolStripItem) this.DescendingToolStripMenuItem
      });
      this.SortingToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.SortingToolStripMenuItem.Name = "SortingToolStripMenuItem";
      this.SortingToolStripMenuItem.Size = new Size(57, 21);
      this.SortingToolStripMenuItem.Text = "Sorting";
      this.AscendingToolStripMenuItem.BackColor = Color.White;
      this.AscendingToolStripMenuItem.CheckOnClick = true;
      this.AscendingToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.AscendingToolStripMenuItem.Name = "AscendingToolStripMenuItem";
      this.AscendingToolStripMenuItem.Size = new Size(136, 22);
      this.AscendingToolStripMenuItem.Text = "Ascending";
      this.DescendingToolStripMenuItem.BackColor = Color.White;
      this.DescendingToolStripMenuItem.CheckOnClick = true;
      this.DescendingToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.DescendingToolStripMenuItem.Name = "DescendingToolStripMenuItem";
      this.DescendingToolStripMenuItem.Size = new Size(136, 22);
      this.DescendingToolStripMenuItem.Text = "Descending";
      this.DotNetBarTabcontrol1.Alignment = TabAlignment.Left;
      this.DotNetBarTabcontrol1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage1);
      this.DotNetBarTabcontrol1.ItemSize = new Size(43, 85);
      this.DotNetBarTabcontrol1.Location = new Point(12, 82);
      this.DotNetBarTabcontrol1.Multiline = true;
      this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
      this.DotNetBarTabcontrol1.SelectedIndex = 0;
      this.DotNetBarTabcontrol1.Size = new Size(1011, 488);
      this.DotNetBarTabcontrol1.SizeMode = TabSizeMode.Fixed;
      this.DotNetBarTabcontrol1.TabIndex = 24;
      this.TabPage1.BackColor = Color.White;
      this.TabPage1.Controls.Add((Control) this.PicturePlay);
      this.TabPage1.Controls.Add((Control) this.ListView1);
      this.TabPage1.Location = new Point(89, 4);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Padding = new Padding(3);
      this.TabPage1.Size = new Size(918, 480);
      this.TabPage1.TabIndex = 0;
      this.TabPage1.Text = "Library";
      this.PicturePlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.PicturePlay.BackColor = Color.Transparent;
      this.PicturePlay.BackgroundImageLayout = ImageLayout.None;
      this.PicturePlay.ContextMenuStrip = this.ContextMenuStrip1;
      this.PicturePlay.Location = new Point(683, 0);
      this.PicturePlay.Name = "PicturePlay";
      this.PicturePlay.Size = new Size(250, 90);
      this.PicturePlay.TabIndex = 1;
      this.PicturePlay.TabStop = false;
      this.PicturePlay.Visible = false;
      this.ListView1.BorderStyle = BorderStyle.None;
      this.ListView1.ContextMenuStrip = this.ContextMenuStrip2;
      this.ListView1.Dock = DockStyle.Fill;
      this.ListView1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListView1.ForeColor = Color.DodgerBlue;
      this.ListView1.HideSelection = false;
      this.ListView1.Location = new Point(3, 3);
      this.ListView1.MultiSelect = false;
      this.ListView1.Name = "ListView1";
      this.ListView1.Size = new Size(912, 474);
      this.ListView1.TabIndex = 3;
      this.ListView1.UseCompatibleStateImageBehavior = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1024, 584);
      this.Controls.Add((Control) this.MenuStrip1);
      this.Controls.Add((Control) this.DotNetBarTabcontrol1);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.TextBox1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.MenuStrip1;
      this.MinimumSize = new Size(1040, 623);
      this.Name = nameof (frmLibrary);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Game Library";
      this.ContextMenuStrip2.ResumeLayout(false);
      this.ContextMenuStrip1.ResumeLayout(false);
      this.MenuStrip1.ResumeLayout(false);
      this.MenuStrip1.PerformLayout();
      this.DotNetBarTabcontrol1.ResumeLayout(false);
      this.TabPage1.ResumeLayout(false);
      ((ISupportInitialize) this.PicturePlay).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual ListView ListView1
    {
      get => this._ListView1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.ListView1_MouseMove);
        ListView listView1_1 = this._ListView1;
        if (listView1_1 != null)
          listView1_1.MouseMove -= mouseEventHandler;
        this._ListView1 = value;
        ListView listView1_2 = this._ListView1;
        if (listView1_2 == null)
          return;
        listView1_2.MouseMove += mouseEventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolTip1")]
    internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [field: AccessedThroughProperty("ToolStripMenuItem3")]
    internal virtual ToolStripMenuItem ToolStripMenuItem3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem ToolStripMenuItem2
    {
      get => this._ToolStripMenuItem2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem2_Click);
        ToolStripMenuItem toolStripMenuItem2_1 = this._ToolStripMenuItem2;
        if (toolStripMenuItem2_1 != null)
          toolStripMenuItem2_1.Click -= eventHandler;
        this._ToolStripMenuItem2 = value;
        ToolStripMenuItem toolStripMenuItem2_2 = this._ToolStripMenuItem2;
        if (toolStripMenuItem2_2 == null)
          return;
        toolStripMenuItem2_2.Click += eventHandler;
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

    internal virtual ToolStripMenuItem ToolStripMenuItem7
    {
      get => this._ToolStripMenuItem7;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem7_Click);
        ToolStripMenuItem toolStripMenuItem7_1 = this._ToolStripMenuItem7;
        if (toolStripMenuItem7_1 != null)
          toolStripMenuItem7_1.Click -= eventHandler;
        this._ToolStripMenuItem7 = value;
        ToolStripMenuItem toolStripMenuItem7_2 = this._ToolStripMenuItem7;
        if (toolStripMenuItem7_2 == null)
          return;
        toolStripMenuItem7_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem8
    {
      get => this._ToolStripMenuItem8;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem8_Click);
        ToolStripMenuItem toolStripMenuItem8_1 = this._ToolStripMenuItem8;
        if (toolStripMenuItem8_1 != null)
          toolStripMenuItem8_1.Click -= eventHandler;
        this._ToolStripMenuItem8 = value;
        ToolStripMenuItem toolStripMenuItem8_2 = this._ToolStripMenuItem8;
        if (toolStripMenuItem8_2 == null)
          return;
        toolStripMenuItem8_2.Click += eventHandler;
      }
    }

    internal virtual PictureBox PicturePlay
    {
      get => this._PicturePlay;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.PicturePlay_MouseUp);
        PictureBox picturePlay1 = this._PicturePlay;
        if (picturePlay1 != null)
          picturePlay1.MouseUp -= mouseEventHandler;
        this._PicturePlay = value;
        PictureBox picturePlay2 = this._PicturePlay;
        if (picturePlay2 == null)
          return;
        picturePlay2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual ContextMenuStrip ContextMenuStrip2
    {
      get => this._ContextMenuStrip2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.ContextMenuStrip2_Opening);
        ContextMenuStrip contextMenuStrip2_1 = this._ContextMenuStrip2;
        if (contextMenuStrip2_1 != null)
          contextMenuStrip2_1.Opening -= cancelEventHandler;
        this._ContextMenuStrip2 = value;
        ContextMenuStrip contextMenuStrip2_2 = this._ContextMenuStrip2;
        if (contextMenuStrip2_2 == null)
          return;
        contextMenuStrip2_2.Opening += cancelEventHandler;
      }
    }

    [field: AccessedThroughProperty("ReEnableAppToolStripMenuItem")]
    internal virtual ToolStripMenuItem ReEnableAppToolStripMenuItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TextBox1
    {
      get => this._TextBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.TextBox1_KeyDown);
        TextBox textBox1_1 = this._TextBox1;
        if (textBox1_1 != null)
          textBox1_1.KeyDown -= keyEventHandler;
        this._TextBox1 = value;
        TextBox textBox1_2 = this._TextBox1;
        if (textBox1_2 == null)
          return;
        textBox1_2.KeyDown += keyEventHandler;
      }
    }

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

    [field: AccessedThroughProperty("Label6")]
    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem ToolStripMenuItem1
    {
      get => this._ToolStripMenuItem1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem1_Click);
        ToolStripMenuItem toolStripMenuItem1_1 = this._ToolStripMenuItem1;
        if (toolStripMenuItem1_1 != null)
          toolStripMenuItem1_1.Click -= eventHandler;
        this._ToolStripMenuItem1 = value;
        ToolStripMenuItem toolStripMenuItem1_2 = this._ToolStripMenuItem1;
        if (toolStripMenuItem1_2 == null)
          return;
        toolStripMenuItem1_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem9
    {
      get => this._ToolStripMenuItem9;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ToolStripMenuItem9_Click);
        ToolStripMenuItem toolStripMenuItem9_1 = this._ToolStripMenuItem9;
        if (toolStripMenuItem9_1 != null)
          toolStripMenuItem9_1.Click -= eventHandler;
        this._ToolStripMenuItem9 = value;
        ToolStripMenuItem toolStripMenuItem9_2 = this._ToolStripMenuItem9;
        if (toolStripMenuItem9_2 == null)
          return;
        toolStripMenuItem9_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ToolStripSeparator1")]
    internal virtual ToolStripSeparator ToolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ToolStripSeparator2")]
    internal virtual ToolStripSeparator ToolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("GroupBox2")]
    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem ShowAppInLibraryAndProfilesToolStripMenuItem
    {
      get => this._ShowAppInLibraryAndProfilesToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ShowAppInLibraryAndProfilesToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ShowAppInLibraryAndProfilesToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ShowAppInLibraryAndProfilesToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ShowAppInLibraryAndProfilesToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("DotNetBarTabcontrol1")]
    internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("TabPage1")]
    internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("MenuStrip1")]
    internal virtual MenuStrip MenuStrip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("OptionsToolStripMenuItem")]
    internal virtual ToolStripMenuItem OptionsToolStripMenuItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem AddSteamVRToolStripMenuItem
    {
      get => this._AddSteamVRToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AddSteamVRToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._AddSteamVRToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._AddSteamVRToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._AddSteamVRToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ShowToolStripMenuItem
    {
      get => this._ShowToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ShowToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ShowToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ShowToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ShowToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ShowRemoved3rdPartyAppsToolStripMenuItem")]
    internal virtual ToolStripMenuItem ShowRemoved3rdPartyAppsToolStripMenuItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("SortingToolStripMenuItem")]
    internal virtual ToolStripMenuItem SortingToolStripMenuItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem AscendingToolStripMenuItem
    {
      get => this._AscendingToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AscendingToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._AscendingToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._AscendingToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._AscendingToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem DescendingToolStripMenuItem
    {
      get => this._DescendingToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.DescendingToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._DescendingToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._DescendingToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._DescendingToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem RefreshLibraryToolStripMenuItem
    {
      get => this._RefreshLibraryToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.RefreshLibraryToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._RefreshLibraryToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._RefreshLibraryToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._RefreshLibraryToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ShowIgnoredAppsToolStripMenuItem
    {
      get => this._ShowIgnoredAppsToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ShowIgnoredAppsToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._ShowIgnoredAppsToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._ShowIgnoredAppsToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._ShowIgnoredAppsToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
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

    internal virtual ToolStripMenuItem RemoveProfileToolStripMenuItem
    {
      get => this._RemoveProfileToolStripMenuItem;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.RemoveProfileToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._RemoveProfileToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._RemoveProfileToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._RemoveProfileToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("Client")]
    private virtual WebClient Client { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private static string ByteArrayToString(byte[] ba)
    {
      return BitConverter.ToString(ba).Replace("-", "");
    }

    private static byte[] GetBytes(SQLiteDataReader reader)
    {
      byte[] buffer = new byte[2048];
      long fieldOffset = 0;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        long target;
        while (frmLibrary.InlineAssignHelper<long>(ref target, reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0L)
        {
          memoryStream.Write(buffer, 0, checked ((int) target));
          checked { fieldOffset += target; }
        }
        return memoryStream.ToArray();
      }
    }

    private static T InlineAssignHelper<T>(ref T target, T value)
    {
      target = value;
      return value;
    }

    public static void SetDoubleBuffering(Control control, bool value)
    {
      typeof (Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) control, (object) value, (object[]) null);
    }

    private void GetOculusLibrary(string p)
    {
      frmLibrary.SetDoubleBuffering((Control) this.ListView1, true);
      this.PicturePlay.Visible = false;
      if (Globals.dbg)
        Log.WriteToLog("Entering GetOculusLibrary");
      if (System.IO.File.Exists(Application.StartupPath + "\\data.sqlite"))
      {
        if (Globals.dbg)
          Log.WriteToLog("Opening database copy");
        try
        {
          if (this.cnn.State == ConnectionState.Closed)
          {
            this.cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
            this.cnn.Open();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Failed to open database copy: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to open database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error opening database");
          FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          ProjectData.ClearProjectError();
          return;
        }
        if (Globals.dbg)
          Log.WriteToLog("Parsing Manifests in " + p);
        SQLiteCommand sqLiteCommand = new SQLiteCommand(this.cnn);
        this.ListView1.BeginUpdate();
        string[] files = Directory.GetFiles(p, "*.mini");
        int index1 = 0;
        while (index1 < files.Length)
        {
          string path = files[index1];
          JObject jobject = JObject.Parse(System.IO.File.ReadAllText(path));
          string str1 = p.Replace("\\Manifests", "") + "\\Software";
          string str2 = jobject.SelectToken("canonicalName").ToString();
          string Left = jobject.SelectToken("appId").ToString();
          string str3 = str1 + "\\" + str2 + "\\" + jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
          string str4 = MySettingsProperty.Settings.OculusPath.TrimEnd('\\') + "\\CoreData\\Software\\StoreAssets\\" + str2 + "_assets";
          string str5 = str4 + "\\small_landscape_image.jpg";
          if (!System.IO.File.Exists(str5))
          {
            Log.WriteToLog("Could not find game icon '" + str5 + "', looking in the other library paths");
            string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
            int index2 = 0;
            while (index2 < strArray.Length)
            {
              str4 = strArray[index2].TrimEnd('\\') + "\\Software\\StoreAssets\\" + str2 + "_assets";
              str5 = str4 + "\\small_landscape_image.jpg";
              if (System.IO.File.Exists(str5))
              {
                Log.WriteToLog("Found game icon at '" + str5 + "'");
                break;
              }
              checked { ++index2; }
            }
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "", false) != 0)
          {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
              sqLiteCommand.CommandText = "Select value from Objects WHERE hashkey='" + Left + "' AND typename='Application'";
              using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
              {
                if (reader.HasRows)
                {
                  while (reader.Read())
                  {
                    byte[] bytes = frmLibrary.GetBytes(reader);
                    stringBuilder.Append(Encoding.Default.GetString(bytes));
                  }
                }
                else
                  goto label_44;
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Exception exception = ex;
              Log.WriteToLog("Failed to read database entry for appId '" + Left + "': " + exception.Message);
              FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + Left + "': " + exception.Message);
              MyProject.Forms.FrmMain.hasError = true;
              ProjectData.ClearProjectError();
              return;
            }
            string str6 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
            string str7 = "display:name::";
            string str8 = Conversions.ToInteger(MyProject.Forms.FrmMain.OculusAppVersion) < 118 ? ":grouping" : ":display:short:description";
            int num1 = str6.IndexOf(str7);
            int num2 = str6.IndexOf(str8);
            if (num1 > -1 && num2 > -1)
            {
              string str9 = Strings.Mid(str6, checked (num1 + str7.Length + 1), checked (num2 - num1 - str7.Length)).Replace(":", " ").TrimEnd(':').TrimEnd(' ');
              string text = str9.Remove(checked (str9.Length - 1));
              if (this.ListView1.FindItemWithText(text) == null)
              {
                if (System.IO.File.Exists(str5))
                {
                  using (Image image = Image.FromFile(str5))
                    this.imageListLarge.Images.Add(str3, image);
                }
                else
                  this.imageListLarge.Images.Add(str3, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
                this.ListView1.Items.Add(new ListViewItem(text, str3)
                {
                  Tag = (object) (Path.GetFileName(str3) + "," + str4 + "," + path.Replace(".mini", "") + "," + str3),
                  ForeColor = !(this.ManualStartProfiles.ContainsKey(str3) | this.ManualStartProfiles.ContainsKey(str3.ToLower())) ? (!this.DisplayNameList.Contains(text.ToLower()) ? Color.Red : Color.Blue) : Color.Green
                });
                if (!this.IconGameList.Contains(text))
                  this.IconGameList.Add(text);
              }
            }
          }
label_44:
          checked { ++index1; }
        }
        this.ListView1.Sorting = SortOrder.Ascending;
        this.ListView1.Sort();
        this.ListView1.EndUpdate();
        sqLiteCommand.Dispose();
        this.cnn.Close();
        if (Globals.dbg)
          Log.WriteToLog("Connection closed");
        if (Globals.dbg)
          Log.WriteToLog("Exiting GetOculusLibrary");
      }
    }

    private void GetThirdPartyApps(string p)
    {
      int num1;
      int num2;
      try
      {
label_2:
        int num3 = 1;
        if (!Globals.dbg)
          goto label_4;
label_3:
        num3 = 2;
        Log.WriteToLog("Entering GetThirdPartyApps");
label_4:
        num3 = 3;
        List<string> steamGameList = new List<string>();
label_5:
        num3 = 4;
        this.PicturePlay.Visible = false;
label_6:
        num3 = 5;
        this.ListView1.BeginUpdate();
label_7:
        num3 = 6;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MyProject.Forms.FrmMain.SteamPath, "", false) == 0)
          goto label_32;
label_8:
        num3 = 7;
        string path1 = Path.Combine(MyProject.Forms.FrmMain.SteamPath, "config\\steamapps.vrmanifest");
label_9:
        num3 = 8;
        if (System.IO.File.Exists(path1))
          goto label_11;
label_10:
        num3 = 9;
        Log.WriteToLog("Could not locate Steam VR manifest");
        goto label_31;
label_11:
        num3 = 11;
        Log.WriteToLog("Found Steam VR manifest: " + path1);
label_12:
        num3 = 12;
        string json1 = System.IO.File.ReadAllText(path1);
label_13:
        num3 = 13;
        JObject jobject1 = JObject.Parse(json1);
label_14:
        num3 = 14;
        JToken jtoken = jobject1.SelectToken("applications");
label_15:
        num3 = 15;
        IEnumerator<JToken> enumerator1 = ((IEnumerable<JToken>) jtoken).GetEnumerator();
        goto label_27;
label_17:
        num3 = 16;
label_18:
        num3 = 17;
        JToken current1;
        current1[(object) "app_key"].ToString();
label_19:
        num3 = 18;
        string str = current1[(object) "strings"][(object) "en_us"][(object) "name"].ToString();
label_20:
        num3 = 19;
        if (steamGameList.Contains(str))
          goto label_25;
label_21:
        num3 = 20;
        steamGameList.Add(str);
label_22:
        num3 = 21;
        if (!Globals.dbg)
          goto label_24;
label_23:
        num3 = 22;
        Log.WriteToLog("GetThirdPartyLibraryApps: Steam game '" + str + "' added to list");
label_24:
label_25:
label_26:
        num3 = 24;
label_27:
        if (enumerator1.MoveNext())
        {
          current1 = enumerator1.Current;
          goto label_17;
        }
label_28:
        num3 = 25;
        enumerator1?.Dispose();
label_30:
label_31:
label_32:
label_33:
        num3 = 28;
        string[] files = Directory.GetFiles(p, "*.json");
        int index = 0;
        goto label_116;
label_35:
        ProjectData.ClearProjectError();
        num1 = -2;
label_36:
        num3 = 30;
        string path2;
        if (path2.Contains("_assets.json"))
          goto label_115;
label_37:
        num3 = 32;
        if (!Globals.dbg)
          goto label_39;
label_38:
        num3 = 33;
        Log.WriteToLog("Opening " + path2);
label_39:
        num3 = 34;
        string json2 = System.IO.File.ReadAllText(path2);
label_40:
        num3 = 35;
        JObject jobject2 = JObject.Parse(json2);
label_41:
        num3 = 36;
        bool flag = (bool) jobject2.SelectToken("thirdParty");
label_42:
        num3 = 37;
        string canonName = jobject2.SelectToken("canonicalName").ToString();
label_43:
        num3 = 38;
        List<JToken> list = jobject2.Children().ToList<JToken>();
label_44:
        num3 = 39;
        List<JToken>.Enumerator enumerator2 = list.GetEnumerator();
        goto label_54;
label_46:
        num3 = 40;
        JProperty current2;
        current2.CreateReader();
label_47:
        num3 = 41;
        string name = current2.Name;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "displayName", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "launchFile", false) == 0)
            goto label_50;
          else
            goto label_52;
        }
label_49:
        num3 = 43;
        string DisplayName = current2.Value.ToString();
        goto label_52;
label_50:
        num3 = 45;
        string fullpath = current2.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
label_51:
        num3 = 46;
        string fileName = Path.GetFileName(current2.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
        goto label_55;
label_52:
label_53:
        num3 = 49;
label_54:
        if (enumerator2.MoveNext())
        {
          current2 = (JProperty) enumerator2.Current;
          goto label_46;
        }
label_55:
        num3 = 50;
        enumerator2.Dispose();
label_56:
        num3 = 51;
        if (flag)
          goto label_59;
label_57:
        num3 = 52;
        if (!Globals.dbg)
          goto label_115;
label_58:
        num3 = 53;
        Log.WriteToLog("'" + DisplayName + "' is not thirdParty, ignoring for now");
        goto label_115;
label_59:
label_60:
        num3 = 56;
        if (!steamGameList.Contains(DisplayName))
          goto label_64;
label_61:
        num3 = 57;
        if (!Globals.dbg)
          goto label_63;
label_62:
        num3 = 58;
        Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + DisplayName + "' to Library view");
label_63:
        num3 = 59;
        this.AddThirdPartyGameToLibrary(p, steamGameList, canonName, DisplayName, fileName, fullpath);
        goto label_115;
label_64:
        num3 = 61;
        Log.WriteToLog("'" + DisplayName + "' not found in Steam game list, getting info from the Oculus Database");
label_65:
        num3 = 62;
        StringBuilder stringBuilder = new StringBuilder();
label_66:
        num3 = 63;
        if (this.cnn.State != ConnectionState.Closed)
          goto label_70;
label_67:
        num3 = 64;
        this.cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
label_68:
        num3 = 65;
        this.cnn.Open();
label_69:
label_70:
label_71:
        num3 = 67;
        SQLiteCommand sqLiteCommand = new SQLiteCommand(this.cnn);
label_72:
        num3 = 68;
        sqLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + canonName + "_LocalAppState' AND typename='LocalApplicationState'";
label_73:
        num3 = 69;
        using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
        {
          while (reader.Read())
          {
            byte[] bytes = frmLibrary.GetBytes(reader);
            stringBuilder.Append(Encoding.Default.GetString(bytes));
          }
        }
label_80:
        num3 = 70;
        if (!stringBuilder.ToString().Contains("FLAT"))
          goto label_83;
label_81:
        num3 = 71;
        if (!Globals.dbg)
          goto label_115;
label_82:
        num3 = 72;
        Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
        goto label_115;
label_83:
label_84:
        num3 = 75;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(stringBuilder.ToString(), "", false) == 0)
          goto label_89;
label_85:
        num3 = 76;
        if (!Globals.dbg)
          goto label_87;
label_86:
        num3 = 77;
        Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + DisplayName + "' to Library view");
label_87:
        num3 = 78;
        this.AddThirdPartyGameToLibrary(p, steamGameList, canonName, DisplayName, fileName, fullpath);
label_88:
label_89:
label_90:
        num3 = 80;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(stringBuilder.ToString(), "", false) != 0)
          goto label_109;
label_91:
        num3 = 81;
        if (!Globals.dbg)
          goto label_93;
label_92:
        num3 = 82;
        Log.WriteToLog("GetThirdPartyLibraryApps:  -> Not found, looking for secondary entry: " + canonName + ": UserAppPlayTime");
label_93:
        num3 = 83;
        sqLiteCommand.CommandText = "select value from Objects WHERE hashkey LIKE \"%" + canonName + "%\" AND typename='UserAppPlayTime'";
label_94:
        num3 = 84;
        using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (Globals.dbg)
              Log.WriteToLog("GetThirdPartyLibraryApps:  -> Found entry for " + canonName + ": UserAppPlayTime");
            if (Globals.dbg)
              Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + DisplayName + "' to Library view");
            this.AddThirdPartyGameToLibrary(p, steamGameList, canonName, DisplayName, fileName, fullpath);
          }
          else if (!MyProject.Forms.FrmMain.includedApps.Contains(path2))
          {
            if (Globals.dbg)
            {
              Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
              goto label_115;
            }
            else
              goto label_115;
          }
          else
            this.AddThirdPartyGameToLibrary(p, steamGameList, canonName, DisplayName, fileName, fullpath);
        }
label_108:
label_109:
label_110:
        num3 = 86;
        sqLiteCommand.Dispose();
label_111:
        num3 = 87;
        this.cnn.Close();
label_112:
        num3 = 88;
        if (!Globals.dbg)
          goto label_114;
label_113:
        num3 = 89;
        Log.WriteToLog("Connection closed");
label_114:
label_115:
        num3 = 91;
        checked { ++index; }
label_116:
        if (index < files.Length)
        {
          path2 = files[index];
          goto label_35;
        }
label_117:
        num3 = 92;
        this.ListView1.EndUpdate();
label_118:
        num3 = 93;
        if (this.cnn.State != ConnectionState.Open)
          goto label_123;
label_119:
        num3 = 94;
        this.cnn.Close();
label_120:
        num3 = 95;
        if (!Globals.dbg)
          goto label_122;
label_121:
        num3 = 96;
        Log.WriteToLog("Connection closed");
label_122:
label_123:
label_124:
        num3 = 98;
        if (!Globals.dbg)
          goto label_132;
label_125:
        num3 = 99;
        Log.WriteToLog("Exiting GetThirdPartyApps");
        goto label_132;
label_127:
        num2 = num3;
        switch (num1 > -2 ? num1 : 1)
        {
          case 1:
            int num4 = num2 + 1;
            num2 = 0;
            switch (num4)
            {
              case 1:
                goto label_2;
              case 2:
                goto label_3;
              case 3:
                goto label_4;
              case 4:
                goto label_5;
              case 5:
                goto label_6;
              case 6:
                goto label_7;
              case 7:
                goto label_8;
              case 8:
                goto label_9;
              case 9:
                goto label_10;
              case 10:
              case 27:
                goto label_31;
              case 11:
                goto label_11;
              case 12:
                goto label_12;
              case 13:
                goto label_13;
              case 14:
                goto label_14;
              case 15:
                goto label_15;
              case 16:
                goto label_17;
              case 17:
                goto label_18;
              case 18:
                goto label_19;
              case 19:
                goto label_20;
              case 20:
                goto label_21;
              case 21:
                goto label_22;
              case 22:
                goto label_23;
              case 23:
                goto label_24;
              case 24:
                goto label_26;
              case 25:
                goto label_28;
              case 26:
                goto label_30;
              case 28:
                goto label_33;
              case 29:
                goto label_35;
              case 30:
                goto label_36;
              case 31:
              case 54:
              case 60:
              case 73:
              case 91:
                goto label_115;
              case 32:
                goto label_37;
              case 33:
                goto label_38;
              case 34:
                goto label_39;
              case 35:
                goto label_40;
              case 36:
                goto label_41;
              case 37:
                goto label_42;
              case 38:
                goto label_43;
              case 39:
                goto label_44;
              case 40:
                goto label_46;
              case 41:
                goto label_47;
              case 42:
              case 44:
              case 48:
                goto label_52;
              case 43:
                goto label_49;
              case 45:
                goto label_50;
              case 46:
                goto label_51;
              case 47:
              case 50:
                goto label_55;
              case 49:
                goto label_53;
              case 51:
                goto label_56;
              case 52:
                goto label_57;
              case 53:
                goto label_58;
              case 55:
                goto label_59;
              case 56:
                goto label_60;
              case 57:
                goto label_61;
              case 58:
                goto label_62;
              case 59:
                goto label_63;
              case 61:
                goto label_64;
              case 62:
                goto label_65;
              case 63:
                goto label_66;
              case 64:
                goto label_67;
              case 65:
                goto label_68;
              case 66:
                goto label_69;
              case 67:
                goto label_71;
              case 68:
                goto label_72;
              case 69:
                goto label_73;
              case 70:
                goto label_80;
              case 71:
                goto label_81;
              case 72:
                goto label_82;
              case 74:
                goto label_83;
              case 75:
                goto label_84;
              case 76:
                goto label_85;
              case 77:
                goto label_86;
              case 78:
                goto label_87;
              case 79:
                goto label_88;
              case 80:
                goto label_90;
              case 81:
                goto label_91;
              case 82:
                goto label_92;
              case 83:
                goto label_93;
              case 84:
                goto label_94;
              case 85:
                goto label_108;
              case 86:
                goto label_110;
              case 87:
                goto label_111;
              case 88:
                goto label_112;
              case 89:
                goto label_113;
              case 90:
                goto label_114;
              case 92:
                goto label_117;
              case 93:
                goto label_118;
              case 94:
                goto label_119;
              case 95:
                goto label_120;
              case 96:
                goto label_121;
              case 97:
                goto label_122;
              case 98:
                goto label_124;
              case 99:
                goto label_125;
              case 100:
                goto label_132;
            }
            break;
        }
      }
      catch (Exception ex) when (ex is Exception & num1 != 0 & num2 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_127;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_132:
      if (num2 == 0)
        return;
      ProjectData.ClearProjectError();
    }

    private void AddThirdPartyGameToLibrary(
      string p,
      List<string> steamGameList,
      string canonName,
      string DisplayName,
      string LaunchFile,
      string fullpath)
    {
      try
      {
        if (this.IconGameList.Contains(DisplayName))
        {
          if (!Globals.dbg)
            return;
          Log.WriteToLog("AddThirdPartyGameToLibrary: '" + DisplayName + "' has already been added to the library, skipping");
        }
        else
        {
          bool flag = false;
          string str1 = p + "\\" + canonName + ".json";
          string str2 = MySettingsProperty.Settings.OculusPath.TrimEnd('\\') + "\\CoreData\\Software\\StoreAssets\\" + canonName + "_assets";
          string str3 = str2 + "\\small_landscape_image.jpg";
          if (System.IO.File.Exists(str3))
          {
            flag = true;
            if (Globals.dbg)
              Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + str3);
          }
          else
          {
            string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
            int index = 0;
            while (index < strArray.Length)
            {
              str2 = strArray[index].TrimEnd('\\') + "\\Software\\StoreAssets\\" + canonName + "_assets";
              str3 = str2 + "\\small_landscape_image.jpg";
              if (System.IO.File.Exists(str3))
              {
                flag = true;
                if (Globals.dbg)
                {
                  Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + str3);
                  break;
                }
                break;
              }
              checked { ++index; }
            }
          }
          if (!flag)
          {
            Log.WriteToLog("Could not locate local icon for '" + DisplayName + "'");
            str3 = "Default Unknown";
          }
          if (DisplayName.ToLower().EndsWith(".exe") | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(DisplayName.ToLower(), "unknown app", false) == 0)
            DisplayName = Path.GetFileNameWithoutExtension(LaunchFile);
          if (Globals.dbg)
          {
            Log.WriteToLog("    App is thirdParty");
            Log.WriteToLog("    DisplayName: '" + DisplayName + "'");
            Log.WriteToLog("    LaunchFile: '" + LaunchFile + "'");
            Log.WriteToLog("    FullPath: '" + fullpath + "'");
            Log.WriteToLog("    assetsPath: '" + str2 + "'");
            Log.WriteToLog("    iconFile: '" + str3 + "'");
          }
          string str4 = Path.GetFileName(LaunchFile) + "," + str2 + "," + str1 + ",3rdParty," + LaunchFile;
          if (!OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Library") & !OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both"))
          {
            if (Globals.dbg)
              Log.WriteToLog("    Hidden: False");
            if (System.IO.File.Exists(str3))
            {
              using (Image image = Image.FromFile(str3))
              {
                if (Globals.dbg)
                  Log.WriteToLog("AddThirdPartyGameToLibrary: Adding '" + DisplayName + "' (" + LaunchFile + ") to library with '" + str3 + "'");
                this.imageListLarge.Images.Add(LaunchFile, image);
              }
            }
            else
            {
              if (Globals.dbg)
                Log.WriteToLog("AddThirdPartyGameToLibrary: Adding '" + DisplayName + "' (" + LaunchFile + ") to library with [???] icon");
              this.imageListLarge.Images.Add(LaunchFile, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
            }
            this.ListView1.Items.Add(new ListViewItem(DisplayName, LaunchFile)
            {
              Tag = (object) str4,
              ForeColor = !(this.ManualStartProfiles.ContainsKey(fullpath) | this.ManualStartProfiles.ContainsKey(fullpath.ToLower())) ? (!this.DisplayNameList.Contains(DisplayName.ToLower()) ? Color.Red : Color.Blue) : Color.Green
            });
            if (!this.IconGameList.Contains(DisplayName))
              this.IconGameList.Add(DisplayName);
          }
          else if (Globals.dbg)
            Log.WriteToLog("    Hidden: True");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddThirdPartyGameToLibrary: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void Library_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.changeMade && Process.GetProcessesByName("OculusClient").Length > 0)
      {
        int num = (int) Interaction.MsgBox((object) "You may need to restart oculus Home to see the new icons in VR.", MsgBoxStyle.Information, (object) "Oculus Tray Tool");
      }
      MySettingsProperty.Settings.LibraryWindowLocation = this.Location;
      MySettingsProperty.Settings.LibraryWindowSize = this.Size;
      MySettingsProperty.Settings.Save();
      if (e.CloseReason != CloseReason.UserClosing)
        return;
      e.Cancel = true;
      this.Hide();
    }

    private void Library_Load(object sender, EventArgs e) => this.LoadLibrary();

    public void LoadLibrary()
    {
      Control.CheckForIllegalCrossThreadCalls = false;
      Log.WriteToLog("Opening Library");
      this.changeMade = false;
      if (MySettingsProperty.Settings.LibraryWindowLocation != new Point())
      {
        if (Globals.dbg)
          Log.WriteToLog("Setting Library GUI location to " + MySettingsProperty.Settings.LibraryWindowLocation.ToString());
        this.Location = MySettingsProperty.Settings.LibraryWindowLocation;
      }
      else
      {
        this.CenterToScreen();
        MySettingsProperty.Settings.LibraryWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      Point location = this.Location;
      int num1 = location.X < 0 ? 1 : 0;
      location = this.Location;
      int num2 = location.Y < 0 ? 1 : 0;
      if ((num1 | num2) != 0)
      {
        if (Globals.dbg)
          Log.WriteToLog("Library GUI location has negative number, adjusting");
        this.CenterToScreen();
        MySettingsProperty.Settings.LibraryWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      this.Size = MySettingsProperty.Settings.LibraryWindowSize;
      this.rs.FindAllControls((Control) this);
      this.rs.ResizeAllControls((Control) this, (float) MyProject.Forms.FrmMain.TrackBar1.Value);
      this.imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
      this.ImgListOverlay.ColorDepth = ColorDepth.Depth32Bit;
      this.ImgListOverlay.Images.Add((Image) OculusTrayTool.My.Resources.Resources.play2);
      this.PicturePlay.Visible = false;
      frmLibrary.icons.Images.Clear();
      frmLibrary.icons.ColorDepth = ColorDepth.Depth32Bit;
      frmLibrary.icons.ImageSize = new Size(250, 90);
      if (!this.libraryLoaded)
      {
        Log.WriteToLog("Library not loaded");
        this.PopulateList();
      }
      else if (Globals.dbg)
        Log.WriteToLog("Library already loaded, proceeding");
    }

    private object GenerateSHA256Hash(string filename)
    {
      using (FileStream inputStream = System.IO.File.OpenRead(filename))
        return (object) BitConverter.ToString(new SHA256Managed().ComputeHash((Stream) inputStream)).Replace("-", string.Empty).ToLower();
    }

    public void PopulateList()
    {
      this.Cursor = Cursors.WaitCursor;
      if (Globals.dbg)
        Log.WriteToLog("Loading Library view");
      this.PicturePlay.Visible = false;
      this.ListView1.Items.Clear();
      this.imageListLarge.Images.Clear();
      this.imageListLarge.ImageSize = new Size(250, 90);
      this.ListView1.LargeImageList = this.imageListLarge;
      this.ListView1.View = View.LargeIcon;
      this.ContextMenuStrip1.Visible = true;
      this.ContextMenuStrip1.Close();
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
        this.GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
        this.GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
        this.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0)
      {
        string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
        int index = 0;
        while (index < strArray.Length)
        {
          string str = strArray[index];
          if (Directory.Exists(str.TrimEnd('\\') + "\\Manifests"))
            this.GetOculusLibrary(str.TrimEnd('\\') + "\\Manifests");
          if (Directory.Exists(str.TrimEnd('\\') + "\\CoreData\\Manifests"))
            this.GetThirdPartyApps(str.TrimEnd('\\') + "\\CoreData\\Manifests");
          checked { ++index; }
        }
      }
      MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
      MyProject.Forms.frmProfiles.GameList.Clear();
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
        GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
        GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
        GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0)
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
      this.libraryLoaded = true;
      this.Cursor = Cursors.Default;
    }

    private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count == 0)
        return;
      if (this.ListView1.SelectedItems.Count > 0 & this.PicturePlay.Visible)
      {
        if (this.ListView1.SelectedItems[0].ForeColor == Color.Red)
        {
          this.ToolStripMenuItem1.Visible = true;
          this.ToolStripMenuItem9.Visible = false;
          this.RemoveProfileToolStripMenuItem.Visible = false;
        }
        if (this.ListView1.SelectedItems[0].ForeColor == Color.Green)
        {
          this.ToolStripMenuItem1.Visible = false;
          this.ToolStripMenuItem9.Visible = true;
          this.RemoveProfileToolStripMenuItem.Visible = true;
        }
        if (Conversions.ToBoolean(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
        {
          (object) "3rdParty"
        }, (string[]) null, (Type[]) null, (bool[]) null)))
        {
          this.ToolStripMenuItem2.Visible = true;
          this.ToolStripMenuItem4.Visible = true;
          this.ToolStripMenuItem5.Visible = true;
          this.ToolStripMenuItem7.Visible = true;
          this.ToolStripMenuItem8.Visible = true;
        }
        else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
        {
          (object) "hidden"
        }, (string[]) null, (Type[]) null, (bool[]) null))))
        {
          this.ToolStripMenuItem2.Visible = true;
          this.ToolStripMenuItem4.Visible = false;
          this.ToolStripMenuItem5.Visible = false;
          this.ToolStripMenuItem7.Visible = true;
          this.ToolStripMenuItem8.Visible = true;
        }
        if (!this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked)
          return;
        this.ToolStripMenuItem2.Visible = false;
        this.ToolStripMenuItem4.Visible = false;
        this.ToolStripMenuItem5.Visible = false;
        this.ToolStripMenuItem7.Visible = false;
        this.ToolStripMenuItem8.Visible = false;
      }
      else
      {
        this.ToolStripMenuItem1.Visible = false;
        this.ToolStripMenuItem2.Visible = false;
        this.ToolStripMenuItem4.Visible = false;
        this.ToolStripMenuItem5.Visible = false;
        this.ToolStripMenuItem7.Visible = false;
        this.ToolStripMenuItem8.Visible = false;
      }
    }

    private void CreateManifest(
      string canonicalName,
      string displayName,
      string files,
      string launchFile,
      string path)
    {
      StringWriter stringWriter = new StringWriter(new StringBuilder());
      using (JsonWriter jsonWriter = (JsonWriter) new JsonTextWriter((TextWriter) stringWriter))
      {
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName(nameof (canonicalName));
        jsonWriter.WriteValue(canonicalName);
        jsonWriter.WritePropertyName(nameof (displayName));
        jsonWriter.WriteValue(displayName);
        jsonWriter.WritePropertyName(nameof (files));
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName(files);
        jsonWriter.WriteValue("");
        jsonWriter.WriteEndObject();
        jsonWriter.WritePropertyName("firewallExceptionsRequired");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName("isCore");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName(nameof (launchFile));
        jsonWriter.WriteValue(launchFile);
        jsonWriter.WritePropertyName("launchParameters");
        jsonWriter.WriteValue("");
        jsonWriter.WritePropertyName("manifestVersion");
        jsonWriter.WriteValue(0);
        jsonWriter.WritePropertyName("packageType");
        jsonWriter.WriteValue("APP");
        jsonWriter.WritePropertyName("thirdParty");
        jsonWriter.WriteValue(true);
        jsonWriter.WritePropertyName("version");
        jsonWriter.WriteValue("1");
        jsonWriter.WritePropertyName("versionCode");
        jsonWriter.WriteValue(1);
        jsonWriter.WriteEndObject();
      }
      StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
      streamWriter.Write((object) stringWriter);
      streamWriter.Close();
    }

    private void CreateAssetManifest(
      string canonicalName,
      string color,
      Dictionary<string, string> files,
      string parameters,
      string path)
    {
      StringWriter stringWriter = new StringWriter(new StringBuilder());
      using (JsonWriter jsonWriter = (JsonWriter) new JsonTextWriter((TextWriter) stringWriter))
      {
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("dominantColor");
        jsonWriter.WriteValue(color);
        jsonWriter.WritePropertyName(nameof (files));
        jsonWriter.WriteStartObject();
        try
        {
          foreach (KeyValuePair<string, string> file in files)
          {
            jsonWriter.WritePropertyName(file.Key);
            jsonWriter.WriteValue(file.Value);
          }
        }
        finally
        {
          Dictionary<string, string>.Enumerator enumerator;
          enumerator.Dispose();
        }
        jsonWriter.WriteEndObject();
        jsonWriter.WritePropertyName("packageType");
        jsonWriter.WriteValue("ASSET_BUNDLE");
        jsonWriter.WritePropertyName("isCore");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName("appId");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName(nameof (canonicalName));
        jsonWriter.WriteValue(canonicalName);
        jsonWriter.WritePropertyName("launchFile");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("launchParameters");
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(parameters, "", false) == 0)
          jsonWriter.WriteNull();
        else
          jsonWriter.WriteValue(parameters);
        jsonWriter.WritePropertyName("launchFile2D");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("launchParameters2D");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("version");
        jsonWriter.WriteValue("1");
        jsonWriter.WritePropertyName("versionCode");
        jsonWriter.WriteValue(1);
        jsonWriter.WritePropertyName("redistributables");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("firewallExceptionsRequired");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName("thirdParty");
        jsonWriter.WriteValue(true);
        jsonWriter.WritePropertyName("manifestVersion");
        jsonWriter.WriteValue(0);
        jsonWriter.WriteEndObject();
      }
      StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
      streamWriter.Write((object) stringWriter);
      streamWriter.Close();
    }

    private void ToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      if (!System.IO.File.Exists(strArray[2]))
        return;
      MyProject.Forms.frmProperties.RichTextBox1.Text = JToken.Parse(System.IO.File.ReadAllText(strArray[2])).ToString(Formatting.Indented);
      MyProject.Forms.frmProperties.TextBox1.Text = strArray[2];
      MyProject.Forms.frmProperties.fname = strArray[2];
      this.rs.FindAllControls((Control) MyProject.Forms.frmProperties);
      this.rs.ResizeAllControls((Control) MyProject.Forms.frmProperties, (float) MyProject.Forms.FrmMain.TrackBar1.Value);
      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
      {
        (object) "3rdParty"
      }, (string[]) null, (Type[]) null, (bool[]) null))))
        MyProject.Forms.frmProperties.Button1.Enabled = false;
      else
        MyProject.Forms.frmProperties.Button1.Enabled = true;
      int num = (int) MyProject.Forms.frmProperties.ShowDialog();
    }

    private void ToolStripMenuItem4_Click(object sender, EventArgs e)
    {
      OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",")[0], "Library");
      this.PopulateList();
    }

    private void ToolStripMenuItem5_Click(object sender, EventArgs e)
    {
      OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",")[0], "Both");
      this.PopulateList();
    }

    private void ToolStripMenuItem7_Click(object sender, EventArgs e) => this.LaunchApp();

    private void LaunchApp()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
        if (!System.IO.File.Exists(strArray[2]))
          return;
        string str1 = "";
        string str2 = "";
        List<string> stringList = new List<string>();
        List<string> appInfo = this.GetAppInfo(strArray[2], "");
        int num1 = checked (appInfo.Count - 1);
        int num2 = 0;
        while (num2 <= num1)
        {
          str1 = appInfo[0];
          str2 = appInfo[1];
          checked { ++num2; }
        }
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", false) != 0 & System.IO.File.Exists(str1))
        {
          MyProject.Forms.FrmMain.ManualStart = true;
          if (!MyProject.Forms.FrmMain.HomeIsRunning)
          {
            RunCommand.StartHome();
            Thread.Sleep(3000);
          }
          if (this.ManualStartProfiles.ContainsKey(str1.ToLower()))
          {
            Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(str1));
            this.ApplyProfile(str1.TrimStart().TrimEnd());
          }
          else
            Log.WriteToLog("No profile found for '" + str1 + "'");
          Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", false) != 0)
            Log.WriteToLog(" -> " + str1.TrimStart().TrimEnd() + " " + str2.TrimStart().TrimEnd());
          else
            Log.WriteToLog(" -> " + str1.TrimStart().TrimEnd());
          this.Cursor = Cursors.Default;
          Process.Start(str1, str2);
          if (Globals.dbg)
            Log.WriteToLog("Adding Worker AppWatchWorker");
          BackgroundWorker backgroundWorker = new BackgroundWorker();
          backgroundWorker.DoWork += new DoWorkEventHandler(MyProject.Forms.FrmMain.AppWork);
          backgroundWorker.RunWorkerAsync();
          if (Globals.dbg)
            Log.WriteToLog("Worker started");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("LaunchApp(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void ApplyProfile(string appName)
    {
      string ss = "";
      try
      {
        if (!this.ManualStartProfiles.TryGetValue(appName.ToLower(), out ss))
          return;
        new Thread((ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool(ss))).Start();
        string Left1 = "";
        if (MyProject.Forms.FrmMain.profileAGPS.TryGetValue(MyProject.Forms.FrmMain.runningApp.ToLower(), out Left1))
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "0", false) == 0)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (frmLibrary._Closure\u0024__.\u0024I209\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = frmLibrary._Closure\u0024__.\u0024I209\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmLibrary._Closure\u0024__.\u0024I209\u002D1 = start = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_agps("false"));
            }
            new Thread(start).Start();
          }
          else
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (frmLibrary._Closure\u0024__.\u0024I209\u002D2 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = frmLibrary._Closure\u0024__.\u0024I209\u002D2;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmLibrary._Closure\u0024__.\u0024I209\u002D2 = start = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_agps("true"));
            }
            new Thread(start).Start();
          }
        }
        if (MySettingsProperty.Settings.VoiceConfirmProfile)
        {
          ThreadStart start;
          // ISSUE: reference to a compiler-generated field
          if (frmLibrary._Closure\u0024__.\u0024I209\u002D3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            start = frmLibrary._Closure\u0024__.\u0024I209\u002D3;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            frmLibrary._Closure\u0024__.\u0024I209\u002D3 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav"));
          }
          new Thread(start).Start();
        }
        if (GetConfig.SetRiftDefault)
        {
          if (MySettingsProperty.Settings.SetRiftAudioDefault == 2)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (frmLibrary._Closure\u0024__.\u0024I209\u002D4 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = frmLibrary._Closure\u0024__.\u0024I209\u002D4;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmLibrary._Closure\u0024__.\u0024I209\u002D4 = start = (ThreadStart) ([SpecialName] () => AudioSwitcher.SetDefaultAudioDeviceOnStart(false));
            }
            new Thread(start).Start();
          }
          if (MySettingsProperty.Settings.SetRiftMicDefault == 2)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (frmLibrary._Closure\u0024__.\u0024I209\u002D5 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = frmLibrary._Closure\u0024__.\u0024I209\u002D5;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmLibrary._Closure\u0024__.\u0024I209\u002D5 = start = (ThreadStart) ([SpecialName] () => AudioSwitcher.SetDefaultMicDeviceOnStart());
            }
            new Thread(start).Start();
          }
        }
        MyProject.Forms.FrmMain.runningApp = appName;
        string displayName = OTTDB.GetDisplayName(appName);
        MyProject.Forms.FrmMain.runningapp_displayname = OTTDB.GetDisplayName(appName);
        Log.WriteToLog("Manual game launch detected: " + displayName + " (" + appName + ")");
        Log.WriteToLog(displayName + ": Super Sampling @ " + ss);
        if (Globals.dbg)
          Log.WriteToLog(MyProject.Forms.FrmMain.runningApp + ": Super Sampling @ " + ss);
        FrmMain.fmain.AddToListboxAndScroll("Game launch detected: " + displayName);
        string str1 = "";
        if (MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str1))
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = (double) checked (Conversions.ToInteger(str1) * 1000);
          timer.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyCpuPrioTick);
          timer.Start();
          Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + str1 + " seconds");
          FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + str1 + " seconds");
        }
        string str2 = "";
        if (MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str2))
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = (double) checked (Conversions.ToInteger(str2) * 1000);
          timer.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyAswTick);
          timer.Start();
          Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str2 + " seconds");
          FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str2 + " seconds");
        }
        string Left2 = "";
        if (MyProject.Forms.FrmMain.profileMirror.TryGetValue(MyProject.Forms.FrmMain.runningApp, out Left2) && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "1", false) == 0)
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = 2000.0;
          timer.Elapsed += new ElapsedEventHandler(FrmMain.fmain.ApplyMirrorTick);
          timer.Start();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ApplyProfile(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private List<string> GetAppInfo(string jFile, string customParms)
    {
      List<string> appInfo;
      try
      {
        List<string> stringList = new List<string>();
        string str1 = "";
        JObject jobject = (JObject) JToken.Parse(System.IO.File.ReadAllText(jFile));
        string str2 = (string) jobject.SelectToken("canonicalName");
        string str3 = ((string) jobject.SelectToken("launchFile")).Replace("/", "\\").Replace("\\\\", "\\");
        string str4 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(customParms, "", false) != 0 ? customParms : (string) jobject.SelectToken("launchParameters");
        if (this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
          str1 = str3.Replace("/", "\\").Replace("\\\\", "\\");
        if (!this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
        {
          string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
          int index = 0;
          while (index < strArray.Length)
          {
            string str5 = strArray[index];
            if (System.IO.File.Exists(str5 + "\\Software\\" + str2 + "\\" + str3))
            {
              str1 = str5 + "\\Software\\" + str2 + "\\" + str3;
              break;
            }
            checked { ++index; }
          }
        }
        stringList.Add(str1);
        stringList.Add(str4);
        appInfo = stringList;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetAppInfo(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return appInfo;
    }

    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if (this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked || this.ShowToolStripMenuItem.Checked || this.ListView1.Items.Count == 0)
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
        {
          itemAt.Selected = true;
          itemAt.EnsureVisible();
          ListViewHitTestInfo listViewHitTestInfo = this.ListView1.HitTest(e.X, e.Y);
          PictureBox picturePlay1 = this.PicturePlay;
          int left1 = this.ListView1.Left;
          Rectangle bounds = listViewHitTestInfo.Item.Bounds;
          int left2 = bounds.Left;
          int num1 = checked (left1 + left2 + 21);
          picturePlay1.Left = num1;
          PictureBox picturePlay2 = this.PicturePlay;
          int top1 = this.ListView1.Top;
          bounds = listViewHitTestInfo.Item.Bounds;
          int top2 = bounds.Top;
          int num2 = checked (top1 + top2 + 2);
          picturePlay2.Top = num2;
          string[] source = Strings.Split(Conversions.ToString(itemAt.Tag), ",");
          this.PicturePlay.Image = this.CreateOverlay(this.imageListLarge.Images[source[checked (((IEnumerable<string>) source).Count<string>() - 1)]]);
          this.PicturePlay.Visible = true;
          this.PicturePlay.Select();
        }
        else
          this.PicturePlay.Visible = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private Image CreateOverlay(Image im)
    {
      int width1 = this.ImgListOverlay.Images[0].Width;
      int height1 = this.ImgListOverlay.Images[0].Height;
      Bitmap bitmap = new Bitmap(width1, height1);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        graphics.DrawImage(this.ImgListOverlay.Images[0], 0, 0, width1, height1);
      bitmap.MakeTransparent(Color.Red);
      int width2 = im.Width;
      int height2 = im.Height;
      Bitmap overlay = new Bitmap(width2, height2);
      int x = checked (width2 - width1) / 2;
      int y = checked (height2 - height1) / 2;
      using (Graphics graphics = Graphics.FromImage((Image) overlay))
      {
        graphics.DrawImage(im, 0, 0, width2, height2);
        graphics.DrawImage((Image) bitmap, x, y, width1, height1);
      }
      this.PicturePlay.Image = (Image) overlay;
      bitmap.Dispose();
      return (Image) overlay;
    }

    private void ToolStripMenuItem8_Click(object sender, EventArgs e)
    {
      string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      if (System.IO.File.Exists(strArray[2]))
      {
        string str1 = "";
        string str2 = "";
        List<string> stringList = new List<string>();
        List<string> appInfo = this.GetAppInfo(strArray[2], "");
        int num1 = checked (appInfo.Count - 1);
        int num2 = 0;
        while (num2 <= num1)
        {
          str1 = appInfo[0];
          str2 = appInfo[1];
          checked { ++num2; }
        }
        MyProject.Forms.frmLaunchOptions.TextBox1.Text = str2;
        int num3 = (int) MyProject.Forms.frmLaunchOptions.ShowDialog();
        if (MyProject.Forms.frmLaunchOptions.optionsCanceled || !(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", false) != 0 & System.IO.File.Exists(str1)))
          return;
        MyProject.Forms.FrmMain.ManualStart = true;
        Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
        Log.WriteToLog(" -> " + str1.TrimStart().TrimEnd() + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text.TrimStart().TrimEnd());
        this.ApplyProfile(str1.TrimStart().TrimEnd());
        Process.Start(str1, MyProject.Forms.frmLaunchOptions.TextBox1.Text);
        MyProject.Forms.frmLaunchOptions.Close();
      }
    }

    private void PicturePlay_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count <= 0 || e.Button != MouseButtons.Left)
        return;
      this.LaunchApp();
    }

    private void ContextMenuStrip2_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count == 0 || this.ListView1.SelectedItems.Count <= 0)
        return;
      if (Conversions.ToBoolean(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
      {
        (object) "hidden"
      }, (string[]) null, (Type[]) null, (bool[]) null)))
        this.ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = true;
      else
        this.ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = false;
    }

    private void Button2_Click(object sender, EventArgs e) => this.SearchForApp();

    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SearchForApp();
    }

    private void SearchForApp()
    {
      if (this.DotNetBarTabcontrol1.SelectedIndex != 0)
        return;
      ListViewItem itemWithText = this.ListView1.FindItemWithText(this.TextBox1.Text);
      if (itemWithText != null)
      {
        itemWithText.Selected = true;
        this.ListView1.Focus();
        this.ListView1.SelectedItems[0].EnsureVisible();
      }
    }

    private void ToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      frmCreateEditProfile createEditProfile = new frmCreateEditProfile();
      string str = !this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty") ? strArray[3] : JObject.Parse(System.IO.File.ReadAllText(strArray[2])).SelectToken("launchFile").ToString();
      createEditProfile.TextDisplayName.Text = this.ListView1.SelectedItems[0].Text;
      createEditProfile.ComboSS.Text = "0";
      createEditProfile.ComboASW.Text = "Auto";
      createEditProfile.ComboCPU.Text = "Normal";
      createEditProfile.ComboMethod.Text = "WMI";
      createEditProfile.pLaunchfile = strArray[0].Replace("\\\\", "\\").Replace("/", "\\");
      createEditProfile.pPath = str.Replace("\\\\", "\\").Replace("/", "\\");
      createEditProfile.TextBoxPath.Text = str.Replace("\\\\", "\\").Replace("/", "\\");
      createEditProfile.NumericUpDown1.Value = 5M;
      createEditProfile.NumericUpDown2.Value = 5M;
      createEditProfile.ComboMirror.SelectedIndex = 0;
      createEditProfile.ComboAGPS.SelectedIndex = 1;
      createEditProfile.Button1.Enabled = true;
      int num = (int) createEditProfile.ShowDialog((IWin32Window) this);
      if (createEditProfile.CreateCancel)
        return;
      this.PicturePlay.Visible = false;
      this.PopulateList();
    }

    private void ToolStripMenuItem9_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.ListView1.SelectedItems.Count == 0)
          return;
        if (Globals.dbg)
          Log.WriteToLog("Editing Profile: '" + this.ListView1.SelectedItems[0].Text + "'");
        if (Globals.dbg)
          Log.WriteToLog(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) " Tag: ", this.ListView1.SelectedItems[0].Tag)));
        string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
        if (Globals.dbg)
          Log.WriteToLog(" Reading " + strArray[2].Replace("\\\\", "\\").Replace("/", "\\"));
        string str1 = JObject.Parse(System.IO.File.ReadAllText(strArray[2].Replace("\\\\", "\\").Replace("/", "\\"))).SelectToken("launchFile").ToString();
        if (Globals.dbg)
          Log.WriteToLog(" Json Launchfile: " + str1);
        string str2 = strArray[3];
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "3rdParty", false) == 0)
          str2 = str1.Replace("\\\\", "\\").Replace("/", "\\");
        if (Globals.dbg)
          Log.WriteToLog(" Path: " + str2);
        if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(str2, out str1))
          str1 = str2;
        string str3 = str1.Replace("\\\\", "\\").Replace("/", "\\");
        if (Globals.dbg)
          Log.WriteToLog(" Launchfile: " + str3);
        frmCreateEditProfile createEditProfile = new frmCreateEditProfile();
        string str4 = "";
        string str5 = "";
        string str6 = "";
        string str7 = "";
        string str8 = "";
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        if (this.ManualStartProfiles.TryGetValue(str3.ToLower(), out str6))
          createEditProfile.ComboSS.Text = str6;
        if (MyProject.Forms.FrmMain.profileASWList.TryGetValue(str3, out str5))
          createEditProfile.ComboASW.Text = str5;
        if (MyProject.Forms.FrmMain.profileDisplayNames.TryGetValue(str3, out str4))
          createEditProfile.TextDisplayName.Text = str4;
        if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(str3, out str8))
          createEditProfile.ComboCPU.Text = str8;
        createEditProfile.ComboMethod.Text = !MyProject.Forms.FrmMain.profileTimerList.TryGetValue(str3, out str7) ? "WMI" : "Timer";
        Dictionary<string, string> profileAswDelay = MyProject.Forms.FrmMain.profileAswDelay;
        string key1 = str3;
        string str9 = Conversions.ToString(num1);
        ref string local1 = ref str9;
        int num5 = profileAswDelay.TryGetValue(key1, out local1) ? 1 : 0;
        int integer1 = Conversions.ToInteger(str9);
        if (num5 != 0)
          createEditProfile.NumericUpDown1.Value = new Decimal(integer1);
        Dictionary<string, string> profileCpuDelay = MyProject.Forms.FrmMain.profileCpuDelay;
        string key2 = str3;
        string str10 = Conversions.ToString(num2);
        ref string local2 = ref str10;
        int num6 = profileCpuDelay.TryGetValue(key2, out local2) ? 1 : 0;
        int integer2 = Conversions.ToInteger(str10);
        if (num6 != 0)
          createEditProfile.NumericUpDown2.Value = new Decimal(integer2);
        Dictionary<string, string> profileMirror = MyProject.Forms.FrmMain.profileMirror;
        string lower1 = str3.ToLower();
        str10 = Conversions.ToString(num3);
        ref string local3 = ref str10;
        if (profileMirror.TryGetValue(lower1, out local3))
          createEditProfile.ComboMirror.SelectedIndex = num3;
        Dictionary<string, string> profileAgps = MyProject.Forms.FrmMain.profileAGPS;
        string lower2 = str3.ToLower();
        str10 = Conversions.ToString(num4);
        ref string local4 = ref str10;
        if (profileAgps.TryGetValue(lower2, out local4))
          createEditProfile.ComboAGPS.SelectedIndex = num4;
        createEditProfile.pLaunchfile = Path.GetFileName(str3);
        createEditProfile.pPath = str3;
        createEditProfile.TextBoxPath.Text = str3;
        createEditProfile.Button1.Enabled = true;
        int num7 = (int) createEditProfile.ShowDialog((IWin32Window) this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("Could not edit profile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
    {
      this.ContextMenuStrip1.Close();
      this.ListView1.Focus();
    }

    private void Library_ResizeBegin(object sender, EventArgs e)
    {
      this.PicturePlay.Visible = false;
    }

    private void ShowAppInLibraryAndProfilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OTTDB.UnHideApp(this.ListView1.SelectedItems[0].Text);
      this.ShowToolStripMenuItem.Checked = false;
      this.PopulateList();
    }

    public void ImagelistAddItem(string name, Image img)
    {
      try
      {
        frmLibrary.icons.Images.Add(name, img);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private int GetCount(SQLiteConnection sqConnection, string Table)
    {
      return (int) Convert.ToInt16(RuntimeHelpers.GetObjectValue(new SQLiteCommand("SELECT COUNT(*) From " + Table, sqConnection).ExecuteScalar()));
    }

    public void ClearListview(ListView lv)
    {
      if (lv.InvokeRequired)
      {
        frmLibrary.ClearListview_delegate method = new frmLibrary.ClearListview_delegate(this.ClearListview);
        lv.BeginInvoke((Delegate) method, (object) lv);
      }
      else
        lv.Items.Clear();
    }

    private void AddSteamVRToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MyProject.Forms.FrmMain.steamvr, "", false) == 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Could not locate Steam VR path", MsgBoxStyle.Critical, (object) "Error");
      }
      else
      {
        string canonicalName = MyProject.Forms.FrmMain.steamvr.Replace(" ", "").Replace("\\", "_").Replace(":", "") + "bin_win32_assets";
        string path = MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Software\\StoreAssets\\" + canonicalName;
        Dictionary<string, string> files1 = new Dictionary<string, string>();
        if (!Directory.Exists(path))
        {
          Log.WriteToLog("Creating " + path);
          Directory.CreateDirectory(path);
        }
        try
        {
          string[] files2 = Directory.GetFiles(this.steam_assets);
          int index = 0;
          while (index < files2.Length)
          {
            string str1 = files2[index];
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(str1), ".bat", false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(str1), ".exe", false) != 0)
            {
              Log.WriteToLog("Copying " + Path.GetFileName(str1) + " -> " + path);
              System.IO.File.Copy(str1, path + "\\" + Path.GetFileName(str1), true);
              Log.WriteToLog("Generating hash for " + Path.GetFileName(str1));
              string str2 = Conversions.ToString(this.GenerateSHA256Hash(str1));
              files1.Add(Path.GetFileName(str1), str2);
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(str1), ".bat", false) == 0)
              System.IO.File.Copy(str1, MyProject.Forms.FrmMain.steamvr + Path.GetFileName(str1), true);
            checked { ++index; }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Exception occurred when copying files: " + exception.Message);
          int num2 = (int) Interaction.MsgBox((object) ("Exception occurred when copying files: " + exception.Message));
          ProjectData.ClearProjectError();
          return;
        }
        this.CreateManifest(canonicalName.Replace("_assets", ""), "SteamVR", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
        this.CreateAssetManifest(canonicalName, "#060404", files1, "", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
        this.PopulateList();
        if (Interaction.MsgBox((object) "You need to restart the Oculus Service for SteamVR to be visible in Oculus Home. Restart it now?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object) "Restart Required") == MsgBoxResult.Yes)
        {
          MyProject.Forms.FrmMain.StopOVR();
          MyProject.Forms.FrmMain.StartOVR();
        }
      }
    }

    private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.ShowToolStripMenuItem.Checked)
      {
        this.PicturePlay.Visible = false;
        this.isReading = true;
        this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked = false;
        this.isReading = false;
        this.ListView1.Items.Clear();
        this.imageListLarge.Images.Clear();
        this.imageListLarge.ImageSize = new Size(250, 90);
        this.ListView1.LargeImageList = this.imageListLarge;
        this.ListView1.View = View.LargeIcon;
        try
        {
          foreach (object hiddenApp in (IEnumerable) OTTDB.GetHiddenApps())
          {
            string str = Conversions.ToString(hiddenApp);
            this.imageListLarge.Images.Add(str, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
            this.ListView1.Items.Add(new ListViewItem(str, str)
            {
              Tag = (object) (str + ",hidden")
            });
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      else
        this.RefreshLibrary();
    }

    private void AscendingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.AscendingToolStripMenuItem.Checked)
        return;
      this.DescendingToolStripMenuItem.Checked = false;
      this.ListView1.Sorting = this.DotNetBarTabcontrol1.SelectedIndex != 0 ? SortOrder.None : SortOrder.Ascending;
    }

    private void DescendingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.DescendingToolStripMenuItem.Checked)
        return;
      this.AscendingToolStripMenuItem.Checked = false;
      this.ListView1.Sorting = this.DotNetBarTabcontrol1.SelectedIndex != 0 ? SortOrder.None : SortOrder.Descending;
    }

    private void RefreshLibraryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.RefreshLibrary();
    }

    private void RefreshLibrary()
    {
      Log.WriteToLog("Refreshing Library");
      try
      {
        if (this.cnn.State == ConnectionState.Open)
          this.cnn.Close();
        if (System.IO.File.Exists(Application.StartupPath + "\\data.sqlite"))
        {
          System.IO.File.Delete(Application.StartupPath + "\\data.sqlite");
          if (Globals.dbg)
            Log.WriteToLog("Database copy deleted");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Failed to delete database copy: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Failed to delete database copy: " + exception.Message));
        FrmMain.fmain.AddToListboxAndScroll("Failed to delete database copy: " + exception.Message);
        MyProject.Forms.FrmMain.hasError = true;
        ProjectData.ClearProjectError();
        return;
      }
      if (Globals.dbg)
        Log.WriteToLog("Looking for Oculus database");
      if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite"))
      {
        if (Globals.dbg)
          Log.WriteToLog("Database found, making a copy");
        try
        {
          System.IO.File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Failed to create database copy: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to create database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error copying database");
          FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          ProjectData.ClearProjectError();
          return;
        }
      }
      this.IconGameList.Clear();
      this.libraryLoaded = false;
      this.LoadLibrary();
    }

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData.ToString());
    }

    private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData.ToString());
    }

    private void ShowIgnoredAppsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.FrmIgnoredApps.ShowDialog((IWin32Window) this);
    }

    private void ToolStripMenuItem6_Click(object sender, EventArgs e)
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      string str = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",")[2];
      string text = this.ListView1.SelectedItems[0].Text;
      OTTDB.AddIgnoreApp(str);
      OTTDB.RemoveIncludedApp(str);
      MyProject.Forms.FrmMain.ignoredApps = (List<string>) OTTDB.GetIgnoredApps();
      MyProject.Forms.FrmMain.includedApps = (List<string>) OTTDB.GetIncludedApps();
      MyProject.Forms.FrmMain.ignoredApps.Add(str);
      this.PopulateList();
      Log.WriteToLog("'" + text + "' is now being ignored");
      MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + text + "' is now being ignored");
    }

    private void RemoveProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.DeleteProfile();
    }

    private void DeleteProfile()
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      ListViewItem selectedItem = this.ListView1.SelectedItems[0];
      string[] strArray = Strings.Split(Conversions.ToString(selectedItem.Tag), ",");
      if (Globals.dbg)
        Log.WriteToLog(" Reading " + strArray[2].Replace("\\\\", "\\").Replace("/", "\\"));
      string str1 = JObject.Parse(System.IO.File.ReadAllText(strArray[2].Replace("\\\\", "\\").Replace("/", "\\"))).SelectToken("launchFile").ToString();
      if (Globals.dbg)
        Log.WriteToLog(" Json Launchfile: " + str1);
      string str2 = strArray[3];
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "3rdParty", false) == 0)
        str2 = str1.Replace("\\\\", "\\").Replace("/", "\\");
      if (Globals.dbg)
        Log.WriteToLog(" Path: " + str2);
      if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(str2, out str1))
        str1 = str2;
      string Path = str1.Replace("\\\\", "\\").Replace("/", "\\");
      if (Interaction.MsgBox((object) ("Remove profile for '" + selectedItem.Text + "'?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Confirm") == MsgBoxResult.Yes)
      {
        OTTDB.RemoveProfile(Path);
        OTTDB.GetProfiles();
        if (OTTDB.numWMI > 0)
          MyProject.Forms.FrmMain.CreateWatcher();
        if (OTTDB.numTimer > 0)
          MyProject.Forms.FrmMain.pTimer.Start();
      }
      MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
      this.PopulateList();
    }

    public delegate void ImagelistAddItem_delegate(string name, Image img);

    public delegate void ListViewAddItemSteam_delegate(string name, string tag);

    public delegate void ClearListview_delegate(ListView lv);
  }
}
