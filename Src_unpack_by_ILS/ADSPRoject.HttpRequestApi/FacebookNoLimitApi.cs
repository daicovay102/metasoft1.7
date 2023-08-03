using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Threading;
using ADSPRoject.Data;
using ADSPRoject.Server;
using Newtonsoft.Json;
using Rebex;
using Rebex.Net;
using xNet;

namespace ADSPRoject.HttpRequestApi;

public class FacebookNoLimitApi
{
	private HttpRequest httpRequest_0 = null;

	private frmMain frmMain;

	public string UID_VIA = "";

	public string Token_VIA = "";

	public string Cookie_VIA = "";

	public string UID_BM = "";

	public string Token_BM = "";

	public string Cookie_BM = "";

	private static bool isChangeTokenBM;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FacebookNoLimitApi(frmMain frm)
	{
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		frmMain = frm;
		httpRequest_0 = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));
		httpRequest_0.SslProtocols = SslProtocols.Tls12;
		if (getToken_TKQC<bool, string>(checkNull: false))
		{
			getToken_BM<bool, string>(checkNull: false);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 getToken_TKQC<T0, T1>(T0 checkNull)
	{
		//IL_0016: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		TokenEntity token_TKQC = frmMain.TokenNolimit.Get_Token_TKQC<int, T0>();
		T0 val = (T0)(token_TKQC != null);
		if (val != null)
		{
			UID_VIA = token_TKQC.UID;
			Token_VIA = token_TKQC.Token;
			return (T0)1;
		}
		if (checkNull != null)
		{
			frmMain.isRunning = false;
			frmMain.errorMessage((T1)"Hết token TKQC!");
		}
		return (T0)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 getToken_BM<T0, T1>(T0 checkNull)
	{
		//IL_0016: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		TokenEntity token_BM = frmMain.TokenNolimit.Get_Token_BM<int, T0>();
		T0 val = (T0)(token_BM != null);
		if (val != null)
		{
			UID_BM = token_BM.UID;
			Token_BM = token_BM.Token;
			Cookie_BM = token_BM.Cookie;
			return (T0)1;
		}
		if (checkNull != null)
		{
			frmMain.isRunning = false;
			frmMain.errorMessage((T1)"Hết token BM!");
		}
		return (T0)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void mtClearBmRequestPending<T0, T1, T2>()
	{
		//IL_0018: Expected O, but got I4
		try
		{
			get_pending_client_ad_accounts get_pending_client_ad_accounts = pending_client_ad_accounts<string, T2, T0>();
			T0 val = (T0)(get_pending_client_ad_accounts != null && get_pending_client_ad_accounts.data != null);
			if (val == null)
			{
				return;
			}
			T1 enumerator = (T1)get_pending_client_ad_accounts.data.GetEnumerator();
			try
			{
				while (((List<pending_client_ad_accounts>.Enumerator*)(&enumerator))->MoveNext())
				{
					pending_client_ad_accounts current = ((List<pending_client_ad_accounts>.Enumerator*)(&enumerator))->Current;
					clearActPending<T0, string>(current.id.Replace("act_", ""));
				}
			}
			finally
			{
				((IDisposable)(*(List<pending_client_ad_accounts>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private get_pending_client_ad_accounts pending_client_ad_accounts<T0, T1, T2>()
	{
		//IL_007f: Expected O, but got I4
		get_pending_client_ad_accounts result = null;
		while (true)
		{
			T2 val = (T2)frmMain.isRunning;
			if (val != null)
			{
				try
				{
					httpRequest_0.SetCookie(Cookie_BM, true);
					T0 val2 = (T0)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + frmMain.TokenNolimit.ID_BM + "/pending_client_ad_accounts?access_token=" + Token_BM);
					T0 val3 = (T0)((object)httpRequest_0.Get((string)val2, (RequestParams)null)).ToString();
					result = JsonConvert.DeserializeObject<get_pending_client_ad_accounts>((string)val3);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					goto IL_006e;
				}
			}
			break;
			IL_006e:
			Thread.Sleep(1500);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 clearActPending<T0, T1>(T1 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			httpRequest_0.SetCookie(Cookie_BM, true);
			T1 val = (T1)string.Concat((string[])(object)new T1[5]
			{
				(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
				(T1)frmMain.TokenNolimit.ID_BM,
				(T1)"/adaccounts?access_token=",
				(T1)Token_BM,
				(T1)"&__cppo=1"
			});
			T1 val2 = (T1)("_reqName=object%3Abrand%2Fadaccounts&_reqSrc=AdAccountActions.brands&adaccount_id=act_" + (string)act + "&locale=en_US&method=delete&pretty=0&suppress_http_code=1&xref=f20db5b18b5d954");
			T1 val3 = (T1)((object)httpRequest_0.Post((string)val, string.Concat((string[])(object)new T1[1] { val2 }), "application/x-www-form-urlencoded")).ToString();
			T0 val4 = (T0)(!((string)val3).Contains("true"));
			if (val4 != null)
			{
				result = (T0)0;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 checkToken<T0, T1>(T1 token, out string id)
	{
		//IL_0002: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		T0 result = (T0)0;
		id = "";
		try
		{
			T1 val = (T1)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + "me?fields=id&access_token=" + (string)token);
			T1 val2 = (T1)((object)httpRequest_0.Get((string)val, (RequestParams)null)).ToString();
			Get_UID_Token get_UID_Token = JsonConvert.DeserializeObject<Get_UID_Token>((string)val2);
			T0 val3 = (T0)(get_UID_Token != null && get_UID_Token.id != null);
			if (val3 != null)
			{
				id = get_UID_Token.id;
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	public T0 requestFriend_Single<T0, T1>(T1 UID_Clone)
	{
		//IL_003c: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		while (true)
		{
			T0 val = requestFriend<WebClient, NameValueCollection, T1, T0, HttpRequest>(UID_Clone, (T1)UID_VIA, (T1)Token_VIA, (T1)Cookie_VIA);
			if (val != null)
			{
				break;
			}
			frmMain.TokenNolimit.Set_Status_Token_TKQC<T0, int, T1>((T1)Token_VIA, (T1)frmMain.STATUS.Die.ToString());
			frmMain.saveTokenNolimit();
			T0 token_TKQC = getToken_TKQC<T0, T1>((T0)1);
			if (token_TKQC == null)
			{
				return (T0)0;
			}
		}
		return (T0)1;
	}

	public unsafe T1 requestFriend_All<T0, T1, T2>(T2 UID_Clone)
	{
		//IL_003d: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		T0 enumerator = (T0)frmMain.TokenNolimit.List_TOKEN_TKQC.GetEnumerator();
		try
		{
			while (((List<TokenEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				TokenEntity current = ((List<TokenEntity>.Enumerator*)(&enumerator))->Current;
				T1 val = (T1)current.Status.Equals(frmMain.STATUS.Live.ToString());
				if (val != null)
				{
					requestFriend<WebClient, NameValueCollection, T2, T1, HttpRequest>(UID_Clone, (T2)current.UID, (T2)current.Token, (T2)current.Cookie);
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T3 requestFriend<T0, T1, T2, T3, T4>(T2 UID_Clone, T2 UID_VIA, T2 Token_VIA, T2 Cookie_VIA)
	{
		//IL_00fe: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		try
		{
			Licensing.Key = (string)FacebookApi.getTrialkey_Rebex<T3, T4, T2>();
			Console.WriteLine(Licensing.Key);
			T0 val = (T0)Activator.CreateInstance(typeof(WebClient));
			((SslSettings)((WebClient)val).Settings).SslAllowedVersions = (TlsVersion)16;
			Activator.CreateInstance(typeof(NameValueCollection));
			((WebClient)val).Headers.Add("Cookie", (string)Cookie_VIA);
			T2 val2 = (T2)((WebClient)val).DownloadString(string.Concat((string[])(object)new T2[7]
			{
				(T2)"https://graph.facebook.com/v7.0/graphql?access_token=",
				Token_VIA,
				(T2)"&variables=%7B%22input%22:%7B%22attribution_id_v2%22:%22ProfileCometTimelineListViewRoot.react,comet.profile.timeline.list,via_cold_start,1650249369781,665546,190055527696468%22,%22friend_requestee_ids%22:[%22",
				UID_Clone,
				(T2)"%22],%22refs%22:[null],%22source%22:%22profile_button%22,%22warn_ack_for_ids%22:[],%22actor_id%22:%22",
				UID_VIA,
				(T2)"%22,%22client_mutation_id%22:%221%22%7D,%22scale%22:1.5%7D&doc_id=5061499187226583&method=post"
			}));
			T2 val3 = (T2)((WebClient)val).DownloadString(string.Concat((string[])(object)new T2[9]
			{
				(T2)"https://graph.facebook.com/v7.0/graphql?access_token=",
				Token_VIA,
				(T2)"&variables=%7B%22input%22:%7B%22attribution_id_v2%22:%22ProfileCometTimelineListViewRoot.react,comet.profile.timeline.list,via_cold_start,1663824083557,294316,190055527696468,%22,%22friend_requestee_ids%22:[%22",
				UID_Clone,
				(T2)"%22],%22refs%22:[null],%22source%22:%22profile_button%22,%22warn_ack_for_ids%22:[%22",
				UID_Clone,
				(T2)"%22],%22actor_id%22:%22",
				UID_VIA,
				(T2)"%22,%22client_mutation_id%22:%222%22%7D,%22scale%22:1.5%7D&doc_id=5419238518196807&method=post"
			}));
			T3 val4 = (T3)(((string)val2).Contains((string)UID_Clone) || ((string)val3).Contains((string)UID_Clone));
			if (val4 != null)
			{
				return (T3)1;
			}
			T3 val5 = (T3)(((string)val2).Contains("1431004") || ((string)val2).Contains("1390008") || ((string)val2).Contains("api_error_code\":368"));
			if (val5 == null)
			{
				return (T3)0;
			}
			return (T3)0;
		}
		catch
		{
		}
		return (T3)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 getUID_Token<T0, T1, T2>()
	{
		//IL_0064: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(HttpRequest));
			T1 input = (T1)((object)((HttpRequest)val).Get(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + "me?&access_token=" + Token_VIA, (RequestParams)null)).ToString();
			T1 value = (T1)Regex.Match((string)input, "\"id\": \"(\\d+)\",").Groups[1].Value;
			T2 val2 = (T2)((string)value == string.Empty);
			if (val2 != null)
			{
				value = (T1)Regex.Match((string)input, "\"id\": \"(\\d+)\"").Groups[1].Value;
			}
			T2 val3 = (T2)(!((string)value != string.Empty));
			if (val3 == null)
			{
				return value;
			}
			return (T1)"";
		}
		catch
		{
		}
		return (T1)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 shareAdsToClone<T0, T1, T2>(T1 UID_Clone)
	{
		//IL_0028: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(HttpRequest));
			T1 val2 = (T1)"users";
			T2 val3 = (T2)(!((string)val2 != string.Empty));
			if (val3 != null)
			{
				return (T2)0;
			}
			T1 val4 = (T1)((object)((HttpRequest)val).Post(string.Concat((string[])(object)new T1[7]
			{
				(T1)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + "act_"),
				(T1)frmMain.TokenNolimit.ID_TKQC,
				(T1)"/",
				val2,
				(T1)"?_reqName=adaccount%2Fusers&access_token=",
				(T1)Token_VIA,
				(T1)"&method=post&__cppo=1"
			}), string.Concat((string[])(object)new T1[5]
			{
				(T1)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&_index=12&_reqName=adaccount%2Fusers&_reqSrc=AdsPermissionDialogController&_sessionID=87345a785eb4e67&account_id=",
				(T1)frmMain.TokenNolimit.ID_TKQC,
				(T1)"&include_headers=false&locale=en_US&method=post&pretty=0&role=281423141961500&suppress_http_code=1&uid=",
				UID_Clone,
				(T1)"&xref=fadc4641ce460c"
			}), "application/x-www-form-urlencoded")).ToString();
			T2 val5 = (T2)((string)val4).Contains("success");
			if (val5 != null)
			{
				return (T2)1;
			}
		}
		catch
		{
		}
		return (T2)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 requestAddToBm<T0, T1, T2, T3>(T2 string_2)
	{
		//IL_0002: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_01af: Expected O, but got I4
		//IL_01c2: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		T0 result = (T0)2;
		try
		{
			while (true)
			{
				T3 val = (T3)isChangeTokenBM;
				if (val != null)
				{
					Thread.Sleep(3000);
					continue;
				}
				T3 val2 = (T3)(!frmMain.isRunning);
				if (val2 == null)
				{
					T1 val3 = (T1)Activator.CreateInstance(typeof(HttpRequest));
					((HttpRequest)val3).SslProtocols = SslProtocols.Tls12;
					ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
					((HttpRequest)val3).SetCookie(Cookie_BM, true);
					T2 token_BM = (T2)Token_BM;
					T2 val4 = (T2)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + frmMain.TokenNolimit.ID_BM + "/client_ad_accounts?access_token=" + (string)token_BM);
					T2 val5 = (T2)("__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Abrand%2Fclient_ad_accounts&_reqSrc=AdAccountActions.brands&access_type=AGENCY&adaccount_id=act_" + ((string)string_2).Replace("act_", "") + "&locale=en_US&method=post&permitted_roles=%5B%5D&permitted_tasks=%5B%22ADVERTISE%22%2C%22ANALYZE%22%2C%22DRAFT%22%2C%22MANAGE%22%5D&pretty=0&suppress_http_code=1&xref=f17fec5ecbe8884");
					T2 val6 = (T2)((object)((HttpRequest)val3).Post((string)val4, string.Concat((string[])(object)new T2[1] { val5 }), "application/x-www-form-urlencoded")).ToString();
					T3 val7 = (T3)(((string)val6).Contains("PENDING") || ((string)val6).Contains("1752041"));
					if (val7 == null)
					{
						T3 val8 = (T3)((string)val6).Contains("code\":200");
						if (val8 == null)
						{
							T3 val9 = (T3)(((string)val6).Contains("code\":2") || ((string)val6).Contains("code\":100"));
							if (val9 != null)
							{
								Thread.Sleep(2000);
								continue;
							}
							T3 val10 = (T3)(isChangeTokenBM || (string)token_BM != Token_BM);
							if (val10 != null)
							{
								Thread.Sleep(2000);
								continue;
							}
							isChangeTokenBM = true;
							frmMain.TokenNolimit.Set_Status_Token_BM<T3, T0, T2>((T2)Token_BM, (T2)frmMain.STATUS.Die.ToString());
							frmMain.saveTokenNolimit();
							T3 token_BM2 = getToken_BM<T3, T2>((T3)1);
							if (token_BM2 != null)
							{
								isChangeTokenBM = false;
								continue;
							}
							isChangeTokenBM = false;
							break;
						}
						result = (T0)1;
						break;
					}
					result = (T0)0;
					break;
				}
				return result;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 clearRequest<T0, T1, T2>(T1 string_2)
	{
		//IL_0096: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(HttpRequest));
			((HttpRequest)val).SetCookie(Cookie_BM, true);
			T1 val2 = (T1)((object)((HttpRequest)val).Get(string.Concat((string[])(object)new T1[7]
			{
				(T1)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") ?? ""),
				(T1)frmMain.TokenNolimit.ID_BM,
				(T1)"/adaccounts?access_token=",
				(T1)Token_BM,
				(T1)"&_reqName=object:brand/adaccounts&_reqSrc=AdAccountActions.brands&adaccount_id=act_",
				string_2,
				(T1)"&locale=vi_VN&method=delete&pretty=0&suppress_http_code=1&xref=f1f70a464f2e71c"
			}), (RequestParams)null)).ToString();
			T2 val3 = (T2)((string)val2).Contains("true");
			if (val3 != null)
			{
				return (T2)1;
			}
			return (T2)0;
		}
		catch
		{
		}
		return (T2)0;
	}
}
