using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OtpNet;

public abstract class Otp
{
	protected readonly IKeyProvider secretKey;

	protected readonly OtpHashMode hashMode;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Otp(byte[] secretKey, OtpHashMode mode)
	{
		if (secretKey != null)
		{
			if (secretKey.Length == 0)
			{
				throw new ArgumentException("secretKey empty");
			}
			this.secretKey = new InMemoryKey(secretKey);
			hashMode = mode;
			return;
		}
		throw new ArgumentNullException("secretKey");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Otp(IKeyProvider key, OtpHashMode mode)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		secretKey = key;
		hashMode = mode;
	}

	protected abstract string Compute(long counter, OtpHashMode mode);

	protected internal T2 CalculateOtp<T0, T1, T2>(T0[] data, OtpHashMode mode)
	{
		//IL_0019: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got I8
		T0[] array = (T0[])(object)secretKey.ComputeHmac(mode, (byte[])(object)data);
		T1 val = (T1)(((byte[])(object)array)[array.Length - 1] & 0xF);
		return (T2)(((((byte[])(object)array)[(object)val] & 0x7F) << 24) | ((((byte[])(object)array)[val + 1] & 0xFF) << 16) | ((((byte[])(object)array)[val + 2] & 0xFF) << 8) | ((((byte[])(object)array)[val + 3] & 0xFF) % 1000000));
	}

	protected internal static T1 Digits<T0, T1, T2>(T2 input, T0 digitCount)
	{
		//IL_0015: Expected O, but got I4
		//IL_0024: Expected I4, but got O
		return (T1)System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)((int)input % (int)Math.Pow(10.0, (double)digitCount))).ToString().PadLeft((int)digitCount, '0');
	}

	protected T0 Verify<T0, T1, T2, T3>(T2 initialStep, T3 valueToVerify, out long matchedStep, VerificationWindow window)
	{
		//IL_0006: Expected O, but got I4
		//IL_002a: Expected O, but got I8
		//IL_0037: Expected I8, but got O
		//IL_0053: Expected I8, but got O
		//IL_0056: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		T0 val = (T0)(window == null);
		if (val != null)
		{
			window = new VerificationWindow();
		}
		T1 enumerator = (T1)window.ValidationCandidates<IEnumerable<long>, T2>(initialStep).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				T2 val2 = (T2)((IEnumerator<long>)enumerator).Current;
				T3 a = (T3)Compute((long)val2, hashMode);
				T0 val3 = ValuesEqual<int, T0, T3>(a, valueToVerify);
				if (val3 != null)
				{
					matchedStep = (long)val2;
					return (T0)1;
				}
			}
		}
		finally
		{
			if (enumerator != null)
			{
				((IDisposable)enumerator).Dispose();
			}
		}
		matchedStep = 0L;
		return (T0)0;
	}

	private T1 ValuesEqual<T0, T1, T2>(T2 a, T2 b)
	{
		//IL_0012: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_001b: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0027: Expected I4, but got O
		//IL_002e: Expected I4, but got O
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		T1 val = (T1)(((string)a).Length != ((string)b).Length);
		if (val != null)
		{
			return (T1)0;
		}
		T0 val2 = (T0)0;
		T0 val3 = (T0)0;
		while (true)
		{
			T1 val4 = (T1)((nint)val3 < ((string)a).Length);
			if (val4 == null)
			{
				break;
			}
			val2 = (T0)(val2 | (((string)a)[(int)val3] ^ ((string)b)[(int)val3]));
			val3 = (T0)(val3 + 1);
		}
		return (T1)(val2 == null);
	}
}
