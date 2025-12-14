using System;
using System.Collections.Generic;
using MetaQuestTrayTool.My;
using SharpDX.DirectInput;
using System.Linq;
using MetaQuestTrayTool.Forms;

namespace MetaQuestTrayTool
{
  internal sealed class GetControllers
  {
    public static Dictionary<string, Guid> joysticks = new Dictionary<string, Guid>();
    private static DirectInput directInput = new DirectInput();
    public static bool ControllersFound = false;
    public static string selectedDevice;
    public static Joystick joy; 
    public static bool joyAquired = false;

    public static void GetAllControllers()
    {
        try 
        {
            joysticks.Clear();
            var devices = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            
            foreach (var deviceInstance in devices)
            {
                if (!joysticks.ContainsKey(deviceInstance.InstanceName))
                {
                    joysticks.Add(deviceInstance.InstanceName, deviceInstance.InstanceGuid);
                }
            }

            if (joysticks.Count > 0)
            {
                ControllersFound = true;
                Log.WriteToLog("Found " + joysticks.Count + " controllers");
            }
            else
            {
                ControllersFound = false;
                Log.WriteToLog("No controllers found");
            }
        }
        catch (Exception ex)
        {
            Log.WriteToLog("Error enumerating controllers: " + ex.Message);
            ControllersFound = false;
        }
    }

    public static void SelectController()
    {
        try
        {
            if (string.IsNullOrEmpty(selectedDevice) || !joysticks.ContainsKey(selectedDevice)) return;

            joy = new Joystick(directInput, joysticks[selectedDevice]);
            joy.Acquire();
            joyAquired = true;
        }
        catch (Exception ex)
        {
            Log.WriteToLog("Error acquiring controller: " + ex.Message);
            joyAquired = false;
        }
    }

    public static void CaptureSelectedButton()
    {
         // Stub: polling logic would go here, usually run in a timer or separate thread
         // For now, we just ensure the device is acquired
         if (!joyAquired && !string.IsNullOrEmpty(selectedDevice))
         {
             SelectController();
         }
    }

    public static void CaptureButtonPushToTalk()
    {
         // Stub: similar to above
    }
  }
}
