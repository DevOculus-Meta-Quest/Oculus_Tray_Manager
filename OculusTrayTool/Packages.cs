using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000042 RID: 66
	[StandardModule]
	internal sealed class Packages
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x0002CE94 File Offset: 0x0002B094
		public static object CheckPackage(string cmd, string app)
		{
			int num = 0;
			try
			{
				using (Runspace runspace = RunspaceFactory.CreateRunspace())
				{
					runspace.Open();
					using (Pipeline pipeline = runspace.CreatePipeline())
					{
						pipeline.Commands.AddScript(cmd);
						Collection<PSObject> collection = pipeline.Invoke();
						num = collection.Count;
						bool flag = (num != 0) & (Operators.CompareString(app, "", false) != 0);
						if (flag)
						{
							try
							{
								foreach (PSObject psobject in collection)
								{
									Log.WriteToLinkLog(app + " is installed in: " + psobject.Members["Source"].Value.ToString());
								}
							}
							finally
							{
								IEnumerator<PSObject> enumerator;
								if (enumerator != null)
								{
									enumerator.Dispose();
								}
							}
						}
					}
					runspace.Close();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLinkLog("CheckPackage: " + ex.Message);
				MyProject.Forms.FrmMain.AddToListboxAndScroll(ex.Message);
			}
			return num;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0002CFF4 File Offset: 0x0002B1F4
		public static object CheckCode(string cmd)
		{
			try
			{
				using (Runspace runspace = RunspaceFactory.CreateRunspace())
				{
					runspace.Open();
					using (Pipeline pipeline = runspace.CreatePipeline())
					{
						pipeline.Commands.AddScript(cmd);
						Collection<PSObject> collection = pipeline.Invoke();
						int count = collection.Count;
						bool flag = count != 0;
						if (flag)
						{
							try
							{
								IEnumerator<PSObject> enumerator = collection.GetEnumerator();
								if (enumerator.MoveNext())
								{
									PSObject psobject = enumerator.Current;
									return psobject.ToString();
								}
							}
							finally
							{
								IEnumerator<PSObject> enumerator;
								if (enumerator != null)
								{
									enumerator.Dispose();
								}
							}
						}
					}
					runspace.Close();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLinkLog("CheckPackage: " + ex.Message);
				MyProject.Forms.FrmMain.AddToListboxAndScroll(ex.Message);
			}
			return "0";
		}
	}
}
