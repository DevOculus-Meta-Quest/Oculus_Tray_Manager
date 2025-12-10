using System;
using System.Collections.Generic;
using OculusTrayTool.My;

namespace OculusTrayTool
{
  internal sealed class GetControllers
  {
    public static Dictionary<string, Guid> joysticks = new Dictionary<string, Guid>();
    private static object joystickGuid = (object) Guid.Empty;
    public static bool ControllersFound = false;
    public static string selectedDevice;
    public static object joy; 
    public static bool joyAquired = false;

    public static void GetAllControllers()
    {
        Log.WriteToLog("GetAllControllers: Functionality disabled due to missing SharpDX.dll dependency.");
        ControllersFound = false;
    }

    public static void SelectController()
    {
    }

    public static void CaptureSelectedButton()
    {
         Log.WriteToLog("CaptureSelectedButton: Functionality disabled due to missing SharpDX.dll dependency.");
    }

    public static void CaptureButtonPushToTalk()
    {
         Log.WriteToLog("CaptureButtonPushToTalk: Functionality disabled due to missing SharpDX.dll dependency.");
    }
  }
}
