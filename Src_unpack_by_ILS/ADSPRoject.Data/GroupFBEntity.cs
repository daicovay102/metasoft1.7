using System;

namespace ADSPRoject.Data;

public class GroupFBEntity
{
	public bool Select { get; set; }

	public string Group_Id { get; set; }

	public string Group_Name { get; set; }

	public int Member { get; set; }

	public DateTime CreateDate { get; set; }

	public DateTime UpdateDate { get; set; }

	public string Message { get; set; }

	public string Status { get; set; }
}
