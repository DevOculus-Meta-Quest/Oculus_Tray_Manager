

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
namespace OculusTrayTool.Forms
{

  public partial class frmLibrary : Form
  {
    
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
    private ListView _ListView1;
    private ToolTip _ToolTip1;
    private ContextMenuStrip _ContextMenuStrip1;
    private ToolStripMenuItem _ToolStripMenuItem3;
    private ToolStripMenuItem _ToolStripMenuItem2;
    private ToolStripMenuItem _ToolStripMenuItem4;
    private ToolStripMenuItem _ToolStripMenuItem7;
    private ToolStripMenuItem _ToolStripMenuItem8;
    private PictureBox _PicturePlay;
    private ContextMenuStrip _ContextMenuStrip2;
    private ToolStripMenuItem _ReEnableAppToolStripMenuItem;
    private GroupBox _GroupBox1;
    private TextBox _TextBox1;
    private Button _Button2;
    private Label _Label6;
    private ToolStripMenuItem _ToolStripMenuItem1;
    private ToolStripMenuItem _ToolStripMenuItem9;
    private ToolStripSeparator _ToolStripSeparator1;
    private ToolStripSeparator _ToolStripSeparator2;
    private GroupBox _GroupBox2;
    private ToolStripMenuItem _ShowAppInLibraryAndProfilesToolStripMenuItem;
    private DotNetBarTabcontrol _DotNetBarTabcontrol1;
    private TabPage _TabPage1;
    private MenuStrip _MenuStrip1;
    private ToolStripMenuItem _OptionsToolStripMenuItem;
    private ToolStripMenuItem _AddSteamVRToolStripMenuItem;
    private ToolStripMenuItem _ShowToolStripMenuItem;
    private ToolStripMenuItem _ShowRemoved3rdPartyAppsToolStripMenuItem;
    private ToolStripMenuItem _SortingToolStripMenuItem;
    private ToolStripMenuItem _AscendingToolStripMenuItem;
    private ToolStripMenuItem _DescendingToolStripMenuItem;
    private ToolStripMenuItem _RefreshLibraryToolStripMenuItem;
    private ToolStripMenuItem _ShowIgnoredAppsToolStripMenuItem;
    private ToolStripMenuItem _ToolStripMenuItem5;
    private ToolStripMenuItem _ToolStripMenuItem6;
    private ToolStripSeparator _ToolStripSeparator3;
    private ToolStripMenuItem _RemoveProfileToolStripMenuItem;

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

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    [field: AccessedThroughProperty("Client")]
    private WebClient Client { get; set; }

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
        long target = 0L;
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

          Exception exception = ex;
          Log.WriteToLog("Failed to open database copy: " + exception.Message);
          MessageBox.Show("Failed to open database copy: " + exception.Message, "Error opening database", MessageBoxButtons.OK, MessageBoxIcon.Error);
          FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;

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
            string[] strArray = Convert.ToString(MySettingsProperty.Settings.LibraryPath).Split(',');
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
          if (!String.Equals(Left, "", StringComparison.OrdinalIgnoreCase))
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
    
              Exception exception = ex;
              Log.WriteToLog("Failed to read database entry for appId '" + Left + "': " + exception.Message);
              FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + Left + "': " + exception.Message);
              MyProject.Forms.FrmMain.hasError = true;
    
              return;
            }
            string str6 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
            string str7 = "display:name::";
            string str8 = Convert.ToInt32(MyProject.Forms.FrmMain.OculusAppVersion) < 118 ? ":grouping" : ":display:short:description";
            int num1 = str6.IndexOf(str7);
            int num2 = str6.IndexOf(str8);
            if (num1 > -1 && num2 > -1)
            {
              string str9 = str6.Substring(checked (num1 + str7.Length), checked (num2 - num1 - str7.Length)).Replace(":", " ").TrimEnd(':').TrimEnd(' ');
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
      if (Globals.dbg)
        Log.WriteToLog("Entering GetThirdPartyApps");
      
      List<string> steamGameList = new List<string>();
      PicturePlay.Visible = false;
      ListView1.BeginUpdate();

      if (!string.IsNullOrEmpty(MyProject.Forms.FrmMain.SteamPath))
      {
        string path = Path.Combine(MyProject.Forms.FrmMain.SteamPath, "config\\steamapps.vrmanifest");
        if (System.IO.File.Exists(path))
        {
          if (Globals.dbg) Log.WriteToLog("Found Steam VR manifest: " + path);
          try
          {
            string json = System.IO.File.ReadAllText(path);
            JObject jobject = JObject.Parse(json);
            JToken applications = jobject["applications"];
            if (applications != null)
            {
              foreach (JToken app in applications)
              {
                string name = app["strings"]?["en_us"]?["name"]?.ToString();
                if (!string.IsNullOrEmpty(name) && !steamGameList.Contains(name))
                {
                  steamGameList.Add(name);
                  if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Steam game '" + name + "' added to list");
                }
              }
            }
          }
          catch (Exception ex)
          {
            Log.WriteToLog("Error parsing Steam VR manifest: " + ex.Message);
          }
        }
        else
        {
          Log.WriteToLog("Could not locate Steam VR manifest");
        }
      }

      try
      {
        string[] files = Directory.GetFiles(p, "*.json");
        foreach (string file in files)
        {
          try
          {
            if (file.Contains("_assets.json")) continue;

            if (Globals.dbg) Log.WriteToLog("Opening " + file);
            string json = System.IO.File.ReadAllText(file);
            JObject jobject = JObject.Parse(json);

            bool isThirdParty = (bool?)jobject["thirdParty"] ?? false;
            string canonName = (string)jobject["canonicalName"];
            string displayName = (string)jobject["displayName"];
            string launchFile = (string)jobject["launchFile"];
            string fullPath = launchFile?.Replace("\\\\", "\\").Replace("/", "\\");
            string fileName = fullPath != null ? Path.GetFileName(fullPath) : null;

            if (!isThirdParty)
            {
              if (Globals.dbg) Log.WriteToLog("'" + displayName + "' is not thirdParty, ignoring for now");
              continue;
            }

            if (steamGameList.Contains(displayName))
            {
              if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + displayName + "' to Library view");
              AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
            }
            else
            {
              Log.WriteToLog("'" + displayName + "' not found in Steam game list, getting info from the Oculus Database");
              
              if (cnn.State == ConnectionState.Closed)
              {
                cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
                cnn.Open();
              }

              StringBuilder sb = new StringBuilder();
              using (SQLiteCommand cmd = new SQLiteCommand(cnn))
              {
                cmd.CommandText = "select value from Objects WHERE hashkey='" + canonName + "_LocalAppState' AND typename='LocalApplicationState'";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                  while (reader.Read())
                  {
                    byte[] bytes = GetBytes(reader);
                    sb.Append(Encoding.Default.GetString(bytes));
                  }
                }

                string dbContent = sb.ToString();
                if (dbContent.Contains("FLAT"))
                {
                  if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
                }
                else if (!string.IsNullOrEmpty(dbContent))
                {
                   if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + displayName + "' to Library view");
                   AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
                }
                else
                {
                   if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> Not found, looking for secondary entry: " + canonName + ": UserAppPlayTime");
                   cmd.CommandText = "select value from Objects WHERE hashkey LIKE \"%" + canonName + "%\" AND typename='UserAppPlayTime'";
                   using (SQLiteDataReader reader2 = cmd.ExecuteReader())
                   {
                     if (reader2.HasRows)
                     {
                       if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> Found entry for " + canonName + ": UserAppPlayTime");
                       if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + displayName + "' to Library view");
                       AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
                     }
                     else if (MyProject.Forms.FrmMain.includedApps.Contains(file))
                     {
                        AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
                     }
                     else
                     {
                        if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
                     }
                   }
                }
              }
              if (cnn.State == ConnectionState.Open) cnn.Close();
            }
          }
          catch (Exception ex)
          {
  
            Log.WriteToLog("Error processing file " + file + ": " + ex.Message);
  
          }
        }
      }
      catch (Exception ex)
      {
         // ProjectData.SetProjectError(ex);
         Log.WriteToLog("Error in GetThirdPartyApps: " + ex.Message);
         // ProjectData.ClearProjectError();
      }

      ListView1.EndUpdate();
      if (cnn.State == ConnectionState.Open) cnn.Close();
      if (Globals.dbg) Log.WriteToLog("Exiting GetThirdPartyApps");
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
            string[] strArray = Convert.ToString(MySettingsProperty.Settings.LibraryPath).Split(',');
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
          if (DisplayName.ToLower().EndsWith(".exe") | String.Equals(DisplayName, "unknown app", StringComparison.OrdinalIgnoreCase))
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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddThirdPartyGameToLibrary: " + ex.Message);
        // ProjectData.ClearProjectError();
      }
    }

    private void Library_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.changeMade && Process.GetProcessesByName("OculusClient").Length > 0)
      {
        MessageBox.Show("You may need to restart oculus Home to see the new icons in VR.", "Oculus Tray Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      if (String.Equals(MySettingsProperty.Settings.LibraryPath, "", StringComparison.OrdinalIgnoreCase))
      {
        string[] strArray = Convert.ToString(MySettingsProperty.Settings.LibraryPath).Split(',');
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
      GetGames.GameList.Clear();
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
        GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
        GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
        GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
      if (String.Equals(MySettingsProperty.Settings.LibraryPath, "", StringComparison.OrdinalIgnoreCase))
      {
        string[] strArray = Convert.ToString(MySettingsProperty.Settings.LibraryPath).Split(',');
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
if (Convert.ToString(this.ListView1.SelectedItems[0].Tag).Contains("3rdParty"))
        {
          this.ToolStripMenuItem2.Visible = true;
          this.ToolStripMenuItem4.Visible = true;
          this.ToolStripMenuItem5.Visible = true;
          this.ToolStripMenuItem7.Visible = true;
          this.ToolStripMenuItem8.Visible = true;
        }
else if (Convert.ToString(this.ListView1.SelectedItems[0].Tag).Contains("hidden"))
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
          foreach (KeyValuePair<string, string> file in files)
          {
            jsonWriter.WritePropertyName(file.Key);
            jsonWriter.WriteValue(file.Value);
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
        if (String.Equals(parameters, "", StringComparison.OrdinalIgnoreCase))
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
      string[] strArray = Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',');
      if (!System.IO.File.Exists(strArray[2]))
        return;
      MyProject.Forms.frmProperties.RichTextBox1.Text = JToken.Parse(System.IO.File.ReadAllText(strArray[2])).ToString(Formatting.Indented);
      MyProject.Forms.frmProperties.TextBox1.Text = strArray[2];
      MyProject.Forms.frmProperties.fname = strArray[2];
      this.rs.FindAllControls((Control) MyProject.Forms.frmProperties);
      this.rs.ResizeAllControls((Control) MyProject.Forms.frmProperties, (float) MyProject.Forms.FrmMain.TrackBar1.Value);
if (Convert.ToString(this.ListView1.SelectedItems[0].Tag).Contains("3rdParty"))
        MyProject.Forms.frmProperties.Button1.Enabled = false;
      else
        MyProject.Forms.frmProperties.Button1.Enabled = true;
      int num = (int) MyProject.Forms.frmProperties.ShowDialog();
    }

    private void ToolStripMenuItem4_Click(object sender, EventArgs e)
    {
      OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',')[0], "Library");
      this.PopulateList();
    }

    private void ToolStripMenuItem5_Click(object sender, EventArgs e)
    {
      OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',')[0], "Both");
      this.PopulateList();
    }

    private void ToolStripMenuItem7_Click(object sender, EventArgs e) => this.LaunchApp();

    private void LaunchApp()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        string[] strArray = Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',');
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
        if (!String.Equals(str1, "", StringComparison.OrdinalIgnoreCase) & System.IO.File.Exists(str1))
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
          if (!String.Equals(str2, "", StringComparison.OrdinalIgnoreCase))
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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("LaunchApp(): " + ex.Message);
        // ProjectData.ClearProjectError();
      }
    }

    private void ApplyProfile(string appName)
    {
      string ss = "";
      string displayName = appName;
      try
      {
        if (!this.ManualStartProfiles.TryGetValue(appName.ToLower(), out ss))
          return;
        new Thread((ThreadStart) (() => RunCommand.Run_debug_tool(ss))).Start();
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
          timer.Interval = (double) checked (Convert.ToInt32(str1) * 1000);
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
          timer.Interval = (double) checked (Convert.ToInt32(str2) * 1000);
          timer.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyAswTick);
          timer.Start();
          Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str2 + " seconds");
          FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str2 + " seconds");
        }
        string Left2 = "";
        if (MyProject.Forms.FrmMain.profileMirror.TryGetValue(MyProject.Forms.FrmMain.runningApp, out Left2) && String.Equals(Left2, "1", StringComparison.OrdinalIgnoreCase))
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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("ApplyProfile(): " + ex.Message);
        // ProjectData.ClearProjectError();
      }
    }

    private List<string> GetAppInfo(string jFile, string customParms)
    {
      List<string> appInfo = null;
      try
      {
        List<string> stringList = new List<string>();
        string str1 = "";
        JObject jobject = (JObject) JToken.Parse(System.IO.File.ReadAllText(jFile));
        string str2 = (string) jobject.SelectToken("canonicalName");
        string str3 = ((string) jobject.SelectToken("launchFile")).Replace("/", "\\").Replace("\\\\", "\\");
        string str4 = !String.Equals(customParms, "", StringComparison.OrdinalIgnoreCase) ? customParms : (string) jobject.SelectToken("launchParameters");
        if (this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
          str1 = str3.Replace("/", "\\").Replace("\\\\", "\\");
        if (!this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
        {
          string[] strArray = Convert.ToString(MySettingsProperty.Settings.LibraryPath).Split(',');
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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetAppInfo(): " + ex.Message);
        // ProjectData.ClearProjectError();
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
        foreach (ListViewItem listViewItem in this.ListView1.Items)
        {
          if (listViewItem != itemAt)
            listViewItem.Selected = false;
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
          string[] source = Convert.ToString(itemAt.Tag).Split(',');
          this.PicturePlay.Image = this.CreateOverlay(this.imageListLarge.Images[source[checked (((IEnumerable<string>) source).Count<string>() - 1)]]);
          this.PicturePlay.Visible = true;
          this.PicturePlay.Select();
        }
        else
          this.PicturePlay.Visible = false;
      }
      catch (Exception ex)
      {
        // ProjectData.SetProjectError(ex);
        // ProjectData.ClearProjectError();
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
      string[] strArray = Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',');
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
        if (MyProject.Forms.frmLaunchOptions.optionsCanceled || !(!String.Equals(str1, "", StringComparison.OrdinalIgnoreCase) & System.IO.File.Exists(str1)))
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
if (Convert.ToString(this.ListView1.SelectedItems[0].Tag).Contains("hidden"))
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
      string[] strArray = Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',');
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
          Log.WriteToLog(Convert.ToString(" Tag: " + this.ListView1.SelectedItems[0].Tag));
        string[] strArray = Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',');
        if (Globals.dbg)
          Log.WriteToLog(" Reading " + strArray[2].Replace("\\\\", "\\").Replace("/", "\\"));
        string str1 = JObject.Parse(System.IO.File.ReadAllText(strArray[2].Replace("\\\\", "\\").Replace("/", "\\"))).SelectToken("launchFile").ToString();
        if (Globals.dbg)
          Log.WriteToLog(" Json Launchfile: " + str1);
        string str2 = strArray[3];
        if (String.Equals(str2, "3rdParty", StringComparison.OrdinalIgnoreCase))
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
        string str9 = Convert.ToString(num1);
        ref string local1 = ref str9;
        int num5 = profileAswDelay.TryGetValue(key1, out local1) ? 1 : 0;
        int integer1 = Convert.ToInt32(str9);
        if (num5 != 0)
          createEditProfile.NumericUpDown1.Value = new Decimal(integer1);
        Dictionary<string, string> profileCpuDelay = MyProject.Forms.FrmMain.profileCpuDelay;
        string key2 = str3;
        string str10 = Convert.ToString(num2);
        ref string local2 = ref str10;
        int num6 = profileCpuDelay.TryGetValue(key2, out local2) ? 1 : 0;
        int integer2 = Convert.ToInt32(str10);
        if (num6 != 0)
          createEditProfile.NumericUpDown2.Value = new Decimal(integer2);
        Dictionary<string, string> profileMirror = MyProject.Forms.FrmMain.profileMirror;
        string lower1 = str3.ToLower();
        str10 = Convert.ToString(num3);
        ref string local3 = ref str10;
        if (profileMirror.TryGetValue(lower1, out local3))
          createEditProfile.ComboMirror.SelectedIndex = num3;
        Dictionary<string, string> profileAgps = MyProject.Forms.FrmMain.profileAGPS;
        string lower2 = str3.ToLower();
        str10 = Convert.ToString(num4);
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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("Could not edit profile: " + ex.Message);
        // ProjectData.ClearProjectError();
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
        // ProjectData.SetProjectError(ex);
        // ProjectData.ClearProjectError();
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
      if (String.Equals(MyProject.Forms.FrmMain.steamvr, "", StringComparison.OrdinalIgnoreCase))
      {
        MessageBox.Show("Could not locate Steam VR path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!String.Equals(Path.GetExtension(str1), ".bat", StringComparison.OrdinalIgnoreCase) && !String.Equals(Path.GetExtension(str1), ".exe", StringComparison.OrdinalIgnoreCase))
            {
              Log.WriteToLog("Copying " + Path.GetFileName(str1) + " -> " + path);
              System.IO.File.Copy(str1, path + "\\" + Path.GetFileName(str1), true);
              Log.WriteToLog("Generating hash for " + Path.GetFileName(str1));
              string str2 = Convert.ToString(this.GenerateSHA256Hash(str1));
              files1.Add(Path.GetFileName(str1), str2);
            }
            if (String.Equals(Path.GetExtension(str1), ".bat", StringComparison.OrdinalIgnoreCase))
              System.IO.File.Copy(str1, MyProject.Forms.FrmMain.steamvr + Path.GetFileName(str1), true);
            checked { ++index; }
          }
        }
        catch (Exception ex)
        {

          Exception exception = ex;
          Log.WriteToLog("Exception occurred when copying files: " + exception.Message);
          MessageBox.Show("Exception occurred when copying files: " + exception.Message);

          return;
        }
        this.CreateManifest(canonicalName.Replace("_assets", ""), "SteamVR", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
        this.CreateAssetManifest(canonicalName, "#060404", files1, "", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
        this.PopulateList();
        if (MessageBox.Show("You need to restart the Oculus Service for SteamVR to be visible in Oculus Home. Restart it now?", "Restart Required", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        foreach (object hiddenApp in (IEnumerable) OTTDB.GetHiddenApps())
        {
          string str = Convert.ToString(hiddenApp);
          this.imageListLarge.Images.Add(str, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
          this.ListView1.Items.Add(new ListViewItem(str, str)
          {
            Tag = (object) (str + ",hidden")
          });
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
        // ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Failed to delete database copy: " + exception.Message);
        MessageBox.Show("Failed to delete database copy: " + exception.Message);
        FrmMain.fmain.AddToListboxAndScroll("Failed to delete database copy: " + exception.Message);
        MyProject.Forms.FrmMain.hasError = true;
        // ProjectData.ClearProjectError();
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

          Exception exception = ex;
          Log.WriteToLog("Failed to create database copy: " + exception.Message);
          MessageBox.Show("Failed to create database copy: " + exception.Message, "Error copying database", MessageBoxButtons.OK, MessageBoxIcon.Error);
          FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;

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
      string str = Convert.ToString(this.ListView1.SelectedItems[0].Tag).Split(',')[2];
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
      string[] strArray = Convert.ToString(selectedItem.Tag).Split(',');
      if (Globals.dbg)
        Log.WriteToLog(" Reading " + strArray[2].Replace("\\\\", "\\").Replace("/", "\\"));
      string str1 = JObject.Parse(System.IO.File.ReadAllText(strArray[2].Replace("\\\\", "\\").Replace("/", "\\"))).SelectToken("launchFile").ToString();
      if (Globals.dbg)
        Log.WriteToLog(" Json Launchfile: " + str1);
      string str2 = strArray[3];
      if (String.Equals(str2, "3rdParty", StringComparison.OrdinalIgnoreCase))
        str2 = str1.Replace("\\\\", "\\").Replace("/", "\\");
      if (Globals.dbg)
        Log.WriteToLog(" Path: " + str2);
      if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(str2, out str1))
        str1 = str2;
      string Path = str1.Replace("\\\\", "\\").Replace("/", "\\");
      if (MessageBox.Show("Remove profile for '" + selectedItem.Text + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
