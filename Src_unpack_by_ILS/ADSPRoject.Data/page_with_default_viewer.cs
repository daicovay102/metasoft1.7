namespace ADSPRoject.Data;

public class page_with_default_viewer
{
	public enum STATUS
	{
		New,
		Used,
		Clear
	}

	public bool select { get; set; }

	public string id { get; set; }

	public string name { get; set; }

	public string status { get; set; }
}
