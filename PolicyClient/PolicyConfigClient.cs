// Decompiled with JetBrains decompiler

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
