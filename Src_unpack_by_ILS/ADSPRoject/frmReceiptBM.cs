using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Data;
using ADSPRoject.License;
using ADSPRoject.Server;
using OpenQA.Selenium;
using xNet;

namespace ADSPRoject;

public class frmReceiptBM : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int lỗi;

		public string strlỗi;

		public int sucsess;

		public string strSuccess;

		public int threadRunning;

		public frmReceiptBM _003C_003E4__this;

		public ParameterizedThreadStart _003C_003E9__0;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe void _003CthrChromeReceipt_003Eb__0<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_0022: Expected I4, but got O
			//IL_004b: Expected O, but got I4
			//IL_0062: Expected O, but got I4
			//IL_0081: Expected O, but got I4
			//IL_0095: Expected I4, but got O
			//IL_00a9: Expected I4, but got O
			//IL_00c7: Expected I4, but got O
			//IL_00e5: Expected O, but got I4
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_0105: Expected O, but got I4
			//IL_0124: Expected I4, but got O
			//IL_0140: Expected O, but got I4
			//IL_0161: Expected I4, but got O
			//IL_0176: Expected O, but got I4
			//IL_0182: Expected O, but got I4
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected I4, but got Unknown
			//IL_01a5: Expected I4, but got O
			//IL_01fc: Expected O, but got I4
			//IL_020a: Expected O, but got I4
			//IL_0218: Expected O, but got I4
			//IL_0226: Expected O, but got I4
			//IL_023c: Expected I4, but got O
			//IL_0253: Expected O, but got I4
			//IL_0260: Expected O, but got I4
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Expected I4, but got Unknown
			//IL_0283: Expected I4, but got O
			//IL_02f5: Expected I4, but got O
			//IL_030c: Expected O, but got I4
			//IL_0320: Expected I4, but got O
			//IL_0337: Expected O, but got I4
			//IL_034b: Expected I4, but got O
			//IL_0362: Expected O, but got I4
			//IL_0371: Expected O, but got I4
			//IL_0388: Expected O, but got I4
			//IL_038f: Expected O, but got I4
			//IL_039c: Expected O, but got I4
			//IL_045a: Expected O, but got I4
			//IL_045e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0464: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			ChromeControl chromeControl = new ChromeControl("", _003C_003E4__this.listIndexFBEntity[(int)val], _003C_003E4__this.main, 15);
			chromeControl.setMessage((T2)frmMain.STATUS.Working.ToString(), (T1)0);
			T1 val2 = (T1)(chromeControl.isLogined && _003C_003E4__this.isRunning);
			T0 val11;
			if (val2 != null)
			{
				chromeControl.goUrl<T0, T1, T5, T6, T7, T2>((T2)ResouceControl.getResouce("RESOUCE_BM_OVERVIEW"));
				T1 val16;
				do
				{
					IL_038c:
					T0 val3 = (T0)(-1);
					T1 val4 = (T1)_003C_003E4__this.isRunning;
					if (val4 != null)
					{
						T0 val5 = (T0)0;
						while (true)
						{
							T1 val6 = (T1)((nint)val5 < _003C_003E4__this.listLink.Count);
							if (val6 == null)
							{
								break;
							}
							T1 val7 = (T1)(_003C_003E4__this.listLink[(int)val5] != null && !string.IsNullOrWhiteSpace(_003C_003E4__this.listLink[(int)val5].str2) && _003C_003E4__this.listLink[(int)val5].str2.Equals(frmMain.STATUS.Ready.ToString()));
							if (val7 == null)
							{
								val5 = (T0)(val5 + 1);
								continue;
							}
							val3 = val5;
							_003C_003E4__this.listLink[(int)val3].str2 = frmMain.STATUS.Used.ToString();
							break;
						}
						T1 val8 = (T1)((nint)val3 == -1);
						if (val8 == null)
						{
							T2 message = (T2)"";
							T0 val9 = chromeControl.receiptLinkBM_2<T0, T2, T8, T9, T1, T10>((T2)_003C_003E4__this.listLink[(int)val3].str1, out *(string*)(&message));
							T1 val10 = (T1)(val9 == null);
							if (val10 != null)
							{
								val11 = (T0)lỗi;
								lỗi = val11 + 1;
								strlỗi = strlỗi + _003C_003E4__this.listLink[(int)val3].str1 + "|Link đã sử dụng" + Environment.NewLine;
								_003C_003E4__this.txtlỗi.Text = strlỗi;
								_003C_003E4__this.lblỗi.Text = lỗi.ToString();
								goto IL_038c;
							}
							T1 val12 = (T1)((nint)val9 == 1);
							if (val12 == null)
							{
								T1 val13 = (T1)((nint)val9 == 3);
								if (val13 == null)
								{
									T1 val14 = (T1)((nint)val9 == 1);
									if (val14 == null)
									{
										T1 val15 = (T1)((nint)val9 == 4);
										if (val15 != null)
										{
											_003C_003E4__this.listLink[(int)val3].str2 = frmMain.STATUS.Ready.ToString();
											val3 = (T0)(-1);
										}
										else
										{
											val11 = (T0)sucsess;
											sucsess = val11 + 1;
											strSuccess = strSuccess + _003C_003E4__this.listLink[(int)val3].str1 + Environment.NewLine;
											_003C_003E4__this.txtSuccess.Text = strSuccess;
											_003C_003E4__this.lbSuccess.Text = sucsess.ToString();
											Thread.Sleep(_003C_003E4__this.intDelayReceiptBM * 1000);
										}
									}
									else
									{
										_003C_003E4__this.listLink[(int)val3].str2 = frmMain.STATUS.Ready.ToString();
										val3 = (T0)(-1);
									}
								}
								else
								{
									_003C_003E4__this.listLink[(int)val3].str2 = frmMain.STATUS.Ready.ToString();
									val3 = (T0)(-1);
								}
							}
							else
							{
								_003C_003E4__this.listLink[(int)val3].str2 = frmMain.STATUS.Ready.ToString();
								val3 = (T0)(-1);
							}
						}
						else
						{
							chromeControl.setMessage((T2)"Hết link BM", (T1)1);
						}
					}
					val16 = (T1)(!_003C_003E4__this.ViaReceiptAllLink || (nint)val3 == -1);
				}
				while (val16 == null);
				T3 val17 = (T3)Activator.CreateInstance(typeof(T3));
				FBFlowField fBFlowField = new FBFlowField();
				((List<FBFlowField>)val17).Add(new FBFlowField
				{
					key = "Clear_Cookie",
					value = "false",
					type = typeof(T1)
				});
				((List<FBFlowField>)val17).Add(new FBFlowField
				{
					key = "Save_Last_Cookie",
					value = "false",
					type = typeof(T1)
				});
				chromeControl.Close_Browser<T1, T2, T11, T12, T7>(new FBFlow
				{
					Flow_Name = "Close_Browser",
					Filed = (List<FBFlowField>)val17
				});
			}
			val11 = (T0)threadRunning;
			threadRunning = val11 - 1;
		}
	}

	private frmAdsManager frm;

	private frmMain main;

	private List<int> listIndexFBEntity;

	private bool isRunning = false;

	private List<ListStringData> listLink = (List<ListStringData>)Activator.CreateInstance(typeof(List<ListStringData>));

	private int intDelayReceiptBM = 0;

	private int intNumThread = 1;

	private bool ViaReceiptAllLink = false;

	private IContainer components = null;

	private TextBox txtLinkBM;

	private Label label1;

	private Label lbSuccess;

	private Label label3;

	private Label lblỗi;

	private Button button1;

	private TextBox txtSuccess;

	private TextBox txtlỗi;

	private Label lbTotal;

	private Label label4;

	private NumericUpDown numDelayReceiptBM;

	private Label label16;

	private NumericUpDown numThread;

	private Label label2;

	private SplitContainer splitContainer1;

	private CheckBox cbViaReceiptAllLink;

	public frmReceiptBM(frmAdsManager frm, frmMain main, List<int> listFBEntity)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		InitializeComponent<ComponentResourceManager, TextBox, Label, Button, NumericUpDown, SplitContainer, CheckBox, int, object, EventArgs, string, bool, decimal, Icon, FormClosingEventArgs>();
		this.frm = frm;
		this.main = main;
		listIndexFBEntity = listFBEntity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_002c: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0100: Expected O, but got I4
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		isRunning = !isRunning;
		T0 val = (T0)isRunning;
		if (val == null)
		{
			T0 val2 = (T0)(frm == null);
			if (val2 != null)
			{
				frmMain.isRunning = false;
			}
			button1.Text = "Nhận Link";
			return;
		}
		button1.Text = "Dừng Lại";
		txtSuccess.Text = "";
		txtlỗi.Text = "";
		listLink.Clear();
		T1[] lines = (T1[])(object)txtLinkBM.Lines;
		T2 val3 = (T2)0;
		while ((nint)val3 < lines.Length)
		{
			T1 val4 = (T1)((object[])(object)lines)[(object)val3];
			T0 val5 = (T0)(!string.IsNullOrWhiteSpace((string)val4));
			if (val5 != null)
			{
				listLink.Add(new ListStringData
				{
					str1 = ((string)val4).Trim(),
					str2 = frmMain.STATUS.Ready.ToString()
				});
			}
			val3 = (T2)(val3 + 1);
		}
		T0 val6 = (T0)(frm == null);
		if (val6 == null)
		{
			new Thread(thrReceipt<T1, T2, T0, HttpRequest, Dictionary<string, string>, char>).Start();
		}
		else
		{
			new Thread(thrChromeReceipt<T1, T2, Thread, T0, ParameterizedThreadStart>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void thrChromeReceipt<T0, T1, T2, T3, T4>()
	{
		//IL_0041: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected I4, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00e1: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		//IL_012f: Expected I4, but got O
		//IL_013e: Expected I4, but got O
		//IL_0157: Expected I4, but got O
		//IL_0176: Expected O, but got I4
		//IL_0188: Expected I4, but got O
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01af: Expected O, but got I4
		try
		{
			_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
			_003C_003Ec__DisplayClass7_._003C_003E4__this = this;
			frmMain.isRunning = true;
			_003C_003Ec__DisplayClass7_.threadRunning = 0;
			_003C_003Ec__DisplayClass7_.sucsess = 0;
			_003C_003Ec__DisplayClass7_.lỗi = 0;
			_003C_003Ec__DisplayClass7_.strSuccess = "";
			_003C_003Ec__DisplayClass7_.strlỗi = "";
			T1 val = (T1)0;
			while (true)
			{
				T3 val2 = (T3)((nint)val < listIndexFBEntity.Count);
				if (val2 == null)
				{
					break;
				}
				while (true)
				{
					T3 val3 = (T3)(isRunning && _003C_003Ec__DisplayClass7_.threadRunning >= intNumThread);
					if (val3 == null)
					{
						break;
					}
					Thread.Sleep(2000);
				}
				T3 val4 = (T3)(!isRunning);
				if (val4 != null)
				{
					break;
				}
				T1 val5 = (T1)_003C_003Ec__DisplayClass7_.threadRunning;
				_003C_003Ec__DisplayClass7_.threadRunning = val5 + 1;
				T2 val6 = (T2)new Thread(_003C_003Ec__DisplayClass7_._003CthrChromeReceipt_003Eb__0<T1, T3, T0, List<FBFlowField>, object, ReadOnlyCollection<IWebElement>, IWebElement, Exception, HttpRequest, Dictionary<string, string>, char, IEnumerator<Cookie>, Cookie>);
				((Thread)val6).Start((object)val);
				val = (T1)(val + 1);
			}
			while (true)
			{
				T3 val7 = (T3)(isRunning && _003C_003Ec__DisplayClass7_.threadRunning >= intNumThread);
				if (val7 == null)
				{
					break;
				}
				Thread.Sleep(2000);
			}
			T0 val8 = (T0)"";
			T1 val9 = (T1)0;
			while (true)
			{
				T3 val10 = (T3)((nint)val9 < listLink.Count);
				if (val10 == null)
				{
					break;
				}
				T3 val11 = (T3)(listLink[(int)val9] != null && !string.IsNullOrWhiteSpace(listLink[(int)val9].str2) && listLink[(int)val9].str2.Equals(frmMain.STATUS.Ready.ToString()));
				if (val11 != null)
				{
					val8 = (T0)((string)val8 + listLink[(int)val9].str1 + Environment.NewLine);
				}
				val9 = (T1)(val9 + 1);
			}
			txtLinkBM.Text = (string)val8;
			frmMain.isRunning = false;
			frmMain.infoMessage((T0)"Done!");
			button1.Text = "Nhận Link";
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void thrReceipt<T0, T1, T2, T3, T4, T5>()
	{
		//IL_000f: Expected O, but got I4
		//IL_0011: Expected O, but got I4
		//IL_0014: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_0038: Expected I4, but got O
		//IL_0063: Expected O, but got I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_00a3: Expected O, but got I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ea: Expected O, but got I4
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_014e: Expected O, but got I4
		try
		{
			T0 val = (T0)"";
			T0 val2 = (T0)"";
			T1 val3 = (T1)0;
			T1 val4 = (T1)0;
			T1 val5 = (T1)0;
			while (true)
			{
				T2 val6 = (T2)((nint)val5 < listLink.Count);
				if (val6 == null)
				{
					break;
				}
				T2 val7 = (T2)(!isRunning);
				if (val7 != null)
				{
					break;
				}
				T0 str = (T0)listLink[(int)val5].str1;
				T0 message = (T0)"";
				T1 val8 = frm.chrome.receiptLinkBM_2<T1, T0, T3, T4, T2, T5>(str, out *(string*)(&message));
				T2 val9 = (T2)(val8 == null);
				if (val9 != null)
				{
					val4 = (T1)(val4 + 1);
					val2 = (T0)((string)val2 + (string)str + Environment.NewLine);
					lblỗi.Text = ((int*)(&val4))->ToString();
					txtlỗi.Text = (string)val2;
				}
				else
				{
					T2 val10 = (T2)((nint)val8 == 1);
					if (val10 == null)
					{
						val3 = (T1)(val3 + 1);
						val = (T0)((string)val + (string)str + Environment.NewLine);
						lbSuccess.Text = ((int*)(&val3))->ToString();
						txtSuccess.Text = (string)val;
						T2 val11 = (T2)((nint)val5 < listLink.Count - 1);
						if (val11 != null)
						{
							Thread.Sleep(intDelayReceiptBM * 1000);
						}
					}
					else
					{
						val4 = (T1)(val4 + 1);
						val2 = (T0)((string)val2 + "HCQC|" + (string)str + Environment.NewLine);
						lblỗi.Text = ((int*)(&val4))->ToString();
						txtlỗi.Text = (string)val2;
					}
				}
				val5 = (T1)(val5 + 1);
			}
		}
		catch
		{
		}
		frmMain.infoMessage((T0)"Done!");
		button1.Text = "Nhận Link";
	}

	private void txtLinkBM_TextChanged<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)((IEnumerable<T3>)(object)txtLinkBM.Lines).Count()).ToString();
	}

	private void numDelayReceiptBM_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intDelayReceiptBM = int.Parse(((decimal)(T0)numDelayReceiptBM.Value).ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmReceiptBM_Load<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_00bb: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		int num;
		if (frm != null && frm.chrome != null && frm.chrome.frmMain != null && frm.chrome.frmMain.listFBEntity != null && frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity] != null)
		{
			_ = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intDelayReceiptBM;
			num = 1;
		}
		else
		{
			num = 0;
		}
		T0 val = (T0)num;
		if (val != null)
		{
			numDelayReceiptBM.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intDelayReceiptBM;
			numThread.Value = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadReceiptBM;
		}
		T0 val2 = (T0)(frm != null);
		if (val2 != null)
		{
			cbViaReceiptAllLink.Visible = false;
		}
		cbViaReceiptAllLink.Visible = User.AddCardByPro5;
	}

	private void frmReceiptBM_FormClosing<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_00a5: Expected O, but got I4
		int num;
		if (frm != null && frm.chrome != null && frm.chrome.frmMain != null && frm.chrome.frmMain.listFBEntity != null && frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity] != null)
		{
			_ = frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intDelayReceiptBM;
			num = 1;
		}
		else
		{
			num = 0;
		}
		T0 val = (T0)num;
		if (val != null)
		{
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intDelayReceiptBM = int.Parse(((decimal)(T1)numDelayReceiptBM.Value).ToString());
			frm.chrome.frmMain.listFBEntity[frm.chrome.indexEntity].intThreadReceiptBM = int.Parse(((decimal)(T1)numThread.Value).ToString());
			frmMain.settingSaving();
		}
		frmMain.isRunning = false;
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		intNumThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
	}

	private void cbViaReceiptAllLink_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		ViaReceiptAllLink = cbViaReceiptAllLink.Checked;
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
	{
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmReceiptBM));
		this.txtLinkBM = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lbSuccess = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.lblỗi = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.txtSuccess = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.txtlỗi = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.lbTotal = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelayReceiptBM = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label16 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.cbViaReceiptAllLink = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		((System.ComponentModel.ISupportInitialize)this.numDelayReceiptBM).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.txtLinkBM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtLinkBM.Location = new System.Drawing.Point(16, 30);
		this.txtLinkBM.Margin = new System.Windows.Forms.Padding(4);
		this.txtLinkBM.Multiline = true;
		this.txtLinkBM.Name = "txtLinkBM";
		this.txtLinkBM.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtLinkBM.Size = new System.Drawing.Size(680, 319);
		this.txtLinkBM.TabIndex = 0;
		this.txtLinkBM.TextChanged += new System.EventHandler(txtLinkBM_TextChanged<T7, T8, T9, T10>);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(11, 6);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(81, 16);
		this.label1.TabIndex = 1;
		this.label1.Text = "Thành công:";
		this.lbSuccess.AutoSize = true;
		this.lbSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbSuccess.ForeColor = System.Drawing.Color.Blue;
		this.lbSuccess.Location = new System.Drawing.Point(100, 6);
		this.lbSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbSuccess.Name = "lbSuccess";
		this.lbSuccess.Size = new System.Drawing.Size(17, 17);
		this.lbSuccess.TabIndex = 2;
		this.lbSuccess.Text = "0";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(6, 6);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(28, 16);
		this.label3.TabIndex = 3;
		this.label3.Text = "Lỗi:";
		this.lblỗi.AutoSize = true;
		this.lblỗi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblỗi.ForeColor = System.Drawing.Color.Red;
		this.lblỗi.Location = new System.Drawing.Point(41, 5);
		this.lblỗi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblỗi.Name = "lblỗi";
		this.lblỗi.Size = new System.Drawing.Size(17, 17);
		this.lblỗi.TabIndex = 4;
		this.lblỗi.Text = "0";
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Location = new System.Drawing.Point(597, 625);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 28);
		this.button1.TabIndex = 5;
		this.button1.Text = "Nhận Link";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T11, T10, T7, T8, T9>);
		this.txtSuccess.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSuccess.Location = new System.Drawing.Point(4, 26);
		this.txtSuccess.Margin = new System.Windows.Forms.Padding(4);
		this.txtSuccess.Multiline = true;
		this.txtSuccess.Name = "txtSuccess";
		this.txtSuccess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtSuccess.Size = new System.Drawing.Size(338, 232);
		this.txtSuccess.TabIndex = 6;
		this.txtlỗi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtlỗi.Location = new System.Drawing.Point(4, 26);
		this.txtlỗi.Margin = new System.Windows.Forms.Padding(4);
		this.txtlỗi.Multiline = true;
		this.txtlỗi.Name = "txtlỗi";
		this.txtlỗi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtlỗi.Size = new System.Drawing.Size(322, 235);
		this.txtlỗi.TabIndex = 7;
		this.lbTotal.AutoSize = true;
		this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbTotal.ForeColor = System.Drawing.Color.Black;
		this.lbTotal.Location = new System.Drawing.Point(88, 11);
		this.lbTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(17, 17);
		this.lbTotal.TabIndex = 9;
		this.lbTotal.Text = "0";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(16, 11);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(65, 16);
		this.label4.TabIndex = 8;
		this.label4.Text = "Tổng link:";
		this.numDelayReceiptBM.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numDelayReceiptBM.Location = new System.Drawing.Point(505, 629);
		this.numDelayReceiptBM.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayReceiptBM.Maximum = new decimal((int[])(object)new T7[4]
		{
			(T7)9999999,
			default(T7),
			default(T7),
			default(T7)
		});
		this.numDelayReceiptBM.Name = "numDelayReceiptBM";
		this.numDelayReceiptBM.Size = new System.Drawing.Size(84, 22);
		this.numDelayReceiptBM.TabIndex = 54;
		this.numDelayReceiptBM.ValueChanged += new System.EventHandler(numDelayReceiptBM_ValueChanged<T12, T8, T9>);
		this.label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(444, 631);
		this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(46, 16);
		this.label16.TabIndex = 53;
		this.label16.Text = "Delay:";
		this.numThread.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.numThread.Location = new System.Drawing.Point(342, 629);
		this.numThread.Margin = new System.Windows.Forms.Padding(4);
		this.numThread.Maximum = new decimal((int[])(object)new T7[4]
		{
			(T7)9999999,
			default(T7),
			default(T7),
			default(T7)
		});
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(84, 22);
		this.numThread.TabIndex = 56;
		this.numThread.Value = new decimal((int[])(object)new T7[4]
		{
			(T7)1,
			default(T7),
			default(T7),
			default(T7)
		});
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T12, T8, T9>);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(281, 631);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(54, 16);
		this.label2.TabIndex = 55;
		this.label2.Text = "Thread:";
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.Location = new System.Drawing.Point(16, 356);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.txtSuccess);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		this.splitContainer1.Panel1.Controls.Add(this.lbSuccess);
		this.splitContainer1.Panel2.Controls.Add(this.lblỗi);
		this.splitContainer1.Panel2.Controls.Add(this.label3);
		this.splitContainer1.Panel2.Controls.Add(this.txtlỗi);
		this.splitContainer1.Size = new System.Drawing.Size(680, 262);
		this.splitContainer1.SplitterDistance = 346;
		this.splitContainer1.TabIndex = 57;
		this.cbViaReceiptAllLink.AutoSize = true;
		this.cbViaReceiptAllLink.Location = new System.Drawing.Point(16, 630);
		this.cbViaReceiptAllLink.Name = "cbViaReceiptAllLink";
		this.cbViaReceiptAllLink.Size = new System.Drawing.Size(163, 20);
		this.cbViaReceiptAllLink.TabIndex = 58;
		this.cbViaReceiptAllLink.Text = "1 VIA nhận toàn bộ link";
		this.cbViaReceiptAllLink.UseVisualStyleBackColor = true;
		this.cbViaReceiptAllLink.CheckedChanged += new System.EventHandler(cbViaReceiptAllLink_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(713, 668);
		base.Controls.Add(this.cbViaReceiptAllLink);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.numThread);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numDelayReceiptBM);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.lbTotal);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.txtLinkBM);
		base.Icon = (System.Drawing.Icon)(T13)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmReceiptBM";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Nhận link BM";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmReceiptBM_FormClosing<T11, T12, T8, T14>);
		base.Load += new System.EventHandler(frmReceiptBM_Load<T11, T8, T9>);
		((System.ComponentModel.ISupportInitialize)this.numDelayReceiptBM).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
