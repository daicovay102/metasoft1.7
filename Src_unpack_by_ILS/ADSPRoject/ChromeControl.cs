using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
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
using ADSPRoject.Data.BusinessManager;
using ADSPRoject.Data.BusinessManagerEntity;
using ADSPRoject.Data.Campains;
using ADSPRoject.HttpRequestApi;
using ADSPRoject.Server;
using CreditCardValidator;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OtpNet;
using Rebex.Net;
using xNet;

namespace ADSPRoject;

public class ChromeControl
{
	private FacebookApi fbApi = null;

	public ChromeDriver chrome;

	public frmMain frmMain;

	public int indexEntity;

	public string strProxy;

	public Actions actions;

	public string PROFILE_DIR = "";

	public bool isLogined = false;

	public bool isShopeeLogined = false;

	private string PAGE_NAME = "";

	private static List<string> FirstName = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private static List<string> LastName = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private ChromeOptions options = (ChromeOptions)Activator.CreateInstance(typeof(ChromeOptions));

	private List<bool> listRandomBool;

	private List<string> listTempString;

	private List<string> listFriendAdded;

	private int countAddFriends;

	private static Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private int countError;

	private int countCheckSuccess;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 kichNo<T0, T1, T2, T3, T4>(T2 act, T2 strAmount)
	{
		//IL_0002: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		//IL_01be: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
				T2 resouce = (T2)ResouceControl.getResouce("lay_thong_tin_no", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
				BillingPayNowLandingScreenQuery billingPayNowLandingScreenQuery = JsonConvert.DeserializeObject<BillingPayNowLandingScreenQuery>((string)val3);
				T3 enumerator = (T3)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
				try
				{
					while (((List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator))->MoveNext())
					{
						ADSPRoject.Data.BusinessManager.billing_payment_methods current = ((List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator))->Current;
						try
						{
							T2 credential_id = (T2)current.credential.credential_id;
							T2 value = (T2)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.account_balance.amount;
							T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)strAmount));
							if (val4 != null)
							{
								value = strAmount;
							}
							T2 currency = (T2)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.account_balance.currency;
							val2 = (T1)Activator.CreateInstance(typeof(T1));
							((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
							((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
							((Dictionary<string, string>)val2).Add("strCredential_id", (string)credential_id);
							((Dictionary<string, string>)val2).Add("strAmount", (string)value);
							((Dictionary<string, string>)val2).Add("strCurency", (string)currency);
							resouce = (T2)ResouceControl.getResouce("pay_xit", (Dictionary<string, string>)val2);
							val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
							T0 val5 = (T0)(!((string)val3).Contains("Payment lỗied"));
							if (val5 != null)
							{
								result = (T0)0;
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			else
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 kichNo_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_0217: Expected I4, but got O
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_023e: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_0276: Expected I4, but got O
		//IL_028c: Expected O, but got I4
		//IL_0298: Expected I4, but got O
		//IL_02b7: Expected I4, but got O
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			lay_thong_tin_no_Promise<T0, T1, T7, T2, T4, T6, T5, T8>(listData);
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T2 enumerator = (T2)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					current.str3 = "Null";
					BillingPayNowLandingScreenQuery billingPayNowLandingScreenQuery = (BillingPayNowLandingScreenQuery)current.obj1;
					T3 enumerator2 = (T3)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
					try
					{
						while (((List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator2))->MoveNext())
						{
							ADSPRoject.Data.BusinessManager.billing_payment_methods current2 = ((List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator2))->Current;
							try
							{
								T1 val3 = (T1)("fetch_" + (string)str + "_" + current2.credential.credential_id);
								T1 credential_id = (T1)current2.credential.credential_id;
								T1 value = (T1)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.account_balance.amount;
								T0 val4 = (T0)(!string.IsNullOrWhiteSpace(current.str2));
								if (val4 != null)
								{
									value = (T1)current.str2;
								}
								T1 currency = (T1)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.account_balance.currency;
								T4 val5 = (T4)Activator.CreateInstance(typeof(T4));
								((Dictionary<string, string>)val5).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
								((Dictionary<string, string>)val5).Add("strAct", ((string)str).Replace("act_", ""));
								((Dictionary<string, string>)val5).Add("strCredential_id", (string)credential_id);
								((Dictionary<string, string>)val5).Add("strAmount", (string)value);
								((Dictionary<string, string>)val5).Add("strCurency", (string)currency);
								((Dictionary<string, string>)val5).Add("result", (string)val3);
								T1 resouce = (T1)ResouceControl.getResouce("pay_xit_Promise", (Dictionary<string, string>)val5);
								val = (T1)((string)val + (string)resouce);
								val2 = (T1)((string)val2 + (string)val3 + ",");
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T0 val6 = (T0)string.IsNullOrWhiteSpace((string)val);
			if (val6 != null)
			{
				T6 val7 = (T6)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str3 = frmMain.STATUS.lỗi.ToString();
						val7 = (T6)(val7 + 1);
						continue;
					}
					break;
				}
			}
			else
			{
				T7 val9 = executeScript_Promise<T7, T1, IJavaScriptExecutor, ICollection<object>, T0, T5, char, object>(val, val2);
				T0 val10 = (T0)(val9 != null && ((List<object>)val9).Count > 0);
				if (val10 != null)
				{
					T6 val11 = (T6)0;
					while (true)
					{
						T0 val12 = (T0)((nint)val11 < ((List<ListStringData>)listData).Count);
						if (val12 == null)
						{
							break;
						}
						T1 val13 = (T1)((List<object>)val9)[(int)val11].ToString();
						T0 val14 = (T0)((string)val13).Contains("api_error_code");
						if (val14 == null)
						{
							((List<ListStringData>)listData)[(int)val11].str3 = frmMain.STATUS.Done.ToString();
						}
						else
						{
							((List<ListStringData>)listData)[(int)val11].str3 = frmMain.STATUS.lỗi.ToString();
						}
						val11 = (T6)(val11 + 1);
					}
					result = (T0)1;
				}
			}
		}
		catch (Exception ex2)
		{
			result = (T0)0;
			Console.WriteLine(ex2.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 lay_thong_tin_no_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0112: Expected I4, but got O
		//IL_012a: Expected I4, but got O
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0143: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strAct", ((string)str).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("lay_thong_tin_no_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					BillingPayNowLandingScreenQuery obj = JsonConvert.DeserializeObject<BillingPayNowLandingScreenQuery>((string)val9);
					((List<ListStringData>)listData)[(int)val7].obj1 = obj;
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 payNow<T0, T1, T2, T3>(T2 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
				((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
				T2 resouce = (T2)ResouceControl.getResouce("lay_payment_method_id", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
				Get_List_Payment get_List_Payment = JsonConvert.DeserializeObject<Get_List_Payment>((string)val3);
				T0 val4 = (T0)(get_List_Payment != null && get_List_Payment.all_payment_methods != null && get_List_Payment.all_payment_methods.pm_credit_card != null && get_List_Payment.all_payment_methods.pm_credit_card.data != null);
				if (val4 != null)
				{
					T3 enumerator = (T3)get_List_Payment.all_payment_methods.pm_credit_card.data.GetEnumerator();
					try
					{
						while (((List<pm_credit_card_data>.Enumerator*)(&enumerator))->MoveNext())
						{
							pm_credit_card_data current = ((List<pm_credit_card_data>.Enumerator*)(&enumerator))->Current;
							T2 credential_id = (T2)current.credential_id;
							val2 = (T1)Activator.CreateInstance(typeof(T1));
							((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
							((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
							((Dictionary<string, string>)val2).Add("strCredential_id", (string)credential_id);
							resouce = (T2)ResouceControl.getResouce("pay_tay", (Dictionary<string, string>)val2);
							val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
							T0 val5 = (T0)(!((string)val3).Contains("ACTIVE"));
							if (val5 != null)
							{
								result = (T0)0;
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<pm_credit_card_data>.Enumerator*)(&enumerator))).Dispose();
					}
				}
			}
			else
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 removePaymentMethod<T0, T1, T2, T3, T4>(T2 act, T2 byName)
	{
		//IL_0002: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0170: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
				T2 resouce = (T2)ResouceControl.getResouce("lay_toan_bo_payment_method", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, IJavaScriptExecutor, T4, T0, object>(resouce);
				ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery = JsonConvert.DeserializeObject<ADSPRoject.Data.BillingAMNexusRootQuery>((string)val3);
				T0 val4 = (T0)(billingAMNexusRootQuery != null && billingAMNexusRootQuery.data != null && billingAMNexusRootQuery.data.billable_account_by_payment_account != null && billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
				if (val4 != null)
				{
					T3 enumerator = (T3)billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
					try
					{
						while (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator))->MoveNext())
						{
							ADSPRoject.Data.billing_payment_methods current = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator))->Current;
							T0 val5 = (T0)((!string.IsNullOrWhiteSpace((string)byName) && (current.credential.card_association.ToLower().Contains(((string)byName).ToLower()) || System.Runtime.CompilerServices.Unsafe.As<T4, int>(ref (T4)current.credential.last_four_digits).ToString().ToLower()
								.Contains(((string)byName).ToLower()))) || string.IsNullOrWhiteSpace((string)byName));
							if (val5 != null)
							{
								result = removeCard<T0, T1, T2>((T2)current.credential.credential_id, act);
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator))).Dispose();
					}
				}
			}
			else
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 removeCard<T0, T1, T2>(T2 credential_id, T2 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strAct", ((string)act).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strPaymentMethodId", (string)credential_id);
			T2 resouce = (T2)ResouceControl.getResouce("go_phuong_thuc_thanh_toan", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)(((string)val2).Contains("errors") || ((string)val2).Contains("api_error_code"));
			if (val3 != null)
			{
				result = (T0)0;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 removeCard_Promise<T0, T1, T2, T3, T4, T5, T6>(T6 listCredential_id, T1 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_0133: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0144: Expected I4, but got O
		//IL_015a: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listCredential_id).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("await", "");
					((Dictionary<string, string>)val4).Add("return result;", "");
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strAct", ((string)act).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strPaymentMethodId", (string)str);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("go_phuong_thuc_thanh_toan", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, Exception, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listCredential_id).Count);
					if (val8 != null)
					{
						T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
						T0 val10 = (T0)((string)val9).Contains("errors");
						if (val10 != null)
						{
							result = (T0)0;
						}
						val7 = (T5)(val7 + 1);
						continue;
					}
					break;
				}
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 resetLimit<T0, T1, T2>(T2 act)
	{
		//IL_0022: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val != null)
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
			else
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
				((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
				T2 resouce = (T2)ResouceControl.getResouce("reset_limit", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
				T0 val4 = (T0)((string)val3).Contains("success");
				if (val4 != null)
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
	public unsafe T0 day_the_len_chinh_promise<T0, T1, T2, T3, T4, T5, T6>(T6 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 str2 = (T1)current.str2;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", ((string)str).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strCredential_id", (string)str2);
					((Dictionary<string, string>)val4).Add("strBMID", "");
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("day_the_len_chinh_promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T5, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				result = (T0)0;
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 day_the_len_chinh_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 listData, T1 strPushCardPrimary)
	{
		//IL_0002: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0234: Expected O, but got I4
		//IL_0255: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_026a: Expected I4, but got O
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0291: Expected O, but got I4
		//IL_029b: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			lay_thong_tin_no_Promise<T0, T1, T7, T2, T4, T6, T5, T8>(listData);
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T2 enumerator = (T2)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					current.str3 = "Done";
					BillingPayNowLandingScreenQuery billingPayNowLandingScreenQuery = (BillingPayNowLandingScreenQuery)current.obj1;
					T3 enumerator2 = (T3)billingPayNowLandingScreenQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
					try
					{
						while (((List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator2))->MoveNext())
						{
							ADSPRoject.Data.BusinessManager.billing_payment_methods current2 = ((List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator2))->Current;
							try
							{
								T1 value = (T1)"";
								T0 val3 = (T0)string.IsNullOrWhiteSpace((string)strPushCardPrimary);
								if (val3 == null)
								{
									T0 val4 = (T0)(current2.credential.card_association_name.ToLower().Contains((string)strPushCardPrimary) || current2.credential.credential_type.ToLower().Contains((string)strPushCardPrimary) || current2.credential.last_four_digits.ToLower().Contains((string)strPushCardPrimary));
									if (val4 != null)
									{
										value = (T1)current2.credential.credential_id;
									}
								}
								else
								{
									value = (T1)current2.credential.credential_id;
								}
								T0 val5 = (T0)(!string.IsNullOrWhiteSpace((string)value));
								if (val5 != null)
								{
									T4 val6 = (T4)Activator.CreateInstance(typeof(T4));
									T1 val7 = (T1)("fetch_" + (string)str + "_" + current2.credential.credential_id);
									((Dictionary<string, string>)val6).Add("strAct", ((string)str).Replace("act_", ""));
									((Dictionary<string, string>)val6).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
									((Dictionary<string, string>)val6).Add("strCredential_id", (string)value);
									((Dictionary<string, string>)val6).Add("strBMID", "");
									((Dictionary<string, string>)val6).Add("result", (string)val7);
									T1 resouce = (T1)ResouceControl.getResouce("day_the_len_chinh_promise", (Dictionary<string, string>)val6);
									val = (T1)((string)val + (string)resouce);
									val2 = (T1)((string)val2 + (string)val7 + ",");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T0 val8 = (T0)string.IsNullOrWhiteSpace((string)val);
			if (val8 == null)
			{
				T7 val9 = executeScript_Promise<T7, T1, IJavaScriptExecutor, ICollection<object>, T0, T5, char, object>(val, val2);
				T0 val10 = (T0)(val9 != null && ((List<object>)val9).Count > 0);
				if (val10 != null)
				{
					result = (T0)1;
				}
			}
			else
			{
				T6 val11 = (T6)0;
				while (true)
				{
					T0 val12 = (T0)((nint)val11 < ((List<ListStringData>)listData).Count);
					if (val12 != null)
					{
						((List<ListStringData>)listData)[(int)val11].str3 = frmMain.STATUS.lỗi.ToString();
						val11 = (T6)(val11 + 1);
						continue;
					}
					break;
				}
			}
		}
		catch (Exception ex2)
		{
			result = (T0)0;
			Console.WriteLine(ex2.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Approved_hold<T0, T1, T2>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			setMessage("Approved hold", (T0)0);
			getFullAdsInfo<Dictionary<string, string>, string, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, int, char, IDisposable, T2, IWebElement>();
			T1 enumerator = (T1)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					approvedPayment(current.id.Replace("act_", ""));
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			setMessage("e:" + ex.Message, (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Set_limit<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Set_limit").ToString();
			setMessage((T1)("Set limit: " + (string)val2), (T0)0);
			getFullAdsInfo<T3, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, int, char, IDisposable, T4, IWebElement>();
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T3 val3 = (T3)Activator.CreateInstance(typeof(T3));
					((Dictionary<string, string>)val3).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val3).Add("strAct", current.id.Replace("act_", ""));
					((Dictionary<string, string>)val3).Add("strBMID", "");
					((Dictionary<string, string>)val3).Add("strCurrency", current.currency);
					((Dictionary<string, string>)val3).Add("strAmount", (string)val2);
					T1 resouce = (T1)ResouceControl.getResouce("Set_Limit", (Dictionary<string, string>)val3);
					executeScript<T1, IJavaScriptExecutor, int, T0, object>(resouce);
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
			setMessage((T1)("Limit " + (string)val2 + " Ok"), (T0)1);
		}
		catch (Exception ex)
		{
			setMessage((T1)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 accept_agency_permission<T0, T1, T2>(T2 act, T2 strAd_market_id, T2 strAgency_id, T2 strExt, T2 strHash)
	{
		//IL_0002: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			T0 val2 = (T0)((RemoteWebDriver)chrome).Url.Contains("business.facebook");
			if (val2 != null)
			{
				((Dictionary<string, string>)val).Add("www.facebook", "business.facebook");
			}
			((Dictionary<string, string>)val).Add("strAct", ((string)act).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strAd_market_id", (string)strAd_market_id);
			((Dictionary<string, string>)val).Add("strAgency_id", (string)strAgency_id);
			((Dictionary<string, string>)val).Add("strExt", (string)strExt);
			((Dictionary<string, string>)val).Add("strHash", (string)strHash);
			T2 resouce = (T2)ResouceControl.getResouce("Accept_BM_Request", (Dictionary<string, string>)val);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("errorSummary");
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
	private T0 get_ext_hash<T0, T1, T2>(T2 act, T2 ad_market_id, T2 agency_id, out string ext, out string hash)
	{
		//IL_0012: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		ext = "";
		hash = "";
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			T0 val2 = (T0)((RemoteWebDriver)chrome).Url.Contains("business.facebook");
			if (val2 != null)
			{
				((Dictionary<string, string>)val).Add("www.facebook", "business.facebook");
			}
			((Dictionary<string, string>)val).Add("strAct", ((string)act).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strAd_market_id", (string)ad_market_id);
			((Dictionary<string, string>)val).Add("strAgency_id", (string)agency_id);
			T2 resouce = (T2)ResouceControl.getResouce("get_ext_hash", (Dictionary<string, string>)val);
			T2 result2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			ext = (string)get_ad_market_id_agency_id<T2, IEnumerator, Match, int, T0, char, IDisposable>((T2)"ext=", result2);
			hash = (string)get_ad_market_id_agency_id<T2, IEnumerator, Match, int, T0, char, IDisposable>((T2)"hash=", result2);
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 agency_permission_requests_getter<T0, T1, T2>(T2 act, out string ad_market_id, out string agency_id)
	{
		//IL_0010: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		ad_market_id = "";
		agency_id = "";
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			T0 val2 = (T0)((RemoteWebDriver)chrome).Url.Contains("business.facebook");
			if (val2 != null)
			{
				((Dictionary<string, string>)val).Add("www.facebook", "business.facebook");
			}
			((Dictionary<string, string>)val).Add("strAct", ((string)act).Replace("act_", ""));
			T2 resouce = (T2)ResouceControl.getResouce("TKCN_Get_Request_BM", (Dictionary<string, string>)val);
			T2 result2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			ad_market_id = (string)get_ad_market_id_agency_id<T2, IEnumerator, Match, int, T0, char, IDisposable>((T2)"ad_market_id=", result2);
			agency_id = (string)get_ad_market_id_agency_id<T2, IEnumerator, Match, int, T0, char, IDisposable>((T2)"agency_id=", result2);
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 get_ad_market_id_agency_id<T0, T1, T2, T3, T4, T5, T6>(T0 pattern, T0 result)
	{
		//IL_002e: Expected O, but got I4
		//IL_0037: Expected I4, but got O
		//IL_0042: Expected I4, but got O
		//IL_004d: Expected I4, but got O
		//IL_0056: Expected O, but got I4
		//IL_0062: Expected I4, but got O
		//IL_0064: Expected O, but got I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0080: Expected O, but got I4
		T0 val = (T0)"";
		T1 enumerator = (T1)Regex.Matches((string)result, (string)pattern).GetEnumerator();
		try
		{
			if (((IEnumerator)enumerator).MoveNext())
			{
				T2 val2 = (T2)((IEnumerator)enumerator).Current;
				T3 val3 = (T3)((Capture)val2).Index;
				while (true)
				{
					T4 val4 = (T4)((nint)val3 < ((string)result).Length);
					if (val4 != null)
					{
						T4 val5 = (T4)(((string)result)[(int)val3] == '"' || ((string)result)[(int)val3] == '&' || ((string)result)[(int)val3] == '\\');
						if (val5 == null)
						{
							val = (T0)((string)val + System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)((string)result)[(int)val3]));
							val3 = (T3)(val3 + 1);
							continue;
						}
						break;
					}
					break;
				}
			}
		}
		finally
		{
			T6 val6 = (T6)((enumerator is T6) ? enumerator : null);
			if (val6 != null)
			{
				((IDisposable)val6).Dispose();
			}
		}
		return (T0)((string)val).Replace("\\", "").Replace((string)pattern, "");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string createAdsInBM(string BM_ID, string Name, string Đổi_múi_giờ, string Đổi_tiền_tệ, string Quốc_Gia, string MS_Thuế, string State, string Địa_chỉ, string Zip, string City, out string strError)
	{
		string text = "";
		strError = "";
		if (frmMain.isRunning && chrome != null)
		{
			try
			{
				Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
				dictionary.Add("strBMID", BM_ID);
				dictionary.Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
				dictionary.Add("strCurrency", "USD");
				dictionary.Add("strTimeZone", "1");
				dictionary.Add("strLocale", "en-US");
				dictionary.Add("strEmail", "%5B%5D");
				string s = $"{Name} - {rnd.Next(111, 999)}";
				s = HttpUtility.HtmlEncode(s);
				dictionary.Add("strName", s);
				string resouce = ResouceControl.getResouce("Tao_TK_Trong_BM", dictionary);
				string text2 = executeScript<string, IJavaScriptExecutor, int, bool, object>(resouce);
				if (text2.Contains("act_"))
				{
					text = Regex.Match(text2, "account_id\":\"(.*?)\"").Groups[1].Value;
					if (shareToAdminBM<Dictionary<string, string>, string, List<ADSPRoject.Data.business_users_data>.Enumerator, bool>(BM_ID, text))
					{
						changeInfoAct<Dictionary<string, string>, string, bool, int>(text, BM_ID, Đổi_múi_giờ, Đổi_tiền_tệ, Quốc_Gia, MS_Thuế, State, Địa_chỉ, Zip, City);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return text;
		}
		return "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 Set_Payment_BM_Cho_Act<T0, T1, T2>(T0 Act, T0 BM_ID, T0 card_association, out string strError)
	{
		//IL_00a3: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		strError = "";
		try
		{
			T0 value = Lay_Payment_Id_Act<T1, T0, T2, List<billing_payment_method_options>.Enumerator>(Act, BM_ID, card_association);
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct", ((string)Act).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strBM", (string)BM_ID);
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentId", (string)value);
			T0 resouce = (T0)ResouceControl.getResouce("Set_Payment_BM_Cho_Act", (Dictionary<string, string>)val);
			T0 val2 = executeScript<T0, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val3 = (T2)((string)val2).Contains("description");
			if (val3 == null)
			{
				return (T2)1;
			}
			strError = Regex.Match((string)val2, "description\":\"(.*?)\"").Groups[1].Value;
		}
		catch
		{
		}
		return (T2)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe T1 Lay_Payment_Id_Act<T0, T1, T2, T3>(T1 Act, T1 BM_ID, T1 card_association)
	{
		//IL_0084: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strAct", ((string)Act).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strBMID", (string)BM_ID);
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			T1 resouce = (T1)ResouceControl.getResouce("Lay_Payment_Id_Act", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val3 = (T2)((string)val2).Contains("credential_id");
			if (val3 != null)
			{
				T1 result = (T1)Regex.Match((string)val2, "credential_id\":\"(.*?)\"").Groups[1].Value;
				T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)card_association));
				if (val4 != null)
				{
					payment_account payment_account = JsonConvert.DeserializeObject<payment_account>((string)val2);
					T2 val5 = (T2)(payment_account.data != null && payment_account.data.billable_account_by_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_method_options != null);
					if (val5 != null)
					{
						T3 enumerator = (T3)payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_method_options.GetEnumerator();
						try
						{
							while (((List<billing_payment_method_options>.Enumerator*)(&enumerator))->MoveNext())
							{
								billing_payment_method_options current = ((List<billing_payment_method_options>.Enumerator*)(&enumerator))->Current;
								T2 val6 = (T2)current.business_cc_credential.card_association.ToLower().Contains(((string)card_association).ToLower());
								if (val6 != null)
								{
									result = (T1)current.business_cc_credential.credential_id;
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
		return (T1)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T3 shareToAdminBM<T0, T1, T2, T3>(T1 BM_ID, T1 Act)
	{
		//IL_00fe: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strBMID", (string)BM_ID);
			((Dictionary<string, string>)val).Add("strToken", "\"" + frmMain.listFBEntity[indexEntity].TokenEAAG + "\"");
			T1 resouce = (T1)ResouceControl.getResouce("Lay_danh_sach_admin_trong_BM", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T3, object>(resouce);
			ADSPRoject.Data.business_users business_users = JsonConvert.DeserializeObject<ADSPRoject.Data.business_users>((string)val2);
			T2 enumerator = (T2)business_users.data.GetEnumerator();
			try
			{
				while (((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator))->MoveNext())
				{
					ADSPRoject.Data.business_users_data current = ((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator))->Current;
					val = (T0)Activator.CreateInstance(typeof(T0));
					((Dictionary<string, string>)val).Add("strAct", ((string)Act).Replace("act_", ""));
					((Dictionary<string, string>)val).Add("strBMID", (string)BM_ID);
					((Dictionary<string, string>)val).Add("strUserInBM", current.id);
					resouce = (T1)ResouceControl.getResouce("phan_quyen_tai_khoan_cho_user", (Dictionary<string, string>)val);
					val2 = executeScript<T1, IJavaScriptExecutor, int, T3, object>(resouce);
					T3 val3 = (T3)((string)val2).Contains("successes");
					if (val3 != null)
					{
						Console.WriteLine("Done");
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator))).Dispose();
			}
			return (T3)1;
		}
		catch
		{
		}
		return (T3)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 changeInfoAct<T0, T1, T2, T3>(T1 Act, T1 BM_ID, T1 Đổi_múi_giờ, T1 Đổi_tiền_tệ, T1 Quốc_gia, T1 MS_thuế, T1 State, T1 Địa_chỉ, T1 Zip, T1 City)
	{
		//IL_0094: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strBMID", (string)BM_ID);
			((Dictionary<string, string>)val).Add("strAct", ((string)Act).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strCountry", (string)Quốc_gia);
			((Dictionary<string, string>)val).Add("strTax", (string)MS_thuế);
			T2 val2 = (T2)(!((string)Quốc_gia).ToLower().Equals("us"));
			if (val2 != null)
			{
				State = (T1)"";
			}
			((Dictionary<string, string>)val).Add("strState", (string)State);
			((Dictionary<string, string>)val).Add("strAddress", HttpUtility.HtmlEncode((string)Địa_chỉ));
			((Dictionary<string, string>)val).Add("strZip", (string)Zip);
			((Dictionary<string, string>)val).Add("strBusinessName", (string)getFirstName<T2, T1, T3>() + " " + System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)rnd.Next(111, 999)));
			((Dictionary<string, string>)val).Add("strTimeZone", (string)Đổi_múi_giờ);
			((Dictionary<string, string>)val).Add("strCurrency", (string)Đổi_tiền_tệ);
			((Dictionary<string, string>)val).Add("strCity", HttpUtility.HtmlEncode((string)City));
			T1 resouce = (T1)ResouceControl.getResouce("Doi_Thong_Tin_TK_BM", (Dictionary<string, string>)val);
			T1 val3 = executeScript<T1, IJavaScriptExecutor, T3, T2, object>(resouce);
			T2 val4 = (T2)((string)val3).Contains("is_final\":true");
			if (val4 != null)
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
	public T0 receiptLinkBM_2<T0, T1, T2, T3, T4, T5>(T1 bm, out string message)
	{
		//IL_0009: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_02d3: Expected O, but got I4
		//IL_02e9: Expected O, but got I4
		//IL_02ff: Expected O, but got I4
		//IL_0310: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_0326: Expected O, but got I4
		//IL_0337: Expected O, but got I4
		//IL_0339: Expected O, but got I4
		//IL_034d: Expected O, but got I4
		//IL_0363: Expected O, but got I4
		//IL_0398: Expected O, but got I4
		//IL_039a: Expected O, but got I4
		//IL_03ae: Expected O, but got I4
		//IL_03e3: Expected O, but got I4
		//IL_03e5: Expected O, but got I4
		//IL_0418: Expected O, but got I4
		//IL_041a: Expected O, but got I4
		//IL_041e: Expected O, but got I4
		//IL_042d: Expected O, but got I4
		//IL_042f: Expected O, but got I4
		//IL_043a: Expected O, but got I4
		//IL_0447: Expected O, but got I4
		message = "";
		T0 result = (T0)0;
		try
		{
			T1 value = (T1)"";
			T2 val = (T2)Activator.CreateInstance(typeof(HttpRequest));
			((HttpRequest)val).SslProtocols = SslProtocols.Tls12;
			((HttpRequest)val).AllowAutoRedirect = true;
			((object)((HttpRequest)val).Get((string)bm, (RequestParams)null)).ToString();
			T1 val2 = (T1)((HttpRequest)val).Address.ToString();
			T4 val3 = (T4)((string)val2).Contains("=");
			if (val3 != null)
			{
				val2 = ((IEnumerable<T1>)(object)((string)val2).Split((char[])(object)new T5[1] { (T5)61 })).Last();
				val2 = (T1)HttpUtility.UrlDecode((string)val2);
				T4 val4 = (T4)((string)val2).Contains("=");
				if (val4 != null)
				{
					value = ((IEnumerable<T1>)(object)((string)val2).Split((char[])(object)new T5[1] { (T5)61 })).Last();
				}
			}
			T4 val5 = (T4)string.IsNullOrWhiteSpace((string)value);
			if (val5 != null)
			{
				val2 = (T1)((HttpRequest)val).Address.ToString();
				T4 val6 = (T4)((string)val2).Contains("next");
				if (val6 != null)
				{
					T1 str = ((IEnumerable<T1>)(object)((string)val2).Split((string[])(object)new T1[1] { (T1)"next=" }, StringSplitOptions.None)).Last();
					str = (T1)HttpUtility.UrlDecode((string)str);
					value = (T1)Regex.Match((string)str, "token=(.*?)&").Groups[1].Value;
				}
			}
			T3 val7 = (T3)Activator.CreateInstance(typeof(T3));
			((Dictionary<string, string>)val7).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			T1 value2 = getFirstName<T4, T1, T0>();
			T1 value3 = getLastName<T4, T1, T0>();
			T4 val8 = (T4)(!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Name));
			if (val8 != null)
			{
				T4 val9 = (T4)frmMain.listFBEntity[indexEntity].Name.Contains(" ");
				if (val9 == null)
				{
					value2 = (T1)frmMain.listFBEntity[indexEntity].Name;
					value3 = (T1)frmMain.listFBEntity[indexEntity].Name;
				}
				else
				{
					value2 = ((IEnumerable<T1>)(object)frmMain.listFBEntity[indexEntity].Name.Split((char[])(object)new T5[1] { (T5)32 })).First();
					value3 = ((IEnumerable<T1>)(object)frmMain.listFBEntity[indexEntity].Name.Split((char[])(object)new T5[1] { (T5)32 })).Last();
				}
			}
			((Dictionary<string, string>)val7).Add("strFirstName", (string)value2);
			((Dictionary<string, string>)val7).Add("strLastName", (string)value3);
			((Dictionary<string, string>)val7).Add("strUrlToken", (string)value);
			((Dictionary<string, string>)val7).Add("strPassword", frmMain.listFBEntity[indexEntity].Password);
			T1 resouce = (T1)ResouceControl.getResouce("Nhan_Link_BM", (Dictionary<string, string>)val7);
			T1 val10 = executeScript<T1, IJavaScriptExecutor, T0, T4, object>(resouce);
			T4 val11 = (T4)string.IsNullOrWhiteSpace((string)val10);
			if (val11 == null)
			{
				T4 val12 = (T4)((string)val10).Contains("errorSummary");
				if (val12 != null)
				{
					T4 val13 = (T4)((string)val10).Contains("1357008");
					if (val13 != null)
					{
						setMessage((T1)"Sai mật khẩu", (T4)1);
						result = (T0)1;
					}
					else
					{
						T4 val14 = (T4)((string)val10).Contains("1390008");
						if (val14 != null)
						{
							setMessage((T1)"Spam.", (T4)1);
							result = (T0)4;
						}
						else
						{
							T4 val15 = (T4)((string)val10).Contains("1690212");
							if (val15 == null)
							{
								T4 val16 = (T4)((string)val10).Contains("1404163");
								if (val16 != null)
								{
									message = Regex.Match((string)val10, "errorSummary\":\"(.*?)\"").Groups[1].Value;
									message = Regex.Unescape(message);
									setMessage((T1)message, (T4)1);
									result = (T0)1;
								}
								else
								{
									T4 val17 = (T4)((string)val10).Contains("1348033");
									if (val17 == null)
									{
										message = Regex.Match((string)val10, "errorSummary\":\"(.*?)\"").Groups[1].Value;
										message = Regex.Unescape(message);
										setMessage((T1)message, (T4)1);
										result = (T0)1;
									}
									else
									{
										message = Regex.Match((string)val10, "errorSummary\":\"(.*?)\"").Groups[1].Value;
										message = Regex.Unescape(message);
										setMessage((T1)message, (T4)1);
										result = (T0)2;
									}
								}
							}
							else
							{
								result = (T0)0;
							}
						}
					}
				}
				else
				{
					setMessage((T1)"Nhận link BM thành công", (T4)1);
					result = (T0)2;
				}
			}
			else
			{
				isLogined = false;
				result = (T0)3;
				setMessage((T1)"Checkpoint", (T4)1);
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 receiptLinkBM<T0, T1, T2, T3, T4, T5, T6, T7>(T3 bm)
	{
		//IL_0002: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00b7: Expected I4, but got O
		//IL_00b9: Expected O, but got I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0111: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_01fb: Expected O, but got I4
		//IL_022d: Expected O, but got I4
		//IL_025f: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02aa: Expected O, but got I4
		//IL_02cd: Expected O, but got I4
		//IL_02f8: Expected O, but got I4
		//IL_032b: Expected O, but got I4
		//IL_0336: Expected I4, but got O
		//IL_0338: Expected O, but got I4
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_0386: Expected O, but got I4
		//IL_039c: Expected O, but got I4
		//IL_03ab: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			goUrl<T4, T0, T1, T6, Exception, T3>(bm);
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("input"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 == null)
			{
				val = (T0)0;
			}
			else
			{
				T2 val4 = (T2)chrome;
				((IWebElement)((IEnumerable<T6>)val2).First()).Click();
				T3 val5 = (T3)frmMain.listFBEntity[indexEntity].Name;
				T0 val6 = (T0)string.IsNullOrWhiteSpace((string)val5);
				if (val6 != null)
				{
					val5 = (T3)"a a";
				}
				T0 val7 = (T0)(!((string)val5).Contains(" "));
				if (val7 != null)
				{
					val5 = (T3)((string)val5 + " " + (string)val5);
				}
				T3 val8 = val5;
				T4 val9 = (T4)0;
				while ((nint)val9 < ((string)val8).Length)
				{
					T5 val10 = (T5)((string)val8)[(int)val9];
					((IWebElement)((IEnumerable<T6>)val2).First()).SendKeys(((char*)(&val10))->ToString());
					val9 = (T4)(val9 + 1);
				}
				Thread.Sleep(500);
				T1 val11 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
				T0 val12 = (T0)(val11 != null && ((ReadOnlyCollection<IWebElement>)val11).Count > 0);
				if (val12 != null)
				{
					((IJavaScriptExecutor)val4).ExecuteScript("document.getElementsByTagName('button')[0].click();", (object[])(object)Array.Empty<T7>());
					Thread.Sleep(500);
				}
				val11 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
				T0 val13 = (T0)(val11 != null && ((ReadOnlyCollection<IWebElement>)val11).Count > 0);
				if (val13 != null)
				{
					((IJavaScriptExecutor)val4).ExecuteScript("document.getElementsByTagName('button')[0].click();", (object[])(object)Array.Empty<T7>());
					Thread.Sleep(500);
				}
				val11 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
				T0 val14 = (T0)(val11 != null && ((ReadOnlyCollection<IWebElement>)val11).Count > 0);
				if (val14 != null)
				{
					((IJavaScriptExecutor)val4).ExecuteScript("document.getElementsByTagName('button')[0].click();", (object[])(object)Array.Empty<T7>());
					T4 val15 = (T4)0;
					while (true)
					{
						T0 val16 = (T0)((nint)val15 < 50);
						if (val16 == null)
						{
							break;
						}
						T0 val17 = (T0)(((RemoteWebDriver)chrome).Url.Contains("home/accounts") || ((RemoteWebDriver)chrome).Url.Contains("latest/home"));
						if (val17 != null)
						{
							break;
						}
						T1 val18 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("ajax_password"));
						T0 val19 = (T0)(val18 != null && ((ReadOnlyCollection<IWebElement>)val18).Count > 0);
						if (val19 != null)
						{
							break;
						}
						T1 val20 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("uiList"));
						T0 val21 = (T0)(val20 != null && ((ReadOnlyCollection<IWebElement>)val20).Count > 0);
						if (val21 == null)
						{
							T1 val22 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("uiOverlayButton"));
							T0 val23 = (T0)(val22 != null && ((ReadOnlyCollection<IWebElement>)val22).Count > 0);
							if (val23 == null)
							{
								val15 = (T4)(val15 + 1);
								Thread.Sleep(1000);
								continue;
							}
							((IWebElement)((IEnumerable<T6>)val22).Last()).Click();
							Thread.Sleep(2000);
							break;
						}
						val = (T0)0;
						break;
					}
				}
				T1 val24 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("ajax_password"));
				T0 val25 = (T0)(val24 != null && ((ReadOnlyCollection<IWebElement>)val24).Count > 0);
				if (val25 != null)
				{
					((IWebElement)((IEnumerable<T6>)val24).First()).Click();
					T3 password = (T3)frmMain.listFBEntity[indexEntity].Password;
					T4 val26 = (T4)0;
					while ((nint)val26 < ((string)password).Length)
					{
						T5 val27 = (T5)((string)password)[(int)val26];
						((IWebElement)((IEnumerable<T6>)val24).First()).SendKeys(((char*)(&val27))->ToString());
						val26 = (T4)(val26 + 1);
					}
					Thread.Sleep(500);
					((IWebElement)((IEnumerable<T6>)val24).First()).SendKeys(Keys.Enter);
					Thread.Sleep(5000);
				}
			}
		}
		catch
		{
			val = (T0)0;
		}
		T0 val28 = val;
		if (val28 != null)
		{
			setMessage((T3)"Nhận link BM thành công", (T0)1);
		}
		else
		{
			setMessage((T3)"Nhận link BM lỗi", (T0)1);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 removeLimitInCamp_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0112: Expected I4, but got O
		//IL_0128: Expected O, but got I4
		//IL_0134: Expected I4, but got O
		//IL_0153: Expected I4, but got O
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_017a: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", ((string)str).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("remove_limit_on_camp", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 changeInfoAct_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData, T1 BM_ID, T1 Đổi_múi_giờ, T1 Đổi_tiền_tệ, T1 Quốc_gia, T1 State, T1 Địa_chỉ, T1 Zip, T1 City)
	{
		//IL_0002: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_01f1: Expected I4, but got O
		//IL_0207: Expected O, but got I4
		//IL_0213: Expected I4, but got O
		//IL_0230: Expected I4, but got O
		//IL_0241: Expected I4, but got O
		//IL_025e: Expected I4, but got O
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_0289: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strBMID", (string)BM_ID);
					((Dictionary<string, string>)val4).Add("strAct", ((string)str).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strCountry", (string)Quốc_gia);
					T0 val5 = (T0)(!((string)Quốc_gia).ToLower().Equals("us"));
					if (val5 != null)
					{
						State = (T1)"";
					}
					((Dictionary<string, string>)val4).Add("strState", (string)State);
					((Dictionary<string, string>)val4).Add("strAddress", HttpUtility.HtmlEncode((string)Địa_chỉ));
					((Dictionary<string, string>)val4).Add("strZip", (string)Zip);
					((Dictionary<string, string>)val4).Add("strBusinessName", (string)getFirstName<T0, T1, T5>() + " " + System.Runtime.CompilerServices.Unsafe.As<T5, int>(ref (T5)rnd.Next(111, 999)));
					((Dictionary<string, string>)val4).Add("strTimeZone", (string)Đổi_múi_giờ);
					((Dictionary<string, string>)val4).Add("strCurrency", (string)Đổi_tiền_tệ);
					((Dictionary<string, string>)val4).Add("strCity", HttpUtility.HtmlEncode((string)City));
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("Doi_Thong_Tin_TK_BM_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val6 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val7 = (T0)(val6 != null && ((List<object>)val6).Count > 0);
			if (val7 != null)
			{
				T5 val8 = (T5)0;
				while (true)
				{
					T0 val9 = (T0)((nint)val8 < ((List<ListStringData>)listData).Count);
					if (val9 == null)
					{
						break;
					}
					T1 val10 = (T1)((List<object>)val6)[(int)val8].ToString();
					T0 val11 = (T0)((string)val10).Contains("api_error_code");
					if (val11 == null)
					{
						((List<ListStringData>)listData)[(int)val8].str4 = frmMain.STATUS.Done.ToString();
						((List<ListStringData>)listData)[(int)val8].str5 = (string)Quốc_gia;
					}
					else
					{
						((List<ListStringData>)listData)[(int)val8].str4 = frmMain.STATUS.lỗi.ToString();
						((List<ListStringData>)listData)[(int)val8].str5 = "";
					}
					val8 = (T5)(val8 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getCredential_id<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 strAct, T0 strBMID)
	{
		//IL_008a: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_00f4: Expected I4, but got O
		//IL_0100: Expected I4, but got O
		//IL_0109: Expected O, but got I4
		//IL_0116: Expected I4, but got O
		//IL_0118: Expected O, but got I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0137: Expected O, but got I4
		T0 val = (T0)"";
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val2).Add("strBMID", (string)strBMID);
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			T0 resouce = (T0)ResouceControl.getResouce("get_credential_id", (Dictionary<string, string>)val2);
			T0 val3 = executeScript<T0, IJavaScriptExecutor, T5, T2, object>(resouce);
			T2 val4 = (T2)((string)val3).Contains("credential_id");
			if (val4 != null)
			{
				val3 = (T0)((string)val3).Replace(" ", "").Replace("\"", "");
				T0 val5 = (T0)"credential_id:";
				T3 enumerator = (T3)Regex.Matches((string)val3, (string)val5).GetEnumerator();
				try
				{
					if (((IEnumerator)enumerator).MoveNext())
					{
						T4 val6 = (T4)((IEnumerator)enumerator).Current;
						T5 val7 = (T5)((Capture)val6).Index;
						while (true)
						{
							T2 val8 = (T2)((nint)val7 < ((string)val3).Length);
							if (val8 != null)
							{
								T2 val9 = (T2)(((string)val3)[(int)val7] == ',' || ((string)val3)[(int)val7] == '}');
								if (val9 == null)
								{
									val = (T0)((string)val + System.Runtime.CompilerServices.Unsafe.As<T6, char>(ref (T6)((string)val3)[(int)val7]));
									val7 = (T5)(val7 + 1);
									continue;
								}
								break;
							}
							break;
						}
					}
				}
				finally
				{
					T7 val10 = (T7)((enumerator is T7) ? enumerator : null);
					if (val10 != null)
					{
						((IDisposable)val10).Dispose();
					}
				}
				val = (T0)((string)val).Replace((string)val5, "").Replace("\"", "").Replace(" ", "")
					.Replace("}", "");
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 day_the_len_chinh<T0, T1, T2, T3>(T2 strAct, T2 strCredential_id, T2 strBMID)
	{
		//IL_0002: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strCredential_id", (string)strCredential_id);
			((Dictionary<string, string>)val).Add("strBMID", (string)strBMID);
			T2 resouce = (T2)ResouceControl.getResouce("day_the_len_chinh", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)(!((string)val2).Contains("is_primary\":true"));
			if (val3 != null)
			{
				result = (T0)0;
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 removeLimit<T0, T1, T2>(T2 strAct)
	{
		//IL_0002: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strBMID", "");
			T2 resouce = (T2)ResouceControl.getResouce("remove_limit", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("error");
			if (val3 != null)
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
	public unsafe T0 removeLimit_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0124: Expected I4, but got O
		//IL_013a: Expected O, but got I4
		//IL_0146: Expected I4, but got O
		//IL_0165: Expected I4, but got O
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_018c: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", ((string)str).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strBMID", "");
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("remove_limit_promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("error");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 khangTK<T0, T1, T2>(T2 strAct, T2 strMessage, T2 strBMID)
	{
		//IL_0002: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strACT", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strBMID", (string)strBMID);
			T2 value = (T2)HttpUtility.UrlPathEncode((string)strMessage);
			((Dictionary<string, string>)val).Add("strMessage", (string)value);
			T2 resouce = (T2)ResouceControl.getResouce("khang_tkqc", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("success\":true");
			if (val3 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 khangTk_273_Yes<T0, T1, T2>(T2 strAct, T2 strMessage)
	{
		//IL_0002: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			T2 value = (T2)HttpUtility.UrlPathEncode((string)strMessage);
			((Dictionary<string, string>)val).Add("strMessage", (string)value);
			T2 resouce = (T2)ResouceControl.getResouce("khang_273_Yes", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("success\":true");
			if (val3 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 khangTk_273_No<T0, T1, T2>(T2 strAct, T2 strMessage)
	{
		//IL_0002: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			T2 value = (T2)HttpUtility.UrlPathEncode((string)strMessage);
			((Dictionary<string, string>)val).Add("strMessage", (string)value);
			T2 resouce = (T2)ResouceControl.getResouce("khang_273_No", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("success\":true");
			if (val3 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 khangTK_792<T0, T1, T2>(T2 strAct, T2 strMessage, T2 strBMID)
	{
		//IL_0002: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strBMID", (string)strBMID);
			((Dictionary<string, string>)val).Add("strMessage", (string)strMessage);
			T2 resouce = (T2)ResouceControl.getResouce("khangTK_792", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("success\":true");
			if (val3 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 sharePartner<T0, T1, T2>(T2 Act, T2 BM_ID, T2 Partner_Id)
	{
		//IL_0002: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strAct_id_2", "\"" + ((string)Act).Replace("act_", "") + "\"");
			((Dictionary<string, string>)val).Add("strAct_id", "\"act_" + ((string)Act).Replace("act_", "") + "\"");
			((Dictionary<string, string>)val).Add("strActing_brand_id", "\"" + (string)BM_ID + "\"");
			((Dictionary<string, string>)val).Add("strAnother_business", "\"" + (string)Partner_Id + "\"");
			((Dictionary<string, string>)val).Add("strToken", "\"" + frmMain.listFBEntity[indexEntity].TokenEAAG + "\"");
			T2 resouce = (T2)ResouceControl.getResouce("share_doi_tac", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("true");
			if (val3 != null)
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
	public T0 tao_link_moi_bm<T0, T1, T2, T3>(T3 strBM_ID, T3 strEmail, T0 isAdmin)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00d7: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		T0 val = (T0)0;
		T1 val2 = (T1)0;
		T0 val8;
		do
		{
			try
			{
				strEmail = (T3)((string)strEmail).Replace("@", "%40");
				strEmail = (T3)((string)strEmail).Replace("+", "%2B");
				T2 val3 = (T2)Activator.CreateInstance(typeof(T2));
				((Dictionary<string, string>)val3).Add("strBM_ID", (string)strBM_ID);
				((Dictionary<string, string>)val3).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
				((Dictionary<string, string>)val3).Add("strEmail", (string)strEmail);
				T0 val4 = (T0)(isAdmin == null);
				if (val4 != null)
				{
					((Dictionary<string, string>)val3).Add("ADMIN", "EMPLOYEE");
				}
				T3 resouce = (T3)ResouceControl.getResouce("tao_link_moi_bm", (Dictionary<string, string>)val3);
				T3 val5 = executeScript<T3, IJavaScriptExecutor, T1, T0, object>(resouce);
				T0 val6 = (T0)((string)val5).Contains("id");
				if (val6 != null)
				{
					val = (T0)1;
				}
			}
			catch
			{
			}
			T0 val7 = (T0)(val == null);
			if (val7 == null)
			{
				break;
			}
			val2 = (T1)(val2 + 1);
			val8 = (T0)((nint)val2 <= 5);
		}
		while (val8 != null);
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 doi_ten_BM<T0, T1, T2>(T2 strBM_ID, T2 strNewName)
	{
		//IL_0002: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strBMID", (string)strBM_ID);
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val).Add("strNewName", (string)strNewName);
			T2 resouce = (T2)ResouceControl.getResouce("doi_ten_BM", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("id");
			if (val3 != null)
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
	public T1 fetch_url<T0, T1, T2>(T1 url)
	{
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUrl", (string)url);
			T1 resouce = (T1)ResouceControl.getResouce("fetch_url", (Dictionary<string, string>)val);
			return executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
		}
		catch (Exception ex)
		{
			return (T1)ex.Message;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getUID_FromLink<T0, T1, T2>(T0 profileUrl)
	{
		profileUrl = (T0)((string)profileUrl).Replace("www.facebook", "business.facebook");
		T0 input = fetch_url<T1, T0, T2>(profileUrl);
		return (T0)Regex.Match((string)input, "entity_id\":\"(.*?)\"").Groups[1].Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 fetch_url_business<T0, T1, T2>(T1 url)
	{
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUrl", (string)url);
			T1 resouce = (T1)ResouceControl.getResouce("fetch_url_business", (Dictionary<string, string>)val);
			return executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
		}
		catch (Exception ex)
		{
			return (T1)ex.Message;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 changeNameAct<T0, T1, T2>(T2 strAct, T2 strNameAtc)
	{
		//IL_0002: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			strNameAtc = (T2)((string)strNameAtc).Replace(" ", "%20");
			((Dictionary<string, string>)val2).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val2).Add("strNameAtc", (string)strNameAtc);
			T2 resouce = (T2)ResouceControl.getResouce("change_name_act", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("true");
			if (val4 != null)
			{
				return (T0)1;
			}
			return (T0)0;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 changeNameAct_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_013c: Expected I4, but got O
		//IL_0152: Expected O, but got I4
		//IL_015e: Expected I4, but got O
		//IL_017d: Expected I4, but got O
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01a4: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("strNameAtc", current.str2.Replace(" ", "%20"));
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("change_name_act_promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("true");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str3 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str3 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 shareTK<T0, T1, T2>(T2 strAct, T2 strUID_Nhan)
	{
		//IL_0002: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val2).Add("strUID_NHAN", (string)strUID_Nhan);
			T2 resouce = (T2)ResouceControl.getResouce("share_quyen_tkqc", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("success\":true");
			if (val4 == null)
			{
				return (T0)0;
			}
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 thu_lai_tam_giu_tien<T0, T1, T2>(T2 strAct)
	{
		//IL_0002: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			T2 resouce = (T2)ResouceControl.getResouce("thu_lai_tam_giu_tien", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("is_reauth_restricted\":true");
			if (val4 != null)
			{
				return (T0)0;
			}
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 thu_lai_tam_giu_tien_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0112: Expected I4, but got O
		//IL_0128: Expected O, but got I4
		//IL_0134: Expected I4, but got O
		//IL_0153: Expected I4, but got O
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_017a: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", ((string)str).Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("thu_lai_tam_giu_tien_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("is_reauth_restricted\":true");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 check_life_act_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listI, frmAdsManager frm)
	{
		//IL_0002: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0038: Expected I4, but got O
		//IL_007a: Expected I4, but got O
		//IL_0128: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_014e: Expected I4, but got O
		//IL_0160: Expected O, but got I4
		//IL_0171: Expected I4, but got O
		//IL_0196: Expected I4, but got O
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01cd: Expected O, but got I4
		//IL_01d3: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<int>)listI).GetEnumerator();
			try
			{
				while (((List<int>.Enumerator*)(&enumerator))->MoveNext())
				{
					T4 val3 = (T4)((List<int>.Enumerator*)(&enumerator))->Current;
					T1 val4 = (T1)("fetch_" + frm.listData[(int)val3].id.Replace("act_", ""));
					T5 val5 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val5).Add("strAct", frm.listData[(int)val3].id.Replace("act_", ""));
					((Dictionary<string, string>)val5).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val5).Add("result", (string)val4);
					T1 resouce = (T1)ResouceControl.getResouce("check_life_act_Promise", (Dictionary<string, string>)val5);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val4 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<int>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val6 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val7 = (T0)(val6 != null && ((List<object>)val6).Count > 0);
			if (val7 != null)
			{
				T4 val8 = (T4)0;
				T3 enumerator2 = (T3)((List<int>)listI).GetEnumerator();
				try
				{
					while (((List<int>.Enumerator*)(&enumerator2))->MoveNext())
					{
						T4 val9 = (T4)((List<int>.Enumerator*)(&enumerator2))->Current;
						T0 val10 = (T0)((List<object>)val6)[(int)val8].ToString().Contains("ACCOUNT_STATUS_ACTIVE");
						if (val10 != null)
						{
							frm.listData[(int)val9].message = frmMain.STATUS.Live.ToString();
						}
						else
						{
							frm.listData[(int)val9].message = frmMain.STATUS.VHH.ToString();
						}
						val8 = (T4)(val8 + 1);
					}
				}
				finally
				{
					((IDisposable)(*(List<int>.Enumerator*)(&enumerator2))).Dispose();
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 createAct<T0, T1, T2, T3>()
	{
		//IL_001a: Expected O, but got I4
		T0 val = (T0)"";
		T1 val2 = (T1)(!frmMain.isRunning || chrome == null);
		if (val2 == null)
		{
			try
			{
				T0 resouce = (T0)ResouceControl.getResouce("Tao_TKCN_Buoc_1");
				T0 val3 = executeScript<T0, IJavaScriptExecutor, int, T1, object>(resouce);
				T2 val4 = (T2)Activator.CreateInstance(typeof(T2));
				((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
				resouce = (T0)ResouceControl.getResouce("Tao_TKCN_Buoc_2", (Dictionary<string, string>)val4);
				val3 = executeScript<T0, IJavaScriptExecutor, int, T1, object>(resouce);
				val = (T0)Regex.Match((string)val3, "{\"id\":\"(\\d+)\",").Groups[1].Value;
				val4 = (T2)Activator.CreateInstance(typeof(T2));
				((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
				((Dictionary<string, string>)val4).Add("strAct_Id", (string)val);
				resouce = (T0)ResouceControl.getResouce("Tao_TKCN_Buoc_3", (Dictionary<string, string>)val4);
				val3 = executeScript<T0, IJavaScriptExecutor, int, T1, object>(resouce);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return val;
		}
		return (T0)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Share_Tk_Cá_Nhân_Vào_BM<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00e5: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			setMessage((T3)"Đang thêm vào BM", (T0)0);
			T0 val2 = (T0)(frmMain.nolimitApi == null);
			if (val2 != null)
			{
				frmMain.nolimitApi = new FacebookNoLimitApi(frmMain);
			}
			getFullAdsInfo<Dictionary<string, string>, T3, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, T4, char, IDisposable, T5, IWebElement>();
			Activator.CreateInstance(typeof(T1));
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T3 val3 = (T3)current.id.Replace("act_", "");
					T4 val4 = frmMain.nolimitApi.requestAddToBm<T4, HttpRequest, T3, T0>(val3);
					T0 val5 = (T0)(val4 == null);
					if (val5 != null)
					{
						setMessage((T3)"Đang chờ clone chấp nhận", (T0)0);
						T0 val6 = acceptRequestToBm<T0, T3, Dictionary<string, string>>(val3);
						if (val6 != null)
						{
							setMessage((T3)"Thêm BM Ok", (T0)1);
							continue;
						}
						frmMain.nolimitApi.clearRequest<HttpRequest, T3, T0>(val3);
						setMessage((T3)"Thêm BM lỗi", (T0)1);
					}
					else
					{
						T0 val7 = (T0)((nint)val4 == 1);
						if (val7 == null)
						{
							frmMain.nolimitApi.clearRequest<HttpRequest, T3, T0>(val3);
							setMessage((T3)"Thêm BM lỗi", (T0)1);
						}
						else
						{
							setMessage((T3)"Thêm BM Ok", (T0)1);
						}
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
	public unsafe void Tạo_Tk_Cá_Nhân<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_01ca: Expected O, but got I4
		//IL_0261: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_02b7: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_02f4: Expected O, but got I4
		//IL_02fd: Expected O, but got I4
		//IL_030e: Expected O, but got I4
		//IL_0330: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_cho_BM").ToString());
			T1 mS_thuế = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"MS_thuế").ToString();
			T1 quốc_gia = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_quốc_gia").ToString();
			T1 đổi_tiền_tệ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tiền_tệ").ToString();
			T1 đổi_múi_giờ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_múi_giờ").ToString();
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tên").ToString();
			T1 url = (T1)"https://business.facebook.com/ad_campaign/landing.php?placement=bkmk_admgr&campaign_id=415838275119884&nav_source=comet&nav_entry_point=comet_bookmark&extra_1=campaign";
			T1 val4 = createAct<T1, T0, T5, T4>();
			Thread.Sleep(1500);
			getFullAdsInfo<T5, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, T3, char, IDisposable, T4, IWebElement>();
			T0 val5 = (T0)(frmMain.listFBEntity[indexEntity].fullAdsInfo == null || frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts == null || frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data == null || frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.Count <= 0);
			if (val5 != null)
			{
				goUrl<T3, T0, ReadOnlyCollection<IWebElement>, IWebElement, T4, T1>(url);
				goUrl<T3, T0, ReadOnlyCollection<IWebElement>, IWebElement, T4, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
				getFullAdsInfo<T5, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, T3, char, IDisposable, T4, IWebElement>();
			}
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					val4 = (T1)current.id.Replace("act_", "");
					T0 val6 = (T0)string.IsNullOrWhiteSpace((string)val3);
					if (val6 != null)
					{
						changeNameAct<T0, T5, T1>((T1)current.id, (T1)frmMain.listFBEntity[indexEntity].UID);
					}
					else
					{
						changeNameAct<T0, T5, T1>((T1)current.id, val3);
					}
					changeInfoAct<T5, T1, T0, T3>((T1)current.id.Replace("act_", ""), (T1)"", đổi_múi_giờ, đổi_tiền_tệ, quốc_gia, mS_thuế, (T1)"NY", (T1)"1 Facebook Way", (T1)"94025", (T1)"Menlo Park");
					T0 val7 = val2;
					if (val7 == null)
					{
						continue;
					}
					setMessage((T1)"Đang thêm vào BM", (T0)0);
					T0 val8 = (T0)(frmMain.nolimitApi == null);
					if (val8 != null)
					{
						frmMain.nolimitApi = new FacebookNoLimitApi(frmMain);
					}
					T3 val9 = frmMain.nolimitApi.requestAddToBm<T3, HttpRequest, T1, T0>(val4);
					T0 val10 = (T0)(val9 == null);
					if (val10 != null)
					{
						setMessage((T1)"Đang chờ clone chấp nhận", (T0)0);
						T0 val11 = acceptRequestToBm<T0, T1, T5>(val4);
						if (val11 != null)
						{
							setMessage((T1)"Thêm BM Ok", (T0)1);
							continue;
						}
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val4);
						setMessage((T1)"Thêm BM lỗi", (T0)1);
					}
					else
					{
						T0 val12 = (T0)((nint)val9 == 1);
						if (val12 != null)
						{
							setMessage((T1)"Thêm BM Ok", (T0)1);
							continue;
						}
						frmMain.nolimitApi.clearRequest<HttpRequest, T1, T0>(val4);
						setMessage((T1)"Thêm BM lỗi", (T0)1);
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

	public unsafe T0 acceptRequestToBm<T0, T1, T2>(T1 act_id)
	{
		//IL_0002: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		T0 val = (T0)0;
		T1 ad_market_id;
		T1 agency_id;
		agency_permission_requests_getter<T0, T2, T1>(act_id, out *(string*)(&ad_market_id), out *(string*)(&agency_id));
		T1 ext;
		T1 hash;
		get_ext_hash<T0, T2, T1>(act_id, ad_market_id, agency_id, out *(string*)(&ext), out *(string*)(&hash));
		T0 val2 = accept_agency_permission<T0, T2, T1>(act_id, ad_market_id, agency_id, ext, hash);
		if (val2 == null)
		{
			return (T0)0;
		}
		return (T0)1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 setLimit<T0, T1, T2>(T2 strAct, T2 strBMID, T2 strCurrency, T2 strAmount)
	{
		//IL_0002: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val2).Add("strBMID", (string)strBMID);
			((Dictionary<string, string>)val2).Add("strCurrency", (string)strCurrency);
			((Dictionary<string, string>)val2).Add("strAmount", (string)strAmount);
			T2 resouce = (T2)ResouceControl.getResouce("Set_Limit", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("errors");
			if (val4 == null)
			{
				return (T0)1;
			}
			return (T0)0;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 setLimit_Promise<T0, T1, T2, T3, T4, T5, T6>(T6 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_0154: Expected I4, but got O
		//IL_016f: Expected O, but got I4
		//IL_017b: Expected I4, but got O
		//IL_019a: Expected I4, but got O
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01c1: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		//IL_01cc: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strAct", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strBMID", "");
					((Dictionary<string, string>)val4).Add("strCurrency", current.str2);
					((Dictionary<string, string>)val4).Add("strAmount", current.str3);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("Set_Limit_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, Exception, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString().ToLower();
					T0 val10 = (T0)((string)val9).Contains("errors");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 account_close<T0, T1, T2>(T2 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
			T2 resouce = (T2)ResouceControl.getResouce("account_close", (Dictionary<string, string>)val2);
			executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 account_unsettled<T0, T1, T2>(T2 act)
	{
		//IL_0002: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strAct", ((string)act).Replace("act_", ""));
			T2 resouce = (T2)ResouceControl.getResouce("account_unsettled", (Dictionary<string, string>)val2);
			executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 xoa_bm_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_0135: Expected I4, but got O
		//IL_014b: Expected O, but got I4
		//IL_0157: Expected I4, but got O
		//IL_017b: Expected O, but got I4
		//IL_0187: Expected I4, but got O
		//IL_01b3: Expected I4, but got O
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01da: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_01e9: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)"";
			T1 val3 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val4 = (T1)("fetch_" + (string)str);
					T4 val5 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val5).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val5).Add("strBMID", current.str1);
					((Dictionary<string, string>)val5).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val5).Add("result", (string)val4);
					T1 resouce = (T1)ResouceControl.getResouce("xoa_bm_Promise", (Dictionary<string, string>)val5);
					val2 = (T1)((string)val2 + (string)resouce);
					val3 = (T1)((string)val3 + (string)val4 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val6 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val2, val3);
			T0 val7 = (T0)(val6 != null && ((List<object>)val6).Count > 0);
			if (val7 != null)
			{
				T5 val8 = (T5)0;
				while (true)
				{
					T0 val9 = (T0)((nint)val8 < ((List<ListStringData>)listData).Count);
					if (val9 == null)
					{
						break;
					}
					T1 val10 = (T1)((List<object>)val6)[(int)val8].ToString();
					T0 val11 = (T0)((string)val10).Contains("success\":true");
					if (val11 == null)
					{
						((List<ListStringData>)listData)[(int)val8].str2 = frmMain.STATUS.lỗi.ToString();
						T0 val12 = (T0)((string)val10).Contains("message");
						if (val12 != null)
						{
							((List<ListStringData>)listData)[(int)val8].str3 = Regex.Match((string)val10, "message\":\"(.*?).\"").Groups[1].Value;
						}
					}
					else
					{
						((List<ListStringData>)listData)[(int)val8].str2 = frmMain.STATUS.Done.ToString();
					}
					val8 = (T5)(val8 + 1);
				}
			}
			val = (T0)1;
		}
		catch (Exception ex)
		{
			val = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 xoa_loi_moi_bm<T0, T1, T2, T3, T4, T5, T6, T7>(T1 strBMID, T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_0107: Expected I4, but got O
		//IL_011d: Expected O, but got I4
		//IL_0129: Expected I4, but got O
		//IL_0148: Expected I4, but got O
		//IL_015f: Expected O, but got I4
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0171: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_017d: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("strUserId", current.str1);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("xoa_loi_moi_bm_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
						result = (T0)1;
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 xoa_doi_tac_bm<T0, T1, T2, T3, T4, T5, T6, T7>(T1 strBMID, T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0115: Expected I4, but got O
		//IL_012b: Expected O, but got I4
		//IL_0137: Expected I4, but got O
		//IL_0156: Expected I4, but got O
		//IL_016d: Expected O, but got I4
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_017f: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strBMID", (string)strBMID);
					((Dictionary<string, string>)val4).Add("strPartnerID", current.str1);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("xoa_doi_tac_bm_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("error");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
						result = (T0)1;
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 xoa_quyen_page_bm_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T1 strPageId, T7 listData, T0 isClassPage)
	{
		//IL_0002: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		//IL_0110: Expected I4, but got O
		//IL_0126: Expected O, but got I4
		//IL_0132: Expected I4, but got O
		//IL_0151: Expected I4, but got O
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0178: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUserId", (string)str);
					((Dictionary<string, string>)val4).Add("strPageId", (string)strPageId);
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("xoa_quyen_page_bm_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 chi_dinh_user_page_Promise<T0, T1, T2, T3, T4, T5, T6>(T1 strPageId, T1 strBMID, T5 listData, T0 isClassPage)
	{
		//IL_0002: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_004b: Expected I4, but got O
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_01c6: Expected O, but got I4
		//IL_01d2: Expected I4, but got O
		//IL_01de: Expected O, but got I4
		//IL_01ea: Expected I4, but got O
		//IL_0209: Expected I4, but got O
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0230: Expected O, but got I4
		//IL_0236: Expected O, but got I4
		//IL_023c: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T1 val3 = (T1)"";
			T3 val4 = (T3)0;
			while (true)
			{
				T0 val5 = (T0)((nint)val4 < ((List<ListStringData>)listData).Count);
				if (val5 == null)
				{
					break;
				}
				T0 val6 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
				if (val6 != null)
				{
					val3 = (T1)((string)val3 + "&");
				}
				val3 = (T1)((string)val3 + $"user_ids[{val4}]={((List<ListStringData>)listData)[(int)val4].str1}");
				val4 = (T3)(val4 + 1);
			}
			T1 val7 = (T1)"sssssssssssss";
			T1 val8 = (T1)("fetch_" + (string)val7);
			T1 val9 = (T1)"";
			val9 = (T1)((isClassPage == null) ? ResouceControl.getResouce("chi_dinh_user_page_Promise") : ResouceControl.getResouce("chi_dinh_user_Classic_Page_Promise"));
			val9 = (T1)((string)val9).Replace("strUserId", (string)val3);
			val9 = (T1)((string)val9).Replace("strPageId", (string)strPageId);
			val9 = (T1)((string)val9).Replace("strBMID", (string)strBMID);
			val9 = (T1)((string)val9).Replace("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			val9 = (T1)((string)val9).Replace("result", (string)val8);
			val = (T1)((string)val + (string)val9);
			val2 = (T1)((string)val2 + (string)val8 + ",");
			T2 val10 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T4, char, T6>(val, val2);
			T0 val11 = (T0)(val10 != null && ((List<object>)val10).Count > 0);
			if (val11 != null)
			{
				T1 value = (T1)Regex.Match(((IEnumerable<T6>)val10).First().ToString(), "successes\":{\"" + (string)strPageId + "\":(.*?)}").Groups[1].Value;
				_ = Regex.Match(((IEnumerable<T6>)val10).First().ToString(), "failures\":{\"" + (string)strPageId + "\":(.*?)}").Groups[1].Value;
				T3 val12 = (T3)0;
				while (true)
				{
					T0 val13 = (T0)((nint)val12 < ((List<ListStringData>)listData).Count);
					if (val13 == null)
					{
						break;
					}
					T0 val14 = (T0)((string)value).Contains(((List<ListStringData>)listData)[(int)val12].str1);
					if (val14 == null)
					{
						((List<ListStringData>)listData)[(int)val12].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val12].str2 = frmMain.STATUS.Done.ToString();
					}
					val12 = (T3)(val12 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UserInBM getListUserInBM<T0, T1, T2, T3>(T0 BM_Id, T0 typeUser)
	{
		//IL_008e: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		try
		{
			T0 val = (T0)"";
			val = (T0)string.Concat((string[])(object)new T0[7]
			{
				(T0)"https://graph.facebook.com/v14.0/",
				BM_Id,
				(T0)"/",
				typeUser,
				(T0)"?access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG,
				(T0)"&__activeScenarioIDs=[]&__activeScenarios=[]&__interactionsMetadata=[]&_reqName=object:business/business_users&_reqSrc=BusinessConnectedConfirmedUsersStore.brands&after=QVFIUjJmMlczWFd1MWV0Y0hmR0lXcXZAjTXlLYWd4a1BVSWVhbElfNzYwakt3bEZAqUEZAjTkxLMGNuOWNlOG9oOEVaRWdTWkxVQ3NnU2RHckJ4Ql9CRk9lbmRn&date_format=U&fields=[%22email%22,%22expiry_time%22,%22first_name%22,%22finance_permission%22,%22developer_permission%22,%22ip_permission%22,%22partner_center_admin_permission%22,%22partner_center_analyst_permission%22,%22partner_center_education_permission%22,%22partner_center_marketing_permission%22,%22partner_center_operations_permission%22,%22last_name%22,%22manage_page_in_www%22,%22marked_for_removal%22,%22pending_email%22,%22role%22,%22two_fac_status%22,%22is_two_fac_blocked%22,%22was_integrity_demoted%22,%22sso_migration_status%22,%22business_role_request.fields(creation_source.fields(name),created_by.fields(name),created_time,updated_time)%22,%22transparency_info_seen_by%22,%22work_profile_pic%22,%22is_pending_integrity_review%22,%22is_ineligible_developer%22,%22last_active_time%22,%22permitted_business_account_task_ids%22,%22sensitive_action_reviews%22,%22name%22]&limit=500&locale=vi_VN&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref=f2da96be0e856d4"
			});
			T0 val2 = fetch_url<T3, T0, T2>(val);
			UserInBM userInBM = JsonConvert.DeserializeObject<UserInBM>((string)val2);
			T1 val3 = (T1)(userInBM != null && userInBM.paging != null && !string.IsNullOrWhiteSpace(userInBM.paging.next));
			if (val3 != null)
			{
				T0 next = (T0)userInBM.paging.next;
				while (true)
				{
					T0 val4 = fetch_url_business<T3, T0, T2>(next);
					UserInBM userInBM2 = JsonConvert.DeserializeObject<UserInBM>((string)val4);
					T1 val5 = (T1)(userInBM2 != null && userInBM2.data != null);
					if (val5 != null)
					{
						userInBM.data.AddRange(userInBM2.data);
					}
					T1 val6 = (T1)(userInBM2 != null && userInBM2.paging != null && !string.IsNullOrWhiteSpace(userInBM2.paging.next));
					if (val6 == null)
					{
						break;
					}
					next = (T0)userInBM2.paging.next;
				}
			}
			return userInBM;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe UserInBM getListPartnerInBM<T0, T1, T2, T3, T4, T5>(T0 BM_Id)
	{
		//IL_0066: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		try
		{
			T0 val = (T0)"";
			val = (T0)("https://graph.facebook.com/v14.0/" + (string)BM_Id + "/partner_relationships?fields=partner_relationships.limit(200)%7Bid%7D&sort=name_ascending&access_token=" + frmMain.listFBEntity[indexEntity].TokenEAAG);
			T0 val2 = fetch_url<T5, T0, T4>(val);
			UserInBM userInBM = JsonConvert.DeserializeObject<UserInBM>((string)val2);
			T1 val3 = (T1)(userInBM != null && userInBM.paging != null && !string.IsNullOrWhiteSpace(userInBM.paging.next));
			if (val3 != null)
			{
				T0 val4 = (T0)userInBM.paging.next;
				while (true)
				{
					T0 val5 = fetch_url_business<T5, T0, T4>(val4);
					UserInBM userInBM2 = JsonConvert.DeserializeObject<UserInBM>((string)val5);
					T1 val6 = (T1)(userInBM2 != null && userInBM2.data != null);
					if (val6 != null)
					{
						userInBM.data.AddRange(userInBM2.data);
						Console.WriteLine(System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)userInBM.data.Count).ToString());
					}
					T1 val7 = (T1)(userInBM2 != null && userInBM2.paging != null && !string.IsNullOrWhiteSpace(userInBM2.paging.next));
					if (val7 == null)
					{
						break;
					}
					val4 = (T0)userInBM2.paging.next;
					T1 val8 = (T1)((string)val4).Contains("&limit=25");
					if (val8 != null)
					{
						val4 = (T0)((string)val4).Replace("&limit=25", "&limit=200");
					}
				}
			}
			T3 enumerator = (T3)userInBM.data.GetEnumerator();
			try
			{
				while (((List<UserInBM_Data>.Enumerator*)(&enumerator))->MoveNext())
				{
					UserInBM_Data current = ((List<UserInBM_Data>.Enumerator*)(&enumerator))->Current;
					Console.WriteLine(current.id);
				}
			}
			finally
			{
				((IDisposable)(*(List<UserInBM_Data>.Enumerator*)(&enumerator))).Dispose();
			}
			return userInBM;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 chi_dinh_user_nhom_tai_san_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T1 groupId, T1 strBMID, T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		//IL_0119: Expected O, but got I4
		//IL_0123: Expected I4, but got O
		//IL_0139: Expected O, but got I4
		//IL_0145: Expected I4, but got O
		//IL_0164: Expected I4, but got O
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUserId", current.str1);
					((Dictionary<string, string>)val4).Add("strGroupId", (string)groupId);
					((Dictionary<string, string>)val4).Add("strBMID", (string)strBMID);
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("chi_dinh_user_nhom_tai_san_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 add_ads_to_group_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T1 groupId, T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0125: Expected I4, but got O
		//IL_013b: Expected O, but got I4
		//IL_0147: Expected I4, but got O
		//IL_0166: Expected I4, but got O
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("strGroupId", (string)groupId);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("add_ads_to_group_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 xoa_tkqc_trong_nhom_tai_san<T0, T1, T2, T3, T4, T5, T6, T7>(T1 groupId, T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0125: Expected I4, but got O
		//IL_013b: Expected O, but got I4
		//IL_0147: Expected I4, but got O
		//IL_0166: Expected I4, but got O
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strActId", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("strGroupId", (string)groupId);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("xoa_tkqc_trong_nhom_tai_san", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 remove_act_in_bm<T0, T1, T2>(T1 bmId, T1 actId)
	{
		//IL_004d: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strBMId", (string)bmId);
			((Dictionary<string, string>)val).Add("strActId", (string)actId);
			T1 resouce = (T1)ResouceControl.getResouce("remove_act_in_bm", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val3 = (T2)((string)val2).Contains("success");
			if (val3 != null)
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
	public unsafe T0 remove_act_in_bm_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T1 bmId, T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_00fd: Expected I4, but got O
		//IL_0113: Expected O, but got I4
		//IL_011f: Expected I4, but got O
		//IL_013e: Expected I4, but got O
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0165: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0171: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strBMId", (string)bmId);
					((Dictionary<string, string>)val4).Add("strActId", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("remove_act_in_bm_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void createAdsInBM(string[] listString)
	{
		string text = $"{frmMain.listFBEntity[indexEntity].Name}{rnd.Next(111, 999)}";
		text = ((listString == null || listString.Count() == 0) ? (text + "@" + getLastName<bool, string, int>() + ".com") : (text + listString[rnd.Next(0, listString.Count() - 1)]));
		text = text.ToLower().Replace(" ", "");
		foreach (BMData datum in frmMain.listFBEntity[indexEntity].fullAdsInfo.businesses.data)
		{
			while (frmMain.isRunning)
			{
				try
				{
					Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
					dictionary.Add("strBMID", datum.id);
					dictionary.Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					dictionary.Add("strCurrency", "USD");
					dictionary.Add("strTimeZone", "1");
					dictionary.Add("strLocale", "en-US");
					dictionary.Add("strEmail", "%5B%5D");
					string s = $"{frmMain.listFBEntity[indexEntity].Name} - {rnd.Next(111, 999)}";
					s = HttpUtility.HtmlEncode(s);
					dictionary.Add("strName", s);
					string resouce = ResouceControl.getResouce("Tao_TK_Trong_BM", dictionary);
					string text2 = executeScript<string, IJavaScriptExecutor, int, bool, object>(resouce);
					if (text2.Contains("error"))
					{
						break;
					}
				}
				catch
				{
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Tạo_BM<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00ce: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_02a2: Expected O, but got I4
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02cb: Expected O, but got I4
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected I4, but got Unknown
		//IL_02e5: Expected I4, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_031e: Expected O, but got I4
		//IL_0343: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_BM_cần_tạo").ToString());
			T2[] array = null;
			try
			{
				array = (T2[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Domain_mail");
			}
			catch (Exception)
			{
			}
			T0 val3 = (T0)(array == null);
			if (val3 != null)
			{
				array = JsonConvert.DeserializeObject<T2[]>(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Domain_mail").ToString());
			}
			T3 val4 = (T3)Activator.CreateInstance(typeof(T3));
			T2[] array2 = array;
			T1 val5 = (T1)0;
			while ((nint)val5 < array2.Length)
			{
				T2 val6 = (T2)((object[])(object)array2)[(object)val5];
				T0 val7 = (T0)(!string.IsNullOrWhiteSpace((string)val6));
				if (val7 != null)
				{
					((List<string>)val4).Add(((string)val6).Trim());
				}
				val5 = (T1)(val5 + 1);
			}
			T0 val8 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Random_domain_mail").ToString());
			T1 val9 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val10 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T2 resouce = (T2)ResouceControl.getResouce("Tao_BM");
			T1 val11 = (T1)0;
			T0 val12 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business"));
			if (val12 != null)
			{
				goUrl<T1, T0, ReadOnlyCollection<IWebElement>, IWebElement, T5, T2>((T2)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			bat_che_do_chuyen_nghiep<Dictionary<string, string>, T2, T0>();
			T1 val13 = (T1)0;
			while (true)
			{
				T0 val14 = (T0)(val13 < val2);
				if (val14 == null)
				{
					break;
				}
				try
				{
					T2 val15 = (T2)$"{StringCipher.getPageName<Random, T0, T2, StreamReader>()} {System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)rnd.Next(111, 999)).ToString()}";
					T2 firstName = getFirstName<T0, T2, T1>();
					T2 lastName = getLastName<T0, T2, T1>();
					T2 val16 = (T2)"";
					T0 val17 = val8;
					if (val17 != null)
					{
						val16 = (T2)string.Concat((string[])(object)new T2[5]
						{
							(T2)((string)val15).Replace(" ", ""),
							(T2)"@",
							(T2)((string)firstName).Replace(" ", ""),
							(T2)((string)lastName).Replace(" ", ""),
							(T2)".com"
						}).ToLower().Replace(" ", "");
					}
					else
					{
						T2 val18 = (T2)((List<string>)val4)[rnd.Next(0, ((List<string>)val4).Count - 1)];
						val16 = (T2)(((string)val15).Replace(" ", "") + "@" + (string)val18);
					}
					T2 script = (T2)((string)resouce).Replace("strBrandName", (string)val15).Replace("strFirstName", (string)firstName).Replace("strLastName", (string)lastName)
						.Replace("strEmail", (string)val16);
					T2 val19 = executeScript<T2, IJavaScriptExecutor, T1, T0, object>(script);
					T0 val20 = (T0)((string)val19).Contains("business_id=");
					if (val20 != null)
					{
						val11 = (T1)(val11 + 1);
					}
					setMessage((T2)$"Create {val11}/{val2}", (T0)0);
					Thread.Sleep(rnd.Next(val9 * 1000, val10 * 1000));
				}
				catch
				{
				}
				val13 = (T1)(val13 + 1);
			}
			T2 strError = (T2)"";
			T4 val21 = mtLoadBM<Dictionary<string, string>, T2, T0, T4, T5>(out *(string*)(&strError));
			T0 val22 = (T0)(val21 != null && ((List<BusinessManagerEntity_businesses_Data>)val21).Count > 0);
			if (val22 != null)
			{
				_ = ((List<BusinessManagerEntity_businesses_Data>)val21).Count;
			}
			setMessage((T2)$"BM {val11}", (T0)1);
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Tao_BM<T0, T1, T2, T3, T4>(T2 Số_BM_cần_tạo, out int Done)
	{
		//IL_0002: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0151: Expected O, but got I4
		T0 result = (T0)0;
		Done = 0;
		try
		{
			T1 resouce = (T1)ResouceControl.getResouce("Tao_BM");
			T2 val = (T2)0;
			while (true)
			{
				T0 val2 = (T0)(val < Số_BM_cần_tạo);
				if (val2 == null)
				{
					break;
				}
				try
				{
					fetch_url<T3, T1, T4>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
					T1 val3 = (T1)$"{StringCipher.getPageName<Random, T0, T1, StreamReader>()} {System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)rnd.Next(111, 999)).ToString()}";
					T1 firstName = getFirstName<T0, T1, T2>();
					T1 lastName = getLastName<T0, T1, T2>();
					T1 val4 = (T1)"";
					val4 = (T1)string.Concat((string[])(object)new T1[5]
					{
						(T1)((string)val3).Replace(" ", ""),
						(T1)"@",
						(T1)((string)firstName).Replace(" ", ""),
						(T1)((string)lastName).Replace(" ", ""),
						(T1)".com"
					}).ToLower().Replace(" ", "");
					T1 script = (T1)((string)resouce).Replace("strBrandName", (string)val3).Replace("strFirstName", (string)firstName).Replace("strLastName", (string)lastName)
						.Replace("strEmail", (string)val4);
					T1 val5 = executeScript<T1, IJavaScriptExecutor, T2, T0, object>(script);
					T0 val6 = (T0)((string)val5).Contains("business_id=");
					if (val6 != null)
					{
						Done++;
					}
				}
				catch
				{
				}
				val = (T2)(val + 1);
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T3 phan_quyen_payment_bm_cho_user<T0, T1, T2, T3>(T1 BM_ID)
	{
		//IL_0108: Expected O, but got I4
		//IL_0136: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strBMID", (string)BM_ID);
			((Dictionary<string, string>)val).Add("strToken", "\"" + frmMain.listFBEntity[indexEntity].TokenEAAG + "\"");
			T1 resouce = (T1)ResouceControl.getResouce("Lay_danh_sach_admin_trong_BM", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T3, object>(resouce);
			ADSPRoject.Data.business_users business_users = JsonConvert.DeserializeObject<ADSPRoject.Data.business_users>((string)val2);
			T2 enumerator = (T2)business_users.data.GetEnumerator();
			try
			{
				while (((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator))->MoveNext())
				{
					ADSPRoject.Data.business_users_data current = ((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator))->Current;
					val = (T0)Activator.CreateInstance(typeof(T0));
					((Dictionary<string, string>)val).Add("strBMID", (string)BM_ID);
					((Dictionary<string, string>)val).Add("strUserId", current.id);
					((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					resouce = (T1)ResouceControl.getResouce("phan_quyen_payment_bm_cho_user", (Dictionary<string, string>)val);
					val2 = executeScript<T1, IJavaScriptExecutor, int, T3, object>(resouce);
					T3 val3 = (T3)((string)val2).Contains("successes");
					if (val3 != null)
					{
						Console.WriteLine("Done");
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator))).Dispose();
			}
			return (T3)1;
		}
		catch
		{
		}
		return (T3)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 addCardToBM<T0, T1, T2, T3, T4>(out string strError, T1 BM_ID, T1 strPaymentAccountId, T1 strCountryCode, T1 strCurrency, T1 strNameCart, T1 strCC, T1 strCVV, T1 strMonth, T1 strYear)
	{
		//IL_034d: Expected O, but got I4
		//IL_044c: Expected O, but got I4
		//IL_0453: Expected O, but got I4
		//IL_048e: Expected O, but got I4
		strError = "";
		try
		{
			phan_quyen_payment_bm_cho_user<T0, T1, T4, T2>(BM_ID);
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			T1 resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_0", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_1", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_2", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_3", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_4", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_5", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strCurrency", (string)strCurrency);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm_Step_6", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val3 = (T2)(((string)strYear).Length == 2);
			if (val3 != null)
			{
				strYear = (T1)("20" + (string)strYear);
			}
			val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strPaymentAccountId", (string)strPaymentAccountId);
			((Dictionary<string, string>)val).Add("strCountryCode", (string)strCountryCode);
			((Dictionary<string, string>)val).Add("strNameCart", (string)strNameCart);
			((Dictionary<string, string>)val).Add("strCC6", ((string)strCC).Substring(0, 6));
			((Dictionary<string, string>)val).Add("strCC4", ((string)strCC).Substring(((string)strCC).Length - 4, 4));
			((Dictionary<string, string>)val).Add("strCC", (string)strCC);
			((Dictionary<string, string>)val).Add("strCVV", (string)strCVV);
			((Dictionary<string, string>)val).Add("strMonth", (string)strMonth);
			((Dictionary<string, string>)val).Add("strYear", (string)strYear);
			resouce = (T1)ResouceControl.getResouce("add_the_vao_bm", (Dictionary<string, string>)val);
			val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val4 = (T2)((string)val2).Contains("description_raw");
			if (val4 == null)
			{
				return (T2)1;
			}
			strError = Regex.Match((string)val2, "description_raw\":\"(.*?)\"").Groups[1].Value;
			strError = Regex.Unescape(strError);
		}
		catch (Exception ex)
		{
			strError = ex.Message;
		}
		return (T2)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T3 mtLoadBM<T0, T1, T2, T3, T4>(out string strError)
	{
		//IL_0078: Expected O, but got I4
		strError = "";
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			T1 resouce = (T1)ResouceControl.getResouce("lay_danh_sach_bm_2", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			BusinessManagerEntity businessManagerEntity = JsonConvert.DeserializeObject<BusinessManagerEntity>((string)val2);
			T2 val3 = (T2)(businessManagerEntity != null && businessManagerEntity.businesses != null && businessManagerEntity.businesses.data != null);
			if (val3 != null)
			{
				return (T3)businessManagerEntity.businesses.data;
			}
		}
		catch (Exception ex)
		{
			strError = ex.Message;
		}
		return (T3)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 getAddraftCamp_3<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 listAct)
	{
		//IL_00cc: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_0156: Expected I4, but got O
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		try
		{
			T1 val2 = (T1)"";
			T1 val3 = (T1)"";
			T4 enumerator = (T4)((List<string>)listAct).GetEnumerator();
			try
			{
				while (((List<string>.Enumerator*)(&enumerator))->MoveNext())
				{
					T1 current = (T1)((List<string>.Enumerator*)(&enumerator))->Current;
					T1 val4 = (T1)("fetch_" + (string)current);
					T5 val5 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val5).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val5).Add("strAtc", ((string)current).Replace("act_", ""));
					((Dictionary<string, string>)val5).Add("result", (string)val4);
					T1 resouce = (T1)ResouceControl.getResouce("addraft_fragments_3", (Dictionary<string, string>)val5);
					val2 = (T1)((string)val2 + (string)resouce);
					T6 val6 = (T6)(!string.IsNullOrWhiteSpace((string)val3));
					if (val6 != null)
					{
						val3 = (T1)((string)val3 + ",");
					}
					val3 = (T1)((string)val3 + (string)val4);
				}
			}
			finally
			{
				((IDisposable)(*(List<string>.Enumerator*)(&enumerator))).Dispose();
			}
			T1 val7 = val2;
			val7 = (T1)((string)val7 + "var testPromise=await Promise.all([" + (string)val3 + "]).then((values) => { return values; }); return testPromise;");
			T2 val8 = (T2)chrome;
			T3 val9 = (T3)(ICollection<object>)((IJavaScriptExecutor)val8).ExecuteScript((string)val7, (object[])(object)Array.Empty<T10>());
			T6 val10 = (T6)(val9 != null);
			if (val10 != null)
			{
				T7 val11 = (T7)((IEnumerable<T10>)val9).ToList();
				T8 val12 = (T8)0;
				while (true)
				{
					T6 val13 = (T6)((nint)val12 < ((List<string>)listAct).Count);
					if (val13 != null)
					{
						addraft_fragments_2 item = JsonConvert.DeserializeObject<addraft_fragments_2>(((List<object>)val11)[(int)val12].ToString());
						((List<addraft_fragments_2>)val).Add(item);
						val12 = (T8)(val12 + 1);
						continue;
					}
					break;
				}
			}
		}
		catch
		{
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 ImportCamp_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_0117: Expected I4, but got O
		//IL_012d: Expected O, but got I4
		//IL_0139: Expected I4, but got O
		//IL_0158: Expected I4, but got O
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_017f: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("straccount_id", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strdraft_id", current.str2);
					((Dictionary<string, string>)val4).Add("strtsv", current.str3);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("ImportTextCamp_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("async_session_id");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 CampBoostpost_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 listData, T1 strVariables)
	{
		//IL_0002: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		//IL_0192: Expected I4, but got O
		//IL_01a8: Expected O, but got I4
		//IL_01b4: Expected I4, but got O
		//IL_01d3: Expected I4, but got O
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_01fa: Expected O, but got I4
		//IL_0200: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 value = (T1)Regex.Match(((string)strVariables).ToLower(), "legacy_ad_account_id%22%3a%22(.*?)%22").Groups[1].Value;
			T1 value2 = (T1)Regex.Match(((string)strVariables).ToLower(), "flow_id%22%3a%22(.*?)%22").Groups[1].Value;
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("LWICometValidationNoticesProviderQuery", "LWICometCreateBoostedComponentMutation");
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strVariables", ((string)strVariables).Replace((string)value, ((string)str).Replace("act_", "")).Replace((string)value2, ((T5)Guid.NewGuid()).ToString()));
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("CampBoostpost_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T7, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T6 val7 = (T6)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("is_final\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T6)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 postContentPage<T0, T1, T2, T3, T4, T5, T6>(T1 pageId, T1 content, T1 folderImage)
	{
		//IL_0039: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0114: Expected O, but got I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		T0 result = (T0)Activator.CreateInstance(typeof(T0));
		T1 url = (T1)((RemoteWebDriver)chrome).Url;
		goUrl<T5, T3, T2, T6, T4, T1>((T1)("https://business.facebook.com/latest/composer/?asset_id=" + (string)pageId + "&ref=biz_web_home&context_ref=HOME"));
		T2 val;
		while (true)
		{
			val = (T2)((RemoteWebDriver)chrome).FindElements(By.ClassName("notranslate"));
			T3 val2 = (T3)(val == null || ((ReadOnlyCollection<IWebElement>)val).Count <= 0);
			if (val2 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		try
		{
			((IWebElement)((IEnumerable<T6>)val).First()).SendKeys((string)content);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@type='file']"));
		T2 source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("input"));
		try
		{
			T1[] files = (T1[])(object)Directory.GetFiles((string)folderImage);
			T5 val3 = (T5)0;
			while ((nint)val3 < files.Length)
			{
				T1 val4 = (T1)((object[])(object)files)[(object)val3];
				((IWebElement)((IEnumerable<T6>)source).First()).SendKeys((string)val4);
				val3 = (T5)(val3 + 1);
			}
			T2 source2 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@area-label]"));
			T1[] files2 = (T1[])(object)Directory.GetFiles((string)folderImage);
			T5 val5 = (T5)0;
			while ((nint)val5 < files2.Length)
			{
				T1 val6 = (T1)((object[])(object)files2)[(object)val5];
				((IWebElement)((IEnumerable<T6>)source2).First()).SendKeys((string)val6);
				val5 = (T5)(val5 + 1);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
		goUrl<T5, T3, T2, T6, T4, T1>(url);
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 Lên_camp_boostpost_30e<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(FBFlow flow)
	{
		//IL_0002: Expected O, but got I4
		//IL_000b: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0064: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0142: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_0204: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_025d: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		//IL_02cf: Expected O, but got I4
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected I4, but got Unknown
		//IL_04e3: Expected O, but got I4
		//IL_04f2: Expected O, but got I4
		//IL_04f8: Expected O, but got I4
		T0 result = (T0)0;
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return result;
		}
		try
		{
			setMessage((T1)"Camp boostpost", (T0)0);
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tên_page").ToString();
			bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Xóa_thẻ").ToString());
			T2 val3 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Độ_trễ").ToString());
			T1[] array = null;
			try
			{
				array = (T1[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Target");
			}
			catch (Exception)
			{
			}
			T0 val4 = (T0)(array == null);
			if (val4 != null)
			{
				array = JsonConvert.DeserializeObject<T1[]>(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Target").ToString());
			}
			T1 val5 = array.First();
			T1 value = (T1)Regex.Match(((string)val5).ToLower(), "legacy_ad_account_id\":\"(.*?)\"").Groups[1].Value;
			T1 value2 = (T1)Regex.Match(((string)val5).ToLower(), "flow_id\":\"(.*?)\"").Groups[1].Value;
			T1 value3 = (T1)Regex.Match(((string)val5).ToLower(), "page_id\":\"(.*?)\"").Groups[1].Value;
			T1 val6 = (T1)"";
			T1 strError = (T1)"";
			T3 val7 = mtLoadPage<T3, T1, T0, T11, T9>(out *(string*)(&strError));
			T0 val8 = (T0)(val7 != null && ((List<facebook_pagesData>)val7).Count > 0);
			if (val8 != null)
			{
				T4 enumerator = (T4)((List<facebook_pagesData>)val7).GetEnumerator();
				try
				{
					while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
					{
						facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
						T0 val9 = (T0)(string.IsNullOrWhiteSpace((string)val2) || current.name.ToLower().Equals(((string)val2).ToLower()));
						if (val9 != null)
						{
							val6 = (T1)current.id;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val10 = (T0)string.IsNullOrWhiteSpace((string)val6);
			if (val10 == null)
			{
				postContentPage<T5, T1, T12, T0, T11, T2, T13>(val6, (T1)"hello\n\r22222", (T1)"C:\\Users\\Ximate\\Downloads\\New folder");
				T1 strError2 = (T1)"";
				T6 val11 = mtLoadBM<T9, T1, T0, T6, T11>(out *(string*)(&strError2));
				T0 val12 = (T0)(val11 == null || ((List<BusinessManagerEntity_businesses_Data>)val11).Count <= 0);
				if (val12 != null)
				{
					setMessage((T1)"e:Không có BM", (T0)1);
				}
				else
				{
					T7 enumerator2 = (T7)((List<BusinessManagerEntity_businesses_Data>)val11).GetEnumerator();
					try
					{
						while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							BusinessManagerEntity_businesses_Data current2 = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))->Current;
							T1 id = (T1)current2.id;
							adaccounts fullAdsInfo_In_BM = getFullAdsInfo_In_BM<T1, T9, T0, T2, T12, IEnumerator, Match, char, IDisposable, T11, T13, List<adaccountsData>>(id, (T0)1, (T2)0, (T2)0, (T1)"");
							T0 val13 = (T0)(fullAdsInfo_In_BM != null && fullAdsInfo_In_BM.data != null && fullAdsInfo_In_BM.data.Count > 0);
							if (val13 == null)
							{
								continue;
							}
							T8 enumerator3 = (T8)fullAdsInfo_In_BM.data.GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator3))->MoveNext())
								{
									adaccountsData current3 = ((List<adaccountsData>.Enumerator*)(&enumerator3))->Current;
									T1 val14 = (T1)current3.id.Replace("act_", "");
									T0 val15 = (T0)(current3.account_status == 1 || current3.account_status == 7 || current3.account_status == 9);
									if (val15 == null)
									{
										setMessage((T1)"HCQC", (T0)1);
										continue;
									}
									T1 str = (T1)((string)val5).Replace((string)value3, (string)val6).Replace((string)value2, ((T10)Guid.NewGuid()).ToString()).Replace((string)value, (string)val14)
										.Replace("strUID", frmMain.listFBEntity[indexEntity].UID)
										.Replace("strPageId", (string)val6);
									str = (T1)HttpUtility.UrlEncode((string)str);
									T9 val16 = (T9)Activator.CreateInstance(typeof(T9));
									((Dictionary<string, string>)val16).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
									((Dictionary<string, string>)val16).Add("strAct", (string)val14);
									((Dictionary<string, string>)val16).Add("strPageId", (string)val6);
									T1 resouce = (T1)ResouceControl.getResouce("CampBoostpost_0", (Dictionary<string, string>)val16);
									executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce);
									val16 = (T9)Activator.CreateInstance(typeof(T9));
									((Dictionary<string, string>)val16).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
									((Dictionary<string, string>)val16).Add("strVariables", (string)str);
									((Dictionary<string, string>)val16).Add("strPageId", (string)val6);
									resouce = (T1)ResouceControl.getResouce("CampBoostpost_1", (Dictionary<string, string>)val16);
									executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce);
									val16 = (T9)Activator.CreateInstance(typeof(T9));
									((Dictionary<string, string>)val16).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
									((Dictionary<string, string>)val16).Add("strVariables", (string)str);
									((Dictionary<string, string>)val16).Add("strPageId", (string)val6);
									resouce = (T1)ResouceControl.getResouce("CampBoostpost", (Dictionary<string, string>)val16);
									executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce);
									Thread.Sleep(val3 * 1000);
									removePaymentMethod<T0, T9, T1, T14, T2>(val14, (T1)"");
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator3))).Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))).Dispose();
					}
					result = (T0)1;
				}
			}
			else
			{
				setMessage((T1)"e:Không có page", (T0)1);
			}
		}
		catch (Exception ex2)
		{
			result = (T0)0;
			Console.WriteLine(ex2.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 CampSuite_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T8 listData, T1 strVariables)
	{
		//IL_0002: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_017f: Expected I4, but got O
		//IL_0195: Expected O, but got I4
		//IL_01a1: Expected I4, but got O
		//IL_01c0: Expected I4, but got O
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01e7: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 value = (T1)Regex.Match(((string)strVariables).ToLower(), "legacy_ad_account_id%22%3a%22(.*?)%22").Groups[1].Value;
			T1 value2 = (T1)Regex.Match(((string)strVariables).ToLower(), "flow_id%22%3a%22(.*?)%22").Groups[1].Value;
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strVariables", ((string)strVariables).Replace((string)value, ((string)str).Replace("act_", "")).Replace((string)value2, ((T5)Guid.NewGuid()).ToString()));
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("CampSuite_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T7, char, object>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T6 val7 = (T6)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("is_final\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str4 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T6)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 clearAddrafts<T0, T1, T2>(T2 addraft)
	{
		//IL_0022: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
				((Dictionary<string, string>)val2).Add("strAddraft", (string)addraft);
				T2 resouce = (T2)ResouceControl.getResouce("discard_fragments", (Dictionary<string, string>)val2);
				executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
				return (T0)1;
			}
			frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
		}
		catch
		{
		}
		return (T0)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 clearAddrafts_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0128: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)"";
			T1 val3 = (T1)"";
			T2 enumerator = (T2)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1[] array = (T1[])(object)current.str2.Split((char[])(object)new T8[1] { (T8)124 });
					T1[] array2 = array;
					T3 val4 = (T3)0;
					while ((nint)val4 < array2.Length)
					{
						T1 val5 = (T1)((object[])(object)array2)[(object)val4];
						T0 val6 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
						if (val6 != null)
						{
							T1 val7 = (T1)("fetch_" + (string)val5);
							T4 val8 = (T4)Activator.CreateInstance(typeof(T4));
							((Dictionary<string, string>)val8).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val8).Add("strAddraft", (string)val5);
							((Dictionary<string, string>)val8).Add("result", (string)val7);
							T1 resouce = (T1)ResouceControl.getResouce("discard_fragments_Promise", (Dictionary<string, string>)val8);
							val2 = (T1)((string)val2 + (string)resouce);
							val3 = (T1)((string)val3 + (string)val7 + ",");
						}
						val4 = (T3)(val4 + 1);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T0 val9 = (T0)(!string.IsNullOrWhiteSpace((string)val2));
			if (val9 != null)
			{
				executeScript_Promise<T5, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, T8, object>(val2, val3);
			}
			val = (T0)1;
		}
		catch (Exception ex)
		{
			val = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 updateTargetCampain<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T1 strAct, T1 strNewTarget_ChienDich, T1 strNewTarget_NhomQuangCao, T1 strNewTarget_QuangCao, T1 CampFilter)
	{
		//IL_0002: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00a3: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01d3: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_024e: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_02a0: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_02cb: Expected O, but got I4
		//IL_034a: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			strNewTarget_ChienDich = (T1)HttpUtility.UrlEncode((string)strNewTarget_ChienDich);
			strNewTarget_NhomQuangCao = (T1)HttpUtility.UrlEncode((string)strNewTarget_NhomQuangCao);
			strNewTarget_QuangCao = (T1)HttpUtility.UrlEncode((string)strNewTarget_QuangCao);
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)"";
				T2 val3 = (T2)0;
				while (true)
				{
					addraft_fragments_2 addraftCamp_ = getAddraftCamp_2<T0, T2, T8, T1, IJavaScriptExecutor, object>(strAct);
					T0 val4 = (T0)(addraftCamp_ != null && addraftCamp_.data != null);
					if (val4 != null)
					{
						T3 enumerator = (T3)addraftCamp_.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
							{
								addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
								val2 = (T1)current.id;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
						}
					}
					val3 = (T2)(val3 + 1);
					T0 val5 = (T0)(string.IsNullOrWhiteSpace((string)val2) && (nint)val3 < 5);
					if (val5 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T1 url = (T1)string.Concat((string[])(object)new T1[5]
				{
					(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
					(T1)"act_",
					(T1)((string)strAct).Replace("act_", ""),
					(T1)"?fields=campaigns%7Bid%2Cname%2Cadsets%7Bid%2Cname%2Cads%7Bid%2Cname%7D%7D%7D&access_token=",
					(T1)frmMain.listFBEntity[indexEntity].TokenEAAB
				});
				T1 val6 = fetch_url_business<T8, T1, T7>(url);
				Ads ads = JsonConvert.DeserializeObject<Ads>((string)val6);
				T0 val7 = (T0)(ads != null && ads.campaigns != null && ads.campaigns.data != null);
				if (val7 != null)
				{
					T4 enumerator2 = (T4)ads.campaigns.data.GetEnumerator();
					try
					{
						while (((List<campaigns_data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							campaigns_data current2 = ((List<campaigns_data>.Enumerator*)(&enumerator2))->Current;
							T0 val8 = (T0)current2.name.ToLower().Contains(((string)CampFilter).ToLower());
							if (val8 == null)
							{
								continue;
							}
							T0 val9 = (T0)(!string.IsNullOrWhiteSpace((string)strNewTarget_ChienDich));
							if (val9 != null)
							{
								T0 val10 = sua_target_chien_dich<T0, T8, T1>(val2, strAct, (T1)current2.id, strNewTarget_ChienDich);
								T0 val11 = (T0)(val10 == null);
								if (val11 != null)
								{
									result = (T0)0;
								}
							}
							T0 val12 = (T0)(current2.adsets != null && current2.adsets.data != null);
							if (val12 == null)
							{
								continue;
							}
							T5 enumerator3 = (T5)current2.adsets.data.GetEnumerator();
							try
							{
								while (((List<ADSPRoject.Data.Campains.adsets_data>.Enumerator*)(&enumerator3))->MoveNext())
								{
									ADSPRoject.Data.Campains.adsets_data current3 = ((List<ADSPRoject.Data.Campains.adsets_data>.Enumerator*)(&enumerator3))->Current;
									T0 val13 = (T0)(!string.IsNullOrWhiteSpace((string)strNewTarget_NhomQuangCao));
									if (val13 != null)
									{
										T0 val14 = sua_target_nhom_quang_cao<T0, T8, T1>(val2, strAct, (T1)current3.id, (T1)current2.id, strNewTarget_NhomQuangCao);
										T0 val15 = (T0)(val14 == null);
										if (val15 != null)
										{
											result = (T0)0;
										}
									}
									T0 val16 = (T0)(current3.ads != null && current3.ads.data != null);
									if (val16 == null)
									{
										continue;
									}
									T6 enumerator4 = (T6)current3.ads.data.GetEnumerator();
									try
									{
										while (((List<ADSPRoject.Data.Campains.ads_data>.Enumerator*)(&enumerator4))->MoveNext())
										{
											ADSPRoject.Data.Campains.ads_data current4 = ((List<ADSPRoject.Data.Campains.ads_data>.Enumerator*)(&enumerator4))->Current;
											T0 val17 = (T0)(!string.IsNullOrWhiteSpace((string)strNewTarget_QuangCao));
											if (val17 != null)
											{
												T0 val18 = sua_target_quang_cao<T0, T8, T1>(val2, strAct, (T1)current4.id, (T1)current3.id, strNewTarget_QuangCao);
												T0 val19 = (T0)(val18 == null);
												if (val19 != null)
												{
													result = (T0)0;
												}
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ADSPRoject.Data.Campains.ads_data>.Enumerator*)(&enumerator4))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<ADSPRoject.Data.Campains.adsets_data>.Enumerator*)(&enumerator3))).Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<campaigns_data>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
			}
			else
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 sua_target_chien_dich<T0, T1, T2>(T2 addraft_id, T2 strAct, T2 strCampId, T2 strNewTarget)
	{
		//IL_0002: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strDraft", (string)addraft_id);
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strCampId", (string)strCampId);
			((Dictionary<string, string>)val).Add("strNewTarget", (string)strNewTarget);
			T2 resouce = (T2)ResouceControl.getResouce("sua_target_chien_dich", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("EDITING");
			if (val3 != null)
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
	public T0 sua_target_nhom_quang_cao<T0, T1, T2>(T2 addraft_id, T2 strAct, T2 strAdset_id, T2 strCamp_Id, T2 strNewTarget)
	{
		//IL_0002: Expected O, but got I4
		//IL_00af: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strDraftId", (string)addraft_id);
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strAdset_id", (string)strAdset_id);
			((Dictionary<string, string>)val).Add("strCamp_Id", (string)strCamp_Id);
			((Dictionary<string, string>)val).Add("strNewTarget", (string)strNewTarget);
			T2 resouce = (T2)ResouceControl.getResouce("sua_target_nhom_quang_cao", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("EDITING");
			if (val3 != null)
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
	public T0 sua_target_quang_cao<T0, T1, T2>(T2 addraft_id, T2 strAct, T2 strAd_Id, T2 strAdset_Id, T2 strNewTarget)
	{
		//IL_0002: Expected O, but got I4
		//IL_00af: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strDraftId", (string)addraft_id);
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
			((Dictionary<string, string>)val).Add("strAct", ((string)strAct).Replace("act_", ""));
			((Dictionary<string, string>)val).Add("strAd_Id", (string)strAd_Id);
			((Dictionary<string, string>)val).Add("strAdset_Id", (string)strAdset_Id);
			((Dictionary<string, string>)val).Add("strNewTarget", (string)strNewTarget);
			T2 resouce = (T2)ResouceControl.getResouce("sua_target_quang_cao", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).Contains("EDITING");
			if (val3 != null)
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
	public unsafe T0 CreateCampPE_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 listData, T1 strVariables)
	{
		//IL_0002: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_0278: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		//IL_0290: Expected I4, but got O
		//IL_029f: Expected I4, but got O
		//IL_02ae: Expected O, but got I4
		//IL_02ba: Expected I4, but got O
		//IL_02df: Expected O, but got I4
		//IL_02eb: Expected I4, but got O
		//IL_030b: Expected I4, but got O
		//IL_0329: Expected I4, but got O
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_035d: Expected O, but got I4
		//IL_04ba: Expected O, but got I4
		//IL_04c4: Expected O, but got I4
		//IL_04d2: Expected I4, but got O
		//IL_04e1: Expected I4, but got O
		//IL_04f0: Expected O, but got I4
		//IL_04fc: Expected I4, but got O
		//IL_0521: Expected O, but got I4
		//IL_052d: Expected I4, but got O
		//IL_054b: Expected I4, but got O
		//IL_0577: Expected I4, but got O
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		//IL_059f: Expected O, but got I4
		//IL_071e: Expected O, but got I4
		//IL_0728: Expected O, but got I4
		//IL_0736: Expected I4, but got O
		//IL_0745: Expected I4, but got O
		//IL_0754: Expected O, but got I4
		//IL_0760: Expected I4, but got O
		//IL_0785: Expected O, but got I4
		//IL_0791: Expected I4, but got O
		//IL_07b1: Expected I4, but got O
		//IL_07cf: Expected I4, but got O
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Expected O, but got Unknown
		//IL_0803: Expected O, but got I4
		//IL_0810: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			strVariables = (T1)HttpUtility.UrlDecode((string)strVariables);
			T1[] array = (T1[])(object)Regex.Split((string)strVariables, "\r\n|\r|\n");
			T1 oldValue = ((IEnumerable<T1>)(object)((string)((object[])(object)array)[0]).Split((char[])(object)new T9[1] { (T9)58 })).Last();
			T1 oldValue2 = ((IEnumerable<T1>)(object)((string)((object[])(object)array)[1]).Split((char[])(object)new T9[1] { (T9)58 })).Last();
			T1 oldValue3 = ((IEnumerable<T1>)(object)((string)((object[])(object)array)[2]).Split((char[])(object)new T9[1] { (T9)58 })).Last();
			T1 val = (T1)HttpUtility.UrlEncode((string)((object[])(object)array)[3]);
			T1 val2 = (T1)HttpUtility.UrlEncode((string)((object[])(object)array)[4]);
			T1 val3 = (T1)HttpUtility.UrlEncode((string)((object[])(object)array)[5]);
			T1 val4 = (T1)"";
			T1 val5 = (T1)"";
			reaload_campaigns_Promise<T0, T8, T3, T7, T1, T2, T5, T6>(listData);
			getAddraftCamp_2_Promise<T0, T1, T2, T3, T5, T6, T7, T8>(listData);
			addraft_fragments_2 addraft_fragments_ = null;
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T0 val6 = (T0)(current.obj1 != null);
					if (val6 == null)
					{
						continue;
					}
					try
					{
						addraft_fragments_ = (addraft_fragments_2)current.obj1;
						T0 val7 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
						if (val7 == null)
						{
							continue;
						}
						T4 enumerator2 = (T4)addraft_fragments_.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_2_data current2 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator2))->Current;
								current.str6 = current2.id;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
					catch
					{
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T3 enumerator3 = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator3))->MoveNext())
				{
					ListStringData current3 = ((List<ListStringData>.Enumerator*)(&enumerator3))->Current;
					T1 val8 = (T1)current3.str1.Replace("act_", "");
					T1 val9 = (T1)("fetch_" + (string)val8);
					T5 val10 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val10).Add("strDraft_Id", current3.str6);
					((Dictionary<string, string>)val10).Add("strToken_EEAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val10).Add("strAct_Id", (string)val8);
					((Dictionary<string, string>)val10).Add("strValues", ((string)val).Replace((string)oldValue, (string)val8));
					((Dictionary<string, string>)val10).Add("result", (string)val9);
					T1 resouce = (T1)ResouceControl.getResouce("Tao_Camp_Chien_Dich_PE_Promise", (Dictionary<string, string>)val10);
					val4 = (T1)((string)val4 + (string)resouce);
					val5 = (T1)((string)val5 + (string)val9 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator3))).Dispose();
			}
			T2 val11 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T7, T9, object>(val4, val5);
			T0 val12 = (T0)(val11 != null && ((List<object>)val11).Count > 0);
			if (val12 != null)
			{
				T6 val13 = (T6)0;
				while (true)
				{
					T0 val14 = (T0)((nint)val13 < ((List<ListStringData>)listData).Count);
					if (val14 == null)
					{
						break;
					}
					T1 val15 = (T1)((List<object>)val11)[(int)val13].ToString();
					T0 val16 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val13].str4));
					if (val16 != null)
					{
						((List<ListStringData>)listData)[(int)val13].str4 += "-";
					}
					T0 val17 = (T0)((string)val15).Contains("ad_object_id");
					if (val17 == null)
					{
						((List<ListStringData>)listData)[(int)val13].str4 += "0";
					}
					else
					{
						((List<ListStringData>)listData)[(int)val13].str4 += "1";
						((List<ListStringData>)listData)[(int)val13].str2 = Regex.Match((string)val15, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
					}
					val13 = (T6)(val13 + 1);
				}
			}
			val4 = (T1)"";
			val5 = (T1)"";
			T3 enumerator4 = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator4))->MoveNext())
				{
					ListStringData current4 = ((List<ListStringData>.Enumerator*)(&enumerator4))->Current;
					T1 val18 = (T1)current4.str1.Replace("act_", "");
					T1 val19 = (T1)("fetch_" + (string)val18);
					T5 val20 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val20).Add("strDraft_Id", current4.str6);
					((Dictionary<string, string>)val20).Add("strToken_EEAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val20).Add("strAct_Id", (string)val18);
					((Dictionary<string, string>)val20).Add("strValues", ((string)val2).Replace((string)oldValue, (string)val18).Replace((string)oldValue2, current4.str2));
					((Dictionary<string, string>)val20).Add("strCampaign_id", current4.str2);
					((Dictionary<string, string>)val20).Add("result", (string)val19);
					T1 resouce2 = (T1)ResouceControl.getResouce("Tao_Camp_Nhom_QC_PE_Promise", (Dictionary<string, string>)val20);
					val4 = (T1)((string)val4 + (string)resouce2);
					val5 = (T1)((string)val5 + (string)val19 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator4))).Dispose();
			}
			val11 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T7, T9, object>(val4, val5);
			T0 val21 = (T0)(val11 != null && ((List<object>)val11).Count > 0);
			if (val21 != null)
			{
				T6 val22 = (T6)0;
				while (true)
				{
					T0 val23 = (T0)((nint)val22 < ((List<ListStringData>)listData).Count);
					if (val23 == null)
					{
						break;
					}
					T1 val24 = (T1)((List<object>)val11)[(int)val22].ToString();
					T0 val25 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val22].str4));
					if (val25 != null)
					{
						((List<ListStringData>)listData)[(int)val22].str4 += "-";
					}
					T0 val26 = (T0)((string)val24).Contains("ad_object_id");
					if (val26 != null)
					{
						((List<ListStringData>)listData)[(int)val22].str4 += "1";
						((List<ListStringData>)listData)[(int)val22].str3 = Regex.Match((string)val24, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
					}
					else
					{
						((List<ListStringData>)listData)[(int)val22].str4 += "0";
					}
					val22 = (T6)(val22 + 1);
				}
			}
			val4 = (T1)"";
			val5 = (T1)"";
			T3 enumerator5 = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator5))->MoveNext())
				{
					ListStringData current5 = ((List<ListStringData>.Enumerator*)(&enumerator5))->Current;
					T1 val27 = (T1)current5.str1.Replace("act_", "");
					T1 val28 = (T1)("fetch_" + (string)val27);
					T5 val29 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val29).Add("strDraft_Id", current5.str6);
					((Dictionary<string, string>)val29).Add("strToken_EEAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val29).Add("strAct_Id", (string)val27);
					((Dictionary<string, string>)val29).Add("strValues", ((string)val3).Replace((string)oldValue, (string)val27).Replace((string)oldValue2, current5.str2).Replace((string)oldValue3, current5.str3));
					((Dictionary<string, string>)val29).Add("strCampaign_id", current5.str2);
					((Dictionary<string, string>)val29).Add("strAdset_Id", current5.str3);
					((Dictionary<string, string>)val29).Add("result", (string)val28);
					T1 resouce3 = (T1)ResouceControl.getResouce("Tao_Camp_QC_PE_Promise", (Dictionary<string, string>)val29);
					val4 = (T1)((string)val4 + (string)resouce3);
					val5 = (T1)((string)val5 + (string)val28 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator5))).Dispose();
			}
			val11 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T7, T9, object>(val4, val5);
			T0 val30 = (T0)(val11 != null && ((List<object>)val11).Count > 0);
			if (val30 != null)
			{
				T6 val31 = (T6)0;
				while (true)
				{
					T0 val32 = (T0)((nint)val31 < ((List<ListStringData>)listData).Count);
					if (val32 != null)
					{
						T1 val33 = (T1)((List<object>)val11)[(int)val31].ToString();
						T0 val34 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val31].str4));
						if (val34 != null)
						{
							((List<ListStringData>)listData)[(int)val31].str4 += "-";
						}
						T0 val35 = (T0)((string)val33).Contains("ad_object_id");
						if (val35 == null)
						{
							((List<ListStringData>)listData)[(int)val31].str4 += "0";
						}
						else
						{
							((List<ListStringData>)listData)[(int)val31].str4 += "1";
							((List<ListStringData>)listData)[(int)val31].str5 = Regex.Match((string)val33, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
						}
						val31 = (T6)(val31 + 1);
						continue;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Set_camp_PE<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		//IL_01ec: Expected O, but got I4
		//IL_0221: Expected O, but got I4
		//IL_0234: Expected O, but got I4
		//IL_0261: Expected O, but got I4
		//IL_02a5: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02e7: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_034d: Expected O, but got I4
		//IL_0366: Expected O, but got I4
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_043e: Expected O, but got I4
		//IL_0479: Expected O, but got I4
		//IL_0483: Expected O, but got I4
		//IL_0491: Expected I4, but got O
		//IL_04a1: Expected I4, but got O
		//IL_04b0: Expected O, but got I4
		//IL_04bd: Expected I4, but got O
		//IL_04e2: Expected O, but got I4
		//IL_04ef: Expected I4, but got O
		//IL_050e: Expected I4, but got O
		//IL_053b: Expected I4, but got O
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_0564: Expected O, but got I4
		//IL_06c3: Expected O, but got I4
		//IL_06cd: Expected O, but got I4
		//IL_06db: Expected I4, but got O
		//IL_06eb: Expected I4, but got O
		//IL_06fa: Expected O, but got I4
		//IL_0707: Expected I4, but got O
		//IL_072c: Expected O, but got I4
		//IL_0739: Expected I4, but got O
		//IL_075a: Expected I4, but got O
		//IL_0779: Expected I4, but got O
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		//IL_07ae: Expected O, but got I4
		//IL_092f: Expected O, but got I4
		//IL_0939: Expected O, but got I4
		//IL_0947: Expected I4, but got O
		//IL_0957: Expected I4, but got O
		//IL_0966: Expected O, but got I4
		//IL_0973: Expected I4, but got O
		//IL_0998: Expected O, but got I4
		//IL_09a5: Expected I4, but got O
		//IL_09c4: Expected I4, but got O
		//IL_09f1: Expected I4, but got O
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0d: Expected O, but got Unknown
		//IL_0a1a: Expected O, but got I4
		//IL_0a2e: Expected O, but got I4
		//IL_0a42: Expected O, but got I4
		//IL_0a42: Expected O, but got I4
		//IL_0a42: Expected O, but got I4
		//IL_0a61: Expected O, but got I4
		//IL_0a70: Expected O, but got I4
		//IL_0a8d: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			setMessage((T1)"Camp message", (T0)0);
			T1[] array = null;
			try
			{
				array = (T1[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Campaign_PE");
			}
			catch (Exception)
			{
			}
			T0 val2 = (T0)(array == null);
			if (val2 != null)
			{
				array = JsonConvert.DeserializeObject<T1[]>(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Campaign_PE").ToString());
			}
			T0 val3 = (T0)1;
			T0 val4 = (T0)(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Check_The") != null);
			if (val4 != null)
			{
				val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Check_The").ToString());
			}
			T1 oldValue = ((IEnumerable<T1>)(object)((string)((object[])(object)array)[0]).Split((char[])(object)new T11[1] { (T11)58 })).Last();
			T1 oldValue2 = ((IEnumerable<T1>)(object)((string)((object[])(object)array)[1]).Split((char[])(object)new T11[1] { (T11)58 })).Last();
			T1 oldValue3 = ((IEnumerable<T1>)(object)((string)((object[])(object)array)[2]).Split((char[])(object)new T11[1] { (T11)58 })).Last();
			T1 val5 = (T1)HttpUtility.UrlEncode((string)((object[])(object)array)[3]);
			T1 val6 = (T1)HttpUtility.UrlEncode((string)((object[])(object)array)[4]);
			T1 val7 = (T1)HttpUtility.UrlEncode((string)((object[])(object)array)[5]);
			T1 val8 = (T1)"";
			T1 val9 = (T1)"";
			getFullAdsInfo<T8, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, T2, T11, IDisposable, T10, IWebElement>();
			T2 val10 = (T2)0;
			T3 val11 = (T3)Activator.CreateInstance(typeof(T3));
			T5 enumerator = (T5)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T1 val12 = (T1)current.id.Replace("act_", "");
					adaccountsData adaccountsData = reload_act<T1, T10, T8>(val12);
					T0 val13 = (T0)(adaccountsData.account_status == 2);
					if (val13 == null)
					{
						T0 val14 = (T0)0;
						T0 val15 = val3;
						if (val15 != null)
						{
							ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery = lay_toan_bo_payment_method<T8, T1>(val12);
							T0 val16 = (T0)(billingAMNexusRootQuery != null && billingAMNexusRootQuery.data != null && billingAMNexusRootQuery.data.billable_account_by_payment_account != null && billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
							if (val16 != null)
							{
								T6 enumerator2 = (T6)billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
								try
								{
									if (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator2))->MoveNext())
									{
										_ = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator2))->Current;
										val14 = (T0)1;
									}
								}
								finally
								{
									((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator2))).Dispose();
								}
							}
						}
						else
						{
							val14 = (T0)1;
						}
						T0 val17 = val14;
						if (val17 == null)
						{
							continue;
						}
						ListStringData listStringData = new ListStringData();
						listStringData.str1 = (string)val12;
						T1 val18 = (T1)("fetch_" + (string)val12);
						T2 val19 = (T2)0;
						while (true)
						{
							T0 val20 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business."));
							if (val20 != null)
							{
								goUrl<T2, T0, ReadOnlyCollection<IWebElement>, IWebElement, T10, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
							}
							fetch_url<T8, T1, T10>((T1)("https://business.facebook.com/adsmanager/manage/ads?act=" + (string)val12));
							Thread.Sleep(1000);
							addraft_fragments_2 addraft_fragments_ = null;
							addraft_fragments_ = getAddraftCamp_2<T0, T2, T8, T1, IJavaScriptExecutor, object>(val12);
							T0 val21 = (T0)0;
							T0 val22 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
							if (val22 != null)
							{
								T7 enumerator3 = (T7)addraft_fragments_.data.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
									{
										addraft_fragments_2_data current2 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
										listStringData.str6 = current2.id;
										val21 = (T0)1;
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
								}
							}
							T0 val23 = val21;
							if (val23 == null)
							{
								T0 val24 = (T0)((nint)val19 <= 5);
								if (val24 == null)
								{
									break;
								}
								val19 = (T2)(val19 + 1);
								goUrl<T2, T0, ReadOnlyCollection<IWebElement>, IWebElement, T10, T1>((T1)("https://business.facebook.com/adsmanager/manage/ads?act=" + (string)val12));
								continue;
							}
							setMessage((T1)"Tạo bản nháp", (T0)0);
							T8 val25 = (T8)Activator.CreateInstance(typeof(T8));
							((Dictionary<string, string>)val25).Add("strDraft_Id", listStringData.str6);
							((Dictionary<string, string>)val25).Add("strToken_EEAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val25).Add("strAct_Id", (string)val12);
							((Dictionary<string, string>)val25).Add("strValues", ((string)val5).Replace((string)oldValue, (string)val12));
							((Dictionary<string, string>)val25).Add("result", (string)val18);
							T1 resouce = (T1)ResouceControl.getResouce("Tao_Camp_Chien_Dich_PE_Promise", (Dictionary<string, string>)val25);
							val8 = (T1)((string)val8 + (string)resouce);
							val9 = (T1)((string)val9 + (string)val18 + ",");
							((List<ListStringData>)val11).Add(listStringData);
							val10 = (T2)(val10 + 1);
							break;
						}
					}
					else
					{
						setMessage((T1)("TK " + (string)val12 + " DIE"), (T0)1);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
			T4 val26 = executeScript_Promise<T4, T1, IJavaScriptExecutor, ICollection<object>, T0, T10, T11, object>(val8, val9);
			T0 val27 = (T0)(val26 != null && ((List<object>)val26).Count > 0);
			if (val27 != null)
			{
				T2 val28 = (T2)0;
				while (true)
				{
					T0 val29 = (T0)((nint)val28 < ((List<ListStringData>)val11).Count);
					if (val29 == null)
					{
						break;
					}
					T1 val30 = (T1)((List<object>)val26)[(int)val28].ToString();
					T0 val31 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)val11)[(int)val28].str4));
					if (val31 != null)
					{
						((List<ListStringData>)val11)[(int)val28].str4 += "-";
					}
					T0 val32 = (T0)((string)val30).Contains("ad_object_id");
					if (val32 != null)
					{
						((List<ListStringData>)val11)[(int)val28].str4 += "1";
						((List<ListStringData>)val11)[(int)val28].str2 = Regex.Match((string)val30, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
					}
					else
					{
						((List<ListStringData>)val11)[(int)val28].str4 += "0";
					}
					val28 = (T2)(val28 + 1);
				}
			}
			val8 = (T1)"";
			val9 = (T1)"";
			T9 enumerator4 = (T9)((List<ListStringData>)val11).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator4))->MoveNext())
				{
					ListStringData current3 = ((List<ListStringData>.Enumerator*)(&enumerator4))->Current;
					T1 val33 = (T1)current3.str1.Replace("act_", "");
					T1 val34 = (T1)("fetch_" + (string)val33);
					T8 val35 = (T8)Activator.CreateInstance(typeof(T8));
					((Dictionary<string, string>)val35).Add("strDraft_Id", current3.str6);
					((Dictionary<string, string>)val35).Add("strToken_EEAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val35).Add("strAct_Id", (string)val33);
					((Dictionary<string, string>)val35).Add("strValues", ((string)val6).Replace((string)oldValue, (string)val33).Replace((string)oldValue2, current3.str2));
					((Dictionary<string, string>)val35).Add("strCampaign_id", current3.str2);
					((Dictionary<string, string>)val35).Add("result", (string)val34);
					T1 resouce2 = (T1)ResouceControl.getResouce("Tao_Camp_Nhom_QC_PE_Promise", (Dictionary<string, string>)val35);
					val8 = (T1)((string)val8 + (string)resouce2);
					val9 = (T1)((string)val9 + (string)val34 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator4))).Dispose();
			}
			val26 = executeScript_Promise<T4, T1, IJavaScriptExecutor, ICollection<object>, T0, T10, T11, object>(val8, val9);
			T0 val36 = (T0)(val26 != null && ((List<object>)val26).Count > 0);
			if (val36 != null)
			{
				T2 val37 = (T2)0;
				while (true)
				{
					T0 val38 = (T0)((nint)val37 < ((List<ListStringData>)val11).Count);
					if (val38 == null)
					{
						break;
					}
					T1 val39 = (T1)((List<object>)val26)[(int)val37].ToString();
					T0 val40 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)val11)[(int)val37].str4));
					if (val40 != null)
					{
						((List<ListStringData>)val11)[(int)val37].str4 += "-";
					}
					T0 val41 = (T0)((string)val39).Contains("ad_object_id");
					if (val41 == null)
					{
						((List<ListStringData>)val11)[(int)val37].str4 += "0";
					}
					else
					{
						((List<ListStringData>)val11)[(int)val37].str4 += "1";
						((List<ListStringData>)val11)[(int)val37].str3 = Regex.Match((string)val39, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
					}
					val37 = (T2)(val37 + 1);
				}
			}
			val8 = (T1)"";
			val9 = (T1)"";
			T9 enumerator5 = (T9)((List<ListStringData>)val11).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator5))->MoveNext())
				{
					ListStringData current4 = ((List<ListStringData>.Enumerator*)(&enumerator5))->Current;
					T1 val42 = (T1)current4.str1.Replace("act_", "");
					T1 val43 = (T1)("fetch_" + (string)val42);
					T8 val44 = (T8)Activator.CreateInstance(typeof(T8));
					((Dictionary<string, string>)val44).Add("strDraft_Id", current4.str6);
					((Dictionary<string, string>)val44).Add("strToken_EEAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val44).Add("strAct_Id", (string)val42);
					((Dictionary<string, string>)val44).Add("strValues", ((string)val7).Replace((string)oldValue, (string)val42).Replace((string)oldValue2, current4.str2).Replace((string)oldValue3, current4.str3));
					((Dictionary<string, string>)val44).Add("strCampaign_id", current4.str2);
					((Dictionary<string, string>)val44).Add("strAdset_Id", current4.str3);
					((Dictionary<string, string>)val44).Add("result", (string)val43);
					T1 resouce3 = (T1)ResouceControl.getResouce("Tao_Camp_QC_PE_Promise", (Dictionary<string, string>)val44);
					val8 = (T1)((string)val8 + (string)resouce3);
					val9 = (T1)((string)val9 + (string)val43 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator5))).Dispose();
			}
			val26 = executeScript_Promise<T4, T1, IJavaScriptExecutor, ICollection<object>, T0, T10, T11, object>(val8, val9);
			T0 val45 = (T0)(val26 != null && ((List<object>)val26).Count > 0);
			if (val45 != null)
			{
				T2 val46 = (T2)0;
				while (true)
				{
					T0 val47 = (T0)((nint)val46 < ((List<ListStringData>)val11).Count);
					if (val47 == null)
					{
						break;
					}
					T1 val48 = (T1)((List<object>)val26)[(int)val46].ToString();
					T0 val49 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)val11)[(int)val46].str4));
					if (val49 != null)
					{
						((List<ListStringData>)val11)[(int)val46].str4 += "-";
					}
					T0 val50 = (T0)((string)val48).Contains("ad_object_id");
					if (val50 != null)
					{
						((List<ListStringData>)val11)[(int)val46].str4 += "1";
						((List<ListStringData>)val11)[(int)val46].str5 = Regex.Match((string)val48, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
					}
					else
					{
						((List<ListStringData>)val11)[(int)val46].str4 += "0";
					}
					val46 = (T2)(val46 + 1);
				}
			}
			setMessage((T1)"Đăng camp", (T0)0);
			getAddraftCamp_2_Promise<T0, T1, T4, T9, T8, T2, T10, T3>(val11);
			T0 val51 = publishCamps_Promise<T0, T9, T1, T4, T7, T8, List<addraft_fragments_data>.Enumerator, List<object>.Enumerator, object, T10, T3>(val11, (T0)1, (T0)1, (T0)1);
			if (val51 != null)
			{
				setMessage((T1)$"Đăng camp Ok {val10}", (T0)1);
			}
			else
			{
				setMessage((T1)"Đăng camp lỗi", (T0)1);
			}
		}
		catch (Exception ex2)
		{
			setMessage((T1)("e:" + ex2.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Lên_camp_chuyển_đổi<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0119: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_0240: Expected O, but got I4
		//IL_024a: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		//IL_0293: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_0322: Expected O, but got I4
		//IL_0360: Expected O, but got I4
		//IL_064c: Expected O, but got I4
		//IL_067e: Expected O, but got I4
		//IL_079e: Expected O, but got I4
		//IL_0801: Expected O, but got I4
		//IL_081c: Expected O, but got I4
		//IL_0862: Expected O, but got I4
		//IL_0909: Expected O, but got I4
		//IL_093d: Expected O, but got I4
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_098c: Expected O, but got Unknown
		//IL_09b4: Expected O, but got I4
		//IL_09cf: Expected O, but got I4
		//IL_09ec: Expected O, but got I4
		//IL_0a14: Expected O, but got I4
		//IL_0a4c: Expected O, but got I4
		//IL_0a67: Expected O, but got I4
		//IL_0a84: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random-Tên-Id").ToString();
			T1 str = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_web").ToString();
			T1 str2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Nội_dung").ToString();
			T1 path = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Folder_ảnh").ToString();
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Giới_tính_0_1_2").ToString());
			T1 value = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tuổi_min").ToString();
			T1 value2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tuổi_max").ToString();
			T1 str3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Quốc_gia").ToString();
			T1 value3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Ngân_sách").ToString();
			T1 value4 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Pixcel_Id").ToString();
			T1 value5 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Domain_Pixel").ToString();
			T1 value6 = (T1)"";
			val2 = (T1)((string)val2).ToLower().Trim();
			T1 strError = (T1)"";
			T3 val3 = mtLoadPage<T3, T1, T0, T13, T7>(out *(string*)(&strError));
			T0 val4 = (T0)(val3 != null && ((List<facebook_pagesData>)val3).Count > 0);
			if (val4 != null)
			{
				T4 enumerator = (T4)((List<facebook_pagesData>)val3).GetEnumerator();
				try
				{
					while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
					{
						facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
						T0 val5 = (T0)(string.IsNullOrEmpty((string)val2) || ((string)val2).Equals("random"));
						if (val5 == null)
						{
							T0 val6 = (T0)(current.id.Contains((string)val2) || current.name.ToLower().Contains((string)val2));
							if (val6 != null)
							{
								value6 = (T1)current.id;
								break;
							}
						}
						else
						{
							T0 val7 = (T0)(!current.is_restricted);
							if (val7 != null)
							{
								value6 = (T1)current.id;
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
			T2 val8 = (T2)0;
			T0 val9 = (T0)string.IsNullOrWhiteSpace((string)value6);
			if (val9 == null)
			{
				getFullAdsInfo<T7, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, T2, char, IDisposable, T13, IWebElement>();
				T5 enumerator2 = (T5)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
					{
						adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
						T1 val10 = (T1)current2.id.Replace("act_", "");
						adaccountsData adaccountsData = reload_act<T1, T13, T7>(val10);
						T0 val11 = (T0)(adaccountsData.account_status == 2);
						if (val11 == null)
						{
							T0 val12 = (T0)0;
							setMessage((T1)"Share pixel", (T0)0);
							T6 enumerator3 = (T6)frmMain.setting.List_TOKEN_PIXEL.GetEnumerator();
							try
							{
								while (((List<TokenEntity>.Enumerator*)(&enumerator3))->MoveNext())
								{
									TokenEntity current3 = ((List<TokenEntity>.Enumerator*)(&enumerator3))->Current;
									T0 val13 = (T0)current3.Status.Equals(frmMain.STATUS.Live.ToString());
									if (val13 != null)
									{
										T0 val14 = frmMain.apiPixel.Share_Pixel<T0, T2, T1, T13, HttpRequest>((T1)current3.Token, (T1)frmMain.setting.BM_Pixel_ID, (T1)frmMain.setting.Pixel_Id, val10);
										if (val14 != null)
										{
											val12 = (T0)1;
											break;
										}
										current3.Status = frmMain.STATUS.Die.ToString();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator3))).Dispose();
							}
							T0 val15 = (T0)(val12 == null);
							if (val15 != null)
							{
								setMessage((T1)"e:Share pixel lỗi", (T0)1);
								break;
							}
							T1 val16 = (T1)"";
							setMessage((T1)"Nhập camp", (T0)0);
							fetch_url<T7, T1, T13>((T1)("https://business.facebook.com/adsmanager/manage/ads?act=" + (string)val10));
							Thread.Sleep(1000);
							addraft_fragments_2 addraft_fragments_ = null;
							addraft_fragments_ = getAddraftCamp_2<T0, T2, T7, T1, IJavaScriptExecutor, object>(val10);
							T0 val17 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
							if (val17 != null)
							{
								T8 enumerator4 = (T8)addraft_fragments_.data.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator4))->MoveNext())
									{
										addraft_fragments_2_data current4 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator4))->Current;
										val16 = (T1)current4.id;
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator4))).Dispose();
								}
							}
							T7 val18 = (T7)Activator.CreateInstance(typeof(T7));
							((Dictionary<string, string>)val18).Add("strDraft_Id", (string)val16);
							((Dictionary<string, string>)val18).Add("strToken_EAAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val18).Add("strAct_Id", (string)val10);
							((Dictionary<string, string>)val18).Add("strBuget", (string)value3);
							T1 resouce = (T1)ResouceControl.getResouce("Tao_chien_dich_chuyen_doi", (Dictionary<string, string>)val18);
							T1 input = executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce);
							T1 value7 = (T1)Regex.Match((string)input, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
							val18 = (T7)Activator.CreateInstance(typeof(T7));
							((Dictionary<string, string>)val18).Add("strDraft_Id", (string)val16);
							((Dictionary<string, string>)val18).Add("strToken_EAAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val18).Add("strAct_Id", (string)val10);
							((Dictionary<string, string>)val18).Add("strAct_Id", (string)val10);
							((Dictionary<string, string>)val18).Add("strCamp_object_id", (string)value7);
							((Dictionary<string, string>)val18).Add("strAgeMin", (string)value);
							((Dictionary<string, string>)val18).Add("strAgeMax", (string)value2);
							T1 value8 = (T1)HttpUtility.UrlEncode((string)str3);
							((Dictionary<string, string>)val18).Add("strCountry", (string)value8);
							((Dictionary<string, string>)val18).Add("strPixel_Id", (string)value4);
							T1 resouce2 = (T1)ResouceControl.getResouce("Tao_nhom_quang_cao_chuyen_doi", (Dictionary<string, string>)val18);
							input = executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce2);
							T1 value9 = (T1)Regex.Match((string)input, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
							Thread.Sleep(1000);
							T1 value10 = (T1)"";
							T1 val19 = (T1)"";
							T1 filename = ((IEnumerable<T1>)(object)Directory.GetFiles((string)path)).First();
							T9 val20 = (T9)Image.FromFile((string)filename);
							try
							{
								T10 val21 = (T10)Activator.CreateInstance(typeof(MemoryStream));
								try
								{
									((Image)val20).Save((Stream)val21, ((Image)val20).RawFormat);
									T11[] inArray = (T11[])(object)((MemoryStream)val21).ToArray();
									val19 = (T1)Convert.ToBase64String((byte[])(object)inArray);
									val19 = (T1)HttpUtility.UrlEncode((string)val19);
								}
								finally
								{
									if (val21 != null)
									{
										((IDisposable)val21).Dispose();
									}
								}
							}
							finally
							{
								if (val20 != null)
								{
									((IDisposable)val20).Dispose();
								}
							}
							val18 = (T7)Activator.CreateInstance(typeof(T7));
							((Dictionary<string, string>)val18).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val18).Add("strAct_Id", (string)val10);
							((Dictionary<string, string>)val18).Add("strBM_Id", "");
							((Dictionary<string, string>)val18).Add("strBytes", (string)val19);
							T1 resouce3 = (T1)ResouceControl.getResouce("Upload_anh_camp", (Dictionary<string, string>)val18);
							input = executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce3);
							T0 val22 = (T0)(!((string)input).Contains("hash\":"));
							if (val22 == null)
							{
								value10 = (T1)Regex.Match((string)input, "hash\":\"(.*?)\"").Groups[1].Value;
							}
							else
							{
								setMessage((T1)"e:Upload ảnh camp lỗi", (T0)1);
							}
							val18 = (T7)Activator.CreateInstance(typeof(T7));
							((Dictionary<string, string>)val18).Add("strDraft_Id", (string)val16);
							((Dictionary<string, string>)val18).Add("strToken_EAAB", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val18).Add("strAct_Id", (string)val10);
							((Dictionary<string, string>)val18).Add("strCamp_object_id", (string)value7);
							((Dictionary<string, string>)val18).Add("strAds_Object_Id", (string)value9);
							((Dictionary<string, string>)val18).Add("strPixel_Domain", (string)value5);
							((Dictionary<string, string>)val18).Add("strImg_Hash", (string)value10);
							T1 value11 = (T1)HttpUtility.UrlEncode((string)str2);
							((Dictionary<string, string>)val18).Add("strContent", (string)value11);
							T1 value12 = (T1)HttpUtility.UrlEncode((string)str);
							((Dictionary<string, string>)val18).Add("strWebShop", (string)value12);
							((Dictionary<string, string>)val18).Add("strPage_Id", (string)value6);
							T1 resouce4 = (T1)ResouceControl.getResouce("Tao_quang_cao_chuyen_doi", (Dictionary<string, string>)val18);
							input = executeScript<T1, IJavaScriptExecutor, T2, T0, object>(resouce4);
							_ = Regex.Match((string)input, "ad_object_id\":\"(.*?)\"").Groups[1].Value;
							Thread.Sleep(1000);
							T1 val23 = (T1)"";
							T0 val28;
							do
							{
								addraft_fragments_ = getAddraftCamp_2<T0, T2, T7, T1, IJavaScriptExecutor, object>(val10);
								T0 val24 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
								if (val24 != null)
								{
									T8 enumerator5 = (T8)addraft_fragments_.data.GetEnumerator();
									try
									{
										while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator5))->MoveNext())
										{
											addraft_fragments_2_data current5 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator5))->Current;
											val16 = (T1)current5.id;
											T12 enumerator6 = (T12)current5.addraft_fragments.data.GetEnumerator();
											try
											{
												while (((List<addraft_fragments_data>.Enumerator*)(&enumerator6))->MoveNext())
												{
													addraft_fragments_data current6 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator6))->Current;
													T0 val25 = (T0)current6.ad_object_type.Equals("ad");
													if (val25 == null)
													{
														T0 val26 = (T0)current6.ad_object_type.Equals("campaign");
														if (val26 != null)
														{
															val23 = (T1)((string)val23 + "\"" + current6.id + "\",");
															_ = current6.ad_object_id;
															_ = current6.id;
															continue;
														}
														T0 val27 = (T0)current6.ad_object_type.Equals("ad_set");
														if (val27 != null)
														{
															val23 = (T1)((string)val23 + "\"" + current6.id + "\",");
															_ = current6.ad_object_id;
															_ = current6.id;
														}
													}
													else
													{
														val23 = (T1)((string)val23 + "\"" + current6.id + "\",");
														_ = current6.ad_object_id;
														_ = current6.id;
														_ = current6.parent_ad_object_id;
													}
												}
											}
											finally
											{
												((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator6))).Dispose();
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator5))).Dispose();
									}
								}
								val28 = (T0)string.IsNullOrWhiteSpace((string)val16);
							}
							while (val28 != null);
							T0 val29 = (T0)(((string)val23).Length > 0);
							if (val29 != null)
							{
								val23 = (T1)((string)val23).Remove(((string)val23).Length - 1, 1);
							}
							val23 = (T1)("[" + (string)val23 + "]");
							val23 = (T1)HttpUtility.UrlEncode((string)val23);
							T0 val30 = publishCamps<T0, T7, T1>(val16, val23);
							T0 val31 = val30;
							if (val31 != null)
							{
								val8 = (T2)(val8 + 1);
							}
							Console.WriteLine(((bool*)(&val30))->ToString());
						}
						else
						{
							setMessage((T1)("TK " + (string)val10 + " DIE"), (T0)1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
				}
			}
			else
			{
				setMessage((T1)"e:Không có page", (T0)1);
			}
			T0 val32 = (T0)frmMain.listFBEntity[indexEntity].Message.Contains("e:");
			if (val32 != null)
			{
				setMessage((T1)$"Camp: {val8} -{frmMain.listFBEntity[indexEntity].Message}", (T0)0);
			}
			else
			{
				setMessage((T1)$"Camp: {val8}", (T0)0);
			}
		}
		catch (Exception ex)
		{
			setMessage((T1)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 getDraft_Edit_Target<T0, T1, T2, T3, T4, T5>(T1 Act_Id, out string Camp, out string Adset, out string Ad, out string message)
	{
		//IL_0033: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_02c9: Expected O, but got I4
		//IL_02fa: Expected O, but got I4
		//IL_03a9: Expected O, but got I4
		//IL_03ce: Expected O, but got I4
		//IL_03f4: Expected O, but got I4
		//IL_0421: Expected O, but got I4
		Act_Id = (T1)((string)Act_Id).Replace("act_", "");
		Camp = "";
		Adset = "";
		Ad = "";
		message = "";
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)"";
			addraft_fragments_2 addraft_fragments_ = null;
			addraft_fragments_ = getAddraftCamp_2<T0, int, Dictionary<string, string>, T1, IJavaScriptExecutor, object>(Act_Id);
			T0 val2 = (T0)(addraft_fragments_ != null && addraft_fragments_.data != null);
			if (val2 != null)
			{
				T2 enumerator = (T2)addraft_fragments_.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						val = (T1)current.id;
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val3 = (T0)(!string.IsNullOrWhiteSpace((string)val));
			if (val3 != null)
			{
				addraft_fragments addraftCamp = getAddraftCamp<T0, Dictionary<string, string>, T1, IJavaScriptExecutor, int, object>(val);
				T0 val4 = (T0)(addraftCamp != null && addraftCamp.data != null && addraftCamp.data.Count > 0);
				if (val4 != null)
				{
					T3 enumerator2 = (T3)addraftCamp.data.GetEnumerator();
					try
					{
						while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
							T0 val5 = (T0)(current2.ad_object_type.Equals("campaign") && current2.values != null);
							if (val5 != null)
							{
								T4 enumerator3 = (T4)current2.values.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_data_value>.Enumerator*)(&enumerator3))->MoveNext())
									{
										addraft_fragments_data_value current3 = ((List<addraft_fragments_data_value>.Enumerator*)(&enumerator3))->Current;
										T0 val6 = (T0)(!string.IsNullOrWhiteSpace(Camp));
										if (val6 != null)
										{
											Camp += ",";
										}
										Camp = string.Concat((string[])(object)new T1[8]
										{
											(T1)Camp,
											(T1)"{\"field\":\"",
											(T1)current3.field,
											(T1)"\",\"old_value\":",
											(T1)current3.old_value,
											(T1)",\"new_value\":",
											(T1)current3.new_value,
											(T1)"}"
										});
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_data_value>.Enumerator*)(&enumerator3))).Dispose();
								}
								_ = current2.ad_object_id;
							}
							T0 val7 = (T0)(current2.ad_object_type.Equals("ad_set") && current2.values != null);
							if (val7 != null)
							{
								T4 enumerator4 = (T4)current2.values.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_data_value>.Enumerator*)(&enumerator4))->MoveNext())
									{
										addraft_fragments_data_value current4 = ((List<addraft_fragments_data_value>.Enumerator*)(&enumerator4))->Current;
										T0 val8 = (T0)(!string.IsNullOrWhiteSpace(Adset));
										if (val8 != null)
										{
											Adset += ",";
										}
										Adset = string.Concat((string[])(object)new T1[8]
										{
											(T1)Adset,
											(T1)"{\"field\":\"",
											(T1)current4.field,
											(T1)"\",\"old_value\":",
											(T1)current4.old_value,
											(T1)",\"new_value\":",
											(T1)current4.new_value,
											(T1)"}"
										});
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_data_value>.Enumerator*)(&enumerator4))).Dispose();
								}
								_ = current2.ad_object_id;
							}
							T0 val9 = (T0)(current2.ad_object_type.Equals("ad") && current2.values != null);
							if (val9 == null)
							{
								continue;
							}
							T4 enumerator5 = (T4)current2.values.GetEnumerator();
							try
							{
								while (((List<addraft_fragments_data_value>.Enumerator*)(&enumerator5))->MoveNext())
								{
									addraft_fragments_data_value current5 = ((List<addraft_fragments_data_value>.Enumerator*)(&enumerator5))->Current;
									T0 val10 = (T0)(!string.IsNullOrWhiteSpace(Ad));
									if (val10 != null)
									{
										Ad += ",";
									}
									Ad = string.Concat((string[])(object)new T1[8]
									{
										(T1)Ad,
										(T1)"{\"field\":\"",
										(T1)current5.field,
										(T1)"\",\"old_value\":",
										(T1)current5.old_value,
										(T1)",\"new_value\":",
										(T1)current5.new_value,
										(T1)"}"
									});
								}
							}
							finally
							{
								((IDisposable)(*(List<addraft_fragments_data_value>.Enumerator*)(&enumerator5))).Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
				T0 val11 = (T0)(!string.IsNullOrEmpty(Camp));
				if (val11 != null)
				{
					Camp = "[" + Camp + "]";
				}
				T0 val12 = (T0)(!string.IsNullOrEmpty(Adset));
				if (val12 != null)
				{
					Adset = "[" + Adset + "]";
				}
				T0 val13 = (T0)(!string.IsNullOrEmpty(Ad));
				if (val13 != null)
				{
					Ad = "[" + Ad + "]";
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			result = (T0)0;
			message = ex.Message;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 getDraft_Template<T0, T1, T2, T3, T4, T5>(T0 Act_Id)
	{
		//IL_0039: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_01f8: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_02d4: Expected O, but got I4
		//IL_0301: Expected O, but got I4
		Act_Id = (T0)((string)Act_Id).Replace("act_", "");
		T0 result = (T0)"";
		try
		{
			T0 val = (T0)"";
			addraft_fragments_2 addraft_fragments_ = null;
			addraft_fragments_ = getAddraftCamp_2<T1, int, Dictionary<string, string>, T0, IJavaScriptExecutor, object>(Act_Id);
			T1 val2 = (T1)(addraft_fragments_ != null && addraft_fragments_.data != null);
			if (val2 != null)
			{
				T2 enumerator = (T2)addraft_fragments_.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						val = (T0)current.id;
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T1 val3 = (T1)(!string.IsNullOrWhiteSpace((string)val));
			if (val3 != null)
			{
				addraft_fragments addraftCamp = getAddraftCamp<T1, Dictionary<string, string>, T0, IJavaScriptExecutor, int, object>(val);
				T0 val4 = (T0)"";
				T0 val5 = (T0)"";
				T0 val6 = (T0)"";
				T0 val7 = (T0)"";
				T0 val8 = (T0)"";
				T1 val9 = (T1)(addraftCamp != null && addraftCamp.data != null && addraftCamp.data.Count > 0);
				if (val9 != null)
				{
					T3 enumerator2 = (T3)addraftCamp.data.GetEnumerator();
					try
					{
						while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
							T1 val10 = (T1)(current2.ad_object_type.Equals("campaign") && current2.values != null);
							if (val10 != null)
							{
								T4 enumerator3 = (T4)current2.values.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_data_value>.Enumerator*)(&enumerator3))->MoveNext())
									{
										addraft_fragments_data_value current3 = ((List<addraft_fragments_data_value>.Enumerator*)(&enumerator3))->Current;
										T1 val11 = (T1)(!string.IsNullOrWhiteSpace((string)val4));
										if (val11 != null)
										{
											val4 = (T0)((string)val4 + ",");
										}
										val4 = (T0)string.Concat((string[])(object)new T0[8]
										{
											val4,
											(T0)"{\"field\":\"",
											(T0)current3.field,
											(T0)"\",\"old_value\":",
											(T0)current3.old_value,
											(T0)",\"new_value\":",
											(T0)current3.new_value,
											(T0)"}"
										});
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_data_value>.Enumerator*)(&enumerator3))).Dispose();
								}
								val7 = (T0)current2.ad_object_id;
							}
							T1 val12 = (T1)(current2.ad_object_type.Equals("ad_set") && current2.values != null);
							if (val12 != null)
							{
								T4 enumerator4 = (T4)current2.values.GetEnumerator();
								try
								{
									while (((List<addraft_fragments_data_value>.Enumerator*)(&enumerator4))->MoveNext())
									{
										addraft_fragments_data_value current4 = ((List<addraft_fragments_data_value>.Enumerator*)(&enumerator4))->Current;
										T1 val13 = (T1)(!string.IsNullOrWhiteSpace((string)val5));
										if (val13 != null)
										{
											val5 = (T0)((string)val5 + ",");
										}
										val5 = (T0)string.Concat((string[])(object)new T0[8]
										{
											val5,
											(T0)"{\"field\":\"",
											(T0)current4.field,
											(T0)"\",\"old_value\":",
											(T0)current4.old_value,
											(T0)",\"new_value\":",
											(T0)current4.new_value,
											(T0)"}"
										});
									}
								}
								finally
								{
									((IDisposable)(*(List<addraft_fragments_data_value>.Enumerator*)(&enumerator4))).Dispose();
								}
								val8 = (T0)current2.ad_object_id;
							}
							T1 val14 = (T1)(current2.ad_object_type.Equals("ad") && current2.values != null);
							if (val14 == null)
							{
								continue;
							}
							T4 enumerator5 = (T4)current2.values.GetEnumerator();
							try
							{
								while (((List<addraft_fragments_data_value>.Enumerator*)(&enumerator5))->MoveNext())
								{
									addraft_fragments_data_value current5 = ((List<addraft_fragments_data_value>.Enumerator*)(&enumerator5))->Current;
									T1 val15 = (T1)(!string.IsNullOrWhiteSpace((string)val6));
									if (val15 != null)
									{
										val6 = (T0)((string)val6 + ",");
									}
									val6 = (T0)string.Concat((string[])(object)new T0[8]
									{
										val6,
										(T0)"{\"field\":\"",
										(T0)current5.field,
										(T0)"\",\"old_value\":",
										(T0)current5.old_value,
										(T0)",\"new_value\":",
										(T0)current5.new_value,
										(T0)"}"
									});
								}
							}
							finally
							{
								((IDisposable)(*(List<addraft_fragments_data_value>.Enumerator*)(&enumerator5))).Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
				val4 = (T0)("[" + (string)val4 + "]");
				val5 = (T0)("[" + (string)val5 + "]");
				val6 = (T0)("[" + (string)val6 + "]");
				result = (T0)string.Concat((string[])(object)new T0[14]
				{
					(T0)"act_id:",
					Act_Id,
					(T0)Environment.NewLine,
					(T0)"campaign_id:",
					val7,
					(T0)Environment.NewLine,
					(T0)"adset_id:",
					val8,
					(T0)Environment.NewLine,
					val4,
					(T0)Environment.NewLine,
					val5,
					(T0)Environment.NewLine,
					val6
				});
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 publishCamps<T0, T1, T2>(T2 strAddraft, T2 strFragments)
	{
		//IL_0022: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val != null)
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
			else
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
				((Dictionary<string, string>)val2).Add("strAddraft", (string)strAddraft);
				((Dictionary<string, string>)val2).Add("strFragments", (string)strFragments);
				T2 resouce = (T2)ResouceControl.getResouce("publish_camps", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
				T0 val4 = (T0)((string)val3).Contains("success");
				if (val4 != null)
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
	public unsafe T0 publishCamps_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 listData, T0 isPlush_Camp, T0 isPlush_Ads, T0 isPlush_Adset)
	{
		//IL_0002: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_0324: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			Chap_nhan_dieu_khoan_camp<T2>();
			T1 enumerator = (T1)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T2 val2 = (T2)"";
					T2 val3 = (T2)"";
					current.str2 = "";
					addraft_fragments_2 addraft_fragments_ = (addraft_fragments_2)current.obj1;
					T4 enumerator2 = (T4)addraft_fragments_.data.GetEnumerator();
					try
					{
						while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							addraft_fragments_2_data current2 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator2))->Current;
							T2 val4 = (T2)"";
							T6 enumerator3 = (T6)current2.addraft_fragments.data.GetEnumerator();
							try
							{
								while (((List<addraft_fragments_data>.Enumerator*)(&enumerator3))->MoveNext())
								{
									addraft_fragments_data current3 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator3))->Current;
									T0 val5 = (T0)(isPlush_Camp != null && current3.ad_object_type.ToLower().Equals("campaign"));
									if (val5 != null)
									{
										val4 = (T2)((string)val4 + "\"" + current3.id + "\",");
									}
									T0 val6 = (T0)(isPlush_Ads != null && current3.ad_object_type.ToLower().Equals("ad_set"));
									if (val6 != null)
									{
										val4 = (T2)((string)val4 + "\"" + current3.id + "\",");
									}
									T0 val7 = (T0)(isPlush_Adset != null && current3.ad_object_type.ToLower().Equals("ad"));
									if (val7 != null)
									{
										val4 = (T2)((string)val4 + "\"" + current3.id + "\",");
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator3))).Dispose();
							}
							T0 val8 = (T0)(((string)val4).Length > 0);
							if (val8 != null)
							{
								val4 = (T2)((string)val4).Remove(((string)val4).Length - 1, 1);
								val4 = (T2)("[" + (string)val4 + "]");
							}
							val4 = (T2)HttpUtility.UrlEncode((string)val4);
							T2 id = (T2)current2.id;
							T2 val9 = (T2)("fetch_" + (string)id);
							T5 val10 = (T5)Activator.CreateInstance(typeof(T5));
							((Dictionary<string, string>)val10).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
							((Dictionary<string, string>)val10).Add("strAddraft", current2.id);
							((Dictionary<string, string>)val10).Add("strFragments", (string)val4);
							((Dictionary<string, string>)val10).Add("result", (string)val9);
							T2 resouce = (T2)ResouceControl.getResouce("publish_camps_Promise", (Dictionary<string, string>)val10);
							val2 = (T2)((string)val2 + (string)resouce);
							val3 = (T2)((string)val3 + (string)val9 + ",");
						}
					}
					finally
					{
						((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator2))).Dispose();
					}
					T3 val11 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T9, char, T8>(val2, val3);
					T7 enumerator4 = (T7)((List<object>)val11).GetEnumerator();
					try
					{
						while (((List<object>.Enumerator*)(&enumerator4))->MoveNext())
						{
							T8 current4 = (T8)((List<object>.Enumerator*)(&enumerator4))->Current;
							T0 val12 = (T0)current4.ToString().Contains("success");
							if (val12 == null)
							{
								current.str2 += frmMain.STATUS.lỗi;
							}
							else
							{
								current.str2 += frmMain.STATUS.Done;
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<object>.Enumerator*)(&enumerator4))).Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			val = (T0)1;
		}
		catch (Exception ex)
		{
			val = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T9 publishCamps_2<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 listDraft)
	{
		//IL_00cb: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_0156: Expected I4, but got O
		//IL_016c: Expected O, but got I4
		//IL_0178: Expected I4, but got O
		//IL_0197: Expected I4, but got O
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Expected O, but got I4
		try
		{
			T0 val = (T0)"";
			T0 val2 = (T0)"";
			T3 enumerator = (T3)((List<ListStringData>)listDraft).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T0 val3 = (T0)("fetch_" + current.str1);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val4).Add("strAddraft", current.str1);
					((Dictionary<string, string>)val4).Add("strFragments", current.str2);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T0 resouce = (T0)ResouceControl.getResouce("publish_camps_2", (Dictionary<string, string>)val4);
					val = (T0)((string)val + (string)resouce);
					T5 val5 = (T5)(!string.IsNullOrWhiteSpace((string)val2));
					if (val5 != null)
					{
						val2 = (T0)((string)val2 + ",");
					}
					val2 = (T0)((string)val2 + (string)val3);
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T0 val6 = val;
			val6 = (T0)((string)val6 + "var testPromise=await Promise.all([" + (string)val2 + "]).then((values) => { return values; }); return testPromise;");
			T1 val7 = (T1)chrome;
			T2 val8 = (T2)(ICollection<object>)((IJavaScriptExecutor)val7).ExecuteScript((string)val6, (object[])(object)Array.Empty<T10>());
			T5 val9 = (T5)(val8 != null);
			if (val9 != null)
			{
				T6 val10 = (T6)((IEnumerable<T10>)val8).ToList();
				T7 val11 = (T7)0;
				while (true)
				{
					T5 val12 = (T5)((nint)val11 < ((List<ListStringData>)listDraft).Count);
					if (val12 != null)
					{
						T0 val13 = (T0)((List<object>)val10)[(int)val11].ToString();
						T5 val14 = (T5)((string)val13).Contains("success");
						if (val14 == null)
						{
							((List<ListStringData>)listDraft)[(int)val11].str3 = frmMain.STATUS.lỗi.ToString();
						}
						else
						{
							((List<ListStringData>)listDraft)[(int)val11].str3 = frmMain.STATUS.Done.ToString();
						}
						val11 = (T7)(val11 + 1);
						continue;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
		return listDraft;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ADSPRoject.Data.BillingAMNexusRootQuery lay_toan_bo_payment_method<T0, T1>(T1 act)
	{
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strAct", ((string)act).Replace("act_", ""));
			T1 resouce = (T1)ResouceControl.getResouce("lay_toan_bo_payment_method", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
			return JsonConvert.DeserializeObject<ADSPRoject.Data.BillingAMNexusRootQuery>((string)val2);
		}
		catch
		{
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 addCart<T0, T1, T2, T3, T4, T5>(T2 ads, T2 Đổi_quốc_gia, T0 Đẩy_lên_chính)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0006: Expected O, but got I4
		//IL_000d: Expected O, but got I4
		//IL_0010: Expected O, but got I4
		//IL_0023: Expected I4, but got O
		//IL_003f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_005e: Expected O, but got I4
		//IL_0078: Expected I4, but got O
		//IL_0094: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_0100: Expected I4, but got O
		//IL_0115: Expected I4, but got O
		//IL_012a: Expected I4, but got O
		//IL_017f: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c7: Expected I4, but got O
		//IL_01e7: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_0215: Expected O, but got I4
		T0 result = (T0)0;
		T0 val = (T0)1;
		T1 val2 = (T1)0;
		while (true)
		{
			T0 val3 = val;
			if (val3 == null)
			{
				break;
			}
			T1 val4 = (T1)(-1);
			T1 val5 = (T1)0;
			while (true)
			{
				T0 val6 = (T0)((nint)val5 < frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"").Count);
				if (val6 == null)
				{
					break;
				}
				T0 val7 = (T0)frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val5].Status.Equals(frmMain.STATUS.Ready.ToString());
				if (val7 == null)
				{
					val5 = (T1)(val5 + 1);
					continue;
				}
				val4 = val5;
				frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val5].Status = frmMain.STATUS.Used.ToString();
				break;
			}
			T0 val8 = (T0)((nint)val4 == -1);
			if (val8 == null)
			{
				T0 val9 = (T0)(Đổi_quốc_gia == null);
				if (val9 != null)
				{
					Đổi_quốc_gia = (T2)"UA";
				}
				T2 quocGia = Đổi_quốc_gia;
				T0 val10 = (T0)((string)Đổi_quốc_gia).Contains("_");
				if (val10 != null)
				{
					quocGia = (T2)((string)Đổi_quốc_gia).Split((char[])(object)new T3[1] { (T3)95 })[1];
				}
				try
				{
					T2 val11 = (T2)addCard((string)quocGia, frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val4].Card_Number, frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val4].Card_Security, frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val4].Exp_Month, frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val4].Exp_Year, (string)ads);
					AddCard_Result addCard_Result = JsonConvert.DeserializeObject<AddCard_Result>((string)val11);
					T0 val12 = (T0)(((string)val11).Contains("declined") || ((string)val11).Contains("inactive or has been disabled") || ((string)val11).Contains("Invalid Card Number") || ((string)val11).Contains("api_error_code"));
					if (val12 == null)
					{
						val = (T0)0;
						result = (T0)1;
						if (Đẩy_lên_chính != null)
						{
							day_the_len_chinh<T0, T4, T2, T5>(ads, (T2)addCard_Result.data.add_credit_card.credit_card.credential_id, (T2)"");
						}
					}
					else
					{
						val2 = (T1)(val2 + 1);
						frmMain.listCreditCardEntity<T1, T0, List<CreditCardEntity>, T2>((T2)"")[(int)val4].Status = frmMain.STATUS.Declined.ToString();
					}
					T0 val13 = (T0)((nint)val2 >= 10);
					if (val13 != null)
					{
						val = (T0)0;
						result = (T0)0;
					}
				}
				catch
				{
					result = (T0)0;
				}
			}
			else
			{
				frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Message", (T2)"Hết thẻ");
				val = (T0)0;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string addCard(string quocGia, string Card_Number, string Card_Security, string Exp_Month, string expiry_year, string ads)
	{
		string result = "";
		try
		{
			string text = Card_Number.Substring(0, 6);
			string text2 = Card_Number.Substring(Card_Number.Length - 4, 4);
			if (expiry_year.Length == 2)
			{
				expiry_year = "20" + expiry_year;
			}
			string str = "{\"input\":{\"billing_address\":{\"country_code\":\"" + quocGia + "\"},\"billing_logging_data\":{\"logging_counter\":1,\"logging_id\":\"1\"},\"cardholder_name\":\"" + frmMain.listFBEntity[indexEntity].Name + "\",\"credit_card_first_6\":{\"sensitive_string_value\":\"" + text + "\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"" + text2 + "\"},\"credit_card_number\":{\"sensitive_string_value\":\"" + Card_Number + "\"},\"csc\":{\"sensitive_string_value\":\"" + Card_Security + "\"},\"expiry_month\":\"" + int.Parse(Exp_Month) + "\",\"expiry_year\":\"" + expiry_year + "\",\"payment_account_id\":\"" + ads.Replace("act_", "") + "\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true,\"actor_id\":\"" + frmMain.listFBEntity[indexEntity].UID + "\",\"client_mutation_id\":\"3\"}}";
			string value = HttpUtility.UrlEncode(str);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
			dictionary.Add("strVariables", value);
			string resouce = ResouceControl.getResouce("Add_the", dictionary);
			result = executeScript<string, IJavaScriptExecutor, int, bool, object>(resouce);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 addCard_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T1 listData, T0 isPlushPrimary, T0 MFacebook, T0 Link667, T0 AddCode, T0 isBoospost, T0 isSuite, T0 isLink1, T0 isAPI, T0 isRequest, T0 MFacebook2, T0 isPro5, T2 changerUID)
	{
		//IL_0002: Expected O, but got I4
		//IL_000a: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_02a5: Expected O, but got I4
		//IL_02af: Expected O, but got I4
		//IL_02bd: Expected I4, but got O
		//IL_02cc: Expected I4, but got O
		//IL_0303: Expected O, but got I4
		//IL_0341: Expected I4, but got O
		//IL_0374: Expected I4, but got O
		//IL_0396: Expected I4, but got O
		//IL_03ba: Expected O, but got I4
		//IL_03c6: Expected I4, but got O
		//IL_03f5: Expected I4, but got O
		//IL_0401: Expected O, but got I4
		//IL_040d: Expected I4, but got O
		//IL_0437: Expected I4, but got O
		//IL_0443: Expected O, but got I4
		//IL_044f: Expected I4, but got O
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_0483: Expected O, but got I4
		//IL_048c: Expected O, but got I4
		//IL_0583: Expected O, but got I4
		//IL_06c2: Expected O, but got I4
		//IL_06cc: Expected O, but got I4
		//IL_06da: Expected I4, but got O
		//IL_06e9: Expected I4, but got O
		//IL_0720: Expected O, but got I4
		//IL_072f: Expected I4, but got O
		//IL_0753: Expected O, but got I4
		//IL_075f: Expected I4, but got O
		//IL_078e: Expected I4, but got O
		//IL_079a: Expected O, but got I4
		//IL_07a6: Expected I4, but got O
		//IL_07d0: Expected I4, but got O
		//IL_07dc: Expected O, but got I4
		//IL_07eb: Expected I4, but got O
		//IL_0846: Expected I4, but got O
		//IL_0879: Expected I4, but got O
		//IL_0891: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Expected O, but got Unknown
		//IL_08a0: Expected O, but got I4
		//IL_08a9: Expected O, but got I4
		//IL_09a0: Expected O, but got I4
		//IL_0af4: Expected O, but got I4
		//IL_0afe: Expected O, but got I4
		//IL_0b0c: Expected I4, but got O
		//IL_0b1b: Expected I4, but got O
		//IL_0b52: Expected O, but got I4
		//IL_0b61: Expected I4, but got O
		//IL_0b85: Expected O, but got I4
		//IL_0b91: Expected I4, but got O
		//IL_0bc0: Expected I4, but got O
		//IL_0bcc: Expected O, but got I4
		//IL_0bd8: Expected I4, but got O
		//IL_0c02: Expected I4, but got O
		//IL_0c0e: Expected O, but got I4
		//IL_0c1d: Expected I4, but got O
		//IL_0c78: Expected I4, but got O
		//IL_0cab: Expected I4, but got O
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Expected O, but got Unknown
		//IL_0cd2: Expected O, but got I4
		//IL_0cdb: Expected O, but got I4
		//IL_0dd2: Expected O, but got I4
		//IL_0f26: Expected O, but got I4
		//IL_0f30: Expected O, but got I4
		//IL_0f3e: Expected I4, but got O
		//IL_0f4d: Expected I4, but got O
		//IL_0f84: Expected O, but got I4
		//IL_0fc2: Expected I4, but got O
		//IL_0ff5: Expected I4, but got O
		//IL_1017: Expected I4, but got O
		//IL_103b: Expected O, but got I4
		//IL_1047: Expected I4, but got O
		//IL_1076: Expected I4, but got O
		//IL_1082: Expected O, but got I4
		//IL_108e: Expected I4, but got O
		//IL_10b8: Expected I4, but got O
		//IL_10c4: Expected O, but got I4
		//IL_10d0: Expected I4, but got O
		//IL_10f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f8: Expected O, but got Unknown
		//IL_1104: Expected O, but got I4
		//IL_110d: Expected O, but got I4
		//IL_1204: Expected O, but got I4
		//IL_1358: Expected O, but got I4
		//IL_1362: Expected O, but got I4
		//IL_1370: Expected I4, but got O
		//IL_137f: Expected I4, but got O
		//IL_13b6: Expected O, but got I4
		//IL_13c5: Expected I4, but got O
		//IL_13e9: Expected O, but got I4
		//IL_13f5: Expected I4, but got O
		//IL_1424: Expected I4, but got O
		//IL_1430: Expected O, but got I4
		//IL_143c: Expected I4, but got O
		//IL_1466: Expected I4, but got O
		//IL_1472: Expected O, but got I4
		//IL_1481: Expected I4, but got O
		//IL_14dc: Expected I4, but got O
		//IL_150f: Expected I4, but got O
		//IL_1527: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Expected O, but got Unknown
		//IL_1536: Expected O, but got I4
		//IL_153f: Expected O, but got I4
		//IL_155a: Expected O, but got I4
		//IL_17a2: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1801: Expected O, but got I4
		//IL_1859: Expected O, but got I4
		//IL_1874: Expected O, but got I4
		//IL_1a7c: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1adb: Expected O, but got I4
		//IL_1b33: Expected O, but got I4
		//IL_1c27: Expected O, but got I4
		//IL_1c53: Expected O, but got I4
		//IL_1cda: Expected O, but got I4
		//IL_1de0: Expected O, but got I4
		//IL_1dea: Expected O, but got I4
		//IL_1df8: Expected I4, but got O
		//IL_1e07: Expected I4, but got O
		//IL_1e3e: Expected O, but got I4
		//IL_1e4d: Expected I4, but got O
		//IL_1e71: Expected O, but got I4
		//IL_1e7d: Expected I4, but got O
		//IL_1eac: Expected I4, but got O
		//IL_1eb8: Expected O, but got I4
		//IL_1ec4: Expected I4, but got O
		//IL_1eee: Expected I4, but got O
		//IL_1efa: Expected O, but got I4
		//IL_1f06: Expected I4, but got O
		//IL_1f30: Expected I4, but got O
		//IL_1f3c: Expected O, but got I4
		//IL_1f48: Expected I4, but got O
		//IL_1f72: Expected I4, but got O
		//IL_1f81: Expected O, but got I4
		//IL_1f90: Expected I4, but got O
		//IL_1f98: Expected I4, but got O
		//IL_1fe3: Expected I4, but got O
		//IL_2016: Expected I4, but got O
		//IL_202d: Expected O, but got I4
		//IL_2030: Unknown result type (might be due to invalid IL or missing references)
		//IL_2033: Expected O, but got Unknown
		//IL_203f: Expected O, but got I4
		//IL_2142: Expected O, but got I4
		//IL_217c: Expected O, but got I4
		//IL_2217: Expected O, but got I4
		//IL_2354: Expected O, but got I4
		//IL_23a4: Expected O, but got I4
		//IL_23b2: Expected O, but got I4
		//IL_23c2: Expected I4, but got O
		//IL_23d5: Expected I4, but got O
		//IL_241a: Expected O, but got I4
		//IL_242d: Expected I4, but got O
		//IL_2455: Expected O, but got I4
		//IL_2465: Expected I4, but got O
		//IL_2498: Expected I4, but got O
		//IL_24a6: Expected O, but got I4
		//IL_24b6: Expected I4, but got O
		//IL_24e4: Expected I4, but got O
		//IL_24f2: Expected O, but got I4
		//IL_2502: Expected I4, but got O
		//IL_2530: Expected I4, but got O
		//IL_253e: Expected O, but got I4
		//IL_254e: Expected I4, but got O
		//IL_257c: Expected I4, but got O
		//IL_258d: Expected O, but got I4
		//IL_25a0: Expected I4, but got O
		//IL_25aa: Expected I4, but got O
		//IL_2603: Expected I4, but got O
		//IL_263e: Expected I4, but got O
		//IL_2655: Expected O, but got I4
		//IL_265a: Unknown result type (might be due to invalid IL or missing references)
		//IL_265f: Expected O, but got Unknown
		//IL_266f: Expected O, but got I4
		//IL_268b: Expected O, but got I4
		//IL_26a1: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace((string)changerUID);
			if (val != null)
			{
				changerUID = (T2)frmMain.listFBEntity[indexEntity].UID;
			}
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			if (MFacebook != null)
			{
				T2 val3 = (T2)"";
				T2 val4 = (T2)"";
				T4 enumerator = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
					{
						ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
						T2 str = (T2)current.str1;
						T2 val5 = (T2)("fetch_" + (string)str);
						T2 str2 = (T2)current.str2;
						T2 str3 = (T2)current.str3;
						T2 val6 = (T2)((string)str3).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 value = (T2)((string)str3).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val7 = (T2)((string)str3).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 value2 = (T2)((string)str3).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 val8 = (T2)((string)str3).Split((char[])(object)new T8[1] { (T8)124 })[4];
						val8 = (T2)((string)val8).Replace(" ", "%20");
						T2 value3 = (T2)((string)val6).Substring(0, 6);
						T2 value4 = (T2)((string)val6).Substring(((string)val6).Length - 4, 4);
						T0 val9 = (T0)(((string)val7).Length == 2);
						if (val9 != null)
						{
							val7 = (T2)("20" + (string)val7);
						}
						T5 val10 = (T5)Activator.CreateInstance(typeof(T5));
						((Dictionary<string, string>)val10).Add("strUID", (string)changerUID);
						((Dictionary<string, string>)val10).Add("strActId", ((string)str).Replace("act_", ""));
						((Dictionary<string, string>)val10).Add("strCountryCode", (string)str2);
						((Dictionary<string, string>)val10).Add("strNameCard", (string)val8);
						((Dictionary<string, string>)val10).Add("strFirstCard", (string)value3);
						((Dictionary<string, string>)val10).Add("strLastCard", (string)value4);
						((Dictionary<string, string>)val10).Add("strCard", (string)val6);
						((Dictionary<string, string>)val10).Add("strCVV", (string)value2);
						((Dictionary<string, string>)val10).Add("strMonth", (string)value);
						((Dictionary<string, string>)val10).Add("strYear", (string)val7);
						((Dictionary<string, string>)val10).Add("strFB_dtsg", frmMain.listFBEntity[indexEntity].fb_dtsg);
						((Dictionary<string, string>)val10).Add("result", (string)val5);
						T2 resouce = (T2)ResouceControl.getResouce("Add_the_m_facebook_promise", (Dictionary<string, string>)val10);
						val3 = (T2)((string)val3 + (string)resouce);
						val4 = (T2)((string)val4 + (string)val5 + ",");
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
				}
				T3 val11 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val3, val4);
				T0 val12 = (T0)(val11 != null && ((List<object>)val11).Count > 0);
				if (val12 != null)
				{
					T6 val13 = (T6)0;
					while (true)
					{
						T0 val14 = (T0)((nint)val13 < ((List<ListStringData>)listData).Count);
						if (val14 == null)
						{
							break;
						}
						T2 val15 = (T2)((List<object>)val11)[(int)val13].ToString();
						T2 str4 = (T2)((List<ListStringData>)listData)[(int)val13].str3;
						T2 val16 = (T2)((string)str4).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T0 val17 = (T0)((string)val15).Contains(((string)val16).Substring(((string)val16).Length - 4, 4));
						if (val17 != null)
						{
							if (isPlushPrimary != null)
							{
								T2 value5 = (T2)Regex.Match((string)val15, "credential_id\":\"(.*?)\"").Groups[1].Value;
								ListStringData listStringData = new ListStringData();
								listStringData.str1 = ((List<ListStringData>)listData)[(int)val13].str1.Replace("act_", "");
								listStringData.str2 = (string)value5;
								((List<ListStringData>)val2).Add(listStringData);
							}
							((List<ListStringData>)listData)[(int)val13].str4 = frmMain.STATUS.Done.ToString();
						}
						else
						{
							((List<ListStringData>)listData)[(int)val13].str4 = frmMain.STATUS.lỗi.ToString();
							T0 val18 = (T0)((string)val15).Contains("description");
							if (val18 != null)
							{
								((List<ListStringData>)listData)[(int)val13].str5 = Regex.Match((string)val15, "description\":\"(.*?)\",").Groups[1].Value.ToString();
							}
							T0 val19 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val13].str5);
							if (val19 != null)
							{
								((List<ListStringData>)listData)[(int)val13].str5 = Regex.Match((string)val15, "message\":\"(.*?)\",").Groups[1].Value;
							}
							T0 val20 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val13].str5);
							if (val20 != null)
							{
								((List<ListStringData>)listData)[(int)val13].str5 = Regex.Match((string)val15, "summary\":\"(.*?)\",").Groups[1].Value;
							}
						}
						val13 = (T6)(val13 + 1);
					}
					result = (T0)1;
				}
			}
			else if (AddCode != null)
			{
				T2 val21 = (T2)"";
				T2 val22 = (T2)"";
				T4 enumerator2 = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
					{
						ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
						T2 str5 = (T2)current2.str1;
						T2 val23 = (T2)("fetch_" + (string)str5);
						T2 str6 = (T2)current2.str2;
						T2 str7 = (T2)current2.str3;
						T2 val24 = (T2)((string)str7).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 value6 = (T2)((string)str7).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val25 = (T2)((string)str7).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 value7 = (T2)((string)str7).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 value8 = (T2)((string)str7).Split((char[])(object)new T8[1] { (T8)124 })[4];
						T2 value9 = (T2)((string)val24).Substring(0, 6);
						T2 value10 = (T2)((string)val24).Substring(((string)val24).Length - 4, 4);
						T0 val26 = (T0)(((string)val25).Length == 2);
						if (val26 != null)
						{
							val25 = (T2)("20" + (string)val25);
						}
						T5 val27 = (T5)Activator.CreateInstance(typeof(T5));
						((Dictionary<string, string>)val27).Add("strCountryCode", (string)str6);
						((Dictionary<string, string>)val27).Add("strName", (string)value8);
						((Dictionary<string, string>)val27).Add("strCard", (string)val24);
						((Dictionary<string, string>)val27).Add("strCVV", (string)value7);
						((Dictionary<string, string>)val27).Add("strMonth", (string)value6);
						((Dictionary<string, string>)val27).Add("strYear", (string)val25);
						((Dictionary<string, string>)val27).Add("strUID", (string)changerUID);
						((Dictionary<string, string>)val27).Add("strCredit_card_last_4", (string)value10);
						((Dictionary<string, string>)val27).Add("strCredit_card_first_6", (string)value9);
						((Dictionary<string, string>)val27).Add("strAct", ((string)str5).Replace("act_", ""));
						((Dictionary<string, string>)val27).Add("result", (string)val23);
						T2 resouce2 = (T2)ResouceControl.getResouce("Add_Card_By_Code_Promise", (Dictionary<string, string>)val27);
						val21 = (T2)((string)val21 + (string)resouce2);
						val22 = (T2)((string)val22 + (string)val23 + ",");
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator2))).Dispose();
				}
				T3 val28 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val21, val22);
				T0 val29 = (T0)(val28 != null && ((List<object>)val28).Count > 0);
				if (val29 != null)
				{
					T6 val30 = (T6)0;
					while (true)
					{
						T0 val31 = (T0)((nint)val30 < ((List<ListStringData>)listData).Count);
						if (val31 == null)
						{
							break;
						}
						T2 val32 = (T2)((List<object>)val28)[(int)val30].ToString();
						T2 str8 = (T2)((List<ListStringData>)listData)[(int)val30].str3;
						T2 val33 = (T2)((string)str8).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T0 val34 = (T0)((string)val32).Contains(((string)val33).Substring(((string)val33).Length - 4, 4));
						if (val34 == null)
						{
							((List<ListStringData>)listData)[(int)val30].str4 = frmMain.STATUS.lỗi.ToString();
							T0 val35 = (T0)((string)val32).Contains("description");
							if (val35 != null)
							{
								((List<ListStringData>)listData)[(int)val30].str5 = Regex.Match((string)val32, "description\":\"(.*?)\",").Groups[1].Value.ToString();
							}
							T0 val36 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val30].str5);
							if (val36 != null)
							{
								((List<ListStringData>)listData)[(int)val30].str5 = Regex.Match((string)val32, "message\":\"(.*?)\",").Groups[1].Value;
							}
							T0 val37 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val30].str5);
							if (val37 != null)
							{
								((List<ListStringData>)listData)[(int)val30].str5 = Regex.Match((string)val32, "summary\":\"(.*?)\",").Groups[1].Value;
							}
						}
						else
						{
							if (isPlushPrimary != null)
							{
								T2 value11 = (T2)Regex.Match((string)val32, "credential_id\":\"(.*?)\"").Groups[1].Value;
								ListStringData listStringData2 = new ListStringData();
								listStringData2.str1 = ((List<ListStringData>)listData)[(int)val30].str1.Replace("act_", "");
								listStringData2.str2 = (string)value11;
								((List<ListStringData>)val2).Add(listStringData2);
							}
							((List<ListStringData>)listData)[(int)val30].str4 = frmMain.STATUS.Done.ToString();
						}
						val30 = (T6)(val30 + 1);
					}
					result = (T0)1;
				}
			}
			else if (isBoospost != null)
			{
				T2 val38 = (T2)"";
				T2 val39 = (T2)"";
				T4 enumerator3 = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator3))->MoveNext())
					{
						ListStringData current3 = ((List<ListStringData>.Enumerator*)(&enumerator3))->Current;
						T2 str9 = (T2)current3.str1;
						T2 val40 = (T2)("fetch_" + (string)str9);
						T2 str10 = (T2)current3.str2;
						T2 str11 = (T2)current3.str3;
						T2 val41 = (T2)((string)str11).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 value12 = (T2)((string)str11).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val42 = (T2)((string)str11).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 value13 = (T2)((string)str11).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 val43 = (T2)((string)str11).Split((char[])(object)new T8[1] { (T8)124 })[4];
						T2 value14 = (T2)((string)val41).Substring(0, 6);
						T2 value15 = (T2)((string)val41).Substring(((string)val41).Length - 4, 4);
						T0 val44 = (T0)(((string)val42).Length == 2);
						if (val44 != null)
						{
							val42 = (T2)("20" + (string)val42);
						}
						T5 val45 = (T5)Activator.CreateInstance(typeof(T5));
						((Dictionary<string, string>)val45).Add("strUID", (string)changerUID);
						((Dictionary<string, string>)val45).Add("strCountryCode", (string)str10);
						T2 value16 = (T2)((string)val43).Replace(" ", "%20");
						((Dictionary<string, string>)val45).Add("strNameCard", (string)value16);
						((Dictionary<string, string>)val45).Add("str6NumFirst", (string)value14);
						((Dictionary<string, string>)val45).Add("str4NumLast", (string)value15);
						((Dictionary<string, string>)val45).Add("strCardNumber", (string)val41);
						((Dictionary<string, string>)val45).Add("strCVV", (string)value13);
						((Dictionary<string, string>)val45).Add("strMonth", (string)value12);
						((Dictionary<string, string>)val45).Add("strYear", (string)val42);
						((Dictionary<string, string>)val45).Add("strAct_Id", ((string)str9).Replace("act_", ""));
						((Dictionary<string, string>)val45).Add("result", (string)val40);
						T2 resouce3 = (T2)ResouceControl.getResouce("Add_the_bostpost_Promise", (Dictionary<string, string>)val45);
						val38 = (T2)((string)val38 + (string)resouce3);
						val39 = (T2)((string)val39 + (string)val40 + ",");
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator3))).Dispose();
				}
				T3 val46 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val38, val39);
				T0 val47 = (T0)(val46 != null && ((List<object>)val46).Count > 0);
				if (val47 != null)
				{
					T6 val48 = (T6)0;
					while (true)
					{
						T0 val49 = (T0)((nint)val48 < ((List<ListStringData>)listData).Count);
						if (val49 == null)
						{
							break;
						}
						T2 val50 = (T2)((List<object>)val46)[(int)val48].ToString();
						T2 str12 = (T2)((List<ListStringData>)listData)[(int)val48].str3;
						T2 val51 = (T2)((string)str12).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T0 val52 = (T0)((string)val50).Contains(((string)val51).Substring(((string)val51).Length - 4, 4));
						if (val52 == null)
						{
							((List<ListStringData>)listData)[(int)val48].str4 = frmMain.STATUS.lỗi.ToString();
							T0 val53 = (T0)((string)val50).Contains("description");
							if (val53 != null)
							{
								((List<ListStringData>)listData)[(int)val48].str5 = Regex.Match((string)val50, "description\":\"(.*?)\",").Groups[1].Value.ToString();
							}
							T0 val54 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val48].str5);
							if (val54 != null)
							{
								((List<ListStringData>)listData)[(int)val48].str5 = Regex.Match((string)val50, "message\":\"(.*?)\",").Groups[1].Value;
							}
							T0 val55 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val48].str5);
							if (val55 != null)
							{
								((List<ListStringData>)listData)[(int)val48].str5 = Regex.Match((string)val50, "summary\":\"(.*?)\",").Groups[1].Value;
							}
						}
						else
						{
							if (isPlushPrimary != null)
							{
								T2 value17 = (T2)Regex.Match((string)val50, "credential_id\":\"(.*?)\"").Groups[1].Value;
								ListStringData listStringData3 = new ListStringData();
								listStringData3.str1 = ((List<ListStringData>)listData)[(int)val48].str1.Replace("act_", "");
								listStringData3.str2 = (string)value17;
								((List<ListStringData>)val2).Add(listStringData3);
							}
							((List<ListStringData>)listData)[(int)val48].str4 = frmMain.STATUS.Done.ToString();
						}
						val48 = (T6)(val48 + 1);
					}
					result = (T0)1;
				}
			}
			else if (isSuite != null)
			{
				T2 val56 = (T2)"";
				T2 val57 = (T2)"";
				T4 enumerator4 = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator4))->MoveNext())
					{
						ListStringData current4 = ((List<ListStringData>.Enumerator*)(&enumerator4))->Current;
						T2 str13 = (T2)current4.str1;
						T2 val58 = (T2)("fetch_" + (string)str13);
						T2 str14 = (T2)current4.str2;
						T2 str15 = (T2)current4.str3;
						T2 val59 = (T2)((string)str15).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 value18 = (T2)((string)str15).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val60 = (T2)((string)str15).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 value19 = (T2)((string)str15).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 val61 = (T2)((string)str15).Split((char[])(object)new T8[1] { (T8)124 })[4];
						T2 value20 = (T2)((string)val59).Substring(0, 6);
						T2 value21 = (T2)((string)val59).Substring(((string)val59).Length - 4, 4);
						T0 val62 = (T0)(((string)val60).Length == 2);
						if (val62 != null)
						{
							val60 = (T2)("20" + (string)val60);
						}
						T5 val63 = (T5)Activator.CreateInstance(typeof(T5));
						((Dictionary<string, string>)val63).Add("strUID", (string)changerUID);
						((Dictionary<string, string>)val63).Add("strCountryCode", (string)str14);
						T2 value22 = (T2)((string)val61).Replace(" ", "%20");
						((Dictionary<string, string>)val63).Add("strNameCard", (string)value22);
						((Dictionary<string, string>)val63).Add("str6NumFirst", (string)value20);
						((Dictionary<string, string>)val63).Add("str4NumLast", (string)value21);
						((Dictionary<string, string>)val63).Add("strCardNumber", (string)val59);
						((Dictionary<string, string>)val63).Add("strCVV", (string)value19);
						((Dictionary<string, string>)val63).Add("strMonth", (string)value18);
						((Dictionary<string, string>)val63).Add("strYear", (string)val60);
						((Dictionary<string, string>)val63).Add("strAct_Id", ((string)str13).Replace("act_", ""));
						((Dictionary<string, string>)val63).Add("result", (string)val58);
						T2 resouce4 = (T2)ResouceControl.getResouce("Add_the_suite_Promise", (Dictionary<string, string>)val63);
						val56 = (T2)((string)val56 + (string)resouce4);
						val57 = (T2)((string)val57 + (string)val58 + ",");
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator4))).Dispose();
				}
				T3 val64 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val56, val57);
				T0 val65 = (T0)(val64 != null && ((List<object>)val64).Count > 0);
				if (val65 != null)
				{
					T6 val66 = (T6)0;
					while (true)
					{
						T0 val67 = (T0)((nint)val66 < ((List<ListStringData>)listData).Count);
						if (val67 == null)
						{
							break;
						}
						T2 val68 = (T2)((List<object>)val64)[(int)val66].ToString();
						T2 str16 = (T2)((List<ListStringData>)listData)[(int)val66].str3;
						T2 val69 = (T2)((string)str16).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T0 val70 = (T0)((string)val68).Contains(((string)val69).Substring(((string)val69).Length - 4, 4));
						if (val70 != null)
						{
							if (isPlushPrimary != null)
							{
								T2 value23 = (T2)Regex.Match((string)val68, "credential_id\":\"(.*?)\"").Groups[1].Value;
								ListStringData listStringData4 = new ListStringData();
								listStringData4.str1 = ((List<ListStringData>)listData)[(int)val66].str1.Replace("act_", "");
								listStringData4.str2 = (string)value23;
								((List<ListStringData>)val2).Add(listStringData4);
							}
							((List<ListStringData>)listData)[(int)val66].str4 = frmMain.STATUS.Done.ToString();
						}
						else
						{
							((List<ListStringData>)listData)[(int)val66].str4 = frmMain.STATUS.lỗi.ToString();
							T0 val71 = (T0)((string)val68).Contains("description");
							if (val71 != null)
							{
								((List<ListStringData>)listData)[(int)val66].str5 = Regex.Match((string)val68, "description\":\"(.*?)\",").Groups[1].Value.ToString();
							}
							T0 val72 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val66].str5);
							if (val72 != null)
							{
								((List<ListStringData>)listData)[(int)val66].str5 = Regex.Match((string)val68, "message\":\"(.*?)\",").Groups[1].Value;
							}
							T0 val73 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val66].str5);
							if (val73 != null)
							{
								((List<ListStringData>)listData)[(int)val66].str5 = Regex.Match((string)val68, "summary\":\"(.*?)\",").Groups[1].Value;
							}
						}
						val66 = (T6)(val66 + 1);
					}
					result = (T0)1;
				}
			}
			else if (isLink1 != null)
			{
				T2 val74 = (T2)"";
				T2 val75 = (T2)"";
				T4 enumerator5 = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator5))->MoveNext())
					{
						ListStringData current5 = ((List<ListStringData>.Enumerator*)(&enumerator5))->Current;
						T2 str17 = (T2)current5.str1;
						T2 val76 = (T2)("fetch_" + (string)str17);
						T2 str18 = (T2)current5.str2;
						T2 str19 = (T2)current5.str3;
						T2 val77 = (T2)((string)str19).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 value24 = (T2)((string)str19).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val78 = (T2)((string)str19).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 value25 = (T2)((string)str19).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 val79 = (T2)((string)str19).Split((char[])(object)new T8[1] { (T8)124 })[4];
						T2 value26 = (T2)((string)val77).Substring(0, 6);
						T2 value27 = (T2)((string)val77).Substring(((string)val77).Length - 4, 4);
						T0 val80 = (T0)(((string)val78).Length == 2);
						if (val80 != null)
						{
							val78 = (T2)("20" + (string)val78);
						}
						T5 val81 = (T5)Activator.CreateInstance(typeof(T5));
						((Dictionary<string, string>)val81).Add("strUID", (string)changerUID);
						((Dictionary<string, string>)val81).Add("strCountryCode", (string)str18);
						T2 value28 = (T2)((string)val79).Replace(" ", "%20");
						((Dictionary<string, string>)val81).Add("strNameCard", (string)value28);
						((Dictionary<string, string>)val81).Add("str6NumFirst", (string)value26);
						((Dictionary<string, string>)val81).Add("str4NumLast", (string)value27);
						((Dictionary<string, string>)val81).Add("strCardNumber", (string)val77);
						((Dictionary<string, string>)val81).Add("strCVV", (string)value25);
						((Dictionary<string, string>)val81).Add("strMonth", (string)value24);
						((Dictionary<string, string>)val81).Add("strYear", (string)val78);
						((Dictionary<string, string>)val81).Add("strAct_Id", ((string)str17).Replace("act_", ""));
						((Dictionary<string, string>)val81).Add("result", (string)val76);
						T2 resouce5 = (T2)ResouceControl.getResouce("Add_the_link1_Promise", (Dictionary<string, string>)val81);
						val74 = (T2)((string)val74 + (string)resouce5);
						val75 = (T2)((string)val75 + (string)val76 + ",");
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator5))).Dispose();
				}
				T3 val82 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val74, val75);
				T0 val83 = (T0)(val82 != null && ((List<object>)val82).Count > 0);
				if (val83 != null)
				{
					T6 val84 = (T6)0;
					while (true)
					{
						T0 val85 = (T0)((nint)val84 < ((List<ListStringData>)listData).Count);
						if (val85 == null)
						{
							break;
						}
						T2 val86 = (T2)((List<object>)val82)[(int)val84].ToString();
						T2 str20 = (T2)((List<ListStringData>)listData)[(int)val84].str3;
						T2 val87 = (T2)((string)str20).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T0 val88 = (T0)((string)val86).Contains(((string)val87).Substring(((string)val87).Length - 4, 4));
						if (val88 == null)
						{
							((List<ListStringData>)listData)[(int)val84].str4 = frmMain.STATUS.lỗi.ToString();
							T0 val89 = (T0)((string)val86).Contains("description");
							if (val89 != null)
							{
								((List<ListStringData>)listData)[(int)val84].str5 = Regex.Match((string)val86, "description\":\"(.*?)\",").Groups[1].Value.ToString();
							}
							T0 val90 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val84].str5);
							if (val90 != null)
							{
								((List<ListStringData>)listData)[(int)val84].str5 = Regex.Match((string)val86, "message\":\"(.*?)\",").Groups[1].Value;
							}
							T0 val91 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val84].str5);
							if (val91 != null)
							{
								((List<ListStringData>)listData)[(int)val84].str5 = Regex.Match((string)val86, "summary\":\"(.*?)\",").Groups[1].Value;
							}
						}
						else
						{
							if (isPlushPrimary != null)
							{
								T2 value29 = (T2)Regex.Match((string)val86, "credential_id\":\"(.*?)\"").Groups[1].Value;
								ListStringData listStringData5 = new ListStringData();
								listStringData5.str1 = ((List<ListStringData>)listData)[(int)val84].str1.Replace("act_", "");
								listStringData5.str2 = (string)value29;
								((List<ListStringData>)val2).Add(listStringData5);
							}
							((List<ListStringData>)listData)[(int)val84].str4 = frmMain.STATUS.Done.ToString();
						}
						val84 = (T6)(val84 + 1);
					}
					result = (T0)1;
				}
			}
			else if (isAPI != null)
			{
				T0 val92 = (T0)(fbApi == null);
				if (val92 != null)
				{
					fbApi = new FacebookApi(frmMain, indexEntity, "", isAuto_Run_Follow: false);
					FBFlow fBFlow = new FBFlow();
					fBFlow.Flow_Name = "Đăng_nhập";
					fBFlow.Filed.Add(new FBFlowField
					{
						key = "Update_User_Agent",
						value = "false",
						type = typeof(T0)
					});
					fBFlow.Filed.Add(new FBFlowField
					{
						key = "Cookie",
						value = "true",
						type = typeof(T0)
					});
					fBFlow.Filed.Add(new FBFlowField
					{
						key = "Cập_nhật_nhóm",
						value = "false",
						type = typeof(T0)
					});
					fBFlow.Filed.Add(new FBFlowField
					{
						key = "Khóa_nhóm",
						value = "false",
						type = typeof(T0)
					});
					fBFlow.Filed.Add(new FBFlowField
					{
						key = "Change_Useragent",
						value = "false",
						type = typeof(T0)
					});
					fbApi.Đăng_nhập<T0, T2, T6, T7>(fBFlow);
				}
				T4 enumerator6 = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator6))->MoveNext())
					{
						ListStringData current6 = ((List<ListStringData>.Enumerator*)(&enumerator6))->Current;
						T2 act = (T2)current6.str1.Replace("act_", "");
						T2 str21 = (T2)current6.str2;
						T2 str22 = (T2)current6.str3;
						T2 val93 = (T2)((string)str22).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 exp_Month = (T2)((string)str22).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val94 = (T2)((string)str22).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 card_Security = (T2)((string)str22).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 bin_mồi = (T2)((string)val93).Substring(0, 6);
						((string)val93).Substring(((string)val93).Length - 4, 4);
						T0 val95 = (T0)(((string)val94).Length == 2);
						if (val95 != null)
						{
							val94 = (T2)("20" + (string)val94);
						}
						CreditCardEntity creditCardEntity = new CreditCardEntity();
						creditCardEntity.Card_Number = (string)val93;
						creditCardEntity.Exp_Month = (string)exp_Month;
						creditCardEntity.Exp_Year = (string)val94;
						creditCardEntity.Card_Security = (string)card_Security;
						T0 val96 = fbApi.addCard<T0, T2, T6, T7, T8, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, (T0)0, (T0)0, act, str21, bin_mồi, creditCardEntity, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0);
						T0 val97 = val96;
						if (val97 == null)
						{
							current6.str4 = frmMain.STATUS.lỗi.ToString();
						}
						else
						{
							current6.str4 = frmMain.STATUS.Done.ToString();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator6))).Dispose();
				}
				result = (T0)1;
			}
			else if (isRequest != null)
			{
				T0 val98 = (T0)(fbApi == null);
				if (val98 != null)
				{
					fbApi = new FacebookApi(frmMain, indexEntity, "", isAuto_Run_Follow: false);
					FBFlow fBFlow2 = new FBFlow();
					fBFlow2.Flow_Name = "Đăng_nhập";
					fBFlow2.Filed.Add(new FBFlowField
					{
						key = "Update_User_Agent",
						value = "false",
						type = typeof(T0)
					});
					fBFlow2.Filed.Add(new FBFlowField
					{
						key = "Cookie",
						value = "true",
						type = typeof(T0)
					});
					fBFlow2.Filed.Add(new FBFlowField
					{
						key = "Cập_nhật_nhóm",
						value = "false",
						type = typeof(T0)
					});
					fBFlow2.Filed.Add(new FBFlowField
					{
						key = "Khóa_nhóm",
						value = "false",
						type = typeof(T0)
					});
					fbApi.Đăng_nhập<T0, T2, T6, T7>(fBFlow2);
				}
				T4 enumerator7 = (T4)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator7))->MoveNext())
					{
						ListStringData current7 = ((List<ListStringData>.Enumerator*)(&enumerator7))->Current;
						T2 act2 = (T2)current7.str1.Replace("act_", "");
						T2 str23 = (T2)current7.str2;
						T2 str24 = (T2)current7.str3;
						T2 val99 = (T2)((string)str24).Split((char[])(object)new T8[1] { (T8)124 })[0];
						T2 exp_Month2 = (T2)((string)str24).Split((char[])(object)new T8[1] { (T8)124 })[1];
						T2 val100 = (T2)((string)str24).Split((char[])(object)new T8[1] { (T8)124 })[2];
						T2 card_Security2 = (T2)((string)str24).Split((char[])(object)new T8[1] { (T8)124 })[3];
						T2 bin_mồi2 = (T2)((string)val99).Substring(0, 6);
						((string)val99).Substring(((string)val99).Length - 4, 4);
						T0 val101 = (T0)(((string)val100).Length == 2);
						if (val101 != null)
						{
							val100 = (T2)("20" + (string)val100);
						}
						CreditCardEntity creditCardEntity2 = new CreditCardEntity();
						creditCardEntity2.Card_Number = (string)val99;
						creditCardEntity2.Exp_Month = (string)exp_Month2;
						creditCardEntity2.Exp_Year = (string)val100;
						creditCardEntity2.Card_Security = (string)card_Security2;
						T0 val102 = fbApi.addCard<T0, T2, T6, T7, T8, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, (T0)0, (T0)0, act2, str23, bin_mồi2, creditCardEntity2, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
						T0 val103 = val102;
						if (val103 == null)
						{
							current7.str4 = frmMain.STATUS.lỗi.ToString();
						}
						else
						{
							current7.str4 = frmMain.STATUS.Done.ToString();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator7))).Dispose();
				}
				result = (T0)1;
			}
			else if (MFacebook2 == null)
			{
				if (isPro5 != null)
				{
					T2 val104 = (T2)"";
					T2 val105 = (T2)"";
					T4 enumerator8 = (T4)((List<ListStringData>)listData).GetEnumerator();
					try
					{
						while (((List<ListStringData>.Enumerator*)(&enumerator8))->MoveNext())
						{
							ListStringData current8 = ((List<ListStringData>.Enumerator*)(&enumerator8))->Current;
							T2 str25 = (T2)current8.str1;
							T2 val106 = (T2)("fetch_" + (string)str25);
							T2 str26 = (T2)current8.str2;
							T2 str27 = (T2)current8.str3;
							T2 val107 = (T2)((string)str27).Split((char[])(object)new T8[1] { (T8)124 })[0];
							T2 s = (T2)((string)str27).Split((char[])(object)new T8[1] { (T8)124 })[1];
							T2 val108 = (T2)((string)str27).Split((char[])(object)new T8[1] { (T8)124 })[2];
							T2 val109 = (T2)((string)str27).Split((char[])(object)new T8[1] { (T8)124 })[3];
							T2 val110 = (T2)((string)str27).Split((char[])(object)new T8[1] { (T8)124 })[4];
							T2 val111 = (T2)((string)val107).Substring(0, 6);
							T0 val112 = (T0)(!string.IsNullOrWhiteSpace(current8.str6));
							if (val112 != null)
							{
								val111 = (T2)current8.str6;
							}
							T2 val113 = (T2)((string)val107).Substring(((string)val107).Length - 4, 4);
							T0 val114 = (T0)(((string)val108).Length == 2);
							if (val114 != null)
							{
								val108 = (T2)("20" + (string)val108);
							}
							T2 str28 = (T2)string.Concat((string[])(object)new T2[21]
							{
								(T2)"{\"input\":{\"billing_address\":{\"country_code\":\"",
								str26,
								(T2)"\"},\"billing_logging_data\":{\"logging_counter\":22,\"logging_id\":\"3779790846\"},\"cardholder_name\":\"",
								val110,
								(T2)"\",\"credit_card_first_6\":{\"sensitive_string_value\":\"",
								val111,
								(T2)"\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"",
								val113,
								(T2)"\"},\"credit_card_number\":{\"sensitive_string_value\":\"",
								val107,
								(T2)"\"},\"csc\":{\"sensitive_string_value\":\"",
								val109,
								(T2)"\"},\"expiry_month\":\"",
								(T2)System.Runtime.CompilerServices.Unsafe.As<T6, int>(ref (T6)int.Parse((string)s)).ToString(),
								(T2)"\",\"expiry_year\":\"",
								val108,
								(T2)"\",\"payment_account_id\":\"",
								(T2)((string)str25).Replace("act_", ""),
								(T2)"\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true,\"actor_id\":\"",
								changerUID,
								(T2)"\",\"client_mutation_id\":\"6\"}}"
							});
							T2 value30 = (T2)HttpUtility.UrlEncode((string)str28);
							T5 val115 = (T5)Activator.CreateInstance(typeof(T5));
							((Dictionary<string, string>)val115).Add("strVariables", (string)value30);
							((Dictionary<string, string>)val115).Add("strUID", (string)changerUID);
							((Dictionary<string, string>)val115).Add("result", (string)val106);
							T2 resouce6 = (T2)ResouceControl.getResouce("Add_the_pro5_promise", (Dictionary<string, string>)val115);
							val104 = (T2)((string)val104 + (string)resouce6);
							val105 = (T2)((string)val105 + (string)val106 + ",");
						}
					}
					finally
					{
						((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator8))).Dispose();
					}
					T3 val116 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val104, val105);
					T0 val117 = (T0)(val116 != null && ((List<object>)val116).Count > 0);
					if (val117 != null)
					{
						T6 val118 = (T6)0;
						while (true)
						{
							T0 val119 = (T0)((nint)val118 < ((List<ListStringData>)listData).Count);
							if (val119 == null)
							{
								break;
							}
							T2 val120 = (T2)((List<object>)val116)[(int)val118].ToString();
							T2 str29 = (T2)((List<ListStringData>)listData)[(int)val118].str3;
							T2 val121 = (T2)((string)str29).Split((char[])(object)new T8[1] { (T8)124 })[0];
							T0 val122 = (T0)((string)val120).Contains(((string)val121).Substring(((string)val121).Length - 4, 4));
							if (val122 == null)
							{
								((List<ListStringData>)listData)[(int)val118].str4 = frmMain.STATUS.lỗi.ToString();
								T0 val123 = (T0)((string)val120).Contains("description");
								if (val123 != null)
								{
									((List<ListStringData>)listData)[(int)val118].str5 = Regex.Match((string)val120, "description\":\"(.*?)\",").Groups[1].Value.ToString();
								}
								T0 val124 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val118].str5);
								if (val124 != null)
								{
									((List<ListStringData>)listData)[(int)val118].str5 = Regex.Match((string)val120, "errorDescription\":\"(.*?)\",").Groups[1].Value;
								}
								T0 val125 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val118].str5);
								if (val125 != null)
								{
									((List<ListStringData>)listData)[(int)val118].str5 = Regex.Match((string)val120, "message\":\"(.*?)\",").Groups[1].Value;
								}
								T0 val126 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val118].str5);
								if (val126 != null)
								{
									((List<ListStringData>)listData)[(int)val118].str5 = Regex.Match((string)val120, "summary\":\"(.*?)\",").Groups[1].Value;
								}
								T0 val127 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val118].str5));
								if (val127 != null)
								{
									((List<ListStringData>)listData)[(int)val118].str5 = Regex.Unescape(((List<ListStringData>)listData)[(int)val118].str5);
								}
							}
							else
							{
								if (isPlushPrimary != null)
								{
									T2 value31 = (T2)Regex.Match((string)val120, "credential_id\":\"(.*?)\"").Groups[1].Value;
									ListStringData listStringData6 = new ListStringData();
									listStringData6.str1 = ((List<ListStringData>)listData)[(int)val118].str1.Replace("act_", "");
									listStringData6.str2 = (string)value31;
									((List<ListStringData>)val2).Add(listStringData6);
								}
								((List<ListStringData>)listData)[(int)val118].str4 = frmMain.STATUS.Done.ToString();
								result = (T0)1;
							}
							val118 = (T6)(val118 + 1);
						}
					}
				}
				else
				{
					T2 val128 = (T2)"";
					T2 val129 = (T2)"";
					T4 enumerator9 = (T4)((List<ListStringData>)listData).GetEnumerator();
					try
					{
						while (((List<ListStringData>.Enumerator*)(&enumerator9))->MoveNext())
						{
							ListStringData current9 = ((List<ListStringData>.Enumerator*)(&enumerator9))->Current;
							T2 str30 = (T2)current9.str1;
							T2 val130 = (T2)("fetch_" + (string)str30);
							T2 str31 = (T2)current9.str2;
							T2 str32 = (T2)current9.str3;
							T2 val131 = (T2)((string)str32).Split((char[])(object)new T8[1] { (T8)124 })[0];
							T2 s2 = (T2)((string)str32).Split((char[])(object)new T8[1] { (T8)124 })[1];
							T2 val132 = (T2)((string)str32).Split((char[])(object)new T8[1] { (T8)124 })[2];
							T2 val133 = (T2)((string)str32).Split((char[])(object)new T8[1] { (T8)124 })[3];
							T2 val134 = (T2)((string)str32).Split((char[])(object)new T8[1] { (T8)124 })[4];
							T2 val135 = (T2)((string)val131).Substring(0, 6);
							T0 val136 = (T0)(!string.IsNullOrWhiteSpace(current9.str6));
							if (val136 != null)
							{
								val135 = (T2)current9.str6;
							}
							T2 val137 = (T2)((string)val131).Substring(((string)val131).Length - 4, 4);
							T0 val138 = (T0)(((string)val132).Length == 2);
							if (val138 != null)
							{
								val132 = (T2)("20" + (string)val132);
							}
							T2 str33 = (T2)string.Concat((string[])(object)new T2[21]
							{
								(T2)"{\"input\":{\"billing_address\":{\"country_code\":\"",
								str31,
								(T2)"\"},\"billing_logging_data\":{\"logging_counter\":1,\"logging_id\":\"1\"},\"cardholder_name\":\"",
								val134,
								(T2)"\",\"credit_card_first_6\":{\"sensitive_string_value\":\"",
								val135,
								(T2)"\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"",
								val137,
								(T2)"\"},\"credit_card_number\":{\"sensitive_string_value\":\"",
								val131,
								(T2)"\"},\"csc\":{\"sensitive_string_value\":\"",
								val133,
								(T2)"\"},\"expiry_month\":\"",
								(T2)System.Runtime.CompilerServices.Unsafe.As<T6, int>(ref (T6)int.Parse((string)s2)).ToString(),
								(T2)"\",\"expiry_year\":\"",
								val132,
								(T2)"\",\"payment_account_id\":\"",
								(T2)((string)str30).Replace("act_", ""),
								(T2)"\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true,\"actor_id\":\"",
								changerUID,
								(T2)"\",\"client_mutation_id\":\"3\"}}"
							});
							T2 value32 = (T2)HttpUtility.UrlEncode((string)str33);
							T5 val139 = (T5)Activator.CreateInstance(typeof(T5));
							if (Link667 != null)
							{
								((Dictionary<string, string>)val139).Add("\"referrer\": \"https://www.facebook.com/\"", "\"referrer\": \"https://www.facebook.com/help/contact/649167531904667\"");
							}
							((Dictionary<string, string>)val139).Add("strVariables", (string)value32);
							((Dictionary<string, string>)val139).Add("result", (string)val130);
							((Dictionary<string, string>)val139).Add("\"+uid+\"", (string)changerUID);
							T2 resouce7 = (T2)ResouceControl.getResouce("Add_the_promise", (Dictionary<string, string>)val139);
							val128 = (T2)((string)val128 + (string)resouce7);
							val129 = (T2)((string)val129 + (string)val130 + ",");
						}
					}
					finally
					{
						((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator9))).Dispose();
					}
					T0 val140 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business."));
					if (val140 != null)
					{
						val128 = (T2)((string)val128).Replace("business.", "");
					}
					val128 = (T2)((string)val128).Replace("business.secure", "secure");
					T3 val141 = executeScript_Promise<T3, T2, IJavaScriptExecutor, ICollection<object>, T0, T7, T8, object>(val128, val129);
					T0 val142 = (T0)(val141 != null && ((List<object>)val141).Count > 0);
					if (val142 != null)
					{
						T6 val143 = (T6)0;
						while (true)
						{
							T0 val144 = (T0)((nint)val143 < ((List<ListStringData>)listData).Count);
							if (val144 == null)
							{
								break;
							}
							T2 val145 = (T2)((List<object>)val141)[(int)val143].ToString();
							T2 str34 = (T2)((List<ListStringData>)listData)[(int)val143].str3;
							T2 val146 = (T2)((string)str34).Split((char[])(object)new T8[1] { (T8)124 })[0];
							T0 val147 = (T0)((string)val145).Contains(((string)val146).Substring(((string)val146).Length - 4, 4));
							if (val147 == null)
							{
								((List<ListStringData>)listData)[(int)val143].str4 = frmMain.STATUS.lỗi.ToString();
								T0 val148 = (T0)((string)val145).Contains("description");
								if (val148 != null)
								{
									((List<ListStringData>)listData)[(int)val143].str5 = Regex.Match((string)val145, "description\":\"(.*?)\",").Groups[1].Value.ToString();
								}
								T0 val149 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val143].str5);
								if (val149 != null)
								{
									((List<ListStringData>)listData)[(int)val143].str5 = Regex.Match((string)val145, "errorDescription\":\"(.*?)\",").Groups[1].Value;
								}
								T0 val150 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val143].str5);
								if (val150 != null)
								{
									((List<ListStringData>)listData)[(int)val143].str5 = Regex.Match((string)val145, "message\":\"(.*?)\",").Groups[1].Value;
								}
								T0 val151 = (T0)string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val143].str5);
								if (val151 != null)
								{
									((List<ListStringData>)listData)[(int)val143].str5 = Regex.Match((string)val145, "summary\":\"(.*?)\",").Groups[1].Value;
								}
								T0 val152 = (T0)(!string.IsNullOrWhiteSpace(((List<ListStringData>)listData)[(int)val143].str5));
								if (val152 != null)
								{
									((List<ListStringData>)listData)[(int)val143].str5 = Regex.Unescape(((List<ListStringData>)listData)[(int)val143].str5);
								}
							}
							else
							{
								if (isPlushPrimary != null)
								{
									T2 value33 = (T2)Regex.Match((string)val145, "credential_id\":\"(.*?)\"").Groups[1].Value;
									ListStringData listStringData7 = new ListStringData();
									listStringData7.str1 = ((List<ListStringData>)listData)[(int)val143].str1.Replace("act_", "");
									listStringData7.str2 = (string)value33;
									((List<ListStringData>)val2).Add(listStringData7);
								}
								((List<ListStringData>)listData)[(int)val143].str4 = frmMain.STATUS.Done.ToString();
								result = (T0)1;
							}
							val143 = (T6)(val143 + 1);
						}
					}
				}
			}
			T0 val153 = (T0)(isPlushPrimary != null && ((List<ListStringData>)val2).Count > 0);
			if (val153 != null)
			{
				day_the_len_chinh_promise<T0, T2, T3, T4, T5, T7, T1>(val2);
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Xóa_thẻ<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Loại_thẻ").ToString();
			T0 val3 = (T0)((string)val2).Equals("ALL");
			if (val3 != null)
			{
				val2 = (T1)"";
			}
			getFullAdsInfo<T4, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, T6, char, IDisposable, T3, IWebElement>();
			T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					removePaymentMethod<T0, T4, T1, T5, T6>((T1)current.id.Replace("act_", ""), (T1)"");
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
	public unsafe void Add_thẻ_từ_BM<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_014f: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		//IL_02c8: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_02f3: Expected O, but got I4
		//IL_031c: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"API").ToString());
			T1 card_association = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Loại_thẻ").ToString();
			setMessage((T1)"Đẩy_chính_TK_BM", (T0)0);
			T1 strError = (T1)"";
			T2 val3 = mtLoadBM<T7, T1, T0, T2, T6>(out *(string*)(&strError));
			T0 val4 = (T0)(val3 == null || ((List<BusinessManagerEntity_businesses_Data>)val3).Count <= 0);
			if (val4 != null)
			{
				setMessage((T1)"e:Không có BM", (T0)1);
				return;
			}
			T3 enumerator = (T3)((List<BusinessManagerEntity_businesses_Data>)val3).GetEnumerator();
			try
			{
				while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
				{
					BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
					T1 id = (T1)current.id;
					adaccounts fullAdsInfo_In_BM = getFullAdsInfo_In_BM<T1, T7, T0, T5, ReadOnlyCollection<IWebElement>, IEnumerator, Match, char, IDisposable, T6, IWebElement, List<adaccountsData>>(id, (T0)1, (T5)0, (T5)0, (T1)"");
					T0 val5 = (T0)(fullAdsInfo_In_BM != null && fullAdsInfo_In_BM.data != null && fullAdsInfo_In_BM.data.Count > 0);
					if (val5 != null)
					{
						T4 enumerator2 = (T4)fullAdsInfo_In_BM.data.GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
							{
								adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
								T1 act = (T1)current2.id.Replace("act_", "");
								T1 strError2 = (T1)"";
								T5 val6 = (T5)0;
								while (true)
								{
									T0 val7 = (T0)0;
									T0 val8 = val2;
									if (val8 == null)
									{
										val7 = Set_Payment_BM_Cho_Act<T1, T7, T0>(act, id, card_association, out *(string*)(&strError2));
									}
									else
									{
										T0 val9 = (T0)(fbApi == null);
										if (val9 != null)
										{
											fbApi = new FacebookApi(frmMain, indexEntity, "", isAuto_Run_Follow: false);
											FBFlow fBFlow = new FBFlow();
											fBFlow.Flow_Name = "Đăng_nhập";
											fBFlow.Filed.Add(new FBFlowField
											{
												key = "Update_User_Agent",
												value = "false",
												type = typeof(T0)
											});
											fBFlow.Filed.Add(new FBFlowField
											{
												key = "Cookie",
												value = "true",
												type = typeof(T0)
											});
											fBFlow.Filed.Add(new FBFlowField
											{
												key = "Cập_nhật_nhóm",
												value = "false",
												type = typeof(T0)
											});
											fBFlow.Filed.Add(new FBFlowField
											{
												key = "Khóa_nhóm",
												value = "false",
												type = typeof(T0)
											});
											fbApi.Đăng_nhập<T0, T1, T5, T6>(fBFlow);
										}
										val7 = fbApi.Set_Payment_BM_Cho_Act((T0)1, act, id, card_association, out *(string*)(&strError2));
									}
									T0 val10 = (T0)(val7 == null);
									if (val10 != null)
									{
										val6 = (T5)(val6 + 1);
										T0 val11 = (T0)((nint)val6 >= 3);
										if (val11 != null)
										{
											setMessage((T1)"e:Share thẻ lỗi", (T0)1);
											break;
										}
										continue;
									}
									setMessage((T1)"Add thẻ Ok", (T0)1);
									break;
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
					else
					{
						setMessage((T1)"e:Không có TK", (T0)1);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Add_thẻ<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_00da: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_01a9: Expected O, but got I4
		//IL_01c5: Expected O, but got I4
		//IL_01e9: Expected O, but got I4
		//IL_0227: Expected O, but got I4
		//IL_0277: Expected O, but got I4
		//IL_0292: Expected O, but got I4
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0351: Expected O, but got I4
		//IL_0377: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		//IL_03a8: Expected O, but got I4
		//IL_03ab: Expected O, but got I4
		//IL_03ae: Expected O, but got I4
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_03f1: Expected O, but got I4
		//IL_0411: Expected O, but got I4
		//IL_0414: Expected O, but got I4
		//IL_0425: Expected O, but got I4
		//IL_045d: Expected I4, but got O
		//IL_046b: Expected I4, but got O
		//IL_0479: Expected I4, but got O
		//IL_0487: Expected I4, but got O
		//IL_0496: Expected O, but got I4
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_04aa: Expected O, but got I4
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04ce: Expected O, but got I4
		//IL_04db: Expected O, but got I4
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_04fd: Expected O, but got I4
		//IL_0508: Expected O, but got I4
		//IL_0523: Expected O, but got I4
		//IL_0546: Expected O, but got I4
		//IL_055f: Expected O, but got I4
		//IL_056e: Expected O, but got I4
		//IL_0586: Expected O, but got I4
		//IL_05ad: Expected O, but got I4
		//IL_05be: Expected O, but got I4
		//IL_05f4: Expected O, but got I4
		//IL_05f4: Expected O, but got I4
		//IL_05f4: Expected O, but got I4
		//IL_0617: Expected O, but got I4
		//IL_065e: Expected O, but got I4
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Expected O, but got Unknown
		//IL_0670: Expected O, but got I4
		//IL_0677: Expected O, but got I4
		//IL_0691: Expected O, but got I4
		//IL_06ab: Expected O, but got I4
		//IL_06ba: Expected O, but got I4
		//IL_06e3: Expected O, but got I4
		//IL_076f: Expected O, but got I4
		//IL_0776: Expected O, but got I4
		//IL_0782: Expected O, but got I4
		//IL_07b4: Expected O, but got I4
		//IL_07bb: Expected O, but got I4
		//IL_07db: Expected O, but got I4
		//IL_0815: Expected O, but got I4
		//IL_0826: Expected O, but got I4
		//IL_0876: Expected O, but got I4
		//IL_08b5: Expected O, but got I4
		//IL_08f4: Expected O, but got I4
		//IL_0933: Expected O, but got I4
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Expected O, but got Unknown
		//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d6: Expected O, but got Unknown
		//IL_09d9: Expected O, but got I4
		//IL_09dc: Expected O, but got I4
		//IL_09df: Expected O, but got I4
		//IL_09e2: Expected O, but got I4
		//IL_09fd: Expected O, but got I4
		//IL_0a0e: Expected I4, but got O
		//IL_0a15: Expected O, but got I4
		//IL_0a26: Expected O, but got I4
		//IL_0a4c: Expected O, but got I4
		//IL_0a7d: Expected O, but got I4
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8a: Expected O, but got Unknown
		//IL_0aa5: Expected O, but got I4
		//IL_0ab8: Expected O, but got I4
		//IL_0ac9: Expected O, but got I4
		//IL_0ada: Expected O, but got I4
		//IL_0ae8: Expected O, but got I4
		//IL_0b20: Expected I4, but got O
		//IL_0b3a: Expected I4, but got O
		//IL_0b54: Expected I4, but got O
		//IL_0b6e: Expected I4, but got O
		//IL_0bb3: Expected O, but got I4
		//IL_0c17: Expected O, but got I4
		//IL_0c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c21: Expected O, but got Unknown
		//IL_0c31: Expected O, but got I4
		//IL_0c3d: Expected O, but got I4
		//IL_0c4e: Expected O, but got I4
		//IL_0c80: Expected O, but got I4
		//IL_0c98: Expected O, but got I4
		//IL_0cf8: Expected O, but got I4
		//IL_0d32: Expected O, but got I4
		//IL_0df1: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f17: Expected O, but got I4
		//IL_0f2c: Expected O, but got I4
		//IL_0f57: Expected O, but got I4
		//IL_0f94: Expected O, but got I4
		//IL_0fca: Expected O, but got I4
		//IL_0fe4: Expected O, but got I4
		//IL_105e: Expected O, but got I4
		//IL_10ca: Expected O, but got I4
		//IL_1117: Expected O, but got I4
		//IL_117d: Expected O, but got I4
		//IL_11ae: Expected O, but got I4
		//IL_1219: Expected O, but got I4
		//IL_1220: Unknown result type (might be due to invalid IL or missing references)
		//IL_1223: Expected O, but got Unknown
		//IL_1226: Unknown result type (might be due to invalid IL or missing references)
		//IL_1229: Expected O, but got Unknown
		//IL_123d: Expected O, but got I4
		//IL_1268: Expected O, but got I4
		//IL_1379: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1421: Expected O, but got I4
		//IL_1477: Expected O, but got I4
		//IL_14c5: Expected O, but got I4
		//IL_14cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cf: Expected O, but got Unknown
		//IL_14d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d5: Expected O, but got Unknown
		//IL_14e9: Expected O, but got I4
		//IL_1514: Expected O, but got I4
		//IL_1523: Expected O, but got I4
		//IL_1526: Unknown result type (might be due to invalid IL or missing references)
		//IL_1529: Expected O, but got Unknown
		//IL_155f: Expected O, but got I4
		//IL_158a: Expected O, but got I4
		//IL_15c7: Expected O, but got I4
		//IL_15fd: Expected O, but got I4
		//IL_1617: Expected O, but got I4
		//IL_1691: Expected O, but got I4
		//IL_16fd: Expected O, but got I4
		//IL_174a: Expected O, but got I4
		//IL_17b0: Expected O, but got I4
		//IL_17e1: Expected O, but got I4
		//IL_184c: Expected O, but got I4
		//IL_1853: Unknown result type (might be due to invalid IL or missing references)
		//IL_1856: Expected O, but got Unknown
		//IL_1859: Unknown result type (might be due to invalid IL or missing references)
		//IL_185c: Expected O, but got Unknown
		//IL_1870: Expected O, but got I4
		//IL_189b: Expected O, but got I4
		//IL_19d6: Expected O, but got I4
		//IL_1a92: Expected O, but got I4
		//IL_1ada: Expected O, but got I4
		//IL_1af4: Expected O, but got I4
		//IL_1b2d: Expected O, but got I4
		//IL_1b6c: Expected O, but got I4
		//IL_1b96: Expected O, but got I4
		//IL_1b99: Expected O, but got I4
		//IL_1b9c: Expected O, but got I4
		//IL_1b9f: Expected O, but got I4
		//IL_1c13: Expected O, but got I4
		//IL_1c24: Expected I4, but got O
		//IL_1c2b: Expected O, but got I4
		//IL_1c3c: Expected O, but got I4
		//IL_1c62: Expected O, but got I4
		//IL_1c93: Expected O, but got I4
		//IL_1c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca0: Expected O, but got Unknown
		//IL_1cbb: Expected O, but got I4
		//IL_1cce: Expected O, but got I4
		//IL_1cdf: Expected O, but got I4
		//IL_1cf0: Expected O, but got I4
		//IL_1cfe: Expected O, but got I4
		//IL_1d36: Expected I4, but got O
		//IL_1d50: Expected I4, but got O
		//IL_1d6a: Expected I4, but got O
		//IL_1d84: Expected I4, but got O
		//IL_1dbb: Expected O, but got I4
		//IL_1e1f: Expected O, but got I4
		//IL_1e26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e29: Expected O, but got Unknown
		//IL_1e39: Expected O, but got I4
		//IL_1e45: Expected O, but got I4
		//IL_1e56: Expected O, but got I4
		//IL_1e88: Expected O, but got I4
		//IL_1eab: Expected O, but got I4
		//IL_1f0b: Expected O, but got I4
		//IL_1f45: Expected O, but got I4
		//IL_2004: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_212d: Expected O, but got I4
		//IL_2142: Expected O, but got I4
		//IL_216d: Expected O, but got I4
		//IL_21aa: Expected O, but got I4
		//IL_21e0: Expected O, but got I4
		//IL_21fa: Expected O, but got I4
		//IL_2274: Expected O, but got I4
		//IL_22e0: Expected O, but got I4
		//IL_232d: Expected O, but got I4
		//IL_2393: Expected O, but got I4
		//IL_23c4: Expected O, but got I4
		//IL_242f: Expected O, but got I4
		//IL_2436: Unknown result type (might be due to invalid IL or missing references)
		//IL_2439: Expected O, but got Unknown
		//IL_243c: Unknown result type (might be due to invalid IL or missing references)
		//IL_243f: Expected O, but got Unknown
		//IL_2453: Expected O, but got I4
		//IL_247e: Expected O, but got I4
		//IL_258f: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_263a: Expected O, but got I4
		//IL_267b: Expected O, but got I4
		//IL_26aa: Expected O, but got I4
		//IL_2778: Expected O, but got I4
		//IL_27d3: Expected O, but got I4
		//IL_2869: Expected O, but got I4
		//IL_291e: Expected O, but got I4
		//IL_2976: Expected O, but got I4
		//IL_297f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2982: Expected O, but got Unknown
		//IL_2985: Unknown result type (might be due to invalid IL or missing references)
		//IL_2988: Expected O, but got Unknown
		//IL_299e: Expected O, but got I4
		//IL_29cd: Expected O, but got I4
		//IL_29de: Expected O, but got I4
		//IL_29e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e4: Expected O, but got Unknown
		//IL_2a20: Expected O, but got I4
		//IL_2a4f: Expected O, but got I4
		//IL_2aa0: Expected O, but got I4
		//IL_2ae4: Expected O, but got I4
		//IL_2b04: Expected O, but got I4
		//IL_2b8c: Expected O, but got I4
		//IL_2c0a: Expected O, but got I4
		//IL_2c65: Expected O, but got I4
		//IL_2ce0: Expected O, but got I4
		//IL_2d19: Expected O, but got I4
		//IL_2d8c: Expected O, but got I4
		//IL_2d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d98: Expected O, but got Unknown
		//IL_2d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d9e: Expected O, but got Unknown
		//IL_2db4: Expected O, but got I4
		//IL_2de3: Expected O, but got I4
		//IL_2f3a: Expected O, but got I4
		//IL_2fed: Expected O, but got I4
		//IL_301e: Expected O, but got I4
		//IL_3068: Expected O, but got I4
		//IL_3094: Expected O, but got I4
		//IL_30f7: Expected O, but got I4
		//IL_316b: Expected O, but got I4
		//IL_31ac: Expected O, but got I4
		//IL_31d4: Expected O, but got I4
		//IL_3224: Expected I4, but got O
		//IL_3240: Expected I4, but got O
		//IL_325c: Expected I4, but got O
		//IL_3278: Expected I4, but got O
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32bd: Expected O, but got I4
		//IL_32cc: Expected O, but got I4
		//IL_32d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_32dc: Expected O, but got Unknown
		//IL_32ea: Expected O, but got I4
		//IL_3307: Expected O, but got I4
		//IL_331f: Expected O, but got I4
		//IL_332e: Expected O, but got I4
		//IL_334b: Expected O, but got I4
		//IL_3379: Expected O, but got I4
		//IL_3417: Expected O, but got I4
		//IL_348b: Expected O, but got I4
		//IL_34cc: Expected O, but got I4
		//IL_34f4: Expected O, but got I4
		//IL_3544: Expected I4, but got O
		//IL_3560: Expected I4, but got O
		//IL_357c: Expected I4, but got O
		//IL_3598: Expected I4, but got O
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35dd: Expected O, but got I4
		//IL_35ec: Expected O, but got I4
		//IL_35f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_35fc: Expected O, but got Unknown
		//IL_360a: Expected O, but got I4
		//IL_3627: Expected O, but got I4
		//IL_363f: Expected O, but got I4
		//IL_364e: Expected O, but got I4
		//IL_366b: Expected O, but got I4
		//IL_36aa: Expected O, but got I4
		//IL_370d: Expected O, but got I4
		//IL_3781: Expected O, but got I4
		//IL_37c2: Expected O, but got I4
		//IL_37ea: Expected O, but got I4
		//IL_380b: Expected I4, but got O
		//IL_381b: Expected I4, but got O
		//IL_382b: Expected I4, but got O
		//IL_383b: Expected I4, but got O
		//IL_3854: Expected O, but got I4
		//IL_385f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3864: Expected O, but got Unknown
		//IL_3872: Expected O, but got I4
		//IL_388f: Expected O, but got I4
		//IL_38a7: Expected O, but got I4
		//IL_38b6: Expected O, but got I4
		//IL_38d3: Expected O, but got I4
		//IL_3901: Expected O, but got I4
		//IL_3964: Expected O, but got I4
		//IL_39d8: Expected O, but got I4
		//IL_3a19: Expected O, but got I4
		//IL_3a41: Expected O, but got I4
		//IL_3a62: Expected I4, but got O
		//IL_3a72: Expected I4, but got O
		//IL_3a82: Expected I4, but got O
		//IL_3a92: Expected I4, but got O
		//IL_3aab: Expected O, but got I4
		//IL_3ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3abb: Expected O, but got Unknown
		//IL_3ac9: Expected O, but got I4
		//IL_3ae6: Expected O, but got I4
		//IL_3afe: Expected O, but got I4
		//IL_3b0d: Expected O, but got I4
		//IL_3b2a: Expected O, but got I4
		//IL_3b58: Expected O, but got I4
		//IL_3d2b: Expected O, but got I4
		//IL_3d9f: Expected O, but got I4
		//IL_3de0: Expected O, but got I4
		//IL_3e08: Expected O, but got I4
		//IL_3e26: Expected I4, but got O
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e36: Expected O, but got I4
		//IL_3e45: Expected O, but got I4
		//IL_3e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e55: Expected O, but got Unknown
		//IL_3e63: Expected O, but got I4
		//IL_3e80: Expected O, but got I4
		//IL_3e95: Expected O, but got I4
		//IL_3ea4: Expected O, but got I4
		//IL_3ec1: Expected O, but got I4
		//IL_3ef4: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)0;
			T0 val3 = (T0)(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Chỉ_add_tk_không_thẻ") != null);
			if (val3 != null)
			{
				val2 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Chỉ_add_tk_không_thẻ").ToString());
			}
			T1 val4 = (T1)int.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_lại_khi_lỗi").ToString());
			T2 val5 = (T2)flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Quốc_gia_add_thẻ").ToString();
			T2 strCurrency = (T2)flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Tiền_tệ").ToString();
			T0 val6 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_vào_BM").ToString());
			T0 val7 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_thẻ_từ_BM").ToString());
			T0 val8 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_thẳng_TK").ToString());
			T0 val9 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"M_Facebook").ToString());
			T0 val10 = (T0)0;
			T0 val11 = (T0)(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"M_Facebook_2") != null);
			if (val11 != null)
			{
				val10 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"M_Facebook_2").ToString());
			}
			T0 val12 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Bostpost").ToString());
			T0 val13 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Suite").ToString());
			T0 val14 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"API").ToString());
			T0 val15 = (T0)0;
			T0 val16 = (T0)(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_qua_Pro5") != null);
			if (val16 != null)
			{
				val15 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_qua_Pro5").ToString());
			}
			T2 val17 = (T2)flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Danh_sách_thẻ").ToString();
			T0 val18 = (T0)0;
			T0 val19 = (T0)(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_theo_danh_sách") != null);
			if (val19 != null)
			{
				val18 = (T0)bool.Parse(flow.getValue<T23, List<FBFlowField>, T0, T2>((T2)"Add_theo_danh_sách").ToString());
			}
			T3 val20 = frmMain.listCreditCardEntity<T1, T0, T3, T2>(val17);
			T0 val21 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business."));
			if (val21 != null)
			{
				goUrl<T1, T0, T19, T18, T21, T2>((T2)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			T2 val22 = (T2)"";
			T0 val23 = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Name);
			val22 = (T2)((val23 == null) ? frmMain.listFBEntity[indexEntity].Name.ToUpper() : (((string)getFirstName<T0, T2, T1>()).ToUpper() + " " + ((string)getLastName<T0, T2, T1>()).ToUpper()));
			T0 val24 = (T0)(val20 == null);
			if (val24 != null)
			{
				val20 = (T3)Activator.CreateInstance(typeof(T3));
				T1 val25 = (T1)0;
				while (true)
				{
					T0 val26 = (T0)((nint)val25 < 99);
					if (val26 == null)
					{
						break;
					}
					T2 cardGen = BinGen2Class.getCardGen<T1, T2, CreditCardDetector, T0, Regex, T13, T22, T23>(val17);
					((List<CreditCardEntity>)val20).Add(new CreditCardEntity
					{
						Card_Number = ((string)cardGen).Split((char[])(object)new T22[1] { (T22)124 })[0],
						Exp_Month = ((string)cardGen).Split((char[])(object)new T22[1] { (T22)124 })[1],
						Exp_Year = ((string)cardGen).Split((char[])(object)new T22[1] { (T22)124 })[2],
						Card_Security = ((string)cardGen).Split((char[])(object)new T22[1] { (T22)124 })[3],
						Status = frmMain.STATUS.Ready.ToString(),
						Select = true,
						Row = 1
					});
					val25 = (T1)(val25 + 1);
				}
			}
			T2 strError = (T2)"";
			T0 val27 = val6;
			if (val27 != null)
			{
				setMessage((T2)"Chỉ_Add_vào_BM", (T0)0);
				T2 strError2 = (T2)"";
				T4 val28 = mtLoadBM<T17, T2, T0, T4, T21>(out *(string*)(&strError2));
				T0 val29 = (T0)(val28 == null || ((List<BusinessManagerEntity_businesses_Data>)val28).Count <= 0);
				if (val29 == null)
				{
					T1 val30 = (T1)0;
					T1 val31 = (T1)0;
					T1 val32 = (T1)0;
					T5 enumerator = (T5)((List<BusinessManagerEntity_businesses_Data>)val28).GetEnumerator();
					try
					{
						while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
						{
							BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
							val32 = (T1)(val32 + 1);
							setMessage((T2)$"Add thẻ BM {(T23)(object)val32}/{(T23)(object)(T1)((List<BusinessManagerEntity_businesses_Data>)val28).Count} - Thành công: {(T23)(object)val30} Lỗi: {(T23)(object)val31}", (T0)0);
							T1 val33 = (T1)0;
							T1 indexCard = getIndexCard<T1, T0, T3>(val20);
							T0 val34 = (T0)((nint)indexCard == -1);
							if (val34 == null)
							{
								T2 id = (T2)current.id;
								T2 strPaymentAccountId = Get_Payment_Account_Id_BM<T17, T2, T0>(id);
								while (true)
								{
									T0 val35 = (T0)(addCardToBM<T17, T2, T0, T21, T24>(out *(string*)(&strError), id, strPaymentAccountId, val5, strCurrency, (T2)(((object)val22) ?? ((object)"")), (T2)((List<CreditCardEntity>)val20)[(int)indexCard].Card_Number, (T2)((List<CreditCardEntity>)val20)[(int)indexCard].Card_Security, (T2)((List<CreditCardEntity>)val20)[(int)indexCard].Exp_Month, (T2)((List<CreditCardEntity>)val20)[(int)indexCard].Exp_Year) == null);
									if (val35 != null)
									{
										val33 = (T1)(val33 + 1);
										T0 val36 = (T0)(val33 >= val4);
										if (val36 != null)
										{
											val31 = (T1)(val31 + 1);
											setMessage((T2)$"Add thẻ BM {val32}/{(T1)((List<BusinessManagerEntity_businesses_Data>)val28).Count} lỗi: {strError}", (T0)1);
											break;
										}
										continue;
									}
									val30 = (T1)(val30 + 1);
									setMessage((T2)$"Add thẻ BM {val32}/{(T1)((List<BusinessManagerEntity_businesses_Data>)val28).Count} Ok", (T0)1);
									break;
								}
								continue;
							}
							setMessage((T2)"e:Hết thẻ", (T0)1);
							break;
						}
					}
					finally
					{
						((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
					}
					setMessage((T2)$"Add thẻ BM {(T1)((List<BusinessManagerEntity_businesses_Data>)val28).Count} Thành công: {val30} Lỗi: {val31}", (T0)0);
				}
				else
				{
					setMessage((T2)"e:Không có BM", (T0)1);
				}
			}
			T0 val37 = val7;
			if (val37 != null)
			{
				setMessage((T2)"Đẩy_chính_TK_BM", (T0)0);
				T2 strError3 = (T2)"";
				T4 val38 = mtLoadBM<T17, T2, T0, T4, T21>(out *(string*)(&strError3));
				T0 val39 = (T0)(val38 == null || ((List<BusinessManagerEntity_businesses_Data>)val38).Count <= 0);
				if (val39 != null)
				{
					setMessage((T2)"e:Không có BM", (T0)1);
				}
				else
				{
					T5 enumerator2 = (T5)((List<BusinessManagerEntity_businesses_Data>)val38).GetEnumerator();
					try
					{
						while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							BusinessManagerEntity_businesses_Data current2 = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))->Current;
							T2 id2 = (T2)current2.id;
							adaccounts fullAdsInfo_In_BM = getFullAdsInfo_In_BM<T2, T17, T0, T1, T19, IEnumerator, Match, T22, IDisposable, T21, T18, List<adaccountsData>>(id2, (T0)1, (T1)0, (T1)0, (T2)"");
							T0 val40 = (T0)(fullAdsInfo_In_BM != null && fullAdsInfo_In_BM.data != null && fullAdsInfo_In_BM.data.Count > 0);
							if (val40 != null)
							{
								T6 enumerator3 = (T6)fullAdsInfo_In_BM.data.GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator3))->MoveNext())
									{
										adaccountsData current3 = ((List<adaccountsData>.Enumerator*)(&enumerator3))->Current;
										T2 act = (T2)current3.id.Replace("act_", "");
										strError = (T2)"";
										T1 val41 = (T1)0;
										while (true)
										{
											T0 val42 = (T0)0;
											val42 = Set_Payment_BM_Cho_Act<T2, T17, T0>(act, id2, (T2)"", out *(string*)(&strError));
											T0 val43 = (T0)(val42 == null);
											if (val43 != null)
											{
												val41 = (T1)(val41 + 1);
												T0 val44 = (T0)((nint)val41 >= 3);
												if (val44 != null)
												{
													setMessage((T2)("e:Share thẻ BM lỗi: " + (string)strError), (T0)1);
													break;
												}
												continue;
											}
											setMessage((T2)"Add thẻ BM Ok", (T0)1);
											break;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator3))).Dispose();
								}
							}
							else
							{
								setMessage((T2)"e:Không có TKBM", (T0)1);
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
			}
			T0 val45 = val18;
			if (val45 != null)
			{
				T0 val46 = val15;
				if (val46 != null)
				{
					T7 val47 = mtLoadPage<T7, T2, T0, T21, T17>(out *(string*)(&strError));
					T8 val48 = (T8)Activator.CreateInstance(typeof(T8));
					T9 enumerator4 = (T9)((List<facebook_pagesData>)val47).GetEnumerator();
					try
					{
						while (((List<facebook_pagesData>.Enumerator*)(&enumerator4))->MoveNext())
						{
							facebook_pagesData current4 = ((List<facebook_pagesData>.Enumerator*)(&enumerator4))->Current;
							T0 val49 = (T0)(!string.IsNullOrWhiteSpace(current4.additional_profile_id) && !frmMain.listPro5Used.Contains(current4.additional_profile_id));
							if (val49 == null)
							{
								continue;
							}
							T0 val50 = (T0)0;
							T0 val51 = (T0)(current4.category_list != null);
							if (val51 != null)
							{
								T10 enumerator5 = (T10)current4.category_list.GetEnumerator();
								try
								{
									while (((List<category_list>.Enumerator*)(&enumerator5))->MoveNext())
									{
										category_list current5 = ((List<category_list>.Enumerator*)(&enumerator5))->Current;
										T0 val52 = (T0)current5.id.Equals("1603");
										if (val52 != null)
										{
											val50 = (T0)1;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<category_list>.Enumerator*)(&enumerator5))).Dispose();
								}
							}
							T0 val53 = (T0)(val50 == null);
							if (val53 != null)
							{
								((List<string>)val48).Add(current4.additional_profile_id);
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator4))).Dispose();
					}
					T0 val54 = (T0)(((List<string>)val48).Count == 0);
					if (val54 != null)
					{
						setMessage((T2)"Không có page", (T0)1);
						return;
					}
					T11 enumerator6 = (T11)((List<string>)val48).GetEnumerator();
					try
					{
						while (((List<string>.Enumerator*)(&enumerator6))->MoveNext())
						{
							T2 current6 = (T2)((List<string>.Enumerator*)(&enumerator6))->Current;
							frmMain.listPro5Used.Add((string)current6);
							T0 val55 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("usida") != null);
							if (val55 != null)
							{
								((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("usida");
							}
							T0 val56 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("m_pixel_ratio") != null);
							if (val56 != null)
							{
								((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("m_pixel_ratio");
							}
							T0 val57 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("i_user") != null);
							if (val57 != null)
							{
								((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("i_user");
							}
							T0 val58 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("m_page_voice") != null);
							if (val58 != null)
							{
								((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("m_page_voice");
							}
							((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie("i_user", (string)current6, ".facebook.com", "/", (DateTime?)((DateTime)(T13)DateTime.Now).AddYears(1)));
							((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie("m_page_voice", (string)current6, ".facebook.com", "/", (DateTime?)((DateTime)(T13)DateTime.Now).AddYears(1)));
							T1 val59 = (T1)0;
							T1 val60 = (T1)0;
							T1 val61 = (T1)0;
							T1 val62 = (T1)0;
							T12 val63 = (T12)Activator.CreateInstance(typeof(T12));
							T0 val124;
							do
							{
								((List<ListStringData>)val63).Clear();
								T1 val64 = (T1)0;
								while (true)
								{
									T0 val65 = (T0)((nint)val64 < frmMain.actList.Count);
									if (val65 == null)
									{
										break;
									}
									ActControl actControl = frmMain.actList[(int)val64];
									while (true)
									{
										T0 val66 = (T0)(!frmActControl.isActive && frmMain.isRunning);
										if (val66 == null)
										{
											break;
										}
										setMessage((T2)"Add thẻ lỗi! đang dừng", (T0)0);
										Thread.Sleep(3000);
									}
									T0 val67 = (T0)(!frmMain.isRunning);
									if (val67 != null)
									{
										break;
									}
									T0 val68 = (T0)(actControl.Status != null && actControl.Status.Equals(frmMain.STATUS.Ready.ToString()));
									if (val68 != null)
									{
										val59 = (T1)(val59 + 1);
										actControl.Status = frmMain.STATUS.Processing.ToString();
										T1 val69 = (T1)(-1);
										while (true)
										{
											T0 val70 = (T0)frmMain.isRunning;
											if (val70 == null)
											{
												break;
											}
											val69 = getIndexCard<T1, T0, T3>(val20);
											T0 val71 = (T0)((nint)val69 == -1);
											if (val71 == null)
											{
												break;
											}
											setMessage((T2)"Hết thẻ, hãy add thêm thẻ", (T0)0);
											Thread.Sleep(3000);
										}
										T0 val72 = (T0)(!frmMain.isRunning);
										if (val72 != null)
										{
											break;
										}
										ListStringData listStringData = new ListStringData();
										listStringData.str1 = actControl.Id;
										listStringData.str2 = (string)val5;
										listStringData.str3 = string.Concat((string[])(object)new T2[9]
										{
											(T2)((List<CreditCardEntity>)val20)[(int)val69].Card_Number,
											(T2)"|",
											(T2)((List<CreditCardEntity>)val20)[(int)val69].Exp_Month,
											(T2)"|",
											(T2)((List<CreditCardEntity>)val20)[(int)val69].Exp_Year,
											(T2)"|",
											(T2)((List<CreditCardEntity>)val20)[(int)val69].Card_Security,
											(T2)"|",
											val22
										});
										actControl._Card = listStringData.str3;
										T0 val73 = (T0)(!string.IsNullOrEmpty(frmMain.setting.actControl.txtBin6First));
										if (val73 != null)
										{
											listStringData.str6 = frmMain.setting.actControl.txtBin6First;
										}
										listStringData.obj5 = val64;
										((List<ListStringData>)val63).Add(listStringData);
										T0 val74 = (T0)(((List<ListStringData>)val63).Count >= frmMain.setting.actControl.numThreadActOnVia || (nint)val59 >= frmMain.setting.actControl.numActOnVia);
										if (val74 != null)
										{
											break;
										}
									}
									val64 = (T1)(val64 + 1);
								}
								while (true)
								{
									T0 val75 = (T0)(!frmActControl.isActive && frmMain.isRunning);
									if (val75 == null)
									{
										break;
									}
									setMessage((T2)"Add thẻ lỗi! đang dừng", (T0)0);
									Thread.Sleep(3000);
								}
								T0 val76 = (T0)(frmMain.isRunning && ((List<ListStringData>)val63).Count > 0);
								if (val76 == null)
								{
									break;
								}
								T0 val77 = (T0)frmMain.setting.actControl.cbAddBinBait;
								if (val77 != null)
								{
									T12 val78 = (T12)Activator.CreateInstance(typeof(T12));
									T14 enumerator7 = (T14)((List<ListStringData>)val63).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator7))->MoveNext())
										{
											ListStringData current7 = ((List<ListStringData>.Enumerator*)(&enumerator7))->Current;
											T2 val79 = (T2)"";
											T3 val80 = frmMain.listCreditCardEntity<T1, T0, T3, T2>((T2)frmMain.setting.actControl.txtBinBait);
											T0 val81 = (T0)(val80 != null && ((List<CreditCardEntity>)val80).Count > 0);
											if (val81 != null)
											{
												T15 enumerator8 = (T15)((List<CreditCardEntity>)val80).GetEnumerator();
												try
												{
													while (((List<CreditCardEntity>.Enumerator*)(&enumerator8))->MoveNext())
													{
														CreditCardEntity current8 = ((List<CreditCardEntity>.Enumerator*)(&enumerator8))->Current;
														T0 val82 = (T0)current8.Status.Equals(frmMain.STATUS.Ready.ToString());
														if (val82 != null)
														{
															current8.Status = frmMain.STATUS.Used.ToString();
															val79 = (T2)string.Concat((string[])(object)new T2[7]
															{
																(T2)current8.Card_Number,
																(T2)"|",
																(T2)current8.Exp_Month,
																(T2)"|",
																(T2)current8.Exp_Year,
																(T2)"|",
																(T2)current8.Card_Security
															});
															break;
														}
													}
												}
												finally
												{
													((IDisposable)(*(List<CreditCardEntity>.Enumerator*)(&enumerator8))).Dispose();
												}
											}
											else
											{
												val79 = BinGen2Class.getCardGen<T1, T2, CreditCardDetector, T0, Regex, T13, T22, T23>((T2)frmMain.setting.actControl.txtBinBait);
											}
											T2 val83 = (T2)((string)val79).Split((char[])(object)new T22[1] { (T22)124 })[2];
											T0 val84 = (T0)(((string)val83).Length > 2);
											if (val84 != null)
											{
												val83 = (T2)((string)val83).Substring(((string)val83).Length - 2, 2);
											}
											((List<ListStringData>)val78).Add(new ListStringData
											{
												str1 = current7.str1,
												str2 = frmMain.setting.actControl.txtCountryBait,
												str3 = string.Concat((string[])(object)new T2[9]
												{
													(T2)((string)val79).Split((char[])(object)new T22[1] { (T22)124 })[0],
													(T2)"|",
													(T2)((string)val79).Split((char[])(object)new T22[1] { (T22)124 })[1],
													(T2)"|",
													val83,
													(T2)"|",
													(T2)((string)val79).Split((char[])(object)new T22[1] { (T22)124 })[3],
													(T2)"|",
													val22
												}),
												obj1 = current7.obj5,
												str6 = frmMain.setting.actControl.txtBin6First
											});
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator7))).Dispose();
									}
									addCard_Promise<T0, T12, T2, T25, T14, T17, T1, T21, T22>(val78, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, current6);
									T0 val85 = (T0)(frmMain.setting.actControl.numCheckPayment > 0);
									if (val85 != null)
									{
										Thread.Sleep(frmMain.setting.actControl.numCheckPayment * 1000);
										T0 val86 = (T0)payment_account_Promise_3((List<ListStringData>)val63);
										T0 val87 = val86;
										if (val87 != null)
										{
											T14 enumerator9 = (T14)((List<ListStringData>)val63).GetEnumerator();
											try
											{
												while (((List<ListStringData>.Enumerator*)(&enumerator9))->MoveNext())
												{
													ListStringData current9 = ((List<ListStringData>.Enumerator*)(&enumerator9))->Current;
													T2 val88 = (T2)"";
													T2 val89 = (T2)"";
													T0 val90 = (T0)(current9.obj1 != null);
													if (val90 != null)
													{
														payment_account payment_account = (payment_account)current9.obj1;
														T0 val91 = (T0)(payment_account != null && payment_account.data != null && payment_account.data.billable_account_by_payment_account != null);
														if (val91 != null)
														{
															T0 val92 = (T0)payment_account.data.billable_account_by_payment_account.is_reauth_restricted;
															val89 = (T2)((val92 != null) ? frmMain.STATUS.Không_đủ_tiền.ToString() : frmMain.STATUS.Bình_thường.ToString());
															T0 val93 = (T0)(payment_account.data.billable_account_by_payment_account.billing_payment_account != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null && payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count > 0);
															if (val93 != null)
															{
																T16 enumerator10 = (T16)payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
																try
																{
																	while (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator10))->MoveNext())
																	{
																		ADSPRoject.Data.billing_payment_methods current10 = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator10))->Current;
																		T0 val94 = (T0)(!string.IsNullOrWhiteSpace(current10.usability) && (current10.usability.Equals("UNVERIFIED_OR_PENDING_AUTH") || current10.usability.Equals("UNVERIFIABLE")));
																		if (val94 != null)
																		{
																			val88 = (T2)"Xác minh thẻ - ";
																			break;
																		}
																	}
																}
																finally
																{
																	((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator10))).Dispose();
																}
															}
														}
													}
													T0 val95 = (T0)(current9.obj2 != null && ((string)val89).Equals(frmMain.STATUS.Bình_thường.ToString()));
													if (val95 != null)
													{
														CheckPayment checkPayment = (CheckPayment)current9.obj2;
														T0 val96 = (T0)(checkPayment != null && checkPayment.data != null && checkPayment.data.billable_account_by_asset_id != null && !string.IsNullOrWhiteSpace(checkPayment.data.billable_account_by_asset_id.risk_restricted_state) && checkPayment.data.billable_account_by_asset_id.risk_restricted_state.Equals("ACTIONABLE_PREAUTH_STATE"));
														if (val96 != null)
														{
															val89 = (T2)frmMain.STATUS.Không_đủ_tiền.ToString();
														}
													}
													T0 val97 = (T0)((string)val89).Equals(frmMain.STATUS.Không_đủ_tiền.ToString());
													if (val97 != null)
													{
														T0 val98 = (T0)(string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current9.obj5.ToString())].Status) || !frmMain.actList[int.Parse(current9.obj5.ToString())].Status.Equals(frmMain.STATUS.lỗi.ToString()));
														if (val98 != null)
														{
															val62 = (T1)(val62 + 1);
															val61 = (T1)(val61 + 1);
															T0 val99 = (T0)(frmMain.setting.actControl.numDieNext > 0);
															if (val99 != null)
															{
																frmActControl.CountError++;
																T0 val100 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
																if (val100 != null)
																{
																	frmActControl.isActive = false;
																}
															}
														}
														frmMain.actList[int.Parse(current9.obj5.ToString())].Mồi = "MỒI CHẾT: " + frmMain.STATUS.Không_đủ_tiền.ToString() + ": " + frmMain.actList[int.Parse(current9.obj5.ToString())].Message;
													}
													frmMain.actList[int.Parse(current9.obj5.ToString())].Mồi = (string)val88 + frmMain.actList[int.Parse(current9.obj5.ToString())].Mồi;
												}
											}
											finally
											{
												((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator9))).Dispose();
											}
										}
										else
										{
											T14 enumerator11 = (T14)((List<ListStringData>)val63).GetEnumerator();
											try
											{
												while (((List<ListStringData>.Enumerator*)(&enumerator11))->MoveNext())
												{
													ListStringData current11 = ((List<ListStringData>.Enumerator*)(&enumerator11))->Current;
													T0 val101 = (T0)string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current11.obj5.ToString())].Message);
													if (val101 != null)
													{
														frmMain.actList[int.Parse(current11.obj5.ToString())].Message = "";
													}
													frmMain.actList[int.Parse(current11.obj5.ToString())].Mồi = "MỒI CHẾT: Fail to check payment: " + frmMain.actList[int.Parse(current11.obj5.ToString())].Message;
												}
											}
											finally
											{
												((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator11))).Dispose();
											}
										}
									}
									Thread.Sleep(frmMain.setting.actControl.numDelayBait * 1000);
								}
								addCard_Promise<T0, T12, T2, T25, T14, T17, T1, T21, T22>(val63, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, current6);
								T14 enumerator12 = (T14)((List<ListStringData>)val63).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator12))->MoveNext())
									{
										ListStringData current12 = ((List<ListStringData>.Enumerator*)(&enumerator12))->Current;
										frmMain.actList[int.Parse(current12.obj5.ToString())].Status = Regex.Unescape(current12.str4);
										T0 val102 = (T0)(!string.IsNullOrWhiteSpace(current12.str5));
										if (val102 != null)
										{
											frmMain.actList[int.Parse(current12.obj5.ToString())].Message = Regex.Unescape(current12.str5);
										}
										T0 val103 = (T0)current12.str4.Equals(frmMain.STATUS.Done.ToString());
										if (val103 == null)
										{
											val62 = (T1)(val62 + 1);
											val61 = (T1)(val61 + 1);
											T0 val104 = (T0)(frmMain.setting.actControl.numDieNext > 0);
											if (val104 != null)
											{
												frmActControl.CountError++;
												T0 val105 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
												if (val105 != null)
												{
													frmActControl.isActive = false;
												}
											}
										}
										else
										{
											val62 = (T1)0;
											val60 = (T1)(val60 + 1);
											frmActControl.CountError = 0;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator12))).Dispose();
								}
								T0 val106 = (T0)(frmMain.setting.actControl.numCheckPayment > 0);
								if (val106 != null)
								{
									Thread.Sleep(frmMain.setting.actControl.numCheckPayment * 1000);
									T0 val107 = (T0)payment_account_Promise_3((List<ListStringData>)val63);
									T0 val108 = val107;
									if (val108 != null)
									{
										T14 enumerator13 = (T14)((List<ListStringData>)val63).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator13))->MoveNext())
											{
												ListStringData current13 = ((List<ListStringData>.Enumerator*)(&enumerator13))->Current;
												T2 val109 = (T2)"";
												T2 val110 = (T2)"";
												T0 val111 = (T0)(current13.obj1 != null);
												if (val111 != null)
												{
													payment_account payment_account2 = (payment_account)current13.obj1;
													T0 val112 = (T0)(payment_account2 != null && payment_account2.data != null && payment_account2.data.billable_account_by_payment_account != null);
													if (val112 != null)
													{
														T0 val113 = (T0)payment_account2.data.billable_account_by_payment_account.is_reauth_restricted;
														val110 = (T2)((val113 == null) ? frmMain.STATUS.Bình_thường.ToString() : frmMain.STATUS.Không_đủ_tiền.ToString());
														T0 val114 = (T0)(payment_account2.data.billable_account_by_payment_account.billing_payment_account != null && payment_account2.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null && payment_account2.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count > 0);
														if (val114 != null)
														{
															T16 enumerator14 = (T16)payment_account2.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
															try
															{
																while (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator14))->MoveNext())
																{
																	ADSPRoject.Data.billing_payment_methods current14 = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator14))->Current;
																	T0 val115 = (T0)(!string.IsNullOrWhiteSpace(current14.usability) && (current14.usability.Equals("UNVERIFIED_OR_PENDING_AUTH") || current14.usability.Equals("UNVERIFIABLE")));
																	if (val115 != null)
																	{
																		val109 = (T2)"Xác minh thẻ - ";
																		break;
																	}
																}
															}
															finally
															{
																((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator14))).Dispose();
															}
														}
													}
												}
												T0 val116 = (T0)(current13.obj2 != null && ((string)val110).Equals(frmMain.STATUS.Bình_thường.ToString()));
												if (val116 != null)
												{
													CheckPayment checkPayment2 = (CheckPayment)current13.obj2;
													T0 val117 = (T0)(checkPayment2 != null && checkPayment2.data != null && checkPayment2.data.billable_account_by_asset_id != null && !string.IsNullOrWhiteSpace(checkPayment2.data.billable_account_by_asset_id.risk_restricted_state) && checkPayment2.data.billable_account_by_asset_id.risk_restricted_state.Equals("ACTIONABLE_PREAUTH_STATE"));
													if (val117 != null)
													{
														val110 = (T2)frmMain.STATUS.Không_đủ_tiền.ToString();
													}
												}
												T0 val118 = (T0)((string)val110).Equals(frmMain.STATUS.Không_đủ_tiền.ToString());
												if (val118 != null)
												{
													T0 val119 = (T0)(string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current13.obj5.ToString())].Status) || !frmMain.actList[int.Parse(current13.obj5.ToString())].Status.Equals(frmMain.STATUS.lỗi.ToString()));
													if (val119 != null)
													{
														val62 = (T1)(val62 + 1);
														val61 = (T1)(val61 + 1);
														T0 val120 = (T0)(frmMain.setting.actControl.numDieNext > 0);
														if (val120 != null)
														{
															frmActControl.CountError++;
															T0 val121 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
															if (val121 != null)
															{
																frmActControl.isActive = false;
															}
														}
													}
													frmMain.actList[int.Parse(current13.obj5.ToString())].Message = frmMain.STATUS.Không_đủ_tiền.ToString() + ": " + frmMain.actList[int.Parse(current13.obj5.ToString())].Message;
													frmMain.actList[int.Parse(current13.obj5.ToString())].Status = frmMain.STATUS.lỗi.ToString();
												}
												frmMain.actList[int.Parse(current13.obj5.ToString())].Message = (string)val109 + frmMain.actList[int.Parse(current13.obj5.ToString())].Message;
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator13))).Dispose();
										}
									}
									else
									{
										T14 enumerator15 = (T14)((List<ListStringData>)val63).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator15))->MoveNext())
											{
												ListStringData current15 = ((List<ListStringData>.Enumerator*)(&enumerator15))->Current;
												T0 val122 = (T0)string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current15.obj5.ToString())].Message);
												if (val122 != null)
												{
													frmMain.actList[int.Parse(current15.obj5.ToString())].Message = "";
												}
												frmMain.actList[int.Parse(current15.obj5.ToString())].Message = "Fail to check payment: " + frmMain.actList[int.Parse(current15.obj5.ToString())].Message;
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator15))).Dispose();
										}
									}
								}
								T0 val123 = (T0)((nint)val59 < frmMain.setting.actControl.numActOnVia);
								if (val123 == null)
								{
									break;
								}
								val124 = (T0)(frmMain.setting.actControl.numDieToStop == 0 || (nint)val62 < frmMain.setting.actControl.numDieToStop);
							}
							while (val124 != null);
							setMessage((T2)$"Add thẻ done: {val60} lỗi: {val61}", (T0)1);
						}
					}
					finally
					{
						((IDisposable)(*(List<string>.Enumerator*)(&enumerator6))).Dispose();
					}
					T0 val125 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("i_user") != null);
					if (val125 != null)
					{
						((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("i_user");
					}
					T0 val126 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("m_page_voice") != null);
					if (val126 != null)
					{
						((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("m_page_voice");
					}
					return;
				}
				T1 val127 = (T1)0;
				T1 val128 = (T1)0;
				T1 val129 = (T1)0;
				T1 val130 = (T1)0;
				T0 val131 = val10;
				if (val131 != null)
				{
					T17 val132 = (T17)Activator.CreateInstance(typeof(T17));
					((Dictionary<string, string>)val132).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					T2 resouce = (T2)ResouceControl.getResouce("Bat_m_facebook_add_the", (Dictionary<string, string>)val132);
					executeScript<T2, T20, T1, T0, T23>(resouce);
				}
				T12 val133 = (T12)Activator.CreateInstance(typeof(T12));
				while (true)
				{
					((List<ListStringData>)val133).Clear();
					T1 val134 = (T1)0;
					while (true)
					{
						T0 val135 = (T0)((nint)val134 < frmMain.actList.Count);
						if (val135 == null)
						{
							break;
						}
						ActControl actControl2 = frmMain.actList[(int)val134];
						while (true)
						{
							T0 val136 = (T0)(!frmActControl.isActive && frmMain.isRunning);
							if (val136 == null)
							{
								break;
							}
							setMessage((T2)"Add thẻ lỗi! đang dừng", (T0)0);
							Thread.Sleep(3000);
						}
						T0 val137 = (T0)(!frmMain.isRunning);
						if (val137 != null)
						{
							return;
						}
						T0 val138 = (T0)(actControl2.Status != null && actControl2.Status.Equals(frmMain.STATUS.Ready.ToString()));
						if (val138 != null)
						{
							val127 = (T1)(val127 + 1);
							actControl2.Status = frmMain.STATUS.Processing.ToString();
							T1 val139 = (T1)(-1);
							while (true)
							{
								T0 val140 = (T0)frmMain.isRunning;
								if (val140 == null)
								{
									break;
								}
								val139 = getIndexCard<T1, T0, T3>(val20);
								T0 val141 = (T0)((nint)val139 == -1);
								if (val141 == null)
								{
									break;
								}
								setMessage((T2)"Hết thẻ, hãy add thêm thẻ", (T0)0);
								Thread.Sleep(3000);
							}
							T0 val142 = (T0)(!frmMain.isRunning);
							if (val142 != null)
							{
								break;
							}
							ListStringData listStringData2 = new ListStringData();
							listStringData2.str1 = actControl2.Id;
							listStringData2.str2 = (string)val5;
							listStringData2.str3 = string.Concat((string[])(object)new T2[9]
							{
								(T2)((List<CreditCardEntity>)val20)[(int)val139].Card_Number,
								(T2)"|",
								(T2)((List<CreditCardEntity>)val20)[(int)val139].Exp_Month,
								(T2)"|",
								(T2)((List<CreditCardEntity>)val20)[(int)val139].Exp_Year,
								(T2)"|",
								(T2)((List<CreditCardEntity>)val20)[(int)val139].Card_Security,
								(T2)"|",
								val22
							});
							T0 val143 = (T0)(!string.IsNullOrEmpty(frmMain.setting.actControl.txtBin6First));
							if (val143 != null)
							{
								listStringData2.str6 = frmMain.setting.actControl.txtBin6First;
							}
							listStringData2.obj5 = val134;
							((List<ListStringData>)val133).Add(listStringData2);
							T0 val144 = (T0)(((List<ListStringData>)val133).Count >= frmMain.setting.actControl.numThreadActOnVia || (nint)val127 >= frmMain.setting.actControl.numActOnVia);
							if (val144 != null)
							{
								break;
							}
						}
						val134 = (T1)(val134 + 1);
					}
					while (true)
					{
						T0 val145 = (T0)(!frmActControl.isActive && frmMain.isRunning);
						if (val145 == null)
						{
							break;
						}
						setMessage((T2)"Add thẻ lỗi! đang dừng", (T0)0);
						Thread.Sleep(3000);
					}
					T0 val146 = (T0)(frmMain.isRunning && ((List<ListStringData>)val133).Count > 0);
					if (val146 != null)
					{
						T0 val147 = val8;
						if (val147 != null)
						{
							T0 val148 = (T0)frmMain.setting.actControl.cbAddBinBait;
							if (val148 != null)
							{
								T12 val149 = (T12)Activator.CreateInstance(typeof(T12));
								T14 enumerator16 = (T14)((List<ListStringData>)val133).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator16))->MoveNext())
									{
										ListStringData current16 = ((List<ListStringData>.Enumerator*)(&enumerator16))->Current;
										T2 val150 = (T2)"";
										T3 val151 = frmMain.listCreditCardEntity<T1, T0, T3, T2>((T2)frmMain.setting.actControl.txtBinBait);
										T0 val152 = (T0)(val151 != null && ((List<CreditCardEntity>)val151).Count > 0);
										if (val152 != null)
										{
											T15 enumerator17 = (T15)((List<CreditCardEntity>)val151).GetEnumerator();
											try
											{
												while (((List<CreditCardEntity>.Enumerator*)(&enumerator17))->MoveNext())
												{
													CreditCardEntity current17 = ((List<CreditCardEntity>.Enumerator*)(&enumerator17))->Current;
													T0 val153 = (T0)current17.Status.Equals(frmMain.STATUS.Ready.ToString());
													if (val153 != null)
													{
														current17.Status = frmMain.STATUS.Used.ToString();
														val150 = (T2)string.Concat((string[])(object)new T2[7]
														{
															(T2)current17.Card_Number,
															(T2)"|",
															(T2)current17.Exp_Month,
															(T2)"|",
															(T2)current17.Exp_Year,
															(T2)"|",
															(T2)current17.Card_Security
														});
														break;
													}
												}
											}
											finally
											{
												((IDisposable)(*(List<CreditCardEntity>.Enumerator*)(&enumerator17))).Dispose();
											}
										}
										else
										{
											val150 = BinGen2Class.getCardGen<T1, T2, CreditCardDetector, T0, Regex, T13, T22, T23>((T2)frmMain.setting.actControl.txtBinBait);
										}
										T2 val154 = (T2)((string)val150).Split((char[])(object)new T22[1] { (T22)124 })[2];
										T0 val155 = (T0)(((string)val154).Length > 2);
										if (val155 != null)
										{
											val154 = (T2)((string)val154).Substring(((string)val154).Length - 2, 2);
										}
										((List<ListStringData>)val149).Add(new ListStringData
										{
											str1 = current16.str1,
											str2 = frmMain.setting.actControl.txtCountryBait,
											str3 = string.Concat((string[])(object)new T2[9]
											{
												(T2)((string)val150).Split((char[])(object)new T22[1] { (T22)124 })[0],
												(T2)"|",
												(T2)((string)val150).Split((char[])(object)new T22[1] { (T22)124 })[1],
												(T2)"|",
												val154,
												(T2)"|",
												(T2)((string)val150).Split((char[])(object)new T22[1] { (T22)124 })[3],
												(T2)"|",
												val22
											}),
											obj1 = current16.obj5,
											str6 = frmMain.setting.actControl.txtBin6First
										});
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator16))).Dispose();
								}
								addCard_Promise<T0, T12, T2, T25, T14, T17, T1, T21, T22>(val149, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T2)"");
								T0 val156 = (T0)(frmMain.setting.actControl.numCheckPayment > 0);
								if (val156 != null)
								{
									Thread.Sleep(frmMain.setting.actControl.numCheckPayment * 1000);
									T0 val157 = (T0)payment_account_Promise_3((List<ListStringData>)val133);
									T0 val158 = val157;
									if (val158 != null)
									{
										T14 enumerator18 = (T14)((List<ListStringData>)val133).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator18))->MoveNext())
											{
												ListStringData current18 = ((List<ListStringData>.Enumerator*)(&enumerator18))->Current;
												T2 val159 = (T2)"";
												T2 val160 = (T2)"";
												T0 val161 = (T0)(current18.obj1 != null);
												if (val161 != null)
												{
													payment_account payment_account3 = (payment_account)current18.obj1;
													T0 val162 = (T0)(payment_account3 != null && payment_account3.data != null && payment_account3.data.billable_account_by_payment_account != null);
													if (val162 != null)
													{
														T0 val163 = (T0)payment_account3.data.billable_account_by_payment_account.is_reauth_restricted;
														val160 = (T2)((val163 == null) ? frmMain.STATUS.Bình_thường.ToString() : frmMain.STATUS.Không_đủ_tiền.ToString());
														T0 val164 = (T0)(payment_account3.data.billable_account_by_payment_account.billing_payment_account != null && payment_account3.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null && payment_account3.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count > 0);
														if (val164 != null)
														{
															T16 enumerator19 = (T16)payment_account3.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
															try
															{
																while (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator19))->MoveNext())
																{
																	ADSPRoject.Data.billing_payment_methods current19 = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator19))->Current;
																	T0 val165 = (T0)(!string.IsNullOrWhiteSpace(current19.usability) && (current19.usability.Equals("UNVERIFIED_OR_PENDING_AUTH") || current19.usability.Equals("UNVERIFIABLE")));
																	if (val165 != null)
																	{
																		val159 = (T2)"Xác minh thẻ - ";
																		break;
																	}
																}
															}
															finally
															{
																((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator19))).Dispose();
															}
														}
													}
												}
												T0 val166 = (T0)(current18.obj2 != null && ((string)val160).Equals(frmMain.STATUS.Bình_thường.ToString()));
												if (val166 != null)
												{
													CheckPayment checkPayment3 = (CheckPayment)current18.obj2;
													T0 val167 = (T0)(checkPayment3 != null && checkPayment3.data != null && checkPayment3.data.billable_account_by_asset_id != null && !string.IsNullOrWhiteSpace(checkPayment3.data.billable_account_by_asset_id.risk_restricted_state) && checkPayment3.data.billable_account_by_asset_id.risk_restricted_state.Equals("ACTIONABLE_PREAUTH_STATE"));
													if (val167 != null)
													{
														val160 = (T2)frmMain.STATUS.Không_đủ_tiền.ToString();
													}
												}
												T0 val168 = (T0)((string)val160).Equals(frmMain.STATUS.Không_đủ_tiền.ToString());
												if (val168 != null)
												{
													T0 val169 = (T0)(string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current18.obj5.ToString())].Status) || !frmMain.actList[int.Parse(current18.obj5.ToString())].Status.Equals(frmMain.STATUS.lỗi.ToString()));
													if (val169 != null)
													{
														val130 = (T1)(val130 + 1);
														val129 = (T1)(val129 + 1);
														T0 val170 = (T0)(frmMain.setting.actControl.numDieNext > 0);
														if (val170 != null)
														{
															frmActControl.CountError++;
															T0 val171 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
															if (val171 != null)
															{
																frmActControl.isActive = false;
															}
														}
													}
													frmMain.actList[int.Parse(current18.obj5.ToString())].Mồi = "MỒI CHẾT: " + frmMain.STATUS.Không_đủ_tiền.ToString() + ": " + frmMain.actList[int.Parse(current18.obj5.ToString())].Message;
												}
												frmMain.actList[int.Parse(current18.obj5.ToString())].Mồi = (string)val159 + frmMain.actList[int.Parse(current18.obj5.ToString())].Mồi;
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator18))).Dispose();
										}
									}
									else
									{
										T14 enumerator20 = (T14)((List<ListStringData>)val133).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator20))->MoveNext())
											{
												ListStringData current20 = ((List<ListStringData>.Enumerator*)(&enumerator20))->Current;
												T0 val172 = (T0)string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current20.obj5.ToString())].Message);
												if (val172 != null)
												{
													frmMain.actList[int.Parse(current20.obj5.ToString())].Message = "";
												}
												frmMain.actList[int.Parse(current20.obj5.ToString())].Mồi = "MỒI CHẾT: Fail to check payment: " + frmMain.actList[int.Parse(current20.obj5.ToString())].Message;
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator20))).Dispose();
										}
									}
								}
								Thread.Sleep(frmMain.setting.actControl.numDelayBait * 1000);
							}
							addCard_Promise<T0, T12, T2, T25, T14, T17, T1, T21, T22>(val133, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T2)"");
						}
						else
						{
							T0 val173 = val10;
							if (val173 != null)
							{
								T14 enumerator21 = (T14)((List<ListStringData>)val133).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator21))->MoveNext())
									{
										ListStringData current21 = ((List<ListStringData>.Enumerator*)(&enumerator21))->Current;
										T0 val174 = (T0)((RemoteWebDriver)chrome).Url.Contains("creditcard");
										if (val174 != null)
										{
											T19 val175 = (T19)((RemoteWebDriver)chrome).FindElements(By.Name("adAccountID"));
											T0 val176 = (T0)(val175 != null && ((ReadOnlyCollection<IWebElement>)val175).Count > 0);
											if (val176 != null)
											{
												T20 val177 = (T20)chrome;
												((IJavaScriptExecutor)val177).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", (object[])(object)new T23[3]
												{
													(T23)((IEnumerable<T18>)val175).First(),
													(T23)"value",
													(T23)current21.str1
												});
											}
										}
										else
										{
											goUrl<T1, T0, T19, T18, T21, T2>((T2)("https://m.facebook.com/ads/manage/funding/creditcard/add/?account_id=" + current21.str1));
										}
										T18 val178 = (T18)((RemoteWebDriver)chrome).FindElement(By.Id("credit_card_number"));
										((IWebElement)val178).SendKeys(current21.str3.Split((char[])(object)new T22[1] { (T22)124 })[0]);
										T18 val179 = (T18)((RemoteWebDriver)chrome).FindElement(By.Id("credit_card_month"));
										T2 val180 = (T2)current21.str3.Split((char[])(object)new T22[1] { (T22)124 })[1];
										T0 val181 = (T0)(((string)val180).Length == 1);
										if (val181 != null)
										{
											val180 = (T2)("0" + (string)val180);
										}
										((IWebElement)val179).SendKeys((string)val180);
										T18 val182 = (T18)((RemoteWebDriver)chrome).FindElement(By.Id("credit_card_year"));
										T2 val183 = (T2)current21.str3.Split((char[])(object)new T22[1] { (T22)124 })[2];
										T0 val184 = (T0)(((string)val183).Length == 2);
										if (val184 != null)
										{
											val183 = (T2)("20" + (string)val183);
										}
										((IWebElement)val182).SendKeys((string)val183);
										T18 val185 = (T18)((RemoteWebDriver)chrome).FindElement(By.Id("credit_card_security_code"));
										((IWebElement)val185).SendKeys(current21.str3.Split((char[])(object)new T22[1] { (T22)124 })[3]);
										((IWebElement)val185).SendKeys(Keys.Enter);
										Thread.Sleep(1000);
										current21.str5 = ((RemoteWebDriver)chrome).Url;
										T0 val186 = (T0)((RemoteWebDriver)chrome).Url.Contains("error_code");
										if (val186 != null)
										{
											current21.str4 = frmMain.STATUS.lỗi.ToString();
										}
										else
										{
											current21.str4 = frmMain.STATUS.Done.ToString();
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator21))).Dispose();
								}
							}
						}
						T14 enumerator22 = (T14)((List<ListStringData>)val133).GetEnumerator();
						try
						{
							while (((List<ListStringData>.Enumerator*)(&enumerator22))->MoveNext())
							{
								ListStringData current22 = ((List<ListStringData>.Enumerator*)(&enumerator22))->Current;
								frmMain.actList[int.Parse(current22.obj5.ToString())].Status = Regex.Unescape(current22.str4);
								T0 val187 = (T0)(!string.IsNullOrWhiteSpace(current22.str5));
								if (val187 != null)
								{
									frmMain.actList[int.Parse(current22.obj5.ToString())].Message = Regex.Unescape(current22.str5);
								}
								T0 val188 = (T0)current22.str4.Equals(frmMain.STATUS.Done.ToString());
								if (val188 == null)
								{
									val130 = (T1)(val130 + 1);
									val129 = (T1)(val129 + 1);
									T0 val189 = (T0)(frmMain.setting.actControl.numDieNext > 0);
									if (val189 != null)
									{
										frmActControl.CountError++;
										T0 val190 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
										if (val190 != null)
										{
											frmActControl.isActive = false;
										}
									}
								}
								else
								{
									val130 = (T1)0;
									val128 = (T1)(val128 + 1);
									frmActControl.CountError = 0;
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator22))).Dispose();
						}
						T0 val191 = (T0)(frmMain.setting.actControl.numCheckPayment > 0);
						if (val191 != null)
						{
							Thread.Sleep(frmMain.setting.actControl.numCheckPayment * 1000);
							T0 val192 = (T0)payment_account_Promise_3((List<ListStringData>)val133);
							T0 val193 = val192;
							if (val193 != null)
							{
								T14 enumerator23 = (T14)((List<ListStringData>)val133).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator23))->MoveNext())
									{
										ListStringData current23 = ((List<ListStringData>.Enumerator*)(&enumerator23))->Current;
										T2 val194 = (T2)"";
										T2 val195 = (T2)"";
										T0 val196 = (T0)(current23.obj1 != null);
										if (val196 != null)
										{
											payment_account payment_account4 = (payment_account)current23.obj1;
											T0 val197 = (T0)(payment_account4 != null && payment_account4.data != null && payment_account4.data.billable_account_by_payment_account != null);
											if (val197 != null)
											{
												T0 val198 = (T0)payment_account4.data.billable_account_by_payment_account.is_reauth_restricted;
												val195 = (T2)((val198 != null) ? frmMain.STATUS.Không_đủ_tiền.ToString() : frmMain.STATUS.Bình_thường.ToString());
												T0 val199 = (T0)(payment_account4.data.billable_account_by_payment_account.billing_payment_account != null && payment_account4.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null && payment_account4.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count > 0);
												if (val199 != null)
												{
													T16 enumerator24 = (T16)payment_account4.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
													try
													{
														while (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator24))->MoveNext())
														{
															ADSPRoject.Data.billing_payment_methods current24 = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator24))->Current;
															T0 val200 = (T0)(!string.IsNullOrWhiteSpace(current24.usability) && (current24.usability.Equals("UNVERIFIED_OR_PENDING_AUTH") || current24.usability.Equals("UNVERIFIABLE")));
															if (val200 != null)
															{
																val194 = (T2)"Xác minh thẻ - ";
																break;
															}
														}
													}
													finally
													{
														((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator24))).Dispose();
													}
												}
											}
										}
										T0 val201 = (T0)(current23.obj2 != null && ((string)val195).Equals(frmMain.STATUS.Bình_thường.ToString()));
										if (val201 != null)
										{
											CheckPayment checkPayment4 = (CheckPayment)current23.obj2;
											T0 val202 = (T0)(checkPayment4 != null && checkPayment4.data != null && checkPayment4.data.billable_account_by_asset_id != null && !string.IsNullOrWhiteSpace(checkPayment4.data.billable_account_by_asset_id.risk_restricted_state) && checkPayment4.data.billable_account_by_asset_id.risk_restricted_state.Equals("ACTIONABLE_PREAUTH_STATE"));
											if (val202 != null)
											{
												val195 = (T2)frmMain.STATUS.Không_đủ_tiền.ToString();
											}
										}
										T0 val203 = (T0)((string)val195).Equals(frmMain.STATUS.Không_đủ_tiền.ToString());
										if (val203 != null)
										{
											T0 val204 = (T0)(string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current23.obj5.ToString())].Status) || !frmMain.actList[int.Parse(current23.obj5.ToString())].Status.Equals(frmMain.STATUS.lỗi.ToString()));
											if (val204 != null)
											{
												val130 = (T1)(val130 + 1);
												val129 = (T1)(val129 + 1);
												T0 val205 = (T0)(frmMain.setting.actControl.numDieNext > 0);
												if (val205 != null)
												{
													frmActControl.CountError++;
													T0 val206 = (T0)(frmActControl.CountError >= frmMain.setting.actControl.numDieNext);
													if (val206 != null)
													{
														frmActControl.isActive = false;
													}
												}
											}
											frmMain.actList[int.Parse(current23.obj5.ToString())].Message = frmMain.STATUS.Không_đủ_tiền.ToString() + ": " + frmMain.actList[int.Parse(current23.obj5.ToString())].Message;
											frmMain.actList[int.Parse(current23.obj5.ToString())].Status = frmMain.STATUS.lỗi.ToString();
										}
										frmMain.actList[int.Parse(current23.obj5.ToString())].Message = (string)val194 + frmMain.actList[int.Parse(current23.obj5.ToString())].Message;
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator23))).Dispose();
								}
							}
							else
							{
								T14 enumerator25 = (T14)((List<ListStringData>)val133).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator25))->MoveNext())
									{
										ListStringData current25 = ((List<ListStringData>.Enumerator*)(&enumerator25))->Current;
										T0 val207 = (T0)string.IsNullOrWhiteSpace(frmMain.actList[int.Parse(current25.obj5.ToString())].Message);
										if (val207 != null)
										{
											frmMain.actList[int.Parse(current25.obj5.ToString())].Message = "";
										}
										frmMain.actList[int.Parse(current25.obj5.ToString())].Message = "Fail to check payment: " + frmMain.actList[int.Parse(current25.obj5.ToString())].Message;
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator25))).Dispose();
								}
							}
						}
						T0 val208 = (T0)((nint)val127 < frmMain.setting.actControl.numActOnVia);
						if (val208 != null)
						{
							T0 val209 = (T0)(frmMain.setting.actControl.numDieToStop == 0 || (nint)val130 < frmMain.setting.actControl.numDieToStop);
							if (val209 != null)
							{
								continue;
							}
						}
					}
					setMessage((T2)$"Add thẻ done: {val128} lỗi: {val129}", (T0)1);
					break;
				}
				return;
			}
			getFullAdsInfo<T17, T2, T0, T19, IEnumerator, Match, T1, T22, IDisposable, T21, T18>();
			T0 val210 = val8;
			if (val210 != null)
			{
				setMessage((T2)"Add_thẳng_TK", (T0)0);
				T6 enumerator26 = (T6)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator26))->MoveNext())
					{
						adaccountsData current26 = ((List<adaccountsData>.Enumerator*)(&enumerator26))->Current;
						T2 val211 = (T2)current26.id.Replace("act_", "");
						T0 val212 = (T0)1;
						T0 val213 = val2;
						if (val213 != null)
						{
							ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery = lay_toan_bo_payment_method<T17, T2>(val211);
							T0 val214 = (T0)(billingAMNexusRootQuery != null && billingAMNexusRootQuery.data != null && billingAMNexusRootQuery.data.billable_account_by_payment_account != null && billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
							if (val214 != null)
							{
								T16 enumerator27 = (T16)billingAMNexusRootQuery.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
								try
								{
									if (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator27))->MoveNext())
									{
										_ = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator27))->Current;
										val212 = (T0)0;
									}
								}
								finally
								{
									((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator27))).Dispose();
								}
							}
						}
						T0 val215 = val212;
						if (val215 == null)
						{
							continue;
						}
						T1 val216 = (T1)0;
						while (true)
						{
							T1 indexCard2 = getIndexCard<T1, T0, T3>(val20);
							T0 val217 = (T0)((nint)indexCard2 == -1);
							if (val217 == null)
							{
								T12 val218 = (T12)Activator.CreateInstance(typeof(T12));
								ListStringData listStringData3 = new ListStringData();
								listStringData3.str1 = (string)val211;
								listStringData3.str2 = (string)val5;
								listStringData3.str3 = string.Concat((string[])(object)new T2[9]
								{
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard2].Card_Number,
									(T2)"|",
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard2].Exp_Month,
									(T2)"|",
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard2].Exp_Year,
									(T2)"|",
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard2].Card_Security,
									(T2)"|",
									val22
								});
								((List<ListStringData>)val218).Add(listStringData3);
								T0 val219 = addCard_Promise<T0, T12, T2, T25, T14, T17, T1, T21, T22>(val218, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T2)"");
								T0 val220 = (T0)(val219 == null);
								if (val220 != null)
								{
									val216 = (T1)(val216 + 1);
									T0 val221 = (T0)(val216 >= val4);
									if (val221 != null)
									{
										setMessage((T2)"e:Add thẻ lỗi", (T0)1);
										break;
									}
									continue;
								}
								setMessage((T2)"Add thẻ Ok", (T0)1);
								break;
							}
							setMessage((T2)"e:Hết thẻ", (T0)1);
							goto end_IL_332e;
						}
						continue;
						end_IL_332e:
						break;
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator26))).Dispose();
				}
			}
			T0 val222 = val9;
			if (val222 != null)
			{
				setMessage((T2)"Add_qua_m_facebook", (T0)0);
				T2 fb_dtsg = executeScript<T2, T20, T1, T0, T23>((T2)"var fb_dtsg = require('DTSGInitialData').token; return fb_dtsg;");
				frmMain.listFBEntity[indexEntity].fb_dtsg = (string)fb_dtsg;
				goUrl<T1, T0, T19, T18, T21, T2>((T2)"https://m.facebook.com/settings/framework/msite/payments/?entry_point=bookmark&ref=wizard&_rdr");
				T6 enumerator28 = (T6)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator28))->MoveNext())
					{
						adaccountsData current27 = ((List<adaccountsData>.Enumerator*)(&enumerator28))->Current;
						T2 val223 = (T2)current27.id.Replace("act_", "");
						T0 val224 = (T0)1;
						T0 val225 = val2;
						if (val225 != null)
						{
							ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery2 = lay_toan_bo_payment_method<T17, T2>(val223);
							T0 val226 = (T0)(billingAMNexusRootQuery2 != null && billingAMNexusRootQuery2.data != null && billingAMNexusRootQuery2.data.billable_account_by_payment_account != null && billingAMNexusRootQuery2.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery2.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
							if (val226 != null)
							{
								T16 enumerator29 = (T16)billingAMNexusRootQuery2.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
								try
								{
									if (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator29))->MoveNext())
									{
										_ = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator29))->Current;
										val224 = (T0)0;
									}
								}
								finally
								{
									((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator29))).Dispose();
								}
							}
						}
						T0 val227 = val224;
						if (val227 == null)
						{
							continue;
						}
						T1 val228 = (T1)0;
						while (true)
						{
							T1 indexCard3 = getIndexCard<T1, T0, T3>(val20);
							T0 val229 = (T0)((nint)indexCard3 == -1);
							if (val229 == null)
							{
								T12 val230 = (T12)Activator.CreateInstance(typeof(T12));
								ListStringData listStringData4 = new ListStringData();
								listStringData4.str1 = (string)val223;
								listStringData4.str2 = (string)val5;
								listStringData4.str3 = string.Concat((string[])(object)new T2[9]
								{
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard3].Card_Number,
									(T2)"|",
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard3].Exp_Month,
									(T2)"|",
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard3].Exp_Year,
									(T2)"|",
									(T2)((List<CreditCardEntity>)val20)[(int)indexCard3].Card_Security,
									(T2)"|",
									val22
								});
								((List<ListStringData>)val230).Add(listStringData4);
								T0 val231 = addCard_Promise<T0, T12, T2, T25, T14, T17, T1, T21, T22>(val230, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T2)"");
								T0 val232 = (T0)(val231 == null);
								if (val232 != null)
								{
									val228 = (T1)(val228 + 1);
									T0 val233 = (T0)(val228 >= val4);
									if (val233 != null)
									{
										setMessage((T2)"e:Add thẻ lỗi", (T0)1);
										break;
									}
									continue;
								}
								setMessage((T2)"Add thẻ Ok", (T0)1);
								break;
							}
							setMessage((T2)"e:Hết thẻ", (T0)1);
							goto end_IL_364e;
						}
						continue;
						end_IL_364e:
						break;
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator28))).Dispose();
				}
				goUrl<T1, T0, T19, T18, T21, T2>((T2)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			T0 val234 = val12;
			if (val234 != null)
			{
				setMessage((T2)"Add_qua_Bostpost", (T0)0);
				T6 enumerator30 = (T6)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator30))->MoveNext())
					{
						adaccountsData current28 = ((List<adaccountsData>.Enumerator*)(&enumerator30))->Current;
						T2 val235 = (T2)current28.id.Replace("act_", "");
						T0 val236 = (T0)1;
						T0 val237 = val2;
						if (val237 != null)
						{
							ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery3 = lay_toan_bo_payment_method<T17, T2>(val235);
							T0 val238 = (T0)(billingAMNexusRootQuery3 != null && billingAMNexusRootQuery3.data != null && billingAMNexusRootQuery3.data.billable_account_by_payment_account != null && billingAMNexusRootQuery3.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery3.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
							if (val238 != null)
							{
								T16 enumerator31 = (T16)billingAMNexusRootQuery3.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
								try
								{
									if (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator31))->MoveNext())
									{
										_ = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator31))->Current;
										val236 = (T0)0;
									}
								}
								finally
								{
									((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator31))).Dispose();
								}
							}
						}
						T0 val239 = val236;
						if (val239 == null)
						{
							continue;
						}
						T1 val240 = (T1)0;
						while (true)
						{
							T1 indexCard4 = getIndexCard<T1, T0, T3>(val20);
							T0 val241 = (T0)((nint)indexCard4 == -1);
							if (val241 == null)
							{
								T0 val242 = Add_the_bostpost<T0, T2, T17>(val235, val5, (T2)(((object)val22) ?? ((object)"")), (T2)((List<CreditCardEntity>)val20)[(int)indexCard4].Card_Number, (T2)((List<CreditCardEntity>)val20)[(int)indexCard4].Card_Security, (T2)((List<CreditCardEntity>)val20)[(int)indexCard4].Exp_Month, (T2)((List<CreditCardEntity>)val20)[(int)indexCard4].Exp_Year);
								T0 val243 = (T0)(val242 == null);
								if (val243 != null)
								{
									val240 = (T1)(val240 + 1);
									T0 val244 = (T0)(val240 >= val4);
									if (val244 == null)
									{
										continue;
									}
									setMessage((T2)"e:Add thẻ lỗi", (T0)1);
								}
								else
								{
									setMessage((T2)"Add thẻ Ok", (T0)1);
								}
								goto IL_38b6;
							}
							setMessage((T2)"e:Hết thẻ", (T0)1);
							break;
						}
						break;
						IL_38b6:;
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator30))).Dispose();
				}
			}
			T0 val245 = val13;
			if (val245 != null)
			{
				setMessage((T2)"Add_qua_Suite", (T0)0);
				T6 enumerator32 = (T6)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator32))->MoveNext())
					{
						adaccountsData current29 = ((List<adaccountsData>.Enumerator*)(&enumerator32))->Current;
						T2 val246 = (T2)current29.id.Replace("act_", "");
						T0 val247 = (T0)1;
						T0 val248 = val2;
						if (val248 != null)
						{
							ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery4 = lay_toan_bo_payment_method<T17, T2>(val246);
							T0 val249 = (T0)(billingAMNexusRootQuery4 != null && billingAMNexusRootQuery4.data != null && billingAMNexusRootQuery4.data.billable_account_by_payment_account != null && billingAMNexusRootQuery4.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery4.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
							if (val249 != null)
							{
								T16 enumerator33 = (T16)billingAMNexusRootQuery4.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
								try
								{
									if (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator33))->MoveNext())
									{
										_ = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator33))->Current;
										val247 = (T0)0;
									}
								}
								finally
								{
									((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator33))).Dispose();
								}
							}
						}
						T0 val250 = val247;
						if (val250 == null)
						{
							continue;
						}
						T1 val251 = (T1)0;
						while (true)
						{
							T1 indexCard5 = getIndexCard<T1, T0, T3>(val20);
							T0 val252 = (T0)((nint)indexCard5 == -1);
							if (val252 == null)
							{
								T0 val253 = Add_the_suite<T0, T2, T17>(val246, val5, (T2)(((object)val22) ?? ((object)"")), (T2)((List<CreditCardEntity>)val20)[(int)indexCard5].Card_Number, (T2)((List<CreditCardEntity>)val20)[(int)indexCard5].Card_Security, (T2)((List<CreditCardEntity>)val20)[(int)indexCard5].Exp_Month, (T2)((List<CreditCardEntity>)val20)[(int)indexCard5].Exp_Year);
								T0 val254 = (T0)(val253 == null);
								if (val254 != null)
								{
									val251 = (T1)(val251 + 1);
									T0 val255 = (T0)(val251 >= val4);
									if (val255 == null)
									{
										continue;
									}
									setMessage((T2)"e:Add thẻ lỗi", (T0)1);
								}
								else
								{
									setMessage((T2)"Add thẻ Ok", (T0)1);
								}
								goto IL_3b0d;
							}
							setMessage((T2)"e:Hết thẻ", (T0)1);
							break;
						}
						break;
						IL_3b0d:;
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator32))).Dispose();
				}
			}
			T0 val256 = val14;
			if (val256 == null)
			{
				return;
			}
			setMessage((T2)"Add_qua_API", (T0)0);
			FacebookApi facebookApi = new FacebookApi(frmMain, indexEntity, "", isAuto_Run_Follow: false);
			FBFlow fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Đăng_nhập";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Update_User_Agent",
				value = "false",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Cookie",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Cập_nhật_nhóm",
				value = "false",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Khóa_nhóm",
				value = "false",
				type = typeof(T0)
			});
			facebookApi.Đăng_nhập<T0, T2, T1, T21>(fBFlow);
			T6 enumerator34 = (T6)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator34))->MoveNext())
				{
					adaccountsData current30 = ((List<adaccountsData>.Enumerator*)(&enumerator34))->Current;
					T2 act2 = (T2)current30.id.Replace("act_", "");
					T0 val257 = (T0)1;
					T0 val258 = val2;
					if (val258 != null)
					{
						ADSPRoject.Data.BillingAMNexusRootQuery billingAMNexusRootQuery5 = lay_toan_bo_payment_method<T17, T2>(act2);
						T0 val259 = (T0)(billingAMNexusRootQuery5 != null && billingAMNexusRootQuery5.data != null && billingAMNexusRootQuery5.data.billable_account_by_payment_account != null && billingAMNexusRootQuery5.data.billable_account_by_payment_account.billing_payment_account != null && billingAMNexusRootQuery5.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods != null);
						if (val259 != null)
						{
							T16 enumerator35 = (T16)billingAMNexusRootQuery5.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.GetEnumerator();
							try
							{
								if (((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator35))->MoveNext())
								{
									_ = ((List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator35))->Current;
									val257 = (T0)0;
								}
							}
							finally
							{
								((IDisposable)(*(List<ADSPRoject.Data.billing_payment_methods>.Enumerator*)(&enumerator35))).Dispose();
							}
						}
					}
					T0 val260 = val257;
					if (val260 == null)
					{
						continue;
					}
					T1 val261 = (T1)0;
					while (true)
					{
						T1 indexCard6 = getIndexCard<T1, T0, T3>(val20);
						T0 val262 = (T0)((nint)indexCard6 == -1);
						if (val262 == null)
						{
							T0 val263 = facebookApi.addCard<T0, T2, T1, T21, T22, HttpRequest, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, WebClient, NameValueCollection, byte>((T0)1, (T0)0, (T0)0, act2, val5, (T2)"", ((List<CreditCardEntity>)val20)[(int)indexCard6], (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0);
							T0 val264 = (T0)(val263 == null);
							if (val264 != null)
							{
								val261 = (T1)(val261 + 1);
								T0 val265 = (T0)(val261 >= val4);
								if (val265 != null)
								{
									setMessage((T2)"e:Add thẻ lỗi", (T0)1);
									break;
								}
								continue;
							}
							setMessage((T2)"Add thẻ Ok", (T0)1);
							break;
						}
						setMessage((T2)"e:Hết thẻ", (T0)1);
						return;
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator34))).Dispose();
			}
		}
		catch (Exception ex)
		{
			setMessage((T2)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Add_the_suite<T0, T1, T2>(T1 Act_Id, T1 CountryCode, T1 NameCard, T1 CardNumber, T1 Cvv, T1 Month, T1 Year)
	{
		//IL_0002: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 value = (T1)((string)CardNumber).Substring(0, 6);
			T1 value2 = (T1)((string)CardNumber).Substring(((string)CardNumber).Length - 4, 4);
			T0 val = (T0)(((string)Year).Length == 2);
			if (val != null)
			{
				Year = (T1)("20" + (string)Year);
			}
			T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strCountryCode", (string)CountryCode);
			NameCard = (T1)((string)NameCard).Replace(" ", "%20");
			((Dictionary<string, string>)val2).Add("strNameCard", (string)NameCard);
			((Dictionary<string, string>)val2).Add("str6NumFirst", (string)value);
			((Dictionary<string, string>)val2).Add("str4NumLast", (string)value2);
			((Dictionary<string, string>)val2).Add("strCardNumber", (string)CardNumber);
			((Dictionary<string, string>)val2).Add("strCVV", (string)Cvv);
			((Dictionary<string, string>)val2).Add("strMonth", (string)Month);
			((Dictionary<string, string>)val2).Add("strYear", (string)Year);
			((Dictionary<string, string>)val2).Add("strAct_Id", (string)Act_Id);
			T1 resouce = (T1)ResouceControl.getResouce("Add_the_suite", (Dictionary<string, string>)val2);
			T1 val3 = executeScript<T1, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains((string)value2);
			if (val4 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Add_the_bostpost<T0, T1, T2>(T1 Act_Id, T1 CountryCode, T1 NameCard, T1 CardNumber, T1 Cvv, T1 Month, T1 Year)
	{
		//IL_0002: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 value = (T1)((string)CardNumber).Substring(0, 6);
			T1 value2 = (T1)((string)CardNumber).Substring(((string)CardNumber).Length - 4, 4);
			T0 val = (T0)(((string)Year).Length == 2);
			if (val != null)
			{
				Year = (T1)("20" + (string)Year);
			}
			T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strCountryCode", (string)CountryCode);
			NameCard = (T1)((string)NameCard).Replace(" ", "%20");
			((Dictionary<string, string>)val2).Add("strNameCard", (string)NameCard);
			((Dictionary<string, string>)val2).Add("str6NumFirst", (string)value);
			((Dictionary<string, string>)val2).Add("str4NumLast", (string)value2);
			((Dictionary<string, string>)val2).Add("strCardNumber", (string)CardNumber);
			((Dictionary<string, string>)val2).Add("strCVV", (string)Cvv);
			((Dictionary<string, string>)val2).Add("strMonth", (string)Month);
			((Dictionary<string, string>)val2).Add("strYear", (string)Year);
			((Dictionary<string, string>)val2).Add("strAct_Id", (string)Act_Id);
			T1 resouce = (T1)ResouceControl.getResouce("Add_the_bostpost", (Dictionary<string, string>)val2);
			T1 val3 = executeScript<T1, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains((string)value2);
			if (val4 != null)
			{
				result = (T0)1;
			}
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addCard(string Đổi_quốc_gia, bool VHH_tk_add_thẻ)
	{
		foreach (BMData datum in frmMain.listFBEntity[indexEntity].fullAdsInfo.businesses.data)
		{
			if (datum.owned_ad_accounts == null)
			{
				continue;
			}
			foreach (adaccountsData datum2 in datum.owned_ad_accounts.data)
			{
				if (VHH_tk_add_thẻ)
				{
					account_close<bool, Dictionary<string, string>, string>(datum2.id);
				}
				bool flag = true;
				while (flag && frmMain.isRunning)
				{
					int num = -1;
					for (int i = 0; i < frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("").Count; i++)
					{
						if (frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[i].Status.Equals(frmMain.STATUS.Ready.ToString()))
						{
							num = i;
							frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[i].Status = frmMain.STATUS.Used.ToString();
							break;
						}
					}
					if (num != -1)
					{
						string text = Đổi_quốc_gia;
						if (Đổi_quốc_gia.Contains("_"))
						{
							text = Đổi_quốc_gia.Split('_')[1];
						}
						string text2 = frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Card_Number.Substring(0, 6);
						string text3 = frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Card_Number.Substring(frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Card_Number.Length - 4, 4);
						string text4 = frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Exp_Year;
						if (text4.Length == 2)
						{
							text4 = "20" + text4;
						}
						string str = "{\"input\":{\"billing_address\":{\"country_code\":\"" + text + "\"},\"billing_logging_data\":{\"logging_counter\":1,\"logging_id\":\"1\"},\"cardholder_name\":\"" + frmMain.listFBEntity[indexEntity].Name + "\",\"credit_card_first_6\":{\"sensitive_string_value\":\"" + text2 + "\"},\"credit_card_last_4\":{\"sensitive_string_value\":\"" + text3 + "\"},\"credit_card_number\":{\"sensitive_string_value\":\"" + frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Card_Number + "\"},\"csc\":{\"sensitive_string_value\":\"" + frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Card_Security + "\"},\"expiry_month\":\"" + int.Parse(frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Exp_Month) + "\",\"expiry_year\":\"" + text4 + "\",\"payment_account_id\":\"" + datum2.id.Replace("act_", "") + "\",\"payment_type\":\"MOR_ADS_INVOICE\",\"unified_payments_api\":true,\"actor_id\":\"" + frmMain.listFBEntity[indexEntity].UID + "\",\"client_mutation_id\":\"3\"}}";
						string value = HttpUtility.UrlEncode(str);
						try
						{
							Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
							dictionary.Add("strVariables", value);
							string resouce = ResouceControl.getResouce("Add_the", dictionary);
							string text5 = executeScript<string, IJavaScriptExecutor, int, bool, object>(resouce);
							if (!text5.Contains("declined") && !text5.Contains("inactive or has been disabled"))
							{
								flag = false;
							}
							else
							{
								frmMain.listCreditCardEntity<int, bool, List<CreditCardEntity>, string>("")[num].Status = frmMain.STATUS.Declined.ToString();
							}
						}
						catch
						{
						}
					}
					else
					{
						frmMain.SetCellText<bool, int, string>(indexEntity, "Message", "Hết thẻ");
					}
				}
				if (VHH_tk_add_thẻ)
				{
					account_unsettled<bool, Dictionary<string, string>, string>(datum2.id);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Share_page_đối_tác<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_013c: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01cb: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0290: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		//IL_02d4: Expected O, but got I4
		//IL_0390: Expected O, but got I4
		//IL_039a: Expected O, but got I4
		//IL_03ca: Expected O, but got I4
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_0421: Expected O, but got I4
		//IL_04e0: Expected O, but got I4
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_04ed: Expected O, but got I4
		//IL_051b: Expected O, but got I4
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_053e: Expected O, but got I4
		//IL_055e: Expected O, but got I4
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_059d: Expected O, but got I4
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_05af: Expected O, but got I4
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_061a: Expected O, but got I4
		//IL_0637: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business."));
			if (val2 != null)
			{
				goUrl<T3, T0, ReadOnlyCollection<IWebElement>, IWebElement, T9, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			setMessage((T1)"Share page đối tác", (T0)0);
			T1 strError = (T1)"";
			T2 val3 = mtLoadBM<T6, T1, T0, T2, T9>(out *(string*)(&strError));
			T0 val4 = (T0)(val3 == null || ((List<BusinessManagerEntity_businesses_Data>)val3).Count == 0);
			if (val4 != null)
			{
				setMessage((T1)"e:Không có BM", (T0)1);
				return;
			}
			T3 val5 = (T3)0;
			T3 val6 = (T3)0;
			T3 val7 = (T3)0;
			T4 enumerator = (T4)((List<BusinessManagerEntity_businesses_Data>)val3).GetEnumerator();
			try
			{
				while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
				{
					BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
					T1 id = (T1)current.id;
					T3 val8 = (T3)0;
					while (true)
					{
						IL_05a5:
						T0 val9 = (T0)((nint)val8 >= 4);
						if (val9 == null)
						{
							T0 val10 = (T0)0;
							T0 val11 = (T0)0;
							T5 enumerator2 = (T5)frmMain.setting.List_TOKEN_PAGE_PARTNER.GetEnumerator();
							try
							{
								while (((List<TokenEntity>.Enumerator*)(&enumerator2))->MoveNext())
								{
									TokenEntity current2 = ((List<TokenEntity>.Enumerator*)(&enumerator2))->Current;
									T0 val12 = (T0)current2.Status.Equals(frmMain.STATUS.Live.ToString());
									if (val12 == null)
									{
										continue;
									}
									val10 = (T0)1;
									T1[] array = (T1[])(object)frmMain.setting.txtPageID_Partner.Split((char[])(object)new T10[1] { (T10)124 });
									T3 val13 = (T3)0;
									while ((nint)val13 < array.Length)
									{
										T1 val14 = (T1)((object[])(object)array)[(object)val13];
										T0 val15 = (T0)(!string.IsNullOrWhiteSpace((string)val14));
										if (val15 != null)
										{
											T0 val16 = frmMain.tokenPagePartner.Share_Page<T0, T3, T1, T9, HttpRequest>((T1)current2.Token, (T1)frmMain.setting.txtBMID_PagePartner, id, val14, (T1)current2.Cookie, (T0)0, out *(string*)(&strError));
											if (val16 != null)
											{
												val11 = (T0)1;
											}
											else
											{
												current2.Status = frmMain.STATUS.Die.ToString();
											}
										}
										val13 = (T3)(val13 + 1);
									}
									T0 val17 = val11;
									if (val17 != null)
									{
										break;
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator2))).Dispose();
							}
							T0 val18 = (T0)(val10 == null);
							if (val18 == null)
							{
								T0 val19 = (T0)(val11 == null);
								if (val19 == null)
								{
									T6 val20 = (T6)Activator.CreateInstance(typeof(T6));
									((Dictionary<string, string>)val20).Add("strBMID", "\"" + (string)id + "\"");
									((Dictionary<string, string>)val20).Add("strToken", "\"" + frmMain.listFBEntity[indexEntity].TokenEAAG + "\"");
									T1 resouce = (T1)ResouceControl.getResouce("Lay_danh_sach_admin_trong_BM", (Dictionary<string, string>)val20);
									T1 val21 = executeScript<T1, IJavaScriptExecutor, T3, T0, object>(resouce);
									ADSPRoject.Data.business_users business_users = JsonConvert.DeserializeObject<ADSPRoject.Data.business_users>((string)val21);
									T0 val22 = (T0)(business_users == null || business_users.data == null || business_users.data.Count <= 0);
									if (val22 == null)
									{
										T1[] array2 = (T1[])(object)frmMain.setting.txtPageID_Partner.Split((char[])(object)new T10[1] { (T10)124 });
										T3 val23 = (T3)0;
										while ((nint)val23 < array2.Length)
										{
											T1 value = (T1)((object[])(object)array2)[(object)val23];
											T0 val24 = (T0)(!string.IsNullOrWhiteSpace((string)value));
											if (val24 != null)
											{
												try
												{
													T1 val25 = (T1)"";
													val20 = (T6)Activator.CreateInstance(typeof(T6));
													((Dictionary<string, string>)val20).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
													((Dictionary<string, string>)val20).Add("strPageId", (string)value);
													((Dictionary<string, string>)val20).Add("strBMID", (string)id);
													resouce = (T1)ResouceControl.getResouce("lay_quyen_page_bm", (Dictionary<string, string>)val20);
													val21 = executeScript<T1, IJavaScriptExecutor, T3, T0, object>(resouce);
													PermissionTaskPageBM permissionTaskPageBM = JsonConvert.DeserializeObject<PermissionTaskPageBM>((string)val21);
													T0 val26 = (T0)(permissionTaskPageBM != null && permissionTaskPageBM.data != null && permissionTaskPageBM.data.business_object_rendered_in_ui != null && permissionTaskPageBM.data.business_object_rendered_in_ui.available_permission_tasks_ui_configs != null);
													if (val26 != null)
													{
														T3 val27 = (T3)0;
														T7 enumerator3 = (T7)permissionTaskPageBM.data.business_object_rendered_in_ui.available_permission_tasks_ui_configs.GetEnumerator();
														try
														{
															while (((List<available_permission_tasks_ui_configs>.Enumerator*)(&enumerator3))->MoveNext())
															{
																available_permission_tasks_ui_configs current3 = ((List<available_permission_tasks_ui_configs>.Enumerator*)(&enumerator3))->Current;
																T0 val28 = (T0)(!string.IsNullOrWhiteSpace((string)val25));
																if (val28 != null)
																{
																	val25 = (T1)((string)val25 + "&");
																}
																val25 = (T1)((string)val25 + $"roles[{val27}]={current3.task_id}");
																val27 = (T3)(val27 + 1);
															}
														}
														finally
														{
															((IDisposable)(*(List<available_permission_tasks_ui_configs>.Enumerator*)(&enumerator3))).Dispose();
														}
													}
													T0 val29 = (T0)0;
													T8 enumerator4 = (T8)business_users.data.GetEnumerator();
													try
													{
														while (((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator4))->MoveNext())
														{
															ADSPRoject.Data.business_users_data current4 = ((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator4))->Current;
															val20 = (T6)Activator.CreateInstance(typeof(T6));
															((Dictionary<string, string>)val20).Add("strPageId", (string)value);
															((Dictionary<string, string>)val20).Add("strBMID", (string)id);
															((Dictionary<string, string>)val20).Add("strUserId", current4.id);
															((Dictionary<string, string>)val20).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
															((Dictionary<string, string>)val20).Add("strRoles", (string)val25);
															resouce = (T1)ResouceControl.getResouce("phan_quyen_page_doi_tac", (Dictionary<string, string>)val20);
															val21 = executeScript<T1, IJavaScriptExecutor, T3, T0, object>(resouce);
															T0 val30 = (T0)((string)val21).Contains("successes");
															if (val30 != null)
															{
																val7 = (T3)(val7 + 1);
																val29 = (T0)1;
																Console.WriteLine("Done");
															}
														}
													}
													finally
													{
														((IDisposable)(*(List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator4))).Dispose();
													}
													T0 val31 = (T0)(val29 == null);
													if (val31 != null)
													{
														T0 val32 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business."));
														if (val32 != null)
														{
															goUrl<T3, T0, ReadOnlyCollection<IWebElement>, IWebElement, T9, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
														}
														val8 = (T3)(val8 + 1);
														goto IL_05a5;
													}
													val5 = (T3)(val5 + 1);
													setMessage((T1)$"Share BM Đối Tác {val5}", (T0)0);
												}
												catch (Exception ex)
												{
													setMessage((T1)$"Share lỗi {val5}: {ex.Message}", (T0)0);
												}
											}
											val23 = (T3)(val23 + 1);
										}
										break;
									}
									val8 = (T3)(val8 + 1);
									continue;
								}
								val6 = (T3)(val6 + 1);
								break;
							}
							frmMain.isRunning = false;
							frmMain.errorMessage((T1)"Hết token page!");
							return;
						}
						val6 = (T3)(val6 + 1);
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
			}
			setMessage((T1)$"Share: {val7} lỗi: {val6}", (T0)1);
		}
		catch (Exception ex2)
		{
			setMessage((T1)("e:" + ex2.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Tạo_page_nhanh<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		//IL_0188: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01d3: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<T4, List<FBFlowField>, T0, T1>((T1)"Tạo_page_thường").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<T4, List<FBFlowField>, T0, T1>((T1)"Random_tên_page").ToString());
			T1 str = (T1)flow.getValue<T4, List<FBFlowField>, T0, T1>((T1)"Tên_page").ToString();
			T1 catePage = (T1)flow.getValue<T4, List<FBFlowField>, T0, T1>((T1)"Loại_page").ToString();
			T1 val4 = (T1)flow.getValue<T4, List<FBFlowField>, T0, T1>((T1)"BM_Page_Gốc").ToString();
			setMessage((T1)"Tạo page", (T0)0);
			T1 message = (T1)"";
			T1 val5 = (T1)"";
			T0 val6 = val3;
			if (val6 != null)
			{
				T1 firstName = getFirstName<T0, T1, T5>();
				T1 lastName = getLastName<T0, T1, T5>();
				str = (T1)$"{(T4)System.Runtime.CompilerServices.Unsafe.As<T2, char>(ref ((IEnumerable<T2>)firstName).First()).ToString().ToUpper()}{(T4)((string)firstName).Substring(1).ToLower()} {(T4)System.Runtime.CompilerServices.Unsafe.As<T2, char>(ref ((IEnumerable<T2>)lastName).First()).ToString().ToUpper()}{(T4)((string)lastName).Substring(1).ToLower()} {(T4)(object)(T5)rnd.Next(111, 999)}";
			}
			str = (T1)HttpUtility.UrlPathEncode((string)str);
			T0 val7 = val2;
			if (val7 == null)
			{
				T1 bM_Id = (T1)"";
				val5 = Tao_page_trong_bm<T1, Dictionary<string, string>, T0>(bM_Id, str, catePage, out *(string*)(&message));
			}
			else
			{
				val5 = fetch_tao_classic_page<Dictionary<string, string>, T1, T0>(str, catePage);
			}
			T0 val8 = (T0)(!string.IsNullOrEmpty((string)val5) && !string.IsNullOrWhiteSpace((string)val4));
			if (val8 != null)
			{
				Share_Page_Doi_Tac<T0, Dictionary<string, string>, T1>(val5, val4);
			}
			T0 val9 = (T0)(!string.IsNullOrEmpty((string)val5));
			if (val9 == null)
			{
				setMessage((T1)("Tạo page lỗi: " + (string)message), (T0)1);
			}
			else
			{
				setMessage((T1)("Tạo page Ok " + (string)val5), (T0)1);
			}
		}
		catch (Exception ex)
		{
			setMessage((T1)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 fetch_tao_classic_page<T0, T1, T2>(T1 PageName, T1 CatePage)
	{
		//IL_0068: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("strPageName", (string)PageName);
		((Dictionary<string, string>)val).Add("strCategory", (string)CatePage);
		((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
		T2 val2 = (T2)((RemoteWebDriver)chrome).Url.Contains("business.");
		if (val2 != null)
		{
			((Dictionary<string, string>)val).Add("www.", "business.");
		}
		T1 resouce = (T1)ResouceControl.getResouce("fetch_tao_classic_page", (Dictionary<string, string>)val);
		T1 val3 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
		T2 val4 = (T2)((string)val3).Contains("id\":");
		if (val4 != null)
		{
			return (T1)Regex.Match((string)val3, "id\":\"(.*?)\"").Groups[1].Value;
		}
		return (T1)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Tao_page_trong_bm<T0, T1, T2>(T0 BM_Id, T0 PageName, T0 CatePage, out string message)
	{
		//IL_0087: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		//IL_0103: Expected O, but got I4
		message = "";
		T0 result = (T0)"";
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strBM_ID", (string)BM_Id);
			((Dictionary<string, string>)val).Add("strPageName", (string)PageName);
			((Dictionary<string, string>)val).Add("strCatePage", (string)CatePage);
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			T2 val2 = (T2)(!((RemoteWebDriver)chrome).Url.Contains("business."));
			if (val2 != null)
			{
				((Dictionary<string, string>)val).Add("business.", "www.");
			}
			T0 resouce = (T0)ResouceControl.getResouce("Tao_page_trong_bm", (Dictionary<string, string>)val);
			T0 val3 = executeScript<T0, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val4 = (T2)((string)val3).Contains("errorDescription");
			if (val4 == null)
			{
				T2 val5 = (T2)((string)val3).Contains("\"id\":");
				if (val5 != null)
				{
					result = (T0)Regex.Match((string)val3, "id\":\"(.*?)\"").Groups[1].Value;
				}
				else
				{
					T2 val6 = (T2)((string)val3).Contains("error");
					if (val6 != null)
					{
						message = Regex.Match((string)val3, "error\":\"(.*?)\"").Groups[1].Value;
					}
				}
			}
			else
			{
				message = Regex.Match((string)val3, "errorDescription\":\"(.*?)\"").Groups[1].Value;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 kich_page_pro_5<T0, T1, T2>(T2 strPageId)
	{
		//IL_0002: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strPageId", (string)strPageId);
			T2 resouce = (T2)ResouceControl.getResouce("kich_page_pro_5", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("profile_id");
			if (val4 == null)
			{
				return (T0)0;
			}
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 dang_trang<T0, T1, T2>(T2 strPageId)
	{
		//IL_0002: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strPageId", (string)strPageId);
			T2 resouce = (T2)ResouceControl.getResouce("dang_trang", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("is_published\":true");
			if (val4 == null)
			{
				return (T0)0;
			}
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 huy_dang_trang<T0, T1, T2>(T2 strPageId)
	{
		//IL_0002: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strPageId", (string)strPageId);
			T2 resouce = (T2)ResouceControl.getResouce("huy_dang_trang", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)(!((string)val3).ToLower().Contains("error"));
			if (val4 != null)
			{
				return (T0)1;
			}
			return (T0)0;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 phan_quyen_pro5<T0, T1, T2, T3>(T2 strPro5_Id, T2 strUID_VIA_NHAN, T3 isFull)
	{
		//IL_0002: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0147: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			T2 value = (T2)HttpUtility.UrlEncode(frmMain.listFBEntity[indexEntity].Password);
			((Dictionary<string, string>)val2).Add("strPWD_BROWSER", (string)value);
			((Dictionary<string, string>)val2).Add("strPro5_Id", (string)strPro5_Id);
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			T2 resouce = (T2)ResouceControl.getResouce("set_password_pro5_2", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, T0, T3, object>(resouce);
			T3 val4 = (T3)(!((string)val3).Contains("reauth_is_successful\":true"));
			if (val4 == null)
			{
				Thread.Sleep(500);
				val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strUID_Nhan", (string)strUID_VIA_NHAN);
				((Dictionary<string, string>)val2).Add("strPro5_Id", (string)strPro5_Id);
				((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				T3 val5 = (T3)(isFull == null);
				if (val5 != null)
				{
					((Dictionary<string, string>)val2).Add("grant_full_control%22%3Atrue%2C%22", "grant_full_control%22%3Afalse%2C%22");
				}
				T2 resouce2 = (T2)ResouceControl.getResouce("phan_quyen_page_pro5_2", (Dictionary<string, string>)val2);
				val3 = executeScript<T2, IJavaScriptExecutor, T0, T3, object>(resouce2);
				T3 val6 = (T3)((string)val3).Contains("is_invite_sent\":true");
				if (val6 == null)
				{
					return (T0)2;
				}
				return (T0)0;
			}
			return (T0)1;
		}
		catch
		{
			return (T0)2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 kich_page_cong_dong<T0, T1, T2>(T2 strProId)
	{
		//IL_0002: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strPro5_Id", (string)strProId);
			T2 resouce = (T2)ResouceControl.getResouce("chuyen_sang_page_pro5", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			goUrl<int, T0, ReadOnlyCollection<IWebElement>, IWebElement, Exception, T2>((T2)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
			T2 resouce2 = (T2)ResouceControl.getResouce("kich_page_cong_dong");
			val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce2);
			T0 val4 = (T0)((string)val3).Contains("status\":\"success");
			val = ((val4 != null) ? ((T0)1) : ((T0)0));
			val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strUID_VIA_NHAN", frmMain.listFBEntity[indexEntity].UID);
			T2 resouce3 = (T2)ResouceControl.getResouce("chuyen_pro5_sang_via", (Dictionary<string, string>)val2);
			val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce3);
			goUrl<int, T0, ReadOnlyCollection<IWebElement>, IWebElement, Exception, T2>((T2)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
		}
		catch
		{
			val = (T0)0;
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 doi_category_page<T0, T1, T2, T3, T4>(T2 strPageId, T2 strCategoriesId)
	{
		//IL_0002: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00f9: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_0103: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strPageId", (string)strPageId);
			T2 val3 = (T2)"";
			strCategoriesId = (T2)((string)strCategoriesId).Replace("\"", "");
			T0 val4 = (T0)((string)strCategoriesId).Contains(",");
			if (val4 == null)
			{
				val3 = (T2)((string)val3 + "%22" + (string)strCategoriesId + "%22");
			}
			else
			{
				T2[] array = (T2[])(object)((string)strCategoriesId).Split((char[])(object)new T4[1] { (T4)44 });
				T2[] array2 = array;
				T3 val5 = (T3)0;
				while ((nint)val5 < array2.Length)
				{
					T2 val6 = (T2)((object[])(object)array2)[(object)val5];
					T0 val7 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
					if (val7 != null)
					{
						val3 = (T2)((string)val3 + ",");
					}
					val3 = (T2)((string)val3 + "%22" + ((string)val6).Trim() + "%22");
					val5 = (T3)(val5 + 1);
				}
			}
			((Dictionary<string, string>)val2).Add("strCategoriesId", (string)val3);
			T2 resouce = (T2)ResouceControl.getResouce("doi_category_page", (Dictionary<string, string>)val2);
			T2 val8 = executeScript<T2, IJavaScriptExecutor, T3, T0, object>(resouce);
			T0 val9 = (T0)((string)val8).Contains("error\":null");
			if (val9 != null)
			{
				return (T0)1;
			}
			return (T0)0;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 doi_ten_page<T0, T1, T2>(T2 strPageId, T2 strPro5Id, T2 strPageName, out string message)
	{
		//IL_000a: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00db: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		message = "";
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strPro5Id", (string)strPro5Id);
			((Dictionary<string, string>)val2).Add("strPageId", (string)strPageId);
			((Dictionary<string, string>)val2).Add("strNewPageName", (string)strPageName);
			T2 resouce = (T2)ResouceControl.getResouce("doi_ten_page_pro5", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("errors\":null");
			if (val4 == null)
			{
				val = (T0)0;
				val3 = (T2)((string)val3).ToLower();
				T0 val5 = (T0)((string)val3).Contains("description");
				if (val5 != null)
				{
					message = Regex.Match((string)val3, "description\":\"(.*?)\",").Groups[1].Value.ToString();
				}
				T0 val6 = (T0)string.IsNullOrWhiteSpace(message);
				if (val6 != null)
				{
					message = Regex.Match((string)val3, "message\":\"(.*?)\",").Groups[1].Value;
				}
				T0 val7 = (T0)string.IsNullOrWhiteSpace(message);
				if (val7 != null)
				{
					message = Regex.Match((string)val3, "summary\":\"(.*?)\",").Groups[1].Value;
				}
				T0 val8 = (T0)(!string.IsNullOrWhiteSpace(message));
				if (val8 != null)
				{
					message = (string)Compound2Unicode.compound2Unicode((T2)message);
				}
			}
			else
			{
				val = (T0)1;
			}
		}
		catch
		{
			val = (T0)0;
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheckPro5Admin check_user_pro5<T0, T1>(T1 strProId)
	{
		CheckPro5Admin result = null;
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("strProId", (string)strProId);
			T1 resouce = (T1)ResouceControl.getResouce("check_user_pro5", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
			result = JsonConvert.DeserializeObject<CheckPro5Admin>((string)val2);
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Share_Page_Doi_Tac<T0, T1, T2>(T2 strPageId, T2 strBM_Doi_Tac)
	{
		//IL_0002: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		T0 result = (T0)0;
		T1 val = (T1)Activator.CreateInstance(typeof(T1));
		((Dictionary<string, string>)val).Add("strPageId", (string)strPageId);
		((Dictionary<string, string>)val).Add("strBM_Doi_Tac", (string)strBM_Doi_Tac);
		((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
		T2 resouce = (T2)ResouceControl.getResouce("Share_Page_Doi_Tac", (Dictionary<string, string>)val);
		T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
		T0 val3 = (T0)((string)val2).Contains("success\":true");
		if (val3 != null)
		{
			result = (T0)1;
		}
		val = (T1)Activator.CreateInstance(typeof(T1));
		((Dictionary<string, string>)val).Add("strPageId", (string)strPageId);
		((Dictionary<string, string>)val).Add("strBM_Doi_Tac", (string)strBM_Doi_Tac);
		((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
		resouce = (T2)ResouceControl.getResouce("Share_Page_Doi_Tac_Page_Classic", (Dictionary<string, string>)val);
		val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
		T0 val4 = (T0)((string)val2).Contains("success\":true");
		if (val4 != null)
		{
			result = (T0)1;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tạo_Page<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00d8: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_01ad: Expected O, but got I4
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected I4, but got Unknown
		//IL_01c7: Expected I4, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_020b: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Số_page_cần_tạo").ToString());
			string Loại_page = flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Loại_page").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(Loại_page))).First();
			T1 val3 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val4 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T2 resouce = (T2)ResouceControl.getResouce("Tao_Page");
			T2 comment = (T2)categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)].Comment;
			T1 val5 = (T1)0;
			T1 val6 = (T1)0;
			while (true)
			{
				T0 val7 = (T0)(val6 < val2);
				if (val7 == null)
				{
					break;
				}
				try
				{
					goUrl<T1, T0, ReadOnlyCollection<IWebElement>, IWebElement, T3, T2>((T2)ResouceControl.getResouce(".RESOUCE_LIST_PAGE_BM"));
					PAGE_NAME = $"{StringCipher.getPageName<Random, T0, T2, StreamReader>()} {System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)rnd.Next(111, 999)).ToString()}";
					T2 script = (T2)((string)resouce).Replace("categoryid", (string)comment).Replace("strDes", PAGE_NAME).Replace("strName", PAGE_NAME);
					T2 val8 = executeScript<T2, IJavaScriptExecutor, T1, T0, object>(script);
					T0 val9 = (T0)((string)val8).Contains("error_message\":null");
					if (val9 != null)
					{
						val5 = (T1)(val5 + 1);
					}
					frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Message", (T2)$"Create {val5}/{val2}");
					Thread.Sleep(rnd.Next(val3 * 1000, val4 * 1000));
				}
				catch
				{
				}
				val6 = (T1)(val6 + 1);
			}
			frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Message", (T2)$"Done {val5}/{val2}");
			Cập_nhật_page_mth<T0, T1, T2, List<facebook_pagesData>, List<facebook_pagesData>.Enumerator, T3, Dictionary<string, string>>();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Post mtLoadPost<T0, T1, T2>(out string strError, T0 pageId)
	{
		strError = "";
		try
		{
			Post post = new Post();
			T0 val = fetch_url<T2, T0, T1>((T0)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + (string)pageId + "?fields=posts.limit(100)%7Bid%2Cmessage%7D&access_token=" + frmMain.listFBEntity[indexEntity].TokenEAAG));
			return JsonConvert.DeserializeObject<Post>((string)val);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			strError = ex.Message;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 mtLoadPage<T0, T1, T2, T3, T4>(out string strError)
	{
		//IL_0085: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00db: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		strError = "";
		try
		{
			T1 resouce = (T1)ResouceControl.getResouce("lay_danh_sach_page");
			resouce = (T1)((string)resouce).Replace("limit(5000)", "limit(500)");
			resouce = (T1)((string)resouce).Replace("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
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
				val2 = fetch_url_business<T4, T1, T3>(val3);
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
	public T0 get_city_page_locations<T0, T1, T2, T3>(T1 strKeyword)
	{
		//IL_0047: Expected O, but got I4
		T0 result = (T0)Activator.CreateInstance(typeof(T0));
		try
		{
			T1 resouce = (T1)ResouceControl.getResouce("get_city_page_locations");
			strKeyword = (T1)HttpUtility.HtmlEncode((string)strKeyword);
			resouce = (T1)((string)resouce).Replace("strKeyword", (string)strKeyword);
			T1 val = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
			T2 val2 = (T2)((string)val).Contains("[");
			if (val2 != null)
			{
				T1 val3 = val;
				val3 = (T1)((string)val3).Substring(((string)val3).IndexOf("[") + 1);
				val3 = (T1)((string)val3).Substring(0, ((string)val3).IndexOf("]"));
				val3 = (T1)("[" + (string)val3 + "]");
				result = JsonConvert.DeserializeObject<T0>((string)val3);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 tao_page_vi_tri<T0, T1, T2, T3>(T2 strPageId, T2 strCatePage, T2 strCity, T2 strLatitude, T2 strLongitude, T2 strDiaChi, T2 strPhone, T2 strStoreNumber)
	{
		//IL_0002: Expected O, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strPageId", (string)strPageId);
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val).Add("strCatePage", (string)strCatePage);
			((Dictionary<string, string>)val).Add("strCity", (string)strCity);
			((Dictionary<string, string>)val).Add("strLatitude", (string)strLatitude);
			((Dictionary<string, string>)val).Add("strLongitude", (string)strLongitude);
			strDiaChi = (T2)HttpUtility.UrlEncode((string)strDiaChi);
			((Dictionary<string, string>)val).Add("strDiaChi", (string)strDiaChi);
			((Dictionary<string, string>)val).Add("strStoreNumber", (string)strStoreNumber);
			strPhone = (T2)HttpUtility.UrlEncode((string)strPhone);
			((Dictionary<string, string>)val).Add("strPhone", (string)strPhone);
			T2 resouce = (T2)ResouceControl.getResouce("tao_page_vi_tri", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val3 = (T0)((string)val2).ToLower().Contains("\"id\":");
			if (val3 != null)
			{
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Share_pixel<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_0111: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)0;
			setMessage((T2)"Share pixel", (T0)0);
			getFullAdsInfo<Dictionary<string, string>, T2, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, int, char, IDisposable, T4, IWebElement>();
			T1 enumerator = (T1)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					T2 act_id = (T2)current.id.Replace("act_", "");
					T3 enumerator2 = (T3)frmMain.setting.List_TOKEN_PIXEL.GetEnumerator();
					try
					{
						while (((List<TokenEntity>.Enumerator*)(&enumerator2))->MoveNext())
						{
							TokenEntity current2 = ((List<TokenEntity>.Enumerator*)(&enumerator2))->Current;
							T0 val3 = (T0)current2.Status.Equals(frmMain.STATUS.Live.ToString());
							if (val3 != null)
							{
								T0 val4 = frmMain.apiPixel.Share_Pixel<T0, int, T2, T4, HttpRequest>((T2)current2.Token, (T2)frmMain.setting.BM_Pixel_ID, (T2)frmMain.setting.Pixel_Id, act_id);
								if (val4 != null)
								{
									val2 = (T0)1;
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
					T0 val5 = (T0)(val2 == null);
					if (val5 == null)
					{
						setMessage((T2)"Pixel OK", (T0)1);
						continue;
					}
					setMessage((T2)"e:Share pixel lỗi", (T0)1);
					break;
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			setMessage((T2)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void SEO_Keyword_Shopee<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_0113: Expected I4, but got O
		//IL_0113: Expected I4, but got O
		//IL_0130: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_023b: Expected O, but got I4
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_02d0: Expected O, but got I4
		//IL_02ef: Expected O, but got I4
		//IL_02fa: Expected I4, but got O
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_032a: Expected O, but got I4
		//IL_0335: Expected I4, but got O
		//IL_0337: Expected O, but got I4
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_03ac: Expected O, but got I4
		//IL_0429: Expected O, but got I4
		//IL_04a6: Expected O, but got I4
		//IL_0523: Expected O, but got I4
		//IL_053d: Expected O, but got I4
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Expected O, but got Unknown
		//IL_05b9: Expected O, but got I4
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0656: Expected O, but got I4
		//IL_067d: Expected O, but got I4
		//IL_06bb: Expected O, but got I4
		//IL_06f3: Expected O, but got I4
		//IL_070a: Expected O, but got I4
		//IL_0712: Expected O, but got I4
		//IL_0746: Expected O, but got I4
		//IL_0788: Expected O, but got I4
		//IL_0799: Expected O, but got I4
		//IL_07e3: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07fb: Expected O, but got I4
		//IL_0832: Expected O, but got I4
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Expected O, but got Unknown
		//IL_085c: Expected O, but got I4
		//IL_086c: Expected O, but got I4
		//IL_086c: Expected O, but got I4
		//IL_088d: Expected O, but got I4
		//IL_0894: Expected O, but got I4
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b7: Expected O, but got Unknown
		//IL_08be: Expected O, but got I4
		//IL_08d5: Expected O, but got I4
		//IL_08d8: Expected O, but got I4
		//IL_08df: Expected O, but got I4
		//IL_0940: Expected O, but got I4
		//IL_0972: Expected O, but got I4
		//IL_0997: Expected O, but got I4
		//IL_09c9: Expected O, but got I4
		//IL_0a0e: Expected O, but got I4
		//IL_0a1f: Expected O, but got I4
		//IL_0a3d: Expected O, but got I4
		//IL_0a74: Expected O, but got I4
		//IL_0a97: Expected O, but got I4
		//IL_0a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Expected O, but got Unknown
		//IL_0ad9: Expected I4, but got O
		//IL_0ad9: Expected I4, but got O
		//IL_0adb: Expected O, but got I4
		//IL_0ae2: Expected O, but got I4
		//IL_0ae9: Expected O, but got I4
		//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b11: Expected O, but got Unknown
		//IL_0b19: Expected O, but got I4
		//IL_0b86: Expected O, but got I4
		//IL_0b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Expected O, but got Unknown
		//IL_0bc4: Expected O, but got I4
		//IL_0be7: Expected O, but got I4
		//IL_0c16: Expected O, but got I4
		//IL_0ca7: Expected O, but got I4
		//IL_0caf: Expected O, but got I4
		//IL_0cb9: Expected O, but got I4
		//IL_0cc9: Expected O, but got I4
		//IL_0ccc: Expected O, but got I4
		//IL_0cdd: Expected O, but got I4
		//IL_0cf3: Expected O, but got I4
		//IL_0cf6: Expected O, but got I4
		//IL_0d04: Expected O, but got I4
		//IL_0d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3a: Expected O, but got Unknown
		//IL_0d42: Expected O, but got I4
		//IL_0d79: Expected O, but got I4
		//IL_0da0: Expected O, but got I4
		//IL_0dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc0: Expected O, but got Unknown
		//IL_0dc8: Expected O, but got I4
		//IL_0dd6: Expected O, but got I4
		//IL_0e33: Expected O, but got I4
		//IL_0e3e: Expected O, but got I4
		//IL_0e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e55: Expected O, but got Unknown
		//IL_0e69: Expected O, but got I4
		//IL_0e84: Expected O, but got I4
		//IL_0eb4: Expected O, but got I4
		//IL_0ef8: Expected O, but got I4
		//IL_0f2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2d: Expected O, but got Unknown
		//IL_0f35: Expected O, but got I4
		//IL_0f4b: Expected O, but got I4
		//IL_0f71: Expected O, but got I4
		//IL_0fc8: Expected O, but got I4
		//IL_0ff6: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Từ_khóa").ToString();
			string Id_sản_phẩm = flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Id_sản_phẩm").ToString();
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Sắp_xếp_theo").ToString();
			T2 val4 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Refesh_page_từ").ToString());
			T2 val5 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Refesh_page_đến").ToString());
			T2 val6 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Mặc_định_page").ToString());
			T2 val7 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tìm_sp_từ_page").ToString());
			T2 val8 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Giới_hạn_page").ToString());
			T2 val9 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thời_gian_online_từ").ToString());
			T2 val10 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thời_gian_online_đến").ToString());
			int Time_Online = rnd.Next((int)val9, (int)val10);
			T0 val11 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thả_tim").ToString());
			T2 val12 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Thêm_vào_giỏ_hàng").ToString());
			T2 val13 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random_sp_liên_quan").ToString());
			T1[] array = null;
			try
			{
				array = (T1[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_sp_liên_quan");
			}
			catch (Exception)
			{
			}
			T0 val14 = (T0)(array == null);
			if (val14 != null)
			{
				try
				{
					array = JsonConvert.DeserializeObject<T1[]>(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_sp_liên_quan").ToString());
				}
				catch (Exception)
				{
				}
			}
			T3 val15 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("icon-shopee-logo"));
			T0 val16 = (T0)(val15 == null || ((ReadOnlyCollection<IWebElement>)val15).Count == 0);
			if (val16 != null)
			{
				goUrl<T2, T0, T3, T4, T7, T1>((T1)frmMain.RESOUCE_SHOPEE_HOME);
				Thread.Sleep(3000);
				addon_page_is_showing<T3, T0>();
			}
			addon_closeAds<T3, T0, T4>();
			val15 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("icon-shopee-logo"));
			actions.MoveToElement((IWebElement)((IEnumerable<T4>)val15).First()).Perform();
			focusElement<IJavaScriptExecutor, T7, T4, T2, object>(((IEnumerable<T4>)val15).First(), (T2)1000);
			((IWebElement)((IEnumerable<T4>)val15).First()).Click();
			Thread.Sleep(2000);
			addon_closeAds<T3, T0, T4>();
			T3 source = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-searchbar-input__input"));
			actions = new Actions((IWebDriver)(object)chrome);
			actions.MoveToElement((IWebElement)((IEnumerable<T4>)source).First()).Perform();
			((IWebElement)((IEnumerable<T4>)source).First()).Click();
			((IWebElement)((IEnumerable<T4>)source).First()).Clear();
			Thread.Sleep(1000);
			T0 val17 = (T0)(((IWebElement)((IEnumerable<T4>)source).First()).GetAttribute("value") != null);
			if (val17 != null)
			{
				T1 attribute = (T1)((IWebElement)((IEnumerable<T4>)source).First()).GetAttribute("value");
				T1 val18 = attribute;
				T2 val19 = (T2)0;
				while ((nint)val19 < ((string)val18).Length)
				{
					_ = ((string)val18)[(int)val19];
					((IWebElement)((IEnumerable<T4>)source).First()).SendKeys(Keys.Backspace);
					Thread.Sleep(10);
					val19 = (T2)(val19 + 1);
				}
			}
			T1 val20 = val2;
			T2 val21 = (T2)0;
			while ((nint)val21 < ((string)val20).Length)
			{
				T5 val22 = (T5)((string)val20)[(int)val21];
				((IWebElement)((IEnumerable<T4>)source).First()).SendKeys(((char*)(&val22))->ToString());
				Thread.Sleep(rnd.Next(10, 50));
				val21 = (T2)(val21 + 1);
			}
			Thread.Sleep(1500);
			((IWebElement)((IEnumerable<T4>)source).First()).SendKeys(Keys.Enter);
			Thread.Sleep(5000);
			shopee_sort_by_options_is_showing<T3, T0>();
			T0 val23 = (T0)((string)val3).ToLower().Equals("liên quan");
			if (val23 != null)
			{
				T3 source2 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-sort-by-options__option"));
				T6 source3 = (T6)((IEnumerable<T4>)source2).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T4 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("liên quan")))).ToList();
				((IWebElement)((IEnumerable<T4>)source3).First()).Click();
				Thread.Sleep(2000);
				shopee_sort_by_options_is_showing<T3, T0>();
			}
			else
			{
				T0 val24 = (T0)((string)val3).ToLower().Equals("mới nhất");
				if (val24 != null)
				{
					T3 source4 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-sort-by-options__option"));
					T6 source5 = (T6)((IEnumerable<T4>)source4).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T4 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("mới nhất")))).ToList();
					((IWebElement)((IEnumerable<T4>)source5).First()).Click();
					Thread.Sleep(2000);
					shopee_sort_by_options_is_showing<T3, T0>();
				}
				else
				{
					T0 val25 = (T0)((string)val3).ToLower().Equals("bán chạy");
					if (val25 != null)
					{
						T3 source6 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-sort-by-options__option"));
						T6 source7 = (T6)((IEnumerable<T4>)source6).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T4 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("bán chạy")))).ToList();
						((IWebElement)((IEnumerable<T4>)source7).First()).Click();
						Thread.Sleep(2000);
						shopee_sort_by_options_is_showing<T3, T0>();
					}
					else
					{
						T0 val26 = (T0)((string)val3).ToLower().Equals("giá thấp đến cao");
						if (val26 == null)
						{
							T0 val27 = (T0)((string)val3).ToLower().Equals("giá cao đến thấp");
							if (val27 != null)
							{
								T3 source8 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("select-with-status"));
								actions = new Actions((IWebDriver)(object)chrome);
								actions.MoveToElement((IWebElement)((IEnumerable<T4>)source8).First()).Perform();
								Thread.Sleep(1500);
								T3 val28 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("select-with-status__dropdown-item"));
								T0 val29 = (T0)(val28 != null && ((ReadOnlyCollection<IWebElement>)val28).Count > 0);
								if (val29 != null)
								{
									((IWebElement)((IEnumerable<T4>)val28).Last()).Click();
									Thread.Sleep(2000);
									shopee_sort_by_options_is_showing<T3, T0>();
								}
							}
						}
						else
						{
							T3 source9 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("select-with-status"));
							actions = new Actions((IWebDriver)(object)chrome);
							actions.MoveToElement((IWebElement)((IEnumerable<T4>)source9).First()).Perform();
							Thread.Sleep(1500);
							T3 val30 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("select-with-status__dropdown-item"));
							T0 val31 = (T0)(val30 != null && ((ReadOnlyCollection<IWebElement>)val30).Count > 0);
							if (val31 != null)
							{
								((IWebElement)((IEnumerable<T4>)val30).First()).Click();
								Thread.Sleep(2000);
								shopee_sort_by_options_is_showing<T3, T0>();
							}
						}
					}
				}
			}
			T0 val32 = (T0)((nint)val6 > 0);
			if (val32 != null)
			{
				goUrl<T2, T0, T3, T4, T7, T1>((T1)$"{((RemoteWebDriver)chrome).Url}&page={val6}");
				Thread.Sleep(2000);
				shopee_sort_by_options_is_showing<T3, T0>();
			}
			T0 val33 = (T0)((nint)val7 > 0);
			if (val33 != null)
			{
				while (true)
				{
					T0 val34 = (T0)frmMain.isRunning;
					if (val34 == null)
					{
						break;
					}
					try
					{
						T3 val35 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-mini-page-controller__current"));
						T0 val36 = (T0)(val35 != null && ((ReadOnlyCollection<IWebElement>)val35).Count > 0);
						if (val36 == null)
						{
							goto IL_071b;
						}
						T2 val37 = (T2)int.Parse(((IWebElement)((IEnumerable<T4>)val35).First()).Text);
						T0 val38 = (T0)((object)val37 == (object)val7);
						if (val38 == null)
						{
							goto IL_071b;
						}
						goto end_IL_06c8;
						IL_071b:
						T3 val39 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("icon-arrow-right-small"));
						T0 val40 = (T0)(val39 != null && ((ReadOnlyCollection<IWebElement>)val39).Count > 0);
						if (val40 != null)
						{
							T4 parent = GetParent(((IEnumerable<T4>)val39).First());
							T0 val41 = (T0)(((IWebElement)parent).GetAttribute("class") != null && !((IWebElement)parent).GetAttribute("class").Contains("disabled"));
							if (val41 != null)
							{
								focusElement<IJavaScriptExecutor, T7, T4, T2, object>(parent, (T2)500);
								((IWebElement)parent).Click();
								Thread.Sleep(500);
								shopee_sort_by_options_is_showing<T3, T0>();
								pageDown(4, 500);
								continue;
							}
						}
						end_IL_06c8:;
					}
					catch (Exception ex3)
					{
						Console.WriteLine(ex3.Message);
						Thread.Sleep(2000);
						continue;
					}
					break;
				}
			}
			T4 val42 = (T4)null;
			T4 val43 = (T4)null;
			while (true)
			{
				T0 val44 = (T0)frmMain.isRunning;
				if (val44 == null)
				{
					break;
				}
				T0 val45 = (T0)1;
				T0 val46 = (T0)1;
				while (true)
				{
					T0 val47 = (T0)frmMain.isRunning;
					if (val47 == null)
					{
						break;
					}
					T0 val48 = addon_check_product_show_all<T3, T6, T0, T4>();
					if (val48 != null)
					{
						break;
					}
					T0 val49 = val45;
					if (val49 == null)
					{
						T3 source10 = (T3)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
						T2 val50 = (T2)0;
						while (true)
						{
							T0 val51 = (T0)((nint)val50 < 5);
							if (val51 == null)
							{
								break;
							}
							((IWebElement)((IEnumerable<T4>)source10).First()).SendKeys(Keys.Right);
							Thread.Sleep(200);
							val50 = (T2)(val50 + 1);
						}
						pageUp<T3, T2, T0, T4>((T2)6, (T2)500);
					}
					else
					{
						T3 source11 = (T3)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
						T0 val52 = (T0)(val46 == null);
						if (val52 != null)
						{
							T2 val53 = (T2)0;
							while (true)
							{
								T0 val54 = (T0)((nint)val53 < 5);
								if (val54 == null)
								{
									break;
								}
								((IWebElement)((IEnumerable<T4>)source11).First()).SendKeys(Keys.Right);
								Thread.Sleep(200);
								val53 = (T2)(val53 + 1);
							}
						}
						pageDown(6, 500);
					}
					val45 = (T0)(val45 == null);
					val46 = (T0)0;
				}
				T3 source12 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-search-item-result__item"));
				T6 val55 = (T6)((IEnumerable<T4>)source12).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T4 a) => (T0)(((ISearchContext)a).FindElements(By.TagName("a")) != null && ((ISearchContext)a).FindElements(By.TagName("a")).Count > 0 && ((IWebElement)((IEnumerable<T4>)((ISearchContext)a).FindElements(By.TagName("a"))).First()).GetAttribute("href") != null && !string.IsNullOrWhiteSpace(((IWebElement)((IEnumerable<T4>)((ISearchContext)a).FindElements(By.TagName("a"))).First()).GetAttribute("href")) && ((IWebElement)((IEnumerable<T4>)((ISearchContext)a).FindElements(By.TagName("a"))).First()).GetAttribute("href").ToLower().EndsWith(Id_sản_phẩm.ToLower())))).ToList();
				T0 val56 = (T0)(val55 != null && ((List<IWebElement>)val55).Count > 0);
				if (val56 == null)
				{
					T3 val57 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-mini-page-controller__current"));
					T0 val58 = (T0)(val57 != null && ((ReadOnlyCollection<IWebElement>)val57).Count > 0);
					if (val58 == null)
					{
						break;
					}
					T0 val59 = (T0)(val8 == null || (nint)val8 > int.Parse(((IWebElement)((IEnumerable<T4>)val57).First()).Text));
					if (val59 == null)
					{
						break;
					}
					T3 val60 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("icon-arrow-right-small"));
					T0 val61 = (T0)(val60 != null && ((ReadOnlyCollection<IWebElement>)val60).Count > 0);
					if (val61 == null)
					{
						break;
					}
					T4 parent2 = GetParent(((IEnumerable<T4>)val60).First());
					T0 val62 = (T0)(((IWebElement)parent2).GetAttribute("class") != null && !((IWebElement)parent2).GetAttribute("class").Contains("disabled"));
					if (val62 == null)
					{
						break;
					}
					focusElement<IJavaScriptExecutor, T7, T4, T2, object>(parent2, (T2)150);
					((IWebElement)parent2).Click();
					Thread.Sleep(500);
					shopee_sort_by_options_is_showing<T3, T0>();
					continue;
				}
				val42 = ((IEnumerable<T4>)val55).First();
				val43 = ((IEnumerable<T4>)((ISearchContext)((IEnumerable<T4>)val55).First()).FindElements(By.TagName("a"))).First();
				break;
			}
			T0 val63 = (T0)(val42 != null);
			if (val63 != null)
			{
				focusElement<IJavaScriptExecutor, T7, T4, T2, object>(val42, (T2)2500);
				actions = new Actions((IWebDriver)(object)chrome);
				actions.MoveToElement((IWebElement)val42).Perform();
				((IWebElement)val43).Click();
				Thread.Sleep(2000);
				T2 val64 = (T2)rnd.Next((int)val4, (int)val5);
				T0 val65 = (T0)((nint)val64 > 0);
				if (val65 != null)
				{
					T2 val66 = (T2)0;
					while (true)
					{
						T0 val67 = (T0)(val66 < val64);
						if (val67 == null)
						{
							break;
						}
						((RemoteWebDriver)chrome).Navigate().Refresh();
						Thread.Sleep(2000);
						addon_page_is_showing<T3, T0>();
						val66 = (T2)(val66 + 1);
					}
				}
				addon_closeAds<T3, T0, T4>();
				T0 val68 = val11;
				if (val68 != null)
				{
					T3 source13 = (T3)((RemoteWebDriver)chrome).FindElements(By.TagName("path"));
					T6 val69 = (T6)((IEnumerable<T4>)source13).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T4 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("fill-rule") != null && ((IWebElement)a).GetAttribute("fill-rule").Equals("evenodd") && ((IWebElement)a).GetAttribute("fill") != null && ((IWebElement)a).GetAttribute("fill").Equals("none")))).ToList();
					T0 val70 = (T0)(val69 != null && ((List<IWebElement>)val69).Count > 0);
					if (val70 != null)
					{
						actions = new Actions((IWebDriver)(object)chrome);
						actions.MoveToElement((IWebElement)((IEnumerable<T4>)val69).First()).Perform();
						focusElement<IJavaScriptExecutor, T7, T4, T2, object>(((IEnumerable<T4>)val69).First(), (T2)200);
						((IWebElement)GetParent(((IEnumerable<T4>)val69).First())).Click();
						Thread.Sleep(1500);
					}
				}
				T0 val71 = (T0)((nint)val12 > 0);
				if (val71 != null)
				{
					T3 val72 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("product-variation"));
					T0 val73 = (T0)(val72 != null && ((ReadOnlyCollection<IWebElement>)val72).Count > 0);
					if (val73 != null)
					{
						T4 parent3 = GetParent(GetParent(GetParent(((IEnumerable<T4>)val72).First())));
						((IWebElement)parent3).GetAttribute("class");
						((ISearchContext)parent3).FindElements(By.ClassName("items-center"));
						((ISearchContext)parent3).FindElements(By.TagName("div"));
					}
				}
				bool isrun = true;
				T9 val74 = (T9)new Thread((ThreadStart)delegate
				{
					Thread.Sleep(Time_Online * 1000);
					isrun = false;
				});
				((Thread)val74).Start();
				T3 source14 = (T3)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
				T0 val75 = (T0)1;
				while (true)
				{
					T0 val76 = (T0)(isrun && frmMain.isRunning);
					if (val76 == null)
					{
						break;
					}
					T2 val77 = (T2)0;
					T2 val78 = (T2)rnd.Next(15, 25);
					T2 val79 = (T2)0;
					while (true)
					{
						T0 val80 = (T0)(val79 < val78);
						if (val80 == null)
						{
							break;
						}
						T0 val81 = (T0)(!isrun);
						if (val81 != null)
						{
							break;
						}
						val77 = (T2)rnd.Next(6, 15);
						T2 val82 = (T2)0;
						while (true)
						{
							T0 val83 = (T0)(val82 < val77);
							if (val83 == null)
							{
								break;
							}
							T0 val84 = (T0)(!isrun);
							if (val84 != null)
							{
								break;
							}
							T0 val85 = val75;
							if (val85 == null)
							{
								((IWebElement)((IEnumerable<T4>)source14).First()).SendKeys(Keys.Up);
							}
							else
							{
								((IWebElement)((IEnumerable<T4>)source14).First()).SendKeys(Keys.Down);
							}
							val82 = (T2)(val82 + 1);
						}
						T0 val86 = val75;
						if (val86 == null)
						{
							T3 val87 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-searchbar-input"));
							T0 val88 = (T0)(val87 != null && ((ReadOnlyCollection<IWebElement>)val87).Count > 0);
							if (val88 != null)
							{
								T10 val89 = (T10)((IEnumerable<T4>)val87).First();
								T0 val90 = (T0)(((Point)(T11)((RemoteWebElement)val89).LocationOnScreenOnceScrolledIntoView).Y > 0);
								if (val90 != null)
								{
									break;
								}
							}
						}
						Thread.Sleep(rnd.Next(100, 500));
						val79 = (T2)(val79 + 1);
					}
					val75 = (T0)(val75 == null);
					Thread.Sleep(rnd.Next(3000, 5000));
				}
				((IWebElement)((IEnumerable<T4>)source14).First()).SendKeys(Keys.Home);
				Thread.Sleep(1500);
				T0 val91 = (T0)(array != null && array.Length != 0);
				if (val91 != null)
				{
					T1[] array2 = array;
					T2 val92 = (T2)0;
					while ((nint)val92 < array2.Length)
					{
						T1 sp = (T1)((object[])(object)array2)[(object)val92];
						addon_view_product_relasion<T3, T0, T13, T4, T1>(sp);
						val92 = (T2)(val92 + 1);
					}
					return;
				}
				T0 val93 = (T0)((nint)val13 > 0);
				if (val93 == null)
				{
					return;
				}
				T12 val94 = (T12)Activator.CreateInstance(typeof(T12));
				T2 val95 = (T2)0;
				while (true)
				{
					T0 val96 = (T0)(val95 < val13);
					if (val96 == null)
					{
						break;
					}
					T3 val97 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("page-product__content--right"));
					T0 val98 = (T0)(val97 != null && ((ReadOnlyCollection<IWebElement>)val97).Count > 0);
					if (val98 != null)
					{
						T3 val99 = (T3)((ISearchContext)((IEnumerable<T4>)val97).First()).FindElements(By.TagName("a"));
						T13 enumerator = (T13)((ReadOnlyCollection<IWebElement>)val99).GetEnumerator();
						try
						{
							while (((IEnumerator)enumerator).MoveNext())
							{
								T4 current = (T4)((IEnumerator<IWebElement>)enumerator).Current;
								T0 val100 = (T0)(((IWebElement)current).GetAttribute("href") != null);
								if (val100 != null)
								{
									((List<string>)val94).Add(((IWebElement)current).GetAttribute("href"));
								}
							}
						}
						finally
						{
							if (enumerator != null)
							{
								((IDisposable)enumerator).Dispose();
							}
						}
					}
					val95 = (T2)(val95 + 1);
				}
				while (true)
				{
					T0 val101 = (T0)frmMain.isRunning;
					if (val101 == null)
					{
						break;
					}
					T0 val102 = (T0)(((List<string>)val94).Count > (nint)val13);
					if (val102 == null)
					{
						break;
					}
					((List<string>)val94).RemoveAt(rnd.Next(0, ((List<string>)val94).Count - 1));
				}
				T14 enumerator2 = (T14)((List<string>)val94).GetEnumerator();
				try
				{
					while (((List<string>.Enumerator*)(&enumerator2))->MoveNext())
					{
						T1 current2 = (T1)((List<string>.Enumerator*)(&enumerator2))->Current;
						addon_view_product_relasion<T3, T0, T13, T4, T1>(current2);
					}
					return;
				}
				finally
				{
					((IDisposable)(*(List<string>.Enumerator*)(&enumerator2))).Dispose();
				}
			}
			frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Shopee_Status", (T1)"Không tìm thấy sản phẩm!");
		}
		catch (Exception ex4)
		{
			Console.WriteLine(ex4.Message);
			frmMain.SetCellText<T0, T2, T1>((T2)indexEntity, (T1)"Message", (T1)ex4.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addon_view_product_relasion<T0, T1, T2, T3, T4>(T4 sp)
	{
		//IL_0027: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		T0 val = (T0)((RemoteWebDriver)chrome).FindElements(By.ClassName("page-product__content--right"));
		T1 val2 = (T1)(val != null && ((ReadOnlyCollection<IWebElement>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T0 val3 = (T0)((ISearchContext)((IEnumerable<T3>)val).First()).FindElements(By.TagName("a"));
		T2 enumerator = (T2)((ReadOnlyCollection<IWebElement>)val3).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				T3 current = (T3)((IEnumerator<IWebElement>)enumerator).Current;
				T1 val4 = (T1)(!frmMain.isRunning);
				if (val4 == null)
				{
					T1 val5 = (T1)(((IWebElement)current).GetAttribute("href") != null && ((string)sp).ToLower().Contains(((IWebElement)current).GetAttribute("href").ToLower()));
					if (val5 != null)
					{
						actions = new Actions((IWebDriver)(object)chrome);
						focusElement<IJavaScriptExecutor, Exception, T3, int, object>(current, 1500);
						actions.MoveToElement((IWebElement)current).Perform();
						((IWebElement)current).Click();
						Thread.Sleep(5000);
						addon_page_is_showing<T0, T1>();
						addon_down_up_page<T1, Thread, T0, int, RemoteWebElement, Point, T3>(rnd.Next(5000, 10000));
						((RemoteWebDriver)chrome).Navigate().Back();
						break;
					}
					continue;
				}
				break;
			}
		}
		finally
		{
			if (enumerator != null)
			{
				((IDisposable)enumerator).Dispose();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addon_down_up_page<T0, T1, T2, T3, T4, T5, T6>(T3 Time_Online)
	{
		//IL_000d: Expected I4, but got O
		//IL_0016: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d1: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0156: Expected O, but got I4
		//IL_0162: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		int Time_Online2 = (int)Time_Online;
		bool isrun = true;
		T0 val = (T0)1;
		T1 val2 = (T1)new Thread((ThreadStart)delegate
		{
			Thread.Sleep(Time_Online2);
			isrun = false;
		});
		((Thread)val2).Start();
		T2 source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
		while (true)
		{
			T0 val3 = (T0)isrun;
			if (val3 == null)
			{
				break;
			}
			T3 val4 = (T3)0;
			T3 val5 = (T3)rnd.Next(15, 25);
			T3 val6 = (T3)0;
			while (true)
			{
				T0 val7 = (T0)(val6 < val5);
				if (val7 == null)
				{
					break;
				}
				T0 val8 = (T0)(!isrun);
				if (val8 != null)
				{
					break;
				}
				val4 = (T3)rnd.Next(6, 15);
				T3 val9 = (T3)0;
				while (true)
				{
					T0 val10 = (T0)(val9 < val4);
					if (val10 == null)
					{
						break;
					}
					T0 val11 = (T0)(!isrun);
					if (val11 != null)
					{
						break;
					}
					T0 val12 = val;
					if (val12 != null)
					{
						((IWebElement)((IEnumerable<T6>)source).First()).SendKeys(Keys.Down);
					}
					else
					{
						((IWebElement)((IEnumerable<T6>)source).First()).SendKeys(Keys.Up);
					}
					val9 = (T3)(val9 + 1);
				}
				T0 val13 = val;
				if (val13 == null)
				{
					T2 val14 = (T2)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-searchbar-input"));
					T0 val15 = (T0)(val14 != null && ((ReadOnlyCollection<IWebElement>)val14).Count > 0);
					if (val15 != null)
					{
						T4 val16 = (T4)((IEnumerable<T6>)val14).First();
						T0 val17 = (T0)(((Point)(T5)((RemoteWebElement)val16).LocationOnScreenOnceScrolledIntoView).Y > 0);
						if (val17 != null)
						{
							break;
						}
					}
				}
				Thread.Sleep(rnd.Next(100, 500));
				val6 = (T3)(val6 + 1);
			}
			val = (T0)(val == null);
			Thread.Sleep(rnd.Next(3000, 5000));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pageDown(int numDown, int timeDelay)
	{
		ReadOnlyCollection<IWebElement> source = ((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
		for (int i = 0; i < numDown; i++)
		{
			if (!frmMain.isRunning)
			{
				break;
			}
			source.First().SendKeys(Keys.PageDown);
			Thread.Sleep(timeDelay);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pageUp<T0, T1, T2, T3>(T1 numDown, T1 timeDelay)
	{
		//IL_0019: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_003d: Expected I4, but got O
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0046: Expected O, but got I4
		T0 source = (T0)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
		T1 val = (T1)0;
		while (true)
		{
			T2 val2 = (T2)(val < numDown);
			if (val2 != null)
			{
				T2 val3 = (T2)(!frmMain.isRunning);
				if (val3 == null)
				{
					((IWebElement)((IEnumerable<T3>)source).First()).SendKeys(Keys.PageUp);
					Thread.Sleep((int)timeDelay);
					val = (T1)(val + 1);
					continue;
				}
				break;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void shopee_sort_by_options_is_showing<T0, T1>()
	{
		//IL_002a: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		while (true)
		{
			T1 val = (T1)frmMain.isRunning;
			if (val != null)
			{
				T0 val2 = (T0)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-sort-by-options"));
				T1 val3 = (T1)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
				if (val3 == null)
				{
					Thread.Sleep(3000);
					continue;
				}
				break;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Login_Shopee_By_Facebook<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_015a: Expected O, but got I4
		//IL_01c8: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_0212: Expected O, but got I4
		//IL_022b: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		//IL_02d1: Expected O, but got I4
		//IL_0317: Expected O, but got I4
		//IL_0336: Expected O, but got I4
		//IL_0368: Expected O, but got I4
		//IL_0387: Expected O, but got I4
		//IL_03cf: Expected O, but got I4
		//IL_0405: Expected O, but got I4
		//IL_043e: Expected O, but got I4
		//IL_0457: Expected O, but got I4
		//IL_046f: Expected O, but got I4
		//IL_0489: Expected O, but got I4
		//IL_04b0: Expected O, but got I4
		//IL_04cf: Expected O, but got I4
		//IL_04da: Expected I4, but got O
		//IL_04dc: Expected O, but got I4
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_0543: Expected O, but got I4
		//IL_0568: Expected O, but got I4
		//IL_056e: Expected O, but got I4
		//IL_0599: Expected O, but got I4
		//IL_05dd: Expected O, but got I4
		//IL_05e3: Expected O, but got I4
		//IL_0612: Expected O, but got I4
		//IL_0616: Expected O, but got I4
		//IL_0623: Expected O, but got I4
		//IL_0627: Expected O, but got I4
		//IL_067f: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			goUrl<T5, T0, T1, T3, T7, T4>((T4)frmMain.RESOUCE_SHOPEE_HOME);
			Thread.Sleep(2000);
			addon_closeAds<T1, T0, T3>();
			addon_page_is_showing<T1, T0>();
			T0 val2 = (T0)0;
			T1 val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
			T0 val4 = (T0)(val3 == null || ((ReadOnlyCollection<IWebElement>)val3).Count <= 0);
			if (val4 != null)
			{
				T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__link"));
				T2 val5 = (T2)((IEnumerable<T3>)source).Where((Func<T3, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T3 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("đăng nhập")))).ToList();
				T0 val6 = (T0)(((List<IWebElement>)val5).Count > 0);
				if (val6 != null)
				{
					((IWebElement)((IEnumerable<T3>)val5).First()).Click();
					Thread.Sleep(3000);
				}
				addon_closeAds<T1, T0, T3>();
				while (true)
				{
					T0 val7 = (T0)frmMain.isRunning;
					if (val7 == null)
					{
						break;
					}
					T1 val8 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("loginKey"));
					T0 val9 = (T0)(((ReadOnlyCollection<IWebElement>)val8).Count > 0);
					if (val9 != null)
					{
						break;
					}
					val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
					T0 val10 = (T0)(val3 != null && ((ReadOnlyCollection<IWebElement>)val3).Count > 0);
					if (val10 == null)
					{
						Thread.Sleep(1500);
						continue;
					}
					val2 = (T0)1;
					break;
				}
				T0 val11 = (T0)(val2 == null);
				if (val11 == null)
				{
					return;
				}
				countError = 0;
				T3 val12 = (T3)null;
				while (true)
				{
					T0 val13 = (T0)frmMain.isRunning;
					if (val13 != null)
					{
						T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
						T2 val14 = (T2)((IEnumerable<T3>)source2).Where((Func<T3, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T3 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).Text.ToLower().Equals("facebook") && ((IWebElement)a).GetAttribute("disable") == null))).ToList();
						T0 val15 = (T0)(val14 != null && ((List<IWebElement>)val14).Count > 0);
						if (val15 == null)
						{
							T0 val16 = (T0)(countError == 10);
							if (val16 != null)
							{
								countError = 0;
								((RemoteWebDriver)chrome).Navigate().Refresh();
							}
							countError++;
							Thread.Sleep(1500);
							continue;
						}
						val12 = ((IEnumerable<T3>)val14).First();
						break;
					}
					break;
				}
				T0 val17 = (T0)(val12 != null);
				if (val17 != null)
				{
					countError = 0;
					((IWebElement)val12).Click();
					Thread.Sleep(500);
					while (true)
					{
						T0 val18 = (T0)frmMain.isRunning;
						if (val18 == null)
						{
							break;
						}
						T0 val19 = (T0)(countError == 10);
						if (val19 != null)
						{
							countError = 0;
							((RemoteWebDriver)chrome).Navigate().Refresh();
							T1 source3 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
							T2 val20 = (T2)((IEnumerable<T3>)source3).Where((Func<T3, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T3 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).Text.ToLower().Equals("facebook") && ((IWebElement)a).GetAttribute("disable") == null))).ToList();
							T0 val21 = (T0)(val20 != null && ((List<IWebElement>)val20).Count > 0);
							if (val21 != null)
							{
								val12 = ((IEnumerable<T3>)val20).First();
								((IWebElement)val12).Click();
								Thread.Sleep(500);
							}
						}
						val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
						T0 val22 = (T0)(val3 != null && ((ReadOnlyCollection<IWebElement>)val3).Count > 0);
						if (val22 == null)
						{
							T0 val23 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("khoản đã bị cấm");
							if (val23 == null)
							{
								T1 val24 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("username"));
								T0 val25 = (T0)(val24 != null && ((ReadOnlyCollection<IWebElement>)val24).Count > 0);
								if (val25 == null)
								{
									T0 val26 = (T0)(((RemoteWebDriver)chrome).WindowHandles.Count >= 2);
									if (val26 != null)
									{
										((RemoteWebDriver)chrome).SwitchTo().Window(((RemoteWebDriver)chrome).WindowHandles[1]);
										T3 val27 = (T3)((RemoteWebDriver)chrome).FindElement(By.Id("email"));
										T0 val28 = (T0)(val27 != null);
										if (val28 != null)
										{
											updateStatus((T4)"Chưa đăng nhập Facebook!", (T0)1);
											break;
										}
										T1 val29 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("__CONFIRM__"));
										countError = 0;
										T0 val30 = (T0)(val29 != null && ((ReadOnlyCollection<IWebElement>)val29).Count > 0);
										if (val30 != null)
										{
											((IWebElement)((IEnumerable<T3>)val29).First()).Click();
											Thread.Sleep(5000);
										}
									}
									countError++;
									Thread.Sleep(1000);
									continue;
								}
								T3 val31 = (T3)null;
								val31 = ((IEnumerable<T3>)val24).First();
								T4 val32 = frmMain.RandomString<T4, T5, T6>((T5)16);
								val32 = (T4)((string)val32 + System.Runtime.CompilerServices.Unsafe.As<T5, int>(ref (T5)rnd.Next(1978, 2004)));
								frmMain.SetCellText<T0, T5, T4>((T5)indexEntity, (T4)"Shopee_UserName", val32);
								((IWebElement)val31).Click();
								((IWebElement)val31).Clear();
								Thread.Sleep(1500);
								T4 val33 = val32;
								T5 val34 = (T5)0;
								while ((nint)val34 < ((string)val33).Length)
								{
									((IWebElement)val31).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T6, char>(ref (T6)((string)val33)[(int)val34]).ToString());
									Thread.Sleep(rnd.Next(10, 50));
									val34 = (T5)(val34 + 1);
								}
								Thread.Sleep(3000);
								T1 source4 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
								((IWebElement)((IEnumerable<T3>)source4).Last()).Click();
								while (true)
								{
									T0 val35 = (T0)frmMain.isRunning;
									if (val35 == null)
									{
										break;
									}
									try
									{
										T0 val36 = (T0)((RemoteWebDriver)chrome).PageSource.ToLower().Contains("đăng ký thành công");
										if (val36 != null)
										{
											val2 = (T0)1;
											T1 val37 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
											T0 val38 = (T0)(val37 != null && ((ReadOnlyCollection<IWebElement>)val37).Count > 0);
											if (val38 != null)
											{
												((IWebElement)((IEnumerable<T3>)val37).First()).Click();
											}
											Thread.Sleep(3000);
										}
										else
										{
											val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
											T0 val39 = (T0)(val3 != null && ((ReadOnlyCollection<IWebElement>)val3).Count > 0);
											if (val39 == null)
											{
												goto IL_0601;
											}
											val2 = (T0)1;
											Thread.Sleep(3000);
										}
									}
									catch (Exception ex)
									{
										Console.WriteLine(ex.Message);
										goto IL_0601;
									}
									break;
									IL_0601:
									Thread.Sleep(1000);
								}
								val2 = (T0)1;
								break;
							}
							val2 = (T0)0;
							updateStatus((T4)"Tài khoản đã bị cấm", (T0)1);
							break;
						}
						val2 = (T0)1;
						Thread.Sleep(3000);
						break;
					}
				}
				T0 val40 = val2;
				if (val40 == null)
				{
					isShopeeLogined = false;
				}
				else
				{
					isShopeeLogined = true;
				}
			}
			else
			{
				isShopeeLogined = true;
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
			frmMain.SetCellText<T0, T5, T4>((T5)indexEntity, (T4)"Message", (T4)ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Login_Shopee_By_Account<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_01da: Expected I4, but got O
		//IL_01dc: Expected O, but got I4
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_025a: Expected O, but got I4
		//IL_0265: Expected I4, but got O
		//IL_0267: Expected O, but got I4
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_02da: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_0321: Expected O, but got I4
		//IL_0361: Expected O, but got I4
		//IL_0375: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_03ce: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			goUrl<T4, T0, T1, T6, T7, T3>((T3)frmMain.RESOUCE_SHOPEE_HOME);
			Thread.Sleep(2000);
			addon_closeAds<T1, T0, T6>();
			addon_page_is_showing<T1, T0>();
			T0 val2 = (T0)0;
			T1 val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
			T0 val4 = (T0)(val3 == null || ((ReadOnlyCollection<IWebElement>)val3).Count <= 0);
			if (val4 == null)
			{
				isShopeeLogined = true;
				return;
			}
			T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__link"));
			T2 val5 = (T2)((IEnumerable<T6>)source).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("đăng nhập")))).ToList();
			T0 val6 = (T0)(((List<IWebElement>)val5).Count > 0);
			if (val6 != null)
			{
				((IWebElement)((IEnumerable<T6>)val5).First()).Click();
				Thread.Sleep(1500);
			}
			addon_closeAds<T1, T0, T6>();
			while (true)
			{
				T0 val7 = (T0)frmMain.isRunning;
				if (val7 != null)
				{
					T1 val8 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("loginKey"));
					T0 val9 = (T0)(((ReadOnlyCollection<IWebElement>)val8).Count > 0);
					if (val9 == null)
					{
						val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
						T0 val10 = (T0)(val3 != null && ((ReadOnlyCollection<IWebElement>)val3).Count > 0);
						if (val10 == null)
						{
							Thread.Sleep(1500);
							continue;
						}
						val2 = (T0)1;
						isShopeeLogined = true;
						break;
					}
					val2 = (T0)0;
					break;
				}
				break;
			}
			T0 val11 = (T0)(val2 == null);
			if (val11 == null)
			{
				return;
			}
			T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("loginKey"));
			((IWebElement)((IEnumerable<T6>)source2).First()).Click();
			((IWebElement)((IEnumerable<T6>)source2).First()).Clear();
			Thread.Sleep(500);
			T3 shopee_UserName = (T3)frmMain.listFBEntity[indexEntity].Shopee_UserName;
			T4 val12 = (T4)0;
			while ((nint)val12 < ((string)shopee_UserName).Length)
			{
				T5 val13 = (T5)((string)shopee_UserName)[(int)val12];
				((IWebElement)((IEnumerable<T6>)source2).First()).SendKeys(((char*)(&val13))->ToString());
				val12 = (T4)(val12 + 1);
			}
			T1 source3 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("password"));
			((IWebElement)((IEnumerable<T6>)source3).First()).Click();
			((IWebElement)((IEnumerable<T6>)source3).First()).Clear();
			Thread.Sleep(500);
			T3 shopee_Password = (T3)frmMain.listFBEntity[indexEntity].Shopee_Password;
			T4 val14 = (T4)0;
			while ((nint)val14 < ((string)shopee_Password).Length)
			{
				T5 val15 = (T5)((string)shopee_Password)[(int)val14];
				((IWebElement)((IEnumerable<T6>)source3).First()).SendKeys(((char*)(&val15))->ToString());
				val14 = (T4)(val14 + 1);
			}
			Thread.Sleep(1500);
			((IWebElement)((IEnumerable<T6>)source3).First()).SendKeys(Keys.Enter);
			Thread.Sleep(5000);
			while (true)
			{
				T0 val16 = (T0)frmMain.isRunning;
				if (val16 == null)
				{
					break;
				}
				val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
				T0 val17 = (T0)(val3 != null && ((ReadOnlyCollection<IWebElement>)val3).Count > 0);
				if (val17 == null)
				{
					T1 val18 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("stardust-icon-cross-with-circle"));
					T0 val19 = (T0)(val18 != null && ((ReadOnlyCollection<IWebElement>)val18).Count > 0);
					if (val19 == null)
					{
						Thread.Sleep(1500);
						continue;
					}
					isShopeeLogined = false;
					T6 parent = GetParent(GetParent(((IEnumerable<T6>)val18).First()));
					frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Shopee_Status", (T3)((IWebElement)parent).Text);
					break;
				}
				isShopeeLogined = true;
				break;
			}
			T0 val20 = (T0)(!isShopeeLogined);
			if (val20 != null)
			{
				frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)frmMain.STATUS.lỗi.ToString());
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addon_page_is_showing<T0, T1>()
	{
		//IL_0040: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		T0 val = (T0)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-searchbar-input__input"));
		while (true)
		{
			T1 val2 = (T1)frmMain.isRunning;
			if (val2 != null)
			{
				val = (T0)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-searchbar-input__input"));
				T1 val3 = (T1)(val != null && ((ReadOnlyCollection<IWebElement>)val).Count > 0);
				if (val3 == null)
				{
					Thread.Sleep(3000);
					continue;
				}
				break;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void addon_closeAds<T0, T1, T2>()
	{
		//IL_0021: Expected O, but got I4
		T0 val = (T0)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-popup__close-btn"));
		T1 val2 = (T1)(((ReadOnlyCollection<IWebElement>)val).Count > 0);
		if (val2 != null)
		{
			((IWebElement)((IEnumerable<T2>)val).First()).Click();
			Thread.Sleep(2000);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 addon_check_product_show_all<T0, T1, T2, T3>()
	{
		//IL_0051: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		T0 val = (T0)((RemoteWebDriver)chrome).FindElements(By.ClassName("shopee-search-item-result__item"));
		T1 val2 = (T1)((IEnumerable<T3>)val).Where((Func<T3, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T3 a) => (T2)(((ISearchContext)a).FindElements(By.TagName("a")) != null && ((ISearchContext)a).FindElements(By.TagName("a")).Count > 0 && ((IWebElement)((IEnumerable<T3>)((ISearchContext)a).FindElements(By.TagName("a"))).First()).GetAttribute("href") != null && !string.IsNullOrWhiteSpace(((IWebElement)((IEnumerable<T3>)((ISearchContext)a).FindElements(By.TagName("a"))).First()).GetAttribute("href"))))).ToList();
		T2 val3 = (T2)(((List<IWebElement>)val2).Count == ((ReadOnlyCollection<IWebElement>)val).Count);
		if (val3 == null)
		{
			return (T2)0;
		}
		return (T2)1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Register_Shpoee_By_Fb<T0, T1, T2, T3, T4, T5, T6, T7, T8>(FBFlow flow)
	{
		//IL_0031: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0235: Expected O, but got I4
		//IL_027e: Expected O, but got I4
		//IL_0286: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e9: Expected O, but got I4
		//IL_02fc: Expected O, but got I4
		//IL_0331: Expected O, but got I4
		//IL_038d: Expected O, but got I4
		//IL_0392: Expected O, but got I4
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03be: Expected O, but got I4
		//IL_03ee: Expected O, but got I4
		//IL_040f: Expected O, but got I4
		//IL_043c: Expected O, but got I4
		//IL_04a1: Expected O, but got I4
		//IL_04e9: Expected O, but got I4
		//IL_04fd: Expected O, but got I4
		//IL_0523: Expected O, but got I4
		//IL_052e: Expected I4, but got O
		//IL_0530: Expected O, but got I4
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_0590: Expected O, but got I4
		//IL_05a6: Expected O, but got I4
		//IL_05ad: Expected O, but got I4
		//IL_05d2: Expected O, but got I4
		//IL_05d9: Expected O, but got I4
		//IL_0604: Expected O, but got I4
		//IL_064b: Expected O, but got I4
		//IL_0652: Expected O, but got I4
		//IL_06ae: Expected O, but got I4
		//IL_06cb: Expected O, but got I4
		//IL_06ea: Expected O, but got I4
		//IL_0707: Expected O, but got I4
		//IL_0726: Expected O, but got I4
		//IL_0745: Expected O, but got I4
		//IL_0773: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null || !frmMain.listFBEntity[indexEntity].Select);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)(((RemoteWebDriver)chrome).Url.ToLower().Contains("shopee.vn") && !((RemoteWebDriver)chrome).Url.ToLower().Contains("login") && !((RemoteWebDriver)chrome).Url.ToLower().Contains("signup"));
			if (val2 == null)
			{
				goUrl<T4, T0, T1, T6, T8, T3>((T3)frmMain.RESOUCE_SHOPEE_HOME);
				Thread.Sleep(2000);
				addon_page_is_showing<T1, T0>();
			}
			addon_closeAds<T1, T0, T6>();
			Thread.Sleep(5000);
			T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__link"));
			T2 val3 = (T2)((IEnumerable<T6>)source).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("đăng ký")))).ToList();
			T0 val4 = (T0)(val3 != null && ((List<IWebElement>)val3).Count > 0);
			if (val4 != null)
			{
				T3 val5 = frmMain.RandomString<T3, T4, T7>((T4)16);
				val5 = (T3)((string)val5 + System.Runtime.CompilerServices.Unsafe.As<T4, int>(ref (T4)rnd.Next(1978, 2004)));
				frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Shopee_UserName", val5);
				((IWebElement)((IEnumerable<T6>)val3).First()).Click();
				Thread.Sleep(1500);
				T1 val6 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("phone"));
				while (true)
				{
					T0 val7 = (T0)frmMain.isRunning;
					if (val7 == null)
					{
						break;
					}
					T0 val8 = (T0)(val6 != null && ((ReadOnlyCollection<IWebElement>)val6).Count > 0);
					if (val8 != null)
					{
						break;
					}
					Thread.Sleep(2000);
					val6 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("phone"));
				}
				T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
				T2 val9 = (T2)((IEnumerable<T6>)source2).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.ToLower().Equals("facebook")))).ToList();
				T0 val10 = (T0)(val9 != null && ((List<IWebElement>)val9).Count > 0);
				if (val10 != null)
				{
					((IWebElement)((IEnumerable<T6>)val9).First()).Click();
					Thread.Sleep(2000);
					string chromeCurrent = ((RemoteWebDriver)chrome).CurrentWindowHandle;
					T5 windowHandles = (T5)((RemoteWebDriver)chrome).WindowHandles;
					T6 val11 = (T6)null;
					T4 val12 = (T4)0;
					while (true)
					{
						T0 val13 = (T0)(((ReadOnlyCollection<string>)windowHandles).Count == 1 && frmMain.isRunning);
						if (val13 == null)
						{
							break;
						}
						windowHandles = (T5)((RemoteWebDriver)chrome).WindowHandles;
						T0 val14 = (T0)(((ReadOnlyCollection<string>)windowHandles).Count == 1);
						if (val14 != null)
						{
							T1 val15 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("username"));
							T0 val16 = (T0)(val15 != null && ((ReadOnlyCollection<IWebElement>)val15).Count > 0);
							if (val16 != null)
							{
								val11 = ((IEnumerable<T6>)val15).First();
								break;
							}
						}
						val12 = (T4)(val12 + 1);
						T0 val17 = (T0)((nint)val12 >= 5);
						if (val17 != null)
						{
							((IWebElement)((IEnumerable<T6>)val9).First()).Click();
							val12 = (T4)0;
						}
						Thread.Sleep(2000);
					}
					T0 val18 = (T0)(val11 == null);
					if (val18 != null)
					{
						T3 val19 = ((IEnumerable<T3>)windowHandles).Where((Func<T3, bool>)(object)(Func<string, bool>)((T3 a) => (T0)(!((string)a).Equals(chromeCurrent)))).First();
						((RemoteWebDriver)chrome).SwitchTo().Window((string)val19);
						_ = ((RemoteWebDriver)chrome).CurrentWindowHandle;
						T1 val20 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("__CONFIRM__"));
						val12 = (T4)0;
						while (true)
						{
							T0 val21 = (T0)(val20 == null && frmMain.isRunning);
							if (val21 == null)
							{
								break;
							}
							val20 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("__CONFIRM__"));
							val12 = (T4)(val12 + 1);
							T0 val22 = (T0)((nint)val12 >= 5);
							if (val22 != null)
							{
								break;
							}
							Thread.Sleep(2000);
						}
						T0 val23 = (T0)(val20 != null && ((ReadOnlyCollection<IWebElement>)val20).Count > 0);
						if (val23 == null)
						{
							frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)"Chưa đăng nhập Facebook!");
						}
						else
						{
							((IWebElement)((IEnumerable<T6>)val20).First()).Click();
							Thread.Sleep(2000);
							windowHandles = (T5)((RemoteWebDriver)chrome).WindowHandles;
							while (true)
							{
								T0 val24 = (T0)(((ReadOnlyCollection<string>)windowHandles).Count > 1 && frmMain.isRunning);
								if (val24 == null)
								{
									break;
								}
								windowHandles = (T5)((RemoteWebDriver)chrome).WindowHandles;
								Thread.Sleep(2000);
							}
							((RemoteWebDriver)chrome).SwitchTo().Window(chromeCurrent);
							T1 val25 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("username"));
							while (true)
							{
								T0 val26 = (T0)(val25 == null && frmMain.isRunning);
								if (val26 == null)
								{
									break;
								}
								val25 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("username"));
								Thread.Sleep(2000);
							}
							T0 val27 = (T0)(val25 != null && ((ReadOnlyCollection<IWebElement>)val25).Count > 0);
							if (val27 != null)
							{
								val11 = ((IEnumerable<T6>)val25).First();
							}
						}
					}
					T0 val28 = (T0)(val11 != null);
					if (val28 == null)
					{
						return;
					}
					((IWebElement)val11).Click();
					((IWebElement)val11).Clear();
					Thread.Sleep(1500);
					T3 val29 = val5;
					T4 val30 = (T4)0;
					while ((nint)val30 < ((string)val29).Length)
					{
						((IWebElement)val11).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T7, char>(ref (T7)((string)val29)[(int)val30]).ToString());
						Thread.Sleep(rnd.Next(10, 50));
						val30 = (T4)(val30 + 1);
					}
					Thread.Sleep(3000);
					T1 val31 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
					T0 val32 = (T0)(((ReadOnlyCollection<IWebElement>)val31).Count > 0);
					if (val32 == null)
					{
						return;
					}
					((IWebElement)((IEnumerable<T6>)val31).Last()).Click();
					T0 val33 = (T0)0;
					while (true)
					{
						T0 val34 = (T0)frmMain.isRunning;
						if (val34 == null)
						{
							break;
						}
						try
						{
							T0 val35 = (T0)((RemoteWebDriver)chrome).PageSource.ToLower().Contains("đăng ký thành công");
							if (val35 != null)
							{
								val33 = (T0)1;
								T1 val36 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
								T0 val37 = (T0)(val36 != null && ((ReadOnlyCollection<IWebElement>)val36).Count > 0);
								if (val37 != null)
								{
									((IWebElement)((IEnumerable<T6>)val36).First()).Click();
								}
								Thread.Sleep(3000);
							}
							else
							{
								T1 val38 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("navbar__username"));
								T0 val39 = (T0)(val38 != null && ((ReadOnlyCollection<IWebElement>)val38).Count > 0);
								if (val39 == null)
								{
									goto IL_0670;
								}
								val33 = (T0)1;
								Thread.Sleep(3000);
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
							goto IL_0670;
						}
						break;
						IL_0670:
						Thread.Sleep(1000);
					}
					T0 val40 = val33;
					if (val40 == null)
					{
						frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)frmMain.STATUS.lỗi.ToString());
						frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Shopee_Status", (T3)"Đăng ký không thành công!");
					}
					else
					{
						frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)"Đăng ký Shopee thành công!");
						frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Shopee_Status", (T3)"Đăng ký thành công!");
					}
				}
				else
				{
					frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)"Không tìm thấy button Facebook!");
				}
			}
			else
			{
				frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)"TK đã đăng nhập");
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
			frmMain.SetCellText<T0, T4, T3>((T4)indexEntity, (T3)"Message", (T3)ex2.Message);
			Register_Shpoee_By_Fb<T0, T1, T2, T3, T4, T5, T6, T7, T8>(flow);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getToken<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 pattern, T2 url)
	{
		//IL_0002: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0128: Expected I4, but got O
		//IL_012e: Expected O, but got I4
		//IL_013d: Expected I4, but got O
		//IL_013f: Expected O, but got I4
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0160: Expected O, but got I4
		//IL_0171: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_01ba: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		T0 result = (T0)0;
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return result;
		}
		try
		{
			goUrl<T5, T0, T1, T9, T8, T2>(url);
			Thread.Sleep(2000);
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("input"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count >= 2 && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Code2FA));
			if (val3 != null)
			{
				((IWebElement)((IEnumerable<T9>)val2).Last()).Click();
				T2 val4 = authenCode<T5, T0, T2, T8, byte, T6>((T2)frmMain.listFBEntity[indexEntity].Code2FA);
				((IWebElement)((IEnumerable<T9>)val2).Last()).SendKeys((string)val4);
				Thread.Sleep(100);
				((IWebElement)((IEnumerable<T9>)val2).Last()).SendKeys(Keys.Enter);
				Thread.Sleep(5000);
			}
			T2 pageSource = (T2)((RemoteWebDriver)chrome).PageSource;
			T2 val5 = (T2)"";
			T2 input = pageSource;
			T3 enumerator = (T3)Regex.Matches((string)input, (string)pattern).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					T4 val6 = (T4)((IEnumerator)enumerator).Current;
					T5 val7 = (T5)((Capture)val6).Index;
					while (true)
					{
						T0 val8 = (T0)((nint)val7 < ((string)pageSource).Length);
						if (val8 == null)
						{
							break;
						}
						T0 val9 = (T0)(((string)pageSource)[(int)val7] == '"');
						if (val9 != null)
						{
							break;
						}
						val5 = (T2)((string)val5 + System.Runtime.CompilerServices.Unsafe.As<T6, char>(ref (T6)((string)pageSource)[(int)val7]));
						val7 = (T5)(val7 + 1);
					}
					T0 val10 = (T0)(((string)val5).Length > 50);
					if (val10 == null)
					{
						val5 = (T2)"";
						continue;
					}
					break;
				}
			}
			finally
			{
				T7 val11 = (T7)((enumerator is T7) ? enumerator : null);
				if (val11 != null)
				{
					((IDisposable)val11).Dispose();
				}
			}
			T0 val12 = (T0)(!string.IsNullOrEmpty((string)val5));
			if (val12 != null)
			{
				T0 val13 = (T0)((string)pattern).Equals("EAAB");
				if (val13 == null)
				{
					frmMain.listFBEntity[indexEntity].TokenEAAG = (string)val5;
				}
				else
				{
					frmMain.listFBEntity[indexEntity].TokenEAAB = (string)val5;
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getToken_Fetch<T0, T1, T2, T3, T4, T5, T6, T7>(T1 pattern, T1 url)
	{
		//IL_0002: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		//IL_0072: Expected I4, but got O
		//IL_0078: Expected O, but got I4
		//IL_0086: Expected I4, but got O
		//IL_0088: Expected O, but got I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00a8: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_0125: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		T0 result = (T0)0;
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val == null)
		{
			try
			{
				goUrl<T4, T0, ReadOnlyCollection<IWebElement>, IWebElement, T7, T1>((T1)"https://adsmanager.facebook.com/adsmanager/manage/accounts?nav_source=no_referre");
				T1 pageSource = (T1)((RemoteWebDriver)chrome).PageSource;
				T1 val2 = (T1)"";
				T1 input = pageSource;
				T2 enumerator = (T2)Regex.Matches((string)input, (string)pattern).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						T3 val3 = (T3)((IEnumerator)enumerator).Current;
						T4 val4 = (T4)((Capture)val3).Index;
						while (true)
						{
							T0 val5 = (T0)((nint)val4 < ((string)pageSource).Length);
							if (val5 == null)
							{
								break;
							}
							T0 val6 = (T0)(((string)pageSource)[(int)val4] == '"');
							if (val6 != null)
							{
								break;
							}
							val2 = (T1)((string)val2 + System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)((string)pageSource)[(int)val4]));
							val4 = (T4)(val4 + 1);
						}
						T0 val7 = (T0)(((string)val2).Length > 50);
						if (val7 == null)
						{
							val2 = (T1)"";
							continue;
						}
						break;
					}
				}
				finally
				{
					T6 val8 = (T6)((enumerator is T6) ? enumerator : null);
					if (val8 != null)
					{
						((IDisposable)val8).Dispose();
					}
				}
				T0 val9 = (T0)(!string.IsNullOrEmpty((string)val2));
				if (val9 != null)
				{
					T0 val10 = (T0)((string)pattern).Equals("EAAB");
					if (val10 != null)
					{
						frmMain.listFBEntity[indexEntity].TokenEAAB = (string)val2;
					}
					result = (T0)1;
				}
				T0 val11 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business"));
				if (val11 != null)
				{
					goUrl<T4, T0, ReadOnlyCollection<IWebElement>, IWebElement, T7, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getToken_EEAG_Fetch<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
	{
		//IL_0002: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00cd: Expected I4, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00e1: Expected I4, but got O
		//IL_00e3: Expected O, but got I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0103: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val).Add("str2FACode", (string)authenCode<T5, T0, T2, T8, byte, T6>((T2)frmMain.listFBEntity[indexEntity].Code2FA));
			T2 resouce = (T2)ResouceControl.getResouce("confirm_2fa_get_token_eeag", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, IJavaScriptExecutor, T5, T0, object>(resouce);
			val2 = fetch_url<T1, T2, T8>((T2)"https://business.facebook.com/business_locations/?nav_source=flyout_menu&nav_id=1059597948");
			T2 val3 = (T2)"";
			T2 pattern = (T2)"EAAG";
			T2 input = val2;
			T3 enumerator = (T3)Regex.Matches((string)input, (string)pattern).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					T4 val4 = (T4)((IEnumerator)enumerator).Current;
					T5 val5 = (T5)((Capture)val4).Index;
					while (true)
					{
						T0 val6 = (T0)((nint)val5 < ((string)val2).Length);
						if (val6 == null)
						{
							break;
						}
						T0 val7 = (T0)(((string)val2)[(int)val5] == '"');
						if (val7 != null)
						{
							break;
						}
						val3 = (T2)((string)val3 + System.Runtime.CompilerServices.Unsafe.As<T6, char>(ref (T6)((string)val2)[(int)val5]));
						val5 = (T5)(val5 + 1);
					}
					T0 val8 = (T0)(((string)val3).Length > 50);
					if (val8 == null)
					{
						val3 = (T2)"";
						continue;
					}
					break;
				}
			}
			finally
			{
				T7 val9 = (T7)((enumerator is T7) ? enumerator : null);
				if (val9 != null)
				{
					((IDisposable)val9).Dispose();
				}
			}
			T0 val10 = (T0)(!string.IsNullOrEmpty((string)val3));
			if (val10 != null)
			{
				frmMain.listFBEntity[indexEntity].TokenEAAG = (string)val3;
			}
			T0 val11 = (T0)(string.IsNullOrEmpty(frmMain.listFBEntity[indexEntity].TokenEAAG) && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB));
			if (val11 != null)
			{
				frmMain.listFBEntity[indexEntity].TokenEAAG = frmMain.listFBEntity[indexEntity].TokenEAAB;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChromeControl(string strProxy, int index, frmMain main, int flag)
	{
		object obj = Activator.CreateInstance(typeof(List<bool>));
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		listRandomBool = (List<bool>)obj;
		listTempString = (List<string>)Activator.CreateInstance(typeof(List<string>));
		listFriendAdded = (List<string>)Activator.CreateInstance(typeof(List<string>));
		countAddFriends = 0;
		countError = 0;
		countCheckSuccess = 0;
		base._002Ector();
		try
		{
			ResouceControl.RESOUCE_VERSION = "ResouceV2";
			ResouceControl.API_URL = "https://api.meta-soft.tech/";
			this.strProxy = strProxy;
			indexEntity = index;
			frmMain = main;
			switch (flag)
			{
			case 1:
			{
				foreach (FBFlow item in frmMain.listFBEntity[indexEntity].Flow)
				{
					if (!frmMain.listFBEntity[indexEntity].Select || !frmMain.isRunning)
					{
						break;
					}
					if (item.Flow_Name.Equals("Mở_trình_duyệt"))
					{
						Open_Browser<bool, ChromeDriverService, string, Rectangle, int, TimeSpan, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Đăng_nhập"))
					{
						countError = 0;
						Đăng_nhập<bool, ReadOnlyCollection<IWebElement>, IWebElement, string, int, char, List<IWebElement>, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Delay"))
					{
						Delay<int, bool, string>(item);
					}
					else if (item.Flow_Name.Equals("Truy_cập_link"))
					{
						GoToUrl<string, int, bool>(item);
					}
					else if (item.Flow_Name.Equals("Tương_tác_live_stream"))
					{
						Live_Stream<List<LiveStreamSedding>, List<bool>, bool, List<LiveStreamSedding>.Enumerator, ReadOnlyCollection<IWebElement>, IWebElement, string, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Like_share_bài_viết"))
					{
						Like_share_bài_viết<bool, string, int, ReadOnlyCollection<IWebElement>, Exception, IWebElement, IJavaScriptExecutor, object>(item);
					}
					else if (item.Flow_Name.Equals("Post_bài_group"))
					{
						Post_bài_group<bool, int, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Post_bài_lên_tường"))
					{
						Post_bài_lên_tường<bool, int, ReadOnlyCollection<IWebElement>, IWebElement, IEnumerator<IWebElement>, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Tương_tác_dạo"))
					{
						Tương_tác_dạo<bool, string, int, List<IWebElement>, ReadOnlyCollection<IWebElement>, IEnumerator<IWebElement>, IWebElement, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Tương_tác_marketplace"))
					{
						Tương_tác_marketplace<bool, string, int, IWebElement, ReadOnlyCollection<IWebElement>, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Tham_gia_nhóm"))
					{
						Tham_gia_nhóm<bool, int, Dictionary<string, string>, string, Exception, IJavaScriptExecutor, object>(item);
					}
					else if (item.Flow_Name.Equals("Rời_khỏi_nhóm"))
					{
						Rời_khỏi_nhóm<bool, string, List<GroupFBEntity>, int, List<GroupFBEntity>.Enumerator, Exception, IJavaScriptExecutor, object>(item);
					}
					else if (item.Flow_Name.Equals("Kết_bạn_theo_gợi_ý") && isLogined)
					{
						Add_Friend_Sugguested_By_Facebook<bool, int, ReadOnlyCollection<IWebElement>, IWebElement, Exception, string>(item);
					}
					else if (item.Flow_Name.Equals("Kết_bạn_theo_UID") && isLogined)
					{
						Add_Friend_By_UID_Facebook<bool, int, string, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Kết_bạn_theo_profile_đối_thủ") && isLogined)
					{
						Add_Friend_By_Rival<int, bool, ReadOnlyCollection<IWebElement>, IWebElement, string, IEnumerator<IWebElement>, Exception, char>(item);
					}
					else if (item.Flow_Name.Equals("Chấp_nhận_kết_bạn") && isLogined)
					{
						Accept_Friend<bool, string, int, ReadOnlyCollection<IWebElement>, List<IWebElement>, IWebElement, IEnumerator<IWebElement>, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Hủy_kết_bạn") && isLogined)
					{
						Outgoing_Friend<bool, int, string, Exception>(item);
					}
					else if (item.Flow_Name.Equals("Post_bài_trên_newfeed") && isLogined)
					{
						Post_on_newfeed<bool, string, int, List<ImagesList>, IWebElement, ReadOnlyCollection<IWebElement>, IEnumerator<IWebElement>, List<ImagesList>.Enumerator, Exception, Guid>(item);
					}
					else if (item.Flow_Name.Equals("Spam_support") && isLogined)
					{
						Spam_support<bool, string, List<SpamSupportEntity>, int, List<SpamSupportEntity>.Enumerator, ReadOnlyCollection<IWebElement>, IWebElement, IEnumerator<IWebElement>, Exception>(item);
					}
					else
					{
						if ((item.Flow_Name.Equals("Comment_Post_On_Newfeed") && isLogined) || (item.Flow_Name.Equals("Join_Group") && isLogined) || (item.Flow_Name.Equals("Change_Password") && isLogined))
						{
							continue;
						}
						if (item.Flow_Name.Equals("Tạo_Page") && isLogined)
						{
							Tạo_Page<bool, int, string, Exception>(item);
						}
						else if (item.Flow_Name.Equals("Tạo_BM") && isLogined)
						{
							Tạo_BM<bool, int, string, List<string>, List<BusinessManagerEntity_businesses_Data>, Exception>(item);
						}
						else
						{
							if (item.Flow_Name.Equals("Tút_10$_BM") && isLogined)
							{
								continue;
							}
							if (item.Flow_Name.Equals("Lên_camp_chuyển_đổi") && isLogined)
							{
								Lên_camp_chuyển_đổi<bool, string, int, List<facebook_pagesData>, List<facebook_pagesData>.Enumerator, List<adaccountsData>.Enumerator, List<TokenEntity>.Enumerator, Dictionary<string, string>, List<addraft_fragments_2_data>.Enumerator, Image, MemoryStream, byte, List<addraft_fragments_data>.Enumerator, Exception>(item);
							}
							else if (item.Flow_Name.Equals("Set_camp_PE") && isLogined)
							{
								Set_camp_PE<bool, string, int, List<ListStringData>, List<object>, List<adaccountsData>.Enumerator, List<ADSPRoject.Data.billing_payment_methods>.Enumerator, List<addraft_fragments_2_data>.Enumerator, Dictionary<string, string>, List<ListStringData>.Enumerator, Exception, char>(item);
							}
							else if (item.Flow_Name.Equals("Lên_camp_boostpost_30e") && isLogined)
							{
								Lên_camp_boostpost_30e<bool, string, int, List<facebook_pagesData>, List<facebook_pagesData>.Enumerator, List<string>, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<adaccountsData>.Enumerator, Dictionary<string, string>, Guid, Exception, ReadOnlyCollection<IWebElement>, IWebElement, List<ADSPRoject.Data.billing_payment_methods>.Enumerator>(item);
							}
							else if (item.Flow_Name.Equals("Tạo_page_nhanh") && isLogined)
							{
								Tạo_page_nhanh<bool, string, char, Exception, object, int>(item);
							}
							else if (item.Flow_Name.Equals("Share_page_đối_tác") && isLogined)
							{
								Share_page_đối_tác<bool, string, List<BusinessManagerEntity_businesses_Data>, int, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<TokenEntity>.Enumerator, Dictionary<string, string>, List<available_permission_tasks_ui_configs>.Enumerator, List<ADSPRoject.Data.business_users_data>.Enumerator, Exception, char>(item);
							}
							else if (item.Flow_Name.Equals("Share_pixel") && isLogined)
							{
								Share_pixel<bool, List<adaccountsData>.Enumerator, string, List<TokenEntity>.Enumerator, Exception>(item);
							}
							else if (item.Flow_Name.Equals("Tạo_Tk_trong_BM") && isLogined)
							{
								Tạo_Tk_trong_BM<bool, string, List<BusinessManagerEntity_businesses_Data>, int, List<BusinessManagerEntity_businesses_Data>.Enumerator, Exception, Dictionary<string, string>>(item);
							}
							else if (item.Flow_Name.Equals("Lưu_ID_TKQC") && isLogined)
							{
								Lưu_ID_TKQC<bool, string, List<adaccountsData>.Enumerator, Exception>(item);
							}
							else if (item.Flow_Name.Equals("Add_thẻ") && isLogined)
							{
								Add_thẻ<bool, int, string, List<CreditCardEntity>, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<adaccountsData>.Enumerator, List<facebook_pagesData>, List<string>, List<facebook_pagesData>.Enumerator, List<category_list>.Enumerator, List<string>.Enumerator, List<ListStringData>, DateTime, List<ListStringData>.Enumerator, List<CreditCardEntity>.Enumerator, List<ADSPRoject.Data.billing_payment_methods>.Enumerator, Dictionary<string, string>, IWebElement, ReadOnlyCollection<IWebElement>, IJavaScriptExecutor, Exception, char, object, List<ADSPRoject.Data.business_users_data>.Enumerator, List<object>>(item);
							}
							else if (item.Flow_Name.Equals("Add_thẻ_từ_BM") && isLogined)
							{
								Add_thẻ_từ_BM<bool, string, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<adaccountsData>.Enumerator, int, Exception, Dictionary<string, string>>(item);
							}
							else if (item.Flow_Name.Equals("Xóa_thẻ") && isLogined)
							{
								Xóa_thẻ<bool, string, List<adaccountsData>.Enumerator, Exception, Dictionary<string, string>, List<ADSPRoject.Data.billing_payment_methods>.Enumerator, int>(item);
							}
							else if (item.Flow_Name.Equals("Set_limit") && isLogined)
							{
								Set_limit<bool, string, List<adaccountsData>.Enumerator, Dictionary<string, string>, Exception>(item);
							}
							else if (item.Flow_Name.Equals("Approved_hold") && isLogined)
							{
								Approved_hold<bool, List<adaccountsData>.Enumerator, Exception>(item);
							}
							else if (item.Flow_Name.Equals("Tạo_Tk_Cá_Nhân") && isLogined)
							{
								Tạo_Tk_Cá_Nhân<bool, string, List<adaccountsData>.Enumerator, int, Exception, Dictionary<string, string>>(item);
							}
							else if (item.Flow_Name.Equals("Share_Tk_Cá_Nhân_Vào_BM") && isLogined)
							{
								Share_Tk_Cá_Nhân_Vào_BM<bool, List<ListStringData>, List<adaccountsData>.Enumerator, string, int, Exception>(item);
							}
							else if (item.Flow_Name.Equals("Share_Tk_BM_sang_BM_đối_tác") && isLogined)
							{
								Share_Tk_BM_sang_BM_đối_tác<bool, string, List<BusinessManagerEntity_businesses_Data>, int, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<adaccountsData>.Enumerator, Exception, Dictionary<string, string>, List<ADSPRoject.Data.business_users_data>.Enumerator>(item);
							}
							else if (!item.Flow_Name.Equals("Logout") || !isLogined)
							{
								if (item.Flow_Name.Equals("Delay"))
								{
									int num = int.Parse(item.getValue<object, List<FBFlowField>, bool, string>("Delay").ToString());
									Thread.Sleep(num * 1000);
								}
								else if (item.Flow_Name.Equals("Close_Browser"))
								{
									Close_Browser<bool, string, IEnumerator<Cookie>, Cookie, Exception>(item);
								}
							}
						}
					}
				}
				break;
			}
			case 2:
				openChromeNoFollow<List<FBFlowField>, bool>(isHidden: false);
				break;
			case 4:
			{
				List<FBFlowField> list = (List<FBFlowField>)Activator.CreateInstance(typeof(List<FBFlowField>));
				openChromeNoFollow<List<FBFlowField>, bool>(isHidden: false);
				list.Clear();
				Login_Shopee_By_Account<bool, ReadOnlyCollection<IWebElement>, List<IWebElement>, string, int, char, IWebElement, Exception>(new FBFlow
				{
					Flow_Name = "Đăng_Nhập_Shopee_By_Account",
					Filed = list
				});
				break;
			}
			case 6:
			{
				openChromeNoFollow<List<FBFlowField>, bool>(isHidden: false);
				frmReMarketing frmReMarketing2 = new frmReMarketing(this);
				frmReMarketing2.ShowDialog();
				break;
			}
			case 7:
				openChromeNoFollow<List<FBFlowField>, bool>(isHidden: false);
				Live_Stream<List<LiveStreamSedding>, List<bool>, bool, List<LiveStreamSedding>.Enumerator, ReadOnlyCollection<IWebElement>, IWebElement, string, Exception>(new FBFlow());
				break;
			case 15:
				openChromeNoFollow<List<FBFlowField>, bool>(isHidden: false);
				isLogined = true;
				break;
			case 16:
				openChromeNoFollow<List<FBFlowField>, bool>(isHidden: false);
				isLogined = true;
				resole956_MBasic<string, ReadOnlyCollection<IWebElement>, ReadOnlyCollection<string>, int, bool, char, Exception, IJavaScriptExecutor, object, IWebElement>();
				break;
			case 8:
			case 12:
			case 13:
			case 14:
				switch (flag)
				{
				case 8:
					taskOpenChrome<List<FBFlowField>, bool, int>(10);
					break;
				case 12:
					taskOpenChrome<List<FBFlowField>, bool, int>(5);
					break;
				case 13:
					taskOpenChrome<List<FBFlowField>, bool, int>(11);
					break;
				case 14:
					taskOpenChrome<List<FBFlowField>, bool, int>(0);
					break;
				}
				if (isLogined)
				{
					frmAdsManager frmAdsManager2 = new frmAdsManager(this);
					frmAdsManager2.ShowDialog();
				}
				break;
			case 3:
			case 5:
			case 10:
			case 11:
				taskOpenChrome<List<FBFlowField>, bool, int>(flag);
				break;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private T0 getIndexCard<T0, T1, T2>(T2 creditCardEntities)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_000d: Expected I4, but got O
		//IL_0027: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0039: Expected O, but got I4
		//IL_0048: Expected I4, but got O
		T0 result = (T0)(-1);
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < ((List<CreditCardEntity>)creditCardEntities).Count);
			if (val2 != null)
			{
				T1 val3 = (T1)((List<CreditCardEntity>)creditCardEntities)[(int)val].Status.Equals(frmMain.STATUS.Ready.ToString());
				if (val3 == null)
				{
					val = (T0)(val + 1);
					continue;
				}
				result = val;
				((List<CreditCardEntity>)creditCardEntities)[(int)val].Status = frmMain.STATUS.Used.ToString();
				break;
			}
			break;
		}
		return result;
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
			getFullAdsInfo<Dictionary<string, string>, T1, T0, ReadOnlyCollection<IWebElement>, IEnumerator, Match, int, char, IDisposable, T3, IWebElement>();
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
	public unsafe void Share_Tk_BM_sang_BM_đối_tác<T0, T1, T2, T3, T4, T5, T6, T7, T8>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0139: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 partner_Id = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"BM_TK_Gốc").ToString();
			T1 strError = (T1)"";
			T2 val2 = mtLoadBM<T7, T1, T0, T2, T6>(out *(string*)(&strError));
			T0 val3 = (T0)(val2 == null || ((List<BusinessManagerEntity_businesses_Data>)val2).Count <= 0);
			if (val3 == null)
			{
				T3 val4 = (T3)0;
				T3 val5 = (T3)0;
				T4 enumerator = (T4)((List<BusinessManagerEntity_businesses_Data>)val2).GetEnumerator();
				try
				{
					while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
					{
						BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
						adaccounts fullAdsInfo_In_BM = getFullAdsInfo_In_BM<T1, T7, T0, T3, ReadOnlyCollection<IWebElement>, IEnumerator, Match, char, IDisposable, T6, IWebElement, List<adaccountsData>>((T1)current.id, (T0)0, (T3)0, (T3)0, (T1)"");
						T0 val6 = (T0)(fullAdsInfo_In_BM != null && fullAdsInfo_In_BM.data != null);
						if (val6 == null)
						{
							continue;
						}
						T5 enumerator2 = (T5)fullAdsInfo_In_BM.data.GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
							{
								adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
								shareToAdminBM<T7, T1, T8, T0>((T1)current.id, (T1)current2.id.Replace("act_", ""));
								T0 val7 = sharePartner<T0, T7, T1>((T1)current2.id.Replace("act_", ""), (T1)current.id, partner_Id);
								if (val7 == null)
								{
									val5 = (T3)(val5 + 1);
								}
								else
								{
									val4 = (T3)(val4 + 1);
								}
								setMessage((T1)$"Đang share: {val4}", (T0)0);
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
				}
				setMessage((T1)$"Share đối tác: {val4} lỗi: {val5}", (T0)1);
			}
			else
			{
				setMessage((T1)"e:Không có BM", (T0)1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Tạo_Tk_trong_BM<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00ef: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_017a: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"BM_TK_Gốc").ToString();
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Đổi_tên").ToString();
			T1 quốc_Gia = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Quốc_gia_tài_khoản").ToString();
			T1 đổi_tiền_tệ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Tiền_tệ_tài_khoản").ToString();
			T1 đổi_múi_giờ = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Múi_giờ_tài_khoản").ToString();
			T1 strError = (T1)"";
			T2 val4 = mtLoadBM<T6, T1, T0, T2, T5>(out *(string*)(&strError));
			T0 val5 = (T0)(val4 == null || ((List<BusinessManagerEntity_businesses_Data>)val4).Count <= 0);
			if (val5 != null)
			{
				setMessage((T1)"e:Không có BM", (T0)1);
				return;
			}
			bat_che_do_chuyen_nghiep<T6, T1, T0>();
			T3 val6 = (T3)0;
			T4 enumerator = (T4)((List<BusinessManagerEntity_businesses_Data>)val4).GetEnumerator();
			try
			{
				while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
				{
					BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
					T1 id = (T1)current.id;
					setMessage((T1)$"Tạo TK {(T3)(val6 + 1)}", (T0)0);
					T1 strError2 = (T1)"";
					T0 val7 = (T0)string.IsNullOrWhiteSpace((string)val3);
					if (val7 != null)
					{
						val3 = (T1)frmMain.listFBEntity[indexEntity].UID;
					}
					T1 val8 = (T1)createAdsInBM((string)id, (string)val3, (string)đổi_múi_giờ, (string)đổi_tiền_tệ, (string)quốc_Gia, "", "NY", "312 Fayette St", "94105", "Manlius", out *(string*)(&strError2));
					T0 val9 = (T0)string.IsNullOrWhiteSpace((string)val8);
					if (val9 != null)
					{
						setMessage((T1)"e:Tạo TK lỗi", (T0)1);
						continue;
					}
					val6 = (T3)(val6 + 1);
					T0 val10 = (T0)(!string.IsNullOrWhiteSpace((string)val2));
					if (val10 != null)
					{
						sharePartner<T0, T6, T1>(val8, id, val2);
					}
					setMessage((T1)"Tạo TKBM Ok", (T0)1);
				}
			}
			finally
			{
				((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			setMessage((T1)("e:" + ex.Message), (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Chap_nhan_dieu_khoan_camp<T0>()
	{
		T0 resouce = (T0)ResouceControl.getResouce("Chap_nhan_dieu_khoan_camp");
		executeScript<T0, IJavaScriptExecutor, int, bool, object>(resouce);
		Chap_nhan_dieu_khoan_camp_2<Dictionary<string, string>, T0>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 bat_che_do_chuyen_nghiep<T0, T1, T2>()
	{
		//IL_005e: Expected O, but got I4
		//IL_0064: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
		T1 resouce = (T1)ResouceControl.getResouce("bat_che_do_chuyen_nghiep", (Dictionary<string, string>)val);
		T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
		T2 val3 = (T2)((string)val2).ToLower().Contains("success");
		if (val3 == null)
		{
			return (T2)0;
		}
		return (T2)1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Chap_nhan_dieu_khoan_camp_2<T0, T1>()
	{
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
		T1 resouce = (T1)ResouceControl.getResouce("Chap_nhan_dieu_khoan_camp_2", (Dictionary<string, string>)val);
		executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 Get_Payment_Account_Id_BM<T0, T1, T2>(T1 BM_Id)
	{
		//IL_0076: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("BM_ID", (string)BM_Id);
		((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
		T1 resouce = (T1)ResouceControl.getResouce("lay_payment_account_id_bm", (Dictionary<string, string>)val);
		T1 val2 = executeScript<T1, IJavaScriptExecutor, int, T2, object>(resouce);
		BMDetail bMDetail = JsonConvert.DeserializeObject<BMDetail>((string)val2);
		T2 val3 = (T2)(bMDetail != null && !string.IsNullOrWhiteSpace(bMDetail.payment_account_id));
		if (val3 != null)
		{
			return (T1)bMDetail.payment_account_id;
		}
		return (T1)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void setMessage<T0, T1>(T1 message, T0 addToColumnMessage)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(!string.IsNullOrWhiteSpace((string)message));
		if (val != null)
		{
			frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Step", message);
			if (addToColumnMessage != null)
			{
				frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Message", (T1)(frmMain.listFBEntity[indexEntity].Message + ">" + (string)message));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void taskOpenChrome<T0, T1, T2>(T2 flag)
	{
		//IL_0007: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		openChromeNoFollow<T0, T1>((T1)0);
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		FBFlowField fBFlowField = new FBFlowField();
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Login_By_Cookie";
		T1 val2 = (T1)((nint)flag == 5);
		if (val2 != null)
		{
			fBFlowField.value = "true";
		}
		else
		{
			fBFlowField.value = "false";
		}
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Cập_nhật_nhóm";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Cập_nhật_page";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "mbasic.facebook";
		T1 val3 = (T1)((nint)flag == 10);
		if (val3 == null)
		{
			fBFlowField.value = "false";
		}
		else
		{
			fBFlowField.value = "true";
		}
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "m.facebook";
		T1 val4 = (T1)((nint)flag == 11);
		if (val4 == null)
		{
			fBFlowField.value = "false";
		}
		else
		{
			fBFlowField.value = "true";
		}
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Lấy_Token_EAAG";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Lấy_Token_EAAB";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		Đăng_nhập<T1, ReadOnlyCollection<IWebElement>, IWebElement, string, T2, char, List<IWebElement>, Exception>(new FBFlow
		{
			Flow_Name = "Login",
			Filed = (List<FBFlowField>)val
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void getFullAdsInfo<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
	{
		//IL_0023: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_01de: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_0349: Expected O, but got I4
		//IL_0354: Expected O, but got I4
		try
		{
			T2 val = (T2)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val != null)
			{
				getToken<T2, T3, T1, T4, T5, T6, T7, T8, T9, T10>((T1)"EAAB", (T1)ResouceControl.getResouce("RESOUCE_BM_CAMPAIGNS"));
			}
			T0 val2 = (T0)Activator.CreateInstance(typeof(T0));
			T2 val3 = (T2)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG);
			if (val3 != null)
			{
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
			}
			else
			{
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			}
			((Dictionary<string, string>)val2).Add("limit(2000)", "limit(100)");
			T1 resouce = (T1)ResouceControl.getResouce("GetFullInfoAds_2", (Dictionary<string, string>)val2);
			T1 val4 = executeScript<T1, IJavaScriptExecutor, T6, T2, object>(resouce);
			CheckInfo fullAdsInfo = JsonConvert.DeserializeObject<CheckInfo>((string)val4);
			frmMain.listFBEntity[indexEntity].fullAdsInfo = fullAdsInfo;
			while (true)
			{
				T2 val5 = (T2)frmMain.isRunning;
				if (val5 == null)
				{
					break;
				}
				T2 val6 = (T2)(frmMain.listFBEntity[indexEntity].fullAdsInfo != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data != null && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging != null && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging.next));
				if (val6 == null)
				{
					break;
				}
				T1 val7 = fetch_url_business<T0, T1, T9>((T1)frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging.next);
				adaccounts adaccounts = JsonConvert.DeserializeObject<adaccounts>((string)val7);
				T2 val8 = (T2)(adaccounts != null && adaccounts.data != null);
				if (val8 != null)
				{
					frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.AddRange(adaccounts.data);
					frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.paging = adaccounts.paging;
					frmMain.listFBEntity[indexEntity].lbCountLoadAct = frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.Count;
					T2 val9 = (T2)(frmMain.listFBEntity[indexEntity].numMaxAct > 0 && frmMain.listFBEntity[indexEntity].fullAdsInfo.adaccounts.data.Count >= frmMain.listFBEntity[indexEntity].numMaxAct);
					if (val9 != null)
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public adaccounts getFullAdsInfo_In_BM<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 strBMID, T2 isOwned_ad_accounts, T3 indexFilter, T3 indexSort, T0 searchByKeyword)
	{
		//IL_0024: Expected O, but got I4
		//IL_00e4: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected I4, but got Unknown
		//IL_026a: Expected O, but got I4
		//IL_027a: Expected O, but got I4
		//IL_02b9: Expected O, but got I4
		//IL_0361: Expected O, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_03f7: Expected O, but got I4
		//IL_0421: Expected O, but got I4
		//IL_047f: Expected O, but got I4
		//IL_048c: Expected O, but got I4
		//IL_04a1: Expected O, but got I4
		//IL_052c: Expected O, but got I4
		//IL_0584: Expected O, but got I4
		//IL_05c2: Expected O, but got I4
		//IL_05ec: Expected O, but got I4
		adaccounts adaccounts = null;
		try
		{
			T2 val = (T2)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG);
			if (val != null)
			{
				getToken<T2, T4, T0, T5, T6, T3, T7, T8, T9, T10>((T0)"EAAB", (T0)ResouceControl.getResouce("RESOUCE_BM_CAMPAIGNS"));
			}
			T0 resouce = (T0)ResouceControl.getResouce("getAll_Tkqc_In_BM_limit_250");
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val2).Add("strBMID", (string)strBMID);
			((Dictionary<string, string>)val2).Add("v15.0", "v16.0");
			T2 val3 = (T2)(frmMain.listFBEntity[indexEntity].numMaxAct > 0 && frmMain.listFBEntity[indexEntity].numMaxAct < 100);
			if (val3 == null)
			{
				((Dictionary<string, string>)val2).Add("limit=2000", "limit=100");
			}
			else
			{
				((Dictionary<string, string>)val2).Add("limit=2000", "limit=" + System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)frmMain.listFBEntity[indexEntity].numMaxAct));
			}
			if (isOwned_ad_accounts != null)
			{
				((Dictionary<string, string>)val2).Add("client_ad_accounts", "owned_ad_accounts");
			}
			T0 val4 = (T0)"";
			T0[] array = (T0[])(object)((string)resouce).Split((char[])(object)new T7[1] { (T7)38 });
			T3 val5 = (T3)0;
			while ((nint)val5 < array.Length)
			{
				T0 val6 = (T0)((object[])(object)array)[(object)val5];
				T2 val7 = (T2)((string)val6).ToLower().Contains("sort=");
				if (val7 == null)
				{
					val5 = (T3)(val5 + 1);
					continue;
				}
				val4 = val6;
				break;
			}
			switch (indexSort - 1)
			{
			case 0:
				((Dictionary<string, string>)val2).Add((string)val4, "sort=name_ascending");
				val4 = (T0)"sort=name_ascending";
				break;
			case 1:
				((Dictionary<string, string>)val2).Add((string)val4, "sort=name_descending");
				val4 = (T0)"sort=name_descending";
				break;
			case 2:
				((Dictionary<string, string>)val2).Add((string)val4, "sort=creation_time_descending");
				val4 = (T0)"sort=creation_time_descending";
				break;
			case 3:
				((Dictionary<string, string>)val2).Add((string)val4, "sort=creation_time_ascending");
				val4 = (T0)"sort=creation_time_ascending";
				break;
			}
			T0 val8 = (T0)"";
			T0 val9 = (T0)"";
			T0 val10 = (T0)"";
			if ((nint)indexFilter != 1)
			{
				if ((nint)indexFilter == 2)
				{
					val9 = (T0)"{\"field\":\"account_status\",\"operator\":\"EQUAL\",\"value\":\"0\"}";
				}
			}
			else
			{
				val9 = (T0)"{\"field\":\"account_status\",\"operator\":\"EQUAL\",\"value\":\"1\"}";
			}
			val8 = (T0)((string)val8 + (string)val9);
			T2 val11 = (T2)(!string.IsNullOrWhiteSpace((string)searchByKeyword));
			if (val11 != null)
			{
				T2 val12 = (T2)(!string.IsNullOrWhiteSpace((string)val8));
				if (val12 != null)
				{
					val8 = (T0)((string)val8 + ",");
				}
				val10 = (T0)("{\"field\":\"name_or_id_or_owner_obo_business\",\"operator\":\"CONTAIN\",\"value\":\"" + (string)searchByKeyword + "\"}");
				val8 = (T0)((string)val8 + (string)val10);
			}
			T2 val13 = (T2)(!string.IsNullOrWhiteSpace((string)val8));
			if (val13 != null)
			{
				val8 = (T0)("[" + (string)val8 + "]");
				val8 = (T0)HttpUtility.UrlEncode((string)val8);
				((Dictionary<string, string>)val2).Add((string)val4, (string)val4 + "&filtering=" + (string)val8);
			}
			resouce = (T0)ResouceControl.getResouce("getAll_Tkqc_In_BM_limit_250", (Dictionary<string, string>)val2);
			T0 val14 = executeScript<T0, IJavaScriptExecutor, T3, T2, object>(resouce);
			adaccounts = JsonConvert.DeserializeObject<adaccounts>((string)val14);
			while (true)
			{
				T2 val15 = (T2)frmMain.isRunning;
				if (val15 == null)
				{
					break;
				}
				T2 val16 = (T2)(frmMain.listFBEntity[indexEntity].numMaxAct > 0 && adaccounts.data.Count >= frmMain.listFBEntity[indexEntity].numMaxAct);
				if (val16 != null)
				{
					break;
				}
				frmMain.listFBEntity[indexEntity].lbCountLoadAct = adaccounts.data.Count;
				T2 val17 = (T2)(adaccounts != null && adaccounts.data != null && adaccounts.paging != null && !string.IsNullOrWhiteSpace(adaccounts.paging.next));
				if (val17 == null)
				{
					break;
				}
				T0 val18 = fetch_url_business<T1, T0, T9>((T0)adaccounts.paging.next);
				adaccounts adaccounts2 = JsonConvert.DeserializeObject<adaccounts>((string)val18);
				T2 val19 = (T2)(adaccounts != null && adaccounts.data != null && adaccounts2 != null && adaccounts2.data != null);
				if (val19 != null)
				{
					adaccounts.data.AddRange(adaccounts2.data);
					adaccounts.paging = adaccounts2.paging;
				}
			}
			T0 resouce2 = (T0)ResouceControl.getResouce("getAll_Tkqc_In_BM_limit_250", (Dictionary<string, string>)val2);
			resouce2 = (T0)((string)resouce2).Replace("client_ad_accounts", "owned_ad_accounts");
			val14 = executeScript<T0, IJavaScriptExecutor, T3, T2, object>(resouce2);
			adaccounts adaccounts3 = JsonConvert.DeserializeObject<adaccounts>((string)val14);
			T2 val20 = (T2)(adaccounts3 != null && adaccounts3.data != null && adaccounts3.data.Count > 0);
			if (val20 != null)
			{
				T2 val21 = (T2)(adaccounts == null);
				if (val21 != null)
				{
					adaccounts = new adaccounts();
				}
				T2 val22 = (T2)(adaccounts.data == null);
				if (val22 != null)
				{
					adaccounts.data = (List<adaccountsData>)Activator.CreateInstance(typeof(T11));
				}
				adaccounts.data.AddRange(adaccounts3.data);
				adaccounts.paging = adaccounts3.paging;
			}
			while (true)
			{
				T2 val23 = (T2)frmMain.isRunning;
				if (val23 != null)
				{
					T2 val24 = (T2)(frmMain.listFBEntity[indexEntity].numMaxAct > 0 && adaccounts.data.Count >= frmMain.listFBEntity[indexEntity].numMaxAct);
					if (val24 == null)
					{
						frmMain.listFBEntity[indexEntity].lbCountLoadAct = adaccounts.data.Count;
						T2 val25 = (T2)(adaccounts != null && adaccounts.data != null && adaccounts.paging != null && !string.IsNullOrWhiteSpace(adaccounts.paging.next));
						if (val25 != null)
						{
							T0 val26 = fetch_url_business<T1, T0, T9>((T0)adaccounts.paging.next);
							adaccounts adaccounts4 = JsonConvert.DeserializeObject<adaccounts>((string)val26);
							T2 val27 = (T2)(adaccounts != null && adaccounts.data != null && adaccounts4 != null && adaccounts4.data != null);
							if (val27 != null)
							{
								adaccounts.data.AddRange(adaccounts4.data);
								adaccounts.paging = adaccounts4.paging;
							}
							continue;
						}
						break;
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 share_tkqc_to_via<T0, T1, T2>(T2 strBMstrUIDShareID, T2 strAsset_Ids, T2 strBMID)
	{
		//IL_0002: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			strAsset_Ids = (T2)((string)strAsset_Ids).Replace("act_", "");
			((Dictionary<string, string>)val2).Add("strUIDShare", (string)strBMstrUIDShareID);
			((Dictionary<string, string>)val2).Add("strAsset_Ids", (string)strAsset_Ids);
			((Dictionary<string, string>)val2).Add("strBMID", (string)strBMID);
			T2 resouce = (T2)ResouceControl.getResouce("share_tkqc_to_via", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("successes");
			if (val4 != null)
			{
				return (T0)1;
			}
			return (T0)0;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 xoa_tkqc_trong_bm<T0, T1, T2>(T2 strAct, T2 strUIDShare)
	{
		//IL_0002: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			strAct = (T2)((string)strAct).Replace("act_", "");
			((Dictionary<string, string>)val2).Add("strAct", (string)strAct);
			((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val2).Add("strUIDShare", (string)strUIDShare);
			T2 resouce = (T2)ResouceControl.getResouce("xoa_tkqc_trong_bm", (Dictionary<string, string>)val2);
			T2 val3 = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T0 val4 = (T0)((string)val3).Contains("true");
			if (val4 != null)
			{
				return (T0)1;
			}
			return (T0)0;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 post_bai_group<T0, T1, T2>(out string outMessage, T2 strGroupId, T2 strBackgroundId, T2 strMessage)
	{
		//IL_0009: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_0147: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		outMessage = "";
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			((Dictionary<string, string>)val2).Add("https://www.facebook.com/api/graphql/", "https://business.facebook.com/api/graphql/");
			((Dictionary<string, string>)val2).Add("strGroupId", (string)strGroupId);
			((Dictionary<string, string>)val2).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
			((Dictionary<string, string>)val2).Add("strBackgroundId", (string)strBackgroundId);
			strMessage = (T2)HttpUtility.UrlPathEncode((string)strMessage);
			strMessage = (T2)((string)strMessage).Replace("%0a", "%5Cn");
			((Dictionary<string, string>)val2).Add("strMessage", (string)strMessage);
			T2 resouce = (T2)ResouceControl.getResouce("post_bai_group", (Dictionary<string, string>)val2);
			T2 input = executeScript<T2, IJavaScriptExecutor, int, T0, object>(resouce);
			T2 value = (T2)Regex.Match((string)input, "legacy_story_hideable_id\":\"(.*?)\"").Groups[1].Value;
			T0 val3 = (T0)(!string.IsNullOrWhiteSpace((string)value));
			if (val3 == null)
			{
				T2 val4 = (T2)Regex.Match((string)input, "errorDescription\":\"(.*?)\"").Groups[1].Value;
				T0 val5 = (T0)string.IsNullOrWhiteSpace((string)val4);
				if (val5 != null)
				{
					val4 = (T2)Regex.Match((string)input, "message\":\"(.*?)\"").Groups[1].Value;
				}
				T0 val6 = (T0)string.IsNullOrWhiteSpace((string)val4);
				if (val6 != null)
				{
					val4 = (T2)"Đăng lỗi";
				}
				outMessage = (string)val4;
				return (T0)0;
			}
			outMessage = (string)value;
			return (T0)1;
		}
		catch
		{
			return (T0)0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ADSPRoject.Data.business_users get_user_in_bm<T0, T1, T2>(T1 strBMID)
	{
		ADSPRoject.Data.business_users result = null;
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val).Add("strBMID", (string)strBMID);
			T1 resouce = (T1)ResouceControl.getResouce("get_user_in_bm", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
			result = JsonConvert.DeserializeObject<ADSPRoject.Data.business_users>((string)val2);
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public business_asset_groups get_group_in_bm<T0, T1, T2>(T1 strBMID)
	{
		business_asset_groups result = null;
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val).Add("strBMID", (string)strBMID);
			T1 resouce = (T1)ResouceControl.getResouce("get_group_in_bm", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, IJavaScriptExecutor, int, bool, object>(resouce);
			result = JsonConvert.DeserializeObject<business_asset_groups>((string)val2);
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public business_asset_groups get_page_in_bm<T0, T1, T2, T3, T4>(T0 strBMID)
	{
		//IL_008a: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0158: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_0226: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_0285: Expected O, but got I4
		//IL_029c: Expected O, but got I4
		business_asset_groups business_asset_groups = new business_asset_groups();
		business_asset_groups.data = (List<business_asset_groups_data>)Activator.CreateInstance(typeof(T3));
		try
		{
			T0 url = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://graph.facebook.com/v14.0/",
				strBMID,
				(T0)"/client_pages?access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG,
				(T0)"&__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Abusiness%2Fclient_pages&_reqSrc=BusinessConnectedClientPagesStore.brands&date_format=U&fields=%5B%22id%22%2C%22name%22%2C%22global_brand_page_name%22%2C%22location%22%2C%22category%22%2C%22link%22%2C%22locations.fields(id).limit(1)%22%2C%22parent_page%22%2C%22has_transitioned_to_new_page_experience%22%2C%22additional_profile_id%22%2C%22has_updated_profile_plus_perm_management%22%2C%22is_verified%22%2C%22is_published%22%2C%22page_created_time%22%2C%22picture.type(square)%22%2C%22username%22%2C%22userpermissions%22%2C%22global_brand_root_id%22%2C%22business%22%2C%22is_deactivated%22%2C%22is_pending_deletion%22%2C%22is_deleted%22%2C%22deletion_time%22%2C%22permitted_roles%22%2C%22permitted_tasks%22%2C%22permitted_tasks_from_business_asset_groups%22%5D&limit=25&locale=vi_VN&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref=f25c1e7def7ee34"
			});
			T0 val = fetch_url_business<T4, T0, T2>(url);
			url = (T0)"";
			business_asset_groups business_asset_groups2 = JsonConvert.DeserializeObject<business_asset_groups>((string)val);
			T1 val2 = (T1)(business_asset_groups2 != null && business_asset_groups2.data != null);
			if (val2 != null)
			{
				business_asset_groups.data.AddRange(business_asset_groups2.data);
				T1 val3 = (T1)(business_asset_groups2.paging != null && !string.IsNullOrWhiteSpace(business_asset_groups2.paging.next));
				if (val3 != null)
				{
					url = (T0)business_asset_groups2.paging.next;
				}
			}
			while (true)
			{
				T1 val4 = (T1)frmMain.isRunning;
				if (val4 == null)
				{
					break;
				}
				T1 val5 = (T1)(!string.IsNullOrWhiteSpace((string)url));
				if (val5 == null)
				{
					break;
				}
				val = fetch_url_business<T4, T0, T2>(url);
				url = (T0)"";
				business_asset_groups2 = JsonConvert.DeserializeObject<business_asset_groups>((string)val);
				T1 val6 = (T1)(business_asset_groups2 != null && business_asset_groups2.data != null);
				if (val6 != null)
				{
					business_asset_groups.data.AddRange(business_asset_groups2.data);
				}
				T1 val7 = (T1)(business_asset_groups2.paging != null && !string.IsNullOrWhiteSpace(business_asset_groups2.paging.next));
				if (val7 != null)
				{
					url = (T0)business_asset_groups2.paging.next;
				}
			}
			url = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://graph.facebook.com/v14.0/",
				strBMID,
				(T0)"/owned_pages?access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG,
				(T0)"&__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Abusiness%2Fclient_pages&_reqSrc=BusinessConnectedClientPagesStore.brands&date_format=U&fields=%5B%22id%22%2C%22name%22%2C%22global_brand_page_name%22%2C%22location%22%2C%22category%22%2C%22link%22%2C%22locations.fields(id).limit(1)%22%2C%22parent_page%22%2C%22has_transitioned_to_new_page_experience%22%2C%22additional_profile_id%22%2C%22has_updated_profile_plus_perm_management%22%2C%22is_verified%22%2C%22is_published%22%2C%22page_created_time%22%2C%22picture.type(square)%22%2C%22username%22%2C%22userpermissions%22%2C%22global_brand_root_id%22%2C%22business%22%2C%22is_deactivated%22%2C%22is_pending_deletion%22%2C%22is_deleted%22%2C%22deletion_time%22%2C%22permitted_roles%22%2C%22permitted_tasks%22%2C%22permitted_tasks_from_business_asset_groups%22%5D&limit=25&locale=vi_VN&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref=f25c1e7def7ee34"
			});
			val = fetch_url_business<T4, T0, T2>(url);
			url = (T0)"";
			business_asset_groups2 = JsonConvert.DeserializeObject<business_asset_groups>((string)val);
			T1 val8 = (T1)(business_asset_groups2 != null && business_asset_groups2.data != null);
			if (val8 != null)
			{
				business_asset_groups.data.AddRange(business_asset_groups2.data);
				T1 val9 = (T1)(business_asset_groups2.paging != null && !string.IsNullOrWhiteSpace(business_asset_groups2.paging.next));
				if (val9 != null)
				{
					url = (T0)business_asset_groups2.paging.next;
				}
			}
			while (true)
			{
				T1 val10 = (T1)frmMain.isRunning;
				if (val10 != null)
				{
					T1 val11 = (T1)(!string.IsNullOrWhiteSpace((string)url));
					if (val11 != null)
					{
						val = fetch_url_business<T4, T0, T2>(url);
						url = (T0)"";
						business_asset_groups2 = JsonConvert.DeserializeObject<business_asset_groups>((string)val);
						T1 val12 = (T1)(business_asset_groups2 != null && business_asset_groups2.data != null);
						if (val12 != null)
						{
							business_asset_groups.data.AddRange(business_asset_groups2.data);
						}
						T1 val13 = (T1)(business_asset_groups2.paging != null && !string.IsNullOrWhiteSpace(business_asset_groups2.paging.next));
						if (val13 != null)
						{
							url = (T0)business_asset_groups2.paging.next;
						}
						continue;
					}
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return business_asset_groups;
	}

	public T0 executeScript<T0, T1, T2, T3, T4>(T0 script)
	{
		//IL_000f: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Expected O, but got I4
		T0 result = (T0)"";
		T1 val = (T1)chrome;
		T2 val2 = (T2)0;
		while (true)
		{
			try
			{
				result = (T0)((IJavaScriptExecutor)val).ExecuteScript((string)script, (object[])(object)Array.Empty<T4>());
			}
			catch
			{
				goto IL_0028;
			}
			break;
			IL_0028:
			val2 = (T2)(val2 + 1);
			T3 val3 = (T3)((nint)val2 >= 5);
			if (val3 != null)
			{
				break;
			}
			Thread.Sleep(2000);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clCampaigns getCampaigns<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 act)
	{
		//IL_0024: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		clCampaigns result = null;
		try
		{
			T2 val = (T2)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val != null)
			{
				getToken<T2, T3, T1, T4, T5, T6, T7, T8, T9, T10>((T1)"EAAB", (T1)ResouceControl.getResouce("RESOUCE_BM_CAMPAIGNS"));
			}
			T0 val2 = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val2).Add("strAct", (string)act);
			((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
			T1 resouce = (T1)ResouceControl.getResouce("GetCampaigns", (Dictionary<string, string>)val2);
			T1 val3 = executeScript<T1, T11, T6, T2, T12>(resouce);
			adaccountsData adaccountsData = JsonConvert.DeserializeObject<adaccountsData>((string)val3);
			T2 val4 = (T2)(adaccountsData != null && adaccountsData.campaigns != null);
			if (val4 != null)
			{
				result = adaccountsData.campaigns;
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 supportReviewCamps<T0, T1, T2, T3, T4, T5>(T1 adsId)
	{
		//IL_0002: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 url = (T1)((RemoteWebDriver)chrome).Url;
			((RemoteWebDriver)chrome).Navigate().GoToUrl(ResouceControl.getResouce("RESOUCE_SUPPORT_CAMP_REVIEW"));
			T2 val = (T2)Activator.CreateInstance(typeof(T2));
			adsId = (T1)HttpUtility.UrlEncode((string)adsId);
			((Dictionary<string, string>)val).Add("strAdId", (string)adsId);
			T1 resouce = (T1)ResouceControl.getResouce("support_camp_review", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, T3, T4, T0, T5>(resouce);
			T0 val3 = (T0)((string)val2).Contains("errorSummary");
			if (val3 != null)
			{
				result = (T0)0;
			}
			((RemoteWebDriver)chrome).Navigate().GoToUrl((string)url);
		}
		catch
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 getAddraftsId<T0, T1, T2, T3, T4, T5>(T2 actId)
	{
		//IL_0022: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
				((Dictionary<string, string>)val2).Add("strActId", (string)actId);
				T2 resouce = (T2)ResouceControl.getResouce("getAddrafts", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, T3, T4, T0, T5>(resouce);
				Addrafts addrafts = JsonConvert.DeserializeObject<Addrafts>((string)val3);
				T0 val4 = (T0)(addrafts != null && addrafts.data != null && addrafts.data.Count > 0);
				if (val4 != null)
				{
					return (T2)addrafts.data.Last().id;
				}
			}
			else
			{
				frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
			}
		}
		catch
		{
		}
		return (T2)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public addraft_fragments getAddraftCamp<T0, T1, T2, T3, T4, T5>(T2 addraft)
	{
		//IL_0022: Expected O, but got I4
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				((Dictionary<string, string>)val2).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
				((Dictionary<string, string>)val2).Add("strActId", (string)addraft);
				T2 resouce = (T2)ResouceControl.getResouce("addraft_fragments", (Dictionary<string, string>)val2);
				T2 val3 = executeScript<T2, T3, T4, T0, T5>(resouce);
				return JsonConvert.DeserializeObject<addraft_fragments>((string)val3);
			}
			frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
		}
		catch
		{
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public addraft_fragments_2 getAddraftCamp_2<T0, T1, T2, T3, T4, T5>(T3 strAtc)
	{
		//IL_0022: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		try
		{
			T0 val = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAB);
			if (val == null)
			{
				T1 val2 = (T1)0;
				addraft_fragments_2 addraft_fragments_;
				while (true)
				{
					T2 val3 = (T2)Activator.CreateInstance(typeof(T2));
					((Dictionary<string, string>)val3).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val3).Add("strAtc", ((string)strAtc).Replace("act_", ""));
					T3 resouce = (T3)ResouceControl.getResouce("addraft_fragments_2", (Dictionary<string, string>)val3);
					T3 val4 = executeScript<T3, T4, T1, T0, T5>(resouce);
					addraft_fragments_ = JsonConvert.DeserializeObject<addraft_fragments_2>((string)val4);
					val2 = (T1)(val2 + 1);
					T0 val5 = (T0)(addraft_fragments_ == null || addraft_fragments_.data == null || addraft_fragments_.data.Count <= 0);
					if (val5 == null)
					{
						break;
					}
					T0 val6 = (T0)((nint)val2 < 5);
					if (val6 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				return addraft_fragments_;
			}
			frmMain.listFBEntity[indexEntity].fullAdsInfo = null;
		}
		catch
		{
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 getAddraftCamp_2_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_0117: Expected I4, but got O
		//IL_012f: Expected I4, but got O
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_0148: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)"";
			T1 val3 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val4 = (T1)("fetch_" + (string)str);
					T4 val5 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val5).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAB);
					((Dictionary<string, string>)val5).Add("strAtc", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val5).Add("result", (string)val4);
					T1 resouce = (T1)ResouceControl.getResouce("addraft_fragments_2_Promise", (Dictionary<string, string>)val5);
					val2 = (T1)((string)val2 + (string)resouce);
					val3 = (T1)((string)val3 + (string)val4 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val6 = executeScript_Promise<T2, T1, IJavaScriptExecutor, ICollection<object>, T0, T6, char, object>(val2, val3);
			T0 val7 = (T0)(val6 != null && ((List<object>)val6).Count > 0);
			if (val7 != null)
			{
				T5 val8 = (T5)0;
				while (true)
				{
					T0 val9 = (T0)((nint)val8 < ((List<ListStringData>)listData).Count);
					if (val9 == null)
					{
						break;
					}
					T1 val10 = (T1)((List<object>)val6)[(int)val8].ToString();
					addraft_fragments_2 obj = JsonConvert.DeserializeObject<addraft_fragments_2>((string)val10);
					((List<ListStringData>)listData)[(int)val8].obj1 = obj;
					val8 = (T5)(val8 + 1);
				}
			}
			val = (T0)1;
		}
		catch (Exception ex)
		{
			val = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 reaload_campaigns_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T1 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		T0 val = (T0)0;
		try
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
			T2 enumerator = (T2)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					((List<ListStringData>)val2).Add(new ListStringData
					{
						str1 = current.str1,
						str2 = null,
						str3 = "act_id%3A3400061953584575%0Acampaign_id%3A23852113925960176%0Aadset_id%3A23852113926010176%0A%5B%7B%22field%22%3A%22adlabels%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22split_test_config%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22can_use_spend_cap%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Atrue%7D%2C%7B%22field%22%3A%22name%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22New%20Engagement%20Campaign%22%7D%2C%7B%22field%22%3A%22metrics_metadata%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22campaign_group_creation_source%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22click_quick_create%22%7D%2C%7B%22field%22%3A%22smart_promotion_type%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22account_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%223400061953584575%22%7D%2C%7B%22field%22%3A%22is_odax_campaign_group%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Atrue%7D%2C%7B%22field%22%3A%22tempID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A-1676801932603%7D%2C%7B%22field%22%3A%22boosted_component_product%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22incremental_conversion_optimization_config%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22spend_cap%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22topline_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22special_ad_categories%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%22NONE%22%5D%7D%2C%7B%22field%22%3A%22status%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22ACTIVE%22%7D%2C%7B%22field%22%3A%22special_ad_category%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22NONE%22%7D%2C%7B%22field%22%3A%22objective%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22OUTCOME_ENGAGEMENT%22%7D%2C%7B%22field%22%3A%22promoted_object%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22budget_remaining%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22buying_type%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22AUCTION%22%7D%2C%7B%22field%22%3A%22collaborative_ads_partner_info%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22is_using_l3_schedule%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%5D%0A%5B%7B%22field%22%3A%22optimization_goal%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22CONVERSATIONS%22%7D%2C%7B%22field%22%3A%22placement%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22user_device%22%3A%5B%5D%2C%22excluded_publisher_list_ids%22%3A%5B%5D%2C%22excluded_brand_safety_content_types%22%3A%5B%5D%2C%22excluded_user_device%22%3A%5B%5D%2C%22wireless_carrier%22%3A%5B%5D%2C%22user_os%22%3A%5B%5D%2C%22brand_safety_content_filter_levels%22%3A%5B%22FACEBOOK_STANDARD%22%2C%22AN_STANDARD%22%5D%7D%7D%2C%7B%22field%22%3A%22targeting_as_signal%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A3%7D%2C%7B%22field%22%3A%22parentAdObjectID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%2223852113925960176%22%7D%2C%7B%22field%22%3A%22pacing_type%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%22standard%22%5D%7D%2C%7B%22field%22%3A%22start_time%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%222023-02-24T22%3A20%3A22%2B0800%22%7D%2C%7B%22field%22%3A%22campaign_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%2223852113925960176%22%7D%2C%7B%22field%22%3A%22daily_budget%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A60000%7D%2C%7B%22field%22%3A%22destination_type%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22MESSENGER%22%7D%2C%7B%22field%22%3A%22name%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22New%20Engagement%20Ad%20Set%22%7D%2C%7B%22field%22%3A%22campaign_creation_source%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22click_quick_create%22%7D%2C%7B%22field%22%3A%22account_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%223400061953584575%22%7D%2C%7B%22field%22%3A%22tempID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A-1676801933418%7D%2C%7B%22field%22%3A%22targeting%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22age_max%22%3A58%2C%22user_device%22%3A%5B%5D%2C%22excluded_publisher_list_ids%22%3A%5B%5D%2C%22geo_locations%22%3A%7B%22countries%22%3A%5B%22VN%22%5D%2C%22location_types%22%3A%5B%22home%22%2C%22recent%22%5D%2C%22custom_locations%22%3A%5B%7B%22name%22%3A%22%2825.0259%2C%20-81.5295%29%22%2C%22distance_unit%22%3A%22mile%22%2C%22latitude%22%3A25.025884%2C%22longitude%22%3A-81.529541%2C%22primary_city_id%22%3A2429937%2C%22radius%22%3A1%2C%22region_id%22%3A3852%2C%22country%22%3A%22US%22%7D%5D%7D%2C%22genders%22%3A%5B2%5D%2C%22age_min%22%3A23%2C%22excluded_brand_safety_content_types%22%3A%5B%5D%2C%22excluded_user_device%22%3A%5B%5D%2C%22wireless_carrier%22%3A%5B%5D%2C%22user_os%22%3A%5B%5D%2C%22brand_safety_content_filter_levels%22%3A%5B%22FACEBOOK_STANDARD%22%5D%7D%7D%2C%7B%22field%22%3A%22end_time%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%222023-02-28T01%3A00%3A00%2B0800%22%7D%2C%7B%22field%22%3A%22status%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22ACTIVE%22%7D%2C%7B%22field%22%3A%22frequency_control_specs%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Anull%7D%2C%7B%22field%22%3A%22bid_strategy%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22LOWEST_COST_WITHOUT_CAP%22%7D%2C%7B%22field%22%3A%22billing_event%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22IMPRESSIONS%22%7D%2C%7B%22field%22%3A%22is_autobid%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Atrue%7D%2C%7B%22field%22%3A%22promoted_object%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22page_id%22%3A%22271201579892655%22%7D%7D%2C%7B%22field%22%3A%22lifetime_budget%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A0%7D%2C%7B%22field%22%3A%22attribution_spec%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%5B%7B%22event_type%22%3A%22CLICK_THROUGH%22%2C%22window_days%22%3A1%7D%2C%7B%22event_type%22%3A%22VIEW_THROUGH%22%2C%22window_days%22%3A0%7D%5D%7D%2C%7B%22field%22%3A%22budget_remaining%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A40000%7D%2C%7B%22field%22%3A%22is_average_price_pacing%22%2C%22old_value%22%3Anull%2C%22new_value%22%3Afalse%7D%5D%0A%5B%7B%22field%22%3A%22parentAdObjectID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%2223852113926010176%22%7D%2C%7B%22field%22%3A%22campaign_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%2223852113925960176%22%7D%2C%7B%22field%22%3A%22name%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22New%20Engagement%20Ad%22%7D%2C%7B%22field%22%3A%22account_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%223400061953584575%22%7D%2C%7B%22field%22%3A%22metadata%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22carousel_style%22%3A%22others%22%7D%7D%2C%7B%22field%22%3A%22creative%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%7B%22object_type%22%3A%22VIDEO%22%2C%22object_story_id%22%3A%22271201579892655_572373264937121%22%2C%22facebook_branded_content%22%3A%7B%22sponsor_page_id%22%3Anull%7D%2C%22page_welcome_message%22%3A%22%7B%5C%22type%5C%22%3A%5C%22VISUAL_EDITOR%5C%22%2C%5C%22version%5C%22%3A2%2C%5C%22landing_screen_type%5C%22%3A%5C%22welcome_message%5C%22%2C%5C%22media_type%5C%22%3A%5C%22text%5C%22%2C%5C%22text_format%5C%22%3A%7B%5C%22customer_action_type%5C%22%3A%5C%22ice_breakers%5C%22%2C%5C%22message%5C%22%3A%7B%5C%22ice_breakers%5C%22%3A%5B%7B%5C%22title%5C%22%3A%5C%22T%5Cu00f4i%20%5Cu0111%5Cu1eb7t%202%20ch%5Cu0103n%20%5C%22%7D%2C%7B%5C%22title%5C%22%3A%5C%22T%5Cu00f4i%20%5Cu0111%5Cu1eb7t%203%20ch%5Cu0103n%20%5C%22%7D%2C%7B%5C%22title%5C%22%3A%5C%22T%5Cu00f4i%20%5Cu0111%5Cu1eb7t%204%20ch%5Cu0103n%5C%22%7D%5D%2C%5C%22quick_replies%5C%22%3A%5B%5D%2C%5C%22text%5C%22%3A%5C%22%5Cud83d%5Cudc49%20Ch%5Cu00e0o%20a%5C%2Fc.%201%20CH%5Cu0102N%20%3D%2099K%20%2B%2030K%20SHIP%202%20CH%5Cu0102N%20%3D%20199K%20MI%5Cu1ec4N%20SHIP%20%5Cud83d%5Cudc49Ch%5Cu1ea5t%20V%5Cu1ea3i%20%23Cotton%20%23H%5Cu00e0n_Qu%5Cu1ed1c%20Ch%5Cu0103n%20tr%5Cu1ea7n%203%20l%5Cu1edbp%20n%5Cu1eb7ng%201.3kg.%20R%5Cu1ed9ng%201m7%20d%5Cu00e0i%202m.%20KI%5Cu1ec2M%20TRA%20H%5Cu00c0NG%20TR%5Cu01af%5Cu1edaC%20KHI%20THANH%20TO%5Cu00c1N%20%21%21%5C%22%7D%7D%2C%5C%22image_format%5C%22%3A%7B%5C%22customer_action_type%5C%22%3A%5C%22quick_replies%5C%22%2C%5C%22message%5C%22%3A%7B%5C%22attachment%5C%22%3A%7B%5C%22type%5C%22%3A%5C%22template%5C%22%2C%5C%22payload%5C%22%3A%7B%5C%22template_type%5C%22%3A%5C%22generic%5C%22%2C%5C%22elements%5C%22%3A%5B%7B%5C%22title%5C%22%3A%5C%22%5C%22%2C%5C%22buttons%5C%22%3A%5B%5D%7D%5D%7D%7D%2C%5C%22quick_replies%5C%22%3A%5B%7B%5C%22title%5C%22%3A%5C%22I%27d%20like%20to%20learn%20more%5C%22%2C%5C%22content_type%5C%22%3A%5C%22text%5C%22%7D%5D%2C%5C%22text%5C%22%3A%5C%22%5Cud83d%5Cudc49%20Ch%5Cu00e0o%20a%5C%2Fc.%201%20CH%5Cu0102N%20%3D%2099K%20%2B%2030K%20SHIP%202%20CH%5Cu0102N%20%3D%20199K%20MI%5Cu1ec4N%20SHIP%20%5Cud83d%5Cudc49Ch%5Cu1ea5t%20V%5Cu1ea3i%20%23Cotton%20%23H%5Cu00e0n_Qu%5Cu1ed1c%20Ch%5Cu0103n%20tr%5Cu1ea7n%203%20l%5Cu1edbp%20n%5Cu1eb7ng%201.3kg.%20R%5Cu1ed9ng%201m7%20d%5Cu00e0i%202m.%20KI%5Cu1ec2M%20TRA%20H%5Cu00c0NG%20TR%5Cu01af%5Cu1edaC%20KHI%20THANH%20TO%5Cu00c1N%20%21%21%5C%22%7D%7D%2C%5C%22video_format%5C%22%3A%7B%5C%22customer_action_type%5C%22%3A%5C%22quick_replies%5C%22%2C%5C%22message%5C%22%3A%7B%5C%22attachment%5C%22%3A%7B%5C%22type%5C%22%3A%5C%22video%5C%22%2C%5C%22payload%5C%22%3A%7B%5C%22attachment_id%5C%22%3A%5C%22%5C%22%7D%7D%2C%5C%22quick_replies%5C%22%3A%5B%7B%5C%22title%5C%22%3A%5C%22I%27d%20like%20to%20learn%20more%5C%22%2C%5C%22content_type%5C%22%3A%5C%22text%5C%22%7D%5D%2C%5C%22text%5C%22%3A%5C%22%5Cud83d%5Cudc49%20Ch%5Cu00e0o%20a%5C%2Fc.%201%20CH%5Cu0102N%20%3D%2099K%20%2B%2030K%20SHIP%202%20CH%5Cu0102N%20%3D%20199K%20MI%5Cu1ec4N%20SHIP%20%5Cud83d%5Cudc49Ch%5Cu1ea5t%20V%5Cu1ea3i%20%23Cotton%20%23H%5Cu00e0n_Qu%5Cu1ed1c%20Ch%5Cu0103n%20tr%5Cu1ea7n%203%20l%5Cu1edbp%20n%5Cu1eb7ng%201.3kg.%20R%5Cu1ed9ng%201m7%20d%5Cu00e0i%202m.%20KI%5Cu1ec2M%20TRA%20H%5Cu00c0NG%20TR%5Cu01af%5Cu1edaC%20KHI%20THANH%20TO%5Cu00c1N%20%21%21%5C%22%7D%7D%2C%5C%22user_edit%5C%22%3Atrue%2C%5C%22surface%5C%22%3A%5C%22visual_editor_new%5C%22%2C%5C%22template_id%5C%22%3A%5C%22509765077988340%5C%22%2C%5C%22template_version%5C%22%3A1%7D%22%7D%7D%2C%7B%22field%22%3A%22tempID%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A-1676801934131%7D%2C%7B%22field%22%3A%22status%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22ACTIVE%22%7D%2C%7B%22field%22%3A%22adset_id%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%2223852113926010176%22%7D%2C%7B%22field%22%3A%22display_sequence%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A0%7D%2C%7B%22field%22%3A%22ad_creation_source%22%2C%22old_value%22%3Anull%2C%22new_value%22%3A%22click_quick_create%22%7D%5D"
					});
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			val = ImportCamp_Promise<T0, T4, T5, T2, T6, T7, T3, T1>(val2);
			val = (T0)1;
		}
		catch (Exception ex)
		{
			val = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 executeScript_Promise<T0, T1, T2, T3, T4, T5, T6, T7>(T1 fetch, T1 fetch_id_list)
	{
		//IL_002f: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		T0 result = (T0)Activator.CreateInstance(typeof(T0));
		try
		{
			fetch_id_list = (T1)((string)fetch_id_list).Replace(" ", "");
			T4 val = (T4)((nint)((IEnumerable<T6>)fetch_id_list).Last() == 44);
			if (val != null)
			{
				fetch_id_list = (T1)((string)fetch_id_list).Substring(0, ((string)fetch_id_list).Length - 1);
			}
			T1 val2 = fetch;
			val2 = (T1)((string)val2 + "var testPromise=await Promise.all([" + (string)fetch_id_list + "]).then((values) => { return values; }); return testPromise;");
			T2 val3 = (T2)chrome;
			T3 val4 = (T3)(ICollection<object>)((IJavaScriptExecutor)val3).ExecuteScript((string)val2, (object[])(object)Array.Empty<T7>());
			T4 val5 = (T4)(val4 != null);
			if (val5 != null)
			{
				result = (T0)((IEnumerable<T7>)val4).ToList();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public adaccountsData reload_act<T0, T1, T2>(T0 act)
	{
		adaccountsData result = null;
		try
		{
			T0 val = fetch_url<T2, T0, T1>((T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
				(T0)"act_",
				(T0)((string)act).Replace("act_", ""),
				(T0)"?fields=business_country_code%2Cspend_cap%2Ccampaigns%7Bid%2Cstatus%2Cdelivery_status%7D%2Ctimezone_name%2Cid%2Cname%2Caccount_status%2Ccurrency%2Cadtrust_dsl%2Camount_spent%2Cadspaymentcycle%7Bthreshold_amount%7D%2Chas_repay_processing_invoices%2Cinvoicing_emails%2Cbalance&access_token=",
				(T0)frmMain.listFBEntity[indexEntity].TokenEAAG
			}));
			result = JsonConvert.DeserializeObject<adaccountsData>((string)val);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 reload_act_2<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 listI, frmAdsManager frm)
	{
		//IL_0002: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0049: Expected I4, but got O
		//IL_0099: Expected I4, but got O
		//IL_0143: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_01bb: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		//IL_01d7: Expected I4, but got O
		//IL_01ec: Expected I4, but got O
		//IL_020a: Expected I4, but got O
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_023c: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T4 enumerator = (T4)((List<int>)listI).GetEnumerator();
			try
			{
				while (((List<int>.Enumerator*)(&enumerator))->MoveNext())
				{
					T5 val3 = (T5)((List<int>.Enumerator*)(&enumerator))->Current;
					T6 val4 = (T6)Activator.CreateInstance(typeof(T6));
					T1 val5 = (T1)("fetch_" + frm.listData[(int)val3].id.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strUrl", string.Concat((string[])(object)new T1[5]
					{
						(T1)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
						(T1)"act_",
						(T1)frm.listData[(int)val3].id.Replace("act_", ""),
						(T1)"?fields=business_country_code%2Cspend_cap%2Ccampaigns%7Bid%2Cstatus%2Cdelivery_status%7D%2Ctimezone_name%2Cid%2Cdisable_reason%2Cname%2Caccount_status%2Ccurrency%2Cadtrust_dsl%2Camount_spent%2Cadspaymentcycle%7Bthreshold_amount%7D%2Chas_repay_processing_invoices%2Cinvoicing_emails%2Cbalance&access_token=",
						(T1)frmMain.listFBEntity[indexEntity].TokenEAAG
					}));
					((Dictionary<string, string>)val4).Add("result", (string)val5);
					((Dictionary<string, string>)val4).Add("await", "");
					((Dictionary<string, string>)val4).Add("return " + (string)val5 + ";", "");
					T1 resouce = (T1)ResouceControl.getResouce("fetch_url", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					T0 val6 = (T0)(!string.IsNullOrWhiteSpace((string)val2));
					if (val6 != null)
					{
						val2 = (T1)((string)val2 + ",");
					}
					val2 = (T1)((string)val2 + (string)val5);
				}
			}
			finally
			{
				((IDisposable)(*(List<int>.Enumerator*)(&enumerator))).Dispose();
			}
			T1 val7 = val;
			val7 = (T1)((string)val7 + "var testPromise=await Promise.all([" + (string)val2 + "]).then((values) => { return values; }); return testPromise;");
			T2 val8 = (T2)chrome;
			T3 val9 = (T3)(ICollection<object>)((IJavaScriptExecutor)val8).ExecuteScript((string)val7, (object[])(object)Array.Empty<T10>());
			T0 val10 = (T0)(val9 != null);
			if (val10 != null)
			{
				result = (T0)1;
				T7 val11 = (T7)((IEnumerable<T10>)val9).ToList();
				T5 val12 = (T5)0;
				while (true)
				{
					T0 val13 = (T0)((nint)val12 < ((List<int>)listI).Count);
					if (val13 != null)
					{
						T1 id = (T1)frm.listData[((List<int>)listI)[(int)val12]].id;
						T1 val14 = (T1)((List<object>)val11)[(int)val12].ToString();
						adaccountsData adaccountsData = JsonConvert.DeserializeObject<adaccountsData>((string)val14);
						frm.listData[((List<int>)listI)[(int)val12]] = adaccountsData;
						Console.WriteLine((string)id + "-" + adaccountsData.id);
						val12 = (T5)(val12 + 1);
						continue;
					}
					break;
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
	public payment_account payment_account<T0, T1, T2, T3, T4, T5>(T1 act)
	{
		payment_account result = null;
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			((Dictionary<string, string>)val).Add("strAct", ((string)act).Replace("act_", ""));
			T1 resouce = (T1)ResouceControl.getResouce("billable_account_by_payment_account", (Dictionary<string, string>)val);
			T1 val2 = executeScript<T1, T2, T3, T4, T5>(resouce);
			result = JsonConvert.DeserializeObject<payment_account>((string)val2);
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 payment_account_Promise_1<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 listI, frmAdsManager frm)
	{
		//IL_0002: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0038: Expected I4, but got O
		//IL_007a: Expected I4, but got O
		//IL_0100: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0128: Expected I4, but got O
		//IL_0130: Expected I4, but got O
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0160: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<int>)listI).GetEnumerator();
			try
			{
				while (((List<int>.Enumerator*)(&enumerator))->MoveNext())
				{
					T4 val3 = (T4)((List<int>.Enumerator*)(&enumerator))->Current;
					T1 val4 = (T1)("fetch_" + frm.listData[(int)val3].id.Replace("act_", ""));
					T5 val5 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val5).Add("strAct", frm.listData[(int)val3].id.Replace("act_", ""));
					((Dictionary<string, string>)val5).Add("result", (string)val4);
					T1 resouce = (T1)ResouceControl.getResouce("billable_account_by_payment_account_Promise", (Dictionary<string, string>)val5);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val4 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<int>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val6 = executeScript_Promise<T2, T1, T8, T9, T0, T6, T10, T11>(val, val2);
			T0 val7 = (T0)(val6 != null && ((List<object>)val6).Count > 0);
			if (val7 != null)
			{
				T4 val8 = (T4)0;
				T3 enumerator2 = (T3)((List<int>)listI).GetEnumerator();
				try
				{
					while (((List<int>.Enumerator*)(&enumerator2))->MoveNext())
					{
						T4 val9 = (T4)((List<int>.Enumerator*)(&enumerator2))->Current;
						frm.listData[(int)val9].payment_account = JsonConvert.DeserializeObject<payment_account>(((List<object>)val6)[(int)val8].ToString());
						val8 = (T4)(val8 + 1);
					}
				}
				finally
				{
					((IDisposable)(*(List<int>.Enumerator*)(&enumerator2))).Dispose();
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool payment_account_Promise_3(List<ListStringData> listData)
	{
		bool result = false;
		try
		{
			string text = "";
			string text2 = "";
			foreach (ListStringData listDatum in listData)
			{
				string text3 = "fetch_" + listDatum.str1.Replace("act_", "");
				Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
				dictionary.Add("strActId", listDatum.str1.Replace("act_", ""));
				dictionary.Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				dictionary.Add("result", text3);
				string resouce = ResouceControl.getResouce("billable_account_by_payment_account_Promise_3", dictionary);
				text += resouce;
				text2 = text2 + text3 + ",";
			}
			List<object> list = executeScript_Promise<List<object>, string, IJavaScriptExecutor, ICollection<object>, bool, Exception, char, object>(text, text2);
			if (list != null && list.Count > 0)
			{
				int num = 0;
				foreach (ListStringData listDatum2 in listData)
				{
					listDatum2.obj1 = JsonConvert.DeserializeObject<payment_account>(list[num].ToString());
					num++;
				}
				result = true;
			}
			text = "";
			text2 = "";
			foreach (ListStringData listDatum3 in listData)
			{
				string text4 = "fetch_" + listDatum3.str1.Replace("act_", "");
				Dictionary<string, string> dictionary2 = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
				dictionary2.Add("strActId", listDatum3.str1.Replace("act_", ""));
				dictionary2.Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				dictionary2.Add("result", text4);
				string resouce2 = ResouceControl.getResouce("BillingHubRootBillableAccountContextProviderQuery_Promise", dictionary2);
				text += resouce2;
				text2 = text2 + text4 + ",";
			}
			list = executeScript_Promise<List<object>, string, IJavaScriptExecutor, ICollection<object>, bool, Exception, char, object>(text, text2);
			if (list != null)
			{
				if (list.Count > 0)
				{
					int num2 = 0;
					foreach (ListStringData listDatum4 in listData)
					{
						listDatum4.obj2 = JsonConvert.DeserializeObject<CheckPayment>(list[num2].ToString());
						num2++;
					}
					return true;
				}
				return result;
			}
			return result;
		}
		catch (Exception ex)
		{
			result = false;
			Console.WriteLine(ex.Message);
			return result;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool payment_account_Promise_3(List<int> listI, frmAdsManager frm)
	{
		bool result = false;
		try
		{
			string text = "";
			string text2 = "";
			foreach (int item in listI)
			{
				string text3 = "fetch_" + frm.listData[item].id.Replace("act_", "");
				Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
				dictionary.Add("strActId", frm.listData[item].id.Replace("act_", ""));
				dictionary.Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				dictionary.Add("result", text3);
				string resouce = ResouceControl.getResouce("billable_account_by_payment_account_Promise_3", dictionary);
				text += resouce;
				text2 = text2 + text3 + ",";
			}
			List<object> list = executeScript_Promise<List<object>, string, IJavaScriptExecutor, ICollection<object>, bool, Exception, char, object>(text, text2);
			if (list != null && list.Count > 0)
			{
				int num = 0;
				foreach (int item2 in listI)
				{
					frm.listData[item2].strPayment_account = list[num].ToString();
					frm.listData[item2].payment_account = JsonConvert.DeserializeObject<payment_account>(list[num].ToString());
					num++;
				}
				result = true;
			}
			text = "";
			text2 = "";
			foreach (int item3 in listI)
			{
				string text4 = "fetch_" + frm.listData[item3].id.Replace("act_", "");
				Dictionary<string, string> dictionary2 = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
				dictionary2.Add("strActId", frm.listData[item3].id.Replace("act_", ""));
				dictionary2.Add("strUID", frmMain.listFBEntity[indexEntity].UID);
				dictionary2.Add("result", text4);
				string resouce2 = ResouceControl.getResouce("BillingHubRootBillableAccountContextProviderQuery_Promise", dictionary2);
				text += resouce2;
				text2 = text2 + text4 + ",";
			}
			list = executeScript_Promise<List<object>, string, IJavaScriptExecutor, ICollection<object>, bool, Exception, char, object>(text, text2);
			if (list != null)
			{
				if (list.Count > 0)
				{
					int num2 = 0;
					foreach (int item4 in listI)
					{
						frm.listData[item4].strCheckPayment = list[num2].ToString();
						frm.listData[item4].CheckPayment = JsonConvert.DeserializeObject<CheckPayment>(list[num2].ToString());
						num2++;
					}
					return true;
				}
				return result;
			}
			return result;
		}
		catch (Exception ex)
		{
			result = false;
			Console.WriteLine(ex.Message);
			return result;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getFragmentId<T0, T1, T2, T3>(T0 strAct, T0 BmID)
	{
		//IL_0059: Expected O, but got I4
		T0 result = (T0)"";
		try
		{
			T0 url = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"https://business.facebook.com/adsmanager/manage/ads?act=",
				(T0)((string)strAct).Replace("act_", ""),
				(T0)"&business_id=",
				BmID,
				(T0)"&columns=name%2Cdelivery%2Ccampaign_name%2Cbid%2Cbudget%2Clast_significant_edit%2Cattribution_setting%2Cresults%2Creach%2Cimpressions%2Ccost_per_result%2Cquality_score_organic%2Cquality_score_ectr%2Cquality_score_ecvr%2Cspend%2Cend_time%2Cschedule%2Cactions%3Alike&attribution_windows=default"
			});
			T0 val = fetch_url_business<T2, T0, T3>(url);
			T1 val2 = (T1)((string)val).Contains("");
			if (val2 != null)
			{
			}
		}
		catch
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void openChromeNoFollow<T0, T1>(T1 isHidden)
	{
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		FBFlowField fBFlowField = new FBFlowField();
		fBFlowField.key = "Update_User_Agent";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Disable_image";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Add_extension";
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Save_Profile_Folder";
		PROFILE_DIR = frmMain.PROFILE_CHROME_UID + frmMain.listFBEntity[indexEntity].UID;
		fBFlowField.value = "true";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		fBFlowField = new FBFlowField();
		fBFlowField.key = "Ẩn_chrome";
		PROFILE_DIR = frmMain.PROFILE_CHROME_UID + frmMain.listFBEntity[indexEntity].UID;
		fBFlowField.value = "false";
		fBFlowField.type = typeof(T1);
		((List<FBFlowField>)val).Add(fBFlowField);
		Open_Browser<T1, ChromeDriverService, string, Rectangle, int, TimeSpan, Exception, char>(new FBFlow
		{
			Flow_Name = "Open_Browser",
			Filed = (List<FBFlowField>)val
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void pageDown()
	{
		try
		{
			ReadOnlyCollection<IWebElement> source = ((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
			source.First().SendKeys(Keys.PageDown);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 getFBID<T0, T1, T2, T3, T4, T5>()
	{
		//IL_0062: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("async_del"));
			T2 enumerator = (T2)((ReadOnlyCollection<IWebElement>)val2).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					T3 current = (T3)((IEnumerator<IWebElement>)enumerator).Current;
					T4 val3 = (T4)(((IWebElement)current).GetAttribute("id") != null && ((IWebElement)current).GetAttribute("id").Contains("threadlist_row_other_user_fbid"));
					if (val3 != null)
					{
						((List<Customer_UID>)val).Add(new Customer_UID
						{
							UID = ((IWebElement)current).GetAttribute("id").Replace("threadlist_row_other_user_fbid_", "").Trim(),
							STATUS = frmReMarketing.STATUS.Ready.ToString()
						});
					}
				}
			}
			finally
			{
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
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
	public T0 reMarketing<T0, T1, T2, T3, T4, T5>(T1 customerId, T1 pageId, T1 message, out string error)
	{
		//IL_000a: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		error = "";
		T0 result = (T0)1;
		try
		{
			T1 script = (T1)string.Concat((string[])(object)new T1[7]
			{
				(T1)"function reMarketing(){var cid = \"",
				customerId,
				(T1)"\";var pageId=\"",
				pageId,
				(T1)"\";var fbdtsg = document.querySelector('[name=\"fb_dtsg\"]').value;var jazoest = require([\"SprinkleConfig\"]).jazoest;var userId = require([\"CurrentUserInitialData\"]).USER_ID;fetch(\"https://m.facebook.com/messages/send/?icm=1&pageID=\"+pageId+\"&entrypoint=web%3Atrigger%3Athread_list_thread&surface_hierarchy=unknown&paipv=1&refid=12\", {\"headers\": {\"accept\": \",\"accept-language\": \"en-US,en;q=0.9\",\"content-type\": \"application/x-www-form-urlencoded\",\"sec-ch-ua-mobile\": \"?0\",\"sec-ch-ua-platform\": \"Windows\",\"sec-fetch-dest\": \"empty\",\"sec-fetch-mode\": \"cors\",\"sec-fetch-site\": \"same-origin\",\"x-fb-lsd\": \"9tsHbf6htjCrZOTPkEFsWs\",\"x-msgr-region\": \"CLN\",\"x-requested-with\": \"XMLHttpRequest\",\"x-response-format\": \"JSONStream\"},\"referrer\": \"https://m.facebook.com/messages/read/?tid=cid.c.\"+cid+\"%3A\"+pageId+\"&pageID=\"+pageId+\"&entrypoint=web%3Atrigger%3Athread_list_thread&surface_hierarchy=unknown&paipv=1\",\"referrerPolicy\": \"origin-when-cross-origin\",\"body\": \"tids=cid.c.\"+cid+\"%3A\"+pageId+\"&wwwupp=C3&ids%5B\"+cid+\"%5D=\"+cid+\"&body=",
				message,
				(T1)"&waterfall_source=message&action_time=1635491426474&fb_dtsg=\"+fbdtsg+\"&jazoest=\"+jazoest+\"&lsd=9tsHbf6htjCrZOTPkEFsWs&__user=\"+userId+\"\",\"method\": \"POST\",\"mode\": \"cors\",\"credentials\": \"include\"});};reMarketing();"
			});
			executeScript<T1, T3, T4, T0, T5>(script);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			result = (T0)0;
			error = ex.Message;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T1 getFirstName<T0, T1, T2>()
	{
		//IL_000e: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		T0 val = (T0)(FirstName.Count == 0);
		if (val != null)
		{
			T1[] array = (T1[])(object)File.ReadAllLines("Data Reg Clone\\FirstName.txt");
			T1[] array2 = array;
			T2 val2 = (T2)0;
			while ((nint)val2 < array2.Length)
			{
				T1 val3 = (T1)((object[])(object)array2)[(object)val2];
				T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
				if (val4 != null)
				{
					FirstName.Add((string)val3);
				}
				val2 = (T2)(val2 + 1);
			}
		}
		return (T1)FirstName[rnd.Next(0, FirstName.Count - 1)].ToUpper();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T1 getLastName<T0, T1, T2>()
	{
		//IL_000e: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		T0 val = (T0)(LastName.Count == 0);
		if (val != null)
		{
			T1[] array = (T1[])(object)File.ReadAllLines("Data Reg Clone\\LastName.txt");
			T1[] array2 = array;
			T2 val2 = (T2)0;
			while ((nint)val2 < array2.Length)
			{
				T1 val3 = (T1)((object[])(object)array2)[(object)val2];
				T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
				if (val4 != null)
				{
					LastName.Add((string)val3);
				}
				val2 = (T2)(val2 + 1);
			}
		}
		return (T1)LastName[rnd.Next(0, LastName.Count - 1)].ToUpper();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void approvedPayment()
	{
		foreach (BMData datum in frmMain.listFBEntity[indexEntity].fullAdsInfo.businesses.data)
		{
			if (datum.owned_ad_accounts == null)
			{
				continue;
			}
			foreach (adaccountsData datum2 in datum.owned_ad_accounts.data)
			{
				try
				{
					Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
					string str = "{\"input\":{\"billable_account_payment_legacy_account_id\":\"" + datum2.id.Replace("act_", "") + "\",\"entry_point\":\"BILLING_2_0\",\"actor_id\":\"" + frmMain.listFBEntity[indexEntity].UID + "\",\"client_mutation_id\":\"1\"}}";
					dictionary.Add("strAct", datum2.id.Replace("act_", ""));
					str = HttpUtility.UrlEncode(str);
					dictionary.Add("strVariables", str);
					string resouce = ResouceControl.getResouce("Approved_payment", dictionary);
					executeScript<string, IJavaScriptExecutor, int, bool, object>(resouce);
				}
				catch
				{
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool approvedPayment(string act)
	{
		bool result = false;
		try
		{
			Dictionary<string, string> dictionary = (Dictionary<string, string>)Activator.CreateInstance(typeof(Dictionary<string, string>));
			string str = "{\"input\":{\"billable_account_payment_legacy_account_id\":\"" + act.Replace("act_", "") + "\",\"entry_point\":\"BILLING_2_0\",\"actor_id\":\"" + frmMain.listFBEntity[indexEntity].UID + "\",\"client_mutation_id\":\"1\"}}";
			dictionary.Add("strAct", act.Replace("act_", ""));
			str = HttpUtility.UrlEncode(str);
			dictionary.Add("strVariables", str);
			string resouce = ResouceControl.getResouce("Approved_payment", dictionary);
			string text = executeScript<string, IJavaScriptExecutor, int, bool, object>(resouce);
			if (text.Contains("success\":true"))
			{
				return true;
			}
			return result;
		}
		catch
		{
			return false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 approvedPayment_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_0167: Expected I4, but got O
		//IL_017d: Expected O, but got I4
		//IL_0189: Expected I4, but got O
		//IL_01a8: Expected I4, but got O
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Expected O, but got I4
		//IL_01d5: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T1 str2 = (T1)string.Concat((string[])(object)new T1[5]
					{
						(T1)"{\"input\":{\"billable_account_payment_legacy_account_id\":\"",
						(T1)current.str1.Replace("act_", ""),
						(T1)"\",\"entry_point\":\"BILLING_2_0\",\"actor_id\":\"",
						(T1)frmMain.listFBEntity[indexEntity].UID,
						(T1)"\",\"client_mutation_id\":\"1\"}}"
					});
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strAct", current.str1.Replace("act_", ""));
					str2 = (T1)HttpUtility.UrlEncode((string)str2);
					((Dictionary<string, string>)val4).Add("strVariables", (string)str2);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("Approved_payment_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, T8, T9, T0, T6, T10, T11>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 xm_3ds2_the_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 listData)
	{
		//IL_0002: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_012b: Expected I4, but got O
		//IL_0141: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_016c: Expected I4, but got O
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_0193: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_019f: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
					((Dictionary<string, string>)val4).Add("strAct", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strCredential", current.str2);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("xm_3ds2_the", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, T8, T9, T0, T6, T10, T11>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("COMPLETED");
					if (val10 != null)
					{
						((List<ListStringData>)listData)[(int)val7].str3 = frmMain.STATUS.Done.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str3 = frmMain.STATUS.lỗi.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 sharePixel_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 listData, T1 BMID, T1 Pixel_Id)
	{
		//IL_0002: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_0133: Expected I4, but got O
		//IL_0149: Expected O, but got I4
		//IL_0155: Expected I4, but got O
		//IL_0174: Expected I4, but got O
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_019b: Expected O, but got I4
		//IL_01a1: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T1 str = (T1)current.str1;
					T1 val3 = (T1)("fetch_" + (string)str);
					T4 val4 = (T4)Activator.CreateInstance(typeof(T4));
					((Dictionary<string, string>)val4).Add("strActId", current.str1.Replace("act_", ""));
					((Dictionary<string, string>)val4).Add("strBMID", (string)BMID);
					((Dictionary<string, string>)val4).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
					((Dictionary<string, string>)val4).Add("strPixelId", (string)Pixel_Id);
					((Dictionary<string, string>)val4).Add("result", (string)val3);
					T1 resouce = (T1)ResouceControl.getResouce("share_pixel_Promise", (Dictionary<string, string>)val4);
					val = (T1)((string)val + (string)resouce);
					val2 = (T1)((string)val2 + (string)val3 + ",");
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, T8, T9, T0, T6, T10, T11>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T5 val7 = (T5)0;
				while (true)
				{
					T0 val8 = (T0)((nint)val7 < ((List<ListStringData>)listData).Count);
					if (val8 == null)
					{
						break;
					}
					T1 val9 = (T1)((List<object>)val5)[(int)val7].ToString();
					T0 val10 = (T0)((string)val9).Contains("success\":true");
					if (val10 == null)
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.lỗi.ToString();
					}
					else
					{
						((List<ListStringData>)listData)[(int)val7].str2 = frmMain.STATUS.Done.ToString();
					}
					val7 = (T5)(val7 + 1);
				}
				result = (T0)1;
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe T0 share_page_thuong_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 listData, T0 isAutoReceiptPage)
	{
		//IL_0002: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		//IL_01a2: Expected I4, but got O
		//IL_01b8: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		//IL_01fe: Expected I4, but got O
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0229: Expected O, but got I4
		//IL_0232: Expected O, but got I4
		//IL_02d6: Expected O, but got I4
		T0 result = (T0)0;
		try
		{
			T1 val = (T1)"";
			T1 val2 = (T1)"";
			T3 enumerator = (T3)((List<ListStringData>)listData).GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T4 enumerator2 = (T4)frmMain.setting.List_TOKEN_PAGE.GetEnumerator();
					try
					{
						while (((List<TokenEntity>.Enumerator*)(&enumerator2))->MoveNext())
						{
							TokenEntity current2 = ((List<TokenEntity>.Enumerator*)(&enumerator2))->Current;
							T1 str = (T1)current.str1;
							T1 uID = (T1)current2.UID;
							T1 val3 = (T1)("fetch_" + (string)str + "_" + (string)uID);
							T5 val4 = (T5)Activator.CreateInstance(typeof(T5));
							((Dictionary<string, string>)val4).Add("strPageId", (string)str);
							((Dictionary<string, string>)val4).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
							((Dictionary<string, string>)val4).Add("strShareToUID", (string)uID);
							((Dictionary<string, string>)val4).Add("strPassword", HttpUtility.UrlEncode(frmMain.listFBEntity[indexEntity].Password));
							((Dictionary<string, string>)val4).Add("result", (string)val3);
							T1 resouce = (T1)ResouceControl.getResouce("share_page_thuong_Promise", (Dictionary<string, string>)val4);
							val = (T1)((string)val + (string)resouce);
							val2 = (T1)((string)val2 + (string)val3 + ",");
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
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T2 val5 = executeScript_Promise<T2, T1, T10, T11, T0, T8, T12, T13>(val, val2);
			T0 val6 = (T0)(val5 != null && ((List<object>)val5).Count > 0);
			if (val6 != null)
			{
				T6 val7 = (T6)Activator.CreateInstance(typeof(T6));
				T7 val8 = (T7)0;
				while (true)
				{
					T0 val9 = (T0)((nint)val8 < ((List<ListStringData>)listData).Count);
					if (val9 == null)
					{
						break;
					}
					T1 val10 = (T1)((List<object>)val5)[(int)val8].ToString();
					T0 val11 = (T0)((string)val10).Contains("isInvited\":true");
					if (val11 != null)
					{
						((List<string>)val7).Add("Done");
					}
					else
					{
						((List<string>)val7).Add("lỗi");
					}
					T0 val12 = (T0)(((List<string>)val7).Count == frmMain.setting.List_TOKEN_PAGE.Count);
					if (val12 != null)
					{
						((List<ListStringData>)listData)[(int)val8].str2 = string.Join(",", (IEnumerable<string>)val7);
						((List<string>)val7).Clear();
					}
					val8 = (T7)(val8 + 1);
				}
				result = (T0)1;
			}
			if (isAutoReceiptPage != null)
			{
				T3 enumerator3 = (T3)((List<ListStringData>)listData).GetEnumerator();
				try
				{
					while (((List<ListStringData>.Enumerator*)(&enumerator3))->MoveNext())
					{
						ListStringData current3 = ((List<ListStringData>.Enumerator*)(&enumerator3))->Current;
						T1 str2 = (T1)current3.str1;
						T4 enumerator4 = (T4)frmMain.setting.List_TOKEN_PAGE.GetEnumerator();
						try
						{
							while (((List<TokenEntity>.Enumerator*)(&enumerator4))->MoveNext())
							{
								TokenEntity current4 = ((List<TokenEntity>.Enumerator*)(&enumerator4))->Current;
								frmMain.apiPage.Accept_Page<T0, T7, T1, T8, HttpRequest>((T1)current4.Token, (T1)current4.Cookie, (T1)current4.UID, str2);
							}
						}
						finally
						{
							((IDisposable)(*(List<TokenEntity>.Enumerator*)(&enumerator4))).Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator3))).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void changePaymentInfo<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 Đổi_quốc_gia, T0 Đổi_múi_giờ, T0 Đổi_tiền_tệ)
	{
		//IL_000f: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		T0 value = Đổi_quốc_gia;
		T1 val = (T1)((string)Đổi_quốc_gia).Contains("_");
		if (val != null)
		{
			value = (T0)((string)Đổi_quốc_gia).Split((char[])(object)new T5[1] { (T5)95 })[1];
		}
		T2 enumerator = (T2)frmMain.listFBEntity[indexEntity].fullAdsInfo.businesses.data.GetEnumerator();
		try
		{
			while (((List<BMData>.Enumerator*)(&enumerator))->MoveNext())
			{
				BMData current = ((List<BMData>.Enumerator*)(&enumerator))->Current;
				T1 val2 = (T1)(current.owned_ad_accounts != null);
				if (val2 == null)
				{
					continue;
				}
				T3 enumerator2 = (T3)current.owned_ad_accounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
					{
						adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
						try
						{
							T4 val3 = (T4)Activator.CreateInstance(typeof(T4));
							((Dictionary<string, string>)val3).Add("strUID", frmMain.listFBEntity[indexEntity].UID);
							((Dictionary<string, string>)val3).Add("strAct", current2.id.Replace("act_", ""));
							((Dictionary<string, string>)val3).Add("strBMID", current.id);
							((Dictionary<string, string>)val3).Add("strTimezone", (string)Đổi_múi_giờ);
							((Dictionary<string, string>)val3).Add("strCurrency", (string)Đổi_tiền_tệ);
							((Dictionary<string, string>)val3).Add("strCountry_code", (string)value);
							((Dictionary<string, string>)val3).Add("strFullName", frmMain.listFBEntity[indexEntity].Name);
							T0 resouce = (T0)ResouceControl.getResouce("Doi_Thanh_Toan_TK", (Dictionary<string, string>)val3);
							T0 val4 = executeScript<T0, T6, T7, T1, T8>(resouce);
							T1 val5 = (T1)((string)val4).Contains("errors");
							if (val5 != null)
							{
							}
						}
						catch
						{
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<BMData>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void shareAdsToAdmin<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
	{
		//IL_0042: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		T0 enumerator = (T0)frmMain.listFBEntity[indexEntity].fullAdsInfo.businesses.data.GetEnumerator();
		try
		{
			while (((List<BMData>.Enumerator*)(&enumerator))->MoveNext())
			{
				BMData current = ((List<BMData>.Enumerator*)(&enumerator))->Current;
				T1 val = (T1)0;
				while (true)
				{
					T1 val2 = (T1)(val == null && frmMain.isRunning);
					if (val2 == null)
					{
						break;
					}
					try
					{
						T1 val3 = (T1)(current.owned_ad_accounts == null);
						if (val3 == null)
						{
							T2 val4 = (T2)Activator.CreateInstance(typeof(T2));
							((Dictionary<string, string>)val4).Add("strBMID", current.id);
							((Dictionary<string, string>)val4).Add("strToken", "\"" + frmMain.listFBEntity[indexEntity].TokenEAAG + "\"");
							T3 resouce = (T3)ResouceControl.getResouce("Lay_danh_sach_admin_trong_BM", (Dictionary<string, string>)val4);
							T3 val5 = executeScript<T3, T6, T7, T1, T8>(resouce);
							current.business_users = JsonConvert.DeserializeObject<ADSPRoject.Data.business_users>((string)val5);
							T4 enumerator2 = (T4)current.owned_ad_accounts.data.GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
								{
									adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
									T5 enumerator3 = (T5)current.business_users.data.GetEnumerator();
									try
									{
										while (((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator3))->MoveNext())
										{
											ADSPRoject.Data.business_users_data current3 = ((List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator3))->Current;
											val4 = (T2)Activator.CreateInstance(typeof(T2));
											((Dictionary<string, string>)val4).Add("strAct", current2.id.Replace("act_", ""));
											((Dictionary<string, string>)val4).Add("strBMID", current.id);
											((Dictionary<string, string>)val4).Add("strUserInBM", current3.id);
											resouce = (T3)ResouceControl.getResouce("phan_quyen_tai_khoan_cho_user", (Dictionary<string, string>)val4);
											val5 = executeScript<T3, T6, T7, T1, T8>(resouce);
											T1 val6 = (T1)((string)val5).Contains("successes");
											if (val6 != null)
											{
												val = (T1)1;
											}
											Thread.Sleep(2000);
										}
									}
									finally
									{
										((IDisposable)(*(List<ADSPRoject.Data.business_users_data>.Enumerator*)(&enumerator3))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
							}
						}
						else
						{
							val = (T1)1;
						}
					}
					catch
					{
					}
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<BMData>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Open_Browser<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_020e: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_026c: Expected O, but got I4
		//IL_0281: Expected O, but got I4
		//IL_02a4: Expected O, but got I4
		//IL_02c3: Expected I4, but got O
		//IL_02f1: Expected I4, but got O
		//IL_02fb: Expected O, but got I4
		//IL_0320: Expected O, but got I4
		//IL_03a2: Expected O, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_0548: Expected O, but got I4
		//IL_055c: Expected O, but got I4
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_0595: Expected O, but got I4
		//IL_05bb: Expected O, but got I4
		//IL_05e1: Expected O, but got I4
		//IL_0621: Expected O, but got I4
		//IL_06a0: Expected O, but got I4
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_070c: Expected O, but got I4
		//IL_0843: Expected O, but got I4
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Expected O, but got Unknown
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected O, but got Unknown
		T0 val = (T0)(!frmMain.isRunning);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Disable_image").ToString());
			bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Add_extension").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Update_User_Agent").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Save_Profile_Folder").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Ẩn_chrome").ToString());
			T1 val6 = (T1)ChromeDriverService.CreateDefaultService();
			((DriverService)val6).HideCommandPromptWindow = true;
			T0 val7 = val4;
			if (val7 != null)
			{
				PROFILE_DIR = frmMain.PROFILE_CHROME_UID + frmMain.listFBEntity[indexEntity].UID;
				T0 val8 = (T0)(!Directory.Exists(PROFILE_DIR));
				if (val8 != null)
				{
					Directory.CreateDirectory(PROFILE_DIR);
				}
				options.AddArgument("user-data-dir=" + PROFILE_DIR);
			}
			T0 val9 = (T0)(frmMain.setting.ccbChromeSize == 0);
			if (val9 != null)
			{
				T3 bounds = (T3)Screen.PrimaryScreen.Bounds;
				options.AddArguments((string[])(object)new T2[1] { (T2)$"--window-size={(T4)((Rectangle*)(&bounds))->Width},{(T4)(((Rectangle*)(&bounds))->Height - 50)}" });
			}
			else
			{
				T2 size = (T2)frmMain.chromeSize[frmMain.setting.ccbChromeSize].Size;
				options.AddArguments((string[])(object)new T2[1] { (T2)("--window-size=" + ((string)size).Split((char[])(object)new T7[1] { (T7)120 })[0] + "," + ((string)size).Split((char[])(object)new T7[1] { (T7)120 })[1]) });
			}
			T0 val10 = val2;
			if (val10 != null)
			{
				options.AddArguments((string[])(object)new T2[1] { (T2)"--disable-images" });
			}
			T2 path = (T2)(Application.StartupPath + "\\Extension");
			T0 val11 = (T0)Directory.Exists((string)path);
			if (val11 != null)
			{
				T2[] files = (T2[])(object)Directory.GetFiles((string)path);
				T2[] array = files;
				T4 val12 = (T4)0;
				while ((nint)val12 < array.Length)
				{
					T2 val13 = (T2)((object[])(object)array)[(object)val12];
					options.AddExtension((string)val13);
					val12 = (T4)(val12 + 1);
				}
			}
			T0 val14 = val3;
			if (val14 != null)
			{
				frmMain.SetCellText<T0, T4, T2>((T4)indexEntity, (T2)"UserAgent", (T2)"");
				T0 val15 = (T0)(frmMain.listUserAgent.Count > 1);
				if (val15 != null)
				{
					T4 val16 = (T4)rnd.Next(0, frmMain.listUserAgent.Count - 1);
					Console.WriteLine("{0}\t{1}", val16, frmMain.listUserAgent[(int)val16].UserAgent);
					frmMain.SetCellText<T0, T4, T2>((T4)indexEntity, (T2)"UserAgent", (T2)frmMain.listUserAgent[(int)val16].UserAgent);
				}
			}
			T0 val17 = (T0)(!string.IsNullOrEmpty(frmMain.listFBEntity[indexEntity].UserAgent));
			if (val17 != null)
			{
				options.AddArgument("--user-agent=" + frmMain.listFBEntity[indexEntity].UserAgent);
			}
			T0 val18 = val5;
			if (val18 != null)
			{
				options.AddArgument("headless");
			}
			options.AddArgument("--disable-impl-side-painting");
			options.AddArgument("no-sandbox");
			options.AddUserProfilePreference("credentials_enable_service", (object)(T0)0);
			options.AddUserProfilePreference("profile.password_manager_enabled", (object)(T0)0);
			options.AddArgument("--disable-notifications");
			options.AddArgument("--mute-audio");
			options.AddArgument("high-dpi-support=0.5");
			options.AddArgument("--disable-background-networking");
			options.AddArgument("--disable-client-side-phishing-detection");
			options.AddArgument("--disable-default-apps");
			options.AddArgument("--disable-hang-monitor");
			options.AddArgument("--disable-popup-blocking");
			options.AddArgument("--disable-prompt-on-repost");
			options.AddArgument("--disable-sync");
			options.AddArgument("--enable-automation");
			options.AddArgument("--enable-blink-features=ShadowDOMV05");
			options.AddArgument("--enable-logging");
			options.AddArgument("--log-level=0");
			options.AddArgument("--no-first-run");
			options.AddArgument("--no-service-autorun");
			options.AddArgument("--password-store=basic");
			options.AddArgument("--remote-debugging-port=0");
			options.AddArgument("--test-type=webdriver");
			options.AddArgument("--use-mock-keychain");
			options.AddExcludedArgument("enable-automation");
			T0 val19 = (T0)(!string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Socks));
			if (val19 == null)
			{
				T0 val20 = (T0)string.IsNullOrWhiteSpace(strProxy);
				if (val20 != null)
				{
					chrome = new ChromeDriver((ChromeDriverService)val6, options, TimeSpan.FromMinutes(3.0));
				}
				else
				{
					T0 val21 = (T0)(frmMain.setting.rbTypeChangeIP == 3);
					if (val21 == null)
					{
						T0 val22 = (T0)(frmMain.setting.rbTypeChangeIP == 5 && frmMain.setting.ccbTypeTMProxy == 1);
						if (val22 == null)
						{
							T0 val23 = (T0)(frmMain.setting.rbTypeChangeIP == 5 && frmMain.setting.ccbTypeTMProxy == 0);
							if (val23 != null)
							{
								setSocks5((T2)strProxy);
							}
							else
							{
								T0 val24 = (T0)(frmMain.setting.rbTypeChangeIP != 4 || frmMain.setting.TypeXProxy == 0 || frmMain.setting.TypeXProxy == 2);
								if (val24 != null)
								{
									setHttpProxy<Proxy, T2>((T2)strProxy);
								}
								else
								{
									T0 val25 = (T0)(frmMain.setting.TypeXProxy == 1 || frmMain.setting.TypeXProxy == 3 || (frmMain.listFBEntity[indexEntity].Socks != null && frmMain.listFBEntity[indexEntity].Socks.ToLower().StartsWith("socks5")));
									if (val25 != null)
									{
										setSocks5((T2)strProxy);
									}
								}
							}
						}
						else
						{
							setHttpProxy<Proxy, T2>((T2)strProxy);
						}
					}
					else
					{
						setSocks5((T2)strProxy);
					}
					chrome = new ChromeDriver((ChromeDriverService)val6, options);
				}
			}
			else
			{
				T0 val26 = (T0)frmMain.listFBEntity[indexEntity].Socks.Contains("@");
				if (val26 != null)
				{
					strProxy = (string)((IEnumerable<T2>)(object)frmMain.listFBEntity[indexEntity].Socks.Split((char[])(object)new T7[1] { (T7)64 })).Last();
					T2 val27 = ((IEnumerable<T2>)(object)frmMain.listFBEntity[indexEntity].Socks.Split((char[])(object)new T7[1] { (T7)64 })).First();
					createZipProxy<T2, T0>((T2)((string)val27).Split((char[])(object)new T7[1] { (T7)58 })[1], (T2)((string)val27).Split((char[])(object)new T7[1] { (T7)58 })[2]);
				}
				else
				{
					strProxy = $"{frmMain.listFBEntity[indexEntity].Socks.Split((char[])(object)new T7[1] { (T7)58 })[1]}:{frmMain.listFBEntity[indexEntity].Socks.Split((char[])(object)new T7[1] { (T7)58 })[2]}";
				}
				T0 val28 = (T0)frmMain.listFBEntity[indexEntity].Socks.ToLower().StartsWith("proxy");
				if (val28 != null)
				{
					setHttpProxy<Proxy, T2>((T2)strProxy);
				}
				else
				{
					setSocks5((T2)strProxy);
				}
				chrome = new ChromeDriver((ChromeDriverService)val6, options, TimeSpan.FromMinutes(3.0));
			}
			frmMain.countChrome++;
			actions = new Actions((IWebDriver)(object)chrome);
			((RemoteWebDriver)chrome).Manage().Window.Position = new Point(0, 0);
			((TimeSpan)(T5)((RemoteWebDriver)chrome).Manage().Timeouts().PageLoad).Add(TimeSpan.FromSeconds(30.0));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void createZipProxy<T0, T1>(T0 userName, T0 password)
	{
		//IL_0018: Expected O, but got I4
		try
		{
			T1 val = (T1)File.Exists(PROFILE_DIR + "\\proxy.crx");
			if (val != null)
			{
				try
				{
					File.Delete(PROFILE_DIR + "\\proxy.crx");
				}
				catch
				{
				}
			}
			CopyFilesRecursively<T0, int>((T0)"Proxy-Auto-Auth", (T0)(PROFILE_DIR + "\\Proxy-Auto-Auth"));
			T0 val2 = (T0)File.ReadAllText(PROFILE_DIR + "\\Proxy-Auto-Auth\\bg.js");
			val2 = (T0)((string)val2).Replace("user49371", (string)userName).Replace("yCkVoIHCCe", (string)password);
			File.WriteAllText(PROFILE_DIR + "\\Proxy-Auto-Auth\\bg.js", (string)val2);
			T0 sourceDirectoryName = (T0)(PROFILE_DIR + "\\Proxy-Auto-Auth");
			T0 destinationArchiveFileName = (T0)(PROFILE_DIR + "\\proxy.crx");
			ZipFile.CreateFromDirectory((string)sourceDirectoryName, (string)destinationArchiveFileName);
			options.AddExtension(PROFILE_DIR + "\\proxy.crx");
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CopyFilesRecursively<T0, T1>(T0 sourcePath, T0 targetPath)
	{
		//IL_0011: Expected O, but got I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0040: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		try
		{
			T0[] directories = (T0[])(object)Directory.GetDirectories((string)sourcePath, "*", SearchOption.AllDirectories);
			T1 val = (T1)0;
			while ((nint)val < directories.Length)
			{
				T0 val2 = (T0)((object[])(object)directories)[(object)val];
				Directory.CreateDirectory(((string)val2).Replace((string)sourcePath, (string)targetPath));
				val = (T1)(val + 1);
			}
			T0[] files = (T0[])(object)Directory.GetFiles((string)sourcePath, "*.*", SearchOption.AllDirectories);
			T1 val3 = (T1)0;
			while ((nint)val3 < files.Length)
			{
				T0 val4 = (T0)((object[])(object)files)[(object)val3];
				File.Copy((string)val4, ((string)val4).Replace((string)sourcePath, (string)targetPath), overwrite: true);
				val3 = (T1)(val3 + 1);
			}
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void setSocks5<T0>(T0 strProxy)
	{
		options.AddArguments((string[])(object)new T0[1] { (T0)("--proxy-server=socks5://" + (string)strProxy) });
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void setHttpProxy<T0, T1>(T1 strProxy)
	{
		T0 val = (T0)Activator.CreateInstance(typeof(Proxy));
		((Proxy)val).Kind = (ProxyKind)1;
		((Proxy)val).IsAutoDetect = false;
		T1 httpProxy = (T1)(((Proxy)val).SslProxy = (string)strProxy);
		((Proxy)val).HttpProxy = (string)httpProxy;
		((DriverOptions)options).Proxy = (Proxy)val;
		options.AddArgument("ignore-certificate-errors");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Spam_support<T0, T1, T2, T3, T4, T5, T6, T7, T8>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_0103: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_01f8: Expected O, but got I4
		//IL_0272: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_02e0: Expected O, but got I4
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected I4, but got Unknown
		//IL_0322: Expected I4, but got Unknown
		//IL_0340: Expected O, but got I4
		//IL_0363: Expected O, but got I4
		//IL_036e: Expected O, but got I4
		//IL_0382: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1[] array = null;
			try
			{
				array = (T1[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_support");
			}
			catch (Exception)
			{
			}
			T0 val2 = (T0)(array == null);
			if (val2 != null)
			{
				array = JsonConvert.DeserializeObject<T1[]>(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link_support").ToString());
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
					((List<SpamSupportEntity>)val3).Add(new SpamSupportEntity
					{
						Link = ((string)val5).Trim(),
						isReplied = false
					});
				}
				val4 = (T3)(val4 + 1);
			}
			string Message = flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Message").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(Message))).First();
			T3 val7 = (T3)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_From").ToString());
			T3 val8 = (T3)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_To").ToString());
			T0 val20;
			do
			{
				T0 val9 = (T0)frmMain.isRunning;
				if (val9 == null)
				{
					break;
				}
				T0 val10 = (T0)0;
				T4 enumerator = (T4)((List<SpamSupportEntity>)val3).GetEnumerator();
				try
				{
					while (((List<SpamSupportEntity>.Enumerator*)(&enumerator))->MoveNext())
					{
						SpamSupportEntity current = ((List<SpamSupportEntity>.Enumerator*)(&enumerator))->Current;
						T0 val11 = (T0)(!current.isReplied);
						if (val11 == null)
						{
							continue;
						}
						goUrl<T3, T0, T5, T6, T8, T1>((T1)current.Link);
						Thread.Sleep(1500);
						T1 comment = (T1)categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)].Comment;
						comment = frmMain.Spin_String<T1, Match, T0, char>(comment);
						T5 val12 = (T5)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
						T6 val13 = (T6)null;
						try
						{
							T7 enumerator2 = (T7)((ReadOnlyCollection<IWebElement>)val12).GetEnumerator();
							try
							{
								while (((IEnumerator)enumerator2).MoveNext())
								{
									T6 current2 = (T6)((IEnumerator<IWebElement>)enumerator2).Current;
									try
									{
										T0 val14 = (T0)(!string.IsNullOrWhiteSpace(((IWebElement)current2).Text) && ((IWebElement)current2).Text.Contains("previous messages"));
										if (val14 != null)
										{
											val13 = current2;
											break;
										}
									}
									catch
									{
									}
								}
							}
							finally
							{
								if (enumerator2 != null)
								{
									((IDisposable)enumerator2).Dispose();
								}
							}
						}
						catch (Exception ex2)
						{
							Console.WriteLine(ex2.Message);
						}
						T0 val15 = (T0)(val13 != null);
						if (val15 != null)
						{
							((IWebElement)val13).Click();
							Thread.Sleep(1500);
						}
						T5 val16 = (T5)((RemoteWebDriver)chrome).FindElements(By.TagName("textarea"));
						T0 val17 = (T0)(val16 != null && ((ReadOnlyCollection<IWebElement>)val16).Count > 0);
						if (val17 != null)
						{
							val10 = (T0)1;
							focusElement<IJavaScriptExecutor, T8, T6, T3, object>(((IEnumerable<T6>)val16).First(), (T3)1500);
							((IWebElement)((IEnumerable<T6>)val16).First()).Click();
							((IWebElement)((IEnumerable<T6>)val16).First()).SendKeys((string)comment);
							Thread.Sleep(1500);
							T5 val18 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@aria-label='Send']"));
							T0 val19 = (T0)(val18 == null || ((ReadOnlyCollection<IWebElement>)val18).Count <= 0);
							if (val19 != null)
							{
								val18 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@aria-label='Gửi']"));
							}
							((IWebElement)((IEnumerable<T6>)val18).First()).Click();
							Thread.Sleep(rnd.Next(val7 * 1000, val8 * 1000));
						}
						else
						{
							current.isReplied = true;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<SpamSupportEntity>.Enumerator*)(&enumerator))).Dispose();
				}
				val20 = (T0)(val10 == null);
			}
			while (val20 == null);
			setMessage((T1)"Spam Done", (T0)0);
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.Message);
			setMessage((T1)ex3.Message, (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Post_on_newfeed<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0136: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0204: Expected O, but got I4
		//IL_023f: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		//IL_02ca: Expected O, but got I4
		//IL_02f8: Expected O, but got I4
		//IL_0302: Expected O, but got I4
		//IL_0305: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		//IL_0380: Expected O, but got I4
		//IL_03a5: Expected O, but got I4
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_03d3: Expected O, but got I4
		//IL_03ee: Expected O, but got I4
		//IL_044d: Expected O, but got I4
		//IL_0486: Expected O, but got I4
		//IL_04af: Expected O, but got I4
		//IL_04be: Expected O, but got I4
		//IL_04c9: Expected O, but got I4
		//IL_0545: Expected O, but got I4
		//IL_0586: Expected O, but got I4
		//IL_05be: Expected O, but got I4
		//IL_05cd: Expected O, but got I4
		//IL_05eb: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Content_(Spin{ | | | })").ToString();
			T1 val3 = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Share_with").ToString();
			T1 path = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Image_Path").ToString();
			T2 val4 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Number_Of_Images").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random_Images").ToString());
			T3 val6 = (T3)Activator.CreateInstance(typeof(T3));
			T0 val7 = (T0)Directory.Exists((string)path);
			if (val7 != null)
			{
				T1[] files = (T1[])(object)Directory.GetFiles((string)path);
				T2 val8 = (T2)0;
				while ((nint)val8 < files.Length)
				{
					T1 val9 = (T1)((object[])(object)files)[(object)val8];
					T0 val10 = (T0)Regex.IsMatch(((string)val9).ToLower(), ".jpg|.png|.gif$");
					if (val10 != null)
					{
						((List<ImagesList>)val6).Add(new ImagesList
						{
							ImagePath = (string)val9,
							Posted = false
						});
					}
					val8 = (T2)(val8 + 1);
				}
			}
			T0 val11 = val5;
			if (val11 != null)
			{
				val6 = (T3)((IEnumerable<ImagesList>)val6).OrderBy((Func<ImagesList, T9>)(object)(Func<ImagesList, Guid>)((ImagesList x) => (T9)Guid.NewGuid())).ToList();
			}
			T0 val12 = (T0)((string)val2).Contains("{");
			if (val12 != null)
			{
				val2 = spintax<T1, Match, T0, Random, char>(rnd, val2);
			}
			goUrl<T2, T0, T5, T4, T8, T1>((T1)"https://mbasic.facebook.com/");
			Thread.Sleep(1500);
			countError = 0;
			T4 val13 = (T4)null;
			while (true)
			{
				T0 val14 = (T0)frmMain.isRunning;
				if (val14 != null)
				{
					T5 val15 = (T5)((RemoteWebDriver)chrome).FindElements(By.Name("xc_message"));
					T0 val16 = (T0)(((ReadOnlyCollection<IWebElement>)val15).Count > 0);
					if (val16 == null)
					{
						countError++;
						T0 val17 = (T0)(countError >= 10);
						if (val17 != null)
						{
							break;
						}
						Thread.Sleep(1500);
						continue;
					}
					val13 = ((IEnumerable<T4>)val15).First();
					break;
				}
				break;
			}
			T0 val18 = (T0)(val13 != null);
			if (val18 != null)
			{
				T5 val19 = (T5)((RemoteWebDriver)chrome).FindElements(By.Name("view_privacy"));
				T0 val20 = (T0)(((ReadOnlyCollection<IWebElement>)val19).Count > 0);
				if (val20 != null)
				{
					T0 val21 = (T0)(((IWebElement)((IEnumerable<T4>)val19).First()).GetAttribute("value") != null && !((IWebElement)((IEnumerable<T4>)val19).First()).GetAttribute("value").Equals((string)val3));
					if (val21 != null)
					{
						((IWebElement)((IEnumerable<T4>)val19).First()).Click();
						Thread.Sleep(1500);
						T5 val22 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[@aria-label='" + (string)val3 + "']"));
						T0 val23 = (T0)(((ReadOnlyCollection<IWebElement>)val22).Count > 0);
						if (val23 != null)
						{
							((IWebElement)((IEnumerable<T4>)val22).First()).Click();
							Thread.Sleep(1500);
							T5 val24 = (T5)((RemoteWebDriver)chrome).FindElements(By.PartialLinkText("Cancel"));
							T0 val25 = (T0)(((ReadOnlyCollection<IWebElement>)val24).Count > 0);
							if (val25 != null)
							{
								((IWebElement)((IEnumerable<T4>)val24).First()).Click();
								Thread.Sleep(1500);
							}
						}
					}
				}
				T0 val26 = (T0)(((List<ImagesList>)val6).Count > 0 && (nint)val4 > 0);
				if (val26 != null)
				{
					T2 val27 = (T2)0;
					T0 val28 = (T0)0;
					T5 source = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@value='Photo']"));
					((IWebElement)((IEnumerable<T4>)source).First()).Click();
					Thread.Sleep(1500);
					while (true)
					{
						T0 val29 = (T0)frmMain.isRunning;
						if (val29 == null)
						{
							break;
						}
						val28 = (T0)0;
						T5 val30 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@type='file']"));
						T6 enumerator = (T6)((ReadOnlyCollection<IWebElement>)val30).GetEnumerator();
						try
						{
							while (((IEnumerator)enumerator).MoveNext())
							{
								T4 current = (T4)((IEnumerator<IWebElement>)enumerator).Current;
								T0 val31 = (T0)(((IWebElement)current).Enabled && ((IWebElement)current).Displayed);
								if (val31 == null)
								{
									continue;
								}
								T7 enumerator2 = (T7)((List<ImagesList>)val6).GetEnumerator();
								try
								{
									while (((List<ImagesList>.Enumerator*)(&enumerator2))->MoveNext())
									{
										ImagesList current2 = ((List<ImagesList>.Enumerator*)(&enumerator2))->Current;
										T0 val32 = (T0)(!current2.Posted);
										if (val32 != null)
										{
											current2.Posted = true;
											((IWebElement)current).SendKeys(current2.ImagePath);
											val27 = (T2)(val27 + 1);
											val28 = (T0)1;
											break;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<ImagesList>.Enumerator*)(&enumerator2))).Dispose();
								}
								T0 val33 = (T0)(val27 >= val4);
								if (val33 != null)
								{
									break;
								}
							}
						}
						finally
						{
							if (enumerator != null)
							{
								((IDisposable)enumerator).Dispose();
							}
						}
						T0 val34 = val28;
						if (val34 != null)
						{
							T5 source2 = (T5)((RemoteWebDriver)chrome).FindElements(By.Name("add_photo_done"));
							((IWebElement)((IEnumerable<T4>)source2).First()).Click();
							Thread.Sleep(1500);
							T0 val35 = (T0)(val27 < val4);
							if (val35 != null)
							{
								T5 source3 = (T5)((RemoteWebDriver)chrome).FindElements(By.Name("view_photo"));
								((IWebElement)((IEnumerable<T4>)source3).First()).Click();
								Thread.Sleep(1500);
								continue;
							}
							setMessage((T1)$"Send file {val27}/{val4}", (T0)0);
							break;
						}
						setMessage((T1)"Input file not found!", (T0)0);
						break;
					}
				}
				T0 val36 = (T0)(!string.IsNullOrWhiteSpace((string)val2));
				if (val36 != null)
				{
					val13 = ((IEnumerable<T4>)((RemoteWebDriver)chrome).FindElements(By.Name("xc_message"))).First();
					((IWebElement)val13).Click();
					sendKeysWithEmojis<T1, IJavaScriptExecutor, T4, object>(val13, val2);
					Thread.Sleep(1500);
				}
				T5 val37 = (T5)((RemoteWebDriver)chrome).FindElements(By.Name("view_post"));
				T0 val38 = (T0)(((ReadOnlyCollection<IWebElement>)val37).Count > 0 && ((IWebElement)((IEnumerable<T4>)val37).First()).Enabled && ((IWebElement)((IEnumerable<T4>)val37).First()).Displayed);
				if (val38 != null)
				{
					((IWebElement)((IEnumerable<T4>)val37).First()).Click();
					Thread.Sleep(1500);
					T5 val39 = (T5)((RemoteWebDriver)chrome).FindElements(By.PartialLinkText("Cancel"));
					T0 val40 = (T0)(((ReadOnlyCollection<IWebElement>)val39).Count > 0);
					if (val40 != null)
					{
						((IWebElement)((IEnumerable<T4>)val39).First()).Click();
						Thread.Sleep(1500);
					}
					goUrl<T2, T0, T5, T4, T8, T1>((T1)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
					setMessage((T1)"Posted", (T0)0);
				}
			}
			else
			{
				setMessage((T1)"Post conent lỗi", (T0)0);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			setMessage((T1)ex.Message, (T0)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void sendKeysWithEmojis<T0, T1, T2, T3>(T2 element, T0 text)
	{
		T0 val = (T0)"var elm = arguments[0],txt = arguments[1]; elm.value += txt; elm.dispatchEvent(new Event('keydown', { bubbles: true })); elm.dispatchEvent(new Event('keypress', { bubbles: true })); elm.dispatchEvent(new Event('input', { bubbles: true })); elm.dispatchEvent(new Event('keyup', { bubbles: true })); ";
		T1 val2 = (T1)chrome;
		((IJavaScriptExecutor)val2).ExecuteScript((string)val, (object[])(object)new T3[2]
		{
			(T3)element,
			(T3)text
		});
	}

	public T3 AutoSortListString<T0, T1, T2, T3>(T3 listString)
	{
		//IL_0007: Expected O, but got I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected I4, but got Unknown
		//IL_001b: Expected O, but got I4
		//IL_0022: Expected I4, but got O
		//IL_002c: Expected I4, but got O
		//IL_0031: Expected I4, but got O
		//IL_0039: Expected I4, but got O
		//IL_003e: Expected O, but got I4
		T0 val = (T0)((List<string>)listString).Count;
		while (true)
		{
			T2 val2 = (T2)((nint)val > 1);
			if (val2 == null)
			{
				break;
			}
			val = (T0)(val - 1);
			T0 val3 = (T0)rnd.Next(val + 1);
			T1 value = (T1)((List<string>)listString)[(int)val3];
			((List<string>)listString)[(int)val3] = ((List<string>)listString)[(int)val];
			((List<string>)listString)[(int)val] = (string)value;
		}
		return listString;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 spintax<T0, T1, T2, T3, T4>(T3 rnd, T0 str)
	{
		//IL_007c: Expected O, but got I4
		T0 pattern = (T0)"{[^{}]*}";
		T1 val = (T1)Regex.Match((string)str, (string)pattern);
		while (true)
		{
			T2 val2 = (T2)((Group)val).Success;
			if (val2 == null)
			{
				break;
			}
			T0 val3 = (T0)((string)str).Substring(((Capture)val).Index + 1, ((Capture)val).Length - 2);
			T0[] array = (T0[])(object)((string)val3).Split((char[])(object)new T4[1] { (T4)124 });
			str = (T0)(((string)str).Substring(0, ((Capture)val).Index) + (string)((object[])(object)array)[((Random)rnd).Next(array.Length)] + ((string)str).Substring(((Capture)val).Index + ((Capture)val).Length));
			val = (T1)Regex.Match((string)str, (string)pattern);
		}
		return str;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Click_Home<T0, T1, T2, T3>()
	{
		//IL_0002: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		T0 result = (T0)0;
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val == null)
		{
			try
			{
				T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[@aria-label='Facebook']"));
				T0 val3 = (T0)(((ReadOnlyCollection<IWebElement>)val2).Count > 0);
				if (val3 != null)
				{
					focusElement<IJavaScriptExecutor, T2, T3, int, object>(((IEnumerable<T3>)val2).First(), 300);
					((IWebElement)((IEnumerable<T3>)val2).First()).Click();
					result = (T0)1;
					Thread.Sleep(2000);
				}
			}
			catch (Exception ex)
			{
				result = (T0)0;
				Console.WriteLine(ex.Message);
			}
			return result;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add_Friend_By_UID_Facebook<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected I4, but got Unknown
		//IL_0144: Expected I4, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Random").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Reload").ToString());
			T1 val4 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val5 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T2[] array = null;
			try
			{
				array = (T2[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"List_UID");
			}
			catch (Exception)
			{
			}
			T0 val6 = (T0)(array == null);
			if (val6 != null)
			{
				array = JsonConvert.DeserializeObject<T2[]>(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"List_UID").ToString());
			}
			T0 val7 = val2;
			if (val7 != null)
			{
				array = array.OrderBy((Func<T2, T1>)(object)(Func<string, int>)((T2 x) => (T1)rnd.Next())).ToArray();
			}
			goUrl<T1, T0, ReadOnlyCollection<IWebElement>, IWebElement, T3, T2>((T2)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
			T2[] array2 = array;
			T1 val8 = (T1)0;
			while ((nint)val8 < array2.Length)
			{
				T2 uid = (T2)((object[])(object)array2)[(object)val8];
				requestAddFriendFetch<Dictionary<string, string>, T1, T2, T0, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, Size, IJavaScriptExecutor, object>(uid);
				T0 val9 = val3;
				if (val9 != null)
				{
					goUrl<T1, T0, ReadOnlyCollection<IWebElement>, IWebElement, T3, T2>((T2)((RemoteWebDriver)chrome).Url);
				}
				Thread.Sleep(rnd.Next(val4 * 1000, val5 * 1000));
				val8 = (T1)(val8 + 1);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 clickFriends<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0108: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0117: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0191: Expected O, but got I4
		T0 val = (T0)1;
		try
		{
			T1 val2 = (T1)0;
			while (true)
			{
				T0 val3 = (T0)frmMain.isRunning;
				if (val3 == null)
				{
					break;
				}
				T2 val4 = (T2)((RemoteWebDriver)chrome).FindElements(By.LinkText("Friends"));
				T0 val5 = (T0)(((ReadOnlyCollection<IWebElement>)val4).Count > 0);
				if (val5 != null)
				{
					T3 enumerator = (T3)((ReadOnlyCollection<IWebElement>)val4).GetEnumerator();
					try
					{
						while (((IEnumerator)enumerator).MoveNext())
						{
							T4 current = (T4)((IEnumerator<IWebElement>)enumerator).Current;
							T0 val6 = (T0)(((IWebElement)current).Displayed && ((IWebElement)current).Enabled && ((IWebElement)current).GetAttribute("href") != null);
							if (val6 != null)
							{
								((IWebElement)current).GetAttribute("href");
								focusElement<IJavaScriptExecutor, T6, T4, T1, object>(current, (T1)200);
								((IWebElement)current).Click();
								Thread.Sleep(1500);
								break;
							}
						}
					}
					finally
					{
						if (enumerator != null)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
				}
				T0 val7 = (T0)(val4 != null && ((ReadOnlyCollection<IWebElement>)val4).Count > 0);
				if (val7 != null)
				{
					break;
				}
				T2 source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
				T1 val8 = (T1)0;
				while (true)
				{
					T0 val9 = (T0)((nint)val8 < 20);
					if (val9 == null)
					{
						break;
					}
					((IWebElement)((IEnumerable<T4>)source).First()).SendKeys(Keys.Down);
					val8 = (T1)(val8 + 1);
				}
				val2 = (T1)(val2 + 1);
				T0 val10 = (T0)((nint)val2 > 10);
				if (val10 == null)
				{
					Thread.Sleep(1500);
					continue;
				}
				val = (T0)0;
				break;
			}
			while (true)
			{
				T0 val11 = (T0)(frmMain.isRunning & val);
				if (val11 != null)
				{
					T2 val12 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@placeholder='Search']"));
					T0 val13 = (T0)(val12 != null && ((ReadOnlyCollection<IWebElement>)val12).Count > 0);
					if (val13 == null)
					{
						Thread.Sleep(1500);
						continue;
					}
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			val = (T0)0;
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 findTagAddFriend<T0, T1, T2, T3, T4>()
	{
		//IL_002f: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006b: Expected O, but got I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0087: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		T0 result = (T0)null;
		try
		{
			countError = 0;
			while (true)
			{
				T2 val = (T2)frmMain.isRunning;
				if (val == null)
				{
					break;
				}
				T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//span[text()='Add Friend']"));
				T2 val3 = (T2)(((ReadOnlyCollection<IWebElement>)val2).Count > 5);
				if (val3 == null)
				{
					T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
					T3 val4 = (T3)0;
					while (true)
					{
						T2 val5 = (T2)((nint)val4 < 80);
						if (val5 == null)
						{
							break;
						}
						((IWebElement)((IEnumerable<T0>)source).First()).SendKeys(Keys.Down);
						T2 val6 = (T2)(val4 % 10 == 0);
						if (val6 != null)
						{
							Thread.Sleep(1500);
						}
						val4 = (T3)(val4 + 1);
					}
					countError++;
					T2 val7 = (T2)(countError >= 10);
					if (val7 == null)
					{
						Thread.Sleep(1500);
						continue;
					}
					break;
				}
				result = ((IEnumerable<T0>)val2).Last();
				break;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add_Friend_By_Rival<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0009: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_02c4: Expected O, but got I4
		//IL_02e6: Expected O, but got I4
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Invalid comparison between Unknown and I4
		//IL_0302: Expected O, but got I4
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_031d: Expected O, but got I4
		//IL_0330: Expected O, but got I4
		//IL_0341: Expected O, but got I4
		//IL_0395: Expected O, but got I4
		//IL_03d4: Expected O, but got I4
		//IL_03fd: Expected O, but got I4
		//IL_0474: Expected O, but got I4
		//IL_049b: Expected O, but got I4
		//IL_04f9: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected O, but got Unknown
		//IL_0577: Expected O, but got I4
		//IL_05a5: Expected O, but got I4
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Invalid comparison between Unknown and I4
		//IL_05c1: Expected O, but got I4
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Expected O, but got Unknown
		//IL_05dc: Expected O, but got I4
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected O, but got Unknown
		//IL_05f1: Expected O, but got I4
		//IL_0603: Expected O, but got I4
		//IL_060e: Expected O, but got I4
		//IL_0624: Expected O, but got I4
		countAddFriends = 0;
		T0 val = (T0)0;
		T1 val2 = (T1)(!frmMain.isRunning || chrome == null);
		if (val2 != null)
		{
			return;
		}
		try
		{
			listFriendAdded.Clear();
			T1 val3 = (T1)bool.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"Kết bạn với đối thủ").ToString());
			val = (T0)int.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"Số lượng").ToString());
			T1 random = (T1)bool.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"Random").ToString());
			int.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"Thời gian trễ từ").ToString());
			int.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"Thời gian trễ đến").ToString());
			T1 val4 = (T1)bool.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"KB thành phố").ToString());
			T1 val5 = (T1)bool.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"KB khu vực").ToString());
			T1 val6 = (T1)bool.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"KB theo dõi").ToString());
			T1 val7 = (T1)bool.Parse(flow.getValue<object, List<FBFlowField>, T1, T4>((T4)"KB đang theo dõi").ToString());
			goUrl<T0, T1, T2, T3, T6, T4>((T4)frmMain.listFBEntity[indexEntity].RivalLink);
			Thread.Sleep(2000);
			T1 val8 = val3;
			if (val8 != null)
			{
				T2 val9 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//span[text()='Add Friend']"));
				T1 val10 = (T1)(((ReadOnlyCollection<IWebElement>)val9).Count > 0 && ((IWebElement)((IEnumerable<T3>)val9).First()).Enabled && ((IWebElement)((IEnumerable<T3>)val9).First()).Displayed);
				if (val10 != null)
				{
					focusElement<IJavaScriptExecutor, T6, T3, T0, object>(((IEnumerable<T3>)val9).First(), (T0)300);
					((IWebElement)((IEnumerable<T3>)val9).First()).Click();
					Thread.Sleep(2000);
				}
			}
			T1 val11 = (T1)(clickFriends<T1, T0, T2, T5, T3, T4, T6>() == null);
			if (val11 != null)
			{
				return;
			}
			T1 val12 = val4;
			if (val12 == null)
			{
				T1 val13 = val5;
				if (val13 != null)
				{
					goUrl<T0, T1, T2, T3, T6, T4>((T4)string.Format("{0}/{1}", frmMain.listFBEntity[indexEntity].RivalLink, "friends_hometown"));
				}
				else
				{
					T1 val14 = val6;
					if (val14 == null)
					{
						T1 val15 = val7;
						if (val15 != null)
						{
							goUrl<T0, T1, T2, T3, T6, T4>((T4)string.Format("{0}/{1}", frmMain.listFBEntity[indexEntity].RivalLink, "following"));
						}
					}
					else
					{
						goUrl<T0, T1, T2, T3, T6, T4>((T4)string.Format("{0}/{1}", frmMain.listFBEntity[indexEntity].RivalLink, "followers"));
					}
				}
			}
			else
			{
				goUrl<T0, T1, T2, T3, T6, T4>((T4)string.Format("{0}/{1}", frmMain.listFBEntity[indexEntity].RivalLink, "friends_current_city"));
			}
			T1 val16 = (T1)((RemoteWebDriver)chrome).PageSource.Contains("No Friends To Show");
			if (val16 == null)
			{
				T2 source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
				T0 val17 = (T0)0;
				while (true)
				{
					T1 val18 = (T1)((nint)val17 < 6);
					if (val18 == null)
					{
						break;
					}
					((IWebElement)((IEnumerable<T3>)source).First()).SendKeys(Keys.End);
					T1 val19 = (T1)(val17 % 2 == 0);
					if (val19 != null)
					{
						Thread.Sleep(1500);
					}
					val17 = (T0)(val17 + 1);
				}
				T3 val20 = findTagAddFriend<T3, T2, T1, T0, T6>();
				T1 val21 = (T1)(val20 == null);
				if (val21 != null)
				{
					setMessage((T4)"No Friends To Show", (T1)0);
					return;
				}
				T3 parent = GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(val20))))))));
				T4 attribute = (T4)((IWebElement)parent).GetAttribute("class");
				T1 val22 = (T1)(!string.IsNullOrWhiteSpace((string)attribute));
				if (val22 == null)
				{
					return;
				}
				T4 val23 = (T4)((string)attribute).Split((char[])(object)new T7[1] { (T7)32 })[((IEnumerable<T4>)(object)((string)attribute).Split((char[])(object)new T7[1] { (T7)32 })).Count() - 1];
				countError = 0;
				T0 val24 = (T0)0;
				T1 val41;
				do
				{
					T1 val25 = (T1)frmMain.isRunning;
					if (val25 == null)
					{
						break;
					}
					T2 val26 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@aria-label='Close chat']"));
					T1 val27 = (T1)(((ReadOnlyCollection<IWebElement>)val26).Count > 0);
					if (val27 != null)
					{
						((IWebElement)((IEnumerable<T3>)val26).First()).Click();
						Thread.Sleep(2000);
					}
					T2 val28 = (T2)((RemoteWebDriver)chrome).FindElements(By.ClassName((string)val23));
					T4 val29 = (T4)"";
					T4 titleProfile = (T4)"";
					T3 val30 = (T3)null;
					T5 enumerator = (T5)((ReadOnlyCollection<IWebElement>)val28).GetEnumerator();
					try
					{
						while (((IEnumerator)enumerator).MoveNext())
						{
							T3 current = (T3)((IEnumerator<IWebElement>)enumerator).Current;
							T1 val31 = (T1)(((IWebElement)current).Displayed && ((IWebElement)current).Text.Contains("Add Friend"));
							if (val31 == null)
							{
								continue;
							}
							T2 val32 = (T2)((ISearchContext)current).FindElements(By.TagName("a"));
							T1 val33 = (T1)(((ReadOnlyCollection<IWebElement>)val32).Count > 0);
							if (val33 == null)
							{
								continue;
							}
							T3 val34 = ((IEnumerable<T3>)val32).Where((Func<T3, bool>)(object)(Func<IWebElement, bool>)((T3 a) => (T1)(((IWebElement)a).Displayed && !string.IsNullOrWhiteSpace(((IWebElement)a).Text)))).First();
							val29 = (T4)((IWebElement)val34).GetAttribute("href");
							titleProfile = (T4)((IWebElement)val34).Text;
							T1 val35 = (T1)(!listFriendAdded.Contains((string)val29));
							if (val35 != null)
							{
								try
								{
									listFriendAdded.Add((string)val29);
									val30 = val34;
									focusElement<IJavaScriptExecutor, T6, T3, T0, object>(val30, (T0)500);
									actions = new Actions((IWebDriver)(object)chrome);
									actions.MoveToElement((IWebElement)val30).Perform();
								}
								catch (Exception ex)
								{
									Console.WriteLine(ex.Message);
									continue;
								}
								break;
							}
						}
					}
					finally
					{
						if (enumerator != null)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					T1 val36 = (T1)(!string.IsNullOrWhiteSpace((string)val29));
					if (val36 != null)
					{
						popupAddFriend<T1, T0, T3, T2, List<IWebElement>, T6, T4>(random, val, titleProfile, val30);
					}
					else
					{
						source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
						T0 val37 = (T0)0;
						while (true)
						{
							T1 val38 = (T1)((nint)val37 < 6);
							if (val38 == null)
							{
								break;
							}
							((IWebElement)((IEnumerable<T3>)source).First()).SendKeys(Keys.End);
							T1 val39 = (T1)(val37 % 2 == 0);
							if (val39 != null)
							{
								Thread.Sleep(2000);
							}
							val37 = (T0)(val37 + 1);
						}
						val24 = (T0)(val24 + 1);
						T1 val40 = (T1)((nint)val24 >= 10);
						if (val40 != null)
						{
							break;
						}
					}
					val41 = (T1)(countAddFriends >= (nint)val);
				}
				while (val41 == null);
			}
			else
			{
				setMessage((T4)"No Friends To Show", (T1)0);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 popupAddFriend<T0, T1, T2, T3, T4, T5, T6>(T0 Random, T1 Quantity, T6 titleProfile, T2 tagHover)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0006: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		//IL_0098: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_011f: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_01e2: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_0214: Expected O, but got I4
		//IL_021f: Expected I4, but got O
		//IL_022f: Expected I4, but got O
		//IL_0245: Expected I4, but got O
		//IL_0260: Expected O, but got I4
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0274: Expected O, but got I4
		//IL_0283: Expected I4, but got O
		//IL_028e: Expected I4, but got O
		//IL_02c2: Expected O, but got I4
		//IL_02cb: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_02f2: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0347: Expected O, but got I4
		//IL_036f: Expected O, but got I4
		//IL_03b0: Expected O, but got I4
		//IL_03c8: Expected O, but got I4
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected O, but got Unknown
		//IL_03f5: Expected O, but got I4
		//IL_0407: Expected O, but got I4
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_0455: Expected O, but got I4
		//IL_045f: Expected O, but got I4
		T0 result = (T0)1;
		try
		{
			T1 val = (T1)0;
			T0 val2 = (T0)1;
			if (Random != null)
			{
				T0 val3 = (T0)(!listRandomBool[rnd.Next(0, listRandomBool.Count - 1)]);
				if (val3 != null)
				{
					val2 = (T0)0;
				}
			}
			T0 val4 = val2;
			if (val4 != null)
			{
				T2 val5 = (T2)null;
				T2 val6 = (T2)null;
				val = (T1)0;
				T0 val13;
				do
				{
					T0 val7 = (T0)frmMain.isRunning;
					if (val7 == null)
					{
						break;
					}
					T3 val8 = (T3)((RemoteWebDriver)chrome).FindElements(By.LinkText((string)titleProfile));
					T0 val9 = (T0)(((ReadOnlyCollection<IWebElement>)val8).Count >= 2);
					if (val9 == null)
					{
						Thread.Sleep(1000);
						val = (T1)(val + 1);
						T0 val10 = (T0)(val % 5 == 0);
						if (val10 != null)
						{
							try
							{
								T3 val11 = (T3)((RemoteWebDriver)chrome).FindElements(By.PartialLinkText((string)titleProfile));
								T0 val12 = (T0)(((ReadOnlyCollection<IWebElement>)val11).Count > 0);
								if (val12 != null)
								{
									tagHover = ((IEnumerable<T2>)val11).First();
									focusElement<IJavaScriptExecutor, T5, T2, T1, object>(tagHover, (T1)200);
									actions = new Actions((IWebDriver)(object)chrome);
									actions.MoveToElement((IWebElement)tagHover).Perform();
									Thread.Sleep(3000);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
						}
						val13 = (T0)((nint)val >= 20);
						continue;
					}
					val5 = GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(((IEnumerable<T2>)val8).Last()))))))))));
					T3 source = (T3)((ISearchContext)val5).FindElements(By.TagName("span"));
					T4 val14 = (T4)((IEnumerable<T2>)source).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Text.Equals("Add Friend")))).ToList();
					countAddFriends++;
					setMessage((T6)$"Add Friend: {(T1)countAddFriends}/{Quantity}", (T0)0);
					T0 val15 = (T0)(((List<IWebElement>)val14).Count > 0);
					if (val15 == null)
					{
						T3 val16 = (T3)((ISearchContext)val5).FindElements(By.TagName("div"));
						T1 val17 = (T1)(((ReadOnlyCollection<IWebElement>)val16).Count - 1);
						while (true)
						{
							T0 val18 = (T0)((nint)val17 >= 0);
							if (val18 != null)
							{
								T0 val19 = (T0)(((ReadOnlyCollection<IWebElement>)val16)[(int)val17].Displayed && ((ReadOnlyCollection<IWebElement>)val16)[(int)val17].GetAttribute("aria-label") != null && ((ReadOnlyCollection<IWebElement>)val16)[(int)val17].GetAttribute("aria-label").Equals("Add Friend"));
								if (val19 == null)
								{
									val17 = (T1)(val17 - 1);
									continue;
								}
								val6 = (T2)((ReadOnlyCollection<IWebElement>)val16)[(int)val17];
								((ReadOnlyCollection<IWebElement>)val16)[(int)val17].Click();
								break;
							}
							break;
						}
					}
					else
					{
						val6 = ((IEnumerable<T2>)val14).First();
						((IWebElement)((IEnumerable<T2>)val14).First()).Click();
					}
					Thread.Sleep(2000);
					break;
				}
				while (val13 == null);
				T0 val20 = (T0)(val5 != null && val6 != null);
				if (val20 != null)
				{
					val = (T1)0;
					while (true)
					{
						T0 val21 = (T0)frmMain.isRunning;
						if (val21 == null)
						{
							break;
						}
						try
						{
							T0 val22 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("has reached the limit");
							if (val22 != null)
							{
								T3 val23 = (T3)((RemoteWebDriver)chrome).FindElements(By.XPath("//span[text()='OK']"));
								T0 val24 = (T0)(((ReadOnlyCollection<IWebElement>)val23).Count > 0);
								if (val24 != null)
								{
									((IWebElement)((IEnumerable<T2>)val23).First()).Click();
								}
								break;
							}
							T0 val25 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("People You May Know");
							if (val25 != null)
							{
								T3 val26 = (T3)((RemoteWebDriver)chrome).FindElements(By.XPath("//span[text()='OK']"));
								T0 val27 = (T0)(((ReadOnlyCollection<IWebElement>)val26).Count > 0);
								if (val27 != null)
								{
									((IWebElement)((IEnumerable<T2>)val26).First()).Click();
								}
								break;
							}
							T0 val28 = (T0)(((IWebElement)val6).GetAttribute("aria-label") != null && ((IWebElement)val6).GetAttribute("aria-label").Equals("Cancel Request"));
							if (val28 == null)
							{
								T0 val29 = (T0)((IWebElement)val5).Text.Contains("Cancel Request");
								if (val29 == null)
								{
									goto IL_03e8;
								}
							}
						}
						catch (Exception ex2)
						{
							Console.WriteLine(ex2.Message);
						}
						break;
						IL_03e8:
						val = (T1)(val + 1);
						T0 val30 = (T0)((nint)val >= 5);
						if (val30 != null)
						{
							try
							{
								focusElement<IJavaScriptExecutor, T5, T2, T1, object>(tagHover, (T1)200);
								actions = new Actions((IWebDriver)(object)chrome);
								actions.MoveToElement((IWebElement)tagHover).Perform();
							}
							catch (Exception ex3)
							{
								Console.WriteLine(ex3.Message);
							}
						}
						T0 val31 = (T0)((nint)val >= 10);
						if (val31 == null)
						{
							Thread.Sleep(1500);
							continue;
						}
						break;
					}
				}
			}
		}
		catch (Exception ex4)
		{
			result = (T0)0;
			Console.WriteLine(ex4.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Outgoing_Friend<T0, T1, T2, T3>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected I4, but got Unknown
		//IL_0159: Expected I4, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Random").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Reload").ToString());
			T1 val4 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_From").ToString());
			T1 val5 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"Delay_To").ToString());
			T2[] array = null;
			try
			{
				array = (T2[])(object)(string[])flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"List_UID");
			}
			catch (Exception)
			{
			}
			T0 val6 = (T0)(array == null);
			if (val6 != null)
			{
				array = JsonConvert.DeserializeObject<T2[]>(flow.getValue<object, List<FBFlowField>, T0, T2>((T2)"List_UID").ToString());
			}
			T0 val7 = val2;
			if (val7 != null)
			{
				array = array.OrderBy((Func<T2, T1>)(object)(Func<string, int>)((T2 x) => (T1)rnd.Next())).ToArray();
			}
			T2[] array2 = array;
			T1 val8 = (T1)0;
			while ((nint)val8 < array2.Length)
			{
				T2 val9 = (T2)((object[])(object)array2)[(object)val8];
				goUrl<T1, T0, ReadOnlyCollection<IWebElement>, IWebElement, T3, T2>((T2)string.Format("{0}{1}", ResouceControl.getResouce("RESOUCE_HOME_PAGE"), val9));
				requestOutingFriendFetch<Dictionary<string, string>, T1, T2, T0, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, Size, IJavaScriptExecutor, object>(val9);
				requestCancelRequestAddFriendFetch<Dictionary<string, string>, T1, T2, T0, Dictionary<string, string>.Enumerator, KeyValuePair<string, string>, Size, IJavaScriptExecutor, object>(val9);
				T0 val10 = val3;
				if (val10 != null)
				{
					goUrl<T1, T0, ReadOnlyCollection<IWebElement>, IWebElement, T3, T2>((T2)((RemoteWebDriver)chrome).Url);
				}
				Thread.Sleep(rnd.Next(val4 * 1000, val5 * 1000));
				val8 = (T1)(val8 + 1);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void requestOutingFriendFetch<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 uid)
	{
		//IL_0111: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_016e: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("__user", "");
		((Dictionary<string, string>)val).Add("__a", "");
		((Dictionary<string, string>)val).Add("__dyn", "");
		((Dictionary<string, string>)val).Add("__req", "");
		((Dictionary<string, string>)val).Add("__beoa", "");
		((Dictionary<string, string>)val).Add("dpr", "");
		((Dictionary<string, string>)val).Add("__rev", "");
		((Dictionary<string, string>)val).Add("__s", "");
		((Dictionary<string, string>)val).Add("__hsi", "");
		((Dictionary<string, string>)val).Add("__comet_req", "");
		((Dictionary<string, string>)val).Add("fb_dtsg", "");
		((Dictionary<string, string>)val).Add("jazoest", "");
		((Dictionary<string, string>)val).Add("__spin_r", "");
		((Dictionary<string, string>)val).Add("__spin_t", "");
		((Dictionary<string, string>)val).Add("__spin_b", "");
		T1 val2 = (T1)0;
		while (true)
		{
			T3 val3 = (T3)frmMain.isRunning;
			if (val3 == null)
			{
				break;
			}
			val = GetFetchData<T2, T1, T3, T5, T0, T7, T8, char>(val);
			T3 val4 = (T3)0;
			T4 enumerator = (T4)((Dictionary<string, string>)val).GetEnumerator();
			try
			{
				while (((Dictionary<string, string>.Enumerator*)(&enumerator))->MoveNext())
				{
					T3 val5 = (T3)string.IsNullOrWhiteSpace(((KeyValuePair<string, string>)(T5)((Dictionary<string, string>.Enumerator*)(&enumerator))->Current).Value);
					if (val5 != null)
					{
						val4 = (T3)1;
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(Dictionary<string, string>.Enumerator*)(&enumerator))).Dispose();
			}
			val2 = (T1)(val2 + 1);
			T3 val6 = (T3)((nint)val2 >= 10);
			if (val6 != null)
			{
				break;
			}
			T3 val7 = (T3)(val4 == null);
			if (val7 != null)
			{
				break;
			}
			Thread.Sleep(2000);
		}
		T2 script = (T2)string.Concat((string[])(object)new T2[37]
		{
			(T2)"fetch(\"https://www.facebook.com/ajax/profile/removefriendconfirm.php\", {\"headers\": {\"accept\": \"*/*\",\"accept-language\": \"q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5\",\"content-type\": \"application/x-www-form-urlencoded\",\"sec-fetch-dest\": \"empty\",\"sec-fetch-mode\": \"cors\",\"sec-fetch-site\": \"same-origin\",\"viewport-width\": \"",
			(T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((Size)(T6)((RemoteWebDriver)chrome).Manage().Window.Size).Width).ToString(),
			(T2)"\"},\"referrer\": \"",
			(T2)((RemoteWebDriver)chrome).Url,
			(T2)"?fref=profile_friend_list&hc_location=friends_tab\",\"referrerPolicy\": \"origin-when-cross-origin\",\"body\": \"uid=",
			uid,
			(T2)"&unref=bd_profile_button&floc=profile_button&nctr[_mod]=pagelet_timeline_profile_actions&__user=",
			(T2)((Dictionary<string, string>)val)["__user"],
			(T2)"&__a=",
			(T2)((Dictionary<string, string>)val)["__a"],
			(T2)"&__dyn=",
			(T2)((Dictionary<string, string>)val)["__dyn"],
			(T2)"&__csr=&__req=",
			(T2)((Dictionary<string, string>)val)["__req"],
			(T2)"&__beoa=",
			(T2)((Dictionary<string, string>)val)["__beoa"],
			(T2)"&__pc=PHASED%3ADEFAULT&dpr=",
			(T2)((Dictionary<string, string>)val)["dpr"],
			(T2)"&__ccg=GOOD&__rev=",
			(T2)((Dictionary<string, string>)val)["__rev"],
			(T2)"&__s=",
			(T2)((Dictionary<string, string>)val)["__s"],
			(T2)"&__hsi=",
			(T2)((Dictionary<string, string>)val)["__hsi"],
			(T2)"&__comet_req=",
			(T2)((Dictionary<string, string>)val)["__comet_req"],
			(T2)"&fb_dtsg=",
			(T2)((Dictionary<string, string>)val)["fb_dtsg"],
			(T2)"&jazoest=",
			(T2)((Dictionary<string, string>)val)["jazoest"],
			(T2)"&__spin_r=",
			(T2)((Dictionary<string, string>)val)["__spin_r"],
			(T2)"&__spin_b=",
			(T2)((Dictionary<string, string>)val)["__spin_b"],
			(T2)"&__spin_t=",
			(T2)((Dictionary<string, string>)val)["__spin_t"],
			(T2)"\",\"method\": \"POST\",\"mode\": \"cors\",\"credentials\": \"include\"});"
		});
		executeScript<T2, T7, T1, T3, T8>(script);
		Thread.Sleep(1000);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void requestCancelRequestAddFriendFetch<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 uid)
	{
		//IL_0122: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_017f: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("__user", "");
		((Dictionary<string, string>)val).Add("__a", "");
		((Dictionary<string, string>)val).Add("__dyn", "");
		((Dictionary<string, string>)val).Add("__req", "");
		((Dictionary<string, string>)val).Add("__beoa", "");
		((Dictionary<string, string>)val).Add("__ccg", "");
		((Dictionary<string, string>)val).Add("dpr", "");
		((Dictionary<string, string>)val).Add("__rev", "");
		((Dictionary<string, string>)val).Add("__s", "");
		((Dictionary<string, string>)val).Add("__hsi", "");
		((Dictionary<string, string>)val).Add("__comet_req", "");
		((Dictionary<string, string>)val).Add("fb_dtsg", "");
		((Dictionary<string, string>)val).Add("jazoest", "");
		((Dictionary<string, string>)val).Add("__spin_r", "");
		((Dictionary<string, string>)val).Add("__spin_t", "");
		((Dictionary<string, string>)val).Add("__spin_b", "");
		T1 val2 = (T1)0;
		while (true)
		{
			T3 val3 = (T3)frmMain.isRunning;
			if (val3 == null)
			{
				break;
			}
			val = GetFetchData<T2, T1, T3, T5, T0, T7, T8, char>(val);
			T3 val4 = (T3)0;
			T4 enumerator = (T4)((Dictionary<string, string>)val).GetEnumerator();
			try
			{
				while (((Dictionary<string, string>.Enumerator*)(&enumerator))->MoveNext())
				{
					T3 val5 = (T3)string.IsNullOrWhiteSpace(((KeyValuePair<string, string>)(T5)((Dictionary<string, string>.Enumerator*)(&enumerator))->Current).Value);
					if (val5 != null)
					{
						val4 = (T3)1;
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(Dictionary<string, string>.Enumerator*)(&enumerator))).Dispose();
			}
			val2 = (T1)(val2 + 1);
			T3 val6 = (T3)((nint)val2 >= 10);
			if (val6 != null)
			{
				break;
			}
			T3 val7 = (T3)(val4 == null);
			if (val7 != null)
			{
				break;
			}
			Thread.Sleep(2000);
		}
		T2 script = (T2)string.Concat((string[])(object)new T2[39]
		{
			(T2)"fetch(\"https://www.facebook.com/ajax/friends/requests/cancel.php\", {\"headers\": {\"accept\": \"*/*\",\"accept-language\": \"en-US,en;q=0.9\",\"content-type\": \"application/x-www-form-urlencoded\",\"sec-fetch-dest\": \"empty\",\"sec-fetch-mode\": \"cors\",\"sec-fetch-site\": \"same-origin\",\"viewport-width\": \"",
			(T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((Size)(T6)((RemoteWebDriver)chrome).Manage().Window.Size).Width).ToString(),
			(T2)"\"},\"referrer\": \"",
			(T2)((RemoteWebDriver)chrome).Url,
			(T2)"\",\"referrerPolicy\": \"origin-when-cross-origin\",\"body\": \"friend=",
			uid,
			(T2)"&cancel_ref=profile&floc=profile_button&__user=",
			(T2)((Dictionary<string, string>)val)["__user"],
			(T2)"&__a=",
			(T2)((Dictionary<string, string>)val)["__a"],
			(T2)"&__dyn=",
			(T2)((Dictionary<string, string>)val)["__dyn"],
			(T2)"&__csr=&__req=",
			(T2)((Dictionary<string, string>)val)["__req"],
			(T2)"&__beoa=",
			(T2)((Dictionary<string, string>)val)["__beoa"],
			(T2)"&__pc=PHASED%3ADEFAULT&dpr=",
			(T2)((Dictionary<string, string>)val)["dpr"],
			(T2)"&__ccg=",
			(T2)((Dictionary<string, string>)val)["__ccg"],
			(T2)"&__rev=",
			(T2)((Dictionary<string, string>)val)["__rev"],
			(T2)"&__s=",
			(T2)((Dictionary<string, string>)val)["__s"],
			(T2)"&__hsi=",
			(T2)((Dictionary<string, string>)val)["__hsi"],
			(T2)"&__comet_req=",
			(T2)((Dictionary<string, string>)val)["__comet_req"],
			(T2)"&fb_dtsg=",
			(T2)((Dictionary<string, string>)val)["fb_dtsg"],
			(T2)"&jazoest=",
			(T2)((Dictionary<string, string>)val)["jazoest"],
			(T2)"&__spin_r=",
			(T2)((Dictionary<string, string>)val)["__spin_r"],
			(T2)"&__spin_b=",
			(T2)((Dictionary<string, string>)val)["__spin_b"],
			(T2)"&__spin_t=",
			(T2)((Dictionary<string, string>)val)["__spin_t"],
			(T2)"\",\"method\": \"POST\",\"mode\": \"cors\",\"credentials\": \"include\"});"
		});
		executeScript<T2, T7, T1, T3, T8>(script);
		Thread.Sleep(1000);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void requestAddFriendFetch<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T2 uid)
	{
		//IL_0122: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_017f: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_01fb: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("__user", "");
		((Dictionary<string, string>)val).Add("__a", "");
		((Dictionary<string, string>)val).Add("__dyn", "");
		((Dictionary<string, string>)val).Add("__req", "");
		((Dictionary<string, string>)val).Add("__beoa", "");
		((Dictionary<string, string>)val).Add("dpr", "");
		((Dictionary<string, string>)val).Add("__rev", "");
		((Dictionary<string, string>)val).Add("__s", "");
		((Dictionary<string, string>)val).Add("__hsi", "");
		((Dictionary<string, string>)val).Add("fb_dtsg", "");
		((Dictionary<string, string>)val).Add("jazoest", "");
		((Dictionary<string, string>)val).Add("__spin_r", "");
		((Dictionary<string, string>)val).Add("__spin_t", "");
		((Dictionary<string, string>)val).Add("__comet_req", "");
		((Dictionary<string, string>)val).Add("__ccg", "");
		((Dictionary<string, string>)val).Add("__spin_b", "");
		T1 val2 = (T1)0;
		while (true)
		{
			T3 val3 = (T3)frmMain.isRunning;
			if (val3 == null)
			{
				break;
			}
			val = GetFetchData<T2, T1, T3, T5, T0, T7, T8, char>(val);
			T3 val4 = (T3)0;
			T4 enumerator = (T4)((Dictionary<string, string>)val).GetEnumerator();
			try
			{
				while (((Dictionary<string, string>.Enumerator*)(&enumerator))->MoveNext())
				{
					T3 val5 = (T3)string.IsNullOrWhiteSpace(((KeyValuePair<string, string>)(T5)((Dictionary<string, string>.Enumerator*)(&enumerator))->Current).Value);
					if (val5 != null)
					{
						val4 = (T3)1;
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(Dictionary<string, string>.Enumerator*)(&enumerator))).Dispose();
			}
			val2 = (T1)(val2 + 1);
			T3 val6 = (T3)((nint)val2 >= 10);
			if (val6 != null)
			{
				break;
			}
			T3 val7 = (T3)(val4 == null);
			if (val7 != null)
			{
				break;
			}
			Thread.Sleep(2000);
		}
		T2 script = (T2)string.Concat((string[])(object)new T2[43]
		{
			(T2)"fetch(\"https://www.facebook.com/ajax/add_friend/action/?to_friend=",
			uid,
			(T2)"&action=add_friend&how_found=profile_button&ref_param=unknown&link_data[gt][type]=xtracking&link_data[gt][xt]=48.%7B%22event%22%3A%22add_friend%22%2C%22intent_status%22%3Anull%2C%22intent_type%22%3Anull%2C%22profile_id%22%3A",
			uid,
			(T2)"%2C%22ref%22%3A1%7D&link_data[gt][profile_owner]=",
			uid,
			(T2)"&link_data[gt][ref]=timeline%3Atimeline&logging_location=&floc=profile_button&frefs[0]=unknown\", {\"headers\": {\"accept\": \"*/*\",\"accept-language\": \"q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5\",\"content-type\": \"application/x-www-form-urlencoded\",\"sec-fetch-dest\": \"empty\",\"sec-fetch-mode\": \"cors\",\"sec-fetch-site\": \"same-origin\",\"viewport-width\": \"",
			(T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((Size)(T6)((RemoteWebDriver)chrome).Manage().Window.Size).Width).ToString(),
			(T2)"\"},\"referrer\": \"",
			(T2)((RemoteWebDriver)chrome).Url,
			(T2)"\",\"referrerPolicy\": \"origin-when-cross-origin\",\"body\": \"__user=",
			(T2)((Dictionary<string, string>)val)["__user"],
			(T2)"&__a=",
			(T2)((Dictionary<string, string>)val)["__a"],
			(T2)"&__dyn=",
			(T2)((Dictionary<string, string>)val)["__dyn"],
			(T2)"&__csr=&__req=",
			(T2)((Dictionary<string, string>)val)["__req"],
			(T2)"&__beoa=",
			(T2)((Dictionary<string, string>)val)["__beoa"],
			(T2)"&__pc=PHASED%3ADEFAULT&dpr=",
			(T2)((Dictionary<string, string>)val)["dpr"],
			(T2)"&__ccg=",
			(T2)((Dictionary<string, string>)val)["__ccg"],
			(T2)"&__rev=",
			(T2)((Dictionary<string, string>)val)["__rev"],
			(T2)"&__s=",
			(T2)((Dictionary<string, string>)val)["__s"],
			(T2)"&__hsi=",
			(T2)((Dictionary<string, string>)val)["__hsi"],
			(T2)"&__comet_req=",
			(T2)((Dictionary<string, string>)val)["__comet_req"],
			(T2)"&fb_dtsg=",
			(T2)((Dictionary<string, string>)val)["fb_dtsg"],
			(T2)"&jazoest=",
			(T2)((Dictionary<string, string>)val)["jazoest"],
			(T2)"&__spin_r=",
			(T2)((Dictionary<string, string>)val)["__spin_r"],
			(T2)"&__spin_b=",
			(T2)((Dictionary<string, string>)val)["__spin_b"],
			(T2)"&__spin_t=",
			(T2)((Dictionary<string, string>)val)["__spin_t"],
			(T2)"\",\"method\": \"POST\",\"mode\": \"cors\",\"credentials\": \"include\"});"
		});
		executeScript<T2, T7, T1, T3, T8>(script);
		Thread.Sleep(1000);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Accept_Friend<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0067: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected I4, but got Unknown
		//IL_0224: Expected I4, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_024f: Expected O, but got I4
		//IL_0278: Expected O, but got I4
		//IL_02b5: Expected O, but got I4
		//IL_02cb: Expected O, but got I4
		//IL_0305: Expected O, but got I4
		//IL_031f: Expected O, but got I4
		//IL_0329: Expected I4, but got O
		//IL_033d: Expected O, but got I4
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected I4, but got Unknown
		//IL_0357: Expected I4, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Expected O, but got Unknown
		//IL_0369: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			goUrl<T2, T0, T3, T5, T7, T1>((T1)ResouceControl.getResouce("RESOUCE_ADD_FRIEND_SUGGESTED_BY_FACEBOOK"));
			flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Gender_F_or_M").ToString();
			flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Location").ToString();
			T2 val2 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Quantity").ToString());
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Age_From").ToString());
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Age_To").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random").ToString());
			T2 val4 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_From").ToString());
			T2 val5 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_To").ToString());
			T3 val6 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("fb_content"));
			T0 val7 = (T0)(((ReadOnlyCollection<IWebElement>)val6).Count > 0);
			if (val7 == null)
			{
				return;
			}
			focusElement<IJavaScriptExecutor, T7, T5, T2, object>(((IEnumerable<T5>)val6).First(), (T2)1000);
			T0 val8 = val3;
			if (val8 == null)
			{
				T3 val9 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("ruResponseButtons"));
				T2 val10 = (T2)0;
				T6 enumerator = (T6)((ReadOnlyCollection<IWebElement>)val9).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						T5 current = (T5)((IEnumerator<IWebElement>)enumerator).Current;
						T3 val11 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("layerConfirm"));
						T0 val12 = (T0)(((ReadOnlyCollection<IWebElement>)val11).Count > 0);
						if (val12 != null)
						{
							T4 val13 = (T4)((IEnumerable<T5>)val11).Where((Func<T5, bool>)(object)(Func<IWebElement, bool>)((T5 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
							T0 val14 = (T0)(((List<IWebElement>)val13).Count > 0);
							if (val14 != null)
							{
								focusElement<IJavaScriptExecutor, T7, T5, T2, object>(((IEnumerable<T5>)val13).First(), (T2)300);
								((IWebElement)((IEnumerable<T5>)val13).First()).Click();
								Thread.Sleep(1000);
							}
						}
						T0 val15 = (T0)(val10 >= val2);
						if (val15 == null)
						{
							T5 parent = GetParent(current);
							focusElement<IJavaScriptExecutor, T7, T5, T2, object>(parent, (T2)500);
							Thread.Sleep(rnd.Next(val4 * 1000, val5 * 1000));
							val10 = (T2)(val10 + 1);
							continue;
						}
						break;
					}
					return;
				}
				finally
				{
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
			}
			T2 val16 = (T2)0;
			while (true)
			{
				T0 val17 = (T0)(val16 < val2);
				if (val17 == null)
				{
					break;
				}
				T3 val18 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("layerConfirm"));
				T0 val19 = (T0)(((ReadOnlyCollection<IWebElement>)val18).Count > 0);
				if (val19 != null)
				{
					T4 val20 = (T4)((IEnumerable<T5>)val18).Where((Func<T5, bool>)(object)(Func<IWebElement, bool>)((T5 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
					T0 val21 = (T0)(((List<IWebElement>)val20).Count > 0);
					if (val21 != null)
					{
						focusElement<IJavaScriptExecutor, T7, T5, T2, object>(((IEnumerable<T5>)val20).First(), (T2)300);
						((IWebElement)((IEnumerable<T5>)val20).First()).Click();
						Thread.Sleep(1000);
					}
				}
				T3 val22 = (T3)((RemoteWebDriver)chrome).FindElements(By.ClassName("ruResponseButtons"));
				T0 val23 = (T0)(((ReadOnlyCollection<IWebElement>)val22).Count > 0);
				if (val23 != null)
				{
					T2 val24 = (T2)rnd.Next(0, ((ReadOnlyCollection<IWebElement>)val22).Count - 1);
					T5 parent2 = GetParent((T5)((ReadOnlyCollection<IWebElement>)val22)[(int)val24]);
					focusElement<IJavaScriptExecutor, T7, T5, T2, object>(parent2, (T2)500);
					Thread.Sleep(rnd.Next(val4 * 1000, val5 * 1000));
				}
				val16 = (T2)(val16 + 1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Live_Stream<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_0219: Expected O, but got I4
		//IL_0256: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_0281: Expected O, but got I4
		T2 val = (T2)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		T0 val2 = (T0)Activator.CreateInstance(typeof(T0));
		object obj = Activator.CreateInstance(typeof(T1));
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		((List<bool>)obj).Add(item: true);
		((List<bool>)obj).Add(item: false);
		T1 val3 = (T1)obj;
		while (true)
		{
			T2 val4 = (T2)frmMain.isRunning;
			if (val4 == null)
			{
				break;
			}
			try
			{
				T3 enumerator = (T3)frmSedding.listLiveStreamSedding.GetEnumerator();
				try
				{
					while (((List<LiveStreamSedding>.Enumerator*)(&enumerator))->MoveNext())
					{
						LiveStreamSedding liveAction = ((List<LiveStreamSedding>.Enumerator*)(&enumerator))->Current;
						T2 val5 = (T2)(((IEnumerable<LiveStreamSedding>)val2).Where((Func<LiveStreamSedding, bool>)((LiveStreamSedding a) => (T2)a.Id.Equals(liveAction.Id))).Count() <= 0);
						if (val5 == null)
						{
							continue;
						}
						try
						{
							((List<LiveStreamSedding>)val2).Add(new LiveStreamSedding
							{
								Id = liveAction.Id,
								Key = liveAction.Key,
								Value = liveAction.Value,
								isRandom = liveAction.isRandom
							});
							T2 val6 = (T2)(liveAction.isRandom && !((List<bool>)val3)[rnd.Next(0, ((List<bool>)val3).Count - 1)]);
							if (val6 == null)
							{
								T2 val7 = (T2)(liveAction.Key == frmSedding.KEY_LIVE_STREAM.GO_LINK);
								if (val7 != null)
								{
									goUrl<int, T2, T4, T5, T7, T6>((T6)liveAction.Value.ToString());
									continue;
								}
								T2 val8 = (T2)(liveAction.Key == frmSedding.KEY_LIVE_STREAM.LIKE);
								if (val8 != null)
								{
									T4 val9 = (T4)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@aria-label='Like']"));
									T2 val10 = (T2)(val9 != null && ((ReadOnlyCollection<IWebElement>)val9).Count > 0 && ((IWebElement)((IEnumerable<T5>)val9).First()).Displayed);
									if (val10 != null)
									{
										((IWebElement)((IEnumerable<T5>)val9).First()).Click();
										Thread.Sleep(2000);
									}
									clickFullLiveStream<T2, T4, T5, T7>();
									continue;
								}
								T2 val11 = (T2)(liveAction.Key == frmSedding.KEY_LIVE_STREAM.SEDDING);
								if (val11 == null)
								{
									continue;
								}
								clickFullLiveStream<T2, T4, T5, T7>();
								T5 val12 = (T5)null;
								while (true)
								{
									T2 val13 = (T2)frmMain.isRunning;
									if (val13 == null)
									{
										break;
									}
									T4 val14 = (T4)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@data-outline-editor='true']"));
									T2 val15 = (T2)(val14 != null && ((ReadOnlyCollection<IWebElement>)val14).Count > 0);
									if (val15 == null)
									{
										Thread.Sleep(2000);
										continue;
									}
									val12 = ((IEnumerable<T5>)val14).First();
									break;
								}
								T2 val16 = (T2)(val12 != null);
								if (val16 != null)
								{
									((IWebElement)val12).Clear();
									T6 val17 = frmMain.Spin_String<T6, Match, T2, char>((T6)liveAction.Value.ToString());
									((IWebElement)val12).SendKeys((string)val17);
									Thread.Sleep(1500);
									((IWebElement)val12).SendKeys(Keys.Enter);
								}
								continue;
							}
							Console.WriteLine("Not working.");
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<LiveStreamSedding>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.Message);
			}
			Thread.Sleep(frmMain.setting.numDelayLiveStream * 1000);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clickFullLiveStream<T0, T1, T2, T3>()
	{
		//IL_0018: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		try
		{
			T0 val = (T0)((RemoteWebDriver)chrome).Url.Contains("watch_permalink");
			if (val != null)
			{
				T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("video"));
				T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
				if (val3 != null)
				{
					T2 parent = GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(((IEnumerable<T2>)val2).First())))))))))));
					((IWebElement)parent).Click();
					Thread.Sleep(3000);
					((IWebElement)parent).Click();
					Thread.Sleep(3000);
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void checkIsSpam<T0, T1, T2, T3, T4>()
	{
		//IL_0053: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		try
		{
			T0 source = (T0)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@role='dialog']"));
			T1 val = (T1)((IEnumerable<T4>)source).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)((T4 a) => (T2)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
			T2 val2 = (T2)(val != null && ((List<IWebElement>)val).Count > 0);
			if (val2 != null)
			{
				T0 val3 = (T0)((ISearchContext)((IEnumerable<T4>)val).First()).FindElements(By.TagName("i"));
				T2 val4 = (T2)(val3 != null && ((ReadOnlyCollection<IWebElement>)val3).Count > 0);
				if (val4 != null)
				{
					((IWebElement)((IEnumerable<T4>)val3).First()).Click();
					Thread.Sleep(1000);
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Rời_khỏi_nhóm<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01a6: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Rời_khỏi_toàn_bộ_nhóm").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Tick").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"UnTick").ToString());
			T1 groupUId = (T1)frmMain.listFBEntity[indexEntity].GroupUId;
			T1 path = (T1)$"GroupFB\\{groupUId}.json";
			T0 val5 = (T0)File.Exists((string)path);
			if (val5 == null)
			{
				return;
			}
			T2 val6 = (T2)Activator.CreateInstance(typeof(T2));
			val6 = JsonConvert.DeserializeObject<T2>(File.ReadAllText((string)path));
			T2 val7 = (T2)Activator.CreateInstance(typeof(T2));
			T0 val8 = val2;
			if (val8 == null)
			{
				T0 val9 = val3;
				if (val9 != null)
				{
					val7 = (T2)((IEnumerable<GroupFBEntity>)val6).Where((Func<GroupFBEntity, bool>)((GroupFBEntity a) => (T0)a.Select)).ToList();
				}
				else
				{
					T0 val10 = val4;
					if (val10 != null)
					{
						val7 = (T2)((IEnumerable<GroupFBEntity>)val6).Where((Func<GroupFBEntity, bool>)((GroupFBEntity a) => (T0)(!a.Select))).ToList();
					}
				}
			}
			else
			{
				val7 = val6;
			}
			T1 resouce = (T1)ResouceControl.getResouce("Roi_khoi_nhom");
			T3 val11 = (T3)0;
			T4 enumerator = (T4)((List<GroupFBEntity>)val7).GetEnumerator();
			try
			{
				while (((List<GroupFBEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					GroupFBEntity current = ((List<GroupFBEntity>.Enumerator*)(&enumerator))->Current;
					try
					{
						T1 script = (T1)((string)resouce).Replace("1234567890", current.Group_Id);
						executeScript<T1, T6, T3, T0, T7>(script);
						val11 = (T3)(val11 + 1);
						setMessage((T1)$"Leave: {val11}", (T0)0);
					}
					catch
					{
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<GroupFBEntity>.Enumerator*)(&enumerator))).Dispose();
			}
			setMessage((T1)$"Leave: {val11}", (T0)0);
			T0 val12 = (T0)((nint)val11 > 0);
			if (val12 != null)
			{
				Cập_nhật_nhóm_mth<T0, T1, T2, T3, T5, T6, T7>();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tham_gia_nhóm<T0, T1, T2, T3, T4, T5, T6>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00a0: Expected I4, but got O
		//IL_00bc: Expected O, but got I4
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00dc: Expected O, but got I4
		//IL_00f4: Expected I4, but got O
		//IL_0127: Expected I4, but got O
		//IL_0143: Expected I4, but got O
		//IL_018b: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_01a4: Expected I4, but got O
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01de: Expected O, but got I4
		//IL_01f2: Expected I4, but got O
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected I4, but got Unknown
		//IL_021f: Expected I4, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0235: Expected O, but got I4
		//IL_027b: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)int.Parse(flow.getValue<T6, List<FBFlowField>, T0, T3>((T3)"Số_nhóm_tham_gia").ToString());
			T1 val3 = (T1)int.Parse(flow.getValue<T6, List<FBFlowField>, T0, T3>((T3)"Delay_From").ToString());
			T1 val4 = (T1)int.Parse(flow.getValue<T6, List<FBFlowField>, T0, T3>((T3)"Delay_To").ToString());
			T1 val5 = (T1)0;
			T1 val6 = (T1)0;
			T0 val15;
			do
			{
				T0 val7 = (T0)(frmMain.isRunning && val5 < val2);
				if (val7 == null)
				{
					break;
				}
				T2 val8 = (T2)Activator.CreateInstance(typeof(T2));
				T1 val9 = (T1)0;
				T1 val10 = (T1)0;
				while (true)
				{
					T0 val11 = (T0)((nint)val10 < frmMain.listGroupEntity.Count);
					if (val11 != null)
					{
						T0 val12 = (T0)frmMain.listGroupEntity[(int)val10].Status.Equals(frmListGroupToJoin.STATUS.Ready.ToString());
						if (val12 == null)
						{
							val10 = (T1)(val10 + 1);
							continue;
						}
						frmMain.listGroupEntity[(int)val10].Status = frmListGroupToJoin.STATUS.Processing.ToString();
						val9 = val10;
						break;
					}
					break;
				}
				((Dictionary<string, string>)val8).Add("8888888888", frmMain.listGroupEntity[(int)val9].GroupId);
				frmMain.listGroupEntity[(int)val9].UID = frmMain.listFBEntity[indexEntity].UID;
				T3 resouce = (T3)ResouceControl.getResouce("Fetch_join_group", (Dictionary<string, string>)val8);
				T3 val13 = executeScript<T3, T5, T1, T0, T6>(resouce);
				T0 val14 = (T0)((string)val13).Contains("group_referral_post_attachment");
				if (val14 != null)
				{
					val6 = (T1)0;
					frmMain.listGroupEntity[(int)val9].Status = frmListGroupToJoin.STATUS.Joined.ToString();
					val5 = (T1)(val5 + 1);
					setMessage((T3)$"Joined: {val5}/{val2}", (T0)0);
				}
				else
				{
					frmMain.listGroupEntity[(int)val9].Status = frmListGroupToJoin.STATUS.lỗi.ToString();
				}
				Thread.Sleep(rnd.Next(val3 * 1000, val4 * 1000));
				val6 = (T1)(val6 + 1);
				val15 = (T0)((nint)val6 >= 15);
			}
			while (val15 == null);
			frmMain.saveListGroupId();
			setMessage((T3)$"Joined: {val5}/{val2}", (T0)0);
			T0 val16 = (T0)((nint)val5 > 0);
			if (val16 != null)
			{
				Cập_nhật_nhóm_mth<T0, T3, List<GroupFBEntity>, T1, T4, T5, T6>();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tương_tác_marketplace<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0160: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_01a3: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_01e1: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_022b: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_027b: Expected O, but got I4
		//IL_02c8: Expected O, but got I4
		//IL_02dd: Expected O, but got I4
		//IL_02f3: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_030a: Expected O, but got I4
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected I4, but got Unknown
		//IL_038a: Expected I4, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_039d: Expected O, but got I4
		//IL_03c3: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 url = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link").ToString();
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Next_ảnh").ToString());
			string strComment = flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Message").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(strComment))).First();
			T2 val3 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Số_Message").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random").ToString());
			T2 val5 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_From").ToString());
			T2 val6 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_To").ToString());
			goUrl<T2, T0, T4, T3, T5, T1>(url);
			T0 val7 = (T0)1;
			T2 val8 = (T2)0;
			T3 val9 = (T3)null;
			while (true)
			{
				T0 val10 = (T0)(frmMain.isRunning && (nint)val8 < 10);
				if (val10 == null)
				{
					break;
				}
				T4 val11 = (T4)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@data-pagelet='MainFeed']"));
				T0 val12 = (T0)(val11 != null && ((ReadOnlyCollection<IWebElement>)val11).Count > 0);
				if (val12 == null)
				{
					val8 = (T2)(val8 + 1);
					Thread.Sleep(2000);
					continue;
				}
				val9 = ((IEnumerable<T3>)val11).First();
				break;
			}
			T0 val13 = (T0)(val9 != null && frmMain.isRunning);
			if (val13 != null)
			{
				T0 val14 = val2;
				if (val14 != null)
				{
					val7 = (T0)1;
					T0 val15 = (T0)(val4 != null && !listRandomBool[rnd.Next(0, listRandomBool.Count - 1)]);
					if (val15 != null)
					{
						val7 = (T0)0;
					}
					T0 val16 = val7;
					if (val16 != null)
					{
						try
						{
							T4 val17 = (T4)((RemoteWebDriver)chrome).FindElements(By.XPath("//*[@id='mount_0_0_nH']/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[2]/div/div/div/div/div/div[2]/div/div[1]/div/div[4]/div[2]/div/div"));
							T0 val18 = (T0)(val17 != null && ((ReadOnlyCollection<IWebElement>)val17).Count > 0);
							if (val18 != null)
							{
								T2 val19 = (T2)rnd.Next(3, 5);
								T2 val20 = (T2)0;
								while (true)
								{
									T0 val21 = (T0)(val20 < val19);
									if (val21 != null)
									{
										((IWebElement)((IEnumerable<T3>)val17).First()).Click();
										Thread.Sleep(rnd.Next(150, 500));
										val20 = (T2)(val20 + 1);
										continue;
									}
									break;
								}
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
				T0 val22 = (T0)((nint)val3 > 0);
				if (val22 == null)
				{
					return;
				}
				try
				{
					T4 val23 = (T4)((RemoteWebDriver)chrome).FindElements(By.XPath("//*[@id='mount_0_0_nH']/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[2]/div/div/div/div/div/div[2]/div/div[2]/div/div[2]/div/div/div[3]/div/span/div/span/div/div/div[1]/div/span/span"));
					T0 val24 = (T0)(val23 != null && ((ReadOnlyCollection<IWebElement>)val23).Count > 0);
					if (val24 == null)
					{
						return;
					}
					((IWebElement)((IEnumerable<T3>)val23).First()).Click();
					Thread.Sleep(150);
					T3 val25 = (T3)null;
					while (true)
					{
						T0 val26 = (T0)frmMain.isRunning;
						if (val26 == null)
						{
							break;
						}
						T4 val27 = (T4)((RemoteWebDriver)chrome).FindElements(By.ClassName("notranslate"));
						T0 val28 = (T0)(val27 != null && ((ReadOnlyCollection<IWebElement>)val27).Count > 0);
						if (val28 == null)
						{
							Thread.Sleep(1500);
							continue;
						}
						val25 = ((IEnumerable<T3>)val27).First();
						break;
					}
					T0 val29 = (T0)(val25 != null);
					if (val29 == null)
					{
						return;
					}
					focusElement<IJavaScriptExecutor, T5, T3, T2, object>(val25, (T2)150);
					T2 val30 = (T2)0;
					while (true)
					{
						T0 val31 = (T0)(val30 < val3);
						if (val31 != null)
						{
							((IWebElement)val25).Click();
							T1 comment = (T1)categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)].Comment;
							comment = frmMain.Spin_String<T1, Match, T0, char>(comment);
							((IWebElement)val25).SendKeys((string)comment);
							Thread.Sleep(300);
							((IWebElement)val25).SendKeys(Keys.Enter);
							Thread.Sleep(rnd.Next(val5 * 1000, val6 * 1000));
							val30 = (T2)(val30 + 1);
							continue;
						}
						break;
					}
					return;
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.Message);
					return;
				}
			}
			setMessage((T1)"Không truy cập được Marketplace", (T0)0);
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tương_tác_dạo<T0, T1, T2, T3, T4, T5, T6, T7, T8>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_0133: Expected I4, but got O
		//IL_0133: Expected I4, but got O
		//IL_0135: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_017d: Expected O, but got I4
		//IL_01ba: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_022b: Expected O, but got I4
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected I4, but got Unknown
		//IL_024c: Expected I4, but got Unknown
		//IL_0256: Expected O, but got I4
		//IL_0285: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		//IL_02bd: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0321: Expected O, but got I4
		//IL_032f: Expected O, but got I4
		//IL_0337: Expected O, but got I4
		//IL_0392: Expected O, but got I4
		//IL_03ae: Expected O, but got I4
		//IL_0430: Expected O, but got I4
		//IL_0437: Expected O, but got I4
		//IL_0463: Expected O, but got I4
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_0488: Expected O, but got I4
		//IL_04d7: Expected O, but got I4
		//IL_0501: Expected O, but got I4
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected I4, but got Unknown
		//IL_0598: Expected I4, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Expected I4, but got Unknown
		//IL_05da: Expected I4, but got Unknown
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Expected O, but got Unknown
		//IL_060f: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_063c: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Expected O, but got Unknown
		//IL_064a: Expected O, but got I4
		//IL_0654: Expected O, but got I4
		//IL_0692: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 url = (T1)flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Link").ToString();
			T2 val2 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random_bài_viết_từ").ToString());
			T2 val3 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random_bài_viết_đến").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Like_bài_viết").ToString());
			string strComment = flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Comment").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(strComment))).First();
			T2 val5 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Số_comment").ToString());
			T0 val6 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Random").ToString());
			T2 val7 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_From").ToString());
			T2 val8 = (T2)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Delay_To").ToString());
			goUrl<T2, T0, T4, T6, T7, T1>(url);
			T3 val9 = (T3)Activator.CreateInstance(typeof(T3));
			T2 val10 = (T2)rnd.Next((int)val2, (int)val3);
			T2 val11 = (T2)0;
			T0 val12 = (T0)1;
			T2 val13 = (T2)0;
			while (true)
			{
				T0 val14 = (T0)(frmMain.isRunning && val11 <= val10);
				if (val14 == null)
				{
					break;
				}
				T4 val15 = (T4)((RemoteWebDriver)chrome).FindElements(By.ClassName("notranslate"));
				T0 val16 = (T0)(val15 != null && ((ReadOnlyCollection<IWebElement>)val15).Count > 0);
				if (val16 != null)
				{
					try
					{
						T5 enumerator = (T5)((ReadOnlyCollection<IWebElement>)val15).GetEnumerator();
						try
						{
							while (((IEnumerator)enumerator).MoveNext())
							{
								T6 current = (T6)((IEnumerator<IWebElement>)enumerator).Current;
								T0 val17 = (T0)(!((List<IWebElement>)val9).Contains((IWebElement)current) && ((IWebElement)current).Displayed && ((IWebElement)current).Enabled);
								if (val17 == null)
								{
									continue;
								}
								val13 = (T2)0;
								checkIsSpam<T4, T3, T0, T7, T6>();
								((List<IWebElement>)val9).Add((IWebElement)current);
								T6 parent = GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(current))))))))));
								focusElement<IJavaScriptExecutor, T7, T6, T2, object>(parent, (T2)500);
								((IWebElement)current).Click();
								Thread.Sleep(rnd.Next(val7 * 1000, val8 * 1000) / 2);
								val12 = (T0)1;
								T0 val18 = (T0)(val6 != null && !listRandomBool[rnd.Next(0, listRandomBool.Count - 1)]);
								if (val18 != null)
								{
									val12 = (T0)0;
								}
								T0 val19 = (T0)((object)val12 & (object)val4);
								if (val19 != null)
								{
									T4 source = (T4)((ISearchContext)parent).FindElements(By.TagName("i"));
									focusElement<IJavaScriptExecutor, T7, T6, T2, object>(((IEnumerable<T6>)source).First(), (T2)500);
									((IWebElement)((IEnumerable<T6>)source).First()).Click();
									Thread.Sleep(rnd.Next(1000, 5000));
								}
								checkIsSpam<T4, T3, T0, T7, T6>();
								val12 = (T0)1;
								T0 val20 = (T0)(val6 != null && !listRandomBool[rnd.Next(0, listRandomBool.Count - 1)]);
								if (val20 != null)
								{
									val12 = (T0)0;
								}
								T0 val21 = val12;
								if (val21 != null)
								{
									T2 val22 = (T2)0;
									while (true)
									{
										T0 val23 = (T0)(val22 < val5);
										if (val23 == null)
										{
											break;
										}
										CommentStroll commentStroll = categoryComment.listCommentStroll[rnd.Next(0, categoryComment.listCommentStroll.Count - 1)];
										T1 comment = (T1)commentStroll.Comment;
										comment = frmMain.Spin_String<T1, Match, T0, T8>(comment);
										T1 media = (T1)commentStroll.Media;
										T0 val24 = (T0)(!string.IsNullOrWhiteSpace((string)media));
										if (val24 != null)
										{
											T0 val25 = (T0)(!string.IsNullOrWhiteSpace((string)media) && Directory.Exists((string)media));
											if (val25 != null)
											{
												try
												{
													T4 source2 = (T4)((ISearchContext)parent).FindElements(By.TagName("input"));
													T3 source3 = (T3)((IEnumerable<T6>)source2).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T0)(((IWebElement)a).GetAttribute("type") != null && ((IWebElement)a).GetAttribute("type").Equals("file")))).ToList();
													T1[] files = (T1[])(object)Directory.GetFiles((string)media);
													((IWebElement)((IEnumerable<T6>)source3).First()).SendKeys((string)((object[])(object)files)[rnd.Next(0, files.Count() - 1)]);
													Thread.Sleep(1000);
													T2 val26 = (T2)0;
													while (true)
													{
														T0 val27 = (T0)frmMain.isRunning;
														if (val27 == null)
														{
															break;
														}
														try
														{
															T4 val28 = (T4)((ISearchContext)parent).FindElements(By.ClassName("scaledImageFitWidth"));
															T0 val29 = (T0)(val28 != null && ((ReadOnlyCollection<IWebElement>)val28).Count > 0);
															if (val29 != null)
															{
																break;
															}
														}
														catch
														{
														}
														val26 = (T2)(val26 + 1);
														T0 val30 = (T0)((nint)val26 > 20);
														if (val30 == null)
														{
															Thread.Sleep(1000);
															continue;
														}
														break;
													}
												}
												catch (Exception ex)
												{
													Console.WriteLine(ex.Message);
												}
											}
										}
										try
										{
											comment = frmMain.Spin_String<T1, Match, T0, T8>(comment);
											comment = (T1)((string)comment).Replace("\r\n", "|");
											T0 val31 = (T0)((string)comment).Contains("|");
											if (val31 == null)
											{
												((IWebElement)current).SendKeys((string)comment);
											}
											else
											{
												T1[] array = (T1[])(object)((string)comment).Split((char[])(object)new T8[1] { (T8)124 });
												T1[] array2 = array;
												T2 val32 = (T2)0;
												while ((nint)val32 < array2.Length)
												{
													T1 val33 = (T1)((object[])(object)array2)[(object)val32];
													((IWebElement)current).SendKeys((string)val33);
													((IWebElement)current).SendKeys(Keys.Alt + Keys.Enter);
													val32 = (T2)(val32 + 1);
												}
												((IWebElement)current).SendKeys(Keys.Backspace);
											}
											((IWebElement)current).SendKeys(Keys.Enter);
											Thread.Sleep(rnd.Next(1000, 5000));
										}
										catch
										{
										}
										val22 = (T2)(val22 + 1);
									}
								}
								Thread.Sleep(rnd.Next(val7 * 1000, val8 * 1000) / 2);
								break;
							}
						}
						finally
						{
							if (enumerator != null)
							{
								((IDisposable)enumerator).Dispose();
							}
						}
					}
					catch (Exception ex2)
					{
						Console.WriteLine(ex2.Message);
						Thread.Sleep(rnd.Next(val7 * 1000, val8 * 1000));
					}
				}
				T4 source4 = (T4)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
				T2 val34 = (T2)0;
				while (true)
				{
					T0 val35 = (T0)((nint)val34 < rnd.Next(30, 120));
					if (val35 == null)
					{
						break;
					}
					((IWebElement)((IEnumerable<T6>)source4).First()).SendKeys(Keys.Down);
					val34 = (T2)(val34 + 1);
				}
				setMessage((T1)$"Cmm: {val11}/{val10}", (T0)0);
				val11 = (T2)(val11 + 1);
				val13 = (T2)(val13 + 1);
				T0 val36 = (T0)((nint)val13 >= 10);
				if (val36 != null)
				{
					val13 = (T2)0;
					((RemoteWebDriver)chrome).Navigate().Refresh();
				}
			}
			Console.WriteLine("aa");
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Post_bài_lên_tường<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		//IL_0119: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			string Bài_viết = flow.getValue<object, List<FBFlowField>, T0, string>("Bài_viết").ToString();
			((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(Bài_viết))).First();
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("Số_Bài_viết").ToString());
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("Delay_From").ToString());
			int.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("Delay_To").ToString());
			goUrl<T1, T0, T2, T3, T5, string>(ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
			Thread.Sleep(1500);
			T2 val2 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@style='border-radius:20px']"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 == null)
			{
				return;
			}
			try
			{
				focusElement<IJavaScriptExecutor, T5, T3, T1, object>(((IEnumerable<T3>)val2).First(), (T1)500);
				((IWebElement)((IEnumerable<T3>)val2).First()).Click();
				Thread.Sleep(1500);
				T3 val4 = (T3)null;
				while (true)
				{
					T0 val5 = (T0)frmMain.isRunning;
					if (val5 == null)
					{
						break;
					}
					try
					{
						T2 val6 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@role='dialog']"));
						T4 enumerator = (T4)((ReadOnlyCollection<IWebElement>)val6).GetEnumerator();
						try
						{
							while (((IEnumerator)enumerator).MoveNext())
							{
								T3 current = (T3)((IEnumerator<IWebElement>)enumerator).Current;
								T0 val7 = (T0)(((IWebElement)current).Displayed && ((IWebElement)current).Enabled);
								if (val7 != null)
								{
									val4 = current;
									break;
								}
							}
						}
						finally
						{
							if (enumerator != null)
							{
								((IDisposable)enumerator).Dispose();
							}
						}
						T0 val8 = (T0)(val4 != null);
						if (val8 == null)
						{
							goto IL_0196;
						}
					}
					catch
					{
						goto IL_0196;
					}
					break;
					IL_0196:
					Thread.Sleep(1500);
				}
				T0 val9 = (T0)(val4 != null);
				if (val9 == null)
				{
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Post_bài_group<T0, T1, T2>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			string Bài_viết = flow.getValue<object, List<FBFlowField>, T0, string>("Bài_viết").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(Bài_viết))).First();
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("Share_toàn_bộ_nhóm").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("Tick").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("UnTick").ToString());
			T1 giới_hạn_nhóm = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, string>("Giới_hạn_nhóm").ToString());
			T0 val5 = val2;
			if (val5 != null)
			{
				Post_Group<string, T0, List<GroupFBEntity>, T1, List<GroupFBEntity>.Enumerator, ReadOnlyCollection<IWebElement>, IWebElement, IEnumerator<IWebElement>, List<IWebElement>, T2, List<CommentStroll>>((T1)1, categoryComment.listCommentStroll, giới_hạn_nhóm);
				return;
			}
			T0 val6 = val3;
			if (val6 == null)
			{
				T0 val7 = val4;
				if (val7 != null)
				{
					Post_Group<string, T0, List<GroupFBEntity>, T1, List<GroupFBEntity>.Enumerator, ReadOnlyCollection<IWebElement>, IWebElement, IEnumerator<IWebElement>, List<IWebElement>, T2, List<CommentStroll>>((T1)3, categoryComment.listCommentStroll, giới_hạn_nhóm);
				}
			}
			else
			{
				Post_Group<string, T0, List<GroupFBEntity>, T1, List<GroupFBEntity>.Enumerator, ReadOnlyCollection<IWebElement>, IWebElement, IEnumerator<IWebElement>, List<IWebElement>, T2, List<CommentStroll>>((T1)2, categoryComment.listCommentStroll, giới_hạn_nhóm);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Post_Group<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 flag, T10 listCommentStroll, T3 Giới_hạn_nhóm)
	{
		//IL_0030: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_00e4: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_01c1: Expected I4, but got O
		//IL_01d1: Expected I4, but got O
		//IL_01e3: Expected O, but got I4
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01fa: Expected O, but got I4
		//IL_0209: Expected I4, but got O
		//IL_0212: Expected O, but got I4
		//IL_0226: Expected O, but got I4
		//IL_0241: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_02b3: Expected O, but got I4
		//IL_02d4: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0318: Expected O, but got I4
		//IL_0355: Expected O, but got I4
		//IL_0367: Expected O, but got I4
		//IL_03b6: Expected O, but got I4
		//IL_0413: Expected O, but got I4
		//IL_0420: Expected O, but got I4
		//IL_04e3: Expected O, but got I4
		//IL_04f1: Expected O, but got I4
		//IL_04fc: Expected O, but got I4
		//IL_053e: Expected O, but got I4
		//IL_0550: Expected O, but got I4
		//IL_0565: Expected O, but got I4
		//IL_0586: Expected O, but got I4
		//IL_05f6: Expected O, but got I4
		//IL_0629: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_0646: Expected O, but got I4
		//IL_0651: Expected O, but got I4
		//IL_065f: Expected O, but got I4
		//IL_06ba: Expected O, but got I4
		//IL_06c5: Expected O, but got I4
		T0 groupUId = (T0)frmMain.listFBEntity[indexEntity].GroupUId;
		T0 path = (T0)$"GroupFB\\{groupUId}.json";
		T1 val = (T1)File.Exists((string)path);
		if (val == null)
		{
			return;
		}
		T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
		val2 = JsonConvert.DeserializeObject<T2>(File.ReadAllText((string)path));
		T2 val3 = (T2)Activator.CreateInstance(typeof(T2));
		T1 val4 = (T1)((nint)flag == 1);
		if (val4 == null)
		{
			T1 val5 = (T1)((nint)flag == 2);
			if (val5 == null)
			{
				T1 val6 = (T1)((nint)flag == 3);
				if (val6 != null)
				{
					val3 = (T2)((IEnumerable<GroupFBEntity>)val2).Where((Func<GroupFBEntity, bool>)((GroupFBEntity a) => (T1)(!a.Select))).ToList();
				}
			}
			else
			{
				val3 = (T2)((IEnumerable<GroupFBEntity>)val2).Where((Func<GroupFBEntity, bool>)((GroupFBEntity a) => (T1)a.Select)).ToList();
			}
		}
		else
		{
			val3 = val2;
		}
		try
		{
			T3 val7 = (T3)0;
			T4 enumerator = (T4)((List<GroupFBEntity>)val3).GetEnumerator();
			try
			{
				while (((List<GroupFBEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					GroupFBEntity current = ((List<GroupFBEntity>.Enumerator*)(&enumerator))->Current;
					try
					{
						CommentStroll commentStroll = ((List<CommentStroll>)listCommentStroll)[rnd.Next(0, ((List<CommentStroll>)listCommentStroll).Count - 1)];
						T0 comment = (T0)commentStroll.Comment;
						comment = frmMain.Spin_String<T0, Match, T1, char>(comment);
						T0 media = (T0)commentStroll.Media;
						goUrl<T3, T1, T5, T6, T9, T0>((T0)(ResouceControl.getResouce("RESOUCE_HOME_PAGE") + "/" + current.Group_Id));
						Thread.Sleep(1500);
						T5 val8 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@data-pagelet='GroupInlineComposer']"));
						T1 val9 = (T1)(val8 != null && ((ReadOnlyCollection<IWebElement>)val8).Count > 0);
						if (val9 == null)
						{
							continue;
						}
						T5 val10 = (T5)((ISearchContext)((IEnumerable<T6>)val8).First()).FindElements(By.TagName("span"));
						T6 val11 = (T6)null;
						T3 val12 = (T3)0;
						while (true)
						{
							T1 val13 = (T1)((nint)val12 < ((ReadOnlyCollection<IWebElement>)val10).Count);
							if (val13 == null)
							{
								break;
							}
							T1 val14 = (T1)(((ReadOnlyCollection<IWebElement>)val10)[(int)val12].Displayed && !string.IsNullOrWhiteSpace(((ReadOnlyCollection<IWebElement>)val10)[(int)val12].Text));
							if (val14 == null)
							{
								val12 = (T3)(val12 + 1);
								continue;
							}
							val11 = (T6)((ReadOnlyCollection<IWebElement>)val10)[(int)val12];
							break;
						}
						T1 val15 = (T1)(val11 != null);
						if (val15 == null)
						{
							continue;
						}
						focusElement<IJavaScriptExecutor, T9, T6, T3, object>(val11, (T3)500);
						((IWebElement)val11).Click();
						Thread.Sleep(1500);
						T6 val16 = (T6)null;
						while (true)
						{
							T1 val17 = (T1)frmMain.isRunning;
							if (val17 == null)
							{
								break;
							}
							try
							{
								T5 val18 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@role='dialog']"));
								T7 enumerator2 = (T7)((ReadOnlyCollection<IWebElement>)val18).GetEnumerator();
								try
								{
									while (((IEnumerator)enumerator2).MoveNext())
									{
										T6 current2 = (T6)((IEnumerator<IWebElement>)enumerator2).Current;
										T1 val19 = (T1)(((IWebElement)current2).Displayed && ((IWebElement)current2).Enabled);
										if (val19 != null)
										{
											val16 = current2;
											break;
										}
									}
								}
								finally
								{
									if (enumerator2 != null)
									{
										((IDisposable)enumerator2).Dispose();
									}
								}
								T1 val20 = (T1)(val16 != null);
								if (val20 != null)
								{
									break;
								}
							}
							catch
							{
							}
							Thread.Sleep(1500);
						}
						T1 val21 = (T1)(val16 != null);
						if (val21 == null)
						{
							continue;
						}
						countError = 0;
						T6 val22 = (T6)null;
						while (true)
						{
							T1 val23 = (T1)frmMain.isRunning;
							if (val23 == null)
							{
								break;
							}
							try
							{
								T5 val24 = (T5)((ISearchContext)val16).FindElements(By.ClassName("notranslate"));
								T1 val25 = (T1)(val24 != null && ((ReadOnlyCollection<IWebElement>)val24).Count > 0);
								if (val25 != null)
								{
									val22 = ((IEnumerable<T6>)val24).First();
									break;
								}
							}
							catch
							{
							}
							countError++;
							T1 val26 = (T1)(countError >= 20);
							if (val26 != null)
							{
								break;
							}
							Thread.Sleep(1500);
						}
						T1 val27 = (T1)(val22 != null && frmMain.isRunning);
						if (val27 == null)
						{
							continue;
						}
						((IWebElement)val22).Click();
						T5 source = (T5)((ISearchContext)val22).FindElements(By.TagName("span"));
						((IWebElement)((IEnumerable<T6>)source).First()).SendKeys((string)comment);
						Thread.Sleep(300);
						T1 val28 = (T1)(!string.IsNullOrWhiteSpace((string)media) && Directory.Exists((string)media));
						if (val28 == null)
						{
							continue;
						}
						T5 source2 = (T5)((ISearchContext)val16).FindElements(By.TagName("input"));
						T8 source3 = (T8)((IEnumerable<T6>)source2).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T1)(((IWebElement)a).GetAttribute("type") != null && ((IWebElement)a).GetAttribute("type").Equals("file")))).ToList();
						T0[] array = (T0[])(object)Directory.GetFiles((string)media);
						T1 val29 = (T1)(commentStroll.numMedia > 0);
						if (val29 != null)
						{
							T1 val30 = (T1)commentStroll.randomMedia;
							if (val30 != null)
							{
								array = array.OrderBy((Func<T0, T3>)(object)(Func<string, int>)((T0 x) => (T3)rnd.Next())).ToArray();
							}
							array = array.Take(commentStroll.numMedia).ToArray();
						}
						((IWebElement)((IEnumerable<T6>)source3).First()).SendKeys(string.Join("\n", (string[])(object)array));
						Thread.Sleep(3000);
						T5 source4 = (T5)((ISearchContext)val16).FindElements(By.TagName("span"));
						T8 source5 = (T8)((IEnumerable<T6>)source4).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)((T6 a) => (T1)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
						((IWebElement)((IEnumerable<T6>)source5).Last()).Click();
						Thread.Sleep(1500);
						T1 val31 = (T1)0;
						countError = 0;
						while (true)
						{
							T1 val32 = (T1)frmMain.isRunning;
							if (val32 == null)
							{
								break;
							}
							try
							{
								val31 = (T1)0;
								T5 val33 = (T5)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@role='dialog']"));
								T7 enumerator3 = (T7)((ReadOnlyCollection<IWebElement>)val33).GetEnumerator();
								try
								{
									while (((IEnumerator)enumerator3).MoveNext())
									{
										T6 current3 = (T6)((IEnumerator<IWebElement>)enumerator3).Current;
										T1 val34 = (T1)(((IWebElement)current3).Displayed && ((IWebElement)current3).Enabled);
										if (val34 != null)
										{
											val31 = (T1)1;
											break;
										}
									}
								}
								finally
								{
									if (enumerator3 != null)
									{
										((IDisposable)enumerator3).Dispose();
									}
								}
								T1 val35 = (T1)(val31 == null);
								if (val35 != null)
								{
									break;
								}
								countError++;
								T1 val36 = (T1)(countError == 10);
								if (val36 != null)
								{
									try
									{
										source4 = (T5)((ISearchContext)val16).FindElements(By.TagName("span"));
										source5 = (T8)((IEnumerable<T6>)source4).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)((T6 a) => (T1)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
										((IWebElement)((IEnumerable<T6>)source5).Last()).Click();
										Thread.Sleep(1500);
									}
									catch
									{
									}
								}
								T1 val37 = (T1)(countError >= 20);
								if (val37 == null)
								{
									goto IL_0603;
								}
							}
							catch
							{
								goto IL_0603;
							}
							break;
							IL_0603:
							Thread.Sleep(1500);
						}
						current.Select = false;
						current.UpdateDate = DateTime.Now;
						val7 = (T3)(val7 + 1);
						setMessage((T0)$"Post: {val7}/{(T3)((List<GroupFBEntity>)val3).Count}", (T1)0);
						T1 val38 = (T1)((nint)Giới_hạn_nhóm > 0 && (object)val7 == (object)Giới_hạn_nhóm);
						if (val38 != null)
						{
							break;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<GroupFBEntity>.Enumerator*)(&enumerator))).Dispose();
			}
			File.WriteAllText((string)path, JsonConvert.SerializeObject((object)val3));
			setMessage((T0)$"Post: {val7}/{(T3)((List<GroupFBEntity>)val3).Count}", (T1)0);
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Like_share_bài_viết<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		//IL_00d9: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_01c2: Expected O, but got I4
		//IL_01e6: Expected O, but got I4
		//IL_01fa: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"ID_bài_viết").ToString();
			string strComment = flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Message").ToString();
			CategoryComment categoryComment = ((IEnumerable<CategoryComment>)frmMain.listCommentStroll).Where((Func<CategoryComment, bool>)((CategoryComment a) => (T0)a.Name.Equals(strComment))).First();
			T1 share_type = (T1)flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"22=Pro+5_11=Page").ToString();
			T0 val3 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Like").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Share_lên_tường").ToString());
			T0 val5 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Share_toàn_bộ_nhóm").ToString());
			T0 val6 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Tick").ToString());
			T0 val7 = (T0)bool.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"UnTick").ToString());
			T2 giới_hạn_nhóm = (T2)int.Parse(flow.getValue<T7, List<FBFlowField>, T0, T1>((T1)"Giới_hạn_nhóm").ToString());
			T0 val8 = val3;
			if (val8 != null)
			{
				try
				{
					T3 val9 = (T3)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@aria-label='Like']"));
					T0 val10 = (T0)(val9 != null && ((ReadOnlyCollection<IWebElement>)val9).Count > 0 && ((IWebElement)((IEnumerable<T5>)val9).First()).Displayed);
					if (val10 != null)
					{
						((IWebElement)((IEnumerable<T5>)val9).First()).Click();
						Thread.Sleep(2000);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			T0 val11 = val4;
			if (val11 != null)
			{
				try
				{
					executeScript<T1, T6, T2, T0, T7>(stringFethSharePostToWall(val2));
					Thread.Sleep(2000);
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.Message);
				}
			}
			T0 val12 = val5;
			if (val12 != null)
			{
				shareGroup<T1, T0, List<GroupFBEntity>, T2, List<GroupFBEntity>.Enumerator, Dictionary<string, string>, T4, List<CommentStroll>, T6, T7>((T2)1, categoryComment.listCommentStroll, share_type, val2, giới_hạn_nhóm);
				return;
			}
			T0 val13 = val6;
			if (val13 == null)
			{
				T0 val14 = val7;
				if (val14 != null)
				{
					shareGroup<T1, T0, List<GroupFBEntity>, T2, List<GroupFBEntity>.Enumerator, Dictionary<string, string>, T4, List<CommentStroll>, T6, T7>((T2)3, categoryComment.listCommentStroll, share_type, val2, giới_hạn_nhóm);
				}
			}
			else
			{
				shareGroup<T1, T0, List<GroupFBEntity>, T2, List<GroupFBEntity>.Enumerator, Dictionary<string, string>, T4, List<CommentStroll>, T6, T7>((T2)2, categoryComment.listCommentStroll, share_type, val2, giới_hạn_nhóm);
			}
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void shareGroup<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 flag, T7 listCommentStroll, T0 Share_type, T0 ID_bài_viết, T3 Giới_hạn_nhóm)
	{
		//IL_0021: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00d8: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_019f: Expected O, but got I4
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01d3: Expected O, but got I4
		//IL_01de: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_0205: Expected O, but got I4
		//IL_024c: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		T0 arg = executeScript<T0, T8, T3, T1, T9>((T0)"return require([\"CurrentUserInitialData\"]).USER_ID;");
		T0 path = (T0)$"GroupFB\\{arg}.json";
		T1 val = (T1)File.Exists((string)path);
		if (val == null)
		{
			return;
		}
		T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
		val2 = JsonConvert.DeserializeObject<T2>(File.ReadAllText((string)path));
		T2 val3 = (T2)Activator.CreateInstance(typeof(T2));
		T1 val4 = (T1)((nint)flag == 1);
		if (val4 != null)
		{
			val3 = val2;
		}
		else
		{
			T1 val5 = (T1)((nint)flag == 2);
			if (val5 != null)
			{
				val3 = (T2)((IEnumerable<GroupFBEntity>)val2).Where((Func<GroupFBEntity, bool>)((GroupFBEntity a) => (T1)a.Select)).ToList();
			}
			else
			{
				T1 val6 = (T1)((nint)flag == 3);
				if (val6 != null)
				{
					val3 = (T2)((IEnumerable<GroupFBEntity>)val2).Where((Func<GroupFBEntity, bool>)((GroupFBEntity a) => (T1)(!a.Select))).ToList();
				}
			}
		}
		try
		{
			T3 val7 = (T3)0;
			T3 val8 = (T3)0;
			T4 enumerator = (T4)((List<GroupFBEntity>)val3).GetEnumerator();
			try
			{
				while (((List<GroupFBEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					GroupFBEntity current = ((List<GroupFBEntity>.Enumerator*)(&enumerator))->Current;
					T0 comment = (T0)((List<CommentStroll>)listCommentStroll)[rnd.Next(0, ((List<CommentStroll>)listCommentStroll).Count - 1)].Comment;
					comment = frmMain.Spin_String<T0, Match, T1, char>(comment);
					T5 val9 = (T5)Activator.CreateInstance(typeof(T5));
					((Dictionary<string, string>)val9).Add("group_id", current.Group_Id);
					((Dictionary<string, string>)val9).Add("sharetype", (string)Share_type);
					((Dictionary<string, string>)val9).Add("post_id", (string)ID_bài_viết);
					((Dictionary<string, string>)val9).Add("strmessage", (string)comment);
					T0 resouce = (T0)ResouceControl.getResouce("Fetch_Share_Group_sharetype.postId.strmessage", (Dictionary<string, string>)val9);
					T0 val10 = executeScript<T0, T8, T3, T1, T9>(resouce);
					T1 val11 = (T1)((string)val10).Contains("api_error_code");
					if (val11 == null)
					{
						val7 = (T3)0;
						current.Select = false;
						current.UpdateDate = DateTime.Now;
						val8 = (T3)(val8 + 1);
						setMessage((T0)$"Share: {val8}/{(T3)((List<GroupFBEntity>)val3).Count}", (T1)0);
						T1 val12 = (T1)((nint)Giới_hạn_nhóm > 0 && (object)val8 == (object)Giới_hạn_nhóm);
						if (val12 != null)
						{
							break;
						}
					}
					else
					{
						val7 = (T3)(val7 + 1);
						T1 val13 = (T1)((nint)val7 >= 15);
						if (val13 != null)
						{
							break;
						}
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<GroupFBEntity>.Enumerator*)(&enumerator))).Dispose();
			}
			File.WriteAllText((string)path, JsonConvert.SerializeObject((object)val3));
			setMessage((T0)$"Share: {val8}/{(T3)((List<GroupFBEntity>)val3).Count}", (T1)0);
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 stringFethSharePostToWall<T0>(T0 IdPost)
	{
		return (T0)("var share_params=\"" + (string)IdPost + "\";var userId = require([\"CurrentUserInitialData\"]).USER_ID;var fb_dtsg = require(\"DTSGInitialData\").token || document.querySelector('[name=\"fb_dtsg\"]').value;var jazoest = require([\"SprinkleConfig\"]).jazoest;var __spin_r = require([\"SiteData\"]).__spin_r;var __spin_t = require([\"SiteData\"]).__spin_t;fetch(\"https://www.facebook.com/api/graphql/\", {\"headers\": {\"accept\": \"*/*\",\"accept-language\": \"en-US,en;q=0.9\",\"content-type\": \"application/x-www-form-urlencoded\",\"sec-ch-prefers-color-scheme\": \"light\",\"sec-ch-ua-mobile\": \"?0\",\"sec-fetch-dest\": \"empty\",\"sec-fetch-mode\": \"cors\",\"sec-fetch-site\": \"same-origin\",\"x-fb-friendly-name\": \"useCometFeedToFeedReshare_FeedToFeedMutation\",\"x-fb-lsd\": \"\"},\"referrer\": \"https://www.facebook.com\",\"referrerPolicy\": \"strict-origin-when-cross-origin\",\"body\": \"av=\"+userId+\"&__user=\"+userId+\"&__a=1&__dyn=7AzHxqU5a5Q1ryaxG4VuC0BVU98nwgU76byQdwSwAyU8EW0CEboG4E762S1DwUx60gu0luq7oc81xoszU887m2210x-8wgolzUO0n2US2G3i0Boy1PwBgK7o884y0EEuwiEjwPyoowYwlE-UqwsUkxe2GewGwkUtxGm2SUnxq5olwUwgojUlDw-wUws9ovUy2a2-0FE8FobodEGdwb622390&__csr=gplayl3Ylsn94myhkIqIO7EB9quQAGn9mjtjOHYD6b8yARV4APGR-WlaWDWKSFrngyi9Klp4bJyoOXgz-SgxVbDKQUCtcCGiCKujA-VJGnHKdAyUFGUBt6VUO-m8xijAG9xuEjVu-6ogxuEPCJ2UOEK8KWmEjh8-4EhBBU9842265d0TwyBAwUyUugyEgCx6iayoSvw_UfVFoWuiEmz8khoy3m7pEaUig9UuCzXxFeUoGqq2N1fUO8BwSzFEuxC49FEW4by8kx-15wtobod8KfxB0SKu10waK3GFoe8bUmzrCx22W1LCCw0P_UdpU1eqw3Jo4fU041202mmt04ww7Kxu0KE2Aw2jhlw2uk3z4ixy3dCy4bw8eWyo6y0su05mEkpHBw2b81tA0bPwhK0tG06go0B9yE4yz04pgV03koow&__req=o&__hs=18942.HYP%3Acomet_pkg.2.1.0.0.&dpr=1&__ccg=EXCELLENT&__rev=\"+__spin_r+\"&__s=&__hsi=&__comet_req=1&fb_dtsg=\"+fb_dtsg+\"&jazoest=\"+jazoest+\"&lsd=&__spin_r=\"+__spin_r+\"&__spin_b=trunk&__spin_t=\"+__spin_t+\"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useCometFeedToFeedReshare_FeedToFeedMutation&variables=%7B%22input%22%3A%7B%22attachments%22%3A%7B%22link%22%3A%7B%22share_scrape_data%22%3A%22%7B%5C%22share_type%5C%22%3A11%2C%5C%22share_params%5C%22%3A%5B\"+share_params+\"%5D%7D%22%7D%7D%2C%22audiences%22%3A%7B%22undirected%22%3A%7B%22privacy%22%3A%7B%22allow%22%3A%5B%5D%2C%22base_state%22%3A%22EVERYONE%22%2C%22deny%22%3A%5B%5D%2C%22tag_expansion_state%22%3A%22UNSPECIFIED%22%7D%7D%7D%2C%22is_tracking_encrypted%22%3Atrue%2C%22source%22%3A%22www%22%2C%22tracking%22%3A%5B%5D%2C%22actor_id%22%3A%22\"+userId+\"%22%2C%22client_mutation_id%22%3A%221%22%7D%2C%22renderLocation%22%3A%22homepage_stream%22%2C%22scale%22%3A1%2C%22privacySelectorRenderLocation%22%3A%22COMET_STREAM%22%2C%22useDefaultActor%22%3Afalse%2C%22displayCommentsContextEnableComment%22%3Anull%2C%22feedLocation%22%3A%22NEWSFEED%22%2C%22displayCommentsContextIsAdPreview%22%3Anull%2C%22displayCommentsContextIsAggregatedShare%22%3Anull%2C%22displayCommentsContextIsStorySet%22%3Anull%2C%22displayCommentsFeedbackContext%22%3Anull%2C%22feedbackSource%22%3A1%2C%22focusCommentID%22%3Anull%2C%22UFI2CommentsProvider_commentsKey%22%3A%22CometModernHomeFeedQuery%22%7D&server_timestamps=true&doc_id=4550778484958324\",\"method\": \"POST\",\"mode\": \"cors\",\"credentials\": \"include\"});");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add_Friend_Sugguested_By_Facebook<T0, T1, T2, T3, T4, T5>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00c0: Expected I4, but got O
		//IL_00d6: Expected I4, but got O
		//IL_00f1: Expected O, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0108: Expected O, but got I4
		//IL_0117: Expected I4, but got O
		//IL_0126: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01a6: Expected O, but got I4
		//IL_01be: Expected O, but got I4
		//IL_01ca: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_0216: Expected O, but got I4
		//IL_022d: Expected O, but got I4
		//IL_023c: Expected O, but got I4
		//IL_023f: Expected O, but got I4
		//IL_025f: Expected O, but got I4
		//IL_026a: Expected I4, but got O
		//IL_0279: Expected O, but got I4
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_0290: Expected O, but got I4
		//IL_029f: Expected I4, but got O
		//IL_02b1: Expected O, but got I4
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02da: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0301: Expected O, but got I4
		//IL_0321: Expected O, but got I4
		//IL_0324: Expected O, but got I4
		//IL_0336: Expected O, but got I4
		//IL_0341: Expected O, but got I4
		//IL_035c: Expected O, but got I4
		//IL_0367: Expected I4, but got O
		//IL_03ba: Expected O, but got I4
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03d1: Expected O, but got I4
		//IL_03dd: Expected O, but got I4
		//IL_03f9: Expected I4, but got O
		//IL_0403: Expected O, but got I4
		//IL_042f: Expected O, but got I4
		//IL_043c: Expected I4, but got O
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_0466: Expected O, but got I4
		//IL_0471: Expected I4, but got O
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_049b: Expected O, but got I4
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected I4, but got Unknown
		//IL_04b5: Expected I4, but got Unknown
		//IL_04c1: Expected O, but got I4
		//IL_04ee: Expected O, but got I4
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		//IL_050f: Expected O, but got I4
		//IL_0543: Expected O, but got I4
		//IL_0562: Expected O, but got I4
		//IL_058c: Expected O, but got I4
		//IL_0597: Expected I4, but got O
		//IL_05a7: Expected I4, but got O
		//IL_05b7: Expected I4, but got O
		//IL_05cc: Expected O, but got I4
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_05e0: Expected O, but got I4
		//IL_05f2: Expected I4, but got O
		//IL_0614: Expected O, but got I4
		//IL_063e: Expected O, but got I4
		//IL_0649: Expected I4, but got O
		//IL_0659: Expected I4, but got O
		//IL_0669: Expected I4, but got O
		//IL_067e: Expected O, but got I4
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_0692: Expected O, but got I4
		//IL_06a4: Expected I4, but got O
		//IL_06bd: Expected O, but got I4
		//IL_06d6: Expected O, but got I4
		//IL_06ee: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T5>((T5)"URL_redirection").ToString());
			T1 val3 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T5>((T5)"Quantity").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T5>((T5)"Random").ToString());
			T1 val5 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T5>((T5)"Delay_From").ToString());
			T1 val6 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T0, T5>((T5)"Delay_To").ToString());
			T0 val7 = val2;
			if (val7 == null)
			{
				T2 val8 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("a"));
				T1 val9 = (T1)0;
				while (true)
				{
					T0 val10 = (T0)((nint)val9 < ((ReadOnlyCollection<IWebElement>)val8).Count);
					if (val10 != null)
					{
						T0 val11 = (T0)(((ReadOnlyCollection<IWebElement>)val8)[(int)val9].GetAttribute("aria-label") != null && ((ReadOnlyCollection<IWebElement>)val8)[(int)val9].GetAttribute("aria-label").Equals("Facebook"));
						if (val11 == null)
						{
							val9 = (T1)(val9 + 1);
							continue;
						}
						T3 val12 = (T3)((ReadOnlyCollection<IWebElement>)val8)[(int)val9];
						focusElement<IJavaScriptExecutor, T4, T3, T1, object>(val12, (T1)300);
						((IWebElement)val12).Click();
						Thread.Sleep(2000);
						break;
					}
					break;
				}
				T0 val13 = (T0)1;
				T1 val14 = (T1)0;
				T2 val15 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[@href='/bookmarks/']"));
				T0 val16 = (T0)(((ReadOnlyCollection<IWebElement>)val15).Count > 0);
				if (val16 == null)
				{
					val14 = (T1)0;
					while (true)
					{
						T0 val17 = (T0)frmMain.isRunning;
						if (val17 != null)
						{
							T2 val18 = (T2)((RemoteWebDriver)chrome).FindElements(By.LinkText("See All"));
							T0 val19 = (T0)(((ReadOnlyCollection<IWebElement>)val18).Count > 0);
							if (val19 == null)
							{
								val14 = (T1)(val14 + 1);
								T0 val20 = (T0)((nint)val14 >= 10);
								if (val20 != null)
								{
									break;
								}
								Thread.Sleep(2000);
								continue;
							}
							val13 = (T0)0;
							focusElement<IJavaScriptExecutor, T4, T3, T1, object>(((IEnumerable<T3>)val18).First(), (T1)300);
							((IWebElement)((IEnumerable<T3>)val18).First()).Click();
							break;
						}
						break;
					}
				}
				else
				{
					T0 val21 = (T0)(!((IWebElement)((IEnumerable<T3>)val15).First()).Displayed);
					if (val21 != null)
					{
						goUrl<T1, T0, T2, T3, T4, T5>((T5)ResouceControl.getResouce("RESOUCE_ADD_FRIEND_SUGGESTED_BY_FACEBOOK"));
						val13 = (T0)0;
					}
					else
					{
						focusElement<IJavaScriptExecutor, T4, T3, T1, object>(((IEnumerable<T3>)val15).First(), (T1)300);
						((IWebElement)((IEnumerable<T3>)val15).First()).Click();
						val14 = (T1)0;
						T0 val22 = (T0)0;
						while (true)
						{
							T0 val23 = (T0)frmMain.isRunning;
							if (val23 == null)
							{
								break;
							}
							T2 val24 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[@href='https://www.facebook.com/friends/']"));
							T1 val25 = (T1)0;
							while (true)
							{
								T0 val26 = (T0)((nint)val25 < ((ReadOnlyCollection<IWebElement>)val24).Count);
								if (val26 != null)
								{
									T0 val27 = (T0)(!string.IsNullOrWhiteSpace(((ReadOnlyCollection<IWebElement>)val24)[(int)val25].Text));
									if (val27 == null)
									{
										val25 = (T1)(val25 + 1);
										continue;
									}
									((ReadOnlyCollection<IWebElement>)val24)[(int)val25].Click();
									Thread.Sleep(1500);
									val22 = (T0)1;
									break;
								}
								break;
							}
							val14 = (T1)(val14 + 1);
							T0 val28 = (T0)(((nint)val14 >= 10) | val22);
							if (val28 != null)
							{
								break;
							}
							Thread.Sleep(1500);
						}
						T0 val29 = val22;
						if (val29 != null)
						{
							val13 = (T0)0;
						}
					}
				}
				T0 val30 = val13;
				if (val30 != null)
				{
					setMessage((T5)"Not found see all friends", (T0)0);
					return;
				}
			}
			else
			{
				goUrl<T1, T0, T2, T3, T4, T5>((T5)ResouceControl.getResouce("RESOUCE_ADD_FRIEND_SUGGESTED_BY_FACEBOOK"));
			}
			countError = 0;
			T1 val31 = (T1)0;
			T0 val32 = (T0)0;
			listTempString.Clear();
			while (true)
			{
				T0 val33 = (T0)frmMain.isRunning;
				if (val33 == null)
				{
					break;
				}
				try
				{
					val32 = (T0)0;
					T2 val34 = (T2)((RemoteWebDriver)chrome).FindElements(By.XPath("//span[text()='Add Friend']"));
					T1 val35 = (T1)0;
					while (true)
					{
						T0 val36 = (T0)((nint)val35 < ((ReadOnlyCollection<IWebElement>)val34).Count);
						if (val36 == null)
						{
							break;
						}
						T3 e = (T3)((ReadOnlyCollection<IWebElement>)val34)[(int)val35];
						T3 parent = GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(GetParent(e)))))))));
						T0 val37 = (T0)(!listTempString.Contains(((IWebElement)parent).Text));
						if (val37 == null)
						{
							val35 = (T1)(val35 + 1);
							continue;
						}
						val32 = (T0)1;
						listTempString.Add(((IWebElement)parent).Text);
						focusElement<IJavaScriptExecutor, T4, T3, T1, object>((T3)((ReadOnlyCollection<IWebElement>)val34)[(int)val35], (T1)300);
						T0 val38 = val4;
						if (val38 != null)
						{
							T0 val39 = (T0)listRandomBool[rnd.Next(0, listRandomBool.Count - 1)];
							if (val39 != null)
							{
								((ReadOnlyCollection<IWebElement>)val34)[(int)val35].Click();
								val31 = (T1)(val31 + 1);
								setMessage((T5)$"Add friend: {val31}/{val3}", (T0)0);
							}
						}
						else
						{
							((ReadOnlyCollection<IWebElement>)val34)[(int)val35].Click();
							val31 = (T1)(val31 + 1);
							setMessage((T5)$"Add friend: {val31}/{val3}", (T0)0);
						}
						Thread.Sleep(rnd.Next(val5 * 1000, val6 * 1000));
						break;
					}
					T0 val40 = (T0)(val32 == null);
					if (val40 != null)
					{
						countError++;
						T2 source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
						T1 val41 = (T1)0;
						while (true)
						{
							T0 val42 = (T0)((nint)val41 < 10);
							if (val42 != null)
							{
								((IWebElement)((IEnumerable<T3>)source).First()).SendKeys(Keys.Down);
								val41 = (T1)(val41 + 1);
								continue;
							}
							break;
						}
					}
				}
				catch (Exception ex)
				{
					countError++;
					Console.WriteLine(ex.Message);
				}
				T0 val43 = (T0)(countError >= 20);
				if (val43 == null)
				{
					T0 val44 = (T0)(val31 >= val3);
					if (val44 != null)
					{
						break;
					}
					T0 val45 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("we can't process this request");
					if (val45 != null)
					{
						T2 val46 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
						T1 val47 = (T1)(((ReadOnlyCollection<IWebElement>)val46).Count - 1);
						while (true)
						{
							T0 val48 = (T0)((nint)val47 >= 0);
							if (val48 == null)
							{
								break;
							}
							T0 val49 = (T0)(((ReadOnlyCollection<IWebElement>)val46)[(int)val47].Enabled && ((ReadOnlyCollection<IWebElement>)val46)[(int)val47].Displayed && ((ReadOnlyCollection<IWebElement>)val46)[(int)val47].Text.Contains("OK"));
							if (val49 == null)
							{
								val47 = (T1)(val47 - 1);
								continue;
							}
							((ReadOnlyCollection<IWebElement>)val46)[(int)val47].Click();
							break;
						}
						continue;
					}
					T0 val50 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("is a list of friend suggestions based on mutual friends");
					if (val50 == null)
					{
						continue;
					}
					T2 val51 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
					T1 val52 = (T1)(((ReadOnlyCollection<IWebElement>)val51).Count - 1);
					while (true)
					{
						T0 val53 = (T0)((nint)val52 >= 0);
						if (val53 == null)
						{
							break;
						}
						T0 val54 = (T0)(((ReadOnlyCollection<IWebElement>)val51)[(int)val52].Enabled && ((ReadOnlyCollection<IWebElement>)val51)[(int)val52].Displayed && ((ReadOnlyCollection<IWebElement>)val51)[(int)val52].Text.Contains("OK"));
						if (val54 == null)
						{
							val52 = (T1)(val52 - 1);
							continue;
						}
						((ReadOnlyCollection<IWebElement>)val51)[(int)val52].Click();
						break;
					}
					continue;
				}
				setMessage((T5)$"Eror: {(T1)countError}: Add friend: {val31}/{val3}", (T0)0);
				break;
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Delay<T0, T1, T2>(FBFlow flow)
	{
		//IL_0017: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_003a: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0050: Expected O, but got I4
		T0 val = (T0)int.Parse(flow.getValue<object, List<FBFlowField>, T1, T2>((T2)"Số_giây_nghỉ").ToString());
		T0 val2 = (T0)0;
		T1 val4;
		do
		{
			T1 val3 = (T1)(frmMain.isRunning && frmMain.listFBEntity[indexEntity].Select);
			if (val3 != null)
			{
				setMessage((T2)$"Delay {(T0)(val2 + 1)}", (T1)0);
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
	public void GoToUrl<T0, T1, T2>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected I4, but got Unknown
		//IL_00d2: Expected I4, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		T2 val = (T2)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		T0[] array = null;
		try
		{
			array = (T0[])(object)(string[])flow.getValue<object, List<FBFlowField>, T2, T0>((T0)"List URL");
		}
		catch (Exception)
		{
		}
		T2 val2 = (T2)(array == null);
		if (val2 != null)
		{
			array = JsonConvert.DeserializeObject<T0[]>(flow.getValue<object, List<FBFlowField>, T2, T0>((T0)"List URL").ToString());
		}
		T1 val3 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T2, T0>((T0)"On_Site_From").ToString());
		T1 val4 = (T1)int.Parse(flow.getValue<object, List<FBFlowField>, T2, T0>((T0)"On_Site_To").ToString());
		T2 val5 = (T2)(array != null && array.Length != 0);
		if (val5 == null)
		{
			return;
		}
		T0[] array2 = array;
		T1 val6 = (T1)0;
		while ((nint)val6 < array2.Length)
		{
			T0 val7 = (T0)((object[])(object)array2)[(object)val6];
			T2 val8 = (T2)(!string.IsNullOrWhiteSpace((string)val7));
			if (val8 != null)
			{
				goUrl<T1, T2, ReadOnlyCollection<IWebElement>, IWebElement, Exception, T0>(val7);
				Thread.Sleep(rnd.Next(val3 * 1000, val4 * 1000));
			}
			val6 = (T1)(val6 + 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Close_Browser<T0, T1, T2, T3, T4>(FBFlow flow)
	{
		//IL_0018: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		try
		{
			T0 val = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Clear_Cookie").ToString());
			T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T1>((T1)"Save_Last_Cookie").ToString());
			T0 val3 = val2;
			if (val3 != null)
			{
				try
				{
					T0 val4 = (T0)(chrome != null);
					if (val4 != null)
					{
						T1 val5 = (T1)"";
						T2 enumerator = (T2)((RemoteWebDriver)chrome).Manage().Cookies.AllCookies.GetEnumerator();
						try
						{
							while (((IEnumerator)enumerator).MoveNext())
							{
								T3 current = (T3)((IEnumerator<Cookie>)enumerator).Current;
								val5 = (T1)((string)val5 + $"{((Cookie)current).Name}={((Cookie)current).Value};");
							}
						}
						finally
						{
							if (enumerator != null)
							{
								((IDisposable)enumerator).Dispose();
							}
						}
						frmMain.listFBEntity[indexEntity].Cookie = (string)val5;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			try
			{
				T0 val6 = (T0)(val != null && chrome != null);
				if (val6 != null)
				{
					((RemoteWebDriver)chrome).Manage().Cookies.DeleteAllCookies();
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.Message);
			}
			T0 val7 = (T0)frmMain.listFBEntity[indexEntity].Status.Equals(frmMain.STATUS.Working.ToString());
			if (val7 != null)
			{
				frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Status", (T1)frmMain.STATUS.Done.ToString());
			}
			frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Select", (T1)System.Runtime.CompilerServices.Unsafe.As<T0, bool>(ref (T0)0).ToString());
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.Message);
		}
		try
		{
			T0 val8 = (T0)(chrome != null);
			if (val8 != null)
			{
				((RemoteWebDriver)chrome).Close();
				((RemoteWebDriver)chrome).Quit();
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void goUrl<T0, T1, T2, T3, T4, T5>(T5 url)
	{
		//IL_0002: Expected O, but got I4
		//IL_000a: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0084: Expected I4, but got O
		//IL_0092: Expected I4, but got O
		//IL_00a0: Expected I4, but got O
		//IL_00b9: Expected I4, but got O
		//IL_00d1: Expected O, but got I4
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I4
		//IL_00ef: Expected I4, but got O
		//IL_0121: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_016f: Expected O, but got I4
		T0 val = (T0)0;
		T1 val11;
		do
		{
			T1 val2 = (T1)(frmMain.isRunning && chrome != null);
			if (val2 == null)
			{
				break;
			}
			try
			{
				((RemoteWebDriver)chrome).Navigate().GoToUrl((string)url);
				T1 val3 = (T1)(((RemoteWebDriver)chrome).PageSource.Contains("Now you can find Privacy") || ((RemoteWebDriver)chrome).PageSource.Contains("Have ideas or spot an issue"));
				if (val3 == null)
				{
					break;
				}
				T2 val4 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
				T0 val5 = (T0)(((ReadOnlyCollection<IWebElement>)val4).Count - 1);
				while (true)
				{
					T1 val6 = (T1)((nint)val5 >= 0);
					if (val6 == null)
					{
						break;
					}
					T1 val7 = (T1)(((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Enabled && ((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Displayed && (((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Text.Contains("Now you can find Privacy") || ((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Text.Contains("Have ideas or spot an issue")));
					if (val7 == null)
					{
						val5 = (T0)(val5 - 1);
						continue;
					}
					T3 e = (T3)((ReadOnlyCollection<IWebElement>)val4)[(int)val5];
					T3 parent = GetParent(GetParent(e));
					T2 val8 = (T2)((ISearchContext)parent).FindElements(By.TagName("i"));
					T1 val9 = (T1)(((ReadOnlyCollection<IWebElement>)val8).Count > 0);
					if (val9 != null)
					{
						((IWebElement)GetParent(((IEnumerable<T3>)val8).First())).Click();
					}
					Thread.Sleep(1500);
					break;
				}
				break;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			T1 val10 = (T1)(chrome == null);
			if (val10 == null)
			{
				val = (T0)(val + 1);
				val11 = (T1)((nint)val >= 5);
				continue;
			}
			break;
		}
		while (val11 == null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void Đăng_nhập<T0, T1, T2, T3, T4, T5, T6, T7>(FBFlow flow)
	{
		//IL_0017: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_01f8: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_0244: Expected O, but got I4
		//IL_0295: Expected O, but got I4
		//IL_02c7: Expected O, but got I4
		//IL_02d8: Expected O, but got I4
		//IL_032e: Expected O, but got I4
		//IL_0360: Expected O, but got I4
		//IL_0388: Expected O, but got I4
		//IL_03c0: Expected O, but got I4
		//IL_03cb: Expected I4, but got O
		//IL_03cd: Expected O, but got I4
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_0439: Expected O, but got I4
		//IL_0467: Expected O, but got I4
		//IL_0472: Expected I4, but got O
		//IL_0474: Expected O, but got I4
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Expected O, but got Unknown
		//IL_04ed: Expected O, but got I4
		//IL_0528: Expected O, but got I4
		//IL_0532: Expected O, but got I4
		//IL_0544: Expected O, but got I4
		//IL_057c: Expected O, but got I4
		//IL_0587: Expected I4, but got O
		//IL_0589: Expected O, but got I4
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_05f5: Expected O, but got I4
		//IL_0623: Expected O, but got I4
		//IL_062e: Expected I4, but got O
		//IL_0630: Expected O, but got I4
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_06d1: Expected O, but got I4
		//IL_06e2: Expected O, but got I4
		//IL_0700: Expected O, but got I4
		//IL_0724: Expected O, but got I4
		//IL_0742: Expected O, but got I4
		//IL_07e4: Expected O, but got I4
		//IL_081e: Expected O, but got I4
		//IL_0858: Expected O, but got I4
		//IL_089d: Expected O, but got I4
		//IL_08fa: Expected O, but got I4
		//IL_0913: Expected O, but got I4
		//IL_094b: Expected O, but got I4
		//IL_0956: Expected I4, but got O
		//IL_0958: Expected O, but got I4
		//IL_0991: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Expected O, but got Unknown
		//IL_09b1: Expected O, but got I4
		//IL_09e9: Expected O, but got I4
		//IL_09f4: Expected I4, but got O
		//IL_09f6: Expected O, but got I4
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Expected O, but got Unknown
		//IL_0a9b: Expected O, but got I4
		//IL_0aba: Expected O, but got I4
		//IL_0acf: Expected O, but got I4
		//IL_0af6: Expected O, but got I4
		//IL_0afd: Expected O, but got I4
		//IL_0b09: Expected O, but got I4
		//IL_0b3b: Expected O, but got I4
		//IL_0b80: Expected O, but got I4
		//IL_0bc5: Expected O, but got I4
		//IL_0bf7: Expected O, but got I4
		//IL_0c13: Expected O, but got I4
		//IL_0c25: Expected O, but got I4
		//IL_0c5c: Expected O, but got I4
		//IL_0c67: Expected I4, but got O
		//IL_0c69: Expected O, but got I4
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca0: Expected O, but got Unknown
		//IL_0d04: Expected O, but got I4
		//IL_0d49: Expected O, but got I4
		//IL_0d8e: Expected O, but got I4
		//IL_0dd3: Expected O, but got I4
		//IL_0e18: Expected O, but got I4
		//IL_0e29: Expected O, but got I4
		//IL_0e43: Expected O, but got I4
		//IL_0e52: Expected O, but got I4
		//IL_0e57: Expected O, but got I4
		//IL_0e8d: Expected O, but got I4
		//IL_0eea: Expected O, but got I4
		//IL_0f09: Expected O, but got I4
		//IL_0f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2c: Expected O, but got Unknown
		//IL_0f33: Expected O, but got I4
		//IL_0f9b: Expected O, but got I4
		//IL_0fbe: Expected O, but got I4
		T0 val = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Login_By_Cookie").ToString());
		T0 val2 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"mbasic.facebook").ToString());
		T0 val3 = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"m.facebook").ToString());
		T0 cập_nhật_nhóm = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Cập_nhật_nhóm").ToString());
		T0 cập_nhật_page = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Cập_nhật_page").ToString());
		T0 lấy_Token_EAAG = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Lấy_Token_EAAG").ToString());
		T0 lấy_Token_EAAB = (T0)bool.Parse(flow.getValue<object, List<FBFlowField>, T0, T3>((T3)"Lấy_Token_EAAB").ToString());
		T0 val4 = (T0)(!frmMain.isRunning || chrome == null);
		if (val4 != null)
		{
			return;
		}
		T0 val5 = (T0)((object)val2 | (object)val3);
		if (val5 == null)
		{
			T0 val6 = val3;
			if (val6 == null)
			{
				try
				{
					goUrl<T4, T0, T1, T2, T7, T3>((T3)ResouceControl.getResouce("RESOUCE_START_PAGE"));
					Thread.Sleep(1000);
					T1 val7 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
					T0 val8 = (T0)(val7 != null && ((ReadOnlyCollection<IWebElement>)val7).Count > 0);
					if (val8 != null)
					{
						T6 val9 = (T6)((IEnumerable<T2>)val7).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).GetAttribute("data-cookiebanner") != null && ((IWebElement)a).GetAttribute("data-cookiebanner").Equals("accept_button")))).ToList();
						T0 val10 = (T0)(val9 != null && ((List<IWebElement>)val9).Count > 0);
						if (val10 != null)
						{
							((IWebElement)((IEnumerable<T2>)val9).First()).Click();
							Thread.Sleep(1500);
						}
					}
					T1 val11 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("email"));
					T1 val12 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("appsNav"));
					T1 val13 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[@href='/stories/create/']"));
					T0 val14 = (T0)((val11 == null || ((ReadOnlyCollection<IWebElement>)val11).Count <= 0) && ((val12 != null && ((ReadOnlyCollection<IWebElement>)val12).Count > 0) || (val13 != null && ((ReadOnlyCollection<IWebElement>)val13).Count > 0)));
					if (val14 != null)
					{
						loginSucess<T0, T3, T1, T4, T2, T7, IEnumerator<Cookie>, Cookie, IJavaScriptExecutor, object, IEnumerator, Match, T5, IDisposable, Dictionary<string, string>>((T0)0, cập_nhật_nhóm, cập_nhật_page, lấy_Token_EAAG, lấy_Token_EAAB);
					}
					else
					{
						T1 val15 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("m_login_email"));
						T0 val16 = (T0)(val15 != null && ((ReadOnlyCollection<IWebElement>)val15).Count > 0);
						if (val16 == null)
						{
							T4 typeLogin = (T4)0;
							T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("input"));
							T6 val17 = (T6)((IEnumerable<T2>)source).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).GetAttribute("type") != null && ((IWebElement)a).GetAttribute("type").Equals("search")))).ToList();
							T0 val18 = (T0)(((List<IWebElement>)val17).Count > 0);
							if (val18 == null)
							{
								T1 val19 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointBottomBar"));
								T0 val20 = (T0)(val19 != null && ((ReadOnlyCollection<IWebElement>)val19).Count > 0);
								if (val20 != null)
								{
									updateStatus((T3)"Checkpoint", (T0)1);
								}
								else
								{
									T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("a"));
									T6 val21 = (T6)((IEnumerable<T2>)source2).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).GetAttribute("href") != null && ((IWebElement)a).GetAttribute("href").Contains("checkpoint/dyi/?privacy_mutation_token")))).ToList();
									T0 val22 = (T0)(((List<IWebElement>)val21).Count > 0);
									if (val22 == null)
									{
										T0 val23 = (T0)(val != null && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Cookie));
										if (val23 != null)
										{
											loginByCookie<T3, T0, T4, DateTime, T7, T5, T1, T2, IJavaScriptExecutor, object>(cập_nhật_nhóm, cập_nhật_page, lấy_Token_EAAG, lấy_Token_EAAB);
										}
										else
										{
											focusElement<IJavaScriptExecutor, T7, T2, T4, object>(((IEnumerable<T2>)val11).First(), (T4)500);
											((IWebElement)((IEnumerable<T2>)val11).First()).Click();
											((IWebElement)((IEnumerable<T2>)val11).First()).Clear();
											T3 uID = (T3)frmMain.listFBEntity[indexEntity].UID;
											T4 val24 = (T4)0;
											while ((nint)val24 < ((string)uID).Length)
											{
												T5 val25 = (T5)((string)uID)[(int)val24];
												((IWebElement)((IEnumerable<T2>)val11).First()).SendKeys(((char*)(&val25))->ToString());
												Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
												val24 = (T4)(val24 + 1);
											}
											T2 val26 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("pass"));
											focusElement<IJavaScriptExecutor, T7, T2, T4, object>(val26, (T4)500);
											((IWebElement)val26).Click();
											((IWebElement)val26).Clear();
											T3 password = (T3)frmMain.listFBEntity[indexEntity].Password;
											T4 val27 = (T4)0;
											while ((nint)val27 < ((string)password).Length)
											{
												((IWebElement)val26).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)((string)password)[(int)val27]).ToString());
												Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
												val27 = (T4)(val27 + 1);
											}
											((IWebElement)val26).SendKeys(Keys.Enter);
											Thread.Sleep(2000);
											checkLogin<T0, T1, T3, T4, T5, T6, T7, T2>(typeLogin, cập_nhật_nhóm, cập_nhật_page, lấy_Token_EAAG, lấy_Token_EAAB);
										}
									}
									else
									{
										updateStatus((T3)"Checkpoint", (T0)1);
									}
								}
							}
							else
							{
								fetchOldDesig();
							}
						}
						else
						{
							T0 val28 = (T0)(val != null && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Cookie));
							if (val28 == null)
							{
								T4 typeLogin = (T4)1;
								focusElement<IJavaScriptExecutor, T7, T2, T4, object>(((IEnumerable<T2>)val15).First(), (T4)500);
								((IWebElement)((IEnumerable<T2>)val15).First()).Click();
								((IWebElement)((IEnumerable<T2>)val15).First()).Clear();
								T3 uID2 = (T3)frmMain.listFBEntity[indexEntity].UID;
								T4 val29 = (T4)0;
								while ((nint)val29 < ((string)uID2).Length)
								{
									T5 val30 = (T5)((string)uID2)[(int)val29];
									((IWebElement)((IEnumerable<T2>)val15).First()).SendKeys(((char*)(&val30))->ToString());
									Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
									val29 = (T4)(val29 + 1);
								}
								T2 val31 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("m_login_password"));
								focusElement<IJavaScriptExecutor, T7, T2, T4, object>(val31, (T4)500);
								((IWebElement)val31).Click();
								((IWebElement)val31).Clear();
								T3 password2 = (T3)frmMain.listFBEntity[indexEntity].Password;
								T4 val32 = (T4)0;
								while ((nint)val32 < ((string)password2).Length)
								{
									((IWebElement)val31).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)((string)password2)[(int)val32]).ToString());
									Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
									val32 = (T4)(val32 + 1);
								}
								((IWebElement)val31).SendKeys(Keys.Enter);
								Thread.Sleep(5000);
								checkLogin<T0, T1, T3, T4, T5, T6, T7, T2>(typeLogin, cập_nhật_nhóm, cập_nhật_page, lấy_Token_EAAG, lấy_Token_EAAB);
							}
							else
							{
								loginByCookie<T3, T0, T4, DateTime, T7, T5, T1, T2, IJavaScriptExecutor, object>(cập_nhật_nhóm, cập_nhật_page, lấy_Token_EAAG, lấy_Token_EAAB);
							}
						}
					}
					return;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					T0 val33 = (T0)((RemoteWebDriver)chrome).Url.Contains("checkpoint");
					if (val33 != null)
					{
						updateStatus((T3)"Checkpoint", (T0)1);
					}
					else
					{
						countError++;
						T0 val34 = (T0)(countError >= 5);
						if (val34 == null)
						{
							Thread.Sleep(1000);
							Đăng_nhập<T0, T1, T2, T3, T4, T5, T6, T7>(flow);
						}
						else
						{
							updateStatus((T3)"Socks Die", (T0)1);
						}
					}
					return;
				}
			}
			goUrl<T4, T0, T1, T2, T7, T3>((T3)ResouceControl.getResouce("RESOUCE_M_FACEBOOK"));
			return;
		}
		T0 val35 = (T0)0;
		T0 val36 = val2;
		if (val36 != null)
		{
			goUrl<T4, T0, T1, T2, T7, T3>((T3)ResouceControl.getResouce("RESOUCE_MBASIC_FACEBOOK"));
		}
		else
		{
			goUrl<T4, T0, T1, T2, T7, T3>((T3)ResouceControl.getResouce("RESOUCE_M_FACEBOOK"));
		}
		T0 val37 = (T0)((((RemoteWebDriver)chrome).FindElements(By.Name("xc_message")) != null && ((RemoteWebDriver)chrome).FindElements(By.Name("xc_message")).Count > 0) || ((RemoteWebDriver)chrome).FindElements(By.Name("email")) == null || ((RemoteWebDriver)chrome).FindElements(By.Name("email")).Count <= 0);
		if (val37 == null)
		{
			T0 val38 = (T0)(((RemoteWebDriver)chrome).Url.Contains("828281030927956") || ((RemoteWebDriver)chrome).Url.Contains("checkpoint/block"));
			if (val38 != null)
			{
				resole956_MBasic<T3, T1, ReadOnlyCollection<string>, T4, T0, T5, T7, IJavaScriptExecutor, object, T2>();
			}
			else
			{
				T1 val39 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-testid='cookie-policy-manage-dialog-accept-button']"));
				T0 val40 = (T0)(val39 != null && ((ReadOnlyCollection<IWebElement>)val39).Count > 0);
				if (val40 != null)
				{
					((IWebElement)((IEnumerable<T2>)val39).First()).Click();
					Thread.Sleep(1500);
				}
				T1 val41 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("accept_only_essential"));
				T0 val42 = (T0)(val41 != null && ((ReadOnlyCollection<IWebElement>)val41).Count > 0);
				if (val42 != null)
				{
					((IWebElement)((IEnumerable<T2>)val41).Last()).Click();
					Thread.Sleep(1500);
				}
				T1 val43 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("m_login_email"));
				T1 source3 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("pass"));
				T0 val44 = (T0)(val43 != null && ((ReadOnlyCollection<IWebElement>)val43).Count > 0);
				if (val44 != null)
				{
					focusElement<IJavaScriptExecutor, T7, T2, T4, object>(((IEnumerable<T2>)val43).First(), (T4)500);
					((IWebElement)((IEnumerable<T2>)val43).First()).Click();
					((IWebElement)((IEnumerable<T2>)val43).First()).Clear();
					T3 uID3 = (T3)frmMain.listFBEntity[indexEntity].UID;
					T4 val45 = (T4)0;
					while ((nint)val45 < ((string)uID3).Length)
					{
						T5 val46 = (T5)((string)uID3)[(int)val45];
						((IWebElement)((IEnumerable<T2>)val43).First()).SendKeys(((char*)(&val46))->ToString());
						Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
						val45 = (T4)(val45 + 1);
					}
					focusElement<IJavaScriptExecutor, T7, T2, T4, object>(((IEnumerable<T2>)source3).First(), (T4)500);
					((IWebElement)((IEnumerable<T2>)source3).First()).Click();
					((IWebElement)((IEnumerable<T2>)source3).First()).Clear();
					T3 password3 = (T3)frmMain.listFBEntity[indexEntity].Password;
					T4 val47 = (T4)0;
					while ((nint)val47 < ((string)password3).Length)
					{
						T5 val48 = (T5)((string)password3)[(int)val47];
						((IWebElement)((IEnumerable<T2>)source3).First()).SendKeys(((char*)(&val48))->ToString());
						Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
						val47 = (T4)(val47 + 1);
					}
					T1 source4 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("login"));
					((IWebElement)((IEnumerable<T2>)source4).First()).Click();
					Thread.Sleep(3000);
					T2 val49 = (T2)null;
					while (true)
					{
						T0 val50 = (T0)frmMain.isRunning;
						if (val50 != null)
						{
							T1 val51 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("approvals_code"));
							T0 val52 = (T0)(val51 != null && ((ReadOnlyCollection<IWebElement>)val51).Count > 0);
							if (val52 == null)
							{
								T0 val53 = (T0)(((RemoteWebDriver)chrome).FindElements(By.Id("login_error")) != null);
								if (val53 != null)
								{
									break;
								}
								Thread.Sleep(1500);
								continue;
							}
							val49 = ((IEnumerable<T2>)val51).First();
							break;
						}
						break;
					}
					T0 val54 = (T0)((RemoteWebDriver)chrome).Url.Contains("save-device");
					if (val54 != null)
					{
						val35 = (T0)1;
					}
					else
					{
						T0 val55 = (T0)(val49 != null);
						if (val55 == null)
						{
							T1 val56 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val57 = (T0)(val56 != null && ((ReadOnlyCollection<IWebElement>)val56).Count > 0);
							if (val57 != null)
							{
								((IWebElement)((IEnumerable<T2>)val56).First()).Click();
								Thread.Sleep(3000);
							}
							val56 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val58 = (T0)(val56 != null && ((ReadOnlyCollection<IWebElement>)val56).Count > 0);
							if (val58 != null)
							{
								((IWebElement)((IEnumerable<T2>)val56).First()).Click();
								Thread.Sleep(3000);
							}
							val56 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val59 = (T0)(val56 != null && ((ReadOnlyCollection<IWebElement>)val56).Count > 0);
							if (val59 != null)
							{
								((IWebElement)((IEnumerable<T2>)val56).First()).Click();
								Thread.Sleep(3000);
							}
							T0 val60 = (T0)((RemoteWebDriver)chrome).Url.Contains("828281030927956");
							if (val60 != null)
							{
								resole956_MBasic<T3, T1, ReadOnlyCollection<string>, T4, T0, T5, T7, IJavaScriptExecutor, object, T2>();
							}
							else
							{
								updateStatus((T3)"Checkpoint", (T0)1);
							}
						}
						else
						{
							focusElement<IJavaScriptExecutor, T7, T2, T4, object>(val49, (T4)500);
							((IWebElement)val49).Click();
							((IWebElement)val49).Clear();
							T3 val61 = authenCode<T4, T0, T3, T7, byte, T5>((T3)frmMain.listFBEntity[indexEntity].Code2FA);
							T3 val62 = val61;
							T4 val63 = (T4)0;
							while ((nint)val63 < ((string)val62).Length)
							{
								((IWebElement)val49).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T5, char>(ref (T5)((string)val62)[(int)val63]).ToString());
								Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
								val63 = (T4)(val63 + 1);
							}
							T1 source5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							((IWebElement)((IEnumerable<T2>)source5).First()).Click();
							Thread.Sleep(3000);
							source5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val64 = (T0)(source5 != null && ((ReadOnlyCollection<IWebElement>)source5).Count > 0);
							if (val64 != null)
							{
								((IWebElement)((IEnumerable<T2>)source5).First()).Click();
								Thread.Sleep(3000);
							}
							source5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val65 = (T0)(source5 != null && ((ReadOnlyCollection<IWebElement>)source5).Count > 0);
							if (val65 != null)
							{
								((IWebElement)((IEnumerable<T2>)source5).First()).Click();
								Thread.Sleep(3000);
							}
							source5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val66 = (T0)(source5 != null && ((ReadOnlyCollection<IWebElement>)source5).Count > 0);
							if (val66 != null)
							{
								((IWebElement)((IEnumerable<T2>)source5).First()).Click();
								Thread.Sleep(3000);
							}
							source5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
							T0 val67 = (T0)(source5 != null && ((ReadOnlyCollection<IWebElement>)source5).Count > 0);
							if (val67 != null)
							{
								((IWebElement)((IEnumerable<T2>)source5).First()).Click();
								Thread.Sleep(3000);
							}
							T1 val68 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpoint_title"));
							T0 val69 = (T0)(val68 != null && ((ReadOnlyCollection<IWebElement>)val68).Count > 0);
							if (val69 != null)
							{
								updateStatus((T3)"Checkpoint", (T0)1);
							}
							else
							{
								T0 val70 = (T0)((RemoteWebDriver)chrome).Url.Contains("828281030927956");
								if (val70 != null)
								{
									resole956_MBasic<T3, T1, ReadOnlyCollection<string>, T4, T0, T5, T7, IJavaScriptExecutor, object, T2>();
								}
								else
								{
									val35 = (T0)1;
								}
							}
						}
					}
				}
			}
		}
		else
		{
			val35 = (T0)1;
		}
		T0 val71 = val35;
		if (val71 == null)
		{
			return;
		}
		T1 val72 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("accept_consent"));
		T0 val73 = (T0)(val72 != null && ((ReadOnlyCollection<IWebElement>)val72).Count > 0);
		if (val73 != null)
		{
			T1 source6 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
			((IWebElement)((IEnumerable<T2>)source6).First()).Click();
			Thread.Sleep(1500);
		}
		T1 val74 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("primary_consent_button"));
		T0 val75 = (T0)(val74 != null && ((ReadOnlyCollection<IWebElement>)val74).Count > 0);
		if (val75 != null)
		{
			T1 source7 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("body"));
			T4 val76 = (T4)0;
			while (true)
			{
				T0 val77 = (T0)((nint)val76 < 3);
				if (val77 == null)
				{
					break;
				}
				((IWebElement)((IEnumerable<T2>)source7).First()).SendKeys(Keys.PageDown);
				Thread.Sleep(200);
				val76 = (T4)(val76 + 1);
			}
			val74 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("primary_consent_button"));
			((IWebElement)((IEnumerable<T2>)val74).Last()).Click();
			Thread.Sleep(1500);
		}
		T0 val78 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("m.facebook") && !((RemoteWebDriver)chrome).Url.Contains("www.facebook"));
		if (val78 != null)
		{
			goUrl<T4, T0, T1, T2, T7, T3>((T3)ResouceControl.getResouce("RESOUCE_START_PAGE"));
		}
		loginSucess<T0, T3, T1, T4, T2, T7, IEnumerator<Cookie>, Cookie, IJavaScriptExecutor, object, IEnumerator, Match, T5, IDisposable, Dictionary<string, string>>((T0)0, cập_nhật_nhóm, cập_nhật_page, lấy_Token_EAAG, lấy_Token_EAAB);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void loginByCookie<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 Cập_nhật_nhóm, T1 Cập_nhật_page, T1 Lấy_Token_EAAG, T1 Lấy_Token_EAAB)
	{
		//IL_001f: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_032c: Expected O, but got I4
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_03e6: Expected O, but got I4
		//IL_03f7: Expected O, but got I4
		//IL_0405: Expected O, but got I4
		try
		{
			T1 val = (T1)((RemoteWebDriver)chrome).Url.Contains("m.facebook.com");
			if (val == null)
			{
				T1 val2 = (T1)((RemoteWebDriver)chrome).Url.Contains("mbasic.facebook.com");
				if (val2 == null)
				{
				}
			}
			T0[] array = (T0[])(object)frmMain.listFBEntity[indexEntity].Cookie.Split((char[])(object)new T5[1] { (T5)59 });
			T2 val3 = (T2)0;
			while ((nint)val3 < array.Length)
			{
				T0 val4 = (T0)((object[])(object)array)[(object)val3];
				try
				{
					T0 val5 = (T0)((string)val4).Trim();
					try
					{
						((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie(((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[0], ((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[1], ".facebook.com", "/", (DateTime?)((DateTime)(T3)DateTime.Now).AddYears(1)));
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
					try
					{
						((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie(((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[0], ((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[1], "www.facebook.com", "/", (DateTime?)((DateTime)(T3)DateTime.Now).AddYears(1)));
					}
					catch (Exception ex2)
					{
						Console.WriteLine(ex2.Message);
					}
					try
					{
						((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie(((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[0], ((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[1], "facebook.com", "/", (DateTime?)((DateTime)(T3)DateTime.Now).AddYears(1)));
					}
					catch (Exception ex3)
					{
						Console.WriteLine(ex3.Message);
					}
					try
					{
						((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie(((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[0], ((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[1], "m.facebook.com", "/", (DateTime?)((DateTime)(T3)DateTime.Now).AddYears(1)));
					}
					catch (Exception ex4)
					{
						Console.WriteLine(ex4.Message);
					}
					try
					{
						((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie(((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[0], ((string)val5).Split((char[])(object)new T5[1] { (T5)61 })[1], "mbasic.facebook.com", "/", (DateTime?)((DateTime)(T3)DateTime.Now).AddYears(1)));
					}
					catch (Exception ex5)
					{
						Console.WriteLine(ex5.Message);
					}
				}
				catch (Exception ex6)
				{
					Console.WriteLine(ex6.Message);
				}
				val3 = (T2)(val3 + 1);
			}
			T0[] array2 = (T0[])(object)frmMain.listFBEntity[indexEntity].Cookie.Split((char[])(object)new T5[1] { (T5)59 });
			T2 val6 = (T2)0;
			while ((nint)val6 < array2.Length)
			{
				T0 val7 = (T0)((object[])(object)array2)[(object)val6];
				try
				{
					T0 val8 = (T0)((string)val7).Trim();
					((RemoteWebDriver)chrome).Manage().Cookies.AddCookie(new Cookie(((string)val8).Split((char[])(object)new T5[1] { (T5)61 })[0], ((string)val8).Split((char[])(object)new T5[1] { (T5)61 })[1]));
				}
				catch (Exception ex7)
				{
					Console.WriteLine(ex7.Message);
				}
				val6 = (T2)(val6 + 1);
			}
			goUrl<T2, T1, T6, T7, T4, T0>((T0)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
			Thread.Sleep(2000);
			T0 val9 = executeScript<T0, T8, T2, T1, T9>((T0)"return require([\"CurrentUserInitialData\"]).USER_ID");
			T1 val10 = (T1)(string.IsNullOrWhiteSpace((string)val9) || ((string)val9).ToLower().Equals("null"));
			if (val10 != null)
			{
				updateStatus((T0)"Checkpoint", (T1)1);
			}
			else
			{
				loginSucess<T1, T0, T6, T2, T7, T4, IEnumerator<Cookie>, Cookie, T8, T9, IEnumerator, Match, T5, IDisposable, Dictionary<string, string>>((T1)1, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
			}
		}
		catch (Exception ex8)
		{
			Console.WriteLine(ex8.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void resole956_MBasic<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
	{
		//IL_0048: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0207: Expected O, but got I4
		//IL_0287: Expected O, but got I4
		//IL_0292: Expected I4, but got O
		//IL_0294: Expected O, but got I4
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_0306: Expected O, but got I4
		//IL_036e: Expected O, but got I4
		//IL_0392: Expected O, but got I4
		//IL_039d: Expected I4, but got O
		//IL_039f: Expected O, but got I4
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_03e9: Expected O, but got I4
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_041f: Expected O, but got I4
		//IL_0464: Expected O, but got I4
		//IL_04a9: Expected O, but got I4
		//IL_04ee: Expected O, but got I4
		//IL_0512: Expected O, but got I4
		try
		{
			T0 script = (T0)"window.open('https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1646101493&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3debab61aa-700c-2dc4-09cb-2fc381454845&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015');";
			executeScript<T0, T7, T3, T4, T8>(script);
			Thread.Sleep(5000);
			T1 val = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton-actual-button"));
			T4 val2 = (T4)(val != null && ((ReadOnlyCollection<IWebElement>)val).Count > 0);
			if (val2 != null)
			{
				((IWebElement)((IEnumerable<T9>)val).First()).Click();
				Thread.Sleep(2000);
			}
			T1 val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[contains(@href,'828281030927956/stepper')]"));
			T4 val4 = (T4)((val3 != null) & (((ReadOnlyCollection<IWebElement>)val3).Count > 0));
			if (val4 != null)
			{
				((IWebElement)((IEnumerable<T9>)val3).First()).Click();
				Thread.Sleep(2000);
			}
			val3 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//a[contains(@href,'828281030927956/anti_scripting')]"));
			T4 val5 = (T4)((val3 != null) & (((ReadOnlyCollection<IWebElement>)val3).Count > 0));
			if (val5 != null)
			{
				((IWebElement)((IEnumerable<T9>)val3).First()).Click();
				Thread.Sleep(2000);
			}
			T1 val6 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@type='submit']"));
			T4 val7 = (T4)((val6 != null) & (((ReadOnlyCollection<IWebElement>)val6).Count > 0));
			if (val7 != null)
			{
				((IWebElement)((IEnumerable<T9>)val6).First()).Click();
				Thread.Sleep(2000);
			}
			val6 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@type='submit']"));
			T4 val8 = (T4)((val6 != null) & (((ReadOnlyCollection<IWebElement>)val6).Count > 0));
			if (val8 != null)
			{
				((IWebElement)((IEnumerable<T9>)val6).First()).Click();
			}
			executeScript<T0, T7, T3, T4, T8>((T0)("document.title = '" + frmMain.listFBEntity[indexEntity].UID + "'"));
			T2 windowHandles = (T2)((RemoteWebDriver)chrome).WindowHandles;
			_ = ((RemoteWebDriver)chrome).CurrentWindowHandle;
			string chromeOutlook = (string)((IEnumerable<T0>)((RemoteWebDriver)chrome).WindowHandles).Last();
			T0 val9 = ((IEnumerable<T0>)windowHandles).Where((Func<T0, bool>)(object)(Func<string, bool>)((T0 a) => (T4)((string)a).Equals(chromeOutlook))).First();
			((RemoteWebDriver)chrome).SwitchTo().Window((string)val9);
			T3 val10 = (T3)0;
			while (true)
			{
				T1 val11 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("loginfmt"));
				T4 val12 = (T4)(val11 != null && ((ReadOnlyCollection<IWebElement>)val11).Count > 0 && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].Email));
				if (val12 == null)
				{
					val10 = (T3)(val10 + 1);
					T4 val13 = (T4)((nint)val10 < 5);
					if (val13 == null)
					{
						break;
					}
					Thread.Sleep(2000);
					continue;
				}
				T0 email = (T0)frmMain.listFBEntity[indexEntity].Email;
				T3 val14 = (T3)0;
				while ((nint)val14 < ((string)email).Length)
				{
					T5 val15 = (T5)((string)email)[(int)val14];
					((IWebElement)((IEnumerable<T9>)val11).First()).SendKeys(((char*)(&val15))->ToString());
					Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
					val14 = (T3)(val14 + 1);
				}
				break;
			}
			T1 val16 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("idSIButton9"));
			T4 val17 = (T4)(val16 != null && ((ReadOnlyCollection<IWebElement>)val16).Count > 0);
			if (val17 != null)
			{
				((IWebElement)((IEnumerable<T9>)val16).First()).Click();
				Thread.Sleep(3000);
			}
			T1 val18 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("passwd"));
			T4 val19 = (T4)(val18 != null && ((ReadOnlyCollection<IWebElement>)val18).Count > 0 && !string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].EmailPassword));
			if (val19 != null)
			{
				T0 emailPassword = (T0)frmMain.listFBEntity[indexEntity].EmailPassword;
				T3 val20 = (T3)0;
				while ((nint)val20 < ((string)emailPassword).Length)
				{
					T5 val21 = (T5)((string)emailPassword)[(int)val20];
					((IWebElement)((IEnumerable<T9>)val18).First()).SendKeys(((char*)(&val21))->ToString());
					Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
					val20 = (T3)(val20 + 1);
				}
			}
			T3 val22 = (T3)0;
			while (true)
			{
				T4 val23 = (T4)((nint)val22 <= 5);
				if (val23 != null)
				{
					val22 = (T3)(val22 + 1);
					T1 val24 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//span[@data-automationid='splitbuttonprimary']"));
					T4 val25 = (T4)(val24 != null && ((ReadOnlyCollection<IWebElement>)val24).Count > 0);
					if (val25 != null)
					{
						((IWebElement)((IEnumerable<T9>)val24).First()).Click();
						Thread.Sleep(1000);
					}
					val16 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("idSIButton9"));
					T4 val26 = (T4)(val16 != null && ((ReadOnlyCollection<IWebElement>)val16).Count > 0);
					if (val26 != null)
					{
						((IWebElement)((IEnumerable<T9>)val16).First()).Click();
						Thread.Sleep(3000);
					}
					T1 val27 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("iShowSkip"));
					T4 val28 = (T4)(val27 != null && ((ReadOnlyCollection<IWebElement>)val27).Count > 0);
					if (val28 != null)
					{
						((IWebElement)((IEnumerable<T9>)val27).First()).Click();
						Thread.Sleep(1000);
					}
					T1 val29 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("iCancel"));
					T4 val30 = (T4)(val29 != null && ((ReadOnlyCollection<IWebElement>)val29).Count > 0);
					if (val30 != null)
					{
						((IWebElement)((IEnumerable<T9>)val29).First()).Click();
						Thread.Sleep(2000);
					}
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void fetchOldDesig()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void checkLogin<T0, T1, T2, T3, T4, T5, T6, T7>(T3 typeLogin, T0 Cập_nhật_nhóm, T0 Cập_nhật_page, T0 Lấy_Token_EAAG, T0 Lấy_Token_EAAB)
	{
		//IL_0014: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0151: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_01ab: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_023c: Expected O, but got I4
		//IL_0279: Expected O, but got I4
		//IL_0284: Expected I4, but got O
		//IL_0286: Expected O, but got I4
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02f3: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("approvals_code"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 == null)
			{
				T1 val4 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("appsNav"));
				T0 val5 = (T0)(val4 != null && ((ReadOnlyCollection<IWebElement>)val4).Count > 0);
				if (val5 != null)
				{
					clickContinues<T0, T1, T5, T6, T3, T7>((T3)1, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
					return;
				}
				T1 val6 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton"));
				T0 val7 = (T0)(((ReadOnlyCollection<IWebElement>)val6).Count > 0);
				if (val7 == null)
				{
					updateStatus((T2)"Checkpoint", (T0)1);
					return;
				}
				T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("localeSelectorList"));
				T1 source2 = (T1)((ISearchContext)((IEnumerable<T7>)source).First()).FindElements(By.TagName("a"));
				T5 val8 = (T5)((IEnumerable<T7>)source2).Where((Func<T7, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T7 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).GetAttribute("title") != null && (((IWebElement)a).GetAttribute("title").Equals("English (US)") || ((IWebElement)a).GetAttribute("title").Equals("English (UK)"))))).ToList();
				T0 val9 = (T0)(((List<IWebElement>)val8).Count > 0);
				if (val9 == null)
				{
					T0 val10 = (T0)((RemoteWebDriver)chrome).PageSource.ToLower().Contains("review recent login");
					if (val10 != null)
					{
						focusElement<IJavaScriptExecutor, T6, T7, T3, object>(((IEnumerable<T7>)val6).First(), (T3)500);
						((IWebElement)((IEnumerable<T7>)val6).First()).Click();
						Thread.Sleep(2000);
						val6 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton"));
						T0 val11 = (T0)(val6 != null && ((ReadOnlyCollection<IWebElement>)val6).Count > 0);
						if (val11 != null)
						{
							focusElement<IJavaScriptExecutor, T6, T7, T3, object>(((IEnumerable<T7>)val6).First(), (T3)500);
							((IWebElement)((IEnumerable<T7>)val6).First()).Click();
							Thread.Sleep(1000);
						}
						clickContinues<T0, T1, T5, T6, T3, T7>((T3)0, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
					}
					else
					{
						updateStatus((T2)"Checkpoint", (T0)1);
					}
				}
				else
				{
					focusElement<IJavaScriptExecutor, T6, T7, T3, object>(((IEnumerable<T7>)val8).First(), (T3)500);
					((IWebElement)((IEnumerable<T7>)val8).First()).Click();
					checkLogin<T0, T1, T2, T3, T4, T5, T6, T7>(typeLogin, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
				}
			}
			else
			{
				focusElement<IJavaScriptExecutor, T6, T7, T3, object>(((IEnumerable<T7>)val2).First(), (T3)500);
				((IWebElement)((IEnumerable<T7>)val2).First()).Click();
				((IWebElement)((IEnumerable<T7>)val2).First()).Clear();
				T2 val12 = authenCode<T3, T0, T2, T6, byte, T4>((T2)frmMain.listFBEntity[indexEntity].Code2FA);
				T2 val13 = val12;
				T3 val14 = (T3)0;
				while ((nint)val14 < ((string)val13).Length)
				{
					T4 val15 = (T4)((string)val13)[(int)val14];
					((IWebElement)((IEnumerable<T7>)val2).First()).SendKeys(((char*)(&val15))->ToString());
					Thread.Sleep(rnd.Next(frmMain.setting.numFromDelay, frmMain.setting.numToDelay));
					val14 = (T3)(val14 + 1);
				}
				((IWebElement)((IEnumerable<T7>)val2).First()).SendKeys(Keys.Enter);
				Thread.Sleep(2000);
				clickContinues<T0, T1, T5, T6, T3, T7>((T3)0, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			checkLogin<T0, T1, T2, T3, T4, T5, T6, T7>(typeLogin, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clickContinues<T0, T1, T2, T3, T4, T5>(T4 step, T0 Cập_nhật_nhóm, T0 Cập_nhật_page, T0 Lấy_Token_EAAG, T0 Lấy_Token_EAAB)
	{
		//IL_0014: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_0215: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_0253: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_0298: Expected O, but got I4
		//IL_02a9: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02cb: Expected O, but got I4
		//IL_02ed: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSecondaryButton"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 != null)
			{
				try
				{
					((IWebElement)((IEnumerable<T5>)val2).First()).Click();
					Thread.Sleep(2000);
				}
				catch
				{
				}
			}
			T1 val4 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton"));
			T0 val5 = (T0)(step == null);
			if (val5 == null)
			{
				T0 val6 = (T0)((nint)step == 1);
				if (val6 == null)
				{
					return;
				}
				T0 val7 = (T0)(val4 != null && ((ReadOnlyCollection<IWebElement>)val4).Count > 0);
				if (val7 == null)
				{
					T0 val8 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("Account Has Been Locked");
					if (val8 == null)
					{
						T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("a"));
						T2 val9 = (T2)((IEnumerable<T5>)source).Where((Func<T5, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T5 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).GetAttribute("href") != null && ((IWebElement)a).GetAttribute("href").Contains("checkpoint/dyi/?privacy_mutation_toke")))).ToList();
						T0 val10 = (T0)(val9 != null && ((List<IWebElement>)val9).Count > 0);
						if (val10 == null)
						{
							loginSucess<T0, string, T1, T4, T5, T3, IEnumerator<Cookie>, Cookie, IJavaScriptExecutor, object, IEnumerator, Match, char, IDisposable, Dictionary<string, string>>((T0)1, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
						}
						else
						{
							updateStatus("Checkpoint", (T0)1);
						}
					}
					else
					{
						updateStatus("Checkpoint", (T0)1);
					}
					return;
				}
				T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("localeSelectorList"));
				T1 source3 = (T1)((ISearchContext)((IEnumerable<T5>)source2).First()).FindElements(By.TagName("a"));
				T2 val11 = (T2)((IEnumerable<T5>)source3).Where((Func<T5, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T5 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled && ((IWebElement)a).GetAttribute("title") != null && (((IWebElement)a).GetAttribute("title").Equals("English (US)") || ((IWebElement)a).GetAttribute("title").Equals("English (UK)"))))).ToList();
				T0 val12 = (T0)(((List<IWebElement>)val11).Count > 0);
				if (val12 != null)
				{
					focusElement<IJavaScriptExecutor, T3, T5, T4, object>(((IEnumerable<T5>)val11).First(), (T4)500);
					((IWebElement)((IEnumerable<T5>)val11).First()).Click();
					clickContinues<T0, T1, T2, T3, T4, T5>((T4)1, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
					return;
				}
				T0 val13 = (T0)((RemoteWebDriver)chrome).PageSource.ToLower().Contains("review recent login");
				if (val13 != null)
				{
					focusElement<IJavaScriptExecutor, T3, T5, T4, object>(((IEnumerable<T5>)val4).First(), (T4)500);
					((IWebElement)((IEnumerable<T5>)val4).First()).Click();
					Click_This_Was_Me<T0, T1, T3, T5>(Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
				}
				else
				{
					updateStatus("Checkpoint", (T0)1);
				}
				return;
			}
			T0 val14 = (T0)(val4 != null && ((ReadOnlyCollection<IWebElement>)val4).Count > 0);
			if (val14 == null)
			{
				T1 val15 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("appsNav"));
				T0 val16 = (T0)(val15 != null && ((ReadOnlyCollection<IWebElement>)val15).Count > 0);
				if (val16 == null)
				{
					updateStatus("Checkpoint", (T0)1);
				}
				else
				{
					clickContinues<T0, T1, T2, T3, T4, T5>((T4)1, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
				}
			}
			else
			{
				focusElement<IJavaScriptExecutor, T3, T5, T4, object>(((IEnumerable<T5>)val4).First(), (T4)500);
				((IWebElement)((IEnumerable<T5>)val4).First()).Click();
				Thread.Sleep(2000);
				clickContinues<T0, T1, T2, T3, T4, T5>((T4)1, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			clickContinues<T0, T1, T2, T3, T4, T5>(step, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Click_This_Was_Me<T0, T1, T2, T3>(T0 Cập_nhật_nhóm, T0 Cập_nhật_page, T0 Lấy_Token_EAAG, T0 Lấy_Token_EAAB)
	{
		//IL_0014: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 != null)
			{
				focusElement<IJavaScriptExecutor, T2, T3, int, object>(((IEnumerable<T3>)val2).First(), 500);
				((IWebElement)((IEnumerable<T3>)val2).First()).Click();
				Thread.Sleep(1000);
			}
			Click_This_Was_Me_2<T0, T1, T2, T3, List<IWebElement>, int>(Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(2000);
			Click_This_Was_Me<T0, T1, T2, T3>(Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Click_This_Was_Me_2<T0, T1, T2, T3, T4, T5>(T0 Cập_nhật_nhóm, T0 Cập_nhật_page, T0 Lấy_Token_EAAG, T0 Lấy_Token_EAAB)
	{
		//IL_0014: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 != null)
			{
				focusElement<IJavaScriptExecutor, T2, T3, T5, object>(((IEnumerable<T3>)val2).First(), (T5)500);
				((IWebElement)((IEnumerable<T3>)val2).First()).Click();
				Thread.Sleep(1000);
			}
			clickContinues<T0, T1, T4, T2, T5, T3>((T5)0, Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(2000);
			Click_This_Was_Me<T0, T1, T2, T3>(Cập_nhật_nhóm, Cập_nhật_page, Lấy_Token_EAAG, Lấy_Token_EAAB);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void loginSucess<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 isChangeLanguage, T0 Cập_nhật_nhóm, T0 Cập_nhật_page, T0 Lấy_Token_EAAG, T0 Lấy_Token_EAAB)
	{
		//IL_003c: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_00e2: Expected I4, but got O
		//IL_00f2: Expected I4, but got O
		//IL_0102: Expected I4, but got O
		//IL_0117: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_012b: Expected O, but got I4
		//IL_013a: Expected I4, but got O
		//IL_0167: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		//IL_01a3: Expected O, but got I4
		//IL_01ae: Expected I4, but got O
		//IL_01be: Expected I4, but got O
		//IL_01ce: Expected I4, but got O
		//IL_01e3: Expected O, but got I4
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f7: Expected O, but got I4
		//IL_0206: Expected I4, but got O
		//IL_024e: Expected O, but got I4
		//IL_0263: Expected O, but got I4
		//IL_028a: Expected O, but got I4
		//IL_0295: Expected I4, but got O
		//IL_02a5: Expected I4, but got O
		//IL_02b5: Expected I4, but got O
		//IL_02d0: Expected I4, but got O
		//IL_02e8: Expected O, but got I4
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fc: Expected O, but got I4
		//IL_030b: Expected I4, but got O
		//IL_033d: Expected O, but got I4
		//IL_03a2: Expected O, but got I4
		//IL_03cc: Expected O, but got I4
		//IL_03d7: Expected I4, but got O
		//IL_03e7: Expected I4, but got O
		//IL_03f7: Expected I4, but got O
		//IL_0412: Expected I4, but got O
		//IL_042a: Expected O, but got I4
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Expected O, but got Unknown
		//IL_043e: Expected O, but got I4
		//IL_044d: Expected I4, but got O
		//IL_047f: Expected O, but got I4
		//IL_04d2: Expected O, but got I4
		//IL_04fc: Expected O, but got I4
		//IL_0507: Expected I4, but got O
		//IL_0517: Expected I4, but got O
		//IL_0527: Expected I4, but got O
		//IL_0542: Expected I4, but got O
		//IL_055a: Expected O, but got I4
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_056e: Expected O, but got I4
		//IL_057d: Expected I4, but got O
		//IL_05af: Expected O, but got I4
		//IL_05f8: Expected O, but got I4
		//IL_0648: Expected O, but got I4
		//IL_071c: Expected O, but got I4
		if (isChangeLanguage != null)
		{
			changeLanguageFetch<T14, T1, T8, T3, T0, T9>();
			((RemoteWebDriver)chrome).Navigate().Refresh();
			Thread.Sleep(2000);
		}
		T0 val = (T0)((RemoteWebDriver)chrome).Url.Contains("gettingstarted");
		if (val != null)
		{
			goUrl<T3, T0, T2, T4, T5, T1>((T1)"https://m.facebook.com/a/nux/wizard/nav.php?step=upload_profile_pic&skip");
		}
		T0 val2 = (T0)string.IsNullOrEmpty(frmMain.listFBEntity[indexEntity].Name);
		if (val2 != null)
		{
			T1 value = executeScript<T1, T8, T3, T0, T9>((T1)"return require([\"CurrentUserInitialData\"]).NAME;");
			frmMain.SetCellText<T0, T3, T1>((T3)indexEntity, (T1)"Name", value);
		}
		T0 val3 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("Welcome to a Fresh");
		if (val3 != null)
		{
			try
			{
				T2 val4 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
				T3 val5 = (T3)(((ReadOnlyCollection<IWebElement>)val4).Count - 1);
				while (true)
				{
					T0 val6 = (T0)((nint)val5 >= 0);
					if (val6 != null)
					{
						T0 val7 = (T0)(((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Enabled && ((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Displayed && ((ReadOnlyCollection<IWebElement>)val4)[(int)val5].Text.Equals("Next"));
						if (val7 == null)
						{
							val5 = (T3)(val5 - 1);
							continue;
						}
						T4 val8 = (T4)((ReadOnlyCollection<IWebElement>)val4)[(int)val5];
						((IWebElement)val8).Click();
						Thread.Sleep(1500);
						break;
					}
					break;
				}
				while (true)
				{
					T0 val9 = (T0)frmMain.isRunning;
					if (val9 == null)
					{
						break;
					}
					T0 val10 = (T0)((RemoteWebDriver)chrome).PageSource.Contains("Choose a Look");
					if (val10 != null)
					{
						break;
					}
					Thread.Sleep(1000);
				}
				val4 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
				T3 val11 = (T3)(((ReadOnlyCollection<IWebElement>)val4).Count - 1);
				while (true)
				{
					T0 val12 = (T0)((nint)val11 >= 0);
					if (val12 != null)
					{
						T0 val13 = (T0)(((ReadOnlyCollection<IWebElement>)val4)[(int)val11].Enabled && ((ReadOnlyCollection<IWebElement>)val4)[(int)val11].Displayed && ((ReadOnlyCollection<IWebElement>)val4)[(int)val11].Text.Equals("Get Started"));
						if (val13 == null)
						{
							val11 = (T3)(val11 - 1);
							continue;
						}
						T4 val14 = (T4)((ReadOnlyCollection<IWebElement>)val4)[(int)val11];
						((IWebElement)val14).Click();
						Thread.Sleep(1500);
						break;
					}
					break;
				}
				while (true)
				{
					T0 val15 = (T0)frmMain.isRunning;
					if (val15 == null)
					{
						break;
					}
					T0 val16 = (T0)(((RemoteWebDriver)chrome).PageSource.Contains("Now you can find Privacy") || ((RemoteWebDriver)chrome).PageSource.Contains("Have ideas or spot an issue"));
					if (val16 != null)
					{
						break;
					}
					Thread.Sleep(1000);
				}
				val4 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
				T3 val17 = (T3)(((ReadOnlyCollection<IWebElement>)val4).Count - 1);
				while (true)
				{
					T0 val18 = (T0)((nint)val17 >= 0);
					if (val18 == null)
					{
						break;
					}
					T0 val19 = (T0)(((ReadOnlyCollection<IWebElement>)val4)[(int)val17].Enabled && ((ReadOnlyCollection<IWebElement>)val4)[(int)val17].Displayed && (((ReadOnlyCollection<IWebElement>)val4)[(int)val17].Text.Contains("Now you can find Privacy") || ((ReadOnlyCollection<IWebElement>)val4)[(int)val17].Text.Contains("Have ideas or spot an issue")));
					if (val19 == null)
					{
						val17 = (T3)(val17 - 1);
						continue;
					}
					T4 e = (T4)((ReadOnlyCollection<IWebElement>)val4)[(int)val17];
					T4 parent = GetParent(GetParent(e));
					T2 val20 = (T2)((ISearchContext)parent).FindElements(By.TagName("i"));
					T0 val21 = (T0)(((ReadOnlyCollection<IWebElement>)val20).Count > 0);
					if (val21 != null)
					{
						((IWebElement)GetParent(((IEnumerable<T4>)val20).First())).Click();
					}
					Thread.Sleep(1500);
					break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		T0 val22 = (T0)(((RemoteWebDriver)chrome).PageSource.Contains("Now you can find Privacy") || ((RemoteWebDriver)chrome).PageSource.Contains("Have ideas or spot an issue"));
		if (val22 != null)
		{
			T2 val23 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
			T3 val24 = (T3)(((ReadOnlyCollection<IWebElement>)val23).Count - 1);
			while (true)
			{
				T0 val25 = (T0)((nint)val24 >= 0);
				if (val25 == null)
				{
					break;
				}
				T0 val26 = (T0)(((ReadOnlyCollection<IWebElement>)val23)[(int)val24].Enabled && ((ReadOnlyCollection<IWebElement>)val23)[(int)val24].Displayed && (((ReadOnlyCollection<IWebElement>)val23)[(int)val24].Text.Contains("Now you can find Privacy") || ((ReadOnlyCollection<IWebElement>)val23)[(int)val24].Text.Contains("Have ideas or spot an issue")));
				if (val26 == null)
				{
					val24 = (T3)(val24 - 1);
					continue;
				}
				T4 e2 = (T4)((ReadOnlyCollection<IWebElement>)val23)[(int)val24];
				T4 parent2 = GetParent(GetParent(e2));
				T2 val27 = (T2)((ISearchContext)parent2).FindElements(By.TagName("i"));
				T0 val28 = (T0)(((ReadOnlyCollection<IWebElement>)val27).Count > 0);
				if (val28 != null)
				{
					((IWebElement)GetParent(((IEnumerable<T4>)val27).First())).Click();
				}
				Thread.Sleep(1500);
				break;
			}
		}
		T0 val29 = (T0)(((RemoteWebDriver)chrome).PageSource.Contains("Now you can find Privacy") || ((RemoteWebDriver)chrome).PageSource.Contains("Have ideas or spot an issue"));
		if (val29 != null)
		{
			T2 val30 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("span"));
			T3 val31 = (T3)(((ReadOnlyCollection<IWebElement>)val30).Count - 1);
			while (true)
			{
				T0 val32 = (T0)((nint)val31 >= 0);
				if (val32 == null)
				{
					break;
				}
				T0 val33 = (T0)(((ReadOnlyCollection<IWebElement>)val30)[(int)val31].Enabled && ((ReadOnlyCollection<IWebElement>)val30)[(int)val31].Displayed && (((ReadOnlyCollection<IWebElement>)val30)[(int)val31].Text.Contains("Now you can find Privacy") || ((ReadOnlyCollection<IWebElement>)val30)[(int)val31].Text.Contains("Have ideas or spot an issue")));
				if (val33 == null)
				{
					val31 = (T3)(val31 - 1);
					continue;
				}
				T4 e3 = (T4)((ReadOnlyCollection<IWebElement>)val30)[(int)val31];
				T4 parent3 = GetParent(GetParent(e3));
				T2 val34 = (T2)((ISearchContext)parent3).FindElements(By.TagName("i"));
				T0 val35 = (T0)(((ReadOnlyCollection<IWebElement>)val34).Count > 0);
				if (val35 != null)
				{
					((IWebElement)GetParent(((IEnumerable<T4>)val34).First())).Click();
				}
				Thread.Sleep(1500);
				break;
			}
		}
		Chap_nhan_dieu_khoan_camp<T1>();
		if (Lấy_Token_EAAB != null)
		{
			T0 val36 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business"));
			if (val36 != null)
			{
				goUrl<T3, T0, T2, T4, T5, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			getToken_Fetch<T0, T1, T10, T11, T3, T12, T13, T5>((T1)"EAAB", (T1)ResouceControl.getResouce("RESOUCE_BM_CAMPAIGNS"));
		}
		if (Lấy_Token_EAAG != null)
		{
			T0 val37 = (T0)(!((RemoteWebDriver)chrome).Url.Contains("business"));
			if (val37 != null)
			{
				goUrl<T3, T0, T2, T4, T5, T1>((T1)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			getToken_EEAG_Fetch<T0, T14, T1, T10, T11, T3, T12, T13, T5>();
		}
		try
		{
			T1 val38 = (T1)"";
			T6 enumerator = (T6)((RemoteWebDriver)chrome).Manage().Cookies.AllCookies.GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					T7 current = (T7)((IEnumerator<Cookie>)enumerator).Current;
					val38 = (T1)((string)val38 + $"{((Cookie)current).Name}={((Cookie)current).Value};");
				}
			}
			finally
			{
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			frmMain.listFBEntity[indexEntity].Cookie = (string)val38;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
		T0 val39 = (T0)(((RemoteWebDriver)chrome).Manage().Cookies.GetCookieNamed("i_user") != null);
		if (val39 != null)
		{
			((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookieNamed("i_user");
		}
		isLogined = true;
		bat_che_do_chuyen_nghiep<T14, T1, T0>();
		if (Cập_nhật_nhóm != null)
		{
			Cập_nhật_nhóm_mth<T0, T1, List<GroupFBEntity>, T3, T5, T8, T9>();
		}
		if (Cập_nhật_page != null)
		{
			Cập_nhật_page_mth<T0, T3, T1, List<facebook_pagesData>, List<facebook_pagesData>.Enumerator, T5, T14>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void Cập_nhật_page_mth<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0014: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00bf: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG);
			if (val2 == null)
			{
				T1 val3 = (T1)0;
				T1 val4 = (T1)0;
				T2 strError = (T2)"";
				T3 val5 = mtLoadPage<T3, T2, T0, T5, T6>(out *(string*)(&strError));
				T4 enumerator = (T4)((List<facebook_pagesData>)val5).GetEnumerator();
				try
				{
					while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
					{
						facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
						T0 val6 = (T0)string.IsNullOrWhiteSpace(current.additional_profile_id);
						if (val6 != null)
						{
							val4 = (T1)(val4 + 1);
						}
						else
						{
							val3 = (T1)(val3 + 1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
				}
				setMessage((T2)$"Pro5: {val3} Classic: {val4}", (T0)1);
				frmMain.SetCellText<T0, T1, T2>((T1)indexEntity, (T2)"Page", (T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((object)val4 + (object)val3)).ToString());
			}
			else
			{
				setMessage((T2)"Thiếu token EAAG", (T0)1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Cập_nhật_nhóm_mth<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = executeScript<T1, T5, T3, T0, T6>((T1)"return require([\"CurrentUserInitialData\"]).USER_ID;");
			T1 resouce = (T1)ResouceControl.getResouce("Fetch_Get_Group");
			T1 val3 = executeScript<T1, T5, T3, T0, T6>((T1)(((object)resouce) ?? ((object)"")));
			T2 val4 = (T2)Activator.CreateInstance(typeof(T2));
			val4 = JsonConvert.DeserializeObject<T2>((string)val3);
			T1 path = (T1)$"GroupFB\\{val2}.json";
			try
			{
				File.WriteAllText((string)path, JsonConvert.SerializeObject((object)val4));
				frmMain.SetCellText<T0, T3, T1>((T3)indexEntity, (T1)"Group", (T1)System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)((List<GroupFBEntity>)val4).Count).ToString());
				frmMain.SetCellText<T0, T3, T1>((T3)indexEntity, (T1)"GroupUId", val2);
			}
			catch (Exception ex)
			{
				frmMain.errorMessage((T1)ex.Message);
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void changeLanguageFetch<T0, T1, T2, T3, T4, T5>()
	{
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		((Dictionary<string, string>)val).Add("__user", "");
		((Dictionary<string, string>)val).Add("__a", "");
		((Dictionary<string, string>)val).Add("__dyn", "");
		((Dictionary<string, string>)val).Add("__req", "");
		((Dictionary<string, string>)val).Add("dpr", "");
		((Dictionary<string, string>)val).Add("__rev", "");
		((Dictionary<string, string>)val).Add("__s", "");
		((Dictionary<string, string>)val).Add("__hsi", "");
		((Dictionary<string, string>)val).Add("fb_dtsg", "");
		((Dictionary<string, string>)val).Add("jazoest", "");
		((Dictionary<string, string>)val).Add("__spin_r", "");
		((Dictionary<string, string>)val).Add("__spin_t", "");
		val = GetFetchData<T1, T3, T4, KeyValuePair<string, string>, T0, T2, T5, char>(val);
		T1 script = (T1)string.Concat((string[])(object)new T1[25]
		{
			(T1)"fetch(\"https://www.facebook.com/intl/ajax/save_locale/\", {\"headers\":{\"accept\":\"*/*\",\"accept-language\":\"en-US,en;q=0.9\",\"content-type\":\"application/x-www-form-urlencoded\",\"sec-fetch-dest\":\"empty\",\"sec-fetch-mode\":\"cors\",\"sec-fetch-site\":\"same-origin\",\"viewport-width\":\"1365\"},\"referrer\":\"https://www.facebook.com/\",\"referrerPolicy\":\"origin-when-cross-origin\",\"body\":\"loc=en_US&ref=www_card_selector&should_redirect=false&__user=",
			(T1)((Dictionary<string, string>)val)["__user"],
			(T1)"&__a=",
			(T1)((Dictionary<string, string>)val)["__a"],
			(T1)"&__dyn=",
			(T1)((Dictionary<string, string>)val)["__dyn"],
			(T1)"&__csr=&__req=",
			(T1)((Dictionary<string, string>)val)["__req"],
			(T1)"&__beoa=0&__pc=PHASED%3ADEFAULT&dpr=",
			(T1)((Dictionary<string, string>)val)["dpr"],
			(T1)"&__ccg=MODERATE&__rev=",
			(T1)((Dictionary<string, string>)val)["__rev"],
			(T1)"&__s=",
			(T1)((Dictionary<string, string>)val)["__s"],
			(T1)"&__hsi=",
			(T1)((Dictionary<string, string>)val)["__hsi"],
			(T1)"&__comet_req=0&fb_dtsg=",
			(T1)((Dictionary<string, string>)val)["fb_dtsg"],
			(T1)"&jazoest=",
			(T1)((Dictionary<string, string>)val)["jazoest"],
			(T1)"&__spin_r=",
			(T1)((Dictionary<string, string>)val)["__spin_r"],
			(T1)"&__spin_b=trunk&__spin_t=",
			(T1)((Dictionary<string, string>)val)["__spin_t"],
			(T1)"\",\"method\":\"POST\",\"mode\":\"cors\",\"credentials\":\"include\"});"
		});
		executeScript<T1, T2, T3, T4, T5>(script);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void checkSuccess<T0, T1, T2, T3, T4, T5>()
	{
		//IL_0014: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)0;
			while (true)
			{
				T0 val3 = (T0)frmMain.isRunning;
				if (val3 != null)
				{
					T1 val4 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("checkpointSubmitButton"));
					T1 val5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("title_dialog_0"));
					T0 val6 = (T0)((val4 != null && ((ReadOnlyCollection<IWebElement>)val4).Count > 0 && ((IWebElement)((IEnumerable<T5>)val4).First()).Displayed && ((IWebElement)((IEnumerable<T5>)val4).First()).Enabled) || (val5 != null && ((ReadOnlyCollection<IWebElement>)val5).Count > 0 && ((IWebElement)((IEnumerable<T5>)val5).First()).Displayed && ((IWebElement)((IEnumerable<T5>)val5).First()).Enabled));
					if (val6 == null)
					{
						T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("li"));
						T2 source2 = (T2)((IEnumerable<T5>)source).Where((Func<T5, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T5 a) => (T0)(((IWebElement)a).GetAttribute("data-testid") != null && ((IWebElement)a).GetAttribute("data-testid").Equals("payment_method_0")))).ToList();
						T1 source3 = (T1)((ISearchContext)((IEnumerable<T5>)source2).First()).FindElements(By.TagName("div"));
						T3 source4 = (T3)((IEnumerable<T5>)source3).Where((Func<T5, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T5 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("style") != null && ((IWebElement)a).GetAttribute("style").Contains("font-family"))));
						T1 val7 = (T1)((ISearchContext)((IEnumerable<T5>)source4).First()).FindElements(By.TagName("span"));
						T0 val8 = (T0)(val7 != null && ((ReadOnlyCollection<IWebElement>)val7).Count > 0);
						if (val8 == null)
						{
							countCheckSuccess++;
							T0 val9 = (T0)(countCheckSuccess >= 10);
							if (val9 == null)
							{
								Thread.Sleep(1000);
								continue;
							}
							val2 = (T0)0;
							break;
						}
						val2 = (T0)1;
						break;
					}
					val2 = (T0)0;
					break;
				}
				break;
			}
			T0 val10 = val2;
			if (val10 == null)
			{
				updateStatus("lỗi", (T0)1);
			}
		}
		catch (Exception ex)
		{
			countCheckSuccess++;
			T0 val11 = (T0)(countCheckSuccess >= 10);
			if (val11 != null)
			{
				updateStatus("lỗi", (T0)1);
				return;
			}
			Console.WriteLine(ex.Message);
			Thread.Sleep(2000);
			checkSuccess<T0, T1, T2, T3, T4, T5>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Click_Add_People<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			try
			{
				T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("pagelet_bizbar_megamenu"));
				T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
				if (val3 != null)
				{
					T3 val4 = (T3)chrome;
					((IJavaScriptExecutor)val4).ExecuteScript("arguments[0].parentNode.removeChild(arguments[0]);", (object[])(object)new T8[1] { (T8)((IEnumerable<T6>)val2).First() });
				}
			}
			catch (Exception)
			{
			}
			try
			{
				T1 val5 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("pagelet_dock"));
				T0 val6 = (T0)(val5 != null && ((ReadOnlyCollection<IWebElement>)val5).Count > 0);
				if (val6 != null)
				{
					T3 val7 = (T3)chrome;
					((IJavaScriptExecutor)val7).ExecuteScript("arguments[0].parentNode.removeChild(arguments[0]);", (object[])(object)new T8[1] { (T8)((IEnumerable<T6>)val5).First() });
				}
			}
			catch (Exception)
			{
			}
			T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("a"));
			T2 val8 = (T2)((IEnumerable<T6>)source).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("href") != null && ((IWebElement)a).GetAttribute("href").Contains("add_cm_open")))).ToList();
			T0 val9 = (T0)(val8 != null && ((List<IWebElement>)val8).Count > 0);
			if (val9 != null)
			{
				T4 val10 = (T4)"";
				T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
				T2 source3 = (T2)((IEnumerable<T6>)source2).Where((Func<T6, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T6 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("data-testid") != null && ((IWebElement)a).GetAttribute("data-testid").Equals("big-ad-account-selector")))).ToList();
				T1 val11 = (T1)((ISearchContext)((IEnumerable<T6>)source3).First()).FindElements(By.TagName("span"));
				T5 enumerator = (T5)((ReadOnlyCollection<IWebElement>)val11).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						T6 current = (T6)((IEnumerator<IWebElement>)enumerator).Current;
						T0 val12 = (T0)(!string.IsNullOrWhiteSpace(((IWebElement)current).Text));
						if (val12 != null)
						{
							val10 = (T4)((IWebElement)current).Text;
							val10 = (T4)((string)val10).Split((char[])(object)new T9[1] { (T9)40 })[1];
							val10 = (T4)((string)val10).Replace(")", "");
							val10 = (T4)((string)val10).Trim();
							break;
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				focusElement<T3, T7, T6, int, T8>(((IEnumerable<T6>)val8).First(), 500);
				((IWebElement)((IEnumerable<T6>)val8).First()).Click();
				Thread.Sleep(3000);
				Send_Search_Query<T0, T1, T7, T6>();
			}
			else
			{
				Thread.Sleep(3000);
				Click_Add_People<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
			}
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.Message);
			Thread.Sleep(3000);
			Click_Add_People<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Send_Search_Query<T0, T1, T2, T3>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("search_query"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 != null)
			{
				focusElement<IJavaScriptExecutor, T2, T3, int, object>(((IEnumerable<T3>)val2).First(), 500);
				((IWebElement)((IEnumerable<T3>)val2).First()).SendKeys(frmMain.VIA_NAME);
				Choose_VIA<T0, T1, List<IWebElement>, T3, T2>();
			}
			else
			{
				Thread.Sleep(3000);
				Send_Search_Query<T0, T1, T2, T3>();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			Send_Search_Query<T0, T1, T2, T3>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Choose_VIA<T0, T1, T2, T3, T4>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 val2 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("uiContextualLayerPositioner"));
			T0 val3 = (T0)(val2 != null && ((ReadOnlyCollection<IWebElement>)val2).Count > 0);
			if (val3 == null)
			{
				Thread.Sleep(3000);
				Choose_VIA<T0, T1, T2, T3, T4>();
				return;
			}
			T2 source = (T2)((IEnumerable<T3>)val2).Where((Func<T3, bool>)(object)(Func<IWebElement, bool>)((T3 a) => (T0)((IWebElement)a).Displayed)).ToList();
			T1 source2 = (T1)((ISearchContext)((IEnumerable<T3>)source).First()).FindElements(By.TagName("li"));
			focusElement<IJavaScriptExecutor, T4, T3, int, object>(((IEnumerable<T3>)source2).First(), 500);
			((IWebElement)((IEnumerable<T3>)source2).First()).Click();
			Thread.Sleep(300);
			T3 val4 = (T3)((RemoteWebDriver)chrome).FindElement(By.Id("add_user_permission"));
			focusElement<IJavaScriptExecutor, T4, T3, int, object>(val4, 500);
			((IWebElement)val4).Click();
			Choose_Role<T0, T1, T2, T4, T3>();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			Choose_VIA<T0, T1, T2, T3, T4>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Choose_Role<T0, T1, T2, T3, T4>()
	{
		//IL_0014: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("uiContextualLayerBelowLeft"));
			T2 val2 = (T2)((IEnumerable<T4>)source).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)((T4 a) => (T0)((IWebElement)a).Displayed)).ToList();
			T0 val3 = (T0)(val2 != null && ((List<IWebElement>)val2).Count > 0);
			if (val3 == null)
			{
				Thread.Sleep(3000);
				Choose_Role<T0, T1, T2, T3, T4>();
				return;
			}
			T1 source2 = (T1)((ISearchContext)((IEnumerable<T4>)val2).First()).FindElements(By.TagName("li"));
			focusElement<IJavaScriptExecutor, T3, T4, int, object>(((IEnumerable<T4>)source2).First(), 500);
			((IWebElement)((IEnumerable<T4>)source2).First()).Click();
			Thread.Sleep(300);
			T1 source3 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
			T2 source4 = (T2)((IEnumerable<T4>)source3).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T4 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("class") != null && ((IWebElement)a).GetAttribute("class").Contains("layerConfirm")))).ToList();
			focusElement<IJavaScriptExecutor, T3, T4, int, object>(((IEnumerable<T4>)source4).First(), 500);
			((IWebElement)((IEnumerable<T4>)source4).First()).Click();
			Thread.Sleep(2000);
			Check_Add_People_Success<T0, T1, T2, T3, T4, int, string>();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			Choose_Role<T0, T1, T2, T3, T4>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Check_Add_People_Success<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			while (true)
			{
				T0 val2 = (T0)frmMain.isRunning;
				if (val2 == null)
				{
					break;
				}
				T1 source = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("uiOverlayButton"));
				T2 val3 = (T2)((IEnumerable<T4>)source).Where((Func<T4, bool>)(object)(Func<IWebElement, bool>)((T4 a) => (T0)((IWebElement)a).Displayed)).ToList();
				T0 val4 = (T0)(val3 != null && ((List<IWebElement>)val3).Count > 0);
				if (val4 == null)
				{
					Thread.Sleep(2000);
					continue;
				}
				focusElement<IJavaScriptExecutor, T3, T4, T5, object>(((IEnumerable<T4>)val3).First(), (T5)300);
				((IWebElement)((IEnumerable<T4>)val3).First()).Click();
				break;
			}
			goUrl<T5, T0, T1, T4, T3, T6>((T6)ResouceControl.getResouce("RESOUCE_DELETE_ACCOUNT"));
			Click_Button_Delete_Account<T0, T4, T1, T2, T3>();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			Check_Add_People_Success<T0, T1, T2, T3, T4, T5, T6>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Click_Button_Delete_Account<T0, T1, T2, T3, T4>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_00e1: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_01b5: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_0236: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			while (true)
			{
				T0 val2 = (T0)frmMain.isRunning;
				if (val2 == null)
				{
					break;
				}
				T2 source = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("a"));
				T3 val3 = (T3)((IEnumerable<T1>)source).Where((Func<T1, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T1 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("rel") != null && ((IWebElement)a).GetAttribute("rel").Equals("dialog-post")))).ToList();
				T0 val4 = (T0)(val3 != null && ((List<IWebElement>)val3).Count > 0);
				if (val4 == null)
				{
					Thread.Sleep(2000);
					continue;
				}
				focusElement<IJavaScriptExecutor, T4, T1, int, object>(((IEnumerable<T1>)val3).First(), 500);
				((IWebElement)((IEnumerable<T1>)val3).First()).Click();
				Thread.Sleep(2000);
				break;
			}
			T1 val5 = (T1)null;
			while (true)
			{
				T0 val6 = (T0)frmMain.isRunning;
				if (val6 == null)
				{
					break;
				}
				T2 val7 = (T2)((RemoteWebDriver)chrome).FindElements(By.Name("password"));
				T0 val8 = (T0)(val7 != null && ((ReadOnlyCollection<IWebElement>)val7).Count > 0);
				if (val8 == null)
				{
					Thread.Sleep(2000);
					continue;
				}
				val5 = ((IEnumerable<T1>)val7).First();
				break;
			}
			focusElement<IJavaScriptExecutor, T4, T1, int, object>(val5, 500);
			((IWebElement)val5).SendKeys(frmMain.listFBEntity[indexEntity].Password);
			((IWebElement)val5).SendKeys(Keys.Enter);
			Thread.Sleep(2000);
			while (true)
			{
				T0 val9 = (T0)frmMain.isRunning;
				if (val9 != null)
				{
					T2 source2 = (T2)((RemoteWebDriver)chrome).FindElements(By.TagName("button"));
					T3 val10 = (T3)((IEnumerable<T1>)source2).Where((Func<T1, bool>)(object)(Func<IWebElement, bool>)([MethodImpl(MethodImplOptions.NoInlining)] (T1 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).GetAttribute("class") != null && ((IWebElement)a).GetAttribute("class").Contains("layerConfirm")))).ToList();
					T0 val11 = (T0)(val10 != null && ((List<IWebElement>)val10).Count > 0);
					if (val11 == null)
					{
						Thread.Sleep(2000);
						continue;
					}
					focusElement<IJavaScriptExecutor, T4, T1, int, object>(((IEnumerable<T1>)val10).First(), 500);
					((IWebElement)((IEnumerable<T1>)val10).First()).Click();
					break;
				}
				break;
			}
			while (true)
			{
				T0 val12 = (T0)frmMain.isRunning;
				if (val12 == null)
				{
					break;
				}
				T2 val13 = (T2)((RemoteWebDriver)chrome).FindElements(By.Id("email"));
				T0 val14 = (T0)(val13 != null && ((ReadOnlyCollection<IWebElement>)val13).Count > 0);
				if (val14 != null)
				{
					break;
				}
				Thread.Sleep(2000);
			}
			updateStatus(frmMain.STATUS.Done.ToString(), (T0)0);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			Click_Button_Delete_Account<T0, T1, T2, T3, T4>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void updateStatus<T0, T1>(T1 message, T0 islỗi)
	{
		//IL_0009: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		try
		{
			setMessage(message, (T0)0);
			frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Select", (T1)System.Runtime.CompilerServices.Unsafe.As<T0, bool>(ref (T0)0).ToString());
			if (islỗi != null)
			{
				frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Status", (T1)frmMain.STATUS.lỗi.ToString());
				T0 val = (T0)(chrome != null);
				if (val != null)
				{
					try
					{
						((RemoteWebDriver)chrome).Close();
						((RemoteWebDriver)chrome).Quit();
					}
					catch (Exception)
					{
					}
				}
				chrome = null;
			}
			else
			{
				frmMain.SetCellText<T0, int, T1>(indexEntity, (T1)"Status", (T1)frmMain.STATUS.Done.ToString());
			}
		}
		catch (Exception)
		{
			Thread.Sleep(2000);
			T0 val2 = (T0)frmMain.isRunning;
			if (val2 != null)
			{
				updateStatus(message, islỗi);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 requestGet<T0, T1, T2, T3, T4, T5>(T0 url)
	{
		T0 result = (T0)"";
		try
		{
			T1 val = (T1)WebRequest.Create((string)url);
			((WebRequest)val).ContentType = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
			((WebRequest)val).Method = "get";
			((HttpWebRequest)val).UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36";
			T2 cookieContainer = (T2)Activator.CreateInstance(typeof(CookieContainer));
			((HttpWebRequest)val).CookieContainer = (CookieContainer)cookieContainer;
			T3 val2 = (T3)((WebRequest)val).GetResponse();
			T4 val3 = (T4)new StreamReader(((WebResponse)val2).GetResponseStream());
			try
			{
				result = (T0)((TextReader)val3).ReadToEnd();
			}
			finally
			{
				if (val3 != null)
				{
					((IDisposable)val3).Dispose();
				}
			}
		}
		catch (Exception)
		{
			result = (T0)"";
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T2 authenCode<T0, T1, T2, T3, T4, T5>(T2 code)
	{
		//IL_003a: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		try
		{
			code = (T2)((string)code).Replace(" ", "");
			Totp totp = null;
			while (true)
			{
				totp = new Totp((byte[])(object)Base32Encoding.ToBytes<T0, T4, T1, T2, T5>(code));
				T0 val = (T0)totp.RemainingSeconds();
				T1 val2 = (T1)((nint)val >= 3);
				if (val2 != null)
				{
					break;
				}
				Thread.Sleep(1000);
			}
			return (T2)totp.ComputeTotp();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return (T2)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void focusElement<T0, T1, T2, T3, T4>(T2 element, T3 timeToSleep)
	{
		//IL_0025: Expected I4, but got O
		try
		{
			T0 val = (T0)chrome;
			((IJavaScriptExecutor)val).ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", (object[])(object)new T4[1] { (T4)element });
			Thread.Sleep((int)timeToSleep);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 GetParent<T0>(T0 e)
	{
		return (T0)((ISearchContext)e).FindElement(By.XPath(".."));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T4 GetFetchData<T0, T1, T2, T3, T4, T5, T6, T7>(T4 fetchDatas)
	{
		//IL_0044: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_007a: Expected I4, but got O
		//IL_00a2: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d5: Expected O, but got I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e6: Expected O, but got I4
		T0 script = (T0)"var nameLink = '';var perfEntries = performance.getEntries();for (var i = 0; i < perfEntries.length; i++){nameLink += perfEntries[i].name+'&';}return nameLink; ";
		T0 val = executeScript<T0, T5, T1, T2, T6>(script);
		val = (T0)val.ToString().Replace("?", "&");
		T0[] array = (T0[])(object)val.ToString().Split((char[])(object)new T7[1] { (T7)38 });
		T1 val2 = (T1)(array.Length - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			T0 val4 = (T0)((object[])(object)array)[(object)val2];
			T2 val5 = (T2)(!string.IsNullOrEmpty((string)val4) && ((string)val4).Contains("="));
			if (val5 != null)
			{
				T1 val6 = (T1)0;
				while (true)
				{
					T2 val7 = (T2)((nint)val6 < ((Dictionary<string, string>)fetchDatas).Count);
					if (val7 == null)
					{
						break;
					}
					T0 key = (T0)((KeyValuePair<string, string>)((IEnumerable<T3>)fetchDatas).ElementAt((int)val6)).Key;
					T2 val8 = (T2)((string)val4).Split((char[])(object)new T7[1] { (T7)61 })[0].Equals((string)key);
					if (val8 != null)
					{
						((Dictionary<string, string>)fetchDatas)[(string)key] = ((string)((object[])(object)array)[(object)val2]).Split((char[])(object)new T7[1] { (T7)61 })[1];
					}
					val6 = (T1)(val6 + 1);
				}
			}
			val2 = (T1)(val2 - 1);
		}
		return fetchDatas;
	}

	public T0 ConvertToUnsign2<T0, T1, T2, T3, T4>(T0 str)
	{
		//IL_0023: Expected O, but got I4
		//IL_002c: Expected I4, but got O
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_0047: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005c: Expected O, but got I4
		str = (T0)((string)str).ToLower();
		T0 val = (T0)((string)str).Normalize(NormalizationForm.FormD);
		T1 val2 = (T1)Activator.CreateInstance(typeof(StringBuilder));
		T2 val3 = (T2)0;
		while (true)
		{
			T4 val4 = (T4)((nint)val3 < ((string)val).Length);
			if (val4 == null)
			{
				break;
			}
			T3 val5 = (T3)CharUnicodeInfo.GetUnicodeCategory(((string)val)[(int)val3]);
			T4 val6 = (T4)((nint)val5 != 5);
			if (val6 != null)
			{
				((StringBuilder)val2).Append(((string)val)[(int)val3]);
			}
			val3 = (T2)(val3 + 1);
		}
		val2 = (T1)((StringBuilder)val2).Replace('Đ', 'D');
		val2 = (T1)((StringBuilder)val2).Replace('đ', 'd');
		return (T0)val2.ToString().Normalize(NormalizationForm.FormD);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reg_Clone_Facebook<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(FBFlow flow)
	{
		//IL_0014: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_0261: Expected O, but got I4
		//IL_026c: Expected I4, but got O
		//IL_026e: Expected O, but got I4
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_02ba: Expected O, but got I4
		//IL_02c5: Expected I4, but got O
		//IL_02c7: Expected O, but got I4
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_038a: Expected O, but got I4
		//IL_03fd: Expected O, but got I4
		//IL_046a: Expected O, but got I4
		//IL_04e5: Expected O, but got I4
		//IL_04f0: Expected I4, but got O
		//IL_04f2: Expected O, but got I4
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_05ff: Expected O, but got I4
		//IL_060a: Expected I4, but got O
		//IL_060c: Expected O, but got I4
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_065b: Expected O, but got I4
		//IL_06a6: Expected O, but got I4
		//IL_06ae: Expected O, but got I4
		//IL_06d2: Expected O, but got I4
		//IL_06d9: Expected O, but got I4
		//IL_0714: Expected O, but got I4
		//IL_071b: Expected O, but got I4
		//IL_0722: Expected O, but got I4
		//IL_0737: Expected O, but got I4
		//IL_0762: Expected O, but got I4
		//IL_078d: Expected O, but got I4
		//IL_079e: Expected O, but got I4
		//IL_07bb: Expected O, but got I4
		//IL_0829: Expected O, but got I4
		//IL_095d: Expected O, but got I4
		//IL_0992: Expected O, but got I4
		//IL_09c5: Expected O, but got I4
		//IL_09da: Expected O, but got I4
		//IL_0ab5: Expected O, but got I4
		//IL_0ac6: Expected O, but got I4
		//IL_0ad8: Expected O, but got I4
		//IL_0ae7: Expected O, but got I4
		//IL_0b0c: Expected O, but got I4
		//IL_0b37: Expected O, but got I4
		//IL_0b4c: Expected O, but got I4
		T0 val = (T0)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)bool.Parse(flow.getValue<T10, List<FBFlowField>, T0, T3>((T3)"temp-mail.org").ToString());
			T0 val3 = (T0)bool.Parse(flow.getValue<T10, List<FBFlowField>, T0, T3>((T3)"10minutemail.net").ToString());
			T0 val4 = (T0)bool.Parse(flow.getValue<T10, List<FBFlowField>, T0, T3>((T3)"NoVerify").ToString());
			T0 val5 = val2;
			if (val5 == null)
			{
				T0 val6 = val3;
				if (val6 != null)
				{
					executeScript<T3, T5, T6, T0, T10>((T3)"window.open()");
					Thread.Sleep(200);
					((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).Last());
					T3 script = (T3)"function goTemp(){ window.location='https://10minutemail.net';}setTimeout(goTemp, 1500); ";
					executeScript<T3, T5, T6, T0, T10>(script);
					((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).First());
				}
			}
			else
			{
				executeScript<T3, T5, T6, T0, T10>((T3)"window.open()");
				Thread.Sleep(200);
				((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).Last());
				T3 script2 = (T3)"function goTemp(){ window.location='https://temp-mail.org';}setTimeout(goTemp, 1500); ";
				executeScript<T3, T5, T6, T0, T10>(script2);
				((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).First());
			}
			goUrl<T6, T0, T1, T2, T9, T3>((T3)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
			Thread.Sleep(1000);
			T1 val7 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("accept-cookie-banner-label"));
			T0 val8 = (T0)(((ReadOnlyCollection<IWebElement>)val7).Count > 0);
			if (val8 != null)
			{
				((IWebElement)((IEnumerable<T2>)val7).First()).Click();
				Thread.Sleep(1500);
			}
			T2 val9 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("signup-button"));
			((IWebElement)val9).Click();
			Thread.Sleep(1500);
			T1 val10 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']"));
			T0 val11 = (T0)(((ReadOnlyCollection<IWebElement>)val10).Count > 0);
			if (val11 != null)
			{
				T4 source = (T4)((IEnumerable<T2>)val10).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)((T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
				((IWebElement)((IEnumerable<T2>)source).First()).Click();
				Thread.Sleep(1500);
			}
			T2 val12 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("firstname_input"));
			((IWebElement)val12).Click();
			T3 firstName = getFirstName<T0, T3, T6>();
			T3 val13 = firstName;
			T6 val14 = (T6)0;
			while ((nint)val14 < ((string)val13).Length)
			{
				((IWebElement)val12).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T7, char>(ref (T7)((string)val13)[(int)val14]).ToString());
				val14 = (T6)(val14 + 1);
			}
			T2 val15 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("lastname_input"));
			((IWebElement)val15).Click();
			T3 lastName = getLastName<T0, T3, T6>();
			T3 val16 = lastName;
			T6 val17 = (T6)0;
			while ((nint)val17 < ((string)val16).Length)
			{
				((IWebElement)val15).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T7, char>(ref (T7)((string)val16)[(int)val17]).ToString());
				val17 = (T6)(val17 + 1);
			}
			Thread.Sleep(1500);
			val10 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']"));
			((IWebElement)((IEnumerable<T2>)val10).First()).Click();
			Thread.Sleep(1500);
			T2 val18 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("day"));
			((IWebElement)val18).Click();
			Thread.Sleep(500);
			T4 val19 = (T4)((IEnumerable<T2>)((ISearchContext)val18).FindElements(By.TagName("option"))).ToList();
			T2 val20 = (T2)((List<IWebElement>)val19)[rnd.Next(1, ((List<IWebElement>)val19).Count - 1)];
			focusElement<T5, T9, T2, T6, T10>(val20, (T6)500);
			((IWebElement)val20).Click();
			T2 val21 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("month"));
			((IWebElement)val21).Click();
			Thread.Sleep(500);
			val19 = (T4)((IEnumerable<T2>)((ISearchContext)val21).FindElements(By.TagName("option"))).ToList();
			val20 = (T2)((List<IWebElement>)val19)[rnd.Next(1, ((List<IWebElement>)val19).Count - 1)];
			focusElement<T5, T9, T2, T6, T10>(val20, (T6)500);
			((IWebElement)val20).Click();
			T2 val22 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("year"));
			((IWebElement)val22).Click();
			Thread.Sleep(500);
			val19 = (T4)((IEnumerable<T2>)((ISearchContext)val22).FindElements(By.TagName("option"))).ToList();
			val20 = (T2)((List<IWebElement>)val19)[rnd.Next(29, 49)];
			focusElement<T5, T9, T2, T6, T10>(val20, (T6)500);
			((IWebElement)val20).Click();
			val10 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']"));
			((IWebElement)((IEnumerable<T2>)val10).First()).Click();
			Thread.Sleep(1500);
			T2 val23 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("contactpoint_step_input"));
			((IWebElement)val23).Click();
			((IWebElement)val23).Clear();
			T3 uID = (T3)frmMain.listFBEntity[indexEntity].UID;
			T6 val24 = (T6)0;
			while ((nint)val24 < ((string)uID).Length)
			{
				((IWebElement)val23).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T7, char>(ref (T7)((string)uID)[(int)val24]).ToString());
				val24 = (T6)(val24 + 1);
			}
			Thread.Sleep(500);
			val10 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']"));
			((IWebElement)((IEnumerable<T2>)val10).First()).Click();
			Thread.Sleep(1500);
			T1 val25 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("sex"));
			((ReadOnlyCollection<IWebElement>)val25)[rnd.Next(0, ((ReadOnlyCollection<IWebElement>)val25).Count - 1)].Click();
			Thread.Sleep(1500);
			val10 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']"));
			((IWebElement)((IEnumerable<T2>)val10).First()).Click();
			Thread.Sleep(1500);
			T2 val26 = (T2)((RemoteWebDriver)chrome).FindElement(By.Id("password_step_input"));
			((IWebElement)val26).Click();
			((IWebElement)val26).Clear();
			T3 password = (T3)frmMain.listFBEntity[indexEntity].Password;
			T6 val27 = (T6)0;
			while ((nint)val27 < ((string)password).Length)
			{
				((IWebElement)val26).SendKeys(System.Runtime.CompilerServices.Unsafe.As<T7, char>(ref (T7)((string)password)[(int)val27]).ToString());
				val27 = (T6)(val27 + 1);
			}
			Thread.Sleep(500);
			val10 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_next']"));
			T0 val28 = (T0)((IWebElement)((IEnumerable<T2>)val10).First()).Displayed;
			if (val28 != null)
			{
				((IWebElement)((IEnumerable<T2>)val10).First()).Click();
				Thread.Sleep(1500);
			}
			T1 source2 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable multi_step_submit']"));
			((IWebElement)((IEnumerable<T2>)source2).First()).Click();
			Thread.Sleep(1500);
			T0 val29 = (T0)1;
			while (true)
			{
				T0 val30 = (T0)frmMain.isRunning;
				if (val30 == null)
				{
					break;
				}
				val29 = (T0)1;
				T1 val31 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//div[@data-sigil='m-loading-indicator-animate m-loading-indicator-root']"));
				T0 val32 = (T0)(((ReadOnlyCollection<IWebElement>)val31).Count > 0);
				if (val32 == null)
				{
					val29 = (T0)0;
				}
				else
				{
					T4 val33 = (T4)((IEnumerable<T2>)val31).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)((T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
					T0 val34 = (T0)(((List<IWebElement>)val33).Count == 0);
					if (val34 != null)
					{
						val29 = (T0)0;
					}
				}
				T0 val35 = (T0)(val29 == null);
				if (val35 != null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T1 val36 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("reg_email___error"));
			T0 val37 = (T0)(((ReadOnlyCollection<IWebElement>)val36).Count > 0);
			if (val37 == null)
			{
				T1 val38 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("action_proceed"));
				T0 val39 = (T0)(((ReadOnlyCollection<IWebElement>)val38).Count > 0);
				if (val39 != null)
				{
					updateStatus((T3)"checkpoint", (T0)1);
					return;
				}
				T0 val40 = (T0)((RemoteWebDriver)chrome).Url.Contains("error");
				if (val40 == null)
				{
					T0 val41 = val2;
					if (val41 != null)
					{
						((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).Last());
						T1 val42 = (T1)((RemoteWebDriver)chrome).FindElements(By.Id("mail"));
						T0 val43 = (T0)(((ReadOnlyCollection<IWebElement>)val42).Count > 0 && ((IWebElement)((IEnumerable<T2>)val42).First()).GetAttribute("value") != null);
						if (val43 != null)
						{
							T3 attribute = (T3)((IWebElement)((IEnumerable<T2>)val42).First()).GetAttribute("value");
							((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).First());
							goUrl<T6, T0, T1, T2, T9, T3>((T3)"https://m.facebook.com/changeemail/");
							T1 source3 = (T1)((RemoteWebDriver)chrome).FindElements(By.Name("new"));
							((IWebElement)((IEnumerable<T2>)source3).First()).SendKeys((string)attribute);
							T1 source4 = (T1)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable']"));
							T4 source5 = (T4)((IEnumerable<T2>)source4).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)((T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
							((IWebElement)((IEnumerable<T2>)source5).First()).Click();
							Thread.Sleep(1500);
							((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).Last());
							T3 val44 = (T3)"";
							while (true)
							{
								T0 val45 = (T0)frmMain.isRunning;
								if (val45 == null)
								{
									break;
								}
								T1 val46 = (T1)((RemoteWebDriver)chrome).FindElements(By.ClassName("inboxSubject"));
								T8 enumerator = (T8)((ReadOnlyCollection<IWebElement>)val46).GetEnumerator();
								try
								{
									while (((IEnumerator)enumerator).MoveNext())
									{
										T2 current = (T2)((IEnumerator<IWebElement>)enumerator).Current;
										T0 val47 = (T0)(!string.IsNullOrWhiteSpace(((IWebElement)current).Text));
										if (val47 != null)
										{
											val44 = (T3)Regex.Match(((IWebElement)current).Text, "\\d+").Value;
											T0 val48 = (T0)(!string.IsNullOrWhiteSpace((string)val44) && ((string)val44).Length > 4);
											if (val48 != null)
											{
												break;
											}
										}
									}
								}
								finally
								{
									if (enumerator != null)
									{
										((IDisposable)enumerator).Dispose();
									}
								}
								T0 val49 = (T0)(!string.IsNullOrWhiteSpace((string)val44) && ((string)val44).Length > 4);
								if (val49 != null)
								{
									break;
								}
								Thread.Sleep(1500);
							}
							((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T3>)((RemoteWebDriver)chrome).WindowHandles).First());
							T1 source6 = (T1)((RemoteWebDriver)chrome).FindElements(By.TagName("form"));
							T4 source7 = (T4)((IEnumerable<T2>)source6).Where((Func<T2, bool>)(object)(Func<IWebElement, bool>)((T2 a) => (T0)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
							T1 source8 = (T1)((ISearchContext)((IEnumerable<T2>)source7).First()).FindElements(By.TagName("input"));
							((IWebElement)((IEnumerable<T2>)source8).First()).SendKeys((string)val44);
							T1 source9 = (T1)((ISearchContext)((IEnumerable<T2>)source7).First()).FindElements(By.TagName("a"));
							((IWebElement)((IEnumerable<T2>)source9).First()).Click();
							Thread.Sleep(3000);
							T0 val50 = (T0)((RemoteWebDriver)chrome).Url.Contains("checkpoint");
							if (val50 == null)
							{
								updateStatus((T3)"Ok", (T0)0);
							}
							else
							{
								updateStatus((T3)"checkpoint", (T0)1);
							}
						}
						else
						{
							updateStatus((T3)"temp_mail_org: Không có mail temp", (T0)0);
						}
						return;
					}
					T0 val51 = val3;
					if (val51 != null)
					{
						mthTenminutemail_net<T1, T0, T3, T4, IEnumerator<Cookie>, Cookie, T9, T2, T6>();
						return;
					}
					T0 val52 = val4;
					if (val52 != null)
					{
						updateStatus((T3)"Ok", (T0)0);
					}
				}
				else
				{
					updateStatus((T3)((IWebElement)((IEnumerable<T2>)((RemoteWebDriver)chrome).FindElements(By.TagName("body"))).First()).Text, (T0)1);
				}
			}
			else
			{
				updateStatus((T3)((IWebElement)((IEnumerable<T2>)val36).First()).Text, (T0)1);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void mthTenminutemail_net<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
	{
		//IL_0014: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_0188: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_01c8: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_02de: Expected O, but got I4
		//IL_0318: Expected O, but got I4
		//IL_032d: Expected O, but got I4
		//IL_0405: Expected O, but got I4
		//IL_0416: Expected O, but got I4
		//IL_0425: Expected O, but got I4
		//IL_0434: Expected O, but got I4
		//IL_0443: Expected O, but got I4
		T1 val = (T1)(!frmMain.isRunning || chrome == null);
		if (val != null)
		{
			return;
		}
		((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T2>)((RemoteWebDriver)chrome).WindowHandles).Last());
		T0 val2 = (T0)((RemoteWebDriver)chrome).FindElements(By.Id("span_mail"));
		T1 val3 = (T1)(((ReadOnlyCollection<IWebElement>)val2).Count > 0 && !string.IsNullOrWhiteSpace(((IWebElement)((IEnumerable<T7>)val2).First()).Text));
		if (val3 != null)
		{
			T2 text = (T2)((IWebElement)((IEnumerable<T7>)val2).First()).Text;
			((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T2>)((RemoteWebDriver)chrome).WindowHandles).First());
			goUrl<T8, T1, T0, T7, T6, T2>((T2)"https://m.facebook.com/changeemail/");
			T0 source = (T0)((RemoteWebDriver)chrome).FindElements(By.Name("new"));
			((IWebElement)((IEnumerable<T7>)source).First()).SendKeys((string)text);
			T0 source2 = (T0)((RemoteWebDriver)chrome).FindElements(By.XPath("//button[@data-sigil='touchable']"));
			T3 source3 = (T3)((IEnumerable<T7>)source2).Where((Func<T7, bool>)(object)(Func<IWebElement, bool>)((T7 a) => (T1)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
			((IWebElement)((IEnumerable<T7>)source3).First()).Click();
			Thread.Sleep(1500);
			T1 val4 = (T1)0;
			while (true)
			{
				T1 val5 = (T1)frmMain.isRunning;
				if (val5 == null)
				{
					break;
				}
				T0 val6 = (T0)((RemoteWebDriver)chrome).FindElements(By.XPath("//input[@type='number']"));
				T1 val7 = (T1)(((ReadOnlyCollection<IWebElement>)val6).Count > 0 && ((IWebElement)((IEnumerable<T7>)val6).First()).Displayed);
				if (val7 != null)
				{
					break;
				}
				T1 val8 = (T1)((RemoteWebDriver)chrome).Url.Contains("next&error");
				if (val8 == null)
				{
					T1 val9 = (T1)((RemoteWebDriver)chrome).Url.Contains("checkpoint");
					if (val9 == null)
					{
						Thread.Sleep(1500);
						continue;
					}
					val4 = (T1)1;
					break;
				}
				((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T2>)((RemoteWebDriver)chrome).WindowHandles).Last());
				T4 enumerator = (T4)((RemoteWebDriver)chrome).Manage().Cookies.AllCookies.GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						T5 current = (T5)((IEnumerator<Cookie>)enumerator).Current;
						try
						{
							T1 val10 = (T1)((Cookie)current).Domain.Contains("10minutemail.net");
							if (val10 != null)
							{
								((RemoteWebDriver)chrome).Manage().Cookies.DeleteCookie((Cookie)current);
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				goUrl<T8, T1, T0, T7, T6, T2>((T2)"https://10minutemail.net/");
				mthTenminutemail_net<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
				return;
			}
			T1 val11 = val4;
			if (val11 == null)
			{
				((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T2>)((RemoteWebDriver)chrome).WindowHandles).Last());
				T2 val12 = (T2)"";
				while (true)
				{
					T1 val13 = (T1)frmMain.isRunning;
					if (val13 == null)
					{
						break;
					}
					T0 val14 = (T0)((RemoteWebDriver)chrome).FindElements(By.Id("maillist"));
					T1 val15 = (T1)(((ReadOnlyCollection<IWebElement>)val14).Count > 0);
					if (val15 != null)
					{
						val12 = (T2)Regex.Match(((IWebElement)((IEnumerable<T7>)val14).First()).Text, "\\d+").Value;
					}
					T1 val16 = (T1)(!string.IsNullOrWhiteSpace((string)val12) && ((string)val12).Length > 4);
					if (val16 != null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				((RemoteWebDriver)chrome).SwitchTo().Window((string)((IEnumerable<T2>)((RemoteWebDriver)chrome).WindowHandles).First());
				T0 source4 = (T0)((RemoteWebDriver)chrome).FindElements(By.TagName("form"));
				T3 source5 = (T3)((IEnumerable<T7>)source4).Where((Func<T7, bool>)(object)(Func<IWebElement, bool>)((T7 a) => (T1)(((IWebElement)a).Displayed && ((IWebElement)a).Enabled))).ToList();
				T0 source6 = (T0)((ISearchContext)((IEnumerable<T7>)source5).First()).FindElements(By.TagName("input"));
				((IWebElement)((IEnumerable<T7>)source6).First()).SendKeys((string)val12);
				T0 source7 = (T0)((ISearchContext)((IEnumerable<T7>)source5).First()).FindElements(By.TagName("a"));
				((IWebElement)((IEnumerable<T7>)source7).First()).Click();
				Thread.Sleep(3000);
				T1 val17 = (T1)((RemoteWebDriver)chrome).Url.Contains("checkpoint");
				if (val17 != null)
				{
					updateStatus((T2)"checkpoint", (T1)1);
				}
				else
				{
					updateStatus((T2)"Ok", (T1)0);
				}
			}
			else
			{
				updateStatus((T2)"checkpoint", (T1)1);
			}
		}
		else
		{
			updateStatus((T2)"tenminutemail_net: Không có mail temp", (T1)0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 ads_geo_coding<T0, T1, T2, T3, T4, T5, T6>(T2 strAddress, T2 strCity, out string latitude, out string longitude, out string normalized_address)
	{
		//IL_0002: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		T0 result = (T0)0;
		latitude = "";
		longitude = "";
		normalized_address = "";
		try
		{
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			strAddress = (T2)HttpUtility.UrlEncode((string)strAddress);
			((Dictionary<string, string>)val).Add("strAddress", (string)strAddress);
			((Dictionary<string, string>)val).Add("strToken", frmMain.listFBEntity[indexEntity].TokenEAAG);
			((Dictionary<string, string>)val).Add("strCity", (string)strCity);
			T2 resouce = (T2)ResouceControl.getResouce("ads_geo_coding", (Dictionary<string, string>)val);
			T2 val2 = executeScript<T2, T4, T5, T0, T6>(resouce);
			T0 val3 = (T0)((string)val2).Contains("latitude");
			if (val3 != null)
			{
				latitude = Regex.Match((string)val2, "latitude\":(.*?),").Groups[1].Value;
				longitude = Regex.Match((string)val2, "longitude\":(.*?),").Groups[1].Value;
				normalized_address = Regex.Match((string)val2, "normalized_address\":\"(.*?)\"").Groups[1].Value;
				result = (T0)1;
			}
		}
		catch (Exception)
		{
			result = (T0)0;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 mtLoadGroup<T0, T1, T2, T3, T4>(out string strError)
	{
		//IL_0064: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		strError = "";
		try
		{
			T1 url = (T1)("https://graph.facebook.com/me/groups?limit=500&fields=id,name,member_count,privacy,updated_time&access_token=" + frmMain.listFBEntity[indexEntity].TokenEAAG);
			T1 val2 = fetch_url_business<T4, T1, T3>(url);
			url = (T1)"";
			GroupsEntity groupsEntity = JsonConvert.DeserializeObject<GroupsEntity>((string)val2);
			T2 val3 = (T2)(groupsEntity != null && groupsEntity.data != null);
			if (val3 != null)
			{
				T2 val4 = (T2)(groupsEntity.data != null);
				if (val4 != null)
				{
					((List<GroupsEntity_Data>)val).AddRange((IEnumerable<GroupsEntity_Data>)groupsEntity.data);
				}
				T2 val5 = (T2)(groupsEntity.paging != null && !string.IsNullOrWhiteSpace(groupsEntity.paging.next));
				if (val5 != null)
				{
					url = (T1)groupsEntity.paging.next;
				}
			}
			while (true)
			{
				T2 val6 = (T2)frmMain.isRunning;
				if (val6 != null)
				{
					T2 val7 = (T2)(!string.IsNullOrWhiteSpace((string)url));
					if (val7 != null)
					{
						val2 = fetch_url_business<T4, T1, T3>(url);
						url = (T1)"";
						groupsEntity = JsonConvert.DeserializeObject<GroupsEntity>((string)val2);
						T2 val8 = (T2)(groupsEntity.data != null);
						if (val8 != null)
						{
							((List<GroupsEntity_Data>)val).AddRange((IEnumerable<GroupsEntity_Data>)groupsEntity.data);
						}
						T2 val9 = (T2)(groupsEntity.paging != null && !string.IsNullOrWhiteSpace(groupsEntity.paging.next));
						if (val9 != null)
						{
							url = (T1)groupsEntity.paging.next;
						}
						continue;
					}
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			strError = ex.Message;
		}
		return val;
	}
}
