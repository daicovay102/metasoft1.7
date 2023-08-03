namespace ADSPRoject.Data;

public class LiveStreamSedding
{
	public string Id { get; set; }

	public frmSedding.KEY_LIVE_STREAM Key { get; set; }

	public bool isRandom { get; set; }

	public object Value { get; set; }
}
