using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace OtpNet;

public static class KeyGeneration
{
	public static byte[] GenerateRandomKey(int length)
	{
		byte[] array = new byte[length];
		using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		randomNumberGenerator.GetBytes(array);
		return array;
	}

	public static byte[] GenerateRandomKey(OtpHashMode mode = OtpHashMode.Sha1)
	{
		return GenerateRandomKey(LengthForMode<int>(mode));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] DeriveKeyFromMaster(IKeyProvider masterKey, byte[] publicIdentifier, OtpHashMode mode = OtpHashMode.Sha1)
	{
		if (masterKey == null)
		{
			throw new ArgumentNullException("masterKey");
		}
		return masterKey.ComputeHmac(mode, publicIdentifier);
	}

	public static byte[] DeriveKeyFromMaster(IKeyProvider masterKey, int serialNumber, OtpHashMode mode = OtpHashMode.Sha1)
	{
		return DeriveKeyFromMaster(masterKey, KeyUtilities.GetBigEndianBytes(serialNumber), mode);
	}

	private static T0 GetHashAlgorithmForMode<T0>(OtpHashMode mode)
	{
		return mode switch
		{
			OtpHashMode.Sha256 => (T0)SHA256.Create(), 
			OtpHashMode.Sha512 => (T0)SHA512.Create(), 
			_ => (T0)SHA1.Create(), 
		};
	}

	private static T0 LengthForMode<T0>(OtpHashMode mode)
	{
		//IL_000f: Expected O, but got I4
		//IL_0014: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		return mode switch
		{
			OtpHashMode.Sha512 => (T0)64, 
			OtpHashMode.Sha256 => (T0)32, 
			_ => (T0)20, 
		};
	}
}
