using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000052 RID: 82
	[StandardModule]
	internal sealed class PowerPlans
	{
		// Token: 0x060007D4 RID: 2004 RVA: 0x00047338 File Offset: 0x00045538
		public static void GetActivePowerPlan()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetActivePowerPlan");
			}
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
				try
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						bool flag = Conversions.ToBoolean(managementObject.GetPropertyValue("IsActive"));
						if (flag)
						{
							PowerPlans.ActivePlanID = managementObject["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
							PowerPlans.filter = PowerPlans.ActivePlanID + "\\AC\\{48e6b7a6-50f5-4782-a5d4-53bb8f07e226}";
							PowerPlans.activePlanName = Conversions.ToString(managementObject["ElementName"]);
							Log.WriteToLog("Current Power Plan is " + PowerPlans.activePlanName);
							GetConfig.IsReading = true;
							PowerPlans.GetSetUsbSuspend(PowerPlans.filter, false);
							object obj = false;
						}
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator;
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting GetActivePowerPlan");
				}
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("* Exception in GetActivePowerPlan(): " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000474D4 File Offset: 0x000456D4
		public static void GetPowerPlans()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetPowerPlans");
			}
			Log.WriteToLog("Getting list of available Power Plans");
			try
			{
				PowerPlans.IDs.Clear();
				MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Clear();
				MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Clear();
				MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Add("Not Used");
				MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Add("Not Used");
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan");
				try
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						string text = managementObject["ElementName"].ToString().ToLower();
						string text2 = managementObject["InstanceID"].ToString().Replace("Microsoft:PowerPlan\\", "");
						bool flag = !PowerPlans.IDs.ContainsKey(text);
						if (flag)
						{
							PowerPlans.IDs.Add(text, text2);
						}
						MyProject.Forms.FrmMain.ComboPowerPlanStart.Items.Add(managementObject["ElementName"].ToString());
						MyProject.Forms.FrmMain.ComboPowerPlanExit.Items.Add(managementObject["ElementName"].ToString());
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("Added Power Plan '" + managementObject["ElementName"].ToString() + "' to list");
						}
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator;
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Exiting GetPowerPlans");
				}
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("* Exception in GetPowerPlans(): " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x00047758 File Offset: 0x00045958
		public static void GetSetUsbSuspend(string filter, bool change)
		{
			bool flag = Operators.CompareString(PowerPlans.activePlanName, null, false) == 0;
			if (flag)
			{
				bool flag2 = !MyProject.Forms.FrmMain.ComboUSBsusp.Items.Contains("Not Available");
				if (flag2)
				{
					MyProject.Forms.FrmMain.ComboUSBsusp.Items.Add("Not Available");
				}
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
						foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
						{
							ManagementObject managementObject = (ManagementObject)managementBaseObject;
							bool flag3 = managementObject["InstanceID"].ToString().Contains(filter);
							if (flag3)
							{
								bool flag4 = !change;
								if (flag4)
								{
									bool flag5 = Operators.ConditionalCompareObjectEqual(managementObject.GetPropertyValue("SettingIndexValue"), 1, false);
									if (flag5)
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
								bool flag6 = change;
								if (flag6)
								{
									bool flag7 = Operators.CompareString(MyProject.Forms.FrmMain.ComboUSBsusp.Text, "Disabled", false) == 0;
									if (flag7)
									{
										Log.WriteToLog("Changing USB Selective Suspend for " + PowerPlans.activePlanName + " to Disabled");
										managementObject.SetPropertyValue("SettingIndexValue", 0);
										managementObject.Put();
									}
									else
									{
										Log.WriteToLog("Changing USB Selective Suspend for " + PowerPlans.activePlanName + " to Enabled");
										managementObject.SetPropertyValue("SettingIndexValue", 1);
										managementObject.Put();
									}
									change = false;
								}
							}
						}
					}
					finally
					{
						ManagementObjectCollection.ManagementObjectEnumerator enumerator;
						if (enumerator != null)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					FrmMain.fmain.SetToolTipText("USB Suspend Setting for the currently active Power Plan (" + PowerPlans.activePlanName + ")", FrmMain.fmain.ComboUSBsusp);
					FrmMain.fmain.SetToolTipText("USB Suspend Setting for the currently active Power Plan (" + PowerPlans.activePlanName + ")", FrmMain.fmain.Label4);
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("Exiting GetSetUsbSuspend");
					}
				}
				catch (Exception ex)
				{
					FrmMain.fmain.AddToListboxAndScroll("* Exception in GetSetUsbSuspend(): " + ex.Message);
					MyProject.Forms.FrmMain.hasWarning = true;
					StackTrace stackTrace = new StackTrace(ex, true);
					Log.WriteToLog(ex.ToString() + stackTrace.ToString());
					Control.CheckForIllegalCrossThreadCalls = true;
				}
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00047AD8 File Offset: 0x00045CD8
		public static void SetActivePowerPlan(string name)
		{
			try
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Entering SetActivePowerPlan");
				}
				bool flag = Operators.CompareString(name, "Not Used", false) == 0;
				if (flag)
				{
					Log.WriteToLog("No power plan set for OTT start");
				}
				else
				{
					Log.WriteToLog("Changing active Power Plan to " + name + "...");
					FrmMain.fmain.PowerPlanTimer.Stop();
					ManagementObject managementObject = (ManagementObject)new ManagementObjectSearcher("root\\cimv2\\power", "SELECT * FROM Win32_PowerPlan WHERE  ElementName = '" + name + "'").Get().Cast<object>().ElementAtOrDefault(0);
					try
					{
						managementObject.InvokeMethod("Activate", null, null);
						FrmMain.fmain.AddToListboxAndScroll("Power Plan set to " + name);
						Log.WriteToLog("Power Plan set to " + name);
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("Exiting SetActivePowerPlan");
						}
						PowerPlans.GetActivePowerPlan();
					}
					catch (Exception ex)
					{
						try
						{
							Log.WriteToLog("Set Powerplan failed, trying alternate method...");
							string text = "";
							bool flag2 = PowerPlans.IDs.TryGetValue(name.ToLower(), out text);
							if (flag2)
							{
								RunCommand.Run_PowerCFG(name, text.Replace("{", "").Replace("}", ""));
							}
						}
						catch (Exception ex2)
						{
							StackTrace stackTrace = new StackTrace(ex2, true);
							Log.WriteToLog("Set Powerplan failed: " + ex2.ToString() + stackTrace.ToString());
						}
					}
					MySettingsProperty.Settings.PowerPlanCurrent = name;
					MySettingsProperty.Settings.Save();
					FrmMain.fmain.PowerPlanTimer.Start();
				}
			}
			catch (Exception ex3)
			{
				StackTrace stackTrace2 = new StackTrace(ex3, true);
				Log.WriteToLog("SetActivePowerPlan: " + ex3.ToString() + stackTrace2.ToString());
				FrmMain.fmain.PowerPlanTimer.Start();
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00047D28 File Offset: 0x00045F28
		public static void CheckPowerState(bool change)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering CheckPowerState");
			}
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
				ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("root\\wmi", "SELECT * FROM MSPower_DeviceEnable");
				List<string> list = new List<string>(new string[] { "VID_045E&PID_02E6&REV_0100", "VID_045E&PID_02E6", "VID_2833&PID_0211", "VID_2833&PID_0330", "VID_2833&PID_0031", "ROOT_HUB_FL30" });
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				bool flag = false;
				try
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						dictionary.Add(Conversions.ToString(managementObject["DeviceID"]), Conversions.ToString(managementObject["name"]));
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator;
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				try
				{
					foreach (ManagementBaseObject managementBaseObject2 in managementObjectSearcher2.Get())
					{
						ManagementObject managementObject2 = (ManagementObject)managementBaseObject2;
						try
						{
							foreach (string text in list)
							{
								string text2 = NewLateBinding.LateGet(managementObject2["InstanceName"], null, "TrimEnd", new object[] { "0" }, null, null, null).ToString().TrimEnd(new char[] { '_' })
									.ToUpper();
								string text3 = text.ToUpper();
								bool flag2 = text2.Contains(text3);
								if (flag2)
								{
									bool flag3 = Operators.ConditionalCompareObjectEqual(managementObject2.GetPropertyValue("Enable"), true, false);
									if (flag3)
									{
										flag = true;
										try
										{
											foreach (KeyValuePair<string, string> keyValuePair in dictionary)
											{
												bool flag4 = Operators.CompareString(keyValuePair.Key, text2, false) == 0;
												if (flag4)
												{
													if (change)
													{
														managementObject2.SetPropertyValue("Enable", false);
														managementObject2.Put();
														FrmMain.fmain.AddToListboxAndScroll("Disabled Power Management on " + keyValuePair.Value);
														Log.WriteToLog("Disabled Power Management on " + keyValuePair.Value);
													}
													else
													{
														bool isElevated = MyProject.Forms.FrmMain.isElevated;
														if (isElevated)
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
														MyProject.Forms.FrmMain.ListBox1.TopIndex = checked(MyProject.Forms.FrmMain.ListBox1.Items.Count - 1);
														MyProject.Forms.FrmMain.hasWarning = true;
													}
												}
											}
										}
										finally
										{
											Dictionary<string, string>.Enumerator enumerator4;
											((IDisposable)enumerator4).Dispose();
										}
									}
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator3;
							((IDisposable)enumerator3).Dispose();
						}
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator2;
					if (enumerator2 != null)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				bool flag5 = !flag;
				if (flag5)
				{
					MyProject.Forms.FrmMain.ToolStripMenuItem4.Enabled = false;
					MyProject.Forms.FrmMain.ToolStripMenuItem4.Visible = false;
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting CheckPowerState");
				}
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("* Exception in CheckPowerState(): " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x04000354 RID: 852
		public static string activePlanName;

		// Token: 0x04000355 RID: 853
		public static string ActivePlanID;

		// Token: 0x04000356 RID: 854
		public static Dictionary<string, string> IDs = new Dictionary<string, string>();

		// Token: 0x04000357 RID: 855
		public static string filter;
	}
}
