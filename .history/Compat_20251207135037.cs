using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Globalization;

namespace OculusTrayTool
{
    internal static class MyProject
    {
        public static MyForms Forms { get; } = new MyForms();
        public static MyComputer Computer { get; } = new MyComputer();

        public class MyForms
        {
            private T GetForm<T>() where T : Form, new()
            {
                // Return open form or create new one
                var form = Application.OpenForms.OfType<T>().FirstOrDefault();
                if (form == null || form.IsDisposed)
                    return new T();
                return form;
            }

            // Add all forms seen in FrmMain
            public FrmMain FrmMain => GetForm<FrmMain>();
            public frmLibrary frmLibrary => GetForm<frmLibrary>();
            public frmVoiceSettings frmVoiceSettings => GetForm<frmVoiceSettings>();
            public frmHomeless frmHomeless => GetForm<frmHomeless>();
            public frmProfiles frmProfiles => GetForm<frmProfiles>();
            public frmUpdateToast frmUpdateToast => GetForm<frmUpdateToast>();
            public frmAbout frmAbout => GetForm<frmAbout>();
            public frmLinkPresets frmLinkPresets => GetForm<frmLinkPresets>();
            public frmHomeTrayToast frmHomeTrayToast => GetForm<frmHomeTrayToast>();
            public frmCreateEditProfile frmCreateEditProfile => GetForm<frmCreateEditProfile>();
            public FrmSetFallback FrmSetFallback => GetForm<FrmSetFallback>();
            public frmDonate frmDonate => GetForm<frmDonate>();
            public frmStillRunningToast frmStillRunningToast => GetForm<frmStillRunningToast>();
            public frmLoading frmLoading => GetForm<frmLoading>();
            public frmImportSteamApps frmImportSteamApps => GetForm<frmImportSteamApps>();
            public frmHotKeys frmHotKeys => GetForm<frmHotKeys>();
            public frmAddCustomVoice frmAddCustomVoice => GetForm<frmAddCustomVoice>();
            public frmAddVoiceProfile frmAddVoiceProfile => GetForm<frmAddVoiceProfile>();
            public frmDownloading frmDownloading => GetForm<frmDownloading>();
            public frmEditAllSelected frmEditAllSelected => GetForm<frmEditAllSelected>();
            public frmEditVoiceCommand frmEditVoiceCommand => GetForm<frmEditVoiceCommand>();
            public FrmIgnoredApps FrmIgnoredApps => GetForm<FrmIgnoredApps>();
            public frmLaunchOptions frmLaunchOptions => GetForm<frmLaunchOptions>();
            public frmMicNotDefaultWarning frmMicNotDefaultWarning => GetForm<frmMicNotDefaultWarning>();
            public frmProcessing frmProcessing => GetForm<frmProcessing>();
            public frmProperties frmProperties => GetForm<frmProperties>();
            public frmRemoveProgress frmRemoveProgress => GetForm<frmRemoveProgress>();
            public frmSetLibraryPath frmSetLibraryPath => GetForm<frmSetLibraryPath>();
            public frmSSChanged frmSSChanged => GetForm<frmSSChanged>();
            public frmStartupType frmStartupType => GetForm<frmStartupType>();
        }

        public class MyComputer
        {
            public MyRegistry Registry { get; } = new MyRegistry();
            public MyAudio Audio { get; } = new MyAudio();
        }

        public class MyRegistry
        {
            public Microsoft.Win32.RegistryKey CurrentUser => Microsoft.Win32.Registry.CurrentUser;
            public Microsoft.Win32.RegistryKey LocalMachine => Microsoft.Win32.Registry.LocalMachine;
        }

        public class MyAudio
        {
            public void Play(string location)
            {
                Play(location, AudioPlayMode.Background);
            }

            public void Play(string location, AudioPlayMode playMode)
            {
                try
                {
                    using (SoundPlayer player = new SoundPlayer(location))
                    {
                        if (playMode == AudioPlayMode.WaitToComplete)
                            player.PlaySync();
                        else
                            player.Play();
                    }
                }
                catch { } // Ignore audio errors
            }
        }
    }

    public enum AudioPlayMode
    {
        Background,
        WaitToComplete,
        BackgroundLoop
    }

    internal static class Conversions
    {
         public static string ToString(object o) => Convert.ToString(o, CultureInfo.InvariantCulture);
         public static string ToString(bool b) => b.ToString();
         public static string ToString(double d) => d.ToString(CultureInfo.InvariantCulture);
         public static string ToString(int i) => i.ToString();
         public static string ToString(float f) => f.ToString(CultureInfo.InvariantCulture);

         public static double ToDouble(string s) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : 0;
         public static int ToInteger(string s) => int.TryParse(s, out var result) ? result : 0;
         public static int ToInteger(object o) => Convert.ToInt32(o);
         
         public static char ToChar(string s) => string.IsNullOrEmpty(s) ? '\0' : s[0];
         public static bool ToBoolean(object o) => Convert.ToBoolean(o);
         public static bool ToBoolean(string s) => bool.TryParse(s, out var result) ? result : false;
    }
    
    internal static class Strings
    {
        public static int Len(string s) => s?.Length ?? 0;
        public static string[] Split(string expression, string delimiter = " ", int limit = -1, CompareMethod compare = CompareMethod.Binary)
        {
             if (expression == null) return new string[0];
             return expression.Split(new[] { delimiter }, StringSplitOptions.None);
        }
        public static string Left(string str, int length)
        {
             if (string.IsNullOrEmpty(str)) return "";
             return str.Substring(0, Math.Min(length, str.Length));
        }
    }

    public enum CompareMethod
    {
        Binary,
        Text
    }

    internal static class Operators
    {
        public static int CompareString(string a, string b, bool textCompare)
        {
            return string.Compare(a, b, textCompare ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        public static bool ConditionalCompareObjectNotEqual(object a, object b, bool textCompare)
        {
            return !Equals(a, b);
        }

        public static bool ConditionalCompareObjectEqual(object a, object b, bool textCompare)
        {
            return Equals(a, b);
        }
    }

    internal static class Interaction
    {
        public static MsgBoxResult MsgBox(object prompt, MsgBoxStyle buttons = MsgBoxStyle.OKOnly, object title = null)
        {
             MessageBoxButtons btn = MessageBoxButtons.OK;
             if ((buttons & MsgBoxStyle.YesNo) == MsgBoxStyle.YesNo) btn = MessageBoxButtons.YesNo;
             
             MessageBoxIcon icon = MessageBoxIcon.None;
             if ((buttons & MsgBoxStyle.Critical) == MsgBoxStyle.Critical) icon = MessageBoxIcon.Error;
             if ((buttons & MsgBoxStyle.Exclamation) == MsgBoxStyle.Exclamation) icon = MessageBoxIcon.Exclamation;
             if ((buttons & MsgBoxStyle.Information) == MsgBoxStyle.Information) icon = MessageBoxIcon.Information;
             if ((buttons & MsgBoxStyle.Question) == MsgBoxStyle.Question) icon = MessageBoxIcon.Question;

             DialogResult res = MessageBox.Show(prompt?.ToString(), title?.ToString(), btn, icon);
             return (MsgBoxResult)res;
        }
    }

    public enum MsgBoxStyle
    {
        OKOnly = 0,
        YesNo = 4,
        Critical = 16,
        Question = 32,
        Exclamation = 48,
        Information = 64
    }

    public enum MsgBoxResult
    {
        OK = 1,
        Cancel = 2,
        Abort = 3,
        Retry = 4,
        Ignore = 5,
        Yes = 6,
        No = 7
    }
    
    internal static class FileSystem {
        public static void Rename(string file, string newName) {
            try {
                File.Move(file, newName);
            } catch (IOException) {
                throw;
            }
        }
    }

    public static class DateAndTime {
        public static DateTime TimeOfDay => DateTime.Now;
        public static DateTime Now => DateTime.Now;
    }

    internal static class ProjectData {
        public static void SetProjectError(Exception ex) {}
        public static void ClearProjectError() {}
        public static void EndApp() { Application.Exit(); }
    }
}
