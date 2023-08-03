using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OtpNet;

public class Totp : Otp
{
	private const long unixEpochTicks = 621355968000000000L;

	private const long ticksToSeconds = 10000000L;

	private readonly int step;

	private readonly int totpSize;

	private readonly TimeCorrection correctedTime;

	public Totp(byte[] secretKey, int step = 30, OtpHashMode mode = OtpHashMode.Sha1, int totpSize = 6, TimeCorrection timeCorrection = null)
		: base(secretKey, mode)
	{
		VerifyParameters<bool, int>(step, totpSize);
		this.step = step;
		this.totpSize = totpSize;
		correctedTime = timeCorrection ?? TimeCorrection.UncorrectedInstance;
	}

	public Totp(IKeyProvider key, int step = 30, OtpHashMode mode = OtpHashMode.Sha1, int totpSize = 6, TimeCorrection timeCorrection = null)
		: base(key, mode)
	{
		VerifyParameters<bool, int>(step, totpSize);
		this.step = step;
		this.totpSize = totpSize;
		correctedTime = timeCorrection ?? TimeCorrection.UncorrectedInstance;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void VerifyParameters<T0, T1>(T1 step, T1 totpSize)
	{
		//IL_0008: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		T0 val = (T0)((nint)step <= 0);
		if (val == null)
		{
			T0 val2 = (T0)((nint)totpSize <= 0);
			if (val2 != null)
			{
				throw new ArgumentOutOfRangeException("totpSize");
			}
			T0 val3 = (T0)((nint)totpSize > 10);
			if (val3 != null)
			{
				throw new ArgumentOutOfRangeException("totpSize");
			}
			return;
		}
		throw new ArgumentOutOfRangeException("step");
	}

	public string ComputeTotp(DateTime timestamp)
	{
		return ComputeTotpFromSpecificTime<long, string, DateTime>(correctedTime.GetCorrectedTime(timestamp));
	}

	public string ComputeTotp()
	{
		return ComputeTotpFromSpecificTime<long, string, DateTime>(correctedTime.CorrectedUtcNow);
	}

	private T1 ComputeTotpFromSpecificTime<T0, T1, T2>(T2 timestamp)
	{
		//IL_0015: Expected I8, but got O
		T0 val = CalculateTimeStepFromTimestamp<T0, T2>(timestamp);
		return (T1)Compute((long)val, hashMode);
	}

	public bool VerifyTotp(string totp, out long timeStepMatched, VerificationWindow window = null)
	{
		return VerifyTotpForSpecificTime<long, bool, DateTime, string, IEnumerator<long>>(correctedTime.CorrectedUtcNow, totp, window, out timeStepMatched);
	}

	public bool VerifyTotp(DateTime timestamp, string totp, out long timeStepMatched, VerificationWindow window = null)
	{
		return VerifyTotpForSpecificTime<long, bool, DateTime, string, IEnumerator<long>>(correctedTime.GetCorrectedTime(timestamp), totp, window, out timeStepMatched);
	}

	private T1 VerifyTotpForSpecificTime<T0, T1, T2, T3, T4>(T2 timestamp, T3 totp, VerificationWindow window, out long timeStepMatched)
	{
		T0 initialStep = CalculateTimeStepFromTimestamp<T0, T2>(timestamp);
		return Verify<T1, T4, T0, T3>(initialStep, totp, out timeStepMatched, window);
	}

	private unsafe T0 CalculateTimeStepFromTimestamp<T0, T1>(T1 timestamp)
	{
		//IL_001c: Expected O, but got I8
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		T0 val = (T0)((((DateTime*)(&timestamp))->Ticks - 621355968000000000L) / 10000000L);
		return (T0)(val / step);
	}

	public int RemainingSeconds()
	{
		return RemainingSecondsForSpecificTime<int, DateTime>(correctedTime.CorrectedUtcNow);
	}

	public int RemainingSeconds(DateTime timestamp)
	{
		return RemainingSecondsForSpecificTime<int, DateTime>(correctedTime.GetCorrectedTime(timestamp));
	}

	private unsafe T0 RemainingSecondsForSpecificTime<T0, T1>(T1 timestamp)
	{
		//IL_002c: Expected O, but got I4
		return (T0)(step - (int)((((DateTime*)(&timestamp))->Ticks - 621355968000000000L) / 10000000L % step));
	}

	protected override string Compute(long counter, OtpHashMode mode)
	{
		byte[] bigEndianBytes = KeyUtilities.GetBigEndianBytes(counter);
		long input = CalculateOtp<byte, int, long>(bigEndianBytes, mode);
		return Otp.Digits<int, string, long>(input, totpSize);
	}
}
