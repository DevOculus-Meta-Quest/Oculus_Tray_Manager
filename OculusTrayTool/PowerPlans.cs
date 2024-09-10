using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

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
		{
			Log.WriteToLog("Entering GetActivePowerPlan");
		}
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				if (Conversions.ToBoolean(item.GetPropertyValue("IsActive")))
				{
					ActivePlanID = item["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
					filter = ActivePlanID + "\\AC\\{48e6b7a6-50f5-4782-a5d4-53bb8f07e226}";
					activePlanName = Conversions.ToString(item["ElementName"]);
					Log.WriteToLog("Current Power Plan is " + activePlanName);
					GetConfig.IsReading = true;
					GetSetUsbSuspend(filter, change: false);
					object obj = false;
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetActivePowerPlan");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("* Exception in GetActivePowerPlan(): " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static void GetPowerPlans()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetPowerPlans");
		}
		Log.WriteToLog("Getting list of available Power Plans");
		try
		{
			IDs.Clear();
			MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Clear();
			MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Clear();
			MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Add("Not Used");
			MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Add("Not Used");
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string key = item["ElementName"].ToString().ToLower();
				string value = item["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
				if (!IDs.ContainsKey(key))
				{
					IDs.Add(key, value);
				}
				MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Add(item["ElementName"].ToString());
				MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Add(item["ElementName"].ToString());
				if (Globals.dbg)
				{
					Log.WriteToLog("Added Power Plan '" + item["ElementName"].ToString() + "' to list");
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetPowerPlans");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("* Exception in GetPowerPlans(): " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static void GetSetUsbSuspend(string filter, bool change)
	{
		if (Operators.CompareString(activePlanName, null, TextCompare: false) == 0)
		{
			if (!MyProject.Forms.FrmMain.ComboUSBsusp.Items.Contains("Not Available"))
			{
				MyProject.Forms.FrmMain.ComboUSBsusp.Items.Add("Not Available");
			}
			MyProject.Forms.FrmMain.ComboUSBsusp.SelectedIndex = 2;
			Log.WriteToLog("Could not determine active power plan, exiting");
			return;
		}
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerSettingDataIndex");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				if (!item["InstanceID"].ToString().Contains(filter))
				{
					continue;
				}
				if (!change)
				{
					if (Operators.ConditionalCompareObjectEqual(item.GetPropertyValue("SettingIndexValue"), 1, TextCompare: false))
					{
						MyProject.Forms.FrmMain.ComboUSBsusp.Text = "Enabled";
						Log.WriteToLog("Current Power Plan '" + activePlanName + "' has USB Selective Suspend Enabled");
						FrmMain.fmain.AddToListboxAndScroll("Current Power Plan '" + activePlanName + "' has USB Selective Suspend Enabled");
					}
					else
					{
						MyProject.Forms.FrmMain.ComboUSBsusp.Text = "Disabled";
						Log.WriteToLog("Current Power Plan '" + activePlanName + "' has USB Selective Suspend Disabled");
						FrmMain.fmain.AddToListboxAndScroll("Current Power Plan '" + activePlanName + "' has USB Selective Suspend Disabled");
					}
				}
				if (change)
				{
					if (Operators.CompareString(MyProject.Forms.FrmMain.ComboUSBsusp.Text, "Disabled", TextCompare: false) == 0)
					{
						Log.WriteToLog("Changing USB Selective Suspend for " + activePlanName + " to Disabled");
						item.SetPropertyValue("SettingIndexValue", 0);
						item.Put();
					}
					else
					{
						Log.WriteToLog("Changing USB Selective Suspend for " + activePlanName + " to Enabled");
						item.SetPropertyValue("SettingIndexValue", 1);
						item.Put();
					}
					change = false;
				}
			}
			FrmMain.fmain.SetToolTipText("USB Suspend Setting for the currently active Power Plan (" + activePlanName + ")", FrmMain.fmain.ComboUSBsusp);
			FrmMain.fmain.SetToolTipText("USB Suspend Setting for the currently active Power Plan (" + activePlanName + ")", FrmMain.fmain.Label4);
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetSetUsbSuspend");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("* Exception in GetSetUsbSuspend(): " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			Control.CheckForIllegalCrossThreadCalls = true;
			ProjectData.ClearProjectError();
		}
	}

	public static void SetActivePowerPlan(string name)
	{
		try
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Entering SetActivePowerPlan");
			}
			if (Operators.CompareString(name, "Not Used", TextCompare: false) == 0)
			{
				Log.WriteToLog("No power plan set for OTT start");
				return;
			}
			Log.WriteToLog("Changing active Power Plan to " + name + "...");
			FrmMain.fmain.PowerPlanTimer.Stop();
			ManagementObject managementObject = (ManagementObject)new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan WHERE  ElementName = '" + name + "'").Get().Cast<object>().ElementAtOrDefault(0);
			try
			{
				managementObject.InvokeMethod("Activate", null, null);
				FrmMain.fmain.AddToListboxAndScroll("Power Plan set to " + name);
				Log.WriteToLog("Power Plan set to " + name);
				if (Globals.dbg)
				{
					Log.WriteToLog("Exiting SetActivePowerPlan");
				}
				GetActivePowerPlan();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Log.WriteToLog("Set Powerplan failed, trying alternate method...");
					string value = "";
					if (IDs.TryGetValue(name.ToLower(), out value))
					{
						RunCommand.Run_PowerCFG(name, value.Replace("{", "").Replace("}", ""));
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					StackTrace stackTrace = new StackTrace(ex4, fNeedFileInfo: true);
					Log.WriteToLog("Set Powerplan failed: " + ex4.ToString() + stackTrace.ToString());
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
			MySettingsProperty.Settings.PowerPlanCurrent = name;
			MySettingsProperty.Settings.Save();
			FrmMain.fmain.PowerPlanTimer.Start();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			StackTrace stackTrace2 = new StackTrace(ex6, fNeedFileInfo: true);
			Log.WriteToLog("SetActivePowerPlan: " + ex6.ToString() + stackTrace2.ToString());
			FrmMain.fmain.PowerPlanTimer.Start();
			ProjectData.ClearProjectError();
		}
	}

	public static void CheckPowerState(bool change)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CheckPowerState");
		}
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
			ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("root\\wmi", "SELECT * FROM MSPower_DeviceEnable");
			List<string> list = new List<string>(new string[6] { "VID_045E&PID_02E6&REV_0100", "VID_045E&PID_02E6", "VID_2833&PID_0211", "VID_2833&PID_0330", "VID_2833&PID_0031", "ROOT_HUB_FL30" });
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			bool flag = false;
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				dictionary.Add(Conversions.ToString(item["DeviceID"]), Conversions.ToString(item["name"]));
			}
			foreach (ManagementObject item2 in managementObjectSearcher2.Get())
			{
				foreach (string item3 in list)
				{
					string text = NewLateBinding.LateGet(item2["InstanceName"], null, "TrimEnd", new object[1] { "0" }, null, null, null).ToString().TrimEnd('_')
						.ToUpper();
					string value = item3.ToUpper();
					if (!text.Contains(value) || !Operators.ConditionalCompareObjectEqual(item2.GetPropertyValue("Enable"), true, TextCompare: false))
					{
						continue;
					}
					flag = true;
					foreach (KeyValuePair<string, string> item4 in dictionary)
					{
						if (Operators.CompareString(item4.Key, text, TextCompare: false) != 0)
						{
							continue;
						}
						if (change)
						{
							item2.SetPropertyValue("Enable", false);
							item2.Put();
							FrmMain.fmain.AddToListboxAndScroll("Disabled Power Management on " + item4.Value);
							Log.WriteToLog("Disabled Power Management on " + item4.Value);
							continue;
						}
						if (MyProject.Forms.FrmMain.isElevated)
						{
							FrmMain.fmain.AddToListboxAndScroll(item4.Value + " has Power Management Enabled, right-click to Disable");
							MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = true;
							MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = true;
						}
						else
						{
							FrmMain.fmain.AddToListboxAndScroll(item4.Value + " has Power Management Enabled. Cannot change, not running as Administrator");
							MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = false;
							MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = false;
						}
						MyProject.Forms.FrmMain.ListBox1.TopIndex = checked(MyProject.Forms.FrmMain.ListBox1.Items.Count - 1);
						MyProject.Forms.FrmMain.hasWarning = true;
					}
				}
			}
			if (!flag)
			{
				MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = false;
				MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting CheckPowerState");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("* Exception in CheckPowerState(): " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}
}
