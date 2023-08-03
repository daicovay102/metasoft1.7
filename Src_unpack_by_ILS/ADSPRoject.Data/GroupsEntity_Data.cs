using System;

namespace ADSPRoject.Data;

public class GroupsEntity_Data
{
	public bool select_row;

	public string id { get; set; }

	public string name { get; set; }

	public int member_count { get; set; }

	public string privacy { get; set; }

	public DateTime updated_time { get; set; }

	public double updated_time_minute
	{
		get
		{
			return DateTime.Now.Subtract(updated_time).TotalMinutes;
		}
		set
		{
		}
	}

	public string message { get; set; }
}
