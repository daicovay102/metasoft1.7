using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using OpenQA.Selenium;

namespace ADSPRoject;

public class frmPageManager : Form
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
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public List<string> listSelect;

		internal T0 _003C_002Ector_003Eb__0<T0>(facebook_pagesData a)
		{
			//IL_0012: Expected O, but got I4
			return (T0)listSelect.Contains(a.id);
		}
	}

	public int intThread = 1;

	private List<facebook_pagesData> ListAds = (List<facebook_pagesData>)Activator.CreateInstance(typeof(List<facebook_pagesData>));

	private frmAdsManager frm;

	private bool KichPro5;

	public bool isRunning = false;

	private bool CatePage;

	private string strCatePage;

	private bool SharePermistion;

	private string UID_Permistion;

	private bool VisiablePage;

	private bool UnVisiablePage;

	private bool ShareContentPermistion;

	private bool KichComunity;

	private bool boolRemovePageFromBM;

	private string strRemovePageFromBM;

	private bool ChangePageName;

	private List<ListStringData> listPageName = (List<ListStringData>)Activator.CreateInstance(typeof(List<ListStringData>));

	private string ViaPageThuong = "";

	private bool ShareAdminPageThuong;

	private bool ShareContentPageThuong;

	private bool SharePageThuongAPI;

	private bool boolShareParterBM;

	private string BM_ID_Partner_Page;

	private IContainer components = null;

	private DataGridView gvData;

	private NumericUpDown numThread;

	private Label label2;

	private Button button1;

	private CheckBox cbKichPro5;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel lbQuantity;

	private TextBox txtCatePage;

	private CheckBox cbCatePage;

	private TextBox txtUID_Permistion;

	private CheckBox cbSharePermistion;

	private CheckBox cbUnVisiablePage;

	private CheckBox cbVisiablePage;

	private CheckBox checkBox1;

	private CheckBox cbShareContentPermistion;

	private Label label1;

	private CheckBox cbKichComunity;

	private CheckBox cbRemovePageFromBM;

	private TextBox txtRemovePageFromBM;

	private CheckBox cbChangePageName;

	private TextBox txtPageName;

	private Label lbTotalPageName;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private CheckBox cbShareAdminPageThuong;

	private TextBox txtViaPageThuong;

	private Label label3;

	private CheckBox cbShareContentPageThuong;

	private CheckBox cbSharePageThuongAPI;

	private TextBox txtBM_ID_Partner;

	private CheckBox cbShareParterBM;

	private SplitContainer splitContainer1;

	private Label label4;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmPageManager(List<string> listSelect, frmAdsManager frmCamp)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.listSelect = listSelect;
		base._002Ector();
		InitializeComponent<ComponentResourceManager, Container, DataGridView, NumericUpDown, Label, Button, TextBox, CheckBox, StatusStrip, ToolStripStatusLabel, TabControl, TabPage, SplitContainer, int, decimal, object, EventArgs, bool, string, Dictionary<string, string>, Exception, ToolStripItem, Icon, FormClosingEventArgs>();
		frm = frmCamp;
		ListAds = frmCamp.Pages.Where(_003C_003Ec__DisplayClass4_._003C_002Ector_003Eb__0<bool>).ToList();
		gvData.AutoGenerateColumns = false;
		gvData.Columns.Clear();
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "Id");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Pro5 Id", "additional_profile_id");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Trạng thái", "message");
		gvData.DataSource = ListAds;
		lbQuantity.Text = ListAds.Count.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenColumn<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvData.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T2 val3 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvData.Columns.Add((DataGridViewColumn)val3);
		}
	}

	private void cbKichPro5_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		KichPro5 = cbKichPro5.Checked;
		T0 val = (T0)KichPro5;
		if (val != null)
		{
			cbKichPro5.ForeColor = Color.Red;
		}
		else
		{
			cbKichPro5.ForeColor = Color.Black;
		}
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
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
			new Thread(thrStart<T0, int, Thread, ParameterizedThreadStart, List<ListStringData>, List<facebook_pagesData>, List<facebook_pagesData>.Enumerator, List<ListStringData>.Enumerator, Dictionary<string, string>, string, ReadOnlyCollection<IWebElement>, IWebElement, Exception, List<object>, List<TokenEntity>.Enumerator, List<string>, IJavaScriptExecutor, ICollection<object>, char, T1>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void thrStart<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>()
	{
		//IL_000f: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected I4, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00cb: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected I4, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01b8: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_0202: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_0242: Expected O, but got I4
		//IL_0287: Expected O, but got I4
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected I4, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02a8: Expected O, but got I4
		//IL_02b1: Expected O, but got I4
		//IL_02e9: Expected O, but got I4
		//IL_02f3: Expected O, but got I4
		//IL_02fb: Expected O, but got I4
		//IL_0302: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_031c: Expected O, but got I4
		//IL_0330: Expected I4, but got O
		//IL_035d: Expected I4, but got O
		//IL_0390: Expected I4, but got O
		//IL_039f: Expected I4, but got O
		//IL_03c4: Expected I4, but got O
		//IL_03de: Expected I4, but got O
		//IL_0403: Expected I4, but got O
		//IL_0415: Expected O, but got I4
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_0430: Expected O, but got I4
		//IL_043c: Expected O, but got I4
		//IL_0469: Expected O, but got I4
		//IL_047a: Expected O, but got I4
		//IL_048a: Expected O, but got I4
		//IL_049e: Expected I4, but got O
		//IL_04cb: Expected I4, but got O
		//IL_04ee: Expected I4, but got O
		//IL_0513: Expected I4, but got O
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_0540: Expected O, but got I4
		//IL_054c: Expected O, but got I4
		//IL_0579: Expected O, but got I4
		//IL_0599: Expected O, but got I4
		//IL_05a9: Expected O, but got I4
		//IL_05bd: Expected I4, but got O
		//IL_05ea: Expected I4, but got O
		//IL_060b: Expected I4, but got O
		//IL_0630: Expected I4, but got O
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_065d: Expected O, but got I4
		//IL_067f: Expected O, but got I4
		//IL_06ac: Expected O, but got I4
		//IL_06bd: Expected O, but got I4
		//IL_06c5: Expected O, but got I4
		//IL_06fd: Expected O, but got I4
		//IL_0742: Expected O, but got I4
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Expected I4, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Expected O, but got Unknown
		//IL_0763: Expected O, but got I4
		//IL_076f: Expected O, but got I4
		//IL_079c: Expected O, but got I4
		//IL_07ad: Expected O, but got I4
		//IL_07b5: Expected O, but got I4
		//IL_07ed: Expected O, but got I4
		//IL_0832: Expected O, but got I4
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected I4, but got Unknown
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Expected O, but got Unknown
		//IL_0853: Expected O, but got I4
		//IL_085c: Expected O, but got I4
		//IL_0889: Expected O, but got I4
		//IL_0893: Expected O, but got I4
		//IL_08a2: Expected I4, but got O
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Expected O, but got Unknown
		//IL_08ce: Expected O, but got I4
		//IL_08dc: Expected O, but got I4
		//IL_08e4: Expected O, but got I4
		//IL_091c: Expected O, but got I4
		//IL_0961: Expected O, but got I4
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Expected I4, but got Unknown
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0971: Expected O, but got Unknown
		//IL_0982: Expected O, but got I4
		//IL_098e: Expected O, but got I4
		//IL_09c6: Expected O, but got I4
		//IL_09e1: Expected O, but got I4
		//IL_09f2: Expected O, but got I4
		//IL_0a04: Expected O, but got I4
		//IL_0a18: Expected I4, but got O
		//IL_0a43: Expected I4, but got O
		//IL_0a87: Expected O, but got I4
		//IL_0a91: Expected O, but got I4
		//IL_0a99: Expected O, but got I4
		//IL_0aa0: Expected O, but got I4
		//IL_0b6f: Expected O, but got I4
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfe: Expected O, but got Unknown
		//IL_0c0f: Expected O, but got I4
		T0 val = (T0)1;
		int countThread = 0;
		T0 val2 = (T0)KichPro5;
		if (val2 != null)
		{
			countThread = 0;
			T1 val3 = (T1)0;
			while (true)
			{
				T0 val4 = (T0)((nint)val3 < ListAds.Count);
				if (val4 == null)
				{
					break;
				}
				while (true)
				{
					T0 val5 = (T0)(isRunning && countThread >= intThread);
					if (val5 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val6 = (T0)(!isRunning);
				if (val6 != null)
				{
					break;
				}
				T2 val7 = (T2)new Thread((ParameterizedThreadStart)delegate(T19 obj)
				{
					//IL_000c: Expected O, but got I4
					//IL_001d: Expected I4, but got O
					//IL_0052: Expected I4, but got O
					//IL_0071: Expected I4, but got O
					//IL_0099: Expected I4, but got O
					//IL_00b5: Expected O, but got I4
					//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Expected I4, but got Unknown
					T1 val99 = (T1)int.Parse(obj.ToString());
					ListAds[(int)val99].message = STATUS.Processing.ToString();
					T0 val100 = frm.chrome.kich_page_pro_5<T0, T8, T9>((T9)ListAds[(int)val99].id);
					if (val100 != null)
					{
						ListAds[(int)val99].message = STATUS.Done.ToString();
					}
					else
					{
						ListAds[(int)val99].message = STATUS.lỗi.ToString();
					}
					T1 val101 = (T1)countThread;
					countThread = val101 - 1;
				});
				((Thread)val7).Start((object)val3);
				T1 val8 = (T1)countThread;
				countThread = val8 + 1;
				val3 = (T1)(val3 + 1);
			}
		}
		while (true)
		{
			T0 val9 = (T0)(isRunning && countThread > 0);
			if (val9 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val10 = (T0)VisiablePage;
		if (val10 != null)
		{
			countThread = 0;
			T1 val11 = (T1)0;
			while (true)
			{
				T0 val12 = (T0)((nint)val11 < ListAds.Count);
				if (val12 == null)
				{
					break;
				}
				while (true)
				{
					T0 val13 = (T0)(isRunning && countThread >= intThread);
					if (val13 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val14 = (T0)(!isRunning);
				if (val14 != null)
				{
					break;
				}
				T2 val15 = (T2)new Thread((ParameterizedThreadStart)delegate(T19 obj)
				{
					//IL_000c: Expected O, but got I4
					//IL_001d: Expected I4, but got O
					//IL_0052: Expected I4, but got O
					//IL_0071: Expected I4, but got O
					//IL_0099: Expected I4, but got O
					//IL_00b5: Expected O, but got I4
					//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Expected I4, but got Unknown
					T1 val96 = (T1)int.Parse(obj.ToString());
					ListAds[(int)val96].message = STATUS.Processing.ToString();
					T0 val97 = frm.chrome.dang_trang<T0, T8, T9>((T9)ListAds[(int)val96].id);
					if (val97 == null)
					{
						ListAds[(int)val96].message = STATUS.lỗi.ToString();
					}
					else
					{
						ListAds[(int)val96].message = STATUS.Done.ToString();
					}
					T1 val98 = (T1)countThread;
					countThread = val98 - 1;
				});
				((Thread)val15).Start((object)val11);
				T1 val8 = (T1)countThread;
				countThread = val8 + 1;
				val11 = (T1)(val11 + 1);
			}
		}
		while (true)
		{
			T0 val16 = (T0)(isRunning && countThread > 0);
			if (val16 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val17 = (T0)UnVisiablePage;
		if (val17 != null)
		{
			countThread = 0;
			T1 val18 = (T1)0;
			while (true)
			{
				T0 val19 = (T0)((nint)val18 < ListAds.Count);
				if (val19 == null)
				{
					break;
				}
				while (true)
				{
					T0 val20 = (T0)(isRunning && countThread >= intThread);
					if (val20 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val21 = (T0)(!isRunning);
				if (val21 != null)
				{
					break;
				}
				T2 val22 = (T2)new Thread((ParameterizedThreadStart)delegate(T19 obj)
				{
					//IL_000c: Expected O, but got I4
					//IL_001d: Expected I4, but got O
					//IL_0052: Expected I4, but got O
					//IL_0071: Expected I4, but got O
					//IL_0099: Expected I4, but got O
					//IL_00b5: Expected O, but got I4
					//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Expected I4, but got Unknown
					T1 val93 = (T1)int.Parse(obj.ToString());
					ListAds[(int)val93].message = STATUS.Processing.ToString();
					T0 val94 = frm.chrome.huy_dang_trang<T0, T8, T9>((T9)ListAds[(int)val93].id);
					if (val94 == null)
					{
						ListAds[(int)val93].message = STATUS.lỗi.ToString();
					}
					else
					{
						ListAds[(int)val93].message = STATUS.Done.ToString();
					}
					T1 val95 = (T1)countThread;
					countThread = val95 - 1;
				});
				((Thread)val22).Start((object)val18);
				T1 val8 = (T1)countThread;
				countThread = val8 + 1;
				val18 = (T1)(val18 + 1);
			}
		}
		while (true)
		{
			T0 val23 = (T0)(isRunning && countThread > 0);
			if (val23 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val24 = (T0)(SharePermistion || ShareContentPermistion);
		if (val24 != null)
		{
			T0 isFull = (T0)0;
			T0 val25 = (T0)SharePermistion;
			if (val25 != null)
			{
				isFull = (T0)1;
			}
			countThread = 0;
			T1 val26 = (T1)0;
			while (true)
			{
				T0 val27 = (T0)((nint)val26 < ListAds.Count);
				if (val27 != null)
				{
					T0 val28 = (T0)(!isRunning);
					if (val28 != null)
					{
						break;
					}
					ListAds[(int)val26].message = STATUS.Processing.ToString();
					T1 val29 = frm.chrome.phan_quyen_pro5<T1, T8, T9, T0>((T9)ListAds[(int)val26].additional_profile_id, (T9)UID_Permistion, isFull);
					T1 val30 = val29;
					T1 val31 = val30;
					switch ((int)val31)
					{
					case 0:
						ListAds[(int)val26].message = STATUS.Done.ToString();
						break;
					case 1:
						ListAds[(int)val26].message = "Sai password";
						break;
					case 2:
						ListAds[(int)val26].message = STATUS.lỗi.ToString();
						break;
					case 3:
						ListAds[(int)val26].message = "Chuyển pro5 lỗi";
						break;
					}
					T0 val32 = (T0)(val29 != null);
					if (val32 != null)
					{
						break;
					}
					val26 = (T1)(val26 + 1);
					continue;
				}
				break;
			}
		}
		while (true)
		{
			T0 val33 = (T0)(isRunning && countThread > 0);
			if (val33 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val34 = (T0)boolShareParterBM;
		if (val34 != null)
		{
			countThread = 0;
			T1 val35 = (T1)0;
			while (true)
			{
				T0 val36 = (T0)((nint)val35 < ListAds.Count);
				if (val36 == null)
				{
					break;
				}
				T0 val37 = (T0)(!isRunning);
				if (val37 != null)
				{
					break;
				}
				ListAds[(int)val35].message = STATUS.Processing.ToString();
				T0 val38 = frm.chrome.Share_Page_Doi_Tac<T0, T8, T9>((T9)ListAds[(int)val35].id, (T9)BM_ID_Partner_Page);
				if (val38 == null)
				{
					ListAds[(int)val35].message = STATUS.lỗi.ToString();
				}
				else
				{
					ListAds[(int)val35].message = STATUS.Done.ToString();
				}
				val35 = (T1)(val35 + 1);
			}
		}
		while (true)
		{
			T0 val39 = (T0)(isRunning && countThread > 0);
			if (val39 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val40 = (T0)KichComunity;
		if (val40 != null)
		{
			frm.chrome.goUrl<T1, T0, T10, T11, T12, T9>((T9)"https://facebook.com");
			T1 val41 = (T1)0;
			while (true)
			{
				T0 val42 = (T0)((nint)val41 < ListAds.Count);
				if (val42 == null)
				{
					break;
				}
				T0 val43 = (T0)(!isRunning);
				if (val43 != null)
				{
					break;
				}
				ListAds[(int)val41].message = STATUS.Processing.ToString();
				T0 val44 = frm.chrome.kich_page_cong_dong<T0, T8, T9>((T9)ListAds[(int)val41].additional_profile_id);
				T0 val45 = val44;
				if (val45 == null)
				{
					ListAds[(int)val41].message = STATUS.lỗi.ToString();
				}
				else
				{
					ListAds[(int)val41].message = STATUS.Done.ToString();
				}
				val41 = (T1)(val41 + 1);
			}
			frm.chrome.goUrl<T1, T0, T10, T11, T12, T9>((T9)"https://business.facebook.com/overview/");
		}
		while (true)
		{
			T0 val46 = (T0)(isRunning && countThread > 0);
			if (val46 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val47 = (T0)boolRemovePageFromBM;
		if (val47 != null)
		{
			countThread = 0;
			T1 val48 = (T1)0;
			while (true)
			{
				T0 val49 = (T0)((nint)val48 < ListAds.Count);
				if (val49 == null)
				{
					break;
				}
				while (true)
				{
					T0 val50 = (T0)(isRunning && countThread >= intThread);
					if (val50 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val51 = (T0)(!isRunning);
				if (val51 != null)
				{
					break;
				}
				T2 val52 = (T2)new Thread((ParameterizedThreadStart)delegate(T19 obj)
				{
					//IL_000c: Expected O, but got I4
					//IL_001d: Expected I4, but got O
					//IL_0052: Expected I4, but got O
					//IL_0071: Expected I4, but got O
					//IL_0099: Expected I4, but got O
					//IL_00b5: Expected O, but got I4
					//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Expected I4, but got Unknown
					T1 val90 = (T1)int.Parse(obj.ToString());
					ListAds[(int)val90].message = STATUS.Processing.ToString();
					T0 val91 = frm.chrome.huy_dang_trang<T0, T8, T9>((T9)ListAds[(int)val90].id);
					if (val91 != null)
					{
						ListAds[(int)val90].message = STATUS.Done.ToString();
					}
					else
					{
						ListAds[(int)val90].message = STATUS.lỗi.ToString();
					}
					T1 val92 = (T1)countThread;
					countThread = val92 - 1;
				});
				((Thread)val52).Start((object)val48);
				T1 val8 = (T1)countThread;
				countThread = val8 + 1;
				val48 = (T1)(val48 + 1);
			}
		}
		while (true)
		{
			T0 val53 = (T0)(isRunning && countThread > 0);
			if (val53 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val54 = (T0)CatePage;
		if (val54 != null)
		{
			countThread = 0;
			T1 val55 = (T1)0;
			while (true)
			{
				T0 val56 = (T0)((nint)val55 < ListAds.Count);
				if (val56 == null)
				{
					break;
				}
				while (true)
				{
					T0 val57 = (T0)(isRunning && countThread >= intThread);
					if (val57 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val58 = (T0)(!isRunning);
				if (val58 != null)
				{
					break;
				}
				T2 val59 = (T2)new Thread((ParameterizedThreadStart)delegate(T19 obj)
				{
					//IL_000c: Expected O, but got I4
					//IL_001d: Expected I4, but got O
					//IL_0052: Expected I4, but got O
					//IL_007c: Expected I4, but got O
					//IL_00a4: Expected I4, but got O
					//IL_00c0: Expected O, but got I4
					//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c9: Expected I4, but got Unknown
					T1 val87 = (T1)int.Parse(obj.ToString());
					ListAds[(int)val87].message = STATUS.Processing.ToString();
					T0 val88 = frm.chrome.doi_category_page<T0, T8, T9, T1, T18>((T9)ListAds[(int)val87].id, (T9)strCatePage);
					if (val88 == null)
					{
						ListAds[(int)val87].message = STATUS.lỗi.ToString();
					}
					else
					{
						ListAds[(int)val87].message = STATUS.Done.ToString();
					}
					T1 val89 = (T1)countThread;
					countThread = val89 - 1;
				});
				((Thread)val59).Start((object)val55);
				T1 val8 = (T1)countThread;
				countThread = val8 + 1;
				val55 = (T1)(val55 + 1);
			}
		}
		while (true)
		{
			T0 val60 = (T0)(isRunning && countThread > 0);
			if (val60 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val61 = (T0)ChangePageName;
		if (val61 != null)
		{
			T1 val62 = (T1)0;
			while (true)
			{
				T0 val63 = (T0)((nint)val62 < ListAds.Count);
				if (val63 == null)
				{
					break;
				}
				ListAds[(int)val62].message = STATUS.Ready.ToString();
				val62 = (T1)(val62 + 1);
			}
			countThread = 0;
			T1 val64 = (T1)0;
			while (true)
			{
				T0 val65 = (T0)((nint)val64 < ListAds.Count);
				if (val65 == null)
				{
					break;
				}
				while (true)
				{
					T0 val66 = (T0)(isRunning && countThread >= intThread);
					if (val66 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T0 val67 = (T0)(!isRunning);
				if (val67 != null)
				{
					break;
				}
				T2 val68 = (T2)new Thread((ParameterizedThreadStart)([MethodImpl(MethodImplOptions.NoInlining)] (T19 obj) =>
				{
					//IL_000c: Expected O, but got I4
					//IL_001d: Expected I4, but got O
					//IL_0072: Expected O, but got I4
					//IL_00b9: Expected O, but got I4
					//IL_00ce: Expected I4, but got O
					//IL_0106: Expected I4, but got O
					//IL_011c: Expected I4, but got O
					//IL_0140: Expected I4, but got O
					//IL_0166: Expected I4, but got O
					//IL_017d: Expected I4, but got O
					//IL_0196: Expected I4, but got O
					//IL_01a5: Expected O, but got I4
					//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
					//IL_01af: Expected I4, but got Unknown
					T1 val81 = (T1)int.Parse(obj.ToString());
					ListAds[(int)val81].message = STATUS.Processing.ToString();
					T9 val82 = (T9)"";
					T7 enumerator4 = (T7)listPageName.GetEnumerator();
					try
					{
						while (((List<ListStringData>.Enumerator*)(&enumerator4))->MoveNext())
						{
							ListStringData current4 = ((List<ListStringData>.Enumerator*)(&enumerator4))->Current;
							T0 val83 = (T0)current4.str2.Equals(frmMain.STATUS.Ready.ToString());
							if (val83 != null)
							{
								current4.str2 = frmMain.STATUS.Processing.ToString();
								val82 = (T9)current4.str1;
								break;
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<ListStringData>.Enumerator*)(&enumerator4))).Dispose();
					}
					T0 val84 = (T0)string.IsNullOrWhiteSpace((string)val82);
					if (val84 != null)
					{
						ListAds[(int)val81].message = "Thiếu tên page";
					}
					else
					{
						T9 message = (T9)"";
						T0 val85 = frm.chrome.doi_ten_page<T0, T8, T9>((T9)ListAds[(int)val81].id, (T9)ListAds[(int)val81].additional_profile_id, val82, out *(string*)(&message));
						if (val85 != null)
						{
							ListAds[(int)val81].message = STATUS.Done.ToString();
							ListAds[(int)val81].name_with_location_descriptor = (string)val82;
							ListAds[(int)val81].name = (string)val82;
						}
						else
						{
							ListAds[(int)val81].message = (string)message;
						}
					}
					T1 val86 = (T1)countThread;
					countThread = val86 - 1;
				}));
				((Thread)val68).Start((object)val64);
				T1 val8 = (T1)countThread;
				countThread = val8 + 1;
				val64 = (T1)(val64 + 1);
			}
		}
		while (true)
		{
			T0 val69 = (T0)(isRunning && countThread > 0);
			if (val69 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		T0 val70 = (T0)(SharePageThuongAPI || ShareAdminPageThuong);
		if (val70 != null)
		{
			T4 val71 = (T4)Activator.CreateInstance(typeof(T4));
			T1 val72 = (T1)0;
			while (true)
			{
				T0 val73 = (T0)((nint)val72 < ListAds.Count);
				if (val73 == null)
				{
					break;
				}
				T0 val74 = (T0)(!isRunning);
				if (val74 != null)
				{
					return;
				}
				ListAds[(int)val72].message = STATUS.Processing.ToString();
				ListStringData listStringData = new ListStringData();
				listStringData.str1 = ListAds[(int)val72].id;
				((List<ListStringData>)val71).Add(listStringData);
				T0 val75 = (T0)((((List<ListStringData>)val71).Count >= intThread || (nint)val72 == ListAds.Count - 1) && ((List<ListStringData>)val71).Count > 0);
				if (val75 != null)
				{
					T0 isAutoReceiptPage = (T0)1;
					T0 val76 = (T0)ShareAdminPageThuong;
					if (val76 != null)
					{
						isAutoReceiptPage = (T0)0;
					}
					val = frm.chrome.share_page_thuong_Promise<T0, T9, T13, T7, T14, T8, T15, T1, T12, T4, T16, T17, T18, T19>(val71, isAutoReceiptPage);
					T5 val77 = (T5)ListAds.Join((IEnumerable<ListStringData>)val71, (Func<facebook_pagesData, T9>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T9)a.id), (Func<ListStringData, T9>)(object)(Func<ListStringData, string>)((ListStringData d) => (T9)d.str1), (facebook_pagesData a, ListStringData d) => a).ToList();
					T0 val78 = val;
					if (val78 != null)
					{
						T6 enumerator = (T6)((List<facebook_pagesData>)val77).GetEnumerator();
						try
						{
							while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
							{
								facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
								T7 enumerator2 = (T7)((List<ListStringData>)val71).GetEnumerator();
								try
								{
									while (((List<ListStringData>.Enumerator*)(&enumerator2))->MoveNext())
									{
										ListStringData current2 = ((List<ListStringData>.Enumerator*)(&enumerator2))->Current;
										T0 val79 = (T0)current.id.Equals(current2.str1);
										if (val79 != null)
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
							((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
						}
					}
					else
					{
						T6 enumerator3 = (T6)((List<facebook_pagesData>)val77).GetEnumerator();
						try
						{
							while (((List<facebook_pagesData>.Enumerator*)(&enumerator3))->MoveNext())
							{
								facebook_pagesData current3 = ((List<facebook_pagesData>.Enumerator*)(&enumerator3))->Current;
								current3.message = frmMain.STATUS.lỗi.ToString();
							}
						}
						finally
						{
							((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
					((List<ListStringData>)val71).Clear();
				}
				val72 = (T1)(val72 + 1);
			}
		}
		while (true)
		{
			T0 val80 = (T0)(isRunning && countThread > 0);
			if (val80 == null)
			{
				break;
			}
			Thread.Sleep(1500);
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

	private void cbCatePage_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		CatePage = cbCatePage.Checked;
		T0 val = (T0)CatePage;
		if (val != null)
		{
			cbCatePage.ForeColor = Color.Red;
		}
		else
		{
			cbCatePage.ForeColor = Color.Black;
		}
	}

	private void groupBox1_Enter<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtCatePage_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strCatePage = txtCatePage.Text;
	}

	private void frmPageManager_FormClosing<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage = int.Parse(((decimal)(T1)numThread.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strCatePage = txtCatePage.Text;
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].BM_ID_Partner_Page = txtBM_ID_Partner.Text;
		}
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmPageManager_Load<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_00f9: Expected I4, but got O
		//IL_0133: Expected O, but got I4
		T0 val = (T0)(frm.chrome != null);
		if (val != null)
		{
			T0 val2 = (T0)(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage == 0);
			if (val2 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage = 10;
			}
			txtBM_ID_Partner.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].BM_ID_Partner_Page;
			NumericUpDown numericUpDown = numThread;
			int numThreadPage = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].numThreadPage;
			T1 val3 = (T1)numThreadPage;
			intThread = numThreadPage;
			numericUpDown.Value = (int)val3;
			T0 val4 = (T0)string.IsNullOrWhiteSpace(frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strCatePage);
			if (val4 != null)
			{
				frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strCatePage = "1701,161422927240513";
			}
			T2 val5 = (T2)(txtCatePage.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strCatePage);
			strCatePage = (string)val5;
			val5 = (T2)(txtRemovePageFromBM.Text = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].strRemovePageFromBM);
			strRemovePageFromBM = (string)val5;
		}
	}

	private void cbSharePermistion_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SharePermistion = cbSharePermistion.Checked;
		T0 val = (T0)SharePermistion;
		if (val != null)
		{
			cbSharePermistion.ForeColor = Color.Red;
		}
		else
		{
			cbSharePermistion.ForeColor = Color.Black;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtUID_Permistion_TextChanged<T0, T1, T2, T3, T4, T5>(T2 sender, T3 e)
	{
		//IL_003a: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		UID_Permistion = txtUID_Permistion.Text;
		T0 value = (T0)Regex.Match(UID_Permistion, "\\d+").Value;
		T1 val = (T1)UID_Permistion.Contains("profile.php?id");
		if (val != null)
		{
			UID_Permistion = ((string)value).Trim();
			txtUID_Permistion.Text = UID_Permistion;
			return;
		}
		T1 val2 = (T1)UID_Permistion.Contains(".com");
		if (val2 != null)
		{
			UID_Permistion = (string)frm.chrome.getUID_FromLink<T0, T4, T5>((T0)UID_Permistion);
			txtUID_Permistion.Text = UID_Permistion;
		}
	}

	private void checkBox1_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void cbVisiablePage_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		VisiablePage = cbVisiablePage.Checked;
		T0 val = (T0)VisiablePage;
		if (val == null)
		{
			cbVisiablePage.ForeColor = Color.Black;
		}
		else
		{
			cbVisiablePage.ForeColor = Color.Red;
		}
	}

	private void cbUnVisiablePage_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		UnVisiablePage = cbUnVisiablePage.Checked;
		T0 val = (T0)UnVisiablePage;
		if (val != null)
		{
			cbUnVisiablePage.ForeColor = Color.Red;
		}
		else
		{
			cbUnVisiablePage.ForeColor = Color.Black;
		}
	}

	private void cbShareContentPermistion_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShareContentPermistion = cbShareContentPermistion.Checked;
		T0 val = (T0)ShareContentPermistion;
		if (val == null)
		{
			cbShareContentPermistion.ForeColor = Color.Black;
		}
		else
		{
			cbShareContentPermistion.ForeColor = Color.Red;
		}
	}

	private void cbKichComunity_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		KichComunity = cbKichComunity.Checked;
		T0 val = (T0)KichComunity;
		if (val != null)
		{
			cbKichComunity.ForeColor = Color.Red;
		}
		else
		{
			cbKichComunity.ForeColor = Color.Black;
		}
	}

	private void cbRemovePageFromBM_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		boolRemovePageFromBM = cbRemovePageFromBM.Checked;
		T0 val = (T0)boolRemovePageFromBM;
		if (val != null)
		{
			cbRemovePageFromBM.ForeColor = Color.Red;
		}
		else
		{
			cbRemovePageFromBM.ForeColor = Color.Black;
		}
	}

	private void txtRemovePageFromBM_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		strRemovePageFromBM = txtRemovePageFromBM.Text;
	}

	private void cbChangePageName_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ChangePageName = cbChangePageName.Checked;
		T0 val = (T0)ChangePageName;
		if (val == null)
		{
			cbChangePageName.ForeColor = Color.Black;
		}
		else
		{
			cbChangePageName.ForeColor = Color.Red;
		}
	}

	private void txtPageName_TextChanged<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_007b: Expected O, but got I4
		listPageName.Clear();
		T0[] lines = (T0[])(object)txtPageName.Lines;
		T1 val = (T1)0;
		while ((nint)val < lines.Length)
		{
			T0 val2 = (T0)((object[])(object)lines)[(object)val];
			T2 val3 = (T2)(!string.IsNullOrWhiteSpace((string)val2));
			if (val3 != null)
			{
				listPageName.Add(new ListStringData
				{
					str1 = ((string)val2).Trim(),
					str2 = frmMain.STATUS.Ready.ToString()
				});
			}
			val = (T1)(val + 1);
		}
		lbTotalPageName.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)listPageName.Count).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtViaPageThuong_TextChanged<T0, T1, T2, T3, T4, T5>(T2 sender, T3 e)
	{
		//IL_003a: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		ViaPageThuong = txtViaPageThuong.Text;
		T0 value = (T0)Regex.Match(ViaPageThuong, "\\d+").Value;
		T1 val = (T1)ViaPageThuong.Contains("profile.php?id");
		if (val == null)
		{
			T1 val2 = (T1)ViaPageThuong.Contains(".com");
			if (val2 != null)
			{
				ViaPageThuong = (string)frm.chrome.getUID_FromLink<T0, T4, T5>((T0)ViaPageThuong);
				txtViaPageThuong.Text = ViaPageThuong;
			}
		}
		else
		{
			ViaPageThuong = ((string)value).Trim();
			txtViaPageThuong.Text = ViaPageThuong;
		}
	}

	private void cbShareAdminPageThuong_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShareAdminPageThuong = cbShareAdminPageThuong.Checked;
		T0 val = (T0)ShareAdminPageThuong;
		if (val == null)
		{
			cbShareAdminPageThuong.ForeColor = Color.Black;
		}
		else
		{
			cbShareAdminPageThuong.ForeColor = Color.Red;
		}
	}

	private void cbShareContentPageThuong_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		ShareContentPageThuong = cbShareContentPageThuong.Checked;
		T0 val = (T0)ShareContentPageThuong;
		if (val == null)
		{
			cbShareContentPageThuong.ForeColor = Color.Black;
		}
		else
		{
			cbShareContentPageThuong.ForeColor = Color.Red;
		}
	}

	private void cbSharePageThuongAPI_CheckedChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		SharePageThuongAPI = cbSharePageThuongAPI.Checked;
		T0 val = (T0)SharePageThuongAPI;
		if (val != null)
		{
			cbSharePageThuongAPI.ForeColor = Color.Red;
		}
		else
		{
			cbSharePageThuongAPI.ForeColor = Color.Black;
		}
	}

	private void cbShareParterBM_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		boolShareParterBM = cbShareParterBM.Checked;
	}

	private void txtBM_ID_Partner_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		BM_ID_Partner_Page = txtBM_ID_Partner.Text;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmPageManager));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lbTotalPageName = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtPageName = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbChangePageName = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbRemovePageFromBM = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtRemovePageFromBM = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbKichComunity = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbShareContentPermistion = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.checkBox1 = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbUnVisiablePage = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbVisiablePage = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtUID_Permistion = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbSharePermistion = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtCatePage = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbCatePage = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbKichPro5 = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbQuantity = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.tabControl1 = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabPage1 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.txtBM_ID_Partner = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.cbShareParterBM = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.tabPage2 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.cbSharePageThuongAPI = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.cbShareAdminPageThuong = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.txtViaPageThuong = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbShareContentPageThuong = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		this.statusStrip1.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.tabPage2.SuspendLayout();
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
		this.gvData.Size = new System.Drawing.Size(531, 764);
		this.gvData.TabIndex = 5;
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(366, 745);
		this.numThread.Margin = new System.Windows.Forms.Padding(4);
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(179, 22);
		this.numThread.TabIndex = 39;
		this.numThread.Value = new decimal((int[])(object)new T13[4]
		{
			(T13)1,
			default(T13),
			default(T13),
			default(T13)
		});
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T14, T15, T16>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(304, 747);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 16);
		this.label2.TabIndex = 38;
		this.label2.Text = "Luồng:";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.DodgerBlue;
		this.button1.Location = new System.Drawing.Point(552, 704);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 65);
		this.button1.TabIndex = 37;
		this.button1.Text = "START";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click<T17, T15, T16>);
		this.lbTotalPageName.AutoSize = true;
		this.lbTotalPageName.Location = new System.Drawing.Point(132, 159);
		this.lbTotalPageName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotalPageName.Name = "lbTotalPageName";
		this.lbTotalPageName.Size = new System.Drawing.Size(14, 16);
		this.lbTotalPageName.TabIndex = 45;
		this.lbTotalPageName.Text = "0";
		this.txtPageName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtPageName.Location = new System.Drawing.Point(8, 186);
		this.txtPageName.Margin = new System.Windows.Forms.Padding(4);
		this.txtPageName.Multiline = true;
		this.txtPageName.Name = "txtPageName";
		this.txtPageName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtPageName.Size = new System.Drawing.Size(436, 470);
		this.txtPageName.TabIndex = 44;
		this.txtPageName.TextChanged += new System.EventHandler(txtPageName_TextChanged<T18, T13, T17, T15, T16>);
		this.cbChangePageName.AutoSize = true;
		this.cbChangePageName.Location = new System.Drawing.Point(8, 158);
		this.cbChangePageName.Margin = new System.Windows.Forms.Padding(4);
		this.cbChangePageName.Name = "cbChangePageName";
		this.cbChangePageName.Size = new System.Drawing.Size(105, 20);
		this.cbChangePageName.TabIndex = 43;
		this.cbChangePageName.Text = "Đổi tên page";
		this.cbChangePageName.UseVisualStyleBackColor = true;
		this.cbChangePageName.CheckedChanged += new System.EventHandler(cbChangePageName_CheckedChanged<T17, T15, T16>);
		this.cbRemovePageFromBM.AutoSize = true;
		this.cbRemovePageFromBM.Location = new System.Drawing.Point(8, 129);
		this.cbRemovePageFromBM.Margin = new System.Windows.Forms.Padding(4);
		this.cbRemovePageFromBM.Name = "cbRemovePageFromBM";
		this.cbRemovePageFromBM.Size = new System.Drawing.Size(182, 20);
		this.cbRemovePageFromBM.TabIndex = 42;
		this.cbRemovePageFromBM.Text = "Đá Page khỏi BM. BM_ID:";
		this.cbRemovePageFromBM.UseVisualStyleBackColor = true;
		this.cbRemovePageFromBM.CheckedChanged += new System.EventHandler(cbRemovePageFromBM_CheckedChanged<T17, T15, T16>);
		this.txtRemovePageFromBM.Location = new System.Drawing.Point(219, 127);
		this.txtRemovePageFromBM.Margin = new System.Windows.Forms.Padding(4);
		this.txtRemovePageFromBM.Name = "txtRemovePageFromBM";
		this.txtRemovePageFromBM.Size = new System.Drawing.Size(225, 22);
		this.txtRemovePageFromBM.TabIndex = 41;
		this.txtRemovePageFromBM.TextChanged += new System.EventHandler(txtRemovePageFromBM_TextChanged);
		this.cbKichComunity.AutoSize = true;
		this.cbKichComunity.Location = new System.Drawing.Point(161, 38);
		this.cbKichComunity.Margin = new System.Windows.Forms.Padding(4);
		this.cbKichComunity.Name = "cbKichComunity";
		this.cbKichComunity.Size = new System.Drawing.Size(121, 20);
		this.cbKichComunity.TabIndex = 40;
		this.cbKichComunity.Text = "Kích cộng đồng";
		this.cbKichComunity.UseVisualStyleBackColor = true;
		this.cbKichComunity.CheckedChanged += new System.EventHandler(cbKichComunity_CheckedChanged<T17, T15, T16>);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(4, 96);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(81, 16);
		this.label1.TabIndex = 39;
		this.label1.Text = "Phân quyền:";
		this.cbShareContentPermistion.AutoSize = true;
		this.cbShareContentPermistion.Location = new System.Drawing.Point(243, 95);
		this.cbShareContentPermistion.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareContentPermistion.Name = "cbShareContentPermistion";
		this.cbShareContentPermistion.Size = new System.Drawing.Size(128, 20);
		this.cbShareContentPermistion.TabIndex = 38;
		this.cbShareContentPermistion.Text = "Quyền: Nội dung";
		this.cbShareContentPermistion.UseVisualStyleBackColor = true;
		this.cbShareContentPermistion.CheckedChanged += new System.EventHandler(cbShareContentPermistion_CheckedChanged<T17, T15, T16>);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(8, 38);
		this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(101, 20);
		this.checkBox1.TabIndex = 37;
		this.checkBox1.Text = "Kích pro5 - 2";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.cbUnVisiablePage.AutoSize = true;
		this.cbUnVisiablePage.Location = new System.Drawing.Point(121, 66);
		this.cbUnVisiablePage.Margin = new System.Windows.Forms.Padding(4);
		this.cbUnVisiablePage.Name = "cbUnVisiablePage";
		this.cbUnVisiablePage.Size = new System.Drawing.Size(120, 20);
		this.cbUnVisiablePage.TabIndex = 36;
		this.cbUnVisiablePage.Text = "Hủy đăng trang";
		this.cbUnVisiablePage.UseVisualStyleBackColor = true;
		this.cbUnVisiablePage.CheckedChanged += new System.EventHandler(cbUnVisiablePage_CheckedChanged<T17, T15, T16>);
		this.cbVisiablePage.AutoSize = true;
		this.cbVisiablePage.Location = new System.Drawing.Point(8, 66);
		this.cbVisiablePage.Margin = new System.Windows.Forms.Padding(4);
		this.cbVisiablePage.Name = "cbVisiablePage";
		this.cbVisiablePage.Size = new System.Drawing.Size(94, 20);
		this.cbVisiablePage.TabIndex = 35;
		this.cbVisiablePage.Text = "Đăng trang";
		this.cbVisiablePage.UseVisualStyleBackColor = true;
		this.cbVisiablePage.CheckedChanged += new System.EventHandler(cbVisiablePage_CheckedChanged<T17, T15, T16>);
		this.txtUID_Permistion.Location = new System.Drawing.Point(392, 95);
		this.txtUID_Permistion.Margin = new System.Windows.Forms.Padding(4);
		this.txtUID_Permistion.Name = "txtUID_Permistion";
		this.txtUID_Permistion.Size = new System.Drawing.Size(225, 22);
		this.txtUID_Permistion.TabIndex = 34;
		this.txtUID_Permistion.TextChanged += new System.EventHandler(txtUID_Permistion_TextChanged<T18, T17, T15, T16, T19, T20>);
		this.cbSharePermistion.AutoSize = true;
		this.cbSharePermistion.Location = new System.Drawing.Point(101, 95);
		this.cbSharePermistion.Margin = new System.Windows.Forms.Padding(4);
		this.cbSharePermistion.Name = "cbSharePermistion";
		this.cbSharePermistion.Size = new System.Drawing.Size(119, 20);
		this.cbSharePermistion.TabIndex = 33;
		this.cbSharePermistion.Text = "Quyền: Quản trị";
		this.cbSharePermistion.UseVisualStyleBackColor = true;
		this.cbSharePermistion.CheckedChanged += new System.EventHandler(cbSharePermistion_CheckedChanged<T17, T15, T16>);
		this.txtCatePage.Location = new System.Drawing.Point(340, 7);
		this.txtCatePage.Margin = new System.Windows.Forms.Padding(4);
		this.txtCatePage.Name = "txtCatePage";
		this.txtCatePage.Size = new System.Drawing.Size(277, 22);
		this.txtCatePage.TabIndex = 31;
		this.txtCatePage.Text = "1701,161422927240513";
		this.txtCatePage.TextChanged += new System.EventHandler(txtCatePage_TextChanged);
		this.cbCatePage.AutoSize = true;
		this.cbCatePage.Location = new System.Drawing.Point(161, 7);
		this.cbCatePage.Margin = new System.Windows.Forms.Padding(4);
		this.cbCatePage.Name = "cbCatePage";
		this.cbCatePage.Size = new System.Drawing.Size(152, 20);
		this.cbCatePage.TabIndex = 30;
		this.cbCatePage.Text = "Đổi loại page \"1,2,3\":";
		this.cbCatePage.UseVisualStyleBackColor = true;
		this.cbCatePage.CheckedChanged += new System.EventHandler(cbCatePage_CheckedChanged<T17, T15, T16>);
		this.cbKichPro5.AutoSize = true;
		this.cbKichPro5.Location = new System.Drawing.Point(8, 10);
		this.cbKichPro5.Margin = new System.Windows.Forms.Padding(4);
		this.cbKichPro5.Name = "cbKichPro5";
		this.cbKichPro5.Size = new System.Drawing.Size(101, 20);
		this.cbKichPro5.TabIndex = 29;
		this.cbKichPro5.Text = "Kích pro5 - 1";
		this.cbKichPro5.UseVisualStyleBackColor = true;
		this.cbKichPro5.CheckedChanged += new System.EventHandler(cbKichPro5_CheckedChanged<T17, T15, T16>);
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer_auto_refesh_Tick<T17, T15, T16>);
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[2]
		{
			(T21)this.toolStripStatusLabel1,
			(T21)this.lbQuantity
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 788);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
		this.statusStrip1.Size = new System.Drawing.Size(1211, 26);
		this.statusStrip1.TabIndex = 41;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbQuantity.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbQuantity.Name = "lbQuantity";
		this.lbQuantity.Size = new System.Drawing.Size(18, 20);
		this.lbQuantity.Text = "0";
		this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Location = new System.Drawing.Point(4, 5);
		this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(648, 697);
		this.tabControl1.TabIndex = 42;
		this.tabPage1.Controls.Add(this.txtBM_ID_Partner);
		this.tabPage1.Controls.Add(this.cbShareParterBM);
		this.tabPage1.Controls.Add(this.lbTotalPageName);
		this.tabPage1.Controls.Add(this.cbCatePage);
		this.tabPage1.Controls.Add(this.txtPageName);
		this.tabPage1.Controls.Add(this.cbKichPro5);
		this.tabPage1.Controls.Add(this.cbChangePageName);
		this.tabPage1.Controls.Add(this.txtCatePage);
		this.tabPage1.Controls.Add(this.cbRemovePageFromBM);
		this.tabPage1.Controls.Add(this.cbSharePermistion);
		this.tabPage1.Controls.Add(this.txtRemovePageFromBM);
		this.tabPage1.Controls.Add(this.txtUID_Permistion);
		this.tabPage1.Controls.Add(this.cbKichComunity);
		this.tabPage1.Controls.Add(this.cbVisiablePage);
		this.tabPage1.Controls.Add(this.label1);
		this.tabPage1.Controls.Add(this.cbUnVisiablePage);
		this.tabPage1.Controls.Add(this.cbShareContentPermistion);
		this.tabPage1.Controls.Add(this.checkBox1);
		this.tabPage1.Location = new System.Drawing.Point(4, 25);
		this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
		this.tabPage1.Size = new System.Drawing.Size(640, 668);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Page Pro5";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.txtBM_ID_Partner.Location = new System.Drawing.Point(457, 39);
		this.txtBM_ID_Partner.Margin = new System.Windows.Forms.Padding(4);
		this.txtBM_ID_Partner.Name = "txtBM_ID_Partner";
		this.txtBM_ID_Partner.Size = new System.Drawing.Size(163, 22);
		this.txtBM_ID_Partner.TabIndex = 46;
		this.txtBM_ID_Partner.TextChanged += new System.EventHandler(txtBM_ID_Partner_TextChanged);
		this.cbShareParterBM.AutoSize = true;
		this.cbShareParterBM.Location = new System.Drawing.Point(304, 42);
		this.cbShareParterBM.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareParterBM.Name = "cbShareParterBM";
		this.cbShareParterBM.Size = new System.Drawing.Size(131, 20);
		this.cbShareParterBM.TabIndex = 47;
		this.cbShareParterBM.Text = "Share đối tác BM";
		this.cbShareParterBM.UseVisualStyleBackColor = true;
		this.cbShareParterBM.CheckedChanged += new System.EventHandler(cbShareParterBM_CheckedChanged);
		this.tabPage2.Controls.Add(this.label4);
		this.tabPage2.Controls.Add(this.cbSharePageThuongAPI);
		this.tabPage2.Controls.Add(this.cbShareAdminPageThuong);
		this.tabPage2.Controls.Add(this.txtViaPageThuong);
		this.tabPage2.Controls.Add(this.label3);
		this.tabPage2.Controls.Add(this.cbShareContentPageThuong);
		this.tabPage2.Location = new System.Drawing.Point(4, 25);
		this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
		this.tabPage2.Size = new System.Drawing.Size(640, 668);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Page Thường";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.cbSharePageThuongAPI.AutoSize = true;
		this.cbSharePageThuongAPI.ForeColor = System.Drawing.SystemColors.Highlight;
		this.cbSharePageThuongAPI.Location = new System.Drawing.Point(168, 36);
		this.cbSharePageThuongAPI.Margin = new System.Windows.Forms.Padding(4);
		this.cbSharePageThuongAPI.Name = "cbSharePageThuongAPI";
		this.cbSharePageThuongAPI.Size = new System.Drawing.Size(211, 20);
		this.cbSharePageThuongAPI.TabIndex = 44;
		this.cbSharePageThuongAPI.Text = "Phân quyền tự nhận Token API";
		this.cbSharePageThuongAPI.UseVisualStyleBackColor = true;
		this.cbSharePageThuongAPI.CheckedChanged += new System.EventHandler(cbSharePageThuongAPI_CheckedChanged<T17, T15, T16>);
		this.cbShareAdminPageThuong.AutoSize = true;
		this.cbShareAdminPageThuong.Location = new System.Drawing.Point(168, 8);
		this.cbShareAdminPageThuong.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareAdminPageThuong.Name = "cbShareAdminPageThuong";
		this.cbShareAdminPageThuong.Size = new System.Drawing.Size(119, 20);
		this.cbShareAdminPageThuong.TabIndex = 40;
		this.cbShareAdminPageThuong.Text = "Quyền: Quản trị";
		this.cbShareAdminPageThuong.UseVisualStyleBackColor = true;
		this.cbShareAdminPageThuong.CheckedChanged += new System.EventHandler(cbShareAdminPageThuong_CheckedChanged<T17, T15, T16>);
		this.txtViaPageThuong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtViaPageThuong.Location = new System.Drawing.Point(435, 6);
		this.txtViaPageThuong.Margin = new System.Windows.Forms.Padding(4);
		this.txtViaPageThuong.Name = "txtViaPageThuong";
		this.txtViaPageThuong.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtViaPageThuong.Size = new System.Drawing.Size(197, 22);
		this.txtViaPageThuong.TabIndex = 41;
		this.txtViaPageThuong.TextChanged += new System.EventHandler(txtViaPageThuong_TextChanged<T18, T17, T15, T16, T19, T20>);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(7, 9);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(136, 16);
		this.label3.TabIndex = 43;
		this.label3.Text = "Phân quyền theo UID:";
		this.cbShareContentPageThuong.AutoSize = true;
		this.cbShareContentPageThuong.Location = new System.Drawing.Point(299, 8);
		this.cbShareContentPageThuong.Margin = new System.Windows.Forms.Padding(4);
		this.cbShareContentPageThuong.Name = "cbShareContentPageThuong";
		this.cbShareContentPageThuong.Size = new System.Drawing.Size(128, 20);
		this.cbShareContentPageThuong.TabIndex = 42;
		this.cbShareContentPageThuong.Text = "Quyền: Nội dung";
		this.cbShareContentPageThuong.UseVisualStyleBackColor = true;
		this.cbShareContentPageThuong.CheckedChanged += new System.EventHandler(cbShareContentPageThuong_CheckedChanged<T17, T15, T16>);
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.Location = new System.Drawing.Point(12, 3);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.gvData);
		this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
		this.splitContainer1.Panel2.Controls.Add(this.button1);
		this.splitContainer1.Panel2.Controls.Add(this.numThread);
		this.splitContainer1.Panel2.Controls.Add(this.label2);
		this.splitContainer1.Size = new System.Drawing.Size(1199, 774);
		this.splitContainer1.SplitterDistance = 539;
		this.splitContainer1.TabIndex = 43;
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(8, 37);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(152, 16);
		this.label4.TabIndex = 45;
		this.label4.Text = "Phân quyền theo Token:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1211, 814);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.statusStrip1);
		base.Icon = (System.Drawing.Icon)(T22)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmPageManager";
		this.Text = "frmPageManager";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmPageManager_FormClosing<T17, T14, T15, T23>);
		base.Load += new System.EventHandler(frmPageManager_Load<T17, T13, T18, T15, T16>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.tabPage2.PerformLayout();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
