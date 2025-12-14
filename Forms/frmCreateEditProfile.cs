

using MetaQuestTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool.Forms
{

  public partial class frmCreateEditProfile : Form
  {
    
    public string pLaunchfile;
    public string pPath;
    public bool CreateCancel;
    public bool isEdit;
    private string DSep;

    public frmCreateEditProfile()
    {
      this.Load += this.CreateEditProfile_Load;
      this.CreateCancel = false;
      this.isEdit = false;
      this.DSep = ".";
      this.InitializeComponent();
    }

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    



    

    

    

    

    

    

    

    

    



    

    

    

    

    

    


    

    

    

    

    

    

    

    

    

    

    

    

    

    

    private void Button1_Click(object sender, EventArgs e)
    {
      if (String.Equals(this.TextDisplayName.Text, null, StringComparison.Ordinal))
        return;
      MyProject.Forms.frmProfiles.TopMost = true;
      if (!String.Equals(this.TextDisplayName.Text, "- All Games & Apps -", StringComparison.Ordinal))
      {
        this.pLaunchfile = Path.GetFileName(this.TextBoxPath.Text);
        this.pPath = this.TextBoxPath.Text;
        string text1 = this.TextDisplayName.Text;
        string text2 = this.ComboASW.Text;
        string text3 = this.ComboSS.Text;
        string text4 = this.ComboCPU.Text;
        string pLaunchfile = this.pLaunchfile;
        string pPath = this.pPath;
        string text5 = this.ComboMethod.Text;
        Decimal num = this.NumericUpDown1.Value;
        string aswdelay = num.ToString();
        num = this.NumericUpDown2.Value;
        string cpudelay = num.ToString();
        int selectedIndex = this.ComboMirror.SelectedIndex;
        string mirror = selectedIndex.ToString();
        selectedIndex = this.ComboAGPS.SelectedIndex;
        string agps = selectedIndex.ToString();
        string text6 = this.TextBoxComment.Text;
        num = this.NumericUpDown3.Value;
        string str1 = num.ToString();
        num = this.NumericUpDown4.Value;
        string str2 = num.ToString();
        string fov = str1 + " " + str2;
        string text7 = this.ComboBox8.Text;
        string text8 = this.ComboBox9.Text;
        string text9 = this.ComboBoxEnabled.Text;
        MQTTDB.AddProfile(text1, text2, text3, text4, pLaunchfile, pPath, text5, aswdelay, cpudelay, mirror, agps, text6, fov, text7, text8, text9);
      }
      else
      {
        this.Cursor = Cursors.WaitCursor;
        int num1 = checked (this.ComboBox1.Items.Count - 1);
        int index = 1;
        while (index <= num1)
        {
          frmCreateEditProfile.GameItem gameItem = (frmCreateEditProfile.GameItem) this.ComboBox1.Items[index];
          this.TextBoxPath.Text = gameItem.Info;
          this.TextDisplayName.Text = gameItem.Name;
          this.pLaunchfile = Path.GetFileName(this.TextBoxPath.Text);
          this.pPath = this.TextBoxPath.Text;
          string text10 = this.TextDisplayName.Text;
          string text11 = this.ComboASW.Text;
          string text12 = this.ComboSS.Text;
          string text13 = this.ComboCPU.Text;
          string pLaunchfile = this.pLaunchfile;
          string pPath = this.pPath;
          string text14 = this.ComboMethod.Text;
          Decimal num2 = this.NumericUpDown1.Value;
          string aswdelay = num2.ToString();
          num2 = this.NumericUpDown2.Value;
          string cpudelay = num2.ToString();
          string mirror = this.ComboMirror.SelectedIndex.ToString();
          string agps = this.ComboAGPS.SelectedIndex.ToString();
          string text15 = this.TextBoxComment.Text;
          num2 = this.NumericUpDown3.Value;
          string str3 = num2.ToString();
          num2 = this.NumericUpDown4.Value;
          string str4 = num2.ToString();
          string fov = str3 + " " + str4;
          string text16 = this.ComboBox8.Text;
          string text17 = this.ComboBox9.Text;
          string text18 = this.ComboBoxEnabled.Text;
          MQTTDB.AddProfile(text10, text11, text12, text13, pLaunchfile, pPath, text14, aswdelay, cpudelay, mirror, agps, text15, fov, text16, text17, text18);
          checked { ++index; }
        }
        this.Cursor = Cursors.Default;
      }
      MQTTDB.GetProfiles();
      if (FrmMain.fmain.HomeIsRunning | MySettingsProperty.Settings.StartAppwatcherOnStart)
      {
        if (MQTTDB.numWMI > 0)
          FrmMain.fmain.CreateWatcher();
        if (MQTTDB.numTimer > 0)
          FrmMain.fmain.pTimer.Start();
      }
      this.ComboBox1.Items.Remove(this.ComboBox1.SelectedItem);
      this.ComboBox1.Text = "- Select Game -";
      this.ComboSS.SelectedIndex = 0;
      this.ComboASW.SelectedIndex = 0;
      this.ComboCPU.SelectedIndex = 0;
      this.ComboMethod.SelectedIndex = 0;
      this.NumericUpDown1.Value = 5M;
      this.NumericUpDown2.Value = 5M;
      this.TextBoxPath.Text = "";
      this.TextDisplayName.Text = "";
      this.ComboMirror.SelectedIndex = 0;
      this.ComboAGPS.SelectedIndex = 1;
      this.NumericUpDown3.Value = 0M;
      this.NumericUpDown4.Value = 0M;
      this.ComboBoxEnabled.Text = "Yes";
      this.Close();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.CreateCancel = true;
      this.ComboBox1.Text = "- Select Game -";
      this.ComboSS.SelectedIndex = 0;
      this.ComboASW.SelectedIndex = 0;
      this.ComboCPU.SelectedIndex = 0;
      this.ComboMethod.SelectedIndex = 0;
      this.NumericUpDown1.Value = 5M;
      this.NumericUpDown2.Value = 5M;
      this.TextBoxPath.Text = "";
      this.TextDisplayName.Text = "";
      this.ComboAGPS.SelectedIndex = 1;
      this.NumericUpDown3.Value = 0M;
      this.NumericUpDown4.Value = 0M;
      this.ComboBoxEnabled.Text = "Yes";
      this.Close();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Browse...";
      if (!String.Equals(this.TextBoxPath.Text, "", StringComparison.Ordinal))
      {
        if (Directory.Exists(Path.GetDirectoryName(this.TextBoxPath.Text)))
          openFileDialog.InitialDirectory = Path.GetDirectoryName(this.TextBoxPath.Text);
      }
      else
        openFileDialog.InitialDirectory = FrmMain.fmain.MetaPath;
      openFileDialog.Filter = "Executable files (*.exe)|*.exe";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.TextDisplayName.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
      this.TextDisplayName.Visible = true;
      this.ComboBox1.Visible = false;
      this.TextBoxPath.Text = openFileDialog.FileName;
      this.Button1.Enabled = true;
    }

    private void CreateEditProfile_Load(object sender, EventArgs e)
    {
      this.ToolTip1.SetToolTip((Control) this.PictureBox2, "Sets the level of Super Sampling, or Pixel Density, to apply to the app when it is started.\r\nThis value acts as a multiplier, it is not the definitive value the app will get.\r\nThat depends on what the native Pixeld Density the app runs att.\r\nUse the Pixel Density Visual HUD to check what you actually get, and adjust this value to get the desired result.");
      this.ToolTip1.SetToolTip((Control) this.PictureBox3, "Sets the mode for Asynchronous Space Warp (ASW).\r\nThis should usualy be set to Auto unless you experience issues.");
      this.ToolTip1.SetToolTip((Control) this.PictureBox4, "Makes Windows give this app a bit higher priority over other system resources.\r\n Can improve performance.");
      this.ToolTip1.SetToolTip((Control) this.PictureBox5, "Determines how MQTT should detect this app. WMI is default and has less impact on CPU performace\r\nbut is less accurate in detecting games starts. Might not work for every game.\r\nThe Timer method consumes more CPU bit is a lot more accurate.\r\nUse Timer for the apps that do not work with WMI.");
      this.ToolTip1.SetToolTip((Control) this.PictureBox8, "The path to the executable that MQTT should monitor. This is usally correct and should in most\r\ncases not be touched. But in some cases it might be neccessary to modify this\r\nso MQTT detects the right process.");
      this.ToolTip1.SetToolTip((Control) this.PictureBox11, "Setting this to a value lower than 1, for example 0.8, will cause a lower FOV in the headset which\r\nwill increase the FPS due to less pixels being drawn.\r\nUsing a value higher than 1 will only affect the Mirror view on your desktop.");
    
      // Fix: Ensure something is selected if list is not empty
      if (this.ComboASW.SelectedIndex == -1 && this.ComboASW.Items.Count > 0)
      {
          this.ComboASW.SelectedIndex = 0;
      }
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!String.Equals(this.ComboBox1.SelectedItem.ToString(), "- All Games & Apps -", StringComparison.Ordinal))
      {
        frmCreateEditProfile.GameItem selectedItem = (frmCreateEditProfile.GameItem) this.ComboBox1.SelectedItem;
        this.TextBoxPath.Text = selectedItem.Info;
        this.TextDisplayName.Text = selectedItem.Name;
      }
      else
        this.TextDisplayName.Text = "- All Games & Apps -";
      this.Button1.Enabled = true;
    }

    private void ComboBox1_TextChanged(object sender, EventArgs e)
    {
      this.TextDisplayName.Text = this.ComboBox1.Text;
    }

    private void ComboSS_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(!char.IsNumber(e.KeyChar) & e.KeyChar != '.' & Convert.ToInt32(e.KeyChar) != 8))
        return;
      e.Handled = (int) e.KeyChar == (int) Convert.ToChar(this.DSep) || true;
    }

    public class GameItem
    {
      private string mInfo;
      private string mName;

      public GameItem(string name, string info)
      {
        this.mInfo = info;
        this.mName = name;
      }

      public string Info
      {
        get => this.mInfo;
        set => this.mInfo = value;
      }

      public string Name
      {
        get => this.mName;
        set => this.mName = value;
      }

      public override string ToString()
      {
          return this.mName;
      }
    }
  }
}
