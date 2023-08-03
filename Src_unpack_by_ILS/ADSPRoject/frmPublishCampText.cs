using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using ADSPRoject.BinGen;
using ADSPRoject.Data;
using ADSPRoject.License;
using ADSPRoject.Server;
using CreditCardValidator;
using Newtonsoft.Json;
using OpenQA.Selenium;

namespace ADSPRoject;

public class frmPublishCampText : Form
{
	public enum STATUS
	{
		Ready,
		Reseted,
		Clearing,
		Cleared,
		Processing,
		Importing,
		Imported,
		Pulish,
		Pulish_lỗi,
		Pulish_Done,
		Done,
		Removed,
		lỗi
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass180_0
	{
		public object sender;

		public frmPublishCampText _003C_003E4__this;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CpasteCCEvent_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7>(T5 param)
		{
			//IL_000f: Expected O, but got I4
			//IL_0038: Expected O, but got I4
			//IL_003f: Expected O, but got I4
			//IL_0079: Expected O, but got I4
			//IL_00eb: Expected O, but got I4
			//IL_016c: Expected O, but got I4
			//IL_01c0: Expected O, but got I4
			//IL_0206: Expected O, but got I4
			//IL_020c: Expected O, but got I4
			//IL_021b: Expected O, but got I4
			//IL_02d2: Expected O, but got I4
			//IL_02e9: Expected I4, but got O
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Expected O, but got Unknown
			//IL_036c: Expected O, but got I4
			//IL_038e: Expected O, but got I4
			//IL_03b1: Expected O, but got I4
			//IL_0445: Unknown result type (might be due to invalid IL or missing references)
			//IL_0448: Expected O, but got Unknown
			//IL_044f: Expected O, but got I4
			//IL_0459: Unknown result type (might be due to invalid IL or missing references)
			//IL_045c: Expected O, but got Unknown
			try
			{
				object obj = sender;
				T0 val = (T0)((obj is T0) ? obj : null);
				T1 val2 = (T1)1;
				T3 val3 = (T3)(((MenuItem)val).Text.Equals("Paste Number|Exp_month|Exp_year|Security x10") || ((MenuItem)val).Text.Equals("Paste Number|Exp_month|Exp_year|Security x10 + Xóa"));
				if (val3 != null)
				{
					val2 = (T1)10;
				}
				_003C_003E4__this.rbListCard.Checked = true;
				T3 val4 = (T3)(((MenuItem)val).Text.Equals("Paste Number|Exp_month|Exp_year|Security + Xóa") || ((MenuItem)val).Text.Equals("Paste Number|Exp_month|Exp_year|Security x10 + Xóa"));
				if (val4 != null)
				{
					_003C_003E4__this.gvCard.DataSource = null;
					_003C_003E4__this.frm.chrome.frmMain.listFBEntity[_003C_003E4__this.frm.chrome.indexEntity].listCard.Clear();
				}
				T2 text = (T2)Clipboard.GetText();
				T2[] array = (T2[])(object)((string)text).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				CreditCardEntity creditCardEntity = null;
				T1 val5 = (T1)1;
				T3 val6 = (T3)(_003C_003E4__this.frm.chrome.frmMain.listFBEntity[_003C_003E4__this.frm.chrome.indexEntity].listCard != null && _003C_003E4__this.frm.chrome.frmMain.listFBEntity[_003C_003E4__this.frm.chrome.indexEntity].listCard.Count > 0);
				if (val6 != null)
				{
					T3 val7 = (T3)(!string.IsNullOrWhiteSpace(_003C_003E4__this.frm.chrome.frmMain.listFBEntity[_003C_003E4__this.frm.chrome.indexEntity].listCard.First().Card_Number));
					if (val7 != null)
					{
						val5 = (T1)(_003C_003E4__this.frm.chrome.frmMain.listFBEntity[_003C_003E4__this.frm.chrome.indexEntity].listCard.Count + 1);
					}
				}
				T2[] array2 = array;
				T1 val8 = (T1)0;
				while ((nint)val8 < array2.Length)
				{
					T2 val9 = (T2)((object[])(object)array2)[(object)val8];
					T1 val10 = (T1)0;
					while (true)
					{
						T3 val11 = (T3)(val10 < val2);
						if (val11 == null)
						{
							break;
						}
						T2 val12 = (T2)((string)val9).Replace(" ", "");
						val12 = (T2)((string)val12).Replace("\\", "|").Replace("/", "|").Replace("[", "|")
							.Replace(" ", "")
							.Replace("Live|", "")
							.Replace("|BIN:---]|GATE:01]@/ChkNET-ID", "");
						T3 val13 = (T3)(!string.IsNullOrEmpty((string)val12) && ((string)val12).Contains("|") && ((string)val12).Split((char[])(object)new T4[1] { (T4)124 }).Length >= 4);
						if (val13 != null)
						{
							creditCardEntity = new CreditCardEntity
							{
								Row = (int)val5
							};
							val5 = (T1)(val5 + 1);
							creditCardEntity.Card_Number = ((string)val12).Split((char[])(object)new T4[1] { (T4)124 })[0];
							creditCardEntity.Exp_Month = ((string)val12).Split((char[])(object)new T4[1] { (T4)124 })[1];
							creditCardEntity.Exp_Year = ((string)val12).Split((char[])(object)new T4[1] { (T4)124 })[2];
							creditCardEntity.Card_Security = ((string)val12).Split((char[])(object)new T4[1] { (T4)124 })[3];
							T3 val14 = (T3)(creditCardEntity.Exp_Year.Length > 2);
							if (val14 != null)
							{
								creditCardEntity.Exp_Year = System.Runtime.CompilerServices.Unsafe.As<T4, char>(ref (T4)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 2]).ToString() + System.Runtime.CompilerServices.Unsafe.As<T4, char>(ref (T4)creditCardEntity.Exp_Year[creditCardEntity.Exp_Year.Length - 1]);
							}
							creditCardEntity.Status = frmMain.STATUS.Ready.ToString();
							creditCardEntity.UID = "";
							creditCardEntity.int_random = _003C_003E4__this.rnd.Next(1, 99999);
							_003C_003E4__this.frm.chrome.frmMain.listFBEntity[_003C_003E4__this.frm.chrome.indexEntity].listCard.Add(creditCardEntity);
						}
						val10 = (T1)(val10 + 1);
					}
					val8 = (T1)(val8 + 1);
				}
				_003C_003E4__this.loadCC<T3, T1, T6, T7>();
			}
			catch
			{
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass199_0
	{
		public frmPublishCampText _003C_003E4__this;

		public MenuItem mi;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CpasteJsonEvent_003Eb__0<T0, T1, T2, T3, T4, T5>(T4 param)
		{
			//IL_0010: Expected O, but got I4
			//IL_0044: Expected O, but got I4
			try
			{
				T2 val = (T2)(_003C_003E4__this.ListAds == null);
				if (val != null)
				{
					_003C_003E4__this.ListAds = (List<adaccountsData>)Activator.CreateInstance(typeof(T1));
				}
				T2 val2 = (T2)mi.Text.Equals("Paste Json + Xóa");
				if (val2 != null)
				{
					_003C_003E4__this.ListAds.Clear();
				}
				T0 val3 = (T0)"";
				val3 = (T0)Clipboard.GetText();
				T1 collection = JsonConvert.DeserializeObject<T1>((string)val3);
				_003C_003E4__this.ListAds.AddRange((IEnumerable<adaccountsData>)collection);
				_003C_003E4__this.loadData<T5>();
			}
			catch (Exception ex)
			{
				errorMessage((T0)ex.Message);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass68_0
	{
		public List<string> listAdsAcc;

		internal T0 _003C_002Ector_003Eb__0<T0>(adaccountsData a)
		{
			//IL_0012: Expected O, but got I4
			return (T0)listAdsAcc.Contains(a.id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_0
	{
		public frmPublishCampText _003C_003E4__this;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__0;

		internal void _003CgetAddraft_003Eb__0<T0, T1, T2, T3, T4, T5>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0035: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			//IL_005d: Expected I4, but got O
			//IL_007e: Expected I4, but got O
			//IL_009e: Expected I4, but got O
			//IL_00c3: Expected I4, but got O
			//IL_00db: Expected I4, but got O
			//IL_00ec: Expected O, but got I4
			//IL_0100: Expected I4, but got O
			//IL_0128: Expected I4, but got O
			//IL_0144: Expected O, but got I4
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			T1 val2 = (T1)(_003C_003E4__this.ListAds[(int)val].addraft_fragments == null || _003C_003E4__this.ListAds[(int)val].addraft_fragments.data == null);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].addraft_fragments = _003C_003E4__this.frm.chrome.getAddraftCamp_2<T1, T0, T3, T4, T5, T2>((T4)_003C_003E4__this.ListAds[(int)val].id);
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
				T1 val3 = (T1)(_003C_003E4__this.ListAds[(int)val].addraft_fragments == null || _003C_003E4__this.ListAds[(int)val].addraft_fragments.data == null);
				if (val3 != null)
				{
					_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
				}
				else
				{
					_003C_003E4__this.ListAds[(int)val].message = STATUS.Ready.ToString();
				}
			}
			T0 val4 = (T0)countThread;
			countThread = val4 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_0
	{
		public int countThread;

		public frmPublishCampText _003C_003E4__this;

		public ParameterizedThreadStart _003C_003E9__12;

		public ParameterizedThreadStart _003C_003E9__13;

		public ParameterizedThreadStart _003C_003E9__14;

		public ParameterizedThreadStart _003C_003E9__15;

		public ParameterizedThreadStart _003C_003E9__16;

		public ParameterizedThreadStart _003C_003E9__23;

		public ParameterizedThreadStart _003C_003E9__46;

		public ParameterizedThreadStart _003C_003E9__62;

		public ParameterizedThreadStart _003C_003E9__63;

		public ParameterizedThreadStart _003C_003E9__70;

		public ParameterizedThreadStart _003C_003E9__72;

		public ParameterizedThreadStart _003C_003E9__73;

		internal void _003CthrStart_003Eb__12<T0, T1, T2, T3, T4, T5, T6>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_0068: Expected I4, but got O
			//IL_0073: Expected O, but got I4
			//IL_0088: Expected I4, but got O
			//IL_00b0: Expected I4, but got O
			//IL_00cc: Expected O, but got I4
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.addCart<T1, T0, T3, T4, T5, T6>((T3)_003C_003E4__this.ListAds[(int)val].id, (T3)_003C_003E4__this.ListAds[(int)val].business_country_code, (T1)0);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__13<T0, T1, T2, T3, T4, T5, T6>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_0068: Expected I4, but got O
			//IL_0073: Expected O, but got I4
			//IL_0088: Expected I4, but got O
			//IL_00b0: Expected I4, but got O
			//IL_00cc: Expected O, but got I4
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.addCart<T1, T0, T3, T4, T5, T6>((T3)_003C_003E4__this.ListAds[(int)val].id, (T3)_003C_003E4__this.ListAds[(int)val].business_country_code, (T1)1);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__14<T0, T1, T2, T3, T4, T5>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_0076: Expected I4, but got O
			//IL_009e: Expected I4, but got O
			//IL_00ba: Expected O, but got I4
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.removePaymentMethod<T1, T3, T4, T5, T0>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)"");
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__15<T0, T1, T2, T3, T4, T5>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_007c: Expected I4, but got O
			//IL_00a4: Expected I4, but got O
			//IL_00c0: Expected O, but got I4
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.removePaymentMethod<T1, T3, T4, T5, T0>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.strRemoveCardByName);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__16<T0, T1, T2, T3, T4, T5, T6>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_0076: Expected I4, but got O
			//IL_009e: Expected I4, but got O
			//IL_00ba: Expected O, but got I4
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.kichNo<T1, T3, T4, T5, T6>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)"");
			if (val2 == null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__23<T0, T1, T2, T3, T4>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_0071: Expected I4, but got O
			//IL_0098: Expected I4, but got O
			//IL_00b4: Expected O, but got I4
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.resetLimit<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Reseted.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__46<T0, T1, T2, T3, T4>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_007c: Expected I4, but got O
			//IL_00a4: Expected I4, but got O
			//IL_00c0: Expected O, but got I4
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.shareTK<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.UID_Share_Tk);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		internal void _003CthrStart_003Eb__62<T0, T1, T2, T3, T4>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0033: Expected O, but got I4
			//IL_0040: Expected O, but got I4
			//IL_0059: Expected I4, but got O
			//IL_007f: Expected I4, but got O
			//IL_00c6: Expected I4, but got O
			//IL_010a: Expected I4, but got O
			//IL_0143: Expected I4, but got O
			//IL_0171: Expected I4, but got O
			//IL_0199: Expected I4, but got O
			//IL_01b6: Expected O, but got I4
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = (T1)1;
			T0 val3 = (T0)_003C_003E4__this.intKhangTK;
			T0 val4 = val3;
			switch ((int)val4)
			{
			case 0:
				val2 = _003C_003E4__this.frm.chrome.khangTK<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.strMessageKhangTK, (T4)_003C_003E4__this.BMID);
				break;
			case 1:
				val2 = _003C_003E4__this.frm.chrome.khangTK_792<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.strMessageKhangTK, (T4)_003C_003E4__this.BMID);
				break;
			case 2:
				val2 = _003C_003E4__this.frm.chrome.khangTk_273_Yes<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.strMessageKhangTK);
				break;
			case 3:
				val2 = _003C_003E4__this.frm.chrome.khangTk_273_No<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.strMessageKhangTK);
				break;
			}
			T1 val5 = val2;
			if (val5 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val6 = (T0)countThread;
			countThread = val6 - 1;
		}

		internal void _003CthrStart_003Eb__63<T0, T1, T2, T3, T4>(T2 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0052: Expected I4, but got O
			//IL_0096: Expected I4, but got O
			//IL_00be: Expected I4, but got O
			//IL_00da: Expected O, but got I4
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.frm.chrome.xoa_tkqc_trong_bm<T1, T3, T4>((T4)_003C_003E4__this.ListAds[(int)val].id, (T4)_003C_003E4__this.users_in_bm.data[_003C_003E4__this.UIDVia].id);
			if (val2 != null)
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.ListAds[(int)val].message = STATUS.lỗi.ToString();
			}
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__70<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_001f: Expected I4, but got O
			//IL_0054: Expected I4, but got O
			//IL_00a6: Expected I4, but got O
			//IL_00c7: Expected I4, but got O
			//IL_00e7: Expected I4, but got O
			//IL_00ff: Expected I4, but got O
			//IL_011c: Expected I4, but got O
			//IL_0136: Expected O, but got I4
			//IL_014e: Expected I4, but got O
			//IL_01a7: Expected O, but got I4
			//IL_01c7: Expected O, but got I4
			//IL_0200: Expected O, but got I4
			//IL_0239: Expected O, but got I4
			//IL_0281: Expected O, but got I4
			//IL_02eb: Expected I4, but got O
			//IL_0304: Expected O, but got I4
			//IL_0315: Expected I4, but got O
			//IL_0347: Expected O, but got I4
			//IL_0358: Expected I4, but got O
			//IL_0387: Expected I4, but got O
			//IL_039f: Expected I4, but got O
			//IL_03bc: Expected I4, but got O
			//IL_03d3: Expected O, but got I4
			//IL_03e9: Expected I4, but got O
			//IL_0449: Expected O, but got I4
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0453: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			_003C_003E4__this.frm.chrome.updateTargetCampain<T0, T3, T1, T2, T6, T7, T8, T9, T10>((T3)_003C_003E4__this.ListAds[(int)val2].id, (T3)_003C_003E4__this.TargetCamp, (T3)_003C_003E4__this.TargetAdset, (T3)_003C_003E4__this.TargetAd, (T3)_003C_003E4__this.CampFilter);
			Thread.Sleep(1500);
			_003C_003E4__this.ListAds[(int)val2].addraft_fragments = _003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T3, T11, T5>((T3)_003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(_003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 == null)
			{
				T2 enumerator = (T2)_003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T3 val4 = (T3)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!_003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("campaign");
									if (val6 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val7 = (T0)current2.ad_object_type.ToLower().Equals("ad_set");
									if (val7 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val8 = (T0)current2.ad_object_type.ToLower().Equals("ad");
									if (val8 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val9 = (T0)(((string)val4).Length > 0);
						if (val9 != null)
						{
							val4 = (T3)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T3)("[" + (string)val4 + "]");
						val4 = (T3)HttpUtility.UrlEncode((string)val4);
						T0 val10 = _003C_003E4__this.frm.chrome.publishCamps<T0, T10, T3>((T3)current.id, val4);
						if (val10 != null)
						{
							_003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
							continue;
						}
						val = (T0)1;
						_003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			else
			{
				val = (T0)1;
				_003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			T0 val11 = val;
			if (val11 != null)
			{
				T0 val12 = (T0)(_003C_003E4__this.ListAds[(int)val2].addraft_fragments != null && _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data != null && _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count > 0);
				if (val12 != null)
				{
					try
					{
						T2 enumerator3 = (T2)_003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
							{
								addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
								_003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T3>((T3)current3.id);
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
					catch
					{
					}
				}
			}
			T1 val13 = (T1)countThread;
			countThread = val13 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__72<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_001f: Expected I4, but got O
			//IL_0072: Expected I4, but got O
			//IL_00a8: Expected I4, but got O
			//IL_00c9: Expected I4, but got O
			//IL_00e9: Expected I4, but got O
			//IL_0101: Expected I4, but got O
			//IL_011e: Expected I4, but got O
			//IL_0138: Expected O, but got I4
			//IL_0150: Expected I4, but got O
			//IL_01a6: Expected O, but got I4
			//IL_01c3: Expected O, but got I4
			//IL_0208: Expected O, but got I4
			//IL_0263: Expected O, but got I4
			//IL_0274: Expected I4, but got O
			//IL_029c: Expected I4, but got O
			//IL_02d0: Expected O, but got I4
			//IL_02e1: Expected I4, but got O
			//IL_030a: Expected I4, but got O
			//IL_031d: Expected I4, but got O
			//IL_0335: Expected I4, but got O
			//IL_0352: Expected I4, but got O
			//IL_0369: Expected O, but got I4
			//IL_037e: Expected I4, but got O
			//IL_03d9: Expected O, but got I4
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e3: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			T2 strNewTarget_ChienDich = (T2)("[{\"field\":\"daily_budget\",\"new_value\":" + _003C_003E4__this.BugetCamp + "}]");
			_003C_003E4__this.frm.chrome.updateTargetCampain<T0, T2, T1, T3, T6, T7, T8, T9, T10>((T2)_003C_003E4__this.ListAds[(int)val2].id, strNewTarget_ChienDich, (T2)"", (T2)"", (T2)"");
			Thread.Sleep(1500);
			_003C_003E4__this.ListAds[(int)val2].addraft_fragments = _003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T2, T11, T5>((T2)_003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(_003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 == null)
			{
				T3 enumerator = (T3)_003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T2 val4 = (T2)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!_003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("campaign");
									if (val6 != null)
									{
										val4 = (T2)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val7 = (T0)(((string)val4).Length > 0);
						if (val7 != null)
						{
							val4 = (T2)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T2)("[" + (string)val4 + "]");
						val4 = (T2)HttpUtility.UrlEncode((string)val4);
						T0 val8 = _003C_003E4__this.frm.chrome.publishCamps<T0, T10, T2>((T2)current.id, val4);
						if (val8 == null)
						{
							val = (T0)1;
							_003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
						}
						else
						{
							_003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			else
			{
				val = (T0)1;
				_003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			T0 val9 = (T0)(val != null && _003C_003E4__this.ListAds[(int)val2] != null && _003C_003E4__this.ListAds[(int)val2].addraft_fragments != null && _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data != null && _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count > 0);
			if (val9 != null)
			{
				T3 enumerator3 = (T3)_003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
					{
						addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
						_003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T2>((T2)current3.id);
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
				}
			}
			T1 val10 = (T1)countThread;
			countThread = val10 - 1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__73<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_001f: Expected I4, but got O
			//IL_0072: Expected I4, but got O
			//IL_00a8: Expected I4, but got O
			//IL_00c9: Expected I4, but got O
			//IL_00e9: Expected I4, but got O
			//IL_0101: Expected I4, but got O
			//IL_011e: Expected I4, but got O
			//IL_0138: Expected O, but got I4
			//IL_013e: Expected O, but got I4
			//IL_014f: Expected I4, but got O
			//IL_017a: Expected I4, but got O
			//IL_01d0: Expected O, but got I4
			//IL_01ed: Expected O, but got I4
			//IL_0232: Expected O, but got I4
			//IL_028d: Expected O, but got I4
			//IL_029e: Expected I4, but got O
			//IL_02c6: Expected I4, but got O
			//IL_0310: Expected I4, but got O
			//IL_036b: Expected O, but got I4
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			_003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			T2 strNewTarget_NhomQuangCao = (T2)("[{\"field\":\"daily_budget\",\"old_value\":3000,\"new_value\":" + _003C_003E4__this.BugetCamp + "}]");
			_003C_003E4__this.frm.chrome.updateTargetCampain<T0, T2, T1, T3, T6, T7, T8, T9, T10>((T2)_003C_003E4__this.ListAds[(int)val2].id, (T2)"", strNewTarget_NhomQuangCao, (T2)"", (T2)"");
			Thread.Sleep(3000);
			_003C_003E4__this.ListAds[(int)val2].addraft_fragments = _003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T2, T11, T5>((T2)_003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(_003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || _003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 != null)
			{
				val = (T0)1;
				_003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			else
			{
				T3 enumerator = (T3)_003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T2 val4 = (T2)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!_003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("ad_set");
									if (val6 != null)
									{
										val4 = (T2)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val7 = (T0)(((string)val4).Length > 0);
						if (val7 != null)
						{
							val4 = (T2)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T2)("[" + (string)val4 + "]");
						val4 = (T2)HttpUtility.UrlEncode((string)val4);
						T0 val8 = _003C_003E4__this.frm.chrome.publishCamps<T0, T10, T2>((T2)current.id, val4);
						if (val8 == null)
						{
							val = (T0)1;
							_003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
						}
						else
						{
							_003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val9 = val;
			if (val9 != null)
			{
				T3 enumerator3 = (T3)_003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
					{
						addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
						_003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T2>((T2)current3.id);
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
				}
			}
			T1 val10 = (T1)countThread;
			countThread = val10 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_1
	{
		public string idAds;

		public _003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals1;

		public ParameterizedThreadStart _003C_003E9__42;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__42<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T5 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_0022: Expected I4, but got O
			//IL_004c: Expected I4, but got O
			//IL_0077: Expected I4, but got O
			//IL_009c: Expected I4, but got O
			//IL_00b9: Expected I4, but got O
			//IL_00ca: Expected O, but got I4
			//IL_00e6: Expected I4, but got O
			//IL_0122: Expected O, but got I4
			//IL_0168: Expected O, but got I4
			//IL_0207: Expected O, but got I4
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			CS_0024_003C_003E8__locals1._003C_003E4__this.ListAds[(int)val].message = STATUS.Processing.ToString();
			CS_0024_003C_003E8__locals1._003C_003E4__this.ListAds[(int)val].campaigns = CS_0024_003C_003E8__locals1._003C_003E4__this.frm.chrome.getCampaigns<T6, T7, T1, T8, T9, T10, T0, T11, T12, T13, T14, T15, T5>((T7)CS_0024_003C_003E8__locals1._003C_003E4__this.ListAds[(int)val].id);
			T1 val2 = (T1)(CS_0024_003C_003E8__locals1._003C_003E4__this.ListAds[(int)val].campaigns != null && CS_0024_003C_003E8__locals1._003C_003E4__this.ListAds[(int)val].campaigns.data != null);
			if (val2 != null)
			{
				T2 enumerator = (T2)CS_0024_003C_003E8__locals1._003C_003E4__this.ListAds[(int)val].campaigns.data.GetEnumerator();
				try
				{
					while (((List<campaignsData>.Enumerator*)(&enumerator))->MoveNext())
					{
						campaignsData current = ((List<campaignsData>.Enumerator*)(&enumerator))->Current;
						T1 val3 = (T1)(current.adsets != null && current.adsets.data != null);
						if (val3 == null)
						{
							continue;
						}
						T3 enumerator2 = (T3)current.adsets.data.GetEnumerator();
						try
						{
							while (((List<adsets_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								adsets_data current2 = ((List<adsets_data>.Enumerator*)(&enumerator2))->Current;
								T1 val4 = (T1)(current2.ads != null && current2.ads.data != null);
								if (val4 == null)
								{
									continue;
								}
								T4 enumerator3 = (T4)current2.ads.data.GetEnumerator();
								try
								{
									while (((List<ads_data>.Enumerator*)(&enumerator3))->MoveNext())
									{
										ads_data current3 = ((List<ads_data>.Enumerator*)(&enumerator3))->Current;
										idAds = idAds + current3.id + ",";
									}
								}
								finally
								{
									((IDisposable)(*(List<ads_data>.Enumerator*)(&enumerator3))).Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<adsets_data>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<campaignsData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val5 = (T0)CS_0024_003C_003E8__locals1.countThread;
			CS_0024_003C_003E8__locals1.countThread = val5 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_2
	{
		public string TargetCamp2;

		public string TargetAdset2;

		public string TargetAd2;

		public string CampFilter2;

		public _003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals2;

		public ParameterizedThreadStart _003C_003E9__67;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__67<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_0024: Expected I4, but got O
			//IL_0063: Expected I4, but got O
			//IL_00a6: Expected I4, but got O
			//IL_00d1: Expected I4, but got O
			//IL_00f6: Expected I4, but got O
			//IL_0113: Expected I4, but got O
			//IL_0135: Expected I4, but got O
			//IL_014f: Expected O, but got I4
			//IL_0155: Expected O, but got I4
			//IL_016b: Expected I4, but got O
			//IL_019a: Expected I4, but got O
			//IL_01f8: Expected O, but got I4
			//IL_0218: Expected O, but got I4
			//IL_0251: Expected O, but got I4
			//IL_028a: Expected O, but got I4
			//IL_02d2: Expected O, but got I4
			//IL_0346: Expected I4, but got O
			//IL_035f: Expected O, but got I4
			//IL_0375: Expected I4, but got O
			//IL_03c5: Expected I4, but got O
			//IL_03e2: Expected I4, but got O
			//IL_0404: Expected I4, but got O
			//IL_041b: Expected O, but got I4
			//IL_0436: Expected I4, but got O
			//IL_04a0: Expected O, but got I4
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04af: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			CS_0024_003C_003E8__locals2._003C_003E4__this.frm.chrome.updateTargetCampain<T0, T3, T1, T2, T6, T7, T8, T9, T10>((T3)CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].id, (T3)TargetCamp2, (T3)TargetAdset2, (T3)TargetAd2, (T3)CampFilter2);
			Thread.Sleep(1500);
			CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments = CS_0024_003C_003E8__locals2._003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T3, T11, T5>((T3)CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 != null)
			{
				val = (T0)1;
				CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			else
			{
				T2 enumerator = (T2)CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T3 val4 = (T3)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!CS_0024_003C_003E8__locals2._003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("campaign");
									if (val6 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val7 = (T0)current2.ad_object_type.ToLower().Equals("ad_set");
									if (val7 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val8 = (T0)current2.ad_object_type.ToLower().Equals("ad");
									if (val8 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val9 = (T0)(((string)val4).Length > 0);
						if (val9 != null)
						{
							val4 = (T3)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T3)("[" + (string)val4 + "]");
						val4 = (T3)HttpUtility.UrlEncode((string)val4);
						T0 val10 = CS_0024_003C_003E8__locals2._003C_003E4__this.frm.chrome.publishCamps<T0, T10, T3>((T3)current.id, val4);
						if (val10 != null)
						{
							CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
							continue;
						}
						val = (T0)1;
						CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val11 = val;
			if (val11 != null)
			{
				T0 val12 = (T0)(CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments != null && CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data != null && CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count > 0);
				if (val12 != null)
				{
					try
					{
						T2 enumerator3 = (T2)CS_0024_003C_003E8__locals2._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
							{
								addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
								CS_0024_003C_003E8__locals2._003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T3>((T3)current3.id);
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
					catch
					{
					}
				}
			}
			T1 val13 = (T1)CS_0024_003C_003E8__locals2.countThread;
			CS_0024_003C_003E8__locals2.countThread = val13 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_3
	{
		public string TargetCamp2;

		public string TargetAdset2;

		public string TargetAd2;

		public string CampFilter2;

		public _003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals3;

		public ParameterizedThreadStart _003C_003E9__68;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__68<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_0024: Expected I4, but got O
			//IL_0063: Expected I4, but got O
			//IL_00a6: Expected I4, but got O
			//IL_00d1: Expected I4, but got O
			//IL_00f6: Expected I4, but got O
			//IL_0113: Expected I4, but got O
			//IL_0135: Expected I4, but got O
			//IL_014f: Expected O, but got I4
			//IL_0155: Expected O, but got I4
			//IL_016b: Expected I4, but got O
			//IL_019a: Expected I4, but got O
			//IL_01f8: Expected O, but got I4
			//IL_0218: Expected O, but got I4
			//IL_0251: Expected O, but got I4
			//IL_028a: Expected O, but got I4
			//IL_02d2: Expected O, but got I4
			//IL_0332: Expected O, but got I4
			//IL_0348: Expected I4, but got O
			//IL_0374: Expected I4, but got O
			//IL_03c5: Expected I4, but got O
			//IL_03e2: Expected I4, but got O
			//IL_0404: Expected I4, but got O
			//IL_041b: Expected O, but got I4
			//IL_0436: Expected I4, but got O
			//IL_04a0: Expected O, but got I4
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04af: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			CS_0024_003C_003E8__locals3._003C_003E4__this.frm.chrome.updateTargetCampain<T0, T3, T1, T2, T6, T7, T8, T9, T10>((T3)CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].id, (T3)TargetCamp2, (T3)TargetAdset2, (T3)TargetAd2, (T3)CampFilter2);
			Thread.Sleep(1500);
			CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments = CS_0024_003C_003E8__locals3._003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T3, T11, T5>((T3)CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 != null)
			{
				val = (T0)1;
				CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			else
			{
				T2 enumerator = (T2)CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T3 val4 = (T3)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!CS_0024_003C_003E8__locals3._003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("campaign");
									if (val6 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val7 = (T0)current2.ad_object_type.ToLower().Equals("ad_set");
									if (val7 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val8 = (T0)current2.ad_object_type.ToLower().Equals("ad");
									if (val8 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val9 = (T0)(((string)val4).Length > 0);
						if (val9 != null)
						{
							val4 = (T3)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T3)("[" + (string)val4 + "]");
						val4 = (T3)HttpUtility.UrlEncode((string)val4);
						T0 val10 = CS_0024_003C_003E8__locals3._003C_003E4__this.frm.chrome.publishCamps<T0, T10, T3>((T3)current.id, val4);
						if (val10 == null)
						{
							val = (T0)1;
							CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val11 = val;
			if (val11 != null)
			{
				T0 val12 = (T0)(CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments != null && CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data != null && CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count > 0);
				if (val12 != null)
				{
					try
					{
						T2 enumerator3 = (T2)CS_0024_003C_003E8__locals3._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
							{
								addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
								CS_0024_003C_003E8__locals3._003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T3>((T3)current3.id);
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
					catch
					{
					}
				}
			}
			T1 val13 = (T1)CS_0024_003C_003E8__locals3.countThread;
			CS_0024_003C_003E8__locals3.countThread = val13 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_4
	{
		public string TargetCamp2;

		public string TargetAdset2;

		public string TargetAd2;

		public string CampFilter2;

		public _003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals4;

		public ParameterizedThreadStart _003C_003E9__69;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__69<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_0024: Expected I4, but got O
			//IL_0063: Expected I4, but got O
			//IL_00a6: Expected I4, but got O
			//IL_00d1: Expected I4, but got O
			//IL_00f6: Expected I4, but got O
			//IL_0113: Expected I4, but got O
			//IL_0135: Expected I4, but got O
			//IL_014f: Expected O, but got I4
			//IL_0155: Expected O, but got I4
			//IL_016b: Expected I4, but got O
			//IL_019a: Expected I4, but got O
			//IL_01f8: Expected O, but got I4
			//IL_0218: Expected O, but got I4
			//IL_0251: Expected O, but got I4
			//IL_028a: Expected O, but got I4
			//IL_02d2: Expected O, but got I4
			//IL_0332: Expected O, but got I4
			//IL_0348: Expected I4, but got O
			//IL_0374: Expected I4, but got O
			//IL_03c5: Expected I4, but got O
			//IL_03e2: Expected I4, but got O
			//IL_0404: Expected I4, but got O
			//IL_041b: Expected O, but got I4
			//IL_0436: Expected I4, but got O
			//IL_04a0: Expected O, but got I4
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04af: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			CS_0024_003C_003E8__locals4._003C_003E4__this.frm.chrome.updateTargetCampain<T0, T3, T1, T2, T6, T7, T8, T9, T10>((T3)CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].id, (T3)TargetCamp2, (T3)TargetAdset2, (T3)TargetAd2, (T3)CampFilter2);
			Thread.Sleep(1500);
			CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments = CS_0024_003C_003E8__locals4._003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T3, T11, T5>((T3)CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 != null)
			{
				val = (T0)1;
				CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			else
			{
				T2 enumerator = (T2)CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T3 val4 = (T3)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!CS_0024_003C_003E8__locals4._003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("campaign");
									if (val6 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val7 = (T0)current2.ad_object_type.ToLower().Equals("ad_set");
									if (val7 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val8 = (T0)current2.ad_object_type.ToLower().Equals("ad");
									if (val8 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val9 = (T0)(((string)val4).Length > 0);
						if (val9 != null)
						{
							val4 = (T3)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T3)("[" + (string)val4 + "]");
						val4 = (T3)HttpUtility.UrlEncode((string)val4);
						T0 val10 = CS_0024_003C_003E8__locals4._003C_003E4__this.frm.chrome.publishCamps<T0, T10, T3>((T3)current.id, val4);
						if (val10 == null)
						{
							val = (T0)1;
							CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val11 = val;
			if (val11 != null)
			{
				T0 val12 = (T0)(CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments != null && CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data != null && CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count > 0);
				if (val12 != null)
				{
					try
					{
						T2 enumerator3 = (T2)CS_0024_003C_003E8__locals4._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
							{
								addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
								CS_0024_003C_003E8__locals4._003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T3>((T3)current3.id);
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
					catch
					{
					}
				}
			}
			T1 val13 = (T1)CS_0024_003C_003E8__locals4.countThread;
			CS_0024_003C_003E8__locals4.countThread = val13 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_5
	{
		public string changePost;

		public _003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals5;

		public ParameterizedThreadStart _003C_003E9__71;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrStart_003Eb__71<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 obj)
		{
			//IL_0002: Expected O, but got I4
			//IL_000e: Expected O, but got I4
			//IL_0024: Expected I4, but got O
			//IL_0063: Expected I4, but got O
			//IL_00a3: Expected I4, but got O
			//IL_00ce: Expected I4, but got O
			//IL_00f3: Expected I4, but got O
			//IL_0110: Expected I4, but got O
			//IL_0132: Expected I4, but got O
			//IL_014c: Expected O, but got I4
			//IL_0152: Expected O, but got I4
			//IL_0168: Expected I4, but got O
			//IL_0197: Expected I4, but got O
			//IL_01f5: Expected O, but got I4
			//IL_0215: Expected O, but got I4
			//IL_024e: Expected O, but got I4
			//IL_0287: Expected O, but got I4
			//IL_02cf: Expected O, but got I4
			//IL_0343: Expected I4, but got O
			//IL_035c: Expected O, but got I4
			//IL_0372: Expected I4, but got O
			//IL_03c2: Expected I4, but got O
			//IL_03df: Expected I4, but got O
			//IL_0401: Expected I4, but got O
			//IL_0418: Expected O, but got I4
			//IL_0432: Expected I4, but got O
			//IL_0497: Expected O, but got I4
			//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Expected I4, but got Unknown
			T0 val = (T0)0;
			T1 val2 = (T1)int.Parse(obj.ToString());
			CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].message = STATUS.Processing.ToString();
			CS_0024_003C_003E8__locals5._003C_003E4__this.frm.chrome.updateTargetCampain<T0, T3, T1, T2, T6, T7, T8, T9, T10>((T3)CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].id, (T3)"", (T3)"", (T3)changePost, (T3)"");
			Thread.Sleep(1500);
			CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments = CS_0024_003C_003E8__locals5._003C_003E4__this.frm.chrome.getAddraftCamp_2<T0, T1, T10, T3, T11, T5>((T3)CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].id);
			T0 val3 = (T0)(CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments == null || CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data == null || CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count <= 0);
			if (val3 != null)
			{
				val = (T0)1;
				CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
			}
			else
			{
				T2 enumerator = (T2)CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
				try
				{
					while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->MoveNext())
					{
						addraft_fragments_2_data current = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator))->Current;
						T3 val4 = (T3)"";
						T4 enumerator2 = (T4)current.addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->MoveNext())
							{
								addraft_fragments_data current2 = ((List<addraft_fragments_data>.Enumerator*)(&enumerator2))->Current;
								T0 val5 = (T0)(!CS_0024_003C_003E8__locals5._003C_003E4__this.isRunning);
								if (val5 == null)
								{
									T0 val6 = (T0)current2.ad_object_type.ToLower().Equals("campaign");
									if (val6 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val7 = (T0)current2.ad_object_type.ToLower().Equals("ad_set");
									if (val7 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									T0 val8 = (T0)current2.ad_object_type.ToLower().Equals("ad");
									if (val8 != null)
									{
										val4 = (T3)((string)val4 + "\"" + current2.id + "\",");
									}
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_data>.Enumerator*)(&enumerator2))).Dispose();
						}
						T0 val9 = (T0)(((string)val4).Length > 0);
						if (val9 != null)
						{
							val4 = (T3)((string)val4).Remove(((string)val4).Length - 1, 1);
						}
						val4 = (T3)("[" + (string)val4 + "]");
						val4 = (T3)HttpUtility.UrlEncode((string)val4);
						T0 val10 = CS_0024_003C_003E8__locals5._003C_003E4__this.frm.chrome.publishCamps<T0, T10, T3>((T3)current.id, val4);
						if (val10 != null)
						{
							CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].message = STATUS.Done.ToString();
							continue;
						}
						val = (T0)1;
						CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].message = STATUS.Pulish_lỗi.ToString();
					}
				}
				finally
				{
					((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val11 = val;
			if (val11 != null)
			{
				T0 val12 = (T0)(CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments != null && CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data != null && CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.Count > 0);
				if (val12 != null)
				{
					T2 enumerator3 = (T2)CS_0024_003C_003E8__locals5._003C_003E4__this.ListAds[(int)val2].addraft_fragments.data.GetEnumerator();
					try
					{
						while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
						{
							addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
							CS_0024_003C_003E8__locals5._003C_003E4__this.frm.chrome.clearAddrafts<T0, T10, T3>((T3)current3.id);
						}
					}
					finally
					{
						((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
					}
				}
			}
			T1 val13 = (T1)CS_0024_003C_003E8__locals5.countThread;
			CS_0024_003C_003E8__locals5.countThread = val13 - 1;
		}
	}

	public bool CampReview;

	public string strChangeNameAct;

	public bool boolChangeNameAct;

	public bool RemveLimitInCamp;

	public bool RemoveLimit;

	public bool boolKhangTK;

	public int intKhangTK;

	public string strMessageKhangTK;

	public bool ShareTKQCToVia;

	public bool RemoveTKQCToVia;

	public bool PushCardPrimary;

	public int UIDVia;

	private List<string> listTaskChecked = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private List<adaccountsData> ListAds = (List<adaccountsData>)Activator.CreateInstance(typeof(List<adaccountsData>));

	private frmAdsManager frm;

	private string Card_Log = "";

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	public bool isRunning = false;

	private business_users users_in_bm;

	private bool OffTkqc;

	private bool OnTkqc;

	private int OnOffTKQC;

	private string textCamp = "";

	private string TargetCamp = "";

	private string TargetAdset = "";

	private string TargetAd = "";

	private bool EditTarget = false;

	private string CampFilter = "";

	private bool ChangeInfoAct;

	private string Address = "";

	private string City = "";

	private string State = "";

	private string Zip = "";

	private string Country = "";

	private string Currency = "";

	private string TimeZone = "";

	public bool RemoveCard;

	private bool PayNow;

	private bool KichNo;

	private bool ShareTK;

	private string UID_Share_Tk;

	private bool TryAgainHoldMoney;

	private bool AddCartPrimary;

	private bool PayBalance;

	private string strPayBalance;

	private bool RemoveCardByName;

	private string strRemoveCardByName;

	private bool ChangeBugetCamp;

	private bool ChangeBugetGruopAds;

	private string BugetCamp;

	private bool AddCardItem;

	private bool AddCardItem_Primary;

	private string strCardCountry;

	private List<BinGenClass> listBinGen = (List<BinGenClass>)Activator.CreateInstance(typeof(List<BinGenClass>));

	private bool blBinGen = true;

	private bool blListCard;

	private bool blListCardCenter;

	private bool boolBoostPost = false;

	private bool boolCampSuite = false;

	private bool AddCardItem_M_Facebook;

	private string NameCard = "";

	private bool AddCardLink667;

	private bool SharePixel;

	private string IdPixel;

	private string BM_Pixel;

	private string strPushCardPrimary;

	private bool AddCodeCard;

	private int intDelay = 0;

	private bool ReloadTk;

	private bool boolCreatePE = false;

	private bool AddBoostpost;

	private bool AddSuite;

	private bool AddCardLink1;

	private bool AddCardAPI;

	private business_asset_groups asset_groups;

	private bool AddAdsToGroup;

	private bool RemoveAdsToGroup;

	private int GROUP_ID;

	private bool boolApproved2;

	private int intDelayApproved2;

	private bool ChangePost;

	private string strPageId;

	private string strPostId;

	private bool RollingMatThread;

	private bool AddCardRequest;

	private int DelayRemoveCard = 0;

	private bool RemoveCamp;

	private bool AddCardByPage;

	private string ListCardCenter;

	private string Pro5List;

	private int AddActOnPage;

	private bool AddCartMFacebook2;

	private bool CardVerify;

	private int DelayLifeCycle = 0;

	private int LifeCycle = 0;

	private IContainer components = null;

	private DataGridView gvData;

	private Button button1;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private CheckBox cbImportCamp;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel lbQuantity;

	private TextBox txtTextCamp;

	private CheckBox cbPublishCamp;

	private CheckBox cbPublishGroup;

	private CheckBox cbPublishAds;

	private CheckBox cbClearAddraft;

	private CheckBox cbResetLimit;

	private CheckBox cbRemoveActInBM;

	private Label label1;

	private TextBox txtBMID;

	private CheckBox ccbAddCart;

	private CheckBox cbSetLimit;

	private TextBox txtLimit;

	private CheckBox ccbApprovedPayment;

	private CheckBox cbCampReview;

	private TextBox txtChangeNameAds;

	private CheckBox cbChangeNameAct;

	private CheckBox cbRemveLimitInCamp;

	private CheckBox cbRemoveLimit;

	private CheckBox ccbKhangTK;

	private ComboBox cbbKhangTK;

	private ComboBox ccbMessageKhangTK;

	private GroupBox groupRollingMat;

	private GroupBox groupBox2;

	private GroupBox groupBox3;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripStatusLabel lbActive;

	private ToolStripStatusLabel toolStripStatusLabel4;

	private ToolStripStatusLabel lbDie;

	private ToolStripStatusLabel toolStripStatusLabel6;

	private ToolStripStatusLabel lbUnsettled;

	private ToolStripStatusLabel toolStripStatusLabel8;

	private ToolStripStatusLabel lbReview;

	private ToolStripStatusLabel toolStripStatusLabel10;

	private ToolStripStatusLabel lbGracePeriod;

	private ToolStripStatusLabel toolStripStatusLabel12;

	private ToolStripStatusLabel lbTemporarityUnavable;

	private ToolStripStatusLabel toolStripStatusLabel14;

	private ToolStripStatusLabel lbPendingCloure;

	private TabControl tabControl;

	private TabPage tabCookie;

	private TabPage tabToken;

	private CheckBox cbShareTKQCToVia;

	private Button button2;

	private ComboBox ccbUserInBM;

	private GroupBox groupBox4;

	private CheckBox cbRemoveTKQCToVia;

	private CheckBox ccbPushCardPrimary;

	private ComboBox ccbOnOffTKQC;

	private CheckBox cbOnTkqc;

	private CheckBox cbOffTkqc;

	private Label label2;

	private NumericUpDown numThread;

	private TabPage tabPage1;

	private SplitContainer splitContainer1;

	private SplitContainer splitContainer2;

	private GroupBox groupBox6;

	private GroupBox groupBox7;

	private GroupBox groupBox8;

	private TextBox txtTargetCamp;

	private TextBox txtTargetAdset;

	private TextBox txtTargetAd;

	private CheckBox cbEditTarget;

	private Label label3;

	private TextBox txtCampFilter;

	private GroupBox groupBox9;

	private CheckBox cbChangeInfoAct;

	private Label label4;

	private TextBox txtAddress;

	private Label label10;

	private TextBox txtTimeZone;

	private Label label9;

	private TextBox txtCurrency;

	private Label label8;

	private TextBox txtCountry;

	private Label label7;

	private TextBox txtState;

	private Label label6;

	private TextBox txtZip;

	private Label label5;

	private TextBox txtCity;

	private CheckBox cbRemoveCard;

	private CheckBox cbPaynow;

	private CheckBox cbKichNo;

	private TextBox txtUID_Share_Tk;

	private CheckBox cbShareTK;

	private CheckBox cbTryAgainHoldMoney;

	private CheckBox cbAddCartPrimary;

	private TextBox txtPayBalance;

	private CheckBox cbPayBalance;

	private TextBox txtRemoveCardByName;

	private CheckBox cbRemoveCardByName;

	private TabPage tabPage2;

	private CheckBox cbAddCardItem;

	private CheckBox cbAddCardItem_Primary;

	private DataGridView gvCard;

	private Label lbCard;

	private TextBox txtCardCountry;

	private Label label11;

	private TextBox txtBinGen;

	private TextBox txtAddCard_Log;

	private SplitContainer splitContainer3;

	private RadioButton rbListCard;

	private RadioButton rbBinGen;

	private Label lbTotalBinGen;

	private CheckBox rbCampSuite;

	private CheckBox rbBoostPost;

	private CheckBox cbAddCardItem_M_Facebook;

	private TextBox txtNameCard;

	private Label label12;

	private CheckBox cbAddCardLink667;

	private TextBox txtIdPixel;

	private CheckBox cbSharePixel;

	private Label label13;

	private TextBox txtBM_Pixel;

	private TextBox txtPushCardPrimary;

	private CheckBox cbAddCodeCard;

	private NumericUpDown numDelay;

	private Label label14;

	private CheckBox cbReloadTk;

	private Button btnGetDraftPE;

	private CheckBox rbCreateCampPE;

	private CheckBox cbAddSuite;

	private CheckBox cbAddBoostpost;

	private CheckBox cbAddCardLink1;

	private ImageList imageList1;

	private CheckBox cbAddCardAPI;

	private GroupBox groupBox10;

	private CheckBox cbRemoveAdsToGroup;

	private ComboBox ccbGroupInBM;

	private CheckBox cbAddAdsToGroup;

	private Button button3;

	private CheckBox cbApproved2;

	private NumericUpDown numDelayApproved2;

	private TextBox txtBugetCamp;

	private CheckBox cbChangeBugetGruopAds;

	private CheckBox cbChangeBugetCamp;

	private Label label16;

	private Label label15;

	private ComboBox ccbPostId;

	private ComboBox ccbPageId;

	private CheckBox cbChangePost;

	private Button button4;

	private CheckBox cbRollingMatThread;

	private CheckBox cbAddCardRequest;

	private NumericUpDown numDelayRemoveCard;

	private Label label17;

	private CheckBox cbRemoveCamp;

	private Panel plAddByPro5;

	private CheckBox cbAddCardByPage;

	private RadioButton rbListCardCenter;

	private ComboBox ccbListCard;

	private TextBox txtPro5List;

	private NumericUpDown numAddActOnPage;

	private Label label18;

	private CheckBox cbAddCartMFacebook2;

	private CheckBox cbCardVerify;

	private NumericUpDown numLifeCycle;

	private Label label20;

	private NumericUpDown numDelayLifeCycle;

	private Label label21;

	private Label label22;

	private SplitContainer splitContainer4;

	public bool ImportCamp { get; set; }

	public bool PublishAds { get; set; }

	public bool PublishGroup { get; set; }

	public bool PublishCamp { get; set; }

	public bool RemoveActInBM { get; set; }

	public bool ResetLimit { get; set; }

	public bool ClearAddraft { get; set; }

	public bool ApprovedPayment { get; set; }

	public bool SetLimit { get; set; }

	public bool AddCart { get; set; }

	public string Limit { get; set; }

	public string BMID { get; set; }

	public int intThread { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmPublishCampText(List<string> listAdsAcc, frmAdsManager frmCamp, int Active, int Die, int Unsettled, int Pending_Review, int In_Grace_Period, int temporarily_unavailable, int pending_closure, List<adaccountsData> listData_Act)
	{
		_003C_003Ec__DisplayClass68_0 _003C_003Ec__DisplayClass68_ = new _003C_003Ec__DisplayClass68_0();
		_003C_003Ec__DisplayClass68_.listAdsAcc = listAdsAcc;
		base._002Ector();
		InitializeComponent<ComponentResourceManager, Container, DataGridView, Button, CheckBox, StatusStrip, ToolStripStatusLabel, TextBox, Label, ComboBox, GroupBox, NumericUpDown, TabControl, TabPage, SplitContainer, RadioButton, Panel, bool, ContextMenu, MenuItem, object, MouseEventArgs, EventArgs, ToolStripItem, string, int, char, decimal, List<business_asset_groups_data>.Enumerator, Dictionary<string, string>, Exception, List<business_users_data>.Enumerator, List<addraft_fragments_2_data>.Enumerator, List<addraft_fragments_data>.Enumerator, List<addraft_fragments_data_value>.Enumerator, List<post_data>.Enumerator, ImageListStreamer, Icon, FormClosingEventArgs>();
		lbActive.Text = Active.ToString();
		lbDie.Text = Die.ToString();
		lbUnsettled.Text = Unsettled.ToString();
		lbReview.Text = Pending_Review.ToString();
		lbGracePeriod.Text = In_Grace_Period.ToString();
		lbTemporarityUnavable.Text = temporarily_unavailable.ToString();
		lbPendingCloure.Text = pending_closure.ToString();
		frm = frmCamp;
		if (listData_Act != null)
		{
			ListAds = listData_Act;
		}
		else
		{
			ListAds = frmCamp.listData.Where(_003C_003Ec__DisplayClass68_._003C_002Ector_003Eb__0<bool>).ToList();
		}
		gvData.AutoGenerateColumns = false;
		gvData.Columns.Clear();
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "int_id");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Quốc gia", "business_country_code");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Trạng thái", "message");
		loadData<int>();
		gvCard.AutoGenerateColumns = false;
		gvCard.Columns.Clear();
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Card_Number", "Card_Number");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Exp_Month", "Exp_Month");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Exp_Year", "Exp_Year");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Card_Security", "Card_Security");
		GenColumn_Card<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Status", "Status");
	}

	public void loadData<T0>()
	{
		//IL_002f: Expected O, but got I4
		gvData.DataSource = null;
		gvData.DataSource = ListAds;
		lbQuantity.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)ListAds.Count).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenColumn_Card<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val == null)
		{
			T2 val2 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvCard.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T1 val3 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvCard.Columns.Add((DataGridViewColumn)val3);
		}
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
		//IL_007d: Expected O, but got I4
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
			T0 val2 = (T0)RollingMatThread;
			if (val2 != null)
			{
				new Thread(thrStart_RollingMan<T0, int, List<ListStringData>, List<adaccountsData>, List<adaccountsData>.Enumerator, List<ListStringData>.Enumerator, List<string>.Enumerator, string, Exception, Dictionary<string, string>, IJavaScriptExecutor, T1, List<object>, List<addraft_fragments_2_data>.Enumerator, List<addraft_fragments_data>.Enumerator, List<object>.Enumerator, Guid>).Start();
			}
			else
			{
				new Thread(thrStart<T0, List<ListStringData>, List<adaccountsData>, int, List<adaccountsData>.Enumerator, List<addraft_fragments_2_data>.Enumerator, List<ListStringData>.Enumerator, Thread, ParameterizedThreadStart, string, List<string>, StringReader, List<string>.Enumerator, Exception, List<object>, Dictionary<string, string>, char, IJavaScriptExecutor, T1, ReadOnlyCollection<IWebElement>, IWebElement, List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator, Guid, List<addraft_fragments_data>.Enumerator, List<object>.Enumerator, ICollection<object>>).Start();
			}
		}
	}

	private void getAddraft<T0, T1, T2, T3>()
	{
		//IL_0016: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected I4, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		_003C_003Ec__DisplayClass73_0 _003C_003Ec__DisplayClass73_ = new _003C_003Ec__DisplayClass73_0();
		_003C_003Ec__DisplayClass73_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass73_.countThread = 0;
		T0 val = (T0)0;
		while (true)
		{
			T2 val2 = (T2)((nint)val < ListAds.Count);
			if (val2 == null)
			{
				break;
			}
			while (true)
			{
				T2 val3 = (T2)(isRunning && _003C_003Ec__DisplayClass73_.countThread >= intThread);
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
			T1 val5 = (T1)new Thread(_003C_003Ec__DisplayClass73_._003CgetAddraft_003Eb__0<T0, T2, object, Dictionary<string, string>, string, IJavaScriptExecutor>);
			((Thread)val5).Start((object)val);
			T0 val6 = (T0)_003C_003Ec__DisplayClass73_.countThread;
			_003C_003Ec__DisplayClass73_.countThread = val6 + 1;
			val = (T0)(val + 1);
		}
		while (true)
		{
			T2 val7 = (T2)(isRunning && _003C_003Ec__DisplayClass73_.countThread > 0);
			if (val7 != null)
			{
				Thread.Sleep(1500);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getAddraft_Promise<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
	{
		//IL_0012: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0045: Expected I4, but got O
		//IL_006d: Expected I4, but got O
		//IL_00ac: Expected O, but got I4
		//IL_019a: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)0;
		while (true)
		{
			T2 val3 = (T2)((nint)val2 < ListAds.Count);
			if (val3 == null)
			{
				break;
			}
			T2 val4 = (T2)(!isRunning);
			if (val4 != null)
			{
				break;
			}
			ListAds[(int)val2].message = STATUS.Processing.ToString();
			ListStringData listStringData = new ListStringData();
			listStringData.str1 = ListAds[(int)val2].id;
			((List<ListStringData>)val).Add(listStringData);
			T2 val5 = (T2)((((List<ListStringData>)val).Count >= intThread || (nint)val2 == ListAds.Count - 1) && ((List<ListStringData>)val).Count > 0);
			if (val5 != null)
			{
				T2 addraftCamp_2_Promise = frm.chrome.getAddraftCamp_2_Promise<T2, T6, T7, T5, T8, T1, T9, T0>(val);
				T3 val6 = (T3)ListAds.Join((IEnumerable<ListStringData>)val, (Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.id), (Func<ListStringData, T6>)(object)(Func<ListStringData, string>)((ListStringData d) => (T6)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
				T2 val7 = addraftCamp_2_Promise;
				if (val7 != null)
				{
					T4 enumerator = (T4)((List<adaccountsData>)val6).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
							Console.WriteLine(current.id);
							T5 enumerator2 = (T5)((List<ListStringData>)val).GetEnumerator();
							try
							{
								while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
								{
									ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
									Console.WriteLine(current2.str1);
									T2 val8 = (T2)current.id.Equals(current2.str1);
									if (val8 != null)
									{
										Console.WriteLine("OK OK OK");
										current.addraft_fragments = (addraft_fragments_2)current2.obj1;
										T2 val9 = (T2)(current.addraft_fragments == null || current.addraft_fragments.data == null);
										if (val9 != null)
										{
											current.message = STATUS.lỗi.ToString();
										}
										else
										{
											current.message = STATUS.Ready.ToString();
										}
										break;
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator2))).Dispose();
							}
							Console.WriteLine("===========" + Environment.NewLine + Environment.NewLine);
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				else
				{
					T4 enumerator3 = (T4)((List<adaccountsData>)val6).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator3))->MoveNext())
						{
							adaccountsData current3 = ((List<adaccountsData>.Enumerator*)(&enumerator3))->Current;
							current3.message = frmMain.STATUS.lỗi.ToString();
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator3))).Dispose();
					}
				}
				((List<ListStringData>)val).Clear();
				Thread.Sleep(intDelay);
			}
			val2 = (T1)(val2 + 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void thrStart_RollingMan<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
	{
		//IL_0003: Expected O, but got I4
		//IL_0005: Expected O, but got I4
		//IL_0015: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_005a: Expected I4, but got O
		//IL_006d: Expected I4, but got O
		//IL_007f: Expected O, but got I4
		//IL_0092: Expected I4, but got O
		//IL_00a9: Expected I4, but got O
		//IL_00c4: Expected I4, but got O
		//IL_00e5: Expected I4, but got O
		//IL_00f8: Expected I4, but got O
		//IL_010a: Expected O, but got I4
		//IL_011a: Expected I4, but got O
		//IL_013e: Expected I4, but got O
		//IL_0161: Expected I4, but got O
		//IL_0182: Expected I4, but got O
		//IL_019e: Expected O, but got I4
		//IL_01cb: Expected I4, but got O
		//IL_01e3: Expected I4, but got O
		//IL_0202: Expected I4, but got O
		//IL_023c: Expected O, but got I4
		//IL_023c: Expected O, but got I4
		//IL_023c: Expected O, but got I4
		//IL_02ed: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		//IL_035f: Expected I4, but got O
		//IL_0389: Expected I4, but got O
		//IL_0484: Expected O, but got I4
		//IL_0530: Expected I4, but got O
		//IL_055a: Expected I4, but got O
		//IL_0655: Expected O, but got I4
		//IL_06e6: Expected O, but got I4
		//IL_06f9: Expected I4, but got O
		//IL_0715: Expected O, but got I4
		//IL_0744: Expected I4, but got O
		//IL_07a2: Expected I4, but got O
		//IL_07be: Expected I4, but got O
		//IL_07f3: Expected I4, but got O
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected O, but got Unknown
		//IL_082b: Expected O, but got I4
		try
		{
			T0 val = (T0)1;
			T1 val2 = (T1)0;
			while (true)
			{
				T0 val3 = (T0)((nint)val2 < ListAds.Count);
				if (val3 == null)
				{
					break;
				}
				T0 val4 = (T0)(!isRunning);
				if (val4 != null)
				{
					return;
				}
				T0 val5 = (T0)(PublishAds || PublishCamp || PublishGroup);
				if (val5 != null)
				{
					T0 val6 = (T0)(ListAds[(int)val2].addraft_fragments == null || ListAds[(int)val2].addraft_fragments.data == null);
					if (val6 != null)
					{
						ListAds[(int)val2].addraft_fragments = frm.chrome.getAddraftCamp_2<T0, T1, T9, T7, T10, T11>((T7)ListAds[(int)val2].id);
						ListAds[(int)val2].message = STATUS.Processing.ToString();
						T0 val7 = (T0)(ListAds[(int)val2].addraft_fragments == null || ListAds[(int)val2].addraft_fragments.data == null);
						if (val7 != null)
						{
							ListAds[(int)val2].message = STATUS.lỗi.ToString();
						}
						else
						{
							ListAds[(int)val2].message = STATUS.Ready.ToString();
						}
					}
					else
					{
						ListAds[(int)val2].message = STATUS.Ready.ToString();
					}
					T0 val8 = (T0)ListAds[(int)val2].message.Equals(STATUS.Ready.ToString());
					if (val8 != null)
					{
						T2 val9 = (T2)Activator.CreateInstance(typeof(T2));
						ListStringData listStringData = new ListStringData();
						listStringData.str1 = ListAds[(int)val2].id;
						listStringData.obj1 = ListAds[(int)val2].addraft_fragments;
						((List<ListStringData>)val9).Add(listStringData);
						ListAds[(int)val2].message = frmMain.STATUS.Processing.ToString();
						val = frm.chrome.publishCamps_Promise<T0, T5, T7, T12, T13, T9, T14, T15, T11, T8, T2>(val9, (T0)PublishCamp, (T0)PublishGroup, (T0)PublishAds);
						T3 val10 = (T3)ListAds.Join((IEnumerable<ListStringData>)val9, (Func<adaccountsData, T7>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T4 enumerator = (T4)((List<adaccountsData>)val10).GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
							{
								adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
								T5 enumerator2 = (T5)((List<ListStringData>)val9).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
									{
										ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
										T0 val11 = (T0)current.id.Equals(current2.str1);
										if (val11 != null)
										{
											current.message = current2.str2;
											break;
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
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
						}
					}
				}
				T0 val12 = (T0)boolCampSuite;
				if (val12 != null)
				{
					T2 val13 = (T2)Activator.CreateInstance(typeof(T2));
					ListAds[(int)val2].message = STATUS.Processing.ToString();
					ListStringData listStringData2 = new ListStringData();
					listStringData2.str1 = ListAds[(int)val2].id;
					listStringData2.str2 = null;
					listStringData2.str3 = textCamp;
					((List<ListStringData>)val13).Add(listStringData2);
					val = frm.chrome.CampSuite_Promise<T0, T7, T12, T5, T9, T16, T1, T8, T2>(val13, (T7)textCamp);
					T3 val14 = (T3)ListAds.Join((IEnumerable<ListStringData>)val13, (Func<adaccountsData, T7>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
					T0 val15 = val;
					if (val15 != null)
					{
						T4 enumerator3 = (T4)((List<adaccountsData>)val14).GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator3))->MoveNext())
							{
								adaccountsData current3 = ((List<adaccountsData>.Enumerator*)(&enumerator3))->Current;
								T5 enumerator4 = (T5)((List<ListStringData>)val13).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator4))->MoveNext())
									{
										ListStringData current4 = ((List<ListStringData>.Enumerator*)(&enumerator4))->Current;
										T0 val16 = (T0)current3.id.Equals(current4.str1);
										if (val16 != null)
										{
											current3.message = current4.str4;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator4))).Dispose();
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
						T4 enumerator5 = (T4)((List<adaccountsData>)val14).GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator5))->MoveNext())
							{
								adaccountsData current5 = ((List<adaccountsData>.Enumerator*)(&enumerator5))->Current;
								current5.message = frmMain.STATUS.lỗi.ToString();
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator5))).Dispose();
						}
					}
				}
				T0 val17 = (T0)boolBoostPost;
				if (val17 != null)
				{
					T2 val18 = (T2)Activator.CreateInstance(typeof(T2));
					ListAds[(int)val2].message = STATUS.Processing.ToString();
					ListStringData listStringData3 = new ListStringData();
					listStringData3.str1 = ListAds[(int)val2].id;
					listStringData3.str2 = null;
					listStringData3.str3 = textCamp;
					((List<ListStringData>)val18).Add(listStringData3);
					val = frm.chrome.CampBoostpost_Promise<T0, T7, T12, T5, T9, T16, T1, T8, T2>(val18, (T7)textCamp);
					T3 val19 = (T3)ListAds.Join((IEnumerable<ListStringData>)val18, (Func<adaccountsData, T7>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T7)a.id), (Func<ListStringData, T7>)(object)(Func<ListStringData, string>)((ListStringData d) => (T7)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
					T0 val20 = val;
					if (val20 != null)
					{
						T4 enumerator6 = (T4)((List<adaccountsData>)val19).GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator6))->MoveNext())
							{
								adaccountsData current6 = ((List<adaccountsData>.Enumerator*)(&enumerator6))->Current;
								T5 enumerator7 = (T5)((List<ListStringData>)val18).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator7))->MoveNext())
									{
										ListStringData current7 = ((List<ListStringData>.Enumerator*)(&enumerator7))->Current;
										T0 val21 = (T0)current6.id.Equals(current7.str1);
										if (val21 != null)
										{
											current6.message = current7.str4;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator7))).Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator6))).Dispose();
						}
					}
					else
					{
						T4 enumerator8 = (T4)((List<adaccountsData>)val19).GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator8))->MoveNext())
							{
								adaccountsData current8 = ((List<adaccountsData>.Enumerator*)(&enumerator8))->Current;
								current8.message = frmMain.STATUS.lỗi.ToString();
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator8))).Dispose();
						}
					}
				}
				T0 val22 = (T0)RemoveCard;
				if (val22 != null)
				{
					T0 val23 = (T0)ListAds[(int)val2].message.Contains(frmMain.STATUS.Done.ToString());
					if (val23 != null)
					{
						Thread.Sleep(DelayRemoveCard);
						T2 val24 = (T2)Activator.CreateInstance(typeof(T2));
						T6 enumerator9 = (T6)ListAds[(int)val2].credential_id.GetEnumerator();
						try
						{
							while (((List<string>.Enumerator*)(&enumerator9))->MoveNext())
							{
								T7 current9 = (T7)((List<string>.Enumerator*)(&enumerator9))->Current;
								((List<ListStringData>)val24).Add(new ListStringData
								{
									str1 = (string)current9
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<string>.Enumerator*)(&enumerator9))).Dispose();
						}
						T0 val25 = frm.chrome.removeCard_Promise<T0, T7, T12, T5, T9, T1, T2>(val24, (T7)ListAds[(int)val2].id);
						if (val25 != null)
						{
							adaccountsData adaccountsData = ListAds[(int)val2];
							adaccountsData.message = adaccountsData.message + ">" + STATUS.Done;
						}
						else
						{
							adaccountsData adaccountsData2 = ListAds[(int)val2];
							adaccountsData2.message = adaccountsData2.message + ">" + STATUS.lỗi;
						}
					}
				}
				val2 = (T1)(val2 + 1);
			}
			isRunning = false;
		}
		catch (Exception ex)
		{
			errorMessage((T7)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void thrStart<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>()
	{
		//IL_0010: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_0061: Expected I4, but got O
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_008e: Expected O, but got I4
		//IL_01ba: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		//IL_01ec: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_0212: Expected I4, but got O
		//IL_0234: Expected I4, but got O
		//IL_0248: Expected I4, but got O
		//IL_025a: Expected O, but got I4
		//IL_0277: Expected I4, but got O
		//IL_029a: Expected I4, but got O
		//IL_032e: Expected O, but got I4
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_047a: Expected O, but got I4
		//IL_0495: Expected O, but got I4
		//IL_04a6: Expected O, but got I4
		//IL_04b8: Expected O, but got I4
		//IL_04cc: Expected I4, but got O
		//IL_04f7: Expected I4, but got O
		//IL_0510: Expected I4, but got O
		//IL_0561: Expected O, but got I4
		//IL_0638: Expected O, but got I4
		//IL_0668: Expected O, but got I4
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Expected O, but got Unknown
		//IL_0723: Expected O, but got I4
		//IL_073e: Expected O, but got I4
		//IL_074f: Expected O, but got I4
		//IL_0761: Expected O, but got I4
		//IL_0775: Expected I4, but got O
		//IL_07a0: Expected I4, but got O
		//IL_07e4: Expected O, but got I4
		//IL_08e8: Expected O, but got I4
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Expected O, but got Unknown
		//IL_09af: Expected O, but got I4
		//IL_09c0: Expected O, but got I4
		//IL_09c8: Expected O, but got I4
		//IL_0a00: Expected O, but got I4
		//IL_0a45: Expected O, but got I4
		//IL_0a49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Expected I4, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Expected O, but got Unknown
		//IL_0a6a: Expected O, but got I4
		//IL_0a76: Expected O, but got I4
		//IL_0aa3: Expected O, but got I4
		//IL_0ab4: Expected O, but got I4
		//IL_0abc: Expected O, but got I4
		//IL_0af4: Expected O, but got I4
		//IL_0b39: Expected O, but got I4
		//IL_0b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Expected I4, but got Unknown
		//IL_0b4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4d: Expected O, but got Unknown
		//IL_0b5e: Expected O, but got I4
		//IL_0b6a: Expected O, but got I4
		//IL_0b97: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bab: Expected O, but got I4
		//IL_0bb3: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bc7: Expected O, but got I4
		//IL_0bcf: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0be3: Expected O, but got I4
		//IL_0beb: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c61: Expected O, but got I4
		//IL_0c84: Expected O, but got I4
		//IL_0c8e: Expected O, but got I4
		//IL_0c9d: Expected I4, but got O
		//IL_0cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Expected O, but got Unknown
		//IL_0ccd: Expected O, but got I4
		//IL_0cfe: Expected O, but got I4
		//IL_0d11: Expected O, but got I4
		//IL_0d4b: Expected O, but got I4
		//IL_0dc4: Expected O, but got I4
		//IL_0de7: Expected O, but got I4
		//IL_0df1: Expected O, but got I4
		//IL_0e40: Expected O, but got I4
		//IL_0e4f: Expected I4, but got O
		//IL_0e6b: Expected O, but got I4
		//IL_0e7c: Expected I4, but got O
		//IL_0e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9b: Expected O, but got Unknown
		//IL_0eaa: Expected O, but got I4
		//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb8: Expected O, but got Unknown
		//IL_0ec9: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0f1f: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0f3b: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f4f: Expected O, but got I4
		//IL_0f57: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f6b: Expected O, but got I4
		//IL_0f73: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f87: Expected O, but got I4
		//IL_0f8f: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fa3: Expected O, but got I4
		//IL_0fab: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fbf: Expected O, but got I4
		//IL_0fc7: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fdb: Expected O, but got I4
		//IL_0fe0: Expected O, but got I4
		//IL_100d: Expected O, but got I4
		//IL_101e: Expected O, but got I4
		//IL_1026: Expected O, but got I4
		//IL_105e: Expected O, but got I4
		//IL_10a3: Expected O, but got I4
		//IL_10a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ad: Expected I4, but got Unknown
		//IL_10b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b7: Expected O, but got Unknown
		//IL_10c8: Expected O, but got I4
		//IL_10d4: Expected O, but got I4
		//IL_1101: Expected O, but got I4
		//IL_1112: Expected O, but got I4
		//IL_111a: Expected O, but got I4
		//IL_1152: Expected O, but got I4
		//IL_1197: Expected O, but got I4
		//IL_119b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1: Expected I4, but got Unknown
		//IL_11a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ab: Expected O, but got Unknown
		//IL_11bc: Expected O, but got I4
		//IL_11c8: Expected O, but got I4
		//IL_11f5: Expected O, but got I4
		//IL_1206: Expected O, but got I4
		//IL_120e: Expected O, but got I4
		//IL_1246: Expected O, but got I4
		//IL_128b: Expected O, but got I4
		//IL_128f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1295: Expected I4, but got Unknown
		//IL_129c: Unknown result type (might be due to invalid IL or missing references)
		//IL_129f: Expected O, but got Unknown
		//IL_12b0: Expected O, but got I4
		//IL_12bc: Expected O, but got I4
		//IL_12e9: Expected O, but got I4
		//IL_1304: Expected O, but got I4
		//IL_1315: Expected O, but got I4
		//IL_1327: Expected O, but got I4
		//IL_133b: Expected I4, but got O
		//IL_1366: Expected I4, but got O
		//IL_13c2: Expected O, but got I4
		//IL_1496: Expected O, but got I4
		//IL_1526: Unknown result type (might be due to invalid IL or missing references)
		//IL_1529: Expected O, but got Unknown
		//IL_154f: Expected O, but got I4
		//IL_156a: Expected O, but got I4
		//IL_157b: Expected O, but got I4
		//IL_158d: Expected O, but got I4
		//IL_15a1: Expected I4, but got O
		//IL_15cc: Expected I4, but got O
		//IL_1629: Expected O, but got I4
		//IL_16fd: Expected O, but got I4
		//IL_178d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1790: Expected O, but got Unknown
		//IL_17b6: Expected O, but got I4
		//IL_17c7: Expected O, but got I4
		//IL_17cf: Expected O, but got I4
		//IL_1807: Expected O, but got I4
		//IL_184c: Expected O, but got I4
		//IL_1850: Unknown result type (might be due to invalid IL or missing references)
		//IL_1856: Expected I4, but got Unknown
		//IL_185d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1860: Expected O, but got Unknown
		//IL_1871: Expected O, but got I4
		//IL_187d: Expected O, but got I4
		//IL_18aa: Expected O, but got I4
		//IL_18c5: Expected O, but got I4
		//IL_18d6: Expected O, but got I4
		//IL_18e8: Expected O, but got I4
		//IL_18fc: Expected I4, but got O
		//IL_1927: Expected I4, but got O
		//IL_1980: Expected O, but got I4
		//IL_1a54: Expected O, but got I4
		//IL_1ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae7: Expected O, but got Unknown
		//IL_1b0d: Expected O, but got I4
		//IL_1b17: Expected O, but got I4
		//IL_1b1a: Expected O, but got I4
		//IL_1b2e: Expected O, but got I4
		//IL_1b3f: Expected O, but got I4
		//IL_1b51: Expected O, but got I4
		//IL_1b65: Expected I4, but got O
		//IL_1b79: Expected I4, but got O
		//IL_1b91: Expected O, but got I4
		//IL_1ba5: Expected I4, but got O
		//IL_1bd0: Expected I4, but got O
		//IL_1c60: Expected O, but got I4
		//IL_1d3a: Expected O, but got I4
		//IL_1dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd3: Expected O, but got Unknown
		//IL_1ddb: Expected O, but got I4
		//IL_1dde: Expected O, but got I4
		//IL_1ded: Expected I4, but got O
		//IL_1e01: Expected I4, but got O
		//IL_1e19: Expected O, but got I4
		//IL_1e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e27: Expected O, but got Unknown
		//IL_1e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e31: Expected O, but got Unknown
		//IL_1e42: Expected O, but got I4
		//IL_1e55: Expected O, but got I4
		//IL_1e6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6d: Expected O, but got Unknown
		//IL_1e96: Expected O, but got I4
		//IL_1eb1: Expected O, but got I4
		//IL_1ec2: Expected O, but got I4
		//IL_1ed4: Expected O, but got I4
		//IL_1ee8: Expected I4, but got O
		//IL_1f13: Expected I4, but got O
		//IL_1f6c: Expected O, but got I4
		//IL_2046: Expected O, but got I4
		//IL_20d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d9: Expected O, but got Unknown
		//IL_20ff: Expected O, but got I4
		//IL_2109: Expected O, but got I4
		//IL_211d: Expected O, but got I4
		//IL_212e: Expected O, but got I4
		//IL_2140: Expected O, but got I4
		//IL_2154: Expected I4, but got O
		//IL_217f: Expected I4, but got O
		//IL_21d8: Expected O, but got I4
		//IL_21e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e9: Expected O, but got Unknown
		//IL_22bc: Expected O, but got I4
		//IL_2362: Expected O, but got I4
		//IL_2369: Expected O, but got I4
		//IL_2381: Unknown result type (might be due to invalid IL or missing references)
		//IL_2384: Expected O, but got Unknown
		//IL_23bd: Expected O, but got I4
		//IL_23c7: Expected O, but got I4
		//IL_23e1: Expected O, but got I4
		//IL_23f1: Expected O, but got I4
		//IL_2405: Expected I4, but got O
		//IL_241c: Expected I4, but got O
		//IL_2438: Expected I4, but got O
		//IL_2457: Expected I4, but got O
		//IL_247a: Expected I4, but got O
		//IL_24a2: Expected I4, but got O
		//IL_24c8: Expected O, but got I4
		//IL_24e2: Expected I4, but got O
		//IL_24fb: Expected I4, but got O
		//IL_251b: Expected I4, but got O
		//IL_2540: Expected I4, but got O
		//IL_2586: Expected O, but got I4
		//IL_2594: Unknown result type (might be due to invalid IL or missing references)
		//IL_2597: Expected O, but got Unknown
		//IL_25bb: Expected O, but got I4
		//IL_25bb: Expected O, but got I4
		//IL_25bb: Expected O, but got I4
		//IL_2682: Expected O, but got I4
		//IL_2707: Expected O, but got I4
		//IL_2710: Expected O, but got I4
		//IL_2728: Unknown result type (might be due to invalid IL or missing references)
		//IL_272b: Expected O, but got Unknown
		//IL_273e: Expected O, but got I4
		//IL_2758: Expected O, but got I4
		//IL_2779: Expected O, but got I4
		//IL_278e: Expected O, but got I4
		//IL_27a4: Expected O, but got I4
		//IL_27bc: Expected I4, but got O
		//IL_27ed: Expected I4, but got O
		//IL_283d: Expected O, but got I4
		//IL_2939: Expected O, but got I4
		//IL_29ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ef: Expected O, but got Unknown
		//IL_2a19: Expected O, but got I4
		//IL_2a57: Expected O, but got I4
		//IL_2a61: Expected O, but got I4
		//IL_2aa5: Expected O, but got I4
		//IL_2b03: Expected O, but got I4
		//IL_2b0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b15: Expected I4, but got Unknown
		//IL_2b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b23: Expected O, but got Unknown
		//IL_2b38: Expected O, but got I4
		//IL_2b48: Expected O, but got I4
		//IL_2b8c: Expected O, but got I4
		//IL_2bda: Expected O, but got I4
		//IL_2be2: Expected O, but got I4
		//IL_2be9: Expected O, but got I4
		//IL_2c1a: Expected O, but got I4
		//IL_2c3b: Expected O, but got I4
		//IL_2c50: Expected O, but got I4
		//IL_2c66: Expected O, but got I4
		//IL_2c7e: Expected I4, but got O
		//IL_2caf: Expected I4, but got O
		//IL_2cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd4: Expected O, but got Unknown
		//IL_2d24: Expected O, but got I4
		//IL_2e1d: Expected O, but got I4
		//IL_2e57: Expected O, but got I4
		//IL_2f0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f10: Expected O, but got Unknown
		//IL_2f3a: Expected O, but got I4
		//IL_2f4f: Expected O, but got I4
		//IL_2f59: Expected O, but got I4
		//IL_2f95: Expected O, but got I4
		//IL_2fe2: Expected O, but got I4
		//IL_2fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fec: Expected I4, but got Unknown
		//IL_2ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ffa: Expected O, but got Unknown
		//IL_300f: Expected O, but got I4
		//IL_301f: Expected O, but got I4
		//IL_3050: Expected O, but got I4
		//IL_3071: Expected O, but got I4
		//IL_3086: Expected O, but got I4
		//IL_309c: Expected O, but got I4
		//IL_30b4: Expected I4, but got O
		//IL_30e5: Expected I4, but got O
		//IL_3135: Expected O, but got I4
		//IL_322b: Expected O, but got I4
		//IL_32dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_32e1: Expected O, but got Unknown
		//IL_330b: Expected O, but got I4
		//IL_332c: Expected O, but got I4
		//IL_3341: Expected O, but got I4
		//IL_3357: Expected O, but got I4
		//IL_336f: Expected I4, but got O
		//IL_33a0: Expected I4, but got O
		//IL_33f0: Expected O, but got I4
		//IL_34e6: Expected O, but got I4
		//IL_3597: Unknown result type (might be due to invalid IL or missing references)
		//IL_359c: Expected O, but got Unknown
		//IL_35c6: Expected O, but got I4
		//IL_35e7: Expected O, but got I4
		//IL_35fc: Expected O, but got I4
		//IL_3612: Expected O, but got I4
		//IL_362a: Expected I4, but got O
		//IL_365b: Expected I4, but got O
		//IL_36ab: Expected O, but got I4
		//IL_37a1: Expected O, but got I4
		//IL_3852: Unknown result type (might be due to invalid IL or missing references)
		//IL_3857: Expected O, but got Unknown
		//IL_3881: Expected O, but got I4
		//IL_38a3: Expected O, but got I4
		//IL_38b8: Expected O, but got I4
		//IL_38ce: Expected O, but got I4
		//IL_38e6: Expected I4, but got O
		//IL_3917: Expected I4, but got O
		//IL_3967: Expected O, but got I4
		//IL_3a78: Expected O, but got I4
		//IL_3b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b2e: Expected O, but got Unknown
		//IL_3b6e: Expected O, but got I4
		//IL_3b90: Expected O, but got I4
		//IL_3ba5: Expected O, but got I4
		//IL_3bbb: Expected O, but got I4
		//IL_3bd3: Expected I4, but got O
		//IL_3c04: Expected I4, but got O
		//IL_3c54: Expected O, but got I4
		//IL_3d65: Expected O, but got I4
		//IL_3e16: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1b: Expected O, but got Unknown
		//IL_3e5b: Expected O, but got I4
		//IL_3e70: Expected O, but got I4
		//IL_3e7a: Expected O, but got I4
		//IL_3eb6: Expected O, but got I4
		//IL_3f03: Expected O, but got I4
		//IL_3f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f0d: Expected I4, but got Unknown
		//IL_3f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f1b: Expected O, but got Unknown
		//IL_3f30: Expected O, but got I4
		//IL_3f40: Expected O, but got I4
		//IL_3f71: Expected O, but got I4
		//IL_3f88: Expected O, but got I4
		//IL_3f97: Expected O, but got I4
		//IL_3faf: Expected I4, but got O
		//IL_3fe6: Expected I4, but got O
		//IL_4002: Unknown result type (might be due to invalid IL or missing references)
		//IL_4007: Expected O, but got Unknown
		//IL_401c: Expected O, but got I4
		//IL_4035: Expected O, but got I4
		//IL_4095: Expected O, but got I4
		//IL_40b4: Expected I4, but got O
		//IL_40db: Expected I4, but got O
		//IL_40fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_40ff: Expected O, but got Unknown
		//IL_4114: Expected O, but got I4
		//IL_4124: Expected O, but got I4
		//IL_4155: Expected O, but got I4
		//IL_416a: Expected O, but got I4
		//IL_4174: Expected O, but got I4
		//IL_41b0: Expected O, but got I4
		//IL_41fd: Expected O, but got I4
		//IL_4201: Unknown result type (might be due to invalid IL or missing references)
		//IL_4207: Expected I4, but got Unknown
		//IL_4210: Unknown result type (might be due to invalid IL or missing references)
		//IL_4215: Expected O, but got Unknown
		//IL_422a: Expected O, but got I4
		//IL_423a: Expected O, but got I4
		//IL_426b: Expected O, but got I4
		//IL_428c: Expected O, but got I4
		//IL_42a1: Expected O, but got I4
		//IL_42b7: Expected O, but got I4
		//IL_42cf: Expected I4, but got O
		//IL_4300: Expected I4, but got O
		//IL_4350: Expected O, but got I4
		//IL_444c: Expected O, but got I4
		//IL_44fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4502: Expected O, but got Unknown
		//IL_452c: Expected O, but got I4
		//IL_4560: Expected O, but got I4
		//IL_456f: Expected O, but got I4
		//IL_4594: Expected I4, but got O
		//IL_45b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b9: Expected O, but got Unknown
		//IL_45ce: Expected O, but got I4
		//IL_462b: Expected O, but got I4
		//IL_4648: Expected I4, but got O
		//IL_468f: Expected O, but got I4
		//IL_4699: Expected O, but got I4
		//IL_46dd: Expected O, but got I4
		//IL_473b: Expected O, but got I4
		//IL_4747: Unknown result type (might be due to invalid IL or missing references)
		//IL_474d: Expected I4, but got Unknown
		//IL_4756: Unknown result type (might be due to invalid IL or missing references)
		//IL_475b: Expected O, but got Unknown
		//IL_4770: Expected O, but got I4
		//IL_4785: Expected O, but got I4
		//IL_47b6: Expected O, but got I4
		//IL_47ea: Expected O, but got I4
		//IL_47f9: Expected O, but got I4
		//IL_481e: Expected I4, but got O
		//IL_483e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4843: Expected O, but got Unknown
		//IL_4858: Expected O, but got I4
		//IL_48b5: Expected O, but got I4
		//IL_48d2: Expected I4, but got O
		//IL_4919: Expected O, but got I4
		//IL_4923: Expected O, but got I4
		//IL_4967: Expected O, but got I4
		//IL_49c5: Expected O, but got I4
		//IL_49d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_49d7: Expected I4, but got Unknown
		//IL_49e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_49e5: Expected O, but got Unknown
		//IL_49fa: Expected O, but got I4
		//IL_4a0f: Expected O, but got I4
		//IL_4a40: Expected O, but got I4
		//IL_4a74: Expected O, but got I4
		//IL_4a83: Expected O, but got I4
		//IL_4aa8: Expected I4, but got O
		//IL_4ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4acd: Expected O, but got Unknown
		//IL_4ae2: Expected O, but got I4
		//IL_4b4a: Expected O, but got I4
		//IL_4b54: Expected O, but got I4
		//IL_4b98: Expected O, but got I4
		//IL_4bf6: Expected O, but got I4
		//IL_4c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c08: Expected I4, but got Unknown
		//IL_4c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c16: Expected O, but got Unknown
		//IL_4c2b: Expected O, but got I4
		//IL_4c40: Expected O, but got I4
		//IL_4c71: Expected O, but got I4
		//IL_4c92: Expected O, but got I4
		//IL_4ca1: Expected O, but got I4
		//IL_4cc3: Expected I4, but got O
		//IL_4ce3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ce8: Expected O, but got Unknown
		//IL_4cfd: Expected O, but got I4
		//IL_4d2b: Expected O, but got I4
		//IL_4d35: Expected O, but got I4
		//IL_4d71: Expected O, but got I4
		//IL_4dbe: Expected O, but got I4
		//IL_4dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dc8: Expected I4, but got Unknown
		//IL_4dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dd6: Expected O, but got Unknown
		//IL_4deb: Expected O, but got I4
		//IL_4dfb: Expected O, but got I4
		//IL_4e2c: Expected O, but got I4
		//IL_4e60: Expected O, but got I4
		//IL_4e6f: Expected O, but got I4
		//IL_4e91: Expected I4, but got O
		//IL_4eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4eb6: Expected O, but got Unknown
		//IL_4ecb: Expected O, but got I4
		//IL_4f4c: Expected O, but got I4
		//IL_4f56: Expected O, but got I4
		//IL_4f9a: Expected O, but got I4
		//IL_4ff8: Expected O, but got I4
		//IL_5004: Unknown result type (might be due to invalid IL or missing references)
		//IL_500a: Expected I4, but got Unknown
		//IL_5013: Unknown result type (might be due to invalid IL or missing references)
		//IL_5018: Expected O, but got Unknown
		//IL_502d: Expected O, but got I4
		//IL_503d: Expected O, but got I4
		//IL_506e: Expected O, but got I4
		//IL_508f: Expected O, but got I4
		//IL_509e: Expected O, but got I4
		//IL_50c0: Expected I4, but got O
		//IL_50e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_50e5: Expected O, but got Unknown
		//IL_50fa: Expected O, but got I4
		//IL_5128: Expected O, but got I4
		//IL_5132: Expected O, but got I4
		//IL_516e: Expected O, but got I4
		//IL_51bb: Expected O, but got I4
		//IL_51bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_51c5: Expected I4, but got Unknown
		//IL_51ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_51d3: Expected O, but got Unknown
		//IL_51e8: Expected O, but got I4
		//IL_51f8: Expected O, but got I4
		//IL_5229: Expected O, but got I4
		//IL_524a: Expected O, but got I4
		//IL_5259: Expected O, but got I4
		//IL_527b: Expected I4, but got O
		//IL_529b: Unknown result type (might be due to invalid IL or missing references)
		//IL_52a0: Expected O, but got Unknown
		//IL_52b5: Expected O, but got I4
		//IL_52e3: Expected O, but got I4
		//IL_52ed: Expected O, but got I4
		//IL_5329: Expected O, but got I4
		//IL_5376: Expected O, but got I4
		//IL_537a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5380: Expected I4, but got Unknown
		//IL_5389: Unknown result type (might be due to invalid IL or missing references)
		//IL_538e: Expected O, but got Unknown
		//IL_53a3: Expected O, but got I4
		//IL_53b3: Expected O, but got I4
		//IL_53e4: Expected O, but got I4
		//IL_53fc: Expected O, but got I4
		//IL_541d: Expected O, but got I4
		//IL_5432: Expected O, but got I4
		//IL_5448: Expected O, but got I4
		//IL_5460: Expected I4, but got O
		//IL_5479: Expected I4, but got O
		//IL_5497: Expected I4, but got O
		//IL_54ba: Expected I4, but got O
		//IL_54e2: Expected I4, but got O
		//IL_550f: Expected I4, but got O
		//IL_553f: Expected I4, but got O
		//IL_5573: Expected I4, but got O
		//IL_55a5: Expected O, but got I4
		//IL_55ba: Expected I4, but got O
		//IL_55e4: Expected I4, but got O
		//IL_5615: Expected I4, but got O
		//IL_5632: Expected I4, but got O
		//IL_56b3: Expected O, but got I4
		//IL_57a9: Expected O, but got I4
		//IL_585a: Unknown result type (might be due to invalid IL or missing references)
		//IL_585f: Expected O, but got Unknown
		//IL_5889: Expected O, but got I4
		//IL_58aa: Expected O, but got I4
		//IL_58bf: Expected O, but got I4
		//IL_58d5: Expected O, but got I4
		//IL_58ed: Expected I4, but got O
		//IL_591e: Expected I4, but got O
		//IL_596e: Expected O, but got I4
		//IL_5a70: Expected O, but got I4
		//IL_5b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b26: Expected O, but got Unknown
		//IL_5b4d: Expected O, but got I4
		try
		{
			_003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass76_0();
			CS_0024_003C_003E8__locals0._003C_003E4__this = this;
			T0 isDone = (T0)1;
			CS_0024_003C_003E8__locals0.countThread = 0;
			T0 val = (T0)ReloadTk;
			if (val != null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val3 = (T3)0;
				while (true)
				{
					T0 val4 = (T0)((nint)val3 < ListAds.Count);
					if (val4 == null)
					{
						break;
					}
					T0 val5 = (T0)(!isRunning);
					if (val5 == null)
					{
						ListStringData listStringData = new ListStringData();
						listStringData.str1 = ListAds[(int)val3].id;
						((List<ListStringData>)val2).Add(listStringData);
						T3 val6 = val3;
						val3 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				isDone = frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val2);
				T2 val7 = (T2)ListAds.Join((IEnumerable<ListStringData>)val2, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
				T0 val8 = isDone;
				if (val8 != null)
				{
					T4 enumerator = (T4)((List<adaccountsData>)val7).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
							current.message = frmMain.STATUS.Done.ToString();
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				else
				{
					T4 enumerator2 = (T4)((List<adaccountsData>)val7).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator2))->MoveNext())
						{
							adaccountsData current2 = ((List<adaccountsData>.Enumerator*)(&enumerator2))->Current;
							current2.message = frmMain.STATUS.lỗi.ToString();
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator2))).Dispose();
					}
				}
				((List<ListStringData>)val2).Clear();
			}
			T0 val9 = (T0)ClearAddraft;
			if (val9 != null)
			{
				getAddraft_Promise<T1, T3, T0, T2, T4, T6, T9, T14, T15, T13>();
				T1 val10 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val11 = (T3)0;
				while (true)
				{
					T0 val12 = (T0)((nint)val11 < ListAds.Count);
					if (val12 == null)
					{
						break;
					}
					T0 val13 = (T0)(!isRunning);
					if (val13 != null)
					{
						return;
					}
					ListAds[(int)val11].message = STATUS.Clearing.ToString();
					T0 val14 = (T0)(ListAds[(int)val11].addraft_fragments != null && ListAds[(int)val11].addraft_fragments.data != null);
					if (val14 != null)
					{
						ListStringData listStringData2 = new ListStringData();
						listStringData2.str1 = ListAds[(int)val11].id;
						listStringData2.str2 = "";
						T5 enumerator3 = (T5)ListAds[(int)val11].addraft_fragments.data.GetEnumerator();
						try
						{
							while (((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->MoveNext())
							{
								addraft_fragments_2_data current3 = ((List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))->Current;
								ListStringData listStringData3 = listStringData2;
								listStringData3.str2 = listStringData3.str2 + current3.id + "|";
							}
						}
						finally
						{
							((IDisposable)(*(List<addraft_fragments_2_data>.Enumerator*)(&enumerator3))).Dispose();
						}
						((List<ListStringData>)val10).Add(listStringData2);
					}
					T0 val15 = (T0)((((List<ListStringData>)val10).Count >= intThread || (nint)val11 == ListAds.Count - 1) && ((List<ListStringData>)val10).Count > 0);
					if (val15 != null)
					{
						isDone = frm.chrome.clearAddrafts_Promise<T0, T9, T6, T3, T15, T14, T13, T1, T16>(val10);
						T2 val16 = (T2)ListAds.Join((IEnumerable<ListStringData>)val10, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val17 = isDone;
						if (val17 != null)
						{
							T4 enumerator4 = (T4)((List<adaccountsData>)val16).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator4))->MoveNext())
								{
									adaccountsData current4 = ((List<adaccountsData>.Enumerator*)(&enumerator4))->Current;
									current4.message = frmMain.STATUS.Done.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator4))).Dispose();
							}
						}
						else
						{
							T4 enumerator5 = (T4)((List<adaccountsData>)val16).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator5))->MoveNext())
								{
									adaccountsData current5 = ((List<adaccountsData>.Enumerator*)(&enumerator5))->Current;
									current5.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator5))).Dispose();
							}
						}
						((List<ListStringData>)val10).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val11;
					val11 = (T3)(val6 + 1);
				}
			}
			T0 val18 = (T0)SetLimit;
			if (val18 != null)
			{
				T1 val19 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val20 = (T3)0;
				while (true)
				{
					T0 val21 = (T0)((nint)val20 < ListAds.Count);
					if (val21 == null)
					{
						break;
					}
					T0 val22 = (T0)(!isRunning);
					if (val22 != null)
					{
						return;
					}
					ListAds[(int)val20].message = STATUS.Processing.ToString();
					ListStringData listStringData4 = new ListStringData();
					listStringData4.str1 = ListAds[(int)val20].id;
					listStringData4.str2 = ListAds[(int)val20].currency;
					listStringData4.str3 = Limit;
					((List<ListStringData>)val19).Add(listStringData4);
					T0 val23 = (T0)((((List<ListStringData>)val19).Count >= intThread || (nint)val20 == ListAds.Count - 1) && ((List<ListStringData>)val19).Count > 0);
					if (val23 != null)
					{
						isDone = frm.chrome.setLimit_Promise<T0, T9, T14, T6, T15, T3, T1>(val19);
						T2 val24 = (T2)ListAds.Join((IEnumerable<ListStringData>)val19, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val25 = isDone;
						if (val25 != null)
						{
							T4 enumerator6 = (T4)((List<adaccountsData>)val24).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator6))->MoveNext())
								{
									adaccountsData current6 = ((List<adaccountsData>.Enumerator*)(&enumerator6))->Current;
									T6 enumerator7 = (T6)((List<ListStringData>)val19).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator7))->MoveNext())
										{
											ListStringData current7 = ((List<ListStringData>.Enumerator*)(&enumerator7))->Current;
											T0 val26 = (T0)current6.id.Equals(current7.str1);
											if (val26 != null)
											{
												current6.message = current7.str4;
												T0 val27 = (T0)current6.message.Equals(frmMain.STATUS.Done.ToString());
												if (val27 != null)
												{
													current6.spend_cap = Limit;
												}
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator7))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator6))).Dispose();
							}
						}
						else
						{
							T4 enumerator8 = (T4)((List<adaccountsData>)val24).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator8))->MoveNext())
								{
									adaccountsData current8 = ((List<adaccountsData>.Enumerator*)(&enumerator8))->Current;
									current8.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator8))).Dispose();
							}
						}
						((List<ListStringData>)val19).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val20;
					val20 = (T3)(val6 + 1);
				}
			}
			T0 val28 = (T0)ChangeInfoAct;
			if (val28 != null)
			{
				T1 val29 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val30 = (T3)0;
				while (true)
				{
					T0 val31 = (T0)((nint)val30 < ListAds.Count);
					if (val31 == null)
					{
						break;
					}
					T0 val32 = (T0)(!isRunning);
					if (val32 != null)
					{
						return;
					}
					ListAds[(int)val30].message = STATUS.Processing.ToString();
					ListStringData listStringData5 = new ListStringData();
					listStringData5.str1 = ListAds[(int)val30].id;
					((List<ListStringData>)val29).Add(listStringData5);
					T0 val33 = (T0)((((List<ListStringData>)val29).Count >= intThread || (nint)val30 == ListAds.Count - 1) && ((List<ListStringData>)val29).Count > 0);
					if (val33 != null)
					{
						isDone = frm.chrome.changeInfoAct_Promise<T0, T9, T14, T6, T15, T3, T13, T1>(val29, (T9)BMID, (T9)TimeZone, (T9)Currency, (T9)Country, (T9)State, (T9)Address, (T9)Zip, (T9)City);
						T2 val34 = (T2)ListAds.Join((IEnumerable<ListStringData>)val29, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val35 = isDone;
						if (val35 != null)
						{
							T4 enumerator9 = (T4)((List<adaccountsData>)val34).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator9))->MoveNext())
								{
									adaccountsData current9 = ((List<adaccountsData>.Enumerator*)(&enumerator9))->Current;
									T6 enumerator10 = (T6)((List<ListStringData>)val29).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator10))->MoveNext())
										{
											ListStringData current10 = ((List<ListStringData>.Enumerator*)(&enumerator10))->Current;
											T0 val36 = (T0)current9.id.Equals(current10.str1);
											if (val36 != null)
											{
												current9.message = current10.str4;
												current9.business_country_code = current10.str5;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator10))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator9))).Dispose();
							}
						}
						else
						{
							T4 enumerator11 = (T4)((List<adaccountsData>)val34).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator11))->MoveNext())
								{
									adaccountsData current11 = ((List<adaccountsData>.Enumerator*)(&enumerator11))->Current;
									current11.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator11))).Dispose();
							}
						}
						((List<ListStringData>)val29).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val30;
					val30 = (T3)(val6 + 1);
				}
			}
			T0 val37 = (T0)AddCart;
			if (val37 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val38 = (T3)0;
				while (true)
				{
					T0 val39 = (T0)((nint)val38 < ListAds.Count);
					if (val39 == null)
					{
						break;
					}
					while (true)
					{
						T0 val40 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val40 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val41 = (T0)(!isRunning);
					if (val41 != null)
					{
						break;
					}
					T7 val42 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0052: Expected I4, but got O
						//IL_0068: Expected I4, but got O
						//IL_0073: Expected O, but got I4
						//IL_0088: Expected I4, but got O
						//IL_00b0: Expected I4, but got O
						//IL_00cc: Expected O, but got I4
						//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d5: Expected I4, but got Unknown
						T3 val418 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val418].message = STATUS.Processing.ToString();
						T0 val419 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.addCart<T0, T3, T9, T16, T15, T13>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val418].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val418].business_country_code, (T0)0);
						if (val419 != null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val418].message = STATUS.Done.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val418].message = STATUS.lỗi.ToString();
						}
						T3 val420 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val420 - 1;
					});
					((Thread)val42).Start((object)val38);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val38;
					val38 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val43 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val43 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val44 = (T0)AddCartPrimary;
			if (val44 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val45 = (T3)0;
				while (true)
				{
					T0 val46 = (T0)((nint)val45 < ListAds.Count);
					if (val46 == null)
					{
						break;
					}
					while (true)
					{
						T0 val47 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val47 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val48 = (T0)(!isRunning);
					if (val48 != null)
					{
						break;
					}
					T7 val49 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0052: Expected I4, but got O
						//IL_0068: Expected I4, but got O
						//IL_0073: Expected O, but got I4
						//IL_0088: Expected I4, but got O
						//IL_00b0: Expected I4, but got O
						//IL_00cc: Expected O, but got I4
						//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d5: Expected I4, but got Unknown
						T3 val415 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val415].message = STATUS.Processing.ToString();
						T0 val416 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.addCart<T0, T3, T9, T16, T15, T13>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val415].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val415].business_country_code, (T0)1);
						if (val416 != null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val415].message = STATUS.Done.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val415].message = STATUS.lỗi.ToString();
						}
						T3 val417 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val417 - 1;
					});
					((Thread)val49).Start((object)val45);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val45;
					val45 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val50 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val50 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val51 = (T0)AddCardItem;
			if (val51 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
			}
			T0 val52 = (T0)AddCardItem_Primary;
			if (val52 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
			}
			T0 val53 = (T0)AddCartMFacebook2;
			if (val53 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1);
			}
			T0 val54 = (T0)AddCardItem_M_Facebook;
			if (val54 != null)
			{
				T9 fb_dtsg = frm.chrome.executeScript<T9, T17, T3, T0, T18>((T9)"var fb_dtsg = require('DTSGInitialData').token; return fb_dtsg;");
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].fb_dtsg = (string)fb_dtsg;
				frm.chrome.goUrl<T3, T0, T19, T20, T13, T9>((T9)"https://m.facebook.com/settings/framework/msite/payments/?entry_point=bookmark&ref=wizard&_rdr");
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
				frm.chrome.goUrl<T3, T0, T19, T20, T13, T9>((T9)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			T0 val55 = (T0)AddCardByPage;
			if (val55 != null)
			{
				T3 val56 = (T3)0;
				while (true)
				{
					T0 val57 = (T0)((nint)val56 < ListAds.Count);
					if (val57 == null)
					{
						break;
					}
					ListAds[(int)val56].message = STATUS.Ready.ToString();
					T3 val6 = val56;
					val56 = (T3)(val6 + 1);
				}
				T10 val58 = (T10)Activator.CreateInstance(typeof(T10));
				T11 val59 = (T11)new StringReader(Pro5List);
				try
				{
					while (true)
					{
						T9 val60;
						T0 val61 = (T0)((val60 = (T9)((TextReader)val59).ReadLine()) != null);
						if (val61 == null)
						{
							break;
						}
						T0 val62 = (T0)(!string.IsNullOrWhiteSpace((string)val60));
						if (val62 != null)
						{
							T0 val63 = (T0)((string)val60).Contains("/");
							if (val63 != null)
							{
								val60 = ((IEnumerable<T9>)(object)((string)val60).Split((char[])(object)new T16[1] { (T16)47 })).Last();
							}
							((List<string>)val58).Add(((string)val60).Trim());
						}
					}
				}
				finally
				{
					if (val59 != null)
					{
						((IDisposable)val59).Dispose();
					}
				}
				T9 fb_dtsg2 = frm.chrome.executeScript<T9, T17, T3, T0, T18>((T9)"var fb_dtsg = require('DTSGInitialData').token; return fb_dtsg;");
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].fb_dtsg = (string)fb_dtsg2;
				frm.chrome.goUrl<T3, T0, T19, T20, T13, T9>((T9)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
				T3 val64 = (T3)0;
				T12 enumerator12 = (T12)((List<string>)val58).GetEnumerator();
				try
				{
					while (((List<string>.Enumerator*)(&enumerator12))->MoveNext())
					{
						T9 current12 = (T9)((List<string>.Enumerator*)(&enumerator12))->Current;
						T0 val65 = (T0)(!isRunning);
						if (val65 != null)
						{
							break;
						}
						val64 = (T3)0;
						T9 resouce = (T9)ResouceControl.getResouce("chuyen_sang_page_pro5");
						resouce = (T9)((string)resouce).Replace("strPro5_Id", (string)current12);
						frm.chrome.executeScript<T9, T17, T3, T0, T18>(resouce);
						frm.chrome.goUrl<T3, T0, T19, T20, T13, T9>((T9)ResouceControl.getResouce("RESOUCE_HOME_PAGE"));
						T3 val66 = (T3)0;
						while (true)
						{
							T0 val67 = (T0)((nint)val66 < ListAds.Count);
							if (val67 == null)
							{
								break;
							}
							T0 val68 = (T0)ListAds[(int)val66].message.Equals(STATUS.Ready.ToString());
							T3 val6;
							if (val68 != null)
							{
								ListAds[(int)val66].message = STATUS.Processing.ToString();
								val6 = val64;
								val64 = (T3)(val6 + 1);
								T0 val69 = (T0)((nint)val64 >= AddActOnPage);
								if (val69 != null)
								{
									break;
								}
							}
							val6 = val66;
							val66 = (T3)(val6 + 1);
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<string>.Enumerator*)(&enumerator12))).Dispose();
				}
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
				frm.chrome.goUrl<T3, T0, T19, T20, T13, T9>((T9)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
			}
			T0 val70 = (T0)AddBoostpost;
			if (val70 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
			}
			T0 val71 = (T0)AddSuite;
			if (val71 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0);
			}
			T0 val72 = (T0)AddCardLink1;
			if (val72 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0);
			}
			T0 val73 = (T0)AddCardAPI;
			if (val73 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0);
			}
			T0 val74 = (T0)AddCardRequest;
			if (val74 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)1, (T0)0);
			}
			T0 val75 = (T0)AddCodeCard;
			if (val75 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
			}
			T0 val76 = (T0)AddCardLink667;
			if (val76 != null)
			{
				addCard<T1, T3, T0, List<CreditCardEntity>, T9, List<BinGenClass>.Enumerator, T2, T4, T6, T13, T16, T14, T15>((T0)0, (T0)0, (T0)1, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0, (T0)0);
			}
			while (true)
			{
				T0 val77 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val77 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val78 = (T0)RemoveCard;
			if (val78 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val79 = (T3)0;
				while (true)
				{
					T0 val80 = (T0)((nint)val79 < ListAds.Count);
					if (val80 == null)
					{
						break;
					}
					while (true)
					{
						T0 val81 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val81 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val82 = (T0)(!isRunning);
					if (val82 != null)
					{
						break;
					}
					T7 val83 = (T7)new Thread((ParameterizedThreadStart)CS_0024_003C_003E8__locals0._003CthrStart_003Eb__14<T3, T0, T18, T15, T9, List<billing_payment_methods>.Enumerator>);
					((Thread)val83).Start((object)val79);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val79;
					val79 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val84 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val84 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val85 = (T0)RemoveCardByName;
			if (val85 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val86 = (T3)0;
				while (true)
				{
					T0 val87 = (T0)((nint)val86 < ListAds.Count);
					if (val87 == null)
					{
						break;
					}
					while (true)
					{
						T0 val88 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val88 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val89 = (T0)(!isRunning);
					if (val89 != null)
					{
						break;
					}
					T7 val90 = (T7)new Thread((ParameterizedThreadStart)CS_0024_003C_003E8__locals0._003CthrStart_003Eb__15<T3, T0, T18, T15, T9, List<billing_payment_methods>.Enumerator>);
					((Thread)val90).Start((object)val86);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val86;
					val86 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val91 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val91 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val92 = (T0)KichNo;
			if (val92 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val93 = (T3)0;
				while (true)
				{
					T0 val94 = (T0)((nint)val93 < ListAds.Count);
					if (val94 == null)
					{
						break;
					}
					while (true)
					{
						T0 val95 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val95 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val96 = (T0)(!isRunning);
					if (val96 != null)
					{
						break;
					}
					T7 val97 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0052: Expected I4, but got O
						//IL_0076: Expected I4, but got O
						//IL_009e: Expected I4, but got O
						//IL_00ba: Expected O, but got I4
						//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
						//IL_00c3: Expected I4, but got Unknown
						T3 val412 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val412].message = STATUS.Processing.ToString();
						T0 val413 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.kichNo<T0, T15, T9, T21, T13>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val412].id, (T9)"");
						if (val413 == null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val412].message = STATUS.lỗi.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val412].message = STATUS.Done.ToString();
						}
						T3 val414 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val414 - 1;
					});
					((Thread)val97).Start((object)val93);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val93;
					val93 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val98 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val98 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val99 = (T0)PayNow;
			if (val99 != null)
			{
				T1 val100 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val101 = (T3)0;
				while (true)
				{
					T0 val102 = (T0)((nint)val101 < ListAds.Count);
					if (val102 == null)
					{
						break;
					}
					T0 val103 = (T0)(!isRunning);
					if (val103 != null)
					{
						return;
					}
					ListAds[(int)val101].message = STATUS.Processing.ToString();
					ListStringData listStringData6 = new ListStringData();
					listStringData6.str1 = ListAds[(int)val101].id;
					listStringData6.str2 = "";
					listStringData6.str3 = "";
					((List<ListStringData>)val100).Add(listStringData6);
					T0 val104 = (T0)((((List<ListStringData>)val100).Count >= intThread || (nint)val101 == ListAds.Count - 1) && ((List<ListStringData>)val100).Count > 0);
					if (val104 != null)
					{
						isDone = frm.chrome.kichNo_Promise<T0, T9, T6, T21, T15, T13, T3, T14, T1>(val100);
						T2 val105 = (T2)ListAds.Join((IEnumerable<ListStringData>)val100, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val106 = isDone;
						if (val106 != null)
						{
							T4 enumerator13 = (T4)((List<adaccountsData>)val105).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator13))->MoveNext())
								{
									adaccountsData current13 = ((List<adaccountsData>.Enumerator*)(&enumerator13))->Current;
									T6 enumerator14 = (T6)((List<ListStringData>)val100).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator14))->MoveNext())
										{
											ListStringData current14 = ((List<ListStringData>.Enumerator*)(&enumerator14))->Current;
											T0 val107 = (T0)current13.id.Equals(current14.str1);
											if (val107 != null)
											{
												current13.message = current14.str3;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator14))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator13))).Dispose();
							}
						}
						else
						{
							T4 enumerator15 = (T4)((List<adaccountsData>)val105).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator15))->MoveNext())
								{
									adaccountsData current15 = ((List<adaccountsData>.Enumerator*)(&enumerator15))->Current;
									current15.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator15))).Dispose();
							}
						}
						((List<ListStringData>)val100).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val101;
					val101 = (T3)(val6 + 1);
				}
			}
			T0 val108 = (T0)PayBalance;
			if (val108 != null)
			{
				T1 val109 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val110 = (T3)0;
				while (true)
				{
					T0 val111 = (T0)((nint)val110 < ListAds.Count);
					if (val111 == null)
					{
						break;
					}
					T0 val112 = (T0)(!isRunning);
					if (val112 != null)
					{
						return;
					}
					ListAds[(int)val110].message = STATUS.Processing.ToString();
					ListStringData listStringData7 = new ListStringData();
					listStringData7.str1 = ListAds[(int)val110].id;
					listStringData7.str2 = strPayBalance;
					listStringData7.str3 = "";
					((List<ListStringData>)val109).Add(listStringData7);
					T0 val113 = (T0)((((List<ListStringData>)val109).Count >= intThread || (nint)val110 == ListAds.Count - 1) && ((List<ListStringData>)val109).Count > 0);
					if (val113 != null)
					{
						isDone = frm.chrome.kichNo_Promise<T0, T9, T6, T21, T15, T13, T3, T14, T1>(val109);
						T2 val114 = (T2)ListAds.Join((IEnumerable<ListStringData>)val109, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val115 = isDone;
						if (val115 != null)
						{
							T4 enumerator16 = (T4)((List<adaccountsData>)val114).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator16))->MoveNext())
								{
									adaccountsData current16 = ((List<adaccountsData>.Enumerator*)(&enumerator16))->Current;
									T6 enumerator17 = (T6)((List<ListStringData>)val109).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator17))->MoveNext())
										{
											ListStringData current17 = ((List<ListStringData>.Enumerator*)(&enumerator17))->Current;
											T0 val116 = (T0)current16.id.Equals(current17.str1);
											if (val116 != null)
											{
												current16.message = current17.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator17))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator16))).Dispose();
							}
						}
						else
						{
							T4 enumerator18 = (T4)((List<adaccountsData>)val114).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator18))->MoveNext())
								{
									adaccountsData current18 = ((List<adaccountsData>.Enumerator*)(&enumerator18))->Current;
									current18.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator18))).Dispose();
							}
						}
						((List<ListStringData>)val109).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val110;
					val110 = (T3)(val6 + 1);
				}
			}
			T0 val117 = (T0)ResetLimit;
			if (val117 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val118 = (T3)0;
				while (true)
				{
					T0 val119 = (T0)((nint)val118 < ListAds.Count);
					if (val119 == null)
					{
						break;
					}
					while (true)
					{
						T0 val120 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val120 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val121 = (T0)(!isRunning);
					if (val121 != null)
					{
						break;
					}
					T7 val122 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0052: Expected I4, but got O
						//IL_0071: Expected I4, but got O
						//IL_0098: Expected I4, but got O
						//IL_00b4: Expected O, but got I4
						//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
						//IL_00bd: Expected I4, but got Unknown
						T3 val409 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val409].message = STATUS.Processing.ToString();
						T0 val410 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.resetLimit<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val409].id);
						if (val410 != null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val409].message = STATUS.Reseted.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val409].message = STATUS.lỗi.ToString();
						}
						T3 val411 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val411 - 1;
					});
					((Thread)val122).Start((object)val118);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val118;
					val118 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val123 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val123 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val124 = (T0)ImportCamp;
			if (val124 != null)
			{
				T1 val125 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val126 = (T3)0;
				while (true)
				{
					T0 val127 = (T0)((nint)val126 < ListAds.Count);
					if (val127 == null)
					{
						break;
					}
					T0 val128 = (T0)(!isRunning);
					if (val128 != null)
					{
						return;
					}
					ListAds[(int)val126].message = STATUS.Processing.ToString();
					ListStringData listStringData8 = new ListStringData();
					listStringData8.str1 = ListAds[(int)val126].id;
					listStringData8.str2 = null;
					listStringData8.str3 = textCamp;
					((List<ListStringData>)val125).Add(listStringData8);
					T0 val129 = (T0)((((List<ListStringData>)val125).Count >= intThread || (nint)val126 == ListAds.Count - 1) && ((List<ListStringData>)val125).Count > 0);
					if (val129 != null)
					{
						isDone = frm.chrome.ImportCamp_Promise<T0, T9, T14, T6, T15, T3, T13, T1>(val125);
						T2 val130 = (T2)ListAds.Join((IEnumerable<ListStringData>)val125, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val131 = isDone;
						if (val131 != null)
						{
							T4 enumerator19 = (T4)((List<adaccountsData>)val130).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator19))->MoveNext())
								{
									adaccountsData current19 = ((List<adaccountsData>.Enumerator*)(&enumerator19))->Current;
									T6 enumerator20 = (T6)((List<ListStringData>)val125).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator20))->MoveNext())
										{
											ListStringData current20 = ((List<ListStringData>.Enumerator*)(&enumerator20))->Current;
											T0 val132 = (T0)current19.id.Equals(current20.str1);
											if (val132 != null)
											{
												current19.message = current20.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator20))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator19))).Dispose();
							}
						}
						else
						{
							T4 enumerator21 = (T4)((List<adaccountsData>)val130).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator21))->MoveNext())
								{
									adaccountsData current21 = ((List<adaccountsData>.Enumerator*)(&enumerator21))->Current;
									current21.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator21))).Dispose();
							}
						}
						((List<ListStringData>)val125).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val126;
					val126 = (T3)(val6 + 1);
				}
			}
			T0 val133 = (T0)boolCreatePE;
			if (val133 != null)
			{
				T3 val134 = (T3)0;
				T3 val135 = (T3)0;
				while (true)
				{
					T1 val136 = (T1)Activator.CreateInstance(typeof(T1));
					T3 val137 = (T3)0;
					T3 val6;
					while (true)
					{
						T0 val138 = (T0)((nint)val137 < ListAds.Count);
						if (val138 == null)
						{
							break;
						}
						T0 val139 = (T0)(!isRunning);
						if (val139 != null)
						{
							return;
						}
						T0 val140 = (T0)(ListAds[(int)val137].message == null || !ListAds[(int)val137].message.Equals("1-1-1"));
						if (val140 != null)
						{
							ListAds[(int)val137].message = STATUS.Processing.ToString();
							ListStringData listStringData9 = new ListStringData();
							listStringData9.str1 = ListAds[(int)val137].id;
							listStringData9.str2 = "";
							listStringData9.str3 = "";
							listStringData9.str4 = "";
							listStringData9.str5 = "";
							listStringData9.str6 = "";
							((List<ListStringData>)val136).Add(listStringData9);
							T0 val141 = (T0)((((List<ListStringData>)val136).Count >= intThread || (nint)val137 == ListAds.Count - 1 || ((nint)val134 > 0 && ((List<ListStringData>)val136).Count >= (nint)val135)) && ((List<ListStringData>)val136).Count > 0);
							if (val141 != null)
							{
								isDone = frm.chrome.CreateCampPE_Promise<T0, T9, T14, T6, T5, T15, T3, T13, T1, T16>(val136, (T9)textCamp);
								T2 val142 = (T2)ListAds.Join((IEnumerable<ListStringData>)val136, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
								T0 val143 = isDone;
								if (val143 != null)
								{
									T4 enumerator22 = (T4)((List<adaccountsData>)val142).GetEnumerator();
									try
									{
										while (((List<adaccountsData>.Enumerator*)(&enumerator22))->MoveNext())
										{
											adaccountsData current22 = ((List<adaccountsData>.Enumerator*)(&enumerator22))->Current;
											T6 enumerator23 = (T6)((List<ListStringData>)val136).GetEnumerator();
											try
											{
												while (((List<ListStringData>.Enumerator*)(&enumerator23))->MoveNext())
												{
													ListStringData current23 = ((List<ListStringData>.Enumerator*)(&enumerator23))->Current;
													T0 val144 = (T0)current22.id.Equals(current23.str1);
													if (val144 != null)
													{
														current22.message = current23.str4;
													}
												}
											}
											finally
											{
												((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator23))).Dispose();
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator22))).Dispose();
									}
								}
								else
								{
									T4 enumerator24 = (T4)((List<adaccountsData>)val142).GetEnumerator();
									try
									{
										while (((List<adaccountsData>.Enumerator*)(&enumerator24))->MoveNext())
										{
											adaccountsData current24 = ((List<adaccountsData>.Enumerator*)(&enumerator24))->Current;
											current24.message = frmMain.STATUS.lỗi.ToString();
										}
									}
									finally
									{
										((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator24))).Dispose();
									}
								}
								((List<ListStringData>)val136).Clear();
								Thread.Sleep(intDelay);
							}
						}
						val6 = val137;
						val137 = (T3)(val6 + 1);
					}
					val135 = (T3)0;
					T3 val145 = (T3)0;
					while (true)
					{
						T0 val146 = (T0)((nint)val145 < ListAds.Count);
						if (val146 == null)
						{
							break;
						}
						T0 val147 = (T0)(ListAds[(int)val145].message == null || !ListAds[(int)val145].message.Equals("1-1-1"));
						if (val147 != null)
						{
							val6 = val135;
							val135 = (T3)(val6 + 1);
						}
						val6 = val145;
						val145 = (T3)(val6 + 1);
					}
					T0 val148 = (T0)((nint)val134 < 3 && (nint)val135 > 0);
					if (val148 == null)
					{
						break;
					}
					Thread.Sleep(5000);
					val6 = val134;
					val134 = (T3)(val6 + 1);
				}
			}
			T0 val149 = (T0)boolBoostPost;
			if (val149 != null)
			{
				T1 val150 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val151 = (T3)0;
				while (true)
				{
					T0 val152 = (T0)((nint)val151 < ListAds.Count);
					if (val152 == null)
					{
						break;
					}
					T0 val153 = (T0)(!isRunning);
					if (val153 != null)
					{
						return;
					}
					ListAds[(int)val151].message = STATUS.Processing.ToString();
					ListStringData listStringData10 = new ListStringData();
					listStringData10.str1 = ListAds[(int)val151].id;
					listStringData10.str2 = null;
					listStringData10.str3 = textCamp;
					((List<ListStringData>)val150).Add(listStringData10);
					T0 val154 = (T0)((((List<ListStringData>)val150).Count >= intThread || (nint)val151 == ListAds.Count - 1) && ((List<ListStringData>)val150).Count > 0);
					if (val154 != null)
					{
						isDone = frm.chrome.CampBoostpost_Promise<T0, T9, T14, T6, T15, T22, T3, T13, T1>(val150, (T9)textCamp);
						T2 val155 = (T2)ListAds.Join((IEnumerable<ListStringData>)val150, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val156 = isDone;
						if (val156 != null)
						{
							T4 enumerator25 = (T4)((List<adaccountsData>)val155).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator25))->MoveNext())
								{
									adaccountsData current25 = ((List<adaccountsData>.Enumerator*)(&enumerator25))->Current;
									T6 enumerator26 = (T6)((List<ListStringData>)val150).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator26))->MoveNext())
										{
											ListStringData current26 = ((List<ListStringData>.Enumerator*)(&enumerator26))->Current;
											T0 val157 = (T0)current25.id.Equals(current26.str1);
											if (val157 != null)
											{
												current25.message = current26.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator26))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator25))).Dispose();
							}
						}
						else
						{
							T4 enumerator27 = (T4)((List<adaccountsData>)val155).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator27))->MoveNext())
								{
									adaccountsData current27 = ((List<adaccountsData>.Enumerator*)(&enumerator27))->Current;
									current27.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator27))).Dispose();
							}
						}
						((List<ListStringData>)val150).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val151;
					val151 = (T3)(val6 + 1);
				}
			}
			T0 val158 = (T0)boolCampSuite;
			if (val158 != null)
			{
				T3 val159 = (T3)0;
				T1 val160 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val161 = (T3)0;
				while (true)
				{
					T0 val162 = (T0)((nint)val161 < ListAds.Count);
					if (val162 == null)
					{
						break;
					}
					T0 val163 = (T0)(!isRunning);
					if (val163 != null)
					{
						return;
					}
					ListAds[(int)val161].message = STATUS.Processing.ToString();
					ListStringData listStringData11 = new ListStringData();
					listStringData11.str1 = ListAds[(int)val161].id;
					listStringData11.str2 = null;
					listStringData11.str3 = textCamp;
					((List<ListStringData>)val160).Add(listStringData11);
					T0 val164 = (T0)((((List<ListStringData>)val160).Count >= intThread || (nint)val161 == ListAds.Count - 1) && ((List<ListStringData>)val160).Count > 0);
					T3 val6;
					if (val164 != null)
					{
						val6 = val159;
						val159 = (T3)(val6 + 1);
						isDone = frm.chrome.CampSuite_Promise<T0, T9, T14, T6, T15, T22, T3, T13, T1>(val160, (T9)textCamp);
						T2 val165 = (T2)ListAds.Join((IEnumerable<ListStringData>)val160, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val166 = isDone;
						if (val166 != null)
						{
							T4 enumerator28 = (T4)((List<adaccountsData>)val165).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator28))->MoveNext())
								{
									adaccountsData current28 = ((List<adaccountsData>.Enumerator*)(&enumerator28))->Current;
									T6 enumerator29 = (T6)((List<ListStringData>)val160).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator29))->MoveNext())
										{
											ListStringData current29 = ((List<ListStringData>.Enumerator*)(&enumerator29))->Current;
											T0 val167 = (T0)current28.id.Equals(current29.str1);
											if (val167 != null)
											{
												current28.message = current29.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator29))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator28))).Dispose();
							}
						}
						else
						{
							T4 enumerator30 = (T4)((List<adaccountsData>)val165).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator30))->MoveNext())
								{
									adaccountsData current30 = ((List<adaccountsData>.Enumerator*)(&enumerator30))->Current;
									current30.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator30))).Dispose();
							}
						}
						((List<ListStringData>)val160).Clear();
						Thread.Sleep(intDelay);
					}
					T0 val168 = (T0)(LifeCycle != 0 && (nint)val159 >= LifeCycle);
					if (val168 != null)
					{
						val159 = (T3)0;
						Thread.Sleep(DelayLifeCycle * 1000);
					}
					val6 = val161;
					val161 = (T3)(val6 + 1);
				}
			}
			T0 val169 = (T0)(PublishAds || PublishCamp || PublishGroup);
			if (val169 != null)
			{
				T3 val170 = (T3)0;
				getAddraft_Promise<T1, T3, T0, T2, T4, T6, T9, T14, T15, T13>();
				T1 val171 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val172 = (T3)0;
				while (true)
				{
					T0 val173 = (T0)((nint)val172 < ListAds.Count);
					if (val173 == null)
					{
						break;
					}
					T0 val174 = (T0)(!isRunning);
					if (val174 != null)
					{
						return;
					}
					T0 val175 = (T0)(ListAds[(int)val172].addraft_fragments != null && ListAds[(int)val172].addraft_fragments.data != null && ListAds[(int)val172].addraft_fragments.data.Count > 0 && ListAds[(int)val172].addraft_fragments.data.First().addraft_fragments != null && ListAds[(int)val172].addraft_fragments.data.First().addraft_fragments.data != null && ListAds[(int)val172].addraft_fragments.data.First().addraft_fragments.data.Count > 0);
					if (val175 != null)
					{
						ListStringData listStringData12 = new ListStringData();
						listStringData12.str1 = ListAds[(int)val172].id;
						listStringData12.obj1 = ListAds[(int)val172].addraft_fragments;
						((List<ListStringData>)val171).Add(listStringData12);
						ListAds[(int)val172].message = frmMain.STATUS.Processing.ToString();
					}
					else
					{
						ListAds[(int)val172].message = frmMain.STATUS.lỗi.ToString();
					}
					T0 val176 = (T0)((((List<ListStringData>)val171).Count >= intThread || (nint)val172 == ListAds.Count - 1) && ((List<ListStringData>)val171).Count > 0);
					T3 val6;
					if (val176 != null)
					{
						val6 = val170;
						val170 = (T3)(val6 + 1);
						isDone = frm.chrome.publishCamps_Promise<T0, T6, T9, T14, T5, T15, T23, T24, T18, T13, T1>(val171, (T0)PublishCamp, (T0)PublishGroup, (T0)PublishAds);
						T2 val177 = (T2)ListAds.Join((IEnumerable<ListStringData>)val171, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T4 enumerator31 = (T4)((List<adaccountsData>)val177).GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator31))->MoveNext())
							{
								adaccountsData current31 = ((List<adaccountsData>.Enumerator*)(&enumerator31))->Current;
								T6 enumerator32 = (T6)((List<ListStringData>)val171).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator32))->MoveNext())
									{
										ListStringData current32 = ((List<ListStringData>.Enumerator*)(&enumerator32))->Current;
										T0 val178 = (T0)current31.id.Equals(current32.str1);
										if (val178 != null)
										{
											current31.message = current32.str2;
											break;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator32))).Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator31))).Dispose();
						}
						((List<ListStringData>)val171).Clear();
						Thread.Sleep(intDelay);
					}
					T0 val179 = (T0)(LifeCycle != 0 && (nint)val170 >= LifeCycle);
					if (val179 != null)
					{
						val170 = (T3)0;
						Thread.Sleep(DelayLifeCycle * 1000);
					}
					val6 = val172;
					val172 = (T3)(val6 + 1);
				}
			}
			T0 val180 = (T0)RemoveActInBM;
			if (val180 != null)
			{
				T1 val181 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val182 = (T3)0;
				while (true)
				{
					T0 val183 = (T0)((nint)val182 < ListAds.Count);
					if (val183 == null)
					{
						break;
					}
					T0 val184 = (T0)(!isRunning);
					if (val184 != null)
					{
						return;
					}
					ListAds[(int)val182].message = STATUS.Processing.ToString();
					ListStringData listStringData13 = new ListStringData();
					listStringData13.str1 = ListAds[(int)val182].id;
					((List<ListStringData>)val181).Add(listStringData13);
					T0 val185 = (T0)((((List<ListStringData>)val181).Count >= intThread || (nint)val182 == ListAds.Count - 1) && ((List<ListStringData>)val181).Count > 0);
					if (val185 != null)
					{
						isDone = frm.chrome.remove_act_in_bm_Promise<T0, T9, T14, T6, T15, T3, T13, T1>((T9)BMID, val181);
						T2 val186 = (T2)ListAds.Join((IEnumerable<ListStringData>)val181, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val187 = isDone;
						if (val187 != null)
						{
							T4 enumerator33 = (T4)((List<adaccountsData>)val186).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator33))->MoveNext())
								{
									adaccountsData current33 = ((List<adaccountsData>.Enumerator*)(&enumerator33))->Current;
									T6 enumerator34 = (T6)((List<ListStringData>)val181).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator34))->MoveNext())
										{
											ListStringData current34 = ((List<ListStringData>.Enumerator*)(&enumerator34))->Current;
											T0 val188 = (T0)current33.id.Equals(current34.str1);
											if (val188 != null)
											{
												current33.message = current34.str2;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator34))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator33))).Dispose();
							}
						}
						else
						{
							T4 enumerator35 = (T4)((List<adaccountsData>)val186).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator35))->MoveNext())
								{
									adaccountsData current35 = ((List<adaccountsData>.Enumerator*)(&enumerator35))->Current;
									current35.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator35))).Dispose();
							}
						}
						((List<ListStringData>)val181).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val182;
					val182 = (T3)(val6 + 1);
				}
			}
			T0 val189 = (T0)CampReview;
			if (val189 != null)
			{
				_003C_003Ec__DisplayClass76_1 _003C_003Ec__DisplayClass76_ = new _003C_003Ec__DisplayClass76_1();
				_003C_003Ec__DisplayClass76_.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				_003C_003Ec__DisplayClass76_.idAds = "";
				_003C_003Ec__DisplayClass76_.CS_0024_003C_003E8__locals1.countThread = 0;
				T3 val190 = (T3)0;
				while (true)
				{
					T0 val191 = (T0)((nint)val190 < ListAds.Count);
					if (val191 == null)
					{
						break;
					}
					while (true)
					{
						T0 val192 = (T0)(isRunning && _003C_003Ec__DisplayClass76_.CS_0024_003C_003E8__locals1.countThread >= intThread);
						if (val192 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val193 = (T0)(!isRunning);
					if (val193 != null)
					{
						break;
					}
					T7 val194 = (T7)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass76_._003CthrStart_003Eb__42<T3, T0, List<campaignsData>.Enumerator, List<adsets_data>.Enumerator, List<ads_data>.Enumerator, T18, T15, T9, T19, IEnumerator, Match, T16, IDisposable, T13, T20, T17>);
					((Thread)val194).Start((object)val190);
					T3 val6 = (T3)_003C_003Ec__DisplayClass76_.CS_0024_003C_003E8__locals1.countThread;
					_003C_003Ec__DisplayClass76_.CS_0024_003C_003E8__locals1.countThread = val6 + 1;
					val6 = val190;
					val190 = (T3)(val6 + 1);
				}
				while (true)
				{
					T0 val195 = (T0)(isRunning && _003C_003Ec__DisplayClass76_.CS_0024_003C_003E8__locals1.countThread > 0);
					if (val195 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val196 = (T0)(_003C_003Ec__DisplayClass76_.idAds.Length > 0);
				if (val196 != null)
				{
					_003C_003Ec__DisplayClass76_.idAds = _003C_003Ec__DisplayClass76_.idAds.Substring(0, _003C_003Ec__DisplayClass76_.idAds.Length - 1);
					T0 val197 = (T0)(frm.chrome.supportReviewCamps<T0, T9, T15, T17, T3, T18>((T9)_003C_003Ec__DisplayClass76_.idAds) == null);
					if (val197 != null)
					{
						isDone = (T0)0;
					}
				}
			}
			while (true)
			{
				T0 val198 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val198 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val199 = (T0)boolChangeNameAct;
			if (val199 != null)
			{
				T1 val200 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val201 = (T3)0;
				while (true)
				{
					T0 val202 = (T0)((nint)val201 < ListAds.Count);
					if (val202 == null)
					{
						break;
					}
					T0 val203 = (T0)(!isRunning);
					if (val203 != null)
					{
						return;
					}
					ListAds[(int)val201].message = STATUS.Processing.ToString();
					ListStringData listStringData14 = new ListStringData();
					listStringData14.str1 = ListAds[(int)val201].id;
					listStringData14.str2 = $"{strChangeNameAct} {(T3)(val201 + 1)}";
					((List<ListStringData>)val200).Add(listStringData14);
					T0 val204 = (T0)((((List<ListStringData>)val200).Count >= intThread || (nint)val201 == ListAds.Count - 1) && ((List<ListStringData>)val200).Count > 0);
					if (val204 != null)
					{
						isDone = frm.chrome.changeNameAct_Promise<T0, T9, T14, T6, T15, T3, T13, T1>(val200);
						T2 val205 = (T2)ListAds.Join((IEnumerable<ListStringData>)val200, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val206 = isDone;
						if (val206 != null)
						{
							T4 enumerator36 = (T4)((List<adaccountsData>)val205).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator36))->MoveNext())
								{
									adaccountsData current36 = ((List<adaccountsData>.Enumerator*)(&enumerator36))->Current;
									T6 enumerator37 = (T6)((List<ListStringData>)val200).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator37))->MoveNext())
										{
											ListStringData current37 = ((List<ListStringData>.Enumerator*)(&enumerator37))->Current;
											T0 val207 = (T0)current36.id.Equals(current37.str1);
											if (val207 != null)
											{
												current36.message = current37.str3;
												T0 val208 = (T0)current36.message.Equals(frmMain.STATUS.Done.ToString());
												if (val208 != null)
												{
													current36.name = current37.str2;
												}
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator37))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator36))).Dispose();
							}
						}
						else
						{
							T4 enumerator38 = (T4)((List<adaccountsData>)val205).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator38))->MoveNext())
								{
									adaccountsData current38 = ((List<adaccountsData>.Enumerator*)(&enumerator38))->Current;
									current38.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator38))).Dispose();
							}
						}
						((List<ListStringData>)val200).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val201;
					val201 = (T3)(val6 + 1);
				}
			}
			T0 val209 = (T0)ShareTK;
			if (val209 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val210 = (T3)0;
				while (true)
				{
					T0 val211 = (T0)((nint)val210 < ListAds.Count);
					if (val211 == null)
					{
						break;
					}
					while (true)
					{
						T0 val212 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val212 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val213 = (T0)(!isRunning);
					if (val213 != null)
					{
						break;
					}
					T7 val214 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0052: Expected I4, but got O
						//IL_007c: Expected I4, but got O
						//IL_00a4: Expected I4, but got O
						//IL_00c0: Expected O, but got I4
						//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
						//IL_00c9: Expected I4, but got Unknown
						T3 val406 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val406].message = STATUS.Processing.ToString();
						T0 val407 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.shareTK<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val406].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.UID_Share_Tk);
						if (val407 != null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val406].message = STATUS.Done.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val406].message = STATUS.lỗi.ToString();
						}
						T3 val408 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val408 - 1;
					});
					((Thread)val214).Start((object)val210);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val210;
					val210 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val215 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val215 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val216 = (T0)TryAgainHoldMoney;
			if (val216 != null)
			{
				T1 val217 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val218 = (T3)0;
				while (true)
				{
					T0 val219 = (T0)((nint)val218 < ListAds.Count);
					if (val219 == null)
					{
						break;
					}
					T0 val220 = (T0)(!isRunning);
					if (val220 != null)
					{
						return;
					}
					ListAds[(int)val218].message = STATUS.Processing.ToString();
					ListStringData listStringData15 = new ListStringData();
					listStringData15.str1 = ListAds[(int)val218].id;
					((List<ListStringData>)val217).Add(listStringData15);
					T0 val221 = (T0)((((List<ListStringData>)val217).Count >= intThread || (nint)val218 == ListAds.Count - 1) && ((List<ListStringData>)val217).Count > 0);
					if (val221 != null)
					{
						isDone = frm.chrome.thu_lai_tam_giu_tien_Promise<T0, T9, T14, T6, T15, T3, T13, T1>(val217);
						T2 val222 = (T2)ListAds.Join((IEnumerable<ListStringData>)val217, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val223 = isDone;
						if (val223 != null)
						{
							T4 enumerator39 = (T4)((List<adaccountsData>)val222).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator39))->MoveNext())
								{
									adaccountsData current39 = ((List<adaccountsData>.Enumerator*)(&enumerator39))->Current;
									T6 enumerator40 = (T6)((List<ListStringData>)val217).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator40))->MoveNext())
										{
											ListStringData current40 = ((List<ListStringData>.Enumerator*)(&enumerator40))->Current;
											T0 val224 = (T0)current39.id.Equals(current40.str1);
											if (val224 != null)
											{
												current39.message = current40.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator40))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator39))).Dispose();
							}
						}
						else
						{
							T4 enumerator41 = (T4)((List<adaccountsData>)val222).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator41))->MoveNext())
								{
									adaccountsData current41 = ((List<adaccountsData>.Enumerator*)(&enumerator41))->Current;
									current41.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator41))).Dispose();
							}
						}
						((List<ListStringData>)val217).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val218;
					val218 = (T3)(val6 + 1);
				}
			}
			T0 val225 = (T0)RemveLimitInCamp;
			if (val225 != null)
			{
				T1 val226 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val227 = (T3)0;
				while (true)
				{
					T0 val228 = (T0)((nint)val227 < ListAds.Count);
					if (val228 == null)
					{
						break;
					}
					T0 val229 = (T0)(!isRunning);
					if (val229 != null)
					{
						return;
					}
					ListAds[(int)val227].message = STATUS.Processing.ToString();
					ListStringData listStringData16 = new ListStringData();
					listStringData16.str1 = ListAds[(int)val227].id;
					((List<ListStringData>)val226).Add(listStringData16);
					T0 val230 = (T0)((((List<ListStringData>)val226).Count >= intThread || (nint)val227 == ListAds.Count - 1) && ((List<ListStringData>)val226).Count > 0);
					if (val230 != null)
					{
						isDone = frm.chrome.removeLimitInCamp_Promise<T0, T9, T14, T6, T15, T3, T13, T1>(val226);
						T2 val231 = (T2)ListAds.Join((IEnumerable<ListStringData>)val226, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val232 = isDone;
						if (val232 != null)
						{
							T4 enumerator42 = (T4)((List<adaccountsData>)val231).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator42))->MoveNext())
								{
									adaccountsData current42 = ((List<adaccountsData>.Enumerator*)(&enumerator42))->Current;
									T6 enumerator43 = (T6)((List<ListStringData>)val226).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator43))->MoveNext())
										{
											ListStringData current43 = ((List<ListStringData>.Enumerator*)(&enumerator43))->Current;
											T0 val233 = (T0)current42.id.Equals(current43.str1);
											if (val233 != null)
											{
												current42.message = current43.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator43))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator42))).Dispose();
							}
						}
						else
						{
							T4 enumerator44 = (T4)((List<adaccountsData>)val231).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator44))->MoveNext())
								{
									adaccountsData current44 = ((List<adaccountsData>.Enumerator*)(&enumerator44))->Current;
									current44.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator44))).Dispose();
							}
						}
						((List<ListStringData>)val226).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val227;
					val227 = (T3)(val6 + 1);
				}
			}
			T0 val234 = (T0)RemoveLimit;
			if (val234 != null)
			{
				T1 val235 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val236 = (T3)0;
				while (true)
				{
					T0 val237 = (T0)((nint)val236 < ListAds.Count);
					if (val237 == null)
					{
						break;
					}
					T0 val238 = (T0)(!isRunning);
					if (val238 != null)
					{
						return;
					}
					ListAds[(int)val236].message = STATUS.Processing.ToString();
					ListStringData listStringData17 = new ListStringData();
					listStringData17.str1 = ListAds[(int)val236].id;
					((List<ListStringData>)val235).Add(listStringData17);
					T0 val239 = (T0)((((List<ListStringData>)val235).Count >= intThread || (nint)val236 == ListAds.Count - 1) && ((List<ListStringData>)val235).Count > 0);
					if (val239 != null)
					{
						isDone = frm.chrome.removeLimit_Promise<T0, T9, T14, T6, T15, T3, T13, T1>(val235);
						T2 val240 = (T2)ListAds.Join((IEnumerable<ListStringData>)val235, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val241 = isDone;
						if (val241 != null)
						{
							T4 enumerator45 = (T4)((List<adaccountsData>)val240).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator45))->MoveNext())
								{
									adaccountsData current45 = ((List<adaccountsData>.Enumerator*)(&enumerator45))->Current;
									T6 enumerator46 = (T6)((List<ListStringData>)val235).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator46))->MoveNext())
										{
											ListStringData current46 = ((List<ListStringData>.Enumerator*)(&enumerator46))->Current;
											T0 val242 = (T0)current45.id.Equals(current46.str1);
											if (val242 != null)
											{
												current45.message = current46.str4;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator46))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator45))).Dispose();
							}
						}
						else
						{
							T4 enumerator47 = (T4)((List<adaccountsData>)val240).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator47))->MoveNext())
								{
									adaccountsData current47 = ((List<adaccountsData>.Enumerator*)(&enumerator47))->Current;
									current47.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator47))).Dispose();
							}
						}
						((List<ListStringData>)val235).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val236;
					val236 = (T3)(val6 + 1);
				}
			}
			T0 val243 = (T0)AddAdsToGroup;
			if (val243 != null)
			{
				try
				{
					T1 val244 = (T1)Activator.CreateInstance(typeof(T1));
					T3 val245 = (T3)0;
					while (true)
					{
						T0 val246 = (T0)((nint)val245 < ListAds.Count);
						if (val246 == null)
						{
							break;
						}
						T0 val247 = (T0)(!isRunning);
						if (val247 != null)
						{
							return;
						}
						ListAds[(int)val245].message = STATUS.Processing.ToString();
						ListStringData listStringData18 = new ListStringData();
						listStringData18.str1 = ListAds[(int)val245].id;
						((List<ListStringData>)val244).Add(listStringData18);
						T0 val248 = (T0)((((List<ListStringData>)val244).Count >= intThread || (nint)val245 == ListAds.Count - 1) && ((List<ListStringData>)val244).Count > 0);
						if (val248 != null)
						{
							isDone = frm.chrome.add_ads_to_group_Promise<T0, T9, T14, T6, T15, T3, T13, T1>((T9)asset_groups.data[GROUP_ID].id, val244);
							T2 val249 = (T2)ListAds.Join((IEnumerable<ListStringData>)val244, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
							T0 val250 = isDone;
							if (val250 != null)
							{
								T4 enumerator48 = (T4)((List<adaccountsData>)val249).GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator48))->MoveNext())
									{
										adaccountsData current48 = ((List<adaccountsData>.Enumerator*)(&enumerator48))->Current;
										T6 enumerator49 = (T6)((List<ListStringData>)val244).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator49))->MoveNext())
											{
												ListStringData current49 = ((List<ListStringData>.Enumerator*)(&enumerator49))->Current;
												T0 val251 = (T0)current48.id.Equals(current49.str1);
												if (val251 != null)
												{
													current48.message = current49.str2;
												}
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator49))).Dispose();
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator48))).Dispose();
								}
							}
							else
							{
								T4 enumerator50 = (T4)((List<adaccountsData>)val249).GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator50))->MoveNext())
									{
										adaccountsData current50 = ((List<adaccountsData>.Enumerator*)(&enumerator50))->Current;
										current50.message = frmMain.STATUS.lỗi.ToString();
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator50))).Dispose();
								}
							}
							((List<ListStringData>)val244).Clear();
							Thread.Sleep(intDelay);
						}
						T3 val6 = val245;
						val245 = (T3)(val6 + 1);
					}
				}
				catch (Exception ex)
				{
					errorMessage((T9)ex.Message);
				}
			}
			T0 val252 = (T0)RemoveAdsToGroup;
			if (val252 != null)
			{
				try
				{
					T1 val253 = (T1)Activator.CreateInstance(typeof(T1));
					T3 val254 = (T3)0;
					while (true)
					{
						T0 val255 = (T0)((nint)val254 < ListAds.Count);
						if (val255 == null)
						{
							break;
						}
						T0 val256 = (T0)(!isRunning);
						if (val256 != null)
						{
							return;
						}
						ListAds[(int)val254].message = STATUS.Processing.ToString();
						ListStringData listStringData19 = new ListStringData();
						listStringData19.str1 = ListAds[(int)val254].id;
						((List<ListStringData>)val253).Add(listStringData19);
						T0 val257 = (T0)((((List<ListStringData>)val253).Count >= intThread || (nint)val254 == ListAds.Count - 1) && ((List<ListStringData>)val253).Count > 0);
						if (val257 != null)
						{
							isDone = frm.chrome.xoa_tkqc_trong_nhom_tai_san<T0, T9, T14, T6, T15, T3, T13, T1>((T9)asset_groups.data[GROUP_ID].id, val253);
							T2 val258 = (T2)ListAds.Join((IEnumerable<ListStringData>)val253, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
							T0 val259 = isDone;
							if (val259 != null)
							{
								T4 enumerator51 = (T4)((List<adaccountsData>)val258).GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator51))->MoveNext())
									{
										adaccountsData current51 = ((List<adaccountsData>.Enumerator*)(&enumerator51))->Current;
										T6 enumerator52 = (T6)((List<ListStringData>)val253).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator52))->MoveNext())
											{
												ListStringData current52 = ((List<ListStringData>.Enumerator*)(&enumerator52))->Current;
												T0 val260 = (T0)current51.id.Equals(current52.str1);
												if (val260 != null)
												{
													current51.message = current52.str2;
												}
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator52))).Dispose();
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator51))).Dispose();
								}
							}
							else
							{
								T4 enumerator53 = (T4)((List<adaccountsData>)val258).GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator53))->MoveNext())
									{
										adaccountsData current53 = ((List<adaccountsData>.Enumerator*)(&enumerator53))->Current;
										current53.message = frmMain.STATUS.lỗi.ToString();
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator53))).Dispose();
								}
							}
							((List<ListStringData>)val253).Clear();
							Thread.Sleep(intDelay);
						}
						T3 val6 = val254;
						val254 = (T3)(val6 + 1);
					}
				}
				catch (Exception ex2)
				{
					errorMessage((T9)ex2.Message);
				}
			}
			T0 val261 = (T0)boolKhangTK;
			if (val261 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val262 = (T3)0;
				while (true)
				{
					T0 val263 = (T0)((nint)val262 < ListAds.Count);
					if (val263 == null)
					{
						break;
					}
					while (true)
					{
						T0 val264 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val264 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val265 = (T0)(!isRunning);
					if (val265 != null)
					{
						break;
					}
					T7 val266 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0033: Expected O, but got I4
						//IL_0040: Expected O, but got I4
						//IL_0059: Expected I4, but got O
						//IL_007f: Expected I4, but got O
						//IL_00c6: Expected I4, but got O
						//IL_010a: Expected I4, but got O
						//IL_0143: Expected I4, but got O
						//IL_0171: Expected I4, but got O
						//IL_0199: Expected I4, but got O
						//IL_01b6: Expected O, but got I4
						//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
						//IL_01c0: Expected I4, but got Unknown
						T3 val400 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].message = STATUS.Processing.ToString();
						T0 val401 = (T0)1;
						T3 val402 = (T3)CS_0024_003C_003E8__locals0._003C_003E4__this.intKhangTK;
						T3 val403 = val402;
						switch ((int)val403)
						{
						case 0:
							val401 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.khangTK<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.strMessageKhangTK, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.BMID);
							break;
						case 1:
							val401 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.khangTK_792<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.strMessageKhangTK, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.BMID);
							break;
						case 2:
							val401 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.khangTk_273_Yes<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.strMessageKhangTK);
							break;
						case 3:
							val401 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.khangTk_273_No<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.strMessageKhangTK);
							break;
						}
						T0 val404 = val401;
						if (val404 != null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].message = STATUS.Done.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val400].message = STATUS.lỗi.ToString();
						}
						T3 val405 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val405 - 1;
					});
					((Thread)val266).Start((object)val262);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val262;
					val262 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val267 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val267 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val268 = (T0)ShareTKQCToVia;
			if (val268 != null)
			{
				T9 val269 = (T9)"";
				T3 val270 = (T3)0;
				while (true)
				{
					T0 val271 = (T0)((nint)val270 < ListAds.Count);
					if (val271 == null)
					{
						break;
					}
					T0 val272 = (T0)(!isRunning);
					if (val272 != null)
					{
						break;
					}
					ListAds[(int)val270].message = STATUS.Processing.ToString();
					val269 = (T9)((string)val269 + $"asset_ids[{val270}]={ListAds[(int)val270].id}&");
					T3 val6 = val270;
					val270 = (T3)(val6 + 1);
				}
				T0 val273 = (T0)(((string)val269).Length > 0);
				if (val273 != null)
				{
					val269 = (T9)((string)val269).Remove(((string)val269).Length - 1, 1);
					T0 val274 = frm.chrome.share_tkqc_to_via<T0, T15, T9>((T9)users_in_bm.data[UIDVia].id, val269, (T9)BMID);
					T3 val275 = (T3)0;
					while (true)
					{
						T0 val276 = (T0)((nint)val275 < ListAds.Count);
						if (val276 == null)
						{
							break;
						}
						T0 val277 = val274;
						if (val277 != null)
						{
							ListAds[(int)val275].message = STATUS.Done.ToString();
						}
						else
						{
							ListAds[(int)val275].message = STATUS.lỗi.ToString();
						}
						T3 val6 = val275;
						val275 = (T3)(val6 + 1);
					}
				}
			}
			while (true)
			{
				T0 val278 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val278 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val279 = (T0)RemoveTKQCToVia;
			if (val279 != null)
			{
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val280 = (T3)0;
				while (true)
				{
					T0 val281 = (T0)((nint)val280 < ListAds.Count);
					if (val281 == null)
					{
						break;
					}
					while (true)
					{
						T0 val282 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val282 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val283 = (T0)(!isRunning);
					if (val283 != null)
					{
						break;
					}
					T7 val284 = (T7)new Thread((ParameterizedThreadStart)delegate(T18 obj)
					{
						//IL_000c: Expected O, but got I4
						//IL_001d: Expected I4, but got O
						//IL_0052: Expected I4, but got O
						//IL_0096: Expected I4, but got O
						//IL_00be: Expected I4, but got O
						//IL_00da: Expected O, but got I4
						//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
						//IL_00e3: Expected I4, but got Unknown
						T3 val397 = (T3)int.Parse(obj.ToString());
						CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val397].message = STATUS.Processing.ToString();
						T0 val398 = CS_0024_003C_003E8__locals0._003C_003E4__this.frm.chrome.xoa_tkqc_trong_bm<T0, T15, T9>((T9)CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val397].id, (T9)CS_0024_003C_003E8__locals0._003C_003E4__this.users_in_bm.data[CS_0024_003C_003E8__locals0._003C_003E4__this.UIDVia].id);
						if (val398 != null)
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val397].message = STATUS.Done.ToString();
						}
						else
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.ListAds[(int)val397].message = STATUS.lỗi.ToString();
						}
						T3 val399 = (T3)CS_0024_003C_003E8__locals0.countThread;
						CS_0024_003C_003E8__locals0.countThread = val399 - 1;
					});
					((Thread)val284).Start((object)val280);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val280;
					val280 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val285 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val285 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val286 = (T0)PushCardPrimary;
			if (val286 != null)
			{
				T1 val287 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val288 = (T3)0;
				while (true)
				{
					T0 val289 = (T0)((nint)val288 < ListAds.Count);
					if (val289 == null)
					{
						break;
					}
					T0 val290 = (T0)(!isRunning);
					if (val290 != null)
					{
						return;
					}
					ListAds[(int)val288].message = STATUS.Processing.ToString();
					ListStringData listStringData20 = new ListStringData();
					listStringData20.str1 = ListAds[(int)val288].id;
					((List<ListStringData>)val287).Add(listStringData20);
					T0 val291 = (T0)((((List<ListStringData>)val287).Count >= intThread || (nint)val288 == ListAds.Count - 1) && ((List<ListStringData>)val287).Count > 0);
					if (val291 != null)
					{
						isDone = frm.chrome.day_the_len_chinh_Promise<T0, T9, T6, T21, T15, T13, T3, T14, T1>(val287, (T9)strPushCardPrimary);
						T2 val292 = (T2)ListAds.Join((IEnumerable<ListStringData>)val287, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val293 = isDone;
						if (val293 != null)
						{
							T4 enumerator54 = (T4)((List<adaccountsData>)val292).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator54))->MoveNext())
								{
									adaccountsData current54 = ((List<adaccountsData>.Enumerator*)(&enumerator54))->Current;
									T6 enumerator55 = (T6)((List<ListStringData>)val287).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator55))->MoveNext())
										{
											ListStringData current55 = ((List<ListStringData>.Enumerator*)(&enumerator55))->Current;
											T0 val294 = (T0)current54.id.Equals(current55.str1);
											if (val294 != null)
											{
												current54.message = current55.str3;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator55))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator54))).Dispose();
							}
						}
						else
						{
							T4 enumerator56 = (T4)((List<adaccountsData>)val292).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator56))->MoveNext())
								{
									adaccountsData current56 = ((List<adaccountsData>.Enumerator*)(&enumerator56))->Current;
									current56.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator56))).Dispose();
							}
						}
						((List<ListStringData>)val287).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val288;
					val288 = (T3)(val6 + 1);
				}
			}
			T0 val295 = (T0)OffTkqc;
			if (val295 != null)
			{
				_003C_003Ec__DisplayClass76_2 _003C_003Ec__DisplayClass76_2 = new _003C_003Ec__DisplayClass76_2();
				_003C_003Ec__DisplayClass76_2.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals0;
				T1 val296 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val297 = (T3)0;
				while (true)
				{
					T0 val298 = (T0)((nint)val297 < ListAds.Count);
					if (val298 == null)
					{
						break;
					}
					T0 val299 = (T0)(!isRunning);
					if (val299 == null)
					{
						ListStringData listStringData21 = new ListStringData();
						listStringData21.str1 = ListAds[(int)val297].id;
						((List<ListStringData>)val296).Add(listStringData21);
						T3 val6 = val297;
						val297 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val296);
				_003C_003Ec__DisplayClass76_2.TargetCamp2 = "";
				_003C_003Ec__DisplayClass76_2.TargetAdset2 = "";
				_003C_003Ec__DisplayClass76_2.TargetAd2 = "";
				_003C_003Ec__DisplayClass76_2.CampFilter2 = "";
				T3 val300 = (T3)OnOffTKQC;
				T3 val301 = val300;
				switch ((int)val301)
				{
				case 0:
					_003C_003Ec__DisplayClass76_2.TargetCamp2 = "[{\"field\":\"status\",\"old_value\":\"ACTIVE\",\"new_value\":\"PAUSED\"}]";
					break;
				case 1:
					_003C_003Ec__DisplayClass76_2.TargetAdset2 = "[{\"field\":\"status\",\"old_value\":\"ACTIVE\",\"new_value\":\"PAUSED\"}]";
					break;
				case 2:
					_003C_003Ec__DisplayClass76_2.TargetAd2 = "[{\"field\":\"status\",\"old_value\":\"ACTIVE\",\"new_value\":\"PAUSED\"}]";
					break;
				}
				_003C_003Ec__DisplayClass76_2.CS_0024_003C_003E8__locals2.countThread = 0;
				T3 val302 = (T3)0;
				while (true)
				{
					T0 val303 = (T0)((nint)val302 < ListAds.Count);
					if (val303 == null)
					{
						break;
					}
					while (true)
					{
						T0 val304 = (T0)(isRunning && _003C_003Ec__DisplayClass76_2.CS_0024_003C_003E8__locals2.countThread >= intThread);
						if (val304 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val305 = (T0)(!isRunning);
					if (val305 != null)
					{
						break;
					}
					T7 val306 = (T7)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass76_2._003CthrStart_003Eb__67<T0, T3, T5, T9, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val306).Start((object)val302);
					T3 val6 = (T3)_003C_003Ec__DisplayClass76_2.CS_0024_003C_003E8__locals2.countThread;
					_003C_003Ec__DisplayClass76_2.CS_0024_003C_003E8__locals2.countThread = val6 + 1;
					val6 = val302;
					val302 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val307 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val307 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val308 = (T0)OnTkqc;
			if (val308 != null)
			{
				_003C_003Ec__DisplayClass76_3 _003C_003Ec__DisplayClass76_3 = new _003C_003Ec__DisplayClass76_3();
				_003C_003Ec__DisplayClass76_3.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals0;
				T1 val309 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val310 = (T3)0;
				while (true)
				{
					T0 val311 = (T0)((nint)val310 < ListAds.Count);
					if (val311 == null)
					{
						break;
					}
					T0 val312 = (T0)(!isRunning);
					if (val312 == null)
					{
						ListStringData listStringData22 = new ListStringData();
						listStringData22.str1 = ListAds[(int)val310].id;
						((List<ListStringData>)val309).Add(listStringData22);
						T3 val6 = val310;
						val310 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val309);
				_003C_003Ec__DisplayClass76_3.TargetCamp2 = "";
				_003C_003Ec__DisplayClass76_3.TargetAdset2 = "";
				_003C_003Ec__DisplayClass76_3.TargetAd2 = "";
				_003C_003Ec__DisplayClass76_3.CampFilter2 = "";
				T3 val313 = (T3)OnOffTKQC;
				T3 val314 = val313;
				switch ((int)val314)
				{
				case 0:
					_003C_003Ec__DisplayClass76_3.TargetCamp2 = "[{\"field\":\"status\",\"old_value\":\"PAUSED\",\"new_value\":\"ACTIVE\"}]";
					break;
				case 1:
					_003C_003Ec__DisplayClass76_3.TargetAdset2 = "[{\"field\":\"status\",\"old_value\":\"PAUSED\",\"new_value\":\"ACTIVE\"}]";
					break;
				case 2:
					_003C_003Ec__DisplayClass76_3.TargetAd2 = "[{\"field\":\"status\",\"old_value\":\"PAUSED\",\"new_value\":\"ACTIVE\"}]";
					break;
				}
				_003C_003Ec__DisplayClass76_3.CS_0024_003C_003E8__locals3.countThread = 0;
				T3 val315 = (T3)0;
				while (true)
				{
					T0 val316 = (T0)((nint)val315 < ListAds.Count);
					if (val316 == null)
					{
						break;
					}
					while (true)
					{
						T0 val317 = (T0)(isRunning && _003C_003Ec__DisplayClass76_3.CS_0024_003C_003E8__locals3.countThread >= intThread);
						if (val317 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val318 = (T0)(!isRunning);
					if (val318 != null)
					{
						break;
					}
					T7 val319 = (T7)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass76_3._003CthrStart_003Eb__68<T0, T3, T5, T9, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val319).Start((object)val315);
					T3 val6 = (T3)_003C_003Ec__DisplayClass76_3.CS_0024_003C_003E8__locals3.countThread;
					_003C_003Ec__DisplayClass76_3.CS_0024_003C_003E8__locals3.countThread = val6 + 1;
					val6 = val315;
					val315 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val320 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val320 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val321 = (T0)RemoveCamp;
			if (val321 != null)
			{
				_003C_003Ec__DisplayClass76_4 _003C_003Ec__DisplayClass76_4 = new _003C_003Ec__DisplayClass76_4();
				_003C_003Ec__DisplayClass76_4.CS_0024_003C_003E8__locals4 = CS_0024_003C_003E8__locals0;
				T1 val322 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val323 = (T3)0;
				while (true)
				{
					T0 val324 = (T0)((nint)val323 < ListAds.Count);
					if (val324 == null)
					{
						break;
					}
					T0 val325 = (T0)(!isRunning);
					if (val325 == null)
					{
						ListStringData listStringData23 = new ListStringData();
						listStringData23.str1 = ListAds[(int)val323].id;
						((List<ListStringData>)val322).Add(listStringData23);
						T3 val6 = val323;
						val323 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val322);
				_003C_003Ec__DisplayClass76_4.TargetCamp2 = "[{\"field\":\"status\",\"old_value\":\"ACTIVE\",\"new_value\":\"ARCHIVED\"}]";
				_003C_003Ec__DisplayClass76_4.TargetAdset2 = "";
				_003C_003Ec__DisplayClass76_4.TargetAd2 = "";
				_003C_003Ec__DisplayClass76_4.CampFilter2 = "";
				_003C_003Ec__DisplayClass76_4.CS_0024_003C_003E8__locals4.countThread = 0;
				T3 val326 = (T3)0;
				while (true)
				{
					T0 val327 = (T0)((nint)val326 < ListAds.Count);
					if (val327 == null)
					{
						break;
					}
					while (true)
					{
						T0 val328 = (T0)(isRunning && _003C_003Ec__DisplayClass76_4.CS_0024_003C_003E8__locals4.countThread >= intThread);
						if (val328 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val329 = (T0)(!isRunning);
					if (val329 != null)
					{
						break;
					}
					T7 val330 = (T7)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass76_4._003CthrStart_003Eb__69<T0, T3, T5, T9, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val330).Start((object)val326);
					T3 val6 = (T3)_003C_003Ec__DisplayClass76_4.CS_0024_003C_003E8__locals4.countThread;
					_003C_003Ec__DisplayClass76_4.CS_0024_003C_003E8__locals4.countThread = val6 + 1;
					val6 = val326;
					val326 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val331 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val331 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val332 = (T0)EditTarget;
			if (val332 != null)
			{
				T1 val333 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val334 = (T3)0;
				while (true)
				{
					T0 val335 = (T0)((nint)val334 < ListAds.Count);
					if (val335 == null)
					{
						break;
					}
					T0 val336 = (T0)(!isRunning);
					if (val336 == null)
					{
						ListStringData listStringData24 = new ListStringData();
						listStringData24.str1 = ListAds[(int)val334].id;
						((List<ListStringData>)val333).Add(listStringData24);
						T3 val6 = val334;
						val334 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val333);
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val337 = (T3)0;
				while (true)
				{
					T0 val338 = (T0)((nint)val337 < ListAds.Count);
					if (val338 == null)
					{
						break;
					}
					while (true)
					{
						T0 val339 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val339 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val340 = (T0)(!isRunning);
					if (val340 != null)
					{
						break;
					}
					T7 val341 = (T7)new Thread((ParameterizedThreadStart)CS_0024_003C_003E8__locals0._003CthrStart_003Eb__70<T0, T3, T5, T9, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val341).Start((object)val337);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val337;
					val337 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val342 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val342 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val343 = (T0)ChangePost;
			if (val343 != null)
			{
				_003C_003Ec__DisplayClass76_5 _003C_003Ec__DisplayClass76_5 = new _003C_003Ec__DisplayClass76_5();
				_003C_003Ec__DisplayClass76_5.CS_0024_003C_003E8__locals5 = CS_0024_003C_003E8__locals0;
				T1 val344 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val345 = (T3)0;
				while (true)
				{
					T0 val346 = (T0)((nint)val345 < ListAds.Count);
					if (val346 == null)
					{
						break;
					}
					T0 val347 = (T0)(!isRunning);
					if (val347 == null)
					{
						ListStringData listStringData25 = new ListStringData();
						listStringData25.str1 = ListAds[(int)val345].id;
						((List<ListStringData>)val344).Add(listStringData25);
						T3 val6 = val345;
						val345 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val344);
				Thread.Sleep(3000);
				_003C_003Ec__DisplayClass76_5.changePost = string.Concat((string[])(object)new T9[5]
				{
					(T9)"[{\"field\":\"creative\",\"old_value\":{\"authorization_category\":\"NONE\",\"actor_type\":\"PAGE\",\"object_story_id\":\"\",\"effective_object_story_id\":\"\",\"uca_draft_version\":0,\"use_page_actor_override\":false,},\"new_value\":{\"authorization_category\":\"NONE\",\"actor_type\":\"PAGE\",\"object_story_id\":\"",
					(T9)strPageId,
					(T9)"_",
					(T9)strPostId,
					(T9)"\",\"effective_object_story_id\":\"\",\"uca_draft_version\":0,\"use_page_actor_override\":false,}}]"
				});
				_003C_003Ec__DisplayClass76_5.CS_0024_003C_003E8__locals5.countThread = 0;
				T3 val348 = (T3)0;
				while (true)
				{
					T0 val349 = (T0)((nint)val348 < ListAds.Count);
					if (val349 == null)
					{
						break;
					}
					while (true)
					{
						T0 val350 = (T0)(isRunning && _003C_003Ec__DisplayClass76_5.CS_0024_003C_003E8__locals5.countThread >= intThread);
						if (val350 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val351 = (T0)(!isRunning);
					if (val351 != null)
					{
						break;
					}
					T7 val352 = (T7)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass76_5._003CthrStart_003Eb__71<T0, T3, T5, T9, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val352).Start((object)val348);
					T3 val6 = (T3)_003C_003Ec__DisplayClass76_5.CS_0024_003C_003E8__locals5.countThread;
					_003C_003Ec__DisplayClass76_5.CS_0024_003C_003E8__locals5.countThread = val6 + 1;
					val6 = val348;
					val348 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val353 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val353 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val354 = (T0)ChangeBugetCamp;
			if (val354 != null)
			{
				T1 val355 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val356 = (T3)0;
				while (true)
				{
					T0 val357 = (T0)((nint)val356 < ListAds.Count);
					if (val357 == null)
					{
						break;
					}
					T0 val358 = (T0)(!isRunning);
					if (val358 == null)
					{
						ListStringData listStringData26 = new ListStringData();
						listStringData26.str1 = ListAds[(int)val356].id;
						((List<ListStringData>)val355).Add(listStringData26);
						T3 val6 = val356;
						val356 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val355);
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val359 = (T3)0;
				while (true)
				{
					T0 val360 = (T0)((nint)val359 < ListAds.Count);
					if (val360 == null)
					{
						break;
					}
					while (true)
					{
						T0 val361 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val361 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val362 = (T0)(!isRunning);
					if (val362 != null)
					{
						break;
					}
					T7 val363 = (T7)new Thread((ParameterizedThreadStart)CS_0024_003C_003E8__locals0._003CthrStart_003Eb__72<T0, T3, T9, T5, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val363).Start((object)val359);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val359;
					val359 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val364 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val364 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val365 = (T0)ChangeBugetGruopAds;
			if (val365 != null)
			{
				T1 val366 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val367 = (T3)0;
				while (true)
				{
					T0 val368 = (T0)((nint)val367 < ListAds.Count);
					if (val368 == null)
					{
						break;
					}
					T0 val369 = (T0)(!isRunning);
					if (val369 == null)
					{
						ListStringData listStringData27 = new ListStringData();
						listStringData27.str1 = ListAds[(int)val367].id;
						((List<ListStringData>)val366).Add(listStringData27);
						T3 val6 = val367;
						val367 = (T3)(val6 + 1);
						continue;
					}
					return;
				}
				frm.chrome.reaload_campaigns_Promise<T0, T1, T6, T13, T9, T14, T15, T3>(val366);
				CS_0024_003C_003E8__locals0.countThread = 0;
				T3 val370 = (T3)0;
				while (true)
				{
					T0 val371 = (T0)((nint)val370 < ListAds.Count);
					if (val371 == null)
					{
						break;
					}
					while (true)
					{
						T0 val372 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread >= intThread);
						if (val372 == null)
						{
							break;
						}
						Thread.Sleep(1500);
					}
					T0 val373 = (T0)(!isRunning);
					if (val373 != null)
					{
						break;
					}
					T7 val374 = (T7)new Thread((ParameterizedThreadStart)CS_0024_003C_003E8__locals0._003CthrStart_003Eb__73<T0, T3, T9, T5, T23, T18, List<ADSPRoject.Data.Campains.campaigns_data>.Enumerator, List<ADSPRoject.Data.Campains.adsets_data>.Enumerator, List<ADSPRoject.Data.Campains.ads_data>.Enumerator, T13, T15, T17>);
					((Thread)val374).Start((object)val370);
					T3 val6 = (T3)CS_0024_003C_003E8__locals0.countThread;
					CS_0024_003C_003E8__locals0.countThread = val6 + 1;
					val6 = val370;
					val370 = (T3)(val6 + 1);
				}
			}
			while (true)
			{
				T0 val375 = (T0)(isRunning && CS_0024_003C_003E8__locals0.countThread > 0);
				if (val375 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T0 val376 = (T0)ApprovedPayment;
			if (val376 != null)
			{
				approvedPayment<T1, T3, T0, T2, T4, T6, T9, T14, T15, T13, T17, T25, T16, T18>(out *(bool*)(&isDone));
			}
			T0 val377 = (T0)CardVerify;
			if (val377 != null)
			{
				T1 val378 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val379 = (T3)0;
				while (true)
				{
					T0 val380 = (T0)((nint)val379 < ListAds.Count);
					if (val380 == null)
					{
						break;
					}
					T0 val381 = (T0)(!isRunning);
					if (val381 != null)
					{
						return;
					}
					T0 val382 = (T0)(ListAds[(int)val379].payment_account == null || ListAds[(int)val379].payment_account.data == null || ListAds[(int)val379].payment_account.data.billable_account_by_payment_account == null || ListAds[(int)val379].payment_account.data.billable_account_by_payment_account.billing_payment_account == null || ListAds[(int)val379].payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods == null || ListAds[(int)val379].payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.Count <= 0 || ListAds[(int)val379].payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.First().credential == null || ListAds[(int)val379].payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.First().credential.credential_id == null);
					if (val382 != null)
					{
						ListAds[(int)val379].message = STATUS.lỗi.ToString();
					}
					else
					{
						ListAds[(int)val379].message = STATUS.Processing.ToString();
						ListStringData listStringData28 = new ListStringData();
						listStringData28.str1 = ListAds[(int)val379].id;
						listStringData28.str2 = ListAds[(int)val379].payment_account.data.billable_account_by_payment_account.billing_payment_account.billing_payment_methods.First().credential.credential_id;
						listStringData28.str3 = "";
						((List<ListStringData>)val378).Add(listStringData28);
						T0 val383 = (T0)((((List<ListStringData>)val378).Count >= intThread || (nint)val379 == ListAds.Count - 1) && ((List<ListStringData>)val378).Count > 0);
						if (val383 != null)
						{
							isDone = frm.chrome.xm_3ds2_the_Promise<T0, T9, T14, T6, T15, T3, T13, T1, T17, T25, T16, T18>(val378);
							T2 val384 = (T2)ListAds.Join((IEnumerable<ListStringData>)val378, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
							T0 val385 = isDone;
							if (val385 != null)
							{
								T4 enumerator57 = (T4)((List<adaccountsData>)val384).GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator57))->MoveNext())
									{
										adaccountsData current57 = ((List<adaccountsData>.Enumerator*)(&enumerator57))->Current;
										T6 enumerator58 = (T6)((List<ListStringData>)val378).GetEnumerator();
										try
										{
											while (((List<ListStringData>.Enumerator*)(&enumerator58))->MoveNext())
											{
												ListStringData current58 = ((List<ListStringData>.Enumerator*)(&enumerator58))->Current;
												T0 val386 = (T0)current57.id.Equals(current58.str1);
												if (val386 != null)
												{
													current57.message = current58.str3;
												}
											}
										}
										finally
										{
											((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator58))).Dispose();
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator57))).Dispose();
								}
							}
							else
							{
								T4 enumerator59 = (T4)((List<adaccountsData>)val384).GetEnumerator();
								try
								{
									while (((List<adaccountsData>.Enumerator*)(&enumerator59))->MoveNext())
									{
										adaccountsData current59 = ((List<adaccountsData>.Enumerator*)(&enumerator59))->Current;
										current59.message = frmMain.STATUS.lỗi.ToString();
									}
								}
								finally
								{
									((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator59))).Dispose();
								}
							}
							((List<ListStringData>)val378).Clear();
							Thread.Sleep(intDelay);
						}
					}
					T3 val6 = val379;
					val379 = (T3)(val6 + 1);
				}
			}
			T0 val387 = (T0)SharePixel;
			if (val387 != null)
			{
				T1 val388 = (T1)Activator.CreateInstance(typeof(T1));
				T3 val389 = (T3)0;
				while (true)
				{
					T0 val390 = (T0)((nint)val389 < ListAds.Count);
					if (val390 == null)
					{
						break;
					}
					T0 val391 = (T0)(!isRunning);
					if (val391 != null)
					{
						return;
					}
					ListAds[(int)val389].message = STATUS.Processing.ToString();
					ListStringData listStringData29 = new ListStringData();
					listStringData29.str1 = ListAds[(int)val389].id;
					((List<ListStringData>)val388).Add(listStringData29);
					T0 val392 = (T0)((((List<ListStringData>)val388).Count >= intThread || (nint)val389 == ListAds.Count - 1) && ((List<ListStringData>)val388).Count > 0);
					if (val392 != null)
					{
						isDone = frm.chrome.sharePixel_Promise<T0, T9, T14, T6, T15, T3, T13, T1, T17, T25, T16, T18>(val388, (T9)BM_Pixel, (T9)IdPixel);
						T2 val393 = (T2)ListAds.Join((IEnumerable<ListStringData>)val388, (Func<adaccountsData, T9>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
						T0 val394 = isDone;
						if (val394 != null)
						{
							T4 enumerator60 = (T4)((List<adaccountsData>)val393).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator60))->MoveNext())
								{
									adaccountsData current60 = ((List<adaccountsData>.Enumerator*)(&enumerator60))->Current;
									T6 enumerator61 = (T6)((List<ListStringData>)val388).GetEnumerator();
									try
									{
										while (((List<ListStringData>.Enumerator*)(&enumerator61))->MoveNext())
										{
											ListStringData current61 = ((List<ListStringData>.Enumerator*)(&enumerator61))->Current;
											T0 val395 = (T0)current60.id.Equals(current61.str1);
											if (val395 != null)
											{
												current60.message = current61.str2;
											}
										}
									}
									finally
									{
										((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator61))).Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator60))).Dispose();
							}
						}
						else
						{
							T4 enumerator62 = (T4)((List<adaccountsData>)val393).GetEnumerator();
							try
							{
								while (((List<adaccountsData>.Enumerator*)(&enumerator62))->MoveNext())
								{
									adaccountsData current62 = ((List<adaccountsData>.Enumerator*)(&enumerator62))->Current;
									current62.message = frmMain.STATUS.lỗi.ToString();
								}
							}
							finally
							{
								((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator62))).Dispose();
							}
						}
						((List<ListStringData>)val388).Clear();
						Thread.Sleep(intDelay);
					}
					T3 val6 = val389;
					val389 = (T3)(val6 + 1);
				}
			}
			T0 val396 = (T0)boolApproved2;
			if (val396 != null)
			{
				Thread.Sleep(intDelayApproved2 * 1000);
				approvedPayment<T1, T3, T0, T2, T4, T6, T9, T14, T15, T13, T17, T25, T16, T18>(out *(bool*)(&isDone));
			}
			isRunning = false;
		}
		catch (Exception ex3)
		{
			errorMessage((T9)ex3.Message);
		}
	}

	private unsafe void approvedPayment<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(out bool isDone)
	{
		//IL_0015: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0048: Expected I4, but got O
		//IL_0070: Expected I4, but got O
		//IL_00af: Expected O, but got I4
		//IL_00c9: Expected I4, but got O
		//IL_013d: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		isDone = false;
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)0;
		while (true)
		{
			T2 val3 = (T2)((nint)val2 < ListAds.Count);
			if (val3 == null)
			{
				break;
			}
			T2 val4 = (T2)(!isRunning);
			if (val4 != null)
			{
				break;
			}
			ListAds[(int)val2].message = STATUS.Processing.ToString();
			ListStringData listStringData = new ListStringData();
			listStringData.str1 = ListAds[(int)val2].id;
			((List<ListStringData>)val).Add(listStringData);
			T2 val5 = (T2)((((List<ListStringData>)val).Count >= intThread || (nint)val2 == ListAds.Count - 1) && ((List<ListStringData>)val).Count > 0);
			if (val5 != null)
			{
				isDone = (byte)(int)frm.chrome.approvedPayment_Promise<T2, T6, T7, T5, T8, T1, T9, T0, T10, T11, T12, T13>(val) != 0;
				T3 val6 = (T3)ListAds.Join((IEnumerable<ListStringData>)val, (Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.id), (Func<ListStringData, T6>)(object)(Func<ListStringData, string>)((ListStringData d) => (T6)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
				T2 val7 = (T2)isDone;
				if (val7 != null)
				{
					T4 enumerator = (T4)((List<adaccountsData>)val6).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
							T5 enumerator2 = (T5)((List<ListStringData>)val).GetEnumerator();
							try
							{
								while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
								{
									ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
									T2 val8 = (T2)current.id.Equals(current2.str1);
									if (val8 != null)
									{
										current.message = current2.str2;
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
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				else
				{
					T4 enumerator3 = (T4)((List<adaccountsData>)val6).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator3))->MoveNext())
						{
							adaccountsData current3 = ((List<adaccountsData>.Enumerator*)(&enumerator3))->Current;
							current3.message = frmMain.STATUS.lỗi.ToString();
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator3))).Dispose();
					}
				}
				((List<ListStringData>)val).Clear();
				Thread.Sleep(intDelay);
			}
			val2 = (T1)(val2 + 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void addCard<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 isPlushPrimary, T2 isMFacebook, T2 isLink667, T2 isCode, T2 isBoospost, T2 isSuite, T2 isLink1, T2 isAPI, T2 isRequest, T2 isMFacebook2)
	{
		//IL_0013: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0034: Expected I4, but got O
		//IL_0053: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00c4: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0108: Expected O, but got I4
		//IL_013c: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_01c2: Expected O, but got I4
		//IL_02bd: Expected O, but got I4
		//IL_02c4: Expected O, but got I4
		//IL_02cf: Expected I4, but got O
		//IL_02eb: Expected O, but got I4
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0302: Expected O, but got I4
		//IL_0311: Expected I4, but got O
		//IL_0330: Expected I4, but got O
		//IL_0337: Expected O, but got I4
		//IL_034f: Expected O, but got I4
		//IL_035f: Expected I4, but got O
		//IL_037b: Expected I4, but got O
		//IL_0408: Expected I4, but got O
		//IL_0436: Expected O, but got I4
		//IL_0464: Expected O, but got I4
		//IL_0464: Expected O, but got I4
		//IL_0519: Expected O, but got I4
		//IL_0546: Expected O, but got I4
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected O, but got Unknown
		//IL_0635: Expected O, but got I4
		try
		{
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			T1 val2 = (T1)0;
			while (true)
			{
				T2 val3 = (T2)((nint)val2 < ListAds.Count);
				if (val3 == null)
				{
					break;
				}
				T2 val4 = (T2)(!isRunning);
				if (val4 != null)
				{
					break;
				}
				ListAds[(int)val2].message = STATUS.Processing.ToString();
				CreditCardEntity creditCardEntity = null;
				T2 val5 = (T2)blListCardCenter;
				if (val5 == null)
				{
					T2 val6 = (T2)blListCard;
					if (val6 != null)
					{
						T1 val7 = (T1)0;
						while (true)
						{
							T2 val8 = (T2)((nint)val7 < frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.Count);
							if (val8 != null)
							{
								CreditCardEntity creditCardEntity2 = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard[(int)val7];
								T2 val9 = (T2)creditCardEntity2.Status.Equals(frmMain.STATUS.Ready.ToString());
								if (val9 == null)
								{
									val7 = (T1)(val7 + 1);
									continue;
								}
								creditCardEntity2.Status = frmMain.STATUS.Processing.ToString();
								creditCardEntity = creditCardEntity2;
								break;
							}
							break;
						}
					}
					else
					{
						T2 val10 = (T2)blBinGen;
						if (val10 != null)
						{
							T4 val11 = (T4)"";
							while (true)
							{
								T5 enumerator = (T5)listBinGen.GetEnumerator();
								try
								{
									while (((List<BinGenClass>.Enumerator*)(&enumerator))->MoveNext())
									{
										BinGenClass current = ((List<BinGenClass>.Enumerator*)(&enumerator))->Current;
										T2 val12 = (T2)current.Status.Equals(frmMain.STATUS.Ready.ToString());
										if (val12 != null)
										{
											val11 = (T4)current.Bin;
											current.Status = frmMain.STATUS.Used.ToString();
											break;
										}
									}
								}
								finally
								{
									((IDisposable)(*(List<BinGenClass>.Enumerator*)(&enumerator))).Dispose();
								}
								T2 val13 = (T2)string.IsNullOrWhiteSpace((string)val11);
								if (val13 == null)
								{
									break;
								}
								T5 enumerator2 = (T5)listBinGen.GetEnumerator();
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
							T4 cardGen = BinGen2Class.getCardGen<T1, T4, CreditCardDetector, T2, Regex, DateTime, T10, object>(val11);
							creditCardEntity.Card_Number = ((string)cardGen).Split((char[])(object)new T10[1] { (T10)124 })[0];
							creditCardEntity.Exp_Month = ((string)cardGen).Split((char[])(object)new T10[1] { (T10)124 })[1];
							creditCardEntity.Exp_Year = ((string)cardGen).Split((char[])(object)new T10[1] { (T10)124 })[2];
							creditCardEntity.Card_Security = ((string)cardGen).Split((char[])(object)new T10[1] { (T10)124 })[3];
						}
					}
				}
				else
				{
					T3 val14 = frmMain.listCreditCardEntity<T1, T2, T3, T4>((T4)ListCardCenter);
					T2 val15 = (T2)(val14 != null && ((List<CreditCardEntity>)val14).Count > 0);
					if (val15 != null)
					{
						T1 val16 = (T1)0;
						while (true)
						{
							T2 val17 = (T2)((nint)val16 < ((List<CreditCardEntity>)val14).Count);
							if (val17 == null)
							{
								break;
							}
							T2 val18 = (T2)((List<CreditCardEntity>)val14)[(int)val16].Status.Equals(frmMain.STATUS.Ready.ToString());
							if (val18 == null)
							{
								val16 = (T1)(val16 + 1);
								continue;
							}
							((List<CreditCardEntity>)val14)[(int)val16].Status = frmMain.STATUS.Used.ToString();
							creditCardEntity = ((List<CreditCardEntity>)val14)[(int)val16];
							break;
						}
					}
				}
				T2 val19 = (T2)(creditCardEntity == null);
				if (val19 == null)
				{
					T4 business_country_code = (T4)strCardCountry;
					T2 val20 = (T2)string.IsNullOrWhiteSpace((string)business_country_code);
					if (val20 != null)
					{
						business_country_code = (T4)ListAds[(int)val2].business_country_code;
					}
					ListStringData listStringData = new ListStringData();
					listStringData.str1 = ListAds[(int)val2].id;
					listStringData.str2 = (string)business_country_code;
					listStringData.str3 = string.Concat((string[])(object)new T4[9]
					{
						(T4)creditCardEntity.Card_Number,
						(T4)"|",
						(T4)creditCardEntity.Exp_Month,
						(T4)"|",
						(T4)creditCardEntity.Exp_Year,
						(T4)"|",
						(T4)creditCardEntity.Card_Security,
						(T4)"|",
						(T4)NameCard
					});
					((List<ListStringData>)val).Add(listStringData);
				}
				else
				{
					ListAds[(int)val2].message = "Hết thẻ";
				}
				T2 val21 = (T2)(((List<ListStringData>)val).Count >= intThread || (nint)val2 == ListAds.Count - 1);
				if (val21 != null)
				{
					frm.chrome.addCard_Promise<T2, T0, T4, T11, T8, T12, T1, T9, T10>(val, isPlushPrimary, isMFacebook, isLink667, isCode, isBoospost, isSuite, isLink1, isAPI, isRequest, (T2)0, (T2)0, (T4)"");
					T6 val22 = (T6)ListAds.Join((IEnumerable<ListStringData>)val, (Func<adaccountsData, T4>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T4)a.id), (Func<ListStringData, T4>)(object)(Func<ListStringData, string>)((ListStringData d) => (T4)d.str1), (adaccountsData a, ListStringData d) => a).ToList();
					T7 enumerator3 = (T7)((List<adaccountsData>)val22).GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator3))->MoveNext())
						{
							adaccountsData current3 = ((List<adaccountsData>.Enumerator*)(&enumerator3))->Current;
							T8 enumerator4 = (T8)((List<ListStringData>)val).GetEnumerator();
							try
							{
								while (((List<ListStringData>.Enumerator*)(&enumerator4))->MoveNext())
								{
									ListStringData current4 = ((List<ListStringData>.Enumerator*)(&enumerator4))->Current;
									T2 val23 = (T2)current3.id.Equals(current4.str1);
									if (val23 != null)
									{
										current3.message = current4.str4;
										T4 val24 = (T4)"";
										T2 val25 = (T2)(!string.IsNullOrWhiteSpace(current4.str5));
										if (val25 != null)
										{
											val24 = Compound2Unicode.compound2Unicode((T4)current4.str5.ToString());
										}
										Card_Log = string.Concat((string[])(object)new T4[10]
										{
											(T4)Card_Log,
											(T4)current4.str1.Replace("act_", ""),
											(T4)"-",
											(T4)current4.str3,
											(T4)": ",
											(T4)current4.str4,
											(T4)"- (",
											val24,
											(T4)")",
											(T4)Environment.NewLine
										});
									}
								}
							}
							finally
							{
								((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator4))).Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator3))).Dispose();
					}
					((List<ListStringData>)val).Clear();
					Thread.Sleep(intDelay);
				}
				val2 = (T1)(val2 + 1);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void infoMessage<T0>(T0 ms)
	{
		MessageBox.Show((string)ms, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void errorMessage<T0>(T0 ms)
	{
		MessageBox.Show((string)ms, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer_auto_refesh_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0026: Expected O, but got I4
		gvData.Refresh();
		txtAddCard_Log.Text = Card_Log;
		T0 val = (T0)(!isRunning);
		if (val != null)
		{
			button1.Text = "START";
			button1.BackColor = Color.DodgerBlue;
			timer_auto_refesh.Stop();
			MessageBox.Show("Done", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void cbImportCamp_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ImportCamp = cbImportCamp.Checked;
		T0 val = (T0)ImportCamp;
		if (val != null)
		{
			cbImportCamp.ForeColor = Color.Red;
		}
		else
		{
			cbImportCamp.ForeColor = Color.Black;
		}
	}

	private void cbClearAddraft_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ClearAddraft = cbClearAddraft.Checked;
		T0 val = (T0)ClearAddraft;
		if (val != null)
		{
			cbClearAddraft.ForeColor = Color.Red;
		}
		else
		{
			cbClearAddraft.ForeColor = Color.Black;
		}
	}

	private void cbResetLimit_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ResetLimit = cbResetLimit.Checked;
		T0 val = (T0)ResetLimit;
		if (val == null)
		{
			cbResetLimit.ForeColor = Color.Black;
		}
		else
		{
			cbResetLimit.ForeColor = Color.Red;
		}
	}

	private void cbRemoveActInBM_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveActInBM = cbRemoveActInBM.Checked;
		T0 val = (T0)RemoveActInBM;
		if (val != null)
		{
			cbRemoveActInBM.ForeColor = Color.Red;
		}
		else
		{
			cbRemoveActInBM.ForeColor = Color.Black;
		}
	}

	private void cbPublishCamp_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		PublishCamp = cbPublishCamp.Checked;
		T0 val = (T0)PublishCamp;
		if (val != null)
		{
			cbPublishCamp.ForeColor = Color.Red;
		}
		else
		{
			cbPublishCamp.ForeColor = Color.Black;
		}
	}

	private void cbPublishGroup_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		PublishGroup = cbPublishGroup.Checked;
		T0 val = (T0)PublishGroup;
		if (val != null)
		{
			cbPublishGroup.ForeColor = Color.Red;
		}
		else
		{
			cbPublishGroup.ForeColor = Color.Black;
		}
	}

	private void cbPublishAds_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		PublishAds = cbPublishAds.Checked;
		T0 val = (T0)PublishAds;
		if (val == null)
		{
			cbPublishAds.ForeColor = Color.Black;
		}
		else
		{
			cbPublishAds.ForeColor = Color.Red;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmPublishCampText_Load<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_002b: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		//IL_01c3: Expected I4, but got O
		//IL_0200: Expected O, but got I4
		//IL_020b: Expected I4, but got O
		//IL_0284: Expected O, but got I4
		//IL_02f2: Expected O, but got I4
		//IL_0361: Expected O, but got I4
		//IL_03cf: Expected O, but got I4
		//IL_043e: Expected O, but got I4
		//IL_04ad: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0843: Expected O, but got I4
		//IL_08ec: Expected O, but got I4
		//IL_0a09: Expected O, but got I4
		//IL_0c03: Expected O, but got I4
		//IL_0c7d: Expected O, but got I4
		rbBinGen.Checked = true;
		groupRollingMat.Visible = User.AdsManager_RollingMatThread;
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			txtChangeNameAds.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtChangeNameAds;
			txtLimit.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtLimit;
			txtBMID.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMID;
			txtTextCamp.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTextCamp;
			T0 val2 = (T0)(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThread == 0);
			if (val2 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThread = 10;
			}
			NumericUpDown numericUpDown = numThread;
			int num = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThread;
			T1 val3 = (T1)num;
			intThread = num;
			numericUpDown.Value = (int)val3;
			NumericUpDown numericUpDown2 = numDelay;
			int num2 = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelay;
			val3 = (T1)num2;
			intDelay = num2;
			numericUpDown2.Value = (int)val3;
			numDelayApproved2.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelayApproved2;
			T0 val4 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddress);
			if (val4 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddress = "69 Tran Duy Hung";
			}
			T0 val5 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCity);
			if (val5 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCity = "Ha Noi";
			}
			T0 val6 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtState);
			if (val6 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtState = "";
			}
			T0 val7 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZip);
			if (val7 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZip = "100000";
			}
			T0 val8 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountry);
			if (val8 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountry = "VN";
			}
			T0 val9 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrency);
			if (val9 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrency = "VND";
			}
			T0 val10 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZone);
			if (val10 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZone = "Asia/Ho_Chi_Minh";
			}
			txtTargetCamp.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTargetCamp;
			txtTargetAdset.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTargetAdset;
			txtTargetAd.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTargetAd;
			txtCampFilter.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCampFilter;
			txtAddress.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddress;
			txtCity.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCity;
			txtState.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtState;
			txtZip.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZip;
			txtCountry.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountry;
			txtCurrency.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrency;
			txtTimeZone.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZone;
			txtPayBalance.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPayBalance;
			T0 val11 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtRemoveCardByName);
			if (val11 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtRemoveCardByName = "master";
			}
			txtRemoveCardByName.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtRemoveCardByName;
			T0 val12 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].BugetCamp);
			if (val12 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].BugetCamp = "90000";
			}
			txtBugetCamp.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].BugetCamp;
			txtCardCountry.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCardCountry;
			txtBinGen.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBinGen;
			T0 val13 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameCard);
			if (val13 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameCard = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].Name.ToUpper();
			}
			txtNameCard.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameCard;
			txtIdPixel.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtIdPixel;
			txtBM_Pixel.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBM_Pixel;
			txtPushCardPrimary.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPushCardPrimary;
			cbRemoveCamp.Checked = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].cbRemoveCamp;
			txtPro5List.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPro5List;
			T0 val14 = (T0)(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numAddActOnPage <= 0);
			if (val14 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numAddActOnPage = 1;
			}
			numAddActOnPage.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numAddActOnPage;
			T0 val15 = (T0)User.AdsManager_RollingMatThread;
			if (val15 != null)
			{
				cbRollingMatThread.Checked = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].cbRollingMatThread;
				numDelayRemoveCard.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelayRemoveCard;
			}
			else
			{
				cbRollingMatThread.Checked = false;
			}
			numDelayLifeCycle.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelayLifeCycle;
			numLifeCycle.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numLifeCycle;
			loadCC<T0, T1, Exception, List<CreditCardEntity>>();
		}
		cbbKhangTK.SelectedIndex = 0;
	}

	private void txtBMID_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BMID = txtBMID.Text;
	}

	private void ccbAddCart_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCart = ccbAddCart.Checked;
		T0 val = (T0)AddCart;
		if (val == null)
		{
			ccbAddCart.ForeColor = Color.Black;
		}
		else
		{
			ccbAddCart.ForeColor = Color.Red;
		}
	}

	private void cbSetLimit_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SetLimit = cbSetLimit.Checked;
		T0 val = (T0)SetLimit;
		if (val != null)
		{
			cbSetLimit.ForeColor = Color.Red;
		}
		else
		{
			cbSetLimit.ForeColor = Color.Black;
		}
	}

	private void txtLimit_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Limit = txtLimit.Text;
	}

	private void ccbApprovedPayment_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ApprovedPayment = ccbApprovedPayment.Checked;
		T0 val = (T0)ApprovedPayment;
		if (val != null)
		{
			ccbApprovedPayment.ForeColor = Color.Red;
		}
		else
		{
			ccbApprovedPayment.ForeColor = Color.Black;
		}
	}

	private void frmPublishCampText_FormClosing<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThread = int.Parse(((decimal)(T1)numThread.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelay = int.Parse(((decimal)(T1)numDelay.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtChangeNameAds = txtChangeNameAds.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtLimit = txtLimit.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBMID = txtBMID.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTextCamp = txtTextCamp.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTargetCamp = txtTargetCamp.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTargetAdset = txtTargetAdset.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTargetAd = txtTargetAd.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtAddress = txtAddress.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCity = txtCity.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtState = txtState.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtZip = txtZip.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCountry = txtCountry.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCurrency = txtCurrency.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtTimeZone = txtTimeZone.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCampFilter = txtCampFilter.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPayBalance = txtPayBalance.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtRemoveCardByName = txtRemoveCardByName.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].BugetCamp = txtBugetCamp.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtCardCountry = txtCardCountry.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBinGen = txtBinGen.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtNameCard = txtNameCard.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtIdPixel = txtIdPixel.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtBM_Pixel = txtBM_Pixel.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPushCardPrimary = txtPushCardPrimary.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelayApproved2 = int.Parse(((decimal)(T1)numDelayApproved2.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].cbRollingMatThread = cbRollingMatThread.Checked;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelayRemoveCard = int.Parse(((decimal)(T1)numDelayRemoveCard.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].txtPro5List = txtPro5List.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numAddActOnPage = int.Parse(((decimal)(T1)numAddActOnPage.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numDelayLifeCycle = int.Parse(((decimal)(T1)numDelayLifeCycle.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numLifeCycle = int.Parse(((decimal)(T1)numLifeCycle.Value).ToString());
		}
		frmMain.settingSaving();
	}

	private void cbCampReview_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		CampReview = cbCampReview.Checked;
		T0 val = (T0)CampReview;
		if (val != null)
		{
			cbCampReview.ForeColor = Color.Red;
		}
		else
		{
			cbCampReview.ForeColor = Color.Black;
		}
	}

	private void txtChangeNameAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strChangeNameAct = txtChangeNameAds.Text;
	}

	private void cbChangeNameAct_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		boolChangeNameAct = cbChangeNameAct.Checked;
		T0 val = (T0)boolChangeNameAct;
		if (val == null)
		{
			cbChangeNameAct.ForeColor = Color.Black;
		}
		else
		{
			cbChangeNameAct.ForeColor = Color.Red;
		}
	}

	private void cbRemveLimitInCamp_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemveLimitInCamp = cbRemveLimitInCamp.Checked;
		T0 val = (T0)RemveLimitInCamp;
		if (val != null)
		{
			cbRemveLimitInCamp.ForeColor = Color.Red;
		}
		else
		{
			cbRemveLimitInCamp.ForeColor = Color.Black;
		}
	}

	private void cbRemoveLimit_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveLimit = cbRemoveLimit.Checked;
		T0 val = (T0)RemoveLimit;
		if (val != null)
		{
			cbRemoveLimit.ForeColor = Color.Red;
		}
		else
		{
			cbRemoveLimit.ForeColor = Color.Black;
		}
	}

	private void ccbKhangTK_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		boolKhangTK = ccbKhangTK.Checked;
		T0 val = (T0)boolKhangTK;
		if (val != null)
		{
			ccbKhangTK.ForeColor = Color.Red;
		}
		else
		{
			ccbKhangTK.ForeColor = Color.Black;
		}
	}

	private void cbbKhangTK_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		intKhangTK = cbbKhangTK.SelectedIndex;
	}

	private void ccbMessageKhangTK_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		strMessageKhangTK = ccbMessageKhangTK.SelectedItem.ToString();
	}

	private void ccbMessageKhangTK_MouseUp<T0, T1>(T0 sender, T1 e)
	{
		strMessageKhangTK = ccbMessageKhangTK.Text;
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		getUserInBM<bool, List<business_users_data>.Enumerator, Dictionary<string, string>, string, Exception>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getUserInBM<T0, T1, T2, T3, T4>()
	{
		//IL_0046: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		ccbUserInBM.Items.Clear();
		users_in_bm = frm.chrome.get_user_in_bm<T2, T3, T4>((T3)BMID);
		T0 val = (T0)(users_in_bm != null && users_in_bm.data != null);
		if (val != null)
		{
			T1 enumerator = (T1)users_in_bm.data.GetEnumerator();
			try
			{
				while (((List<business_users_data>.Enumerator*)(&enumerator))->MoveNext())
				{
					business_users_data current = ((List<business_users_data>.Enumerator*)(&enumerator))->Current;
					ccbUserInBM.Items.Add(current.first_name + " " + current.last_name);
				}
			}
			finally
			{
				((IDisposable)(*(List<business_users_data>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		T0 val2 = (T0)(ccbUserInBM.Items.Count > 0);
		if (val2 != null)
		{
			ccbUserInBM.SelectedIndex = 0;
		}
	}

	private void ccbUserInBM_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		UIDVia = ccbUserInBM.SelectedIndex;
	}

	private void cbShareTKQCToVia_CheckedChanged<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShareTKQCToVia = cbShareTKQCToVia.Checked;
		T0 val = (T0)ShareTKQCToVia;
		if (val != null)
		{
			cbRemoveTKQCToVia.Checked = false;
			cbShareTKQCToVia.ForeColor = Color.Red;
			getUserInBM<T0, T3, T4, T5, T6>();
		}
		else
		{
			cbShareTKQCToVia.ForeColor = Color.Black;
		}
	}

	private void cbRemoveTKQCToVia_CheckedChanged<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveTKQCToVia = cbRemoveTKQCToVia.Checked;
		T0 val = (T0)RemoveTKQCToVia;
		if (val == null)
		{
			cbRemoveTKQCToVia.ForeColor = Color.Black;
			return;
		}
		cbShareTKQCToVia.Checked = false;
		cbRemoveTKQCToVia.ForeColor = Color.Red;
		getUserInBM<T0, T3, T4, T5, T6>();
	}

	private void ccbPushCardPrimary_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		PushCardPrimary = ccbPushCardPrimary.Checked;
		T0 val = (T0)PushCardPrimary;
		if (val == null)
		{
			ccbPushCardPrimary.ForeColor = Color.Black;
			txtPushCardPrimary.Enabled = false;
		}
		else
		{
			ccbPushCardPrimary.ForeColor = Color.Red;
			txtPushCardPrimary.Enabled = true;
		}
	}

	private void cbOffTkqc_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		OffTkqc = cbOffTkqc.Checked;
		T0 val = (T0)OffTkqc;
		if (val == null)
		{
			cbOffTkqc.ForeColor = Color.Black;
			return;
		}
		cbOnTkqc.Checked = false;
		cbOffTkqc.ForeColor = Color.Red;
	}

	private void cbOnTkqc_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		OnTkqc = cbOnTkqc.Checked;
		T0 val = (T0)OnTkqc;
		if (val == null)
		{
			cbOnTkqc.ForeColor = Color.Black;
			return;
		}
		cbOffTkqc.Checked = false;
		cbOnTkqc.ForeColor = Color.Red;
	}

	private void ccbOnOffTKQC_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		OnOffTKQC = ccbOnOffTKQC.SelectedIndex;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtTextCamp_TextChanged<T0, T1, T2, T3, T4, T5>(T4 sender, T5 e)
	{
		//IL_0023: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_004c: Expected I4, but got O
		//IL_0051: Expected O, but got I4
		//IL_0061: Expected I4, but got O
		//IL_0063: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0084: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_00e2: Expected I4, but got O
		//IL_00e8: Expected O, but got I4
		//IL_00fb: Expected I4, but got O
		//IL_00fd: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0122: Expected O, but got I4
		//IL_0151: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_0181: Expected I4, but got O
		//IL_0187: Expected O, but got I4
		//IL_019a: Expected I4, but got O
		//IL_019c: Expected O, but got I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01c1: Expected O, but got I4
		textCamp = txtTextCamp.Text;
		T0 val = (T0)textCamp.Contains("cg:");
		if (val != null)
		{
			T1 val2 = (T1)"";
			T2 val3 = (T2)textCamp.IndexOf("cg:");
			while (true)
			{
				T0 val4 = (T0)((nint)val3 < textCamp.Length);
				if (val4 == null)
				{
					break;
				}
				T0 val5 = (T0)(textCamp[(int)val3] == '\t');
				if (val5 != null)
				{
					break;
				}
				val2 = (T1)((string)val2 + System.Runtime.CompilerServices.Unsafe.As<T3, char>(ref (T3)textCamp[(int)val3]));
				val3 = (T2)(val3 + 1);
			}
			textCamp = textCamp.Replace((string)val2, "");
		}
		T0 val6 = (T0)textCamp.Contains("c:");
		if (val6 != null)
		{
			T1 val7 = (T1)"";
			T2 val8 = (T2)textCamp.IndexOf("c:");
			while (true)
			{
				T0 val9 = (T0)((nint)val8 < textCamp.Length);
				if (val9 == null)
				{
					break;
				}
				T0 val10 = (T0)(textCamp[(int)val8] == '\t');
				if (val10 != null)
				{
					break;
				}
				val7 = (T1)((string)val7 + System.Runtime.CompilerServices.Unsafe.As<T3, char>(ref (T3)textCamp[(int)val8]));
				val8 = (T2)(val8 + 1);
			}
			textCamp = textCamp.Replace((string)val7, "");
		}
		T0 val11 = (T0)textCamp.Contains("a:");
		if (val11 != null)
		{
			T1 val12 = (T1)"";
			T2 val13 = (T2)textCamp.IndexOf("a:");
			while (true)
			{
				T0 val14 = (T0)((nint)val13 < textCamp.Length);
				if (val14 == null)
				{
					break;
				}
				T0 val15 = (T0)(textCamp[(int)val13] == '\t');
				if (val15 != null)
				{
					break;
				}
				val12 = (T1)((string)val12 + System.Runtime.CompilerServices.Unsafe.As<T3, char>(ref (T3)textCamp[(int)val13]));
				val13 = (T2)(val13 + 1);
			}
			textCamp = textCamp.Replace((string)val12, "");
		}
		textCamp = HttpUtility.UrlEncode(textCamp);
	}

	private void numericUpDown1_ValueChanged<T0, T1>(T0 sender, T1 e)
	{
		BMID = txtBMID.Text;
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
	}

	private void txtTargetAds_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		TargetCamp = txtTargetCamp.Text;
	}

	private void txtTargetAdset_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		TargetAdset = txtTargetAdset.Text;
	}

	private void txtTargetContent_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		TargetAd = txtTargetAd.Text;
	}

	private void cbEditTarget_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		EditTarget = cbEditTarget.Checked;
		T0 val = (T0)EditTarget;
		if (val != null)
		{
			cbEditTarget.ForeColor = Color.Red;
		}
		else
		{
			cbEditTarget.ForeColor = Color.Black;
		}
	}

	private void txtCampFilter_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		CampFilter = txtCampFilter.Text;
	}

	private void cbChangeInfoAct_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ChangeInfoAct = cbChangeInfoAct.Checked;
		T0 val = (T0)ChangeInfoAct;
		if (val != null)
		{
			cbChangeInfoAct.ForeColor = Color.Red;
		}
		else
		{
			cbChangeInfoAct.ForeColor = Color.Black;
		}
	}

	private void txtAddress_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Address = txtAddress.Text;
	}

	private void txtCity_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		City = txtCity.Text;
	}

	private void txtState_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		State = txtState.Text;
	}

	private void txtZip_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Zip = txtZip.Text;
	}

	private void txtCountry_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Country = txtCountry.Text;
	}

	private void txtCurrency_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Currency = txtCurrency.Text;
	}

	private void txtTimeZone_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		TimeZone = txtTimeZone.Text;
	}

	private void cbRemoveCard_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveCard = cbRemoveCard.Checked;
		T0 val = (T0)RemoveCard;
		if (val == null)
		{
			cbRemoveCard.ForeColor = Color.Black;
		}
		else
		{
			cbRemoveCard.ForeColor = Color.Red;
		}
	}

	private void cbPaynow_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		PayNow = cbPaynow.Checked;
		T0 val = (T0)PayNow;
		if (val == null)
		{
			cbPaynow.ForeColor = Color.Black;
		}
		else
		{
			cbPaynow.ForeColor = Color.Red;
		}
	}

	private void cbKichNo_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		KichNo = cbKichNo.Checked;
		T0 val = (T0)KichNo;
		if (val != null)
		{
			cbKichNo.ForeColor = Color.Red;
		}
		else
		{
			cbKichNo.ForeColor = Color.Black;
		}
	}

	private void cbShareTK_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShareTK = cbShareTK.Checked;
		T0 val = (T0)ShareTK;
		if (val != null)
		{
			cbShareTK.ForeColor = Color.Red;
			txtUID_Share_Tk.Enabled = true;
		}
		else
		{
			cbShareTK.ForeColor = Color.Black;
			txtUID_Share_Tk.Enabled = false;
		}
	}

	private void txtUID_Share_Tk_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		UID_Share_Tk = txtUID_Share_Tk.Text;
	}

	private void cbTryAgainHoldMoney_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		TryAgainHoldMoney = cbTryAgainHoldMoney.Checked;
		T0 val = (T0)TryAgainHoldMoney;
		if (val == null)
		{
			cbTryAgainHoldMoney.ForeColor = Color.Black;
		}
		else
		{
			cbTryAgainHoldMoney.ForeColor = Color.Red;
		}
	}

	private void cbAddCartPrimary_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCartPrimary = cbAddCartPrimary.Checked;
		T0 val = (T0)AddCartPrimary;
		if (val != null)
		{
			cbAddCartPrimary.ForeColor = Color.Red;
		}
		else
		{
			cbAddCartPrimary.ForeColor = Color.Black;
		}
	}

	private void cbPayBalance_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		PayBalance = cbPayBalance.Checked;
		T0 val = (T0)PayBalance;
		if (val != null)
		{
			cbPayBalance.ForeColor = Color.Red;
			txtPayBalance.Enabled = true;
		}
		else
		{
			cbPayBalance.ForeColor = Color.Black;
			txtPayBalance.Enabled = false;
		}
	}

	private void txtPayBalance_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strPayBalance = txtPayBalance.Text;
	}

	private void cbRemoveCardByName_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0029: Expected O, but got I4
		RemoveCardByName = cbRemoveCardByName.Checked;
		txtRemoveCardByName.Enabled = RemoveCardByName;
		T0 val = (T0)RemoveCardByName;
		if (val != null)
		{
			cbRemoveCardByName.ForeColor = Color.Red;
		}
		else
		{
			cbRemoveCardByName.ForeColor = Color.Black;
		}
	}

	private void txtRemoveCardByName_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strRemoveCardByName = txtRemoveCardByName.Text;
	}

	private void txtBugetCamp_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BugetCamp = txtBugetCamp.Text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvCard_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			gvCard.ClearSelection();
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security + Xóa", (EventHandler)pasteCCEvent<Thread, Exception, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security", (EventHandler)pasteCCEvent<Thread, Exception, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security x10", (EventHandler)pasteCCEvent<Thread, Exception, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Number|Exp_month|Exp_year|Security x10 + Xóa", (EventHandler)pasteCCEvent<Thread, Exception, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Random sort", (EventHandler)randomSortEvent<int, T0, T3, EventArgs, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", deleteAllCCEvent);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvCard, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void randomSortEvent<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		//IL_000e: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		T0 val = (T0)rnd.Next(0, 3);
		T1 val2 = (T1)(val == null);
		if (val2 == null)
		{
			T1 val3 = (T1)((nint)val == 1);
			if (val3 == null)
			{
				T1 val4 = (T1)((nint)val == 2);
				if (val4 != null)
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.OrderByDescending((Func<CreditCardEntity, T4>)(object)(Func<CreditCardEntity, string>)((CreditCardEntity a) => (T4)a.Card_Security)).ToList();
				}
				else
				{
					frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.OrderBy((Func<CreditCardEntity, T4>)(object)(Func<CreditCardEntity, string>)((CreditCardEntity a) => (T4)a.Card_Security)).ToList();
				}
			}
			else
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.OrderByDescending((Func<CreditCardEntity, T0>)(object)(Func<CreditCardEntity, int>)((CreditCardEntity a) => (T0)a.int_random)).ToList();
			}
		}
		else
		{
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.OrderBy((Func<CreditCardEntity, T0>)(object)(Func<CreditCardEntity, int>)((CreditCardEntity a) => (T0)a.int_random)).ToList();
		}
		loadCC<T1, T0, Exception, List<CreditCardEntity>>();
	}

	private void deleteAllCCEvent<T0, T1>(T0 sender, T1 e)
	{
		try
		{
			gvCard.ClearSelection();
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.Clear();
			loadCC<bool, int, Exception, List<CreditCardEntity>>();
		}
		catch
		{
		}
	}

	private void pasteCCEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		_003C_003Ec__DisplayClass180_0 _003C_003Ec__DisplayClass180_ = new _003C_003Ec__DisplayClass180_0();
		_003C_003Ec__DisplayClass180_.sender = sender;
		_003C_003Ec__DisplayClass180_._003C_003E4__this = this;
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass180_._003CpasteCCEvent_003Eb__0<MenuItem, int, string, bool, char, T2, T1, List<CreditCardEntity>>);
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch (Exception)
		{
		}
	}

	private void loadCC<T0, T1, T2, T3>()
	{
		//IL_0034: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		try
		{
			T0 val = (T0)(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard == null);
			if (val != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard = (List<CreditCardEntity>)Activator.CreateInstance(typeof(T3));
			}
			gvCard.DataSource = null;
			gvCard.DataSource = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard;
			lbCard.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].listCard.Count).ToString();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	private void cbAddCardItem_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardItem = cbAddCardItem.Checked;
		T0 val = (T0)AddCardItem;
		if (val == null)
		{
			cbAddCardItem.ForeColor = Color.Black;
		}
		else
		{
			cbAddCardItem.ForeColor = Color.Red;
		}
	}

	private void cbAddCardItem_Primary_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardItem_Primary = cbAddCardItem_Primary.Checked;
		T0 val = (T0)AddCardItem_Primary;
		if (val != null)
		{
			cbAddCardItem_Primary.ForeColor = Color.Red;
		}
		else
		{
			cbAddCardItem_Primary.ForeColor = Color.Black;
		}
	}

	private void gvCard_MouseDoubleClick<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtCardCountry_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strCardCountry = txtCardCountry.Text;
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

	private void rbBinGen_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		blBinGen = rbBinGen.Checked;
		T0 val = (T0)blBinGen;
		if (val != null)
		{
			rbListCard.Checked = false;
			rbListCardCenter.Checked = false;
		}
	}

	private void rbListCard_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		blListCard = rbListCard.Checked;
		T0 val = (T0)blListCard;
		if (val != null)
		{
			rbBinGen.Checked = false;
			rbListCardCenter.Checked = false;
		}
	}

	private void rbListCardCenter_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0029: Expected O, but got I4
		blListCardCenter = rbListCardCenter.Checked;
		ccbListCard.Enabled = blListCardCenter;
		T0 val = (T0)blListCardCenter;
		if (val != null)
		{
			loadListCard<List<GroupCreditCard>.Enumerator, T0>();
			rbBinGen.Checked = false;
			rbListCard.Checked = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Clear", (EventHandler)clearEvent<T0, T3, EventArgs, List<adaccountsData>, int>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Json", (EventHandler)pasteJsonEvent<Thread, T3, EventArgs, T2>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Json + Xóa", (EventHandler)pasteJsonEvent<Thread, T3, EventArgs, T2>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void clearEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(ListAds == null);
		if (val != null)
		{
			ListAds = (List<adaccountsData>)Activator.CreateInstance(typeof(T3));
		}
		ListAds.Clear();
		loadData<T4>();
	}

	private void pasteJsonEvent<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		_003C_003Ec__DisplayClass199_0 _003C_003Ec__DisplayClass199_ = new _003C_003Ec__DisplayClass199_0();
		_003C_003Ec__DisplayClass199_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass199_.mi = (MenuItem)(T3)sender;
		T0 val = (T0)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass199_._003CpasteJsonEvent_003Eb__0<string, List<adaccountsData>, bool, Exception, T1, int>);
		((Thread)val).SetApartmentState(ApartmentState.STA);
		((Thread)val).Start();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rbBoostPost_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		boolBoostPost = rbBoostPost.Checked;
		T0 val = (T0)boolBoostPost;
		if (val == null)
		{
			rbBoostPost.ForeColor = Color.Black;
			T0 val2 = (T0)listTaskChecked.Contains("boolBoostPost");
			if (val2 != null)
			{
				listTaskChecked.Remove("boolBoostPost");
			}
		}
		else
		{
			rbBoostPost.ForeColor = Color.Red;
			listTaskChecked.Add("boolBoostPost");
		}
	}

	private void rbCampSuite_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		boolCampSuite = rbCampSuite.Checked;
		T0 val = (T0)boolBoostPost;
		if (val != null)
		{
			rbCampSuite.ForeColor = Color.Red;
		}
		else
		{
			rbCampSuite.ForeColor = Color.Black;
		}
	}

	private void rbBoostPost_MouseClick<T0, T1>(T0 sender, T1 e)
	{
	}

	private void rbCampSuite_MouseClick<T0, T1>(T0 sender, T1 e)
	{
	}

	private void cbAddCardItem_M_Facebook_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardItem_M_Facebook = cbAddCardItem_M_Facebook.Checked;
		T0 val = (T0)AddCardItem_M_Facebook;
		if (val == null)
		{
			cbAddCardItem_M_Facebook.ForeColor = Color.Black;
		}
		else
		{
			cbAddCardItem_M_Facebook.ForeColor = Color.Red;
		}
	}

	private void txtNameCard_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		NameCard = txtNameCard.Text;
	}

	private void tabPage2_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private void cbAddCardLink667_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		AddCardLink667 = cbAddCardLink667.Checked;
	}

	private void cbSharePixel_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SharePixel = cbSharePixel.Checked;
		T0 val = (T0)SharePixel;
		if (val != null)
		{
			cbSharePixel.ForeColor = Color.Red;
			txtIdPixel.Enabled = true;
			txtBM_Pixel.Enabled = true;
		}
		else
		{
			cbSharePixel.ForeColor = Color.Black;
			txtIdPixel.Enabled = false;
			txtBM_Pixel.Enabled = false;
		}
	}

	private void txtIdPixel_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		IdPixel = txtIdPixel.Text;
	}

	private void txtBM_Pixel_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BM_Pixel = txtBM_Pixel.Text;
	}

	private void txtPushCardPrimary_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strPushCardPrimary = txtPushCardPrimary.Text.ToLower();
	}

	private void cbAddCodeCard_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCodeCard = cbAddCodeCard.Checked;
		T0 val = (T0)AddCodeCard;
		if (val == null)
		{
			cbAddCodeCard.ForeColor = Color.Black;
		}
		else
		{
			cbAddCodeCard.ForeColor = Color.Red;
		}
	}

	private void numDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intDelay = int.Parse(((decimal)(T0)numDelay.Value).ToString());
		intDelay *= 1000;
	}

	private void cbReloadTk_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ReloadTk = cbReloadTk.Checked;
		T0 val = (T0)ReloadTk;
		if (val == null)
		{
			cbReloadTk.ForeColor = Color.Black;
		}
		else
		{
			cbReloadTk.ForeColor = Color.Red;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnGetDraftPE_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T2 sender, T3 e)
	{
		//IL_001a: Expected O, but got I4
		T0 val = (T0)(ListAds == null || ListAds.Count == 0);
		if (val == null)
		{
			T1 id = (T1)ListAds.First().id;
			T1 draft_Template = frm.chrome.getDraft_Template<T1, T0, T4, T5, T6, T7>(id);
			txtTextCamp.Text = (string)draft_Template;
		}
		else
		{
			frmMain.errorMessage((T1)"Chưa chọn TK");
		}
	}

	private void rbCreateCampPE_MouseClick<T0, T1>(T0 sender, T1 e)
	{
	}

	private void rbCreateCampPE_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		boolCreatePE = rbCreateCampPE.Checked;
		T0 val = (T0)boolCreatePE;
		if (val == null)
		{
			rbCreateCampPE.ForeColor = Color.Black;
		}
		else
		{
			rbCreateCampPE.ForeColor = Color.Red;
		}
	}

	private void cbAddBoostpost_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddBoostpost = cbAddBoostpost.Checked;
		T0 val = (T0)AddBoostpost;
		if (val == null)
		{
			cbAddBoostpost.ForeColor = Color.Black;
		}
		else
		{
			cbAddBoostpost.ForeColor = Color.Red;
		}
	}

	private void cbAddSuite_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddSuite = cbAddSuite.Checked;
		T0 val = (T0)AddSuite;
		if (val == null)
		{
			cbAddSuite.ForeColor = Color.Black;
		}
		else
		{
			cbAddSuite.ForeColor = Color.Red;
		}
	}

	private void cbAddCardLink1_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardLink1 = cbAddCardLink1.Checked;
		T0 val = (T0)AddCardLink1;
		if (val == null)
		{
			cbAddCardLink1.ForeColor = Color.Black;
		}
		else
		{
			cbAddCardLink1.ForeColor = Color.Red;
		}
	}

	private void groupBox2_Enter<T0, T1>(T0 sender, T1 e)
	{
	}

	private void cbPublishCamp_MouseClick<T0, T1>(T0 sender, T1 e)
	{
	}

	private void cbAddCardAPI_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardAPI = cbAddCardAPI.Checked;
		T0 val = (T0)AddCardAPI;
		if (val == null)
		{
			cbAddCardAPI.ForeColor = Color.Black;
		}
		else
		{
			cbAddCardAPI.ForeColor = Color.Red;
		}
	}

	private void button3_Click<T0, T1>(T0 sender, T1 e)
	{
		getGroupInBM<bool, List<business_asset_groups_data>.Enumerator, Dictionary<string, string>, string, Exception>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getGroupInBM<T0, T1, T2, T3, T4>()
	{
		//IL_0046: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		ccbGroupInBM.Items.Clear();
		asset_groups = frm.chrome.get_group_in_bm<T2, T3, T4>((T3)BMID);
		T0 val = (T0)(asset_groups != null && asset_groups.data != null);
		if (val != null)
		{
			T1 enumerator = (T1)asset_groups.data.GetEnumerator();
			try
			{
				while (((List<business_asset_groups_data>.Enumerator*)(&enumerator))->MoveNext())
				{
					business_asset_groups_data current = ((List<business_asset_groups_data>.Enumerator*)(&enumerator))->Current;
					ccbGroupInBM.Items.Add(current.id + " " + current.name);
				}
			}
			finally
			{
				((IDisposable)(*(List<business_asset_groups_data>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		T0 val2 = (T0)(ccbGroupInBM.Items.Count > 0);
		if (val2 != null)
		{
			ccbGroupInBM.SelectedIndex = 0;
		}
	}

	private void cbAddAdsToGroup_CheckedChanged<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddAdsToGroup = cbAddAdsToGroup.Checked;
		T0 val = (T0)AddAdsToGroup;
		if (val != null)
		{
			cbRemoveAdsToGroup.Checked = false;
			cbAddAdsToGroup.ForeColor = Color.Red;
			getGroupInBM<T0, T3, T4, T5, T6>();
		}
		else
		{
			cbAddAdsToGroup.ForeColor = SystemColors.Highlight;
		}
	}

	private void cbRemoveAdsToGroup_CheckedChanged<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveAdsToGroup = cbRemoveAdsToGroup.Checked;
		T0 val = (T0)RemoveAdsToGroup;
		if (val == null)
		{
			cbRemoveAdsToGroup.ForeColor = SystemColors.Highlight;
			return;
		}
		cbAddAdsToGroup.Checked = false;
		cbAddAdsToGroup.ForeColor = Color.Red;
		getGroupInBM<T0, T3, T4, T5, T6>();
	}

	private void ccbGroupInBM_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		GROUP_ID = ccbGroupInBM.SelectedIndex;
	}

	private void cbApproved2_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		boolApproved2 = cbApproved2.Checked;
	}

	private void numDelayApproved2_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intDelayApproved2 = int.Parse(((decimal)(T0)numDelayApproved2.Value).ToString());
	}

	private void cbChangePost_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ChangePost = cbChangePost.Checked;
		T0 val = (T0)ChangePost;
		if (val == null)
		{
			cbChangePost.ForeColor = Color.Black;
			ccbPageId.Enabled = false;
			ccbPostId.Enabled = false;
		}
		else
		{
			cbChangePost.ForeColor = Color.Red;
			ccbPageId.Enabled = true;
			ccbPostId.Enabled = true;
			getPageId<List<facebook_pagesData>, string, T0, List<facebook_pagesData>.Enumerator, Exception, Dictionary<string, string>>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getPageId<T0, T1, T2, T3, T4, T5>()
	{
		//IL_0059: Expected O, but got I4
		ccbPageId.Items.Clear();
		ccbPostId.Items.Clear();
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 strError = (T1)string.Empty;
		val = frm.chrome.mtLoadPage<T0, T1, T2, T4, T5>(out *(string*)(&strError));
		T2 val2 = (T2)(val != null && ((List<facebook_pagesData>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T3 enumerator = (T3)((List<facebook_pagesData>)val).GetEnumerator();
		try
		{
			while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
			{
				facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
				ccbPageId.Items.Add(current.id + "-" + current.name);
			}
		}
		finally
		{
			((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void ccbPageId_SelectedIndexChanged<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_001f: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		ccbPostId.Items.Clear();
		T0 val = (T0)(ccbPageId.SelectedItem != null);
		if (val == null)
		{
			return;
		}
		strPageId = ccbPageId.SelectedItem.ToString();
		T0 val2 = (T0)strPageId.Contains("-");
		if (val2 == null)
		{
			return;
		}
		strPageId = (string)((IEnumerable<T1>)(object)strPageId.Split((char[])(object)new T5[1] { (T5)45 })).First();
		T1 strError;
		Post post = frm.chrome.mtLoadPost<T1, T6, T7>(out *(string*)(&strError), (T1)strPageId);
		T0 val3 = (T0)(post != null && post.posts != null && post.posts != null);
		if (val3 == null)
		{
			return;
		}
		T2 enumerator = (T2)post.posts.data.GetEnumerator();
		try
		{
			while (((List<post_data>.Enumerator*)(&enumerator))->MoveNext())
			{
				post_data current = ((List<post_data>.Enumerator*)(&enumerator))->Current;
				T0 val4 = (T0)(current.message == null);
				if (val4 != null)
				{
					current.message = "";
				}
				current.id = current.id.Replace(strPageId + "_", "");
				ccbPostId.Items.Add(current.id + "-" + current.message);
			}
		}
		finally
		{
			((IDisposable)(*(List<post_data>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val5 = (T0)(ccbPostId.Items.Count > 0);
		if (val5 != null)
		{
			ccbPostId.SelectedIndex = 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ccbPostId_SelectedIndexChanged<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		T0 val = (T0)(ccbPostId.SelectedItem != null);
		if (val != null)
		{
			strPostId = ccbPostId.SelectedItem.ToString();
			T0 val2 = (T0)strPostId.Contains("-");
			if (val2 != null)
			{
				strPostId = (string)((IEnumerable<T4>)(object)strPostId.Split((char[])(object)new T3[1] { (T3)45 })).First();
			}
		}
	}

	private void cbChangeBugetCamp_CheckedChanged_1<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ChangeBugetCamp = cbChangeBugetCamp.Checked;
		T0 val = (T0)ChangeBugetCamp;
		if (val != null)
		{
			cbChangeBugetCamp.ForeColor = Color.Red;
		}
		else
		{
			cbChangeBugetCamp.ForeColor = Color.Black;
		}
	}

	private void cbChangeBugetGruopAds_CheckedChanged_1<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ChangeBugetGruopAds = cbChangeBugetGruopAds.Checked;
		T0 val = (T0)ChangeBugetGruopAds;
		if (val == null)
		{
			cbChangeBugetGruopAds.ForeColor = Color.Black;
		}
		else
		{
			cbChangeBugetGruopAds.ForeColor = Color.Red;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button4_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T2 sender, T3 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		T0 val = (T0)(ListAds == null || ListAds.Count == 0);
		if (val != null)
		{
			frmMain.errorMessage((T1)"Chưa chọn TK");
			return;
		}
		txtTargetCamp.Text = "";
		txtTargetAdset.Text = "";
		txtTargetAd.Text = "";
		TargetCamp = "";
		TargetAdset = "";
		TargetAd = "";
		T1 id = (T1)ListAds.First().id;
		T1 Camp = (T1)"";
		T1 Adset = (T1)"";
		T1 Ad = (T1)"";
		T1 message = (T1)"";
		T0 draft_Edit_Target = frm.chrome.getDraft_Edit_Target<T0, T1, T4, T5, T6, T7>(id, out *(string*)(&Camp), out *(string*)(&Adset), out *(string*)(&Ad), out *(string*)(&message));
		T0 val2 = draft_Edit_Target;
		if (val2 != null)
		{
			T0 val3 = (T0)(!string.IsNullOrWhiteSpace((string)Camp));
			if (val3 != null)
			{
				txtTargetCamp.Text = (string)Camp;
			}
			T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)Adset));
			if (val4 != null)
			{
				txtTargetAdset.Text = (string)Adset;
			}
			T0 val5 = (T0)(!string.IsNullOrWhiteSpace((string)Ad));
			if (val5 != null)
			{
				txtTargetAd.Text = (string)Ad;
			}
		}
		else
		{
			frmMain.errorMessage(message);
		}
	}

	private void cbRollingMatThread_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RollingMatThread = cbRollingMatThread.Checked;
		T0 val = (T0)RollingMatThread;
		if (val == null)
		{
			cbRollingMatThread.ForeColor = Color.Black;
			cbPublishCamp.Checked = false;
			cbPublishGroup.Checked = false;
			cbPublishAds.Checked = false;
			cbRemoveCard.Checked = false;
		}
		else
		{
			cbRollingMatThread.ForeColor = Color.Red;
			cbPublishCamp.Checked = true;
			cbPublishGroup.Checked = true;
			cbPublishAds.Checked = true;
			cbRemoveCard.Checked = true;
		}
	}

	private void cbAddCardRequest_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardRequest = cbAddCardRequest.Checked;
		T0 val = (T0)AddCardRequest;
		if (val != null)
		{
			cbAddCardRequest.ForeColor = Color.Red;
		}
		else
		{
			cbAddCardRequest.ForeColor = Color.Black;
		}
	}

	private void numDelayRemoveCard_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		DelayRemoveCard = int.Parse(((decimal)(T0)numDelayRemoveCard.Value).ToString());
		DelayRemoveCard *= 1000;
	}

	private void cbRemoveCamp_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		RemoveCamp = cbRemoveCamp.Checked;
		T0 val = (T0)RemoveCamp;
		if (val != null)
		{
			cbRemoveCamp.ForeColor = Color.Red;
		}
		else
		{
			cbRemoveCamp.ForeColor = Color.Black;
		}
	}

	private void cbAddCardByPage_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCardByPage = cbAddCardByPage.Checked;
		T0 val = (T0)AddCardByPage;
		if (val != null)
		{
			cbAddCardByPage.ForeColor = Color.Red;
		}
		else
		{
			cbAddCardByPage.ForeColor = Color.Black;
		}
	}

	private unsafe void loadListCard<T0, T1>()
	{
		//IL_007a: Expected O, but got I4
		ccbListCard.Items.Clear();
		T0 enumerator = (T0)frmMain.groupCreditCard.GetEnumerator();
		try
		{
			while (((List<GroupCreditCard>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupCreditCard current = ((List<GroupCreditCard>.Enumerator*)(&enumerator))->Current;
				ccbListCard.Items.Add(current.Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupCreditCard>.Enumerator*)(&enumerator))).Dispose();
		}
		T1 val = (T1)(ccbListCard.Items != null && ccbListCard.Items.Count > 0);
		if (val != null)
		{
			ccbListCard.SelectedIndex = 0;
		}
	}

	private void ccbListCard_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		ListCardCenter = ccbListCard.SelectedItem.ToString();
	}

	private void txtPro5List_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		Pro5List = txtPro5List.Text;
	}

	private void numAddActOnPage_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		AddActOnPage = int.Parse(((decimal)(T0)numAddActOnPage.Value).ToString());
	}

	private void cbAddCartMFacebook2_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		AddCartMFacebook2 = cbAddCartMFacebook2.Checked;
		T0 val = (T0)AddCartMFacebook2;
		if (val == null)
		{
			cbAddCartMFacebook2.ForeColor = Color.Black;
		}
		else
		{
			cbAddCartMFacebook2.ForeColor = Color.Red;
		}
	}

	private void cbCardVerify_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		CardVerify = cbCardVerify.Checked;
		T0 val = (T0)CardVerify;
		if (val == null)
		{
			cbCardVerify.ForeColor = Color.Black;
		}
		else
		{
			cbCardVerify.ForeColor = Color.Red;
		}
	}

	private void numDelayLifeCycle_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		DelayLifeCycle = int.Parse(((decimal)(T0)numDelayLifeCycle.Value).ToString());
	}

	private void numLifeCycle_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		LifeCycle = int.Parse(((decimal)(T0)numLifeCycle.Value).ToString());
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmPublishCampText));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.cbImportCamp = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbQuantity = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel2 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbActive = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel4 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbDie = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel6 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbUnsettled = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel8 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbReview = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel10 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbGracePeriod = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel12 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTemporarityUnavable = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel14 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbPendingCloure = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.txtTextCamp = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbPublishCamp = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbPublishGroup = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbPublishAds = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbClearAddraft = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbResetLimit = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbRemoveActInBM = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBMID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.ccbAddCart = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbSetLimit = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtLimit = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.ccbApprovedPayment = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbCampReview = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtChangeNameAds = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbChangeNameAct = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbRemveLimitInCamp = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbRemoveLimit = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbKhangTK = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbbKhangTK = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.ccbMessageKhangTK = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.groupRollingMat = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.numDelayRemoveCard = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label17 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbRollingMatThread = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.groupBox2 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.rbCreateCampPE = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.rbCampSuite = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.rbBoostPost = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.groupBox3 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.cbCardVerify = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbReloadTk = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtPushCardPrimary = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbAddCartPrimary = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtRemoveCardByName = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbRemoveCardByName = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtPayBalance = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbPayBalance = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbTryAgainHoldMoney = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtUID_Share_Tk = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbShareTK = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbKichNo = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbPaynow = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbRemoveCard = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbPushCardPrimary = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.tabControl = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabCookie = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.groupBox9 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.label10 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtTimeZone = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label9 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCurrency = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label8 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCountry = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label7 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtState = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label6 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtZip = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCity = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtAddress = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbChangeInfoAct = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.tabToken = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.groupBox10 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.cbRemoveAdsToGroup = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbGroupInBM = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.cbAddAdsToGroup = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.groupBox4 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.cbRemoveTKQCToVia = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbUserInBM = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.cbShareTKQCToVia = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.tabPage1 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.cbRemoveCamp = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbOnOffTKQC = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.cbOnTkqc = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.button4 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.cbOffTkqc = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label16 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label15 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.ccbPostId = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.ccbPageId = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.cbChangePost = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtBugetCamp = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbChangeBugetGruopAds = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbChangeBugetCamp = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCampFilter = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbEditTarget = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.splitContainer2 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.groupBox6 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.txtTargetCamp = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.groupBox7 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.txtTargetAdset = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.groupBox8 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.txtTargetAd = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.tabPage2 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.cbAddCartMFacebook2 = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.ccbListCard = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.rbListCardCenter = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.plAddByPro5 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.numAddActOnPage = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label18 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtPro5List = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbAddCardByPage = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddCardRequest = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbApproved2 = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.numDelayApproved2 = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.cbAddCardAPI = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddCardLink1 = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddSuite = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddBoostpost = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddCodeCard = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddCardLink667 = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtNameCard = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label12 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbAddCardItem_M_Facebook = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.lbTotalBinGen = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.rbListCard = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbBinGen = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.txtAddCard_Log = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtBinGen = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtCardCountry = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label11 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbCard = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.gvCard = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.cbAddCardItem = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbAddCardItem_Primary = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.splitContainer3 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.btnGetDraftPE = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.txtIdPixel = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbSharePixel = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label13 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBM_Pixel = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.numDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label14 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numLifeCycle = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label20 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelayLifeCycle = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label21 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label22 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.splitContainer4 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		this.statusStrip1.SuspendLayout();
		this.groupRollingMat.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelayRemoveCard).BeginInit();
		this.groupBox2.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.tabControl.SuspendLayout();
		this.tabCookie.SuspendLayout();
		this.groupBox9.SuspendLayout();
		this.tabToken.SuspendLayout();
		this.groupBox10.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.tabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer2).BeginInit();
		this.splitContainer2.Panel1.SuspendLayout();
		this.splitContainer2.Panel2.SuspendLayout();
		this.splitContainer2.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox7.SuspendLayout();
		this.groupBox8.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.plAddByPro5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numAddActOnPage).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayApproved2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gvCard).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer3).BeginInit();
		this.splitContainer3.Panel1.SuspendLayout();
		this.splitContainer3.Panel2.SuspendLayout();
		this.splitContainer3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numLifeCycle).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayLifeCycle).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer4).BeginInit();
		this.splitContainer4.Panel1.SuspendLayout();
		this.splitContainer4.Panel2.SuspendLayout();
		this.splitContainer4.SuspendLayout();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AllowUserToOrderColumns = true;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gvData.Location = new System.Drawing.Point(0, 0);
		this.gvData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.gvData.Name = "gvData";
		this.gvData.RowHeadersWidth = 51;
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(608, 944);
		this.gvData.TabIndex = 4;
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T17, T18, T19, T20, T21>);
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.DodgerBlue;
		this.button1.Location = new System.Drawing.Point(632, 835);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 87);
		this.button1.TabIndex = 7;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click<T17, T20, T22>);
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer_auto_refesh_Tick<T17, T20, T22>);
		this.cbImportCamp.AutoSize = true;
		this.cbImportCamp.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbImportCamp.Location = new System.Drawing.Point(199, 52);
		this.cbImportCamp.Margin = new System.Windows.Forms.Padding(4);
		this.cbImportCamp.Name = "cbImportCamp";
		this.cbImportCamp.Size = new System.Drawing.Size(105, 20);
		this.cbImportCamp.TabIndex = 9;
		this.cbImportCamp.Text = "Nhập File PE";
		this.cbImportCamp.UseVisualStyleBackColor = true;
		this.cbImportCamp.CheckedChanged += new System.EventHandler(cbImportCamp_CheckedChanged<T17, T20, T22>);
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T23[16]
		{
			(T23)this.toolStripStatusLabel1,
			(T23)this.lbQuantity,
			(T23)this.toolStripStatusLabel2,
			(T23)this.lbActive,
			(T23)this.toolStripStatusLabel4,
			(T23)this.lbDie,
			(T23)this.toolStripStatusLabel6,
			(T23)this.lbUnsettled,
			(T23)this.toolStripStatusLabel8,
			(T23)this.lbReview,
			(T23)this.toolStripStatusLabel10,
			(T23)this.lbGracePeriod,
			(T23)this.toolStripStatusLabel12,
			(T23)this.lbTemporarityUnavable,
			(T23)this.toolStripStatusLabel14,
			(T23)this.lbPendingCloure
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 944);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
		this.statusStrip1.Size = new System.Drawing.Size(1348, 22);
		this.statusStrip1.TabIndex = 10;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 17);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbQuantity.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbQuantity.Name = "lbQuantity";
		this.lbQuantity.Size = new System.Drawing.Size(14, 17);
		this.lbQuantity.Text = "0";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 17);
		this.toolStripStatusLabel2.Text = "Hoạt động:";
		this.lbActive.Name = "lbActive";
		this.lbActive.Size = new System.Drawing.Size(13, 17);
		this.lbActive.Text = "0";
		this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
		this.toolStripStatusLabel4.Size = new System.Drawing.Size(27, 17);
		this.toolStripStatusLabel4.Text = "Die:";
		this.lbDie.Name = "lbDie";
		this.lbDie.Size = new System.Drawing.Size(13, 17);
		this.lbDie.Text = "0";
		this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
		this.toolStripStatusLabel6.Size = new System.Drawing.Size(26, 17);
		this.toolStripStatusLabel6.Text = "Nợ:";
		this.lbUnsettled.Name = "lbUnsettled";
		this.lbUnsettled.Size = new System.Drawing.Size(13, 17);
		this.lbUnsettled.Text = "0";
		this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
		this.toolStripStatusLabel8.Size = new System.Drawing.Size(47, 17);
		this.toolStripStatusLabel8.Text = "Review:";
		this.lbReview.Name = "lbReview";
		this.lbReview.Size = new System.Drawing.Size(13, 17);
		this.lbReview.Text = "0";
		this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
		this.toolStripStatusLabel10.Size = new System.Drawing.Size(48, 17);
		this.toolStripStatusLabel10.Text = "Ân hạn:";
		this.lbGracePeriod.Name = "lbGracePeriod";
		this.lbGracePeriod.Size = new System.Drawing.Size(13, 17);
		this.lbGracePeriod.Text = "0";
		this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
		this.toolStripStatusLabel12.Size = new System.Drawing.Size(62, 17);
		this.toolStripStatusLabel12.Text = "Tạm khóa:";
		this.lbTemporarityUnavable.Name = "lbTemporarityUnavable";
		this.lbTemporarityUnavable.Size = new System.Drawing.Size(13, 17);
		this.lbTemporarityUnavable.Text = "0";
		this.toolStripStatusLabel14.Name = "toolStripStatusLabel14";
		this.toolStripStatusLabel14.Size = new System.Drawing.Size(67, 17);
		this.toolStripStatusLabel14.Text = "Đang khóa:";
		this.lbPendingCloure.Name = "lbPendingCloure";
		this.lbPendingCloure.Size = new System.Drawing.Size(13, 17);
		this.lbPendingCloure.Text = "0";
		this.txtTextCamp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtTextCamp.Location = new System.Drawing.Point(4, 37);
		this.txtTextCamp.Margin = new System.Windows.Forms.Padding(4);
		this.txtTextCamp.MaxLength = 999999999;
		this.txtTextCamp.Multiline = true;
		this.txtTextCamp.Name = "txtTextCamp";
		this.txtTextCamp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtTextCamp.Size = new System.Drawing.Size(717, 127);
		this.txtTextCamp.TabIndex = 5;
		this.txtTextCamp.TextChanged += new System.EventHandler(txtTextCamp_TextChanged<T17, T24, T25, T26, T20, T22>);
		this.cbPublishCamp.AutoSize = true;
		this.cbPublishCamp.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbPublishCamp.Location = new System.Drawing.Point(9, 80);
		this.cbPublishCamp.Margin = new System.Windows.Forms.Padding(4);
		this.cbPublishCamp.Name = "cbPublishCamp";
		this.cbPublishCamp.Size = new System.Drawing.Size(121, 20);
		this.cbPublishCamp.TabIndex = 11;
		this.cbPublishCamp.Text = "Đăng chiến dịch";
		this.cbPublishCamp.UseVisualStyleBackColor = true;
		this.cbPublishCamp.CheckedChanged += new System.EventHandler(cbPublishCamp_CheckedChanged<T17, T20, T22>);
		this.cbPublishCamp.MouseClick += new System.Windows.Forms.MouseEventHandler(cbPublishCamp_MouseClick);
		this.cbPublishGroup.AutoSize = true;
		this.cbPublishGroup.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbPublishGroup.Location = new System.Drawing.Point(156, 80);
		this.cbPublishGroup.Margin = new System.Windows.Forms.Padding(4);
		this.cbPublishGroup.Name = "cbPublishGroup";
		this.cbPublishGroup.Size = new System.Drawing.Size(94, 20);
		this.cbPublishGroup.TabIndex = 12;
		this.cbPublishGroup.Text = "Đăng nhóm";
		this.cbPublishGroup.UseVisualStyleBackColor = true;
		this.cbPublishGroup.CheckedChanged += new System.EventHandler(cbPublishGroup_CheckedChanged<T17, T20, T22>);
		this.cbPublishAds.AutoSize = true;
		this.cbPublishAds.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbPublishAds.Location = new System.Drawing.Point(272, 80);
		this.cbPublishAds.Margin = new System.Windows.Forms.Padding(4);
		this.cbPublishAds.Name = "cbPublishAds";
		this.cbPublishAds.Size = new System.Drawing.Size(80, 20);
		this.cbPublishAds.TabIndex = 13;
		this.cbPublishAds.Text = "Đăng QC";
		this.cbPublishAds.UseVisualStyleBackColor = true;
		this.cbPublishAds.CheckedChanged += new System.EventHandler(cbPublishAds_CheckedChanged<T17, T20, T22>);
		this.cbClearAddraft.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbClearAddraft.AutoSize = true;
		this.cbClearAddraft.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbClearAddraft.Location = new System.Drawing.Point(499, 81);
		this.cbClearAddraft.Margin = new System.Windows.Forms.Padding(4);
		this.cbClearAddraft.Name = "cbClearAddraft";
		this.cbClearAddraft.Size = new System.Drawing.Size(109, 20);
		this.cbClearAddraft.TabIndex = 14;
		this.cbClearAddraft.Text = "Xóa bản nháp";
		this.cbClearAddraft.UseVisualStyleBackColor = true;
		this.cbClearAddraft.CheckedChanged += new System.EventHandler(cbClearAddraft_CheckedChanged<T17, T20, T22>);
		this.cbResetLimit.AutoSize = true;
		this.cbResetLimit.Location = new System.Drawing.Point(9, 23);
		this.cbResetLimit.Margin = new System.Windows.Forms.Padding(4);
		this.cbResetLimit.Name = "cbResetLimit";
		this.cbResetLimit.Size = new System.Drawing.Size(88, 20);
		this.cbResetLimit.TabIndex = 15;
		this.cbResetLimit.Text = "Reset limit";
		this.cbResetLimit.UseVisualStyleBackColor = true;
		this.cbResetLimit.CheckedChanged += new System.EventHandler(cbResetLimit_CheckedChanged<T17, T20, T22>);
		this.cbRemoveActInBM.AutoSize = true;
		this.cbRemoveActInBM.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbRemoveActInBM.Location = new System.Drawing.Point(413, 110);
		this.cbRemoveActInBM.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveActInBM.Name = "cbRemoveActInBM";
		this.cbRemoveActInBM.Size = new System.Drawing.Size(121, 20);
		this.cbRemoveActInBM.TabIndex = 16;
		this.cbRemoveActInBM.Text = "Xóa TK khỏi BM";
		this.cbRemoveActInBM.UseVisualStyleBackColor = true;
		this.cbRemoveActInBM.CheckedChanged += new System.EventHandler(cbRemoveActInBM_CheckedChanged<T17, T20, T22>);
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(308, 847);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(46, 16);
		this.label1.TabIndex = 17;
		this.label1.Text = "BM ID:";
		this.txtBMID.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtBMID.Location = new System.Drawing.Point(356, 844);
		this.txtBMID.Margin = new System.Windows.Forms.Padding(4);
		this.txtBMID.Name = "txtBMID";
		this.txtBMID.Size = new System.Drawing.Size(228, 22);
		this.txtBMID.TabIndex = 18;
		this.txtBMID.TextChanged += new System.EventHandler(txtBMID_TextChanged);
		this.ccbAddCart.AutoSize = true;
		this.ccbAddCart.Location = new System.Drawing.Point(171, 138);
		this.ccbAddCart.Margin = new System.Windows.Forms.Padding(4);
		this.ccbAddCart.Name = "ccbAddCart";
		this.ccbAddCart.Size = new System.Drawing.Size(72, 20);
		this.ccbAddCart.TabIndex = 19;
		this.ccbAddCart.Text = "Add thẻ";
		this.ccbAddCart.UseVisualStyleBackColor = true;
		this.ccbAddCart.CheckedChanged += new System.EventHandler(ccbAddCart_CheckedChanged<T17, T20, T22>);
		this.cbSetLimit.AutoSize = true;
		this.cbSetLimit.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbSetLimit.Location = new System.Drawing.Point(339, 52);
		this.cbSetLimit.Margin = new System.Windows.Forms.Padding(4);
		this.cbSetLimit.Name = "cbSetLimit";
		this.cbSetLimit.Size = new System.Drawing.Size(75, 20);
		this.cbSetLimit.TabIndex = 20;
		this.cbSetLimit.Text = "Set limit:";
		this.cbSetLimit.UseVisualStyleBackColor = true;
		this.cbSetLimit.CheckedChanged += new System.EventHandler(cbSetLimit_CheckedChanged<T17, T20, T22>);
		this.txtLimit.Location = new System.Drawing.Point(433, 49);
		this.txtLimit.Margin = new System.Windows.Forms.Padding(4);
		this.txtLimit.Name = "txtLimit";
		this.txtLimit.Size = new System.Drawing.Size(63, 22);
		this.txtLimit.TabIndex = 21;
		this.txtLimit.Text = "0";
		this.txtLimit.TextChanged += new System.EventHandler(txtLimit_TextChanged);
		this.ccbApprovedPayment.AutoSize = true;
		this.ccbApprovedPayment.ForeColor = System.Drawing.SystemColors.Highlight;
		this.ccbApprovedPayment.Location = new System.Drawing.Point(177, 52);
		this.ccbApprovedPayment.Margin = new System.Windows.Forms.Padding(4);
		this.ccbApprovedPayment.Name = "ccbApprovedPayment";
		this.ccbApprovedPayment.Size = new System.Drawing.Size(115, 20);
		this.ccbApprovedPayment.TabIndex = 22;
		this.ccbApprovedPayment.Text = "Approved hold";
		this.ccbApprovedPayment.UseVisualStyleBackColor = true;
		this.ccbApprovedPayment.CheckedChanged += new System.EventHandler(ccbApprovedPayment_CheckedChanged<T17, T20, T22>);
		this.cbCampReview.AutoSize = true;
		this.cbCampReview.Location = new System.Drawing.Point(9, 52);
		this.cbCampReview.Margin = new System.Windows.Forms.Padding(4);
		this.cbCampReview.Name = "cbCampReview";
		this.cbCampReview.Size = new System.Drawing.Size(143, 20);
		this.cbCampReview.TabIndex = 23;
		this.cbCampReview.Text = "Kháng camp review";
		this.cbCampReview.UseVisualStyleBackColor = true;
		this.cbCampReview.CheckedChanged += new System.EventHandler(cbCampReview_CheckedChanged<T17, T20, T22>);
		this.txtChangeNameAds.Location = new System.Drawing.Point(116, 80);
		this.txtChangeNameAds.Margin = new System.Windows.Forms.Padding(4);
		this.txtChangeNameAds.Name = "txtChangeNameAds";
		this.txtChangeNameAds.Size = new System.Drawing.Size(192, 22);
		this.txtChangeNameAds.TabIndex = 25;
		this.txtChangeNameAds.TextChanged += new System.EventHandler(txtChangeNameAds_TextChanged);
		this.cbChangeNameAct.AutoSize = true;
		this.cbChangeNameAct.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbChangeNameAct.Location = new System.Drawing.Point(9, 81);
		this.cbChangeNameAct.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangeNameAct.Name = "cbChangeNameAct";
		this.cbChangeNameAct.Size = new System.Drawing.Size(90, 20);
		this.cbChangeNameAct.TabIndex = 24;
		this.cbChangeNameAct.Text = "Đổi tên TK:";
		this.cbChangeNameAct.UseVisualStyleBackColor = true;
		this.cbChangeNameAct.CheckedChanged += new System.EventHandler(cbChangeNameAct_CheckedChanged<T17, T20, T22>);
		this.cbRemveLimitInCamp.AutoSize = true;
		this.cbRemveLimitInCamp.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbRemveLimitInCamp.Location = new System.Drawing.Point(211, 23);
		this.cbRemveLimitInCamp.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemveLimitInCamp.Name = "cbRemveLimitInCamp";
		this.cbRemveLimitInCamp.Size = new System.Drawing.Size(148, 20);
		this.cbRemveLimitInCamp.TabIndex = 26;
		this.cbRemveLimitInCamp.Text = "Xóa limit trong Camp";
		this.cbRemveLimitInCamp.UseVisualStyleBackColor = true;
		this.cbRemveLimitInCamp.CheckedChanged += new System.EventHandler(cbRemveLimitInCamp_CheckedChanged<T17, T20, T22>);
		this.cbRemoveLimit.AutoSize = true;
		this.cbRemoveLimit.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbRemoveLimit.Location = new System.Drawing.Point(116, 23);
		this.cbRemoveLimit.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveLimit.Name = "cbRemoveLimit";
		this.cbRemoveLimit.Size = new System.Drawing.Size(76, 20);
		this.cbRemoveLimit.TabIndex = 27;
		this.cbRemoveLimit.Text = "Xóa limit";
		this.cbRemoveLimit.UseVisualStyleBackColor = true;
		this.cbRemoveLimit.CheckedChanged += new System.EventHandler(cbRemoveLimit_CheckedChanged<T17, T20, T22>);
		this.ccbKhangTK.AutoSize = true;
		this.ccbKhangTK.Location = new System.Drawing.Point(9, 194);
		this.ccbKhangTK.Margin = new System.Windows.Forms.Padding(4);
		this.ccbKhangTK.Name = "ccbKhangTK";
		this.ccbKhangTK.Size = new System.Drawing.Size(87, 20);
		this.ccbKhangTK.TabIndex = 28;
		this.ccbKhangTK.Text = "Kháng TK:";
		this.ccbKhangTK.UseVisualStyleBackColor = true;
		this.ccbKhangTK.CheckedChanged += new System.EventHandler(ccbKhangTK_CheckedChanged<T17, T20, T22>);
		this.cbbKhangTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbbKhangTK.FormattingEnabled = true;
		this.cbbKhangTK.Items.AddRange((object[])(object)new T20[4]
		{
			(T20)"Kháng 1",
			(T20)"Kháng 792",
			(T20)"273=>Via cầm TK",
			(T20)"273=>Via không cầm TK"
		});
		this.cbbKhangTK.Location = new System.Drawing.Point(115, 192);
		this.cbbKhangTK.Margin = new System.Windows.Forms.Padding(4);
		this.cbbKhangTK.Name = "cbbKhangTK";
		this.cbbKhangTK.Size = new System.Drawing.Size(139, 24);
		this.cbbKhangTK.TabIndex = 29;
		this.cbbKhangTK.SelectedIndexChanged += new System.EventHandler(cbbKhangTK_SelectedIndexChanged);
		this.ccbMessageKhangTK.FormattingEnabled = true;
		this.ccbMessageKhangTK.Items.AddRange((object[])(object)new T20[2]
		{
			(T20)"I'm not sure which policy was violated.",
			(T20)"I think there was unauthorized use of my Ad account."
		});
		this.ccbMessageKhangTK.Location = new System.Drawing.Point(263, 190);
		this.ccbMessageKhangTK.Margin = new System.Windows.Forms.Padding(4);
		this.ccbMessageKhangTK.Name = "ccbMessageKhangTK";
		this.ccbMessageKhangTK.Size = new System.Drawing.Size(349, 24);
		this.ccbMessageKhangTK.TabIndex = 30;
		this.ccbMessageKhangTK.SelectedIndexChanged += new System.EventHandler(ccbMessageKhangTK_SelectedIndexChanged);
		this.ccbMessageKhangTK.MouseUp += new System.Windows.Forms.MouseEventHandler(ccbMessageKhangTK_MouseUp);
		this.groupRollingMat.Controls.Add(this.numDelayRemoveCard);
		this.groupRollingMat.Controls.Add(this.label17);
		this.groupRollingMat.Controls.Add(this.cbRollingMatThread);
		this.groupRollingMat.Location = new System.Drawing.Point(13, 494);
		this.groupRollingMat.Margin = new System.Windows.Forms.Padding(4);
		this.groupRollingMat.Name = "groupRollingMat";
		this.groupRollingMat.Padding = new System.Windows.Forms.Padding(4);
		this.groupRollingMat.Size = new System.Drawing.Size(689, 80);
		this.groupRollingMat.TabIndex = 31;
		this.groupRollingMat.TabStop = false;
		this.groupRollingMat.Visible = false;
		this.numDelayRemoveCard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numDelayRemoveCard.Location = new System.Drawing.Point(271, 22);
		this.numDelayRemoveCard.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayRemoveCard.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)99999999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numDelayRemoveCard.Name = "numDelayRemoveCard";
		this.numDelayRemoveCard.Size = new System.Drawing.Size(77, 22);
		this.numDelayRemoveCard.TabIndex = 50;
		this.numDelayRemoveCard.Value = new decimal((int[])(object)new T25[4]
		{
			(T25)1,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numDelayRemoveCard.ValueChanged += new System.EventHandler(numDelayRemoveCard_ValueChanged<T27, T20, T22>);
		this.label17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label17.AutoSize = true;
		this.label17.Location = new System.Drawing.Point(172, 25);
		this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(92, 16);
		this.label17.TabIndex = 49;
		this.label17.Text = "Delay xóa thẻ:";
		this.cbRollingMatThread.AutoSize = true;
		this.cbRollingMatThread.Location = new System.Drawing.Point(9, 23);
		this.cbRollingMatThread.Margin = new System.Windows.Forms.Padding(4);
		this.cbRollingMatThread.Name = "cbRollingMatThread";
		this.cbRollingMatThread.Size = new System.Drawing.Size(91, 20);
		this.cbRollingMatThread.TabIndex = 34;
		this.cbRollingMatThread.Text = "Tút xóa thẻ";
		this.cbRollingMatThread.UseVisualStyleBackColor = true;
		this.cbRollingMatThread.CheckedChanged += new System.EventHandler(cbRollingMatThread_CheckedChanged<T17, T20, T22>);
		this.groupBox2.Controls.Add(this.rbCreateCampPE);
		this.groupBox2.Controls.Add(this.cbImportCamp);
		this.groupBox2.Controls.Add(this.rbCampSuite);
		this.groupBox2.Controls.Add(this.rbBoostPost);
		this.groupBox2.Controls.Add(this.cbPublishCamp);
		this.groupBox2.Controls.Add(this.cbPublishGroup);
		this.groupBox2.Controls.Add(this.cbPublishAds);
		this.groupBox2.Controls.Add(this.cbClearAddraft);
		this.groupBox2.Location = new System.Drawing.Point(13, 7);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox2.Size = new System.Drawing.Size(688, 111);
		this.groupBox2.TabIndex = 32;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Quảng cáo";
		this.groupBox2.Enter += new System.EventHandler(groupBox2_Enter);
		this.rbCreateCampPE.AutoSize = true;
		this.rbCreateCampPE.ForeColor = System.Drawing.SystemColors.Highlight;
		this.rbCreateCampPE.Location = new System.Drawing.Point(9, 52);
		this.rbCreateCampPE.Margin = new System.Windows.Forms.Padding(4);
		this.rbCreateCampPE.Name = "rbCreateCampPE";
		this.rbCreateCampPE.Size = new System.Drawing.Size(108, 20);
		this.rbCreateCampPE.TabIndex = 15;
		this.rbCreateCampPE.Text = "Tạo Nháp PE";
		this.rbCreateCampPE.UseVisualStyleBackColor = true;
		this.rbCreateCampPE.CheckedChanged += new System.EventHandler(rbCreateCampPE_CheckedChanged<T17, T20, T22>);
		this.rbCreateCampPE.MouseClick += new System.Windows.Forms.MouseEventHandler(rbCreateCampPE_MouseClick);
		this.rbCampSuite.AutoSize = true;
		this.rbCampSuite.ForeColor = System.Drawing.SystemColors.Highlight;
		this.rbCampSuite.Location = new System.Drawing.Point(199, 23);
		this.rbCampSuite.Margin = new System.Windows.Forms.Padding(4);
		this.rbCampSuite.Name = "rbCampSuite";
		this.rbCampSuite.Size = new System.Drawing.Size(130, 20);
		this.rbCampSuite.TabIndex = 7;
		this.rbCampSuite.Text = "Đăng Camp Suite";
		this.rbCampSuite.UseVisualStyleBackColor = true;
		this.rbCampSuite.CheckedChanged += new System.EventHandler(rbCampSuite_CheckedChanged<T17, T20, T22>);
		this.rbCampSuite.MouseClick += new System.Windows.Forms.MouseEventHandler(rbCampSuite_MouseClick);
		this.rbBoostPost.AutoSize = true;
		this.rbBoostPost.ForeColor = System.Drawing.SystemColors.Highlight;
		this.rbBoostPost.Location = new System.Drawing.Point(9, 23);
		this.rbBoostPost.Margin = new System.Windows.Forms.Padding(4);
		this.rbBoostPost.Name = "rbBoostPost";
		this.rbBoostPost.Size = new System.Drawing.Size(165, 20);
		this.rbBoostPost.TabIndex = 6;
		this.rbBoostPost.Text = "Đăng Camp Boost Post";
		this.rbBoostPost.UseVisualStyleBackColor = true;
		this.rbBoostPost.CheckedChanged += new System.EventHandler(rbBoostPost_CheckedChanged<T17, T20, T22>);
		this.rbBoostPost.MouseClick += new System.Windows.Forms.MouseEventHandler(rbBoostPost_MouseClick);
		this.groupBox3.Controls.Add(this.cbCardVerify);
		this.groupBox3.Controls.Add(this.ccbMessageKhangTK);
		this.groupBox3.Controls.Add(this.cbbKhangTK);
		this.groupBox3.Controls.Add(this.cbReloadTk);
		this.groupBox3.Controls.Add(this.txtPushCardPrimary);
		this.groupBox3.Controls.Add(this.ccbKhangTK);
		this.groupBox3.Controls.Add(this.ccbAddCart);
		this.groupBox3.Controls.Add(this.cbAddCartPrimary);
		this.groupBox3.Controls.Add(this.txtRemoveCardByName);
		this.groupBox3.Controls.Add(this.cbRemoveCardByName);
		this.groupBox3.Controls.Add(this.txtPayBalance);
		this.groupBox3.Controls.Add(this.cbPayBalance);
		this.groupBox3.Controls.Add(this.cbTryAgainHoldMoney);
		this.groupBox3.Controls.Add(this.txtUID_Share_Tk);
		this.groupBox3.Controls.Add(this.cbShareTK);
		this.groupBox3.Controls.Add(this.cbKichNo);
		this.groupBox3.Controls.Add(this.cbPaynow);
		this.groupBox3.Controls.Add(this.cbRemoveCard);
		this.groupBox3.Controls.Add(this.ccbPushCardPrimary);
		this.groupBox3.Controls.Add(this.cbResetLimit);
		this.groupBox3.Controls.Add(this.cbRemoveLimit);
		this.groupBox3.Controls.Add(this.cbRemveLimitInCamp);
		this.groupBox3.Controls.Add(this.txtChangeNameAds);
		this.groupBox3.Controls.Add(this.cbChangeNameAct);
		this.groupBox3.Controls.Add(this.cbCampReview);
		this.groupBox3.Controls.Add(this.txtLimit);
		this.groupBox3.Controls.Add(this.ccbApprovedPayment);
		this.groupBox3.Controls.Add(this.cbSetLimit);
		this.groupBox3.Controls.Add(this.cbRemoveActInBM);
		this.groupBox3.Location = new System.Drawing.Point(13, 261);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox3.Size = new System.Drawing.Size(689, 225);
		this.groupBox3.TabIndex = 33;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Tiện ích";
		this.cbCardVerify.AutoSize = true;
		this.cbCardVerify.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbCardVerify.Location = new System.Drawing.Point(431, 138);
		this.cbCardVerify.Margin = new System.Windows.Forms.Padding(4);
		this.cbCardVerify.Name = "cbCardVerify";
		this.cbCardVerify.Size = new System.Drawing.Size(66, 20);
		this.cbCardVerify.TabIndex = 45;
		this.cbCardVerify.Text = "XM thẻ";
		this.cbCardVerify.UseVisualStyleBackColor = true;
		this.cbCardVerify.CheckedChanged += new System.EventHandler(cbCardVerify_CheckedChanged<T17, T20, T22>);
		this.cbReloadTk.AutoSize = true;
		this.cbReloadTk.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbReloadTk.Location = new System.Drawing.Point(519, 166);
		this.cbReloadTk.Margin = new System.Windows.Forms.Padding(4);
		this.cbReloadTk.Name = "cbReloadTk";
		this.cbReloadTk.Size = new System.Drawing.Size(91, 20);
		this.cbReloadTk.TabIndex = 44;
		this.cbReloadTk.Text = "Reload TK";
		this.cbReloadTk.UseVisualStyleBackColor = true;
		this.cbReloadTk.CheckedChanged += new System.EventHandler(cbReloadTk_CheckedChanged<T17, T20, T22>);
		this.txtPushCardPrimary.Enabled = false;
		this.txtPushCardPrimary.Location = new System.Drawing.Point(473, 79);
		this.txtPushCardPrimary.Margin = new System.Windows.Forms.Padding(4);
		this.txtPushCardPrimary.Name = "txtPushCardPrimary";
		this.txtPushCardPrimary.Size = new System.Drawing.Size(148, 22);
		this.txtPushCardPrimary.TabIndex = 43;
		this.txtPushCardPrimary.TextChanged += new System.EventHandler(txtPushCardPrimary_TextChanged);
		this.cbAddCartPrimary.AutoSize = true;
		this.cbAddCartPrimary.Location = new System.Drawing.Point(263, 138);
		this.cbAddCartPrimary.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCartPrimary.Name = "cbAddCartPrimary";
		this.cbAddCartPrimary.Size = new System.Drawing.Size(157, 20);
		this.cbAddCartPrimary.TabIndex = 35;
		this.cbAddCartPrimary.Text = "Add thẻ+đẩy lên chính";
		this.cbAddCartPrimary.UseVisualStyleBackColor = true;
		this.cbAddCartPrimary.CheckedChanged += new System.EventHandler(cbAddCartPrimary_CheckedChanged<T17, T20, T22>);
		this.txtRemoveCardByName.Enabled = false;
		this.txtRemoveCardByName.Location = new System.Drawing.Point(385, 162);
		this.txtRemoveCardByName.Margin = new System.Windows.Forms.Padding(4);
		this.txtRemoveCardByName.Name = "txtRemoveCardByName";
		this.txtRemoveCardByName.Size = new System.Drawing.Size(116, 22);
		this.txtRemoveCardByName.TabIndex = 39;
		this.txtRemoveCardByName.TextChanged += new System.EventHandler(txtRemoveCardByName_TextChanged);
		this.cbRemoveCardByName.AutoSize = true;
		this.cbRemoveCardByName.Location = new System.Drawing.Point(152, 166);
		this.cbRemoveCardByName.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveCardByName.Name = "cbRemoveCardByName";
		this.cbRemoveCardByName.Size = new System.Drawing.Size(212, 20);
		this.cbRemoveCardByName.TabIndex = 38;
		this.cbRemoveCardByName.Text = "Xóa thẻ visa/master/4_số_cuối:";
		this.cbRemoveCardByName.UseVisualStyleBackColor = true;
		this.cbRemoveCardByName.CheckedChanged += new System.EventHandler(cbRemoveCardByName_CheckedChanged<T17, T20, T22>);
		this.txtPayBalance.Enabled = false;
		this.txtPayBalance.Location = new System.Drawing.Point(308, 110);
		this.txtPayBalance.Margin = new System.Windows.Forms.Padding(4);
		this.txtPayBalance.Name = "txtPayBalance";
		this.txtPayBalance.Size = new System.Drawing.Size(96, 22);
		this.txtPayBalance.TabIndex = 37;
		this.txtPayBalance.TextChanged += new System.EventHandler(txtPayBalance_TextChanged);
		this.cbPayBalance.AutoSize = true;
		this.cbPayBalance.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbPayBalance.Location = new System.Drawing.Point(231, 112);
		this.cbPayBalance.Margin = new System.Windows.Forms.Padding(4);
		this.cbPayBalance.Name = "cbPayBalance";
		this.cbPayBalance.Size = new System.Drawing.Size(68, 20);
		this.cbPayBalance.TabIndex = 36;
		this.cbPayBalance.Text = "Pay nợ";
		this.cbPayBalance.UseVisualStyleBackColor = true;
		this.cbPayBalance.CheckedChanged += new System.EventHandler(cbPayBalance_CheckedChanged<T17, T20, T22>);
		this.cbTryAgainHoldMoney.AutoSize = true;
		this.cbTryAgainHoldMoney.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbTryAgainHoldMoney.Location = new System.Drawing.Point(8, 138);
		this.cbTryAgainHoldMoney.Margin = new System.Windows.Forms.Padding(4);
		this.cbTryAgainHoldMoney.Name = "cbTryAgainHoldMoney";
		this.cbTryAgainHoldMoney.Size = new System.Drawing.Size(150, 20);
		this.cbTryAgainHoldMoney.TabIndex = 34;
		this.cbTryAgainHoldMoney.Text = "Thử lại (Tạm giữ tiền)";
		this.cbTryAgainHoldMoney.UseVisualStyleBackColor = true;
		this.cbTryAgainHoldMoney.CheckedChanged += new System.EventHandler(cbTryAgainHoldMoney_CheckedChanged<T17, T20, T22>);
		this.txtUID_Share_Tk.Enabled = false;
		this.txtUID_Share_Tk.Location = new System.Drawing.Point(473, 21);
		this.txtUID_Share_Tk.Margin = new System.Windows.Forms.Padding(4);
		this.txtUID_Share_Tk.Name = "txtUID_Share_Tk";
		this.txtUID_Share_Tk.Size = new System.Drawing.Size(148, 22);
		this.txtUID_Share_Tk.TabIndex = 33;
		this.txtUID_Share_Tk.TextChanged += new System.EventHandler(txtUID_Share_Tk_TextChanged);
		this.cbShareTK.AutoSize = true;
		this.cbShareTK.Location = new System.Drawing.Point(381, 23);
		this.cbShareTK.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareTK.Name = "cbShareTK";
		this.cbShareTK.Size = new System.Drawing.Size(85, 20);
		this.cbShareTK.TabIndex = 32;
		this.cbShareTK.Text = "Share TK:";
		this.cbShareTK.UseVisualStyleBackColor = true;
		this.cbShareTK.CheckedChanged += new System.EventHandler(cbShareTK_CheckedChanged<T17, T20, T22>);
		this.cbKichNo.AutoSize = true;
		this.cbKichNo.Location = new System.Drawing.Point(9, 110);
		this.cbKichNo.Margin = new System.Windows.Forms.Padding(4);
		this.cbKichNo.Name = "cbKichNo";
		this.cbKichNo.Size = new System.Drawing.Size(69, 20);
		this.cbKichNo.TabIndex = 31;
		this.cbKichNo.Text = "Kích nợ";
		this.cbKichNo.UseVisualStyleBackColor = true;
		this.cbKichNo.CheckedChanged += new System.EventHandler(cbKichNo_CheckedChanged<T17, T20, T22>);
		this.cbPaynow.AutoSize = true;
		this.cbPaynow.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbPaynow.Location = new System.Drawing.Point(116, 112);
		this.cbPaynow.Margin = new System.Windows.Forms.Padding(4);
		this.cbPaynow.Name = "cbPaynow";
		this.cbPaynow.Size = new System.Drawing.Size(103, 20);
		this.cbPaynow.TabIndex = 30;
		this.cbPaynow.Text = "Pay nợ FULL";
		this.cbPaynow.UseVisualStyleBackColor = true;
		this.cbPaynow.CheckedChanged += new System.EventHandler(cbPaynow_CheckedChanged<T17, T20, T22>);
		this.cbRemoveCard.AutoSize = true;
		this.cbRemoveCard.Location = new System.Drawing.Point(8, 166);
		this.cbRemoveCard.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveCard.Name = "cbRemoveCard";
		this.cbRemoveCard.Size = new System.Drawing.Size(119, 20);
		this.cbRemoveCard.TabIndex = 29;
		this.cbRemoveCard.Text = "Xóa toàn bộ thẻ";
		this.cbRemoveCard.UseVisualStyleBackColor = true;
		this.cbRemoveCard.CheckedChanged += new System.EventHandler(cbRemoveCard_CheckedChanged<T17, T20, T22>);
		this.ccbPushCardPrimary.AutoSize = true;
		this.ccbPushCardPrimary.ForeColor = System.Drawing.SystemColors.MenuHighlight;
		this.ccbPushCardPrimary.Location = new System.Drawing.Point(317, 81);
		this.ccbPushCardPrimary.Margin = new System.Windows.Forms.Padding(4);
		this.ccbPushCardPrimary.Name = "ccbPushCardPrimary";
		this.ccbPushCardPrimary.Size = new System.Drawing.Size(129, 20);
		this.ccbPushCardPrimary.TabIndex = 28;
		this.ccbPushCardPrimary.Text = "Đẩy thẻ lên chính:";
		this.ccbPushCardPrimary.UseVisualStyleBackColor = true;
		this.ccbPushCardPrimary.CheckedChanged += new System.EventHandler(ccbPushCardPrimary_CheckedChanged<T17, T20, T22>);
		this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl.Controls.Add(this.tabCookie);
		this.tabControl.Controls.Add(this.tabToken);
		this.tabControl.Controls.Add(this.tabPage1);
		this.tabControl.Controls.Add(this.tabPage2);
		this.tabControl.ImageList = this.imageList1;
		this.tabControl.Location = new System.Drawing.Point(4, 9);
		this.tabControl.Margin = new System.Windows.Forms.Padding(4);
		this.tabControl.Name = "tabControl";
		this.tabControl.SelectedIndex = 0;
		this.tabControl.Size = new System.Drawing.Size(718, 623);
		this.tabControl.TabIndex = 34;
		this.tabCookie.AutoScroll = true;
		this.tabCookie.Controls.Add(this.groupBox9);
		this.tabCookie.Controls.Add(this.groupBox2);
		this.tabCookie.Controls.Add(this.groupRollingMat);
		this.tabCookie.Controls.Add(this.groupBox3);
		this.tabCookie.ImageIndex = 0;
		this.tabCookie.Location = new System.Drawing.Point(4, 25);
		this.tabCookie.Margin = new System.Windows.Forms.Padding(4);
		this.tabCookie.Name = "tabCookie";
		this.tabCookie.Padding = new System.Windows.Forms.Padding(4);
		this.tabCookie.Size = new System.Drawing.Size(710, 594);
		this.tabCookie.TabIndex = 0;
		this.tabCookie.Text = "Tab 1";
		this.tabCookie.UseVisualStyleBackColor = true;
		this.groupBox9.Controls.Add(this.label10);
		this.groupBox9.Controls.Add(this.txtTimeZone);
		this.groupBox9.Controls.Add(this.label9);
		this.groupBox9.Controls.Add(this.txtCurrency);
		this.groupBox9.Controls.Add(this.label8);
		this.groupBox9.Controls.Add(this.txtCountry);
		this.groupBox9.Controls.Add(this.label7);
		this.groupBox9.Controls.Add(this.txtState);
		this.groupBox9.Controls.Add(this.label6);
		this.groupBox9.Controls.Add(this.txtZip);
		this.groupBox9.Controls.Add(this.label5);
		this.groupBox9.Controls.Add(this.txtCity);
		this.groupBox9.Controls.Add(this.label4);
		this.groupBox9.Controls.Add(this.txtAddress);
		this.groupBox9.Controls.Add(this.cbChangeInfoAct);
		this.groupBox9.Location = new System.Drawing.Point(13, 126);
		this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox9.Size = new System.Drawing.Size(688, 128);
		this.groupBox9.TabIndex = 32;
		this.groupBox9.TabStop = false;
		this.groupBox9.Text = "Đổi thông tin TK";
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(381, 90);
		this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(53, 16);
		this.label10.TabIndex = 42;
		this.label10.Text = "Múi giờ:";
		this.txtTimeZone.Location = new System.Drawing.Point(444, 87);
		this.txtTimeZone.Margin = new System.Windows.Forms.Padding(4);
		this.txtTimeZone.MaxLength = 999999999;
		this.txtTimeZone.Name = "txtTimeZone";
		this.txtTimeZone.Size = new System.Drawing.Size(168, 22);
		this.txtTimeZone.TabIndex = 41;
		this.txtTimeZone.TextChanged += new System.EventHandler(txtTimeZone_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(177, 90);
		this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(51, 16);
		this.label9.TabIndex = 40;
		this.label9.Text = "Tiền tệ:";
		this.txtCurrency.Location = new System.Drawing.Point(240, 87);
		this.txtCurrency.Margin = new System.Windows.Forms.Padding(4);
		this.txtCurrency.MaxLength = 999999999;
		this.txtCurrency.Name = "txtCurrency";
		this.txtCurrency.Size = new System.Drawing.Size(132, 22);
		this.txtCurrency.TabIndex = 39;
		this.txtCurrency.TextChanged += new System.EventHandler(txtCurrency_TextChanged);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(8, 90);
		this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(64, 16);
		this.label8.TabIndex = 38;
		this.label8.Text = "Quốc gia:";
		this.txtCountry.Location = new System.Drawing.Point(87, 87);
		this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
		this.txtCountry.MaxLength = 999999999;
		this.txtCountry.Name = "txtCountry";
		this.txtCountry.Size = new System.Drawing.Size(81, 22);
		this.txtCountry.TabIndex = 37;
		this.txtCountry.TextChanged += new System.EventHandler(txtCountry_TextChanged);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(389, 58);
		this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(41, 16);
		this.label7.TabIndex = 36;
		this.label7.Text = "State:";
		this.txtState.Location = new System.Drawing.Point(444, 55);
		this.txtState.Margin = new System.Windows.Forms.Padding(4);
		this.txtState.MaxLength = 999999999;
		this.txtState.Name = "txtState";
		this.txtState.Size = new System.Drawing.Size(52, 22);
		this.txtState.TabIndex = 35;
		this.txtState.TextChanged += new System.EventHandler(txtState_TextChanged);
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(503, 58);
		this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(29, 16);
		this.label6.TabIndex = 34;
		this.label6.Text = "Zip:";
		this.txtZip.Location = new System.Drawing.Point(543, 55);
		this.txtZip.Margin = new System.Windows.Forms.Padding(4);
		this.txtZip.MaxLength = 999999999;
		this.txtZip.Name = "txtZip";
		this.txtZip.Size = new System.Drawing.Size(69, 22);
		this.txtZip.TabIndex = 33;
		this.txtZip.TextChanged += new System.EventHandler(txtZip_TextChanged);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(240, 58);
		this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(32, 16);
		this.label5.TabIndex = 32;
		this.label5.Text = "City:";
		this.txtCity.Location = new System.Drawing.Point(284, 55);
		this.txtCity.Margin = new System.Windows.Forms.Padding(4);
		this.txtCity.MaxLength = 999999999;
		this.txtCity.Name = "txtCity";
		this.txtCity.Size = new System.Drawing.Size(88, 22);
		this.txtCity.TabIndex = 31;
		this.txtCity.TextChanged += new System.EventHandler(txtCity_TextChanged);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(8, 58);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(50, 16);
		this.label4.TabIndex = 30;
		this.label4.Text = "Địa chỉ:";
		this.txtAddress.Location = new System.Drawing.Point(87, 54);
		this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
		this.txtAddress.MaxLength = 999999999;
		this.txtAddress.Name = "txtAddress";
		this.txtAddress.Size = new System.Drawing.Size(144, 22);
		this.txtAddress.TabIndex = 29;
		this.txtAddress.TextChanged += new System.EventHandler(txtAddress_TextChanged);
		this.cbChangeInfoAct.AutoSize = true;
		this.cbChangeInfoAct.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbChangeInfoAct.Location = new System.Drawing.Point(8, 26);
		this.cbChangeInfoAct.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangeInfoAct.Name = "cbChangeInfoAct";
		this.cbChangeInfoAct.Size = new System.Drawing.Size(118, 20);
		this.cbChangeInfoAct.TabIndex = 28;
		this.cbChangeInfoAct.Text = "Đổi thông tin TK";
		this.cbChangeInfoAct.UseVisualStyleBackColor = true;
		this.cbChangeInfoAct.CheckedChanged += new System.EventHandler(cbChangeInfoAct_CheckedChanged<T17, T20, T22>);
		this.tabToken.AutoScroll = true;
		this.tabToken.Controls.Add(this.groupBox10);
		this.tabToken.Controls.Add(this.groupBox4);
		this.tabToken.ImageIndex = 0;
		this.tabToken.Location = new System.Drawing.Point(4, 25);
		this.tabToken.Margin = new System.Windows.Forms.Padding(4);
		this.tabToken.Name = "tabToken";
		this.tabToken.Padding = new System.Windows.Forms.Padding(4);
		this.tabToken.Size = new System.Drawing.Size(710, 594);
		this.tabToken.TabIndex = 1;
		this.tabToken.Text = "Tab 2";
		this.tabToken.UseVisualStyleBackColor = true;
		this.groupBox10.Controls.Add(this.cbRemoveAdsToGroup);
		this.groupBox10.Controls.Add(this.ccbGroupInBM);
		this.groupBox10.Controls.Add(this.cbAddAdsToGroup);
		this.groupBox10.Controls.Add(this.button3);
		this.groupBox10.Location = new System.Drawing.Point(8, 79);
		this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox10.Name = "groupBox10";
		this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox10.Size = new System.Drawing.Size(694, 64);
		this.groupBox10.TabIndex = 6;
		this.groupBox10.TabStop = false;
		this.groupBox10.Text = "Thêm TKQC vào nhóm tài sản";
		this.cbRemoveAdsToGroup.AutoSize = true;
		this.cbRemoveAdsToGroup.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbRemoveAdsToGroup.Location = new System.Drawing.Point(129, 26);
		this.cbRemoveAdsToGroup.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveAdsToGroup.Name = "cbRemoveAdsToGroup";
		this.cbRemoveAdsToGroup.Size = new System.Drawing.Size(109, 20);
		this.cbRemoveAdsToGroup.TabIndex = 5;
		this.cbRemoveAdsToGroup.Text = "Thu hồi TKQC";
		this.cbRemoveAdsToGroup.UseVisualStyleBackColor = true;
		this.cbRemoveAdsToGroup.CheckedChanged += new System.EventHandler(cbRemoveAdsToGroup_CheckedChanged<T17, T20, T22, T28, T29, T24, T30>);
		this.ccbGroupInBM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbGroupInBM.FormattingEnabled = true;
		this.ccbGroupInBM.Location = new System.Drawing.Point(263, 23);
		this.ccbGroupInBM.Margin = new System.Windows.Forms.Padding(4);
		this.ccbGroupInBM.Name = "ccbGroupInBM";
		this.ccbGroupInBM.Size = new System.Drawing.Size(337, 24);
		this.ccbGroupInBM.TabIndex = 4;
		this.ccbGroupInBM.SelectedIndexChanged += new System.EventHandler(ccbGroupInBM_SelectedIndexChanged);
		this.cbAddAdsToGroup.AutoSize = true;
		this.cbAddAdsToGroup.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddAdsToGroup.Location = new System.Drawing.Point(8, 26);
		this.cbAddAdsToGroup.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddAdsToGroup.Name = "cbAddAdsToGroup";
		this.cbAddAdsToGroup.Size = new System.Drawing.Size(100, 20);
		this.cbAddAdsToGroup.TabIndex = 2;
		this.cbAddAdsToGroup.Text = "Thêm TKQC";
		this.cbAddAdsToGroup.UseVisualStyleBackColor = true;
		this.cbAddAdsToGroup.CheckedChanged += new System.EventHandler(cbAddAdsToGroup_CheckedChanged<T17, T20, T22, T28, T29, T24, T30>);
		this.button3.Location = new System.Drawing.Point(609, 21);
		this.button3.Margin = new System.Windows.Forms.Padding(4);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(32, 28);
		this.button3.TabIndex = 3;
		this.button3.Text = "O";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.groupBox4.Controls.Add(this.cbRemoveTKQCToVia);
		this.groupBox4.Controls.Add(this.ccbUserInBM);
		this.groupBox4.Controls.Add(this.cbShareTKQCToVia);
		this.groupBox4.Controls.Add(this.button2);
		this.groupBox4.Location = new System.Drawing.Point(8, 7);
		this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox4.Size = new System.Drawing.Size(694, 64);
		this.groupBox4.TabIndex = 5;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Phân quyền TKQC cho user";
		this.cbRemoveTKQCToVia.AutoSize = true;
		this.cbRemoveTKQCToVia.Location = new System.Drawing.Point(120, 26);
		this.cbRemoveTKQCToVia.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveTKQCToVia.Name = "cbRemoveTKQCToVia";
		this.cbRemoveTKQCToVia.Size = new System.Drawing.Size(98, 20);
		this.cbRemoveTKQCToVia.TabIndex = 5;
		this.cbRemoveTKQCToVia.Text = "Thu hồi tkqc";
		this.cbRemoveTKQCToVia.UseVisualStyleBackColor = true;
		this.cbRemoveTKQCToVia.CheckedChanged += new System.EventHandler(cbRemoveTKQCToVia_CheckedChanged<T17, T20, T22, T31, T29, T24, T30>);
		this.ccbUserInBM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbUserInBM.FormattingEnabled = true;
		this.ccbUserInBM.Location = new System.Drawing.Point(243, 23);
		this.ccbUserInBM.Margin = new System.Windows.Forms.Padding(4);
		this.ccbUserInBM.Name = "ccbUserInBM";
		this.ccbUserInBM.Size = new System.Drawing.Size(357, 24);
		this.ccbUserInBM.TabIndex = 4;
		this.ccbUserInBM.SelectedIndexChanged += new System.EventHandler(ccbUserInBM_SelectedIndexChanged);
		this.cbShareTKQCToVia.AutoSize = true;
		this.cbShareTKQCToVia.Location = new System.Drawing.Point(8, 26);
		this.cbShareTKQCToVia.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareTKQCToVia.Name = "cbShareTKQCToVia";
		this.cbShareTKQCToVia.Size = new System.Drawing.Size(90, 20);
		this.cbShareTKQCToVia.TabIndex = 2;
		this.cbShareTKQCToVia.Text = "Share tkqc";
		this.cbShareTKQCToVia.UseVisualStyleBackColor = true;
		this.cbShareTKQCToVia.CheckedChanged += new System.EventHandler(cbShareTKQCToVia_CheckedChanged<T17, T20, T22, T31, T29, T24, T30>);
		this.button2.Location = new System.Drawing.Point(609, 21);
		this.button2.Margin = new System.Windows.Forms.Padding(4);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(32, 28);
		this.button2.TabIndex = 3;
		this.button2.Text = "O";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.tabPage1.AutoScroll = true;
		this.tabPage1.Controls.Add(this.cbRemoveCamp);
		this.tabPage1.Controls.Add(this.ccbOnOffTKQC);
		this.tabPage1.Controls.Add(this.cbOnTkqc);
		this.tabPage1.Controls.Add(this.button4);
		this.tabPage1.Controls.Add(this.cbOffTkqc);
		this.tabPage1.Controls.Add(this.label16);
		this.tabPage1.Controls.Add(this.label15);
		this.tabPage1.Controls.Add(this.ccbPostId);
		this.tabPage1.Controls.Add(this.ccbPageId);
		this.tabPage1.Controls.Add(this.cbChangePost);
		this.tabPage1.Controls.Add(this.txtBugetCamp);
		this.tabPage1.Controls.Add(this.cbChangeBugetGruopAds);
		this.tabPage1.Controls.Add(this.cbChangeBugetCamp);
		this.tabPage1.Controls.Add(this.label3);
		this.tabPage1.Controls.Add(this.txtCampFilter);
		this.tabPage1.Controls.Add(this.cbEditTarget);
		this.tabPage1.Controls.Add(this.splitContainer1);
		this.tabPage1.ImageIndex = 1;
		this.tabPage1.Location = new System.Drawing.Point(4, 25);
		this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
		this.tabPage1.Size = new System.Drawing.Size(710, 594);
		this.tabPage1.TabIndex = 2;
		this.tabPage1.Text = "Sửa target";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.cbRemoveCamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbRemoveCamp.AutoSize = true;
		this.cbRemoveCamp.Location = new System.Drawing.Point(377, 557);
		this.cbRemoveCamp.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemoveCamp.Name = "cbRemoveCamp";
		this.cbRemoveCamp.Size = new System.Drawing.Size(87, 20);
		this.cbRemoveCamp.TabIndex = 52;
		this.cbRemoveCamp.Text = "Xóa camp";
		this.cbRemoveCamp.UseVisualStyleBackColor = true;
		this.cbRemoveCamp.CheckedChanged += new System.EventHandler(cbRemoveCamp_CheckedChanged<T17, T20, T22>);
		this.ccbOnOffTKQC.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.ccbOnOffTKQC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbOnOffTKQC.FormattingEnabled = true;
		this.ccbOnOffTKQC.Items.AddRange((object[])(object)new T20[3]
		{
			(T20)"Chiến dịch",
			(T20)"Nhóm quảng cáo",
			(T20)"Quảng cáo"
		});
		this.ccbOnOffTKQC.Location = new System.Drawing.Point(195, 555);
		this.ccbOnOffTKQC.Margin = new System.Windows.Forms.Padding(4);
		this.ccbOnOffTKQC.Name = "ccbOnOffTKQC";
		this.ccbOnOffTKQC.Size = new System.Drawing.Size(173, 24);
		this.ccbOnOffTKQC.TabIndex = 8;
		this.ccbOnOffTKQC.SelectedIndexChanged += new System.EventHandler(ccbOnOffTKQC_SelectedIndexChanged);
		this.cbOnTkqc.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbOnTkqc.AutoSize = true;
		this.cbOnTkqc.Location = new System.Drawing.Point(9, 557);
		this.cbOnTkqc.Margin = new System.Windows.Forms.Padding(4);
		this.cbOnTkqc.Name = "cbOnTkqc";
		this.cbOnTkqc.Size = new System.Drawing.Size(83, 20);
		this.cbOnTkqc.TabIndex = 7;
		this.cbOnTkqc.Text = "Bật camp";
		this.cbOnTkqc.UseVisualStyleBackColor = true;
		this.cbOnTkqc.CheckedChanged += new System.EventHandler(cbOnTkqc_CheckedChanged<T17, T20, T22>);
		this.button4.Location = new System.Drawing.Point(108, 2);
		this.button4.Margin = new System.Windows.Forms.Padding(4);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(145, 28);
		this.button4.TabIndex = 51;
		this.button4.Text = "Lấy bản nháp";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click<T17, T24, T20, T22, T32, T33, T34, T30>);
		this.cbOffTkqc.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbOffTkqc.AutoSize = true;
		this.cbOffTkqc.Location = new System.Drawing.Point(108, 557);
		this.cbOffTkqc.Margin = new System.Windows.Forms.Padding(4);
		this.cbOffTkqc.Name = "cbOffTkqc";
		this.cbOffTkqc.Size = new System.Drawing.Size(83, 20);
		this.cbOffTkqc.TabIndex = 6;
		this.cbOffTkqc.Text = "Tắt camp";
		this.cbOffTkqc.UseVisualStyleBackColor = true;
		this.cbOffTkqc.CheckedChanged += new System.EventHandler(cbOffTkqc_CheckedChanged<T17, T20, T22>);
		this.label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(312, 524);
		this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(37, 16);
		this.label16.TabIndex = 50;
		this.label16.Text = "Post:";
		this.label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(104, 753);
		this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(43, 16);
		this.label15.TabIndex = 49;
		this.label15.Text = "Page:";
		this.ccbPostId.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.ccbPostId.DropDownWidth = 500;
		this.ccbPostId.Enabled = false;
		this.ccbPostId.FormattingEnabled = true;
		this.ccbPostId.Location = new System.Drawing.Point(356, 521);
		this.ccbPostId.Margin = new System.Windows.Forms.Padding(4);
		this.ccbPostId.Name = "ccbPostId";
		this.ccbPostId.Size = new System.Drawing.Size(233, 24);
		this.ccbPostId.TabIndex = 48;
		this.ccbPostId.SelectedIndexChanged += new System.EventHandler(ccbPostId_SelectedIndexChanged<T17, T20, T22, T26, T24>);
		this.ccbPageId.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.ccbPageId.DropDownWidth = 500;
		this.ccbPageId.Enabled = false;
		this.ccbPageId.FormattingEnabled = true;
		this.ccbPageId.Location = new System.Drawing.Point(95, 521);
		this.ccbPageId.Margin = new System.Windows.Forms.Padding(4);
		this.ccbPageId.Name = "ccbPageId";
		this.ccbPageId.Size = new System.Drawing.Size(209, 24);
		this.ccbPageId.TabIndex = 47;
		this.ccbPageId.SelectedIndexChanged += new System.EventHandler(ccbPageId_SelectedIndexChanged<T17, T24, T35, T20, T22, T26, T30, T29>);
		this.cbChangePost.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbChangePost.AutoSize = true;
		this.cbChangePost.Location = new System.Drawing.Point(9, 524);
		this.cbChangePost.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangePost.Name = "cbChangePost";
		this.cbChangePost.Size = new System.Drawing.Size(75, 20);
		this.cbChangePost.TabIndex = 46;
		this.cbChangePost.Text = "Đổi post";
		this.cbChangePost.UseVisualStyleBackColor = true;
		this.cbChangePost.CheckedChanged += new System.EventHandler(cbChangePost_CheckedChanged<T17, T20, T22>);
		this.txtBugetCamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtBugetCamp.Location = new System.Drawing.Point(345, 491);
		this.txtBugetCamp.Margin = new System.Windows.Forms.Padding(4);
		this.txtBugetCamp.Name = "txtBugetCamp";
		this.txtBugetCamp.Size = new System.Drawing.Size(140, 22);
		this.txtBugetCamp.TabIndex = 45;
		this.txtBugetCamp.TextChanged += new System.EventHandler(txtBugetCamp_TextChanged);
		this.cbChangeBugetGruopAds.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbChangeBugetGruopAds.AutoSize = true;
		this.cbChangeBugetGruopAds.Location = new System.Drawing.Point(195, 493);
		this.cbChangeBugetGruopAds.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangeBugetGruopAds.Name = "cbChangeBugetGruopAds";
		this.cbChangeBugetGruopAds.Size = new System.Drawing.Size(148, 20);
		this.cbChangeBugetGruopAds.TabIndex = 44;
		this.cbChangeBugetGruopAds.Text = "Ngân sách nhóm qc:";
		this.cbChangeBugetGruopAds.UseVisualStyleBackColor = true;
		this.cbChangeBugetGruopAds.CheckedChanged += new System.EventHandler(cbChangeBugetGruopAds_CheckedChanged_1<T17, T20, T22>);
		this.cbChangeBugetCamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbChangeBugetCamp.AutoSize = true;
		this.cbChangeBugetCamp.Location = new System.Drawing.Point(9, 493);
		this.cbChangeBugetCamp.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangeBugetCamp.Name = "cbChangeBugetCamp";
		this.cbChangeBugetCamp.Size = new System.Drawing.Size(157, 20);
		this.cbChangeBugetCamp.TabIndex = 43;
		this.cbChangeBugetCamp.Text = "Ngân sách chiến dịch:";
		this.cbChangeBugetCamp.UseVisualStyleBackColor = true;
		this.cbChangeBugetCamp.CheckedChanged += new System.EventHandler(cbChangeBugetCamp_CheckedChanged_1<T17, T20, T22>);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(320, 9);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(116, 16);
		this.label3.TabIndex = 5;
		this.label3.Text = "Lọc tên chiến dịch:";
		this.txtCampFilter.Location = new System.Drawing.Point(459, 5);
		this.txtCampFilter.Margin = new System.Windows.Forms.Padding(4);
		this.txtCampFilter.Name = "txtCampFilter";
		this.txtCampFilter.Size = new System.Drawing.Size(195, 22);
		this.txtCampFilter.TabIndex = 4;
		this.txtCampFilter.TextChanged += new System.EventHandler(txtCampFilter_TextChanged);
		this.cbEditTarget.AutoSize = true;
		this.cbEditTarget.Location = new System.Drawing.Point(9, 7);
		this.cbEditTarget.Margin = new System.Windows.Forms.Padding(4);
		this.cbEditTarget.Name = "cbEditTarget";
		this.cbEditTarget.Size = new System.Drawing.Size(87, 20);
		this.cbEditTarget.TabIndex = 3;
		this.cbEditTarget.Text = "Sửa target";
		this.cbEditTarget.UseVisualStyleBackColor = true;
		this.cbEditTarget.CheckedChanged += new System.EventHandler(cbEditTarget_CheckedChanged<T17, T20, T22>);
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.splitContainer1.Location = new System.Drawing.Point(9, 35);
		this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
		this.splitContainer1.Panel2.Controls.Add(this.groupBox8);
		this.splitContainer1.Size = new System.Drawing.Size(701, 448);
		this.splitContainer1.SplitterDistance = 267;
		this.splitContainer1.SplitterWidth = 5;
		this.splitContainer1.TabIndex = 0;
		this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer2.Location = new System.Drawing.Point(0, 0);
		this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
		this.splitContainer2.Name = "splitContainer2";
		this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer2.Panel1.Controls.Add(this.groupBox6);
		this.splitContainer2.Panel2.Controls.Add(this.groupBox7);
		this.splitContainer2.Size = new System.Drawing.Size(701, 267);
		this.splitContainer2.SplitterDistance = 121;
		this.splitContainer2.SplitterWidth = 5;
		this.splitContainer2.TabIndex = 0;
		this.groupBox6.Controls.Add(this.txtTargetCamp);
		this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox6.Location = new System.Drawing.Point(0, 0);
		this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox6.Size = new System.Drawing.Size(699, 119);
		this.groupBox6.TabIndex = 0;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "Chiến dịch";
		this.txtTargetCamp.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtTargetCamp.Location = new System.Drawing.Point(4, 19);
		this.txtTargetCamp.Margin = new System.Windows.Forms.Padding(4);
		this.txtTargetCamp.MaxLength = 999999999;
		this.txtTargetCamp.Multiline = true;
		this.txtTargetCamp.Name = "txtTargetCamp";
		this.txtTargetCamp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtTargetCamp.Size = new System.Drawing.Size(691, 96);
		this.txtTargetCamp.TabIndex = 0;
		this.txtTargetCamp.TextChanged += new System.EventHandler(txtTargetAds_TextChanged);
		this.groupBox7.Controls.Add(this.txtTargetAdset);
		this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox7.Location = new System.Drawing.Point(0, 0);
		this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox7.Size = new System.Drawing.Size(699, 139);
		this.groupBox7.TabIndex = 1;
		this.groupBox7.TabStop = false;
		this.groupBox7.Text = "Nhóm quảng cáo";
		this.txtTargetAdset.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtTargetAdset.Location = new System.Drawing.Point(4, 19);
		this.txtTargetAdset.Margin = new System.Windows.Forms.Padding(4);
		this.txtTargetAdset.MaxLength = 999999999;
		this.txtTargetAdset.Multiline = true;
		this.txtTargetAdset.Name = "txtTargetAdset";
		this.txtTargetAdset.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtTargetAdset.Size = new System.Drawing.Size(691, 116);
		this.txtTargetAdset.TabIndex = 1;
		this.txtTargetAdset.TextChanged += new System.EventHandler(txtTargetAdset_TextChanged);
		this.groupBox8.Controls.Add(this.txtTargetAd);
		this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox8.Location = new System.Drawing.Point(0, 0);
		this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
		this.groupBox8.Size = new System.Drawing.Size(699, 174);
		this.groupBox8.TabIndex = 1;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "Quảng cáo";
		this.txtTargetAd.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtTargetAd.Location = new System.Drawing.Point(4, 19);
		this.txtTargetAd.Margin = new System.Windows.Forms.Padding(4);
		this.txtTargetAd.MaxLength = 999999999;
		this.txtTargetAd.Multiline = true;
		this.txtTargetAd.Name = "txtTargetAd";
		this.txtTargetAd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtTargetAd.Size = new System.Drawing.Size(691, 151);
		this.txtTargetAd.TabIndex = 1;
		this.txtTargetAd.TextChanged += new System.EventHandler(txtTargetContent_TextChanged);
		this.tabPage2.AutoScroll = true;
		this.tabPage2.Controls.Add(this.cbAddCartMFacebook2);
		this.tabPage2.Controls.Add(this.ccbListCard);
		this.tabPage2.Controls.Add(this.rbListCardCenter);
		this.tabPage2.Controls.Add(this.plAddByPro5);
		this.tabPage2.Controls.Add(this.cbAddCardRequest);
		this.tabPage2.Controls.Add(this.cbApproved2);
		this.tabPage2.Controls.Add(this.numDelayApproved2);
		this.tabPage2.Controls.Add(this.cbAddCardAPI);
		this.tabPage2.Controls.Add(this.cbAddCardLink1);
		this.tabPage2.Controls.Add(this.cbAddSuite);
		this.tabPage2.Controls.Add(this.cbAddBoostpost);
		this.tabPage2.Controls.Add(this.cbAddCodeCard);
		this.tabPage2.Controls.Add(this.cbAddCardLink667);
		this.tabPage2.Controls.Add(this.txtNameCard);
		this.tabPage2.Controls.Add(this.label12);
		this.tabPage2.Controls.Add(this.cbAddCardItem_M_Facebook);
		this.tabPage2.Controls.Add(this.lbTotalBinGen);
		this.tabPage2.Controls.Add(this.rbListCard);
		this.tabPage2.Controls.Add(this.rbBinGen);
		this.tabPage2.Controls.Add(this.txtAddCard_Log);
		this.tabPage2.Controls.Add(this.txtBinGen);
		this.tabPage2.Controls.Add(this.txtCardCountry);
		this.tabPage2.Controls.Add(this.label11);
		this.tabPage2.Controls.Add(this.lbCard);
		this.tabPage2.Controls.Add(this.gvCard);
		this.tabPage2.Controls.Add(this.cbAddCardItem);
		this.tabPage2.Controls.Add(this.cbAddCardItem_Primary);
		this.tabPage2.ImageIndex = 2;
		this.tabPage2.Location = new System.Drawing.Point(4, 25);
		this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
		this.tabPage2.Size = new System.Drawing.Size(710, 594);
		this.tabPage2.TabIndex = 3;
		this.tabPage2.Text = "Add thẻ";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.tabPage2.Click += new System.EventHandler(tabPage2_Click);
		this.cbAddCartMFacebook2.AutoSize = true;
		this.cbAddCartMFacebook2.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCartMFacebook2.Location = new System.Drawing.Point(161, 92);
		this.cbAddCartMFacebook2.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCartMFacebook2.Name = "cbAddCartMFacebook2";
		this.cbAddCartMFacebook2.Size = new System.Drawing.Size(135, 20);
		this.cbAddCartMFacebook2.TabIndex = 64;
		this.cbAddCartMFacebook2.Text = "Add m.facebook 2";
		this.cbAddCartMFacebook2.UseVisualStyleBackColor = true;
		this.cbAddCartMFacebook2.Visible = false;
		this.cbAddCartMFacebook2.CheckedChanged += new System.EventHandler(cbAddCartMFacebook2_CheckedChanged<T17, T20, T22>);
		this.ccbListCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ccbListCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbListCard.Enabled = false;
		this.ccbListCard.FormattingEnabled = true;
		this.ccbListCard.Location = new System.Drawing.Point(487, 135);
		this.ccbListCard.Margin = new System.Windows.Forms.Padding(4);
		this.ccbListCard.Name = "ccbListCard";
		this.ccbListCard.Size = new System.Drawing.Size(219, 24);
		this.ccbListCard.TabIndex = 63;
		this.ccbListCard.SelectedIndexChanged += new System.EventHandler(ccbListCard_SelectedIndexChanged);
		this.rbListCardCenter.AutoSize = true;
		this.rbListCardCenter.Location = new System.Drawing.Point(407, 137);
		this.rbListCardCenter.Margin = new System.Windows.Forms.Padding(4);
		this.rbListCardCenter.Name = "rbListCardCenter";
		this.rbListCardCenter.Size = new System.Drawing.Size(66, 20);
		this.rbListCardCenter.TabIndex = 62;
		this.rbListCardCenter.Text = "List thẻ";
		this.rbListCardCenter.UseVisualStyleBackColor = true;
		this.rbListCardCenter.CheckedChanged += new System.EventHandler(rbListCardCenter_CheckedChanged<T17, T20, T22>);
		this.plAddByPro5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.plAddByPro5.Controls.Add(this.numAddActOnPage);
		this.plAddByPro5.Controls.Add(this.label18);
		this.plAddByPro5.Controls.Add(this.txtPro5List);
		this.plAddByPro5.Controls.Add(this.cbAddCardByPage);
		this.plAddByPro5.Location = new System.Drawing.Point(9, 726);
		this.plAddByPro5.Margin = new System.Windows.Forms.Padding(4);
		this.plAddByPro5.Name = "plAddByPro5";
		this.plAddByPro5.Size = new System.Drawing.Size(1028, 92);
		this.plAddByPro5.TabIndex = 61;
		this.plAddByPro5.Visible = false;
		this.numAddActOnPage.Location = new System.Drawing.Point(164, 28);
		this.numAddActOnPage.Margin = new System.Windows.Forms.Padding(4);
		this.numAddActOnPage.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)999999999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numAddActOnPage.Minimum = new decimal((int[])(object)new T25[4]
		{
			(T25)1,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numAddActOnPage.Name = "numAddActOnPage";
		this.numAddActOnPage.Size = new System.Drawing.Size(76, 22);
		this.numAddActOnPage.TabIndex = 64;
		this.numAddActOnPage.Value = new decimal((int[])(object)new T25[4]
		{
			(T25)1,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numAddActOnPage.ValueChanged += new System.EventHandler(numAddActOnPage_ValueChanged<T27, T20, T22>);
		this.label18.AutoSize = true;
		this.label18.Location = new System.Drawing.Point(4, 31);
		this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(144, 16);
		this.label18.TabIndex = 63;
		this.label18.Text = "Số TK add trên 1 page:";
		this.txtPro5List.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtPro5List.Location = new System.Drawing.Point(248, 6);
		this.txtPro5List.Margin = new System.Windows.Forms.Padding(4);
		this.txtPro5List.Multiline = true;
		this.txtPro5List.Name = "txtPro5List";
		this.txtPro5List.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtPro5List.Size = new System.Drawing.Size(780, 82);
		this.txtPro5List.TabIndex = 62;
		this.txtPro5List.TextChanged += new System.EventHandler(txtPro5List_TextChanged);
		this.cbAddCardByPage.AutoSize = true;
		this.cbAddCardByPage.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardByPage.Location = new System.Drawing.Point(4, 6);
		this.cbAddCardByPage.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardByPage.Name = "cbAddCardByPage";
		this.cbAddCardByPage.Size = new System.Drawing.Size(115, 20);
		this.cbAddCardByPage.TabIndex = 61;
		this.cbAddCardByPage.Text = "Add bằng pro5";
		this.cbAddCardByPage.UseVisualStyleBackColor = true;
		this.cbAddCardByPage.CheckedChanged += new System.EventHandler(cbAddCardByPage_CheckedChanged<T17, T20, T22>);
		this.cbAddCardRequest.AutoSize = true;
		this.cbAddCardRequest.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardRequest.Location = new System.Drawing.Point(75, 92);
		this.cbAddCardRequest.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardRequest.Name = "cbAddCardRequest";
		this.cbAddCardRequest.Size = new System.Drawing.Size(77, 20);
		this.cbAddCardRequest.TabIndex = 60;
		this.cbAddCardRequest.Text = "Request";
		this.cbAddCardRequest.UseVisualStyleBackColor = true;
		this.cbAddCardRequest.CheckedChanged += new System.EventHandler(cbAddCardRequest_CheckedChanged<T17, T20, T22>);
		this.cbApproved2.AutoSize = true;
		this.cbApproved2.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbApproved2.Location = new System.Drawing.Point(399, 70);
		this.cbApproved2.Margin = new System.Windows.Forms.Padding(4);
		this.cbApproved2.Name = "cbApproved2";
		this.cbApproved2.Size = new System.Drawing.Size(160, 20);
		this.cbApproved2.TabIndex = 59;
		this.cbApproved2.Text = "Approved hold. Delay:";
		this.cbApproved2.UseVisualStyleBackColor = true;
		this.cbApproved2.CheckedChanged += new System.EventHandler(cbApproved2_CheckedChanged);
		this.numDelayApproved2.Location = new System.Drawing.Point(581, 69);
		this.numDelayApproved2.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayApproved2.Name = "numDelayApproved2";
		this.numDelayApproved2.Size = new System.Drawing.Size(73, 22);
		this.numDelayApproved2.TabIndex = 57;
		this.numDelayApproved2.ValueChanged += new System.EventHandler(numDelayApproved2_ValueChanged<T27, T20, T22>);
		this.cbAddCardAPI.AutoSize = true;
		this.cbAddCardAPI.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardAPI.Location = new System.Drawing.Point(9, 92);
		this.cbAddCardAPI.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardAPI.Name = "cbAddCardAPI";
		this.cbAddCardAPI.Size = new System.Drawing.Size(47, 20);
		this.cbAddCardAPI.TabIndex = 56;
		this.cbAddCardAPI.Text = "API";
		this.cbAddCardAPI.UseVisualStyleBackColor = true;
		this.cbAddCardAPI.CheckedChanged += new System.EventHandler(cbAddCardAPI_CheckedChanged<T17, T20, T22>);
		this.cbAddCardLink1.AutoSize = true;
		this.cbAddCardLink1.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardLink1.Location = new System.Drawing.Point(257, 64);
		this.cbAddCardLink1.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardLink1.Name = "cbAddCardLink1";
		this.cbAddCardLink1.Size = new System.Drawing.Size(60, 20);
		this.cbAddCardLink1.TabIndex = 55;
		this.cbAddCardLink1.Text = "Link 1";
		this.cbAddCardLink1.UseVisualStyleBackColor = true;
		this.cbAddCardLink1.CheckedChanged += new System.EventHandler(cbAddCardLink1_CheckedChanged<T17, T20, T22>);
		this.cbAddSuite.AutoSize = true;
		this.cbAddSuite.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddSuite.Location = new System.Drawing.Point(156, 64);
		this.cbAddSuite.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddSuite.Name = "cbAddSuite";
		this.cbAddSuite.Size = new System.Drawing.Size(82, 20);
		this.cbAddSuite.TabIndex = 54;
		this.cbAddSuite.Text = "Add suite";
		this.cbAddSuite.UseVisualStyleBackColor = true;
		this.cbAddSuite.CheckedChanged += new System.EventHandler(cbAddSuite_CheckedChanged<T17, T20, T22>);
		this.cbAddBoostpost.AutoSize = true;
		this.cbAddBoostpost.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddBoostpost.Location = new System.Drawing.Point(9, 64);
		this.cbAddBoostpost.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddBoostpost.Name = "cbAddBoostpost";
		this.cbAddBoostpost.Size = new System.Drawing.Size(114, 20);
		this.cbAddBoostpost.TabIndex = 53;
		this.cbAddBoostpost.Text = "Add boostpost";
		this.cbAddBoostpost.UseVisualStyleBackColor = true;
		this.cbAddBoostpost.CheckedChanged += new System.EventHandler(cbAddBoostpost_CheckedChanged<T17, T20, T22>);
		this.cbAddCodeCard.AutoSize = true;
		this.cbAddCodeCard.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCodeCard.Location = new System.Drawing.Point(277, 39);
		this.cbAddCodeCard.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCodeCard.Name = "cbAddCodeCard";
		this.cbAddCodeCard.Size = new System.Drawing.Size(85, 20);
		this.cbAddCodeCard.TabIndex = 52;
		this.cbAddCodeCard.Text = "Add code";
		this.cbAddCodeCard.UseVisualStyleBackColor = true;
		this.cbAddCodeCard.CheckedChanged += new System.EventHandler(cbAddCodeCard_CheckedChanged<T17, T20, T22>);
		this.cbAddCardLink667.AutoSize = true;
		this.cbAddCardLink667.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardLink667.Location = new System.Drawing.Point(156, 39);
		this.cbAddCardLink667.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardLink667.Name = "cbAddCardLink667";
		this.cbAddCardLink667.Size = new System.Drawing.Size(98, 20);
		this.cbAddCardLink667.TabIndex = 51;
		this.cbAddCardLink667.Text = "Add link 667";
		this.cbAddCardLink667.UseVisualStyleBackColor = true;
		this.cbAddCardLink667.CheckedChanged += new System.EventHandler(cbAddCardLink667_CheckedChanged);
		this.txtNameCard.Location = new System.Drawing.Point(473, 37);
		this.txtNameCard.Margin = new System.Windows.Forms.Padding(4);
		this.txtNameCard.Name = "txtNameCard";
		this.txtNameCard.Size = new System.Drawing.Size(183, 22);
		this.txtNameCard.TabIndex = 50;
		this.txtNameCard.TextChanged += new System.EventHandler(txtNameCard_TextChanged);
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(403, 41);
		this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(55, 16);
		this.label12.TabIndex = 49;
		this.label12.Text = "Tên thẻ:";
		this.cbAddCardItem_M_Facebook.AutoSize = true;
		this.cbAddCardItem_M_Facebook.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardItem_M_Facebook.Location = new System.Drawing.Point(9, 36);
		this.cbAddCardItem_M_Facebook.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardItem_M_Facebook.Name = "cbAddCardItem_M_Facebook";
		this.cbAddCardItem_M_Facebook.Size = new System.Drawing.Size(125, 20);
		this.cbAddCardItem_M_Facebook.TabIndex = 48;
		this.cbAddCardItem_M_Facebook.Text = "Add m.facebook";
		this.cbAddCardItem_M_Facebook.UseVisualStyleBackColor = true;
		this.cbAddCardItem_M_Facebook.CheckedChanged += new System.EventHandler(cbAddCardItem_M_Facebook_CheckedChanged<T17, T20, T22>);
		this.lbTotalBinGen.AutoSize = true;
		this.lbTotalBinGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbTotalBinGen.Location = new System.Drawing.Point(85, 139);
		this.lbTotalBinGen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotalBinGen.Name = "lbTotalBinGen";
		this.lbTotalBinGen.Size = new System.Drawing.Size(22, 13);
		this.lbTotalBinGen.TabIndex = 47;
		this.lbTotalBinGen.Text = "(0)";
		this.rbListCard.AutoSize = true;
		this.rbListCard.Location = new System.Drawing.Point(216, 137);
		this.rbListCard.Margin = new System.Windows.Forms.Padding(4);
		this.rbListCard.Name = "rbListCard";
		this.rbListCard.Size = new System.Drawing.Size(66, 20);
		this.rbListCard.TabIndex = 46;
		this.rbListCard.Text = "List thẻ";
		this.rbListCard.UseVisualStyleBackColor = true;
		this.rbListCard.CheckedChanged += new System.EventHandler(rbListCard_CheckedChanged<T17, T20, T22>);
		this.rbBinGen.AutoSize = true;
		this.rbBinGen.Checked = true;
		this.rbBinGen.Location = new System.Drawing.Point(9, 137);
		this.rbBinGen.Margin = new System.Windows.Forms.Padding(4);
		this.rbBinGen.Name = "rbBinGen";
		this.rbBinGen.Size = new System.Drawing.Size(70, 20);
		this.rbBinGen.TabIndex = 45;
		this.rbBinGen.TabStop = true;
		this.rbBinGen.Text = "Bin gen";
		this.rbBinGen.UseVisualStyleBackColor = true;
		this.rbBinGen.CheckedChanged += new System.EventHandler(rbBinGen_CheckedChanged<T17, T20, T22>);
		this.txtAddCard_Log.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtAddCard_Log.Location = new System.Drawing.Point(8, 497);
		this.txtAddCard_Log.Margin = new System.Windows.Forms.Padding(4);
		this.txtAddCard_Log.Multiline = true;
		this.txtAddCard_Log.Name = "txtAddCard_Log";
		this.txtAddCard_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtAddCard_Log.Size = new System.Drawing.Size(698, 89);
		this.txtAddCard_Log.TabIndex = 44;
		this.txtBinGen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtBinGen.Location = new System.Drawing.Point(9, 165);
		this.txtBinGen.Margin = new System.Windows.Forms.Padding(4);
		this.txtBinGen.Multiline = true;
		this.txtBinGen.Name = "txtBinGen";
		this.txtBinGen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtBinGen.Size = new System.Drawing.Size(203, 324);
		this.txtBinGen.TabIndex = 43;
		this.txtBinGen.TextChanged += new System.EventHandler(txtBinGen_TextChanged<T24, T25, T17, T20, T22, T26>);
		this.txtCardCountry.Location = new System.Drawing.Point(535, 5);
		this.txtCardCountry.Margin = new System.Windows.Forms.Padding(4);
		this.txtCardCountry.Name = "txtCardCountry";
		this.txtCardCountry.Size = new System.Drawing.Size(119, 22);
		this.txtCardCountry.TabIndex = 41;
		this.txtCardCountry.TextChanged += new System.EventHandler(txtCardCountry_TextChanged);
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(289, 9);
		this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(219, 16);
		this.label11.TabIndex = 40;
		this.label11.Text = "Quốc gia thẻ(mặc định khi để trống):";
		this.lbCard.AutoSize = true;
		this.lbCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbCard.Location = new System.Drawing.Point(289, 139);
		this.lbCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbCard.Name = "lbCard";
		this.lbCard.Size = new System.Drawing.Size(22, 13);
		this.lbCard.TabIndex = 39;
		this.lbCard.Text = "(0)";
		this.gvCard.AllowUserToAddRows = false;
		this.gvCard.AllowUserToDeleteRows = false;
		this.gvCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvCard.Location = new System.Drawing.Point(216, 165);
		this.gvCard.Margin = new System.Windows.Forms.Padding(4);
		this.gvCard.Name = "gvCard";
		this.gvCard.RowHeadersWidth = 51;
		this.gvCard.Size = new System.Drawing.Size(490, 324);
		this.gvCard.TabIndex = 38;
		this.gvCard.MouseClick += new System.Windows.Forms.MouseEventHandler(gvCard_MouseClick<T17, T18, T19, T20, T21>);
		this.gvCard.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(gvCard_MouseDoubleClick);
		this.cbAddCardItem.AutoSize = true;
		this.cbAddCardItem.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardItem.Location = new System.Drawing.Point(9, 7);
		this.cbAddCardItem.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardItem.Name = "cbAddCardItem";
		this.cbAddCardItem.Size = new System.Drawing.Size(72, 20);
		this.cbAddCardItem.TabIndex = 36;
		this.cbAddCardItem.Text = "Add thẻ";
		this.cbAddCardItem.UseVisualStyleBackColor = true;
		this.cbAddCardItem.CheckedChanged += new System.EventHandler(cbAddCardItem_CheckedChanged<T17, T20, T22>);
		this.cbAddCardItem_Primary.AutoSize = true;
		this.cbAddCardItem_Primary.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbAddCardItem_Primary.Location = new System.Drawing.Point(101, 7);
		this.cbAddCardItem_Primary.Margin = new System.Windows.Forms.Padding(4);
		this.cbAddCardItem_Primary.Name = "cbAddCardItem_Primary";
		this.cbAddCardItem_Primary.Size = new System.Drawing.Size(157, 20);
		this.cbAddCardItem_Primary.TabIndex = 37;
		this.cbAddCardItem_Primary.Text = "Add thẻ+đẩy lên chính";
		this.cbAddCardItem_Primary.UseVisualStyleBackColor = true;
		this.cbAddCardItem_Primary.CheckedChanged += new System.EventHandler(cbAddCardItem_Primary_CheckedChanged<T17, T20, T22>);
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)(T36)((System.Resources.ResourceManager)val).GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "clipart.ico");
		this.imageList1.Images.SetKeyName(1, "1458506.ico");
		this.imageList1.Images.SetKeyName(2, "87-870350_credit-cards-all-credit-card-logos.png");
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(313, 877);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 16);
		this.label2.TabIndex = 35;
		this.label2.Text = "Luồng:";
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.numThread.Location = new System.Drawing.Point(367, 875);
		this.numThread.Margin = new System.Windows.Forms.Padding(4);
		this.numThread.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)99999999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(61, 22);
		this.numThread.TabIndex = 36;
		this.numThread.Value = new decimal((int[])(object)new T25[4]
		{
			(T25)1,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T27, T20, T22>);
		this.splitContainer3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.splitContainer3.Location = new System.Drawing.Point(4, 4);
		this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
		this.splitContainer3.Name = "splitContainer3";
		this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer3.Panel1.Controls.Add(this.btnGetDraftPE);
		this.splitContainer3.Panel1.Controls.Add(this.txtTextCamp);
		this.splitContainer3.Panel2.Controls.Add(this.tabControl);
		this.splitContainer3.Size = new System.Drawing.Size(728, 823);
		this.splitContainer3.SplitterDistance = 170;
		this.splitContainer3.SplitterWidth = 5;
		this.splitContainer3.TabIndex = 37;
		this.btnGetDraftPE.Location = new System.Drawing.Point(4, 5);
		this.btnGetDraftPE.Margin = new System.Windows.Forms.Padding(4);
		this.btnGetDraftPE.Name = "btnGetDraftPE";
		this.btnGetDraftPE.Size = new System.Drawing.Size(145, 28);
		this.btnGetDraftPE.TabIndex = 8;
		this.btnGetDraftPE.Text = "Lấy bản nháp PE";
		this.btnGetDraftPE.UseVisualStyleBackColor = true;
		this.btnGetDraftPE.Click += new System.EventHandler(btnGetDraftPE_Click<T17, T24, T20, T22, T32, T33, T34, T30>);
		this.txtIdPixel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtIdPixel.Enabled = false;
		this.txtIdPixel.Location = new System.Drawing.Point(173, 844);
		this.txtIdPixel.Margin = new System.Windows.Forms.Padding(4);
		this.txtIdPixel.Name = "txtIdPixel";
		this.txtIdPixel.Size = new System.Drawing.Size(127, 22);
		this.txtIdPixel.TabIndex = 44;
		this.txtIdPixel.TextChanged += new System.EventHandler(txtIdPixel_TextChanged);
		this.cbSharePixel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cbSharePixel.AutoSize = true;
		this.cbSharePixel.Location = new System.Drawing.Point(18, 846);
		this.cbSharePixel.Margin = new System.Windows.Forms.Padding(4);
		this.cbSharePixel.Name = "cbSharePixel";
		this.cbSharePixel.Size = new System.Drawing.Size(147, 20);
		this.cbSharePixel.TabIndex = 43;
		this.cbSharePixel.Text = "Share Pixel. ID pixel:";
		this.cbSharePixel.UseVisualStyleBackColor = true;
		this.cbSharePixel.CheckedChanged += new System.EventHandler(cbSharePixel_CheckedChanged<T17, T20, T22>);
		this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label13.AutoSize = true;
		this.label13.Location = new System.Drawing.Point(15, 877);
		this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(62, 16);
		this.label13.TabIndex = 45;
		this.label13.Text = "BM Pixel:";
		this.txtBM_Pixel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtBM_Pixel.Enabled = false;
		this.txtBM_Pixel.Location = new System.Drawing.Point(89, 874);
		this.txtBM_Pixel.Margin = new System.Windows.Forms.Padding(4);
		this.txtBM_Pixel.Name = "txtBM_Pixel";
		this.txtBM_Pixel.Size = new System.Drawing.Size(211, 22);
		this.txtBM_Pixel.TabIndex = 46;
		this.txtBM_Pixel.TextChanged += new System.EventHandler(txtBM_Pixel_TextChanged);
		this.numDelay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.numDelay.Location = new System.Drawing.Point(517, 875);
		this.numDelay.Margin = new System.Windows.Forms.Padding(4);
		this.numDelay.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)99999999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numDelay.Name = "numDelay";
		this.numDelay.Size = new System.Drawing.Size(67, 22);
		this.numDelay.TabIndex = 48;
		this.numDelay.Value = new decimal((int[])(object)new T25[4]
		{
			(T25)1,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numDelay.ValueChanged += new System.EventHandler(numDelay_ValueChanged<T27, T20, T22>);
		this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(438, 877);
		this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(80, 16);
		this.label14.TabIndex = 47;
		this.label14.Text = "Delay(giây):";
		this.numLifeCycle.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.numLifeCycle.Location = new System.Drawing.Point(481, 905);
		this.numLifeCycle.Margin = new System.Windows.Forms.Padding(4);
		this.numLifeCycle.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)99999999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numLifeCycle.Name = "numLifeCycle";
		this.numLifeCycle.Size = new System.Drawing.Size(67, 22);
		this.numLifeCycle.TabIndex = 52;
		this.numLifeCycle.ValueChanged += new System.EventHandler(numLifeCycle_ValueChanged<T27, T20, T22>);
		this.label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label20.AutoSize = true;
		this.label20.Location = new System.Drawing.Point(445, 907);
		this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(29, 16);
		this.label20.TabIndex = 51;
		this.label20.Text = "sau";
		this.numDelayLifeCycle.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.numDelayLifeCycle.Location = new System.Drawing.Point(378, 905);
		this.numDelayLifeCycle.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayLifeCycle.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)99999999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numDelayLifeCycle.Name = "numDelayLifeCycle";
		this.numDelayLifeCycle.Size = new System.Drawing.Size(61, 22);
		this.numDelayLifeCycle.TabIndex = 50;
		this.numDelayLifeCycle.ValueChanged += new System.EventHandler(numDelayLifeCycle_ValueChanged<T27, T20, T22>);
		this.label21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label21.AutoSize = true;
		this.label21.Location = new System.Drawing.Point(293, 907);
		this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(77, 16);
		this.label21.TabIndex = 49;
		this.label21.Text = "Delay(giây)";
		this.label22.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label22.AutoSize = true;
		this.label22.Location = new System.Drawing.Point(556, 907);
		this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(28, 16);
		this.label22.TabIndex = 53;
		this.label22.Text = "lượt";
		this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer4.Location = new System.Drawing.Point(0, 0);
		this.splitContainer4.Name = "splitContainer4";
		this.splitContainer4.Panel1.Controls.Add(this.gvData);
		this.splitContainer4.Panel2.Controls.Add(this.cbSharePixel);
		this.splitContainer4.Panel2.Controls.Add(this.splitContainer3);
		this.splitContainer4.Panel2.Controls.Add(this.button1);
		this.splitContainer4.Panel2.Controls.Add(this.label22);
		this.splitContainer4.Panel2.Controls.Add(this.label1);
		this.splitContainer4.Panel2.Controls.Add(this.numLifeCycle);
		this.splitContainer4.Panel2.Controls.Add(this.txtBMID);
		this.splitContainer4.Panel2.Controls.Add(this.label20);
		this.splitContainer4.Panel2.Controls.Add(this.label2);
		this.splitContainer4.Panel2.Controls.Add(this.numDelayLifeCycle);
		this.splitContainer4.Panel2.Controls.Add(this.numThread);
		this.splitContainer4.Panel2.Controls.Add(this.label21);
		this.splitContainer4.Panel2.Controls.Add(this.txtIdPixel);
		this.splitContainer4.Panel2.Controls.Add(this.numDelay);
		this.splitContainer4.Panel2.Controls.Add(this.label13);
		this.splitContainer4.Panel2.Controls.Add(this.label14);
		this.splitContainer4.Panel2.Controls.Add(this.txtBM_Pixel);
		this.splitContainer4.Size = new System.Drawing.Size(1348, 944);
		this.splitContainer4.SplitterDistance = 608;
		this.splitContainer4.TabIndex = 54;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1348, 966);
		base.Controls.Add(this.splitContainer4);
		base.Controls.Add(this.statusStrip1);
		base.Icon = (System.Drawing.Icon)(T37)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmPublishCampText";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Quản lý TKQC BM";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmPublishCampText_FormClosing<T17, T27, T20, T38>);
		base.Load += new System.EventHandler(frmPublishCampText_Load<T17, T25, T20, T22>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.groupRollingMat.ResumeLayout(false);
		this.groupRollingMat.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numDelayRemoveCard).EndInit();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.tabControl.ResumeLayout(false);
		this.tabCookie.ResumeLayout(false);
		this.groupBox9.ResumeLayout(false);
		this.groupBox9.PerformLayout();
		this.tabToken.ResumeLayout(false);
		this.groupBox10.ResumeLayout(false);
		this.groupBox10.PerformLayout();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.splitContainer2.Panel1.ResumeLayout(false);
		this.splitContainer2.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
		this.splitContainer2.ResumeLayout(false);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox7.ResumeLayout(false);
		this.groupBox7.PerformLayout();
		this.groupBox8.ResumeLayout(false);
		this.groupBox8.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.tabPage2.PerformLayout();
		this.plAddByPro5.ResumeLayout(false);
		this.plAddByPro5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numAddActOnPage).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayApproved2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gvCard).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		this.splitContainer3.Panel1.ResumeLayout(false);
		this.splitContainer3.Panel1.PerformLayout();
		this.splitContainer3.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer3).EndInit();
		this.splitContainer3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numLifeCycle).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayLifeCycle).EndInit();
		this.splitContainer4.Panel1.ResumeLayout(false);
		this.splitContainer4.Panel2.ResumeLayout(false);
		this.splitContainer4.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer4).EndInit();
		this.splitContainer4.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
