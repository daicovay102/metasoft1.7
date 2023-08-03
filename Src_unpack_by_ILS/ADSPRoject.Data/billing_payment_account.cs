using System.Collections.Generic;

namespace ADSPRoject.Data;

public class billing_payment_account
{
	public string __typename { get; set; }

	public List<billing_payment_methods> billing_payment_methods { get; set; }

	public List<billing_payment_method_options> billing_payment_method_options { get; set; }
}
