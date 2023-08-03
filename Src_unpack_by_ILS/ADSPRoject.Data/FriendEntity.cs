using System;

namespace ADSPRoject.Data;

[Serializable]
public class FriendEntity
{
	public string CLONE_UID { get; set; }

	public string CLONE_Name { get; set; }

	public string VIA_UID { get; set; }

	public string Status { get; set; }
}
