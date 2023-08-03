namespace ADSPRoject.Data;

public class credential
{
	public string __typename { get; set; }

	public string card_association { get; set; }

	public string card_association_name { get; set; }

	public string id { get; set; }

	public bool supports_recurring { get; set; }

	public int expiry_month { get; set; }

	public int expiry_year { get; set; }

	public string is_expired { get; set; }

	public int last_four_digits { get; set; }

	public string needs_verification { get; set; }

	public bool can_retry_verify_card { get; set; }

	public bool is_owned_by_business { get; set; }

	public string network_tokenization_eligibility { get; set; }

	public string credential_id { get; set; }
}
