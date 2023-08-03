using System.Runtime.CompilerServices;

namespace ADSPRoject.Data;

public class ProxySocksEntity
{
	public string Username { get; set; }

	public string Password { get; set; }

	public string IP { get; set; }

	public string Port { get; set; }

	public string Status { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 ToString<T0, T1>()
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(!string.IsNullOrWhiteSpace(Username));
		if (val != null)
		{
			return (T1)string.Concat((string[])(object)new T1[7]
			{
				(T1)Username,
				(T1)":",
				(T1)Password,
				(T1)"@",
				(T1)IP,
				(T1)":",
				(T1)Port
			});
		}
		return (T1)(IP + ":" + Port);
	}
}
