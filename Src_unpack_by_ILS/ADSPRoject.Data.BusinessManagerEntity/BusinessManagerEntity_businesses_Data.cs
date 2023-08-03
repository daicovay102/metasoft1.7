using System.Runtime.CompilerServices;

namespace ADSPRoject.Data.BusinessManagerEntity;

public class BusinessManagerEntity_businesses_Data
{
	public bool select_row = false;

	public string id { get; set; }

	public string name { get; set; }

	public string payment_account_id { get; set; }

	public string message { get; set; }

	public string status { get; set; }

	public string TKQC
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (owned_ad_accounts != null && owned_ad_accounts.data != null)
			{
				string text = "";
				foreach (adaccountsData datum in owned_ad_accounts.data)
				{
					text = text + datum.id + "|";
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Substring(0, text.Length - 1);
				}
				return text;
			}
			return "null";
		}
	}

	public string Payment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (credit_cards != null && credit_cards.data != null)
			{
				string text = "";
				foreach (credit_cards_data datum in credit_cards.data)
				{
					text = text + datum.last4 + "|" + datum.expiry_month + "|" + datum.expiry_year + "-";
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Substring(0, text.Length - 1);
				}
				return text;
			}
			return "null";
		}
	}

	public owned_ad_accounts owned_ad_accounts { get; set; }

	public credit_cards credit_cards { get; set; }
}
