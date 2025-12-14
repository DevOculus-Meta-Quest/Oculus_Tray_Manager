

using OculusTrayTool.My;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Text.RegularExpressions;

#nullable disable
namespace OculusTrayTool
{
  internal sealed class PowerPlans
  {
    public static string activePlanName;
    public static string ActivePlanID;
    public static Dictionary<string, string> IDs = new Dictionary<string, string>();
    public static List<string> PlanNames = new List<string>();
    private static readonly object _lock = new object();
    public static string filter;

    public static void GetActivePowerPlan()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetActivePowerPlan");
      try
      {
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
        foreach (ManagementObject managementObject in managementObjectSearcher.Get())
        {
          if (Convert.ToBoolean(managementObject.GetPropertyValue("IsActive")))
          {
            PowerPlans.ActivePlanID = managementObject["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
            PowerPlans.filter = PowerPlans.ActivePlanID + "\\AC\\{48e6b7a6-50f5-4782-a5d4-53bb8f07e226}";
            PowerPlans.activePlanName = Convert.ToString(managementObject["ElementName"]);
            Log.WriteToLog("Current Power Plan is " + PowerPlans.activePlanName);
            GetConfig.IsReading = true;
            PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
            object obj = (object) false;
          }
        }
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting GetActivePowerPlan");
      }
      catch (Exception ex)
      {
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Exception in GetActivePowerPlan(): " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
      }
    }

    public static void GetPowerPlans()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetPowerPlans");
      Log.WriteToLog("Getting list of available Power Plans.");
      try
      {
        lock (_lock)
        {
            PowerPlans.PlanNames.Clear();
            PowerPlans.PlanNames.Add("Not Used");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
            foreach (ManagementObject managementObject in managementObjectSearcher.Get())
            {
              string lower = managementObject["ElementName"].ToString().ToLower();
              string str = managementObject["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
              if (!PowerPlans.IDs.ContainsKey(lower))
              {
                PowerPlans.IDs.Add(lower, str);
                PowerPlans.PlanNames.Add(managementObject["ElementName"].ToString());
              }
            }
    
            // If WMI failed to find any plans, try parsing powercfg /list
            if (PowerPlans.IDs.Count == 0)
            {
                 Log.WriteToLog("GetPowerPlans: WMI found no plans. Trying powercfg /list fallback...");
                 try 
                 {
                     ProcessStartInfo psi = new ProcessStartInfo("powercfg", "/list");
                     psi.RedirectStandardOutput = true;
                     psi.UseShellExecute = false;
                     psi.CreateNoWindow = true;
                     
                     using (Process p = Process.Start(psi))
                     {
                         string output = p.StandardOutput.ReadToEnd();
                         p.WaitForExit();
                         
                         Regex r = new Regex(@"Power Scheme GUID:\s+([0-9a-fA-F\-]+)\s+\((.+)\)");
                         foreach (Match m in r.Matches(output))
                         {
                             if (m.Success)
                             {
                                 string guid = m.Groups[1].Value;
                                 string name = m.Groups[2].Value;
                                 string lowerName = name.ToLower();
                                 
                                 if (!PowerPlans.IDs.ContainsKey(lowerName))
                                 {
                                     PowerPlans.IDs.Add(lowerName, guid);
                                     PowerPlans.PlanNames.Add(name);
                                 }
                             }
                         }
                     }
                 }
                 catch (Exception exFallback)
                 {
                     Log.WriteToLog("GetPowerPlans Fallback Error: " + exFallback.Message);
                 }
            }
            
             // Fix: Auto-select logic moved to FrmMain
            // if (FrmMain.fmain.ComboPowerPlanStart.Items.Count > 0 && FrmMain.fmain.ComboPowerPlanStart.SelectedIndex == -1)
            //   FrmMain.fmain.ComboPowerPlanStart.SelectedIndex = 0;
            // if (FrmMain.fmain.ComboPowerPlanExit.Items.Count > 0 && FrmMain.fmain.ComboPowerPlanExit.SelectedIndex == -1)
            //   FrmMain.fmain.ComboPowerPlanExit.SelectedIndex = 0;
              
            Log.WriteToLog("GetPowerPlans: Found " + PowerPlans.IDs.Count + " plans.");
        }
        return;
      }
      catch (Exception ex)
      {
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Exception in GetPowerPlans(): " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
      }
    }

    public static void GetSetUsbSuspend(string filter, bool change)
    {
      if (string.Equals(PowerPlans.activePlanName, null, StringComparison.Ordinal))
      {
        if (!FrmMain.fmain.ComboUSBsusp.Items.Contains((object) "Not Available"))
          FrmMain.fmain.ComboUSBsusp.Items.Add((object) "Not Available");
        FrmMain.fmain.ComboUSBsusp.SelectedIndex = 2;
        Log.WriteToLog("Could not determine active power plan, exiting");
      }
      else
      {
        try
        {
          ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerSettingDataIndex");
          foreach (ManagementObject managementObject in managementObjectSearcher.Get())
          {
            if (managementObject["InstanceID"].ToString().Contains(filter))
            {
              if (!change)
              {
                if (Convert.ToInt32(managementObject.GetPropertyValue("SettingIndexValue")) == 1)
                {
                  FrmMain.fmain.ComboUSBsusp.Text = "Enabled";
                  Log.WriteToLog("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Enabled");
                  FrmMain.fmain.AddToListboxAndScroll("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Enabled");
                }
                else
                {
                  FrmMain.fmain.ComboUSBsusp.Text = "Disabled";
                  Log.WriteToLog("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Disabled");
                  FrmMain.fmain.AddToListboxAndScroll("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Disabled");
                }
              }
              if (change)
              {
                if (string.Equals(FrmMain.fmain.ComboUSBsusp.Text, "Disabled", StringComparison.Ordinal))
                {
                  Log.WriteToLog("Changing USB Selective Suspend for " + PowerPlans.activePlanName + " to Disabled");
                  managementObject.SetPropertyValue("SettingIndexValue", (object) 0);
                  managementObject.Put();
                }
                else
                {
                  Log.WriteToLog("Changing USB Selective Suspend for " + PowerPlans.activePlanName + " to Enabled");
                  managementObject.SetPropertyValue("SettingIndexValue", (object) 1);
                  managementObject.Put();
                }
                change = false;
              }
            }
          }
          FrmMain.fmain.SetToolTipText((Control) FrmMain.fmain.ComboUSBsusp, "USB Suspend Setting for the currently active Power Plan (" + PowerPlans.activePlanName + ")");
          FrmMain.fmain.SetToolTipText((Control) FrmMain.fmain.Label4, "USB Suspend Setting for the currently active Power Plan (" + PowerPlans.activePlanName + ")");
          if (Globals.dbg)
            Log.WriteToLog("Exiting GetSetUsbSuspend");
        }
        catch (Exception ex)
        {
          Exception e = ex;
          FrmMain.fmain.AddToListboxAndScroll("* Exception in GetSetUsbSuspend(): " + e.Message);
          MyProject.Forms.FrmMain.hasWarning = true;
          StackTrace stackTrace = new StackTrace(e, true);
          Log.WriteToLog(e.ToString() + stackTrace.ToString());
          Control.CheckForIllegalCrossThreadCalls = true;
        }
      }
    }

    public static void SetActivePowerPlan(string name)
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Entering SetActivePowerPlan");
        if (string.Equals(name, "Not Used", StringComparison.Ordinal))
        {
          Log.WriteToLog("No power plan set for OTT start");
        }
        else
        {
          Log.WriteToLog("Changing active Power Plan to " + name + "...");
          FrmMain.fmain.PowerPlanTimer.Stop();
          ManagementObject managementObject = (ManagementObject) new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan WHERE  ElementName = '" + name + "'").Get().Cast<object>().ElementAtOrDefault<object>(0);
          try
          {
            managementObject.InvokeMethod("Activate", (ManagementBaseObject) null, (InvokeMethodOptions) null);
            FrmMain.fmain.AddToListboxAndScroll("Power Plan set to " + name);
            Log.WriteToLog("Power Plan set to " + name);
            if (Globals.dbg)
              Log.WriteToLog("Exiting SetActivePowerPlan");
            PowerPlans.GetActivePowerPlan();
          }
          catch (Exception ex1)
          {
            try
            {
              Log.WriteToLog("Set Powerplan failed, trying alternate method...");
              string str = "";
              lock (_lock)
              {
                   bool found = PowerPlans.IDs.TryGetValue(name.ToLower(), out str);
                   if (found)
                    RunCommand.Run_PowerCFG(name, str.Replace("{", "").Replace("}", ""));
              }
            }
            catch (Exception ex2)
            {
              Exception e = ex2;
              StackTrace stackTrace = new StackTrace(e, true);
              Log.WriteToLog("Set Powerplan failed: " + e.ToString() + stackTrace.ToString());
            }
          }
          MySettingsProperty.Settings.PowerPlanCurrent = name;
          MySettingsProperty.Settings.Save();
          FrmMain.fmain.PowerPlanTimer.Start();
        }
      }
      catch (Exception ex)
      {
        Exception e = ex;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog("SetActivePowerPlan: " + e.ToString() + stackTrace.ToString());
        FrmMain.fmain.PowerPlanTimer.Start();
      }
    }

    public static void CheckPowerState(bool change)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering CheckPowerState");
      try
      {
        ManagementObjectSearcher managementObjectSearcher1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
        ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("root\\wmi", "SELECT * FROM MSPower_DeviceEnable");
        List<string> stringList = new List<string>((IEnumerable<string>) new string[6]
        {
          "VID_045E&PID_02E6&REV_0100",
          "VID_045E&PID_02E6",
          "VID_2833&PID_0211",
          "VID_2833&PID_0330",
          "VID_2833&PID_0031",
          "ROOT_HUB_FL30"
        });
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        bool flag = false;
        foreach (ManagementObject managementObject in managementObjectSearcher1.Get())
          {
            dictionary.Add(Convert.ToString(managementObject["DeviceID"]), Convert.ToString(managementObject["name"]));
          }
        foreach (ManagementObject managementObject in managementObjectSearcher2.Get())
        {
          foreach (string str in stringList)
          {
            string upper1 = managementObject["InstanceName"].ToString().TrimEnd("0".ToCharArray()).TrimEnd('_').ToUpper();
            string upper2 = str.ToUpper();
            if (upper1.Contains(upper2) && Convert.ToBoolean(managementObject.GetPropertyValue("Enable")))
            {
              flag = true;
              foreach (KeyValuePair<string, string> keyValuePair in dictionary)
              {
                if (string.Equals(keyValuePair.Key, upper1, StringComparison.Ordinal))
                {
                  if (change)
                  {
                    managementObject.SetPropertyValue("Enable", (object) false);
                    managementObject.Put();
                    FrmMain.fmain.AddToListboxAndScroll("Disabled Power Management on " + keyValuePair.Value);
                    Log.WriteToLog("Disabled Power Management on " + keyValuePair.Value);
                  }
                  else
                  {
                    if (FrmMain.fmain.isElevated)
                    {
                      FrmMain.fmain.AddToListboxAndScroll(keyValuePair.Value + " has Power Management Enabled, right-click to Disable");
                      FrmMain.fmain.ToolStripMenuItem4.Enabled = true;
                      FrmMain.fmain.ToolStripMenuItem4.Visible = true;
                    }
                    else
                    {
                      FrmMain.fmain.AddToListboxAndScroll(keyValuePair.Value + " has Power Management Enabled. Cannot change, not running as Administrator");
                      FrmMain.fmain.ToolStripMenuItem4.Enabled = false;
                      FrmMain.fmain.ToolStripMenuItem4.Visible = false;
                    }
                    FrmMain.fmain.ListBox1.TopIndex = checked (FrmMain.fmain.ListBox1.Items.Count - 1);
                    FrmMain.fmain.hasWarning = true;
                  }
                }
              }
            }
          }
        }
        if (!flag)
        {
          FrmMain.fmain.ToolStripMenuItem4.Enabled = false;
          FrmMain.fmain.ToolStripMenuItem4.Visible = false;
        }
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting CheckPowerState");
      }
      catch (Exception ex)
      {
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Exception in CheckPowerState(): " + e.Message);
        FrmMain.fmain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
      }
    }
  }
}
