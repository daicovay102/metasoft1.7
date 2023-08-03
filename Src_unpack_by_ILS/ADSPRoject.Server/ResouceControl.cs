using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using ADSPRoject.Data.API;
using ADSPRoject.License;
using Newtonsoft.Json;

namespace ADSPRoject.Server;

public class ResouceControl
{
	private static int countRequest = 0;

	private static Dictionary<string, string> listResouce_Offline;

	public static string API_URL = "https://api.meta-soft.tech/";

	public static string RESOUCE_VERSION = "ResouceV2";

	private static List<string> listResouce_;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string getResouce(string key)
	{
		try
		{
			string text = "";
			int num = 0;
			while (true)
			{
				if (!listResouce_Offline.ContainsKey(key))
				{
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(API_URL + "/api/" + RESOUCE_VERSION);
					httpWebRequest.Method = "POST";
					httpWebRequest.ContentType = "application/json";
					ResouceParameter resouceParameter = new ResouceParameter();
					resouceParameter.Resouce_Name = key;
					resouceParameter.User_Token = User.Get_Token_User<string>();
					resouceParameter.Parameter = null;
					using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
					{
						streamWriter.Write(JsonConvert.SerializeObject((object)resouceParameter));
					}
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
					string text2 = streamReader.ReadToEnd();
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ResouceModel resouceModel = JsonConvert.DeserializeObject<ResouceModel>(text2);
						if (resouceModel != null && !string.IsNullOrEmpty(resouceModel.Value))
						{
							text = StringCipher.Decrypt(resouceModel.Value, User.Token);
							if (!listResouce_Offline.ContainsKey(key))
							{
								listResouce_Offline.Add(key, text);
							}
						}
					}
					else
					{
						num++;
						if (num < 20)
						{
							Thread.Sleep(1000);
							continue;
						}
						Process.GetCurrentProcess().Kill();
					}
				}
				else
				{
					text = listResouce_Offline[key];
				}
				break;
			}
			return text;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string getResouce(string key, Dictionary<string, string> parameter)
	{
		try
		{
			string text = "";
			int num = 0;
			while (true)
			{
				if (!listResouce_.Contains(key) || !listResouce_Offline.ContainsKey(key))
				{
					Console.WriteLine(key + ": " + parameter.Count);
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(API_URL + "/api/" + RESOUCE_VERSION);
					httpWebRequest.Method = "POST";
					httpWebRequest.ContentType = "application/json";
					ResouceParameter resouceParameter = new ResouceParameter();
					resouceParameter.Resouce_Name = key;
					resouceParameter.User_Token = User.Get_Token_User<string>();
					if (!listResouce_.Contains(key))
					{
						Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
						if (parameter != null && parameter.Count > 0)
						{
							foreach (KeyValuePair<string, string> item in parameter)
							{
								dictionary.Add(StringCipher.Encrypt(item.Key, User.Token), item.Value);
							}
						}
						resouceParameter.Parameter = dictionary;
					}
					else
					{
						resouceParameter.Parameter = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
					}
					using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
					{
						streamWriter.Write(JsonConvert.SerializeObject((object)resouceParameter));
					}
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
					string text2 = streamReader.ReadToEnd();
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ResouceModel resouceModel = JsonConvert.DeserializeObject<ResouceModel>(text2);
						if (resouceModel != null && !string.IsNullOrEmpty(resouceModel.Value))
						{
							text = StringCipher.Decrypt(resouceModel.Value, User.Token);
							if (listResouce_.Contains(key) && !listResouce_Offline.ContainsKey(key))
							{
								listResouce_Offline.Add(key, text);
							}
						}
					}
					else
					{
						num++;
						if (num < 20)
						{
							Thread.Sleep(1000);
							continue;
						}
						Process.GetCurrentProcess().Kill();
					}
				}
				else
				{
					text = listResouce_Offline[key];
				}
				break;
			}
			if (listResouce_.Contains(key))
			{
				foreach (KeyValuePair<string, string> item2 in parameter)
				{
					text = text.Replace(item2.Key, item2.Value);
				}
			}
			return text;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 login<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 Email, T2 Password)
	{
		//IL_0002: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			User.Building_User_Token<T2, T0, char>(Email, Password);
			T1 val2 = (T1)WebRequest.Create(API_URL + "/api/user");
			((WebRequest)val2).Method = "POST";
			((WebRequest)val2).ContentType = "application/json";
			T2 value = (T2)string.Concat((string[])(object)new T2[5]
			{
				(T2)"{\"App\":\"\",\"Flag\":\"",
				(T2)FLAG_STATUS.Login.ToString(),
				(T2)"\",\"User_Token\":\"",
				User.Get_Token_User<T2>(),
				(T2)"\"}"
			});
			T4 val3 = (T4)new StreamWriter(((WebRequest)val2).GetRequestStream());
			try
			{
				((TextWriter)val3).Write((string)value);
			}
			finally
			{
				if (val3 != null)
				{
					((IDisposable)val3).Dispose();
				}
			}
			T3 val4 = (T3)((WebRequest)val2).GetResponse();
			T5 val5 = (T5)new StreamReader(((WebResponse)val4).GetResponseStream());
			try
			{
				T2 val6 = (T2)((TextReader)val5).ReadToEnd();
				T6 val7 = (T6)(!string.IsNullOrWhiteSpace((string)val6));
				if (val7 != null)
				{
					UserResultModel userResultModel = JsonConvert.DeserializeObject<UserResultModel>((string)val6);
					val = (T0)int.Parse(userResultModel.Value);
					T6 val8 = (T6)((nint)val != 1 && (nint)val != 3);
					if (val8 != null)
					{
						User.Email += "?";
					}
					User.ExpireDate = userResultModel.ExpireDate;
					User.AdsManager_RollingMatThread = userResultModel.AdsManager_RollingMatThread;
					User.AddCardByPro5 = userResultModel.AddCardByPro5;
					User.Page_Partner = userResultModel.Page_Partner;
					listResouce_Offline = (Dictionary<string, string>)Activator.CreateInstance(typeof(T8));
				}
			}
			finally
			{
				if (val5 != null)
				{
					((IDisposable)val5).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 UpdateTokenUser<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0002: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)WebRequest.Create(API_URL + "/api/user");
			((WebRequest)val).Method = "POST";
			((WebRequest)val).ContentType = "application/json";
			T2 value = (T2)string.Concat((string[])(object)new T2[5]
			{
				(T2)"{\"App\":\"\",\"Flag\":\"",
				(T2)FLAG_STATUS.UpdateToken.ToString(),
				(T2)"\",\"User_Token\":\"",
				User.Get_Token_User<T2>(),
				(T2)"\"}"
			});
			T4 val2 = (T4)new StreamWriter(((WebRequest)val).GetRequestStream());
			try
			{
				((TextWriter)val2).Write((string)value);
			}
			finally
			{
				if (val2 != null)
				{
					((IDisposable)val2).Dispose();
				}
			}
			T3 val3 = (T3)((WebRequest)val).GetResponse();
			T5 val4 = (T5)new StreamReader(((WebResponse)val3).GetResponseStream());
			try
			{
				T2 val5 = (T2)((TextReader)val4).ReadToEnd();
				T0 val6 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
				if (val6 != null)
				{
					UserResultModel userResultModel = JsonConvert.DeserializeObject<UserResultModel>((string)val5);
					result = (T0)bool.Parse(userResultModel.Value);
				}
			}
			finally
			{
				if (val4 != null)
				{
					((IDisposable)val4).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ResouceControl()
	{
		object obj = Activator.CreateInstance(typeof(List<string>));
		((List<string>)obj).Add("share_tkqc_to_via");
		((List<string>)obj).Add("xoa_tkqc_trong_bm");
		((List<string>)obj).Add("GetCampaigns");
		((List<string>)obj).Add("support_camp_review");
		((List<string>)obj).Add("getAddrafts");
		((List<string>)obj).Add("addraft_fragments");
		((List<string>)obj).Add("addraft_fragments_2");
		((List<string>)obj).Add("addraft_fragments_2_Promise");
		((List<string>)obj).Add("fetch_url");
		((List<string>)obj).Add("billable_account_by_payment_account");
		((List<string>)obj).Add("billable_account_by_payment_account_Promise");
		((List<string>)obj).Add("billable_account_by_payment_account_Promise_3");
		((List<string>)obj).Add("BillingHubRootBillableAccountContextProviderQuery_Promise");
		((List<string>)obj).Add("billable_account_by_payment_account_Promise_3");
		((List<string>)obj).Add("BillingHubRootBillableAccountContextProviderQuery_Promise");
		((List<string>)obj).Add("Approved_payment");
		((List<string>)obj).Add("Approved_payment_Promise");
		((List<string>)obj).Add("xm_3ds2_the");
		((List<string>)obj).Add("share_pixel_Promise");
		((List<string>)obj).Add("Doi_Thanh_Toan_TK");
		((List<string>)obj).Add("phan_quyen_tai_khoan_cho_user");
		((List<string>)obj).Add("lay_thong_tin_no");
		((List<string>)obj).Add("pay_xit");
		((List<string>)obj).Add("pay_xit_Promise");
		((List<string>)obj).Add("lay_thong_tin_no_Promise");
		((List<string>)obj).Add("lay_payment_method_id");
		((List<string>)obj).Add("pay_tay");
		((List<string>)obj).Add("go_phuong_thuc_thanh_toan");
		((List<string>)obj).Add("reset_limit");
		((List<string>)obj).Add("day_the_len_chinh_promise");
		((List<string>)obj).Add("Set_Limit");
		((List<string>)obj).Add("Accept_BM_Request");
		((List<string>)obj).Add("get_ext_hash");
		((List<string>)obj).Add("TKCN_Get_Request_BM");
		((List<string>)obj).Add("Tao_TK_Trong_BM");
		((List<string>)obj).Add("Set_Payment_BM_Cho_Act");
		((List<string>)obj).Add("Lay_Payment_Id_Act");
		((List<string>)obj).Add("phan_quyen_tai_khoan_cho_user");
		((List<string>)obj).Add("Doi_Thong_Tin_TK_BM");
		((List<string>)obj).Add("remove_limit_on_camp");
		((List<string>)obj).Add("Doi_Thong_Tin_TK_BM_Promise");
		((List<string>)obj).Add("get_credential_id");
		((List<string>)obj).Add("day_the_len_chinh");
		((List<string>)obj).Add("remove_limit");
		((List<string>)obj).Add("remove_limit_promise");
		((List<string>)obj).Add("khang_tkqc");
		((List<string>)obj).Add("khang_273_Yes");
		((List<string>)obj).Add("khang_273_No");
		((List<string>)obj).Add("khangTK_792");
		((List<string>)obj).Add("share_doi_tac");
		((List<string>)obj).Add("tao_link_moi_bm");
		((List<string>)obj).Add("fetch_url");
		((List<string>)obj).Add("fetch_url_business");
		((List<string>)obj).Add("change_name_act");
		((List<string>)obj).Add("change_name_act_promise");
		((List<string>)obj).Add("share_quyen_tkqc");
		((List<string>)obj).Add("thu_lai_tam_giu_tien");
		((List<string>)obj).Add("thu_lai_tam_giu_tien_Promise");
		((List<string>)obj).Add("check_life_act_Promise");
		((List<string>)obj).Add("remove_act_in_bm");
		((List<string>)obj).Add("Set_Limit_Promise");
		((List<string>)obj).Add("account_close");
		((List<string>)obj).Add("account_unsettled");
		((List<string>)obj).Add("chi_dinh_user_nhom_tai_san_Promise");
		((List<string>)obj).Add("add_ads_to_group_Promise");
		((List<string>)obj).Add("xoa_tkqc_trong_nhom_tai_san");
		((List<string>)obj).Add("remove_act_in_bm_Promise");
		((List<string>)obj).Add("phan_quyen_payment_bm_cho_user");
		((List<string>)obj).Add("add_the_vao_bm_Step_0");
		((List<string>)obj).Add("add_the_vao_bm_Step_1");
		((List<string>)obj).Add("add_the_vao_bm_Step_2");
		((List<string>)obj).Add("add_the_vao_bm_Step_3");
		((List<string>)obj).Add("add_the_vao_bm_Step_4");
		((List<string>)obj).Add("add_the_vao_bm_Step_5");
		((List<string>)obj).Add("add_the_vao_bm_Step_6");
		((List<string>)obj).Add("add_the_vao_bm");
		((List<string>)obj).Add("addraft_fragments_3");
		((List<string>)obj).Add("ImportTextCamp");
		((List<string>)obj).Add("CampBoostpost_Promise");
		((List<string>)obj).Add("ImportTextCamp_Promise");
		((List<string>)obj).Add("CampBoostpost_0");
		((List<string>)obj).Add("CampBoostpost_1");
		((List<string>)obj).Add("CampBoostpost");
		((List<string>)obj).Add("CampSuite_Promise");
		((List<string>)obj).Add("discard_fragments");
		((List<string>)obj).Add("discard_fragments_Promise");
		((List<string>)obj).Add("sua_target_chien_dich");
		((List<string>)obj).Add("sua_target_nhom_quang_cao");
		((List<string>)obj).Add("sua_target_quang_cao");
		((List<string>)obj).Add("Tao_Camp_Chien_Dich_PE_Promise");
		((List<string>)obj).Add("Tao_Camp_Nhom_QC_PE_Promise");
		((List<string>)obj).Add("Tao_Camp_QC_PE_Promise");
		((List<string>)obj).Add("Tao_Camp_Chien_Dich_PE_Promise");
		((List<string>)obj).Add("Tao_Camp_Nhom_QC_PE_Promise");
		((List<string>)obj).Add("Tao_Camp_QC_PE_Promise");
		((List<string>)obj).Add("Tao_chien_dich_chuyen_doi");
		((List<string>)obj).Add("Tao_nhom_quang_cao_chuyen_doi");
		((List<string>)obj).Add("Upload_anh_camp");
		((List<string>)obj).Add("Tao_quang_cao_chuyen_doi");
		((List<string>)obj).Add("publish_camps");
		((List<string>)obj).Add("publish_camps_Promise");
		((List<string>)obj).Add("publish_camps_2");
		((List<string>)obj).Add("lay_toan_bo_payment_method");
		((List<string>)obj).Add("Add_the");
		((List<string>)obj).Add("Add_the_m_facebook_promise");
		((List<string>)obj).Add("Add_Card_By_Code_Promise");
		((List<string>)obj).Add("Add_the_bostpost_Promise");
		((List<string>)obj).Add("Add_the_suite_Promise");
		((List<string>)obj).Add("Add_the_link1_Promise");
		((List<string>)obj).Add("Add_the_promise");
		((List<string>)obj).Add("Add_the_suite");
		((List<string>)obj).Add("Add_the");
		((List<string>)obj).Add("doi_category_page");
		((List<string>)obj).Add("Share_Page_Doi_Tac");
		((List<string>)obj).Add("Share_Page_Doi_Tac_Page_Classic");
		((List<string>)obj).Add("confirm_2fa_get_token_eeag");
		((List<string>)obj).Add("Chap_nhan_dieu_khoan_camp_2");
		((List<string>)obj).Add("phan_quyen_page_doi_tac");
		((List<string>)obj).Add("xoa_doi_tac_bm_Promise");
		((List<string>)obj).Add("xoa_quyen_page_bm_Promise");
		((List<string>)obj).Add("lay_quyen_page_bm");
		((List<string>)obj).Add("Lay_danh_sach_admin_trong_BM");
		((List<string>)obj).Add("Add_the_pro5_promise");
		((List<string>)obj).Add("xoa_bm_Promise");
		((List<string>)obj).Add("tao_link_moi_bm_nhieu_mail");
		listResouce_ = (List<string>)obj;
	}
}
