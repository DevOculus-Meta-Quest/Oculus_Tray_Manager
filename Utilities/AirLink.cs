using MetaQuestTrayTool.Forms;

    using System;
    using System.Diagnostics;
    using System.IO;


#nullable disable
    namespace MetaQuestTrayTool
    {
        internal sealed class AirLink
        {
            public static string asar_check = "Get-Command -ErrorAction SilentlyContinue asar";
            public static string node_check = "Get-Command -ErrorAction SilentlyContinue node";
            public static string choco_check = "Get-Command -ErrorAction SilentlyContinue chocolatey";

            public static void EnableAirLink()
            {
                string str = Convert.ToString(DateAndTime.Now).Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");
                string cmd1 = "Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
                string cmd2 = "choco install nodejs -y";
                string arguments = "/C npm install -g --engine-strict asar";
                string cmd3 = "kill -ErrorAction SilentlyContinue -name OculusClient";
                
                if (!Convert.ToString(Packages.CheckCode("(New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')")).Contains("setTimeout(function enable() {"))
                {
                    Log.WriteToLinkLog("Could not download code, aborting");
                    FrmMain.fmain.AddToListboxAndScroll("Could not download code, aborting");
                }
                else
                {
                    string cmd4 = "Add-Content \"" + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app\\output\\main.js\" (New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')";
                    MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for chocolatey");
                    Log.WriteToLinkLog("Checking for chocolatey");
                    if (Equals(Packages.CheckPackage(AirLink.choco_check, ""), 0))
                    {
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing chocolatey..");
                        Log.WriteToLinkLog("chocolatey not installed, installing");
                        AirLink.RunPSCommand(cmd1);
                        if (!Equals(Packages.CheckPackage(AirLink.choco_check, "chocolatey"), 0))
                        {
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installed");
                        }
                        else
                        {
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installation failed");
                            Log.WriteToLinkLog("chocolatey installation failed");
                        }
                    }
                    else if (!Equals(Packages.CheckPackage(AirLink.choco_check, "chocolatey"), 0))
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey already installed");
                    if (!Equals(Packages.CheckPackage(AirLink.choco_check, ""), 0))
                    {
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for nodejs");
                        Log.WriteToLinkLog("Checking For nodejs");
                        if (Equals(Packages.CheckPackage(AirLink.node_check, ""), 0))
                        {
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing nodejs..");
                            Log.WriteToLinkLog("nodejs Not installed, installing");
                            AirLink.RunPSCommand(cmd2);
                            if (!Equals(Packages.CheckPackage(AirLink.node_check, "nodejs"), 0))
                            {
                                MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installed");
                            }
                            else
                            {
                                MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installation failed");
                                Log.WriteToLinkLog("nodejs installation failed");
                            }
                        }
                        else if (!Equals(Packages.CheckPackage(AirLink.node_check, "nodejs"), 0))
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs already installed");
                    }
                    if (!Equals(Packages.CheckPackage(AirLink.node_check, ""), 0))
                    {
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for asar");
                        Log.WriteToLinkLog("Checking for asar");
                        if (Equals(Packages.CheckPackage(AirLink.asar_check, ""), 0))
                        {
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing asar..");
                            Log.WriteToLinkLog("asar Not installed, installing");
                            AirLink.RunCMDCommand(arguments);
                            if (!Equals(Packages.CheckPackage(AirLink.asar_check, "asar"), 0))
                            {
                                MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installed");
                            }
                            else
                            {
                                MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installation failed");
                                Log.WriteToLinkLog("asar installation failed");
                            }
                        }
                        else if (!Equals(Packages.CheckPackage(AirLink.asar_check, "asar"), 0))
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("asar already installed");
                    }
                    if (!Equals(Packages.CheckPackage(AirLink.asar_check, ""), 0))
                    {
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Killing OculusClient if it's running");
                        Log.WriteToLinkLog("Killing OculusClient if it's running");
                        AirLink.RunPSCommand(cmd3);
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Backing up current app.asar to app.asar." + str);
                        Log.WriteToLinkLog("Backing up current app.asar to app.asar." + str);
                        File.Copy(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar", MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar." + str);
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Extracting app.asar");
                        Log.WriteToLinkLog("Extracting app.asar to " + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app");
                        AirLink.RunCMDCommand("/C asar extract \"" + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar\" \"" + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app\"");
                        MyProject.Forms.FrmMain.AddToListboxAndScroll("Verifying...");
                        Log.WriteToLinkLog("Verifying...");
                        if (!File.ReadAllText(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app\\output\\main.js").Contains("setTimeout(function enable() {"))
                        {
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is not patched, continuing");
                            Log.WriteToLinkLog("AirLink is not patched, continuing");
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("Downloading pd29's code and patching Link");
                            Log.WriteToLinkLog("Downloading latest version of pd29's code from https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js and patching Link");
                            AirLink.RunPSCommand(cmd4);
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("Compressing app.asar");
                            Log.WriteToLinkLog("Re-compressing app.asar");
                            AirLink.RunCMDCommand("/C asar pack \"" + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app\" \"" + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar\"");
                            if (Directory.Exists(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app"))
                            {
                                Log.WriteToLinkLog("Removing temporary directory " + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app");
                                Directory.Delete(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app", true);
                            }
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is patched!");
                            Log.WriteToLinkLog("AirLink is patched!");
                        }
                        else
                        {
                            MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is already patched, aborting");
                            Log.WriteToLinkLog("AirLink is already patched, aborting");
                            if (Directory.Exists(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app"))
                            {
                                Log.WriteToLinkLog("Removing temporary directory " + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app");
                                Directory.Delete(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app", true);
                            }
                            if (!File.Exists(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar." + str))
                                return;
                            Log.WriteToLinkLog("Removing backup " + MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar." + str);
                            File.Delete(MyProject.Forms.FrmMain.MetaPath + "Support\\oculus-client\\resources\\app.asar." + str);
                        }
                    }
                }
            }

            private static int RunPSCommand(string cmd)
            {
                int num = 0;
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
                        process.WaitForExit();
                        if (process.ExitCode == 0) num = 1; 
                    }
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    FrmMain.fmain.AddToListboxAndScroll(exception.Message);
                    Log.WriteToLinkLog($"RunPSCommand: {cmd}: {exception.Message}: {exception.StackTrace}");
                }
                return num;
            }

            private static void RunCMDCommand(string arguments)
            {
                try
                {
                    Process process = new Process()
                    {
                        StartInfo = new ProcessStartInfo()
                        {
                            FileName = "cmd.exe",
                            Arguments = arguments,
                            UseShellExecute = false,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        }
                    };
                    process.Start();
                    process.WaitForExit();
                    string end = process.StandardError.ReadToEnd();
      if (string.Equals(end, "", StringComparison.OrdinalIgnoreCase))
                        return;
                    MyProject.Forms.FrmMain.AddToListboxAndScroll(end);
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    Log.WriteToLinkLog("RunCMDCommand: " + arguments + " " + exception.Message + ": " + exception.StackTrace);
                }
            }
        }
    }

