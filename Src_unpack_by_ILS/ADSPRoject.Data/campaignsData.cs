namespace ADSPRoject.Data;

public class campaignsData
{
	public string id { get; set; }

	public string name { get; set; }

	public string status { get; set; }

	public delivery_status delivery_status { get; set; }

	public adsets adsets { get; set; }
}
