using System;
using System.Runtime.CompilerServices;

namespace OtpNet;

public class Base32Encoding
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T1[] ToBytes<T0, T1, T2, T3, T4>(T3 input)
	{
		//IL_0008: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_004f: Expected I4, but got O
		//IL_0051: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0097: Expected I4, but got O
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I4
		//IL_00cb: Expected I4, but got O
		T2 val = (T2)string.IsNullOrEmpty((string)input);
		if (val == null)
		{
			input = (T3)((string)input).TrimEnd((char[])(object)new T4[1] { (T4)61 });
			T0 val2 = (T0)(((string)input).Length * 5 / 8);
			T1[] array = new T1[(object)val2];
			T1 val3 = (T1)0;
			T1 val4 = (T1)8;
			T0 val5 = (T0)0;
			T0 val6 = (T0)0;
			T3 val7 = input;
			T0 val8 = (T0)0;
			while ((nint)val8 < ((string)val7).Length)
			{
				T4 c = (T4)((string)val7)[(int)val8];
				T0 val9 = CharToValue<T0, T2, T4>(c);
				T2 val10 = (T2)((nint)val4 > 5);
				if (val10 != null)
				{
					val5 = (T0)((object)val9 << ((val4 - 5) & 0x1F));
					val3 = (T1)(byte)((object)val3 | (object)val5);
					val4 = (T1)(byte)(val4 - 5);
				}
				else
				{
					val5 = (T0)((object)val9 >> ((5 - val4) & 0x1F));
					val3 = (T1)(byte)((object)val3 | (object)val5);
					T0 val11 = val6;
					val6 = (T0)(val11 + 1);
					((sbyte[])(object)array)[(object)val11] = (sbyte)(int)val3;
					val3 = (T1)(byte)((object)val9 << ((3 + val4) & 0x1F));
					val4 = (T1)(byte)(val4 + 3);
				}
				val8 = (T0)(val8 + 1);
			}
			T2 val12 = (T2)((object)val6 != (object)val2);
			if (val12 != null)
			{
				((sbyte[])(object)array)[(object)val6] = (sbyte)(int)val3;
			}
			return array;
		}
		throw new ArgumentNullException("input");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T4 ToString<T0, T1, T2, T3, T4>(T2[] input)
	{
		//IL_000d: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0064: Expected I4, but got O
		//IL_006a: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008b: Expected I4, but got O
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00cc: Expected I4, but got O
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e3: Expected O, but got I4
		T3 val = (T3)(input == null || input.Length == 0);
		if (val == null)
		{
			T0 val2 = (T0)((int)Math.Ceiling((double)input.Length / 5.0) * 8);
			T1[] array = new T1[(object)val2];
			T2 val3 = (T2)0;
			T2 val4 = (T2)5;
			T0 val5 = (T0)0;
			T0 val6 = (T0)0;
			while ((nint)val6 < input.Length)
			{
				T2 val7 = (T2)((byte[])(object)input)[(object)val6];
				val3 = (T2)(byte)((object)val3 | (object)((object)val7 >> ((8 - val4) & 0x1F)));
				T0 val8 = val5;
				val5 = (T0)(val8 + 1);
				((short[])(object)array)[(object)val8] = (short)(int)ValueToChar<T3, T1, T2>(val3);
				T3 val9 = (T3)((nint)val4 < 4);
				if (val9 != null)
				{
					val3 = (T2)(byte)(((object)val7 >> ((3 - val4) & 0x1F)) & 0x1F);
					T0 val10 = val5;
					val5 = (T0)(val10 + 1);
					((short[])(object)array)[(object)val10] = (short)(int)ValueToChar<T3, T1, T2>(val3);
					val4 = (T2)(byte)(val4 + 5);
				}
				val4 = (T2)(byte)(val4 - 3);
				val3 = (T2)(byte)(((object)val7 << (val4 & 0x1F)) & 0x1F);
				val6 = (T0)(val6 + 1);
			}
			T3 val11 = (T3)((object)val5 != (object)val2);
			if (val11 != null)
			{
				T0 val12 = val5;
				val5 = (T0)(val12 + 1);
				((short[])(object)array)[(object)val12] = (short)(int)ValueToChar<T3, T1, T2>(val3);
				while (true)
				{
					T3 val13 = (T3)((object)val5 != (object)val2);
					if (val13 != null)
					{
						T0 val14 = val5;
						val5 = (T0)(val14 + 1);
						((short[])(object)array)[(object)val14] = 61;
						continue;
					}
					break;
				}
			}
			return (T4)new string((char[])(object)array);
		}
		throw new ArgumentNullException("input");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T0 CharToValue<T0, T1, T2>(T2 c)
	{
		//IL_0010: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0028: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		T1 val = (T1)((nint)c < 91 && (nint)c > 64);
		if (val != null)
		{
			return (T0)(c - 65);
		}
		T1 val2 = (T1)((nint)c < 56 && (nint)c > 49);
		if (val2 == null)
		{
			T1 val3 = (T1)((nint)c < 123 && (nint)c > 96);
			if (val3 != null)
			{
				return (T0)(c - 97);
			}
			throw new ArgumentException("Character is not a Base32 character.", "c");
		}
		return (T0)(c - 24);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T1 ValueToChar<T0, T1, T2>(T2 b)
	{
		//IL_0006: Expected O, but got I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got I4
		T0 val = (T0)((nint)b < 26);
		if (val != null)
		{
			return (T1)(ushort)(b + 65);
		}
		T0 val2 = (T0)((nint)b < 32);
		if (val2 == null)
		{
			throw new ArgumentException("Byte is not a Base32 value.", "b");
		}
		return (T1)(ushort)(b + 24);
	}
}
