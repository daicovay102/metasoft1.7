using System.Collections.Generic;

namespace ADSPRoject.Data;

public class facebook_pagesData
{
	public bool select_row;

	public string id { get; set; }

	public string name { get; set; }

	public string name_with_location_descriptor { get; set; }

	public string category { get; set; }

	public List<category_list> category_list { get; set; }

	public bool is_restricted { get; set; }

	public bool has_transitioned_to_new_page_experience { get; set; }

	public int followers_count { get; set; }

	public string additional_profile_id { get; set; }

	public bool is_published { get; set; }

	public string message { get; set; }

	public CheckPro5Admin check_user_pro5 { get; set; }
}
