namespace ADSPRoject.Data;

public class billable_account_by_payment_account
{
	public string __typename { get; set; }

	public bool show_sdc_changes { get; set; }

	public string __isBillableAccount { get; set; }

	public string india_network_tokenization_migration_status { get; set; }

	public billing_payment_account billing_payment_account { get; set; }

	public bool is_reauth_restricted { get; set; }

	public string required_wizard_name { get; set; }
}
