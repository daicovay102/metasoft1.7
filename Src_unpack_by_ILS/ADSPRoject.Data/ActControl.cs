namespace ADSPRoject.Data;

public class ActControl
{
	private string _Status;

	public int Row { get; set; }

	public string Id { get; set; }

	public string _Card { get; set; }

	public string Mồi { get; set; }

	public string Message { get; set; }

	public string Status
	{
		get
		{
			return _Status;
		}
		set
		{
			_Status = value;
		}
	}
}
