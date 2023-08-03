using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.Data.BusinessManagerEntity;

namespace ADSPRoject;

public class frmBMManager : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public List<string> listBM;

		internal T0 _003C_002Ector_003Eb__0<T0>(BusinessManagerEntity_businesses_Data a)
		{
			//IL_0012: Expected O, but got I4
			return (T0)listBM.Contains(a.id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public frmBMManager _003C_003E4__this;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__0;

		public ParameterizedThreadStart _003C_003E9__1;

		public ParameterizedThreadStart _003C_003E9__2;

		public ParameterizedThreadStart _003C_003E9__4;

		public ParameterizedThreadStart _003C_003E9__5;

		public ParameterizedThreadStart _003C_003E9__6;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__0<T0, T1, T2, T3, T4>(T3 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0059: Expected I4, but got O
			//IL_008b: Expected O, but got I4
			//IL_00f5: Expected O, but got I4
			//IL_010a: Expected I4, but got O
			//IL_012f: Expected I4, but got O
			//IL_014b: Expected I4, but got O
			//IL_0170: Expected I4, but got O
			//IL_017a: Expected O, but got I4
			//IL_018f: Expected I4, but got O
			//IL_01aa: Expected I4, but got O
			//IL_01b9: Expected O, but got I4
			//IL_01ce: Expected I4, but got O
			//IL_01f8: Expected I4, but got O
			//IL_0226: Expected O, but got I4
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Processing.ToString();
			T1 strError = (T1)"";
			T1 val2 = (T1)_003C_003E4__this.frm.chrome.createAdsInBM(_003C_003E4__this.BusinessManager[(int)val].id, $"{_003C_003E4__this.NameAds} {(T0)_003C_003E4__this.rnd.Next(111, 999)}", _003C_003E4__this.TimeZoneAds, _003C_003E4__this.CurrencyAds, _003C_003E4__this.CountryAds, "", _003C_003E4__this.StateAds, _003C_003E4__this.AddressAds, _003C_003E4__this.ZipAds, _003C_003E4__this.CityAds, out *(string*)(&strError));
			T2 val3 = (T2)(!string.IsNullOrWhiteSpace((string)val2));
			if (val3 == null)
			{
				_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.lỗi.ToString();
				_003C_003E4__this.BusinessManager[(int)val].message = (string)strError;
			}
			else
			{
				_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Done.ToString();
				T2 val4 = (T2)(_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts == null);
				if (val4 != null)
				{
					_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts = new owned_ad_accounts();
				}
				T2 val5 = (T2)(_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data == null);
				if (val5 != null)
				{
					_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data = (List<adaccountsData>)Activator.CreateInstance(typeof(T4));
				}
				_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data.Add(new adaccountsData
				{
					id = (string)val2,
					name = ""
				});
			}
			T0 val6 = (T0)countThread;
			countThread = val6 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__1<T0, T1, T2, T3, T4, T5>(T4 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_0023: Expected I4, but got O
			//IL_003b: Expected O, but got I4
			//IL_003d: Expected O, but got I4
			//IL_004e: Expected I4, but got O
			//IL_0066: Expected I4, but got O
			//IL_0078: Expected O, but got I4
			//IL_0090: Expected I4, but got O
			//IL_00d5: Expected I4, but got O
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_0120: Expected I4, but got O
			//IL_014d: Expected I4, but got O
			//IL_016a: Expected O, but got I4
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			T1 strError = (T1)"";
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Processing.ToString();
			T0 val2 = (T0)0;
			T0 val3 = (T0)0;
			T2 val4 = (T2)(_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts != null && _003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data != null);
			if (val4 != null)
			{
				T3 enumerator = (T3)_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
					{
						adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
						T2 val5 = _003C_003E4__this.frm.chrome.Set_Payment_BM_Cho_Act<T1, T5, T2>((T1)current.id, (T1)_003C_003E4__this.BusinessManager[(int)val].id, (T1)"", out *(string*)(&strError));
						if (val5 != null)
						{
							val2 = (T0)(val2 + 1);
						}
						else
						{
							val3 = (T0)(val3 + 1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			_003C_003E4__this.BusinessManager[(int)val].message = $"Succ({val2}) - lỗi({val3})";
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Done.ToString();
			T0 val6 = (T0)countThread;
			countThread = val6 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__2<T0, T1, T2, T3, T4, T5>(T3 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0034: Expected O, but got I4
			//IL_0036: Expected O, but got I4
			//IL_0047: Expected I4, but got O
			//IL_005f: Expected I4, but got O
			//IL_0071: Expected O, but got I4
			//IL_0089: Expected I4, but got O
			//IL_00ce: Expected I4, but got O
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_011d: Expected I4, but got O
			//IL_014a: Expected I4, but got O
			//IL_0166: Expected O, but got I4
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Processing.ToString();
			T0 val2 = (T0)0;
			T0 val3 = (T0)0;
			T1 val4 = (T1)(_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts != null && _003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data != null);
			if (val4 != null)
			{
				T2 enumerator = (T2)_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
					{
						adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
						T1 val5 = _003C_003E4__this.frm.chrome.sharePartner<T1, T4, T5>((T5)current.id, (T5)_003C_003E4__this.BusinessManager[(int)val].id, (T5)_003C_003E4__this.BMPartner);
						if (val5 != null)
						{
							val2 = (T0)(val2 + 1);
						}
						else
						{
							val3 = (T0)(val3 + 1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			_003C_003E4__this.BusinessManager[(int)val].message = $"Share({val2}) - lỗi({val3})";
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Done.ToString();
			T0 val6 = (T0)countThread;
			countThread = val6 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CthrStart_003Eb__4<T0, T1, T2, T3, T4, T5>(T3 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0057: Expected O, but got I4
			//IL_007e: Expected O, but got I4
			//IL_0099: Expected O, but got I4
			//IL_00b1: Expected O, but got I4
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00e4: Expected O, but got I4
			//IL_010c: Expected I4, but got O
			//IL_0126: Expected O, but got I4
			//IL_013d: Expected I4, but got O
			//IL_0166: Expected I4, but got O
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_01a7: Expected O, but got I4
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.BusinessManager[(int)val].status = "";
			T1[] array = (T1[])(object)_003C_003E4__this.MailDomain.Replace("\r", "").Split((char[])(object)new T4[1] { (T4)10 });
			T1[] array2 = array;
			T0 val2 = (T0)0;
			while ((nint)val2 < array2.Length)
			{
				T1 val3 = (T1)((object[])(object)array2)[(object)val2];
				T1 val4 = (T1)((string)val3).Trim().ToLower();
				T2 val5 = (T2)((string)val4).Contains("|");
				if (val5 != null)
				{
					T1[] array3 = (T1[])(object)((string)val4).Split((char[])(object)new T4[1] { (T4)124 });
					T0 val6 = (T0)0;
					while ((nint)val6 < array3.Length)
					{
						T1 val7 = (T1)((object[])(object)array3)[(object)val6];
						T2 val8 = (T2)((string)val7).Contains("@");
						if (val8 == null)
						{
							val6 = (T0)(val6 + 1);
							continue;
						}
						val4 = val7;
						break;
					}
				}
				T2 val9 = (T2)(!string.IsNullOrWhiteSpace((string)val4) && ((string)val4).Contains("@"));
				if (val9 != null)
				{
					T2 val10 = _003C_003E4__this.frm.chrome.tao_link_moi_bm<T2, T0, T5, T1>((T1)_003C_003E4__this.BusinessManager[(int)val].id, val4, (T2)(!_003C_003E4__this.LinkInvaiteEmployee));
					if (val10 != null)
					{
						_003C_003E4__this.BusinessManager[(int)val].status += "1-";
					}
					else
					{
						_003C_003E4__this.BusinessManager[(int)val].status += "0-";
					}
					Thread.Sleep(_003C_003E4__this.intDelayBM * 1000);
				}
				val2 = (T0)(val2 + 1);
			}
			T0 val11 = (T0)countThread;
			countThread = val11 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__5<T0, T1, T2, T3, T4, T5, T6>(T3 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0034: Expected O, but got I4
			//IL_0036: Expected O, but got I4
			//IL_0047: Expected I4, but got O
			//IL_005f: Expected I4, but got O
			//IL_0071: Expected O, but got I4
			//IL_0089: Expected I4, but got O
			//IL_00c7: Expected I4, but got O
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_0112: Expected I4, but got O
			//IL_013f: Expected I4, but got O
			//IL_015b: Expected O, but got I4
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Processing.ToString();
			T0 val2 = (T0)0;
			T0 val3 = (T0)0;
			T1 val4 = (T1)(_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts != null && _003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data != null);
			if (val4 != null)
			{
				T2 enumerator = (T2)_003C_003E4__this.BusinessManager[(int)val].owned_ad_accounts.data.GetEnumerator();
				try
				{
					while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
					{
						adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
						T1 val5 = _003C_003E4__this.frm.chrome.shareToAdminBM<T4, T5, T6, T1>((T5)_003C_003E4__this.BusinessManager[(int)val].id, (T5)current.id);
						if (val5 == null)
						{
							val3 = (T0)(val3 + 1);
						}
						else
						{
							val2 = (T0)(val2 + 1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			_003C_003E4__this.BusinessManager[(int)val].message = $"Succ({val2}) - lỗi({val3})";
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Done.ToString();
			T0 val6 = (T0)countThread;
			countThread = val6 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CthrStart_003Eb__6<T0, T1, T2, T3, T4>(T3 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0054: Expected I4, but got O
			//IL_006a: Expected I4, but got O
			//IL_00b6: Expected I4, but got O
			//IL_00d6: Expected I4, but got O
			//IL_00fd: Expected I4, but got O
			//IL_0122: Expected I4, but got O
			//IL_0141: Expected O, but got I4
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Processing.ToString();
			T1 val2 = (T1)(_003C_003E4__this.BMName + " " + _003C_003E4__this.BusinessManager[(int)val].id.Substring(_003C_003E4__this.BusinessManager[(int)val].id.Length - 4, 4));
			val2 = (T1)((string)val2).Replace(" ", "%20");
			T2 val3 = _003C_003E4__this.frm.chrome.doi_ten_BM<T2, T4, T1>((T1)_003C_003E4__this.BusinessManager[(int)val].id, val2);
			if (val3 == null)
			{
				_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.lỗi.ToString();
			}
			else
			{
				_003C_003E4__this.BusinessManager[(int)val].status = frmMain.STATUS.Done.ToString();
				_003C_003E4__this.BusinessManager[(int)val].name = ((string)val2).Replace("%20", " ");
			}
			T0 val4 = (T0)countThread;
			countThread = val4 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public List<ListStringData> listMail;

		public _003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals1;

		public ParameterizedThreadStart _003C_003E9__3;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__3<T0, T1, T2, T3, T4, T5>(T4 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_0022: Expected I4, but got O
			//IL_0066: Expected O, but got I4
			//IL_00bc: Expected O, but got I4
			//IL_00c6: Expected O, but got I4
			//IL_00d8: Expected O, but got I4
			//IL_00df: Expected O, but got I4
			//IL_010a: Expected I4, but got O
			//IL_0133: Expected I4, but got O
			//IL_0161: Expected I4, but got O
			//IL_01aa: Expected I4, but got O
			//IL_01cd: Expected O, but got I4
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			CS_0024_003C_003E8__locals1._003C_003E4__this.BusinessManager[(int)val].status = "";
			T1 val2 = (T1)"";
			T2 enumerator = (T2)listMail.GetEnumerator();
			try
			{
				while (((List<ListStringData>.Enumerator*)(&enumerator))->MoveNext())
				{
					ListStringData current = ((List<ListStringData>.Enumerator*)(&enumerator))->Current;
					T3 val3 = (T3)current.str2.Equals(frmMain.STATUS.Ready.ToString());
					if (val3 != null)
					{
						val2 = (T1)current.str1;
						current.str2 = frmMain.STATUS.Used.ToString();
						break;
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator))).Dispose();
			}
			T3 val4 = (T3)(!string.IsNullOrWhiteSpace((string)val2) && ((string)val2).Contains("@"));
			if (val4 != null)
			{
				T3 isAdmin = (T3)1;
				T3 val5 = (T3)CS_0024_003C_003E8__locals1._003C_003E4__this.LinkInvaiteEmployee;
				if (val5 != null)
				{
					isAdmin = (T3)0;
				}
				T3 val6 = CS_0024_003C_003E8__locals1._003C_003E4__this.frm.chrome.tao_link_moi_bm<T3, T0, T5, T1>((T1)CS_0024_003C_003E8__locals1._003C_003E4__this.BusinessManager[(int)val].id, val2, isAdmin);
				if (val6 != null)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.BusinessManager[(int)val].status += "1-";
				}
				else
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.BusinessManager[(int)val].status += "0-";
				}
				Thread.Sleep(CS_0024_003C_003E8__locals1._003C_003E4__this.intDelayBM * 1000);
			}
			else
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.BusinessManager[(int)val].status += "Hết mail";
			}
			T0 val7 = (T0)CS_0024_003C_003E8__locals1.countThread;
			CS_0024_003C_003E8__locals1.countThread = val7 - 1;
		}
	}

	private List<BusinessManagerEntity_businesses_Data> BusinessManager = (List<BusinessManagerEntity_businesses_Data>)Activator.CreateInstance(typeof(List<BusinessManagerEntity_businesses_Data>));

	private frmAdsManager frm;

	private bool isRunning = false;

	private string strError = "";

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private List<ClassCard> listCart = (List<ClassCard>)Activator.CreateInstance(typeof(List<ClassCard>));

	private bool AddCart = false;

	private int intThreadBM = 0;

	private string Country;

	private string Currency;

	private bool CreateAds;

	private string NameAds = "";

	private string CountryAds;

	private string TimeZoneAds;

	private string CurrencyAds;

	private string AddressAds;

	private string StateAds;

	private string CityAds;

	private string ZipAds;

	private bool SetCardBMToAct;

	private int NumOfCard = 10;

	private bool SharePartner;

	private string BMPartner;

	private bool LinkInvaiteAdmin;

	private string MailDomain = "";

	private bool ShareActToUser;

	private bool ChangeNameBM;

	private string BMName;

	private string ActByBM10;

	private bool LinkInvaiteEmployee;

	private int intDelayBM = 0;

	private bool boolOneBmOneMail;

	private bool RemoveBM = false;

	private IContainer components = null;

	private DataGridView gvData;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel lbTotal;

	private NumericUpDown numThread;

	private Label label2;

	private Button button1;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private GroupBox groupBox1;

	private Label label3;

	private TextBox txtCurrency;

	private Label label1;

	private TextBox txtCountry;

	private CheckBox cbAddCart;

	private TextBox txtCard;

	private Label label4;

	private GroupBox groupBox2;

	private CheckBox cbCreateAds;

	private TextBox txtCountryAds;

	private Label label5;

	private TextBox txtTimeZoneAds;

	private Label label7;

	private TextBox txtCurrencyAds;

	private Label label6;

	private TextBox txtNameAds;

	private Label label8;

	private TextBox txtZipAds;

	private Label label12;

	private TextBox txtCityAds;

	private Label label11;

	private TextBox txtStateAds;

	private Label label10;

	private TextBox txtAddressAds;

	private Label label9;

	private CheckBox cbSetCardBMToAct;

	private NumericUpDown numNumOfCard;

	private Label label13;

	private CheckBox cbSharePartner;

	private TextBox txtBMPartner;

	private TextBox txtMailDomain;

	private CheckBox cbLinkInvaiteAdmin;

	private CheckBox cbShareActToUser;

	private TextBox txtBMName;

	private CheckBox cbChangeNameBM;

	private TextBox txtActByBM10;

	private Label label14;

	private Label label15;

	private CheckBox cbLinkInvaiteEmployee;

	private NumericUpDown numDelayBM;

	private Label label16;

	private CheckBox cbOneBmOneMail;

	private CheckBox cbRemoveBM;

	private SplitContainer splitContainer1;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmBMManager(List<string> listBM, frmAdsManager frm)
	{
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
		_003C_003Ec__DisplayClass2_.listBM = listBM;
		base._002Ector();
		InitializeComponent<ComponentResourceManager, Container, DataGridView, StatusStrip, ToolStripStatusLabel, NumericUpDown, Label, Button, GroupBox, TextBox, CheckBox, SplitContainer, ToolStripItem, int, decimal, object, EventArgs, bool, string, char, Icon, FormClosingEventArgs>();
		this.frm = frm;
		ChromeControl.getFirstName<bool, string, int>();
		ChromeControl.getLastName<bool, string, int>();
		gvData.AutoGenerateColumns = false;
		gvData.Columns.Clear();
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "id");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Message", "message");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Status", "status");
		BusinessManager = frm.BusinessManager.Where(_003C_003Ec__DisplayClass2_._003C_002Ector_003Eb__0<bool>).ToList();
		gvData.DataSource = BusinessManager;
		lbTotal.Text = BusinessManager.Count.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenColumn<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val == null)
		{
			T2 val2 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvData.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T1 val3 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvData.Columns.Add((DataGridViewColumn)val3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0037: Expected O, but got I4
		button1.Text = "START";
		button1.BackColor = Color.DodgerBlue;
		isRunning = !isRunning;
		T0 val = (T0)isRunning;
		if (val != null)
		{
			button1.Text = "STOP";
			button1.BackColor = Color.Red;
			timer_auto_refesh.Interval = 1000;
			timer_auto_refesh.Start();
			new Thread(thrStart<T0, int, string, Thread, ParameterizedThreadStart, List<ListStringData>, List<BusinessManagerEntity_businesses_Data>, List<BusinessManagerEntity_businesses_Data>.Enumerator, List<ListStringData>.Enumerator, Exception, char, Dictionary<string, string>, List<business_users_data>.Enumerator, List<object>>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void thrStart<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
	{
		//IL_000f: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_007c: Expected I4, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a5: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00b7: Expected I4, but got O
		//IL_00d4: Expected O, but got I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00ef: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_010d: Expected I4, but got O
		//IL_012d: Expected O, but got I4
		//IL_013e: Expected I4, but got O
		//IL_017e: Expected I4, but got O
		//IL_019d: Expected O, but got I4
		//IL_01b1: Expected I4, but got O
		//IL_01d7: Expected I4, but got O
		//IL_01fd: Expected I4, but got O
		//IL_0223: Expected I4, but got O
		//IL_0249: Expected I4, but got O
		//IL_028b: Expected I4, but got O
		//IL_02b1: Expected I4, but got O
		//IL_02d7: Expected I4, but got O
		//IL_02fd: Expected I4, but got O
		//IL_0334: Expected O, but got I4
		//IL_0349: Expected O, but got I4
		//IL_037a: Expected I4, but got O
		//IL_038c: Expected I4, but got O
		//IL_03bf: Expected I4, but got O
		//IL_03e3: Expected I4, but got O
		//IL_0405: Expected I4, but got O
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		//IL_042b: Expected O, but got I4
		//IL_043a: Expected O, but got I4
		//IL_0446: Expected O, but got I4
		//IL_0475: Expected O, but got I4
		//IL_047d: Expected O, but got I4
		//IL_04b5: Expected O, but got I4
		//IL_04f7: Expected O, but got I4
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected I4, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		//IL_0518: Expected O, but got I4
		//IL_0524: Expected O, but got I4
		//IL_0530: Expected O, but got I4
		//IL_055f: Expected O, but got I4
		//IL_0567: Expected O, but got I4
		//IL_059f: Expected O, but got I4
		//IL_05e1: Expected O, but got I4
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected I4, but got Unknown
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_0602: Expected O, but got I4
		//IL_060e: Expected O, but got I4
		//IL_061a: Expected O, but got I4
		//IL_0649: Expected O, but got I4
		//IL_0651: Expected O, but got I4
		//IL_0689: Expected O, but got I4
		//IL_06cb: Expected O, but got I4
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Expected I4, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		//IL_06ec: Expected O, but got I4
		//IL_0703: Expected O, but got I4
		//IL_070f: Expected O, but got I4
		//IL_0743: Expected O, but got I4
		//IL_074d: Expected O, but got I4
		//IL_0755: Expected O, but got I4
		//IL_078d: Expected O, but got I4
		//IL_07d2: Expected O, but got I4
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Expected I4, but got Unknown
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Expected O, but got Unknown
		//IL_07f3: Expected O, but got I4
		//IL_0850: Expected O, but got I4
		//IL_0879: Expected O, but got I4
		//IL_0894: Expected O, but got I4
		//IL_08ac: Expected O, but got I4
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Expected O, but got Unknown
		//IL_08d3: Expected O, but got I4
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_090c: Expected O, but got Unknown
		//IL_091a: Expected O, but got I4
		//IL_0922: Expected O, but got I4
		//IL_0960: Expected O, but got I4
		//IL_09ab: Expected O, but got I4
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Expected I4, but got Unknown
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Expected O, but got Unknown
		//IL_09d2: Expected O, but got I4
		//IL_09e1: Expected O, but got I4
		//IL_09ed: Expected O, but got I4
		//IL_0a1c: Expected O, but got I4
		//IL_0a24: Expected O, but got I4
		//IL_0a5c: Expected O, but got I4
		//IL_0a9e: Expected O, but got I4
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Expected I4, but got Unknown
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Expected O, but got Unknown
		//IL_0abf: Expected O, but got I4
		//IL_0acb: Expected O, but got I4
		//IL_0ad7: Expected O, but got I4
		//IL_0b06: Expected O, but got I4
		//IL_0b0e: Expected O, but got I4
		//IL_0b46: Expected O, but got I4
		//IL_0b88: Expected O, but got I4
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Expected I4, but got Unknown
		//IL_0b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0ba9: Expected O, but got I4
		//IL_0bb5: Expected O, but got I4
		//IL_0bd0: Expected O, but got I4
		//IL_0be1: Expected O, but got I4
		//IL_0bf3: Expected O, but got I4
		//IL_0c07: Expected I4, but got O
		//IL_0c33: Expected I4, but got O
		//IL_0c8f: Expected O, but got I4
		//IL_0d63: Expected O, but got I4
		//IL_0dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_0e24: Expected O, but got I4
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_._003C_003E4__this = this;
		T0 val = (T0)1;
		_003C_003Ec__DisplayClass7_.countThread = 0;
		try
		{
			T0 val2 = (T0)AddCart;
			if (val2 != null)
			{
				while (true)
				{
					T0 val3 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val3 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T1 val4 = (T1)0;
				T1 val5 = (T1)(-1);
				T1 val6 = (T1)0;
				while (true)
				{
					T0 val7 = (T0)((nint)val6 < BusinessManager.Count);
					if (val7 == null)
					{
						break;
					}
					T1 val8 = (T1)int.Parse(((int*)(&val6))->ToString());
					BusinessManager[(int)val8].status = frmMain.STATUS.Processing.ToString();
					T0 val9 = (T0)((nint)val4 <= 0);
					if (val9 != null)
					{
						val5 = (T1)(-1);
						T1 val10 = (T1)0;
						while (true)
						{
							T0 val11 = (T0)((nint)val10 < listCart.Count);
							if (val11 != null)
							{
								T0 val12 = (T0)listCart[(int)val10].Status.Equals(frmMain.STATUS.Live.ToString());
								if (val12 == null)
								{
									val10 = (T1)(val10 + 1);
									continue;
								}
								val4 = (T1)NumOfCard;
								val5 = val10;
								listCart[(int)val10].Status = frmMain.STATUS.Processing.ToString();
								break;
							}
							break;
						}
					}
					T0 val13 = (T0)((nint)val5 != -1);
					if (val13 == null)
					{
						BusinessManager[(int)val8].status = "Hết thẻ";
					}
					else
					{
						T2 val14 = (T2)"";
						T2 val15 = (T2)"";
						T2 val16 = (T2)"";
						T2 val17 = (T2)"";
						T2 val18 = (T2)"";
						T0 val19 = (T0)(((IEnumerable<T2>)(object)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })).Count() == 5);
						if (val19 != null)
						{
							val14 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[0];
							val15 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[1];
							val16 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[2];
							val17 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[3];
							val18 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[4];
						}
						else
						{
							val14 = (T2)((string)ChromeControl.getFirstName<T0, T2, T1>() + " " + (string)ChromeControl.getLastName<T0, T2, T1>());
							val15 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[0];
							val16 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[1];
							val17 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[2];
							val18 = (T2)listCart[(int)val5].Card.Split((char[])(object)new T10[1] { (T10)124 })[3];
						}
						val14 = (T2)((string)val14).Replace(" ", "%20");
						val16 = (T2)System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)int.Parse((string)val16)).ToString();
						T0 val20 = (T0)(((string)val17).Length == 2);
						if (val20 != null)
						{
							val17 = (T2)("20" + (string)val17);
						}
						T0 val21 = frm.chrome.addCardToBM<T11, T2, T0, T9, T12>(out strError, (T2)BusinessManager[(int)val8].id, (T2)BusinessManager[(int)val8].payment_account_id, (T2)Country, (T2)Currency, val14, val15, val18, val16, val17);
						if (val21 != null)
						{
							BusinessManager[(int)val8].status = frmMain.STATUS.Done.ToString();
						}
						else
						{
							BusinessManager[(int)val8].status = frmMain.STATUS.lỗi.ToString();
							BusinessManager[(int)val8].message = strError;
						}
						val4 = (T1)(val4 - 1);
					}
					val6 = (T1)(val6 + 1);
				}
			}
			T0 val22 = (T0)CreateAds;
			if (val22 != null)
			{
				while (true)
				{
					T0 val23 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val23 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T1 val24 = (T1)0;
				while (true)
				{
					T0 val25 = (T0)((nint)val24 < BusinessManager.Count);
					if (val25 == null)
					{
						break;
					}
					while (true)
					{
						T0 val26 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread >= intThreadBM);
						if (val26 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val27 = (T0)(!isRunning);
					if (val27 != null)
					{
						break;
					}
					T3 val28 = (T3)new Thread(_003C_003Ec__DisplayClass7_._003CthrStart_003Eb__0<T1, T2, T0, object, List<adaccountsData>>);
					((Thread)val28).Start((object)val24);
					T1 val29 = (T1)_003C_003Ec__DisplayClass7_.countThread;
					_003C_003Ec__DisplayClass7_.countThread = val29 + 1;
					val24 = (T1)(val24 + 1);
				}
			}
			T0 val30 = (T0)SetCardBMToAct;
			if (val30 != null)
			{
				while (true)
				{
					T0 val31 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val31 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T1 val32 = (T1)0;
				while (true)
				{
					T0 val33 = (T0)((nint)val32 < BusinessManager.Count);
					if (val33 == null)
					{
						break;
					}
					while (true)
					{
						T0 val34 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread >= intThreadBM);
						if (val34 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val35 = (T0)(!isRunning);
					if (val35 != null)
					{
						break;
					}
					T3 val36 = (T3)new Thread(_003C_003Ec__DisplayClass7_._003CthrStart_003Eb__1<T1, T2, T0, List<adaccountsData>.Enumerator, object, T11>);
					((Thread)val36).Start((object)val32);
					T1 val29 = (T1)_003C_003Ec__DisplayClass7_.countThread;
					_003C_003Ec__DisplayClass7_.countThread = val29 + 1;
					val32 = (T1)(val32 + 1);
				}
			}
			T0 val37 = (T0)SharePartner;
			if (val37 != null)
			{
				while (true)
				{
					T0 val38 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val38 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T1 val39 = (T1)0;
				while (true)
				{
					T0 val40 = (T0)((nint)val39 < BusinessManager.Count);
					if (val40 == null)
					{
						break;
					}
					while (true)
					{
						T0 val41 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread >= intThreadBM);
						if (val41 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val42 = (T0)(!isRunning);
					if (val42 != null)
					{
						break;
					}
					T3 val43 = (T3)new Thread(_003C_003Ec__DisplayClass7_._003CthrStart_003Eb__2<T1, T0, List<adaccountsData>.Enumerator, object, T11, T2>);
					((Thread)val43).Start((object)val39);
					T1 val29 = (T1)_003C_003Ec__DisplayClass7_.countThread;
					_003C_003Ec__DisplayClass7_.countThread = val29 + 1;
					val39 = (T1)(val39 + 1);
				}
			}
			T0 val44 = (T0)(LinkInvaiteAdmin || LinkInvaiteEmployee);
			if (val44 != null)
			{
				while (true)
				{
					T0 val45 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val45 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T0 val46 = (T0)boolOneBmOneMail;
				if (val46 == null)
				{
					T1 val47 = (T1)0;
					while (true)
					{
						T0 val48 = (T0)((nint)val47 < BusinessManager.Count);
						if (val48 == null)
						{
							break;
						}
						while (true)
						{
							T0 val49 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread >= intThreadBM);
							if (val49 == null)
							{
								break;
							}
							Thread.Sleep(1500);
						}
						T0 val50 = (T0)(!isRunning);
						if (val50 != null)
						{
							break;
						}
						T3 val51 = (T3)new Thread(_003C_003Ec__DisplayClass7_._003CthrStart_003Eb__4<T1, T2, T0, object, T10, T11>);
						((Thread)val51).Start((object)val47);
						T1 val29 = (T1)_003C_003Ec__DisplayClass7_.countThread;
						_003C_003Ec__DisplayClass7_.countThread = val29 + 1;
						val47 = (T1)(val47 + 1);
					}
				}
				else
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_2 = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_;
					_003C_003Ec__DisplayClass7_2.listMail = (List<ListStringData>)Activator.CreateInstance(typeof(T5));
					T2[] array = (T2[])(object)MailDomain.Replace("\r", "").Split((char[])(object)new T10[1] { (T10)10 });
					T2[] array2 = array;
					T1 val52 = (T1)0;
					while ((nint)val52 < array2.Length)
					{
						T2 val53 = (T2)((object[])(object)array2)[(object)val52];
						T2 val54 = (T2)((string)val53).Trim().ToLower();
						T0 val55 = (T0)((string)val54).Contains("|");
						if (val55 != null)
						{
							T2[] array3 = (T2[])(object)((string)val54).Split((char[])(object)new T10[1] { (T10)124 });
							T1 val56 = (T1)0;
							while ((nint)val56 < array3.Length)
							{
								T2 val57 = (T2)((object[])(object)array3)[(object)val56];
								T0 val58 = (T0)((string)val57).Contains("@");
								if (val58 == null)
								{
									val56 = (T1)(val56 + 1);
									continue;
								}
								val54 = val57;
								break;
							}
						}
						T0 val59 = (T0)((string)val54).Contains("@");
						if (val59 != null)
						{
							_003C_003Ec__DisplayClass7_2.listMail.Add(new ListStringData
							{
								str1 = (string)val54,
								str2 = frmMain.STATUS.Ready.ToString()
							});
						}
						val52 = (T1)(val52 + 1);
					}
					T1 val60 = (T1)0;
					while (true)
					{
						T0 val61 = (T0)((nint)val60 < BusinessManager.Count);
						if (val61 == null)
						{
							break;
						}
						while (true)
						{
							T0 val62 = (T0)(isRunning && _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.countThread >= intThreadBM);
							if (val62 == null)
							{
								break;
							}
							Thread.Sleep(1500);
						}
						T0 val63 = (T0)(!isRunning);
						if (val63 != null)
						{
							break;
						}
						T3 val64 = (T3)new Thread(_003C_003Ec__DisplayClass7_2._003CthrStart_003Eb__3<T1, T2, T8, T0, object, T11>);
						((Thread)val64).Start((object)val60);
						T1 val29 = (T1)_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.countThread;
						_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.countThread = val29 + 1;
						val60 = (T1)(val60 + 1);
					}
				}
			}
			T0 val65 = (T0)ShareActToUser;
			if (val65 != null)
			{
				while (true)
				{
					T0 val66 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val66 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T1 val67 = (T1)0;
				while (true)
				{
					T0 val68 = (T0)((nint)val67 < BusinessManager.Count);
					if (val68 == null)
					{
						break;
					}
					while (true)
					{
						T0 val69 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread >= intThreadBM);
						if (val69 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val70 = (T0)(!isRunning);
					if (val70 != null)
					{
						break;
					}
					T3 val71 = (T3)new Thread(_003C_003Ec__DisplayClass7_._003CthrStart_003Eb__5<T1, T0, List<adaccountsData>.Enumerator, object, T11, T2, T12>);
					((Thread)val71).Start((object)val67);
					T1 val29 = (T1)_003C_003Ec__DisplayClass7_.countThread;
					_003C_003Ec__DisplayClass7_.countThread = val29 + 1;
					val67 = (T1)(val67 + 1);
				}
			}
			T0 val72 = (T0)ChangeNameBM;
			if (val72 != null)
			{
				while (true)
				{
					T0 val73 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
					if (val73 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				_003C_003Ec__DisplayClass7_.countThread = 0;
				T1 val74 = (T1)0;
				while (true)
				{
					T0 val75 = (T0)((nint)val74 < BusinessManager.Count);
					if (val75 == null)
					{
						break;
					}
					while (true)
					{
						T0 val76 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread >= intThreadBM);
						if (val76 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val77 = (T0)(!isRunning);
					if (val77 != null)
					{
						break;
					}
					T3 val78 = (T3)new Thread(_003C_003Ec__DisplayClass7_._003CthrStart_003Eb__6<T1, T2, T0, object, T11>);
					((Thread)val78).Start((object)val74);
					T1 val29 = (T1)_003C_003Ec__DisplayClass7_.countThread;
					_003C_003Ec__DisplayClass7_.countThread = val29 + 1;
					val74 = (T1)(val74 + 1);
				}
			}
			T0 val79 = (T0)RemoveBM;
			if (val79 != null)
			{
				T5 val80 = (T5)Activator.CreateInstance(typeof(T5));
				T1 val81 = (T1)0;
				while (true)
				{
					T0 val82 = (T0)((nint)val81 < BusinessManager.Count);
					if (val82 == null)
					{
						break;
					}
					T0 val83 = (T0)(!isRunning);
					if (val83 != null)
					{
						return;
					}
					BusinessManager[(int)val81].message = frmMain.STATUS.Processing.ToString();
					ListStringData listStringData = new ListStringData();
					listStringData.str1 = BusinessManager[(int)val81].id;
					listStringData.str2 = "";
					listStringData.str3 = "";
					((List<ListStringData>)val80).Add(listStringData);
					T0 val84 = (T0)((((List<ListStringData>)val80).Count >= intThreadBM || (nint)val81 == BusinessManager.Count - 1) && ((List<ListStringData>)val80).Count > 0);
					if (val84 != null)
					{
						val = frm.chrome.xoa_bm_Promise<T0, T2, T13, T8, T11, T1, T9, T5>(val80);
						T6 val85 = (T6)BusinessManager.Join((IEnumerable<ListStringData>)val80, (Func<BusinessManagerEntity_businesses_Data, T2>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T2)a.id), (Func<ListStringData, T2>)(object)(Func<ListStringData, string>)((ListStringData d) => (T2)d.str1), (BusinessManagerEntity_businesses_Data a, ListStringData d) => a).ToList();
						T0 val86 = val;
						if (val86 != null)
						{
							T7 enumerator = (T7)((List<BusinessManagerEntity_businesses_Data>)val85).GetEnumerator();
							try
							{
								while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->MoveNext())
								{
									BusinessManagerEntity_businesses_Data current = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))->Current;
									T8 enumerator2 = (T8)((List<ListStringData>)val80).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
										{
											ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
											T0 val87 = (T0)current.id.Equals(current2.str1);
											if (val87 != null)
											{
												current.status = current2.str2;
												current.message = current2.str3;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator2))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator))).Dispose();
							}
						}
						else
						{
							T7 enumerator3 = (T7)((List<BusinessManagerEntity_businesses_Data>)val85).GetEnumerator();
							try
							{
								while (((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))->MoveNext())
								{
									BusinessManagerEntity_businesses_Data current3 = ((List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))->Current;
									current3.status = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<BusinessManagerEntity_businesses_Data>.Enumerator*)(&enumerator3))).Dispose();
							}
						}
						((List<ListStringData>)val80).Clear();
						Thread.Sleep(intDelayBM * 1000);
					}
					val81 = (T1)(val81 + 1);
				}
			}
			while (true)
			{
				T0 val88 = (T0)(isRunning && _003C_003Ec__DisplayClass7_.countThread > 0);
				if (val88 != null)
				{
					Thread.Sleep(1500);
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T2)ex.Message);
		}
		isRunning = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer_auto_refesh_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(!isRunning);
		if (val != null)
		{
			button1.Text = "START";
			button1.BackColor = Color.DodgerBlue;
			timer_auto_refesh.Stop();
			frmMain.infoMessage("Done!");
		}
		gvData.Refresh();
	}

	private void cbAddCart_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCart = cbAddCart.Checked;
		T0 val = (T0)AddCart;
		if (val != null)
		{
			cbAddCart.ForeColor = Color.Red;
		}
		else
		{
			cbAddCart.ForeColor = Color.Black;
		}
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intThreadBM = int.Parse(((decimal)(T0)numThread.Value).ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmBMManager_Load<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0010: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_024d: Expected O, but got I4
		//IL_02ba: Expected O, but got I4
		//IL_0328: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_0406: Expected O, but got I4
		//IL_04ef: Expected O, but got I4
		//IL_055e: Expected O, but got I4
		//IL_05cd: Expected O, but got I4
		//IL_063c: Expected O, but got I4
		//IL_06ab: Expected O, but got I4
		//IL_071a: Expected O, but got I4
		//IL_09eb: Expected O, but got I4
		try
		{
			T0 val = (T0)(frm.chrome != null);
			if (val != null)
			{
				T0 val2 = (T0)(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadBM == 0);
				if (val2 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadBM = 10;
				}
				numThread.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadBM;
				intThreadBM = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadBM;
				txtBMPartner.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMPartner;
				txtMailDomain.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtMailDomain;
				txtBMName.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMName;
				numDelayBM.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intDelayBM;
				cbOneBmOneMail.Checked = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].boolOneBmOneMail;
				T0 val3 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameAdsBM);
				if (val3 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameAdsBM = "HEY";
				}
				T0 val4 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryAdsBM);
				if (val4 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryAdsBM = "US";
				}
				T0 val5 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZoneAdsBM);
				if (val5 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZoneAdsBM = "Asia/Bangkok";
				}
				T0 val6 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyAdsBM);
				if (val6 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyAdsBM = "USD";
				}
				T0 val7 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddressAdsBM);
				if (val7 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddressAdsBM = "312 Fayette St";
				}
				T0 val8 = (T0)(string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtStateAdsBM) && !string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryAdsBM) && frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryAdsBM.ToLower().Equals("us"));
				if (val8 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtStateAdsBM = "NY";
				}
				T0 val9 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZipAdsBM);
				if (val9 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZipAdsBM = "13104";
				}
				T0 val10 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCityAdsBM);
				if (val10 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCityAdsBM = "Manlius";
				}
				T0 val11 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryBM);
				if (val11 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryBM = "US";
				}
				T0 val12 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyBM);
				if (val12 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyBM = "USD";
				}
				T0 val13 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtActByBM10);
				if (val13 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtActByBM10 = "";
				}
				txtNameAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameAdsBM;
				txtCountryAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryAdsBM;
				txtTimeZoneAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZoneAdsBM;
				txtCurrencyAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyAdsBM;
				txtAddressAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddressAdsBM;
				txtStateAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtStateAdsBM;
				txtZipAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZipAdsBM;
				txtCityAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCityAdsBM;
				txtCountry.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryBM;
				txtCurrency.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyBM;
				txtActByBM10.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtActByBM10;
				T0 val14 = (T0)(BusinessManager != null && BusinessManager.Count == 1);
				if (val14 != null)
				{
					txtBMName.Text = BusinessManager.First().name;
				}
			}
		}
		catch
		{
		}
	}

	private void frmBMManager_FormClosing<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0010: Expected O, but got I4
		try
		{
			T0 val = (T0)(frm.chrome != null);
			if (val != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadBM = intThreadBM;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intDelayBM = intDelayBM;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMPartner = txtBMPartner.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtMailDomain = txtMailDomain.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMName = txtBMName.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameAdsBM = txtNameAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryAdsBM = txtCountryAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZoneAdsBM = txtTimeZoneAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyAdsBM = txtCurrencyAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddressAdsBM = txtAddressAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtStateAdsBM = txtStateAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZipAdsBM = txtZipAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCityAdsBM = txtCityAds.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].boolOneBmOneMail = cbOneBmOneMail.Checked;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountryBM = txtCountry.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrencyBM = txtCurrency.Text;
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtActByBM10 = txtActByBM10.Text;
			}
		}
		catch
		{
		}
		frmMain.settingSaving();
	}

	private void txtCountry_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Country = txtCountry.Text;
	}

	private void txtCurrency_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Currency = txtCurrency.Text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtCard_TextChanged<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		listCart.Clear();
		T0[] lines = (T0[])(object)txtCard.Lines;
		T1 val = (T1)0;
		while ((nint)val < lines.Length)
		{
			T0 val2 = (T0)((object[])(object)lines)[(object)val];
			T2 val3 = (T2)(!string.IsNullOrWhiteSpace((string)val2));
			if (val3 != null)
			{
				T2 val4 = (T2)(((string)val2).Contains("|") && (((IEnumerable<T0>)(object)((string)val2).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 5 || ((IEnumerable<T0>)(object)((string)val2).Split((char[])(object)new T5[1] { (T5)124 })).Count() == 4));
				if (val4 != null)
				{
					listCart.Add(new ClassCard
					{
						STT = listCart.Count + 1,
						Card = ((string)val2).Trim(),
						Status = frmMain.STATUS.Live.ToString()
					});
				}
			}
			val = (T1)(val + 1);
		}
	}

	private void cbCreateAds_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		CreateAds = cbCreateAds.Checked;
		T0 val = (T0)CreateAds;
		if (val == null)
		{
			cbCreateAds.ForeColor = Color.Black;
		}
		else
		{
			cbCreateAds.ForeColor = Color.Red;
		}
	}

	private void txtNameAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		NameAds = txtNameAds.Text;
	}

	private void txtCountryAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		CountryAds = txtCountryAds.Text;
	}

	private void txtTimeZoneAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		TimeZoneAds = txtTimeZoneAds.Text;
	}

	private void txtCurrencyAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		CurrencyAds = txtCurrencyAds.Text;
	}

	private void txtAddressAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		AddressAds = txtAddressAds.Text;
	}

	private void txtStateAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		StateAds = txtStateAds.Text;
	}

	private void txtCityAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		CityAds = txtCityAds.Text;
	}

	private void txtZipAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		ZipAds = txtZipAds.Text;
	}

	private void cbSetCardBMToAct_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SetCardBMToAct = cbSetCardBMToAct.Checked;
		T0 val = (T0)SetCardBMToAct;
		if (val != null)
		{
			cbSetCardBMToAct.ForeColor = Color.Red;
		}
		else
		{
			cbSetCardBMToAct.ForeColor = Color.Black;
		}
	}

	private void numNumOfCard_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		NumOfCard = int.Parse(((decimal)(T0)numNumOfCard.Value).ToString());
	}

	private void cbSharePartner_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SharePartner = cbSharePartner.Checked;
		T0 val = (T0)SharePartner;
		if (val != null)
		{
			cbSharePartner.ForeColor = Color.Red;
		}
		else
		{
			cbSharePartner.ForeColor = Color.Black;
		}
	}

	private void txtBMPartner_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BMPartner = txtBMPartner.Text;
	}

	private void cbLinkInvaite_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		LinkInvaiteAdmin = cbLinkInvaiteAdmin.Checked;
		T0 val = (T0)LinkInvaiteAdmin;
		if (val != null)
		{
			cbLinkInvaiteAdmin.ForeColor = Color.Red;
		}
		else
		{
			cbLinkInvaiteAdmin.ForeColor = Color.Black;
		}
	}

	private void txtMailDomain_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		MailDomain = txtMailDomain.Text;
	}

	private void cbShareActToUser_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShareActToUser = cbShareActToUser.Checked;
		T0 val = (T0)ShareActToUser;
		if (val != null)
		{
			cbShareActToUser.ForeColor = Color.Red;
		}
		else
		{
			cbShareActToUser.ForeColor = Color.Black;
		}
	}

	private void cbChangeNameBM_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ChangeNameBM = cbChangeNameBM.Checked;
		T0 val = (T0)ChangeNameBM;
		if (val == null)
		{
			cbChangeNameBM.ForeColor = Color.Black;
		}
		else
		{
			cbChangeNameBM.ForeColor = Color.Red;
		}
	}

	private void txtBMName_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BMName = txtBMName.Text;
	}

	private void txtActByBM10_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		ActByBM10 = txtActByBM10.Text;
	}

	private void cbLinkInvaiteEmployee_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		LinkInvaiteEmployee = cbLinkInvaiteEmployee.Checked;
		T0 val = (T0)LinkInvaiteEmployee;
		if (val != null)
		{
			cbLinkInvaiteEmployee.ForeColor = Color.Red;
		}
		else
		{
			cbLinkInvaiteEmployee.ForeColor = Color.Black;
		}
	}

	private void numDelayBM_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intDelayBM = int.Parse(((decimal)(T0)numDelayBM.Value).ToString());
	}

	private void cbOneBmOneMail_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		boolOneBmOneMail = cbOneBmOneMail.Checked;
	}

	private void cbRemoveBM_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveBM = cbRemoveBM.Checked;
		T0 val = (T0)RemoveBM;
		if (val != null)
		{
			cbRemoveBM.ForeColor = Color.Red;
		}
		else
		{
			cbRemoveBM.ForeColor = Color.Black;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmBMManager));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotal = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.groupBox1 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.numNumOfCard = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label13 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCard = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbAddCart = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCurrency = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCountry = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.groupBox2 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.txtActByBM10 = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label14 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtZipAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label12 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCityAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label11 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtStateAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label10 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtAddressAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label9 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtNameAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label8 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtTimeZoneAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label7 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCurrencyAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label6 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCountryAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbCreateAds = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbSetCardBMToAct = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbSharePartner = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtBMPartner = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtMailDomain = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbLinkInvaiteAdmin = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbShareActToUser = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtBMName = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbChangeNameBM = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label15 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbLinkInvaiteEmployee = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.numDelayBM = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label16 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbOneBmOneMail = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbRemoveBM = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		this.statusStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numNumOfCard).BeginInit();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelayBM).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AllowUserToOrderColumns = true;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(4, 5);
		this.gvData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.gvData.Name = "gvData";
		this.gvData.RowHeadersWidth = 51;
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(467, 768);
		this.gvData.TabIndex = 5;
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T12[2]
		{
			(T12)this.toolStripStatusLabel1,
			(T12)this.lbTotal
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 793);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
		this.statusStrip1.Size = new System.Drawing.Size(1027, 26);
		this.statusStrip1.TabIndex = 6;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(18, 20);
		this.lbTotal.Text = "0";
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(175, 743);
		this.numThread.Margin = new System.Windows.Forms.Padding(4);
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(84, 22);
		this.numThread.TabIndex = 41;
		this.numThread.Value = new decimal((int[])(object)new T13[4]
		{
			(T13)1,
			default(T13),
			default(T13),
			default(T13)
		});
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T14, T15, T16>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(113, 745);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 16);
		this.label2.TabIndex = 40;
		this.label2.Text = "Luồng:";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.DodgerBlue;
		this.button1.Location = new System.Drawing.Point(420, 708);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 65);
		this.button1.TabIndex = 37;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click<T17, T15, T16>);
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer_auto_refesh_Tick<T17, T15, T16>);
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.numNumOfCard);
		this.groupBox1.Controls.Add(this.label13);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.txtCard);
		this.groupBox1.Controls.Add(this.cbAddCart);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.txtCurrency);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.txtCountry);
		this.groupBox1.Location = new System.Drawing.Point(41, 5);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox1.Size = new System.Drawing.Size(479, 254);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.numNumOfCard.ForeColor = System.Drawing.Color.Blue;
		this.numNumOfCard.Location = new System.Drawing.Point(127, 81);
		this.numNumOfCard.Margin = new System.Windows.Forms.Padding(4);
		this.numNumOfCard.Maximum = new decimal((int[])(object)new T13[4]
		{
			(T13)999999,
			default(T13),
			default(T13),
			default(T13)
		});
		this.numNumOfCard.Name = "numNumOfCard";
		this.numNumOfCard.Size = new System.Drawing.Size(96, 22);
		this.numNumOfCard.TabIndex = 10;
		this.numNumOfCard.Value = new decimal((int[])(object)new T13[4]
		{
			(T13)10,
			default(T13),
			default(T13),
			default(T13)
		});
		this.numNumOfCard.ValueChanged += new System.EventHandler(numNumOfCard_ValueChanged<T14, T15, T16>);
		this.label13.AutoSize = true;
		this.label13.ForeColor = System.Drawing.Color.Blue;
		this.label13.Location = new System.Drawing.Point(8, 84);
		this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(107, 16);
		this.label13.TabIndex = 9;
		this.label13.Text = "Số lượt add/1thẻ:";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(8, 110);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(236, 17);
		this.label4.TabIndex = 7;
		this.label4.Text = "Paste \"Name|Code|Month|Year|CVV\"";
		this.txtCard.Location = new System.Drawing.Point(12, 129);
		this.txtCard.Margin = new System.Windows.Forms.Padding(4);
		this.txtCard.Multiline = true;
		this.txtCard.Name = "txtCard";
		this.txtCard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtCard.Size = new System.Drawing.Size(436, 109);
		this.txtCard.TabIndex = 6;
		this.txtCard.TextChanged += new System.EventHandler(txtCard_TextChanged<T18, T13, T17, T15, T16, T19>);
		this.cbAddCart.AutoSize = true;
		this.cbAddCart.Location = new System.Drawing.Point(12, 23);
		this.cbAddCart.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCart.Name = "cbAddCart";
		this.cbAddCart.Size = new System.Drawing.Size(124, 20);
		this.cbAddCart.TabIndex = 5;
		this.cbAddCart.Text = "Add thẻ vào BM";
		this.cbAddCart.UseVisualStyleBackColor = true;
		this.cbAddCart.CheckedChanged += new System.EventHandler(cbAddCart_CheckedChanged<T17, T15, T16>);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(231, 55);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(51, 16);
		this.label3.TabIndex = 3;
		this.label3.Text = "Tiền tệ:";
		this.txtCurrency.Location = new System.Drawing.Point(296, 52);
		this.txtCurrency.Margin = new System.Windows.Forms.Padding(4);
		this.txtCurrency.Name = "txtCurrency";
		this.txtCurrency.Size = new System.Drawing.Size(152, 22);
		this.txtCurrency.TabIndex = 2;
		this.txtCurrency.TextChanged += new System.EventHandler(txtCurrency_TextChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(8, 55);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(55, 16);
		this.label1.TabIndex = 1;
		this.label1.Text = "Country:";
		this.txtCountry.Location = new System.Drawing.Point(77, 52);
		this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
		this.txtCountry.Name = "txtCountry";
		this.txtCountry.Size = new System.Drawing.Size(144, 22);
		this.txtCountry.TabIndex = 0;
		this.txtCountry.TextChanged += new System.EventHandler(txtCountry_TextChanged);
		this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox2.Controls.Add(this.txtActByBM10);
		this.groupBox2.Controls.Add(this.label14);
		this.groupBox2.Controls.Add(this.txtZipAds);
		this.groupBox2.Controls.Add(this.label12);
		this.groupBox2.Controls.Add(this.txtCityAds);
		this.groupBox2.Controls.Add(this.label11);
		this.groupBox2.Controls.Add(this.txtStateAds);
		this.groupBox2.Controls.Add(this.label10);
		this.groupBox2.Controls.Add(this.txtAddressAds);
		this.groupBox2.Controls.Add(this.label9);
		this.groupBox2.Controls.Add(this.txtNameAds);
		this.groupBox2.Controls.Add(this.label8);
		this.groupBox2.Controls.Add(this.txtTimeZoneAds);
		this.groupBox2.Controls.Add(this.label7);
		this.groupBox2.Controls.Add(this.txtCurrencyAds);
		this.groupBox2.Controls.Add(this.label6);
		this.groupBox2.Controls.Add(this.txtCountryAds);
		this.groupBox2.Controls.Add(this.label5);
		this.groupBox2.Controls.Add(this.cbCreateAds);
		this.groupBox2.Location = new System.Drawing.Point(41, 267);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox2.Size = new System.Drawing.Size(479, 218);
		this.groupBox2.TabIndex = 0;
		this.groupBox2.TabStop = false;
		this.txtActByBM10.Location = new System.Drawing.Point(128, 172);
		this.txtActByBM10.Margin = new System.Windows.Forms.Padding(4);
		this.txtActByBM10.Name = "txtActByBM10";
		this.txtActByBM10.Size = new System.Drawing.Size(320, 22);
		this.txtActByBM10.TabIndex = 18;
		this.txtActByBM10.TextChanged += new System.EventHandler(txtActByBM10_TextChanged);
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(8, 176);
		this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(100, 16);
		this.label14.TabIndex = 17;
		this.label14.Text = "Tạo tk theo BM:";
		this.txtZipAds.Location = new System.Drawing.Point(359, 140);
		this.txtZipAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtZipAds.Name = "txtZipAds";
		this.txtZipAds.Size = new System.Drawing.Size(89, 22);
		this.txtZipAds.TabIndex = 16;
		this.txtZipAds.TextChanged += new System.EventHandler(txtZipAds_TextChanged);
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(280, 144);
		this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(29, 16);
		this.label12.TabIndex = 15;
		this.label12.Text = "Zip:";
		this.txtCityAds.Location = new System.Drawing.Point(73, 140);
		this.txtCityAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtCityAds.Name = "txtCityAds";
		this.txtCityAds.Size = new System.Drawing.Size(201, 22);
		this.txtCityAds.TabIndex = 14;
		this.txtCityAds.TextChanged += new System.EventHandler(txtCityAds_TextChanged);
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(8, 144);
		this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(32, 16);
		this.label11.TabIndex = 13;
		this.label11.Text = "City:";
		this.txtStateAds.Location = new System.Drawing.Point(359, 108);
		this.txtStateAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtStateAds.Name = "txtStateAds";
		this.txtStateAds.Size = new System.Drawing.Size(89, 22);
		this.txtStateAds.TabIndex = 12;
		this.txtStateAds.TextChanged += new System.EventHandler(txtStateAds_TextChanged);
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(280, 112);
		this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(41, 16);
		this.label10.TabIndex = 11;
		this.label10.Text = "State:";
		this.txtAddressAds.Location = new System.Drawing.Point(73, 108);
		this.txtAddressAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtAddressAds.Name = "txtAddressAds";
		this.txtAddressAds.Size = new System.Drawing.Size(201, 22);
		this.txtAddressAds.TabIndex = 10;
		this.txtAddressAds.TextChanged += new System.EventHandler(txtAddressAds_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(8, 112);
		this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(50, 16);
		this.label9.TabIndex = 9;
		this.label9.Text = "Địa chỉ:";
		this.txtNameAds.Location = new System.Drawing.Point(73, 44);
		this.txtNameAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtNameAds.Name = "txtNameAds";
		this.txtNameAds.Size = new System.Drawing.Size(201, 22);
		this.txtNameAds.TabIndex = 8;
		this.txtNameAds.TextChanged += new System.EventHandler(txtNameAds_TextChanged);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(8, 48);
		this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(54, 16);
		this.label8.TabIndex = 7;
		this.label8.Text = "Tên TK:";
		this.txtTimeZoneAds.Location = new System.Drawing.Point(73, 76);
		this.txtTimeZoneAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtTimeZoneAds.Name = "txtTimeZoneAds";
		this.txtTimeZoneAds.Size = new System.Drawing.Size(201, 22);
		this.txtTimeZoneAds.TabIndex = 6;
		this.txtTimeZoneAds.TextChanged += new System.EventHandler(txtTimeZoneAds_TextChanged);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(8, 80);
		this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(53, 16);
		this.label7.TabIndex = 5;
		this.label7.Text = "Múi giờ:";
		this.txtCurrencyAds.Location = new System.Drawing.Point(359, 76);
		this.txtCurrencyAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtCurrencyAds.Name = "txtCurrencyAds";
		this.txtCurrencyAds.Size = new System.Drawing.Size(89, 22);
		this.txtCurrencyAds.TabIndex = 4;
		this.txtCurrencyAds.TextChanged += new System.EventHandler(txtCurrencyAds_TextChanged);
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(280, 80);
		this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(51, 16);
		this.label6.TabIndex = 3;
		this.label6.Text = "Tiền tệ:";
		this.txtCountryAds.Location = new System.Drawing.Point(359, 44);
		this.txtCountryAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtCountryAds.Name = "txtCountryAds";
		this.txtCountryAds.Size = new System.Drawing.Size(89, 22);
		this.txtCountryAds.TabIndex = 2;
		this.txtCountryAds.TextChanged += new System.EventHandler(txtCountryAds_TextChanged);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(280, 48);
		this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(64, 16);
		this.label5.TabIndex = 1;
		this.label5.Text = "Quốc gia:";
		this.cbCreateAds.AutoSize = true;
		this.cbCreateAds.Location = new System.Drawing.Point(8, 16);
		this.cbCreateAds.Margin = new System.Windows.Forms.Padding(4);
		this.cbCreateAds.Name = "cbCreateAds";
		this.cbCreateAds.Size = new System.Drawing.Size(178, 20);
		this.cbCreateAds.TabIndex = 0;
		this.cbCreateAds.Text = "Tạo tài khoản quảng cáo";
		this.cbCreateAds.UseVisualStyleBackColor = true;
		this.cbCreateAds.CheckedChanged += new System.EventHandler(cbCreateAds_CheckedChanged<T17, T15, T16>);
		this.cbSetCardBMToAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbSetCardBMToAct.AutoSize = true;
		this.cbSetCardBMToAct.Location = new System.Drawing.Point(44, 494);
		this.cbSetCardBMToAct.Margin = new System.Windows.Forms.Padding(4);
		this.cbSetCardBMToAct.Name = "cbSetCardBMToAct";
		this.cbSetCardBMToAct.Size = new System.Drawing.Size(162, 20);
		this.cbSetCardBMToAct.TabIndex = 43;
		this.cbSetCardBMToAct.Text = "Đẩy thẻ BM vào TKQC";
		this.cbSetCardBMToAct.UseVisualStyleBackColor = true;
		this.cbSetCardBMToAct.CheckedChanged += new System.EventHandler(cbSetCardBMToAct_CheckedChanged<T17, T15, T16>);
		this.cbSharePartner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbSharePartner.AutoSize = true;
		this.cbSharePartner.Location = new System.Drawing.Point(43, 522);
		this.cbSharePartner.Margin = new System.Windows.Forms.Padding(4);
		this.cbSharePartner.Name = "cbSharePartner";
		this.cbSharePartner.Size = new System.Drawing.Size(175, 20);
		this.cbSharePartner.TabIndex = 44;
		this.cbSharePartner.Text = "Share TKQC cho đối tác:";
		this.cbSharePartner.UseVisualStyleBackColor = true;
		this.cbSharePartner.CheckedChanged += new System.EventHandler(cbSharePartner_CheckedChanged<T17, T15, T16>);
		this.txtBMPartner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.txtBMPartner.Location = new System.Drawing.Point(236, 520);
		this.txtBMPartner.Margin = new System.Windows.Forms.Padding(4);
		this.txtBMPartner.Name = "txtBMPartner";
		this.txtBMPartner.Size = new System.Drawing.Size(259, 22);
		this.txtBMPartner.TabIndex = 11;
		this.txtBMPartner.TextChanged += new System.EventHandler(txtBMPartner_TextChanged);
		this.txtMailDomain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.txtMailDomain.Location = new System.Drawing.Point(169, 615);
		this.txtMailDomain.Margin = new System.Windows.Forms.Padding(4);
		this.txtMailDomain.Multiline = true;
		this.txtMailDomain.Name = "txtMailDomain";
		this.txtMailDomain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtMailDomain.Size = new System.Drawing.Size(325, 75);
		this.txtMailDomain.TabIndex = 45;
		this.txtMailDomain.TextChanged += new System.EventHandler(txtMailDomain_TextChanged);
		this.cbLinkInvaiteAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbLinkInvaiteAdmin.AutoSize = true;
		this.cbLinkInvaiteAdmin.Location = new System.Drawing.Point(133, 586);
		this.cbLinkInvaiteAdmin.Margin = new System.Windows.Forms.Padding(4);
		this.cbLinkInvaiteAdmin.Name = "cbLinkInvaiteAdmin";
		this.cbLinkInvaiteAdmin.Size = new System.Drawing.Size(67, 20);
		this.cbLinkInvaiteAdmin.TabIndex = 46;
		this.cbLinkInvaiteAdmin.Text = "Admin";
		this.cbLinkInvaiteAdmin.UseVisualStyleBackColor = true;
		this.cbLinkInvaiteAdmin.CheckedChanged += new System.EventHandler(cbLinkInvaite_CheckedChanged<T17, T15, T16>);
		this.cbShareActToUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbShareActToUser.AutoSize = true;
		this.cbShareActToUser.Location = new System.Drawing.Point(236, 494);
		this.cbShareActToUser.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareActToUser.Name = "cbShareActToUser";
		this.cbShareActToUser.Size = new System.Drawing.Size(209, 20);
		this.cbShareActToUser.TabIndex = 47;
		this.cbShareActToUser.Text = "Share TKQC cho toàn bộ User";
		this.cbShareActToUser.UseVisualStyleBackColor = true;
		this.cbShareActToUser.CheckedChanged += new System.EventHandler(cbShareActToUser_CheckedChanged<T17, T15, T16>);
		this.txtBMName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.txtBMName.Location = new System.Drawing.Point(151, 552);
		this.txtBMName.Margin = new System.Windows.Forms.Padding(4);
		this.txtBMName.Name = "txtBMName";
		this.txtBMName.Size = new System.Drawing.Size(344, 22);
		this.txtBMName.TabIndex = 48;
		this.txtBMName.TextChanged += new System.EventHandler(txtBMName_TextChanged);
		this.cbChangeNameBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbChangeNameBM.AutoSize = true;
		this.cbChangeNameBM.Location = new System.Drawing.Point(44, 554);
		this.cbChangeNameBM.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangeNameBM.Name = "cbChangeNameBM";
		this.cbChangeNameBM.Size = new System.Drawing.Size(93, 20);
		this.cbChangeNameBM.TabIndex = 49;
		this.cbChangeNameBM.Text = "Đổi tên BM";
		this.cbChangeNameBM.UseVisualStyleBackColor = true;
		this.cbChangeNameBM.CheckedChanged += new System.EventHandler(cbChangeNameBM_CheckedChanged<T17, T15, T16>);
		this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(29, 587);
		this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(83, 16);
		this.label15.TabIndex = 19;
		this.label15.Text = "Tạo link mời:";
		this.cbLinkInvaiteEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbLinkInvaiteEmployee.AutoSize = true;
		this.cbLinkInvaiteEmployee.Location = new System.Drawing.Point(219, 586);
		this.cbLinkInvaiteEmployee.Margin = new System.Windows.Forms.Padding(4);
		this.cbLinkInvaiteEmployee.Name = "cbLinkInvaiteEmployee";
		this.cbLinkInvaiteEmployee.Size = new System.Drawing.Size(89, 20);
		this.cbLinkInvaiteEmployee.TabIndex = 50;
		this.cbLinkInvaiteEmployee.Text = "Nhân viên";
		this.cbLinkInvaiteEmployee.UseVisualStyleBackColor = true;
		this.cbLinkInvaiteEmployee.CheckedChanged += new System.EventHandler(cbLinkInvaiteEmployee_CheckedChanged<T17, T15, T16>);
		this.numDelayBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numDelayBM.Location = new System.Drawing.Point(328, 743);
		this.numDelayBM.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayBM.Name = "numDelayBM";
		this.numDelayBM.Size = new System.Drawing.Size(84, 22);
		this.numDelayBM.TabIndex = 52;
		this.numDelayBM.Value = new decimal((int[])(object)new T13[4]
		{
			(T13)1,
			default(T13),
			default(T13),
			default(T13)
		});
		this.numDelayBM.ValueChanged += new System.EventHandler(numDelayBM_ValueChanged<T14, T15, T16>);
		this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(267, 745);
		this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(46, 16);
		this.label16.TabIndex = 51;
		this.label16.Text = "Delay:";
		this.cbOneBmOneMail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbOneBmOneMail.AutoSize = true;
		this.cbOneBmOneMail.Location = new System.Drawing.Point(44, 617);
		this.cbOneBmOneMail.Margin = new System.Windows.Forms.Padding(4);
		this.cbOneBmOneMail.Name = "cbOneBmOneMail";
		this.cbOneBmOneMail.Size = new System.Drawing.Size(112, 20);
		this.cbOneBmOneMail.TabIndex = 53;
		this.cbOneBmOneMail.Text = "Mỗi BM 1 mail";
		this.cbOneBmOneMail.UseVisualStyleBackColor = true;
		this.cbOneBmOneMail.CheckedChanged += new System.EventHandler(cbOneBmOneMail_CheckedChanged);
		this.cbRemoveBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cbRemoveBM.AutoSize = true;
		this.cbRemoveBM.Location = new System.Drawing.Point(44, 697);
		this.cbRemoveBM.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveBM.Name = "cbRemoveBM";
		this.cbRemoveBM.Size = new System.Drawing.Size(104, 20);
		this.cbRemoveBM.TabIndex = 54;
		this.cbRemoveBM.Text = "Xóa khỏi BM";
		this.cbRemoveBM.UseVisualStyleBackColor = true;
		this.cbRemoveBM.CheckedChanged += new System.EventHandler(cbRemoveBM_CheckedChanged<T17, T15, T16>);
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.Location = new System.Drawing.Point(12, 12);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.gvData);
		this.splitContainer1.Panel2.AutoScroll = true;
		this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
		this.splitContainer1.Panel2.Controls.Add(this.numDelayBM);
		this.splitContainer1.Panel2.Controls.Add(this.cbRemoveBM);
		this.splitContainer1.Panel2.Controls.Add(this.label16);
		this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
		this.splitContainer1.Panel2.Controls.Add(this.numThread);
		this.splitContainer1.Panel2.Controls.Add(this.cbOneBmOneMail);
		this.splitContainer1.Panel2.Controls.Add(this.label2);
		this.splitContainer1.Panel2.Controls.Add(this.txtMailDomain);
		this.splitContainer1.Panel2.Controls.Add(this.button1);
		this.splitContainer1.Panel2.Controls.Add(this.cbSetCardBMToAct);
		this.splitContainer1.Panel2.Controls.Add(this.cbSharePartner);
		this.splitContainer1.Panel2.Controls.Add(this.cbLinkInvaiteEmployee);
		this.splitContainer1.Panel2.Controls.Add(this.txtBMPartner);
		this.splitContainer1.Panel2.Controls.Add(this.label15);
		this.splitContainer1.Panel2.Controls.Add(this.cbLinkInvaiteAdmin);
		this.splitContainer1.Panel2.Controls.Add(this.txtBMName);
		this.splitContainer1.Panel2.Controls.Add(this.cbShareActToUser);
		this.splitContainer1.Panel2.Controls.Add(this.cbChangeNameBM);
		this.splitContainer1.Size = new System.Drawing.Size(1003, 778);
		this.splitContainer1.SplitterDistance = 475;
		this.splitContainer1.TabIndex = 55;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1027, 819);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.statusStrip1);
		base.Icon = (System.Drawing.Icon)(T20)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmBMManager";
		this.Text = "frmBMManager";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmBMManager_FormClosing<T17, T15, T21>);
		base.Load += new System.EventHandler(frmBMManager_Load<T17, T15, T16>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numNumOfCard).EndInit();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelayBM).EndInit();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
