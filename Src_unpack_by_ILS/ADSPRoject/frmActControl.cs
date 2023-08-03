using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADSPRoject.Data;

namespace ADSPRoject;

public class frmActControl : Form
{
	private frmMain frm;

	public static int CountError = 0;

	public static bool isActive = true;

	private double totalCount = 0.0;

	public static double countSucess = 0.0;

	public static double countError = 0.0;

	private double error;

	private double success;

	private IContainer components = null;

	private DataGridView gvData;

	private Label label1;

	private NumericUpDown numActOnVia;

	private NumericUpDown numDieToStop;

	private Label label2;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel lbTotal;

	private Button btnStatus;

	private Timer timer_auto_update;

	private Label label4;

	private NumericUpDown numDieNext;

	private CheckBox cbFocusGridview;

	private NumericUpDown numDelayToApprovedHold;

	private Label label5;

	private NumericUpDown numDelayVerifyCard;

	private Label label6;

	private TextBox txtSearch;

	private Button button2;

	private NumericUpDown numThreadActOnVia;

	private Label label7;

	private Label label8;

	private TextBox txtCountryBait;

	private Label lbRowSelected;

	private CheckBox cbAddBinBait;

	private NumericUpDown numCheckPayment;

	private Label label9;

	private ComboBox ccbBinBait;

	private NumericUpDown numDelayBait;

	private Label label10;

	private Label label3;

	private TextBox txtBin6First;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripStatusLabel lbSuccess;

	private ToolStripStatusLabel toolStripStatusLabel4;

	private ToolStripStatusLabel lbError;

	public frmActControl(frmMain frm)
	{
		InitializeComponent<DataGridViewCellStyle, ComponentResourceManager, Container, DataGridView, Label, NumericUpDown, StatusStrip, ToolStripStatusLabel, Button, CheckBox, TextBox, ComboBox, int, object, DataGridViewRowStateChangedEventArgs, bool, ContextMenu, MenuItem, MouseEventArgs, decimal, EventArgs, ToolStripItem, Exception, KeyEventArgs, string, char, Icon, FormClosingEventArgs, List<GroupCreditCard>.Enumerator>();
		this.frm = frm;
		setData<bool, int>();
		if (frmMain.setting.actControl == null)
		{
			frmMain.setting.actControl = new ActControlData();
			frmMain.settingSaving();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		try
		{
			T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
			if (val != null)
			{
				T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
				T2 item = (T2)new MenuItem("Paste danh sách ID TK", (EventHandler)pasteActEvent<T2, string, int, List<string>, StringReader, T0, Exception, T3, EventArgs>);
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("----------------------");
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("Status");
				((Menu)val2).MenuItems.Add((MenuItem)item);
				T2 item2 = (T2)new MenuItem(frmMain.STATUS.Ready.ToString(), (EventHandler)statusUpdateEvent<T2, List<DataGridViewRow>, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)item).MenuItems.Add((MenuItem)item2);
				item2 = (T2)new MenuItem(frmMain.STATUS.lỗi.ToString(), (EventHandler)statusUpdateEvent<T2, List<DataGridViewRow>, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)item).MenuItems.Add((MenuItem)item2);
				item2 = (T2)new MenuItem(frmMain.STATUS.Done.ToString(), (EventHandler)statusUpdateEvent<T2, List<DataGridViewRow>, T0, int, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)item).MenuItems.Add((MenuItem)item2);
				item = (T2)new MenuItem("----------------------");
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("Copy dòng đã chọn", (EventHandler)copyEvent<string, T2, T0, List<DataGridViewRow>, int, List<ActControl>.Enumerator, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("Copy toàn bộ", (EventHandler)copyEvent<string, T2, T0, List<DataGridViewRow>, int, List<ActControl>.Enumerator, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("----------------------");
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("Xóa dòng đã chọn", (EventHandler)removeEvent<T2, T0, List<DataGridViewRow>, int, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)val2).MenuItems.Add((MenuItem)item);
				item = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)removeEvent<T2, T0, List<DataGridViewRow>, int, Exception, T3, EventArgs, DataGridViewRow>);
				((Menu)val2).MenuItems.Add((MenuItem)item);
				((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
			}
		}
		catch
		{
		}
	}

	private void statusUpdateEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0070: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00b1: Expected I4, but got O
		//IL_00ed: Expected O, but got I4
		//IL_00fd: Expected I4, but got O
		//IL_0139: Expected O, but got I4
		//IL_0149: Expected I4, but got O
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0175: Expected O, but got I4
		try
		{
			T0 val = (T0)sender;
			T1 val2 = (T1)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
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
					T2 val6 = (T2)((MenuItem)val).Text.Equals(frmMain.STATUS.Ready.ToString());
					if (val6 != null)
					{
						frmMain.actList[((List<DataGridViewRow>)val2)[(int)val4].Index].Status = frmMain.STATUS.Ready.ToString();
					}
					T2 val7 = (T2)((MenuItem)val).Text.Equals(frmMain.STATUS.lỗi.ToString());
					if (val7 != null)
					{
						frmMain.actList[((List<DataGridViewRow>)val2)[(int)val4].Index].Status = frmMain.STATUS.lỗi.ToString();
					}
					T2 val8 = (T2)((MenuItem)val).Text.Equals(frmMain.STATUS.Done.ToString());
					if (val8 != null)
					{
						frmMain.actList[((List<DataGridViewRow>)val2)[(int)val4].Index].Status = frmMain.STATUS.Done.ToString();
					}
					val4 = (T3)(val4 - 1);
				}
			}
			frmMain.actListSaving();
			gvData.Refresh();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void copyEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 sender, T8 e)
	{
		//IL_0020: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00f2: Expected I4, but got O
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011d: Expected O, but got I4
		try
		{
			T0 val = (T0)"";
			T1 val2 = (T1)sender;
			T2 val3 = (T2)((MenuItem)val2).Text.Equals("Copy dòng đã chọn");
			if (val3 == null)
			{
				T5 enumerator = (T5)frmMain.actList.GetEnumerator();
				try
				{
					while (((List<ActControl>.Enumerator*)(&enumerator))->MoveNext())
					{
						ActControl current = ((List<ActControl>.Enumerator*)(&enumerator))->Current;
						val = (T0)((string)val + current.Id + "|");
					}
				}
				finally
				{
					((IDisposable)(*(List<ActControl>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			else
			{
				T3 val4 = (T3)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T4>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T4)((DataGridViewBand)row).Index))
					.ToList();
				T2 val5 = (T2)(((List<DataGridViewRow>)val4).Count > 0);
				if (val5 != null)
				{
					T4 val6 = (T4)(((List<DataGridViewRow>)val4).Count - 1);
					while (true)
					{
						T2 val7 = (T2)((nint)val6 >= 0);
						if (val7 == null)
						{
							break;
						}
						val = (T0)((string)val + frmMain.actList[((List<DataGridViewRow>)val4)[(int)val6].Index].Id + "|");
						val6 = (T4)(val6 - 1);
					}
				}
			}
			Clipboard.Clear();
			Clipboard.SetText((string)val);
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void removeEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00a4: Expected I4, but got O
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00be: Expected O, but got I4
		try
		{
			T0 val = (T0)sender;
			T1 val2 = (T1)((MenuItem)val).Text.Equals("Xóa dòng đã chọn");
			if (val2 != null)
			{
				T2 val3 = (T2)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
					.ToList();
				T1 val4 = (T1)(((List<DataGridViewRow>)val3).Count > 0);
				if (val4 != null)
				{
					T3 val5 = (T3)(((List<DataGridViewRow>)val3).Count - 1);
					while (true)
					{
						T1 val6 = (T1)((nint)val5 >= 0);
						if (val6 == null)
						{
							break;
						}
						frmMain.actList.RemoveAt(((List<DataGridViewRow>)val3)[(int)val5].Index);
						val5 = (T3)(val5 - 1);
					}
				}
			}
			else
			{
				frmMain.actList.Clear();
			}
			frmMain.actListSaving();
			setData<T1, T3>();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteActEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T7 sender, T8 e)
	{
		//IL_0021: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00e6: Expected O, but got I4
		try
		{
			T1 val = (T1)"";
			val = (T1)Clipboard.GetText();
			val = (T1)((string)val).Replace("|", Environment.NewLine);
			T2 val2 = (T2)0;
			T3 val3 = (T3)Activator.CreateInstance(typeof(T3));
			T4 val4 = (T4)new StringReader((string)val);
			try
			{
				while (true)
				{
					T1 val5;
					T5 val6 = (T5)((val5 = (T1)((TextReader)val4).ReadLine()) != null);
					if (val6 != null)
					{
						T5 val7 = (T5)(!string.IsNullOrWhiteSpace((string)val5) && !((List<string>)val3).Contains(((string)val5).Trim()));
						if (val7 != null)
						{
							((List<string>)val3).Add(((string)val5).Trim());
							frmMain.actList.Add(new ActControl
							{
								Row = frmMain.actList.Count + 1,
								Id = ((string)val5).Trim(),
								_Card = "",
								Mồi = "",
								Message = "",
								Status = frmMain.STATUS.Ready.ToString()
							});
							val2 = (T2)(val2 + 1);
						}
						continue;
					}
					break;
				}
			}
			finally
			{
				if (val4 != null)
				{
					((IDisposable)val4).Dispose();
				}
			}
			frmMain.actListSaving();
			setData<T5, T2>();
		}
		catch (Exception ex)
		{
			frmMain.errorMessage((T1)ex.Message);
		}
	}

	private void setData<T0, T1>()
	{
		//IL_0020: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		gvData.ClearSelection();
		gvData.DataSource = null;
		T0 val = (T0)(frmMain.actList != null);
		if (val != null)
		{
			gvData.DataSource = frmMain.actList;
		}
		lbTotal.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)gvData.Rows.Count).ToString();
		gvData.Refresh();
		report<T0, double>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer_auto_update_Tick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_0007: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_0053: Expected I4, but got O
		//IL_0066: Expected I4, but got O
		//IL_0085: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009f: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00df: Expected I4, but got O
		try
		{
			T0 val = (T0)isActive;
			if (val != null)
			{
				T0 val2 = (T0)frmMain.isRunning;
				if (val2 == null)
				{
					return;
				}
				gvData.Refresh();
				report<T0, double>();
				T0 val3 = (T0)frmMain.setting.actControl.cbFocusGridview;
				if (val3 == null)
				{
					return;
				}
				T1 val4 = (T1)(-1);
				T1 val5 = (T1)0;
				while (true)
				{
					T0 val6 = (T0)((nint)val5 < frmMain.actList.Count);
					if (val6 == null)
					{
						break;
					}
					T0 val7 = (T0)(frmMain.actList[(int)val5].Status != null && frmMain.actList[(int)val5].Status.Equals(frmMain.STATUS.Ready.ToString()));
					if (val7 == null)
					{
						val5 = (T1)(val5 + 1);
						continue;
					}
					val4 = val5;
					break;
				}
				T0 val8 = (T0)((nint)val4 > 1 && gvData.Rows.Count > 0);
				if (val8 != null)
				{
					gvData.CurrentCell = gvData.Rows[(int)val4].Cells[0];
				}
			}
			else
			{
				btnStatus.BackColor = Color.Red;
				btnStatus.Text = "Tạm dừng";
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	private unsafe void frmActControl_Load<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_0157: Expected O, but got I4
		//IL_01f5: Expected O, but got I4
		T0 enumerator = (T0)frmMain.groupCreditCard.GetEnumerator();
		try
		{
			while (((List<GroupCreditCard>.Enumerator*)(&enumerator))->MoveNext())
			{
				GroupCreditCard current = ((List<GroupCreditCard>.Enumerator*)(&enumerator))->Current;
				ccbBinBait.Items.Add(current.Name);
			}
		}
		finally
		{
			((IDisposable)(*(List<GroupCreditCard>.Enumerator*)(&enumerator))).Dispose();
		}
		numDelayBait.Value = frmMain.setting.actControl.numDelayBait;
		txtBin6First.Text = frmMain.setting.actControl.txtBin6First;
		numCheckPayment.Value = frmMain.setting.actControl.numCheckPayment;
		ccbBinBait.Text = frmMain.setting.actControl.txtBinBait;
		txtCountryBait.Text = frmMain.setting.actControl.txtCountryBait;
		cbAddBinBait.Checked = frmMain.setting.actControl.cbAddBinBait;
		txtSearch.Text = frmMain.setting.actControl.txtSearch;
		numDelayVerifyCard.Value = frmMain.setting.actControl.numDelayVerifyCard;
		numDelayToApprovedHold.Value = frmMain.setting.actControl.numDelayToApprovedHold;
		T1 val = (T1)(frmMain.setting.actControl.numActOnVia == 0);
		if (val != null)
		{
			frmMain.setting.actControl.numActOnVia = 30;
		}
		numActOnVia.Value = frmMain.setting.actControl.numActOnVia;
		numDieToStop.Value = frmMain.setting.actControl.numDieToStop;
		numDieNext.Value = frmMain.setting.actControl.numDieNext;
		cbFocusGridview.Checked = frmMain.setting.actControl.cbFocusGridview;
		T1 val2 = (T1)(frmMain.setting.actControl.numThreadActOnVia == 0);
		if (val2 != null)
		{
			frmMain.setting.actControl.numThreadActOnVia = 1;
		}
		numThreadActOnVia.Value = frmMain.setting.actControl.numThreadActOnVia;
		timer_auto_update.Start();
	}

	private void frmActControl_FormClosing<T0, T1>(T0 sender, T1 e)
	{
		timer_auto_update.Stop();
		frmMain.actListSaving();
	}

	private void numActOnVia_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numActOnVia = int.Parse(((decimal)(T0)numActOnVia.Value).ToString());
		frmMain.settingSaving();
	}

	private void numDieToStop_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numDieToStop = int.Parse(((decimal)(T0)numDieToStop.Value).ToString());
		frmMain.settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void report<T0, T1>()
	{
		//IL_0018: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00fd: Expected O, but got F8
		//IL_0109: Expected O, but got F8
		//IL_0130: Expected O, but got F8
		//IL_013c: Expected O, but got F8
		T0 val = (T0)(frmMain.actList != null && frmMain.actList.Count > 0);
		if (val != null)
		{
			countError = ((IEnumerable<ActControl>)frmMain.actList).Where((Func<ActControl, bool>)((ActControl a) => (T0)a.Status.Equals(frmMain.STATUS.lỗi.ToString()))).Count();
			countSucess = ((IEnumerable<ActControl>)frmMain.actList).Where((Func<ActControl, bool>)((ActControl a) => (T0)a.Status.Equals(frmMain.STATUS.Done.ToString()))).Count();
			totalCount = countError + countSucess;
			T0 val2 = (T0)(totalCount > 0.0);
			if (val2 != null)
			{
				error = countError / totalCount * 100.0;
				success = countSucess / totalCount * 100.0;
				lbError.Text = $"{(T1)countError} - ({System.Runtime.CompilerServices.Unsafe.As<T1, double>(ref (T1)Math.Round(error)).ToString()}%)";
				lbSuccess.Text = $"{(T1)countSucess} - ({System.Runtime.CompilerServices.Unsafe.As<T1, double>(ref (T1)Math.Round(success)).ToString()}%)";
			}
			else
			{
				lbError.Text = "0";
				lbSuccess.Text = "0";
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnStatus_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0013: Expected O, but got I4
		isActive = !isActive;
		T0 val = (T0)isActive;
		if (val == null)
		{
			btnStatus.BackColor = Color.Red;
			btnStatus.Text = "Tạm dừng";
		}
		else
		{
			btnStatus.BackColor = Color.DodgerBlue;
			btnStatus.Text = "Hoạt động";
			CountError = 0;
		}
	}

	private void numDieNext_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numDieNext = int.Parse(((decimal)(T0)numDieNext.Value).ToString());
		frmMain.settingSaving();
	}

	private void cbFocusGridview_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.cbFocusGridview = cbFocusGridview.Checked;
		frmMain.settingSaving();
	}

	private void numDelayToApprovedHold_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numDelayToApprovedHold = int.Parse(((decimal)(T0)numDelayToApprovedHold.Value).ToString());
		frmMain.settingSaving();
	}

	private void numDelayVerifyCard_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numDelayVerifyCard = int.Parse(((decimal)(T0)numDelayVerifyCard.Value).ToString());
		frmMain.settingSaving();
	}

	private void txtSearch_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.txtSearch = txtSearch.Text;
		frmMain.settingSaving();
	}

	private void button2_Click<T0, T1>(T0 sender, T1 e)
	{
		search<string, int, bool, char>();
	}

	private void search<T0, T1, T2, T3>()
	{
		//IL_0037: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_005e: Expected I4, but got O
		//IL_0071: Expected I4, but got O
		//IL_0093: Expected I4, but got O
		//IL_00a6: Expected I4, but got O
		//IL_00c8: Expected I4, but got O
		//IL_00db: Expected I4, but got O
		//IL_00fd: Expected I4, but got O
		//IL_0110: Expected I4, but got O
		//IL_012f: Expected I4, but got O
		//IL_0142: Expected I4, but got O
		//IL_0161: Expected I4, but got O
		//IL_0174: Expected I4, but got O
		//IL_0196: Expected I4, but got O
		//IL_019d: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_01c8: Expected I4, but got O
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e4: Expected O, but got I4
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		gvData.ClearSelection();
		T0 val = (T0)txtSearch.Text.ToLower().Trim();
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
				T2 val5 = (T2)((nint)val4 < frmMain.actList.Count);
				if (val5 == null)
				{
					break;
				}
				T2 val6 = (T2)((frmMain.actList[(int)val4].Id != null && frmMain.actList[(int)val4].Id.ToLower().Contains((string)value)) || (frmMain.actList[(int)val4]._Card != null && frmMain.actList[(int)val4]._Card.ToLower().Contains((string)value)) || (frmMain.actList[(int)val4].Mồi != null && frmMain.actList[(int)val4].Mồi.ToLower().Contains((string)value)) || (frmMain.actList[(int)val4].Status != null && frmMain.actList[(int)val4].Status.ToLower().Contains((string)value)) || (frmMain.actList[(int)val4].Message != null && frmMain.actList[(int)val4].Message.ToLower().Contains((string)value)) || (frmMain.actList[(int)val4].Status != null && frmMain.actList[(int)val4].Status.ToLower().Contains((string)value)) || System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)frmMain.actList[(int)val4].Row).ToString().ToLower()
					.Contains((string)value));
				if (val6 != null)
				{
					gvData.Rows[(int)val4].Selected = true;
				}
				val4 = (T1)(val4 + 1);
			}
			val2 = (T1)(val2 + 1);
		}
	}

	private void txtSearch_KeyDown<T0, T1, T2, T3, T4, T5>(T1 sender, T2 e)
	{
		//IL_000b: Expected O, but got I4
		T0 val = (T0)(((KeyEventArgs)e).KeyCode == Keys.Return);
		if (val != null)
		{
			search<T3, T4, T0, T5>();
		}
	}

	private void label7_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private void numThreadActOnVia_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numThreadActOnVia = int.Parse(((decimal)(T0)numThreadActOnVia.Value).ToString());
		frmMain.settingSaving();
	}

	private void gvData_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0018: Expected O, but got I4
		try
		{
			lbRowSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvData.SelectedRows.Count).ToString();
		}
		catch
		{
		}
	}

	private void cbAddBinBait_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.cbAddBinBait = cbAddBinBait.Checked;
		frmMain.settingSaving();
		ccbBinBait.Enabled = frmMain.setting.actControl.cbAddBinBait;
		txtCountryBait.Enabled = frmMain.setting.actControl.cbAddBinBait;
	}

	private void txtBinBait_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.txtBinBait = ccbBinBait.Text;
		frmMain.settingSaving();
	}

	private void txtCountryBait_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.txtCountryBait = txtCountryBait.Text;
		frmMain.settingSaving();
	}

	private void numCheckPayment_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numCheckPayment = int.Parse(((decimal)(T0)numCheckPayment.Value).ToString());
		frmMain.settingSaving();
	}

	private void button1_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private void ccbBinBait_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.txtBinBait = ccbBinBait.Text.Trim();
		frmMain.settingSaving();
	}

	private void ccbBinBait_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.txtBinBait = ccbBinBait.Text.Trim();
		frmMain.settingSaving();
	}

	private void numDelayBait_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		frmMain.setting.actControl.numDelayBait = int.Parse(((decimal)(T0)numDelayBait.Value).ToString());
		frmMain.settingSaving();
	}

	private void txtBin6First_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		frmMain.setting.actControl.txtBin6First = txtBin6First.Text;
		frmMain.settingSaving();
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
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val2 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T0 val3 = (T0)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridViewCellStyle));
		T1 val4 = (T1)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmActControl));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numActOnVia = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.numDieToStop = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotal = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel2 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbSuccess = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel4 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbError = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.btnStatus = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.timer_auto_update = new System.Windows.Forms.Timer(this.components);
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDieNext = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.cbFocusGridview = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.numDelayToApprovedHold = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numDelayVerifyCard = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label6 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtSearch = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numThreadActOnVia = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label7 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label8 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtCountryBait = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.lbRowSelected = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.cbAddBinBait = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.numCheckPayment = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label9 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.ccbBinBait = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.numDelayBait = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label10 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label3 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txtBin6First = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numActOnVia).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDieToStop).BeginInit();
		this.statusStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numDieNext).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayToApprovedHold).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayVerifyCard).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThreadActOnVia).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numCheckPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayBait).BeginInit();
		base.SuspendLayout();
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
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
		((System.Windows.Forms.DataGridViewCellStyle)val2).Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		((System.Windows.Forms.DataGridViewCellStyle)val2).BackColor = System.Drawing.SystemColors.Window;
		((System.Windows.Forms.DataGridViewCellStyle)val2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		((System.Windows.Forms.DataGridViewCellStyle)val2).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.DataGridViewCellStyle)val2).SelectionBackColor = System.Drawing.SystemColors.Highlight;
		((System.Windows.Forms.DataGridViewCellStyle)val2).SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		((System.Windows.Forms.DataGridViewCellStyle)val2).WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.gvData.DefaultCellStyle = (System.Windows.Forms.DataGridViewCellStyle)val2;
		this.gvData.Location = new System.Drawing.Point(16, 163);
		this.gvData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
		this.gvData.Size = new System.Drawing.Size(1372, 590);
		this.gvData.TabIndex = 4;
		this.gvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvData_RowStateChanged<T12, T13, T14>);
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T15, T16, T17, T13, T18>);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(27, 18);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(155, 16);
		this.label1.TabIndex = 6;
		this.label1.Text = "Số lượt add thẻ trên 1 via:";
		this.numActOnVia.Location = new System.Drawing.Point(190, 15);
		this.numActOnVia.Margin = new System.Windows.Forms.Padding(4);
		this.numActOnVia.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numActOnVia.Name = "numActOnVia";
		this.numActOnVia.Size = new System.Drawing.Size(65, 22);
		this.numActOnVia.TabIndex = 7;
		this.numActOnVia.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)33,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numActOnVia.ValueChanged += new System.EventHandler(numActOnVia_ValueChanged<T19, T13, T20>);
		this.numDieToStop.Location = new System.Drawing.Point(459, 15);
		this.numDieToStop.Margin = new System.Windows.Forms.Padding(4);
		this.numDieToStop.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDieToStop.Name = "numDieToStop";
		this.numDieToStop.Size = new System.Drawing.Size(81, 22);
		this.numDieToStop.TabIndex = 9;
		this.numDieToStop.ValueChanged += new System.EventHandler(numDieToStop_ValueChanged<T19, T13, T20>);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(309, 18);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(142, 16);
		this.label2.TabIndex = 8;
		this.label2.Text = "Giới hạn via add thẻ lỗi";
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[6]
		{
			(T21)this.toolStripStatusLabel1,
			(T21)this.lbTotal,
			(T21)this.toolStripStatusLabel2,
			(T21)this.lbSuccess,
			(T21)this.toolStripStatusLabel4,
			(T21)this.lbError
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 759);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
		this.statusStrip1.Size = new System.Drawing.Size(1404, 26);
		this.statusStrip1.TabIndex = 10;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 20);
		this.toolStripStatusLabel1.Text = "Tổng:";
		this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbTotal.Name = "lbTotal";
		this.lbTotal.Size = new System.Drawing.Size(18, 20);
		this.lbTotal.Text = "0";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(89, 20);
		this.toolStripStatusLabel2.Text = "Thành công:";
		this.lbSuccess.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbSuccess.Name = "lbSuccess";
		this.lbSuccess.Size = new System.Drawing.Size(18, 20);
		this.lbSuccess.Text = "0";
		this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
		this.toolStripStatusLabel4.Size = new System.Drawing.Size(32, 20);
		this.toolStripStatusLabel4.Text = "Lỗi:";
		this.lbError.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
		this.lbError.Name = "lbError";
		this.lbError.Size = new System.Drawing.Size(18, 20);
		this.lbError.Text = "0";
		this.btnStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnStatus.BackColor = System.Drawing.Color.DodgerBlue;
		this.btnStatus.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnStatus.Location = new System.Drawing.Point(1288, 15);
		this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
		this.btnStatus.Name = "btnStatus";
		this.btnStatus.Size = new System.Drawing.Size(100, 86);
		this.btnStatus.TabIndex = 11;
		this.btnStatus.Text = "Hoạt động";
		this.btnStatus.UseVisualStyleBackColor = false;
		this.btnStatus.Click += new System.EventHandler(btnStatus_Click<T15, T13, T20>);
		this.timer_auto_update.Interval = 2000;
		this.timer_auto_update.Tick += new System.EventHandler(timer_auto_update_Tick<T15, T12, T22, T13, T20>);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(37, 47);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(145, 16);
		this.label4.TabIndex = 14;
		this.label4.Text = "Dừng lại khi lỗi liên tiếp:";
		this.numDieNext.Location = new System.Drawing.Point(190, 45);
		this.numDieNext.Margin = new System.Windows.Forms.Padding(4);
		this.numDieNext.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDieNext.Name = "numDieNext";
		this.numDieNext.Size = new System.Drawing.Size(65, 22);
		this.numDieNext.TabIndex = 15;
		this.numDieNext.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)33,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDieNext.ValueChanged += new System.EventHandler(numDieNext_ValueChanged<T19, T13, T20>);
		this.cbFocusGridview.AutoSize = true;
		this.cbFocusGridview.Location = new System.Drawing.Point(776, 17);
		this.cbFocusGridview.Name = "cbFocusGridview";
		this.cbFocusGridview.Size = new System.Drawing.Size(119, 20);
		this.cbFocusGridview.TabIndex = 16;
		this.cbFocusGridview.Text = "Focus gridview";
		this.cbFocusGridview.UseVisualStyleBackColor = true;
		this.cbFocusGridview.CheckedChanged += new System.EventHandler(cbFocusGridview_CheckedChanged);
		this.numDelayToApprovedHold.Location = new System.Drawing.Point(706, 42);
		this.numDelayToApprovedHold.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayToApprovedHold.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelayToApprovedHold.Name = "numDelayToApprovedHold";
		this.numDelayToApprovedHold.Size = new System.Drawing.Size(65, 22);
		this.numDelayToApprovedHold.TabIndex = 18;
		this.numDelayToApprovedHold.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)33,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelayToApprovedHold.ValueChanged += new System.EventHandler(numDelayToApprovedHold_ValueChanged<T19, T13, T20>);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(547, 44);
		this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(151, 16);
		this.label5.TabIndex = 17;
		this.label5.Text = "Delay to approved hold:";
		this.numDelayVerifyCard.Location = new System.Drawing.Point(887, 72);
		this.numDelayVerifyCard.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayVerifyCard.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelayVerifyCard.Name = "numDelayVerifyCard";
		this.numDelayVerifyCard.Size = new System.Drawing.Size(65, 22);
		this.numDelayVerifyCard.TabIndex = 20;
		this.numDelayVerifyCard.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)33,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelayVerifyCard.ValueChanged += new System.EventHandler(numDelayVerifyCard_ValueChanged<T19, T13, T20>);
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(776, 74);
		this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(103, 16);
		this.label6.TabIndex = 19;
		this.label6.Text = "Delay to XM thẻ:";
		this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearch.Location = new System.Drawing.Point(16, 132);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(1291, 22);
		this.txtSearch.TabIndex = 21;
		this.txtSearch.TextChanged += new System.EventHandler(txtSearch_TextChanged);
		this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(txtSearch_KeyDown<T15, T13, T23, T24, T12, T25>);
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.Location = new System.Drawing.Point(1313, 132);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 23);
		this.button2.TabIndex = 22;
		this.button2.Text = "Tìm kiếm";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.numThreadActOnVia.Location = new System.Drawing.Point(706, 16);
		this.numThreadActOnVia.Margin = new System.Windows.Forms.Padding(4);
		this.numThreadActOnVia.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numThreadActOnVia.Name = "numThreadActOnVia";
		this.numThreadActOnVia.Size = new System.Drawing.Size(65, 22);
		this.numThreadActOnVia.TabIndex = 24;
		this.numThreadActOnVia.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)1,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numThreadActOnVia.ValueChanged += new System.EventHandler(numThreadActOnVia_ValueChanged<T19, T13, T20>);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(582, 18);
		this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(116, 16);
		this.label7.TabIndex = 23;
		this.label7.Text = "Luồng via add thẻ:";
		this.label7.Click += new System.EventHandler(label7_Click);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(296, 76);
		this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(89, 16);
		this.label8.TabIndex = 27;
		this.label8.Text = "Quốc gia mồi:";
		this.txtCountryBait.Location = new System.Drawing.Point(392, 73);
		this.txtCountryBait.Name = "txtCountryBait";
		this.txtCountryBait.Size = new System.Drawing.Size(86, 22);
		this.txtCountryBait.TabIndex = 28;
		this.txtCountryBait.TextChanged += new System.EventHandler(txtCountryBait_TextChanged);
		this.lbRowSelected.AutoSize = true;
		this.lbRowSelected.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbRowSelected.Location = new System.Drawing.Point(19, 167);
		this.lbRowSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lbRowSelected.Name = "lbRowSelected";
		this.lbRowSelected.Size = new System.Drawing.Size(18, 17);
		this.lbRowSelected.TabIndex = 55;
		this.lbRowSelected.Text = "0";
		this.cbAddBinBait.AutoSize = true;
		this.cbAddBinBait.Location = new System.Drawing.Point(22, 76);
		this.cbAddBinBait.Name = "cbAddBinBait";
		this.cbAddBinBait.Size = new System.Drawing.Size(100, 20);
		this.cbAddBinBait.TabIndex = 56;
		this.cbAddBinBait.Text = "Add bin mồi";
		this.cbAddBinBait.UseVisualStyleBackColor = true;
		this.cbAddBinBait.CheckedChanged += new System.EventHandler(cbAddBinBait_CheckedChanged);
		this.numCheckPayment.Location = new System.Drawing.Point(887, 45);
		this.numCheckPayment.Margin = new System.Windows.Forms.Padding(4);
		this.numCheckPayment.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numCheckPayment.Name = "numCheckPayment";
		this.numCheckPayment.Size = new System.Drawing.Size(65, 22);
		this.numCheckPayment.TabIndex = 58;
		this.numCheckPayment.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)33,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numCheckPayment.ValueChanged += new System.EventHandler(numCheckPayment_ValueChanged<T19, T13, T20>);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(776, 47);
		this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(103, 16);
		this.label9.TabIndex = 57;
		this.label9.Text = "Check payment:";
		this.ccbBinBait.FormattingEnabled = true;
		this.ccbBinBait.Location = new System.Drawing.Point(128, 73);
		this.ccbBinBait.Name = "ccbBinBait";
		this.ccbBinBait.Size = new System.Drawing.Size(161, 24);
		this.ccbBinBait.TabIndex = 59;
		this.ccbBinBait.SelectedIndexChanged += new System.EventHandler(ccbBinBait_SelectedIndexChanged);
		this.ccbBinBait.TextChanged += new System.EventHandler(ccbBinBait_TextChanged);
		this.numDelayBait.Location = new System.Drawing.Point(703, 75);
		this.numDelayBait.Margin = new System.Windows.Forms.Padding(4);
		this.numDelayBait.Maximum = new decimal((int[])(object)new T12[4]
		{
			(T12)99999,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelayBait.Name = "numDelayBait";
		this.numDelayBait.Size = new System.Drawing.Size(65, 22);
		this.numDelayBait.TabIndex = 62;
		this.numDelayBait.Value = new decimal((int[])(object)new T12[4]
		{
			(T12)33,
			default(T12),
			default(T12),
			default(T12)
		});
		this.numDelayBait.ValueChanged += new System.EventHandler(numDelayBait_ValueChanged<T19, T13, T20>);
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(633, 77);
		this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(71, 16);
		this.label10.TabIndex = 61;
		this.label10.Text = "Delay mồi:";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(27, 106);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(80, 16);
		this.label3.TabIndex = 63;
		this.label3.Text = "Bin 6 số đầu";
		this.txtBin6First.Location = new System.Drawing.Point(128, 103);
		this.txtBin6First.Name = "txtBin6First";
		this.txtBin6First.Size = new System.Drawing.Size(161, 22);
		this.txtBin6First.TabIndex = 64;
		this.txtBin6First.TextChanged += new System.EventHandler(txtBin6First_TextChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1404, 785);
		base.Controls.Add(this.txtBin6First);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.numDelayBait);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.ccbBinBait);
		base.Controls.Add(this.numCheckPayment);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.cbAddBinBait);
		base.Controls.Add(this.lbRowSelected);
		base.Controls.Add(this.txtCountryBait);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.numThreadActOnVia);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.txtSearch);
		base.Controls.Add(this.numDelayVerifyCard);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.numDelayToApprovedHold);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.cbFocusGridview);
		base.Controls.Add(this.numDieNext);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.btnStatus);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.numDieToStop);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numActOnVia);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.gvData);
		base.Icon = (System.Drawing.Icon)(T26)((System.Resources.ResourceManager)val4).GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmActControl";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Trình quản lý TKQC";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmActControl_FormClosing);
		base.Load += new System.EventHandler(frmActControl_Load<T28, T15, T13, T20>);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numActOnVia).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDieToStop).EndInit();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numDieNext).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayToApprovedHold).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayVerifyCard).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThreadActOnVia).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numCheckPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numDelayBait).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
