using System;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace ADSPRoject;

public class RegeditKey
{
	private static string regedit = "SOFTWARE\\WinRAR";

	private static void MakeRegeditActivationCode()
	{
		Registry.CurrentUser.CreateSubKey(regedit);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T1 ReadRegeditKey<T0, T1>()
	{
		try
		{
			T0 val = (T0)Registry.CurrentUser.OpenSubKey(regedit, writable: true);
			return (T1)((RegistryKey)val).GetValue("frfic").ToString();
		}
		catch
		{
			SetRegeditKeyValue<T0, bool, T1>((T1)"");
			return (T1)"";
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T1 SetRegeditKeyValue<T0, T1, T2>(T2 value)
	{
		//IL_0017: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		try
		{
			T0 val = (T0)Registry.CurrentUser.OpenSubKey(regedit, writable: true);
			T1 val2 = (T1)(val == null);
			if (val2 != null)
			{
				MakeRegeditActivationCode();
				val = (T0)Registry.CurrentUser.OpenSubKey(regedit, writable: true);
			}
			((RegistryKey)val).SetValue("frfic", (object)value, RegistryValueKind.String);
			return (T1)1;
		}
		catch (Exception)
		{
			return (T1)0;
		}
	}
}
