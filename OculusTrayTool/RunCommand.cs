using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using UACHelper;

namespace OculusTrayTool
{
	// Token: 0x02000055 RID: 85
	[StandardModule]
	internal sealed class RunCommand
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x00048C90 File Offset: 0x00046E90
		public static void Run_debug_tool(string ss)
		{
			bool flag = Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0;
			if (flag)
			{
				Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting SuperSampling to " + ss);
				FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting SuperSampling to " + ss);
			}
			else
			{
				Log.WriteToLog("Setting SuperSampling to " + ss);
				FrmMain.fmain.AddToListboxAndScroll("Setting SuperSampling to " + ss);
			}
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\ppdp.txt"))
				{
					streamWriter.WriteLine("service set-pixels-per-display-pixel " + ss);
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\ppdp.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag3)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				try
				{
					Log.WriteToLog("Set SuperSampling: Failed: " + ex.Message);
					Log.WriteToLog("Set SuperSampling: Re-trying...");
					bool flag4 = MySettingsProperty.Settings.DbgToolMethod == 1;
					if (flag4)
					{
						process.Start();
						process.WaitForExit();
						MySettingsProperty.Settings.DbgToolMethod = 2;
						MySettingsProperty.Settings.Save();
					}
					bool flag5 = MySettingsProperty.Settings.DbgToolMethod == 2;
					if (flag5)
					{
						global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
						MySettingsProperty.Settings.DbgToolMethod = 1;
						MySettingsProperty.Settings.Save();
					}
				}
				catch (Exception ex2)
				{
					Log.WriteToLog("Set SuperSampling: Failed: " + ex2.Message);
					StackTrace stackTrace = new StackTrace(ex2, true);
					Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
					FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
				}
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00048F88 File Offset: 0x00047188
		public static void Run_debug_tool_info(string info)
		{
			Log.WriteToLog("Setting Info Overlay to " + info);
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\perf.txt"))
				{
					streamWriter.WriteLine(info);
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\perf.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag2)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				try
				{
					Log.WriteToLog("Set Info Overlay: Failed: " + ex.Message);
					Log.WriteToLog("Set Info Overlay: Re-trying...");
					bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 1;
					if (flag3)
					{
						process.Start();
						process.WaitForExit();
						MySettingsProperty.Settings.DbgToolMethod = 2;
						MySettingsProperty.Settings.Save();
					}
					bool flag4 = MySettingsProperty.Settings.DbgToolMethod == 2;
					if (flag4)
					{
						global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
						MySettingsProperty.Settings.DbgToolMethod = 1;
						MySettingsProperty.Settings.Save();
					}
				}
				catch (Exception ex2)
				{
					Log.WriteToLog("Warning: Set Info Overlay: " + ex2.Message);
					StackTrace stackTrace = new StackTrace(ex2, true);
					Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
					FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
				}
			}
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00049200 File Offset: 0x00047400
		public static void Run_debug_tool_asw(string info)
		{
			Log.WriteToLog("Setting ASW to " + info);
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\asw.txt"))
				{
					streamWriter.WriteLine(info);
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\asw.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag2)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				try
				{
					Log.WriteToLog("Set ASW: Failed: " + ex.Message);
					Log.WriteToLog("Set ASW: Re-trying...");
					bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 1;
					if (flag3)
					{
						process.Start();
						process.WaitForExit();
						MySettingsProperty.Settings.DbgToolMethod = 2;
						MySettingsProperty.Settings.Save();
					}
					bool flag4 = MySettingsProperty.Settings.DbgToolMethod == 2;
					if (flag4)
					{
						global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
						MySettingsProperty.Settings.DbgToolMethod = 1;
						MySettingsProperty.Settings.Save();
					}
				}
				catch (Exception ex2)
				{
					Log.WriteToLog("Set ASW: Failed: " + ex2.Message);
					StackTrace stackTrace = new StackTrace(ex2, true);
					Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
					FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
				}
			}
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00049478 File Offset: 0x00047678
		public static void Run_debug_tool_fov(string info)
		{
			bool flag = Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0;
			if (flag)
			{
				Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting FOV to " + info.Replace(" ", ";"));
				FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting FOV to " + info.Replace(" ", ";"));
			}
			else
			{
				Log.WriteToLog("Setting FOV to " + info.Replace(" ", ";"));
				FrmMain.fmain.AddToListboxAndScroll("Setting FOV to " + info.Replace(" ", ";"));
			}
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\fov.txt"))
				{
					streamWriter.WriteLine("service set-client-fov-tan-angle-multiplier " + info);
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\fov.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag3)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Set FOV: Failed: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex.Message);
			}
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x000496E8 File Offset: 0x000478E8
		public static void Run_debug_tool_agps(string info)
		{
			bool flag = Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0;
			if (flag)
			{
				Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting Adaptive GPU Scaling to " + info);
				FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting Adaptive GPU Scaling to " + info);
			}
			else
			{
				Log.WriteToLog("Setting Adaptive GPU Scaling to " + info);
				FrmMain.fmain.AddToListboxAndScroll("Setting Adaptive GPU Scaling to " + info);
			}
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\agps.txt"))
				{
					streamWriter.WriteLine("service enable-adaptive-gpu-perf-scale " + info);
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\agps.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag3)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Set GPU Scaling: Failed: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex.Message);
			}
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0004991C File Offset: 0x00047B1C
		public static void Run_debug_tool_force_mipmap(string info)
		{
			bool flag = Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0;
			if (flag)
			{
				Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting Force MipMap Generation On All Layers to " + info.ToLower());
				FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting Force MipMap Generation On All Layers to " + info.ToLower());
			}
			else
			{
				Log.WriteToLog("Setting Force MipMap Generation On All Layers to " + info.ToLower());
				FrmMain.fmain.AddToListboxAndScroll("Setting Force MipMap Generation On All Layers to " + info.ToLower());
			}
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\force.txt"))
				{
					streamWriter.WriteLine("service set-force-mip-gen-on-all-layers " + info.ToLower());
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\force.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag3)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Setting force-mip-gen-on-all-layers: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex.Message);
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00049B68 File Offset: 0x00047D68
		public static void Run_debug_tool_offset_mipmap(string info)
		{
			bool flag = Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0;
			if (flag)
			{
				Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting Offset MipMap Bias On All Layers to " + info);
				FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting Offset MipMap Bias On All Layers to " + info);
			}
			else
			{
				Log.WriteToLog("Setting Offset MipMap Bias On All Layers to " + info);
				FrmMain.fmain.AddToListboxAndScroll("Setting Offset MipMap Bias On All Layers to " + info);
			}
			Process process = new Process();
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\offset.txt"))
				{
					streamWriter.WriteLine("service set-offset-mip-bias-on-all-layers " + info);
					streamWriter.WriteLine("exit");
				}
				process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\offset.txt\"")
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
				}
				bool flag2 = MySettingsProperty.Settings.DbgToolMethod == 1;
				if (flag2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
				}
				bool flag3 = MySettingsProperty.Settings.DbgToolMethod == 2;
				if (flag3)
				{
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Setting offset-mip-bias-on-all-layers: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex.Message);
			}
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00049D9C File Offset: 0x00047F9C
		public static void StartHome()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering StartHome");
			}
			try
			{
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				bool flag = processesByName.Length > 0;
				if (!flag)
				{
					FrmMain.fmain.AddToListboxAndScroll("Launching Oculus Home in " + Conversions.ToString(GetConfig.StartHomeDelay) + " seconds..");
					Log.WriteToLog("Launching Oculus Home");
					Thread.Sleep(checked(GetConfig.StartHomeDelay * 1000));
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Starting process " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\OculusClient.exe");
					}
					new Process
					{
						StartInfo = new ProcessStartInfo(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\OculusClient.exe")
						{
							UseShellExecute = true
						}
					}.Start();
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog("Process started");
					}
					bool dbg4 = Globals.dbg;
					if (dbg4)
					{
						Log.WriteToLog("Exiting StartHome");
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Warning: Could not launch Oculus Home: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex.Message);
			}
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00049F30 File Offset: 0x00048130
		public static void CloseDebugTool()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering CloseDebugTool");
			}
			checked
			{
				try
				{
					Log.WriteToLog("Checking for running instances of the OculusDebugTool");
					RunCommand.DebugToolInstances = 0;
					Process[] processesByName = Process.GetProcessesByName("OculusDebugToolCLI");
					foreach (Process process in processesByName)
					{
						try
						{
							process.Kill();
							RunCommand.DebugToolInstances++;
							Thread.Sleep(100);
						}
						catch (InvalidOperationException ex)
						{
							bool flag = (double)ex.HResult == Conversions.ToDouble("-2146233079 ");
							if (flag)
							{
								return;
							}
							Log.WriteToLog("Warning: CloseDebugTool: " + ex.Message);
						}
					}
					bool flag2 = RunCommand.DebugToolInstances > 0;
					if (flag2)
					{
						Log.WriteToLog("Killed " + Conversions.ToString(RunCommand.DebugToolInstances) + " running instances of the OculusDebugTool");
					}
					else
					{
						Log.WriteToLog("Found " + Conversions.ToString(RunCommand.DebugToolInstances) + " running instances of the OculusDebugTool");
					}
					bool flag3 = File.Exists(Application.StartupPath + "\\perf_info.txt");
					if (flag3)
					{
						File.Delete(Application.StartupPath + "\\perf_info.txt");
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("Deleted temporary file: perf_info.txt");
						}
					}
					bool flag4 = File.Exists(Application.StartupPath + "\\ppdp.txt");
					if (flag4)
					{
						File.Delete(Application.StartupPath + "\\ppdp.txt");
						bool dbg3 = Globals.dbg;
						if (dbg3)
						{
							Log.WriteToLog("Deleted temporary file: ppdp.txt");
						}
					}
					bool flag5 = File.Exists(Application.StartupPath + "\\usb.txt");
					if (flag5)
					{
						File.Delete(Application.StartupPath + "\\usb.txt");
						bool dbg4 = Globals.dbg;
						if (dbg4)
						{
							Log.WriteToLog("Deleted temporary file: usb.txt");
						}
					}
					bool flag6 = File.Exists(Application.StartupPath + "\\fov.txt");
					if (flag6)
					{
						File.Delete(Application.StartupPath + "\\fov.txt");
						bool dbg5 = Globals.dbg;
						if (dbg5)
						{
							Log.WriteToLog("Deleted temporary file: fov.txt");
						}
					}
					bool flag7 = File.Exists(Application.StartupPath + "\\agps.txt");
					if (flag7)
					{
						File.Delete(Application.StartupPath + "\\agps.txt");
						bool dbg6 = Globals.dbg;
						if (dbg6)
						{
							Log.WriteToLog("Deleted temporary file: agps.txt");
						}
					}
					bool flag8 = File.Exists(Application.StartupPath + "\\asw.txt");
					if (flag8)
					{
						File.Delete(Application.StartupPath + "\\asw.txt");
						bool dbg7 = Globals.dbg;
						if (dbg7)
						{
							Log.WriteToLog("Deleted temporary file: asw.txt");
						}
					}
					bool flag9 = File.Exists(Application.StartupPath + "\\force.txt");
					if (flag9)
					{
						File.Delete(Application.StartupPath + "\\force.txt");
						bool dbg8 = Globals.dbg;
						if (dbg8)
						{
							Log.WriteToLog("Deleted temporary file: force.txt");
						}
					}
					bool flag10 = File.Exists(Application.StartupPath + "\\offset.txt");
					if (flag10)
					{
						File.Delete(Application.StartupPath + "\\offset.txt");
						bool dbg9 = Globals.dbg;
						if (dbg9)
						{
							Log.WriteToLog("Deleted temporary file: offset.txt");
						}
					}
					bool dbg10 = Globals.dbg;
					if (dbg10)
					{
						Log.WriteToLog("Exiting CloseDebugTool");
					}
				}
				catch (Win32Exception ex2)
				{
					bool flag11 = Operators.CompareString(ex2.HResult.ToString(), "0x80004005", false) == 0;
					if (flag11)
					{
					}
				}
				catch (Exception ex3)
				{
					Log.WriteToLog("CloseDebugTool: " + ex3.Message);
					StackTrace stackTrace = new StackTrace(ex3, true);
					Log.WriteToLog(ex3.ToString() + stackTrace.ToString());
					FrmMain.fmain.AddToListboxAndScroll("* " + ex3.Message);
				}
			}
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0004A390 File Offset: 0x00048590
		public static void Run_PowerCFG(string name, string id)
		{
			try
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo("cmd.exe", "/c powercfg /setactive " + id)
				{
					UseShellExecute = false,
					CreateNoWindow = true
				};
				process.Start();
				process.WaitForExit();
				FrmMain.fmain.AddToListboxAndScroll("Power Plan set to " + name);
				PowerPlans.GetActivePowerPlan();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Run_PowerCFG: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex.Message);
			}
		}

		// Token: 0x04000365 RID: 869
		public static List<string> usb_suspend_list = new List<string>();

		// Token: 0x04000366 RID: 870
		public static int DebugToolInstances = 0;

		// Token: 0x04000367 RID: 871
		public static string debug_tool_path = "";
	}
}
