using System.Text.RegularExpressions;

namespace ADSPRoject.Data;

public class Compound2Unicode
{
	public static T0 compound2Unicode<T0>(T0 str)
	{
		return (T0)Regex.Unescape((string)str);
	}
}
