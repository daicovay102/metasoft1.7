using System.Collections.Generic;

namespace ADSPRoject.Data;

public class BMData
{
	public adaccounts owned_ad_accounts { get; set; }

	public pending_users pending_users { get; set; }

	public string id { get; set; }

	public string name { get; set; }

	public string verification_status { get; set; }

	public bool can_create_ad_account { get; set; }

	public List<string> permitted_roles { get; set; }

	public business_users business_users { get; set; }
}
