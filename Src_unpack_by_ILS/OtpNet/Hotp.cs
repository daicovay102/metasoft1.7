using System;
using System.Runtime.CompilerServices;

namespace OtpNet;

public class Hotp : Otp
{
	private readonly int hotpSize;

	public Hotp(byte[] secretKey, OtpHashMode mode = OtpHashMode.Sha1, int hotpSize = 6)
		: base(secretKey, mode)
	{
		VerifyParameters<bool, int>(hotpSize);
		this.hotpSize = hotpSize;
	}

	public Hotp(IKeyProvider key, OtpHashMode mode = OtpHashMode.Sha1, int hotpSize = 6)
		: base(key, mode)
	{
		VerifyParameters<bool, int>(hotpSize);
		this.hotpSize = hotpSize;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void VerifyParameters<T0, T1>(T1 hotpSize)
	{
		//IL_0005: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		T0 val = (T0)((nint)hotpSize < 6);
		if (val != null)
		{
			throw new ArgumentOutOfRangeException("hotpSize");
		}
		T0 val2 = (T0)((nint)hotpSize > 8);
		if (val2 != null)
		{
			throw new ArgumentOutOfRangeException("hotpSize");
		}
	}

	public T0 ComputeHOTP<T0, T1>(T1 counter)
	{
		//IL_000d: Expected I8, but got O
		return (T0)Compute((long)counter, hashMode);
	}

	public T0 VerifyHotp<T0, T1, T2>(T1 hotp, T2 counter)
	{
		//IL_000e: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		T0 val = (T0)((string)hotp == (string)ComputeHOTP<T1, T2>(counter));
		if (val != null)
		{
			return (T0)1;
		}
		return (T0)0;
	}

	protected override string Compute(long counter, OtpHashMode mode)
	{
		byte[] bigEndianBytes = KeyUtilities.GetBigEndianBytes(counter);
		long input = CalculateOtp<byte, int, long>(bigEndianBytes, mode);
		return Otp.Digits<int, string, long>(input, hotpSize);
	}
}
