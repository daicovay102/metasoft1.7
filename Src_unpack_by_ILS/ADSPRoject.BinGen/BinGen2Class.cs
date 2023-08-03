using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CreditCardValidator;

namespace ADSPRoject.BinGen;

public class BinGen2Class
{
	private sealed class Class20
	{
		internal T0 method_0<T0, T1>(T1 char_0)
		{
			//IL_0006: Expected O, but got I4
			return (T0)((nint)char_0 == 120);
		}
	}

	public static Random Rand = (Random)Activator.CreateInstance(typeof(Random));

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static T1 getCardGen<T0, T1, T2, T3, T4, T5, T6, T7>(T1 string_0)
	{
		//IL_000c: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0081: Expected O, but got I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0097: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		T3 val = (T3)(((string)string_0).Length < 13);
		if (val != null)
		{
			T3 val2 = (T3)((nint)((IEnumerable<T6>)string_0).First() == 51);
			string_0 = (T1)((val2 == null) ? ((string)string_0).PadRight(16, 'x') : ((string)string_0).PadRight(15, 'x'));
		}
		T0 val3 = (T0)((IEnumerable<T6>)(object)((string)string_0).ToCharArray()).Count((Func<T6, bool>)(object)new Func<char, bool>(method_0<T3, T6>));
		T1 val4;
		T3 val9;
		do
		{
			val4 = string_0;
			T4 val5 = (T4)new Regex(Regex.Escape("x"));
			T0 val6 = (T0)0;
			while (true)
			{
				T3 val7 = (T3)(val6 < val3);
				if (val7 == null)
				{
					break;
				}
				val4 = (T1)((Regex)val5).Replace((string)val4, System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)Rand.Next(0, 9)).ToString(), 1);
				val6 = (T0)(val6 + 1);
			}
			T2 val8 = (T2)new CreditCardDetector((string)val4);
			val9 = (T3)(!((CreditCardDetector)val8).IsValid());
		}
		while (val9 != null);
		T0 val10 = (T0)Rand.Next(1, 12);
		T3 val11 = (T3)((nint)val10 >= 10);
		T1 val12 = (T1)((val11 != null) ? string.Concat(val10) : ("0" + *(int*)(&val10)));
		return (T1)string.Concat((T7)val4, (T7)"|", (T7)val12, (T7)"|", (T7)(object)(T0)Rand.Next(((DateTime)(T5)DateTime.Now).Year + 1, ((DateTime)(T5)DateTime.Now).Year + 4), (T7)"|", (T7)(object)(T0)(((nint)((IEnumerable<T6>)string_0).First() == 51) ? Rand.Next(1000, 9999) : Rand.Next(100, 999)));
	}

	public static T0 method_0<T0, T1>(T1 char_0)
	{
		//IL_0006: Expected O, but got I4
		return (T0)((nint)char_0 == 120);
	}
}
