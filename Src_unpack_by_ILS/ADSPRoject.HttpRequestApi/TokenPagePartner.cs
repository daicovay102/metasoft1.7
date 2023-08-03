using System;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using ADSPRoject.Server;
using xNet;

namespace ADSPRoject.HttpRequestApi;

public class TokenPagePartner
{
	private HttpRequest httpRequest_0 = null;

	private frmMain frmMain;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TokenPagePartner(frmMain frm)
	{
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		frmMain = frm;
		httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
		httpRequest_0.SslProtocols = SslProtocols.Tls12;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Share_Page<T0, T1, T2, T3, T4>(T2 token, T2 bm_id, T2 partner_id, T2 page_id, T2 cookie, T0 isTesting, out string message)
	{
		//IL_000a: Expected O, but got I4
		//IL_000c: Expected O, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010b: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		message = "";
		T0 val = (T0)0;
		T1 val2 = (T1)0;
		while (true)
		{
			try
			{
				httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
				httpRequest_0.SslProtocols = SslProtocols.Tls12;
				httpRequest_0.SetCookie((string)cookie, true);
				T2 val3 = (T2)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + (string)page_id + "/agencies?access_token=" + (string)token);
				T2 val4 = (T2)(message = ((object)httpRequest_0.Post((string)val3, string.Concat((string[])(object)new T2[1] { (T2)string.Concat((string[])(object)new T2[7]
				{
					(T2)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Apage%2Fagencies&_reqSrc=BrandAgencyActions.brands&acting_brand_id=",
					bm_id,
					(T2)"&business=",
					partner_id,
					(T2)"&locale=vi_VN&method=post&pageId=",
					page_id,
					(T2)"&permitted_tasks=%5B%22ANALYZE%22%2C%22VIEW_MONETIZATION_INSIGHTS%22%2C%22CREATE_CONTENT%22%2C%22MODERATE%22%2C%22MESSAGING%22%2C%22ADVERTISE%22%2C%22MANAGE%22%5D&pretty=0&suppress_http_code=1&xref=f21d7da559e0fc"
				}) }), "application/x-www-form-urlencoded")).ToString());
				T0 val5 = (T0)(((string)val4).Contains("success\":true") || ((string)val4).Contains("1690131"));
				val = ((val5 == null) ? ((T0)0) : ((T0)1));
				if (isTesting != null)
				{
					return val;
				}
			}
			catch (Exception)
			{
				val = (T0)0;
			}
			T0 val6 = (T0)(val == null);
			if (val6 != null)
			{
				val2 = (T1)(val2 + 1);
				T0 val7 = (T0)((nint)val2 <= 3);
				if (val7 == null)
				{
					break;
				}
				Thread.Sleep(2000);
				continue;
			}
			return val;
		}
		return val;
	}
}
