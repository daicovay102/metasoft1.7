using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ADSPRoject.Server;

public class LocalStateData
{
	private const long CHROME_OFFSET = 11644473600000000L;

	public static T0 Get_Local_State<T0, T1, T2>()
	{
		return (T0)"tjbtgvuqkegrcyamsavq";
	}

	public static T0 GetExpireUtcFromChromeCookie<T0>(T0 chromCookieExpire)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		return (T0)(chromCookieExpire - 11644473600000000L);
	}

	public static T0[] SubArray<T0, T1>(T0[] array, T1 offset, T1 length)
	{
		//IL_0011: Expected I4, but got O
		//IL_0011: Expected I4, but got O
		T0[] array2 = new T0[(object)length];
		Array.Copy(array, (int)offset, array2, 0, (int)length);
		return array2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 RemoveInvalidChars<T0>(T0 strSource)
	{
		return (T0)Regex.Replace((string)strSource, "[^0-9a-zA-Z=+\\/]", "");
	}
}
