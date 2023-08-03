using System.Collections.Generic;

namespace ADSPRoject.Data;

public class CheckPro5Admin_user
{
	public core_app_admins_for_additional_profile core_app_admins_for_additional_profile { get; set; }

	public List<outgoing_core_app_admin_invites> outgoing_core_app_admin_invites { get; set; }
}
