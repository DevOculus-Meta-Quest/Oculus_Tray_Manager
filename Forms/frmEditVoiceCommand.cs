

using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool.Forms
{

  public partial class frmEditVoiceCommand : Form
  {
    

    public frmEditVoiceCommand() => this.InitializeComponent();

    

    

    

    

    

    

    







    private void Button2_Click(object sender, EventArgs e) => this.Close();

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.TextBoxPhrase.Text.EndsWith(";"))
        this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.TrimEnd(';');
      this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.Replace(";;", ";");
      if (String.Equals(this.LabelAction.Text, "Enable Voice Control", StringComparison.OrdinalIgnoreCase))
        MySettingsProperty.Settings.StartVoice = this.TextBoxPhrase.Text;
      if (String.Equals(this.LabelAction.Text, "Disable Voice Control", StringComparison.OrdinalIgnoreCase))
        MySettingsProperty.Settings.StopVoice = this.TextBoxPhrase.Text;
      if (String.Equals(this.LabelAction.Text, "Set Pixel Density", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.SetPD = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.SetPDEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Disable ASW", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.DisableASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.DisableASWEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Enable ASW", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.EnableASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.EnableASWEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "45 fps, ASW On", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.LockASWOn = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.LockASWOnEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show ASW Status", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowASWEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show Pixel Density", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowPD = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowPDEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show Performance", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowPerf = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowPerfEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show Latency Timing", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowLatency = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowLatencyEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show Application Render Timing", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowApplicationRender = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowApplicationRenderEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show Compositor Render Timing", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowCompositorRender = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowCompositorRenderEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Show Version Info", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.ShowVersion = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowVersionEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Close Overlay", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.Close = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.CloseEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      if (String.Equals(this.LabelAction.Text, "Launch SteamVR", StringComparison.OrdinalIgnoreCase))
      {
        MySettingsProperty.Settings.LaunchSteam = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.LaunchSteamEnabled = Convert.ToBoolean(this.ComboEnabled.Text);
      }
      MySettingsProperty.Settings.Save();
      MyProject.Forms.FrmMain.LoadVoiceSettings();
      MyProject.Forms.frmVoiceSettings.VoicechangeMade = true;
      this.Close();
    }
  }
}
