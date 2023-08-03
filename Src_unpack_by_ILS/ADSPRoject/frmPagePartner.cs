using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.Server;
using Newtonsoft.Json;
using xNet;

namespace ADSPRoject;

public class frmPagePartner : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public frmPagePartner _003C_003E4__this;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__0;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CevictionPartner_003Eb__0<T0, T1, T2, T3, T4, T5>(T5 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_00b9: Expected I4, but got O
			//IL_0168: Expected O, but got I4
			//IL_016e: Expected O, but got I4
			//IL_017c: Expected O, but got I4
			//IL_0194: Expected I4, but got O
			//IL_01b7: Expected I4, but got O
			//IL_01e4: Expected I4, but got O
			//IL_0201: Expected O, but got I4
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			T1 val2 = (T1)0;
			try
			{
				T2 val3 = (T2)Activator.CreateInstance(typeof(HttpRequest));
				((HttpRequest)val3).SslProtocols = SslProtocols.Tls12;
				((HttpRequest)val3).SetCookie(frmMain.setting.pagePartner.Cookie, true);
				T3 val4 = (T3)string.Concat((string[])(object)new T3[13]
				{
					(T3)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=path%3A%2F",
					(T3)frmMain.setting.pagePartner.Page_ID,
					(T3)"%2Fagencies&_reqSrc=adsDaoGraphDataMutator&acting_brand_id=",
					(T3)frmMain.setting.pagePartner.BM_ID,
					(T3)"&brandID=",
					(T3)frmMain.setting.pagePartner.BM_ID,
					(T3)"&business=",
					(T3)_003C_003E4__this.partner.data[(int)val].id,
					(T3)"&endpoint=%2F",
					(T3)frmMain.setting.pagePartner.Page_ID,
					(T3)"%2Fagencies&locale=vi_VN&method=delete&pageId=",
					(T3)frmMain.setting.pagePartner.Page_ID,
					(T3)"&pretty=0&suppress_http_code=1&version=14.0&xref=fc4ce2cbe174"
				});
				T3 val5 = (T3)((object)((HttpRequest)val3).Post("https://graph.facebook.com/v14.0/" + frmMain.setting.pagePartner.Page_ID + "/agencies?access_token=" + frmMain.setting.pagePartner.Token, string.Concat((string[])(object)new T3[1] { val4 }), "application/x-www-form-urlencoded")).ToString();
				T1 val6 = (T1)((string)val5).Contains("success\":true");
				if (val6 != null)
				{
					val2 = (T1)1;
				}
				else
				{
					Console.WriteLine((string)val5);
				}
			}
			catch (Exception)
			{
				val2 = (T1)0;
			}
			_003C_003E4__this.partner.data[(int)val].select = false;
			T1 val7 = val2;
			if (val7 == null)
			{
				_003C_003E4__this.partner.data[(int)val].Message = frmMain.STATUS.lỗi.ToString();
			}
			else
			{
				_003C_003E4__this.partner.data[(int)val].Message = frmMain.STATUS.Done.ToString();
			}
			T0 val8 = (T0)countThread;
			countThread = val8 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public frmPagePartner _003C_003E4__this;

		public int countThread;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public int iAds;

		public _003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CassignPartner_003Eb__0<T0, T1, T2, T3, T4, T5>(T5 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_0010: Expected O, but got I4
			//IL_014a: Expected O, but got I4
			//IL_0150: Expected O, but got I4
			//IL_0154: Expected O, but got I4
			//IL_0159: Expected O, but got I4
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0165: Expected O, but got I4
			//IL_0174: Expected O, but got I4
			//IL_017c: Expected O, but got I4
			//IL_0192: Expected I4, but got O
			//IL_01ad: Expected O, but got I4
			//IL_01c7: Expected I4, but got O
			//IL_01f4: Expected I4, but got O
			//IL_022c: Expected I4, but got O
			//IL_024e: Expected O, but got I4
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			T1 val2 = (T1)0;
			T0 val3 = (T0)0;
			T2 val4 = (T2)"";
			while (true)
			{
				try
				{
					T3 val5 = (T3)Activator.CreateInstance(typeof(HttpRequest));
					((HttpRequest)val5).SslProtocols = SslProtocols.Tls12;
					((HttpRequest)val5).SetCookie(frmMain.setting.pagePartner.Cookie.Replace(" ", ""), true);
					T2 val6 = (T2)(ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13") + frmMain.setting.pagePartner.Page_ID + "/agencies?access_token=" + frmMain.setting.pagePartner.Token);
					val4 = (T2)((object)((HttpRequest)val5).Post((string)val6, string.Concat((string[])(object)new T2[1] { (T2)string.Concat((string[])(object)new T2[7]
					{
						(T2)"__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Apage%2Fagencies&_reqSrc=BrandAgencyActions.brands&acting_brand_id=",
						(T2)frmMain.setting.pagePartner.BM_ID,
						(T2)"&business=",
						(T2)CS_0024_003C_003E8__locals1._003C_003E4__this.listBM_IDList[iAds].Id,
						(T2)"&locale=vi_VN&method=post&pageId=",
						(T2)frmMain.setting.pagePartner.Page_ID,
						(T2)"&permitted_tasks=%5B%22CREATE_CONTENT%22%2C%22MODERATE%22%2C%22MESSAGING%22%2C%22ADVERTISE%22%2C%22ANALYZE%22%2C%22MANAGE%22%2C%22VIEW_MONETIZATION_INSIGHTS%22%5D&pretty=0&suppress_http_code=1&xref=f1f8d90ca2dedf"
					}) }), "application/x-www-form-urlencoded")).ToString();
					T1 val7 = (T1)(((string)val4).Contains("success\":true") || ((string)val4).Contains("1690131"));
					val2 = ((val7 == null) ? ((T1)0) : ((T1)1));
				}
				catch (Exception)
				{
					val2 = (T1)0;
				}
				T1 val8 = (T1)(val2 == null);
				if (val8 == null)
				{
					break;
				}
				val3 = (T0)(val3 + 1);
				T1 val9 = (T1)((nint)val3 < 5);
				if (val9 != null)
				{
					continue;
				}
				val2 = (T1)0;
				break;
			}
			CS_0024_003C_003E8__locals1._003C_003E4__this.listBM_IDList[(int)val].select = false;
			T1 val10 = val2;
			if (val10 == null)
			{
				T1 val11 = (T1)((string)val4).Contains("code\":368");
				if (val11 == null)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.listBM_IDList[(int)val].Message = frmMain.STATUS.lỗi.ToString();
				}
				else
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.listBM_IDList[(int)val].Message = frmMain.STATUS.lỗi.ToString() + "-spam";
				}
			}
			else
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.listBM_IDList[(int)val].Message = frmMain.STATUS.Done.ToString();
			}
			T0 val12 = (T0)CS_0024_003C_003E8__locals1.countThread;
			CS_0024_003C_003E8__locals1.countThread = val12 - 1;
		}
	}

	private List<BM_Partner> listBM_IDList = (List<BM_Partner>)Activator.CreateInstance(typeof(List<BM_Partner>));

	private frmMain frm;

	private PagePartner_Current partner;

	private bool isEvictionRunning = false;

	private bool isAssignRunning = false;

	private IContainer components = null;

	private Label label1;

	private TextBox txtCookieToken;

	private TextBox txtBMID;

	private Label label2;

	private TextBox txtPageID;

	private Label label3;

	private DataGridView gvBMList;

	private Label label4;

	private NumericUpDown numThreadAssign;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private DataGridView gvPartnerCurrent;

	private Button btnEviction;

	private NumericUpDown numThreadEviction;

	private Label label5;

	private TabPage tabPage2;

	private Button button3;

	private Label lbTotalTab1;

	private Label lbTotalTab2;

	private Label lbPartnerCurrent;

	private Label lbBMList;

	private System.Windows.Forms.Timer timer_eviction_start;

	private Button btnAssign;

	private System.Windows.Forms.Timer timer_assign_start;

	private Button button1;

	private TextBox txtAssignPartnerSearch;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmPagePartner(frmMain frm)
	{
		InitializeComponent<ComponentResourceManager, Container, Label, TextBox, DataGridView, NumericUpDown, TabControl, TabPage, Button, bool, string, int, object, EventArgs, char, DataGridViewRowStateChangedEventArgs, ContextMenu, MenuItem, MouseEventArgs, decimal, HttpRequest, Exception, Icon>();
		this.frm = frm;
		if (File.Exists("BM_ID_List.json"))
		{
			listBM_IDList = JsonConvert.DeserializeObject<List<BM_Partner>>(File.ReadAllText("BM_ID_List.json"));
			if (listBM_IDList == null)
			{
				listBM_IDList = (List<BM_Partner>)Activator.CreateInstance(typeof(List<BM_Partner>));
			}
		}
		setDataBMList<bool, int, Exception>(isRefesh: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button3_Click<T0, T1, T2, T3, T4, T5, T6>(T5 sender, T6 e)
	{
		//IL_0032: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_020b: Expected O, but got I4
		//IL_023d: Expected O, but got I4
		try
		{
			T0 val = (T0)(!string.IsNullOrWhiteSpace(frmMain.setting.pagePartner.Token) && !string.IsNullOrWhiteSpace(frmMain.setting.pagePartner.Cookie));
			if (val == null)
			{
				return;
			}
			T1 val2 = (T1)Activator.CreateInstance(typeof(HttpRequest));
			((HttpRequest)val2).SslProtocols = SslProtocols.Tls12;
			((HttpRequest)val2).SetCookie(frmMain.setting.pagePartner.Cookie.Replace(" ", ""), true);
			T2 val3 = (T2)string.Concat((string[])(object)new T2[5]
			{
				(T2)"https://graph.facebook.com/v16.0/",
				(T2)frmMain.setting.pagePartner.Page_ID,
				(T2)"/assigned_partners?access_token=",
				(T2)frmMain.setting.pagePartner.Token,
				(T2)"&__activeScenarioIDs=%5B%5D&__activeScenarios=%5B%5D&__interactionsMetadata=%5B%5D&_reqName=object%3Apage%2Fassigned_partners&_reqSrc=BusinessObjectAssignedPartnerStores.brands&date_format=U&fields=%5B%22id%22%2C%22name%22%2C%22permitted_tasks%22%2C%22has_transitioned_to_new_page_experience%22%2C%22has_updated_profile_plus_perm_management%22%5D&limit=300&locale=vi_VN&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref=f3d3ea0ed7c6c84"
			});
			T2 val4 = (T2)((object)((HttpRequest)val2).Get(string.Concat((string[])(object)new T2[1] { val3 }), (RequestParams)null)).ToString();
			partner = JsonConvert.DeserializeObject<PagePartner_Current>((string)val4);
			T2 val5 = (T2)"";
			T0 val6 = (T0)(partner.paging != null && !string.IsNullOrWhiteSpace(partner.paging.next));
			if (val6 != null)
			{
				val5 = (T2)partner.paging.next;
			}
			while (true)
			{
				T0 val7 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
				if (val7 == null)
				{
					break;
				}
				((object)((HttpRequest)val2).Get(string.Concat((string[])(object)new T2[1] { val5 }), (RequestParams)null)).ToString();
				val5 = (T2)"";
				PagePartner_Current pagePartner_Current = JsonConvert.DeserializeObject<PagePartner_Current>((string)val4);
				T0 val8 = (T0)(pagePartner_Current != null);
				if (val8 != null)
				{
					T0 val9 = (T0)(pagePartner_Current.data != null);
					if (val9 != null)
					{
						partner.data.AddRange(pagePartner_Current.data);
					}
					T0 val10 = (T0)(pagePartner_Current.paging != null && !string.IsNullOrWhiteSpace(pagePartner_Current.paging.next));
					if (val10 != null)
					{
						val5 = (T2)pagePartner_Current.paging.next;
					}
				}
			}
			gvPartnerCurrent.DataSource = null;
			T0 val11 = (T0)(partner != null && partner.data != null);
			if (val11 != null)
			{
				gvPartnerCurrent.DataSource = partner.data;
			}
			lbTotalTab1.Text = System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)gvPartnerCurrent.Rows.Count).ToString();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T2)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmPagePartner_Load<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000e: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		T0 val = (T0)(frmMain.setting.pagePartner == null);
		if (val != null)
		{
			frmMain.setting.pagePartner = new PagePartner();
		}
		T0 val2 = (T0)(!string.IsNullOrWhiteSpace(frmMain.setting.pagePartner.Cookie) && !string.IsNullOrWhiteSpace(frmMain.setting.pagePartner.Token));
		if (val2 != null)
		{
			txtCookieToken.Text = frmMain.setting.pagePartner.Cookie + "|" + frmMain.setting.pagePartner.Token;
		}
		T0 val3 = (T0)(!string.IsNullOrWhiteSpace(frmMain.setting.pagePartner.BM_ID));
		if (val3 != null)
		{
			txtBMID.Text = frmMain.setting.pagePartner.BM_ID;
		}
		T0 val4 = (T0)(!string.IsNullOrWhiteSpace(frmMain.setting.pagePartner.Page_ID));
		if (val4 != null)
		{
			txtPageID.Text = frmMain.setting.pagePartner.Page_ID;
		}
		numThreadAssign.Value = frmMain.setting.pagePartner.numThreadAssign;
		numThreadEviction.Value = frmMain.setting.pagePartner.numThreadEviction;
	}

	private void setDataBMList<T0, T1, T2>(T0 isRefesh)
	{
		//IL_0029: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		try
		{
			if (isRefesh != null)
			{
				gvBMList.Refresh();
			}
			else
			{
				gvBMList.DataSource = null;
				T0 val = (T0)(listBM_IDList != null);
				if (val != null)
				{
					gvBMList.DataSource = listBM_IDList;
				}
				lbTotalTab2.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)gvBMList.Rows.Count).ToString();
			}
			BM_IDList_Saving();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtCookieToken_TextChanged<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_003f: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		frmMain.setting.pagePartner.Token = "";
		frmMain.setting.pagePartner.Cookie = "";
		T0 val = (T0)txtCookieToken.Text.Contains("|");
		if (val != null)
		{
			T1[] array = (T1[])(object)txtCookieToken.Text.Split((char[])(object)new T5[1] { (T5)124 });
			T2 val2 = (T2)0;
			while ((nint)val2 < array.Length)
			{
				T1 val3 = (T1)((object[])(object)array)[(object)val2];
				T0 val4 = (T0)((string)val3).Contains("c_user");
				if (val4 != null)
				{
					frmMain.setting.pagePartner.Cookie = (string)val3;
				}
				else
				{
					frmMain.setting.pagePartner.Token = (string)val3;
				}
				val2 = (T2)(val2 + 1);
			}
		}
		frmMain.settingSaving();
	}

	private void txtBMID_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.pagePartner.BM_ID = txtBMID.Text;
		frmMain.settingSaving();
	}

	private void txtPageID_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.pagePartner.Page_ID = txtPageID.Text;
		frmMain.settingSaving();
	}

	private void numThreadEviction_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.pagePartner.numThreadEviction = int.Parse(((decimal)(T0)numThreadEviction.Value).ToString());
		frmMain.settingSaving();
	}

	private void numThreadAssign_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.pagePartner.numThreadAssign = int.Parse(((decimal)(T0)numThreadAssign.Value).ToString());
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvPartnerCurrent_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Tick toàn bộ", (EventHandler)tickUnTickPartnerCurrentEvent<T2, T0, List<PagePartner_Data>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Tick dòng đã chọn", (EventHandler)tickUnTickPartnerCurrentEvent<T2, T0, List<PagePartner_Data>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Bỏ tick toàn bộ", (EventHandler)tickUnTickPartnerCurrentEvent<T2, T0, List<PagePartner_Data>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Bỏ tick dòng đã chọn", (EventHandler)tickUnTickPartnerCurrentEvent<T2, T0, List<PagePartner_Data>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste danh sách BM ID", (EventHandler)pasteBMListPartnerCurrentEvent<string, List<string>, T0, StringReader, int, Exception, T3, EventArgs, List<PagePartner_Data>>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((ContextMenu)val2).Show((Control)gvPartnerCurrent, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteBMListPartnerCurrentEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 sender, T7 e)
	{
		//IL_000b: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		try
		{
			T2 val = (T2)(partner == null);
			if (val != null)
			{
				partner = new PagePartner_Current();
			}
			T2 val2 = (T2)(partner.data == null);
			if (val2 != null)
			{
				partner.data = (List<PagePartner_Data>)Activator.CreateInstance(typeof(T8));
			}
			T0 val3 = (T0)"";
			val3 = (T0)Clipboard.GetText();
			val3 = (T0)((string)val3).Replace("|", Environment.NewLine);
			T1 val4 = (T1)Activator.CreateInstance(typeof(T1));
			T3 val5 = (T3)new StringReader((string)val3);
			try
			{
				while (true)
				{
					T0 val6;
					T2 val7 = (T2)((val6 = (T0)((TextReader)val5).ReadLine()) != null);
					if (val7 == null)
					{
						break;
					}
					T2 val8 = (T2)(!string.IsNullOrWhiteSpace((string)val6));
					if (val8 != null)
					{
						T2 val9 = (T2)(!((List<string>)val4).Contains(((string)val6).Trim()));
						if (val9 != null)
						{
							((List<string>)val4).Add(((string)val6).Trim());
							partner.data.Add(new PagePartner_Data
							{
								id = (string)val6,
								has_transitioned_to_new_page_experience = "",
								has_updated_profile_plus_perm_management = "",
								Message = "",
								name = (string)val6,
								select = true
							});
						}
					}
				}
			}
			finally
			{
				if (val5 != null)
				{
					((IDisposable)val5).Dispose();
				}
			}
			gvPartnerCurrent.DataSource = null;
			T2 val10 = (T2)(partner != null && partner.data != null);
			if (val10 != null)
			{
				gvPartnerCurrent.DataSource = partner.data;
			}
			lbTotalTab1.Text = System.Runtime.CompilerServices.Unsafe.As<T4, int>(ref (T4)gvPartnerCurrent.Rows.Count).ToString();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void tickUnTickPartnerCurrentEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0011: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_0129: Expected I4, but got O
		//IL_015c: Expected I4, but got O
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017f: Expected O, but got I4
		//IL_019b: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_0266: Expected O, but got I4
		//IL_026d: Expected O, but got I4
		//IL_0283: Expected I4, but got O
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02a6: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)(partner != null);
		if (val2 == null)
		{
			return;
		}
		T1 val3 = (T1)((MenuItem)val).Text.Equals("Tick toàn bộ");
		if (val3 != null)
		{
			T2 enumerator = (T2)partner.data.GetEnumerator();
			try
			{
				while (((List<PagePartner_Data>.Enumerator*)(&enumerator))->MoveNext())
				{
					PagePartner_Data current = ((List<PagePartner_Data>.Enumerator*)(&enumerator))->Current;
					current.Message = frmMain.STATUS.Ready.ToString();
					current.select = true;
				}
			}
			finally
			{
				((IDisposable)(*(List<PagePartner_Data>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		else
		{
			T1 val4 = (T1)((MenuItem)val).Text.Equals("Tick dòng đã chọn");
			if (val4 != null)
			{
				T3 val5 = (T3)gvPartnerCurrent.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
					.ToList();
				T1 val6 = (T1)(((List<DataGridViewRow>)val5).Count > 0);
				if (val6 != null)
				{
					T4 val7 = (T4)0;
					while (true)
					{
						T1 val8 = (T1)((nint)val7 < ((List<DataGridViewRow>)val5).Count);
						if (val8 == null)
						{
							break;
						}
						partner.data[((List<DataGridViewRow>)val5)[(int)val7].Index].Message = frmMain.STATUS.Ready.ToString();
						partner.data[((List<DataGridViewRow>)val5)[(int)val7].Index].select = true;
						val7 = (T4)(val7 + 1);
					}
				}
			}
			else
			{
				T1 val9 = (T1)((MenuItem)val).Text.Equals("Bỏ tick toàn bộ");
				if (val9 != null)
				{
					T2 enumerator2 = (T2)partner.data.GetEnumerator();
					try
					{
						while (((List<PagePartner_Data>.Enumerator*)(&enumerator2))->MoveNext())
						{
							PagePartner_Data current2 = ((List<PagePartner_Data>.Enumerator*)(&enumerator2))->Current;
							current2.select = false;
						}
					}
					finally
					{
						((IDisposable)(*(List<PagePartner_Data>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
				else
				{
					T1 val10 = (T1)((MenuItem)val).Text.Equals("Bỏ tick dòng đã chọn");
					if (val10 != null)
					{
						T3 val11 = (T3)gvPartnerCurrent.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
							.ToList();
						T1 val12 = (T1)(((List<DataGridViewRow>)val11).Count > 0);
						if (val12 != null)
						{
							T4 val13 = (T4)0;
							while (true)
							{
								T1 val14 = (T1)((nint)val13 < ((List<DataGridViewRow>)val11).Count);
								if (val14 == null)
								{
									break;
								}
								partner.data[((List<DataGridViewRow>)val11)[(int)val13].Index].select = false;
								val13 = (T4)(val13 + 1);
							}
						}
					}
				}
			}
		}
		gvPartnerCurrent.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvBMList_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Tick toàn bộ", (EventHandler)tickUnTickBMListEvent<T2, T0, List<BM_Partner>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, Exception>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Tick dòng đã chọn", (EventHandler)tickUnTickBMListEvent<T2, T0, List<BM_Partner>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, Exception>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Bỏ tick toàn bộ", (EventHandler)tickUnTickBMListEvent<T2, T0, List<BM_Partner>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, Exception>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Bỏ tick dòng đã chọn", (EventHandler)tickUnTickBMListEvent<T2, T0, List<BM_Partner>.Enumerator, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, Exception>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste danh sách BM ID", (EventHandler)pasteBMListEvent<string, List<string>, T0, StringReader, Exception, T3, EventArgs, List<BM_Partner>, int>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)removeBMListEvent<T2, T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, Exception>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Xóa dòng đã chọn", (EventHandler)removeBMListEvent<T2, T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, Exception>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvBMList, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void removeBMListEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_0011: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		//IL_00d2: Expected I4, but got O
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)(listBM_IDList != null);
		if (val2 == null)
		{
			return;
		}
		T1 val3 = (T1)((MenuItem)val).Text.Equals("Xóa toàn bộ");
		if (val3 == null)
		{
			T1 val4 = (T1)((MenuItem)val).Text.Equals("Xóa dòng đã chọn");
			if (val4 != null)
			{
				T2 val5 = (T2)gvBMList.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
					.ToList();
				T1 val6 = (T1)(((List<DataGridViewRow>)val5).Count > 0);
				if (val6 != null)
				{
					T3 val7 = (T3)(((List<DataGridViewRow>)val5).Count - 1);
					while (true)
					{
						T1 val8 = (T1)((nint)val7 >= 0);
						if (val8 == null)
						{
							break;
						}
						listBM_IDList.RemoveAt(((List<DataGridViewRow>)val5)[(int)val7].Index);
						val7 = (T3)(val7 - 1);
					}
				}
			}
		}
		else
		{
			listBM_IDList.Clear();
		}
		setDataBMList<T1, T3, T7>((T1)0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteBMListEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_000b: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		try
		{
			T2 val = (T2)(listBM_IDList == null);
			if (val != null)
			{
				listBM_IDList = (List<BM_Partner>)Activator.CreateInstance(typeof(T7));
			}
			T0 val2 = (T0)"";
			val2 = (T0)Clipboard.GetText();
			val2 = (T0)((string)val2).Replace("|", Environment.NewLine);
			T1 val3 = (T1)Activator.CreateInstance(typeof(T1));
			T3 val4 = (T3)new StringReader((string)val2);
			try
			{
				while (true)
				{
					T0 val5;
					T2 val6 = (T2)((val5 = (T0)((TextReader)val4).ReadLine()) != null);
					if (val6 == null)
					{
						break;
					}
					T2 val7 = (T2)(!string.IsNullOrWhiteSpace((string)val5));
					if (val7 != null)
					{
						T2 val8 = (T2)(!((List<string>)val3).Contains(((string)val5).Trim()));
						if (val8 != null)
						{
							((List<string>)val3).Add(((string)val5).Trim());
							listBM_IDList.Add(new BM_Partner
							{
								Id = ((string)val5).Trim(),
								row = listBM_IDList.Count + 1,
								Message = frmMain.STATUS.Ready.ToString(),
								select = true
							});
						}
					}
				}
			}
			finally
			{
				if (val4 != null)
				{
					((IDisposable)val4).Dispose();
				}
			}
			setDataBMList<T2, T8, T4>((T2)0);
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void tickUnTickBMListEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_0011: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_011f: Expected I4, but got O
		//IL_013e: Expected I4, but got O
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_0170: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		//IL_0252: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		//IL_026a: Expected I4, but got O
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_028d: Expected O, but got I4
		//IL_0298: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)(listBM_IDList != null);
		if (val2 == null)
		{
			return;
		}
		T1 val3 = (T1)((MenuItem)val).Text.Equals("Tick toàn bộ");
		if (val3 != null)
		{
			T2 enumerator = (T2)listBM_IDList.GetEnumerator();
			try
			{
				while (((List<BM_Partner>.Enumerator*)(&enumerator))->MoveNext())
				{
					BM_Partner current = ((List<BM_Partner>.Enumerator*)(&enumerator))->Current;
					current.select = true;
					current.Message = frmMain.STATUS.Ready.ToString();
				}
			}
			finally
			{
				((IDisposable)(*(List<BM_Partner>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		else
		{
			T1 val4 = (T1)((MenuItem)val).Text.Equals("Tick dòng đã chọn");
			if (val4 != null)
			{
				T3 val5 = (T3)gvBMList.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
					.ToList();
				T1 val6 = (T1)(((List<DataGridViewRow>)val5).Count > 0);
				if (val6 != null)
				{
					T4 val7 = (T4)0;
					while (true)
					{
						T1 val8 = (T1)((nint)val7 < ((List<DataGridViewRow>)val5).Count);
						if (val8 == null)
						{
							break;
						}
						listBM_IDList[((List<DataGridViewRow>)val5)[(int)val7].Index].select = true;
						listBM_IDList[((List<DataGridViewRow>)val5)[(int)val7].Index].Message = frmMain.STATUS.Ready.ToString();
						val7 = (T4)(val7 + 1);
					}
				}
			}
			else
			{
				T1 val9 = (T1)((MenuItem)val).Text.Equals("Bỏ tick toàn bộ");
				if (val9 != null)
				{
					T2 enumerator2 = (T2)listBM_IDList.GetEnumerator();
					try
					{
						while (((List<BM_Partner>.Enumerator*)(&enumerator2))->MoveNext())
						{
							BM_Partner current2 = ((List<BM_Partner>.Enumerator*)(&enumerator2))->Current;
							current2.select = false;
						}
					}
					finally
					{
						((IDisposable)(*(List<BM_Partner>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
				else
				{
					T1 val10 = (T1)((MenuItem)val).Text.Equals("Bỏ tick dòng đã chọn");
					if (val10 != null)
					{
						T3 val11 = (T3)gvBMList.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
							.ToList();
						T1 val12 = (T1)(((List<DataGridViewRow>)val11).Count > 0);
						if (val12 != null)
						{
							T4 val13 = (T4)0;
							while (true)
							{
								T1 val14 = (T1)((nint)val13 < ((List<DataGridViewRow>)val11).Count);
								if (val14 == null)
								{
									break;
								}
								listBM_IDList[((List<DataGridViewRow>)val11)[(int)val13].Index].select = false;
								val13 = (T4)(val13 + 1);
							}
						}
					}
				}
			}
		}
		setDataBMList<T1, T4, T8>((T1)1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BM_IDList_Saving()
	{
		try
		{
			File.WriteAllText("BM_ID_List.json", JsonConvert.SerializeObject((object)listBM_IDList));
		}
		catch
		{
		}
	}

	private void gvBMList_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbBMList.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvBMList.SelectedRows.Count).ToString();
	}

	private void gvPartnerCurrent_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbPartnerCurrent.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvPartnerCurrent.SelectedRows.Count).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button2_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0016: Expected O, but got I4
		isEvictionRunning = !isEvictionRunning;
		T0 val = (T0)isEvictionRunning;
		if (val == null)
		{
			btnEviction.BackColor = Color.RoyalBlue;
			btnEviction.Text = "Start Thu hồi đối tác";
			return;
		}
		btnEviction.Text = "Stop Thu hồi đối tác";
		btnEviction.BackColor = Color.Red;
		timer_eviction_start.Start();
		new Thread(evictionPartner<int, T0, Thread, ParameterizedThreadStart>).Start();
	}

	private void evictionPartner<T0, T1, T2, T3>()
	{
		//IL_0016: Expected O, but got I4
		//IL_002c: Expected I4, but got O
		//IL_0044: Expected I4, but got O
		//IL_0070: Expected I4, but got O
		//IL_0081: Expected O, but got I4
		//IL_0098: Expected I4, but got O
		//IL_00b2: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected I4, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0152: Expected O, but got I4
		_003C_003Ec__DisplayClass24_0 _003C_003Ec__DisplayClass24_ = new _003C_003Ec__DisplayClass24_0();
		_003C_003Ec__DisplayClass24_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass24_.countThread = 0;
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < partner.data.Count);
			if (val2 == null)
			{
				break;
			}
			T1 val3 = (T1)(partner.data[(int)val].select && (partner.data[(int)val].Message.Equals(frmMain.STATUS.Ready.ToString()) || string.IsNullOrWhiteSpace(partner.data[(int)val].Message)));
			if (val3 != null)
			{
				partner.data[(int)val].Message = frmMain.STATUS.Processing.ToString();
				while (true)
				{
					T1 val4 = (T1)(_003C_003Ec__DisplayClass24_.countThread >= frmMain.setting.pagePartner.numThreadEviction && isEvictionRunning);
					if (val4 == null)
					{
						break;
					}
					Thread.Sleep(1000);
				}
				T1 val5 = (T1)(!isEvictionRunning);
				if (val5 != null)
				{
					break;
				}
				T2 val6 = (T2)new Thread(_003C_003Ec__DisplayClass24_._003CevictionPartner_003Eb__0<T0, T1, HttpRequest, string, Exception, object>);
				((Thread)val6).Start((object)val);
				T0 val7 = (T0)_003C_003Ec__DisplayClass24_.countThread;
				_003C_003Ec__DisplayClass24_.countThread = val7 + 1;
			}
			val = (T0)(val + 1);
		}
		isEvictionRunning = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer_eviction_start_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0015: Expected O, but got I4
		gvPartnerCurrent.Refresh();
		T0 val = (T0)(!isEvictionRunning);
		if (val != null)
		{
			timer_eviction_start.Stop();
			btnEviction.BackColor = Color.RoyalBlue;
			btnEviction.Text = "Start Thu hồi đối tác";
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button2_Click_1<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0016: Expected O, but got I4
		isAssignRunning = !isAssignRunning;
		T0 val = (T0)isAssignRunning;
		if (val == null)
		{
			btnAssign.BackColor = Color.RoyalBlue;
			btnAssign.Text = "Start Chỉ định đối tác";
			return;
		}
		btnAssign.Text = "Stop Chỉ định đối tác";
		btnAssign.BackColor = Color.Red;
		timer_assign_start.Start();
		new Thread(assignPartner<T0, Thread, int>).Start();
	}

	private void assignPartner<T0, T1, T2>()
	{
		//IL_0093: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected I4, but got Unknown
		//IL_0152: Expected O, but got I4
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected I4, but got Unknown
		//IL_0171: Expected O, but got I4
		_003C_003Ec__DisplayClass28_0 _003C_003Ec__DisplayClass28_ = new _003C_003Ec__DisplayClass28_0();
		_003C_003Ec__DisplayClass28_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass28_.countThread = 0;
		_003C_003Ec__DisplayClass28_1 _003C_003Ec__DisplayClass28_2 = new _003C_003Ec__DisplayClass28_1();
		_003C_003Ec__DisplayClass28_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass28_;
		_003C_003Ec__DisplayClass28_2.iAds = 0;
		while (true)
		{
			T0 val = (T0)(_003C_003Ec__DisplayClass28_2.iAds < listBM_IDList.Count);
			if (val == null)
			{
				break;
			}
			T0 val2 = (T0)(listBM_IDList[_003C_003Ec__DisplayClass28_2.iAds].select && (listBM_IDList[_003C_003Ec__DisplayClass28_2.iAds].Message.Equals(frmMain.STATUS.Ready.ToString()) || string.IsNullOrWhiteSpace(listBM_IDList[_003C_003Ec__DisplayClass28_2.iAds].Message)));
			T2 val6;
			if (val2 != null)
			{
				listBM_IDList[_003C_003Ec__DisplayClass28_2.iAds].Message = frmMain.STATUS.Processing.ToString();
				while (true)
				{
					T0 val3 = (T0)(_003C_003Ec__DisplayClass28_2.CS_0024_003C_003E8__locals1.countThread >= frmMain.setting.pagePartner.numThreadAssign && isAssignRunning);
					if (val3 == null)
					{
						break;
					}
					Thread.Sleep(1000);
				}
				T0 val4 = (T0)(!isAssignRunning);
				if (val4 != null)
				{
					break;
				}
				T1 val5 = (T1)new Thread(_003C_003Ec__DisplayClass28_2._003CassignPartner_003Eb__0<T2, T0, string, HttpRequest, Exception, object>);
				((Thread)val5).Start((object)(T2)_003C_003Ec__DisplayClass28_2.iAds);
				val6 = (T2)_003C_003Ec__DisplayClass28_2.CS_0024_003C_003E8__locals1.countThread;
				_003C_003Ec__DisplayClass28_2.CS_0024_003C_003E8__locals1.countThread = val6 + 1;
			}
			val6 = (T2)_003C_003Ec__DisplayClass28_2.iAds;
			_003C_003Ec__DisplayClass28_2.iAds = val6 + 1;
		}
		isAssignRunning = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer_assign_start_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0015: Expected O, but got I4
		gvBMList.Refresh();
		T0 val = (T0)(!isAssignRunning);
		if (val != null)
		{
			timer_assign_start.Stop();
			btnAssign.BackColor = Color.RoyalBlue;
			btnAssign.Text = "Start Chỉ định đối tác";
			BM_IDList_Saving();
		}
	}

	private void button1_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_001e: Expected O, but got I4
		//IL_002f: Expected I4, but got O
		//IL_003d: Expected I4, but got O
		//IL_0055: Expected I4, but got O
		//IL_0076: Expected I4, but got O
		//IL_008e: Expected I4, but got O
		//IL_00a2: Expected O, but got I4
		//IL_00b6: Expected I4, but got O
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cf: Expected O, but got I4
		gvBMList.ClearSelection();
		T0 value = (T0)txtAssignPartnerSearch.Text.ToLower();
		T1 val = (T1)0;
		while (true)
		{
			T2 val2 = (T2)((nint)val < listBM_IDList.Count);
			if (val2 != null)
			{
				T2 val3 = (T2)((listBM_IDList[(int)val] != null && !string.IsNullOrWhiteSpace(listBM_IDList[(int)val].Id) && listBM_IDList[(int)val].Id.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listBM_IDList[(int)val].Message) && listBM_IDList[(int)val].Message.ToLower().Contains((string)value)));
				if (val3 != null)
				{
					gvBMList.Rows[(int)val].Selected = true;
				}
				val = (T1)(val + 1);
				continue;
			}
			break;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmPagePartner));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCookieToken = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtBMID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtPageID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.gvBMList = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numThreadAssign = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.tabControl1 = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabPage1 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbPartnerCurrent = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbTotalTab1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvPartnerCurrent = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.btnEviction = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numThreadEviction = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.tabPage2 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.btnAssign = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lbBMList = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbTotalTab2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.timer_eviction_start = new System.Windows.Forms.Timer(this.components);
		this.timer_assign_start = new System.Windows.Forms.Timer(this.components);
		this.txtAssignPartnerSearch = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		((System.ComponentModel.ISupportInitialize)this.gvBMList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThreadAssign).BeginInit();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvPartnerCurrent).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThreadEviction).BeginInit();
		this.tabPage2.SuspendLayout();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(132, 16);
		this.label1.TabIndex = 0;
		this.label1.Text = "Cookie|Token EAAG";
		this.txtCookieToken.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtCookieToken.Location = new System.Drawing.Point(150, 6);
		this.txtCookieToken.Name = "txtCookieToken";
		this.txtCookieToken.Size = new System.Drawing.Size(782, 22);
		this.txtCookieToken.TabIndex = 1;
		this.txtCookieToken.TextChanged += new System.EventHandler(txtCookieToken_TextChanged<T9, T10, T11, T12, T13, T14>);
		this.txtBMID.Location = new System.Drawing.Point(150, 34);
		this.txtBMID.Name = "txtBMID";
		this.txtBMID.Size = new System.Drawing.Size(255, 22);
		this.txtBMID.TabIndex = 3;
		this.txtBMID.TextChanged += new System.EventHandler(txtBMID_TextChanged);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(101, 37);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(43, 16);
		this.label2.TabIndex = 2;
		this.label2.Text = "BM ID";
		this.txtPageID.Location = new System.Drawing.Point(150, 62);
		this.txtPageID.Name = "txtPageID";
		this.txtPageID.Size = new System.Drawing.Size(255, 22);
		this.txtPageID.TabIndex = 5;
		this.txtPageID.TextChanged += new System.EventHandler(txtPageID_TextChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(88, 65);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(56, 16);
		this.label3.TabIndex = 4;
		this.label3.Text = "Page ID";
		this.gvBMList.AllowUserToAddRows = false;
		this.gvBMList.AllowUserToDeleteRows = false;
		this.gvBMList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvBMList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvBMList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvBMList.Location = new System.Drawing.Point(6, 55);
		this.gvBMList.Name = "gvBMList";
		this.gvBMList.RowHeadersWidth = 51;
		this.gvBMList.RowTemplate.Height = 24;
		this.gvBMList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvBMList.Size = new System.Drawing.Size(918, 353);
		this.gvBMList.TabIndex = 6;
		this.gvBMList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvBMList_RowStateChanged<T11, T12, T15>);
		this.gvBMList.MouseClick += new System.Windows.Forms.MouseEventHandler(gvBMList_MouseClick<T9, T16, T17, T12, T18>);
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(612, 19);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(47, 16);
		this.label4.TabIndex = 7;
		this.label4.Text = "Luồng:";
		this.numThreadAssign.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numThreadAssign.Location = new System.Drawing.Point(665, 17);
		this.numThreadAssign.Maximum = new decimal((int[])(object)new T11[4]
		{
			(T11)99999999,
			default(T11),
			default(T11),
			default(T11)
		});
		this.numThreadAssign.Name = "numThreadAssign";
		this.numThreadAssign.Size = new System.Drawing.Size(95, 22);
		this.numThreadAssign.TabIndex = 8;
		this.numThreadAssign.Value = new decimal((int[])(object)new T11[4]
		{
			(T11)5,
			default(T11),
			default(T11),
			default(T11)
		});
		this.numThreadAssign.ValueChanged += new System.EventHandler(numThreadAssign_ValueChanged<T19, T12, T13>);
		this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Location = new System.Drawing.Point(3, 90);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(938, 440);
		this.tabControl1.TabIndex = 10;
		this.tabPage1.Controls.Add(this.lbPartnerCurrent);
		this.tabPage1.Controls.Add(this.lbTotalTab1);
		this.tabPage1.Controls.Add(this.button3);
		this.tabPage1.Controls.Add(this.gvPartnerCurrent);
		this.tabPage1.Controls.Add(this.btnEviction);
		this.tabPage1.Controls.Add(this.numThreadEviction);
		this.tabPage1.Controls.Add(this.label5);
		this.tabPage1.Location = new System.Drawing.Point(4, 25);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(930, 411);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Đối tác hiện tại";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.lbPartnerCurrent.AutoSize = true;
		this.lbPartnerCurrent.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbPartnerCurrent.Location = new System.Drawing.Point(7, 35);
		this.lbPartnerCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbPartnerCurrent.Name = "lbPartnerCurrent";
		this.lbPartnerCurrent.Size = new System.Drawing.Size(18, 17);
		this.lbPartnerCurrent.TabIndex = 55;
		this.lbPartnerCurrent.Text = "0";
		this.lbTotalTab1.AutoSize = true;
		this.lbTotalTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbTotalTab1.Location = new System.Drawing.Point(87, 9);
		this.lbTotalTab1.Name = "lbTotalTab1";
		this.lbTotalTab1.Size = new System.Drawing.Size(15, 16);
		this.lbTotalTab1.TabIndex = 15;
		this.lbTotalTab1.Text = "0";
		this.button3.Location = new System.Drawing.Point(6, 5);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(75, 25);
		this.button3.TabIndex = 14;
		this.button3.Text = "Reload";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T9, T20, T10, T11, T21, T12, T13>);
		this.gvPartnerCurrent.AllowUserToAddRows = false;
		this.gvPartnerCurrent.AllowUserToDeleteRows = false;
		this.gvPartnerCurrent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvPartnerCurrent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvPartnerCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvPartnerCurrent.Location = new System.Drawing.Point(6, 55);
		this.gvPartnerCurrent.Name = "gvPartnerCurrent";
		this.gvPartnerCurrent.RowHeadersWidth = 51;
		this.gvPartnerCurrent.RowTemplate.Height = 24;
		this.gvPartnerCurrent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvPartnerCurrent.Size = new System.Drawing.Size(918, 351);
		this.gvPartnerCurrent.TabIndex = 10;
		this.gvPartnerCurrent.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvPartnerCurrent_RowStateChanged<T11, T12, T15>);
		this.gvPartnerCurrent.MouseClick += new System.Windows.Forms.MouseEventHandler(gvPartnerCurrent_MouseClick<T9, T16, T17, T12, T18>);
		this.btnEviction.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnEviction.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnEviction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
		this.btnEviction.Location = new System.Drawing.Point(766, 6);
		this.btnEviction.Name = "btnEviction";
		this.btnEviction.Size = new System.Drawing.Size(158, 43);
		this.btnEviction.TabIndex = 13;
		this.btnEviction.Text = "Start Thu hồi đối tác";
		this.btnEviction.UseVisualStyleBackColor = false;
		this.btnEviction.Click += new System.EventHandler(button2_Click<T9, T12, T13>);
		this.numThreadEviction.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numThreadEviction.Location = new System.Drawing.Point(665, 17);
		this.numThreadEviction.Maximum = new decimal((int[])(object)new T11[4]
		{
			(T11)99999999,
			default(T11),
			default(T11),
			default(T11)
		});
		this.numThreadEviction.Name = "numThreadEviction";
		this.numThreadEviction.Size = new System.Drawing.Size(95, 22);
		this.numThreadEviction.TabIndex = 12;
		this.numThreadEviction.Value = new decimal((int[])(object)new T11[4]
		{
			(T11)5,
			default(T11),
			default(T11),
			default(T11)
		});
		this.numThreadEviction.ValueChanged += new System.EventHandler(numThreadEviction_ValueChanged<T19, T12, T13>);
		this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(612, 19);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(47, 16);
		this.label5.TabIndex = 11;
		this.label5.Text = "Luồng:";
		this.tabPage2.Controls.Add(this.button1);
		this.tabPage2.Controls.Add(this.txtAssignPartnerSearch);
		this.tabPage2.Controls.Add(this.btnAssign);
		this.tabPage2.Controls.Add(this.lbBMList);
		this.tabPage2.Controls.Add(this.lbTotalTab2);
		this.tabPage2.Controls.Add(this.gvBMList);
		this.tabPage2.Controls.Add(this.numThreadAssign);
		this.tabPage2.Controls.Add(this.label4);
		this.tabPage2.Location = new System.Drawing.Point(4, 25);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(930, 411);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Chỉ định đối tác";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.btnAssign.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnAssign.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnAssign.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
		this.btnAssign.Location = new System.Drawing.Point(766, 6);
		this.btnAssign.Name = "btnAssign";
		this.btnAssign.Size = new System.Drawing.Size(158, 43);
		this.btnAssign.TabIndex = 56;
		this.btnAssign.Text = "Start Chỉ định đối tác";
		this.btnAssign.UseVisualStyleBackColor = false;
		this.btnAssign.Click += new System.EventHandler(button2_Click_1<T9, T12, T13>);
		this.lbBMList.AutoSize = true;
		this.lbBMList.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbBMList.Location = new System.Drawing.Point(7, 37);
		this.lbBMList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbBMList.Name = "lbBMList";
		this.lbBMList.Size = new System.Drawing.Size(18, 17);
		this.lbBMList.TabIndex = 55;
		this.lbBMList.Text = "0";
		this.lbTotalTab2.AutoSize = true;
		this.lbTotalTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbTotalTab2.Location = new System.Drawing.Point(6, 10);
		this.lbTotalTab2.Name = "lbTotalTab2";
		this.lbTotalTab2.Size = new System.Drawing.Size(15, 16);
		this.lbTotalTab2.TabIndex = 10;
		this.lbTotalTab2.Text = "0";
		this.timer_eviction_start.Interval = 1000;
		this.timer_eviction_start.Tick += new System.EventHandler(timer_eviction_start_Tick<T9, T12, T13>);
		this.timer_assign_start.Interval = 1000;
		this.timer_assign_start.Tick += new System.EventHandler(timer_assign_start_Tick<T9, T12, T13>);
		this.txtAssignPartnerSearch.Location = new System.Drawing.Point(307, 16);
		this.txtAssignPartnerSearch.Name = "txtAssignPartnerSearch";
		this.txtAssignPartnerSearch.Size = new System.Drawing.Size(200, 22);
		this.txtAssignPartnerSearch.TabIndex = 57;
		this.button1.Location = new System.Drawing.Point(513, 16);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 58;
		this.button1.Text = "Search";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T10, T11, T9, T12, T13>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(944, 534);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.txtPageID);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.txtBMID);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtCookieToken);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)(T22)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmPagePartner";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Quản lý page đối tác";
		base.Load += new System.EventHandler(frmPagePartner_Load<T9, T12, T13>);
		((System.ComponentModel.ISupportInitialize)this.gvBMList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThreadAssign).EndInit();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvPartnerCurrent).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThreadEviction).EndInit();
		this.tabPage2.ResumeLayout(false);
		this.tabPage2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
