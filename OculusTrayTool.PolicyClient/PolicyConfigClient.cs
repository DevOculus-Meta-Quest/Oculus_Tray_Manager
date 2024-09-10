using System.Runtime.InteropServices;
using CoreAudio;
using OculusTrayTool.CoreAudioApi.Interfaces;

namespace OculusTrayTool.PolicyClient;

public class PolicyConfigClient
{
	private readonly IPolicyConfig _PolicyConfig;

	private readonly IPolicyConfig10 _PolicyConfig10;

	public PolicyConfigClient()
	{
		_PolicyConfig = new _PolicyConfigClient() as IPolicyConfig;
		if (_PolicyConfig == null)
		{
			_PolicyConfig10 = new _PolicyConfigClient() as IPolicyConfig10;
		}
	}

	public void SetDefaultEndpoint(string devID, ERole eRole)
	{
		if (_PolicyConfig != null)
		{
			Marshal.ThrowExceptionForHR(_PolicyConfig.SetDefaultEndpoint(devID, eRole));
		}
		else if (_PolicyConfig10 != null)
		{
			Marshal.ThrowExceptionForHR(_PolicyConfig10.SetDefaultEndpoint(devID, eRole));
		}
	}
}
