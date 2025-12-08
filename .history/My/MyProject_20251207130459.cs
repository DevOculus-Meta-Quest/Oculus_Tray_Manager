using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Media; // For Audio

namespace OculusTrayTool.My
{
    internal static class MyProject
    {
        private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();
        private static readonly ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

        // Application property shim - might not be fully needed if we use System.Windows.Forms.Application
        // but existing code might access MyProject.Application.SaveMySettingsOnExit
        // We will stub what is needed.
        // internal static MyApplication Application { ... } // Removed for now, let's see errors.

        internal static MyComputer Computer => m_ComputerObjectProvider.GetInstance;
        internal static MyForms Forms => m_MyFormsObjectProvider.GetInstance;

        internal sealed class MyForms
        {
            // We use a simple field-backed lazy property pattern for each form
            private frmAbout m_frmAbout;
            public frmAbout frmAbout
            {
                get
                {
                    if (m_frmAbout == null || m_frmAbout.IsDisposed)
                        m_frmAbout = new frmAbout();
                    return m_frmAbout;
                }
                set => m_frmAbout = value;
            }

            private frmAddCustomVoice m_frmAddCustomVoice;
            public frmAddCustomVoice frmAddCustomVoice 
            {
                get { if (m_frmAddCustomVoice == null || m_frmAddCustomVoice.IsDisposed) m_frmAddCustomVoice = new frmAddCustomVoice(); return m_frmAddCustomVoice; }
                set => m_frmAddCustomVoice = value;
            }

            private frmAddVoiceProfile m_frmAddVoiceProfile;
            public frmAddVoiceProfile frmAddVoiceProfile
            {
                get { if (m_frmAddVoiceProfile == null || m_frmAddVoiceProfile.IsDisposed) m_frmAddVoiceProfile = new frmAddVoiceProfile(); return m_frmAddVoiceProfile; }
                set => m_frmAddVoiceProfile = value;
            }

            private frmCreateEditProfile m_frmCreateEditProfile;
            public frmCreateEditProfile frmCreateEditProfile
            {
                get { if (m_frmCreateEditProfile == null || m_frmCreateEditProfile.IsDisposed) m_frmCreateEditProfile = new frmCreateEditProfile(); return m_frmCreateEditProfile; }
                set => m_frmCreateEditProfile = value;
            }

            private frmDonate m_frmDonate;
            public frmDonate frmDonate
            {
                get { if (m_frmDonate == null || m_frmDonate.IsDisposed) m_frmDonate = new frmDonate(); return m_frmDonate; }
                set => m_frmDonate = value;
            }

            private frmDownloading m_frmDownloading;
            public frmDownloading frmDownloading
            {
                get { if (m_frmDownloading == null || m_frmDownloading.IsDisposed) m_frmDownloading = new frmDownloading(); return m_frmDownloading; }
                set => m_frmDownloading = value;
            }

            private frmEditAllSelected m_frmEditAllSelected;
            public frmEditAllSelected frmEditAllSelected
            {
                get { if (m_frmEditAllSelected == null || m_frmEditAllSelected.IsDisposed) m_frmEditAllSelected = new frmEditAllSelected(); return m_frmEditAllSelected; }
                set => m_frmEditAllSelected = value;
            }

            private frmEditVoiceCommand m_frmEditVoiceCommand;
            public frmEditVoiceCommand frmEditVoiceCommand
            {
                get { if (m_frmEditVoiceCommand == null || m_frmEditVoiceCommand.IsDisposed) m_frmEditVoiceCommand = new frmEditVoiceCommand(); return m_frmEditVoiceCommand; }
                set => m_frmEditVoiceCommand = value;
            }

            private frmHomeless m_frmHomeless;
            public frmHomeless frmHomeless
            {
                get { if (m_frmHomeless == null || m_frmHomeless.IsDisposed) m_frmHomeless = new frmHomeless(); return m_frmHomeless; }
                set => m_frmHomeless = value;
            }

            private frmHomeTrayToast m_frmHomeTrayToast;
            public frmHomeTrayToast frmHomeTrayToast
            {
                get { if (m_frmHomeTrayToast == null || m_frmHomeTrayToast.IsDisposed) m_frmHomeTrayToast = new frmHomeTrayToast(); return m_frmHomeTrayToast; }
                set => m_frmHomeTrayToast = value;
            }

            private frmHotKeys m_frmHotKeys;
            public frmHotKeys frmHotKeys
            {
                get { if (m_frmHotKeys == null || m_frmHotKeys.IsDisposed) m_frmHotKeys = new frmHotKeys(); return m_frmHotKeys; }
                set => m_frmHotKeys = value;
            }

            private FrmIgnoredApps m_FrmIgnoredApps;
            public FrmIgnoredApps FrmIgnoredApps
            {
                get { if (m_FrmIgnoredApps == null || m_FrmIgnoredApps.IsDisposed) m_FrmIgnoredApps = new FrmIgnoredApps(); return m_FrmIgnoredApps; }
                set => m_FrmIgnoredApps = value;
            }

            private frmImportSteamApps m_frmImportSteamApps;
            public frmImportSteamApps frmImportSteamApps
            {
                get { if (m_frmImportSteamApps == null || m_frmImportSteamApps.IsDisposed) m_frmImportSteamApps = new frmImportSteamApps(); return m_frmImportSteamApps; }
                set => m_frmImportSteamApps = value;
            }

            private frmLaunchOptions m_frmLaunchOptions;
            public frmLaunchOptions frmLaunchOptions
            {
                get { if (m_frmLaunchOptions == null || m_frmLaunchOptions.IsDisposed) m_frmLaunchOptions = new frmLaunchOptions(); return m_frmLaunchOptions; }
                set => m_frmLaunchOptions = value;
            }

            private frmLibrary m_frmLibrary;
            public frmLibrary frmLibrary
            {
                get { if (m_frmLibrary == null || m_frmLibrary.IsDisposed) m_frmLibrary = new frmLibrary(); return m_frmLibrary; }
                set => m_frmLibrary = value;
            }

            private frmLinkPresets m_frmLinkPresets;
            public frmLinkPresets frmLinkPresets
            {
                get { if (m_frmLinkPresets == null || m_frmLinkPresets.IsDisposed) m_frmLinkPresets = new frmLinkPresets(); return m_frmLinkPresets; }
                set => m_frmLinkPresets = value;
            }

            private frmLoading m_frmLoading;
            public frmLoading frmLoading
            {
                get { if (m_frmLoading == null || m_frmLoading.IsDisposed) m_frmLoading = new frmLoading(); return m_frmLoading; }
                set => m_frmLoading = value;
            }

            private FrmMain m_FrmMain;
            public FrmMain FrmMain
            {
                get { if (m_FrmMain == null || m_FrmMain.IsDisposed) m_FrmMain = new FrmMain(); return m_FrmMain; }
                set => m_FrmMain = value;
            }

            private frmMicNotDefaultWarning m_frmMicNotDefaultWarning;
            public frmMicNotDefaultWarning frmMicNotDefaultWarning
            {
                get { if (m_frmMicNotDefaultWarning == null || m_frmMicNotDefaultWarning.IsDisposed) m_frmMicNotDefaultWarning = new frmMicNotDefaultWarning(); return m_frmMicNotDefaultWarning; }
                set => m_frmMicNotDefaultWarning = value;
            }

            private frmProcessing m_frmProcessing;
            public frmProcessing frmProcessing
            {
                get { if (m_frmProcessing == null || m_frmProcessing.IsDisposed) m_frmProcessing = new frmProcessing(); return m_frmProcessing; }
                set => m_frmProcessing = value;
            }

            private frmProfiles m_frmProfiles;
            public frmProfiles frmProfiles
            {
                get { if (m_frmProfiles == null || m_frmProfiles.IsDisposed) m_frmProfiles = new frmProfiles(); return m_frmProfiles; }
                set => m_frmProfiles = value;
            }

            private frmProperties m_frmProperties;
            public frmProperties frmProperties
            {
                get { if (m_frmProperties == null || m_frmProperties.IsDisposed) m_frmProperties = new frmProperties(); return m_frmProperties; }
                set => m_frmProperties = value;
            }

            private frmRemoveProgress m_frmRemoveProgress;
            public frmRemoveProgress frmRemoveProgress
            {
                get { if (m_frmRemoveProgress == null || m_frmRemoveProgress.IsDisposed) m_frmRemoveProgress = new frmRemoveProgress(); return m_frmRemoveProgress; }
                set => m_frmRemoveProgress = value;
            }

            private FrmSetFallback m_FrmSetFallback;
            public FrmSetFallback FrmSetFallback
            {
                get { if (m_FrmSetFallback == null || m_FrmSetFallback.IsDisposed) m_FrmSetFallback = new FrmSetFallback(); return m_FrmSetFallback; }
                set => m_FrmSetFallback = value;
            }

            private frmSetLibraryPath m_frmSetLibraryPath;
            public frmSetLibraryPath frmSetLibraryPath
            {
                get { if (m_frmSetLibraryPath == null || m_frmSetLibraryPath.IsDisposed) m_frmSetLibraryPath = new frmSetLibraryPath(); return m_frmSetLibraryPath; }
                set => m_frmSetLibraryPath = value;
            }

            private frmSSChanged m_frmSSChanged;
            public frmSSChanged frmSSChanged
            {
                get { if (m_frmSSChanged == null || m_frmSSChanged.IsDisposed) m_frmSSChanged = new frmSSChanged(); return m_frmSSChanged; }
                set => m_frmSSChanged = value;
            }

            private frmStartupType m_frmStartupType;
            public frmStartupType frmStartupType
            {
                get { if (m_frmStartupType == null || m_frmStartupType.IsDisposed) m_frmStartupType = new frmStartupType(); return m_frmStartupType; }
                set => m_frmStartupType = value;
            }

            private frmStillRunningToast m_frmStillRunningToast;
            public frmStillRunningToast frmStillRunningToast
            {
                get { if (m_frmStillRunningToast == null || m_frmStillRunningToast.IsDisposed) m_frmStillRunningToast = new frmStillRunningToast(); return m_frmStillRunningToast; }
                set => m_frmStillRunningToast = value;
            }

            private frmUpdateToast m_frmUpdateToast;
            public frmUpdateToast frmUpdateToast
            {
                get { if (m_frmUpdateToast == null || m_frmUpdateToast.IsDisposed) m_frmUpdateToast = new frmUpdateToast(); return m_frmUpdateToast; }
                set => m_frmUpdateToast = value;
            }

            private frmVoiceSettings m_frmVoiceSettings;
            public frmVoiceSettings frmVoiceSettings
            {
                get { if (m_frmVoiceSettings == null || m_frmVoiceSettings.IsDisposed) m_frmVoiceSettings = new frmVoiceSettings(); return m_frmVoiceSettings; }
                set => m_frmVoiceSettings = value;
            }
        }

        internal sealed class MyComputer
        {
             internal MyAudio Audio { get; } = new MyAudio();
        }

        internal class MyAudio
        {
            public void Play(string location)
            {
               new SoundPlayer(location).Play();
            }
             public void Play(string location, AudioPlayMode mode)
            {
                 // AudioPlayMode enum logic mapping
                 // Background = 1
                 SoundPlayer sp = new SoundPlayer(location);
                 if(mode == AudioPlayMode.Background) sp.Play();
                 else sp.PlaySync();
            }
        }
        
        // Enum shim
        internal enum AudioPlayMode { Background, WaitToComplete }


        internal class ThreadSafeObjectProvider<T> where T : new()
        {
            [ThreadStatic]
            private static T m_ThreadStaticValue;

            internal T GetInstance
            {
                get
                {
                    if (m_ThreadStaticValue == null)
                        m_ThreadStaticValue = new T();
                    return m_ThreadStaticValue;
                }
            }
        }
    }
}
