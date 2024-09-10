using System;

namespace OculusTrayTool
{
	// Token: 0x02000037 RID: 55
	public class MathTools
	{
		// Token: 0x060004E6 RID: 1254 RVA: 0x00023C2C File Offset: 0x00021E2C
		public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
		{
			T t = value;
			bool flag = value.CompareTo(min) < 0;
			if (flag)
			{
				t = min;
			}
			bool flag2 = value.CompareTo(max) > 0;
			if (flag2)
			{
				t = max;
			}
			return t;
		}
	}
}
