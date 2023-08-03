namespace ADSPRoject.Data;

public class billable_account_by_asset_id
{
	public bool is_using_ec { get; set; }

	public string risk_restricted_state { get; set; }

	public string risk_restriction { get; set; }

	public bool is_reauth_restricted { get; set; }

	public billing_info billing_info { get; set; }

	public billing_payment_account billing_payment_account { get; set; }
}
