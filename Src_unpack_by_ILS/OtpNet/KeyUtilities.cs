using System;
using System.Runtime.CompilerServices;

namespace OtpNet;

internal class KeyUtilities
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Destroy<T0, T1, T2>(T1[] sensitiveData)
	{
		//IL_0005: Expected O, but got I4
		T0 val = (T0)(sensitiveData == null);
		if (val != null)
		{
			throw new ArgumentNullException("sensitiveData");
		}
		((Random)Activator.CreateInstance(typeof(Random))).NextBytes((byte[])(object)sensitiveData);
	}

	internal static byte[] GetBigEndianBytes(long input)
	{
		byte[] bytes = BitConverter.GetBytes(input);
		Array.Reverse(bytes);
		return bytes;
	}

	internal static byte[] GetBigEndianBytes(int input)
	{
		byte[] bytes = BitConverter.GetBytes(input);
		Array.Reverse(bytes);
		return bytes;
	}
}
