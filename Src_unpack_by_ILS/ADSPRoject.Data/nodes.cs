namespace ADSPRoject.Data;

public class nodes
{
	public string id { get; set; }

	public string name { get; set; }

	public string rejected_ad_count { get; set; }

	public string ads_business { get; set; }

	public nodes_payment_account payment_account { get; set; }
}
