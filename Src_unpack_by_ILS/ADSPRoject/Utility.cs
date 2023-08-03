using System.Runtime.CompilerServices;

namespace ADSPRoject;

public class Utility
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T2 RateCurrency<T0, T1, T2>(T0 currency)
	{
		//IL_0011: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		T0 val = (T0)"CLP,COP,CRC,HUF,ISK,IDR,JPY,KRW,PYG,TWD,VND";
		T1 val2 = (T1)(!string.IsNullOrWhiteSpace((string)currency));
		if (val2 != null)
		{
			T1 val3 = (T1)((string)val).ToLower().Contains(((string)currency).ToLower());
			if (val3 != null)
			{
				return (T2)1;
			}
		}
		return (T2)100;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static T1 GetStatus<T0, T1>(T0 status)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected I4, but got Unknown
		T0 val = status;
		T0 val2 = val;
		switch (val2 - 1)
		{
		default:
			if ((nint)val2 != 100)
			{
				if ((nint)val2 != 101)
				{
					goto case 3;
				}
				return (T1)"temporarily unavailable";
			}
			return (T1)"pending closure";
		case 0:
			return (T1)frmMain.STATUS.Hoạt_động.ToString();
		case 1:
			return (T1)frmMain.STATUS.Die.ToString();
		case 2:
			return (T1)"Unsettled";
		case 6:
			return (T1)"Pending Review";
		case 3:
		case 4:
		case 5:
		case 7:
			return (T1)((int*)(&status))->ToString();
		case 8:
			return (T1)"In Grace Period";
		}
	}
}
