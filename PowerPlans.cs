// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.PowerPlans
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class PowerPlans
  {
    public static string activePlanName;
    public static string ActivePlanID;
    public static Dictionary<string, string> IDs = new Dictionary<string, string>();
    public static string filter;

    public static void GetActivePowerPlan()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetActivePowerPlan");
      try
      {
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
        try
        {
          foreach (ManagementObject managementObject in managementObjectSearcher.Get())
          {
            if (Conversions.ToBoolean(managementObject.GetPropertyValue("IsActive")))
            {
              PowerPlans.ActivePlanID = managementObject["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
              PowerPlans.filter = PowerPlans.ActivePlanID + "\\AC\\{48e6b7a6-50f5-4782-a5d4-53bb8f07e226}";
              PowerPlans.activePlanName = Conversions.ToString(managementObject["ElementName"]);
              Log.WriteToLog("Current Power Plan is " + PowerPlans.activePlanName);
              GetConfig.IsReading = true;
              PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
              object obj = (object) false;
            }
          }
        }
        finally
        {
          ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
          objectEnumerator?.Dispose();
        }
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting GetActivePowerPlan");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Exception in GetActivePowerPlan(): " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static void GetPowerPlans()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetPowerPlans");
      Log.WriteToLog("Getting list of available Power Plans");
      try
      {
        PowerPlans.IDs.Clear();
        MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Clear();
        MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Clear();
        MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Add((object) "Not Used");
        MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Add((object) "Not Used");
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
        try
        {
          foreach (ManagementObject managementObject in managementObjectSearcher.Get())
          {
            string lower = managementObject["ElementName"].ToString().ToLower();
            string str = managementObject["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
            if (!PowerPlans.IDs.ContainsKey(lower))
              PowerPlans.IDs.Add(lower, str);
            MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Add((object) managementObject["ElementName"].ToString());
            MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Add((object) managementObject["ElementName"].ToString());
            if (Globals.dbg)
              Log.WriteToLog("Added Power Plan '" + managementObject["ElementName"].ToString() + "' to list");
          }
        }
        finally
        {
          ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
          objectEnumerator?.Dispose();
        }
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting GetPowerPlans");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Exception in GetPowerPlans(): " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static void GetSetUsbSuspend(string filter, bool change)
    {
      if (Operators.CompareString(PowerPlans.activePlanName, (string) null, false) == 0)
      {
        if (!MyProject.Forms.FrmMain.ComboUSBsusp.Items.Contains((object) "Not Available"))
          MyProject.Forms.FrmMain.ComboUSBsusp.Items.Add((object) "Not Available");
        MyProject.Forms.FrmMain.ComboUSBsusp.SelectedIndex = 2;
        Log.WriteToLog("Could not determine active power plan, exiting");
      }
      else
      {
        try
        {
          ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerSettingDataIndex");
          try
          {
            foreach (ManagementObject managementObject in managementObjectSearcher.Get())
            {
              if (managementObject["InstanceID"].ToString().Contains(filter))
              {
                if (!change)
                {
                  if (Operators.ConditionalCompareObjectEqual(managementObject.GetPropertyValue("SettingIndexValue"), (object) 1, false))
                  {
                    MyProject.Forms.FrmMain.ComboUSBsusp.Text = "Enabled";
                    Log.WriteToLog("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Enabled");
                    FrmMain.fmain.AddToListboxAndScroll("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Enabled");
                  }
                  else
                  {
                    MyProject.Forms.FrmMain.ComboUSBsusp.Text = "Disabled";
                    Log.WriteToLog("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Disabled");
                    FrmMain.fmain.AddToListboxAndScroll("Current Power Plan '" + PowerPlans.activePlanName + "' has USB Selective Suspend Disabled");
                  }
                }
                if (change)
                {
                  if (Operators.CompareString(MyProject.Forms.FrmMain.ComboUSBsusp.Text, "Disabled", false) == 0)
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
          }
          finally
          {
            ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
            objectEnumerator?.Dispose();
          }
          FrmMain.fmain.SetToolTipText("USB Suspend Setting for the currently active Power Plan (" + PowerPlans.activePlanName + ")", (Control) FrmMain.fmain.ComboUSBsusp);
          FrmMain.fmain.SetToolTipText("USB Suspend Setting for the currently active Power Plan (" + PowerPlans.activePlanName + ")", (Control) FrmMain.fmain.Label4);
          if (Globals.dbg)
            Log.WriteToLog("Exiting GetSetUsbSuspend");
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception e = ex;
          FrmMain.fmain.AddToListboxAndScroll("* Exception in GetSetUsbSuspend(): " + e.Message);
          MyProject.Forms.FrmMain.hasWarning = true;
          StackTrace stackTrace = new StackTrace(e, true);
          Log.WriteToLog(e.ToString() + stackTrace.ToString());
          Control.CheckForIllegalCrossThreadCalls = true;
          ProjectData.ClearProjectError();
        }
      }
    }

    public static void SetActivePowerPlan(string name)
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Entering SetActivePowerPlan");
        if (Operators.CompareString(name, "Not Used", false) == 0)
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
            ProjectData.SetProjectError(ex1);
            try
            {
              Log.WriteToLog("Set Powerplan failed, trying alternate method...");
              string str = "";
              if (PowerPlans.IDs.TryGetValue(name.ToLower(), out str))
                RunCommand.Run_PowerCFG(name, str.Replace("{", "").Replace("}", ""));
            }
            catch (Exception ex2)
            {
              ProjectData.SetProjectError(ex2);
              Exception e = ex2;
              StackTrace stackTrace = new StackTrace(e, true);
              Log.WriteToLog("Set Powerplan failed: " + e.ToString() + stackTrace.ToString());
              ProjectData.ClearProjectError();
            }
            ProjectData.ClearProjectError();
          }
          MySettingsProperty.Settings.PowerPlanCurrent = name;
          MySettingsProperty.Settings.Save();
          FrmMain.fmain.PowerPlanTimer.Start();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog("SetActivePowerPlan: " + e.ToString() + stackTrace.ToString());
        FrmMain.fmain.PowerPlanTimer.Start();
        ProjectData.ClearProjectError();
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
        try
        {
          foreach (ManagementObject managementObject in managementObjectSearcher1.Get())
            dictionary.Add(Conversions.ToString(managementObject["DeviceID"]), Conversions.ToString(managementObject["name"]));
        }
        finally
        {
          ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
          objectEnumerator?.Dispose();
        }
        try
        {
          foreach (ManagementObject managementObject in managementObjectSearcher2.Get())
          {
            try
            {
              foreach (string str in stringList)
              {
                string upper1 = NewLateBinding.LateGet(managementObject["InstanceName"], (Type) null, "TrimEnd", new object[1]
                {
                  (object) "0"
                }, (string[]) null, (Type[]) null, (bool[]) null).ToString().TrimEnd('_').ToUpper();
                string upper2 = str.ToUpper();
                if (upper1.Contains(upper2) && Operators.ConditionalCompareObjectEqual(managementObject.GetPropertyValue("Enable"), (object) true, false))
                {
                  flag = true;
                  try
                  {
                    foreach (KeyValuePair<string, string> keyValuePair in dictionary)
                    {
                      if (Operators.CompareString(keyValuePair.Key, upper1, false) == 0)
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
                          if (MyProject.Forms.FrmMain.isElevated)
                          {
                            FrmMain.fmain.AddToListboxAndScroll(keyValuePair.Value + " has Power Management Enabled, right-click to Disable");
                            MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = true;
                            MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = true;
                          }
                          else
                          {
                            FrmMain.fmain.AddToListboxAndScroll(keyValuePair.Value + " has Power Management Enabled. Cannot change, not running as Administrator");
                            MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = false;
                            MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = false;
                          }
                          MyProject.Forms.FrmMain.ListBox1.TopIndex = checked (MyProject.Forms.FrmMain.ListBox1.Items.Count - 1);
                          MyProject.Forms.FrmMain.hasWarning = true;
                        }
                      }
                    }
                  }
                  finally
                  {
                    Dictionary<string, string>.Enumerator enumerator;
                    enumerator.Dispose();
                  }
                }
              }
            }
            finally
            {
              List<string>.Enumerator enumerator;
              enumerator.Dispose();
            }
          }
        }
        finally
        {
          ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
          objectEnumerator?.Dispose();
        }
        if (!flag)
        {
          MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = false;
          MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = false;
        }
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting CheckPowerState");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Exception in CheckPowerState(): " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }
  }
}
