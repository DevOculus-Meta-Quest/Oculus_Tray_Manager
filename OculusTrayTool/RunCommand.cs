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

namespace OculusTrayTool;

[StandardModule]
internal sealed class RunCommand
{
	public static List<string> usb_suspend_list = new List<string>();

	public static int DebugToolInstances = 0;

	public static string debug_tool_path = "";

	public static void Run_debug_tool(string ss)
	{
		if (Operators.CompareString(FrmMain.fmain.runningApp, "", TextCompare: false) != 0)
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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\ppdp.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			try
			{
				Log.WriteToLog("Set SuperSampling: Failed: " + ex2.Message);
				Log.WriteToLog("Set SuperSampling: Re-trying...");
				if (MySettingsProperty.Settings.DbgToolMethod == 1)
				{
					process.Start();
					process.WaitForExit();
					MySettingsProperty.Settings.DbgToolMethod = 2;
					MySettingsProperty.Settings.Save();
				}
				if (MySettingsProperty.Settings.DbgToolMethod == 2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
					MySettingsProperty.Settings.DbgToolMethod = 1;
					MySettingsProperty.Settings.Save();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("Set SuperSampling: Failed: " + ex4.Message);
				StackTrace stackTrace = new StackTrace(ex4, fNeedFileInfo: true);
				Log.WriteToLog(ex4.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex4.Message);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
	}

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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\perf.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			try
			{
				Log.WriteToLog("Set Info Overlay: Failed: " + ex2.Message);
				Log.WriteToLog("Set Info Overlay: Re-trying...");
				if (MySettingsProperty.Settings.DbgToolMethod == 1)
				{
					process.Start();
					process.WaitForExit();
					MySettingsProperty.Settings.DbgToolMethod = 2;
					MySettingsProperty.Settings.Save();
				}
				if (MySettingsProperty.Settings.DbgToolMethod == 2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
					MySettingsProperty.Settings.DbgToolMethod = 1;
					MySettingsProperty.Settings.Save();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("Warning: Set Info Overlay: " + ex4.Message);
				StackTrace stackTrace = new StackTrace(ex4, fNeedFileInfo: true);
				Log.WriteToLog(ex4.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex4.Message);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
	}

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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\asw.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			try
			{
				Log.WriteToLog("Set ASW: Failed: " + ex2.Message);
				Log.WriteToLog("Set ASW: Re-trying...");
				if (MySettingsProperty.Settings.DbgToolMethod == 1)
				{
					process.Start();
					process.WaitForExit();
					MySettingsProperty.Settings.DbgToolMethod = 2;
					MySettingsProperty.Settings.Save();
				}
				if (MySettingsProperty.Settings.DbgToolMethod == 2)
				{
					global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
					MySettingsProperty.Settings.DbgToolMethod = 1;
					MySettingsProperty.Settings.Save();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("Set ASW: Failed: " + ex4.Message);
				StackTrace stackTrace = new StackTrace(ex4, fNeedFileInfo: true);
				Log.WriteToLog(ex4.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex4.Message);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void Run_debug_tool_fov(string info)
	{
		if (Operators.CompareString(FrmMain.fmain.runningApp, "", TextCompare: false) != 0)
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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\fov.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Set FOV: Failed: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void Run_debug_tool_agps(string info)
	{
		if (Operators.CompareString(FrmMain.fmain.runningApp, "", TextCompare: false) != 0)
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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\agps.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Set GPU Scaling: Failed: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void Run_debug_tool_force_mipmap(string info)
	{
		if (Operators.CompareString(FrmMain.fmain.runningApp, "", TextCompare: false) != 0)
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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\force.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Setting force-mip-gen-on-all-layers: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void Run_debug_tool_offset_mipmap(string info)
	{
		if (Operators.CompareString(FrmMain.fmain.runningApp, "", TextCompare: false) != 0)
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
			ProcessStartInfo processStartInfo = new ProcessStartInfo("\"" + debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\offset.txt\"");
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			if (Globals.dbg)
			{
				Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 1)
			{
				global::UACHelper.UACHelper.StartWithShell(process.StartInfo);
			}
			if (MySettingsProperty.Settings.DbgToolMethod == 2)
			{
				process.Start();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Setting offset-mip-bias-on-all-layers: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void StartHome()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering StartHome");
		}
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			if (processesByName.Length <= 0)
			{
				FrmMain.fmain.AddToListboxAndScroll("Launching Oculus Home in " + Conversions.ToString(GetConfig.StartHomeDelay) + " seconds..");
				Log.WriteToLog("Launching Oculus Home");
				Thread.Sleep(checked(GetConfig.StartHomeDelay * 1000));
				if (Globals.dbg)
				{
					Log.WriteToLog("Starting process " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\OculusClient.exe");
				}
				Process process = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\OculusClient.exe");
				processStartInfo.UseShellExecute = true;
				process.StartInfo = processStartInfo;
				process.Start();
				if (Globals.dbg)
				{
					Log.WriteToLog("Process started");
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("Exiting StartHome");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Warning: Could not launch Oculus Home: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void CloseDebugTool()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CloseDebugTool");
		}
		checked
		{
			try
			{
				Log.WriteToLog("Checking for running instances of the OculusDebugTool");
				DebugToolInstances = 0;
				Process[] processesByName = Process.GetProcessesByName("OculusDebugToolCLI");
				Process[] array = processesByName;
				foreach (Process process in array)
				{
					try
					{
						process.Kill();
						DebugToolInstances++;
						Thread.Sleep(100);
					}
					catch (InvalidOperationException ex)
					{
						ProjectData.SetProjectError(ex);
						InvalidOperationException ex2 = ex;
						if ((double)ex2.HResult == Conversions.ToDouble("-2146233079 "))
						{
							ProjectData.ClearProjectError();
							return;
						}
						Log.WriteToLog("Warning: CloseDebugTool: " + ex2.Message);
						ProjectData.ClearProjectError();
					}
				}
				if (DebugToolInstances > 0)
				{
					Log.WriteToLog("Killed " + Conversions.ToString(DebugToolInstances) + " running instances of the OculusDebugTool");
				}
				else
				{
					Log.WriteToLog("Found " + Conversions.ToString(DebugToolInstances) + " running instances of the OculusDebugTool");
				}
				if (File.Exists(Application.StartupPath + "\\perf_info.txt"))
				{
					File.Delete(Application.StartupPath + "\\perf_info.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: perf_info.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\ppdp.txt"))
				{
					File.Delete(Application.StartupPath + "\\ppdp.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: ppdp.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\usb.txt"))
				{
					File.Delete(Application.StartupPath + "\\usb.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: usb.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\fov.txt"))
				{
					File.Delete(Application.StartupPath + "\\fov.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: fov.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\agps.txt"))
				{
					File.Delete(Application.StartupPath + "\\agps.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: agps.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\asw.txt"))
				{
					File.Delete(Application.StartupPath + "\\asw.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: asw.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\force.txt"))
				{
					File.Delete(Application.StartupPath + "\\force.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: force.txt");
					}
				}
				if (File.Exists(Application.StartupPath + "\\offset.txt"))
				{
					File.Delete(Application.StartupPath + "\\offset.txt");
					if (Globals.dbg)
					{
						Log.WriteToLog("Deleted temporary file: offset.txt");
					}
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("Exiting CloseDebugTool");
				}
			}
			catch (Win32Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Win32Exception ex4 = ex3;
				if (Operators.CompareString(ex4.HResult.ToString(), "0x80004005", TextCompare: false) == 0)
				{
					ProjectData.ClearProjectError();
				}
				else
				{
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				Log.WriteToLog("CloseDebugTool: " + ex6.Message);
				StackTrace stackTrace = new StackTrace(ex6, fNeedFileInfo: true);
				Log.WriteToLog(ex6.ToString() + stackTrace.ToString());
				FrmMain.fmain.AddToListboxAndScroll("* " + ex6.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void Run_PowerCFG(string name, string id)
	{
		try
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c powercfg /setactive " + id);
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.Start();
			process.WaitForExit();
			FrmMain.fmain.AddToListboxAndScroll("Power Plan set to " + name);
			PowerPlans.GetActivePowerPlan();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Run_PowerCFG: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			FrmMain.fmain.AddToListboxAndScroll("* " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}
}
