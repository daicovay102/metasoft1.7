using System;
using System.Collections.Generic;

namespace ADSPRoject.Data;

[Serializable]
public class GroupFB
{
	public string UID { get; set; }

	public List<GroupFBEntity> listGroupFBEntity { get; set; }
}
