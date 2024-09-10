using System;
using System.Runtime.InteropServices;
using CoreAudio;
using OculusTrayTool.CoreAudioApi.Interfaces;

namespace OculusTrayTool.PolicyClient
{
	// Token: 0x02000044 RID: 68
	public class PolicyConfigClient
	{
		// Token: 0x06000583 RID: 1411 RVA: 0x0002D124 File Offset: 0x0002B324
		public PolicyConfigClient()
		{
			this._PolicyConfig = new _PolicyConfigClient() as IPolicyConfig;
			bool flag = this._PolicyConfig != null;
			if (!flag)
			{
				this._PolicyConfig10 = new _PolicyConfigClient() as IPolicyConfig10;
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0002D16C File Offset: 0x0002B36C
		public void SetDefaultEndpoint(string devID, ERole eRole)
		{
			bool flag = this._PolicyConfig != null;
			if (flag)
			{
				Marshal.ThrowExceptionForHR(this._PolicyConfig.SetDefaultEndpoint(devID, eRole));
			}
			else
			{
				bool flag2 = this._PolicyConfig10 != null;
				if (flag2)
				{
					Marshal.ThrowExceptionForHR(this._PolicyConfig10.SetDefaultEndpoint(devID, eRole));
				}
			}
		}

		// Token: 0x04000212 RID: 530
		private readonly IPolicyConfig _PolicyConfig;

		// Token: 0x04000213 RID: 531
		private readonly IPolicyConfig10 _PolicyConfig10;
	}
}
