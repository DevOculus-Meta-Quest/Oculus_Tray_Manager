using OculusTrayTool.Forms;


    using OculusTrayTool.My;
    using System;
    using System.Diagnostics;
    using System.IO;

#nullable disable
    namespace OculusTrayTool
    {

        internal sealed class Packages
        {
            public static object CheckPackage(string cmd, string app)
            {
                int num = 0;
                try
                {
                    string psCommand = cmd;
                    if (!string.IsNullOrEmpty(app))
                    {
                        psCommand += " | Select-Object -ExpandProperty Source";
                    }

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psCommand}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(startInfo))
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        if (!string.IsNullOrWhiteSpace(output))
                        {
                            num = 1; // Assume found if output exists
                            if (!string.IsNullOrEmpty(app))
                            {
                                string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string line in lines)
                                {
                                    Log.WriteToLinkLog(app + " is installed in: " + line.Trim());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    Log.WriteToLinkLog("CheckPackage: " + exception.Message);
                    MyProject.Forms.FrmMain.AddToListboxAndScroll(exception.Message);
                    // ProjectData.ClearProjectError();
                }
                return (object)num;
            }

            public static object CheckCode(string cmd)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{cmd}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(startInfo))
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                        
                        if (!string.IsNullOrWhiteSpace(output))
                        {
                            return (object)output.Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    Log.WriteToLinkLog("CheckCode: " + exception.Message);
                    MyProject.Forms.FrmMain.AddToListboxAndScroll(exception.Message);
                    // ProjectData.ClearProjectError();
                }
                return (object)"0";
            }
        }
    }

