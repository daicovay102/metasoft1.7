using System;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using ADSPRoject.Server;
using xNet;

namespace ADSPRoject.HttpRequestApi;

public class FacebookApiPixel
{
	private HttpRequest httpRequest_0 = null;

	private frmMain frmMain;

	public FacebookApiPixel(frmMain frm)
	{
		frmMain = frm;
		httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
		httpRequest_0.SslProtocols = SslProtocols.Tls12;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Share_Pixel<T0, T1, T2, T3, T4>(T2 token, T2 bm_id, T2 pixel_id, T2 act_id)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00d6: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		T0 val = (T0)0;
		T1 val2 = (T1)0;
		while (true)
		{
			try
			{
				httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
				httpRequest_0.SslProtocols = SslProtocols.Tls12;
				T2 val3 = (T2)((object)httpRequest_0.Post(string.Concat((string[])(object)new T2[3]
				{
					(T2)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + (string)pixel_id + "/shared_accounts"),
					(T2)string.Concat((string[])(object)new T2[6]
					{
						(T2)"?account_id=",
						act_id,
						(T2)"&access_token=",
						token,
						(T2)"&business=",
						bm_id
					}),
					(T2)"&__cppo=1&limit=1"
				}), "&method=post&pretty=0&suppress_http_code=1&transport=cors", "application/x-www-form-urlencoded")).ToString();
				T0 val4 = (T0)((string)val3).Contains("true");
				val = ((val4 == null) ? ((T0)0) : ((T0)1));
			}
			catch (Exception)
			{
				val = (T0)0;
			}
			T0 val5 = (T0)(val == null);
			if (val5 == null)
			{
				break;
			}
			val2 = (T1)(val2 + 1);
			T0 val6 = (T0)((nint)val2 <= 3);
			if (val6 != null)
			{
				Thread.Sleep(2000);
				continue;
			}
			return val;
		}
		return val;
	}
}
