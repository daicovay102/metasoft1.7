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
using System.Web;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace ADSPRoject;

public class frmReMarketing : Form
{
	public enum STATUS
	{
		Ready,
		Sending,
		lỗi,
		Done
	}

	private bool isRunning = false;

	private List<Customer_UID> listCustomer = (List<Customer_UID>)Activator.CreateInstance(typeof(List<Customer_UID>));

	private ChromeControl chrome;

	private int delayFrom = 0;

	private int delayTo = 0;

	private string message;

	private string pageId;

	private Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	private IContainer components = null;

	private DataGridView gvData;

	private System.Windows.Forms.Timer timer_auto_refesh;

	private Button button2;

	private Button button1;

	private Button button3;

	private Button button4;

	private TextBox txtMessage;

	private NumericUpDown numDelayFrom;

	private Label label2;

	private Button button5;

	private ComboBox cbbStatus;

	private TextBox txtPageId;

	private Label label1;

	private Label label3;

	private NumericUpDown numDelayTo;

	private Label label4;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel lbReady;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripStatusLabel lbDone;

	private ToolStripStatusLabel toolStripStatusLabel4;

	public frmReMarketing()
	{
		InitializeComponent<ComponentResourceManager, Container, DataGridView, Button, TextBox, NumericUpDown, Label, ComboBox, StatusStrip, ToolStripStatusLabel, bool, ContextMenu, MenuItem, object, MouseEventArgs, int, EventArgs, decimal, List<Customer_UID>, ReadOnlyCollection<IWebElement>, IEnumerator<IWebElement>, IWebElement, Exception, string, List<Customer_UID>.Enumerator, ToolStripItem, Icon, FormClosingEventArgs>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmReMarketing(ChromeControl chrome)
	{
		InitializeComponent<ComponentResourceManager, Container, DataGridView, Button, TextBox, NumericUpDown, Label, ComboBox, StatusStrip, ToolStripStatusLabel, bool, ContextMenu, MenuItem, object, MouseEventArgs, int, EventArgs, decimal, List<Customer_UID>, ReadOnlyCollection<IWebElement>, IEnumerator<IWebElement>, IWebElement, Exception, string, List<Customer_UID>.Enumerator, ToolStripItem, Icon, FormClosingEventArgs>();
		this.chrome = chrome;
		Text = Text + " - " + chrome.frmMain.listFBEntity[chrome.indexEntity].UID;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 val3 = (T2)new MenuItem("------------");
			val3 = (T2)new MenuItem("Paste", (EventHandler)pasteEvent<string, int, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			val3 = (T2)new MenuItem("Copy", (EventHandler)copyEvent<string, int, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			val3 = (T2)new MenuItem("Xóa", (EventHandler)removeEvent<int, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			val3 = (T2)new MenuItem("------------");
			((Menu)val2).MenuItems.Add((MenuItem)val3);
			T2 val4 = (T2)new MenuItem("Cập nhật trạng thái");
			val3 = (T2)new MenuItem(STATUS.Ready.ToString(), (EventHandler)readyEvent<int, T0, T3, EventArgs>);
			((Menu)val4).MenuItems.Add((MenuItem)val3);
			val3 = (T2)new MenuItem(STATUS.Sending.ToString(), (EventHandler)sendingEvent<int, T0, T3, EventArgs>);
			((Menu)val4).MenuItems.Add((MenuItem)val3);
			val3 = (T2)new MenuItem(STATUS.lỗi.ToString(), (EventHandler)lỗiEvent<int, T0, T3, EventArgs>);
			((Menu)val4).MenuItems.Add((MenuItem)val3);
			val3 = (T2)new MenuItem(STATUS.Done.ToString(), (EventHandler)doneEvent<int, T0, T3, EventArgs>);
			((Menu)val4).MenuItems.Add((MenuItem)val3);
			((Menu)val2).MenuItems.Add((MenuItem)val4);
			((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	private void readyEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0038: Expected I4, but got O
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0063: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T0 val3 = (T0)(val - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listCustomer[gvData.SelectedRows[(int)val3].Index].STATUS = STATUS.Ready.ToString();
				val3 = (T0)(val3 - 1);
			}
		}
		gvBindData();
	}

	private void sendingEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0038: Expected I4, but got O
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0063: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T0 val3 = (T0)(val - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listCustomer[gvData.SelectedRows[(int)val3].Index].STATUS = STATUS.Sending.ToString();
				val3 = (T0)(val3 - 1);
			}
		}
		gvBindData();
	}

	private void lỗiEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0038: Expected I4, but got O
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0063: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T0 val3 = (T0)(val - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listCustomer[gvData.SelectedRows[(int)val3].Index].STATUS = STATUS.lỗi.ToString();
				val3 = (T0)(val3 - 1);
			}
		}
		gvBindData();
	}

	private void doneEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0038: Expected I4, but got O
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0063: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T0 val3 = (T0)(val - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listCustomer[gvData.SelectedRows[(int)val3].Index].STATUS = STATUS.Done.ToString();
				val3 = (T0)(val3 - 1);
			}
		}
		gvBindData();
	}

	private void removeEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0038: Expected I4, but got O
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_004e: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T0 val3 = (T0)(val - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listCustomer.RemoveAt(gvData.SelectedRows[(int)val3].Index);
				val3 = (T0)(val3 - 1);
			}
		}
		gvBindData();
	}

	private void copyEvent<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_003f: Expected I4, but got O
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0066: Expected O, but got I4
		T0 val = (T0)string.Empty;
		T1 val2 = (T1)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T2 val3 = (T2)((nint)val2 > 0);
		if (val3 != null)
		{
			T1 val4 = (T1)(val2 - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				val = (T0)((string)val + listCustomer[gvData.SelectedRows[(int)val4].Index].UID + Environment.NewLine);
				val4 = (T1)(val4 - 1);
			}
		}
		ClipboardCom.SetText<byte, IntPtr, T0>(val);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteEvent<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		T0 val = ClipboardCom.GetText<T0, IntPtr, T2>();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrEmpty((string)val3));
			if (val4 != null)
			{
				Customer_UID customer_UID = new Customer_UID();
				customer_UID.UID = ((string)val3).Trim();
				customer_UID.STATUS = STATUS.Ready.ToString();
				listCustomer.Add(customer_UID);
			}
			val2 = (T1)(val2 + 1);
		}
		gvBindData();
	}

	private void gvBindData()
	{
		gvData.DataSource = null;
		gvData.DataSource = listCustomer;
	}

	private void timer_auto_refesh_Tick<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000a: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		T0 val = (T0)(!isRunning);
		if (val != null)
		{
			timer_auto_refesh.Stop();
		}
		gvData.Refresh();
		lbDone.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((IEnumerable<Customer_UID>)listCustomer).Where((Func<Customer_UID, bool>)((Customer_UID a) => (T0)a.STATUS.Equals(STATUS.Done.ToString()))).Count()).ToString();
		lbReady.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((IEnumerable<Customer_UID>)listCustomer).Where((Func<Customer_UID, bool>)((Customer_UID a) => (T0)a.STATUS.Equals(STATUS.Ready.ToString()))).Count()).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0027: Expected O, but got I4
		isRunning = !isRunning;
		button1.Text = "Spam Inbox FB START";
		T0 val = (T0)isRunning;
		if (val != null)
		{
			button1.Text = "Spam Inbox FB STOP";
			timer_auto_refesh.Start();
			delayFrom = int.Parse(((decimal)(T1)numDelayFrom.Value).ToString());
			delayTo = int.Parse(((decimal)(T1)numDelayTo.Value).ToString());
			message = txtMessage.Text;
			pageId = txtPageId.Text;
			new Thread(thrSending<string, int, T0, Exception, IJavaScriptExecutor, T2>).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void thrSending<T0, T1, T2, T3, T4, T5>()
	{
		//IL_0008: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0029: Expected I4, but got O
		//IL_0044: Expected O, but got I4
		//IL_0056: Expected I4, but got O
		//IL_007d: Expected I4, but got O
		//IL_00b8: Expected I4, but got O
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00fd: Expected O, but got I4
		//IL_0112: Expected I4, but got O
		//IL_012f: Expected O, but got I4
		T0 error = (T0)"";
		T1 val = (T1)0;
		while (true)
		{
			T2 val2 = (T2)((nint)val < listCustomer.Count);
			if (val2 == null)
			{
				break;
			}
			T2 val3 = (T2)(!isRunning);
			if (val3 != null)
			{
				break;
			}
			T2 val4 = (T2)listCustomer[(int)val].STATUS.Equals(STATUS.Ready.ToString());
			if (val4 != null)
			{
				listCustomer[(int)val].STATUS = STATUS.Sending.ToString();
				T2 val5 = chrome.reMarketing<T2, T0, T3, T4, T1, T5>((T0)listCustomer[(int)val].UID, (T0)pageId, (T0)HttpUtility.UrlEncode((string)Spin_String<T0, Match, T2, Random, char>(rnd, (T0)message)), out *(string*)(&error));
				if (val5 == null)
				{
					listCustomer[(int)val].STATUS = STATUS.lỗi.ToString();
					break;
				}
				listCustomer[(int)val].STATUS = STATUS.Done.ToString();
			}
			Thread.Sleep(rnd.Next(delayFrom, delayTo));
			val = (T1)(val + 1);
		}
		T2 val6 = (T2)string.IsNullOrWhiteSpace((string)error);
		if (val6 == null)
		{
			frmMain.errorMessage(error);
		}
		else
		{
			frmMain.infoMessage((T0)"Done");
		}
	}

	private void frmReMarketing_FormClosing<T0, T1>(T0 sender, T1 e)
	{
		isRunning = false;
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		listCustomer.Clear();
		gvBindData();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button3_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0027: Expected O, but got I4
		isRunning = !isRunning;
		button3.Text = "Page Down START";
		T0 val = (T0)isRunning;
		if (val != null)
		{
			button3.Text = "Page Down STOP";
			new Thread(thrPageDown<T0>).Start();
		}
	}

	private void thrPageDown<T0>()
	{
		//IL_001f: Expected O, but got I4
		while (true)
		{
			T0 val = (T0)isRunning;
			if (val != null)
			{
				chrome.pageDown();
				Thread.Sleep(200);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button4_Click<T0, T1, T2, T3, T4, T5, T6, T7>(T0 sender, T1 e)
	{
		listCustomer.AddRange((IEnumerable<Customer_UID>)chrome.getFBID<T2, T3, T4, T5, T6, T7>());
		gvBindData();
		MessageBox.Show("Done!");
	}

	private void numDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		delayFrom = int.Parse(((decimal)(T0)numDelayFrom.Value).ToString());
		frmMain.setting.ReMarketing_DelayFrom = int.Parse(((decimal)(T0)numDelayFrom.Value).ToString());
		frmMain.settingSaving();
	}

	private void frmReMarketing_Load<T0, T1>(T0 sender, T1 e)
	{
		cbbStatus.SelectedIndex = 0;
		txtMessage.Text = frmMain.setting.ReMarketing_Message;
		numDelayFrom.Value = frmMain.setting.ReMarketing_DelayFrom;
		numDelayTo.Value = frmMain.setting.ReMarketing_DelayTo;
		txtPageId.Text = frmMain.setting.ReMarketing_PageId;
	}

	private unsafe void button5_Click<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_003c: Expected O, but got I4
		T0 val = (T0)"";
		T0 value = (T0)cbbStatus.SelectedItem.ToString();
		T1 enumerator = (T1)listCustomer.GetEnumerator();
		try
		{
			while (((List<Customer_UID>.Enumerator*)(&enumerator))->MoveNext())
			{
				Customer_UID current = ((List<Customer_UID>.Enumerator*)(&enumerator))->Current;
				T2 val2 = (T2)current.STATUS.Equals((string)value);
				if (val2 != null)
				{
					val = (T0)((string)val + current.UID + Environment.NewLine);
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<Customer_UID>.Enumerator*)(&enumerator))).Dispose();
		}
		ClipboardCom.SetText<byte, IntPtr, T0>(val);
	}

	private void numDelayTo_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		delayTo = int.Parse(((decimal)(T0)numDelayFrom.Value).ToString());
		frmMain.setting.ReMarketing_DelayTo = int.Parse(((decimal)(T0)numDelayTo.Value).ToString());
		frmMain.settingSaving();
	}

	private void txtMessage_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		message = txtMessage.Text;
		frmMain.setting.ReMarketing_Message = txtMessage.Text;
		frmMain.settingSaving();
	}

	private void txtPageId_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		pageId = txtPageId.Text;
		frmMain.setting.ReMarketing_PageId = txtPageId.Text;
		frmMain.settingSaving();
	}

	private void label4_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Spin_String<T0, T1, T2, T3, T4>(T3 rnd, T0 str)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmReMarketing));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.timer_auto_refesh = new System.Windows.Forms.Timer(this.components);
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button4 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.txtMessage = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.numDelayFrom = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.button5 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.cbbStatus = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.txtPageId = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelayTo = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.lbReady = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel2 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbDone = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel4 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayTo).BeginInit();
		this.statusStrip1.SuspendLayout();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(499, 41);
		this.gvData.Name = "gvData";
		this.gvData.ReadOnly = true;
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(440, 401);
		this.gvData.TabIndex = 0;
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T10, T11, T12, T13, T14>);
		this.timer_auto_refesh.Interval = 1000;
		this.timer_auto_refesh.Tick += new System.EventHandler(timer_auto_refesh_Tick<T10, T15, T13, T16>);
		this.button2.Location = new System.Drawing.Point(499, 12);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(87, 23);
		this.button2.TabIndex = 2;
		this.button2.Text = "Clear";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Location = new System.Drawing.Point(322, 14);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(170, 73);
		this.button1.TabIndex = 1;
		this.button1.Text = "Spam Inbox FB START";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T10, T17, T13, T16>);
		this.button3.Location = new System.Drawing.Point(14, 12);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(147, 23);
		this.button3.TabIndex = 3;
		this.button3.Text = "Page Down START";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T10, T13, T16>);
		this.button4.Location = new System.Drawing.Point(168, 12);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(133, 23);
		this.button4.TabIndex = 4;
		this.button4.Text = "Get UID Customer";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click<T13, T16, T18, T19, T20, T21, T10, T22>);
		this.txtMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtMessage.Location = new System.Drawing.Point(14, 108);
		this.txtMessage.Multiline = true;
		this.txtMessage.Name = "txtMessage";
		this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtMessage.Size = new System.Drawing.Size(478, 334);
		this.txtMessage.TabIndex = 5;
		this.txtMessage.TextChanged += new System.EventHandler(txtMessage_TextChanged);
		this.numDelayFrom.Location = new System.Drawing.Point(57, 41);
		this.numDelayFrom.Maximum = new decimal((int[])(object)new T15[4]
		{
			(T15)1410065407,
			(T15)2,
			default(T15),
			default(T15)
		});
		this.numDelayFrom.Name = "numDelayFrom";
		this.numDelayFrom.Size = new System.Drawing.Size(104, 20);
		this.numDelayFrom.TabIndex = 7;
		this.numDelayFrom.Value = new decimal((int[])(object)new T15[4]
		{
			(T15)3000,
			default(T15),
			default(T15),
			default(T15)
		});
		this.numDelayFrom.ValueChanged += new System.EventHandler(numDelay_ValueChanged<T17, T13, T16>);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(10, 43);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(40, 13);
		this.label2.TabIndex = 8;
		this.label2.Text = "Delay";
		this.button5.Location = new System.Drawing.Point(708, 12);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(87, 23);
		this.button5.TabIndex = 9;
		this.button5.Text = "Copy";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click<T23, T24, T10, T13, T16>);
		this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbbStatus.FormattingEnabled = true;
		this.cbbStatus.Items.AddRange((object[])(object)new T13[4]
		{
			(T13)"Ready",
			(T13)"Sending",
			(T13)"lỗi",
			(T13)"Done"
		});
		this.cbbStatus.Location = new System.Drawing.Point(594, 14);
		this.cbbStatus.Name = "cbbStatus";
		this.cbbStatus.Size = new System.Drawing.Size(107, 21);
		this.cbbStatus.TabIndex = 10;
		this.txtPageId.Location = new System.Drawing.Point(76, 67);
		this.txtPageId.Name = "txtPageId";
		this.txtPageId.Size = new System.Drawing.Size(224, 20);
		this.txtPageId.TabIndex = 14;
		this.txtPageId.TextChanged += new System.EventHandler(txtPageId_TextChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(15, 70);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(53, 13);
		this.label1.TabIndex = 15;
		this.label1.Text = "Page ID";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(12, 92);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(56, 13);
		this.label3.TabIndex = 16;
		this.label3.Text = "Message";
		this.numDelayTo.Location = new System.Drawing.Point(197, 41);
		this.numDelayTo.Maximum = new decimal((int[])(object)new T15[4]
		{
			(T15)1410065407,
			(T15)2,
			default(T15),
			default(T15)
		});
		this.numDelayTo.Name = "numDelayTo";
		this.numDelayTo.Size = new System.Drawing.Size(104, 20);
		this.numDelayTo.TabIndex = 17;
		this.numDelayTo.Value = new decimal((int[])(object)new T15[4]
		{
			(T15)5000,
			default(T15),
			default(T15),
			default(T15)
		});
		this.numDelayTo.ValueChanged += new System.EventHandler(numDelayTo_ValueChanged<T17, T13, T16>);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(168, 43);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(25, 13);
		this.label4.TabIndex = 18;
		this.label4.Text = "=>";
		this.label4.Click += new System.EventHandler(label4_Click);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T25[4]
		{
			(T25)this.lbReady,
			(T25)this.toolStripStatusLabel2,
			(T25)this.lbDone,
			(T25)this.toolStripStatusLabel4
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 455);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(16, 0, 1, 0);
		this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.statusStrip1.Size = new System.Drawing.Size(953, 22);
		this.statusStrip1.TabIndex = 19;
		this.statusStrip1.Text = "statusStrip1";
		this.lbReady.Name = "lbReady";
		this.lbReady.Size = new System.Drawing.Size(13, 17);
		this.lbReady.Text = "0";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(39, 17);
		this.toolStripStatusLabel2.Text = "Ready";
		this.lbDone.Name = "lbDone";
		this.lbDone.Size = new System.Drawing.Size(13, 17);
		this.lbDone.Text = "0";
		this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
		this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 17);
		this.toolStripStatusLabel4.Text = "Done";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(953, 477);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.numDelayTo);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.txtPageId);
		base.Controls.Add(this.cbbStatus);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numDelayFrom);
		base.Controls.Add(this.txtMessage);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.gvData);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T26)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.Name = "frmReMarketing";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Re-Marketing";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmReMarketing_FormClosing);
		base.Load += new System.EventHandler(frmReMarketing_Load);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayTo).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
