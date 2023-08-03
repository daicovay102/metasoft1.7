using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ADSPRoject.Data;

public class adaccountsData
{
	private float fl_balance;

	private float fl_amount_spent;

	private float fl_spend_cap = 0f;

	public addraft_fragments_2 addraft_fragments;

	public string Temp_String;

	public bool select_row { get; set; }

	public string id { get; set; }

	public string bm_id { get; set; }

	public string int_id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (!string.IsNullOrWhiteSpace(id))
			{
				return id.Replace("act_", "");
			}
			return "0";
		}
		set
		{
			id = value;
		}
	}

	public string name { get; set; }

	public string currency { get; set; }

	public int account_status { get; set; }

	public string str_account_status
	{
		get
		{
			return Utility.GetStatus<int, string>(account_status);
		}
		set
		{
		}
	}

	public string timezone_name { get; set; }

	public string balance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (!fl_balance.ToString().Equals("0.00") && !fl_balance.ToString().Equals("0"))
			{
				return $"{fl_balance / (float)Utility.RateCurrency<string, bool, int>(currency):n}";
			}
			return "";
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				value = "0";
			}
			fl_balance = float.Parse(value);
		}
	}

	public float adtrust_dsl { get; set; }

	public string amount_spent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return $"{fl_amount_spent / (float)Utility.RateCurrency<string, bool, int>(currency):n}";
		}
		set
		{
			fl_amount_spent = float.Parse(value);
		}
	}

	public string threshold_amount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (adspaymentcycle != null && adspaymentcycle.data != null)
			{
				try
				{
					return $"{adspaymentcycle.data.First().threshold_amount / (float)Utility.RateCurrency<string, bool, int>(currency):n}";
				}
				catch
				{
					return "";
				}
			}
			return "";
		}
		set
		{
		}
	}

	public string payment
	{
		get
		{
			if (funding_source_details == null)
			{
				return "";
			}
			return funding_source_details.display_string;
		}
	}

	public adspaymentcycle adspaymentcycle { get; set; }

	public bool has_repay_processing_invoices { get; set; }

	public invoicing_emails invoicing_emails { get; set; }

	public funding_source_details funding_source_details { get; set; }

	public clCampaigns campaigns { get; set; }

	public string current_addrafts { get; set; }

	public string Has_Campaigns
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (campaigns != null && campaigns.data != null && campaigns.data.Count > 0)
			{
				string text = "Có";
				foreach (campaignsData datum in campaigns.data)
				{
					if (datum.delivery_status != null)
					{
						text = text + "-" + datum.delivery_status.status + "-" + string.Join("-", datum.delivery_status.substatuses);
					}
				}
				return text;
			}
			return "";
		}
		set
		{
		}
	}

	public string spend_cap
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			if (!fl_spend_cap.ToString().Equals("0.00") && !fl_spend_cap.ToString().Equals("0"))
			{
				return $"{fl_spend_cap / (float)Utility.RateCurrency<string, bool, int>(currency):n}";
			}
			return "";
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				value = "0";
			}
			fl_spend_cap = float.Parse(value);
		}
	}

	public string get_remaining_amount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			try
			{
				float num = fl_spend_cap - fl_amount_spent;
				if (!num.ToString().Equals("0.00") && !num.ToString().Equals("0"))
				{
					return $"{num / (float)Utility.RateCurrency<string, bool, int>(currency):n}";
				}
				return "";
			}
			catch
			{
			}
			return "0";
		}
		set
		{
		}
	}

	public string business_country_code { get; set; }

	public string message { get; set; }

	public string strPayment_account { get; set; }

	public payment_account payment_account { get; set; }

	public string strCheckPayment { get; set; }

	public CheckPayment CheckPayment { get; set; }

	public string payment_section_details
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			try
			{
				string text = "";
				if (payment_account == null)
				{
					return "";
				}
				if (payment_account != null && payment_account.data != null && payment_account.data.billable_account_by_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count > 0)
				{
					foreach (billing_payment_methods billing_payment_method in payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods)
					{
						if (billing_payment_method.credential != null)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += " | ";
							}
							text = (billing_payment_method.is_primary ? (text + "c") : (text + "p"));
							text = ((string.IsNullOrWhiteSpace(billing_payment_method.usability) || (!billing_payment_method.usability.Equals("UNVERIFIED_OR_PENDING_AUTH") && !billing_payment_method.usability.Equals("UNVERIFIABLE") && (string.IsNullOrWhiteSpace(billing_payment_method.credential.needs_verification) || !bool.Parse(billing_payment_method.credential.needs_verification)))) ? (text + "-") : (text + "-XM-"));
							text = text + billing_payment_method.credential.card_association_name + $"*{billing_payment_method.credential.last_four_digits}/{billing_payment_method.credential.expiry_month}/{billing_payment_method.credential.expiry_year}";
						}
					}
					return text;
				}
				return frmMain.STATUS.Không_thẻ.ToString();
			}
			catch (Exception)
			{
				return strPayment_account;
			}
		}
		set
		{
		}
	}

	public string credential_id_count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return $"Có {credential_id.Count()} Id";
		}
	}

	public List<string> credential_id
	{
		get
		{
			List<string> list = (List<string>)Activator.CreateInstance(typeof(List<string>));
			if (CheckPayment != null && CheckPayment.data != null && CheckPayment.data.billable_account_by_asset_id != null && CheckPayment.data.billable_account_by_asset_id.billing_payment_account != null && CheckPayment.data.billable_account_by_asset_id.billing_payment_account.billing_payment_methods != null)
			{
				foreach (billing_payment_methods billing_payment_method in CheckPayment.data.billable_account_by_asset_id.billing_payment_account.billing_payment_methods)
				{
					if (billing_payment_method.credential != null)
					{
						list.Add(billing_payment_method.credential.credential_id);
					}
				}
			}
			if (payment_account != null && payment_account.data != null && payment_account.data.billable_account_by_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null)
			{
				foreach (billing_payment_methods billing_payment_method2 in payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods)
				{
					if (billing_payment_method2.credential != null)
					{
						list.Add(billing_payment_method2.credential.credential_id);
					}
				}
			}
			return list;
		}
	}

	public string payment_status
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			string text = "";
			if (payment_account != null && payment_account.data != null && payment_account.data.billable_account_by_payment_account != null)
			{
				text = ((!payment_account.data.billable_account_by_payment_account.is_reauth_restricted) ? frmMain.STATUS.Bình_thường.ToString() : frmMain.STATUS.Không_đủ_tiền.ToString());
			}
			if (text.Equals(frmMain.STATUS.Bình_thường.ToString()) && CheckPayment != null && CheckPayment.data != null && CheckPayment.data.billable_account_by_asset_id != null && !string.IsNullOrWhiteSpace(CheckPayment.data.billable_account_by_asset_id.risk_restricted_state) && CheckPayment.data.billable_account_by_asset_id.risk_restricted_state.Equals("ACTIONABLE_PREAUTH_STATE"))
			{
				text = frmMain.STATUS.Không_đủ_tiền.ToString();
			}
			return text;
		}
		set
		{
		}
	}

	public int disable_reason { get; set; }

	public string disable_reason_string
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return disable_reason switch
			{
				0 => "", 
				1 => "ADS_INTEGRITY_POLICY", 
				2 => "ADS_IP_REVIEW", 
				3 => "RISK_PAYMENT", 
				4 => "GRAY_ACCOUNT_SHUT_DOWN", 
				5 => "ADS_AFC_REVIEW", 
				6 => "BUSINESS_INTEGRITY_RAR", 
				7 => "PERMANENT_CLOSE", 
				8 => "UNUSED_RESELLER_ACCOUNT", 
				9 => "UNUSED_ACCOUNT", 
				_ => "Null", 
			};
		}
		set
		{
		}
	}
}
