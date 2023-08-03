using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ADSPRoject;

public static class ClipboardCom
{
	private const uint CF_UNICODETEXT = 13u;

	[DllImport("user32.dll")]
	private static extern bool EmptyClipboard();

	[DllImport("user32.dll")]
	private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

	[DllImport("user32.dll")]
	private static extern IntPtr GetClipboardData(uint uFormat);

	[DllImport("user32.dll")]
	private static extern bool IsClipboardFormatAvailable(uint format);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool OpenClipboard(IntPtr hWndNewOwner);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool CloseClipboard();

	[DllImport("kernel32.dll")]
	private static extern IntPtr GlobalLock(IntPtr hMem);

	[DllImport("kernel32.dll")]
	private static extern bool GlobalUnlock(IntPtr hMem);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetText<T0, T1, T2>(T2 nullTerminatedStr)
	{
		//IL_0023: Expected O, but got I
		//IL_002e: Expected I, but got O
		//IL_0047: Expected I, but got O
		//IL_0054: Expected I, but got O
		nullTerminatedStr = (T2)((string)nullTerminatedStr + "\0");
		T0[] bytes = (T0[])(object)Encoding.Unicode.GetBytes((string)nullTerminatedStr);
		T1 val = (T1)(nint)Marshal.AllocHGlobal(bytes.Length);
		Marshal.Copy((byte[])(object)bytes, 0, (IntPtr)val, bytes.Length);
		OpenClipboard(IntPtr.Zero);
		EmptyClipboard();
		SetClipboardData(13u, (IntPtr)val);
		CloseClipboard();
		Marshal.FreeHGlobal((IntPtr)val);
	}

	public static T0 GetText<T0, T1, T2>()
	{
		//IL_000b: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_002f: Expected O, but got I
		//IL_003a: Expected I, but got O
		//IL_003c: Expected O, but got I4
		//IL_0046: Expected I, but got O
		//IL_0048: Expected O, but got I
		//IL_0054: Expected I, but got O
		//IL_0056: Expected O, but got I4
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		T2 val = (T2)(!IsClipboardFormatAvailable(13u));
		if (val == null)
		{
			T2 val2 = (T2)(!OpenClipboard(IntPtr.Zero));
			if (val2 != null)
			{
				return (T0)null;
			}
			T0 result = (T0)null;
			T1 val3 = (T1)(nint)GetClipboardData(13u);
			T2 val4 = (T2)((IntPtr)val3 != IntPtr.Zero);
			if (val4 != null)
			{
				T1 val5 = (T1)(nint)GlobalLock((IntPtr)val3);
				T2 val6 = (T2)((IntPtr)val5 != IntPtr.Zero);
				if (val6 != null)
				{
					result = (T0)Marshal.PtrToStringUni((IntPtr)val5);
					GlobalUnlock((IntPtr)val5);
				}
			}
			CloseClipboard();
			return result;
		}
		return (T0)null;
	}
}
