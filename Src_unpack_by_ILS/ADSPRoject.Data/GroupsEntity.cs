using System.Collections.Generic;

namespace ADSPRoject.Data;

public class GroupsEntity
{
	public List<GroupsEntity_Data> data { get; set; }

	public paging paging { get; set; }
}
