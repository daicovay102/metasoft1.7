namespace ADSPRoject.Data;

public class credit_card
{
	public string card_association { get; set; }

	public string credential_id { get; set; }

	public string expiry_month { get; set; }

	public string expiry_year { get; set; }

	public string is_expired { get; set; }

	public string last_four_digits { get; set; }
}
