using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class Packages
{
	public static object CheckPackage(string cmd, string app)
	{
		int num = 0;
		try
		{
			using Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();
			using (Pipeline pipeline = runspace.CreatePipeline())
			{
				pipeline.Commands.AddScript(cmd);
				Collection<PSObject> collection = pipeline.Invoke();
				num = collection.Count;
				if ((num != 0) & (Operators.CompareString(app, "", TextCompare: false) != 0))
				{
					foreach (PSObject item in collection)
					{
						Log.WriteToLinkLog(app + " is installed in: " + item.Members["Source"].Value.ToString());
					}
				}
			}
			runspace.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLinkLog("CheckPackage: " + ex2.Message);
			MyProject.Forms.FrmMain.AddToListboxAndScroll(ex2.Message);
			ProjectData.ClearProjectError();
		}
		return num;
	}

	public static object CheckCode(string cmd)
	{
		int num = 0;
		try
		{
			using Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();
			using (Pipeline pipeline = runspace.CreatePipeline())
			{
				pipeline.Commands.AddScript(cmd);
				Collection<PSObject> collection = pipeline.Invoke();
				if (collection.Count != 0)
				{
					using IEnumerator<PSObject> enumerator = collection.GetEnumerator();
					if (enumerator.MoveNext())
					{
						PSObject current = enumerator.Current;
						return current.ToString();
					}
				}
			}
			runspace.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLinkLog("CheckPackage: " + ex2.Message);
			MyProject.Forms.FrmMain.AddToListboxAndScroll(ex2.Message);
			ProjectData.ClearProjectError();
		}
		return "0";
	}
}
