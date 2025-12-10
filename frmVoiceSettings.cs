// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmVoiceSettings
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmVoiceSettings : Form
  {
    
    public bool VoicechangeMade;
    private int iRow;
    private int iCol;
    private string setting;
    private bool isEditing;

    public frmVoiceSettings()
    {
      this.FormClosing += this.voiceSettings_FormClosing;
      this.Load += this.voiceSettings_Load;
      this.KeyDown += this.frmVoiceSettings_KeyDown;
      this.VoicechangeMade = false;
      this.isEditing = false;
      this.InitializeComponent();
    }

    


    

    


    

    


    

    


    

    

    

    

    

    

    

    

    


    




    



    

    

    





    



    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.VoicechangeMade)
      {
        this.VoicechangeMade = false;
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Restarting voice recognition");
        VoiceCommands.StopListening();
        // VoiceCommands.DisableVoice();
        VoiceCommands.StartStopBuilder();
      }
      this.Close();
    }

    private void voiceSettings_FormClosing(object sender, FormClosingEventArgs e)
    {
      MySettingsProperty.Settings.VoiceDialogSize = this.Size;
      MySettings.Default.VoiceWindowLocation = this.Location;
      MySettingsProperty.Settings.Save();
      MySettings.Default.Save();
    }

    private void voiceSettings_Load(object sender, EventArgs e)
    {
      if (this.DotNetBarTabcontrol1.TabPages.Count > 2)
        this.DotNetBarTabcontrol1.TabPages.Remove(this.DotNetBarTabcontrol1.TabPages[2]);
      if (MySettings.Default.VoiceWindowLocation != new Point())
        this.Location = MySettings.Default.VoiceWindowLocation;
      else
        this.StartPosition = FormStartPosition.CenterParent;
      if (GetControllers.ControllersFound)
        return;
      GetControllers.GetAllControllers();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.StartVoice = "computer, start listening;speech on";
      MySettingsProperty.Settings.StartVoiceEnabled = true;
      MySettingsProperty.Settings.StopVoice = "computer, stop listening;speech off";
      MySettingsProperty.Settings.StopVoiceEnabled = true;
      MySettingsProperty.Settings.EnableASW = "enable spacewarp";
      MySettingsProperty.Settings.EnableASWEnabled = true;
      MySettingsProperty.Settings.DisableASW = "disable spacewarp";
      MySettingsProperty.Settings.DisableASWEnabled = true;
      MySettingsProperty.Settings.ShowPD = "show pixel density; show super sampling";
      MySettingsProperty.Settings.ShowPDEnabled = true;
      MySettingsProperty.Settings.ShowPerf = "show performance";
      MySettingsProperty.Settings.ShowPerfEnabled = true;
      MySettingsProperty.Settings.Close = "close overlay";
      MySettingsProperty.Settings.CloseEnabled = true;
      MySettingsProperty.Settings.SetPD = "set pixel density;set super sampling";
      MySettingsProperty.Settings.SetPDEnabled = true;
      MySettingsProperty.Settings.ShowASW = "show spacewarp";
      MySettingsProperty.Settings.ShowASWEnabled = true;
      MySettingsProperty.Settings.LockASWOn = "lock framerate";
      MySettingsProperty.Settings.LockASWOnEnabled = true;
      MySettingsProperty.Settings.ShowLatency = "show latency timing";
      MySettingsProperty.Settings.ShowLatencyEnabled = true;
      MySettingsProperty.Settings.ShowApplicationRender = "show application timing";
      MySettingsProperty.Settings.ShowApplicationRenderEnabled = true;
      MySettingsProperty.Settings.ShowCompositorRender = "show compositor timing";
      MySettingsProperty.Settings.ShowCompositorRenderEnabled = true;
      MySettingsProperty.Settings.ShowVersion = "show version";
      MySettingsProperty.Settings.ShowVersionEnabled = true;
      MySettingsProperty.Settings.LaunchSteam = "start steam;launch steam";
      MySettingsProperty.Settings.LaunchSteamEnabled = true;
      MySettingsProperty.Settings.Save();
      MyProject.Forms.FrmMain.LoadVoiceSettings();
      this.VoicechangeMade = true;
    }

    private void TrackBar1_Scroll(object sender, EventArgs e)
    {
      this.LabelConfidencePercent.Text = Conversions.ToString(this.TrackBar1.Value) + "%";
      this.LabelConfidencePercent.Refresh();
      this.VoicechangeMade = true;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox1.Checked)
      {
        this.CheckBox2.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the prhase set for 'Disable Voice Control' is spoken.";
        MySettingsProperty.Settings.VoiceActivationVoiceContinous = true;
      }
      else
        MySettingsProperty.Settings.VoiceActivationVoiceContinous = false;
      MySettingsProperty.Settings.Save();
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox2.Checked)
      {
        this.CheckBox1.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the prhase set for 'Enable Voice Control' must once again be spoken to activate commands.";
        MySettingsProperty.Settings.VoiceActivationVoiceRepeated = true;
      }
      else
        MySettingsProperty.Settings.VoiceActivationVoiceRepeated = false;
      MySettingsProperty.Settings.Save();
    }

    private void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox3.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox4.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again";
        MySettingsProperty.Settings.VoiceActivationKeyContinous = true;
      }
      else
      {
        MySettingsProperty.Settings.VoiceActivationKeyContinous = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox4.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox3.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
        MySettingsProperty.Settings.VoiceActivationKeyPush = true;
      }
      else
      {
        MySettingsProperty.Settings.VoiceActivationKeyPush = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void ButtonListen_Click(object sender, EventArgs e)
    {
      this.ButtonListen.Image = this.ImageList1.Images[0];
      this.ButtonListen.Refresh();
      if (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) != 0 & Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "", false) != 0)
      {
        frmVoiceSettings.UpdateButtonLabel("Push button");
        GetControllers.CaptureSelectedButton();
      }
      if (!(Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) == 0 & Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "", false) != 0))
        return;
      this.LabelKey.Text = "Press key";
    }

    private void ComboDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
      GetControllers.selectedDevice = this.ComboDevice.SelectedItem.ToString();
      if (Operators.CompareString(this.ComboDevice.SelectedItem.ToString(), "Keyboard", false) != 0)
      {
        GetControllers.SelectController();
        if (Operators.CompareString(MySettingsProperty.Settings.JoystickDeviceName, this.ComboDevice.SelectedItem.ToString(), false) == 0)
          this.LabelKey.Text = MySettingsProperty.Settings.JoystickVoiceActivationButton.Replace("Buttons", "");
      }
      else
        this.LabelKey.Text = MySettingsProperty.Settings.KeyboardVoiceActivationKey;
      this.ButtonListen.Enabled = true;
    }

    private void TrackBar1_MouseUp(object sender, MouseEventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.Confidence = this.TrackBar1.Value;
      MySettingsProperty.Settings.Save();
    }

    public static void UpdateButtonLabel(string text)
    {
      if (MyProject.Forms.frmVoiceSettings.InvokeRequired)
      {
        MyProject.Forms.frmVoiceSettings.Invoke((Delegate) new frmVoiceSettings.UpdateLabelDelegate(frmVoiceSettings.UpdateButtonLabel), (object) text);
      }
      else
      {
        MyProject.Forms.frmVoiceSettings.LabelKey.Text = text;
        MyProject.Forms.frmVoiceSettings.LabelKey.Refresh();
      }
    }

    public static void UpdateListeningButton(int index)
    {
      if (MyProject.Forms.frmVoiceSettings.InvokeRequired)
      {
        MyProject.Forms.frmVoiceSettings.Invoke((Delegate) new frmVoiceSettings.UpdateListeningButtonDelegate(frmVoiceSettings.UpdateListeningButton), (object) index);
      }
      else
      {
        MyProject.Forms.frmVoiceSettings.ButtonListen.Image = MyProject.Forms.frmVoiceSettings.ImageList1.Images[index];
        MyProject.Forms.frmVoiceSettings.ButtonListen.Refresh();
      }
    }

    private void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox5.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox6.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again";
        MySettingsProperty.Settings.JoystickActivationKeyContinous = true;
      }
      else
      {
        MySettingsProperty.Settings.JoystickActivationKeyContinous = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      if (this.CheckBox6.Checked)
      {
        this.ComboDevice.Enabled = true;
        this.CheckBox5.Checked = false;
        this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
        MySettingsProperty.Settings.JoystickActivationKeyPush = true;
      }
      else
      {
        MySettingsProperty.Settings.JoystickActivationKeyPush = false;
        if (!this.CheckBox3.Checked & !this.CheckBox4.Checked & !this.CheckBox5.Checked & !this.CheckBox5.Checked & !this.CheckBox6.Checked)
        {
          this.ComboDevice.Enabled = false;
          this.ButtonListen.Enabled = false;
        }
      }
      MySettingsProperty.Settings.Save();
      this.AddItemsToDeviceList();
    }

    private void frmVoiceSettings_KeyDown(object sender, KeyEventArgs e)
    {
      if (Operators.CompareString(this.LabelKey.Text, "Press key", false) != 0)
        return;
      frmVoiceSettings.UpdateButtonLabel(e.KeyCode.ToString().ToUpper());
      this.ButtonListen.Image = this.ImageList1.Images[1];
      this.ButtonListen.Refresh();
      MySettingsProperty.Settings.KeyboardVoiceActivationKey = e.KeyCode.ToString().ToUpper();
      MySettingsProperty.Settings.Save();
      Log.WriteToLog("Registered '" + e.KeyCode.ToString().ToUpper() + "' as key for activating voice commands");
    }

    private void CheckBox1_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active and will remain so until the phrase set for 'Disable Voice Control' is spoken.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox2_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening on startup, but it will only recognize the phrase set for 'Enable Voice Control'. After that phrase is spoken and understood, the rest of the voice commands become active. After a voice command has been spoken, Oculus Tray Tool will stop listening for more commands, and the phrase set for 'Enable Voice Control' must once again be spoken.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox3_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a key is pressed. It will keep listening until the same key is pressed again.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox4_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a key is pressed, and stop listening when it is released.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox5_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands when a joystick button is pressed. It will keep listening until the same joystick button is pressed again.";
      this.LabelExplain.Refresh();
    }

    private void CheckBox6_MouseHover(object sender, EventArgs e)
    {
      this.LabelExplain.Text = "Oculus Tray Tool will start listening for commands while a joystick button is pressed, and stop listening when it is released.";
      this.LabelExplain.Refresh();
    }

    public void AddItemsToDeviceList()
    {
      this.ComboDevice.Text = "";
      this.ComboDevice.Items.Clear();
      this.LabelKey.Text = "";
      if (this.CheckBox3.Checked | this.CheckBox4.Checked)
        this.ComboDevice.Items.Add((object) "Keyboard");
      if (!(this.CheckBox5.Checked | this.CheckBox6.Checked))
        return;
      foreach (KeyValuePair<string, Guid> joystick in GetControllers.joysticks)
        this.ComboDevice.Items.Add((object) joystick.Key);
    }

    private void ComboDevice_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void ListView1_MouseClick(object sender, MouseEventArgs e)
    {
      ListViewHitTestInfo listViewHitTestInfo = this.ListView1.HitTest(e.X, e.Y);
      if (listViewHitTestInfo.Item == null)
        return;
      MyProject.Forms.frmEditVoiceCommand.LabelAction.Text = listViewHitTestInfo.Item.Text;
      MyProject.Forms.frmEditVoiceCommand.TextBoxPhrase.Text = listViewHitTestInfo.Item.SubItems[1].Text + ";";
      MyProject.Forms.frmEditVoiceCommand.ComboEnabled.SelectedIndex = Operators.CompareString(listViewHitTestInfo.Item.SubItems[2].Text, "True", false) != 0 ? 1 : 0;
      int num = (int) MyProject.Forms.frmEditVoiceCommand.ShowDialog();
    }

    private void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
      if (GetConfig.IsReading)
        return;
      MySettingsProperty.Settings.DisableVoiceControlAudioFeedback = this.CheckBox7.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmAddCustomVoice.ShowDialog();
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Operators.ConditionalCompareObjectNotEqual(this.ComboBox1.SelectedItem, (object) null, false))
      {
        this.Button2.Enabled = true;
        List<string> stringList = new List<string>();
        List<string> voiceProfileCommands = (List<string>) OTTDB.GetVoiceProfileCommands(this.ComboBox1.SelectedItem.ToString());
        foreach (string Expression in voiceProfileCommands)
        {
          string[] strArray1 = Strings.Split(Expression, "|");
          ListViewItem listViewItem1 = new ListViewItem();
          ListViewItem listViewItem2 = this.ListView2.Items.Add(strArray1[0]);
          string[] strArray2 = Strings.Split(strArray1[1], ",");
          int index = 0;
          while (index < strArray2.Length)
          {
            string[] strArray3 = Strings.Split(strArray2[index], ":");
            if (Operators.CompareString(strArray3[0], "wait", false) != 0)
              listViewItem2.SubItems.Add(strArray3[0] + " '" + strArray3[1] + "'");
            checked { ++index; }
          }
        }
      }
      else
        this.Button2.Enabled = false;
    }

    private void DotNetBarTabcontrol1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmAddVoiceProfile.ShowDialog();
    }

    private void ComboBox1_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(this.ComboBox1.Text, (string) null, false) != 0)
        return;
      this.Button2.Enabled = false;
    }

    private delegate void UpdateLabelDelegate(string text);

    private delegate void UpdateListeningButtonDelegate(int index);
  }
}