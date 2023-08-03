using System.Collections.Generic;

namespace ADSPRoject.Data.API;

public class ResouceParameter
{
	public string User_Token { get; set; }

	public string Resouce_Name { get; set; }

	public Dictionary<string, string> Parameter { get; set; }
}
