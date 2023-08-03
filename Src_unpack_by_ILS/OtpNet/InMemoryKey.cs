using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;

namespace OtpNet;

public class InMemoryKey : IKeyProvider
{
	private static readonly object platformSupportSync = Activator.CreateInstance(typeof(object));

	private readonly object stateSync = Activator.CreateInstance(typeof(object));

	private readonly byte[] KeyData;

	private readonly int keyLength;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InMemoryKey(byte[] key)
	{
		if (key != null)
		{
			if (key.Length == 0)
			{
				throw new ArgumentException("The key must not be empty");
			}
			keyLength = key.Length;
			int num = (int)Math.Ceiling((decimal)key.Length / 16m) * 16;
			KeyData = new byte[num];
			Array.Copy(key, KeyData, key.Length);
			return;
		}
		throw new ArgumentNullException("key");
	}

	internal unsafe T0[] GetCopyOfKey<T0, T1, T2>()
	{
		//IL_0015: Expected O, but got I4
		T0[] array = new T0[keyLength];
		T1 obj = (T1)stateSync;
		T2 lockTaken = (T2)0;
		try
		{
			Monitor.Enter(obj, ref *(bool*)(&lockTaken));
			Array.Copy(KeyData, array, keyLength);
		}
		finally
		{
			if (lockTaken != null)
			{
				Monitor.Exit(obj);
			}
		}
		return array;
	}

	public byte[] ComputeHmac(OtpHashMode mode, byte[] data)
	{
		byte[] result = null;
		using (HMAC hMAC = CreateHmacHash<HMAC, HMACSHA256, HMACSHA512, HMACSHA1>(mode))
		{
			byte[] copyOfKey = GetCopyOfKey<byte, object, bool>();
			try
			{
				hMAC.Key = copyOfKey;
				result = hMAC.ComputeHash(data);
			}
			finally
			{
				KeyUtilities.Destroy<bool, byte, Random>(copyOfKey);
			}
		}
		return result;
	}

	byte[] IKeyProvider.ComputeHmac(OtpHashMode mode, byte[] data)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ComputeHmac
		return this.ComputeHmac(mode, data);
	}

	private static T0 CreateHmacHash<T0, T1, T2, T3>(OtpHashMode otpHashMode)
	{
		T0 val = (T0)null;
		return otpHashMode switch
		{
			OtpHashMode.Sha512 => (T0)Activator.CreateInstance(typeof(HMACSHA512)), 
			OtpHashMode.Sha256 => (T0)Activator.CreateInstance(typeof(HMACSHA256)), 
			_ => (T0)Activator.CreateInstance(typeof(HMACSHA1)), 
		};
	}
}
