using System;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using ADSPRoject.Server;
using xNet;

namespace ADSPRoject.HttpRequestApi;

public class FacebookApiPage
{
	private HttpRequest httpRequest_0 = null;

	private frmMain frmMain;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FacebookApiPage(frmMain frm)
	{
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		frmMain = frm;
		httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
		httpRequest_0.SslProtocols = SslProtocols.Tls12;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Accept_Page<T0, T1, T2, T3, T4>(T2 token, T2 cookie, T2 uid_nhan_page, T2 page_id)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_00a5: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c9: Expected O, but got I4
		T0 val = (T0)0;
		T1 val2 = (T1)0;
		while (true)
		{
			try
			{
				httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
				httpRequest_0.SslProtocols = SslProtocols.Tls12;
				httpRequest_0.SetCookie((string)cookie, true);
				T2 val3 = (T2)string.Concat((string[])(object)new T2[6]
				{
					(T2)"https://graph.facebook.com/v7.0/graphql?method=post&locale=en_US&pretty=false&format=json&fb_api_req_friendly_name=useAcceptPageAdminInviteMutation&fb_api_caller_class=RelayModern&doc_id=3348120965246221&variables={\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"",
					uid_nhan_page,
					(T2)"\",\"page_id\":\"",
					page_id,
					(T2)"\"}}&access_token=",
					token
				});
				T2 val4 = (T2)((object)httpRequest_0.Get(string.Concat((string[])(object)new T2[1] { val3 }), (RequestParams)null)).ToString();
				T0 val5 = (T0)((string)val4).Contains("\"is_accepted\":true");
				val = ((val5 == null) ? ((T0)0) : ((T0)1));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				val = (T0)0;
				val2 = (T1)(val2 + 1);
				T0 val6 = (T0)((nint)val2 <= 10);
				if (val6 == null)
				{
					break;
				}
				Thread.Sleep(2000);
				continue;
			}
			break;
		}
		return val;
	}
}
