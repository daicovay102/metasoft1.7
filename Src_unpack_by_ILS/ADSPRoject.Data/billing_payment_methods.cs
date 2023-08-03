namespace ADSPRoject.Data;

public class billing_payment_methods
{
	public string __typename { get; set; }

	public bool is_primary { get; set; }

	public string usability { get; set; }

	public bool is_editable { get; set; }

	public credential credential { get; set; }
}
