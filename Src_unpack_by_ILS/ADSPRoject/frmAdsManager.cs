using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.Data.BusinessManagerEntity;
using ADSPRoject.Data.PageLocations;
using ADSPRoject.Server;
using ADSPRoject.Tasking;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace ADSPRoject;

public class frmAdsManager : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public string strActList;

		public List<adaccountsData> listAct_Json;

		internal void _003CcopyIdTkEvent_003Eb__2<T0>(T0 param)
		{
			Clipboard.Clear();
			Clipboard.SetText(strActList);
		}

		internal void _003CcopyIdTkEvent_003Eb__3<T0, T1>(T1 param)
		{
			Clipboard.Clear();
			T0 text = (T0)JsonConvert.SerializeObject((object)listAct_Json);
			Clipboard.SetText((string)text);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public frmAdsManager _003C_003E4__this;

		public object amount;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__1;

		public ParameterizedThreadStart _003C_003E9__0;

		internal void _003CkichNo_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_004e: Expected I4, but got O
			//IL_007c: Expected I4, but got O
			//IL_00a3: Expected I4, but got O
			//IL_00bf: Expected O, but got I4
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.listData[(int)val].message = frmMain.STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.chrome.kichNo<T1, T5, T6, T7, T8>((T6)_003C_003E4__this.listData[(int)val].id, (T6)amount.ToString());
			T1 val3 = val2;
			if (val3 != null)
			{
				_003C_003E4__this.listData[(int)val].message = frmMain.STATUS.Done.ToString();
			}
			else
			{
				_003C_003E4__this.listData[(int)val].message = frmMain.STATUS.lỗi.ToString();
			}
			T0 val4 = (T0)countThread;
			countThread = val4 - 1;
			T2 val5 = (T2)new Thread((ParameterizedThreadStart)delegate
			{
				_003C_003E4__this.gvData.Refresh();
			});
			((Thread)val5).SetApartmentState(ApartmentState.STA);
			((Thread)val5).Start();
		}

		internal void _003CkichNo_003Eb__1<T0>(T0 param)
		{
			_003C_003E4__this.gvData.Refresh();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public frmAdsManager _003C_003E4__this;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__1;

		public ParameterizedThreadStart _003C_003E9__0;

		internal void _003CpayNow_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7>(T4 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_004e: Expected I4, but got O
			//IL_0071: Expected I4, but got O
			//IL_0098: Expected I4, but got O
			//IL_00b4: Expected O, but got I4
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.listData[(int)val].message = frmMain.STATUS.Processing.ToString();
			T1 val2 = _003C_003E4__this.chrome.payNow<T1, T5, T6, T7>((T6)_003C_003E4__this.listData[(int)val].id);
			T1 val3 = val2;
			if (val3 == null)
			{
				_003C_003E4__this.listData[(int)val].message = frmMain.STATUS.lỗi.ToString();
			}
			else
			{
				_003C_003E4__this.listData[(int)val].message = frmMain.STATUS.Done.ToString();
			}
			T0 val4 = (T0)countThread;
			countThread = val4 - 1;
			T2 val5 = (T2)new Thread((ParameterizedThreadStart)delegate
			{
				_003C_003E4__this.gvData.Refresh();
			});
			((Thread)val5).SetApartmentState(ApartmentState.STA);
			((Thread)val5).Start();
		}

		internal void _003CpayNow_003Eb__1<T0>(T0 param)
		{
			_003C_003E4__this.gvData.Refresh();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public frmAdsManager _003C_003E4__this;

		public MenuItem mi;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _003CpasteJsonActEvent_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 param)
		{
			//IL_0029: Expected O, but got I4
			//IL_0073: Expected O, but got I4
			//IL_0089: Expected O, but got I4
			//IL_00ca: Expected O, but got I4
			//IL_00f5: Expected O, but got I4
			try
			{
				_003C_003E4__this.gvData.DataSource = null;
				T0 val = (T0)mi.Text.Equals("Paste danh sách ID TK");
				if (val != null)
				{
					T1 val2 = (T1)"";
					val2 = (T1)Clipboard.GetText();
					val2 = (T1)((string)val2).Replace("|", Environment.NewLine);
					T2 val3 = (T2)Activator.CreateInstance(typeof(T2));
					T3 val4 = (T3)new StringReader((string)val2);
					try
					{
						while (true)
						{
							T1 val5;
							T0 val6 = (T0)((val5 = (T1)((TextReader)val4).ReadLine()) != null);
							if (val6 == null)
							{
								break;
							}
							T0 val7 = (T0)(!string.IsNullOrWhiteSpace((string)val5));
							if (val7 != null)
							{
								T0 val8 = (T0)(!((List<string>)val3).Contains(((string)val5).Trim()));
								if (val8 != null)
								{
									((List<string>)val3).Add(((string)val5).Trim());
									_003C_003E4__this.listData.Add(new adaccountsData
									{
										id = ((string)val5).Trim()
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
				}
				else
				{
					T0 val9 = (T0)mi.Text.Equals("Paste Json và xóa toàn bộ dữ liệu");
					if (val9 != null)
					{
						_003C_003E4__this.listData.Clear();
					}
					T1 val10 = (T1)"";
					val10 = (T1)Clipboard.GetText();
					T4 collection = JsonConvert.DeserializeObject<T4>((string)val10);
					_003C_003E4__this.listData.AddRange((IEnumerable<adaccountsData>)collection);
					_003C_003E4__this.chrome.frmMain.listFBEntity[_003C_003E4__this.chrome.indexEntity].fullAdsInfo = new CheckInfo();
					_003C_003E4__this.chrome.frmMain.listFBEntity[_003C_003E4__this.chrome.indexEntity].fullAdsInfo.adaccounts = new adaccounts();
					_003C_003E4__this.chrome.frmMain.listFBEntity[_003C_003E4__this.chrome.indexEntity].fullAdsInfo.adaccounts.data = (List<adaccountsData>)Activator.CreateInstance(typeof(T4));
					_003C_003E4__this.chrome.frmMain.listFBEntity[_003C_003E4__this.chrome.indexEntity].fullAdsInfo.adaccounts.data = _003C_003E4__this.listData;
				}
				_003C_003E4__this.gvData.DataSource = _003C_003E4__this.listData;
				_003C_003E4__this.loadTotal<T7, T8, T0>();
			}
			catch (Exception)
			{
				frmMain.errorMessage((T1)"Copy sai định dạng Json!");
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass90_0
	{
		public frmAdsManager _003C_003E4__this;

		public int countThread;

		public ParameterizedThreadStart _003C_003E9__1;

		public ParameterizedThreadStart _003C_003E9__0;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CcheckAdminPage_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_001d: Expected I4, but got O
			//IL_0043: Expected I4, but got O
			//IL_004e: Expected O, but got I4
			//IL_0062: Expected I4, but got O
			//IL_0083: Expected I4, but got O
			//IL_009f: Expected I4, but got O
			//IL_00bf: Expected I4, but got O
			//IL_00d7: Expected I4, but got O
			//IL_00f4: Expected I4, but got O
			//IL_010b: Expected O, but got I4
			//IL_0115: Expected O, but got I4
			//IL_012d: Expected I4, but got O
			//IL_0154: Expected I4, but got O
			//IL_0180: Expected I4, but got O
			//IL_01a6: Expected O, but got I4
			//IL_01bb: Expected I4, but got O
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Expected O, but got Unknown
			//IL_0229: Expected O, but got I4
			//IL_0241: Expected I4, but got O
			//IL_025a: Expected O, but got I4
			//IL_026f: Expected I4, but got O
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Expected O, but got Unknown
			//IL_02e1: Expected I4, but got O
			//IL_0328: Expected I4, but got O
			//IL_033b: Expected O, but got I4
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			_003C_003E4__this.Pages[(int)val].message = frmMain.STATUS.Processing.ToString();
			T2 val2 = (T2)string.IsNullOrWhiteSpace(_003C_003E4__this.Pages[(int)val].additional_profile_id);
			if (val2 != null)
			{
				_003C_003E4__this.Pages[(int)val].message = "Pro5 null";
			}
			else
			{
				_003C_003E4__this.Pages[(int)val].check_user_pro5 = _003C_003E4__this.chrome.check_user_pro5<T8, T3>((T3)_003C_003E4__this.Pages[(int)val].additional_profile_id);
				T2 val3 = (T2)(_003C_003E4__this.Pages[(int)val].check_user_pro5 != null && _003C_003E4__this.Pages[(int)val].check_user_pro5.data != null && _003C_003E4__this.Pages[(int)val].check_user_pro5.data.user != null);
				if (val3 != null)
				{
					T0 val4 = (T0)0;
					T3 val5 = (T3)"";
					T2 val6 = (T2)(_003C_003E4__this.Pages[(int)val].check_user_pro5.data.user.core_app_admins_for_additional_profile != null && _003C_003E4__this.Pages[(int)val].check_user_pro5.data.user.core_app_admins_for_additional_profile.edges != null && _003C_003E4__this.Pages[(int)val].check_user_pro5.data.user.core_app_admins_for_additional_profile.edges.Count > 0);
					if (val6 != null)
					{
						T4 enumerator = (T4)_003C_003E4__this.Pages[(int)val].check_user_pro5.data.user.core_app_admins_for_additional_profile.edges.GetEnumerator();
						try
						{
							while (((List<core_app_admins_for_additional_profile_edges>.Enumerator*)(&enumerator))->MoveNext())
							{
								core_app_admins_for_additional_profile_edges current = ((List<core_app_admins_for_additional_profile_edges>.Enumerator*)(&enumerator))->Current;
								val4 = (T0)(val4 + 1);
								val5 = (T3)((string)val5 + current.node.admin_profile.name + ", ");
							}
						}
						finally
						{
							((IDisposable)(*(List<core_app_admins_for_additional_profile_edges>.Enumerator*)(&enumerator))).Dispose();
						}
					}
					T0 val7 = (T0)0;
					T3 val8 = (T3)"";
					T2 val9 = (T2)(_003C_003E4__this.Pages[(int)val].check_user_pro5.data.user.outgoing_core_app_admin_invites != null);
					if (val9 != null)
					{
						T5 enumerator2 = (T5)_003C_003E4__this.Pages[(int)val].check_user_pro5.data.user.outgoing_core_app_admin_invites.GetEnumerator();
						try
						{
							while (((List<outgoing_core_app_admin_invites>.Enumerator*)(&enumerator2))->MoveNext())
							{
								outgoing_core_app_admin_invites current2 = ((List<outgoing_core_app_admin_invites>.Enumerator*)(&enumerator2))->Current;
								val7 = (T0)(val7 + 1);
								val8 = (T3)((string)val8 + current2.admin_profile.name + ", ");
							}
						}
						finally
						{
							((IDisposable)(*(List<outgoing_core_app_admin_invites>.Enumerator*)(&enumerator2))).Dispose();
						}
					}
					_003C_003E4__this.Pages[(int)val].message = $"({(T7)(object)val4}) admin({(T7)val5})-({(T7)(object)val7}) mời({(T7)val8})";
				}
				else
				{
					_003C_003E4__this.Pages[(int)val].message = "null";
				}
			}
			T0 val10 = (T0)countThread;
			countThread = val10 - 1;
			T1 val11 = (T1)new Thread((ParameterizedThreadStart)delegate
			{
				_003C_003E4__this.gvPage.Refresh();
			});
			((Thread)val11).SetApartmentState(ApartmentState.STA);
			((Thread)val11).Start();
		}

		internal void _003CcheckAdminPage_003Eb__1<T0>(T0 param)
		{
			_003C_003E4__this.gvPage.Refresh();
		}
	}

	public ChromeControl chrome = null;

	private int flag_load_data = 0;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private bool isLoading = false;

	public List<adaccountsData> listData = (List<adaccountsData>)Activator.CreateInstance(typeof(List<adaccountsData>));

	private List<string> listIdSelected = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private bool isAscending = false;

	private bool isRunning = false;

	private List<int> listRowIndex = (List<int>)Activator.CreateInstance(typeof(List<int>));

	private string strError = "";

	public List<BusinessManagerEntity_businesses_Data> BusinessManager = (List<BusinessManagerEntity_businesses_Data>)Activator.CreateInstance(typeof(List<BusinessManagerEntity_businesses_Data>));

	private List<string> listBMClick = (List<string>)Activator.CreateInstance(typeof(List<string>));

	public List<facebook_pagesData> Pages = (List<facebook_pagesData>)Activator.CreateInstance(typeof(List<facebook_pagesData>));

	private List<string> listPageClick = (List<string>)Activator.CreateInstance(typeof(List<string>));

	public List<GroupsEntity_Data> Groups = (List<GroupsEntity_Data>)Activator.CreateInstance(typeof(List<GroupsEntity_Data>));

	private List<string> listGroupClick = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private ToolTip tt = (ToolTip)Activator.CreateInstance(typeof(ToolTip));

	private List<global_cities> global_cities = (List<global_cities>)Activator.CreateInstance(typeof(List<global_cities>));

	private IContainer components = null;

	private Button button1;

	private DataGridView gvData;

	private ComboBox ccbBM;

	private TextBox txtSearch;

	private Button button2;

	private Button button3;

	private TabControl tabControl;

	private TabPage tabCookie;

	private TabPage tabToken;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel lbTotal;

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

	private NumericUpDown numLimit;

	private Label label2;

	private TextBox txtBMID;

	private Label label3;

	private Label label1;

	private TextBox txtToken;

	private Button button4;

	private TabPage tabTKQCBM;

	private TextBox txtBMIDTQCKInBM;

	private Label label4;

	private Button button5;

	private System.Windows.Forms.Timer timer_load_data_cookie;

	private System.Windows.Forms.Timer timer_load_data_token;

	private ProgressBar progressBar1;

	private TabControl tabGroup;

	private TabPage tabAds;

	private TabPage tabBM;

	private TabPage tabPage3;

	private Panel plBrowser;

	private StatusStrip statusStrip2;

	private ToolStripStatusLabel toolStripStatusLabel3;

	private ToolStripStatusLabel toolStripStatusLabel5;

	private DataGridView gvBM;

	private ProgressBar progressBar2;

	private Button button7;

	private System.Windows.Forms.Timer timer_load_bm;

	private Button button6;

	private TabPage tabPage;

	private StatusStrip statusStrip3;

	private ToolStripStatusLabel toolStripStatusLabel7;

	private ToolStripStatusLabel toolStripStatusLabel9;

	private Button button8;

	private DataGridView gvPage;

	private ProgressBar progressBar3;

	private System.Windows.Forms.Timer timer_load_page;

	private ToolStripStatusLabel toolStripStatusLabel11;

	private ToolStripStatusLabel lbPageLive;

	private ToolStripStatusLabel toolStripStatusLabel13;

	private ToolStripStatusLabel lbPageNormal;

	private ToolStripStatusLabel toolStripStatusLabel15;

	private ToolStripStatusLabel lbPagePro5;

	private TextBox txtSearchPage;

	private Button button9;

	private TabPage tabGroups;

	private TextBox txtSearchGroup;

	private Button button10;

	private Button button11;

	private DataGridView gvGroup;

	private ProgressBar progressBar4;

	private System.Windows.Forms.Timer timer_load_group;

	private StatusStrip statusStrip4;

	private ToolStripStatusLabel toolStripStatusLabel16;

	private ToolStripStatusLabel lbTotalGroups;

	private TabPage tabPageLocations;

	private ComboBox ccbPageLocations;

	private TextBox textBox1;

	private Button button12;

	private Button button13;

	private Button button14;

	private Button button15;

	private Button btnCreateBM;

	private NumericUpDown numBMAmount;

	private Label label5;

	private ImageList imageList1;

	private TextBox txtSearchBM;

	private Button button16;

	private ComboBox ccbActSort;

	private ComboBox ccbActFillter;

	private TextBox txtSearchByKeyword;

	private Label label6;

	private NumericUpDown numMaxAct;

	private Label label7;

	private DataGridViewTextBoxColumn Column1;

	private Label lbRowSelected;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem copyToolStripMenuItem;

	private ToolStripMenuItem uIDToolStripMenuItem;

	private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;

	private ToolStripMenuItem tokenEEAGToolStripMenuItem;

	private ToolStripMenuItem tokenEEABToolStripMenuItem;

	private ToolStripMenuItem cookieToolStripMenuItem;

	private ToolStripMenuItem fACodeToolStripMenuItem;

	private TextBox txtCreateNamePage;

	private ComboBox ccbTypeCreatePage;

	private Button button17;

	private Label label8;

	private TextBox txtCategoryCreatePage;

	private Label lbCountLoadAct;

	private Label lbBMSelected;

	private Label lbPageSelected;

	private Label label9;

	private ToolStripMenuItem mậtKhẩuToolStripMenuItem;

	private ToolStripMenuItem emailPasswordToolStripMenuItem;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmAdsManager(ChromeControl chrome)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		this.chrome = chrome;
		InitializeComponent<DataGridViewCellStyle, ComponentResourceManager, Container, Button, DataGridView, DataGridViewTextBoxColumn, ComboBox, TextBox, TabControl, TabPage, NumericUpDown, Label, StatusStrip, ToolStripStatusLabel, ProgressBar, Panel, MenuStrip, ToolStripMenuItem, object, EventArgs, DataGridViewColumn, DataGridViewCellFormattingEventArgs, DataGridViewCellMouseEventArgs, List<adaccountsData>, bool, int, string, float, List<adaccountsData>.Enumerator, DataGridViewRowStateChangedEventArgs, List<DataGridViewRow>, List<int>, DataGridViewRow, ContextMenu, MenuItem, MouseEventArgs, KeyEventArgs, char, Exception, decimal, ImageListStreamer, ToolStripItem, Dictionary<string, string>, List<BusinessManagerEntity_businesses_Data>, List<facebook_pagesData>.Enumerator, List<facebook_pagesData>, List<GroupsEntity_Data>, DateTime, double, List<string>, Thread, IJavaScriptExecutor, Icon, FormClosingEventArgs>();
		base.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
		PointToScreen(new Point(1, 1));
		if (this.chrome != null)
		{
			chromeMini<bool, string, Process, int, ReadOnlyCollection<IWebElement>, IWebElement, Exception>();
		}
		gvData.AutoGenerateColumns = false;
		gvData.Columns.Clear();
		if (chrome != null)
		{
			Text = chrome.frmMain.listFBEntity[chrome.indexEntity].Name + " - " + chrome.frmMain.listFBEntity[chrome.indexEntity].UID;
			setComboxBM<bool, List<BMData>.Enumerator>();
			tabControl.TabPages.Remove(tabToken);
		}
		else
		{
			tabControl.TabPages.Remove(tabCookie);
		}
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "int_id");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tiền tệ", "currency");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Quốc gia", "business_country_code");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Giới hạn chi tiêu", "adtrust_dsl");
		gvData.Columns["clGiới hạn chi tiêu"].DefaultCellStyle.ForeColor = Color.Blue;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Ngưỡng pay", "threshold_amount");
		gvData.Columns["clNgưỡng pay"].DefaultCellStyle.ForeColor = Color.Magenta;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Nợ", "balance");
		gvData.Columns["clNợ"].DefaultCellStyle.ForeColor = Color.Green;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Set limit", "spend_cap");
		gvData.Columns["clSet limit"].DefaultCellStyle.ForeColor = Color.Teal;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tổng chi", "amount_spent");
		gvData.Columns["clTổng chi"].DefaultCellStyle.ForeColor = Color.Coral;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Số dư limit", "get_remaining_amount");
		gvData.Columns["clSố dư limit"].DefaultCellStyle.ForeColor = Color.Purple;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Múi giờ", "timezone_name");
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Campaigns", "Has_Campaigns");
		gvData.Columns["clCampaigns"].DefaultCellStyle.ForeColor = Color.Teal;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Thẻ", "payment_section_details");
		gvData.Columns["clThẻ"].DefaultCellStyle.ForeColor = Color.Maroon;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Payment", "payment_status");
		gvData.Columns["clPayment"].DefaultCellStyle.ForeColor = Color.Green;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Trạng thái", "str_account_status");
		gvData.Columns["clTrạng thái"].DefaultCellStyle.ForeColor = Color.Green;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Lỗi", "disable_reason_string");
		gvData.Columns["clLỗi"].DefaultCellStyle.ForeColor = Color.Purple;
		GenColumn<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Message", "message");
		gvData.Columns["clMessage"].DefaultCellStyle.ForeColor = Color.Green;
		gvBM.AutoGenerateColumns = false;
		gvBM.Columns.Clear();
		GenColumn_BM<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "id");
		GenColumn_BM<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name");
		GenColumn_BM<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "TKQC", "TKQC");
		GenColumn_BM<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Payment", "Payment");
		GenColumn_BM<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Message", "message");
		gvPage.AutoGenerateColumns = false;
		gvPage.Columns.Clear();
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "id");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Pro Id", "additional_profile_id");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name_with_location_descriptor");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Loại page", "category");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Page Hiện Thị", "is_published");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Hạn chế QC", "is_restricted");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Page pro5", "has_transitioned_to_new_page_experience");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Follow", "followers_count");
		GenColumn_Page<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Message", "message");
		gvGroup.AutoGenerateColumns = false;
		gvGroup.Columns.Clear();
		GenColumn_Group<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Id", "id");
		GenColumn_Group<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Tên", "name");
		GenColumn_Group<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Thành viên", "member_count");
		GenColumn_Group<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Loại group", "privacy");
		GenColumn_Group<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Hoạt động gần (phút)", "updated_time_minute");
		GenColumn_Group<bool, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, string>("string", "Message", "message");
		if (this.chrome != null)
		{
			new Thread(getToken<int, bool, ReadOnlyCollection<IWebElement>, IWebElement, Exception, string, IEnumerator, Match, char, IDisposable, Dictionary<string, string>>).Start();
		}
		if (!frmMain.ADS_MANAGER)
		{
			tabGroup.TabPages.Remove(tabAds);
		}
		if (!frmMain.BM_MANAGER)
		{
			tabGroup.TabPages.Remove(tabBM);
		}
		if (!frmMain.PAGE_MANAGER)
		{
			tabGroup.TabPages.Remove(tabPage);
		}
		if (!frmMain.GROUP_MANAGER)
		{
			tabGroup.TabPages.Remove(tabGroups);
		}
		tabGroup.TabPages.Remove(tabPageLocations);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenColumn_Group<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val == null)
		{
			T2 val2 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvGroup.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T1 val3 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvGroup.Columns.Add((DataGridViewColumn)val3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void getToken<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
	{
		chrome.goUrl<T0, T1, T2, T3, T4, T5>((T5)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
		chrome.getToken_Fetch<T1, T5, T6, T7, T0, T8, T9, T4>((T5)"EAAB", (T5)ResouceControl.getResouce("RESOUCE_BM_CAMPAIGNS"));
		chrome.getToken_EEAG_Fetch<T1, T10, T5, T6, T7, T0, T8, T9, T4>();
		tabGroup.SelectedIndex = 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void chromeMini<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_000a: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_008b: Expected I4, but got O
		//IL_00ad: Expected O, but got I4
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00be: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		T0 val = (T0)(chrome != null);
		if (val == null)
		{
			return;
		}
		T1 val2 = frmMain.RandomString<T1, T3, char>((T3)10);
		chrome.goUrl<T3, T0, T4, T5, T6, T1>((T1)("chrome://" + (string)val2));
		Thread.Sleep(1000);
		T2[] processes = (T2[])(object)Process.GetProcesses();
		T3 val3 = (T3)((RemoteWebDriver)chrome.chrome).WindowHandles.Count;
		T0 val4 = (T0)((nint)val3 > 1);
		if (val4 != null)
		{
			T3 val5 = (T3)0;
			while (true)
			{
				T0 val6 = (T0)(val5 < val3);
				if (val6 == null)
				{
					break;
				}
				((RemoteWebDriver)chrome.chrome).SwitchTo().Window(((RemoteWebDriver)chrome.chrome).WindowHandles[(int)val5]);
				T1 title = (T1)((RemoteWebDriver)chrome.chrome).Title;
				T0 val7 = (T0)((string)title).Contains((string)val2);
				if (val7 != null)
				{
					break;
				}
				val5 = (T3)(val5 + 1);
			}
		}
		T2[] array = processes;
		T3 val8 = (T3)0;
		T2 val9;
		while (true)
		{
			if ((nint)val8 < array.Length)
			{
				val9 = (T2)((object[])(object)array)[(object)val8];
				T1 processName = (T1)((Process)val9).ProcessName;
				T0 val10 = (T0)(((string)processName).Equals("chrome") && !string.IsNullOrWhiteSpace(((Process)val9).MainWindowTitle) && ((Process)val9).MainWindowTitle.ToLower().Contains((string)val2));
				if (val10 != null)
				{
					break;
				}
				val8 = (T3)(val8 + 1);
				continue;
			}
			return;
		}
		SetParent(((Process)val9).MainWindowHandle, plBrowser.Handle);
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool repaint);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void button3_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0090: Expected O, but got F4
		//IL_016c: Expected O, but got I4
		try
		{
			T0 val = (T0)"";
			T1 enumerator = (T1)listData.GetEnumerator();
			try
			{
				while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
				{
					adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
					val = (T0)string.Concat((string[])(object)new T0[21]
					{
						val,
						(T0)current.id,
						(T0)"\t",
						(T0)current.name,
						(T0)"\t",
						(T0)current.currency,
						(T0)"\t",
						(T0)current.business_country_code,
						(T0)"\t",
						(T0)$"{(T4)(object)(T6)current.adtrust_dsl}\t{(T4)current.threshold_amount}\t{(T4)current.balance}\t{(T4)current.spend_cap}\t{(T4)current.get_remaining_amount}",
						(T0)"\t",
						(T0)current.payment,
						(T0)"\t",
						(T0)current.timezone_name,
						(T0)"\t",
						(T0)current.Has_Campaigns,
						(T0)"\t",
						(T0)current.payment_status,
						(T0)"\t",
						(T0)current.str_account_status,
						(T0)Environment.NewLine
					});
				}
			}
			finally
			{
				((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
			}
			T0 folderPath = (T0)Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			folderPath = (T0)((string)folderPath + "\\Export Camp-" + System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)rnd.Next(111, 999)) + ".txt");
			File.WriteAllText((string)folderPath, (string)val);
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
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
	private void GenColumn_Page<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvPage.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T2 val3 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvPage.Columns.Add((DataGridViewColumn)val3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GenColumn_BM<T0, T1, T2, T3>(T3 typeColumn, T3 HeaderText, T3 DataPropertyName)
	{
		//IL_0012: Expected O, but got I4
		T0 val = (T0)((string)typeColumn).ToLower().Equals("bool");
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
			((DataGridViewColumn)val2).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val2).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val2).Name = "cl" + (string)HeaderText;
			gvBM.Columns.Add((DataGridViewColumn)val2);
		}
		else
		{
			T2 val3 = (T2)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
			((DataGridViewColumn)val3).DataPropertyName = (string)DataPropertyName;
			((DataGridViewColumn)val3).HeaderText = (string)HeaderText;
			((DataGridViewColumn)val3).Name = "cl" + (string)HeaderText;
			gvBM.Columns.Add((DataGridViewColumn)val3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
		isLoading = true;
		flag_load_data = 0;
		gvData.DataSource = null;
		button1.Enabled = false;
		progressBar1.Style = ProgressBarStyle.Marquee;
		new Thread(thrLoadDataCookie<Dictionary<string, string>, string, bool, ReadOnlyCollection<IWebElement>, IEnumerator, Match, int, char, IDisposable, Exception, IWebElement>).Start();
		timer_load_data_cookie.Start();
		lbCountLoadAct.Text = "0";
	}

	private void thrLoadDataCookie<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
	{
		chrome.getFullAdsInfo<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
		isLoading = false;
	}

	private void timer_load_data_cookie_Tick<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		T0 val = (T0)(!isLoading);
		if (val == null)
		{
			lbCountLoadAct.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)chrome.frmMain.listFBEntity[chrome.indexEntity].lbCountLoadAct).ToString();
			return;
		}
		timer_load_data_cookie.Stop();
		setComboxBM<T0, List<BMData>.Enumerator>();
		button1.Enabled = true;
		progressBar1.Style = ProgressBarStyle.Blocks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void setComboxBM<T0, T1>()
	{
		//IL_00b0: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		ccbBM.Items.Clear();
		ccbBM.Items.Add("Toàn bộ TK");
		T0 val = (T0)(chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo != null && chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.businesses != null && chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.businesses.data != null);
		if (val != null)
		{
			T1 enumerator = (T1)chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.businesses.data.GetEnumerator();
			try
			{
				while (((List<BMData>.Enumerator*)(&enumerator))->MoveNext())
				{
					BMData current = ((List<BMData>.Enumerator*)(&enumerator))->Current;
					ccbBM.Items.Add(current.id + "-" + current.name);
				}
			}
			finally
			{
				((IDisposable)(*(List<BMData>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		T0 val2 = (T0)(ccbBM.Items.Count > 0);
		if (val2 != null)
		{
			ccbBM.SelectedIndex = 0;
		}
	}

	private void ccbBM_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		SetData<string, bool, List<BMData>.Enumerator, int, char>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void SetData<T0, T1, T2, T3, T4>()
	{
		//IL_002a: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_01be: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_022b: Expected O, but got I4
		//IL_0235: Expected O, but got I4
		//IL_024a: Expected I4, but got O
		//IL_0256: Expected O, but got I4
		//IL_0267: Expected I4, but got O
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0284: Expected O, but got I4
		//IL_02de: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0305: Expected I4, but got O
		//IL_0311: Expected O, but got I4
		//IL_0327: Expected I4, but got O
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_0344: Expected O, but got I4
		gvData.DataSource = null;
		T0 val = (T0)ccbBM.SelectedItem.ToString();
		T1 val2 = (T1)((string)val).Equals("Toàn bộ TK");
		if (val2 != null)
		{
			T1 val3 = (T1)(chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo != null && chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.adaccounts != null && chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.adaccounts.data != null);
			if (val3 != null)
			{
				listData = chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.adaccounts.data;
			}
		}
		else
		{
			T0 value = (T0)((string)val).Split((char[])(object)new T4[1] { (T4)45 })[0];
			T1 val4 = (T1)(chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.businesses != null && chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo != null);
			if (val4 != null)
			{
				T2 enumerator = (T2)chrome.frmMain.listFBEntity[chrome.indexEntity].fullAdsInfo.businesses.data.GetEnumerator();
				try
				{
					while (((List<BMData>.Enumerator*)(&enumerator))->MoveNext())
					{
						BMData current = ((List<BMData>.Enumerator*)(&enumerator))->Current;
						T1 val5 = (T1)current.id.Equals((string)value);
						if (val5 != null)
						{
							T1 val6 = (T1)(current.owned_ad_accounts != null && current.owned_ad_accounts.data != null);
							if (val6 != null)
							{
								listData = current.owned_ad_accounts.data;
							}
							break;
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<BMData>.Enumerator*)(&enumerator))).Dispose();
				}
			}
		}
		T1 val7 = (T1)(listData != null && listData.Count > 0);
		if (val7 != null)
		{
			T3 val8 = (T3)0;
			while (true)
			{
				T1 val9 = (T1)((nint)val8 < listData.Count);
				if (val9 == null)
				{
					break;
				}
				T1 val10 = (T1)listIdSelected.Contains(listData[(int)val8].int_id);
				if (val10 != null)
				{
					listData[(int)val8].select_row = true;
				}
				val8 = (T3)(val8 + 1);
			}
			listData = listData.OrderByDescending((Func<adaccountsData, T1>)(object)(Func<adaccountsData, bool>)((adaccountsData a) => (T1)a.select_row)).ToList();
			gvData.DataSource = listData;
			T1 val11 = (T1)(listIdSelected.Count > 0);
			if (val11 != null)
			{
				gvData.ClearSelection();
				T3 val12 = (T3)0;
				while (true)
				{
					T1 val13 = (T1)((nint)val12 < listData.Count);
					if (val13 == null)
					{
						break;
					}
					T1 val14 = (T1)listIdSelected.Contains(listData[(int)val12].int_id);
					if (val14 != null)
					{
						gvData.Rows[(int)val12].Selected = true;
					}
					val12 = (T3)(val12 + 1);
				}
			}
		}
		loadTotal<T3, List<adaccountsData>.Enumerator, T1>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void loadTotal<T0, T1, T2>()
	{
		//IL_0013: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_015a: Expected O, but got I4
		//IL_016c: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_01a0: Expected O, but got I4
		//IL_01b6: Expected I4, but got O
		//IL_01e2: Expected I4, but got O
		//IL_01f6: Expected I4, but got O
		//IL_0216: Expected O, but got I4
		//IL_022c: Expected I4, but got O
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_0262: Expected O, but got I4
		lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)listData.Count).ToString();
		T0 val = (T0)0;
		T0 val2 = (T0)0;
		T0 val3 = (T0)0;
		T0 val4 = (T0)0;
		T0 val5 = (T0)0;
		T0 val6 = (T0)0;
		T0 val7 = (T0)0;
		T1 enumerator = (T1)listData.GetEnumerator();
		try
		{
			while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
			{
				adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
				T0 val8 = (T0)current.account_status;
				T0 val9 = val8;
				switch (val9 - 1)
				{
				case 0:
					val = (T0)(val + 1);
					continue;
				case 1:
					val2 = (T0)(val2 + 1);
					continue;
				case 2:
					val3 = (T0)(val3 + 1);
					continue;
				case 6:
					val4 = (T0)(val4 + 1);
					continue;
				case 8:
					val5 = (T0)(val5 + 1);
					continue;
				case 3:
				case 4:
				case 5:
				case 7:
					continue;
				}
				if ((nint)val9 == 100)
				{
					val7 = (T0)(val7 + 1);
				}
				else if ((nint)val9 == 101)
				{
					val6 = (T0)(val6 + 1);
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
		}
		lbActive.Text = ((int*)(&val))->ToString();
		lbDie.Text = ((int*)(&val2))->ToString();
		lbUnsettled.Text = ((int*)(&val3))->ToString();
		lbReview.Text = ((int*)(&val4))->ToString();
		lbGracePeriod.Text = ((int*)(&val5))->ToString();
		lbTemporarityUnavable.Text = ((int*)(&val6))->ToString();
		lbPendingCloure.Text = ((int*)(&val7))->ToString();
		try
		{
			T0 val10 = (T0)0;
			while (true)
			{
				T2 val11 = (T2)((nint)val10 < listData.Count);
				if (val11 != null)
				{
					T2 val12 = (T2)(listData[(int)val10].payment_status != null && listData[(int)val10].payment_status.Equals(frmMain.STATUS.Không_đủ_tiền.ToString()));
					if (val12 != null)
					{
						gvData.Rows[(int)val10].Cells["clPayment"].Style.ForeColor = Color.Purple;
					}
					T2 val13 = (T2)(listData[(int)val10].str_account_status != null && listData[(int)val10].str_account_status.Equals(frmMain.STATUS.Die.ToString()));
					if (val13 != null)
					{
						gvData.Rows[(int)val10].Cells["clTrạng thái"].Style.ForeColor = Color.Red;
					}
					val10 = (T0)(val10 + 1);
					continue;
				}
				break;
			}
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_ColumnHeaderMouseClick<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 sender, T5 e)
	{
		//IL_000c: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_00ed: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_0271: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0303: Expected O, but got I4
		//IL_055a: Expected O, but got I4
		//IL_05a1: Expected O, but got I4
		//IL_05bb: Expected O, but got I4
		//IL_0602: Expected O, but got I4
		//IL_0649: Expected O, but got I4
		//IL_0690: Expected O, but got I4
		//IL_06d7: Expected O, but got I4
		//IL_06f1: Expected O, but got I4
		//IL_070b: Expected O, but got I4
		//IL_0725: Expected O, but got I4
		//IL_076c: Expected O, but got I4
		//IL_0786: Expected O, but got I4
		//IL_07a0: Expected O, but got I4
		//IL_07e7: Expected O, but got I4
		//IL_0801: Expected O, but got I4
		//IL_081b: Expected O, but got I4
		//IL_0862: Expected O, but got I4
		//IL_0a6d: Expected O, but got I4
		//IL_0a82: Expected I4, but got O
		//IL_0a8e: Expected O, but got I4
		//IL_0aa4: Expected I4, but got O
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab0: Expected O, but got Unknown
		//IL_0ac1: Expected O, but got I4
		T0 val = (T0)listData;
		T1 val2 = (T1)(val != null);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)gvData.Columns[((DataGridViewCellMouseEventArgs)e).ColumnIndex];
		isAscending = !isAscending;
		T1 val4 = (T1)isAscending;
		if (val4 != null)
		{
			T1 val5 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("int_id");
			if (val5 == null)
			{
				T1 val6 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("name");
				if (val6 == null)
				{
					T1 val7 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("currency");
					if (val7 != null)
					{
						val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.currency)).ToList();
					}
					else
					{
						T1 val8 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("adtrust_dsl");
						if (val8 == null)
						{
							T1 val9 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("threshold_amount");
							if (val9 != null)
							{
								val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.threshold_amount)).ToList();
							}
							else
							{
								T1 val10 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("balance");
								if (val10 == null)
								{
									T1 val11 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("spend_cap");
									if (val11 == null)
									{
										T1 val12 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("amount_spent");
										if (val12 == null)
										{
											T1 val13 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("get_remaining_amount");
											if (val13 != null)
											{
												val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.get_remaining_amount)).ToList();
											}
											else
											{
												T1 val14 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("payment");
												if (val14 == null)
												{
													T1 val15 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("timezone_name");
													if (val15 != null)
													{
														val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.timezone_name)).ToList();
													}
													else
													{
														T1 val16 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("Has_Campaigns");
														if (val16 != null)
														{
															val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.Has_Campaigns)).ToList();
														}
														else
														{
															T1 val17 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("payment_status");
															if (val17 != null)
															{
																val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.payment_status)).ToList();
															}
															else
															{
																T1 val18 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("message");
																if (val18 == null)
																{
																	T1 val19 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("disable_reason_string");
																	if (val19 == null)
																	{
																		T1 val20 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("business_country_code");
																		if (val20 == null)
																		{
																			T1 val21 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("payment_section_details");
																			val = (T0)((val21 != null) ? ((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.payment_section_details)).ToList() : ((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.str_account_status)).ToList());
																		}
																		else
																		{
																			val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.business_country_code)).ToList();
																		}
																	}
																	else
																	{
																		val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T3>)(object)(Func<adaccountsData, int>)((adaccountsData a) => (T3)a.disable_reason)).ToList();
																	}
																}
																else
																{
																	val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.message)).ToList();
																}
															}
														}
													}
												}
												else
												{
													val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.payment)).ToList();
												}
											}
										}
										else
										{
											val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.amount_spent)).ToList();
										}
									}
									else
									{
										val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.spend_cap)).ToList();
									}
								}
								else
								{
									val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.balance)).ToList();
								}
							}
						}
						else
						{
							val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T7>)(object)(Func<adaccountsData, float>)((adaccountsData a) => (T7)a.adtrust_dsl)).ToList();
						}
					}
				}
				else
				{
					val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.name)).ToList();
				}
			}
			else
			{
				val = (T0)((IEnumerable<adaccountsData>)val).OrderByDescending((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.id)).ToList();
			}
		}
		else
		{
			T1 val22 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("int_id");
			if (val22 != null)
			{
				val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.id)).ToList();
			}
			else
			{
				T1 val23 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("payment_section_details");
				if (val23 == null)
				{
					T1 val24 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("name");
					if (val24 != null)
					{
						val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.name)).ToList();
					}
					else
					{
						T1 val25 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("currency");
						if (val25 != null)
						{
							val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.currency)).ToList();
						}
						else
						{
							T1 val26 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("adtrust_dsl");
							if (val26 != null)
							{
								val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T7>)(object)(Func<adaccountsData, float>)((adaccountsData a) => (T7)a.adtrust_dsl)).ToList();
							}
							else
							{
								T1 val27 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("threshold_amount");
								if (val27 != null)
								{
									val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.threshold_amount)).ToList();
								}
								else
								{
									T1 val28 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("balance");
									if (val28 == null)
									{
										T1 val29 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("spend_cap");
										if (val29 == null)
										{
											T1 val30 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("amount_spent");
											if (val30 == null)
											{
												T1 val31 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("get_remaining_amount");
												if (val31 != null)
												{
													val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.get_remaining_amount)).ToList();
												}
												else
												{
													T1 val32 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("payment");
													if (val32 == null)
													{
														T1 val33 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("timezone_name");
														if (val33 == null)
														{
															T1 val34 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("business_country_code");
															if (val34 != null)
															{
																val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.business_country_code)).ToList();
															}
															else
															{
																T1 val35 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("Has_Campaigns");
																if (val35 == null)
																{
																	T1 val36 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("payment_status");
																	if (val36 == null)
																	{
																		T1 val37 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("message");
																		if (val37 != null)
																		{
																			val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.message)).ToList();
																		}
																		else
																		{
																			T1 val38 = (T1)((DataGridViewColumn)val3).DataPropertyName.Equals("disable_reason_string");
																			val = (T0)((val38 == null) ? ((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.str_account_status)).ToList() : ((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T3>)(object)(Func<adaccountsData, int>)((adaccountsData a) => (T3)a.disable_reason)).ToList());
																		}
																	}
																	else
																	{
																		val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.payment_status)).ToList();
																	}
																}
																else
																{
																	val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.Has_Campaigns)).ToList();
																}
															}
														}
														else
														{
															val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.timezone_name)).ToList();
														}
													}
													else
													{
														val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.payment)).ToList();
													}
												}
											}
											else
											{
												val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.amount_spent)).ToList();
											}
										}
										else
										{
											val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.spend_cap)).ToList();
										}
									}
									else
									{
										val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.balance)).ToList();
									}
								}
							}
						}
					}
				}
				else
				{
					val = (T0)((IEnumerable<adaccountsData>)val).OrderBy((Func<adaccountsData, T6>)(object)(Func<adaccountsData, string>)((adaccountsData a) => (T6)a.payment_section_details)).ToList();
				}
			}
		}
		listData = (List<adaccountsData>)val;
		gvData.DataSource = null;
		gvData.DataSource = listData;
		gvData.ClearSelection();
		T3 val39 = (T3)0;
		while (true)
		{
			T1 val40 = (T1)((nint)val39 < listData.Count);
			if (val40 == null)
			{
				break;
			}
			T1 val41 = (T1)listIdSelected.Contains(listData[(int)val39].int_id);
			if (val41 != null)
			{
				gvData.Rows[(int)val39].Selected = true;
			}
			val39 = (T3)(val39 + 1);
		}
		loadTotal<T3, T8, T1>();
	}

	private void frmAdsManager_FormClosing<T0, T1>(T0 sender, T1 e)
	{
		new Thread(thrCloneChrome<bool, Exception>).Start();
		try
		{
			chrome.frmMain.fblistSaving<Thread, bool, Exception>(isNeedCheckTime: false);
		}
		catch
		{
		}
	}

	private void thrCloneChrome<T0, T1>()
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			try
			{
				((RemoteWebDriver)chrome.chrome).Close();
				((RemoteWebDriver)chrome.chrome).Quit();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
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
			T2 item = (T2)new MenuItem("Đăng camp - cấu hình tài khoản", (EventHandler)publishCampTextEvent<List<string>, List<DataGridViewRow>, int, T0, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Clear toàn bộ", (EventHandler)clearActEvent<T2, T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, List<adaccountsData>.Enumerator>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Clear dòng đã chọn", (EventHandler)clearActEvent<T2, T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow, List<adaccountsData>.Enumerator>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 val3 = (T2)new MenuItem("Copy");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("Copy ID TK", (EventHandler)copyIdTkEvent<T2, List<DataGridViewRow>, T0, int, Thread, T3, EventArgs, List<adaccountsData>, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Copy ID TK Tách Dòng", (EventHandler)copyIdTkEvent<T2, List<DataGridViewRow>, T0, int, Thread, T3, EventArgs, List<adaccountsData>, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Copy Json", (EventHandler)copyIdTkEvent<T2, List<DataGridViewRow>, T0, int, Thread, T3, EventArgs, List<adaccountsData>, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			val3 = (T2)new MenuItem("Paste");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("Paste Json", (EventHandler)pasteJsonActEvent<Thread, T3, EventArgs, T2>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste Json và xóa toàn bộ dữ liệu", (EventHandler)pasteJsonActEvent<Thread, T3, EventArgs, T2>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Paste danh sách ID TK", (EventHandler)pasteJsonActEvent<Thread, T3, EventArgs, T2>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Tạo TKCQ", (EventHandler)createTKQCEvent<string, T0, Exception, T3, EventArgs, Dictionary<string, string>>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Reload", (EventHandler)reloadTkEvent<T0, T2, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Check trạng thái TK", (EventHandler)reloadTkEvent<T0, T2, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Kiểm tra thông tin thẻ", (EventHandler)reloadTkEvent<T0, T2, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Reload + Kiểm tra thông tin thẻ", (EventHandler)reloadTkEvent<T0, T2, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("-------------");
			((Menu)val2).MenuItems.Add((MenuItem)item);
			val3 = (T2)new MenuItem("Chrome");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("Trình quảng cáo", (EventHandler)openCampEvent<T2, List<DataGridViewRow>, T0, int, string, T3, EventArgs, DataGridViewRow, IJavaScriptExecutor>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Cài đặt thanh toán", (EventHandler)openCampEvent<T2, List<DataGridViewRow>, T0, int, string, T3, EventArgs, DataGridViewRow, IJavaScriptExecutor>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Chất lượng tài khoản", (EventHandler)openCampEvent<T2, List<DataGridViewRow>, T0, int, string, T3, EventArgs, DataGridViewRow, IJavaScriptExecutor>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void createTKQCEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0017: Expected O, but got I4
		try
		{
			T0 value = chrome.createAct<T0, T1, T5, T2>();
			T1 val = (T1)(!string.IsNullOrWhiteSpace((string)value));
			if (val == null)
			{
				frmMain.errorMessage((T0)"Tạo TK lỗi!");
			}
			else
			{
				frmMain.infoMessage((T0)"Done!");
			}
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void reloadTkEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0021: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00bb: Expected I4, but got O
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		isRunning = !isRunning;
		listRowIndex.Clear();
		T0 val = (T0)isRunning;
		if (val == null)
		{
			return;
		}
		T1 val2 = (T1)sender;
		T2 val3 = (T2)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T3 val4 = (T3)(((List<DataGridViewRow>)val3).Count - 1);
		while (true)
		{
			T0 val5 = (T0)((nint)val4 >= 0);
			if (val5 == null)
			{
				break;
			}
			listRowIndex.Add(((List<DataGridViewRow>)val3)[(int)val4].Index);
			listData[((List<DataGridViewRow>)val3)[(int)val4].Index].message = frmMain.STATUS.Ready.ToString();
			val4 = (T3)(val4 - 1);
		}
		T0 val6 = (T0)(listRowIndex.Count > 0);
		if (val6 == null)
		{
			return;
		}
		T3 val7 = (T3)0;
		T0 val8 = (T0)((MenuItem)val2).Text.Equals("Reload");
		if (val8 == null)
		{
			T0 val9 = (T0)((MenuItem)val2).Text.Equals("Check trạng thái TK");
			if (val9 == null)
			{
				T0 val10 = (T0)((MenuItem)val2).Text.Equals("Kiểm tra thông tin thẻ");
				if (val10 == null)
				{
					T0 val11 = (T0)((MenuItem)val2).Text.Equals("Reload + Kiểm tra thông tin thẻ");
					if (val11 != null)
					{
						val7 = (T3)3;
					}
				}
				else
				{
					val7 = (T3)2;
				}
			}
			else
			{
				val7 = (T3)1;
			}
		}
		else
		{
			val7 = (T3)0;
		}
		new Thread((ParameterizedThreadStart)thrReload<T3, List<int>, Thread, T0, List<int>.Enumerator, Exception, T4, string, IJavaScriptExecutor, ICollection<object>, Dictionary<string, string>, List<object>>).Start(val7);
	}

	private unsafe void thrReload<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 obj)
	{
		//IL_000d: Expected O, but got I4
		//IL_0010: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0041: Expected I4, but got O
		//IL_0043: Expected O, but got I4
		//IL_004b: Expected I4, but got O
		//IL_0058: Expected I4, but got O
		//IL_0081: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_015c: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01c4: Expected O, but got I4
		try
		{
			T0 val = (T0)int.Parse(obj.ToString());
			T0 val2 = (T0)100;
			T1 val3 = (T1)Activator.CreateInstance(typeof(T1));
			T0 val4 = (T0)(listRowIndex.Count - 1);
			while (true)
			{
				T3 val5 = (T3)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				T0 val6 = (T0)listRowIndex[(int)val4];
				((List<int>)val3).Add((int)val6);
				listData[(int)val6].message = frmMain.STATUS.Processing.ToString();
				T3 val7 = (T3)(((List<int>)val3).Count >= (nint)val2 || val4 == null);
				if (val7 != null)
				{
					T2 val8 = (T2)new Thread((ParameterizedThreadStart)delegate
					{
						gvData.Refresh();
					});
					((Thread)val8).SetApartmentState(ApartmentState.STA);
					((Thread)val8).Start();
					T3 val9 = (T3)1;
					T3 val10 = (T3)1;
					T3 val11 = (T3)(val == null);
					if (val11 == null)
					{
						T3 val12 = (T3)((nint)val == 1);
						if (val12 == null)
						{
							T3 val13 = (T3)((nint)val == 2);
							if (val13 == null)
							{
								T3 val14 = (T3)((nint)val == 3);
								if (val14 != null)
								{
									val9 = chrome.reload_act_2<T3, T7, T8, T9, T4, T0, T10, T11, T5, T1, T6>(val3, this);
									val10 = (T3)chrome.payment_account_Promise_3((List<int>)val3, this);
								}
							}
							else
							{
								val9 = (T3)chrome.payment_account_Promise_3((List<int>)val3, this);
							}
						}
						else
						{
							val9 = chrome.check_life_act_Promise<T3, T7, T11, T4, T0, T10, T5, T1>(val3, this);
						}
					}
					else
					{
						val9 = chrome.reload_act_2<T3, T7, T8, T9, T4, T0, T10, T11, T5, T1, T6>(val3, this);
					}
					T4 enumerator = (T4)((List<int>)val3).GetEnumerator();
					try
					{
						while (((List<int>.Enumerator*)(&enumerator))->MoveNext())
						{
							T0 val15 = (T0)((List<int>.Enumerator*)(&enumerator))->Current;
							T3 val16 = (T3)(val9 == null || val10 == null);
							if (val16 == null)
							{
								listData[(int)val15].message = frmMain.STATUS.Done.ToString();
							}
							else
							{
								listData[(int)val15].message = frmMain.STATUS.lỗi.ToString();
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<int>.Enumerator*)(&enumerator))).Dispose();
					}
					((List<int>)val3).Clear();
				}
				val4 = (T0)(val4 - 1);
			}
			T2 val17 = (T2)new Thread((ParameterizedThreadStart)_003CthrReload_003Eb__30_0<T6, T0, List<adaccountsData>.Enumerator, T3>);
			((Thread)val17).SetApartmentState(ApartmentState.STA);
			((Thread)val17).Start();
			isRunning = false;
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T7)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copyIdTkEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_0096: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_00fb: Expected I4, but got O
		//IL_012c: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_016f: Expected I4, but got O
		//IL_019d: Expected O, but got I4
		//IL_01b5: Expected I4, but got O
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		try
		{
			_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
			CS_0024_003C_003E8__locals0.listAct_Json = (List<adaccountsData>)Activator.CreateInstance(typeof(T7));
			T0 val = (T0)sender;
			T1 val2 = (T1)gvData.SelectedRows.Cast<T8>().Where((Func<T8, bool>)(object)(Func<DataGridViewRow, bool>)((T8 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T8, T3>)(object)(Func<DataGridViewRow, int>)((T8 row) => (T3)((DataGridViewBand)row).Index))
				.ToList();
			CS_0024_003C_003E8__locals0.strActList = "";
			T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
			if (val3 != null)
			{
				T3 val4 = (T3)0;
				while (true)
				{
					T2 val5 = (T2)((nint)val4 < ((List<DataGridViewRow>)val2).Count);
					if (val5 == null)
					{
						break;
					}
					T2 val6 = (T2)((MenuItem)val).Text.Equals("Copy ID TK");
					if (val6 != null)
					{
						T2 val7 = (T2)(!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.strActList));
						if (val7 != null)
						{
							CS_0024_003C_003E8__locals0.strActList += "|";
						}
						CS_0024_003C_003E8__locals0.strActList += listData[((List<DataGridViewRow>)val2)[(int)val4].Index].int_id;
					}
					else
					{
						T2 val8 = (T2)((MenuItem)val).Text.Equals("Copy ID TK Tách Dòng");
						if (val8 != null)
						{
							T2 val9 = (T2)(!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.strActList));
							if (val9 != null)
							{
								CS_0024_003C_003E8__locals0.strActList += Environment.NewLine;
							}
							CS_0024_003C_003E8__locals0.strActList += listData[((List<DataGridViewRow>)val2)[(int)val4].Index].int_id;
						}
						else
						{
							T2 val10 = (T2)((MenuItem)val).Text.Equals("Copy Json");
							if (val10 != null)
							{
								CS_0024_003C_003E8__locals0.listAct_Json.Add(listData[((List<DataGridViewRow>)val2)[(int)val4].Index]);
							}
						}
					}
					val4 = (T3)(val4 + 1);
				}
			}
			T2 val11 = (T2)(((MenuItem)val).Text.Equals("Copy ID TK") || ((MenuItem)val).Text.Equals("Copy ID TK Tách Dòng"));
			if (val11 == null)
			{
				T2 val12 = (T2)((MenuItem)val).Text.Equals("Copy Json");
				if (val12 != null)
				{
					T4 val13 = (T4)new Thread((ParameterizedThreadStart)CS_0024_003C_003E8__locals0._003CcopyIdTkEvent_003Eb__3<string, T5>);
					((Thread)val13).SetApartmentState(ApartmentState.STA);
					((Thread)val13).Start();
				}
			}
			else
			{
				T4 val14 = (T4)new Thread((ParameterizedThreadStart)delegate
				{
					Clipboard.Clear();
					Clipboard.SetText(CS_0024_003C_003E8__locals0.strActList);
				});
				((Thread)val14).SetApartmentState(ApartmentState.STA);
				((Thread)val14).Start();
			}
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void openCampEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_006f: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		//IL_00ce: Expected I4, but got O
		//IL_00ff: Expected O, but got I4
		//IL_0116: Expected I4, but got O
		//IL_0147: Expected I4, but got O
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_017e: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 == null)
		{
			return;
		}
		T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
		while (true)
		{
			T2 val5 = (T2)((nint)val4 >= 0);
			if (val5 == null)
			{
				break;
			}
			T4 script = (T4)"";
			T2 val6 = (T2)((MenuItem)val).Text.Equals("Trình quảng cáo");
			if (val6 == null)
			{
				T2 val7 = (T2)((MenuItem)val).Text.Equals("Cài đặt thanh toán");
				if (val7 != null)
				{
					script = (T4)("window.open('https://www.facebook.com/ads/manager/account_settings/account_billing/?act=" + listData[((List<DataGridViewRow>)val2)[(int)val4].Index].int_id + "&pid=p1&page=account_settings&tab=account_billing_settings');");
				}
				else
				{
					T2 val8 = (T2)((MenuItem)val).Text.Equals("Chất lượng tài khoản");
					if (val8 != null)
					{
						script = (T4)("window.open('https://business.facebook.com/accountquality/" + listData[((List<DataGridViewRow>)val2)[(int)val4].Index].int_id + "');");
					}
				}
			}
			else
			{
				script = (T4)("window.open('https://business.facebook.com/adsmanager/manage/campaigns?act=" + listData[((List<DataGridViewRow>)val2)[(int)val4].Index].int_id + "');");
			}
			chrome.executeScript<T4, T8, T3, T2, T5>(script);
			val4 = (T3)(val4 - 1);
		}
	}

	private void kichNoEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0021: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00b4: Expected I4, but got O
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00df: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		isRunning = !isRunning;
		listRowIndex.Clear();
		T0 val = (T0)isRunning;
		if (val == null)
		{
			return;
		}
		T1 val2 = (T1)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count - 1);
		while (true)
		{
			T0 val4 = (T0)((nint)val3 >= 0);
			if (val4 == null)
			{
				break;
			}
			listRowIndex.Add(((List<DataGridViewRow>)val2)[(int)val3].Index);
			listData[((List<DataGridViewRow>)val2)[(int)val3].Index].message = frmMain.STATUS.Ready.ToString();
			val3 = (T2)(val3 - 1);
		}
		T0 val5 = (T0)(listRowIndex.Count > 0);
		if (val5 != null)
		{
			new Thread((ParameterizedThreadStart)kichNo<T2, Thread, T0, ParameterizedThreadStart, T3>).Start("");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void payNow01Event<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_002f: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00ad: Expected I4, but got O
		//IL_00c5: Expected I4, but got O
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00f4: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)((MenuItem)val).Text;
		isRunning = !isRunning;
		listRowIndex.Clear();
		T2 val3 = (T2)isRunning;
		if (val3 == null)
		{
			return;
		}
		T3 val4 = (T3)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		T4 val5 = (T4)(((List<DataGridViewRow>)val4).Count - 1);
		while (true)
		{
			T2 val6 = (T2)((nint)val5 >= 0);
			if (val6 == null)
			{
				break;
			}
			listRowIndex.Add(((List<DataGridViewRow>)val4)[(int)val5].Index);
			listData[((List<DataGridViewRow>)val4)[(int)val5].Index].message = frmMain.STATUS.Ready.ToString();
			val5 = (T4)(val5 - 1);
		}
		T2 val7 = (T2)(listRowIndex.Count > 0);
		if (val7 == null)
		{
			return;
		}
		T2 val8 = (T2)((string)val2).Contains("Pay nợ 0.01$");
		if (val8 == null)
		{
			T2 val9 = (T2)((string)val2).Contains("Pay nợ 0.1$");
			if (val9 == null)
			{
				T2 val10 = (T2)((string)val2).Contains("Pay nợ 1$");
				if (val10 != null)
				{
					new Thread((ParameterizedThreadStart)kichNo<T4, Thread, T2, ParameterizedThreadStart, T5>).Start("1");
				}
			}
			else
			{
				new Thread((ParameterizedThreadStart)kichNo<T4, Thread, T2, ParameterizedThreadStart, T5>).Start("0.1");
			}
		}
		else
		{
			new Thread((ParameterizedThreadStart)kichNo<T4, Thread, T2, ParameterizedThreadStart, T5>).Start("0.01");
		}
	}

	private void payNowEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0021: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00b4: Expected I4, but got O
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00df: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		isRunning = !isRunning;
		listRowIndex.Clear();
		T0 val = (T0)isRunning;
		if (val == null)
		{
			return;
		}
		T1 val2 = (T1)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count - 1);
		while (true)
		{
			T0 val4 = (T0)((nint)val3 >= 0);
			if (val4 == null)
			{
				break;
			}
			listRowIndex.Add(((List<DataGridViewRow>)val2)[(int)val3].Index);
			listData[((List<DataGridViewRow>)val2)[(int)val3].Index].message = frmMain.STATUS.Ready.ToString();
			val3 = (T2)(val3 - 1);
		}
		T0 val5 = (T0)(listRowIndex.Count > 0);
		if (val5 != null)
		{
			new Thread(payNow<T2, Thread, T0, ParameterizedThreadStart>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kichNo<T0, T1, T2, T3, T4>(T4 amount)
	{
		//IL_001d: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_00a1: Expected I4, but got O
		//IL_00a6: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected I4, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00ca: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		_003C_003Ec__DisplayClass38_0 _003C_003Ec__DisplayClass38_ = new _003C_003Ec__DisplayClass38_0();
		_003C_003Ec__DisplayClass38_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass38_.amount = amount;
		_003C_003Ec__DisplayClass38_.countThread = 0;
		T0 val = (T0)5;
		T0 val2 = (T0)(listRowIndex.Count - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			while (true)
			{
				T2 val4 = (T2)(isRunning && _003C_003Ec__DisplayClass38_.countThread >= (nint)val);
				if (val4 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T2 val5 = (T2)(!isRunning);
			if (val5 != null)
			{
				break;
			}
			T1 val6 = (T1)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass38_._003CkichNo_003Eb__0<T0, T2, T1, T3, T4, Dictionary<string, string>, string, List<ADSPRoject.Data.BusinessManager.billing_payment_methods>.Enumerator, Exception>);
			((Thread)val6).Start((object)(T0)listRowIndex[(int)val2]);
			T0 val7 = (T0)_003C_003Ec__DisplayClass38_.countThread;
			_003C_003Ec__DisplayClass38_.countThread = val7 + 1;
			val2 = (T0)(val2 - 1);
		}
		while (true)
		{
			T2 val8 = (T2)(isRunning && _003C_003Ec__DisplayClass38_.countThread > 0);
			if (val8 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		isRunning = false;
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void payNow<T0, T1, T2, T3>()
	{
		//IL_0016: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_009a: Expected I4, but got O
		//IL_009f: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected I4, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c3: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		_003C_003Ec__DisplayClass39_0 _003C_003Ec__DisplayClass39_ = new _003C_003Ec__DisplayClass39_0();
		_003C_003Ec__DisplayClass39_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass39_.countThread = 0;
		T0 val = (T0)5;
		T0 val2 = (T0)(listRowIndex.Count - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			while (true)
			{
				T2 val4 = (T2)(isRunning && _003C_003Ec__DisplayClass39_.countThread >= (nint)val);
				if (val4 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T2 val5 = (T2)(!isRunning);
			if (val5 != null)
			{
				break;
			}
			T1 val6 = (T1)new Thread(_003C_003Ec__DisplayClass39_._003CpayNow_003Eb__0<T0, T2, T1, T3, object, Dictionary<string, string>, string, List<pm_credit_card_data>.Enumerator>);
			((Thread)val6).Start((object)(T0)listRowIndex[(int)val2]);
			T0 val7 = (T0)_003C_003Ec__DisplayClass39_.countThread;
			_003C_003Ec__DisplayClass39_.countThread = val7 + 1;
			val2 = (T0)(val2 - 1);
		}
		while (true)
		{
			T2 val8 = (T2)(isRunning && _003C_003Ec__DisplayClass39_.countThread > 0);
			if (val8 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		isRunning = false;
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void copyIdCampEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 sender, T7 e)
	{
		//IL_007e: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_00a2: Expected I4, but got O
		//IL_00bf: Expected I4, but got O
		//IL_00de: Expected I4, but got O
		//IL_00fa: Expected O, but got I4
		//IL_010c: Expected I4, but got O
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0170: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvData.SelectedRows.Cast<T8>().Where((Func<T8, bool>)(object)(Func<DataGridViewRow, bool>)((T8 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T8, T4>)(object)(Func<DataGridViewRow, int>)((T8 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)"";
		T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count > 0);
		if (val4 != null)
		{
			T4 val5 = (T4)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T3 val6 = (T3)((nint)val5 >= 0);
				if (val6 == null)
				{
					break;
				}
				((List<adaccountsData>)val).Add(listData[((List<DataGridViewRow>)val2)[(int)val5].Index]);
				T3 val7 = (T3)(listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns != null && listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns.data != null);
				if (val7 != null)
				{
					T5 enumerator = (T5)listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns.data.GetEnumerator();
					try
					{
						while (((List<campaignsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							campaignsData current = ((List<campaignsData>.Enumerator*)(&enumerator))->Current;
							val3 = (T2)((string)val3 + current.id + ",");
						}
					}
					finally
					{
						((IDisposable)(*(List<campaignsData>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				val5 = (T4)(val5 - 1);
			}
		}
		T3 val8 = (T3)(((string)val3).Length > 0);
		if (val8 != null)
		{
			val3 = (T2)((string)val3).Remove(1, ((string)val3).Length - 1);
		}
		Clipboard.Clear();
		Clipboard.SetText((string)val3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void copyIdAdsetEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 sender, T8 e)
	{
		//IL_007e: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_00a2: Expected I4, but got O
		//IL_00bf: Expected I4, but got O
		//IL_00de: Expected I4, but got O
		//IL_00fa: Expected O, but got I4
		//IL_010f: Expected I4, but got O
		//IL_0153: Expected O, but got I4
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_01cc: Expected O, but got I4
		//IL_01de: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T4>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)"";
		T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count > 0);
		if (val4 != null)
		{
			T4 val5 = (T4)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T3 val6 = (T3)((nint)val5 >= 0);
				if (val6 == null)
				{
					break;
				}
				((List<adaccountsData>)val).Add(listData[((List<DataGridViewRow>)val2)[(int)val5].Index]);
				T3 val7 = (T3)(listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns != null && listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns.data != null);
				if (val7 != null)
				{
					T5 enumerator = (T5)listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns.data.GetEnumerator();
					try
					{
						while (((List<campaignsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							campaignsData current = ((List<campaignsData>.Enumerator*)(&enumerator))->Current;
							T3 val8 = (T3)(current.adsets != null && current.adsets.data != null);
							if (val8 == null)
							{
								continue;
							}
							T6 enumerator2 = (T6)current.adsets.data.GetEnumerator();
							try
							{
								while (((List<adsets_data>.Enumerator*)(&enumerator2))->MoveNext())
								{
									adsets_data current2 = ((List<adsets_data>.Enumerator*)(&enumerator2))->Current;
									val3 = (T2)((string)val3 + current2.id + ",");
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
				val5 = (T4)(val5 - 1);
			}
		}
		T3 val9 = (T3)(((string)val3).Length > 0);
		if (val9 != null)
		{
			val3 = (T2)((string)val3).Remove(1, ((string)val3).Length - 1);
		}
		Clipboard.Clear();
		Clipboard.SetText((string)val3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void copyIdAdsEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 sender, T9 e)
	{
		//IL_007e: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_00a2: Expected I4, but got O
		//IL_00bf: Expected I4, but got O
		//IL_00de: Expected I4, but got O
		//IL_00fa: Expected O, but got I4
		//IL_010f: Expected I4, but got O
		//IL_0156: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_022e: Expected O, but got I4
		//IL_0240: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvData.SelectedRows.Cast<T10>().Where((Func<T10, bool>)(object)(Func<DataGridViewRow, bool>)((T10 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T10, T4>)(object)(Func<DataGridViewRow, int>)((T10 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)"";
		T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count > 0);
		if (val4 != null)
		{
			T4 val5 = (T4)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T3 val6 = (T3)((nint)val5 >= 0);
				if (val6 == null)
				{
					break;
				}
				((List<adaccountsData>)val).Add(listData[((List<DataGridViewRow>)val2)[(int)val5].Index]);
				T3 val7 = (T3)(listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns != null && listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns.data != null);
				if (val7 != null)
				{
					T5 enumerator = (T5)listData[((List<DataGridViewRow>)val2)[(int)val5].Index].campaigns.data.GetEnumerator();
					try
					{
						while (((List<campaignsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							campaignsData current = ((List<campaignsData>.Enumerator*)(&enumerator))->Current;
							T3 val8 = (T3)(current.adsets != null && current.adsets.data != null);
							if (val8 == null)
							{
								continue;
							}
							T6 enumerator2 = (T6)current.adsets.data.GetEnumerator();
							try
							{
								while (((List<adsets_data>.Enumerator*)(&enumerator2))->MoveNext())
								{
									adsets_data current2 = ((List<adsets_data>.Enumerator*)(&enumerator2))->Current;
									T3 val9 = (T3)(current2.ads != null && current2.ads.data != null);
									if (val9 == null)
									{
										continue;
									}
									T7 enumerator3 = (T7)current2.ads.data.GetEnumerator();
									try
									{
										while (((List<ads_data>.Enumerator*)(&enumerator3))->MoveNext())
										{
											ads_data current3 = ((List<ads_data>.Enumerator*)(&enumerator3))->Current;
											val3 = (T2)((string)val3 + current3.id + ",");
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
				val5 = (T4)(val5 - 1);
			}
		}
		T3 val10 = (T3)(((string)val3).Length > 0);
		if (val10 != null)
		{
			val3 = (T2)((string)val3).Remove(1, ((string)val3).Length - 1);
		}
		Clipboard.Clear();
		Clipboard.SetText((string)val3);
	}

	private void openCamp()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clearActEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_00d9: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00f6: Expected I4, but got O
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		T0 val = (T0)((sender is T0) ? sender : null);
		T1 val2 = (T1)((MenuItem)val).Text.Equals("Clear dòng đã chọn");
		if (val2 == null)
		{
			T1 val3 = (T1)(frmMain.questioniMessage<DialogResult, string>("Bạn chắc xóa?") == DialogResult.Yes);
			if (val3 != null)
			{
				gvData.ClearSelection();
				gvData.DataSource = null;
				listData.Clear();
				gvData.DataSource = listData;
				loadTotal<T3, T7, T1>();
			}
			return;
		}
		T2 val4 = (T2)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T1 val5 = (T1)(((List<DataGridViewRow>)val4).Count > 0);
		if (val5 != null)
		{
			T3 val6 = (T3)(((List<DataGridViewRow>)val4).Count - 1);
			while (true)
			{
				T1 val7 = (T1)((nint)val6 >= 0);
				if (val7 == null)
				{
					break;
				}
				listData.RemoveAt(((List<DataGridViewRow>)val4)[(int)val6].Index);
				val6 = (T3)(val6 - 1);
			}
		}
		gvData.ClearSelection();
		gvData.DataSource = null;
		gvData.DataSource = listData;
		loadTotal<T3, T7, T1>();
	}

	private void pasteJsonActEvent<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		_003C_003Ec__DisplayClass45_0 _003C_003Ec__DisplayClass45_ = new _003C_003Ec__DisplayClass45_0();
		_003C_003Ec__DisplayClass45_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass45_.mi = (MenuItem)(T3)sender;
		gvData.ClearSelection();
		T0 val = (T0)new Thread((ParameterizedThreadStart)_003C_003Ec__DisplayClass45_._003CpasteJsonActEvent_003Eb__0<bool, string, List<string>, StringReader, List<adaccountsData>, Exception, T1, int, List<adaccountsData>.Enumerator>);
		((Thread)val).SetApartmentState(ApartmentState.STA);
		((Thread)val).Start();
	}

	private void publishCampTextEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0070: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00b1: Expected I4, but got O
		//IL_00d3: Expected I4, but got O
		//IL_00e4: Expected O, but got I4
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected I4, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0165: Expected O, but got I4
		//IL_0180: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)0;
		T2 val4 = (T2)0;
		T2 val5 = (T2)0;
		T2 val6 = (T2)0;
		T2 val7 = (T2)0;
		T2 val8 = (T2)0;
		T2 val9 = (T2)0;
		T3 val10 = (T3)(((List<DataGridViewRow>)val2).Count > 0);
		if (val10 != null)
		{
			T2 val11 = (T2)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T3 val12 = (T3)((nint)val11 >= 0);
				if (val12 == null)
				{
					break;
				}
				((List<string>)val).Add(listData[((List<DataGridViewRow>)val2)[(int)val11].Index].id);
				T2 val13 = (T2)listData[((List<DataGridViewRow>)val2)[(int)val11].Index].account_status;
				T2 val14 = val13;
				switch (val14 - 1)
				{
				default:
					if ((nint)val14 == 100)
					{
						val9 = (T2)(val9 + 1);
					}
					else if ((nint)val14 == 101)
					{
						val8 = (T2)(val8 + 1);
					}
					break;
				case 0:
					val3 = (T2)(val3 + 1);
					break;
				case 1:
					val4 = (T2)(val4 + 1);
					break;
				case 2:
					val5 = (T2)(val5 + 1);
					break;
				case 6:
					val6 = (T2)(val6 + 1);
					break;
				case 8:
					val7 = (T2)(val7 + 1);
					break;
				case 3:
				case 4:
				case 5:
				case 7:
					break;
				}
				val11 = (T2)(val11 - 1);
			}
		}
		frmPublishCampText frmPublishCampText2 = new frmPublishCampText((List<string>)val, this, (int)val3, (int)val4, (int)val5, (int)val6, (int)val7, (int)val8, (int)val9, null);
		frmPublishCampText2.TopLevel = false;
		base.Controls.Add(frmPublishCampText2);
		frmPublishCampText2.Show();
		frmPublishCampText2.PointToClient(new Point(0, 0));
		frmPublishCampText2.Height = frmPublishCampText2.Parent.Height - 200;
		frmPublishCampText2.Text = Text;
		frmPublishCampText2.BringToFront();
	}

	private void gvData_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0083: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c5: Expected O, but got I4
		listIdSelected.Clear();
		T0 val = (T0)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T1));
		T2 val2 = (T2)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T3 val3 = (T3)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val4 = (T2)((nint)val3 >= 0);
			if (val4 != null)
			{
				listIdSelected.Add(listData[((List<DataGridViewRow>)val)[(int)val3].Index].int_id);
				val3 = (T3)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void txtSearch_TextChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			chrome.frmMain.listFBEntity[chrome.indexEntity].txtSearch = txtSearch.Text;
		}
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		search<string, List<DataGridViewRow>, List<int>, List<adaccountsData>.Enumerator, int, bool, float, char, DataGridViewRow>();
	}

	private unsafe void search<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
	{
		//IL_0073: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00b1: Expected I4, but got O
		//IL_00d4: Expected I4, but got O
		//IL_00e8: Expected I4, but got O
		//IL_010b: Expected I4, but got O
		//IL_011f: Expected I4, but got O
		//IL_0142: Expected I4, but got O
		//IL_0156: Expected I4, but got O
		//IL_0179: Expected I4, but got O
		//IL_018d: Expected I4, but got O
		//IL_01b0: Expected I4, but got O
		//IL_01c4: Expected I4, but got O
		//IL_01e7: Expected I4, but got O
		//IL_01fb: Expected I4, but got O
		//IL_021e: Expected I4, but got O
		//IL_0232: Expected I4, but got O
		//IL_0255: Expected I4, but got O
		//IL_0269: Expected I4, but got O
		//IL_028c: Expected I4, but got O
		//IL_02a0: Expected I4, but got O
		//IL_02c3: Expected I4, but got O
		//IL_02d7: Expected I4, but got O
		//IL_02fa: Expected I4, but got O
		//IL_0301: Expected O, but got F4
		//IL_0326: Expected I4, but got O
		//IL_033a: Expected I4, but got O
		//IL_035d: Expected I4, but got O
		//IL_0371: Expected I4, but got O
		//IL_0394: Expected I4, but got O
		//IL_03a8: Expected I4, but got O
		//IL_03cb: Expected I4, but got O
		//IL_03df: Expected I4, but got O
		//IL_0402: Expected I4, but got O
		//IL_0416: Expected I4, but got O
		//IL_0439: Expected I4, but got O
		//IL_044d: Expected I4, but got O
		//IL_0470: Expected I4, but got O
		//IL_0484: Expected I4, but got O
		//IL_04a4: Expected I4, but got O
		//IL_04b8: Expected I4, but got O
		//IL_04d8: Expected I4, but got O
		//IL_04ec: Expected I4, but got O
		//IL_0505: Expected O, but got I4
		//IL_0516: Expected I4, but got O
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_0533: Expected O, but got I4
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_05a0: Expected O, but got I4
		//IL_05af: Expected I4, but got O
		//IL_05b6: Expected O, but got I4
		//IL_05cc: Expected I4, but got O
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected O, but got Unknown
		//IL_05e9: Expected O, but got I4
		//IL_0671: Expected O, but got I4
		//IL_067f: Expected O, but got I4
		//IL_0695: Expected I4, but got O
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Expected O, but got Unknown
		//IL_06b9: Expected O, but got I4
		gvData.ClearSelection();
		T3 enumerator = (T3)listData.GetEnumerator();
		try
		{
			while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
			{
				adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
				current.select_row = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val = (T0)txtSearch.Text.ToLower().Trim();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T7[1] { (T7)124 });
		T0[] array2 = array;
		T4 val2 = (T4)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T0 value = (T0)((string)val3).Trim();
			T4 val4 = (T4)0;
			while (true)
			{
				T5 val5 = (T5)((nint)val4 < listData.Count);
				if (val5 == null)
				{
					break;
				}
				T5 val6 = (T5)((listData[(int)val4].id != null && listData[(int)val4].id.ToLower().Contains((string)value)) || (listData[(int)val4].business_country_code != null && listData[(int)val4].business_country_code.ToLower().Contains((string)value)) || (listData[(int)val4].currency != null && listData[(int)val4].currency.ToLower().Contains((string)value)) || (listData[(int)val4].message != null && listData[(int)val4].message.ToLower().Contains((string)value)) || (listData[(int)val4].name != null && listData[(int)val4].name.ToLower().Contains((string)value)) || (listData[(int)val4].payment_status != null && listData[(int)val4].payment_status.ToLower().Contains((string)value)) || (listData[(int)val4].str_account_status != null && listData[(int)val4].str_account_status.ToLower().Contains((string)value)) || (listData[(int)val4].timezone_name != null && listData[(int)val4].timezone_name.ToLower().Contains((string)value)) || (listData[(int)val4].Has_Campaigns != null && listData[(int)val4].Has_Campaigns.ToLower().Contains((string)value)) || (listData[(int)val4].spend_cap != null && listData[(int)val4].spend_cap.ToLower().Contains((string)value)) || (listData[(int)val4].disable_reason_string != null && listData[(int)val4].disable_reason_string.ToLower().Contains((string)value)) || System.Runtime.CompilerServices.Unsafe.As<T6, float>(ref (T6)listData[(int)val4].adtrust_dsl).ToString().ToLower()
					.Contains((string)value) || (listData[(int)val4].threshold_amount != null && listData[(int)val4].threshold_amount.ToLower().Contains((string)value)) || (listData[(int)val4].balance != null && listData[(int)val4].balance.ToLower().Contains((string)value)) || (listData[(int)val4].spend_cap != null && listData[(int)val4].spend_cap.ToLower().Contains((string)value)) || (listData[(int)val4].amount_spent != null && listData[(int)val4].amount_spent.ToLower().Contains((string)value)) || (listData[(int)val4].get_remaining_amount != null && listData[(int)val4].get_remaining_amount.ToLower().Contains((string)value)) || (listData[(int)val4].payment != null && listData[(int)val4].payment.ToLower().Contains((string)value)) || (listData[(int)val4].Has_Campaigns != null && listData[(int)val4].Has_Campaigns.ToLower().Contains((string)value)) || (listData[(int)val4].disable_reason_string != null && listData[(int)val4].disable_reason_string.ToLower().Contains((string)value)) || (listData[(int)val4].payment_section_details != null && listData[(int)val4].payment_section_details.ToLower().Contains((string)value)));
				if (val6 != null)
				{
					listData[(int)val4].select_row = true;
				}
				val4 = (T4)(val4 + 1);
			}
			val2 = (T4)(val2 + 1);
		}
		gvData.DataSource = null;
		listData = listData.OrderByDescending((Func<adaccountsData, T5>)(object)(Func<adaccountsData, bool>)((adaccountsData a) => (T5)a.select_row)).ToList();
		gvData.DataSource = listData;
		T4 val7 = (T4)0;
		while (true)
		{
			T5 val8 = (T5)((nint)val7 < listData.Count);
			if (val8 == null)
			{
				break;
			}
			T5 val9 = (T5)listData[(int)val7].select_row;
			if (val9 != null)
			{
				gvData.Rows[(int)val7].Selected = true;
			}
			val7 = (T4)(val7 + 1);
		}
		listIdSelected.Clear();
		T1 val10 = (T1)gvData.SelectedRows.Cast<T8>().Where((Func<T8, bool>)(object)(Func<DataGridViewRow, bool>)((T8 row) => (T5)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T8, T4>)(object)(Func<DataGridViewRow, int>)((T8 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T2));
		T5 val11 = (T5)(((List<DataGridViewRow>)val10).Count > 0);
		if (val11 != null)
		{
			T4 val12 = (T4)(((List<DataGridViewRow>)val10).Count - 1);
			while (true)
			{
				T5 val13 = (T5)((nint)val12 >= 0);
				if (val13 == null)
				{
					break;
				}
				listIdSelected.Add(listData[((List<DataGridViewRow>)val10)[(int)val12].Index].int_id);
				val12 = (T4)(val12 - 1);
			}
		}
		loadTotal<T4, T3, T5>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button4_Click<T0, T1>(T0 sender, T1 e)
	{
		flag_load_data = 1;
		loadToken<string, decimal>();
		frmMain.infoMessage("Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void loadToken<T0, T1>()
	{
		gvData.DataSource = null;
		T0 url = (T0)string.Concat((string[])(object)new T0[6]
		{
			(T0)ResouceControl.getResouce("RESOUCE_API_FACEBOOK_GRAPHQL_V13"),
			(T0)"603561707534762/client_ad_accounts?access_token=",
			(T0)txtToken.Text,
			(T0)"&_reqName=object:business/client_ad_accounts&_reqSrc=BusinessConnectedClientAdAccountsStore.brands&date_format=U&fields=[%22id%22,%22name%22]&limit=",
			(T0)((decimal)(T1)numLimit.Value).ToString(),
			(T0)"&locale=en_US&method=get&pretty=0&sort=name_ascending&suppress_http_code=1&xref="
		});
		T0 val = HttpRequestClassToken.Get<T0, HttpWebRequest, HttpWebResponse, StreamReader, WebException, Exception>(url);
		adaccounts adaccounts = JsonConvert.DeserializeObject<adaccounts>((string)val);
		listData = adaccounts.data;
		gvData.DataSource = listData;
	}

	private void txtToken_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtBMManagerToken = txtToken.Text;
		frmMain.settingSaving();
	}

	private void txtBMID_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.txtBMManagerBMID = txtBMID.Text;
		frmMain.settingSaving();
	}

	private void numLimit_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.txtBMManagerLimit = int.Parse(((decimal)(T0)numLimit.Value).ToString());
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmAdsManager_Load<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0070: Expected O, but got I4
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		ccbTypeCreatePage.SelectedIndex = 0;
		txtToken.Text = frmMain.setting.txtBMManagerToken;
		txtBMID.Text = frmMain.setting.txtBMManagerBMID;
		numLimit.Value = frmMain.setting.txtBMManagerLimit;
		T0 val = (T0)(chrome != null);
		if (val == null)
		{
			txtBMIDTQCKInBM.Text = frmMain.setting.txtBMManagerBMID;
		}
		else
		{
			txtBMIDTQCKInBM.Text = chrome.frmMain.listFBEntity[chrome.indexEntity].txtBMIDTQCKInBM;
			txtSearch.Text = chrome.frmMain.listFBEntity[chrome.indexEntity].txtSearch;
			ccbActFillter.SelectedIndex = chrome.frmMain.listFBEntity[chrome.indexEntity].ccbActFillter;
			ccbActSort.SelectedIndex = chrome.frmMain.listFBEntity[chrome.indexEntity].ccbActSort;
			txtSearchByKeyword.Text = chrome.frmMain.listFBEntity[chrome.indexEntity].txtSearchByKeyword;
			numMaxAct.Value = chrome.frmMain.listFBEntity[chrome.indexEntity].numMaxAct;
		}
		tabGroup.SelectedIndex = tabGroup.TabCount - 1;
	}

	private void txtBMIDTQCKInBM_TextChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			chrome.frmMain.listFBEntity[chrome.indexEntity].txtBMIDTQCKInBM = txtBMIDTQCKInBM.Text;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button5_Click<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_0011: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		T0 val = (T0)string.IsNullOrWhiteSpace(txtBMIDTQCKInBM.Text);
		if (val == null)
		{
			isLoading = true;
			button5.Enabled = false;
			T0 val2 = (T0)(listData == null);
			if (val2 != null)
			{
				listData = (List<adaccountsData>)Activator.CreateInstance(typeof(T3));
			}
			flag_load_data = 2;
			gvData.DataSource = null;
			progressBar1.Style = ProgressBarStyle.Marquee;
			new Thread(thrLoadDataToken<T0, int, string, Dictionary<string, string>, ReadOnlyCollection<IWebElement>, IEnumerator, Match, char, IDisposable, Exception, IWebElement, T3>).Start();
			timer_load_data_token.Start();
			lbCountLoadAct.Text = "0";
		}
		else
		{
			frmMain.errorMessage("Chưa nhập BM ID!");
			txtBMIDTQCKInBM.Focus();
		}
	}

	private void thrLoadDataToken<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
	{
		//IL_0086: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		//IL_00e3: Expected O, but got I4
		//IL_00f2: Expected I4, but got O
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_010c: Expected O, but got I4
		adaccounts fullAdsInfo_In_BM = chrome.getFullAdsInfo_In_BM<T2, T3, T0, T1, T4, T5, T6, T7, T8, T9, T10, T11>((T2)txtBMIDTQCKInBM.Text, (T0)0, (T1)chrome.frmMain.listFBEntity[chrome.indexEntity].ccbActFillter, (T1)chrome.frmMain.listFBEntity[chrome.indexEntity].ccbActSort, (T2)chrome.frmMain.listFBEntity[chrome.indexEntity].txtSearchByKeyword);
		T0 val = (T0)(fullAdsInfo_In_BM != null && ((fullAdsInfo_In_BM.data != null) & (fullAdsInfo_In_BM.data.Count > 0)));
		if (val == null)
		{
			listData.Clear();
		}
		else
		{
			listData = fullAdsInfo_In_BM.data;
		}
		T1 val2 = (T1)0;
		while (true)
		{
			T0 val3 = (T0)((nint)val2 < listData.Count);
			if (val3 == null)
			{
				break;
			}
			T0 val4 = (T0)listIdSelected.Contains(listData[(int)val2].int_id);
			if (val4 != null)
			{
				listData[(int)val2].select_row = true;
			}
			val2 = (T1)(val2 + 1);
		}
		listData = listData.OrderByDescending((Func<adaccountsData, T0>)(object)(Func<adaccountsData, bool>)((adaccountsData a) => (T0)a.select_row)).ToList();
		isLoading = false;
	}

	private void timer_load_data_token_Tick<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_009a: Expected I4, but got O
		//IL_00a5: Expected O, but got I4
		//IL_00b9: Expected I4, but got O
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00d3: Expected O, but got I4
		T0 val = (T0)(!isLoading);
		if (val == null)
		{
			lbCountLoadAct.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)chrome.frmMain.listFBEntity[chrome.indexEntity].lbCountLoadAct).ToString();
			return;
		}
		timer_load_data_token.Stop();
		gvData.DataSource = listData;
		T0 val2 = (T0)(listIdSelected.Count > 0);
		if (val2 != null)
		{
			gvData.ClearSelection();
			T1 val3 = (T1)0;
			while (true)
			{
				T0 val4 = (T0)((nint)val3 < listData.Count);
				if (val4 == null)
				{
					break;
				}
				T0 val5 = (T0)listIdSelected.Contains(listData[(int)val3].int_id);
				if (val5 != null)
				{
					gvData.Rows[(int)val3].Selected = true;
				}
				val3 = (T1)(val3 + 1);
			}
		}
		loadTotal<T1, T4, T0>();
		button5.Enabled = true;
		progressBar1.Style = ProgressBarStyle.Blocks;
	}

	private void numLimitTkqcInBM_ValueChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtSearch_KeyDown<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 sender, T2 e)
	{
		//IL_000b: Expected O, but got I4
		T0 val = (T0)(((KeyEventArgs)e).KeyCode == Keys.Return);
		if (val != null)
		{
			search<T3, T4, T5, T6, T7, T0, T8, T9, T10>();
		}
	}

	private void plBrowser_SizeChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val == null)
		{
			return;
		}
		try
		{
			T0 val2 = (T0)(plBrowser.Width > 2000);
			if (val2 == null)
			{
				((RemoteWebDriver)chrome.chrome).Manage().Window.Size = new Size(plBrowser.Width, plBrowser.Height);
			}
			else
			{
				((RemoteWebDriver)chrome.chrome).Manage().Window.Size = new Size((int)Math.Round((double)plBrowser.Width / 1.25), (int)Math.Round((double)plBrowser.Height / 1.25));
			}
			((RemoteWebDriver)chrome.chrome).Manage().Window.Position = new Point(0, 0);
		}
		catch
		{
		}
	}

	private void button7_Click<T0, T1>(T0 sender, T1 e)
	{
		isLoading = true;
		flag_load_data = 0;
		gvBM.DataSource = null;
		button7.Enabled = false;
		progressBar2.Style = ProgressBarStyle.Marquee;
		new Thread(thrLoadBM<bool, Dictionary<string, string>, string, List<BusinessManagerEntity_businesses_Data>, Exception>).Start();
		timer_load_bm.Start();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void thrLoadBM<T0, T1, T2, T3, T4>()
	{
		//IL_0028: Expected O, but got I4
		BusinessManager = (List<BusinessManagerEntity_businesses_Data>)chrome.mtLoadBM<T1, T2, T0, T3, T4>(out strError);
		isLoading = false;
		T0 val = (T0)(BusinessManager == null);
		if (val != null)
		{
			frmMain.errorMessage((T2)"Không có BM!");
		}
	}

	private void timer_load_bm_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		T0 val = (T0)(!isLoading);
		if (val != null)
		{
			timer_load_bm.Stop();
			button7.Enabled = true;
			progressBar2.Style = ProgressBarStyle.Blocks;
			T0 val2 = (T0)(BusinessManager != null);
			if (val2 != null)
			{
				loadBM<T0, int>();
			}
		}
	}

	private void loadBM<T0, T1>()
	{
		//IL_0026: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0042: Expected I4, but got O
		//IL_004d: Expected O, but got I4
		//IL_005c: Expected I4, but got O
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0075: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_00f5: Expected I4, but got O
		//IL_0101: Expected O, but got I4
		//IL_0117: Expected I4, but got O
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0134: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		gvBM.DataSource = null;
		T0 val = (T0)(BusinessManager != null && BusinessManager.Count > 0);
		if (val != null)
		{
			T1 val2 = (T1)0;
			while (true)
			{
				T0 val3 = (T0)((nint)val2 < BusinessManager.Count);
				if (val3 == null)
				{
					break;
				}
				T0 val4 = (T0)listBMClick.Contains(BusinessManager[(int)val2].id);
				if (val4 != null)
				{
					BusinessManager[(int)val2].select_row = true;
				}
				val2 = (T1)(val2 + 1);
			}
			BusinessManager = BusinessManager.OrderByDescending((Func<BusinessManagerEntity_businesses_Data, T0>)(object)(Func<BusinessManagerEntity_businesses_Data, bool>)((BusinessManagerEntity_businesses_Data a) => (T0)a.select_row)).ToList();
			gvBM.DataSource = BusinessManager;
			T0 val5 = (T0)(listBMClick.Count > 0);
			if (val5 != null)
			{
				gvBM.ClearSelection();
				T1 val6 = (T1)0;
				while (true)
				{
					T0 val7 = (T0)((nint)val6 < BusinessManager.Count);
					if (val7 == null)
					{
						break;
					}
					T0 val8 = (T0)listBMClick.Contains(BusinessManager[(int)val6].id);
					if (val8 != null)
					{
						gvBM.Rows[(int)val6].Selected = true;
					}
					val6 = (T1)(val6 + 1);
				}
			}
		}
		toolStripStatusLabel5.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)gvBM.Rows.Count).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvBM_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Quản lý BM", (EventHandler)bmManagerEvent<List<string>, List<DataGridViewRow>, T0, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Quản lý TKQC", (EventHandler)tkqcInBMEvent<List<adaccountsData>, List<DataGridViewRow>, T0, int, List<adaccountsData>.Enumerator, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Quản lý User", (EventHandler)userInBMEvent<string, List<DataGridViewRow>, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 val3 = (T2)new MenuItem("Copy");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("ID BM", (EventHandler)copyIdBMEvent<List<DataGridViewRow>, T0, T2, Thread, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("ID TKQC", (EventHandler)copyIdBMEvent<List<DataGridViewRow>, T0, T2, Thread, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			val3 = (T2)new MenuItem("Trình duyệt");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("Mở trình BM", (EventHandler)openBMEvent<List<DataGridViewRow>, T0, int, string, T3, EventArgs, DataGridViewRow, IJavaScriptExecutor>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvBM, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copyIdBMEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00ba: Expected I4, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00ec: Expected I4, but got O
		//IL_0137: Expected I4, but got O
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0166: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		T0 val = (T0)gvBM.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)sender;
		string bmId = "";
		T4 val4 = (T4)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val5 = (T1)((nint)val4 >= 0);
			if (val5 == null)
			{
				break;
			}
			T1 val6 = (T1)((MenuItem)val3).Text.Equals("ID BM");
			if (val6 == null)
			{
				T1 val7 = (T1)(!string.IsNullOrWhiteSpace(BusinessManager[((List<DataGridViewRow>)val)[(int)val4].Index].TKQC));
				if (val7 != null)
				{
					bmId = bmId + BusinessManager[((List<DataGridViewRow>)val)[(int)val4].Index].TKQC.Replace("act_", "").Trim() + "|";
				}
			}
			else
			{
				bmId = bmId + BusinessManager[((List<DataGridViewRow>)val)[(int)val4].Index].id + "|";
			}
			val4 = (T4)(val4 - 1);
		}
		T1 val8 = (T1)bmId.EndsWith("|");
		if (val8 != null)
		{
			bmId = bmId.Substring(0, bmId.Length - 1);
		}
		T3 val9 = (T3)new Thread((ParameterizedThreadStart)delegate
		{
			Clipboard.Clear();
			Clipboard.SetText(bmId);
		});
		((Thread)val9).SetApartmentState(ApartmentState.STA);
		((Thread)val9).Start();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void openBMEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0089: Expected I4, but got O
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00be: Expected O, but got I4
		T0 val = (T0)gvBM.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				T3 script = (T3)("window.open('https://business.facebook.com/settings/system-users?business_id=" + BusinessManager[((List<DataGridViewRow>)val)[(int)val3].Index].id + "');");
				chrome.executeScript<T3, T7, T2, T1, T4>(script);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void userInBMEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_006f: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_0095: Expected I4, but got O
		//IL_00b0: Expected O, but got I4
		try
		{
			T0 val = (T0)string.Empty;
			T1 val2 = (T1)gvBM.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
				.ToList();
			T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
			if (val3 != null)
			{
				T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 != null)
				{
					val = (T0)BusinessManager[((List<DataGridViewRow>)val2)[(int)val4].Index].id;
				}
			}
			T2 val6 = (T2)(!string.IsNullOrWhiteSpace((string)val));
			if (val6 != null)
			{
				frmUserBMManager frmUserBMManager2 = new frmUserBMManager(this, val.ToString());
				frmUserBMManager2.TopLevel = false;
				base.Controls.Add(frmUserBMManager2);
				frmUserBMManager2.Show();
				frmUserBMManager2.Text = Text;
				frmUserBMManager2.BringToFront();
			}
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	private unsafe void tkqcInBMEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		//IL_009b: Expected I4, but got O
		//IL_00ba: Expected I4, but got O
		//IL_00d6: Expected O, but got I4
		//IL_00e8: Expected I4, but got O
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0140: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvBM.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				T2 val6 = (T2)(BusinessManager[((List<DataGridViewRow>)val2)[(int)val4].Index].owned_ad_accounts != null && BusinessManager[((List<DataGridViewRow>)val2)[(int)val4].Index].owned_ad_accounts.data != null);
				if (val6 != null)
				{
					T4 enumerator = (T4)BusinessManager[((List<DataGridViewRow>)val2)[(int)val4].Index].owned_ad_accounts.data.GetEnumerator();
					try
					{
						while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
						{
							adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
							((List<adaccountsData>)val).Add(current);
						}
					}
					finally
					{
						((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				val4 = (T3)(val4 - 1);
			}
		}
		frmPublishCampText frmPublishCampText2 = new frmPublishCampText(null, this, 0, 0, 0, 0, 0, 0, 0, (List<adaccountsData>)val);
		frmPublishCampText2.TopLevel = false;
		base.Controls.Add(frmPublishCampText2);
		frmPublishCampText2.Show();
		frmPublishCampText2.Text = Text;
		frmPublishCampText2.BringToFront();
	}

	private void bmManagerEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0096: Expected I4, but got O
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvBM.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				((List<string>)val).Add(BusinessManager[((List<DataGridViewRow>)val2)[(int)val4].Index].id);
				val4 = (T3)(val4 - 1);
			}
		}
		frmBMManager frmBMManager2 = new frmBMManager((List<string>)val, this);
		frmBMManager2.TopLevel = false;
		base.Controls.Add(frmBMManager2);
		frmBMManager2.Show();
		frmBMManager2.Text = Text;
		frmBMManager2.BringToFront();
	}

	private void gvBM_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0083: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c5: Expected O, but got I4
		listBMClick.Clear();
		T0 val = (T0)gvBM.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T1));
		T2 val2 = (T2)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T3 val3 = (T3)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val4 = (T2)((nint)val3 >= 0);
			if (val4 != null)
			{
				listBMClick.Add(BusinessManager[((List<DataGridViewRow>)val)[(int)val3].Index].id);
				val3 = (T3)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void button6_Click<T0, T1>(T0 sender, T1 e)
	{
		frmReceiptBM frmReceiptBM2 = new frmReceiptBM(this, null, null);
		frmReceiptBM2.TopLevel = false;
		base.Controls.Add(frmReceiptBM2);
		frmReceiptBM2.Show();
		frmReceiptBM2.Text = Text;
		frmReceiptBM2.BringToFront();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvBM_ColumnHeaderMouseClick<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_01eb: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		//IL_029d: Expected O, but got I4
		//IL_02b4: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_0396: Expected I4, but got O
		//IL_03a2: Expected O, but got I4
		//IL_03b8: Expected I4, but got O
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03d5: Expected O, but got I4
		T0 businessManager = (T0)Activator.CreateInstance(typeof(T0));
		T1 val = (T1)(BusinessManager != null);
		if (val == null)
		{
			return;
		}
		T2 val2 = (T2)gvBM.Columns[((DataGridViewCellMouseEventArgs)e).ColumnIndex];
		isAscending = !isAscending;
		T1 val3 = (T1)isAscending;
		if (val3 == null)
		{
			T1 val4 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("id");
			if (val4 == null)
			{
				T1 val5 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name");
				if (val5 == null)
				{
					T1 val6 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("TKQC");
					if (val6 != null)
					{
						businessManager = (T0)BusinessManager.OrderBy((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.TKQC)).ToList();
					}
					else
					{
						T1 val7 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("Payment");
						if (val7 == null)
						{
							T1 val8 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("message");
							if (val8 != null)
							{
								businessManager = (T0)BusinessManager.OrderBy((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.message)).ToList();
							}
						}
						else
						{
							businessManager = (T0)BusinessManager.OrderBy((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.Payment)).ToList();
						}
					}
				}
				else
				{
					businessManager = (T0)BusinessManager.OrderBy((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.name)).ToList();
				}
			}
			else
			{
				businessManager = (T0)BusinessManager.OrderBy((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.id)).ToList();
			}
		}
		else
		{
			T1 val9 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("id");
			if (val9 != null)
			{
				businessManager = (T0)BusinessManager.OrderByDescending((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.id)).ToList();
			}
			else
			{
				T1 val10 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name");
				if (val10 == null)
				{
					T1 val11 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("TKQC");
					if (val11 != null)
					{
						businessManager = (T0)BusinessManager.OrderByDescending((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.TKQC)).ToList();
					}
					else
					{
						T1 val12 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("Payment");
						if (val12 == null)
						{
							T1 val13 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("message");
							if (val13 != null)
							{
								businessManager = (T0)BusinessManager.OrderByDescending((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.message)).ToList();
							}
						}
						else
						{
							businessManager = (T0)BusinessManager.OrderByDescending((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.Payment)).ToList();
						}
					}
				}
				else
				{
					businessManager = (T0)BusinessManager.OrderByDescending((Func<BusinessManagerEntity_businesses_Data, T6>)(object)(Func<BusinessManagerEntity_businesses_Data, string>)((BusinessManagerEntity_businesses_Data a) => (T6)a.name)).ToList();
				}
			}
		}
		BusinessManager = (List<BusinessManagerEntity_businesses_Data>)businessManager;
		gvBM.DataSource = null;
		gvBM.DataSource = BusinessManager;
		gvBM.ClearSelection();
		T3 val14 = (T3)0;
		while (true)
		{
			T1 val15 = (T1)((nint)val14 < BusinessManager.Count);
			if (val15 != null)
			{
				T1 val16 = (T1)listBMClick.Contains(BusinessManager[(int)val14].id);
				if (val16 != null)
				{
					gvBM.Rows[(int)val14].Selected = true;
				}
				val14 = (T3)(val14 + 1);
				continue;
			}
			break;
		}
	}

	private void button8_Click<T0, T1>(T0 sender, T1 e)
	{
		isLoading = true;
		flag_load_data = 0;
		gvPage.DataSource = null;
		button8.Enabled = false;
		progressBar3.Style = ProgressBarStyle.Marquee;
		new Thread(thrLoadPage<bool, List<facebook_pagesData>, string, Exception, Dictionary<string, string>>).Start();
		timer_load_page.Start();
	}

	private void thrLoadPage<T0, T1, T2, T3, T4>()
	{
		//IL_0028: Expected O, but got I4
		Pages = (List<facebook_pagesData>)chrome.mtLoadPage<T1, T2, T0, T3, T4>(out strError);
		isLoading = false;
		T0 val = (T0)(Pages == null);
		if (val != null)
		{
			frmMain.errorMessage((T2)strError);
		}
	}

	private void timer_load_page_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		T0 val = (T0)(!isLoading);
		if (val != null)
		{
			timer_load_page.Stop();
			button8.Enabled = true;
			progressBar3.Style = ProgressBarStyle.Blocks;
			T0 val2 = (T0)(Pages != null);
			if (val2 != null)
			{
				loadPage<int, T0>();
			}
		}
	}

	private unsafe void loadPage<T0, T1>()
	{
		//IL_0026: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0042: Expected I4, but got O
		//IL_004d: Expected O, but got I4
		//IL_005c: Expected I4, but got O
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0076: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00f7: Expected I4, but got O
		//IL_0103: Expected O, but got I4
		//IL_0119: Expected I4, but got O
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0136: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		gvPage.DataSource = null;
		T1 val = (T1)(Pages != null && Pages.Count > 0);
		if (val != null)
		{
			T0 val2 = (T0)0;
			while (true)
			{
				T1 val3 = (T1)((nint)val2 < Pages.Count);
				if (val3 == null)
				{
					break;
				}
				T1 val4 = (T1)listPageClick.Contains(Pages[(int)val2].id);
				if (val4 != null)
				{
					Pages[(int)val2].select_row = true;
				}
				val2 = (T0)(val2 + 1);
			}
			Pages = Pages.OrderByDescending((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.select_row)).ToList();
			gvPage.DataSource = Pages;
			T1 val5 = (T1)(listPageClick.Count > 0);
			if (val5 != null)
			{
				gvPage.ClearSelection();
				T0 val6 = (T0)0;
				while (true)
				{
					T1 val7 = (T1)((nint)val6 < Pages.Count);
					if (val7 == null)
					{
						break;
					}
					T1 val8 = (T1)listPageClick.Contains(Pages[(int)val6].id);
					if (val8 != null)
					{
						gvPage.Rows[(int)val6].Selected = true;
					}
					val6 = (T0)(val6 + 1);
				}
			}
		}
		toolStripStatusLabel9.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvPage.Rows.Count).ToString();
		lbPageLive.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)((IEnumerable<facebook_pagesData>)Pages).Where((Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)(!a.is_restricted))).Count()).ToString();
		T0 val9 = (T0)((IEnumerable<facebook_pagesData>)Pages).Where((Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.has_transitioned_to_new_page_experience)).Count();
		lbPageNormal.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)(Pages.Count - val9)).ToString();
		lbPagePro5.Text = ((int*)(&val9))->ToString();
	}

	private void gvPage_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0083: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c5: Expected O, but got I4
		listPageClick.Clear();
		T0 val = (T0)gvPage.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T1));
		T2 val2 = (T2)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T3 val3 = (T3)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val4 = (T2)((nint)val3 >= 0);
			if (val4 != null)
			{
				listPageClick.Add(Pages[((List<DataGridViewRow>)val)[(int)val3].Index].id);
				val3 = (T3)(val3 - 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvPage_ColumnHeaderMouseClick<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_0215: Expected O, but got I4
		//IL_036d: Expected O, but got I4
		//IL_0387: Expected O, but got I4
		//IL_03d3: Expected O, but got I4
		//IL_03ed: Expected O, but got I4
		//IL_0439: Expected O, but got I4
		//IL_0485: Expected O, but got I4
		//IL_049f: Expected O, but got I4
		//IL_04b9: Expected O, but got I4
		//IL_0505: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0688: Expected O, but got I4
		//IL_069d: Expected I4, but got O
		//IL_06a9: Expected O, but got I4
		//IL_06bf: Expected I4, but got O
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Expected O, but got Unknown
		//IL_06dc: Expected O, but got I4
		T0 pages = (T0)Activator.CreateInstance(typeof(T0));
		T1 val = (T1)(Pages != null);
		if (val == null)
		{
			return;
		}
		T2 val2 = (T2)gvPage.Columns[((DataGridViewCellMouseEventArgs)e).ColumnIndex];
		isAscending = !isAscending;
		T1 val3 = (T1)isAscending;
		if (val3 != null)
		{
			T1 val4 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("id");
			if (val4 == null)
			{
				T1 val5 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("additional_profile_id");
				if (val5 != null)
				{
					pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.additional_profile_id)).ToList();
				}
				else
				{
					T1 val6 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name");
					if (val6 == null)
					{
						T1 val7 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name_with_location_descriptor");
						if (val7 == null)
						{
							T1 val8 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("category");
							if (val8 != null)
							{
								pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.category)).ToList();
							}
							else
							{
								T1 val9 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("is_published");
								if (val9 != null)
								{
									pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.is_published)).ToList();
								}
								else
								{
									T1 val10 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("is_restricted");
									if (val10 == null)
									{
										T1 val11 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("has_transitioned_to_new_page_experience");
										if (val11 != null)
										{
											pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.has_transitioned_to_new_page_experience)).ToList();
										}
										else
										{
											T1 val12 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("followers_count");
											if (val12 == null)
											{
												T1 val13 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("message");
												if (val13 != null)
												{
													pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.message)).ToList();
												}
											}
											else
											{
												pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T3>)(object)(Func<facebook_pagesData, int>)((facebook_pagesData a) => (T3)a.followers_count)).ToList();
											}
										}
									}
									else
									{
										pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.is_restricted)).ToList();
									}
								}
							}
						}
						else
						{
							pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.name)).ToList();
						}
					}
					else
					{
						pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.name)).ToList();
					}
				}
			}
			else
			{
				pages = (T0)Pages.OrderByDescending((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.id)).ToList();
			}
		}
		else
		{
			T1 val14 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("id");
			if (val14 == null)
			{
				T1 val15 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("additional_profile_id");
				if (val15 != null)
				{
					pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.additional_profile_id)).ToList();
				}
				else
				{
					T1 val16 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name");
					if (val16 == null)
					{
						T1 val17 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name_with_location_descriptor");
						if (val17 != null)
						{
							pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.name)).ToList();
						}
						else
						{
							T1 val18 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("category");
							if (val18 != null)
							{
								pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.category)).ToList();
							}
							else
							{
								T1 val19 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("is_published");
								if (val19 == null)
								{
									T1 val20 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("is_restricted");
									if (val20 == null)
									{
										T1 val21 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("has_transitioned_to_new_page_experience");
										if (val21 != null)
										{
											pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.has_transitioned_to_new_page_experience)).ToList();
										}
										else
										{
											T1 val22 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("followers_count");
											if (val22 == null)
											{
												T1 val23 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("message");
												if (val23 != null)
												{
													pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.message)).ToList();
												}
											}
											else
											{
												pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T3>)(object)(Func<facebook_pagesData, int>)((facebook_pagesData a) => (T3)a.followers_count)).ToList();
											}
										}
									}
									else
									{
										pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.is_restricted)).ToList();
									}
								}
								else
								{
									pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T1>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T1)a.is_published)).ToList();
								}
							}
						}
					}
					else
					{
						pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.name)).ToList();
					}
				}
			}
			else
			{
				pages = (T0)Pages.OrderBy((Func<facebook_pagesData, T6>)(object)(Func<facebook_pagesData, string>)((facebook_pagesData a) => (T6)a.id)).ToList();
			}
		}
		Pages = (List<facebook_pagesData>)pages;
		gvPage.DataSource = null;
		gvPage.DataSource = Pages;
		gvPage.ClearSelection();
		T3 val24 = (T3)0;
		while (true)
		{
			T1 val25 = (T1)((nint)val24 < Pages.Count);
			if (val25 != null)
			{
				T1 val26 = (T1)listPageClick.Contains(Pages[(int)val24].id);
				if (val26 != null)
				{
					gvPage.Rows[(int)val24].Selected = true;
				}
				val24 = (T3)(val24 + 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvPage_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Cập nhật page", (EventHandler)pageUpdateEvent<List<string>, List<DataGridViewRow>, T0, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 val3 = (T2)new MenuItem("Copy");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("ID", (EventHandler)copyPageEvent<T2, string, List<DataGridViewRow>, Thread, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("ID Pro5", (EventHandler)copyPageEvent<T2, string, List<DataGridViewRow>, Thread, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("ID|Tên Page", (EventHandler)copyPageEvent<T2, string, List<DataGridViewRow>, Thread, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("Check quản trị", (EventHandler)checkAdminPageEvent<T0, List<DataGridViewRow>, int, T3, EventArgs, DataGridViewRow>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			val3 = (T2)new MenuItem("Trình duyệt");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("Mở page", (EventHandler)openPageEvent<List<DataGridViewRow>, T0, int, string, T3, EventArgs, DataGridViewRow, IJavaScriptExecutor>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvPage, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void checkAdminPageEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0021: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00b4: Expected I4, but got O
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00df: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		isRunning = !isRunning;
		listRowIndex.Clear();
		T0 val = (T0)isRunning;
		if (val == null)
		{
			return;
		}
		T1 val2 = (T1)gvPage.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count - 1);
		while (true)
		{
			T0 val4 = (T0)((nint)val3 >= 0);
			if (val4 == null)
			{
				break;
			}
			listRowIndex.Add(((List<DataGridViewRow>)val2)[(int)val3].Index);
			Pages[((List<DataGridViewRow>)val2)[(int)val3].Index].message = frmMain.STATUS.Ready.ToString();
			val3 = (T2)(val3 - 1);
		}
		T0 val5 = (T0)(listRowIndex.Count > 0);
		if (val5 != null)
		{
			new Thread(checkAdminPage<T2, Thread, T0, ParameterizedThreadStart>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void checkAdminPage<T0, T1, T2, T3>()
	{
		//IL_0016: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_009a: Expected I4, but got O
		//IL_009f: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected I4, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c3: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		_003C_003Ec__DisplayClass90_0 _003C_003Ec__DisplayClass90_ = new _003C_003Ec__DisplayClass90_0();
		_003C_003Ec__DisplayClass90_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass90_.countThread = 0;
		T0 val = (T0)5;
		T0 val2 = (T0)(listRowIndex.Count - 1);
		while (true)
		{
			T2 val3 = (T2)((nint)val2 >= 0);
			if (val3 == null)
			{
				break;
			}
			while (true)
			{
				T2 val4 = (T2)(isRunning && _003C_003Ec__DisplayClass90_.countThread >= (nint)val);
				if (val4 == null)
				{
					break;
				}
				Thread.Sleep(1500);
			}
			T2 val5 = (T2)(!isRunning);
			if (val5 != null)
			{
				break;
			}
			T1 val6 = (T1)new Thread(_003C_003Ec__DisplayClass90_._003CcheckAdminPage_003Eb__0<T0, T1, T2, string, List<core_app_admins_for_additional_profile_edges>.Enumerator, List<outgoing_core_app_admin_invites>.Enumerator, T3, object, Dictionary<string, string>>);
			((Thread)val6).Start((object)(T0)listRowIndex[(int)val2]);
			T0 val7 = (T0)_003C_003Ec__DisplayClass90_.countThread;
			_003C_003Ec__DisplayClass90_.countThread = val7 + 1;
			val2 = (T0)(val2 - 1);
		}
		while (true)
		{
			T2 val8 = (T2)(isRunning && _003C_003Ec__DisplayClass90_.countThread > 0);
			if (val8 == null)
			{
				break;
			}
			Thread.Sleep(1500);
		}
		isRunning = false;
		frmMain.infoMessage("Done");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copyPageEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 sender, T8 e)
	{
		//IL_0088: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00cb: Expected I4, but got O
		//IL_00fc: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_0130: Expected I4, but got O
		//IL_0179: Expected I4, but got O
		//IL_01a2: Expected I4, but got O
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d4: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)((MenuItem)val).Text;
		try
		{
			T2 val3 = (T2)gvPage.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T4)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T5>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T5)((DataGridViewBand)row).Index))
				.ToList();
			string value = "";
			T4 val4 = (T4)(((List<DataGridViewRow>)val3).Count > 0);
			if (val4 != null)
			{
				T5 val5 = (T5)(((List<DataGridViewRow>)val3).Count - 1);
				while (true)
				{
					T4 val6 = (T4)((nint)val5 >= 0);
					if (val6 == null)
					{
						break;
					}
					T4 val7 = (T4)((string)val2).Equals("ID");
					if (val7 != null)
					{
						value = value + "fb.com/" + Pages[((List<DataGridViewRow>)val3)[(int)val5].Index].id + Environment.NewLine;
					}
					else
					{
						T4 val8 = (T4)((string)val2).Equals("ID|Tên Page");
						if (val8 == null)
						{
							T4 val9 = (T4)((string)val2).Equals("ID Pro5");
							if (val9 != null)
							{
								value = value + "fb.com/" + Pages[((List<DataGridViewRow>)val3)[(int)val5].Index].additional_profile_id + Environment.NewLine;
							}
						}
						else
						{
							value = string.Concat((string[])(object)new T1[6]
							{
								(T1)value,
								(T1)"fb.com/",
								(T1)Pages[((List<DataGridViewRow>)val3)[(int)val5].Index].id,
								(T1)"|",
								(T1)Pages[((List<DataGridViewRow>)val3)[(int)val5].Index].name,
								(T1)Environment.NewLine
							});
						}
					}
					val5 = (T5)(val5 - 1);
				}
			}
			T3 val10 = (T3)new Thread((ParameterizedThreadStart)delegate
			{
				Clipboard.Clear();
				Clipboard.SetText(value);
			});
			((Thread)val10).SetApartmentState(ApartmentState.STA);
			((Thread)val10).Start();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void openGroupEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0089: Expected I4, but got O
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00be: Expected O, but got I4
		T0 val = (T0)gvGroup.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				T3 script = (T3)("window.open('https://www.facebook.com/" + Groups[((List<DataGridViewRow>)val)[(int)val3].Index].id + "');");
				chrome.executeScript<T3, T7, T2, T1, T4>(script);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void openPageEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0089: Expected I4, but got O
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00be: Expected O, but got I4
		T0 val = (T0)gvPage.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				T3 script = (T3)("window.open('https://www.facebook.com/" + Pages[((List<DataGridViewRow>)val)[(int)val3].Index].id + "');");
				chrome.executeScript<T3, T7, T2, T1, T4>(script);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void groupUpdateEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0096: Expected I4, but got O
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvGroup.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				((List<string>)val).Add(Groups[((List<DataGridViewRow>)val2)[(int)val4].Index].id);
				val4 = (T3)(val4 - 1);
			}
		}
		frmGroupSpam frmGroupSpam2 = new frmGroupSpam((List<string>)val, this);
		frmGroupSpam2.TopLevel = false;
		base.Controls.Add(frmGroupSpam2);
		frmGroupSpam2.Show();
		frmGroupSpam2.Text = Text;
		frmGroupSpam2.BringToFront();
	}

	private void pageUpdateEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0096: Expected I4, but got O
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvPage.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				((List<string>)val).Add(Pages[((List<DataGridViewRow>)val2)[(int)val4].Index].id);
				val4 = (T3)(val4 - 1);
			}
		}
		frmPageManager frmPageManager2 = new frmPageManager((List<string>)val, this);
		frmPageManager2.TopLevel = false;
		base.Controls.Add(frmPageManager2);
		frmPageManager2.Show();
		frmPageManager2.Text = Text;
		frmPageManager2.BringToFront();
	}

	private void button9_Click<T0, T1>(T0 sender, T1 e)
	{
		searchPage<string, List<DataGridViewRow>, List<int>, List<facebook_pagesData>.Enumerator, int, bool, char, DataGridViewRow>();
	}

	private unsafe void searchPage<T0, T1, T2, T3, T4, T5, T6, T7>()
	{
		//IL_0073: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00b1: Expected I4, but got O
		//IL_00d4: Expected I4, but got O
		//IL_00e8: Expected I4, but got O
		//IL_010b: Expected I4, but got O
		//IL_011f: Expected I4, but got O
		//IL_013f: Expected I4, but got O
		//IL_0153: Expected I4, but got O
		//IL_0173: Expected I4, but got O
		//IL_0187: Expected I4, but got O
		//IL_01aa: Expected I4, but got O
		//IL_01be: Expected I4, but got O
		//IL_01d4: Expected O, but got I4
		//IL_01e5: Expected I4, but got O
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0202: Expected O, but got I4
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_026f: Expected O, but got I4
		//IL_027e: Expected I4, but got O
		//IL_0285: Expected O, but got I4
		//IL_029b: Expected I4, but got O
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_02b8: Expected O, but got I4
		//IL_0340: Expected O, but got I4
		//IL_034e: Expected O, but got I4
		//IL_0364: Expected I4, but got O
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_0388: Expected O, but got I4
		gvPage.ClearSelection();
		T3 enumerator = (T3)Pages.GetEnumerator();
		try
		{
			while (((List<facebook_pagesData>.Enumerator*)(&enumerator))->MoveNext())
			{
				facebook_pagesData current = ((List<facebook_pagesData>.Enumerator*)(&enumerator))->Current;
				current.select_row = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<facebook_pagesData>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val = (T0)txtSearchPage.Text.ToLower().Trim();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T6[1] { (T6)124 });
		T0[] array2 = array;
		T4 val2 = (T4)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T0 value = (T0)((string)val3).Trim();
			T4 val4 = (T4)0;
			while (true)
			{
				T5 val5 = (T5)((nint)val4 < Pages.Count);
				if (val5 == null)
				{
					break;
				}
				T5 val6 = (T5)((Pages[(int)val4].id != null && Pages[(int)val4].id.ToLower().Contains((string)value)) || (Pages[(int)val4].additional_profile_id != null && Pages[(int)val4].additional_profile_id.ToLower().Contains((string)value)) || (Pages[(int)val4].name != null && Pages[(int)val4].name.ToLower().Contains((string)value)) || (Pages[(int)val4].category != null && Pages[(int)val4].category.ToLower().Contains((string)value)) || (Pages[(int)val4].message != null && Pages[(int)val4].message.ToLower().Contains((string)value)) || (Pages[(int)val4].name != null && Pages[(int)val4].name.ToLower().Contains((string)value)));
				if (val6 != null)
				{
					Pages[(int)val4].select_row = true;
				}
				val4 = (T4)(val4 + 1);
			}
			val2 = (T4)(val2 + 1);
		}
		gvPage.DataSource = null;
		Pages = Pages.OrderByDescending((Func<facebook_pagesData, T5>)(object)(Func<facebook_pagesData, bool>)((facebook_pagesData a) => (T5)a.select_row)).ToList();
		gvPage.DataSource = Pages;
		T4 val7 = (T4)0;
		while (true)
		{
			T5 val8 = (T5)((nint)val7 < Pages.Count);
			if (val8 == null)
			{
				break;
			}
			T5 val9 = (T5)Pages[(int)val7].select_row;
			if (val9 != null)
			{
				gvPage.Rows[(int)val7].Selected = true;
			}
			val7 = (T4)(val7 + 1);
		}
		listPageClick.Clear();
		T1 val10 = (T1)gvPage.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T5)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T2));
		T5 val11 = (T5)(((List<DataGridViewRow>)val10).Count > 0);
		if (val11 == null)
		{
			return;
		}
		T4 val12 = (T4)(((List<DataGridViewRow>)val10).Count - 1);
		while (true)
		{
			T5 val13 = (T5)((nint)val12 >= 0);
			if (val13 != null)
			{
				listPageClick.Add(Pages[((List<DataGridViewRow>)val10)[(int)val12].Index].id);
				val12 = (T4)(val12 - 1);
				continue;
			}
			break;
		}
	}

	private void txtSearchPage_KeyDown<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 sender, T2 e)
	{
		//IL_000b: Expected O, but got I4
		T0 val = (T0)(((KeyEventArgs)e).KeyCode == Keys.Return);
		if (val != null)
		{
			searchPage<T3, T4, T5, T6, T7, T0, T8, T9>();
		}
	}

	private void button11_Click<T0, T1>(T0 sender, T1 e)
	{
		isLoading = true;
		flag_load_data = 0;
		gvGroup.DataSource = null;
		button11.Enabled = false;
		progressBar4.Style = ProgressBarStyle.Marquee;
		new Thread(thrLoadGroup<bool, List<GroupsEntity_Data>, string, Exception, Dictionary<string, string>>).Start();
		timer_load_group.Start();
	}

	private void thrLoadGroup<T0, T1, T2, T3, T4>()
	{
		//IL_0028: Expected O, but got I4
		Groups = (List<GroupsEntity_Data>)chrome.mtLoadGroup<T1, T2, T0, T3, T4>(out strError);
		isLoading = false;
		T0 val = (T0)(Groups == null);
		if (val != null)
		{
			frmMain.errorMessage((T2)strError);
		}
	}

	private void timer_load_group_Tick<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		T0 val = (T0)(!isLoading);
		if (val != null)
		{
			timer_load_group.Stop();
			button11.Enabled = true;
			progressBar4.Style = ProgressBarStyle.Blocks;
			T0 val2 = (T0)(Groups != null);
			if (val2 != null)
			{
				loadGroup<T0, int>();
			}
		}
	}

	private void loadGroup<T0, T1>()
	{
		//IL_0026: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0042: Expected I4, but got O
		//IL_004d: Expected O, but got I4
		//IL_005c: Expected I4, but got O
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0075: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_00f5: Expected I4, but got O
		//IL_0101: Expected O, but got I4
		//IL_0117: Expected I4, but got O
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0134: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		gvGroup.DataSource = null;
		T0 val = (T0)(Groups != null && Groups.Count > 0);
		if (val != null)
		{
			T1 val2 = (T1)0;
			while (true)
			{
				T0 val3 = (T0)((nint)val2 < Groups.Count);
				if (val3 == null)
				{
					break;
				}
				T0 val4 = (T0)listGroupClick.Contains(Groups[(int)val2].id);
				if (val4 != null)
				{
					Groups[(int)val2].select_row = true;
				}
				val2 = (T1)(val2 + 1);
			}
			Groups = Groups.OrderByDescending((Func<GroupsEntity_Data, T0>)(object)(Func<GroupsEntity_Data, bool>)((GroupsEntity_Data a) => (T0)a.select_row)).ToList();
			gvGroup.DataSource = Groups;
			T0 val5 = (T0)(listGroupClick.Count > 0);
			if (val5 != null)
			{
				gvGroup.ClearSelection();
				T1 val6 = (T1)0;
				while (true)
				{
					T0 val7 = (T0)((nint)val6 < Groups.Count);
					if (val7 == null)
					{
						break;
					}
					T0 val8 = (T0)listGroupClick.Contains(Groups[(int)val6].id);
					if (val8 != null)
					{
						gvGroup.Rows[(int)val6].Selected = true;
					}
					val6 = (T1)(val6 + 1);
				}
			}
		}
		lbTotalGroups.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)Groups.Count).ToString();
	}

	private void gvGroup_Click<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0083: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c5: Expected O, but got I4
		listGroupClick.Clear();
		T0 val = (T0)gvGroup.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T1));
		T2 val2 = (T2)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T3 val3 = (T3)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T2 val4 = (T2)((nint)val3 >= 0);
			if (val4 != null)
			{
				listGroupClick.Add(Groups[((List<DataGridViewRow>)val)[(int)val3].Index].id);
				val3 = (T3)(val3 - 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvGroup_MouseClick<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Cập nhật Group", (EventHandler)groupUpdateEvent<T5, T6, T0, T7, T3, T8, T9>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 val3 = (T2)new MenuItem("Copy");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("ID", (EventHandler)copyPageEvent<T2, T10, T6, T11, T0, T7, T12, T3, T8, T9>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			item = (T2)new MenuItem("ID|Tên Page", (EventHandler)copyPageEvent<T2, T10, T6, T11, T0, T7, T12, T3, T8, T9>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			val3 = (T2)new MenuItem("Trình duyệt");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			item = (T2)new MenuItem("Mở group", (EventHandler)openGroupEvent<T6, T0, T7, T10, T3, T8, T9, T13>);
			((Menu)val3).MenuItems.Add((MenuItem)item);
			((ContextMenu)val2).Show((Control)gvGroup, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvGroup_ColumnHeaderMouseClick<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 sender, T5 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_0286: Expected O, but got I4
		//IL_02a0: Expected O, but got I4
		//IL_02ba: Expected O, but got I4
		//IL_0306: Expected O, but got I4
		//IL_0352: Expected O, but got I4
		//IL_036c: Expected O, but got I4
		//IL_03b8: Expected O, but got I4
		//IL_04ba: Expected O, but got I4
		//IL_04cf: Expected I4, but got O
		//IL_04db: Expected O, but got I4
		//IL_04f1: Expected I4, but got O
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected O, but got Unknown
		//IL_050e: Expected O, but got I4
		T0 groups = (T0)Activator.CreateInstance(typeof(T0));
		T1 val = (T1)(Groups != null);
		if (val == null)
		{
			return;
		}
		T2 val2 = (T2)gvGroup.Columns[((DataGridViewCellMouseEventArgs)e).ColumnIndex];
		isAscending = !isAscending;
		T1 val3 = (T1)isAscending;
		if (val3 != null)
		{
			T1 val4 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("id");
			if (val4 != null)
			{
				groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.id)).ToList();
			}
			else
			{
				T1 val5 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name");
				if (val5 != null)
				{
					groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.name)).ToList();
				}
				else
				{
					T1 val6 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("privacy");
					if (val6 == null)
					{
						T1 val7 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("member_count");
						if (val7 == null)
						{
							T1 val8 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("message");
							if (val8 == null)
							{
								T1 val9 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("updated_time");
								if (val9 == null)
								{
									T1 val10 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("updated_time_minute");
									if (val10 != null)
									{
										groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T8>)(object)(Func<GroupsEntity_Data, double>)((GroupsEntity_Data a) => (T8)a.updated_time_minute)).ToList();
									}
								}
								else
								{
									groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T7>)(object)(Func<GroupsEntity_Data, DateTime>)((GroupsEntity_Data a) => (T7)a.updated_time)).ToList();
								}
							}
							else
							{
								groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.message)).ToList();
							}
						}
						else
						{
							groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T3>)(object)(Func<GroupsEntity_Data, int>)((GroupsEntity_Data a) => (T3)a.member_count)).ToList();
						}
					}
					else
					{
						groups = (T0)Groups.OrderByDescending((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.privacy)).ToList();
					}
				}
			}
		}
		else
		{
			T1 val11 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("id");
			if (val11 == null)
			{
				T1 val12 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("name");
				if (val12 == null)
				{
					T1 val13 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("privacy");
					if (val13 != null)
					{
						groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.privacy)).ToList();
					}
					else
					{
						T1 val14 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("updated_time");
						if (val14 != null)
						{
							groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T7>)(object)(Func<GroupsEntity_Data, DateTime>)((GroupsEntity_Data a) => (T7)a.updated_time)).ToList();
						}
						else
						{
							T1 val15 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("message");
							if (val15 == null)
							{
								T1 val16 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("member_count");
								if (val16 != null)
								{
									groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T3>)(object)(Func<GroupsEntity_Data, int>)((GroupsEntity_Data a) => (T3)a.member_count)).ToList();
								}
								else
								{
									T1 val17 = (T1)((DataGridViewColumn)val2).DataPropertyName.Equals("updated_time_minute");
									if (val17 != null)
									{
										groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T8>)(object)(Func<GroupsEntity_Data, double>)((GroupsEntity_Data a) => (T8)a.updated_time_minute)).ToList();
									}
								}
							}
							else
							{
								groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.message)).ToList();
							}
						}
					}
				}
				else
				{
					groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.name)).ToList();
				}
			}
			else
			{
				groups = (T0)Groups.OrderBy((Func<GroupsEntity_Data, T6>)(object)(Func<GroupsEntity_Data, string>)((GroupsEntity_Data a) => (T6)a.id)).ToList();
			}
		}
		Groups = (List<GroupsEntity_Data>)groups;
		gvGroup.DataSource = null;
		gvGroup.DataSource = Groups;
		gvGroup.ClearSelection();
		T3 val18 = (T3)0;
		while (true)
		{
			T1 val19 = (T1)((nint)val18 < Groups.Count);
			if (val19 != null)
			{
				T1 val20 = (T1)listGroupClick.Contains(Groups[(int)val18].id);
				if (val20 != null)
				{
					gvGroup.Rows[(int)val18].Selected = true;
				}
				val18 = (T3)(val18 + 1);
				continue;
			}
			break;
		}
	}

	private void button10_Click<T0, T1>(T0 sender, T1 e)
	{
		searchGroup<string, List<DataGridViewRow>, List<int>, List<GroupsEntity_Data>.Enumerator, int, bool, char, DataGridViewRow>();
	}

	private unsafe void searchGroup<T0, T1, T2, T3, T4, T5, T6, T7>()
	{
		//IL_0073: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00b1: Expected I4, but got O
		//IL_00d1: Expected I4, but got O
		//IL_00e5: Expected I4, but got O
		//IL_0105: Expected I4, but got O
		//IL_0119: Expected I4, but got O
		//IL_013c: Expected I4, but got O
		//IL_0150: Expected I4, but got O
		//IL_0166: Expected O, but got I4
		//IL_0177: Expected I4, but got O
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0194: Expected O, but got I4
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_0201: Expected O, but got I4
		//IL_0210: Expected I4, but got O
		//IL_0217: Expected O, but got I4
		//IL_022d: Expected I4, but got O
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_024a: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_02e0: Expected O, but got I4
		//IL_02f6: Expected I4, but got O
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_031a: Expected O, but got I4
		gvGroup.ClearSelection();
		T3 enumerator = (T3)Groups.GetEnumerator();
		try
		{
			while (((List<GroupsEntity_Data>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupsEntity_Data current = ((List<GroupsEntity_Data>.Enumerator*)(&enumerator))->Current;
				current.select_row = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupsEntity_Data>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val = (T0)txtSearchGroup.Text.ToLower().Trim();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T6[1] { (T6)124 });
		T0[] array2 = array;
		T4 val2 = (T4)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T0 value = (T0)((string)val3).Trim();
			T4 val4 = (T4)0;
			while (true)
			{
				T5 val5 = (T5)((nint)val4 < Groups.Count);
				if (val5 == null)
				{
					break;
				}
				T5 val6 = (T5)((Groups[(int)val4].id != null && Groups[(int)val4].id.ToLower().Contains((string)value)) || (Groups[(int)val4].name != null && Groups[(int)val4].name.ToLower().Contains((string)value)) || (Groups[(int)val4].message != null && Groups[(int)val4].message.ToLower().Contains((string)value)) || (Groups[(int)val4].privacy != null && Groups[(int)val4].privacy.ToLower().Contains((string)value)));
				if (val6 != null)
				{
					Groups[(int)val4].select_row = true;
				}
				val4 = (T4)(val4 + 1);
			}
			val2 = (T4)(val2 + 1);
		}
		gvGroup.DataSource = null;
		Groups = Groups.OrderByDescending((Func<GroupsEntity_Data, T5>)(object)(Func<GroupsEntity_Data, bool>)((GroupsEntity_Data a) => (T5)a.select_row)).ToList();
		gvGroup.DataSource = Groups;
		T4 val7 = (T4)0;
		while (true)
		{
			T5 val8 = (T5)((nint)val7 < Groups.Count);
			if (val8 == null)
			{
				break;
			}
			T5 val9 = (T5)Groups[(int)val7].select_row;
			if (val9 != null)
			{
				gvGroup.Rows[(int)val7].Selected = true;
			}
			val7 = (T4)(val7 + 1);
		}
		listGroupClick.Clear();
		T1 val10 = (T1)gvGroup.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T5)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T4>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		Activator.CreateInstance(typeof(T2));
		T5 val11 = (T5)(((List<DataGridViewRow>)val10).Count > 0);
		if (val11 == null)
		{
			return;
		}
		T4 val12 = (T4)(((List<DataGridViewRow>)val10).Count - 1);
		while (true)
		{
			T5 val13 = (T5)((nint)val12 >= 0);
			if (val13 != null)
			{
				listGroupClick.Add(Groups[((List<DataGridViewRow>)val10)[(int)val12].Index].id);
				val12 = (T4)(val12 - 1);
				continue;
			}
			break;
		}
	}

	private void gvData_CellMouseMove<T0, T1>(T0 sender, T1 e)
	{
	}

	private void gvData_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbRowSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvData.SelectedRows.Count).ToString();
	}

	private void gvPage_CellMouseMove<T0, T1>(T0 sender, T1 e)
	{
	}

	private void button14_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		_ = ccbPageLocations.Text;
	}

	private void button15_Click<T0, T1>(T0 sender, T1 e)
	{
		frmCreatePageLocation frmCreatePageLocation2 = new frmCreatePageLocation(this);
		frmCreatePageLocation2.ShowDialog();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void btnCreateBM_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T4 sender, T5 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		T0 val = (T0)(frmMain.questioniMessage<DialogResult, T6>((T6)"Bạn muốn tạo BM?") == DialogResult.Yes);
		if (val != null)
		{
			btnCreateBM.Enabled = false;
			try
			{
				T1 số_BM_cần_tạo = (T1)int.Parse(((decimal)(T2)numBMAmount.Value).ToString());
				T1 Done;
				chrome.Tao_BM<T0, T6, T1, T7, T3>(số_BM_cần_tạo, out *(int*)(&Done));
				frmMain.infoMessage((T6)("Done :" + *(int*)(&Done)));
			}
			catch (Exception ex)
			{
				frmMain.errorMessage((T6)ex.Message);
			}
			btnCreateBM.Enabled = true;
		}
	}

	private void button16_Click<T0, T1>(T0 sender, T1 e)
	{
		searchBM<string, int, bool, char>();
	}

	private void searchBM<T0, T1, T2, T3>()
	{
		//IL_0042: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_006a: Expected I4, but got O
		//IL_007e: Expected I4, but got O
		//IL_00a1: Expected I4, but got O
		//IL_00b5: Expected I4, but got O
		//IL_00d8: Expected I4, but got O
		//IL_00ec: Expected I4, but got O
		//IL_010f: Expected I4, but got O
		//IL_0123: Expected I4, but got O
		//IL_0143: Expected I4, but got O
		//IL_0157: Expected I4, but got O
		//IL_0177: Expected I4, but got O
		//IL_018b: Expected I4, but got O
		//IL_01ae: Expected I4, but got O
		//IL_01c2: Expected I4, but got O
		//IL_01d8: Expected O, but got I4
		//IL_01ef: Expected I4, but got O
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0210: Expected O, but got I4
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_023f: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_025b: Expected I4, but got O
		//IL_0267: Expected O, but got I4
		//IL_027d: Expected I4, but got O
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_029a: Expected O, but got I4
		gvBM.ClearSelection();
		listBMClick.Clear();
		T0 val = (T0)txtSearchBM.Text.ToLower().Trim();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T3[1] { (T3)124 });
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T0 value = (T0)((string)val3).Trim();
			T1 val4 = (T1)0;
			while (true)
			{
				T2 val5 = (T2)((nint)val4 < BusinessManager.Count);
				if (val5 == null)
				{
					break;
				}
				T2 val6 = (T2)((BusinessManager[(int)val4].name != null && BusinessManager[(int)val4].name.ToLower().Contains((string)value)) || (BusinessManager[(int)val4].id != null && BusinessManager[(int)val4].id.ToLower().Contains((string)value)) || (BusinessManager[(int)val4].message != null && BusinessManager[(int)val4].message.ToLower().Contains((string)value)) || (BusinessManager[(int)val4].Payment != null && BusinessManager[(int)val4].Payment.ToLower().Contains((string)value)) || (BusinessManager[(int)val4].payment_account_id != null && BusinessManager[(int)val4].payment_account_id.ToLower().Contains((string)value)) || (BusinessManager[(int)val4].status != null && BusinessManager[(int)val4].status.ToLower().Contains((string)value)) || (BusinessManager[(int)val4].TKQC != null && BusinessManager[(int)val4].TKQC.ToLower().Contains((string)value)));
				if (val6 != null)
				{
					listBMClick.Add(BusinessManager[(int)val4].id);
				}
				val4 = (T1)(val4 + 1);
			}
			val2 = (T1)(val2 + 1);
		}
		T2 val7 = (T2)(listBMClick != null && listBMClick.Count > 0);
		if (val7 == null)
		{
			return;
		}
		T1 val8 = (T1)0;
		while (true)
		{
			T2 val9 = (T2)((nint)val8 < BusinessManager.Count);
			if (val9 != null)
			{
				T2 val10 = (T2)listBMClick.Contains(BusinessManager[(int)val8].id);
				if (val10 != null)
				{
					gvBM.Rows[(int)val8].Selected = true;
				}
				val8 = (T1)(val8 + 1);
				continue;
			}
			break;
		}
	}

	private void txtSearchBM_KeyDown<T0, T1, T2, T3, T4, T5>(T1 sender, T2 e)
	{
		//IL_000b: Expected O, but got I4
		T0 val = (T0)(((KeyEventArgs)e).KeyCode == Keys.Return);
		if (val != null)
		{
			searchBM<T3, T4, T0, T5>();
		}
	}

	private void txtSearchPage_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void ccbActFillter_SelectedIndexChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			chrome.frmMain.listFBEntity[chrome.indexEntity].ccbActFillter = ccbActFillter.SelectedIndex;
		}
	}

	private void ccbActSort_SelectedIndexChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			chrome.frmMain.listFBEntity[chrome.indexEntity].ccbActSort = ccbActSort.SelectedIndex;
		}
	}

	private void txtSearchByKeyword_TextChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			chrome.frmMain.listFBEntity[chrome.indexEntity].txtSearchByKeyword = txtSearchByKeyword.Text;
		}
	}

	private void numMaxAct_ValueChanged<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(chrome != null);
		if (val != null)
		{
			chrome.frmMain.listFBEntity[chrome.indexEntity].numMaxAct = int.Parse(((decimal)(T1)numMaxAct.Value).ToString());
		}
	}

	private void uIDToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)delegate
			{
				Clipboard.Clear();
				Clipboard.SetText(chrome.frmMain.listFBEntity[chrome.indexEntity].UID);
			});
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void thôngTinTàiKhoảnToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)delegate
			{
				Clipboard.Clear();
				Clipboard.SetText(chrome.frmMain.listFBEntity[chrome.indexEntity].FullInfo);
			});
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void tokenEEAGToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)([MethodImpl(MethodImplOptions.NoInlining)] (T1 param) =>
			{
				Clipboard.Clear();
				Clipboard.SetText($"{chrome.frmMain.listFBEntity[chrome.indexEntity].Cookie}|{chrome.frmMain.listFBEntity[chrome.indexEntity].TokenEAAG}");
			}));
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void tokenEEABToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)([MethodImpl(MethodImplOptions.NoInlining)] (T1 param) =>
			{
				Clipboard.Clear();
				Clipboard.SetText($"{chrome.frmMain.listFBEntity[chrome.indexEntity].Cookie}|{chrome.frmMain.listFBEntity[chrome.indexEntity].TokenEAAB}");
			}));
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void cookieToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)delegate
			{
				Clipboard.Clear();
				Clipboard.SetText(chrome.frmMain.listFBEntity[chrome.indexEntity].Cookie);
			});
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void fACodeToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)_003CfACodeToolStripMenuItem_Click_003Eb__131_0<string, T1, int, bool, Exception, byte, char>);
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void lbRowSelected_Click<T0, T1>(T0 sender, T1 e)
	{
		gvData.SelectAll();
	}

	private void gvData_CellFormatting<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button17_Click<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0026: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		T0 val = (T0)(string.IsNullOrWhiteSpace(txtCreateNamePage.Text) || string.IsNullOrWhiteSpace(txtCategoryCreatePage.Text));
		if (val != null)
		{
			frmMain.errorMessage((T1)"Thiếu thông tin tạo page!");
			return;
		}
		T1 value = (T1)"";
		T2 val2 = (T2)ccbTypeCreatePage.SelectedIndex;
		T2 val3 = val2;
		if (val3 != null)
		{
			if ((nint)val3 == 1)
			{
				value = chrome.fetch_tao_classic_page<T5, T1, T0>((T1)txtCreateNamePage.Text, (T1)txtCategoryCreatePage.Text);
			}
		}
		else
		{
			value = chrome.fetch_tao_classic_page<T5, T1, T0>((T1)txtCreateNamePage.Text, (T1)txtCategoryCreatePage.Text);
		}
		T0 val4 = (T0)string.IsNullOrWhiteSpace((string)value);
		if (val4 == null)
		{
			frmMain.infoMessage((T1)"Tạo page thành công!");
		}
		else
		{
			frmMain.errorMessage((T1)"Tạo page lỗi!");
		}
	}

	private void gvBM_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbBMSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvBM.SelectedRows.Count).ToString();
	}

	private void gvPage_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbPageSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvPage.SelectedRows.Count).ToString();
	}

	private void txtSearchBM_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtCreateNamePage_TextChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void mậtKhẩuToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)delegate
			{
				Clipboard.Clear();
				Clipboard.SetText(chrome.frmMain.listFBEntity[chrome.indexEntity].Password);
			});
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
		}
	}

	private void emailPasswordToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			T0 val = (T0)new Thread((ParameterizedThreadStart)([MethodImpl(MethodImplOptions.NoInlining)] (T1 param) =>
			{
				Clipboard.Clear();
				Clipboard.SetText(chrome.frmMain.listFBEntity[chrome.indexEntity].Email + "|" + chrome.frmMain.listFBEntity[chrome.indexEntity].EmailPassword);
			}));
			((Thread)val).SetApartmentState(ApartmentState.STA);
			((Thread)val).Start();
		}
		catch
		{
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val2 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val3 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T1 val4 = (T1)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmAdsManager));
		T0 val5 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val6 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val7 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val8 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val9 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val10 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.Column1 = (System.Windows.Forms.DataGridViewTextBoxColumn)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewTextBoxColumn));
		this.ccbBM = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.txtSearch = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.tabControl = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabCookie = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.tabToken = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.button4 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numLimit = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBMID = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtToken = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.tabTKQCBM = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.txtBMIDTQCKInBM = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button5 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.ccbActSort = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.ccbActFillter = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotal = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
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
		this.timer_load_data_cookie = new System.Windows.Forms.Timer(this.components);
		this.timer_load_data_token = new System.Windows.Forms.Timer(this.components);
		this.progressBar1 = (System.Windows.Forms.ProgressBar)System.Activator.CreateInstance(typeof(System.Windows.Forms.ProgressBar));
		this.tabGroup = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabAds = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbCountLoadAct = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbRowSelected = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numMaxAct = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label7 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSearchByKeyword = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label6 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.tabBM = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.lbBMSelected = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSearchBM = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button16 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numBMAmount = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.btnCreateBM = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button6 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button7 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.statusStrip2 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel3 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel5 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.gvBM = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.progressBar2 = (System.Windows.Forms.ProgressBar)System.Activator.CreateInstance(typeof(System.Windows.Forms.ProgressBar));
		this.tabPage = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.label9 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbPageSelected = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label8 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCategoryCreatePage = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtCreateNamePage = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.ccbTypeCreatePage = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.button17 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.txtSearchPage = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button9 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.statusStrip3 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel7 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel9 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel13 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbPageLive = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel11 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbPageNormal = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel15 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbPagePro5 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.button8 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvPage = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.progressBar3 = (System.Windows.Forms.ProgressBar)System.Activator.CreateInstance(typeof(System.Windows.Forms.ProgressBar));
		this.tabPageLocations = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.button15 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button14 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.ccbPageLocations = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.textBox1 = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button12 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button13 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.tabGroups = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.txtSearchGroup = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button10 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.statusStrip4 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel16 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotalGroups = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.button11 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvGroup = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.progressBar4 = (System.Windows.Forms.ProgressBar)System.Activator.CreateInstance(typeof(System.Windows.Forms.ProgressBar));
		this.tabPage3 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.plBrowser = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.timer_load_bm = new System.Windows.Forms.Timer(this.components);
		this.timer_load_page = new System.Windows.Forms.Timer(this.components);
		this.timer_load_group = new System.Windows.Forms.Timer(this.components);
		this.menuStrip1 = (System.Windows.Forms.MenuStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.MenuStrip));
		this.copyToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.uIDToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.mậtKhẩuToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.fACodeToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.cookieToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.emailPasswordToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.thôngTinTàiKhoảnToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.tokenEEABToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.tokenEEAGToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		this.tabControl.SuspendLayout();
		this.tabCookie.SuspendLayout();
		this.tabToken.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numLimit).BeginInit();
		this.tabTKQCBM.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.tabGroup.SuspendLayout();
		this.tabAds.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numMaxAct).BeginInit();
		this.tabBM.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numBMAmount).BeginInit();
		this.statusStrip2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvBM).BeginInit();
		this.tabPage.SuspendLayout();
		this.statusStrip3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvPage).BeginInit();
		this.tabPageLocations.SuspendLayout();
		this.tabGroups.SuspendLayout();
		this.statusStrip4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvGroup).BeginInit();
		this.tabPage3.SuspendLayout();
		this.menuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.button1.Location = new System.Drawing.Point(16, 9);
		this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(101, 34);
		this.button1.TabIndex = 2;
		this.button1.Text = "Reload";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AllowUserToOrderColumns = true;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		((System.Windows.Forms.DataGridViewCellStyle)val).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val).BackColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.DataGridViewCellStyle)val).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val).ForeColor = System.Drawing.SystemColors.WindowText;
		((System.Windows.Forms.DataGridViewCellStyle)val).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val).WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.gvData.ColumnHeadersDefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Columns.AddRange((System.Windows.Forms.DataGridViewColumn[])(object)new T20[1] { (T20)this.Column1 });
		((System.Windows.Forms.DataGridViewCellStyle)val2).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val2).BackColor = System.Drawing.SystemColors.Window;
		((System.Windows.Forms.DataGridViewCellStyle)val2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val2).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.DataGridViewCellStyle)val2).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val2).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val2).WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.gvData.DefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val2;
		this.gvData.Location = new System.Drawing.Point(15, 165);
		this.gvData.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
		this.gvData.Name = "gvData";
		((System.Windows.Forms.DataGridViewCellStyle)val3).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val3).BackColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.DataGridViewCellStyle)val3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val3).ForeColor = System.Drawing.SystemColors.WindowText;
		((System.Windows.Forms.DataGridViewCellStyle)val3).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val3).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val3).WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.gvData.RowHeadersDefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val3;
		this.gvData.RowHeadersWidth = 51;
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(2001, 624);
		this.gvData.TabIndex = 3;
		this.gvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(gvData_CellFormatting);
		this.gvData.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvData_CellMouseMove);
		this.gvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvData_ColumnHeaderMouseClick<T23, T24, T20, T25, T18, T22, T26, T27, T28>);
		this.gvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvData_RowStateChanged<T25, T18, T29>);
		this.gvData.Click += new System.EventHandler(gvData_Click<T30, T31, T24, T25, T18, T19, T32>);
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T24, T33, T34, T18, T35>);
		this.Column1.HeaderText = "Column1";
		this.Column1.MinimumWidth = 6;
		this.Column1.Name = "Column1";
		this.ccbBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ccbBM.FormattingEnabled = true;
		this.ccbBM.Location = new System.Drawing.Point(128, 15);
		this.ccbBM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.ccbBM.Name = "ccbBM";
		this.ccbBM.Size = new System.Drawing.Size(635, 24);
		this.ccbBM.TabIndex = 5;
		this.ccbBM.SelectedIndexChanged += new System.EventHandler(ccbBM_SelectedIndexChanged);
		this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtSearch.Location = new System.Drawing.Point(949, 44);
		this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(842, 28);
		this.txtSearch.TabIndex = 6;
		this.txtSearch.TextChanged += new System.EventHandler(txtSearch_TextChanged<T24, T18, T19>);
		this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(txtSearch_KeyDown<T24, T18, T36, T26, T30, T31, T28, T25, T27, T37, T32>);
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(1804, 43);
		this.button2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(213, 34);
		this.button2.TabIndex = 7;
		this.button2.Text = "Tìm kiếm | Search";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button3.Location = new System.Drawing.Point(807, 43);
		this.button3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(133, 34);
		this.button3.TabIndex = 8;
		this.button3.Text = "Xuất file";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T26, T28, T25, T38, T18, T19, T27>);
		this.tabControl.Controls.Add(this.tabCookie);
		this.tabControl.Controls.Add(this.tabToken);
		this.tabControl.Controls.Add(this.tabTKQCBM);
		this.tabControl.ImageList = this.imageList1;
		this.tabControl.Location = new System.Drawing.Point(11, 9);
		this.tabControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabControl.Name = "tabControl";
		this.tabControl.SelectedIndex = 0;
		this.tabControl.Size = new System.Drawing.Size(785, 94);
		this.tabControl.TabIndex = 9;
		this.tabCookie.BackColor = System.Drawing.SystemColors.Control;
		this.tabCookie.Controls.Add(this.ccbBM);
		this.tabCookie.Controls.Add(this.button1);
		this.tabCookie.ImageIndex = 5;
		this.tabCookie.Location = new System.Drawing.Point(4, 25);
		this.tabCookie.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabCookie.Name = "tabCookie";
		this.tabCookie.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabCookie.Size = new System.Drawing.Size(777, 65);
		this.tabCookie.TabIndex = 0;
		this.tabCookie.Text = "_____Cookie_____";
		this.tabToken.BackColor = System.Drawing.SystemColors.Control;
		this.tabToken.Controls.Add(this.button4);
		this.tabToken.Controls.Add(this.numLimit);
		this.tabToken.Controls.Add(this.label2);
		this.tabToken.Controls.Add(this.txtBMID);
		this.tabToken.Controls.Add(this.label3);
		this.tabToken.Controls.Add(this.label1);
		this.tabToken.Controls.Add(this.txtToken);
		this.tabToken.ImageIndex = 6;
		this.tabToken.Location = new System.Drawing.Point(4, 25);
		this.tabToken.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabToken.Name = "tabToken";
		this.tabToken.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabToken.Size = new System.Drawing.Size(777, 65);
		this.tabToken.TabIndex = 1;
		this.tabToken.Text = "_____Token_____";
		this.button4.Location = new System.Drawing.Point(11, 6);
		this.button4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(101, 34);
		this.button4.TabIndex = 17;
		this.button4.Text = "Reload";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.numLimit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.numLimit.Location = new System.Drawing.Point(1533, 11);
		this.numLimit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.numLimit.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)1410065407,
			(T25)2,
			default(T25),
			default(T25)
		});
		this.numLimit.Name = "numLimit";
		this.numLimit.Size = new System.Drawing.Size(181, 22);
		this.numLimit.TabIndex = 16;
		this.numLimit.Value = new decimal((int[])(object)new T25[4]
		{
			(T25)2500,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numLimit.ValueChanged += new System.EventHandler(numLimit_ValueChanged<T39, T18, T19>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(1465, 14);
		this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(37, 16);
		this.label2.TabIndex = 15;
		this.label2.Text = "Limit:";
		this.txtBMID.Location = new System.Drawing.Point(495, 12);
		this.txtBMID.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtBMID.Name = "txtBMID";
		this.txtBMID.Size = new System.Drawing.Size(268, 22);
		this.txtBMID.TabIndex = 15;
		this.txtBMID.TextChanged += new System.EventHandler(txtBMID_TextChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(433, 16);
		this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(44, 16);
		this.label3.TabIndex = 14;
		this.label3.Text = "BM Id:";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(123, 16);
		this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(89, 16);
		this.label1.TabIndex = 12;
		this.label1.Text = "Token EAAG:";
		this.txtToken.Location = new System.Drawing.Point(225, 12);
		this.txtToken.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtToken.Name = "txtToken";
		this.txtToken.Size = new System.Drawing.Size(196, 22);
		this.txtToken.TabIndex = 13;
		this.txtToken.TextChanged += new System.EventHandler(txtToken_TextChanged);
		this.tabTKQCBM.BackColor = System.Drawing.SystemColors.Control;
		this.tabTKQCBM.Controls.Add(this.txtBMIDTQCKInBM);
		this.tabTKQCBM.Controls.Add(this.label4);
		this.tabTKQCBM.Controls.Add(this.button5);
		this.tabTKQCBM.Location = new System.Drawing.Point(4, 25);
		this.tabTKQCBM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabTKQCBM.Name = "tabTKQCBM";
		this.tabTKQCBM.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabTKQCBM.Size = new System.Drawing.Size(777, 65);
		this.tabTKQCBM.TabIndex = 2;
		this.tabTKQCBM.Text = "_____TKQC trong BM_____";
		this.txtBMIDTQCKInBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtBMIDTQCKInBM.Location = new System.Drawing.Point(184, 15);
		this.txtBMIDTQCKInBM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtBMIDTQCKInBM.Name = "txtBMIDTQCKInBM";
		this.txtBMIDTQCKInBM.Size = new System.Drawing.Size(579, 22);
		this.txtBMIDTQCKInBM.TabIndex = 17;
		this.txtBMIDTQCKInBM.TextChanged += new System.EventHandler(txtBMIDTQCKInBM_TextChanged<T24, T18, T19>);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(123, 18);
		this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(44, 16);
		this.label4.TabIndex = 16;
		this.label4.Text = "BM Id:";
		this.button5.Location = new System.Drawing.Point(11, 9);
		this.button5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(101, 34);
		this.button5.TabIndex = 3;
		this.button5.Text = "Reload";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click<T24, T18, T19, T23>);
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)(T40)((System.Resources.ResourceManager)val4).GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "5b3cdfb9d9ef511fcdf9b5977068c6aa.ico");
		this.imageList1.Images.SetKeyName(1, "41-419791_fb-page-icon-png-facebook-page-logo-png.ico");
		this.imageList1.Images.SetKeyName(2, "60daf1e3a17d2.ico");
		this.imageList1.Images.SetKeyName(3, "chrome.ico");
		this.imageList1.Images.SetKeyName(4, "png-transparent-computer-icons-facebook-private.ico");
		this.imageList1.Images.SetKeyName(5, "1035040.ico");
		this.imageList1.Images.SetKeyName(6, "images (1).ico");
		this.ccbActSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbActSort.FormattingEnabled = true;
		this.ccbActSort.Items.AddRange((object[])(object)new T18[5]
		{
			(T18)"Sắp xếp",
			(T18)"Thứ tự tên tăng dần",
			(T18)"Thứ tự tên giảm dần",
			(T18)"Tạo gần đây nhất",
			(T18)"Tạo cũ nhất"
		});
		this.ccbActSort.Location = new System.Drawing.Point(241, 106);
		this.ccbActSort.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.ccbActSort.Name = "ccbActSort";
		this.ccbActSort.Size = new System.Drawing.Size(212, 24);
		this.ccbActSort.TabIndex = 7;
		this.ccbActSort.SelectedIndexChanged += new System.EventHandler(ccbActSort_SelectedIndexChanged<T24, T18, T19>);
		this.ccbActFillter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbActFillter.FormattingEnabled = true;
		this.ccbActFillter.Items.AddRange((object[])(object)new T18[3]
		{
			(T18)"Lọc tài khoản",
			(T18)"Đang hoạt động",
			(T18)"Đã vô hiệu hóa"
		});
		this.ccbActFillter.Location = new System.Drawing.Point(16, 107);
		this.ccbActFillter.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.ccbActFillter.Name = "ccbActFillter";
		this.ccbActFillter.Size = new System.Drawing.Size(212, 24);
		this.ccbActFillter.TabIndex = 6;
		this.ccbActFillter.SelectedIndexChanged += new System.EventHandler(ccbActFillter_SelectedIndexChanged<T24, T18, T19>);
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T41[16]
		{
			(T41)this.toolStripStatusLabel1,
			(T41)this.lbTotal,
			(T41)this.toolStripStatusLabel2,
			(T41)this.lbActive,
			(T41)this.toolStripStatusLabel4,
			(T41)this.lbDie,
			(T41)this.toolStripStatusLabel6,
			(T41)this.lbUnsettled,
			(T41)this.toolStripStatusLabel8,
			(T41)this.lbReview,
			(T41)this.toolStripStatusLabel10,
			(T41)this.lbGracePeriod,
			(T41)this.toolStripStatusLabel12,
			(T41)this.lbTemporarityUnavable,
			(T41)this.toolStripStatusLabel14,
			(T41)this.lbPendingCloure
		});
		this.statusStrip1.Location = new System.Drawing.Point(5, 795);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
		this.statusStrip1.Size = new System.Drawing.Size(2026, 26);
		this.statusStrip1.TabIndex = 11;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(18, 20);
		this.lbTotal.Text = "0";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(84, 20);
		this.toolStripStatusLabel2.Text = "Hoạt động:";
		this.lbActive.Name = "lbActive";
		this.lbActive.Size = new System.Drawing.Size(17, 20);
		this.lbActive.Text = "0";
		this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
		this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 20);
		this.toolStripStatusLabel4.Text = "Die:";
		this.lbDie.Name = "lbDie";
		this.lbDie.Size = new System.Drawing.Size(17, 20);
		this.lbDie.Text = "0";
		this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
		this.toolStripStatusLabel6.Size = new System.Drawing.Size(32, 20);
		this.toolStripStatusLabel6.Text = "Nợ:";
		this.lbUnsettled.Name = "lbUnsettled";
		this.lbUnsettled.Size = new System.Drawing.Size(17, 20);
		this.lbUnsettled.Text = "0";
		this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
		this.toolStripStatusLabel8.Size = new System.Drawing.Size(59, 20);
		this.toolStripStatusLabel8.Text = "Review:";
		this.lbReview.Name = "lbReview";
		this.lbReview.Size = new System.Drawing.Size(17, 20);
		this.lbReview.Text = "0";
		this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
		this.toolStripStatusLabel10.Size = new System.Drawing.Size(58, 20);
		this.toolStripStatusLabel10.Text = "Ân hạn:";
		this.lbGracePeriod.Name = "lbGracePeriod";
		this.lbGracePeriod.Size = new System.Drawing.Size(17, 20);
		this.lbGracePeriod.Text = "0";
		this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
		this.toolStripStatusLabel12.Size = new System.Drawing.Size(77, 20);
		this.toolStripStatusLabel12.Text = "Tạm khóa:";
		this.lbTemporarityUnavable.Name = "lbTemporarityUnavable";
		this.lbTemporarityUnavable.Size = new System.Drawing.Size(17, 20);
		this.lbTemporarityUnavable.Text = "0";
		this.toolStripStatusLabel14.Name = "toolStripStatusLabel14";
		this.toolStripStatusLabel14.Size = new System.Drawing.Size(84, 20);
		this.toolStripStatusLabel14.Text = "Đang khóa:";
		this.lbPendingCloure.Name = "lbPendingCloure";
		this.lbPendingCloure.Size = new System.Drawing.Size(17, 20);
		this.lbPendingCloure.Text = "0";
		this.timer_load_data_cookie.Interval = 1000;
		this.timer_load_data_cookie.Tick += new System.EventHandler(timer_load_data_cookie_Tick<T24, T25, T18, T19>);
		this.timer_load_data_token.Interval = 1000;
		this.timer_load_data_token.Tick += new System.EventHandler(timer_load_data_token_Tick<T24, T25, T18, T19, T28>);
		this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.progressBar1.Location = new System.Drawing.Point(11, 145);
		this.progressBar1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(2001, 15);
		this.progressBar1.TabIndex = 12;
		this.tabGroup.Controls.Add(this.tabAds);
		this.tabGroup.Controls.Add(this.tabBM);
		this.tabGroup.Controls.Add(this.tabPage);
		this.tabGroup.Controls.Add(this.tabPageLocations);
		this.tabGroup.Controls.Add(this.tabGroups);
		this.tabGroup.Controls.Add(this.tabPage3);
		this.tabGroup.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabGroup.ImageList = this.imageList1;
		this.tabGroup.Location = new System.Drawing.Point(0, 48);
		this.tabGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabGroup.Name = "tabGroup";
		this.tabGroup.SelectedIndex = 0;
		this.tabGroup.Size = new System.Drawing.Size(2044, 855);
		this.tabGroup.TabIndex = 14;
		this.tabAds.Controls.Add(this.lbCountLoadAct);
		this.tabAds.Controls.Add(this.lbRowSelected);
		this.tabAds.Controls.Add(this.numMaxAct);
		this.tabAds.Controls.Add(this.label7);
		this.tabAds.Controls.Add(this.txtSearchByKeyword);
		this.tabAds.Controls.Add(this.label6);
		this.tabAds.Controls.Add(this.ccbActSort);
		this.tabAds.Controls.Add(this.ccbActFillter);
		this.tabAds.Controls.Add(this.gvData);
		this.tabAds.Controls.Add(this.tabControl);
		this.tabAds.Controls.Add(this.statusStrip1);
		this.tabAds.Controls.Add(this.progressBar1);
		this.tabAds.Controls.Add(this.txtSearch);
		this.tabAds.Controls.Add(this.button2);
		this.tabAds.Controls.Add(this.button3);
		this.tabAds.ImageIndex = 2;
		this.tabAds.Location = new System.Drawing.Point(4, 25);
		this.tabAds.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabAds.Name = "tabAds";
		this.tabAds.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabAds.Size = new System.Drawing.Size(2036, 826);
		this.tabAds.TabIndex = 0;
		this.tabAds.Text = "_____TKQC_____";
		this.tabAds.UseVisualStyleBackColor = true;
		this.lbCountLoadAct.AutoSize = true;
		this.lbCountLoadAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbCountLoadAct.ForeColor = System.Drawing.Color.Blue;
		this.lbCountLoadAct.Location = new System.Drawing.Point(1232, 113);
		this.lbCountLoadAct.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lbCountLoadAct.Name = "lbCountLoadAct";
		this.lbCountLoadAct.Size = new System.Drawing.Size(18, 20);
		this.lbCountLoadAct.TabIndex = 55;
		this.lbCountLoadAct.Text = "0";
		this.lbRowSelected.AutoSize = true;
		this.lbRowSelected.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbRowSelected.Location = new System.Drawing.Point(23, 172);
		this.lbRowSelected.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lbRowSelected.Name = "lbRowSelected";
		this.lbRowSelected.Size = new System.Drawing.Size(18, 17);
		this.lbRowSelected.TabIndex = 54;
		this.lbRowSelected.Text = "0";
		this.lbRowSelected.Click += new System.EventHandler(lbRowSelected_Click);
		this.numMaxAct.Location = new System.Drawing.Point(1023, 110);
		this.numMaxAct.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.numMaxAct.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)10000,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numMaxAct.Name = "numMaxAct";
		this.numMaxAct.Size = new System.Drawing.Size(181, 22);
		this.numMaxAct.TabIndex = 16;
		this.numMaxAct.ValueChanged += new System.EventHandler(numMaxAct_ValueChanged<T24, T39, T18, T19>);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(940, 112);
		this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(47, 16);
		this.label7.TabIndex = 15;
		this.label7.Text = "Số TK:";
		this.txtSearchByKeyword.Location = new System.Drawing.Point(559, 106);
		this.txtSearchByKeyword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtSearchByKeyword.Name = "txtSearchByKeyword";
		this.txtSearchByKeyword.Size = new System.Drawing.Size(368, 22);
		this.txtSearchByKeyword.TabIndex = 14;
		this.txtSearchByKeyword.TextChanged += new System.EventHandler(txtSearchByKeyword_TextChanged<T24, T18, T19>);
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(468, 112);
		this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(51, 16);
		this.label6.TabIndex = 13;
		this.label6.Text = "Tên/ID:";
		this.tabBM.Controls.Add(this.lbBMSelected);
		this.tabBM.Controls.Add(this.txtSearchBM);
		this.tabBM.Controls.Add(this.button16);
		this.tabBM.Controls.Add(this.numBMAmount);
		this.tabBM.Controls.Add(this.label5);
		this.tabBM.Controls.Add(this.btnCreateBM);
		this.tabBM.Controls.Add(this.button6);
		this.tabBM.Controls.Add(this.button7);
		this.tabBM.Controls.Add(this.statusStrip2);
		this.tabBM.Controls.Add(this.gvBM);
		this.tabBM.Controls.Add(this.progressBar2);
		this.tabBM.ImageIndex = 0;
		this.tabBM.Location = new System.Drawing.Point(4, 25);
		this.tabBM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabBM.Name = "tabBM";
		this.tabBM.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabBM.Size = new System.Drawing.Size(1627, 664);
		this.tabBM.TabIndex = 1;
		this.tabBM.Text = "_____BM_____";
		this.tabBM.UseVisualStyleBackColor = true;
		this.lbBMSelected.AutoSize = true;
		this.lbBMSelected.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbBMSelected.Location = new System.Drawing.Point(13, 82);
		this.lbBMSelected.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lbBMSelected.Name = "lbBMSelected";
		this.lbBMSelected.Size = new System.Drawing.Size(18, 17);
		this.lbBMSelected.TabIndex = 55;
		this.lbBMSelected.Text = "0";
		this.txtSearchBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearchBM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtSearchBM.Location = new System.Drawing.Point(696, 10);
		this.txtSearchBM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtSearchBM.Name = "txtSearchBM";
		this.txtSearchBM.Size = new System.Drawing.Size(697, 28);
		this.txtSearchBM.TabIndex = 22;
		this.txtSearchBM.TextChanged += new System.EventHandler(txtSearchBM_TextChanged);
		this.txtSearchBM.KeyDown += new System.Windows.Forms.KeyEventHandler(txtSearchBM_KeyDown<T24, T18, T36, T26, T25, T37>);
		this.button16.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button16.Location = new System.Drawing.Point(1404, 7);
		this.button16.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(208, 34);
		this.button16.TabIndex = 23;
		this.button16.Text = "Tìm kiếm | Search";
		this.button16.UseVisualStyleBackColor = true;
		this.button16.Click += new System.EventHandler(button16_Click);
		this.numBMAmount.Location = new System.Drawing.Point(443, 14);
		this.numBMAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.numBMAmount.Maximum = new decimal((int[])(object)new T25[4]
		{
			(T25)99999,
			default(T25),
			default(T25),
			default(T25)
		});
		this.numBMAmount.Name = "numBMAmount";
		this.numBMAmount.Size = new System.Drawing.Size(123, 22);
		this.numBMAmount.TabIndex = 21;
		this.numBMAmount.Value = new decimal((int[])(object)new T25[4]
		{
			(T25)2,
			default(T25),
			default(T25),
			default(T25)
		});
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(357, 17);
		this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(50, 16);
		this.label5.TabIndex = 20;
		this.label5.Text = "Số BM:";
		this.btnCreateBM.ForeColor = System.Drawing.Color.Blue;
		this.btnCreateBM.Location = new System.Drawing.Point(576, 9);
		this.btnCreateBM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.btnCreateBM.Name = "btnCreateBM";
		this.btnCreateBM.Size = new System.Drawing.Size(109, 34);
		this.btnCreateBM.TabIndex = 19;
		this.btnCreateBM.Text = "Tạo BM";
		this.btnCreateBM.UseVisualStyleBackColor = true;
		this.btnCreateBM.Click += new System.EventHandler(btnCreateBM_Click<T24, T25, T39, T38, T18, T19, T26, T42>);
		this.button6.ForeColor = System.Drawing.Color.Blue;
		this.button6.Location = new System.Drawing.Point(127, 9);
		this.button6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(192, 34);
		this.button6.TabIndex = 18;
		this.button6.Text = "Nhận Link BM";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click);
		this.button7.Location = new System.Drawing.Point(15, 9);
		this.button7.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(101, 34);
		this.button7.TabIndex = 17;
		this.button7.Text = "Reload";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(button7_Click);
		this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip2.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T41[2]
		{
			(T41)this.toolStripStatusLabel3,
			(T41)this.toolStripStatusLabel5
		});
		this.statusStrip2.Location = new System.Drawing.Point(5, 633);
		this.statusStrip2.Name = "statusStrip2";
		this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
		this.statusStrip2.Size = new System.Drawing.Size(1617, 26);
		this.statusStrip2.TabIndex = 15;
		this.statusStrip2.Text = "statusStrip2";
		this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
		this.toolStripStatusLabel3.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel3.Text = "Tổng:";
		this.toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
		this.toolStripStatusLabel5.Size = new System.Drawing.Size(18, 20);
		this.toolStripStatusLabel5.Text = "0";
		this.gvBM.AllowUserToAddRows = false;
		this.gvBM.AllowUserToDeleteRows = false;
		this.gvBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvBM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		((System.Windows.Forms.DataGridViewCellStyle)val5).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val5).BackColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.DataGridViewCellStyle)val5).Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val5).ForeColor = System.Drawing.SystemColors.WindowText;
		((System.Windows.Forms.DataGridViewCellStyle)val5).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val5).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val5).WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.gvBM.ColumnHeadersDefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val5;
		this.gvBM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		((System.Windows.Forms.DataGridViewCellStyle)val6).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val6).BackColor = System.Drawing.SystemColors.Window;
		((System.Windows.Forms.DataGridViewCellStyle)val6).Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val6).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.DataGridViewCellStyle)val6).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val6).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val6).WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.gvBM.DefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val6;
		this.gvBM.Location = new System.Drawing.Point(11, 79);
		this.gvBM.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
		this.gvBM.Name = "gvBM";
		this.gvBM.RowHeadersWidth = 51;
		this.gvBM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvBM.Size = new System.Drawing.Size(1601, 548);
		this.gvBM.TabIndex = 13;
		this.gvBM.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvBM_ColumnHeaderMouseClick<T43, T24, T20, T25, T18, T22, T26>);
		this.gvBM.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvBM_RowStateChanged<T25, T18, T29>);
		this.gvBM.Click += new System.EventHandler(gvBM_Click<T30, T31, T24, T25, T18, T19, T32>);
		this.gvBM.MouseClick += new System.Windows.Forms.MouseEventHandler(gvBM_MouseClick<T24, T33, T34, T18, T35>);
		this.progressBar2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.progressBar2.Location = new System.Drawing.Point(11, 53);
		this.progressBar2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.progressBar2.Name = "progressBar2";
		this.progressBar2.Size = new System.Drawing.Size(1601, 15);
		this.progressBar2.TabIndex = 14;
		this.tabPage.Controls.Add(this.label9);
		this.tabPage.Controls.Add(this.lbPageSelected);
		this.tabPage.Controls.Add(this.label8);
		this.tabPage.Controls.Add(this.txtCategoryCreatePage);
		this.tabPage.Controls.Add(this.txtCreateNamePage);
		this.tabPage.Controls.Add(this.ccbTypeCreatePage);
		this.tabPage.Controls.Add(this.button17);
		this.tabPage.Controls.Add(this.txtSearchPage);
		this.tabPage.Controls.Add(this.button9);
		this.tabPage.Controls.Add(this.statusStrip3);
		this.tabPage.Controls.Add(this.button8);
		this.tabPage.Controls.Add(this.gvPage);
		this.tabPage.Controls.Add(this.progressBar3);
		this.tabPage.ImageIndex = 1;
		this.tabPage.Location = new System.Drawing.Point(4, 25);
		this.tabPage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabPage.Name = "tabPage";
		this.tabPage.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabPage.Size = new System.Drawing.Size(1627, 664);
		this.tabPage.TabIndex = 3;
		this.tabPage.Text = "_____Page_____";
		this.tabPage.UseVisualStyleBackColor = true;
		this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(1207, 16);
		this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(69, 16);
		this.label9.TabIndex = 57;
		this.label9.Text = "Tên page:";
		this.lbPageSelected.AutoSize = true;
		this.lbPageSelected.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbPageSelected.Location = new System.Drawing.Point(19, 82);
		this.lbPageSelected.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lbPageSelected.Name = "lbPageSelected";
		this.lbPageSelected.Size = new System.Drawing.Size(18, 17);
		this.lbPageSelected.TabIndex = 56;
		this.lbPageSelected.Text = "0";
		this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(917, 15);
		this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(71, 16);
		this.label8.TabIndex = 28;
		this.label8.Text = "Loại page:";
		this.txtCategoryCreatePage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.txtCategoryCreatePage.Location = new System.Drawing.Point(1004, 12);
		this.txtCategoryCreatePage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtCategoryCreatePage.Name = "txtCategoryCreatePage";
		this.txtCategoryCreatePage.Size = new System.Drawing.Size(191, 22);
		this.txtCategoryCreatePage.TabIndex = 27;
		this.txtCategoryCreatePage.Text = "200046713342752";
		this.txtCreateNamePage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.txtCreateNamePage.Location = new System.Drawing.Point(1292, 12);
		this.txtCreateNamePage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtCreateNamePage.Name = "txtCreateNamePage";
		this.txtCreateNamePage.Size = new System.Drawing.Size(180, 22);
		this.txtCreateNamePage.TabIndex = 26;
		this.txtCreateNamePage.TextChanged += new System.EventHandler(txtCreateNamePage_TextChanged);
		this.ccbTypeCreatePage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.ccbTypeCreatePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbTypeCreatePage.FormattingEnabled = true;
		this.ccbTypeCreatePage.Items.AddRange((object[])(object)new T18[2]
		{
			(T18)"Page thường",
			(T18)"Page pro5"
		});
		this.ccbTypeCreatePage.Location = new System.Drawing.Point(696, 12);
		this.ccbTypeCreatePage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.ccbTypeCreatePage.Name = "ccbTypeCreatePage";
		this.ccbTypeCreatePage.Size = new System.Drawing.Size(212, 24);
		this.ccbTypeCreatePage.TabIndex = 25;
		this.button17.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button17.Location = new System.Drawing.Point(1484, 9);
		this.button17.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button17.Name = "button17";
		this.button17.Size = new System.Drawing.Size(133, 34);
		this.button17.TabIndex = 24;
		this.button17.Text = "Tạo page";
		this.button17.UseVisualStyleBackColor = true;
		this.button17.Click += new System.EventHandler(button17_Click<T24, T26, T25, T18, T19, T42>);
		this.txtSearchPage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearchPage.Location = new System.Drawing.Point(135, 12);
		this.txtSearchPage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtSearchPage.Name = "txtSearchPage";
		this.txtSearchPage.Size = new System.Drawing.Size(328, 22);
		this.txtSearchPage.TabIndex = 22;
		this.txtSearchPage.TextChanged += new System.EventHandler(txtSearchPage_TextChanged);
		this.txtSearchPage.KeyDown += new System.Windows.Forms.KeyEventHandler(txtSearchPage_KeyDown<T24, T18, T36, T26, T30, T31, T44, T25, T37, T32>);
		this.button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button9.Location = new System.Drawing.Point(473, 9);
		this.button9.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(213, 34);
		this.button9.TabIndex = 23;
		this.button9.Text = "Tìm kiếm | Search";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(button9_Click);
		this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip3.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T41[8]
		{
			(T41)this.toolStripStatusLabel7,
			(T41)this.toolStripStatusLabel9,
			(T41)this.toolStripStatusLabel13,
			(T41)this.lbPageLive,
			(T41)this.toolStripStatusLabel11,
			(T41)this.lbPageNormal,
			(T41)this.toolStripStatusLabel15,
			(T41)this.lbPagePro5
		});
		this.statusStrip3.Location = new System.Drawing.Point(5, 633);
		this.statusStrip3.Name = "statusStrip3";
		this.statusStrip3.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
		this.statusStrip3.Size = new System.Drawing.Size(1617, 26);
		this.statusStrip3.TabIndex = 21;
		this.statusStrip3.Text = "statusStrip3";
		this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
		this.toolStripStatusLabel7.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel7.Text = "Tổng:";
		this.toolStripStatusLabel9.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
		this.toolStripStatusLabel9.Size = new System.Drawing.Size(18, 20);
		this.toolStripStatusLabel9.Text = "0";
		this.toolStripStatusLabel13.Name = "toolStripStatusLabel13";
		this.toolStripStatusLabel13.Size = new System.Drawing.Size(38, 20);
		this.toolStripStatusLabel13.Text = "Live:";
		this.lbPageLive.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbPageLive.Name = "lbPageLive";
		this.lbPageLive.Size = new System.Drawing.Size(18, 20);
		this.lbPageLive.Text = "0";
		this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
		this.toolStripStatusLabel11.Size = new System.Drawing.Size(96, 20);
		this.toolStripStatusLabel11.Text = "Page thường:";
		this.lbPageNormal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbPageNormal.Name = "lbPageNormal";
		this.lbPageNormal.Size = new System.Drawing.Size(18, 20);
		this.lbPageNormal.Text = "0";
		this.toolStripStatusLabel15.Name = "toolStripStatusLabel15";
		this.toolStripStatusLabel15.Size = new System.Drawing.Size(79, 20);
		this.toolStripStatusLabel15.Text = "Page pro5:";
		this.lbPagePro5.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbPagePro5.Name = "lbPagePro5";
		this.lbPagePro5.Size = new System.Drawing.Size(18, 20);
		this.lbPagePro5.Text = "0";
		this.button8.Location = new System.Drawing.Point(15, 9);
		this.button8.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(101, 34);
		this.button8.TabIndex = 20;
		this.button8.Text = "Reload";
		this.button8.UseVisualStyleBackColor = true;
		this.button8.Click += new System.EventHandler(button8_Click);
		this.gvPage.AllowUserToAddRows = false;
		this.gvPage.AllowUserToDeleteRows = false;
		this.gvPage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		((System.Windows.Forms.DataGridViewCellStyle)val7).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val7).BackColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.DataGridViewCellStyle)val7).Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val7).ForeColor = System.Drawing.SystemColors.WindowText;
		((System.Windows.Forms.DataGridViewCellStyle)val7).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val7).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val7).WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.gvPage.ColumnHeadersDefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val7;
		this.gvPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		((System.Windows.Forms.DataGridViewCellStyle)val8).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val8).BackColor = System.Drawing.SystemColors.Window;
		((System.Windows.Forms.DataGridViewCellStyle)val8).Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val8).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.DataGridViewCellStyle)val8).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val8).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val8).WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.gvPage.DefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val8;
		this.gvPage.Location = new System.Drawing.Point(15, 73);
		this.gvPage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
		this.gvPage.Name = "gvPage";
		this.gvPage.RowHeadersWidth = 51;
		this.gvPage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvPage.Size = new System.Drawing.Size(1603, 554);
		this.gvPage.TabIndex = 18;
		this.gvPage.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvPage_CellMouseMove);
		this.gvPage.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvPage_ColumnHeaderMouseClick<T45, T24, T20, T25, T18, T22, T26>);
		this.gvPage.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvPage_RowStateChanged<T25, T18, T29>);
		this.gvPage.Click += new System.EventHandler(gvPage_Click<T30, T31, T24, T25, T18, T19, T32>);
		this.gvPage.MouseClick += new System.Windows.Forms.MouseEventHandler(gvPage_MouseClick<T24, T33, T34, T18, T35>);
		this.progressBar3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.progressBar3.Location = new System.Drawing.Point(15, 47);
		this.progressBar3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.progressBar3.Name = "progressBar3";
		this.progressBar3.Size = new System.Drawing.Size(1601, 15);
		this.progressBar3.TabIndex = 19;
		this.tabPageLocations.Controls.Add(this.button15);
		this.tabPageLocations.Controls.Add(this.button14);
		this.tabPageLocations.Controls.Add(this.ccbPageLocations);
		this.tabPageLocations.Controls.Add(this.textBox1);
		this.tabPageLocations.Controls.Add(this.button12);
		this.tabPageLocations.Controls.Add(this.button13);
		this.tabPageLocations.ImageIndex = 1;
		this.tabPageLocations.Location = new System.Drawing.Point(4, 25);
		this.tabPageLocations.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabPageLocations.Name = "tabPageLocations";
		this.tabPageLocations.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabPageLocations.Size = new System.Drawing.Size(1627, 664);
		this.tabPageLocations.TabIndex = 5;
		this.tabPageLocations.Text = "Page Vị Trí";
		this.tabPageLocations.UseVisualStyleBackColor = true;
		this.button15.Location = new System.Drawing.Point(756, 9);
		this.button15.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button15.Name = "button15";
		this.button15.Size = new System.Drawing.Size(180, 34);
		this.button15.TabIndex = 29;
		this.button15.Text = "Tạo Page Vị Trí";
		this.button15.UseVisualStyleBackColor = true;
		this.button15.Click += new System.EventHandler(button15_Click);
		this.button14.Location = new System.Drawing.Point(512, 9);
		this.button14.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button14.Name = "button14";
		this.button14.Size = new System.Drawing.Size(233, 34);
		this.button14.TabIndex = 28;
		this.button14.Text = "Hiện Thị Page Vị Trí";
		this.button14.UseVisualStyleBackColor = true;
		this.button14.Click += new System.EventHandler(button14_Click<T26, T18, T19>);
		this.ccbPageLocations.FormattingEnabled = true;
		this.ccbPageLocations.Location = new System.Drawing.Point(127, 12);
		this.ccbPageLocations.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.ccbPageLocations.Name = "ccbPageLocations";
		this.ccbPageLocations.Size = new System.Drawing.Size(372, 24);
		this.ccbPageLocations.TabIndex = 27;
		this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox1.Location = new System.Drawing.Point(947, 15);
		this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(335, 22);
		this.textBox1.TabIndex = 25;
		this.button12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button12.Location = new System.Drawing.Point(1291, 9);
		this.button12.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(213, 34);
		this.button12.TabIndex = 26;
		this.button12.Text = "Tìm kiếm | Search";
		this.button12.UseVisualStyleBackColor = true;
		this.button13.Location = new System.Drawing.Point(15, 9);
		this.button13.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button13.Name = "button13";
		this.button13.Size = new System.Drawing.Size(101, 34);
		this.button13.TabIndex = 24;
		this.button13.Text = "Reload";
		this.button13.UseVisualStyleBackColor = true;
		this.tabGroups.Controls.Add(this.txtSearchGroup);
		this.tabGroups.Controls.Add(this.button10);
		this.tabGroups.Controls.Add(this.statusStrip4);
		this.tabGroups.Controls.Add(this.button11);
		this.tabGroups.Controls.Add(this.gvGroup);
		this.tabGroups.Controls.Add(this.progressBar4);
		this.tabGroups.ImageIndex = 4;
		this.tabGroups.Location = new System.Drawing.Point(4, 25);
		this.tabGroups.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
		this.tabGroups.Name = "tabGroups";
		this.tabGroups.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
		this.tabGroups.Size = new System.Drawing.Size(1627, 664);
		this.tabGroups.TabIndex = 4;
		this.tabGroups.Text = "_____Group_____";
		this.tabGroups.UseVisualStyleBackColor = true;
		this.txtSearchGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearchGroup.Location = new System.Drawing.Point(133, 12);
		this.txtSearchGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.txtSearchGroup.Name = "txtSearchGroup";
		this.txtSearchGroup.Size = new System.Drawing.Size(481, 22);
		this.txtSearchGroup.TabIndex = 28;
		this.button10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button10.Location = new System.Drawing.Point(629, 9);
		this.button10.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(213, 34);
		this.button10.TabIndex = 29;
		this.button10.Text = "Tìm kiếm | Search";
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(button10_Click);
		this.statusStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip4.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T41[2]
		{
			(T41)this.toolStripStatusLabel16,
			(T41)this.lbTotalGroups
		});
		this.statusStrip4.Location = new System.Drawing.Point(4, 636);
		this.statusStrip4.Name = "statusStrip4";
		this.statusStrip4.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
		this.statusStrip4.Size = new System.Drawing.Size(1619, 26);
		this.statusStrip4.TabIndex = 27;
		this.statusStrip4.Text = "statusStrip4";
		this.toolStripStatusLabel16.Name = "toolStripStatusLabel16";
		this.toolStripStatusLabel16.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel16.Text = "Tổng:";
		this.lbTotalGroups.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbTotalGroups.Name = "lbTotalGroups";
		this.lbTotalGroups.Size = new System.Drawing.Size(18, 20);
		this.lbTotalGroups.Text = "0";
		this.button11.Location = new System.Drawing.Point(15, 9);
		this.button11.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(101, 34);
		this.button11.TabIndex = 26;
		this.button11.Text = "Reload";
		this.button11.UseVisualStyleBackColor = true;
		this.button11.Click += new System.EventHandler(button11_Click);
		this.gvGroup.AllowUserToAddRows = false;
		this.gvGroup.AllowUserToDeleteRows = false;
		this.gvGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		((System.Windows.Forms.DataGridViewCellStyle)val9).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val9).BackColor = System.Drawing.SystemColors.Control;
		((System.Windows.Forms.DataGridViewCellStyle)val9).Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val9).ForeColor = System.Drawing.SystemColors.WindowText;
		((System.Windows.Forms.DataGridViewCellStyle)val9).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val9).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val9).WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.gvGroup.ColumnHeadersDefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val9;
		this.gvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		((System.Windows.Forms.DataGridViewCellStyle)val10).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val10).BackColor = System.Drawing.SystemColors.Window;
		((System.Windows.Forms.DataGridViewCellStyle)val10).Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val10).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.DataGridViewCellStyle)val10).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val10).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val10).WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.gvGroup.DefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val10;
		this.gvGroup.Location = new System.Drawing.Point(11, 79);
		this.gvGroup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
		this.gvGroup.Name = "gvGroup";
		this.gvGroup.RowHeadersWidth = 51;
		this.gvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvGroup.Size = new System.Drawing.Size(1607, 550);
		this.gvGroup.TabIndex = 24;
		this.gvGroup.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvGroup_ColumnHeaderMouseClick<T46, T24, T20, T25, T18, T22, T26, T47, T48>);
		this.gvGroup.Click += new System.EventHandler(gvGroup_Click<T30, T31, T24, T25, T18, T19, T32>);
		this.gvGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(gvGroup_MouseClick<T24, T33, T34, T18, T35, T49, T30, T25, T19, T32, T26, T50, T38, T51>);
		this.progressBar4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.progressBar4.Location = new System.Drawing.Point(15, 53);
		this.progressBar4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.progressBar4.Name = "progressBar4";
		this.progressBar4.Size = new System.Drawing.Size(1603, 15);
		this.progressBar4.TabIndex = 25;
		this.tabPage3.Controls.Add(this.plBrowser);
		this.tabPage3.ImageIndex = 3;
		this.tabPage3.Location = new System.Drawing.Point(4, 25);
		this.tabPage3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.tabPage3.Size = new System.Drawing.Size(1627, 664);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "_____Browser_____";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.plBrowser.AutoScroll = true;
		this.plBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
		this.plBrowser.Location = new System.Drawing.Point(5, 5);
		this.plBrowser.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		this.plBrowser.Name = "plBrowser";
		this.plBrowser.Size = new System.Drawing.Size(1617, 654);
		this.plBrowser.TabIndex = 0;
		this.plBrowser.SizeChanged += new System.EventHandler(plBrowser_SizeChanged<T24, T18, T19>);
		this.timer_load_bm.Interval = 1000;
		this.timer_load_bm.Tick += new System.EventHandler(timer_load_bm_Tick<T24, T18, T19>);
		this.timer_load_page.Interval = 1000;
		this.timer_load_page.Tick += new System.EventHandler(timer_load_page_Tick<T24, T18, T19>);
		this.timer_load_group.Interval = 1000;
		this.timer_load_group.Tick += new System.EventHandler(timer_load_group_Tick<T24, T18, T19>);
		this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.menuStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T41[1] { (T41)this.copyToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
		this.menuStrip1.Size = new System.Drawing.Size(2044, 38);
		this.menuStrip1.TabIndex = 15;
		this.menuStrip1.Text = "menuStrip1";
		this.copyToolStripMenuItem.DropDownItems.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T41[8]
		{
			(T41)this.uIDToolStripMenuItem,
			(T41)this.mậtKhẩuToolStripMenuItem,
			(T41)this.fACodeToolStripMenuItem,
			(T41)this.cookieToolStripMenuItem,
			(T41)this.emailPasswordToolStripMenuItem,
			(T41)this.thôngTinTàiKhoảnToolStripMenuItem,
			(T41)this.tokenEEABToolStripMenuItem,
			(T41)this.tokenEEAGToolStripMenuItem
		});
		this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		this.copyToolStripMenuItem.Size = new System.Drawing.Size(57, 34);
		this.copyToolStripMenuItem.Text = "Copy";
		this.uIDToolStripMenuItem.Name = "uIDToolStripMenuItem";
		this.uIDToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.uIDToolStripMenuItem.Text = "UID";
		this.uIDToolStripMenuItem.Click += new System.EventHandler(uIDToolStripMenuItem_Click<T50, T18, T19>);
		this.mậtKhẩuToolStripMenuItem.Name = "mậtKhẩuToolStripMenuItem";
		this.mậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.mậtKhẩuToolStripMenuItem.Text = "Mật khẩu";
		this.mậtKhẩuToolStripMenuItem.Click += new System.EventHandler(mậtKhẩuToolStripMenuItem_Click<T50, T18, T19>);
		this.fACodeToolStripMenuItem.Name = "fACodeToolStripMenuItem";
		this.fACodeToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.fACodeToolStripMenuItem.Text = "2FA code";
		this.fACodeToolStripMenuItem.Click += new System.EventHandler(fACodeToolStripMenuItem_Click<T50, T18, T19>);
		this.cookieToolStripMenuItem.Name = "cookieToolStripMenuItem";
		this.cookieToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.cookieToolStripMenuItem.Text = "Cookie";
		this.cookieToolStripMenuItem.Click += new System.EventHandler(cookieToolStripMenuItem_Click<T50, T18, T19>);
		this.emailPasswordToolStripMenuItem.Name = "emailPasswordToolStripMenuItem";
		this.emailPasswordToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.emailPasswordToolStripMenuItem.Text = "Email & Password";
		this.emailPasswordToolStripMenuItem.Click += new System.EventHandler(emailPasswordToolStripMenuItem_Click<T50, T18, T19>);
		this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
		this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
		this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(thôngTinTàiKhoảnToolStripMenuItem_Click<T50, T18, T19>);
		this.tokenEEABToolStripMenuItem.Name = "tokenEEABToolStripMenuItem";
		this.tokenEEABToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.tokenEEABToolStripMenuItem.Text = "Token EEAB";
		this.tokenEEABToolStripMenuItem.Click += new System.EventHandler(tokenEEABToolStripMenuItem_Click<T50, T18, T19>);
		this.tokenEEAGToolStripMenuItem.Name = "tokenEEAGToolStripMenuItem";
		this.tokenEEAGToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
		this.tokenEEAGToolStripMenuItem.Text = "Token EEAG";
		this.tokenEEAGToolStripMenuItem.Click += new System.EventHandler(tokenEEAGToolStripMenuItem_Click<T50, T18, T19>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1635, 722);
		base.Controls.Add(this.tabGroup);
		base.Controls.Add(this.menuStrip1);
		base.Icon = (System.Drawing.Icon)(T52)((System.Resources.ResourceManager)val4).GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		base.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		base.Name = "frmAdsManager";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Quản lý TKQC BM";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmAdsManager_FormClosing);
		base.Load += new System.EventHandler(frmAdsManager_Load<T24, T18, T19>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.tabControl.ResumeLayout(false);
		this.tabCookie.ResumeLayout(false);
		this.tabToken.ResumeLayout(false);
		this.tabToken.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numLimit).EndInit();
		this.tabTKQCBM.ResumeLayout(false);
		this.tabTKQCBM.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.tabGroup.ResumeLayout(false);
		this.tabAds.ResumeLayout(false);
		this.tabAds.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numMaxAct).EndInit();
		this.tabBM.ResumeLayout(false);
		this.tabBM.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numBMAmount).EndInit();
		this.statusStrip2.ResumeLayout(false);
		this.statusStrip2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvBM).EndInit();
		this.tabPage.ResumeLayout(false);
		this.tabPage.PerformLayout();
		this.statusStrip3.ResumeLayout(false);
		this.statusStrip3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvPage).EndInit();
		this.tabPageLocations.ResumeLayout(false);
		this.tabPageLocations.PerformLayout();
		this.tabGroups.ResumeLayout(false);
		this.tabGroups.PerformLayout();
		this.statusStrip4.ResumeLayout(false);
		this.statusStrip4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gvGroup).EndInit();
		this.tabPage3.ResumeLayout(false);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
