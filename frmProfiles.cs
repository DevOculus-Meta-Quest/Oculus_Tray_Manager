
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
  public partial class frmProfiles : Form
  {
    
    private Resizer rs;
    private int sortColumn;
    private string ProfileToFind;
    public int selectedItem;
    public Dictionary<string, string> GameList;
    private CheckBox cck;




    public frmProfiles()
    {
      this.FormClosing += this.scan_FormClosing;
      this.Load += this.scan_Load;
      this.rs = new Resizer();
      this.sortColumn = -1;
      this.GameList = new Dictionary<string, string>();
      this.InitializeComponent();
    }

    

    

    


    

    

    

    



    

    




    

    





    

    

    


    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    


    

    

    

    

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
      
      GetConfig.IsReading = true;
      try
      {
          this.CheckVoiceConfirm.Checked = MySettingsProperty.Settings.VoiceConfirmProfile;
          if (!string.IsNullOrEmpty(MySettingsProperty.Settings.DesktopResolution))
          {
               this.ComboResolution.SelectedItem = MySettingsProperty.Settings.DesktopResolution;
               if (this.ComboResolution.SelectedIndex == -1) this.ComboResolution.Text = MySettingsProperty.Settings.DesktopResolution;
          }
      }
      finally
      {
          GetConfig.IsReading = false;
      }

      this.Show();
      OTTDB.GetProfiles();
      this.ComboResolution.Focus();
    }

    private bool FindItem(
      ListView.ListViewItemCollection ItemList,
      int ColumnIndex,
      string SearchString)
    {
        foreach (ListViewItem listViewItem in ItemList)
        {
          if (Operators.CompareString(listViewItem.SubItems[ColumnIndex].Text, SearchString, false) == 0)
            return true;
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
        foreach (ListViewItem checkedItem in this.ListView1.CheckedItems)
          checkedItem.Checked = false;
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
        MyProject.Forms.frmCreateEditProfile.ComboAGPS.Text = FrmMain.fmain.ComboBox5.Text;
        MyProject.Forms.frmCreateEditProfile.NumericUpDown3.Value = FrmMain.fmain.NumericFOVh.Value;
        MyProject.Forms.frmCreateEditProfile.NumericUpDown4.Value = FrmMain.fmain.NumericFOVv.Value;
        MyProject.Forms.frmCreateEditProfile.ComboBox8.Text = FrmMain.fmain.ComboBox8.Text;
        MyProject.Forms.frmCreateEditProfile.ComboBox9.Text = FrmMain.fmain.ComboBox9.Text;
        MyProject.Forms.frmCreateEditProfile.ComboBoxEnabled.Text = "Yes";
          foreach (KeyValuePair<string, string> game in MyProject.Forms.frmProfiles.GameList)
            MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Add((object) new frmCreateEditProfile.GameItem(game.Key, game.Value));
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
        foreach (ListViewItem listViewItem in this.ListView1.Items)
        {
          if (listViewItem != itemAt)
            listViewItem.Selected = false;
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
        new Thread(() => RunCommand.Run_debug_tool(ss)).Start();
        string Left = "";
        if (MyProject.Forms.FrmMain.profileAGPS.TryGetValue(appName.ToLower(), out Left))
        {
          if (Operators.CompareString(Left, "0", false) == 0)
          {
            new Thread(() => RunCommand.Run_debug_tool_agps("false")).Start();
          }
          else
          {
            new Thread(() => RunCommand.Run_debug_tool_agps("true")).Start();
          }
        }
        if (MySettingsProperty.Settings.VoiceConfirmProfile)
        {
          new Thread(() => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav")).Start();
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
            foreach (ListViewItem listViewItem in this.ListView1.Items)
              listViewItem.Checked = true;
        }
        else if (!this.cck.Checked)
        {
            foreach (ListViewItem listViewItem in this.ListView1.Items)
              listViewItem.Checked = false;
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