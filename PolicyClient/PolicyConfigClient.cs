// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.PolicyClient.PolicyConfigClient
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using OculusTrayTool.CoreAudioApi.Interfaces;
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool.PolicyClient
{
  public class PolicyConfigClient
  {
    private readonly IPolicyConfig _PolicyConfig;
    private readonly IPolicyConfig10 _PolicyConfig10;

    public PolicyConfigClient()
    {
      this._PolicyConfig = new _PolicyConfigClient() as IPolicyConfig;
      if (this._PolicyConfig != null)
        return;
      this._PolicyConfig10 = new _PolicyConfigClient() as IPolicyConfig10;
    }

    public void SetDefaultEndpoint(string devID, ERole eRole)
    {
      if (this._PolicyConfig != null)
        Marshal.ThrowExceptionForHR(this._PolicyConfig.SetDefaultEndpoint(devID, eRole));
      else if (this._PolicyConfig10 != null)
        Marshal.ThrowExceptionForHR(this._PolicyConfig10.SetDefaultEndpoint(devID, eRole));
    }
  }
}
