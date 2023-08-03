using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace ADSPRoject;

public class StringCipher
{
	private const int Keysize = 256;

	public static string passPhrase = "FDFDSFDDF-54564615-KLJLIPIP-4324324-YERERREFD";

	private const int DerivationIterations = 1000;

	public static List<string> listPageName = (List<string>)Activator.CreateInstance(typeof(List<string>));

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T2 getPageName<T0, T1, T2, T3>()
	{
		//IL_002c: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(Random));
		T1 val2 = (T1)(listPageName == null || listPageName.Count <= 0);
		if (val2 != null)
		{
			T3 val3 = (T3)new StreamReader("pagename.txt");
			while (true)
			{
				T2 val4;
				T1 val5 = (T1)((val4 = (T2)((TextReader)val3).ReadLine()) != null);
				if (val5 == null)
				{
					break;
				}
				T1 val6 = (T1)(!string.IsNullOrWhiteSpace((string)val4));
				if (val6 != null)
				{
					listPageName.Add(((string)val4).Trim());
				}
			}
			((TextReader)val3).Close();
		}
		return (T2)listPageName[((Random)val).Next(0, listPageName.Count - 1)];
	}

	public static string Encrypt(string plainText)
	{
		try
		{
			byte[] array = Generate256BitsOfRandomEntropy<byte, RNGCryptoServiceProvider>();
			byte[] array2 = Generate256BitsOfRandomEntropy<byte, RNGCryptoServiceProvider>();
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, array, 1000);
			byte[] bytes2 = rfc2898DeriveBytes.GetBytes(32);
			using RijndaelManaged rijndaelManaged = Activator.CreateInstance(typeof(RijndaelManaged));
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, array2);
			using MemoryStream memoryStream = Activator.CreateInstance(typeof(MemoryStream));
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] first = array;
			first = first.Concat(array2).ToArray();
			first = first.Concat(memoryStream.ToArray()).ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(first);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Encrypt(string plainText, string passPhrase)
	{
		try
		{
			byte[] array = Generate256BitsOfRandomEntropy<byte, RNGCryptoServiceProvider>();
			byte[] array2 = Generate256BitsOfRandomEntropy<byte, RNGCryptoServiceProvider>();
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, array, 1000);
			byte[] bytes2 = rfc2898DeriveBytes.GetBytes(32);
			using RijndaelManaged rijndaelManaged = Activator.CreateInstance(typeof(RijndaelManaged));
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, array2);
			using MemoryStream memoryStream = Activator.CreateInstance(typeof(MemoryStream));
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] first = array;
			first = first.Concat(array2).ToArray();
			first = first.Concat(memoryStream.ToArray()).ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(first);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Decrypt(string cipherText)
	{
		try
		{
			byte[] array = Convert.FromBase64String(cipherText);
			byte[] salt = array.Take(32).ToArray();
			byte[] rgbIV = array.Skip(32).Take(32).ToArray();
			byte[] array2 = array.Skip(64).Take(array.Length - 64).ToArray();
			using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, salt, 1000);
			byte[] bytes = rfc2898DeriveBytes.GetBytes(32);
			using RijndaelManaged rijndaelManaged = Activator.CreateInstance(typeof(RijndaelManaged));
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes, rgbIV);
			using MemoryStream memoryStream = new MemoryStream(array2);
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array3 = new byte[array2.Length];
			int count = cryptoStream.Read(array3, 0, array3.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array3, 0, count);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Decrypt(string cipherText, string passPhrase)
	{
		try
		{
			byte[] array = Convert.FromBase64String(cipherText);
			byte[] salt = array.Take(32).ToArray();
			byte[] rgbIV = array.Skip(32).Take(32).ToArray();
			byte[] array2 = array.Skip(64).Take(array.Length - 64).ToArray();
			using Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, salt, 1000);
			byte[] bytes = rfc2898DeriveBytes.GetBytes(32);
			using RijndaelManaged rijndaelManaged = Activator.CreateInstance(typeof(RijndaelManaged));
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			using ICryptoTransform transform = rijndaelManaged.CreateDecryptor(bytes, rgbIV);
			using MemoryStream memoryStream = new MemoryStream(array2);
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			byte[] array3 = new byte[array2.Length];
			int count = cryptoStream.Read(array3, 0, array3.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array3, 0, count);
		}
		catch (Exception)
		{
			return "";
		}
	}

	private static T0[] Generate256BitsOfRandomEntropy<T0, T1>()
	{
		T0[] array = new T0[32];
		T1 val = (T1)Activator.CreateInstance(typeof(RNGCryptoServiceProvider));
		try
		{
			((RandomNumberGenerator)val).GetBytes((byte[])(object)array);
		}
		finally
		{
			if (val != null)
			{
				((IDisposable)val).Dispose();
			}
		}
		return array;
	}
}
