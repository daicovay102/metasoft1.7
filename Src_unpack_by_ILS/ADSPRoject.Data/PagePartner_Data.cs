namespace ADSPRoject.Data;

public class PagePartner_Data
{
	private string strMessage;

	public bool select { get; set; }

	public string id { get; set; }

	public string name { get; set; }

	public string has_transitioned_to_new_page_experience { get; set; }

	public string has_updated_profile_plus_perm_management { get; set; }

	public string Message
	{
		get
		{
			if (string.IsNullOrWhiteSpace(strMessage))
			{
				strMessage = frmMain.STATUS.Ready.ToString();
			}
			return strMessage;
		}
		set
		{
			strMessage = value;
		}
	}
}
