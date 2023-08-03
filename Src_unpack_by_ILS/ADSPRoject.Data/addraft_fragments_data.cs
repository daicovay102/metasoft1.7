using System.Collections.Generic;

namespace ADSPRoject.Data;

public class addraft_fragments_data
{
	public string id { get; set; }

	public string ad_object_type { get; set; }

	public string parent_ad_object_id { get; set; }

	public string ad_object_id { get; set; }

	public List<addraft_fragments_data_value> values { get; set; }
}
