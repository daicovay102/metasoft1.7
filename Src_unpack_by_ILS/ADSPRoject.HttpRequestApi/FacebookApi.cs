using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using ADSPRoject.BinGen;
using ADSPRoject.Data;
using ADSPRoject.Data.BusinessManagerEntity;
using ADSPRoject.Server;
using CreditCardValidator;
using Data;
using Newtonsoft.Json;
using Rebex;
using Rebex.Net;
using xNet;

namespace ADSPRoject.HttpRequestApi;

public class FacebookApi
{
	private HttpRequest httpRequest = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));

	private frmMain frmMain;

	private int indexEntity;

	private bool isLogined = false;

	private string jazoest = string.Empty;

	private string lsd = "";

	private int Create_BM_Count = 0;

	private int Create_Act_Count = 0;

	private int Create_BM_Act_Count = 0;

	private string[] listUseragentDesktop = new string[6] { "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36", "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36", "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36" };

	public static string Trialkey_Rebex = "";

	private int countPage = 0;

	public static List<string> listUserAgent;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private int indexCart = -1;

	private string strUserAgentDesktop => listUseragentDesktop[rnd.Next(0, listUseragentDesktop.Count() - 1)];

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void setProxySocks<T0, T1, T2>(T0 ip, T1 isProxy)
	{
		//IL_0015: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		T0 val = ip;
		T0 val2 = (T0)"";
		T1 val3 = (T1)((string)ip).Contains("@");
		if (val3 != null)
		{
			val2 = ((IEnumerable<T0>)(object)((string)ip).Split((char[])(object)new T2[1] { (T2)64 })).First();
			val = ((IEnumerable<T0>)(object)((string)ip).Split((char[])(object)new T2[1] { (T2)64 })).Last();
		}
		if (isProxy == null)
		{
			httpRequest.Proxy = (ProxyClient)(object)Socks5ProxyClient.Parse((string)val);
		}
		else
		{
			httpRequest.Proxy = (ProxyClient)(object)HttpProxyClient.Parse((string)val);
		}
		T1 val4 = (T1)(!string.IsNullOrWhiteSpace((string)val2));
		if (val4 != null)
		{
			httpRequest.Proxy.Username = (string)((IEnumerable<T0>)(object)((string)val2).Split((char[])(object)new T2[1] { (T2)58 })).First();
			httpRequest.Proxy.Password = (string)((IEnumerable<T0>)(object)((string)val2).Split((char[])(object)new T2[1] { (T2)58 })).Last();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FacebookApi(frmMain frm, int index, string strProxy, bool isAuto_Run_Follow)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		try
		{
			bool flag = true;
			indexEntity = index;
			frmMain = frm;
			httpRequest.SslProtocols = SslProtocols.Tls12;
			ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
			httpRequest.Cookies = new CookieDictionary(false);
			httpRequest.AllowAutoRedirect = true;
			httpRequest.KeepAlive = true;
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			if (!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Socks))
			{
				strProxy = frmMain.listFBEntity[indexEntity].Socks.Replace("proxy:", "").Replace("socks5:", "");
				bool flag2 = true;
				flag2 = (frmMain.listFBEntity[indexEntity].Socks.ToLower().StartsWith("proxy") ? true : false);
				int num = 0;
				setProxySocks<string, bool, char>(strProxy, flag2);
				while (true)
				{
					setMessage<bool, string, int>($"Testing IP {num}", addToColumnMessage: false);
					try
					{
						((object)httpRequest.Get("https://facebook.com", (RequestParams)null)).ToString();
						setMessage<bool, string, int>("IP OK", addToColumnMessage: false);
					}
					catch
					{
						num++;
						if (num < 1)
						{
							if (num % 2 != 0)
							{
								setProxySocks<string, bool, char>(strProxy, isProxy: false);
							}
							else
							{
								setProxySocks<string, bool, char>(strProxy, isProxy: true);
							}
							continue;
						}
						setMessage<bool, string, int>("IP ERROR", addToColumnMessage: true);
						flag = false;
						updateStatus<bool, int, string>(isDone: false);
					}
					break;
				}
			}
			else if (!string.IsNullOrWhiteSpace(strProxy))
			{
				if (frmMain.setting.rbTypeChangeIP == 5 && frmMain.setting.ccbTypeTMProxy == 1)
				{
					setProxySocks<string, bool, char>(strProxy, isProxy: true);
				}
				else if (frmMain.setting.rbTypeChangeIP == 5 && frmMain.setting.ccbTypeTMProxy == 0)
				{
					setProxySocks<string, bool, char>(strProxy, isProxy: false);
				}
				else if (frmMain.setting.rbTypeChangeIP == 3)
				{
					int num2 = 0;
					setProxySocks<string, bool, char>(strProxy, isProxy: false);
					while (true)
					{
						setMessage<bool, string, int>($"Testing IP {num2}", addToColumnMessage: false);
						try
						{
							((object)httpRequest.Get("https://google.com", (RequestParams)null)).ToString();
							setMessage<bool, string, int>("IP OK", addToColumnMessage: false);
						}
						catch
						{
							num2++;
							if (num2 < 10)
							{
								if (num2 % 2 != 0)
								{
									setProxySocks<string, bool, char>(strProxy, isProxy: true);
								}
								continue;
							}
							setMessage<bool, string, int>("IP ERROR", addToColumnMessage: true);
						}
						break;
					}
				}
				else if (frmMain.setting.rbTypeChangeIP == 4 && frmMain.setting.TypeXProxy != 0 && frmMain.setting.TypeXProxy != 2)
				{
					if (frmMain.setting.TypeXProxy == 1 || frmMain.setting.TypeXProxy == 3 || (frmMain.listFBEntity[indexEntity].Socks != null && frmMain.listFBEntity[indexEntity].Socks.ToLower().StartsWith("socks5")))
					{
						setProxySocks<string, bool, char>(strProxy, isProxy: false);
					}
				}
				else
				{
					setProxySocks<string, bool, char>(strProxy, isProxy: true);
				}
			}
			if (!(isAuto_Run_Follow && flag))
			{
				return;
			}
			foreach (FBFlow item in frmMain.listFBEntity[indexEntity].Flow)
			{
				if (frmMain.isRunning)
				{
					if (item.Flow_Name.Equals("Đăng_nhập"))
					{
						Đăng_nhập<bool, string, int, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Delay"))
					{
						Delay<int, bool>(item);
					}
					else if (item.Flow_Name.Equals("Tham_gia_nhóm") & isLogined)
					{
						Tham_gia_nhóm<bool, int, string, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Hủy_tham_gia_nhóm") & isLogined)
					{
						Hủy_tham_gia_nhóm<bool, int, List<GroupItem>, string, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Đăng_bài_vào_nhóm") & isLogined)
					{
						Đăng_bài_vào_nhóm<bool, int, string, List<GroupItem>, List<GroupItem>.Enumerator, Exception, Match, char>(item);
					}
					else if (item.Flow_Name.Equals("Share_TKQC_cá_nhân") & isLogined)
					{
						Share_TKQC_cá_nhân<bool, string, int, List<TokenEntity>.Enumerator, Exception, List<nodes>.Enumerator, Color, char, List<billing_payment_methods>.Enumerator>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_TKQC_cá_nhân") & isLogined)
					{
						Tạo_TKQC_cá_nhân<bool, string, int, List<TokenEntity>.Enumerator, Exception, List<nodes>.Enumerator, Color, char, List<CreditCardEntity>>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_tài_khoản_BM") & isLogined)
					{
						Tạo_tài_khoản_BM<bool, string, List<string>, int, List<string>.Enumerator, Exception, List<CreditCardEntity>>(item);
					}
					else if (item.Flow_Name.Equals("Add_thẻ_vô_hạn") & isLogined)
					{
						Add_thẻ_vô_hạn_2<bool, string, int, Exception, List<nodes>.Enumerator, Color, char>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_BM") & isLogined)
					{
						Tạo_BM<bool, int, string, DateTime, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_Page") & isLogined)
					{
						Tạo_Page<bool, int, string, Exception, Match, char>(item);
						setMessage<bool, string, int>($"{countPage}(pages)", addToColumnMessage: false);
					}
					else if (item.Flow_Name.Equals("Rip_clone") & isLogined)
					{
						Rip_clone<bool, string, DateTime, int, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Add_thẻ") & isLogined)
					{
						Add_thẻ<bool, string, int, Exception, List<CreditCardEntity>, List<nodes>.Enumerator, Color, char>(item);
					}
					else if (item.Flow_Name.Equals("Add_thẻ_m_facebook") & isLogined)
					{
						Add_thẻ_m_facebook<bool, string, int, Exception, List<CreditCardEntity>, List<nodes>.Enumerator, Color, char>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_TKQC_cá_nhân_2") & isLogined)
					{
						Tạo_TKQC_cá_nhân_2<bool, string, int, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_TKQC_BM") & isLogined)
					{
						Tạo_TKQC_BM<bool, int, string, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Add_thẻ_2"))
					{
						ResouceControl.RESOUCE_VERSION = "ResouceV2";
						ResouceControl.API_URL = "https://api.meta-soft.tech/";
						Add_thẻ_2<bool, int, string, List<CreditCardEntity>, List<facebook_pagesData>, List<string>, List<string>.Enumerator, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<adaccountsData>.Enumerator, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Tạo_Page_Nhanh") & isLogined)
					{
						Tạo_Page_Nhanh<bool, string, char, Exception, int, object>(item);
					}
					else if (item.Flow_Name.Equals("Set_limit") & isLogined)
					{
						Set_limit<bool, string, List<adaccountsData>.Enumerator, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Approved_hold") && isLogined)
					{
						Approved_hold<bool, List<adaccountsData>.Enumerator, string, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Set_camp_chuyển_đổi_PE") & isLogined)
					{
						Set_camp_chuyển_đổi_PE<bool, string, int, List<facebook_pagesData>, List<facebook_pagesData>.Enumerator, List<adaccountsData>.Enumerator, List<addraft_fragments_2_data>.Enumerator, Image, MemoryStream, byte, List<addraft_fragments_data>.Enumerator, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Set_camp_chuyển_đổi_Suite") & isLogined)
					{
						Set_camp_chuyển_đổi_Suite<bool, string, List<facebook_pagesData>, int, List<facebook_pagesData>.Enumerator, List<adaccountsData>.Enumerator, Guid, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Share_pixel") & isLogined)
					{
						Share_pixel<bool, int, List<adaccountsData>.Enumerator, string, List<TokenEntity>.Enumerator, Exception, HttpRequest>(item);
					}
					else if (item.Flow_Name.Equals("Share_page_đối_tác") & isLogined)
					{
						Share_page_đối_tác<bool, string, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<TokenEntity>.Enumerator, int, List<available_permission_tasks_ui_configs>.Enumerator, List<business_users_data>.Enumerator, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Lưu_ID_TKQC") & isLogined)
					{
						Lưu_ID_TKQC<bool, string, List<adaccountsData>.Enumerator, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Hoàn_thành"))
					{
						Hoàn_thành<bool, string, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, Exception>(item);
						break;
					}
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Share_page_đối_tác<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_019c: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_0227: Expected O, but got I4
		//IL_0438: Expected O, but got I4
		//IL_0442: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_0659: Expected O, but got I4
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		//IL_0697: Expected O, but got I4
		//IL_06a6: Expected O, but got I4
		//IL_06c3: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)0;
			T0 val3 = (T0)(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"share_tất_cả_bm") != null);
			if (val3 != null)
			{
				val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"share_tất_cả_bm").ToString());
			}
			setMessage<T0, T1, T5>((T1)"Share page đối tác", (T0)0);
			T1 strError = (T1)"";
			T2 bMList = getBMList<T1, T0, T2, T8>(out *(string*)(&strError));
			T0 val4 = (T0)(bMList == null || ((List<BusinessManagerEntity_businesses_Data>)bMList).Count <= 0);
			if (val4 == null)
			{
				T0 val5 = (T0)0;
				T3 enumerator = (T3)((List<BusinessManagerEntity_businesses_Data>)bMList).GetEnumerator();
				try
				{
					while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
					{
						BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
						T4 enumerator2 = (T4)frmMain.setting.List_TOKEN_PAGE_PARTNER.GetEnumerator();
						try
						{
							while (((List<TokenEntity>.Enumerator*)(&enumerator2))->MoveNext())
							{
								TokenEntity current2 = ((List<TokenEntity>.Enumerator*)(&enumerator2))->Current;
								T0 val6 = (T0)current2.Status.Equals(frmMain.STATUS.Live.ToString());
								if (val6 == null)
								{
									continue;
								}
								T1[] array = (T1[])(object)frmMain.setting.txtPageID_Partner.Split((char[])(object)new T9[1] { (T9)124 });
								T5 val7 = (T5)0;
								while ((nint)val7 < array.Length)
								{
									T1 val8 = (T1)((object[])(object)array)[(object)val7];
									T0 val9 = (T0)(!string.IsNullOrWhiteSpace((string)val8));
									if (val9 != null)
									{
										T0 val10 = frmMain.tokenPagePartner.Share_Page<T0, T5, T1, T8, HttpRequest>((T1)current2.Token, (T1)frmMain.setting.txtBMID_PagePartner, (T1)current.id, val8, (T1)current2.Cookie, (T0)0, out *(string*)(&strError));
										if (val10 == null)
										{
											current2.Status = frmMain.STATUS.Die.ToString();
										}
										else
										{
											val5 = (T0)1;
										}
									}
									val7 = (T5)(val7 + 1);
								}
								T0 val11 = val5;
								if (val11 != null)
								{
									break;
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val12 = (T0)(val2 == null);
						if (val12 != null)
						{
							break;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
				}
				T0 val13 = (T0)(val5 == null);
				if (val13 != null)
				{
					setMessage<T0, T1, T5>((T1)"e:Share page lỗi", (T0)1);
					return;
				}
				T3 enumerator3 = (T3)((List<BusinessManagerEntity_businesses_Data>)bMList).GetEnumerator();
				try
				{
					while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))->MoveNext())
					{
						BusinessManagerEntity_businesses_Data current3 = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))->Current;
						T1[] array2 = (T1[])(object)frmMain.setting.txtPageID_Partner.Split((char[])(object)new T9[1] { (T9)124 });
						T5 val14 = (T5)0;
						while ((nint)val14 < array2.Length)
						{
							T1 val15 = (T1)((object[])(object)array2)[(object)val14];
							T0 val16 = (T0)(!string.IsNullOrWhiteSpace((string)val15));
							if (val16 != null)
							{
								T1 val17 = (T1)string.Concat((string[])(object)new T1[5]
								{
									(T1)"https://graph.facebook.com/v15.0/",
									(T1)current3.id,
									(T1)"/business_users?access_token=",
									(T1)frmMain.listFBEntity[indexEntity].TokenEAAG,
									(T1)"&_reqName=object%3Abusiness%2Fbusiness_users&_reqSrc=BusinessConnectedConfirmedUsersStore.brands&date_format=U&fields=%5B%22email%22%2C%22expiry_time%22%2C%22first_name%22%2C%22finance_permission%22%2C%22developer_permission%22%2C%22ip_permission%22%2C%22partner_center_admin_permission%22%2C%22partner_center_analyst_permission%22%2C%22partner_center_education_permission%22%2C%22partner_center_marketing_permission%22%2C%22partner_center_operations_permission%22%2C%22last_name%22%2C%22manage_page_in_www%22%2C%22marked_for_removal%22%2C%22pending_email%22%2C%22role%22%2C%22two_fac_status%22%2C%22is_two_fac_blocked%22%2C%22was_integrity_demoted%22%2C%22sso_migration_status%22%2C%22business_role_request.fields(creation_source.fields(name)%2Ccreated_by.fields(name)%2Ccreated_time%2Cupdated_time)%22%2C%22transparency_info_seen_by%22%2C%22work_profile_pic%22%2C%22is_pending_integrity_review%22%2C%22is_ineligible_developer%22%5D&limit=25&locale=en_US&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref=f3c73166af176ac"
								});
								T1 val18 = (T1)((object)httpRequest.Get((string)val17, (RequestParams)null)).ToString();
								business_users business_users = JsonConvert.DeserializeObject<business_users>((string)val18);
								T1 val19 = (T1)string.Concat((string[])(object)new T1[17]
								{
									(T1)"av=",
									(T1)frmMain.listFBEntity[indexEntity].UID,
									(T1)"&__user=",
									(T1)frmMain.listFBEntity[indexEntity].UID,
									(T1)"&__a=1&__dyn=7xeUmxa2C5rgydwCwRyU8EKnFG2Om2q12wAxuq3mq1FxebzA3aF98Sm4Euxa16xq2WdwJwy-1Ex21FxG9y8Gdz8hwgo5S3a4EuCx62a2q5E9UeUryE5mWyUd8S3bg-3tpUdoK7UC5U7y78jxiUa8522m3K2y3WElUScyo720FoO12Kmu7EK3i2a3Fe6rwnVUao9k2B12ewi8doa84K5E5WUrorx2awCx5e8wxK2efK6F8W1dx-q4VEhwww9O3ifzobEaUiwrUK5Ue8Sp1G3WcwMzUkGum2ym2WE4e8wl8hyVEKu9zUbVEHyU8U3yDwbm1bwzwqp87qeCK2q&__csr=&__req=l&__hs=19304.BP%3Abrands_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=",
									(T1)frmMain.listFBEntity[indexEntity].__spin_r,
									(T1)"&__s=tpu5ti%3Aphaeqk%3Aojgyhj&__hsi=7163583109543975193&__comet_req=0&fb_dtsg=",
									(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
									(T1)"&jazoest=25271&lsd=Epf8Q-JcvYmgjoEIuqBNMr&__aaid=3408701206121062&__spin_r=",
									(T1)frmMain.listFBEntity[indexEntity].__spin_r,
									(T1)"&__spin_b=trunk&__spin_t=",
									(T1)frmMain.listFBEntity[indexEntity].__spin_t,
									(T1)"&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=PermissionTaskComponentHardImpliedTasksQuery&variables=%7B%22businessID%22%3A%22",
									(T1)current3.id,
									(T1)"%22%2C%22assetID%22%3A%22",
									val15,
									(T1)"%22%7D&server_timestamps=true&doc_id=5089147604465452"
								});
								val18 = (T1)((object)httpRequest.Post("https://business.facebook.com/api/graphql/", string.Concat((string[])(object)new T1[1] { val19 }), "application/x-www-form-urlencoded")).ToString();
								PermissionTaskPageBM permissionTaskPageBM = JsonConvert.DeserializeObject<PermissionTaskPageBM>((string)val18);
								T1 val20 = (T1)"";
								T0 val21 = (T0)(permissionTaskPageBM != null && permissionTaskPageBM.data != null && permissionTaskPageBM.data.business_object_rendered_in_ui != null && permissionTaskPageBM.data.business_object_rendered_in_ui.available_permission_tasks_ui_configs != null);
								if (val21 != null)
								{
									T5 val22 = (T5)0;
									T6 enumerator4 = (T6)permissionTaskPageBM.data.business_object_rendered_in_ui.available_permission_tasks_ui_configs.GetEnumerator();
									try
									{
										while (((List<available_permission_tasks_ui_configs>.Enumerator*)(&enumerator4))->MoveNext())
										{
											available_permission_tasks_ui_configs current4 = ((List<available_permission_tasks_ui_configs>.Enumerator*)(&enumerator4))->Current;
											T0 val23 = (T0)(!string.IsNullOrWhiteSpace((string)val20));
											if (val23 != null)
											{
												val20 = (T1)((string)val20 + "&");
											}
											val20 = (T1)((string)val20 + $"roles[{val22}]={current4.task_id}");
											val22 = (T5)(val22 + 1);
										}
									}
									finally
									{
										((IDisposable)(*(List<available_permission_tasks_ui_configs>.Enumerator*)(&enumerator4))).Dispose();
									}
								}
								T7 enumerator5 = (T7)business_users.data.GetEnumerator();
								try
								{
									while (((List<business_users_data>.Enumerator*)(&enumerator5))->MoveNext())
									{
										business_users_data current5 = ((List<business_users_data>.Enumerator*)(&enumerator5))->Current;
										val19 = (T1)string.Concat((string[])(object)new T1[19]
										{
											(T1)"asset_ids[0]=",
											val15,
											(T1)"&asset_type=page&business_id=",
											(T1)current3.id,
											(T1)"&",
											val20,
											(T1)"&user_ids[0]=",
											(T1)current5.id,
											(T1)"&__user=",
											(T1)frmMain.listFBEntity[indexEntity].UID,
											(T1)"&__a=1&__dyn=7xeUmxa2C5rgydwCwRyU8EKnFG2Om2q12wAxuq3mq1FxebzA3aF98Sm4Euxa16xq2WdwJwy-1Ex21FxG9y8Gdz8hwgo5S3a4EuCx62a2q5E9UeUryE5mWyUd8S3bg-3tpUdoK7UC5U7y78jxiUa8522m3K2y3WElUScyo720FoO12Kmu7EK3i2a3Fe6rwnVUao9k2B12ewi8doa84K5E5WUrorx2awCx5e8wxK2efK6F8W1dx-q4VEhwww9O3ifzobEaUiwrUK5Ue8Sp1G3WcwMzUkGum2ym2WE4e8wl8hyVEKu9zUbVEHyU8U3yDwbm1bwzwqp87qeCK2q&__csr=&__req=13&__hs=19304.BP%3Abrands_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=",
											(T1)frmMain.listFBEntity[indexEntity].__spin_r,
											(T1)"&__s=xsiatv%3A9bp51d%3Aisreof&__hsi=7163561003668999961&__comet_req=0&fb_dtsg=",
											(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
											(T1)"&jazoest=5412&lsd=1_czZSyWJ2g-4Zlwi8Bf3o&__aaid=754736582290219&__spin_r=",
											(T1)frmMain.listFBEntity[indexEntity].__spin_r,
											(T1)"&__spin_b=trunk&__spin_t=",
											(T1)frmMain.listFBEntity[indexEntity].__spin_t,
											(T1)"&__jssesw=1"
										});
										val18 = (T1)((object)httpRequest.Post("https://business.facebook.com/business/business_objects/update/permissions/", string.Concat((string[])(object)new T1[1] { val19 }), "application/x-www-form-urlencoded")).ToString();
									}
								}
								finally
								{
									((IDisposable)(*(List<business_users_data>.Enumerator*)(&enumerator5))).Dispose();
								}
								T0 val24 = (T0)(val2 == null);
								if (val24 != null)
								{
									break;
								}
							}
							val14 = (T5)(val14 + 1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))).Dispose();
				}
				setMessage<T0, T1, T5>((T1)"Share Page Ok", (T0)1);
			}
			else
			{
				setMessage<T0, T1, T5>((T1)"e:Không có BM", (T0)1);
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T5>((T1)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Delay<T0, T1>(FBFlow flow)
	{
		//IL_0017: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0052: Expected O, but got I4
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Expected O, but got I4
		T0 val = (T0)int.Parse(flow.getValue<object, List<FBFlowField>, T1, string>("Số_giây_nghỉ").ToString());
		T0 val2 = (T0)0;
		setMessage<T1, string, T0>($"Delay {val}", (T1)1);
		T1 val4;
		do
		{
			T1 val3 = (T1)(frmMain.isRunning && frmMain.listFBEntity[indexEntity].Select);
			if (val3 != null)
			{
				setMessage<T1, string, T0>($"Delay {(T0)(val2 + 1)}", (T1)0);
				Thread.Sleep(1000);
				val2 = (T0)(val2 + 1);
				val4 = (T1)(val2 >= val);
				continue;
			}
			break;
		}
		while (val4 == null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Add_thẻ_2<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0014: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_00e4: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		//IL_01e5: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_0212: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_023d: Expected O, but got I4
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_02fc: Expected O, but got I4
		//IL_0348: Expected O, but got I4
		//IL_0359: Expected O, but got I4
		//IL_03bc: Expected O, but got I4
		//IL_03bf: Expected O, but got I4
		//IL_03c7: Expected O, but got I4
		//IL_03cc: Expected O, but got I4
		//IL_03dd: Expected O, but got I4
		//IL_0440: Expected O, but got I4
		//IL_044a: Expected O, but got I4
		//IL_0458: Expected I4, but got O
		//IL_046b: Expected I4, but got O
		//IL_048a: Expected O, but got I4
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_04a4: Expected O, but got I4
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_04bc: Expected I4, but got O
		//IL_04e0: Expected O, but got I4
		//IL_04ea: Expected O, but got I4
		//IL_04fd: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_051f: Expected O, but got I4
		//IL_0526: Expected O, but got I4
		//IL_0537: Expected O, but got I4
		//IL_05d8: Expected O, but got I4
		//IL_0618: Expected I4, but got O
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0659: Expected I4, but got O
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_0674: Expected O, but got I4
		//IL_068a: Expected I4, but got O
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06a5: Expected O, but got I4
		//IL_06bb: Expected O, but got I4
		//IL_06ed: Expected I4, but got O
		//IL_0702: Expected O, but got I4
		//IL_0712: Expected I4, but got O
		//IL_072a: Expected I4, but got O
		//IL_0756: Expected I4, but got O
		//IL_0768: Expected I4, but got O
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0796: Expected I4, but got O
		//IL_07a8: Expected I4, but got O
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07d6: Expected I4, but got O
		//IL_07e8: Expected I4, but got O
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_0815: Expected O, but got I4
		//IL_0840: Expected I4, but got O
		//IL_0855: Expected O, but got I4
		//IL_085c: Expected O, but got I4
		//IL_0870: Expected O, but got I4
		//IL_089d: Expected I4, but got O
		//IL_08b0: Expected I4, but got O
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Expected O, but got Unknown
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Expected O, but got Unknown
		//IL_08e3: Expected O, but got I4
		//IL_090e: Expected O, but got I4
		//IL_0926: Expected I4, but got O
		//IL_093c: Expected I4, but got O
		//IL_0954: Expected O, but got I4
		//IL_0956: Unknown result type (might be due to invalid IL or missing references)
		//IL_0958: Expected O, but got Unknown
		//IL_0973: Expected O, but got I4
		//IL_09a0: Expected O, but got I4
		//IL_09ae: Expected O, but got I4
		//IL_09d5: Expected O, but got I4
		//IL_09e7: Expected O, but got I4
		//IL_0a0e: Expected O, but got I4
		//IL_0a32: Expected O, but got I4
		//IL_0a54: Expected O, but got I4
		//IL_0a76: Expected O, but got I4
		//IL_0aa9: Expected I4, but got O
		//IL_0ab7: Expected I4, but got O
		//IL_0ac5: Expected I4, but got O
		//IL_0ad3: Expected I4, but got O
		//IL_0ae2: Expected O, but got I4
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aec: Expected O, but got Unknown
		//IL_0af6: Expected O, but got I4
		//IL_0b0b: Expected O, but got I4
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Expected O, but got Unknown
		//IL_0b25: Expected O, but got I4
		//IL_0b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2b: Expected O, but got Unknown
		//IL_0b38: Expected O, but got I4
		//IL_0b53: Expected O, but got I4
		//IL_0b70: Expected O, but got I4
		//IL_0b88: Expected O, but got I4
		//IL_0baf: Expected O, but got I4
		//IL_0bc0: Expected O, but got I4
		//IL_0c11: Expected O, but got I4
		//IL_0c58: Expected O, but got I4
		//IL_0c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c60: Expected O, but got Unknown
		//IL_0c6a: Expected O, but got I4
		//IL_0c86: Expected O, but got I4
		//IL_0c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8e: Expected O, but got Unknown
		//IL_0ca8: Expected O, but got I4
		//IL_0cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Expected O, but got Unknown
		//IL_0cc2: Expected O, but got I4
		//IL_0cf8: Expected O, but got I4
		//IL_0d2c: Expected O, but got I4
		//IL_0d70: Expected O, but got I4
		//IL_0da0: Expected I4, but got O
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db0: Expected O, but got I4
		//IL_0db9: Expected O, but got I4
		//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc3: Expected O, but got Unknown
		//IL_0dcd: Expected O, but got I4
		//IL_0de2: Expected O, but got I4
		//IL_0dea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dec: Expected O, but got Unknown
		//IL_0df9: Expected O, but got I4
		//IL_0dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dff: Expected O, but got Unknown
		//IL_0e19: Expected O, but got I4
		//IL_0e34: Expected O, but got I4
		//IL_0e5c: Expected O, but got I4
		//IL_0ea0: Expected O, but got I4
		//IL_0ed0: Expected I4, but got O
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee0: Expected O, but got I4
		//IL_0ee9: Expected O, but got I4
		//IL_0ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef3: Expected O, but got Unknown
		//IL_0efd: Expected O, but got I4
		//IL_0f12: Expected O, but got I4
		//IL_0f1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1c: Expected O, but got Unknown
		//IL_0f29: Expected O, but got I4
		//IL_0f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2f: Expected O, but got Unknown
		//IL_0f49: Expected O, but got I4
		//IL_0f64: Expected O, but got I4
		//IL_0f8c: Expected O, but got I4
		//IL_0fd0: Expected O, but got I4
		//IL_1000: Expected I4, but got O
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1010: Expected O, but got I4
		//IL_1019: Expected O, but got I4
		//IL_1020: Unknown result type (might be due to invalid IL or missing references)
		//IL_1023: Expected O, but got Unknown
		//IL_102d: Expected O, but got I4
		//IL_1042: Expected O, but got I4
		//IL_104a: Unknown result type (might be due to invalid IL or missing references)
		//IL_104c: Expected O, but got Unknown
		//IL_1059: Expected O, but got I4
		//IL_105d: Unknown result type (might be due to invalid IL or missing references)
		//IL_105f: Expected O, but got Unknown
		//IL_1079: Expected O, but got I4
		//IL_1094: Expected O, but got I4
		//IL_10bc: Expected O, but got I4
		//IL_1100: Expected O, but got I4
		//IL_1130: Expected I4, but got O
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1140: Expected O, but got I4
		//IL_1149: Expected O, but got I4
		//IL_1150: Unknown result type (might be due to invalid IL or missing references)
		//IL_1153: Expected O, but got Unknown
		//IL_115d: Expected O, but got I4
		//IL_1172: Expected O, but got I4
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_117c: Expected O, but got Unknown
		//IL_1189: Expected O, but got I4
		//IL_118d: Unknown result type (might be due to invalid IL or missing references)
		//IL_118f: Expected O, but got Unknown
		//IL_11a9: Expected O, but got I4
		//IL_11c4: Expected O, but got I4
		//IL_11ec: Expected O, but got I4
		//IL_1230: Expected O, but got I4
		//IL_1260: Expected I4, but got O
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1270: Expected O, but got I4
		//IL_1279: Expected O, but got I4
		//IL_1280: Unknown result type (might be due to invalid IL or missing references)
		//IL_1283: Expected O, but got Unknown
		//IL_128d: Expected O, but got I4
		//IL_12a2: Expected O, but got I4
		//IL_12aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Expected O, but got Unknown
		//IL_12b9: Expected O, but got I4
		//IL_12bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bf: Expected O, but got Unknown
		//IL_12d9: Expected O, but got I4
		//IL_12f4: Expected O, but got I4
		//IL_131c: Expected O, but got I4
		//IL_1360: Expected O, but got I4
		//IL_1390: Expected I4, but got O
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a0: Expected O, but got I4
		//IL_13a9: Expected O, but got I4
		//IL_13b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b3: Expected O, but got Unknown
		//IL_13bd: Expected O, but got I4
		//IL_13d2: Expected O, but got I4
		//IL_13da: Unknown result type (might be due to invalid IL or missing references)
		//IL_13dc: Expected O, but got Unknown
		//IL_13e9: Expected O, but got I4
		//IL_13ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ef: Expected O, but got Unknown
		//IL_1409: Expected O, but got I4
		//IL_1424: Expected O, but got I4
		//IL_144c: Expected O, but got I4
		//IL_1490: Expected O, but got I4
		//IL_14c0: Expected I4, but got O
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d0: Expected O, but got I4
		//IL_14d9: Expected O, but got I4
		//IL_14e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e3: Expected O, but got Unknown
		//IL_14ed: Expected O, but got I4
		//IL_1502: Expected O, but got I4
		//IL_150a: Unknown result type (might be due to invalid IL or missing references)
		//IL_150c: Expected O, but got Unknown
		//IL_1519: Expected O, but got I4
		//IL_151d: Unknown result type (might be due to invalid IL or missing references)
		//IL_151f: Expected O, but got Unknown
		//IL_1539: Expected O, but got I4
		//IL_1554: Expected O, but got I4
		//IL_157c: Expected O, but got I4
		//IL_15c0: Expected O, but got I4
		//IL_15fc: Expected O, but got I4
		//IL_1636: Expected I4, but got O
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1647: Expected O, but got I4
		//IL_1650: Expected O, but got I4
		//IL_1657: Unknown result type (might be due to invalid IL or missing references)
		//IL_165a: Expected O, but got Unknown
		//IL_1664: Expected O, but got I4
		//IL_1679: Expected O, but got I4
		//IL_1684: Unknown result type (might be due to invalid IL or missing references)
		//IL_1686: Expected O, but got Unknown
		//IL_1693: Expected O, but got I4
		//IL_1697: Unknown result type (might be due to invalid IL or missing references)
		//IL_1699: Expected O, but got Unknown
		//IL_16b3: Expected O, but got I4
		//IL_16ce: Expected O, but got I4
		//IL_16dd: Expected O, but got I4
		//IL_1705: Expected O, but got I4
		//IL_1749: Expected O, but got I4
		//IL_1779: Expected I4, but got O
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1789: Expected O, but got I4
		//IL_1792: Expected O, but got I4
		//IL_1799: Unknown result type (might be due to invalid IL or missing references)
		//IL_179c: Expected O, but got Unknown
		//IL_17a6: Expected O, but got I4
		//IL_17bb: Expected O, but got I4
		//IL_17c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c5: Expected O, but got Unknown
		//IL_17d2: Expected O, but got I4
		//IL_17d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d8: Expected O, but got Unknown
		//IL_17f2: Expected O, but got I4
		//IL_180d: Expected O, but got I4
		//IL_1835: Expected O, but got I4
		//IL_1879: Expected O, but got I4
		//IL_18a9: Expected I4, but got O
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18b9: Expected O, but got I4
		//IL_18c2: Expected O, but got I4
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cc: Expected O, but got Unknown
		//IL_18d6: Expected O, but got I4
		//IL_18eb: Expected O, but got I4
		//IL_18f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f5: Expected O, but got Unknown
		//IL_1902: Expected O, but got I4
		//IL_1906: Unknown result type (might be due to invalid IL or missing references)
		//IL_1908: Expected O, but got Unknown
		//IL_1922: Expected O, but got I4
		//IL_193d: Expected O, but got I4
		//IL_196b: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)0;
			T1 val3 = (T1)0;
			T1 val4 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_lại_khi_lỗi").ToString());
			T0 vhhTK = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"VHH_Tk").ToString());
			T0 chrome = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Chrome").ToString());
			bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_TK_Cá_Nhân").ToString());
			bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_TK_Của_BM").ToString());
			T2 val5 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Quốc_gia_add_thẻ").ToString();
			T0 val6 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Chỉ_Add_vào_BM").ToString());
			T0 val7 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Đẩy_chính_TK_BM").ToString());
			T0 val8 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_link_1").ToString());
			T0 val9 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_link_2").ToString());
			T0 val10 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_thẳng_TK").ToString());
			T0 val11 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_link_667").ToString());
			T0 val12 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_qua_m_facebook").ToString());
			T0 val13 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_qua_Bostpost").ToString());
			T0 val14 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_qua_Suite").ToString());
			T0 val15 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_qua_API").ToString());
			T0 val16 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_m_facebook_2").ToString());
			T0 val17 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_Pro_5").ToString());
			T2 bin_mồi = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Bin_mồi").ToString();
			T2 val18 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Danh_sách_thẻ").ToString();
			T0 val19 = (T0)0;
			T0 val20 = (T0)(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_theo_danh_sách") != null);
			if (val20 != null)
			{
				val19 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_theo_danh_sách").ToString());
			}
			T3 val21 = frmMain.listCreditCardEntity<T1, T0, T3, T2>(val18);
			T0 val22 = (T0)(val21 == null);
			if (val22 != null)
			{
				val21 = (T3)Activator.CreateInstance(typeof(T3));
				T1 val23 = (T1)0;
				while (true)
				{
					T0 val24 = (T0)((nint)val23 < 99);
					if (val24 == null)
					{
						break;
					}
					T2 cardGen = BinGen2Class.getCardGen<T1, T2, CreditCardDetector, T0, Regex, DateTime, T11, object>(val18);
					((List<CreditCardEntity>)val21).Add(new CreditCardEntity
					{
						Card_Number = ((string)cardGen).Split((char[])(object)new T11[1] { (T11)124 })[0],
						Exp_Month = ((string)cardGen).Split((char[])(object)new T11[1] { (T11)124 })[1],
						Exp_Year = ((string)cardGen).Split((char[])(object)new T11[1] { (T11)124 })[2],
						Card_Security = ((string)cardGen).Split((char[])(object)new T11[1] { (T11)124 })[3],
						Status = frmMain.STATUS.Ready.ToString(),
						Select = true,
						Row = 1
					});
					val23 = (T1)(val23 + 1);
				}
			}
			T0 val25 = val19;
			if (val25 != null)
			{
				T0 val26 = val17;
				if (val26 != null)
				{
					T4 val27 = (T4)Activator.CreateInstance(typeof(T4));
					T5 listPro = getListPro5<T5, T2, T0, List<profile_switcher_eligible_profiles_nodes>.Enumerator, T10>();
					T0 val28 = (T0)(listPro == null || ((List<string>)listPro).Count <= 0);
					if (val28 != null)
					{
						setMessage<T0, T2, T1>((T2)"Không có page pro5", (T0)1);
						return;
					}
					T6 enumerator = (T6)((List<string>)listPro).GetEnumerator();
					try
					{
						while (((List<string>.Enumerator*)(&enumerator))->MoveNext())
						{
							T2 current = (T2)((List<string>.Enumerator*)(&enumerator))->Current;
							((List<facebook_pagesData>)val27).Add(new facebook_pagesData
							{
								id = (string)current,
								message = frmMain.STATUS.Ready.ToString()
							});
						}
					}
					finally
					{
						((IDisposable)(*(List<string>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				else
				{
					T1 val29 = (T1)0;
					T1 val30 = (T1)0;
					while (true)
					{
						T0 val31 = (T0)(!frmMain.isRunning);
						if (val31 != null)
						{
							return;
						}
						T1 val32 = (T1)(-1);
						while (true)
						{
							T0 val33 = (T0)(!frmActControl.isActive && frmMain.isRunning && frmMain.listFBEntity[indexEntity].Select);
							if (val33 == null)
							{
								break;
							}
							setMessage<T0, T2, T1>((T2)"Add thẻ lỗi! đang dừng", (T0)0);
							Thread.Sleep(3000);
						}
						T0 val34 = (T0)(!frmMain.isRunning || !frmMain.listFBEntity[indexEntity].Select);
						if (val34 != null)
						{
							return;
						}
						T1 val35 = (T1)0;
						while (true)
						{
							T0 val36 = (T0)((nint)val35 < frmMain.actList.Count);
							if (val36 != null)
							{
								T0 val37 = (T0)(frmMain.actList[(int)val35].Status != null && frmMain.actList[(int)val35].Status.Equals(frmMain.STATUS.Ready.ToString()));
								if (val37 == null)
								{
									val35 = (T1)(val35 + 1);
									continue;
								}
								val30 = (T1)(val30 + 1);
								frmMain.actList[(int)val35].Status = frmMain.STATUS.Processing.ToString();
								val32 = val35;
								break;
							}
							break;
						}
						T0 val38 = (T0)((nint)val32 != -1);
						if (val38 != null)
						{
							T1 val39 = (T1)(-1);
							while (true)
							{
								T0 val40 = (T0)frmMain.isRunning;
								if (val40 == null)
								{
									break;
								}
								val39 = getIndexCard<T1, T0, T3>(val21);
								T0 val41 = (T0)((nint)val39 == -1);
								if (val41 == null)
								{
									break;
								}
								setMessage<T0, T2, T1>((T2)"Hết thẻ, hãy add thêm thẻ", (T0)0);
								Thread.Sleep(3000);
							}
							T0 val42 = (T0)0;
							T0 val43 = (T0)frmMain.setting.actControl.cbAddBinBait;
							if (val43 != null)
							{
								CreditCardEntity creditCardEntity = new CreditCardEntity();
								T2 cardGen2 = BinGen2Class.getCardGen<T1, T2, CreditCardDetector, T0, Regex, DateTime, T11, object>((T2)frmMain.setting.actControl.txtBinBait);
								creditCardEntity.Card_Number = ((string)cardGen2).Split((char[])(object)new T11[1] { (T11)124 })[0];
								creditCardEntity.Exp_Month = ((string)cardGen2).Split((char[])(object)new T11[1] { (T11)124 })[1];
								creditCardEntity.Exp_Year = ((string)cardGen2).Split((char[])(object)new T11[1] { (T11)124 })[2];
								creditCardEntity.Card_Security = ((string)cardGen2).Split((char[])(object)new T11[1] { (T11)124 })[3];
								T0 val44 = (T0)(creditCardEntity.Exp_Year.Length > 2);
								if (val44 != null)
								{
									creditCardEntity.Exp_Year = creditCardEntity.Exp_Year.Substring(creditCardEntity.Exp_Year.Length - 2, 2);
								}
								T0 val45 = val10;
								if (val45 != null)
								{
									val42 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)0, vhhTK, chrome, (T2)frmMain.actList[(int)val32].Id, val5, bin_mồi, creditCardEntity, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
								}
								else
								{
									T0 val46 = val8;
									if (val46 == null)
									{
										T0 val47 = val9;
										if (val47 != null)
										{
											val42 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)0, vhhTK, chrome, (T2)frmMain.actList[(int)val32].Id, val5, bin_mồi, creditCardEntity, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1);
										}
									}
									else
									{
										val42 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)0, vhhTK, chrome, (T2)frmMain.actList[(int)val32].Id, val5, bin_mồi, creditCardEntity, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0);
									}
								}
								T0 val48 = (T0)(frmMain.setting.actControl.numCheckPayment > 0);
								if (val48 != null)
								{
									Thread.Sleep(frmMain.setting.actControl.numCheckPayment * 1000);
									T2 status = (T2)"";
									T0 val49 = check_status_payment<T0, T2, List<billing_payment_methods>.Enumerator, T10, T1, Color>((T2)frmMain.actList[(int)val32].Id, out *(string*)(&status));
									T0 val50 = (T0)(val49 == null);
									if (val50 == null)
									{
										frmMain.actList[(int)val32].Mồi = "";
									}
									else
									{
										frmMain.actList[(int)val32].Mồi = "MỒI CHẾT: " + (string)status;
									}
								}
							}
							T0 val51 = val10;
							if (val51 != null)
							{
								val42 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)0, vhhTK, chrome, (T2)frmMain.actList[(int)val32].Id, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)val39], (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
							}
							else
							{
								T0 val52 = val8;
								if (val52 != null)
								{
									val42 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)0, vhhTK, chrome, (T2)frmMain.actList[(int)val32].Id, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)val39], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0);
								}
								else
								{
									T0 val53 = val9;
									if (val53 != null)
									{
										val42 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)0, vhhTK, chrome, (T2)frmMain.actList[(int)val32].Id, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)val39], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1);
									}
								}
							}
							T2 status2 = (T2)"";
							T0 val54 = (T0)(frmMain.setting.actControl.numCheckPayment > 0);
							if (val54 != null)
							{
								Thread.Sleep(frmMain.setting.actControl.numCheckPayment * 1000);
								T0 val55 = check_status_payment<T0, T2, List<billing_payment_methods>.Enumerator, T10, T1, Color>((T2)frmMain.actList[(int)val32].Id, out *(string*)(&status2));
								T0 val56 = (T0)(val55 == null);
								if (val56 != null)
								{
									val42 = (T0)0;
								}
							}
							T0 val57 = val42;
							if (val57 == null)
							{
								T0 val58 = (T0)string.IsNullOrWhiteSpace((string)status2);
								if (val58 != null)
								{
									status2 = (T2)frmMain.listFBEntity[indexEntity].Note;
								}
								frmMain.actList[(int)val32].Message = (string)status2;
								frmMain.actList[(int)val32].Status = frmMain.STATUS.lỗi.ToString();
								val29 = (T1)(val29 + 1);
								val3 = (T1)(val3 + 1);
								T0 val59 = (T0)(frmMain.setting.actControl.numDieNext > 0);
								if (val59 != null)
								{
									frmActControl.CountError++;
									T0 val60 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
									if (val60 != null)
									{
										frmActControl.isActive = false;
									}
								}
							}
							else
							{
								frmMain.actList[(int)val32].Message = "";
								frmMain.actList[(int)val32].Status = frmMain.STATUS.Done.ToString();
								val29 = (T1)0;
								val2 = (T1)(val2 + 1);
								frmActControl.CountError = 0;
							}
							T0 val61 = (T0)((nint)val30 < frmMain.setting.actControl.numActOnVia);
							if (val61 != null)
							{
								T0 val62 = (T0)(frmMain.setting.actControl.numDieToStop == 0 || (nint)val29 < frmMain.setting.actControl.numDieToStop);
								if (val62 != null)
								{
									continue;
								}
							}
							setMessage<T0, T2, T1>((T2)$"Add thẻ done: {val2} lỗi: {val3}", (T0)1);
						}
						else
						{
							setMessage<T0, T2, T1>((T2)"Hết Tk", (T0)0);
						}
						break;
					}
				}
			}
			else
			{
				T0 val63 = val6;
				if (val63 != null)
				{
					setMessage<T0, T2, T1>((T2)"Chỉ_Add_vào_BM", (T0)0);
					T2 strError = (T2)"";
					T7 bMList = getBMList<T2, T0, T7, T10>(out *(string*)(&strError));
					T0 val64 = (T0)(bMList != null && ((List<BusinessManagerEntity_businesses_Data>)bMList).Count > 0);
					if (val64 != null)
					{
						T8 enumerator2 = (T8)((List<BusinessManagerEntity_businesses_Data>)bMList).GetEnumerator();
						try
						{
							while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								BusinessManagerEntity_businesses_Data current2 = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))->Current;
								T1 val65 = (T1)0;
								while (true)
								{
									T1 indexCard = getIndexCard<T1, T0, T3>(val21);
									T0 val66 = (T0)((nint)indexCard == -1);
									if (val66 == null)
									{
										T2 id = (T2)current2.id;
										setMessage<T0, T2, T1>((T2)("BM: " + (string)id), (T0)0);
										T2 strPaymentAccountId = Get_Payment_Account_Id_BM<T2, T0, T10>(id);
										T0 val67 = (T0)(addCardToBM<T2, T0, T10>(chrome, out *(string*)(&strError), id, strPaymentAccountId, val5, (T2)((string)ChromeControl.getFirstName<T0, T2, T1>() + " " + (string)ChromeControl.getLastName<T0, T2, T1>()), (T2)((List<CreditCardEntity>)val21)[(int)indexCard].Card_Number, (T2)((List<CreditCardEntity>)val21)[(int)indexCard].Card_Security, (T2)((List<CreditCardEntity>)val21)[(int)indexCard].Exp_Month, (T2)((List<CreditCardEntity>)val21)[(int)indexCard].Exp_Year) == null);
										if (val67 != null)
										{
											val65 = (T1)(val65 + 1);
											T0 val68 = (T0)(val65 >= val4);
											if (val68 == null)
											{
												continue;
											}
											val3 = (T1)(val3 + 1);
											setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
										}
										else
										{
											val2 = (T1)(val2 + 1);
											setMessage<T0, T2, T1>((T2)"Add thẻ BM=>Ok", (T0)1);
										}
										goto IL_0b38;
									}
									setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
									break;
								}
								break;
								IL_0b38:;
							}
						}
						finally
						{
							((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
					else
					{
						setMessage<T0, T2, T1>((T2)"e:Không có BM", (T0)1);
					}
				}
				T0 val69 = val7;
				if (val69 != null)
				{
					setMessage<T0, T2, T1>((T2)"Đẩy_chính_TK_BM", (T0)0);
					T2 strError2 = (T2)"";
					T7 bMList2 = getBMList<T2, T0, T7, T10>(out *(string*)(&strError2));
					T0 val70 = (T0)(bMList2 == null || ((List<BusinessManagerEntity_businesses_Data>)bMList2).Count <= 0);
					if (val70 != null)
					{
						setMessage<T0, T2, T1>((T2)"e:Không có BM", (T0)1);
					}
					else
					{
						T8 enumerator3 = (T8)((List<BusinessManagerEntity_businesses_Data>)bMList2).GetEnumerator();
						try
						{
							while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))->MoveNext())
							{
								BusinessManagerEntity_businesses_Data current3 = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))->Current;
								T2 id2 = (T2)current3.id;
								adaccounts fullAdsInfo_In_BM = getFullAdsInfo_In_BM<T2, T0>(id2);
								T0 val71 = (T0)(fullAdsInfo_In_BM != null && fullAdsInfo_In_BM.data != null && fullAdsInfo_In_BM.data.Count > 0);
								if (val71 != null)
								{
									T9 enumerator4 = (T9)fullAdsInfo_In_BM.data.GetEnumerator();
									try
									{
										while (((List<adaccountsData>.Enumerator*)(&enumerator4))->MoveNext())
										{
											adaccountsData current4 = ((List<adaccountsData>.Enumerator*)(&enumerator4))->Current;
											T2 val72 = (T2)current4.id.Replace("act_", "");
											T2 strError3 = (T2)"";
											T1 val73 = (T1)0;
											while (true)
											{
												T0 val74 = (T0)(Set_Payment_BM_Cho_Act(chrome, val72, id2, (T2)"", out *(string*)(&strError3)) == null);
												if (val74 != null)
												{
													val73 = (T1)(val73 + 1);
													T0 val75 = (T0)((nint)val73 >= 3);
													if (val75 != null)
													{
														val3 = (T1)(val3 + 1);
														setMessage<T0, T2, T1>((T2)("e:Share thẻ lỗi: " + (string)strError3), (T0)1);
														break;
													}
													continue;
												}
												val2 = (T1)(val2 + 1);
												setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val72 + "=>Ok"), (T0)0);
												break;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator4))).Dispose();
									}
								}
								else
								{
									setMessage<T0, T2, T1>((T2)("e:" + (string)id2 + ": Không có TK"), (T0)1);
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
				}
				T0 val76 = val10;
				if (val76 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_thẳng_TK", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator5 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator5))->MoveNext())
						{
							adaccountsData current5 = ((List<adaccountsData>.Enumerator*)(&enumerator5))->Current;
							T1 val77 = (T1)0;
							while (true)
							{
								T1 indexCard2 = getIndexCard<T1, T0, T3>(val21);
								T0 val78 = (T0)((nint)indexCard2 == -1);
								if (val78 == null)
								{
									T2 val79 = (T2)current5.id.Replace("act_", "");
									T0 val80 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val79, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard2], (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
									T0 val81 = (T0)(val80 == null);
									if (val81 != null)
									{
										val77 = (T1)(val77 + 1);
										T0 val82 = (T0)(val77 >= val4);
										if (val82 != null)
										{
											val3 = (T1)(val3 + 1);
											setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
											break;
										}
										continue;
									}
									val2 = (T1)(val2 + 1);
									setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val79 + "=>Ok"), (T0)0);
									break;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								goto end_IL_0e19;
							}
							continue;
							end_IL_0e19:
							break;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator5))).Dispose();
					}
				}
				T0 val83 = val11;
				if (val83 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_link_667", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator6 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator6))->MoveNext())
						{
							adaccountsData current6 = ((List<adaccountsData>.Enumerator*)(&enumerator6))->Current;
							T1 val84 = (T1)0;
							while (true)
							{
								T1 indexCard3 = getIndexCard<T1, T0, T3>(val21);
								T0 val85 = (T0)((nint)indexCard3 == -1);
								if (val85 == null)
								{
									T2 val86 = (T2)current6.id.Replace("act_", "");
									T0 val87 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val86, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard3], (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
									T0 val88 = (T0)(val87 == null);
									if (val88 != null)
									{
										val84 = (T1)(val84 + 1);
										T0 val89 = (T0)(val84 >= val4);
										if (val89 != null)
										{
											val3 = (T1)(val3 + 1);
											setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
											break;
										}
										continue;
									}
									val2 = (T1)(val2 + 1);
									setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val86 + "=>Ok"), (T0)0);
									break;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								goto end_IL_0f49;
							}
							continue;
							end_IL_0f49:
							break;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator6))).Dispose();
					}
				}
				T0 val90 = val12;
				if (val90 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_qua_m_facebook", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator7 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator7))->MoveNext())
						{
							adaccountsData current7 = ((List<adaccountsData>.Enumerator*)(&enumerator7))->Current;
							T1 val91 = (T1)0;
							while (true)
							{
								T1 indexCard4 = getIndexCard<T1, T0, T3>(val21);
								T0 val92 = (T0)((nint)indexCard4 == -1);
								if (val92 == null)
								{
									T2 val93 = (T2)current7.id.Replace("act_", "");
									T0 val94 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val93, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard4], (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
									T0 val95 = (T0)(val94 == null);
									if (val95 != null)
									{
										val91 = (T1)(val91 + 1);
										T0 val96 = (T0)(val91 >= val4);
										if (val96 == null)
										{
											continue;
										}
										val3 = (T1)(val3 + 1);
										setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
									}
									else
									{
										val2 = (T1)(val2 + 1);
										setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val93 + "=>Ok"), (T0)0);
									}
									goto IL_1079;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_1079:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator7))).Dispose();
					}
				}
				T0 val97 = val13;
				if (val97 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_qua_Bostpost", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator8 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator8))->MoveNext())
						{
							adaccountsData current8 = ((List<adaccountsData>.Enumerator*)(&enumerator8))->Current;
							T1 val98 = (T1)0;
							while (true)
							{
								T1 indexCard5 = getIndexCard<T1, T0, T3>(val21);
								T0 val99 = (T0)((nint)indexCard5 == -1);
								if (val99 == null)
								{
									T2 val100 = (T2)current8.id.Replace("act_", "");
									T0 val101 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val100, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard5], (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
									T0 val102 = (T0)(val101 == null);
									if (val102 != null)
									{
										val98 = (T1)(val98 + 1);
										T0 val103 = (T0)(val98 >= val4);
										if (val103 == null)
										{
											continue;
										}
										val3 = (T1)(val3 + 1);
										setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
									}
									else
									{
										val2 = (T1)(val2 + 1);
										setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val100 + "=>Ok"), (T0)0);
									}
									goto IL_11a9;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_11a9:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator8))).Dispose();
					}
				}
				T0 val104 = val14;
				if (val104 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_qua_Suite", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator9 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator9))->MoveNext())
						{
							adaccountsData current9 = ((List<adaccountsData>.Enumerator*)(&enumerator9))->Current;
							T1 val105 = (T1)0;
							while (true)
							{
								T1 indexCard6 = getIndexCard<T1, T0, T3>(val21);
								T0 val106 = (T0)((nint)indexCard6 == -1);
								if (val106 == null)
								{
									T2 val107 = (T2)current9.id.Replace("act_", "");
									T0 val108 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val107, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard6], (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
									T0 val109 = (T0)(val108 == null);
									if (val109 != null)
									{
										val105 = (T1)(val105 + 1);
										T0 val110 = (T0)(val105 >= val4);
										if (val110 == null)
										{
											continue;
										}
										val3 = (T1)(val3 + 1);
										setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
									}
									else
									{
										val2 = (T1)(val2 + 1);
										setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val107 + "=>Ok"), (T0)0);
									}
									goto IL_12d9;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_12d9:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator9))).Dispose();
					}
				}
				T0 val111 = val15;
				if (val111 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_qua_API", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator10 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator10))->MoveNext())
						{
							adaccountsData current10 = ((List<adaccountsData>.Enumerator*)(&enumerator10))->Current;
							T1 val112 = (T1)0;
							while (true)
							{
								T1 indexCard7 = getIndexCard<T1, T0, T3>(val21);
								T0 val113 = (T0)((nint)indexCard7 == -1);
								if (val113 == null)
								{
									T2 val114 = (T2)current10.id.Replace("act_", "");
									T0 val115 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val114, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard7], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0);
									T0 val116 = (T0)(val115 == null);
									if (val116 != null)
									{
										val112 = (T1)(val112 + 1);
										T0 val117 = (T0)(val112 >= val4);
										if (val117 != null)
										{
											val3 = (T1)(val3 + 1);
											setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
											break;
										}
										continue;
									}
									val2 = (T1)(val2 + 1);
									setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val114 + "=>Ok"), (T0)0);
									break;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								goto end_IL_1409;
							}
							continue;
							end_IL_1409:
							break;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator10))).Dispose();
					}
				}
				T0 val118 = val16;
				if (val118 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_qua_m_facebook_2", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator11 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator11))->MoveNext())
						{
							adaccountsData current11 = ((List<adaccountsData>.Enumerator*)(&enumerator11))->Current;
							T1 val119 = (T1)0;
							while (true)
							{
								T1 indexCard8 = getIndexCard<T1, T0, T3>(val21);
								T0 val120 = (T0)((nint)indexCard8 == -1);
								if (val120 == null)
								{
									T2 val121 = (T2)current11.id.Replace("act_", "");
									T0 val122 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val121, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard8], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0);
									T0 val123 = (T0)(val122 == null);
									if (val123 != null)
									{
										val119 = (T1)(val119 + 1);
										T0 val124 = (T0)(val119 >= val4);
										if (val124 == null)
										{
											continue;
										}
										val3 = (T1)(val3 + 1);
										setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
									}
									else
									{
										val2 = (T1)(val2 + 1);
										setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val121 + "=>Ok"), (T0)0);
									}
									goto IL_1539;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_1539:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator11))).Dispose();
					}
				}
				T0 val125 = val17;
				if (val125 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add pro5", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator12 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator12))->MoveNext())
						{
							adaccountsData current12 = ((List<adaccountsData>.Enumerator*)(&enumerator12))->Current;
							T1 val126 = (T1)0;
							while (true)
							{
								T1 indexCard9 = getIndexCard<T1, T0, T3>(val21);
								T0 val127 = (T0)((nint)indexCard9 == -1);
								if (val127 == null)
								{
									T2 val128 = (T2)current12.id.Replace("act_", "");
									T5 listPro2 = getListPro5<T5, T2, T0, List<profile_switcher_eligible_profiles_nodes>.Enumerator, T10>();
									T0 val129 = (T0)(listPro2 == null || ((List<string>)listPro2).Count <= 0);
									if (val129 == null)
									{
										T2 pro5Id = (T2)((List<string>)listPro2)[rnd.Next(0, ((List<string>)listPro2).Count - 1)];
										T0 val130 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val128, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard9], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, pro5Id);
										T0 val131 = (T0)(val130 == null);
										if (val131 != null)
										{
											val126 = (T1)(val126 + 1);
											T0 val132 = (T0)(val126 >= val4);
											if (val132 == null)
											{
												continue;
											}
											val3 = (T1)(val3 + 1);
											setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
										}
										else
										{
											val2 = (T1)(val2 + 1);
											setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val128 + "=>Ok"), (T0)0);
										}
										goto IL_16b3;
									}
									setMessage<T0, T2, T1>((T2)"Không có page pro5", (T0)1);
									break;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_16b3:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator12))).Dispose();
					}
				}
				T0 val133 = val8;
				if (val133 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_link_1", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator13 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator13))->MoveNext())
						{
							adaccountsData current13 = ((List<adaccountsData>.Enumerator*)(&enumerator13))->Current;
							T1 val134 = (T1)0;
							while (true)
							{
								T1 indexCard10 = getIndexCard<T1, T0, T3>(val21);
								T0 val135 = (T0)((nint)indexCard10 == -1);
								if (val135 == null)
								{
									T2 val136 = (T2)current13.id.Replace("act_", "");
									T0 val137 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val136, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard10], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0);
									T0 val138 = (T0)(val137 == null);
									if (val138 != null)
									{
										val134 = (T1)(val134 + 1);
										T0 val139 = (T0)(val134 >= val4);
										if (val139 == null)
										{
											continue;
										}
										val3 = (T1)(val3 + 1);
										setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
									}
									else
									{
										val2 = (T1)(val2 + 1);
										setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val136 + "=>Ok"), (T0)0);
									}
									goto IL_17f2;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_17f2:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator13))).Dispose();
					}
				}
				T0 val140 = val9;
				if (val140 != null)
				{
					setMessage<T0, T2, T1>((T2)"Add_link_1", (T0)0);
					getFullAdsInfo<T2, T0>();
					T9 enumerator14 = (T9)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator14))->MoveNext())
						{
							adaccountsData current14 = ((List<adaccountsData>.Enumerator*)(&enumerator14))->Current;
							T1 val141 = (T1)0;
							while (true)
							{
								T1 indexCard11 = getIndexCard<T1, T0, T3>(val21);
								T0 val142 = (T0)((nint)indexCard11 == -1);
								if (val142 == null)
								{
									T2 val143 = (T2)current14.id.Replace("act_", "");
									T0 val144 = addCard<T0, T2, T1, T10, T11, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, vhhTK, chrome, val143, val5, bin_mồi, ((List<CreditCardEntity>)val21)[(int)indexCard11], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1);
									T0 val145 = (T0)(val144 == null);
									if (val145 != null)
									{
										val141 = (T1)(val141 + 1);
										T0 val146 = (T0)(val141 >= val4);
										if (val146 == null)
										{
											continue;
										}
										val3 = (T1)(val3 + 1);
										setMessage<T0, T2, T1>((T2)"e:Add thẻ lỗi", (T0)1);
									}
									else
									{
										val2 = (T1)(val2 + 1);
										setMessage<T0, T2, T1>((T2)("Add thẻ " + (string)val143 + "=>Ok"), (T0)0);
									}
									goto IL_1922;
								}
								setMessage<T0, T2, T1>((T2)"e:Hết thẻ", (T0)1);
								break;
							}
							break;
							IL_1922:;
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator14))).Dispose();
					}
				}
			}
			setMessage<T0, T2, T1>((T2)$"Add thẻ done: {val2} lỗi: {val3}", (T0)1);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void addCardByPro5<T0, T1>(T0 creditCardEntities, T1 country)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 addByPro5<T0, T1, T2, T3>(T3 httpRequest, T1 pro5Id, T1 fb_dtsg, T1 countryCode, T1 Bin_mồi, CreditCardEntity card, T1 act, out string result)
	{
		//IL_000a: Expected O, but got I4
		//IL_0211: Expected O, but got I4
		result = "";
		T0 result2 = (T0)1;
		try
		{
			((HttpRequest)httpRequest).AddHeader("authority", "secure.facebook.com");
			((HttpRequest)httpRequest).AddHeader("accept", "*/*");
			((HttpRequest)httpRequest).AddHeader("accept-language", "en-US,en;q=0.9");
			((HttpRequest)httpRequest).AddHeader("origin", "https://www.facebook.com");
			((HttpRequest)httpRequest).AddHeader("referer", "https://www.facebook.com/");
			((HttpRequest)httpRequest).AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
			((HttpRequest)httpRequest).AddHeader("sec-ch-ua-mobile", "?0");
			((HttpRequest)httpRequest).AddHeader("sec-ch-ua-platform", "\"Windows\"");
			((HttpRequest)httpRequest).AddHeader("sec-fetch-dest", "empty");
			((HttpRequest)httpRequest).AddHeader("sec-fetch-mode", "cors");
			((HttpRequest)httpRequest).AddHeader("sec-fetch-site", "same-site");
			((HttpRequest)httpRequest).AddHeader("x-fb-friendly-name", "useBillingAddCreditCardMutation");
			((HttpRequest)httpRequest).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36";
			T1 val = (T1)string.Concat((string[])(object)new T1[25]
			{
				(T1)"av=",
				pro5Id,
				(T1)"&payment_dev_cycle=prod&__usid=6-Trm8dm710oqi2%3APrm8dm8oiybw%3A0-Arm8dm71ns7xz8-RV%3D6%3AF%3D&__user=",
				pro5Id,
				(T1)"&__a=1&__dyn=7AzHxqU5a9zk1ryaxG4VuC0BVU98nwgUb84ibyQdwSAx-bwNxW3W3O2Saxa1NxZ38C1twUx60p-0LVEtwMw65xO2OU7m221FwgolzUO0n2US2G5Usw9m1cwLwBgK7o6C0Mo5W3S1lwlE-UqwsUkxe2GewywuoqBwJK2W5olwUwlu5o4q0GpovUaUe82xxWm4UpCwLyES0Io5d08O322m2m2e3u362-2B0oobo8o&__req=42&__hs=19327.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=1006667578&__s=vj6xkd%3Al3ms4z%3A3aez0y&__hsi=7172291302238261646&__comet_req=15&fb_dtsg=",
				fb_dtsg,
				(T1)"&jazoest=25619&lsd=MMEVKK0nWD3sSpinU5C6bp&__aaid=820383459080981&__spin_r=1006667578&__spin_b=trunk&__spin_t=1669929200&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22billing_address%22%3A%7B%22country_code%22%3A%22",
				countryCode,
				(T1)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A22%2C%22logging_id%22%3A%223779790846%22%7D%2C%22cardholder_name%22%3A%22tanhgold%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
				Bin_mồi,
				(T1)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
				(T1)card.Card_Number.Substring(card.Card_Number.Length - 4, 4),
				(T1)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
				(T1)card.Card_Number,
				(T1)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
				(T1)card.Card_Security,
				(T1)"%22%7D%2C%22expiry_month%22%3A%22",
				(T1)card.Exp_Month,
				(T1)"%22%2C%22expiry_year%22%3A%22",
				(T1)card.Exp_Year,
				(T1)"%22%2C%22payment_account_id%22%3A%22",
				act,
				(T1)"%22%2C%22payment_type%22%3A%22MOR_ADS_STORED_BALANCE%22%2C%22unified_payments_api%22%3Atrue%2C%22actor_id%22%3A%22",
				pro5Id,
				(T1)"%22%2C%22client_mutation_id%22%3A%226%22%7D%7D&server_timestamps=true&doc_id=4987045951343337"
			});
			result = ((object)((HttpRequest)httpRequest).Post("https://secure.facebook.com/ajax/payment/token_proxy.php?tpe=%2Fapi%2Fgraphql%2F", (string)val, "application/x-www-form-urlencoded")).ToString();
		}
		catch (Exception ex)
		{
			result2 = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 getListPro5<T0, T1, T2, T3, T4>()
	{
		//IL_0124: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		try
		{
			try
			{
				try
				{
					T1 val2 = (T1)string.Concat((string[])(object)new T1[7]
					{
						(T1)"av=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__user=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__a=1&__dyn=7AzHxqU5a5Q1ryaxG4VuC0BVU98nwgU765QdwSwAyU8EW1twYwJyEiwsobo6u3y4o11U2nwb-q7oc81xoswIK1Rwwwg8a8465o-cwfG12wOKdwGxu782lwv89kbxS1Fwc61axe3S1lwlE-UqwsUkxe2GewywmUtxGm2SUbElxm3y11xfxmu3W2i4U72m7-8wywdqUuBwJCwLyES0Io88cA0z8c84qifxe3u362-2B0oobo8o&__csr=iT0Eh4nlOFs9YQ_t_8j_bRZn9kiD949dnieOOjIzRiOiFVpbmmH8IGLhacWrRlalatalqQuql7ucTyaBJkVV8Z2pd4D_8EChASVe8mAuVHAGufGi4VHyGFkloGvBGmXihV8Oq9Ze48OqVanGAaxPx10PUtxeimdyoK9zE8VUSFkmFUqjyAu-5XLx-iamUjyo-cyUSp1ymax62fyEx1q6oe8tyE4mEnGdx2dAzotxaU7C78iwByUkU9orwwxhe32m686vybz8bUym3m1PwBg6CaK2S78owh84PBwJwmU8ob809yU0iKw0wzw3bk1cw0uDE0c7E1NQ0i209rw2xU0Ii09gw4bAw4Jw1xtQ1pwzCgtw7Xw1s60ata0pK06Up64h07q1zw0PaAt4zA4hdk0q2VyCw9i221iw5BwGwdHw7lwop2w4Yw2aA0hC2C0Jo&__req=17&__hs=19328.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=1006673605&__s=04kf4h%3Acee8gc%3Au1p4a5&__hsi=7172493681628173779&__comet_req=15&fb_dtsg=",
						(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T1)"&jazoest=25736&lsd=bQuJbN5f-Vjij6dQggSE86&__aaid=654172436159447&__spin_r=1006673605&__spin_b=trunk&__spin_t=1669976320&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=PageCometLaunchpointLeftNavMenuRootQuery&variables=%7B%22showUpdatedLaunchpointRedesign%22%3Atrue%2C%22useAdminedPagesForActingAccount%22%3Afalse%2C%22useNewPagesYouManage%22%3Atrue%7D&server_timestamps=true&doc_id=5300338636681652"
					});
					T1 val3 = (T1)((object)httpRequest.Post("https://www.facebook.com/api/graphql/", (string)val2, "application/x-www-form-urlencoded")).ToString();
					GetPro5 getPro = JsonConvert.DeserializeObject<GetPro5>((string)val3);
					T2 val4 = (T2)(getPro != null && getPro.data != null && getPro.data.viewer != null && getPro.data.viewer.actor != null && getPro.data.viewer.actor.profile_switcher_eligible_profiles != null && getPro.data.viewer.actor.profile_switcher_eligible_profiles.nodes != null);
					if (val4 != null)
					{
						T3 enumerator = (T3)getPro.data.viewer.actor.profile_switcher_eligible_profiles.nodes.GetEnumerator();
						try
						{
							while (((List<profile_switcher_eligible_profiles_nodes>.Enumerator*)(&enumerator))->MoveNext())
							{
								profile_switcher_eligible_profiles_nodes current = ((List<profile_switcher_eligible_profiles_nodes>.Enumerator*)(&enumerator))->Current;
								T2 val5 = (T2)(current.profile != null);
								if (val5 != null)
								{
									T2 val6 = (T2)(!((List<string>)val).Contains(current.profile.id));
									if (val6 != null)
									{
										((List<string>)val).Add(current.profile.id);
									}
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<profile_switcher_eligible_profiles_nodes>.Enumerator*)(&enumerator))).Dispose();
						}
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 addCard<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 checkLive, T0 vhhTK, T0 Chrome, T1 Act, T1 CountryCode, T1 Bin_mồi, CreditCardEntity Card, T0 AddNormal, T0 MFacebook, T0 Add_qua_Bostpost, T0 Add_qua_Suite, T0 AddLink667, T0 addAPI, T0 isMFacebook_2, T0 isPro5, T0 Add_link_1, T0 Add_link_2, T1 pro5Id = default(T1))
	{
		//IL_0002: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_05e0: Expected O, but got I4
		//IL_060b: Expected O, but got I4
		//IL_07e3: Expected O, but got I4
		//IL_080f: Expected O, but got I4
		//IL_0aea: Expected O, but got I4
		//IL_0b23: Expected O, but got I4
		//IL_0b6b: Expected O, but got I4
		//IL_0b79: Expected O, but got I4
		//IL_0bb2: Expected O, but got I4
		//IL_0bfa: Expected O, but got I4
		//IL_0c1d: Expected O, but got I4
		//IL_0c40: Expected O, but got I4
		//IL_0c42: Expected O, but got I4
		//IL_0fb2: Expected O, but got I4
		//IL_12bf: Expected O, but got I4
		//IL_12fd: Expected O, but got I4
		//IL_1346: Expected O, but got I4
		//IL_137a: Expected O, but got I4
		//IL_1383: Expected O, but got I4
		//IL_13a4: Expected O, but got I4
		//IL_1cb7: Expected O, but got I4
		//IL_1cf5: Expected O, but got I4
		//IL_1d3e: Expected O, but got I4
		//IL_1d72: Expected O, but got I4
		//IL_1d7b: Expected O, but got I4
		//IL_2311: Expected O, but got I4
		//IL_265b: Expected O, but got I4
		//IL_2699: Expected O, but got I4
		//IL_26e2: Expected O, but got I4
		//IL_2716: Expected O, but got I4
		//IL_271f: Expected O, but got I4
		//IL_282a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2834: Expected O, but got Unknown
		//IL_2886: Expected O, but got I4
		//IL_28c5: Expected O, but got I4
		//IL_28df: Expected O, but got I4
		//IL_28f8: Expected O, but got I4
		//IL_2937: Expected O, but got I4
		//IL_296a: Unknown result type (might be due to invalid IL or missing references)
		//IL_296d: Expected O, but got Unknown
		//IL_2977: Expected O, but got I4
		//IL_29a2: Expected O, but got I4
		//IL_29ac: Expected I4, but got O
		//IL_2a11: Expected O, but got I4
		//IL_2a4f: Expected O, but got I4
		//IL_2a98: Expected O, but got I4
		//IL_2aa7: Expected O, but got I4
		//IL_2ae5: Expected O, but got I4
		//IL_2b2e: Expected O, but got I4
		//IL_2b52: Expected O, but got I4
		//IL_2b72: Expected O, but got I4
		//IL_2b74: Expected O, but got I4
		//IL_2bb0: Expected O, but got I4
		//IL_2be3: Expected O, but got I4
		//IL_2c93: Expected O, but got I4
		//IL_2cec: Expected O, but got I4
		//IL_2d26: Expected O, but got I4
		//IL_2e7a: Expected O, but got I4
		//IL_2ed8: Expected O, but got I4
		//IL_2f16: Expected O, but got I4
		//IL_2f5f: Expected O, but got I4
		//IL_2f6e: Expected O, but got I4
		//IL_2fac: Expected O, but got I4
		//IL_2ff5: Expected O, but got I4
		//IL_3019: Expected O, but got I4
		//IL_3039: Expected O, but got I4
		//IL_303b: Expected O, but got I4
		//IL_306b: Expected O, but got I4
		//IL_309e: Expected O, but got I4
		//IL_3159: Expected O, but got I4
		//IL_31b2: Expected O, but got I4
		//IL_31ec: Expected O, but got I4
		//IL_3232: Expected O, but got I4
		//IL_339f: Expected O, but got I4
		//IL_33dd: Expected O, but got I4
		//IL_3426: Expected O, but got I4
		//IL_3435: Expected O, but got I4
		//IL_3473: Expected O, but got I4
		//IL_34bc: Expected O, but got I4
		//IL_34cb: Expected O, but got I4
		//IL_34eb: Expected O, but got I4
		//IL_34ed: Expected O, but got I4
		//IL_352b: Expected O, but got I4
		//IL_355e: Expected O, but got I4
		//IL_36a8: Expected O, but got I4
		//IL_36b1: Expected O, but got I4
		//IL_3817: Expected O, but got I4
		//IL_384a: Expected O, but got I4
		//IL_3906: Expected O, but got I4
		//IL_390b: Unknown result type (might be due to invalid IL or missing references)
		//IL_390e: Expected O, but got Unknown
		//IL_3918: Expected O, but got I4
		//IL_3978: Expected O, but got I4
		//IL_397e: Expected O, but got I4
		//IL_3985: Expected O, but got I4
		//IL_3e2e: Expected O, but got I4
		//IL_4262: Expected O, but got I4
		//IL_42a0: Expected O, but got I4
		//IL_42e9: Expected O, but got I4
		//IL_431d: Expected O, but got I4
		//IL_4323: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			Act = (T1)((string)Act).ToLower().Replace("act_", "");
			if (vhhTK != null)
			{
				disableAct<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, Act, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
			}
			setMessage<T0, T1, T2>((T1)("Add thẻ: " + (string)Act), (T0)0);
			if (AddNormal != null)
			{
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/manager/account_settings/account_billing/";
				T1 val = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjomj1dvkmjw%3APrjjomg1sxhqq0%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe484e4824yoyaxG4o7i2G15wxwUwCwuE9FEdUmCBBwLghUbqQGxBa2dum11K6UC5U7y78jCggwExm3G4UhwXwEwl-dwh85G0CEtwAKdxWbwQwnHxC1zVoao9k2B12ewzwAwgoszUeUmwnEvorx2awCx5e8wxK2efK6Ejwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFo2nz85S4oiyVUCcG3qazo8U3yDwqU4C1bwzwqp8aE4K6osyo&__csr=&__req=1i&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=67cama%3Awib606%3Awwohpl&__hsi=7152915123459913621&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25421&lsd=Fl8BnI2PCPe6PSQV379NiT&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665417832&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardProductContextQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5670634143000359"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/manager/account_settings/account_billing/";
				val = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjomj1dvkmjw%3APrjjomg1sxhqq0%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe484e4824yoyaxG4o7i2G15wxwUwCwuE9FEdUmCBBwLghUbqQGxBa2dum11K6UC5U7y78jCggwExm3G4UhwXwEwl-dwh85G0CEtwAKdxWbwQwnHxC1zVoao9k2B12ewzwAwgoszUeUmwnEvorx2awCx5e8wxK2efK6Ejwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFo2nz85S4oiyVUCcG3qazo8U3yDwqU4C1bwzwqp8aE4K6osyo&__csr=&__req=1j&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=67cama%3Awib606%3Awwohpl&__hsi=7152915123459913621&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25421&lsd=Fl8BnI2PCPe6PSQV379NiT&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665417832&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAddPaymentMethodInitStateStateQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5022661927861573"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/manager/account_settings/account_billing/";
				T0 val2 = (T0)(Card.Exp_Year.Length == 2);
				if (val2 != null)
				{
					Card.Exp_Year = "20" + Card.Exp_Year;
				}
				T2 val3 = (T2)int.Parse(Card.Exp_Month);
				T1 val4 = (T1)string.Concat((string[])(object)new T1[45]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&payment_dev_cycle=prod&__usid=6-Trsl1v5ddly2t%3APrsl1sdwwy5a1%3A0-Arsl1v51vi4xyu-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__req=1a&__hs=19451.BP%3Aads_campaign_manager_pkg.2.0..0.0&dpr=1.5&__ccg=UNKNOWN&__rev=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_r,
					(T1)"&__s=8zgbtu%3Ak6kv72%3Alxsxyx&__hsi=",
					(T1)((!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].hsi)) ? frmMain.listFBEntity[indexEntity].hsi : "7218113847172721870"),
					(T1)"&__dyn=7xeUmxa2C5rgydwCwRyu2abheCEnxim2q12xCagjGqErxqqax2366UjyXgC3eF98Sm4EuGfyUeEjG4Erzobo-4Jxe3a26486C6EC8yEScx611wOwGwOxa7FEhwyg9omwwCwXxKaCwTxqWBBwLjzu2SJaECfiwzlBwRyXxK9xu1UxN1ap3bBwyxm3G4UhwXzoqwgolUScyo725UtwrUO12Kmu7EK3i2a3Fe6rwRwFVoao9kbxR2V8W2e2i3mbxOfwXxq1uK6S6UgyHwyx6i8wxK2efKawzwjovCxeq4o88dE6mi2-fzobEaUiwm8myUnwUzpA6EfEO32fxiFVoa9obGwSz8yfyUe8hyVEKu9zawLCyKbwzweau1Hwio4K2e2617AwGwgVUWqU9E5C1dwXzEkw&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=",
					(T1)((!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].jazoest)) ? frmMain.listFBEntity[indexEntity].jazoest : "25524"),
					(T1)"&lsd=y43ZLotPB77rac1XlDwCdv&__aaid=",
					Act,
					(T1)"&__spin_r=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_r,
					(T1)"&__spin_b=trunk&__spin_t=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_t,
					(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22billing_address%22%3A%7B%22country_code%22%3A%22",
					CountryCode,
					(T1)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A",
					(T1)System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)rnd.Next(11, 99)).ToString(),
					(T1)"%2C%22logging_id%22%3A%22376950",
					(T1)System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)rnd.Next(3333, 9999)).ToString(),
					(T1)"%22%7D%2C%22cardholder_name%22%3A%22",
					(T1)((string)ChromeControl.getFirstName<T0, T1, T2>()).ToUpper(),
					(T1)"%20",
					(T1)((string)ChromeControl.getLastName<T0, T1, T2>()).ToUpper(),
					(T1)"%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(0, 6),
					(T1)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4),
					(T1)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number,
					(T1)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Security,
					(T1)"%22%7D%2C%22expiry_month%22%3A%22",
					(T1)((int*)(&val3))->ToString(),
					(T1)"%22%2C%22expiry_year%22%3A%22",
					(T1)Card.Exp_Year,
					(T1)"%22%2C%22payment_account_id%22%3A%22",
					Act,
					(T1)"%22%2C%22payment_type%22%3A%22MOR_ADS_INVOICE%22%2C%22unified_payments_api%22%3Atrue%2C%22actor_id%22%3A%22",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"%22%2C%22client_mutation_id%22%3A%222%22%7D%7D&server_timestamps=true&doc_id=4987045951343337"
				});
				if (Chrome != null)
				{
					try
					{
						httpRequest.KeepAlive = true;
						httpRequest.Accept = "*/*";
						httpRequest.AddHeader("accept-encoding", "gzip, deflate");
						httpRequest.AddHeader("accept-language", "en-US,en;q=0.9");
						httpRequest.ContentType = "application/x-www-form-urlencoded";
						httpRequest.AddHeader("origin", "https://adsmanager.facebook.com");
						httpRequest.Referer = "https://adsmanager.facebook.com/";
						httpRequest.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
						httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
						httpRequest.AddHeader("sec-ch-ua-platform", "\"Windows\"");
						httpRequest.AddHeader("sec-fetch-dest", "empty");
						httpRequest.AddHeader("sec-fetch-mode", "cors");
						httpRequest.AddHeader("sec-fetch-site", "same-site");
						httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
						httpRequest.AddHeader("x-fb-friendly-name", "useBillingAddCreditCardMutation");
						httpRequest.AddHeader("authority", "secure.facebook.com");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				val = (T1)((object)httpRequest.Post("https://adsmanager.secure.facebook.com/ajax/payment/token_proxy.php?tpe=/api/graphql/", string.Concat((string[])(object)new T1[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.UserAgent = Http.FirefoxUserAgent();
				T0 val5 = (T0)((string)val).Contains("description");
				if (val5 != null)
				{
					T1 value = (T1)Regex.Match((string)val, "description\":\"(.*?)\"").Groups[1].Value;
					value = (T1)Regex.Unescape((string)value);
					T0 val6 = (T0)((string)val).Contains("api_error_code");
					if (val6 != null)
					{
						value = (T1)(Regex.Match((string)val, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value);
					}
					frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value);
				}
				T0 val7 = (T0)((string)val).Contains("description");
				if (val7 != null)
				{
					T1 value2 = (T1)Regex.Match((string)val, "description\":\"(.*?)\"").Groups[1].Value;
					value2 = (T1)Regex.Unescape((string)value2);
					T0 val8 = (T0)((string)val).Contains("api_error_code");
					if (val8 != null)
					{
						value2 = (T1)(Regex.Match((string)val, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value2);
					}
					frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value2);
				}
				T0 val9 = (T0)((string)val).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
				if (val9 != null)
				{
					frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", (T1)"");
					result = (T0)1;
				}
			}
			else if (AddLink667 != null)
			{
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/help/contact/649167531904667";
				T1 val10 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjomj1dvkmjw%3APrjjomg1sxhqq0%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe484e4824yoyaxG4o7i2G15wxwUwCwuE9FEdUmCBBwLghUbqQGxBa2dum11K6UC5U7y78jCggwExm3G4UhwXwEwl-dwh85G0CEtwAKdxWbwQwnHxC1zVoao9k2B12ewzwAwgoszUeUmwnEvorx2awCx5e8wxK2efK6Ejwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFo2nz85S4oiyVUCcG3qazo8U3yDwqU4C1bwzwqp8aE4K6osyo&__csr=&__req=1i&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=67cama%3Awib606%3Awwohpl&__hsi=7152915123459913621&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25421&lsd=Fl8BnI2PCPe6PSQV379NiT&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665417832&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardProductContextQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5670634143000359"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/help/contact/649167531904667";
				val10 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjomj1dvkmjw%3APrjjomg1sxhqq0%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe484e4824yoyaxG4o7i2G15wxwUwCwuE9FEdUmCBBwLghUbqQGxBa2dum11K6UC5U7y78jCggwExm3G4UhwXwEwl-dwh85G0CEtwAKdxWbwQwnHxC1zVoao9k2B12ewzwAwgoszUeUmwnEvorx2awCx5e8wxK2efK6Ejwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFo2nz85S4oiyVUCcG3qazo8U3yDwqU4C1bwzwqp8aE4K6osyo&__csr=&__req=1j&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=67cama%3Awib606%3Awwohpl&__hsi=7152915123459913621&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25421&lsd=Fl8BnI2PCPe6PSQV379NiT&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665417832&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAddPaymentMethodInitStateStateQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5022661927861573"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/help/contact/649167531904667";
				T0 val11 = (T0)(Card.Exp_Year.Length == 2);
				if (val11 != null)
				{
					Card.Exp_Year = "20" + Card.Exp_Year;
				}
				T1 val12 = (T1)string.Concat((string[])(object)new T1[31]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&payment_dev_cycle=prod&__usid=6-Trjiq1c34vhi2%3APrjiq175s4m4r%3A0-Arjiq0m1wphg19-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe3a264824yoyaxG4o7i2G15wmE9E7G2qq3u5FFpobQ4u2SJaEpiwznBwgrxK9xu1UxN1ap122y5oeEjx63K2y1nUScwTwmE2qxS2iUS7EK3i1uK6o6fBwFwBgak48W2e2i11xOfwXxq1uxZxK48G2q4kUy26U8U-Uqxe1dwCxe68882sAw_zobEaUiwuUnwhFA6E2cxiaBw9ucwnohxabDyoOEdEGdwzweau1Hwio4K2e1FAwGwiUWaxO9w&__req=17&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=MODERATE&__rev=1006356336&__s=tywl9j%3A1zr2lm%3A8z8vlj&__hsi=7152722583750348152&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25563&lsd=hJdnVJElBiOAEJlD4kdizk&__aaid=",
					Act,
					(T1)"&__spin_r=1006356336&__spin_b=trunk&__spin_t=1665373003&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22billing_address%22%3A%7B%22country_code%22%3A%22",
					CountryCode,
					(T1)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A15%2C%22logging_id%22%3A%22946262452%22%7D%2C%22cardholder_name%22%3A%22",
					ChromeControl.getFirstName<T0, T1, T2>(),
					(T1)"%20",
					ChromeControl.getLastName<T0, T1, T2>(),
					(T1)"%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(0, 6),
					(T1)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4),
					(T1)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number,
					(T1)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Security,
					(T1)"%22%7D%2C%22expiry_month%22%3A%22",
					(T1)Card.Exp_Month,
					(T1)"%22%2C%22expiry_year%22%3A%22",
					(T1)Card.Exp_Year,
					(T1)"%22%2C%22payment_account_id%22%3A%22",
					Act,
					(T1)"%22%2C%22payment_type%22%3A%22MOR_ADS_INVOICE%22%2C%22unified_payments_api%22%3Atrue%2C%22actor_id%22%3A%22",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"%22%2C%22client_mutation_id%22%3A%221%22%7D%7D&server_timestamps=true&doc_id=4987045951343337"
				});
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				val10 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_SECURE_PAYMENT") + "?tpe=/api/graphql/", string.Concat((string[])(object)new T1[1] { val12 }), "application/x-www-form-urlencoded")).ToString();
				val10 = (T1)Regex.Unescape((string)val10);
				T0 val13 = (T0)((string)val10).Contains("description");
				if (val13 != null)
				{
					T1 value3 = (T1)Regex.Match((string)val10, "description\":\"(.*?)\"").Groups[1].Value;
					value3 = (T1)Regex.Unescape((string)value3);
					T0 val14 = (T0)((string)val10).Contains("api_error_code");
					if (val14 != null)
					{
						value3 = (T1)(Regex.Match((string)val10, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value3);
					}
					frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value3);
				}
				httpRequest.UserAgent = Http.FirefoxUserAgent();
				T0 val15 = (T0)((string)val10).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
				if (val15 != null)
				{
					result = (T0)1;
				}
			}
			else if (MFacebook != null)
			{
				T0 val16 = (T0)(Card.Exp_Year.Length == 2);
				if (val16 != null)
				{
					Card.Exp_Year = "20" + Card.Exp_Year;
				}
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = "Mozilla/5.0 (Linux; Android 13) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.5359.128 Mobile Safari/537.36";
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://m",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/ads/manage/billing/?account_id=",
					Act,
					(T1)"&eav=AfZMvkeG9rLTPu3drKhJK6C4bmGBSrYzAI_yPNye07P-tx0_Rp09Eln-VD--pcSF2Sg&paipv=0&ext=1665677966&hash=AeQ3_GMbDipYWRtb6W0"
				});
				T1 val17 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpcmt2ia0t%3APrjjpcibgazjp%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=1KQEGiE5q5Ujwh8-t0BBBgS5UqxK12wAxu3-U6C4UqwSAwHxW4E2qxK4o1nEhwem0iy1gCwjE1xoswaq1Jwt8-0nSUS0ka2-2l0Fwwyo36w9yq3q0H8-7E2swp834wmE2ewnE2Lx-220gO2S3qazo11E2ZwiU8U6C2-0z8&__csr=&__req=n&__hs=19275.BP%3Amtouch_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=5vkmxb%3Alcodcy%3Ar1v0yi&__hsi=7152919066773610426&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25519&lsd=-6KqOAQYj3PnmZgoYUBnmn&__aaid=",
					Act,
					(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingQEQuery&variables=%7B%22hasPaymentAccount%22%3Atrue%2C%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%2C%22universes%22%3A%5B%7B%22params%22%3A%5B%22show_billing_wizard_test%22%2C%22show_both_buttons%22%2C%22show_both_test%22%2C%22show_button_billing_wizard%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22ads_payments_billing_hub_contact_support%22%7D%2C%7B%22params%22%3A%5B%22auto_reload_supported%22%2C%22prepay_supported%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22auto_reload_testing_v1%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2021h2_ad_account_id%22%2C%22params%22%3A%5B%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22billing_h2_2021%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2022h1_ad_account_id%22%2C%22params%22%3A%5B%22all_unblock_options%22%2C%22backup_option_only%22%2C%22backup_pm_payment_settings_options%22%2C%22make_primary_checked%22%2C%22make_primary_checked_v2%22%2C%22make_primary_unchecked%22%2C%22make_primary_unchecked_v2%22%2C%22show_make_primary_checkbox%22%2C%22show_make_primary_checkbox_v2%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22billing_solutions_to_unblock_universe%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2021h2_ad_account_id%22%2C%22params%22%3A%5B%22is_eos_with_30_days%22%2C%22is_eos_with_30_days_v2%22%2C%22is_eos_with_anniversary%22%2C%22is_eos_with_anniversary_v2%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22end_of_spend_universe%22%7D%2C%7B%22params%22%3A%5B%22bv_enabled%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22flex_billing_h1_2021%22%7D%2C%7B%22params%22%3A%5B%22show_preauth_after_add_cc%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22pre_auth_experiment_bi%22%7D%2C%7B%22params%22%3A%5B%22show_support%22%5D%2C%22universe_name%22%3A%22risk_ops_contact_support%22%7D%2C%7B%22params%22%3A%5B%22show_restricted_addfunds%22%5D%2C%22universe_name%22%3A%22sdc_verification_on_add_funds%22%7D%2C%7B%22params%22%3A%5B%22show_restricted_paynow%22%5D%2C%22universe_name%22%3A%22sdc_verification_on_pay_now%22%7D%2C%7B%22params%22%3A%5B%22enable_nux%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22standard_billing_2021_h2%22%7D%5D%7D&server_timestamps=true&doc_id=5787537841277053"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://m",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/ads/manage/billing/?account_id=",
					Act,
					(T1)"&eav=AfZMvkeG9rLTPu3drKhJK6C4bmGBSrYzAI_yPNye07P-tx0_Rp09Eln-VD--pcSF2Sg&paipv=0&ext=1665677966&hash=AeQ3_GMbDipYWRtb6W0"
				});
				val17 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpcmt2ia0t%3APrjjpcibgazjp%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=1KQEGiE5q5Ujwh8-t0BBBgS5UqxK12wAxu3-U6C4UqwSAwHxW4E2qxK4o1nEhwem0iy1gCwjE1xoswaq1Jwt8-0nSUS0ka2-2l0Fwwyo36w9yq3q0H8-7E2swp834wmE2ewnE2Lx-220gO2S3qazo11E2ZwiU8U6C2-0z8&__csr=&__req=p&__hs=19275.BP%3Amtouch_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=5vkmxb%3Alcodcy%3Ar1v0yi&__hsi=7152919066773610426&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25519&lsd=-6KqOAQYj3PnmZgoYUBnmn&__aaid=",
					Act,
					(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardProductContextQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5670634143000359"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://m",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/ads/manage/billing/?account_id=",
					Act,
					(T1)"&eav=AfZMvkeG9rLTPu3drKhJK6C4bmGBSrYzAI_yPNye07P-tx0_Rp09Eln-VD--pcSF2Sg&paipv=0&ext=1665677966&hash=AeQ3_GMbDipYWRtb6W0"
				});
				val17 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpcmt2ia0t%3APrjjpcibgazjp%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=1KQEGiE5q5Ujwh8-t0BBBgS5UqxK12wAxu3-U6C4UqwSAwHxW4E2qxK4o1nEhwem0iy1gCwjE1xoswaq1Jwt8-0nSUS0ME7-2-2l0Fwwyo36w9yq3q6U2gzUuw9O1Awci1qw8W1uCway7U887O0zUbodEGdw46wsU4C1bwzwqobU2cw&__csr=&__req=q&__hs=19275.BP%3Amtouch_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=5vkmxb%3Alcodcy%3Ar1v0yi&__hsi=7152919066773610426&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25519&lsd=-6KqOAQYj3PnmZgoYUBnmn&__aaid=",
					Act,
					(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAddPaymentMethodInitStateStateQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5022661927861573"
				}) }), "application/x-www-form-urlencoded")).ToString();
				httpRequest.SslProtocols = SslProtocols.Tls12;
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://m",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/ads/manage/billing/?account_id=",
					Act,
					(T1)"&eav=AfZMvkeG9rLTPu3drKhJK6C4bmGBSrYzAI_yPNye07P-tx0_Rp09Eln-VD--pcSF2Sg&paipv=0&ext=1665677966&hash=AeQ3_GMbDipYWRtb6W0"
				});
				val17 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpcmt2ia0t%3APrjjpcibgazjp%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=1KQEGiE5q5Ujwh8-t0BBBgS5UqxK12wAxu3-U6C4UqwSAwHxW4E2qxK4o1nEhwem0iy1gCwjE1xoswaq1Jwt8-0nSUS0ME7-2-2l0Fwwyo36w9yq3q6U2gzUuw9O1Awci1qw8W1uCway7U887O0zUbodEGdw46wsU4C1bwzwqobU2cw&__csr=&__req=r&__hs=19275.BP%3Amtouch_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=5vkmxb%3Alcodcy%3Ar1v0yi&__hsi=7152919066773610426&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25519&lsd=-6KqOAQYj3PnmZgoYUBnmn&__aaid=",
					Act,
					(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardLandingScreenQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5987803917897133"
				}) }), "application/x-www-form-urlencoded")).ToString();
				T1 val18 = (T1)string.Concat((string[])(object)new T1[31]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&payment_dev_cycle=prod&__usid=6-Trjitc41o13c7c%3APrjitcl1dw6mro%3A0-Arjitc4m70zqs-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=1KQEGiE5q5Ujwh8-t0BBBgS5UqxK12wAxu3-U6C4UqwSAwHxW4E2qxK4o4K0ha4o3Bw4Ewk9E4W0om782Cwro7ifw5ZKdwca1_wLwBgao88C0NE2oCwSxK0A8-7E2swp834wmE2ewnFE2Ex-221Yw8-2S3qazo11E7e19wiU8U6C2-0z8&__req=1n&__hs=19275.BP%3Amtouch_pkg.2.0.0.0.0&dpr=1&__ccg=MODERATE&__rev=1006356336&__s=%3Avptfzh%3Av45ou3&__hsi=7152741001609894176&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25723&lsd=R88AEMI5xk317rO6yPl9Gd&__aaid=",
					Act,
					(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22client_mutation_id%22%3A%224%22%2C%22actor_id%22%3A%22",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"%22%2C%22billing_address%22%3A%7B%22country_code%22%3A%22",
					CountryCode,
					(T1)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A21%2C%22logging_id%22%3A%223084382846%22%7D%2C%22cardholder_name%22%3A%22",
					ChromeControl.getFirstName<T0, T1, T2>(),
					(T1)"%20",
					ChromeControl.getLastName<T0, T1, T2>(),
					(T1)"%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(0, 6),
					(T1)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4),
					(T1)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number,
					(T1)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Security,
					(T1)"%22%7D%2C%22expiry_month%22%3A%22",
					(T1)Card.Exp_Month,
					(T1)"%22%2C%22expiry_year%22%3A%22",
					(T1)Card.Exp_Year,
					(T1)"%22%2C%22payment_account_id%22%3A%22",
					Act,
					(T1)"%22%2C%22payment_type%22%3A%22MOR_ADS_INVOICE%22%2C%22unified_payments_api%22%3Atrue%7D%7D&server_timestamps=true&doc_id=4987045951343337"
				});
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = "Mozilla/5.0 (Linux; Android 13) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.5359.128 Mobile Safari/537.36";
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://m",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/ads/manage/billing/?account_id=",
					Act,
					(T1)"&eav=AfZMvkeG9rLTPu3drKhJK6C4bmGBSrYzAI_yPNye07P-tx0_Rp09Eln-VD--pcSF2Sg&paipv=0&ext=1665677966&hash=AeQ3_GMbDipYWRtb6W0"
				});
				val17 = (T1)((object)httpRequest.Post("https://m.secure" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ajax/payment/token_proxy.php?tpe=%2Fapi%2Fgraphql%2F", string.Concat((string[])(object)new T1[1] { val18 }), "application/x-www-form-urlencoded")).ToString();
				val17 = (T1)Regex.Unescape((string)val17);
				T0 val19 = (T0)((string)val17).Contains("description");
				if (val19 != null)
				{
					T1 value4 = (T1)Regex.Match((string)val17, "description\":\"(.*?)\"").Groups[1].Value;
					value4 = (T1)Regex.Unescape((string)value4);
					T0 val20 = (T0)((string)val17).Contains("api_error_code");
					if (val20 != null)
					{
						value4 = (T1)(Regex.Match((string)val17, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value4);
					}
					frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value4);
				}
				httpRequest.UserAgent = Http.FirefoxUserAgent();
				T0 val21 = (T0)((string)val17).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
				if (val21 != null)
				{
					result = (T0)1;
				}
			}
			else if (Add_qua_Bostpost == null)
			{
				if (Add_qua_Suite != null)
				{
					httpRequest.SslProtocols = SslProtocols.Tls12;
					if (Chrome != null)
					{
						httpRequest.KeepAlive = true;
						httpRequest.AddHeader("viewport-width", "1229");
						httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
						httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
						httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
						httpRequest.UserAgent = strUserAgentDesktop;
						httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
						httpRequest.AddHeader("Sec-Fetch-Site", "none");
						httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
						httpRequest.AddHeader("Sec-Fetch-User", "?1");
						httpRequest.AddHeader("Sec-Fetch-Dest", "document");
					}
					httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=102459842633456";
					T1 val22 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
					{
						(T1)"av=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__usid=6-Trjjq4r1ar3cd8%3APrjjq7o1w1jdtb%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo8o3uwu9E4W0OE2WxO2O1Vwooa8465o-0nSUS2G3i1uwbe2l0Fwwwi85W1ywnEfogwh85qfK6E28xe3C2au1NwkEbEaU6K2a5U4q3eE7y7U2-wrEjxC3qazo11E2ZwBwwAwzwTwNwLw8O&__csr=&__req=2n&__hs=19275.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=rd571d%3A67bmk9%3Aa052hs&__hsi=7152923971386432477&__comet_req=0&fb_dtsg=",
						(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T1)"&lsd=YpchZAZt_oGfyaP8A1lPzd&__aaid=",
						Act,
						(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419892&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=LWICometValidationNoticesProviderConstraintsQuery&variables=%7B%22input%22%3A%7B%22ad_account_id%22%3A%22",
						Act,
						(T1)"%22%2C%22client_spec_override%22%3Anull%2C%22page_id%22%3A%22102459842633456%22%2C%22product%22%3A%22BOOSTED_PAGELIKE%22%2C%22objective%22%3A%22PAGE_LIKES%22%7D%2C%22cta_type%22%3A%22LIKE_PAGE%22%7D&server_timestamps=true&doc_id=3830262120432240"
					}) }), "application/x-www-form-urlencoded")).ToString();
					httpRequest.SslProtocols = SslProtocols.Tls12;
					httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=102459842633456";
					val22 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
					{
						(T1)"av=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__usid=6-Trjjq4r1ar3cd8%3APrjjq7o1w1jdtb%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo8o3uwu9E4W0OE2WxO2O1Vwooa8465o-0nSUS2G3i1uwbe2l0Fwwwi85W1ywnEfogwh85qfK6E28xe3C2au1NwkEbEaU6K2a5U4q3eE7y7U2-wrEjxC3qazo11E2ZwBwwAwzwTwNwLw8O&__csr=&__req=2o&__hs=19275.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=rd571d%3A67bmk9%3Aa052hs&__hsi=7152923971386432477&__comet_req=0&fb_dtsg=",
						(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T1)"&lsd=YpchZAZt_oGfyaP8A1lPzd&__aaid=",
						Act,
						(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419892&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=LWICometCreationCouponBannerRootQuery&variables=%7B%22adAccountID%22%3A%22",
						Act,
						(T1)"%22%2C%22boostedComponentProduct%22%3A%22BOOSTED_PAGELIKE%22%2C%22entryPoint%22%3A%22BOOSTED_COMPONENT_CREATION%22%2C%22campaignGroupID%22%3Anull%7D&server_timestamps=true&doc_id=5695475823829766"
					}) }), "application/x-www-form-urlencoded")).ToString();
					httpRequest.SslProtocols = SslProtocols.Tls12;
					httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=102459842633456";
					val22 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
					{
						(T1)"av=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__usid=6-Trjjq4r1ar3cd8%3APrjjq7o1w1jdtb%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo8o3uwu9E4W0OE2WxO2O1Vwooa8465o-0nSUS2G3i1uwbe2l0Fwwwi85W1ywnEfogwh85qfK6E28xe3C2au1NwkEbEaU6K2a5U4q3eE7y7U2-wrEjxC3qazo11E2ZwBwwAwzwTwNwLw8O&__csr=&__req=2p&__hs=19275.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=rd571d%3A67bmk9%3Aa052hs&__hsi=7152923971386432477&__comet_req=0&fb_dtsg=",
						(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T1)"&lsd=YpchZAZt_oGfyaP8A1lPzd&__aaid=",
						Act,
						(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419892&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=LWICometPaymentMethodSectionLiveQuery&variables=%7B%22paymentAccountID%22%3A%22",
						Act,
						(T1)"%22%2C%22passCometReliabilityRollout%22%3Atrue%7D&server_timestamps=true&doc_id=4830379213729197"
					}) }), "application/x-www-form-urlencoded")).ToString();
					httpRequest.SslProtocols = SslProtocols.Tls12;
					httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=102459842633456";
					val22 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[15]
					{
						(T1)"av=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__usid=6-Trjjq4r1ar3cd8%3APrjjq7o1w1jdtb%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo8o3uwu9E4W0OE2WxO2O1Vwooa8465o-0nSUS2G3i1uwbe2l0Fwwwi85W1ywnEfogwh85qfK6E28xe3C2au1NwkEbEaU6K2a5U4q3eE7y7U2-wrEjxC3qazo11E2ZwBwwAwzwTwNwLw8O&__csr=&__req=2q&__hs=19275.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=rd571d%3A67bmk9%3Aa052hs&__hsi=7152923971386432477&__comet_req=0&fb_dtsg=",
						(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T1)"&lsd=YpchZAZt_oGfyaP8A1lPzd&__aaid=",
						Act,
						(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419892&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=LWICometValidationNoticesProviderQuery&variables=%7B%22input%22%3A%7B%22boost_id%22%3Anull%2C%22creation_spec%22%3A%7B%22ads_lwi_goal%22%3A%22GET_PAGE_LIKES%22%2C%22audience_option%22%3A%22NCPP%22%2C%22auto_boost_settings_id%22%3Anull%2C%22auto_targeting_sources%22%3Anull%2C%22billing_event%22%3A%22IMPRESSIONS%22%2C%22budget%22%3A500%2C%22budget_type%22%3A%22DAILY_BUDGET%22%2C%22currency%22%3A%22USD%22%2C%22duration_in_days%22%3A5%2C%22franchise_program_id%22%3Anull%2C%22is_automatic_goal%22%3Afalse%2C%22legacy_ad_account_id%22%3A%22",
						Act,
						(T1)"%22%2C%22legacy_entry_point%22%3A%22bizweb_home_header%22%2C%22messenger_welcome_message%22%3Anull%2C%22pixel_event_type%22%3Anull%2C%22pixel_id%22%3Anull%2C%22placement_spec%22%3A%7B%22publisher_platforms%22%3A%5B%22FACEBOOK%22%5D%7D%2C%22regulated_categories%22%3A%5B%5D%2C%22regulated_category%22%3A%22NONE%22%2C%22retargeting_enabled%22%3Afalse%2C%22run_continuously%22%3Afalse%2C%22saved_audience_id%22%3Anull%2C%22special_ad_category_countries%22%3A%5B%5D%2C%22start_time%22%3Anull%2C%22surface%22%3A%22BIZ_WEB%22%2C%22targeting_spec_string%22%3A%22%7B%5C%22age_min%5C%22%3A18%2C%5C%22age_max%5C%22%3A65%2C%5C%22geo_locations%5C%22%3A%7B%5C%22countries%5C%22%3A%5B%5C%22US%5C%22%5D%2C%5C%22location_types%5C%22%3A%5B%5C%22home%5C%22%5D%7D%7D%22%2C%22adgroup_specs%22%3A%5B%7B%22creative%22%3A%7B%22degrees_of_freedom_spec%22%3A%7B%22degrees_of_freedom_type%22%3A%22USER_ENROLLED_LWI_ACO%22%7D%2C%22instagram_branded_content%22%3A%7B%7D%2C%22object_story_spec%22%3A%7B%22link_data%22%3A%7B%22call_to_action%22%3A%7B%22type%22%3A%22LIKE_PAGE%22%2C%22value%22%3A%7B%22page%22%3A%22102459842633456%22%7D%7D%2C%22link%22%3A%22https%3A%2F%2Fwww",
						(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
						(T1)"%2F102459842633456%22%2C%22message%22%3A%22Connect%20with%20Vin%C3%ADcius%20J%C3%BAnior%2035474392%22%2C%22picture%22%3A%22https%3A%2F%2Fbusiness",
						(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
						(T1)"%2Fads%2Fimage%2F%3Fd%3DAQJo96be-B_6KeIllCDzVF_tXRG6bK51f5BWYSaWzZYjI9uXXh_EhCK_-qJ4ZOUmNL84E-7Fhx33Nn-lvGLINA90YQsluAFblQ_hiWGYof2oi12s5SVxoSGDttin5Ahq684kYCt1Tdmw0taAYfAp-6w5%22%2C%22use_flexible_image_aspect_ratio%22%3Atrue%7D%2C%22page_id%22%3A%22102459842633456%22%7D%2C%22use_page_actor_override%22%3Anull%7D%7D%5D%2C%22cta_data%22%3Anull%2C%22objective%22%3A%22PAGE_LIKES%22%7D%2C%22flow_id%22%3A%22b3cd9e83-72d8-4b72-b39a-a9fe925cfa53%22%2C%22manual_review_requested%22%3Afalse%2C%22page_id%22%3A%22102459842633456%22%2C%22product%22%3A%22BOOSTED_PAGELIKE%22%7D%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=5641891389201875"
					}) }), "application/x-www-form-urlencoded")).ToString();
					T0 val23 = (T0)(Card.Exp_Year.Length == 2);
					if (val23 != null)
					{
						Card.Exp_Year = "20" + Card.Exp_Year;
					}
					httpRequest.SslProtocols = SslProtocols.Tls12;
					httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=102459842633456";
					T1 val24 = (T1)string.Concat((string[])(object)new T1[31]
					{
						(T1)"av=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&payment_dev_cycle=prod&__usid=6-Trjj0dy8mnzet%3APrjj0dyr00v98%3A0-Arjizs51m1kvg8-RV%3D6%3AF%3D&__user=",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo8o3uwu9E4W0OE2WxO2O1Vwooa8465o-0nSUS2G3i1uK1_wLwBgao884y1uwoE5W3S48G3C1mzXxG0y8jwVwyDwso5a2W2K1Hwyxu16CwIG1Ux-0Do886W4UpwSyES0gq1Pwio9o8988UdUcobU2cw&__req=3a&__hs=19275.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=MODERATE&__rev=1006356399&__s=wyi1if%3Aolpie5%3Adohu95&__hsi=7152780219792120615&__comet_req=0&fb_dtsg=",
						(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T1)"&jazoest=25522&lsd=GOosELy7K5O1Cv1_2LF5Iz&__aaid=",
						Act,
						(T1)"&__spin_r=1006356399&__spin_b=trunk&__spin_t=1665386422&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22billing_address%22%3A%7B%22country_code%22%3A%22",
						CountryCode,
						(T1)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A21%2C%22logging_id%22%3A%223740071703%22%7D%2C%22cardholder_name%22%3A%22",
						ChromeControl.getFirstName<T0, T1, T2>(),
						(T1)"%20",
						ChromeControl.getLastName<T0, T1, T2>(),
						(T1)"%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
						(T1)Card.Card_Number.Substring(0, 6),
						(T1)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
						(T1)Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4),
						(T1)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
						(T1)Card.Card_Number,
						(T1)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
						(T1)Card.Card_Security,
						(T1)"%22%7D%2C%22expiry_month%22%3A%22",
						(T1)Card.Exp_Month,
						(T1)"%22%2C%22expiry_year%22%3A%22",
						(T1)Card.Exp_Year,
						(T1)"%22%2C%22payment_account_id%22%3A%22",
						Act,
						(T1)"%22%2C%22payment_type%22%3A%22MOR_ADS_INVOICE%22%2C%22unified_payments_api%22%3Atrue%2C%22actor_id%22%3A%22",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"%22%2C%22client_mutation_id%22%3A%225%22%7D%7D&server_timestamps=true&doc_id=4987045951343337"
					});
					if (Chrome != null)
					{
						httpRequest.KeepAlive = true;
						httpRequest.AddHeader("viewport-width", "1229");
						httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
						httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
						httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
						httpRequest.UserAgent = strUserAgentDesktop;
						httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
						httpRequest.AddHeader("Sec-Fetch-Site", "none");
						httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
						httpRequest.AddHeader("Sec-Fetch-User", "?1");
						httpRequest.AddHeader("Sec-Fetch-Dest", "document");
					}
					val22 = (T1)((object)httpRequest.Post("https://business.secure" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ajax/payment/token_proxy.php?tpe=/api/graphql/", string.Concat((string[])(object)new T1[1] { val24 }), "application/x-www-form-urlencoded")).ToString();
					val22 = (T1)Regex.Unescape((string)val22);
					T0 val25 = (T0)((string)val22).Contains("description");
					if (val25 != null)
					{
						T1 value5 = (T1)Regex.Match((string)val22, "description\":\"(.*?)\"").Groups[1].Value;
						value5 = (T1)Regex.Unescape((string)value5);
						T0 val26 = (T0)((string)val22).Contains("api_error_code");
						if (val26 != null)
						{
							value5 = (T1)(Regex.Match((string)val22, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value5);
						}
						frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value5);
					}
					httpRequest.UserAgent = Http.FirefoxUserAgent();
					T0 val27 = (T0)((string)val22).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
					if (val27 != null)
					{
						result = (T0)1;
					}
				}
				else if (addAPI == null)
				{
					if (isMFacebook_2 == null)
					{
						if (isPro5 != null)
						{
							try
							{
								T1 val28 = (T1)"";
								T6 enumerator = (T6)((Dictionary<string, string>)(object)httpRequest.Cookies).GetEnumerator();
								try
								{
									while (((Dictionary<string, string>.Enumerator*)(&enumerator))->MoveNext())
									{
										T7 current = (T7)((Dictionary<string, string>.Enumerator*)(&enumerator))->Current;
										val28 = (T1)string.Concat((string[])(object)new T1[5]
										{
											val28,
											(T1)((KeyValuePair<string, string>*)(&current))->Key,
											(T1)"=",
											(T1)((KeyValuePair<string, string>*)(&current))->Value,
											(T1)";"
										});
									}
								}
								finally
								{
									((IDisposable)(*(Dictionary<string, string>.Enumerator*)(&enumerator))).Dispose();
								}
								T1 val29 = (T1)("; i_user=" + (string)pro5Id + ";");
								val28 = (T1)((string)val28 + (string)val29);
								T5 val30 = (T5)Activator.CreateInstance(typeof(HttpRequest));
								((HttpRequest)val30).SslProtocols = SslProtocols.Tls12;
								ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
								((HttpRequest)val30).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36";
								((HttpRequest)val30).KeepAlive = true;
								((HttpRequest)val30).AllowAutoRedirect = true;
								((HttpRequest)val30).Cookies = new CookieDictionary(false);
								((HttpRequest)val30).AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
								((HttpRequest)val30).AddHeader("Accept-Language", "en-VN,en;q=0.9");
								T1 val31 = val28;
								val31 = (T1)((string)val31).Replace(" ", "");
								T0 val32 = (T0)(!((string)val31).Contains("wd="));
								if (val32 != null)
								{
									val31 = (T1)((string)val31 + ";wd=584x667");
								}
								val31 = (T1)((string)val31).Replace(";;", ";");
								T1[] array = (T1[])(object)((string)val31).Split((char[])(object)new T4[1] { (T4)59 });
								T2 val33 = (T2)0;
								while (true)
								{
									T0 val34 = (T0)((nint)val33 < array.Length);
									if (val34 == null)
									{
										break;
									}
									T0 val35 = (T0)(!((string)((object[])(object)array)[(object)val33]).Contains("useragent="));
									if (val35 != null)
									{
										T0 val36 = (T0)((string)((object[])(object)array)[(object)val33] == "wd=");
										if (val36 != null)
										{
											((object[])(object)array)[(object)val33] = ((string)((object[])(object)array)[(object)val33]).Replace("wd=", "wd=584x667");
										}
										T1[] array2 = (T1[])(object)((string)((object[])(object)array)[(object)val33]).Split((char[])(object)new T4[1] { (T4)61 });
										T0 val37 = (T0)(array2.Length > 1);
										if (val37 == null)
										{
											((Dictionary<string, string>)(object)((HttpRequest)val30).Cookies).Add((string)((object[])(object)array2)[0], " ");
										}
										else
										{
											((Dictionary<string, string>)(object)((HttpRequest)val30).Cookies).Add((string)((object[])(object)array2)[0], (string)((object[])(object)array2)[1]);
										}
									}
									val33 = (T2)(val33 + 1);
								}
								T1 val38 = (T1)((object)((HttpRequest)val30).Get("https://www.facebook.com/", (RequestParams)null)).ToString();
								T2 val39 = (T2)((string)val38).IndexOf("\"token\"");
								val38 = (T1)((string)val38).Remove(0, (int)val39);
								T1[] array3 = (T1[])(object)((string)val38).Split((char[])(object)new T4[1] { (T4)34 });
								T1 fb_dtsg = (T1)((object[])(object)array3)[3];
								_ = frmMain.listFBEntity[indexEntity].fb_dtsg;
								T1 result2 = (T1)"";
								addByPro5<T0, T1, T3, T5>(val30, pro5Id, fb_dtsg, CountryCode, Bin_mồi, Card, Act, out *(string*)(&result2));
								T0 val40 = (T0)((string)result2).Contains("description");
								if (val40 != null)
								{
									T1 value6 = (T1)Regex.Match((string)result2, "description\":\"(.*?)\"").Groups[1].Value;
									value6 = (T1)Regex.Unescape((string)value6);
									T0 val41 = (T0)((string)result2).Contains("api_error_code");
									if (val41 != null)
									{
										value6 = (T1)(Regex.Match((string)result2, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value6);
									}
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value6);
								}
								T0 val42 = (T0)((string)result2).Contains("description");
								if (val42 != null)
								{
									T1 value7 = (T1)Regex.Match((string)result2, "description\":\"(.*?)\"").Groups[1].Value;
									value7 = (T1)Regex.Unescape((string)value7);
									T0 val43 = (T0)((string)result2).Contains("api_error_code");
									if (val43 != null)
									{
										value7 = (T1)(Regex.Match((string)result2, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value7);
									}
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value7);
								}
								T0 val44 = (T0)((string)result2).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
								if (val44 != null)
								{
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", (T1)"");
									result = (T0)1;
								}
							}
							catch (Exception ex2)
							{
								Console.WriteLine(ex2.Message);
							}
						}
						else if (Add_link_1 != null)
						{
							T0 val45 = (T0)Card.Exp_Month.ToString().Contains("0");
							if (val45 != null)
							{
								Card.Exp_Month = Card.Exp_Month.Replace("0", "");
							}
							T0 val46 = (T0)(Card.Exp_Year.Length == 2);
							if (val46 != null)
							{
								Card.Exp_Year = "20" + Card.Exp_Year;
							}
							try
							{
								Licensing.Key = (string)getTrialkey_Rebex<T0, T5, T1>();
								Console.WriteLine(Licensing.Key);
								T8 val47 = (T8)Activator.CreateInstance(typeof(WebClient));
								((SslSettings)((WebClient)val47).Settings).SslAllowedVersions = (TlsVersion)16;
								T9 val48 = (T9)Activator.CreateInstance(typeof(NameValueCollection));
								((WebClient)val47).Headers.Add("Cookie", ((object)httpRequest.Cookies).ToString());
								T0 val49 = (T0)(httpRequest.Proxy != null && !string.IsNullOrWhiteSpace(httpRequest.Proxy.Host));
								if (val49 != null)
								{
									((WebClient)val47).Proxy.Host = httpRequest.Proxy.Host;
									((WebClient)val47).Proxy.Port = httpRequest.Proxy.Port;
									T0 val50 = (T0)(!string.IsNullOrWhiteSpace(httpRequest.Proxy.Username));
									if (val50 != null)
									{
										((WebClient)val47).Proxy.UserName = httpRequest.Proxy.Username;
									}
									T0 val51 = (T0)(!string.IsNullOrWhiteSpace(httpRequest.Proxy.Password));
									if (val51 != null)
									{
										((WebClient)val47).Proxy.Password = httpRequest.Proxy.Password;
									}
								}
								((NameValueCollection)val48)["variables"] = string.Concat((string[])(object)new T1[19]
								{
									(T1)"{\"input\":{\"client_mutation_id\":\"9\",\"billing_address\":{\"country_code\":\"",
									(T1)((string)CountryCode).ToUpper(),
									(T1)"\"},\"cardholder_name\":\"",
									(T1)((string)ChromeControl.getFirstName<T0, T1, T2>() + " " + (string)ChromeControl.getLastName<T0, T1, T2>()),
									(T1)"\",\"credit_card_first_6\":{\"sensitive_string_value\":\"",
									(T1)Card.Card_Number.Substring(0, 6),
									(T1)"\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"",
									(T1)Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4),
									(T1)"\"},\"credit_card_number\":{\"sensitive_string_value\":\"",
									(T1)Card.Card_Number,
									(T1)"\"},\"csc\":{\"sensitive_string_value\":\"",
									(T1)Card.Card_Security,
									(T1)"\"},\"expiry_month\":\"",
									(T1)Card.Exp_Month,
									(T1)"\",\"expiry_year\":\"",
									(T1)Card.Exp_Year,
									(T1)"\",\"payment_account_id\":\"",
									Act,
									(T1)"\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true}}"
								});
								((NameValueCollection)val48)["doc_id"] = "4987045951343337";
								T1 value8 = (T1)frmMain.listFBEntity[indexEntity].TokenEAAG;
								T0 val52 = (T0)string.IsNullOrWhiteSpace((string)value8);
								if (val52 != null)
								{
									value8 = (T1)frmMain.listFBEntity[indexEntity].TokenEAAB;
								}
								((NameValueCollection)val48)["access_token"] = (string)value8;
								T10[] bytes = (T10[])(object)((WebClient)val47).UploadValues("https://graph.secure.facebook.com/ajax/payment/token_proxy.php?tpe=%2Fgraphql%2F", (NameValueCollection)val48);
								T1 @string = (T1)Encoding.ASCII.GetString((byte[])(object)bytes);
								T0 val53 = (T0)((string)@string).Contains("description");
								if (val53 != null)
								{
									T1 value9 = (T1)Regex.Match((string)@string, "description\":\"(.*?)\"").Groups[1].Value;
									value9 = (T1)Regex.Unescape((string)value9);
									T0 val54 = (T0)((string)@string).Contains("api_error_code");
									if (val54 != null)
									{
										value9 = (T1)(Regex.Match((string)@string, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value9);
									}
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value9);
								}
								T0 val55 = (T0)((string)@string).Contains("description");
								if (val55 != null)
								{
									T1 value10 = (T1)Regex.Match((string)@string, "description\":\"(.*?)\"").Groups[1].Value;
									value10 = (T1)Regex.Unescape((string)value10);
									T0 val56 = (T0)((string)@string).Contains("api_error_code");
									if (val56 != null)
									{
										value10 = (T1)(Regex.Match((string)@string, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value10);
									}
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value10);
								}
								T0 val57 = (T0)((string)@string).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
								if (val57 != null)
								{
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", (T1)"");
									result = (T0)1;
								}
							}
							catch
							{
							}
						}
						else if (Add_link_2 != null)
						{
							try
							{
								T0 val58 = (T0)Card.Exp_Month.ToString().Contains("0");
								if (val58 != null)
								{
									Card.Exp_Month = Card.Exp_Month.Replace("0", "");
								}
								T0 val59 = (T0)(Card.Exp_Year.Length == 2);
								if (val59 != null)
								{
									Card.Exp_Year = "20" + Card.Exp_Year;
								}
								Licensing.Key = (string)getTrialkey_Rebex<T0, T5, T1>();
								Console.WriteLine(Licensing.Key);
								T8 val60 = (T8)Activator.CreateInstance(typeof(WebClient));
								((SslSettings)((WebClient)val60).Settings).SslAllowedVersions = (TlsVersion)16;
								((WebClient)val60).Timeout = 180000;
								T9 val61 = (T9)Activator.CreateInstance(typeof(NameValueCollection));
								((WebClient)val60).Headers.Add("cookie", ((object)httpRequest.Cookies).ToString());
								T0 val62 = (T0)(httpRequest.Proxy != null && !string.IsNullOrWhiteSpace(httpRequest.Proxy.Host));
								if (val62 != null)
								{
									((WebClient)val60).Proxy.Host = httpRequest.Proxy.Host;
									((WebClient)val60).Proxy.Port = httpRequest.Proxy.Port;
									T0 val63 = (T0)(!string.IsNullOrWhiteSpace(httpRequest.Proxy.Username));
									if (val63 != null)
									{
										((WebClient)val60).Proxy.UserName = httpRequest.Proxy.Username;
									}
									T0 val64 = (T0)(!string.IsNullOrWhiteSpace(httpRequest.Proxy.Password));
									if (val64 != null)
									{
										((WebClient)val60).Proxy.Password = httpRequest.Proxy.Password;
									}
								}
								T1 value11 = (T1)frmMain.listFBEntity[indexEntity].TokenEAAG;
								T0 val65 = (T0)string.IsNullOrWhiteSpace((string)value11);
								if (val65 != null)
								{
									value11 = (T1)frmMain.listFBEntity[indexEntity].TokenEAAB;
								}
								((NameValueCollection)val61)["access_token"] = (string)value11;
								((NameValueCollection)val61)["auth_mode"] = "auth";
								((NameValueCollection)val61)["creditCardNumber"] = Card.Card_Number;
								((NameValueCollection)val61)["csc"] = Card.Card_Security;
								((NameValueCollection)val61)["expiry_month"] = Card.Exp_Month;
								((NameValueCollection)val61)["expiry_year"] = Card.Exp_Year;
								T1 value12 = (T1)((string)ChromeControl.getFirstName<T0, T1, T2>() + " " + (string)ChromeControl.getLastName<T0, T1, T2>());
								((NameValueCollection)val61)["card_holder_name"] = (string)value12;
								((NameValueCollection)val61)["billing_address"] = string.Concat((string[])(object)new T1[5]
								{
									(T1)"{\"zip\":\"",
									(T1)((Card.ZipCode == null) ? "100000" : Card.ZipCode),
									(T1)"\",\"country_code\":\"",
									CountryCode,
									(T1)"\"}"
								});
								((NameValueCollection)val61)["locale"] = "vi_VN";
								((NameValueCollection)val61)["payment_type"] = "ads_invoice";
								T10[] bytes2 = (T10[])(object)((WebClient)val60).UploadValues("https://graph.secure.facebook.com/ajax/payment/token_proxy.php?tpe=%2Fv5.0%2Fact_" + (string)Act + "%2Fcredit_cards", (NameValueCollection)val61);
								T1 string2 = (T1)Encoding.ASCII.GetString((byte[])(object)bytes2);
								T0 val66 = (T0)((string)string2).Contains("description");
								if (val66 != null)
								{
									T1 value13 = (T1)Regex.Match((string)string2, "description\":\"(.*?)\"").Groups[1].Value;
									value13 = (T1)Regex.Unescape((string)value13);
									T0 val67 = (T0)((string)string2).Contains("api_error_code");
									if (val67 != null)
									{
										value13 = (T1)(Regex.Match((string)string2, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value13);
									}
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value13);
								}
								T0 val68 = (T0)((string)string2).Contains("description");
								if (val68 != null)
								{
									T1 value14 = (T1)Regex.Match((string)string2, "description\":\"(.*?)\"").Groups[1].Value;
									value14 = (T1)Regex.Unescape((string)value14);
									T0 val69 = (T0)((string)string2).Contains("api_error_code");
									if (val69 != null)
									{
										value14 = (T1)(Regex.Match((string)string2, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value14);
									}
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value14);
								}
								T0 val70 = (T0)((string)string2).Contains("card_type");
								if (val70 != null)
								{
									frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", (T1)"");
									result = (T0)1;
								}
							}
							catch (Exception ex3)
							{
								Console.WriteLine(ex3.Message);
							}
						}
					}
					else
					{
						T1 tokenEAAG = (T1)frmMain.listFBEntity[indexEntity].TokenEAAG;
						T0 val71 = (T0)string.IsNullOrWhiteSpace((string)tokenEAAG);
						if (val71 != null)
						{
							tokenEAAG = (T1)frmMain.listFBEntity[indexEntity].TokenEAAB;
						}
						T0 val72 = (T0)((nint)((IEnumerable<T4>)(object)Card.Exp_Month).First() == 48);
						if (val72 != null)
						{
							Card.Exp_Month = System.Runtime.CompilerServices.Unsafe.As<T4, char>(ref ((IEnumerable<T4>)(object)Card.Exp_Month).Last()).ToString();
						}
						T1 val73 = (T1)string.Concat((string[])(object)new T1[20]
						{
							(T1)"fb_dtsg=",
							(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T1)"&jazoest=25832&nextURI=https%3A%2F%2Fm.facebook.com%2Fads%2Fmanage%2Fbilling%2F%3Faccount_id%3D",
							Act,
							(T1)"%26cc_success%26source_support_form_id%3D0%26eav%3DAfY2Hqt7gVq2fEZYuY6zbMCC8MQBDA-t24UhKvWnt2d1jAkK2S9Bp9vUoinpjVbDPAU%26paipv%3D0%26ext%3D1680590201%26hash%3DAeSMc-K6qrMZ0EbnKvw&failURI=https%3A%2F%2Fm.facebook.com%2Fads%2Fmanage%2Ffunding%2Fcreditcard%2Fadd%2F%3Faccount_id%3D",
							Act,
							(T1)"%26cc_failure%26source_support_form_id%3D0&adAccountID=",
							Act,
							(T1)"&firstName=",
							(T1)((string)ChromeControl.getFirstName<T0, T1, T2>()).ToLower(),
							(T1)"&lastName=",
							(T1)((string)ChromeControl.getLastName<T0, T1, T2>()).ToLower(),
							(T1)"&app_id=337193689767846&flow_context_id=536310872018818&placement=mobile_ads_manager&creditCardNumber=",
							(T1)Card.Card_Number,
							(T1)"&expMonth=",
							(T1)Card.Exp_Month,
							(T1)"&expYear=",
							(T1)Card.Exp_Year,
							(T1)"&csc=",
							(T1)Card.Card_Security
						});
						T1 val74 = (T1)((object)httpRequest.Post("https://secure.facebook.com/ajax/payment/token_proxy.php?tpe=%2Fpayments%2Fads_add_credit_card%2F", (string)val73, "application/x-www-form-urlencoded")).ToString();
						val74 = (T1)httpRequest.Address.AbsoluteUri;
						Console.WriteLine((string)val74);
						T0 val75 = (T0)((string)val74).Contains("cc_success");
						if (val75 != null)
						{
							result = (T0)1;
						}
					}
				}
				else
				{
					httpRequest.SslProtocols = SslProtocols.Tls12;
					if (Chrome != null)
					{
						httpRequest.KeepAlive = true;
						httpRequest.AddHeader("viewport-width", "1229");
						httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
						httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
						httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
						httpRequest.UserAgent = strUserAgentDesktop;
						httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
						httpRequest.AddHeader("Sec-Fetch-Site", "none");
						httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
						httpRequest.AddHeader("Sec-Fetch-User", "?1");
						httpRequest.AddHeader("Sec-Fetch-Dest", "document");
					}
					httpRequest.Referer = "graph.secure.facebook.com";
					httpRequest.Accept = "gzip, deflate";
					httpRequest.ContentType = "application/x-www-form-urlencoded";
					T1 val76 = (T1)frmMain.listFBEntity[indexEntity].TokenEAAG;
					T0 val77 = (T0)string.IsNullOrWhiteSpace((string)val76);
					if (val77 != null)
					{
						val76 = (T1)frmMain.listFBEntity[indexEntity].TokenEAAB;
					}
					T0 val78 = (T0)((nint)((IEnumerable<T4>)(object)Card.Exp_Month).First() == 48);
					if (val78 != null)
					{
						Card.Exp_Month = System.Runtime.CompilerServices.Unsafe.As<T4, char>(ref ((IEnumerable<T4>)(object)Card.Exp_Month).Last()).ToString();
					}
					T1 val79 = (T1)string.Concat((string[])(object)new T1[15]
					{
						(T1)"access_token=",
						val76,
						(T1)"&auth_mode=auth&card_holder_name=",
						ChromeControl.getFirstName<T0, T1, T2>(),
						(T1)" ",
						ChromeControl.getLastName<T0, T1, T2>(),
						(T1)"&creditCardNumber=",
						(T1)Card.Card_Number,
						(T1)"&expiry_month=",
						(T1)Card.Exp_Month,
						(T1)"&expiry_year=",
						(T1)Card.Exp_Year,
						(T1)"&csc=",
						(T1)Card.Card_Security,
						(T1)"&payment_type=ads_invoice"
					});
					T2 val80 = (T2)0;
					while (true)
					{
						T1 str = (T1)((object)httpRequest.Post("https://graph.secure.facebook.com/ajax/payment/token_proxy.php?tpe=%2Fv5.0%2Fact_" + (string)Act + "%2Fcredit_cards", (string)val79, "application/x-www-form-urlencoded")).ToString();
						str = (T1)Regex.Unescape((string)str);
						Console.WriteLine((string)str);
						httpRequest.UserAgent = Http.FirefoxUserAgent();
						T0 val81 = (T0)((string)str).Contains("card_type");
						if (val81 == null)
						{
							val80 = (T2)(val80 + 1);
							T0 val82 = (T0)((nint)val80 >= 5);
							if (val82 != null)
							{
								result = (T0)0;
								break;
							}
							continue;
						}
						result = (T0)1;
						break;
					}
				}
			}
			else
			{
				httpRequest.SslProtocols = SslProtocols.Tls12;
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ad_center/create/consolidatedad?entry_point=www_profile_plus_promote_as_primary_action&page_id=102459842633456";
				T1 val83 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpttocvqxs%3APrjjptj10ykstt%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7AzHxqU5a9zk1ryaxG4VuC0BVU98nwgUb84ibyQdwSAx-bwNwnof8boG4E767Qcyo5S3y4o1DU2_CxS2adw65xO2OU7m2210wEwgolzUO0n2US2G5Usw9m1cwLwBgK7o884y0Mo4G4Ufo5m1mzXxG1Pxi4UaEW2au1jxS6FobrwKxm5oe8cE8K5pUfE9824Bx_y88E3mK7FobpEbUGdwb6223908O322m22ifxe3u362-2B0oo&__csr=gX1rR7RfbtTrf94hW5R5nNDvkQLf-QIIjOHqZJslnRXmleIJFkjaiFttaq8ihWAiDKQKiWCjALVft-rHBCrB9BjgmJ5KahuIPGScyk9giKimqjKUGFXAThuiEPDF7QmGnSOly-qBjAxm8zWKqiFFUCmQ4EWEx5g-mqVt6QUsmibmeiKF9oCcyVryFV6AWtGumUJoF4yAfABGGxSXyoOqax2ucK9x-9UgHLwVxl4yUmzEZ38yi4UlzXxym48borzo9Uoz88kfUlwCgC2GUfoy9h8cEhG9Cgy4oWcxC7UjwWK2659U4HxG12xmi2C0AEmU30w9Ou05i40hC04wE04ga01cxw0hEo18U0AW05aE0C20M81fk04Wo0DNw1kq045S041U3iwmpqa267EizcE0qHEU0Vu1Tw1a-0jC2KoM1m413wpo1y82lwDG0kAR1m3R0g8Fsk&__req=2o&__hs=19275.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=3ly3r9%3Ar4zy43%3Azdayih&__hsi=7152921784755429408&__comet_req=15&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25430&lsd=vFAOEDdziQ9KS1ziLwVDub&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419383&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingQEQuery&variables=%7B%22hasPaymentAccount%22%3Atrue%2C%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%2C%22universes%22%3A%5B%7B%22params%22%3A%5B%22show_billing_wizard_test%22%2C%22show_both_buttons%22%2C%22show_both_test%22%2C%22show_button_billing_wizard%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22ads_payments_billing_hub_contact_support%22%7D%2C%7B%22params%22%3A%5B%22auto_reload_supported%22%2C%22prepay_supported%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22auto_reload_testing_v1%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2021h2_ad_account_id%22%2C%22params%22%3A%5B%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22billing_h2_2021%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2022h1_ad_account_id%22%2C%22params%22%3A%5B%22all_unblock_options%22%2C%22backup_option_only%22%2C%22backup_pm_payment_settings_options%22%2C%22make_primary_checked%22%2C%22make_primary_checked_v2%22%2C%22make_primary_unchecked%22%2C%22make_primary_unchecked_v2%22%2C%22show_make_primary_checkbox%22%2C%22show_make_primary_checkbox_v2%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22billing_solutions_to_unblock_universe%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2021h2_ad_account_id%22%2C%22params%22%3A%5B%22is_eos_with_30_days%22%2C%22is_eos_with_30_days_v2%22%2C%22is_eos_with_anniversary%22%2C%22is_eos_with_anniversary_v2%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22end_of_spend_universe%22%7D%2C%7B%22params%22%3A%5B%22bv_enabled%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22flex_billing_h1_2021%22%7D%2C%7B%22params%22%3A%5B%22show_preauth_after_add_cc%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22pre_auth_experiment_bi%22%7D%2C%7B%22params%22%3A%5B%22show_support%22%5D%2C%22universe_name%22%3A%22risk_ops_contact_support%22%7D%2C%7B%22params%22%3A%5B%22show_restricted_addfunds%22%5D%2C%22universe_name%22%3A%22sdc_verification_on_add_funds%22%7D%2C%7B%22params%22%3A%5B%22show_restricted_paynow%22%5D%2C%22universe_name%22%3A%22sdc_verification_on_pay_now%22%7D%2C%7B%22params%22%3A%5B%22enable_nux%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22standard_billing_2021_h2%22%7D%5D%7D&server_timestamps=true&doc_id=5787537841277053"
				}) }), "application/x-www-form-urlencoded")).ToString();
				val83 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpttocvqxs%3APrjjptj10ykstt%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7AzHxqU5a9zk1ryaxG4VuC0BVU98nwgUb84ibyQdwSAx-bwNwnof8boG4E767Qcyo5S3y4o1DU2_CxS2adw65xO2OU7m2210wEwgolzUO0n2US2G5UswoEcE4O2-2l2Utwwwi831wiEjwZxK3C1mzXxG1Pxi4UaEW2au1jxS6FobrwKxm5oe8cE8K5pUfFEtw8im7-8wywrU6qUuBwJCwLyES0Io88cA1Pxy322m22ifxe3u362-2B0oo&__csr=gX1rR7RfbtTrf94hW5R5nNDvkQLf-QIIjOHqZJslnRXmleIJFkjaiFttaq8ihWAiDKQKiWCjALVft-rHBCrB9BjgmJ5KahuIPGScyk9giKimqjKUGFXAThuiEPDF7QmGnSOly-qBjAxm8zWKqiFFUCmQ4EWEx5g-mqVt6QUsmibmeiKF9oCcyVryFV6AWtGumUJoF4yAfABGGxSXyoOqax2ucK9x-9UgHLwVxl4yUmzEZ38yi4UlzXxym48borzo9Uoz88kfUlwCgC8xx7K3S8yki2WA4qypA8x6ez8px-4U-2GU8okDwiK6E4a5p8ao2ixrwc20D9U0l8g16o0i2w0h0E04O6016xw4zw2jE0kGw2o830w4Zg0jFw2v605hE0gno0g7wda1pBEE8ouxacOw1GKzw3BU7u04HU1eoaVz05og4e1Bw68w9m2uE1ijk5ofk10yBNg&__req=2q&__hs=19275.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=3ly3r9%3Ar4zy43%3Azdayih&__hsi=7152921784755429408&__comet_req=15&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25430&lsd=vFAOEDdziQ9KS1ziLwVDub&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419383&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAddPaymentMethodInitStateStateQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5022661927861573"
				}) }), "application/x-www-form-urlencoded")).ToString();
				val83 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpttocvqxs%3APrjjptj10ykstt%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7AzHxqU5a9zk1ryaxG4VuC0BVU98nwgUb84ibyQdwSAx-bwNwnof8boG4E767Qcyo5S3y4o1DU2_CxS2adw65xO2OU7m2210wEwgolzUO0n2US2G5UswoEcE4O2-2l2Utwwwi831wiEjwZxK3C1mzXxG1Pxi4UaEW2au1jxS6FobrwKxm5oe8cE8K5pUfFEtw8im7-8wywrU6qUuBwJCwLyES0Io88cA1Pxy322m22ifxe3u362-2B0oo&__csr=gX1rR7RfbtTrf94hW5R5nNDvkQLf-QIIjOHqZJslnRXmleIJFkjaiFttaq8ihWAiDKQKiWCjALVft-rHBCrB9BjgmJ5KahuIPGScyk9giKimqjKUGFXAThuiEPDF7QmGnSOly-qBjAxm8zWKqiFFUCmQ4EWEx5g-mqVt6QUsmibmeiKF9oCcyVryFV6AWtGumUJoF4yAfABGGxSXyoOqax2ucK9x-9UgHLwVxl4yUmzEZ38yi4UlzXxym48borzo9Uoz88kfUlwCgC8xx7K3S8yki2WA4qypA8x6ez8px-4U-2GU8okDwiK6E4a5p8ao2ixrwc20D9U0l8g16o0i2w0h0E04O6016xw4zw2jE0kGw2o830w4Zg0jFw2v605hE0gno0g7wda1pBEE8ouxacOw1GKzw3BU7u04HU1eoaVz05og4e1Bw68w9m2uE1ijk5ofk10yBNg&__req=2r&__hs=19275.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=3ly3r9%3Ar4zy43%3Azdayih&__hsi=7152921784755429408&__comet_req=15&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25430&lsd=vFAOEDdziQ9KS1ziLwVDub&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419383&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardLandingScreenQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5987803917897133"
				}) }), "application/x-www-form-urlencoded")).ToString();
				val83 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[11]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjjpttocvqxs%3APrjjptj10ykstt%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7AzHxqU5a9zk1ryaxG4VuC0BVU98nwgUb84ibyQdwSAx-bwNwnof8boG4E767Qcyo5S3y4o1DU2_CxS2adw65xO2OU7m2210wEwgolzUO0n2US2G5UswoEcE4O2-2l2Utwwwi831wiEjwZxK3C1mzXxG1Pxi4UaEW2au1jxS6FobrwKxm5oe8cE8K5pUfFEtw8im7-8wywrU6qUuBwJCwLyES0Io88cA1Pxy322m22ifxe3u362-2B0oo&__csr=gX1rR7RfbtTrf94hW5R5nNDvkQLf-QIIjOHqZJslnRXmleIJFkjaiFttaq8ihWAiDKQKiWCjALVft-rHBCrB9BjgmJ5KahuIPGScyk9giKimqjKUGFXAThuiEPDF7QmGnSOly-qBjAxm8zWKqiFFUCmQ4EWEx5g-mqVt6QUsmibmeiKF9oCcyVryFV6AWtGumUJoF4yAfABGGxSXyoOqax2ucK9x-9UgHLwVxl4yUmzEZ38yi4UlzXxym48borzo9Uoz88kfUlwCgC8xx7K3S8yki2WA4qypA8x6eyK6ovxefwGK2659U4HxG12xmi2C0AEmU30w9Ou05i40hC04wE04ga01cxw0hEo18U0AW05aE0C20M81fk04Wo0DNw1kq045S041U3iwmpqa267EizcE0qHEU0Vu1Tw1a-0jC2KoM1m413wpo1y82lwDG0kAR1m3R0g8Fsk&__req=2t&__hs=19275.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=3ly3r9%3Ar4zy43%3Azdayih&__hsi=7152921784755429408&__comet_req=15&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25430&lsd=vFAOEDdziQ9KS1ziLwVDub&__aaid=",
					Act,
					(T1)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665419383&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardProductContextQuery&variables=%7B%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=5670634143000359"
				}) }), "application/x-www-form-urlencoded")).ToString();
				T0 val84 = (T0)(Card.Exp_Year.Length == 2);
				if (val84 != null)
				{
					Card.Exp_Year = "20" + Card.Exp_Year;
				}
				T1 val85 = (T1)string.Concat((string[])(object)new T1[31]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&payment_dev_cycle=prod&__usid=6-Trjiuqp1p2gwtp%3APrjj00j1t01rhp%3A0-Arjizs51m1kvg8-RV%3D6%3AF%3D&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7AzHxqU5a9zk1ryaxG4VuC0BVU98nwgU8EC14yUJ3odF8vyUcouw-wYwJyEiwsovgO9wnoe8hw6vwb-q7o8ES0om78bbwto886C11xmfz81sbzoaEnxO1ywOwj8bU9kbxS2218wc61axe3S6Ueo5qfK6E7e58jwGzE8FU5e7oqBwJK2W5olwUwlu5pUfFE2yBx_wHwUwSwqEuBxe6pEbUGdwb61jg7e68c89o9o8UdUcobUak1xw&__req=33&__hs=19275.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=MODERATE&__rev=1006356399&__s=ah4rts%3Apj9iqj%3Ale7hvo&__hsi=7152778140120054876&__comet_req=15&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25584&lsd=Yine2D15DtJS2F8LiIs0HF&__aaid=",
					Act,
					(T1)"&__spin_r=1006356399&__spin_b=trunk&__spin_t=1665385938&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22billing_address%22%3A%7B%22country_code%22%3A%22",
					CountryCode,
					(T1)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A30%2C%22logging_id%22%3A%22919211315%22%7D%2C%22cardholder_name%22%3A%22",
					ChromeControl.getFirstName<T0, T1, T2>(),
					(T1)"%20",
					ChromeControl.getLastName<T0, T1, T2>(),
					(T1)"%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(0, 6),
					(T1)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4),
					(T1)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Number,
					(T1)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
					(T1)Card.Card_Security,
					(T1)"%22%7D%2C%22expiry_month%22%3A%22",
					(T1)Card.Exp_Month,
					(T1)"%22%2C%22expiry_year%22%3A%22",
					(T1)Card.Exp_Year,
					(T1)"%22%2C%22payment_account_id%22%3A%22",
					Act,
					(T1)"%22%2C%22payment_type%22%3A%22MOR_ADS_INVOICE%22%2C%22unified_payments_api%22%3Atrue%2C%22actor_id%22%3A%22",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"%22%2C%22client_mutation_id%22%3A%224%22%7D%7D&server_timestamps=true&doc_id=4987045951343337"
				});
				httpRequest.SslProtocols = SslProtocols.Tls12;
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/";
				httpRequest.AddHeader("accept", "*/*");
				httpRequest.AddHeader("accept-language", "en-US,en;q=0.9");
				httpRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
				httpRequest.AddHeader("sec-ch-ua", "\"Chromium\";v=\"106\", \"Google Chrome\";v=\"106\", \"Not;A=Brand\";v=\"99\"");
				httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
				httpRequest.AddHeader("sec-ch-ua-platform", "\"Windows\"");
				httpRequest.AddHeader("sec-fetch-dest", "empty");
				httpRequest.AddHeader("sec-fetch-mode", "cors");
				httpRequest.AddHeader("sec-fetch-site", "same-site");
				httpRequest.AddHeader("x-fb-friendly-name", "useBillingAddCreditCardMutation");
				if (Chrome != null)
				{
					httpRequest.KeepAlive = true;
					httpRequest.AddHeader("viewport-width", "1229");
					httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
					httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
					httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
					httpRequest.UserAgent = strUserAgentDesktop;
					httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
					httpRequest.AddHeader("Sec-Fetch-Site", "none");
					httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
					httpRequest.AddHeader("Sec-Fetch-User", "?1");
					httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				}
				val83 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_SECURE_PAYMENT") + "?tpe=/api/graphql/", string.Concat((string[])(object)new T1[1] { val85 }), "application/x-www-form-urlencoded")).ToString();
				val83 = (T1)Regex.Unescape((string)val83);
				T0 val86 = (T0)((string)val83).Contains("description");
				if (val86 != null)
				{
					T1 value15 = (T1)Regex.Match((string)val83, "description\":\"(.*?)\"").Groups[1].Value;
					value15 = (T1)Regex.Unescape((string)value15);
					T0 val87 = (T0)((string)val83).Contains("api_error_code");
					if (val87 != null)
					{
						value15 = (T1)(Regex.Match((string)val83, "api_error_code\":(.*?),").Groups[1].Value + ": " + (string)value15);
					}
					frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Note", value15);
				}
				httpRequest.UserAgent = Http.FirefoxUserAgent();
				T0 val88 = (T0)((string)val83).Contains(Card.Card_Number.Substring(Card.Card_Number.Length - 4, 4));
				if (val88 != null)
				{
					result = (T0)1;
				}
			}
			if (vhhTK != null)
			{
				activeAct<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, Act, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
			}
			if (checkLive != null)
			{
				T1 status = (T1)"";
				check_status_payment<T0, T1, List<billing_payment_methods>.Enumerator, T3, T2, Color>(Act, out *(string*)(&status));
			}
		}
		catch (Exception ex4)
		{
			Console.WriteLine(ex4.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T2 getTrialkey_Rebex<T0, T1, T2>()
	{
		//IL_000c: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(Trialkey_Rebex);
			if (val != null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(HttpRequest));
				((HttpRequest)val2).SslProtocols = SslProtocols.Tls12;
				T2 input = (T2)((object)((HttpRequest)val2).Get("https://www.rebex.net/support/trial/", (RequestParams)null)).ToString();
				T2 value = (T2)Regex.Match((string)input, "name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\"").Groups[1].Value;
				T0 val3 = (T0)(!((string)value != string.Empty));
				if (val3 != null)
				{
					return (T2)string.Empty;
				}
				input = (T2)((object)((HttpRequest)val2).Post("https://www.rebex.net/support/trial/", "__RequestVerificationToken=" + (string)value, "application/x-www-form-urlencoded")).ToString();
				value = (T2)Regex.Match((string)input, "\"readonly\" value=\"(.*?)\"").Groups[1].Value;
				T0 val4 = (T0)((string)value != string.Empty);
				if (val4 == null)
				{
					return (T2)string.Empty;
				}
				Trialkey_Rebex = ((string)value).Replace(" ", "");
				return (T2)Trialkey_Rebex;
			}
			return (T2)Trialkey_Rebex;
		}
		catch
		{
		}
		return (T2)string.Empty;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 check_status_payment<T0, T1, T2, T3, T4, T5>(T1 Act, out string status)
	{
		//IL_0009: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_02bf: Expected O, but got I4
		//IL_02fb: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		//IL_034b: Expected O, but got I4
		//IL_036d: Expected O, but got I4
		//IL_0395: Expected O, but got I4
		//IL_03ac: Expected O, but got I4
		//IL_03c5: Expected O, but got I4
		//IL_03ce: Expected O, but got I4
		//IL_05c5: Expected O, but got I4
		//IL_05de: Expected O, but got I4
		//IL_05e7: Expected O, but got I4
		//IL_0601: Expected O, but got I4
		//IL_060c: Expected O, but got I4
		//IL_0622: Expected O, but got I4
		status = "";
		T0 result = (T0)1;
		try
		{
			setMessage<T0, T1, T4>((T1)"Check trạng thái TK", (T0)0);
			T1 val = (T1)string.Concat((string[])(object)new T1[6]
			{
				(T1)"https://graph",
				(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T1)"/v16.0/act_",
				Act,
				(T1)"?fields=business_country_code,spend_cap,timezone_name,id,disable_reason,name,account_status,currency,adtrust_dsl,amount_spent,adspaymentcycle{threshold_amount},has_repay_processing_invoices,invoicing_emails,balance&access_token=",
				(T1)frmMain.listFBEntity[indexEntity].TokenEAAG
			});
			T1 val2 = (T1)((object)httpRequest.Get((string)val, (RequestParams)null)).ToString();
			adaccountsData adaccountsData = JsonConvert.DeserializeObject<adaccountsData>((string)val2);
			T0 val3 = (T0)(adaccountsData != null && adaccountsData.account_status != 1);
			if (val3 != null)
			{
				status = "TK " + (string)Utility.GetStatus<T4, T1>((T4)adaccountsData.account_status);
				result = (T0)0;
			}
			T0 val4 = (T0)string.IsNullOrWhiteSpace(status);
			if (val4 != null)
			{
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://www",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/ads/manager/account_settings/account_billing/?act=",
					Act,
					(T1)"&pid=p1&page=account_settings&tab=account_billing_settings"
				});
				val2 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[15]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo5O9U8EKnFG2Om2q12wAxiFGxK7oG48corxebzEdF98Sm4EuGfyU4W5orzobo-5EjwOwOw8i9y8G6Ehwt8aE4m1qwCwuE9FEdUmCBBwLghUbqQGxBa2du17K2m5U7y746k48a8lwWxe4oeUa85vzo4i1qw9G7o9bzouyUd85WUpwoVUao9k2C4oW2e2i11xOfwXxq1uxZxK48GU8EhAy88rwzzXwKwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFobE6ycwnohxabDyoOEdEGcgjgW0UFU6K19wiU8U6Ci2G1bzEG2q1pw&__csr=&__req=i&__hs=19392.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_r,
					(T1)"&__s=5kchdd%3A94p0zr%3A2pr9c2&__hsi=7196296338329782737&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25482&lsd=5n3AixGNZnYy5eQysNjNCC&__aaid=595121591920536&__spin_r=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_r,
					(T1)"&__spin_b=trunk&__spin_t=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_t,
					(T1)"&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingHubPaymentSettingsPaymentMethodsListQuery&variables=%7B%22hasSDCRiskRestriction%22%3Atrue%2C%22paymentAccountID%22%3A%22",
					Act,
					(T1)"%22%7D&server_timestamps=true&doc_id=6271422066224436"
				}) }), "application/x-www-form-urlencoded")).ToString();
				payment_account payment_account = JsonConvert.DeserializeObject<payment_account>((string)val2);
				T0 val5 = (T0)(payment_account != null && payment_account.data != null && payment_account.data.billable_account_by_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count > 0);
				if (val5 != null)
				{
					T2 enumerator = (T2)payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
					try
					{
						while (((List<billing_payment_methods>.Enumerator*)(&enumerator))->MoveNext())
						{
							billing_payment_methods current = ((List<billing_payment_methods>.Enumerator*)(&enumerator))->Current;
							T0 val6 = (T0)(current.credential != null);
							if (val6 != null)
							{
								T0 val7 = (T0)(current.usability.Equals("UNVERIFIED_OR_PENDING_AUTH") || current.usability.Equals("UNVERIFIABLE") || bool.Parse(current.credential.needs_verification));
								if (val7 != null)
								{
									status = "Thẻ XM";
									result = (T0)0;
								}
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<billing_payment_methods>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				T0 val8 = (T0)string.IsNullOrWhiteSpace(status);
				if (val8 != null)
				{
					T0 val9 = (T0)(payment_account != null && payment_account.data != null && payment_account.data.billable_account_by_payment_account != null);
					if (val9 != null)
					{
						T0 val10 = (T0)payment_account.data.billable_account_by_payment_account.is_reauth_restricted;
						if (val10 != null)
						{
							status = frmMain.STATUS.Không_đủ_tiền.ToString();
							result = (T0)0;
						}
					}
					T0 val11 = (T0)string.IsNullOrWhiteSpace(status);
					if (val11 != null)
					{
						httpRequest.Referer = string.Concat((string[])(object)new T1[5]
						{
							(T1)"https://www",
							(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
							(T1)"/ads/manager/account_settings/account_billing/?act=",
							Act,
							(T1)"&pid=p1&page=account_settings&tab=account_billing_settings"
						});
						val2 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[17]
						{
							(T1)"av=",
							(T1)frmMain.listFBEntity[indexEntity].UID,
							(T1)"&__user=",
							(T1)frmMain.listFBEntity[indexEntity].UID,
							(T1)"&__a=1&__dyn=7xeUmxa3-Q8zo5O9U8EKnFG2Om2q12wAxiFGxK7oG48corx-ewSAAzpoixWE-bwjElxKdwJzUmxe1Bw8W8yEqx61QwGwho5G2q1WwCCwTxqqmm2Z17wJHiG6kE8Ro4uU9onwu8sxF122y5oeEjx63K2y1nUS0DU2qwgHzouwg85W7o6eu2C2l0Fx6ewzwAwgoszUeUmwnEvorx2ewyx6i8wxK2efK2W1dwCxe68882sAw_zobEaUiwuU5Wu6E2cxiaBwai1tx64EKu9zawSyEN1d3E3yDwbm1bwzwqp8aE4KeyE9E5C0C8&__csr=&__req=5&__hs=19448.BP%3Aads_campaign_manager_pkg.2.0..0.0&dpr=1.5&__ccg=EXCELLENT&__rev=",
							(T1)frmMain.listFBEntity[indexEntity].__spin_r,
							(T1)"&__s=faot7h%3Aljq7f6%3Akarq3j&__hsi=7216926139393332725&__comet_req=0&fb_dtsg=",
							(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T1)"&jazoest=25381&lsd=SBDckWSISG74dJ3G2iYjHK&__aaid=",
							Act,
							(T1)"&__spin_r=",
							(T1)frmMain.listFBEntity[indexEntity].__spin_r,
							(T1)"&__spin_b=trunk&__spin_t=",
							(T1)frmMain.listFBEntity[indexEntity].__spin_t,
							(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingHubRootBillableAccountContextProviderQuery&variables=%7B%22assetID%22%3A%22",
							Act,
							(T1)"%22%7D&server_timestamps=true&doc_id=5877268549017357"
						}) }), "application/x-www-form-urlencoded")).ToString();
						CheckPayment checkPayment = JsonConvert.DeserializeObject<CheckPayment>((string)val2);
						T0 val12 = (T0)(checkPayment != null && checkPayment.data != null && checkPayment.data.billable_account_by_asset_id != null && !string.IsNullOrWhiteSpace(checkPayment.data.billable_account_by_asset_id.risk_restricted_state) && checkPayment.data.billable_account_by_asset_id.risk_restricted_state.Equals("ACTIONABLE_PREAUTH_STATE"));
						if (val12 != null)
						{
							status = frmMain.STATUS.Không_đủ_tiền.ToString();
							result = (T0)0;
						}
					}
				}
			}
			T0 val13 = (T0)string.IsNullOrWhiteSpace(status);
			if (val13 != null)
			{
				frmMain.SetCellColor<T0, T4, T5>((T4)indexEntity, (T5)Color.Blue);
			}
			else
			{
				setMessage<T0, T1, T4>((T1)status, (T0)1);
				frmMain.SetCellColor<T0, T4, T5>((T4)indexEntity, (T5)Color.Red);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 Set_Payment_BM_Cho_Act<T0, T1>(T1 Chrome, T0 Act, T0 BM_ID, T0 card_association, out string strError)
	{
		//IL_04dd: Expected O, but got I4
		//IL_0505: Expected O, but got I4
		//IL_050d: Expected O, but got I4
		strError = "";
		try
		{
			httpRequest.SslProtocols = SslProtocols.Tls12;
			httpRequest.Referer = string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://www",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/ads/manager/account_settings/account_billing/?act=",
				Act,
				(T0)"&pid=p1&page=account_settings&tab=account_billing_settings"
			});
			T0 val = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[11]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__usid=6-Trjjomj1dvkmjw%3APrjjomg1sxhqq0%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe484e4824yoyaxG4o7i2G15wxwUwCwuE9FEdUmCBBwLghUbqQGxBa2dum11K6UC5U7y78jCggwExm3G4UhwXwEwl-dwh85G0CEtwAKdxWbwQwnHxC1zVoao9k2B12ewzwAwgoszUeUmwnEvorx2awCx5e8wxK2efK6Ejwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFo2nz85S4oiyVUCcG3qazo8U3yDwqU4C1bwzwqp8aE4K6osyo&__csr=&__req=1i&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=67cama%3Awib606%3Awwohpl&__hsi=7152915123459913621&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=25421&lsd=Fl8BnI2PCPe6PSQV379NiT&__aaid=",
				Act,
				(T0)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665417832&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingWizardProductContextQuery&variables=%7B%22paymentAccountID%22%3A%22",
				Act,
				(T0)"%22%7D&server_timestamps=true&doc_id=5670634143000359"
			}) }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.SslProtocols = SslProtocols.Tls12;
			httpRequest.Referer = string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://www",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/ads/manager/account_settings/account_billing/?act=",
				Act,
				(T0)"&pid=p1&page=account_settings&tab=account_billing_settings"
			});
			val = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[11]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__usid=6-Trjjomj1dvkmjw%3APrjjomg1sxhqq0%3A0-Arjjomjwp4uo9-RV%3D6%3AF%3D&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=7xeUmxa3-Q8zo9EdoDwyyVuCEb9o9E4a2i5aCG6UtyEgwNxK4UKewSAAzpoixWE-bwjElxKdwJzUmxe484e4824yoyaxG4o7i2G15wxwUwCwuE9FEdUmCBBwLghUbqQGxBa2dum11K6UC5U7y78jCggwExm3G4UhwXwEwl-dwh85G0CEtwAKdxWbwQwnHxC1zVoao9k2B12ewzwAwgoszUeUmwnEvorx2awCx5e8wxK2efK6Ejwjo9Ejxy220D98fUS2W2K4E7K5U4qp1G0z8kyFo2nz85S4oiyVUCcG3qazo8U3yDwqU4C1bwzwqp8aE4K6osyo&__csr=&__req=1j&__hs=19275.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1006356756&__s=67cama%3Awib606%3Awwohpl&__hsi=7152915123459913621&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=25421&lsd=Fl8BnI2PCPe6PSQV379NiT&__aaid=",
				Act,
				(T0)"&__spin_r=1006356756&__spin_b=trunk&__spin_t=1665417832&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAddPaymentMethodInitStateStateQuery&variables=%7B%22paymentAccountID%22%3A%22",
				Act,
				(T0)"%22%7D&server_timestamps=true&doc_id=5022661927861573"
			}) }), "application/x-www-form-urlencoded")).ToString();
			T0 val2 = Lay_Payment_Id_Act<T0, T1, List<billing_payment_method_options>.Enumerator>(Act, BM_ID, card_association);
			T0 val3 = (T0)string.Concat((string[])(object)new T0[13]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__usid=&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=&__csr=&__req=10&__hs=19058.BP%3Aads_campaign_manager_pkg.2.0.0.0.&dpr=1&__ccg=MODERATE&__rev=1006356291&__s=&__hsi=&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&lsd=&__spin_r=1006356291&__spin_b=trunk&__spin_t=1665371703&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingMakePrimaryStateMutation&variables=%7B%22input%22%3A%7B%22billable_account_payment_legacy_account_id%22%3A%22",
				(T0)((string)Act).Replace("act_", ""),
				(T0)"%22%2C%22logging_data%22%3A%7B%22logging_counter%22%3A1%2C%22logging_id%22%3A%221%22%7D%2C%22primary_funding_id%22%3A%22",
				val2,
				(T0)"%22%2C%22actor_id%22%3A%22",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"%22%2C%22client_mutation_id%22%3A%221%22%7D%7D&server_timestamps=true&doc_id=5269766796431668"
			});
			httpRequest.SslProtocols = SslProtocols.Tls12;
			if (Chrome != null)
			{
				httpRequest.KeepAlive = true;
				httpRequest.AddHeader("viewport-width", "1229");
				httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
				httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
				httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
				httpRequest.UserAgent = strUserAgentDesktop;
				httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
				httpRequest.AddHeader("Sec-Fetch-Site", "none");
				httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
				httpRequest.AddHeader("Sec-Fetch-User", "?1");
				httpRequest.AddHeader("Sec-Fetch-Dest", "document");
			}
			httpRequest.Referer = string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://www",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/ads/manager/account_settings/account_billing/?act=",
				Act,
				(T0)"&pid=p1&page=account_settings&tab=account_billing_settings"
			});
			val = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { val3 }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.UserAgent = Http.FirefoxUserAgent();
			T1 val4 = (T1)((string)val).Contains("description");
			if (val4 == null)
			{
				return (T1)1;
			}
			strError = Regex.Match((string)val, "description\":\"(.*?)\"").Groups[1].Value;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe T0 Lay_Payment_Id_Act<T0, T1, T2>(T0 Act, T0 BM_ID, T0 card_association)
	{
		//IL_00e7: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		try
		{
			T0 val = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__usid=&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=&__csr=&__req=11&__hs=19058.BP%3Aads_campaign_manager_pkg.2.0.0.0.&dpr=1&__ccg=MODERATE&__rev=1006356291&__s=&__hsi=&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=&lsd=&__spin_r=1006356291&__spin_b=trunk&__spin_t=1665371703&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingBMPaymentMethodsScreenQuery&variables=%7B%22paymentAccountID%22%3A%22",
				(T0)((string)Act).Replace("act_", ""),
				(T0)"%22%7D&server_timestamps=true&doc_id=5118339514872333"
			});
			T0 val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { val }), "application/x-www-form-urlencoded")).ToString();
			T1 val3 = (T1)((string)val2).Contains("credential_id");
			if (val3 != null)
			{
				T0 result = (T0)Regex.Match((string)val2, "credential_id\":\"(.*?)\"").Groups[1].Value;
				T1 val4 = (T1)(!string.IsNullOrWhiteSpace((string)card_association));
				if (val4 != null)
				{
					payment_account payment_account = JsonConvert.DeserializeObject<payment_account>((string)val2);
					T1 val5 = (T1)(payment_account.data != null && payment_account.data.billable_account_by_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_method_options != null);
					if (val5 != null)
					{
						T2 enumerator = (T2)payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_method_options.GetEnumerator();
						try
						{
							while (((List<billing_payment_method_options>.Enumerator*)(&enumerator))->MoveNext())
							{
								billing_payment_method_options current = ((List<billing_payment_method_options>.Enumerator*)(&enumerator))->Current;
								T1 val6 = (T1)(current.business_cc_credential != null && current.business_cc_credential.card_association != null && current.business_cc_credential.card_association.ToLower().Contains(((string)card_association).ToLower()));
								if (val6 != null)
								{
									result = (T0)current.business_cc_credential.credential_id;
									break;
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<billing_payment_method_options>.Enumerator*)(&enumerator))).Dispose();
						}
					}
				}
				return result;
			}
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public adaccounts getFullAdsInfo_In_BM<T0, T1>(T0 strBMID)
	{
		//IL_00ab: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		adaccounts adaccounts = null;
		try
		{
			T0 val = (T0)string.Concat((string[])(object)new T0[7]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v14.0/",
				strBMID,
				(T0)"/owned_ad_accounts?access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG,
				(T0)"&_reqName=object:business/owned_ad_accounts&_reqSrc=BusinessConnectedOwnedAdAccountsStore.brands&date_format=U&fields=[\"id\",\"name\",\"account_id\",\"account_status\",\"business\",\"created_time\",\"currency\",\"timezone_name\",\"end_advertiser\",\"end_advertiser_name\",\"invoicing_emails\",\"is_disabled_umbrella\",\"last_spend_time\",\"funding_source\",\"can_be_blocked_from_pixel_sharing\",\"disable_reason\",\"bill_to_org.fields(legal_entity_name)\",\"onbehalf_requests.fields(receiving_business.fields(name),status)\"]&limit=25&locale=en_GB&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref=f94904476bd6cc"
			});
			T0 val2 = (T0)((object)httpRequest.Get((string)val, (RequestParams)null)).ToString();
			adaccounts = JsonConvert.DeserializeObject<adaccounts>((string)val2);
			while (true)
			{
				T1 val3 = (T1)frmMain.isRunning;
				if (val3 != null)
				{
					T1 val4 = (T1)(adaccounts != null && adaccounts.data != null && adaccounts.paging != null && !string.IsNullOrWhiteSpace(adaccounts.paging.next));
					if (val4 != null)
					{
						T0 val5 = fetch_url_business<T0, Exception>((T0)adaccounts.paging.next);
						adaccounts adaccounts2 = JsonConvert.DeserializeObject<adaccounts>((string)val5);
						T1 val6 = (T1)(adaccounts != null && adaccounts.data != null && adaccounts2 != null && adaccounts2.data != null);
						if (val6 != null)
						{
							adaccounts.data.AddRange(adaccounts2.data);
							adaccounts.paging = adaccounts2.paging;
						}
						continue;
					}
					break;
				}
				break;
			}
		}
		catch
		{
		}
		return adaccounts;
	}

	public T0 fetch_url_business<T0, T1>(T0 url)
	{
		try
		{
			return (T0)((object)httpRequest.Get((string)url, (RequestParams)null)).ToString();
		}
		catch (Exception ex)
		{
			return (T0)ex.Message;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 addCardToBM<T0, T1, T2>(T1 Chrome, out string strError, T0 BM_Id, T0 strPaymentAccountId, T0 strCountryCode, T0 strNameCart, T0 strCC, T0 strCVV, T0 strMonth, T0 strYear)
	{
		//IL_0012: Expected O, but got I4
		//IL_06ab: Expected O, but got I4
		//IL_06b1: Expected O, but got I4
		//IL_06e3: Expected O, but got I4
		strError = "";
		try
		{
			T1 val = (T1)(((string)strYear).Length == 2);
			if (val != null)
			{
				strYear = (T0)("20" + (string)strYear);
			}
			httpRequest.SslProtocols = SslProtocols.Tls12;
			httpRequest.Referer = string.Concat((string[])(object)new T0[8]
			{
				(T0)"https://business",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/settings/payment-methods/business_id=",
				BM_Id,
				(T0)"?business_id=",
				BM_Id,
				(T0)"&global_scope_id=",
				BM_Id
			});
			T0 val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[7]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=7xeUmxa2C5rgydwCwRyU8EKnFG2Om2q12xCagmCwRCwqojyUV0OGiidBxa7EiwhEmwKzobo8LwAwgUgwqoqyoyazoO4o461twOxa7Am4o8E9EmxGcwXxKawlrGbwQzoO2ng-3tpUdoK7UC5U7y78jxiUa8522m3K2y3WElUScyo723m1Lz84aVpUuyUd88EeAVUhK1vVoao9k2B12ewi8doa84K5E5WUrorx2awCx5e8wxK2efK6F8W1dx-q4VEhwww9O3ifzobEaUiwrUK5Ue8Sp1G3WcwMzUkGum2ym2WE4e8wl8hyVEKu9zUbVEHyU8U3yDwbm1bwzwqp87q5rxO9w&__csr=&__req=p&__hs=19275.BP%3Abrands_pkg.2.0.0.0.0&dpr=1&__ccg=UNKNOWN&__rev=1006357666&__s=3kt2vt%3Awib606%3A2dszpx&__hsi=7152940038301643003&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=25578&lsd=xSUiq2X2uHc1pscEqPmOOG&__aaid=497657848867177&__spin_r=1006357666&__spin_b=trunk&__spin_t=1665423633&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingQEQuery&variables=%7B%22hasPaymentAccount%22%3Afalse%2C%22paymentAccountID%22%3Anull%2C%22universes%22%3A%5B%7B%22params%22%3A%5B%22show_billing_wizard_test%22%2C%22show_both_buttons%22%2C%22show_both_test%22%2C%22show_button_billing_wizard%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22ads_payments_billing_hub_contact_support%22%7D%2C%7B%22params%22%3A%5B%22auto_reload_supported%22%2C%22prepay_supported%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22auto_reload_testing_v1%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2021h2_ad_account_id%22%2C%22params%22%3A%5B%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22billing_h2_2021%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2022h1_ad_account_id%22%2C%22params%22%3A%5B%22all_unblock_options%22%2C%22backup_option_only%22%2C%22backup_pm_payment_settings_options%22%2C%22make_primary_checked%22%2C%22make_primary_checked_v2%22%2C%22make_primary_unchecked%22%2C%22make_primary_unchecked_v2%22%2C%22show_make_primary_checkbox%22%2C%22show_make_primary_checkbox_v2%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22billing_solutions_to_unblock_universe%22%7D%2C%7B%22holdout%22%3A%22billing_holdout_2021h2_ad_account_id%22%2C%22params%22%3A%5B%22is_eos_with_30_days%22%2C%22is_eos_with_30_days_v2%22%2C%22is_eos_with_anniversary%22%2C%22is_eos_with_anniversary_v2%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22end_of_spend_universe%22%7D%2C%7B%22params%22%3A%5B%22bv_enabled%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22flex_billing_h1_2021%22%7D%2C%7B%22params%22%3A%5B%22show_preauth_after_add_cc%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22pre_auth_experiment_bi%22%7D%2C%7B%22params%22%3A%5B%22show_support%22%5D%2C%22universe_name%22%3A%22risk_ops_contact_support%22%7D%2C%7B%22params%22%3A%5B%22show_restricted_addfunds%22%5D%2C%22universe_name%22%3A%22sdc_verification_on_add_funds%22%7D%2C%7B%22params%22%3A%5B%22show_restricted_paynow%22%5D%2C%22universe_name%22%3A%22sdc_verification_on_pay_now%22%7D%2C%7B%22params%22%3A%5B%22enable_nux%22%5D%2C%22type%22%3A%22PAYMENT_ACCOUNT%22%2C%22universe_name%22%3A%22standard_billing_2021_h2%22%7D%5D%7D&server_timestamps=true&doc_id=5787537841277053"
			}) }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.SslProtocols = SslProtocols.Tls12;
			httpRequest.Referer = string.Concat((string[])(object)new T0[8]
			{
				(T0)"https://business",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/settings/payment-methods/business_id=",
				BM_Id,
				(T0)"?business_id=",
				BM_Id,
				(T0)"&global_scope_id=",
				BM_Id
			});
			val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=7xeUmxa2C5rgydwCwRyU8EKnFG2Om2q12xCagmCwRCwqojyUV0OGiidBxa7EiwhEmwKzobo8LwAwgUgwqoqyoyazoO4o461twOxa7Am4o8E9EmxGcwXxKawlrGbwQzoO2ng-3tpUdoK7UC5U7y78jxiUa8522m3K2y3WElUScyo723m1Lz84aVpUuyUd88EeAVUhK1vVoao9k2B12ewi8doa84K5E5WUrorx2awCx5e8wxK2efK6F8W1dx-q4VEhwww9O3ifzobEaUiwrUK5Ue8Sp1G3WcwMzUkGum2ym2WEdEO8wl8hyVEKu9zUbVEHyU8U3yDwqU4C1bwzwqp87q5rxO9w&__csr=&__req=s&__hs=19275.BP%3Abrands_pkg.2.0.0.0.0&dpr=1&__ccg=UNKNOWN&__rev=1006357666&__s=3kt2vt%3Awib606%3A2dszpx&__hsi=7152940038301643003&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=25578&lsd=xSUiq2X2uHc1pscEqPmOOG&__aaid=497657848867177&__spin_r=1006357666&__spin_b=trunk&__spin_t=1665423633&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingMICheckFinanceEditorStateQuery&variables=%7B%22businessID%22%3A%22",
				BM_Id,
				(T0)"%22%7D&server_timestamps=true&doc_id=5242607189090759"
			}) }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.SslProtocols = SslProtocols.Tls12;
			httpRequest.Referer = string.Concat((string[])(object)new T0[8]
			{
				(T0)"https://business",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/settings/payment-methods/business_id=",
				BM_Id,
				(T0)"?business_id=",
				BM_Id,
				(T0)"&global_scope_id=",
				BM_Id
			});
			val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=7xeUmxa2C5rgydwCwRyU8EKnFG2Om2q12xCagmCwRCwqojyUV0OGiidBxa7EiwhEmwKzobo8LwAwgUgwqoqyoyazoO4o461twOxa7Am4o8E9EmxGcwXxKawlrGbwQzoO2ng-3tpUdoK7UC5U7y78jxiUa8522m3K2y3WElUScyo723m1Lz84aVpUuyUd88EeAVUhK1vVoao9k2B12ewi8doa84K5E5WUrorx2awCx5e8wxK2efK6F8W1dx-q4VEhwww9O3ifzobEaUiwrUK5Ue8Sp1G3WcwMzUkGum2ym2WEdEO8wl8hyVEKu9zUbVEHyU8U3yDwqU4C1bwzwqp87q5rxO9w&__csr=&__req=t&__hs=19275.BP%3Abrands_pkg.2.0.0.0.0&dpr=1&__ccg=UNKNOWN&__rev=1006357666&__s=3kt2vt%3Awib606%3A2dszpx&__hsi=7152940038301643003&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=25578&lsd=xSUiq2X2uHc1pscEqPmOOG&__aaid=497657848867177&__spin_r=1006357666&__spin_b=trunk&__spin_t=1665423633&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAddPaymentMethodBusinessScreenQuery&variables=%7B%22businessID%22%3A%22",
				BM_Id,
				(T0)"%22%2C%22paymentAccountID%22%3A%22%22%7D&server_timestamps=true&doc_id=5558453434248014"
			}) }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.SslProtocols = SslProtocols.Tls12;
			if (Chrome != null)
			{
				httpRequest.KeepAlive = true;
				httpRequest.AddHeader("viewport-width", "1229");
				httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
				httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
				httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
				httpRequest.UserAgent = strUserAgentDesktop;
				httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
				httpRequest.AddHeader("Sec-Fetch-Site", "none");
				httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
				httpRequest.AddHeader("Sec-Fetch-User", "?1");
				httpRequest.AddHeader("Sec-Fetch-Dest", "document");
			}
			httpRequest.Referer = string.Concat((string[])(object)new T0[8]
			{
				(T0)"https://business",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/settings/payment-methods/business_id=",
				BM_Id,
				(T0)"?business_id=",
				BM_Id,
				(T0)"&global_scope_id=",
				BM_Id
			});
			val2 = (T0)((object)httpRequest.Post("https://business.secure" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ajax/payment/token_proxy.php?tpe=%2Fapi%2Fgraphql%2F", string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[27]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&payment_dev_cycle=prod&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=&__req=w&__hs=19057.BP%3Abrands_pkg.2.0.0.0.&dpr=1&__ccg=MODERATE&__rev=1005155397&__s=qok82q%3Agc0lhn%3A5ccqxm&__hsi=&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=&lsd=&__spin_r=1005155397&__spin_b=trunk&__spin_t=1646590463&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=%7B%22input%22%3A%7B%22billing_address%22%3A%7B%22country_code%22%3A%22",
				strCountryCode,
				(T0)"%22%7D%2C%22billing_logging_data%22%3A%7B%22logging_counter%22%3A1%2C%22logging_id%22%3A%221%22%7D%2C%22cardholder_name%22%3A%22",
				(T0)HttpUtility.HtmlEncode((string)strNameCart),
				(T0)"%22%2C%22credit_card_first_6%22%3A%7B%22sensitive_string_value%22%3A%22",
				(T0)((string)strCC).Substring(0, 6),
				(T0)"%22%7D%2C%22credit_card_last_4%22%3A%7B%22sensitive_string_value%22%3A%22",
				(T0)((string)strCC).Substring(((string)strCC).Length - 4, 4),
				(T0)"%22%7D%2C%22credit_card_number%22%3A%7B%22sensitive_string_value%22%3A%22",
				strCC,
				(T0)"%22%7D%2C%22csc%22%3A%7B%22sensitive_string_value%22%3A%22",
				strCVV,
				(T0)"%22%7D%2C%22expiry_month%22%3A%22",
				strMonth,
				(T0)"%22%2C%22expiry_year%22%3A%22",
				strYear,
				(T0)"%22%2C%22payment_account_id%22%3A%22",
				strPaymentAccountId,
				(T0)"%22%2C%22payment_type%22%3A%22MOR_ADS_INVOICE%22%2C%22unified_payments_api%22%3Atrue%2C%22actor_id%22%3A%22",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"%22%2C%22client_mutation_id%22%3A%221%22%7D%7D&server_timestamps=true&doc_id=4126726757375265"
			}) }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.UserAgent = Http.FirefoxUserAgent();
			T1 val3 = (T1)((string)val2).Contains("description_raw");
			if (val3 == null)
			{
				return (T1)1;
			}
			strError = Regex.Match((string)val2, "description_raw\":\"(.*?)\"").Groups[1].Value;
		}
		catch (Exception ex)
		{
			strError = ex.Message;
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Get_Payment_Account_Id_BM<T0, T1, T2>(T0 BM_Id)
	{
		//IL_0085: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[6]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v10.0/",
				BM_Id,
				(T0)"?fields=payment_account_id&access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG
			}), (RequestParams)null)).ToString();
			BMDetail bMDetail = JsonConvert.DeserializeObject<BMDetail>((string)val);
			T1 val2 = (T1)(bMDetail != null && !string.IsNullOrWhiteSpace(bMDetail.payment_account_id));
			if (val2 != null)
			{
				return (T0)bMDetail.payment_account_id;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return (T0)"";
	}

	private T0 getIndexCard<T0, T1, T2>(T2 creditCardEntities)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_000d: Expected I4, but got O
		//IL_002f: Expected I4, but got O
		//IL_004c: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005e: Expected O, but got I4
		//IL_006d: Expected I4, but got O
		//IL_0088: Expected O, but got I4
		//IL_0093: Expected I4, but got O
		T0 result = (T0)(-1);
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < ((List<CreditCardEntity>)creditCardEntities).Count);
			if (val2 == null)
			{
				break;
			}
			T1 val3 = (T1)(((List<CreditCardEntity>)creditCardEntities)[(int)val].Status.Equals(frmMain.STATUS.Ready.ToString()) || ((List<CreditCardEntity>)creditCardEntities)[(int)val].Status.Equals(frmMain.STATUS.NoLimit.ToString()));
			if (val3 == null)
			{
				val = (T0)(val + 1);
				continue;
			}
			result = val;
			T1 val4 = (T1)((List<CreditCardEntity>)creditCardEntities)[(int)val].Status.Equals(frmMain.STATUS.Ready.ToString());
			if (val4 != null)
			{
				((List<CreditCardEntity>)creditCardEntities)[(int)val].Status = frmMain.STATUS.Used.ToString();
			}
			break;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Tạo_TKQC_BM<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_0135: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_01fd: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_02f6: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_0321: Expected O, but got I4
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_03b2: Expected O, but got I4
		//IL_03ca: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			setMessage<T0, T2, T1>((T2)"Tạo_TKQC_BM", (T0)0);
			T1 val2 = (T1)0;
			T2 val3 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"BM_Cầm_TK").ToString();
			T2 country_code = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Quốc_gia").ToString();
			T2 tax_id = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"MS_Thuế").ToString();
			T2 currency = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Tiền_tệ").ToString();
			T2 timezone = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Múi_giờ").ToString();
			T2 val4 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Đổi_tên").ToString();
			T2 strError = (T2)"";
			T3 bMList = getBMList<T2, T0, T3, T5>(out *(string*)(&strError));
			T0 val5 = (T0)(bMList != null && ((List<BusinessManagerEntity_businesses_Data>)bMList).Count > 0);
			if (val5 != null)
			{
				T1 val6 = (T1)1;
				T4 enumerator = (T4)((List<BusinessManagerEntity_businesses_Data>)bMList).GetEnumerator();
				try
				{
					while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
					{
						BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
						T2 val7 = (T2)"";
						T0 val8 = (T0)(!string.IsNullOrEmpty(current.TKQC) && !current.TKQC.Equals("null"));
						if (val8 != null)
						{
							val7 = (T2)current.TKQC.Replace("act_", "");
							setMessage<T0, T2, T1>((T2)("Đổi TTTK BM: " + (string)val7), (T0)0);
						}
						else
						{
							setMessage<T0, T2, T1>((T2)$"Tạo TK :{val6}", (T0)0);
							T0 val9 = (T0)string.IsNullOrWhiteSpace((string)val4);
							if (val9 != null)
							{
								val4 = (T2)frmMain.listFolder[frmMain.folderCheckedIndex].Name;
							}
							val7 = createAds<T2, T0, T1>(val4, (T2)"", (T2)"1", (T2)"USD", (T2)current.id, (T2)frmMain.listFBEntity[indexEntity].TokenEAAG, (T0)0, (T2)"");
						}
						T0 val10 = (T0)(!string.IsNullOrWhiteSpace((string)val7));
						if (val10 == null)
						{
							setMessage<T0, T2, T1>((T2)$"e:Tạo TK {val6} LỖI", (T0)0);
						}
						else
						{
							T0 val11 = (T0)(!frmMain.isRunning);
							if (val11 != null)
							{
								return;
							}
							shareToUser<T2, T0, T5, T1>((T2)frmMain.listFBEntity[indexEntity].TokenEAAG, (T2)current.id, (T2)frmMain.listFBEntity[indexEntity].UID, val7);
							T0 val12 = (T0)(!frmMain.isRunning);
							if (val12 != null)
							{
								return;
							}
							updateBillingInfo((string)val7, (string)currency, "", (string)country_code, "", "", "", frmMain.listFBEntity[indexEntity].Name, (string)timezone, frmMain.listFBEntity[indexEntity].UID, frmMain.listFBEntity[indexEntity].fb_dtsg, (string)tax_id);
							T0 val13 = (T0)(!frmMain.isRunning);
							if (val13 != null)
							{
								return;
							}
							T0 val14 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
							if (val14 != null)
							{
								T0 val15 = (T0)1;
								T2[] array = (T2[])(object)((string)val3).Split((char[])(object)new T6[1] { (T6)124 });
								T1 val16 = (T1)0;
								while ((nint)val16 < array.Length)
								{
									T2 val17 = (T2)((object[])(object)array)[(object)val16];
									T0 val18 = (T0)(!string.IsNullOrWhiteSpace((string)val17));
									if (val18 != null)
									{
										val15 = shareParter<T2, T0, T1>((T2)frmMain.listFBEntity[indexEntity].TokenEAAG, (T2)current.id, val17, val7);
									}
									val16 = (T1)(val16 + 1);
								}
								T0 val19 = val15;
								if (val19 != null)
								{
									Create_BM_Act_Count++;
								}
							}
							val2 = (T1)(val2 + 1);
						}
						val6 = (T1)(val6 + 1);
					}
				}
				finally
				{
					((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			else
			{
				setMessage<T0, T2, T1>((T2)"e:Không có BM", (T0)1);
			}
			setMessage<T0, T2, T1>((T2)$"Tạo TK_BM: {val2}", (T0)1);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 getBMList<T0, T1, T2, T3>(out string strError)
	{
		//IL_0076: Expected O, but got I4
		strError = "";
		try
		{
			T0 val = (T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v10.0/me?fields=businesses.limit(50000){id,name,payment_account_id,owned_ad_accounts{business_country_code,spend_cap,campaigns{id,status,delivery_status},timezone_name,id,name,account_status,currency,adtrust_dsl,amount_spent,adspaymentcycle{threshold_amount},has_repay_processing_invoices,invoicing_emails,balance}}&access_token=" + frmMain.listFBEntity[indexEntity].TokenEAAG);
			T0 val2 = (T0)((object)httpRequest.Get((string)val, (RequestParams)null)).ToString();
			BusinessManagerEntity businessManagerEntity = JsonConvert.DeserializeObject<BusinessManagerEntity>((string)val2);
			T1 val3 = (T1)(businessManagerEntity != null && businessManagerEntity.businesses != null && businessManagerEntity.businesses.data != null);
			if (val3 != null)
			{
				return (T2)businessManagerEntity.businesses.data;
			}
		}
		catch (Exception ex)
		{
			strError = ex.Message;
		}
		return (T2)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Tạo_TKQC_cá_nhân_2<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_0111: Expected O, but got I4
		//IL_0125: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_0277: Expected O, but got I4
		//IL_0288: Expected O, but got I4
		//IL_0299: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		//IL_02db: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0303: Expected O, but got I4
		//IL_0378: Expected O, but got I4
		//IL_038c: Expected O, but got I4
		//IL_0416: Expected O, but got I4
		//IL_0438: Expected O, but got I4
		//IL_0441: Expected O, but got I4
		//IL_0465: Expected O, but got I4
		//IL_0474: Expected O, but got I4
		//IL_048d: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_vào_BM").ToString());
			T1 string_ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Quốc_gia").ToString();
			T1 string_2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tiền_tệ").ToString();
			T1 string_3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Múi_giờ").ToString();
			setMessage<T0, T1, T2>((T1)"Tạo TKQC", (T0)0);
			T1 result = (T1)"";
			T1 act_Id = getAct_Id<T1, T0, List<nodes>.Enumerator, T2, Color>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, out *(string*)(&result));
			T0 val3 = (T0)string.IsNullOrWhiteSpace((string)act_Id);
			if (val3 != null)
			{
				setMessage<T0, T1, T2>((T1)"HCQC", (T0)1);
				return;
			}
			T0 val4 = (T0)((string)act_Id).Equals("checkpoint");
			if (val4 == null)
			{
				setMessage<T0, T1, T2>((T1)"Live TKQC", (T0)1);
				T1[] array = (T1[])(object)((string)act_Id).Split((char[])(object)new T4[1] { (T4)124 });
				T1 val5 = (T1)((object[])(object)array)[0];
				frmMain.listFBEntity[indexEntity].Name = (string)val5;
				setMessage<T0, T1, T2>(val5, (T0)0);
				T0 val6 = (T0)(smethod_1<T1, MatchCollection, T0>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG) == null);
				if (val6 != null)
				{
					smethod_2((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				}
				Thread.Sleep(1000);
				T0 val7 = doi_thong_tin_TKQC<T0, T1>(val5, string_3, string_, string_2, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)((string)ChromeControl.getFirstName<T0, T1, T2>() + " " + (string)ChromeControl.getLastName<T0, T1, T2>()), (T1)"", (T1)"", (T1)"", (T1)"", (T1)"");
				T0 val8 = val7;
				if (val8 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đổi Múi giờ & tiền tệ Ok", (T0)0);
				}
				else
				{
					T0 val9 = (T0)((string)val5).Contains("tiền");
					if (val9 != null)
					{
						setMessage<T0, T1, T2>((T1)"Không đủ tiền", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Đổi Múi giờ & tiền tệ lỗi", (T0)1);
					}
				}
				createNewAds_3<T1, T0>(val5, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				T0 val10 = (T0)((string)val5).Contains("tiền");
				if (val10 != null)
				{
					setMessage<T0, T1, T2>((T1)"Không đủ tiền", (T0)1);
				}
				T0 val11 = val2;
				if (val11 == null)
				{
					return;
				}
				setMessage<T0, T1, T2>((T1)"Đang thêm vào BM", (T0)0);
				addAdsToBM<T2, T0, T1>(val5, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
				T2 val12 = frmMain.nolimitApi.requestAddToBm<T2, HttpRequest, T1, T0>(val5);
				T0 val13 = (T0)(val12 == null);
				if (val13 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đang chờ clone chấp nhận", (T0)0);
					T0 val14 = acceptRequestToBm<T1, WebClient, NameValueCollection, T0, HttpRequest>(val5, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.TokenNolimit.ID_BM, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
					if (val14 != null)
					{
						Create_Act_Count++;
						setMessage<T0, T1, T2>((T1)"Thêm Bm ok", (T0)1);
					}
					else
					{
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val5);
						setMessage<T0, T1, T2>((T1)"Thêm BM lỗi", (T0)1);
					}
				}
				else
				{
					T0 val15 = (T0)((nint)val12 == 1);
					if (val15 == null)
					{
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val5);
						setMessage<T0, T1, T2>((T1)"Thêm BM lỗi", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Thêm BM ok", (T0)1);
					}
				}
			}
			else
			{
				setMessage<T0, T1, T2>((T1)frmMain.STATUS.Checkpoint.ToString(), (T0)1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Lưu_ID_TKQC<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			getFullAdsInfo<T1, T0>();
			T1 path = (T1)$"TKQC\\{frmMain.listFolder[frmMain.folderCheckedIndex].Name}.txt";
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					while (true)
					{
						try
						{
							File.AppendAllText((string)path, current.id.Replace("act_", "") + Environment.NewLine);
						}
						catch
						{
							Thread.Sleep(500);
							continue;
						}
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Share_pixel<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0157: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)0;
			getFullAdsInfo<T3, T0>();
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T3 act_id = (T3)current.id.Replace("act_", "");
					setMessage<T0, T3, T1>((T3)"Share pixel", (T0)0);
					T4 enumerator2 = (T4)frmMain.setting.List_TOKEN_PIXEL.GetEnumerator();
					try
					{
						while (((List<TokenEntity>.Enumerator*)(&enumerator2))->MoveNext())
						{
							TokenEntity current2 = ((List<TokenEntity>.Enumerator*)(&enumerator2))->Current;
							T0 val3 = (T0)current2.Status.Equals(frmMain.STATUS.Live.ToString());
							if (val3 != null)
							{
								T0 val4 = frmMain.apiPixel.Share_Pixel<T0, T1, T3, T5, T6>((T3)current2.Token, (T3)frmMain.setting.BM_Pixel_ID, (T3)frmMain.setting.Pixel_Id, act_id);
								if (val4 != null)
								{
									val2 = (T1)(val2 + 1);
									break;
								}
								current2.Status = frmMain.STATUS.Die.ToString();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
			setMessage<T0, T3, T1>((T3)$"Share pixel: {val2}", (T0)1);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Set_camp_chuyển_đổi_Suite<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0095: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_0322: Expected O, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_03c9: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_03fa: Expected O, but got I4
		//IL_0624: Expected O, but got I4
		//IL_0642: Expected O, but got I4
		//IL_065e: Expected O, but got I4
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Expected O, but got Unknown
		//IL_06b2: Expected O, but got I4
		//IL_06cf: Expected O, but got I4
		//IL_06ea: Expected O, but got I4
		//IL_0709: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Lỗi_dừng_lại").ToString());
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random-Tên-Id").ToString();
			T1 str = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"LWICometCreateBoostedComponentMutation").ToString();
			str = (T1)HttpUtility.UrlEncode((string)str);
			T0 val4 = (T0)(frmMain.listFBEntity[indexEntity].Message.ToLower().Contains("lỗi") & val2);
			if (val4 != null)
			{
				return;
			}
			setMessage<T0, T1, T3>((T1)"CĐ_Suite", (T0)1);
			acceptPolicy_3<T1, T7, T0>();
			T1 val5 = (T1)"";
			val3 = (T1)((string)val3).ToLower().Trim();
			T1 strError = (T1)"";
			T2 val6 = mtLoadPage<T2, T1, T0, T7>(out *(string*)(&strError));
			T0 val7 = (T0)(val6 != null && ((List<facebook_pagesData>)val6).Count > 0);
			if (val7 != null)
			{
				T4 enumerator = (T4)((List<facebook_pagesData>)val6).GetEnumerator();
				try
				{
					while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
					{
						facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
						T0 val8 = (T0)(string.IsNullOrEmpty((string)val3) || ((string)val3).Equals("random"));
						if (val8 != null)
						{
							T0 val9 = (T0)(!current.is_restricted);
							if (val9 != null)
							{
								val5 = (T1)current.id;
								break;
							}
						}
						else
						{
							T0 val10 = (T0)(current.id.Contains((string)val3) || current.name.ToLower().Contains((string)val3));
							if (val10 != null)
							{
								val5 = (T1)current.id;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T3 val11 = (T3)0;
			T0 val12 = (T0)string.IsNullOrWhiteSpace((string)val5);
			if (val12 != null)
			{
				setMessage<T0, T1, T3>((T1)"e:Không có page", (T0)1);
			}
			else
			{
				acceptPolicy_3<T1, T7, T0>();
				T1 val13 = (T1)string.Concat((string[])(object)new T1[13]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=6-Trjr2b957otq8:Prjr2i91w1byxa:0-Arjr2b91uupu3d-RV=6:F=&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo1087yq1ewcG0KEswIwuo662y11xmfw5ZKdwnU5W0IU9k2C2218wnE6a1uwZx214wlE-Uqw8y4Ueo8FU761iwKwHwqU8E5W3e1Xx-0LE6W4UpwSyES0gq0Lo9o9o8UdUcobU2cw&__csr=&__req=3x&__hs=19170.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_r,
					(T1)"&__s=&__hsi=&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=25409&lsd=NOAWFI5UiUnps85uTEQWxj&__spin_r=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_r,
					(T1)"&__spin_b=trunk&__spin_t=",
					(T1)frmMain.listFBEntity[indexEntity].__spin_t,
					(T1)"&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=LWICometCreateBoostedComponentMutation&variables=strVariables&server_timestamps=true&doc_id=3843613959067653"
				});
				T1 value = (T1)Regex.Match(((string)str).ToLower(), "legacy_ad_account_id%22%3a%22(.*?)%22").Groups[1].Value;
				T1 value2 = (T1)Regex.Match(((string)str).ToLower(), "flow_id%22%3a%22(.*?)%22").Groups[1].Value;
				T1 value3 = (T1)Regex.Match(((string)str).ToLower(), "page_id%22%3a%22(.*?)%22").Groups[1].Value;
				T1 oldValue = (T1)"old_uidold_uid";
				T0 val14 = (T0)((string)str).Contains("actor_id");
				if (val14 != null)
				{
					oldValue = (T1)Regex.Match(((string)str).ToLower(), "actor_id%22%3a%22(.*?)%22").Groups[1].Value;
				}
				getFullAdsInfo<T1, T0>();
				T5 enumerator2 = (T5)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
					{
						adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
						T1 val15 = (T1)current2.id.Replace("act_", "");
						adaccountsData adaccountsData = reload_act<T1, T7>(val15);
						T0 val16 = (T0)(adaccountsData.account_status == 2);
						if (val16 != null)
						{
							setMessage<T0, T1, T3>((T1)("TK " + (string)val15 + System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)1) + " DIE"), (T0)1);
							continue;
						}
						setMessage<T0, T1, T3>((T1)("Camp: " + (string)val15), (T0)1);
						T1 val17 = (T1)((string)val13).Replace("strUID", frmMain.listFBEntity[indexEntity].UID);
						val17 = (T1)((string)val17).Replace("strVariables", ((string)str).Replace((string)value, (string)val15).Replace((string)value2, ((T6)Guid.NewGuid()).ToString()).Replace((string)value3, (string)val5)
							.Replace((string)oldValue, frmMain.listFBEntity[indexEntity].UID));
						httpRequest.AddHeader("accept", "*/*");
						httpRequest.AddHeader("accept-language", "en-US,en;q=0.9");
						httpRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
						httpRequest.AddHeader("sec-ch-prefers-color-scheme", "light");
						httpRequest.AddHeader("sec-ch-ua", "\".Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"103\", \"Chromium\";v=\"103\"");
						httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
						httpRequest.AddHeader("sec-ch-ua-platform", "\"Windows\"");
						httpRequest.AddHeader("sec-fetch-dest", "empty");
						httpRequest.AddHeader("sec-fetch-mode", "cors");
						httpRequest.AddHeader("sec-fetch-site", "same-origin");
						httpRequest.AddHeader("viewport-width", "1463");
						httpRequest.AddHeader("x-fb-friendly-name", "LWICometCreateBoostedComponentMutation");
						httpRequest.AddHeader("x-fb-lsd", "NOAWFI5UiUnps85uTEQWxj");
						httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=110072251856927";
						T1 val18 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { val17 }), "application/x-www-form-urlencoded")).ToString();
						T0 val19 = (T0)((string)val18).Contains("is_final\":true");
						if (val19 == null)
						{
							setMessage<T0, T1, T3>((T1)("Camp " + (string)val15 + " lỗi"), (T0)1);
							continue;
						}
						setMessage<T0, T1, T3>((T1)("Camp " + (string)val15 + " OK"), (T0)1);
						val11 = (T3)(val11 + 1);
						Thread.Sleep(3000);
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
				}
			}
			T0 val20 = (T0)frmMain.listFBEntity[indexEntity].Message.Contains("e:");
			if (val20 != null)
			{
				setMessage<T0, T1, T3>((T1)$"Camp: {val11}", (T0)1);
			}
			else
			{
				setMessage<T0, T1, T3>((T1)$"Camp: {val11}", (T0)1);
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T3>((T1)("e:" + ex.Message), (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void acceptPolicy_3<T0, T1, T2>()
	{
		//IL_019f: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_0310: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		try
		{
			httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?asset_id=110072251856927";
			((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[15]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__usid=6-Trjr2b957otq8%3APrjr2b81j8enx6%3A0-Arjr2b91uupu3d-RV%3D6%3AF%3D&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=7xeUmwkHgydwn8K2WnFwn84a2i5U4e2O3O4UKewSAAwCxW4E5S2WdwJwaZ1q1twUx60Vo1087yq1ewcG0KEswIwuo662y11xmfw5ZKdwnU5W0IU9k2C2218wnE6a1uwZx214wlE-Uqw8y4Ueo8FU761iwKwHwqU8E5W3e1Xx-0LE6W4UpwSyES0gq0Lo9o9o8UdUcobU2cw&__csr=&__req=1y&__hs=19279.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=",
				(T0)frmMain.listFBEntity[indexEntity].__spin_r,
				(T0)"&__s=l556d4%3Ap218wk%3Av9ecwz&__hsi=7154394019123928595&__comet_req=0&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=25253&lsd=1YQTTDKkM4ILkVY3hWG2P2&__aaid=492755936026273&__spin_r=",
				(T0)frmMain.listFBEntity[indexEntity].__spin_r,
				(T0)"&__spin_b=trunk&__spin_t=",
				(T0)frmMain.listFBEntity[indexEntity].__spin_t,
				(T0)"&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useAdIntegrityCertifyMutation&variables=%7B%22input%22%3A%7B%22source%22%3A%22lwi_www%22%2C%22actor_id%22%3A%22",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"%22%2C%22client_mutation_id%22%3A%222%22%7D%7D&server_timestamps=true&doc_id=4873245096092226"
			}) }), "application/x-www-form-urlencoded")).ToString();
		}
		catch (Exception ex)
		{
			setMessage<T2, T0, int>((T0)("e:" + ex.Message), (T2)1);
		}
		T2 val = (T2)(!frmMain.isRunning);
		if (val == null)
		{
			try
			{
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/adsmanager/manage/campaigns?nav_entry_point=comet_bookmark";
				((object)httpRequest.Post("https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/integrity/user/self_cert/ajax/", string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[11]
				{
					(T0)"source=boosted_component_create&__usid=6-Trjpe0u5mbsei%3APrjpe0sne0r29%3A0-Arjpe0uv14zf9-RV%3D6%3AF%3D&__user=",
					(T0)frmMain.listFBEntity[indexEntity].UID,
					(T0)"&__a=1&__dyn=7AgSXghF3Gxd2um5rpUR0Bxpxa9yUqDBBheCFohK49o9EeAq2imeGqFEkG4VEHoOqqE88lBxeipe9wNWAAzppFuUuGfxW2vxi4EOezoK26UKbC-mdwTzUOESegGbwgEmK9y8Gdz8hyUuxqt1eiUO4EgCyku4oS4EWfGUhwyg9p44889EScxyu6UGq13yHGmmUTxJe9LgbdkGypVRg8Rpo8ESibKegK9xubwr8sxep3bBAzECi9lpubwIxecAwXzogyo465ubUO9xSfwgEnxaFo5a7EN1O74qVpVoKcyU98-m79UcF9Q4bwRwFDCG4UK4EigK7kbAzEmK8wzgdoKdKazUlwBx6i1iyWgroF3UgyHxSi4kUy7rKfxefKazUWi2y2icxaq4VEhGcx22uewDwZAwLzUS2XxeayEiwAgCmHxK9K8yUnwUzpUqw-yK4UoKfxiFAm9KczpoaHQfwPy9oCbxa58gx6bCyVUCuho88WqaVF8-4Uiwj9pEcE4avAxa9w8Kmbw_wzzq-3W5rg99oak48-eC-dDVbBw&__csr=&__req=1m&__hs=19278.BP%3Aads_manager_pkg.2.0.0.0.0&dpr=1&__ccg=UNKNOWN&__rev=",
					(T0)frmMain.listFBEntity[indexEntity].__spin_r,
					(T0)"&__s=53pxhn%3A5mxdvz%3A0njfx0&__hsi=7154058426525392943&__comet_req=0&fb_dtsg=",
					(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T0)"&jazoest=25164&lsd=oyUz-V91ziRQ3iByX3nCIe&__aaid=510551574249800&__spin_r=",
					(T0)frmMain.listFBEntity[indexEntity].__spin_r,
					(T0)"&__spin_b=trunk&__spin_t=",
					(T0)frmMain.listFBEntity[indexEntity].__spin_t,
					(T0)"&__jssesw=1"
				}) }), "application/x-www-form-urlencoded")).ToString();
			}
			catch (Exception ex2)
			{
				setMessage<T2, T0, int>((T0)("e:" + ex2.Message), (T2)1);
			}
			try
			{
				httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/adsmanager/manage/ads?act=578282704086097&business_id=518611856763429&nav_source=no_referrer";
				((object)httpRequest.Post("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/integrity/user/self_cert/ajax/", string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[11]
				{
					(T0)"source=boosted_component_create&__usid=&__user=",
					(T0)frmMain.listFBEntity[indexEntity].UID,
					(T0)"&__a=1&__dyn=&__csr=&__req=1d&__hs=19270.BP%3Aads_manager_pkg.2.0.0.0.0&dpr=1&__ccg=UNKNOWN&__rev=",
					(T0)frmMain.listFBEntity[indexEntity].__spin_r,
					(T0)"&__s=irz77f%3Arwupdc%3Akuxmod&__hsi=&__comet_req=0&fb_dtsg=",
					(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T0)"&jazoest=25326&lsd=c7krdEoZP71-twpW1R2CUb&__spin_r=",
					(T0)frmMain.listFBEntity[indexEntity].__spin_r,
					(T0)"&__spin_b=trunk&__spin_t=",
					(T0)frmMain.listFBEntity[indexEntity].__spin_t,
					(T0)"&__jssesw=1"
				}) }), "application/x-www-form-urlencoded")).ToString();
			}
			catch (Exception ex3)
			{
				setMessage<T2, T0, int>((T0)("e:" + ex3.Message), (T2)1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Set_camp_chuyển_đổi_PE<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_013d: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_01af: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_01eb: Expected O, but got I4
		//IL_0221: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_023b: Expected O, but got I4
		//IL_0291: Expected O, but got I4
		//IL_02d3: Expected O, but got I4
		//IL_0300: Expected O, but got I4
		//IL_0350: Expected O, but got I4
		//IL_036b: Expected O, but got I4
		//IL_04cf: Expected O, but got I4
		//IL_0be9: Expected O, but got I4
		//IL_0c1b: Expected O, but got I4
		//IL_0eb9: Expected O, but got I4
		//IL_0f1c: Expected O, but got I4
		//IL_0f6d: Expected O, but got I4
		//IL_0f85: Expected O, but got I4
		//IL_1024: Expected O, but got I4
		//IL_1058: Expected O, but got I4
		//IL_10a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a7: Expected O, but got Unknown
		//IL_10c1: Expected O, but got I4
		//IL_10d9: Expected O, but got I4
		//IL_1122: Expected O, but got I4
		//IL_113f: Expected O, but got I4
		//IL_115a: Expected O, but got I4
		//IL_1179: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Lỗi_dừng_lại").ToString());
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random-Tên-Id").ToString();
			T1 str = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_web").ToString();
			T1 str2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Nội_dung").ToString();
			T1 path = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Folder_ảnh").ToString();
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Giới_tính_0_1_2").ToString());
			T1 val4 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tuổi_min").ToString();
			T1 val5 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tuổi_max").ToString();
			T1 str3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Quốc_gia").ToString();
			T1 val6 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Ngân_sách").ToString();
			T1 val7 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Pixcel_Id").ToString();
			T1 val8 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Domain_Pixel").ToString();
			T0 val9 = (T0)(frmMain.listFBEntity[indexEntity].Message.ToLower().Contains("lỗi") & val2);
			if (val9 != null)
			{
				return;
			}
			setMessage<T0, T1, T2>((T1)"Set_camp_chuyển_đổi_PE", (T0)1);
			acceptPolicy_3<T1, T11, T0>();
			T1 val10 = (T1)"";
			val3 = (T1)((string)val3).ToLower().Trim();
			T1 strError = (T1)"";
			T3 val11 = mtLoadPage<T3, T1, T0, T11>(out *(string*)(&strError));
			T0 val12 = (T0)(val11 != null && ((List<facebook_pagesData>)val11).Count > 0);
			if (val12 != null)
			{
				T4 enumerator = (T4)((List<facebook_pagesData>)val11).GetEnumerator();
				try
				{
					while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
					{
						facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
						T0 val13 = (T0)(string.IsNullOrEmpty((string)val3) || ((string)val3).Equals("random"));
						if (val13 != null)
						{
							T0 val14 = (T0)(!current.is_restricted);
							if (val14 != null)
							{
								val10 = (T1)current.id;
								break;
							}
						}
						else
						{
							T0 val15 = (T0)(current.id.Contains((string)val3) || current.name.ToLower().Contains((string)val3));
							if (val15 != null)
							{
								val10 = (T1)current.id;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T2 val16 = (T2)0;
			T0 val17 = (T0)string.IsNullOrWhiteSpace((string)val10);
			if (val17 != null)
			{
				setMessage<T0, T1, T2>((T1)"e:Không có page", (T0)1);
			}
			else
			{
				acceptPolicy_3<T1, T11, T0>();
				getFullAdsInfo<T1, T0>();
				T5 enumerator2 = (T5)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
					{
						adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
						T0 val18 = (T0)(!frmMain.isRunning);
						if (val18 != null)
						{
							return;
						}
						T1 val19 = (T1)current2.id.Replace("act_", "");
						T0 val20 = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
						if (val20 != null)
						{
							getTokenEAAG_EEAB<T2, HttpRequest, T1, T0>();
							T0 val21 = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
							if (val21 != null)
							{
								frmMain.listFBEntity[indexEntity].TokenEAAB = frmMain.listFBEntity[indexEntity].TokenEAAG;
							}
						}
						adaccountsData adaccountsData = reload_act<T1, T11>(val19);
						T0 val22 = (T0)(adaccountsData.account_status == 2);
						if (val22 == null)
						{
							T1 val23 = (T1)"";
							setMessage<T0, T1, T2>((T1)"Nhập camp", (T0)1);
							httpRequest.KeepAlive = true;
							httpRequest.AddHeader("viewport-width", "1229");
							httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
							httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
							httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
							httpRequest.UserAgent = strUserAgentDesktop;
							httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
							httpRequest.AddHeader("Sec-Fetch-Site", "none");
							httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
							httpRequest.AddHeader("Sec-Fetch-User", "?1");
							httpRequest.AddHeader("Sec-Fetch-Dest", "document");
							T1 val24 = (T1)((object)httpRequest.Get(string.Concat((string[])(object)new T1[5]
							{
								(T1)"https://www",
								(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
								(T1)"/adsmanager/manage/campaigns?act=",
								val19,
								(T1)"&nav_entry_point=lep_233&nav_source=unknown"
							}), (RequestParams)null)).ToString();
							Thread.Sleep(1000);
							addraft_fragments_2 addraft_fragments_ = null;
							addraft_fragments_ = getAddraftCamp_2(val19);
							T0 val25 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
							if (val25 != null)
							{
								T6 enumerator3 = (T6)addraft_fragments_.data.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
									{
										addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
										val23 = (T1)current3.id;
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
								}
							}
							httpRequest.KeepAlive = true;
							httpRequest.AddHeader("viewport-width", "1229");
							httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
							httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
							httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
							httpRequest.UserAgent = strUserAgentDesktop;
							httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
							httpRequest.AddHeader("Sec-Fetch-Site", "none");
							httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
							httpRequest.AddHeader("Sec-Fetch-User", "?1");
							httpRequest.AddHeader("Sec-Fetch-Dest", "document");
							httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/";
							val24 = (T1)((object)httpRequest.Post(string.Concat((string[])(object)new T1[5]
							{
								(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
								val23,
								(T1)"/addraft_fragments?_app=ADS_MANAGER&_reqName=object%3Aaddraft%2Faddraft_fragments&access_token=",
								(T1)frmMain.listFBEntity[indexEntity].TokenEAAB,
								(T1)"&method=post&qpl_active_flow_ids=270209052%2C270220209&qpl_active_flow_instance_ids=270209052_4af20fef18b6c578c%2C270209052_4afccc52360f1d64%2C270220209_4af2f0a3a678c4d4&__cppo=1"
							}), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[9]
							{
								(T1)"__activeScenarioIDs=%5B%22f18fb3cb823f094_1664951151825.1%22%2C%222f2a5c8a-5ae2-4e62-96bd-aafa548d79fa%22%5D&__activeScenarios=%5B%22ad_object_draft_creation%22%2C%22am.draft.create_draft%22%5D&__interactionsMetadata=%5B%22%7Bname%3Aam.draft.create_draft%2Cflow_instance_id%3A270209052_4afccc52360f1d64%2Cat_section%3AL3%2Cstart_callsite%3AQUICK_CREATION%2Crevisit%3A0%2Ccurrent_action_objects_total_count%3A0%2C%7D%22%5D&_app=ADS_MANAGER&_priority=HIGH&_reqName=object%3Aaddraft%2Faddraft_fragments&_reqSrc=AdsDraftFragmentDataManager&_sessionID=4818864a307aae4a&account_id=",
								val19,
								(T1)"&action=add&ad_draft_id=",
								val23,
								(T1)"&ad_object_type=campaign&include_headers=false&is_archive=false&is_delete=false&locale=en_GB&method=post&pretty=0&qpl_active_flow_ids=270209052%2C270220209&qpl_active_flow_instance_ids=270209052_4af20fef18b6c578c%2C270209052_4afccc52360f1d64%2C270220209_4af2f0a3a678c4d4&source=click_quick_create&suppress_http_code=1&validate=false&values=%5B%7B%22field%22%3A%22adlabels%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22pacing_type%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%22standard%22%5D%7D%2C%7B%22field%22%3A%22start_time%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22stop_time%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22split_test_config%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22can_use_spend_cap%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Atrue%7D%2C%7B%22field%22%3A%22daily_budget%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								val6,
								(T1)"%22%7D%2C%7B%22field%22%3A%22name%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22New%20Sales%20campaign%22%7D%2C%7B%22field%22%3A%22metrics_metadata%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22campaign_group_creation_source%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22click_quick_create%22%7D%2C%7B%22field%22%3A%22smart_promotion_type%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22account_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								val19,
								(T1)"%22%7D%2C%7B%22field%22%3A%22is_odax_campaign_group%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Atrue%7D%2C%7B%22field%22%3A%22tempID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A-1664953132594%7D%2C%7B%22field%22%3A%22boosted_component_product%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22incremental_conversion_optimization_config%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22spend_cap%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22topline_id%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22special_ad_categories%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%22NONE%22%5D%7D%2C%7B%22field%22%3A%22status%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22ACTIVE%22%7D%2C%7B%22field%22%3A%22special_ad_category%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22NONE%22%7D%2C%7B%22field%22%3A%22bid_strategy%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22LOWEST_COST_WITHOUT_CAP%22%7D%2C%7B%22field%22%3A%22objective%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22OUTCOME_SALES%22%7D%2C%7B%22field%22%3A%22is_autobid%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Atrue%7D%2C%7B%22field%22%3A%22promoted_object%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22lifetime_budget%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22budget_remaining%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22is_average_price_pacing%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Afalse%7D%2C%7B%22field%22%3A%22buying_type%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22AUCTION%22%7D%2C%7B%22field%22%3A%22collaborative_ads_partner_info%22%2C%22old_value%22%3Anull%7D%2C%7B%22field%22%3A%22is_using_l3_schedule%22%2C%22old_value%22%3Anull%7D%5D&xref=f8b697f18ca17c"
							}) }), "application/x-www-form-urlencoded")).ToString();
							T1 value = (T1)Regex.Match((string)val24, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
							httpRequest.KeepAlive = true;
							httpRequest.AddHeader("viewport-width", "1229");
							httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
							httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
							httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
							httpRequest.UserAgent = strUserAgentDesktop;
							httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
							httpRequest.AddHeader("Sec-Fetch-Site", "none");
							httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
							httpRequest.AddHeader("Sec-Fetch-User", "?1");
							httpRequest.AddHeader("Sec-Fetch-Dest", "document");
							T1 val26 = (T1)HttpUtility.UrlEncode((string)str3);
							httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/";
							val24 = (T1)((object)httpRequest.Post(string.Concat((string[])(object)new T1[5]
							{
								(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
								val23,
								(T1)"/addraft_fragments?_app=ADS_MANAGER&_reqName=object%3Aaddraft%2Faddraft_fragments&access_token=",
								(T1)frmMain.listFBEntity[indexEntity].TokenEAAB,
								(T1)"&method=post&qpl_active_flow_instance_ids=270209052_c9f2d4ab9954fc1e4&__cppo=1"
							}), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[21]
							{
								(T1)"__activeScenarioIDs=%5B%22ffe6f2f503851c_1664953250171.6%22%5D&__activeScenarios=%5B%22ad_object_draft_creation%22%5D&_app=ADS_MANAGER&_priority=HIGH&_reqName=object%3Aaddraft%2Faddraft_fragments&_reqSrc=AdsDraftFragmentDataManager&_sessionID=493dd34e494f73c9&account_id=",
								val19,
								(T1)"&action=add&ad_draft_id=",
								val23,
								(T1)"&ad_object_type=ad_set&include_headers=false&is_archive=false&is_delete=false&locale=en_GB&method=post&parent_ad_object_id=",
								value,
								(T1)"&pretty=0&qpl_active_flow_instance_ids=270209052_c9f2d4ab9954fc1e4&source=create_ad_set_contextual&suppress_http_code=1&validate=false&values=%5B%7B%22field%22%3A%22optimization_goal%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22OFFSITE_CONVERSIONS%22%7D%2C%7B%22field%22%3A%22targeting_as_signal%22%2C%22new_value%22%3A3%7D%2C%7B%22field%22%3A%22parentAdObjectID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								value,
								(T1)"%22%7D%2C%7B%22field%22%3A%22start_time%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%222022-10-05T15%3A00%3A51%2B0800%22%7D%2C%7B%22field%22%3A%22campaign_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								value,
								(T1)"%22%7D%2C%7B%22field%22%3A%22name%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22New%20Sales%20ad%20set%22%7D%2C%7B%22field%22%3A%22campaign_creation_source%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22create_ad_set_contextual%22%7D%2C%7B%22field%22%3A%22account_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								val19,
								(T1)"%22%7D%2C%7B%22field%22%3A%22tempID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A-1664953251261%7D%2C%7B%22field%22%3A%22targeting%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22age_max%22%3A",
								val5,
								(T1)"%2C%22user_device%22%3A%5B%5D%2C%22excluded_publisher_list_ids%22%3A%5B%5D%2C%22geo_locations%22%3A%7B%22countries%22%3A%5B",
								val26,
								(T1)"%5D%2C%22location_types%22%3A%5B%22home%22%2C%22recent%22%5D%7D%2C%22facebook_positions%22%3A%5B%22feed%22%2C%22instant_article%22%2C%22instream_video%22%2C%22right_hand_column%22%2C%22video_feeds%22%2C%22marketplace%22%2C%22story%22%2C%22facebook_reels_overlay%22%2C%22search%22%2C%22groups_feed%22%2C%22biz_disco_feed%22%2C%22facebook_reels%22%5D%2C%22age_min%22%3A",
								val4,
								(T1)"%2C%22excluded_brand_safety_content_types%22%3A%5B%5D%2C%22excluded_user_device%22%3A%5B%5D%2C%22wireless_carrier%22%3A%5B%5D%2C%22device_platforms%22%3A%5B%22mobile%22%2C%22desktop%22%5D%2C%22user_os%22%3A%5B%5D%2C%22brand_safety_content_filter_levels%22%3A%5B%22FACEBOOK_STANDARD%22%2C%22AN_STANDARD%22%5D%2C%22publisher_platforms%22%3A%5B%22facebook%22%5D%7D%7D%2C%7B%22field%22%3A%22end_time%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22status%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22ACTIVE%22%7D%2C%7B%22field%22%3A%22frequency_control_specs%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22bid_constraints%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%5D%7D%2C%7B%22field%22%3A%22billing_event%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22IMPRESSIONS%22%7D%2C%7B%22field%22%3A%22full_funnel_exploration_mode%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22NONE_EXPLORATION%22%7D%2C%7B%22field%22%3A%22promoted_object%22%2C%22new_value%22%3A%7B%22pixel_id%22%3A%22",
								val7,
								(T1)"%22%2C%22custom_event_type%22%3A%22PURCHASE%22%7D%7D%2C%7B%22field%22%3A%22attribution_spec%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%7B%22event_type%22%3A%22CLICK_THROUGH%22%2C%22window_days%22%3A7%7D%2C%7B%22event_type%22%3A%22VIEW_THROUGH%22%2C%22window_days%22%3A1%7D%5D%7D%5D&xref=f26e506703fc528"
							}) }), "application/x-www-form-urlencoded")).ToString();
							T1 value2 = (T1)Regex.Match((string)val24, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
							T1 val27 = (T1)"";
							T1 val28 = (T1)"";
							T1 filename = ((IEnumerable<T1>)(object)Directory.GetFiles((string)path)).First();
							T7 val29 = (T7)Image.FromFile((string)filename);
							try
							{
								T8 val30 = (T8)Activator.CreateInstance(typeof(MemoryStream));
								try
								{
									((Image)val29).Save((Stream)val30, ((Image)val29).RawFormat);
									T9[] inArray = (T9[])(object)((MemoryStream)val30).ToArray();
									val28 = (T1)Convert.ToBase64String((byte[])(object)inArray);
									val28 = (T1)HttpUtility.UrlEncode((string)val28);
								}
								finally
								{
									if (val30 != null)
									{
										((IDisposable)val30).Dispose();
									}
								}
							}
							finally
							{
								if (val29 != null)
								{
									((IDisposable)val29).Dispose();
								}
							}
							httpRequest.KeepAlive = true;
							httpRequest.AddHeader("viewport-width", "1229");
							httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
							httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
							httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
							httpRequest.UserAgent = strUserAgentDesktop;
							httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
							httpRequest.AddHeader("Sec-Fetch-Site", "none");
							httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
							httpRequest.AddHeader("Sec-Fetch-User", "?1");
							httpRequest.AddHeader("Sec-Fetch-Dest", "document");
							httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/";
							val24 = (T1)((object)httpRequest.Post(string.Concat((string[])(object)new T1[9]
							{
								(T1)"https://graph",
								(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
								(T1)"/v15.0/act_",
								val19,
								(T1)"/adimages?_app=ADS_MANAGER&_reqName=path%3A%2Fact_",
								val19,
								(T1)"%2Fadimages&access_token=",
								(T1)frmMain.listFBEntity[indexEntity].TokenEAAB,
								(T1)"&method=post&qpl_active_flow_ids=270212441%2C270213890&qpl_active_flow_instance_ids=270212441_ecf38a690b9a8fa74%2C270213890_ecf327b1c8905ff6&__cppo=1"
							}), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[9]
							{
								(T1)"__activeScenarioIDs=%5B%22f3e2e21abd7fd2_1664874796753.9%22%2C%226ff6a1c0-77e5-4b9f-9a0a-8a70de2fd32b%22%5D&__activeScenarios=%5B%22am%3Aedit_ads%3Aupload_asset_in_media_dialog%22%2C%22am.edit_ads.upload_asset_in_media_dialog%22%5D&__business_id=&__interactionsMetadata=%5B%22%7Bname%3Aam.edit_ads.upload_asset_in_media_dialog%2Cflow_instance_id%3A270212441_ecf38a690b9a8fa74%2Cat_section%3AL1%2Cstart_callsite%3AAdsImageUploadDragDialogAndVideoThumbnailUploadPerfScenarioLoggerPlugins_default%2Crevisit%3A0%2Ccurrent_action_objects_total_count%3A0%2C%7D%22%5D&_app=ADS_MANAGER&_reqName=path%3A%2Fact_",
								val19,
								(T1)"%2Fadimages&_reqSrc=adsDaoGraphDataMutator&_sessionID=48fb4d95abb233ec&accountId=",
								val19,
								(T1)"&bytes=",
								val28,
								(T1)"&encoding=data%3Aimage%2Fpng%3Bbase64&endpoint=%2Fact_",
								val19,
								(T1)"%2Fadimages&include_headers=false&locale=en_US&method=post&name=Screenshot%202022-09-28%20131210.png&pretty=0&qpl_active_flow_ids=270212441%2C270213890&qpl_active_flow_instance_ids=270212441_ecf38a690b9a8fa74%2C270213890_ecf327b1c8905ff6&suppress_http_code=1&xref=f1efedf40ae679"
							}) }), "application/x-www-form-urlencoded")).ToString();
							T0 val31 = (T0)(!((string)val24).Contains("hash\":"));
							if (val31 == null)
							{
								val27 = (T1)Regex.Match((string)val24, "hash\":\"(.*?)\"").Groups[1].Value;
							}
							else
							{
								setMessage<T0, T1, T2>((T1)"e:Upload ảnh camp lỗi", (T0)1);
							}
							T1 val32 = (T1)HttpUtility.UrlEncode((string)str2);
							T1 val33 = (T1)HttpUtility.UrlEncode((string)str);
							httpRequest.KeepAlive = true;
							httpRequest.AddHeader("viewport-width", "1229");
							httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
							httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
							httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
							httpRequest.UserAgent = strUserAgentDesktop;
							httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
							httpRequest.AddHeader("Sec-Fetch-Site", "none");
							httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
							httpRequest.AddHeader("Sec-Fetch-User", "?1");
							httpRequest.AddHeader("Sec-Fetch-Dest", "document");
							httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/";
							val24 = (T1)((object)httpRequest.Post(string.Concat((string[])(object)new T1[5]
							{
								(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
								val23,
								(T1)"/addraft_fragments?_app=ADS_MANAGER&_reqName=object%3Aaddraft%2Faddraft_fragments&access_token=",
								(T1)frmMain.listFBEntity[indexEntity].TokenEAAB,
								(T1)"&method=post&qpl_active_flow_instance_ids=270209052_a9f34b96e66845b&__cppo=1"
							}), string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[25]
							{
								(T1)"__activeScenarioIDs=%5B%22f2b1537dea56d8_1664953953950%22%5D&__activeScenarios=%5B%22ad_object_draft_creation%22%5D&_app=ADS_MANAGER&_priority=HIGH&_reqName=object%3Aaddraft%2Faddraft_fragments&_reqSrc=AdsDraftFragmentDataManager&_sessionID=61acfc41ff3261a9&account_id=",
								val19,
								(T1)"&action=add&ad_draft_id=",
								val23,
								(T1)"&ad_object_type=ad&include_headers=false&is_archive=false&is_delete=false&locale=en_GB&method=post&parent_ad_object_id=",
								value2,
								(T1)"&pretty=0&qpl_active_flow_instance_ids=270209052_a9f34b96e66845b&source=create_ad_contextual&suppress_http_code=1&validate=false&values=%5B%7B%22field%22%3A%22parentAdObjectID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								value2,
								(T1)"%22%7D%2C%7B%22field%22%3A%22campaign_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								value,
								(T1)"%22%7D%2C%7B%22field%22%3A%22name%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22New%20Sales%20ad%22%7D%2C%7B%22field%22%3A%22conversion_domain%22%2C%22new_value%22%3A%22",
								val8,
								(T1)"%22%7D%2C%7B%22field%22%3A%22account_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								val19,
								(T1)"%22%7D%2C%7B%22field%22%3A%22creative%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22object_story_spec%22%3A%7B%22link_data%22%3A%7B%22call_to_action%22%3A%7B%22value%22%3A%7B%22link%22%3Anull%7D%2C%22type%22%3A%22SHOP_NOW%22%7D%2C%22image_hash%22%3A%22",
								val27,
								(T1)"%22%2C%22message%22%3A%22",
								val32,
								(T1)"%22%2C%22link%22%3A%22",
								val33,
								(T1)"%22%7D%2C%22page_id%22%3A%22",
								val10,
								(T1)"%22%7D%2C%22degrees_of_freedom_spec%22%3A%7B%22creative_features_spec%22%3A%7B%22standard_enhancements%22%3A%7B%22action_metadata%22%3A%7B%22type%22%3A%22DEFAULT%22%7D%2C%22enroll_status%22%3A%22OPT_OUT%22%7D%7D%2C%22degrees_of_freedom_type%22%3A%22USER_ENROLLED_NON_DCO%22%2C%22text_transformation_types%22%3A%5B%22TEXT_LIQUIDITY%22%5D%2C%22image_transformation_types%22%3A%5B%22CROPPING%22%2C%22ENHANCEMENT%22%5D%7D%2C%22object_type%22%3A%22SHARE%22%2C%22asset_feed_spec%22%3A%7B%22badge_sets%22%3A%5B%7B%22social_cues_from_profile%22%3A%7B%22selected_social_cues_options%22%3A%5B%22ig_account_followers%22%2C%22page_check_ins%22%2C%22page_follows%22%2C%22page_likes%22%2C%22page_messenger_response_time%22%2C%22page_ratings%22%2C%22page_recent_check_ins%22%5D%7D%2C%22business_info_from_profile%22%3A%7B%22selected_business_info_options%22%3A%5B%22ig_account_joining_date%22%2C%22page_operating_hours%22%2C%22page_price_range%22%2C%22page_store_location%22%5D%7D%7D%5D%7D%7D%7D%2C%7B%22field%22%3A%22tempID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A-1664953955072%7D%2C%7B%22field%22%3A%22status%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22ACTIVE%22%7D%2C%7B%22field%22%3A%22adset_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22",
								value2,
								(T1)"%22%7D%2C%7B%22field%22%3A%22display_sequence%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A0%7D%2C%7B%22field%22%3A%22ad_creation_source%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22create_ad_contextual%22%7D%5D&xref=f1f7e6c37e05cd4"
							}) }), "application/x-www-form-urlencoded")).ToString();
							_ = Regex.Match((string)val24, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
							Thread.Sleep(1000);
							T1 val34 = (T1)"";
							T0 val39;
							do
							{
								addraft_fragments_ = getAddraftCamp_2(val19);
								T0 val35 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
								if (val35 != null)
								{
									T6 enumerator4 = (T6)addraft_fragments_.data.GetEnumerator();
									try
									{
										while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator4))->MoveNext())
										{
											addraft_fragments_2_data current4 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator4))->Current;
											val23 = (T1)current4.id;
											T10 enumerator5 = (T10)current4.addraft_fragments.data.GetEnumerator();
											try
											{
												while (((List<addraft_fragments_data>.Enumerator*)(&enumerator5))->MoveNext())
												{
													addraft_fragments_data current5 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator5))->Current;
													T0 val36 = (T0)current5.ad_object_type.Equals("ad");
													if (val36 != null)
													{
														val34 = (T1)((string)val34 + "\"" + current5.id + "\",");
														_ = current5.ad_object_id;
														_ = current5.id;
														_ = current5.parent_ad_object_id;
														continue;
													}
													T0 val37 = (T0)current5.ad_object_type.Equals("campaign");
													if (val37 == null)
													{
														T0 val38 = (T0)current5.ad_object_type.Equals("ad_set");
														if (val38 != null)
														{
															val34 = (T1)((string)val34 + "\"" + current5.id + "\",");
															_ = current5.ad_object_id;
															_ = current5.id;
														}
													}
													else
													{
														val34 = (T1)((string)val34 + "\"" + current5.id + "\",");
														_ = current5.ad_object_id;
														_ = current5.id;
													}
												}
											}
											finally
											{
												((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator5))).Dispose();
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator4))).Dispose();
									}
								}
								val39 = (T0)string.IsNullOrWhiteSpace((string)val23);
							}
							while (val39 != null);
							T0 val40 = (T0)(((string)val34).Length > 0);
							if (val40 != null)
							{
								val34 = (T1)((string)val34).Remove(((string)val34).Length - 1, 1);
							}
							val34 = (T1)("[" + (string)val34 + "]");
							val34 = (T1)HttpUtility.UrlEncode((string)val34);
							T0 val41 = publishCamps<T0, T1>(val23, val34);
							T0 val42 = val41;
							if (val42 != null)
							{
								val16 = (T2)(val16 + 1);
							}
							Console.WriteLine(((bool*)(&val41))->ToString());
						}
						else
						{
							setMessage<T0, T1, T2>((T1)("TK " + (string)val19 + System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)1) + " DIE"), (T0)1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
				}
			}
			T0 val43 = (T0)frmMain.listFBEntity[indexEntity].Message.Contains("e:");
			if (val43 == null)
			{
				setMessage<T0, T1, T2>((T1)$"Camp: {val16}", (T0)1);
			}
			else
			{
				setMessage<T0, T1, T2>((T1)$"Camp: {val16}", (T0)1);
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T2>((T1)("e:" + ex.Message), (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 publishCamps<T0, T1>(T1 strAddraft, T1 strFragments)
	{
		//IL_0022: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val != null)
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
			else
			{
				httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/";
				T1 val2 = (T1)((object)httpRequest.Post(string.Concat((string[])(object)new T1[7]
				{
					(T1)"https://graph",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/v11.0/",
					strAddraft,
					(T1)"/publish?_app=ADS_MANAGER&_reqName=object%3Adraft_id%2Fpublish&access_token=",
					(T1)frmMain.listFBEntity[indexEntity].TokenEAAB,
					(T1)"&method=post&qpl_active_flow_ids=&qpl_active_flow_instance_ids=&__cppo=1"
				}), string.Concat((string[])(object)new T1[1] { (T1)("__activeScenarioIDs=%5B%22%22%5D&__activeScenarios=%5B%22review_and_publish%22%5D&__business_id=&_app=ADS_MANAGER&_reqName=object%3Adraft_id%2Fpublish&_reqSrc=AdsDraftPublishDataManager&_sessionID=&append=false&fragments=" + (string)strFragments + "&ignore_errors=true&include_fragment_statuses=true&include_headers=false&locale=en_US&method=post&pretty=0&qpl_active_flow_ids=&qpl_active_flow_instance_ids=&suppress_http_code=1&xref=") }), "application/x-www-form-urlencoded")).ToString();
				T0 val3 = (T0)((string)val2).Contains("success");
				if (val3 != null)
				{
					return (T0)1;
				}
			}
		}
		catch
		{
		}
		return (T0)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public addraft_fragments_2 getAddraftCamp_2<T0>(T0 strAtc)
	{
		try
		{
			httpRequest.KeepAlive = true;
			httpRequest.AddHeader("viewport-width", "1229");
			httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
			httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
			httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
			httpRequest.UserAgent = strUserAgentDesktop;
			httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
			httpRequest.AddHeader("Sec-Fetch-Site", "none");
			httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
			httpRequest.AddHeader("Sec-Fetch-User", "?1");
			httpRequest.AddHeader("Sec-Fetch-Dest", "document");
			httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM");
			T0 val = (T0)string.Concat((string[])(object)new T0[6]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v16.0/act_",
				(T0)((string)strAtc).Replace("act_", ""),
				(T0)"/current_addrafts?fields=addraft_fragments.summary(true).limit(500){action,ad_creation_package_config,ad_draft_id,ad_object,ad_object_id,ad_object_type,ancestor_ad_object_ids,business_folder,draft_version,fragment_type,fragment_version,id,parent_ad_object_id,publish_error,publish_status,source,status,time_created,time_updated,validation_status,values}&access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAB
			});
			T0 val2 = (T0)((object)httpRequest.Get((string)val, (RequestParams)null)).ToString();
			return JsonConvert.DeserializeObject<addraft_fragments_2>((string)val2);
		}
		catch
		{
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public adaccountsData reload_act<T0, T1>(T0 act)
	{
		adaccountsData result = null;
		try
		{
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[6]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v14.0/act_",
				(T0)((string)act).Replace("act_", ""),
				(T0)"?fields=business_country_code%2Cspend_cap%2Ccampaigns%7Bid%2Cstatus%2Cdelivery_status%7D%2Ctimezone_name%2Cid%2Cname%2Caccount_status%2Ccurrency%2Cadtrust_dsl%2Camount_spent%2Cadspaymentcycle%7Bthreshold_amount%7D%2Chas_repay_processing_invoices%2Cinvoicing_emails%2Cbalance&access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG
			}), (RequestParams)null)).ToString();
			result = JsonConvert.DeserializeObject<adaccountsData>((string)val);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 mtLoadPage<T0, T1, T2, T3>(out string strError)
	{
		//IL_007e: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		strError = "";
		try
		{
			T1 val2 = (T1)((object)httpRequest.Get("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v10.0/me?fields=facebook_pages.limit(5000){id,name,name_with_location_descriptor,category,is_restricted,has_transitioned_to_new_page_experience,followers_count,additional_profile_id,is_published}&access_token=" + frmMain.listFBEntity[indexEntity].TokenEAAG, (RequestParams)null)).ToString();
			PageEntity pageEntity = JsonConvert.DeserializeObject<PageEntity>((string)val2);
			T1 val3 = (T1)"";
			T2 val4 = (T2)(pageEntity != null && pageEntity.facebook_pages != null);
			if (val4 != null)
			{
				T2 val5 = (T2)(pageEntity.facebook_pages.data != null);
				if (val5 != null)
				{
					((List<facebook_pagesData>)val).AddRange((IEnumerable<facebook_pagesData>)pageEntity.facebook_pages.data);
				}
				T2 val6 = (T2)(pageEntity.facebook_pages.paging != null && !string.IsNullOrWhiteSpace(pageEntity.facebook_pages.paging.next));
				if (val6 != null)
				{
					val3 = (T1)pageEntity.facebook_pages.paging.next;
				}
			}
			while (true)
			{
				T2 val7 = (T2)frmMain.isRunning;
				if (val7 == null)
				{
					break;
				}
				T2 val8 = (T2)(!string.IsNullOrWhiteSpace((string)val3));
				if (val8 == null)
				{
					break;
				}
				val2 = fetch_url_business<T1, T3>(val3);
				val3 = (T1)"";
				facebook_pages facebook_pages = JsonConvert.DeserializeObject<facebook_pages>((string)val2);
				T2 val9 = (T2)(facebook_pages != null);
				if (val9 != null)
				{
					T2 val10 = (T2)(facebook_pages.data != null);
					if (val10 != null)
					{
						((List<facebook_pagesData>)val).AddRange((IEnumerable<facebook_pagesData>)facebook_pages.data);
					}
					T2 val11 = (T2)(facebook_pages.paging != null && !string.IsNullOrWhiteSpace(facebook_pages.paging.next));
					if (val11 != null)
					{
						val3 = (T1)facebook_pages.paging.next;
					}
				}
			}
		}
		catch (Exception ex)
		{
			strError = ex.Message;
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Set_limit<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Limit").ToString();
			setMessage<T0, T1, int>((T1)("Set limit: " + (string)val2), (T0)0);
			getFullAdsInfo<T1, T0>();
			T0 val3 = (T0)(frmMain.listFBEntity[indexEntity].fullAdsInfo != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data != null);
			if (val3 == null)
			{
				return;
			}
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T0 val4 = setLimit<T1, T0, int>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)current.id.Replace("act_", ""), (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, val2, (T1)current.currency);
					if (val4 == null)
					{
						setMessage<T0, T1, int>((T1)"Set limit lỗi", (T0)1);
					}
					else
					{
						setMessage<T0, T1, int>((T1)"Set limit ok", (T0)1);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, int>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void getFullAdsInfo<T0, T1>()
	{
		//IL_013b: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_0200: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Get("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v10.0/me?fields=adaccounts.limit(2000){business_country_code,spend_cap,campaigns{id,status,delivery_status},timezone_name,id,name,disable_reason,account_status,currency,adtrust_dsl,amount_spent,adspaymentcycle{threshold_amount},has_repay_processing_invoices,invoicing_emails,balance},businesses.limit(2500){name,id,permitted_roles,two_factor_type,verification_status,owned_ad_accounts{business_country_code,spend_cap,campaigns{id,status,delivery_status},timezone_name,id,name,disable_reason,account_status,currency,adtrust_dsl,amount_spent,adspaymentcycle{threshold_amount},has_repay_processing_invoices,invoicing_emails,balance},pending_users{email,invite_link,role}}&access_token=" + frmMain.listFBEntity[indexEntity].TokenEAAG, (RequestParams)null)).ToString();
			CheckInfo fullAdsInfo = JsonConvert.DeserializeObject<CheckInfo>((string)val);
			frmMain.listFBEntity[indexEntity].fullAdsInfo = fullAdsInfo;
			while (true)
			{
				T1 val2 = (T1)frmMain.isRunning;
				if (val2 != null)
				{
					T1 val3 = (T1)(frmMain.listFBEntity[indexEntity].fullAdsInfo != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging != null && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging.next));
					if (val3 != null)
					{
						T0 val4 = (T0)((object)httpRequest.Get(frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging.next, (RequestParams)null)).ToString();
						adaccounts adaccounts = JsonConvert.DeserializeObject<adaccounts>((string)val4);
						T1 val5 = (T1)(adaccounts != null && adaccounts.data != null);
						if (val5 != null)
						{
							frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.AddRange(adaccounts.data);
							frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging = adaccounts.paging;
						}
						continue;
					}
					break;
				}
				break;
			}
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tạo_Page_Nhanh<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_0175: Expected I4, but got O
		//IL_0183: Expected O, but got I4
		//IL_0194: Expected O, but got I4
		//IL_01a3: Expected O, but got I4
		//IL_01af: Expected O, but got I4
		//IL_0208: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<T5, List<FBFlowField>, T0, T1>((T1)"Page_thường").ToString());
			T1 val3 = (T1)flow.getValue<T5, List<FBFlowField>, T0, T1>((T1)"Tên_PAGE").ToString();
			T0 val4 = (T0)bool.Parse(flow.getValue<T5, List<FBFlowField>, T0, T1>((T1)"Random_tên_page").ToString());
			T1 category = (T1)flow.getValue<T5, List<FBFlowField>, T0, T1>((T1)"Loại_PAGE").ToString();
			T1 val5 = (T1)flow.getValue<T5, List<FBFlowField>, T0, T1>((T1)"BM_Cầm_Page").ToString();
			T0 val6 = (T0)bool.Parse(flow.getValue<T5, List<FBFlowField>, T0, T1>((T1)"Share_via").ToString());
			setMessage<T0, T1, T4>((T1)("Tạo page " + (string)val3), (T0)0);
			T0 val7 = val4;
			if (val7 != null)
			{
				T1 firstName = ChromeControl.getFirstName<T0, T1, T4>();
				T1 lastName = ChromeControl.getLastName<T0, T1, T4>();
				val3 = (T1)$"{(T5)System.Runtime.CompilerServices.Unsafe.As<T2, char>(ref ((IEnumerable<T2>)firstName).First()).ToString().ToUpper()}{(T5)((string)firstName).Substring(1).ToLower()} {(T5)System.Runtime.CompilerServices.Unsafe.As<T2, char>(ref ((IEnumerable<T2>)lastName).First()).ToString().ToUpper()}{(T5)((string)lastName).Substring(1).ToLower()} {(T5)(object)(T4)rnd.Next(111, 999)}";
			}
			T1 val8 = (T1)createPage(frmMain.listFBEntity[indexEntity].TokenEAAG, frmMain.listFBEntity[indexEntity].UID, (string)val3, (string)category, (byte)(int)val2 != 0);
			T0 val9 = (T0)(!string.IsNullOrWhiteSpace((string)val8));
			if (val9 == null)
			{
				setMessage<T0, T1, T4>((T1)"e:Tạo page lỗi", (T0)1);
				return;
			}
			setMessage<T0, T1, T4>((T1)"Tạo page Ok", (T0)1);
			T0 val10 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
			if (val10 != null)
			{
				sharePage((T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)frmMain.listFBEntity[indexEntity].UID, val8, val5);
			}
			T0 val11 = val6;
			if (val11 != null)
			{
				SharePage<T0, List<TokenEntity>.Enumerator, T1, T4, T3, HttpRequest>(val8, (T0)(val2 == null));
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T4>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 sharePage<T0>(T0 TokenEAAG, T0 UID, T0 pageId, T0 BM_Cầm_Page)
	{
		try
		{
			((object)httpRequest.Post("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v14.0/{pageId}/agencies?access_token={TokenEAAG}&__cppo=1", string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Apage%2Fagencies&_reqSrc=BrandAgencyActions.brands&acting_brand_id=730967675052459&business=",
				BM_Cầm_Page,
				(T0)"&locale=en_US&method=post&pageId=",
				pageId,
				(T0)"&permitted_tasks=%5B%22PROFILE_PLUS_CREATE_CONTENT%22%2C%22PROFILE_PLUS_MODERATE%22%2C%22PROFILE_PLUS_MESSAGING%22%2C%22PROFILE_PLUS_ADVERTISE%22%2C%22PROFILE_PLUS_ANALYZE%22%2C%22PROFILE_PLUS_FACEBOOK_ACCESS%22%5D&pretty=0&suppress_http_code=1&xref=f1b213778f9628c"
			}) }), "application/x-www-form-urlencoded")).ToString();
		}
		catch
		{
		}
		try
		{
			T0 val = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Apage%2Fagencies&_reqSrc=BrandAgencyActions.brands&acting_brand_id=730967675052459&business=",
				BM_Cầm_Page,
				(T0)"&locale=en_US&method=post&pageId=",
				pageId,
				(T0)"&permitted_tasks=%5B%22CREATE_CONTENT%22%2C%22MODERATE%22%2C%22MESSAGING%22%2C%22ADVERTISE%22%2C%22ANALYZE%22%2C%22MANAGE%22%2C%22VIEW_MONETIZATION_INSIGHTS%22%5D&pretty=0&suppress_http_code=1&xref=f1b213778f9628c"
			});
			((object)httpRequest.Post(string.Concat((string[])(object)new T0[5]
			{
				(T0)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
				pageId,
				(T0)"/agencies?access_token=",
				TokenEAAG,
				(T0)"&__cppo=1"
			}), string.Concat((string[])(object)new T0[1] { val }), "application/x-www-form-urlencoded")).ToString();
		}
		catch
		{
		}
		return pageId;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Hoàn_thành<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Lưu_cookies").ToString());
			T0 val3 = (T0)(val2 != null && isLogined);
			if (val3 != null)
			{
				T1 val4 = (T1)"";
				T2 enumerator = (T2)((Dictionary<string, string>)(object)httpRequest.Cookies).GetEnumerator();
				try
				{
					while (((Dictionary<string, string>.Enumerator*)(&enumerator))->MoveNext())
					{
						T3 current = (T3)((Dictionary<string, string>.Enumerator*)(&enumerator))->Current;
						val4 = (T1)string.Concat((string[])(object)new T1[5]
						{
							val4,
							(T1)((KeyValuePair<string, string>*)(&current))->Key,
							(T1)"=",
							(T1)((KeyValuePair<string, string>*)(&current))->Value,
							(T1)";"
						});
					}
				}
				finally
				{
					((IDisposable)(*(Dictionary<string, string>.Enumerator*)(&enumerator))).Dispose();
				}
				frmMain.listFBEntity[indexEntity].Cookie = (string)val4;
			}
			updateStatus<T0, int, T1>((T0)1);
		}
		catch (Exception ex)
		{
			Thread.Sleep(1500);
			setMessage<T0, T1, int>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Đăng_bài_vào_nhóm<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_01df: Expected O, but got I4
		//IL_01f7: Expected O, but got I4
		//IL_01fa: Expected O, but got I4
		//IL_0270: Expected O, but got I4
		//IL_02b3: Expected O, but got I4
		//IL_0335: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		//IL_049e: Expected O, but got I4
		//IL_04b2: Expected O, but got I4
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected I4, but got Unknown
		//IL_05ec: Expected O, but got I4
		//IL_05fe: Expected O, but got I4
		//IL_060d: Expected O, but got I4
		//IL_0771: Expected O, but got I4
		//IL_079a: Expected O, but got I4
		//IL_07a9: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d0: Expected O, but got Unknown
		//IL_07ef: Expected O, but got I4
		//IL_0833: Expected O, but got I4
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_084c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Expected I4, but got Unknown
		//IL_0852: Expected I4, but got Unknown
		//IL_0892: Expected O, but got I4
		//IL_08a4: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_nhóm").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Nhóm_mới").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Nhóm_không_kiểm_duyệt").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Nhóm_kiểm_duyệt").ToString());
			T1 val6 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Nghỉ_sửa_bài_mồi").ToString());
			string strComment = flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Bài_đăng_mồi").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(strComment))).First();
			T2 comment = (T2)categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)].Comment;
			comment = frmMain.Spin_String<T2, T6, T0, T7>(comment);
			strComment = flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Nội_dung").ToString();
			categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(strComment))).First();
			T2 comment2 = (T2)categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)].Comment;
			comment2 = frmMain.Spin_String<T2, T6, T0, T7>(comment2);
			T0 val7 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Đăng_bài_mồi").ToString());
			T0 val8 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Bài_live_stream").ToString());
			T2 val9 = (T2)"22";
			T0 val10 = val8;
			if (val10 != null)
			{
				val9 = (T2)"11";
			}
			T2 val11 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"ID_bài_viết").ToString();
			T1 val12 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val13 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T1 val14 = (T1)0;
			int GroupStatus = 0;
			T0 val15 = val3;
			if (val15 == null)
			{
				T0 val16 = val4;
				if (val16 != null)
				{
					GroupStatus = 2;
				}
				else
				{
					T0 val17 = val5;
					if (val17 != null)
					{
						GroupStatus = 3;
					}
				}
			}
			else
			{
				GroupStatus = 0;
			}
			T3 val18 = (T3)((IEnumerable<GroupItem>)frmMain.listFBEntity[indexEntity].ListGroup).Where((Func<GroupItem, bool>)((GroupItem a) => (T0)(a.Status == GroupStatus && !a.isShared))).ToList();
			T0 val19 = (T0)(((List<GroupItem>)val18).Count < (nint)val2);
			if (val19 != null)
			{
				T4 enumerator = (T4)frmMain.listFBEntity[indexEntity].ListGroup.GetEnumerator();
				try
				{
					while (((List<GroupItem>.Enumerator*)(&enumerator))->MoveNext())
					{
						GroupItem current = ((List<GroupItem>.Enumerator*)(&enumerator))->Current;
						T0 val20 = (T0)(current.Status == GroupStatus);
						if (val20 != null)
						{
							current.isShared = false;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<GroupItem>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			val18 = (T3)((IEnumerable<GroupItem>)frmMain.listFBEntity[indexEntity].ListGroup).Where((Func<GroupItem, bool>)((GroupItem a) => (T0)(a.Status == GroupStatus && !a.isShared))).ToList();
			T4 enumerator2 = (T4)((List<GroupItem>)val18).GetEnumerator();
			try
			{
				while (((List<GroupItem>.Enumerator*)(&enumerator2))->MoveNext())
				{
					GroupItem current2 = ((List<GroupItem>.Enumerator*)(&enumerator2))->Current;
					current2.isShared = true;
					T2 val21 = (T2)"";
					T0 val22 = (T0)0;
					T0 val23 = val7;
					if (val23 != null)
					{
						T2 val24 = (T2)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T2[1] { (T2)string.Concat((string[])(object)new T2[13]
						{
							(T2)"av=",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"&__user=",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"&__a=1&__dyn=&__csr=&__req=&__hs=19051.HYP%3Acomet_pkg.2.1.0.2.&dpr=1&__ccg=EXCELLENT&__rev=&__s=x6b7xl%3Aix5qx7%3Apozmbu&__hsi=&__comet_req=1&fb_dtsg=",
							(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T2)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ComposerStoryCreateMutation&variables=%7B%22input%22%3A%7B%22composer_entry_point%22%3A%22inline_composer%22%2C%22composer_source_surface%22%3A%22group%22%2C%22composer_type%22%3A%22group%22%2C%22logging%22%3A%7B%22composer_session_id%22%3A%22%22%7D%2C%22source%22%3A%22WWW%22%2C%22attachments%22%3A%5B%5D%2C%22message%22%3A%7B%22ranges%22%3A%5B%5D%2C%22text%22%3A%22",
							comment,
							(T2)"%22%7D%2C%22with_tags_ids%22%3A%5B%5D%2C%22inline_activities%22%3A%5B%5D%2C%22explicit_place_id%22%3A%220%22%2C%22text_format_preset_id%22%3A%220%22%2C%22tracking%22%3A%5Bnull%5D%2C%22audience%22%3A%7B%22to_id%22%3A%22",
							(T2)current2.Group_Id,
							(T2)"%22%7D%2C%22actor_id%22%3A%22",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"%22%2C%22client_mutation_id%22%3A%222%22%7D%2C%22displayCommentsFeedbackContext%22%3Anull%2C%22displayCommentsContextEnableComment%22%3Anull%2C%22displayCommentsContextIsAdPreview%22%3Anull%2C%22displayCommentsContextIsAggregatedShare%22%3Anull%2C%22displayCommentsContextIsStorySet%22%3Anull%2C%22feedLocation%22%3A%22GROUP%22%2C%22feedbackSource%22%3A0%2C%22focusCommentID%22%3Anull%2C%22gridMediaWidth%22%3Anull%2C%22scale%22%3A1%2C%22privacySelectorRenderLocation%22%3A%22COMET_STREAM%22%2C%22renderLocation%22%3A%22group%22%2C%22useDefaultActor%22%3Afalse%2C%22inviteShortLinkKey%22%3Anull%2C%22isFeed%22%3Afalse%2C%22isFundraiser%22%3Afalse%2C%22isFunFactPost%22%3Afalse%2C%22isGroup%22%3Atrue%2C%22isTimeline%22%3Afalse%2C%22isSocialLearning%22%3Afalse%2C%22isPageNewsFeed%22%3Afalse%2C%22isProfileReviews%22%3Afalse%2C%22isWorkSharedDraft%22%3Afalse%2C%22UFI2CommentsProvider_commentsKey%22%3A%22CometGroupDiscussionRootSuccessQuery%22%2C%22useCometPhotoViewerPlaceholderFrag%22%3Atrue%2C%22hashtag%22%3Anull%2C%22canUserManageOffers%22%3Afalse%7D&server_timestamps=true&doc_id=5050998961589306"
						}) }), "application/x-www-form-urlencoded")).ToString();
						val21 = (T2)Regex.Match((string)val24, "id\":\"(.*?)\"").Groups[1].Value;
						T0 val25 = (T0)(!string.IsNullOrWhiteSpace((string)val21));
						if (val25 != null)
						{
							T0 val26 = (T0)((GroupStatus == 0 || GroupStatus == 2) && ((string)val24).Contains("/pending_posts"));
							if (val26 == null)
							{
								setMessage<T0, T2, T1>((T2)"Delay sửa bài", (T0)1);
								Thread.Sleep(val6 * 1000);
								T2 val27 = (T2)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T2[1] { (T2)string.Concat((string[])(object)new T2[17]
								{
									(T2)"av=",
									(T2)frmMain.listFBEntity[indexEntity].UID,
									(T2)"&__user=",
									(T2)frmMain.listFBEntity[indexEntity].UID,
									(T2)"&__a=1&__dyn=&__csr=&__req=24&__hs=19051.HYP%3Acomet_pkg.2.1.0.2.&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=1&fb_dtsg=",
									(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
									(T2)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ComposerStoryEditMutation&variables=%7B%22input%22%3A%7B%22composer_entry_point%22%3A%22inline_composer%22%2C%22composer_source_surface%22%3A%22group%22%2C%22composer_type%22%3A%22edit%22%2C%22logging%22%3A%7B%22composer_session_id%22%3A%22%22%7D%2C%22story_id%22%3A%22",
									val21,
									(T2)"%22%2C%22attachments%22%3A%5B%7B%22link%22%3A%7B%22share_scrape_data%22%3A%22%7B%5C%22share_type%5C%22%3A",
									val9,
									(T2)"%2C%5C%22share_params%5C%22%3A%5B",
									val11,
									(T2)"%5D%7D%22%7D%7D%5D%2C%22message%22%3A%7B%22ranges%22%3A%5B%5D%2C%22text%22%3A%22",
									comment2,
									(T2)"%22%7D%2C%22with_tags_ids%22%3A%5B%5D%2C%22inline_activities%22%3A%5B%5D%2C%22explicit_place_id%22%3A%220%22%2C%22text_format_preset_id%22%3A%220%22%2C%22editable_post_feature_capabilities%22%3A%5B%22CONTAINED_LINK%22%2C%22CONTAINED_MEDIA%22%2C%22POLL%22%5D%2C%22actor_id%22%3A%22",
									(T2)frmMain.listFBEntity[indexEntity].UID,
									(T2)"%22%2C%22client_mutation_id%22%3A%222%22%7D%2C%22displayCommentsFeedbackContext%22%3Anull%2C%22displayCommentsContextEnableComment%22%3Anull%2C%22displayCommentsContextIsAdPreview%22%3Anull%2C%22displayCommentsContextIsAggregatedShare%22%3Anull%2C%22displayCommentsContextIsStorySet%22%3Anull%2C%22feedLocation%22%3A%22GROUP%22%2C%22feedbackSource%22%3A1%2C%22focusCommentID%22%3Anull%2C%22scale%22%3A1%2C%22privacySelectorRenderLocation%22%3A%22COMET_STREAM%22%2C%22renderLocation%22%3A%22group%22%2C%22useDefaultActor%22%3Afalse%2C%22UFI2CommentsProvider_commentsKey%22%3Anull%2C%22isGroupViewerContent%22%3Afalse%2C%22isSocialLearning%22%3Afalse%2C%22isWorkDraftFor%22%3Afalse%7D&server_timestamps=true&doc_id=4822577157796111"
								}) }), "application/x-www-form-urlencoded")).ToString();
								T0 val28 = (T0)((string)val27).Contains((string)val21);
								if (val28 != null)
								{
									T0 val29 = (T0)(GroupStatus == 0);
									if (val29 != null)
									{
										current2.Status = 2;
									}
									val22 = (T0)1;
								}
							}
							else
							{
								current2.Status = 3;
							}
						}
					}
					else
					{
						T2 val30 = (T2)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T2[1] { (T2)string.Concat((string[])(object)new T2[17]
						{
							(T2)"av=",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"&__user=",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"&__a=1&__dyn=&__csr=&__req=&__hs=19051.HYP%3Acomet_pkg.2.1.0.2.&dpr=1&__ccg=EXCELLENT&__rev=&__s=x6b7xl%3Aix5qx7%3Apozmbu&__hsi=&__comet_req=1&fb_dtsg=",
							(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T2)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ComposerStoryCreateMutation&variables=%7B%22input%22%3A%7B%22composer_entry_point%22%3A%22inline_composer%22%2C%22composer_source_surface%22%3A%22group%22%2C%22composer_type%22%3A%22group%22%2C%22logging%22%3A%7B%22composer_session_id%22%3A%22%22%7D%2C%22source%22%3A%22WWW%22%2C%22attachments%22%3A%5B%7B%22link%22%3A%7B%22share_scrape_data%22%3A%22%7B%5C%22share_type%5C%22%3A",
							val9,
							(T2)"%2C%5C%22share_params%5C%22%3A%5B",
							val11,
							(T2)"%5D%7D%22%7D%7D%5D%2C%22message%22%3A%7B%22ranges%22%3A%5B%5D%2C%22text%22%3A%22",
							comment2,
							(T2)"%22%7D%2C%22with_tags_ids%22%3A%5B%5D%2C%22inline_activities%22%3A%5B%5D%2C%22explicit_place_id%22%3A%220%22%2C%22text_format_preset_id%22%3A%220%22%2C%22tracking%22%3A%5Bnull%5D%2C%22audience%22%3A%7B%22to_id%22%3A%22",
							(T2)current2.Group_Id,
							(T2)"%22%7D%2C%22actor_id%22%3A%22",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"%22%2C%22client_mutation_id%22%3A%222%22%7D%2C%22displayCommentsFeedbackContext%22%3Anull%2C%22displayCommentsContextEnableComment%22%3Anull%2C%22displayCommentsContextIsAdPreview%22%3Anull%2C%22displayCommentsContextIsAggregatedShare%22%3Anull%2C%22displayCommentsContextIsStorySet%22%3Anull%2C%22feedLocation%22%3A%22GROUP%22%2C%22feedbackSource%22%3A0%2C%22focusCommentID%22%3Anull%2C%22gridMediaWidth%22%3Anull%2C%22scale%22%3A1%2C%22privacySelectorRenderLocation%22%3A%22COMET_STREAM%22%2C%22renderLocation%22%3A%22group%22%2C%22useDefaultActor%22%3Afalse%2C%22inviteShortLinkKey%22%3Anull%2C%22isFeed%22%3Afalse%2C%22isFundraiser%22%3Afalse%2C%22isFunFactPost%22%3Afalse%2C%22isGroup%22%3Atrue%2C%22isTimeline%22%3Afalse%2C%22isSocialLearning%22%3Afalse%2C%22isPageNewsFeed%22%3Afalse%2C%22isProfileReviews%22%3Afalse%2C%22isWorkSharedDraft%22%3Afalse%2C%22UFI2CommentsProvider_commentsKey%22%3A%22CometGroupDiscussionRootSuccessQuery%22%2C%22useCometPhotoViewerPlaceholderFrag%22%3Atrue%2C%22hashtag%22%3Anull%2C%22canUserManageOffers%22%3Afalse%7D&server_timestamps=true&doc_id=5050998961589306"
						}) }), "application/x-www-form-urlencoded")).ToString();
						val21 = (T2)Regex.Match((string)val30, "id\":\"(.*?)\"").Groups[1].Value;
						T0 val31 = (T0)(!string.IsNullOrWhiteSpace((string)val21));
						if (val31 != null)
						{
							T0 val32 = (T0)((GroupStatus == 0 || GroupStatus == 2) && ((string)val30).Contains("/pending_posts"));
							if (val32 == null)
							{
								T0 val33 = (T0)(GroupStatus == 0);
								if (val33 != null)
								{
									current2.Status = 2;
								}
								val22 = (T0)1;
							}
							else
							{
								current2.Status = 3;
							}
						}
					}
					T0 val34 = val22;
					if (val34 != null)
					{
						val14 = (T1)(val14 + 1);
						setMessage<T0, T2, T1>((T2)$"Share {val14}/{val2}", (T0)1);
						frmMain.listFBEntity[indexEntity].GroupShared.Add(new GroupShared
						{
							Group_Id = current2.Group_Id,
							Post_Id = (string)val21
						});
					}
					T0 val35 = (T0)(val14 >= val2);
					if (val35 == null)
					{
						Thread.Sleep(rnd.Next(val12 * 1000, val13 * 1000));
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)(*(List<GroupItem>.Enumerator*)(&enumerator2))).Dispose();
			}
			setMessage<T0, T2, T1>((T2)$"Share {val14}/{val2}", (T0)1);
		}
		catch (Exception ex)
		{
			setMessage<T0, T2, T1>((T2)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Hủy_tham_gia_nhóm<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0200: Expected I4, but got O
		//IL_0244: Expected I4, but got O
		//IL_027c: Expected I4, but got O
		//IL_0288: Expected O, but got I4
		//IL_02ae: Expected I4, but got O
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02d3: Expected O, but got I4
		//IL_02dd: Expected O, but got I4
		//IL_02f5: Expected O, but got I4
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected I4, but got Unknown
		//IL_0312: Expected I4, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_0329: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Số_nhóm").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Nhóm_mới").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Nhóm_không_kiểm_duyệt").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Nhóm_kiểm_duyệt").ToString());
			T0 val6 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Nhóm_khóa").ToString());
			T1 val7 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Delay_From").ToString());
			T1 val8 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Delay_To").ToString());
			int GroupStatus = 0;
			T0 val9 = val3;
			if (val9 != null)
			{
				GroupStatus = 0;
			}
			else
			{
				T0 val10 = val4;
				if (val10 == null)
				{
					T0 val11 = val5;
					if (val11 != null)
					{
						GroupStatus = 3;
					}
					else
					{
						T0 val12 = val6;
						if (val12 != null)
						{
							GroupStatus = 1;
						}
					}
				}
				else
				{
					GroupStatus = 2;
				}
			}
			T2 val13 = (T2)((IEnumerable<GroupItem>)frmMain.listFBEntity[indexEntity].ListGroup).Where((Func<GroupItem, bool>)((GroupItem a) => (T0)(a.Status == GroupStatus && !a.isShared))).ToList();
			T1 val14 = (T1)0;
			T1 val15 = (T1)(((List<GroupItem>)val13).Count - 1);
			while (true)
			{
				T0 val16 = (T0)((nint)val15 >= 0);
				if (val16 == null)
				{
					break;
				}
				try
				{
					T3 val17 = (T3)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T3[1] { (T3)string.Concat((string[])(object)new T3[13]
					{
						(T3)"av=",
						(T3)frmMain.listFBEntity[indexEntity].UID,
						(T3)"&__user=",
						(T3)frmMain.listFBEntity[indexEntity].UID,
						(T3)"&__a=1&__dyn=&__csr=&__req=3d&__hs=19056.HYP%3Acomet_pkg.2.1.0.2.&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=1&fb_dtsg=",
						(T3)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T3)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=GroupCometLeaveForumMutation&variables=%7B%22imageMediaType%22%3A%22image%2Fx-auto%22%2C%22input%22%3A%7B%22group_id%22%3A%22",
						(T3)((List<GroupItem>)val13)[(int)val15].Group_Id,
						(T3)"%22%2C%22actor_id%22%3A%22",
						(T3)frmMain.listFBEntity[indexEntity].UID,
						(T3)"%22%2C%22client_mutation_id%22%3A%223%22%7D%2C%22inviteShortLinkKey%22%3Anull%2C%22isChainingRecommendationUnit%22%3Afalse%2C%22isNextGenIAEnabled%22%3Afalse%2C%22prefetchGroupsHeaderFacepile%22%3Atrue%2C%22scale%22%3A1%2C%22groupID%22%3A%22",
						(T3)((List<GroupItem>)val13)[(int)val15].Group_Id,
						(T3)"%22%7D&server_timestamps=true&doc_id=4862353793883353"
					}) }), "application/x-www-form-urlencoded")).ToString();
					T0 val18 = (T0)((string)val17).Contains(((List<GroupItem>)val13)[(int)val15].Group_Id);
					if (val18 != null)
					{
						frmMain.listFBEntity[indexEntity].ListGroup.RemoveAt((int)val15);
						val14 = (T1)(val14 + 1);
						setMessage<T0, T3, T1>((T3)$"Leave: {val14}/{val2}", (T0)1);
					}
					T0 val19 = (T0)(val14 >= val2);
					if (val19 != null)
					{
						break;
					}
				}
				catch (Exception ex)
				{
					setMessage<T0, T3, T1>((T3)ex.Message, (T0)1);
				}
				Thread.Sleep(rnd.Next(val7 * 1000, val8 * 1000));
				val15 = (T1)(val15 - 1);
			}
			mtUpdateGroup<T3, T0, List<GroupAPI_edges>.Enumerator, T4, T2>((T0)0);
		}
		catch (Exception ex2)
		{
			setMessage<T0, T3, T1>((T3)ex2.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tham_gia_nhóm<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_008a: Expected I4, but got O
		//IL_00a6: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00c6: Expected O, but got I4
		//IL_00de: Expected I4, but got O
		//IL_0109: Expected I4, but got O
		//IL_01ee: Expected I4, but got O
		//IL_0213: Expected I4, but got O
		//IL_0278: Expected O, but got I4
		//IL_028e: Expected I4, but got O
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02c8: Expected O, but got I4
		//IL_02dc: Expected I4, but got O
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected I4, but got Unknown
		//IL_032c: Expected I4, but got Unknown
		//IL_0360: Expected O, but got I4
		//IL_0367: Expected O, but got I4
		//IL_0372: Expected O, but got I4
		//IL_0384: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_nhóm_tham_gia").ToString());
			T1 val3 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val4 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T1 val5 = (T1)0;
			T1 val6 = (T1)0;
			while (true)
			{
				T0 val7 = (T0)(frmMain.isRunning && val6 < val2);
				if (val7 == null)
				{
					break;
				}
				try
				{
					T1 val8 = (T1)0;
					T1 val9 = (T1)0;
					while (true)
					{
						T0 val10 = (T0)((nint)val9 < frmMain.listGroupEntity.Count);
						if (val10 != null)
						{
							T0 val11 = (T0)frmMain.listGroupEntity[(int)val9].Status.Equals(frmListGroupToJoin.STATUS.Ready.ToString());
							if (val11 == null)
							{
								val9 = (T1)(val9 + 1);
								continue;
							}
							frmMain.listGroupEntity[(int)val9].Status = frmListGroupToJoin.STATUS.Processing.ToString();
							val8 = val9;
							break;
						}
						break;
					}
					frmMain.listGroupEntity[(int)val8].UID = frmMain.listFBEntity[indexEntity].UID;
					T2 val12 = (T2)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T2[1] { (T2)string.Concat((string[])(object)new T2[15]
					{
						(T2)"av=",
						(T2)frmMain.listFBEntity[indexEntity].UID,
						(T2)"&__user=",
						(T2)frmMain.listFBEntity[indexEntity].UID,
						(T2)"&__a=1&__dyn=&__csr=&__req=w&__hs=&dpr=1&__ccg=GOOD&__rev=&__s=&__hsi=&__comet_req=1&fb_dtsg=",
						(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T2)"&jazoest=&lsd=",
						(T2)lsd,
						(T2)"&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=GroupCometJoinForumMutation&variables=%7B%22feedType%22%3A%22DISCUSSION%22%2C%22groupID%22%3A%22",
						(T2)frmMain.listGroupEntity[(int)val8].GroupId,
						(T2)"%22%2C%22imageMediaType%22%3A%22image%2Fx-auto%22%2C%22input%22%3A%7B%22group_id%22%3A%22",
						(T2)frmMain.listGroupEntity[(int)val8].GroupId,
						(T2)"%22%2C%22group_share_tracking_params%22%3A%7B%22app_id%22%3A%222220391788200892%22%2C%22exp_id%22%3Anull%2C%22is_from_share%22%3Afalse%7D%2C%22source%22%3A%22group_mall%22%2C%22actor_id%22%3A%22",
						(T2)frmMain.listFBEntity[indexEntity].UID,
						(T2)"%22%2C%22client_mutation_id%22%3A%221%22%7D%2C%22inviteShortLinkKey%22%3Anull%2C%22isChainingRecommendationUnit%22%3Afalse%2C%22isNextGenIAEnabled%22%3Afalse%2C%22prefetchGroupsHeaderFacepile%22%3Atrue%2C%22scale%22%3A1%2C%22source%22%3A%22GROUP_MALL%22%2C%22renderLocation%22%3A%22group_mall%22%7D&server_timestamps=true&doc_id=4886515911434996&fb_api_analytics_tags=%5B%22qpl_active_flow_ids%3D431626709%22%5D"
					}) }), "application/x-www-form-urlencoded")).ToString();
					T0 val13 = (T0)((string)val12).Contains("group_referral_post_attachment");
					if (val13 != null)
					{
						frmMain.listGroupEntity[(int)val8].Status = frmListGroupToJoin.STATUS.Joined.ToString();
						val5 = (T1)(val5 + 1);
						setMessage<T0, T2, T1>((T2)$"Joined: {val5}/{val2}", (T0)1);
					}
					else
					{
						frmMain.listGroupEntity[(int)val8].Status = frmListGroupToJoin.STATUS.lỗi.ToString();
					}
					val6 = (T1)(val6 + 1);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				Thread.Sleep(rnd.Next(val3 * 1000, val4 * 1000));
			}
			frmMain.saveListGroupId();
			setMessage<T0, T2, T1>((T2)$"Joined: {val5}/{val2}", (T0)1);
			T0 val14 = (T0)((nint)val5 > 0);
			if (val14 != null)
			{
				mtUpdateGroup<T2, T0, List<GroupAPI_edges>.Enumerator, T3, List<GroupItem>>((T0)0);
			}
		}
		catch (Exception ex2)
		{
			setMessage<T0, T2, T1>((T2)ex2.Message, (T0)1);
		}
	}

	public T0 getUseragent<T0>()
	{
		return (T0)listUserAgent[rnd.Next(0, listUserAgent.Count - 1)];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Đăng_nhập<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00c6: Expected I4, but got O
		//IL_00e3: Expected O, but got I4
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0133: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0176: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_0224: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_024b: Expected O, but got I4
		//IL_02d1: Expected O, but got I4
		//IL_0315: Expected O, but got I4
		//IL_035f: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
		//IL_0423: Expected O, but got I4
		//IL_0435: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Update_User_Agent").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Cookie").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Cập_nhật_nhóm").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Khóa_nhóm").ToString());
			T1 val6 = (T1)"";
			T0 val7 = val2;
			if (val7 != null)
			{
				T0 val8 = (T0)(frmMain.listUserAgent.Count > 1);
				if (val8 != null)
				{
					T2 val9 = (T2)rnd.Next(0, frmMain.listUserAgent.Count - 1);
					val6 = (T1)frmMain.listUserAgent[(int)val9].UserAgent;
					httpRequest.UserAgent = (string)val6;
				}
			}
			T0 val10 = (T0)string.IsNullOrWhiteSpace((string)val6);
			if (val10 != null)
			{
				httpRequest.UserAgent = Http.FirefoxUserAgent();
			}
			httpRequest.Cookies = new CookieDictionary(false);
			T0 val11 = (T0)(val3 != null && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Cookie));
			if (val11 != null)
			{
				T0 val12 = loginByCookies<T2, T1, T0, char>();
				if (val12 != null)
				{
					isLogined = true;
				}
				else
				{
					setMessage<T0, T1, T2>((T1)"Đăng nhập lỗi", (T0)1);
				}
			}
			else
			{
				T2 val13 = (T2)0;
				while (true)
				{
					frmMain.listFBEntity[indexEntity].fb_dtsg = (string)Login<T1, T0, T2, char, T3, byte>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].Password, (T1)frmMain.listFBEntity[indexEntity].Code2FA, (T2)0, (T2)0);
					T0 val14 = (T0)(frmMain.listFBEntity[indexEntity].fb_dtsg.Length > 20);
					if (val14 == null)
					{
						val13 = (T2)(val13 + 1);
						T0 val15 = (T0)((nint)val13 >= 3);
						if (val15 == null)
						{
							setMessage<T0, T1, T2>((T1)"Đăng nhập lại", (T0)1);
							continue;
						}
						setMessage<T0, T1, T2>((T1)"Đăng nhập lỗi", (T0)1);
						break;
					}
					isLogined = true;
					break;
				}
			}
			T0 val16 = (T0)isLogined;
			if (val16 != null)
			{
				acceptCookie<T0, T1>();
				login_success_1<T0, T1>();
				acceptPolicy_3<T1, T3, T0>();
				bat_che_do_chuyen_nghiep<T0, T2, T1>();
				getTokenEAAG<T1, T0, T2, T3, byte, char>();
				getTokenEAAG_EEAB<T2, HttpRequest, T1, T0>();
				((object)httpRequest.Get("https://m" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/composer/ocelot/async_loader/?publisher=feed", (RequestParams)null)).ToString();
				acceptPolicy_3<T1, T3, T0>();
				T0 val17 = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].UID);
				if (val17 != null)
				{
					getUID<T1, T0>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				}
				T0 val18 = (T0)((object)val4 | (object)val5);
				if (val18 != null)
				{
					mtUpdateGroup<T1, T0, List<GroupAPI_edges>.Enumerator, T3, List<GroupItem>>(val5);
				}
				setMessage<T0, T1, T2>((T1)"", (T0)1);
				T0 val19 = (T0)(string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG) && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB));
				if (val19 != null)
				{
					frmMain.listFBEntity[indexEntity].TokenEAAG = frmMain.listFBEntity[indexEntity].TokenEAAB;
				}
				T0 val20 = (T0)(!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG) && string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB));
				if (val20 != null)
				{
					frmMain.listFBEntity[indexEntity].TokenEAAB = frmMain.listFBEntity[indexEntity].TokenEAAG;
				}
			}
			else
			{
				updateStatus<T0, T2, T1>((T0)0);
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T2>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 acceptCookie<T0, T1>()
	{
		//IL_0002: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			((object)httpRequest.Get("https://www.facebook.com/privacy/consent/user_cookie_choice/?source=pft_user_cookie_choice", (RequestParams)null)).ToString();
			Thread.Sleep(300);
			((object)httpRequest.Get("https://www.facebook.com/privacy/consent/user_cookie_choice/?source=pft_user_cookie_choice", (RequestParams)null)).ToString();
			httpRequest.Referer = "https://www." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/profile.php?id=" + frmMain.listFBEntity[indexEntity].UID;
			T1 resouce = (T1)ResouceControl.getResouce("RESOUCE_API_GRAPHQL");
			T1 val = (T1)string.Concat((string[])(object)new T1[15]
			{
				(T1)"av=",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"&__user=",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"&__a=1&__dyn=7xeUmwlE7ibwKBWo2vwAxu13w8CewSwMwNw9G2S0im3y4o0B-q1ew65xO0FE2awt81sbzo5-0Boy1PwBgao6C0Mo5W3S1lwlEjxG1Pxi4UaEW0D888cobEaU2eU5O0HUvw4JwJwSyES0gq0Lo4K2e1Fw&__csr=gVdsIjppFeRVWO5Klal4zp8kyFouUqK6FUao5S7o6a0ne0PU3Vw6Yw05Lrguwjo&__req=9&__hs=19186.HYP%3Acomet_plat_default_pkg.2.1.0.2.0&dpr=1&__ccg=EXCELLENT&__rev=",
				(T1)frmMain.listFBEntity[indexEntity].__spin_r,
				(T1)"&__s=%3A%3A0c43hk&__hsi=7119690519708346852&__comet_req=1&fb_dtsg=",
				(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T1)"&jazoest=25527&lsd=_z4X9gBhos6-ou6ErL7uQ-&__spin_r=",
				(T1)frmMain.listFBEntity[indexEntity].__spin_r,
				(T1)"&__spin_b=trunk&__spin_t=",
				(T1)frmMain.listFBEntity[indexEntity].__spin_t,
				(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useCometConsentPromptOutcomeBatchedMutation&variables=%7B%22input%22%3A%7B%22config_enum%22%3A%22USER_COOKIE_CHOICE_FRENCH_CNIL%22%2C%22extra_params_json%22%3A%22%7B%7D%22%2C%22flow_step_type%22%3A%22STANDALONE%22%2C%22outcome%22%3A%22APPROVED%22%2C%22server_on_complete_params_darray_json%22%3A%22%7B%5C%22first_party_trackers_on_foa%5C%22%3A%5C%22true%5C%22%2C%5C%22fb_trackers_on_other_companies%5C%22%3A%5C%22false%5C%22%2C%5C%22other_company_trackers_on_foa%5C%22%3A%5C%22false%5C%22%7D%22%2C%22source%22%3A%22pft_user_cookie_choice%22%2C%22surface%22%3A%22FACEBOOK_COMET%22%2C%22actor_id%22%3A%22",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"%22%2C%22client_mutation_id%22%3A%222%22%7D%7D&server_timestamps=true&doc_id=5733973206629812"
			});
			((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T1[1] { val }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.Referer = "https://www." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/profile.php?id=" + frmMain.listFBEntity[indexEntity].UID;
			resouce = (T1)ResouceControl.getResouce("RESOUCE_API_GRAPHQL");
			val = (T1)string.Concat((string[])(object)new T1[15]
			{
				(T1)"av=",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"&__user=",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"&__a=1&__dyn=7xeUmwlE7ibwKBWo2vwAxu13w8CewSwMwNw9G2S0im3y4o0B-q1ew65xO0FE2awt81sbzo5-0Boy1PwBgao6C0Mo5W3S1lwlEjxG1Pxi4UaEW0D888cobEaU2eU5O0HUvw4JwJwSyES0gq0Lo4K2e1Fw&__csr=gVdsIjppFeRVWO5Klal4zp8kyFouUqK6FUao5S7o6a0ne0PU3Vw6Yw05Lrguwjo&__req=a&__hs=19186.HYP%3Acomet_plat_default_pkg.2.1.0.2.0&dpr=1&__ccg=EXCELLENT&__rev=",
				(T1)frmMain.listFBEntity[indexEntity].__spin_r,
				(T1)"&__s=%3A%3A0c43hk&__hsi=7119690519708346852&__comet_req=1&fb_dtsg=",
				(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T1)"&jazoest=25527&lsd=_z4X9gBhos6-ou6ErL7uQ-&__spin_r=",
				(T1)frmMain.listFBEntity[indexEntity].__spin_r,
				(T1)"&__spin_b=trunk&__spin_t=",
				(T1)frmMain.listFBEntity[indexEntity].__spin_t,
				(T1)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useCometConsentPromptEndOfFlowBatchedMutation&variables=%7B%22input%22%3A%7B%22config_enum%22%3A%22USER_COOKIE_CHOICE_FRENCH_CNIL%22%2C%22extra_params_json%22%3A%22%7B%7D%22%2C%22flow_step_type%22%3A%22STANDALONE%22%2C%22outcome%22%3A%22APPROVED%22%2C%22source%22%3A%22pft_user_cookie_choice%22%2C%22surface%22%3A%22FACEBOOK_COMET%22%2C%22actor_id%22%3A%22",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"%22%2C%22client_mutation_id%22%3A%223%22%7D%7D&server_timestamps=true&doc_id=4943422439028807"
			});
			((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T1[1] { val }), "application/x-www-form-urlencoded")).ToString();
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 login_success_1<T0, T1>()
	{
		//IL_0002: Expected O, but got I4
		//IL_00e1: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			httpRequest.Referer = "https://www." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/profile.php?id=" + frmMain.listFBEntity[indexEntity].UID;
			T1 resouce = (T1)ResouceControl.getResouce("RESOUCE_API_GRAPHQL");
			T1 str = (T1)"{\"category_id\":\"2347428775505624\",\"surface\":null}";
			str = (T1)HttpUtility.UrlEncode((string)str);
			T1 val = (T1)string.Concat((string[])(object)new T1[5]
			{
				(T1)"fb_dtsg=",
				(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T1)"&variables=",
				str,
				(T1)"&doc_id=5578508822226155"
			});
			T1 val2 = (T1)((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T1[1] { val }), "application/x-www-form-urlencoded")).ToString();
			T0 val3 = (T0)(!((string)val2).Contains("api_error_code"));
			if (val3 != null)
			{
				return (T0)1;
			}
			T0 val4 = (T0)((string)val2).ToLower().Contains("success");
			if (val4 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T2 loginByCookies<T0, T1, T2, T3>()
	{
		//IL_000d: Expected O, but got I4
		//IL_000f: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_03a9: Expected O, but got I4
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		//IL_03d8: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_03e6: Expected O, but got I4
		setMessage<T2, T1, T0>((T1)"Đăng nhập Cookie", (T2)0);
		T0 val = (T0)0;
		while (true)
		{
			try
			{
				T1 val2 = (T1)"";
				T1 val3 = (T1)"";
				T1 val4 = (T1)"";
				T1 val5 = (T1)"";
				T1 val6 = (T1)"";
				T1[] array = (T1[])(object)frmMain.listFBEntity[indexEntity].Cookie.Split((char[])(object)new T3[1] { (T3)59 });
				T0 val7 = (T0)0;
				while ((nint)val7 < array.Length)
				{
					T1 val8 = (T1)((object[])(object)array)[(object)val7];
					T2 val9 = (T2)((string)val8).Contains("=");
					if (val9 != null)
					{
						T2 val10 = (T2)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).First()).ToLower().Contains("c_user");
						if (val10 != null)
						{
							val2 = (T1)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).Last()).Trim();
						}
						T2 val11 = (T2)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).First()).ToLower().Contains("xs");
						if (val11 != null)
						{
							val3 = (T1)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).Last()).Trim();
						}
						T2 val12 = (T2)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).First()).ToLower().Contains("fr");
						if (val12 != null)
						{
							val4 = (T1)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).Last()).Trim();
						}
						T2 val13 = (T2)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).First()).ToLower().Contains("datr");
						if (val13 != null)
						{
							val5 = (T1)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).Last()).Trim();
						}
						T2 val14 = (T2)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).First()).ToLower().Contains("sb");
						if (val14 != null)
						{
							val6 = (T1)((string)((IEnumerable<T1>)(object)((string)val8).Split((char[])(object)new T3[1] { (T3)61 })).Last()).Trim();
						}
					}
					val7 = (T0)(val7 + 1);
				}
				T1 val15 = (T1)string.Concat((string[])(object)new T1[10]
				{
					(T1)"c_user=",
					val2,
					(T1)"; xs=",
					val3,
					(T1)"; fr=",
					val4,
					(T1)"; datr=",
					val5,
					(T1)"; sb=",
					val6
				});
				httpRequest.SetCookie((string)val15, true);
				httpRequest.KeepAlive = true;
				T1 str = (T1)((object)httpRequest.Get("https://m" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/composer/ocelot/async_loader/?publisher=feed", (RequestParams)null)).ToString();
				str = (T1)Regex.Unescape((string)str);
				T1 value = (T1)Regex.Match((string)str, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
				frmMain.listFBEntity[indexEntity].fb_dtsg = (string)value;
				value = (T1)Regex.Match((string)str, "spin_r\":(.*?),").Groups[1].Value;
				frmMain.listFBEntity[indexEntity].__spin_r = (string)value;
				value = (T1)Regex.Match((string)str, "spin_t\":(.*?),").Groups[1].Value;
				frmMain.listFBEntity[indexEntity].__spin_t = (string)value;
				value = (T1)Regex.Match((string)str, "async_get_token\":\"(.*?)\"").Groups[1].Value;
				frmMain.listFBEntity[indexEntity].async_get_token = (string)value;
			}
			catch
			{
			}
			val = (T0)(val + 1);
			T2 val16 = (T2)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].fb_dtsg);
			if (val16 == null)
			{
				break;
			}
			T2 val17 = (T2)((nint)val <= 3);
			if (val17 == null)
			{
				return (T2)0;
			}
		}
		return (T2)1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void mtUpdateGroup<T0, T1, T2, T3, T4>(T1 Khóa_nhóm)
	{
		//IL_0020: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		try
		{
			T1 val = (T1)(frmMain.listFBEntity[indexEntity].ListGroup == null);
			if (val != null)
			{
				frmMain.listFBEntity[indexEntity].ListGroup = (List<GroupItem>)Activator.CreateInstance(typeof(T4));
			}
			T0 val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=&__csr=&__req=m&__hs=&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=1&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=&lsd=",
				(T0)lsd,
				(T0)"&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=GroupsCometLeftRailContainerQuery&variables=%7B%22adminGroupsCount%22%3A3%2C%22memberGroupsCount%22%3A10000%2C%22scale%22%3A1%7D&server_timestamps=true&doc_id=3884641628300421"
			}) }), "application/x-www-form-urlencoded")).ToString();
			GroupAPI groupAPI = JsonConvert.DeserializeObject<GroupAPI>((string)val2);
			T1 val3 = (T1)(groupAPI != null && groupAPI.data != null && groupAPI.data.nonAdminGroups != null && groupAPI.data.nonAdminGroups.groups_tab != null && groupAPI.data.nonAdminGroups.groups_tab.tab_groups_list != null && groupAPI.data.nonAdminGroups.groups_tab.tab_groups_list.edges != null);
			if (val3 == null)
			{
				return;
			}
			if (Khóa_nhóm != null)
			{
				frmMain.listFBEntity[indexEntity].ListGroup.Clear();
				T2 enumerator = (T2)groupAPI.data.nonAdminGroups.groups_tab.tab_groups_list.edges.GetEnumerator();
				try
				{
					while (((List<GroupAPI_edges>.Enumerator*)(&enumerator))->MoveNext())
					{
						GroupAPI_edges current = ((List<GroupAPI_edges>.Enumerator*)(&enumerator))->Current;
						frmMain.listFBEntity[indexEntity].ListGroup.Add(new GroupItem
						{
							Group_Id = current.node.Id,
							isShared = false,
							Status = 1
						});
					}
					return;
				}
				finally
				{
					((IDisposable)(*(List<GroupAPI_edges>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T2 enumerator2 = (T2)groupAPI.data.nonAdminGroups.groups_tab.tab_groups_list.edges.GetEnumerator();
			try
			{
				while (((List<GroupAPI_edges>.Enumerator*)(&enumerator2))->MoveNext())
				{
					GroupAPI_edges item = ((List<GroupAPI_edges>.Enumerator*)(&enumerator2))->Current;
					T1 val4 = (T1)(((IEnumerable<GroupItem>)frmMain.listFBEntity[indexEntity].ListGroup).Where((Func<GroupItem, bool>)((GroupItem a) => (T1)a.Group_Id.Equals(item.node.Id))).Count() <= 0);
					if (val4 != null)
					{
						frmMain.listFBEntity[indexEntity].ListGroup.Add(new GroupItem
						{
							Group_Id = item.node.Id,
							isShared = false,
							Status = 0
						});
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<GroupAPI_edges>.Enumerator*)(&enumerator2))).Dispose();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool createPage(string TokenEAAG, string UID)
	{
		try
		{
			string text = string.Concat("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql?doc_id=6015849741773814&method=post&pretty=false&format=json&variables={\"input\":{\"publish\":true,\"name\":\"Vinícius Júnior ", Rand.Next(79, 79797979), "\",\"ref\":\"pages_tab_launch_point\",\"client_mutation_id\":\"6ecf7153-2986-47cd-9a65-cdcee39fee88\",\"category\":\"1350536325044173\",\"actor_id\":\"", UID, "\"}}&access_token=", TokenEAAG);
			string input = ((object)httpRequest.Get(text ?? "", (RequestParams)null)).ToString();
			string value = Regex.Match(input, "\"page\":{\"id\":\"(\\d+)\",").Groups[1].Value;
			if (value != string.Empty)
			{
				((object)httpRequest.Get("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/latest/home?nav_ref=bm_home_redirect&asset_id=" + value, (RequestParams)null)).ToString();
				((object)httpRequest.Get("https://m" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/pages/boosted_component_v2/view/?entry_point=promote_action_button&page_id=" + value + "&product=boosted_pagelike", (RequestParams)null)).ToString();
				return true;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 getAct_Id<T0, T1, T2, T3, T4>(T0 UID, T0 fb_dtsg, T0 TokenEAAG, out string result)
	{
		//IL_00b1: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_02e2: Expected O, but got I4
		//IL_02fc: Expected O, but got I4
		//IL_036e: Expected O, but got I4
		//IL_03d5: Expected O, but got I4
		//IL_0409: Expected O, but got I4
		//IL_0466: Expected O, but got I4
		//IL_0480: Expected O, but got I4
		//IL_04a0: Expected O, but got I4
		result = "";
		try
		{
			T0 empty = (T0)string.Empty;
			httpRequest.KeepAlive = true;
			empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				UID,
				(T0)"&session_id=4711e022067c790f&__user=",
				UID,
				(T0)"&__a=1&__dyn=7xeUmBz8aolJ28S1syU8EKnFG3a2q12wAxuq3mq1FxebzEcWAxam4EuGfwhEmx-ezobo_x3U98dEO486C6EC4UScx60C9EcEixWq4o8Efo9UeUryE5mWBBwQzocEiwTgfUK2C0A8swIwEwk8898eUugx0g8lUScyo720FoO12Kh7xWbwFyE8EeAUtxS2K5pUao9k2CEWewi8doa88EfU5WUvxC4e2-5Ey19zUuxe1dx-q4VEkwbG3ifzobEaUiyE-7888myUnwUzpA6EaEjz8c8-5azoa9obGAw-y84ybx6bCyV-ufwLCyKbw&__csr=&__req=1&__beoa=0&__pc=PHASED%3ADEFAULT&__hs=18770.PHASED%3ADEFAULT.2.0.0.0&__bhv=2&dpr=1.5&__ccg=GOOD&__rev=1003840914&__s=xb3mlj%3Ai7usn8%3Aen4cah&__hsi=6965484331858901774-0&__comet_req=0&fb_dtsg=",
				fb_dtsg,
				(T0)"&jazoest=22722&lsd=xkJCQ1jt1kZPZH696RZkUS&__spin_r=1003840914&__spin_b=trunk&__spin_t=1621777831&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=AccountQualityHubAssetOwnerViewQuery&variables=%7B%22assetOwnerId%22%3A%22",
				UID,
				(T0)"%22%2C%22startTime%22%3A1619136000%7D&server_timestamps=true&doc_id=4285998904743937"
			}), "application/x-www-form-urlencoded")).ToString();
			empty = (T0)Regex.Unescape((string)empty);
			T0 value = (T0)Regex.Match((string)empty, "\"status\":\"(.*?)\",").Groups[1].Value;
			T1 val = (T1)string.IsNullOrWhiteSpace((string)value);
			if (val != null)
			{
				httpRequest.KeepAlive = true;
				httpRequest.AddHeader("viewport-width", "1229");
				httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
				httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
				httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
				httpRequest.UserAgent = strUserAgentDesktop;
				httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
				httpRequest.AddHeader("Sec-Fetch-Site", "none");
				httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
				httpRequest.AddHeader("Sec-Fetch-User", "?1");
				httpRequest.AddHeader("Sec-Fetch-Dest", "document");
				empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL"), string.Concat((string[])(object)new T0[9]
				{
					(T0)"av=",
					UID,
					(T0)"&session_id=4711e022067c790f&__user=",
					UID,
					(T0)"&__a=1&__dyn=7xeUmBz8aolJ28S1syU8EKnFG3a2q12wAxuq3mq1FxebzEcWAxam4EuGfwhEmx-ezobo_x3U98dEO486C6EC4UScx60C9EcEixWq4o8Efo9UeUryE5mWBBwQzocEiwTgfUK2C0A8swIwEwk8898eUugx0g8lUScyo720FoO12Kh7xWbwFyE8EeAUtxS2K5pUao9k2CEWewi8doa88EfU5WUvxC4e2-5Ey19zUuxe1dx-q4VEkwbG3ifzobEaUiyE-7888myUnwUzpA6EaEjz8c8-5azoa9obGAw-y84ybx6bCyV-ufwLCyKbw&__csr=&__req=1&__beoa=0&__pc=PHASED%3ADEFAULT&__hs=18770.PHASED%3ADEFAULT.2.0.0.0&__bhv=2&dpr=1.5&__ccg=GOOD&__rev=1003840914&__s=xb3mlj%3Ai7usn8%3Aen4cah&__hsi=6965484331858901774-0&__comet_req=0&fb_dtsg=",
					fb_dtsg,
					(T0)"&jazoest=22722&lsd=xkJCQ1jt1kZPZH696RZkUS&__spin_r=1003840914&__spin_b=trunk&__spin_t=1621777831&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=AccountQualityHubAssetOwnerViewQuery&variables=%7B%22assetOwnerId%22%3A%22",
					UID,
					(T0)"%22%2C%22startTime%22%3A1619136000%7D&server_timestamps=true&doc_id=4285998904743937"
				}), "application/x-www-form-urlencoded")).ToString();
				httpRequest.UserAgent = Http.FirefoxUserAgent();
				empty = (T0)Regex.Unescape((string)empty);
				value = (T0)Regex.Match((string)empty, "\"status\":\"(.*?)\",").Groups[1].Value;
			}
			result = (string)empty;
			T1 val2 = (T1)((string)empty).Contains("checkpoint");
			if (val2 != null)
			{
				frmMain.SetCellColor<T1, T3, T4>((T3)indexEntity, (T4)Color.Red);
				return (T0)"checkpoint";
			}
			T1 val3 = (T1)((string)empty).Contains("RISK_PAYMENT");
			if (val3 != null)
			{
				frmMain.SetCellColor<T1, T3, T4>((T3)indexEntity, (T4)Color.Red);
				return (T0)"";
			}
			T1 val4 = (T1)(!((string)value == "NOT_RESTRICTED") && !((string)value == "APPEAL_ACCEPTED") && !((string)empty).Contains("AuthenticityVerificationRestrictionProviderAdditionalParameters"));
			if (val4 != null)
			{
				frmMain.SetCellColor<T1, T3, T4>((T3)indexEntity, (T4)Color.Red);
				return (T0)string.Empty;
			}
			T0 val5 = (T0)"";
			GetActId getActId = JsonConvert.DeserializeObject<GetActId>((string)empty);
			T1 val6 = (T1)(getActId != null && getActId.data != null && getActId.data.viewerData != null && getActId.data.viewerData.ad_accounts != null && getActId.data.viewerData.ad_accounts != null && getActId.data.viewerData.ad_accounts.nodes != null);
			if (val6 != null)
			{
				T2 enumerator = (T2)getActId.data.viewerData.ad_accounts.nodes.GetEnumerator();
				try
				{
					while (((List<nodes>.Enumerator*)(&enumerator))->MoveNext())
					{
						nodes current = ((List<nodes>.Enumerator*)(&enumerator))->Current;
						T1 val7 = (T1)(current.payment_account != null && !string.IsNullOrWhiteSpace(current.payment_account.__typename) && current.payment_account.__typename.Equals("AdsPaymentAccountRawDoNotUse"));
						if (val7 != null)
						{
							val5 = (T0)current.payment_account.payment_legacy_account_id;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<nodes>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T1 val8 = (T1)string.IsNullOrWhiteSpace((string)val5);
			if (val8 != null)
			{
				val5 = (T0)Regex.Match((string)empty, "payment_legacy_account_id\":\"(.*?)\"").Groups[1].Value;
			}
			T0 value2 = (T0)Regex.Match((string)empty, "\"name\":\"(.*?)\",\"profile_picture").Groups[1].Value;
			T1 val9 = (T1)((string)val5 != string.Empty && (string)value2 != string.Empty);
			if (val9 == null)
			{
				frmMain.SetCellColor<T1, T3, T4>((T3)indexEntity, (T4)Color.Red);
				return (T0)"null|null";
			}
			frmMain.SetCellColor<T1, T3, T4>((T3)indexEntity, (T4)Color.Blue);
			return (T0)((string)val5 + "|" + Regex.Unescape((string)value2));
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Share_TKQC_cá_nhân<T0, T1, T2, T3, T4, T5, T6, T7, T8>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_019d: Expected O, but got I4
		//IL_01ad: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_01ca: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_0231: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_028d: Expected O, but got I4
		//IL_02ad: Expected O, but got I4
		//IL_0300: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_0372: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_03ad: Expected O, but got I4
		//IL_03bc: Expected O, but got I4
		//IL_03f2: Expected O, but got I4
		//IL_0467: Expected O, but got I4
		//IL_047b: Expected O, but got I4
		//IL_050a: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0525: Expected O, but got I4
		//IL_0536: Expected O, but got I4
		//IL_0558: Expected O, but got I4
		//IL_0569: Expected O, but got I4
		//IL_057a: Expected O, but got I4
		//IL_0589: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_vào_via").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_vào_BM").ToString());
			T0 val4 = (T0)(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Check_live") != null);
			if (val4 != null)
			{
				bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Check_live").ToString());
			}
			T1 val5 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tên").ToString();
			T1 result = (T1)"";
			T1 act_Id = getAct_Id<T1, T0, T5, T2, T6>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, out *(string*)(&result));
			T0 val6 = (T0)string.IsNullOrWhiteSpace((string)act_Id);
			if (val6 != null)
			{
				setMessage<T0, T1, T2>((T1)"HCQC", (T0)1);
				return;
			}
			T0 val7 = (T0)((string)act_Id).Equals("checkpoint");
			if (val7 != null)
			{
				setMessage<T0, T1, T2>((T1)frmMain.STATUS.Checkpoint.ToString(), (T0)1);
				return;
			}
			setMessage<T0, T1, T2>((T1)"Live TKQC", (T0)0);
			T1[] array = (T1[])(object)((string)act_Id).Split((char[])(object)new T7[1] { (T7)124 });
			T1 val8 = (T1)((object[])(object)array)[0];
			frmMain.listFBEntity[indexEntity].Name = (string)val8;
			T1 status = (T1)"";
			T0 val9 = (T0)(check_status_payment<T0, T1, T8, T4, T2, T6>(val8, out *(string*)(&status)) == null);
			if (val9 == null)
			{
				setMessage<T0, T1, T2>(val8, (T0)0);
				T0 val10 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
				if (val10 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đang đổi tên", (T0)0);
					val5 = (T1)((string)val5 + " " + System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)(indexEntity + 1)));
					T0 val11 = changeNameAds_Clone<T1, T0>(val8, val5, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
					if (val11 == null)
					{
						setMessage<T0, T1, T2>((T1)"Đổi tên lỗi", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Đổi tên ok", (T0)1);
					}
				}
				T0 val12 = val2;
				if (val12 != null)
				{
					setMessage<T0, T1, T2>((T1)"Share VIA", (T0)0);
					T3 enumerator = (T3)frmMain.TokenNolimit.List_TOKEN_TKQC.GetEnumerator();
					try
					{
						while (((List<TokenEntity>.Enumerator*)(&enumerator))->MoveNext())
						{
							TokenEntity current = ((List<TokenEntity>.Enumerator*)(&enumerator))->Current;
							T0 val13 = (T0)current.Status.Equals(frmMain.STATUS.Live.ToString());
							if (val13 == null)
							{
								continue;
							}
							setMessage<T0, T1, T2>((T1)("Share VIA " + current.UID), (T0)0);
							T0 val14 = frmMain.nolimitApi.requestFriend<WebClient, NameValueCollection, T1, T0, HttpRequest>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)current.UID, (T1)current.Token, (T1)current.Cookie);
							if (val14 == null)
							{
								setMessage<T0, T1, T2>((T1)"Kết bạn lỗi!", (T0)1);
								continue;
							}
							setMessage<T0, T1, T2>((T1)"Đã gửi kết bạn", (T0)0);
							Thread.Sleep(1000);
							T0 val15 = acceptAddFriend<T1, T0>((T1)current.UID, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
							if (val15 == null)
							{
								setMessage<T0, T1, T2>((T1)"Kết bạn lỗi!", (T0)1);
								continue;
							}
							setMessage<T0, T1, T2>((T1)"SHARE TK...", (T0)0);
							Thread.Sleep(1000);
							T0 val16 = shareAdsToVia<T1, T0>(val8, (T1)current.UID);
							if (val16 == null)
							{
								setMessage<T0, T1, T2>((T1)"Share lỗi", (T0)1);
							}
							else
							{
								setMessage<T0, T1, T2>((T1)"SHARE ok", (T0)1);
							}
						}
						return;
					}
					finally
					{
						((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				T0 val17 = val3;
				if (val17 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đang thêm vào BM", (T0)0);
					addAdsToBM<T2, T0, T1>(val8, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
					T2 val18 = frmMain.nolimitApi.requestAddToBm<T2, HttpRequest, T1, T0>(val8);
					T0 val19 = (T0)(val18 == null);
					if (val19 != null)
					{
						setMessage<T0, T1, T2>((T1)"Đang chờ clone chấp nhận", (T0)0);
						T0 val20 = acceptRequestToBm<T1, WebClient, NameValueCollection, T0, HttpRequest>(val8, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.TokenNolimit.ID_BM, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
						if (val20 == null)
						{
							frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val8);
							setMessage<T0, T1, T2>((T1)"Thêm vào BM lỗi", (T0)1);
						}
						else
						{
							setMessage<T0, T1, T2>((T1)"Thêm vào BM ok", (T0)1);
						}
					}
					else
					{
						T0 val21 = (T0)((nint)val18 == 1);
						if (val21 != null)
						{
							setMessage<T0, T1, T2>((T1)"Thêm vào BM ok", (T0)1);
							return;
						}
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val8);
						setMessage<T0, T1, T2>((T1)"Thêm vào BM lỗi", (T0)1);
					}
				}
				else
				{
					T0 val22 = (T0)((string)val8).Contains("tiền");
					if (val22 == null)
					{
						setMessage<T0, T1, T2>((T1)"Đổi Múi giờ & tiền tệ lỗi", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Không đủ tiền", (T0)1);
					}
				}
			}
			else
			{
				Console.WriteLine((string)status);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Tạo_TKQC_cá_nhân<T0, T1, T2, T3, T4, T5, T6, T7, T8>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_027f: Expected O, but got I4
		//IL_02dc: Expected O, but got I4
		//IL_032f: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_03f2: Expected O, but got I4
		//IL_0403: Expected O, but got I4
		//IL_0412: Expected O, but got I4
		//IL_041e: Expected O, but got I4
		//IL_042f: Expected O, but got I4
		//IL_0441: Expected O, but got I4
		//IL_0487: Expected O, but got I4
		//IL_0496: Expected O, but got I4
		//IL_04ad: Expected O, but got I4
		//IL_04b0: Expected O, but got I4
		//IL_04bf: Expected O, but got I4
		//IL_04d2: Expected I4, but got O
		//IL_04ee: Expected O, but got I4
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_050d: Expected O, but got I4
		//IL_051b: Expected I4, but got O
		//IL_052c: Expected I4, but got O
		//IL_054d: Expected O, but got I4
		//IL_055e: Expected O, but got I4
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_0580: Expected O, but got I4
		//IL_0590: Expected O, but got I4
		//IL_0693: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Expected O, but got Unknown
		//IL_06a0: Expected O, but got I4
		//IL_06ab: Expected O, but got I4
		//IL_06c1: Expected O, but got I4
		//IL_06d5: Expected O, but got I4
		//IL_0722: Expected O, but got I4
		//IL_073a: Expected O, but got I4
		//IL_078f: Expected O, but got I4
		//IL_079e: Expected O, but got I4
		//IL_07d9: Expected O, but got I4
		//IL_081e: Expected O, but got I4
		//IL_083e: Expected O, but got I4
		//IL_0894: Expected O, but got I4
		//IL_08f4: Expected O, but got I4
		//IL_0903: Expected O, but got I4
		//IL_092f: Expected O, but got I4
		//IL_093e: Expected O, but got I4
		//IL_0974: Expected O, but got I4
		//IL_0977: Expected O, but got I4
		//IL_0983: Expected O, but got I4
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Expected O, but got Unknown
		//IL_09ad: Expected O, but got I4
		//IL_09c6: Expected O, but got I4
		//IL_0a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Expected O, but got Unknown
		//IL_0a5b: Expected O, but got I4
		//IL_0ad7: Expected O, but got I4
		//IL_0af0: Expected O, but got I4
		//IL_0aff: Expected O, but got I4
		//IL_0b0e: Expected O, but got I4
		//IL_0b1d: Expected O, but got I4
		//IL_0b36: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_vào_via").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_vào_BM").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Add_thẻ").ToString());
			T1 val5 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_quốc_gia_thẻ").ToString();
			T1 street = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Địa_chỉ").ToString();
			T1 city = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thành_phố").ToString();
			T1 state = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Bang").ToString();
			T1 zipCode = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"ZipCode").ToString();
			T1 tax_id = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_số_thuế").ToString();
			T1 val6 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_quốc_gia").ToString();
			T1 val7 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tiền_tệ").ToString();
			T1 string_ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_múi_giờ").ToString();
			T1 val8 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Set_limit").ToString();
			T1 val9 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tên").ToString();
			setMessage<T0, T1, T2>((T1)"Tạo TKQC", (T0)0);
			T0 val10 = (T0)createPage(frmMain.listFBEntity[indexEntity].TokenEAAG, frmMain.listFBEntity[indexEntity].UID);
			T0 val11 = (T0)(val10 == null);
			if (val11 != null)
			{
				createPage_API<T1, object>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)"Free Traffic", (T1)"180164648685982");
			}
			T1 result = (T1)"";
			T1 act_Id = getAct_Id<T1, T0, T5, T2, T6>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, out *(string*)(&result));
			T0 val12 = (T0)string.IsNullOrWhiteSpace((string)act_Id);
			if (val12 != null)
			{
				setMessage<T0, T1, T2>((T1)"HCQC", (T0)1);
				return;
			}
			T0 val13 = (T0)((string)act_Id).Equals("checkpoint");
			if (val13 == null)
			{
				setMessage<T0, T1, T2>((T1)"Live TKQC", (T0)1);
				T1[] array = (T1[])(object)((string)act_Id).Split((char[])(object)new T7[1] { (T7)124 });
				T1 val14 = (T1)((object[])(object)array)[0];
				frmMain.listFBEntity[indexEntity].Name = (string)val14;
				T0 val15 = (T0)(smethod_1<T1, MatchCollection, T0>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG) == null);
				if (val15 != null)
				{
					smethod_2((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				}
				Thread.Sleep(1000);
				setMessage<T0, T1, T2>(val14, (T0)0);
				frmMain.listFBEntity[indexEntity].Name = (string)val14;
				T0 val16 = doi_thong_tin_TKQC<T0, T1>(val14, string_, val6, val7, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)((string)ChromeControl.getFirstName<T0, T1, T2>() + " " + (string)ChromeControl.getLastName<T0, T1, T2>()), city, state, street, zipCode, tax_id);
				T0 val17 = val16;
				if (val17 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đổi Múi giờ & tiền tệ Ok", (T0)0);
				}
				else
				{
					T0 val18 = (T0)((string)val14).Contains("tiền");
					if (val18 == null)
					{
						setMessage<T0, T1, T2>((T1)"Đổi Múi giờ & tiền tệ lỗi", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Không đủ tiền", (T0)1);
					}
				}
				T0 val19 = (T0)(!string.IsNullOrWhiteSpace((string)val9));
				if (val19 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đang đổi tên", (T0)0);
					val9 = (T1)((string)val9 + " " + System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)(indexEntity + 1)));
					T0 val20 = changeNameAds_Clone<T1, T0>(val14, val9, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
					if (val20 != null)
					{
						setMessage<T0, T1, T2>((T1)"Đổi tên ok", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Đổi tên lỗi", (T0)1);
					}
				}
				T0 val21 = val4;
				if (val21 != null)
				{
					setMessage<T0, T1, T2>((T1)"Add thẻ", (T0)1);
					T2 val22 = (T2)0;
					while (true)
					{
						T0 val23 = (T0)frmMain.isRunning;
						if (val23 == null)
						{
							break;
						}
						indexCart = -1;
						T2 val24 = (T2)0;
						while (true)
						{
							T0 val25 = (T0)((nint)val24 < ((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)"")).Count);
							if (val25 != null)
							{
								T0 val26 = (T0)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[(int)val24].Status.Equals(frmMain.STATUS.Ready.ToString());
								if (val26 == null)
								{
									val24 = (T2)(val24 + 1);
									continue;
								}
								indexCart = (int)val24;
								((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[(int)val24].Status = frmMain.STATUS.Used.ToString();
								break;
							}
							break;
						}
						T0 val27 = (T0)(indexCart == -1);
						if (val27 == null)
						{
							T0 val28 = (T0)(!frmMain.isRunning);
							if (val28 == null)
							{
								setMessage<T0, T1, T2>((T1)$"Add thẻ {(T2)(val22 + 1)}", (T0)0);
								T1 country_code = val6;
								T0 val29 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
								if (val29 != null)
								{
									country_code = val5;
								}
								T0 val30 = addCart<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, val14, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, country_code, (T1)frmMain.listFBEntity[indexEntity].Name, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[indexCart].Card_Number, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[indexCart].Card_Security, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[indexCart].Exp_Month, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[indexCart].Exp_Year);
								T0 val31 = val30;
								if (val31 != null)
								{
									break;
								}
								((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T8, T1>((T1)""))[indexCart].Status = frmMain.STATUS.Declined.ToString();
								val22 = (T2)(val22 + 1);
								T0 val32 = (T0)((nint)val22 >= 5);
								if (val32 != null)
								{
									setMessage<T0, T1, T2>((T1)"Add thẻ không ok", (T0)1);
									break;
								}
								continue;
							}
							return;
						}
						setMessage<T0, T1, T2>((T1)"Hết thẻ", (T0)1);
						frmMain.isRunning = false;
						return;
					}
				}
				createNewAds_3<T1, T0>(val14, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				T0 val33 = (T0)(!string.IsNullOrWhiteSpace((string)val8) && !((string)val8).Equals("0"));
				if (val33 != null)
				{
					setMessage<T0, T1, T2>((T1)("Set limit: " + (string)val8), (T0)0);
					T0 val34 = setLimit<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, val14, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, val8, val7);
					if (val34 != null)
					{
						setMessage<T0, T1, T2>((T1)"Set limit ok", (T0)1);
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Set limit lỗi", (T0)1);
					}
				}
				createNewAds_3<T1, T0>(val14, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				T0 val35 = val2;
				if (val35 != null)
				{
					setMessage<T0, T1, T2>((T1)"Share VIA", (T0)0);
					T3 enumerator = (T3)frmMain.TokenNolimit.List_TOKEN_TKQC.GetEnumerator();
					try
					{
						while (((List<TokenEntity>.Enumerator*)(&enumerator))->MoveNext())
						{
							TokenEntity current = ((List<TokenEntity>.Enumerator*)(&enumerator))->Current;
							T0 val36 = (T0)current.Status.Equals(frmMain.STATUS.Live.ToString());
							if (val36 == null)
							{
								continue;
							}
							setMessage<T0, T1, T2>((T1)("Share VIA " + current.UID), (T0)0);
							T0 val37 = frmMain.nolimitApi.requestFriend<WebClient, NameValueCollection, T1, T0, HttpRequest>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)current.UID, (T1)current.Token, (T1)current.Cookie);
							if (val37 == null)
							{
								continue;
							}
							setMessage<T0, T1, T2>((T1)"Đã gửi kết bạn", (T0)0);
							Thread.Sleep(1000);
							T0 val38 = acceptAddFriend<T1, T0>((T1)current.UID, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
							if (val38 == null)
							{
								setMessage<T0, T1, T2>((T1)"Kết bạn lỗi!", (T0)1);
								continue;
							}
							setMessage<T0, T1, T2>((T1)"SHARE TK...", (T0)0);
							Thread.Sleep(1000);
							T0 val39 = shareAdsToVia<T1, T0>(val14, (T1)current.UID);
							if (val39 == null)
							{
								setMessage<T0, T1, T2>((T1)"Share lỗi", (T0)1);
							}
							else
							{
								setMessage<T0, T1, T2>((T1)"SHARE ok", (T0)1);
							}
						}
						return;
					}
					finally
					{
						((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				T0 val40 = val3;
				if (val40 == null)
				{
					return;
				}
				setMessage<T0, T1, T2>((T1)"Đang thêm vào BM", (T0)0);
				T2 val41 = (T2)0;
				while (true)
				{
					addAdsToBM<T2, T0, T1>(val14, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
					T2 val42 = frmMain.nolimitApi.requestAddToBm<T2, HttpRequest, T1, T0>(val14);
					T0 val43 = (T0)(val42 == null);
					if (val43 == null)
					{
						T0 val44 = (T0)((nint)val42 == 1);
						if (val44 != null)
						{
							break;
						}
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val14);
						val41 = (T2)(val41 + 1);
						T0 val45 = (T0)((nint)val41 <= 5);
						if (val45 == null)
						{
							setMessage<T0, T1, T2>((T1)"Thêm vào BM lỗi", (T0)1);
							return;
						}
						continue;
					}
					setMessage<T0, T1, T2>((T1)"Đang chờ clone chấp nhận", (T0)0);
					T0 val46 = acceptRequestToBm<T1, WebClient, NameValueCollection, T0, HttpRequest>(val14, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.TokenNolimit.ID_BM, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
					if (val46 == null)
					{
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val14);
						val41 = (T2)(val41 + 1);
						T0 val47 = (T0)((nint)val41 <= 5);
						if (val47 == null)
						{
							setMessage<T0, T1, T2>((T1)"Thêm vào BM lỗi", (T0)1);
							return;
						}
						continue;
					}
					setMessage<T0, T1, T2>((T1)"Thêm vào Bm ok", (T0)1);
					return;
				}
				setMessage<T0, T1, T2>((T1)"Thêm vào Bm ok", (T0)1);
			}
			else
			{
				setMessage<T0, T1, T2>((T1)frmMain.STATUS.Checkpoint.ToString(), (T0)1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 shareAdsToVia<T0, T1>(T0 Act, T0 UID_VIA)
	{
		//IL_00b7: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://adsmanager-graph.facebook.com/v15.0/act_",
				Act,
				(T0)"/users?_reqName=adaccount%2Fusers&access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG,
				(T0)"&method=post&__cppo=1"
			}) }), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&_index=12&_reqName=adaccount%2Fusers&_reqSrc=AdsPermissionDialogController&_sessionID=87345a785eb4e67&account_id=",
				Act,
				(T0)"&include_headers=false&locale=en_US&method=post&pretty=0&role=281423141961500&suppress_http_code=1&uid=",
				UID_VIA,
				(T0)"&xref=fadc4641ce460c"
			}) }), "application/x-www-form-urlencoded")).ToString();
			T1 val2 = (T1)((string)val).Contains("success");
			if (val2 != null)
			{
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Approved_hold<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			getFullAdsInfo<T2, T0>();
			T0 val2 = (T0)(frmMain.listFBEntity[indexEntity].fullAdsInfo != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data != null);
			if (val2 == null)
			{
				return;
			}
			T1 enumerator = (T1)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T2 val3 = (T2)current.id.Replace("act_", "");
					approved_payment<T2, T0, int>((T2)frmMain.listFBEntity[indexEntity].UID, val3, (T2)frmMain.listFBEntity[indexEntity].fb_dtsg);
					createNewAds_3<T2, T0>(val3, (T2)frmMain.listFBEntity[indexEntity].TokenEAAG);
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T2, int>((T2)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Add_thẻ_vô_hạn_2<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_01c5: Expected O, but got I4
		//IL_01d6: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_023e: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_02b1: Expected O, but got I4
		//IL_02f6: Expected O, but got I4
		//IL_035f: Expected O, but got I4
		//IL_03ae: Expected O, but got I4
		//IL_03c5: Expected O, but got I4
		//IL_0451: Expected O, but got I4
		//IL_045e: Expected O, but got I4
		//IL_048a: Expected O, but got I4
		//IL_04ba: Expected O, but got I4
		//IL_04cb: Expected O, but got I4
		//IL_04dd: Expected O, but got I4
		//IL_0523: Expected O, but got I4
		//IL_0532: Expected O, but got I4
		//IL_0550: Expected O, but got I4
		//IL_0568: Expected O, but got I4
		//IL_05bd: Expected O, but got I4
		//IL_05cc: Expected O, but got I4
		//IL_05fd: Expected O, but got I4
		//IL_0672: Expected O, but got I4
		//IL_067d: Expected O, but got I4
		//IL_068e: Expected O, but got I4
		//IL_06ae: Expected O, but got I4
		//IL_06c0: Expected O, but got I4
		//IL_074a: Expected O, but got I4
		//IL_076c: Expected O, but got I4
		//IL_077b: Expected O, but got I4
		//IL_078a: Expected O, but got I4
		//IL_07a3: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			T1 street = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Địa_chỉ").ToString();
			T1 city = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thành_phố").ToString();
			T1 state = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Bang").ToString();
			T1 zipCode = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"ZipCode").ToString();
			T1 tax_id = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_số_thuế").ToString();
			T1 string_ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_quốc_gia").ToString();
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tiền_tệ").ToString();
			T1 string_2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_múi_giờ").ToString();
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Set_limit").ToString();
			bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Approved_payment").ToString());
			T0 đẩy_thẻ_lên_chính = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đẩy_thẻ_lên_chính").ToString());
			T1 val4 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tên").ToString();
			setMessage<T0, T1, T2>((T1)"Vô hạn", (T0)1);
			createPage(frmMain.listFBEntity[indexEntity].TokenEAAG, frmMain.listFBEntity[indexEntity].UID);
			T1 result = (T1)"";
			T1 act_Id = getAct_Id<T1, T0, T4, T2, T5>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, out *(string*)(&result));
			T0 val5 = (T0)string.IsNullOrWhiteSpace((string)act_Id);
			if (val5 != null)
			{
				setMessage<T0, T1, T2>((T1)"HCQC", (T0)1);
				return;
			}
			T0 val6 = (T0)((string)act_Id).Equals("checkpoint");
			if (val6 == null)
			{
				setMessage<T0, T1, T2>((T1)"Live TKQC", (T0)0);
				T1[] array = (T1[])(object)((string)act_Id).Split((char[])(object)new T6[1] { (T6)124 });
				T1 val7 = (T1)((object[])(object)array)[0];
				frmMain.listFBEntity[indexEntity].Name = (string)val7;
				setMessage<T0, T1, T2>(val7, (T0)0);
				T0 val8 = (T0)(smethod_1<T1, MatchCollection, T0>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG) == null);
				if (val8 != null)
				{
					smethod_2((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				}
				setMessage<T0, T1, T2>((T1)"Kết bạn", (T0)0);
				T0 val9 = frmMain.nolimitApi.requestFriend_Single<T0, T1>((T1)frmMain.listFBEntity[indexEntity].UID);
				T0 val10 = val9;
				if (val10 != null)
				{
					setMessage<T0, T1, T2>((T1)"Đã gửi kết bạn", (T0)0);
					Thread.Sleep(1000);
					T0 val11 = acceptAddFriend<T1, T0>((T1)frmMain.nolimitApi.UID_VIA, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
					if (val11 != null)
					{
						setMessage<T0, T1, T2>((T1)"SHARE TK...", (T0)0);
					}
					Thread.Sleep(1000);
					T0 val12 = frmMain.nolimitApi.shareAdsToClone<HttpRequest, T1, T0>((T1)frmMain.listFBEntity[indexEntity].UID);
					T0 val13 = val12;
					if (val13 != null)
					{
						setMessage<T0, T1, T2>((T1)"SHARE OK", (T0)1);
						Thread.Sleep(1000);
						setMessage<T0, T1, T2>((T1)"Đang tạo TKQC mới", (T0)0);
						T1 val14 = createNewAds_Nolimit<T1, T0, object, T2>(string_2, string_, val2, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)((string)ChromeControl.getFirstName<T0, T1, T2>() + " " + (string)ChromeControl.getLastName<T0, T1, T2>()), city, state, street, zipCode, tax_id, đẩy_thẻ_lên_chính);
						T0 val15 = (T0)Regex.IsMatch((string)val14, "[0-9]{7,9}");
						if (val15 == null)
						{
							setMessage<T0, T1, T2>(val14, (T0)1);
							return;
						}
						T1[] array2 = (T1[])(object)((string)val14).Split((char[])(object)new T6[1] { (T6)124 });
						val14 = (T1)((object[])(object)array2)[0];
						setMessage<T0, T1, T2>((T1)"Tạo TKQC ok", (T0)1);
						createNewAds_3<T1, T0>(val14, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
						T0 val16 = (T0)(!string.IsNullOrWhiteSpace((string)val4));
						if (val16 != null)
						{
							setMessage<T0, T1, T2>((T1)"Đang đổi tên", (T0)0);
							val4 = (T1)((string)val4 + " " + System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)(indexEntity + 1)));
							T0 val17 = changeNameAds_Clone<T1, T0>(val14, val4, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
							if (val17 == null)
							{
								setMessage<T0, T1, T2>((T1)"Đổi tên lỗi", (T0)1);
							}
							else
							{
								setMessage<T0, T1, T2>((T1)"Đổi tên ok", (T0)1);
							}
						}
						T0 val18 = (T0)(!string.IsNullOrWhiteSpace((string)val3) && !((string)val3).Equals("0"));
						if (val18 != null)
						{
							setMessage<T0, T1, T2>((T1)("Set limit: " + (string)val3), (T0)0);
							T0 val19 = setLimit<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, val14, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, val3, val2);
							if (val19 == null)
							{
								setMessage<T0, T1, T2>((T1)"Set limit lỗi", (T0)1);
							}
							else
							{
								setMessage<T0, T1, T2>((T1)"Set limit ok", (T0)1);
							}
						}
						createNewAds_3<T1, T0>(val14, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
						setMessage<T0, T1, T2>((T1)"Đang thêm vào BM", (T0)0);
						addAdsToBM<T2, T0, T1>(val14, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
						T2 val20 = frmMain.nolimitApi.requestAddToBm<T2, HttpRequest, T1, T0>(val14);
						T0 val21 = (T0)(val20 == null);
						if (val21 == null)
						{
							T0 val22 = (T0)((nint)val20 == 1);
							if (val22 == null)
							{
								setMessage<T0, T1, T2>((T1)"Thêm vào BM lỗi", (T0)1);
								return;
							}
							Create_Act_Count++;
							setMessage<T0, T1, T2>((T1)"Thêm vào Bm ok", (T0)1);
							return;
						}
						setMessage<T0, T1, T2>((T1)"Đang chờ clone chấp nhận", (T0)0);
						T0 val23 = acceptRequestToBm<T1, WebClient, NameValueCollection, T0, HttpRequest>(val14, (T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.TokenNolimit.ID_BM, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
						if (val23 != null)
						{
							Create_Act_Count++;
							setMessage<T0, T1, T2>((T1)"Thêm vào Bm ok", (T0)1);
						}
						else
						{
							frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val14);
							setMessage<T0, T1, T2>((T1)"Thêm vào BM lỗi", (T0)1);
						}
					}
					else
					{
						setMessage<T0, T1, T2>((T1)"Share lỗi", (T0)1);
					}
				}
				else
				{
					setMessage<T0, T1, T2>((T1)"Kết bạn lỗi", (T0)1);
				}
			}
			else
			{
				setMessage<T0, T1, T2>((T1)frmMain.STATUS.Checkpoint.ToString(), (T0)1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T3 acceptRequestToBm<T0, T1, T2, T3, T4>(T0 string_0, T0 string_1, T0 string_2, T0 agency_id, T0 string_4)
	{
		//IL_001a: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		//IL_0268: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0321: Expected O, but got I4
		//IL_0326: Expected O, but got I4
		//IL_032b: Expected O, but got I4
		//IL_0333: Expected O, but got I4
		try
		{
			T0 val = acceptRequestToBm_2<T0, T3>(string_4);
			T3 val2 = (T3)(!((string)val != string.Empty));
			if (val2 != null)
			{
				return (T3)0;
			}
			Licensing.Key = (string)getTrialkey_Rebex<T3, T4, T0>();
			Console.WriteLine(Licensing.Key);
			T1 val3 = (T1)Activator.CreateInstance(typeof(WebClient));
			((SslSettings)((WebClient)val3).Settings).SslAllowedVersions = (TlsVersion)16;
			Activator.CreateInstance(typeof(NameValueCollection));
			((WebClient)val3).Headers.Add("Cookie", ((object)httpRequest.Cookies).ToString());
			T3 val4 = (T3)(httpRequest.Proxy != null && !string.IsNullOrWhiteSpace(httpRequest.Proxy.Host));
			if (val4 != null)
			{
				((WebClient)val3).Proxy.Host = httpRequest.Proxy.Host;
				((WebClient)val3).Proxy.Port = httpRequest.Proxy.Port;
				T3 val5 = (T3)(!string.IsNullOrWhiteSpace(httpRequest.Proxy.Username));
				if (val5 != null)
				{
					((WebClient)val3).Proxy.UserName = httpRequest.Proxy.Username;
				}
				T3 val6 = (T3)(!string.IsNullOrWhiteSpace(httpRequest.Proxy.Password));
				if (val6 != null)
				{
					((WebClient)val3).Proxy.Password = httpRequest.Proxy.Password;
				}
			}
			T0 input = (T0)((WebClient)val3).DownloadString("https://adsmanager.facebook.com/ads/manager/account_settings/information/?act=" + (string)string_0 + "&pid=p1&page=account_settings&tab=account_information");
			T0 value = (T0)Regex.Match((string)input, "async_get_token\":\"(.*?)\"").Groups[1].Value;
			T0 val7 = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"https://adsmanager.facebook.com/adaccount/agency/accept_reject_dialog/?ad_market_id=",
				val,
				(T0)"&agency_id=",
				agency_id,
				(T0)"&fb_dtsg_ag=",
				value,
				(T0)"&__usid=6-Trw91x21hdn02b:Prw91zkpqf38:0-Arw91wytk5e15-RV=6:F=&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__req=k&__hs=19522.BP:ads_campaign_manager_pkg.2.0..0.0&dpr=1.5&__ccg=EXCELLENT&__rev=1007676763&__s=x1kjln:6nhzs1:mbc5zk&__hsi=7244565912160181656&__dyn=7xeUmxa2C5rgydwCxpxO9UqDBBBWqxu59o9E4a2i5aCGq58mCyEgx2226UjACzEcWAAzpoOm7GzUK3G4WxaczES2SfxbVoS1kx2egGbwgEmK9y8Gdz8hyUdocEaEcEixWq4o8A2m5E9US2S6UGq3u5HGmmU-6QUTgbaQGypVQE8RpodoKUV2UC5UK1IxO4VAcKm2a9l7wWxe4oeUS6E465ubUO9ws8nxK1Nz84a9DxWbAzE888EeAUpK3m2Cu2C2l0FgKiewzxG9wRyUsKbwXxq2Sq2CUrorx2aK2ambAy88rwzzXyE8U4S7VEjCx6223q5o4-i2-fzobEaUiwm8myUnwUzpUqw-z8cedxiFVo9bBwKG13y8-agixi48hyVEKu9zawFBCyKbwzxa0NVVU2RwkO1y1FAwGwgVUWqU9Ecu2m1dxW6QquuaUohXwRCxC&__csr=&jazoest=24842&__aaid=962740714846055&__spin_r=1007676763&__spin_b=trunk&__spin_t=1686756944&"
			});
			T0 input2 = (T0)((WebClient)val3).DownloadString((string)val7);
			T0 value2 = (T0)Regex.Match((string)input2, "ad_market_id=(.*?)\"").Groups[1].Value;
			value2 = (T0)("https://adsmanager.facebook.com/adaccount/agency/request/accept_reject/?ad_market_id=" + ((string)value2).Replace("\\", "").Replace("&amp;", "&"));
			T3 val8 = (T3)((string)value2 != string.Empty);
			if (val8 != null)
			{
				try
				{
					((WebClient)val3).DownloadString((string)value2);
				}
				catch
				{
				}
				T0 input3 = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[5]
				{
					(T0)"https://graph.facebook.com/v14.0/act_",
					string_0,
					(T0)"?access_token=",
					(T0)frmMain.listFBEntity[indexEntity].TokenEAAG,
					(T0)"&_reqName=adaccount&_reqSrc=AdsCMAccountSettingsDataLoader&_sessionID=35ecbb5e9c6d7277&fields=[%22account_id%22,%22account_status%22,%22agencies{id,name,access_status,permitted_roles,picture}%22]"
				}), (RequestParams)null)).ToString();
				input3 = (T0)Regex.Replace((string)input3, "\\t|\\n|\\r", "").Replace(" ", "");
				T3 val9 = (T3)(((string)input3).Contains((string)agency_id) && ((string)input3).Contains("CONFIRMED"));
				if (val9 != null)
				{
					return (T3)1;
				}
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
	public T0 acceptRequestToBm_2<T0, T1>(T0 string_0)
	{
		//IL_0072: Expected O, but got I4
		try
		{
			T0 input = (T0)((object)httpRequest.Post("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v7.0/graphql?locale=en_US", "access_token=" + (string)string_0 + "&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=AdsManagerNotificationsQuery&variables=%7B%22count%22%3A100%7D&server_timestamps=true&doc_id=1786217454754453", "application/x-www-form-urlencoded")).ToString();
			T0 value = (T0)Regex.Match((string)input, "\"node\":{\"id\":\"(\\d+)\",\"adalerts_and_tips\"").Groups[1].Value;
			T1 val = (T1)(!((string)value != string.Empty));
			if (val != null)
			{
				return (T0)"";
			}
			return value;
		}
		catch
		{
		}
		return (T0)"";
	}

	public T1 addAdsToBM<T0, T1, T2>(T2 string_0, T2 string_1, T2 string_2, T2 string_3)
	{
		//IL_0003: Expected O, but got I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_001a: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		try
		{
			T0 val = (T0)0;
			while (true)
			{
				T1 val2 = (T1)((nint)val < 2);
				if (val2 != null)
				{
					T1 val3 = addAdsToBM_Step_1<T2, T1>(string_0, string_1);
					if (val3 != null)
					{
						break;
					}
					val = (T0)(val + 1);
					continue;
				}
				return (T1)0;
			}
			return (T1)1;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 addAdsToBM_Step_1<T0, T1>(T0 string_0, T0 string_1)
	{
		//IL_005c: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[6]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v9.0/act_",
				string_0,
				(T0)"?fields=account_status,is_user_allowed_to_advertise&access_token=",
				string_1
			}), (RequestParams)null)).ToString();
			T1 val2 = (T1)((string)val).Contains("\"account_status\": 1");
			if (val2 == null)
			{
				return (T1)0;
			}
			return (T1)1;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 changeNameAds_Clone<T0, T1>(T0 string_0, T0 string_1, T0 string_2)
	{
		//IL_00a1: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		try
		{
			T0 val = (T0)"debug=all&format=json&method=post";
			T0 input = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[5]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v11.0/act_"),
				string_0,
				(T0)"?access_token=",
				string_2,
				(T0)"&__cppo=1"
			}), (string)val + "&name=" + (string)string_1 + "&pretty=0&suppress_http_code=1&transport=cors", "application/x-www-form-urlencoded")).ToString();
			T1 val2 = (T1)(!(Regex.Match((string)input, "{\"success\":(.*?)}").Groups[1].Value == "true"));
			if (val2 == null)
			{
				return (T1)1;
			}
			return (T1)0;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 createNewAds_Nolimit<T0, T1, T2, T3>(T0 string_2, T0 string_3, T0 string_4, T0 string_5, T0 string_6, T0 string_7, T0 business_name, T0 city, T0 state, T0 street2, T0 zipCode, T0 tax_id, T1 Đẩy_thẻ_lên_chính)
	{
		//IL_0154: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_01cc: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		//IL_0288: Expected O, but got I4
		//IL_02d9: Expected O, but got I4
		//IL_0309: Expected O, but got I4
		//IL_0352: Expected O, but got I4
		try
		{
			T0 empty = (T0)string.Empty;
			empty = (T0)((object)httpRequest.Post("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql/", string.Concat((string[])(object)new T0[14]
			{
				(T0)"variables={\"input\":{\"current_payment_legacy_account_id\":\"",
				(T0)frmMain.TokenNolimit.ID_TKQC,
				(T0)"\",\"logging_data\":{\"logging_counter\":17,\"logging_id\":\"\"},\"new_country_code\":\"",
				string_3,
				(T0)"\",\"new_currency_code\":\"",
				string_4,
				(T0)("\",\"new_tax\":{\"business_address\":{\"city\":\"" + (string)city + "\",\"country_code\":\""),
				string_3,
				(T0)string.Concat((string[])(object)new T0[13]
				{
					(T0)"\",\"state\":\"",
					state,
					(T0)"\",\"street1\":\"",
					street2,
					(T0)"\",\"street2\":\"",
					street2,
					(T0)"\",\"zip\":\"",
					zipCode,
					(T0)"\"},\"business_name\":\"",
					business_name,
					(T0)"\",\"is_personal_use\":false,\"tax_exempt\":false,\"tax_id\":\"",
					tax_id,
					(T0)"\"},\"new_timezone\":\""
				}),
				string_2,
				(T0)"\",\"actor_id\":\"",
				string_6,
				(T0)"\",\"client_mutation_id\":\"2\"}}&server_timestamps=true&doc_id=4649659218451741&access_token=",
				string_7
			}), "application/x-www-form-urlencoded")).ToString();
			T0 value = (T0)Regex.Match((string)empty, "\"payment_legacy_account_id\":\"(\\d+)\",").Groups[1].Value;
			T1 val = (T1)((string)value == string.Empty);
			if (val != null)
			{
				value = (T0)Regex.Match((string)empty, "\"payment_legacy_account_id\":\"(\\d+)\"").Groups[1].Value;
			}
			T1 val2 = (T1)(((string)value).Length <= 9);
			if (val2 == null)
			{
				createNewAds_3<T0, T1>(value, string_7);
				if (Đẩy_thẻ_lên_chính != null)
				{
					createNewAds_1<T0, T1>(value, string_7, string_5, string_6);
				}
				Thread.Sleep(3000);
				T0 val3 = check_Khong_Du_Tien_Need_Very<T0, T1>(string_7, value);
				T1 val4 = (T1)((string)val3).Equals("Success");
				if (val4 == null)
				{
					setMessage<T1, T0, T3>((T0)"Tạo lại tk lần 2", (T1)1);
					empty = (T0)((object)httpRequest.Post("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql/", string.Concat((T2)"variables={\"input\":{\"current_payment_legacy_account_id\":\"", (T2)frmMain.TokenNolimit.ID_TKQC, (T2)"\",\"logging_data\":{\"logging_counter\":17,\"logging_id\":\"\"},\"new_country_code\":\"", (T2)string_3, (T2)"\",\"new_currency_code\":\"", (T2)string_4, (T2)"\",\"new_tax\":{\"business_address\":{\"city\":\"WWW\",\"country_code\":\"", (T2)string_3, (T2)"\",\"state\":\"\",\"street1\":\"\",\"street2\":\"Vinicius Junior\",\"zip\":\"99999\"},\"business_name\":\"Vinicius junior\",\"is_personal_use\":false,\"tax_exempt\":false,\"tax_id\":\"\"},\"new_timezone\":\"", (T2)string_2, (T2)"\",\"actor_id\":\"", (T2)string_6, (T2)"\",\"client_mutation_id\":\"", (T2)(object)(T3)Rand.Next(79, 797979), (T2)"\"}}&doc_id=4649659218451741&access_token=", (T2)string_7), "application/x-www-form-urlencoded")).ToString();
					value = (T0)Regex.Match((string)empty, "\"payment_legacy_account_id\":\"(\\d+)\",").Groups[1].Value;
					T1 val5 = (T1)((string)value == string.Empty);
					if (val5 != null)
					{
						value = (T0)Regex.Match((string)empty, "\"payment_legacy_account_id\":\"(\\d+)\"").Groups[1].Value;
					}
					T1 val6 = (T1)(((string)value).Length <= 9);
					if (val6 == null)
					{
						createNewAds_3<T0, T1>(value, string_7);
						if (Đẩy_thẻ_lên_chính != null)
						{
							createNewAds_1<T0, T1>(value, string_7, string_5, string_6);
						}
						Thread.Sleep(3000);
						val3 = check_Khong_Du_Tien_Need_Very<T0, T1>(string_7, value);
						T1 val7 = (T1)(!((string)val3 == "Success"));
						if (val7 != null)
						{
							return val3;
						}
						return value;
					}
					return val3;
				}
				return value;
			}
			return (T0)"Tạo TKQC mới lỗi (Kiểm tra lại TKQC gốc, clone HCQC, TKQC đã tạo đủ lượt)";
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 doi_thong_tin_TKQC<T0, T1>(T1 TKQC, T1 string_2, T1 string_3, T1 string_4, T1 string_5, T1 string_6, T1 string_7, T1 business_name, T1 city, T1 state, T1 street2, T1 zipCode, T1 tax_id)
	{
		//IL_0002: Expected O, but got I4
		//IL_000d: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01b7: Expected O, but got I4
		//IL_01cc: Expected O, but got I4
		//IL_0203: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T0 val = (T0)(!string.IsNullOrWhiteSpace((string)tax_id));
			if (val != null)
			{
				tax_id = (T1)("tax_id:" + (string)tax_id + ",");
			}
			T1 resouce = (T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL");
			T1 val2 = (T1)((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T1[1] { (T1)string.Concat((string[])(object)new T1[29]
			{
				(T1)"av=",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"&__usid=&__user=",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"&__a=1&__dyn=&__csr=&__req=14&__hs=&dpr=1&__ccg=GOOD&__rev=&__s=&__hsi=&__comet_req=0&fb_dtsg=",
				(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T1)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAccountInformationUtilsUpdateAccountMutation&variables={\"input\":{\"billable_account_payment_legacy_account_id\":\"",
				TKQC,
				(T1)"\",\"currency\":\"",
				string_4,
				(T1)"\",\"logging_data\":{\"logging_counter\":1,\"logging_id\":\"1\"},\"tax\":{\"business_address\":{\"city\":\"",
				city,
				(T1)"\",\"country_code\":\"",
				string_3,
				(T1)"\",\"state\":\"",
				state,
				(T1)"\",\"street1\":\"",
				street2,
				(T1)"\",\"street2\":\"\",\"zip\":\"",
				zipCode,
				(T1)"\"},\"business_name\":\"",
				business_name,
				(T1)"\",",
				tax_id,
				(T1)"\"is_personal_use\":false},\"timezone\":\"",
				string_2,
				(T1)"\",\"actor_id\":\"",
				(T1)frmMain.listFBEntity[indexEntity].UID,
				(T1)"\",\"client_mutation_id\":\"2\"}}&server_timestamps=true&doc_id=4699960830024588"
			}) }), "application/x-www-form-urlencoded")).ToString();
			T0 val3 = (T0)((string)val2).Contains((string)TKQC);
			if (val3 != null)
			{
				result = (T0)1;
				T1 val4 = (T1)"";
				T0 val5 = (T0)((string)val2).Contains("currency");
				if (val5 != null)
				{
					val4 = (T1)((string)val4 + Regex.Match((string)val2, "currency\":\"(.*?)\"").Groups[1].Value);
				}
				T0 val6 = (T0)((string)val2).Contains("business_country_code");
				if (val6 != null)
				{
					T0 val7 = (T0)(!string.IsNullOrWhiteSpace((string)val4));
					if (val7 != null)
					{
						val4 = (T1)((string)val4 + "-");
					}
					val4 = (T1)((string)val4 + Regex.Match((string)val2, "business_country_code\":\"(.*?)\"").Groups[1].Value);
				}
				T0 val8 = (T0)(!string.IsNullOrWhiteSpace((string)val4));
				if (val8 != null)
				{
					setMessage<T0, T1, int>(val4, (T0)1);
				}
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 createNewAds_3<T0, T1>(T0 string_0, T0 string_1)
	{
		//IL_0064: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[5]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v7.0/graphql?access_token="),
				string_1,
				(T0)"&variables={\"input\":{\"client_mutation_id\":\"6\",\"billable_account_payment_legacy_account_id\":\"",
				string_0,
				(T0)"\",\"entry_point\":\"BILLING_2_0\"}}&doc_id=3514448948659909&method=post"
			}), (RequestParams)null)).ToString();
			T1 val2 = (T1)((string)val).Contains("\"success\":true");
			if (val2 != null)
			{
				return (T1)1;
			}
			return (T1)0;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 check_Khong_Du_Tien_Need_Very<T0, T1>(T0 string_0, T0 string_1)
	{
		//IL_000e: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		try
		{
			setMessage<T1, T0, int>((T0)"Check không đủ tiền", (T1)0);
			T0 val = (T0)"";
			T0 val2 = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[5]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql?access_token="),
				string_0,
				(T0)"&variables={\"paymentAccountID\":\"",
				string_1,
				(T0)"\"}&doc_id=6975887429148122&method=post"
			}), (RequestParams)null)).ToString();
			T0 value = (T0)Regex.Match((string)val2, "\"card_association_name\":\"(.*?)\",").Groups[1].Value;
			T1 val3 = (T1)((string)value == string.Empty);
			if (val3 != null)
			{
				val = (T0)((string)val + "_Không có thẻ");
			}
			T1 val4 = (T1)((string)val2).Contains("\"is_reauth_restricted\":true,");
			if (val4 != null)
			{
				val = (T0)((string)val + "_Không đủ tiền");
			}
			T1 val5 = (T1)((string)val2).Contains("UNVERIFIED_OR_PENDING");
			if (val5 != null)
			{
				val = (T0)((string)val + "_Xác minh thẻ");
			}
			T1 val6 = (T1)((string)val == string.Empty);
			if (val6 != null)
			{
				return (T0)"Success";
			}
			return (T0)((string)val).Substring(1);
		}
		catch
		{
		}
		return (T0)"ERROR CHECK";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 lay_quoc_gia_tk<T0>(T0 string_0, T0 string_1)
	{
		T0 input = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[5]
		{
			(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v5.0/act_"),
			string_0,
			(T0)"?access_token=",
			string_1,
			(T0)"&_reqName=adaccount&_reqSrc=AdsPaymentMethodsDataLoader&_sessionID=277466400cb7c39d&fields=%5B%22all_payment_methods%7Bpayment_method_altpays%7Baccount_id%2Ccountry%2Ccredential_id%2Cdisplay_name%2Cimage_url%2Cinstrument_type%2Cnetwork_id%2Cpayment_provider%2Ctitle%7D%2Cpm_credit_card%7Baccount_id%2Ccredential_id%2Ccredit_card_address%2Ccredit_card_type%2Cdisplay_string%2Cexp_month%2Cexp_year%2Cfirst_name%2Cis_verified%2Clast_name%2Cmiddle_name%2Ctime_created%2Cneed_3ds_authorization%2Csupports_recurring_in_india%2Cverify_card_behavior%7D%2Cpayment_method_direct_debits%7Baccount_id%2Caddress%2Ccan_verify%2Ccredential_id%2Cdisplay_string%2Cfirst_name%2Cis_awaiting%2Cis_pending%2Clast_name%2Cmiddle_name%2Cstatus%2Ctime_created%7D%2Cpayment_method_extended_credits%7Baccount_id%2Cbalance%2Ccredential_id%2Cmax_balance%2Ctype%2Cpartitioned_from%2Csequential_liability_amount%7D%2Cpayment_method_paypal%7Baccount_id%2Ccredential_id%2Cemail_address%2Ctime_created%7D%2Cpayment_method_stored_balances%7Baccount_id%2Cbalance%2Ccredential_id%2Ctotal_fundings%7D%2Cpayment_method_tokens%7Baccount_id%2Ccredential_id%2Ccurrent_balance%2Coriginal_balance%2Ctime_created%2Ctime_expire%2Ctype%7D%7D%22%5D&include_headers=false&locale=vi_VN&method=get&pretty=0&suppress_http_code=1&xref=f39e7b8e8c24214"
		}), (RequestParams)null)).ToString();
		return (T0)Regex.Match((string)input, "country_code\":\"(.*?)\"").Groups[1].Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 createNewAds_1<T0, T1>(T0 string_0, T0 string_1, T0 string_2, T0 string_3)
	{
		//IL_000e: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		try
		{
			setMessage<T1, T0, int>((T0)"Đẩy thẻ lên chính", (T1)1);
			T0 input = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[5]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v5.0/act_"),
				string_0,
				(T0)"?access_token=",
				string_1,
				(T0)"&_reqName=adaccount&_reqSrc=AdsPaymentMethodsDataLoader&_sessionID=277466400cb7c39d&fields=%5B%22all_payment_methods%7Bpayment_method_altpays%7Baccount_id%2Ccountry%2Ccredential_id%2Cdisplay_name%2Cimage_url%2Cinstrument_type%2Cnetwork_id%2Cpayment_provider%2Ctitle%7D%2Cpm_credit_card%7Baccount_id%2Ccredential_id%2Ccredit_card_address%2Ccredit_card_type%2Cdisplay_string%2Cexp_month%2Cexp_year%2Cfirst_name%2Cis_verified%2Clast_name%2Cmiddle_name%2Ctime_created%2Cneed_3ds_authorization%2Csupports_recurring_in_india%2Cverify_card_behavior%7D%2Cpayment_method_direct_debits%7Baccount_id%2Caddress%2Ccan_verify%2Ccredential_id%2Cdisplay_string%2Cfirst_name%2Cis_awaiting%2Cis_pending%2Clast_name%2Cmiddle_name%2Cstatus%2Ctime_created%7D%2Cpayment_method_extended_credits%7Baccount_id%2Cbalance%2Ccredential_id%2Cmax_balance%2Ctype%2Cpartitioned_from%2Csequential_liability_amount%7D%2Cpayment_method_paypal%7Baccount_id%2Ccredential_id%2Cemail_address%2Ctime_created%7D%2Cpayment_method_stored_balances%7Baccount_id%2Cbalance%2Ccredential_id%2Ctotal_fundings%7D%2Cpayment_method_tokens%7Baccount_id%2Ccredential_id%2Ccurrent_balance%2Coriginal_balance%2Ctime_created%2Ctime_expire%2Ctype%7D%7D%22%5D&include_headers=false&locale=vi_VN&method=get&pretty=0&suppress_http_code=1&xref=f39e7b8e8c24214"
			}), (RequestParams)null)).ToString();
			T0 value = (T0)Regex.Match((string)input, "\"credential_id\":\"(\\d+)\",").Groups[1].Value;
			T1 val = (T1)(!((string)value != string.Empty));
			if (val == null)
			{
				httpRequest.Referer = string.Concat((string[])(object)new T0[5]
				{
					(T0)"https://www",
					(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T0)"/ads/manager/account_settings/account_billing/?act=",
					string_0,
					(T0)"&pid=p1&page=account_settings&tab=account_billing_settings"
				});
				input = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[6]
				{
					(T0)"https://www",
					(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T0)"/ads/payments/payment_methods/primary/change/?ad_account_id=",
					string_0,
					(T0)"&payment_method_id=",
					value
				}), string.Concat((string[])(object)new T0[5]
				{
					(T0)"__user=",
					string_3,
					(T0)"&__a=1&__dyn=7xeUmBz8aolJ28S2qq7E-8mA5FaDJ4WqwOwCwgEpyA4WCHxC49pEG48coG49UKbigC6UnGiidBxa7GzUK3G4Wxa6US2SaAUgS4UgwxAzUO486C6EC8yEScx60DUcEiyEjCx65EJ0Bxq22q3KUnyFEdUmKFpobQUTwMQmqEjwznBwRyXxK9z9p87zxil1ap12U98lwWxecAwTK6pox0g8lUScyobo43xu7o4q2ycwgHAhUuyUlxeawywWjy8gK4EG11DwFg94bxRoCiewzwAwRyUgyU-1iwnHxJxK48cohAy88rxiezUuxe1dx-q4VEhwbSi2-fzobEaUiwBxe3mbxu3ydDxG2G4UOcwzxG9GdxS48bE4q8w&__csr=&__req=15&__beoa=0&__pc=PHASED%3Apowereditor_pkg&dpr=1.5&__ccg=EXCELLENT&__rev=1003225987&__s=se4rr9%3Ag69eav%3Aafvy63&__hsi=6922271462199843630-0&__comet_req=0&fb_dtsg=",
					string_2,
					(T0)"&jazoest=22009&__spin_r=1003225987&__spin_b=trunk&__spin_t=1611716920&__jssesw=1"
				}), "application/x-www-form-urlencoded")).ToString();
				T1 val2 = (T1)((string)input).Contains("true");
				if (val2 != null)
				{
					return (T1)1;
				}
				return (T1)0;
			}
			return (T1)0;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 acceptAddFriend<T0, T1>(T0 string_0, T0 string_1, T0 string_2)
	{
		//IL_0073: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://m",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/a/mobile/friends/profile_add_friend.php?subjectid=",
				string_0,
				(T0)"&confirm&istimeline=1&hf=profile_button&fref=profile_inline"
			}), "m_sess=&fb_dtsg=" + (string)string_2 + "&jazoest=22000&__dyn=1KQEGiFo525Ujwh8-t28sBBgS5UqxKcwRwAxu3-Uco6q1DxW0Oohx61MwdK4o3Bw4Ewk9EdEnw9u0Xoswvosw-wWwt8-0mWeKdwle1Awbq1gwwyo36w9yq2a4U2YxW0D86i0DU985G&__csr=&__req=6&__ajax__=AYkDqOEiXoXfSS4nGnSdXwp4Bs-ie2WViqpsoEfUnj4-R0EmU3t3STvpxQ4W7w8Z9k_br3yKKa-_RRA9gQVqxmZw81c93ZyVg5a5cgXe1720jw&__a=AYkDqOEiXoXfSS4nGnSdXwp4Bs-ie2WViqpsoEfUnj4-R0EmU3t3STvpxQ4W7w8Z9k_br3yKKa-_RRA9gQVqxmZw81c93ZyVg5a5cgXe1720jw&__user=" + (string)string_1, "application/x-www-form-urlencoded")).ToString();
			T1 val2 = (T1)(!((string)val).Contains("true"));
			if (val2 != null)
			{
				return (T1)0;
			}
			return (T1)1;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void smethod_2<T0>(T0 string_0, T0 string_1)
	{
		try
		{
			((object)httpRequest.Post("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql?locale=en_US", string.Concat((string[])(object)new T0[5]
			{
				(T0)"access_token=",
				string_1,
				(T0)"&variables={\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"",
				string_0,
				(T0)"\",\"privacy_fbid\":\"8787540733\",\"privacy\":{\"allow\":[],\"base_state\":\"EVERYONE\",\"deny\":[]},\"source\":\"MOBILE_PRIVACY_SETTINGS\"},\"privacy_fbid\":\"8787540733\",\"root_setting_name\":\"PRIVACY_SETTINGS_PAGE\"}&doc_id=2311178268893184"
			}), "application/x-www-form-urlencoded")).ToString();
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T2 smethod_1<T0, T1, T2>(T0 string_0)
	{
		//IL_006b: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		try
		{
			T0 input = (T0)((object)httpRequest.Post("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql?locale=vi_VN", "access_token=" + (string)string_0 + "&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=PrivacySettingPageWithAudiencePickerQuery&variables=%7B%22name%22%3A%22friend_request%22%2C%22privacy_fbid%22%3A%228787540733%22%2C%22scale%22%3Anull%7D&server_timestamps=true&doc_id=3095252510531278", "application/x-www-form-urlencoded")).ToString();
			T1 val = (T1)Regex.Matches((string)input, "\"is_currently_selected\":(.*?),");
			T2 val2 = (T2)((MatchCollection)val)[0].ToString().Contains("true");
			if (val2 != null)
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Add_thẻ<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0051: Expected I4, but got O
		//IL_006d: Expected O, but got I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0089: Expected O, but got I4
		//IL_0096: Expected I4, but got O
		//IL_00a6: Expected I4, but got O
		//IL_00c7: Expected O, but got I4
		//IL_00d8: Expected O, but got I4
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f9: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		//IL_01d6: Expected O, but got I4
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0302: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		//IL_0323: Expected O, but got I4
		//IL_0332: Expected O, but got I4
		//IL_0341: Expected O, but got I4
		//IL_0350: Expected O, but got I4
		//IL_0361: Expected O, but got I4
		//IL_037b: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_quốc_gia_thẻ").ToString();
			setMessage<T0, T1, T2>((T1)"Add thẻ", (T0)0);
			T2 val3 = (T2)0;
			while (true)
			{
				T0 val4 = (T0)frmMain.isRunning;
				if (val4 == null)
				{
					break;
				}
				indexCart = -1;
				T2 val5 = (T2)0;
				while (true)
				{
					T0 val6 = (T0)((nint)val5 < ((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)"")).Count);
					if (val6 == null)
					{
						break;
					}
					T0 val7 = (T0)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[(int)val5].Status.Equals(frmMain.STATUS.Ready.ToString());
					if (val7 == null)
					{
						val5 = (T2)(val5 + 1);
						continue;
					}
					indexCart = (int)val5;
					((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[(int)val5].Status = frmMain.STATUS.Used.ToString();
					break;
				}
				T0 val8 = (T0)(indexCart == -1);
				if (val8 == null)
				{
					T0 val9 = (T0)(!frmMain.isRunning);
					if (val9 == null)
					{
						setMessage<T0, T1, T2>((T1)$"Add thẻ {(T2)(val3 + 1)}", (T0)1);
						T1 result = (T1)"";
						T1 act_Id = getAct_Id<T1, T0, T5, T2, T6>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, out *(string*)(&result));
						T0 val10 = (T0)((string)act_Id).Contains("checkpoint");
						if (val10 == null)
						{
							T0 val11 = (T0)string.IsNullOrWhiteSpace((string)act_Id);
							if (val11 == null)
							{
								setMessage<T0, T1, T2>((T1)"Live TKQC", (T0)0);
								T1[] array = (T1[])(object)((string)act_Id).Split((char[])(object)new T7[1] { (T7)124 });
								T1 val12 = (T1)((object[])(object)array)[0];
								frmMain.listFBEntity[indexEntity].Name = (string)val12;
								setMessage<T0, T1, T2>(val12, (T0)0);
								T0 val13 = (T0)string.IsNullOrWhiteSpace((string)val2);
								if (val13 != null)
								{
									val2 = lay_quoc_gia_tk(val12, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
								}
								T0 val14 = addCart<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, val12, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, val2, (T1)frmMain.listFBEntity[indexEntity].Name, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Card_Number, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Card_Security, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Exp_Month, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Exp_Year);
								T0 val15 = val14;
								if (val15 == null)
								{
									((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Status = frmMain.STATUS.Declined.ToString();
									val3 = (T2)(val3 + 1);
									T0 val16 = (T0)((nint)val3 >= 5);
									if (val16 != null)
									{
										setMessage<T0, T1, T2>((T1)"Add thẻ không ok", (T0)1);
										break;
									}
									continue;
								}
								setMessage<T0, T1, T2>((T1)"Add thẻ ok", (T0)1);
								break;
							}
							setMessage<T0, T1, T2>((T1)"HCQC", (T0)1);
							break;
						}
						setMessage<T0, T1, T2>((T1)"Checkpoint", (T0)1);
						break;
					}
					break;
				}
				setMessage<T0, T1, T2>((T1)"Hết thẻ", (T0)1);
				frmMain.isRunning = false;
				break;
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T2>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Add_thẻ_m_facebook<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_004a: Expected I4, but got O
		//IL_0065: Expected O, but got I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0080: Expected O, but got I4
		//IL_008d: Expected I4, but got O
		//IL_009d: Expected I4, but got O
		//IL_00be: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_00e5: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_02f5: Expected O, but got I4
		//IL_032f: Expected O, but got I4
		//IL_0347: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_quốc_gia_thẻ").ToString();
			setMessage<T0, T1, T2>((T1)"Add thẻ", (T0)1);
			indexCart = -1;
			T2 val3 = (T2)0;
			while (true)
			{
				T0 val4 = (T0)((nint)val3 < ((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)"")).Count);
				if (val4 == null)
				{
					break;
				}
				T0 val5 = (T0)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[(int)val3].Status.Equals(frmMain.STATUS.Ready.ToString());
				if (val5 == null)
				{
					val3 = (T2)(val3 + 1);
					continue;
				}
				indexCart = (int)val3;
				((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[(int)val3].Status = frmMain.STATUS.Used.ToString();
				break;
			}
			T0 val6 = (T0)(indexCart == -1);
			if (val6 == null)
			{
				T0 val7 = (T0)(!frmMain.isRunning);
				if (val7 != null)
				{
					return;
				}
				setMessage<T0, T1, T2>((T1)"Add thẻ", (T0)0);
				T1 result = (T1)"";
				T1 act_Id = getAct_Id<T1, T0, T5, T2, T6>((T1)frmMain.listFBEntity[indexEntity].UID, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, out *(string*)(&result));
				T0 val8 = (T0)((string)act_Id).Contains("checkpoint");
				if (val8 != null)
				{
					setMessage<T0, T1, T2>((T1)"Checkpoint", (T0)1);
					return;
				}
				T0 val9 = (T0)string.IsNullOrWhiteSpace((string)act_Id);
				if (val9 != null)
				{
					setMessage<T0, T1, T2>((T1)"HCQC", (T0)1);
					return;
				}
				setMessage<T0, T1, T2>((T1)"Live TKQC", (T0)0);
				T1[] array = (T1[])(object)((string)act_Id).Split((char[])(object)new T7[1] { (T7)124 });
				T1 val10 = (T1)((object[])(object)array)[0];
				frmMain.listFBEntity[indexEntity].Name = (string)val10;
				setMessage<T0, T1, T2>(val10, (T0)0);
				T0 val11 = (T0)string.IsNullOrWhiteSpace((string)val2);
				if (val11 != null)
				{
					val2 = lay_quoc_gia_tk(val10, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
				}
				T1 strOutMessage = (T1)"";
				T0 val12 = addCart_M_Facebook<T1, T0, T2>((T1)frmMain.listFBEntity[indexEntity].UID, val10, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, val2, (T1)frmMain.listFBEntity[indexEntity].Name, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Card_Number, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Card_Security, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Exp_Month, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Exp_Year, out *(string*)(&strOutMessage));
				T0 val13 = val12;
				if (val13 != null)
				{
					setMessage<T0, T1, T2>((T1)"Add thẻ ok", (T0)1);
					return;
				}
				setMessage<T0, T1, T2>(strOutMessage, (T0)1);
				((List<CreditCardEntity>)frmMain.listCreditCardEntity<T2, T0, T4, T1>((T1)""))[indexCart].Status = frmMain.STATUS.Declined.ToString();
			}
			else
			{
				setMessage<T0, T1, T2>((T1)"Hết thẻ", (T0)1);
				frmMain.isRunning = false;
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T2>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rip_clone<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_01eb: Expected O, but got I4
		//IL_01fa: Expected O, but got I4
		//IL_020c: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			setMessage<T0, T1, T3>((T1)"Rip nick", (T0)0);
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Rip_ngày_sinh").ToString());
			T0 val3 = val2;
			if (val3 != null)
			{
				T1 str = (T1)string.Concat((string[])(object)new T1[5]
				{
					(T1)"{\"collectionToken\":\"\",\"input\":{\"birthday_confirmation\":true,\"day\":1,\"month\":1,\"month_day_privacy\":{\"allow\":[],\"base_state\":\"FRIENDS_OF_FRIENDS\",\"deny\":[],\"tag_expansion_state\":\"UNSPECIFIED\"},\"year\":",
					(T1)System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)((DateTime)(T2)DateTime.Now).Year).ToString(),
					(T1)",\"year_privacy\":{\"allow\":[],\"base_state\":\"FRIENDS_OF_FRIENDS\",\"deny\":[],\"tag_expansion_state\":\"UNSPECIFIED\"},\"actor_id\":\"",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"\",\"client_mutation_id\":\"1\"},\"scale\":1,\"sectionToken\":\"\"}"
				});
				str = (T1)HttpUtility.UrlEncode((string)str);
				T1 val4 = (T1)string.Concat((string[])(object)new T1[9]
				{
					(T1)"av=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__usid=&__user=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&__a=1&__dyn=&__csr=&__req=r&__hs=&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=0&fb_dtsg=",
					(T1)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T1)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ProfileCometBirthdayUpdateMutation&variables=",
					str,
					(T1)"&server_timestamps=true&doc_id=5123707484403326"
				});
				httpRequest.Referer = string.Concat((string[])(object)new T1[5]
				{
					(T1)"https://www",
					(T1)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T1)"/profile.php?id=",
					(T1)frmMain.listFBEntity[indexEntity].UID,
					(T1)"&sk=about_contact_and_basic_info"
				});
				T1 val5 = (T1)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T1[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
				T0 val6 = (T0)((string)val5).Contains("user_update_birthday");
				if (val6 != null)
				{
					setMessage<T0, T1, T3>((T1)"Rip ok", (T0)1);
				}
				else
				{
					setMessage<T0, T1, T3>((T1)"Rip lỗi", (T0)1);
				}
			}
		}
		catch (Exception ex)
		{
			setMessage<T0, T1, T3>((T1)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tạo_Page<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00ff: Expected O, but got I4
		//IL_0215: Expected I4, but got O
		//IL_0223: Expected O, but got I4
		//IL_0249: Expected O, but got I4
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0257: Expected O, but got I4
		//IL_0276: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected I4, but got Unknown
		//IL_02a9: Expected I4, but got Unknown
		//IL_02c0: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_Page").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Page_thường").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Tạo_Bằng_API").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Share_via").ToString());
			string Tên_PAGE = flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Tên_PAGE").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(Tên_PAGE))).First();
			string Loại_PAGE = flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Loại_PAGE").ToString();
			CategoryComment categoryComment2 = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(Loại_PAGE))).First();
			T1 val6 = (T1)0;
			while (true)
			{
				T0 val7 = (T0)(val6 < val2);
				if (val7 == null)
				{
					break;
				}
				setMessage<T0, T2, T1>((T2)$"Tạo page: {(T1)(val6 + 1)}", (T0)1);
				T2 comment = (T2)categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)].Comment;
				comment = (T2)((string)frmMain.Spin_String<T2, T4, T0, T5>(comment)).Trim();
				T2 comment2 = (T2)categoryComment2.listCommentStroll[rnd.Next(0, categoryComment2.listCommentStroll.Count - 1)].Comment;
				comment2 = (T2)((string)frmMain.Spin_String<T2, T4, T0, T5>(comment2)).Trim();
				T2 val8 = (T2)"";
				T0 val9 = val4;
				val8 = (T2)((val9 == null) ? ((object)createPage(frmMain.listFBEntity[indexEntity].TokenEAAG, frmMain.listFBEntity[indexEntity].UID, (string)comment, (string)comment2, (byte)(int)val3 != 0)) : ((object)createPage_API<T2, object>((T2)frmMain.listFBEntity[indexEntity].TokenEAAG, (T2)frmMain.listFBEntity[indexEntity].UID, comment, comment2)));
				T0 val10 = (T0)(!string.IsNullOrWhiteSpace((string)val8));
				if (val10 != null)
				{
					countPage++;
					T0 val11 = val5;
					if (val11 != null)
					{
						SharePage<T0, List<TokenEntity>.Enumerator, T2, T1, T3, HttpRequest>(val8, (T0)(val3 == null));
					}
				}
				val6 = (T1)(val6 + 1);
			}
			T1 val12 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val13 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			Thread.Sleep(rnd.Next(val12 * 1000, val13 * 1000));
		}
		catch (Exception ex)
		{
			setMessage<T0, T2, T1>((T2)ex.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string createPage(string TokenEAAG, string UID, string pageName, string category, bool pageNormal)
	{
		string result = "";
		try
		{
			if (pageNormal)
			{
				string text = "av=strUID&__user=strUID&__a=1&__dyn=7AzHJ16U9ob8ng5K8G6EjBWo2nDwAxu13wsoKbmbwSwAyUcoeU5W2Saxa1NwJwpUe8hwaG0Z82_CxS320om78c87m2210x-8wgolzUO0n2US2G3i0Boy1PwBgK7o884y0Mo4G4UcUC68f85qfK6E7e58jwGzEaE5e7oqBwJK5Umxm5oe846mdUlDw-wUwxwjFo8oy2a2-3a1PwyBwJwSyES0Io88cA&__csr=gphslf2YQB8lIntPOiNcRqNT5sYnfn9lQBHJRcgLlO4lpyirFruZVQXXJaSKZV4iGgwyHALuFRnZaTtaG8QyZbloyHJRheijXmXpDWJQnAv8FniiRGimjBJ6V968VVGh6inRyWWXV44uch4EV3Ki8y8OmhatqGCiGhEx4KcheCmFbyEC8yGylzefxp5y94qUymbWK-jah6DGClqBCUO8Gh2pfQeFUix29VUyueK5Jz8aFozxieDz8-GgHhGG4eqVk2u5pUhFbChJ4CGEBxqi6p89FUGfxuWy9lJ5yeeAzWxGFohAyom_AmiKmayGBGU9EB1TwDUizCqFF4i6AEOUQxRzbAyFbyKu4A4uu6LgjxC1mCg8Eoy8mBx-4okhEixyESm5Ugy8qDxGK7V8izp8K7poaQ2y9wGw3RU0LK8w4sw2783Dg12EdQ0tjG6F81oQ0oy0mpw1fK2e04Ho1Fo08s81T822g3Cw5Bg4B0Ih-4hxkawbiq488r80jaawWy8nz-r4ehw4Cw920kG320euwm8ga0HE7W1tG0Se0akw2C80uCDOw2ZA1RU1kU7EMhw2zrS79648elg5S4GioD5iw&__req=20&__hs=18908.HYP%3Acomet_pkg.2.1.0.0.&dpr=1&__ccg=EXCELLENT&__rev=" + frmMain.listFBEntity[indexEntity].__spin_r + "&__s=9aaa4n%3Am5n0ja%3A4l2fjc&__hsi=7016556646384247452-0&__comet_req=1&fb_dtsg=" + frmMain.listFBEntity[indexEntity].fb_dtsg + "&jazoest=22048&lsd=VTmM0G5gd4qJnO_Fm2yU3x&__spin_r=" + frmMain.listFBEntity[indexEntity].__spin_r + "&__spin_b=trunk&__spin_t=" + frmMain.listFBEntity[indexEntity].__spin_t + "&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=CometPageCreateMutation&variables=%7B%22input%22%3A%7B%22categories%22%3A%5B%22strCategory%22%5D%2C%22description%22%3A%22%22%2C%22name%22%3A%22strPageName%22%2C%22publish%22%3Atrue%2C%22ref%22%3A%22launch_point%22%2C%22actor_id%22%3A%22strUID%22%2C%22client_mutation_id%22%3A%222%22%7D%7D&server_timestamps=true&doc_id=6015849741773814";
				text = text.Replace("strUID", UID);
				text = text.Replace("strPageName", pageName);
				text = text.Replace("strCategory", category);
				string text2 = ((object)httpRequest.Post("https://www.facebook.com/api/graphql/", string.Concat(text), "application/x-www-form-urlencoded")).ToString();
				if (!text2.Contains("page_create\":null}"))
				{
					result = Regex.Match(text2, "id\":\"(.*?)\"").Groups[1].Value;
				}
			}
			else
			{
				string input = ((object)httpRequest.Post("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ajax/ads/create/page/create", string.Concat("jazoest=&fb_dtsg=" + frmMain.listFBEntity[indexEntity].fb_dtsg + "&page_name=" + pageName + "&category=" + category + "&parent_category=1009&has_no_profile_pic=1&business_id=&__user=" + frmMain.listFBEntity[indexEntity].UID + "&__a=1&__dyn=&__csr=&__req=n&__hs=19269.BP%3Abrands_pkg.2.0.0.0.0&dpr=1&__ccg=MODERATE&__rev=1006317129&__s=4a38uu%3Aag6cq3%3Ataqsc1&__hsi=&__comet_req=0&lsd=&__spin_r=1006317129&__spin_b=trunk&__spin_t=1664859856&__jssesw=1"), "application/x-www-form-urlencoded")).ToString();
				result = Regex.Match(input, "\"page\":{\"id\":\"(\\d+)\",").Groups[1].Value;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 createPage_API<T0, T1>(T0 TokenEAAG, T0 UID, T0 pageName, T0 category)
	{
		T0 result = (T0)"";
		try
		{
			T0 input = (T0)((object)httpRequest.Get(string.Concat((T1)string.Concat((string[])(object)new T0[7]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/graphql?doc_id=6015849741773814&method=post&pretty=false&format=json&variables={\"input\":{\"publish\":true,\"name\":\"",
				pageName,
				(T0)"\",\"ref\":\"pages_tab_launch_point\",\"client_mutation_id\":\"6ecf7153-2986-47cd-9a65-cdcee39fee88\",\"category\":\"",
				category,
				(T0)"\",\"actor_id\":\""
			}), (T1)UID, (T1)"\"}}&access_token=", (T1)TokenEAAG), (RequestParams)null)).ToString();
			result = (T0)Regex.Match((string)input, "\"page\":{\"id\":\"(\\d+)\",").Groups[1].Value;
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe T0 SharePage<T0, T1, T2, T3, T4, T5>(T2 pageId, T0 isPro5)
	{
		//IL_0002: Expected O, but got I4
		//IL_000b: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_0209: Expected O, but got I4
		//IL_0395: Expected O, but got I4
		//IL_03c8: Expected O, but got I4
		//IL_0549: Expected O, but got I4
		//IL_056a: Expected O, but got I4
		T0 result = (T0)1;
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return result;
		}
		try
		{
			T1 enumerator = (T1)frmMain.setting.List_TOKEN_PAGE.GetEnumerator();
			try
			{
				while (((List<TokenEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					TokenEntity current = ((List<TokenEntity>.Enumerator*)(&enumerator))->Current;
					T0 val2 = (T0)current.Status.Equals(frmMain.STATUS.Live.ToString());
					if (val2 == null)
					{
						continue;
					}
					T0 val3 = (T0)0;
					setMessage<T0, T2, T3>((T2)("Share page: " + current.UID), (T0)1);
					if (isPro5 == null)
					{
						((object)httpRequest.Post(string.Concat((string[])(object)new T2[7]
						{
							(T2)"https://m",
							(T2)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
							(T2)"/password/reauth/?next=https%3A%2F%2Fm",
							(T2)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
							(T2)"%2Fpages%2Fedit_admin%2F%3Fid%3D",
							pageId,
							(T2)"%26admin_id%3D"
						}), string.Concat((string[])(object)new T2[5]
						{
							(T2)"fb_dtsg=",
							(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T2)"&jazoest=22098&pass=",
							(T2)frmMain.listFBEntity[indexEntity].Password,
							(T2)"&save=Ti%E1%BA%BFp+t%E1%BB%A5c"
						}), "application/x-www-form-urlencoded")).ToString();
						((object)httpRequest.Post(string.Concat((string[])(object)new T2[6]
						{
							(T2)"https://m",
							(T2)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
							(T2)"/a/pages/add_change_admin/?page_id=",
							pageId,
							(T2)"&admin_id=",
							(T2)current.UID
						}), string.Concat((string[])(object)new T2[5]
						{
							(T2)"fb_dtsg=",
							(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T2)"&jazoest=21974&admin_role=",
							(T2)"0",
							(T2)"&submit=Th%C3%AAm"
						}), "application/x-www-form-urlencoded")).ToString();
						setMessage<T0, T2, T3>((T2)("Nhận page: " + current.UID), (T0)1);
						Thread.Sleep(1000);
						val3 = frmMain.apiPage.Accept_Page<T0, T3, T2, T4, T5>((T2)current.Token, (T2)current.Cookie, (T2)current.UID, pageId);
					}
					else
					{
						T2 resouce = (T2)ResouceControl.getResouce("RESOUCE_API_GRAPHQL");
						T2 str = (T2)string.Concat((string[])(object)new T2[5]
						{
							(T2)"{\"input\":{\"password\":{\"sensitive_string_value\":\"",
							(T2)frmMain.listFBEntity[indexEntity].Password,
							(T2)"\"},\"actor_id\":\"",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"\",\"client_mutation_id\":\"1\"}}"
						});
						str = (T2)HttpUtility.UrlEncode((string)str);
						T2 val4 = (T2)string.Concat((string[])(object)new T2[9]
						{
							(T2)"av=",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"&__user=",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"&__a=1&__req=10&__hs=19519.HYP%3Acomet_plat_default_pkg.2.1..2.1&dpr=1.5&__ccg=EXCELLENT&__rev=1007660106&__s=1zt3z8%3A5arulv%3Arcgxxf&__hsi=7243274170417751901&__dyn=7AzHxqUW13xt0mUyEqxenFwLBwopU98nwgUao4u5QdwSxucyUco5S3O2Saxa1NwJwpUe8hw2nVEtwMw65xO2OU7m2210wEwgolzUO0n24oaEnxO0Bo7O2l2Utwwwi831wnEfovwRwlE-U2exi4UaEW2au1NxGm2SUbElxm3y3aexfxm16wUws9ovUy2a0SEuBwJCwLyESE2KwwwOg2cwMwrUdUcojxK2B0oouzE8oC1Iwqo&__csr=gd4AYQIJhdMzkgRTqiqihiQHh99QJ8Gjp2dGqAijWjjgShkQqGCC-qUHKWDBKp5Xy98tOyp9bJuHCCGngDAVV8nS9AyEgCxbWoDCQqbh8yaz8Km8A9zoGUHKl28y649zawMBK4kbUvy9FEGcCzAfzU8FoDG21zUkG22fwMwOry89UG4bK2OUbomFyqxG8xqewr8mBx611G2a2a5WwDDBwoUGdwg83cga8oAz8aXzU4p3Uy7olyA7oeEOHwAwg8ix2322y12yo8U2mwKG7E4Z0gqK1BK2e4U9Uuw2RQrw0C-g0jECBAGGwMwGIx80Re01QUwPw0gLE0e8o0bYU0vsg0KCm1Aw74zE0h7GEhKE4m1lzaw6p80bmwkQ0OFkKgU52i8wl40d5zEZ17o14o0o9Ba2aiYzg7a0dCxe1vg620lm0qa&__comet_req=1&fb_dtsg=",
							(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T2)"&jazoest=25456&lsd=-9ufzfYKv7G65jg1J-tf_-&__spin_r=1007660106&__spin_b=trunk&__spin_t=1686456187&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ProfilePlusMarkReauthedMutation&variables=",
							str,
							(T2)"&server_timestamps=true&doc_id=5048033918567225"
						});
						((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T2[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
						T0 val5 = (T0)((Dictionary<string, string>)(object)httpRequest.Cookies).ContainsKey("i_user");
						if (val5 != null)
						{
							((Dictionary<string, string>)(object)httpRequest.Cookies).Remove("i_user");
						}
						T0 val6 = (T0)((Dictionary<string, string>)(object)httpRequest.Cookies).ContainsKey("m_page_voice");
						if (val6 != null)
						{
							((Dictionary<string, string>)(object)httpRequest.Cookies).Remove("m_page_voice");
						}
						((Dictionary<string, string>)(object)httpRequest.Cookies).Add("i_user", (string)pageId);
						((Dictionary<string, string>)(object)httpRequest.Cookies).Add("m_page_voice", (string)pageId);
						((object)httpRequest.Get("https://www.facebook.com/", (RequestParams)null)).ToString();
						T2 fb_dtsg = (T2)frmMain.listFBEntity[indexEntity].fb_dtsg;
						str = (T2)string.Concat((string[])(object)new T2[7]
						{
							(T2)"{\"input\":{\"additional_profile_id\":\"",
							pageId,
							(T2)"\",\"admin_id\":\"",
							(T2)frmMain.listFBEntity[indexEntity].UID,
							(T2)"\",\"admin_visibility\":\"Unspecified\",\"grant_full_control\":true,\"actor_id\":\"",
							pageId,
							(T2)"\",\"client_mutation_id\":\"2\"}}"
						});
						str = (T2)HttpUtility.UrlEncode((string)str);
						val4 = (T2)string.Concat((string[])(object)new T2[9]
						{
							(T2)"av=",
							pageId,
							(T2)"&__user=",
							pageId,
							(T2)"&__a=1&__req=23&__hs=19519.HYP%3Acomet_plat_default_pkg.2.1..2.1&dpr=1.5&__ccg=EXCELLENT&__rev=1007660106&__s=rwlmyz%3Adhkpfk%3Azyselz&__hsi=7243287699078785235&__dyn=7AzHxqUW13yoR0mUK6EjBWobVo66u2i5U4e2C1vzEdEnz8K361twYwJxS0DU6u3y4o0B-q7oc81xoswIwuo886C11xmfz81s8hwGxu782lwv89kbxS2218wc61uwZxacwRwlE-U2exi4UaEW2au1NxGm2SUbElxm3y11xfxm16wUws9ovUy2a0SEuBwJCwLyESE2KwwwOg2cwMwrUdUcojxK2B0oouzE8oC1Iwqo&__csr=gd4BTdbaJOQxkDmAfVt6hKAcz7VnXC8QVEyjzUSnAhaWzvyEG9yFrCm-Uyi7vxSKWx2t2oyui6u9AyEaHHyoF194y8akct3oGeXBwAxWEc9olgdELxuqfx-3a2u2u49EowTwHrwvGwNxaV8C3Saws8sx614w45wjE13UhwoU8EpxS261Iwpo1xk1fwjQ0HHwzwmE0Jt6U0eG9FpaGE0XK00KaU0AS02Ze02_e07T40bFBwp81N8W04hWG4rG15woGw1BV03hoWfghS0h602ye4U5Z06Sw&__comet_req=1&fb_dtsg=",
							fb_dtsg,
							(T2)"&jazoest=25592&lsd=IZVtKu_pOxCZSN6K2vNI-u&__spin_r=1007660106&__spin_b=trunk&__spin_t=1686459337&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=ProfilePlusCoreAppAdminInviteMutation&variables=",
							str,
							(T2)"&server_timestamps=true&doc_id=6123408387725487"
						});
						httpRequest.AddHeader("x-fb-friendly-name", "ProfilePlusCoreAppAdminInviteMutation");
						((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T2[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
					}
					T0 val7 = val3;
					if (val7 == null)
					{
						setMessage<T0, T2, T3>((T2)"Nhận page lỗi", (T0)1);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 bat_che_do_chuyen_nghiep<T0, T1, T2>()
	{
		//IL_0002: Expected O, but got I4
		//IL_000d: Expected O, but got I4
		//IL_0015: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004c: Expected O, but got I4
		//IL_01fd: Expected O, but got I4
		//IL_03a9: Expected O, but got I4
		//IL_03af: Expected O, but got I4
		//IL_03c3: Expected O, but got I4
		//IL_03c9: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T0 val2 = (T0)frmMain.setting.isOnProfersional;
			if (val2 != null)
			{
				T1 val3 = (T1)0;
				while (true)
				{
					httpRequest.Referer = "https://www." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/profile.php?id=" + frmMain.listFBEntity[indexEntity].UID;
					T2 resouce = (T2)ResouceControl.getResouce("RESOUCE_API_GRAPHQL");
					T2 str = (T2)"{\"category_id\":\"1603\"}";
					str = (T2)HttpUtility.UrlEncode((string)str);
					T2 val4 = (T2)string.Concat((string[])(object)new T2[15]
					{
						(T2)"av=",
						(T2)frmMain.listFBEntity[indexEntity].UID,
						(T2)"&__user=",
						(T2)frmMain.listFBEntity[indexEntity].UID,
						(T2)"&__a=1&__dyn=7AzHxqU5a5Q1ryaxG4VuC0BVU98nwgU765QdwSwAyU8EW1twYwJyEiwsobo6u3y4o11U2nwb-q7oc81xoswIK1Rwwwg8a8465o-cwfG12wOKdwGxu782lwv89kbxS2218wc61axe3S1lwlE-UqwsUkxe2GewyDwkUtxGm2SUbElxm3y3aexfxmu3W3rws9ovUy2a0SEuBwJCwLyES0Io88cA0z8c84qifxe3u362-2B0oouzE8o&__csr=gT1n1p3O5iORsJhvYILZh2P_p74jkyOfqEABnQRQGdjq8A-XEFt--TKjh4WHmqHGSaQtdeFFfAVODACLhQFGFHhSC4ubVEzB8q9UDV48UW78sUN2pvADBy5DDgHzazEyey8gzk8mumHKVpVQ8Gby8-26eyF8hx64oymm48do5mbCufgowxxycUC2-dwVz8gxify8gwJg-cxmEC8xa0P8bEnxK5ErwBwNwrolw9a1Xxe1swwwKwIgbUO2ycwpEc87O262a1gx-6E3qw2BU08aU0iyw5sw14xK1-oy00Ku81880lAw1SF01zpzqw1VC0a8ztw3jC08Aw5Vw0Njw2FE0JK0nm0G82kwfF0eS0eFwbq3u0Eo&__req=1q&__hs=19313.HYP%3Acomet_pkg.2.1.0.2.1&dpr=1&__ccg=EXCELLENT&__rev=",
						(T2)frmMain.listFBEntity[indexEntity].__spin_r,
						(T2)"&__s=4xzpei%3Alsxbqx%3A12b54v&__hsi=7167024723252291444&__comet_req=15&fb_dtsg=",
						(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T2)"&jazoest=25522&lsd=8nNq65LrFnkOc53sxQ__IU&__aaid=755684252175517&__spin_r=",
						(T2)frmMain.listFBEntity[indexEntity].__spin_r,
						(T2)"&__spin_b=trunk&__spin_t=",
						(T2)frmMain.listFBEntity[indexEntity].__spin_t,
						(T2)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=CometProfilePlusOnboardingDialogTransitionMutation&variables=",
						str,
						(T2)"&server_timestamps=true&doc_id=4958075807610679&fb_api_analytics_tags=%5B%22qpl_active_flow_ids%3D30605361%22%5D"
					});
					T2 val5 = (T2)((object)httpRequest.Post((string)resouce, string.Concat((string[])(object)new T2[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
					T0 val6 = (T0)(!((string)val5).Contains("api_error_code"));
					if (val6 != null)
					{
						val = (T0)1;
					}
					T0 val7 = (T0)((string)val5).ToLower().Contains("success");
					if (val7 != null)
					{
						val = (T0)1;
					}
					T0 val8 = (T0)(val == null && (nint)val3 < 2);
					if (val8 != null)
					{
						val3 = (T1)(val3 + 1);
						continue;
					}
					break;
				}
			}
			else
			{
				httpRequest.Referer = "https://www." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/profile.php?id=" + frmMain.listFBEntity[indexEntity].UID;
				T2 resouce2 = (T2)ResouceControl.getResouce("RESOUCE_API_GRAPHQL");
				T2 str2 = (T2)"";
				str2 = (T2)HttpUtility.UrlEncode((string)str2);
				T2 val9 = (T2)string.Concat((string[])(object)new T2[13]
				{
					(T2)"av=",
					(T2)frmMain.listFBEntity[indexEntity].UID,
					(T2)"&__usid=6-Trw3uh01bfd1aa%3APrw3uixhqz27v%3A0-Arw3uh01nn52wk-RV%3D6%3AF%3D&__user=",
					(T2)frmMain.listFBEntity[indexEntity].UID,
					(T2)"&__a=1&__req=11&__hs=19519.HYP%3Acomet_pkg.2.1..2.1&dpr=1.5&__ccg=EXCELLENT&__rev=",
					(T2)frmMain.listFBEntity[indexEntity].__spin_r,
					(T2)"&__s=2prxlr%3Al5o5yz%3Ahs4z3z&__hsi=7243522445290139405&__dyn=7AzHJ16UW5Eb8ng5K8G6EjBWobVo66u2i5U4e2C17xt3odEnz8K2aewnof8boG4E762S1DwUx60GE5O0BU2_CxS320om78bbwto88422y11xmfz83WwgEcEhwGxu782lwv89kbxS2218wc61axe3S7Udo5qfK0zEkxe2GewyDwkUtxGm2SUbElxm3y3aexfxmu3W3y261eBx_y88E3qxWm2CVEbUGdG1Fwh888cA0z8c84q58jwTwNxe6Uak1xwJwxyo566k1Fw&__csr=g9tNAr48Htl3Alf4if9El5iE9BEgJFjFr8wBdfYDRmRh5nSIgOqlJaTGhiltdpKD9uCQOBWAYGGmFLApujuaDhZFCCFRVKLHGJ5hbijjVrmtlRhrBWgG8XAh8y-mrCGhki8AAABoCciGbUhKFonmFqGcxbxm5po_KcDQVV8jCgGbxubG4WzUmyV8OeCxaFSUS7aCBFxaEkzkbJ4x2fghwMxqqmdyokyrAxKmidxKbzUpy4fxacwFwgHypEc8Cdxmi8gaokXx-UlxjKEjBg4y4FopAxW2m4ooy-4oCU4ifK1nxXwtobE4CbwHxC5opxGE02gDx201X-w0Tww78w8a0DP2E2-wQK1FQbx3h_zFk3bAx6K7K0AEK1RyUsKpoBJqngGEnUWVExvHiwl9Xy_AwLybUyfpaCiW-hJsAWJpp6HGjHo9XxK7UyqK5Gx2q2l1Oq08jw5sg6G3K3W3-05eXDh8yGjzEgwMxWm1kxh380Dny9831w2kEG1JyF202YrwOw4awso0we3m0S81aeK4XyFAFawpo2vy8Gjw5aw6cw4Sw9S1Cw33U3ew33O09C6E0a980gAy813E2ww4aw4kw5VwMGQ42xK0Po0y906NKZ5yH81pgC0eOm1zw&__comet_req=15&fb_dtsg=",
					(T2)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T2)"&jazoest=25234&lsd=Bn-GGGsjcN5alRu6M7-oy8&__spin_r=",
					(T2)frmMain.listFBEntity[indexEntity].__spin_r,
					(T2)"&__spin_b=trunk&__spin_t=",
					(T2)frmMain.listFBEntity[indexEntity].__spin_t,
					(T2)"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=CometProfilePlusRollbackMutation&variables=%7B%7D&server_timestamps=true&doc_id=4947853815250139"
				});
				T2 val10 = (T2)((object)httpRequest.Post((string)resouce2, string.Concat((string[])(object)new T2[1] { val9 }), "application/x-www-form-urlencoded")).ToString();
				T0 val11 = (T0)(!((string)val10).Contains("api_error_code"));
				if (val11 != null)
				{
					val = (T0)1;
				}
				T0 val12 = (T0)((string)val10).ToLower().Contains("success");
				if (val12 != null)
				{
					val = (T0)1;
				}
			}
		}
		catch
		{
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tạo_BM<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_019b: Expected I4, but got O
		//IL_01be: Expected I4, but got O
		//IL_01dd: Expected O, but got I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0202: Expected O, but got I4
		//IL_0222: Expected I4, but got O
		//IL_024f: Expected I4, but got O
		//IL_025f: Expected O, but got I4
		//IL_0266: Expected O, but got I4
		//IL_027f: Expected I4, but got O
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02b5: Expected O, but got I4
		//IL_02c3: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_02ee: Expected O, but got I4
		//IL_0303: Expected O, but got I4
		//IL_0326: Expected O, but got I4
		//IL_0361: Expected O, but got I4
		//IL_0378: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_03e3: Expected O, but got I4
		//IL_0415: Expected O, but got I4
		//IL_0446: Expected O, but got I4
		//IL_0484: Expected O, but got I4
		//IL_04b3: Expected O, but got I4
		//IL_050b: Expected O, but got I4
		//IL_0521: Expected O, but got I4
		//IL_0537: Expected O, but got I4
		//IL_054d: Expected O, but got I4
		//IL_0560: Expected O, but got I4
		//IL_0582: Expected O, but got I4
		//IL_0585: Expected O, but got I4
		//IL_0597: Expected O, but got I4
		//IL_05a7: Expected O, but got I4
		//IL_05cf: Expected O, but got I4
		//IL_05e1: Expected O, but got I4
		//IL_061b: Expected O, but got I4
		//IL_066f: Expected O, but got I4
		//IL_06b6: Expected O, but got I4
		//IL_070b: Expected O, but got I4
		//IL_0789: Expected O, but got I4
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected O, but got Unknown
		//IL_079b: Expected O, but got I4
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected I4, but got Unknown
		//IL_07bd: Expected I4, but got Unknown
		//IL_07d1: Expected O, but got I4
		//IL_07e0: Expected O, but got I4
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Expected O, but got Unknown
		//IL_07f5: Expected O, but got I4
		//IL_0836: Expected O, but got I4
		//IL_0868: Expected O, but got I4
		//IL_089a: Expected O, but got I4
		//IL_08bf: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Đổi_proxy").ToString());
			T0 val3 = (T0)0;
			T0 val4 = (T0)(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Limit_dừng_lại") != null);
			if (val4 != null)
			{
				val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Limit_dừng_lại").ToString());
			}
			T0 link_ = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Link_2").ToString());
			T1 val5 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_BM_cần_tạo").ToString());
			T2 val6 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Tên_BM").ToString();
			T2 val7 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Mail_BM").ToString().ToLower();
			T2 val8 = (T2)flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Mail_link_mời").ToString().ToLower();
			T1 val9 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_link_mời").ToString());
			T1 val10 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val11 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T2 val12 = (T2)(Application.StartupPath + "\\BM\\");
			T0 val13 = (T0)(!Directory.Exists((string)val12));
			if (val13 != null)
			{
				Directory.CreateDirectory((string)val12);
			}
			T2 path = (T2)((string)val12 + "\\" + ((DateTime)(T3)DateTime.Now).ToString("dd-MM-yyyy") + ".txt");
			bat_che_do_chuyen_nghiep<T0, T1, T2>();
			T0 val14 = val2;
			if (val14 != null)
			{
				T2 val15 = (T2)"";
				while (true)
				{
					T0 val16 = (T0)(!frmMain.isRunning);
					if (val16 != null)
					{
						return;
					}
					T1 val17 = (T1)0;
					while (true)
					{
						T0 val18 = (T0)((nint)val17 < frmMain.proxySetting.listProxy.Count);
						if (val18 != null)
						{
							T0 val19 = (T0)(string.IsNullOrWhiteSpace(frmMain.proxySetting.listProxy[(int)val17].Status) || frmMain.proxySetting.listProxy[(int)val17].Status.Equals(frmMain.STATUS.Ready.ToString()));
							if (val19 == null)
							{
								val17 = (T1)(val17 + 1);
								continue;
							}
							frmMain.proxySetting.listProxy[(int)val17].Status = frmMain.STATUS.Used.ToString();
							val15 = frmMain.proxySetting.listProxy[(int)val17].ToString<T0, T2>();
							break;
						}
						break;
					}
					T0 val20 = (T0)string.IsNullOrWhiteSpace((string)val15);
					if (val20 == null)
					{
						break;
					}
					T1 val21 = (T1)0;
					while (true)
					{
						T0 val22 = (T0)((nint)val21 < frmMain.proxySetting.listProxy.Count);
						if (val22 == null)
						{
							break;
						}
						frmMain.proxySetting.listProxy[(int)val21].Status = frmMain.STATUS.Ready.ToString();
						val21 = (T1)(val21 + 1);
					}
				}
				setProxySocks<T2, T0, T5>(val15, (T0)frmMain.proxySetting.isProxy);
			}
			T1 val23 = (T1)0;
			while (true)
			{
				T0 val24 = (T0)(val23 < val5);
				if (val24 == null)
				{
					break;
				}
				T2 val25 = (T2)"";
				T0 val26 = (T0)string.IsNullOrWhiteSpace((string)val6);
				val25 = (T2)((val26 != null) ? string.Format("{0} {1}", ((string)ChromeControl.getFirstName<T0, T2, T1>()).Replace(" ", ""), (T1)rnd.Next(111, 999)) : $"{val6} {(T1)rnd.Next(111, 999)}");
				T2 val27 = (T2)"";
				T0 val28 = (T0)string.IsNullOrWhiteSpace((string)val7);
				if (val28 == null)
				{
					T0 val29 = (T0)(((string)val7).EndsWith("@hotmail.com") || ((string)val7).EndsWith("@outlook.com"));
					if (val29 != null)
					{
						T2[] array = (T2[])(object)((string)val7).Split((char[])(object)new T5[1] { (T5)64 });
						val27 = (T2)string.Concat((string[])(object)new T2[5]
						{
							(T2)((object[])(object)array)[0],
							(T2)"+",
							(T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)rnd.Next(1, 999)).ToString(),
							(T2)"@",
							(T2)((object[])(object)array)[1]
						});
					}
					else
					{
						T0 val30 = (T0)(((string)val7)[0] == '@');
						val27 = (T2)((val30 == null) ? ((object)val7) : ((object)(((string)ChromeControl.getFirstName<T0, T2, T1>()).ToLower().Replace(" ", "") + System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)rnd.Next(0, 9999)) + (string)val7)));
					}
				}
				else
				{
					val27 = (T2)(((string)ChromeControl.getFirstName<T0, T2, T1>()).ToLower().Replace(" ", "") + "@" + ((string)frmMain.RandomString<T2, T1, T5>((T1)8)).ToLower().Replace(" ", "") + ".com");
				}
				setMessage<T0, T2, T1>((T2)"Đang tạo BM", (T0)0);
				T2 val31 = createBM<T2, T0, T1, Random, StreamReader>((T2)frmMain.listFBEntity[indexEntity].UID, val25, val27, (T2)frmMain.listFBEntity[indexEntity].fb_dtsg, (T2)"5402509349824310", link_);
				T0 val32 = (T0)((string)val31).Equals("1404163");
				if (val32 == null)
				{
					T0 val33 = (T0)((string)val31).Equals("502 Bad Gateway");
					if (val33 == null)
					{
						T0 val34 = (T0)((string)val31).Equals("1501092823525282");
						if (val34 == null)
						{
							T0 val35 = (T0)((string)val31).Equals("1690114");
							if (val35 == null)
							{
								T0 val36 = (T0)(!string.IsNullOrWhiteSpace((string)val31));
								if (val36 != null)
								{
									Create_BM_Count++;
									setMessage<T0, T2, T1>((T2)"BM Ok", (T0)1);
									T1 val37 = (T1)0;
									while (true)
									{
										T0 val38 = (T0)(val37 < val9);
										if (val38 == null)
										{
											break;
										}
										setMessage<T0, T2, T1>((T2)"Đang lấy Link mời", (T0)1);
										T2 val39 = (T2)"";
										T0 val40 = (T0)string.IsNullOrWhiteSpace((string)val8);
										if (val40 == null)
										{
											T0 val41 = (T0)(((string)val8).EndsWith("@hotmail.com") || ((string)val8).EndsWith("@outlook.com"));
											if (val41 == null)
											{
												T0 val42 = (T0)(((string)val8)[0] == '@');
												val39 = (T2)((val42 != null) ? ((object)(((string)ChromeControl.getFirstName<T0, T2, T1>()).ToLower().Replace(" ", "") + System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)rnd.Next(0, 9999)) + (string)val8)) : ((object)val8));
											}
											else
											{
												T2[] array2 = (T2[])(object)((string)val8).Split((char[])(object)new T5[1] { (T5)64 });
												val39 = (T2)string.Concat((string[])(object)new T2[5]
												{
													(T2)((object[])(object)array2)[0],
													(T2)"+",
													(T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)rnd.Next(1, 999)).ToString(),
													(T2)"@",
													(T2)((object[])(object)array2)[1]
												});
											}
										}
										else
										{
											val39 = (T2)(((string)ChromeControl.getFirstName<T0, T2, T1>()).ToLower().Replace(" ", "") + "@" + ((string)frmMain.RandomString<T2, T1, T5>((T1)8)).ToLower().Replace(" ", "") + ".com");
										}
										T2 val43 = createLinkInvite<T2, T0, object>(val31, (T2)frmMain.listFBEntity[indexEntity].TokenEAAG, val39);
										T0 val44 = (T0)(!string.IsNullOrWhiteSpace((string)val43));
										if (val44 != null)
										{
											while (true)
											{
												T0 val45 = (T0)frmMain.isRunning;
												if (val45 != null)
												{
													try
													{
														File.AppendAllText((string)path, string.Concat((string[])(object)new T2[6]
														{
															(T2)frmMain.listFBEntity[indexEntity].UID,
															(T2)"|",
															val31,
															(T2)"|",
															val43,
															(T2)Environment.NewLine
														}));
													}
													catch (Exception ex)
													{
														Console.WriteLine(ex.Message);
														goto IL_0778;
													}
												}
												break;
												IL_0778:
												Thread.Sleep(1500);
											}
										}
										val37 = (T1)(val37 + 1);
									}
									Thread.Sleep(rnd.Next(val10 * 1000, val11 * 1000));
								}
								else
								{
									setMessage<T0, T2, T1>((T2)"BM lỗi", (T0)1);
								}
							}
							else
							{
								setMessage<T0, T2, T1>((T2)"Limit create BM", (T0)1);
								T0 val46 = val3;
								if (val46 != null)
								{
									isLogined = false;
									frmMain.listFBEntity[indexEntity].Select = false;
									return;
								}
							}
							val23 = (T1)(val23 + 1);
							continue;
						}
						setMessage<T0, T2, T1>((T2)"CP 282", (T0)1);
						isLogined = false;
						frmMain.listFBEntity[indexEntity].Select = false;
						return;
					}
					setMessage<T0, T2, T1>((T2)"502 Bad Gateway", (T0)1);
					isLogined = false;
					frmMain.listFBEntity[indexEntity].Select = false;
					return;
				}
				setMessage<T0, T2, T1>((T2)"HCQC", (T0)1);
				break;
			}
			T0 val47 = val2;
			if (val47 != null)
			{
				httpRequest.Proxy = null;
			}
		}
		catch (Exception ex2)
		{
			setMessage<T0, T2, T1>((T2)ex2.Message, (T0)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 createLinkInvite<T0, T1, T2>(T0 string_1, T0 string_2, T0 email)
	{
		//IL_0019: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		T0 empty = (T0)string.Empty;
		try
		{
			T0 val = (T0)"brandId";
			T1 val2 = (T1)((string)val == string.Empty);
			if (val2 != null)
			{
				return (T0)"";
			}
			email = (T0)HttpUtility.UrlEncode((string)email);
			empty = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[6]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v3.0/",
				string_1,
				(T0)"/business_users?access_token=",
				string_2
			}), string.Format("{0}={1}&email=" + (string)email + "&method=post&pretty=0&roles=%5B%22ADMIN%22%2C%22FINANCE_EDITOR%22%5D&suppress_http_code=1", (object[])(object)new T2[2]
			{
				(T2)val,
				(T2)string_1
			}), "application /x-www-form-urlencoded")).ToString();
			empty = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[5]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v4.0/"),
				string_1,
				(T0)"/pending_users?access_token=",
				string_2,
				(T0)"&_reqName=object%3Abusiness%2Fpending_users&_reqSrc=BusinessConnectedPendingUsersStore.brands&date_format=U&fields=%5B%22id%22%2C%22role%22%2C%22email%22%2C%22invite_link%22%2C%22status%22%5D&limit=25&locale=en_US&method=get&pretty=0&sort=name_ascending&suppress_http_code=1"
			}), "access_token=" + (string)string_2 + "&_reqName=object%3Abusiness%2Fpending_users&_reqSrc=BusinessConnectedPendingUsersStore.brands&date_format=U&fields=%5B%22id%22%2C%22role%22%2C%22email%22%2C%22invite_link%22%2C%22status%22%5D&limit=25&locale=en_US&method=get&pretty=0&sort=name_ascending&suppress_http_code=1", "application/x-www-form-urlencoded")).ToString();
			T0 val3 = (T0)Regex.Match((string)empty, "\"invite_link\":\"(.*?)\"").Groups[1].Value.Replace("\\", "");
			T1 val4 = (T1)((string)val3 != string.Empty);
			if (val4 == null)
			{
				return (T0)"";
			}
			return val3;
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Tạo_tài_khoản_BM<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0156: Expected O, but got I4
		//IL_0181: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_01b1: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_0232: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		//IL_02f2: Expected O, but got I4
		//IL_0300: Expected O, but got I4
		//IL_031f: Expected O, but got I4
		//IL_0362: Expected O, but got I4
		//IL_0370: Expected O, but got I4
		//IL_038f: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_046f: Expected O, but got I4
		//IL_047d: Expected O, but got I4
		//IL_04d9: Expected O, but got I4
		//IL_052d: Expected O, but got I4
		//IL_053c: Expected O, but got I4
		//IL_054f: Expected I4, but got O
		//IL_056b: Expected O, but got I4
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_058a: Expected O, but got I4
		//IL_0598: Expected I4, but got O
		//IL_05a9: Expected I4, but got O
		//IL_05ca: Expected O, but got I4
		//IL_05db: Expected O, but got I4
		//IL_05fb: Expected O, but got I4
		//IL_060b: Expected O, but got I4
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0711: Expected O, but got Unknown
		//IL_071b: Expected O, but got I4
		//IL_0726: Expected O, but got I4
		//IL_073c: Expected O, but got I4
		//IL_074e: Expected O, but got I4
		//IL_07a6: Expected O, but got I4
		//IL_07d4: Expected O, but got I4
		//IL_0804: Expected O, but got I4
		//IL_080b: Expected O, but got I4
		//IL_0866: Expected O, but got I4
		//IL_08bf: Expected O, but got I4
		//IL_08c6: Expected O, but got I4
		//IL_08e2: Expected O, but got I4
		//IL_0901: Expected O, but got I4
		//IL_090c: Expected O, but got I4
		//IL_091d: Expected O, but got I4
		//IL_092c: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1[] array = null;
			try
			{
				array = (T1[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"BM_ID_nhận_TK");
			}
			catch (Exception)
			{
			}
			T0 val2 = (T0)(array == null);
			if (val2 != null)
			{
				array = JsonConvert.DeserializeObject<T1[]>(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"BM_ID_nhận_TK").ToString());
			}
			T2 val3 = (T2)Activator.CreateInstance(typeof(T2));
			T1[] array2 = array;
			T3 val4 = (T3)0;
			while ((nint)val4 < array2.Length)
			{
				T1 val5 = (T1)((object[])(object)array2)[(object)val4];
				T0 val6 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
				if (val6 != null)
				{
					((List<string>)val3).Add(((string)val5).Trim());
				}
				val4 = (T3)(val4 + 1);
			}
			T1 street = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Địa_chỉ").ToString();
			T1 city = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thành_phố").ToString();
			T1 state = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Bang").ToString();
			T1 zip = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"ZipCode").ToString();
			T1 tax_id = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_số_thuế").ToString();
			T1 val7 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_quốc_gia").ToString();
			T1 val8 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tiền_tệ").ToString();
			T1 timezone = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_múi_giờ").ToString();
			T1 val9 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Set_limit").ToString();
			T0 val10 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Add_thẻ").ToString());
			T1 val11 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mã_quốc_gia_thẻ").ToString();
			T0 val12 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Dùng_lại_thẻ_thành_công").ToString());
			T0 val13 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"VHH_tk_khi_add_thẻ").ToString());
			T0 val14 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Approved_payment").ToString());
			T1 val15 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tên").ToString();
			val15 = (T1)((string)val15 + " " + indexEntity);
			T0 val16 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Check_không_đủ_tiền").ToString());
			bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_2").ToString());
			T0 val17 = (T0)(!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG));
			if (val17 != null)
			{
				bat_che_do_chuyen_nghiep<T0, T3, T1>();
				while (true)
				{
					T0 val18 = (T0)frmMain.isRunning;
					if (val18 == null)
					{
						break;
					}
					T1 val19 = (T1)$"{frmMain.listFBEntity[indexEntity].Name} {(T3)rnd.Next(11111, 99999)}";
					T1 a_ = (T1)(((string)val19).ToLower().Replace(" ", "") + "@gmail.com");
					T1 val20 = createBM<T1, T0, T3, Random, StreamReader>((T1)frmMain.listFBEntity[indexEntity].UID, val19, a_, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, (T1)"5402509349824310", (T0)0);
					T0 val21 = (T0)(!string.IsNullOrWhiteSpace((string)val20));
					if (val21 != null)
					{
						Create_BM_Count++;
						T0 val22 = (T0)(!frmMain.isRunning);
						if (val22 != null)
						{
							return;
						}
						T1 val23 = createAds<T1, T0, T3>(val15, (T1)"", (T1)"1", (T1)"USD", val20, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG, (T0)0, (T1)"");
						T0 val24 = (T0)(!string.IsNullOrWhiteSpace((string)val23));
						if (val24 != null)
						{
							Create_BM_Act_Count++;
							T0 val25 = (T0)(!frmMain.isRunning);
							if (val25 != null)
							{
								return;
							}
							shareToUser<T1, T0, T5, T3>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG, val20, (T1)frmMain.listFBEntity[indexEntity].UID, val23);
							T0 val26 = (T0)(!frmMain.isRunning);
							if (val26 != null)
							{
								return;
							}
							updateBillingInfo((string)val23, (string)val8, (string)city, (string)val7, (string)state, (string)street, (string)zip, frmMain.listFBEntity[indexEntity].Name, (string)timezone, frmMain.listFBEntity[indexEntity].UID, frmMain.listFBEntity[indexEntity].fb_dtsg, (string)tax_id);
							T0 val27 = (T0)(!string.IsNullOrWhiteSpace((string)val9) && !((string)val9).Equals("0"));
							if (val27 != null)
							{
								T0 val28 = (T0)(!frmMain.isRunning);
								if (val28 != null)
								{
									return;
								}
								setLimit<T1, T0, T3>((T1)frmMain.listFBEntity[indexEntity].UID, val23, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, val9, val8);
							}
							T0 val29 = val13;
							if (val29 != null)
							{
								T0 val30 = (T0)(!frmMain.isRunning);
								if (val30 != null)
								{
									return;
								}
								disableAct<T1, T0, T3>((T1)frmMain.listFBEntity[indexEntity].UID, val23, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
							}
							T0 val31 = val10;
							if (val31 != null)
							{
								T3 val32 = (T3)0;
								while (true)
								{
									T0 val33 = (T0)frmMain.isRunning;
									if (val33 == null)
									{
										break;
									}
									indexCart = -1;
									T3 val34 = (T3)0;
									while (true)
									{
										T0 val35 = (T0)((nint)val34 < ((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)"")).Count);
										if (val35 == null)
										{
											break;
										}
										T0 val36 = (T0)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[(int)val34].Status.Equals(frmMain.STATUS.Ready.ToString());
										if (val36 == null)
										{
											val34 = (T3)(val34 + 1);
											continue;
										}
										indexCart = (int)val34;
										((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[(int)val34].Status = frmMain.STATUS.Used.ToString();
										break;
									}
									T0 val37 = (T0)(indexCart == -1);
									if (val37 == null)
									{
										T0 val38 = (T0)(!frmMain.isRunning);
										if (val38 == null)
										{
											setMessage<T0, T1, T3>((T1)$"Add thẻ {val32}", (T0)1);
											T1 country_code = val7;
											T0 val39 = (T0)(!string.IsNullOrWhiteSpace((string)val11));
											if (val39 != null)
											{
												country_code = val11;
											}
											T0 val40 = addCart<T1, T0, T3>((T1)frmMain.listFBEntity[indexEntity].UID, val23, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg, country_code, (T1)frmMain.listFBEntity[indexEntity].Name, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[indexCart].Card_Number, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[indexCart].Card_Security, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[indexCart].Exp_Month, (T1)((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[indexCart].Exp_Year);
											T0 val41 = val40;
											if (val41 != null)
											{
												break;
											}
											((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[indexCart].Status = frmMain.STATUS.Declined.ToString();
											val32 = (T3)(val32 + 1);
											T0 val42 = (T0)((nint)val32 >= 5);
											if (val42 != null)
											{
												setMessage<T0, T1, T3>((T1)"Add thẻ không ok", (T0)1);
												break;
											}
											continue;
										}
										return;
									}
									setMessage<T0, T1, T3>((T1)"Hết thẻ", (T0)1);
									frmMain.isRunning = false;
									return;
								}
							}
							T0 val43 = val13;
							if (val43 != null)
							{
								T0 val44 = (T0)(!frmMain.isRunning);
								if (val44 != null)
								{
									return;
								}
								activeAct<T1, T0, T3>((T1)frmMain.listFBEntity[indexEntity].UID, val23, (T1)frmMain.listFBEntity[indexEntity].fb_dtsg);
							}
							T0 val45 = val14;
							if (val45 != null)
							{
								T0 val46 = (T0)(!frmMain.isRunning);
								if (val46 != null)
								{
									return;
								}
								createNewAds_3<T1, T0>(val23, (T1)frmMain.listFBEntity[indexEntity].TokenEAAG);
							}
							T0 val47 = (T0)1;
							T0 val48 = val16;
							if (val48 != null)
							{
								T0 val49 = (T0)(checkBlankPayment<T1, T0>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG, val23) == null);
								if (val49 != null)
								{
									val47 = (T0)0;
								}
							}
							T0 val50 = val47;
							if (val50 == null)
							{
								continue;
							}
							T0 val51 = val12;
							if (val51 != null)
							{
								((List<CreditCardEntity>)frmMain.listCreditCardEntity<T3, T0, T6, T1>((T1)""))[indexCart].Status = frmMain.STATUS.Ready.ToString();
							}
							T4 enumerator = (T4)((List<string>)val3).GetEnumerator();
							try
							{
								while (((List<string>.Enumerator*)(&enumerator))->MoveNext())
								{
									T1 current = (T1)((List<string>.Enumerator*)(&enumerator))->Current;
									T0 val52 = (T0)(!frmMain.isRunning);
									if (val52 == null)
									{
										shareParter<T1, T0, T3>((T1)frmMain.listFBEntity[indexEntity].TokenEAAG, val20, current, val23);
										continue;
									}
									return;
								}
							}
							finally
							{
								((IDisposable)(*(List<string>.Enumerator*)(&enumerator))).Dispose();
							}
						}
						else
						{
							setMessage<T0, T1, T3>((T1)"Tạo TK không ok", (T0)1);
						}
						continue;
					}
					setMessage<T0, T1, T3>((T1)"Không tạo được BM", (T0)0);
					break;
				}
				T0 val53 = (T0)(Create_BM_Count > 0);
				if (val53 == null)
				{
					setMessage<T0, T1, T3>((T1)"Không tạo được BM", (T0)1);
				}
			}
			else
			{
				setMessage<T0, T1, T3>((T1)"Không lấy được Token", (T0)1);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void updateStatus<T0, T1, T2>(T0 isDone)
	{
		//IL_0015: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		try
		{
			frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Select", (T2)System.Runtime.CompilerServices.Unsafe.As<T0, bool>(ref (T0)0).ToString());
			if (isDone == null)
			{
				frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Status", (T2)frmMain.STATUS.lỗi.ToString());
			}
			else
			{
				frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Status", (T2)frmMain.STATUS.Done.ToString());
			}
		}
		catch (Exception)
		{
			Thread.Sleep(1500);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void setMessage<T0, T1, T2>(T1 message, T0 addToColumnMessage)
	{
		//IL_000a: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		T0 val = (T0)(!string.IsNullOrWhiteSpace((string)message));
		if (val != null)
		{
			frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Step", message);
			if (addToColumnMessage != null)
			{
				frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Message", (T1)(frmMain.listFBEntity[indexEntity].Message + ">" + (string)message));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Login<T0, T1, T2, T3, T4, T5>(T0 A_2, T0 A_3, T0 code_2fa, T2 A_5, T2 A_6)
	{
		//IL_000b: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_0220: Expected O, but got I4
		//IL_0243: Expected O, but got I4
		//IL_02d4: Expected O, but got I4
		//IL_02f8: Expected O, but got I4
		//IL_0407: Expected O, but got I4
		//IL_042b: Expected O, but got I4
		//IL_043f: Expected O, but got I4
		//IL_04ca: Expected O, but got I4
		//IL_0555: Expected O, but got I4
		//IL_05fe: Expected O, but got I4
		//IL_0669: Expected O, but got I4
		//IL_06b5: Expected O, but got I4
		//IL_06e7: Expected O, but got I4
		//IL_06fc: Expected O, but got I4
		//IL_0749: Expected O, but got I4
		//IL_0796: Expected O, but got I4
		//IL_07e3: Expected O, but got I4
		//IL_0830: Expected O, but got I4
		//IL_08b4: Expected O, but got I4
		//IL_08eb: Expected O, but got I4
		//IL_0900: Expected O, but got I4
		//IL_094d: Expected O, but got I4
		//IL_099a: Expected O, but got I4
		//IL_0a18: Expected O, but got I4
		//IL_0a4a: Expected O, but got I4
		//IL_0a5f: Expected O, but got I4
		//IL_0aac: Expected O, but got I4
		try
		{
			T1 val = (T1)(!frmMain.isRunning);
			if (val != null)
			{
				return (T0)"";
			}
			setMessage<T1, T0, T2>((T0)"Đăng nhập...", (T1)1);
			T0 empty = (T0)string.Empty;
			T0 empty2 = (T0)string.Empty;
			empty2 = Login_2<T2, T1, T0, T4>(code_2fa);
			T1 val2 = (T1)(!((string)empty2 != string.Empty));
			if (val2 == null)
			{
				T0[] array = (T0[])(object)((string)empty2).Split((char[])(object)new T3[1] { (T3)124 });
				T0 val3 = (T0)((object[])(object)array)[1];
				T1 val4 = (T1)((string)val3 == string.Empty);
				if (val4 != null)
				{
					((object[])(object)array)[1] = "21312";
				}
				setMessage<T1, T0, T2>((T0)"Đăng nhập...", (T1)0);
				lsd = (string)((object[])(object)array)[0];
				empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_LOGIN") + "/device-based/login/async/?refsrc=deprecated&lwv=100", string.Concat((string[])(object)new T0[15]
				{
					(T0)"m_ts=",
					(T0)((object[])(object)array)[2],
					(T0)"&li=",
					(T0)((object[])(object)array)[3],
					(T0)"&try_number=0&unrecognized_tries=0&email=",
					A_2,
					(T0)"&prefill_contact_point=",
					A_2,
					(T0)"&prefill_source=browser_dropdown&prefill_type=password&first_prefill_source=browser_dropdown&first_prefill_type=contact_point&had_cp_prefilled=true&had_password_prefilled=true&is_smart_lock=false&bi_xrwh=0&bi_wvdp=%7B%22hwc%22%3Atrue%2C%22hwcr%22%3Atrue%2C%22has_dnt%22%3Atrue%2C%22has_standalone%22%3Afalse%2C%22wnd_toStr_toStr%22%3A%22function%20toString()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22hasPerm%22%3Atrue%2C%22permission_query_toString%22%3A%22function%20query()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22permission_query_toString_toString%22%3A%22function%20toString()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22has_seWo%22%3Atrue%2C%22has_meDe%22%3Atrue%2C%22has_creds%22%3Atrue%2C%22has_hwi_bt%22%3Afalse%2C%22has_agjsi%22%3Afalse%2C%22iframeProto%22%3A%22function%20get%20contentWindow()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22remap%22%3Afalse%2C%22iframeData%22%3A%7B%22hwc%22%3Atrue%2C%22hwcr%22%3Afalse%2C%22has_dnt%22%3Atrue%2C%22has_standalone%22%3Afalse%2C%22wnd_toStr_toStr%22%3A%22function%20toString()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22hasPerm%22%3Atrue%2C%22permission_query_toString%22%3A%22function%20query()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22permission_query_toString_toString%22%3A%22function%20toString()%20%7B%20%5Bnative%20code%5D%20%7D%22%2C%22has_seWo%22%3Atrue%2C%22has_meDe%22%3Atrue%2C%22has_creds%22%3Atrue%2C%22has_hwi_bt%22%3Afalse%2C%22has_agjsi%22%3Afalse%7D%7D&encpass=",
					(T0)HttpUtility.UrlEncode((string)A_3),
					(T0)"&fb_dtsg=",
					(T0)((object[])(object)array)[4],
					(T0)"&jazoest=24934&lsd=",
					(T0)((object[])(object)array)[0],
					(T0)"&__dyn=1KidAG1mwHwh8-t0BBBg9odE4a2i5U4e0C86u7E39x60lW4o3Bw4Ewk9E4W0om0MU0D2US0se229w4NwqU3rw9O1Aw4vw8W0iW220jG3qaw4kwbS1Lw9C&__csr=&__req=3&__a=AYnzf9AS6-gU6hCPqqzFPC8YRHaLrUKODEBxlqbPo1KFx89HCXojty-bFVo9kxXVOQfLotSowwg--b0PMIVR0L1TCaxvP0zfimAjqB66GRSebg&__user=0"
				}), "application/x-www-form-urlencoded")).ToString();
				empty = (T0)((object)httpRequest.Get("https://m.facebook.com/checkpoint/?", (RequestParams)null)).ToString();
				T0 empty3 = (T0)string.Empty;
				T0 empty4 = (T0)string.Empty;
				empty3 = (T0)Regex.Match((string)empty, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
				empty4 = (T0)Regex.Match((string)empty, "name=\"nh\" value=\"(.*?)\"").Groups[1].Value;
				jazoest = Regex.Match((string)empty, "name=\"jazoest\" value=\"(\\d+)\"").Groups[1].Value;
				T1 val5 = (T1)(((string)empty3).Length <= 5);
				if (val5 != null)
				{
					frmMain.listFBEntity[indexEntity].Error = (string)empty;
					return (T0)"";
				}
				T0 str = empty3;
				str = (T0)HttpUtility.UrlEncode((string)str);
				T1 val6 = (T1)(!string.IsNullOrWhiteSpace((string)code_2fa));
				if (val6 != null)
				{
					T0 val7 = ChromeControl.authenCode<T2, T1, T0, T4, T5, T3>(code_2fa);
					setMessage<T1, T0, T2>((T0)("Auth code: " + (string)val7), (T1)0);
					empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_LOGIN") + "/checkpoint/", string.Concat((string[])(object)new T0[6]
					{
						(T0)"fb_dtsg=",
						str,
						(T0)"&jazoest=2980&checkpoint_data=&approvals_code=",
						val7,
						(T0)"&codes_submitted=0&submit[Submit Code]=Submit Code&nh=",
						empty4
					}), "application/x-www-form-urlencoded")).ToString();
					str = (T0)Regex.Match((string)empty, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
					T1 val8 = (T1)(!((string)str != string.Empty));
					if (val8 != null)
					{
						frmMain.listFBEntity[indexEntity].Error = (string)empty;
						return (T0)"";
					}
					str = (T0)HttpUtility.UrlEncode((string)str);
					setMessage<T1, T0, T2>((T0)("Submit code: " + (string)val7), (T1)0);
					empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_LOGIN") + "/checkpoint/?ref=dbl", string.Concat((string[])(object)new T0[10]
					{
						(T0)"fb_dtsg=",
						str,
						(T0)"&jazoest=",
						(T0)jazoest,
						(T0)"&checkpoint_data=&name_action_selected=save_device&submit%5BContinue%5D=Continue&nh=",
						empty4,
						(T0)"&fb_dtsg=",
						str,
						(T0)"&jazoest=",
						(T0)jazoest
					}), "application/x-www-form-urlencoded")).ToString();
				}
				T0 value = (T0)Regex.Match(((object)httpRequest.Cookies).ToString(), "xs=(.*[^\\s])").Groups[1].Value;
				T1 val9 = (T1)(!httpRequest.Address.ToString().Contains("home.php") && ((string)value).Length <= 15);
				if (val9 != null)
				{
					T1 val10 = (T1)httpRequest.Address.ToString().Contains("checkpoint");
					if (val10 != null)
					{
						setMessage<T1, T0, T2>((T0)"Step 1", (T1)1);
						empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_LOGIN") + "/checkpoint/", string.Concat((string[])(object)new T0[9]
						{
							(T0)"fb_dtsg=",
							str,
							(T0)"&jazoest=",
							(T0)jazoest,
							(T0)"&checkpoint_data=&submit%5BContinue%5D=Continue&nh=",
							empty4,
							(T0)"&fb_dtsg=",
							str,
							(T0)"&jazoest=21141"
						}), "application/x-www-form-urlencoded")).ToString();
						setMessage<T1, T0, T2>((T0)"Step 2", (T1)1);
						empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_LOGIN") + "/checkpoint/", string.Concat((string[])(object)new T0[9]
						{
							(T0)"fb_dtsg=",
							str,
							(T0)"&jazoest=",
							(T0)jazoest,
							(T0)"&checkpoint_data=&submit%5BThis+was+me%5D=This+Was+Me&nh=",
							empty4,
							(T0)"&fb_dtsg=",
							str,
							(T0)"&jazoest=21141"
						}), "application/x-www-form-urlencoded")).ToString();
						setMessage<T1, T0, T2>((T0)"Step 3", (T1)1);
						empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_M_FACEBOOK_LOGIN") + "/checkpoint/", string.Concat((string[])(object)new T0[9]
						{
							(T0)"fb_dtsg=",
							str,
							(T0)"&jazoest=",
							(T0)jazoest,
							(T0)"&checkpoint_data=&name_action_selected=save_device&submit%5BContinue%5D=Continue&nh=",
							empty4,
							(T0)"&fb_dtsg=",
							str,
							(T0)"&jazoest=21141"
						}), "application/x-www-form-urlencoded")).ToString();
						empty3 = (T0)Regex.Match((string)empty, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
						T1 val11 = (T1)(((string)empty3).Length > 20);
						if (val11 != null)
						{
							return empty3;
						}
						empty = (T0)((object)httpRequest.Get("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/overview", (RequestParams)null)).ToString();
						empty3 = (T0)Regex.Match(Regex.Unescape((string)empty), "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
						T1 val12 = (T1)(((string)empty3).Length > 20);
						if (val12 != null)
						{
							return empty3;
						}
					}
				}
				else
				{
					empty = (T0)((object)httpRequest.Get("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/overview", (RequestParams)null)).ToString();
					T1 val13 = (T1)((string)empty).Contains("name=\"fb_dtsg\"");
					if (val13 != null)
					{
						empty3 = (T0)Regex.Match((string)empty, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
						T1 val14 = (T1)(((string)empty3).Length > 20);
						if (val14 != null)
						{
							T1 val15 = (T1)((string)empty).Contains("__spin_r");
							if (val15 != null)
							{
								T0 value2 = (T0)Regex.Match((string)empty, "spin_r\":(.*?),").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].__spin_r = (string)value2;
							}
							T1 val16 = (T1)((string)empty).Contains("__spin_t");
							if (val16 != null)
							{
								T0 value3 = (T0)Regex.Match((string)empty, "spin_t\":(.*?),").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].__spin_t = (string)value3;
							}
							T1 val17 = (T1)((string)empty).Contains("hsi");
							if (val17 != null)
							{
								T0 value4 = (T0)Regex.Match((string)empty, "hsi\":\"(.*?)\"").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].hsi = (string)value4;
							}
							T1 val18 = (T1)((string)empty).Contains("async_get_token");
							if (val18 != null)
							{
								T0 value5 = (T0)Regex.Match((string)empty, "async_get_token\":\"(.*?)\"").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].async_get_token = (string)value5;
							}
							T1 val19 = (T1)((string)empty).Contains("jazoest\" value=\"");
							if (val19 != null)
							{
								T0 value6 = (T0)Regex.Match((string)empty, "jazoest\" value=\"(.*?)\"").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].jazoest = (string)value6;
							}
							return empty3;
						}
					}
					empty = (T0)((object)httpRequest.Get("https://m" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/composer/ocelot/async_loader/?publisher=feed", (RequestParams)null)).ToString();
					T1 val20 = (T1)((string)empty).Contains("name=\"fb_dtsg\"");
					if (val20 != null)
					{
						empty3 = (T0)Regex.Match(Regex.Unescape((string)empty), "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
						T1 val21 = (T1)(((string)empty3).Length > 20);
						if (val21 != null)
						{
							T1 val22 = (T1)((string)empty).Contains("__spin_r");
							if (val22 != null)
							{
								T0 value7 = (T0)Regex.Match((string)empty, "spin_r\":(.*?),").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].__spin_r = (string)value7;
							}
							T1 val23 = (T1)((string)empty).Contains("__spin_t");
							if (val23 != null)
							{
								T0 value8 = (T0)Regex.Match((string)empty, "spin_t\":(.*?),").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].__spin_t = (string)value8;
							}
							T1 val24 = (T1)((string)empty).Contains("async_get_token");
							if (val24 != null)
							{
								T0 value9 = (T0)Regex.Match((string)empty, "async_get_token\":\"(.*?)\"").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].async_get_token = (string)value9;
							}
							return empty3;
						}
					}
					empty = (T0)((object)httpRequest.Get("https://m" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"), (RequestParams)null)).ToString();
					T1 val25 = (T1)((string)empty).Contains("name=\"fb_dtsg\"");
					if (val25 != null)
					{
						empty3 = (T0)Regex.Match((string)empty, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
						T1 val26 = (T1)(((string)empty3).Length > 20);
						if (val26 != null)
						{
							T1 val27 = (T1)((string)empty).Contains("__spin_r");
							if (val27 != null)
							{
								T0 value10 = (T0)Regex.Match((string)empty, "spin_r\":(.*?),").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].__spin_r = (string)value10;
							}
							T1 val28 = (T1)((string)empty).Contains("__spin_t");
							if (val28 != null)
							{
								T0 value11 = (T0)Regex.Match((string)empty, "spin_t\":(.*?),").Groups[1].Value;
								frmMain.listFBEntity[indexEntity].__spin_t = (string)value11;
							}
							return empty3;
						}
					}
				}
				return (T0)"";
			}
			frmMain.listFBEntity[indexEntity].Error = (string)empty2;
			return (T0)"";
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T2 Login_2<T0, T1, T2, T3>(T2 A_1)
	{
		//IL_0002: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0053: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00f8: Expected O, but got I4
		//IL_025c: Expected O, but got I4
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_026e: Expected O, but got I4
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_02ff: Expected O, but got I4
		//IL_0310: Expected O, but got I4
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)(!frmMain.isRunning);
			if (val2 == null)
			{
				try
				{
					T2 empty = (T2)string.Empty;
					T2 empty2 = (T2)string.Empty;
					T2 empty3 = (T2)string.Empty;
					T2 empty4 = (T2)string.Empty;
					T2 empty5 = (T2)string.Empty;
					T2 empty6 = (T2)string.Empty;
					T2 empty7 = (T2)string.Empty;
					T2 empty8 = (T2)string.Empty;
					httpRequest.Cookies = new CookieDictionary(false);
					T0 val3 = (T0)0;
					while (true)
					{
						T1 val4 = (T1)((nint)val3 < 10);
						if (val4 != null)
						{
							T1 val5 = (T1)(!frmMain.isRunning);
							if (val5 != null)
							{
								break;
							}
							httpRequest.Referer = "https://m.facebook.com/login/?next&ref=dbl&fl&login_from_aymh=1&refid=8";
							empty = (T2)((object)httpRequest.Get("https://m" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/login/?next&ref=dbl&fl&login_from_aymh=1&refid=8", (RequestParams)null)).ToString();
							empty5 = (T2)Regex.Match((string)empty, "name=\"lsd\" value=\"(.*?)\"").Groups[1].Value;
							T1 val6 = (T1)((string)empty5 != string.Empty);
							if (val6 != null)
							{
								T1 val7 = (T1)httpRequest.Address.ToString().Contains("cookie");
								if (val7 != null)
								{
									empty = (T2)((object)httpRequest.Post("https://mbasic." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/basic-lite/cookie/consent/?next_uri=https%3A%2F%2Fmbasic.facebook.com%2F&sid=McsWeBQePHbfcA2OEO4o&basic_lite_source_surface=COOKIE_CONSENT_PAGE", "jazoest=2948&lsd=" + (string)empty5 + "&accept_consent=1", "application/x-www-form-urlencoded")).ToString();
									httpRequest.Referer = "https://m." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/login/?next&ref=dbl&fl&login_from_aymh=1&refid=8";
									empty = (T2)((object)httpRequest.Get("https://m." + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/login/?next&ref=dbl&fl&login_from_aymh=1&refid=8", (RequestParams)null)).ToString();
								}
								empty2 = (T2)Regex.Match((string)empty, "name=\"m_ts\" value=\"(\\d+)\"").Groups[1].Value;
								empty3 = (T2)Regex.Match((string)empty, "name=\"li\" value=\"(.*?)\"").Groups[1].Value;
								empty5 = (T2)Regex.Match((string)empty, "name=\"lsd\" value=\"(.*?)\"").Groups[1].Value;
								empty6 = (T2)Regex.Match((string)empty, "\"dtsg\":{\"token\":\"(.*?)\",").Groups[1].Value;
								empty7 = (T2)Regex.Match((string)empty, "privacy_mutation_token=(.*?)&amp").Groups[1].Value;
								empty8 = (T2)Regex.Match((string)empty, "\"encrypted\":\"(.*?)\"}").Groups[1].Value;
								T1 val8 = (T1)((string)empty5 != string.Empty);
								if (val8 != null)
								{
									return (T2)string.Concat((string[])(object)new T2[13]
									{
										empty5,
										(T2)"|",
										empty4,
										(T2)"|",
										empty2,
										(T2)"|",
										empty3,
										(T2)"|",
										empty6,
										(T2)"|",
										empty7,
										(T2)"|",
										empty8
									});
								}
							}
							val3 = (T0)(val3 + 1);
							continue;
						}
						return (T2)"";
					}
					return (T2)"";
				}
				catch (Exception)
				{
					val = (T0)(val + 1);
					T1 val9 = (T1)((nint)val < 5);
					if (val9 == null)
					{
						break;
					}
				}
				continue;
			}
			return (T2)"";
		}
		return (T2)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 getTokenEAAG<T0, T1, T2, T3, T4, T5>()
	{
		//IL_0056: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_0202: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_022f: Expected O, but got I4
		T0 empty = (T0)string.Empty;
		try
		{
			T0 empty2 = (T0)string.Empty;
			empty = (T0)((object)httpRequest.Get("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/content_management", (RequestParams)null)).ToString();
			T1 val = (T1)httpRequest.Address.ToString().Contains("twofactor");
			if (val == null)
			{
				Console.WriteLine(httpRequest.Address.ToString());
			}
			else
			{
				while (true)
				{
					T1 val2 = (T1)(!frmMain.isRunning);
					if (val2 == null)
					{
						T1 val3 = (T1)(frmMain.listFBEntity[indexEntity].Code2FA == null);
						if (val3 != null)
						{
							frmMain.listFBEntity[indexEntity].Code2FA = "";
						}
						empty2 = ChromeControl.authenCode<T2, T1, T0, T3, T4, T5>((T0)frmMain.listFBEntity[indexEntity].Code2FA);
						empty = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_2FA"), string.Concat((string[])(object)new T0[7]
						{
							(T0)"approvals_code=",
							empty2,
							(T0)"&save_device=false&__user=",
							(T0)frmMain.listFBEntity[indexEntity].UID,
							(T0)"&__a=1&__dyn=&__csr=&__req=9&__hs=19108.BP:DEFAULT.2.0.0.0.&dpr=1.5&__ccg=EXCELLENT&__rev=1005404255&__s=n7y7to:i7topm:vo61pg&__hsi=7090761015361603355-0&__comet_req=0&fb_dtsg=",
							(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T0)"&jazoest=21954&lsd=Qf7z54nRePaFgnLxvbGQyN&__spin_r=1005404255&__spin_b=trunk&__spin_t=1650946451&__jssesw=1"
						}), "application/x-www-form-urlencoded")).ToString();
						T1 val4 = (T1)((string)empty).Contains("\"codeConfirmed\":true");
						if (val4 != null)
						{
							break;
						}
						Thread.Sleep(5000);
						continue;
					}
					return (T1)0;
				}
				empty = (T0)((object)httpRequest.Get("https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/content_management", (RequestParams)null)).ToString();
			}
			T0 val5 = (T0)("EAAG" + Regex.Match((string)empty, "\"EAAG(\\w+)\"").Groups[1].Value);
			T1 val6 = (T1)(((string)val5).Length > 4);
			if (val6 != null)
			{
				frmMain.listFBEntity[indexEntity].TokenEAAG = (string)val5;
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T3 getTokenEAAG_EEAB<T0, T1, T2, T3>()
	{
		//IL_0003: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007d: Expected O, but got I4
		//IL_02ff: Expected O, but got I4
		//IL_032d: Expected O, but got I4
		//IL_0335: Expected O, but got I4
		try
		{
			T0 val = (T0)0;
			T3 val6;
			do
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(HttpRequest));
				((HttpRequest)val2).SslProtocols = SslProtocols.Tls12;
				((HttpRequest)val2).AllowAutoRedirect = true;
				((HttpRequest)val2).KeepAlive = true;
				((HttpRequest)val2).AddHeader("viewport-width", "1365");
				((HttpRequest)val2).AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"105\", \"Not)A;Brand\";v=\"8\", \"Chromium\";v=\"105\"");
				((HttpRequest)val2).AddHeader("sec-ch-ua-mobile", "?0");
				((HttpRequest)val2).AddHeader("sec-ch-ua-platform", "\"Windows\"");
				((HttpRequest)val2).AddHeader("sec-ch-prefers-color-scheme", "dark");
				((HttpRequest)val2).AddHeader("Upgrade-Insecure-Requests", "1");
				((HttpRequest)val2).Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
				((HttpRequest)val2).AddHeader("Sec-Fetch-Site", "none");
				((HttpRequest)val2).AddHeader("Sec-Fetch-Mode", "navigate");
				((HttpRequest)val2).AddHeader("Sec-Fetch-User", "?1");
				((HttpRequest)val2).AddHeader("Sec-Fetch-Dest", "document");
				T2 input = (T2)((object)httpRequest.Cookies).ToString();
				T2 val3 = (T2)string.Concat((string[])(object)new T2[10]
				{
					(T2)"c_user=",
					(T2)Regex.Match((string)input, "c_user=(\\d+)").Groups[1].Value,
					(T2)"; xs=",
					(T2)Regex.Match((string)input, "xs=(.*?);").Groups[1].Value,
					(T2)"; fr=",
					(T2)Regex.Match((string)input, "fr=(.*?);").Groups[1].Value,
					(T2)"; datr=",
					(T2)Regex.Match((string)input, "datr=(.*?);").Groups[1].Value,
					(T2)"; sb=",
					(T2)Regex.Match((string)input, "sb=(.*?);").Groups[1].Value
				});
				((HttpRequest)val2).SetCookie((string)val3, true);
				T2 input2 = (T2)((object)((HttpRequest)val2).Get("https://business.facebook.com/business_locations", (RequestParams)null)).ToString();
				T2 value = (T2)Regex.Match((string)input2, "\"adAccountID\":\"(\\d+)\",").Groups[1].Value;
				T3 val4 = (T3)((string)value == string.Empty);
				if (val4 != null)
				{
					input2 = (T2)((object)((HttpRequest)val2).Post("https://business.facebook.com/business_locations")).ToString();
					Thread.Sleep(1000);
					input2 = (T2)((object)((HttpRequest)val2).Get("https://business.facebook.com/business_locations", (RequestParams)null)).ToString();
					value = (T2)Regex.Match((string)input2, "\"adAccountID\":\"(\\d+)\",").Groups[1].Value;
				}
				((HttpRequest)val2).Referer = "https://www.facebook.com/ads/manager/account_settings/information/?act=" + (string)value + "&pid=p1&page=account_settings&tab=account_billing_settings";
				input2 = (T2)((object)((HttpRequest)val2).Get("https://adsmanager.facebook.com/adsmanager/manage/campaigns?act=" + (string)value, (RequestParams)null)).ToString();
				T2 value2 = (T2)Regex.Match((string)input2, "window.__accessToken=\"(.*?)\"").Groups[1].Value;
				T3 val5 = (T3)((string)value2 != string.Empty);
				if (val5 == null)
				{
					val = (T0)(val + 1);
					val6 = (T3)((nint)val <= 3);
					continue;
				}
				frmMain.listFBEntity[indexEntity].TokenEAAB = (string)value2;
				return (T3)1;
			}
			while (val6 != null);
		}
		catch
		{
		}
		return (T3)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 getUID<T0, T1>(T0 A_1)
	{
		//IL_00a4: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		try
		{
			T0 input = (T0)((object)httpRequest.Get("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v11.0/me?fields=name%2Cid&access_token=" + (string)A_1, (RequestParams)null)).ToString();
			T0 value = (T0)Regex.Match((string)input, "\"id\": \"(\\d+)\"").Groups[1].Value;
			T0 value2 = (T0)Regex.Match((string)input, "\"name\": \"(.*?)\",").Groups[1].Value;
			frmMain.listFBEntity[indexEntity].Name = (string)value2;
			frmMain.listFBEntity[indexEntity].UID = (string)value;
			return (T1)1;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 createBM<T0, T1, T2, T3, T4>(T0 A_1, T0 A_2, T0 A_3, T0 A_4, T0 A_5, T1 Link_2)
	{
		//IL_0014: Expected O, but got I4
		//IL_0223: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		//IL_033a: Expected O, but got I4
		//IL_0394: Expected O, but got I4
		//IL_03b8: Expected O, but got I4
		//IL_03f8: Expected O, but got I4
		//IL_040e: Expected O, but got I4
		//IL_0424: Expected O, but got I4
		//IL_0444: Expected O, but got I4
		//IL_0483: Expected O, but got I4
		//IL_04bf: Expected O, but got I4
		//IL_04d5: Expected O, but got I4
		//IL_04f5: Expected O, but got I4
		//IL_050b: Expected O, but got I4
		//IL_054a: Expected O, but got I4
		//IL_055a: Expected O, but got I4
		//IL_0561: Expected O, but got I4
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Expected O, but got Unknown
		//IL_0595: Expected O, but got I4
		try
		{
			A_3 = (T0)HttpUtility.UrlEncode((string)A_3);
			T1 val = (T1)(((string)A_2).Length == 0);
			if (val != null)
			{
				A_2 = ChromeControl.getFirstName<T1, T0, T2>();
			}
			A_2 = (T0)((string)A_2).ToLower();
			T0 val2 = (T0)((string)A_2).Substring(0, 1);
			T0 val3 = (T0)((string)A_2).Substring(1);
			val2 = (T0)((string)val2).ToUpper();
			A_2 = (T0)((string)val2 + (string)val3);
			while (true)
			{
				T0 val4 = (T0)$"{StringCipher.getPageName<T3, T1, T0, T4>()} {System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)rnd.Next(111, 999)).ToString()}";
				T0 firstName = ChromeControl.getFirstName<T1, T0, T2>();
				T0 lastName = ChromeControl.getLastName<T1, T0, T2>();
				T0 val5 = (T0)string.Format("{0}{1}{2}@gmail.com", ((string)firstName).Replace(" ", ""), ((string)lastName).Replace(" ", ""), (T2)rnd.Next(111, 999));
				val5 = (T0)((string)val5).ToLower();
				T0 val6 = (T0)"";
				setMessage<T1, T0, T2>((T0)"Đang tạo BM", (T1)0);
				httpRequest.Referer = "https://business" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM");
				if (Link_2 != null)
				{
					T0 str = (T0)string.Concat((string[])(object)new T0[11]
					{
						(T0)"{\"input\":{\"client_mutation_id\":\"6\",\"actor_id\":\"",
						(T0)frmMain.listFBEntity[indexEntity].UID,
						(T0)"\",\"business_name\":\"",
						val4,
						(T0)"\",\"user_first_name\":\"",
						firstName,
						(T0)"\",\"user_last_name\":\"",
						lastName,
						(T0)"\",\"user_email\":\"",
						val5,
						(T0)"\",\"creation_source\":\"MBS_BUSINESS_CREATION_IN_SCOPE_SELECTOR_FOOTER\"}}"
					});
					str = (T0)HttpUtility.UrlEncode((string)str);
					T0 val7 = (T0)string.Concat((string[])(object)new T0[15]
					{
						(T0)"av=",
						(T0)frmMain.listFBEntity[indexEntity].UID,
						(T0)"&__usid=6-Trr6x8staokd2%3APrr6x8q1lohuro%3A0-Arr6x8s10acc0e-RV%3D6%3AF%3D&__user=",
						(T0)frmMain.listFBEntity[indexEntity].UID,
						(T0)"&__a=1&__dyn=7xeUmxa3-Q5E5ObwKBWobVo9E4a2i5U4e1FxebzEdEC2q7Eiw8OdwJw5ux60Vo1upEK12wcG0KEswIwuo662y11xmfw5ZKdwnU5W0IU9k2C2218wnE6a1uwZx2ew8OfK0EUjwVwGwso5a2W2K1HwywnEcU7K58G0LE6W4UpwSyES0gq0Lo4K2e3u360yEco5C&__csr=&__req=13&__hs=19424.BP%3Abizweb_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=",
						(T0)frmMain.listFBEntity[indexEntity].__spin_r,
						(T0)"&__s=syydno%3Amp3cdy%3Ab6akik&__hsi=7208069246683211537&__comet_req=0&fb_dtsg=",
						(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T0)"&jazoest=24923&lsd=dumUc5HWUObhoUALNxmRAk&__aaid=904682904068782&__spin_r=",
						(T0)frmMain.listFBEntity[indexEntity].__spin_r,
						(T0)"&__spin_b=trunk&__spin_t=",
						(T0)frmMain.listFBEntity[indexEntity].__spin_t,
						(T0)"&__jssesw=1&qpl_active_flow_ids=558502430&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBusinessCreationMutationMutation&variables=",
						str,
						(T0)"&server_timestamps=true&doc_id=7183377418404152&fb_api_analytics_tags=%5B%22qpl_active_flow_ids%3D558502430%22%5D"
					});
					T0 val8 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { val7 }), "application/x-www-form-urlencoded")).ToString();
					T1 val9 = (T1)((string)val8).Contains("1690091");
					if (val9 != null)
					{
						A_2 = ChromeControl.getFirstName<T1, T0, T2>();
						continue;
					}
					T1 val10 = (T1)((string)val8).Contains("1404163");
					if (val10 != null)
					{
						break;
					}
					T1 val11 = (T1)((string)val8).Contains("502 Bad Gateway");
					if (val11 != null)
					{
						return (T0)"502 Bad Gateway";
					}
					T1 val12 = (T1)((string)val8).Contains("1690114");
					if (val12 != null)
					{
						return (T0)"1690114";
					}
					T1 val13 = (T1)((string)val8).Contains("1501092823525282");
					if (val13 != null)
					{
						return (T0)"1501092823525282";
					}
					val6 = (T0)Regex.Match((string)val8, "\"id\":\"(\\d+)\"").Groups[1].Value;
					T1 val14 = (T1)(((string)val6).Length <= 5);
					if (val14 != null)
					{
						return (T0)"";
					}
				}
				else
				{
					T0 val15 = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[10]
					{
						(T0)ResouceControl.getResouce("RESOUCE_BUSINESS.FACEBOOK"),
						(T0)"business/create_account/?brand_name=",
						(T0)((string)val4).Replace(" ", "%20"),
						(T0)"&first_name=",
						firstName,
						(T0)"&last_name=",
						lastName,
						(T0)"&email=",
						val5,
						(T0)"&timezone_id=132&business_category=OTHER"
					}), string.Concat((string[])(object)new T0[1] { (T0)string.Concat((string[])(object)new T0[5]
					{
						(T0)"__user=",
						A_1,
						(T0)"&__a=1 &__dyn= &__csr= &__req=r &__hs= &dpr=1 &__ccg=EXCELLENT&__rev=1006554990&__s=&__hsi=&__comet_req=0&fb_dtsg=",
						A_4,
						(T0)"&jazoest= &lsd= &__rev=1006554990 &__spin_b=trunk &__spin_t=1667815251 &__jssesw=1"
					}) }), "application/x-www-form-urlencoded")).ToString();
					Regex.Unescape((string)val15);
					T1 val16 = (T1)((string)val15).Contains("1690091");
					if (val16 != null)
					{
						A_2 = ChromeControl.getFirstName<T1, T0, T2>();
						continue;
					}
					T1 val17 = (T1)((string)val15).Contains("1404163");
					if (val17 != null)
					{
						return (T0)"1404163";
					}
					T1 val18 = (T1)((string)val15).Contains("502 Bad Gateway");
					if (val18 != null)
					{
						return (T0)"502 Bad Gateway";
					}
					T1 val19 = (T1)((string)val15).Contains("1690114");
					if (val19 != null)
					{
						return (T0)"1690114";
					}
					T1 val20 = (T1)((string)val15).Contains("1501092823525282");
					if (val20 != null)
					{
						return (T0)"1501092823525282";
					}
					val6 = (T0)Regex.Match((string)val15, "business_id=(\\d+)").Groups[1].Value;
					T1 val21 = (T1)(((string)val6).Length <= 5);
					if (val21 != null)
					{
						return (T0)"";
					}
				}
				T1 val22 = (T1)(!string.IsNullOrWhiteSpace((string)val6));
				if (val22 != null)
				{
					T2 val23 = (T2)0;
					while (true)
					{
						try
						{
							File.AppendAllText("BM_ID.txt", (string)val6 + "|");
						}
						catch
						{
							Thread.Sleep(500);
							val23 = (T2)(val23 + 1);
							T1 val24 = (T1)((nint)val23 < 5);
							if (val24 == null)
							{
								break;
							}
							continue;
						}
						break;
					}
				}
				return val6;
			}
			return (T0)"1404163";
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 createAds<T0, T1, T2>(T0 A_1, T0 A_2, T0 A_3, T0 A_4, T0 A_5, T0 A_6, T1 A_7, T0 A_8)
	{
		//IL_0013: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		T0 empty = (T0)string.Empty;
		try
		{
			setMessage<T1, T0, T2>((T0)"Đang tạo TKBM", (T1)0);
			T0 val = (T0)string.Empty;
			T0 val2 = (T0)"BrandResourceRequests.brands";
			T1 val3 = (T1)((string)val2 == string.Empty);
			if (val3 == null)
			{
				T1 val4 = (T1)(A_7 == null);
				if (val4 != null)
				{
					A_8 = A_5;
				}
				empty = (T0)((object)httpRequest.Post(string.Concat((string[])(object)new T0[6]
				{
					(T0)"https://graph",
					(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
					(T0)"/v7.0/",
					A_5,
					(T0)"/adaccount?access_token=",
					A_6
				}), string.Concat((string[])(object)new T0[11]
				{
					(T0)"_index=36&_reqName=object%3Abrand%2Fadaccount&_reqSrc=",
					val2,
					(T0)"&currency=",
					A_4,
					(T0)"&end_advertiser=",
					A_8,
					(T0)"&locale=en_US&media_agency=UNFOUND&method=post&name=",
					A_1,
					(T0)"&partner=UNFOUND&po_number=&pretty=0&suppress_http_code=1&timezone_id=",
					A_3,
					(T0)"&xref=fbb40cc0a7146"
				}), "application/x-www-form-urlencoded")).ToString();
				T0 value = (T0)Regex.Match((string)empty, "act_(\\d+)").Groups[1].Value;
				T1 val5 = (T1)((string)value == string.Empty);
				if (val5 != null)
				{
					value = (T0)Regex.Match((string)empty, "act_(\\d+),").Groups[1].Value;
				}
				T1 val6 = (T1)(!((string)value != string.Empty));
				if (val6 == null)
				{
					if (A_7 != null)
					{
						val = (T0)("|Connect BM: " + (string)A_8);
					}
					setMessage<T1, T0, T2>((T0)("Tạo TKBM ok " + (string)val), (T1)1);
					return value;
				}
				setMessage<T1, T0, T2>((T0)"Tạo TKBM lỗi", (T1)1);
				return (T0)"";
			}
			return (T0)"";
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 shareParter<T0, T1, T2>(T0 A_1, T0 A_2, T0 A_3, T0 A_4)
	{
		//IL_000e: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)"Đang share đối tác...", (T1)0);
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[11]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v11.0/act_"),
				A_4,
				(T0)"/agencies?access_token=",
				A_1,
				(T0)"&_reqName=adaccount/agencies&_reqSrc=BrandAgencyActions.brands&accountId=",
				A_4,
				(T0)"&acting_brand_id=",
				A_2,
				(T0)"&business=",
				A_3,
				(T0)"&locale=vi_VN&method=post&permitted_tasks=[\"ADVERTISE\",\"ANALYZE\",\"DRAFT\",\"MANAGE\"]&pretty=0&suppress_http_code=1&xref=fb54e4680eb10c&method=post"
			}), (RequestParams)null)).ToString();
			T1 val2 = (T1)(!((string)val).Contains("\"success\":true"));
			if (val2 == null)
			{
				setMessage<T1, T0, T2>((T0)"Share đối tác ok", (T1)1);
				return (T1)1;
			}
			setMessage<T1, T0, T2>((T0)"Share đối tác lỗi", (T1)1);
			Thread.Sleep(1500);
			return (T1)0;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 listBusinessUser<T0>(T0 bm_id, T0 TokenEAAG)
	{
		try
		{
			T0 val = (T0)((object)httpRequest.Get("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/v11.0/{bm_id}?fields=business_users&access_token={TokenEAAG}", (RequestParams)null)).ToString();
			return (T0)Regex.Match(((string)val).Replace(" ", ""), "\"id\":\"(\\d+)\"").Groups[1].Value;
		}
		catch
		{
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 shareToUser<T0, T1, T2, T3>(T0 A_1, T0 A_2, T0 A_3, T0 A_4)
	{
		//IL_000e: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00da: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T3>((T0)"Phân quyền User", (T1)0);
			T0 val = (T0)string.Concat((string[])(object)new T0[11]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v11.0/act_",
				A_4,
				(T0)"/userpermissions?business=",
				A_2,
				(T0)"&tasks=[\"ANALYZE\", \"MANAGE\", \"DRAFT\", \"ADVERTISE\"]&user=",
				A_3,
				(T0)"&access_token=",
				A_1,
				(T0)"&method=post"
			});
			T0 val2 = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[1] { val }), (RequestParams)null)).ToString();
			T1 val3 = (T1)(!((string)val2).Contains("success\": true"));
			if (val3 != null)
			{
				setMessage<T1, T0, T3>((T0)"Phân quyền lỗi", (T1)0);
				return (T1)0;
			}
			setMessage<T1, T0, T3>((T0)"Phân quyền ok", (T1)0);
			return (T1)1;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string updateBillingInfo(string act, string currency, string city, string country_code, string state, string street1, string zip, string business_name, string timezone, string UID)
	{
		try
		{
			setMessage<bool, string, int>("Đổi thông tin TK 1", addToColumnMessage: false);
			string input = ((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat("variables={\"input\":{\"billable_account_payment_legacy_account_id\":\"" + act + "\",\"currency\":" + currency + ",\"logging_data\":{\"logging_counter\":11,\"logging_id\":\"82833808\"},\"tax\":{\"business_address\":{\"city\":\"" + city + "\",\"country_code\":\"" + country_code + "\",\"state\":\"" + state + "\",\"street1\":\"" + street1 + "\",\"street2\":\"\",\"zip\":\"" + zip + "\"},\"business_name\":\"" + business_name + "\",\"is_personal_use\":false},\"timezone\":null,\"actor_id\":\"" + UID + "\",\"client_mutation_id\":\"2\"}}&server_timestamps=true&doc_id=4699960830024588"), "application/x-www-form-urlencoded")).ToString();
			string value = Regex.Match(input, "\"payment_legacy_account_id\":\"(\\d+)\",").Groups[1].Value;
			if (value.Length <= 9)
			{
				return string.Empty;
			}
			return value;
		}
		catch
		{
		}
		return "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool updateBillingInfo(string act, string currency, string city, string country_code, string state, string street1, string zip, string business_name, string timezone, string UID, string fb_dtsg, string tax_id)
	{
		try
		{
			setMessage<bool, string, int>("Đổi thông tin TK", addToColumnMessage: false);
			string str = "{\"input\":{\"billable_account_payment_legacy_account_id\":\"" + act + "\",\"currency\":\"" + currency + "\",\"logging_data\":{\"logging_counter\":1,\"logging_id\":\"1\"},\"tax\":{\"business_address\":{\"city\":\"" + city + "\",\"country_code\":\"" + country_code + "\",\"state\":\"" + state + "\",\"street1\":\"" + street1 + "\",\"street2\":\"\",\"zip\":\"" + zip + "\"},\"business_name\":\"" + business_name + "\",\"is_personal_use\":false,\"tax_exempt\":false,\"tax_id\":\"" + tax_id + "\"},\"timezone\":\"" + timezone + "\",\"actor_id\":\"" + UID + "\",\"client_mutation_id\":\"2\"}}";
			str = HttpUtility.UrlEncode(str);
			string text = "av=" + UID + "&__usid=&__user=" + UID + "&__a=&__dyn=&__csr=&__req=&__hs=&dpr=&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=&fb_dtsg=" + fb_dtsg + "&jazoest=&lsd=&__spin_r=&__spin_b=&__spin_t=&__jssesw=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=BillingAccountInformationUtilsUpdateAccountMutation&variables=" + str + "&server_timestamps=true&doc_id=4699960830024588";
			string text2 = ((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat(text), "application/x-www-form-urlencoded")).ToString();
			if (!text2.Contains("api_error_code"))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 changeNameAct<T0, T1, T2>(T0 act, T0 newName, T0 TokenEAAG)
	{
		//IL_0014: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)("Đổi tên: " + (string)newName), (T1)0);
			newName = (T0)((string)newName).Replace(" ", "%20");
			T0 str = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"_reqName=adaccount&_reqSrc=AdAccountActions.brands&accountId=",
				act,
				(T0)"&invoicing_emails=%5B%5D&locale=en_US&method=post&name=",
				newName,
				(T0)"&pretty=0&suppress_http_code=1&xref=f16fec81a820a7"
			});
			str = (T0)HttpUtility.UrlEncode((string)str);
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[8]
			{
				(T0)"https://graph",
				(T0)ResouceControl.getResouce("RESOUCE_FACEBOOK_COM"),
				(T0)"/v11.0/act_",
				act,
				(T0)"?method=post&name=",
				newName,
				(T0)"&access_token=",
				TokenEAAG
			}), (RequestParams)null)).ToString();
			T1 val2 = (T1)((string)val).Contains("success\": true");
			if (val2 != null)
			{
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 disableAct<T0, T1, T2>(T0 UID, T0 Act, T0 fb_dtsg)
	{
		//IL_000e: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_0214: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)"vhh tk", (T1)1);
			httpRequest.KeepAlive = true;
			httpRequest.AddHeader("viewport-width", "1229");
			httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
			httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
			httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
			httpRequest.UserAgent = strUserAgentDesktop;
			httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
			httpRequest.AddHeader("Sec-Fetch-Site", "none");
			httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
			httpRequest.AddHeader("Sec-Fetch-User", "?1");
			httpRequest.AddHeader("Sec-Fetch-Dest", "document");
			T0 val = (T0)string.Concat((string[])(object)new T0[12]
			{
				(T0)"account_id=",
				Act,
				(T0)"&__user=",
				UID,
				(T0)"&__a=1&__dyn=7xeUmxa2C5rgydwCwRyu2abheCEnxim2q12xCagjGqErxqqax2366UjyXgC3eF98Sm4EuGfyUeEjG4Erzobo-4Jxe3a26486C6EC8yEScx611wOwGwOxa7FEhwyg9omwwCwXxKaCwTxqWBBwLjzu2SJaECfiwznBwRyXxK9xu1UxN1ap3bBwyxm3G4UhwXzoqwgolUScyobo4a5UtwrUO7o9bBDxWbwQwywWjxCUdoapUao9kbxR12ewzwAwRyUszUeUmwnHxJxK48G2q4p8y26U8U-UG2e1dx-q4VEhwwwSwpp8bU-dwKwHxa1LyUnwUzpA6EfEO32fxiFVoa9obGwSz8yfyUe8hyVEKu9zawLCyKbwzweau1Hwio4K2e1FAwGwgVUWqU9E&__csr=&__req=p&__hs=19373.BP%3Aads_campaign_manager_pkg.2.0.0.0.0&dpr=1&__ccg=GOOD&__rev=",
				(T0)frmMain.listFBEntity[indexEntity].__spin_r,
				(T0)"&__s=u2qsyv%3Ad8hja7%3Anbqt8c&__hsi=7189076301117166946&__comet_req=0&fb_dtsg=",
				fb_dtsg,
				(T0)"&jazoest=25655&lsd=qTlpfXzIaPwJhzIkmf35NJ&__aaid=544123324444326&__spin_r=",
				(T0)frmMain.listFBEntity[indexEntity].__spin_r,
				(T0)"&__spin_b=trunk&__spin_t=",
				(T0)frmMain.listFBEntity[indexEntity].__spin_t
			});
			T0 val2 = (T0)((object)httpRequest.Post("https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/ajax/account_close/", string.Concat((string[])(object)new T0[1] { val }), "application/x-www-form-urlencoded")).ToString();
			httpRequest.UserAgent = Http.FirefoxUserAgent();
			T1 val3 = (T1)(!((string)val2).ToLower().Contains("error"));
			if (val3 != null)
			{
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 activeAct<T0, T1, T2>(T0 UID, T0 Act, T0 fb_dtsg)
	{
		//IL_000e: Expected O, but got I4
		//IL_0142: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)"active tk", (T1)1);
			httpRequest.KeepAlive = true;
			httpRequest.AddHeader("viewport-width", "1229");
			httpRequest.AddHeader("sec-ch-ua", "\"Not?A_Brand\";v=\"8\", \"Chromium\";v=\"108\", \"Google Chrome\";v=\"108\"");
			httpRequest.AddHeader("sec-ch-ua-mobile", "?0");
			httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
			httpRequest.UserAgent = strUserAgentDesktop;
			httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
			httpRequest.AddHeader("Sec-Fetch-Site", "none");
			httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
			httpRequest.AddHeader("Sec-Fetch-User", "?1");
			httpRequest.AddHeader("Sec-Fetch-Dest", "document");
			((object)httpRequest.Get("https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/manage/unsettled.php?act=" + (string)Act, (RequestParams)null)).ToString();
			httpRequest.UserAgent = Http.FirefoxUserAgent();
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 setLimit<T0, T1, T2>(T0 UID, T0 Act, T0 fb_dtsg, T0 limit, T0 currentCurrency)
	{
		//IL_0015: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)("Set limit: " + (string)limit), (T1)0);
			T0 str = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"{\"input\":{\"billable_account_payment_legacy_account_id\":\"",
				Act,
				(T0)"\",\"new_spend_limit\":{\"amount\":\"",
				limit,
				(T0)"\",\"currency\":\"",
				currentCurrency,
				(T0)"\"},\"actor_id\":\"",
				UID,
				(T0)"\",\"client_mutation_id\":\"1\"}}"
			});
			str = (T0)HttpUtility.UrlEncode((string)str);
			T0 val = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				UID,
				(T0)"&__usid=&__user=",
				UID,
				(T0)"&__a=1&__dyn=&__csr=&__req=z&__hs=&dpr=1&__ccg=UNKNOWN&__rev=&__s=&__hsi=&__comet_req=0&fb_dtsg=",
				fb_dtsg,
				(T0)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingUpdateAccountSpendLimitScreenMutation&variables=",
				str,
				(T0)"&server_timestamps=true&doc_id=5615899425146711"
			});
			httpRequest.Referer = "https://www" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ads/manager/account_settings/account_billing/";
			T0 val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { val }), "application/x-www-form-urlencoded")).ToString();
			T1 val3 = (T1)((string)val2).Contains("spend_limit");
			if (val3 != null)
			{
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 addCart<T0, T1, T2>(T0 UID, T0 Act, T0 fb_dtsg, T0 country_code, T0 cardholder_name, T0 credit_card_number, T0 sensitive_string_value, T0 expiry_month, T0 expiry_year)
	{
		//IL_000e: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_01a2: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)"Add thẻ", (T1)0);
			T0 val = (T0)((string)credit_card_number).Substring(0, 6);
			T0 val2 = (T0)((string)credit_card_number).Substring(((string)credit_card_number).Length - 4, 4);
			T1 val3 = (T1)(((string)expiry_year).Length == 2);
			if (val3 != null)
			{
				expiry_year = (T0)("20" + (string)expiry_year);
			}
			T0 val5;
			while (true)
			{
				T0 str = (T0)string.Concat((string[])(object)new T0[21]
				{
					(T0)"{\"input\":{\"billing_address\":{\"country_code\":\"",
					country_code,
					(T0)"\"},\"billing_logging_data\":{\"logging_counter\":1,\"logging_id\":\"1\"},\"cardholder_name\":\"",
					cardholder_name,
					(T0)"\",\"credit_card_first_6\":{\"sensitive_string_value\":\"",
					val,
					(T0)"\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"",
					val2,
					(T0)"\"},\"credit_card_number\":{\"sensitive_string_value\":\"",
					credit_card_number,
					(T0)"\"},\"csc\":{\"sensitive_string_value\":\"",
					sensitive_string_value,
					(T0)"\"},\"expiry_month\":\"",
					expiry_month,
					(T0)"\",\"expiry_year\":\"",
					expiry_year,
					(T0)"\",\"payment_account_id\":\"",
					Act,
					(T0)"\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true,\"actor_id\":\"",
					UID,
					(T0)"\",\"client_mutation_id\":\"1\"}}"
				});
				str = (T0)HttpUtility.UrlEncode((string)str);
				T0 val4 = (T0)string.Concat((string[])(object)new T0[9]
				{
					(T0)"av=",
					UID,
					(T0)"&payment_dev_cycle=prod&__usid=&__user=",
					UID,
					(T0)"&__a=1&__dyn=&__req=x&__hs=&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=0&fb_dtsg=",
					fb_dtsg,
					(T0)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=",
					str,
					(T0)"&server_timestamps=true&doc_id=4126726757375265"
				});
				val5 = (T0)((object)httpRequest.Post("https://business.secure" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ajax/payment/token_proxy.php?tpe=%2Fapi%2Fgraphql%2F", string.Concat((string[])(object)new T0[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
				T1 val6 = (T1)((string)val5).Contains("1383118");
				if (val6 == null)
				{
					break;
				}
				approved_payment<T0, T1, T2>(UID, Act, fb_dtsg);
			}
			T1 val7 = (T1)((string)val5).Contains((string)val2);
			if (val7 != null)
			{
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 addCart_M_Facebook<T0, T1, T2>(T0 UID, T0 Act, T0 fb_dtsg, T0 country_code, T0 cardholder_name, T0 credit_card_number, T0 sensitive_string_value, T0 expiry_month, T0 expiry_year, out string strOutMessage)
	{
		//IL_0015: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_019f: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		//IL_024e: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_0268: Expected O, but got I4
		strOutMessage = "";
		try
		{
			setMessage<T1, T0, T2>((T0)"Add thẻ", (T1)0);
			T0 val = (T0)((string)credit_card_number).Substring(0, 6);
			T0 val2 = (T0)((string)credit_card_number).Substring(((string)credit_card_number).Length - 4, 4);
			T1 val3 = (T1)(((string)expiry_year).Length == 2);
			if (val3 != null)
			{
				expiry_year = (T0)("20" + (string)expiry_year);
			}
			T0 str = (T0)string.Concat((string[])(object)new T0[21]
			{
				(T0)"{\"input\":{\"client_mutation_id\":\"3\",\"actor_id\":\"",
				UID,
				(T0)"\",\"billing_address\":{\"country_code\":\"",
				country_code,
				(T0)"\"},\"billing_logging_data\":{\"logging_counter\":17,\"logging_id\":\"3947615373\"},\"cardholder_name\":\"",
				cardholder_name,
				(T0)"\",\"credit_card_first_6\":{\"sensitive_string_value\":\"",
				val,
				(T0)"\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"",
				val2,
				(T0)"\"},\"credit_card_number\":{\"sensitive_string_value\":\"",
				credit_card_number,
				(T0)"\"},\"csc\":{\"sensitive_string_value\":\"",
				sensitive_string_value,
				(T0)"\"},\"expiry_month\":\"",
				expiry_month,
				(T0)"\",\"expiry_year\":\"",
				expiry_year,
				(T0)"\",\"payment_account_id\":\"",
				Act,
				(T0)"\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true}}"
			});
			str = (T0)HttpUtility.UrlEncode((string)str);
			T0 val4 = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				UID,
				(T0)"&payment_dev_cycle=prod&__usid=&__user=",
				UID,
				(T0)"&__a=1&__dyn=&__req=1e&__hs=19173.BP%3Amtouch_pkg.2.0.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1005729155&__s=&__hsi=&__comet_req=0&fb_dtsg=",
				fb_dtsg,
				(T0)"&jazoest=&lsd=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=",
				str,
				(T0)"&server_timestamps=true&doc_id=4126726757375265"
			});
			T0 val5 = (T0)((object)httpRequest.Post("https://m.secure" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/ajax/payment/token_proxy.php?tpe=%2Fapi%2Fgraphql%2F", string.Concat((string[])(object)new T0[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
			T1 val6 = (T1)((string)val5).Contains((string)val2);
			if (val6 != null)
			{
				return (T1)1;
			}
			val5 = (T0)((string)val5).ToLower();
			T1 val7 = (T1)((string)val5).Contains("description");
			if (val7 != null)
			{
				strOutMessage = Regex.Match((string)val5, "description\":\"(.*?)\",").Groups[1].Value.ToString();
			}
			T1 val8 = (T1)string.IsNullOrWhiteSpace(strOutMessage);
			if (val8 != null)
			{
				strOutMessage = Regex.Match((string)val5, "message\":\"(.*?)\",").Groups[1].Value;
			}
			T1 val9 = (T1)string.IsNullOrWhiteSpace(strOutMessage);
			if (val9 != null)
			{
				strOutMessage = Regex.Match((string)val5, "summary\":\"(.*?)\",").Groups[1].Value;
			}
			T1 val10 = (T1)(!string.IsNullOrWhiteSpace(strOutMessage));
			if (val10 != null)
			{
				strOutMessage = (string)Compound2Unicode.compound2Unicode((T0)strOutMessage);
			}
			return (T1)0;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 approved_payment<T0, T1, T2>(T0 UID, T0 Act, T0 fb_dtsg)
	{
		//IL_000e: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00dc: Expected O, but got I4
		try
		{
			setMessage<T1, T0, T2>((T0)"Approved payment", (T1)0);
			T0 str = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"{\"input\":{\"billable_account_payment_legacy_account_id\":\"",
				Act,
				(T0)"\",\"entry_point\":\"BILLING_2_0\",\"actor_id\":\"",
				UID,
				(T0)"\",\"client_mutation_id\":\"1\"}}"
			});
			str = (T0)HttpUtility.UrlEncode((string)str);
			T0 val = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				UID,
				(T0)"&__usid=&__user=",
				UID,
				(T0)"&__a=1&__dyn=&__csr=&__req=y&__hs=&dpr=1&__ccg=UNKNOWN&__rev=&__s=&__hsi=&__comet_req=1&fb_dtsg=",
				fb_dtsg,
				(T0)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingPreauthPermitMutation&variables=",
				str,
				(T0)"&server_timestamps=true&doc_id=3514448948659909"
			});
			T0 val2 = (T0)((object)httpRequest.Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { val }), "application/x-www-form-urlencoded")).ToString();
			T1 val3 = (T1)((string)val2).Contains("success\":true");
			if (val3 != null)
			{
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 checkBlankPayment<T0, T1>(T0 string_0, T0 string_1)
	{
		//IL_0067: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		try
		{
			T0 val = (T0)((object)httpRequest.Get(string.Concat((string[])(object)new T0[5]
			{
				(T0)("https://graph" + ResouceControl.getResouce("RESOUCE_FACEBOOK_COM") + "/graphql?access_token="),
				string_0,
				(T0)"&variables={\"paymentAccountID\":\"",
				string_1,
				(T0)"\"}&doc_id=6975887429148122&method=post"
			}), (RequestParams)null)).ToString();
			T1 val2 = (T1)(!((string)val).Contains("\"is_reauth_restricted\":true,"));
			if (val2 != null)
			{
				return (T1)1;
			}
			return (T1)0;
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FacebookApi()
	{
		object obj = Activator.CreateInstance(typeof(List<string>));
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_11_6 (Build 15G22010)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.3");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_12_6 (Build 16G2136)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_13_6 (Build 17G14042)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_13_6 (Build 17G8037)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_15 (Build 19A583)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_15_1 (Build 19B88)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.4");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_15_6 (Build 19G73)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.3.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  10_15_7 (Build 19H524)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.3.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_0_1 (Build 20B29)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.3.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_2_3 (Build 20D91)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.2.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_2_3 (Build 20D91)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.3.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_2_3 (Build 20D91)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_4 (Build 20F71)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.2.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_4 (Build 20F71)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.3.1");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_5_2 (Build 20G95)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.3.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_5_2 (Build 20G95)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_6 (Build 20G165)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_6 (Build 20G165)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.3");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  11_6_5 (Build 20G527)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  12_1 (Build 21C52)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.4.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  12_1 (Build 21C52)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  12_3 (Build 21E230)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  12_3_1 (Build 21E258)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X  12_4 (Build 21F79)) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Lovense/30.5.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X -1_0_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3195.0 Safari/537.36");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X -1_0_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X -1_0_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X -1_0_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10 10_9) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/84.0.4147.30 Safari/535.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10 8_8) AppleWebKit/532.1 (KHTML, like Gecko) Chrome/71.0.3578.137 Safari/532.1");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:38.0) Gecko/20100101 Firefox/38.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:40.0) Gecko/20100101 Firefox/40.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:42.0) Gecko/20100101 Firefox/42.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:45.0) Gecko/20100101 Firefox/45.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:46.0) Gecko/20100101 Firefox/46.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:48.0) Gecko/20100101 Firefox/48.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:56.0) Gecko/20100101 Firefox/56.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:56.0) Gecko/20100101 Firefox/56.0 Waterfox/56.3");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:56.0) Gecko/20100101 Firefox/56.0 Waterfox/56.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:63.0) Gecko/20100101 Firefox/63.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:68.0) Gecko/20100101 Firefox/68.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:68.0) Gecko/20100101 Firefox/68.0 Waterfox/56.6.2021.10");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:68.0) Gecko/20100101 Firefox/68.0 Waterfox/56.6.2022.02");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:68.0) Gecko/20100101 Firefox/68.0 Waterfox/56.6.2022.06");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:68.0) Gecko/20100101 Thunderbird/68.11.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:70.0) Gecko/20100101 Firefox/70.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:71.0) Gecko/20100101 Firefox/71.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:72.0) Gecko/20100101 Firefox/72.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:73.0) Gecko/20100101 Firefox/73.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:74.0) Gecko/20100101 Firefox/74.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:75.0) Gecko/20100101 Firefox/75.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:76.0) Gecko/20100101 Firefox/76.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.0; rv:77.0) Gecko/20100101 Firefox/77.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10) Gecko/20100101 Firefox/68.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.0) Gecko/20100101 Firefox/10.0.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.0) Gecko/20100101 Firefox/10.0.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.2) Gecko/20100101 Firefox/10.2.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.2) Gecko/20100101 Firefox/10.2.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.3) Gecko/20100101 Firefox/10.3.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.3) Gecko/20100101 Firefox/10.3.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.4) Gecko/20100101 Firefox/10.4.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.4) Gecko/20100101 Firefox/10.4.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.4) Gecko/20100101 Firefox/10.4.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.5) Gecko/20100101 Firefox/10.5.9");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.7) Gecko/20100101 Firefox/10.7.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.8) Gecko/20100101 Firefox/10.8.9");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.9) Gecko/20100101 Firefox/10.9.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:10.9) Gecko/20100101 Firefox/10.9.9");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.1) Gecko/20100101 Firefox/11.1.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.1) Gecko/20100101 Firefox/11.1.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.3) Gecko/20100101 Firefox/11.3.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.3) Gecko/20100101 Firefox/11.3.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.4) Gecko/20100101 Firefox/11.4.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.4) Gecko/20100101 Firefox/11.4.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.5) Gecko/20100101 Firefox/11.5.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.6) Gecko/20100101 Firefox/11.6.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.6) Gecko/20100101 Firefox/11.6.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.7) Gecko/20100101 Firefox/11.7.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:11.8) Gecko/20100101 Firefox/11.8.9");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.1) Gecko/20100101 Firefox/12.1.1");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.1) Gecko/20100101 Firefox/12.1.7");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.2) Gecko/20100101 Firefox/12.2.1");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.2) Gecko/20100101 Firefox/12.2.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.4) Gecko/20100101 Firefox/12.4.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.5) Gecko/20100101 Firefox/12.5.3");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.5) Gecko/20100101 Firefox/12.5.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.6) Gecko/20100101 Firefox/12.6.1");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.6) Gecko/20100101 Firefox/12.6.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.7) Gecko/20100101 Firefox/12.7.2");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.7) Gecko/20100101 Firefox/12.7.3");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.8) Gecko/20100101 Firefox/12.8.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.9) Gecko/20100101 Firefox/12.9.1");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.9) Gecko/20100101 Firefox/12.9.3");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:12.9) Gecko/20100101 Firefox/12.9.6");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:13.0) Gecko/20100101 Firefox/13.0.5");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:13.1) Gecko/20100101 Firefox/13.1.8");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:13.2) Gecko/20100101 Firefox/13.2.0");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:13.2) Gecko/20100101 Firefox/13.2.4");
		((List<string>)obj).Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10.0; rv:13.3) Gecko/20100101 Firefox/13.3.4");
		listUserAgent = (List<string>)obj;
	}
}
